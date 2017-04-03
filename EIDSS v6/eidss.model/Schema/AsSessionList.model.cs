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
    public abstract partial class AsSessionListItem : 
        EditableObject<AsSessionListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfMonitoringSession), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMonitoringSession { get; set; }
                
        [LocalizedDisplayName(_str_strStatus)]
        [MapField(_str_strStatus)]
        public abstract String strStatus { get; set; }
        protected String strStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._strStatus).OriginalValue; } }
        protected String strStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._strStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsMonitoringSessionStatus)]
        [MapField(_str_idfsMonitoringSessionStatus)]
        public abstract Int64? idfsMonitoringSessionStatus { get; set; }
        protected Int64? idfsMonitoringSessionStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMonitoringSessionStatus).OriginalValue; } }
        protected Int64? idfsMonitoringSessionStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMonitoringSessionStatus).PreviousValue; } }
                
        [LocalizedDisplayName("idfsRegion")]
        [MapField(_str_strRegion)]
        public abstract String strRegion { get; set; }
        protected String strRegion_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegion).OriginalValue; } }
        protected String strRegion_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRegion)]
        [MapField(_str_idfsRegion)]
        public abstract Int64? idfsRegion { get; set; }
        protected Int64? idfsRegion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).OriginalValue; } }
        protected Int64? idfsRegion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).PreviousValue; } }
                
        [LocalizedDisplayName("idfsRayon")]
        [MapField(_str_strRayon)]
        public abstract String strRayon { get; set; }
        protected String strRayon_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayon).OriginalValue; } }
        protected String strRayon_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayon).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRayon)]
        [MapField(_str_idfsRayon)]
        public abstract Int64? idfsRayon { get; set; }
        protected Int64? idfsRayon_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).OriginalValue; } }
        protected Int64? idfsRayon_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).PreviousValue; } }
                
        [LocalizedDisplayName("AsSession.strSettlement")]
        [MapField(_str_strSettlement)]
        public abstract String strSettlement { get; set; }
        protected String strSettlement_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).OriginalValue; } }
        protected String strSettlement_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSettlement)]
        [MapField(_str_idfsSettlement)]
        public abstract Int64? idfsSettlement { get; set; }
        protected Int64? idfsSettlement_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).OriginalValue; } }
        protected Int64? idfsSettlement_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datEnteredDate)]
        [MapField(_str_datEnteredDate)]
        public abstract DateTime? datEnteredDate { get; set; }
        protected DateTime? datEnteredDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).OriginalValue; } }
        protected DateTime? datEnteredDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPersonEnteredBy)]
        [MapField(_str_idfPersonEnteredBy)]
        public abstract Int64? idfPersonEnteredBy { get; set; }
        protected Int64? idfPersonEnteredBy_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonEnteredBy).OriginalValue; } }
        protected Int64? idfPersonEnteredBy_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonEnteredBy).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strMonitoringSessionID)]
        [MapField(_str_strMonitoringSessionID)]
        public abstract String strMonitoringSessionID { get; set; }
        protected String strMonitoringSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).OriginalValue; } }
        protected String strMonitoringSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDisease)]
        [MapField(_str_strDisease)]
        public abstract Int32? strDisease { get; set; }
        protected Int32? strDisease_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._strDisease).OriginalValue; } }
        protected Int32? strDisease_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._strDisease).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCampaignID)]
        [MapField(_str_strCampaignID)]
        public abstract String strCampaignID { get; set; }
        protected String strCampaignID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCampaignID).OriginalValue; } }
        protected String strCampaignID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCampaignID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCampaignName)]
        [MapField(_str_strCampaignName)]
        public abstract String strCampaignName { get; set; }
        protected String strCampaignName_Original { get { return ((EditableValue<String>)((dynamic)this)._strCampaignName).OriginalValue; } }
        protected String strCampaignName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCampaignName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datCampaignDateStart)]
        [MapField(_str_datCampaignDateStart)]
        public abstract DateTime? datCampaignDateStart { get; set; }
        protected DateTime? datCampaignDateStart_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateStart).OriginalValue; } }
        protected DateTime? datCampaignDateStart_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateStart).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datCampaignDateEnd)]
        [MapField(_str_datCampaignDateEnd)]
        public abstract DateTime? datCampaignDateEnd { get; set; }
        protected DateTime? datCampaignDateEnd_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateEnd).OriginalValue; } }
        protected DateTime? datCampaignDateEnd_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateEnd).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCampaignType)]
        [MapField(_str_idfsCampaignType)]
        public abstract Int64? idfsCampaignType { get; set; }
        protected Int64? idfsCampaignType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCampaignType).OriginalValue; } }
        protected Int64? idfsCampaignType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCampaignType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStartDate)]
        [MapField(_str_datStartDate)]
        public abstract DateTime? datStartDate { get; set; }
        protected DateTime? datStartDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime? datStartDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datEndDate)]
        [MapField(_str_datEndDate)]
        public abstract DateTime? datEndDate { get; set; }
        protected DateTime? datEndDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEndDate).OriginalValue; } }
        protected DateTime? datEndDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEndDate).PreviousValue; } }
                
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
            internal Func<AsSessionListItem, object> _get_func;
            internal Action<AsSessionListItem, string> _set_func;
            internal Action<AsSessionListItem, AsSessionListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_strStatus = "strStatus";
        internal const string _str_idfsMonitoringSessionStatus = "idfsMonitoringSessionStatus";
        internal const string _str_strRegion = "strRegion";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_strRayon = "strRayon";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_strSettlement = "strSettlement";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_datEnteredDate = "datEnteredDate";
        internal const string _str_idfPersonEnteredBy = "idfPersonEnteredBy";
        internal const string _str_strMonitoringSessionID = "strMonitoringSessionID";
        internal const string _str_strDisease = "strDisease";
        internal const string _str_strCampaignID = "strCampaignID";
        internal const string _str_strCampaignName = "strCampaignName";
        internal const string _str_datCampaignDateStart = "datCampaignDateStart";
        internal const string _str_datCampaignDateEnd = "datCampaignDateEnd";
        internal const string _str_idfsCampaignType = "idfsCampaignType";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_datEndDate = "datEndDate";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_AsSessionStatus = "AsSessionStatus";
        internal const string _str_AsCampaignType = "AsCampaignType";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_PersonEnteredBy = "PersonEnteredBy";
        internal const string _str_Site = "Site";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfMonitoringSession, _formname = _str_idfMonitoringSession, _type = "Int64",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfMonitoringSession != newval) o.idfMonitoringSession = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, o.ObjectIdent2 + _str_idfMonitoringSession, o.ObjectIdent3 + _str_idfMonitoringSession, "Int64", 
                    o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(),                  
                  o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strStatus, _formname = _str_strStatus, _type = "String",
              _get_func = o => o.strStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strStatus != newval) o.strStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.strStatus != c.strStatus || o.IsRIRPropChanged(_str_strStatus, c)) 
                  m.Add(_str_strStatus, o.ObjectIdent + _str_strStatus, o.ObjectIdent2 + _str_strStatus, o.ObjectIdent3 + _str_strStatus, "String", 
                    o.strStatus == null ? "" : o.strStatus.ToString(),                  
                  o.IsReadOnly(_str_strStatus), o.IsInvisible(_str_strStatus), o.IsRequired(_str_strStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsMonitoringSessionStatus, _formname = _str_idfsMonitoringSessionStatus, _type = "Int64?",
              _get_func = o => o.idfsMonitoringSessionStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsMonitoringSessionStatus != newval) 
                  o.AsSessionStatus = o.AsSessionStatusLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsMonitoringSessionStatus != newval) o.idfsMonitoringSessionStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsMonitoringSessionStatus != c.idfsMonitoringSessionStatus || o.IsRIRPropChanged(_str_idfsMonitoringSessionStatus, c)) 
                  m.Add(_str_idfsMonitoringSessionStatus, o.ObjectIdent + _str_idfsMonitoringSessionStatus, o.ObjectIdent2 + _str_idfsMonitoringSessionStatus, o.ObjectIdent3 + _str_idfsMonitoringSessionStatus, "Int64?", 
                    o.idfsMonitoringSessionStatus == null ? "" : o.idfsMonitoringSessionStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsMonitoringSessionStatus), o.IsInvisible(_str_idfsMonitoringSessionStatus), o.IsRequired(_str_idfsMonitoringSessionStatus)); 
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
              _name = _str_idfPersonEnteredBy, _formname = _str_idfPersonEnteredBy, _type = "Int64?",
              _get_func = o => o.idfPersonEnteredBy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfPersonEnteredBy != newval) 
                  o.PersonEnteredBy = o.PersonEnteredByLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfPersonEnteredBy != newval) o.idfPersonEnteredBy = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfPersonEnteredBy != c.idfPersonEnteredBy || o.IsRIRPropChanged(_str_idfPersonEnteredBy, c)) 
                  m.Add(_str_idfPersonEnteredBy, o.ObjectIdent + _str_idfPersonEnteredBy, o.ObjectIdent2 + _str_idfPersonEnteredBy, o.ObjectIdent3 + _str_idfPersonEnteredBy, "Int64?", 
                    o.idfPersonEnteredBy == null ? "" : o.idfPersonEnteredBy.ToString(),                  
                  o.IsReadOnly(_str_idfPersonEnteredBy), o.IsInvisible(_str_idfPersonEnteredBy), o.IsRequired(_str_idfPersonEnteredBy)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strMonitoringSessionID, _formname = _str_strMonitoringSessionID, _type = "String",
              _get_func = o => o.strMonitoringSessionID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strMonitoringSessionID != newval) o.strMonitoringSessionID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strMonitoringSessionID != c.strMonitoringSessionID || o.IsRIRPropChanged(_str_strMonitoringSessionID, c)) 
                  m.Add(_str_strMonitoringSessionID, o.ObjectIdent + _str_strMonitoringSessionID, o.ObjectIdent2 + _str_strMonitoringSessionID, o.ObjectIdent3 + _str_strMonitoringSessionID, "String", 
                    o.strMonitoringSessionID == null ? "" : o.strMonitoringSessionID.ToString(),                  
                  o.IsReadOnly(_str_strMonitoringSessionID), o.IsInvisible(_str_strMonitoringSessionID), o.IsRequired(_str_strMonitoringSessionID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDisease, _formname = _str_strDisease, _type = "Int32?",
              _get_func = o => o.strDisease,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.strDisease != newval) o.strDisease = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDisease != c.strDisease || o.IsRIRPropChanged(_str_strDisease, c)) 
                  m.Add(_str_strDisease, o.ObjectIdent + _str_strDisease, o.ObjectIdent2 + _str_strDisease, o.ObjectIdent3 + _str_strDisease, "Int32?", 
                    o.strDisease == null ? "" : o.strDisease.ToString(),                  
                  o.IsReadOnly(_str_strDisease), o.IsInvisible(_str_strDisease), o.IsRequired(_str_strDisease)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCampaignID, _formname = _str_strCampaignID, _type = "String",
              _get_func = o => o.strCampaignID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCampaignID != newval) o.strCampaignID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strCampaignID != c.strCampaignID || o.IsRIRPropChanged(_str_strCampaignID, c)) 
                  m.Add(_str_strCampaignID, o.ObjectIdent + _str_strCampaignID, o.ObjectIdent2 + _str_strCampaignID, o.ObjectIdent3 + _str_strCampaignID, "String", 
                    o.strCampaignID == null ? "" : o.strCampaignID.ToString(),                  
                  o.IsReadOnly(_str_strCampaignID), o.IsInvisible(_str_strCampaignID), o.IsRequired(_str_strCampaignID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCampaignName, _formname = _str_strCampaignName, _type = "String",
              _get_func = o => o.strCampaignName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCampaignName != newval) o.strCampaignName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strCampaignName != c.strCampaignName || o.IsRIRPropChanged(_str_strCampaignName, c)) 
                  m.Add(_str_strCampaignName, o.ObjectIdent + _str_strCampaignName, o.ObjectIdent2 + _str_strCampaignName, o.ObjectIdent3 + _str_strCampaignName, "String", 
                    o.strCampaignName == null ? "" : o.strCampaignName.ToString(),                  
                  o.IsReadOnly(_str_strCampaignName), o.IsInvisible(_str_strCampaignName), o.IsRequired(_str_strCampaignName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datCampaignDateStart, _formname = _str_datCampaignDateStart, _type = "DateTime?",
              _get_func = o => o.datCampaignDateStart,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datCampaignDateStart != newval) o.datCampaignDateStart = newval; },
              _compare_func = (o, c, m) => {
                if (o.datCampaignDateStart != c.datCampaignDateStart || o.IsRIRPropChanged(_str_datCampaignDateStart, c)) 
                  m.Add(_str_datCampaignDateStart, o.ObjectIdent + _str_datCampaignDateStart, o.ObjectIdent2 + _str_datCampaignDateStart, o.ObjectIdent3 + _str_datCampaignDateStart, "DateTime?", 
                    o.datCampaignDateStart == null ? "" : o.datCampaignDateStart.ToString(),                  
                  o.IsReadOnly(_str_datCampaignDateStart), o.IsInvisible(_str_datCampaignDateStart), o.IsRequired(_str_datCampaignDateStart)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datCampaignDateEnd, _formname = _str_datCampaignDateEnd, _type = "DateTime?",
              _get_func = o => o.datCampaignDateEnd,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datCampaignDateEnd != newval) o.datCampaignDateEnd = newval; },
              _compare_func = (o, c, m) => {
                if (o.datCampaignDateEnd != c.datCampaignDateEnd || o.IsRIRPropChanged(_str_datCampaignDateEnd, c)) 
                  m.Add(_str_datCampaignDateEnd, o.ObjectIdent + _str_datCampaignDateEnd, o.ObjectIdent2 + _str_datCampaignDateEnd, o.ObjectIdent3 + _str_datCampaignDateEnd, "DateTime?", 
                    o.datCampaignDateEnd == null ? "" : o.datCampaignDateEnd.ToString(),                  
                  o.IsReadOnly(_str_datCampaignDateEnd), o.IsInvisible(_str_datCampaignDateEnd), o.IsRequired(_str_datCampaignDateEnd)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCampaignType, _formname = _str_idfsCampaignType, _type = "Int64?",
              _get_func = o => o.idfsCampaignType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsCampaignType != newval) 
                  o.AsCampaignType = o.AsCampaignTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsCampaignType != newval) o.idfsCampaignType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCampaignType != c.idfsCampaignType || o.IsRIRPropChanged(_str_idfsCampaignType, c)) 
                  m.Add(_str_idfsCampaignType, o.ObjectIdent + _str_idfsCampaignType, o.ObjectIdent2 + _str_idfsCampaignType, o.ObjectIdent3 + _str_idfsCampaignType, "Int64?", 
                    o.idfsCampaignType == null ? "" : o.idfsCampaignType.ToString(),                  
                  o.IsReadOnly(_str_idfsCampaignType), o.IsInvisible(_str_idfsCampaignType), o.IsRequired(_str_idfsCampaignType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datStartDate, _formname = _str_datStartDate, _type = "DateTime?",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datStartDate != newval) o.datStartDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, o.ObjectIdent2 + _str_datStartDate, o.ObjectIdent3 + _str_datStartDate, "DateTime?", 
                    o.datStartDate == null ? "" : o.datStartDate.ToString(),                  
                  o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datEndDate, _formname = _str_datEndDate, _type = "DateTime?",
              _get_func = o => o.datEndDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datEndDate != newval) o.datEndDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datEndDate != c.datEndDate || o.IsRIRPropChanged(_str_datEndDate, c)) 
                  m.Add(_str_datEndDate, o.ObjectIdent + _str_datEndDate, o.ObjectIdent2 + _str_datEndDate, o.ObjectIdent3 + _str_datEndDate, "DateTime?", 
                    o.datEndDate == null ? "" : o.datEndDate.ToString(),                  
                  o.IsReadOnly(_str_datEndDate), o.IsInvisible(_str_datEndDate), o.IsRequired(_str_datEndDate)); 
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
              _name = _str_AsSessionStatus, _formname = _str_AsSessionStatus, _type = "Lookup",
              _get_func = o => { if (o.AsSessionStatus == null) return null; return o.AsSessionStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.AsSessionStatus = o.AsSessionStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsMonitoringSessionStatus != c.idfsMonitoringSessionStatus || o.IsRIRPropChanged(_str_AsSessionStatus, c)) {
                  m.Add(_str_AsSessionStatus, o.ObjectIdent + _str_AsSessionStatus, o.ObjectIdent2 + _str_AsSessionStatus, o.ObjectIdent3 + _str_AsSessionStatus, "Lookup", o.idfsMonitoringSessionStatus == null ? "" : o.idfsMonitoringSessionStatus.ToString(), o.IsReadOnly(_str_AsSessionStatus), o.IsInvisible(_str_AsSessionStatus), o.IsRequired(_str_AsSessionStatus)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_AsSessionStatus + "Lookup", _formname = _str_AsSessionStatus + "Lookup", _type = "LookupContent",
              _get_func = o => o.AsSessionStatusLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_AsCampaignType, _formname = _str_AsCampaignType, _type = "Lookup",
              _get_func = o => { if (o.AsCampaignType == null) return null; return o.AsCampaignType.idfsBaseReference; },
              _set_func = (o, val) => { o.AsCampaignType = o.AsCampaignTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCampaignType != c.idfsCampaignType || o.IsRIRPropChanged(_str_AsCampaignType, c)) {
                  m.Add(_str_AsCampaignType, o.ObjectIdent + _str_AsCampaignType, o.ObjectIdent2 + _str_AsCampaignType, o.ObjectIdent3 + _str_AsCampaignType, "Lookup", o.idfsCampaignType == null ? "" : o.idfsCampaignType.ToString(), o.IsReadOnly(_str_AsCampaignType), o.IsInvisible(_str_AsCampaignType), o.IsRequired(_str_AsCampaignType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_AsCampaignType + "Lookup", _formname = _str_AsCampaignType + "Lookup", _type = "LookupContent",
              _get_func = o => o.AsCampaignTypeLookup,
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
              _name = _str_PersonEnteredBy, _formname = _str_PersonEnteredBy, _type = "Lookup",
              _get_func = o => { if (o.PersonEnteredBy == null) return null; return o.PersonEnteredBy.idfPerson; },
              _set_func = (o, val) => { o.PersonEnteredBy = o.PersonEnteredByLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfPersonEnteredBy != c.idfPersonEnteredBy || o.IsRIRPropChanged(_str_PersonEnteredBy, c)) {
                  m.Add(_str_PersonEnteredBy, o.ObjectIdent + _str_PersonEnteredBy, o.ObjectIdent2 + _str_PersonEnteredBy, o.ObjectIdent3 + _str_PersonEnteredBy, "Lookup", o.idfPersonEnteredBy == null ? "" : o.idfPersonEnteredBy.ToString(), o.IsReadOnly(_str_PersonEnteredBy), o.IsInvisible(_str_PersonEnteredBy), o.IsRequired(_str_PersonEnteredBy)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_PersonEnteredBy + "Lookup", _formname = _str_PersonEnteredBy + "Lookup", _type = "LookupContent",
              _get_func = o => o.PersonEnteredByLookup,
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
            AsSessionListItem obj = (AsSessionListItem)o;
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
            
        [LocalizedDisplayName(_str_AsSessionStatus)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsMonitoringSessionStatus)]
        public BaseReference AsSessionStatus
        {
            get { return _AsSessionStatus == null ? null : ((long)_AsSessionStatus.Key == 0 ? null : _AsSessionStatus); }
            set 
            { 
                var oldVal = _AsSessionStatus;
                _AsSessionStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AsSessionStatus != oldVal)
                {
                    if (idfsMonitoringSessionStatus != (_AsSessionStatus == null
                            ? new Int64?()
                            : (Int64?)_AsSessionStatus.idfsBaseReference))
                        idfsMonitoringSessionStatus = _AsSessionStatus == null 
                            ? new Int64?()
                            : (Int64?)_AsSessionStatus.idfsBaseReference; 
                    OnPropertyChanged(_str_AsSessionStatus); 
                }
            }
        }
        private BaseReference _AsSessionStatus;

        
        public BaseReferenceList AsSessionStatusLookup
        {
            get { return _AsSessionStatusLookup; }
        }
        private BaseReferenceList _AsSessionStatusLookup = new BaseReferenceList("rftMonitoringSessionStatus");
            
        [LocalizedDisplayName(_str_AsCampaignType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCampaignType)]
        public BaseReference AsCampaignType
        {
            get { return _AsCampaignType == null ? null : ((long)_AsCampaignType.Key == 0 ? null : _AsCampaignType); }
            set 
            { 
                var oldVal = _AsCampaignType;
                _AsCampaignType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AsCampaignType != oldVal)
                {
                    if (idfsCampaignType != (_AsCampaignType == null
                            ? new Int64?()
                            : (Int64?)_AsCampaignType.idfsBaseReference))
                        idfsCampaignType = _AsCampaignType == null 
                            ? new Int64?()
                            : (Int64?)_AsCampaignType.idfsBaseReference; 
                    OnPropertyChanged(_str_AsCampaignType); 
                }
            }
        }
        private BaseReference _AsCampaignType;

        
        public BaseReferenceList AsCampaignTypeLookup
        {
            get { return _AsCampaignTypeLookup; }
        }
        private BaseReferenceList _AsCampaignTypeLookup = new BaseReferenceList("rftCampaignType");
            
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
            
        [LocalizedDisplayName(_str_PersonEnteredBy)]
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfPersonEnteredBy)]
        public PersonLookup PersonEnteredBy
        {
            get { return _PersonEnteredBy == null ? null : ((long)_PersonEnteredBy.Key == 0 ? null : _PersonEnteredBy); }
            set 
            { 
                var oldVal = _PersonEnteredBy;
                _PersonEnteredBy = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_PersonEnteredBy != oldVal)
                {
                    if (idfPersonEnteredBy != (_PersonEnteredBy == null
                            ? new Int64?()
                            : (Int64?)_PersonEnteredBy.idfPerson))
                        idfPersonEnteredBy = _PersonEnteredBy == null 
                            ? new Int64?()
                            : (Int64?)_PersonEnteredBy.idfPerson; 
                    OnPropertyChanged(_str_PersonEnteredBy); 
                }
            }
        }
        private PersonLookup _PersonEnteredBy;

        
        public List<PersonLookup> PersonEnteredByLookup
        {
            get { return _PersonEnteredByLookup; }
        }
        private List<PersonLookup> _PersonEnteredByLookup = new List<PersonLookup>();
            
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
            
                case _str_Country:
                    return new BvSelectList(CountryLookup, eidss.model.Schema.CountryLookup._str_idfsCountry, null, Country, _str_idfsCountry);
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionLookup._str_idfsRegion, null, Region, _str_idfsRegion);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonLookup._str_idfsRayon, null, Rayon, _str_idfsRayon);
            
                case _str_Settlement:
                    return new BvSelectList(SettlementLookup, eidss.model.Schema.SettlementLookup._str_idfsSettlement, null, Settlement, _str_idfsSettlement);
            
                case _str_AsSessionStatus:
                    return new BvSelectList(AsSessionStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AsSessionStatus, _str_idfsMonitoringSessionStatus);
            
                case _str_AsCampaignType:
                    return new BvSelectList(AsCampaignTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AsCampaignType, _str_idfsCampaignType);
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_PersonEnteredBy:
                    return new BvSelectList(PersonEnteredByLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, PersonEnteredBy, _str_idfPersonEnteredBy);
            
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
        
          [LocalizedDisplayName(_str_idfsCountry)]
        public long? idfsCountry
        {
            get { return m_idfsCountry; }
            set { if (m_idfsCountry != value) { m_idfsCountry = value; OnPropertyChanged(_str_idfsCountry); } }
        }
        private long? m_idfsCountry;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AsSessionListItem";

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
            var ret = base.Clone() as AsSessionListItem;
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
            var ret = base.Clone() as AsSessionListItem;
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
        public AsSessionListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsSessionListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfMonitoringSession; } }
        public string KeyName { get { return "idfMonitoringSession"; } }
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
            var _prev_idfsMonitoringSessionStatus_AsSessionStatus = idfsMonitoringSessionStatus;
            var _prev_idfsCampaignType_AsCampaignType = idfsCampaignType;
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfPersonEnteredBy_PersonEnteredBy = idfPersonEnteredBy;
            var _prev_idfsSite_Site = idfsSite;
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
            if (_prev_idfsMonitoringSessionStatus_AsSessionStatus != idfsMonitoringSessionStatus)
            {
                _AsSessionStatus = _AsSessionStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsMonitoringSessionStatus);
            }
            if (_prev_idfsCampaignType_AsCampaignType != idfsCampaignType)
            {
                _AsCampaignType = _AsCampaignTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCampaignType);
            }
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfPersonEnteredBy_PersonEnteredBy != idfPersonEnteredBy)
            {
                _PersonEnteredBy = _PersonEnteredByLookup.FirstOrDefault(c => c.idfPerson == idfPersonEnteredBy);
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

        private bool IsRIRPropChanged(string fld, AsSessionListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public AsSessionListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsSessionListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsSessionListItem_PropertyChanged);
        }
        private void AsSessionListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsSessionListItem).Changed(e.PropertyName);
            
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
            AsSessionListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsSessionListItem obj = this;
            
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


        internal Dictionary<string, Func<AsSessionListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AsSessionListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsSessionListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsSessionListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AsSessionListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsSessionListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<AsSessionListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AsSessionListItem()
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
                
                LookupManager.RemoveObject("rftMonitoringSessionStatus", this);
                
                LookupManager.RemoveObject("rftCampaignType", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("SiteLookup", this);
                
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
            
            if (lookup_object == "rftMonitoringSessionStatus")
                _getAccessor().LoadLookup_AsSessionStatus(manager, this);
            
            if (lookup_object == "rftCampaignType")
                _getAccessor().LoadLookup_AsCampaignType(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_PersonEnteredBy(manager, this);
            
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
        public class AsSessionListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfMonitoringSession { get; set; }
        
            public String strMonitoringSessionID { get; set; }
        
            public DateTime? datStartDate { get; set; }
        
            public DateTime? datEndDate { get; set; }
        
            public String strRegion { get; set; }
        
            public String strRayon { get; set; }
        
            public String strSettlement { get; set; }
        
            public String strCampaignID { get; set; }
        
            public String strCampaignName { get; set; }
        
        }
        public partial class AsSessionListItemGridModelList : List<AsSessionListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public AsSessionListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionListItem>, errMes);
            }
            public AsSessionListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionListItem>, errMes);
            }
            public AsSessionListItemGridModelList(long key, IEnumerable<AsSessionListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public AsSessionListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<AsSessionListItem>(), null);
            }
            partial void filter(List<AsSessionListItem> items);
            private void LoadGridModelList(long key, IEnumerable<AsSessionListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strMonitoringSessionID,_str_datStartDate,_str_datEndDate,_str_strRegion,_str_strRayon,_str_strSettlement,_str_strCampaignID,_str_strCampaignName};
                    
                Hiddens = new List<string> {_str_idfMonitoringSession};
                Keys = new List<string> {_str_idfMonitoringSession};
                Labels = new Dictionary<string, string> {{_str_strMonitoringSessionID, _str_strMonitoringSessionID},{_str_datStartDate, _str_datStartDate},{_str_datEndDate, _str_datEndDate},{_str_strRegion, "idfsRegion"},{_str_strRayon, "idfsRayon"},{_str_strSettlement, "AsSession.strSettlement"},{_str_strCampaignID, _str_strCampaignID},{_str_strCampaignName, _str_strCampaignName}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strMonitoringSessionID, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "ActionEditAsSession")}};
                AsSessionListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<AsSessionListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AsSessionListItemGridModel()
                {
                    ItemKey=c.idfMonitoringSession,strMonitoringSessionID=c.strMonitoringSessionID,datStartDate=c.datStartDate,datEndDate=c.datEndDate,strRegion=c.strRegion,strRayon=c.strRayon,strSettlement=c.strSettlement,strCampaignID=c.strCampaignID,strCampaignName=c.strCampaignName
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
        : DataAccessor<AsSessionListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<AsSessionListItem>
            
            , IObjectSelectList
            , IObjectSelectList<AsSessionListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfMonitoringSession"; } }
            #endregion
        
            private delegate void on_action(AsSessionListItem obj);
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
            private BaseReference.Accessor AsSessionStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AsCampaignTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor PersonEnteredByAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            private SiteLookup.Accessor SiteAccessor { get { return eidss.model.Schema.SiteLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<AsSessionListItem> SelectListT(DbManagerProxy manager
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
            
            private List<AsSessionListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_AsSession_SelectList.* from dbo.fn_AsSession_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("idfsDiagnosis"))
                {
                    
                    sql.Append(" " + @"
            LEFT JOIN( select distinct d1.idfMonitoringSession, d1.idfsDiagnosis from tlbMonitoringSessionToDiagnosis d1
            where d1.intRowStatus = 0) as d
            ON			fn_AsSession_SelectList.idfMonitoringSession = d.idfMonitoringSession
          ");
                      
                }
                
                if (filters.Contains("strFieldBarCode"))
                {
                    
                    sql.Append(" " + @"
            INNER JOIN tlbMaterial m 
            ON			fn_AsSession_SelectList.idfMonitoringSession = m.idfMonitoringSession
            and m.intRowStatus = 0
          ");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (ModelUserContext.IsWebContext && EidssSiteContext.Instance.SiteType == SiteType.TLVL)
                {
                    sql.Append(@" and exists (select * from  tflMonitoringSessionFiltered f inner join tflSiteToSiteGroup on tflSiteToSiteGroup.idfSiteGroup = f.idfSiteGroup and tflSiteToSiteGroup.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString() + " where f.idfMonitoringSession = fn_AsSession_SelectList.idfMonitoringSession)");
                }
                
                if (filters.Contains("idfsDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsDiagnosis") == 1)
                    {
                        sql.AppendFormat("d.idfsDiagnosis {0} @idfsDiagnosis", filters.Operation("idfsDiagnosis"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsDiagnosis") ? " or " : " and ");
                            sql.AppendFormat("d.idfsDiagnosis {0} @idfsDiagnosis_{1}", filters.Operation("idfsDiagnosis", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strFieldBarCode"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strFieldBarCode") == 1)
                    {
                        sql.AppendFormat("m.strFieldBarcode {0} @strFieldBarCode", filters.Operation("strFieldBarCode"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strFieldBarCode"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strFieldBarCode") ? " or " : " and ");
                            sql.AppendFormat("m.strFieldBarcode {0} @strFieldBarCode_{1}", filters.Operation("strFieldBarCode", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfMonitoringSession"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfMonitoringSession"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfMonitoringSession") ? " or " : " and ");
                        
                        if (filters.Operation("idfMonitoringSession", i) == "&")
                          sql.AppendFormat("(isnull(fn_AsSession_SelectList.idfMonitoringSession,0) {0} @idfMonitoringSession_{1} = @idfMonitoringSession_{1})", filters.Operation("idfMonitoringSession", i), i);
                        else
                          sql.AppendFormat("isnull(fn_AsSession_SelectList.idfMonitoringSession,0) {0} @idfMonitoringSession_{1}", filters.Operation("idfMonitoringSession", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AsSession_SelectList.strStatus {0} @strStatus_{1}", filters.Operation("strStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsMonitoringSessionStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsMonitoringSessionStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsMonitoringSessionStatus") ? " or " : " and ");
                        
                        if (filters.Operation("idfsMonitoringSessionStatus", i) == "&")
                          sql.AppendFormat("(isnull(fn_AsSession_SelectList.idfsMonitoringSessionStatus,0) {0} @idfsMonitoringSessionStatus_{1} = @idfsMonitoringSessionStatus_{1})", filters.Operation("idfsMonitoringSessionStatus", i), i);
                        else
                          sql.AppendFormat("isnull(fn_AsSession_SelectList.idfsMonitoringSessionStatus,0) {0} @idfsMonitoringSessionStatus_{1}", filters.Operation("idfsMonitoringSessionStatus", i), i);
                            
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
                        
                        sql.AppendFormat("fn_AsSession_SelectList.strRegion {0} @strRegion_{1}", filters.Operation("strRegion", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_AsSession_SelectList.idfsRegion,0) {0} @idfsRegion_{1} = @idfsRegion_{1})", filters.Operation("idfsRegion", i), i);
                        else
                          sql.AppendFormat("isnull(fn_AsSession_SelectList.idfsRegion,0) {0} @idfsRegion_{1}", filters.Operation("idfsRegion", i), i);
                            
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
                        
                        sql.AppendFormat("fn_AsSession_SelectList.strRayon {0} @strRayon_{1}", filters.Operation("strRayon", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_AsSession_SelectList.idfsRayon,0) {0} @idfsRayon_{1} = @idfsRayon_{1})", filters.Operation("idfsRayon", i), i);
                        else
                          sql.AppendFormat("isnull(fn_AsSession_SelectList.idfsRayon,0) {0} @idfsRayon_{1}", filters.Operation("idfsRayon", i), i);
                            
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
                        
                        sql.AppendFormat("fn_AsSession_SelectList.strSettlement {0} @strSettlement_{1}", filters.Operation("strSettlement", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_AsSession_SelectList.idfsSettlement,0) {0} @idfsSettlement_{1} = @idfsSettlement_{1})", filters.Operation("idfsSettlement", i), i);
                        else
                          sql.AppendFormat("isnull(fn_AsSession_SelectList.idfsSettlement,0) {0} @idfsSettlement_{1}", filters.Operation("idfsSettlement", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_AsSession_SelectList.datEnteredDate, 112) {0} CONVERT(NVARCHAR(8), @datEnteredDate_{1}, 112)", filters.Operation("datEnteredDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfPersonEnteredBy"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfPersonEnteredBy"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfPersonEnteredBy") ? " or " : " and ");
                        
                        if (filters.Operation("idfPersonEnteredBy", i) == "&")
                          sql.AppendFormat("(isnull(fn_AsSession_SelectList.idfPersonEnteredBy,0) {0} @idfPersonEnteredBy_{1} = @idfPersonEnteredBy_{1})", filters.Operation("idfPersonEnteredBy", i), i);
                        else
                          sql.AppendFormat("isnull(fn_AsSession_SelectList.idfPersonEnteredBy,0) {0} @idfPersonEnteredBy_{1}", filters.Operation("idfPersonEnteredBy", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strMonitoringSessionID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strMonitoringSessionID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strMonitoringSessionID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AsSession_SelectList.strMonitoringSessionID {0} @strMonitoringSessionID_{1}", filters.Operation("strMonitoringSessionID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strDisease"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strDisease"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strDisease") ? " or " : " and ");
                        
                        if (filters.Operation("strDisease", i) == "&")
                          sql.AppendFormat("(isnull(fn_AsSession_SelectList.strDisease,0) {0} @strDisease_{1} = @strDisease_{1})", filters.Operation("strDisease", i), i);
                        else
                          sql.AppendFormat("isnull(fn_AsSession_SelectList.strDisease,0) {0} @strDisease_{1}", filters.Operation("strDisease", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCampaignID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCampaignID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCampaignID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AsSession_SelectList.strCampaignID {0} @strCampaignID_{1}", filters.Operation("strCampaignID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCampaignName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCampaignName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCampaignName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AsSession_SelectList.strCampaignName {0} @strCampaignName_{1}", filters.Operation("strCampaignName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datCampaignDateStart"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datCampaignDateStart"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datCampaignDateStart") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_AsSession_SelectList.datCampaignDateStart, 112) {0} CONVERT(NVARCHAR(8), @datCampaignDateStart_{1}, 112)", filters.Operation("datCampaignDateStart", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datCampaignDateEnd"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datCampaignDateEnd"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datCampaignDateEnd") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_AsSession_SelectList.datCampaignDateEnd, 112) {0} CONVERT(NVARCHAR(8), @datCampaignDateEnd_{1}, 112)", filters.Operation("datCampaignDateEnd", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCampaignType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCampaignType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCampaignType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsCampaignType", i) == "&")
                          sql.AppendFormat("(isnull(fn_AsSession_SelectList.idfsCampaignType,0) {0} @idfsCampaignType_{1} = @idfsCampaignType_{1})", filters.Operation("idfsCampaignType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_AsSession_SelectList.idfsCampaignType,0) {0} @idfsCampaignType_{1}", filters.Operation("idfsCampaignType", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_AsSession_SelectList.datStartDate, 112) {0} CONVERT(NVARCHAR(8), @datStartDate_{1}, 112)", filters.Operation("datStartDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datEndDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datEndDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datEndDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_AsSession_SelectList.datEndDate, 112) {0} CONVERT(NVARCHAR(8), @datEndDate_{1}, 112)", filters.Operation("datEndDate", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_AsSession_SelectList.idfsSite,0) {0} @idfsSite_{1} = @idfsSite_{1})", filters.Operation("idfsSite", i), i);
                        else
                          sql.AppendFormat("isnull(fn_AsSession_SelectList.idfsSite,0) {0} @idfsSite_{1}", filters.Operation("idfsSite", i), i);
                            
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
                    
                    if (filters.Contains("strFieldBarCode"))
                        
                        if (filters.Count("strFieldBarCode") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFieldBarCode", ParsingHelper.CorrectLikeValue(filters.Operation("strFieldBarCode"), filters.Value("strFieldBarCode"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strFieldBarCode"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFieldBarCode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFieldBarCode", i), filters.Value("strFieldBarCode", i))));
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
                            
                    if (filters.Contains("idfMonitoringSession"))
                        for (int i = 0; i < filters.Count("idfMonitoringSession"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMonitoringSession_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMonitoringSession", i), filters.Value("idfMonitoringSession", i))));
                      
                    if (filters.Contains("strStatus"))
                        for (int i = 0; i < filters.Count("strStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strStatus", i), filters.Value("strStatus", i))));
                      
                    if (filters.Contains("idfsMonitoringSessionStatus"))
                        for (int i = 0; i < filters.Count("idfsMonitoringSessionStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsMonitoringSessionStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsMonitoringSessionStatus", i), filters.Value("idfsMonitoringSessionStatus", i))));
                      
                    if (filters.Contains("strRegion"))
                        for (int i = 0; i < filters.Count("strRegion"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strRegion", i), filters.Value("strRegion", i))));
                      
                    if (filters.Contains("idfsRegion"))
                        for (int i = 0; i < filters.Count("idfsRegion"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion", i), filters.Value("idfsRegion", i))));
                      
                    if (filters.Contains("strRayon"))
                        for (int i = 0; i < filters.Count("strRayon"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strRayon", i), filters.Value("strRayon", i))));
                      
                    if (filters.Contains("idfsRayon"))
                        for (int i = 0; i < filters.Count("idfsRayon"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon", i), filters.Value("idfsRayon", i))));
                      
                    if (filters.Contains("strSettlement"))
                        for (int i = 0; i < filters.Count("strSettlement"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSettlement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSettlement", i), filters.Value("strSettlement", i))));
                      
                    if (filters.Contains("idfsSettlement"))
                        for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlement", i), filters.Value("idfsSettlement", i))));
                      
                    if (filters.Contains("datEnteredDate"))
                        for (int i = 0; i < filters.Count("datEnteredDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datEnteredDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datEnteredDate", i), filters.Value("datEnteredDate", i))));
                      
                    if (filters.Contains("idfPersonEnteredBy"))
                        for (int i = 0; i < filters.Count("idfPersonEnteredBy"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfPersonEnteredBy_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfPersonEnteredBy", i), filters.Value("idfPersonEnteredBy", i))));
                      
                    if (filters.Contains("strMonitoringSessionID"))
                        for (int i = 0; i < filters.Count("strMonitoringSessionID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strMonitoringSessionID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strMonitoringSessionID", i), filters.Value("strMonitoringSessionID", i))));
                      
                    if (filters.Contains("strDisease"))
                        for (int i = 0; i < filters.Count("strDisease"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strDisease_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strDisease", i), filters.Value("strDisease", i))));
                      
                    if (filters.Contains("strCampaignID"))
                        for (int i = 0; i < filters.Count("strCampaignID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCampaignID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCampaignID", i), filters.Value("strCampaignID", i))));
                      
                    if (filters.Contains("strCampaignName"))
                        for (int i = 0; i < filters.Count("strCampaignName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCampaignName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCampaignName", i), filters.Value("strCampaignName", i))));
                      
                    if (filters.Contains("datCampaignDateStart"))
                        for (int i = 0; i < filters.Count("datCampaignDateStart"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datCampaignDateStart_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datCampaignDateStart", i), filters.Value("datCampaignDateStart", i))));
                      
                    if (filters.Contains("datCampaignDateEnd"))
                        for (int i = 0; i < filters.Count("datCampaignDateEnd"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datCampaignDateEnd_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datCampaignDateEnd", i), filters.Value("datCampaignDateEnd", i))));
                      
                    if (filters.Contains("idfsCampaignType"))
                        for (int i = 0; i < filters.Count("idfsCampaignType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCampaignType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCampaignType", i), filters.Value("idfsCampaignType", i))));
                      
                    if (filters.Contains("datStartDate"))
                        for (int i = 0; i < filters.Count("datStartDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datStartDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datStartDate", i), filters.Value("datStartDate", i))));
                      
                    if (filters.Contains("datEndDate"))
                        for (int i = 0; i < filters.Count("datEndDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datEndDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datEndDate", i), filters.Value("datEndDate", i))));
                      
                    if (filters.Contains("idfsSite"))
                        for (int i = 0; i < filters.Count("idfsSite"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSite_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSite", i), filters.Value("idfsSite", i))));
                      
                    List<AsSessionListItem> objs = manager.ExecuteList<AsSessionListItem>();
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
            partial void ListSelected(DbManagerProxy manager, List<AsSessionListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spASSession_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsSessionListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AsSessionListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AsSessionListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    AsSessionListItem obj = AsSessionListItem.CreateInstance();
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
                obj.Country = new Func<AsSessionListItem, CountryLookup>(c => 
                                     c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
                                     .SingleOrDefault())(obj);
                obj.Region = new Func<AsSessionListItem, RegionLookup>(c => 
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

            
            public AsSessionListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AsSessionListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AsSessionListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ActionEditAsSession(DbManagerProxy manager, AsSessionListItem obj, List<object> pars)
            {
                
                return ActionEditAsSession(manager, obj
                    );
            }
            public ActResult ActionEditAsSession(DbManagerProxy manager, AsSessionListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ActionEditAsSession"))
                    throw new PermissionException("MonitoringSession", "ActionEditAsSession");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(AsSessionListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AsSessionListItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.Region = new Func<AsSessionListItem, RegionLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.Rayon = new Func<AsSessionListItem, RayonLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                obj.Settlement = new Func<AsSessionListItem, SettlementLookup>(c => null)(obj);
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
                    
                    };
                
            }
    
            public void LoadLookup_Country(DbManagerProxy manager, AsSessionListItem obj)
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
            
            public void LoadLookup_Region(DbManagerProxy manager, AsSessionListItem obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<AsSessionListItem, long>(c => c.idfsCountry ?? 0)(obj)
                            
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
            
            public void LoadLookup_Rayon(DbManagerProxy manager, AsSessionListItem obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<AsSessionListItem, long>(c => c.idfsRegion ?? 0)(obj)
                            
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
            
            public void LoadLookup_Settlement(DbManagerProxy manager, AsSessionListItem obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<AsSessionListItem, long>(c => c.idfsRayon ?? 0)(obj)
                            
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
            
            public void LoadLookup_AsSessionStatus(DbManagerProxy manager, AsSessionListItem obj)
            {
                
                obj.AsSessionStatusLookup.Clear();
                
                obj.AsSessionStatusLookup.Add(AsSessionStatusAccessor.CreateNewT(manager, null));
                
                obj.AsSessionStatusLookup.AddRange(AsSessionStatusAccessor.rftMonitoringSessionStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsMonitoringSessionStatus))
                    
                    .ToList());
                
                if (obj.idfsMonitoringSessionStatus != null && obj.idfsMonitoringSessionStatus != 0)
                {
                    obj.AsSessionStatus = obj.AsSessionStatusLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsMonitoringSessionStatus);
                    
                }
              
                
                LookupManager.AddObject("rftMonitoringSessionStatus", obj, AsSessionStatusAccessor.GetType(), "rftMonitoringSessionStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_AsCampaignType(DbManagerProxy manager, AsSessionListItem obj)
            {
                
                obj.AsCampaignTypeLookup.Clear();
                
                obj.AsCampaignTypeLookup.Add(AsCampaignTypeAccessor.CreateNewT(manager, null));
                
                obj.AsCampaignTypeLookup.AddRange(AsCampaignTypeAccessor.rftCampaignType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCampaignType))
                    
                    .ToList());
                
                if (obj.idfsCampaignType != null && obj.idfsCampaignType != 0)
                {
                    obj.AsCampaignType = obj.AsCampaignTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsCampaignType);
                    
                }
              
                
                LookupManager.AddObject("rftCampaignType", obj, AsCampaignTypeAccessor.GetType(), "rftCampaignType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Diagnosis(DbManagerProxy manager, AsSessionListItem obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Livestock) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
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
            
            public void LoadLookup_PersonEnteredBy(DbManagerProxy manager, AsSessionListItem obj)
            {
                
                obj.PersonEnteredByLookup.Clear();
                
                obj.PersonEnteredByLookup.Add(PersonEnteredByAccessor.CreateNewT(manager, null));
                
                obj.PersonEnteredByLookup.AddRange(PersonEnteredByAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    , false
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfPersonEnteredBy))
                    
                    .ToList());
                
                if (obj.idfPersonEnteredBy != null && obj.idfPersonEnteredBy != 0)
                {
                    obj.PersonEnteredBy = obj.PersonEnteredByLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfPersonEnteredBy);
                    
                }
              
                
                LookupManager.AddObject("PersonLookup", obj, PersonEnteredByAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Site(DbManagerProxy manager, AsSessionListItem obj)
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
            

            private void _LoadLookups(DbManagerProxy manager, AsSessionListItem obj)
            {
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
                LoadLookup_AsSessionStatus(manager, obj);
                
                LoadLookup_AsCampaignType(manager, obj);
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_PersonEnteredBy(manager, obj);
                
                LoadLookup_Site(manager, obj);
                
            }
    
            [SprocName("spASSession_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spASSession_Delete")]
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
                    AsSessionListItem bo = obj as AsSessionListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("MonitoringSession", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("MonitoringSession", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("MonitoringSession", "Update");
                    }
                    
                    long mainObject = bo.idfMonitoringSession;
                    
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoMonitoringSession;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbMonitoringSession;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as AsSessionListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsSessionListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfMonitoringSession
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
            
            public bool ValidateCanDelete(AsSessionListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AsSessionListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfMonitoringSession
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
        
      
            protected ValidationModelException ChainsValidate(AsSessionListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(AsSessionListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as AsSessionListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsSessionListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("MonitoringSession.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("MonitoringSession.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("MonitoringSession.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("MonitoringSession.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(AsSessionListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(AsSessionListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsSessionListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsSessionListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsSessionListItemDetail"; } }
            public string HelpIdWin { get { return "VC_V17"; } }
            public string HelpIdWeb { get { return "VC_V17"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private AsSessionListItem m_obj;
            internal Permissions(AsSessionListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("MonitoringSession.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("MonitoringSession.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("MonitoringSession.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("MonitoringSession.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_AsSession_SelectList";
            public static string spCount = "spASSession_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spASSession_Delete";
            public static string spCanDelete = "spASSession_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsSessionListItem, bool>> RequiredByField = new Dictionary<string, Func<AsSessionListItem, bool>>();
            public static Dictionary<string, Func<AsSessionListItem, bool>> RequiredByProperty = new Dictionary<string, Func<AsSessionListItem, bool>>();
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
                
                Sizes.Add(_str_strStatus, 2000);
                Sizes.Add(_str_strRegion, 300);
                Sizes.Add(_str_strRayon, 300);
                Sizes.Add(_str_strSettlement, 300);
                Sizes.Add(_str_strMonitoringSessionID, 50);
                Sizes.Add(_str_strCampaignID, 50);
                Sizes.Add(_str_strCampaignName, 200);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strMonitoringSessionID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strMonitoringSessionID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFieldBarCode",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strFieldBarcodeField",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsMonitoringSessionStatus",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strStatus",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "AsSessionStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosis",
                    EditorType.Lookup,
                    EditorControlWidth.Large, true, true, false, false, 
                    "AsSessionListItem.idfsDiagnosis",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, "DiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRegion",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsRegion",
                    null, "=", c => false, false, SearchPanelLocation.Main, false, "idfsRayon", "RegionLookup", typeof(RegionLookup), (o) => { var c = (RegionLookup)o; return c.idfsRegion; }, (o) => { var c = (RegionLookup)o; return c.strRegionName; }, null,false
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
                    "strTownOrVillage",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SettlementLookup", typeof(SettlementLookup), (o) => { var c = (SettlementLookup)o; return c.idfsSettlement; }, (o) => { var c = (SettlementLookup)o; return c.strSettlementName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datStartDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, true, 
                    "datStartDate",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datEndDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datEndDate",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datEnteredDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "AsSessionListItem.datEnteredDate",
                    c => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, c => true, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfPersonEnteredBy",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfPersonEnteredBy",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "PersonEnteredByLookup", typeof(PersonLookup), (o) => { var c = (PersonLookup)o; return c.idfPerson; }, (o) => { var c = (PersonLookup)o; return c.FullName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCampaignID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strCampaignID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCampaignName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strCampaignName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCampaignType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strCampaignType",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "AsCampaignTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSite",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "lbDataEntrySiteID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SiteLookup", typeof(SiteLookup), (o) => { var c = (SiteLookup)o; return c.idfsSite; }, (o) => { var c = (SiteLookup)o; return c.strSiteName; }, new List<Tuple<string, string>>(){new Tuple<string, string>("strSiteName", eidss.model.Resources.EidssFields.Get("strSiteName")),new Tuple<string, string>("strSiteID", eidss.model.Resources.EidssFields.Get("strSiteID")),},false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfMonitoringSession,
                    _str_idfMonitoringSession, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strMonitoringSessionID,
                    _str_strMonitoringSessionID, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datStartDate,
                    _str_datStartDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datEndDate,
                    _str_datEndDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRegion,
                    "idfsRegion", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRayon,
                    "idfsRayon", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSettlement,
                    "AsSession.strSettlement", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCampaignID,
                    _str_strCampaignID, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCampaignName,
                    _str_strCampaignName, null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "ActionEditAsSession",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionEditAsSession(manager, (AsSessionListItem)c, pars),
                        
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<AsSession>().CreateNew(manager, c, pars == null ? null : (int?)pars[0])),
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<AsSession>().SelectDetail(manager, pars[0])),
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
                                c = ObjectAccessor.CreatorInterface<AsSessionListItem>().CreateWithParams(manager, null, pars);
                                ((AsSessionListItem)c).idfMonitoringSession = (long)pars[0];
                                ((AsSessionListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((AsSessionListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<AsSessionListItem>().Post(manager, (AsSessionListItem)c), c);
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
                    
                Actions.Add(new ActionMetaItem(
                    "Report",
                    ActionTypes.Report,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strReport_Id",
                        "Report",
                        /*from BvMessages*/"tooltipReport_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipReport_Id",
                        ActionsAlignment.Left,
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
	