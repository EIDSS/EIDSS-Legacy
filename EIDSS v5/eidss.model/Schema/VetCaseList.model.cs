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
    public abstract partial class VetCaseListItem : 
        EditableObject<VetCaseListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCase { get; set; }
                
        [LocalizedDisplayName(_str_datAssignedDate)]
        [MapField(_str_datAssignedDate)]
        public abstract DateTime? datAssignedDate { get; set; }
        #if MONO
        protected DateTime? datAssignedDate_Original { get { return datAssignedDate; } }
        protected DateTime? datAssignedDate_Previous { get { return datAssignedDate; } }
        #else
        protected DateTime? datAssignedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAssignedDate).OriginalValue; } }
        protected DateTime? datAssignedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAssignedDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("datEnteredDateSearchPanel")]
        [MapField(_str_datEnteredDate)]
        public abstract DateTime? datEnteredDate { get; set; }
        #if MONO
        protected DateTime? datEnteredDate_Original { get { return datEnteredDate; } }
        protected DateTime? datEnteredDate_Previous { get { return datEnteredDate; } }
        #else
        protected DateTime? datEnteredDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).OriginalValue; } }
        protected DateTime? datEnteredDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCaseID)]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        #if MONO
        protected String strCaseID_Original { get { return strCaseID; } }
        protected String strCaseID_Previous { get { return strCaseID; } }
        #else
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datReportDate)]
        [MapField(_str_datReportDate)]
        public abstract DateTime? datReportDate { get; set; }
        #if MONO
        protected DateTime? datReportDate_Original { get { return datReportDate; } }
        protected DateTime? datReportDate_Previous { get { return datReportDate; } }
        #else
        protected DateTime? datReportDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReportDate).OriginalValue; } }
        protected DateTime? datReportDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReportDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datInvestigationDate)]
        [MapField(_str_datInvestigationDate)]
        public abstract DateTime? datInvestigationDate { get; set; }
        #if MONO
        protected DateTime? datInvestigationDate_Original { get { return datInvestigationDate; } }
        protected DateTime? datInvestigationDate_Previous { get { return datInvestigationDate; } }
        #else
        protected DateTime? datInvestigationDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datInvestigationDate).OriginalValue; } }
        protected DateTime? datInvestigationDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datInvestigationDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsDiagnosis)]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64? idfsDiagnosis { get; set; }
        #if MONO
        protected Int64? idfsDiagnosis_Original { get { return idfsDiagnosis; } }
        protected Int64? idfsDiagnosis_Previous { get { return idfsDiagnosis; } }
        #else
        protected Int64? idfsDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64? idfsDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsTentativeDiagnosis)]
        [MapField(_str_idfsTentativeDiagnosis)]
        public abstract Int64? idfsTentativeDiagnosis { get; set; }
        #if MONO
        protected Int64? idfsTentativeDiagnosis_Original { get { return idfsTentativeDiagnosis; } }
        protected Int64? idfsTentativeDiagnosis_Previous { get { return idfsTentativeDiagnosis; } }
        #else
        protected Int64? idfsTentativeDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsTentativeDiagnosis1)]
        [MapField(_str_idfsTentativeDiagnosis1)]
        public abstract Int64? idfsTentativeDiagnosis1 { get; set; }
        #if MONO
        protected Int64? idfsTentativeDiagnosis1_Original { get { return idfsTentativeDiagnosis1; } }
        protected Int64? idfsTentativeDiagnosis1_Previous { get { return idfsTentativeDiagnosis1; } }
        #else
        protected Int64? idfsTentativeDiagnosis1_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis1).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis1_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis1).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsTentativeDiagnosis2)]
        [MapField(_str_idfsTentativeDiagnosis2)]
        public abstract Int64? idfsTentativeDiagnosis2 { get; set; }
        #if MONO
        protected Int64? idfsTentativeDiagnosis2_Original { get { return idfsTentativeDiagnosis2; } }
        protected Int64? idfsTentativeDiagnosis2_Previous { get { return idfsTentativeDiagnosis2; } }
        #else
        protected Int64? idfsTentativeDiagnosis2_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis2).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis2_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis2).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsFinalDiagnosis)]
        [MapField(_str_idfsFinalDiagnosis)]
        public abstract Int64? idfsFinalDiagnosis { get; set; }
        #if MONO
        protected Int64? idfsFinalDiagnosis_Original { get { return idfsFinalDiagnosis; } }
        protected Int64? idfsFinalDiagnosis_Previous { get { return idfsFinalDiagnosis; } }
        #else
        protected Int64? idfsFinalDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalDiagnosis).OriginalValue; } }
        protected Int64? idfsFinalDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalDiagnosis).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsCaseStatus)]
        [MapField(_str_idfsCaseStatus)]
        public abstract Int64? idfsCaseStatus { get; set; }
        #if MONO
        protected Int64? idfsCaseStatus_Original { get { return idfsCaseStatus; } }
        protected Int64? idfsCaseStatus_Previous { get { return idfsCaseStatus; } }
        #else
        protected Int64? idfsCaseStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseStatus).OriginalValue; } }
        protected Int64? idfsCaseStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCaseProgressStatus)]
        [MapField(_str_idfsCaseProgressStatus)]
        public abstract Int64? idfsCaseProgressStatus { get; set; }
        #if MONO
        protected Int64? idfsCaseProgressStatus_Original { get { return idfsCaseProgressStatus; } }
        protected Int64? idfsCaseProgressStatus_Previous { get { return idfsCaseProgressStatus; } }
        #else
        protected Int64? idfsCaseProgressStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseProgressStatus).OriginalValue; } }
        protected Int64? idfsCaseProgressStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseProgressStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCaseReportType)]
        [MapField(_str_idfsCaseReportType)]
        public abstract Int64 idfsCaseReportType { get; set; }
        #if MONO
        protected Int64 idfsCaseReportType_Original { get { return idfsCaseReportType; } }
        protected Int64 idfsCaseReportType_Previous { get { return idfsCaseReportType; } }
        #else
        protected Int64 idfsCaseReportType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseReportType).OriginalValue; } }
        protected Int64 idfsCaseReportType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseReportType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsCaseReportType")]
        [MapField(_str_strCaseReportType)]
        public abstract String strCaseReportType { get; set; }
        #if MONO
        protected String strCaseReportType_Original { get { return strCaseReportType; } }
        protected String strCaseReportType_Previous { get { return strCaseReportType; } }
        #else
        protected String strCaseReportType_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseReportType).OriginalValue; } }
        protected String strCaseReportType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseReportType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strDiagnoses")]
        [MapField(_str_DiagnosisName)]
        public abstract String DiagnosisName { get; set; }
        #if MONO
        protected String DiagnosisName_Original { get { return DiagnosisName; } }
        protected String DiagnosisName_Previous { get { return DiagnosisName; } }
        #else
        protected String DiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).OriginalValue; } }
        protected String DiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._diagnosisName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsCaseStatusShort")]
        [MapField(_str_CaseStatusName)]
        public abstract String CaseStatusName { get; set; }
        #if MONO
        protected String CaseStatusName_Original { get { return CaseStatusName; } }
        protected String CaseStatusName_Previous { get { return CaseStatusName; } }
        #else
        protected String CaseStatusName_Original { get { return ((EditableValue<String>)((dynamic)this)._caseStatusName).OriginalValue; } }
        protected String CaseStatusName_Previous { get { return ((EditableValue<String>)((dynamic)this)._caseStatusName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsCaseClassificationShort")]
        [MapField(_str_CaseClassificationName)]
        public abstract String CaseClassificationName { get; set; }
        #if MONO
        protected String CaseClassificationName_Original { get { return CaseClassificationName; } }
        protected String CaseClassificationName_Previous { get { return CaseClassificationName; } }
        #else
        protected String CaseClassificationName_Original { get { return ((EditableValue<String>)((dynamic)this)._caseClassificationName).OriginalValue; } }
        protected String CaseClassificationName_Previous { get { return ((EditableValue<String>)((dynamic)this)._caseClassificationName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsCaseType")]
        [MapField(_str_strCaseType)]
        public abstract String strCaseType { get; set; }
        #if MONO
        protected String strCaseType_Original { get { return strCaseType; } }
        protected String strCaseType_Previous { get { return strCaseType; } }
        #else
        protected String strCaseType_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseType).OriginalValue; } }
        protected String strCaseType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64 idfsCaseType { get; set; }
        #if MONO
        protected Int64 idfsCaseType_Original { get { return idfsCaseType; } }
        protected Int64 idfsCaseType_Previous { get { return idfsCaseType; } }
        #else
        protected Int64 idfsCaseType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64 idfsCaseType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCaseTypeNullable)]
        [MapField(_str_idfsCaseTypeNullable)]
        public abstract Int64? idfsCaseTypeNullable { get; set; }
        #if MONO
        protected Int64? idfsCaseTypeNullable_Original { get { return idfsCaseTypeNullable; } }
        protected Int64? idfsCaseTypeNullable_Previous { get { return idfsCaseTypeNullable; } }
        #else
        protected Int64? idfsCaseTypeNullable_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseTypeNullable).OriginalValue; } }
        protected Int64? idfsCaseTypeNullable_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseTypeNullable).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfAddress)]
        [MapField(_str_idfAddress)]
        public abstract Int64? idfAddress { get; set; }
        #if MONO
        protected Int64? idfAddress_Original { get { return idfAddress; } }
        protected Int64? idfAddress_Previous { get { return idfAddress; } }
        #else
        protected Int64? idfAddress_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAddress).OriginalValue; } }
        protected Int64? idfAddress_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAddress).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("FarmAddress")]
        [MapField(_str_AddressName)]
        public abstract String AddressName { get; set; }
        #if MONO
        protected String AddressName_Original { get { return AddressName; } }
        protected String AddressName_Previous { get { return AddressName; } }
        #else
        protected String AddressName_Original { get { return ((EditableValue<String>)((dynamic)this)._addressName).OriginalValue; } }
        protected String AddressName_Previous { get { return ((EditableValue<String>)((dynamic)this)._addressName).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfFarm)]
        [MapField(_str_idfFarm)]
        public abstract Int64 idfFarm { get; set; }
        #if MONO
        protected Int64 idfFarm_Original { get { return idfFarm; } }
        protected Int64 idfFarm_Previous { get { return idfFarm; } }
        #else
        protected Int64 idfFarm_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).OriginalValue; } }
        protected Int64 idfFarm_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_FarmName)]
        [MapField(_str_FarmName)]
        public abstract String FarmName { get; set; }
        #if MONO
        protected String FarmName_Original { get { return FarmName; } }
        protected String FarmName_Previous { get { return FarmName; } }
        #else
        protected String FarmName_Original { get { return ((EditableValue<String>)((dynamic)this)._farmName).OriginalValue; } }
        protected String FarmName_Previous { get { return ((EditableValue<String>)((dynamic)this)._farmName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfGeoLocation)]
        [MapField(_str_idfGeoLocation)]
        public abstract Int64? idfGeoLocation { get; set; }
        #if MONO
        protected Int64? idfGeoLocation_Original { get { return idfGeoLocation; } }
        protected Int64? idfGeoLocation_Previous { get { return idfGeoLocation; } }
        #else
        protected Int64? idfGeoLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfGeoLocation).OriginalValue; } }
        protected Int64? idfGeoLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfGeoLocation).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsFarmCategory)]
        [MapField(_str_idfsFarmCategory)]
        public abstract Int64? idfsFarmCategory { get; set; }
        #if MONO
        protected Int64? idfsFarmCategory_Original { get { return idfsFarmCategory; } }
        protected Int64? idfsFarmCategory_Previous { get { return idfsFarmCategory; } }
        #else
        protected Int64? idfsFarmCategory_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFarmCategory).OriginalValue; } }
        protected Int64? idfsFarmCategory_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFarmCategory).PreviousValue; } }
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
                
        [LocalizedDisplayName("strOwnerName")]
        [MapField(_str_strOwnerLastName)]
        public abstract String strOwnerLastName { get; set; }
        #if MONO
        protected String strOwnerLastName_Original { get { return strOwnerLastName; } }
        protected String strOwnerLastName_Previous { get { return strOwnerLastName; } }
        #else
        protected String strOwnerLastName_Original { get { return ((EditableValue<String>)((dynamic)this)._strOwnerLastName).OriginalValue; } }
        protected String strOwnerLastName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOwnerLastName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intSickAnimalQty)]
        [MapField(_str_intSickAnimalQty)]
        public abstract Int32? intSickAnimalQty { get; set; }
        #if MONO
        protected Int32? intSickAnimalQty_Original { get { return intSickAnimalQty; } }
        protected Int32? intSickAnimalQty_Previous { get { return intSickAnimalQty; } }
        #else
        protected Int32? intSickAnimalQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intSickAnimalQty).OriginalValue; } }
        protected Int32? intSickAnimalQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intSickAnimalQty).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("intTotalAnimalQtyFull")]
        [MapField(_str_intTotalAnimalQty)]
        public abstract Int32? intTotalAnimalQty { get; set; }
        #if MONO
        protected Int32? intTotalAnimalQty_Original { get { return intTotalAnimalQty; } }
        protected Int32? intTotalAnimalQty_Previous { get { return intTotalAnimalQty; } }
        #else
        protected Int32? intTotalAnimalQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intTotalAnimalQty).OriginalValue; } }
        protected Int32? intTotalAnimalQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intTotalAnimalQty).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intDeadAnimalQty)]
        [MapField(_str_intDeadAnimalQty)]
        public abstract Int32? intDeadAnimalQty { get; set; }
        #if MONO
        protected Int32? intDeadAnimalQty_Original { get { return intDeadAnimalQty; } }
        protected Int32? intDeadAnimalQty_Previous { get { return intDeadAnimalQty; } }
        #else
        protected Int32? intDeadAnimalQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intDeadAnimalQty).OriginalValue; } }
        protected Int32? intDeadAnimalQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intDeadAnimalQty).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<VetCaseListItem, object> _get_func;
            internal Action<VetCaseListItem, string> _set_func;
            internal Action<VetCaseListItem, VetCaseListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCase = "idfCase";
        internal const string _str_datAssignedDate = "datAssignedDate";
        internal const string _str_datEnteredDate = "datEnteredDate";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_datReportDate = "datReportDate";
        internal const string _str_datInvestigationDate = "datInvestigationDate";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_idfsTentativeDiagnosis = "idfsTentativeDiagnosis";
        internal const string _str_idfsTentativeDiagnosis1 = "idfsTentativeDiagnosis1";
        internal const string _str_idfsTentativeDiagnosis2 = "idfsTentativeDiagnosis2";
        internal const string _str_idfsFinalDiagnosis = "idfsFinalDiagnosis";
        internal const string _str_idfPersonEnteredBy = "idfPersonEnteredBy";
        internal const string _str_idfsCaseStatus = "idfsCaseStatus";
        internal const string _str_idfsCaseProgressStatus = "idfsCaseProgressStatus";
        internal const string _str_idfsCaseReportType = "idfsCaseReportType";
        internal const string _str_strCaseReportType = "strCaseReportType";
        internal const string _str_DiagnosisName = "DiagnosisName";
        internal const string _str_CaseStatusName = "CaseStatusName";
        internal const string _str_CaseClassificationName = "CaseClassificationName";
        internal const string _str_strCaseType = "strCaseType";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_idfsCaseTypeNullable = "idfsCaseTypeNullable";
        internal const string _str_idfAddress = "idfAddress";
        internal const string _str_AddressName = "AddressName";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_idfFarm = "idfFarm";
        internal const string _str_FarmName = "FarmName";
        internal const string _str_idfGeoLocation = "idfGeoLocation";
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
        internal const string _str_idfsAnimalAge = "idfsAnimalAge";
        internal const string _str_idfsAnimalGender = "idfsAnimalGender";
        internal const string _str_idfsAnimalCondition = "idfsAnimalCondition";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_finalDiagnosisOnly = "finalDiagnosisOnly";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_CaseProgressStatus = "CaseProgressStatus";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_CaseStatus = "CaseStatus";
        internal const string _str_CaseType = "CaseType";
        internal const string _str_CaseReportType = "CaseReportType";
        internal const string _str_AnimalAge = "AnimalAge";
        internal const string _str_AnimalGender = "AnimalGender";
        internal const string _str_AnimalCondition = "AnimalCondition";
        internal const string _str_SpeciesType = "SpeciesType";
        internal const string _str_OwnershipStructure = "OwnershipStructure";
        internal const string _str_LivestockProductionType = "LivestockProductionType";
        internal const string _str_MovementPattern = "MovementPattern";
        internal const string _str_GrazingPattern = "GrazingPattern";
        internal const string _str_AvianFarmProductionType = "AvianFarmProductionType";
        internal const string _str_AvianFarmType = "AvianFarmType";
        internal const string _str_FarmIntendedUse = "FarmIntendedUse";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfCase, _type = "Int64",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { o.idfCase = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, "Int64", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); }
              }, 
        
            new field_info {
              _name = _str_datAssignedDate, _type = "DateTime?",
              _get_func = o => o.datAssignedDate,
              _set_func = (o, val) => { o.datAssignedDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datAssignedDate != c.datAssignedDate || o.IsRIRPropChanged(_str_datAssignedDate, c)) 
                  m.Add(_str_datAssignedDate, o.ObjectIdent + _str_datAssignedDate, "DateTime?", o.datAssignedDate == null ? "" : o.datAssignedDate.ToString(), o.IsReadOnly(_str_datAssignedDate), o.IsInvisible(_str_datAssignedDate), o.IsRequired(_str_datAssignedDate)); }
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
              _name = _str_strCaseID, _type = "String",
              _get_func = o => o.strCaseID,
              _set_func = (o, val) => { o.strCaseID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCaseID != c.strCaseID || o.IsRIRPropChanged(_str_strCaseID, c)) 
                  m.Add(_str_strCaseID, o.ObjectIdent + _str_strCaseID, "String", o.strCaseID == null ? "" : o.strCaseID.ToString(), o.IsReadOnly(_str_strCaseID), o.IsInvisible(_str_strCaseID), o.IsRequired(_str_strCaseID)); }
              }, 
        
            new field_info {
              _name = _str_datReportDate, _type = "DateTime?",
              _get_func = o => o.datReportDate,
              _set_func = (o, val) => { o.datReportDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datReportDate != c.datReportDate || o.IsRIRPropChanged(_str_datReportDate, c)) 
                  m.Add(_str_datReportDate, o.ObjectIdent + _str_datReportDate, "DateTime?", o.datReportDate == null ? "" : o.datReportDate.ToString(), o.IsReadOnly(_str_datReportDate), o.IsInvisible(_str_datReportDate), o.IsRequired(_str_datReportDate)); }
              }, 
        
            new field_info {
              _name = _str_datInvestigationDate, _type = "DateTime?",
              _get_func = o => o.datInvestigationDate,
              _set_func = (o, val) => { o.datInvestigationDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datInvestigationDate != c.datInvestigationDate || o.IsRIRPropChanged(_str_datInvestigationDate, c)) 
                  m.Add(_str_datInvestigationDate, o.ObjectIdent + _str_datInvestigationDate, "DateTime?", o.datInvestigationDate == null ? "" : o.datInvestigationDate.ToString(), o.IsReadOnly(_str_datInvestigationDate), o.IsInvisible(_str_datInvestigationDate), o.IsRequired(_str_datInvestigationDate)); }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { o.idfsDiagnosis = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, "Int64?", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_idfsTentativeDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsTentativeDiagnosis,
              _set_func = (o, val) => { o.idfsTentativeDiagnosis = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTentativeDiagnosis != c.idfsTentativeDiagnosis || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis, c)) 
                  m.Add(_str_idfsTentativeDiagnosis, o.ObjectIdent + _str_idfsTentativeDiagnosis, "Int64?", o.idfsTentativeDiagnosis == null ? "" : o.idfsTentativeDiagnosis.ToString(), o.IsReadOnly(_str_idfsTentativeDiagnosis), o.IsInvisible(_str_idfsTentativeDiagnosis), o.IsRequired(_str_idfsTentativeDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_idfsTentativeDiagnosis1, _type = "Int64?",
              _get_func = o => o.idfsTentativeDiagnosis1,
              _set_func = (o, val) => { o.idfsTentativeDiagnosis1 = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTentativeDiagnosis1 != c.idfsTentativeDiagnosis1 || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis1, c)) 
                  m.Add(_str_idfsTentativeDiagnosis1, o.ObjectIdent + _str_idfsTentativeDiagnosis1, "Int64?", o.idfsTentativeDiagnosis1 == null ? "" : o.idfsTentativeDiagnosis1.ToString(), o.IsReadOnly(_str_idfsTentativeDiagnosis1), o.IsInvisible(_str_idfsTentativeDiagnosis1), o.IsRequired(_str_idfsTentativeDiagnosis1)); }
              }, 
        
            new field_info {
              _name = _str_idfsTentativeDiagnosis2, _type = "Int64?",
              _get_func = o => o.idfsTentativeDiagnosis2,
              _set_func = (o, val) => { o.idfsTentativeDiagnosis2 = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTentativeDiagnosis2 != c.idfsTentativeDiagnosis2 || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis2, c)) 
                  m.Add(_str_idfsTentativeDiagnosis2, o.ObjectIdent + _str_idfsTentativeDiagnosis2, "Int64?", o.idfsTentativeDiagnosis2 == null ? "" : o.idfsTentativeDiagnosis2.ToString(), o.IsReadOnly(_str_idfsTentativeDiagnosis2), o.IsInvisible(_str_idfsTentativeDiagnosis2), o.IsRequired(_str_idfsTentativeDiagnosis2)); }
              }, 
        
            new field_info {
              _name = _str_idfsFinalDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsFinalDiagnosis,
              _set_func = (o, val) => { o.idfsFinalDiagnosis = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFinalDiagnosis != c.idfsFinalDiagnosis || o.IsRIRPropChanged(_str_idfsFinalDiagnosis, c)) 
                  m.Add(_str_idfsFinalDiagnosis, o.ObjectIdent + _str_idfsFinalDiagnosis, "Int64?", o.idfsFinalDiagnosis == null ? "" : o.idfsFinalDiagnosis.ToString(), o.IsReadOnly(_str_idfsFinalDiagnosis), o.IsInvisible(_str_idfsFinalDiagnosis), o.IsRequired(_str_idfsFinalDiagnosis)); }
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
              _name = _str_idfsCaseStatus, _type = "Int64?",
              _get_func = o => o.idfsCaseStatus,
              _set_func = (o, val) => { o.idfsCaseStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseStatus != c.idfsCaseStatus || o.IsRIRPropChanged(_str_idfsCaseStatus, c)) 
                  m.Add(_str_idfsCaseStatus, o.ObjectIdent + _str_idfsCaseStatus, "Int64?", o.idfsCaseStatus == null ? "" : o.idfsCaseStatus.ToString(), o.IsReadOnly(_str_idfsCaseStatus), o.IsInvisible(_str_idfsCaseStatus), o.IsRequired(_str_idfsCaseStatus)); }
              }, 
        
            new field_info {
              _name = _str_idfsCaseProgressStatus, _type = "Int64?",
              _get_func = o => o.idfsCaseProgressStatus,
              _set_func = (o, val) => { o.idfsCaseProgressStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseProgressStatus != c.idfsCaseProgressStatus || o.IsRIRPropChanged(_str_idfsCaseProgressStatus, c)) 
                  m.Add(_str_idfsCaseProgressStatus, o.ObjectIdent + _str_idfsCaseProgressStatus, "Int64?", o.idfsCaseProgressStatus == null ? "" : o.idfsCaseProgressStatus.ToString(), o.IsReadOnly(_str_idfsCaseProgressStatus), o.IsInvisible(_str_idfsCaseProgressStatus), o.IsRequired(_str_idfsCaseProgressStatus)); }
              }, 
        
            new field_info {
              _name = _str_idfsCaseReportType, _type = "Int64",
              _get_func = o => o.idfsCaseReportType,
              _set_func = (o, val) => { o.idfsCaseReportType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseReportType != c.idfsCaseReportType || o.IsRIRPropChanged(_str_idfsCaseReportType, c)) 
                  m.Add(_str_idfsCaseReportType, o.ObjectIdent + _str_idfsCaseReportType, "Int64", o.idfsCaseReportType == null ? "" : o.idfsCaseReportType.ToString(), o.IsReadOnly(_str_idfsCaseReportType), o.IsInvisible(_str_idfsCaseReportType), o.IsRequired(_str_idfsCaseReportType)); }
              }, 
        
            new field_info {
              _name = _str_strCaseReportType, _type = "String",
              _get_func = o => o.strCaseReportType,
              _set_func = (o, val) => { o.strCaseReportType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCaseReportType != c.strCaseReportType || o.IsRIRPropChanged(_str_strCaseReportType, c)) 
                  m.Add(_str_strCaseReportType, o.ObjectIdent + _str_strCaseReportType, "String", o.strCaseReportType == null ? "" : o.strCaseReportType.ToString(), o.IsReadOnly(_str_strCaseReportType), o.IsInvisible(_str_strCaseReportType), o.IsRequired(_str_strCaseReportType)); }
              }, 
        
            new field_info {
              _name = _str_DiagnosisName, _type = "String",
              _get_func = o => o.DiagnosisName,
              _set_func = (o, val) => { o.DiagnosisName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.DiagnosisName != c.DiagnosisName || o.IsRIRPropChanged(_str_DiagnosisName, c)) 
                  m.Add(_str_DiagnosisName, o.ObjectIdent + _str_DiagnosisName, "String", o.DiagnosisName == null ? "" : o.DiagnosisName.ToString(), o.IsReadOnly(_str_DiagnosisName), o.IsInvisible(_str_DiagnosisName), o.IsRequired(_str_DiagnosisName)); }
              }, 
        
            new field_info {
              _name = _str_CaseStatusName, _type = "String",
              _get_func = o => o.CaseStatusName,
              _set_func = (o, val) => { o.CaseStatusName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.CaseStatusName != c.CaseStatusName || o.IsRIRPropChanged(_str_CaseStatusName, c)) 
                  m.Add(_str_CaseStatusName, o.ObjectIdent + _str_CaseStatusName, "String", o.CaseStatusName == null ? "" : o.CaseStatusName.ToString(), o.IsReadOnly(_str_CaseStatusName), o.IsInvisible(_str_CaseStatusName), o.IsRequired(_str_CaseStatusName)); }
              }, 
        
            new field_info {
              _name = _str_CaseClassificationName, _type = "String",
              _get_func = o => o.CaseClassificationName,
              _set_func = (o, val) => { o.CaseClassificationName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.CaseClassificationName != c.CaseClassificationName || o.IsRIRPropChanged(_str_CaseClassificationName, c)) 
                  m.Add(_str_CaseClassificationName, o.ObjectIdent + _str_CaseClassificationName, "String", o.CaseClassificationName == null ? "" : o.CaseClassificationName.ToString(), o.IsReadOnly(_str_CaseClassificationName), o.IsInvisible(_str_CaseClassificationName), o.IsRequired(_str_CaseClassificationName)); }
              }, 
        
            new field_info {
              _name = _str_strCaseType, _type = "String",
              _get_func = o => o.strCaseType,
              _set_func = (o, val) => { o.strCaseType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCaseType != c.strCaseType || o.IsRIRPropChanged(_str_strCaseType, c)) 
                  m.Add(_str_strCaseType, o.ObjectIdent + _str_strCaseType, "String", o.strCaseType == null ? "" : o.strCaseType.ToString(), o.IsReadOnly(_str_strCaseType), o.IsInvisible(_str_strCaseType), o.IsRequired(_str_strCaseType)); }
              }, 
        
            new field_info {
              _name = _str_idfsCaseType, _type = "Int64",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => { o.idfsCaseType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) 
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, "Int64", o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(), o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType)); }
              }, 
        
            new field_info {
              _name = _str_idfsCaseTypeNullable, _type = "Int64?",
              _get_func = o => o.idfsCaseTypeNullable,
              _set_func = (o, val) => { o.idfsCaseTypeNullable = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseTypeNullable != c.idfsCaseTypeNullable || o.IsRIRPropChanged(_str_idfsCaseTypeNullable, c)) 
                  m.Add(_str_idfsCaseTypeNullable, o.ObjectIdent + _str_idfsCaseTypeNullable, "Int64?", o.idfsCaseTypeNullable == null ? "" : o.idfsCaseTypeNullable.ToString(), o.IsReadOnly(_str_idfsCaseTypeNullable), o.IsInvisible(_str_idfsCaseTypeNullable), o.IsRequired(_str_idfsCaseTypeNullable)); }
              }, 
        
            new field_info {
              _name = _str_idfAddress, _type = "Int64?",
              _get_func = o => o.idfAddress,
              _set_func = (o, val) => { o.idfAddress = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAddress != c.idfAddress || o.IsRIRPropChanged(_str_idfAddress, c)) 
                  m.Add(_str_idfAddress, o.ObjectIdent + _str_idfAddress, "Int64?", o.idfAddress == null ? "" : o.idfAddress.ToString(), o.IsReadOnly(_str_idfAddress), o.IsInvisible(_str_idfAddress), o.IsRequired(_str_idfAddress)); }
              }, 
        
            new field_info {
              _name = _str_AddressName, _type = "String",
              _get_func = o => o.AddressName,
              _set_func = (o, val) => { o.AddressName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.AddressName != c.AddressName || o.IsRIRPropChanged(_str_AddressName, c)) 
                  m.Add(_str_AddressName, o.ObjectIdent + _str_AddressName, "String", o.AddressName == null ? "" : o.AddressName.ToString(), o.IsReadOnly(_str_AddressName), o.IsInvisible(_str_AddressName), o.IsRequired(_str_AddressName)); }
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
              _name = _str_idfFarm, _type = "Int64",
              _get_func = o => o.idfFarm,
              _set_func = (o, val) => { o.idfFarm = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfFarm != c.idfFarm || o.IsRIRPropChanged(_str_idfFarm, c)) 
                  m.Add(_str_idfFarm, o.ObjectIdent + _str_idfFarm, "Int64", o.idfFarm == null ? "" : o.idfFarm.ToString(), o.IsReadOnly(_str_idfFarm), o.IsInvisible(_str_idfFarm), o.IsRequired(_str_idfFarm)); }
              }, 
        
            new field_info {
              _name = _str_FarmName, _type = "String",
              _get_func = o => o.FarmName,
              _set_func = (o, val) => { o.FarmName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.FarmName != c.FarmName || o.IsRIRPropChanged(_str_FarmName, c)) 
                  m.Add(_str_FarmName, o.ObjectIdent + _str_FarmName, "String", o.FarmName == null ? "" : o.FarmName.ToString(), o.IsReadOnly(_str_FarmName), o.IsInvisible(_str_FarmName), o.IsRequired(_str_FarmName)); }
              }, 
        
            new field_info {
              _name = _str_idfGeoLocation, _type = "Int64?",
              _get_func = o => o.idfGeoLocation,
              _set_func = (o, val) => { o.idfGeoLocation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfGeoLocation != c.idfGeoLocation || o.IsRIRPropChanged(_str_idfGeoLocation, c)) 
                  m.Add(_str_idfGeoLocation, o.ObjectIdent + _str_idfGeoLocation, "Int64?", o.idfGeoLocation == null ? "" : o.idfGeoLocation.ToString(), o.IsReadOnly(_str_idfGeoLocation), o.IsInvisible(_str_idfGeoLocation), o.IsRequired(_str_idfGeoLocation)); }
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
              _name = _str_idfsFarmCategory, _type = "Int64?",
              _get_func = o => o.idfsFarmCategory,
              _set_func = (o, val) => { o.idfsFarmCategory = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFarmCategory != c.idfsFarmCategory || o.IsRIRPropChanged(_str_idfsFarmCategory, c)) 
                  m.Add(_str_idfsFarmCategory, o.ObjectIdent + _str_idfsFarmCategory, "Int64?", o.idfsFarmCategory == null ? "" : o.idfsFarmCategory.ToString(), o.IsReadOnly(_str_idfsFarmCategory), o.IsInvisible(_str_idfsFarmCategory), o.IsRequired(_str_idfsFarmCategory)); }
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
              _name = _str_idfsMovementPattern, _type = "Int64?",
              _get_func = o => o.idfsMovementPattern,
              _set_func = (o, val) => { o.idfsMovementPattern = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsMovementPattern != c.idfsMovementPattern || o.IsRIRPropChanged(_str_idfsMovementPattern, c)) 
                  m.Add(_str_idfsMovementPattern, o.ObjectIdent + _str_idfsMovementPattern, "Int64?", o.idfsMovementPattern == null ? "" : o.idfsMovementPattern.ToString(), o.IsReadOnly(_str_idfsMovementPattern), o.IsInvisible(_str_idfsMovementPattern), o.IsRequired(_str_idfsMovementPattern)); }
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
              _name = _str_idfsGrazingPattern, _type = "Int64?",
              _get_func = o => o.idfsGrazingPattern,
              _set_func = (o, val) => { o.idfsGrazingPattern = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsGrazingPattern != c.idfsGrazingPattern || o.IsRIRPropChanged(_str_idfsGrazingPattern, c)) 
                  m.Add(_str_idfsGrazingPattern, o.ObjectIdent + _str_idfsGrazingPattern, "Int64?", o.idfsGrazingPattern == null ? "" : o.idfsGrazingPattern.ToString(), o.IsReadOnly(_str_idfsGrazingPattern), o.IsInvisible(_str_idfsGrazingPattern), o.IsRequired(_str_idfsGrazingPattern)); }
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
              _name = _str_strContactPhone, _type = "String",
              _get_func = o => o.strContactPhone,
              _set_func = (o, val) => { o.strContactPhone = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strContactPhone != c.strContactPhone || o.IsRIRPropChanged(_str_strContactPhone, c)) 
                  m.Add(_str_strContactPhone, o.ObjectIdent + _str_strContactPhone, "String", o.strContactPhone == null ? "" : o.strContactPhone.ToString(), o.IsReadOnly(_str_strContactPhone), o.IsInvisible(_str_strContactPhone), o.IsRequired(_str_strContactPhone)); }
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
              _name = _str_strOwnerLastName, _type = "String",
              _get_func = o => o.strOwnerLastName,
              _set_func = (o, val) => { o.strOwnerLastName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strOwnerLastName != c.strOwnerLastName || o.IsRIRPropChanged(_str_strOwnerLastName, c)) 
                  m.Add(_str_strOwnerLastName, o.ObjectIdent + _str_strOwnerLastName, "String", o.strOwnerLastName == null ? "" : o.strOwnerLastName.ToString(), o.IsReadOnly(_str_strOwnerLastName), o.IsInvisible(_str_strOwnerLastName), o.IsRequired(_str_strOwnerLastName)); }
              }, 
        
            new field_info {
              _name = _str_intSickAnimalQty, _type = "Int32?",
              _get_func = o => o.intSickAnimalQty,
              _set_func = (o, val) => { o.intSickAnimalQty = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intSickAnimalQty != c.intSickAnimalQty || o.IsRIRPropChanged(_str_intSickAnimalQty, c)) 
                  m.Add(_str_intSickAnimalQty, o.ObjectIdent + _str_intSickAnimalQty, "Int32?", o.intSickAnimalQty == null ? "" : o.intSickAnimalQty.ToString(), o.IsReadOnly(_str_intSickAnimalQty), o.IsInvisible(_str_intSickAnimalQty), o.IsRequired(_str_intSickAnimalQty)); }
              }, 
        
            new field_info {
              _name = _str_intTotalAnimalQty, _type = "Int32?",
              _get_func = o => o.intTotalAnimalQty,
              _set_func = (o, val) => { o.intTotalAnimalQty = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intTotalAnimalQty != c.intTotalAnimalQty || o.IsRIRPropChanged(_str_intTotalAnimalQty, c)) 
                  m.Add(_str_intTotalAnimalQty, o.ObjectIdent + _str_intTotalAnimalQty, "Int32?", o.intTotalAnimalQty == null ? "" : o.intTotalAnimalQty.ToString(), o.IsReadOnly(_str_intTotalAnimalQty), o.IsInvisible(_str_intTotalAnimalQty), o.IsRequired(_str_intTotalAnimalQty)); }
              }, 
        
            new field_info {
              _name = _str_intDeadAnimalQty, _type = "Int32?",
              _get_func = o => o.intDeadAnimalQty,
              _set_func = (o, val) => { o.intDeadAnimalQty = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intDeadAnimalQty != c.intDeadAnimalQty || o.IsRIRPropChanged(_str_intDeadAnimalQty, c)) 
                  m.Add(_str_intDeadAnimalQty, o.ObjectIdent + _str_intDeadAnimalQty, "Int32?", o.intDeadAnimalQty == null ? "" : o.intDeadAnimalQty.ToString(), o.IsReadOnly(_str_intDeadAnimalQty), o.IsInvisible(_str_intDeadAnimalQty), o.IsRequired(_str_intDeadAnimalQty)); }
              }, 
        
            new field_info {
              _name = _str_idfsAnimalAge, _type = "long?",
              _get_func = o => o.idfsAnimalAge,
              _set_func = (o, val) => { o.idfsAnimalAge = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsAnimalAge != c.idfsAnimalAge || o.IsRIRPropChanged(_str_idfsAnimalAge, c)) 
                  m.Add(_str_idfsAnimalAge, o.ObjectIdent + _str_idfsAnimalAge, "long?", o.idfsAnimalAge == null ? "" : o.idfsAnimalAge.ToString(), o.IsReadOnly(_str_idfsAnimalAge), o.IsInvisible(_str_idfsAnimalAge), o.IsRequired(_str_idfsAnimalAge));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsAnimalGender, _type = "long?",
              _get_func = o => o.idfsAnimalGender,
              _set_func = (o, val) => { o.idfsAnimalGender = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsAnimalGender != c.idfsAnimalGender || o.IsRIRPropChanged(_str_idfsAnimalGender, c)) 
                  m.Add(_str_idfsAnimalGender, o.ObjectIdent + _str_idfsAnimalGender, "long?", o.idfsAnimalGender == null ? "" : o.idfsAnimalGender.ToString(), o.IsReadOnly(_str_idfsAnimalGender), o.IsInvisible(_str_idfsAnimalGender), o.IsRequired(_str_idfsAnimalGender));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsAnimalCondition, _type = "long?",
              _get_func = o => o.idfsAnimalCondition,
              _set_func = (o, val) => { o.idfsAnimalCondition = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsAnimalCondition != c.idfsAnimalCondition || o.IsRIRPropChanged(_str_idfsAnimalCondition, c)) 
                  m.Add(_str_idfsAnimalCondition, o.ObjectIdent + _str_idfsAnimalCondition, "long?", o.idfsAnimalCondition == null ? "" : o.idfsAnimalCondition.ToString(), o.IsReadOnly(_str_idfsAnimalCondition), o.IsInvisible(_str_idfsAnimalCondition), o.IsRequired(_str_idfsAnimalCondition));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsSpeciesType, _type = "long?",
              _get_func = o => o.idfsSpeciesType,
              _set_func = (o, val) => { o.idfsSpeciesType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_idfsSpeciesType, c)) 
                  m.Add(_str_idfsSpeciesType, o.ObjectIdent + _str_idfsSpeciesType, "long?", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_idfsSpeciesType), o.IsInvisible(_str_idfsSpeciesType), o.IsRequired(_str_idfsSpeciesType));
                 }
              }, 
        
            new field_info {
              _name = _str_finalDiagnosisOnly, _type = "bool?",
              _get_func = o => o.finalDiagnosisOnly,
              _set_func = (o, val) => { o.finalDiagnosisOnly = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.finalDiagnosisOnly != c.finalDiagnosisOnly || o.IsRIRPropChanged(_str_finalDiagnosisOnly, c)) 
                  m.Add(_str_finalDiagnosisOnly, o.ObjectIdent + _str_finalDiagnosisOnly, "bool?", o.finalDiagnosisOnly == null ? "" : o.finalDiagnosisOnly.ToString(), o.IsReadOnly(_str_finalDiagnosisOnly), o.IsInvisible(_str_finalDiagnosisOnly), o.IsRequired(_str_finalDiagnosisOnly));
                 }
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
              _name = _str_CaseProgressStatus, _type = "Lookup",
              _get_func = o => { if (o.CaseProgressStatus == null) return null; return o.CaseProgressStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.CaseProgressStatus = o.CaseProgressStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseProgressStatus != c.idfsCaseProgressStatus || o.IsRIRPropChanged(_str_CaseProgressStatus, c)) 
                  m.Add(_str_CaseProgressStatus, o.ObjectIdent + _str_CaseProgressStatus, "Lookup", o.idfsCaseProgressStatus == null ? "" : o.idfsCaseProgressStatus.ToString(), o.IsReadOnly(_str_CaseProgressStatus), o.IsInvisible(_str_CaseProgressStatus), o.IsRequired(_str_CaseProgressStatus)); }
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
              _name = _str_CaseStatus, _type = "Lookup",
              _get_func = o => { if (o.CaseStatus == null) return null; return o.CaseStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.CaseStatus = o.CaseStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseStatus != c.idfsCaseStatus || o.IsRIRPropChanged(_str_CaseStatus, c)) 
                  m.Add(_str_CaseStatus, o.ObjectIdent + _str_CaseStatus, "Lookup", o.idfsCaseStatus == null ? "" : o.idfsCaseStatus.ToString(), o.IsReadOnly(_str_CaseStatus), o.IsInvisible(_str_CaseStatus), o.IsRequired(_str_CaseStatus)); }
              }, 
        
            new field_info {
              _name = _str_CaseType, _type = "Lookup",
              _get_func = o => { if (o.CaseType == null) return null; return o.CaseType.idfsBaseReference; },
              _set_func = (o, val) => { o.CaseType = o.CaseTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseTypeNullable != c.idfsCaseTypeNullable || o.IsRIRPropChanged(_str_CaseType, c)) 
                  m.Add(_str_CaseType, o.ObjectIdent + _str_CaseType, "Lookup", o.idfsCaseTypeNullable == null ? "" : o.idfsCaseTypeNullable.ToString(), o.IsReadOnly(_str_CaseType), o.IsInvisible(_str_CaseType), o.IsRequired(_str_CaseType)); }
              }, 
        
            new field_info {
              _name = _str_CaseReportType, _type = "Lookup",
              _get_func = o => { if (o.CaseReportType == null) return null; return o.CaseReportType.idfsBaseReference; },
              _set_func = (o, val) => { o.CaseReportType = o.CaseReportTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseReportType != c.idfsCaseReportType || o.IsRIRPropChanged(_str_CaseReportType, c)) 
                  m.Add(_str_CaseReportType, o.ObjectIdent + _str_CaseReportType, "Lookup", o.idfsCaseReportType == null ? "" : o.idfsCaseReportType.ToString(), o.IsReadOnly(_str_CaseReportType), o.IsInvisible(_str_CaseReportType), o.IsRequired(_str_CaseReportType)); }
              }, 
        
            new field_info {
              _name = _str_AnimalAge, _type = "Lookup",
              _get_func = o => { if (o.AnimalAge == null) return null; return o.AnimalAge.idfsBaseReference; },
              _set_func = (o, val) => { o.AnimalAge = o.AnimalAgeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalAge != c.idfsAnimalAge || o.IsRIRPropChanged(_str_AnimalAge, c)) 
                  m.Add(_str_AnimalAge, o.ObjectIdent + _str_AnimalAge, "Lookup", o.idfsAnimalAge == null ? "" : o.idfsAnimalAge.ToString(), o.IsReadOnly(_str_AnimalAge), o.IsInvisible(_str_AnimalAge), o.IsRequired(_str_AnimalAge)); }
              }, 
        
            new field_info {
              _name = _str_AnimalGender, _type = "Lookup",
              _get_func = o => { if (o.AnimalGender == null) return null; return o.AnimalGender.idfsBaseReference; },
              _set_func = (o, val) => { o.AnimalGender = o.AnimalGenderLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalGender != c.idfsAnimalGender || o.IsRIRPropChanged(_str_AnimalGender, c)) 
                  m.Add(_str_AnimalGender, o.ObjectIdent + _str_AnimalGender, "Lookup", o.idfsAnimalGender == null ? "" : o.idfsAnimalGender.ToString(), o.IsReadOnly(_str_AnimalGender), o.IsInvisible(_str_AnimalGender), o.IsRequired(_str_AnimalGender)); }
              }, 
        
            new field_info {
              _name = _str_AnimalCondition, _type = "Lookup",
              _get_func = o => { if (o.AnimalCondition == null) return null; return o.AnimalCondition.idfsBaseReference; },
              _set_func = (o, val) => { o.AnimalCondition = o.AnimalConditionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAnimalCondition != c.idfsAnimalCondition || o.IsRIRPropChanged(_str_AnimalCondition, c)) 
                  m.Add(_str_AnimalCondition, o.ObjectIdent + _str_AnimalCondition, "Lookup", o.idfsAnimalCondition == null ? "" : o.idfsAnimalCondition.ToString(), o.IsReadOnly(_str_AnimalCondition), o.IsInvisible(_str_AnimalCondition), o.IsRequired(_str_AnimalCondition)); }
              }, 
        
            new field_info {
              _name = _str_SpeciesType, _type = "Lookup",
              _get_func = o => { if (o.SpeciesType == null) return null; return o.SpeciesType.idfsBaseReference; },
              _set_func = (o, val) => { o.SpeciesType = o.SpeciesTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_SpeciesType, c)) 
                  m.Add(_str_SpeciesType, o.ObjectIdent + _str_SpeciesType, "Lookup", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_SpeciesType), o.IsInvisible(_str_SpeciesType), o.IsRequired(_str_SpeciesType)); }
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
            VetCaseListItem obj = (VetCaseListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
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
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseProgressStatus)]
        public BaseReference CaseProgressStatus
        {
            get { return _CaseProgressStatus == null ? null : ((long)_CaseProgressStatus.Key == 0 ? null : _CaseProgressStatus); }
            set 
            { 
                _CaseProgressStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCaseProgressStatus = _CaseProgressStatus == null 
                    ? new Int64?()
                    : _CaseProgressStatus.idfsBaseReference; 
                OnPropertyChanged(_str_CaseProgressStatus); 
            }
        }
        private BaseReference _CaseProgressStatus;

        
        public BaseReferenceList CaseProgressStatusLookup
        {
            get { return _CaseProgressStatusLookup; }
        }
        private BaseReferenceList _CaseProgressStatusLookup = new BaseReferenceList("rftCaseProgressStatus");
            
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsDiagnosis = _Diagnosis == null 
                    ? new Int64?()
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
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseStatus)]
        public BaseReference CaseStatus
        {
            get { return _CaseStatus == null ? null : ((long)_CaseStatus.Key == 0 ? null : _CaseStatus); }
            set 
            { 
                _CaseStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCaseStatus = _CaseStatus == null 
                    ? new Int64?()
                    : _CaseStatus.idfsBaseReference; 
                OnPropertyChanged(_str_CaseStatus); 
            }
        }
        private BaseReference _CaseStatus;

        
        public BaseReferenceList CaseStatusLookup
        {
            get { return _CaseStatusLookup; }
        }
        private BaseReferenceList _CaseStatusLookup = new BaseReferenceList("rftCaseStatus");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseTypeNullable)]
        public BaseReference CaseType
        {
            get { return _CaseType == null ? null : ((long)_CaseType.Key == 0 ? null : _CaseType); }
            set 
            { 
                _CaseType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCaseTypeNullable = _CaseType == null 
                    ? new Int64?()
                    : _CaseType.idfsBaseReference; 
                OnPropertyChanged(_str_CaseType); 
            }
        }
        private BaseReference _CaseType;

        
        public BaseReferenceList CaseTypeLookup
        {
            get { return _CaseTypeLookup; }
        }
        private BaseReferenceList _CaseTypeLookup = new BaseReferenceList("rftCaseType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseReportType)]
        public BaseReference CaseReportType
        {
            get { return _CaseReportType == null ? null : ((long)_CaseReportType.Key == 0 ? null : _CaseReportType); }
            set 
            { 
                _CaseReportType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCaseReportType = _CaseReportType == null 
                    ? new Int64()
                    : _CaseReportType.idfsBaseReference; 
                OnPropertyChanged(_str_CaseReportType); 
            }
        }
        private BaseReference _CaseReportType;

        
        public BaseReferenceList CaseReportTypeLookup
        {
            get { return _CaseReportTypeLookup; }
        }
        private BaseReferenceList _CaseReportTypeLookup = new BaseReferenceList("rftCaseReportType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAnimalAge)]
        public BaseReference AnimalAge
        {
            get { return _AnimalAge == null ? null : ((long)_AnimalAge.Key == 0 ? null : _AnimalAge); }
            set 
            { 
                _AnimalAge = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAnimalAge = _AnimalAge == null 
                    ? new long?()
                    : _AnimalAge.idfsBaseReference; 
                OnPropertyChanged(_str_AnimalAge); 
            }
        }
        private BaseReference _AnimalAge;

        
        public BaseReferenceList AnimalAgeLookup
        {
            get { return _AnimalAgeLookup; }
        }
        private BaseReferenceList _AnimalAgeLookup = new BaseReferenceList("rftAnimalAgeList");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAnimalGender)]
        public BaseReference AnimalGender
        {
            get { return _AnimalGender == null ? null : ((long)_AnimalGender.Key == 0 ? null : _AnimalGender); }
            set 
            { 
                _AnimalGender = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAnimalGender = _AnimalGender == null 
                    ? new long?()
                    : _AnimalGender.idfsBaseReference; 
                OnPropertyChanged(_str_AnimalGender); 
            }
        }
        private BaseReference _AnimalGender;

        
        public BaseReferenceList AnimalGenderLookup
        {
            get { return _AnimalGenderLookup; }
        }
        private BaseReferenceList _AnimalGenderLookup = new BaseReferenceList("rftAnimalGenderList");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAnimalCondition)]
        public BaseReference AnimalCondition
        {
            get { return _AnimalCondition == null ? null : ((long)_AnimalCondition.Key == 0 ? null : _AnimalCondition); }
            set 
            { 
                _AnimalCondition = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAnimalCondition = _AnimalCondition == null 
                    ? new long?()
                    : _AnimalCondition.idfsBaseReference; 
                OnPropertyChanged(_str_AnimalCondition); 
            }
        }
        private BaseReference _AnimalCondition;

        
        public BaseReferenceList AnimalConditionLookup
        {
            get { return _AnimalConditionLookup; }
        }
        private BaseReferenceList _AnimalConditionLookup = new BaseReferenceList("rftAnimalCondition");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSpeciesType)]
        public BaseReference SpeciesType
        {
            get { return _SpeciesType == null ? null : ((long)_SpeciesType.Key == 0 ? null : _SpeciesType); }
            set 
            { 
                _SpeciesType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSpeciesType = _SpeciesType == null 
                    ? new long?()
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
            
                case _str_Country:
                    return new BvSelectList(CountryLookup, eidss.model.Schema.CountryLookup._str_idfsCountry, null, Country, _str_idfsCountry);
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionLookup._str_idfsRegion, null, Region, _str_idfsRegion);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonLookup._str_idfsRayon, null, Rayon, _str_idfsRayon);
            
                case _str_Settlement:
                    return new BvSelectList(SettlementLookup, eidss.model.Schema.SettlementLookup._str_idfsSettlement, null, Settlement, _str_idfsSettlement);
            
                case _str_CaseProgressStatus:
                    return new BvSelectList(CaseProgressStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseProgressStatus, _str_idfsCaseProgressStatus);
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_CaseStatus:
                    return new BvSelectList(CaseStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseStatus, _str_idfsCaseStatus);
            
                case _str_CaseType:
                    return new BvSelectList(CaseTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseType, _str_idfsCaseTypeNullable);
            
                case _str_CaseReportType:
                    return new BvSelectList(CaseReportTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseReportType, _str_idfsCaseReportType);
            
                case _str_AnimalAge:
                    return new BvSelectList(AnimalAgeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AnimalAge, _str_idfsAnimalAge);
            
                case _str_AnimalGender:
                    return new BvSelectList(AnimalGenderLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AnimalGender, _str_idfsAnimalGender);
            
                case _str_AnimalCondition:
                    return new BvSelectList(AnimalConditionLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AnimalCondition, _str_idfsAnimalCondition);
            
                case _str_SpeciesType:
                    return new BvSelectList(SpeciesTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SpeciesType, _str_idfsSpeciesType);
            
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
    
          [LocalizedDisplayName(_str_idfsAnimalAge)]
        public long? idfsAnimalAge
        {
            get { return m_idfsAnimalAge; }
            set { if (m_idfsAnimalAge != value) { m_idfsAnimalAge = value; OnPropertyChanged(_str_idfsAnimalAge); } }
        }
        private long? m_idfsAnimalAge;
        
          [LocalizedDisplayName(_str_idfsAnimalGender)]
        public long? idfsAnimalGender
        {
            get { return m_idfsAnimalGender; }
            set { if (m_idfsAnimalGender != value) { m_idfsAnimalGender = value; OnPropertyChanged(_str_idfsAnimalGender); } }
        }
        private long? m_idfsAnimalGender;
        
          [LocalizedDisplayName(_str_idfsAnimalCondition)]
        public long? idfsAnimalCondition
        {
            get { return m_idfsAnimalCondition; }
            set { if (m_idfsAnimalCondition != value) { m_idfsAnimalCondition = value; OnPropertyChanged(_str_idfsAnimalCondition); } }
        }
        private long? m_idfsAnimalCondition;
        
          [LocalizedDisplayName(_str_idfsSpeciesType)]
        public long? idfsSpeciesType
        {
            get { return m_idfsSpeciesType; }
            set { if (m_idfsSpeciesType != value) { m_idfsSpeciesType = value; OnPropertyChanged(_str_idfsSpeciesType); } }
        }
        private long? m_idfsSpeciesType;
        
          [LocalizedDisplayName(_str_finalDiagnosisOnly)]
        public bool? finalDiagnosisOnly
        {
            get { return m_finalDiagnosisOnly; }
            set { if (m_finalDiagnosisOnly != value) { m_finalDiagnosisOnly = value; OnPropertyChanged(_str_finalDiagnosisOnly); } }
        }
        private bool? m_finalDiagnosisOnly;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VetCaseListItem";

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
            var ret = base.Clone() as VetCaseListItem;
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
            var ret = base.Clone() as VetCaseListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public VetCaseListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VetCaseListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfCase; } }
        public string KeyName { get { return "idfCase"; } }
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
        
            var _prev_idfsCountry_Country = idfsCountry;
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            var _prev_idfsSettlement_Settlement = idfsSettlement;
            var _prev_idfsCaseProgressStatus_CaseProgressStatus = idfsCaseProgressStatus;
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsCaseStatus_CaseStatus = idfsCaseStatus;
            var _prev_idfsCaseTypeNullable_CaseType = idfsCaseTypeNullable;
            var _prev_idfsCaseReportType_CaseReportType = idfsCaseReportType;
            var _prev_idfsAnimalAge_AnimalAge = idfsAnimalAge;
            var _prev_idfsAnimalGender_AnimalGender = idfsAnimalGender;
            var _prev_idfsAnimalCondition_AnimalCondition = idfsAnimalCondition;
            var _prev_idfsSpeciesType_SpeciesType = idfsSpeciesType;
            var _prev_idfsOwnershipStructure_OwnershipStructure = idfsOwnershipStructure;
            var _prev_idfsLivestockProductionType_LivestockProductionType = idfsLivestockProductionType;
            var _prev_idfsMovementPattern_MovementPattern = idfsMovementPattern;
            var _prev_idfsGrazingPattern_GrazingPattern = idfsGrazingPattern;
            var _prev_idfsAvianProductionType_AvianFarmProductionType = idfsAvianProductionType;
            var _prev_idfsAvianFarmType_AvianFarmType = idfsAvianFarmType;
            var _prev_idfsIntendedUse_FarmIntendedUse = idfsIntendedUse;
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
            if (_prev_idfsCaseProgressStatus_CaseProgressStatus != idfsCaseProgressStatus)
            {
                _CaseProgressStatus = _CaseProgressStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseProgressStatus);
            }
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsCaseStatus_CaseStatus != idfsCaseStatus)
            {
                _CaseStatus = _CaseStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseStatus);
            }
            if (_prev_idfsCaseTypeNullable_CaseType != idfsCaseTypeNullable)
            {
                _CaseType = _CaseTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseTypeNullable);
            }
            if (_prev_idfsCaseReportType_CaseReportType != idfsCaseReportType)
            {
                _CaseReportType = _CaseReportTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseReportType);
            }
            if (_prev_idfsAnimalAge_AnimalAge != idfsAnimalAge)
            {
                _AnimalAge = _AnimalAgeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAnimalAge);
            }
            if (_prev_idfsAnimalGender_AnimalGender != idfsAnimalGender)
            {
                _AnimalGender = _AnimalGenderLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAnimalGender);
            }
            if (_prev_idfsAnimalCondition_AnimalCondition != idfsAnimalCondition)
            {
                _AnimalCondition = _AnimalConditionLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAnimalCondition);
            }
            if (_prev_idfsSpeciesType_SpeciesType != idfsSpeciesType)
            {
                _SpeciesType = _SpeciesTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSpeciesType);
            }
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

      private bool IsRIRPropChanged(string fld, VetCaseListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public VetCaseListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VetCaseListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VetCaseListItem_PropertyChanged);
        }
        private void VetCaseListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VetCaseListItem).Changed(e.PropertyName);
            
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
            VetCaseListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VetCaseListItem obj = this;
            
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

    
        private static string[] readonly_names1 = "finalDiagnosisOnly".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCaseListItem, bool>(c => c.idfsDiagnosis == null)(this);
            
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


        public Dictionary<string, Func<VetCaseListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VetCaseListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VetCaseListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<VetCaseListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<VetCaseListItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<VetCaseListItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VetCaseListItem()
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
                
                LookupManager.RemoveObject("rftCaseProgressStatus", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftCaseStatus", this);
                
                LookupManager.RemoveObject("rftCaseType", this);
                
                LookupManager.RemoveObject("rftCaseReportType", this);
                
                LookupManager.RemoveObject("rftAnimalAgeList", this);
                
                LookupManager.RemoveObject("rftAnimalGenderList", this);
                
                LookupManager.RemoveObject("rftAnimalCondition", this);
                
                LookupManager.RemoveObject("rftSpeciesList", this);
                
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
            
            if (lookup_object == "CountryLookup")
                _getAccessor().LoadLookup_Country(manager, this);
            
            if (lookup_object == "RegionLookup")
                _getAccessor().LoadLookup_Region(manager, this);
            
            if (lookup_object == "RayonLookup")
                _getAccessor().LoadLookup_Rayon(manager, this);
            
            if (lookup_object == "SettlementLookup")
                _getAccessor().LoadLookup_Settlement(manager, this);
            
            if (lookup_object == "rftCaseProgressStatus")
                _getAccessor().LoadLookup_CaseProgressStatus(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftCaseStatus")
                _getAccessor().LoadLookup_CaseStatus(manager, this);
            
            if (lookup_object == "rftCaseType")
                _getAccessor().LoadLookup_CaseType(manager, this);
            
            if (lookup_object == "rftCaseReportType")
                _getAccessor().LoadLookup_CaseReportType(manager, this);
            
            if (lookup_object == "rftAnimalAgeList")
                _getAccessor().LoadLookup_AnimalAge(manager, this);
            
            if (lookup_object == "rftAnimalGenderList")
                _getAccessor().LoadLookup_AnimalGender(manager, this);
            
            if (lookup_object == "rftAnimalCondition")
                _getAccessor().LoadLookup_AnimalCondition(manager, this);
            
            if (lookup_object == "rftSpeciesList")
                _getAccessor().LoadLookup_SpeciesType(manager, this);
            
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
        
            }
        }
    
        #region Class for web grid
        public class VetCaseListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfCase { get; set; }
        
            public String strCaseID { get; set; }
        
            public DateTime? datEnteredDate { get; set; }
        
            public DateTime? datInvestigationDate { get; set; }
        
            public String DiagnosisName { get; set; }
        
            public String AddressName { get; set; }
        
            public String strOwnerLastName { get; set; }
        
            public Int32? intTotalAnimalQty { get; set; }
        
            public String strCaseType { get; set; }
        
            public String CaseClassificationName { get; set; }
        
            public String CaseStatusName { get; set; }
        
            public String strCaseReportType { get; set; }
        
            public Int64? idfsRegion { get; set; }
        
            public Int64? idfsRayon { get; set; }
        
            public Int64? idfsSettlement { get; set; }
        
        }
        public partial class VetCaseListItemGridModelList : List<VetCaseListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public VetCaseListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VetCaseListItem>, errMes);
            }
            public VetCaseListItemGridModelList(long key, IEnumerable<VetCaseListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<VetCaseListItem> items);
            private void LoadGridModelList(long key, IEnumerable<VetCaseListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strCaseID,_str_datEnteredDate,_str_datInvestigationDate,_str_DiagnosisName,_str_AddressName,_str_strOwnerLastName,_str_intTotalAnimalQty,_str_strCaseType,_str_CaseClassificationName,_str_CaseStatusName,_str_strCaseReportType};
                    
                Hiddens = new List<string> {_str_idfCase,_str_idfsRegion,_str_idfsRayon,_str_idfsSettlement};
                Keys = new List<string> {_str_idfCase};
                Labels = new Dictionary<string, string> {{_str_strCaseID, _str_strCaseID},{_str_datEnteredDate, "datEnteredDateSearchPanel"},{_str_datInvestigationDate, _str_datInvestigationDate},{_str_DiagnosisName, "strDiagnoses"},{_str_AddressName, "FarmAddress"},{_str_strOwnerLastName, "strOwnerName"},{_str_intTotalAnimalQty, "intTotalAnimalQtyFull"},{_str_strCaseType, "idfsCaseType"},{_str_CaseClassificationName, "idfsCaseClassificationShort"},{_str_CaseStatusName, "idfsCaseStatusShort"},{_str_strCaseReportType, "idfsCaseReportType"}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strCaseID, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "ActionEditVetCase")}};
                var list = new List<VetCaseListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VetCaseListItemGridModel()
                {
                    ItemKey=c.idfCase,strCaseID=c.strCaseID,datEnteredDate=c.datEnteredDate,datInvestigationDate=c.datInvestigationDate,DiagnosisName=c.DiagnosisName,AddressName=c.AddressName,strOwnerLastName=c.strOwnerLastName,intTotalAnimalQty=c.intTotalAnimalQty,strCaseType=c.strCaseType,CaseClassificationName=c.CaseClassificationName,CaseStatusName=c.CaseStatusName,strCaseReportType=c.strCaseReportType,idfsRegion=c.idfsRegion,idfsRayon=c.idfsRayon,idfsSettlement=c.idfsSettlement
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
        : DataAccessor<VetCaseListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
            private delegate void on_action(VetCaseListItem obj);
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
            private BaseReference.Accessor CaseProgressStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CaseStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CaseTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CaseReportTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AnimalAgeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AnimalGenderAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AnimalConditionAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SpeciesTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor OwnershipStructureAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor LivestockProductionTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor MovementPatternAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor GrazingPatternAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AvianFarmProductionTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AvianFarmTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor FarmIntendedUseAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<VetCaseListItem> SelectListT(DbManagerProxy manager
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
            
            private List<VetCaseListItem> _SelectList(DbManagerProxy manager
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
                
                if (false
                  
                      || filters.Contains("idfsSpeciesType")
                    
                      || filters.Contains("idfsAnimalAge")
                    
                      || filters.Contains("idfsAnimalGender")
                    
                      || filters.Contains("idfsAnimalCondition")
                    
                      || filters.Contains("strAnimalCode")
                    
                  ) sql.Append(@"distinct ");
                
                sql.Append(@"top ");
                sql.Append(maxtop);
                sql.Append(@" dbo.fn_VetCase_SelectList.* from dbo.fn_VetCase_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("strFieldBarcode"))
                {
                    
                    sql.Append(" " + @"
            LEFT JOIN( select distinct idfCase, strFieldBarcode from tlbMaterial
            WHERE intRowStatus = 0) as m
            on m.idfCase =  fn_VetCase_SelectList.idfCase
          ");
                      
                }
                
                if (filters.Contains("idfsDiagnosis") || filters.Contains("finalDiagnosisOnly"))
                {
                    
                    sql.Append(" " + @"");
                      
                }
                
                if (filters.Contains("idfPerson"))
                {
                    
                    sql.Append(" " + @"
            left join (select distinct idfPerson from tlbPerson where intRowStatus = 0) as person
                on person.idfPerson = fn_VetCase_SelectList.idfPersonEnteredBy
          ");
                      
                }
                
                if (filters.Contains("idfsSpeciesType"))
                {
                    
                    sql.Append(" " + @"
            LEFT JOIN( select distinct farm.idfFarm, species.idfsSpeciesType from tlbFarm farm
            INNER JOIN tlbHerd herd ON
            herd.idfFarm=farm.idfFarm
            AND herd.intRowStatus = 0
            INNER JOIN tlbSpecies species ON
            herd.idfHerd=species.idfHerd
            AND herd.intRowStatus = 0
            where farm.intRowStatus = 0) as s
            ON
            dbo.fn_VetCase_SelectList.idfFarm = s.idfFarm
          ");
                      
                }
                
                if (filters.Contains("idfsAnimalAge") || filters.Contains("idfsAnimalGender") || filters.Contains("idfsAnimalCondition") || filters.Contains("strAnimalCode"))
                {
                    
                    sql.Append(" " + @"
            LEFT JOIN( select distinct farm.idfFarm, 
            animal.idfsAnimalAge, 
            animal.strAnimalCode, 
            animal.idfsAnimalGender, 
            animal.idfsAnimalCondition 
            from tlbFarm farm
            INNER JOIN tlbHerd herd ON
            herd.idfFarm=farm.idfFarm
            AND herd.intRowStatus = 0
            INNER JOIN tlbSpecies species ON
            herd.idfHerd=species.idfHerd
            AND herd.intRowStatus = 0
            INNER JOIN tlbAnimal animal ON
            animal.idfSpecies=species.idfSpecies
            AND animal.intRowStatus = 0
            where farm.intRowStatus = 0) as a
            ON
            dbo.fn_VetCase_SelectList.idfFarm = a.idfFarm
          ");
                      
                }
                
                if (ModelUserContext.IsWebContext && EidssSiteContext.Instance.SiteType == SiteType.SS)
                {
                    sql.Append(" " + @"inner join tflCaseFiltered f on f.idfCase = fn_VetCase_SelectList.idfCase and f.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString());
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("strFieldBarcode"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strFieldBarcode") == 1)
                    {
                        sql.AppendFormat("ISNULL(m.strFieldBarcode,N'') {0} @strFieldBarcode", filters.Operation("strFieldBarcode"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strFieldBarcode"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strFieldBarcode") ? " or " : " and ");
                            sql.AppendFormat("ISNULL(m.strFieldBarcode,N'') {0} @strFieldBarcode_{1}", filters.Operation("strFieldBarcode", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsDiagnosis") == 1)
                    {
                        sql.AppendFormat("(@finalDiagnosisOnly = 1 AND idfsFinalDiagnosis = @idfsDiagnosis) OR (@finalDiagnosisOnly = 0 AND (idfsTentativeDiagnosis = @idfsDiagnosis OR idfsTentativeDiagnosis1 = @idfsDiagnosis OR idfsTentativeDiagnosis2 = @idfsDiagnosis OR idfsFinalDiagnosis = @idfsDiagnosis))", filters.Operation("idfsDiagnosis"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsDiagnosis") ? " or " : " and ");
                            sql.AppendFormat("(@finalDiagnosisOnly = 1 AND idfsFinalDiagnosis = @idfsDiagnosis_{1}) OR (@finalDiagnosisOnly = 0 AND (idfsTentativeDiagnosis = @idfsDiagnosis OR idfsTentativeDiagnosis1 = @idfsDiagnosis OR idfsTentativeDiagnosis2 = @idfsDiagnosis OR idfsFinalDiagnosis = @idfsDiagnosis))", filters.Operation("idfsDiagnosis", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("finalDiagnosisOnly"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("finalDiagnosisOnly") == 1)
                    {
                        sql.AppendFormat("1=1", filters.Operation("finalDiagnosisOnly"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("finalDiagnosisOnly"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("finalDiagnosisOnly") ? " or " : " and ");
                            sql.AppendFormat("@finalDiagnosisOnly_{1}", filters.Operation("finalDiagnosisOnly", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfPerson"))
                    sql.AppendFormat(" and " + new Func<string>(() =>  (String.IsNullOrEmpty(EidssUserContext.User.EmployeeID.ToString())) ? "@idfPerson = 0" : String.Format("(@idfPerson = 0 OR person.idfPerson = {0})",EidssUserContext.User.EmployeeID.ToString()))());
                            
                if (filters.Contains("idfsSpeciesType"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsSpeciesType") == 1)
                    {
                        sql.AppendFormat("s.idfsSpeciesType {0} @idfsSpeciesType", filters.Operation("idfsSpeciesType"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsSpeciesType"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsSpeciesType") ? " or " : " and ");
                            sql.AppendFormat("s.idfsSpeciesType {0} @idfsSpeciesType_{1}", filters.Operation("idfsSpeciesType", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsAnimalAge"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsAnimalAge") == 1)
                    {
                        sql.AppendFormat("a.idfsAnimalAge {0} @idfsAnimalAge", filters.Operation("idfsAnimalAge"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsAnimalAge"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsAnimalAge") ? " or " : " and ");
                            sql.AppendFormat("a.idfsAnimalAge {0} @idfsAnimalAge_{1}", filters.Operation("idfsAnimalAge", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsAnimalGender"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsAnimalGender") == 1)
                    {
                        sql.AppendFormat("a.idfsAnimalGender {0} @idfsAnimalGender", filters.Operation("idfsAnimalGender"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsAnimalGender"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsAnimalGender") ? " or " : " and ");
                            sql.AppendFormat("a.idfsAnimalGender {0} @idfsAnimalGender_{1}", filters.Operation("idfsAnimalGender", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfsAnimalCondition"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsAnimalCondition") == 1)
                    {
                        sql.AppendFormat("a.idfsAnimalCondition {0} @idfsAnimalCondition", filters.Operation("idfsAnimalCondition"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsAnimalCondition"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsAnimalCondition") ? " or " : " and ");
                            sql.AppendFormat("a.idfsAnimalCondition {0} @idfsAnimalCondition_{1}", filters.Operation("idfsAnimalCondition", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strAnimalCode"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strAnimalCode") == 1)
                    {
                        sql.AppendFormat("ISNULL(a.strAnimalCode,N'') {0} @strAnimalCode", filters.Operation("strAnimalCode"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strAnimalCode"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strAnimalCode") ? " or " : " and ");
                            sql.AppendFormat("ISNULL(a.strAnimalCode,N'') {0} @strAnimalCode_{1}", filters.Operation("strAnimalCode", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfCase"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfCase"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfCase") ? " or " : " and ");
                        
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
                  
                if (filters.Contains("idfsTentativeDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTentativeDiagnosis"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTentativeDiagnosis") ? " or " : " and ");
                        
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
                        
                        sql.AppendFormat("isnull(fn_VetCase_SelectList.idfPersonEnteredBy,0) {0} @idfPersonEnteredBy_{1}", filters.Operation("idfPersonEnteredBy", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCaseStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCaseStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCaseStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsCaseStatus,0) {0} @idfsCaseStatus_{1}", filters.Operation("idfsCaseStatus", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_VetCase_SelectList.idfsCaseTypeNullable,0) {0} @idfsCaseTypeNullable_{1}", filters.Operation("idfsCaseTypeNullable", i), i);
                            
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
                  
                if (filters.Contains("idfGeoLocation"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfGeoLocation"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfGeoLocation") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_VetCase_SelectList.idfGeoLocation,0) {0} @idfGeoLocation_{1}", filters.Operation("idfGeoLocation", i), i);
                            
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
                        
                        sql.AppendFormat("isnull(fn_VetCase_SelectList.intDeadAnimalQty,0) {0} @intDeadAnimalQty_{1}", filters.Operation("intDeadAnimalQty", i), i);
                            
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
                            
                    if (filters.Contains("finalDiagnosisOnly"))
                        
                        if (filters.Count("finalDiagnosisOnly") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@finalDiagnosisOnly", ParsingHelper.CorrectLikeValue(filters.Operation("finalDiagnosisOnly"), filters.Value("finalDiagnosisOnly"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("finalDiagnosisOnly"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@finalDiagnosisOnly_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("finalDiagnosisOnly", i), filters.Value("finalDiagnosisOnly", i))));
                        }
                            
                    if (filters.Contains("strFieldBarcode"))
                        
                        if (filters.Count("strFieldBarcode") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFieldBarcode", ParsingHelper.CorrectLikeValue(filters.Operation("strFieldBarcode"), filters.Value("strFieldBarcode"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strFieldBarcode"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFieldBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFieldBarcode", i), filters.Value("strFieldBarcode", i))));
                        }
                            
                    if (filters.Contains("strAnimalCode"))
                        
                        if (filters.Count("strAnimalCode") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strAnimalCode", ParsingHelper.CorrectLikeValue(filters.Operation("strAnimalCode"), filters.Value("strAnimalCode"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strAnimalCode"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strAnimalCode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strAnimalCode", i), filters.Value("strAnimalCode", i))));
                        }
                            
                    if (filters.Contains("idfsAnimalAge"))
                        
                        if (filters.Count("idfsAnimalAge") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAnimalAge", ParsingHelper.CorrectLikeValue(filters.Operation("idfsAnimalAge"), filters.Value("idfsAnimalAge"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsAnimalAge"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAnimalAge_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsAnimalAge", i), filters.Value("idfsAnimalAge", i))));
                        }
                            
                    if (filters.Contains("idfsAnimalGender"))
                        
                        if (filters.Count("idfsAnimalGender") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAnimalGender", ParsingHelper.CorrectLikeValue(filters.Operation("idfsAnimalGender"), filters.Value("idfsAnimalGender"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsAnimalGender"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAnimalGender_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsAnimalGender", i), filters.Value("idfsAnimalGender", i))));
                        }
                            
                    if (filters.Contains("idfsAnimalCondition"))
                        
                        if (filters.Count("idfsAnimalCondition") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAnimalCondition", ParsingHelper.CorrectLikeValue(filters.Operation("idfsAnimalCondition"), filters.Value("idfsAnimalCondition"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsAnimalCondition"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAnimalCondition_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsAnimalCondition", i), filters.Value("idfsAnimalCondition", i))));
                        }
                            
                    if (filters.Contains("idfsSpeciesType"))
                        
                        if (filters.Count("idfsSpeciesType") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSpeciesType", ParsingHelper.CorrectLikeValue(filters.Operation("idfsSpeciesType"), filters.Value("idfsSpeciesType"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsSpeciesType"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSpeciesType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSpeciesType", i), filters.Value("idfsSpeciesType", i))));
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
                      
                    if (filters.Contains("idfsCaseStatus"))
                        for (int i = 0; i < filters.Count("idfsCaseStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseStatus", i), filters.Value("idfsCaseStatus", i))));
                      
                    if (filters.Contains("idfsCaseProgressStatus"))
                        for (int i = 0; i < filters.Count("idfsCaseProgressStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseProgressStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseProgressStatus", i), filters.Value("idfsCaseProgressStatus", i))));
                      
                    if (filters.Contains("idfsCaseReportType"))
                        for (int i = 0; i < filters.Count("idfsCaseReportType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseReportType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseReportType", i), filters.Value("idfsCaseReportType", i))));
                      
                    if (filters.Contains("strCaseReportType"))
                        for (int i = 0; i < filters.Count("strCaseReportType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCaseReportType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCaseReportType", i), filters.Value("strCaseReportType", i))));
                      
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
                      
                    if (filters.Contains("idfGeoLocation"))
                        for (int i = 0; i < filters.Count("idfGeoLocation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfGeoLocation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfGeoLocation", i), filters.Value("idfGeoLocation", i))));
                      
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
                      
                    List<VetCaseListItem> objs = manager.ExecuteList<VetCaseListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                    }
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
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spVetCase_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, VetCaseListItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, VetCaseListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private VetCaseListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    VetCaseListItem obj = VetCaseListItem.CreateInstance();
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
                obj.Country = new Func<VetCaseListItem, CountryLookup>(c => 
                                     c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
                                     .SingleOrDefault())(obj);
                obj.Region = new Func<VetCaseListItem, RegionLookup>(c => 
                                     c.RegionLookup.Where(a => a.idfsRegion == eidss.model.Core.EidssSiteContext.Instance.RegionID)
                                     .SingleOrDefault())(obj);
                obj.CaseReportType = new Func<VetCaseListItem, BaseReference>(c => 
                                     c.CaseReportTypeLookup.Where(a => a.idfsBaseReference == (long)eidss.model.Enums.CaseReportType.Passive)
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

            
            public VetCaseListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public VetCaseListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult CreateLivestock(DbManagerProxy manager, VetCaseListItem obj, List<object> pars)
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
            public ActResult CreateLivestock(DbManagerProxy manager, VetCaseListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("CreateLivestock"))
                    throw new PermissionException("VetCase", "CreateLivestock");
                
              return new ActResult(true, ObjectAccessor.CreatorInterface<VetCase>().CreateNew(manager, null, (int)HACode.Livestock));
            
            }
            
            public ActResult CreateAvian(DbManagerProxy manager, VetCaseListItem obj, List<object> pars)
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
            public ActResult CreateAvian(DbManagerProxy manager, VetCaseListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("CreateAvian"))
                    throw new PermissionException("VetCase", "CreateAvian");
                
                return true;
                
            }
            
            public ActResult ActionEditVetCase(DbManagerProxy manager, VetCaseListItem obj, List<object> pars)
            {
                
                return ActionEditVetCase(manager, obj
                    );
            }
            public ActResult ActionEditVetCase(DbManagerProxy manager, VetCaseListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ActionEditVetCase"))
                    throw new PermissionException("VetCase", "ActionEditVetCase");
                
                return true;
                
            }
            
            private void _SetupChildHandlers(VetCaseListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VetCaseListItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.Region = new Func<VetCaseListItem, RegionLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.Rayon = new Func<VetCaseListItem, RayonLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                obj.Settlement = new Func<VetCaseListItem, SettlementLookup>(c => null)(obj);
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
    
            public void LoadLookup_Country(DbManagerProxy manager, VetCaseListItem obj)
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
            
            public void LoadLookup_Region(DbManagerProxy manager, VetCaseListItem obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<VetCaseListItem, long>(c => c.idfsCountry ?? 0)(obj)
                            
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
            
            public void LoadLookup_Rayon(DbManagerProxy manager, VetCaseListItem obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<VetCaseListItem, long>(c => c.idfsRegion ?? 0)(obj)
                            
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
            
            public void LoadLookup_Settlement(DbManagerProxy manager, VetCaseListItem obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<VetCaseListItem, long>(c => c.idfsRayon ?? 0)(obj)
                            
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
            
            public void LoadLookup_CaseProgressStatus(DbManagerProxy manager, VetCaseListItem obj)
            {
                
                obj.CaseProgressStatusLookup.Clear();
                
                obj.CaseProgressStatusLookup.Add(CaseProgressStatusAccessor.CreateNewT(manager, null));
                
                obj.CaseProgressStatusLookup.AddRange(CaseProgressStatusAccessor.rftCaseProgressStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCaseProgressStatus))
                    
                    .ToList());
                
                if (obj.idfsCaseProgressStatus != null && obj.idfsCaseProgressStatus != 0)
                {
                    obj.CaseProgressStatus = obj.CaseProgressStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsCaseProgressStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCaseProgressStatus", obj, CaseProgressStatusAccessor.GetType(), "rftCaseProgressStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Diagnosis(DbManagerProxy manager, VetCaseListItem obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => !EidssUserContext.User.DenyDiagnosis.ContainsKey(c.idfsDiagnosis))
                        
                    .Where(c => ((c.intHACode & (int)HACode.LivestockAvian) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != null && obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .Where(c => c.idfsDiagnosis == obj.idfsDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_CaseStatus(DbManagerProxy manager, VetCaseListItem obj)
            {
                
                obj.CaseStatusLookup.Clear();
                
                obj.CaseStatusLookup.Add(CaseStatusAccessor.CreateNewT(manager, null));
                
                obj.CaseStatusLookup.AddRange(CaseStatusAccessor.rftCaseStatus_SelectList(manager
                    
                    )
                    .Where(c => c.intHACode.GetValueOrDefault() == 98)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCaseStatus))
                    
                    .ToList());
                
                if (obj.idfsCaseStatus != null && obj.idfsCaseStatus != 0)
                {
                    obj.CaseStatus = obj.CaseStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsCaseStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCaseStatus", obj, CaseStatusAccessor.GetType(), "rftCaseStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_CaseType(DbManagerProxy manager, VetCaseListItem obj)
            {
                
                obj.CaseTypeLookup.Clear();
                
                obj.CaseTypeLookup.Add(CaseTypeAccessor.CreateNewT(manager, null));
                
                obj.CaseTypeLookup.AddRange(CaseTypeAccessor.rftCaseType_SelectList(manager
                    
                    )
                    .Where(c => c.idfsBaseReference == (long)CaseTypeEnum.Livestock || c.idfsBaseReference == (long)CaseTypeEnum.Avian)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCaseTypeNullable))
                    
                    .ToList());
                
                if (obj.idfsCaseTypeNullable != null && obj.idfsCaseTypeNullable != 0)
                {
                    obj.CaseType = obj.CaseTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsCaseTypeNullable)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCaseType", obj, CaseTypeAccessor.GetType(), "rftCaseType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_CaseReportType(DbManagerProxy manager, VetCaseListItem obj)
            {
                
                obj.CaseReportTypeLookup.Clear();
                
                obj.CaseReportTypeLookup.Add(CaseReportTypeAccessor.CreateNewT(manager, null));
                
                obj.CaseReportTypeLookup.AddRange(CaseReportTypeAccessor.rftCaseReportType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCaseReportType))
                    
                    .ToList());
                
                if (obj.idfsCaseReportType != 0)
                {
                    obj.CaseReportType = obj.CaseReportTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsCaseReportType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCaseReportType", obj, CaseReportTypeAccessor.GetType(), "rftCaseReportType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_AnimalAge(DbManagerProxy manager, VetCaseListItem obj)
            {
                
                obj.AnimalAgeLookup.Clear();
                
                obj.AnimalAgeLookup.Add(AnimalAgeAccessor.CreateNewT(manager, null));
                
                obj.AnimalAgeLookup.AddRange(AnimalAgeAccessor.rftAnimalAgeList_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAnimalAge))
                    
                    .ToList());
                
                if (obj.idfsAnimalAge != null && obj.idfsAnimalAge != 0)
                {
                    obj.AnimalAge = obj.AnimalAgeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsAnimalAge)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftAnimalAgeList", obj, AnimalAgeAccessor.GetType(), "rftAnimalAgeList_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_AnimalGender(DbManagerProxy manager, VetCaseListItem obj)
            {
                
                obj.AnimalGenderLookup.Clear();
                
                obj.AnimalGenderLookup.Add(AnimalGenderAccessor.CreateNewT(manager, null));
                
                obj.AnimalGenderLookup.AddRange(AnimalGenderAccessor.rftAnimalGenderList_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAnimalGender))
                    
                    .ToList());
                
                if (obj.idfsAnimalGender != null && obj.idfsAnimalGender != 0)
                {
                    obj.AnimalGender = obj.AnimalGenderLookup
                        .Where(c => c.idfsBaseReference == obj.idfsAnimalGender)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftAnimalGenderList", obj, AnimalGenderAccessor.GetType(), "rftAnimalGenderList_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_AnimalCondition(DbManagerProxy manager, VetCaseListItem obj)
            {
                
                obj.AnimalConditionLookup.Clear();
                
                obj.AnimalConditionLookup.Add(AnimalConditionAccessor.CreateNewT(manager, null));
                
                obj.AnimalConditionLookup.AddRange(AnimalConditionAccessor.rftAnimalCondition_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAnimalCondition))
                    
                    .ToList());
                
                if (obj.idfsAnimalCondition != null && obj.idfsAnimalCondition != 0)
                {
                    obj.AnimalCondition = obj.AnimalConditionLookup
                        .Where(c => c.idfsBaseReference == obj.idfsAnimalCondition)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftAnimalCondition", obj, AnimalConditionAccessor.GetType(), "rftAnimalCondition_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_SpeciesType(DbManagerProxy manager, VetCaseListItem obj)
            {
                
                obj.SpeciesTypeLookup.Clear();
                
                obj.SpeciesTypeLookup.Add(SpeciesTypeAccessor.CreateNewT(manager, null));
                
                obj.SpeciesTypeLookup.AddRange(SpeciesTypeAccessor.rftSpeciesList_SelectList(manager
                    
                    )
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
            
            public void LoadLookup_OwnershipStructure(DbManagerProxy manager, VetCaseListItem obj)
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
            
            public void LoadLookup_LivestockProductionType(DbManagerProxy manager, VetCaseListItem obj)
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
            
            public void LoadLookup_MovementPattern(DbManagerProxy manager, VetCaseListItem obj)
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
            
            public void LoadLookup_GrazingPattern(DbManagerProxy manager, VetCaseListItem obj)
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
            
            public void LoadLookup_AvianFarmProductionType(DbManagerProxy manager, VetCaseListItem obj)
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
            
            public void LoadLookup_AvianFarmType(DbManagerProxy manager, VetCaseListItem obj)
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
            
            public void LoadLookup_FarmIntendedUse(DbManagerProxy manager, VetCaseListItem obj)
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
            

            private void _LoadLookups(DbManagerProxy manager, VetCaseListItem obj)
            {
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
                LoadLookup_CaseProgressStatus(manager, obj);
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_CaseStatus(manager, obj);
                
                LoadLookup_CaseType(manager, obj);
                
                LoadLookup_CaseReportType(manager, obj);
                
                LoadLookup_AnimalAge(manager, obj);
                
                LoadLookup_AnimalGender(manager, obj);
                
                LoadLookup_AnimalCondition(manager, obj);
                
                LoadLookup_SpeciesType(manager, obj);
                
                LoadLookup_OwnershipStructure(manager, obj);
                
                LoadLookup_LivestockProductionType(manager, obj);
                
                LoadLookup_MovementPattern(manager, obj);
                
                LoadLookup_GrazingPattern(manager, obj);
                
                LoadLookup_AvianFarmProductionType(manager, obj);
                
                LoadLookup_AvianFarmType(manager, obj);
                
                LoadLookup_FarmIntendedUse(manager, obj);
                
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
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    VetCaseListItem bo = obj as VetCaseListItem;
                    
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
                        
                        long mainObject = bo.idfCase;
                        
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
                    bSuccess = _PostNonTransaction(manager, obj as VetCaseListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VetCaseListItem obj, bool bChildObject) 
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
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(VetCaseListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VetCaseListItem obj)
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
                return Validate(manager, obj as VetCaseListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VetCaseListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
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
            
            private void _SetupRequired(VetCaseListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(VetCaseListItem obj)
    {
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement))
      {
      
            obj
              .AddHiddenPersonalData("strOwnerLastName", c=>true);
            
            obj
              .AddHiddenPersonalData("strOwnerFirstName", c=>true);
            
            obj
              .AddHiddenPersonalData("strOwnerMiddleName", c=>true);
            
            obj
              .AddHiddenPersonalData("strFarmCode", c=>true);
            
            obj
              .AddHiddenPersonalData("FarmName", c=>true);
            
            obj
              .AddHiddenPersonalData("strContactPhone", c=>true);
            
            obj
              .AddHiddenPersonalData("strFax", c=>true);
            
            obj
              .AddHiddenPersonalData("strEmail", c=>true);
            
            obj
              .AddHiddenPersonalData("AddressName", c=>true);
            
            obj
              .AddHiddenPersonalData("Settlement", c=>true);
            
            obj
              .AddHiddenPersonalData("idfsSettlement", c=>true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details))
      {
      
            obj
              .AddHiddenPersonalData("strOwnerLastName", c=>true);
            
            obj
              .AddHiddenPersonalData("strOwnerFirstName", c=>true);
            
            obj
              .AddHiddenPersonalData("strOwnerMiddleName", c=>true);
            
            obj
              .AddHiddenPersonalData("strFarmCode", c=>true);
            
            obj
              .AddHiddenPersonalData("FarmName", c=>true);
            
            obj
              .AddHiddenPersonalData("strContactPhone", c=>true);
            
            obj
              .AddHiddenPersonalData("strFax", c=>true);
            
            obj
              .AddHiddenPersonalData("strEmail", c=>true);
            
            obj
              .AddHiddenPersonalData("AddressName", c=>true);
            
      }
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VetCaseListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VetCaseListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VetCaseListItemDetail"; } }
            public string HelpIdWin { get { return "VetCaseListForm"; } }
            public string HelpIdWeb { get { return "web_vetcaselistform"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private VetCaseListItem m_obj;
            internal Permissions(VetCaseListItem obj)
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
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VetCaseListItem, bool>> RequiredByField = new Dictionary<string, Func<VetCaseListItem, bool>>();
            public static Dictionary<string, Func<VetCaseListItem, bool>> RequiredByProperty = new Dictionary<string, Func<VetCaseListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strCaseID, 200);
                Sizes.Add(_str_strCaseReportType, 2000);
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
                    false, false, 
                    "lblMyCases",
                    null, null, false, false, SearchPanelLocation.Main, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCaseID",
                    EditorType.Text,
                    false, false, 
                    "strCaseID",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosis",
                    EditorType.Lookup,
                    false, false, 
                    "idfsDiagnosis",
                    null, null, false, false, SearchPanelLocation.Main, true, "finalDiagnosisOnly", "DiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "finalDiagnosisOnly",
                    EditorType.Flag,
                    false, false, 
                    "ReturnOnlyFinalDiagnosis",
                    () => false, null, false, false, SearchPanelLocation.Main, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCaseStatus",
                    EditorType.Lookup,
                    false, false, 
                    "idfsCaseStatus",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "CaseStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCaseProgressStatus",
                    EditorType.Lookup,
                    false, false, 
                    "idfsCaseProgressStatus",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "CaseProgressStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCaseReportType",
                    EditorType.Lookup,
                    false, false, 
                    "idfsCaseReportType",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "CaseReportTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCaseTypeNullable",
                    EditorType.Lookup,
                    false, false, 
                    "idfsCaseType",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "CaseTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datEnteredDate",
                    EditorType.Date,
                    true, true, 
                    "datEnteredDateSearchPanel",
                    () => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, true, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datInvestigationDate",
                    EditorType.Date,
                    true, false, 
                    "datInvestigationDate",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFieldBarcode",
                    EditorType.Text,
                    false, false, 
                    "VetCaseList.strFieldBarCode",
                    null, null, false, false, SearchPanelLocation.Main, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "intTotalAnimalQty",
                    EditorType.Numeric,
                    true, false, 
                    "intTotalAnimalQtyFull",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strOwnerFirstName",
                    EditorType.Text,
                    false, false, 
                    "OwnerFirstName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strOwnerLastName",
                    EditorType.Text,
                    false, false, 
                    "OwnerLastName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRegion",
                    EditorType.Lookup,
                    false, false, 
                    "idfsRegion",
                    null, "=", false, false, SearchPanelLocation.Main, false, "idfsRayon", "RegionLookup", typeof(RegionLookup), (o) => { var c = (RegionLookup)o; return c.idfsRegion; }, (o) => { var c = (RegionLookup)o; return c.strRegionName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRayon",
                    EditorType.Lookup,
                    false, false, 
                    "idfsRayon",
                    null, null, false, false, SearchPanelLocation.Main, false, "idfsSettlement", "RayonLookup", typeof(RayonLookup), (o) => { var c = (RayonLookup)o; return c.idfsRayon; }, (o) => { var c = (RayonLookup)o; return c.strRayonName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSettlement",
                    EditorType.Lookup,
                    false, false, 
                    "strTownOrVillage",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "SettlementLookup", typeof(SettlementLookup), (o) => { var c = (SettlementLookup)o; return c.idfsSettlement; }, (o) => { var c = (SettlementLookup)o; return c.strSettlementName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strAnimalCode",
                    EditorType.Text,
                    false, false, 
                    "strAnimalCode",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsAnimalAge",
                    EditorType.Lookup,
                    false, false, 
                    "AnimalAge",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, "AnimalAgeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsAnimalGender",
                    EditorType.Lookup,
                    false, false, 
                    "AnimalSex",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, "AnimalGenderLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsAnimalCondition",
                    EditorType.Lookup,
                    false, false, 
                    "AnimalCondition",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, "AnimalConditionLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSpeciesType",
                    EditorType.Lookup,
                    false, false, 
                    "idfsSpeciesType",
                    null, "=", false, false, SearchPanelLocation.Combobox, true, null, "SpeciesTypeLookup", typeof(SpeciesTypeLookup), (o) => { var c = (SpeciesTypeLookup)o; return c.idfsBaseReference; }, (o) => { var c = (SpeciesTypeLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsOwnershipStructure",
                    EditorType.Lookup,
                    false, false, 
                    "idfsOwnershipStructure",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, "OwnershipStructureLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsLivestockProductionType",
                    EditorType.Lookup,
                    false, false, 
                    "LivestockProductionType",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, "LivestockProductionTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsMovementPattern",
                    EditorType.Lookup,
                    false, false, 
                    "idfsMovementPattern",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, "MovementPatternLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsGrazingPattern",
                    EditorType.Lookup,
                    false, false, 
                    "idfsGrazingPattern",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, "GrazingPatternLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsAvianProductionType",
                    EditorType.Lookup,
                    false, false, 
                    "AvianProductionType",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, "AvianFarmProductionTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsAvianFarmType",
                    EditorType.Lookup,
                    false, false, 
                    "AvianFarmType",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, "AvianFarmTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsIntendedUse",
                    EditorType.Lookup,
                    false, false, 
                    "idfsIntendedUse",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, "FarmIntendedUseLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFarmCode",
                    EditorType.Text,
                    false, false, 
                    "strFarmCode",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "FarmName",
                    EditorType.Text,
                    false, false, 
                    "strFarmFullName",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strOwnerMiddleName",
                    EditorType.Text,
                    false, false, 
                    "OwnerMiddleName",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strContactPhone",
                    EditorType.Text,
                    false, false, 
                    "ContactPhone",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFax",
                    EditorType.Text,
                    false, false, 
                    "strFax",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strEmail",
                    EditorType.Text,
                    false, false, 
                    "strEmail",
                    null, "=", false, false, SearchPanelLocation.Combobox, false, null, null, null, null, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfCase,
                    _str_idfCase, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseID,
                    _str_strCaseID, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datEnteredDate,
                    "datEnteredDateSearchPanel", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datInvestigationDate,
                    _str_datInvestigationDate, null, true, true, ListSortDirection.Ascending
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_DiagnosisName,
                    "strDiagnoses", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AddressName,
                    "FarmAddress", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strOwnerLastName,
                    "strOwnerName", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intTotalAnimalQty,
                    "intTotalAnimalQtyFull", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseType,
                    "idfsCaseType", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_CaseClassificationName,
                    "idfsCaseClassificationShort", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_CaseStatusName,
                    "idfsCaseStatusShort", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseReportType,
                    "idfsCaseReportType", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsRegion,
                    _str_idfsRegion, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsRayon,
                    _str_idfsRayon, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsSettlement,
                    _str_idfsSettlement, null, false, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "CreateLivestock",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).CreateLivestock(manager, (VetCaseListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreateLivestock_Id",
                        "Livestock_Case__small_",
                        /*from BvMessages*/"strCreateLivestock_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    "VetCase.Insert",
                    null,
                    null,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "CreateAvian",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).CreateAvian(manager, (VetCaseListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreateAvian_Id",
                        "Avian_Case__small_",
                        /*from BvMessages*/"strCreateAvian_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    "VetCase.Insert",
                    null,
                    null,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "ActionEditVetCase",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionEditVetCase(manager, (VetCaseListItem)c, pars),
                        
                    null,
                    
                    null,
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false
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
                                c = ObjectAccessor.CreatorInterface<VetCaseListItem>().CreateWithParams(manager, null, pars);
                                ((VetCaseListItem)c).idfCase = (long)pars[0];
                                ((VetCaseListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((VetCaseListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<VetCaseListItem>().Post(manager, (VetCaseListItem)c), c);
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	