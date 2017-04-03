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
        #if MONO
        protected Int64? idfRootFarm_Original { get { return idfRootFarm; } }
        protected Int64? idfRootFarm_Previous { get { return idfRootFarm; } }
        #else
        protected Int64? idfRootFarm_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootFarm).OriginalValue; } }
        protected Int64? idfRootFarm_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootFarm).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64? idfCase { get; set; }
        #if MONO
        protected Int64? idfCase_Original { get { return idfCase; } }
        protected Int64? idfCase_Previous { get { return idfCase; } }
        #else
        protected Int64? idfCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64? idfCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strContactPhone)]
        [MapField(_str_strContactPhone)]
        public abstract String strContactPhone { get; set; }
        #if MONO
        protected String strContactPhone_Original { get { return strContactPhone; } }
        protected String strContactPhone_Previous { get { return strContactPhone; } }
        #else
        protected String strContactPhone_Original { get { return ((EditableValue<String>)((dynamic)this)._strContactPhone).OriginalValue; } }
        protected String strContactPhone_Previous { get { return ((EditableValue<String>)((dynamic)this)._strContactPhone).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strInternationalName)]
        [MapField(_str_strInternationalName)]
        public abstract String strInternationalName { get; set; }
        #if MONO
        protected String strInternationalName_Original { get { return strInternationalName; } }
        protected String strInternationalName_Previous { get { return strInternationalName; } }
        #else
        protected String strInternationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._strInternationalName).OriginalValue; } }
        protected String strInternationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strInternationalName).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strFax)]
        [MapField(_str_strFax)]
        public abstract String strFax { get; set; }
        #if MONO
        protected String strFax_Original { get { return strFax; } }
        protected String strFax_Previous { get { return strFax; } }
        #else
        protected String strFax_Original { get { return ((EditableValue<String>)((dynamic)this)._strFax).OriginalValue; } }
        protected String strFax_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFax).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strEmail)]
        [MapField(_str_strEmail)]
        public abstract String strEmail { get; set; }
        #if MONO
        protected String strEmail_Original { get { return strEmail; } }
        protected String strEmail_Previous { get { return strEmail; } }
        #else
        protected String strEmail_Original { get { return ((EditableValue<String>)((dynamic)this)._strEmail).OriginalValue; } }
        protected String strEmail_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEmail).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfFarmLocation)]
        [MapField(_str_idfFarmLocation)]
        public abstract Int64? idfFarmLocation { get; set; }
        #if MONO
        protected Int64? idfFarmLocation_Original { get { return idfFarmLocation; } }
        protected Int64? idfFarmLocation_Previous { get { return idfFarmLocation; } }
        #else
        protected Int64? idfFarmLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFarmLocation).OriginalValue; } }
        protected Int64? idfFarmLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFarmLocation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfFarmAddress)]
        [MapField(_str_idfFarmAddress)]
        public abstract Int64? idfFarmAddress { get; set; }
        #if MONO
        protected Int64? idfFarmAddress_Original { get { return idfFarmAddress; } }
        protected Int64? idfFarmAddress_Previous { get { return idfFarmAddress; } }
        #else
        protected Int64? idfFarmAddress_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFarmAddress).OriginalValue; } }
        protected Int64? idfFarmAddress_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFarmAddress).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnIsLivestock)]
        [MapField(_str_blnIsLivestock)]
        public abstract Boolean? blnIsLivestock { get; set; }
        #if MONO
        protected Boolean? blnIsLivestock_Original { get { return blnIsLivestock; } }
        protected Boolean? blnIsLivestock_Previous { get { return blnIsLivestock; } }
        #else
        protected Boolean? blnIsLivestock_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsLivestock).OriginalValue; } }
        protected Boolean? blnIsLivestock_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsLivestock).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnIsAvian)]
        [MapField(_str_blnIsAvian)]
        public abstract Boolean? blnIsAvian { get; set; }
        #if MONO
        protected Boolean? blnIsAvian_Original { get { return blnIsAvian; } }
        protected Boolean? blnIsAvian_Previous { get { return blnIsAvian; } }
        #else
        protected Boolean? blnIsAvian_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsAvian).OriginalValue; } }
        protected Boolean? blnIsAvian_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnIsAvian).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsGrazingPattern)]
        [MapField(_str_idfsGrazingPattern)]
        public abstract Int64? idfsGrazingPattern { get; set; }
        #if MONO
        protected Int64? idfsGrazingPattern_Original { get { return idfsGrazingPattern; } }
        protected Int64? idfsGrazingPattern_Previous { get { return idfsGrazingPattern; } }
        #else
        protected Int64? idfsGrazingPattern_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGrazingPattern).OriginalValue; } }
        protected Int64? idfsGrazingPattern_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGrazingPattern).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsMovementPattern)]
        [MapField(_str_idfsMovementPattern)]
        public abstract Int64? idfsMovementPattern { get; set; }
        #if MONO
        protected Int64? idfsMovementPattern_Original { get { return idfsMovementPattern; } }
        protected Int64? idfsMovementPattern_Previous { get { return idfsMovementPattern; } }
        #else
        protected Int64? idfsMovementPattern_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMovementPattern).OriginalValue; } }
        protected Int64? idfsMovementPattern_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMovementPattern).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsAvianFarmType)]
        [MapField(_str_idfsAvianFarmType)]
        public abstract Int64? idfsAvianFarmType { get; set; }
        #if MONO
        protected Int64? idfsAvianFarmType_Original { get { return idfsAvianFarmType; } }
        protected Int64? idfsAvianFarmType_Previous { get { return idfsAvianFarmType; } }
        #else
        protected Int64? idfsAvianFarmType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAvianFarmType).OriginalValue; } }
        protected Int64? idfsAvianFarmType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAvianFarmType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsAvianProductionType)]
        [MapField(_str_idfsAvianProductionType)]
        public abstract Int64? idfsAvianProductionType { get; set; }
        #if MONO
        protected Int64? idfsAvianProductionType_Original { get { return idfsAvianProductionType; } }
        protected Int64? idfsAvianProductionType_Previous { get { return idfsAvianProductionType; } }
        #else
        protected Int64? idfsAvianProductionType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAvianProductionType).OriginalValue; } }
        protected Int64? idfsAvianProductionType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAvianProductionType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsIntendedUse)]
        [MapField(_str_idfsIntendedUse)]
        public abstract Int64? idfsIntendedUse { get; set; }
        #if MONO
        protected Int64? idfsIntendedUse_Original { get { return idfsIntendedUse; } }
        protected Int64? idfsIntendedUse_Previous { get { return idfsIntendedUse; } }
        #else
        protected Int64? idfsIntendedUse_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsIntendedUse).OriginalValue; } }
        protected Int64? idfsIntendedUse_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsIntendedUse).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intBirdsPerBuilding)]
        [MapField(_str_intBirdsPerBuilding)]
        public abstract Int32? intBirdsPerBuilding { get; set; }
        #if MONO
        protected Int32? intBirdsPerBuilding_Original { get { return intBirdsPerBuilding; } }
        protected Int32? intBirdsPerBuilding_Previous { get { return intBirdsPerBuilding; } }
        #else
        protected Int32? intBirdsPerBuilding_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intBirdsPerBuilding).OriginalValue; } }
        protected Int32? intBirdsPerBuilding_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intBirdsPerBuilding).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intBuidings)]
        [MapField(_str_intBuidings)]
        public abstract Int32? intBuidings { get; set; }
        #if MONO
        protected Int32? intBuidings_Original { get { return intBuidings; } }
        protected Int32? intBuidings_Previous { get { return intBuidings; } }
        #else
        protected Int32? intBuidings_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intBuidings).OriginalValue; } }
        protected Int32? intBuidings_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intBuidings).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfFarmOwner")]
        [MapField(_str_idfOwner)]
        public abstract Int64? idfOwner { get; set; }
        #if MONO
        protected Int64? idfOwner_Original { get { return idfOwner; } }
        protected Int64? idfOwner_Previous { get { return idfOwner; } }
        #else
        protected Int64? idfOwner_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOwner).OriginalValue; } }
        protected Int64? idfOwner_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOwner).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfRootOwner)]
        [MapField(_str_idfRootOwner)]
        public abstract Int64? idfRootOwner { get; set; }
        #if MONO
        protected Int64? idfRootOwner_Original { get { return idfRootOwner; } }
        protected Int64? idfRootOwner_Previous { get { return idfRootOwner; } }
        #else
        protected Int64? idfRootOwner_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootOwner).OriginalValue; } }
        protected Int64? idfRootOwner_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootOwner).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strFarmFullName")]
        [MapField(_str_strFullName)]
        public abstract String strFullName { get; set; }
        #if MONO
        protected String strFullName_Original { get { return strFullName; } }
        protected String strFullName_Previous { get { return strFullName; } }
        #else
        protected String strFullName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFullName).OriginalValue; } }
        protected String strFullName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFullName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strOwnerLastName)]
        [MapField(_str_strOwnerLastName)]
        public abstract String strOwnerLastName { get; set; }
        #if MONO
        protected String strOwnerLastName_Original { get { return strOwnerLastName; } }
        protected String strOwnerLastName_Previous { get { return strOwnerLastName; } }
        #else
        protected String strOwnerLastName_Original { get { return ((EditableValue<String>)((dynamic)this)._strOwnerLastName).OriginalValue; } }
        protected String strOwnerLastName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOwnerLastName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strOwnerFirstName)]
        [MapField(_str_strOwnerFirstName)]
        public abstract String strOwnerFirstName { get; set; }
        #if MONO
        protected String strOwnerFirstName_Original { get { return strOwnerFirstName; } }
        protected String strOwnerFirstName_Previous { get { return strOwnerFirstName; } }
        #else
        protected String strOwnerFirstName_Original { get { return ((EditableValue<String>)((dynamic)this)._strOwnerFirstName).OriginalValue; } }
        protected String strOwnerFirstName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOwnerFirstName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strOwnerMiddleName)]
        [MapField(_str_strOwnerMiddleName)]
        public abstract String strOwnerMiddleName { get; set; }
        #if MONO
        protected String strOwnerMiddleName_Original { get { return strOwnerMiddleName; } }
        protected String strOwnerMiddleName_Previous { get { return strOwnerMiddleName; } }
        #else
        protected String strOwnerMiddleName_Original { get { return ((EditableValue<String>)((dynamic)this)._strOwnerMiddleName).OriginalValue; } }
        protected String strOwnerMiddleName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOwnerMiddleName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfObservation)]
        [MapField(_str_idfObservation)]
        public abstract Int64? idfObservation { get; set; }
        #if MONO
        protected Int64? idfObservation_Original { get { return idfObservation; } }
        protected Int64? idfObservation_Previous { get { return idfObservation; } }
        #else
        protected Int64? idfObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObservation).OriginalValue; } }
        protected Int64? idfObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObservation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64? idfsFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsFormTemplate_Original { get { return idfsFormTemplate; } }
        protected Int64? idfsFormTemplate_Previous { get { return idfsFormTemplate; } }
        #else
        protected Int64? idfsFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64? idfsFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnRootFarm)]
        [MapField(_str_blnRootFarm)]
        public abstract Boolean? blnRootFarm { get; set; }
        #if MONO
        protected Boolean? blnRootFarm_Original { get { return blnRootFarm; } }
        protected Boolean? blnRootFarm_Previous { get { return blnRootFarm; } }
        #else
        protected Boolean? blnRootFarm_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnRootFarm).OriginalValue; } }
        protected Boolean? blnRootFarm_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnRootFarm).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<FarmRootPanel, object> _get_func;
            internal Action<FarmRootPanel, string> _set_func;
            internal Action<FarmRootPanel, FarmRootPanel, CompareModel> _compare_func;
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
        internal const string _str_idfFarmLocation = "idfFarmLocation";
        internal const string _str_idfFarmAddress = "idfFarmAddress";
        internal const string _str_blnIsLivestock = "blnIsLivestock";
        internal const string _str_blnIsAvian = "blnIsAvian";
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
        internal const string _str__blnAllowFarmReload = "_blnAllowFarmReload";
        internal const string _str_OwnershipStructure = "OwnershipStructure";
        internal const string _str_LivestockProductionType = "LivestockProductionType";
        internal const string _str_MovementPattern = "MovementPattern";
        internal const string _str_GrazingPattern = "GrazingPattern";
        internal const string _str_AvianFarmProductionType = "AvianFarmProductionType";
        internal const string _str_AvianFarmType = "AvianFarmType";
        internal const string _str_FarmIntendedUse = "FarmIntendedUse";
        internal const string _str_Location = "Location";
        internal const string _str_Address = "Address";
        internal const string _str_FarmLivestockTree = "FarmLivestockTree";
        internal const string _str_FarmAvianTree = "FarmAvianTree";
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
              _name = _str_idfCase, _type = "Int64?",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { o.idfCase = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, "Int64?", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); }
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
              _name = _str_strContactPhone, _type = "String",
              _get_func = o => o.strContactPhone,
              _set_func = (o, val) => { o.strContactPhone = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strContactPhone != c.strContactPhone || o.IsRIRPropChanged(_str_strContactPhone, c)) 
                  m.Add(_str_strContactPhone, o.ObjectIdent + _str_strContactPhone, "String", o.strContactPhone == null ? "" : o.strContactPhone.ToString(), o.IsReadOnly(_str_strContactPhone), o.IsInvisible(_str_strContactPhone), o.IsRequired(_str_strContactPhone)); }
              }, 
        
            new field_info {
              _name = _str_strInternationalName, _type = "String",
              _get_func = o => o.strInternationalName,
              _set_func = (o, val) => { o.strInternationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strInternationalName != c.strInternationalName || o.IsRIRPropChanged(_str_strInternationalName, c)) 
                  m.Add(_str_strInternationalName, o.ObjectIdent + _str_strInternationalName, "String", o.strInternationalName == null ? "" : o.strInternationalName.ToString(), o.IsReadOnly(_str_strInternationalName), o.IsInvisible(_str_strInternationalName), o.IsRequired(_str_strInternationalName)); }
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
              _name = _str_strFarmCode, _type = "String",
              _get_func = o => o.strFarmCode,
              _set_func = (o, val) => { o.strFarmCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFarmCode != c.strFarmCode || o.IsRIRPropChanged(_str_strFarmCode, c)) 
                  m.Add(_str_strFarmCode, o.ObjectIdent + _str_strFarmCode, "String", o.strFarmCode == null ? "" : o.strFarmCode.ToString(), o.IsReadOnly(_str_strFarmCode), o.IsInvisible(_str_strFarmCode), o.IsRequired(_str_strFarmCode)); }
              }, 
        
            new field_info {
              _name = _str_strFax, _type = "String",
              _get_func = o => o.strFax,
              _set_func = (o, val) => { o.strFax = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFax != c.strFax || o.IsRIRPropChanged(_str_strFax, c)) 
                  m.Add(_str_strFax, o.ObjectIdent + _str_strFax, "String", o.strFax == null ? "" : o.strFax.ToString(), o.IsReadOnly(_str_strFax), o.IsInvisible(_str_strFax), o.IsRequired(_str_strFax)); }
              }, 
        
            new field_info {
              _name = _str_strEmail, _type = "String",
              _get_func = o => o.strEmail,
              _set_func = (o, val) => { o.strEmail = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strEmail != c.strEmail || o.IsRIRPropChanged(_str_strEmail, c)) 
                  m.Add(_str_strEmail, o.ObjectIdent + _str_strEmail, "String", o.strEmail == null ? "" : o.strEmail.ToString(), o.IsReadOnly(_str_strEmail), o.IsInvisible(_str_strEmail), o.IsRequired(_str_strEmail)); }
              }, 
        
            new field_info {
              _name = _str_idfFarmLocation, _type = "Int64?",
              _get_func = o => o.idfFarmLocation,
              _set_func = (o, val) => { o.idfFarmLocation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfFarmLocation != c.idfFarmLocation || o.IsRIRPropChanged(_str_idfFarmLocation, c)) 
                  m.Add(_str_idfFarmLocation, o.ObjectIdent + _str_idfFarmLocation, "Int64?", o.idfFarmLocation == null ? "" : o.idfFarmLocation.ToString(), o.IsReadOnly(_str_idfFarmLocation), o.IsInvisible(_str_idfFarmLocation), o.IsRequired(_str_idfFarmLocation)); }
              }, 
        
            new field_info {
              _name = _str_idfFarmAddress, _type = "Int64?",
              _get_func = o => o.idfFarmAddress,
              _set_func = (o, val) => { o.idfFarmAddress = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfFarmAddress != c.idfFarmAddress || o.IsRIRPropChanged(_str_idfFarmAddress, c)) 
                  m.Add(_str_idfFarmAddress, o.ObjectIdent + _str_idfFarmAddress, "Int64?", o.idfFarmAddress == null ? "" : o.idfFarmAddress.ToString(), o.IsReadOnly(_str_idfFarmAddress), o.IsInvisible(_str_idfFarmAddress), o.IsRequired(_str_idfFarmAddress)); }
              }, 
        
            new field_info {
              _name = _str_blnIsLivestock, _type = "Boolean?",
              _get_func = o => o.blnIsLivestock,
              _set_func = (o, val) => { o.blnIsLivestock = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnIsLivestock != c.blnIsLivestock || o.IsRIRPropChanged(_str_blnIsLivestock, c)) 
                  m.Add(_str_blnIsLivestock, o.ObjectIdent + _str_blnIsLivestock, "Boolean?", o.blnIsLivestock == null ? "" : o.blnIsLivestock.ToString(), o.IsReadOnly(_str_blnIsLivestock), o.IsInvisible(_str_blnIsLivestock), o.IsRequired(_str_blnIsLivestock)); }
              }, 
        
            new field_info {
              _name = _str_blnIsAvian, _type = "Boolean?",
              _get_func = o => o.blnIsAvian,
              _set_func = (o, val) => { o.blnIsAvian = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnIsAvian != c.blnIsAvian || o.IsRIRPropChanged(_str_blnIsAvian, c)) 
                  m.Add(_str_blnIsAvian, o.ObjectIdent + _str_blnIsAvian, "Boolean?", o.blnIsAvian == null ? "" : o.blnIsAvian.ToString(), o.IsReadOnly(_str_blnIsAvian), o.IsInvisible(_str_blnIsAvian), o.IsRequired(_str_blnIsAvian)); }
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
              _name = _str_idfsGrazingPattern, _type = "Int64?",
              _get_func = o => o.idfsGrazingPattern,
              _set_func = (o, val) => { o.idfsGrazingPattern = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsGrazingPattern != c.idfsGrazingPattern || o.IsRIRPropChanged(_str_idfsGrazingPattern, c)) 
                  m.Add(_str_idfsGrazingPattern, o.ObjectIdent + _str_idfsGrazingPattern, "Int64?", o.idfsGrazingPattern == null ? "" : o.idfsGrazingPattern.ToString(), o.IsReadOnly(_str_idfsGrazingPattern), o.IsInvisible(_str_idfsGrazingPattern), o.IsRequired(_str_idfsGrazingPattern)); }
              }, 
        
            new field_info {
              _name = _str_idfsMovementPattern, _type = "Int64?",
              _get_func = o => o.idfsMovementPattern,
              _set_func = (o, val) => { o.idfsMovementPattern = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsMovementPattern != c.idfsMovementPattern || o.IsRIRPropChanged(_str_idfsMovementPattern, c)) 
                  m.Add(_str_idfsMovementPattern, o.ObjectIdent + _str_idfsMovementPattern, "Int64?", o.idfsMovementPattern == null ? "" : o.idfsMovementPattern.ToString(), o.IsReadOnly(_str_idfsMovementPattern), o.IsInvisible(_str_idfsMovementPattern), o.IsRequired(_str_idfsMovementPattern)); }
              }, 
        
            new field_info {
              _name = _str_idfsAvianFarmType, _type = "Int64?",
              _get_func = o => o.idfsAvianFarmType,
              _set_func = (o, val) => { o.idfsAvianFarmType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAvianFarmType != c.idfsAvianFarmType || o.IsRIRPropChanged(_str_idfsAvianFarmType, c)) 
                  m.Add(_str_idfsAvianFarmType, o.ObjectIdent + _str_idfsAvianFarmType, "Int64?", o.idfsAvianFarmType == null ? "" : o.idfsAvianFarmType.ToString(), o.IsReadOnly(_str_idfsAvianFarmType), o.IsInvisible(_str_idfsAvianFarmType), o.IsRequired(_str_idfsAvianFarmType)); }
              }, 
        
            new field_info {
              _name = _str_idfsAvianProductionType, _type = "Int64?",
              _get_func = o => o.idfsAvianProductionType,
              _set_func = (o, val) => { o.idfsAvianProductionType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAvianProductionType != c.idfsAvianProductionType || o.IsRIRPropChanged(_str_idfsAvianProductionType, c)) 
                  m.Add(_str_idfsAvianProductionType, o.ObjectIdent + _str_idfsAvianProductionType, "Int64?", o.idfsAvianProductionType == null ? "" : o.idfsAvianProductionType.ToString(), o.IsReadOnly(_str_idfsAvianProductionType), o.IsInvisible(_str_idfsAvianProductionType), o.IsRequired(_str_idfsAvianProductionType)); }
              }, 
        
            new field_info {
              _name = _str_idfsIntendedUse, _type = "Int64?",
              _get_func = o => o.idfsIntendedUse,
              _set_func = (o, val) => { o.idfsIntendedUse = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsIntendedUse != c.idfsIntendedUse || o.IsRIRPropChanged(_str_idfsIntendedUse, c)) 
                  m.Add(_str_idfsIntendedUse, o.ObjectIdent + _str_idfsIntendedUse, "Int64?", o.idfsIntendedUse == null ? "" : o.idfsIntendedUse.ToString(), o.IsReadOnly(_str_idfsIntendedUse), o.IsInvisible(_str_idfsIntendedUse), o.IsRequired(_str_idfsIntendedUse)); }
              }, 
        
            new field_info {
              _name = _str_intBirdsPerBuilding, _type = "Int32?",
              _get_func = o => o.intBirdsPerBuilding,
              _set_func = (o, val) => { o.intBirdsPerBuilding = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intBirdsPerBuilding != c.intBirdsPerBuilding || o.IsRIRPropChanged(_str_intBirdsPerBuilding, c)) 
                  m.Add(_str_intBirdsPerBuilding, o.ObjectIdent + _str_intBirdsPerBuilding, "Int32?", o.intBirdsPerBuilding == null ? "" : o.intBirdsPerBuilding.ToString(), o.IsReadOnly(_str_intBirdsPerBuilding), o.IsInvisible(_str_intBirdsPerBuilding), o.IsRequired(_str_intBirdsPerBuilding)); }
              }, 
        
            new field_info {
              _name = _str_intBuidings, _type = "Int32?",
              _get_func = o => o.intBuidings,
              _set_func = (o, val) => { o.intBuidings = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intBuidings != c.intBuidings || o.IsRIRPropChanged(_str_intBuidings, c)) 
                  m.Add(_str_intBuidings, o.ObjectIdent + _str_intBuidings, "Int32?", o.intBuidings == null ? "" : o.intBuidings.ToString(), o.IsReadOnly(_str_intBuidings), o.IsInvisible(_str_intBuidings), o.IsRequired(_str_intBuidings)); }
              }, 
        
            new field_info {
              _name = _str_idfOwner, _type = "Int64?",
              _get_func = o => o.idfOwner,
              _set_func = (o, val) => { o.idfOwner = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfOwner != c.idfOwner || o.IsRIRPropChanged(_str_idfOwner, c)) 
                  m.Add(_str_idfOwner, o.ObjectIdent + _str_idfOwner, "Int64?", o.idfOwner == null ? "" : o.idfOwner.ToString(), o.IsReadOnly(_str_idfOwner), o.IsInvisible(_str_idfOwner), o.IsRequired(_str_idfOwner)); }
              }, 
        
            new field_info {
              _name = _str_idfRootOwner, _type = "Int64?",
              _get_func = o => o.idfRootOwner,
              _set_func = (o, val) => { o.idfRootOwner = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfRootOwner != c.idfRootOwner || o.IsRIRPropChanged(_str_idfRootOwner, c)) 
                  m.Add(_str_idfRootOwner, o.ObjectIdent + _str_idfRootOwner, "Int64?", o.idfRootOwner == null ? "" : o.idfRootOwner.ToString(), o.IsReadOnly(_str_idfRootOwner), o.IsInvisible(_str_idfRootOwner), o.IsRequired(_str_idfRootOwner)); }
              }, 
        
            new field_info {
              _name = _str_strFullName, _type = "String",
              _get_func = o => o.strFullName,
              _set_func = (o, val) => { o.strFullName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFullName != c.strFullName || o.IsRIRPropChanged(_str_strFullName, c)) 
                  m.Add(_str_strFullName, o.ObjectIdent + _str_strFullName, "String", o.strFullName == null ? "" : o.strFullName.ToString(), o.IsReadOnly(_str_strFullName), o.IsInvisible(_str_strFullName), o.IsRequired(_str_strFullName)); }
              }, 
        
            new field_info {
              _name = _str_strOwnerLastName, _type = "String",
              _get_func = o => o.strOwnerLastName,
              _set_func = (o, val) => { o.strOwnerLastName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strOwnerLastName != c.strOwnerLastName || o.IsRIRPropChanged(_str_strOwnerLastName, c)) 
                  m.Add(_str_strOwnerLastName, o.ObjectIdent + _str_strOwnerLastName, "String", o.strOwnerLastName == null ? "" : o.strOwnerLastName.ToString(), o.IsReadOnly(_str_strOwnerLastName), o.IsInvisible(_str_strOwnerLastName), o.IsRequired(_str_strOwnerLastName)); }
              }, 
        
            new field_info {
              _name = _str_strOwnerFirstName, _type = "String",
              _get_func = o => o.strOwnerFirstName,
              _set_func = (o, val) => { o.strOwnerFirstName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strOwnerFirstName != c.strOwnerFirstName || o.IsRIRPropChanged(_str_strOwnerFirstName, c)) 
                  m.Add(_str_strOwnerFirstName, o.ObjectIdent + _str_strOwnerFirstName, "String", o.strOwnerFirstName == null ? "" : o.strOwnerFirstName.ToString(), o.IsReadOnly(_str_strOwnerFirstName), o.IsInvisible(_str_strOwnerFirstName), o.IsRequired(_str_strOwnerFirstName)); }
              }, 
        
            new field_info {
              _name = _str_strOwnerMiddleName, _type = "String",
              _get_func = o => o.strOwnerMiddleName,
              _set_func = (o, val) => { o.strOwnerMiddleName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strOwnerMiddleName != c.strOwnerMiddleName || o.IsRIRPropChanged(_str_strOwnerMiddleName, c)) 
                  m.Add(_str_strOwnerMiddleName, o.ObjectIdent + _str_strOwnerMiddleName, "String", o.strOwnerMiddleName == null ? "" : o.strOwnerMiddleName.ToString(), o.IsReadOnly(_str_strOwnerMiddleName), o.IsInvisible(_str_strOwnerMiddleName), o.IsRequired(_str_strOwnerMiddleName)); }
              }, 
        
            new field_info {
              _name = _str_idfObservation, _type = "Int64?",
              _get_func = o => o.idfObservation,
              _set_func = (o, val) => { o.idfObservation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfObservation != c.idfObservation || o.IsRIRPropChanged(_str_idfObservation, c)) 
                  m.Add(_str_idfObservation, o.ObjectIdent + _str_idfObservation, "Int64?", o.idfObservation == null ? "" : o.idfObservation.ToString(), o.IsReadOnly(_str_idfObservation), o.IsInvisible(_str_idfObservation), o.IsRequired(_str_idfObservation)); }
              }, 
        
            new field_info {
              _name = _str_idfsFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { o.idfsFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, "Int64?", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); }
              }, 
        
            new field_info {
              _name = _str_blnRootFarm, _type = "Boolean?",
              _get_func = o => o.blnRootFarm,
              _set_func = (o, val) => { o.blnRootFarm = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnRootFarm != c.blnRootFarm || o.IsRIRPropChanged(_str_blnRootFarm, c)) 
                  m.Add(_str_blnRootFarm, o.ObjectIdent + _str_blnRootFarm, "Boolean?", o.blnRootFarm == null ? "" : o.blnRootFarm.ToString(), o.IsReadOnly(_str_blnRootFarm), o.IsInvisible(_str_blnRootFarm), o.IsRequired(_str_blnRootFarm)); }
              }, 
        
            new field_info {
              _name = _str__blnAllowFarmReload, _type = "bool",
              _get_func = o => o._blnAllowFarmReload,
              _set_func = (o, val) => { o._blnAllowFarmReload = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o._blnAllowFarmReload != c._blnAllowFarmReload || o.IsRIRPropChanged(_str__blnAllowFarmReload, c)) 
                  m.Add(_str__blnAllowFarmReload, o.ObjectIdent + _str__blnAllowFarmReload, "bool", o._blnAllowFarmReload == null ? "" : o._blnAllowFarmReload.ToString(), o.IsReadOnly(_str__blnAllowFarmReload), o.IsInvisible(_str__blnAllowFarmReload), o.IsRequired(_str__blnAllowFarmReload));
                 }
              }, 
        
            new field_info {
              _name = _str_OwnershipStructure, _type = "Lookup",
              _get_func = o => { if (o.OwnershipStructure == null) return null; return o.OwnershipStructure.idfsBaseReference; },
              _set_func = (o, val) => { o.OwnershipStructure = o.OwnershipStructureLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsOwnershipStructure != c.idfsOwnershipStructure || o.IsRIRPropChanged(_str_OwnershipStructure, c)) 
                  m.Add(_str_OwnershipStructure, o.ObjectIdent + _str_OwnershipStructure, "Lookup", o.idfsOwnershipStructure == null ? "" : o.idfsOwnershipStructure.ToString(), o.IsReadOnly(_str_OwnershipStructure), o.IsInvisible(_str_OwnershipStructure), o.IsRequired(_str_OwnershipStructure)); }
              }, 
        
            new field_info {
              _name = _str_LivestockProductionType, _type = "Lookup",
              _get_func = o => { if (o.LivestockProductionType == null) return null; return o.LivestockProductionType.idfsBaseReference; },
              _set_func = (o, val) => { o.LivestockProductionType = o.LivestockProductionTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsLivestockProductionType != c.idfsLivestockProductionType || o.IsRIRPropChanged(_str_LivestockProductionType, c)) 
                  m.Add(_str_LivestockProductionType, o.ObjectIdent + _str_LivestockProductionType, "Lookup", o.idfsLivestockProductionType == null ? "" : o.idfsLivestockProductionType.ToString(), o.IsReadOnly(_str_LivestockProductionType), o.IsInvisible(_str_LivestockProductionType), o.IsRequired(_str_LivestockProductionType)); }
              }, 
        
            new field_info {
              _name = _str_MovementPattern, _type = "Lookup",
              _get_func = o => { if (o.MovementPattern == null) return null; return o.MovementPattern.idfsBaseReference; },
              _set_func = (o, val) => { o.MovementPattern = o.MovementPatternLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsMovementPattern != c.idfsMovementPattern || o.IsRIRPropChanged(_str_MovementPattern, c)) 
                  m.Add(_str_MovementPattern, o.ObjectIdent + _str_MovementPattern, "Lookup", o.idfsMovementPattern == null ? "" : o.idfsMovementPattern.ToString(), o.IsReadOnly(_str_MovementPattern), o.IsInvisible(_str_MovementPattern), o.IsRequired(_str_MovementPattern)); }
              }, 
        
            new field_info {
              _name = _str_GrazingPattern, _type = "Lookup",
              _get_func = o => { if (o.GrazingPattern == null) return null; return o.GrazingPattern.idfsBaseReference; },
              _set_func = (o, val) => { o.GrazingPattern = o.GrazingPatternLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsGrazingPattern != c.idfsGrazingPattern || o.IsRIRPropChanged(_str_GrazingPattern, c)) 
                  m.Add(_str_GrazingPattern, o.ObjectIdent + _str_GrazingPattern, "Lookup", o.idfsGrazingPattern == null ? "" : o.idfsGrazingPattern.ToString(), o.IsReadOnly(_str_GrazingPattern), o.IsInvisible(_str_GrazingPattern), o.IsRequired(_str_GrazingPattern)); }
              }, 
        
            new field_info {
              _name = _str_AvianFarmProductionType, _type = "Lookup",
              _get_func = o => { if (o.AvianFarmProductionType == null) return null; return o.AvianFarmProductionType.idfsBaseReference; },
              _set_func = (o, val) => { o.AvianFarmProductionType = o.AvianFarmProductionTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAvianProductionType != c.idfsAvianProductionType || o.IsRIRPropChanged(_str_AvianFarmProductionType, c)) 
                  m.Add(_str_AvianFarmProductionType, o.ObjectIdent + _str_AvianFarmProductionType, "Lookup", o.idfsAvianProductionType == null ? "" : o.idfsAvianProductionType.ToString(), o.IsReadOnly(_str_AvianFarmProductionType), o.IsInvisible(_str_AvianFarmProductionType), o.IsRequired(_str_AvianFarmProductionType)); }
              }, 
        
            new field_info {
              _name = _str_AvianFarmType, _type = "Lookup",
              _get_func = o => { if (o.AvianFarmType == null) return null; return o.AvianFarmType.idfsBaseReference; },
              _set_func = (o, val) => { o.AvianFarmType = o.AvianFarmTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAvianFarmType != c.idfsAvianFarmType || o.IsRIRPropChanged(_str_AvianFarmType, c)) 
                  m.Add(_str_AvianFarmType, o.ObjectIdent + _str_AvianFarmType, "Lookup", o.idfsAvianFarmType == null ? "" : o.idfsAvianFarmType.ToString(), o.IsReadOnly(_str_AvianFarmType), o.IsInvisible(_str_AvianFarmType), o.IsRequired(_str_AvianFarmType)); }
              }, 
        
            new field_info {
              _name = _str_FarmIntendedUse, _type = "Lookup",
              _get_func = o => { if (o.FarmIntendedUse == null) return null; return o.FarmIntendedUse.idfsBaseReference; },
              _set_func = (o, val) => { o.FarmIntendedUse = o.FarmIntendedUseLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsIntendedUse != c.idfsIntendedUse || o.IsRIRPropChanged(_str_FarmIntendedUse, c)) 
                  m.Add(_str_FarmIntendedUse, o.ObjectIdent + _str_FarmIntendedUse, "Lookup", o.idfsIntendedUse == null ? "" : o.idfsIntendedUse.ToString(), o.IsReadOnly(_str_FarmIntendedUse), o.IsInvisible(_str_FarmIntendedUse), o.IsRequired(_str_FarmIntendedUse)); }
              }, 
        
            new field_info {
              _name = _str_FarmLivestockTree, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.FarmLivestockTree.Count != c.FarmLivestockTree.Count || o.IsReadOnly(_str_FarmLivestockTree) != c.IsReadOnly(_str_FarmLivestockTree) || o.IsInvisible(_str_FarmLivestockTree) != c.IsInvisible(_str_FarmLivestockTree) || o.IsRequired(_str_FarmLivestockTree) != c.IsRequired(_str_FarmLivestockTree)) 
                  m.Add(_str_FarmLivestockTree, o.ObjectIdent + _str_FarmLivestockTree, "Child", o.idfFarm == null ? "" : o.idfFarm.ToString(), o.IsReadOnly(_str_FarmLivestockTree), o.IsInvisible(_str_FarmLivestockTree), o.IsRequired(_str_FarmLivestockTree)); }
              }, 
        
            new field_info {
              _name = _str_FarmAvianTree, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.FarmAvianTree.Count != c.FarmAvianTree.Count || o.IsReadOnly(_str_FarmAvianTree) != c.IsReadOnly(_str_FarmAvianTree) || o.IsInvisible(_str_FarmAvianTree) != c.IsInvisible(_str_FarmAvianTree) || o.IsRequired(_str_FarmAvianTree) != c.IsRequired(_str_FarmAvianTree)) 
                  m.Add(_str_FarmAvianTree, o.ObjectIdent + _str_FarmAvianTree, "Child", o.idfFarm == null ? "" : o.idfFarm.ToString(), o.IsReadOnly(_str_FarmAvianTree), o.IsInvisible(_str_FarmAvianTree), o.IsRequired(_str_FarmAvianTree)); }
              }, 
        
            new field_info {
              _name = _str_Location, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Location != null) o.Location._compare(c.Location, m); }
              }, 
        
            new field_info {
              _name = _str_Address, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
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
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(GeoLocation), eidss.model.Schema.GeoLocation._str_idfGeoLocation, _str_idfFarmLocation)]
        public GeoLocation Location
        {
            get 
            {   
                if (!_LocationLoaded)
                {
                    _LocationLoaded = true;
                    _getAccessor()._LoadLocation(this);
                    if (_Location != null) 
                        _Location.Parent = this;
                }
                return _Location; 
            }
            set 
            {   
                if (!_LocationLoaded) { _LocationLoaded = true; }
                _Location = value;
                if (_Location != null) 
                { 
                    _Location.m_ObjectName = _str_Location;
                    _Location.Parent = this;
                }
                idfFarmLocation = _Location == null 
                        ? new Int64?()
                        : _Location.idfGeoLocation;
                
            }
        }
        protected GeoLocation _Location;
                    
        private bool _LocationLoaded = false;
                    
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
                    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsOwnershipStructure)]
        public BaseReference OwnershipStructure
        {
            get { return _OwnershipStructure == null ? null : ((long)_OwnershipStructure.Key == 0 ? null : _OwnershipStructure); }
            set 
            { 
                _OwnershipStructure = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsOwnershipStructure = _OwnershipStructure == null 
                    ? new Int64?()
                    : _OwnershipStructure.idfsBaseReference; 
                OnPropertyChanged(_str_OwnershipStructure); 
            }
        }
        private BaseReference _OwnershipStructure;

        
        public BaseReferenceList OwnershipStructureLookup
        {
            get { return _OwnershipStructureLookup; }
        }
        private BaseReferenceList _OwnershipStructureLookup = new BaseReferenceList("rftOwnershipType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsLivestockProductionType)]
        public BaseReference LivestockProductionType
        {
            get { return _LivestockProductionType == null ? null : ((long)_LivestockProductionType.Key == 0 ? null : _LivestockProductionType); }
            set 
            { 
                _LivestockProductionType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsLivestockProductionType = _LivestockProductionType == null 
                    ? new Int64?()
                    : _LivestockProductionType.idfsBaseReference; 
                OnPropertyChanged(_str_LivestockProductionType); 
            }
        }
        private BaseReference _LivestockProductionType;

        
        public BaseReferenceList LivestockProductionTypeLookup
        {
            get { return _LivestockProductionTypeLookup; }
        }
        private BaseReferenceList _LivestockProductionTypeLookup = new BaseReferenceList("rftLivestockProductionType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsMovementPattern)]
        public BaseReference MovementPattern
        {
            get { return _MovementPattern == null ? null : ((long)_MovementPattern.Key == 0 ? null : _MovementPattern); }
            set 
            { 
                _MovementPattern = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsMovementPattern = _MovementPattern == null 
                    ? new Int64?()
                    : _MovementPattern.idfsBaseReference; 
                OnPropertyChanged(_str_MovementPattern); 
            }
        }
        private BaseReference _MovementPattern;

        
        public BaseReferenceList MovementPatternLookup
        {
            get { return _MovementPatternLookup; }
        }
        private BaseReferenceList _MovementPatternLookup = new BaseReferenceList("rftMovementPattern");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsGrazingPattern)]
        public BaseReference GrazingPattern
        {
            get { return _GrazingPattern == null ? null : ((long)_GrazingPattern.Key == 0 ? null : _GrazingPattern); }
            set 
            { 
                _GrazingPattern = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsGrazingPattern = _GrazingPattern == null 
                    ? new Int64?()
                    : _GrazingPattern.idfsBaseReference; 
                OnPropertyChanged(_str_GrazingPattern); 
            }
        }
        private BaseReference _GrazingPattern;

        
        public BaseReferenceList GrazingPatternLookup
        {
            get { return _GrazingPatternLookup; }
        }
        private BaseReferenceList _GrazingPatternLookup = new BaseReferenceList("rftGrazingPattern");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAvianProductionType)]
        public BaseReference AvianFarmProductionType
        {
            get { return _AvianFarmProductionType == null ? null : ((long)_AvianFarmProductionType.Key == 0 ? null : _AvianFarmProductionType); }
            set 
            { 
                _AvianFarmProductionType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAvianProductionType = _AvianFarmProductionType == null 
                    ? new Int64?()
                    : _AvianFarmProductionType.idfsBaseReference; 
                OnPropertyChanged(_str_AvianFarmProductionType); 
            }
        }
        private BaseReference _AvianFarmProductionType;

        
        public BaseReferenceList AvianFarmProductionTypeLookup
        {
            get { return _AvianFarmProductionTypeLookup; }
        }
        private BaseReferenceList _AvianFarmProductionTypeLookup = new BaseReferenceList("rftAvianProductionType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAvianFarmType)]
        public BaseReference AvianFarmType
        {
            get { return _AvianFarmType == null ? null : ((long)_AvianFarmType.Key == 0 ? null : _AvianFarmType); }
            set 
            { 
                _AvianFarmType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAvianFarmType = _AvianFarmType == null 
                    ? new Int64?()
                    : _AvianFarmType.idfsBaseReference; 
                OnPropertyChanged(_str_AvianFarmType); 
            }
        }
        private BaseReference _AvianFarmType;

        
        public BaseReferenceList AvianFarmTypeLookup
        {
            get { return _AvianFarmTypeLookup; }
        }
        private BaseReferenceList _AvianFarmTypeLookup = new BaseReferenceList("rftAvianFarmType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsIntendedUse)]
        public BaseReference FarmIntendedUse
        {
            get { return _FarmIntendedUse == null ? null : ((long)_FarmIntendedUse.Key == 0 ? null : _FarmIntendedUse); }
            set 
            { 
                _FarmIntendedUse = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsIntendedUse = _FarmIntendedUse == null 
                    ? new Int64?()
                    : _FarmIntendedUse.idfsBaseReference; 
                OnPropertyChanged(_str_FarmIntendedUse); 
            }
        }
        private BaseReference _FarmIntendedUse;

        
        public BaseReferenceList FarmIntendedUseLookup
        {
            get { return _FarmIntendedUseLookup; }
        }
        private BaseReferenceList _FarmIntendedUseLookup = new BaseReferenceList("rftFarmIntendedUse");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_OwnershipStructure:
                    return new BvSelectList(OwnershipStructureLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, OwnershipStructure, _str_idfsOwnershipStructure);
            
                case _str_LivestockProductionType:
                    return new BvSelectList(LivestockProductionTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, LivestockProductionType, _str_idfsLivestockProductionType);
            
                case _str_MovementPattern:
                    return new BvSelectList(MovementPatternLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, MovementPattern, _str_idfsMovementPattern);
            
                case _str_GrazingPattern:
                    return new BvSelectList(GrazingPatternLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, GrazingPattern, _str_idfsGrazingPattern);
            
                case _str_AvianFarmProductionType:
                    return new BvSelectList(AvianFarmProductionTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AvianFarmProductionType, _str_idfsAvianProductionType);
            
                case _str_AvianFarmType:
                    return new BvSelectList(AvianFarmTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AvianFarmType, _str_idfsAvianFarmType);
            
                case _str_FarmIntendedUse:
                    return new BvSelectList(FarmIntendedUseLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, FarmIntendedUse, _str_idfsIntendedUse);
            
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
        
            if (_Location != null) { _Location.Parent = this; }
                
            if (_Address != null) { _Address.Parent = this; }
                FarmLivestockTree.ForEach(c => { c.Parent = this; });
                FarmAvianTree.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as FarmRootPanel;
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
            var ret = base.Clone() as FarmRootPanel;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Location != null)
              ret.Location = _Location.CloneWithSetup(manager) as GeoLocation;
                
            if (_Address != null)
              ret.Address = _Address.CloneWithSetup(manager) as Address;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
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
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || (_Location != null && _Location.HasChanges)
                
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
            var _prev_idfsLivestockProductionType_LivestockProductionType = idfsLivestockProductionType;
            var _prev_idfsMovementPattern_MovementPattern = idfsMovementPattern;
            var _prev_idfsGrazingPattern_GrazingPattern = idfsGrazingPattern;
            var _prev_idfsAvianProductionType_AvianFarmProductionType = idfsAvianProductionType;
            var _prev_idfsAvianFarmType_AvianFarmType = idfsAvianFarmType;
            var _prev_idfsIntendedUse_FarmIntendedUse = idfsIntendedUse;
            base.RejectChanges();
        
            if (_prev_idfsOwnershipStructure_OwnershipStructure != idfsOwnershipStructure)
            {
                _OwnershipStructure = _OwnershipStructureLookup.FirstOrDefault(c => c.idfsBaseReference == idfsOwnershipStructure);
            }
            if (_prev_idfsLivestockProductionType_LivestockProductionType != idfsLivestockProductionType)
            {
                _LivestockProductionType = _LivestockProductionTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsLivestockProductionType);
            }
            if (_prev_idfsMovementPattern_MovementPattern != idfsMovementPattern)
            {
                _MovementPattern = _MovementPatternLookup.FirstOrDefault(c => c.idfsBaseReference == idfsMovementPattern);
            }
            if (_prev_idfsGrazingPattern_GrazingPattern != idfsGrazingPattern)
            {
                _GrazingPattern = _GrazingPatternLookup.FirstOrDefault(c => c.idfsBaseReference == idfsGrazingPattern);
            }
            if (_prev_idfsAvianProductionType_AvianFarmProductionType != idfsAvianProductionType)
            {
                _AvianFarmProductionType = _AvianFarmProductionTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAvianProductionType);
            }
            if (_prev_idfsAvianFarmType_AvianFarmType != idfsAvianFarmType)
            {
                _AvianFarmType = _AvianFarmTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAvianFarmType);
            }
            if (_prev_idfsIntendedUse_FarmIntendedUse != idfsIntendedUse)
            {
                _FarmIntendedUse = _FarmIntendedUseLookup.FirstOrDefault(c => c.idfsBaseReference == idfsIntendedUse);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (Location != null) Location.RejectChanges();
                
            if (Address != null) Address.RejectChanges();
                FarmLivestockTree.RejectChanges();
                FarmAvianTree.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Location != null) _Location.AcceptChanges();
                
            if (_Address != null) _Address.AcceptChanges();
                FarmLivestockTree.AcceptChanges();
                FarmAvianTree.AcceptChanges();
                
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
        
            if (_Location != null) _Location.SetChange();
                
            if (_Address != null) _Address.SetChange();
                FarmLivestockTree.ForEach(c => c.SetChange());
                FarmAvianTree.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, FarmRootPanel c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public FarmRootPanel()
        {
            
            m_permissions = new Permissions(this);
            
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

    
        private static string[] readonly_names1 = "strFarmCode".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<FarmRootPanel, bool>(c => true)(this);
            
            return ReadOnly || new Func<FarmRootPanel, bool>(c => false)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_Location != null)
                    _Location.ReadOnly = value;
                
                if (_Address != null)
                    _Address.ReadOnly = value;
                
                foreach(var o in _FarmLivestockTree)
                    o.ReadOnly = value;
                
                foreach(var o in _FarmAvianTree)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<FarmRootPanel, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<FarmRootPanel, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<FarmRootPanel, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<FarmRootPanel, bool>> m_isHiddenPersonalData;
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
        ~FarmRootPanel()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftOwnershipType", this);
                
                LookupManager.RemoveObject("rftLivestockProductionType", this);
                
                LookupManager.RemoveObject("rftMovementPattern", this);
                
                LookupManager.RemoveObject("rftGrazingPattern", this);
                
                LookupManager.RemoveObject("rftAvianProductionType", this);
                
                LookupManager.RemoveObject("rftAvianFarmType", this);
                
                LookupManager.RemoveObject("rftFarmIntendedUse", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftOwnershipType")
                _getAccessor().LoadLookup_OwnershipStructure(manager, this);
            
            if (lookup_object == "rftLivestockProductionType")
                _getAccessor().LoadLookup_LivestockProductionType(manager, this);
            
            if (lookup_object == "rftMovementPattern")
                _getAccessor().LoadLookup_MovementPattern(manager, this);
            
            if (lookup_object == "rftGrazingPattern")
                _getAccessor().LoadLookup_GrazingPattern(manager, this);
            
            if (lookup_object == "rftAvianProductionType")
                _getAccessor().LoadLookup_AvianFarmProductionType(manager, this);
            
            if (lookup_object == "rftAvianFarmType")
                _getAccessor().LoadLookup_AvianFarmType(manager, this);
            
            if (lookup_object == "rftFarmIntendedUse")
                _getAccessor().LoadLookup_FarmIntendedUse(manager, this);
            
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
        
            if (_Location != null) _Location.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_Address != null) _Address.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_FarmLivestockTree != null) _FarmLivestockTree.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_FarmAvianTree != null) _FarmAvianTree.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<FarmRootPanel>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(FarmRootPanel obj);
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
            private GeoLocation.Accessor LocationAccessor { get { return eidss.model.Schema.GeoLocation.Accessor.Instance(m_CS); } }
            private Address.Accessor AddressAccessor { get { return eidss.model.Schema.Address.Accessor.Instance(m_CS); } }
            private RootFarmTree.Accessor FarmLivestockTreeAccessor { get { return eidss.model.Schema.RootFarmTree.Accessor.Instance(m_CS); } }
            private RootFarmTree.Accessor FarmAvianTreeAccessor { get { return eidss.model.Schema.RootFarmTree.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor OwnershipStructureAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor LivestockProductionTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor MovementPatternAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor GrazingPatternAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AvianFarmProductionTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AvianFarmTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor FarmIntendedUseAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            

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
            
                MapResultSet[] sets = new MapResultSet[1];
                List<FarmRootPanel> objs = new List<FarmRootPanel>();
                sets[0] = new MapResultSet(typeof(FarmRootPanel), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spFarmPanel_SelectDetail"
                            , manager.Parameter("@idfFarm", idfFarm)
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    FarmRootPanel obj = objs[0];
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
                    throw DbModelException.Create(e);
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
            
            internal void _LoadLocation(FarmRootPanel obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLocation(manager, obj);
                }
            }
            internal void _LoadLocation(DbManagerProxy manager, FarmRootPanel obj)
            {
                
                if (obj.Location == null && obj.idfFarmLocation != null && obj.idfFarmLocation != 0)
                {
                    obj.Location = LocationAccessor.SelectByKey(manager
                        
                        , obj.idfFarmLocation.Value
                        );
                    if (obj.Location != null)
                    {
                        obj.Location.m_ObjectName = _str_Location;
                    }
                }
                    
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
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, FarmRootPanel obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadFarmLivestockTree(manager, obj);
                _LoadFarmAvianTree(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj._blnAllowFarmReload = true;
                obj.Location = new Func<FarmRootPanel, GeoLocation>(c =>c.Location ?? LocationAccessor.CreateWithCountry(manager, c))(obj);
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
                    LocationAccessor._SetPermitions(obj._permissions, obj.Location);
                    AddressAccessor._SetPermitions(obj._permissions, obj.Address);
                    
                        obj.FarmLivestockTree.ForEach(c => FarmLivestockTreeAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.FarmAvianTree.ForEach(c => FarmAvianTreeAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private FarmRootPanel _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    FarmRootPanel obj = FarmRootPanel.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    obj._HACode = HACode;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfFarm = (new GetNewIDExtender<FarmRootPanel>()).GetScalar(manager, obj);
                obj.strFarmCode = new Func<FarmRootPanel, string>(c => "(new farm)")(obj);
                obj.Address = (new ObjectCreateExtender<Address.Accessor, Address>()).Create(manager, obj
                
                        , obj._HACode);
                    
                obj.Location = new Func<FarmRootPanel, GeoLocation>(c => LocationAccessor.CreateWithCountry(manager, c))(obj);
                obj.FarmLivestockTree.Add(new Func<FarmRootPanel, RootFarmTree>(c => FarmLivestockTreeAccessor.CreateFarm(manager, c, c, (int)eidss.model.Enums.HACode.Livestock))(obj));
                obj.FarmAvianTree.Add(new Func<FarmRootPanel, RootFarmTree>(c => FarmAvianTreeAccessor.CreateFarm(manager, c, c, (int)eidss.model.Enums.HACode.Avian))(obj));
                obj.blnIsLivestock = new Func<FarmRootPanel, bool?>(c=> obj._HACode == (int)eidss.model.Enums.HACode.Livestock )(obj);
                obj.blnIsAvian = new Func<FarmRootPanel, bool?>(c=> obj._HACode == (int)eidss.model.Enums.HACode.Avian)(obj);
                obj._blnAllowFarmReload = true;
                obj.idfObservation = (new GetNewIDExtender<FarmRootPanel>()).GetScalar(manager, obj);
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
                obj.Location.blnGeoLocationShared = true;
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

            
            public FarmRootPanel CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
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
                    throw new PermissionException("VetCase", "CreateFlock");
                
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
                    throw new PermissionException("VetCase", "CreateLvstckSpecies");
                
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
                    throw new PermissionException("VetCase", "CreateAvianSpecies");
                
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
                        false
                    )).Validate(obj, item, (farm,i) => 
                                            farm.FarmAvianTree.Where(c => 
                                                c.idfParentParty == i.idfParentParty 
                                                && c.idfParty != i.idfParty 
                                                && c.strName == i.strName
                                                && c.strName != "947220000000"
                                                && !c.IsMarkedToDelete
                                                ).Count() == 0
                    );
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("strName");
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
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
                        false
                    )).Validate(obj, item, (farm,i) => 
                                              farm.FarmLivestockTree.Where(c => 
                                                  c.idfParentParty == i.idfParentParty 
                                                  && c.idfParty != i.idfParty 
                                                  && c.strName == i.strName
                                                  && c.strName != "947220000000"
                                                  && !c.IsMarkedToDelete
                                                  ).Count() == 0
                    );
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("strName");
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
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
                            
                foreach(var o in obj.FarmLivestockTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
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
                            
                foreach(var o in obj.FarmLivestockTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
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
                            
                foreach(var o in obj.FarmLivestockTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
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
                            
                foreach(var o in obj.FarmAvianTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
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
                            
                foreach(var o in obj.FarmAvianTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
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
                            
                foreach(var o in obj.FarmAvianTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
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
                            
                foreach(var o in obj.FarmAvianTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Herd || c.idfsPartyType == (long)PartyTypeEnum.Species))
                {
                    if (newobj == null || newobj == o)
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
                        .Where(c => c.idfsBaseReference == obj.idfsOwnershipStructure)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftOwnershipType", obj, OwnershipStructureAccessor.GetType(), "rftOwnershipType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_LivestockProductionType(DbManagerProxy manager, FarmRootPanel obj)
            {
                
                obj.LivestockProductionTypeLookup.Clear();
                
                obj.LivestockProductionTypeLookup.Add(LivestockProductionTypeAccessor.CreateNewT(manager, null));
                
                obj.LivestockProductionTypeLookup.AddRange(LivestockProductionTypeAccessor.rftLivestockProductionType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsLivestockProductionType))
                    
                    .ToList());
                
                if (obj.idfsLivestockProductionType != null && obj.idfsLivestockProductionType != 0)
                {
                    obj.LivestockProductionType = obj.LivestockProductionTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsLivestockProductionType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftLivestockProductionType", obj, LivestockProductionTypeAccessor.GetType(), "rftLivestockProductionType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_MovementPattern(DbManagerProxy manager, FarmRootPanel obj)
            {
                
                obj.MovementPatternLookup.Clear();
                
                obj.MovementPatternLookup.Add(MovementPatternAccessor.CreateNewT(manager, null));
                
                obj.MovementPatternLookup.AddRange(MovementPatternAccessor.rftMovementPattern_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsMovementPattern))
                    
                    .ToList());
                
                if (obj.idfsMovementPattern != null && obj.idfsMovementPattern != 0)
                {
                    obj.MovementPattern = obj.MovementPatternLookup
                        .Where(c => c.idfsBaseReference == obj.idfsMovementPattern)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftMovementPattern", obj, MovementPatternAccessor.GetType(), "rftMovementPattern_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_GrazingPattern(DbManagerProxy manager, FarmRootPanel obj)
            {
                
                obj.GrazingPatternLookup.Clear();
                
                obj.GrazingPatternLookup.Add(GrazingPatternAccessor.CreateNewT(manager, null));
                
                obj.GrazingPatternLookup.AddRange(GrazingPatternAccessor.rftGrazingPattern_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsGrazingPattern))
                    
                    .ToList());
                
                if (obj.idfsGrazingPattern != null && obj.idfsGrazingPattern != 0)
                {
                    obj.GrazingPattern = obj.GrazingPatternLookup
                        .Where(c => c.idfsBaseReference == obj.idfsGrazingPattern)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftGrazingPattern", obj, GrazingPatternAccessor.GetType(), "rftGrazingPattern_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_AvianFarmProductionType(DbManagerProxy manager, FarmRootPanel obj)
            {
                
                obj.AvianFarmProductionTypeLookup.Clear();
                
                obj.AvianFarmProductionTypeLookup.Add(AvianFarmProductionTypeAccessor.CreateNewT(manager, null));
                
                obj.AvianFarmProductionTypeLookup.AddRange(AvianFarmProductionTypeAccessor.rftAvianProductionType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAvianProductionType))
                    
                    .ToList());
                
                if (obj.idfsAvianProductionType != null && obj.idfsAvianProductionType != 0)
                {
                    obj.AvianFarmProductionType = obj.AvianFarmProductionTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsAvianProductionType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftAvianProductionType", obj, AvianFarmProductionTypeAccessor.GetType(), "rftAvianProductionType_SelectList"
                  , "SelectLookupList");
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
                        .Where(c => c.idfsBaseReference == obj.idfsAvianFarmType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftAvianFarmType", obj, AvianFarmTypeAccessor.GetType(), "rftAvianFarmType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_FarmIntendedUse(DbManagerProxy manager, FarmRootPanel obj)
            {
                
                obj.FarmIntendedUseLookup.Clear();
                
                obj.FarmIntendedUseLookup.Add(FarmIntendedUseAccessor.CreateNewT(manager, null));
                
                obj.FarmIntendedUseLookup.AddRange(FarmIntendedUseAccessor.rftFarmIntendedUse_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsIntendedUse))
                    
                    .ToList());
                
                if (obj.idfsIntendedUse != null && obj.idfsIntendedUse != 0)
                {
                    obj.FarmIntendedUse = obj.FarmIntendedUseLookup
                        .Where(c => c.idfsBaseReference == obj.idfsIntendedUse)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftFarmIntendedUse", obj, FarmIntendedUseAccessor.GetType(), "rftFarmIntendedUse_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, FarmRootPanel obj)
            {
                
                LoadLookup_OwnershipStructure(manager, obj);
                
                LoadLookup_LivestockProductionType(manager, obj);
                
                LoadLookup_MovementPattern(manager, obj);
                
                LoadLookup_GrazingPattern(manager, obj);
                
                LoadLookup_AvianFarmProductionType(manager, obj);
                
                LoadLookup_AvianFarmType(manager, obj);
                
                LoadLookup_FarmIntendedUse(manager, obj);
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spFarmPanel_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfRootFarm", "strFarmCode", "idfRootOwner")] FarmRootPanel obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfRootFarm", "strFarmCode", "idfRootOwner")] FarmRootPanel obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    FarmRootPanel bo = obj as FarmRootPanel;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("VetCase", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("VetCase", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("VetCase", "Update");
                    }
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfFarm;
                        
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
            private bool _PostNonTransaction(DbManagerProxy manager, FarmRootPanel obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.Location != null)
                    {
                        obj.Location.MarkToDelete();
                        if (!LocationAccessor.Post(manager, obj.Location, true))
                            return false;
                    }
                                    
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
                      if (!obj.blnIsAvian.Value)
                      {
                      obj.FarmAvianTree.Clear();
                      obj.idfsAvianFarmType = null;
                      obj.idfsAvianProductionType = null;
                      obj.idfsIntendedUse = null;
                      obj.intBirdsPerBuilding = null;
                      obj.intBuidings = null;
                      }
                      if(!obj.blnIsLivestock.Value)
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
                obj.AcceptChanges();
                
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
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as FarmRootPanel, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, FarmRootPanel obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "Address.idfsCountry", "Address.Country","Farm.Address.idfsCountry",
                false
              )).Validate(c => true, obj, obj.Address.idfsCountry);
            
                (new RequiredValidator( "Address.idfsRegion", "Address.Region","Farm.Address.idfsRegion",
                false
              )).Validate(c => true, obj, obj.Address.idfsRegion);
            
                (new RequiredValidator( "Address.idfsRayon", "Address.Rayon","Farm.Address.idfsRayon",
                false
              )).Validate(c => true, obj, obj.Address.idfsRayon);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                        foreach(var item in obj.FarmAvianTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Species))
                        {
                        
                (new PredicateValidator("DuplicateSpeciesAvian_msgId", "strName", "FarmAvianTree", "strName",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (farm,i) => 
                                            farm.FarmAvianTree.Where(c => 
                                                c.idfParentParty == i.idfParentParty 
                                                && c.idfParty != i.idfParty 
                                                && c.strName == i.strName
                                                && c.strName != "947220000000"
                                                && !c.IsMarkedToDelete
                                                ).Count() == 0
                    );
            
                        }
                
                        foreach(var item in obj.FarmLivestockTree.Where(c => c.idfsPartyType == (long)PartyTypeEnum.Species))
                        {
                        
                (new PredicateValidator("DuplicateSpeciesLivestock_msgId", "strName", "FarmLivestockTree", "strName",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (farm,i) => 
                                              farm.FarmLivestockTree.Where(c => 
                                                  c.idfParentParty == i.idfParentParty 
                                                  && c.idfParty != i.idfParty 
                                                  && c.strName == i.strName
                                                  && c.strName != "947220000000"
                                                  && !c.IsMarkedToDelete
                                                  ).Count() == 0
                    );
            
                        }
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Location != null)
                            LocationAccessor.Validate(manager, obj.Location, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Address != null)
                            AddressAccessor.Validate(manager, obj.Address, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FarmAvianTree != null)
                            foreach (var i in obj.FarmAvianTree.Where(c => !c.IsMarkedToDelete))
                                FarmAvianTreeAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FarmLivestockTree != null)
                            foreach (var i in obj.FarmLivestockTree.Where(c => !c.IsMarkedToDelete))
                                FarmLivestockTreeAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VetCase.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VetCase.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VetCase.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VetCase.Insert"); } }
            
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
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VetCase.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VetCase.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VetCase.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VetCase.Insert"); } }
            
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
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<FarmRootPanel, bool>> RequiredByField = new Dictionary<string, Func<FarmRootPanel, bool>>();
            public static Dictionary<string, Func<FarmRootPanel, bool>> RequiredByProperty = new Dictionary<string, Func<FarmRootPanel, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strContactPhone, 200);
                Sizes.Add(_str_strInternationalName, 200);
                Sizes.Add(_str_strNationalName, 200);
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_strFax, 200);
                Sizes.Add(_str_strEmail, 200);
                Sizes.Add(_str_strFullName, 602);
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
                    false
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
                    false
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
                    false
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
                    false
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	