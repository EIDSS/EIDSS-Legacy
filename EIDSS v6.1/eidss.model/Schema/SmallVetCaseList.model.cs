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
    public abstract partial class SmallVetCaseListItem : 
        EditableObject<SmallVetCaseListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCase { get; set; }
                
        [LocalizedDisplayName(_str_datAssignedDate)]
        [MapField(_str_datAssignedDate)]
        public abstract DateTime? datAssignedDate { get; set; }
        protected DateTime? datAssignedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAssignedDate).OriginalValue; } }
        protected DateTime? datAssignedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAssignedDate).PreviousValue; } }
                
        [LocalizedDisplayName("datEnteredDateSearchPanel")]
        [MapField(_str_datEnteredDate)]
        public abstract DateTime? datEnteredDate { get; set; }
        protected DateTime? datEnteredDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).OriginalValue; } }
        protected DateTime? datEnteredDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCaseID)]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datReportDate)]
        [MapField(_str_datReportDate)]
        public abstract DateTime? datReportDate { get; set; }
        protected DateTime? datReportDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReportDate).OriginalValue; } }
        protected DateTime? datReportDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReportDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datInvestigationDate)]
        [MapField(_str_datInvestigationDate)]
        public abstract DateTime? datInvestigationDate { get; set; }
        protected DateTime? datInvestigationDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datInvestigationDate).OriginalValue; } }
        protected DateTime? datInvestigationDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datInvestigationDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsShowDiagnosis)]
        [MapField(_str_idfsShowDiagnosis)]
        public abstract Int64? idfsShowDiagnosis { get; set; }
        protected Int64? idfsShowDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsShowDiagnosis).OriginalValue; } }
        protected Int64? idfsShowDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsShowDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDiagnosisDate)]
        [MapField(_str_datDiagnosisDate)]
        public abstract DateTime? datDiagnosisDate { get; set; }
        protected DateTime? datDiagnosisDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDiagnosisDate).OriginalValue; } }
        protected DateTime? datDiagnosisDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDiagnosisDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTentativeDiagnosis)]
        [MapField(_str_idfsTentativeDiagnosis)]
        public abstract Int64? idfsTentativeDiagnosis { get; set; }
        protected Int64? idfsTentativeDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTentativeDiagnosis1)]
        [MapField(_str_idfsTentativeDiagnosis1)]
        public abstract Int64? idfsTentativeDiagnosis1 { get; set; }
        protected Int64? idfsTentativeDiagnosis1_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis1).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis1_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis1).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTentativeDiagnosis2)]
        [MapField(_str_idfsTentativeDiagnosis2)]
        public abstract Int64? idfsTentativeDiagnosis2 { get; set; }
        protected Int64? idfsTentativeDiagnosis2_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis2).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis2_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis2).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFinalDiagnosis)]
        [MapField(_str_idfsFinalDiagnosis)]
        public abstract Int64? idfsFinalDiagnosis { get; set; }
        protected Int64? idfsFinalDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalDiagnosis).OriginalValue; } }
        protected Int64? idfsFinalDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPersonEnteredBy)]
        [MapField(_str_idfPersonEnteredBy)]
        public abstract Int64? idfPersonEnteredBy { get; set; }
        protected Int64? idfPersonEnteredBy_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonEnteredBy).OriginalValue; } }
        protected Int64? idfPersonEnteredBy_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonEnteredBy).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseClassification)]
        [MapField(_str_idfsCaseClassification)]
        public abstract Int64? idfsCaseClassification { get; set; }
        protected Int64? idfsCaseClassification_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseClassification).OriginalValue; } }
        protected Int64? idfsCaseClassification_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseClassification).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseProgressStatus)]
        [MapField(_str_idfsCaseProgressStatus)]
        public abstract Int64? idfsCaseProgressStatus { get; set; }
        protected Int64? idfsCaseProgressStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseProgressStatus).OriginalValue; } }
        protected Int64? idfsCaseProgressStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseProgressStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseReportType)]
        [MapField(_str_idfsCaseReportType)]
        public abstract Int64 idfsCaseReportType { get; set; }
        protected Int64 idfsCaseReportType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseReportType).OriginalValue; } }
        protected Int64 idfsCaseReportType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseReportType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCaseReportType)]
        [MapField(_str_strCaseReportType)]
        public abstract String strCaseReportType { get; set; }
        protected String strCaseReportType_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseReportType).OriginalValue; } }
        protected String strCaseReportType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseReportType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_FinalDiagnosisName)]
        [MapField(_str_FinalDiagnosisName)]
        public abstract String FinalDiagnosisName { get; set; }
        protected String FinalDiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._finalDiagnosisName).OriginalValue; } }
        protected String FinalDiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._finalDiagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DiagnosisName)]
        [MapField(_str_DiagnosisName)]
        public abstract String DiagnosisName { get; set; }
        protected String DiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).OriginalValue; } }
        protected String DiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName("idfsCaseStatusShort")]
        [MapField(_str_CaseStatusName)]
        public abstract String CaseStatusName { get; set; }
        protected String CaseStatusName_Original { get { return ((EditableValue<String>)((dynamic)this)._caseStatusName).OriginalValue; } }
        protected String CaseStatusName_Previous { get { return ((EditableValue<String>)((dynamic)this)._caseStatusName).PreviousValue; } }
                
        [LocalizedDisplayName("idfsCaseClassificationShort")]
        [MapField(_str_CaseClassificationName)]
        public abstract String CaseClassificationName { get; set; }
        protected String CaseClassificationName_Original { get { return ((EditableValue<String>)((dynamic)this)._caseClassificationName).OriginalValue; } }
        protected String CaseClassificationName_Previous { get { return ((EditableValue<String>)((dynamic)this)._caseClassificationName).PreviousValue; } }
                
        [LocalizedDisplayName("idfsCaseType")]
        [MapField(_str_strCaseType)]
        public abstract String strCaseType { get; set; }
        protected String strCaseType_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseType).OriginalValue; } }
        protected String strCaseType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64 idfsCaseType { get; set; }
        protected Int64 idfsCaseType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64 idfsCaseType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseTypeNullable)]
        [MapField(_str_idfsCaseTypeNullable)]
        public abstract Int64? idfsCaseTypeNullable { get; set; }
        protected Int64? idfsCaseTypeNullable_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseTypeNullable).OriginalValue; } }
        protected Int64? idfsCaseTypeNullable_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseTypeNullable).PreviousValue; } }
                
        [LocalizedDisplayName(_str_uidOfflineCaseID)]
        [MapField(_str_uidOfflineCaseID)]
        public abstract Guid? uidOfflineCaseID { get; set; }
        protected Guid? uidOfflineCaseID_Original { get { return ((EditableValue<Guid?>)((dynamic)this)._uidOfflineCaseID).OriginalValue; } }
        protected Guid? uidOfflineCaseID_Previous { get { return ((EditableValue<Guid?>)((dynamic)this)._uidOfflineCaseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfAddress)]
        [MapField(_str_idfAddress)]
        public abstract Int64? idfAddress { get; set; }
        protected Int64? idfAddress_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAddress).OriginalValue; } }
        protected Int64? idfAddress_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAddress).PreviousValue; } }
                
        [LocalizedDisplayName("FarmAddress")]
        [MapField(_str_AddressName)]
        public abstract String AddressName { get; set; }
        protected String AddressName_Original { get { return ((EditableValue<String>)((dynamic)this)._addressName).OriginalValue; } }
        protected String AddressName_Previous { get { return ((EditableValue<String>)((dynamic)this)._addressName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCountry)]
        [MapField(_str_idfsCountry)]
        public abstract Int64? idfsCountry { get; set; }
        protected Int64? idfsCountry_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).OriginalValue; } }
        protected Int64? idfsCountry_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfFarm)]
        [MapField(_str_idfFarm)]
        public abstract Int64 idfFarm { get; set; }
        protected Int64 idfFarm_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).OriginalValue; } }
        protected Int64 idfFarm_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).PreviousValue; } }
                
        [LocalizedDisplayName(_str_FarmName)]
        [MapField(_str_FarmName)]
        public abstract String FarmName { get; set; }
        protected String FarmName_Original { get { return ((EditableValue<String>)((dynamic)this)._farmName).OriginalValue; } }
        protected String FarmName_Previous { get { return ((EditableValue<String>)((dynamic)this)._farmName).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfsFarmCategory)]
        [MapField(_str_idfsFarmCategory)]
        public abstract Int64? idfsFarmCategory { get; set; }
        protected Int64? idfsFarmCategory_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFarmCategory).OriginalValue; } }
        protected Int64? idfsFarmCategory_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFarmCategory).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsOwnershipStructure)]
        [MapField(_str_idfsOwnershipStructure)]
        public abstract Int64? idfsOwnershipStructure { get; set; }
        protected Int64? idfsOwnershipStructure_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOwnershipStructure).OriginalValue; } }
        protected Int64? idfsOwnershipStructure_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOwnershipStructure).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsMovementPattern)]
        [MapField(_str_idfsMovementPattern)]
        public abstract Int64? idfsMovementPattern { get; set; }
        protected Int64? idfsMovementPattern_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMovementPattern).OriginalValue; } }
        protected Int64? idfsMovementPattern_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMovementPattern).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsIntendedUse)]
        [MapField(_str_idfsIntendedUse)]
        public abstract Int64? idfsIntendedUse { get; set; }
        protected Int64? idfsIntendedUse_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsIntendedUse).OriginalValue; } }
        protected Int64? idfsIntendedUse_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsIntendedUse).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsGrazingPattern)]
        [MapField(_str_idfsGrazingPattern)]
        public abstract Int64? idfsGrazingPattern { get; set; }
        protected Int64? idfsGrazingPattern_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGrazingPattern).OriginalValue; } }
        protected Int64? idfsGrazingPattern_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGrazingPattern).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsLivestockProductionType)]
        [MapField(_str_idfsLivestockProductionType)]
        public abstract Int64? idfsLivestockProductionType { get; set; }
        protected Int64? idfsLivestockProductionType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsLivestockProductionType).OriginalValue; } }
        protected Int64? idfsLivestockProductionType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsLivestockProductionType).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_strContactPhone)]
        [MapField(_str_strContactPhone)]
        public abstract String strContactPhone { get; set; }
        protected String strContactPhone_Original { get { return ((EditableValue<String>)((dynamic)this)._strContactPhone).OriginalValue; } }
        protected String strContactPhone_Previous { get { return ((EditableValue<String>)((dynamic)this)._strContactPhone).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_strOwnerLastName)]
        [MapField(_str_strOwnerLastName)]
        public abstract String strOwnerLastName { get; set; }
        protected String strOwnerLastName_Original { get { return ((EditableValue<String>)((dynamic)this)._strOwnerLastName).OriginalValue; } }
        protected String strOwnerLastName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOwnerLastName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intSickAnimalQty)]
        [MapField(_str_intSickAnimalQty)]
        public abstract Int32? intSickAnimalQty { get; set; }
        protected Int32? intSickAnimalQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intSickAnimalQty).OriginalValue; } }
        protected Int32? intSickAnimalQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intSickAnimalQty).PreviousValue; } }
                
        [LocalizedDisplayName("intTotalAnimalQtyFull")]
        [MapField(_str_intTotalAnimalQty)]
        public abstract Int32? intTotalAnimalQty { get; set; }
        protected Int32? intTotalAnimalQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intTotalAnimalQty).OriginalValue; } }
        protected Int32? intTotalAnimalQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intTotalAnimalQty).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intDeadAnimalQty)]
        [MapField(_str_intDeadAnimalQty)]
        public abstract Int32? intDeadAnimalQty { get; set; }
        protected Int32? intDeadAnimalQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intDeadAnimalQty).OriginalValue; } }
        protected Int32? intDeadAnimalQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intDeadAnimalQty).PreviousValue; } }
                
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
            internal Func<SmallVetCaseListItem, object> _get_func;
            internal Action<SmallVetCaseListItem, string> _set_func;
            internal Action<SmallVetCaseListItem, SmallVetCaseListItem, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCase = "idfCase";
        internal const string _str_datAssignedDate = "datAssignedDate";
        internal const string _str_datEnteredDate = "datEnteredDate";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_datReportDate = "datReportDate";
        internal const string _str_datInvestigationDate = "datInvestigationDate";
        internal const string _str_idfsShowDiagnosis = "idfsShowDiagnosis";
        internal const string _str_datDiagnosisDate = "datDiagnosisDate";
        internal const string _str_idfsTentativeDiagnosis = "idfsTentativeDiagnosis";
        internal const string _str_idfsTentativeDiagnosis1 = "idfsTentativeDiagnosis1";
        internal const string _str_idfsTentativeDiagnosis2 = "idfsTentativeDiagnosis2";
        internal const string _str_idfsFinalDiagnosis = "idfsFinalDiagnosis";
        internal const string _str_idfPersonEnteredBy = "idfPersonEnteredBy";
        internal const string _str_idfsCaseClassification = "idfsCaseClassification";
        internal const string _str_idfsCaseProgressStatus = "idfsCaseProgressStatus";
        internal const string _str_idfsCaseReportType = "idfsCaseReportType";
        internal const string _str_strCaseReportType = "strCaseReportType";
        internal const string _str_FinalDiagnosisName = "FinalDiagnosisName";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_CaseStatusName = "CaseStatusName";
        internal const string _str_CaseClassificationName = "CaseClassificationName";
        internal const string _str_strCaseType = "strCaseType";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_idfsCaseTypeNullable = "idfsCaseTypeNullable";
        internal const string _str_uidOfflineCaseID = "uidOfflineCaseID";
        internal const string _str_idfAddress = "idfAddress";
        internal const string _str_AddressName = "AddressName";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_idfFarm = "idfFarm";
        internal const string _str_FarmName = "FarmName";
        internal const string _str_idfsAvianFarmType = "idfsAvianFarmType";
        internal const string _str_idfsAvianProductionType = "idfsAvianProductionType";
        internal const string _str_idfsFarmCategory = "idfsFarmCategory";
        internal const string _str_idfsOwnershipStructure = "idfsOwnershipStructure";
        internal const string _str_idfsMovementPattern = "idfsMovementPattern";
        internal const string _str_idfsIntendedUse = "idfsIntendedUse";
        internal const string _str_idfsGrazingPattern = "idfsGrazingPattern";
        internal const string _str_idfsLivestockProductionType = "idfsLivestockProductionType";
        internal const string _str_strInternationalName = "strInternationalName";
        internal const string _str_strNationalName = "strNationalName";
        internal const string _str_strFarmCode = "strFarmCode";
        internal const string _str_strFax = "strFax";
        internal const string _str_strEmail = "strEmail";
        internal const string _str_strContactPhone = "strContactPhone";
        internal const string _str_strOwnerFirstName = "strOwnerFirstName";
        internal const string _str_strOwnerMiddleName = "strOwnerMiddleName";
        internal const string _str_strOwnerLastName = "strOwnerLastName";
        internal const string _str_intSickAnimalQty = "intSickAnimalQty";
        internal const string _str_intTotalAnimalQty = "intTotalAnimalQty";
        internal const string _str_intDeadAnimalQty = "intDeadAnimalQty";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_CaseType = "CaseType";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfCase, _formname = _str_idfCase, _type = "Int64",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfCase != newval) o.idfCase = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, o.ObjectIdent2 + _str_idfCase, o.ObjectIdent3 + _str_idfCase, "Int64", 
                    o.idfCase == null ? "" : o.idfCase.ToString(),                  
                  o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datAssignedDate, _formname = _str_datAssignedDate, _type = "DateTime?",
              _get_func = o => o.datAssignedDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datAssignedDate != newval) o.datAssignedDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datAssignedDate != c.datAssignedDate || o.IsRIRPropChanged(_str_datAssignedDate, c)) 
                  m.Add(_str_datAssignedDate, o.ObjectIdent + _str_datAssignedDate, o.ObjectIdent2 + _str_datAssignedDate, o.ObjectIdent3 + _str_datAssignedDate, "DateTime?", 
                    o.datAssignedDate == null ? "" : o.datAssignedDate.ToString(),                  
                  o.IsReadOnly(_str_datAssignedDate), o.IsInvisible(_str_datAssignedDate), o.IsRequired(_str_datAssignedDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datEnteredDate, _formname = _str_datEnteredDate, _type = "DateTime?",
              _get_func = o => o.datEnteredDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datEnteredDate != newval) o.datEnteredDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datEnteredDate != c.datEnteredDate || o.IsRIRPropChanged(_str_datEnteredDate, c)) 
                  m.Add(_str_datEnteredDate, o.ObjectIdent + _str_datEnteredDate, o.ObjectIdent2 + _str_datEnteredDate, o.ObjectIdent3 + _str_datEnteredDate, "DateTime?", 
                    o.datEnteredDate == null ? "" : o.datEnteredDate.ToString(),                  
                  o.IsReadOnly(_str_datEnteredDate), o.IsInvisible(_str_datEnteredDate), o.IsRequired(_str_datEnteredDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCaseID, _formname = _str_strCaseID, _type = "String",
              _get_func = o => o.strCaseID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCaseID != newval) o.strCaseID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCaseID != c.strCaseID || o.IsRIRPropChanged(_str_strCaseID, c)) 
                  m.Add(_str_strCaseID, o.ObjectIdent + _str_strCaseID, o.ObjectIdent2 + _str_strCaseID, o.ObjectIdent3 + _str_strCaseID, "String", 
                    o.strCaseID == null ? "" : o.strCaseID.ToString(),                  
                  o.IsReadOnly(_str_strCaseID), o.IsInvisible(_str_strCaseID), o.IsRequired(_str_strCaseID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datReportDate, _formname = _str_datReportDate, _type = "DateTime?",
              _get_func = o => o.datReportDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datReportDate != newval) o.datReportDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datReportDate != c.datReportDate || o.IsRIRPropChanged(_str_datReportDate, c)) 
                  m.Add(_str_datReportDate, o.ObjectIdent + _str_datReportDate, o.ObjectIdent2 + _str_datReportDate, o.ObjectIdent3 + _str_datReportDate, "DateTime?", 
                    o.datReportDate == null ? "" : o.datReportDate.ToString(),                  
                  o.IsReadOnly(_str_datReportDate), o.IsInvisible(_str_datReportDate), o.IsRequired(_str_datReportDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datInvestigationDate, _formname = _str_datInvestigationDate, _type = "DateTime?",
              _get_func = o => o.datInvestigationDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datInvestigationDate != newval) o.datInvestigationDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datInvestigationDate != c.datInvestigationDate || o.IsRIRPropChanged(_str_datInvestigationDate, c)) 
                  m.Add(_str_datInvestigationDate, o.ObjectIdent + _str_datInvestigationDate, o.ObjectIdent2 + _str_datInvestigationDate, o.ObjectIdent3 + _str_datInvestigationDate, "DateTime?", 
                    o.datInvestigationDate == null ? "" : o.datInvestigationDate.ToString(),                  
                  o.IsReadOnly(_str_datInvestigationDate), o.IsInvisible(_str_datInvestigationDate), o.IsRequired(_str_datInvestigationDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsShowDiagnosis, _formname = _str_idfsShowDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsShowDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsShowDiagnosis != newval) o.idfsShowDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsShowDiagnosis != c.idfsShowDiagnosis || o.IsRIRPropChanged(_str_idfsShowDiagnosis, c)) 
                  m.Add(_str_idfsShowDiagnosis, o.ObjectIdent + _str_idfsShowDiagnosis, o.ObjectIdent2 + _str_idfsShowDiagnosis, o.ObjectIdent3 + _str_idfsShowDiagnosis, "Int64?", 
                    o.idfsShowDiagnosis == null ? "" : o.idfsShowDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsShowDiagnosis), o.IsInvisible(_str_idfsShowDiagnosis), o.IsRequired(_str_idfsShowDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDiagnosisDate, _formname = _str_datDiagnosisDate, _type = "DateTime?",
              _get_func = o => o.datDiagnosisDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDiagnosisDate != newval) o.datDiagnosisDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDiagnosisDate != c.datDiagnosisDate || o.IsRIRPropChanged(_str_datDiagnosisDate, c)) 
                  m.Add(_str_datDiagnosisDate, o.ObjectIdent + _str_datDiagnosisDate, o.ObjectIdent2 + _str_datDiagnosisDate, o.ObjectIdent3 + _str_datDiagnosisDate, "DateTime?", 
                    o.datDiagnosisDate == null ? "" : o.datDiagnosisDate.ToString(),                  
                  o.IsReadOnly(_str_datDiagnosisDate), o.IsInvisible(_str_datDiagnosisDate), o.IsRequired(_str_datDiagnosisDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTentativeDiagnosis, _formname = _str_idfsTentativeDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsTentativeDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTentativeDiagnosis != newval) o.idfsTentativeDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTentativeDiagnosis != c.idfsTentativeDiagnosis || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis, c)) 
                  m.Add(_str_idfsTentativeDiagnosis, o.ObjectIdent + _str_idfsTentativeDiagnosis, o.ObjectIdent2 + _str_idfsTentativeDiagnosis, o.ObjectIdent3 + _str_idfsTentativeDiagnosis, "Int64?", 
                    o.idfsTentativeDiagnosis == null ? "" : o.idfsTentativeDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsTentativeDiagnosis), o.IsInvisible(_str_idfsTentativeDiagnosis), o.IsRequired(_str_idfsTentativeDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTentativeDiagnosis1, _formname = _str_idfsTentativeDiagnosis1, _type = "Int64?",
              _get_func = o => o.idfsTentativeDiagnosis1,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTentativeDiagnosis1 != newval) o.idfsTentativeDiagnosis1 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTentativeDiagnosis1 != c.idfsTentativeDiagnosis1 || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis1, c)) 
                  m.Add(_str_idfsTentativeDiagnosis1, o.ObjectIdent + _str_idfsTentativeDiagnosis1, o.ObjectIdent2 + _str_idfsTentativeDiagnosis1, o.ObjectIdent3 + _str_idfsTentativeDiagnosis1, "Int64?", 
                    o.idfsTentativeDiagnosis1 == null ? "" : o.idfsTentativeDiagnosis1.ToString(),                  
                  o.IsReadOnly(_str_idfsTentativeDiagnosis1), o.IsInvisible(_str_idfsTentativeDiagnosis1), o.IsRequired(_str_idfsTentativeDiagnosis1)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTentativeDiagnosis2, _formname = _str_idfsTentativeDiagnosis2, _type = "Int64?",
              _get_func = o => o.idfsTentativeDiagnosis2,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTentativeDiagnosis2 != newval) o.idfsTentativeDiagnosis2 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTentativeDiagnosis2 != c.idfsTentativeDiagnosis2 || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis2, c)) 
                  m.Add(_str_idfsTentativeDiagnosis2, o.ObjectIdent + _str_idfsTentativeDiagnosis2, o.ObjectIdent2 + _str_idfsTentativeDiagnosis2, o.ObjectIdent3 + _str_idfsTentativeDiagnosis2, "Int64?", 
                    o.idfsTentativeDiagnosis2 == null ? "" : o.idfsTentativeDiagnosis2.ToString(),                  
                  o.IsReadOnly(_str_idfsTentativeDiagnosis2), o.IsInvisible(_str_idfsTentativeDiagnosis2), o.IsRequired(_str_idfsTentativeDiagnosis2)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsFinalDiagnosis, _formname = _str_idfsFinalDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsFinalDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsFinalDiagnosis != newval) o.idfsFinalDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsFinalDiagnosis != c.idfsFinalDiagnosis || o.IsRIRPropChanged(_str_idfsFinalDiagnosis, c)) 
                  m.Add(_str_idfsFinalDiagnosis, o.ObjectIdent + _str_idfsFinalDiagnosis, o.ObjectIdent2 + _str_idfsFinalDiagnosis, o.ObjectIdent3 + _str_idfsFinalDiagnosis, "Int64?", 
                    o.idfsFinalDiagnosis == null ? "" : o.idfsFinalDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsFinalDiagnosis), o.IsInvisible(_str_idfsFinalDiagnosis), o.IsRequired(_str_idfsFinalDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPersonEnteredBy, _formname = _str_idfPersonEnteredBy, _type = "Int64?",
              _get_func = o => o.idfPersonEnteredBy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfPersonEnteredBy != newval) o.idfPersonEnteredBy = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfPersonEnteredBy != c.idfPersonEnteredBy || o.IsRIRPropChanged(_str_idfPersonEnteredBy, c)) 
                  m.Add(_str_idfPersonEnteredBy, o.ObjectIdent + _str_idfPersonEnteredBy, o.ObjectIdent2 + _str_idfPersonEnteredBy, o.ObjectIdent3 + _str_idfPersonEnteredBy, "Int64?", 
                    o.idfPersonEnteredBy == null ? "" : o.idfPersonEnteredBy.ToString(),                  
                  o.IsReadOnly(_str_idfPersonEnteredBy), o.IsInvisible(_str_idfPersonEnteredBy), o.IsRequired(_str_idfPersonEnteredBy)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCaseClassification, _formname = _str_idfsCaseClassification, _type = "Int64?",
              _get_func = o => o.idfsCaseClassification,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCaseClassification != newval) o.idfsCaseClassification = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCaseClassification != c.idfsCaseClassification || o.IsRIRPropChanged(_str_idfsCaseClassification, c)) 
                  m.Add(_str_idfsCaseClassification, o.ObjectIdent + _str_idfsCaseClassification, o.ObjectIdent2 + _str_idfsCaseClassification, o.ObjectIdent3 + _str_idfsCaseClassification, "Int64?", 
                    o.idfsCaseClassification == null ? "" : o.idfsCaseClassification.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseClassification), o.IsInvisible(_str_idfsCaseClassification), o.IsRequired(_str_idfsCaseClassification)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCaseProgressStatus, _formname = _str_idfsCaseProgressStatus, _type = "Int64?",
              _get_func = o => o.idfsCaseProgressStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCaseProgressStatus != newval) o.idfsCaseProgressStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCaseProgressStatus != c.idfsCaseProgressStatus || o.IsRIRPropChanged(_str_idfsCaseProgressStatus, c)) 
                  m.Add(_str_idfsCaseProgressStatus, o.ObjectIdent + _str_idfsCaseProgressStatus, o.ObjectIdent2 + _str_idfsCaseProgressStatus, o.ObjectIdent3 + _str_idfsCaseProgressStatus, "Int64?", 
                    o.idfsCaseProgressStatus == null ? "" : o.idfsCaseProgressStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseProgressStatus), o.IsInvisible(_str_idfsCaseProgressStatus), o.IsRequired(_str_idfsCaseProgressStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCaseReportType, _formname = _str_idfsCaseReportType, _type = "Int64",
              _get_func = o => o.idfsCaseReportType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsCaseReportType != newval) o.idfsCaseReportType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCaseReportType != c.idfsCaseReportType || o.IsRIRPropChanged(_str_idfsCaseReportType, c)) 
                  m.Add(_str_idfsCaseReportType, o.ObjectIdent + _str_idfsCaseReportType, o.ObjectIdent2 + _str_idfsCaseReportType, o.ObjectIdent3 + _str_idfsCaseReportType, "Int64", 
                    o.idfsCaseReportType == null ? "" : o.idfsCaseReportType.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseReportType), o.IsInvisible(_str_idfsCaseReportType), o.IsRequired(_str_idfsCaseReportType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCaseReportType, _formname = _str_strCaseReportType, _type = "String",
              _get_func = o => o.strCaseReportType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCaseReportType != newval) o.strCaseReportType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCaseReportType != c.strCaseReportType || o.IsRIRPropChanged(_str_strCaseReportType, c)) 
                  m.Add(_str_strCaseReportType, o.ObjectIdent + _str_strCaseReportType, o.ObjectIdent2 + _str_strCaseReportType, o.ObjectIdent3 + _str_strCaseReportType, "String", 
                    o.strCaseReportType == null ? "" : o.strCaseReportType.ToString(),                  
                  o.IsReadOnly(_str_strCaseReportType), o.IsInvisible(_str_strCaseReportType), o.IsRequired(_str_strCaseReportType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_FinalDiagnosisName, _formname = _str_FinalDiagnosisName, _type = "String",
              _get_func = o => o.FinalDiagnosisName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.FinalDiagnosisName != newval) o.FinalDiagnosisName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.FinalDiagnosisName != c.FinalDiagnosisName || o.IsRIRPropChanged(_str_FinalDiagnosisName, c)) 
                  m.Add(_str_FinalDiagnosisName, o.ObjectIdent + _str_FinalDiagnosisName, o.ObjectIdent2 + _str_FinalDiagnosisName, o.ObjectIdent3 + _str_FinalDiagnosisName, "String", 
                    o.FinalDiagnosisName == null ? "" : o.FinalDiagnosisName.ToString(),                  
                  o.IsReadOnly(_str_FinalDiagnosisName), o.IsInvisible(_str_FinalDiagnosisName), o.IsRequired(_str_FinalDiagnosisName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DiagnosisName, _formname = _str_DiagnosisName, _type = "String",
              _get_func = o => o.DiagnosisName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DiagnosisName != newval) o.DiagnosisName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DiagnosisName != c.DiagnosisName || o.IsRIRPropChanged(_str_DiagnosisName, c)) 
                  m.Add(_str_DiagnosisName, o.ObjectIdent + _str_DiagnosisName, o.ObjectIdent2 + _str_DiagnosisName, o.ObjectIdent3 + _str_DiagnosisName, "String", 
                    o.DiagnosisName == null ? "" : o.DiagnosisName.ToString(),                  
                  o.IsReadOnly(_str_DiagnosisName), o.IsInvisible(_str_DiagnosisName), o.IsRequired(_str_DiagnosisName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_CaseStatusName, _formname = _str_CaseStatusName, _type = "String",
              _get_func = o => o.CaseStatusName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.CaseStatusName != newval) o.CaseStatusName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.CaseStatusName != c.CaseStatusName || o.IsRIRPropChanged(_str_CaseStatusName, c)) 
                  m.Add(_str_CaseStatusName, o.ObjectIdent + _str_CaseStatusName, o.ObjectIdent2 + _str_CaseStatusName, o.ObjectIdent3 + _str_CaseStatusName, "String", 
                    o.CaseStatusName == null ? "" : o.CaseStatusName.ToString(),                  
                  o.IsReadOnly(_str_CaseStatusName), o.IsInvisible(_str_CaseStatusName), o.IsRequired(_str_CaseStatusName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_CaseClassificationName, _formname = _str_CaseClassificationName, _type = "String",
              _get_func = o => o.CaseClassificationName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.CaseClassificationName != newval) o.CaseClassificationName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.CaseClassificationName != c.CaseClassificationName || o.IsRIRPropChanged(_str_CaseClassificationName, c)) 
                  m.Add(_str_CaseClassificationName, o.ObjectIdent + _str_CaseClassificationName, o.ObjectIdent2 + _str_CaseClassificationName, o.ObjectIdent3 + _str_CaseClassificationName, "String", 
                    o.CaseClassificationName == null ? "" : o.CaseClassificationName.ToString(),                  
                  o.IsReadOnly(_str_CaseClassificationName), o.IsInvisible(_str_CaseClassificationName), o.IsRequired(_str_CaseClassificationName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCaseType, _formname = _str_strCaseType, _type = "String",
              _get_func = o => o.strCaseType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCaseType != newval) o.strCaseType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCaseType != c.strCaseType || o.IsRIRPropChanged(_str_strCaseType, c)) 
                  m.Add(_str_strCaseType, o.ObjectIdent + _str_strCaseType, o.ObjectIdent2 + _str_strCaseType, o.ObjectIdent3 + _str_strCaseType, "String", 
                    o.strCaseType == null ? "" : o.strCaseType.ToString(),                  
                  o.IsReadOnly(_str_strCaseType), o.IsInvisible(_str_strCaseType), o.IsRequired(_str_strCaseType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCaseType, _formname = _str_idfsCaseType, _type = "Int64",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsCaseType != newval) 
                  o.CaseType = o.CaseTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsCaseType != newval) o.idfsCaseType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) 
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, o.ObjectIdent2 + _str_idfsCaseType, o.ObjectIdent3 + _str_idfsCaseType, "Int64", 
                    o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCaseTypeNullable, _formname = _str_idfsCaseTypeNullable, _type = "Int64?",
              _get_func = o => o.idfsCaseTypeNullable,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCaseTypeNullable != newval) o.idfsCaseTypeNullable = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCaseTypeNullable != c.idfsCaseTypeNullable || o.IsRIRPropChanged(_str_idfsCaseTypeNullable, c)) 
                  m.Add(_str_idfsCaseTypeNullable, o.ObjectIdent + _str_idfsCaseTypeNullable, o.ObjectIdent2 + _str_idfsCaseTypeNullable, o.ObjectIdent3 + _str_idfsCaseTypeNullable, "Int64?", 
                    o.idfsCaseTypeNullable == null ? "" : o.idfsCaseTypeNullable.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseTypeNullable), o.IsInvisible(_str_idfsCaseTypeNullable), o.IsRequired(_str_idfsCaseTypeNullable)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_uidOfflineCaseID, _formname = _str_uidOfflineCaseID, _type = "Guid?",
              _get_func = o => o.uidOfflineCaseID,
              _set_func = (o, val) => { var newval = o.uidOfflineCaseID; if (o.uidOfflineCaseID != newval) o.uidOfflineCaseID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.uidOfflineCaseID != c.uidOfflineCaseID || o.IsRIRPropChanged(_str_uidOfflineCaseID, c)) 
                  m.Add(_str_uidOfflineCaseID, o.ObjectIdent + _str_uidOfflineCaseID, o.ObjectIdent2 + _str_uidOfflineCaseID, o.ObjectIdent3 + _str_uidOfflineCaseID, "Guid?", 
                    o.uidOfflineCaseID == null ? "" : o.uidOfflineCaseID.ToString(),                  
                  o.IsReadOnly(_str_uidOfflineCaseID), o.IsInvisible(_str_uidOfflineCaseID), o.IsRequired(_str_uidOfflineCaseID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfAddress, _formname = _str_idfAddress, _type = "Int64?",
              _get_func = o => o.idfAddress,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfAddress != newval) o.idfAddress = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfAddress != c.idfAddress || o.IsRIRPropChanged(_str_idfAddress, c)) 
                  m.Add(_str_idfAddress, o.ObjectIdent + _str_idfAddress, o.ObjectIdent2 + _str_idfAddress, o.ObjectIdent3 + _str_idfAddress, "Int64?", 
                    o.idfAddress == null ? "" : o.idfAddress.ToString(),                  
                  o.IsReadOnly(_str_idfAddress), o.IsInvisible(_str_idfAddress), o.IsRequired(_str_idfAddress)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_AddressName, _formname = _str_AddressName, _type = "String",
              _get_func = o => o.AddressName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.AddressName != newval) o.AddressName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.AddressName != c.AddressName || o.IsRIRPropChanged(_str_AddressName, c)) 
                  m.Add(_str_AddressName, o.ObjectIdent + _str_AddressName, o.ObjectIdent2 + _str_AddressName, o.ObjectIdent3 + _str_AddressName, "String", 
                    o.AddressName == null ? "" : o.AddressName.ToString(),                  
                  o.IsReadOnly(_str_AddressName), o.IsInvisible(_str_AddressName), o.IsRequired(_str_AddressName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCountry, _formname = _str_idfsCountry, _type = "Int64?",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsCountry != newval) 
                  o.Country = o.CountryLookup.FirstOrDefault(c => c.idfsCountry == newval);
                if (o.idfsCountry != newval) o.idfsCountry = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) 
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, o.ObjectIdent2 + _str_idfsCountry, o.ObjectIdent3 + _str_idfsCountry, "Int64?", 
                    o.idfsCountry == null ? "" : o.idfsCountry.ToString(),                  
                  o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRegion, _formname = _str_idfsRegion, _type = "Int64?",
              _get_func = o => o.idfsRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsRegion != newval) 
                  o.Region = o.RegionLookup.FirstOrDefault(c => c.idfsRegion == newval);
                if (o.idfsRegion != newval) o.idfsRegion = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_idfsRegion, c)) 
                  m.Add(_str_idfsRegion, o.ObjectIdent + _str_idfsRegion, o.ObjectIdent2 + _str_idfsRegion, o.ObjectIdent3 + _str_idfsRegion, "Int64?", 
                    o.idfsRegion == null ? "" : o.idfsRegion.ToString(),                  
                  o.IsReadOnly(_str_idfsRegion), o.IsInvisible(_str_idfsRegion), o.IsRequired(_str_idfsRegion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRayon, _formname = _str_idfsRayon, _type = "Int64?",
              _get_func = o => o.idfsRayon,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsRayon != newval) 
                  o.Rayon = o.RayonLookup.FirstOrDefault(c => c.idfsRayon == newval);
                if (o.idfsRayon != newval) o.idfsRayon = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_idfsRayon, c)) 
                  m.Add(_str_idfsRayon, o.ObjectIdent + _str_idfsRayon, o.ObjectIdent2 + _str_idfsRayon, o.ObjectIdent3 + _str_idfsRayon, "Int64?", 
                    o.idfsRayon == null ? "" : o.idfsRayon.ToString(),                  
                  o.IsReadOnly(_str_idfsRayon), o.IsInvisible(_str_idfsRayon), o.IsRequired(_str_idfsRayon)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSettlement, _formname = _str_idfsSettlement, _type = "Int64?",
              _get_func = o => o.idfsSettlement,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsSettlement != newval) 
                  o.Settlement = o.SettlementLookup.FirstOrDefault(c => c.idfsSettlement == newval);
                if (o.idfsSettlement != newval) o.idfsSettlement = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_idfsSettlement, c)) 
                  m.Add(_str_idfsSettlement, o.ObjectIdent + _str_idfsSettlement, o.ObjectIdent2 + _str_idfsSettlement, o.ObjectIdent3 + _str_idfsSettlement, "Int64?", 
                    o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(),                  
                  o.IsReadOnly(_str_idfsSettlement), o.IsInvisible(_str_idfsSettlement), o.IsRequired(_str_idfsSettlement)); 
                  }
              }, 
                  
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
              _name = _str_FarmName, _formname = _str_FarmName, _type = "String",
              _get_func = o => o.FarmName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.FarmName != newval) o.FarmName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.FarmName != c.FarmName || o.IsRIRPropChanged(_str_FarmName, c)) 
                  m.Add(_str_FarmName, o.ObjectIdent + _str_FarmName, o.ObjectIdent2 + _str_FarmName, o.ObjectIdent3 + _str_FarmName, "String", 
                    o.FarmName == null ? "" : o.FarmName.ToString(),                  
                  o.IsReadOnly(_str_FarmName), o.IsInvisible(_str_FarmName), o.IsRequired(_str_FarmName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAvianFarmType, _formname = _str_idfsAvianFarmType, _type = "Int64?",
              _get_func = o => o.idfsAvianFarmType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsAvianFarmType != newval) o.idfsAvianFarmType = newval; },
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
              _name = _str_idfsFarmCategory, _formname = _str_idfsFarmCategory, _type = "Int64?",
              _get_func = o => o.idfsFarmCategory,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsFarmCategory != newval) o.idfsFarmCategory = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsFarmCategory != c.idfsFarmCategory || o.IsRIRPropChanged(_str_idfsFarmCategory, c)) 
                  m.Add(_str_idfsFarmCategory, o.ObjectIdent + _str_idfsFarmCategory, o.ObjectIdent2 + _str_idfsFarmCategory, o.ObjectIdent3 + _str_idfsFarmCategory, "Int64?", 
                    o.idfsFarmCategory == null ? "" : o.idfsFarmCategory.ToString(),                  
                  o.IsReadOnly(_str_idfsFarmCategory), o.IsInvisible(_str_idfsFarmCategory), o.IsRequired(_str_idfsFarmCategory)); 
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
              _name = _str_intSickAnimalQty, _formname = _str_intSickAnimalQty, _type = "Int32?",
              _get_func = o => o.intSickAnimalQty,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intSickAnimalQty != newval) o.intSickAnimalQty = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intSickAnimalQty != c.intSickAnimalQty || o.IsRIRPropChanged(_str_intSickAnimalQty, c)) 
                  m.Add(_str_intSickAnimalQty, o.ObjectIdent + _str_intSickAnimalQty, o.ObjectIdent2 + _str_intSickAnimalQty, o.ObjectIdent3 + _str_intSickAnimalQty, "Int32?", 
                    o.intSickAnimalQty == null ? "" : o.intSickAnimalQty.ToString(),                  
                  o.IsReadOnly(_str_intSickAnimalQty), o.IsInvisible(_str_intSickAnimalQty), o.IsRequired(_str_intSickAnimalQty)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intTotalAnimalQty, _formname = _str_intTotalAnimalQty, _type = "Int32?",
              _get_func = o => o.intTotalAnimalQty,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intTotalAnimalQty != newval) o.intTotalAnimalQty = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intTotalAnimalQty != c.intTotalAnimalQty || o.IsRIRPropChanged(_str_intTotalAnimalQty, c)) 
                  m.Add(_str_intTotalAnimalQty, o.ObjectIdent + _str_intTotalAnimalQty, o.ObjectIdent2 + _str_intTotalAnimalQty, o.ObjectIdent3 + _str_intTotalAnimalQty, "Int32?", 
                    o.intTotalAnimalQty == null ? "" : o.intTotalAnimalQty.ToString(),                  
                  o.IsReadOnly(_str_intTotalAnimalQty), o.IsInvisible(_str_intTotalAnimalQty), o.IsRequired(_str_intTotalAnimalQty)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intDeadAnimalQty, _formname = _str_intDeadAnimalQty, _type = "Int32?",
              _get_func = o => o.intDeadAnimalQty,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intDeadAnimalQty != newval) o.intDeadAnimalQty = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intDeadAnimalQty != c.intDeadAnimalQty || o.IsRIRPropChanged(_str_intDeadAnimalQty, c)) 
                  m.Add(_str_intDeadAnimalQty, o.ObjectIdent + _str_intDeadAnimalQty, o.ObjectIdent2 + _str_intDeadAnimalQty, o.ObjectIdent3 + _str_intDeadAnimalQty, "Int32?", 
                    o.intDeadAnimalQty == null ? "" : o.intDeadAnimalQty.ToString(),                  
                  o.IsReadOnly(_str_intDeadAnimalQty), o.IsInvisible(_str_intDeadAnimalQty), o.IsRequired(_str_intDeadAnimalQty)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSite, _formname = _str_idfsSite, _type = "Int64",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsSite != newval) o.idfsSite = newval; },
              _compare_func = (o, c, m, g) => {
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
              _compare_func = (o, c, m, g) => {
              
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) {
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis,  "long?", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                    o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_Country, _formname = _str_Country, _type = "Lookup",
              _get_func = o => { if (o.Country == null) return null; return o.Country.idfsCountry; },
              _set_func = (o, val) => { o.Country = o.CountryLookup.Where(c => c.idfsCountry.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Country, c);
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_Country, c) || bChangeLookupContent) {
                  m.Add(_str_Country, o.ObjectIdent + _str_Country, o.ObjectIdent2 + _str_Country, o.ObjectIdent3 + _str_Country, "Lookup", o.idfsCountry == null ? "" : o.idfsCountry.ToString(), o.IsReadOnly(_str_Country), o.IsInvisible(_str_Country), o.IsRequired(_str_Country),
                  bChangeLookupContent ? o.CountryLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Country + "Lookup", _formname = _str_Country + "Lookup", _type = "LookupContent",
              _get_func = o => o.CountryLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Region, _formname = _str_Region, _type = "Lookup",
              _get_func = o => { if (o.Region == null) return null; return o.Region.idfsRegion; },
              _set_func = (o, val) => { o.Region = o.RegionLookup.Where(c => c.idfsRegion.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Region, c);
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_Region, c) || bChangeLookupContent) {
                  m.Add(_str_Region, o.ObjectIdent + _str_Region, o.ObjectIdent2 + _str_Region, o.ObjectIdent3 + _str_Region, "Lookup", o.idfsRegion == null ? "" : o.idfsRegion.ToString(), o.IsReadOnly(_str_Region), o.IsInvisible(_str_Region), o.IsRequired(_str_Region),
                  bChangeLookupContent ? o.RegionLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Region + "Lookup", _formname = _str_Region + "Lookup", _type = "LookupContent",
              _get_func = o => o.RegionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Rayon, _formname = _str_Rayon, _type = "Lookup",
              _get_func = o => { if (o.Rayon == null) return null; return o.Rayon.idfsRayon; },
              _set_func = (o, val) => { o.Rayon = o.RayonLookup.Where(c => c.idfsRayon.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Rayon, c);
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_Rayon, c) || bChangeLookupContent) {
                  m.Add(_str_Rayon, o.ObjectIdent + _str_Rayon, o.ObjectIdent2 + _str_Rayon, o.ObjectIdent3 + _str_Rayon, "Lookup", o.idfsRayon == null ? "" : o.idfsRayon.ToString(), o.IsReadOnly(_str_Rayon), o.IsInvisible(_str_Rayon), o.IsRequired(_str_Rayon),
                  bChangeLookupContent ? o.RayonLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Rayon + "Lookup", _formname = _str_Rayon + "Lookup", _type = "LookupContent",
              _get_func = o => o.RayonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Settlement, _formname = _str_Settlement, _type = "Lookup",
              _get_func = o => { if (o.Settlement == null) return null; return o.Settlement.idfsSettlement; },
              _set_func = (o, val) => { o.Settlement = o.SettlementLookup.Where(c => c.idfsSettlement.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Settlement, c);
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_Settlement, c) || bChangeLookupContent) {
                  m.Add(_str_Settlement, o.ObjectIdent + _str_Settlement, o.ObjectIdent2 + _str_Settlement, o.ObjectIdent3 + _str_Settlement, "Lookup", o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(), o.IsReadOnly(_str_Settlement), o.IsInvisible(_str_Settlement), o.IsRequired(_str_Settlement),
                  bChangeLookupContent ? o.SettlementLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Settlement + "Lookup", _formname = _str_Settlement + "Lookup", _type = "LookupContent",
              _get_func = o => o.SettlementLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _formname = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Diagnosis, c);
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c) || bChangeLookupContent) {
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, o.ObjectIdent2 + _str_Diagnosis, o.ObjectIdent3 + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis),
                  bChangeLookupContent ? o.DiagnosisLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Diagnosis + "Lookup", _formname = _str_Diagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_CaseType, _formname = _str_CaseType, _type = "Lookup",
              _get_func = o => { if (o.CaseType == null) return null; return o.CaseType.idfsBaseReference; },
              _set_func = (o, val) => { o.CaseType = o.CaseTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_CaseType, c);
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_CaseType, c) || bChangeLookupContent) {
                  m.Add(_str_CaseType, o.ObjectIdent + _str_CaseType, o.ObjectIdent2 + _str_CaseType, o.ObjectIdent3 + _str_CaseType, "Lookup", o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(), o.IsReadOnly(_str_CaseType), o.IsInvisible(_str_CaseType), o.IsRequired(_str_CaseType),
                  bChangeLookupContent ? o.CaseTypeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_CaseType + "Lookup", _formname = _str_CaseType + "Lookup", _type = "LookupContent",
              _get_func = o => o.CaseTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
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
            SmallVetCaseListItem obj = (SmallVetCaseListItem)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
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
            
        [LocalizedDisplayName(_str_CaseType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseType)]
        public BaseReference CaseType
        {
            get { return _CaseType == null ? null : ((long)_CaseType.Key == 0 ? null : _CaseType); }
            set 
            { 
                var oldVal = _CaseType;
                _CaseType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_CaseType != oldVal)
                {
                    if (idfsCaseType != (_CaseType == null
                            ? new Int64()
                            : (Int64)_CaseType.idfsBaseReference))
                        idfsCaseType = _CaseType == null 
                            ? new Int64()
                            : (Int64)_CaseType.idfsBaseReference; 
                    OnPropertyChanged(_str_CaseType); 
                }
            }
        }
        private BaseReference _CaseType;

        
        public BaseReferenceList CaseTypeLookup
        {
            get { return _CaseTypeLookup; }
        }
        private BaseReferenceList _CaseTypeLookup = new BaseReferenceList("rftCaseType");
            
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
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_CaseType:
                    return new BvSelectList(CaseTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseType, _str_idfsCaseType);
            
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
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "SmallVetCaseListItem";

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
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as SmallVetCaseListItem;
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
            var ret = base.Clone() as SmallVetCaseListItem;
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
        public SmallVetCaseListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as SmallVetCaseListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfCase; } }
        public string KeyName { get { return "idfCase"; } }
        public object KeyLookup { get { return idfCase; } }
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
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsCaseType_CaseType = idfsCaseType;
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
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsCaseType_CaseType != idfsCaseType)
            {
                _CaseType = _CaseTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseType);
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

        private bool IsRIRPropChanged(string fld, SmallVetCaseListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, SmallVetCaseListItem c)
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
        

      

        public SmallVetCaseListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SmallVetCaseListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SmallVetCaseListItem_PropertyChanged);
        }
        private void SmallVetCaseListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as SmallVetCaseListItem).Changed(e.PropertyName);
            
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
            SmallVetCaseListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            SmallVetCaseListItem obj = this;
            
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
        
            }
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


        internal Dictionary<string, Func<SmallVetCaseListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<SmallVetCaseListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<SmallVetCaseListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<SmallVetCaseListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<SmallVetCaseListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<SmallVetCaseListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<SmallVetCaseListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~SmallVetCaseListItem()
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
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("CountryLookup", this);
                
                LookupManager.RemoveObject("RegionLookup", this);
                
                LookupManager.RemoveObject("RayonLookup", this);
                
                LookupManager.RemoveObject("SettlementLookup", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftCaseType", this);
                
                }
            }
            GC.SuppressFinalize(this);
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
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftCaseType")
                _getAccessor().LoadLookup_CaseType(manager, this);
            
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
        
            }
            ParsedFormCollection(form);
        }
    
        #region Class for web grid
        public class SmallVetCaseListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfCase { get; set; }
        
            public String strCaseID { get; set; }
        
            public DateTimeWrap datEnteredDate { get; set; }
        
            public String DiagnosisName { get; set; }
        
            public String AddressName { get; set; }
        
            public String FarmName { get; set; }
        
        }
        public partial class SmallVetCaseListItemGridModelList : List<SmallVetCaseListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public SmallVetCaseListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<SmallVetCaseListItem>, errMes);
            }
            public SmallVetCaseListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<SmallVetCaseListItem>, errMes);
            }
            public SmallVetCaseListItemGridModelList(long key, IEnumerable<SmallVetCaseListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public SmallVetCaseListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<SmallVetCaseListItem>(), null);
            }
            partial void filter(List<SmallVetCaseListItem> items);
            private void LoadGridModelList(long key, IEnumerable<SmallVetCaseListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strCaseID,_str_datEnteredDate,_str_DiagnosisName,_str_AddressName,_str_FarmName};
                    
                Hiddens = new List<string> {_str_idfCase};
                Keys = new List<string> {_str_idfCase};
                Labels = new Dictionary<string, string> {{_str_strCaseID, _str_strCaseID},{_str_datEnteredDate, "datEnteredDateSearchPanel"},{_str_DiagnosisName, _str_DiagnosisName},{_str_AddressName, "FarmAddress"},{_str_FarmName, _str_FarmName}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                SmallVetCaseListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<SmallVetCaseListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new SmallVetCaseListItemGridModel()
                {
                    ItemKey=c.idfCase,strCaseID=c.strCaseID,datEnteredDate=c.datEnteredDate,DiagnosisName=c.DiagnosisName,AddressName=c.IsHiddenPersonalData("AddressName")?"****":c.AddressName,FarmName=c.IsHiddenPersonalData("FarmName")?"****":c.FarmName
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
        : DataAccessor<SmallVetCaseListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<SmallVetCaseListItem>
            
            , IObjectSelectList
            , IObjectSelectList<SmallVetCaseListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfCase"; } }
            #endregion
        
            public delegate void on_action(SmallVetCaseListItem obj);
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
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CaseTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<SmallVetCaseListItem> SelectListT(DbManagerProxy manager
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
            
            protected virtual List<SmallVetCaseListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_VetCase_SelectList.* from dbo.fn_VetCase_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("strFieldBarCode"))
                {
                    
                    sql.Append(" " + @"
            INNER JOIN tlbMaterial
            on tlbMaterial.strCalculatedCaseID =  fn_VetCase_SelectList.strCaseID  COLLATE database_default
          ");
                      
                }
                
                if (filters.Contains("idfsDiagnosis"))
                {
                    
                    sql.Append(" " + @"");
                      
                }
                
                if (filters.Contains("idfPerson"))
                {
                    
                    sql.Append(" " + @"
            left join tlbPerson as person
            on person.idfPerson = fn_VetCase_SelectList.idfPersonEnteredBy
          ");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (EidssSiteContext.Instance.SiteType == SiteType.TLVL)
                {
                    sql.Append(@" and exists (select * from  tflCaseFiltered f inner join tflSiteToSiteGroup on tflSiteToSiteGroup.idfSiteGroup = f.idfSiteGroup and tflSiteToSiteGroup.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString() + " where f.idfCase = fn_VetCase_SelectList.idfCase)");
                }
                
                if (filters.Contains("strFieldBarCode"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strFieldBarCode") == 1)
                    {
                        sql.AppendFormat("ISNULL(tlbMaterial.strFieldBarcode,N'') {0} @strFieldBarCode", filters.Operation("strFieldBarCode"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strFieldBarCode"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strFieldBarCode") ? " or " : " and ");
                            sql.AppendFormat("ISNULL(tlbMaterial.strFieldBarcode,N'') {0} @strFieldBarCode_{1}", filters.Operation("strFieldBarCode", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsDiagnosis") == 1)
                    {
                        sql.AppendFormat("idfsTentativeDiagnosis = @idfsDiagnosis OR idfsTentativeDiagnosis1 = @idfsDiagnosis OR idfsTentativeDiagnosis2 = @idfsDiagnosis OR idfsFinalDiagnosis = @idfsDiagnosis", filters.Operation("idfsDiagnosis"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsDiagnosis") ? " or " : " and ");
                            sql.AppendFormat("idfsTentativeDiagnosis = @idfsDiagnosis_{1} OR idfsTentativeDiagnosis1 = @idfsDiagnosis OR idfsTentativeDiagnosis2 = @idfsDiagnosis OR idfsFinalDiagnosis = @idfsDiagnosis", filters.Operation("idfsDiagnosis", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfPerson"))
                    sql.AppendFormat(" and " + new Func<string>(() => "(@idfPerson = 0 OR person.idfPerson = " + EidssUserContext.User.EmployeeID.ToString() + ")")());
                            
                if (filters.Contains("idfCase"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfCase"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfCase") ? " or " : " and ");
                        
                        if (filters.Operation("idfCase", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfCase,0) {0} @idfCase_{1} = @idfCase_{1})", filters.Operation("idfCase", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfCase,0) {0} @idfCase_{1}", filters.Operation("idfCase", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datAssignedDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datAssignedDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datAssignedDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_VetCase_SelectList.datAssignedDate, 112) {0} CONVERT(NVARCHAR(8), @datAssignedDate_{1}, 112)", filters.Operation("datAssignedDate", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_VetCase_SelectList.datEnteredDate, 112) {0} CONVERT(NVARCHAR(8), @datEnteredDate_{1}, 112)", filters.Operation("datEnteredDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCaseID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCaseID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCaseID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.strCaseID {0} @strCaseID_{1}", filters.Operation("strCaseID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datReportDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datReportDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datReportDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_VetCase_SelectList.datReportDate, 112) {0} CONVERT(NVARCHAR(8), @datReportDate_{1}, 112)", filters.Operation("datReportDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datInvestigationDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datInvestigationDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datInvestigationDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_VetCase_SelectList.datInvestigationDate, 112) {0} CONVERT(NVARCHAR(8), @datInvestigationDate_{1}, 112)", filters.Operation("datInvestigationDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsShowDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsShowDiagnosis"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsShowDiagnosis") ? " or " : " and ");
                        
                        if (filters.Operation("idfsShowDiagnosis", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsShowDiagnosis,0) {0} @idfsShowDiagnosis_{1} = @idfsShowDiagnosis_{1})", filters.Operation("idfsShowDiagnosis", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsShowDiagnosis,0) {0} @idfsShowDiagnosis_{1}", filters.Operation("idfsShowDiagnosis", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datDiagnosisDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datDiagnosisDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datDiagnosisDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_VetCase_SelectList.datDiagnosisDate, 112) {0} CONVERT(NVARCHAR(8), @datDiagnosisDate_{1}, 112)", filters.Operation("datDiagnosisDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsTentativeDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTentativeDiagnosis"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTentativeDiagnosis") ? " or " : " and ");
                        
                        if (filters.Operation("idfsTentativeDiagnosis", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsTentativeDiagnosis,0) {0} @idfsTentativeDiagnosis_{1} = @idfsTentativeDiagnosis_{1})", filters.Operation("idfsTentativeDiagnosis", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsTentativeDiagnosis,0) {0} @idfsTentativeDiagnosis_{1}", filters.Operation("idfsTentativeDiagnosis", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsTentativeDiagnosis1"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTentativeDiagnosis1"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTentativeDiagnosis1") ? " or " : " and ");
                        
                        if (filters.Operation("idfsTentativeDiagnosis1", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsTentativeDiagnosis1,0) {0} @idfsTentativeDiagnosis1_{1} = @idfsTentativeDiagnosis1_{1})", filters.Operation("idfsTentativeDiagnosis1", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsTentativeDiagnosis1,0) {0} @idfsTentativeDiagnosis1_{1}", filters.Operation("idfsTentativeDiagnosis1", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsTentativeDiagnosis2"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTentativeDiagnosis2"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTentativeDiagnosis2") ? " or " : " and ");
                        
                        if (filters.Operation("idfsTentativeDiagnosis2", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsTentativeDiagnosis2,0) {0} @idfsTentativeDiagnosis2_{1} = @idfsTentativeDiagnosis2_{1})", filters.Operation("idfsTentativeDiagnosis2", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsTentativeDiagnosis2,0) {0} @idfsTentativeDiagnosis2_{1}", filters.Operation("idfsTentativeDiagnosis2", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsFinalDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsFinalDiagnosis"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsFinalDiagnosis") ? " or " : " and ");
                        
                        if (filters.Operation("idfsFinalDiagnosis", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsFinalDiagnosis,0) {0} @idfsFinalDiagnosis_{1} = @idfsFinalDiagnosis_{1})", filters.Operation("idfsFinalDiagnosis", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsFinalDiagnosis,0) {0} @idfsFinalDiagnosis_{1}", filters.Operation("idfsFinalDiagnosis", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfPersonEnteredBy,0) {0} @idfPersonEnteredBy_{1} = @idfPersonEnteredBy_{1})", filters.Operation("idfPersonEnteredBy", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfPersonEnteredBy,0) {0} @idfPersonEnteredBy_{1}", filters.Operation("idfPersonEnteredBy", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCaseClassification"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCaseClassification"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCaseClassification") ? " or " : " and ");
                        
                        if (filters.Operation("idfsCaseClassification", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsCaseClassification,0) {0} @idfsCaseClassification_{1} = @idfsCaseClassification_{1})", filters.Operation("idfsCaseClassification", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsCaseClassification,0) {0} @idfsCaseClassification_{1}", filters.Operation("idfsCaseClassification", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCaseProgressStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCaseProgressStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCaseProgressStatus") ? " or " : " and ");
                        
                        if (filters.Operation("idfsCaseProgressStatus", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsCaseProgressStatus,0) {0} @idfsCaseProgressStatus_{1} = @idfsCaseProgressStatus_{1})", filters.Operation("idfsCaseProgressStatus", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsCaseProgressStatus,0) {0} @idfsCaseProgressStatus_{1}", filters.Operation("idfsCaseProgressStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCaseReportType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCaseReportType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCaseReportType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsCaseReportType", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsCaseReportType,0) {0} @idfsCaseReportType_{1} = @idfsCaseReportType_{1})", filters.Operation("idfsCaseReportType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsCaseReportType,0) {0} @idfsCaseReportType_{1}", filters.Operation("idfsCaseReportType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCaseReportType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCaseReportType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCaseReportType") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.strCaseReportType {0} @strCaseReportType_{1}", filters.Operation("strCaseReportType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("FinalDiagnosisName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("FinalDiagnosisName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("FinalDiagnosisName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.FinalDiagnosisName {0} @FinalDiagnosisName_{1}", filters.Operation("FinalDiagnosisName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("DiagnosisName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("DiagnosisName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("DiagnosisName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.DiagnosisName {0} @DiagnosisName_{1}", filters.Operation("DiagnosisName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("CaseStatusName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("CaseStatusName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("CaseStatusName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.CaseStatusName {0} @CaseStatusName_{1}", filters.Operation("CaseStatusName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("CaseClassificationName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("CaseClassificationName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("CaseClassificationName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.CaseClassificationName {0} @CaseClassificationName_{1}", filters.Operation("CaseClassificationName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCaseType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCaseType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCaseType") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.strCaseType {0} @strCaseType_{1}", filters.Operation("strCaseType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCaseType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCaseType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCaseType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsCaseType", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsCaseType,0) {0} @idfsCaseType_{1} = @idfsCaseType_{1})", filters.Operation("idfsCaseType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsCaseType,0) {0} @idfsCaseType_{1}", filters.Operation("idfsCaseType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCaseTypeNullable"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCaseTypeNullable"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCaseTypeNullable") ? " or " : " and ");
                        
                        if (filters.Operation("idfsCaseTypeNullable", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsCaseTypeNullable,0) {0} @idfsCaseTypeNullable_{1} = @idfsCaseTypeNullable_{1})", filters.Operation("idfsCaseTypeNullable", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsCaseTypeNullable,0) {0} @idfsCaseTypeNullable_{1}", filters.Operation("idfsCaseTypeNullable", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("uidOfflineCaseID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("uidOfflineCaseID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("uidOfflineCaseID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.uidOfflineCaseID {0} @uidOfflineCaseID_{1}", filters.Operation("uidOfflineCaseID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfAddress"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfAddress"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfAddress") ? " or " : " and ");
                        
                        if (filters.Operation("idfAddress", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfAddress,0) {0} @idfAddress_{1} = @idfAddress_{1})", filters.Operation("idfAddress", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfAddress,0) {0} @idfAddress_{1}", filters.Operation("idfAddress", i), i);
                            
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
                        
                        sql.AppendFormat("fn_VetCase_SelectList.AddressName {0} @AddressName_{1}", filters.Operation("AddressName", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsCountry,0) {0} @idfsCountry_{1} = @idfsCountry_{1})", filters.Operation("idfsCountry", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsCountry,0) {0} @idfsCountry_{1}", filters.Operation("idfsCountry", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsRegion,0) {0} @idfsRegion_{1} = @idfsRegion_{1})", filters.Operation("idfsRegion", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsRegion,0) {0} @idfsRegion_{1}", filters.Operation("idfsRegion", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsRayon,0) {0} @idfsRayon_{1} = @idfsRayon_{1})", filters.Operation("idfsRayon", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsRayon,0) {0} @idfsRayon_{1}", filters.Operation("idfsRayon", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsSettlement,0) {0} @idfsSettlement_{1} = @idfsSettlement_{1})", filters.Operation("idfsSettlement", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsSettlement,0) {0} @idfsSettlement_{1}", filters.Operation("idfsSettlement", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfFarm"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfFarm"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfFarm") ? " or " : " and ");
                        
                        if (filters.Operation("idfFarm", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfFarm,0) {0} @idfFarm_{1} = @idfFarm_{1})", filters.Operation("idfFarm", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfFarm,0) {0} @idfFarm_{1}", filters.Operation("idfFarm", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("FarmName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("FarmName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("FarmName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.FarmName {0} @FarmName_{1}", filters.Operation("FarmName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsAvianFarmType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsAvianFarmType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsAvianFarmType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsAvianFarmType", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsAvianFarmType,0) {0} @idfsAvianFarmType_{1} = @idfsAvianFarmType_{1})", filters.Operation("idfsAvianFarmType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsAvianFarmType,0) {0} @idfsAvianFarmType_{1}", filters.Operation("idfsAvianFarmType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsAvianProductionType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsAvianProductionType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsAvianProductionType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsAvianProductionType", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsAvianProductionType,0) {0} @idfsAvianProductionType_{1} = @idfsAvianProductionType_{1})", filters.Operation("idfsAvianProductionType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsAvianProductionType,0) {0} @idfsAvianProductionType_{1}", filters.Operation("idfsAvianProductionType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsFarmCategory"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsFarmCategory"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsFarmCategory") ? " or " : " and ");
                        
                        if (filters.Operation("idfsFarmCategory", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsFarmCategory,0) {0} @idfsFarmCategory_{1} = @idfsFarmCategory_{1})", filters.Operation("idfsFarmCategory", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsFarmCategory,0) {0} @idfsFarmCategory_{1}", filters.Operation("idfsFarmCategory", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsOwnershipStructure"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsOwnershipStructure"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsOwnershipStructure") ? " or " : " and ");
                        
                        if (filters.Operation("idfsOwnershipStructure", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsOwnershipStructure,0) {0} @idfsOwnershipStructure_{1} = @idfsOwnershipStructure_{1})", filters.Operation("idfsOwnershipStructure", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsOwnershipStructure,0) {0} @idfsOwnershipStructure_{1}", filters.Operation("idfsOwnershipStructure", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsMovementPattern"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsMovementPattern"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsMovementPattern") ? " or " : " and ");
                        
                        if (filters.Operation("idfsMovementPattern", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsMovementPattern,0) {0} @idfsMovementPattern_{1} = @idfsMovementPattern_{1})", filters.Operation("idfsMovementPattern", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsMovementPattern,0) {0} @idfsMovementPattern_{1}", filters.Operation("idfsMovementPattern", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsIntendedUse"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsIntendedUse"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsIntendedUse") ? " or " : " and ");
                        
                        if (filters.Operation("idfsIntendedUse", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsIntendedUse,0) {0} @idfsIntendedUse_{1} = @idfsIntendedUse_{1})", filters.Operation("idfsIntendedUse", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsIntendedUse,0) {0} @idfsIntendedUse_{1}", filters.Operation("idfsIntendedUse", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsGrazingPattern"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsGrazingPattern"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsGrazingPattern") ? " or " : " and ");
                        
                        if (filters.Operation("idfsGrazingPattern", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsGrazingPattern,0) {0} @idfsGrazingPattern_{1} = @idfsGrazingPattern_{1})", filters.Operation("idfsGrazingPattern", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsGrazingPattern,0) {0} @idfsGrazingPattern_{1}", filters.Operation("idfsGrazingPattern", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsLivestockProductionType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsLivestockProductionType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsLivestockProductionType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsLivestockProductionType", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsLivestockProductionType,0) {0} @idfsLivestockProductionType_{1} = @idfsLivestockProductionType_{1})", filters.Operation("idfsLivestockProductionType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsLivestockProductionType,0) {0} @idfsLivestockProductionType_{1}", filters.Operation("idfsLivestockProductionType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strInternationalName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strInternationalName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strInternationalName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.strInternationalName {0} @strInternationalName_{1}", filters.Operation("strInternationalName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strNationalName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strNationalName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strNationalName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.strNationalName {0} @strNationalName_{1}", filters.Operation("strNationalName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFarmCode"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFarmCode"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFarmCode") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.strFarmCode {0} @strFarmCode_{1}", filters.Operation("strFarmCode", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFax"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFax"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFax") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.strFax {0} @strFax_{1}", filters.Operation("strFax", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strEmail"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strEmail"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strEmail") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.strEmail {0} @strEmail_{1}", filters.Operation("strEmail", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strContactPhone"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strContactPhone"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strContactPhone") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.strContactPhone {0} @strContactPhone_{1}", filters.Operation("strContactPhone", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strOwnerFirstName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strOwnerFirstName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strOwnerFirstName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.strOwnerFirstName {0} @strOwnerFirstName_{1}", filters.Operation("strOwnerFirstName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strOwnerMiddleName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strOwnerMiddleName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strOwnerMiddleName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.strOwnerMiddleName {0} @strOwnerMiddleName_{1}", filters.Operation("strOwnerMiddleName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strOwnerLastName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strOwnerLastName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strOwnerLastName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_VetCase_SelectList.strOwnerLastName {0} @strOwnerLastName_{1}", filters.Operation("strOwnerLastName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intSickAnimalQty"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intSickAnimalQty"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intSickAnimalQty") ? " or " : " and ");
                        
                        if (filters.Operation("intSickAnimalQty", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.intSickAnimalQty,0) {0} @intSickAnimalQty_{1} = @intSickAnimalQty_{1})", filters.Operation("intSickAnimalQty", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.intSickAnimalQty,0) {0} @intSickAnimalQty_{1}", filters.Operation("intSickAnimalQty", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intTotalAnimalQty"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intTotalAnimalQty"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intTotalAnimalQty") ? " or " : " and ");
                        
                        if (filters.Operation("intTotalAnimalQty", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.intTotalAnimalQty,0) {0} @intTotalAnimalQty_{1} = @intTotalAnimalQty_{1})", filters.Operation("intTotalAnimalQty", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.intTotalAnimalQty,0) {0} @intTotalAnimalQty_{1}", filters.Operation("intTotalAnimalQty", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intDeadAnimalQty"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intDeadAnimalQty"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intDeadAnimalQty") ? " or " : " and ");
                        
                        if (filters.Operation("intDeadAnimalQty", i) == "&")
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.intDeadAnimalQty,0) {0} @intDeadAnimalQty_{1} = @intDeadAnimalQty_{1})", filters.Operation("intDeadAnimalQty", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.intDeadAnimalQty,0) {0} @intDeadAnimalQty_{1}", filters.Operation("intDeadAnimalQty", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_VetCase_SelectList.idfsSite,0) {0} @idfsSite_{1} = @idfsSite_{1})", filters.Operation("idfsSite", i), i);
                        else
                          sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsSite,0) {0} @idfsSite_{1}", filters.Operation("idfsSite", i), i);
                            
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
                    
                    if (filters.Contains("idfPerson"))
                        
                        if (filters.Count("idfPerson") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfPerson", ParsingHelper.CorrectLikeValue(filters.Operation("idfPerson"), filters.Value("idfPerson"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfPerson"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfPerson", i), filters.Value("idfPerson", i))));
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
                            
                    if (filters.Contains("idfCase"))
                        for (int i = 0; i < filters.Count("idfCase"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfCase_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfCase", i), filters.Value("idfCase", i))));
                      
                    if (filters.Contains("datAssignedDate"))
                        for (int i = 0; i < filters.Count("datAssignedDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datAssignedDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datAssignedDate", i), filters.Value("datAssignedDate", i))));
                      
                    if (filters.Contains("datEnteredDate"))
                        for (int i = 0; i < filters.Count("datEnteredDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datEnteredDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datEnteredDate", i), filters.Value("datEnteredDate", i))));
                      
                    if (filters.Contains("strCaseID"))
                        for (int i = 0; i < filters.Count("strCaseID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCaseID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCaseID", i), filters.Value("strCaseID", i))));
                      
                    if (filters.Contains("datReportDate"))
                        for (int i = 0; i < filters.Count("datReportDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datReportDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datReportDate", i), filters.Value("datReportDate", i))));
                      
                    if (filters.Contains("datInvestigationDate"))
                        for (int i = 0; i < filters.Count("datInvestigationDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datInvestigationDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datInvestigationDate", i), filters.Value("datInvestigationDate", i))));
                      
                    if (filters.Contains("idfsShowDiagnosis"))
                        for (int i = 0; i < filters.Count("idfsShowDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsShowDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsShowDiagnosis", i), filters.Value("idfsShowDiagnosis", i))));
                      
                    if (filters.Contains("datDiagnosisDate"))
                        for (int i = 0; i < filters.Count("datDiagnosisDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datDiagnosisDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datDiagnosisDate", i), filters.Value("datDiagnosisDate", i))));
                      
                    if (filters.Contains("idfsTentativeDiagnosis"))
                        for (int i = 0; i < filters.Count("idfsTentativeDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTentativeDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTentativeDiagnosis", i), filters.Value("idfsTentativeDiagnosis", i))));
                      
                    if (filters.Contains("idfsTentativeDiagnosis1"))
                        for (int i = 0; i < filters.Count("idfsTentativeDiagnosis1"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTentativeDiagnosis1_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTentativeDiagnosis1", i), filters.Value("idfsTentativeDiagnosis1", i))));
                      
                    if (filters.Contains("idfsTentativeDiagnosis2"))
                        for (int i = 0; i < filters.Count("idfsTentativeDiagnosis2"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTentativeDiagnosis2_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTentativeDiagnosis2", i), filters.Value("idfsTentativeDiagnosis2", i))));
                      
                    if (filters.Contains("idfsFinalDiagnosis"))
                        for (int i = 0; i < filters.Count("idfsFinalDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsFinalDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsFinalDiagnosis", i), filters.Value("idfsFinalDiagnosis", i))));
                      
                    if (filters.Contains("idfPersonEnteredBy"))
                        for (int i = 0; i < filters.Count("idfPersonEnteredBy"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfPersonEnteredBy_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfPersonEnteredBy", i), filters.Value("idfPersonEnteredBy", i))));
                      
                    if (filters.Contains("idfsCaseClassification"))
                        for (int i = 0; i < filters.Count("idfsCaseClassification"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseClassification_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseClassification", i), filters.Value("idfsCaseClassification", i))));
                      
                    if (filters.Contains("idfsCaseProgressStatus"))
                        for (int i = 0; i < filters.Count("idfsCaseProgressStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseProgressStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseProgressStatus", i), filters.Value("idfsCaseProgressStatus", i))));
                      
                    if (filters.Contains("idfsCaseReportType"))
                        for (int i = 0; i < filters.Count("idfsCaseReportType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseReportType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseReportType", i), filters.Value("idfsCaseReportType", i))));
                      
                    if (filters.Contains("strCaseReportType"))
                        for (int i = 0; i < filters.Count("strCaseReportType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCaseReportType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCaseReportType", i), filters.Value("strCaseReportType", i))));
                      
                    if (filters.Contains("FinalDiagnosisName"))
                        for (int i = 0; i < filters.Count("FinalDiagnosisName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@FinalDiagnosisName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("FinalDiagnosisName", i), filters.Value("FinalDiagnosisName", i))));
                      
                    if (filters.Contains("DiagnosisName"))
                        for (int i = 0; i < filters.Count("DiagnosisName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@DiagnosisName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("DiagnosisName", i), filters.Value("DiagnosisName", i))));
                      
                    if (filters.Contains("CaseStatusName"))
                        for (int i = 0; i < filters.Count("CaseStatusName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@CaseStatusName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("CaseStatusName", i), filters.Value("CaseStatusName", i))));
                      
                    if (filters.Contains("CaseClassificationName"))
                        for (int i = 0; i < filters.Count("CaseClassificationName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@CaseClassificationName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("CaseClassificationName", i), filters.Value("CaseClassificationName", i))));
                      
                    if (filters.Contains("strCaseType"))
                        for (int i = 0; i < filters.Count("strCaseType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCaseType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCaseType", i), filters.Value("strCaseType", i))));
                      
                    if (filters.Contains("idfsCaseType"))
                        for (int i = 0; i < filters.Count("idfsCaseType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseType", i), filters.Value("idfsCaseType", i))));
                      
                    if (filters.Contains("idfsCaseTypeNullable"))
                        for (int i = 0; i < filters.Count("idfsCaseTypeNullable"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseTypeNullable_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseTypeNullable", i), filters.Value("idfsCaseTypeNullable", i))));
                      
                    if (filters.Contains("uidOfflineCaseID"))
                        for (int i = 0; i < filters.Count("uidOfflineCaseID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@uidOfflineCaseID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("uidOfflineCaseID", i), filters.Value("uidOfflineCaseID", i))));
                      
                    if (filters.Contains("idfAddress"))
                        for (int i = 0; i < filters.Count("idfAddress"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfAddress_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfAddress", i), filters.Value("idfAddress", i))));
                      
                    if (filters.Contains("AddressName"))
                        for (int i = 0; i < filters.Count("AddressName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@AddressName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("AddressName", i), filters.Value("AddressName", i))));
                      
                    if (filters.Contains("idfsCountry"))
                        for (int i = 0; i < filters.Count("idfsCountry"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCountry_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCountry", i), filters.Value("idfsCountry", i))));
                      
                    if (filters.Contains("idfsRegion"))
                        for (int i = 0; i < filters.Count("idfsRegion"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion", i), filters.Value("idfsRegion", i))));
                      
                    if (filters.Contains("idfsRayon"))
                        for (int i = 0; i < filters.Count("idfsRayon"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon", i), filters.Value("idfsRayon", i))));
                      
                    if (filters.Contains("idfsSettlement"))
                        for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlement", i), filters.Value("idfsSettlement", i))));
                      
                    if (filters.Contains("idfFarm"))
                        for (int i = 0; i < filters.Count("idfFarm"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfFarm_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfFarm", i), filters.Value("idfFarm", i))));
                      
                    if (filters.Contains("FarmName"))
                        for (int i = 0; i < filters.Count("FarmName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@FarmName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("FarmName", i), filters.Value("FarmName", i))));
                      
                    if (filters.Contains("idfsAvianFarmType"))
                        for (int i = 0; i < filters.Count("idfsAvianFarmType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAvianFarmType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsAvianFarmType", i), filters.Value("idfsAvianFarmType", i))));
                      
                    if (filters.Contains("idfsAvianProductionType"))
                        for (int i = 0; i < filters.Count("idfsAvianProductionType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAvianProductionType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsAvianProductionType", i), filters.Value("idfsAvianProductionType", i))));
                      
                    if (filters.Contains("idfsFarmCategory"))
                        for (int i = 0; i < filters.Count("idfsFarmCategory"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsFarmCategory_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsFarmCategory", i), filters.Value("idfsFarmCategory", i))));
                      
                    if (filters.Contains("idfsOwnershipStructure"))
                        for (int i = 0; i < filters.Count("idfsOwnershipStructure"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsOwnershipStructure_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsOwnershipStructure", i), filters.Value("idfsOwnershipStructure", i))));
                      
                    if (filters.Contains("idfsMovementPattern"))
                        for (int i = 0; i < filters.Count("idfsMovementPattern"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsMovementPattern_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsMovementPattern", i), filters.Value("idfsMovementPattern", i))));
                      
                    if (filters.Contains("idfsIntendedUse"))
                        for (int i = 0; i < filters.Count("idfsIntendedUse"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsIntendedUse_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsIntendedUse", i), filters.Value("idfsIntendedUse", i))));
                      
                    if (filters.Contains("idfsGrazingPattern"))
                        for (int i = 0; i < filters.Count("idfsGrazingPattern"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsGrazingPattern_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsGrazingPattern", i), filters.Value("idfsGrazingPattern", i))));
                      
                    if (filters.Contains("idfsLivestockProductionType"))
                        for (int i = 0; i < filters.Count("idfsLivestockProductionType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsLivestockProductionType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsLivestockProductionType", i), filters.Value("idfsLivestockProductionType", i))));
                      
                    if (filters.Contains("strInternationalName"))
                        for (int i = 0; i < filters.Count("strInternationalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strInternationalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strInternationalName", i), filters.Value("strInternationalName", i))));
                      
                    if (filters.Contains("strNationalName"))
                        for (int i = 0; i < filters.Count("strNationalName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strNationalName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strNationalName", i), filters.Value("strNationalName", i))));
                      
                    if (filters.Contains("strFarmCode"))
                        for (int i = 0; i < filters.Count("strFarmCode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFarmCode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFarmCode", i), filters.Value("strFarmCode", i))));
                      
                    if (filters.Contains("strFax"))
                        for (int i = 0; i < filters.Count("strFax"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFax_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFax", i), filters.Value("strFax", i))));
                      
                    if (filters.Contains("strEmail"))
                        for (int i = 0; i < filters.Count("strEmail"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strEmail_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strEmail", i), filters.Value("strEmail", i))));
                      
                    if (filters.Contains("strContactPhone"))
                        for (int i = 0; i < filters.Count("strContactPhone"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strContactPhone_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strContactPhone", i), filters.Value("strContactPhone", i))));
                      
                    if (filters.Contains("strOwnerFirstName"))
                        for (int i = 0; i < filters.Count("strOwnerFirstName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strOwnerFirstName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strOwnerFirstName", i), filters.Value("strOwnerFirstName", i))));
                      
                    if (filters.Contains("strOwnerMiddleName"))
                        for (int i = 0; i < filters.Count("strOwnerMiddleName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strOwnerMiddleName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strOwnerMiddleName", i), filters.Value("strOwnerMiddleName", i))));
                      
                    if (filters.Contains("strOwnerLastName"))
                        for (int i = 0; i < filters.Count("strOwnerLastName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strOwnerLastName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strOwnerLastName", i), filters.Value("strOwnerLastName", i))));
                      
                    if (filters.Contains("intSickAnimalQty"))
                        for (int i = 0; i < filters.Count("intSickAnimalQty"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intSickAnimalQty_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intSickAnimalQty", i), filters.Value("intSickAnimalQty", i))));
                      
                    if (filters.Contains("intTotalAnimalQty"))
                        for (int i = 0; i < filters.Count("intTotalAnimalQty"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intTotalAnimalQty_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intTotalAnimalQty", i), filters.Value("intTotalAnimalQty", i))));
                      
                    if (filters.Contains("intDeadAnimalQty"))
                        for (int i = 0; i < filters.Count("intDeadAnimalQty"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intDeadAnimalQty_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intDeadAnimalQty", i), filters.Value("intDeadAnimalQty", i))));
                      
                    if (filters.Contains("idfsSite"))
                        for (int i = 0; i < filters.Count("idfsSite"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSite_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSite", i), filters.Value("idfsSite", i))));
                      
                    List<SmallVetCaseListItem> objs = manager.ExecuteList<SmallVetCaseListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                        
                        // restore default isolation level for pool connection
                        manager.BeginTransaction();
                        manager.TestConnection();
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
                        
                        // restore default isolation level for pool connection
                        manager.BeginTransaction();
                        manager.TestConnection();
                        manager.RollbackTransaction();
                    }
                    throw DbModelException.Create(null, e);
                }
            }
            partial void ListSelected(DbManagerProxy manager, List<SmallVetCaseListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spVetCase_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, SmallVetCaseListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, SmallVetCaseListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private SmallVetCaseListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                SmallVetCaseListItem obj = null;
                try
                {
                    obj = SmallVetCaseListItem.CreateInstance();
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
                obj.Country = new Func<SmallVetCaseListItem, CountryLookup>(c => 
                                     c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
                                     .SingleOrDefault())(obj);
                obj.Region = new Func<SmallVetCaseListItem, RegionLookup>(c => 
                                     EidssUserContext.User.Options.Prefs.DefaultRegion == true?
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
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public SmallVetCaseListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public SmallVetCaseListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public SmallVetCaseListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult CreateLivestock(DbManagerProxy manager, SmallVetCaseListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return CreateLivestock(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult CreateLivestock(DbManagerProxy manager, SmallVetCaseListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("CreateLivestock"))
                    throw new PermissionException("VetCase", "CreateLivestock");
                
                return true;
                
            }
            
      
            public ActResult CreateAvian(DbManagerProxy manager, SmallVetCaseListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return CreateAvian(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult CreateAvian(DbManagerProxy manager, SmallVetCaseListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("CreateAvian"))
                    throw new PermissionException("VetCase", "CreateAvian");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(SmallVetCaseListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(SmallVetCaseListItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.Region = new Func<SmallVetCaseListItem, RegionLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.Rayon = new Func<SmallVetCaseListItem, RayonLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                obj.Settlement = new Func<SmallVetCaseListItem, SettlementLookup>(c => null)(obj);
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
    
            public void LoadLookup_Country(DbManagerProxy manager, SmallVetCaseListItem obj)
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
              
                LookupManager.AddObject("CountryLookup", obj, CountryAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Region(DbManagerProxy manager, SmallVetCaseListItem obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<SmallVetCaseListItem, long>(c => c.idfsCountry ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRegion == obj.idfsRegion))
                    
                    .ToList());
                
                if (obj.idfsRegion != null && obj.idfsRegion != 0)
                {
                    obj.Region = obj.RegionLookup
                        .SingleOrDefault(c => c.idfsRegion == obj.idfsRegion);
                    
                }
              
                LookupManager.AddObject("RegionLookup", obj, RegionAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Rayon(DbManagerProxy manager, SmallVetCaseListItem obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<SmallVetCaseListItem, long>(c => c.idfsRegion ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRayon == obj.idfsRayon))
                    
                    .ToList());
                
                if (obj.idfsRayon != null && obj.idfsRayon != 0)
                {
                    obj.Rayon = obj.RayonLookup
                        .SingleOrDefault(c => c.idfsRayon == obj.idfsRayon);
                    
                }
              
                LookupManager.AddObject("RayonLookup", obj, RayonAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Settlement(DbManagerProxy manager, SmallVetCaseListItem obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<SmallVetCaseListItem, long>(c => c.idfsRayon ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSettlement == obj.idfsSettlement))
                    
                    .ToList());
                
                if (obj.idfsSettlement != null && obj.idfsSettlement != 0)
                {
                    obj.Settlement = obj.SettlementLookup
                        .SingleOrDefault(c => c.idfsSettlement == obj.idfsSettlement);
                    
                }
              
                LookupManager.AddObject("SettlementLookup", obj, SettlementAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Diagnosis(DbManagerProxy manager, SmallVetCaseListItem obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.LivestockAvian) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != null && obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_CaseType(DbManagerProxy manager, SmallVetCaseListItem obj)
            {
                
                obj.CaseTypeLookup.Clear();
                
                obj.CaseTypeLookup.Add(CaseTypeAccessor.CreateNewT(manager, null));
                
                obj.CaseTypeLookup.AddRange(CaseTypeAccessor.rftCaseType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCaseType))
                    
                    .ToList());
                
                if (obj.idfsCaseType != 0)
                {
                    obj.CaseType = obj.CaseTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsCaseType);
                    
                }
              
                LookupManager.AddObject("rftCaseType", obj, CaseTypeAccessor.GetType(), "rftCaseType_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, SmallVetCaseListItem obj)
            {
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_CaseType(manager, obj);
                
            }
    
            [SprocName("spVetCase_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spVetCase_Delete")]
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
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        SmallVetCaseListItem bo = obj as SmallVetCaseListItem;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            if (!CanDelete)
                                throw new PermissionException("VetCase", "Delete");
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            if (!CanInsert)
                                throw new PermissionException("VetCase", "Insert");
                        }
                        else if (!bo.IsMarkedToDelete && bo.HasChanges) // update
                        {
                            if (!CanUpdate)
                                throw new PermissionException("VetCase", "Update");
                        }
                        
                        long mainObject = bo.idfCase;
                        
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
                            
                            eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoVetCase;
                            eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbVetCase;
                            manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as SmallVetCaseListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, SmallVetCaseListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfCase
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
            
            public bool ValidateCanDelete(SmallVetCaseListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, SmallVetCaseListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfCase
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, ValidationEventType.Error, obj);
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
        
      
            protected ValidationModelException ChainsValidate(SmallVetCaseListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(SmallVetCaseListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as SmallVetCaseListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, SmallVetCaseListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
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
            
            private void _SetupRequired(SmallVetCaseListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(SmallVetCaseListItem obj)
    {
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement))
      {
      
            obj
              .AddHiddenPersonalData("strOwnerLastName", c => true);
            
            obj
              .AddHiddenPersonalData("strOwnerFirstName", c => true);
            
            obj
              .AddHiddenPersonalData("strOwnerMiddleName", c => true);
            
            obj
              .AddHiddenPersonalData("strFarmCode", c => true);
            
            obj
              .AddHiddenPersonalData("FarmName", c => true);
            
            obj
              .AddHiddenPersonalData("strContactPhone", c => true);
            
            obj
              .AddHiddenPersonalData("strFax", c => true);
            
            obj
              .AddHiddenPersonalData("strEmail", c => true);
            
            obj
              .AddHiddenPersonalData("AddressName", c => true);
            
            obj
              .AddHiddenPersonalData("Settlement", c => true);
            
            obj
              .AddHiddenPersonalData("idfsSettlement", c => true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details))
      {
      
            obj
              .AddHiddenPersonalData("strOwnerLastName", c => true);
            
            obj
              .AddHiddenPersonalData("strOwnerFirstName", c => true);
            
            obj
              .AddHiddenPersonalData("strOwnerMiddleName", c => true);
            
            obj
              .AddHiddenPersonalData("strFarmCode", c => true);
            
            obj
              .AddHiddenPersonalData("FarmName", c => true);
            
            obj
              .AddHiddenPersonalData("strContactPhone", c => true);
            
            obj
              .AddHiddenPersonalData("strFax", c => true);
            
            obj
              .AddHiddenPersonalData("strEmail", c => true);
            
            obj
              .AddHiddenPersonalData("AddressName", c => true);
            
      }
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as SmallVetCaseListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as SmallVetCaseListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "SmallVetCaseListItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private SmallVetCaseListItem m_obj;
            internal Permissions(SmallVetCaseListItem obj)
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
            public static string spSelect = "fn_VetCase_SelectList";
            public static string spCount = "spVetCase_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spVetCase_Delete";
            public static string spCanDelete = "spVetCase_CanDelete";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<SmallVetCaseListItem, bool>> RequiredByField = new Dictionary<string, Func<SmallVetCaseListItem, bool>>();
            public static Dictionary<string, Func<SmallVetCaseListItem, bool>> RequiredByProperty = new Dictionary<string, Func<SmallVetCaseListItem, bool>>();
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
                
                Sizes.Add(_str_strCaseID, 200);
                Sizes.Add(_str_strCaseReportType, 2000);
                Sizes.Add(_str_FinalDiagnosisName, 2000);
                Sizes.Add(_str_DiagnosisName, 500);
                Sizes.Add(_str_CaseStatusName, 2000);
                Sizes.Add(_str_CaseClassificationName, 2000);
                Sizes.Add(_str_strCaseType, 2000);
                Sizes.Add(_str_AddressName, 904);
                Sizes.Add(_str_FarmName, 200);
                Sizes.Add(_str_strInternationalName, 200);
                Sizes.Add(_str_strNationalName, 200);
                Sizes.Add(_str_strFarmCode, 200);
                Sizes.Add(_str_strFax, 200);
                Sizes.Add(_str_strEmail, 200);
                Sizes.Add(_str_strContactPhone, 200);
                Sizes.Add(_str_strOwnerFirstName, 200);
                Sizes.Add(_str_strOwnerMiddleName, 200);
                Sizes.Add(_str_strOwnerLastName, 200);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfPerson",
                    EditorType.Flag,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "lblMyVetCases",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCaseID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strCaseID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosis",
                    EditorType.Lookup,
                    EditorControlWidth.Large, true, true, false, false, 
                    "DiagnosisName",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, "DiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCaseType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsCaseType",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "CaseTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datEnteredDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datEnteredDateSearchPanel",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datInvestigationDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datInvestigationDate",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFarmCode",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strFarmCode",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "FarmName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "FarmName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
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
                GridMeta.Add(new GridMetaItem(
                    _str_idfCase,
                    _str_idfCase, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseID,
                    _str_strCaseID, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datEnteredDate,
                    "datEnteredDateSearchPanel", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DiagnosisName,
                    _str_DiagnosisName, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AddressName,
                    "FarmAddress", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_FarmName,
                    _str_FarmName, null, false, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "CreateLivestock",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).CreateLivestock(manager, (SmallVetCaseListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreateLivestock_Id",
                        "add",
                        /*from BvMessages*/"strCreateLivestock_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
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
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "CreateAvian",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).CreateAvian(manager, (SmallVetCaseListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreateAvian_Id",
                        "add",
                        /*from BvMessages*/"strCreateAvian_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
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
                    "Edit",
                    ActionTypes.Edit,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<VetCase>().SelectDetail(manager, pars[0])),
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
                                c = ObjectAccessor.CreatorInterface<SmallVetCaseListItem>().CreateWithParams(manager, null, pars);
                                ((SmallVetCaseListItem)c).idfCase = (long)pars[0];
                                ((SmallVetCaseListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((SmallVetCaseListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<SmallVetCaseListItem>().Post(manager, (SmallVetCaseListItem)c), c);
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
    
        AddHiddenPersonalData("strOwnerLastName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("strOwnerFirstName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("strOwnerMiddleName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("strFarmCode", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("FarmName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("strContactPhone", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("strFax", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("strEmail", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("AddressName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Settlement", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("idfsSettlement", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("strOwnerLastName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("strOwnerFirstName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("strOwnerMiddleName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("strFarmCode", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("FarmName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("strContactPhone", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("strFax", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("strEmail", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("AddressName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      

    }
  
        }
        #endregion
    

        #endregion
        }
    
}
	