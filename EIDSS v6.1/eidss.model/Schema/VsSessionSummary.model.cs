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
    public abstract partial class VsSessionSummary : 
        EditableObject<VsSessionSummary>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsVSSessionSummary), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsVSSessionSummary { get; set; }
                
        [LocalizedDisplayName(_str_idfVectorSurveillanceSession)]
        [MapField(_str_idfVectorSurveillanceSession)]
        public abstract Int64 idfVectorSurveillanceSession { get; set; }
        protected Int64 idfVectorSurveillanceSession_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfVectorSurveillanceSession).OriginalValue; } }
        protected Int64 idfVectorSurveillanceSession_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfVectorSurveillanceSession).PreviousValue; } }
                
        [LocalizedDisplayName("VsSessionSummary.RecordID")]
        [MapField(_str_strVSSessionSummaryID)]
        public abstract String strVSSessionSummaryID { get; set; }
        protected String strVSSessionSummaryID_Original { get { return ((EditableValue<String>)((dynamic)this)._strVSSessionSummaryID).OriginalValue; } }
        protected String strVSSessionSummaryID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVSSessionSummaryID).PreviousValue; } }
                
        [LocalizedDisplayName("AsSessionCase.strGeoLocation")]
        [MapField(_str_idfGeoLocation)]
        public abstract Int64 idfGeoLocation { get; set; }
        protected Int64 idfGeoLocation_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfGeoLocation).OriginalValue; } }
        protected Int64 idfGeoLocation_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfGeoLocation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datCollectionDateTime)]
        [MapField(_str_datCollectionDateTime)]
        public abstract DateTime? datCollectionDateTime { get; set; }
        protected DateTime? datCollectionDateTime_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCollectionDateTime).OriginalValue; } }
        protected DateTime? datCollectionDateTime_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCollectionDateTime).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsVectorType)]
        [MapField(_str_idfsVectorType)]
        public abstract Int64 idfsVectorType { get; set; }
        protected Int64 idfsVectorType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).OriginalValue; } }
        protected Int64 idfsVectorType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).PreviousValue; } }
                
        [LocalizedDisplayName("idfsVectorType")]
        [MapField(_str_strVectorType)]
        public abstract String strVectorType { get; set; }
        protected String strVectorType_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).OriginalValue; } }
        protected String strVectorType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsVectorSubType)]
        [MapField(_str_idfsVectorSubType)]
        public abstract Int64 idfsVectorSubType { get; set; }
        protected Int64 idfsVectorSubType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSubType).OriginalValue; } }
        protected Int64 idfsVectorSubType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSubType).PreviousValue; } }
                
        [LocalizedDisplayName("idfsVectorSubType")]
        [MapField(_str_strVectorSubType)]
        public abstract String strVectorSubType { get; set; }
        protected String strVectorSubType_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorSubType).OriginalValue; } }
        protected String strVectorSubType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorSubType).PreviousValue; } }
                
        [LocalizedDisplayName("idfsAnimalGender")]
        [MapField(_str_idfsSex)]
        public abstract Int64? idfsSex { get; set; }
        protected Int64? idfsSex_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSex).OriginalValue; } }
        protected Int64? idfsSex_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSex).PreviousValue; } }
                
        [LocalizedDisplayName("idfsAnimalGender")]
        [MapField(_str_strSex)]
        public abstract String strSex { get; set; }
        protected String strSex_Original { get { return ((EditableValue<String>)((dynamic)this)._strSex).OriginalValue; } }
        protected String strSex_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSex).PreviousValue; } }
                
        [LocalizedDisplayName("VsSessionSummary.intQuantity")]
        [MapField(_str_intQuantity)]
        public abstract Int32? intQuantity { get; set; }
        protected Int32? intQuantity_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intQuantity).OriginalValue; } }
        protected Int32? intQuantity_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intQuantity).PreviousValue; } }
                
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
            internal Func<VsSessionSummary, object> _get_func;
            internal Action<VsSessionSummary, string> _set_func;
            internal Action<VsSessionSummary, VsSessionSummary, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsVSSessionSummary = "idfsVSSessionSummary";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_strVSSessionSummaryID = "strVSSessionSummaryID";
        internal const string _str_idfGeoLocation = "idfGeoLocation";
        internal const string _str_datCollectionDateTime = "datCollectionDateTime";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_strVectorType = "strVectorType";
        internal const string _str_idfsVectorSubType = "idfsVectorSubType";
        internal const string _str_strVectorSubType = "strVectorSubType";
        internal const string _str_idfsSex = "idfsSex";
        internal const string _str_strSex = "strSex";
        internal const string _str_intQuantity = "intQuantity";
        internal const string _str_intRowStatus = "intRowStatus";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_Session = "Session";
        internal const string _str_datStartDateFromSession = "datStartDateFromSession";
        internal const string _str_strDiagnosesSummary = "strDiagnosesSummary";
        internal const string _str_strLocation = "strLocation";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_Diagnoses = "Diagnoses";
        internal const string _str_VectorType = "VectorType";
        internal const string _str_VectorSubType = "VectorSubType";
        internal const string _str_AnimalGender = "AnimalGender";
        internal const string _str_DiagnosisList = "DiagnosisList";
        internal const string _str_Location = "Location";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsVSSessionSummary, _formname = _str_idfsVSSessionSummary, _type = "Int64",
              _get_func = o => o.idfsVSSessionSummary,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsVSSessionSummary != newval) o.idfsVSSessionSummary = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsVSSessionSummary != c.idfsVSSessionSummary || o.IsRIRPropChanged(_str_idfsVSSessionSummary, c)) 
                  m.Add(_str_idfsVSSessionSummary, o.ObjectIdent + _str_idfsVSSessionSummary, o.ObjectIdent2 + _str_idfsVSSessionSummary, o.ObjectIdent3 + _str_idfsVSSessionSummary, "Int64", 
                    o.idfsVSSessionSummary == null ? "" : o.idfsVSSessionSummary.ToString(),                  
                  o.IsReadOnly(_str_idfsVSSessionSummary), o.IsInvisible(_str_idfsVSSessionSummary), o.IsRequired(_str_idfsVSSessionSummary)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _formname = _str_idfVectorSurveillanceSession, _type = "Int64",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVectorSurveillanceSession != newval) o.idfVectorSurveillanceSession = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, o.ObjectIdent2 + _str_idfVectorSurveillanceSession, o.ObjectIdent3 + _str_idfVectorSurveillanceSession, "Int64", 
                    o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(),                  
                  o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strVSSessionSummaryID, _formname = _str_strVSSessionSummaryID, _type = "String",
              _get_func = o => o.strVSSessionSummaryID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVSSessionSummaryID != newval) o.strVSSessionSummaryID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strVSSessionSummaryID != c.strVSSessionSummaryID || o.IsRIRPropChanged(_str_strVSSessionSummaryID, c)) 
                  m.Add(_str_strVSSessionSummaryID, o.ObjectIdent + _str_strVSSessionSummaryID, o.ObjectIdent2 + _str_strVSSessionSummaryID, o.ObjectIdent3 + _str_strVSSessionSummaryID, "String", 
                    o.strVSSessionSummaryID == null ? "" : o.strVSSessionSummaryID.ToString(),                  
                  o.IsReadOnly(_str_strVSSessionSummaryID), o.IsInvisible(_str_strVSSessionSummaryID), o.IsRequired(_str_strVSSessionSummaryID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfGeoLocation, _formname = _str_idfGeoLocation, _type = "Int64",
              _get_func = o => o.idfGeoLocation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfGeoLocation != newval) o.idfGeoLocation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfGeoLocation != c.idfGeoLocation || o.IsRIRPropChanged(_str_idfGeoLocation, c)) 
                  m.Add(_str_idfGeoLocation, o.ObjectIdent + _str_idfGeoLocation, o.ObjectIdent2 + _str_idfGeoLocation, o.ObjectIdent3 + _str_idfGeoLocation, "Int64", 
                    o.idfGeoLocation == null ? "" : o.idfGeoLocation.ToString(),                  
                  o.IsReadOnly(_str_idfGeoLocation), o.IsInvisible(_str_idfGeoLocation), o.IsRequired(_str_idfGeoLocation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datCollectionDateTime, _formname = _str_datCollectionDateTime, _type = "DateTime?",
              _get_func = o => o.datCollectionDateTime,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datCollectionDateTime != newval) o.datCollectionDateTime = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datCollectionDateTime != c.datCollectionDateTime || o.IsRIRPropChanged(_str_datCollectionDateTime, c)) 
                  m.Add(_str_datCollectionDateTime, o.ObjectIdent + _str_datCollectionDateTime, o.ObjectIdent2 + _str_datCollectionDateTime, o.ObjectIdent3 + _str_datCollectionDateTime, "DateTime?", 
                    o.datCollectionDateTime == null ? "" : o.datCollectionDateTime.ToString(),                  
                  o.IsReadOnly(_str_datCollectionDateTime), o.IsInvisible(_str_datCollectionDateTime), o.IsRequired(_str_datCollectionDateTime)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsVectorType, _formname = _str_idfsVectorType, _type = "Int64",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsVectorType != newval) 
                  o.VectorType = o.VectorTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsVectorType != newval) o.idfsVectorType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) 
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, o.ObjectIdent2 + _str_idfsVectorType, o.ObjectIdent3 + _str_idfsVectorType, "Int64", 
                    o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(),                  
                  o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strVectorType, _formname = _str_strVectorType, _type = "String",
              _get_func = o => o.strVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectorType != newval) o.strVectorType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strVectorType != c.strVectorType || o.IsRIRPropChanged(_str_strVectorType, c)) 
                  m.Add(_str_strVectorType, o.ObjectIdent + _str_strVectorType, o.ObjectIdent2 + _str_strVectorType, o.ObjectIdent3 + _str_strVectorType, "String", 
                    o.strVectorType == null ? "" : o.strVectorType.ToString(),                  
                  o.IsReadOnly(_str_strVectorType), o.IsInvisible(_str_strVectorType), o.IsRequired(_str_strVectorType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsVectorSubType, _formname = _str_idfsVectorSubType, _type = "Int64",
              _get_func = o => o.idfsVectorSubType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsVectorSubType != newval) 
                  o.VectorSubType = o.VectorSubTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsVectorSubType != newval) o.idfsVectorSubType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_idfsVectorSubType, c)) 
                  m.Add(_str_idfsVectorSubType, o.ObjectIdent + _str_idfsVectorSubType, o.ObjectIdent2 + _str_idfsVectorSubType, o.ObjectIdent3 + _str_idfsVectorSubType, "Int64", 
                    o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(),                  
                  o.IsReadOnly(_str_idfsVectorSubType), o.IsInvisible(_str_idfsVectorSubType), o.IsRequired(_str_idfsVectorSubType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strVectorSubType, _formname = _str_strVectorSubType, _type = "String",
              _get_func = o => o.strVectorSubType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectorSubType != newval) o.strVectorSubType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strVectorSubType != c.strVectorSubType || o.IsRIRPropChanged(_str_strVectorSubType, c)) 
                  m.Add(_str_strVectorSubType, o.ObjectIdent + _str_strVectorSubType, o.ObjectIdent2 + _str_strVectorSubType, o.ObjectIdent3 + _str_strVectorSubType, "String", 
                    o.strVectorSubType == null ? "" : o.strVectorSubType.ToString(),                  
                  o.IsReadOnly(_str_strVectorSubType), o.IsInvisible(_str_strVectorSubType), o.IsRequired(_str_strVectorSubType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSex, _formname = _str_idfsSex, _type = "Int64?",
              _get_func = o => o.idfsSex,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsSex != newval) 
                  o.AnimalGender = o.AnimalGenderLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsSex != newval) o.idfsSex = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSex != c.idfsSex || o.IsRIRPropChanged(_str_idfsSex, c)) 
                  m.Add(_str_idfsSex, o.ObjectIdent + _str_idfsSex, o.ObjectIdent2 + _str_idfsSex, o.ObjectIdent3 + _str_idfsSex, "Int64?", 
                    o.idfsSex == null ? "" : o.idfsSex.ToString(),                  
                  o.IsReadOnly(_str_idfsSex), o.IsInvisible(_str_idfsSex), o.IsRequired(_str_idfsSex)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSex, _formname = _str_strSex, _type = "String",
              _get_func = o => o.strSex,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSex != newval) o.strSex = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSex != c.strSex || o.IsRIRPropChanged(_str_strSex, c)) 
                  m.Add(_str_strSex, o.ObjectIdent + _str_strSex, o.ObjectIdent2 + _str_strSex, o.ObjectIdent3 + _str_strSex, "String", 
                    o.strSex == null ? "" : o.strSex.ToString(),                  
                  o.IsReadOnly(_str_strSex), o.IsInvisible(_str_strSex), o.IsRequired(_str_strSex)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intQuantity, _formname = _str_intQuantity, _type = "Int32?",
              _get_func = o => o.intQuantity,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intQuantity != newval) o.intQuantity = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intQuantity != c.intQuantity || o.IsRIRPropChanged(_str_intQuantity, c)) 
                  m.Add(_str_intQuantity, o.ObjectIdent + _str_intQuantity, o.ObjectIdent2 + _str_intQuantity, o.ObjectIdent3 + _str_intQuantity, "Int32?", 
                    o.intQuantity == null ? "" : o.intQuantity.ToString(),                  
                  o.IsReadOnly(_str_intQuantity), o.IsInvisible(_str_intQuantity), o.IsRequired(_str_intQuantity)); 
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
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "long?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) {
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis,  "long?", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                    o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_Session, _formname = _str_Session, _type = "VsSession",
              _get_func = o => o.Session,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_datStartDateFromSession, _formname = _str_datStartDateFromSession, _type = "DateTime?",
              _get_func = o => o.datStartDateFromSession,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.datStartDateFromSession != c.datStartDateFromSession || o.IsRIRPropChanged(_str_datStartDateFromSession, c)) {
                  m.Add(_str_datStartDateFromSession, o.ObjectIdent + _str_datStartDateFromSession, o.ObjectIdent2 + _str_datStartDateFromSession, o.ObjectIdent3 + _str_datStartDateFromSession, "DateTime?", o.datStartDateFromSession == null ? "" : o.datStartDateFromSession.ToString(), o.IsReadOnly(_str_datStartDateFromSession), o.IsInvisible(_str_datStartDateFromSession), o.IsRequired(_str_datStartDateFromSession));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strDiagnosesSummary, _formname = _str_strDiagnosesSummary, _type = "string",
              _get_func = o => o.strDiagnosesSummary,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnosesSummary != newval) o.strDiagnosesSummary = newval;  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strDiagnosesSummary != c.strDiagnosesSummary || o.IsRIRPropChanged(_str_strDiagnosesSummary, c)) {
                  m.Add(_str_strDiagnosesSummary, o.ObjectIdent + _str_strDiagnosesSummary, o.ObjectIdent2 + _str_strDiagnosesSummary, o.ObjectIdent3 + _str_strDiagnosesSummary, "string", o.strDiagnosesSummary == null ? "" : o.strDiagnosesSummary.ToString(), o.IsReadOnly(_str_strDiagnosesSummary), o.IsInvisible(_str_strDiagnosesSummary), o.IsRequired(_str_strDiagnosesSummary));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strLocation, _formname = _str_strLocation, _type = "string",
              _get_func = o => o.strLocation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strLocation != newval) o.strLocation = newval;  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strLocation != c.strLocation || o.IsRIRPropChanged(_str_strLocation, c)) {
                  m.Add(_str_strLocation, o.ObjectIdent + _str_strLocation, o.ObjectIdent2 + _str_strLocation, o.ObjectIdent3 + _str_strLocation, "string", o.strLocation == null ? "" : o.strLocation.ToString(), o.IsReadOnly(_str_strLocation), o.IsInvisible(_str_strLocation), o.IsRequired(_str_strLocation));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_CaseObjectIdent, _formname = _str_CaseObjectIdent, _type = "string",
              _get_func = o => o.CaseObjectIdent,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.CaseObjectIdent != c.CaseObjectIdent || o.IsRIRPropChanged(_str_CaseObjectIdent, c)) {
                  m.Add(_str_CaseObjectIdent, o.ObjectIdent + _str_CaseObjectIdent, o.ObjectIdent2 + _str_CaseObjectIdent, o.ObjectIdent3 + _str_CaseObjectIdent, "string", o.CaseObjectIdent == null ? "" : o.CaseObjectIdent.ToString(), o.IsReadOnly(_str_CaseObjectIdent), o.IsInvisible(_str_CaseObjectIdent), o.IsRequired(_str_CaseObjectIdent));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Diagnoses, _formname = _str_Diagnoses, _type = "Lookup",
              _get_func = o => { if (o.Diagnoses == null) return null; return o.Diagnoses.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnoses = o.DiagnosesLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Diagnoses, c);
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnoses, c) || bChangeLookupContent) {
                  m.Add(_str_Diagnoses, o.ObjectIdent + _str_Diagnoses, o.ObjectIdent2 + _str_Diagnoses, o.ObjectIdent3 + _str_Diagnoses, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnoses), o.IsInvisible(_str_Diagnoses), o.IsRequired(_str_Diagnoses),
                  bChangeLookupContent ? o.DiagnosesLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Diagnoses + "Lookup", _formname = _str_Diagnoses + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosesLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_VectorType, _formname = _str_VectorType, _type = "Lookup",
              _get_func = o => { if (o.VectorType == null) return null; return o.VectorType.idfsBaseReference; },
              _set_func = (o, val) => { o.VectorType = o.VectorTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_VectorType, c);
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_VectorType, c) || bChangeLookupContent) {
                  m.Add(_str_VectorType, o.ObjectIdent + _str_VectorType, o.ObjectIdent2 + _str_VectorType, o.ObjectIdent3 + _str_VectorType, "Lookup", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_VectorType), o.IsInvisible(_str_VectorType), o.IsRequired(_str_VectorType),
                  bChangeLookupContent ? o.VectorTypeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_VectorType + "Lookup", _formname = _str_VectorType + "Lookup", _type = "LookupContent",
              _get_func = o => o.VectorTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_VectorSubType, _formname = _str_VectorSubType, _type = "Lookup",
              _get_func = o => { if (o.VectorSubType == null) return null; return o.VectorSubType.idfsBaseReference; },
              _set_func = (o, val) => { o.VectorSubType = o.VectorSubTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_VectorSubType, c);
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_VectorSubType, c) || bChangeLookupContent) {
                  m.Add(_str_VectorSubType, o.ObjectIdent + _str_VectorSubType, o.ObjectIdent2 + _str_VectorSubType, o.ObjectIdent3 + _str_VectorSubType, "Lookup", o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(), o.IsReadOnly(_str_VectorSubType), o.IsInvisible(_str_VectorSubType), o.IsRequired(_str_VectorSubType),
                  bChangeLookupContent ? o.VectorSubTypeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_VectorSubType + "Lookup", _formname = _str_VectorSubType + "Lookup", _type = "LookupContent",
              _get_func = o => o.VectorSubTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_AnimalGender, _formname = _str_AnimalGender, _type = "Lookup",
              _get_func = o => { if (o.AnimalGender == null) return null; return o.AnimalGender.idfsBaseReference; },
              _set_func = (o, val) => { o.AnimalGender = o.AnimalGenderLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AnimalGender, c);
                if (o.idfsSex != c.idfsSex || o.IsRIRPropChanged(_str_AnimalGender, c) || bChangeLookupContent) {
                  m.Add(_str_AnimalGender, o.ObjectIdent + _str_AnimalGender, o.ObjectIdent2 + _str_AnimalGender, o.ObjectIdent3 + _str_AnimalGender, "Lookup", o.idfsSex == null ? "" : o.idfsSex.ToString(), o.IsReadOnly(_str_AnimalGender), o.IsInvisible(_str_AnimalGender), o.IsRequired(_str_AnimalGender),
                  bChangeLookupContent ? o.AnimalGenderLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AnimalGender + "Lookup", _formname = _str_AnimalGender + "Lookup", _type = "LookupContent",
              _get_func = o => o.AnimalGenderLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_DiagnosisList, _formname = _str_DiagnosisList, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.DiagnosisList.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.DiagnosisList.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.DiagnosisList.Count != c.DiagnosisList.Count || o.IsReadOnly(_str_DiagnosisList) != c.IsReadOnly(_str_DiagnosisList) || o.IsInvisible(_str_DiagnosisList) != c.IsInvisible(_str_DiagnosisList) || o.IsRequired(_str_DiagnosisList) != c._isRequired(o.m_isRequired, _str_DiagnosisList)) {
                  m.Add(_str_DiagnosisList, o.ObjectIdent + _str_DiagnosisList, o.ObjectIdent2 + _str_DiagnosisList, o.ObjectIdent3 + _str_DiagnosisList, "Child", o.idfsVSSessionSummary == null ? "" : o.idfsVSSessionSummary.ToString(), o.IsReadOnly(_str_DiagnosisList), o.IsInvisible(_str_DiagnosisList), o.IsRequired(_str_DiagnosisList)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Location, _formname = _str_Location, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.Location != null) o.Location._compare(c.Location, m); }
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
            VsSessionSummary obj = (VsSessionSummary)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_DiagnosisList)]
        [Relation(typeof(VsSessionSummaryDiagnosis), eidss.model.Schema.VsSessionSummaryDiagnosis._str_idfsVSSessionSummary, _str_idfsVSSessionSummary)]
        public EditableList<VsSessionSummaryDiagnosis> DiagnosisList
        {
            get 
            {   
                return _DiagnosisList; 
            }
            set 
            {
                _DiagnosisList = value;
            }
        }
        protected EditableList<VsSessionSummaryDiagnosis> _DiagnosisList = new EditableList<VsSessionSummaryDiagnosis>();
                    
        [LocalizedDisplayName(_str_Location)]
        [Relation(typeof(GeoLocation), eidss.model.Schema.GeoLocation._str_idfGeoLocation, _str_idfGeoLocation)]
        public GeoLocation Location
        {
            get 
            {   
                return _Location; 
            }
            set 
            {   
                _Location = value;
                if (_Location != null) 
                { 
                    _Location.m_ObjectName = _str_Location;
                    _Location.Parent = this;
                }
                idfGeoLocation = _Location == null 
                        ? new Int64()
                        : _Location.idfGeoLocation;
                
            }
        }
        protected GeoLocation _Location;
                    
        [LocalizedDisplayName(_str_Diagnoses)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnoses
        {
            get { return _Diagnoses == null ? null : ((long)_Diagnoses.Key == 0 ? null : _Diagnoses); }
            set 
            { 
                var oldVal = _Diagnoses;
                _Diagnoses = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Diagnoses != oldVal)
                {
                    if (idfsDiagnosis != (_Diagnoses == null
                            ? new long?()
                            : _Diagnoses.idfsDiagnosis))
                        idfsDiagnosis = _Diagnoses == null 
                            ? new long?()
                            : _Diagnoses.idfsDiagnosis; 
                    OnPropertyChanged(_str_Diagnoses); 
                }
            }
        }
        private DiagnosisLookup _Diagnoses;

        
        public List<DiagnosisLookup> DiagnosesLookup
        {
            get { return _DiagnosesLookup; }
        }
        private List<DiagnosisLookup> _DiagnosesLookup = new List<DiagnosisLookup>();
            
        [LocalizedDisplayName(_str_VectorType)]
        [Relation(typeof(VectorTypeLookup), eidss.model.Schema.VectorTypeLookup._str_idfsBaseReference, _str_idfsVectorType)]
        public VectorTypeLookup VectorType
        {
            get { return _VectorType == null ? null : ((long)_VectorType.Key == 0 ? null : _VectorType); }
            set 
            { 
                var oldVal = _VectorType;
                _VectorType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_VectorType != oldVal)
                {
                    if (idfsVectorType != (_VectorType == null
                            ? new Int64()
                            : (Int64)_VectorType.idfsBaseReference))
                        idfsVectorType = _VectorType == null 
                            ? new Int64()
                            : (Int64)_VectorType.idfsBaseReference; 
                    OnPropertyChanged(_str_VectorType); 
                }
            }
        }
        private VectorTypeLookup _VectorType;

        
        public List<VectorTypeLookup> VectorTypeLookup
        {
            get { return _VectorTypeLookup; }
        }
        private List<VectorTypeLookup> _VectorTypeLookup = new List<VectorTypeLookup>();
            
        [LocalizedDisplayName(_str_VectorSubType)]
        [Relation(typeof(VectorSubTypeLookup), eidss.model.Schema.VectorSubTypeLookup._str_idfsBaseReference, _str_idfsVectorSubType)]
        public VectorSubTypeLookup VectorSubType
        {
            get { return _VectorSubType == null ? null : ((long)_VectorSubType.Key == 0 ? null : _VectorSubType); }
            set 
            { 
                var oldVal = _VectorSubType;
                _VectorSubType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_VectorSubType != oldVal)
                {
                    if (idfsVectorSubType != (_VectorSubType == null
                            ? new Int64()
                            : (Int64)_VectorSubType.idfsBaseReference))
                        idfsVectorSubType = _VectorSubType == null 
                            ? new Int64()
                            : (Int64)_VectorSubType.idfsBaseReference; 
                    OnPropertyChanged(_str_VectorSubType); 
                }
            }
        }
        private VectorSubTypeLookup _VectorSubType;

        
        public List<VectorSubTypeLookup> VectorSubTypeLookup
        {
            get { return _VectorSubTypeLookup; }
        }
        private List<VectorSubTypeLookup> _VectorSubTypeLookup = new List<VectorSubTypeLookup>();
            
        [LocalizedDisplayName(_str_AnimalGender)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSex)]
        public BaseReference AnimalGender
        {
            get { return _AnimalGender == null ? null : ((long)_AnimalGender.Key == 0 ? null : _AnimalGender); }
            set 
            { 
                var oldVal = _AnimalGender;
                _AnimalGender = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AnimalGender != oldVal)
                {
                    if (idfsSex != (_AnimalGender == null
                            ? new Int64?()
                            : (Int64?)_AnimalGender.idfsBaseReference))
                        idfsSex = _AnimalGender == null 
                            ? new Int64?()
                            : (Int64?)_AnimalGender.idfsBaseReference; 
                    OnPropertyChanged(_str_AnimalGender); 
                }
            }
        }
        private BaseReference _AnimalGender;

        
        public BaseReferenceList AnimalGenderLookup
        {
            get { return _AnimalGenderLookup; }
        }
        private BaseReferenceList _AnimalGenderLookup = new BaseReferenceList("rftAnimalSex");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnoses:
                    return new BvSelectList(DiagnosesLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnoses, _str_idfsDiagnosis);
            
                case _str_VectorType:
                    return new BvSelectList(VectorTypeLookup, eidss.model.Schema.VectorTypeLookup._str_idfsBaseReference, null, VectorType, _str_idfsVectorType);
            
                case _str_VectorSubType:
                    return new BvSelectList(VectorSubTypeLookup, eidss.model.Schema.VectorSubTypeLookup._str_idfsBaseReference, null, VectorSubType, _str_idfsVectorSubType);
            
                case _str_AnimalGender:
                    return new BvSelectList(AnimalGenderLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AnimalGender, _str_idfsSex);
            
                case _str_DiagnosisList:
                    return new BvSelectList(DiagnosisList, "", "", null, "");
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_Session)]
        public VsSession Session
        {
            get { return new Func<VsSessionSummary, VsSession>(c => Parent as VsSession)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_datStartDateFromSession)]
        public DateTime? datStartDateFromSession
        {
            get { return new Func<VsSessionSummary, DateTime?>(c => c.Session != null ? c.Session.datStartDate : DateTime.Now)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strDiagnosesSummary)]
        public string strDiagnosesSummary
        {
            get { return new Func<VsSessionSummary, string>(c => {var sb = new StringBuilder();foreach (var d in c.DiagnosisList){if (!sb.ToString().Contains(d.strDiagnosis) && !d.IsMarkedToDelete) sb.AppendFormat(sb.Length == 0 ? "{0} ({1})" : ", {0} ({1})", d.strDiagnosis, d.intPositiveQuantity);}return sb.ToString();})(this); }
            
            set { ; OnPropertyChanged(_str_strDiagnosesSummary); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("LocationDisplayName")]
        public string strLocation
        {
            get { return new Func<VsSessionSummary, string>(c => c.Location != null ? c.Location.LocationDisplayName : String.Empty)(this); }
            
            set { ; OnPropertyChanged(_str_strLocation); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<VsSessionSummary, string>(c => "Summaries_" + c.idfsVSSessionSummary + "_")(this); }
            
        }
        
          [LocalizedDisplayName(_str_idfsDiagnosis)]
        public long? idfsDiagnosis
        {
            get { return m_idfsDiagnosis; }
            set { if (m_idfsDiagnosis != value) { m_idfsDiagnosis = value; OnPropertyChanged(_str_idfsDiagnosis); } }
        }
        private long? m_idfsDiagnosis;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VsSessionSummary";

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
        DiagnosisList.ForEach(c => { c.Parent = this; });
                
            if (_Location != null) { _Location.Parent = this; }
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as VsSessionSummary;
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
            var ret = base.Clone() as VsSessionSummary;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_DiagnosisList != null && _DiagnosisList.Count > 0)
            {
              ret.DiagnosisList.Clear();
              _DiagnosisList.ForEach(c => ret.DiagnosisList.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_Location != null)
              ret.Location = _Location.CloneWithSetup(manager, bRestricted) as GeoLocation;
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public VsSessionSummary CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VsSessionSummary;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsVSSessionSummary; } }
        public string KeyName { get { return "idfsVSSessionSummary"; } }
        public object KeyLookup { get { return idfsVSSessionSummary; } }
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
        
                    || DiagnosisList.IsDirty
                    || DiagnosisList.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || (_Location != null && _Location.HasChanges)
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsDiagnosis_Diagnoses = idfsDiagnosis;
            var _prev_idfsVectorType_VectorType = idfsVectorType;
            var _prev_idfsVectorSubType_VectorSubType = idfsVectorSubType;
            var _prev_idfsSex_AnimalGender = idfsSex;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosis_Diagnoses != idfsDiagnosis)
            {
                _Diagnoses = _DiagnosesLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsVectorType_VectorType != idfsVectorType)
            {
                _VectorType = _VectorTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorType);
            }
            if (_prev_idfsVectorSubType_VectorSubType != idfsVectorSubType)
            {
                _VectorSubType = _VectorSubTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorSubType);
            }
            if (_prev_idfsSex_AnimalGender != idfsSex)
            {
                _AnimalGender = _AnimalGenderLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSex);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        DiagnosisList.DeepRejectChanges();
                
            if (Location != null) Location.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        DiagnosisList.DeepAcceptChanges();
                
            if (_Location != null) _Location.DeepAcceptChanges();
                
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
        DiagnosisList.ForEach(c => c.SetChange());
                
            if (_Location != null) _Location.SetChange();
                
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

        private bool IsRIRPropChanged(string fld, VsSessionSummary c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, VsSessionSummary c)
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
        

      

        public VsSessionSummary()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VsSessionSummary_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VsSessionSummary_PropertyChanged);
        }
        private void VsSessionSummary_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VsSessionSummary).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_Session);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_datStartDateFromSession);
                  
            if (e.PropertyName == _str_DiagnosisList)
                OnPropertyChanged(_str_strDiagnosesSummary);
                  
            if (e.PropertyName == _str_Location)
                OnPropertyChanged(_str_strLocation);
                  
            if (e.PropertyName == _str_idfVectorSurveillanceSession)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
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
            VsSessionSummary obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VsSessionSummary obj = this;
            
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

    
        private static string[] readonly_names1 = "strVSSessionSummaryID".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strDiagnosesSummary".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "strLocation".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VsSessionSummary, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VsSessionSummary, bool>(c => c.idfsVectorSubType == 0 || c.ReadOnly)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VsSessionSummary, bool>(c => false || c.ReadOnly)(this);
            
            return ReadOnly || new Func<VsSessionSummary, bool>(c => c.ReadOnly)(this);
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
                foreach(var o in _DiagnosisList)
                    o._isValid &= value;
                
                if (_Location != null)
                    _Location._isValid &= value;
                
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _DiagnosisList)
                    o.ReadOnly |= value;
                
                if (_Location != null)
                    _Location.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<VsSessionSummary, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VsSessionSummary, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VsSessionSummary, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VsSessionSummary, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VsSessionSummary, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<VsSessionSummary, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<VsSessionSummary, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~VsSessionSummary()
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
                
                if (_Location != null)
                    Location.Dispose();
                
                if (!bIsClone)
                {
                    DiagnosisList.ForEach(c => c.Dispose());
                }
                DiagnosisList.ClearModelListEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("VectorTypeLookup", this);
                
                LookupManager.RemoveObject("VectorSubTypeLookup", this);
                
                LookupManager.RemoveObject("rftAnimalSex", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnoses(manager, this);
            
            if (lookup_object == "VectorTypeLookup")
                _getAccessor().LoadLookup_VectorType(manager, this);
            
            if (lookup_object == "VectorSubTypeLookup")
                _getAccessor().LoadLookup_VectorSubType(manager, this);
            
            if (lookup_object == "rftAnimalSex")
                _getAccessor().LoadLookup_AnimalGender(manager, this);
            
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
        
            if (_DiagnosisList != null) _DiagnosisList.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Location != null) _Location.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
            ParsedFormCollection(form);
        }
    
        #region Class for web grid
        public class VsSessionSummaryGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfsVSSessionSummary { get; set; }
        
            public String strVSSessionSummaryID { get; set; }
        
            public string strLocation { get; set; }
        
            public DateTimeWrap datCollectionDateTime { get; set; }
        
            public Int64 idfsVectorType { get; set; }
        
            public Int64 idfsVectorSubType { get; set; }
        
            public Int64? idfsSex { get; set; }
        
            public String strVectorType { get; set; }
        
            public String strVectorSubType { get; set; }
        
            public String strSex { get; set; }
        
            public Int32? intQuantity { get; set; }
        
            public string strDiagnosesSummary { get; set; }
        
        }
        public partial class VsSessionSummaryGridModelList : List<VsSessionSummaryGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public VsSessionSummaryGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VsSessionSummary>, errMes);
            }
            public VsSessionSummaryGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VsSessionSummary>, errMes);
            }
            public VsSessionSummaryGridModelList(long key, IEnumerable<VsSessionSummary> items)
            {
                LoadGridModelList(key, items, null);
            }
            public VsSessionSummaryGridModelList(long key)
            {
                LoadGridModelList(key, new List<VsSessionSummary>(), null);
            }
            partial void filter(List<VsSessionSummary> items);
            private void LoadGridModelList(long key, IEnumerable<VsSessionSummary> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strVSSessionSummaryID,_str_strLocation,_str_datCollectionDateTime,_str_idfsVectorType,_str_idfsVectorSubType,_str_idfsSex,_str_strVectorType,_str_strVectorSubType,_str_strSex,_str_intQuantity,_str_strDiagnosesSummary};
                    
                Hiddens = new List<string> {_str_idfsVSSessionSummary};
                Keys = new List<string> {_str_idfsVSSessionSummary};
                Labels = new Dictionary<string, string> {{_str_strVSSessionSummaryID, "VsSessionSummary.RecordID"},{_str_strLocation, "LocationDisplayName"},{_str_datCollectionDateTime, _str_datCollectionDateTime},{_str_idfsVectorType, _str_idfsVectorType},{_str_idfsVectorSubType, _str_idfsVectorSubType},{_str_idfsSex, "idfsAnimalGender"},{_str_strVectorType, "idfsVectorType"},{_str_strVectorSubType, "idfsVectorSubType"},{_str_strSex, "idfsAnimalGender"},{_str_intQuantity, "VsSessionSummary.intQuantity"},{_str_strDiagnosesSummary, _str_strDiagnosesSummary}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                VsSessionSummary.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<VsSessionSummary>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VsSessionSummaryGridModel()
                {
                    ItemKey=c.idfsVSSessionSummary,strVSSessionSummaryID=c.strVSSessionSummaryID,strLocation=c.strLocation,datCollectionDateTime=c.datCollectionDateTime,idfsVectorType=c.idfsVectorType,idfsVectorSubType=c.idfsVectorSubType,idfsSex=c.idfsSex,strVectorType=c.strVectorType,strVectorSubType=c.strVectorSubType,strSex=c.strSex,intQuantity=c.intQuantity,strDiagnosesSummary=c.strDiagnosesSummary
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
        : DataAccessor<VsSessionSummary>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<VsSessionSummary>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsVSSessionSummary"; } }
            #endregion
        
            public delegate void on_action(VsSessionSummary obj);
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
            private VsSessionSummaryDiagnosis.Accessor DiagnosisListAccessor { get { return eidss.model.Schema.VsSessionSummaryDiagnosis.Accessor.Instance(m_CS); } }
            private GeoLocation.Accessor LocationAccessor { get { return eidss.model.Schema.GeoLocation.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor DiagnosesAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private VectorTypeLookup.Accessor VectorTypeAccessor { get { return eidss.model.Schema.VectorTypeLookup.Accessor.Instance(m_CS); } }
            private VectorSubTypeLookup.Accessor VectorSubTypeAccessor { get { return eidss.model.Schema.VectorSubTypeLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AnimalGenderAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<VsSessionSummary> SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                )
            {
                return _SelectList(manager
                    , idfVectorSurveillanceSession
                    , delegate(VsSessionSummary obj)
                        {
                        }
                    , delegate(VsSessionSummary obj)
                        {
                        }
                    );
            }

            

            public List<VsSessionSummary> _SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfVectorSurveillanceSession
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<VsSessionSummary> _SelectListInternal(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
                VsSessionSummary _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VsSessionSummary> objs = new List<VsSessionSummary>();
                    sets[0] = new MapResultSet(typeof(VsSessionSummary), objs);
                    
                    manager
                        .SetSpCommand("spVsSessionSummary_SelectDetail"
                            , manager.Parameter("@idfVectorSurveillanceSession", idfVectorSurveillanceSession)
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
    
            private void _SetupAddChildHandlerDiagnosisList(VsSessionSummary obj)
            {
                obj.DiagnosisList.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            internal void _LoadDiagnosisList(VsSessionSummary obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadDiagnosisList(manager, obj);
                }
            }
            internal void _LoadDiagnosisList(DbManagerProxy manager, VsSessionSummary obj)
            {
              
                obj.DiagnosisList.Clear();
                obj.DiagnosisList.AddRange(DiagnosisListAccessor.SelectDetailList(manager
                    
                    , obj.idfsVSSessionSummary
                    ));
                obj.DiagnosisList.ForEach(c => c.m_ObjectName = _str_DiagnosisList);
                obj.DiagnosisList.AcceptChanges();
                    
              }
            
            internal void _LoadLocation(VsSessionSummary obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLocation(manager, obj);
                }
            }
            internal void _LoadLocation(DbManagerProxy manager, VsSessionSummary obj)
            {
              
                if (obj.Location == null && obj.idfGeoLocation != 0)
                {
                    obj.Location = LocationAccessor.SelectByKey(manager
                        
                        , obj.idfGeoLocation
                        );
                    if (obj.Location != null)
                    {
                        obj.Location.m_ObjectName = _str_Location;
                    }
                }
                    
              }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, VsSessionSummary obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadDiagnosisList(manager, obj);
                _LoadLocation(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.Location = new Func<VsSessionSummary, GeoLocation>(c => c.Location == null ? LocationAccessor.CreateWithCountry(manager, c) : c.Location)(obj);
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerDiagnosisList(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, VsSessionSummary obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    LocationAccessor._SetPermitions(obj._permissions, obj.Location);
                    
                        obj.DiagnosisList.ForEach(c => DiagnosisListAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private VsSessionSummary _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                VsSessionSummary obj = null;
                try
                {
                    obj = VsSessionSummary.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfsVSSessionSummary = (new GetNewIDExtender<VsSessionSummary>()).GetScalar(manager, obj, isFake);
                obj.strVSSessionSummaryID = new Func<VsSessionSummary, string>(c => "(new)")(obj);
                obj.Location = new Func<VsSessionSummary, GeoLocation>(c => LocationAccessor.CreateWithCountry(manager, c))(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerDiagnosisList(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.idfVectorSurveillanceSession = new Func<VsSessionSummary, long>(c => c.Session != null ? c.Session.idfVectorSurveillanceSession : c.idfVectorSurveillanceSession)(obj);
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

            
            public VsSessionSummary CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VsSessionSummary CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public VsSessionSummary CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public VsSessionSummary CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                return Create(manager, Parent
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public VsSessionSummary Create(DbManagerProxy manager, IObject Parent
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
            
            public ActResult SummaryOk(DbManagerProxy manager, VsSessionSummary obj, List<object> pars)
            {
                
                return SummaryOk(manager, obj
                    );
            }
            public ActResult SummaryOk(DbManagerProxy manager, VsSessionSummary obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("SummaryOk"))
                    throw new PermissionException("VsSessionSummary", "SummaryOk");
                
              return (obj.GetAccessor() as IObjectValidator).Validate(manager, obj, true, true, true);
            
            }
            
      
            public ActResult SummaryCancel(DbManagerProxy manager, VsSessionSummary obj, List<object> pars)
            {
                
                return SummaryCancel(manager, obj
                    );
            }
            public ActResult SummaryCancel(DbManagerProxy manager, VsSessionSummary obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("SummaryCancel"))
                    throw new PermissionException("VsSessionSummary", "SummaryCancel");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(VsSessionSummary obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VsSessionSummary obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datStartDateFromSession)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datStartDateFromSession);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datCollectionDateTime)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datCollectionDateTime);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_intQuantity)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intQuantity);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datCollectionDateTime)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datCollectionDateTime);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                obj.strVectorType = new Func<VsSessionSummary, string>(c => c.VectorType == null ? String.Empty : c.VectorType.strTranslatedName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorSubType)
                        {
                    
                obj.strVectorSubType = new Func<VsSessionSummary, string>(c => c.VectorSubType == null ? String.Empty : c.VectorSubType.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSex)
                        {
                    
                obj.strSex = new Func<VsSessionSummary, string>(c => c.AnimalGender == null ? String.Empty : c.AnimalGender.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_VectorSubType(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                obj.VectorSubType = new Func<VsSessionSummary, VectorSubTypeLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                obj.VectorType = new Func<VsSessionSummary, VectorTypeLookup>(c => c.VectorTypeLookup.Where(x => x.idfsBaseReference == c.idfsVectorType).FirstOrDefault())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorSubType)
                        {
                    
                obj.VectorSubType = new Func<VsSessionSummary, VectorSubTypeLookup>(c => c.VectorSubTypeLookup.Where(x => x.idfsBaseReference == c.idfsVectorSubType).FirstOrDefault())(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Diagnoses(DbManagerProxy manager, VsSessionSummary obj)
            {
                
                obj.DiagnosesLookup.Clear();
                
                obj.DiagnosesLookup.Add(DiagnosesAccessor.CreateNewT(manager, null));
                
                obj.DiagnosesLookup.AddRange(DiagnosesAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Vector) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != null && obj.idfsDiagnosis != 0)
                {
                    obj.Diagnoses = obj.DiagnosesLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosesAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_VectorType(DbManagerProxy manager, VsSessionSummary obj)
            {
                
                obj.VectorTypeLookup.Clear();
                
                obj.VectorTypeLookup.Add(VectorTypeAccessor.CreateNewT(manager, null));
                
                obj.VectorTypeLookup.AddRange(VectorTypeAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorType))
                    
                    .ToList());
                
                if (obj.idfsVectorType != 0)
                {
                    obj.VectorType = obj.VectorTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsVectorType);
                    
                }
              
                LookupManager.AddObject("VectorTypeLookup", obj, VectorTypeAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_VectorSubType(DbManagerProxy manager, VsSessionSummary obj)
            {
                
                obj.VectorSubTypeLookup.Clear();
                
                obj.VectorSubTypeLookup.Add(VectorSubTypeAccessor.CreateNewT(manager, null));
                
                obj.VectorSubTypeLookup.AddRange(VectorSubTypeAccessor.SelectLookupList(manager
                    
                    , new Func<VsSessionSummary, long?>(c => c.idfsVectorType > 0 ? (long?)c.idfsVectorType : 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorSubType))
                    
                    .ToList());
                
                if (obj.idfsVectorSubType != 0)
                {
                    obj.VectorSubType = obj.VectorSubTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsVectorSubType);
                    
                }
              
                LookupManager.AddObject("VectorSubTypeLookup", obj, VectorSubTypeAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_AnimalGender(DbManagerProxy manager, VsSessionSummary obj)
            {
                
                obj.AnimalGenderLookup.Clear();
                
                obj.AnimalGenderLookup.Add(AnimalGenderAccessor.CreateNewT(manager, null));
                
                obj.AnimalGenderLookup.AddRange(AnimalGenderAccessor.rftAnimalSex_SelectList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Vector) != 0) || c.idfsBaseReference == obj.idfsSex)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSex))
                    
                    .ToList());
                
                if (obj.idfsSex != null && obj.idfsSex != 0)
                {
                    obj.AnimalGender = obj.AnimalGenderLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsSex);
                    
                }
              
                LookupManager.AddObject("rftAnimalSex", obj, AnimalGenderAccessor.GetType(), "rftAnimalSex_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, VsSessionSummary obj)
            {
                
                LoadLookup_Diagnoses(manager, obj);
                
                LoadLookup_VectorType(manager, obj);
                
                LoadLookup_VectorSubType(manager, obj);
                
                LoadLookup_AnimalGender(manager, obj);
                
            }
    
            [SprocName("spVsSessionSummary_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            [SprocName("spVsSessionSummary_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfsVSSessionSummary", "strVSSessionSummaryID")] VsSessionSummary obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfsVSSessionSummary", "strVSSessionSummaryID")] VsSessionSummary obj)
            {
                
                _post(manager, Action, obj);
                
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
                        VsSessionSummary bo = obj as VsSessionSummary;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            if (!CanDelete)
                                throw new PermissionException("VsSessionSummary", "Delete");
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            if (!CanInsert)
                                throw new PermissionException("VsSessionSummary", "Insert");
                        }
                        else if (!bo.IsMarkedToDelete && bo.HasChanges) // update
                        {
                            if (!CanUpdate)
                                throw new PermissionException("VsSessionSummary", "Update");
                        }
                        
                        long mainObject = bo.idfsVSSessionSummary;
                        
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
                            eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbVectorSurveillanceSessionSummary;
                            manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as VsSessionSummary, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VsSessionSummary obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.DiagnosisList != null)
                    {
                        foreach (var i in obj.DiagnosisList)
                        {
                            i.MarkToDelete();
                            if (!DiagnosisListAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    
                    if (!ValidateCanDelete(manager, obj)) return false;
                                
                    _postPredicate(manager, 8, obj);
                                    
                    if (obj.Location != null)
                    {
                        obj.Location.MarkToDelete();
                        if (!LocationAccessor.Post(manager, obj.Location, true))
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
                        if (obj.Location != null) // forced load potential lazy subobject for new object
                            if (!LocationAccessor.Post(manager, obj.Location, true))
                                return false;
                    }
                    else
                    {
                        if (obj._Location != null) // do not load lazy subobject for existing object
                            if (!LocationAccessor.Post(manager, obj.Location, true))
                                return false;
                    }
                                    
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                                    
                    if (obj.IsNew)
                    {
                        if (obj.DiagnosisList != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.DiagnosisList)
                                if (!DiagnosisListAccessor.Post(manager, i, true))
                                    return false;
                            obj.DiagnosisList.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.DiagnosisList.Remove(c));
                            obj.DiagnosisList.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._DiagnosisList != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._DiagnosisList)
                                if (!DiagnosisListAccessor.Post(manager, i, true))
                                    return false;
                            obj._DiagnosisList.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._DiagnosisList.Remove(c));
                            obj._DiagnosisList.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(VsSessionSummary obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VsSessionSummary obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(VsSessionSummary obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<VsSessionSummary>(obj, "datStartDateFromSession", c => true, 
      obj.datStartDateFromSession,
      obj.GetType(),
      false, listdatStartDateFromSession => {
    listdatStartDateFromSession.Add(
    new ChainsValidatorDateTime<VsSessionSummary>(obj, "datCollectionDateTime", c => true, 
      obj.datCollectionDateTime,
      obj.GetType(),
      false, listdatCollectionDateTime => {
    
    }));
  
    }).Process();
  
    new ChainsValidatorNullableInt<VsSessionSummary>(obj, "MinValue", c => true, 
      1,
      null,
      false, listMinValue => {
    listMinValue.Add(
    new ChainsValidatorNullableInt<VsSessionSummary>(obj, "intQuantity", c => true, 
      obj.intQuantity,
      obj.GetType(),
      false, listintQuantity => {
    
    }));
  
    }).Process();
  
    new ChainsValidatorDateTime<VsSessionSummary>(obj, "datCollectionDateTime", c => true, 
      obj.datCollectionDateTime,
      obj.GetType(),
      false, listdatCollectionDateTime => {
    listdatCollectionDateTime.Add(
    new ChainsValidatorDateTime<VsSessionSummary>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }).Process();
  
                }
                catch(ValidationModelException ex)
                {
                    return ex;
                }
                
                return null;
            }
            protected bool ChainsValidate(VsSessionSummary obj, bool bRethrowException)
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
                return Validate(manager, obj as VsSessionSummary, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VsSessionSummary obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsVSSessionSummary", "idfsVSSessionSummary","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsVSSessionSummary);
            
                (new RequiredValidator( "idfVectorSurveillanceSession", "idfVectorSurveillanceSession","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfVectorSurveillanceSession);
            
                (new RequiredValidator( "strVSSessionSummaryID", "strVSSessionSummaryID","VsSessionSummary.RecordID",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.strVSSessionSummaryID);
            
                (new RequiredValidator( "Location.LocationDisplayName", "Location.LocationDisplayName","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.Location.LocationDisplayName);
            
                (new RequiredValidator( "Location.strReadOnlyAdaptiveFullName", "Location.strReadOnlyAdaptiveFullName","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.Location.strReadOnlyAdaptiveFullName);
            
                (new RequiredValidator( "idfsVectorType", "idfsVectorType","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsVectorType);
            
                (new RequiredValidator( "idfsVectorSubType", "idfsVectorSubType","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsVectorSubType);
            
                (new RequiredValidator( "VectorType", "VectorType","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.VectorType);
            
                (new RequiredValidator( "VectorSubType", "VectorSubType","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.VectorSubType);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Location != null)
                            LocationAccessor.Validate(manager, obj.Location, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.DiagnosisList != null)
                            foreach (var i in obj.DiagnosisList.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                DiagnosisListAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(VsSessionSummary obj)
            {
            
                obj
                    .AddRequired("idfsVSSessionSummary", c => true);
                    
                obj
                    .AddRequired("idfVectorSurveillanceSession", c => true);
                    
                obj
                    .AddRequired("strVSSessionSummaryID", c => true);
                    
                obj
                    .Location
                        .AddRequired("LocationDisplayName", c => true);
                        
                obj
                    .Location
                        .AddRequired("strReadOnlyAdaptiveFullName", c => true);
                        
                obj
                    .AddRequired("idfsVectorType", c => true);
                    
                  obj
                    .AddRequired("VectorType", c => true);
                
                obj
                    .AddRequired("idfsVectorSubType", c => true);
                    
                  obj
                    .AddRequired("VectorSubType", c => true);
                
                obj
                    .AddRequired("VectorType", c => true);
                    
                obj
                    .AddRequired("VectorSubType", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(VsSessionSummary obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VsSessionSummary) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VsSessionSummary) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VsSessionSummaryDetail"; } }
            public string HelpIdWin { get { return "vss_form"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private VsSessionSummary m_obj;
            internal Permissions(VsSessionSummary obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSessionSummary.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spVsSessionSummary_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spVsSessionSummary_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spVsSessionSummary_Delete";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VsSessionSummary, bool>> RequiredByField = new Dictionary<string, Func<VsSessionSummary, bool>>();
            public static Dictionary<string, Func<VsSessionSummary, bool>> RequiredByProperty = new Dictionary<string, Func<VsSessionSummary, bool>>();
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
                
                Sizes.Add(_str_strVSSessionSummaryID, 200);
                Sizes.Add(_str_strVectorType, 2000);
                Sizes.Add(_str_strVectorSubType, 2000);
                Sizes.Add(_str_strSex, 2000);
                if (!RequiredByField.ContainsKey("idfsVSSessionSummary")) RequiredByField.Add("idfsVSSessionSummary", c => true);
                if (!RequiredByProperty.ContainsKey("idfsVSSessionSummary")) RequiredByProperty.Add("idfsVSSessionSummary", c => true);
                
                if (!RequiredByField.ContainsKey("idfVectorSurveillanceSession")) RequiredByField.Add("idfVectorSurveillanceSession", c => true);
                if (!RequiredByProperty.ContainsKey("idfVectorSurveillanceSession")) RequiredByProperty.Add("idfVectorSurveillanceSession", c => true);
                
                if (!RequiredByField.ContainsKey("strVSSessionSummaryID")) RequiredByField.Add("strVSSessionSummaryID", c => true);
                if (!RequiredByProperty.ContainsKey("strVSSessionSummaryID")) RequiredByProperty.Add("strVSSessionSummaryID", c => true);
                
                if (!RequiredByField.ContainsKey("Location.LocationDisplayName")) RequiredByField.Add("Location.LocationDisplayName", c => true);
                if (!RequiredByProperty.ContainsKey("Location.LocationDisplayName")) RequiredByProperty.Add("Location.LocationDisplayName", c => true);
                
                if (!RequiredByField.ContainsKey("Location.strReadOnlyAdaptiveFullName")) RequiredByField.Add("Location.strReadOnlyAdaptiveFullName", c => true);
                if (!RequiredByProperty.ContainsKey("Location.strReadOnlyAdaptiveFullName")) RequiredByProperty.Add("Location.strReadOnlyAdaptiveFullName", c => true);
                
                if (!RequiredByField.ContainsKey("idfsVectorType")) RequiredByField.Add("idfsVectorType", c => true);
                if (!RequiredByProperty.ContainsKey("idfsVectorType")) RequiredByProperty.Add("idfsVectorType", c => true);
                
                if (!RequiredByField.ContainsKey("idfsVectorSubType")) RequiredByField.Add("idfsVectorSubType", c => true);
                if (!RequiredByProperty.ContainsKey("idfsVectorSubType")) RequiredByProperty.Add("idfsVectorSubType", c => true);
                
                if (!RequiredByField.ContainsKey("VectorType")) RequiredByField.Add("VectorType", c => true);
                if (!RequiredByProperty.ContainsKey("VectorType")) RequiredByProperty.Add("VectorType", c => true);
                
                if (!RequiredByField.ContainsKey("VectorSubType")) RequiredByField.Add("VectorSubType", c => true);
                if (!RequiredByProperty.ContainsKey("VectorSubType")) RequiredByProperty.Add("VectorSubType", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfsVSSessionSummary,
                    _str_idfsVSSessionSummary, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVSSessionSummaryID,
                    "VsSessionSummary.RecordID", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strLocation,
                    "LocationDisplayName", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datCollectionDateTime,
                    _str_datCollectionDateTime, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsVectorType,
                    _str_idfsVectorType, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsVectorSubType,
                    _str_idfsVectorSubType, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsSex,
                    "idfsAnimalGender", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorType,
                    "idfsVectorType", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorSubType,
                    "idfsVectorSubType", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSex,
                    "idfsAnimalGender", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intQuantity,
                    "VsSessionSummary.intQuantity", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosesSummary,
                    _str_strDiagnosesSummary, null, true, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).Create(manager, c, pars)),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c, a, b, p) => false,
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
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c, a, b, p) => false,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "SummaryOk",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).SummaryOk(manager, (VsSessionSummary)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.Web
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    true,
                    false,
                    "vssessionsummary.formDetailOk",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "SummaryCancel",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).SummaryCancel(manager, (VsSessionSummary)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.Web
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    "vssessionsummary.formDetailCancel",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => ((VsSessionSummary)c).MarkToDelete(),
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
	