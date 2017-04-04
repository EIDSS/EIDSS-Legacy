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
    public abstract partial class FarmRootPanel : 
        EditableObject<FarmRootPanel>
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
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64? idfCase { get; set; }
        protected Int64? idfCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64? idfCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMonitoringSession)]
        [MapField(_str_idfMonitoringSession)]
        public abstract Int64? idfMonitoringSession { get; set; }
        protected Int64? idfMonitoringSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).OriginalValue; } }
        protected Int64? idfMonitoringSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMonitoringSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strContactPhone)]
        [MapField(_str_strContactPhone)]
        public abstract String strContactPhone { get; set; }
        protected String strContactPhone_Original { get { return ((EditableValue<String>)((dynamic)this)._strContactPhone).OriginalValue; } }
        protected String strContactPhone_Previous { get { return ((EditableValue<String>)((dynamic)this)._strContactPhone).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strInternationalName)]
        [MapField(_str_strInternationalName)]
        public abstract String strInternationalName { get; set; }
        protected String strInternationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._strInternationalName).OriginalValue; } }
        protected String strInternationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strInternationalName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strNationalName)]
        [MapField(_str_strNationalName)]
        public abstract String strNationalName { get; set; }
        protected String strNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._strNationalName).OriginalValue; } }
        protected String strNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNationalName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFarmCode)]
        [MapField(_str_strFarmCode)]
        public abstract String strFarmCode { get; set; }
        protected String strFarmCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).OriginalValue; } }
        protected String strFarmCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFarmCode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFax)]
        [MapField(_str_strFax)]
        public abstract String strFax { get; set; }
        protected String strFax_Original { get { return ((EditableValue<String>)((dynamic)this)._strFax).OriginalValue; } }
        protected String strFax_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFax).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strEmail)]
        [MapField(_str_strEmail)]
        public abstract String strEmail { get; set; }
        protected String strEmail_Original { get { return ((EditableValue<String>)((dynamic)this)._strEmail).OriginalValue; } }
        protected String strEmail_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEmail).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfFarmAddress)]
        [MapField(_str_idfFarmAddress)]
        public abstract Int64? idfFarmAddress { get; set; }
        protected Int64? idfFarmAddress_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFarmAddress).OriginalValue; } }
        protected Int64? idfFarmAddress_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFarmAddress).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfsGrazingPattern)]
        [MapField(_str_idfsGrazingPattern)]
        public abstract Int64? idfsGrazingPattern { get; set; }
        protected Int64? idfsGrazingPattern_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGrazingPattern).OriginalValue; } }
        protected Int64? idfsGrazingPattern_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGrazingPattern).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsMovementPattern)]
        [MapField(_str_idfsMovementPattern)]
        public abstract Int64? idfsMovementPattern { get; set; }
        protected Int64? idfsMovementPattern_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMovementPattern).OriginalValue; } }
        protected Int64? idfsMovementPattern_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMovementPattern).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsAvianFarmType)]
        [MapField(_str_idfsAvianFarmType)]
        public abstract Int64? idfsAvianFarmType { get; set; }
        protected Int64? idfsAvianFarmType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAvianFarmType).OriginalValue; } }
        protected Int64? idfsAvianFarmType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAvianFarmType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsAvianProductionType)]
        [MapField(_str_idfsAvianProductionType)]
        public abstract Int64? idfsAvianProductionType { get; set; }
        protected Int64? idfsAvianProductionType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAvianProductionType).OriginalValue; } }
        protected Int64? idfsAvianProductionType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAvianProductionType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsIntendedUse)]
        [MapField(_str_idfsIntendedUse)]
        public abstract Int64? idfsIntendedUse { get; set; }
        protected Int64? idfsIntendedUse_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsIntendedUse).OriginalValue; } }
        protected Int64? idfsIntendedUse_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsIntendedUse).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intBirdsPerBuilding)]
        [MapField(_str_intBirdsPerBuilding)]
        public abstract Int32? intBirdsPerBuilding { get; set; }
        protected Int32? intBirdsPerBuilding_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intBirdsPerBuilding).OriginalValue; } }
        protected Int32? intBirdsPerBuilding_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intBirdsPerBuilding).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intBuidings)]
        [MapField(_str_intBuidings)]
        public abstract Int32? intBuidings { get; set; }
        protected Int32? intBuidings_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intBuidings).OriginalValue; } }
        protected Int32? intBuidings_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intBuidings).PreviousValue; } }
                
        [LocalizedDisplayName("idfFarmOwner")]
        [MapField(_str_idfOwner)]
        public abstract Int64? idfOwner { get; set; }
        protected Int64? idfOwner_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOwner).OriginalValue; } }
        protected Int64? idfOwner_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOwner).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfRootOwner)]
        [MapField(_str_idfRootOwner)]
        public abstract Int64? idfRootOwner { get; set; }
        protected Int64? idfRootOwner_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootOwner).OriginalValue; } }
        protected Int64? idfRootOwner_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootOwner).PreviousValue; } }
                
        [LocalizedDisplayName("strFarmFullName")]
        [MapField(_str_strFullName)]
        public abstract String strFullName { get; set; }
        protected String strFullName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFullName).OriginalValue; } }
        protected String strFullName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFullName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOwnerLastName)]
        [MapField(_str_strOwnerLastName)]
        public abstract String strOwnerLastName { get; set; }
        protected String strOwnerLastName_Original { get { return ((EditableValue<String>)((dynamic)this)._strOwnerLastName).OriginalValue; } }
        protected String strOwnerLastName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOwnerLastName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOwnerFirstName)]
        [MapField(_str_strOwnerFirstName)]
        public abstract String strOwnerFirstName { get; set; }
        protected String strOwnerFirstName_Original { get { return ((EditableValue<String>)((dynamic)this)._strOwnerFirstName).OriginalValue; } }
        protected String strOwnerFirstName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOwnerFirstName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOwnerMiddleName)]
        [MapField(_str_strOwnerMiddleName)]
        public abstract String strOwnerMiddleName { get; set; }
        protected String strOwnerMiddleName_Original { get { return ((EditableValue<String>)((dynamic)this)._strOwnerMiddleName).OriginalValue; } }
        protected String strOwnerMiddleName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOwnerMiddleName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfObservation)]
        [MapField(_str_idfObservation)]
        public abstract Int64? idfObservation { get; set; }
        protected Int64? idfObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObservation).OriginalValue; } }
        protected Int64? idfObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObservation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64? idfsFormTemplate { get; set; }
        protected Int64? idfsFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64? idfsFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnRootFarm)]
        [MapField(_str_blnRootFarm)]
        public abstract Boolean? blnRootFarm { get; set; }
        protected Boolean? blnRootFarm_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnRootFarm).OriginalValue; } }
        protected Boolean? blnRootFarm_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnRootFarm).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32? intHACode { get; set; }
        protected Int32? intHACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32? intHACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datModificationDate)]
        [MapField(_str_datModificationDate)]
        public abstract DateTime? datModificationDate { get; set; }
        protected DateTime? datModificationDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationDate).OriginalValue; } }
        protected DateTime? datModificationDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datModificationForArchiveDate)]
        [MapField(_str_datModificationForArchiveDate)]
        public abstract DateTime? datModificationForArchiveDate { get; set; }
        protected DateTime? datModificationForArchiveDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationForArchiveDate).OriginalValue; } }
        protected DateTime? datModificationForArchiveDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationForArchiveDate).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<FarmRootPanel, object> _get_func;
            internal Action<FarmRootPanel, string> _set_func;
            internal Action<FarmRootPanel, FarmRootPanel, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfFarm = "idfFarm";
        internal const string _str_idfRootFarm = "idfRootFarm";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_strContactPhone = "strContactPhone";
        internal const string _str_strInternationalName = "strInternationalName";
        internal const string _str_strNationalName = "strNationalName";
        internal const string _str_strFarmCode = "strFarmCode";
        internal const string _str_strFax = "strFax";
        internal const string _str_strEmail = "strEmail";
        internal const string _str_idfFarmAddress = "idfFarmAddress";
        internal const string _str_idfsOwnershipStructure = "idfsOwnershipStructure";
        internal const string _str_idfsLivestockProductionType = "idfsLivestockProductionType";
        internal const string _str_idfsGrazingPattern = "idfsGrazingPattern";
        internal const string _str_idfsMovementPattern = "idfsMovementPattern";
        internal const string _str_idfsAvianFarmType = "idfsAvianFarmType";
        internal const string _str_idfsAvianProductionType = "idfsAvianProductionType";
        internal const string _str_idfsIntendedUse = "idfsIntendedUse";
        internal const string _str_intBirdsPerBuilding = "intBirdsPerBuilding";
        internal const string _str_intBuidings = "intBuidings";
        internal const string _str_idfOwner = "idfOwner";
        internal const string _str_idfRootOwner = "idfRootOwner";
        internal const string _str_strFullName = "strFullName";
        internal const string _str_strOwnerLastName = "strOwnerLastName";
        internal const string _str_strOwnerFirstName = "strOwnerFirstName";
        internal const string _str_strOwnerMiddleName = "strOwnerMiddleName";
        internal const string _str_idfObservation = "idfObservation";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_blnRootFarm = "blnRootFarm";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_datModificationDate = "datModificationDate";
        internal const string _str_datModificationForArchiveDate = "datModificationForArchiveDate";
        internal const string _str__blnAllowFarmReload = "_blnAllowFarmReload";
        internal const string _str_OwnershipStructure = "OwnershipStructure";
        internal const string _str_AvianFarmType = "AvianFarmType";
        internal const string _str_Address = "Address";
        internal const string _str_FarmLivestockTree = "FarmLivestockTree";
        internal const string _str_FarmAvianTree = "FarmAvianTree";
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
              _name = _str_idfCase, _formname = _str_idfCase, _type = "Int64?",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfCase != newval) o.idfCase = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, o.ObjectIdent2 + _str_idfCase, o.ObjectIdent3 + _str_idfCase, "Int64?", 
                    o.idfCase == null ? "" : o.idfCase.ToString(),                  
                  o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); 
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
              _name = _str_strContactPhone, _formname = _str_strContactPhone, _type = "String",
              _get_func = o => o.strContactPhone,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strContactPhone != newval) o.strContactPhone = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strContactPhone != c.strContactPhone || o.IsRIRPropChanged(_str_strContactPhone, c)) 
                  m.Add(_str_strContactPhone, o.ObjectIdent + _str_strContactPhone, o.ObjectIdent2 + _str_strContactPhone, o.ObjectIdent3 + _str_strContactPhone, "String", 
                    o.strContactPhone == null ? "" : o.strContactPhone.ToString(),                  
                  o.IsReadOnly(_str_strContactPhone), o.IsInvisible(_str_strContactPhone), o.IsRequired(_str_strContactPhone)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strInternationalName, _formname = _str_strInternationalName, _type = "String",
              _get_func = o => o.strInternationalName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strInternationalName != newval) o.strInternationalName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strInternationalName != c.strInternationalName || o.IsRIRPropChanged(_str_strInternationalName, c)) 
                  m.Add(_str_strInternationalName, o.ObjectIdent + _str_strInternationalName, o.ObjectIdent2 + _str_strInternationalName, o.ObjectIdent3 + _str_strInternationalName, "String", 
                    o.strInternationalName == null ? "" : o.strInternationalName.ToString(),                  
                  o.IsReadOnly(_str_strInternationalName), o.IsInvisible(_str_strInternationalName), o.IsRequired(_str_strInternationalName)); 
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
              _name = _str_strFax, _formname = _str_strFax, _type = "String",
              _get_func = o => o.strFax,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFax != newval) o.strFax = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFax != c.strFax || o.IsRIRPropChanged(_str_strFax, c)) 
                  m.Add(_str_strFax, o.ObjectIdent + _str_strFax, o.ObjectIdent2 + _str_strFax, o.ObjectIdent3 + _str_strFax, "String", 
                    o.strFax == null ? "" : o.strFax.ToString(),                  
                  o.IsReadOnly(_str_strFax), o.IsInvisible(_str_strFax), o.IsRequired(_str_strFax)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strEmail, _formname = _str_strEmail, _type = "String",
              _get_func = o => o.strEmail,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strEmail != newval) o.strEmail = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strEmail != c.strEmail || o.IsRIRPropChanged(_str_strEmail, c)) 
                  m.Add(_str_strEmail, o.ObjectIdent + _str_strEmail, o.ObjectIdent2 + _str_strEmail, o.ObjectIdent3 + _str_strEmail, "String", 
                    o.strEmail == null ? "" : o.strEmail.ToString(),                  
                  o.IsReadOnly(_str_strEmail), o.IsInvisible(_str_strEmail), o.IsRequired(_str_strEmail)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfFarmAddress, _formname = _str_idfFarmAddress, _type = "Int64?",
              _get_func = o => o.idfFarmAddress,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfFarmAddress != newval) o.idfFarmAddress = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfFarmAddress != c.idfFarmAddress || o.IsRIRPropChanged(_str_idfFarmAddress, c)) 
                  m.Add(_str_idfFarmAddress, o.ObjectIdent + _str_idfFarmAddress, o.ObjectIdent2 + _str_idfFarmAddress, o.ObjectIdent3 + _str_idfFarmAddress, "Int64?", 
                    o.idfFarmAddress == null ? "" : o.idfFarmAddress.ToString(),                  
                  o.IsReadOnly(_str_idfFarmAddress), o.IsInvisible(_str_idfFarmAddress), o.IsRequired(_str_idfFarmAddress)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsOwnershipStructure, _formname = _str_idfsOwnershipStructure, _type = "Int64?",
              _get_func = o => o.idfsOwnershipStructure,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsOwnershipStructure != newval) 
                  o.OwnershipStructure = o.OwnershipStructureLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsOwnershipStructure != newval) o.idfsOwnershipStructure = newval; },
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
              _name = _str_idfsGrazingPattern, _formname = _str_idfsGrazingPattern, _type = "Int64?",
              _get_func = o => o.idfsGrazingPattern,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsGrazingPattern != newval) o.idfsGrazingPattern = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsGrazingPattern != c.idfsGrazingPattern || o.IsRIRPropChanged(_str_idfsGrazingPattern, c)) 
                  m.Add(_str_idfsGrazingPattern, o.ObjectIdent + _str_idfsGrazingPattern, o.ObjectIdent2 + _str_idfsGrazingPattern, o.ObjectIdent3 + _str_idfsGrazingPattern, "Int64?", 
                    o.idfsGrazingPattern == null ? "" : o.idfsGrazingPattern.ToString(),                  
                  o.IsReadOnly(_str_idfsGrazingPattern), o.IsInvisible(_str_idfsGrazingPattern), o.IsRequired(_str_idfsGrazingPattern)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsMovementPattern, _formname = _str_idfsMovementPattern, _type = "Int64?",
              _get_func = o => o.idfsMovementPattern,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsMovementPattern != newval) o.idfsMovementPattern = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsMovementPattern != c.idfsMovementPattern || o.IsRIRPropChanged(_str_idfsMovementPattern, c)) 
                  m.Add(_str_idfsMovementPattern, o.ObjectIdent + _str_idfsMovementPattern, o.ObjectIdent2 + _str_idfsMovementPattern, o.ObjectIdent3 + _str_idfsMovementPattern, "Int64?", 
                    o.idfsMovementPattern == null ? "" : o.idfsMovementPattern.ToString(),                  
                  o.IsReadOnly(_str_idfsMovementPattern), o.IsInvisible(_str_idfsMovementPattern), o.IsRequired(_str_idfsMovementPattern)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAvianFarmType, _formname = _str_idfsAvianFarmType, _type = "Int64?",
              _get_func = o => o.idfsAvianFarmType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsAvianFarmType != newval) 
                  o.AvianFarmType = o.AvianFarmTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsAvianFarmType != newval) o.idfsAvianFarmType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsAvianFarmType != c.idfsAvianFarmType || o.IsRIRPropChanged(_str_idfsAvianFarmType, c)) 
                  m.Add(_str_idfsAvianFarmType, o.ObjectIdent + _str_idfsAvianFarmType, o.ObjectIdent2 + _str_idfsAvianFarmType, o.ObjectIdent3 + _str_idfsAvianFarmType, "Int64?", 
                    o.idfsAvianFarmType == null ? "" : o.idfsAvianFarmType.ToString(),                  
                  o.IsReadOnly(_str_idfsAvianFarmType), o.IsInvisible(_str_idfsAvianFarmType), o.IsRequired(_str_idfsAvianFarmType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAvianProductionType, _formname = _str_idfsAvianProductionType, _type = "Int64?",
              _get_func = o => o.idfsAvianProductionType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsAvianProductionType != newval) o.idfsAvianProductionType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsAvianProductionType != c.idfsAvianProductionType || o.IsRIRPropChanged(_str_idfsAvianProductionType, c)) 
                  m.Add(_str_idfsAvianProductionType, o.ObjectIdent + _str_idfsAvianProductionType, o.ObjectIdent2 + _str_idfsAvianProductionType, o.ObjectIdent3 + _str_idfsAvianProductionType, "Int64?", 
                    o.idfsAvianProductionType == null ? "" : o.idfsAvianProductionType.ToString(),                  
                  o.IsReadOnly(_str_idfsAvianProductionType), o.IsInvisible(_str_idfsAvianProductionType), o.IsRequired(_str_idfsAvianProductionType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsIntendedUse, _formname = _str_idfsIntendedUse, _type = "Int64?",
              _get_func = o => o.idfsIntendedUse,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsIntendedUse != newval) o.idfsIntendedUse = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsIntendedUse != c.idfsIntendedUse || o.IsRIRPropChanged(_str_idfsIntendedUse, c)) 
                  m.Add(_str_idfsIntendedUse, o.ObjectIdent + _str_idfsIntendedUse, o.ObjectIdent2 + _str_idfsIntendedUse, o.ObjectIdent3 + _str_idfsIntendedUse, "Int64?", 
                    o.idfsIntendedUse == null ? "" : o.idfsIntendedUse.ToString(),                  
                  o.IsReadOnly(_str_idfsIntendedUse), o.IsInvisible(_str_idfsIntendedUse), o.IsRequired(_str_idfsIntendedUse)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intBirdsPerBuilding, _formname = _str_intBirdsPerBuilding, _type = "Int32?",
              _get_func = o => o.intBirdsPerBuilding,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intBirdsPerBuilding != newval) o.intBirdsPerBuilding = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intBirdsPerBuilding != c.intBirdsPerBuilding || o.IsRIRPropChanged(_str_intBirdsPerBuilding, c)) 
                  m.Add(_str_intBirdsPerBuilding, o.ObjectIdent + _str_intBirdsPerBuilding, o.ObjectIdent2 + _str_intBirdsPerBuilding, o.ObjectIdent3 + _str_intBirdsPerBuilding, "Int32?", 
                    o.intBirdsPerBuilding == null ? "" : o.intBirdsPerBuilding.ToString(),                  
                  o.IsReadOnly(_str_intBirdsPerBuilding), o.IsInvisible(_str_intBirdsPerBuilding), o.IsRequired(_str_intBirdsPerBuilding)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intBuidings, _formname = _str_intBuidings, _type = "Int32?",
              _get_func = o => o.intBuidings,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intBuidings != newval) o.intBuidings = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intBuidings != c.intBuidings || o.IsRIRPropChanged(_str_intBuidings, c)) 
                  m.Add(_str_intBuidings, o.ObjectIdent + _str_intBuidings, o.ObjectIdent2 + _str_intBuidings, o.ObjectIdent3 + _str_intBuidings, "Int32?", 
                    o.intBuidings == null ? "" : o.intBuidings.ToString(),                  
                  o.IsReadOnly(_str_intBuidings), o.IsInvisible(_str_intBuidings), o.IsRequired(_str_intBuidings)); 
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
              _name = _str_idfRootOwner, _formname = _str_idfRootOwner, _type = "Int64?",
              _get_func = o => o.idfRootOwner,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfRootOwner != newval) o.idfRootOwner = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfRootOwner != c.idfRootOwner || o.IsRIRPropChanged(_str_idfRootOwner, c)) 
                  m.Add(_str_idfRootOwner, o.ObjectIdent + _str_idfRootOwner, o.ObjectIdent2 + _str_idfRootOwner, o.ObjectIdent3 + _str_idfRootOwner, "Int64?", 
                    o.idfRootOwner == null ? "" : o.idfRootOwner.ToString(),                  
                  o.IsReadOnly(_str_idfRootOwner), o.IsInvisible(_str_idfRootOwner), o.IsRequired(_str_idfRootOwner)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFullName, _formname = _str_strFullName, _type = "String",
              _get_func = o => o.strFullName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFullName != newval) o.strFullName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFullName != c.strFullName || o.IsRIRPropChanged(_str_strFullName, c)) 
                  m.Add(_str_strFullName, o.ObjectIdent + _str_strFullName, o.ObjectIdent2 + _str_strFullName, o.ObjectIdent3 + _str_strFullName, "String", 
                    o.strFullName == null ? "" : o.strFullName.ToString(),                  
                  o.IsReadOnly(_str_strFullName), o.IsInvisible(_str_strFullName), o.IsRequired(_str_strFullName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOwnerLastName, _formname = _str_strOwnerLastName, _type = "String",
              _get_func = o => o.strOwnerLastName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOwnerLastName != newval) o.strOwnerLastName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strOwnerLastName != c.strOwnerLastName || o.IsRIRPropChanged(_str_strOwnerLastName, c)) 
                  m.Add(_str_strOwnerLastName, o.ObjectIdent + _str_strOwnerLastName, o.ObjectIdent2 + _str_strOwnerLastName, o.ObjectIdent3 + _str_strOwnerLastName, "String", 
                    o.strOwnerLastName == null ? "" : o.strOwnerLastName.ToString(),                  
                  o.IsReadOnly(_str_strOwnerLastName), o.IsInvisible(_str_strOwnerLastName), o.IsRequired(_str_strOwnerLastName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOwnerFirstName, _formname = _str_strOwnerFirstName, _type = "String",
              _get_func = o => o.strOwnerFirstName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOwnerFirstName != newval) o.strOwnerFirstName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strOwnerFirstName != c.strOwnerFirstName || o.IsRIRPropChanged(_str_strOwnerFirstName, c)) 
                  m.Add(_str_strOwnerFirstName, o.ObjectIdent + _str_strOwnerFirstName, o.ObjectIdent2 + _str_strOwnerFirstName, o.ObjectIdent3 + _str_strOwnerFirstName, "String", 
                    o.strOwnerFirstName == null ? "" : o.strOwnerFirstName.ToString(),                  
                  o.IsReadOnly(_str_strOwnerFirstName), o.IsInvisible(_str_strOwnerFirstName), o.IsRequired(_str_strOwnerFirstName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOwnerMiddleName, _formname = _str_strOwnerMiddleName, _type = "String",
              _get_func = o => o.strOwnerMiddleName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOwnerMiddleName != newval) o.strOwnerMiddleName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strOwnerMiddleName != c.strOwnerMiddleName || o.IsRIRPropChanged(_str_strOwnerMiddleName, c)) 
                  m.Add(_str_strOwnerMiddleName, o.ObjectIdent + _str_strOwnerMiddleName, o.ObjectIdent2 + _str_strOwnerMiddleName, o.ObjectIdent3 + _str_strOwnerMiddleName, "String", 
                    o.strOwnerMiddleName == null ? "" : o.strOwnerMiddleName.ToString(),                  
                  o.IsReadOnly(_str_strOwnerMiddleName), o.IsInvisible(_str_strOwnerMiddleName), o.IsRequired(_str_strOwnerMiddleName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfObservation, _formname = _str_idfObservation, _type = "Int64?",
              _get_func = o => o.idfObservation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfObservation != newval) o.idfObservation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfObservation != c.idfObservation || o.IsRIRPropChanged(_str_idfObservation, c)) 
                  m.Add(_str_idfObservation, o.ObjectIdent + _str_idfObservation, o.ObjectIdent2 + _str_idfObservation, o.ObjectIdent3 + _str_idfObservation, "Int64?", 
                    o.idfObservation == null ? "" : o.idfObservation.ToString(),                  
                  o.IsReadOnly(_str_idfObservation), o.IsInvisible(_str_idfObservation), o.IsRequired(_str_idfObservation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsFormTemplate, _formname = _str_idfsFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsFormTemplate != newval) o.idfsFormTemplate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, o.ObjectIdent2 + _str_idfsFormTemplate, o.ObjectIdent3 + _str_idfsFormTemplate, "Int64?", 
                    o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnRootFarm, _formname = _str_blnRootFarm, _type = "Boolean?",
              _get_func = o => o.blnRootFarm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnRootFarm != newval) o.blnRootFarm = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnRootFarm != c.blnRootFarm || o.IsRIRPropChanged(_str_blnRootFarm, c)) 
                  m.Add(_str_blnRootFarm, o.ObjectIdent + _str_blnRootFarm, o.ObjectIdent2 + _str_blnRootFarm, o.ObjectIdent3 + _str_blnRootFarm, "Boolean?", 
                    o.blnRootFarm == null ? "" : o.blnRootFarm.ToString(),                  
                  o.IsReadOnly(_str_blnRootFarm), o.IsInvisible(_str_blnRootFarm), o.IsRequired(_str_blnRootFarm)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHACode, _formname = _str_intHACode, _type = "Int32?",
              _get_func = o => o.intHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intHACode != newval) o.intHACode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_intHACode, c)) 
                  m.Add(_str_intHACode, o.ObjectIdent + _str_intHACode, o.ObjectIdent2 + _str_intHACode, o.ObjectIdent3 + _str_intHACode, "Int32?", 
                    o.intHACode == null ? "" : o.intHACode.ToString(),                  
                  o.IsReadOnly(_str_intHACode), o.IsInvisible(_str_intHACode), o.IsRequired(_str_intHACode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datModificationDate, _formname = _str_datModificationDate, _type = "DateTime?",
              _get_func = o => o.datModificationDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datModificationDate != newval) o.datModificationDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datModificationDate != c.datModificationDate || o.IsRIRPropChanged(_str_datModificationDate, c)) 
                  m.Add(_str_datModificationDate, o.ObjectIdent + _str_datModificationDate, o.ObjectIdent2 + _str_datModificationDate, o.ObjectIdent3 + _str_datModificationDate, "DateTime?", 
                    o.datModificationDate == null ? "" : o.datModificationDate.ToString(),                  
                  o.IsReadOnly(_str_datModificationDate), o.IsInvisible(_str_datModificationDate), o.IsRequired(_str_datModificationDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datModificationForArchiveDate, _formname = _str_datModificationForArchiveDate, _type = "DateTime?",
              _get_func = o => o.datModificationForArchiveDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datModificationForArchiveDate != newval) o.datModificationForArchiveDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datModificationForArchiveDate != c.datModificationForArchiveDate || o.IsRIRPropChanged(_str_datModificationForArchiveDate, c)) 
                  m.Add(_str_datModificationForArchiveDate, o.ObjectIdent + _str_datModificationForArchiveDate, o.ObjectIdent2 + _str_datModificationForArchiveDate, o.ObjectIdent3 + _str_datModificationForArchiveDate, "DateTime?", 
                    o.datModificationForArchiveDate == null ? "" : o.datModificationForArchiveDate.ToString(),                  
                  o.IsReadOnly(_str_datModificationForArchiveDate), o.IsInvisible(_str_datModificationForArchiveDate), o.IsRequired(_str_datModificationForArchiveDate)); 
                  }
              }, 
        
            new field_info {
              _name = _str__blnAllowFarmReload, _formname = _str__blnAllowFarmReload, _type = "bool",
              _get_func = o => o._blnAllowFarmReload,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o._blnAllowFarmReload != newval) o._blnAllowFarmReload = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o._blnAllowFarmReload != c._blnAllowFarmReload || o.IsRIRPropChanged(_str__blnAllowFarmReload, c)) {
                  m.Add(_str__blnAllowFarmReload, o.ObjectIdent + _str__blnAllowFarmReload, o.ObjectIdent2 + _str__blnAllowFarmReload, o.ObjectIdent3 + _str__blnAllowFarmReload,  "bool", 
                    o._blnAllowFarmReload == null ? "" : o._blnAllowFarmReload.ToString(),                  
                    o.IsReadOnly(_str__blnAllowFarmReload), o.IsInvisible(_str__blnAllowFarmReload), o.IsRequired(_str__blnAllowFarmReload));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_OwnershipStructure, _formname = _str_OwnershipStructure, _type = "Lookup",
              _get_func = o => { if (o.OwnershipStructure == null) return null; return o.OwnershipStructure.idfsBaseReference; },
              _set_func = (o, val) => { o.OwnershipStructure = o.OwnershipStructureLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_OwnershipStructure, c);
                if (o.idfsOwnershipStructure != c.idfsOwnershipStructure || o.IsRIRPropChanged(_str_OwnershipStructure, c) || bChangeLookupContent) {
                  m.Add(_str_OwnershipStructure, o.ObjectIdent + _str_OwnershipStructure, o.ObjectIdent2 + _str_OwnershipStructure, o.ObjectIdent3 + _str_OwnershipStructure, "Lookup", o.idfsOwnershipStructure == null ? "" : o.idfsOwnershipStructure.ToString(), o.IsReadOnly(_str_OwnershipStructure), o.IsInvisible(_str_OwnershipStructure), o.IsRequired(_str_OwnershipStructure),
                  bChangeLookupContent ? o.OwnershipStructureLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_OwnershipStructure + "Lookup", _formname = _str_OwnershipStructure + "Lookup", _type = "LookupContent",
              _get_func = o => o.OwnershipStructureLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_AvianFarmType, _formname = _str_AvianFarmType, _type = "Lookup",
              _get_func = o => { if (o.AvianFarmType == null) return null; return o.AvianFarmType.idfsBaseReference; },
              _set_func = (o, val) => { o.AvianFarmType = o.AvianFarmTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AvianFarmType, c);
                if (o.idfsAvianFarmType != c.idfsAvianFarmType || o.IsRIRPropChanged(_str_AvianFarmType, c) || bChangeLookupContent) {
                  m.Add(_str_AvianFarmType, o.ObjectIdent + _str_AvianFarmType, o.ObjectIdent2 + _str_AvianFarmType, o.ObjectIdent3 + _str_AvianFarmType, "Lookup", o.idfsAvianFarmType == null ? "" : o.idfsAvianFarmType.ToString(), o.IsReadOnly(_str_AvianFarmType), o.IsInvisible(_str_AvianFarmType), o.IsRequired(_str_AvianFarmType),
                  bChangeLookupContent ? o.AvianFarmTypeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AvianFarmType + "Lookup", _formname = _str_AvianFarmType + "Lookup", _type = "LookupContent",
              _get_func = o => o.AvianFarmTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_FarmLivestockTree, _formname = _str_FarmLivestockTree, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.FarmLivestockTree.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.FarmLivestockTree.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.FarmLivestockTree.Count != c.FarmLivestockTree.Count || o.IsReadOnly(_str_FarmLivestockTree) != c.IsReadOnly(_str_FarmLivestockTree) || o.IsInvisible(_str_FarmLivestockTree) != c.IsInvisible(_str_FarmLivestockTree) || o.IsRequired(_str_FarmLivestockTree) != c._isRequired(o.m_isRequired, _str_FarmLivestockTree)) {
                  m.Add(_str_FarmLivestockTree, o.ObjectIdent + _str_FarmLivestockTree, o.ObjectIdent2 + _str_FarmLivestockTree, o.ObjectIdent3 + _str_FarmLivestockTree, "Child", o.idfFarm == null ? "" : o.idfFarm.ToString(), o.IsReadOnly(_str_FarmLivestockTree), o.IsInvisible(_str_FarmLivestockTree), o.IsRequired(_str_FarmLivestockTree)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_FarmAvianTree, _formname = _str_FarmAvianTree, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.FarmAvianTree.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.FarmAvianTree.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.FarmAvianTree.Count != c.FarmAvianTree.Count || o.IsReadOnly(_str_FarmAvianTree) != c.IsReadOnly(_str_FarmAvianTree) || o.IsInvisible(_str_FarmAvianTree) != c.IsInvisible(_str_FarmAvianTree) || o.IsRequired(_str_FarmAvianTree) != c._isRequired(o.m_isRequired, _str_FarmAvianTree)) {
                  m.Add(_str_FarmAvianTree, o.ObjectIdent + _str_FarmAvianTree, o.ObjectIdent2 + _str_FarmAvianTree, o.ObjectIdent3 + _str_FarmAvianTree, "Child", o.idfFarm == null ? "" : o.idfFarm.ToString(), o.IsReadOnly(_str_FarmAvianTree), o.IsInvisible(_str_FarmAvianTree), o.IsRequired(_str_FarmAvianTree)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Address, _formname = _str_Address, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.Address != null) o.Address._compare(c.Address, m); }
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
            FarmRootPanel obj = (FarmRootPanel)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Address)]
        [Relation(typeof(Address), eidss.model.Schema.Address._str_idfGeoLocation, _str_idfFarmAddress)]
        public Address Address
        {
            get 
            {   
                if (!_AddressLoaded)
                {
                    _AddressLoaded = true;
                    _getAccessor()._LoadAddress(this);
                    if (_Address != null) 
                        _Address.Parent = this;
                }
                return _Address; 
            }
            set 
            {   
                if (!_AddressLoaded) { _AddressLoaded = true; }
                _Address = value;
                if (_Address != null) 
                { 
                    _Address.m_ObjectName = _str_Address;
                    _Address.Parent = this;
                }
                idfFarmAddress = _Address == null 
                        ? new Int64?()
                        : _Address.idfGeoLocation;
                
            }
        }
        protected Address _Address;
                    
        private bool _AddressLoaded = false;
                    
        [LocalizedDisplayName(_str_FarmLivestockTree)]
        [Relation(typeof(RootFarmTree), "", _str_idfFarm)]
        public EditableList<RootFarmTree> FarmLivestockTree
        {
            get 
            {   
                return _FarmLivestockTree; 
            }
            set 
            {
                _FarmLivestockTree = value;
            }
        }
        protected EditableList<RootFarmTree> _FarmLivestockTree = new EditableList<RootFarmTree>();
                    
        [LocalizedDisplayName(_str_FarmAvianTree)]
        [Relation(typeof(RootFarmTree), "", _str_idfFarm)]
        public EditableList<RootFarmTree> FarmAvianTree
        {
            get 
            {   
                return _FarmAvianTree; 
            }
            set 
            {
                _FarmAvianTree = value;
            }
        }
        protected EditableList<RootFarmTree> _FarmAvianTree = new EditableList<RootFarmTree>();
                    
        [LocalizedDisplayName(_str_OwnershipStructure)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsOwnershipStructure)]
        public BaseReference OwnershipStructure
        {
            get { return _OwnershipStructure == null ? null : ((long)_OwnershipStructure.Key == 0 ? null : _OwnershipStructure); }
            set 
            { 
                var oldVal = _OwnershipStructure;
                _OwnershipStructure = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_OwnershipStructure != oldVal)
                {
                    if (idfsOwnershipStructure != (_OwnershipStructure == null
                            ? new Int64?()
                            : (Int64?)_OwnershipStructure.idfsBaseReference))
                        idfsOwnershipStructure = _OwnershipStructure == null 
                            ? new Int64?()
                            : (Int64?)_OwnershipStructure.idfsBaseReference; 
                    OnPropertyChanged(_str_OwnershipStructure); 
                }
            }
        }
        private BaseReference _OwnershipStructure;

        
        public BaseReferenceList OwnershipStructureLookup
        {
            get { return _OwnershipStructureLookup; }
        }
        private BaseReferenceList _OwnershipStructureLookup = new BaseReferenceList("rftOwnershipType");
            
        [LocalizedDisplayName(_str_AvianFarmType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAvianFarmType)]
        public BaseReference AvianFarmType
        {
            get { return _AvianFarmType == null ? null : ((long)_AvianFarmType.Key == 0 ? null : _AvianFarmType); }
            set 
            { 
                var oldVal = _AvianFarmType;
                _AvianFarmType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AvianFarmType != oldVal)
                {
                    if (idfsAvianFarmType != (_AvianFarmType == null
                            ? new Int64?()
                            : (Int64?)_AvianFarmType.idfsBaseReference))
                        idfsAvianFarmType = _AvianFarmType == null 
                            ? new Int64?()
                            : (Int64?)_AvianFarmType.idfsBaseReference; 
                    OnPropertyChanged(_str_AvianFarmType); 
                }
            }
        }
        private BaseReference _AvianFarmType;

        
        public BaseReferenceList AvianFarmTypeLookup
        {
            get { return _AvianFarmTypeLookup; }
        }
        private BaseReferenceList _AvianFarmTypeLookup = new BaseReferenceList("rftAvianFarmType");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_OwnershipStructure:
                    return new BvSelectList(OwnershipStructureLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, OwnershipStructure, _str_idfsOwnershipStructure);
            
                case _str_AvianFarmType:
                    return new BvSelectList(AvianFarmTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AvianFarmType, _str_idfsAvianFarmType);
            
                case _str_FarmLivestockTree:
                    return new BvSelectList(FarmLivestockTree, "", "", null, "");
            
                case _str_FarmAvianTree:
                    return new BvSelectList(FarmAvianTree, "", "", null, "");
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str__blnAllowFarmReload)]
        public bool _blnAllowFarmReload
        {
            get { return m__blnAllowFarmReload; }
            set { if (m__blnAllowFarmReload != value) { m__blnAllowFarmReload = value; OnPropertyChanged(_str__blnAllowFarmReload); } }
        }
        private bool m__blnAllowFarmReload;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "FarmRootPanel";

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
        
            if (_Address != null) { _Address.Parent = this; }
                FarmLivestockTree.ForEach(c => { c.Parent = this; });
                FarmAvianTree.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as FarmRootPanel;
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
            var ret = base.Clone() as FarmRootPanel;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Address != null)
              ret.Address = _Address.CloneWithSetup(manager, bRestricted) as Address;
                
            if (_FarmLivestockTree != null && _FarmLivestockTree.Count > 0)
            {
              ret.FarmLivestockTree.Clear();
              _FarmLivestockTree.ForEach(c => ret.FarmLivestockTree.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_FarmAvianTree != null && _FarmAvianTree.Count > 0)
            {
              ret.FarmAvianTree.Clear();
              _FarmAvianTree.ForEach(c => ret.FarmAvianTree.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public FarmRootPanel CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as FarmRootPanel;
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
        
                    || (_Address != null && _Address.HasChanges)
                
                    || FarmLivestockTree.IsDirty
                    || FarmLivestockTree.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || FarmAvianTree.IsDirty
                    || FarmAvianTree.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsOwnershipStructure_OwnershipStructure = idfsOwnershipStructure;
            var _prev_idfsAvianFarmType_AvianFarmType = idfsAvianFarmType;
            base.RejectChanges();
        
            if (_prev_idfsOwnershipStructure_OwnershipStructure != idfsOwnershipStructure)
            {
                _OwnershipStructure = _OwnershipStructureLookup.FirstOrDefault(c => c.idfsBaseReference == idfsOwnershipStructure);
            }
            if (_prev_idfsAvianFarmType_AvianFarmType != idfsAvianFarmType)
            {
                _AvianFarmType = _AvianFarmTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAvianFarmType);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (Address != null) Address.DeepRejectChanges();
                FarmLivestockTree.DeepRejectChanges();
                FarmAvianTree.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Address != null) _Address.DeepAcceptChanges();
                FarmLivestockTree.DeepAcceptChanges();
                FarmAvianTree.DeepAcceptChanges();
                
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
        
            if (_Address != null) _Address.SetChange();
                FarmLivestockTree.ForEach(c => c.SetChange());
                FarmAvianTree.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, FarmRootPanel c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, FarmRootPanel c)
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
        

      

        public FarmRootPanel()
        {
            
            m_permissions = new Permissions(this);
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(FarmRootPanel_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(FarmRootPanel_PropertyChanged);
        }
        private void FarmRootPanel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as FarmRootPanel).Changed(e.PropertyName);
            
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
            FarmRootPanel obj = this;
            
        }
        private void _DeletedExtenders()
        {
            FarmRootPanel obj = this;
            
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

    
        private static string[] readonly_names1 = "strFarmCode".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<FarmRootPanel, bool>(c => true)(this);
            
            return ReadOnly || new Func<FarmRootPanel, bool>(c => false)(this);
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
                if (_Address != null)
                    _Address._isValid &= value;
                
                foreach(var o in _FarmLivestockTree)
                    o._isValid &= value;
                
                foreach(var o in _FarmAvianTree)
                    o._isValid &= value;
                
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_Address != null)
                    _Address.ReadOnly |= value;
                
                foreach(var o in _FarmLivestockTree)
                    o.ReadOnly |= value;
                
                foreach(var o in _FarmAvianTree)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<FarmRootPanel, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<FarmRootPanel, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<FarmRootPanel, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<FarmRootPanel, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<FarmRootPanel, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<FarmRootPanel, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<FarmRootPanel, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~FarmRootPanel()
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
                
                if (_Address != null)
                    Address.Dispose();
                
                if (!bIsClone)
                {
                    FarmLivestockTree.ForEach(c => c.Dispose());
                }
                FarmLivestockTree.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    FarmAvianTree.ForEach(c => c.Dispose());
                }
                FarmAvianTree.ClearModelListEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("rftOwnershipType", this);
                
                LookupManager.RemoveObject("rftAvianFarmType", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftOwnershipType")
                _getAccessor().LoadLookup_OwnershipStructure(manager, this);
            
            if (lookup_object == "rftAvianFarmType")
                _getAccessor().LoadLookup_AvianFarmType(manager, this);
            
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
        
            if (_Address != null) _Address.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_FarmLivestockTree != null) _FarmLivestockTree.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_FarmAvianTree != null) _FarmAvianTree.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<FarmRootPanel>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<FarmRootPanel>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<FarmRootPanel>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfFarm"; } }
            #endregion
        
            public delegate void on_action(FarmRootPanel obj);
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
            private Address.Accessor AddressAccessor { get { return eidss.model.Schema.Address.Accessor.Instance(m_CS); } }
            private RootFarmTree.Accessor FarmLivestockTreeAccessor { get { return eidss.model.Schema.RootFarmTree.Accessor.Instance(m_CS); } }
            private RootFarmTree.Accessor FarmAvianTreeAccessor { get { return eidss.model.Schema.RootFarmTree.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor OwnershipStructureAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AvianFarmTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            

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
            public virtual FarmRootPanel SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
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

            
            public virtual FarmRootPanel SelectByKey(DbManagerProxy manager
                , Int64? idfFarm
                , int? HACode = null
                
                )
            {
                return _SelectByKey(manager
                    , idfFarm
                    , HACode
                    
                    , null, null
                    );
            }
            

            private FarmRootPanel _SelectByKey(DbManagerProxy manager
                , Int64? idfFarm
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfFarm
                    , HACode
                    
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual FarmRootPanel _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfFarm
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<FarmRootPanel> objs = new List<FarmRootPanel>();
                sets[0] = new MapResultSet(typeof(FarmRootPanel), objs);
                FarmRootPanel obj = null;
                try
                {
                    manager
                        .SetSpCommand("spFarmPanel_SelectDetail"
                            , manager.Parameter("@idfFarm", idfFarm)
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    obj = objs[0];
                    obj.m_CS = m_CS;
                    
                    obj._HACode = HACode;
                    
                  
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
                    throw DbModelException.Create(obj, e);
                  }
                
            }
    
            private void _SetupAddChildHandlerFarmLivestockTree(FarmRootPanel obj)
            {
                obj.FarmLivestockTree.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerFarmAvianTree(FarmRootPanel obj)
            {
                obj.FarmAvianTree.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadAddress(FarmRootPanel obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadAddress(manager, obj);
                }
            }
            internal void _LoadAddress(DbManagerProxy manager, FarmRootPanel obj)
            {
              
                if (obj.Address == null && obj.idfFarmAddress != null && obj.idfFarmAddress != 0)
                {
                    obj.Address = AddressAccessor.SelectByKey(manager
                        
                        , obj.idfFarmAddress.Value
                        );
                    if (obj.Address != null)
                    {
                        obj.Address.m_ObjectName = _str_Address;
                    }
                }
                    
              }
            
            internal void _LoadFarmLivestockTree(FarmRootPanel obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFarmLivestockTree(manager, obj);
                }
            }
            internal void _LoadFarmLivestockTree(DbManagerProxy manager, FarmRootPanel obj)
            {
              
                obj.FarmLivestockTree.Clear();
                obj.FarmLivestockTree.AddRange(FarmLivestockTreeAccessor.SelectDetailList(manager
                    
                    , new Func<FarmRootPanel, long?>(c => c.idfFarm)(obj)
                    
                    , new Func<FarmRootPanel, int?>(c => (int)HACode.Livestock)(obj)
                    
                    ));
                obj.FarmLivestockTree.ForEach(c => c.m_ObjectName = _str_FarmLivestockTree);
                obj.FarmLivestockTree.AcceptChanges();
                    
              }
            
            internal void _LoadFarmAvianTree(FarmRootPanel obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFarmAvianTree(manager, obj);
                }
            }
            internal void _LoadFarmAvianTree(DbManagerProxy manager, FarmRootPanel obj)
            {
              
                obj.FarmAvianTree.Clear();
                obj.FarmAvianTree.AddRange(FarmAvianTreeAccessor.SelectDetailList(manager
                    
                    , new Func<FarmRootPanel, long?>(c => c.idfFarm)(obj)
                    
                    , new Func<FarmRootPanel, int?>(c => (int)HACode.Avian)(obj)
                    
                    ));
                obj.FarmAvianTree.ForEach(c => c.m_ObjectName = _str_FarmAvianTree);
                obj.FarmAvianTree.AcceptChanges();
                    
              }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, FarmRootPanel obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadFarmLivestockTree(manager, obj);
                _LoadFarmAvianTree(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.Address = new Func<FarmRootPanel, Address>(c => c.Address == null ? AddressAccessor.CreateNewT(manager, c) : c.Address)(obj);
                obj._blnAllowFarmReload = true;
                    if (obj.FarmAvianTree != null) obj.FarmAvianTree.Where(x => x.idfsPartyType == (int)PartyTypeEnum.Species).ToList().ForEach(x => x.strHerdName = (obj.FarmAvianTree.Single(h => h.idfParty == x.idfParentParty).strName));
                    if (obj.FarmLivestockTree != null) obj.FarmLivestockTree.Where(x => x.idfsPartyType == (int)PartyTypeEnum.Species).ToList().ForEach(x => x.strHerdName = (obj.FarmLivestockTree.Single(h => h.idfParty == x.idfParentParty).strName));
                  
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerFarmLivestockTree(obj);
                
                _SetupAddChildHandlerFarmAvianTree(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, FarmRootPanel obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    AddressAccessor._SetPermitions(obj._permissions, obj.Address);
                    
                        obj.FarmLivestockTree.ForEach(c => FarmLivestockTreeAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.FarmAvianTree.ForEach(c => FarmAvianTreeAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private FarmRootPanel _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                FarmRootPanel obj = null;
                try
                {
                    obj = FarmRootPanel.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    obj._HACode = HACode;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfFarm = (new GetNewIDExtender<FarmRootPanel>()).GetScalar(manager, obj, isFake);
                obj.strFarmCode = new Func<FarmRootPanel, string>(c => "(new farm)")(obj);
                obj.Address = (new ObjectCreateExtender<Address.Accessor, Address>()).Create(manager, obj
                
                        , obj._HACode);
                    
                obj.FarmLivestockTree.Add(new Func<FarmRootPanel, RootFarmTree>(c => FarmLivestockTreeAccessor.CreateFarm(manager, c, c, (int)eidss.model.Enums.HACode.Livestock))(obj));
                obj.FarmAvianTree.Add(new Func<FarmRootPanel, RootFarmTree>(c => FarmAvianTreeAccessor.CreateFarm(manager, c, c, (int)eidss.model.Enums.HACode.Avian))(obj));
                obj._blnAllowFarmReload = true;
                obj.idfObservation = (new GetNewIDExtender<FarmRootPanel>()).GetScalar(manager, obj, isFake);
                obj.blnRootFarm = true;
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerFarmLivestockTree(obj);
                    
                    _SetupAddChildHandlerFarmAvianTree(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.Address.blnGeoLocationShared = true;
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

            
            public FarmRootPanel CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public FarmRootPanel CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public FarmRootPanel CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public FarmRootPanel CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is int?)) 
                    throw new TypeMismatchException("HACode", typeof(int?));
                
                return Create(manager, Parent
                    , (int?)pars[0]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public FarmRootPanel Create(DbManagerProxy manager, IObject Parent
                , int? HACode
                )
            {
                return _CreateNew(manager, Parent
                
                    , HACode
                    
                    , obj =>
                {
                obj._HACode = new Func<FarmRootPanel, int?>(c => HACode)(obj);
                obj.idfOwner = new Func<FarmRootPanel, DbManagerProxy, long?>((c,m) => 
                            c.idfOwner ??
                            m.SetSpCommand("dbo.spsysGetNewID", DBNull.Value)
                            .ExecuteScalar<long>(ScalarSourceType.OutputParameter))(obj, manager);
                }
                    , obj =>
                {
                }
                );
            }
            
            public FarmRootPanel CreateHerdT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                return CreateHerd(manager, Parent
                    );
            }
            public IObject CreateHerd(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateHerdT(manager, Parent, pars);
            }
            public FarmRootPanel CreateHerd(DbManagerProxy manager, IObject Parent
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
            
            public ActResult CreateFlock(DbManagerProxy manager, FarmRootPanel obj, List<object> pars)
            {
                
                return CreateFlock(manager, obj
                    );
            }
            public ActResult CreateFlock(DbManagerProxy manager, FarmRootPanel obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("CreateFlock"))
                    throw new PermissionException("AccessToFarmData", "CreateFlock");
                
                  RootFarmTree item = FarmAvianTreeAccessor.CreateHerd(manager, obj, obj.FarmAvianTree[0]);
                  obj.FarmAvianTree.Add(item);
                  _SetupChildHandlers(obj, item);
                  return true;
                
            }
            
      
            public ActResult CreateLvstckSpecies(DbManagerProxy manager, FarmRootPanel obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is RootFarmTree)) 
                    throw new TypeMismatchException("parent", typeof(RootFarmTree));
                
                return CreateLvstckSpecies(manager, obj
                    , (RootFarmTree)pars[0]
                    );
            }
            public ActResult CreateLvstckSpecies(DbManagerProxy manager, FarmRootPanel obj
                , RootFarmTree parent
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("CreateLvstckSpecies"))
                    throw new PermissionException("AccessToFarmData", "CreateLvstckSpecies");
                
                  RootFarmTree item = FarmLivestockTreeAccessor.CreateSpecies(manager, obj, parent);
                  int find = obj.FarmLivestockTree.FindLastIndex(c => c.idfParentParty == parent.idfParty);
                  if (find < 0) find = obj.FarmLivestockTree.FindIndex(c => c.idfParty == parent.idfParty);
                  obj.FarmLivestockTree.Insert(find + 1, item);
                  return true;
                
            }
            
      
            public ActResult CreateAvianSpecies(DbManagerProxy manager, FarmRootPanel obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is RootFarmTree)) 
                    throw new TypeMismatchException("parent", typeof(RootFarmTree));
                
                return CreateAvianSpecies(manager, obj
                    , (RootFarmTree)pars[0]
                    );
            }
            public ActResult CreateAvianSpecies(DbManagerProxy manager, FarmRootPanel obj
                , RootFarmTree parent
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("CreateAvianSpecies"))
                    throw new PermissionException("AccessToFarmData", "CreateAvianSpecies");
                
                  RootFarmTree item = FarmAvianTreeAccessor.CreateSpecies(manager, obj, parent);
                  int find = obj.FarmAvianTree.FindLastIndex(c => c.idfParentParty == parent.idfParty);
                  if (find < 0) find = obj.FarmAvianTree.FindIndex(c => c.idfParty == parent.idfParty);
                  obj.FarmAvianTree.Insert(find + 1, item);
                  return true;
                
            }
            
      
            private void _SetupChildHandlers(FarmRootPanel obj, object newobj)
            {
                
                foreach(var o in obj.FarmAvianTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "strName")
                                {
                                
                (new PredicateValidator("DuplicateSpeciesAvian_msgId", "strName", "FarmAvianTree", "strName",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, item, (farm,i) => 
                                            farm.FarmAvianTree.Where(c => 
                                                c.idfParentParty == i.idfParentParty 
                                                && c.idfParty != i.idfParty 
                                                && c.strName == i.strName
                                                && !c.IsMarkedToDelete
                                                ).Count() == 0
                    );
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("strName");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                }
                            
                foreach(var o in obj.FarmLivestockTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "strName")
                                {
                                
                (new PredicateValidator("DuplicateSpeciesLivestock_msgId", "strName", "FarmLivestockTree", "strName",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, item, (farm,i) => 
                                              farm.FarmLivestockTree.Where(c => 
                                                  c.idfParentParty == i.idfParentParty 
                                                  && c.idfParty != i.idfParty 
                                                  && c.strName == i.strName
                                                  && !c.IsMarkedToDelete
                                                  ).Count() == 0
                    );
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("strName");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                }
                            
                foreach(var o in obj.FarmLivestockTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "intTotalAnimalQty")
                                {
                                
                            var sum = obj.FarmLivestockTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intTotalAnimalQty);
                            obj.FarmLivestockTree.Where(c => c.idfParty == item.idfParentParty).Single().intTotalAnimalQty = sum == 0 ? null : sum;
                        
                                }
                            };
                        }    
                        
                    }
                }
                            
                foreach(var o in obj.FarmLivestockTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "intSickAnimalQty")
                                {
                                
                            var sum = obj.FarmLivestockTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intSickAnimalQty);
                            obj.FarmLivestockTree.Where(c => c.idfParty == item.idfParentParty).Single().intSickAnimalQty = sum == 0 ? null : sum;
                        
                                }
                            };
                        }    
                        
                    }
                }
                            
                foreach(var o in obj.FarmLivestockTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "intDeadAnimalQty")
                                {
                                
                            var sum = obj.FarmLivestockTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intDeadAnimalQty);
                            obj.FarmLivestockTree.Where(c => c.idfParty == item.idfParentParty).Single().intDeadAnimalQty = sum == 0 ? null : sum;
                        
                                }
                            };
                        }    
                        
                    }
                }
                            
                foreach(var o in obj.FarmLivestockTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "IsMarkedToDelete")
                                {
                                
                            var sum = obj.FarmLivestockTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intTotalAnimalQty);
                            obj.FarmLivestockTree.Where(c => c.idfParty == item.idfParentParty).Single().intTotalAnimalQty = sum == 0 ? null : sum;
                            sum = obj.FarmLivestockTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intSickAnimalQty);
                            obj.FarmLivestockTree.Where(c => c.idfParty == item.idfParentParty).Single().intSickAnimalQty = sum == 0 ? null : sum;
                            sum = obj.FarmLivestockTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intDeadAnimalQty);
                            obj.FarmLivestockTree.Where(c => c.idfParty == item.idfParentParty).Single().intDeadAnimalQty = sum == 0 ? null : sum;
                        
                                }
                            };
                        }    
                        
                    }
                }
                            
                foreach(var o in obj.FarmAvianTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "intTotalAnimalQty")
                                {
                                
                      var sum = obj.FarmAvianTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intTotalAnimalQty);
                      obj.FarmAvianTree.Where(c => c.idfParty == item.idfParentParty).Single().intTotalAnimalQty = sum == 0 ? null : sum;
                    
                                }
                            };
                        }    
                        
                    }
                }
                            
                foreach(var o in obj.FarmAvianTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "intSickAnimalQty")
                                {
                                
                      var sum = obj.FarmAvianTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intSickAnimalQty);
                      obj.FarmAvianTree.Where(c => c.idfParty == item.idfParentParty).Single().intSickAnimalQty = sum == 0 ? null : sum;
                    
                                }
                            };
                        }    
                        
                    }
                }
                            
                foreach(var o in obj.FarmAvianTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "intDeadAnimalQty")
                                {
                                
                      var sum = obj.FarmAvianTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intDeadAnimalQty);
                      obj.FarmAvianTree.Where(c => c.idfParty == item.idfParentParty).Single().intDeadAnimalQty = sum == 0 ? null : sum;
                    
                                }
                            };
                        }    
                        
                    }
                }
                            
                foreach(var o in obj.FarmAvianTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "IsMarkedToDelete")
                                {
                                
                      var sum = obj.FarmAvianTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intTotalAnimalQty);
                      obj.FarmAvianTree.Where(c => c.idfParty == item.idfParentParty).Single().intTotalAnimalQty = sum == 0 ? null : sum;
                      sum = obj.FarmAvianTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intSickAnimalQty);
                      obj.FarmAvianTree.Where(c => c.idfParty == item.idfParentParty).Single().intSickAnimalQty = sum == 0 ? null : sum;
                      sum = obj.FarmAvianTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intDeadAnimalQty);
                      obj.FarmAvianTree.Where(c => c.idfParty == item.idfParentParty).Single().intDeadAnimalQty = sum == 0 ? null : sum;
                    
                                }
                            };
                        }    
                        
                    }
                }
                            
            }
            
            private void _SetupHandlers(FarmRootPanel obj)
            {
                
            }
    
            public void LoadLookup_OwnershipStructure(DbManagerProxy manager, FarmRootPanel obj)
            {
                
                obj.OwnershipStructureLookup.Clear();
                
                obj.OwnershipStructureLookup.Add(OwnershipStructureAccessor.CreateNewT(manager, null));
                
                obj.OwnershipStructureLookup.AddRange(OwnershipStructureAccessor.rftOwnershipType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsOwnershipStructure))
                    
                    .ToList());
                
                if (obj.idfsOwnershipStructure != null && obj.idfsOwnershipStructure != 0)
                {
                    obj.OwnershipStructure = obj.OwnershipStructureLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsOwnershipStructure);
                    
                }
              
                LookupManager.AddObject("rftOwnershipType", obj, OwnershipStructureAccessor.GetType(), "rftOwnershipType_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_AvianFarmType(DbManagerProxy manager, FarmRootPanel obj)
            {
                
                obj.AvianFarmTypeLookup.Clear();
                
                obj.AvianFarmTypeLookup.Add(AvianFarmTypeAccessor.CreateNewT(manager, null));
                
                obj.AvianFarmTypeLookup.AddRange(AvianFarmTypeAccessor.rftAvianFarmType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAvianFarmType))
                    
                    .ToList());
                
                if (obj.idfsAvianFarmType != null && obj.idfsAvianFarmType != 0)
                {
                    obj.AvianFarmType = obj.AvianFarmTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsAvianFarmType);
                    
                }
              
                LookupManager.AddObject("rftAvianFarmType", obj, AvianFarmTypeAccessor.GetType(), "rftAvianFarmType_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, FarmRootPanel obj)
            {
                
                LoadLookup_OwnershipStructure(manager, obj);
                
                LoadLookup_AvianFarmType(manager, obj);
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spFarmPanel_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfRootFarm", "strFarmCode", "idfRootOwner", "datModificationDate")] FarmRootPanel obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfRootFarm", "strFarmCode", "idfRootOwner", "datModificationDate")] FarmRootPanel obj)
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
                        FarmRootPanel bo = obj as FarmRootPanel;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            if (!CanDelete)
                                throw new PermissionException("AccessToFarmData", "Delete");
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            if (!CanInsert)
                                throw new PermissionException("AccessToFarmData", "Insert");
                        }
                        else if (!bo.IsMarkedToDelete && bo.HasChanges) // update
                        {
                            if (!CanUpdate)
                                throw new PermissionException("AccessToFarmData", "Update");
                        }
                        
                        long mainObject = bo.idfFarm;
                        
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
                            
                            eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoFarm;
                            eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbFarmActual;
                            manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as FarmRootPanel, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, FarmRootPanel obj, bool bChildObject) 
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
                obj._blnAllowFarmReload = false;
                obj.strFarmCode = new Func<FarmRootPanel, DbManagerProxy, string>((c,m) => 
                        c.strFarmCode != "(new farm)" 
                        ? c.strFarmCode 
                        : m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.Farm, DBNull.Value, DBNull.Value)
                        .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue"))(obj, manager);
                      if ((obj.intHACode & 64)>0)
                      {
                      obj.FarmAvianTree.Clear();
                      obj.idfsAvianFarmType = null;
                      obj.idfsAvianProductionType = null;
                      obj.idfsIntendedUse = null;
                      obj.intBirdsPerBuilding = null;
                      obj.intBuidings = null;
                      }
                      if((obj.intHACode & 32)>0)
                      {
                      obj.FarmLivestockTree.Clear();
                      obj.idfsOwnershipStructure = null;
                      obj.idfsLivestockProductionType = null;
                      obj.idfsMovementPattern = null;
                      obj.idfsGrazingPattern = null;
                      }

                    
                    // posting extenters - end
            
                    if (obj.IsNew)
                    {
                        if (obj.Address != null) // forced load potential lazy subobject for new object
                            if (!AddressAccessor.Post(manager, obj.Address, true))
                                return false;
                    }
                    else
                    {
                        if (obj._Address != null) // do not load lazy subobject for existing object
                            if (!AddressAccessor.Post(manager, obj.Address, true))
                                return false;
                    }
                                    
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                                    
                    if (obj.IsNew)
                    {
                        if (obj.FarmAvianTree != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.FarmAvianTree)
                                if (!FarmAvianTreeAccessor.Post(manager, i, true))
                                    return false;
                            obj.FarmAvianTree.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.FarmAvianTree.Remove(c));
                            obj.FarmAvianTree.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._FarmAvianTree != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._FarmAvianTree)
                                if (!FarmAvianTreeAccessor.Post(manager, i, true))
                                    return false;
                            obj._FarmAvianTree.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._FarmAvianTree.Remove(c));
                            obj._FarmAvianTree.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.FarmLivestockTree != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.FarmLivestockTree)
                                if (!FarmLivestockTreeAccessor.Post(manager, i, true))
                                    return false;
                            obj.FarmLivestockTree.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.FarmLivestockTree.Remove(c));
                            obj.FarmLivestockTree.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._FarmLivestockTree != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._FarmLivestockTree)
                                if (!FarmLivestockTreeAccessor.Post(manager, i, true))
                                    return false;
                            obj._FarmLivestockTree.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._FarmLivestockTree.Remove(c));
                            obj._FarmLivestockTree.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                obj._blnAllowFarmReload = true;
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(FarmRootPanel obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, FarmRootPanel obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(FarmRootPanel obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(FarmRootPanel obj, bool bRethrowException)
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
                return Validate(manager, obj as FarmRootPanel, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, FarmRootPanel obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "Address.idfsCountry", "Address.Country","Farm.Address.idfsCountry",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.Address.idfsCountry);
            
                (new RequiredValidator( "Address.idfsRegion", "Address.Region","Farm.Address.idfsRegion",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.Address.idfsRegion);
            
                (new RequiredValidator( "Address.idfsRayon", "Address.Rayon","Farm.Address.idfsRayon",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.Address.idfsRayon);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                        foreach(var item in obj.FarmAvianTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Species))
                        {
                        
                (new PredicateValidator("DuplicateSpeciesAvian_msgId", "strName", "FarmAvianTree", "strName",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, item, (farm,i) => 
                                            farm.FarmAvianTree.Where(c => 
                                                c.idfParentParty == i.idfParentParty 
                                                && c.idfParty != i.idfParty 
                                                && c.strName == i.strName
                                                && !c.IsMarkedToDelete
                                                ).Count() == 0
                    );
            
                        }
                
                        foreach(var item in obj.FarmLivestockTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Species))
                        {
                        
                (new PredicateValidator("DuplicateSpeciesLivestock_msgId", "strName", "FarmLivestockTree", "strName",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, item, (farm,i) => 
                                              farm.FarmLivestockTree.Where(c => 
                                                  c.idfParentParty == i.idfParentParty 
                                                  && c.idfParty != i.idfParty 
                                                  && c.strName == i.strName
                                                  && !c.IsMarkedToDelete
                                                  ).Count() == 0
                    );
            
                        }
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Address != null)
                            AddressAccessor.Validate(manager, obj.Address, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FarmAvianTree != null)
                            foreach (var i in obj.FarmAvianTree.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                FarmAvianTreeAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FarmLivestockTree != null)
                            foreach (var i in obj.FarmLivestockTree.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                FarmLivestockTreeAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToFarmData.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToFarmData.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToFarmData.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToFarmData.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(FarmRootPanel obj)
            {
            
                obj
                    .Address
                        .AddRequired("Country", c => true);
                        
                obj
                    .Address
                        .AddRequired("Region", c => true);
                        
                obj
                    .Address
                        .AddRequired("Rayon", c => true);
                        
            }
    
    private void _SetupPersonalDataRestrictions(FarmRootPanel obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as FarmRootPanel) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as FarmRootPanel) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "FarmRootPanelDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private FarmRootPanel m_obj;
            internal Permissions(FarmRootPanel obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToFarmData.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToFarmData.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToFarmData.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToFarmData.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFarmPanel_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spFarmPanel_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<FarmRootPanel, bool>> RequiredByField = new Dictionary<string, Func<FarmRootPanel, bool>>();
            public static Dictionary<string, Func<FarmRootPanel, bool>> RequiredByProperty = new Dictionary<string, Func<FarmRootPanel, bool>>();
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
                
                Sizes.Add(_str_strContactPhone, 200);
                Sizes.Add(_str_strInternationalName, 200);
                Sizes.Add(_str_strNationalName, 200);
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_strFax, 200);
                Sizes.Add(_str_strEmail, 200);
                Sizes.Add(_str_strFullName, 400);
                Sizes.Add(_str_strOwnerLastName, 200);
                Sizes.Add(_str_strOwnerFirstName, 200);
                Sizes.Add(_str_strOwnerMiddleName, 200);
                if (!RequiredByField.ContainsKey("Address.idfsCountry")) RequiredByField.Add("Address.idfsCountry", c => true);
                if (!RequiredByProperty.ContainsKey("Address.Country")) RequiredByProperty.Add("Address.Country", c => true);
                
                if (!RequiredByField.ContainsKey("Address.idfsRegion")) RequiredByField.Add("Address.idfsRegion", c => true);
                if (!RequiredByProperty.ContainsKey("Address.Region")) RequiredByProperty.Add("Address.Region", c => true);
                
                if (!RequiredByField.ContainsKey("Address.idfsRayon")) RequiredByField.Add("Address.idfsRayon", c => true);
                if (!RequiredByProperty.ContainsKey("Address.Rayon")) RequiredByProperty.Add("Address.Rayon", c => true);
                
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
                    "CreateHerd",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateHerd(manager, c, pars)),
                        
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
                    "CreateFlock",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).CreateFlock(manager, (FarmRootPanel)c, pars),
                        
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
                    "CreateLvstckSpecies",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).CreateLvstckSpecies(manager, (FarmRootPanel)c, pars),
                        
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
                    "CreateAvianSpecies",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).CreateAvianSpecies(manager, (FarmRootPanel)c, pars),
                        
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<FarmRootPanel>().Post(manager, (FarmRootPanel)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<FarmRootPanel>().Post(manager, (FarmRootPanel)c), c),
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
                    (manager, c, pars) => new ActResult(((FarmRootPanel)c).MarkToDelete() && ObjectAccessor.PostInterface<FarmRootPanel>().Post(manager, (FarmRootPanel)c), c),
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
	