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
        protected Int64? idfRootFarm_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootFarm).OriginalValue; } }
        protected Int64? idfRootFarm_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootFarm).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFarmCode)]
        [MapField(_str_strFarmCode)]
        public abstract String strFarmCode { get; set; }
        protected String strFarmCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).OriginalValue; } }
        protected String strFarmCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strNationalName)]
        [MapField(_str_strNationalName)]
        public abstract String strNationalName { get; set; }
        protected String strNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._strNationalName).OriginalValue; } }
        protected String strNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNationalName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOwnerName)]
        [MapField(_str_strOwnerName)]
        public abstract String strOwnerName { get; set; }
        protected String strOwnerName_Original { get { return ((EditableValue<String>)((dynamic)this)._strOwnerName).OriginalValue; } }
        protected String strOwnerName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOwnerName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsOwnershipStructure)]
        [MapField(_str_idfsOwnershipStructure)]
        public abstract Int64? idfsOwnershipStructure { get; set; }
        protected Int64? idfsOwnershipStructure_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOwnershipStructure).OriginalValue; } }
        protected Int64? idfsOwnershipStructure_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOwnershipStructure).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsLivestockProductionType)]
        [MapField(_str_idfsLivestockProductionType)]
        public abstract Int64? idfsLivestockProductionType { get; set; }
        protected Int64? idfsLivestockProductionType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsLivestockProductionType).OriginalValue; } }
        protected Int64? idfsLivestockProductionType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsLivestockProductionType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64? idfMonitoringSession { get; set; }
        protected Int64? idfMonitoringSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64? idfMonitoringSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnNewFarm)]
        [MapField(_str_blnNewFarm)]
        public abstract Boolean? blnNewFarm { get; set; }
        protected Boolean? blnNewFarm_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnNewFarm).OriginalValue; } }
        protected Boolean? blnNewFarm_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnNewFarm).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnIsDetailsFarm)]
        [MapField(_str_blnIsDetailsFarm)]
        public abstract Boolean blnIsDetailsFarm { get; set; }
        protected Boolean blnIsDetailsFarm_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnIsDetailsFarm).OriginalValue; } }
        protected Boolean blnIsDetailsFarm_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnIsDetailsFarm).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnIsSummaryFarm)]
        [MapField(_str_blnIsSummaryFarm)]
        public abstract Boolean blnIsSummaryFarm { get; set; }
        protected Boolean blnIsSummaryFarm_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnIsSummaryFarm).OriginalValue; } }
        protected Boolean blnIsSummaryFarm_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnIsSummaryFarm).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfOwner)]
        [MapField(_str_idfOwner)]
        public abstract Int64? idfOwner { get; set; }
        protected Int64? idfOwner_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOwner).OriginalValue; } }
        protected Int64? idfOwner_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOwner).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<AsSessionFarm, object> _get_func;
            internal Action<AsSessionFarm, string> _set_func;
            internal Action<AsSessionFarm, AsSessionFarm, CompareModel, DbManagerProxy> _compare_func;
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
        internal const string _str_blnIsDetailsFarm = "blnIsDetailsFarm";
        internal const string _str_blnIsSummaryFarm = "blnIsSummaryFarm";
        internal const string _str_idfOwner = "idfOwner";
        internal const string _str_bDeleteInDetails = "bDeleteInDetails";
        internal const string _str_bDeleteInSummary = "bDeleteInSummary";
        internal const string _str_strOwnerLastName = "strOwnerLastName";
        internal const string _str_strContactPhone = "strContactPhone";
        internal const string _str_strRegion = "strRegion";
        internal const string _str_strRayon = "strRayon";
        internal const string _str_strTownOrVillage = "strTownOrVillage";
        internal const string _str_AsSessionDiseases = "AsSessionDiseases";
        internal const string _str_Farm = "Farm";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfFarm, _formname = _str_idfFarm, _type = "Int64",
              _get_func = o => o.idfFarm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfFarm != newval) o.idfFarm = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfFarm != c.idfFarm || o.IsRIRPropChanged(_str_idfFarm, c)) 
                  m.Add(_str_idfFarm, o.ObjectIdent + _str_idfFarm, o.ObjectIdent2 + _str_idfFarm, o.ObjectIdent3 + _str_idfFarm, "Int64", 
                    o.idfFarm == null ? "" : o.idfFarm.ToString(),                  
                  o.IsReadOnly(_str_idfFarm), o.IsInvisible(_str_idfFarm), o.IsRequired(_str_idfFarm)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfRootFarm, _formname = _str_idfRootFarm, _type = "Int64?",
              _get_func = o => o.idfRootFarm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfRootFarm != newval) o.idfRootFarm = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfRootFarm != c.idfRootFarm || o.IsRIRPropChanged(_str_idfRootFarm, c)) 
                  m.Add(_str_idfRootFarm, o.ObjectIdent + _str_idfRootFarm, o.ObjectIdent2 + _str_idfRootFarm, o.ObjectIdent3 + _str_idfRootFarm, "Int64?", 
                    o.idfRootFarm == null ? "" : o.idfRootFarm.ToString(),                  
                  o.IsReadOnly(_str_idfRootFarm), o.IsInvisible(_str_idfRootFarm), o.IsRequired(_str_idfRootFarm)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFarmCode, _formname = _str_strFarmCode, _type = "String",
              _get_func = o => o.strFarmCode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFarmCode != newval) o.strFarmCode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFarmCode != c.strFarmCode || o.IsRIRPropChanged(_str_strFarmCode, c)) 
                  m.Add(_str_strFarmCode, o.ObjectIdent + _str_strFarmCode, o.ObjectIdent2 + _str_strFarmCode, o.ObjectIdent3 + _str_strFarmCode, "String", 
                    o.strFarmCode == null ? "" : o.strFarmCode.ToString(),                  
                  o.IsReadOnly(_str_strFarmCode), o.IsInvisible(_str_strFarmCode), o.IsRequired(_str_strFarmCode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strNationalName, _formname = _str_strNationalName, _type = "String",
              _get_func = o => o.strNationalName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strNationalName != newval) o.strNationalName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strNationalName != c.strNationalName || o.IsRIRPropChanged(_str_strNationalName, c)) 
                  m.Add(_str_strNationalName, o.ObjectIdent + _str_strNationalName, o.ObjectIdent2 + _str_strNationalName, o.ObjectIdent3 + _str_strNationalName, "String", 
                    o.strNationalName == null ? "" : o.strNationalName.ToString(),                  
                  o.IsReadOnly(_str_strNationalName), o.IsInvisible(_str_strNationalName), o.IsRequired(_str_strNationalName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOwnerName, _formname = _str_strOwnerName, _type = "String",
              _get_func = o => o.strOwnerName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOwnerName != newval) o.strOwnerName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strOwnerName != c.strOwnerName || o.IsRIRPropChanged(_str_strOwnerName, c)) 
                  m.Add(_str_strOwnerName, o.ObjectIdent + _str_strOwnerName, o.ObjectIdent2 + _str_strOwnerName, o.ObjectIdent3 + _str_strOwnerName, "String", 
                    o.strOwnerName == null ? "" : o.strOwnerName.ToString(),                  
                  o.IsReadOnly(_str_strOwnerName), o.IsInvisible(_str_strOwnerName), o.IsRequired(_str_strOwnerName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsOwnershipStructure, _formname = _str_idfsOwnershipStructure, _type = "Int64?",
              _get_func = o => o.idfsOwnershipStructure,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsOwnershipStructure != newval) o.idfsOwnershipStructure = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsOwnershipStructure != c.idfsOwnershipStructure || o.IsRIRPropChanged(_str_idfsOwnershipStructure, c)) 
                  m.Add(_str_idfsOwnershipStructure, o.ObjectIdent + _str_idfsOwnershipStructure, o.ObjectIdent2 + _str_idfsOwnershipStructure, o.ObjectIdent3 + _str_idfsOwnershipStructure, "Int64?", 
                    o.idfsOwnershipStructure == null ? "" : o.idfsOwnershipStructure.ToString(),                  
                  o.IsReadOnly(_str_idfsOwnershipStructure), o.IsInvisible(_str_idfsOwnershipStructure), o.IsRequired(_str_idfsOwnershipStructure)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsLivestockProductionType, _formname = _str_idfsLivestockProductionType, _type = "Int64?",
              _get_func = o => o.idfsLivestockProductionType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsLivestockProductionType != newval) o.idfsLivestockProductionType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsLivestockProductionType != c.idfsLivestockProductionType || o.IsRIRPropChanged(_str_idfsLivestockProductionType, c)) 
                  m.Add(_str_idfsLivestockProductionType, o.ObjectIdent + _str_idfsLivestockProductionType, o.ObjectIdent2 + _str_idfsLivestockProductionType, o.ObjectIdent3 + _str_idfsLivestockProductionType, "Int64?", 
                    o.idfsLivestockProductionType == null ? "" : o.idfsLivestockProductionType.ToString(),                  
                  o.IsReadOnly(_str_idfsLivestockProductionType), o.IsInvisible(_str_idfsLivestockProductionType), o.IsRequired(_str_idfsLivestockProductionType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMonitoringSession, _formname = _str_idfMonitoringSession, _type = "Int64?",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfMonitoringSession != newval) o.idfMonitoringSession = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, o.ObjectIdent2 + _str_idfMonitoringSession, o.ObjectIdent3 + _str_idfMonitoringSession, "Int64?", 
                    o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(),                  
                  o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnNewFarm, _formname = _str_blnNewFarm, _type = "Boolean?",
              _get_func = o => o.blnNewFarm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnNewFarm != newval) o.blnNewFarm = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnNewFarm != c.blnNewFarm || o.IsRIRPropChanged(_str_blnNewFarm, c)) 
                  m.Add(_str_blnNewFarm, o.ObjectIdent + _str_blnNewFarm, o.ObjectIdent2 + _str_blnNewFarm, o.ObjectIdent3 + _str_blnNewFarm, "Boolean?", 
                    o.blnNewFarm == null ? "" : o.blnNewFarm.ToString(),                  
                  o.IsReadOnly(_str_blnNewFarm), o.IsInvisible(_str_blnNewFarm), o.IsRequired(_str_blnNewFarm)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnIsDetailsFarm, _formname = _str_blnIsDetailsFarm, _type = "Boolean",
              _get_func = o => o.blnIsDetailsFarm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnIsDetailsFarm != newval) o.blnIsDetailsFarm = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnIsDetailsFarm != c.blnIsDetailsFarm || o.IsRIRPropChanged(_str_blnIsDetailsFarm, c)) 
                  m.Add(_str_blnIsDetailsFarm, o.ObjectIdent + _str_blnIsDetailsFarm, o.ObjectIdent2 + _str_blnIsDetailsFarm, o.ObjectIdent3 + _str_blnIsDetailsFarm, "Boolean", 
                    o.blnIsDetailsFarm == null ? "" : o.blnIsDetailsFarm.ToString(),                  
                  o.IsReadOnly(_str_blnIsDetailsFarm), o.IsInvisible(_str_blnIsDetailsFarm), o.IsRequired(_str_blnIsDetailsFarm)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnIsSummaryFarm, _formname = _str_blnIsSummaryFarm, _type = "Boolean",
              _get_func = o => o.blnIsSummaryFarm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnIsSummaryFarm != newval) o.blnIsSummaryFarm = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnIsSummaryFarm != c.blnIsSummaryFarm || o.IsRIRPropChanged(_str_blnIsSummaryFarm, c)) 
                  m.Add(_str_blnIsSummaryFarm, o.ObjectIdent + _str_blnIsSummaryFarm, o.ObjectIdent2 + _str_blnIsSummaryFarm, o.ObjectIdent3 + _str_blnIsSummaryFarm, "Boolean", 
                    o.blnIsSummaryFarm == null ? "" : o.blnIsSummaryFarm.ToString(),                  
                  o.IsReadOnly(_str_blnIsSummaryFarm), o.IsInvisible(_str_blnIsSummaryFarm), o.IsRequired(_str_blnIsSummaryFarm)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfOwner, _formname = _str_idfOwner, _type = "Int64?",
              _get_func = o => o.idfOwner,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfOwner != newval) o.idfOwner = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfOwner != c.idfOwner || o.IsRIRPropChanged(_str_idfOwner, c)) 
                  m.Add(_str_idfOwner, o.ObjectIdent + _str_idfOwner, o.ObjectIdent2 + _str_idfOwner, o.ObjectIdent3 + _str_idfOwner, "Int64?", 
                    o.idfOwner == null ? "" : o.idfOwner.ToString(),                  
                  o.IsReadOnly(_str_idfOwner), o.IsInvisible(_str_idfOwner), o.IsRequired(_str_idfOwner)); 
                  }
              }, 
        
            new field_info {
              _name = _str_bDeleteInDetails, _formname = _str_bDeleteInDetails, _type = "bool",
              _get_func = o => o.bDeleteInDetails,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.bDeleteInDetails != newval) o.bDeleteInDetails = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.bDeleteInDetails != c.bDeleteInDetails || o.IsRIRPropChanged(_str_bDeleteInDetails, c)) {
                  m.Add(_str_bDeleteInDetails, o.ObjectIdent + _str_bDeleteInDetails, o.ObjectIdent2 + _str_bDeleteInDetails, o.ObjectIdent3 + _str_bDeleteInDetails,  "bool", 
                    o.bDeleteInDetails == null ? "" : o.bDeleteInDetails.ToString(),                  
                    o.IsReadOnly(_str_bDeleteInDetails), o.IsInvisible(_str_bDeleteInDetails), o.IsRequired(_str_bDeleteInDetails));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_bDeleteInSummary, _formname = _str_bDeleteInSummary, _type = "bool",
              _get_func = o => o.bDeleteInSummary,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.bDeleteInSummary != newval) o.bDeleteInSummary = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.bDeleteInSummary != c.bDeleteInSummary || o.IsRIRPropChanged(_str_bDeleteInSummary, c)) {
                  m.Add(_str_bDeleteInSummary, o.ObjectIdent + _str_bDeleteInSummary, o.ObjectIdent2 + _str_bDeleteInSummary, o.ObjectIdent3 + _str_bDeleteInSummary,  "bool", 
                    o.bDeleteInSummary == null ? "" : o.bDeleteInSummary.ToString(),                  
                    o.IsReadOnly(_str_bDeleteInSummary), o.IsInvisible(_str_bDeleteInSummary), o.IsRequired(_str_bDeleteInSummary));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_strOwnerLastName, _formname = _str_strOwnerLastName, _type = "string",
              _get_func = o => o.strOwnerLastName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOwnerLastName != newval) o.strOwnerLastName = newval;  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strOwnerLastName != c.strOwnerLastName || o.IsRIRPropChanged(_str_strOwnerLastName, c)) {
                  m.Add(_str_strOwnerLastName, o.ObjectIdent + _str_strOwnerLastName, o.ObjectIdent2 + _str_strOwnerLastName, o.ObjectIdent3 + _str_strOwnerLastName, "string", o.strOwnerLastName == null ? "" : o.strOwnerLastName.ToString(), o.IsReadOnly(_str_strOwnerLastName), o.IsInvisible(_str_strOwnerLastName), o.IsRequired(_str_strOwnerLastName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strContactPhone, _formname = _str_strContactPhone, _type = "string",
              _get_func = o => o.strContactPhone,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strContactPhone != c.strContactPhone || o.IsRIRPropChanged(_str_strContactPhone, c)) {
                  m.Add(_str_strContactPhone, o.ObjectIdent + _str_strContactPhone, o.ObjectIdent2 + _str_strContactPhone, o.ObjectIdent3 + _str_strContactPhone, "string", o.strContactPhone == null ? "" : o.strContactPhone.ToString(), o.IsReadOnly(_str_strContactPhone), o.IsInvisible(_str_strContactPhone), o.IsRequired(_str_strContactPhone));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strRegion, _formname = _str_strRegion, _type = "string",
              _get_func = o => o.strRegion,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strRegion != c.strRegion || o.IsRIRPropChanged(_str_strRegion, c)) {
                  m.Add(_str_strRegion, o.ObjectIdent + _str_strRegion, o.ObjectIdent2 + _str_strRegion, o.ObjectIdent3 + _str_strRegion, "string", o.strRegion == null ? "" : o.strRegion.ToString(), o.IsReadOnly(_str_strRegion), o.IsInvisible(_str_strRegion), o.IsRequired(_str_strRegion));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strRayon, _formname = _str_strRayon, _type = "string",
              _get_func = o => o.strRayon,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strRayon != c.strRayon || o.IsRIRPropChanged(_str_strRayon, c)) {
                  m.Add(_str_strRayon, o.ObjectIdent + _str_strRayon, o.ObjectIdent2 + _str_strRayon, o.ObjectIdent3 + _str_strRayon, "string", o.strRayon == null ? "" : o.strRayon.ToString(), o.IsReadOnly(_str_strRayon), o.IsInvisible(_str_strRayon), o.IsRequired(_str_strRayon));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strTownOrVillage, _formname = _str_strTownOrVillage, _type = "string",
              _get_func = o => o.strTownOrVillage,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strTownOrVillage != c.strTownOrVillage || o.IsRIRPropChanged(_str_strTownOrVillage, c)) {
                  m.Add(_str_strTownOrVillage, o.ObjectIdent + _str_strTownOrVillage, o.ObjectIdent2 + _str_strTownOrVillage, o.ObjectIdent3 + _str_strTownOrVillage, "string", o.strTownOrVillage == null ? "" : o.strTownOrVillage.ToString(), o.IsReadOnly(_str_strTownOrVillage), o.IsInvisible(_str_strTownOrVillage), o.IsRequired(_str_strTownOrVillage));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_AsSessionDiseases, _formname = _str_AsSessionDiseases, _type = "List<AsSessionDisease>",
              _get_func = o => o.AsSessionDiseases,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_Farm, _formname = _str_Farm, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
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
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Farm)]
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
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strOwnerLastName)]
        public string strOwnerLastName
        {
            get { return new Func<AsSessionFarm, string>(c => c.Farm.strOwnerLastName)(this); }
            
            set { Farm.strOwnerLastName = value; OnPropertyChanged(_str_strOwnerLastName); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strContactPhone)]
        public string strContactPhone
        {
            get { return new Func<AsSessionFarm, string>(c => c.Farm.strContactPhone)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strRegion)]
        public string strRegion
        {
            get { return new Func<AsSessionFarm, string>(c => c.Farm.Address.Region == null ? "" : c.Farm.Address.Region.strRegionName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strRayon)]
        public string strRayon
        {
            get { return new Func<AsSessionFarm, string>(c => c.Farm.Address.Rayon == null ? "" : c.Farm.Address.Rayon.strRayonName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strTownOrVillage)]
        public string strTownOrVillage
        {
            get { return new Func<AsSessionFarm, string>(c => c.Farm.Address.Settlement == null ? "" : c.Farm.Address.Settlement.strSettlementName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_AsSessionDiseases)]
        public List<AsSessionDisease> AsSessionDiseases
        {
            get { return new Func<AsSessionFarm, List<AsSessionDisease>>(c => c.Parent == null ? new List<AsSessionDisease>() : (c.Parent as AsSession).Diseases.Where(i => !i.IsMarkedToDelete).ToList())(this); }
            
        }
        
          [LocalizedDisplayName(_str_bDeleteInDetails)]
        public bool bDeleteInDetails
        {
            get { return m_bDeleteInDetails; }
            set { if (m_bDeleteInDetails != value) { m_bDeleteInDetails = value; OnPropertyChanged(_str_bDeleteInDetails); } }
        }
        private bool m_bDeleteInDetails;
        
          [LocalizedDisplayName(_str_bDeleteInSummary)]
        public bool bDeleteInSummary
        {
            get { return m_bDeleteInSummary; }
            set { if (m_bDeleteInSummary != value) { m_bDeleteInSummary = value; OnPropertyChanged(_str_bDeleteInSummary); } }
        }
        private bool m_bDeleteInSummary;
        
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
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as AsSessionFarm;
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
            var ret = base.Clone() as AsSessionFarm;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Farm != null)
              ret.Farm = _Farm.CloneWithSetup(manager, bRestricted) as FarmPanel;
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
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
        public object KeyLookup { get { return idfFarm; } }
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
        
            if (Farm != null) Farm.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Farm != null) _Farm.DeepAcceptChanges();
                
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
        
            if (_Farm != null) _Farm.SetChange();
                
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

        private bool IsRIRPropChanged(string fld, AsSessionFarm c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, AsSessionFarm c)
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
        

      

        public AsSessionFarm()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        
        private int? m_HACode;
        public int? _HACode { get { return m_HACode; } set { m_HACode = value; } }
        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
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
            
            if (e.PropertyName == _str_Farm)
                OnPropertyChanged(_str_strOwnerLastName);
                  
            if (e.PropertyName == _str_Farm)
                OnPropertyChanged(_str_strContactPhone);
                  
            if (e.PropertyName == _str_Farm)
                OnPropertyChanged(_str_strRegion);
                  
            if (e.PropertyName == _str_Farm)
                OnPropertyChanged(_str_strRayon);
                  
            if (e.PropertyName == _str_Farm)
                OnPropertyChanged(_str_strTownOrVillage);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_AsSessionDiseases);
                  
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
            AsSessionFarm obj = this;
            try
            {
            
                (new PredicateValidator("msgCantDeleteASFarm", "", "", "",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c => !(c.bDeleteInDetails && (c.Parent as AsSession).ASAnimalsSamples.Any(i => !i.IsMarkedToDelete && i.idfFarm == c.idfFarm))
                    );
            
                (new PredicateValidator("msgCantDelete", "", "", "",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c => !(c.bDeleteInSummary && (c.Parent as AsSession).SummaryItems.Any(i => !i.IsMarkedToDelete && i.idfFarm == c.idfFarm))
                    );
            
            }
            catch(ValidationModelException ex)
            {
                if (bReport && !OnValidation(ex))
                {
                    OnValidationEnd(ex);
                }
                
                return false;
            }
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            AsSessionFarm obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsSessionFarm obj = this;
            
                obj.blnIsDetailsFarm = new Func<AsSessionFarm, bool>(c => c.bDeleteInDetails ? false : c.blnIsDetailsFarm)(obj);
                obj.blnIsSummaryFarm = new Func<AsSessionFarm, bool>(c => c.bDeleteInSummary ? false : c.blnIsSummaryFarm)(obj);
                obj.m_IsMarkedToDelete = new Func<AsSessionFarm, bool>(c => !(c.blnIsDetailsFarm || c.blnIsSummaryFarm))(obj);
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

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
                if (_Farm != null)
                    _Farm._isValid &= value;
                
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_Farm != null)
                    _Farm.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<AsSessionFarm, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AsSessionFarm, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsSessionFarm, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsSessionFarm, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AsSessionFarm, bool>> m_isHiddenPersonalData;
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
        protected bool bNeedLookupRemove;
        ~AsSessionFarm()
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
                
                if (_Farm != null)
                    Farm.Dispose();
                
                
                if (bNeedLookupRemove)
                {
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
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
        
            if (_Farm != null) _Farm.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
            ParsedFormCollection(form);
        }
    
        #region Class for web grid
        public class AsSessionFarmGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public long? idfFarm { get; set; }
        
            public String strFarmCode { get; set; }
        
            public String strOwnerName { get; set; }
        
            public String strNationalName { get; set; }
        
            public string strContactPhone { get; set; }
        
            public string strRegion { get; set; }
        
            public string strRayon { get; set; }
        
            public string strTownOrVillage { get; set; }
        
        }
        public partial class AsSessionFarmGridModelList : List<AsSessionFarmGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public AsSessionFarmGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionFarm>, errMes);
            }
            public AsSessionFarmGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsSessionFarm>, errMes);
            }
            public AsSessionFarmGridModelList(long key, IEnumerable<AsSessionFarm> items)
            {
                LoadGridModelList(key, items, null);
            }
            public AsSessionFarmGridModelList(long key)
            {
                LoadGridModelList(key, new List<AsSessionFarm>(), null);
            }
            partial void filter(List<AsSessionFarm> items);
            private void LoadGridModelList(long key, IEnumerable<AsSessionFarm> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strFarmCode,_str_strOwnerName,_str_strNationalName,_str_strContactPhone,_str_strRegion,_str_strRayon,_str_strTownOrVillage};
                    
                Hiddens = new List<string> {_str_idfFarm};
                Keys = new List<string> {_str_idfFarm};
                Labels = new Dictionary<string, string> {{_str_strFarmCode, _str_strFarmCode},{_str_strOwnerName, _str_strOwnerName},{_str_strNationalName, _str_strNationalName},{_str_strContactPhone, _str_strContactPhone},{_str_strRegion, _str_strRegion},{_str_strRayon, _str_strRayon},{_str_strTownOrVillage, _str_strTownOrVillage}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                AsSessionFarm.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<AsSessionFarm>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AsSessionFarmGridModel()
                {
                    ItemKey=c.idfFarm,strFarmCode=c.strFarmCode,strOwnerName=c.strOwnerName,strNationalName=c.strNationalName,strContactPhone=c.strContactPhone,strRegion=c.strRegion,strRayon=c.strRayon,strTownOrVillage=c.strTownOrVillage
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
        : DataAccessor<AsSessionFarm>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<AsSessionFarm>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfFarm"; } }
            #endregion
        
            public delegate void on_action(AsSessionFarm obj);
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
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , HACode
                    
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<AsSessionFarm> SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , int? HACode
                
                )
            {
                return _SelectList(manager
                    , idfMonitoringSession
                    , HACode
                    
                    , delegate(AsSessionFarm obj)
                        {
                        }
                    , delegate(AsSessionFarm obj)
                        {
                        }
                    );
            }

            

            public List<AsSessionFarm> _SelectList(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfMonitoringSession
                    , HACode
                    
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<AsSessionFarm> _SelectListInternal(DbManagerProxy manager
                , Int64? idfMonitoringSession
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
                AsSessionFarm _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AsSessionFarm> objs = new List<AsSessionFarm>();
                    sets[0] = new MapResultSet(typeof(AsSessionFarm), objs);
                    
                    manager
                        .SetSpCommand("spASSessionFarms_SelectDetail"
                            , manager.Parameter("@idfMonitoringSession", idfMonitoringSession)
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
                        _obj = obj;
                        obj.m_CS = m_CS;
                        
                        obj._HACode = HACode;
                        
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
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsSessionFarm obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj._HACode = new Func<AsSessionFarm, int?>(c => (int)eidss.model.Enums.HACode.Livestock)(obj);
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadFarm(manager, obj);
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

    

            private AsSessionFarm _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                AsSessionFarm obj = null;
                try
                {
                    obj = AsSessionFarm.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    obj._HACode = HACode;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj._HACode = new Func<AsSessionFarm, int?>(c => (int)eidss.model.Enums.HACode.Livestock)(obj);
                obj.Farm = new Func<AsSessionFarm, DbManagerProxy, FarmPanel>((c,m) => FarmPanel.Accessor.Instance(null).CreateBySession(m, c, c.Parent as AsSession))(obj, manager);
                obj.idfMonitoringSession = new Func<AsSessionFarm, long?>(c => (Parent as AsSession).idfMonitoringSession)(obj);
                obj.Farm.idfMonitoringSession = new Func<AsSessionFarm, long?>(c => (Parent as AsSession).idfMonitoringSession)(obj);
                obj.Farm.intHACode = new Func<AsSessionFarm, int?>(c => (int)eidss.model.Enums.HACode.Livestock)(obj);
                obj.idfFarm = new Func<AsSessionFarm, long>(c => c.Farm.idfFarm)(obj);
                obj.idfRootFarm = new Func<AsSessionFarm, long?>(c => c.Farm.idfRootFarm)(obj);
                obj.strFarmCode = new Func<AsSessionFarm, string>(c => c.Farm.strFarmCode)(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
              if (obj.AsSessionDiseases.Select(i => i.idfsSpeciesType).Distinct().Count() == 1 && obj.AsSessionDiseases.Select(i => i.idfsSpeciesType).Distinct().Count(i => i.HasValue && i.Value > 0) == 1)
              {
                  var idfsSpeciesType = obj.AsSessionDiseases.FirstOrDefault(i => i.idfsSpeciesType.HasValue && i.idfsSpeciesType.Value > 0, i => i.idfsSpeciesType);
                  FarmPanel.Accessor.Instance(null).CreateHerd(manager, obj.Farm);
                  var herd = obj.Farm.FarmTree[1];
                  FarmPanel.Accessor.Instance(null).CreateSpecies(manager, obj.Farm, herd);
                  var species = obj.Farm.FarmTree[2];
                  species.SpeciesType = species.SpeciesTypeLookup.FirstOrDefault(i => i.idfsBaseReference == idfsSpeciesType);
              }
            
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

            
            public AsSessionFarm CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AsSessionFarm CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AsSessionFarm CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult TVIOk(DbManagerProxy manager, AsSessionFarm obj, List<object> pars)
            {
                
                return TVIOk(manager, obj
                    );
            }
            public ActResult TVIOk(DbManagerProxy manager, AsSessionFarm obj
                )
            {
                
              return (obj.GetAccessor() as IObjectValidator).Validate(manager, obj, true, true, true);
            
            }
            
      
            public ActResult TVICancel(DbManagerProxy manager, AsSessionFarm obj, List<object> pars)
            {
                
                return TVICancel(manager, obj
                    );
            }
            public ActResult TVICancel(DbManagerProxy manager, AsSessionFarm obj
                )
            {
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(AsSessionFarm obj, object newobj)
            {
                
                    if (newobj == null || newobj == obj.Farm)
                    {
                        var o = obj.Farm;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "idfFarm")
                                {
                                
                obj.idfFarm = new Func<AsSessionFarm, long>(c => c.Farm.idfFarm)(obj);
                                }
                            };
                        }    
                        
                    }
                            
                    if (newobj == null || newobj == obj.Farm)
                    {
                        var o = obj.Farm;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "strFarmCode")
                                {
                                
                obj.strFarmCode = new Func<AsSessionFarm, string>(c => c.Farm.strFarmCode)(obj);
                                }
                            };
                        }    
                        
                    }
                            
                    if (newobj == null || newobj == obj.Farm)
                    {
                        var o = obj.Farm;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "strFullNameCalc")
                                {
                                
                obj.strOwnerName = new Func<AsSessionFarm, string>(c => c.Farm.strFullNameCalc)(obj);
                                }
                            };
                        }    
                        
                    }
                            
                    if (newobj == null || newobj == obj.Farm)
                    {
                        var o = obj.Farm;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "strNationalName")
                                {
                                
                obj.strNationalName = new Func<AsSessionFarm, string>(c => c.Farm.strNationalName)(obj);
                                }
                            };
                        }    
                        
                    }
                            
            }
            
            private void _SetupHandlers(AsSessionFarm obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfRootFarm)
                        {
                    
                obj.Farm.idfRootFarm = new Func<AsSessionFarm, long?>(c => c.idfRootFarm)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfOwner)
                        {
                    
                obj.Farm.idfOwner = new Func<AsSessionFarm, long?>(c => c.idfOwner)(obj);
                        }
                    
                    };
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, AsSessionFarm obj)
            {
                
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
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        AsSessionFarm bo = obj as AsSessionFarm;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as AsSessionFarm, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsSessionFarm obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.Farm != null)
                    {
                        obj.Farm.MarkToDelete();
                        if (!FarmAccessor.Post(manager, obj.Farm, true))
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
                        if (obj.Farm != null) // forced load potential lazy subobject for new object
                            if (!FarmAccessor.Post(manager, obj.Farm, true))
                                return false;
                    }
                    else
                    {
                        if (obj._Farm != null) // do not load lazy subobject for existing object
                            if (!FarmAccessor.Post(manager, obj.Farm, true))
                                return false;
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
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
        
      
            protected ValidationModelException ChainsValidate(AsSessionFarm obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(AsSessionFarm obj, bool bRethrowException)
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
                return Validate(manager, obj as AsSessionFarm, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsSessionFarm obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new PredicateValidator("AsSession_SummaryFarmShouldContainSpecies", "", "", "",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c => c.Farm.FarmTree.Any(x => !x.IsMarkedToDelete && x.idfsPartyType == (int)PartyTypeEnum.Species)
                    );
            
                (new PredicateValidator("AsSession_HerdShouldContainSpecies", "", "", "",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c => !c.Farm.FarmTree.Any(x => !x.IsMarkedToDelete && x.idfsPartyType == (int)PartyTypeEnum.Herd && !c.Farm.FarmTree.Any(y => !y.IsMarkedToDelete && y.idfParentParty == x.idfParty && y.idfsPartyType == (int)PartyTypeEnum.Species))
                    );
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Farm != null)
                            FarmAccessor.Validate(manager, obj.Farm, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spASSessionFarms_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spASSessionFarm_Link";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsSessionFarm, bool>> RequiredByField = new Dictionary<string, Func<AsSessionFarm, bool>>();
            public static Dictionary<string, Func<AsSessionFarm, bool>> RequiredByProperty = new Dictionary<string, Func<AsSessionFarm, bool>>();
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
                
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_strNationalName, 200);
                Sizes.Add(_str_strOwnerName, 400);
                GridMeta.Add(new GridMetaItem(
                    _str_idfFarm,
                    _str_idfFarm, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFarmCode,
                    _str_strFarmCode, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strOwnerName,
                    _str_strOwnerName, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNationalName,
                    _str_strNationalName, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strContactPhone,
                    _str_strContactPhone, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRegion,
                    _str_strRegion, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRayon,
                    _str_strRayon, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTownOrVillage,
                    _str_strTownOrVillage, null, false, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "delete",
                    ActionTypes.Delete,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
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
                    "edit",
                    ActionTypes.Edit,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
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
                    "TVIOk",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).TVIOk(manager, (AsSessionFarm)c, pars),
                        
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
                    "asSession.formFarmDetailOk",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "TVICancel",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).TVICancel(manager, (AsSessionFarm)c, pars),
                        
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
                    "asSession.formDetailCancel",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
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
	