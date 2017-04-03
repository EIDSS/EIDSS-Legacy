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
    public abstract partial class AsSession : 
        EditableObject<AsSession>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfMonitoringSession), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMonitoringSession { get; set; }
                
        [LocalizedDisplayName(_str_idfsMonitoringSessionStatus)]
        [MapField(_str_idfsMonitoringSessionStatus)]
        public abstract Int64? idfsMonitoringSessionStatus { get; set; }
        #if MONO
        protected Int64? idfsMonitoringSessionStatus_Original { get { return idfsMonitoringSessionStatus; } }
        protected Int64? idfsMonitoringSessionStatus_Previous { get { return idfsMonitoringSessionStatus; } }
        #else
        protected Int64? idfsMonitoringSessionStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMonitoringSessionStatus).OriginalValue; } }
        protected Int64? idfsMonitoringSessionStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMonitoringSessionStatus).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsSettlement)]
        [MapField(_str_idfsSettlement)]
        public abstract Int64? idfsSettlement { get; set; }
        #if MONO
        protected Int64? idfsSettlement_Original { get { return idfsSettlement; } }
        protected Int64? idfsSettlement_Previous { get { return idfsSettlement; } }
        #else
        protected Int64? idfsSettlement_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).OriginalValue; } }
        protected Int64? idfsSettlement_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfPersonEnteredBy)]
        [MapField(_str_idfPersonEnteredBy)]
        public abstract Int64? idfPersonEnteredBy { get; set; }
        #if MONO
        protected Int64? idfPersonEnteredBy_Original { get { return idfPersonEnteredBy; } }
        protected Int64? idfPersonEnteredBy_Previous { get { return idfPersonEnteredBy; } }
        #else
        protected Int64? idfPersonEnteredBy_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonEnteredBy).OriginalValue; } }
        protected Int64? idfPersonEnteredBy_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonEnteredBy).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfCampaign)]
        [MapField(_str_idfCampaign)]
        public abstract Int64? idfCampaign { get; set; }
        #if MONO
        protected Int64? idfCampaign_Original { get { return idfCampaign; } }
        protected Int64? idfCampaign_Previous { get { return idfCampaign; } }
        #else
        protected Int64? idfCampaign_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCampaign).OriginalValue; } }
        protected Int64? idfCampaign_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCampaign).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_datEnteredDate)]
        [MapField(_str_datEnteredDate)]
        public abstract DateTime? datEnteredDate { get; set; }
        #if MONO
        protected DateTime? datEnteredDate_Original { get { return datEnteredDate; } }
        protected DateTime? datEnteredDate_Previous { get { return datEnteredDate; } }
        #else
        protected DateTime? datEnteredDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).OriginalValue; } }
        protected DateTime? datEnteredDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strMonitoringSessionID)]
        [MapField(_str_strMonitoringSessionID)]
        public abstract String strMonitoringSessionID { get; set; }
        #if MONO
        protected String strMonitoringSessionID_Original { get { return strMonitoringSessionID; } }
        protected String strMonitoringSessionID_Previous { get { return strMonitoringSessionID; } }
        #else
        protected String strMonitoringSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).OriginalValue; } }
        protected String strMonitoringSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("AsSession.DetailsStartDate")]
        [MapField(_str_datStartDate)]
        public abstract DateTime? datStartDate { get; set; }
        #if MONO
        protected DateTime? datStartDate_Original { get { return datStartDate; } }
        protected DateTime? datStartDate_Previous { get { return datStartDate; } }
        #else
        protected DateTime? datStartDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime? datStartDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datEndDate)]
        [MapField(_str_datEndDate)]
        public abstract DateTime? datEndDate { get; set; }
        #if MONO
        protected DateTime? datEndDate_Original { get { return datEndDate; } }
        protected DateTime? datEndDate_Previous { get { return datEndDate; } }
        #else
        protected DateTime? datEndDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEndDate).OriginalValue; } }
        protected DateTime? datEndDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEndDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCampaignID)]
        [MapField(_str_strCampaignID)]
        public abstract String strCampaignID { get; set; }
        #if MONO
        protected String strCampaignID_Original { get { return strCampaignID; } }
        protected String strCampaignID_Previous { get { return strCampaignID; } }
        #else
        protected String strCampaignID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCampaignID).OriginalValue; } }
        protected String strCampaignID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCampaignID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCampaignName)]
        [MapField(_str_strCampaignName)]
        public abstract String strCampaignName { get; set; }
        #if MONO
        protected String strCampaignName_Original { get { return strCampaignName; } }
        protected String strCampaignName_Previous { get { return strCampaignName; } }
        #else
        protected String strCampaignName_Original { get { return ((EditableValue<String>)((dynamic)this)._strCampaignName).OriginalValue; } }
        protected String strCampaignName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCampaignName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCampaignType)]
        [MapField(_str_idfsCampaignType)]
        public abstract Int64? idfsCampaignType { get; set; }
        #if MONO
        protected Int64? idfsCampaignType_Original { get { return idfsCampaignType; } }
        protected Int64? idfsCampaignType_Previous { get { return idfsCampaignType; } }
        #else
        protected Int64? idfsCampaignType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCampaignType).OriginalValue; } }
        protected Int64? idfsCampaignType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCampaignType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datCampaignDateStart)]
        [MapField(_str_datCampaignDateStart)]
        public abstract DateTime? datCampaignDateStart { get; set; }
        #if MONO
        protected DateTime? datCampaignDateStart_Original { get { return datCampaignDateStart; } }
        protected DateTime? datCampaignDateStart_Previous { get { return datCampaignDateStart; } }
        #else
        protected DateTime? datCampaignDateStart_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateStart).OriginalValue; } }
        protected DateTime? datCampaignDateStart_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateStart).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datCampaignDateEnd)]
        [MapField(_str_datCampaignDateEnd)]
        public abstract DateTime? datCampaignDateEnd { get; set; }
        #if MONO
        protected DateTime? datCampaignDateEnd_Original { get { return datCampaignDateEnd; } }
        protected DateTime? datCampaignDateEnd_Previous { get { return datCampaignDateEnd; } }
        #else
        protected DateTime? datCampaignDateEnd_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateEnd).OriginalValue; } }
        protected DateTime? datCampaignDateEnd_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateEnd).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<AsSession, object> _get_func;
            internal Action<AsSession, string> _set_func;
            internal Action<AsSession, AsSession, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_idfsMonitoringSessionStatus = "idfsMonitoringSessionStatus";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_idfPersonEnteredBy = "idfPersonEnteredBy";
        internal const string _str_idfCampaign = "idfCampaign";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_datEnteredDate = "datEnteredDate";
        internal const string _str_strMonitoringSessionID = "strMonitoringSessionID";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_datEndDate = "datEndDate";
        internal const string _str_strCampaignID = "strCampaignID";
        internal const string _str_strCampaignName = "strCampaignName";
        internal const string _str_idfsCampaignType = "idfsCampaignType";
        internal const string _str_datCampaignDateStart = "datCampaignDateStart";
        internal const string _str_datCampaignDateEnd = "datCampaignDateEnd";
        internal const string _str__blnAllowCampaignReload = "_blnAllowCampaignReload";
        internal const string _str__blnReloadSummaryFigures = "_blnReloadSummaryFigures";
        internal const string _str_blnForceCampaignAssignment = "blnForceCampaignAssignment";
        internal const string _str__idfFarmForCaseCreation = "_idfFarmForCaseCreation";
        internal const string _str__strCreatedCases = "_strCreatedCases";
        internal const string _str_CampaignInRamOnly = "CampaignInRamOnly";
        internal const string _str_buttonSearchCampaign = "buttonSearchCampaign";
        internal const string _str_buttonEditCampaign = "buttonEditCampaign";
        internal const string _str_buttonRemoveCampaign = "buttonRemoveCampaign";
        internal const string _str_strReadOnlyCountry = "strReadOnlyCountry";
        internal const string _str_strReadOnlyEnteredDate = "strReadOnlyEnteredDate";
        internal const string _str_strPersonEnteredBy = "strPersonEnteredBy";
        internal const string _str_intTotalSampledAnimals = "intTotalSampledAnimals";
        internal const string _str_intTotalSamples = "intTotalSamples";
        internal const string _str_intTotalPositiveAnimals = "intTotalPositiveAnimals";
        internal const string _str_intTotalDiagnosedAnimals = "intTotalDiagnosedAnimals";
        internal const string _str_intTotalSamplesInDetails = "intTotalSamplesInDetails";
        internal const string _str_intTotalCases = "intTotalCases";
        internal const string _str_MonitoringSessionStatus = "MonitoringSessionStatus";
        internal const string _str_CampaignType = "CampaignType";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_EnteredByPerson = "EnteredByPerson";
        internal const string _str_Diseases = "Diseases";
        internal const string _str_Actions = "Actions";
        internal const string _str_SummaryItems = "SummaryItems";
        internal const string _str_DetailsTableView = "DetailsTableView";
        internal const string _str_ASAnimals = "ASAnimals";
        internal const string _str_ASSpecies = "ASSpecies";
        internal const string _str_ASFarms = "ASFarms";
        internal const string _str_ASSamples = "ASSamples";
        internal const string _str_Cases = "Cases";
        internal const string _str_CaseTests = "CaseTests";
        internal const string _str_CaseTestValidations = "CaseTestValidations";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfMonitoringSession, _type = "Int64",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { o.idfMonitoringSession = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, "Int64", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); }
              }, 
        
            new field_info {
              _name = _str_idfsMonitoringSessionStatus, _type = "Int64?",
              _get_func = o => o.idfsMonitoringSessionStatus,
              _set_func = (o, val) => { o.idfsMonitoringSessionStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsMonitoringSessionStatus != c.idfsMonitoringSessionStatus || o.IsRIRPropChanged(_str_idfsMonitoringSessionStatus, c)) 
                  m.Add(_str_idfsMonitoringSessionStatus, o.ObjectIdent + _str_idfsMonitoringSessionStatus, "Int64?", o.idfsMonitoringSessionStatus == null ? "" : o.idfsMonitoringSessionStatus.ToString(), o.IsReadOnly(_str_idfsMonitoringSessionStatus), o.IsInvisible(_str_idfsMonitoringSessionStatus), o.IsRequired(_str_idfsMonitoringSessionStatus)); }
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
              _name = _str_idfPersonEnteredBy, _type = "Int64?",
              _get_func = o => o.idfPersonEnteredBy,
              _set_func = (o, val) => { o.idfPersonEnteredBy = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfPersonEnteredBy != c.idfPersonEnteredBy || o.IsRIRPropChanged(_str_idfPersonEnteredBy, c)) 
                  m.Add(_str_idfPersonEnteredBy, o.ObjectIdent + _str_idfPersonEnteredBy, "Int64?", o.idfPersonEnteredBy == null ? "" : o.idfPersonEnteredBy.ToString(), o.IsReadOnly(_str_idfPersonEnteredBy), o.IsInvisible(_str_idfPersonEnteredBy), o.IsRequired(_str_idfPersonEnteredBy)); }
              }, 
        
            new field_info {
              _name = _str_idfCampaign, _type = "Int64?",
              _get_func = o => o.idfCampaign,
              _set_func = (o, val) => { o.idfCampaign = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCampaign != c.idfCampaign || o.IsRIRPropChanged(_str_idfCampaign, c)) 
                  m.Add(_str_idfCampaign, o.ObjectIdent + _str_idfCampaign, "Int64?", o.idfCampaign == null ? "" : o.idfCampaign.ToString(), o.IsReadOnly(_str_idfCampaign), o.IsInvisible(_str_idfCampaign), o.IsRequired(_str_idfCampaign)); }
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
              _name = _str_datEnteredDate, _type = "DateTime?",
              _get_func = o => o.datEnteredDate,
              _set_func = (o, val) => { o.datEnteredDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datEnteredDate != c.datEnteredDate || o.IsRIRPropChanged(_str_datEnteredDate, c)) 
                  m.Add(_str_datEnteredDate, o.ObjectIdent + _str_datEnteredDate, "DateTime?", o.datEnteredDate == null ? "" : o.datEnteredDate.ToString(), o.IsReadOnly(_str_datEnteredDate), o.IsInvisible(_str_datEnteredDate), o.IsRequired(_str_datEnteredDate)); }
              }, 
        
            new field_info {
              _name = _str_strMonitoringSessionID, _type = "String",
              _get_func = o => o.strMonitoringSessionID,
              _set_func = (o, val) => { o.strMonitoringSessionID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strMonitoringSessionID != c.strMonitoringSessionID || o.IsRIRPropChanged(_str_strMonitoringSessionID, c)) 
                  m.Add(_str_strMonitoringSessionID, o.ObjectIdent + _str_strMonitoringSessionID, "String", o.strMonitoringSessionID == null ? "" : o.strMonitoringSessionID.ToString(), o.IsReadOnly(_str_strMonitoringSessionID), o.IsInvisible(_str_strMonitoringSessionID), o.IsRequired(_str_strMonitoringSessionID)); }
              }, 
        
            new field_info {
              _name = _str_datStartDate, _type = "DateTime?",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { o.datStartDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, "DateTime?", o.datStartDate == null ? "" : o.datStartDate.ToString(), o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); }
              }, 
        
            new field_info {
              _name = _str_datEndDate, _type = "DateTime?",
              _get_func = o => o.datEndDate,
              _set_func = (o, val) => { o.datEndDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datEndDate != c.datEndDate || o.IsRIRPropChanged(_str_datEndDate, c)) 
                  m.Add(_str_datEndDate, o.ObjectIdent + _str_datEndDate, "DateTime?", o.datEndDate == null ? "" : o.datEndDate.ToString(), o.IsReadOnly(_str_datEndDate), o.IsInvisible(_str_datEndDate), o.IsRequired(_str_datEndDate)); }
              }, 
        
            new field_info {
              _name = _str_strCampaignID, _type = "String",
              _get_func = o => o.strCampaignID,
              _set_func = (o, val) => { o.strCampaignID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCampaignID != c.strCampaignID || o.IsRIRPropChanged(_str_strCampaignID, c)) 
                  m.Add(_str_strCampaignID, o.ObjectIdent + _str_strCampaignID, "String", o.strCampaignID == null ? "" : o.strCampaignID.ToString(), o.IsReadOnly(_str_strCampaignID), o.IsInvisible(_str_strCampaignID), o.IsRequired(_str_strCampaignID)); }
              }, 
        
            new field_info {
              _name = _str_strCampaignName, _type = "String",
              _get_func = o => o.strCampaignName,
              _set_func = (o, val) => { o.strCampaignName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCampaignName != c.strCampaignName || o.IsRIRPropChanged(_str_strCampaignName, c)) 
                  m.Add(_str_strCampaignName, o.ObjectIdent + _str_strCampaignName, "String", o.strCampaignName == null ? "" : o.strCampaignName.ToString(), o.IsReadOnly(_str_strCampaignName), o.IsInvisible(_str_strCampaignName), o.IsRequired(_str_strCampaignName)); }
              }, 
        
            new field_info {
              _name = _str_idfsCampaignType, _type = "Int64?",
              _get_func = o => o.idfsCampaignType,
              _set_func = (o, val) => { o.idfsCampaignType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCampaignType != c.idfsCampaignType || o.IsRIRPropChanged(_str_idfsCampaignType, c)) 
                  m.Add(_str_idfsCampaignType, o.ObjectIdent + _str_idfsCampaignType, "Int64?", o.idfsCampaignType == null ? "" : o.idfsCampaignType.ToString(), o.IsReadOnly(_str_idfsCampaignType), o.IsInvisible(_str_idfsCampaignType), o.IsRequired(_str_idfsCampaignType)); }
              }, 
        
            new field_info {
              _name = _str_datCampaignDateStart, _type = "DateTime?",
              _get_func = o => o.datCampaignDateStart,
              _set_func = (o, val) => { o.datCampaignDateStart = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCampaignDateStart != c.datCampaignDateStart || o.IsRIRPropChanged(_str_datCampaignDateStart, c)) 
                  m.Add(_str_datCampaignDateStart, o.ObjectIdent + _str_datCampaignDateStart, "DateTime?", o.datCampaignDateStart == null ? "" : o.datCampaignDateStart.ToString(), o.IsReadOnly(_str_datCampaignDateStart), o.IsInvisible(_str_datCampaignDateStart), o.IsRequired(_str_datCampaignDateStart)); }
              }, 
        
            new field_info {
              _name = _str_datCampaignDateEnd, _type = "DateTime?",
              _get_func = o => o.datCampaignDateEnd,
              _set_func = (o, val) => { o.datCampaignDateEnd = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCampaignDateEnd != c.datCampaignDateEnd || o.IsRIRPropChanged(_str_datCampaignDateEnd, c)) 
                  m.Add(_str_datCampaignDateEnd, o.ObjectIdent + _str_datCampaignDateEnd, "DateTime?", o.datCampaignDateEnd == null ? "" : o.datCampaignDateEnd.ToString(), o.IsReadOnly(_str_datCampaignDateEnd), o.IsInvisible(_str_datCampaignDateEnd), o.IsRequired(_str_datCampaignDateEnd)); }
              }, 
        
            new field_info {
              _name = _str__blnAllowCampaignReload, _type = "bool",
              _get_func = o => o._blnAllowCampaignReload,
              _set_func = (o, val) => { o._blnAllowCampaignReload = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o._blnAllowCampaignReload != c._blnAllowCampaignReload || o.IsRIRPropChanged(_str__blnAllowCampaignReload, c)) 
                  m.Add(_str__blnAllowCampaignReload, o.ObjectIdent + _str__blnAllowCampaignReload, "bool", o._blnAllowCampaignReload == null ? "" : o._blnAllowCampaignReload.ToString(), o.IsReadOnly(_str__blnAllowCampaignReload), o.IsInvisible(_str__blnAllowCampaignReload), o.IsRequired(_str__blnAllowCampaignReload));
                 }
              }, 
        
            new field_info {
              _name = _str__blnReloadSummaryFigures, _type = "bool",
              _get_func = o => o._blnReloadSummaryFigures,
              _set_func = (o, val) => { o._blnReloadSummaryFigures = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o._blnReloadSummaryFigures != c._blnReloadSummaryFigures || o.IsRIRPropChanged(_str__blnReloadSummaryFigures, c)) 
                  m.Add(_str__blnReloadSummaryFigures, o.ObjectIdent + _str__blnReloadSummaryFigures, "bool", o._blnReloadSummaryFigures == null ? "" : o._blnReloadSummaryFigures.ToString(), o.IsReadOnly(_str__blnReloadSummaryFigures), o.IsInvisible(_str__blnReloadSummaryFigures), o.IsRequired(_str__blnReloadSummaryFigures));
                 }
              }, 
        
            new field_info {
              _name = _str_blnForceCampaignAssignment, _type = "bool",
              _get_func = o => o.blnForceCampaignAssignment,
              _set_func = (o, val) => { o.blnForceCampaignAssignment = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.blnForceCampaignAssignment != c.blnForceCampaignAssignment || o.IsRIRPropChanged(_str_blnForceCampaignAssignment, c)) 
                  m.Add(_str_blnForceCampaignAssignment, o.ObjectIdent + _str_blnForceCampaignAssignment, "bool", o.blnForceCampaignAssignment == null ? "" : o.blnForceCampaignAssignment.ToString(), o.IsReadOnly(_str_blnForceCampaignAssignment), o.IsInvisible(_str_blnForceCampaignAssignment), o.IsRequired(_str_blnForceCampaignAssignment));
                 }
              }, 
        
            new field_info {
              _name = _str__idfFarmForCaseCreation, _type = "long?",
              _get_func = o => o._idfFarmForCaseCreation,
              _set_func = (o, val) => { o._idfFarmForCaseCreation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o._idfFarmForCaseCreation != c._idfFarmForCaseCreation || o.IsRIRPropChanged(_str__idfFarmForCaseCreation, c)) 
                  m.Add(_str__idfFarmForCaseCreation, o.ObjectIdent + _str__idfFarmForCaseCreation, "long?", o._idfFarmForCaseCreation == null ? "" : o._idfFarmForCaseCreation.ToString(), o.IsReadOnly(_str__idfFarmForCaseCreation), o.IsInvisible(_str__idfFarmForCaseCreation), o.IsRequired(_str__idfFarmForCaseCreation));
                 }
              }, 
        
            new field_info {
              _name = _str__strCreatedCases, _type = "string",
              _get_func = o => o._strCreatedCases,
              _set_func = (o, val) => { o._strCreatedCases = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
              
                if (o._strCreatedCases != c._strCreatedCases || o.IsRIRPropChanged(_str__strCreatedCases, c)) 
                  m.Add(_str__strCreatedCases, o.ObjectIdent + _str__strCreatedCases, "string", o._strCreatedCases == null ? "" : o._strCreatedCases.ToString(), o.IsReadOnly(_str__strCreatedCases), o.IsInvisible(_str__strCreatedCases), o.IsRequired(_str__strCreatedCases));
                 }
              }, 
        
            new field_info {
              _name = _str_CampaignInRamOnly, _type = "AsCampaign",
              _get_func = o => o.CampaignInRamOnly,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_buttonSearchCampaign, _type = "string",
              _get_func = o => o.buttonSearchCampaign,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.buttonSearchCampaign != c.buttonSearchCampaign || o.IsRIRPropChanged(_str_buttonSearchCampaign, c)) 
                  m.Add(_str_buttonSearchCampaign, o.ObjectIdent + _str_buttonSearchCampaign, "string", o.buttonSearchCampaign == null ? "" : o.buttonSearchCampaign.ToString(), o.IsReadOnly(_str_buttonSearchCampaign), o.IsInvisible(_str_buttonSearchCampaign), o.IsRequired(_str_buttonSearchCampaign));
                 }
              }, 
        
            new field_info {
              _name = _str_buttonEditCampaign, _type = "string",
              _get_func = o => o.buttonEditCampaign,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.buttonEditCampaign != c.buttonEditCampaign || o.IsRIRPropChanged(_str_buttonEditCampaign, c)) 
                  m.Add(_str_buttonEditCampaign, o.ObjectIdent + _str_buttonEditCampaign, "string", o.buttonEditCampaign == null ? "" : o.buttonEditCampaign.ToString(), o.IsReadOnly(_str_buttonEditCampaign), o.IsInvisible(_str_buttonEditCampaign), o.IsRequired(_str_buttonEditCampaign));
                 }
              }, 
        
            new field_info {
              _name = _str_buttonRemoveCampaign, _type = "string",
              _get_func = o => o.buttonRemoveCampaign,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.buttonRemoveCampaign != c.buttonRemoveCampaign || o.IsRIRPropChanged(_str_buttonRemoveCampaign, c)) 
                  m.Add(_str_buttonRemoveCampaign, o.ObjectIdent + _str_buttonRemoveCampaign, "string", o.buttonRemoveCampaign == null ? "" : o.buttonRemoveCampaign.ToString(), o.IsReadOnly(_str_buttonRemoveCampaign), o.IsInvisible(_str_buttonRemoveCampaign), o.IsRequired(_str_buttonRemoveCampaign));
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
              _name = _str_strReadOnlyEnteredDate, _type = "string",
              _get_func = o => o.strReadOnlyEnteredDate,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyEnteredDate != c.strReadOnlyEnteredDate || o.IsRIRPropChanged(_str_strReadOnlyEnteredDate, c)) 
                  m.Add(_str_strReadOnlyEnteredDate, o.ObjectIdent + _str_strReadOnlyEnteredDate, "string", o.strReadOnlyEnteredDate == null ? "" : o.strReadOnlyEnteredDate.ToString(), o.IsReadOnly(_str_strReadOnlyEnteredDate), o.IsInvisible(_str_strReadOnlyEnteredDate), o.IsRequired(_str_strReadOnlyEnteredDate));
                 }
              }, 
        
            new field_info {
              _name = _str_strPersonEnteredBy, _type = "string",
              _get_func = o => o.strPersonEnteredBy,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strPersonEnteredBy != c.strPersonEnteredBy || o.IsRIRPropChanged(_str_strPersonEnteredBy, c)) 
                  m.Add(_str_strPersonEnteredBy, o.ObjectIdent + _str_strPersonEnteredBy, "string", o.strPersonEnteredBy == null ? "" : o.strPersonEnteredBy.ToString(), o.IsReadOnly(_str_strPersonEnteredBy), o.IsInvisible(_str_strPersonEnteredBy), o.IsRequired(_str_strPersonEnteredBy));
                 }
              }, 
        
            new field_info {
              _name = _str_intTotalSampledAnimals, _type = "int",
              _get_func = o => o.intTotalSampledAnimals,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.intTotalSampledAnimals != c.intTotalSampledAnimals || o.IsRIRPropChanged(_str_intTotalSampledAnimals, c)) 
                  m.Add(_str_intTotalSampledAnimals, o.ObjectIdent + _str_intTotalSampledAnimals, "int", o.intTotalSampledAnimals == null ? "" : o.intTotalSampledAnimals.ToString(), o.IsReadOnly(_str_intTotalSampledAnimals), o.IsInvisible(_str_intTotalSampledAnimals), o.IsRequired(_str_intTotalSampledAnimals));
                 }
              }, 
        
            new field_info {
              _name = _str_intTotalSamples, _type = "int",
              _get_func = o => o.intTotalSamples,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.intTotalSamples != c.intTotalSamples || o.IsRIRPropChanged(_str_intTotalSamples, c)) 
                  m.Add(_str_intTotalSamples, o.ObjectIdent + _str_intTotalSamples, "int", o.intTotalSamples == null ? "" : o.intTotalSamples.ToString(), o.IsReadOnly(_str_intTotalSamples), o.IsInvisible(_str_intTotalSamples), o.IsRequired(_str_intTotalSamples));
                 }
              }, 
        
            new field_info {
              _name = _str_intTotalPositiveAnimals, _type = "int",
              _get_func = o => o.intTotalPositiveAnimals,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.intTotalPositiveAnimals != c.intTotalPositiveAnimals || o.IsRIRPropChanged(_str_intTotalPositiveAnimals, c)) 
                  m.Add(_str_intTotalPositiveAnimals, o.ObjectIdent + _str_intTotalPositiveAnimals, "int", o.intTotalPositiveAnimals == null ? "" : o.intTotalPositiveAnimals.ToString(), o.IsReadOnly(_str_intTotalPositiveAnimals), o.IsInvisible(_str_intTotalPositiveAnimals), o.IsRequired(_str_intTotalPositiveAnimals));
                 }
              }, 
        
            new field_info {
              _name = _str_intTotalDiagnosedAnimals, _type = "int",
              _get_func = o => o.intTotalDiagnosedAnimals,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.intTotalDiagnosedAnimals != c.intTotalDiagnosedAnimals || o.IsRIRPropChanged(_str_intTotalDiagnosedAnimals, c)) 
                  m.Add(_str_intTotalDiagnosedAnimals, o.ObjectIdent + _str_intTotalDiagnosedAnimals, "int", o.intTotalDiagnosedAnimals == null ? "" : o.intTotalDiagnosedAnimals.ToString(), o.IsReadOnly(_str_intTotalDiagnosedAnimals), o.IsInvisible(_str_intTotalDiagnosedAnimals), o.IsRequired(_str_intTotalDiagnosedAnimals));
                 }
              }, 
        
            new field_info {
              _name = _str_intTotalSamplesInDetails, _type = "int",
              _get_func = o => o.intTotalSamplesInDetails,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.intTotalSamplesInDetails != c.intTotalSamplesInDetails || o.IsRIRPropChanged(_str_intTotalSamplesInDetails, c)) 
                  m.Add(_str_intTotalSamplesInDetails, o.ObjectIdent + _str_intTotalSamplesInDetails, "int", o.intTotalSamplesInDetails == null ? "" : o.intTotalSamplesInDetails.ToString(), o.IsReadOnly(_str_intTotalSamplesInDetails), o.IsInvisible(_str_intTotalSamplesInDetails), o.IsRequired(_str_intTotalSamplesInDetails));
                 }
              }, 
        
            new field_info {
              _name = _str_intTotalCases, _type = "int",
              _get_func = o => o.intTotalCases,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.intTotalCases != c.intTotalCases || o.IsRIRPropChanged(_str_intTotalCases, c)) 
                  m.Add(_str_intTotalCases, o.ObjectIdent + _str_intTotalCases, "int", o.intTotalCases == null ? "" : o.intTotalCases.ToString(), o.IsReadOnly(_str_intTotalCases), o.IsInvisible(_str_intTotalCases), o.IsRequired(_str_intTotalCases));
                 }
              }, 
        
            new field_info {
              _name = _str_MonitoringSessionStatus, _type = "Lookup",
              _get_func = o => { if (o.MonitoringSessionStatus == null) return null; return o.MonitoringSessionStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.MonitoringSessionStatus = o.MonitoringSessionStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsMonitoringSessionStatus != c.idfsMonitoringSessionStatus || o.IsRIRPropChanged(_str_MonitoringSessionStatus, c)) 
                  m.Add(_str_MonitoringSessionStatus, o.ObjectIdent + _str_MonitoringSessionStatus, "Lookup", o.idfsMonitoringSessionStatus == null ? "" : o.idfsMonitoringSessionStatus.ToString(), o.IsReadOnly(_str_MonitoringSessionStatus), o.IsInvisible(_str_MonitoringSessionStatus), o.IsRequired(_str_MonitoringSessionStatus)); }
              }, 
        
            new field_info {
              _name = _str_CampaignType, _type = "Lookup",
              _get_func = o => { if (o.CampaignType == null) return null; return o.CampaignType.idfsBaseReference; },
              _set_func = (o, val) => { o.CampaignType = o.CampaignTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCampaignType != c.idfsCampaignType || o.IsRIRPropChanged(_str_CampaignType, c)) 
                  m.Add(_str_CampaignType, o.ObjectIdent + _str_CampaignType, "Lookup", o.idfsCampaignType == null ? "" : o.idfsCampaignType.ToString(), o.IsReadOnly(_str_CampaignType), o.IsInvisible(_str_CampaignType), o.IsRequired(_str_CampaignType)); }
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
              _name = _str_Diseases, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Diseases.Count != c.Diseases.Count || o.IsReadOnly(_str_Diseases) != c.IsReadOnly(_str_Diseases) || o.IsInvisible(_str_Diseases) != c.IsInvisible(_str_Diseases) || o.IsRequired(_str_Diseases) != c.IsRequired(_str_Diseases)) 
                  m.Add(_str_Diseases, o.ObjectIdent + _str_Diseases, "Child", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_Diseases), o.IsInvisible(_str_Diseases), o.IsRequired(_str_Diseases)); }
              }, 
        
            new field_info {
              _name = _str_Actions, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Actions.Count != c.Actions.Count || o.IsReadOnly(_str_Actions) != c.IsReadOnly(_str_Actions) || o.IsInvisible(_str_Actions) != c.IsInvisible(_str_Actions) || o.IsRequired(_str_Actions) != c.IsRequired(_str_Actions)) 
                  m.Add(_str_Actions, o.ObjectIdent + _str_Actions, "Child", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_Actions), o.IsInvisible(_str_Actions), o.IsRequired(_str_Actions)); }
              }, 
        
            new field_info {
              _name = _str_SummaryItems, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.SummaryItems.Count != c.SummaryItems.Count || o.IsReadOnly(_str_SummaryItems) != c.IsReadOnly(_str_SummaryItems) || o.IsInvisible(_str_SummaryItems) != c.IsInvisible(_str_SummaryItems) || o.IsRequired(_str_SummaryItems) != c.IsRequired(_str_SummaryItems)) 
                  m.Add(_str_SummaryItems, o.ObjectIdent + _str_SummaryItems, "Child", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_SummaryItems), o.IsInvisible(_str_SummaryItems), o.IsRequired(_str_SummaryItems)); }
              }, 
        
            new field_info {
              _name = _str_DetailsTableView, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.DetailsTableView.Count != c.DetailsTableView.Count || o.IsReadOnly(_str_DetailsTableView) != c.IsReadOnly(_str_DetailsTableView) || o.IsInvisible(_str_DetailsTableView) != c.IsInvisible(_str_DetailsTableView) || o.IsRequired(_str_DetailsTableView) != c.IsRequired(_str_DetailsTableView)) 
                  m.Add(_str_DetailsTableView, o.ObjectIdent + _str_DetailsTableView, "Child", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_DetailsTableView), o.IsInvisible(_str_DetailsTableView), o.IsRequired(_str_DetailsTableView)); }
              }, 
        
            new field_info {
              _name = _str_ASAnimals, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.ASAnimals.Count != c.ASAnimals.Count || o.IsReadOnly(_str_ASAnimals) != c.IsReadOnly(_str_ASAnimals) || o.IsInvisible(_str_ASAnimals) != c.IsInvisible(_str_ASAnimals) || o.IsRequired(_str_ASAnimals) != c.IsRequired(_str_ASAnimals)) 
                  m.Add(_str_ASAnimals, o.ObjectIdent + _str_ASAnimals, "Child", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_ASAnimals), o.IsInvisible(_str_ASAnimals), o.IsRequired(_str_ASAnimals)); }
              }, 
        
            new field_info {
              _name = _str_ASSpecies, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.ASSpecies.Count != c.ASSpecies.Count || o.IsReadOnly(_str_ASSpecies) != c.IsReadOnly(_str_ASSpecies) || o.IsInvisible(_str_ASSpecies) != c.IsInvisible(_str_ASSpecies) || o.IsRequired(_str_ASSpecies) != c.IsRequired(_str_ASSpecies)) 
                  m.Add(_str_ASSpecies, o.ObjectIdent + _str_ASSpecies, "Child", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_ASSpecies), o.IsInvisible(_str_ASSpecies), o.IsRequired(_str_ASSpecies)); }
              }, 
        
            new field_info {
              _name = _str_ASFarms, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.ASFarms.Count != c.ASFarms.Count || o.IsReadOnly(_str_ASFarms) != c.IsReadOnly(_str_ASFarms) || o.IsInvisible(_str_ASFarms) != c.IsInvisible(_str_ASFarms) || o.IsRequired(_str_ASFarms) != c.IsRequired(_str_ASFarms)) 
                  m.Add(_str_ASFarms, o.ObjectIdent + _str_ASFarms, "Child", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_ASFarms), o.IsInvisible(_str_ASFarms), o.IsRequired(_str_ASFarms)); }
              }, 
        
            new field_info {
              _name = _str_ASSamples, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.ASSamples.Count != c.ASSamples.Count || o.IsReadOnly(_str_ASSamples) != c.IsReadOnly(_str_ASSamples) || o.IsInvisible(_str_ASSamples) != c.IsInvisible(_str_ASSamples) || o.IsRequired(_str_ASSamples) != c.IsRequired(_str_ASSamples)) 
                  m.Add(_str_ASSamples, o.ObjectIdent + _str_ASSamples, "Child", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_ASSamples), o.IsInvisible(_str_ASSamples), o.IsRequired(_str_ASSamples)); }
              }, 
        
            new field_info {
              _name = _str_Cases, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Cases.Count != c.Cases.Count || o.IsReadOnly(_str_Cases) != c.IsReadOnly(_str_Cases) || o.IsInvisible(_str_Cases) != c.IsInvisible(_str_Cases) || o.IsRequired(_str_Cases) != c.IsRequired(_str_Cases)) 
                  m.Add(_str_Cases, o.ObjectIdent + _str_Cases, "Child", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_Cases), o.IsInvisible(_str_Cases), o.IsRequired(_str_Cases)); }
              }, 
        
            new field_info {
              _name = _str_CaseTests, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.CaseTests.Count != c.CaseTests.Count || o.IsReadOnly(_str_CaseTests) != c.IsReadOnly(_str_CaseTests) || o.IsInvisible(_str_CaseTests) != c.IsInvisible(_str_CaseTests) || o.IsRequired(_str_CaseTests) != c.IsRequired(_str_CaseTests)) 
                  m.Add(_str_CaseTests, o.ObjectIdent + _str_CaseTests, "Child", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_CaseTests), o.IsInvisible(_str_CaseTests), o.IsRequired(_str_CaseTests)); }
              }, 
        
            new field_info {
              _name = _str_CaseTestValidations, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.CaseTestValidations.Count != c.CaseTestValidations.Count || o.IsReadOnly(_str_CaseTestValidations) != c.IsReadOnly(_str_CaseTestValidations) || o.IsInvisible(_str_CaseTestValidations) != c.IsInvisible(_str_CaseTestValidations) || o.IsRequired(_str_CaseTestValidations) != c.IsRequired(_str_CaseTestValidations)) 
                  m.Add(_str_CaseTestValidations, o.ObjectIdent + _str_CaseTestValidations, "Child", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_CaseTestValidations), o.IsInvisible(_str_CaseTestValidations), o.IsRequired(_str_CaseTestValidations)); }
              }, 
        
            new field_info {
              _name = _str_EnteredByPerson, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.EnteredByPerson != null) o.EnteredByPerson._compare(c.EnteredByPerson, m); }
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
            AsSession obj = (AsSession)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(Personnel), eidss.model.Schema.Personnel._str_idfPerson, _str_idfPersonEnteredBy)]
        public Personnel EnteredByPerson
        {
            get 
            {   
                if (!_EnteredByPersonLoaded)
                {
                    _EnteredByPersonLoaded = true;
                    _getAccessor()._LoadEnteredByPerson(this);
                    if (_EnteredByPerson != null) 
                        _EnteredByPerson.Parent = this;
                }
                return _EnteredByPerson; 
            }
            set 
            {   
                if (!_EnteredByPersonLoaded) { _EnteredByPersonLoaded = true; }
                _EnteredByPerson = value;
                if (_EnteredByPerson != null) 
                { 
                    _EnteredByPerson.m_ObjectName = _str_EnteredByPerson;
                    _EnteredByPerson.Parent = this;
                }
                idfPersonEnteredBy = _EnteredByPerson == null 
                        ? new Int64?()
                        : _EnteredByPerson.idfPerson;
                
            }
        }
        protected Personnel _EnteredByPerson;
                    
        private bool _EnteredByPersonLoaded = false;
                    
        [Relation(typeof(AsSessionDisease), eidss.model.Schema.AsSessionDisease._str_idfMonitoringSession, _str_idfMonitoringSession)]
        public EditableList<AsSessionDisease> Diseases
        {
            get 
            {   
                return _Diseases; 
            }
            set 
            {
                _Diseases = value;
            }
        }
        protected EditableList<AsSessionDisease> _Diseases = new EditableList<AsSessionDisease>();
                    
        [Relation(typeof(AsSessionAction), eidss.model.Schema.AsSessionAction._str_idfMonitoringSession, _str_idfMonitoringSession)]
        public EditableList<AsSessionAction> Actions
        {
            get 
            {   
                return _Actions; 
            }
            set 
            {
                _Actions = value;
            }
        }
        protected EditableList<AsSessionAction> _Actions = new EditableList<AsSessionAction>();
                    
        [Relation(typeof(AsSessionSummary), eidss.model.Schema.AsSessionSummary._str_idfMonitoringSession, _str_idfMonitoringSession)]
        public EditableList<AsSessionSummary> SummaryItems
        {
            get 
            {   
                if (!_SummaryItemsLoaded)
                {
                    _SummaryItemsLoaded = true;
                    _getAccessor()._LoadSummaryItems(this);
                    _SummaryItems.ForEach(c => { c.Parent = this; });
                }
                return _SummaryItems; 
            }
            set 
            {
                _SummaryItems = value;
            }
        }
        protected EditableList<AsSessionSummary> _SummaryItems = new EditableList<AsSessionSummary>();
                    
        private bool _SummaryItemsLoaded = false;
                    
        [Relation(typeof(AsSessionTableViewItem), eidss.model.Schema.AsSessionTableViewItem._str_idfMonitoringSession, _str_idfMonitoringSession)]
        public EditableList<AsSessionTableViewItem> DetailsTableView
        {
            get 
            {   
                if (!_DetailsTableViewLoaded)
                {
                    _DetailsTableViewLoaded = true;
                    _getAccessor()._LoadDetailsTableView(this);
                    _DetailsTableView.ForEach(c => { c.Parent = this; });
                }
                return _DetailsTableView; 
            }
            set 
            {
                _DetailsTableView = value;
            }
        }
        protected EditableList<AsSessionTableViewItem> _DetailsTableView = new EditableList<AsSessionTableViewItem>();
                    
        private bool _DetailsTableViewLoaded = false;
                    
        [Relation(typeof(AsSessionAnimal), eidss.model.Schema.AsSessionAnimal._str_idfMonitoringSession, _str_idfMonitoringSession)]
        public EditableList<AsSessionAnimal> ASAnimals
        {
            get 
            {   
                return _ASAnimals; 
            }
            set 
            {
                _ASAnimals = value;
            }
        }
        protected EditableList<AsSessionAnimal> _ASAnimals = new EditableList<AsSessionAnimal>();
                    
        [Relation(typeof(AsSessionFarmSpeciesListItem), "", _str_idfMonitoringSession)]
        public EditableList<AsSessionFarmSpeciesListItem> ASSpecies
        {
            get 
            {   
                if (!_ASSpeciesLoaded)
                {
                    _ASSpeciesLoaded = true;
                    _getAccessor()._LoadASSpecies(this);
                    _ASSpecies.ForEach(c => { c.Parent = this; });
                }
                return _ASSpecies; 
            }
            set 
            {
                _ASSpecies = value;
            }
        }
        protected EditableList<AsSessionFarmSpeciesListItem> _ASSpecies = new EditableList<AsSessionFarmSpeciesListItem>();
                    
        private bool _ASSpeciesLoaded = false;
                    
        [Relation(typeof(AsSessionFarm), eidss.model.Schema.AsSessionFarm._str_idfMonitoringSession, _str_idfMonitoringSession)]
        public EditableList<AsSessionFarm> ASFarms
        {
            get 
            {   
                return _ASFarms; 
            }
            set 
            {
                _ASFarms = value;
            }
        }
        protected EditableList<AsSessionFarm> _ASFarms = new EditableList<AsSessionFarm>();
                    
        [Relation(typeof(AsSessionSample), eidss.model.Schema.AsSessionSample._str_idfMonitoringSession, _str_idfMonitoringSession)]
        public EditableList<AsSessionSample> ASSamples
        {
            get 
            {   
                if (!_ASSamplesLoaded)
                {
                    _ASSamplesLoaded = true;
                    _getAccessor()._LoadASSamples(this);
                    _ASSamples.ForEach(c => { c.Parent = this; });
                }
                return _ASSamples; 
            }
            set 
            {
                _ASSamples = value;
            }
        }
        protected EditableList<AsSessionSample> _ASSamples = new EditableList<AsSessionSample>();
                    
        private bool _ASSamplesLoaded = false;
                    
        [Relation(typeof(AsSessionCase), "", _str_idfMonitoringSession)]
        public EditableList<AsSessionCase> Cases
        {
            get 
            {   
                if (!_CasesLoaded)
                {
                    _CasesLoaded = true;
                    _getAccessor()._LoadCases(this);
                    _Cases.ForEach(c => { c.Parent = this; });
                }
                return _Cases; 
            }
            set 
            {
                _Cases = value;
            }
        }
        protected EditableList<AsSessionCase> _Cases = new EditableList<AsSessionCase>();
                    
        private bool _CasesLoaded = false;
                    
        [Relation(typeof(CaseTest), "", _str_idfMonitoringSession)]
        public EditableList<CaseTest> CaseTests
        {
            get 
            {   
                return _CaseTests; 
            }
            set 
            {
                _CaseTests = value;
            }
        }
        protected EditableList<CaseTest> _CaseTests = new EditableList<CaseTest>();
                    
        [Relation(typeof(CaseTestValidation), "", _str_idfMonitoringSession)]
        public EditableList<CaseTestValidation> CaseTestValidations
        {
            get 
            {   
                return _CaseTestValidations; 
            }
            set 
            {
                _CaseTestValidations = value;
            }
        }
        protected EditableList<CaseTestValidation> _CaseTestValidations = new EditableList<CaseTestValidation>();
                    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsMonitoringSessionStatus)]
        public BaseReference MonitoringSessionStatus
        {
            get { return _MonitoringSessionStatus; }
            set 
            { 
                _MonitoringSessionStatus = value;
                idfsMonitoringSessionStatus = _MonitoringSessionStatus == null 
                    ? new Int64?()
                    : _MonitoringSessionStatus.idfsBaseReference; 
                OnPropertyChanged(_str_MonitoringSessionStatus); 
            }
        }
        private BaseReference _MonitoringSessionStatus;

        
        public BaseReferenceList MonitoringSessionStatusLookup
        {
            get { return _MonitoringSessionStatusLookup; }
        }
        private BaseReferenceList _MonitoringSessionStatusLookup = new BaseReferenceList("rftMonitoringSessionStatus");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCampaignType)]
        public BaseReference CampaignType
        {
            get { return _CampaignType == null ? null : ((long)_CampaignType.Key == 0 ? null : _CampaignType); }
            set 
            { 
                _CampaignType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCampaignType = _CampaignType == null 
                    ? new Int64?()
                    : _CampaignType.idfsBaseReference; 
                OnPropertyChanged(_str_CampaignType); 
            }
        }
        private BaseReference _CampaignType;

        
        public BaseReferenceList CampaignTypeLookup
        {
            get { return _CampaignTypeLookup; }
        }
        private BaseReferenceList _CampaignTypeLookup = new BaseReferenceList("rftCampaignType");
            
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
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_MonitoringSessionStatus:
                    return new BvSelectList(MonitoringSessionStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, MonitoringSessionStatus, _str_idfsMonitoringSessionStatus);
            
                case _str_CampaignType:
                    return new BvSelectList(CampaignTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CampaignType, _str_idfsCampaignType);
            
                case _str_Country:
                    return new BvSelectList(CountryLookup, eidss.model.Schema.CountryLookup._str_idfsCountry, null, Country, _str_idfsCountry);
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionLookup._str_idfsRegion, null, Region, _str_idfsRegion);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonLookup._str_idfsRayon, null, Rayon, _str_idfsRayon);
            
                case _str_Settlement:
                    return new BvSelectList(SettlementLookup, eidss.model.Schema.SettlementLookup._str_idfsSettlement, null, Settlement, _str_idfsSettlement);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_buttonSearchCampaign)]
        public string buttonSearchCampaign
        {
            get { return new Func<AsSession, string>(c=>strCampaignID)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_buttonEditCampaign)]
        public string buttonEditCampaign
        {
            get { return new Func<AsSession, string>(c=>strCampaignID)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_buttonRemoveCampaign)]
        public string buttonRemoveCampaign
        {
            get { return new Func<AsSession, string>(c=>strCampaignID)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyCountry)]
        public string strReadOnlyCountry
        {
            get { return new Func<AsSession, string>(c=>(c.Country == null)?"" : Country.strCountryName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyEnteredDate)]
        public string strReadOnlyEnteredDate
        {
            get { return new Func<AsSession, string>(c => c.datEnteredDate == null ? (string)null : c.datEnteredDate.Value.ToString("d"))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strPersonEnteredBy)]
        public string strPersonEnteredBy
        {
            get { return new Func<AsSession, string>(c=>(c.EnteredByPerson==null) ? "" : c.EnteredByPerson.strFullName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_intTotalSampledAnimals)]
        public int intTotalSampledAnimals
        {
            get { return new Func<AsSession, int>(c=>c.SummaryItems.Where(x=>!x.IsMarkedToDelete).Sum(x=>x.intSampledAnimalsQty ?? 0))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_intTotalSamples)]
        public int intTotalSamples
        {
            get { return new Func<AsSession, int>(c=>c.SummaryItems.Where(x=>!x.IsMarkedToDelete).Sum(x=>x.intSamplesQty ?? 0))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_intTotalPositiveAnimals)]
        public int intTotalPositiveAnimals
        {
            get { return new Func<AsSession, int>(c=>c.SummaryItems.Where(x=>!x.IsMarkedToDelete).Sum(x=>x.intPositiveAnimalsQty ?? 0))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_intTotalDiagnosedAnimals)]
        public int intTotalDiagnosedAnimals
        {
            get { return new Func<AsSession, int>(c=>c.DetailsTableView.Where(x=>!x.IsMarkedToDelete).Where(x=>x.idfAnimal.HasValue).Select(x=>x.idfAnimal).Distinct().Count())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_intTotalSamplesInDetails)]
        public int intTotalSamplesInDetails
        {
            get { return new Func<AsSession, int>(c=>c.ASSamples.Where(x=>!x.IsMarkedToDelete).Count())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_intTotalCases)]
        public int intTotalCases
        {
            get { return new Func<AsSession, int>(c => (c.Cases == null) ? 0 : c.Cases.Count())(this); }
            
        }
        
          [LocalizedDisplayName(_str__blnAllowCampaignReload)]
        public bool _blnAllowCampaignReload
        {
            get { return m__blnAllowCampaignReload; }
            set { if (m__blnAllowCampaignReload != value) { m__blnAllowCampaignReload = value; OnPropertyChanged(_str__blnAllowCampaignReload); } }
        }
        private bool m__blnAllowCampaignReload;
        
          [LocalizedDisplayName(_str__blnReloadSummaryFigures)]
        public bool _blnReloadSummaryFigures
        {
            get { return m__blnReloadSummaryFigures; }
            set { if (m__blnReloadSummaryFigures != value) { m__blnReloadSummaryFigures = value; OnPropertyChanged(_str__blnReloadSummaryFigures); } }
        }
        private bool m__blnReloadSummaryFigures;
        
          [LocalizedDisplayName(_str_blnForceCampaignAssignment)]
        public bool blnForceCampaignAssignment
        {
            get { return m_blnForceCampaignAssignment; }
            set { if (m_blnForceCampaignAssignment != value) { m_blnForceCampaignAssignment = value; OnPropertyChanged(_str_blnForceCampaignAssignment); } }
        }
        private bool m_blnForceCampaignAssignment;
        
          [LocalizedDisplayName(_str__idfFarmForCaseCreation)]
        public long? _idfFarmForCaseCreation
        {
            get { return m__idfFarmForCaseCreation; }
            set { if (m__idfFarmForCaseCreation != value) { m__idfFarmForCaseCreation = value; OnPropertyChanged(_str__idfFarmForCaseCreation); } }
        }
        private long? m__idfFarmForCaseCreation;
        
          [LocalizedDisplayName(_str__strCreatedCases)]
        public string _strCreatedCases
        {
            get { return m__strCreatedCases; }
            set { if (m__strCreatedCases != value) { m__strCreatedCases = value; OnPropertyChanged(_str__strCreatedCases); } }
        }
        private string m__strCreatedCases;
        
          [LocalizedDisplayName(_str_CampaignInRamOnly)]
        public AsCampaign CampaignInRamOnly
        {
            get { return m_CampaignInRamOnly; }
            set { if (m_CampaignInRamOnly != value) { m_CampaignInRamOnly = value; OnPropertyChanged(_str_CampaignInRamOnly); } }
        }
        private AsCampaign m_CampaignInRamOnly;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AsSession";

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
        
            if (_EnteredByPerson != null) { _EnteredByPerson.Parent = this; }
                Diseases.ForEach(c => { c.Parent = this; });
                Actions.ForEach(c => { c.Parent = this; });
                SummaryItems.ForEach(c => { c.Parent = this; });
                DetailsTableView.ForEach(c => { c.Parent = this; });
                ASAnimals.ForEach(c => { c.Parent = this; });
                ASSpecies.ForEach(c => { c.Parent = this; });
                ASFarms.ForEach(c => { c.Parent = this; });
                ASSamples.ForEach(c => { c.Parent = this; });
                Cases.ForEach(c => { c.Parent = this; });
                CaseTests.ForEach(c => { c.Parent = this; });
                CaseTestValidations.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as AsSession;
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
            var ret = base.Clone() as AsSession;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_EnteredByPerson != null)
              ret.EnteredByPerson = _EnteredByPerson.CloneWithSetup(manager) as Personnel;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AsSession CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsSession;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfMonitoringSession; } }
        public string KeyName { get { return "idfMonitoringSession"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || (_EnteredByPerson != null && _EnteredByPerson.HasChanges)
                
                    || Diseases.IsDirty
                    || Diseases.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Actions.IsDirty
                    || Actions.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || SummaryItems.IsDirty
                    || SummaryItems.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || DetailsTableView.IsDirty
                    || DetailsTableView.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || ASAnimals.IsDirty
                    || ASAnimals.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || ASSpecies.IsDirty
                    || ASSpecies.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || ASFarms.IsDirty
                    || ASFarms.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || ASSamples.IsDirty
                    || ASSamples.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Cases.IsDirty
                    || Cases.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || CaseTests.IsDirty
                    || CaseTests.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || CaseTestValidations.IsDirty
                    || CaseTestValidations.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsMonitoringSessionStatus_MonitoringSessionStatus = idfsMonitoringSessionStatus;
            var _prev_idfsCampaignType_CampaignType = idfsCampaignType;
            var _prev_idfsCountry_Country = idfsCountry;
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            var _prev_idfsSettlement_Settlement = idfsSettlement;
            base.RejectChanges();
        
            if (_prev_idfsMonitoringSessionStatus_MonitoringSessionStatus != idfsMonitoringSessionStatus)
            {
                _MonitoringSessionStatus = _MonitoringSessionStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsMonitoringSessionStatus);
            }
            if (_prev_idfsCampaignType_CampaignType != idfsCampaignType)
            {
                _CampaignType = _CampaignTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCampaignType);
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
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (EnteredByPerson != null) EnteredByPerson.RejectChanges();
                Diseases.RejectChanges();
                Actions.RejectChanges();
                SummaryItems.RejectChanges();
                DetailsTableView.RejectChanges();
                ASAnimals.RejectChanges();
                ASSpecies.RejectChanges();
                ASFarms.RejectChanges();
                ASSamples.RejectChanges();
                Cases.RejectChanges();
                CaseTests.RejectChanges();
                CaseTestValidations.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_EnteredByPerson != null) _EnteredByPerson.AcceptChanges();
                Diseases.AcceptChanges();
                Actions.AcceptChanges();
                SummaryItems.AcceptChanges();
                DetailsTableView.AcceptChanges();
                ASAnimals.AcceptChanges();
                ASSpecies.AcceptChanges();
                ASFarms.AcceptChanges();
                ASSamples.AcceptChanges();
                Cases.AcceptChanges();
                CaseTests.AcceptChanges();
                CaseTestValidations.AcceptChanges();
                
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
        
            if (_EnteredByPerson != null) _EnteredByPerson.SetChange();
                Diseases.ForEach(c => c.SetChange());
                Actions.ForEach(c => c.SetChange());
                SummaryItems.ForEach(c => c.SetChange());
                DetailsTableView.ForEach(c => c.SetChange());
                ASAnimals.ForEach(c => c.SetChange());
                ASSpecies.ForEach(c => c.SetChange());
                ASFarms.ForEach(c => c.SetChange());
                ASSamples.ForEach(c => c.SetChange());
                Cases.ForEach(c => c.SetChange());
                CaseTests.ForEach(c => c.SetChange());
                CaseTestValidations.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, AsSession c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public AsSession()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsSession_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsSession_PropertyChanged);
        }
        private void AsSession_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsSession).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_strCampaignID)
                OnPropertyChanged(_str_buttonSearchCampaign);
                  
            if (e.PropertyName == _str_strCampaignID)
                OnPropertyChanged(_str_buttonEditCampaign);
                  
            if (e.PropertyName == _str_strCampaignID)
                OnPropertyChanged(_str_buttonRemoveCampaign);
                  
            if (e.PropertyName == _str_idfsCountry)
                OnPropertyChanged(_str_strReadOnlyCountry);
                  
            if (e.PropertyName == _str_datEnteredDate)
                OnPropertyChanged(_str_strReadOnlyEnteredDate);
                  
            if (e.PropertyName == _str_idfPersonEnteredBy)
                OnPropertyChanged(_str_strPersonEnteredBy);
                  
            if (e.PropertyName == _str_SummaryItems)
                OnPropertyChanged(_str_intTotalSampledAnimals);
                  
            if (e.PropertyName == _str_SummaryItems)
                OnPropertyChanged(_str_intTotalSamples);
                  
            if (e.PropertyName == _str_SummaryItems)
                OnPropertyChanged(_str_intTotalPositiveAnimals);
                  
            if (e.PropertyName == _str_ASAnimals)
                OnPropertyChanged(_str_intTotalDiagnosedAnimals);
                  
            if (e.PropertyName == _str_ASSamples)
                OnPropertyChanged(_str_intTotalSamplesInDetails);
                  
            if (e.PropertyName == _str_Cases)
                OnPropertyChanged(_str_intTotalCases);
                  
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
            AsSession obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsSession obj = this;
            
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

    
        private static string[] readonly_names1 = "strReadOnlyEnteredDate".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "intTotalCases".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "intTotalDiagnosedAnimals,intTotalSamplesInDetails,intTotalPositiveAnimals,intTotalSamples,intTotalSampledAnimals,strMonitoringSessionID,idfPersonEnteredBy,idfsSite,strPersonEnteredBy,idfsCampaignType,CampaignType,strCampaignName,strCampaignID,datEnteredDate".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "idfsMonitoringSessionStatus,MonitoringSessionStatus".Split(new char[] { ',' });
        
        private static string[] readonly_names5 = "buttonSearchCampaign,buttonEditCampaign,buttonRemoveCampaign".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSession, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSession, bool>(c => true)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSession, bool>(c=>true)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSession, bool>(c => false)(this);
            
            if (readonly_names5.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSession, bool>(c=>c.idfsMonitoringSessionStatus == (long)AsSessionStatus.Closed)(this);
            
            return ReadOnly || new Func<AsSession, bool>(c=>c.idfsMonitoringSessionStatus == (long)AsSessionStatus.Closed)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_EnteredByPerson != null)
                    _EnteredByPerson.ReadOnly = value;
                
                foreach(var o in _Diseases)
                    o.ReadOnly = value;
                
                foreach(var o in _Actions)
                    o.ReadOnly = value;
                
                foreach(var o in _SummaryItems)
                    o.ReadOnly = value;
                
                foreach(var o in _DetailsTableView)
                    o.ReadOnly = value;
                
                foreach(var o in _ASAnimals)
                    o.ReadOnly = value;
                
                foreach(var o in _ASSpecies)
                    o.ReadOnly = value;
                
                foreach(var o in _ASFarms)
                    o.ReadOnly = value;
                
                foreach(var o in _ASSamples)
                    o.ReadOnly = value;
                
                foreach(var o in _Cases)
                    o.ReadOnly = value;
                
                foreach(var o in _CaseTests)
                    o.ReadOnly = value;
                
                foreach(var o in _CaseTestValidations)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<AsSession, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsSession, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsSession, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<AsSession, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsSession, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<AsSession, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AsSession()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftMonitoringSessionStatus", this);
                
                LookupManager.RemoveObject("rftCampaignType", this);
                
                LookupManager.RemoveObject("CountryLookup", this);
                
                LookupManager.RemoveObject("RegionLookup", this);
                
                LookupManager.RemoveObject("RayonLookup", this);
                
                LookupManager.RemoveObject("SettlementLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftMonitoringSessionStatus")
                _getAccessor().LoadLookup_MonitoringSessionStatus(manager, this);
            
            if (lookup_object == "rftCampaignType")
                _getAccessor().LoadLookup_CampaignType(manager, this);
            
            if (lookup_object == "CountryLookup")
                _getAccessor().LoadLookup_Country(manager, this);
            
            if (lookup_object == "RegionLookup")
                _getAccessor().LoadLookup_Region(manager, this);
            
            if (lookup_object == "RayonLookup")
                _getAccessor().LoadLookup_Rayon(manager, this);
            
            if (lookup_object == "SettlementLookup")
                _getAccessor().LoadLookup_Settlement(manager, this);
            
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
        
            if (_EnteredByPerson != null) _EnteredByPerson.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_Diseases != null) _Diseases.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Actions != null) _Actions.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_SummaryItems != null) _SummaryItems.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_DetailsTableView != null) _DetailsTableView.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_ASAnimals != null) _ASAnimals.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_ASSpecies != null) _ASSpecies.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_ASFarms != null) _ASFarms.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_ASSamples != null) _ASSamples.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Cases != null) _Cases.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_CaseTests != null) _CaseTests.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_CaseTestValidations != null) _CaseTestValidations.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<AsSession>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(AsSession obj);
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
            private Personnel.Accessor EnteredByPersonAccessor { get { return eidss.model.Schema.Personnel.Accessor.Instance(m_CS); } }
            private AsSessionDisease.Accessor DiseasesAccessor { get { return eidss.model.Schema.AsSessionDisease.Accessor.Instance(m_CS); } }
            private AsSessionAction.Accessor ActionsAccessor { get { return eidss.model.Schema.AsSessionAction.Accessor.Instance(m_CS); } }
            private AsSessionSummary.Accessor SummaryItemsAccessor { get { return eidss.model.Schema.AsSessionSummary.Accessor.Instance(m_CS); } }
            private AsSessionTableViewItem.Accessor DetailsTableViewAccessor { get { return eidss.model.Schema.AsSessionTableViewItem.Accessor.Instance(m_CS); } }
            private AsSessionAnimal.Accessor ASAnimalsAccessor { get { return eidss.model.Schema.AsSessionAnimal.Accessor.Instance(m_CS); } }
            private AsSessionFarmSpeciesListItem.Accessor ASSpeciesAccessor { get { return eidss.model.Schema.AsSessionFarmSpeciesListItem.Accessor.Instance(m_CS); } }
            private AsSessionFarm.Accessor ASFarmsAccessor { get { return eidss.model.Schema.AsSessionFarm.Accessor.Instance(m_CS); } }
            private AsSessionSample.Accessor ASSamplesAccessor { get { return eidss.model.Schema.AsSessionSample.Accessor.Instance(m_CS); } }
            private AsSessionCase.Accessor CasesAccessor { get { return eidss.model.Schema.AsSessionCase.Accessor.Instance(m_CS); } }
            private CaseTest.Accessor CaseTestsAccessor { get { return eidss.model.Schema.CaseTest.Accessor.Instance(m_CS); } }
            private CaseTestValidation.Accessor CaseTestValidationsAccessor { get { return eidss.model.Schema.CaseTestValidation.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor MonitoringSessionStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CampaignTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private CountryLookup.Accessor CountryAccessor { get { return eidss.model.Schema.CountryLookup.Accessor.Instance(m_CS); } }
            private RegionLookup.Accessor RegionAccessor { get { return eidss.model.Schema.RegionLookup.Accessor.Instance(m_CS); } }
            private RayonLookup.Accessor RayonAccessor { get { return eidss.model.Schema.RayonLookup.Accessor.Instance(m_CS); } }
            private SettlementLookup.Accessor SettlementAccessor { get { return eidss.model.Schema.SettlementLookup.Accessor.Instance(m_CS); } }
            

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

            
            public virtual AsSession SelectByKey(DbManagerProxy manager
                , Int64? idfMonitoringSession
                )
            {
                return _SelectByKey(manager
                    , idfMonitoringSession
                    , null, null
                    );
            }
            
      
            private AsSession _SelectByKey(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[3];
                List<AsSession> objs = new List<AsSession>();
                sets[0] = new MapResultSet(typeof(AsSession), objs);
                
                List<AsSessionDisease> objs_AsSessionDisease = new List<AsSessionDisease>();
                sets[1] = new MapResultSet(typeof(AsSessionDisease), objs_AsSessionDisease);
                
                List<AsSessionFarm> objs_AsSessionFarm = new List<AsSessionFarm>();
                sets[2] = new MapResultSet(typeof(AsSessionFarm), objs_AsSessionFarm);
                
        
                try
                {
                    manager
                        .SetSpCommand("spASSession_SelectDetail"
                            , manager.Parameter("@idfMonitoringSession", idfMonitoringSession)
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    AsSession obj = objs[0];
                    obj.m_CS = m_CS;
                    
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    
                    obj.Diseases.ForEach(c => DiseasesAccessor._SetupLoad(manager, c));
                        
                    obj.ASFarms.ForEach(c => ASFarmsAccessor._SetupLoad(manager, c));
                        
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
    
            private void _SetupAddChildHandlerDiseases(AsSession obj)
            {
                obj.Diseases.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerActions(AsSession obj)
            {
                obj.Actions.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerSummaryItems(AsSession obj)
            {
                obj.SummaryItems.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerDetailsTableView(AsSession obj)
            {
                obj.DetailsTableView.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerASAnimals(AsSession obj)
            {
                obj.ASAnimals.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerASSpecies(AsSession obj)
            {
                obj.ASSpecies.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerASFarms(AsSession obj)
            {
                obj.ASFarms.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerASSamples(AsSession obj)
            {
                obj.ASSamples.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerCases(AsSession obj)
            {
                obj.Cases.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerCaseTests(AsSession obj)
            {
                obj.CaseTests.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerCaseTestValidations(AsSession obj)
            {
                obj.CaseTestValidations.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadEnteredByPerson(AsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadEnteredByPerson(manager, obj);
                }
            }
            internal void _LoadEnteredByPerson(DbManagerProxy manager, AsSession obj)
            {
                
                if (obj.EnteredByPerson == null && obj.idfPersonEnteredBy != null && obj.idfPersonEnteredBy != 0)
                {
                    obj.EnteredByPerson = EnteredByPersonAccessor.SelectByKey(manager
                        
                        , obj.idfPersonEnteredBy.Value
                        );
                    if (obj.EnteredByPerson != null)
                    {
                        obj.EnteredByPerson.m_ObjectName = _str_EnteredByPerson;
                    }
                }
                    
            }
            
            internal void _LoadActions(AsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadActions(manager, obj);
                }
            }
            internal void _LoadActions(DbManagerProxy manager, AsSession obj)
            {
                
                obj.Actions.Clear();
                obj.Actions.AddRange(ActionsAccessor.SelectDetailList(manager
                    
                    , obj.idfMonitoringSession
                    ));
                obj.Actions.ForEach(c => c.m_ObjectName = _str_Actions);
                obj.Actions.AcceptChanges();
                    
            }
            
            internal void _LoadSummaryItems(AsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSummaryItems(manager, obj);
                }
            }
            internal void _LoadSummaryItems(DbManagerProxy manager, AsSession obj)
            {
                
                obj.SummaryItems.Clear();
                obj.SummaryItems.AddRange(SummaryItemsAccessor.SelectDetailList(manager
                    
                    , obj.idfMonitoringSession
                    ));
                obj.SummaryItems.ForEach(c => c.m_ObjectName = _str_SummaryItems);
                obj.SummaryItems.AcceptChanges();
                    
            }
            
            internal void _LoadDetailsTableView(AsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadDetailsTableView(manager, obj);
                }
            }
            internal void _LoadDetailsTableView(DbManagerProxy manager, AsSession obj)
            {
                
                obj.DetailsTableView.Clear();
                obj.DetailsTableView.AddRange(DetailsTableViewAccessor.SelectDetailList(manager
                    
                    , obj.idfMonitoringSession
                    ));
                obj.DetailsTableView.ForEach(c => c.m_ObjectName = _str_DetailsTableView);
                obj.DetailsTableView.AcceptChanges();
                    
            }
            
            internal void _LoadASAnimals(AsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadASAnimals(manager, obj);
                }
            }
            internal void _LoadASAnimals(DbManagerProxy manager, AsSession obj)
            {
                
                obj.ASAnimals.Clear();
                obj.ASAnimals.AddRange(ASAnimalsAccessor.SelectDetailList(manager
                    
                    , obj.idfMonitoringSession
                    ));
                obj.ASAnimals.ForEach(c => c.m_ObjectName = _str_ASAnimals);
                obj.ASAnimals.AcceptChanges();
                    
            }
            
            internal void _LoadASSpecies(AsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadASSpecies(manager, obj);
                }
            }
            internal void _LoadASSpecies(DbManagerProxy manager, AsSession obj)
            {
                
                obj.ASSpecies.Clear();
                obj.ASSpecies.AddRange(ASSpeciesAccessor.SelectDetailList(manager
                    
                    , obj.idfMonitoringSession
                    ));
                obj.ASSpecies.ForEach(c => c.m_ObjectName = _str_ASSpecies);
                obj.ASSpecies.AcceptChanges();
                    
            }
            
            internal void _LoadASSamples(AsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadASSamples(manager, obj);
                }
            }
            internal void _LoadASSamples(DbManagerProxy manager, AsSession obj)
            {
                
                obj.ASSamples.Clear();
                obj.ASSamples.AddRange(ASSamplesAccessor.SelectDetailList(manager
                    
                    , obj.idfMonitoringSession
                    ));
                obj.ASSamples.ForEach(c => c.m_ObjectName = _str_ASSamples);
                obj.ASSamples.AcceptChanges();
                    
            }
            
            internal void _LoadCases(AsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadCases(manager, obj);
                }
            }
            internal void _LoadCases(DbManagerProxy manager, AsSession obj)
            {
                
                obj.Cases.Clear();
                obj.Cases.AddRange(CasesAccessor.SelectDetailList(manager
                    
                    , obj.idfMonitoringSession
                    ));
                obj.Cases.ForEach(c => c.m_ObjectName = _str_Cases);
                obj.Cases.AcceptChanges();
                    
            }
            
            internal void _LoadCaseTests(AsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadCaseTests(manager, obj);
                }
            }
            internal void _LoadCaseTests(DbManagerProxy manager, AsSession obj)
            {
                
                obj.CaseTests.Clear();
                obj.CaseTests.AddRange(CaseTestsAccessor.SelectDetailList(manager
                    
                    , obj.idfMonitoringSession
                    ));
                obj.CaseTests.ForEach(c => c.m_ObjectName = _str_CaseTests);
                obj.CaseTests.AcceptChanges();
                    
            }
            
            internal void _LoadCaseTestValidations(AsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadCaseTestValidations(manager, obj);
                }
            }
            internal void _LoadCaseTestValidations(DbManagerProxy manager, AsSession obj)
            {
                
                obj.CaseTestValidations.Clear();
                obj.CaseTestValidations.AddRange(CaseTestValidationsAccessor.SelectDetailList(manager
                    
                    , obj.idfMonitoringSession
                    ));
                obj.CaseTestValidations.ForEach(c => c.m_ObjectName = _str_CaseTestValidations);
                obj.CaseTestValidations.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsSession obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadActions(manager, obj);
                _LoadASAnimals(manager, obj);
                _LoadCaseTests(manager, obj);
                _LoadCaseTestValidations(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.CaseTests.ForEach(t => { t.idfTesting = new Func<AsSession, long>(c => { (t.GetAccessor() as CaseTest.Accessor).LoadLookup_TestTypeRef(manager, t); return t.idfTesting; })(obj); } );
                obj.DetailsTableView.ForEach(t => { t.CaseTests = new Func<AsSession, EditableList<CaseTest>>(c => c.CaseTests)(obj); } );
              obj.DetailsTableView.ForEach(x => x.ASFarms = obj.ASFarms);
              obj.DetailsTableView.ForEach(x => x.ASSpecies = obj.ASSpecies);
              obj.DetailsTableView.ForEach(x => x.ASAnimals = obj.ASAnimals);
              obj.DetailsTableView.ForEach(x => x.ASSamples = obj.ASSamples);
              obj.SummaryItems.ForEach(x => x.ASFarms = obj.ASFarms);

            
                obj._blnAllowCampaignReload = true;
                obj._strCreatedCases = NO_CASES_CREATED;
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerDiseases(obj);
                
                _SetupAddChildHandlerActions(obj);
                
                _SetupAddChildHandlerSummaryItems(obj);
                
                _SetupAddChildHandlerDetailsTableView(obj);
                
                _SetupAddChildHandlerASAnimals(obj);
                
                _SetupAddChildHandlerASSpecies(obj);
                
                _SetupAddChildHandlerASFarms(obj);
                
                _SetupAddChildHandlerASSamples(obj);
                
                _SetupAddChildHandlerCases(obj);
                
                _SetupAddChildHandlerCaseTests(obj);
                
                _SetupAddChildHandlerCaseTestValidations(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, AsSession obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    EnteredByPersonAccessor._SetPermitions(obj._permissions, obj.EnteredByPerson);
                    
                        obj.Diseases.ForEach(c => DiseasesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Actions.ForEach(c => ActionsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.SummaryItems.ForEach(c => SummaryItemsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.DetailsTableView.ForEach(c => DetailsTableViewAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.ASAnimals.ForEach(c => ASAnimalsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.ASSpecies.ForEach(c => ASSpeciesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.ASFarms.ForEach(c => ASFarmsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.ASSamples.ForEach(c => ASSamplesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Cases.ForEach(c => CasesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.CaseTests.ForEach(c => CaseTestsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.CaseTestValidations.ForEach(c => CaseTestValidationsAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private AsSession _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    AsSession obj = AsSession.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfMonitoringSession = (new GetNewIDExtender<AsSession>()).GetScalar(manager, obj);
                obj.strMonitoringSessionID = new Func<AsSession, string>(c=>"(new session)")(obj);
                obj.idfsSite = (new GetSiteIDExtender<AsSession>()).GetScalar(manager, obj);
                obj._blnAllowCampaignReload = true;
                obj.datEnteredDate = DateTime.Today;
              if (EidssUserContext.Instance != null)
              if (EidssUserContext.User != null)
              {
              if (EidssUserContext.User.EmployeeID != null)
              {
              long em;
              if (long.TryParse(EidssUserContext.User.EmployeeID.ToString(), out em))
              {
              obj.idfPersonEnteredBy = em;
              _LoadEnteredByPerson(obj);
              }            
              }
              }

            
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerDiseases(obj);
                    
                    _SetupAddChildHandlerActions(obj);
                    
                    _SetupAddChildHandlerSummaryItems(obj);
                    
                    _SetupAddChildHandlerDetailsTableView(obj);
                    
                    _SetupAddChildHandlerASAnimals(obj);
                    
                    _SetupAddChildHandlerASSpecies(obj);
                    
                    _SetupAddChildHandlerASFarms(obj);
                    
                    _SetupAddChildHandlerASSamples(obj);
                    
                    _SetupAddChildHandlerCases(obj);
                    
                    _SetupAddChildHandlerCaseTests(obj);
                    
                    _SetupAddChildHandlerCaseTestValidations(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.Country = new Func<AsSession, CountryLookup>(c => 
                                     c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
                                     .SingleOrDefault())(obj);
                obj.MonitoringSessionStatus = (new SelectLookupExtender<BaseReference>()).Select(obj.MonitoringSessionStatusLookup, c => c.idfsBaseReference == (long)AsSessionStatus.Open);
                obj._strCreatedCases = NO_CASES_CREATED;
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

            
            public AsSession CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public AsSession CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult CreateCase(DbManagerProxy manager, AsSession obj, List<object> pars)
            {
                
                return CreateCase(manager, obj
                    );
            }
            public ActResult CreateCase(DbManagerProxy manager, AsSession obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("CreateCase"))
                    throw new PermissionException("MonitoringSession", "CreateCase");
                
                return true;
                
            }
            
            public ActResult ReportAsSampleCollectedList(DbManagerProxy manager, AsSession obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("id", typeof(long));
                
                return ReportAsSampleCollectedList(manager, obj
                    , (long)pars[0]
                    );
            }
            public ActResult ReportAsSampleCollectedList(DbManagerProxy manager, AsSession obj
                , long id
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ReportAsSampleCollectedList"))
                    throw new PermissionException("MonitoringSession", "ReportAsSampleCollectedList");
                
                return true;
                
            }
            
            public ActResult ReportAsSessionTests(DbManagerProxy manager, AsSession obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("id", typeof(long));
                
                return ReportAsSessionTests(manager, obj
                    , (long)pars[0]
                    );
            }
            public ActResult ReportAsSessionTests(DbManagerProxy manager, AsSession obj
                , long id
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ReportAsSessionTests"))
                    throw new PermissionException("MonitoringSession", "ReportAsSessionTests");
                
                return true;
                
            }
            
            private void _SetupChildHandlers(AsSession obj, object newobj)
            {
                
                foreach(var o in obj.ASSamples.Where(c => !c.IsMarkedToDelete))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "datFieldCollectionDate")
                                {
                                
                (new PredicateValidator("AsSession.SummaryItem.datCollectionDate_msgId", "datFieldCollectionDate", "ASSamples", "datFieldCollectionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => ASSamplesIsValid(c,i)
                    );
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datFieldCollectionDate");
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                }
                            
                foreach(var o in obj.SummaryItems.Where(c => !c.IsMarkedToDelete))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "datCompletionDate")
                                {
                                
                (new PredicateValidator("AsSession.SummaryItem.datCollectionDate_msgId", "datCompletionDate", "SummaryItems", "datCompletionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => NewSummaryItemIsValid(c,i)
                    );
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datCompletionDate");
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                }
                            
                foreach(var o in obj.DetailsTableView.Where(x=>true))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "IsMarkedToDelete")
                            {
                            
                if (o.Sample != null) o.Sample.MarkToDelete();
                obj.OnPropertyChanged(_str_ASSamples);
              
                            }
                        };
                        
                    }
                }
                            
            }
            
            private void _SetupHandlers(AsSession obj)
            {
                
                obj.ASSamples.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    if (e.ListChangedType == ListChangedType.ItemAdded)
                    {
                        try
                        {
                            var item = obj.ASSamples[e.NewIndex];
                      
                (new PredicateValidator("AsSession.SummaryItem.datCollectionDate_msgId", "ASSamples", "datFieldCollectionDate", "ASSamples",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => ASSamplesIsValid(c,i)
                    );
            
                        }
                        catch (ValidationModelException ex)
                        {
                            if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                            {
                                obj.ASSamples.RemoveAt(e.NewIndex);
                                obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                            }
                        }
                    }
                };
                    
                obj.SummaryItems.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    if (e.ListChangedType == ListChangedType.ItemAdded)
                    {
                        try
                        {
                            var item = obj.SummaryItems[e.NewIndex];
                      
                (new PredicateValidator("AsSession.SummaryItem.datCollectionDate_msgId", "SummaryItems", "datCompletionDate", "SummaryItems",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => NewSummaryItemIsValid(c,i)
                    );
            
                        }
                        catch (ValidationModelException ex)
                        {
                            if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                            {
                                obj.SummaryItems.RemoveAt(e.NewIndex);
                                obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                            }
                        }
                    }
                };
                    
                obj.DetailsTableView.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    if (e.ListChangedType == ListChangedType.ItemAdded)
                    {
                        try
                        {
                            var item = obj.DetailsTableView[e.NewIndex];
                      
                (new PredicateValidator("", "DetailsTableView", "DetailsTableView", "DetailsTableView",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => NewTableItemIsValid(c,i)
                    );
            
                        }
                        catch (ValidationModelException ex)
                        {
                            if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                            {
                                obj.DetailsTableView.RemoveAt(e.NewIndex);
                                obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                            }
                        }
                    }
                };
                    
                obj.Diseases.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    if (e.ListChangedType == ListChangedType.ItemAdded)
                    {
                        try
                        {
                            var item = obj.Diseases[e.NewIndex];
                      
                (new PredicateValidator("", "Diseases", "Diseases", "Diseases",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => NewDiseaseValidation(c,i)
                    );
            
                        }
                        catch (ValidationModelException ex)
                        {
                            if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                            {
                                obj.Diseases.RemoveAt(e.NewIndex);
                                obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                            }
                        }
                    }
                };
                    
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfCampaign)
                        {
                            try
                            {
                            
                (new PredicateValidator("AsSession_WrongCampaignAssignment", "idfCampaign", "idfCampaign", "idfCampaign",
              new object[] {
              },
                        false
                    )).Validate(obj, c=>c.CopyCampaignData()
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_idfCampaign);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str__strCreatedCases)
                        {
                            try
                            {
                            
                (new PredicateValidator("", "_strCreatedCases", "_strCreatedCases", "_strCreatedCases",
              new object[] {
              },
                        false
                    )).Validate(obj, c=>c.ValidationMessageForCases()
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str__strCreatedCases);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datStartDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("datSessionStartDate_datSessionEndDate_msgId", "datStartDate", "datStartDate", "datStartDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datStartDate, c.datEndDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datStartDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datEndDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("datSessionStartDate_datSessionEndDate_msgId", "datEndDate", "datEndDate", "datEndDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datStartDate, c.datEndDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datEndDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
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
                    
                        if (e.PropertyName == _str_blnForceCampaignAssignment)
                        {
                    
              obj.CopyCampaignData();
            
                        }
                    
                    };
                
            }
    
            public void LoadLookup_MonitoringSessionStatus(DbManagerProxy manager, AsSession obj)
            {
                
                obj.MonitoringSessionStatusLookup.Clear();
                
                obj.MonitoringSessionStatusLookup.AddRange(MonitoringSessionStatusAccessor.rftMonitoringSessionStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsMonitoringSessionStatus))
                    
                    .ToList());
                
                if (obj.idfsMonitoringSessionStatus != null && obj.idfsMonitoringSessionStatus != 0)
                {
                    obj.MonitoringSessionStatus = obj.MonitoringSessionStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsMonitoringSessionStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftMonitoringSessionStatus", obj, MonitoringSessionStatusAccessor.GetType(), "rftMonitoringSessionStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_CampaignType(DbManagerProxy manager, AsSession obj)
            {
                
                obj.CampaignTypeLookup.Clear();
                
                obj.CampaignTypeLookup.Add(CampaignTypeAccessor.CreateNewT(manager, null));
                
                obj.CampaignTypeLookup.AddRange(CampaignTypeAccessor.rftCampaignType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCampaignType))
                    
                    .ToList());
                
                if (obj.idfsCampaignType != null && obj.idfsCampaignType != 0)
                {
                    obj.CampaignType = obj.CampaignTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsCampaignType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCampaignType", obj, CampaignTypeAccessor.GetType(), "rftCampaignType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Country(DbManagerProxy manager, AsSession obj)
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
            
            public void LoadLookup_Region(DbManagerProxy manager, AsSession obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<AsSession, long>(c => c.idfsCountry ?? 0)(obj)
                            
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
            
            public void LoadLookup_Rayon(DbManagerProxy manager, AsSession obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<AsSession, long>(c => c.idfsRegion ?? 0)(obj)
                            
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
            
            public void LoadLookup_Settlement(DbManagerProxy manager, AsSession obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<AsSession, long>(c => c.idfsRayon ?? 0)(obj)
                            
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
            

            private void _LoadLookups(DbManagerProxy manager, AsSession obj)
            {
                
                LoadLookup_MonitoringSessionStatus(manager, obj);
                
                LoadLookup_CampaignType(manager, obj);
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
            }
    
            [SprocName("spASSession_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spASSession_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfMonitoringSession", "strMonitoringSessionID")] AsSession obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfMonitoringSession", "strMonitoringSessionID")] AsSession obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AsSession bo = obj as AsSession;
                    
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
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfMonitoringSession;
                        
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
                    bSuccess = _PostNonTransaction(manager, obj as AsSession, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsSession obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                                        
                    _postPredicate(manager, 8, obj);
                                            
                    if (obj.Diseases != null)
                    {
                        foreach (var i in obj.Diseases)
                        {
                            i.MarkToDelete();
                            if (!DiseasesAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            
                    if (obj.ASFarms != null)
                    {
                        foreach (var i in obj.ASFarms)
                        {
                            i.MarkToDelete();
                            if (!ASFarmsAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            
                    if (obj.Actions != null)
                    {
                        foreach (var i in obj.Actions)
                        {
                            i.MarkToDelete();
                            if (!ActionsAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            
                    if (obj.SummaryItems != null)
                    {
                        foreach (var i in obj.SummaryItems)
                        {
                            i.MarkToDelete();
                            if (!SummaryItemsAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            
                    if (obj.DetailsTableView != null)
                    {
                        foreach (var i in obj.DetailsTableView)
                        {
                            i.MarkToDelete();
                            if (!DetailsTableViewAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            
                    if (obj.CaseTests != null)
                    {
                        foreach (var i in obj.CaseTests)
                        {
                            i.MarkToDelete();
                            if (!CaseTestsAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            
                    if (obj.CaseTestValidations != null)
                    {
                        foreach (var i in obj.CaseTestValidations)
                        {
                            i.MarkToDelete();
                            if (!CaseTestValidationsAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                obj._blnAllowCampaignReload = false;
                obj._strCreatedCases = NO_CASES_CREATED;
                obj.strMonitoringSessionID = new Func<AsSession, DbManagerProxy, string>((c,m) => 
                        c.strMonitoringSessionID != "(new session)" 
                        ? c.strMonitoringSessionID 
                        : m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.ASSession, DBNull.Value, DBNull.Value)                        
                        .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue"))(obj, manager);
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                                    
                    if (obj.IsNew)
                    {
                        if (obj.Diseases != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Diseases)
                                if (!DiseasesAccessor.Post(manager, i, true))
                                    return false;
                            obj.Diseases.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Diseases.Remove(c));
                            obj.Diseases.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Diseases != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Diseases)
                                if (!DiseasesAccessor.Post(manager, i, true))
                                    return false;
                            obj._Diseases.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Diseases.Remove(c));
                            obj._Diseases.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.ASFarms != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.ASFarms)
                                if (!ASFarmsAccessor.Post(manager, i, true))
                                    return false;
                            obj.ASFarms.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.ASFarms.Remove(c));
                            obj.ASFarms.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._ASFarms != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._ASFarms)
                                if (!ASFarmsAccessor.Post(manager, i, true))
                                    return false;
                            obj._ASFarms.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._ASFarms.Remove(c));
                            obj._ASFarms.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.Actions != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Actions)
                                if (!ActionsAccessor.Post(manager, i, true))
                                    return false;
                            obj.Actions.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Actions.Remove(c));
                            obj.Actions.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Actions != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Actions)
                                if (!ActionsAccessor.Post(manager, i, true))
                                    return false;
                            obj._Actions.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Actions.Remove(c));
                            obj._Actions.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.SummaryItems != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.SummaryItems)
                                if (!SummaryItemsAccessor.Post(manager, i, true))
                                    return false;
                            obj.SummaryItems.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.SummaryItems.Remove(c));
                            obj.SummaryItems.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._SummaryItems != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._SummaryItems)
                                if (!SummaryItemsAccessor.Post(manager, i, true))
                                    return false;
                            obj._SummaryItems.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._SummaryItems.Remove(c));
                            obj._SummaryItems.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.DetailsTableView != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.DetailsTableView)
                                if (!DetailsTableViewAccessor.Post(manager, i, true))
                                    return false;
                            obj.DetailsTableView.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.DetailsTableView.Remove(c));
                            obj.DetailsTableView.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._DetailsTableView != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._DetailsTableView)
                                if (!DetailsTableViewAccessor.Post(manager, i, true))
                                    return false;
                            obj._DetailsTableView.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._DetailsTableView.Remove(c));
                            obj._DetailsTableView.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.CaseTests != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.CaseTests)
                                if (!CaseTestsAccessor.Post(manager, i, true))
                                    return false;
                            obj.CaseTests.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.CaseTests.Remove(c));
                            obj.CaseTests.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._CaseTests != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._CaseTests)
                                if (!CaseTestsAccessor.Post(manager, i, true))
                                    return false;
                            obj._CaseTests.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._CaseTests.Remove(c));
                            obj._CaseTests.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.CaseTestValidations != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.CaseTestValidations)
                                if (!CaseTestValidationsAccessor.Post(manager, i, true))
                                    return false;
                            obj.CaseTestValidations.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.CaseTestValidations.Remove(c));
                            obj.CaseTestValidations.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._CaseTestValidations != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._CaseTestValidations)
                                if (!CaseTestValidationsAccessor.Post(manager, i, true))
                                    return false;
                            obj._CaseTestValidations.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._CaseTestValidations.Remove(c));
                            obj._CaseTestValidations.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
              if (obj.ASFarms.Count() > 0)
              {
              SaveFarms(manager, obj);
              }
              if (obj._idfFarmForCaseCreation.HasValue)
              {
              CreateCases(manager, obj);
              }
            
                obj._blnAllowCampaignReload = true;
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AsSession obj)
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
                return Validate(manager, obj as AsSession, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsSession obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "MonitoringSessionStatus", "MonitoringSessionStatus","idfsMonitoringSessionStatus",
                false
              )).Validate(c => true, obj, obj.MonitoringSessionStatus);
            
                (new RequiredValidator( "Region", "Region","idfsRegion",
                false
              )).Validate(c => true, obj, obj.Region);
            
            (new CustomMandatoryFieldValidator("datStartDate", "datStartDate", "",
            false
            )).Validate(obj, obj.datStartDate, CustomMandatoryField.ASSession_StartDate);

          
            (new CustomMandatoryFieldValidator("datEndDate", "datEndDate", "",
            false
            )).Validate(obj, obj.datEndDate, CustomMandatoryField.ASSession_EndDate);

          
            (new CustomMandatoryFieldValidator("Rayon", "Rayon", "",
            false
            )).Validate(obj, obj.Rayon, CustomMandatoryField.ASSession_Rayon);

          
                (new PredicateValidator("", "DetailsTableView", "DetailsTableView", "DetailsTableView",
              new object[] {
              },
                        false
                    )).Validate(obj, c => DetailsViewIsValid(c)
                    );
            
                        foreach(var item in obj.ASSamples.Where(c => true))
                        {
                        
                (new PredicateValidator("AsSession.SummaryItem.datCollectionDate_msgId", "ASSamples", "datFieldCollectionDate", "ASSamples",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => ASSamplesIsValid(c,i)
                    );
            
                        }
                
                        foreach(var item in obj.SummaryItems.Where(c => true))
                        {
                        
                (new PredicateValidator("AsSession.SummaryItem.datCollectionDate_msgId", "SummaryItems", "datCompletionDate", "SummaryItems",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => NewSummaryItemIsValid(c,i)
                    );
            
                        }
                
                  
                    }

                    if (bChangeValidation)
                    {
                
                        foreach(var item in obj.ASSamples.Where(c => !c.IsMarkedToDelete))
                        {
                        
                (new PredicateValidator("AsSession.SummaryItem.datCollectionDate_msgId", "datFieldCollectionDate", "ASSamples", "datFieldCollectionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => ASSamplesIsValid(c,i)
                    );
            
                        }
                
                        foreach(var item in obj.SummaryItems.Where(c => !c.IsMarkedToDelete))
                        {
                        
                (new PredicateValidator("AsSession.SummaryItem.datCollectionDate_msgId", "datCompletionDate", "SummaryItems", "datCompletionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => NewSummaryItemIsValid(c,i)
                    );
            
                        }
                
                (new PredicateValidator("AsSession_WrongCampaignAssignment", "idfCampaign", "idfCampaign", "idfCampaign",
              new object[] {
              },
                        false
                    )).Validate(obj, c=>c.CopyCampaignData()
                    );
            
                (new PredicateValidator("", "_strCreatedCases", "_strCreatedCases", "_strCreatedCases",
              new object[] {
              },
                        false
                    )).Validate(obj, c=>c.ValidationMessageForCases()
                    );
            
                (new PredicateValidator("datSessionStartDate_datSessionEndDate_msgId", "datStartDate", "datStartDate", "datStartDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datStartDate, c.datEndDate)
                    );
            
                (new PredicateValidator("datSessionStartDate_datSessionEndDate_msgId", "datEndDate", "datEndDate", "datEndDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datStartDate, c.datEndDate)
                    );
            
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Diseases != null)
                            foreach (var i in obj.Diseases.Where(c => !c.IsMarkedToDelete))
                                DiseasesAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.ASFarms != null)
                            foreach (var i in obj.ASFarms.Where(c => !c.IsMarkedToDelete))
                                ASFarmsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Actions != null)
                            foreach (var i in obj.Actions.Where(c => !c.IsMarkedToDelete))
                                ActionsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.SummaryItems != null)
                            foreach (var i in obj.SummaryItems.Where(c => !c.IsMarkedToDelete))
                                SummaryItemsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.DetailsTableView != null)
                            foreach (var i in obj.DetailsTableView.Where(c => !c.IsMarkedToDelete))
                                DetailsTableViewAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.CaseTests != null)
                            foreach (var i in obj.CaseTests.Where(c => !c.IsMarkedToDelete))
                                CaseTestsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.CaseTestValidations != null)
                            foreach (var i in obj.CaseTestValidations.Where(c => !c.IsMarkedToDelete))
                                CaseTestValidationsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("MonitoringSession.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("MonitoringSession.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("MonitoringSession.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("MonitoringSession.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(AsSession obj)
            {
            
                obj
                    .AddRequired("MonitoringSessionStatus", c => true);
                    
                obj
                    .AddRequired("Region", c => true);
                    
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.ASSession_StartDate))
              {
              
              obj
                  .AddRequired("datStartDate", c=>true);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.ASSession_EndDate))
              {
              
              obj
                  .AddRequired("datEndDate", c=>true);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.ASSession_Rayon))
              {
              
              obj
                  .AddRequired("Rayon", c=>true);
                
                }
            
            }
    
    private void _SetupPersonalDataRestrictions(AsSession obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsSession) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsSession) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsSessionDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return "web_as_session_form"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private AsSession m_obj;
            internal Permissions(AsSession obj)
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
            public static string spSelect = "spASSession_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spASSession_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "spASSession_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsSession, bool>> RequiredByField = new Dictionary<string, Func<AsSession, bool>>();
            public static Dictionary<string, Func<AsSession, bool>> RequiredByProperty = new Dictionary<string, Func<AsSession, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strMonitoringSessionID, 50);
                Sizes.Add(_str_strCampaignID, 50);
                Sizes.Add(_str_strCampaignName, 200);
                if (!RequiredByField.ContainsKey("MonitoringSessionStatus")) RequiredByField.Add("MonitoringSessionStatus", c => true);
                if (!RequiredByProperty.ContainsKey("MonitoringSessionStatus")) RequiredByProperty.Add("MonitoringSessionStatus", c => true);
                
                if (!RequiredByField.ContainsKey("Region")) RequiredByField.Add("Region", c => true);
                if (!RequiredByProperty.ContainsKey("Region")) RequiredByProperty.Add("Region", c => true);
                
                Actions.Add(new ActionMetaItem(
                    "CreateCase",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).CreateCase(manager, (AsSession)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleCreateCase",
                        "Livestock_Case__small_",
                        /*from BvMessages*/"titleCreateCase",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "ReportAsSampleCollectedList",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ReportAsSampleCollectedList(manager, (AsSession)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleReportAsSampleCollectedList",
                        "Report",
                        /*from BvMessages*/"titleReportAsSampleCollectedList",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "ReportAsSessionTests",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ReportAsSessionTests(manager, (AsSession)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleReportAsSessionTests",
                        "Report",
                        /*from BvMessages*/"titleReportAsSessionTests",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      true,
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
                    (manager, c, pars) => new ActResult(((AsSession)c).MarkToDelete() && ObjectAccessor.PostInterface<AsSession>().Post(manager, (AsSession)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AsSession>().Post(manager, (AsSession)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AsSession>().Post(manager, (AsSession)c), c),
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
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class AsSessionDisease : 
        EditableObject<AsSessionDisease>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfMonitoringSessionToDiagnosis), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMonitoringSessionToDiagnosis { get; set; }
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64 idfMonitoringSession { get; set; }
        #if MONO
        protected Int64 idfMonitoringSession_Original { get { return idfMonitoringSession; } }
        protected Int64 idfMonitoringSession_Previous { get { return idfMonitoringSession; } }
        #else
        protected Int64 idfMonitoringSession_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64 idfMonitoringSession_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsDiagnosis)]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64 idfsDiagnosis { get; set; }
        #if MONO
        protected Int64 idfsDiagnosis_Original { get { return idfsDiagnosis; } }
        protected Int64 idfsDiagnosis_Previous { get { return idfsDiagnosis; } }
        #else
        protected Int64 idfsDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64 idfsDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSpeciesType)]
        [MapField(_str_idfsSpeciesType)]
        public abstract Int64? idfsSpeciesType { get; set; }
        #if MONO
        protected Int64? idfsSpeciesType_Original { get { return idfsSpeciesType; } }
        protected Int64? idfsSpeciesType_Previous { get { return idfsSpeciesType; } }
        #else
        protected Int64? idfsSpeciesType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).OriginalValue; } }
        protected Int64? idfsSpeciesType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32 intOrder { get; set; }
        #if MONO
        protected Int32 intOrder_Original { get { return intOrder; } }
        protected Int32 intOrder_Previous { get { return intOrder; } }
        #else
        protected Int32 intOrder_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32 intOrder_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<AsSessionDisease, object> _get_func;
            internal Action<AsSessionDisease, string> _set_func;
            internal Action<AsSessionDisease, AsSessionDisease, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMonitoringSessionToDiagnosis = "idfMonitoringSessionToDiagnosis";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_strDiagnosis = "strDiagnosis";
        internal const string _str_strSpecies = "strSpecies";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_SpeciesType = "SpeciesType";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfMonitoringSessionToDiagnosis, _type = "Int64",
              _get_func = o => o.idfMonitoringSessionToDiagnosis,
              _set_func = (o, val) => { o.idfMonitoringSessionToDiagnosis = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSessionToDiagnosis != c.idfMonitoringSessionToDiagnosis || o.IsRIRPropChanged(_str_idfMonitoringSessionToDiagnosis, c)) 
                  m.Add(_str_idfMonitoringSessionToDiagnosis, o.ObjectIdent + _str_idfMonitoringSessionToDiagnosis, "Int64", o.idfMonitoringSessionToDiagnosis == null ? "" : o.idfMonitoringSessionToDiagnosis.ToString(), o.IsReadOnly(_str_idfMonitoringSessionToDiagnosis), o.IsInvisible(_str_idfMonitoringSessionToDiagnosis), o.IsRequired(_str_idfMonitoringSessionToDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_idfMonitoringSession, _type = "Int64",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { o.idfMonitoringSession = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, "Int64", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosis, _type = "Int64",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { o.idfsDiagnosis = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, "Int64", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_idfsSpeciesType, _type = "Int64?",
              _get_func = o => o.idfsSpeciesType,
              _set_func = (o, val) => { o.idfsSpeciesType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_idfsSpeciesType, c)) 
                  m.Add(_str_idfsSpeciesType, o.ObjectIdent + _str_idfsSpeciesType, "Int64?", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_idfsSpeciesType), o.IsInvisible(_str_idfsSpeciesType), o.IsRequired(_str_idfsSpeciesType)); }
              }, 
        
            new field_info {
              _name = _str_intOrder, _type = "Int32",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { o.intOrder = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, "Int32", o.intOrder == null ? "" : o.intOrder.ToString(), o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); }
              }, 
        
            new field_info {
              _name = _str_strDiagnosis, _type = "string",
              _get_func = o => o.strDiagnosis,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strDiagnosis != c.strDiagnosis || o.IsRIRPropChanged(_str_strDiagnosis, c)) 
                  m.Add(_str_strDiagnosis, o.ObjectIdent + _str_strDiagnosis, "string", o.strDiagnosis == null ? "" : o.strDiagnosis.ToString(), o.IsReadOnly(_str_strDiagnosis), o.IsInvisible(_str_strDiagnosis), o.IsRequired(_str_strDiagnosis));
                 }
              }, 
        
            new field_info {
              _name = _str_strSpecies, _type = "string",
              _get_func = o => o.strSpecies,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strSpecies != c.strSpecies || o.IsRIRPropChanged(_str_strSpecies, c)) 
                  m.Add(_str_strSpecies, o.ObjectIdent + _str_strSpecies, "string", o.strSpecies == null ? "" : o.strSpecies.ToString(), o.IsReadOnly(_str_strSpecies), o.IsInvisible(_str_strSpecies), o.IsRequired(_str_strSpecies));
                 }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c)) 
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); }
              }, 
        
            new field_info {
              _name = _str_SpeciesType, _type = "Lookup",
              _get_func = o => { if (o.SpeciesType == null) return null; return o.SpeciesType.idfsBaseReference; },
              _set_func = (o, val) => { o.SpeciesType = o.SpeciesTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_SpeciesType, c)) 
                  m.Add(_str_SpeciesType, o.ObjectIdent + _str_SpeciesType, "Lookup", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_SpeciesType), o.IsInvisible(_str_SpeciesType), o.IsRequired(_str_SpeciesType)); }
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
            AsSessionDisease obj = (AsSessionDisease)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsDiagnosis = _Diagnosis == null 
                    ? new Int64()
                    : _Diagnosis.idfsDiagnosis; 
                OnPropertyChanged(_str_Diagnosis); 
            }
        }
        private DiagnosisLookup _Diagnosis;

        
        public List<DiagnosisLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<DiagnosisLookup> _DiagnosisLookup = new List<DiagnosisLookup>();
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSpeciesType)]
        public BaseReference SpeciesType
        {
            get { return _SpeciesType == null ? null : ((long)_SpeciesType.Key == 0 ? null : _SpeciesType); }
            set 
            { 
                _SpeciesType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSpeciesType = _SpeciesType == null 
                    ? new Int64?()
                    : _SpeciesType.idfsBaseReference; 
                OnPropertyChanged(_str_SpeciesType); 
            }
        }
        private BaseReference _SpeciesType;

        
        public BaseReferenceList SpeciesTypeLookup
        {
            get { return _SpeciesTypeLookup; }
        }
        private BaseReferenceList _SpeciesTypeLookup = new BaseReferenceList("rftSpeciesList");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_SpeciesType:
                    return new BvSelectList(SpeciesTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SpeciesType, _str_idfsSpeciesType);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strDiagnosis)]
        public string strDiagnosis
        {
            get { return new Func<AsSessionDisease, string>(c=> c.Diagnosis == null ? "" : c.Diagnosis.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strSpecies)]
        public string strSpecies
        {
            get { return new Func<AsSessionDisease, string>(c=>c.SpeciesType == null ? "" : c.SpeciesType.name)(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AsSessionDisease";

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
            var ret = base.Clone() as AsSessionDisease;
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
            var ret = base.Clone() as AsSessionDisease;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AsSessionDisease CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsSessionDisease;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfMonitoringSessionToDiagnosis; } }
        public string KeyName { get { return "idfMonitoringSessionToDiagnosis"; } }
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
        
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsSpeciesType_SpeciesType = idfsSpeciesType;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsSpeciesType_SpeciesType != idfsSpeciesType)
            {
                _SpeciesType = _SpeciesTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSpeciesType);
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

      private bool IsRIRPropChanged(string fld, AsSessionDisease c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public AsSessionDisease()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsSessionDisease_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsSessionDisease_PropertyChanged);
        }
        private void AsSessionDisease_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsSessionDisease).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsDiagnosis)
                OnPropertyChanged(_str_strDiagnosis);
                  
            if (e.PropertyName == _str_idfsSpeciesType)
                OnPropertyChanged(_str_strSpecies);
                  
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
            AsSessionDisease obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsSessionDisease obj = this;
            
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

    
        private static string[] readonly_names1 = "idfsSpeciesType,SpeciesType".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsSessionDisease, bool>(c=>(c.idfsDiagnosis == 0))(this);
            
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


        public Dictionary<string, Func<AsSessionDisease, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsSessionDisease, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsSessionDisease, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<AsSessionDisease, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsSessionDisease, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<AsSessionDisease, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AsSessionDisease()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftSpeciesList", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftSpeciesList")
                _getAccessor().LoadLookup_SpeciesType(manager, this);
            
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
        public class AsSessionDiseaseGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public long? idfMonitoringSessionToDiagnosis { get; set; }
        
            public string strDiagnosis { get; set; }
        
            public string strSpecies { get; set; }
        
        }
        public partial class AsSessionDiseaseGridModelList : List<AsSessionDiseaseGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public AsSessionDiseaseGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionDisease>, errMes);
            }
            public AsSessionDiseaseGridModelList(long key, IEnumerable<AsSessionDisease> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<AsSessionDisease> items);
            private void LoadGridModelList(long key, IEnumerable<AsSessionDisease> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strDiagnosis,_str_strSpecies};
                    
                Hiddens = new List<string> {_str_idfMonitoringSessionToDiagnosis};
                Keys = new List<string> {_str_idfMonitoringSessionToDiagnosis};
                Labels = new Dictionary<string, string> {{_str_strDiagnosis, _str_strDiagnosis},{_str_strSpecies, _str_strSpecies}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<AsSessionDisease>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AsSessionDiseaseGridModel()
                {
                    ItemKey=c.idfMonitoringSessionToDiagnosis,strDiagnosis=c.strDiagnosis,strSpecies=c.strSpecies
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
        : DataAccessor<AsSessionDisease>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(AsSessionDisease obj);
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
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SpeciesTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            

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

            
            public virtual AsSessionDisease SelectByKey(DbManagerProxy manager
                , Int64? idfMonitoringSession
                )
            {
                return _SelectByKey(manager
                    , idfMonitoringSession
                    , null, null
                    );
            }
            
      
            private AsSessionDisease _SelectByKey(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsSessionDisease obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AsSessionDisease obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AsSessionDisease _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    AsSessionDisease obj = AsSessionDisease.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfMonitoringSessionToDiagnosis = (new GetNewIDExtender<AsSessionDisease>()).GetScalar(manager, obj);
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

            
            public AsSessionDisease CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public AsSessionDisease CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(AsSessionDisease obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AsSessionDisease obj)
            {
                
            }
    
            public void LoadLookup_Diagnosis(DbManagerProxy manager, AsSessionDisease obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Livestock) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .Where(c => c.idfsDiagnosis == obj.idfsDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_SpeciesType(DbManagerProxy manager, AsSessionDisease obj)
            {
                
                obj.SpeciesTypeLookup.Clear();
                
                obj.SpeciesTypeLookup.Add(SpeciesTypeAccessor.CreateNewT(manager, null));
                
                obj.SpeciesTypeLookup.AddRange(SpeciesTypeAccessor.rftSpeciesList_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode.GetValueOrDefault() & ((int?)HACode.Livestock).GetValueOrDefault()) != 0 || c.idfsBaseReference == obj.idfsSpeciesType)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSpeciesType))
                    
                    .ToList());
                
                if (obj.idfsSpeciesType != null && obj.idfsSpeciesType != 0)
                {
                    obj.SpeciesType = obj.SpeciesTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsSpeciesType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftSpeciesList", obj, SpeciesTypeAccessor.GetType(), "rftSpeciesList_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, AsSessionDisease obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_SpeciesType(manager, obj);
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spASSessionDiagnosis_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfMonitoringSessionToDiagnosis")] AsSessionDisease obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfMonitoringSessionToDiagnosis")] AsSessionDisease obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AsSessionDisease bo = obj as AsSessionDisease;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as AsSessionDisease, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsSessionDisease obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postPredicate(manager, 8, obj);
                                
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AsSessionDisease obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AsSessionDisease obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as AsSessionDisease, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsSessionDisease obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsDiagnosis", "idfsDiagnosis","idfsDiagnosis",
                false
              )).Validate(c => true, obj, obj.idfsDiagnosis);
            
                  
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
           
    
            private void _SetupRequired(AsSessionDisease obj)
            {
            
                obj
                    .AddRequired("idfsDiagnosis", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(AsSessionDisease obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsSessionDisease) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsSessionDisease) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsSessionDiseaseDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spASSession_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spASSessionDiagnosis_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsSessionDisease, bool>> RequiredByField = new Dictionary<string, Func<AsSessionDisease, bool>>();
            public static Dictionary<string, Func<AsSessionDisease, bool>> RequiredByProperty = new Dictionary<string, Func<AsSessionDisease, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                if (!RequiredByField.ContainsKey("idfsDiagnosis")) RequiredByField.Add("idfsDiagnosis", c => true);
                if (!RequiredByProperty.ContainsKey("idfsDiagnosis")) RequiredByProperty.Add("idfsDiagnosis", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfMonitoringSessionToDiagnosis,
                    _str_idfMonitoringSessionToDiagnosis, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosis,
                    _str_strDiagnosis, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpecies,
                    _str_strSpecies, null, true, true, null
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
                    (manager, c, pars) => new ActResult(((AsSessionDisease)c).MarkToDelete() && ObjectAccessor.PostInterface<AsSessionDisease>().Post(manager, (AsSessionDisease)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AsSessionDisease>().Post(manager, (AsSessionDisease)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AsSessionDisease>().Post(manager, (AsSessionDisease)c), c),
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
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class AsSessionFarm : 
        EditableObject<AsSessionFarm>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfFarm), NonUpdatable, PrimaryKey]
        public abstract Int64 idfFarm { get; set; }
                
        [LocalizedDisplayName(_str_idfRootFarm)]
        [MapField(_str_idfRootFarm)]
        public abstract Int64? idfRootFarm { get; set; }
        #if MONO
        protected Int64? idfRootFarm_Original { get { return idfRootFarm; } }
        protected Int64? idfRootFarm_Previous { get { return idfRootFarm; } }
        #else
        protected Int64? idfRootFarm_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootFarm).OriginalValue; } }
        protected Int64? idfRootFarm_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootFarm).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strFarmCode)]
        [MapField(_str_strFarmCode)]
        public abstract String strFarmCode { get; set; }
        #if MONO
        protected String strFarmCode_Original { get { return strFarmCode; } }
        protected String strFarmCode_Previous { get { return strFarmCode; } }
        #else
        protected String strFarmCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).OriginalValue; } }
        protected String strFarmCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strNationalName)]
        [MapField(_str_strNationalName)]
        public abstract String strNationalName { get; set; }
        #if MONO
        protected String strNationalName_Original { get { return strNationalName; } }
        protected String strNationalName_Previous { get { return strNationalName; } }
        #else
        protected String strNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._strNationalName).OriginalValue; } }
        protected String strNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNationalName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strOwnerName)]
        [MapField(_str_strOwnerName)]
        public abstract String strOwnerName { get; set; }
        #if MONO
        protected String strOwnerName_Original { get { return strOwnerName; } }
        protected String strOwnerName_Previous { get { return strOwnerName; } }
        #else
        protected String strOwnerName_Original { get { return ((EditableValue<String>)((dynamic)this)._strOwnerName).OriginalValue; } }
        protected String strOwnerName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOwnerName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsOwnershipStructure)]
        [MapField(_str_idfsOwnershipStructure)]
        public abstract Int64? idfsOwnershipStructure { get; set; }
        #if MONO
        protected Int64? idfsOwnershipStructure_Original { get { return idfsOwnershipStructure; } }
        protected Int64? idfsOwnershipStructure_Previous { get { return idfsOwnershipStructure; } }
        #else
        protected Int64? idfsOwnershipStructure_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOwnershipStructure).OriginalValue; } }
        protected Int64? idfsOwnershipStructure_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOwnershipStructure).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsLivestockProductionType)]
        [MapField(_str_idfsLivestockProductionType)]
        public abstract Int64? idfsLivestockProductionType { get; set; }
        #if MONO
        protected Int64? idfsLivestockProductionType_Original { get { return idfsLivestockProductionType; } }
        protected Int64? idfsLivestockProductionType_Previous { get { return idfsLivestockProductionType; } }
        #else
        protected Int64? idfsLivestockProductionType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsLivestockProductionType).OriginalValue; } }
        protected Int64? idfsLivestockProductionType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsLivestockProductionType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64? idfMonitoringSession { get; set; }
        #if MONO
        protected Int64? idfMonitoringSession_Original { get { return idfMonitoringSession; } }
        protected Int64? idfMonitoringSession_Previous { get { return idfMonitoringSession; } }
        #else
        protected Int64? idfMonitoringSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64? idfMonitoringSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnNewFarm)]
        [MapField(_str_blnNewFarm)]
        public abstract Boolean? blnNewFarm { get; set; }
        #if MONO
        protected Boolean? blnNewFarm_Original { get { return blnNewFarm; } }
        protected Boolean? blnNewFarm_Previous { get { return blnNewFarm; } }
        #else
        protected Boolean? blnNewFarm_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnNewFarm).OriginalValue; } }
        protected Boolean? blnNewFarm_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnNewFarm).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<AsSessionFarm, object> _get_func;
            internal Action<AsSessionFarm, string> _set_func;
            internal Action<AsSessionFarm, AsSessionFarm, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfFarm = "idfFarm";
        internal const string _str_idfRootFarm = "idfRootFarm";
        internal const string _str_strFarmCode = "strFarmCode";
        internal const string _str_strNationalName = "strNationalName";
        internal const string _str_strOwnerName = "strOwnerName";
        internal const string _str_idfsOwnershipStructure = "idfsOwnershipStructure";
        internal const string _str_idfsLivestockProductionType = "idfsLivestockProductionType";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_blnNewFarm = "blnNewFarm";
        internal const string _str_Farm = "Farm";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfFarm, _type = "Int64",
              _get_func = o => o.idfFarm,
              _set_func = (o, val) => { o.idfFarm = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfFarm != c.idfFarm || o.IsRIRPropChanged(_str_idfFarm, c)) 
                  m.Add(_str_idfFarm, o.ObjectIdent + _str_idfFarm, "Int64", o.idfFarm == null ? "" : o.idfFarm.ToString(), o.IsReadOnly(_str_idfFarm), o.IsInvisible(_str_idfFarm), o.IsRequired(_str_idfFarm)); }
              }, 
        
            new field_info {
              _name = _str_idfRootFarm, _type = "Int64?",
              _get_func = o => o.idfRootFarm,
              _set_func = (o, val) => { o.idfRootFarm = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfRootFarm != c.idfRootFarm || o.IsRIRPropChanged(_str_idfRootFarm, c)) 
                  m.Add(_str_idfRootFarm, o.ObjectIdent + _str_idfRootFarm, "Int64?", o.idfRootFarm == null ? "" : o.idfRootFarm.ToString(), o.IsReadOnly(_str_idfRootFarm), o.IsInvisible(_str_idfRootFarm), o.IsRequired(_str_idfRootFarm)); }
              }, 
        
            new field_info {
              _name = _str_strFarmCode, _type = "String",
              _get_func = o => o.strFarmCode,
              _set_func = (o, val) => { o.strFarmCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFarmCode != c.strFarmCode || o.IsRIRPropChanged(_str_strFarmCode, c)) 
                  m.Add(_str_strFarmCode, o.ObjectIdent + _str_strFarmCode, "String", o.strFarmCode == null ? "" : o.strFarmCode.ToString(), o.IsReadOnly(_str_strFarmCode), o.IsInvisible(_str_strFarmCode), o.IsRequired(_str_strFarmCode)); }
              }, 
        
            new field_info {
              _name = _str_strNationalName, _type = "String",
              _get_func = o => o.strNationalName,
              _set_func = (o, val) => { o.strNationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNationalName != c.strNationalName || o.IsRIRPropChanged(_str_strNationalName, c)) 
                  m.Add(_str_strNationalName, o.ObjectIdent + _str_strNationalName, "String", o.strNationalName == null ? "" : o.strNationalName.ToString(), o.IsReadOnly(_str_strNationalName), o.IsInvisible(_str_strNationalName), o.IsRequired(_str_strNationalName)); }
              }, 
        
            new field_info {
              _name = _str_strOwnerName, _type = "String",
              _get_func = o => o.strOwnerName,
              _set_func = (o, val) => { o.strOwnerName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strOwnerName != c.strOwnerName || o.IsRIRPropChanged(_str_strOwnerName, c)) 
                  m.Add(_str_strOwnerName, o.ObjectIdent + _str_strOwnerName, "String", o.strOwnerName == null ? "" : o.strOwnerName.ToString(), o.IsReadOnly(_str_strOwnerName), o.IsInvisible(_str_strOwnerName), o.IsRequired(_str_strOwnerName)); }
              }, 
        
            new field_info {
              _name = _str_idfsOwnershipStructure, _type = "Int64?",
              _get_func = o => o.idfsOwnershipStructure,
              _set_func = (o, val) => { o.idfsOwnershipStructure = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsOwnershipStructure != c.idfsOwnershipStructure || o.IsRIRPropChanged(_str_idfsOwnershipStructure, c)) 
                  m.Add(_str_idfsOwnershipStructure, o.ObjectIdent + _str_idfsOwnershipStructure, "Int64?", o.idfsOwnershipStructure == null ? "" : o.idfsOwnershipStructure.ToString(), o.IsReadOnly(_str_idfsOwnershipStructure), o.IsInvisible(_str_idfsOwnershipStructure), o.IsRequired(_str_idfsOwnershipStructure)); }
              }, 
        
            new field_info {
              _name = _str_idfsLivestockProductionType, _type = "Int64?",
              _get_func = o => o.idfsLivestockProductionType,
              _set_func = (o, val) => { o.idfsLivestockProductionType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsLivestockProductionType != c.idfsLivestockProductionType || o.IsRIRPropChanged(_str_idfsLivestockProductionType, c)) 
                  m.Add(_str_idfsLivestockProductionType, o.ObjectIdent + _str_idfsLivestockProductionType, "Int64?", o.idfsLivestockProductionType == null ? "" : o.idfsLivestockProductionType.ToString(), o.IsReadOnly(_str_idfsLivestockProductionType), o.IsInvisible(_str_idfsLivestockProductionType), o.IsRequired(_str_idfsLivestockProductionType)); }
              }, 
        
            new field_info {
              _name = _str_idfMonitoringSession, _type = "Int64?",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { o.idfMonitoringSession = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, "Int64?", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); }
              }, 
        
            new field_info {
              _name = _str_blnNewFarm, _type = "Boolean?",
              _get_func = o => o.blnNewFarm,
              _set_func = (o, val) => { o.blnNewFarm = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnNewFarm != c.blnNewFarm || o.IsRIRPropChanged(_str_blnNewFarm, c)) 
                  m.Add(_str_blnNewFarm, o.ObjectIdent + _str_blnNewFarm, "Boolean?", o.blnNewFarm == null ? "" : o.blnNewFarm.ToString(), o.IsReadOnly(_str_blnNewFarm), o.IsInvisible(_str_blnNewFarm), o.IsRequired(_str_blnNewFarm)); }
              }, 
        
            new field_info {
              _name = _str_Farm, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Farm != null) o.Farm._compare(c.Farm, m); }
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
            AsSessionFarm obj = (AsSessionFarm)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(FarmPanel), eidss.model.Schema.FarmPanel._str_idfFarm, _str_idfFarm)]
        public FarmPanel Farm
        {
            get 
            {   
                return _Farm; 
            }
            set 
            {   
                _Farm = value;
                if (_Farm != null) 
                { 
                    _Farm.m_ObjectName = _str_Farm;
                    _Farm.Parent = this;
                }
                idfFarm = _Farm == null 
                        ? new Int64()
                        : _Farm.idfFarm;
                
            }
        }
        protected FarmPanel _Farm;
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AsSessionFarm";

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
        
            if (_Farm != null) { _Farm.Parent = this; }
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as AsSessionFarm;
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
            var ret = base.Clone() as AsSessionFarm;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Farm != null)
              ret.Farm = _Farm.CloneWithSetup(manager) as FarmPanel;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AsSessionFarm CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsSessionFarm;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfFarm; } }
        public string KeyName { get { return "idfFarm"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || (_Farm != null && _Farm.HasChanges)
                
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
        
            if (Farm != null) Farm.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Farm != null) _Farm.AcceptChanges();
                
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
        
            if (_Farm != null) _Farm.SetChange();
                
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

      private bool IsRIRPropChanged(string fld, AsSessionFarm c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public AsSessionFarm()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();

        
        private int? m_HACode;
        public int? _HACode { get { return m_HACode; } set { m_HACode = value; } }
        

        private bool m_IsForcedToDelete;
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsSessionFarm_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsSessionFarm_PropertyChanged);
        }
        private void AsSessionFarm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsSessionFarm).Changed(e.PropertyName);
            
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
            AsSessionFarm obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsSessionFarm obj = this;
            
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
        
                if (_Farm != null)
                    _Farm.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<AsSessionFarm, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsSessionFarm, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsSessionFarm, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<AsSessionFarm, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsSessionFarm, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<AsSessionFarm, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AsSessionFarm()
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
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._name] != null) a._set_func(this, form[ObjectIdent + a._name]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._name)) a._set_func(this, form[ObjectIdent + a._name]);} );
      
            if (bParseRelations)
            {
        
            if (_Farm != null) _Farm.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<AsSessionFarm>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(AsSessionFarm obj);
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
            private FarmPanel.Accessor FarmAccessor { get { return eidss.model.Schema.FarmPanel.Accessor.Instance(m_CS); } }
            

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
                            
                        , HACode
                        
                        , null, null
                        );
                }
            }

            
            public virtual AsSessionFarm SelectByKey(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , int? HACode = null
                
                )
            {
                return _SelectByKey(manager
                    , idfMonitoringSession
                    , HACode
                    
                    , null, null
                    );
            }
            
      
            private AsSessionFarm _SelectByKey(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
            internal void _LoadFarm(AsSessionFarm obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFarm(manager, obj);
                }
            }
            internal void _LoadFarm(DbManagerProxy manager, AsSessionFarm obj)
            {
                
                if (obj.Farm == null && obj.idfFarm != 0)
                {
                    obj.Farm = FarmAccessor.SelectByKey(manager
                        
                        , obj.idfFarm
                        , obj._HACode
                                
                        );
                    if (obj.Farm != null)
                    {
                        obj.Farm.m_ObjectName = _str_Farm;
                    }
                }
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsSessionFarm obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj._HACode = new Func<AsSessionFarm, int?>(c => (int)eidss.model.Enums.HACode.Livestock)(obj);
                // loading extenters - end
                
                _LoadFarm(manager, obj);
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AsSessionFarm obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    FarmAccessor._SetPermitions(obj._permissions, obj.Farm);
                    
                    }
                }
            }

    

            private AsSessionFarm _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    AsSessionFarm obj = AsSessionFarm.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    obj._HACode = HACode;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj._HACode = new Func<AsSessionFarm, int?>(c => (int)eidss.model.Enums.HACode.Livestock)(obj);
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

            
            public AsSessionFarm CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public AsSessionFarm CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public AsSessionFarm CreateFarmT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is FarmPanel)) 
                    throw new TypeMismatchException("farm", typeof(FarmPanel));
                
                return CreateFarm(manager, Parent
                    , (FarmPanel)pars[0]
                    );
            }
            public IObject CreateFarm(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateFarmT(manager, Parent, pars);
            }
            public AsSessionFarm CreateFarm(DbManagerProxy manager, IObject Parent
                , FarmPanel farm
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfFarm = farm.idfFarm;
                obj.idfRootFarm = farm.idfRootFarm;
                obj.idfMonitoringSession = farm.idfMonitoringSession;
                obj.Farm = farm;
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(AsSessionFarm obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AsSessionFarm obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, AsSessionFarm obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spASSessionFarm_Link")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] AsSessionFarm obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] AsSessionFarm obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AsSessionFarm bo = obj as AsSessionFarm;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as AsSessionFarm, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsSessionFarm obj, bool bChildObject) 
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
                    // posting extenters - end
            
                    if (!obj.IsMarkedToDelete && bHasChanges)
                        _postPredicate(manager, obj);
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AsSessionFarm obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AsSessionFarm obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as AsSessionFarm, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsSessionFarm obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(AsSessionFarm obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(AsSessionFarm obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsSessionFarm) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsSessionFarm) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsSessionFarmDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spASSession_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spASSessionFarm_Link";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsSessionFarm, bool>> RequiredByField = new Dictionary<string, Func<AsSessionFarm, bool>>();
            public static Dictionary<string, Func<AsSessionFarm, bool>> RequiredByProperty = new Dictionary<string, Func<AsSessionFarm, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_strNationalName, 200);
                Sizes.Add(_str_strOwnerName, 602);
                Actions.Add(new ActionMetaItem(
                    "CreateFarm",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateFarm(manager, c, pars)),
                        
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
                    (manager, c, pars) => new ActResult(((AsSessionFarm)c).MarkToDelete() && ObjectAccessor.PostInterface<AsSessionFarm>().Post(manager, (AsSessionFarm)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AsSessionFarm>().Post(manager, (AsSessionFarm)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AsSessionFarm>().Post(manager, (AsSessionFarm)c), c),
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
	