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
    public abstract partial class FarmRoot : 
        EditableObject<FarmRoot>
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
            internal Func<FarmRoot, object> _get_func;
            internal Action<FarmRoot, string> _set_func;
            internal Action<FarmRoot, FarmRoot, CompareModel> _compare_func;
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
        internal const string _str_Location = "Location";
        internal const string _str_Address = "Address";
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
            FarmRoot obj = (FarmRoot)o;
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
                    
        private BvSelectList _getList(string name)
        {
        
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
        internal string m_ObjectName = "FarmRoot";

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
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as FarmRoot;
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
            var ret = base.Clone() as FarmRoot;
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
        public FarmRoot CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as FarmRoot;
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
        
            if (Location != null) Location.RejectChanges();
                
            if (Address != null) Address.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Location != null) _Location.AcceptChanges();
                
            if (_Address != null) _Address.AcceptChanges();
                
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

      private bool IsRIRPropChanged(string fld, FarmRoot c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public FarmRoot()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(FarmRoot_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(FarmRoot_PropertyChanged);
        }
        private void FarmRoot_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as FarmRoot).Changed(e.PropertyName);
            
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
            FarmRoot obj = this;
            
        }
        private void _DeletedExtenders()
        {
            FarmRoot obj = this;
            
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
                return ReadOnly || new Func<FarmRoot, bool>(c => true)(this);
            
            return ReadOnly || new Func<FarmRoot, bool>(c => false)(this);
                
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
                
            }
        }


        public Dictionary<string, Func<FarmRoot, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<FarmRoot, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<FarmRoot, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<FarmRoot, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<FarmRoot, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<FarmRoot, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~FarmRoot()
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
        
            if (_Location != null) _Location.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_Address != null) _Address.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<FarmRoot>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(FarmRoot obj);
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

            
            public virtual FarmRoot SelectByKey(DbManagerProxy manager
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
            
      
            private FarmRoot _SelectByKey(DbManagerProxy manager
                , Int64? idfFarm
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<FarmRoot> objs = new List<FarmRoot>();
                sets[0] = new MapResultSet(typeof(FarmRoot), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spFarmPanel_SelectDetail"
                            , manager.Parameter("@idfFarm", idfFarm)
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    FarmRoot obj = objs[0];
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
    
            internal void _LoadLocation(FarmRoot obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLocation(manager, obj);
                }
            }
            internal void _LoadLocation(DbManagerProxy manager, FarmRoot obj)
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
            
            internal void _LoadAddress(FarmRoot obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadAddress(manager, obj);
                }
            }
            internal void _LoadAddress(DbManagerProxy manager, FarmRoot obj)
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
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, FarmRoot obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj._blnAllowFarmReload = true;
                obj.Location = new Func<FarmRoot, GeoLocation>(c =>c.Location ?? LocationAccessor.CreateWithCountry(manager, c))(obj);
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, FarmRoot obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    LocationAccessor._SetPermitions(obj._permissions, obj.Location);
                    AddressAccessor._SetPermitions(obj._permissions, obj.Address);
                    
                    }
                }
            }

    

            private FarmRoot _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    FarmRoot obj = FarmRoot.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    obj._HACode = HACode;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfFarm = (new GetNewIDExtender<FarmRoot>()).GetScalar(manager, obj);
                obj.strFarmCode = new Func<FarmRoot, string>(c => "(new farm)")(obj);
                obj.Address = (new ObjectCreateExtender<Address.Accessor, Address>()).Create(manager, obj
                
                        , obj._HACode);
                    
                obj.Location = new Func<FarmRoot, GeoLocation>(c => LocationAccessor.CreateWithCountry(manager, c))(obj);
                obj._blnAllowFarmReload = true;
                obj.idfObservation = (new GetNewIDExtender<FarmRoot>()).GetScalar(manager, obj);
                obj.blnRootFarm = true;
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
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

            
            public FarmRoot CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public FarmRoot CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(FarmRoot obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(FarmRoot obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, FarmRoot obj)
            {
                
            }
    
            [SprocName("spFarm_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spFarm_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spFarmPanel_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfRootFarm", "strFarmCode", "idfRootOwner")] FarmRoot obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfRootFarm", "strFarmCode", "idfRootOwner")] FarmRoot obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    FarmRoot bo = obj as FarmRoot;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as FarmRoot, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, FarmRoot obj, bool bChildObject) 
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
                obj.strFarmCode = new Func<FarmRoot, DbManagerProxy, string>((c,m) => 
                        c.strFarmCode != "(new farm)" 
                        ? c.strFarmCode 
                        : m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.Farm, DBNull.Value, DBNull.Value)
                        .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue"))(obj, manager);
                      obj.idfsAvianFarmType = null;
                      obj.idfsAvianProductionType = null;
                      obj.idfsIntendedUse = null;
                      obj.intBirdsPerBuilding = null;
                      obj.intBuidings = null;
                      
                      obj.idfsOwnershipStructure = null;
                      obj.idfsLivestockProductionType = null;
                      obj.idfsMovementPattern = null;
                      obj.idfsGrazingPattern = null;
                    
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
                                    
                    // posted extenters - begin
                obj._blnAllowFarmReload = true;
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(FarmRoot obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, FarmRoot obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfFarm
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
                return Validate(manager, obj as FarmRoot, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, FarmRoot obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
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
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Location != null)
                            LocationAccessor.Validate(manager, obj.Location, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Address != null)
                            AddressAccessor.Validate(manager, obj.Address, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
            
            private void _SetupRequired(FarmRoot obj)
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
    
    private void _SetupPersonalDataRestrictions(FarmRoot obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as FarmRoot) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as FarmRoot) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "FarmRootDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private FarmRoot m_obj;
            internal Permissions(FarmRoot obj)
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
            public static string spDelete = "spFarm_Delete";
            public static string spCanDelete = "spFarm_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<FarmRoot, bool>> RequiredByField = new Dictionary<string, Func<FarmRoot, bool>>();
            public static Dictionary<string, Func<FarmRoot, bool>> RequiredByProperty = new Dictionary<string, Func<FarmRoot, bool>>();
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
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((FarmRoot)c).MarkToDelete() && ObjectAccessor.PostInterface<FarmRoot>().Post(manager, (FarmRoot)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<FarmRoot>().Post(manager, (FarmRoot)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<FarmRoot>().Post(manager, (FarmRoot)c), c),
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
	