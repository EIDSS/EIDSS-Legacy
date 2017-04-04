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
    public abstract partial class VetCase : 
        EditableObject<VetCase>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCase { get; set; }
                
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
                
        [LocalizedDisplayName(_str_idfsShowDiagnosis)]
        [MapField(_str_idfsShowDiagnosis)]
        public abstract Int64? idfsShowDiagnosis { get; set; }
        protected Int64? idfsShowDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsShowDiagnosis).OriginalValue; } }
        protected Int64? idfsShowDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsShowDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64 idfsCaseType { get; set; }
        protected Int64 idfsCaseType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64 idfsCaseType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfOutbreak)]
        [MapField(_str_idfOutbreak)]
        public abstract Int64? idfOutbreak { get; set; }
        protected Int64? idfOutbreak_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOutbreak).OriginalValue; } }
        protected Int64? idfOutbreak_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOutbreak).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOutbreakID)]
        [MapField(_str_strOutbreakID)]
        public abstract String strOutbreakID { get; set; }
        protected String strOutbreakID_Original { get { return ((EditableValue<String>)((dynamic)this)._strOutbreakID).OriginalValue; } }
        protected String strOutbreakID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOutbreakID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfParentMonitoringSession)]
        [MapField(_str_idfParentMonitoringSession)]
        public abstract Int64? idfParentMonitoringSession { get; set; }
        protected Int64? idfParentMonitoringSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentMonitoringSession).OriginalValue; } }
        protected Int64? idfParentMonitoringSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentMonitoringSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strMonitoringSessionID)]
        [MapField(_str_strMonitoringSessionID)]
        public abstract String strMonitoringSessionID { get; set; }
        protected String strMonitoringSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).OriginalValue; } }
        protected String strMonitoringSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datEnteredDate)]
        [MapField(_str_datEnteredDate)]
        public abstract DateTime? datEnteredDate { get; set; }
        protected DateTime? datEnteredDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).OriginalValue; } }
        protected DateTime? datEnteredDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_uidOfflineCaseID)]
        [MapField(_str_uidOfflineCaseID)]
        public abstract Guid? uidOfflineCaseID { get; set; }
        protected Guid? uidOfflineCaseID_Original { get { return ((EditableValue<Guid?>)((dynamic)this)._uidOfflineCaseID).OriginalValue; } }
        protected Guid? uidOfflineCaseID_Previous { get { return ((EditableValue<Guid?>)((dynamic)this)._uidOfflineCaseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCaseID)]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
                
        [LocalizedDisplayName("VetCase.TentativeDiagnosis1")]
        [MapField(_str_idfsTentativeDiagnosis)]
        public abstract Int64? idfsTentativeDiagnosis { get; set; }
        protected Int64? idfsTentativeDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName("VetCase.TentativeDiagnosis2")]
        [MapField(_str_idfsTentativeDiagnosis1)]
        public abstract Int64? idfsTentativeDiagnosis1 { get; set; }
        protected Int64? idfsTentativeDiagnosis1_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis1).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis1_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis1).PreviousValue; } }
                
        [LocalizedDisplayName("VetCase.TentativeDiagnosis3")]
        [MapField(_str_idfsTentativeDiagnosis2)]
        public abstract Int64? idfsTentativeDiagnosis2 { get; set; }
        protected Int64? idfsTentativeDiagnosis2_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis2).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis2_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis2).PreviousValue; } }
                
        [LocalizedDisplayName("VetCase.FinalDiagnogis")]
        [MapField(_str_idfsFinalDiagnosis)]
        public abstract Int64? idfsFinalDiagnosis { get; set; }
        protected Int64? idfsFinalDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalDiagnosis).OriginalValue; } }
        protected Int64? idfsFinalDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsYNTestsConducted)]
        [MapField(_str_idfsYNTestsConducted)]
        public abstract Int64? idfsYNTestsConducted { get; set; }
        protected Int64? idfsYNTestsConducted_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNTestsConducted).OriginalValue; } }
        protected Int64? idfsYNTestsConducted_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNTestsConducted).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnEnableTestsConducted)]
        [MapField(_str_blnEnableTestsConducted)]
        public abstract Boolean? blnEnableTestsConducted { get; set; }
        protected Boolean? blnEnableTestsConducted_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnEnableTestsConducted).OriginalValue; } }
        protected Boolean? blnEnableTestsConducted_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnEnableTestsConducted).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfInvestigatedByOffice)]
        [MapField(_str_idfInvestigatedByOffice)]
        public abstract Int64? idfInvestigatedByOffice { get; set; }
        protected Int64? idfInvestigatedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInvestigatedByOffice).OriginalValue; } }
        protected Int64? idfInvestigatedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInvestigatedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strInvestigatedByOffice)]
        [MapField(_str_strInvestigatedByOffice)]
        public abstract String strInvestigatedByOffice { get; set; }
        protected String strInvestigatedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strInvestigatedByOffice).OriginalValue; } }
        protected String strInvestigatedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strInvestigatedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPersonInvestigatedBy)]
        [MapField(_str_idfPersonInvestigatedBy)]
        public abstract Int64? idfPersonInvestigatedBy { get; set; }
        protected Int64? idfPersonInvestigatedBy_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonInvestigatedBy).OriginalValue; } }
        protected Int64? idfPersonInvestigatedBy_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonInvestigatedBy).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPersonInvestigatedBy)]
        [MapField(_str_strPersonInvestigatedBy)]
        public abstract String strPersonInvestigatedBy { get; set; }
        protected String strPersonInvestigatedBy_Original { get { return ((EditableValue<String>)((dynamic)this)._strPersonInvestigatedBy).OriginalValue; } }
        protected String strPersonInvestigatedBy_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPersonInvestigatedBy).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPersonEnteredBy)]
        [MapField(_str_idfPersonEnteredBy)]
        public abstract Int64? idfPersonEnteredBy { get; set; }
        protected Int64? idfPersonEnteredBy_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonEnteredBy).OriginalValue; } }
        protected Int64? idfPersonEnteredBy_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonEnteredBy).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPersonEnteredByName)]
        [MapField(_str_strPersonEnteredByName)]
        public abstract String strPersonEnteredByName { get; set; }
        protected String strPersonEnteredByName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPersonEnteredByName).OriginalValue; } }
        protected String strPersonEnteredByName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPersonEnteredByName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfReportedByOffice)]
        [MapField(_str_idfReportedByOffice)]
        public abstract Int64? idfReportedByOffice { get; set; }
        protected Int64? idfReportedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfReportedByOffice).OriginalValue; } }
        protected Int64? idfReportedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfReportedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strReportedByOffice)]
        [MapField(_str_strReportedByOffice)]
        public abstract String strReportedByOffice { get; set; }
        protected String strReportedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strReportedByOffice).OriginalValue; } }
        protected String strReportedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReportedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPersonReportedBy)]
        [MapField(_str_idfPersonReportedBy)]
        public abstract Int64? idfPersonReportedBy { get; set; }
        protected Int64? idfPersonReportedBy_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonReportedBy).OriginalValue; } }
        protected Int64? idfPersonReportedBy_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonReportedBy).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPersonReportedBy)]
        [MapField(_str_strPersonReportedBy)]
        public abstract String strPersonReportedBy { get; set; }
        protected String strPersonReportedBy_Original { get { return ((EditableValue<String>)((dynamic)this)._strPersonReportedBy).OriginalValue; } }
        protected String strPersonReportedBy_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPersonReportedBy).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64 idfsSite { get; set; }
        protected Int64 idfsSite_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64 idfsSite_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).PreviousValue; } }
                
        [LocalizedDisplayName("datInitialReportDate")]
        [MapField(_str_datReportDate)]
        public abstract DateTime? datReportDate { get; set; }
        protected DateTime? datReportDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReportDate).OriginalValue; } }
        protected DateTime? datReportDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReportDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datAssignedDate)]
        [MapField(_str_datAssignedDate)]
        public abstract DateTime? datAssignedDate { get; set; }
        protected DateTime? datAssignedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAssignedDate).OriginalValue; } }
        protected DateTime? datAssignedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAssignedDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datInvestigationDate)]
        [MapField(_str_datInvestigationDate)]
        public abstract DateTime? datInvestigationDate { get; set; }
        protected DateTime? datInvestigationDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datInvestigationDate).OriginalValue; } }
        protected DateTime? datInvestigationDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datInvestigationDate).PreviousValue; } }
                
        [LocalizedDisplayName("datTentativeDiagnosisDateLbl")]
        [MapField(_str_datTentativeDiagnosisDate)]
        public abstract DateTime? datTentativeDiagnosisDate { get; set; }
        protected DateTime? datTentativeDiagnosisDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTentativeDiagnosisDate).OriginalValue; } }
        protected DateTime? datTentativeDiagnosisDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTentativeDiagnosisDate).PreviousValue; } }
                
        [LocalizedDisplayName("datTentativeDiagnosis1DateLbl")]
        [MapField(_str_datTentativeDiagnosis1Date)]
        public abstract DateTime? datTentativeDiagnosis1Date { get; set; }
        protected DateTime? datTentativeDiagnosis1Date_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTentativeDiagnosis1Date).OriginalValue; } }
        protected DateTime? datTentativeDiagnosis1Date_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTentativeDiagnosis1Date).PreviousValue; } }
                
        [LocalizedDisplayName("datTentativeDiagnosis2DateLbl")]
        [MapField(_str_datTentativeDiagnosis2Date)]
        public abstract DateTime? datTentativeDiagnosis2Date { get; set; }
        protected DateTime? datTentativeDiagnosis2Date_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTentativeDiagnosis2Date).OriginalValue; } }
        protected DateTime? datTentativeDiagnosis2Date_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTentativeDiagnosis2Date).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFinalDiagnosisDate)]
        [MapField(_str_datFinalDiagnosisDate)]
        public abstract DateTime? datFinalDiagnosisDate { get; set; }
        protected DateTime? datFinalDiagnosisDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFinalDiagnosisDate).OriginalValue; } }
        protected DateTime? datFinalDiagnosisDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFinalDiagnosisDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseReportType)]
        [MapField(_str_idfsCaseReportType)]
        public abstract Int64? idfsCaseReportType { get; set; }
        protected Int64? idfsCaseReportType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseReportType).OriginalValue; } }
        protected Int64? idfsCaseReportType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseReportType).PreviousValue; } }
                
        [LocalizedDisplayName("VetCase.strSampleNotes")]
        [MapField(_str_strSampleNotes)]
        public abstract String strSampleNotes { get; set; }
        protected String strSampleNotes_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleNotes).OriginalValue; } }
        protected String strSampleNotes_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleNotes).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strTestNotes)]
        [MapField(_str_strTestNotes)]
        public abstract String strTestNotes { get; set; }
        protected String strTestNotes_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestNotes).OriginalValue; } }
        protected String strTestNotes_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestNotes).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSummaryNotes)]
        [MapField(_str_strSummaryNotes)]
        public abstract String strSummaryNotes { get; set; }
        protected String strSummaryNotes_Original { get { return ((EditableValue<String>)((dynamic)this)._strSummaryNotes).OriginalValue; } }
        protected String strSummaryNotes_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSummaryNotes).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strClinicalNotes)]
        [MapField(_str_strClinicalNotes)]
        public abstract String strClinicalNotes { get; set; }
        protected String strClinicalNotes_Original { get { return ((EditableValue<String>)((dynamic)this)._strClinicalNotes).OriginalValue; } }
        protected String strClinicalNotes_Previous { get { return ((EditableValue<String>)((dynamic)this)._strClinicalNotes).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFieldAccessionID)]
        [MapField(_str_strFieldAccessionID)]
        public abstract String strFieldAccessionID { get; set; }
        protected String strFieldAccessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldAccessionID).OriginalValue; } }
        protected String strFieldAccessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldAccessionID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfFarm)]
        [MapField(_str_idfFarm)]
        public abstract Int64 idfFarm { get; set; }
        protected Int64 idfFarm_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).OriginalValue; } }
        protected Int64 idfFarm_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfFarm).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfRootFarm)]
        [MapField(_str_idfRootFarm)]
        public abstract Int64? idfRootFarm { get; set; }
        protected Int64? idfRootFarm_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootFarm).OriginalValue; } }
        protected Int64? idfRootFarm_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootFarm).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFinalDiagnosisOIECode)]
        [MapField(_str_strFinalDiagnosisOIECode)]
        public abstract String strFinalDiagnosisOIECode { get; set; }
        protected String strFinalDiagnosisOIECode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFinalDiagnosisOIECode).OriginalValue; } }
        protected String strFinalDiagnosisOIECode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFinalDiagnosisOIECode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strTentativeDiagnosisOIECode)]
        [MapField(_str_strTentativeDiagnosisOIECode)]
        public abstract String strTentativeDiagnosisOIECode { get; set; }
        protected String strTentativeDiagnosisOIECode_Original { get { return ((EditableValue<String>)((dynamic)this)._strTentativeDiagnosisOIECode).OriginalValue; } }
        protected String strTentativeDiagnosisOIECode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTentativeDiagnosisOIECode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strTentativeDiagnosis1OIECode)]
        [MapField(_str_strTentativeDiagnosis1OIECode)]
        public abstract String strTentativeDiagnosis1OIECode { get; set; }
        protected String strTentativeDiagnosis1OIECode_Original { get { return ((EditableValue<String>)((dynamic)this)._strTentativeDiagnosis1OIECode).OriginalValue; } }
        protected String strTentativeDiagnosis1OIECode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTentativeDiagnosis1OIECode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strTentativeDiagnosis2OIECode)]
        [MapField(_str_strTentativeDiagnosis2OIECode)]
        public abstract String strTentativeDiagnosis2OIECode { get; set; }
        protected String strTentativeDiagnosis2OIECode_Original { get { return ((EditableValue<String>)((dynamic)this)._strTentativeDiagnosis2OIECode).OriginalValue; } }
        protected String strTentativeDiagnosis2OIECode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTentativeDiagnosis2OIECode).PreviousValue; } }
                
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
            internal Func<VetCase, object> _get_func;
            internal Action<VetCase, string> _set_func;
            internal Action<VetCase, VetCase, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfsCaseClassification = "idfsCaseClassification";
        internal const string _str_idfsCaseProgressStatus = "idfsCaseProgressStatus";
        internal const string _str_idfsShowDiagnosis = "idfsShowDiagnosis";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_idfOutbreak = "idfOutbreak";
        internal const string _str_strOutbreakID = "strOutbreakID";
        internal const string _str_idfParentMonitoringSession = "idfParentMonitoringSession";
        internal const string _str_strMonitoringSessionID = "strMonitoringSessionID";
        internal const string _str_datEnteredDate = "datEnteredDate";
        internal const string _str_uidOfflineCaseID = "uidOfflineCaseID";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_idfsTentativeDiagnosis = "idfsTentativeDiagnosis";
        internal const string _str_idfsTentativeDiagnosis1 = "idfsTentativeDiagnosis1";
        internal const string _str_idfsTentativeDiagnosis2 = "idfsTentativeDiagnosis2";
        internal const string _str_idfsFinalDiagnosis = "idfsFinalDiagnosis";
        internal const string _str_idfsYNTestsConducted = "idfsYNTestsConducted";
        internal const string _str_blnEnableTestsConducted = "blnEnableTestsConducted";
        internal const string _str_idfInvestigatedByOffice = "idfInvestigatedByOffice";
        internal const string _str_strInvestigatedByOffice = "strInvestigatedByOffice";
        internal const string _str_idfPersonInvestigatedBy = "idfPersonInvestigatedBy";
        internal const string _str_strPersonInvestigatedBy = "strPersonInvestigatedBy";
        internal const string _str_idfPersonEnteredBy = "idfPersonEnteredBy";
        internal const string _str_strPersonEnteredByName = "strPersonEnteredByName";
        internal const string _str_idfReportedByOffice = "idfReportedByOffice";
        internal const string _str_strReportedByOffice = "strReportedByOffice";
        internal const string _str_idfPersonReportedBy = "idfPersonReportedBy";
        internal const string _str_strPersonReportedBy = "strPersonReportedBy";
        internal const string _str_idfObservation = "idfObservation";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_datReportDate = "datReportDate";
        internal const string _str_datAssignedDate = "datAssignedDate";
        internal const string _str_datInvestigationDate = "datInvestigationDate";
        internal const string _str_datTentativeDiagnosisDate = "datTentativeDiagnosisDate";
        internal const string _str_datTentativeDiagnosis1Date = "datTentativeDiagnosis1Date";
        internal const string _str_datTentativeDiagnosis2Date = "datTentativeDiagnosis2Date";
        internal const string _str_datFinalDiagnosisDate = "datFinalDiagnosisDate";
        internal const string _str_idfsCaseReportType = "idfsCaseReportType";
        internal const string _str_strSampleNotes = "strSampleNotes";
        internal const string _str_strTestNotes = "strTestNotes";
        internal const string _str_strSummaryNotes = "strSummaryNotes";
        internal const string _str_strClinicalNotes = "strClinicalNotes";
        internal const string _str_strFieldAccessionID = "strFieldAccessionID";
        internal const string _str_idfFarm = "idfFarm";
        internal const string _str_idfRootFarm = "idfRootFarm";
        internal const string _str_strFinalDiagnosisOIECode = "strFinalDiagnosisOIECode";
        internal const string _str_strTentativeDiagnosisOIECode = "strTentativeDiagnosisOIECode";
        internal const string _str_strTentativeDiagnosis1OIECode = "strTentativeDiagnosis1OIECode";
        internal const string _str_strTentativeDiagnosis2OIECode = "strTentativeDiagnosis2OIECode";
        internal const string _str_datModificationForArchiveDate = "datModificationForArchiveDate";
        internal const string _str_strFinalDiagnosis = "strFinalDiagnosis";
        internal const string _str_strDiagnosis = "strDiagnosis";
        internal const string _str_DiagnosisAll = "DiagnosisAll";
        internal const string _str_strDiseaseNames = "strDiseaseNames";
        internal const string _str_IsClosed = "IsClosed";
        internal const string _str_IsEnabledCaseProgressStatus = "IsEnabledCaseProgressStatus";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_strSiteCode = "strSiteCode";
        internal const string _str_strIdfsDiagnosis = "strIdfsDiagnosis";
        internal const string _str_strReadOnlyEnteredDate = "strReadOnlyEnteredDate";
        internal const string _str_buttonSelectFarm = "buttonSelectFarm";
        internal const string _str_buttonCoordinatesPicker = "buttonCoordinatesPicker";
        internal const string _str_blnEnableTestsConductedCalc = "blnEnableTestsConductedCalc";
        internal const string _str_idfObservationFarm = "idfObservationFarm";
        internal const string _str_IsLiveStock = "IsLiveStock";
        internal const string _str_Site = "Site";
        internal const string _str_CaseReportType = "CaseReportType";
        internal const string _str_CaseType = "CaseType";
        internal const string _str_CaseClassification = "CaseClassification";
        internal const string _str_CaseProgressStatus = "CaseProgressStatus";
        internal const string _str_TestsConducted = "TestsConducted";
        internal const string _str_TentativeDiagnosis = "TentativeDiagnosis";
        internal const string _str_TentativeDiagnosis1 = "TentativeDiagnosis1";
        internal const string _str_TentativeDiagnosis2 = "TentativeDiagnosis2";
        internal const string _str_FinalDiagnosis = "FinalDiagnosis";
        internal const string _str_ShowDiagnosis = "ShowDiagnosis";
        internal const string _str_PersonInvestigatedBy = "PersonInvestigatedBy";
        internal const string _str_FFPresenterControlMeasures = "FFPresenterControlMeasures";
        internal const string _str_Farm = "Farm";
        internal const string _str_Vaccination = "Vaccination";
        internal const string _str_CaseTests = "CaseTests";
        internal const string _str_CaseTestValidations = "CaseTestValidations";
        internal const string _str_PensideTests = "PensideTests";
        internal const string _str_AnimalList = "AnimalList";
        internal const string _str_Samples = "Samples";
        internal const string _str_Logs = "Logs";
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
              _name = _str_idfsCaseClassification, _formname = _str_idfsCaseClassification, _type = "Int64?",
              _get_func = o => o.idfsCaseClassification,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsCaseClassification != newval) 
                  o.CaseClassification = o.CaseClassificationLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsCaseClassification != newval) o.idfsCaseClassification = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsCaseProgressStatus != newval) 
                  o.CaseProgressStatus = o.CaseProgressStatusLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsCaseProgressStatus != newval) o.idfsCaseProgressStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCaseProgressStatus != c.idfsCaseProgressStatus || o.IsRIRPropChanged(_str_idfsCaseProgressStatus, c)) 
                  m.Add(_str_idfsCaseProgressStatus, o.ObjectIdent + _str_idfsCaseProgressStatus, o.ObjectIdent2 + _str_idfsCaseProgressStatus, o.ObjectIdent3 + _str_idfsCaseProgressStatus, "Int64?", 
                    o.idfsCaseProgressStatus == null ? "" : o.idfsCaseProgressStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseProgressStatus), o.IsInvisible(_str_idfsCaseProgressStatus), o.IsRequired(_str_idfsCaseProgressStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsShowDiagnosis, _formname = _str_idfsShowDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsShowDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsShowDiagnosis != newval) 
                  o.ShowDiagnosis = o.ShowDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsShowDiagnosis != newval) o.idfsShowDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsShowDiagnosis != c.idfsShowDiagnosis || o.IsRIRPropChanged(_str_idfsShowDiagnosis, c)) 
                  m.Add(_str_idfsShowDiagnosis, o.ObjectIdent + _str_idfsShowDiagnosis, o.ObjectIdent2 + _str_idfsShowDiagnosis, o.ObjectIdent3 + _str_idfsShowDiagnosis, "Int64?", 
                    o.idfsShowDiagnosis == null ? "" : o.idfsShowDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsShowDiagnosis), o.IsInvisible(_str_idfsShowDiagnosis), o.IsRequired(_str_idfsShowDiagnosis)); 
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
              _name = _str_idfOutbreak, _formname = _str_idfOutbreak, _type = "Int64?",
              _get_func = o => o.idfOutbreak,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfOutbreak != newval) o.idfOutbreak = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfOutbreak != c.idfOutbreak || o.IsRIRPropChanged(_str_idfOutbreak, c)) 
                  m.Add(_str_idfOutbreak, o.ObjectIdent + _str_idfOutbreak, o.ObjectIdent2 + _str_idfOutbreak, o.ObjectIdent3 + _str_idfOutbreak, "Int64?", 
                    o.idfOutbreak == null ? "" : o.idfOutbreak.ToString(),                  
                  o.IsReadOnly(_str_idfOutbreak), o.IsInvisible(_str_idfOutbreak), o.IsRequired(_str_idfOutbreak)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOutbreakID, _formname = _str_strOutbreakID, _type = "String",
              _get_func = o => o.strOutbreakID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOutbreakID != newval) o.strOutbreakID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strOutbreakID != c.strOutbreakID || o.IsRIRPropChanged(_str_strOutbreakID, c)) 
                  m.Add(_str_strOutbreakID, o.ObjectIdent + _str_strOutbreakID, o.ObjectIdent2 + _str_strOutbreakID, o.ObjectIdent3 + _str_strOutbreakID, "String", 
                    o.strOutbreakID == null ? "" : o.strOutbreakID.ToString(),                  
                  o.IsReadOnly(_str_strOutbreakID), o.IsInvisible(_str_strOutbreakID), o.IsRequired(_str_strOutbreakID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfParentMonitoringSession, _formname = _str_idfParentMonitoringSession, _type = "Int64?",
              _get_func = o => o.idfParentMonitoringSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfParentMonitoringSession != newval) o.idfParentMonitoringSession = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfParentMonitoringSession != c.idfParentMonitoringSession || o.IsRIRPropChanged(_str_idfParentMonitoringSession, c)) 
                  m.Add(_str_idfParentMonitoringSession, o.ObjectIdent + _str_idfParentMonitoringSession, o.ObjectIdent2 + _str_idfParentMonitoringSession, o.ObjectIdent3 + _str_idfParentMonitoringSession, "Int64?", 
                    o.idfParentMonitoringSession == null ? "" : o.idfParentMonitoringSession.ToString(),                  
                  o.IsReadOnly(_str_idfParentMonitoringSession), o.IsInvisible(_str_idfParentMonitoringSession), o.IsRequired(_str_idfParentMonitoringSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strMonitoringSessionID, _formname = _str_strMonitoringSessionID, _type = "String",
              _get_func = o => o.strMonitoringSessionID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strMonitoringSessionID != newval) o.strMonitoringSessionID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strMonitoringSessionID != c.strMonitoringSessionID || o.IsRIRPropChanged(_str_strMonitoringSessionID, c)) 
                  m.Add(_str_strMonitoringSessionID, o.ObjectIdent + _str_strMonitoringSessionID, o.ObjectIdent2 + _str_strMonitoringSessionID, o.ObjectIdent3 + _str_strMonitoringSessionID, "String", 
                    o.strMonitoringSessionID == null ? "" : o.strMonitoringSessionID.ToString(),                  
                  o.IsReadOnly(_str_strMonitoringSessionID), o.IsInvisible(_str_strMonitoringSessionID), o.IsRequired(_str_strMonitoringSessionID)); 
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
              _name = _str_idfsTentativeDiagnosis, _formname = _str_idfsTentativeDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsTentativeDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsTentativeDiagnosis != newval) 
                  o.TentativeDiagnosis = o.TentativeDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsTentativeDiagnosis != newval) o.idfsTentativeDiagnosis = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsTentativeDiagnosis1 != newval) 
                  o.TentativeDiagnosis1 = o.TentativeDiagnosis1Lookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsTentativeDiagnosis1 != newval) o.idfsTentativeDiagnosis1 = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsTentativeDiagnosis2 != newval) 
                  o.TentativeDiagnosis2 = o.TentativeDiagnosis2Lookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsTentativeDiagnosis2 != newval) o.idfsTentativeDiagnosis2 = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsFinalDiagnosis != newval) 
                  o.FinalDiagnosis = o.FinalDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsFinalDiagnosis != newval) o.idfsFinalDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsFinalDiagnosis != c.idfsFinalDiagnosis || o.IsRIRPropChanged(_str_idfsFinalDiagnosis, c)) 
                  m.Add(_str_idfsFinalDiagnosis, o.ObjectIdent + _str_idfsFinalDiagnosis, o.ObjectIdent2 + _str_idfsFinalDiagnosis, o.ObjectIdent3 + _str_idfsFinalDiagnosis, "Int64?", 
                    o.idfsFinalDiagnosis == null ? "" : o.idfsFinalDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsFinalDiagnosis), o.IsInvisible(_str_idfsFinalDiagnosis), o.IsRequired(_str_idfsFinalDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsYNTestsConducted, _formname = _str_idfsYNTestsConducted, _type = "Int64?",
              _get_func = o => o.idfsYNTestsConducted,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsYNTestsConducted != newval) 
                  o.TestsConducted = o.TestsConductedLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsYNTestsConducted != newval) o.idfsYNTestsConducted = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsYNTestsConducted != c.idfsYNTestsConducted || o.IsRIRPropChanged(_str_idfsYNTestsConducted, c)) 
                  m.Add(_str_idfsYNTestsConducted, o.ObjectIdent + _str_idfsYNTestsConducted, o.ObjectIdent2 + _str_idfsYNTestsConducted, o.ObjectIdent3 + _str_idfsYNTestsConducted, "Int64?", 
                    o.idfsYNTestsConducted == null ? "" : o.idfsYNTestsConducted.ToString(),                  
                  o.IsReadOnly(_str_idfsYNTestsConducted), o.IsInvisible(_str_idfsYNTestsConducted), o.IsRequired(_str_idfsYNTestsConducted)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnEnableTestsConducted, _formname = _str_blnEnableTestsConducted, _type = "Boolean?",
              _get_func = o => o.blnEnableTestsConducted,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnEnableTestsConducted != newval) o.blnEnableTestsConducted = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.blnEnableTestsConducted != c.blnEnableTestsConducted || o.IsRIRPropChanged(_str_blnEnableTestsConducted, c)) 
                  m.Add(_str_blnEnableTestsConducted, o.ObjectIdent + _str_blnEnableTestsConducted, o.ObjectIdent2 + _str_blnEnableTestsConducted, o.ObjectIdent3 + _str_blnEnableTestsConducted, "Boolean?", 
                    o.blnEnableTestsConducted == null ? "" : o.blnEnableTestsConducted.ToString(),                  
                  o.IsReadOnly(_str_blnEnableTestsConducted), o.IsInvisible(_str_blnEnableTestsConducted), o.IsRequired(_str_blnEnableTestsConducted)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfInvestigatedByOffice, _formname = _str_idfInvestigatedByOffice, _type = "Int64?",
              _get_func = o => o.idfInvestigatedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfInvestigatedByOffice != newval) o.idfInvestigatedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfInvestigatedByOffice != c.idfInvestigatedByOffice || o.IsRIRPropChanged(_str_idfInvestigatedByOffice, c)) 
                  m.Add(_str_idfInvestigatedByOffice, o.ObjectIdent + _str_idfInvestigatedByOffice, o.ObjectIdent2 + _str_idfInvestigatedByOffice, o.ObjectIdent3 + _str_idfInvestigatedByOffice, "Int64?", 
                    o.idfInvestigatedByOffice == null ? "" : o.idfInvestigatedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfInvestigatedByOffice), o.IsInvisible(_str_idfInvestigatedByOffice), o.IsRequired(_str_idfInvestigatedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strInvestigatedByOffice, _formname = _str_strInvestigatedByOffice, _type = "String",
              _get_func = o => o.strInvestigatedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strInvestigatedByOffice != newval) o.strInvestigatedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strInvestigatedByOffice != c.strInvestigatedByOffice || o.IsRIRPropChanged(_str_strInvestigatedByOffice, c)) 
                  m.Add(_str_strInvestigatedByOffice, o.ObjectIdent + _str_strInvestigatedByOffice, o.ObjectIdent2 + _str_strInvestigatedByOffice, o.ObjectIdent3 + _str_strInvestigatedByOffice, "String", 
                    o.strInvestigatedByOffice == null ? "" : o.strInvestigatedByOffice.ToString(),                  
                  o.IsReadOnly(_str_strInvestigatedByOffice), o.IsInvisible(_str_strInvestigatedByOffice), o.IsRequired(_str_strInvestigatedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPersonInvestigatedBy, _formname = _str_idfPersonInvestigatedBy, _type = "Int64?",
              _get_func = o => o.idfPersonInvestigatedBy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfPersonInvestigatedBy != newval) 
                  o.PersonInvestigatedBy = o.PersonInvestigatedByLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfPersonInvestigatedBy != newval) o.idfPersonInvestigatedBy = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfPersonInvestigatedBy != c.idfPersonInvestigatedBy || o.IsRIRPropChanged(_str_idfPersonInvestigatedBy, c)) 
                  m.Add(_str_idfPersonInvestigatedBy, o.ObjectIdent + _str_idfPersonInvestigatedBy, o.ObjectIdent2 + _str_idfPersonInvestigatedBy, o.ObjectIdent3 + _str_idfPersonInvestigatedBy, "Int64?", 
                    o.idfPersonInvestigatedBy == null ? "" : o.idfPersonInvestigatedBy.ToString(),                  
                  o.IsReadOnly(_str_idfPersonInvestigatedBy), o.IsInvisible(_str_idfPersonInvestigatedBy), o.IsRequired(_str_idfPersonInvestigatedBy)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPersonInvestigatedBy, _formname = _str_strPersonInvestigatedBy, _type = "String",
              _get_func = o => o.strPersonInvestigatedBy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPersonInvestigatedBy != newval) o.strPersonInvestigatedBy = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strPersonInvestigatedBy != c.strPersonInvestigatedBy || o.IsRIRPropChanged(_str_strPersonInvestigatedBy, c)) 
                  m.Add(_str_strPersonInvestigatedBy, o.ObjectIdent + _str_strPersonInvestigatedBy, o.ObjectIdent2 + _str_strPersonInvestigatedBy, o.ObjectIdent3 + _str_strPersonInvestigatedBy, "String", 
                    o.strPersonInvestigatedBy == null ? "" : o.strPersonInvestigatedBy.ToString(),                  
                  o.IsReadOnly(_str_strPersonInvestigatedBy), o.IsInvisible(_str_strPersonInvestigatedBy), o.IsRequired(_str_strPersonInvestigatedBy)); 
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
              _name = _str_strPersonEnteredByName, _formname = _str_strPersonEnteredByName, _type = "String",
              _get_func = o => o.strPersonEnteredByName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPersonEnteredByName != newval) o.strPersonEnteredByName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strPersonEnteredByName != c.strPersonEnteredByName || o.IsRIRPropChanged(_str_strPersonEnteredByName, c)) 
                  m.Add(_str_strPersonEnteredByName, o.ObjectIdent + _str_strPersonEnteredByName, o.ObjectIdent2 + _str_strPersonEnteredByName, o.ObjectIdent3 + _str_strPersonEnteredByName, "String", 
                    o.strPersonEnteredByName == null ? "" : o.strPersonEnteredByName.ToString(),                  
                  o.IsReadOnly(_str_strPersonEnteredByName), o.IsInvisible(_str_strPersonEnteredByName), o.IsRequired(_str_strPersonEnteredByName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfReportedByOffice, _formname = _str_idfReportedByOffice, _type = "Int64?",
              _get_func = o => o.idfReportedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfReportedByOffice != newval) o.idfReportedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfReportedByOffice != c.idfReportedByOffice || o.IsRIRPropChanged(_str_idfReportedByOffice, c)) 
                  m.Add(_str_idfReportedByOffice, o.ObjectIdent + _str_idfReportedByOffice, o.ObjectIdent2 + _str_idfReportedByOffice, o.ObjectIdent3 + _str_idfReportedByOffice, "Int64?", 
                    o.idfReportedByOffice == null ? "" : o.idfReportedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfReportedByOffice), o.IsInvisible(_str_idfReportedByOffice), o.IsRequired(_str_idfReportedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strReportedByOffice, _formname = _str_strReportedByOffice, _type = "String",
              _get_func = o => o.strReportedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strReportedByOffice != newval) o.strReportedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strReportedByOffice != c.strReportedByOffice || o.IsRIRPropChanged(_str_strReportedByOffice, c)) 
                  m.Add(_str_strReportedByOffice, o.ObjectIdent + _str_strReportedByOffice, o.ObjectIdent2 + _str_strReportedByOffice, o.ObjectIdent3 + _str_strReportedByOffice, "String", 
                    o.strReportedByOffice == null ? "" : o.strReportedByOffice.ToString(),                  
                  o.IsReadOnly(_str_strReportedByOffice), o.IsInvisible(_str_strReportedByOffice), o.IsRequired(_str_strReportedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPersonReportedBy, _formname = _str_idfPersonReportedBy, _type = "Int64?",
              _get_func = o => o.idfPersonReportedBy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfPersonReportedBy != newval) o.idfPersonReportedBy = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfPersonReportedBy != c.idfPersonReportedBy || o.IsRIRPropChanged(_str_idfPersonReportedBy, c)) 
                  m.Add(_str_idfPersonReportedBy, o.ObjectIdent + _str_idfPersonReportedBy, o.ObjectIdent2 + _str_idfPersonReportedBy, o.ObjectIdent3 + _str_idfPersonReportedBy, "Int64?", 
                    o.idfPersonReportedBy == null ? "" : o.idfPersonReportedBy.ToString(),                  
                  o.IsReadOnly(_str_idfPersonReportedBy), o.IsInvisible(_str_idfPersonReportedBy), o.IsRequired(_str_idfPersonReportedBy)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPersonReportedBy, _formname = _str_strPersonReportedBy, _type = "String",
              _get_func = o => o.strPersonReportedBy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPersonReportedBy != newval) o.strPersonReportedBy = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strPersonReportedBy != c.strPersonReportedBy || o.IsRIRPropChanged(_str_strPersonReportedBy, c)) 
                  m.Add(_str_strPersonReportedBy, o.ObjectIdent + _str_strPersonReportedBy, o.ObjectIdent2 + _str_strPersonReportedBy, o.ObjectIdent3 + _str_strPersonReportedBy, "String", 
                    o.strPersonReportedBy == null ? "" : o.strPersonReportedBy.ToString(),                  
                  o.IsReadOnly(_str_strPersonReportedBy), o.IsInvisible(_str_strPersonReportedBy), o.IsRequired(_str_strPersonReportedBy)); 
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
              _name = _str_idfsSite, _formname = _str_idfsSite, _type = "Int64",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsSite != newval) 
                  o.Site = o.SiteLookup.FirstOrDefault(c => c.idfsSite == newval);
                if (o.idfsSite != newval) o.idfsSite = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, o.ObjectIdent2 + _str_idfsSite, o.ObjectIdent3 + _str_idfsSite, "Int64", 
                    o.idfsSite == null ? "" : o.idfsSite.ToString(),                  
                  o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); 
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
              _name = _str_datTentativeDiagnosisDate, _formname = _str_datTentativeDiagnosisDate, _type = "DateTime?",
              _get_func = o => o.datTentativeDiagnosisDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datTentativeDiagnosisDate != newval) o.datTentativeDiagnosisDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datTentativeDiagnosisDate != c.datTentativeDiagnosisDate || o.IsRIRPropChanged(_str_datTentativeDiagnosisDate, c)) 
                  m.Add(_str_datTentativeDiagnosisDate, o.ObjectIdent + _str_datTentativeDiagnosisDate, o.ObjectIdent2 + _str_datTentativeDiagnosisDate, o.ObjectIdent3 + _str_datTentativeDiagnosisDate, "DateTime?", 
                    o.datTentativeDiagnosisDate == null ? "" : o.datTentativeDiagnosisDate.ToString(),                  
                  o.IsReadOnly(_str_datTentativeDiagnosisDate), o.IsInvisible(_str_datTentativeDiagnosisDate), o.IsRequired(_str_datTentativeDiagnosisDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datTentativeDiagnosis1Date, _formname = _str_datTentativeDiagnosis1Date, _type = "DateTime?",
              _get_func = o => o.datTentativeDiagnosis1Date,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datTentativeDiagnosis1Date != newval) o.datTentativeDiagnosis1Date = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datTentativeDiagnosis1Date != c.datTentativeDiagnosis1Date || o.IsRIRPropChanged(_str_datTentativeDiagnosis1Date, c)) 
                  m.Add(_str_datTentativeDiagnosis1Date, o.ObjectIdent + _str_datTentativeDiagnosis1Date, o.ObjectIdent2 + _str_datTentativeDiagnosis1Date, o.ObjectIdent3 + _str_datTentativeDiagnosis1Date, "DateTime?", 
                    o.datTentativeDiagnosis1Date == null ? "" : o.datTentativeDiagnosis1Date.ToString(),                  
                  o.IsReadOnly(_str_datTentativeDiagnosis1Date), o.IsInvisible(_str_datTentativeDiagnosis1Date), o.IsRequired(_str_datTentativeDiagnosis1Date)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datTentativeDiagnosis2Date, _formname = _str_datTentativeDiagnosis2Date, _type = "DateTime?",
              _get_func = o => o.datTentativeDiagnosis2Date,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datTentativeDiagnosis2Date != newval) o.datTentativeDiagnosis2Date = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datTentativeDiagnosis2Date != c.datTentativeDiagnosis2Date || o.IsRIRPropChanged(_str_datTentativeDiagnosis2Date, c)) 
                  m.Add(_str_datTentativeDiagnosis2Date, o.ObjectIdent + _str_datTentativeDiagnosis2Date, o.ObjectIdent2 + _str_datTentativeDiagnosis2Date, o.ObjectIdent3 + _str_datTentativeDiagnosis2Date, "DateTime?", 
                    o.datTentativeDiagnosis2Date == null ? "" : o.datTentativeDiagnosis2Date.ToString(),                  
                  o.IsReadOnly(_str_datTentativeDiagnosis2Date), o.IsInvisible(_str_datTentativeDiagnosis2Date), o.IsRequired(_str_datTentativeDiagnosis2Date)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datFinalDiagnosisDate, _formname = _str_datFinalDiagnosisDate, _type = "DateTime?",
              _get_func = o => o.datFinalDiagnosisDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datFinalDiagnosisDate != newval) o.datFinalDiagnosisDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datFinalDiagnosisDate != c.datFinalDiagnosisDate || o.IsRIRPropChanged(_str_datFinalDiagnosisDate, c)) 
                  m.Add(_str_datFinalDiagnosisDate, o.ObjectIdent + _str_datFinalDiagnosisDate, o.ObjectIdent2 + _str_datFinalDiagnosisDate, o.ObjectIdent3 + _str_datFinalDiagnosisDate, "DateTime?", 
                    o.datFinalDiagnosisDate == null ? "" : o.datFinalDiagnosisDate.ToString(),                  
                  o.IsReadOnly(_str_datFinalDiagnosisDate), o.IsInvisible(_str_datFinalDiagnosisDate), o.IsRequired(_str_datFinalDiagnosisDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCaseReportType, _formname = _str_idfsCaseReportType, _type = "Int64?",
              _get_func = o => o.idfsCaseReportType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsCaseReportType != newval) 
                  o.CaseReportType = o.CaseReportTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsCaseReportType != newval) o.idfsCaseReportType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCaseReportType != c.idfsCaseReportType || o.IsRIRPropChanged(_str_idfsCaseReportType, c)) 
                  m.Add(_str_idfsCaseReportType, o.ObjectIdent + _str_idfsCaseReportType, o.ObjectIdent2 + _str_idfsCaseReportType, o.ObjectIdent3 + _str_idfsCaseReportType, "Int64?", 
                    o.idfsCaseReportType == null ? "" : o.idfsCaseReportType.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseReportType), o.IsInvisible(_str_idfsCaseReportType), o.IsRequired(_str_idfsCaseReportType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSampleNotes, _formname = _str_strSampleNotes, _type = "String",
              _get_func = o => o.strSampleNotes,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSampleNotes != newval) o.strSampleNotes = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSampleNotes != c.strSampleNotes || o.IsRIRPropChanged(_str_strSampleNotes, c)) 
                  m.Add(_str_strSampleNotes, o.ObjectIdent + _str_strSampleNotes, o.ObjectIdent2 + _str_strSampleNotes, o.ObjectIdent3 + _str_strSampleNotes, "String", 
                    o.strSampleNotes == null ? "" : o.strSampleNotes.ToString(),                  
                  o.IsReadOnly(_str_strSampleNotes), o.IsInvisible(_str_strSampleNotes), o.IsRequired(_str_strSampleNotes)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTestNotes, _formname = _str_strTestNotes, _type = "String",
              _get_func = o => o.strTestNotes,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTestNotes != newval) o.strTestNotes = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strTestNotes != c.strTestNotes || o.IsRIRPropChanged(_str_strTestNotes, c)) 
                  m.Add(_str_strTestNotes, o.ObjectIdent + _str_strTestNotes, o.ObjectIdent2 + _str_strTestNotes, o.ObjectIdent3 + _str_strTestNotes, "String", 
                    o.strTestNotes == null ? "" : o.strTestNotes.ToString(),                  
                  o.IsReadOnly(_str_strTestNotes), o.IsInvisible(_str_strTestNotes), o.IsRequired(_str_strTestNotes)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSummaryNotes, _formname = _str_strSummaryNotes, _type = "String",
              _get_func = o => o.strSummaryNotes,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSummaryNotes != newval) o.strSummaryNotes = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSummaryNotes != c.strSummaryNotes || o.IsRIRPropChanged(_str_strSummaryNotes, c)) 
                  m.Add(_str_strSummaryNotes, o.ObjectIdent + _str_strSummaryNotes, o.ObjectIdent2 + _str_strSummaryNotes, o.ObjectIdent3 + _str_strSummaryNotes, "String", 
                    o.strSummaryNotes == null ? "" : o.strSummaryNotes.ToString(),                  
                  o.IsReadOnly(_str_strSummaryNotes), o.IsInvisible(_str_strSummaryNotes), o.IsRequired(_str_strSummaryNotes)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strClinicalNotes, _formname = _str_strClinicalNotes, _type = "String",
              _get_func = o => o.strClinicalNotes,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strClinicalNotes != newval) o.strClinicalNotes = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strClinicalNotes != c.strClinicalNotes || o.IsRIRPropChanged(_str_strClinicalNotes, c)) 
                  m.Add(_str_strClinicalNotes, o.ObjectIdent + _str_strClinicalNotes, o.ObjectIdent2 + _str_strClinicalNotes, o.ObjectIdent3 + _str_strClinicalNotes, "String", 
                    o.strClinicalNotes == null ? "" : o.strClinicalNotes.ToString(),                  
                  o.IsReadOnly(_str_strClinicalNotes), o.IsInvisible(_str_strClinicalNotes), o.IsRequired(_str_strClinicalNotes)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFieldAccessionID, _formname = _str_strFieldAccessionID, _type = "String",
              _get_func = o => o.strFieldAccessionID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldAccessionID != newval) o.strFieldAccessionID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFieldAccessionID != c.strFieldAccessionID || o.IsRIRPropChanged(_str_strFieldAccessionID, c)) 
                  m.Add(_str_strFieldAccessionID, o.ObjectIdent + _str_strFieldAccessionID, o.ObjectIdent2 + _str_strFieldAccessionID, o.ObjectIdent3 + _str_strFieldAccessionID, "String", 
                    o.strFieldAccessionID == null ? "" : o.strFieldAccessionID.ToString(),                  
                  o.IsReadOnly(_str_strFieldAccessionID), o.IsInvisible(_str_strFieldAccessionID), o.IsRequired(_str_strFieldAccessionID)); 
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
              _name = _str_strFinalDiagnosisOIECode, _formname = _str_strFinalDiagnosisOIECode, _type = "String",
              _get_func = o => o.strFinalDiagnosisOIECode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFinalDiagnosisOIECode != newval) o.strFinalDiagnosisOIECode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFinalDiagnosisOIECode != c.strFinalDiagnosisOIECode || o.IsRIRPropChanged(_str_strFinalDiagnosisOIECode, c)) 
                  m.Add(_str_strFinalDiagnosisOIECode, o.ObjectIdent + _str_strFinalDiagnosisOIECode, o.ObjectIdent2 + _str_strFinalDiagnosisOIECode, o.ObjectIdent3 + _str_strFinalDiagnosisOIECode, "String", 
                    o.strFinalDiagnosisOIECode == null ? "" : o.strFinalDiagnosisOIECode.ToString(),                  
                  o.IsReadOnly(_str_strFinalDiagnosisOIECode), o.IsInvisible(_str_strFinalDiagnosisOIECode), o.IsRequired(_str_strFinalDiagnosisOIECode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTentativeDiagnosisOIECode, _formname = _str_strTentativeDiagnosisOIECode, _type = "String",
              _get_func = o => o.strTentativeDiagnosisOIECode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTentativeDiagnosisOIECode != newval) o.strTentativeDiagnosisOIECode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strTentativeDiagnosisOIECode != c.strTentativeDiagnosisOIECode || o.IsRIRPropChanged(_str_strTentativeDiagnosisOIECode, c)) 
                  m.Add(_str_strTentativeDiagnosisOIECode, o.ObjectIdent + _str_strTentativeDiagnosisOIECode, o.ObjectIdent2 + _str_strTentativeDiagnosisOIECode, o.ObjectIdent3 + _str_strTentativeDiagnosisOIECode, "String", 
                    o.strTentativeDiagnosisOIECode == null ? "" : o.strTentativeDiagnosisOIECode.ToString(),                  
                  o.IsReadOnly(_str_strTentativeDiagnosisOIECode), o.IsInvisible(_str_strTentativeDiagnosisOIECode), o.IsRequired(_str_strTentativeDiagnosisOIECode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTentativeDiagnosis1OIECode, _formname = _str_strTentativeDiagnosis1OIECode, _type = "String",
              _get_func = o => o.strTentativeDiagnosis1OIECode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTentativeDiagnosis1OIECode != newval) o.strTentativeDiagnosis1OIECode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strTentativeDiagnosis1OIECode != c.strTentativeDiagnosis1OIECode || o.IsRIRPropChanged(_str_strTentativeDiagnosis1OIECode, c)) 
                  m.Add(_str_strTentativeDiagnosis1OIECode, o.ObjectIdent + _str_strTentativeDiagnosis1OIECode, o.ObjectIdent2 + _str_strTentativeDiagnosis1OIECode, o.ObjectIdent3 + _str_strTentativeDiagnosis1OIECode, "String", 
                    o.strTentativeDiagnosis1OIECode == null ? "" : o.strTentativeDiagnosis1OIECode.ToString(),                  
                  o.IsReadOnly(_str_strTentativeDiagnosis1OIECode), o.IsInvisible(_str_strTentativeDiagnosis1OIECode), o.IsRequired(_str_strTentativeDiagnosis1OIECode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTentativeDiagnosis2OIECode, _formname = _str_strTentativeDiagnosis2OIECode, _type = "String",
              _get_func = o => o.strTentativeDiagnosis2OIECode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTentativeDiagnosis2OIECode != newval) o.strTentativeDiagnosis2OIECode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strTentativeDiagnosis2OIECode != c.strTentativeDiagnosis2OIECode || o.IsRIRPropChanged(_str_strTentativeDiagnosis2OIECode, c)) 
                  m.Add(_str_strTentativeDiagnosis2OIECode, o.ObjectIdent + _str_strTentativeDiagnosis2OIECode, o.ObjectIdent2 + _str_strTentativeDiagnosis2OIECode, o.ObjectIdent3 + _str_strTentativeDiagnosis2OIECode, "String", 
                    o.strTentativeDiagnosis2OIECode == null ? "" : o.strTentativeDiagnosis2OIECode.ToString(),                  
                  o.IsReadOnly(_str_strTentativeDiagnosis2OIECode), o.IsInvisible(_str_strTentativeDiagnosis2OIECode), o.IsRequired(_str_strTentativeDiagnosis2OIECode)); 
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
              _name = _str_strFinalDiagnosis, _formname = _str_strFinalDiagnosis, _type = "string",
              _get_func = o => o.strFinalDiagnosis,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strFinalDiagnosis != c.strFinalDiagnosis || o.IsRIRPropChanged(_str_strFinalDiagnosis, c)) {
                  m.Add(_str_strFinalDiagnosis, o.ObjectIdent + _str_strFinalDiagnosis, o.ObjectIdent2 + _str_strFinalDiagnosis, o.ObjectIdent3 + _str_strFinalDiagnosis, "string", o.strFinalDiagnosis == null ? "" : o.strFinalDiagnosis.ToString(), o.IsReadOnly(_str_strFinalDiagnosis), o.IsInvisible(_str_strFinalDiagnosis), o.IsRequired(_str_strFinalDiagnosis));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strDiagnosis, _formname = _str_strDiagnosis, _type = "string",
              _get_func = o => o.strDiagnosis,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strDiagnosis != c.strDiagnosis || o.IsRIRPropChanged(_str_strDiagnosis, c)) {
                  m.Add(_str_strDiagnosis, o.ObjectIdent + _str_strDiagnosis, o.ObjectIdent2 + _str_strDiagnosis, o.ObjectIdent3 + _str_strDiagnosis, "string", o.strDiagnosis == null ? "" : o.strDiagnosis.ToString(), o.IsReadOnly(_str_strDiagnosis), o.IsInvisible(_str_strDiagnosis), o.IsRequired(_str_strDiagnosis));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_DiagnosisAll, _formname = _str_DiagnosisAll, _type = "List<DiagnosisLookup>",
              _get_func = o => o.DiagnosisAll,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_strDiseaseNames, _formname = _str_strDiseaseNames, _type = "string",
              _get_func = o => o.strDiseaseNames,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strDiseaseNames != c.strDiseaseNames || o.IsRIRPropChanged(_str_strDiseaseNames, c)) {
                  m.Add(_str_strDiseaseNames, o.ObjectIdent + _str_strDiseaseNames, o.ObjectIdent2 + _str_strDiseaseNames, o.ObjectIdent3 + _str_strDiseaseNames, "string", o.strDiseaseNames == null ? "" : o.strDiseaseNames.ToString(), o.IsReadOnly(_str_strDiseaseNames), o.IsInvisible(_str_strDiseaseNames), o.IsRequired(_str_strDiseaseNames));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_IsClosed, _formname = _str_IsClosed, _type = "bool",
              _get_func = o => o.IsClosed,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.IsClosed != c.IsClosed || o.IsRIRPropChanged(_str_IsClosed, c)) {
                  m.Add(_str_IsClosed, o.ObjectIdent + _str_IsClosed, o.ObjectIdent2 + _str_IsClosed, o.ObjectIdent3 + _str_IsClosed, "bool", o.IsClosed == null ? "" : o.IsClosed.ToString(), o.IsReadOnly(_str_IsClosed), o.IsInvisible(_str_IsClosed), o.IsRequired(_str_IsClosed));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_IsEnabledCaseProgressStatus, _formname = _str_IsEnabledCaseProgressStatus, _type = "bool",
              _get_func = o => o.IsEnabledCaseProgressStatus,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.IsEnabledCaseProgressStatus != c.IsEnabledCaseProgressStatus || o.IsRIRPropChanged(_str_IsEnabledCaseProgressStatus, c)) {
                  m.Add(_str_IsEnabledCaseProgressStatus, o.ObjectIdent + _str_IsEnabledCaseProgressStatus, o.ObjectIdent2 + _str_IsEnabledCaseProgressStatus, o.ObjectIdent3 + _str_IsEnabledCaseProgressStatus, "bool", o.IsEnabledCaseProgressStatus == null ? "" : o.IsEnabledCaseProgressStatus.ToString(), o.IsReadOnly(_str_IsEnabledCaseProgressStatus), o.IsInvisible(_str_IsEnabledCaseProgressStatus), o.IsRequired(_str_IsEnabledCaseProgressStatus));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "long?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) {
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis, "long?", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strSiteCode, _formname = _str_strSiteCode, _type = "string",
              _get_func = o => o.strSiteCode,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strSiteCode != c.strSiteCode || o.IsRIRPropChanged(_str_strSiteCode, c)) {
                  m.Add(_str_strSiteCode, o.ObjectIdent + _str_strSiteCode, o.ObjectIdent2 + _str_strSiteCode, o.ObjectIdent3 + _str_strSiteCode, "string", o.strSiteCode == null ? "" : o.strSiteCode.ToString(), o.IsReadOnly(_str_strSiteCode), o.IsInvisible(_str_strSiteCode), o.IsRequired(_str_strSiteCode));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strIdfsDiagnosis, _formname = _str_strIdfsDiagnosis, _type = "string",
              _get_func = o => o.strIdfsDiagnosis,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strIdfsDiagnosis != c.strIdfsDiagnosis || o.IsRIRPropChanged(_str_strIdfsDiagnosis, c)) {
                  m.Add(_str_strIdfsDiagnosis, o.ObjectIdent + _str_strIdfsDiagnosis, o.ObjectIdent2 + _str_strIdfsDiagnosis, o.ObjectIdent3 + _str_strIdfsDiagnosis, "string", o.strIdfsDiagnosis == null ? "" : o.strIdfsDiagnosis.ToString(), o.IsReadOnly(_str_strIdfsDiagnosis), o.IsInvisible(_str_strIdfsDiagnosis), o.IsRequired(_str_strIdfsDiagnosis));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyEnteredDate, _formname = _str_strReadOnlyEnteredDate, _type = "string",
              _get_func = o => o.strReadOnlyEnteredDate,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strReadOnlyEnteredDate != c.strReadOnlyEnteredDate || o.IsRIRPropChanged(_str_strReadOnlyEnteredDate, c)) {
                  m.Add(_str_strReadOnlyEnteredDate, o.ObjectIdent + _str_strReadOnlyEnteredDate, o.ObjectIdent2 + _str_strReadOnlyEnteredDate, o.ObjectIdent3 + _str_strReadOnlyEnteredDate, "string", o.strReadOnlyEnteredDate == null ? "" : o.strReadOnlyEnteredDate.ToString(), o.IsReadOnly(_str_strReadOnlyEnteredDate), o.IsInvisible(_str_strReadOnlyEnteredDate), o.IsRequired(_str_strReadOnlyEnteredDate));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_buttonSelectFarm, _formname = _str_buttonSelectFarm, _type = "string",
              _get_func = o => o.buttonSelectFarm,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.buttonSelectFarm != c.buttonSelectFarm || o.IsRIRPropChanged(_str_buttonSelectFarm, c)) {
                  m.Add(_str_buttonSelectFarm, o.ObjectIdent + _str_buttonSelectFarm, o.ObjectIdent2 + _str_buttonSelectFarm, o.ObjectIdent3 + _str_buttonSelectFarm, "string", o.buttonSelectFarm == null ? "" : o.buttonSelectFarm.ToString(), o.IsReadOnly(_str_buttonSelectFarm), o.IsInvisible(_str_buttonSelectFarm), o.IsRequired(_str_buttonSelectFarm));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_buttonCoordinatesPicker, _formname = _str_buttonCoordinatesPicker, _type = "string",
              _get_func = o => o.buttonCoordinatesPicker,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.buttonCoordinatesPicker != c.buttonCoordinatesPicker || o.IsRIRPropChanged(_str_buttonCoordinatesPicker, c)) {
                  m.Add(_str_buttonCoordinatesPicker, o.ObjectIdent + _str_buttonCoordinatesPicker, o.ObjectIdent2 + _str_buttonCoordinatesPicker, o.ObjectIdent3 + _str_buttonCoordinatesPicker, "string", o.buttonCoordinatesPicker == null ? "" : o.buttonCoordinatesPicker.ToString(), o.IsReadOnly(_str_buttonCoordinatesPicker), o.IsInvisible(_str_buttonCoordinatesPicker), o.IsRequired(_str_buttonCoordinatesPicker));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_blnEnableTestsConductedCalc, _formname = _str_blnEnableTestsConductedCalc, _type = "bool",
              _get_func = o => o.blnEnableTestsConductedCalc,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.blnEnableTestsConductedCalc != c.blnEnableTestsConductedCalc || o.IsRIRPropChanged(_str_blnEnableTestsConductedCalc, c)) {
                  m.Add(_str_blnEnableTestsConductedCalc, o.ObjectIdent + _str_blnEnableTestsConductedCalc, o.ObjectIdent2 + _str_blnEnableTestsConductedCalc, o.ObjectIdent3 + _str_blnEnableTestsConductedCalc, "bool", o.blnEnableTestsConductedCalc == null ? "" : o.blnEnableTestsConductedCalc.ToString(), o.IsReadOnly(_str_blnEnableTestsConductedCalc), o.IsInvisible(_str_blnEnableTestsConductedCalc), o.IsRequired(_str_blnEnableTestsConductedCalc));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_idfObservationFarm, _formname = _str_idfObservationFarm, _type = "long",
              _get_func = o => o.idfObservationFarm,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.idfObservationFarm != c.idfObservationFarm || o.IsRIRPropChanged(_str_idfObservationFarm, c)) {
                  m.Add(_str_idfObservationFarm, o.ObjectIdent + _str_idfObservationFarm, o.ObjectIdent2 + _str_idfObservationFarm, o.ObjectIdent3 + _str_idfObservationFarm, "long", o.idfObservationFarm == null ? "" : o.idfObservationFarm.ToString(), o.IsReadOnly(_str_idfObservationFarm), o.IsInvisible(_str_idfObservationFarm), o.IsRequired(_str_idfObservationFarm));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_IsLiveStock, _formname = _str_IsLiveStock, _type = "bool",
              _get_func = o => o.IsLiveStock,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.IsLiveStock != c.IsLiveStock || o.IsRIRPropChanged(_str_IsLiveStock, c)) {
                  m.Add(_str_IsLiveStock, o.ObjectIdent + _str_IsLiveStock, o.ObjectIdent2 + _str_IsLiveStock, o.ObjectIdent3 + _str_IsLiveStock, "bool", o.IsLiveStock == null ? "" : o.IsLiveStock.ToString(), o.IsReadOnly(_str_IsLiveStock), o.IsInvisible(_str_IsLiveStock), o.IsRequired(_str_IsLiveStock));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Site, _formname = _str_Site, _type = "Lookup",
              _get_func = o => { if (o.Site == null) return null; return o.Site.idfsSite; },
              _set_func = (o, val) => { o.Site = o.SiteLookup.Where(c => c.idfsSite.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Site, c);
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_Site, c) || bChangeLookupContent) {
                  m.Add(_str_Site, o.ObjectIdent + _str_Site, o.ObjectIdent2 + _str_Site, o.ObjectIdent3 + _str_Site, "Lookup", o.idfsSite == null ? "" : o.idfsSite.ToString(), o.IsReadOnly(_str_Site), o.IsInvisible(_str_Site), o.IsRequired(_str_Site),
                  bChangeLookupContent ? o.SiteLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Site + "Lookup", _formname = _str_Site + "Lookup", _type = "LookupContent",
              _get_func = o => o.SiteLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_CaseReportType, _formname = _str_CaseReportType, _type = "Lookup",
              _get_func = o => { if (o.CaseReportType == null) return null; return o.CaseReportType.idfsBaseReference; },
              _set_func = (o, val) => { o.CaseReportType = o.CaseReportTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_CaseReportType, c);
                if (o.idfsCaseReportType != c.idfsCaseReportType || o.IsRIRPropChanged(_str_CaseReportType, c) || bChangeLookupContent) {
                  m.Add(_str_CaseReportType, o.ObjectIdent + _str_CaseReportType, o.ObjectIdent2 + _str_CaseReportType, o.ObjectIdent3 + _str_CaseReportType, "Lookup", o.idfsCaseReportType == null ? "" : o.idfsCaseReportType.ToString(), o.IsReadOnly(_str_CaseReportType), o.IsInvisible(_str_CaseReportType), o.IsRequired(_str_CaseReportType),
                  bChangeLookupContent ? o.CaseReportTypeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_CaseReportType + "Lookup", _formname = _str_CaseReportType + "Lookup", _type = "LookupContent",
              _get_func = o => o.CaseReportTypeLookup,
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
        
            new field_info {
              _name = _str_CaseClassification, _formname = _str_CaseClassification, _type = "Lookup",
              _get_func = o => { if (o.CaseClassification == null) return null; return o.CaseClassification.idfsBaseReference; },
              _set_func = (o, val) => { o.CaseClassification = o.CaseClassificationLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_CaseClassification, c);
                if (o.idfsCaseClassification != c.idfsCaseClassification || o.IsRIRPropChanged(_str_CaseClassification, c) || bChangeLookupContent) {
                  m.Add(_str_CaseClassification, o.ObjectIdent + _str_CaseClassification, o.ObjectIdent2 + _str_CaseClassification, o.ObjectIdent3 + _str_CaseClassification, "Lookup", o.idfsCaseClassification == null ? "" : o.idfsCaseClassification.ToString(), o.IsReadOnly(_str_CaseClassification), o.IsInvisible(_str_CaseClassification), o.IsRequired(_str_CaseClassification),
                  bChangeLookupContent ? o.CaseClassificationLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_CaseClassification + "Lookup", _formname = _str_CaseClassification + "Lookup", _type = "LookupContent",
              _get_func = o => o.CaseClassificationLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_CaseProgressStatus, _formname = _str_CaseProgressStatus, _type = "Lookup",
              _get_func = o => { if (o.CaseProgressStatus == null) return null; return o.CaseProgressStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.CaseProgressStatus = o.CaseProgressStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_CaseProgressStatus, c);
                if (o.idfsCaseProgressStatus != c.idfsCaseProgressStatus || o.IsRIRPropChanged(_str_CaseProgressStatus, c) || bChangeLookupContent) {
                  m.Add(_str_CaseProgressStatus, o.ObjectIdent + _str_CaseProgressStatus, o.ObjectIdent2 + _str_CaseProgressStatus, o.ObjectIdent3 + _str_CaseProgressStatus, "Lookup", o.idfsCaseProgressStatus == null ? "" : o.idfsCaseProgressStatus.ToString(), o.IsReadOnly(_str_CaseProgressStatus), o.IsInvisible(_str_CaseProgressStatus), o.IsRequired(_str_CaseProgressStatus),
                  bChangeLookupContent ? o.CaseProgressStatusLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_CaseProgressStatus + "Lookup", _formname = _str_CaseProgressStatus + "Lookup", _type = "LookupContent",
              _get_func = o => o.CaseProgressStatusLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestsConducted, _formname = _str_TestsConducted, _type = "Lookup",
              _get_func = o => { if (o.TestsConducted == null) return null; return o.TestsConducted.idfsBaseReference; },
              _set_func = (o, val) => { o.TestsConducted = o.TestsConductedLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_TestsConducted, c);
                if (o.idfsYNTestsConducted != c.idfsYNTestsConducted || o.IsRIRPropChanged(_str_TestsConducted, c) || bChangeLookupContent) {
                  m.Add(_str_TestsConducted, o.ObjectIdent + _str_TestsConducted, o.ObjectIdent2 + _str_TestsConducted, o.ObjectIdent3 + _str_TestsConducted, "Lookup", o.idfsYNTestsConducted == null ? "" : o.idfsYNTestsConducted.ToString(), o.IsReadOnly(_str_TestsConducted), o.IsInvisible(_str_TestsConducted), o.IsRequired(_str_TestsConducted),
                  bChangeLookupContent ? o.TestsConductedLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_TestsConducted + "Lookup", _formname = _str_TestsConducted + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestsConductedLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_TentativeDiagnosis, _formname = _str_TentativeDiagnosis, _type = "Lookup",
              _get_func = o => { if (o.TentativeDiagnosis == null) return null; return o.TentativeDiagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.TentativeDiagnosis = o.TentativeDiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_TentativeDiagnosis, c);
                if (o.idfsTentativeDiagnosis != c.idfsTentativeDiagnosis || o.IsRIRPropChanged(_str_TentativeDiagnosis, c) || bChangeLookupContent) {
                  m.Add(_str_TentativeDiagnosis, o.ObjectIdent + _str_TentativeDiagnosis, o.ObjectIdent2 + _str_TentativeDiagnosis, o.ObjectIdent3 + _str_TentativeDiagnosis, "Lookup", o.idfsTentativeDiagnosis == null ? "" : o.idfsTentativeDiagnosis.ToString(), o.IsReadOnly(_str_TentativeDiagnosis), o.IsInvisible(_str_TentativeDiagnosis), o.IsRequired(_str_TentativeDiagnosis),
                  bChangeLookupContent ? o.TentativeDiagnosisLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_TentativeDiagnosis + "Lookup", _formname = _str_TentativeDiagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.TentativeDiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_TentativeDiagnosis1, _formname = _str_TentativeDiagnosis1, _type = "Lookup",
              _get_func = o => { if (o.TentativeDiagnosis1 == null) return null; return o.TentativeDiagnosis1.idfsDiagnosis; },
              _set_func = (o, val) => { o.TentativeDiagnosis1 = o.TentativeDiagnosis1Lookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_TentativeDiagnosis1, c);
                if (o.idfsTentativeDiagnosis1 != c.idfsTentativeDiagnosis1 || o.IsRIRPropChanged(_str_TentativeDiagnosis1, c) || bChangeLookupContent) {
                  m.Add(_str_TentativeDiagnosis1, o.ObjectIdent + _str_TentativeDiagnosis1, o.ObjectIdent2 + _str_TentativeDiagnosis1, o.ObjectIdent3 + _str_TentativeDiagnosis1, "Lookup", o.idfsTentativeDiagnosis1 == null ? "" : o.idfsTentativeDiagnosis1.ToString(), o.IsReadOnly(_str_TentativeDiagnosis1), o.IsInvisible(_str_TentativeDiagnosis1), o.IsRequired(_str_TentativeDiagnosis1),
                  bChangeLookupContent ? o.TentativeDiagnosis1Lookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_TentativeDiagnosis1 + "Lookup", _formname = _str_TentativeDiagnosis1 + "Lookup", _type = "LookupContent",
              _get_func = o => o.TentativeDiagnosis1Lookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_TentativeDiagnosis2, _formname = _str_TentativeDiagnosis2, _type = "Lookup",
              _get_func = o => { if (o.TentativeDiagnosis2 == null) return null; return o.TentativeDiagnosis2.idfsDiagnosis; },
              _set_func = (o, val) => { o.TentativeDiagnosis2 = o.TentativeDiagnosis2Lookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_TentativeDiagnosis2, c);
                if (o.idfsTentativeDiagnosis2 != c.idfsTentativeDiagnosis2 || o.IsRIRPropChanged(_str_TentativeDiagnosis2, c) || bChangeLookupContent) {
                  m.Add(_str_TentativeDiagnosis2, o.ObjectIdent + _str_TentativeDiagnosis2, o.ObjectIdent2 + _str_TentativeDiagnosis2, o.ObjectIdent3 + _str_TentativeDiagnosis2, "Lookup", o.idfsTentativeDiagnosis2 == null ? "" : o.idfsTentativeDiagnosis2.ToString(), o.IsReadOnly(_str_TentativeDiagnosis2), o.IsInvisible(_str_TentativeDiagnosis2), o.IsRequired(_str_TentativeDiagnosis2),
                  bChangeLookupContent ? o.TentativeDiagnosis2Lookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_TentativeDiagnosis2 + "Lookup", _formname = _str_TentativeDiagnosis2 + "Lookup", _type = "LookupContent",
              _get_func = o => o.TentativeDiagnosis2Lookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_FinalDiagnosis, _formname = _str_FinalDiagnosis, _type = "Lookup",
              _get_func = o => { if (o.FinalDiagnosis == null) return null; return o.FinalDiagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.FinalDiagnosis = o.FinalDiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_FinalDiagnosis, c);
                if (o.idfsFinalDiagnosis != c.idfsFinalDiagnosis || o.IsRIRPropChanged(_str_FinalDiagnosis, c) || bChangeLookupContent) {
                  m.Add(_str_FinalDiagnosis, o.ObjectIdent + _str_FinalDiagnosis, o.ObjectIdent2 + _str_FinalDiagnosis, o.ObjectIdent3 + _str_FinalDiagnosis, "Lookup", o.idfsFinalDiagnosis == null ? "" : o.idfsFinalDiagnosis.ToString(), o.IsReadOnly(_str_FinalDiagnosis), o.IsInvisible(_str_FinalDiagnosis), o.IsRequired(_str_FinalDiagnosis),
                  bChangeLookupContent ? o.FinalDiagnosisLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_FinalDiagnosis + "Lookup", _formname = _str_FinalDiagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.FinalDiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_ShowDiagnosis, _formname = _str_ShowDiagnosis, _type = "Lookup",
              _get_func = o => { if (o.ShowDiagnosis == null) return null; return o.ShowDiagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.ShowDiagnosis = o.ShowDiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_ShowDiagnosis, c);
                if (o.idfsShowDiagnosis != c.idfsShowDiagnosis || o.IsRIRPropChanged(_str_ShowDiagnosis, c) || bChangeLookupContent) {
                  m.Add(_str_ShowDiagnosis, o.ObjectIdent + _str_ShowDiagnosis, o.ObjectIdent2 + _str_ShowDiagnosis, o.ObjectIdent3 + _str_ShowDiagnosis, "Lookup", o.idfsShowDiagnosis == null ? "" : o.idfsShowDiagnosis.ToString(), o.IsReadOnly(_str_ShowDiagnosis), o.IsInvisible(_str_ShowDiagnosis), o.IsRequired(_str_ShowDiagnosis),
                  bChangeLookupContent ? o.ShowDiagnosisLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_ShowDiagnosis + "Lookup", _formname = _str_ShowDiagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.ShowDiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_PersonInvestigatedBy, _formname = _str_PersonInvestigatedBy, _type = "Lookup",
              _get_func = o => { if (o.PersonInvestigatedBy == null) return null; return o.PersonInvestigatedBy.idfPerson; },
              _set_func = (o, val) => { o.PersonInvestigatedBy = o.PersonInvestigatedByLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_PersonInvestigatedBy, c);
                if (o.idfPersonInvestigatedBy != c.idfPersonInvestigatedBy || o.IsRIRPropChanged(_str_PersonInvestigatedBy, c) || bChangeLookupContent) {
                  m.Add(_str_PersonInvestigatedBy, o.ObjectIdent + _str_PersonInvestigatedBy, o.ObjectIdent2 + _str_PersonInvestigatedBy, o.ObjectIdent3 + _str_PersonInvestigatedBy, "Lookup", o.idfPersonInvestigatedBy == null ? "" : o.idfPersonInvestigatedBy.ToString(), o.IsReadOnly(_str_PersonInvestigatedBy), o.IsInvisible(_str_PersonInvestigatedBy), o.IsRequired(_str_PersonInvestigatedBy),
                  bChangeLookupContent ? o.PersonInvestigatedByLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_PersonInvestigatedBy + "Lookup", _formname = _str_PersonInvestigatedBy + "Lookup", _type = "LookupContent",
              _get_func = o => o.PersonInvestigatedByLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Vaccination, _formname = _str_Vaccination, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Vaccination.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Vaccination.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.Vaccination.Count != c.Vaccination.Count || o.IsReadOnly(_str_Vaccination) != c.IsReadOnly(_str_Vaccination) || o.IsInvisible(_str_Vaccination) != c.IsInvisible(_str_Vaccination) || o.IsRequired(_str_Vaccination) != c._isRequired(o.m_isRequired, _str_Vaccination)) {
                  m.Add(_str_Vaccination, o.ObjectIdent + _str_Vaccination, o.ObjectIdent2 + _str_Vaccination, o.ObjectIdent3 + _str_Vaccination, "Child", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_Vaccination), o.IsInvisible(_str_Vaccination), o.IsRequired(_str_Vaccination)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_CaseTests, _formname = _str_CaseTests, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.CaseTests.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.CaseTests.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.CaseTests.Count != c.CaseTests.Count || o.IsReadOnly(_str_CaseTests) != c.IsReadOnly(_str_CaseTests) || o.IsInvisible(_str_CaseTests) != c.IsInvisible(_str_CaseTests) || o.IsRequired(_str_CaseTests) != c._isRequired(o.m_isRequired, _str_CaseTests)) {
                  m.Add(_str_CaseTests, o.ObjectIdent + _str_CaseTests, o.ObjectIdent2 + _str_CaseTests, o.ObjectIdent3 + _str_CaseTests, "Child", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_CaseTests), o.IsInvisible(_str_CaseTests), o.IsRequired(_str_CaseTests)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_CaseTestValidations, _formname = _str_CaseTestValidations, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.CaseTestValidations.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.CaseTestValidations.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.CaseTestValidations.Count != c.CaseTestValidations.Count || o.IsReadOnly(_str_CaseTestValidations) != c.IsReadOnly(_str_CaseTestValidations) || o.IsInvisible(_str_CaseTestValidations) != c.IsInvisible(_str_CaseTestValidations) || o.IsRequired(_str_CaseTestValidations) != c._isRequired(o.m_isRequired, _str_CaseTestValidations)) {
                  m.Add(_str_CaseTestValidations, o.ObjectIdent + _str_CaseTestValidations, o.ObjectIdent2 + _str_CaseTestValidations, o.ObjectIdent3 + _str_CaseTestValidations, "Child", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_CaseTestValidations), o.IsInvisible(_str_CaseTestValidations), o.IsRequired(_str_CaseTestValidations)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_PensideTests, _formname = _str_PensideTests, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.PensideTests.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.PensideTests.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.PensideTests.Count != c.PensideTests.Count || o.IsReadOnly(_str_PensideTests) != c.IsReadOnly(_str_PensideTests) || o.IsInvisible(_str_PensideTests) != c.IsInvisible(_str_PensideTests) || o.IsRequired(_str_PensideTests) != c._isRequired(o.m_isRequired, _str_PensideTests)) {
                  m.Add(_str_PensideTests, o.ObjectIdent + _str_PensideTests, o.ObjectIdent2 + _str_PensideTests, o.ObjectIdent3 + _str_PensideTests, "Child", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_PensideTests), o.IsInvisible(_str_PensideTests), o.IsRequired(_str_PensideTests)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_AnimalList, _formname = _str_AnimalList, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.AnimalList.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.AnimalList.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.AnimalList.Count != c.AnimalList.Count || o.IsReadOnly(_str_AnimalList) != c.IsReadOnly(_str_AnimalList) || o.IsInvisible(_str_AnimalList) != c.IsInvisible(_str_AnimalList) || o.IsRequired(_str_AnimalList) != c._isRequired(o.m_isRequired, _str_AnimalList)) {
                  m.Add(_str_AnimalList, o.ObjectIdent + _str_AnimalList, o.ObjectIdent2 + _str_AnimalList, o.ObjectIdent3 + _str_AnimalList, "Child", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_AnimalList), o.IsInvisible(_str_AnimalList), o.IsRequired(_str_AnimalList)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Samples, _formname = _str_Samples, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Samples.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Samples.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.Samples.Count != c.Samples.Count || o.IsReadOnly(_str_Samples) != c.IsReadOnly(_str_Samples) || o.IsInvisible(_str_Samples) != c.IsInvisible(_str_Samples) || o.IsRequired(_str_Samples) != c._isRequired(o.m_isRequired, _str_Samples)) {
                  m.Add(_str_Samples, o.ObjectIdent + _str_Samples, o.ObjectIdent2 + _str_Samples, o.ObjectIdent3 + _str_Samples, "Child", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_Samples), o.IsInvisible(_str_Samples), o.IsRequired(_str_Samples)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Logs, _formname = _str_Logs, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Logs.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Logs.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.Logs.Count != c.Logs.Count || o.IsReadOnly(_str_Logs) != c.IsReadOnly(_str_Logs) || o.IsInvisible(_str_Logs) != c.IsInvisible(_str_Logs) || o.IsRequired(_str_Logs) != c._isRequired(o.m_isRequired, _str_Logs)) {
                  m.Add(_str_Logs, o.ObjectIdent + _str_Logs, o.ObjectIdent2 + _str_Logs, o.ObjectIdent3 + _str_Logs, "Child", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_Logs), o.IsInvisible(_str_Logs), o.IsRequired(_str_Logs)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_FFPresenterControlMeasures, _formname = _str_FFPresenterControlMeasures, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.FFPresenterControlMeasures != null) o.FFPresenterControlMeasures._compare(c.FFPresenterControlMeasures, m); }
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
            VetCase obj = (VetCase)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_FFPresenterControlMeasures)]
        [Relation(typeof(FFPresenterModel), eidss.model.Schema.FFPresenterModel._str_CurrentObservation, _str_idfObservation)]
        public FFPresenterModel FFPresenterControlMeasures
        {
            get 
            {   
                return _FFPresenterControlMeasures; 
            }
            set 
            {   
                _FFPresenterControlMeasures = value;
                if (_FFPresenterControlMeasures != null) 
                { 
                    _FFPresenterControlMeasures.m_ObjectName = _str_FFPresenterControlMeasures;
                    _FFPresenterControlMeasures.Parent = this;
                }
                idfObservation = _FFPresenterControlMeasures == null 
                        ? new Int64?()
                        : _FFPresenterControlMeasures.CurrentObservation;
                
            }
        }
        protected FFPresenterModel _FFPresenterControlMeasures;
                    
        [LocalizedDisplayName(_str_Farm)]
        [Relation(typeof(FarmPanel), eidss.model.Schema.FarmPanel._str_idfFarm, _str_idfFarm)]
        public FarmPanel Farm
        {
            get 
            {   
                if (!_FarmLoaded)
                {
                    _FarmLoaded = true;
                    _getAccessor()._LoadFarm(this);
                    if (_Farm != null) 
                        _Farm.Parent = this;
                }
                return _Farm; 
            }
            set 
            {   
                if (!_FarmLoaded) { _FarmLoaded = true; }
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
                    
        private bool _FarmLoaded = false;
                    
        [LocalizedDisplayName(_str_Vaccination)]
        [Relation(typeof(VaccinationListItem), "", _str_idfCase)]
        public EditableList<VaccinationListItem> Vaccination
        {
            get 
            {   
                return _Vaccination; 
            }
            set 
            {
                _Vaccination = value;
            }
        }
        protected EditableList<VaccinationListItem> _Vaccination = new EditableList<VaccinationListItem>();
                    
        [LocalizedDisplayName(_str_CaseTests)]
        [Relation(typeof(CaseTest), "", _str_idfCase)]
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
                    
        [LocalizedDisplayName(_str_CaseTestValidations)]
        [Relation(typeof(CaseTestValidation), "", _str_idfCase)]
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
                    
        [LocalizedDisplayName(_str_PensideTests)]
        [Relation(typeof(PensideTest), "", _str_idfCase)]
        public EditableList<PensideTest> PensideTests
        {
            get 
            {   
                return _PensideTests; 
            }
            set 
            {
                _PensideTests = value;
            }
        }
        protected EditableList<PensideTest> _PensideTests = new EditableList<PensideTest>();
                    
        [LocalizedDisplayName(_str_AnimalList)]
        [Relation(typeof(AnimalListItem), eidss.model.Schema.AnimalListItem._str_idfCase, _str_idfCase)]
        public EditableList<AnimalListItem> AnimalList
        {
            get 
            {   
                return _AnimalList; 
            }
            set 
            {
                _AnimalList = value;
            }
        }
        protected EditableList<AnimalListItem> _AnimalList = new EditableList<AnimalListItem>();
                    
        [LocalizedDisplayName(_str_Samples)]
        [Relation(typeof(VetCaseSample), eidss.model.Schema.VetCaseSample._str_idfCase, _str_idfCase)]
        public EditableList<VetCaseSample> Samples
        {
            get 
            {   
                return _Samples; 
            }
            set 
            {
                _Samples = value;
            }
        }
        protected EditableList<VetCaseSample> _Samples = new EditableList<VetCaseSample>();
                    
        [LocalizedDisplayName(_str_Logs)]
        [Relation(typeof(VetCaseLog), eidss.model.Schema.VetCaseLog._str_idfVetCase, _str_idfCase)]
        public EditableList<VetCaseLog> Logs
        {
            get 
            {   
                return _Logs; 
            }
            set 
            {
                _Logs = value;
            }
        }
        protected EditableList<VetCaseLog> _Logs = new EditableList<VetCaseLog>();
                    
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
            
        [LocalizedDisplayName(_str_CaseReportType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseReportType)]
        public BaseReference CaseReportType
        {
            get { return _CaseReportType == null ? null : ((long)_CaseReportType.Key == 0 ? null : _CaseReportType); }
            set 
            { 
                var oldVal = _CaseReportType;
                _CaseReportType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_CaseReportType != oldVal)
                {
                    if (idfsCaseReportType != (_CaseReportType == null
                            ? new Int64?()
                            : (Int64?)_CaseReportType.idfsBaseReference))
                        idfsCaseReportType = _CaseReportType == null 
                            ? new Int64?()
                            : (Int64?)_CaseReportType.idfsBaseReference; 
                    OnPropertyChanged(_str_CaseReportType); 
                }
            }
        }
        private BaseReference _CaseReportType;

        
        public BaseReferenceList CaseReportTypeLookup
        {
            get { return _CaseReportTypeLookup; }
        }
        private BaseReferenceList _CaseReportTypeLookup = new BaseReferenceList("rftCaseReportType");
            
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
            
        [LocalizedDisplayName(_str_CaseClassification)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseClassification)]
        public BaseReference CaseClassification
        {
            get { return _CaseClassification == null ? null : ((long)_CaseClassification.Key == 0 ? null : _CaseClassification); }
            set 
            { 
                var oldVal = _CaseClassification;
                _CaseClassification = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_CaseClassification != oldVal)
                {
                    if (idfsCaseClassification != (_CaseClassification == null
                            ? new Int64?()
                            : (Int64?)_CaseClassification.idfsBaseReference))
                        idfsCaseClassification = _CaseClassification == null 
                            ? new Int64?()
                            : (Int64?)_CaseClassification.idfsBaseReference; 
                    OnPropertyChanged(_str_CaseClassification); 
                }
            }
        }
        private BaseReference _CaseClassification;

        
        public BaseReferenceList CaseClassificationLookup
        {
            get { return _CaseClassificationLookup; }
        }
        private BaseReferenceList _CaseClassificationLookup = new BaseReferenceList("rftCaseClassification");
            
        [LocalizedDisplayName(_str_CaseProgressStatus)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseProgressStatus)]
        public BaseReference CaseProgressStatus
        {
            get { return _CaseProgressStatus; }
            set 
            { 
                var oldVal = _CaseProgressStatus;
                _CaseProgressStatus = value;
                if (_CaseProgressStatus != oldVal)
                {
                    if (idfsCaseProgressStatus != (_CaseProgressStatus == null
                            ? new Int64?()
                            : (Int64?)_CaseProgressStatus.idfsBaseReference))
                        idfsCaseProgressStatus = _CaseProgressStatus == null 
                            ? new Int64?()
                            : (Int64?)_CaseProgressStatus.idfsBaseReference; 
                    OnPropertyChanged(_str_CaseProgressStatus); 
                }
            }
        }
        private BaseReference _CaseProgressStatus;

        
        public BaseReferenceList CaseProgressStatusLookup
        {
            get { return _CaseProgressStatusLookup; }
        }
        private BaseReferenceList _CaseProgressStatusLookup = new BaseReferenceList("rftCaseProgressStatus");
            
        [LocalizedDisplayName(_str_TestsConducted)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNTestsConducted)]
        public BaseReference TestsConducted
        {
            get { return _TestsConducted == null ? null : ((long)_TestsConducted.Key == 0 ? null : _TestsConducted); }
            set 
            { 
                var oldVal = _TestsConducted;
                _TestsConducted = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestsConducted != oldVal)
                {
                    if (idfsYNTestsConducted != (_TestsConducted == null
                            ? new Int64?()
                            : (Int64?)_TestsConducted.idfsBaseReference))
                        idfsYNTestsConducted = _TestsConducted == null 
                            ? new Int64?()
                            : (Int64?)_TestsConducted.idfsBaseReference; 
                    OnPropertyChanged(_str_TestsConducted); 
                }
            }
        }
        private BaseReference _TestsConducted;

        
        public BaseReferenceList TestsConductedLookup
        {
            get { return _TestsConductedLookup; }
        }
        private BaseReferenceList _TestsConductedLookup = new BaseReferenceList("rftYesNoValue");
            
        [LocalizedDisplayName(_str_TentativeDiagnosis)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsTentativeDiagnosis)]
        public DiagnosisLookup TentativeDiagnosis
        {
            get { return _TentativeDiagnosis == null ? null : ((long)_TentativeDiagnosis.Key == 0 ? null : _TentativeDiagnosis); }
            set 
            { 
                var oldVal = _TentativeDiagnosis;
                _TentativeDiagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TentativeDiagnosis != oldVal)
                {
                    if (idfsTentativeDiagnosis != (_TentativeDiagnosis == null
                            ? new Int64?()
                            : (Int64?)_TentativeDiagnosis.idfsDiagnosis))
                        idfsTentativeDiagnosis = _TentativeDiagnosis == null 
                            ? new Int64?()
                            : (Int64?)_TentativeDiagnosis.idfsDiagnosis; 
                    OnPropertyChanged(_str_TentativeDiagnosis); 
                }
            }
        }
        private DiagnosisLookup _TentativeDiagnosis;

        
        public List<DiagnosisLookup> TentativeDiagnosisLookup
        {
            get { return _TentativeDiagnosisLookup; }
        }
        private List<DiagnosisLookup> _TentativeDiagnosisLookup = new List<DiagnosisLookup>();
            
        [LocalizedDisplayName(_str_TentativeDiagnosis1)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsTentativeDiagnosis1)]
        public DiagnosisLookup TentativeDiagnosis1
        {
            get { return _TentativeDiagnosis1 == null ? null : ((long)_TentativeDiagnosis1.Key == 0 ? null : _TentativeDiagnosis1); }
            set 
            { 
                var oldVal = _TentativeDiagnosis1;
                _TentativeDiagnosis1 = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TentativeDiagnosis1 != oldVal)
                {
                    if (idfsTentativeDiagnosis1 != (_TentativeDiagnosis1 == null
                            ? new Int64?()
                            : (Int64?)_TentativeDiagnosis1.idfsDiagnosis))
                        idfsTentativeDiagnosis1 = _TentativeDiagnosis1 == null 
                            ? new Int64?()
                            : (Int64?)_TentativeDiagnosis1.idfsDiagnosis; 
                    OnPropertyChanged(_str_TentativeDiagnosis1); 
                }
            }
        }
        private DiagnosisLookup _TentativeDiagnosis1;

        
        public List<DiagnosisLookup> TentativeDiagnosis1Lookup
        {
            get { return _TentativeDiagnosis1Lookup; }
        }
        private List<DiagnosisLookup> _TentativeDiagnosis1Lookup = new List<DiagnosisLookup>();
            
        [LocalizedDisplayName(_str_TentativeDiagnosis2)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsTentativeDiagnosis2)]
        public DiagnosisLookup TentativeDiagnosis2
        {
            get { return _TentativeDiagnosis2 == null ? null : ((long)_TentativeDiagnosis2.Key == 0 ? null : _TentativeDiagnosis2); }
            set 
            { 
                var oldVal = _TentativeDiagnosis2;
                _TentativeDiagnosis2 = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TentativeDiagnosis2 != oldVal)
                {
                    if (idfsTentativeDiagnosis2 != (_TentativeDiagnosis2 == null
                            ? new Int64?()
                            : (Int64?)_TentativeDiagnosis2.idfsDiagnosis))
                        idfsTentativeDiagnosis2 = _TentativeDiagnosis2 == null 
                            ? new Int64?()
                            : (Int64?)_TentativeDiagnosis2.idfsDiagnosis; 
                    OnPropertyChanged(_str_TentativeDiagnosis2); 
                }
            }
        }
        private DiagnosisLookup _TentativeDiagnosis2;

        
        public List<DiagnosisLookup> TentativeDiagnosis2Lookup
        {
            get { return _TentativeDiagnosis2Lookup; }
        }
        private List<DiagnosisLookup> _TentativeDiagnosis2Lookup = new List<DiagnosisLookup>();
            
        [LocalizedDisplayName(_str_FinalDiagnosis)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsFinalDiagnosis)]
        public DiagnosisLookup FinalDiagnosis
        {
            get { return _FinalDiagnosis == null ? null : ((long)_FinalDiagnosis.Key == 0 ? null : _FinalDiagnosis); }
            set 
            { 
                var oldVal = _FinalDiagnosis;
                _FinalDiagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_FinalDiagnosis != oldVal)
                {
                    if (idfsFinalDiagnosis != (_FinalDiagnosis == null
                            ? new Int64?()
                            : (Int64?)_FinalDiagnosis.idfsDiagnosis))
                        idfsFinalDiagnosis = _FinalDiagnosis == null 
                            ? new Int64?()
                            : (Int64?)_FinalDiagnosis.idfsDiagnosis; 
                    OnPropertyChanged(_str_FinalDiagnosis); 
                }
            }
        }
        private DiagnosisLookup _FinalDiagnosis;

        
        public List<DiagnosisLookup> FinalDiagnosisLookup
        {
            get { return _FinalDiagnosisLookup; }
        }
        private List<DiagnosisLookup> _FinalDiagnosisLookup = new List<DiagnosisLookup>();
            
        [LocalizedDisplayName(_str_ShowDiagnosis)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsShowDiagnosis)]
        public DiagnosisLookup ShowDiagnosis
        {
            get { return _ShowDiagnosis == null ? null : ((long)_ShowDiagnosis.Key == 0 ? null : _ShowDiagnosis); }
            set 
            { 
                var oldVal = _ShowDiagnosis;
                _ShowDiagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_ShowDiagnosis != oldVal)
                {
                    if (idfsShowDiagnosis != (_ShowDiagnosis == null
                            ? new Int64?()
                            : (Int64?)_ShowDiagnosis.idfsDiagnosis))
                        idfsShowDiagnosis = _ShowDiagnosis == null 
                            ? new Int64?()
                            : (Int64?)_ShowDiagnosis.idfsDiagnosis; 
                    OnPropertyChanged(_str_ShowDiagnosis); 
                }
            }
        }
        private DiagnosisLookup _ShowDiagnosis;

        
        public List<DiagnosisLookup> ShowDiagnosisLookup
        {
            get { return _ShowDiagnosisLookup; }
        }
        private List<DiagnosisLookup> _ShowDiagnosisLookup = new List<DiagnosisLookup>();
            
        [LocalizedDisplayName(_str_PersonInvestigatedBy)]
        [Relation(typeof(WiderPersonLookup), eidss.model.Schema.WiderPersonLookup._str_idfPerson, _str_idfPersonInvestigatedBy)]
        public WiderPersonLookup PersonInvestigatedBy
        {
            get { return _PersonInvestigatedBy == null ? null : ((long)_PersonInvestigatedBy.Key == 0 ? null : _PersonInvestigatedBy); }
            set 
            { 
                var oldVal = _PersonInvestigatedBy;
                _PersonInvestigatedBy = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_PersonInvestigatedBy != oldVal)
                {
                    if (idfPersonInvestigatedBy != (_PersonInvestigatedBy == null
                            ? new Int64?()
                            : (Int64?)_PersonInvestigatedBy.idfPerson))
                        idfPersonInvestigatedBy = _PersonInvestigatedBy == null 
                            ? new Int64?()
                            : (Int64?)_PersonInvestigatedBy.idfPerson; 
                    OnPropertyChanged(_str_PersonInvestigatedBy); 
                }
            }
        }
        private WiderPersonLookup _PersonInvestigatedBy;

        
        public List<WiderPersonLookup> PersonInvestigatedByLookup
        {
            get { return _PersonInvestigatedByLookup; }
        }
        private List<WiderPersonLookup> _PersonInvestigatedByLookup = new List<WiderPersonLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Site:
                    return new BvSelectList(SiteLookup, eidss.model.Schema.SiteLookup._str_idfsSite, null, Site, _str_idfsSite);
            
                case _str_CaseReportType:
                    return new BvSelectList(CaseReportTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseReportType, _str_idfsCaseReportType);
            
                case _str_CaseType:
                    return new BvSelectList(CaseTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseType, _str_idfsCaseType);
            
                case _str_CaseClassification:
                    return new BvSelectList(CaseClassificationLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseClassification, _str_idfsCaseClassification);
            
                case _str_CaseProgressStatus:
                    return new BvSelectList(CaseProgressStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseProgressStatus, _str_idfsCaseProgressStatus);
            
                case _str_TestsConducted:
                    return new BvSelectList(TestsConductedLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestsConducted, _str_idfsYNTestsConducted);
            
                case _str_TentativeDiagnosis:
                    return new BvSelectList(TentativeDiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, TentativeDiagnosis, _str_idfsTentativeDiagnosis);
            
                case _str_TentativeDiagnosis1:
                    return new BvSelectList(TentativeDiagnosis1Lookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, TentativeDiagnosis1, _str_idfsTentativeDiagnosis1);
            
                case _str_TentativeDiagnosis2:
                    return new BvSelectList(TentativeDiagnosis2Lookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, TentativeDiagnosis2, _str_idfsTentativeDiagnosis2);
            
                case _str_FinalDiagnosis:
                    return new BvSelectList(FinalDiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, FinalDiagnosis, _str_idfsFinalDiagnosis);
            
                case _str_ShowDiagnosis:
                    return new BvSelectList(ShowDiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, ShowDiagnosis, _str_idfsShowDiagnosis);
            
                case _str_PersonInvestigatedBy:
                    return new BvSelectList(PersonInvestigatedByLookup, eidss.model.Schema.WiderPersonLookup._str_idfPerson, null, PersonInvestigatedBy, _str_idfPersonInvestigatedBy);
            
                case _str_Vaccination:
                    return new BvSelectList(Vaccination, "", "", null, "");
            
                case _str_CaseTests:
                    return new BvSelectList(CaseTests, "", "", null, "");
            
                case _str_CaseTestValidations:
                    return new BvSelectList(CaseTestValidations, "", "", null, "");
            
                case _str_PensideTests:
                    return new BvSelectList(PensideTests, "", "", null, "");
            
                case _str_AnimalList:
                    return new BvSelectList(AnimalList, "", "", null, "");
            
                case _str_Samples:
                    return new BvSelectList(Samples, "", "", null, "");
            
                case _str_Logs:
                    return new BvSelectList(Logs, "", "", null, "");
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strFinalDiagnosis)]
        public string strFinalDiagnosis
        {
            get { return new Func<VetCase, string>(c => (c.FinalDiagnosis == null) ? "" : c.FinalDiagnosis.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("TentativeDiagnoses")]
        public string strDiagnosis
        {
            get { return new Func<VetCase, string>(c => String.Format("{0}{1}{2}", 
                              (c.TentativeDiagnosis2 == null) ? "" : c.TentativeDiagnosis2.name,
                              (c.TentativeDiagnosis1 == null) ? "" : ((c.TentativeDiagnosis2 == null) ? "" : ", ")  + c.TentativeDiagnosis1.name,
                              (c.TentativeDiagnosis == null) ? "" : ((c.TentativeDiagnosis2 == null && c.TentativeDiagnosis1 == null) ? "" : ", ")  + c.TentativeDiagnosis.name
                               ))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_DiagnosisAll)]
        public List<DiagnosisLookup> DiagnosisAll
        {
            get { return new Func<VetCase, List<DiagnosisLookup>>(c => new List<DiagnosisLookup>(new []
                                    { c.FinalDiagnosis, c.TentativeDiagnosis2, c.TentativeDiagnosis1, c.TentativeDiagnosis }
                                    .Where(d => d != null).Distinct()))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strDiseaseNames)]
        public string strDiseaseNames
        {
            get { return new Func<VetCase, string>(c => c.DiagnosisAll.Aggregate("", 
                                    (a,b) => (a == "" ? "" : a + ", ") 
                                    + b.name + (String.IsNullOrEmpty(b.strOIECode) ? "" : "(" + b.strOIECode + ")")))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsClosed)]
        public bool IsClosed
        {
            get { return new Func<VetCase, bool>(c => (c.idfsCaseProgressStatus == (long)CaseStatusEnum.Closed) && !c.IsDirty)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsEnabledCaseProgressStatus)]
        public bool IsEnabledCaseProgressStatus
        {
            get { return new Func<VetCase, bool>(c => (!c.idfsCaseProgressStatus.HasValue) || (c.idfsCaseProgressStatus == (long)CaseStatusEnum.InProgress) || (c.idfsCaseProgressStatus == (long)CaseStatusEnum.Closed && c.IsDirty) || (c.idfsCaseProgressStatus == (long)CaseStatusEnum.Closed && !c.IsDirty && c.GetPermissions().CanExecute("CanReopenClosedCase")))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsDiagnosis)]
        public long? idfsDiagnosis
        {
            get { return new Func<VetCase, long?>(c=>
                                  c.idfsFinalDiagnosis.HasValue ? c.idfsFinalDiagnosis :
                                    c.idfsTentativeDiagnosis2.HasValue ? c.idfsTentativeDiagnosis2 :
                                      c.idfsTentativeDiagnosis1.HasValue ? c.idfsTentativeDiagnosis1 :
                                        c.idfsTentativeDiagnosis.HasValue ? c.idfsTentativeDiagnosis : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strSiteCode)]
        public string strSiteCode
        {
            get { return new Func<VetCase, string>(c => c.Site == null ? "" : c.Site.strSiteName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strIdfsDiagnosis)]
        public string strIdfsDiagnosis
        {
            get { return new Func<VetCase, string>(c=> c.idfsFinalDiagnosis.HasValue ? c.idfsFinalDiagnosis.ToString() :                                    
                                        c.idfsTentativeDiagnosis.HasValue ? c.idfsTentativeDiagnosis.ToString() : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyEnteredDate)]
        public string strReadOnlyEnteredDate
        {
            get { return new Func<VetCase, string>(c => c.datEnteredDate == null ? (string)null : c.datEnteredDate.Value.ToString())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_buttonSelectFarm)]
        public string buttonSelectFarm
        {
            get { return new Func<VetCase, string>(c=> "")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_buttonCoordinatesPicker)]
        public string buttonCoordinatesPicker
        {
            get { return new Func<VetCase, string>(c => "")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_blnEnableTestsConductedCalc)]
        public bool blnEnableTestsConductedCalc
        {
            get { return new Func<VetCase, bool>(c => c.CaseTests == null || c.CaseTests.Where(i => !i.IsMarkedToDelete && i.idfsTestStatus == (long)TestStatus.Finalized).Count() == 0)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfObservationFarm)]
        public long idfObservationFarm
        {
            get { return new Func<VetCase, long>(c => c.Farm != null && c.Farm.idfObservation.HasValue ? c.Farm.idfObservation.Value : 0)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsLiveStock)]
        public bool IsLiveStock
        {
            get { return new Func<VetCase, bool>(c => c.idfsCaseType == (long)CaseTypeEnum.Livestock)(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VetCase";

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
        
            if (_FFPresenterControlMeasures != null) { _FFPresenterControlMeasures.Parent = this; }
                
            if (_Farm != null) { _Farm.Parent = this; }
                Vaccination.ForEach(c => { c.Parent = this; });
                CaseTests.ForEach(c => { c.Parent = this; });
                CaseTestValidations.ForEach(c => { c.Parent = this; });
                PensideTests.ForEach(c => { c.Parent = this; });
                AnimalList.ForEach(c => { c.Parent = this; });
                Samples.ForEach(c => { c.Parent = this; });
                Logs.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as VetCase;
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
            var ret = base.Clone() as VetCase;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_FFPresenterControlMeasures != null)
              ret.FFPresenterControlMeasures = _FFPresenterControlMeasures.CloneWithSetup(manager, bRestricted) as FFPresenterModel;
                
            if (_Farm != null)
              ret.Farm = _Farm.CloneWithSetup(manager, bRestricted) as FarmPanel;
                
            if (_Vaccination != null && _Vaccination.Count > 0)
            {
              ret.Vaccination.Clear();
              _Vaccination.ForEach(c => ret.Vaccination.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_CaseTests != null && _CaseTests.Count > 0)
            {
              ret.CaseTests.Clear();
              _CaseTests.ForEach(c => ret.CaseTests.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_CaseTestValidations != null && _CaseTestValidations.Count > 0)
            {
              ret.CaseTestValidations.Clear();
              _CaseTestValidations.ForEach(c => ret.CaseTestValidations.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_PensideTests != null && _PensideTests.Count > 0)
            {
              ret.PensideTests.Clear();
              _PensideTests.ForEach(c => ret.PensideTests.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_AnimalList != null && _AnimalList.Count > 0)
            {
              ret.AnimalList.Clear();
              _AnimalList.ForEach(c => ret.AnimalList.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_Samples != null && _Samples.Count > 0)
            {
              ret.Samples.Clear();
              _Samples.ForEach(c => ret.Samples.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_Logs != null && _Logs.Count > 0)
            {
              ret.Logs.Clear();
              _Logs.ForEach(c => ret.Logs.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public VetCase CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VetCase;
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
        
                    || (_FFPresenterControlMeasures != null && _FFPresenterControlMeasures.HasChanges)
                
                    || (_Farm != null && _Farm.HasChanges)
                
                    || Vaccination.IsDirty
                    || Vaccination.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || CaseTests.IsDirty
                    || CaseTests.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || CaseTestValidations.IsDirty
                    || CaseTestValidations.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || PensideTests.IsDirty
                    || PensideTests.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || AnimalList.IsDirty
                    || AnimalList.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Samples.IsDirty
                    || Samples.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Logs.IsDirty
                    || Logs.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsSite_Site = idfsSite;
            var _prev_idfsCaseReportType_CaseReportType = idfsCaseReportType;
            var _prev_idfsCaseType_CaseType = idfsCaseType;
            var _prev_idfsCaseClassification_CaseClassification = idfsCaseClassification;
            var _prev_idfsCaseProgressStatus_CaseProgressStatus = idfsCaseProgressStatus;
            var _prev_idfsYNTestsConducted_TestsConducted = idfsYNTestsConducted;
            var _prev_idfsTentativeDiagnosis_TentativeDiagnosis = idfsTentativeDiagnosis;
            var _prev_idfsTentativeDiagnosis1_TentativeDiagnosis1 = idfsTentativeDiagnosis1;
            var _prev_idfsTentativeDiagnosis2_TentativeDiagnosis2 = idfsTentativeDiagnosis2;
            var _prev_idfsFinalDiagnosis_FinalDiagnosis = idfsFinalDiagnosis;
            var _prev_idfsShowDiagnosis_ShowDiagnosis = idfsShowDiagnosis;
            var _prev_idfPersonInvestigatedBy_PersonInvestigatedBy = idfPersonInvestigatedBy;
            base.RejectChanges();
        
            if (_prev_idfsSite_Site != idfsSite)
            {
                _Site = _SiteLookup.FirstOrDefault(c => c.idfsSite == idfsSite);
            }
            if (_prev_idfsCaseReportType_CaseReportType != idfsCaseReportType)
            {
                _CaseReportType = _CaseReportTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseReportType);
            }
            if (_prev_idfsCaseType_CaseType != idfsCaseType)
            {
                _CaseType = _CaseTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseType);
            }
            if (_prev_idfsCaseClassification_CaseClassification != idfsCaseClassification)
            {
                _CaseClassification = _CaseClassificationLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseClassification);
            }
            if (_prev_idfsCaseProgressStatus_CaseProgressStatus != idfsCaseProgressStatus)
            {
                _CaseProgressStatus = _CaseProgressStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseProgressStatus);
            }
            if (_prev_idfsYNTestsConducted_TestsConducted != idfsYNTestsConducted)
            {
                _TestsConducted = _TestsConductedLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNTestsConducted);
            }
            if (_prev_idfsTentativeDiagnosis_TentativeDiagnosis != idfsTentativeDiagnosis)
            {
                _TentativeDiagnosis = _TentativeDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsTentativeDiagnosis);
            }
            if (_prev_idfsTentativeDiagnosis1_TentativeDiagnosis1 != idfsTentativeDiagnosis1)
            {
                _TentativeDiagnosis1 = _TentativeDiagnosis1Lookup.FirstOrDefault(c => c.idfsDiagnosis == idfsTentativeDiagnosis1);
            }
            if (_prev_idfsTentativeDiagnosis2_TentativeDiagnosis2 != idfsTentativeDiagnosis2)
            {
                _TentativeDiagnosis2 = _TentativeDiagnosis2Lookup.FirstOrDefault(c => c.idfsDiagnosis == idfsTentativeDiagnosis2);
            }
            if (_prev_idfsFinalDiagnosis_FinalDiagnosis != idfsFinalDiagnosis)
            {
                _FinalDiagnosis = _FinalDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsFinalDiagnosis);
            }
            if (_prev_idfsShowDiagnosis_ShowDiagnosis != idfsShowDiagnosis)
            {
                _ShowDiagnosis = _ShowDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsShowDiagnosis);
            }
            if (_prev_idfPersonInvestigatedBy_PersonInvestigatedBy != idfPersonInvestigatedBy)
            {
                _PersonInvestigatedBy = _PersonInvestigatedByLookup.FirstOrDefault(c => c.idfPerson == idfPersonInvestigatedBy);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (FFPresenterControlMeasures != null) FFPresenterControlMeasures.DeepRejectChanges();
                
            if (Farm != null) Farm.DeepRejectChanges();
                Vaccination.DeepRejectChanges();
                CaseTests.DeepRejectChanges();
                CaseTestValidations.DeepRejectChanges();
                PensideTests.DeepRejectChanges();
                AnimalList.DeepRejectChanges();
                Samples.DeepRejectChanges();
                Logs.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_FFPresenterControlMeasures != null) _FFPresenterControlMeasures.DeepAcceptChanges();
                
            if (_Farm != null) _Farm.DeepAcceptChanges();
                Vaccination.DeepAcceptChanges();
                CaseTests.DeepAcceptChanges();
                CaseTestValidations.DeepAcceptChanges();
                PensideTests.DeepAcceptChanges();
                AnimalList.DeepAcceptChanges();
                Samples.DeepAcceptChanges();
                Logs.DeepAcceptChanges();
                
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
        
            if (_FFPresenterControlMeasures != null) _FFPresenterControlMeasures.SetChange();
                
            if (_Farm != null) _Farm.SetChange();
                Vaccination.ForEach(c => c.SetChange());
                CaseTests.ForEach(c => c.SetChange());
                CaseTestValidations.ForEach(c => c.SetChange());
                PensideTests.ForEach(c => c.SetChange());
                AnimalList.ForEach(c => c.SetChange());
                Samples.ForEach(c => c.SetChange());
                Logs.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, VetCase c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, VetCase c)
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
        

      

        public VetCase()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VetCase_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VetCase_PropertyChanged);
        }
        private void VetCase_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VetCase).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsFinalDiagnosis)
                OnPropertyChanged(_str_strFinalDiagnosis);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis2)
                OnPropertyChanged(_str_strDiagnosis);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis1)
                OnPropertyChanged(_str_strDiagnosis);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis)
                OnPropertyChanged(_str_strDiagnosis);
                  
            if (e.PropertyName == _str_idfsFinalDiagnosis)
                OnPropertyChanged(_str_DiagnosisAll);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis2)
                OnPropertyChanged(_str_DiagnosisAll);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis1)
                OnPropertyChanged(_str_DiagnosisAll);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis)
                OnPropertyChanged(_str_DiagnosisAll);
                  
            if (e.PropertyName == _str_DiagnosisAll)
                OnPropertyChanged(_str_strDiseaseNames);
                  
            if (e.PropertyName == _str_idfsCaseProgressStatus)
                OnPropertyChanged(_str_IsClosed);
                  
            if (e.PropertyName == _str_idfsCaseProgressStatus)
                OnPropertyChanged(_str_IsEnabledCaseProgressStatus);
                  
            if (e.PropertyName == _str_idfsFinalDiagnosis)
                OnPropertyChanged(_str_idfsDiagnosis);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis2)
                OnPropertyChanged(_str_idfsDiagnosis);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis1)
                OnPropertyChanged(_str_idfsDiagnosis);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis)
                OnPropertyChanged(_str_idfsDiagnosis);
                  
            if (e.PropertyName == _str_idfsSite)
                OnPropertyChanged(_str_strSiteCode);
                  
            if (e.PropertyName == _str_idfsFinalDiagnosis)
                OnPropertyChanged(_str_strIdfsDiagnosis);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis)
                OnPropertyChanged(_str_strIdfsDiagnosis);
                  
            if (e.PropertyName == _str_datEnteredDate)
                OnPropertyChanged(_str_strReadOnlyEnteredDate);
                  
            if (e.PropertyName == _str_Farm)
                OnPropertyChanged(_str_buttonSelectFarm);
                  
            if (e.PropertyName == _str_Farm)
                OnPropertyChanged(_str_buttonCoordinatesPicker);
                  
            if (e.PropertyName == _str_Farm)
                OnPropertyChanged(_str_idfObservationFarm);
                  
            if (e.PropertyName == _str_idfsCaseType)
                OnPropertyChanged(_str_IsLiveStock);
                  
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
            VetCase obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VetCase obj = this;
            
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

    
        private static string[] readonly_names1 = "idfsCaseProgressStatus,CaseProgressStatus".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strOutbreakID".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "idfOutbreak".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "strReadOnlyLocalIdentifier,strReadOnlyEnteredDate".Split(new char[] { ',' });
        
        private static string[] readonly_names5 = "strSiteCode,strMonitoringSessionID,idfParentMonitoringSession".Split(new char[] { ',' });
        
        private static string[] readonly_names6 = "idfsCaseType,CaseType,datEnteredDate,strCaseID,strDiseaseNames,strFinalDiagnosis,strDiagnosis,idfPersonEnteredBy,idfsSite,strPersonEnteredByName,strTentativeDiagnosisOIECode,strTentativeDiagnosis1OIECode,strTentativeDiagnosis2OIECode,strFinalDiagnosisOIECode".Split(new char[] { ',' });
        
        private static string[] readonly_names7 = "strInvestigatedByOffice,strReportedByOffice,strPersonInvestigatedBy,strPersonReportedBy".Split(new char[] { ',' });
        
        private static string[] readonly_names8 = "PersonInvestigatedBy,idfPersonInvestigatedBy".Split(new char[] { ',' });
        
        private static string[] readonly_names9 = "TestsConducted,idfsYNTestsConducted".Split(new char[] { ',' });
        
        private static string[] readonly_names10 = "CaseTests,CaseTestValidations".Split(new char[] { ',' });
        
        private static string[] readonly_names11 = "idfsCaseReportType,CaseReportType".Split(new char[] { ',' });
        
        private static string[] readonly_names12 = "buttonSelectFarm,buttonCoordinatesPicker".Split(new char[] { ',' });
        
        private static string[] readonly_names13 = "datTentativeDiagnosisDate".Split(new char[] { ',' });
        
        private static string[] readonly_names14 = "datTentativeDiagnosis1Date".Split(new char[] { ',' });
        
        private static string[] readonly_names15 = "datTentativeDiagnosis2Date".Split(new char[] { ',' });
        
        private static string[] readonly_names16 = "datFinalDiagnosisDate".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => c.ReadOnly || !c.IsEnabledCaseProgressStatus)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => true)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => c.IsClosed || c.ReadOnly)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => true)(this);
            
            if (readonly_names5.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => true)(this);
            
            if (readonly_names6.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => true)(this);
            
            if (readonly_names7.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => true)(this);
            
            if (readonly_names8.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => c.IsClosed || c.ReadOnly || c.idfInvestigatedByOffice == null)(this);
            
            if (readonly_names9.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => c.IsClosed || c.ReadOnly || (c.blnEnableTestsConducted != null && !c.blnEnableTestsConducted.Value) || !c.blnEnableTestsConductedCalc)(this);
            
            if (readonly_names10.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => c.IsClosed || c.ReadOnly)(this);
            
            if (readonly_names11.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => c.IsClosed || c.ReadOnly || c.idfParentMonitoringSession.HasValue)(this);
            
            if (readonly_names12.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => c.IsClosed || c.ReadOnly)(this);
            
            if (readonly_names13.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => c.IsClosed || c.ReadOnly || !c.idfsTentativeDiagnosis.HasValue)(this);
            
            if (readonly_names14.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => c.IsClosed || c.ReadOnly || !c.idfsTentativeDiagnosis1.HasValue)(this);
            
            if (readonly_names15.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => c.IsClosed || c.ReadOnly || !c.idfsTentativeDiagnosis2.HasValue)(this);
            
            if (readonly_names16.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VetCase, bool>(c => c.IsClosed || c.ReadOnly || !c.idfsFinalDiagnosis.HasValue)(this);
            
            return ReadOnly || new Func<VetCase, bool>(c => c.ReadOnly || c.IsClosed)(this);
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
                if (_FFPresenterControlMeasures != null)
                    _FFPresenterControlMeasures._isValid &= value;
                
                if (_Farm != null)
                    _Farm._isValid &= value;
                
                foreach(var o in _Vaccination)
                    o._isValid &= value;
                
                foreach(var o in _CaseTests)
                    o._isValid &= value;
                
                foreach(var o in _CaseTestValidations)
                    o._isValid &= value;
                
                foreach(var o in _PensideTests)
                    o._isValid &= value;
                
                foreach(var o in _AnimalList)
                    o._isValid &= value;
                
                foreach(var o in _Samples)
                    o._isValid &= value;
                
                foreach(var o in _Logs)
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
        
                if (_FFPresenterControlMeasures != null)
                    _FFPresenterControlMeasures.ReadOnly |= value;
                
                if (_Farm != null)
                    _Farm.ReadOnly |= value;
                
                foreach(var o in _Vaccination)
                    o.ReadOnly |= value;
                
                foreach(var o in _CaseTests)
                    o.ReadOnly |= value;
                
                foreach(var o in _CaseTestValidations)
                    o.ReadOnly |= value;
                
                foreach(var o in _PensideTests)
                    o.ReadOnly |= value;
                
                foreach(var o in _AnimalList)
                    o.ReadOnly |= value;
                
                foreach(var o in _Samples)
                    o.ReadOnly |= value;
                
                foreach(var o in _Logs)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<VetCase, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VetCase, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VetCase, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VetCase, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VetCase, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<VetCase, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<VetCase, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~VetCase()
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
                
                if (_FFPresenterControlMeasures != null)
                    FFPresenterControlMeasures.Dispose();
                
                if (_Farm != null)
                    Farm.Dispose();
                
                if (!bIsClone)
                {
                    Vaccination.ForEach(c => c.Dispose());
                }
                Vaccination.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    CaseTests.ForEach(c => c.Dispose());
                }
                CaseTests.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    CaseTestValidations.ForEach(c => c.Dispose());
                }
                CaseTestValidations.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    PensideTests.ForEach(c => c.Dispose());
                }
                PensideTests.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    AnimalList.ForEach(c => c.Dispose());
                }
                AnimalList.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    Samples.ForEach(c => c.Dispose());
                }
                Samples.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    Logs.ForEach(c => c.Dispose());
                }
                Logs.ClearModelListEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("SiteLookup", this);
                
                LookupManager.RemoveObject("rftCaseReportType", this);
                
                LookupManager.RemoveObject("rftCaseType", this);
                
                LookupManager.RemoveObject("rftCaseClassification", this);
                
                LookupManager.RemoveObject("rftCaseProgressStatus", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("WiderPersonLookup", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "SiteLookup")
                _getAccessor().LoadLookup_Site(manager, this);
            
            if (lookup_object == "rftCaseReportType")
                _getAccessor().LoadLookup_CaseReportType(manager, this);
            
            if (lookup_object == "rftCaseType")
                _getAccessor().LoadLookup_CaseType(manager, this);
            
            if (lookup_object == "rftCaseClassification")
                _getAccessor().LoadLookup_CaseClassification(manager, this);
            
            if (lookup_object == "rftCaseProgressStatus")
                _getAccessor().LoadLookup_CaseProgressStatus(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_TestsConducted(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_TentativeDiagnosis(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_TentativeDiagnosis1(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_TentativeDiagnosis2(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_FinalDiagnosis(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_ShowDiagnosis(manager, this);
            
            if (lookup_object == "WiderPersonLookup")
                _getAccessor().LoadLookup_PersonInvestigatedBy(manager, this);
            
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
        
            if (_FFPresenterControlMeasures != null) _FFPresenterControlMeasures.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_Farm != null) _Farm.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_Vaccination != null) _Vaccination.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_CaseTests != null) _CaseTests.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_CaseTestValidations != null) _CaseTestValidations.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_PensideTests != null) _PensideTests.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_AnimalList != null) _AnimalList.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Samples != null) _Samples.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Logs != null) _Logs.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<VetCase>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<VetCase>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<VetCase>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfCase"; } }
            #endregion
        
            public delegate void on_action(VetCase obj);
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
            private FFPresenterModel.Accessor FFPresenterControlMeasuresAccessor { get { return eidss.model.Schema.FFPresenterModel.Accessor.Instance(m_CS); } }
            private FarmPanel.Accessor FarmAccessor { get { return eidss.model.Schema.FarmPanel.Accessor.Instance(m_CS); } }
            private VaccinationListItem.Accessor VaccinationAccessor { get { return eidss.model.Schema.VaccinationListItem.Accessor.Instance(m_CS); } }
            private CaseTest.Accessor CaseTestsAccessor { get { return eidss.model.Schema.CaseTest.Accessor.Instance(m_CS); } }
            private CaseTestValidation.Accessor CaseTestValidationsAccessor { get { return eidss.model.Schema.CaseTestValidation.Accessor.Instance(m_CS); } }
            private PensideTest.Accessor PensideTestsAccessor { get { return eidss.model.Schema.PensideTest.Accessor.Instance(m_CS); } }
            private AnimalListItem.Accessor AnimalListAccessor { get { return eidss.model.Schema.AnimalListItem.Accessor.Instance(m_CS); } }
            private VetCaseSample.Accessor SamplesAccessor { get { return eidss.model.Schema.VetCaseSample.Accessor.Instance(m_CS); } }
            private VetCaseLog.Accessor LogsAccessor { get { return eidss.model.Schema.VetCaseLog.Accessor.Instance(m_CS); } }
            private SiteLookup.Accessor SiteAccessor { get { return eidss.model.Schema.SiteLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CaseReportTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CaseTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CaseClassificationAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CaseProgressStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestsConductedAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor TentativeDiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor TentativeDiagnosis1Accessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor TentativeDiagnosis2Accessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor FinalDiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor ShowDiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private WiderPersonLookup.Accessor PersonInvestigatedByAccessor { get { return eidss.model.Schema.WiderPersonLookup.Accessor.Instance(m_CS); } }
            

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
            public virtual VetCase SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
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

            
            public virtual VetCase SelectByKey(DbManagerProxy manager
                , Int64? idfCase
                , int? HACode = null
                
                )
            {
                return _SelectByKey(manager
                    , idfCase
                    , HACode
                    
                    , null, null
                    );
            }
            

            private VetCase _SelectByKey(DbManagerProxy manager
                , Int64? idfCase
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfCase
                    , HACode
                    
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual VetCase _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfCase
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<VetCase> objs = new List<VetCase>();
                sets[0] = new MapResultSet(typeof(VetCase), objs);
                VetCase obj = null;
                try
                {
                    manager
                        .SetSpCommand("spVetCase_SelectDetail"
                            , manager.Parameter("@idfCase", idfCase)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
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
                    
                      if (BaseSettings.ValidateObject)
                          obj._isValid = (manager.SetSpCommand("spVetCase_Validate", obj.Key).ExecuteScalar<int>(ScalarSourceType.ReturnValue) == 0);
                    

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
    
            private void _SetupAddChildHandlerVaccination(VetCase obj)
            {
                obj.Vaccination.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerCaseTests(VetCase obj)
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
            
            private void _SetupAddChildHandlerCaseTestValidations(VetCase obj)
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
            
            private void _SetupAddChildHandlerPensideTests(VetCase obj)
            {
                obj.PensideTests.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerAnimalList(VetCase obj)
            {
                obj.AnimalList.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerSamples(VetCase obj)
            {
                obj.Samples.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerLogs(VetCase obj)
            {
                obj.Logs.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadFFPresenterControlMeasures(VetCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFFPresenterControlMeasures(manager, obj);
                }
            }
            internal void _LoadFFPresenterControlMeasures(DbManagerProxy manager, VetCase obj)
            {
              
                if (obj.FFPresenterControlMeasures == null && obj.idfObservation != null && obj.idfObservation != 0)
                {
                    obj.FFPresenterControlMeasures = FFPresenterControlMeasuresAccessor.SelectByKey(manager
                        
                        , obj.idfObservation.Value
                        );
                    if (obj.FFPresenterControlMeasures != null)
                    {
                        obj.FFPresenterControlMeasures.m_ObjectName = _str_FFPresenterControlMeasures;
                    }
                }
                    
              }
            
            internal void _LoadFarm(VetCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFarm(manager, obj);
                }
            }
            internal void _LoadFarm(DbManagerProxy manager, VetCase obj)
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
            
            internal void _LoadVaccination(VetCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadVaccination(manager, obj);
                }
            }
            internal void _LoadVaccination(DbManagerProxy manager, VetCase obj)
            {
              
                obj.Vaccination.Clear();
                obj.Vaccination.AddRange(VaccinationAccessor.SelectDetailList(manager
                    
                    , obj.idfCase
                    , obj._HACode
                            
                    ));
                obj.Vaccination.ForEach(c => c.m_ObjectName = _str_Vaccination);
                obj.Vaccination.AcceptChanges();
                    
              }
            
            internal void _LoadCaseTests(VetCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadCaseTests(manager, obj);
                }
            }
            internal void _LoadCaseTests(DbManagerProxy manager, VetCase obj)
            {
              
                obj.CaseTests.Clear();
                obj.CaseTests.AddRange(CaseTestsAccessor.SelectDetailList(manager
                    
                    , obj.idfCase
                    ));
                obj.CaseTests.ForEach(c => c.m_ObjectName = _str_CaseTests);
                obj.CaseTests.AcceptChanges();
                    
              }
            
            internal void _LoadCaseTestValidations(VetCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadCaseTestValidations(manager, obj);
                }
            }
            internal void _LoadCaseTestValidations(DbManagerProxy manager, VetCase obj)
            {
              
                obj.CaseTestValidations.Clear();
                obj.CaseTestValidations.AddRange(CaseTestValidationsAccessor.SelectDetailList(manager
                    
                    , obj.idfCase
                    ));
                obj.CaseTestValidations.ForEach(c => c.m_ObjectName = _str_CaseTestValidations);
                obj.CaseTestValidations.AcceptChanges();
                    
              }
            
            internal void _LoadPensideTests(VetCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadPensideTests(manager, obj);
                }
            }
            internal void _LoadPensideTests(DbManagerProxy manager, VetCase obj)
            {
              
                obj.PensideTests.Clear();
                obj.PensideTests.AddRange(PensideTestsAccessor.SelectDetailList(manager
                    
                    , obj.idfCase
                    ));
                obj.PensideTests.ForEach(c => c.m_ObjectName = _str_PensideTests);
                obj.PensideTests.AcceptChanges();
                    
              }
            
            internal void _LoadAnimalList(VetCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadAnimalList(manager, obj);
                }
            }
            internal void _LoadAnimalList(DbManagerProxy manager, VetCase obj)
            {
              
                obj.AnimalList.Clear();
                obj.AnimalList.AddRange(AnimalListAccessor.SelectDetailList(manager
                    
                    , obj.idfCase
                    , obj._HACode
                            
                    ));
                obj.AnimalList.ForEach(c => c.m_ObjectName = _str_AnimalList);
                obj.AnimalList.AcceptChanges();
                    
              }
            
            internal void _LoadSamples(VetCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSamples(manager, obj);
                }
            }
            internal void _LoadSamples(DbManagerProxy manager, VetCase obj)
            {
              
                obj.Samples.Clear();
                obj.Samples.AddRange(SamplesAccessor.SelectDetailList(manager
                    
                    , obj.idfCase
                    ));
                obj.Samples.ForEach(c => c.m_ObjectName = _str_Samples);
                obj.Samples.AcceptChanges();
                    
              }
            
            internal void _LoadLogs(VetCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLogs(manager, obj);
                }
            }
            internal void _LoadLogs(DbManagerProxy manager, VetCase obj)
            {
              
                obj.Logs.Clear();
                obj.Logs.AddRange(LogsAccessor.SelectDetailList(manager
                    
                    , obj.idfCase
                    ));
                obj.Logs.ForEach(c => c.m_ObjectName = _str_Logs);
                obj.Logs.AcceptChanges();
                    
              }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, VetCase obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj._HACode = new Func<VetCase, int?>(c => (c.idfsCaseType == (long)CaseTypeEnum.Livestock ? 32 : 64))(obj);
                obj.Farm = new Func<VetCase, FarmPanel>(c=> c.Farm ?? FarmAccessor.CreateByCase(manager, c, c))(obj);
                obj.Farm.Case = new Func<VetCase, WeakReference>(c => new WeakReference(c))(obj);
                obj.Farm.FarmTree.ForEach(t => { t.Case = new Func<VetCase, WeakReference>(c => c.Farm.Case)(obj); } );
                obj.idfFarm = new Func<VetCase, long>(c => c.Farm.idfFarm)(obj);
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadFFPresenterControlMeasures(manager, obj);
                _LoadVaccination(manager, obj);
                _LoadCaseTests(manager, obj);
                _LoadCaseTestValidations(manager, obj);
                _LoadPensideTests(manager, obj);
                _LoadAnimalList(manager, obj);
                _LoadSamples(manager, obj);
                _LoadLogs(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.TestsConducted = new Func<VetCase, BaseReference>(c => (c.blnEnableTestsConducted == null || c.blnEnableTestsConducted.Value || c.TestsConductedLookup == null || c.blnEnableTestsConductedCalc) ? c.TestsConducted : c.TestsConductedLookup.Where(i => i.idfsBaseReference == (long)YesNoUnknownValuesEnum.Yes).SingleOrDefault())(obj);
                obj.Samples.ForEach(t => { t._HACode = new Func<VetCase, int?>(c => c._HACode)(obj); } );
                obj.CaseTests.ForEach(t => { t.idfTesting = new Func<VetCase, long>(c => { (t.GetAccessor() as CaseTest.Accessor).LoadLookup_TestNameRef(manager, t); return t.idfTesting; })(obj); } );
                obj.CaseTests.ForEach(t => { t.Diagnosis = new Func<VetCase, DiagnosisLookup>(c => t.DiagnosisLookup.FirstOrDefault(i => i.idfsDiagnosis == t.idfsDiagnosis))(obj); } );
                obj.PensideTests.ForEach(t => { t._HACode = new Func<VetCase, int?>(c => c._HACode)(obj); } );
                obj.PensideTests.ForEach(t => { t.strDummy = new Func<VetCase, string>(c => "")(obj); } );
                    if (obj.idfsFormTemplate.HasValue)
                    {
                      obj.FFPresenterControlMeasures.SetProperties(obj.idfsFormTemplate.Value, obj.idfCase);
                      obj.FFPresenterControlMeasures.ReadOnly = obj.IsClosed;
                    }
                    else
                    {
                      if (obj._HACode.Value == (int)eidss.model.Enums.HACode.Livestock)
                      {
                        if (obj.idfObservation == null)
                        obj.idfObservation = (new GetNewIDExtender<VetCase>()).GetScalar(manager, obj);
                        obj.FFPresenterControlMeasures = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, obj.idfObservation);
                        obj.FFPresenterControlMeasures.SetProperties(EidssSiteContext.Instance.CountryID, null, FFTypeEnum.LivestockControlMeasures, obj.idfObservation.Value, obj.idfCase);
                        if (obj.FFPresenterControlMeasures.CurrentTemplate != null) obj.idfsFormTemplate = obj.FFPresenterControlMeasures.CurrentTemplate.idfsFormTemplate;
                      }
                    }

                  
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerVaccination(obj);
                
                _SetupAddChildHandlerCaseTests(obj);
                
                _SetupAddChildHandlerCaseTestValidations(obj);
                
                _SetupAddChildHandlerPensideTests(obj);
                
                _SetupAddChildHandlerAnimalList(obj);
                
                _SetupAddChildHandlerSamples(obj);
                
                _SetupAddChildHandlerLogs(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, VetCase obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    FFPresenterControlMeasuresAccessor._SetPermitions(obj._permissions, obj.FFPresenterControlMeasures);
                    FarmAccessor._SetPermitions(obj._permissions, obj.Farm);
                    
                        obj.Vaccination.ForEach(c => VaccinationAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.CaseTests.ForEach(c => CaseTestsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.CaseTestValidations.ForEach(c => CaseTestValidationsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.PensideTests.ForEach(c => PensideTestsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.AnimalList.ForEach(c => AnimalListAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Samples.ForEach(c => SamplesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Logs.ForEach(c => LogsAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private VetCase _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                VetCase obj = null;
                try
                {
                    obj = VetCase.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    obj._HACode = HACode;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfsCaseType = new Func<VetCase, long>(c => (HACode == (int)eidss.model.Enums.HACode.Livestock ? (long)CaseTypeEnum.Livestock : (long)CaseTypeEnum.Avian))(obj);
                obj.idfCase = (new GetNewIDExtender<VetCase>()).GetScalar(manager, obj, isFake);
                obj.strCaseID = new Func<VetCase, string>(c => "(new)")(obj);
                obj.idfObservation = (new GetNewIDExtender<VetCase>()).GetScalar(manager, obj, isFake);
                obj.idfsSite = (new GetSiteIDExtender<VetCase>()).GetScalar(manager, obj, isFake);
                obj.datEnteredDate = new Func<VetCase, DateTime>(c => DateTime.Now)(obj);
                obj.Farm = new Func<VetCase, FarmPanel>(c => FarmAccessor.CreateByCase(manager, c, c))(obj);
                obj.idfFarm = new Func<VetCase, long>(c => c.Farm.idfFarm)(obj);
                    obj.Farm._HACode = obj.Farm.intHACode = obj._HACode;
                    if (EidssUserContext.Instance != null)
                    {
                      if (EidssUserContext.User != null)
                      {
                        obj.strPersonEnteredByName = EidssUserContext.User.FullName;
                        if (EidssUserContext.User.EmployeeID != null)
                        {
                          long em;
                          if (long.TryParse(EidssUserContext.User.EmployeeID.ToString(), out em))
                          obj.idfPersonEnteredBy = em;
                        }
                      }
                      if (HACode.Value == (int)eidss.model.Enums.HACode.Livestock)
                      {
                        obj.FFPresenterControlMeasures = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, obj.idfObservation);
                        obj.FFPresenterControlMeasures.SetProperties(EidssSiteContext.Instance.CountryID, null, FFTypeEnum.LivestockControlMeasures, obj.idfObservation.Value, obj.idfCase);
                        if (obj.FFPresenterControlMeasures.CurrentTemplate != null)
                        {
                          obj.idfsFormTemplate = obj.FFPresenterControlMeasures.CurrentTemplate.idfsFormTemplate;
                        }
                      }
                    }
                  
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerVaccination(obj);
                    
                    _SetupAddChildHandlerCaseTests(obj);
                    
                    _SetupAddChildHandlerCaseTestValidations(obj);
                    
                    _SetupAddChildHandlerPensideTests(obj);
                    
                    _SetupAddChildHandlerAnimalList(obj);
                    
                    _SetupAddChildHandlerSamples(obj);
                    
                    _SetupAddChildHandlerLogs(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.CaseProgressStatus = (new SelectLookupExtender<BaseReference>()).Select(obj.CaseProgressStatusLookup, c => c.idfsBaseReference == (long)CaseStatusEnum.InProgress);
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

            
            public VetCase CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VetCase CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public VetCase CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ReportContextMenu(DbManagerProxy manager, VetCase obj, List<object> pars)
            {
                
                return ReportContextMenu(manager, obj
                    );
            }
            public ActResult ReportContextMenu(DbManagerProxy manager, VetCase obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ReportContextMenu"))
                    throw new PermissionException("VetCase", "ReportContextMenu");
                
                return true;
                
            }
            
      
            public ActResult LivestockInvestigationReport(DbManagerProxy manager, VetCase obj, List<object> pars)
            {
                
                return LivestockInvestigationReport(manager, obj
                    );
            }
            public ActResult LivestockInvestigationReport(DbManagerProxy manager, VetCase obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("LivestockInvestigationReport"))
                    throw new PermissionException("VetCase", "LivestockInvestigationReport");
                
                return true;
                
            }
            
      
            public ActResult AvianInvestigationReport(DbManagerProxy manager, VetCase obj, List<object> pars)
            {
                
                return AvianInvestigationReport(manager, obj
                    );
            }
            public ActResult AvianInvestigationReport(DbManagerProxy manager, VetCase obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("AvianInvestigationReport"))
                    throw new PermissionException("VetCase", "AvianInvestigationReport");
                
                return true;
                
            }
            
      
            public ActResult TestsReport(DbManagerProxy manager, VetCase obj, List<object> pars)
            {
                
                return TestsReport(manager, obj
                    );
            }
            public ActResult TestsReport(DbManagerProxy manager, VetCase obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("TestsReport"))
                    throw new PermissionException("VetCase", "TestsReport");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(VetCase obj, object newobj)
            {
                
                foreach(var o in obj.CaseTestValidations.Where(c => !c.IsMarkedToDelete))
                {
                    if (newobj == null || newobj == o)
                    {
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "datInterpretationDate")
                            {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datInterpretationDate");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                            
                        };
                        o._SetupMainHandler();
                    }
                }
                  
                foreach(var o in obj.CaseTestValidations.Where(c => !c.IsMarkedToDelete))
                {
                    if (newobj == null || newobj == o)
                    {
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "datValidationDate")
                            {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datValidationDate");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                            
                        };
                        o._SetupMainHandler();
                    }
                }
                  
                foreach(var o in obj.Samples.Where(c => !c.IsMarkedToDelete))
                {
                    if (newobj == null || newobj == o)
                    {
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "datFieldCollectionDate")
                            {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datFieldCollectionDate");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                            
                        };
                        o._SetupMainHandler();
                    }
                }
                  
                foreach(var o in obj.CaseTests.Where(c => !c.IsMarkedToDelete))
                {
                    if (newobj == null || newobj == o)
                    {
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "datConcludedDate")
                            {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datConcludedDate");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                            
                        };
                        o._SetupMainHandler();
                    }
                }
                  
            }
            
            private void _SetupHandlers(VetCase obj)
            {
                
                obj.CaseTestValidations.ListChanged += delegate(object sender, ListChangedEventArgs e)
                    {
                        if (e.ListChangedType == ListChangedType.ItemAdded)
                        {
                          var ex = ChainsValidate(obj);
                          if (ex != null && !obj.OnValidation(ex))
                          {
                              if (obj.CaseTestValidations.Count > e.NewIndex)
                                  obj.CaseTestValidations.RemoveAt(e.NewIndex);
                          }
                        }
                    };
                  
                obj.CaseTestValidations.ListChanged += delegate(object sender, ListChangedEventArgs e)
                    {
                        if (e.ListChangedType == ListChangedType.ItemAdded)
                        {
                          var ex = ChainsValidate(obj);
                          if (ex != null && !obj.OnValidation(ex))
                          {
                              if (obj.CaseTestValidations.Count > e.NewIndex)
                                  obj.CaseTestValidations.RemoveAt(e.NewIndex);
                          }
                        }
                    };
                  
                obj.Samples.ListChanged += delegate(object sender, ListChangedEventArgs e)
                    {
                        if (e.ListChangedType == ListChangedType.ItemAdded)
                        {
                          var ex = ChainsValidate(obj);
                          if (ex != null && !obj.OnValidation(ex))
                          {
                              if (obj.Samples.Count > e.NewIndex)
                                  obj.Samples.RemoveAt(e.NewIndex);
                          }
                        }
                    };
                  
                obj.CaseTests.ListChanged += delegate(object sender, ListChangedEventArgs e)
                    {
                        if (e.ListChangedType == ListChangedType.ItemAdded)
                        {
                          var ex = ChainsValidate(obj);
                          if (ex != null && !obj.OnValidation(ex))
                          {
                              if (obj.CaseTests.Count > e.NewIndex)
                                  obj.CaseTests.RemoveAt(e.NewIndex);
                          }
                        }
                    };
                  
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datInvestigationDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datInvestigationDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datReportDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datReportDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datInvestigationDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datInvestigationDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datAssignedDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datAssignedDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datTentativeDiagnosisDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTentativeDiagnosisDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datTentativeDiagnosis1Date)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTentativeDiagnosis1Date);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datTentativeDiagnosis2Date)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTentativeDiagnosis2Date);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datFinalDiagnosisDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFinalDiagnosisDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
                obj.CaseTests.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    
                obj.TestsConducted = new Func<VetCase, BaseReference>(c => (c.CaseTests.Count(i => !i.IsMarkedToDelete) == 0) ? c.TestsConducted : c.TestsConductedLookup.Where(i => i.idfsBaseReference == (long)YesNoUnknownValuesEnum.Yes).SingleOrDefault())(obj);
                };
                    
                obj.AnimalList.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    
                obj._HACode = new Func<VetCase, int?>(c => 
                                { 
                                  if (e.ListChangedType == ListChangedType.ItemAdded)
                                  {
                                      var a = obj.AnimalList[e.NewIndex];
                                      var sp = obj.Farm.FarmTree.FirstOrDefault(s => s.idfParty == a.idfSpecies);
                                      if (sp != null)
                                          a.CopyMainProperties(sp);
                                  }
                                  return c._HACode;
                                })(obj);
                };
                    
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsYNTestsConducted)
                        {
                            try
                            {
                            
                (new PredicateValidator("msgSampleWasNotEnteredForVet", "idfsYNTestsConducted", "idfsYNTestsConducted", "idfsYNTestsConducted",
              new object[] {
              },
                        ValidationEventType.Warning
                    )).Validate(obj, c => 
                                              c.idfsYNTestsConducted != (long)YesNoUnknownValuesEnum.Yes || 
                                             (c.idfsYNTestsConducted == (long)YesNoUnknownValuesEnum.Yes && (c.Samples.Where(s => !s.IsMarkedToDelete && s.idfsSampleType != (long)SampleTypeEnum.Unknown).Count() > 0))
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_idfsYNTestsConducted);
                                    obj._TestsConducted = obj.TestsConductedLookup.Where(a => a.idfsBaseReference == obj.idfsYNTestsConducted).SingleOrDefault();
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                                
                            }
                        }
                    
                        if (e.PropertyName == _str_idfOutbreak)
                        {
                            try
                            {
                            
                CheckOutbreak(obj);
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_idfOutbreak);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                                
                                else if (ex.ValidationType == ValidationEventType.Question)
                                {
                                    obj.LockNotifyChanges();
                                    new Action<VetCase>(c => c.ChangeOutbreakDiagnosis())(obj);
                                    obj.UnlockNotifyChanges();
                                }
                                
                            }
                        }
                    
                        if (e.PropertyName == _str_idfsTentativeDiagnosis)
                        {
                    
                obj.datTentativeDiagnosisDate = new Func<VetCase, DateTime?>(c => c.idfsTentativeDiagnosis.HasValue ? (c.datTentativeDiagnosisDate.HasValue ? c.datTentativeDiagnosisDate : DateTime.Today) : null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTentativeDiagnosis1)
                        {
                    
                obj.datTentativeDiagnosis1Date = new Func<VetCase, DateTime?>(c => c.idfsTentativeDiagnosis1.HasValue ? (c.datTentativeDiagnosis1Date.HasValue ? c.datTentativeDiagnosis1Date : DateTime.Today) : null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsTentativeDiagnosis2)
                        {
                    
                obj.datTentativeDiagnosis2Date = new Func<VetCase, DateTime?>(c => c.idfsTentativeDiagnosis2.HasValue ? (c.datTentativeDiagnosis2Date.HasValue ? c.datTentativeDiagnosis2Date : DateTime.Today) : null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsFinalDiagnosis)
                        {
                    
                obj.datFinalDiagnosisDate = new Func<VetCase, DateTime?>(c => c.idfsFinalDiagnosis.HasValue ? (c.datFinalDiagnosisDate.HasValue ? c.datFinalDiagnosisDate : DateTime.Today) : null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfInvestigatedByOffice)
                        {
                    
                obj.PersonInvestigatedBy = (new SetScalarHandler()).Handler(obj,
                    obj.idfInvestigatedByOffice, obj.idfInvestigatedByOffice_Previous, obj.PersonInvestigatedBy,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsTentativeDiagnosis)
                        {
                    
                obj.strTentativeDiagnosisOIECode = (obj.TentativeDiagnosis == null) ? "" : obj.TentativeDiagnosis.strOIECode;
                        }
                    
                        if (e.PropertyName == _str_idfsTentativeDiagnosis1)
                        {
                    
                obj.strTentativeDiagnosis1OIECode = (obj.TentativeDiagnosis1 == null) ? "" : obj.TentativeDiagnosis1.strOIECode;
                        }
                    
                        if (e.PropertyName == _str_idfsTentativeDiagnosis2)
                        {
                    
                obj.strTentativeDiagnosis2OIECode = (obj.TentativeDiagnosis2 == null) ? "" : obj.TentativeDiagnosis2.strOIECode;
                        }
                    
                        if (e.PropertyName == _str_idfsFinalDiagnosis)
                        {
                    
                obj.strFinalDiagnosisOIECode = (obj.FinalDiagnosis == null) ? "" : obj.FinalDiagnosis.strOIECode;
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                       if (obj.idfsDiagnosis.HasValue)
                       {
                          obj.SetNewFFTemplatesValues();
                       }
                     
                        }
                    
                        if (e.PropertyName == _str_idfInvestigatedByOffice)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_PersonInvestigatedBy(manager, obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Site(DbManagerProxy manager, VetCase obj)
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
              
                LookupManager.AddObject("SiteLookup", obj, SiteAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_CaseReportType(DbManagerProxy manager, VetCase obj)
            {
                
                obj.CaseReportTypeLookup.Clear();
                
                obj.CaseReportTypeLookup.Add(CaseReportTypeAccessor.CreateNewT(manager, null));
                
                obj.CaseReportTypeLookup.AddRange(CaseReportTypeAccessor.rftCaseReportType_SelectList(manager
                    
                    )
                    .Where(c => c.idfsBaseReference != (long)eidss.model.Enums.CaseReportType.Both)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCaseReportType))
                    
                    .ToList());
                
                if (obj.idfsCaseReportType != null && obj.idfsCaseReportType != 0)
                {
                    obj.CaseReportType = obj.CaseReportTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsCaseReportType);
                    
                }
              
                LookupManager.AddObject("rftCaseReportType", obj, CaseReportTypeAccessor.GetType(), "rftCaseReportType_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_CaseType(DbManagerProxy manager, VetCase obj)
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
            
            public void LoadLookup_CaseClassification(DbManagerProxy manager, VetCase obj)
            {
                
                obj.CaseClassificationLookup.Clear();
                
                obj.CaseClassificationLookup.Add(CaseClassificationAccessor.CreateNewT(manager, null));
                
                obj.CaseClassificationLookup.AddRange(CaseClassificationAccessor.rftCaseClassification_SelectList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)obj._HACode) != 0))
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCaseClassification))
                    
                    .ToList());
                
                if (obj.idfsCaseClassification != null && obj.idfsCaseClassification != 0)
                {
                    obj.CaseClassification = obj.CaseClassificationLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsCaseClassification);
                    
                }
              
                LookupManager.AddObject("rftCaseClassification", obj, CaseClassificationAccessor.GetType(), "rftCaseClassification_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_CaseProgressStatus(DbManagerProxy manager, VetCase obj)
            {
                
                obj.CaseProgressStatusLookup.Clear();
                
                obj.CaseProgressStatusLookup.AddRange(CaseProgressStatusAccessor.rftCaseProgressStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCaseProgressStatus))
                    
                    .ToList());
                
                if (obj.idfsCaseProgressStatus != null && obj.idfsCaseProgressStatus != 0)
                {
                    obj.CaseProgressStatus = obj.CaseProgressStatusLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsCaseProgressStatus);
                    
                }
              
                LookupManager.AddObject("rftCaseProgressStatus", obj, CaseProgressStatusAccessor.GetType(), "rftCaseProgressStatus_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_TestsConducted(DbManagerProxy manager, VetCase obj)
            {
                
                obj.TestsConductedLookup.Clear();
                
                obj.TestsConductedLookup.Add(TestsConductedAccessor.CreateNewT(manager, null));
                
                obj.TestsConductedLookup.AddRange(TestsConductedAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNTestsConducted))
                    
                    .ToList());
                
                if (obj.idfsYNTestsConducted != null && obj.idfsYNTestsConducted != 0)
                {
                    obj.TestsConducted = obj.TestsConductedLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsYNTestsConducted);
                    
                }
              
                LookupManager.AddObject("rftYesNoValue", obj, TestsConductedAccessor.GetType(), "rftYesNoValue_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_TentativeDiagnosis(DbManagerProxy manager, VetCase obj)
            {
                
                obj.TentativeDiagnosisLookup.Clear();
                
                obj.TentativeDiagnosisLookup.Add(TentativeDiagnosisAccessor.CreateNewT(manager, null));
                
                obj.TentativeDiagnosisLookup.AddRange(TentativeDiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)obj._HACode) != 0) || c.idfsDiagnosis == obj.idfsTentativeDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsTentativeDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsTentativeDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsTentativeDiagnosis != null && obj.idfsTentativeDiagnosis != 0)
                {
                    obj.TentativeDiagnosis = obj.TentativeDiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsTentativeDiagnosis);
                    
                }
              
                LookupManager.AddObject("DiagnosisLookup", obj, TentativeDiagnosisAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_TentativeDiagnosis1(DbManagerProxy manager, VetCase obj)
            {
                
                obj.TentativeDiagnosis1Lookup.Clear();
                
                obj.TentativeDiagnosis1Lookup.Add(TentativeDiagnosis1Accessor.CreateNewT(manager, null));
                
                obj.TentativeDiagnosis1Lookup.AddRange(TentativeDiagnosis1Accessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)obj._HACode) != 0) || c.idfsDiagnosis == obj.idfsTentativeDiagnosis1)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsTentativeDiagnosis1)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsTentativeDiagnosis1))
                    
                    .ToList());
                
                if (obj.idfsTentativeDiagnosis1 != null && obj.idfsTentativeDiagnosis1 != 0)
                {
                    obj.TentativeDiagnosis1 = obj.TentativeDiagnosis1Lookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsTentativeDiagnosis1);
                    
                }
              
                LookupManager.AddObject("DiagnosisLookup", obj, TentativeDiagnosis1Accessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_TentativeDiagnosis2(DbManagerProxy manager, VetCase obj)
            {
                
                obj.TentativeDiagnosis2Lookup.Clear();
                
                obj.TentativeDiagnosis2Lookup.Add(TentativeDiagnosis2Accessor.CreateNewT(manager, null));
                
                obj.TentativeDiagnosis2Lookup.AddRange(TentativeDiagnosis2Accessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)obj._HACode) != 0) || c.idfsDiagnosis == obj.idfsTentativeDiagnosis2)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsTentativeDiagnosis2)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsTentativeDiagnosis2))
                    
                    .ToList());
                
                if (obj.idfsTentativeDiagnosis2 != null && obj.idfsTentativeDiagnosis2 != 0)
                {
                    obj.TentativeDiagnosis2 = obj.TentativeDiagnosis2Lookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsTentativeDiagnosis2);
                    
                }
              
                LookupManager.AddObject("DiagnosisLookup", obj, TentativeDiagnosis2Accessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_FinalDiagnosis(DbManagerProxy manager, VetCase obj)
            {
                
                obj.FinalDiagnosisLookup.Clear();
                
                obj.FinalDiagnosisLookup.Add(FinalDiagnosisAccessor.CreateNewT(manager, null));
                
                obj.FinalDiagnosisLookup.AddRange(FinalDiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)obj._HACode) != 0) || c.idfsDiagnosis == obj.idfsFinalDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsFinalDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsFinalDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsFinalDiagnosis != null && obj.idfsFinalDiagnosis != 0)
                {
                    obj.FinalDiagnosis = obj.FinalDiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsFinalDiagnosis);
                    
                }
              
                LookupManager.AddObject("DiagnosisLookup", obj, FinalDiagnosisAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_ShowDiagnosis(DbManagerProxy manager, VetCase obj)
            {
                
                obj.ShowDiagnosisLookup.Clear();
                
                obj.ShowDiagnosisLookup.Add(ShowDiagnosisAccessor.CreateNewT(manager, null));
                
                obj.ShowDiagnosisLookup.AddRange(ShowDiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)obj._HACode) != 0) || c.idfsDiagnosis == obj.idfsShowDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsShowDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsShowDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsShowDiagnosis != null && obj.idfsShowDiagnosis != 0)
                {
                    obj.ShowDiagnosis = obj.ShowDiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsShowDiagnosis);
                    
                }
              
                LookupManager.AddObject("DiagnosisLookup", obj, ShowDiagnosisAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_PersonInvestigatedBy(DbManagerProxy manager, VetCase obj)
            {
                
                obj.PersonInvestigatedByLookup.Clear();
                
                obj.PersonInvestigatedByLookup.Add(PersonInvestigatedByAccessor.CreateNewT(manager, null));
                
                obj.PersonInvestigatedByLookup.AddRange(PersonInvestigatedByAccessor.SelectLookupList(manager
                    
                    , new Func<VetCase, long>(c => c.idfInvestigatedByOffice ?? 0)(obj)
                            
                    , null
                    , false
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfPersonInvestigatedBy))
                    
                    .ToList());
                
                if (obj.idfPersonInvestigatedBy != null && obj.idfPersonInvestigatedBy != 0)
                {
                    obj.PersonInvestigatedBy = obj.PersonInvestigatedByLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfPersonInvestigatedBy);
                    
                }
              
                LookupManager.AddObject("WiderPersonLookup", obj, PersonInvestigatedByAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, VetCase obj)
            {
                
                LoadLookup_Site(manager, obj);
                
                LoadLookup_CaseReportType(manager, obj);
                
                LoadLookup_CaseType(manager, obj);
                
                LoadLookup_CaseClassification(manager, obj);
                
                LoadLookup_CaseProgressStatus(manager, obj);
                
                LoadLookup_TestsConducted(manager, obj);
                
                LoadLookup_TentativeDiagnosis(manager, obj);
                
                LoadLookup_TentativeDiagnosis1(manager, obj);
                
                LoadLookup_TentativeDiagnosis2(manager, obj);
                
                LoadLookup_FinalDiagnosis(manager, obj);
                
                LoadLookup_ShowDiagnosis(manager, obj);
                
                LoadLookup_PersonInvestigatedBy(manager, obj);
                
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
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spVetCase_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] VetCase obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] VetCase obj)
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
                        VetCase bo = obj as VetCase;
                        
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
                            
                                manager.SetEventParams(false, new object[] { EventType.VetCaseCreatedLocal, mainObject, "" });
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                            if (
                                bo.idfsFinalDiagnosis != bo.idfsFinalDiagnosis_Original
                              ||
                                bo.idfsTentativeDiagnosis2 != bo.idfsTentativeDiagnosis2_Original
                              ||
                                bo.idfsTentativeDiagnosis1 != bo.idfsTentativeDiagnosis1_Original
                              ||
                                bo.idfsTentativeDiagnosis != bo.idfsTentativeDiagnosis_Original
                              )
                              
                                manager.SetEventParams(false, new object[] { EventType.VetCaseDiagnosisChangedLocal, mainObject, "" });
                            
                            if (
                                bo.idfsCaseClassification != bo.idfsCaseClassification_Original
                              )
                              
                                manager.SetEventParams(false, new object[] { EventType.VetCaseClassificationChangedLocal, mainObject, "" });
                            
                            if (new Func<VetCase, bool>(c => c.idfsCaseProgressStatus == (long)CaseStatusEnum.InProgress && c.idfsCaseProgressStatus_Original == (long)CaseStatusEnum.Closed)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.ClosedVetCaseReopenedLocal, mainObject, "" });
                            
                            if (new Func<VetCase, bool>(c => c.PensideTests.Count(i => i.IsNew && !i.IsMarkedToDelete) > 0)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.VetCaseFieldTestResultRegistrationLocal, mainObject, "" });
                            
                            if (new Func<VetCase, bool>(c => c.CaseTests.Count(i => i.IsNew && !i.IsMarkedToDelete) > 0)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.VetCaseTestResultRegistrationLocal, mainObject, "" });
                            
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
                        bSuccess = _PostNonTransaction(manager, obj as VetCase, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VetCase obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.FFPresenterControlMeasures != null)
                    {
                        obj.FFPresenterControlMeasures.MarkToDelete();
                        if (!FFPresenterControlMeasuresAccessor.Post(manager, obj.FFPresenterControlMeasures, true))
                            return false;
                    }
                                    
                    if (obj.Logs != null)
                    {
                        foreach (var i in obj.Logs)
                        {
                            i.MarkToDelete();
                            if (!LogsAccessor.Post(manager, i, true))
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
                    
            
                    // posting extenters - begin
                obj.datModificationForArchiveDate = new Func<VetCase, DateTime?>(c => c.HasChanges ? DateTime.Now : c.datModificationForArchiveDate)(obj);
                obj.strCaseID = new Func<VetCase, DbManagerProxy, string>((c,m) => 
                        c.strCaseID != "(new)" 
                        ? c.strCaseID 
                        : m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.VetCase, DBNull.Value, DBNull.Value)                        
                        .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue"))(obj, manager);
                obj.idfsShowDiagnosis = new Func<VetCase, long?>(c=>c.idfsDiagnosis)(obj);
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
                                    
                    if (!obj.IsMarkedToDelete && bHasChanges)
                        _postPredicate(manager, obj);
                                    
                    if (obj.IsNew)
                    {
                        if (obj.Vaccination != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Vaccination)
                                if (!VaccinationAccessor.Post(manager, i, true))
                                    return false;
                            obj.Vaccination.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Vaccination.Remove(c));
                            obj.Vaccination.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Vaccination != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Vaccination)
                                if (!VaccinationAccessor.Post(manager, i, true))
                                    return false;
                            obj._Vaccination.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Vaccination.Remove(c));
                            obj._Vaccination.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.AnimalList != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.AnimalList)
                                if (!AnimalListAccessor.Post(manager, i, true))
                                    return false;
                            obj.AnimalList.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.AnimalList.Remove(c));
                            obj.AnimalList.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._AnimalList != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._AnimalList)
                                if (!AnimalListAccessor.Post(manager, i, true))
                                    return false;
                            obj._AnimalList.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._AnimalList.Remove(c));
                            obj._AnimalList.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.Samples != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Samples)
                                if (!SamplesAccessor.Post(manager, i, true))
                                    return false;
                            obj.Samples.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Samples.Remove(c));
                            obj.Samples.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Samples != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Samples)
                                if (!SamplesAccessor.Post(manager, i, true))
                                    return false;
                            obj._Samples.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Samples.Remove(c));
                            obj._Samples.AcceptChanges();
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
                        if (obj.PensideTests != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.PensideTests)
                                if (!PensideTestsAccessor.Post(manager, i, true))
                                    return false;
                            obj.PensideTests.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.PensideTests.Remove(c));
                            obj.PensideTests.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._PensideTests != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._PensideTests)
                                if (!PensideTestsAccessor.Post(manager, i, true))
                                    return false;
                            obj._PensideTests.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._PensideTests.Remove(c));
                            obj._PensideTests.AcceptChanges();
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
                                    
                    if (obj.IsNew)
                    {
                        if (obj.Logs != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Logs)
                                if (!LogsAccessor.Post(manager, i, true))
                                    return false;
                            obj.Logs.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Logs.Remove(c));
                            obj.Logs.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Logs != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Logs)
                                if (!LogsAccessor.Post(manager, i, true))
                                    return false;
                            obj._Logs.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Logs.Remove(c));
                            obj._Logs.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.FFPresenterControlMeasures != null) // forced load potential lazy subobject for new object
                            if (!FFPresenterControlMeasuresAccessor.Post(manager, obj.FFPresenterControlMeasures, true))
                                return false;
                    }
                    else
                    {
                        if (obj._FFPresenterControlMeasures != null) // do not load lazy subobject for existing object
                            if (!FFPresenterControlMeasuresAccessor.Post(manager, obj.FFPresenterControlMeasures, true))
                                return false;
                    }
                                    
                    // posted extenters - begin
                    if (obj.AnimalList.Count() > 0)
                    {
                      obj.AnimalList.ForEach(animal => animal.CopyMainProperties(obj.Farm.FarmTree.Single(species=>species.idfParty == animal.idfSpecies)));
                    }
                  
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                obj.OnPropertyChanged(_str_IsClosed);
                
                obj.OnPropertyChanged(_str_IsEnabledCaseProgressStatus);
                
                return true;
            }
            
            public bool ValidateCanDelete(VetCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VetCase obj)
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
        
      
            protected ValidationModelException ChainsValidate(VetCase obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<VetCase>(obj, "datInvestigationDate", c => true, 
      obj.datInvestigationDate,
      obj.GetType(),
      false, listdatInvestigationDate => {
    listdatInvestigationDate.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }).Process();
  
    new ChainsValidatorDateTime<VetCase>(obj, "datReportDate", c => true, 
      obj.datReportDate,
      obj.GetType(),
      false, listdatReportDate => {
    listdatReportDate.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "datInvestigationDate", c => true, 
      obj.datInvestigationDate,
      obj.GetType(),
      false, listdatInvestigationDate => {
    obj.CaseTestValidations.Where(c => !c.IsMarkedToDelete).ToList().ForEach(j =>listdatInvestigationDate.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "datInterpretationDate", c => true, 
      j.datInterpretationDate,
      j.GetType(),
      false, listdatInterpretationDate => {
    listdatInterpretationDate.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    })));
  obj.CaseTestValidations.Where(c => !c.IsMarkedToDelete).ToList().ForEach(j =>listdatInvestigationDate.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "datValidationDate", c => true, 
      j.datValidationDate,
      j.GetType(),
      false, listdatValidationDate => {
    listdatValidationDate.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    })));
  
    }));
  listdatReportDate.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "datAssignedDate", c => true, 
      obj.datAssignedDate,
      obj.GetType(),
      false, listdatAssignedDate => {
    listdatAssignedDate.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "datTentativeDiagnosisDate", c => true, 
      obj.datTentativeDiagnosisDate,
      obj.GetType(),
      false, listdatTentativeDiagnosisDate => {
    listdatTentativeDiagnosisDate.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "datTentativeDiagnosis1Date", c => true, 
      obj.datTentativeDiagnosis1Date,
      obj.GetType(),
      false, listdatTentativeDiagnosis1Date => {
    listdatTentativeDiagnosis1Date.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "datTentativeDiagnosis2Date", c => true, 
      obj.datTentativeDiagnosis2Date,
      obj.GetType(),
      false, listdatTentativeDiagnosis2Date => {
    listdatTentativeDiagnosis2Date.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }));
  
    }));
  
    }));
  
    }));
  obj.Samples.Where(c => !c.IsMarkedToDelete).ToList().ForEach(j =>listdatReportDate.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "datFieldCollectionDate", c => true, 
      j.datFieldCollectionDate,
      j.GetType(),
      false, listdatFieldCollectionDate => {
    listdatFieldCollectionDate.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    })));
  
    }).Process();
  
    new ChainsValidatorDateTime<VetCase>(obj, "datFinalDiagnosisDate", c => true, 
      obj.datFinalDiagnosisDate,
      obj.GetType(),
      false, listdatFinalDiagnosisDate => {
    listdatFinalDiagnosisDate.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }).Process();
  obj.CaseTests.Where(c => !c.IsMarkedToDelete).ToList().ForEach(j =>
    new ChainsValidatorDateTime<VetCase>(obj, "datConcludedDate", c => true, 
      j.datConcludedDate,
      j.GetType(),
      false, listdatConcludedDate => {
    listdatConcludedDate.Add(
    new ChainsValidatorDateTime<VetCase>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }).Process());
  
                }
                catch(ValidationModelException ex)
                {
                    return ex;
                }
                
                return null;
            }
            protected bool ChainsValidate(VetCase obj, bool bRethrowException)
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
                return Validate(manager, obj as VetCase, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VetCase obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "Farm.Address.idfsCountry", "Farm.Address.Country","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.Farm.Address.idfsCountry);
            
                (new RequiredValidator( "Farm.Address.idfsRegion", "Farm.Address.Region","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.Farm.Address.idfsRegion);
            
                (new RequiredValidator( "Farm.Address.idfsRayon", "Farm.Address.Rayon","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.Farm.Address.idfsRayon);
            
                (new RequiredValidator( "idfsCaseReportType", "CaseReportType","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsCaseReportType);
            
                (new RequiredValidator( "idfsCaseProgressStatus", "CaseProgressStatus","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsCaseProgressStatus);
            
            (new CustomMandatoryFieldValidator("CaseClassification", "CaseClassification", "idfsCaseClassification",
            ValidationEventType.Error
            )).Validate(obj, obj.CaseClassification, CustomMandatoryField.VetCase_CaseClassification,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("Farm.Address.Settlement", "Farm.Address.Settlement", "",
            ValidationEventType.Error
            )).Validate(obj, obj.Farm.Address.Settlement, CustomMandatoryField.VetCase_Farm_Address_Settlement,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("TentativeDiagnosis", "TentativeDiagnosis", "VetCase.TentativeDiagnosis1",
            ValidationEventType.Error
            )).Validate(obj, obj.TentativeDiagnosis, CustomMandatoryField.VetCase_TentativeDiagnosis,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("TentativeDiagnosis1", "TentativeDiagnosis1", "VetCase.TentativeDiagnosis2",
            ValidationEventType.Error
            )).Validate(obj, obj.TentativeDiagnosis1, CustomMandatoryField.VetCase_Tentative1Diagnosis,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("TentativeDiagnosis2", "TentativeDiagnosis2", "VetCase.TentativeDiagnosis3",
            ValidationEventType.Error
            )).Validate(obj, obj.TentativeDiagnosis2, CustomMandatoryField.VetCase_Tentative2Diagnosis,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("FinalDiagnosis", "FinalDiagnosis", "VetCase.FinalDiagnogis",
            ValidationEventType.Error
            )).Validate(obj, obj.FinalDiagnosis, CustomMandatoryField.VetCase_FinalDiagnosis,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "",
            ValidationEventType.Error
            )).Validate(obj, obj.datTentativeDiagnosisDate, CustomMandatoryField.VetCase_TentativeDiagnosisDate,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("datTentativeDiagnosis1Date", "datTentativeDiagnosis1Date", "",
            ValidationEventType.Error
            )).Validate(obj, obj.datTentativeDiagnosis1Date, CustomMandatoryField.VetCase_TentativeDiagnosis1Date,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("datTentativeDiagnosis2Date", "datTentativeDiagnosis2Date", "",
            ValidationEventType.Error
            )).Validate(obj, obj.datTentativeDiagnosis2Date, CustomMandatoryField.VetCase_TentativeDiagnosis2Date,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("datFinalDiagnosisDate", "datFinalDiagnosisDate", "",
            ValidationEventType.Error
            )).Validate(obj, obj.datFinalDiagnosisDate, CustomMandatoryField.VetCase_FinalDiagnosisDate,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("Farm.strOwnerLastName", "Farm.strOwnerLastName", "",
            ValidationEventType.Error
            )).Validate(obj, obj.Farm.strOwnerLastName, CustomMandatoryField.VetCase_Farm_FarmOwnerLastName,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("Farm.strOwnerFirstName", "Farm.strOwnerFirstName", "",
            ValidationEventType.Error
            )).Validate(obj, obj.Farm.strOwnerFirstName, CustomMandatoryField.VetCase_Farm_FarmOwnerFirstName,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("Farm.strNationalName", "Farm.strNationalName", "",
            ValidationEventType.Error
            )).Validate(obj, obj.Farm.strNationalName, CustomMandatoryField.VetCase_Farm_FarmName,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("idfReportedByOffice", "idfReportedByOffice", "",
            ValidationEventType.Error
            )).Validate(obj, obj.idfReportedByOffice, CustomMandatoryField.VetCase_ReportedByOffice,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
            (new CustomMandatoryFieldValidator("idfPersonReportedBy", "idfPersonReportedBy", "",
            ValidationEventType.Error
            )).Validate(obj, obj.idfPersonReportedBy, CustomMandatoryField.VetCase_PersonReportedBy,
            c => !eidss.model.Core.EidssUserContext.SmartphoneContext);

          
                CustomValidations(obj);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                CheckOutbreak(obj);
            
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Farm != null)
                            FarmAccessor.Validate(manager, obj.Farm, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Vaccination != null)
                            foreach (var i in obj.Vaccination.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                VaccinationAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.AnimalList != null)
                            foreach (var i in obj.AnimalList.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                AnimalListAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Samples != null)
                            foreach (var i in obj.Samples.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                SamplesAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.CaseTests != null)
                            foreach (var i in obj.CaseTests.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                CaseTestsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.PensideTests != null)
                            foreach (var i in obj.PensideTests.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                PensideTestsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.CaseTestValidations != null)
                            foreach (var i in obj.CaseTestValidations.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                CaseTestValidationsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Logs != null)
                            foreach (var i in obj.Logs.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                LogsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FFPresenterControlMeasures != null)
                            FFPresenterControlMeasuresAccessor.Validate(manager, obj.FFPresenterControlMeasures, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VetCase.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VetCase.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VetCase.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VetCase.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(VetCase obj)
            {
            
                obj
                    .Farm
                        .Address
                        .AddRequired("Country", c => true);
                        
                obj
                    .Farm
                        .Address
                        .AddRequired("Region", c => true);
                        
                obj
                    .Farm
                        .Address
                        .AddRequired("Rayon", c => true);
                        
                obj
                    .AddRequired("CaseReportType", c => true);
                    
                  obj
                    .AddRequired("CaseReportType", c => true);
                
                obj
                    .AddRequired("CaseProgressStatus", c => true);
                    
                  obj
                    .AddRequired("CaseProgressStatus", c => true);
                
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_CaseClassification)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .AddRequired("CaseClassification", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_Farm_Address_Settlement)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .Farm
                      .Address
                      .AddRequired("Settlement", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_TentativeDiagnosis)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .AddRequired("TentativeDiagnosis", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_Tentative1Diagnosis)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .AddRequired("TentativeDiagnosis1", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_Tentative2Diagnosis)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .AddRequired("TentativeDiagnosis2", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_FinalDiagnosis)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .AddRequired("FinalDiagnosis", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_TentativeDiagnosisDate)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .AddRequired("datTentativeDiagnosisDate", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_TentativeDiagnosis1Date)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .AddRequired("datTentativeDiagnosis1Date", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_TentativeDiagnosis2Date)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .AddRequired("datTentativeDiagnosis2Date", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_FinalDiagnosisDate)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .AddRequired("datFinalDiagnosisDate", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_Farm_FarmOwnerLastName)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .Farm
                      .AddRequired("strOwnerLastName", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_Farm_FarmOwnerFirstName)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .Farm
                      .AddRequired("strOwnerFirstName", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_Farm_FarmName)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .Farm
                      .AddRequired("strNationalName", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_ReportedByOffice)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .AddRequired("idfReportedByOffice", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetCase_PersonReportedBy)  && new Func<VetCase, bool>(c => !eidss.model.Core.EidssUserContext.SmartphoneContext)(obj))
              {
                obj
                  .AddRequired("idfPersonReportedBy", c => !eidss.model.Core.EidssUserContext.SmartphoneContext);
                
                }
            
            }
    
    private void _SetupPersonalDataRestrictions(VetCase obj)
    {
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement))
      {
      
            obj
              .AddHiddenPersonalData("Vet_Farm", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
            
            obj
              .Farm
                  .AddHiddenPersonalData("strOwnerLastName", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strOwnerFirstName", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strOwnerMiddleName", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strFarmCode", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strNationalName", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("Settlement", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("idfsSettlement", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("PostCode", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("Street", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("strPostCode", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("strStreetName", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("strApartment", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("strHouse", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("strBuilding", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strFax", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strEmail", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strContactPhone", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details))
      {
      
            obj
              .AddHiddenPersonalData("Vet_Farm", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
            
            obj
              .Farm
                  .AddHiddenPersonalData("strOwnerLastName", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strOwnerFirstName", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strOwnerMiddleName", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strFarmCode", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strNationalName", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("PostCode", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("Street", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("strPostCode", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("strStreetName", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("strApartment", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("strHouse", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("strBuilding", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strFax", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strEmail", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .AddHiddenPersonalData("strContactPhone", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Coordinates))
      {
      
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("dblLatitude", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
            obj
              .Farm
                  .Address
                  .AddHiddenPersonalData("dblLongitude", c => !(obj.IsNew || (ModelUserContext.Instance.CurrentUser != null && obj.idfPersonEnteredBy == (long)ModelUserContext.Instance.CurrentUser.EmployeeID)));
                
      }
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VetCase) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VetCase) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VetCaseDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return "web_vetcaselivestockdetailform"; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private VetCase m_obj;
            internal Permissions(VetCase obj)
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
            public static string spSelect = "spVetCase_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spVetCase_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spVetCase_Delete";
            public static string spCanDelete = "spVetCase_CanDelete";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VetCase, bool>> RequiredByField = new Dictionary<string, Func<VetCase, bool>>();
            public static Dictionary<string, Func<VetCase, bool>> RequiredByProperty = new Dictionary<string, Func<VetCase, bool>>();
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
                
                Sizes.Add(_str_strOutbreakID, 200);
                Sizes.Add(_str_strMonitoringSessionID, 50);
                Sizes.Add(_str_strCaseID, 200);
                Sizes.Add(_str_strInvestigatedByOffice, 2000);
                Sizes.Add(_str_strPersonInvestigatedBy, 400);
                Sizes.Add(_str_strPersonEnteredByName, 400);
                Sizes.Add(_str_strReportedByOffice, 2000);
                Sizes.Add(_str_strPersonReportedBy, 400);
                Sizes.Add(_str_strSampleNotes, 1000);
                Sizes.Add(_str_strTestNotes, 1000);
                Sizes.Add(_str_strSummaryNotes, 1000);
                Sizes.Add(_str_strClinicalNotes, 1000);
                Sizes.Add(_str_strFieldAccessionID, 200);
                Sizes.Add(_str_strFinalDiagnosisOIECode, 200);
                Sizes.Add(_str_strTentativeDiagnosisOIECode, 200);
                Sizes.Add(_str_strTentativeDiagnosis1OIECode, 200);
                Sizes.Add(_str_strTentativeDiagnosis2OIECode, 200);
                if (!RequiredByField.ContainsKey("Farm.Address.idfsCountry")) RequiredByField.Add("Farm.Address.idfsCountry", c => true);
                if (!RequiredByProperty.ContainsKey("Farm.Address.Country")) RequiredByProperty.Add("Farm.Address.Country", c => true);
                
                if (!RequiredByField.ContainsKey("Farm.Address.idfsRegion")) RequiredByField.Add("Farm.Address.idfsRegion", c => true);
                if (!RequiredByProperty.ContainsKey("Farm.Address.Region")) RequiredByProperty.Add("Farm.Address.Region", c => true);
                
                if (!RequiredByField.ContainsKey("Farm.Address.idfsRayon")) RequiredByField.Add("Farm.Address.idfsRayon", c => true);
                if (!RequiredByProperty.ContainsKey("Farm.Address.Rayon")) RequiredByProperty.Add("Farm.Address.Rayon", c => true);
                
                if (!RequiredByField.ContainsKey("idfsCaseReportType")) RequiredByField.Add("idfsCaseReportType", c => true);
                if (!RequiredByProperty.ContainsKey("CaseReportType")) RequiredByProperty.Add("CaseReportType", c => true);
                
                if (!RequiredByField.ContainsKey("idfsCaseProgressStatus")) RequiredByField.Add("idfsCaseProgressStatus", c => true);
                if (!RequiredByProperty.ContainsKey("CaseProgressStatus")) RequiredByProperty.Add("CaseProgressStatus", c => true);
                
                Actions.Add(new ActionMetaItem(
                    "ReportContextMenu",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ReportContextMenu(manager, (VetCase)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strReport_Id",
                        "Report",
                        /*from BvMessages*/"strReport_Id",
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
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "LivestockInvestigationReport",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).LivestockInvestigationReport(manager, (VetCase)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleLivestockInvestigationReport",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    (o1, o2, p, r) => (o1 as VetCase).IsLiveStock && eidss.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("VetLivestockInvestigation"),
                    false,
                    false,
                    "VetInvestigationReport",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "AvianInvestigationReport",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).AvianInvestigationReport(manager, (VetCase)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleAvianInvestigationReport",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenu,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    (o1, o2, p, r) => !(o1 as VetCase).IsLiveStock && eidss.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("VetAvianInvestigation"),
                    false,
                    false,
                    "VetInvestigationReport",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "TestsReport",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).TestsReport(manager, (VetCase)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleLabTestReport",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.ContextMenuAdditional,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    "vetCase.TestsReportRun",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<VetCase>().Post(manager, (VetCase)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<VetCase>().Post(manager, (VetCase)c), c),
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
                    (manager, c, pars) => new ActResult(((VetCase)c).MarkToDelete() && ObjectAccessor.PostInterface<VetCase>().Post(manager, (VetCase)c), c),
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
    
        AddHiddenPersonalData("Vet_Farm", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.strOwnerLastName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.strOwnerFirstName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.strOwnerMiddleName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.strFarmCode", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.strNationalName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.Address.Settlement", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.Address.idfsSettlement", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.Address.PostCode", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.Address.Street", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.Address.strPostCode", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.Address.strStreetName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.Address.strApartment", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.Address.strHouse", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.Address.strBuilding", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.strFax", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.strEmail", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Farm.strContactPhone", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("Vet_Farm", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.strOwnerLastName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.strOwnerFirstName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.strOwnerMiddleName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.strFarmCode", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.strNationalName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.Address.PostCode", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.Address.Street", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.Address.strPostCode", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.Address.strStreetName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.Address.strApartment", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.Address.strHouse", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.Address.strBuilding", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.strFax", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.strEmail", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.strContactPhone", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("Farm.Address.dblLatitude", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Coordinates));
      
        AddHiddenPersonalData("Farm.Address.dblLongitude", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Coordinates));
      

    }
  
        }
        #endregion
    

        #endregion
        }
    
}
	