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
    public abstract partial class HumanCase : 
        EditableObject<HumanCase>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCase { get; set; }
                
        [LocalizedDisplayName(_str_idfOutbreak)]
        [MapField(_str_idfOutbreak)]
        public abstract Int64? idfOutbreak { get; set; }
        #if MONO
        protected Int64? idfOutbreak_Original { get { return idfOutbreak; } }
        protected Int64? idfOutbreak_Previous { get { return idfOutbreak; } }
        #else
        protected Int64? idfOutbreak_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOutbreak).OriginalValue; } }
        protected Int64? idfOutbreak_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOutbreak).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_uidOfflineCaseID)]
        [MapField(_str_uidOfflineCaseID)]
        public abstract Guid? uidOfflineCaseID { get; set; }
        #if MONO
        protected Guid? uidOfflineCaseID_Original { get { return uidOfflineCaseID; } }
        protected Guid? uidOfflineCaseID_Previous { get { return uidOfflineCaseID; } }
        #else
        protected Guid? uidOfflineCaseID_Original { get { return ((EditableValue<Guid?>)((dynamic)this)._uidOfflineCaseID).OriginalValue; } }
        protected Guid? uidOfflineCaseID_Previous { get { return ((EditableValue<Guid?>)((dynamic)this)._uidOfflineCaseID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsFinalState)]
        [MapField(_str_idfsFinalState)]
        public abstract Int64? idfsFinalState { get; set; }
        #if MONO
        protected Int64? idfsFinalState_Original { get { return idfsFinalState; } }
        protected Int64? idfsFinalState_Previous { get { return idfsFinalState; } }
        #else
        protected Int64? idfsFinalState_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalState).OriginalValue; } }
        protected Int64? idfsFinalState_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalState).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsHospitalizationStatus)]
        [MapField(_str_idfsHospitalizationStatus)]
        public abstract Int64? idfsHospitalizationStatus { get; set; }
        #if MONO
        protected Int64? idfsHospitalizationStatus_Original { get { return idfsHospitalizationStatus; } }
        protected Int64? idfsHospitalizationStatus_Previous { get { return idfsHospitalizationStatus; } }
        #else
        protected Int64? idfsHospitalizationStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHospitalizationStatus).OriginalValue; } }
        protected Int64? idfsHospitalizationStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHospitalizationStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsHumanAgeType)]
        [MapField(_str_idfsHumanAgeType)]
        public abstract Int64? idfsHumanAgeType { get; set; }
        #if MONO
        protected Int64? idfsHumanAgeType_Original { get { return idfsHumanAgeType; } }
        protected Int64? idfsHumanAgeType_Previous { get { return idfsHumanAgeType; } }
        #else
        protected Int64? idfsHumanAgeType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanAgeType).OriginalValue; } }
        protected Int64? idfsHumanAgeType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanAgeType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsYNAntimicrobialTherapy)]
        [MapField(_str_idfsYNAntimicrobialTherapy)]
        public abstract Int64? idfsYNAntimicrobialTherapy { get; set; }
        #if MONO
        protected Int64? idfsYNAntimicrobialTherapy_Original { get { return idfsYNAntimicrobialTherapy; } }
        protected Int64? idfsYNAntimicrobialTherapy_Previous { get { return idfsYNAntimicrobialTherapy; } }
        #else
        protected Int64? idfsYNAntimicrobialTherapy_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNAntimicrobialTherapy).OriginalValue; } }
        protected Int64? idfsYNAntimicrobialTherapy_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNAntimicrobialTherapy).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsYNHospitalization)]
        [MapField(_str_idfsYNHospitalization)]
        public abstract Int64? idfsYNHospitalization { get; set; }
        #if MONO
        protected Int64? idfsYNHospitalization_Original { get { return idfsYNHospitalization; } }
        protected Int64? idfsYNHospitalization_Previous { get { return idfsYNHospitalization; } }
        #else
        protected Int64? idfsYNHospitalization_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNHospitalization).OriginalValue; } }
        protected Int64? idfsYNHospitalization_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNHospitalization).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsYNSpecimenCollected)]
        [MapField(_str_idfsYNSpecimenCollected)]
        public abstract Int64? idfsYNSpecimenCollected { get; set; }
        #if MONO
        protected Int64? idfsYNSpecimenCollected_Original { get { return idfsYNSpecimenCollected; } }
        protected Int64? idfsYNSpecimenCollected_Previous { get { return idfsYNSpecimenCollected; } }
        #else
        protected Int64? idfsYNSpecimenCollected_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNSpecimenCollected).OriginalValue; } }
        protected Int64? idfsYNSpecimenCollected_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNSpecimenCollected).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsYNRelatedToOutbreak)]
        [MapField(_str_idfsYNRelatedToOutbreak)]
        public abstract Int64? idfsYNRelatedToOutbreak { get; set; }
        #if MONO
        protected Int64? idfsYNRelatedToOutbreak_Original { get { return idfsYNRelatedToOutbreak; } }
        protected Int64? idfsYNRelatedToOutbreak_Previous { get { return idfsYNRelatedToOutbreak; } }
        #else
        protected Int64? idfsYNRelatedToOutbreak_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNRelatedToOutbreak).OriginalValue; } }
        protected Int64? idfsYNRelatedToOutbreak_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNRelatedToOutbreak).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsYNTestsConducted)]
        [MapField(_str_idfsYNTestsConducted)]
        public abstract Int64? idfsYNTestsConducted { get; set; }
        #if MONO
        protected Int64? idfsYNTestsConducted_Original { get { return idfsYNTestsConducted; } }
        protected Int64? idfsYNTestsConducted_Previous { get { return idfsYNTestsConducted; } }
        #else
        protected Int64? idfsYNTestsConducted_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNTestsConducted).OriginalValue; } }
        protected Int64? idfsYNTestsConducted_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNTestsConducted).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnEnableTestsConducted)]
        [MapField(_str_blnEnableTestsConducted)]
        public abstract Boolean? blnEnableTestsConducted { get; set; }
        #if MONO
        protected Boolean? blnEnableTestsConducted_Original { get { return blnEnableTestsConducted; } }
        protected Boolean? blnEnableTestsConducted_Previous { get { return blnEnableTestsConducted; } }
        #else
        protected Boolean? blnEnableTestsConducted_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnEnableTestsConducted).OriginalValue; } }
        protected Boolean? blnEnableTestsConducted_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnEnableTestsConducted).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsOutcome)]
        [MapField(_str_idfsOutcome)]
        public abstract Int64? idfsOutcome { get; set; }
        #if MONO
        protected Int64? idfsOutcome_Original { get { return idfsOutcome; } }
        protected Int64? idfsOutcome_Previous { get { return idfsOutcome; } }
        #else
        protected Int64? idfsOutcome_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOutcome).OriginalValue; } }
        protected Int64? idfsOutcome_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOutcome).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsInitialCaseStatus)]
        [MapField(_str_idfsInitialCaseStatus)]
        public abstract Int64? idfsInitialCaseStatus { get; set; }
        #if MONO
        protected Int64? idfsInitialCaseStatus_Original { get { return idfsInitialCaseStatus; } }
        protected Int64? idfsInitialCaseStatus_Previous { get { return idfsInitialCaseStatus; } }
        #else
        protected Int64? idfsInitialCaseStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsInitialCaseStatus).OriginalValue; } }
        protected Int64? idfsInitialCaseStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsInitialCaseStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfSentByOffice)]
        [MapField(_str_idfSentByOffice)]
        public abstract Int64? idfSentByOffice { get; set; }
        #if MONO
        protected Int64? idfSentByOffice_Original { get { return idfSentByOffice; } }
        protected Int64? idfSentByOffice_Previous { get { return idfSentByOffice; } }
        #else
        protected Int64? idfSentByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSentByOffice).OriginalValue; } }
        protected Int64? idfSentByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSentByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSentByOffice)]
        [MapField(_str_strSentByOffice)]
        public abstract String strSentByOffice { get; set; }
        #if MONO
        protected String strSentByOffice_Original { get { return strSentByOffice; } }
        protected String strSentByOffice_Previous { get { return strSentByOffice; } }
        #else
        protected String strSentByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strSentByOffice).OriginalValue; } }
        protected String strSentByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSentByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfSentByPerson)]
        [MapField(_str_idfSentByPerson)]
        public abstract Int64? idfSentByPerson { get; set; }
        #if MONO
        protected Int64? idfSentByPerson_Original { get { return idfSentByPerson; } }
        protected Int64? idfSentByPerson_Previous { get { return idfSentByPerson; } }
        #else
        protected Int64? idfSentByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSentByPerson).OriginalValue; } }
        protected Int64? idfSentByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSentByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSentByPerson)]
        [MapField(_str_strSentByPerson)]
        public abstract String strSentByPerson { get; set; }
        #if MONO
        protected String strSentByPerson_Original { get { return strSentByPerson; } }
        protected String strSentByPerson_Previous { get { return strSentByPerson; } }
        #else
        protected String strSentByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strSentByPerson).OriginalValue; } }
        protected String strSentByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSentByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfReceivedByOffice)]
        [MapField(_str_idfReceivedByOffice)]
        public abstract Int64? idfReceivedByOffice { get; set; }
        #if MONO
        protected Int64? idfReceivedByOffice_Original { get { return idfReceivedByOffice; } }
        protected Int64? idfReceivedByOffice_Previous { get { return idfReceivedByOffice; } }
        #else
        protected Int64? idfReceivedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfReceivedByOffice).OriginalValue; } }
        protected Int64? idfReceivedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfReceivedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strReceivedByOffice)]
        [MapField(_str_strReceivedByOffice)]
        public abstract String strReceivedByOffice { get; set; }
        #if MONO
        protected String strReceivedByOffice_Original { get { return strReceivedByOffice; } }
        protected String strReceivedByOffice_Previous { get { return strReceivedByOffice; } }
        #else
        protected String strReceivedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByOffice).OriginalValue; } }
        protected String strReceivedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfReceivedByPerson)]
        [MapField(_str_idfReceivedByPerson)]
        public abstract Int64? idfReceivedByPerson { get; set; }
        #if MONO
        protected Int64? idfReceivedByPerson_Original { get { return idfReceivedByPerson; } }
        protected Int64? idfReceivedByPerson_Previous { get { return idfReceivedByPerson; } }
        #else
        protected Int64? idfReceivedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfReceivedByPerson).OriginalValue; } }
        protected Int64? idfReceivedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfReceivedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strReceivedByPerson)]
        [MapField(_str_strReceivedByPerson)]
        public abstract String strReceivedByPerson { get; set; }
        #if MONO
        protected String strReceivedByPerson_Original { get { return strReceivedByPerson; } }
        protected String strReceivedByPerson_Previous { get { return strReceivedByPerson; } }
        #else
        protected String strReceivedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByPerson).OriginalValue; } }
        protected String strReceivedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfInvestigatedByOffice)]
        [MapField(_str_idfInvestigatedByOffice)]
        public abstract Int64? idfInvestigatedByOffice { get; set; }
        #if MONO
        protected Int64? idfInvestigatedByOffice_Original { get { return idfInvestigatedByOffice; } }
        protected Int64? idfInvestigatedByOffice_Previous { get { return idfInvestigatedByOffice; } }
        #else
        protected Int64? idfInvestigatedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInvestigatedByOffice).OriginalValue; } }
        protected Int64? idfInvestigatedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInvestigatedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strInvestigatedByOffice)]
        [MapField(_str_strInvestigatedByOffice)]
        public abstract String strInvestigatedByOffice { get; set; }
        #if MONO
        protected String strInvestigatedByOffice_Original { get { return strInvestigatedByOffice; } }
        protected String strInvestigatedByOffice_Previous { get { return strInvestigatedByOffice; } }
        #else
        protected String strInvestigatedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strInvestigatedByOffice).OriginalValue; } }
        protected String strInvestigatedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strInvestigatedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfInvestigatedByPerson)]
        [MapField(_str_idfInvestigatedByPerson)]
        public abstract Int64? idfInvestigatedByPerson { get; set; }
        #if MONO
        protected Int64? idfInvestigatedByPerson_Original { get { return idfInvestigatedByPerson; } }
        protected Int64? idfInvestigatedByPerson_Previous { get { return idfInvestigatedByPerson; } }
        #else
        protected Int64? idfInvestigatedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInvestigatedByPerson).OriginalValue; } }
        protected Int64? idfInvestigatedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInvestigatedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strInvestigatedByPerson)]
        [MapField(_str_strInvestigatedByPerson)]
        public abstract String strInvestigatedByPerson { get; set; }
        #if MONO
        protected String strInvestigatedByPerson_Original { get { return strInvestigatedByPerson; } }
        protected String strInvestigatedByPerson_Previous { get { return strInvestigatedByPerson; } }
        #else
        protected String strInvestigatedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strInvestigatedByPerson).OriginalValue; } }
        protected String strInvestigatedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strInvestigatedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfPointGeoLocation)]
        [MapField(_str_idfPointGeoLocation)]
        public abstract Int64? idfPointGeoLocation { get; set; }
        #if MONO
        protected Int64? idfPointGeoLocation_Original { get { return idfPointGeoLocation; } }
        protected Int64? idfPointGeoLocation_Previous { get { return idfPointGeoLocation; } }
        #else
        protected Int64? idfPointGeoLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPointGeoLocation).OriginalValue; } }
        protected Int64? idfPointGeoLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPointGeoLocation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfEpiObservation)]
        [MapField(_str_idfEpiObservation)]
        public abstract Int64? idfEpiObservation { get; set; }
        #if MONO
        protected Int64? idfEpiObservation_Original { get { return idfEpiObservation; } }
        protected Int64? idfEpiObservation_Previous { get { return idfEpiObservation; } }
        #else
        protected Int64? idfEpiObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfEpiObservation).OriginalValue; } }
        protected Int64? idfEpiObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfEpiObservation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsEPIFormTemplate)]
        [MapField(_str_idfsEPIFormTemplate)]
        public abstract Int64? idfsEPIFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsEPIFormTemplate_Original { get { return idfsEPIFormTemplate; } }
        protected Int64? idfsEPIFormTemplate_Previous { get { return idfsEPIFormTemplate; } }
        #else
        protected Int64? idfsEPIFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEPIFormTemplate).OriginalValue; } }
        protected Int64? idfsEPIFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEPIFormTemplate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfCSObservation)]
        [MapField(_str_idfCSObservation)]
        public abstract Int64? idfCSObservation { get; set; }
        #if MONO
        protected Int64? idfCSObservation_Original { get { return idfCSObservation; } }
        protected Int64? idfCSObservation_Previous { get { return idfCSObservation; } }
        #else
        protected Int64? idfCSObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCSObservation).OriginalValue; } }
        protected Int64? idfCSObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCSObservation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCSFormTemplate)]
        [MapField(_str_idfsCSFormTemplate)]
        public abstract Int64? idfsCSFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsCSFormTemplate_Original { get { return idfsCSFormTemplate; } }
        protected Int64? idfsCSFormTemplate_Previous { get { return idfsCSFormTemplate; } }
        #else
        protected Int64? idfsCSFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCSFormTemplate).OriginalValue; } }
        protected Int64? idfsCSFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCSFormTemplate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datNotificationDate)]
        [MapField(_str_datNotificationDate)]
        public abstract DateTime? datNotificationDate { get; set; }
        #if MONO
        protected DateTime? datNotificationDate_Original { get { return datNotificationDate; } }
        protected DateTime? datNotificationDate_Previous { get { return datNotificationDate; } }
        #else
        protected DateTime? datNotificationDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datNotificationDate).OriginalValue; } }
        protected DateTime? datNotificationDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datNotificationDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datCompletionPaperFormDate)]
        [MapField(_str_datCompletionPaperFormDate)]
        public abstract DateTime? datCompletionPaperFormDate { get; set; }
        #if MONO
        protected DateTime? datCompletionPaperFormDate_Original { get { return datCompletionPaperFormDate; } }
        protected DateTime? datCompletionPaperFormDate_Previous { get { return datCompletionPaperFormDate; } }
        #else
        protected DateTime? datCompletionPaperFormDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCompletionPaperFormDate).OriginalValue; } }
        protected DateTime? datCompletionPaperFormDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCompletionPaperFormDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datFirstSoughtCareDate)]
        [MapField(_str_datFirstSoughtCareDate)]
        public abstract DateTime? datFirstSoughtCareDate { get; set; }
        #if MONO
        protected DateTime? datFirstSoughtCareDate_Original { get { return datFirstSoughtCareDate; } }
        protected DateTime? datFirstSoughtCareDate_Previous { get { return datFirstSoughtCareDate; } }
        #else
        protected DateTime? datFirstSoughtCareDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFirstSoughtCareDate).OriginalValue; } }
        protected DateTime? datFirstSoughtCareDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFirstSoughtCareDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datModificationDate)]
        [MapField(_str_datModificationDate)]
        public abstract DateTime? datModificationDate { get; set; }
        #if MONO
        protected DateTime? datModificationDate_Original { get { return datModificationDate; } }
        protected DateTime? datModificationDate_Previous { get { return datModificationDate; } }
        #else
        protected DateTime? datModificationDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationDate).OriginalValue; } }
        protected DateTime? datModificationDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datHospitalizationDate)]
        [MapField(_str_datHospitalizationDate)]
        public abstract DateTime? datHospitalizationDate { get; set; }
        #if MONO
        protected DateTime? datHospitalizationDate_Original { get { return datHospitalizationDate; } }
        protected DateTime? datHospitalizationDate_Previous { get { return datHospitalizationDate; } }
        #else
        protected DateTime? datHospitalizationDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datHospitalizationDate).OriginalValue; } }
        protected DateTime? datHospitalizationDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datHospitalizationDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datFacilityLastVisit)]
        [MapField(_str_datFacilityLastVisit)]
        public abstract DateTime? datFacilityLastVisit { get; set; }
        #if MONO
        protected DateTime? datFacilityLastVisit_Original { get { return datFacilityLastVisit; } }
        protected DateTime? datFacilityLastVisit_Previous { get { return datFacilityLastVisit; } }
        #else
        protected DateTime? datFacilityLastVisit_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFacilityLastVisit).OriginalValue; } }
        protected DateTime? datFacilityLastVisit_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFacilityLastVisit).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datExposureDate)]
        [MapField(_str_datExposureDate)]
        public abstract DateTime? datExposureDate { get; set; }
        #if MONO
        protected DateTime? datExposureDate_Original { get { return datExposureDate; } }
        protected DateTime? datExposureDate_Previous { get { return datExposureDate; } }
        #else
        protected DateTime? datExposureDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datExposureDate).OriginalValue; } }
        protected DateTime? datExposureDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datExposureDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datDischargeDate)]
        [MapField(_str_datDischargeDate)]
        public abstract DateTime? datDischargeDate { get; set; }
        #if MONO
        protected DateTime? datDischargeDate_Original { get { return datDischargeDate; } }
        protected DateTime? datDischargeDate_Previous { get { return datDischargeDate; } }
        #else
        protected DateTime? datDischargeDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDischargeDate).OriginalValue; } }
        protected DateTime? datDischargeDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDischargeDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datOnSetDate)]
        [MapField(_str_datOnSetDate)]
        public abstract DateTime? datOnSetDate { get; set; }
        #if MONO
        protected DateTime? datOnSetDate_Original { get { return datOnSetDate; } }
        protected DateTime? datOnSetDate_Previous { get { return datOnSetDate; } }
        #else
        protected DateTime? datOnSetDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datOnSetDate).OriginalValue; } }
        protected DateTime? datOnSetDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datOnSetDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datInvestigationStartDate)]
        [MapField(_str_datInvestigationStartDate)]
        public abstract DateTime? datInvestigationStartDate { get; set; }
        #if MONO
        protected DateTime? datInvestigationStartDate_Original { get { return datInvestigationStartDate; } }
        protected DateTime? datInvestigationStartDate_Previous { get { return datInvestigationStartDate; } }
        #else
        protected DateTime? datInvestigationStartDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datInvestigationStartDate).OriginalValue; } }
        protected DateTime? datInvestigationStartDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datInvestigationStartDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datTentativeDiagnosisDate)]
        [MapField(_str_datTentativeDiagnosisDate)]
        public abstract DateTime? datTentativeDiagnosisDate { get; set; }
        #if MONO
        protected DateTime? datTentativeDiagnosisDate_Original { get { return datTentativeDiagnosisDate; } }
        protected DateTime? datTentativeDiagnosisDate_Previous { get { return datTentativeDiagnosisDate; } }
        #else
        protected DateTime? datTentativeDiagnosisDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTentativeDiagnosisDate).OriginalValue; } }
        protected DateTime? datTentativeDiagnosisDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTentativeDiagnosisDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datFinalDiagnosisDate)]
        [MapField(_str_datFinalDiagnosisDate)]
        public abstract DateTime? datFinalDiagnosisDate { get; set; }
        #if MONO
        protected DateTime? datFinalDiagnosisDate_Original { get { return datFinalDiagnosisDate; } }
        protected DateTime? datFinalDiagnosisDate_Previous { get { return datFinalDiagnosisDate; } }
        #else
        protected DateTime? datFinalDiagnosisDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFinalDiagnosisDate).OriginalValue; } }
        protected DateTime? datFinalDiagnosisDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFinalDiagnosisDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strNote)]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        #if MONO
        protected String strNote_Original { get { return strNote; } }
        protected String strNote_Previous { get { return strNote; } }
        #else
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCurrentLocation)]
        [MapField(_str_strCurrentLocation)]
        public abstract String strCurrentLocation { get; set; }
        #if MONO
        protected String strCurrentLocation_Original { get { return strCurrentLocation; } }
        protected String strCurrentLocation_Previous { get { return strCurrentLocation; } }
        #else
        protected String strCurrentLocation_Original { get { return ((EditableValue<String>)((dynamic)this)._strCurrentLocation).OriginalValue; } }
        protected String strCurrentLocation_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCurrentLocation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strHospitalizationPlace)]
        [MapField(_str_strHospitalizationPlace)]
        public abstract String strHospitalizationPlace { get; set; }
        #if MONO
        protected String strHospitalizationPlace_Original { get { return strHospitalizationPlace; } }
        protected String strHospitalizationPlace_Previous { get { return strHospitalizationPlace; } }
        #else
        protected String strHospitalizationPlace_Original { get { return ((EditableValue<String>)((dynamic)this)._strHospitalizationPlace).OriginalValue; } }
        protected String strHospitalizationPlace_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHospitalizationPlace).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strLocalIdentifier)]
        [MapField(_str_strLocalIdentifier)]
        public abstract String strLocalIdentifier { get; set; }
        #if MONO
        protected String strLocalIdentifier_Original { get { return strLocalIdentifier; } }
        protected String strLocalIdentifier_Previous { get { return strLocalIdentifier; } }
        #else
        protected String strLocalIdentifier_Original { get { return ((EditableValue<String>)((dynamic)this)._strLocalIdentifier).OriginalValue; } }
        protected String strLocalIdentifier_Previous { get { return ((EditableValue<String>)((dynamic)this)._strLocalIdentifier).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfSoughtCareFacility)]
        [MapField(_str_idfSoughtCareFacility)]
        public abstract Int64? idfSoughtCareFacility { get; set; }
        #if MONO
        protected Int64? idfSoughtCareFacility_Original { get { return idfSoughtCareFacility; } }
        protected Int64? idfSoughtCareFacility_Previous { get { return idfSoughtCareFacility; } }
        #else
        protected Int64? idfSoughtCareFacility_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSoughtCareFacility).OriginalValue; } }
        protected Int64? idfSoughtCareFacility_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSoughtCareFacility).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSoughtCareFacility)]
        [MapField(_str_strSoughtCareFacility)]
        public abstract String strSoughtCareFacility { get; set; }
        #if MONO
        protected String strSoughtCareFacility_Original { get { return strSoughtCareFacility; } }
        protected String strSoughtCareFacility_Previous { get { return strSoughtCareFacility; } }
        #else
        protected String strSoughtCareFacility_Original { get { return ((EditableValue<String>)((dynamic)this)._strSoughtCareFacility).OriginalValue; } }
        protected String strSoughtCareFacility_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSoughtCareFacility).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSentByFirstName)]
        [MapField(_str_strSentByFirstName)]
        public abstract String strSentByFirstName { get; set; }
        #if MONO
        protected String strSentByFirstName_Original { get { return strSentByFirstName; } }
        protected String strSentByFirstName_Previous { get { return strSentByFirstName; } }
        #else
        protected String strSentByFirstName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSentByFirstName).OriginalValue; } }
        protected String strSentByFirstName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSentByFirstName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSentByPatronymicName)]
        [MapField(_str_strSentByPatronymicName)]
        public abstract String strSentByPatronymicName { get; set; }
        #if MONO
        protected String strSentByPatronymicName_Original { get { return strSentByPatronymicName; } }
        protected String strSentByPatronymicName_Previous { get { return strSentByPatronymicName; } }
        #else
        protected String strSentByPatronymicName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSentByPatronymicName).OriginalValue; } }
        protected String strSentByPatronymicName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSentByPatronymicName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSentByLastName)]
        [MapField(_str_strSentByLastName)]
        public abstract String strSentByLastName { get; set; }
        #if MONO
        protected String strSentByLastName_Original { get { return strSentByLastName; } }
        protected String strSentByLastName_Previous { get { return strSentByLastName; } }
        #else
        protected String strSentByLastName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSentByLastName).OriginalValue; } }
        protected String strSentByLastName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSentByLastName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strReceivedByFirstName)]
        [MapField(_str_strReceivedByFirstName)]
        public abstract String strReceivedByFirstName { get; set; }
        #if MONO
        protected String strReceivedByFirstName_Original { get { return strReceivedByFirstName; } }
        protected String strReceivedByFirstName_Previous { get { return strReceivedByFirstName; } }
        #else
        protected String strReceivedByFirstName_Original { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByFirstName).OriginalValue; } }
        protected String strReceivedByFirstName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByFirstName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strReceivedByPatronymicName)]
        [MapField(_str_strReceivedByPatronymicName)]
        public abstract String strReceivedByPatronymicName { get; set; }
        #if MONO
        protected String strReceivedByPatronymicName_Original { get { return strReceivedByPatronymicName; } }
        protected String strReceivedByPatronymicName_Previous { get { return strReceivedByPatronymicName; } }
        #else
        protected String strReceivedByPatronymicName_Original { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByPatronymicName).OriginalValue; } }
        protected String strReceivedByPatronymicName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByPatronymicName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strReceivedByLastName)]
        [MapField(_str_strReceivedByLastName)]
        public abstract String strReceivedByLastName { get; set; }
        #if MONO
        protected String strReceivedByLastName_Original { get { return strReceivedByLastName; } }
        protected String strReceivedByLastName_Previous { get { return strReceivedByLastName; } }
        #else
        protected String strReceivedByLastName_Original { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByLastName).OriginalValue; } }
        protected String strReceivedByLastName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByLastName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strEpidemiologistsName)]
        [MapField(_str_strEpidemiologistsName)]
        public abstract String strEpidemiologistsName { get; set; }
        #if MONO
        protected String strEpidemiologistsName_Original { get { return strEpidemiologistsName; } }
        protected String strEpidemiologistsName_Previous { get { return strEpidemiologistsName; } }
        #else
        protected String strEpidemiologistsName_Original { get { return ((EditableValue<String>)((dynamic)this)._strEpidemiologistsName).OriginalValue; } }
        protected String strEpidemiologistsName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEpidemiologistsName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsNotCollectedReason)]
        [MapField(_str_idfsNotCollectedReason)]
        public abstract Int64? idfsNotCollectedReason { get; set; }
        #if MONO
        protected Int64? idfsNotCollectedReason_Original { get { return idfsNotCollectedReason; } }
        protected Int64? idfsNotCollectedReason_Previous { get { return idfsNotCollectedReason; } }
        #else
        protected Int64? idfsNotCollectedReason_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsNotCollectedReason).OriginalValue; } }
        protected Int64? idfsNotCollectedReason_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsNotCollectedReason).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsNonNotifiableDiagnosis)]
        [MapField(_str_idfsNonNotifiableDiagnosis)]
        public abstract Int64? idfsNonNotifiableDiagnosis { get; set; }
        #if MONO
        protected Int64? idfsNonNotifiableDiagnosis_Original { get { return idfsNonNotifiableDiagnosis; } }
        protected Int64? idfsNonNotifiableDiagnosis_Previous { get { return idfsNonNotifiableDiagnosis; } }
        #else
        protected Int64? idfsNonNotifiableDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsNonNotifiableDiagnosis).OriginalValue; } }
        protected Int64? idfsNonNotifiableDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsNonNotifiableDiagnosis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intPatientAge)]
        [MapField(_str_intPatientAge)]
        public abstract Int32? intPatientAge { get; set; }
        #if MONO
        protected Int32? intPatientAge_Original { get { return intPatientAge; } }
        protected Int32? intPatientAge_Previous { get { return intPatientAge; } }
        #else
        protected Int32? intPatientAge_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intPatientAge).OriginalValue; } }
        protected Int32? intPatientAge_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intPatientAge).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnClinicalDiagBasis)]
        [MapField(_str_blnClinicalDiagBasis)]
        public abstract Boolean? blnClinicalDiagBasis { get; set; }
        #if MONO
        protected Boolean? blnClinicalDiagBasis_Original { get { return blnClinicalDiagBasis; } }
        protected Boolean? blnClinicalDiagBasis_Previous { get { return blnClinicalDiagBasis; } }
        #else
        protected Boolean? blnClinicalDiagBasis_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnClinicalDiagBasis).OriginalValue; } }
        protected Boolean? blnClinicalDiagBasis_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnClinicalDiagBasis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnLabDiagBasis)]
        [MapField(_str_blnLabDiagBasis)]
        public abstract Boolean? blnLabDiagBasis { get; set; }
        #if MONO
        protected Boolean? blnLabDiagBasis_Original { get { return blnLabDiagBasis; } }
        protected Boolean? blnLabDiagBasis_Previous { get { return blnLabDiagBasis; } }
        #else
        protected Boolean? blnLabDiagBasis_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnLabDiagBasis).OriginalValue; } }
        protected Boolean? blnLabDiagBasis_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnLabDiagBasis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_blnEpiDiagBasis)]
        [MapField(_str_blnEpiDiagBasis)]
        public abstract Boolean? blnEpiDiagBasis { get; set; }
        #if MONO
        protected Boolean? blnEpiDiagBasis_Original { get { return blnEpiDiagBasis; } }
        protected Boolean? blnEpiDiagBasis_Previous { get { return blnEpiDiagBasis; } }
        #else
        protected Boolean? blnEpiDiagBasis_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnEpiDiagBasis).OriginalValue; } }
        protected Boolean? blnEpiDiagBasis_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnEpiDiagBasis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strClinicalNotes)]
        [MapField(_str_strClinicalNotes)]
        public abstract String strClinicalNotes { get; set; }
        #if MONO
        protected String strClinicalNotes_Original { get { return strClinicalNotes; } }
        protected String strClinicalNotes_Previous { get { return strClinicalNotes; } }
        #else
        protected String strClinicalNotes_Original { get { return ((EditableValue<String>)((dynamic)this)._strClinicalNotes).OriginalValue; } }
        protected String strClinicalNotes_Previous { get { return ((EditableValue<String>)((dynamic)this)._strClinicalNotes).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSummaryNotes)]
        [MapField(_str_strSummaryNotes)]
        public abstract String strSummaryNotes { get; set; }
        #if MONO
        protected String strSummaryNotes_Original { get { return strSummaryNotes; } }
        protected String strSummaryNotes_Previous { get { return strSummaryNotes; } }
        #else
        protected String strSummaryNotes_Original { get { return ((EditableValue<String>)((dynamic)this)._strSummaryNotes).OriginalValue; } }
        protected String strSummaryNotes_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSummaryNotes).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsFinalCaseStatus)]
        [MapField(_str_idfsFinalCaseStatus)]
        public abstract Int64? idfsFinalCaseStatus { get; set; }
        #if MONO
        protected Int64? idfsFinalCaseStatus_Original { get { return idfsFinalCaseStatus; } }
        protected Int64? idfsFinalCaseStatus_Previous { get { return idfsFinalCaseStatus; } }
        #else
        protected Int64? idfsFinalCaseStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalCaseStatus).OriginalValue; } }
        protected Int64? idfsFinalCaseStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalCaseStatus).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strPersonEnteredBy)]
        [MapField(_str_strPersonEnteredBy)]
        public abstract String strPersonEnteredBy { get; set; }
        #if MONO
        protected String strPersonEnteredBy_Original { get { return strPersonEnteredBy; } }
        protected String strPersonEnteredBy_Previous { get { return strPersonEnteredBy; } }
        #else
        protected String strPersonEnteredBy_Original { get { return ((EditableValue<String>)((dynamic)this)._strPersonEnteredBy).OriginalValue; } }
        protected String strPersonEnteredBy_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPersonEnteredBy).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfHuman)]
        [MapField(_str_idfHuman)]
        public abstract Int64? idfHuman { get; set; }
        #if MONO
        protected Int64? idfHuman_Original { get { return idfHuman; } }
        protected Int64? idfHuman_Previous { get { return idfHuman; } }
        #else
        protected Int64? idfHuman_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHuman).OriginalValue; } }
        protected Int64? idfHuman_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHuman).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsOccupationType)]
        [MapField(_str_idfsOccupationType)]
        public abstract Int64? idfsOccupationType { get; set; }
        #if MONO
        protected Int64? idfsOccupationType_Original { get { return idfsOccupationType; } }
        protected Int64? idfsOccupationType_Previous { get { return idfsOccupationType; } }
        #else
        protected Int64? idfsOccupationType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOccupationType).OriginalValue; } }
        protected Int64? idfsOccupationType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOccupationType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfRegistrationAddress)]
        [MapField(_str_idfRegistrationAddress)]
        public abstract Int64? idfRegistrationAddress { get; set; }
        #if MONO
        protected Int64? idfRegistrationAddress_Original { get { return idfRegistrationAddress; } }
        protected Int64? idfRegistrationAddress_Previous { get { return idfRegistrationAddress; } }
        #else
        protected Int64? idfRegistrationAddress_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRegistrationAddress).OriginalValue; } }
        protected Int64? idfRegistrationAddress_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRegistrationAddress).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datDateOfDeath)]
        [MapField(_str_datDateOfDeath)]
        public abstract DateTime? datDateOfDeath { get; set; }
        #if MONO
        protected DateTime? datDateOfDeath_Original { get { return datDateOfDeath; } }
        protected DateTime? datDateOfDeath_Previous { get { return datDateOfDeath; } }
        #else
        protected DateTime? datDateOfDeath_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateOfDeath).OriginalValue; } }
        protected DateTime? datDateOfDeath_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateOfDeath).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strRegistrationPhone)]
        [MapField(_str_strRegistrationPhone)]
        public abstract String strRegistrationPhone { get; set; }
        #if MONO
        protected String strRegistrationPhone_Original { get { return strRegistrationPhone; } }
        protected String strRegistrationPhone_Previous { get { return strRegistrationPhone; } }
        #else
        protected String strRegistrationPhone_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegistrationPhone).OriginalValue; } }
        protected String strRegistrationPhone_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegistrationPhone).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strWorkPhone)]
        [MapField(_str_strWorkPhone)]
        public abstract String strWorkPhone { get; set; }
        #if MONO
        protected String strWorkPhone_Original { get { return strWorkPhone; } }
        protected String strWorkPhone_Previous { get { return strWorkPhone; } }
        #else
        protected String strWorkPhone_Original { get { return ((EditableValue<String>)((dynamic)this)._strWorkPhone).OriginalValue; } }
        protected String strWorkPhone_Previous { get { return ((EditableValue<String>)((dynamic)this)._strWorkPhone).PreviousValue; } }
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
                
        [LocalizedDisplayName("strNotes")]
        [MapField(_str_strSampleNotes)]
        public abstract String strSampleNotes { get; set; }
        #if MONO
        protected String strSampleNotes_Original { get { return strSampleNotes; } }
        protected String strSampleNotes_Previous { get { return strSampleNotes; } }
        #else
        protected String strSampleNotes_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleNotes).OriginalValue; } }
        protected String strSampleNotes_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleNotes).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<HumanCase, object> _get_func;
            internal Action<HumanCase, string> _set_func;
            internal Action<HumanCase, HumanCase, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfOutbreak = "idfOutbreak";
        internal const string _str_datEnteredDate = "datEnteredDate";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_idfsCaseProgressStatus = "idfsCaseProgressStatus";
        internal const string _str_uidOfflineCaseID = "uidOfflineCaseID";
        internal const string _str_idfsFinalState = "idfsFinalState";
        internal const string _str_idfsHospitalizationStatus = "idfsHospitalizationStatus";
        internal const string _str_idfsHumanAgeType = "idfsHumanAgeType";
        internal const string _str_idfsYNAntimicrobialTherapy = "idfsYNAntimicrobialTherapy";
        internal const string _str_idfsYNHospitalization = "idfsYNHospitalization";
        internal const string _str_idfsYNSpecimenCollected = "idfsYNSpecimenCollected";
        internal const string _str_idfsYNRelatedToOutbreak = "idfsYNRelatedToOutbreak";
        internal const string _str_idfsYNTestsConducted = "idfsYNTestsConducted";
        internal const string _str_blnEnableTestsConducted = "blnEnableTestsConducted";
        internal const string _str_idfsOutcome = "idfsOutcome";
        internal const string _str_idfsTentativeDiagnosis = "idfsTentativeDiagnosis";
        internal const string _str_idfsFinalDiagnosis = "idfsFinalDiagnosis";
        internal const string _str_idfsInitialCaseStatus = "idfsInitialCaseStatus";
        internal const string _str_idfSentByOffice = "idfSentByOffice";
        internal const string _str_strSentByOffice = "strSentByOffice";
        internal const string _str_idfSentByPerson = "idfSentByPerson";
        internal const string _str_strSentByPerson = "strSentByPerson";
        internal const string _str_idfReceivedByOffice = "idfReceivedByOffice";
        internal const string _str_strReceivedByOffice = "strReceivedByOffice";
        internal const string _str_idfReceivedByPerson = "idfReceivedByPerson";
        internal const string _str_strReceivedByPerson = "strReceivedByPerson";
        internal const string _str_idfInvestigatedByOffice = "idfInvestigatedByOffice";
        internal const string _str_strInvestigatedByOffice = "strInvestigatedByOffice";
        internal const string _str_idfInvestigatedByPerson = "idfInvestigatedByPerson";
        internal const string _str_strInvestigatedByPerson = "strInvestigatedByPerson";
        internal const string _str_idfPointGeoLocation = "idfPointGeoLocation";
        internal const string _str_idfEpiObservation = "idfEpiObservation";
        internal const string _str_idfsEPIFormTemplate = "idfsEPIFormTemplate";
        internal const string _str_idfCSObservation = "idfCSObservation";
        internal const string _str_idfsCSFormTemplate = "idfsCSFormTemplate";
        internal const string _str_datNotificationDate = "datNotificationDate";
        internal const string _str_datCompletionPaperFormDate = "datCompletionPaperFormDate";
        internal const string _str_datFirstSoughtCareDate = "datFirstSoughtCareDate";
        internal const string _str_datModificationDate = "datModificationDate";
        internal const string _str_datHospitalizationDate = "datHospitalizationDate";
        internal const string _str_datFacilityLastVisit = "datFacilityLastVisit";
        internal const string _str_datExposureDate = "datExposureDate";
        internal const string _str_datDischargeDate = "datDischargeDate";
        internal const string _str_datOnSetDate = "datOnSetDate";
        internal const string _str_datInvestigationStartDate = "datInvestigationStartDate";
        internal const string _str_datTentativeDiagnosisDate = "datTentativeDiagnosisDate";
        internal const string _str_datFinalDiagnosisDate = "datFinalDiagnosisDate";
        internal const string _str_strNote = "strNote";
        internal const string _str_strCurrentLocation = "strCurrentLocation";
        internal const string _str_strHospitalizationPlace = "strHospitalizationPlace";
        internal const string _str_strLocalIdentifier = "strLocalIdentifier";
        internal const string _str_idfSoughtCareFacility = "idfSoughtCareFacility";
        internal const string _str_strSoughtCareFacility = "strSoughtCareFacility";
        internal const string _str_strSentByFirstName = "strSentByFirstName";
        internal const string _str_strSentByPatronymicName = "strSentByPatronymicName";
        internal const string _str_strSentByLastName = "strSentByLastName";
        internal const string _str_strReceivedByFirstName = "strReceivedByFirstName";
        internal const string _str_strReceivedByPatronymicName = "strReceivedByPatronymicName";
        internal const string _str_strReceivedByLastName = "strReceivedByLastName";
        internal const string _str_strEpidemiologistsName = "strEpidemiologistsName";
        internal const string _str_idfsNotCollectedReason = "idfsNotCollectedReason";
        internal const string _str_idfsNonNotifiableDiagnosis = "idfsNonNotifiableDiagnosis";
        internal const string _str_intPatientAge = "intPatientAge";
        internal const string _str_blnClinicalDiagBasis = "blnClinicalDiagBasis";
        internal const string _str_blnLabDiagBasis = "blnLabDiagBasis";
        internal const string _str_blnEpiDiagBasis = "blnEpiDiagBasis";
        internal const string _str_strClinicalNotes = "strClinicalNotes";
        internal const string _str_strSummaryNotes = "strSummaryNotes";
        internal const string _str_idfsFinalCaseStatus = "idfsFinalCaseStatus";
        internal const string _str_idfPersonEnteredBy = "idfPersonEnteredBy";
        internal const string _str_strPersonEnteredBy = "strPersonEnteredBy";
        internal const string _str_idfHuman = "idfHuman";
        internal const string _str_idfsOccupationType = "idfsOccupationType";
        internal const string _str_idfRegistrationAddress = "idfRegistrationAddress";
        internal const string _str_datDateOfDeath = "datDateOfDeath";
        internal const string _str_strRegistrationPhone = "strRegistrationPhone";
        internal const string _str_strWorkPhone = "strWorkPhone";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_strSampleNotes = "strSampleNotes";
        internal const string _str_strDiagnosis = "strDiagnosis";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_DiagnosisAll = "DiagnosisAll";
        internal const string _str_strCaseClassification = "strCaseClassification";
        internal const string _str_datD = "datD";
        internal const string _str_IsClosed = "IsClosed";
        internal const string _str_strReadOnlyLocalIdentifier = "strReadOnlyLocalIdentifier";
        internal const string _str_strReadOnlyNotificationDate = "strReadOnlyNotificationDate";
        internal const string _str_strReadOnlyFacilityLastVisit = "strReadOnlyFacilityLastVisit";
        internal const string _str_strReadOnlyEnteredDate = "strReadOnlyEnteredDate";
        internal const string _str_strReadOnlyModificationDate = "strReadOnlyModificationDate";
        internal const string _str_strReadOnlyOnSetDate = "strReadOnlyOnSetDate";
        internal const string _str_strReadOnlyDiagnosisDate = "strReadOnlyDiagnosisDate";
        internal const string _str_strReadOnlyFinalDiagnosisDate = "strReadOnlyFinalDiagnosisDate";
        internal const string _str_strReadOnlyTentativeDiagnosis1 = "strReadOnlyTentativeDiagnosis1";
        internal const string _str_strReadOnlyDiagnosis = "strReadOnlyDiagnosis";
        internal const string _str_isChangeDiagnosisReasonEnter = "isChangeDiagnosisReasonEnter";
        internal const string _str_blnEnableTestsConductedCalc = "blnEnableTestsConductedCalc";
        internal const string _str_buttonGeoLocationPicker = "buttonGeoLocationPicker";
        internal const string _str_idfsChangeDiagnosisReason = "idfsChangeDiagnosisReason";
        internal const string _str_CaseProgressStatus = "CaseProgressStatus";
        internal const string _str_PatientState = "PatientState";
        internal const string _str_PatientLocationType = "PatientLocationType";
        internal const string _str_AntimicrobialTherapyUsed = "AntimicrobialTherapyUsed";
        internal const string _str_Hospitalization = "Hospitalization";
        internal const string _str_SpecimenCollected = "SpecimenCollected";
        internal const string _str_RelatedToOutbreak = "RelatedToOutbreak";
        internal const string _str_TestsConducted = "TestsConducted";
        internal const string _str_Outcome = "Outcome";
        internal const string _str_TentativeDiagnosis = "TentativeDiagnosis";
        internal const string _str_FinalDiagnosis = "FinalDiagnosis";
        internal const string _str_InitialCaseStatus = "InitialCaseStatus";
        internal const string _str_NonNotifiableDiagnosis = "NonNotifiableDiagnosis";
        internal const string _str_FinalCaseStatus = "FinalCaseStatus";
        internal const string _str_OccupationType = "OccupationType";
        internal const string _str_NotCollectedReason = "NotCollectedReason";
        internal const string _str_SentByOffice = "SentByOffice";
        internal const string _str_ReceivedByOffice = "ReceivedByOffice";
        internal const string _str_SentByPerson = "SentByPerson";
        internal const string _str_ReceivedByPerson = "ReceivedByPerson";
        internal const string _str_PointGeoLocation = "PointGeoLocation";
        internal const string _str_FFPresenterCs = "FFPresenterCs";
        internal const string _str_FFPresenterEpi = "FFPresenterEpi";
        internal const string _str_Patient = "Patient";
        internal const string _str_RegistrationAddress = "RegistrationAddress";
        internal const string _str_CaseTests = "CaseTests";
        internal const string _str_CaseTestValidations = "CaseTestValidations";
        internal const string _str_ContactedPerson = "ContactedPerson";
        internal const string _str_Samples = "Samples";
        internal const string _str_AntimicrobialTherapy = "AntimicrobialTherapy";
        internal const string _str_DiagnosisHistory = "DiagnosisHistory";
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
              _name = _str_idfOutbreak, _type = "Int64?",
              _get_func = o => o.idfOutbreak,
              _set_func = (o, val) => { o.idfOutbreak = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfOutbreak != c.idfOutbreak || o.IsRIRPropChanged(_str_idfOutbreak, c)) 
                  m.Add(_str_idfOutbreak, o.ObjectIdent + _str_idfOutbreak, "Int64?", o.idfOutbreak == null ? "" : o.idfOutbreak.ToString(), o.IsReadOnly(_str_idfOutbreak), o.IsInvisible(_str_idfOutbreak), o.IsRequired(_str_idfOutbreak)); }
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
              _name = _str_idfsCaseProgressStatus, _type = "Int64?",
              _get_func = o => o.idfsCaseProgressStatus,
              _set_func = (o, val) => { o.idfsCaseProgressStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseProgressStatus != c.idfsCaseProgressStatus || o.IsRIRPropChanged(_str_idfsCaseProgressStatus, c)) 
                  m.Add(_str_idfsCaseProgressStatus, o.ObjectIdent + _str_idfsCaseProgressStatus, "Int64?", o.idfsCaseProgressStatus == null ? "" : o.idfsCaseProgressStatus.ToString(), o.IsReadOnly(_str_idfsCaseProgressStatus), o.IsInvisible(_str_idfsCaseProgressStatus), o.IsRequired(_str_idfsCaseProgressStatus)); }
              }, 
        
            new field_info {
              _name = _str_uidOfflineCaseID, _type = "Guid?",
              _get_func = o => o.uidOfflineCaseID,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
                if (o.uidOfflineCaseID != c.uidOfflineCaseID || o.IsRIRPropChanged(_str_uidOfflineCaseID, c)) 
                  m.Add(_str_uidOfflineCaseID, o.ObjectIdent + _str_uidOfflineCaseID, "Guid?", o.uidOfflineCaseID == null ? "" : o.uidOfflineCaseID.ToString(), o.IsReadOnly(_str_uidOfflineCaseID), o.IsInvisible(_str_uidOfflineCaseID), o.IsRequired(_str_uidOfflineCaseID)); }
              }, 
        
            new field_info {
              _name = _str_idfsFinalState, _type = "Int64?",
              _get_func = o => o.idfsFinalState,
              _set_func = (o, val) => { o.idfsFinalState = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFinalState != c.idfsFinalState || o.IsRIRPropChanged(_str_idfsFinalState, c)) 
                  m.Add(_str_idfsFinalState, o.ObjectIdent + _str_idfsFinalState, "Int64?", o.idfsFinalState == null ? "" : o.idfsFinalState.ToString(), o.IsReadOnly(_str_idfsFinalState), o.IsInvisible(_str_idfsFinalState), o.IsRequired(_str_idfsFinalState)); }
              }, 
        
            new field_info {
              _name = _str_idfsHospitalizationStatus, _type = "Int64?",
              _get_func = o => o.idfsHospitalizationStatus,
              _set_func = (o, val) => { o.idfsHospitalizationStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsHospitalizationStatus != c.idfsHospitalizationStatus || o.IsRIRPropChanged(_str_idfsHospitalizationStatus, c)) 
                  m.Add(_str_idfsHospitalizationStatus, o.ObjectIdent + _str_idfsHospitalizationStatus, "Int64?", o.idfsHospitalizationStatus == null ? "" : o.idfsHospitalizationStatus.ToString(), o.IsReadOnly(_str_idfsHospitalizationStatus), o.IsInvisible(_str_idfsHospitalizationStatus), o.IsRequired(_str_idfsHospitalizationStatus)); }
              }, 
        
            new field_info {
              _name = _str_idfsHumanAgeType, _type = "Int64?",
              _get_func = o => o.idfsHumanAgeType,
              _set_func = (o, val) => { o.idfsHumanAgeType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsHumanAgeType != c.idfsHumanAgeType || o.IsRIRPropChanged(_str_idfsHumanAgeType, c)) 
                  m.Add(_str_idfsHumanAgeType, o.ObjectIdent + _str_idfsHumanAgeType, "Int64?", o.idfsHumanAgeType == null ? "" : o.idfsHumanAgeType.ToString(), o.IsReadOnly(_str_idfsHumanAgeType), o.IsInvisible(_str_idfsHumanAgeType), o.IsRequired(_str_idfsHumanAgeType)); }
              }, 
        
            new field_info {
              _name = _str_idfsYNAntimicrobialTherapy, _type = "Int64?",
              _get_func = o => o.idfsYNAntimicrobialTherapy,
              _set_func = (o, val) => { o.idfsYNAntimicrobialTherapy = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNAntimicrobialTherapy != c.idfsYNAntimicrobialTherapy || o.IsRIRPropChanged(_str_idfsYNAntimicrobialTherapy, c)) 
                  m.Add(_str_idfsYNAntimicrobialTherapy, o.ObjectIdent + _str_idfsYNAntimicrobialTherapy, "Int64?", o.idfsYNAntimicrobialTherapy == null ? "" : o.idfsYNAntimicrobialTherapy.ToString(), o.IsReadOnly(_str_idfsYNAntimicrobialTherapy), o.IsInvisible(_str_idfsYNAntimicrobialTherapy), o.IsRequired(_str_idfsYNAntimicrobialTherapy)); }
              }, 
        
            new field_info {
              _name = _str_idfsYNHospitalization, _type = "Int64?",
              _get_func = o => o.idfsYNHospitalization,
              _set_func = (o, val) => { o.idfsYNHospitalization = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNHospitalization != c.idfsYNHospitalization || o.IsRIRPropChanged(_str_idfsYNHospitalization, c)) 
                  m.Add(_str_idfsYNHospitalization, o.ObjectIdent + _str_idfsYNHospitalization, "Int64?", o.idfsYNHospitalization == null ? "" : o.idfsYNHospitalization.ToString(), o.IsReadOnly(_str_idfsYNHospitalization), o.IsInvisible(_str_idfsYNHospitalization), o.IsRequired(_str_idfsYNHospitalization)); }
              }, 
        
            new field_info {
              _name = _str_idfsYNSpecimenCollected, _type = "Int64?",
              _get_func = o => o.idfsYNSpecimenCollected,
              _set_func = (o, val) => { o.idfsYNSpecimenCollected = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNSpecimenCollected != c.idfsYNSpecimenCollected || o.IsRIRPropChanged(_str_idfsYNSpecimenCollected, c)) 
                  m.Add(_str_idfsYNSpecimenCollected, o.ObjectIdent + _str_idfsYNSpecimenCollected, "Int64?", o.idfsYNSpecimenCollected == null ? "" : o.idfsYNSpecimenCollected.ToString(), o.IsReadOnly(_str_idfsYNSpecimenCollected), o.IsInvisible(_str_idfsYNSpecimenCollected), o.IsRequired(_str_idfsYNSpecimenCollected)); }
              }, 
        
            new field_info {
              _name = _str_idfsYNRelatedToOutbreak, _type = "Int64?",
              _get_func = o => o.idfsYNRelatedToOutbreak,
              _set_func = (o, val) => { o.idfsYNRelatedToOutbreak = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNRelatedToOutbreak != c.idfsYNRelatedToOutbreak || o.IsRIRPropChanged(_str_idfsYNRelatedToOutbreak, c)) 
                  m.Add(_str_idfsYNRelatedToOutbreak, o.ObjectIdent + _str_idfsYNRelatedToOutbreak, "Int64?", o.idfsYNRelatedToOutbreak == null ? "" : o.idfsYNRelatedToOutbreak.ToString(), o.IsReadOnly(_str_idfsYNRelatedToOutbreak), o.IsInvisible(_str_idfsYNRelatedToOutbreak), o.IsRequired(_str_idfsYNRelatedToOutbreak)); }
              }, 
        
            new field_info {
              _name = _str_idfsYNTestsConducted, _type = "Int64?",
              _get_func = o => o.idfsYNTestsConducted,
              _set_func = (o, val) => { o.idfsYNTestsConducted = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNTestsConducted != c.idfsYNTestsConducted || o.IsRIRPropChanged(_str_idfsYNTestsConducted, c)) 
                  m.Add(_str_idfsYNTestsConducted, o.ObjectIdent + _str_idfsYNTestsConducted, "Int64?", o.idfsYNTestsConducted == null ? "" : o.idfsYNTestsConducted.ToString(), o.IsReadOnly(_str_idfsYNTestsConducted), o.IsInvisible(_str_idfsYNTestsConducted), o.IsRequired(_str_idfsYNTestsConducted)); }
              }, 
        
            new field_info {
              _name = _str_blnEnableTestsConducted, _type = "Boolean?",
              _get_func = o => o.blnEnableTestsConducted,
              _set_func = (o, val) => { o.blnEnableTestsConducted = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnEnableTestsConducted != c.blnEnableTestsConducted || o.IsRIRPropChanged(_str_blnEnableTestsConducted, c)) 
                  m.Add(_str_blnEnableTestsConducted, o.ObjectIdent + _str_blnEnableTestsConducted, "Boolean?", o.blnEnableTestsConducted == null ? "" : o.blnEnableTestsConducted.ToString(), o.IsReadOnly(_str_blnEnableTestsConducted), o.IsInvisible(_str_blnEnableTestsConducted), o.IsRequired(_str_blnEnableTestsConducted)); }
              }, 
        
            new field_info {
              _name = _str_idfsOutcome, _type = "Int64?",
              _get_func = o => o.idfsOutcome,
              _set_func = (o, val) => { o.idfsOutcome = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsOutcome != c.idfsOutcome || o.IsRIRPropChanged(_str_idfsOutcome, c)) 
                  m.Add(_str_idfsOutcome, o.ObjectIdent + _str_idfsOutcome, "Int64?", o.idfsOutcome == null ? "" : o.idfsOutcome.ToString(), o.IsReadOnly(_str_idfsOutcome), o.IsInvisible(_str_idfsOutcome), o.IsRequired(_str_idfsOutcome)); }
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
              _name = _str_idfsFinalDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsFinalDiagnosis,
              _set_func = (o, val) => { o.idfsFinalDiagnosis = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFinalDiagnosis != c.idfsFinalDiagnosis || o.IsRIRPropChanged(_str_idfsFinalDiagnosis, c)) 
                  m.Add(_str_idfsFinalDiagnosis, o.ObjectIdent + _str_idfsFinalDiagnosis, "Int64?", o.idfsFinalDiagnosis == null ? "" : o.idfsFinalDiagnosis.ToString(), o.IsReadOnly(_str_idfsFinalDiagnosis), o.IsInvisible(_str_idfsFinalDiagnosis), o.IsRequired(_str_idfsFinalDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_idfsInitialCaseStatus, _type = "Int64?",
              _get_func = o => o.idfsInitialCaseStatus,
              _set_func = (o, val) => { o.idfsInitialCaseStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsInitialCaseStatus != c.idfsInitialCaseStatus || o.IsRIRPropChanged(_str_idfsInitialCaseStatus, c)) 
                  m.Add(_str_idfsInitialCaseStatus, o.ObjectIdent + _str_idfsInitialCaseStatus, "Int64?", o.idfsInitialCaseStatus == null ? "" : o.idfsInitialCaseStatus.ToString(), o.IsReadOnly(_str_idfsInitialCaseStatus), o.IsInvisible(_str_idfsInitialCaseStatus), o.IsRequired(_str_idfsInitialCaseStatus)); }
              }, 
        
            new field_info {
              _name = _str_idfSentByOffice, _type = "Int64?",
              _get_func = o => o.idfSentByOffice,
              _set_func = (o, val) => { o.idfSentByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSentByOffice != c.idfSentByOffice || o.IsRIRPropChanged(_str_idfSentByOffice, c)) 
                  m.Add(_str_idfSentByOffice, o.ObjectIdent + _str_idfSentByOffice, "Int64?", o.idfSentByOffice == null ? "" : o.idfSentByOffice.ToString(), o.IsReadOnly(_str_idfSentByOffice), o.IsInvisible(_str_idfSentByOffice), o.IsRequired(_str_idfSentByOffice)); }
              }, 
        
            new field_info {
              _name = _str_strSentByOffice, _type = "String",
              _get_func = o => o.strSentByOffice,
              _set_func = (o, val) => { o.strSentByOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSentByOffice != c.strSentByOffice || o.IsRIRPropChanged(_str_strSentByOffice, c)) 
                  m.Add(_str_strSentByOffice, o.ObjectIdent + _str_strSentByOffice, "String", o.strSentByOffice == null ? "" : o.strSentByOffice.ToString(), o.IsReadOnly(_str_strSentByOffice), o.IsInvisible(_str_strSentByOffice), o.IsRequired(_str_strSentByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfSentByPerson, _type = "Int64?",
              _get_func = o => o.idfSentByPerson,
              _set_func = (o, val) => { o.idfSentByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSentByPerson != c.idfSentByPerson || o.IsRIRPropChanged(_str_idfSentByPerson, c)) 
                  m.Add(_str_idfSentByPerson, o.ObjectIdent + _str_idfSentByPerson, "Int64?", o.idfSentByPerson == null ? "" : o.idfSentByPerson.ToString(), o.IsReadOnly(_str_idfSentByPerson), o.IsInvisible(_str_idfSentByPerson), o.IsRequired(_str_idfSentByPerson)); }
              }, 
        
            new field_info {
              _name = _str_strSentByPerson, _type = "String",
              _get_func = o => o.strSentByPerson,
              _set_func = (o, val) => { o.strSentByPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSentByPerson != c.strSentByPerson || o.IsRIRPropChanged(_str_strSentByPerson, c)) 
                  m.Add(_str_strSentByPerson, o.ObjectIdent + _str_strSentByPerson, "String", o.strSentByPerson == null ? "" : o.strSentByPerson.ToString(), o.IsReadOnly(_str_strSentByPerson), o.IsInvisible(_str_strSentByPerson), o.IsRequired(_str_strSentByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfReceivedByOffice, _type = "Int64?",
              _get_func = o => o.idfReceivedByOffice,
              _set_func = (o, val) => { o.idfReceivedByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfReceivedByOffice != c.idfReceivedByOffice || o.IsRIRPropChanged(_str_idfReceivedByOffice, c)) 
                  m.Add(_str_idfReceivedByOffice, o.ObjectIdent + _str_idfReceivedByOffice, "Int64?", o.idfReceivedByOffice == null ? "" : o.idfReceivedByOffice.ToString(), o.IsReadOnly(_str_idfReceivedByOffice), o.IsInvisible(_str_idfReceivedByOffice), o.IsRequired(_str_idfReceivedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_strReceivedByOffice, _type = "String",
              _get_func = o => o.strReceivedByOffice,
              _set_func = (o, val) => { o.strReceivedByOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strReceivedByOffice != c.strReceivedByOffice || o.IsRIRPropChanged(_str_strReceivedByOffice, c)) 
                  m.Add(_str_strReceivedByOffice, o.ObjectIdent + _str_strReceivedByOffice, "String", o.strReceivedByOffice == null ? "" : o.strReceivedByOffice.ToString(), o.IsReadOnly(_str_strReceivedByOffice), o.IsInvisible(_str_strReceivedByOffice), o.IsRequired(_str_strReceivedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfReceivedByPerson, _type = "Int64?",
              _get_func = o => o.idfReceivedByPerson,
              _set_func = (o, val) => { o.idfReceivedByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfReceivedByPerson != c.idfReceivedByPerson || o.IsRIRPropChanged(_str_idfReceivedByPerson, c)) 
                  m.Add(_str_idfReceivedByPerson, o.ObjectIdent + _str_idfReceivedByPerson, "Int64?", o.idfReceivedByPerson == null ? "" : o.idfReceivedByPerson.ToString(), o.IsReadOnly(_str_idfReceivedByPerson), o.IsInvisible(_str_idfReceivedByPerson), o.IsRequired(_str_idfReceivedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_strReceivedByPerson, _type = "String",
              _get_func = o => o.strReceivedByPerson,
              _set_func = (o, val) => { o.strReceivedByPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strReceivedByPerson != c.strReceivedByPerson || o.IsRIRPropChanged(_str_strReceivedByPerson, c)) 
                  m.Add(_str_strReceivedByPerson, o.ObjectIdent + _str_strReceivedByPerson, "String", o.strReceivedByPerson == null ? "" : o.strReceivedByPerson.ToString(), o.IsReadOnly(_str_strReceivedByPerson), o.IsInvisible(_str_strReceivedByPerson), o.IsRequired(_str_strReceivedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfInvestigatedByOffice, _type = "Int64?",
              _get_func = o => o.idfInvestigatedByOffice,
              _set_func = (o, val) => { o.idfInvestigatedByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfInvestigatedByOffice != c.idfInvestigatedByOffice || o.IsRIRPropChanged(_str_idfInvestigatedByOffice, c)) 
                  m.Add(_str_idfInvestigatedByOffice, o.ObjectIdent + _str_idfInvestigatedByOffice, "Int64?", o.idfInvestigatedByOffice == null ? "" : o.idfInvestigatedByOffice.ToString(), o.IsReadOnly(_str_idfInvestigatedByOffice), o.IsInvisible(_str_idfInvestigatedByOffice), o.IsRequired(_str_idfInvestigatedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_strInvestigatedByOffice, _type = "String",
              _get_func = o => o.strInvestigatedByOffice,
              _set_func = (o, val) => { o.strInvestigatedByOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strInvestigatedByOffice != c.strInvestigatedByOffice || o.IsRIRPropChanged(_str_strInvestigatedByOffice, c)) 
                  m.Add(_str_strInvestigatedByOffice, o.ObjectIdent + _str_strInvestigatedByOffice, "String", o.strInvestigatedByOffice == null ? "" : o.strInvestigatedByOffice.ToString(), o.IsReadOnly(_str_strInvestigatedByOffice), o.IsInvisible(_str_strInvestigatedByOffice), o.IsRequired(_str_strInvestigatedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfInvestigatedByPerson, _type = "Int64?",
              _get_func = o => o.idfInvestigatedByPerson,
              _set_func = (o, val) => { o.idfInvestigatedByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfInvestigatedByPerson != c.idfInvestigatedByPerson || o.IsRIRPropChanged(_str_idfInvestigatedByPerson, c)) 
                  m.Add(_str_idfInvestigatedByPerson, o.ObjectIdent + _str_idfInvestigatedByPerson, "Int64?", o.idfInvestigatedByPerson == null ? "" : o.idfInvestigatedByPerson.ToString(), o.IsReadOnly(_str_idfInvestigatedByPerson), o.IsInvisible(_str_idfInvestigatedByPerson), o.IsRequired(_str_idfInvestigatedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_strInvestigatedByPerson, _type = "String",
              _get_func = o => o.strInvestigatedByPerson,
              _set_func = (o, val) => { o.strInvestigatedByPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strInvestigatedByPerson != c.strInvestigatedByPerson || o.IsRIRPropChanged(_str_strInvestigatedByPerson, c)) 
                  m.Add(_str_strInvestigatedByPerson, o.ObjectIdent + _str_strInvestigatedByPerson, "String", o.strInvestigatedByPerson == null ? "" : o.strInvestigatedByPerson.ToString(), o.IsReadOnly(_str_strInvestigatedByPerson), o.IsInvisible(_str_strInvestigatedByPerson), o.IsRequired(_str_strInvestigatedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfPointGeoLocation, _type = "Int64?",
              _get_func = o => o.idfPointGeoLocation,
              _set_func = (o, val) => { o.idfPointGeoLocation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfPointGeoLocation != c.idfPointGeoLocation || o.IsRIRPropChanged(_str_idfPointGeoLocation, c)) 
                  m.Add(_str_idfPointGeoLocation, o.ObjectIdent + _str_idfPointGeoLocation, "Int64?", o.idfPointGeoLocation == null ? "" : o.idfPointGeoLocation.ToString(), o.IsReadOnly(_str_idfPointGeoLocation), o.IsInvisible(_str_idfPointGeoLocation), o.IsRequired(_str_idfPointGeoLocation)); }
              }, 
        
            new field_info {
              _name = _str_idfEpiObservation, _type = "Int64?",
              _get_func = o => o.idfEpiObservation,
              _set_func = (o, val) => { o.idfEpiObservation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfEpiObservation != c.idfEpiObservation || o.IsRIRPropChanged(_str_idfEpiObservation, c)) 
                  m.Add(_str_idfEpiObservation, o.ObjectIdent + _str_idfEpiObservation, "Int64?", o.idfEpiObservation == null ? "" : o.idfEpiObservation.ToString(), o.IsReadOnly(_str_idfEpiObservation), o.IsInvisible(_str_idfEpiObservation), o.IsRequired(_str_idfEpiObservation)); }
              }, 
        
            new field_info {
              _name = _str_idfsEPIFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsEPIFormTemplate,
              _set_func = (o, val) => { o.idfsEPIFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsEPIFormTemplate != c.idfsEPIFormTemplate || o.IsRIRPropChanged(_str_idfsEPIFormTemplate, c)) 
                  m.Add(_str_idfsEPIFormTemplate, o.ObjectIdent + _str_idfsEPIFormTemplate, "Int64?", o.idfsEPIFormTemplate == null ? "" : o.idfsEPIFormTemplate.ToString(), o.IsReadOnly(_str_idfsEPIFormTemplate), o.IsInvisible(_str_idfsEPIFormTemplate), o.IsRequired(_str_idfsEPIFormTemplate)); }
              }, 
        
            new field_info {
              _name = _str_idfCSObservation, _type = "Int64?",
              _get_func = o => o.idfCSObservation,
              _set_func = (o, val) => { o.idfCSObservation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCSObservation != c.idfCSObservation || o.IsRIRPropChanged(_str_idfCSObservation, c)) 
                  m.Add(_str_idfCSObservation, o.ObjectIdent + _str_idfCSObservation, "Int64?", o.idfCSObservation == null ? "" : o.idfCSObservation.ToString(), o.IsReadOnly(_str_idfCSObservation), o.IsInvisible(_str_idfCSObservation), o.IsRequired(_str_idfCSObservation)); }
              }, 
        
            new field_info {
              _name = _str_idfsCSFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsCSFormTemplate,
              _set_func = (o, val) => { o.idfsCSFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCSFormTemplate != c.idfsCSFormTemplate || o.IsRIRPropChanged(_str_idfsCSFormTemplate, c)) 
                  m.Add(_str_idfsCSFormTemplate, o.ObjectIdent + _str_idfsCSFormTemplate, "Int64?", o.idfsCSFormTemplate == null ? "" : o.idfsCSFormTemplate.ToString(), o.IsReadOnly(_str_idfsCSFormTemplate), o.IsInvisible(_str_idfsCSFormTemplate), o.IsRequired(_str_idfsCSFormTemplate)); }
              }, 
        
            new field_info {
              _name = _str_datNotificationDate, _type = "DateTime?",
              _get_func = o => o.datNotificationDate,
              _set_func = (o, val) => { o.datNotificationDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datNotificationDate != c.datNotificationDate || o.IsRIRPropChanged(_str_datNotificationDate, c)) 
                  m.Add(_str_datNotificationDate, o.ObjectIdent + _str_datNotificationDate, "DateTime?", o.datNotificationDate == null ? "" : o.datNotificationDate.ToString(), o.IsReadOnly(_str_datNotificationDate), o.IsInvisible(_str_datNotificationDate), o.IsRequired(_str_datNotificationDate)); }
              }, 
        
            new field_info {
              _name = _str_datCompletionPaperFormDate, _type = "DateTime?",
              _get_func = o => o.datCompletionPaperFormDate,
              _set_func = (o, val) => { o.datCompletionPaperFormDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCompletionPaperFormDate != c.datCompletionPaperFormDate || o.IsRIRPropChanged(_str_datCompletionPaperFormDate, c)) 
                  m.Add(_str_datCompletionPaperFormDate, o.ObjectIdent + _str_datCompletionPaperFormDate, "DateTime?", o.datCompletionPaperFormDate == null ? "" : o.datCompletionPaperFormDate.ToString(), o.IsReadOnly(_str_datCompletionPaperFormDate), o.IsInvisible(_str_datCompletionPaperFormDate), o.IsRequired(_str_datCompletionPaperFormDate)); }
              }, 
        
            new field_info {
              _name = _str_datFirstSoughtCareDate, _type = "DateTime?",
              _get_func = o => o.datFirstSoughtCareDate,
              _set_func = (o, val) => { o.datFirstSoughtCareDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datFirstSoughtCareDate != c.datFirstSoughtCareDate || o.IsRIRPropChanged(_str_datFirstSoughtCareDate, c)) 
                  m.Add(_str_datFirstSoughtCareDate, o.ObjectIdent + _str_datFirstSoughtCareDate, "DateTime?", o.datFirstSoughtCareDate == null ? "" : o.datFirstSoughtCareDate.ToString(), o.IsReadOnly(_str_datFirstSoughtCareDate), o.IsInvisible(_str_datFirstSoughtCareDate), o.IsRequired(_str_datFirstSoughtCareDate)); }
              }, 
        
            new field_info {
              _name = _str_datModificationDate, _type = "DateTime?",
              _get_func = o => o.datModificationDate,
              _set_func = (o, val) => { o.datModificationDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datModificationDate != c.datModificationDate || o.IsRIRPropChanged(_str_datModificationDate, c)) 
                  m.Add(_str_datModificationDate, o.ObjectIdent + _str_datModificationDate, "DateTime?", o.datModificationDate == null ? "" : o.datModificationDate.ToString(), o.IsReadOnly(_str_datModificationDate), o.IsInvisible(_str_datModificationDate), o.IsRequired(_str_datModificationDate)); }
              }, 
        
            new field_info {
              _name = _str_datHospitalizationDate, _type = "DateTime?",
              _get_func = o => o.datHospitalizationDate,
              _set_func = (o, val) => { o.datHospitalizationDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datHospitalizationDate != c.datHospitalizationDate || o.IsRIRPropChanged(_str_datHospitalizationDate, c)) 
                  m.Add(_str_datHospitalizationDate, o.ObjectIdent + _str_datHospitalizationDate, "DateTime?", o.datHospitalizationDate == null ? "" : o.datHospitalizationDate.ToString(), o.IsReadOnly(_str_datHospitalizationDate), o.IsInvisible(_str_datHospitalizationDate), o.IsRequired(_str_datHospitalizationDate)); }
              }, 
        
            new field_info {
              _name = _str_datFacilityLastVisit, _type = "DateTime?",
              _get_func = o => o.datFacilityLastVisit,
              _set_func = (o, val) => { o.datFacilityLastVisit = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datFacilityLastVisit != c.datFacilityLastVisit || o.IsRIRPropChanged(_str_datFacilityLastVisit, c)) 
                  m.Add(_str_datFacilityLastVisit, o.ObjectIdent + _str_datFacilityLastVisit, "DateTime?", o.datFacilityLastVisit == null ? "" : o.datFacilityLastVisit.ToString(), o.IsReadOnly(_str_datFacilityLastVisit), o.IsInvisible(_str_datFacilityLastVisit), o.IsRequired(_str_datFacilityLastVisit)); }
              }, 
        
            new field_info {
              _name = _str_datExposureDate, _type = "DateTime?",
              _get_func = o => o.datExposureDate,
              _set_func = (o, val) => { o.datExposureDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datExposureDate != c.datExposureDate || o.IsRIRPropChanged(_str_datExposureDate, c)) 
                  m.Add(_str_datExposureDate, o.ObjectIdent + _str_datExposureDate, "DateTime?", o.datExposureDate == null ? "" : o.datExposureDate.ToString(), o.IsReadOnly(_str_datExposureDate), o.IsInvisible(_str_datExposureDate), o.IsRequired(_str_datExposureDate)); }
              }, 
        
            new field_info {
              _name = _str_datDischargeDate, _type = "DateTime?",
              _get_func = o => o.datDischargeDate,
              _set_func = (o, val) => { o.datDischargeDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datDischargeDate != c.datDischargeDate || o.IsRIRPropChanged(_str_datDischargeDate, c)) 
                  m.Add(_str_datDischargeDate, o.ObjectIdent + _str_datDischargeDate, "DateTime?", o.datDischargeDate == null ? "" : o.datDischargeDate.ToString(), o.IsReadOnly(_str_datDischargeDate), o.IsInvisible(_str_datDischargeDate), o.IsRequired(_str_datDischargeDate)); }
              }, 
        
            new field_info {
              _name = _str_datOnSetDate, _type = "DateTime?",
              _get_func = o => o.datOnSetDate,
              _set_func = (o, val) => { o.datOnSetDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datOnSetDate != c.datOnSetDate || o.IsRIRPropChanged(_str_datOnSetDate, c)) 
                  m.Add(_str_datOnSetDate, o.ObjectIdent + _str_datOnSetDate, "DateTime?", o.datOnSetDate == null ? "" : o.datOnSetDate.ToString(), o.IsReadOnly(_str_datOnSetDate), o.IsInvisible(_str_datOnSetDate), o.IsRequired(_str_datOnSetDate)); }
              }, 
        
            new field_info {
              _name = _str_datInvestigationStartDate, _type = "DateTime?",
              _get_func = o => o.datInvestigationStartDate,
              _set_func = (o, val) => { o.datInvestigationStartDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datInvestigationStartDate != c.datInvestigationStartDate || o.IsRIRPropChanged(_str_datInvestigationStartDate, c)) 
                  m.Add(_str_datInvestigationStartDate, o.ObjectIdent + _str_datInvestigationStartDate, "DateTime?", o.datInvestigationStartDate == null ? "" : o.datInvestigationStartDate.ToString(), o.IsReadOnly(_str_datInvestigationStartDate), o.IsInvisible(_str_datInvestigationStartDate), o.IsRequired(_str_datInvestigationStartDate)); }
              }, 
        
            new field_info {
              _name = _str_datTentativeDiagnosisDate, _type = "DateTime?",
              _get_func = o => o.datTentativeDiagnosisDate,
              _set_func = (o, val) => { o.datTentativeDiagnosisDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datTentativeDiagnosisDate != c.datTentativeDiagnosisDate || o.IsRIRPropChanged(_str_datTentativeDiagnosisDate, c)) 
                  m.Add(_str_datTentativeDiagnosisDate, o.ObjectIdent + _str_datTentativeDiagnosisDate, "DateTime?", o.datTentativeDiagnosisDate == null ? "" : o.datTentativeDiagnosisDate.ToString(), o.IsReadOnly(_str_datTentativeDiagnosisDate), o.IsInvisible(_str_datTentativeDiagnosisDate), o.IsRequired(_str_datTentativeDiagnosisDate)); }
              }, 
        
            new field_info {
              _name = _str_datFinalDiagnosisDate, _type = "DateTime?",
              _get_func = o => o.datFinalDiagnosisDate,
              _set_func = (o, val) => { o.datFinalDiagnosisDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datFinalDiagnosisDate != c.datFinalDiagnosisDate || o.IsRIRPropChanged(_str_datFinalDiagnosisDate, c)) 
                  m.Add(_str_datFinalDiagnosisDate, o.ObjectIdent + _str_datFinalDiagnosisDate, "DateTime?", o.datFinalDiagnosisDate == null ? "" : o.datFinalDiagnosisDate.ToString(), o.IsReadOnly(_str_datFinalDiagnosisDate), o.IsInvisible(_str_datFinalDiagnosisDate), o.IsRequired(_str_datFinalDiagnosisDate)); }
              }, 
        
            new field_info {
              _name = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { o.strNote = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, "String", o.strNote == null ? "" : o.strNote.ToString(), o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); }
              }, 
        
            new field_info {
              _name = _str_strCurrentLocation, _type = "String",
              _get_func = o => o.strCurrentLocation,
              _set_func = (o, val) => { o.strCurrentLocation = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCurrentLocation != c.strCurrentLocation || o.IsRIRPropChanged(_str_strCurrentLocation, c)) 
                  m.Add(_str_strCurrentLocation, o.ObjectIdent + _str_strCurrentLocation, "String", o.strCurrentLocation == null ? "" : o.strCurrentLocation.ToString(), o.IsReadOnly(_str_strCurrentLocation), o.IsInvisible(_str_strCurrentLocation), o.IsRequired(_str_strCurrentLocation)); }
              }, 
        
            new field_info {
              _name = _str_strHospitalizationPlace, _type = "String",
              _get_func = o => o.strHospitalizationPlace,
              _set_func = (o, val) => { o.strHospitalizationPlace = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strHospitalizationPlace != c.strHospitalizationPlace || o.IsRIRPropChanged(_str_strHospitalizationPlace, c)) 
                  m.Add(_str_strHospitalizationPlace, o.ObjectIdent + _str_strHospitalizationPlace, "String", o.strHospitalizationPlace == null ? "" : o.strHospitalizationPlace.ToString(), o.IsReadOnly(_str_strHospitalizationPlace), o.IsInvisible(_str_strHospitalizationPlace), o.IsRequired(_str_strHospitalizationPlace)); }
              }, 
        
            new field_info {
              _name = _str_strLocalIdentifier, _type = "String",
              _get_func = o => o.strLocalIdentifier,
              _set_func = (o, val) => { o.strLocalIdentifier = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strLocalIdentifier != c.strLocalIdentifier || o.IsRIRPropChanged(_str_strLocalIdentifier, c)) 
                  m.Add(_str_strLocalIdentifier, o.ObjectIdent + _str_strLocalIdentifier, "String", o.strLocalIdentifier == null ? "" : o.strLocalIdentifier.ToString(), o.IsReadOnly(_str_strLocalIdentifier), o.IsInvisible(_str_strLocalIdentifier), o.IsRequired(_str_strLocalIdentifier)); }
              }, 
        
            new field_info {
              _name = _str_idfSoughtCareFacility, _type = "Int64?",
              _get_func = o => o.idfSoughtCareFacility,
              _set_func = (o, val) => { o.idfSoughtCareFacility = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSoughtCareFacility != c.idfSoughtCareFacility || o.IsRIRPropChanged(_str_idfSoughtCareFacility, c)) 
                  m.Add(_str_idfSoughtCareFacility, o.ObjectIdent + _str_idfSoughtCareFacility, "Int64?", o.idfSoughtCareFacility == null ? "" : o.idfSoughtCareFacility.ToString(), o.IsReadOnly(_str_idfSoughtCareFacility), o.IsInvisible(_str_idfSoughtCareFacility), o.IsRequired(_str_idfSoughtCareFacility)); }
              }, 
        
            new field_info {
              _name = _str_strSoughtCareFacility, _type = "String",
              _get_func = o => o.strSoughtCareFacility,
              _set_func = (o, val) => { o.strSoughtCareFacility = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSoughtCareFacility != c.strSoughtCareFacility || o.IsRIRPropChanged(_str_strSoughtCareFacility, c)) 
                  m.Add(_str_strSoughtCareFacility, o.ObjectIdent + _str_strSoughtCareFacility, "String", o.strSoughtCareFacility == null ? "" : o.strSoughtCareFacility.ToString(), o.IsReadOnly(_str_strSoughtCareFacility), o.IsInvisible(_str_strSoughtCareFacility), o.IsRequired(_str_strSoughtCareFacility)); }
              }, 
        
            new field_info {
              _name = _str_strSentByFirstName, _type = "String",
              _get_func = o => o.strSentByFirstName,
              _set_func = (o, val) => { o.strSentByFirstName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSentByFirstName != c.strSentByFirstName || o.IsRIRPropChanged(_str_strSentByFirstName, c)) 
                  m.Add(_str_strSentByFirstName, o.ObjectIdent + _str_strSentByFirstName, "String", o.strSentByFirstName == null ? "" : o.strSentByFirstName.ToString(), o.IsReadOnly(_str_strSentByFirstName), o.IsInvisible(_str_strSentByFirstName), o.IsRequired(_str_strSentByFirstName)); }
              }, 
        
            new field_info {
              _name = _str_strSentByPatronymicName, _type = "String",
              _get_func = o => o.strSentByPatronymicName,
              _set_func = (o, val) => { o.strSentByPatronymicName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSentByPatronymicName != c.strSentByPatronymicName || o.IsRIRPropChanged(_str_strSentByPatronymicName, c)) 
                  m.Add(_str_strSentByPatronymicName, o.ObjectIdent + _str_strSentByPatronymicName, "String", o.strSentByPatronymicName == null ? "" : o.strSentByPatronymicName.ToString(), o.IsReadOnly(_str_strSentByPatronymicName), o.IsInvisible(_str_strSentByPatronymicName), o.IsRequired(_str_strSentByPatronymicName)); }
              }, 
        
            new field_info {
              _name = _str_strSentByLastName, _type = "String",
              _get_func = o => o.strSentByLastName,
              _set_func = (o, val) => { o.strSentByLastName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSentByLastName != c.strSentByLastName || o.IsRIRPropChanged(_str_strSentByLastName, c)) 
                  m.Add(_str_strSentByLastName, o.ObjectIdent + _str_strSentByLastName, "String", o.strSentByLastName == null ? "" : o.strSentByLastName.ToString(), o.IsReadOnly(_str_strSentByLastName), o.IsInvisible(_str_strSentByLastName), o.IsRequired(_str_strSentByLastName)); }
              }, 
        
            new field_info {
              _name = _str_strReceivedByFirstName, _type = "String",
              _get_func = o => o.strReceivedByFirstName,
              _set_func = (o, val) => { o.strReceivedByFirstName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strReceivedByFirstName != c.strReceivedByFirstName || o.IsRIRPropChanged(_str_strReceivedByFirstName, c)) 
                  m.Add(_str_strReceivedByFirstName, o.ObjectIdent + _str_strReceivedByFirstName, "String", o.strReceivedByFirstName == null ? "" : o.strReceivedByFirstName.ToString(), o.IsReadOnly(_str_strReceivedByFirstName), o.IsInvisible(_str_strReceivedByFirstName), o.IsRequired(_str_strReceivedByFirstName)); }
              }, 
        
            new field_info {
              _name = _str_strReceivedByPatronymicName, _type = "String",
              _get_func = o => o.strReceivedByPatronymicName,
              _set_func = (o, val) => { o.strReceivedByPatronymicName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strReceivedByPatronymicName != c.strReceivedByPatronymicName || o.IsRIRPropChanged(_str_strReceivedByPatronymicName, c)) 
                  m.Add(_str_strReceivedByPatronymicName, o.ObjectIdent + _str_strReceivedByPatronymicName, "String", o.strReceivedByPatronymicName == null ? "" : o.strReceivedByPatronymicName.ToString(), o.IsReadOnly(_str_strReceivedByPatronymicName), o.IsInvisible(_str_strReceivedByPatronymicName), o.IsRequired(_str_strReceivedByPatronymicName)); }
              }, 
        
            new field_info {
              _name = _str_strReceivedByLastName, _type = "String",
              _get_func = o => o.strReceivedByLastName,
              _set_func = (o, val) => { o.strReceivedByLastName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strReceivedByLastName != c.strReceivedByLastName || o.IsRIRPropChanged(_str_strReceivedByLastName, c)) 
                  m.Add(_str_strReceivedByLastName, o.ObjectIdent + _str_strReceivedByLastName, "String", o.strReceivedByLastName == null ? "" : o.strReceivedByLastName.ToString(), o.IsReadOnly(_str_strReceivedByLastName), o.IsInvisible(_str_strReceivedByLastName), o.IsRequired(_str_strReceivedByLastName)); }
              }, 
        
            new field_info {
              _name = _str_strEpidemiologistsName, _type = "String",
              _get_func = o => o.strEpidemiologistsName,
              _set_func = (o, val) => { o.strEpidemiologistsName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strEpidemiologistsName != c.strEpidemiologistsName || o.IsRIRPropChanged(_str_strEpidemiologistsName, c)) 
                  m.Add(_str_strEpidemiologistsName, o.ObjectIdent + _str_strEpidemiologistsName, "String", o.strEpidemiologistsName == null ? "" : o.strEpidemiologistsName.ToString(), o.IsReadOnly(_str_strEpidemiologistsName), o.IsInvisible(_str_strEpidemiologistsName), o.IsRequired(_str_strEpidemiologistsName)); }
              }, 
        
            new field_info {
              _name = _str_idfsNotCollectedReason, _type = "Int64?",
              _get_func = o => o.idfsNotCollectedReason,
              _set_func = (o, val) => { o.idfsNotCollectedReason = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsNotCollectedReason != c.idfsNotCollectedReason || o.IsRIRPropChanged(_str_idfsNotCollectedReason, c)) 
                  m.Add(_str_idfsNotCollectedReason, o.ObjectIdent + _str_idfsNotCollectedReason, "Int64?", o.idfsNotCollectedReason == null ? "" : o.idfsNotCollectedReason.ToString(), o.IsReadOnly(_str_idfsNotCollectedReason), o.IsInvisible(_str_idfsNotCollectedReason), o.IsRequired(_str_idfsNotCollectedReason)); }
              }, 
        
            new field_info {
              _name = _str_idfsNonNotifiableDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsNonNotifiableDiagnosis,
              _set_func = (o, val) => { o.idfsNonNotifiableDiagnosis = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsNonNotifiableDiagnosis != c.idfsNonNotifiableDiagnosis || o.IsRIRPropChanged(_str_idfsNonNotifiableDiagnosis, c)) 
                  m.Add(_str_idfsNonNotifiableDiagnosis, o.ObjectIdent + _str_idfsNonNotifiableDiagnosis, "Int64?", o.idfsNonNotifiableDiagnosis == null ? "" : o.idfsNonNotifiableDiagnosis.ToString(), o.IsReadOnly(_str_idfsNonNotifiableDiagnosis), o.IsInvisible(_str_idfsNonNotifiableDiagnosis), o.IsRequired(_str_idfsNonNotifiableDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_intPatientAge, _type = "Int32?",
              _get_func = o => o.intPatientAge,
              _set_func = (o, val) => { o.intPatientAge = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intPatientAge != c.intPatientAge || o.IsRIRPropChanged(_str_intPatientAge, c)) 
                  m.Add(_str_intPatientAge, o.ObjectIdent + _str_intPatientAge, "Int32?", o.intPatientAge == null ? "" : o.intPatientAge.ToString(), o.IsReadOnly(_str_intPatientAge), o.IsInvisible(_str_intPatientAge), o.IsRequired(_str_intPatientAge)); }
              }, 
        
            new field_info {
              _name = _str_blnClinicalDiagBasis, _type = "Boolean?",
              _get_func = o => o.blnClinicalDiagBasis,
              _set_func = (o, val) => { o.blnClinicalDiagBasis = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnClinicalDiagBasis != c.blnClinicalDiagBasis || o.IsRIRPropChanged(_str_blnClinicalDiagBasis, c)) 
                  m.Add(_str_blnClinicalDiagBasis, o.ObjectIdent + _str_blnClinicalDiagBasis, "Boolean?", o.blnClinicalDiagBasis == null ? "" : o.blnClinicalDiagBasis.ToString(), o.IsReadOnly(_str_blnClinicalDiagBasis), o.IsInvisible(_str_blnClinicalDiagBasis), o.IsRequired(_str_blnClinicalDiagBasis)); }
              }, 
        
            new field_info {
              _name = _str_blnLabDiagBasis, _type = "Boolean?",
              _get_func = o => o.blnLabDiagBasis,
              _set_func = (o, val) => { o.blnLabDiagBasis = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnLabDiagBasis != c.blnLabDiagBasis || o.IsRIRPropChanged(_str_blnLabDiagBasis, c)) 
                  m.Add(_str_blnLabDiagBasis, o.ObjectIdent + _str_blnLabDiagBasis, "Boolean?", o.blnLabDiagBasis == null ? "" : o.blnLabDiagBasis.ToString(), o.IsReadOnly(_str_blnLabDiagBasis), o.IsInvisible(_str_blnLabDiagBasis), o.IsRequired(_str_blnLabDiagBasis)); }
              }, 
        
            new field_info {
              _name = _str_blnEpiDiagBasis, _type = "Boolean?",
              _get_func = o => o.blnEpiDiagBasis,
              _set_func = (o, val) => { o.blnEpiDiagBasis = ParsingHelper.ParseBooleanNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.blnEpiDiagBasis != c.blnEpiDiagBasis || o.IsRIRPropChanged(_str_blnEpiDiagBasis, c)) 
                  m.Add(_str_blnEpiDiagBasis, o.ObjectIdent + _str_blnEpiDiagBasis, "Boolean?", o.blnEpiDiagBasis == null ? "" : o.blnEpiDiagBasis.ToString(), o.IsReadOnly(_str_blnEpiDiagBasis), o.IsInvisible(_str_blnEpiDiagBasis), o.IsRequired(_str_blnEpiDiagBasis)); }
              }, 
        
            new field_info {
              _name = _str_strClinicalNotes, _type = "String",
              _get_func = o => o.strClinicalNotes,
              _set_func = (o, val) => { o.strClinicalNotes = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strClinicalNotes != c.strClinicalNotes || o.IsRIRPropChanged(_str_strClinicalNotes, c)) 
                  m.Add(_str_strClinicalNotes, o.ObjectIdent + _str_strClinicalNotes, "String", o.strClinicalNotes == null ? "" : o.strClinicalNotes.ToString(), o.IsReadOnly(_str_strClinicalNotes), o.IsInvisible(_str_strClinicalNotes), o.IsRequired(_str_strClinicalNotes)); }
              }, 
        
            new field_info {
              _name = _str_strSummaryNotes, _type = "String",
              _get_func = o => o.strSummaryNotes,
              _set_func = (o, val) => { o.strSummaryNotes = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSummaryNotes != c.strSummaryNotes || o.IsRIRPropChanged(_str_strSummaryNotes, c)) 
                  m.Add(_str_strSummaryNotes, o.ObjectIdent + _str_strSummaryNotes, "String", o.strSummaryNotes == null ? "" : o.strSummaryNotes.ToString(), o.IsReadOnly(_str_strSummaryNotes), o.IsInvisible(_str_strSummaryNotes), o.IsRequired(_str_strSummaryNotes)); }
              }, 
        
            new field_info {
              _name = _str_idfsFinalCaseStatus, _type = "Int64?",
              _get_func = o => o.idfsFinalCaseStatus,
              _set_func = (o, val) => { o.idfsFinalCaseStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFinalCaseStatus != c.idfsFinalCaseStatus || o.IsRIRPropChanged(_str_idfsFinalCaseStatus, c)) 
                  m.Add(_str_idfsFinalCaseStatus, o.ObjectIdent + _str_idfsFinalCaseStatus, "Int64?", o.idfsFinalCaseStatus == null ? "" : o.idfsFinalCaseStatus.ToString(), o.IsReadOnly(_str_idfsFinalCaseStatus), o.IsInvisible(_str_idfsFinalCaseStatus), o.IsRequired(_str_idfsFinalCaseStatus)); }
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
              _name = _str_strPersonEnteredBy, _type = "String",
              _get_func = o => o.strPersonEnteredBy,
              _set_func = (o, val) => { o.strPersonEnteredBy = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strPersonEnteredBy != c.strPersonEnteredBy || o.IsRIRPropChanged(_str_strPersonEnteredBy, c)) 
                  m.Add(_str_strPersonEnteredBy, o.ObjectIdent + _str_strPersonEnteredBy, "String", o.strPersonEnteredBy == null ? "" : o.strPersonEnteredBy.ToString(), o.IsReadOnly(_str_strPersonEnteredBy), o.IsInvisible(_str_strPersonEnteredBy), o.IsRequired(_str_strPersonEnteredBy)); }
              }, 
        
            new field_info {
              _name = _str_idfHuman, _type = "Int64?",
              _get_func = o => o.idfHuman,
              _set_func = (o, val) => { o.idfHuman = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfHuman != c.idfHuman || o.IsRIRPropChanged(_str_idfHuman, c)) 
                  m.Add(_str_idfHuman, o.ObjectIdent + _str_idfHuman, "Int64?", o.idfHuman == null ? "" : o.idfHuman.ToString(), o.IsReadOnly(_str_idfHuman), o.IsInvisible(_str_idfHuman), o.IsRequired(_str_idfHuman)); }
              }, 
        
            new field_info {
              _name = _str_idfsOccupationType, _type = "Int64?",
              _get_func = o => o.idfsOccupationType,
              _set_func = (o, val) => { o.idfsOccupationType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsOccupationType != c.idfsOccupationType || o.IsRIRPropChanged(_str_idfsOccupationType, c)) 
                  m.Add(_str_idfsOccupationType, o.ObjectIdent + _str_idfsOccupationType, "Int64?", o.idfsOccupationType == null ? "" : o.idfsOccupationType.ToString(), o.IsReadOnly(_str_idfsOccupationType), o.IsInvisible(_str_idfsOccupationType), o.IsRequired(_str_idfsOccupationType)); }
              }, 
        
            new field_info {
              _name = _str_idfRegistrationAddress, _type = "Int64?",
              _get_func = o => o.idfRegistrationAddress,
              _set_func = (o, val) => { o.idfRegistrationAddress = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfRegistrationAddress != c.idfRegistrationAddress || o.IsRIRPropChanged(_str_idfRegistrationAddress, c)) 
                  m.Add(_str_idfRegistrationAddress, o.ObjectIdent + _str_idfRegistrationAddress, "Int64?", o.idfRegistrationAddress == null ? "" : o.idfRegistrationAddress.ToString(), o.IsReadOnly(_str_idfRegistrationAddress), o.IsInvisible(_str_idfRegistrationAddress), o.IsRequired(_str_idfRegistrationAddress)); }
              }, 
        
            new field_info {
              _name = _str_datDateOfDeath, _type = "DateTime?",
              _get_func = o => o.datDateOfDeath,
              _set_func = (o, val) => { o.datDateOfDeath = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datDateOfDeath != c.datDateOfDeath || o.IsRIRPropChanged(_str_datDateOfDeath, c)) 
                  m.Add(_str_datDateOfDeath, o.ObjectIdent + _str_datDateOfDeath, "DateTime?", o.datDateOfDeath == null ? "" : o.datDateOfDeath.ToString(), o.IsReadOnly(_str_datDateOfDeath), o.IsInvisible(_str_datDateOfDeath), o.IsRequired(_str_datDateOfDeath)); }
              }, 
        
            new field_info {
              _name = _str_strRegistrationPhone, _type = "String",
              _get_func = o => o.strRegistrationPhone,
              _set_func = (o, val) => { o.strRegistrationPhone = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strRegistrationPhone != c.strRegistrationPhone || o.IsRIRPropChanged(_str_strRegistrationPhone, c)) 
                  m.Add(_str_strRegistrationPhone, o.ObjectIdent + _str_strRegistrationPhone, "String", o.strRegistrationPhone == null ? "" : o.strRegistrationPhone.ToString(), o.IsReadOnly(_str_strRegistrationPhone), o.IsInvisible(_str_strRegistrationPhone), o.IsRequired(_str_strRegistrationPhone)); }
              }, 
        
            new field_info {
              _name = _str_strWorkPhone, _type = "String",
              _get_func = o => o.strWorkPhone,
              _set_func = (o, val) => { o.strWorkPhone = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strWorkPhone != c.strWorkPhone || o.IsRIRPropChanged(_str_strWorkPhone, c)) 
                  m.Add(_str_strWorkPhone, o.ObjectIdent + _str_strWorkPhone, "String", o.strWorkPhone == null ? "" : o.strWorkPhone.ToString(), o.IsReadOnly(_str_strWorkPhone), o.IsInvisible(_str_strWorkPhone), o.IsRequired(_str_strWorkPhone)); }
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
              _name = _str_strSampleNotes, _type = "String",
              _get_func = o => o.strSampleNotes,
              _set_func = (o, val) => { o.strSampleNotes = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSampleNotes != c.strSampleNotes || o.IsRIRPropChanged(_str_strSampleNotes, c)) 
                  m.Add(_str_strSampleNotes, o.ObjectIdent + _str_strSampleNotes, "String", o.strSampleNotes == null ? "" : o.strSampleNotes.ToString(), o.IsReadOnly(_str_strSampleNotes), o.IsInvisible(_str_strSampleNotes), o.IsRequired(_str_strSampleNotes)); }
              }, 
        
            new field_info {
              _name = _str_idfsChangeDiagnosisReason, _type = "long?",
              _get_func = o => o.idfsChangeDiagnosisReason,
              _set_func = (o, val) => { o.idfsChangeDiagnosisReason = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsChangeDiagnosisReason != c.idfsChangeDiagnosisReason || o.IsRIRPropChanged(_str_idfsChangeDiagnosisReason, c)) 
                  m.Add(_str_idfsChangeDiagnosisReason, o.ObjectIdent + _str_idfsChangeDiagnosisReason, "long?", o.idfsChangeDiagnosisReason == null ? "" : o.idfsChangeDiagnosisReason.ToString(), o.IsReadOnly(_str_idfsChangeDiagnosisReason), o.IsInvisible(_str_idfsChangeDiagnosisReason), o.IsRequired(_str_idfsChangeDiagnosisReason));
                 }
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
              _name = _str_idfsDiagnosis, _type = "long?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, "long?", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis));
                 }
              }, 
        
            new field_info {
              _name = _str_DiagnosisAll, _type = "List<DiagnosisLookup>",
              _get_func = o => o.DiagnosisAll,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_strCaseClassification, _type = "string",
              _get_func = o => o.strCaseClassification,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strCaseClassification != c.strCaseClassification || o.IsRIRPropChanged(_str_strCaseClassification, c)) 
                  m.Add(_str_strCaseClassification, o.ObjectIdent + _str_strCaseClassification, "string", o.strCaseClassification == null ? "" : o.strCaseClassification.ToString(), o.IsReadOnly(_str_strCaseClassification), o.IsInvisible(_str_strCaseClassification), o.IsRequired(_str_strCaseClassification));
                 }
              }, 
        
            new field_info {
              _name = _str_datD, _type = "DateTime?",
              _get_func = o => o.datD,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.datD != c.datD || o.IsRIRPropChanged(_str_datD, c)) 
                  m.Add(_str_datD, o.ObjectIdent + _str_datD, "DateTime?", o.datD == null ? "" : o.datD.ToString(), o.IsReadOnly(_str_datD), o.IsInvisible(_str_datD), o.IsRequired(_str_datD));
                 }
              }, 
        
            new field_info {
              _name = _str_IsClosed, _type = "bool",
              _get_func = o => o.IsClosed,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.IsClosed != c.IsClosed || o.IsRIRPropChanged(_str_IsClosed, c)) 
                  m.Add(_str_IsClosed, o.ObjectIdent + _str_IsClosed, "bool", o.IsClosed == null ? "" : o.IsClosed.ToString(), o.IsReadOnly(_str_IsClosed), o.IsInvisible(_str_IsClosed), o.IsRequired(_str_IsClosed));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyLocalIdentifier, _type = "string",
              _get_func = o => o.strReadOnlyLocalIdentifier,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyLocalIdentifier != c.strReadOnlyLocalIdentifier || o.IsRIRPropChanged(_str_strReadOnlyLocalIdentifier, c)) 
                  m.Add(_str_strReadOnlyLocalIdentifier, o.ObjectIdent + _str_strReadOnlyLocalIdentifier, "string", o.strReadOnlyLocalIdentifier == null ? "" : o.strReadOnlyLocalIdentifier.ToString(), o.IsReadOnly(_str_strReadOnlyLocalIdentifier), o.IsInvisible(_str_strReadOnlyLocalIdentifier), o.IsRequired(_str_strReadOnlyLocalIdentifier));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyNotificationDate, _type = "string",
              _get_func = o => o.strReadOnlyNotificationDate,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyNotificationDate != c.strReadOnlyNotificationDate || o.IsRIRPropChanged(_str_strReadOnlyNotificationDate, c)) 
                  m.Add(_str_strReadOnlyNotificationDate, o.ObjectIdent + _str_strReadOnlyNotificationDate, "string", o.strReadOnlyNotificationDate == null ? "" : o.strReadOnlyNotificationDate.ToString(), o.IsReadOnly(_str_strReadOnlyNotificationDate), o.IsInvisible(_str_strReadOnlyNotificationDate), o.IsRequired(_str_strReadOnlyNotificationDate));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyFacilityLastVisit, _type = "string",
              _get_func = o => o.strReadOnlyFacilityLastVisit,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyFacilityLastVisit != c.strReadOnlyFacilityLastVisit || o.IsRIRPropChanged(_str_strReadOnlyFacilityLastVisit, c)) 
                  m.Add(_str_strReadOnlyFacilityLastVisit, o.ObjectIdent + _str_strReadOnlyFacilityLastVisit, "string", o.strReadOnlyFacilityLastVisit == null ? "" : o.strReadOnlyFacilityLastVisit.ToString(), o.IsReadOnly(_str_strReadOnlyFacilityLastVisit), o.IsInvisible(_str_strReadOnlyFacilityLastVisit), o.IsRequired(_str_strReadOnlyFacilityLastVisit));
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
              _name = _str_strReadOnlyModificationDate, _type = "string",
              _get_func = o => o.strReadOnlyModificationDate,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyModificationDate != c.strReadOnlyModificationDate || o.IsRIRPropChanged(_str_strReadOnlyModificationDate, c)) 
                  m.Add(_str_strReadOnlyModificationDate, o.ObjectIdent + _str_strReadOnlyModificationDate, "string", o.strReadOnlyModificationDate == null ? "" : o.strReadOnlyModificationDate.ToString(), o.IsReadOnly(_str_strReadOnlyModificationDate), o.IsInvisible(_str_strReadOnlyModificationDate), o.IsRequired(_str_strReadOnlyModificationDate));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyOnSetDate, _type = "string",
              _get_func = o => o.strReadOnlyOnSetDate,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyOnSetDate != c.strReadOnlyOnSetDate || o.IsRIRPropChanged(_str_strReadOnlyOnSetDate, c)) 
                  m.Add(_str_strReadOnlyOnSetDate, o.ObjectIdent + _str_strReadOnlyOnSetDate, "string", o.strReadOnlyOnSetDate == null ? "" : o.strReadOnlyOnSetDate.ToString(), o.IsReadOnly(_str_strReadOnlyOnSetDate), o.IsInvisible(_str_strReadOnlyOnSetDate), o.IsRequired(_str_strReadOnlyOnSetDate));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyDiagnosisDate, _type = "string",
              _get_func = o => o.strReadOnlyDiagnosisDate,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyDiagnosisDate != c.strReadOnlyDiagnosisDate || o.IsRIRPropChanged(_str_strReadOnlyDiagnosisDate, c)) 
                  m.Add(_str_strReadOnlyDiagnosisDate, o.ObjectIdent + _str_strReadOnlyDiagnosisDate, "string", o.strReadOnlyDiagnosisDate == null ? "" : o.strReadOnlyDiagnosisDate.ToString(), o.IsReadOnly(_str_strReadOnlyDiagnosisDate), o.IsInvisible(_str_strReadOnlyDiagnosisDate), o.IsRequired(_str_strReadOnlyDiagnosisDate));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyFinalDiagnosisDate, _type = "string",
              _get_func = o => o.strReadOnlyFinalDiagnosisDate,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyFinalDiagnosisDate != c.strReadOnlyFinalDiagnosisDate || o.IsRIRPropChanged(_str_strReadOnlyFinalDiagnosisDate, c)) 
                  m.Add(_str_strReadOnlyFinalDiagnosisDate, o.ObjectIdent + _str_strReadOnlyFinalDiagnosisDate, "string", o.strReadOnlyFinalDiagnosisDate == null ? "" : o.strReadOnlyFinalDiagnosisDate.ToString(), o.IsReadOnly(_str_strReadOnlyFinalDiagnosisDate), o.IsInvisible(_str_strReadOnlyFinalDiagnosisDate), o.IsRequired(_str_strReadOnlyFinalDiagnosisDate));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyTentativeDiagnosis1, _type = "string",
              _get_func = o => o.strReadOnlyTentativeDiagnosis1,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyTentativeDiagnosis1 != c.strReadOnlyTentativeDiagnosis1 || o.IsRIRPropChanged(_str_strReadOnlyTentativeDiagnosis1, c)) 
                  m.Add(_str_strReadOnlyTentativeDiagnosis1, o.ObjectIdent + _str_strReadOnlyTentativeDiagnosis1, "string", o.strReadOnlyTentativeDiagnosis1 == null ? "" : o.strReadOnlyTentativeDiagnosis1.ToString(), o.IsReadOnly(_str_strReadOnlyTentativeDiagnosis1), o.IsInvisible(_str_strReadOnlyTentativeDiagnosis1), o.IsRequired(_str_strReadOnlyTentativeDiagnosis1));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyDiagnosis, _type = "string",
              _get_func = o => o.strReadOnlyDiagnosis,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyDiagnosis != c.strReadOnlyDiagnosis || o.IsRIRPropChanged(_str_strReadOnlyDiagnosis, c)) 
                  m.Add(_str_strReadOnlyDiagnosis, o.ObjectIdent + _str_strReadOnlyDiagnosis, "string", o.strReadOnlyDiagnosis == null ? "" : o.strReadOnlyDiagnosis.ToString(), o.IsReadOnly(_str_strReadOnlyDiagnosis), o.IsInvisible(_str_strReadOnlyDiagnosis), o.IsRequired(_str_strReadOnlyDiagnosis));
                 }
              }, 
        
            new field_info {
              _name = _str_isChangeDiagnosisReasonEnter, _type = "bool",
              _get_func = o => o.isChangeDiagnosisReasonEnter,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.isChangeDiagnosisReasonEnter != c.isChangeDiagnosisReasonEnter || o.IsRIRPropChanged(_str_isChangeDiagnosisReasonEnter, c)) 
                  m.Add(_str_isChangeDiagnosisReasonEnter, o.ObjectIdent + _str_isChangeDiagnosisReasonEnter, "bool", o.isChangeDiagnosisReasonEnter == null ? "" : o.isChangeDiagnosisReasonEnter.ToString(), o.IsReadOnly(_str_isChangeDiagnosisReasonEnter), o.IsInvisible(_str_isChangeDiagnosisReasonEnter), o.IsRequired(_str_isChangeDiagnosisReasonEnter));
                 }
              }, 
        
            new field_info {
              _name = _str_blnEnableTestsConductedCalc, _type = "bool",
              _get_func = o => o.blnEnableTestsConductedCalc,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.blnEnableTestsConductedCalc != c.blnEnableTestsConductedCalc || o.IsRIRPropChanged(_str_blnEnableTestsConductedCalc, c)) 
                  m.Add(_str_blnEnableTestsConductedCalc, o.ObjectIdent + _str_blnEnableTestsConductedCalc, "bool", o.blnEnableTestsConductedCalc == null ? "" : o.blnEnableTestsConductedCalc.ToString(), o.IsReadOnly(_str_blnEnableTestsConductedCalc), o.IsInvisible(_str_blnEnableTestsConductedCalc), o.IsRequired(_str_blnEnableTestsConductedCalc));
                 }
              }, 
        
            new field_info {
              _name = _str_buttonGeoLocationPicker, _type = "string",
              _get_func = o => o.buttonGeoLocationPicker,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.buttonGeoLocationPicker != c.buttonGeoLocationPicker || o.IsRIRPropChanged(_str_buttonGeoLocationPicker, c)) 
                  m.Add(_str_buttonGeoLocationPicker, o.ObjectIdent + _str_buttonGeoLocationPicker, "string", o.buttonGeoLocationPicker == null ? "" : o.buttonGeoLocationPicker.ToString(), o.IsReadOnly(_str_buttonGeoLocationPicker), o.IsInvisible(_str_buttonGeoLocationPicker), o.IsRequired(_str_buttonGeoLocationPicker));
                 }
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
              _name = _str_PatientState, _type = "Lookup",
              _get_func = o => { if (o.PatientState == null) return null; return o.PatientState.idfsBaseReference; },
              _set_func = (o, val) => { o.PatientState = o.PatientStateLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsFinalState != c.idfsFinalState || o.IsRIRPropChanged(_str_PatientState, c)) 
                  m.Add(_str_PatientState, o.ObjectIdent + _str_PatientState, "Lookup", o.idfsFinalState == null ? "" : o.idfsFinalState.ToString(), o.IsReadOnly(_str_PatientState), o.IsInvisible(_str_PatientState), o.IsRequired(_str_PatientState)); }
              }, 
        
            new field_info {
              _name = _str_PatientLocationType, _type = "Lookup",
              _get_func = o => { if (o.PatientLocationType == null) return null; return o.PatientLocationType.idfsBaseReference; },
              _set_func = (o, val) => { o.PatientLocationType = o.PatientLocationTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsHospitalizationStatus != c.idfsHospitalizationStatus || o.IsRIRPropChanged(_str_PatientLocationType, c)) 
                  m.Add(_str_PatientLocationType, o.ObjectIdent + _str_PatientLocationType, "Lookup", o.idfsHospitalizationStatus == null ? "" : o.idfsHospitalizationStatus.ToString(), o.IsReadOnly(_str_PatientLocationType), o.IsInvisible(_str_PatientLocationType), o.IsRequired(_str_PatientLocationType)); }
              }, 
        
            new field_info {
              _name = _str_AntimicrobialTherapyUsed, _type = "Lookup",
              _get_func = o => { if (o.AntimicrobialTherapyUsed == null) return null; return o.AntimicrobialTherapyUsed.idfsBaseReference; },
              _set_func = (o, val) => { o.AntimicrobialTherapyUsed = o.AntimicrobialTherapyUsedLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNAntimicrobialTherapy != c.idfsYNAntimicrobialTherapy || o.IsRIRPropChanged(_str_AntimicrobialTherapyUsed, c)) 
                  m.Add(_str_AntimicrobialTherapyUsed, o.ObjectIdent + _str_AntimicrobialTherapyUsed, "Lookup", o.idfsYNAntimicrobialTherapy == null ? "" : o.idfsYNAntimicrobialTherapy.ToString(), o.IsReadOnly(_str_AntimicrobialTherapyUsed), o.IsInvisible(_str_AntimicrobialTherapyUsed), o.IsRequired(_str_AntimicrobialTherapyUsed)); }
              }, 
        
            new field_info {
              _name = _str_Hospitalization, _type = "Lookup",
              _get_func = o => { if (o.Hospitalization == null) return null; return o.Hospitalization.idfsBaseReference; },
              _set_func = (o, val) => { o.Hospitalization = o.HospitalizationLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNHospitalization != c.idfsYNHospitalization || o.IsRIRPropChanged(_str_Hospitalization, c)) 
                  m.Add(_str_Hospitalization, o.ObjectIdent + _str_Hospitalization, "Lookup", o.idfsYNHospitalization == null ? "" : o.idfsYNHospitalization.ToString(), o.IsReadOnly(_str_Hospitalization), o.IsInvisible(_str_Hospitalization), o.IsRequired(_str_Hospitalization)); }
              }, 
        
            new field_info {
              _name = _str_SpecimenCollected, _type = "Lookup",
              _get_func = o => { if (o.SpecimenCollected == null) return null; return o.SpecimenCollected.idfsBaseReference; },
              _set_func = (o, val) => { o.SpecimenCollected = o.SpecimenCollectedLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNSpecimenCollected != c.idfsYNSpecimenCollected || o.IsRIRPropChanged(_str_SpecimenCollected, c)) 
                  m.Add(_str_SpecimenCollected, o.ObjectIdent + _str_SpecimenCollected, "Lookup", o.idfsYNSpecimenCollected == null ? "" : o.idfsYNSpecimenCollected.ToString(), o.IsReadOnly(_str_SpecimenCollected), o.IsInvisible(_str_SpecimenCollected), o.IsRequired(_str_SpecimenCollected)); }
              }, 
        
            new field_info {
              _name = _str_RelatedToOutbreak, _type = "Lookup",
              _get_func = o => { if (o.RelatedToOutbreak == null) return null; return o.RelatedToOutbreak.idfsBaseReference; },
              _set_func = (o, val) => { o.RelatedToOutbreak = o.RelatedToOutbreakLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNRelatedToOutbreak != c.idfsYNRelatedToOutbreak || o.IsRIRPropChanged(_str_RelatedToOutbreak, c)) 
                  m.Add(_str_RelatedToOutbreak, o.ObjectIdent + _str_RelatedToOutbreak, "Lookup", o.idfsYNRelatedToOutbreak == null ? "" : o.idfsYNRelatedToOutbreak.ToString(), o.IsReadOnly(_str_RelatedToOutbreak), o.IsInvisible(_str_RelatedToOutbreak), o.IsRequired(_str_RelatedToOutbreak)); }
              }, 
        
            new field_info {
              _name = _str_TestsConducted, _type = "Lookup",
              _get_func = o => { if (o.TestsConducted == null) return null; return o.TestsConducted.idfsBaseReference; },
              _set_func = (o, val) => { o.TestsConducted = o.TestsConductedLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNTestsConducted != c.idfsYNTestsConducted || o.IsRIRPropChanged(_str_TestsConducted, c)) 
                  m.Add(_str_TestsConducted, o.ObjectIdent + _str_TestsConducted, "Lookup", o.idfsYNTestsConducted == null ? "" : o.idfsYNTestsConducted.ToString(), o.IsReadOnly(_str_TestsConducted), o.IsInvisible(_str_TestsConducted), o.IsRequired(_str_TestsConducted)); }
              }, 
        
            new field_info {
              _name = _str_Outcome, _type = "Lookup",
              _get_func = o => { if (o.Outcome == null) return null; return o.Outcome.idfsBaseReference; },
              _set_func = (o, val) => { o.Outcome = o.OutcomeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsOutcome != c.idfsOutcome || o.IsRIRPropChanged(_str_Outcome, c)) 
                  m.Add(_str_Outcome, o.ObjectIdent + _str_Outcome, "Lookup", o.idfsOutcome == null ? "" : o.idfsOutcome.ToString(), o.IsReadOnly(_str_Outcome), o.IsInvisible(_str_Outcome), o.IsRequired(_str_Outcome)); }
              }, 
        
            new field_info {
              _name = _str_TentativeDiagnosis, _type = "Lookup",
              _get_func = o => { if (o.TentativeDiagnosis == null) return null; return o.TentativeDiagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.TentativeDiagnosis = o.TentativeDiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTentativeDiagnosis != c.idfsTentativeDiagnosis || o.IsRIRPropChanged(_str_TentativeDiagnosis, c)) 
                  m.Add(_str_TentativeDiagnosis, o.ObjectIdent + _str_TentativeDiagnosis, "Lookup", o.idfsTentativeDiagnosis == null ? "" : o.idfsTentativeDiagnosis.ToString(), o.IsReadOnly(_str_TentativeDiagnosis), o.IsInvisible(_str_TentativeDiagnosis), o.IsRequired(_str_TentativeDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_FinalDiagnosis, _type = "Lookup",
              _get_func = o => { if (o.FinalDiagnosis == null) return null; return o.FinalDiagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.FinalDiagnosis = o.FinalDiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsFinalDiagnosis != c.idfsFinalDiagnosis || o.IsRIRPropChanged(_str_FinalDiagnosis, c)) 
                  m.Add(_str_FinalDiagnosis, o.ObjectIdent + _str_FinalDiagnosis, "Lookup", o.idfsFinalDiagnosis == null ? "" : o.idfsFinalDiagnosis.ToString(), o.IsReadOnly(_str_FinalDiagnosis), o.IsInvisible(_str_FinalDiagnosis), o.IsRequired(_str_FinalDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_InitialCaseStatus, _type = "Lookup",
              _get_func = o => { if (o.InitialCaseStatus == null) return null; return o.InitialCaseStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.InitialCaseStatus = o.InitialCaseStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsInitialCaseStatus != c.idfsInitialCaseStatus || o.IsRIRPropChanged(_str_InitialCaseStatus, c)) 
                  m.Add(_str_InitialCaseStatus, o.ObjectIdent + _str_InitialCaseStatus, "Lookup", o.idfsInitialCaseStatus == null ? "" : o.idfsInitialCaseStatus.ToString(), o.IsReadOnly(_str_InitialCaseStatus), o.IsInvisible(_str_InitialCaseStatus), o.IsRequired(_str_InitialCaseStatus)); }
              }, 
        
            new field_info {
              _name = _str_NonNotifiableDiagnosis, _type = "Lookup",
              _get_func = o => { if (o.NonNotifiableDiagnosis == null) return null; return o.NonNotifiableDiagnosis.idfsBaseReference; },
              _set_func = (o, val) => { o.NonNotifiableDiagnosis = o.NonNotifiableDiagnosisLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsNonNotifiableDiagnosis != c.idfsNonNotifiableDiagnosis || o.IsRIRPropChanged(_str_NonNotifiableDiagnosis, c)) 
                  m.Add(_str_NonNotifiableDiagnosis, o.ObjectIdent + _str_NonNotifiableDiagnosis, "Lookup", o.idfsNonNotifiableDiagnosis == null ? "" : o.idfsNonNotifiableDiagnosis.ToString(), o.IsReadOnly(_str_NonNotifiableDiagnosis), o.IsInvisible(_str_NonNotifiableDiagnosis), o.IsRequired(_str_NonNotifiableDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_FinalCaseStatus, _type = "Lookup",
              _get_func = o => { if (o.FinalCaseStatus == null) return null; return o.FinalCaseStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.FinalCaseStatus = o.FinalCaseStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsFinalCaseStatus != c.idfsFinalCaseStatus || o.IsRIRPropChanged(_str_FinalCaseStatus, c)) 
                  m.Add(_str_FinalCaseStatus, o.ObjectIdent + _str_FinalCaseStatus, "Lookup", o.idfsFinalCaseStatus == null ? "" : o.idfsFinalCaseStatus.ToString(), o.IsReadOnly(_str_FinalCaseStatus), o.IsInvisible(_str_FinalCaseStatus), o.IsRequired(_str_FinalCaseStatus)); }
              }, 
        
            new field_info {
              _name = _str_OccupationType, _type = "Lookup",
              _get_func = o => { if (o.OccupationType == null) return null; return o.OccupationType.idfsBaseReference; },
              _set_func = (o, val) => { o.OccupationType = o.OccupationTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsOccupationType != c.idfsOccupationType || o.IsRIRPropChanged(_str_OccupationType, c)) 
                  m.Add(_str_OccupationType, o.ObjectIdent + _str_OccupationType, "Lookup", o.idfsOccupationType == null ? "" : o.idfsOccupationType.ToString(), o.IsReadOnly(_str_OccupationType), o.IsInvisible(_str_OccupationType), o.IsRequired(_str_OccupationType)); }
              }, 
        
            new field_info {
              _name = _str_NotCollectedReason, _type = "Lookup",
              _get_func = o => { if (o.NotCollectedReason == null) return null; return o.NotCollectedReason.idfsBaseReference; },
              _set_func = (o, val) => { o.NotCollectedReason = o.NotCollectedReasonLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsNotCollectedReason != c.idfsNotCollectedReason || o.IsRIRPropChanged(_str_NotCollectedReason, c)) 
                  m.Add(_str_NotCollectedReason, o.ObjectIdent + _str_NotCollectedReason, "Lookup", o.idfsNotCollectedReason == null ? "" : o.idfsNotCollectedReason.ToString(), o.IsReadOnly(_str_NotCollectedReason), o.IsInvisible(_str_NotCollectedReason), o.IsRequired(_str_NotCollectedReason)); }
              }, 
        
            new field_info {
              _name = _str_SentByOffice, _type = "Lookup",
              _get_func = o => { if (o.SentByOffice == null) return null; return o.SentByOffice.idfInstitution; },
              _set_func = (o, val) => { o.SentByOffice = o.SentByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfSentByOffice != c.idfSentByOffice || o.IsRIRPropChanged(_str_SentByOffice, c)) 
                  m.Add(_str_SentByOffice, o.ObjectIdent + _str_SentByOffice, "Lookup", o.idfSentByOffice == null ? "" : o.idfSentByOffice.ToString(), o.IsReadOnly(_str_SentByOffice), o.IsInvisible(_str_SentByOffice), o.IsRequired(_str_SentByOffice)); }
              }, 
        
            new field_info {
              _name = _str_ReceivedByOffice, _type = "Lookup",
              _get_func = o => { if (o.ReceivedByOffice == null) return null; return o.ReceivedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.ReceivedByOffice = o.ReceivedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfReceivedByOffice != c.idfReceivedByOffice || o.IsRIRPropChanged(_str_ReceivedByOffice, c)) 
                  m.Add(_str_ReceivedByOffice, o.ObjectIdent + _str_ReceivedByOffice, "Lookup", o.idfReceivedByOffice == null ? "" : o.idfReceivedByOffice.ToString(), o.IsReadOnly(_str_ReceivedByOffice), o.IsInvisible(_str_ReceivedByOffice), o.IsRequired(_str_ReceivedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_SentByPerson, _type = "Lookup",
              _get_func = o => { if (o.SentByPerson == null) return null; return o.SentByPerson.idfPerson; },
              _set_func = (o, val) => { o.SentByPerson = o.SentByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfSentByPerson != c.idfSentByPerson || o.IsRIRPropChanged(_str_SentByPerson, c)) 
                  m.Add(_str_SentByPerson, o.ObjectIdent + _str_SentByPerson, "Lookup", o.idfSentByPerson == null ? "" : o.idfSentByPerson.ToString(), o.IsReadOnly(_str_SentByPerson), o.IsInvisible(_str_SentByPerson), o.IsRequired(_str_SentByPerson)); }
              }, 
        
            new field_info {
              _name = _str_ReceivedByPerson, _type = "Lookup",
              _get_func = o => { if (o.ReceivedByPerson == null) return null; return o.ReceivedByPerson.idfPerson; },
              _set_func = (o, val) => { o.ReceivedByPerson = o.ReceivedByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfReceivedByPerson != c.idfReceivedByPerson || o.IsRIRPropChanged(_str_ReceivedByPerson, c)) 
                  m.Add(_str_ReceivedByPerson, o.ObjectIdent + _str_ReceivedByPerson, "Lookup", o.idfReceivedByPerson == null ? "" : o.idfReceivedByPerson.ToString(), o.IsReadOnly(_str_ReceivedByPerson), o.IsInvisible(_str_ReceivedByPerson), o.IsRequired(_str_ReceivedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_CaseTests, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.CaseTests.Count != c.CaseTests.Count || o.IsReadOnly(_str_CaseTests) != c.IsReadOnly(_str_CaseTests) || o.IsInvisible(_str_CaseTests) != c.IsInvisible(_str_CaseTests) || o.IsRequired(_str_CaseTests) != c.IsRequired(_str_CaseTests)) 
                  m.Add(_str_CaseTests, o.ObjectIdent + _str_CaseTests, "Child", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_CaseTests), o.IsInvisible(_str_CaseTests), o.IsRequired(_str_CaseTests)); }
              }, 
        
            new field_info {
              _name = _str_CaseTestValidations, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.CaseTestValidations.Count != c.CaseTestValidations.Count || o.IsReadOnly(_str_CaseTestValidations) != c.IsReadOnly(_str_CaseTestValidations) || o.IsInvisible(_str_CaseTestValidations) != c.IsInvisible(_str_CaseTestValidations) || o.IsRequired(_str_CaseTestValidations) != c.IsRequired(_str_CaseTestValidations)) 
                  m.Add(_str_CaseTestValidations, o.ObjectIdent + _str_CaseTestValidations, "Child", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_CaseTestValidations), o.IsInvisible(_str_CaseTestValidations), o.IsRequired(_str_CaseTestValidations)); }
              }, 
        
            new field_info {
              _name = _str_ContactedPerson, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.ContactedPerson.Count != c.ContactedPerson.Count || o.IsReadOnly(_str_ContactedPerson) != c.IsReadOnly(_str_ContactedPerson) || o.IsInvisible(_str_ContactedPerson) != c.IsInvisible(_str_ContactedPerson) || o.IsRequired(_str_ContactedPerson) != c.IsRequired(_str_ContactedPerson)) 
                  m.Add(_str_ContactedPerson, o.ObjectIdent + _str_ContactedPerson, "Child", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_ContactedPerson), o.IsInvisible(_str_ContactedPerson), o.IsRequired(_str_ContactedPerson)); }
              }, 
        
            new field_info {
              _name = _str_Samples, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Samples.Count != c.Samples.Count || o.IsReadOnly(_str_Samples) != c.IsReadOnly(_str_Samples) || o.IsInvisible(_str_Samples) != c.IsInvisible(_str_Samples) || o.IsRequired(_str_Samples) != c.IsRequired(_str_Samples)) 
                  m.Add(_str_Samples, o.ObjectIdent + _str_Samples, "Child", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_Samples), o.IsInvisible(_str_Samples), o.IsRequired(_str_Samples)); }
              }, 
        
            new field_info {
              _name = _str_AntimicrobialTherapy, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.AntimicrobialTherapy.Count != c.AntimicrobialTherapy.Count || o.IsReadOnly(_str_AntimicrobialTherapy) != c.IsReadOnly(_str_AntimicrobialTherapy) || o.IsInvisible(_str_AntimicrobialTherapy) != c.IsInvisible(_str_AntimicrobialTherapy) || o.IsRequired(_str_AntimicrobialTherapy) != c.IsRequired(_str_AntimicrobialTherapy)) 
                  m.Add(_str_AntimicrobialTherapy, o.ObjectIdent + _str_AntimicrobialTherapy, "Child", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_AntimicrobialTherapy), o.IsInvisible(_str_AntimicrobialTherapy), o.IsRequired(_str_AntimicrobialTherapy)); }
              }, 
        
            new field_info {
              _name = _str_DiagnosisHistory, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.DiagnosisHistory.Count != c.DiagnosisHistory.Count || o.IsReadOnly(_str_DiagnosisHistory) != c.IsReadOnly(_str_DiagnosisHistory) || o.IsInvisible(_str_DiagnosisHistory) != c.IsInvisible(_str_DiagnosisHistory) || o.IsRequired(_str_DiagnosisHistory) != c.IsRequired(_str_DiagnosisHistory)) 
                  m.Add(_str_DiagnosisHistory, o.ObjectIdent + _str_DiagnosisHistory, "Child", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_DiagnosisHistory), o.IsInvisible(_str_DiagnosisHistory), o.IsRequired(_str_DiagnosisHistory)); }
              }, 
        
            new field_info {
              _name = _str_PointGeoLocation, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.PointGeoLocation != null) o.PointGeoLocation._compare(c.PointGeoLocation, m); }
              }, 
        
            new field_info {
              _name = _str_FFPresenterCs, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.FFPresenterCs != null) o.FFPresenterCs._compare(c.FFPresenterCs, m); }
              }, 
        
            new field_info {
              _name = _str_FFPresenterEpi, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.FFPresenterEpi != null) o.FFPresenterEpi._compare(c.FFPresenterEpi, m); }
              }, 
        
            new field_info {
              _name = _str_Patient, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Patient != null) o.Patient._compare(c.Patient, m); }
              }, 
        
            new field_info {
              _name = _str_RegistrationAddress, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.RegistrationAddress != null) o.RegistrationAddress._compare(c.RegistrationAddress, m); }
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
            HumanCase obj = (HumanCase)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(GeoLocation), eidss.model.Schema.GeoLocation._str_idfGeoLocation, _str_idfPointGeoLocation)]
        public GeoLocation PointGeoLocation
        {
            get 
            {   
                return _PointGeoLocation; 
            }
            set 
            {   
                _PointGeoLocation = value;
                if (_PointGeoLocation != null) 
                { 
                    _PointGeoLocation.m_ObjectName = _str_PointGeoLocation;
                    _PointGeoLocation.Parent = this;
                }
                idfPointGeoLocation = _PointGeoLocation == null 
                        ? new Int64?()
                        : _PointGeoLocation.idfGeoLocation;
                
            }
        }
        protected GeoLocation _PointGeoLocation;
                    
        [Relation(typeof(FFPresenterModel), eidss.model.Schema.FFPresenterModel._str_CurrentObservation, _str_idfCSObservation)]
        public FFPresenterModel FFPresenterCs
        {
            get 
            {   
                return _FFPresenterCs; 
            }
            set 
            {   
                _FFPresenterCs = value;
                if (_FFPresenterCs != null) 
                { 
                    _FFPresenterCs.m_ObjectName = _str_FFPresenterCs;
                    _FFPresenterCs.Parent = this;
                }
                idfCSObservation = _FFPresenterCs == null 
                        ? new Int64?()
                        : _FFPresenterCs.CurrentObservation;
                
            }
        }
        protected FFPresenterModel _FFPresenterCs;
                    
        [Relation(typeof(FFPresenterModel), eidss.model.Schema.FFPresenterModel._str_CurrentObservation, _str_idfEpiObservation)]
        public FFPresenterModel FFPresenterEpi
        {
            get 
            {   
                return _FFPresenterEpi; 
            }
            set 
            {   
                _FFPresenterEpi = value;
                if (_FFPresenterEpi != null) 
                { 
                    _FFPresenterEpi.m_ObjectName = _str_FFPresenterEpi;
                    _FFPresenterEpi.Parent = this;
                }
                idfEpiObservation = _FFPresenterEpi == null 
                        ? new Int64?()
                        : _FFPresenterEpi.CurrentObservation;
                
            }
        }
        protected FFPresenterModel _FFPresenterEpi;
                    
        [Relation(typeof(Patient), eidss.model.Schema.Patient._str_idfHuman, _str_idfHuman)]
        public Patient Patient
        {
            get 
            {   
                return _Patient; 
            }
            set 
            {   
                _Patient = value;
                if (_Patient != null) 
                { 
                    _Patient.m_ObjectName = _str_Patient;
                    _Patient.Parent = this;
                }
                idfHuman = _Patient == null 
                        ? new Int64?()
                        : _Patient.idfHuman;
                
            }
        }
        protected Patient _Patient;
                    
        [Relation(typeof(Address), eidss.model.Schema.Address._str_idfGeoLocation, _str_idfRegistrationAddress)]
        public Address RegistrationAddress
        {
            get 
            {   
                return _RegistrationAddress; 
            }
            set 
            {   
                _RegistrationAddress = value;
                if (_RegistrationAddress != null) 
                { 
                    _RegistrationAddress.m_ObjectName = _str_RegistrationAddress;
                    _RegistrationAddress.Parent = this;
                }
                idfRegistrationAddress = _RegistrationAddress == null 
                        ? new Int64?()
                        : _RegistrationAddress.idfGeoLocation;
                
            }
        }
        protected Address _RegistrationAddress;
                    
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
                    
        [Relation(typeof(ContactedCasePerson), eidss.model.Schema.ContactedCasePerson._str_idfHumanCase, _str_idfCase)]
        public EditableList<ContactedCasePerson> ContactedPerson
        {
            get 
            {   
                return _ContactedPerson; 
            }
            set 
            {
                _ContactedPerson = value;
            }
        }
        protected EditableList<ContactedCasePerson> _ContactedPerson = new EditableList<ContactedCasePerson>();
                    
        [Relation(typeof(HumanCaseSample), eidss.model.Schema.HumanCaseSample._str_idfCase, _str_idfCase)]
        public EditableList<HumanCaseSample> Samples
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
        protected EditableList<HumanCaseSample> _Samples = new EditableList<HumanCaseSample>();
                    
        [Relation(typeof(AntimicrobialTherapy), eidss.model.Schema.AntimicrobialTherapy._str_idfHumanCase, _str_idfCase)]
        public EditableList<AntimicrobialTherapy> AntimicrobialTherapy
        {
            get 
            {   
                return _AntimicrobialTherapy; 
            }
            set 
            {
                _AntimicrobialTherapy = value;
            }
        }
        protected EditableList<AntimicrobialTherapy> _AntimicrobialTherapy = new EditableList<AntimicrobialTherapy>();
                    
        [Relation(typeof(ChangeDiagnosisHistory), eidss.model.Schema.ChangeDiagnosisHistory._str_idfHumanCase, _str_idfCase)]
        public EditableList<ChangeDiagnosisHistory> DiagnosisHistory
        {
            get 
            {   
                return _DiagnosisHistory; 
            }
            set 
            {
                _DiagnosisHistory = value;
            }
        }
        protected EditableList<ChangeDiagnosisHistory> _DiagnosisHistory = new EditableList<ChangeDiagnosisHistory>();
                    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseProgressStatus)]
        public BaseReference CaseProgressStatus
        {
            get { return _CaseProgressStatus; }
            set 
            { 
                _CaseProgressStatus = value;
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
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsFinalState)]
        public BaseReference PatientState
        {
            get { return _PatientState == null ? null : ((long)_PatientState.Key == 0 ? null : _PatientState); }
            set 
            { 
                _PatientState = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsFinalState = _PatientState == null 
                    ? new Int64?()
                    : _PatientState.idfsBaseReference; 
                OnPropertyChanged(_str_PatientState); 
            }
        }
        private BaseReference _PatientState;

        
        public BaseReferenceList PatientStateLookup
        {
            get { return _PatientStateLookup; }
        }
        private BaseReferenceList _PatientStateLookup = new BaseReferenceList("rftFinalState");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsHospitalizationStatus)]
        public BaseReference PatientLocationType
        {
            get { return _PatientLocationType == null ? null : ((long)_PatientLocationType.Key == 0 ? null : _PatientLocationType); }
            set 
            { 
                _PatientLocationType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsHospitalizationStatus = _PatientLocationType == null 
                    ? new Int64?()
                    : _PatientLocationType.idfsBaseReference; 
                OnPropertyChanged(_str_PatientLocationType); 
            }
        }
        private BaseReference _PatientLocationType;

        
        public BaseReferenceList PatientLocationTypeLookup
        {
            get { return _PatientLocationTypeLookup; }
        }
        private BaseReferenceList _PatientLocationTypeLookup = new BaseReferenceList("rftHospStatus");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNAntimicrobialTherapy)]
        public BaseReference AntimicrobialTherapyUsed
        {
            get { return _AntimicrobialTherapyUsed == null ? null : ((long)_AntimicrobialTherapyUsed.Key == 0 ? null : _AntimicrobialTherapyUsed); }
            set 
            { 
                _AntimicrobialTherapyUsed = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsYNAntimicrobialTherapy = _AntimicrobialTherapyUsed == null 
                    ? new Int64?()
                    : _AntimicrobialTherapyUsed.idfsBaseReference; 
                OnPropertyChanged(_str_AntimicrobialTherapyUsed); 
            }
        }
        private BaseReference _AntimicrobialTherapyUsed;

        
        public BaseReferenceList AntimicrobialTherapyUsedLookup
        {
            get { return _AntimicrobialTherapyUsedLookup; }
        }
        private BaseReferenceList _AntimicrobialTherapyUsedLookup = new BaseReferenceList("rftYesNoValue");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNHospitalization)]
        public BaseReference Hospitalization
        {
            get { return _Hospitalization == null ? null : ((long)_Hospitalization.Key == 0 ? null : _Hospitalization); }
            set 
            { 
                _Hospitalization = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsYNHospitalization = _Hospitalization == null 
                    ? new Int64?()
                    : _Hospitalization.idfsBaseReference; 
                OnPropertyChanged(_str_Hospitalization); 
            }
        }
        private BaseReference _Hospitalization;

        
        public BaseReferenceList HospitalizationLookup
        {
            get { return _HospitalizationLookup; }
        }
        private BaseReferenceList _HospitalizationLookup = new BaseReferenceList("rftYesNoValue");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNSpecimenCollected)]
        public BaseReference SpecimenCollected
        {
            get { return _SpecimenCollected == null ? null : ((long)_SpecimenCollected.Key == 0 ? null : _SpecimenCollected); }
            set 
            { 
                _SpecimenCollected = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsYNSpecimenCollected = _SpecimenCollected == null 
                    ? new Int64?()
                    : _SpecimenCollected.idfsBaseReference; 
                OnPropertyChanged(_str_SpecimenCollected); 
            }
        }
        private BaseReference _SpecimenCollected;

        
        public BaseReferenceList SpecimenCollectedLookup
        {
            get { return _SpecimenCollectedLookup; }
        }
        private BaseReferenceList _SpecimenCollectedLookup = new BaseReferenceList("rftYesNoValue");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNRelatedToOutbreak)]
        public BaseReference RelatedToOutbreak
        {
            get { return _RelatedToOutbreak == null ? null : ((long)_RelatedToOutbreak.Key == 0 ? null : _RelatedToOutbreak); }
            set 
            { 
                _RelatedToOutbreak = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsYNRelatedToOutbreak = _RelatedToOutbreak == null 
                    ? new Int64?()
                    : _RelatedToOutbreak.idfsBaseReference; 
                OnPropertyChanged(_str_RelatedToOutbreak); 
            }
        }
        private BaseReference _RelatedToOutbreak;

        
        public BaseReferenceList RelatedToOutbreakLookup
        {
            get { return _RelatedToOutbreakLookup; }
        }
        private BaseReferenceList _RelatedToOutbreakLookup = new BaseReferenceList("rftYesNoValue");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNTestsConducted)]
        public BaseReference TestsConducted
        {
            get { return _TestsConducted == null ? null : ((long)_TestsConducted.Key == 0 ? null : _TestsConducted); }
            set 
            { 
                _TestsConducted = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsYNTestsConducted = _TestsConducted == null 
                    ? new Int64?()
                    : _TestsConducted.idfsBaseReference; 
                OnPropertyChanged(_str_TestsConducted); 
            }
        }
        private BaseReference _TestsConducted;

        
        public BaseReferenceList TestsConductedLookup
        {
            get { return _TestsConductedLookup; }
        }
        private BaseReferenceList _TestsConductedLookup = new BaseReferenceList("rftYesNoValue");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsOutcome)]
        public BaseReference Outcome
        {
            get { return _Outcome == null ? null : ((long)_Outcome.Key == 0 ? null : _Outcome); }
            set 
            { 
                _Outcome = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsOutcome = _Outcome == null 
                    ? new Int64?()
                    : _Outcome.idfsBaseReference; 
                OnPropertyChanged(_str_Outcome); 
            }
        }
        private BaseReference _Outcome;

        
        public BaseReferenceList OutcomeLookup
        {
            get { return _OutcomeLookup; }
        }
        private BaseReferenceList _OutcomeLookup = new BaseReferenceList("rftOutcome");
            
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsTentativeDiagnosis)]
        public DiagnosisLookup TentativeDiagnosis
        {
            get { return _TentativeDiagnosis == null ? null : ((long)_TentativeDiagnosis.Key == 0 ? null : _TentativeDiagnosis); }
            set 
            { 
                _TentativeDiagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsTentativeDiagnosis = _TentativeDiagnosis == null 
                    ? new Int64?()
                    : _TentativeDiagnosis.idfsDiagnosis; 
                OnPropertyChanged(_str_TentativeDiagnosis); 
            }
        }
        private DiagnosisLookup _TentativeDiagnosis;

        
        public List<DiagnosisLookup> TentativeDiagnosisLookup
        {
            get { return _TentativeDiagnosisLookup; }
        }
        private List<DiagnosisLookup> _TentativeDiagnosisLookup = new List<DiagnosisLookup>();
            
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsFinalDiagnosis)]
        public DiagnosisLookup FinalDiagnosis
        {
            get { return _FinalDiagnosis == null ? null : ((long)_FinalDiagnosis.Key == 0 ? null : _FinalDiagnosis); }
            set 
            { 
                _FinalDiagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsFinalDiagnosis = _FinalDiagnosis == null 
                    ? new Int64?()
                    : _FinalDiagnosis.idfsDiagnosis; 
                OnPropertyChanged(_str_FinalDiagnosis); 
            }
        }
        private DiagnosisLookup _FinalDiagnosis;

        
        public List<DiagnosisLookup> FinalDiagnosisLookup
        {
            get { return _FinalDiagnosisLookup; }
        }
        private List<DiagnosisLookup> _FinalDiagnosisLookup = new List<DiagnosisLookup>();
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsInitialCaseStatus)]
        public BaseReference InitialCaseStatus
        {
            get { return _InitialCaseStatus == null ? null : ((long)_InitialCaseStatus.Key == 0 ? null : _InitialCaseStatus); }
            set 
            { 
                _InitialCaseStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsInitialCaseStatus = _InitialCaseStatus == null 
                    ? new Int64?()
                    : _InitialCaseStatus.idfsBaseReference; 
                OnPropertyChanged(_str_InitialCaseStatus); 
            }
        }
        private BaseReference _InitialCaseStatus;

        
        public BaseReferenceList InitialCaseStatusLookup
        {
            get { return _InitialCaseStatusLookup; }
        }
        private BaseReferenceList _InitialCaseStatusLookup = new BaseReferenceList("rftCaseStatus");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsNonNotifiableDiagnosis)]
        public BaseReference NonNotifiableDiagnosis
        {
            get { return _NonNotifiableDiagnosis == null ? null : ((long)_NonNotifiableDiagnosis.Key == 0 ? null : _NonNotifiableDiagnosis); }
            set 
            { 
                _NonNotifiableDiagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsNonNotifiableDiagnosis = _NonNotifiableDiagnosis == null 
                    ? new Int64?()
                    : _NonNotifiableDiagnosis.idfsBaseReference; 
                OnPropertyChanged(_str_NonNotifiableDiagnosis); 
            }
        }
        private BaseReference _NonNotifiableDiagnosis;

        
        public BaseReferenceList NonNotifiableDiagnosisLookup
        {
            get { return _NonNotifiableDiagnosisLookup; }
        }
        private BaseReferenceList _NonNotifiableDiagnosisLookup = new BaseReferenceList("rftNonNotifiableDiagnosis");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsFinalCaseStatus)]
        public BaseReference FinalCaseStatus
        {
            get { return _FinalCaseStatus == null ? null : ((long)_FinalCaseStatus.Key == 0 ? null : _FinalCaseStatus); }
            set 
            { 
                _FinalCaseStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsFinalCaseStatus = _FinalCaseStatus == null 
                    ? new Int64?()
                    : _FinalCaseStatus.idfsBaseReference; 
                OnPropertyChanged(_str_FinalCaseStatus); 
            }
        }
        private BaseReference _FinalCaseStatus;

        
        public BaseReferenceList FinalCaseStatusLookup
        {
            get { return _FinalCaseStatusLookup; }
        }
        private BaseReferenceList _FinalCaseStatusLookup = new BaseReferenceList("rftCaseStatus");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsOccupationType)]
        public BaseReference OccupationType
        {
            get { return _OccupationType == null ? null : ((long)_OccupationType.Key == 0 ? null : _OccupationType); }
            set 
            { 
                _OccupationType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsOccupationType = _OccupationType == null 
                    ? new Int64?()
                    : _OccupationType.idfsBaseReference; 
                OnPropertyChanged(_str_OccupationType); 
            }
        }
        private BaseReference _OccupationType;

        
        public BaseReferenceList OccupationTypeLookup
        {
            get { return _OccupationTypeLookup; }
        }
        private BaseReferenceList _OccupationTypeLookup = new BaseReferenceList("rftOccupationType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsNotCollectedReason)]
        public BaseReference NotCollectedReason
        {
            get { return _NotCollectedReason == null ? null : ((long)_NotCollectedReason.Key == 0 ? null : _NotCollectedReason); }
            set 
            { 
                _NotCollectedReason = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsNotCollectedReason = _NotCollectedReason == null 
                    ? new Int64?()
                    : _NotCollectedReason.idfsBaseReference; 
                OnPropertyChanged(_str_NotCollectedReason); 
            }
        }
        private BaseReference _NotCollectedReason;

        
        public BaseReferenceList NotCollectedReasonLookup
        {
            get { return _NotCollectedReasonLookup; }
        }
        private BaseReferenceList _NotCollectedReasonLookup = new BaseReferenceList("rftNotCollectedReason");
            
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfSentByOffice)]
        public OrganizationLookup SentByOffice
        {
            get { return _SentByOffice == null ? null : ((long)_SentByOffice.Key == 0 ? null : _SentByOffice); }
            set 
            { 
                _SentByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfSentByOffice = _SentByOffice == null 
                    ? new Int64?()
                    : _SentByOffice.idfInstitution; 
                OnPropertyChanged(_str_SentByOffice); 
            }
        }
        private OrganizationLookup _SentByOffice;

        
        public List<OrganizationLookup> SentByOfficeLookup
        {
            get { return _SentByOfficeLookup; }
        }
        private List<OrganizationLookup> _SentByOfficeLookup = new List<OrganizationLookup>();
            
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfReceivedByOffice)]
        public OrganizationLookup ReceivedByOffice
        {
            get { return _ReceivedByOffice == null ? null : ((long)_ReceivedByOffice.Key == 0 ? null : _ReceivedByOffice); }
            set 
            { 
                _ReceivedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfReceivedByOffice = _ReceivedByOffice == null 
                    ? new Int64?()
                    : _ReceivedByOffice.idfInstitution; 
                OnPropertyChanged(_str_ReceivedByOffice); 
            }
        }
        private OrganizationLookup _ReceivedByOffice;

        
        public List<OrganizationLookup> ReceivedByOfficeLookup
        {
            get { return _ReceivedByOfficeLookup; }
        }
        private List<OrganizationLookup> _ReceivedByOfficeLookup = new List<OrganizationLookup>();
            
        [Relation(typeof(WiderPersonLookup), eidss.model.Schema.WiderPersonLookup._str_idfPerson, _str_idfSentByPerson)]
        public WiderPersonLookup SentByPerson
        {
            get { return _SentByPerson == null ? null : ((long)_SentByPerson.Key == 0 ? null : _SentByPerson); }
            set 
            { 
                _SentByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfSentByPerson = _SentByPerson == null 
                    ? new Int64?()
                    : _SentByPerson.idfPerson; 
                OnPropertyChanged(_str_SentByPerson); 
            }
        }
        private WiderPersonLookup _SentByPerson;

        
        public List<WiderPersonLookup> SentByPersonLookup
        {
            get { return _SentByPersonLookup; }
        }
        private List<WiderPersonLookup> _SentByPersonLookup = new List<WiderPersonLookup>();
            
        [Relation(typeof(WiderPersonLookup), eidss.model.Schema.WiderPersonLookup._str_idfPerson, _str_idfReceivedByPerson)]
        public WiderPersonLookup ReceivedByPerson
        {
            get { return _ReceivedByPerson == null ? null : ((long)_ReceivedByPerson.Key == 0 ? null : _ReceivedByPerson); }
            set 
            { 
                _ReceivedByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfReceivedByPerson = _ReceivedByPerson == null 
                    ? new Int64?()
                    : _ReceivedByPerson.idfPerson; 
                OnPropertyChanged(_str_ReceivedByPerson); 
            }
        }
        private WiderPersonLookup _ReceivedByPerson;

        
        public List<WiderPersonLookup> ReceivedByPersonLookup
        {
            get { return _ReceivedByPersonLookup; }
        }
        private List<WiderPersonLookup> _ReceivedByPersonLookup = new List<WiderPersonLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_CaseProgressStatus:
                    return new BvSelectList(CaseProgressStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseProgressStatus, _str_idfsCaseProgressStatus);
            
                case _str_PatientState:
                    return new BvSelectList(PatientStateLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, PatientState, _str_idfsFinalState);
            
                case _str_PatientLocationType:
                    return new BvSelectList(PatientLocationTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, PatientLocationType, _str_idfsHospitalizationStatus);
            
                case _str_AntimicrobialTherapyUsed:
                    return new BvSelectList(AntimicrobialTherapyUsedLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AntimicrobialTherapyUsed, _str_idfsYNAntimicrobialTherapy);
            
                case _str_Hospitalization:
                    return new BvSelectList(HospitalizationLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Hospitalization, _str_idfsYNHospitalization);
            
                case _str_SpecimenCollected:
                    return new BvSelectList(SpecimenCollectedLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SpecimenCollected, _str_idfsYNSpecimenCollected);
            
                case _str_RelatedToOutbreak:
                    return new BvSelectList(RelatedToOutbreakLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, RelatedToOutbreak, _str_idfsYNRelatedToOutbreak);
            
                case _str_TestsConducted:
                    return new BvSelectList(TestsConductedLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestsConducted, _str_idfsYNTestsConducted);
            
                case _str_Outcome:
                    return new BvSelectList(OutcomeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Outcome, _str_idfsOutcome);
            
                case _str_TentativeDiagnosis:
                    return new BvSelectList(TentativeDiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, TentativeDiagnosis, _str_idfsTentativeDiagnosis);
            
                case _str_FinalDiagnosis:
                    return new BvSelectList(FinalDiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, FinalDiagnosis, _str_idfsFinalDiagnosis);
            
                case _str_InitialCaseStatus:
                    return new BvSelectList(InitialCaseStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, InitialCaseStatus, _str_idfsInitialCaseStatus);
            
                case _str_NonNotifiableDiagnosis:
                    return new BvSelectList(NonNotifiableDiagnosisLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, NonNotifiableDiagnosis, _str_idfsNonNotifiableDiagnosis);
            
                case _str_FinalCaseStatus:
                    return new BvSelectList(FinalCaseStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, FinalCaseStatus, _str_idfsFinalCaseStatus);
            
                case _str_OccupationType:
                    return new BvSelectList(OccupationTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, OccupationType, _str_idfsOccupationType);
            
                case _str_NotCollectedReason:
                    return new BvSelectList(NotCollectedReasonLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, NotCollectedReason, _str_idfsNotCollectedReason);
            
                case _str_SentByOffice:
                    return new BvSelectList(SentByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, SentByOffice, _str_idfSentByOffice);
            
                case _str_ReceivedByOffice:
                    return new BvSelectList(ReceivedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, ReceivedByOffice, _str_idfReceivedByOffice);
            
                case _str_SentByPerson:
                    return new BvSelectList(SentByPersonLookup, eidss.model.Schema.WiderPersonLookup._str_idfPerson, null, SentByPerson, _str_idfSentByPerson);
            
                case _str_ReceivedByPerson:
                    return new BvSelectList(ReceivedByPersonLookup, eidss.model.Schema.WiderPersonLookup._str_idfPerson, null, ReceivedByPerson, _str_idfReceivedByPerson);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strDiagnosis)]
        public string strDiagnosis
        {
            get { return new Func<HumanCase, string>(c => c.FinalDiagnosis == null ? (c.TentativeDiagnosis == null ? "" : c.TentativeDiagnosis.name) : c.FinalDiagnosis.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsDiagnosis)]
        public long? idfsDiagnosis
        {
            get { return new Func<HumanCase, long?>(c => c.idfsFinalDiagnosis == null ? (c.idfsTentativeDiagnosis == null ? null : c.idfsTentativeDiagnosis) : c.idfsFinalDiagnosis)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_DiagnosisAll)]
        public List<DiagnosisLookup> DiagnosisAll
        {
            get { return new Func<HumanCase, List<DiagnosisLookup>>(c => idfsDiagnosis == null ? new List<DiagnosisLookup>() : new List<DiagnosisLookup>(new [] { c.FinalDiagnosis ?? c.TentativeDiagnosis } ))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strCaseClassification)]
        public string strCaseClassification
        {
            get { return new Func<HumanCase, string>(c => c.FinalCaseStatus == null ? (c.InitialCaseStatus == null ? "" : c.InitialCaseStatus.name) : c.FinalCaseStatus.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_datD)]
        public DateTime? datD
        {
            get { return new Func<HumanCase, DateTime?>(c => c.datOnSetDate != null ? c.datOnSetDate : (c.datNotificationDate ?? c.datEnteredDate))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsClosed)]
        public bool IsClosed
        {
            get { return new Func<HumanCase, bool>(c => (c.idfsCaseProgressStatus == (long)CaseStatusEnum.Closed) && !c.IsDirty)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyLocalIdentifier)]
        public string strReadOnlyLocalIdentifier
        {
            get { return new Func<HumanCase, string>(c => c.strLocalIdentifier)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyNotificationDate)]
        public string strReadOnlyNotificationDate
        {
            get { return new Func<HumanCase, string>(c => c.datNotificationDate == null ? (string)null : c.datNotificationDate.Value.ToString())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyFacilityLastVisit)]
        public string strReadOnlyFacilityLastVisit
        {
            get { return new Func<HumanCase, string>(c => c.datFacilityLastVisit == null ? (string)null : c.datFacilityLastVisit.Value.ToString())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyEnteredDate)]
        public string strReadOnlyEnteredDate
        {
            get { return new Func<HumanCase, string>(c => c.datEnteredDate == null ? (string)null : c.datEnteredDate.Value.ToString())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyModificationDate)]
        public string strReadOnlyModificationDate
        {
            get { return new Func<HumanCase, string>(c => c.datModificationDate == null ? (string)null : c.datModificationDate.Value.ToString())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyOnSetDate)]
        public string strReadOnlyOnSetDate
        {
            get { return new Func<HumanCase, string>(c => c.datOnSetDate == null ? (string)null : c.datOnSetDate.Value.ToString("d"))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyDiagnosisDate)]
        public string strReadOnlyDiagnosisDate
        {
            get { return new Func<HumanCase, string>(c => c.datFinalDiagnosisDate == null ? 
                                   (c.datTentativeDiagnosisDate == null ? (string)null : c.datTentativeDiagnosisDate.Value.ToString()) : c.datFinalDiagnosisDate.Value.ToString())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyFinalDiagnosisDate)]
        public string strReadOnlyFinalDiagnosisDate
        {
            get { return new Func<HumanCase, string>(c => c.FinalDiagnosis == null ? 
                                   (c.datTentativeDiagnosisDate == null ? (string)null : c.datTentativeDiagnosisDate.Value.ToString()) : 
                                   (c.datFinalDiagnosisDate == null ? (string)null : c.datFinalDiagnosisDate.Value.ToString()))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyTentativeDiagnosis1)]
        public string strReadOnlyTentativeDiagnosis1
        {
            get { return new Func<HumanCase, string>(c => c.idfsTentativeDiagnosis == null ? (string)null : c.TentativeDiagnosis.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyDiagnosis)]
        public string strReadOnlyDiagnosis
        {
            get { return new Func<HumanCase, string>(c => c.FinalDiagnosis == null ? (c.TentativeDiagnosis == null ? "" : c.TentativeDiagnosis.name) : c.FinalDiagnosis.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isChangeDiagnosisReasonEnter)]
        public bool isChangeDiagnosisReasonEnter
        {
            get { return new Func<HumanCase, bool>(c => idfsChangeDiagnosisReason.HasValue)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_blnEnableTestsConductedCalc)]
        public bool blnEnableTestsConductedCalc
        {
            get { return new Func<HumanCase, bool>(c => c.CaseTests == null || c.CaseTests.Where(i => !i.IsMarkedToDelete && i.idfsTestStatus == (long)BatchStatusEnum.Completed).Count() == 0)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_buttonGeoLocationPicker)]
        public string buttonGeoLocationPicker
        {
            get { return new Func<HumanCase, string>(c => "")(this); }
            
        }
        
          [LocalizedDisplayName(_str_idfsChangeDiagnosisReason)]
        public long? idfsChangeDiagnosisReason
        {
            get { return m_idfsChangeDiagnosisReason; }
            set { if (m_idfsChangeDiagnosisReason != value) { m_idfsChangeDiagnosisReason = value; OnPropertyChanged(_str_idfsChangeDiagnosisReason); } }
        }
        private long? m_idfsChangeDiagnosisReason;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "HumanCase";

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
        
            if (_PointGeoLocation != null) { _PointGeoLocation.Parent = this; }
                
            if (_FFPresenterCs != null) { _FFPresenterCs.Parent = this; }
                
            if (_FFPresenterEpi != null) { _FFPresenterEpi.Parent = this; }
                
            if (_Patient != null) { _Patient.Parent = this; }
                
            if (_RegistrationAddress != null) { _RegistrationAddress.Parent = this; }
                CaseTests.ForEach(c => { c.Parent = this; });
                CaseTestValidations.ForEach(c => { c.Parent = this; });
                ContactedPerson.ForEach(c => { c.Parent = this; });
                Samples.ForEach(c => { c.Parent = this; });
                AntimicrobialTherapy.ForEach(c => { c.Parent = this; });
                DiagnosisHistory.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as HumanCase;
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
            var ret = base.Clone() as HumanCase;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_PointGeoLocation != null)
              ret.PointGeoLocation = _PointGeoLocation.CloneWithSetup(manager) as GeoLocation;
                
            if (_FFPresenterCs != null)
              ret.FFPresenterCs = _FFPresenterCs.CloneWithSetup(manager) as FFPresenterModel;
                
            if (_FFPresenterEpi != null)
              ret.FFPresenterEpi = _FFPresenterEpi.CloneWithSetup(manager) as FFPresenterModel;
                
            if (_Patient != null)
              ret.Patient = _Patient.CloneWithSetup(manager) as Patient;
                
            if (_RegistrationAddress != null)
              ret.RegistrationAddress = _RegistrationAddress.CloneWithSetup(manager) as Address;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public HumanCase CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as HumanCase;
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
        
                    || (_PointGeoLocation != null && _PointGeoLocation.HasChanges)
                
                    || (_FFPresenterCs != null && _FFPresenterCs.HasChanges)
                
                    || (_FFPresenterEpi != null && _FFPresenterEpi.HasChanges)
                
                    || (_Patient != null && _Patient.HasChanges)
                
                    || (_RegistrationAddress != null && _RegistrationAddress.HasChanges)
                
                    || CaseTests.IsDirty
                    || CaseTests.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || CaseTestValidations.IsDirty
                    || CaseTestValidations.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || ContactedPerson.IsDirty
                    || ContactedPerson.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Samples.IsDirty
                    || Samples.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || AntimicrobialTherapy.IsDirty
                    || AntimicrobialTherapy.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || DiagnosisHistory.IsDirty
                    || DiagnosisHistory.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsCaseProgressStatus_CaseProgressStatus = idfsCaseProgressStatus;
            var _prev_idfsFinalState_PatientState = idfsFinalState;
            var _prev_idfsHospitalizationStatus_PatientLocationType = idfsHospitalizationStatus;
            var _prev_idfsYNAntimicrobialTherapy_AntimicrobialTherapyUsed = idfsYNAntimicrobialTherapy;
            var _prev_idfsYNHospitalization_Hospitalization = idfsYNHospitalization;
            var _prev_idfsYNSpecimenCollected_SpecimenCollected = idfsYNSpecimenCollected;
            var _prev_idfsYNRelatedToOutbreak_RelatedToOutbreak = idfsYNRelatedToOutbreak;
            var _prev_idfsYNTestsConducted_TestsConducted = idfsYNTestsConducted;
            var _prev_idfsOutcome_Outcome = idfsOutcome;
            var _prev_idfsTentativeDiagnosis_TentativeDiagnosis = idfsTentativeDiagnosis;
            var _prev_idfsFinalDiagnosis_FinalDiagnosis = idfsFinalDiagnosis;
            var _prev_idfsInitialCaseStatus_InitialCaseStatus = idfsInitialCaseStatus;
            var _prev_idfsNonNotifiableDiagnosis_NonNotifiableDiagnosis = idfsNonNotifiableDiagnosis;
            var _prev_idfsFinalCaseStatus_FinalCaseStatus = idfsFinalCaseStatus;
            var _prev_idfsOccupationType_OccupationType = idfsOccupationType;
            var _prev_idfsNotCollectedReason_NotCollectedReason = idfsNotCollectedReason;
            var _prev_idfSentByOffice_SentByOffice = idfSentByOffice;
            var _prev_idfReceivedByOffice_ReceivedByOffice = idfReceivedByOffice;
            var _prev_idfSentByPerson_SentByPerson = idfSentByPerson;
            var _prev_idfReceivedByPerson_ReceivedByPerson = idfReceivedByPerson;
            base.RejectChanges();
        
            if (_prev_idfsCaseProgressStatus_CaseProgressStatus != idfsCaseProgressStatus)
            {
                _CaseProgressStatus = _CaseProgressStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseProgressStatus);
            }
            if (_prev_idfsFinalState_PatientState != idfsFinalState)
            {
                _PatientState = _PatientStateLookup.FirstOrDefault(c => c.idfsBaseReference == idfsFinalState);
            }
            if (_prev_idfsHospitalizationStatus_PatientLocationType != idfsHospitalizationStatus)
            {
                _PatientLocationType = _PatientLocationTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsHospitalizationStatus);
            }
            if (_prev_idfsYNAntimicrobialTherapy_AntimicrobialTherapyUsed != idfsYNAntimicrobialTherapy)
            {
                _AntimicrobialTherapyUsed = _AntimicrobialTherapyUsedLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNAntimicrobialTherapy);
            }
            if (_prev_idfsYNHospitalization_Hospitalization != idfsYNHospitalization)
            {
                _Hospitalization = _HospitalizationLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNHospitalization);
            }
            if (_prev_idfsYNSpecimenCollected_SpecimenCollected != idfsYNSpecimenCollected)
            {
                _SpecimenCollected = _SpecimenCollectedLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNSpecimenCollected);
            }
            if (_prev_idfsYNRelatedToOutbreak_RelatedToOutbreak != idfsYNRelatedToOutbreak)
            {
                _RelatedToOutbreak = _RelatedToOutbreakLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNRelatedToOutbreak);
            }
            if (_prev_idfsYNTestsConducted_TestsConducted != idfsYNTestsConducted)
            {
                _TestsConducted = _TestsConductedLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNTestsConducted);
            }
            if (_prev_idfsOutcome_Outcome != idfsOutcome)
            {
                _Outcome = _OutcomeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsOutcome);
            }
            if (_prev_idfsTentativeDiagnosis_TentativeDiagnosis != idfsTentativeDiagnosis)
            {
                _TentativeDiagnosis = _TentativeDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsTentativeDiagnosis);
            }
            if (_prev_idfsFinalDiagnosis_FinalDiagnosis != idfsFinalDiagnosis)
            {
                _FinalDiagnosis = _FinalDiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsFinalDiagnosis);
            }
            if (_prev_idfsInitialCaseStatus_InitialCaseStatus != idfsInitialCaseStatus)
            {
                _InitialCaseStatus = _InitialCaseStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsInitialCaseStatus);
            }
            if (_prev_idfsNonNotifiableDiagnosis_NonNotifiableDiagnosis != idfsNonNotifiableDiagnosis)
            {
                _NonNotifiableDiagnosis = _NonNotifiableDiagnosisLookup.FirstOrDefault(c => c.idfsBaseReference == idfsNonNotifiableDiagnosis);
            }
            if (_prev_idfsFinalCaseStatus_FinalCaseStatus != idfsFinalCaseStatus)
            {
                _FinalCaseStatus = _FinalCaseStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsFinalCaseStatus);
            }
            if (_prev_idfsOccupationType_OccupationType != idfsOccupationType)
            {
                _OccupationType = _OccupationTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsOccupationType);
            }
            if (_prev_idfsNotCollectedReason_NotCollectedReason != idfsNotCollectedReason)
            {
                _NotCollectedReason = _NotCollectedReasonLookup.FirstOrDefault(c => c.idfsBaseReference == idfsNotCollectedReason);
            }
            if (_prev_idfSentByOffice_SentByOffice != idfSentByOffice)
            {
                _SentByOffice = _SentByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfSentByOffice);
            }
            if (_prev_idfReceivedByOffice_ReceivedByOffice != idfReceivedByOffice)
            {
                _ReceivedByOffice = _ReceivedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfReceivedByOffice);
            }
            if (_prev_idfSentByPerson_SentByPerson != idfSentByPerson)
            {
                _SentByPerson = _SentByPersonLookup.FirstOrDefault(c => c.idfPerson == idfSentByPerson);
            }
            if (_prev_idfReceivedByPerson_ReceivedByPerson != idfReceivedByPerson)
            {
                _ReceivedByPerson = _ReceivedByPersonLookup.FirstOrDefault(c => c.idfPerson == idfReceivedByPerson);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (PointGeoLocation != null) PointGeoLocation.RejectChanges();
                
            if (FFPresenterCs != null) FFPresenterCs.RejectChanges();
                
            if (FFPresenterEpi != null) FFPresenterEpi.RejectChanges();
                
            if (Patient != null) Patient.RejectChanges();
                
            if (RegistrationAddress != null) RegistrationAddress.RejectChanges();
                CaseTests.RejectChanges();
                CaseTestValidations.RejectChanges();
                ContactedPerson.RejectChanges();
                Samples.RejectChanges();
                AntimicrobialTherapy.RejectChanges();
                DiagnosisHistory.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_PointGeoLocation != null) _PointGeoLocation.AcceptChanges();
                
            if (_FFPresenterCs != null) _FFPresenterCs.AcceptChanges();
                
            if (_FFPresenterEpi != null) _FFPresenterEpi.AcceptChanges();
                
            if (_Patient != null) _Patient.AcceptChanges();
                
            if (_RegistrationAddress != null) _RegistrationAddress.AcceptChanges();
                CaseTests.AcceptChanges();
                CaseTestValidations.AcceptChanges();
                ContactedPerson.AcceptChanges();
                Samples.AcceptChanges();
                AntimicrobialTherapy.AcceptChanges();
                DiagnosisHistory.AcceptChanges();
                
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
        
            if (_PointGeoLocation != null) _PointGeoLocation.SetChange();
                
            if (_FFPresenterCs != null) _FFPresenterCs.SetChange();
                
            if (_FFPresenterEpi != null) _FFPresenterEpi.SetChange();
                
            if (_Patient != null) _Patient.SetChange();
                
            if (_RegistrationAddress != null) _RegistrationAddress.SetChange();
                CaseTests.ForEach(c => c.SetChange());
                CaseTestValidations.ForEach(c => c.SetChange());
                ContactedPerson.ForEach(c => c.SetChange());
                Samples.ForEach(c => c.SetChange());
                AntimicrobialTherapy.ForEach(c => c.SetChange());
                DiagnosisHistory.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, HumanCase c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public HumanCase()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(HumanCase_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(HumanCase_PropertyChanged);
        }
        private void HumanCase_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as HumanCase).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsFinalDiagnosis)
                OnPropertyChanged(_str_strDiagnosis);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis)
                OnPropertyChanged(_str_strDiagnosis);
                  
            if (e.PropertyName == _str_idfsFinalDiagnosis)
                OnPropertyChanged(_str_idfsDiagnosis);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis)
                OnPropertyChanged(_str_idfsDiagnosis);
                  
            if (e.PropertyName == _str_idfsFinalDiagnosis)
                OnPropertyChanged(_str_DiagnosisAll);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis)
                OnPropertyChanged(_str_DiagnosisAll);
                  
            if (e.PropertyName == _str_idfsInitialCaseStatus)
                OnPropertyChanged(_str_strCaseClassification);
                  
            if (e.PropertyName == _str_idfsFinalCaseStatus)
                OnPropertyChanged(_str_strCaseClassification);
                  
            if (e.PropertyName == _str_datOnSetDate)
                OnPropertyChanged(_str_datD);
                  
            if (e.PropertyName == _str_datNotificationDate)
                OnPropertyChanged(_str_datD);
                  
            if (e.PropertyName == _str_datEnteredDate)
                OnPropertyChanged(_str_datD);
                  
            if (e.PropertyName == _str_idfsCaseProgressStatus)
                OnPropertyChanged(_str_IsClosed);
                  
            if (e.PropertyName == _str_strLocalIdentifier)
                OnPropertyChanged(_str_strReadOnlyLocalIdentifier);
                  
            if (e.PropertyName == _str_datNotificationDate)
                OnPropertyChanged(_str_strReadOnlyNotificationDate);
                  
            if (e.PropertyName == _str_datFacilityLastVisit)
                OnPropertyChanged(_str_strReadOnlyFacilityLastVisit);
                  
            if (e.PropertyName == _str_datEnteredDate)
                OnPropertyChanged(_str_strReadOnlyEnteredDate);
                  
            if (e.PropertyName == _str_datModificationDate)
                OnPropertyChanged(_str_strReadOnlyModificationDate);
                  
            if (e.PropertyName == _str_datOnSetDate)
                OnPropertyChanged(_str_strReadOnlyOnSetDate);
                  
            if (e.PropertyName == _str_datTentativeDiagnosisDate)
                OnPropertyChanged(_str_strReadOnlyDiagnosisDate);
                  
            if (e.PropertyName == _str_datFinalDiagnosisDate)
                OnPropertyChanged(_str_strReadOnlyDiagnosisDate);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis)
                OnPropertyChanged(_str_strReadOnlyFinalDiagnosisDate);
                  
            if (e.PropertyName == _str_datTentativeDiagnosisDate)
                OnPropertyChanged(_str_strReadOnlyFinalDiagnosisDate);
                  
            if (e.PropertyName == _str_datFinalDiagnosisDate)
                OnPropertyChanged(_str_strReadOnlyFinalDiagnosisDate);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis)
                OnPropertyChanged(_str_strReadOnlyTentativeDiagnosis1);
                  
            if (e.PropertyName == _str_idfsFinalDiagnosis)
                OnPropertyChanged(_str_strReadOnlyDiagnosis);
                  
            if (e.PropertyName == _str_idfsTentativeDiagnosis)
                OnPropertyChanged(_str_strReadOnlyDiagnosis);
                  
            if (e.PropertyName == _str_idfsChangeDiagnosisReason)
                OnPropertyChanged(_str_isChangeDiagnosisReasonEnter);
                  
            if (e.PropertyName == _str_idfPointGeoLocation)
                OnPropertyChanged(_str_buttonGeoLocationPicker);
                  
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
            HumanCase obj = this;
            
        }
        private void _DeletedExtenders()
        {
            HumanCase obj = this;
            
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
    
        private static string[] invisible_names1 = "NotCollectedReason,idfsNotCollectedReason".Split(new char[] { ',' });
        
        private static string[] invisible_names2 = "datDischargeDate".Split(new char[] { ',' });
        
        private static string[] invisible_names3 = "datDateOfDeath".Split(new char[] { ',' });
        
        private bool _isInvisible(string name)
        {
            
            if (invisible_names1.Where(c => c == name).Count() > 0)
                return new Func<HumanCase, bool>(c => c.SpecimenCollected == null || c.idfsYNSpecimenCollected == (long)YesNoUnknownValuesEnum.Yes || c.idfsYNSpecimenCollected == (long)YesNoUnknownValuesEnum.Unknown)(this);
            
            if (invisible_names2.Where(c => c == name).Count() > 0)
                return new Func<HumanCase, bool>(c => c.Outcome == null || c.idfsOutcome == (long)OutcomeTypeEnum.Died || c.idfsOutcome == (long)OutcomeTypeEnum.Unknown)(this);
            
            if (invisible_names3.Where(c => c == name).Count() > 0)
                return new Func<HumanCase, bool>(c => c.Outcome == null || c.idfsOutcome == (long)OutcomeTypeEnum.Recovered || c.idfsOutcome == (long)OutcomeTypeEnum.Unknown)(this);
            
            return new Func<HumanCase, bool>(c => false)(this);
                
        }

    
        private static string[] readonly_names1 = "strDiagnosis,strCaseClassification,strCaseID,datEnteredDate,datModificationDate,strReadOnlyEnteredDate,strReadOnlyModificationDate".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strReadOnlyLocalIdentifier,strReadOnlyTentativeDiagnosis1,strReadOnlyDiagnosis".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "strSentByOffice,strReceivedByOffice,strInvestigatedByOffice".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "strSoughtCareFacility".Split(new char[] { ',' });
        
        private static string[] readonly_names5 = "TestsConducted,idfsYNTestsConducted".Split(new char[] { ',' });
        
        private static string[] readonly_names6 = "SentByPerson,idfSentByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names7 = "SentByPerson,idfSentByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names8 = "strSentByPerson,strReceivedByPerson,strInvestigatedByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names9 = "ReceivedByPerson,idfReceivedByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names10 = "strReadOnlyNotificationDate,strReadOnlyFacilityLastVisit,strReadOnlyOnSetDate,strReadOnlyDiagnosisDate,strReadOnlyFinalDiagnosisDate".Split(new char[] { ',' });
        
        private static string[] readonly_names11 = "idfsCaseProgressStatus,CaseProgressStatus".Split(new char[] { ',' });
        
        private static string[] readonly_names12 = "AntimicrobialTherapy".Split(new char[] { ',' });
        
        private static string[] readonly_names13 = "Samples".Split(new char[] { ',' });
        
        private static string[] readonly_names14 = "CaseTests,CaseTestValidations".Split(new char[] { ',' });
        
        private static string[] readonly_names15 = "strSampleNotes".Split(new char[] { ',' });
        
        private static string[] readonly_names16 = "NotCollectedReason,idfsNotCollectedReason".Split(new char[] { ',' });
        
        private static string[] readonly_names17 = "datHospitalizationDate,strHospitalizationPlace".Split(new char[] { ',' });
        
        private static string[] readonly_names18 = "strCurrentLocation".Split(new char[] { ',' });
        
        private static string[] readonly_names19 = "datFinalDiagnosisDate".Split(new char[] { ',' });
        
        private static string[] readonly_names20 = "datTentativeDiagnosisDate".Split(new char[] { ',' });
        
        private static string[] readonly_names21 = "intPatientAge,idfsHumanAgeType".Split(new char[] { ',' });
        
        private static string[] readonly_names22 = "blnClinicalDiagBasis,blnEpiDiagBasis,blnLabDiagBasis".Split(new char[] { ',' });
        
        private static string[] readonly_names23 = "buttonGeoLocationPicker".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => true)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => true)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => true)(this);
            
            if (readonly_names5.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || (c.blnEnableTestsConducted != null && !c.blnEnableTestsConducted.Value) || !c.blnEnableTestsConductedCalc)(this);
            
            if (readonly_names6.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || c.idfSentByOffice == null)(this);
            
            if (readonly_names7.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || c.idfSentByOffice == null)(this);
            
            if (readonly_names8.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => true)(this);
            
            if (readonly_names9.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || c.idfReceivedByOffice == null)(this);
            
            if (readonly_names10.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => true)(this);
            
            if (readonly_names11.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.ReadOnly)(this);
            
            if (readonly_names12.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || c.AntimicrobialTherapyUsed == null || c.idfsYNAntimicrobialTherapy != (long)YesNoUnknownValuesEnum.Yes)(this);
            
            if (readonly_names13.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || c.SpecimenCollected == null || c.idfsYNSpecimenCollected != (long)YesNoUnknownValuesEnum.Yes)(this);
            
            if (readonly_names14.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || (c.TestsConducted != null && c.idfsYNTestsConducted == (long)YesNoUnknownValuesEnum.No))(this);
            
            if (readonly_names15.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || c.SpecimenCollected == null || c.idfsYNSpecimenCollected != (long)YesNoUnknownValuesEnum.Yes)(this);
            
            if (readonly_names16.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || c.SpecimenCollected == null || c.idfsYNSpecimenCollected == (long)YesNoUnknownValuesEnum.Yes || c.idfsYNSpecimenCollected == (long)YesNoUnknownValuesEnum.Unknown)(this);
            
            if (readonly_names17.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || c.Hospitalization == null || c.idfsYNHospitalization != (long)YesNoUnknownValuesEnum.Yes)(this);
            
            if (readonly_names18.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || c.PatientLocationType == null || (c.idfsHospitalizationStatus != (long)PatientLocationTypeEnum.Hospital && c.idfsHospitalizationStatus != (long)PatientLocationTypeEnum.Other))(this);
            
            if (readonly_names19.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || c.idfsFinalDiagnosis == null)(this);
            
            if (readonly_names20.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || c.idfsTentativeDiagnosis == null)(this);
            
            if (readonly_names21.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || c.Patient.datDateofBirth != null)(this);
            
            if (readonly_names22.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly || c.idfsTentativeDiagnosis == null && c.idfsFinalDiagnosis == null)(this);
            
            if (readonly_names23.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly)(this);
            
            return ReadOnly || new Func<HumanCase, bool>(c => c.IsClosed || c.ReadOnly)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_PointGeoLocation != null)
                    _PointGeoLocation.ReadOnly = value;
                
                if (_FFPresenterCs != null)
                    _FFPresenterCs.ReadOnly = value;
                
                if (_FFPresenterEpi != null)
                    _FFPresenterEpi.ReadOnly = value;
                
                if (_Patient != null)
                    _Patient.ReadOnly = value;
                
                if (_RegistrationAddress != null)
                    _RegistrationAddress.ReadOnly = value;
                
                foreach(var o in _CaseTests)
                    o.ReadOnly = value;
                
                foreach(var o in _CaseTestValidations)
                    o.ReadOnly = value;
                
                foreach(var o in _ContactedPerson)
                    o.ReadOnly = value;
                
                foreach(var o in _Samples)
                    o.ReadOnly = value;
                
                foreach(var o in _AntimicrobialTherapy)
                    o.ReadOnly = value;
                
                foreach(var o in _DiagnosisHistory)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<HumanCase, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<HumanCase, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<HumanCase, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<HumanCase, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<HumanCase, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<HumanCase, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~HumanCase()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftCaseProgressStatus", this);
                
                LookupManager.RemoveObject("rftFinalState", this);
                
                LookupManager.RemoveObject("rftHospStatus", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftOutcome", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftCaseStatus", this);
                
                LookupManager.RemoveObject("rftNonNotifiableDiagnosis", this);
                
                LookupManager.RemoveObject("rftCaseStatus", this);
                
                LookupManager.RemoveObject("rftOccupationType", this);
                
                LookupManager.RemoveObject("rftNotCollectedReason", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("WiderPersonLookup", this);
                
                LookupManager.RemoveObject("WiderPersonLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftCaseProgressStatus")
                _getAccessor().LoadLookup_CaseProgressStatus(manager, this);
            
            if (lookup_object == "rftFinalState")
                _getAccessor().LoadLookup_PatientState(manager, this);
            
            if (lookup_object == "rftHospStatus")
                _getAccessor().LoadLookup_PatientLocationType(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_AntimicrobialTherapyUsed(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_Hospitalization(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_SpecimenCollected(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_RelatedToOutbreak(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_TestsConducted(manager, this);
            
            if (lookup_object == "rftOutcome")
                _getAccessor().LoadLookup_Outcome(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_TentativeDiagnosis(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_FinalDiagnosis(manager, this);
            
            if (lookup_object == "rftCaseStatus")
                _getAccessor().LoadLookup_InitialCaseStatus(manager, this);
            
            if (lookup_object == "rftNonNotifiableDiagnosis")
                _getAccessor().LoadLookup_NonNotifiableDiagnosis(manager, this);
            
            if (lookup_object == "rftCaseStatus")
                _getAccessor().LoadLookup_FinalCaseStatus(manager, this);
            
            if (lookup_object == "rftOccupationType")
                _getAccessor().LoadLookup_OccupationType(manager, this);
            
            if (lookup_object == "rftNotCollectedReason")
                _getAccessor().LoadLookup_NotCollectedReason(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_SentByOffice(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_ReceivedByOffice(manager, this);
            
            if (lookup_object == "WiderPersonLookup")
                _getAccessor().LoadLookup_SentByPerson(manager, this);
            
            if (lookup_object == "WiderPersonLookup")
                _getAccessor().LoadLookup_ReceivedByPerson(manager, this);
            
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
        
            if (_PointGeoLocation != null) _PointGeoLocation.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_FFPresenterCs != null) _FFPresenterCs.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_FFPresenterEpi != null) _FFPresenterEpi.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_Patient != null) _Patient.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_RegistrationAddress != null) _RegistrationAddress.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_CaseTests != null) _CaseTests.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_CaseTestValidations != null) _CaseTestValidations.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_ContactedPerson != null) _ContactedPerson.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Samples != null) _Samples.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_AntimicrobialTherapy != null) _AntimicrobialTherapy.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_DiagnosisHistory != null) _DiagnosisHistory.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<HumanCase>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(HumanCase obj);
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
            private GeoLocation.Accessor PointGeoLocationAccessor { get { return eidss.model.Schema.GeoLocation.Accessor.Instance(m_CS); } }
            private FFPresenterModel.Accessor FFPresenterCsAccessor { get { return eidss.model.Schema.FFPresenterModel.Accessor.Instance(m_CS); } }
            private FFPresenterModel.Accessor FFPresenterEpiAccessor { get { return eidss.model.Schema.FFPresenterModel.Accessor.Instance(m_CS); } }
            private Patient.Accessor PatientAccessor { get { return eidss.model.Schema.Patient.Accessor.Instance(m_CS); } }
            private Address.Accessor RegistrationAddressAccessor { get { return eidss.model.Schema.Address.Accessor.Instance(m_CS); } }
            private CaseTest.Accessor CaseTestsAccessor { get { return eidss.model.Schema.CaseTest.Accessor.Instance(m_CS); } }
            private CaseTestValidation.Accessor CaseTestValidationsAccessor { get { return eidss.model.Schema.CaseTestValidation.Accessor.Instance(m_CS); } }
            private ContactedCasePerson.Accessor ContactedPersonAccessor { get { return eidss.model.Schema.ContactedCasePerson.Accessor.Instance(m_CS); } }
            private HumanCaseSample.Accessor SamplesAccessor { get { return eidss.model.Schema.HumanCaseSample.Accessor.Instance(m_CS); } }
            private AntimicrobialTherapy.Accessor AntimicrobialTherapyAccessor { get { return eidss.model.Schema.AntimicrobialTherapy.Accessor.Instance(m_CS); } }
            private ChangeDiagnosisHistory.Accessor DiagnosisHistoryAccessor { get { return eidss.model.Schema.ChangeDiagnosisHistory.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CaseProgressStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PatientStateAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PatientLocationTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AntimicrobialTherapyUsedAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor HospitalizationAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SpecimenCollectedAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor RelatedToOutbreakAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestsConductedAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor OutcomeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor TentativeDiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor FinalDiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor InitialCaseStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor NonNotifiableDiagnosisAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor FinalCaseStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor OccupationTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor NotCollectedReasonAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor SentByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor ReceivedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private WiderPersonLookup.Accessor SentByPersonAccessor { get { return eidss.model.Schema.WiderPersonLookup.Accessor.Instance(m_CS); } }
            private WiderPersonLookup.Accessor ReceivedByPersonAccessor { get { return eidss.model.Schema.WiderPersonLookup.Accessor.Instance(m_CS); } }
            

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

            
            public virtual HumanCase SelectByKey(DbManagerProxy manager
                , Int64? idfCase
                )
            {
                return _SelectByKey(manager
                    , idfCase
                    , null, null
                    );
            }
            
      
            private HumanCase _SelectByKey(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<HumanCase> objs = new List<HumanCase>();
                sets[0] = new MapResultSet(typeof(HumanCase), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spHumanCase_SelectDetail"
                            , manager.Parameter("@idfCase", idfCase)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    HumanCase obj = objs[0];
                    obj.m_CS = m_CS;
                    
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
    
            private void _SetupAddChildHandlerCaseTests(HumanCase obj)
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
            
            private void _SetupAddChildHandlerCaseTestValidations(HumanCase obj)
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
            
            private void _SetupAddChildHandlerContactedPerson(HumanCase obj)
            {
                obj.ContactedPerson.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerSamples(HumanCase obj)
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
            
            private void _SetupAddChildHandlerAntimicrobialTherapy(HumanCase obj)
            {
                obj.AntimicrobialTherapy.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerDiagnosisHistory(HumanCase obj)
            {
                obj.DiagnosisHistory.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadPointGeoLocation(HumanCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadPointGeoLocation(manager, obj);
                }
            }
            internal void _LoadPointGeoLocation(DbManagerProxy manager, HumanCase obj)
            {
                
                if (obj.PointGeoLocation == null && obj.idfPointGeoLocation != null && obj.idfPointGeoLocation != 0)
                {
                    obj.PointGeoLocation = PointGeoLocationAccessor.SelectByKey(manager
                        
                        , obj.idfPointGeoLocation.Value
                        );
                    if (obj.PointGeoLocation != null)
                    {
                        obj.PointGeoLocation.m_ObjectName = _str_PointGeoLocation;
                    }
                }
                    
            }
            
            internal void _LoadFFPresenterCs(HumanCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFFPresenterCs(manager, obj);
                }
            }
            internal void _LoadFFPresenterCs(DbManagerProxy manager, HumanCase obj)
            {
                
                if (obj.FFPresenterCs == null && obj.idfCSObservation != null && obj.idfCSObservation != 0)
                {
                    obj.FFPresenterCs = FFPresenterCsAccessor.SelectByKey(manager
                        
                        , obj.idfCSObservation.Value
                        );
                    if (obj.FFPresenterCs != null)
                    {
                        obj.FFPresenterCs.m_ObjectName = _str_FFPresenterCs;
                    }
                }
                    
            }
            
            internal void _LoadFFPresenterEpi(HumanCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFFPresenterEpi(manager, obj);
                }
            }
            internal void _LoadFFPresenterEpi(DbManagerProxy manager, HumanCase obj)
            {
                
                if (obj.FFPresenterEpi == null && obj.idfEpiObservation != null && obj.idfEpiObservation != 0)
                {
                    obj.FFPresenterEpi = FFPresenterEpiAccessor.SelectByKey(manager
                        
                        , obj.idfEpiObservation.Value
                        );
                    if (obj.FFPresenterEpi != null)
                    {
                        obj.FFPresenterEpi.m_ObjectName = _str_FFPresenterEpi;
                    }
                }
                    
            }
            
            internal void _LoadPatient(HumanCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadPatient(manager, obj);
                }
            }
            internal void _LoadPatient(DbManagerProxy manager, HumanCase obj)
            {
                
                if (obj.Patient == null && obj.idfHuman != null && obj.idfHuman != 0)
                {
                    obj.Patient = PatientAccessor.SelectByKey(manager
                        
                        , obj.idfHuman.Value
                        );
                    if (obj.Patient != null)
                    {
                        obj.Patient.m_ObjectName = _str_Patient;
                    }
                }
                    
            }
            
            internal void _LoadRegistrationAddress(HumanCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadRegistrationAddress(manager, obj);
                }
            }
            internal void _LoadRegistrationAddress(DbManagerProxy manager, HumanCase obj)
            {
                
                if (obj.RegistrationAddress == null && obj.idfRegistrationAddress != null && obj.idfRegistrationAddress != 0)
                {
                    obj.RegistrationAddress = RegistrationAddressAccessor.SelectByKey(manager
                        
                        , obj.idfRegistrationAddress.Value
                        );
                    if (obj.RegistrationAddress != null)
                    {
                        obj.RegistrationAddress.m_ObjectName = _str_RegistrationAddress;
                    }
                }
                    
            }
            
            internal void _LoadCaseTests(HumanCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadCaseTests(manager, obj);
                }
            }
            internal void _LoadCaseTests(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.CaseTests.Clear();
                obj.CaseTests.AddRange(CaseTestsAccessor.SelectDetailList(manager
                    
                    , obj.idfCase
                    ));
                obj.CaseTests.ForEach(c => c.m_ObjectName = _str_CaseTests);
                obj.CaseTests.AcceptChanges();
                    
            }
            
            internal void _LoadCaseTestValidations(HumanCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadCaseTestValidations(manager, obj);
                }
            }
            internal void _LoadCaseTestValidations(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.CaseTestValidations.Clear();
                obj.CaseTestValidations.AddRange(CaseTestValidationsAccessor.SelectDetailList(manager
                    
                    , obj.idfCase
                    ));
                obj.CaseTestValidations.ForEach(c => c.m_ObjectName = _str_CaseTestValidations);
                obj.CaseTestValidations.AcceptChanges();
                    
            }
            
            internal void _LoadContactedPerson(HumanCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadContactedPerson(manager, obj);
                }
            }
            internal void _LoadContactedPerson(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.ContactedPerson.Clear();
                obj.ContactedPerson.AddRange(ContactedPersonAccessor.SelectDetailList(manager
                    
                    , obj.idfCase
                    ));
                obj.ContactedPerson.ForEach(c => c.m_ObjectName = _str_ContactedPerson);
                obj.ContactedPerson.AcceptChanges();
                    
            }
            
            internal void _LoadSamples(HumanCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSamples(manager, obj);
                }
            }
            internal void _LoadSamples(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.Samples.Clear();
                obj.Samples.AddRange(SamplesAccessor.SelectDetailList(manager
                    
                    , obj.idfCase
                    ));
                obj.Samples.ForEach(c => c.m_ObjectName = _str_Samples);
                obj.Samples.AcceptChanges();
                    
            }
            
            internal void _LoadAntimicrobialTherapy(HumanCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadAntimicrobialTherapy(manager, obj);
                }
            }
            internal void _LoadAntimicrobialTherapy(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.AntimicrobialTherapy.Clear();
                obj.AntimicrobialTherapy.AddRange(AntimicrobialTherapyAccessor.SelectDetailList(manager
                    
                    , obj.idfCase
                    ));
                obj.AntimicrobialTherapy.ForEach(c => c.m_ObjectName = _str_AntimicrobialTherapy);
                obj.AntimicrobialTherapy.AcceptChanges();
                    
            }
            
            internal void _LoadDiagnosisHistory(HumanCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadDiagnosisHistory(manager, obj);
                }
            }
            internal void _LoadDiagnosisHistory(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.DiagnosisHistory.Clear();
                obj.DiagnosisHistory.AddRange(DiagnosisHistoryAccessor.SelectDetailList(manager
                    
                    , obj.idfCase
                    ));
                obj.DiagnosisHistory.ForEach(c => c.m_ObjectName = _str_DiagnosisHistory);
                obj.DiagnosisHistory.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, HumanCase obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadPointGeoLocation(manager, obj);
                _LoadFFPresenterCs(manager, obj);
                _LoadFFPresenterEpi(manager, obj);
                _LoadPatient(manager, obj);
                _LoadRegistrationAddress(manager, obj);
                _LoadCaseTests(manager, obj);
                _LoadCaseTestValidations(manager, obj);
                _LoadContactedPerson(manager, obj);
                _LoadSamples(manager, obj);
                _LoadAntimicrobialTherapy(manager, obj);
                _LoadDiagnosisHistory(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.TestsConducted = new Func<HumanCase, BaseReference>(c => (c.blnEnableTestsConducted == null || c.blnEnableTestsConducted.Value || c.TestsConductedLookup == null || c.blnEnableTestsConductedCalc) ? c.TestsConducted : c.TestsConductedLookup.Where(i => i.idfsBaseReference == (long)YesNoUnknownValuesEnum.Yes).SingleOrDefault())(obj);
                obj.CaseTests.ForEach(t => { t.idfTesting = new Func<HumanCase, long>(c => { (t.GetAccessor() as CaseTest.Accessor).LoadLookup_TestTypeRef(manager, t); return t.idfTesting; })(obj); } );
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerCaseTests(obj);
                
                _SetupAddChildHandlerCaseTestValidations(obj);
                
                _SetupAddChildHandlerContactedPerson(obj);
                
                _SetupAddChildHandlerSamples(obj);
                
                _SetupAddChildHandlerAntimicrobialTherapy(obj);
                
                _SetupAddChildHandlerDiagnosisHistory(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, HumanCase obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    PointGeoLocationAccessor._SetPermitions(obj._permissions, obj.PointGeoLocation);
                    FFPresenterCsAccessor._SetPermitions(obj._permissions, obj.FFPresenterCs);
                    FFPresenterEpiAccessor._SetPermitions(obj._permissions, obj.FFPresenterEpi);
                    PatientAccessor._SetPermitions(obj._permissions, obj.Patient);
                    RegistrationAddressAccessor._SetPermitions(obj._permissions, obj.RegistrationAddress);
                    
                        obj.CaseTests.ForEach(c => CaseTestsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.CaseTestValidations.ForEach(c => CaseTestValidationsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.ContactedPerson.ForEach(c => ContactedPersonAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Samples.ForEach(c => SamplesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.AntimicrobialTherapy.ForEach(c => AntimicrobialTherapyAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.DiagnosisHistory.ForEach(c => DiagnosisHistoryAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private HumanCase _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    HumanCase obj = HumanCase.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfCase = (new GetNewIDExtender<HumanCase>()).GetScalar(manager, obj);
                obj.idfEpiObservation = (new GetNewIDExtender<HumanCase>()).GetScalar(manager, obj);
                obj.idfCSObservation = (new GetNewIDExtender<HumanCase>()).GetScalar(manager, obj);
                obj.strCaseID = new Func<HumanCase, string>(c => string.Empty)(obj);
                obj.idfsSite = (new GetSiteIDExtender<HumanCase>()).GetScalar(manager, obj);
                obj.Patient = new Func<HumanCase, Patient>(c => PatientAccessor.Create(manager, c, c.idfCase))(obj);
                obj.Patient.idfRootHuman = (new GetNewIDExtender<HumanCase>()).GetScalar(manager, obj);
                obj.RegistrationAddress = new Func<HumanCase, Address>(c => c.Patient.RegistrationAddress)(obj);
                obj.PointGeoLocation = new Func<HumanCase, GeoLocation>(c => PointGeoLocationAccessor.CreateWithoutCountry(manager, c))(obj);
                obj.datEnteredDate = new Func<HumanCase, DateTime?>(c => DateTime.Now)(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerCaseTests(obj);
                    
                    _SetupAddChildHandlerCaseTestValidations(obj);
                    
                    _SetupAddChildHandlerContactedPerson(obj);
                    
                    _SetupAddChildHandlerSamples(obj);
                    
                    _SetupAddChildHandlerAntimicrobialTherapy(obj);
                    
                    _SetupAddChildHandlerDiagnosisHistory(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.CaseProgressStatus = new Func<HumanCase, BaseReference>(c => c.CaseProgressStatusLookup.Where(l => l.idfsBaseReference == (long)CaseStatusEnum.InProgress).SingleOrDefault())(obj);
                obj.strPersonEnteredBy = new Func<HumanCase, string>(c => EidssUserContext.User.FullName)(obj);
                        if (EidssUserContext.Instance != null)
                          if (EidssUserContext.User != null)
                          {                             
                            if (EidssUserContext.User.EmployeeID != null)
                            {
                              long em;
                              if (long.TryParse(EidssUserContext.User.EmployeeID.ToString(), out em))
                              obj.idfPersonEnteredBy = em;
                            }
                          }                        
                      
                      var accFF = FFPresenterModel.Accessor.Instance(null);
                      obj.FFPresenterCs = accFF.SelectByKey(manager, obj.idfCSObservation);
                      obj.FFPresenterCs.SetProperties(EidssSiteContext.Instance.CountryID, null, FFTypeEnum.HumanClinicalSigns, obj.idfCSObservation.Value);
                      obj.FFPresenterEpi = accFF.SelectByKey(manager, obj.idfEpiObservation);
                      obj.FFPresenterEpi.SetProperties(EidssSiteContext.Instance.CountryID, null, FFTypeEnum.HumanEpiInvestigations, obj.idfEpiObservation.Value);
                    
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

            
            public HumanCase CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public HumanCase CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult CreateGeoLocation(DbManagerProxy manager, HumanCase obj, List<object> pars)
            {
                
                return CreateGeoLocation(manager, obj
                    );
            }
            public ActResult CreateGeoLocation(DbManagerProxy manager, HumanCase obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("CreateGeoLocation"))
                    throw new PermissionException("HumanCase", "CreateGeoLocation");
                
                  if (obj.PointGeoLocation.IsNull)
                  {
                    obj.PointGeoLocation.Country = obj.Patient.CurrentResidenceAddress.Country;
                    obj.PointGeoLocation.Region = obj.Patient.CurrentResidenceAddress.Region;
                    obj.PointGeoLocation.Rayon = obj.Patient.CurrentResidenceAddress.Rayon;
                  }
                  return true;
                
            }
            
            public ActResult EmergencyNotificationReport(DbManagerProxy manager, HumanCase obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("id", typeof(long));
                
                return EmergencyNotificationReport(manager, obj
                    , (long)pars[0]
                    );
            }
            public ActResult EmergencyNotificationReport(DbManagerProxy manager, HumanCase obj
                , long id
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("EmergencyNotificationReport"))
                    throw new PermissionException("HumanCase", "EmergencyNotificationReport");
                
                return true;
                
            }
            
            public ActResult HumanInvestigationReport(DbManagerProxy manager, HumanCase obj, List<object> pars)
            {
                
                if (pars.Count != 4) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("caseId", typeof(long));
                if (pars[1] != null && !(pars[1] is long)) 
                    throw new TypeMismatchException("epiId", typeof(long));
                if (pars[2] != null && !(pars[2] is long)) 
                    throw new TypeMismatchException("csId", typeof(long));
                if (pars[3] != null && !(pars[3] is long)) 
                    throw new TypeMismatchException("diagnosisId", typeof(long));
                
                return HumanInvestigationReport(manager, obj
                    , (long)pars[0]
                    , (long)pars[1]
                    , (long)pars[2]
                    , (long)pars[3]
                    );
            }
            public ActResult HumanInvestigationReport(DbManagerProxy manager, HumanCase obj
                , long caseId
                , long epiId
                , long csId
                , long diagnosisId
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("HumanInvestigationReport"))
                    throw new PermissionException("HumanCase", "HumanInvestigationReport");
                
                return true;
                
            }
            
            private void _SetupChildHandlers(HumanCase obj, object newobj)
            {
                
                foreach(var o in obj.ContactedPerson.Where(c => !c.IsMarkedToDelete))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "")
                                {
                                
                (new PredicateValidator("mbDuplicateContact", "", "ContactedPerson", "",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => c.ContactedPerson.Count(j => 
                        !j.IsMarkedToDelete 
                        && j.idfContactedCasePerson != i.idfContactedCasePerson
                        && j.Person.strFirstName == i.Person.strFirstName
                        && j.Person.strLastName == i.Person.strLastName
                        && j.Person.strSecondName == i.Person.strSecondName
                        && j.Person.datDateofBirth == i.Person.datDateofBirth
                        && j.Person.idfsHumanGender == i.Person.idfsHumanGender
                        && j.Person.CurrentResidenceAddress.idfsCountry == i.Person.CurrentResidenceAddress.idfsCountry
                        && j.Person.CurrentResidenceAddress.idfsRegion == i.Person.CurrentResidenceAddress.idfsRegion
                        && j.Person.CurrentResidenceAddress.idfsRayon == i.Person.CurrentResidenceAddress.idfsRayon
                        && j.Person.CurrentResidenceAddress.idfsSettlement == i.Person.CurrentResidenceAddress.idfsSettlement
                        && j.Person.CurrentResidenceAddress.strStreetName == i.Person.CurrentResidenceAddress.strStreetName
                        && j.Person.CurrentResidenceAddress.strPostCode == i.Person.CurrentResidenceAddress.strPostCode
                        && j.Person.CurrentResidenceAddress.strBuilding == i.Person.CurrentResidenceAddress.strBuilding
                        && j.Person.CurrentResidenceAddress.strApartment == i.Person.CurrentResidenceAddress.strApartment
                        && j.Person.CurrentResidenceAddress.strHouse == i.Person.CurrentResidenceAddress.strHouse
                        ) == 0
                    );
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("");
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                }
                            
                    if (newobj == null)
                    {
                        var o = obj.Patient;
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "datDateofBirth")
                                {
                                
                (new PredicateValidator("Date of Birth_Current date", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, DateTime.Now)
                    );
            
                (new PredicateValidator("Date of Birth_Notification date", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datNotificationDate)
                    );
            
                (new PredicateValidator("Date of Birth_Diagnosis date", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datTentativeDiagnosisDate)
                    );
            
                (new PredicateValidator("Date of Birth_Date of changed diagnosis", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datFinalDiagnosisDate)
                    );
            
                (new PredicateValidator("Date of Birth_Date Entered", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datEnteredDate)
                    );
            
                (new PredicateValidator("Date of Birth_Sample Collection Date", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(i.datDateofBirth, a.datFieldCollectionDate)).Count() == c.Samples.Count(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown)
                    );
            
                (new PredicateValidator("Date of Birth_Sample sent date", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(i.datDateofBirth, a.datFieldSentDate)).Count() == c.Samples.Count(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown)
                    );
            
                (new PredicateValidator("Date of Birth_Accession Date", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(i.datDateofBirth, a.datAccession)).Count() == c.Samples.Count(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown)
                    );
            
                (new PredicateValidator("Date of Birth_Date of last visit to employer, school, children's facility", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datFacilityLastVisit)
                    );
            
                (new PredicateValidator("Date of Birth_Date of last contact", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => c.ContactedPerson.Where(a => PredicateValidator.CompareDates(i.datDateofBirth, a.datDateOfLastContact)).Count() == c.ContactedPerson.Count()
                    );
            
                (new PredicateValidator("Date of Birth_Date of hospitalization", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datHospitalizationDate)
                    );
            
                (new PredicateValidator("Date of Birth_Date of patient first sought care", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datFirstSoughtCareDate)
                    );
            
                (new PredicateValidator("Date of Birth_Date of symptoms onset", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datOnSetDate)
                    );
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datDateofBirth");
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                            
                foreach(var o in obj.Samples.Where(c => !c.IsMarkedToDelete && c.idfsSpecimenType != (long)SampleTypeEnum.Unknown))
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
                                
                (new PredicateValidator("Date of Birth_Sample Collection Date", "datFieldCollectionDate", "Samples", "datFieldCollectionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.Patient.datDateofBirth, i.datFieldCollectionDate)
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
                            
                foreach(var o in obj.Samples.Where(c => !c.IsMarkedToDelete && c.idfsSpecimenType != (long)SampleTypeEnum.Unknown))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "datFieldSentDate")
                                {
                                
                (new PredicateValidator("Date of Birth_Sample sent date", "datFieldSentDate", "Samples", "datFieldSentDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.Patient.datDateofBirth, i.datFieldSentDate)
                    );
            
                (new PredicateValidator("Date of symptoms onset_Sample Sent Date", "datFieldSentDate", "Samples", "datFieldSentDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.datOnSetDate, i.datFieldSentDate)
                    );
            
                (new PredicateValidator("Diagnosis date_Sample sent date", "datFieldSentDate", "Samples", "datFieldSentDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, i.datFieldSentDate)
                    );
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datFieldSentDate");
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                }
                            
                foreach(var o in obj.Samples.Where(c => !c.IsMarkedToDelete && c.idfsSpecimenType != (long)SampleTypeEnum.Unknown))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "datAccession")
                                {
                                
                (new PredicateValidator("Date of Birth_Accession Date", "datAccession", "Samples", "datAccession",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.Patient.datDateofBirth, i.datAccession)
                    );
            
                (new PredicateValidator("Date of symptoms onset_Accession Date", "datAccession", "Samples", "datAccession",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.datOnSetDate, i.datAccession)
                    );
            
                (new PredicateValidator("Diagnosis date_Accession Date", "datAccession", "Samples", "datAccession",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, i.datAccession)
                    );
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datAccession");
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                }
                            
                foreach(var o in obj.Samples.Where(c => !c.IsMarkedToDelete && c.idfsSpecimenType != (long)SampleTypeEnum.Unknown))
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
                                
                (new PredicateValidator("Date of symptoms onset_Sample Collection Date", "datFieldCollectionDate", "Samples", "datFieldCollectionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.datOnSetDate, i.datFieldCollectionDate)
                    );
            
                (new PredicateValidator("Diagnosis date_Sample Collection Date", "datFieldCollectionDate", "Samples", "datFieldCollectionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, i.datFieldCollectionDate)
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
                            
                foreach(var o in obj.ContactedPerson.Where(c => !c.IsMarkedToDelete))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "datDateOfLastContact")
                                {
                                
                (new PredicateValidator("Date of Birth_Date of last contact", "datDateOfLastContact", "ContactedPerson", "datDateOfLastContact",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.Patient.datDateofBirth, i.datDateOfLastContact)
                    );
            
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datDateOfLastContact");
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        
                    }
                }
                            
                    if (newobj == null)
                    {
                        var o = obj.Patient;
                            
                        var item = o;
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "datDateofBirth")
                            {
                            
                obj.Patient.intPatientAgeFromCase = new Func<HumanCase, int?>(c => c.CalcPatientAge())(obj);
                            }
                        };
                        
                    }
                            
                    if (newobj == null)
                    {
                        var o = obj.Patient;
                            
                        var item = o;
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "datDateofBirth")
                            {
                            
                obj.Patient.HumanAgeType = new Func<HumanCase, BaseReference>(c => c.Patient.HumanAgeTypeLookup.Where(a => a.idfsBaseReference == c.CalcPatientAgeType()).SingleOrDefault())(obj);
                            }
                        };
                        
                    }
                            
                    if (newobj == null)
                    {
                        var o = obj.Patient;
                            
                        var item = o;
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "idfsHumanAgeTypeFromCase")
                            {
                            
                obj.Patient.intPatientAgeFromCase = new Func<HumanCase, int?>(c => c.Patient.idfsHumanAgeTypeFromCase == null ? c.Patient.intPatientAgeFromCase : 
                                    ((c.Patient.idfsHumanAgeTypeFromCase == (long)HumanAgeTypeEnum.Years && c.Patient.intPatientAgeFromCase > 200) ? 200 :
                                    ((c.Patient.idfsHumanAgeTypeFromCase == (long)HumanAgeTypeEnum.Month && c.Patient.intPatientAgeFromCase > 60) ? 60 :
                                    ((c.Patient.idfsHumanAgeTypeFromCase == (long)HumanAgeTypeEnum.Days && c.Patient.intPatientAgeFromCase > 31) ? 31 :
                                    c.Patient.intPatientAgeFromCase)))
                                    )(obj);
                            }
                        };
                        
                    }
                            
            }
            
            private void _SetupHandlers(HumanCase obj)
            {
                
                obj.AntimicrobialTherapy.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    if (e.ListChangedType == ListChangedType.ItemAdded)
                    {
                        try
                        {
                            for (int index = 0; index < obj.AntimicrobialTherapy.Count; index++)
                            {
                                if (index != e.NewIndex)
                                {
                                    var item = obj.AntimicrobialTherapy[index];
                        
                (new RequiredValidator( "strAntimicrobialTherapyName", "strAntimicrobialTherapyName","",
                false
              )).Validate(c => true, item, item.strAntimicrobialTherapyName);
            
                                }
                            }
                        }
                        catch (ValidationModelException ex)
                        {
                            if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                            {
                                obj.AntimicrobialTherapy.RemoveAt(e.NewIndex);
                                obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                            }
                        }
                    }
                };
                    
                obj.Samples.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    if (e.ListChangedType == ListChangedType.ItemAdded)
                    {
                        try
                        {
                            for (int index = 0; index < obj.Samples.Count; index++)
                            {
                                if (index != e.NewIndex)
                                {
                                    var item = obj.Samples[index];
                        
                (new RequiredValidator( "idfsSpecimenType", "idfsSpecimenType","",
                false
              )).Validate(c => true, item, item.idfsSpecimenType);
            
                                }
                            }
                        }
                        catch (ValidationModelException ex)
                        {
                            if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                            {
                                obj.Samples.RemoveAt(e.NewIndex);
                                obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                            }
                        }
                    }
                };
                    
                obj.ContactedPerson.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    if (e.ListChangedType == ListChangedType.ItemAdded)
                    {
                        try
                        {
                            for (int index = 0; index < obj.ContactedPerson.Count; index++)
                            {
                                if (index != e.NewIndex)
                                {
                                    var item = obj.ContactedPerson[index];
                        
                (new RequiredValidator( "Person.strLastName", "Person.strLastName","",
                false
              )).Validate(c => true, item, item.Person.strLastName);
            
                                }
                            }
                        }
                        catch (ValidationModelException ex)
                        {
                            if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                            {
                                obj.ContactedPerson.RemoveAt(e.NewIndex);
                                obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                            }
                        }
                    }
                };
                    
                obj.CaseTests.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    
                obj.TestsConducted = new Func<HumanCase, BaseReference>(c => (c.CaseTests.Count(i => !i.IsMarkedToDelete) == 0) ? c.TestsConducted : c.TestsConductedLookup.Where(i => i.idfsBaseReference == (long)YesNoUnknownValuesEnum.Yes).SingleOrDefault())(obj);
                };
                    
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsFinalDiagnosis)
                        {
                            try
                            {
                            
                (new PredicateValidator("idfsFinalDiagnosis_idfsTentativeDiagnosis_msgId", "idfsFinalDiagnosis", "idfsFinalDiagnosis", "idfsFinalDiagnosis",
              new object[] {
              },
                        false
                    )).Validate(obj, c => !c.idfsTentativeDiagnosis.HasValue || !c.idfsFinalDiagnosis.HasValue || (c.idfsTentativeDiagnosis.HasValue && c.idfsFinalDiagnosis.HasValue && c.idfsFinalDiagnosis != c.idfsTentativeDiagnosis)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_idfsFinalDiagnosis);
                                    obj._FinalDiagnosis = obj.FinalDiagnosisLookup.Where(a => a.idfsDiagnosis == obj.idfsFinalDiagnosis).SingleOrDefault();
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_idfsTentativeDiagnosis)
                        {
                            try
                            {
                            
                (new PredicateValidator("idfsFinalDiagnosis_idfsTentativeDiagnosis_msgId", "idfsTentativeDiagnosis", "idfsTentativeDiagnosis", "idfsTentativeDiagnosis",
              new object[] {
              },
                        false
                    )).Validate(obj, c => !c.idfsTentativeDiagnosis.HasValue || !c.idfsFinalDiagnosis.HasValue || (c.idfsTentativeDiagnosis.HasValue && c.idfsFinalDiagnosis.HasValue && c.idfsFinalDiagnosis != c.idfsTentativeDiagnosis)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_idfsTentativeDiagnosis);
                                    obj._TentativeDiagnosis = obj.TentativeDiagnosisLookup.Where(a => a.idfsDiagnosis == obj.idfsTentativeDiagnosis).SingleOrDefault();
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_idfsYNHospitalization)
                        {
                            try
                            {
                            
                (new PredicateValidator("mbSureToDisableHosp", "idfsYNHospitalization", "idfsYNHospitalization", "idfsYNHospitalization",
              new object[] {
              },
                        true
                    )).Validate(obj, c => !((c.Hospitalization == null || c.idfsYNHospitalization != (long)YesNoUnknownValuesEnum.Yes)
                                            && (c.datHospitalizationDate != null || !string.IsNullOrEmpty(c.strHospitalizationPlace)))
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_idfsYNHospitalization);
                                    obj._Hospitalization = obj.HospitalizationLookup.Where(a => a.idfsBaseReference == obj.idfsYNHospitalization).SingleOrDefault();
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_idfsYNAntimicrobialTherapy)
                        {
                            try
                            {
                            
                (new PredicateValidator("mbCannotDeleteAllAntibiotics", "idfsYNAntimicrobialTherapy", "idfsYNAntimicrobialTherapy", "idfsYNAntimicrobialTherapy",
              new object[] {
              },
                        false
                    )).Validate(obj, c => !((c.AntimicrobialTherapyUsed == null || c.idfsYNAntimicrobialTherapy != (long)YesNoUnknownValuesEnum.Yes)
                                            && (c.AntimicrobialTherapy.Where(s => !s.IsMarkedToDelete).Count() > 0))
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_idfsYNAntimicrobialTherapy);
                                    obj._AntimicrobialTherapyUsed = obj.AntimicrobialTherapyUsedLookup.Where(a => a.idfsBaseReference == obj.idfsYNAntimicrobialTherapy).SingleOrDefault();
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_idfsYNSpecimenCollected)
                        {
                            try
                            {
                            
                (new PredicateValidator("mbCannotDeleteAllSpecimens", "idfsYNSpecimenCollected", "idfsYNSpecimenCollected", "idfsYNSpecimenCollected",
              new object[] {
              },
                        false
                    )).Validate(obj, c => !((c.SpecimenCollected == null || c.idfsYNSpecimenCollected != (long)YesNoUnknownValuesEnum.Yes)
                                            && (c.Samples.Where(s => !s.IsMarkedToDelete && s.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count() > 0))
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_idfsYNSpecimenCollected);
                                    obj._SpecimenCollected = obj.SpecimenCollectedLookup.Where(a => a.idfsBaseReference == obj.idfsYNSpecimenCollected).SingleOrDefault();
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datNotificationDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of Birth_Notification date", "datNotificationDate", "datNotificationDate", "datNotificationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datNotificationDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datNotificationDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datTentativeDiagnosisDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of Birth_Diagnosis date", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datTentativeDiagnosisDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTentativeDiagnosisDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datFinalDiagnosisDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of Birth_Date of changed diagnosis", "datFinalDiagnosisDate", "datFinalDiagnosisDate", "datFinalDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datFinalDiagnosisDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFinalDiagnosisDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datFacilityLastVisit)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of Birth_Date of last visit to employer, school, children's facility", "datFacilityLastVisit", "datFacilityLastVisit", "datFacilityLastVisit",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datFacilityLastVisit)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFacilityLastVisit);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datNotificationDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Notification date_Date Entered", "datNotificationDate", "datNotificationDate", "datNotificationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datNotificationDate, c.datEnteredDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datNotificationDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datOnSetDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of symptoms onset_Date Entered", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datEnteredDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datOnSetDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datTentativeDiagnosisDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Diagnosis date_Date Entered", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datEnteredDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTentativeDiagnosisDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datNotificationDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Notification date_Current date", "datNotificationDate", "datNotificationDate", "datNotificationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datNotificationDate, DateTime.Now)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datNotificationDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datTentativeDiagnosisDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Diagnosis date_Notification date", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datNotificationDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTentativeDiagnosisDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datNotificationDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Diagnosis date_Notification date", "datNotificationDate", "datNotificationDate", "datNotificationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datNotificationDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datNotificationDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datOnSetDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of symptoms onset_Current date", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, DateTime.Now)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datOnSetDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datOnSetDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of symptoms onset_Diagnosis date", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datTentativeDiagnosisDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datOnSetDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datTentativeDiagnosisDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of symptoms onset_Diagnosis date", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datTentativeDiagnosisDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTentativeDiagnosisDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datOnSetDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of symptoms onset_Date of changed diagnosis", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datFinalDiagnosisDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datOnSetDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datFinalDiagnosisDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of symptoms onset_Date of changed diagnosis", "datFinalDiagnosisDate", "datFinalDiagnosisDate", "datFinalDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datFinalDiagnosisDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFinalDiagnosisDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datOnSetDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of symptoms onset_Sample Collection Date", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(c.datOnSetDate, a.datFieldCollectionDate)).Count() == c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count()
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datOnSetDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datOnSetDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of symptoms onset_Sample Sent Date", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(c.datOnSetDate, a.datFieldSentDate)).Count() == c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count()
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datOnSetDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datOnSetDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of symptoms onset_Accession Date", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(c.datOnSetDate, a.datAccession)).Count() == c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count()
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datOnSetDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datTentativeDiagnosisDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Diagnosis date_Date of changed diagnosis", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datFinalDiagnosisDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTentativeDiagnosisDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datFinalDiagnosisDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Diagnosis date_Date of changed diagnosis", "datFinalDiagnosisDate", "datFinalDiagnosisDate", "datFinalDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datFinalDiagnosisDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFinalDiagnosisDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datTentativeDiagnosisDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Diagnosis date_Sample Collection Date", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, a.datFieldCollectionDate)).Count() == c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count()
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTentativeDiagnosisDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datTentativeDiagnosisDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Diagnosis date_Sample sent date", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, a.datFieldSentDate)).Count() == c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count()
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTentativeDiagnosisDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datTentativeDiagnosisDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Diagnosis date_Accession Date", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, a.datAccession)).Count() == c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count()
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTentativeDiagnosisDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datHospitalizationDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of Birth_Date of hospitalization", "datHospitalizationDate", "datHospitalizationDate", "datHospitalizationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datHospitalizationDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datHospitalizationDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datFirstSoughtCareDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of Birth_Date of patient first sought care", "datFirstSoughtCareDate", "datFirstSoughtCareDate", "datFirstSoughtCareDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datFirstSoughtCareDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFirstSoughtCareDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datExposureDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of Exposure_Date of symptoms onset", "datExposureDate", "datExposureDate", "datExposureDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datExposureDate, c.datOnSetDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datExposureDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datOnSetDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of Exposure_Date of symptoms onset", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datExposureDate, c.datOnSetDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datOnSetDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datTentativeDiagnosisDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Diagnosis date_Date of completion of paper form", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datCompletionPaperFormDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTentativeDiagnosisDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datCompletionPaperFormDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Diagnosis date_Date of completion of paper form", "datCompletionPaperFormDate", "datCompletionPaperFormDate", "datCompletionPaperFormDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datCompletionPaperFormDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datCompletionPaperFormDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datCompletionPaperFormDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of completion of paper form_Notification date", "datCompletionPaperFormDate", "datCompletionPaperFormDate", "datCompletionPaperFormDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datCompletionPaperFormDate, c.datNotificationDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datCompletionPaperFormDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datNotificationDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of completion of paper form_Notification date", "datNotificationDate", "datNotificationDate", "datNotificationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datCompletionPaperFormDate, c.datNotificationDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datNotificationDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datOnSetDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of Birth_Date of symptoms onset", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datOnSetDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datOnSetDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datOnSetDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of symptoms onset_Notification date", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datNotificationDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datOnSetDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datNotificationDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("Date of symptoms onset_Notification date", "datNotificationDate", "datNotificationDate", "datNotificationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datNotificationDate)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datNotificationDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datD)
                        {
                    
                obj.Patient.intPatientAgeFromCase = new Func<HumanCase, int?>(c => c.CalcPatientAge())(obj);
                        }
                    
                        if (e.PropertyName == _str_datD)
                        {
                    
                obj.Patient.HumanAgeType = new Func<HumanCase, BaseReference>(c => c.Patient.HumanAgeTypeLookup.Where(a => a.idfsBaseReference == c.CalcPatientAgeType()).SingleOrDefault())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsHospitalizationStatus)
                        {
                    
                obj.strCurrentLocation = new Func<HumanCase, string>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsFinalDiagnosis)
                        {
                    
                obj.datFinalDiagnosisDate = new Func<HumanCase, DateTime?>(c => c.idfsFinalDiagnosis == null ? null : c.datFinalDiagnosisDate)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsFinalDiagnosis)
                        {
                    
                          if (obj.idfsFinalDiagnosis_Previous != obj.idfsFinalDiagnosis)
                          {
                              var historyItem = obj.DiagnosisHistory.Where(h => h.IsNew).SingleOrDefault();
                              if (historyItem == null)
                              {
                                  int count = obj.DiagnosisHistory.Count;
                                  if (count == 0 || count > 0 && obj.idfsFinalDiagnosis_Previous.HasValue || count > 0 && !obj.idfsFinalDiagnosis_Previous.HasValue  && obj.DiagnosisHistory[count - 1].CurrentDiagnosis == null)
                                  {
                                      using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                                      {
                                          obj.DiagnosisHistory.Add(DiagnosisHistoryAccessor.Create(manager, obj, obj.idfCase, obj.idfsFinalDiagnosis_Previous, obj.idfsFinalDiagnosis));
                                      }
                                  }
                              }
                              else
                              {
                                  historyItem.CurrentDiagnosis = obj.FinalDiagnosisLookup.Where(a => a.idfsDiagnosis == obj.idfsFinalDiagnosis).SingleOrDefault();
                              }
                          }
                        
                        }
                    
                        if (e.PropertyName == _str_idfsFinalDiagnosis)
                        {
                                              
                          obj.blnClinicalDiagBasis = null;
                          obj.blnEpiDiagBasis = null;
                          obj.blnLabDiagBasis = null;
                        
                        }
                    
                        if (e.PropertyName == _str_idfsYNHospitalization)
                        {
                    
                obj.datHospitalizationDate = new Func<HumanCase, DateTime?>(c => (c.Hospitalization == null || c.idfsYNHospitalization != (long)YesNoUnknownValuesEnum.Yes) ? null : c.datHospitalizationDate)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsYNHospitalization)
                        {
                    
                obj.strHospitalizationPlace = new Func<HumanCase, string>(c => (c.Hospitalization == null || c.idfsYNHospitalization != (long)YesNoUnknownValuesEnum.Yes) ? "" : c.strHospitalizationPlace)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsYNSpecimenCollected)
                        {
                    
                obj.idfsNotCollectedReason = new Func<HumanCase, long?>(c => (c.SpecimenCollected == null || c.idfsYNSpecimenCollected == (long)YesNoUnknownValuesEnum.Yes || c.idfsYNSpecimenCollected == (long)YesNoUnknownValuesEnum.Unknown) ? null : c.idfsNotCollectedReason)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsYNSpecimenCollected)
                        {
                    
                obj.strSampleNotes = new Func<HumanCase, string>(c => (c.SpecimenCollected == null || c.idfsYNSpecimenCollected == (long)YesNoUnknownValuesEnum.No || c.idfsYNSpecimenCollected == (long)YesNoUnknownValuesEnum.Unknown) ? "" : c.strSampleNotes)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsOutcome)
                        {
                    
                obj.datDischargeDate = new Func<HumanCase, DateTime?>(c => (c.Outcome == null || c.idfsOutcome != (long)OutcomeTypeEnum.Recovered) ? null : c.datDischargeDate)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsOutcome)
                        {
                    
                obj.datDateOfDeath = new Func<HumanCase, DateTime?>(c => (c.Outcome == null || c.idfsOutcome != (long)OutcomeTypeEnum.Died) ? null : c.datDateOfDeath)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                    
                          using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                          {
                            var idCountry = obj.Patient.CurrentResidenceAddress.idfsCountry;
                            if (idCountry.HasValue)
                            {
                              obj.FFPresenterEpi.SetProperties(FFPresenterModel.LoadActualTemplate(idCountry.Value, obj.idfsDiagnosis, FFTypeEnum.HumanEpiInvestigations));
                              obj.FFPresenterCs.SetProperties(FFPresenterModel.LoadActualTemplate(idCountry.Value, obj.idfsDiagnosis, FFTypeEnum.HumanClinicalSigns));
                              obj.idfsCSFormTemplate = obj.FFPresenterCs.CurrentTemplate.idfsFormTemplate;
                              obj.idfsEPIFormTemplate = obj.FFPresenterEpi.CurrentTemplate.idfsFormTemplate;
                            }
                          }                          
                        
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosis)
                        {
                                              
                          obj.blnClinicalDiagBasis = null;
                          obj.blnEpiDiagBasis = null;
                          obj.blnLabDiagBasis = null;
                        
                        }
                    
                        if (e.PropertyName == _str_idfSentByOffice)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_SentByPerson(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfReceivedByOffice)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_ReceivedByPerson(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfSentByOffice)
                        {
                    
                obj.SentByPerson = (new SetScalarHandler()).Handler(obj,
                    obj.idfSentByOffice, obj.idfSentByOffice_Previous, obj.SentByPerson,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfReceivedByOffice)
                        {
                    
                obj.ReceivedByPerson = (new SetScalarHandler()).Handler(obj,
                    obj.idfReceivedByOffice, obj.idfReceivedByOffice_Previous, obj.ReceivedByPerson,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                    };
                
            }
    
            public void LoadLookup_CaseProgressStatus(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.CaseProgressStatusLookup.Clear();
                
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
            
            public void LoadLookup_PatientState(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.PatientStateLookup.Clear();
                
                obj.PatientStateLookup.Add(PatientStateAccessor.CreateNewT(manager, null));
                
                obj.PatientStateLookup.AddRange(PatientStateAccessor.rftFinalState_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsFinalState))
                    
                    .ToList());
                
                if (obj.idfsFinalState != null && obj.idfsFinalState != 0)
                {
                    obj.PatientState = obj.PatientStateLookup
                        .Where(c => c.idfsBaseReference == obj.idfsFinalState)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftFinalState", obj, PatientStateAccessor.GetType(), "rftFinalState_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_PatientLocationType(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.PatientLocationTypeLookup.Clear();
                
                obj.PatientLocationTypeLookup.Add(PatientLocationTypeAccessor.CreateNewT(manager, null));
                
                obj.PatientLocationTypeLookup.AddRange(PatientLocationTypeAccessor.rftHospStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsHospitalizationStatus))
                    
                    .ToList());
                
                if (obj.idfsHospitalizationStatus != null && obj.idfsHospitalizationStatus != 0)
                {
                    obj.PatientLocationType = obj.PatientLocationTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsHospitalizationStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftHospStatus", obj, PatientLocationTypeAccessor.GetType(), "rftHospStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_AntimicrobialTherapyUsed(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.AntimicrobialTherapyUsedLookup.Clear();
                
                obj.AntimicrobialTherapyUsedLookup.Add(AntimicrobialTherapyUsedAccessor.CreateNewT(manager, null));
                
                obj.AntimicrobialTherapyUsedLookup.AddRange(AntimicrobialTherapyUsedAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNAntimicrobialTherapy))
                    
                    .ToList());
                
                if (obj.idfsYNAntimicrobialTherapy != null && obj.idfsYNAntimicrobialTherapy != 0)
                {
                    obj.AntimicrobialTherapyUsed = obj.AntimicrobialTherapyUsedLookup
                        .Where(c => c.idfsBaseReference == obj.idfsYNAntimicrobialTherapy)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, AntimicrobialTherapyUsedAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Hospitalization(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.HospitalizationLookup.Clear();
                
                obj.HospitalizationLookup.Add(HospitalizationAccessor.CreateNewT(manager, null));
                
                obj.HospitalizationLookup.AddRange(HospitalizationAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNHospitalization))
                    
                    .ToList());
                
                if (obj.idfsYNHospitalization != null && obj.idfsYNHospitalization != 0)
                {
                    obj.Hospitalization = obj.HospitalizationLookup
                        .Where(c => c.idfsBaseReference == obj.idfsYNHospitalization)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, HospitalizationAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_SpecimenCollected(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.SpecimenCollectedLookup.Clear();
                
                obj.SpecimenCollectedLookup.Add(SpecimenCollectedAccessor.CreateNewT(manager, null));
                
                obj.SpecimenCollectedLookup.AddRange(SpecimenCollectedAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNSpecimenCollected))
                    
                    .ToList());
                
                if (obj.idfsYNSpecimenCollected != null && obj.idfsYNSpecimenCollected != 0)
                {
                    obj.SpecimenCollected = obj.SpecimenCollectedLookup
                        .Where(c => c.idfsBaseReference == obj.idfsYNSpecimenCollected)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, SpecimenCollectedAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_RelatedToOutbreak(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.RelatedToOutbreakLookup.Clear();
                
                obj.RelatedToOutbreakLookup.Add(RelatedToOutbreakAccessor.CreateNewT(manager, null));
                
                obj.RelatedToOutbreakLookup.AddRange(RelatedToOutbreakAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNRelatedToOutbreak))
                    
                    .ToList());
                
                if (obj.idfsYNRelatedToOutbreak != null && obj.idfsYNRelatedToOutbreak != 0)
                {
                    obj.RelatedToOutbreak = obj.RelatedToOutbreakLookup
                        .Where(c => c.idfsBaseReference == obj.idfsYNRelatedToOutbreak)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, RelatedToOutbreakAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_TestsConducted(DbManagerProxy manager, HumanCase obj)
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
                        .Where(c => c.idfsBaseReference == obj.idfsYNTestsConducted)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, TestsConductedAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Outcome(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.OutcomeLookup.Clear();
                
                obj.OutcomeLookup.Add(OutcomeAccessor.CreateNewT(manager, null));
                
                obj.OutcomeLookup.AddRange(OutcomeAccessor.rftOutcome_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsOutcome))
                    
                    .ToList());
                
                if (obj.idfsOutcome != null && obj.idfsOutcome != 0)
                {
                    obj.Outcome = obj.OutcomeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsOutcome)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftOutcome", obj, OutcomeAccessor.GetType(), "rftOutcome_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_TentativeDiagnosis(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.TentativeDiagnosisLookup.Clear();
                
                obj.TentativeDiagnosisLookup.Add(TentativeDiagnosisAccessor.CreateNewT(manager, null));
                
                obj.TentativeDiagnosisLookup.AddRange(TentativeDiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Human) != 0) || c.idfsDiagnosis == obj.idfsTentativeDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsTentativeDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsTentativeDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsTentativeDiagnosis != null && obj.idfsTentativeDiagnosis != 0)
                {
                    obj.TentativeDiagnosis = obj.TentativeDiagnosisLookup
                        .Where(c => c.idfsDiagnosis == obj.idfsTentativeDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, TentativeDiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_FinalDiagnosis(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.FinalDiagnosisLookup.Clear();
                
                obj.FinalDiagnosisLookup.Add(FinalDiagnosisAccessor.CreateNewT(manager, null));
                
                obj.FinalDiagnosisLookup.AddRange(FinalDiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Human) != 0) || c.idfsDiagnosis == obj.idfsFinalDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsFinalDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsFinalDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsFinalDiagnosis != null && obj.idfsFinalDiagnosis != 0)
                {
                    obj.FinalDiagnosis = obj.FinalDiagnosisLookup
                        .Where(c => c.idfsDiagnosis == obj.idfsFinalDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, FinalDiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_InitialCaseStatus(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.InitialCaseStatusLookup.Clear();
                
                obj.InitialCaseStatusLookup.Add(InitialCaseStatusAccessor.CreateNewT(manager, null));
                
                obj.InitialCaseStatusLookup.AddRange(InitialCaseStatusAccessor.rftCaseStatus_SelectList(manager
                    
                    )
                    .Where(c => c.intHACode.GetValueOrDefault() == 98)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsInitialCaseStatus))
                    
                    .ToList());
                
                if (obj.idfsInitialCaseStatus != null && obj.idfsInitialCaseStatus != 0)
                {
                    obj.InitialCaseStatus = obj.InitialCaseStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsInitialCaseStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCaseStatus", obj, InitialCaseStatusAccessor.GetType(), "rftCaseStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_NonNotifiableDiagnosis(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.NonNotifiableDiagnosisLookup.Clear();
                
                obj.NonNotifiableDiagnosisLookup.Add(NonNotifiableDiagnosisAccessor.CreateNewT(manager, null));
                
                obj.NonNotifiableDiagnosisLookup.AddRange(NonNotifiableDiagnosisAccessor.rftNonNotifiableDiagnosis_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsNonNotifiableDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsNonNotifiableDiagnosis != null && obj.idfsNonNotifiableDiagnosis != 0)
                {
                    obj.NonNotifiableDiagnosis = obj.NonNotifiableDiagnosisLookup
                        .Where(c => c.idfsBaseReference == obj.idfsNonNotifiableDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftNonNotifiableDiagnosis", obj, NonNotifiableDiagnosisAccessor.GetType(), "rftNonNotifiableDiagnosis_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_FinalCaseStatus(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.FinalCaseStatusLookup.Clear();
                
                obj.FinalCaseStatusLookup.Add(FinalCaseStatusAccessor.CreateNewT(manager, null));
                
                obj.FinalCaseStatusLookup.AddRange(FinalCaseStatusAccessor.rftCaseStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode.GetValueOrDefault() & (int)HACode.Human) != 0)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsFinalCaseStatus))
                    
                    .ToList());
                
                if (obj.idfsFinalCaseStatus != null && obj.idfsFinalCaseStatus != 0)
                {
                    obj.FinalCaseStatus = obj.FinalCaseStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsFinalCaseStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCaseStatus", obj, FinalCaseStatusAccessor.GetType(), "rftCaseStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_OccupationType(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.OccupationTypeLookup.Clear();
                
                obj.OccupationTypeLookup.Add(OccupationTypeAccessor.CreateNewT(manager, null));
                
                obj.OccupationTypeLookup.AddRange(OccupationTypeAccessor.rftOccupationType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsOccupationType))
                    
                    .ToList());
                
                if (obj.idfsOccupationType != null && obj.idfsOccupationType != 0)
                {
                    obj.OccupationType = obj.OccupationTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsOccupationType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftOccupationType", obj, OccupationTypeAccessor.GetType(), "rftOccupationType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_NotCollectedReason(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.NotCollectedReasonLookup.Clear();
                
                obj.NotCollectedReasonLookup.Add(NotCollectedReasonAccessor.CreateNewT(manager, null));
                
                obj.NotCollectedReasonLookup.AddRange(NotCollectedReasonAccessor.rftNotCollectedReason_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsNotCollectedReason))
                    
                    .ToList());
                
                if (obj.idfsNotCollectedReason != null && obj.idfsNotCollectedReason != 0)
                {
                    obj.NotCollectedReason = obj.NotCollectedReasonLookup
                        .Where(c => c.idfsBaseReference == obj.idfsNotCollectedReason)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftNotCollectedReason", obj, NotCollectedReasonAccessor.GetType(), "rftNotCollectedReason_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_SentByOffice(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.SentByOfficeLookup.Clear();
                
                obj.SentByOfficeLookup.Add(SentByOfficeAccessor.CreateNewT(manager, null));
                
                obj.SentByOfficeLookup.AddRange(SentByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfSentByOffice))
                    
                    .ToList());
                
                if (obj.idfSentByOffice != null && obj.idfSentByOffice != 0)
                {
                    obj.SentByOffice = obj.SentByOfficeLookup
                        .Where(c => c.idfInstitution == obj.idfSentByOffice)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("OrganizationLookup", obj, SentByOfficeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_ReceivedByOffice(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.ReceivedByOfficeLookup.Clear();
                
                obj.ReceivedByOfficeLookup.Add(ReceivedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.ReceivedByOfficeLookup.AddRange(ReceivedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfReceivedByOffice))
                    
                    .ToList());
                
                if (obj.idfReceivedByOffice != null && obj.idfReceivedByOffice != 0)
                {
                    obj.ReceivedByOffice = obj.ReceivedByOfficeLookup
                        .Where(c => c.idfInstitution == obj.idfReceivedByOffice)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("OrganizationLookup", obj, ReceivedByOfficeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_SentByPerson(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.SentByPersonLookup.Clear();
                
                obj.SentByPersonLookup.Add(SentByPersonAccessor.CreateNewT(manager, null));
                
                obj.SentByPersonLookup.AddRange(SentByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<HumanCase, long>(c => c.idfSentByOffice ?? -1)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfSentByPerson))
                    
                    .ToList());
                
                if (obj.idfSentByPerson != null && obj.idfSentByPerson != 0)
                {
                    obj.SentByPerson = obj.SentByPersonLookup
                        .Where(c => c.idfPerson == obj.idfSentByPerson)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("WiderPersonLookup", obj, SentByPersonAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_ReceivedByPerson(DbManagerProxy manager, HumanCase obj)
            {
                
                obj.ReceivedByPersonLookup.Clear();
                
                obj.ReceivedByPersonLookup.Add(ReceivedByPersonAccessor.CreateNewT(manager, null));
                
                obj.ReceivedByPersonLookup.AddRange(ReceivedByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<HumanCase, long>(c => c.idfReceivedByOffice ?? -1)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfReceivedByPerson))
                    
                    .ToList());
                
                if (obj.idfReceivedByPerson != null && obj.idfReceivedByPerson != 0)
                {
                    obj.ReceivedByPerson = obj.ReceivedByPersonLookup
                        .Where(c => c.idfPerson == obj.idfReceivedByPerson)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("WiderPersonLookup", obj, ReceivedByPersonAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, HumanCase obj)
            {
                
                LoadLookup_CaseProgressStatus(manager, obj);
                
                LoadLookup_PatientState(manager, obj);
                
                LoadLookup_PatientLocationType(manager, obj);
                
                LoadLookup_AntimicrobialTherapyUsed(manager, obj);
                
                LoadLookup_Hospitalization(manager, obj);
                
                LoadLookup_SpecimenCollected(manager, obj);
                
                LoadLookup_RelatedToOutbreak(manager, obj);
                
                LoadLookup_TestsConducted(manager, obj);
                
                LoadLookup_Outcome(manager, obj);
                
                LoadLookup_TentativeDiagnosis(manager, obj);
                
                LoadLookup_FinalDiagnosis(manager, obj);
                
                LoadLookup_InitialCaseStatus(manager, obj);
                
                LoadLookup_NonNotifiableDiagnosis(manager, obj);
                
                LoadLookup_FinalCaseStatus(manager, obj);
                
                LoadLookup_OccupationType(manager, obj);
                
                LoadLookup_NotCollectedReason(manager, obj);
                
                LoadLookup_SentByOffice(manager, obj);
                
                LoadLookup_ReceivedByOffice(manager, obj);
                
                LoadLookup_SentByPerson(manager, obj);
                
                LoadLookup_ReceivedByPerson(manager, obj);
                
            }
    
            [SprocName("spHumanCase_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spHumanCase_Delete")]
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
        
            [SprocName("spHumanCase_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] HumanCase obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] HumanCase obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    HumanCase bo = obj as HumanCase;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("HumanCase", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("HumanCase", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("HumanCase", "Update");
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
                            
                            eidss.model.Enums.EventType eventType = eidss.model.Enums.EventType.NewHumanCase;
                            manager.SetEventParams("NewHumanCase", new object[] { eventType, mainObject, "" });
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeEdit;
                            
                            if (
                                    bo.idfsFinalDiagnosis != bo.idfsFinalDiagnosis_Original
                                ||
                                    bo.idfsTentativeDiagnosis != bo.idfsTentativeDiagnosis_Original
                                )
                            {
                                eidss.model.Enums.EventType eventType = eidss.model.Enums.EventType.CaseDiseaseChange;
                                manager.SetEventParams("CaseDiseaseChange", new object[] { eventType, mainObject, "" });
                            }
                            
                            if (bo.idfsCaseProgressStatus != bo.idfsCaseProgressStatus_Original)
                            {
                                eidss.model.Enums.EventType eventType = eidss.model.Enums.EventType.CaseStatusChange;
                                manager.SetEventParams("CaseStatusChange", new object[] { eventType, mainObject, "" });
                            }
                            
                        }
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoHumanCase;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbHumanCase;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as HumanCase, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, HumanCase obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.FFPresenterEpi != null)
                    {
                        obj.FFPresenterEpi.MarkToDelete();
                        if (!FFPresenterEpiAccessor.Post(manager, obj.FFPresenterEpi, true))
                            return false;
                    }
                                    
                    if (obj.FFPresenterCs != null)
                    {
                        obj.FFPresenterCs.MarkToDelete();
                        if (!FFPresenterCsAccessor.Post(manager, obj.FFPresenterCs, true))
                            return false;
                    }
                                    
                    if (obj.DiagnosisHistory != null)
                    {
                        foreach (var i in obj.DiagnosisHistory)
                        {
                            i.MarkToDelete();
                            if (!DiagnosisHistoryAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    
                    if (obj.AntimicrobialTherapy != null)
                    {
                        foreach (var i in obj.AntimicrobialTherapy)
                        {
                            i.MarkToDelete();
                            if (!AntimicrobialTherapyAccessor.Post(manager, i, true))
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
                                    
                    if (obj.Samples != null)
                    {
                        foreach (var i in obj.Samples)
                        {
                            i.MarkToDelete();
                            if (!SamplesAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    
                    if (obj.ContactedPerson != null)
                    {
                        foreach (var i in obj.ContactedPerson)
                        {
                            i.MarkToDelete();
                            if (!ContactedPersonAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    
                    if (!ValidateCanDelete(manager, obj)) return false;
                                
                    _postDeletePredicate(manager
                        , obj.idfCase
                        );
                                        
                    if (obj.PointGeoLocation != null)
                    {
                        obj.PointGeoLocation.MarkToDelete();
                        if (!PointGeoLocationAccessor.Post(manager, obj.PointGeoLocation, true))
                            return false;
                    }
                                    
                    if (obj.Patient != null)
                    {
                        obj.Patient.MarkToDelete();
                        if (!PatientAccessor.Post(manager, obj.Patient, true))
                            return false;
                    }
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                obj.strCaseID = new Func<HumanCase, DbManagerProxy, string>((c,m) => 
                        c.strCaseID != string.Empty 
                        ? c.strCaseID 
                        : m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.HumanCase, DBNull.Value, DBNull.Value)
                        .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue"))(obj, manager);
                obj.datModificationDate = new Func<HumanCase, DateTime?>(c => DateTime.Now)(obj);
                obj.intPatientAge = new Func<HumanCase, int?>(c => c.Patient.intPatientAgeFromCase)(obj);
                obj.idfsHumanAgeType = new Func<HumanCase, long?>(c => c.Patient.idfsHumanAgeTypeFromCase)(obj);
                    // posting extenters - end
            
                    if (obj.IsNew)
                    {
                        if (obj.Patient != null) // forced load potential lazy subobject for new object
                            if (!PatientAccessor.Post(manager, obj.Patient, true))
                                return false;
                    }
                    else
                    {
                        if (obj._Patient != null) // do not load lazy subobject for existing object
                            if (!PatientAccessor.Post(manager, obj.Patient, true))
                                return false;
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.PointGeoLocation != null) // forced load potential lazy subobject for new object
                            if (!PointGeoLocationAccessor.Post(manager, obj.PointGeoLocation, true))
                                return false;
                    }
                    else
                    {
                        if (obj._PointGeoLocation != null) // do not load lazy subobject for existing object
                            if (!PointGeoLocationAccessor.Post(manager, obj.PointGeoLocation, true))
                                return false;
                    }
                                    
                    if (!obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, obj);
                                    
                    if (obj.IsNew)
                    {
                        if (obj.ContactedPerson != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.ContactedPerson)
                                if (!ContactedPersonAccessor.Post(manager, i, true))
                                    return false;
                            obj.ContactedPerson.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.ContactedPerson.Remove(c));
                            obj.ContactedPerson.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._ContactedPerson != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._ContactedPerson)
                                if (!ContactedPersonAccessor.Post(manager, i, true))
                                    return false;
                            obj._ContactedPerson.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._ContactedPerson.Remove(c));
                            obj._ContactedPerson.AcceptChanges();
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
                        if (obj.AntimicrobialTherapy != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.AntimicrobialTherapy)
                                if (!AntimicrobialTherapyAccessor.Post(manager, i, true))
                                    return false;
                            obj.AntimicrobialTherapy.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.AntimicrobialTherapy.Remove(c));
                            obj.AntimicrobialTherapy.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._AntimicrobialTherapy != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._AntimicrobialTherapy)
                                if (!AntimicrobialTherapyAccessor.Post(manager, i, true))
                                    return false;
                            obj._AntimicrobialTherapy.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._AntimicrobialTherapy.Remove(c));
                            obj._AntimicrobialTherapy.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.DiagnosisHistory != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.DiagnosisHistory)
                                if (!DiagnosisHistoryAccessor.Post(manager, i, true))
                                    return false;
                            obj.DiagnosisHistory.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.DiagnosisHistory.Remove(c));
                            obj.DiagnosisHistory.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._DiagnosisHistory != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._DiagnosisHistory)
                                if (!DiagnosisHistoryAccessor.Post(manager, i, true))
                                    return false;
                            obj._DiagnosisHistory.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._DiagnosisHistory.Remove(c));
                            obj._DiagnosisHistory.AcceptChanges();
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
                        if (obj.FFPresenterCs != null) // forced load potential lazy subobject for new object
                            if (!FFPresenterCsAccessor.Post(manager, obj.FFPresenterCs, true))
                                return false;
                    }
                    else
                    {
                        if (obj._FFPresenterCs != null) // do not load lazy subobject for existing object
                            if (!FFPresenterCsAccessor.Post(manager, obj.FFPresenterCs, true))
                                return false;
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.FFPresenterEpi != null) // forced load potential lazy subobject for new object
                            if (!FFPresenterEpiAccessor.Post(manager, obj.FFPresenterEpi, true))
                                return false;
                    }
                    else
                    {
                        if (obj._FFPresenterEpi != null) // do not load lazy subobject for existing object
                            if (!FFPresenterEpiAccessor.Post(manager, obj.FFPresenterEpi, true))
                                return false;
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                obj.OnPropertyChanged(_str_IsClosed);
                
                return true;
            }
            
            public bool ValidateCanDelete(HumanCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, HumanCase obj)
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
                return Validate(manager, obj as HumanCase, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, HumanCase obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsCaseProgressStatus", "CaseProgressStatus","",
                false
              )).Validate(c => true, obj, obj.idfsCaseProgressStatus);
            
                (new RequiredValidator( "idfsTentativeDiagnosis", "TentativeDiagnosis","",
                false
              )).Validate(c => true, obj, obj.idfsTentativeDiagnosis);
            
                (new RequiredValidator( "Patient.strLastName", "Patient.strLastName","",
                false
              )).Validate(c => true, obj, obj.Patient.strLastName);
            
                (new RequiredValidator( "Patient.CurrentResidenceAddress.idfsCountry", "Patient.CurrentResidenceAddress.Country","",
                false
              )).Validate(c => true, obj, obj.Patient.CurrentResidenceAddress.idfsCountry);
            
                (new RequiredValidator( "Patient.CurrentResidenceAddress.idfsRegion", "Patient.CurrentResidenceAddress.Region","",
                false
              )).Validate(c => true, obj, obj.Patient.CurrentResidenceAddress.idfsRegion);
            
                (new RequiredValidator( "Patient.CurrentResidenceAddress.idfsRayon", "Patient.CurrentResidenceAddress.Rayon","",
                false
              )).Validate(c => true, obj, obj.Patient.CurrentResidenceAddress.idfsRayon);
            
                (new PredicateValidator("intPatientAge_idfsHumanAgeType_msgId", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => (c.Patient.intPatientAgeFromCase.HasValue && c.Patient.idfsHumanAgeTypeFromCase.HasValue) || (!c.Patient.intPatientAgeFromCase.HasValue && !c.Patient.idfsHumanAgeTypeFromCase.HasValue)
                    );
            
            (new CustomMandatoryFieldValidator("datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "",
            false
            )).Validate(obj, obj.datTentativeDiagnosisDate, CustomMandatoryField.HumanCase_DiagnosisDate);

          
            (new CustomMandatoryFieldValidator("Patient.strFirstName", "Patient.strFirstName", "",
            false
            )).Validate(obj, obj.Patient.strFirstName, CustomMandatoryField.HumanCase_Patient_FirstName);

          
            (new CustomMandatoryFieldValidator("Patient.datDateofBirth", "Patient.datDateofBirth", "",
            false
            )).Validate(obj, obj.Patient.datDateofBirth, CustomMandatoryField.HumanCase_Patient_DateOfBirth);

          
            (new CustomMandatoryFieldValidator("Patient.intPatientAgeFromCase", "Patient.intPatientAgeFromCase", "",
            false
            )).Validate(obj, obj.Patient.intPatientAgeFromCase, CustomMandatoryField.HumanCase_Patient_Age);

          
            (new CustomMandatoryFieldValidator("Patient.HumanAgeType", "Patient.HumanAgeType", "",
            false
            )).Validate(obj, obj.Patient.HumanAgeType, CustomMandatoryField.HumanCase_Patient_AgeType);

          
            (new CustomMandatoryFieldValidator("Patient.Gender", "Patient.Gender", "",
            false
            )).Validate(obj, obj.Patient.Gender, CustomMandatoryField.HumanCase_Patient_Gender);

          
            (new CustomMandatoryFieldValidator("Patient.CurrentResidenceAddress.Settlement", "Patient.CurrentResidenceAddress.Settlement", "",
            false
            )).Validate(obj, obj.Patient.CurrentResidenceAddress.Settlement, CustomMandatoryField.HumanCase_Patient_CurrentResidence_Settlement);

          
            (new CustomMandatoryFieldValidator("datOnSetDate", "datOnSetDate", "",
            false
            )).Validate(obj, obj.datOnSetDate, CustomMandatoryField.HumanCase_DateOfSymptomsOnSet);

          
            (new CustomMandatoryFieldValidator("Patient.RegistrationAddress.Region", "Patient.RegistrationAddress.Region", "",
            false
            )).Validate(obj, obj.Patient.RegistrationAddress.Region, CustomMandatoryField.HumanCase_Patient_RegistrationAddress_Region);

          
            (new CustomMandatoryFieldValidator("Patient.RegistrationAddress.Rayon", "Patient.RegistrationAddress.Rayon", "",
            false
            )).Validate(obj, obj.Patient.RegistrationAddress.Rayon, CustomMandatoryField.HumanCase_Patient_RegistrationAddress_Rayon);

          
            (new CustomMandatoryFieldValidator("Patient.RegistrationAddress.Settlement", "Patient.RegistrationAddress.Settlement", "",
            false
            )).Validate(obj, obj.Patient.RegistrationAddress.Settlement, CustomMandatoryField.HumanCase_Patient_RegistrationAddress_Settlement);

          
            (new CustomMandatoryFieldValidator("PointGeoLocation.strReadOnlyAdaptiveFullName", "PointGeoLocation.strReadOnlyAdaptiveFullName", "",
            false
            )).Validate(obj, obj.PointGeoLocation.strReadOnlyAdaptiveFullName, CustomMandatoryField.HumanCase_PointGeoLocation);

          
            (new CustomMandatoryFieldValidator("datExposureDate", "datExposureDate", "",
            false
            )).Validate(obj, obj.datExposureDate, CustomMandatoryField.HumanCase_ExposureDate);

          
            (new CustomMandatoryFieldValidator("InitialCaseStatus", "InitialCaseStatus", "",
            false
            )).Validate(obj, obj.InitialCaseStatus, CustomMandatoryField.HumanCase_InitialCaseStatus);

          
            (new CustomMandatoryFieldValidator("idfsFinalState", "idfsFinalState", "",
            false
            )).Validate(obj, obj.idfsFinalState, CustomMandatoryField.HumanCase_FinalCaseStatus);

          
            (new CustomMandatoryFieldValidator("datCompletionPaperFormDate", "datCompletionPaperFormDate", "",
            false
            )).Validate(obj, obj.datCompletionPaperFormDate, CustomMandatoryField.HumanCase_CompletionPaperFormDate);

          
            (new CustomMandatoryFieldValidator("idfSentByPerson", "idfSentByPerson", "",
            false
            )).Validate(obj, obj.idfSentByPerson, CustomMandatoryField.HumanCase_SentByPerson);

          
            (new CustomMandatoryFieldValidator("SentByPerson", "SentByPerson", "",
            false
            )).Validate(obj, obj.SentByPerson, CustomMandatoryField.HumanCase_SentByPerson);

          
            (new CustomMandatoryFieldValidator("idfSentByOffice", "idfSentByOffice", "",
            false
            )).Validate(obj, obj.idfSentByOffice, CustomMandatoryField.HumanCase_SentByOffice);

          
                (new PredicateValidator("msgCoordinatesAreNotDefined", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Patient.CurrentResidenceAddress.dblLongitude.HasValue && c.Patient.CurrentResidenceAddress.dblLatitude.HasValue || !c.Patient.CurrentResidenceAddress.dblLongitude.HasValue && !c.Patient.CurrentResidenceAddress.dblLatitude.HasValue
                    );
            
                (new PredicateValidator("msgCoordinatesAreNotDefined", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Patient.RegistrationAddress.dblLongitude.HasValue && c.Patient.RegistrationAddress.dblLatitude.HasValue || !c.Patient.RegistrationAddress.dblLongitude.HasValue && !c.Patient.RegistrationAddress.dblLatitude.HasValue
                    );
            
                (new PredicateValidator("", "", "", "",
              new object[] {
              },
                        true
                    )).Validate(obj, c => c.Patient.CurrentResidenceAddress.IsCoordinatesInRayon() &&
                                                       c.Patient.RegistrationAddress.IsCoordinatesInCountry() &&
                                                       c.Patient.RegistrationAddress.IsCoordinatesInRegion() &&
                                                       c.Patient.RegistrationAddress.IsCoordinatesInRayon()
                      , c => !c.Patient.CurrentResidenceAddress.IsCoordinatesInRayon() ? "msgCoordinatesOutOfRayon"
                                                           : (!c.Patient.RegistrationAddress.IsCoordinatesInCountry() ? "msgCoordinatesOutOfCountry"
                                                           : (!c.Patient.RegistrationAddress.IsCoordinatesInRegion() ? "msgCoordinatesOutOfRegion"
                                                           : (!c.Patient.RegistrationAddress.IsCoordinatesInRayon() ? "msgCoordinatesOutOfRayon"
                                                           : "")))
                    );
            
                        foreach(var item in obj.AntimicrobialTherapy.Where(c => true))
                        {
                        
                (new RequiredValidator( "strAntimicrobialTherapyName", "strAntimicrobialTherapyName","",
                false
              )).Validate(c => true, item, item.strAntimicrobialTherapyName);
            
                        }
                
                        foreach(var item in obj.Samples.Where(c => true))
                        {
                        
                (new RequiredValidator( "idfsSpecimenType", "idfsSpecimenType","",
                false
              )).Validate(c => true, item, item.idfsSpecimenType);
            
                        }
                
                        foreach(var item in obj.ContactedPerson.Where(c => true))
                        {
                        
                (new RequiredValidator( "Person.strLastName", "Person.strLastName","",
                false
              )).Validate(c => true, item, item.Person.strLastName);
            
                        }
                
                  
                    }

                    if (bChangeValidation)
                    {
                
                        foreach(var item in obj.ContactedPerson.Where(c => !c.IsMarkedToDelete))
                        {
                        
                (new PredicateValidator("mbDuplicateContact", "", "ContactedPerson", "",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => c.ContactedPerson.Count(j => 
                        !j.IsMarkedToDelete 
                        && j.idfContactedCasePerson != i.idfContactedCasePerson
                        && j.Person.strFirstName == i.Person.strFirstName
                        && j.Person.strLastName == i.Person.strLastName
                        && j.Person.strSecondName == i.Person.strSecondName
                        && j.Person.datDateofBirth == i.Person.datDateofBirth
                        && j.Person.idfsHumanGender == i.Person.idfsHumanGender
                        && j.Person.CurrentResidenceAddress.idfsCountry == i.Person.CurrentResidenceAddress.idfsCountry
                        && j.Person.CurrentResidenceAddress.idfsRegion == i.Person.CurrentResidenceAddress.idfsRegion
                        && j.Person.CurrentResidenceAddress.idfsRayon == i.Person.CurrentResidenceAddress.idfsRayon
                        && j.Person.CurrentResidenceAddress.idfsSettlement == i.Person.CurrentResidenceAddress.idfsSettlement
                        && j.Person.CurrentResidenceAddress.strStreetName == i.Person.CurrentResidenceAddress.strStreetName
                        && j.Person.CurrentResidenceAddress.strPostCode == i.Person.CurrentResidenceAddress.strPostCode
                        && j.Person.CurrentResidenceAddress.strBuilding == i.Person.CurrentResidenceAddress.strBuilding
                        && j.Person.CurrentResidenceAddress.strApartment == i.Person.CurrentResidenceAddress.strApartment
                        && j.Person.CurrentResidenceAddress.strHouse == i.Person.CurrentResidenceAddress.strHouse
                        ) == 0
                    );
            
                        }
                
                        {
                            var item = obj.Patient;
                        
                (new PredicateValidator("Date of Birth_Current date", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, DateTime.Now)
                    );
            
                (new PredicateValidator("Date of Birth_Notification date", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datNotificationDate)
                    );
            
                (new PredicateValidator("Date of Birth_Diagnosis date", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datTentativeDiagnosisDate)
                    );
            
                (new PredicateValidator("Date of Birth_Date of changed diagnosis", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datFinalDiagnosisDate)
                    );
            
                (new PredicateValidator("Date of Birth_Date Entered", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datEnteredDate)
                    );
            
                (new PredicateValidator("Date of Birth_Sample Collection Date", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(i.datDateofBirth, a.datFieldCollectionDate)).Count() == c.Samples.Count(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown)
                    );
            
                (new PredicateValidator("Date of Birth_Sample sent date", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(i.datDateofBirth, a.datFieldSentDate)).Count() == c.Samples.Count(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown)
                    );
            
                (new PredicateValidator("Date of Birth_Accession Date", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(i.datDateofBirth, a.datAccession)).Count() == c.Samples.Count(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown)
                    );
            
                (new PredicateValidator("Date of Birth_Date of last visit to employer, school, children's facility", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datFacilityLastVisit)
                    );
            
                (new PredicateValidator("Date of Birth_Date of last contact", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => c.ContactedPerson.Where(a => PredicateValidator.CompareDates(i.datDateofBirth, a.datDateOfLastContact)).Count() == c.ContactedPerson.Count()
                    );
            
                (new PredicateValidator("Date of Birth_Date of hospitalization", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datHospitalizationDate)
                    );
            
                (new PredicateValidator("Date of Birth_Date of patient first sought care", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datFirstSoughtCareDate)
                    );
            
                (new PredicateValidator("Date of Birth_Date of symptoms onset", "datDateofBirth", "Patient", "datDateofBirth",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(i.datDateofBirth, c.datOnSetDate)
                    );
            
                        }
                
                        foreach(var item in obj.Samples.Where(c => !c.IsMarkedToDelete && c.idfsSpecimenType != (long)SampleTypeEnum.Unknown))
                        {
                        
                (new PredicateValidator("Date of Birth_Sample Collection Date", "datFieldCollectionDate", "Samples", "datFieldCollectionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.Patient.datDateofBirth, i.datFieldCollectionDate)
                    );
            
                        }
                
                        foreach(var item in obj.Samples.Where(c => !c.IsMarkedToDelete && c.idfsSpecimenType != (long)SampleTypeEnum.Unknown))
                        {
                        
                (new PredicateValidator("Date of Birth_Sample sent date", "datFieldSentDate", "Samples", "datFieldSentDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.Patient.datDateofBirth, i.datFieldSentDate)
                    );
            
                (new PredicateValidator("Date of symptoms onset_Sample Sent Date", "datFieldSentDate", "Samples", "datFieldSentDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.datOnSetDate, i.datFieldSentDate)
                    );
            
                (new PredicateValidator("Diagnosis date_Sample sent date", "datFieldSentDate", "Samples", "datFieldSentDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, i.datFieldSentDate)
                    );
            
                        }
                
                        foreach(var item in obj.Samples.Where(c => !c.IsMarkedToDelete && c.idfsSpecimenType != (long)SampleTypeEnum.Unknown))
                        {
                        
                (new PredicateValidator("Date of Birth_Accession Date", "datAccession", "Samples", "datAccession",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.Patient.datDateofBirth, i.datAccession)
                    );
            
                (new PredicateValidator("Date of symptoms onset_Accession Date", "datAccession", "Samples", "datAccession",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.datOnSetDate, i.datAccession)
                    );
            
                (new PredicateValidator("Diagnosis date_Accession Date", "datAccession", "Samples", "datAccession",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, i.datAccession)
                    );
            
                        }
                
                        foreach(var item in obj.Samples.Where(c => !c.IsMarkedToDelete && c.idfsSpecimenType != (long)SampleTypeEnum.Unknown))
                        {
                        
                (new PredicateValidator("Date of symptoms onset_Sample Collection Date", "datFieldCollectionDate", "Samples", "datFieldCollectionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.datOnSetDate, i.datFieldCollectionDate)
                    );
            
                (new PredicateValidator("Diagnosis date_Sample Collection Date", "datFieldCollectionDate", "Samples", "datFieldCollectionDate",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, i.datFieldCollectionDate)
                    );
            
                        }
                
                        foreach(var item in obj.ContactedPerson.Where(c => !c.IsMarkedToDelete))
                        {
                        
                (new PredicateValidator("Date of Birth_Date of last contact", "datDateOfLastContact", "ContactedPerson", "datDateOfLastContact",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => PredicateValidator.CompareDates(c.Patient.datDateofBirth, i.datDateOfLastContact)
                    );
            
                        }
                
                (new PredicateValidator("idfsFinalDiagnosis_idfsTentativeDiagnosis_msgId", "idfsFinalDiagnosis", "idfsFinalDiagnosis", "idfsFinalDiagnosis",
              new object[] {
              },
                        false
                    )).Validate(obj, c => !c.idfsTentativeDiagnosis.HasValue || !c.idfsFinalDiagnosis.HasValue || (c.idfsTentativeDiagnosis.HasValue && c.idfsFinalDiagnosis.HasValue && c.idfsFinalDiagnosis != c.idfsTentativeDiagnosis)
                    );
            
                (new PredicateValidator("idfsFinalDiagnosis_idfsTentativeDiagnosis_msgId", "idfsTentativeDiagnosis", "idfsTentativeDiagnosis", "idfsTentativeDiagnosis",
              new object[] {
              },
                        false
                    )).Validate(obj, c => !c.idfsTentativeDiagnosis.HasValue || !c.idfsFinalDiagnosis.HasValue || (c.idfsTentativeDiagnosis.HasValue && c.idfsFinalDiagnosis.HasValue && c.idfsFinalDiagnosis != c.idfsTentativeDiagnosis)
                    );
            
                (new PredicateValidator("mbCannotDeleteAllAntibiotics", "idfsYNAntimicrobialTherapy", "idfsYNAntimicrobialTherapy", "idfsYNAntimicrobialTherapy",
              new object[] {
              },
                        false
                    )).Validate(obj, c => !((c.AntimicrobialTherapyUsed == null || c.idfsYNAntimicrobialTherapy != (long)YesNoUnknownValuesEnum.Yes)
                                            && (c.AntimicrobialTherapy.Where(s => !s.IsMarkedToDelete).Count() > 0))
                    );
            
                (new PredicateValidator("mbCannotDeleteAllSpecimens", "idfsYNSpecimenCollected", "idfsYNSpecimenCollected", "idfsYNSpecimenCollected",
              new object[] {
              },
                        false
                    )).Validate(obj, c => !((c.SpecimenCollected == null || c.idfsYNSpecimenCollected != (long)YesNoUnknownValuesEnum.Yes)
                                            && (c.Samples.Where(s => !s.IsMarkedToDelete && s.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count() > 0))
                    );
            
                (new PredicateValidator("Date of Birth_Notification date", "datNotificationDate", "datNotificationDate", "datNotificationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datNotificationDate)
                    );
            
                (new PredicateValidator("Date of Birth_Diagnosis date", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datTentativeDiagnosisDate)
                    );
            
                (new PredicateValidator("Date of Birth_Date of changed diagnosis", "datFinalDiagnosisDate", "datFinalDiagnosisDate", "datFinalDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datFinalDiagnosisDate)
                    );
            
                (new PredicateValidator("Date of Birth_Date of last visit to employer, school, children's facility", "datFacilityLastVisit", "datFacilityLastVisit", "datFacilityLastVisit",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datFacilityLastVisit)
                    );
            
                (new PredicateValidator("Notification date_Date Entered", "datNotificationDate", "datNotificationDate", "datNotificationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datNotificationDate, c.datEnteredDate)
                    );
            
                (new PredicateValidator("Date of symptoms onset_Date Entered", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datEnteredDate)
                    );
            
                (new PredicateValidator("Diagnosis date_Date Entered", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datEnteredDate)
                    );
            
                (new PredicateValidator("Notification date_Current date", "datNotificationDate", "datNotificationDate", "datNotificationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datNotificationDate, DateTime.Now)
                    );
            
                (new PredicateValidator("Diagnosis date_Notification date", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datNotificationDate)
                    );
            
                (new PredicateValidator("Diagnosis date_Notification date", "datNotificationDate", "datNotificationDate", "datNotificationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datNotificationDate)
                    );
            
                (new PredicateValidator("Date of symptoms onset_Current date", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, DateTime.Now)
                    );
            
                (new PredicateValidator("Date of symptoms onset_Diagnosis date", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datTentativeDiagnosisDate)
                    );
            
                (new PredicateValidator("Date of symptoms onset_Diagnosis date", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datTentativeDiagnosisDate)
                    );
            
                (new PredicateValidator("Date of symptoms onset_Date of changed diagnosis", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datFinalDiagnosisDate)
                    );
            
                (new PredicateValidator("Date of symptoms onset_Date of changed diagnosis", "datFinalDiagnosisDate", "datFinalDiagnosisDate", "datFinalDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datFinalDiagnosisDate)
                    );
            
                (new PredicateValidator("Date of symptoms onset_Sample Collection Date", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(c.datOnSetDate, a.datFieldCollectionDate)).Count() == c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count()
                    );
            
                (new PredicateValidator("Date of symptoms onset_Sample Sent Date", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(c.datOnSetDate, a.datFieldSentDate)).Count() == c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count()
                    );
            
                (new PredicateValidator("Date of symptoms onset_Accession Date", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(c.datOnSetDate, a.datAccession)).Count() == c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count()
                    );
            
                (new PredicateValidator("Diagnosis date_Date of changed diagnosis", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datFinalDiagnosisDate)
                    );
            
                (new PredicateValidator("Diagnosis date_Date of changed diagnosis", "datFinalDiagnosisDate", "datFinalDiagnosisDate", "datFinalDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datFinalDiagnosisDate)
                    );
            
                (new PredicateValidator("Diagnosis date_Sample Collection Date", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, a.datFieldCollectionDate)).Count() == c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count()
                    );
            
                (new PredicateValidator("Diagnosis date_Sample sent date", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, a.datFieldSentDate)).Count() == c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count()
                    );
            
                (new PredicateValidator("Diagnosis date_Accession Date", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown && PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, a.datAccession)).Count() == c.Samples.Where(a => !a.IsMarkedToDelete && a.idfsSpecimenType != (long)SampleTypeEnum.Unknown).Count()
                    );
            
                (new PredicateValidator("Date of Birth_Date of hospitalization", "datHospitalizationDate", "datHospitalizationDate", "datHospitalizationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datHospitalizationDate)
                    );
            
                (new PredicateValidator("Date of Birth_Date of patient first sought care", "datFirstSoughtCareDate", "datFirstSoughtCareDate", "datFirstSoughtCareDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datFirstSoughtCareDate)
                    );
            
                (new PredicateValidator("Date of Exposure_Date of symptoms onset", "datExposureDate", "datExposureDate", "datExposureDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datExposureDate, c.datOnSetDate)
                    );
            
                (new PredicateValidator("Date of Exposure_Date of symptoms onset", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datExposureDate, c.datOnSetDate)
                    );
            
                (new PredicateValidator("Diagnosis date_Date of completion of paper form", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate", "datTentativeDiagnosisDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datCompletionPaperFormDate)
                    );
            
                (new PredicateValidator("Diagnosis date_Date of completion of paper form", "datCompletionPaperFormDate", "datCompletionPaperFormDate", "datCompletionPaperFormDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datTentativeDiagnosisDate, c.datCompletionPaperFormDate)
                    );
            
                (new PredicateValidator("Date of completion of paper form_Notification date", "datCompletionPaperFormDate", "datCompletionPaperFormDate", "datCompletionPaperFormDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datCompletionPaperFormDate, c.datNotificationDate)
                    );
            
                (new PredicateValidator("Date of completion of paper form_Notification date", "datNotificationDate", "datNotificationDate", "datNotificationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datCompletionPaperFormDate, c.datNotificationDate)
                    );
            
                (new PredicateValidator("Date of Birth_Date of symptoms onset", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.Patient.datDateofBirth, c.datOnSetDate)
                    );
            
                (new PredicateValidator("Date of symptoms onset_Notification date", "datOnSetDate", "datOnSetDate", "datOnSetDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datNotificationDate)
                    );
            
                (new PredicateValidator("Date of symptoms onset_Notification date", "datNotificationDate", "datNotificationDate", "datNotificationDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datOnSetDate, c.datNotificationDate)
                    );
            
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Patient != null)
                            PatientAccessor.Validate(manager, obj.Patient, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.PointGeoLocation != null)
                            PointGeoLocationAccessor.Validate(manager, obj.PointGeoLocation, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.ContactedPerson != null)
                            foreach (var i in obj.ContactedPerson.Where(c => !c.IsMarkedToDelete))
                                ContactedPersonAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Samples != null)
                            foreach (var i in obj.Samples.Where(c => !c.IsMarkedToDelete))
                                SamplesAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.CaseTests != null)
                            foreach (var i in obj.CaseTests.Where(c => !c.IsMarkedToDelete))
                                CaseTestsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.AntimicrobialTherapy != null)
                            foreach (var i in obj.AntimicrobialTherapy.Where(c => !c.IsMarkedToDelete))
                                AntimicrobialTherapyAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.DiagnosisHistory != null)
                            foreach (var i in obj.DiagnosisHistory.Where(c => !c.IsMarkedToDelete))
                                DiagnosisHistoryAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.CaseTestValidations != null)
                            foreach (var i in obj.CaseTestValidations.Where(c => !c.IsMarkedToDelete))
                                CaseTestValidationsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FFPresenterCs != null)
                            FFPresenterCsAccessor.Validate(manager, obj.FFPresenterCs, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FFPresenterEpi != null)
                            FFPresenterEpiAccessor.Validate(manager, obj.FFPresenterEpi, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(HumanCase obj)
            {
            
                obj
                    .AddRequired("CaseProgressStatus", c => true);
                    
                obj
                    .AddRequired("TentativeDiagnosis", c => true);
                    
                obj
                    .Patient
                        .AddRequired("strLastName", c => true);
                        
                obj
                    .Patient
                        .CurrentResidenceAddress
                        .AddRequired("Country", c => true);
                        
                obj
                    .Patient
                        .CurrentResidenceAddress
                        .AddRequired("Region", c => true);
                        
                obj
                    .Patient
                        .CurrentResidenceAddress
                        .AddRequired("Rayon", c => true);
                        
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_DiagnosisDate))
              {
              
              obj
                  .AddRequired("datTentativeDiagnosisDate", c=>true);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_Patient_FirstName))
              {
              
              obj
                  .Patient
                      .AddRequired("strFirstName", c=>true);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_Patient_DateOfBirth))
              {
              
              obj
                  .Patient
                      .AddRequired("datDateofBirth", c=>true);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_Patient_Age))
              {
              
              obj
                  .Patient
                      .AddRequired("intPatientAgeFromCase", c=>true);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_Patient_AgeType))
              {
              
              obj
                  .Patient
                      .AddRequired("HumanAgeType", c=>true);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_Patient_Gender))
              {
              
              obj
                  .Patient
                      .AddRequired("Gender", c=>true);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_Patient_CurrentResidence_Settlement))
              {
              
              obj
                  .Patient
                      .CurrentResidenceAddress
                      .AddRequired("Settlement", c=>true);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_DateOfSymptomsOnSet))
              {
              
              obj
                  .AddRequired("datOnSetDate", c=>true);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_Patient_RegistrationAddress_Region))
              {
              
              obj
                  .Patient
                      .RegistrationAddress
                      .AddRequired("Region", c=>true);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_Patient_RegistrationAddress_Rayon))
              {
              
              obj
                  .Patient
                      .RegistrationAddress
                      .AddRequired("Rayon", c=>true);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_Patient_RegistrationAddress_Settlement))
              {
              
              obj
                  .Patient
                      .RegistrationAddress
                      .AddRequired("Settlement", c=>true);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_PointGeoLocation))
              {
              
              obj
                  .PointGeoLocation
                      .AddRequired("strReadOnlyAdaptiveFullName", c=>true);
                    
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_ExposureDate))
              {
              
              obj
                  .AddRequired("datExposureDate", c=>true);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_InitialCaseStatus))
              {
              
              obj
                  .AddRequired("InitialCaseStatus", c=>true);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_FinalCaseStatus))
              {
              
              obj
                  .AddRequired("idfsFinalState", c=>true);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_CompletionPaperFormDate))
              {
              
              obj
                  .AddRequired("datCompletionPaperFormDate", c=>true);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_SentByPerson))
              {
              
              obj
                  .AddRequired("idfSentByPerson", c=>true);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_SentByPerson))
              {
              
              obj
                  .AddRequired("SentByPerson", c=>true);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanCase_SentByOffice))
              {
              
              obj
                  .AddRequired("idfSentByOffice", c=>true);
                
                }
            
            }
    
    private void _SetupPersonalDataRestrictions(HumanCase obj)
    {
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName))
      {
      
            obj
              .Patient
                  .AddHiddenPersonalData("strLastName", c=>true);
                
            obj
              .Patient
                  .AddHiddenPersonalData("strFirstName", c=>true);
                
            obj
              .Patient
                  .AddHiddenPersonalData("strMiddleName", c=>true);
                
            obj
              .Patient
                  .AddHiddenPersonalData("strSecondName", c=>true);
                
            obj
              .Patient
                  .AddHiddenPersonalData("strName", c=>true);
                
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonAge))
      {
      
            obj
              .Patient
                  .AddHiddenPersonalData("datDateofBirth", c=>true);
                
            obj
              .Patient
                  .AddHiddenPersonalData("intPatientAgeFromCase", c=>true);
                
            obj
              .Patient
                  .AddHiddenPersonalData("idfsHumanAgeTypeFromCase", c=>true);
                
            obj
              .Patient
                  .AddHiddenPersonalData("HumanAgeType", c=>true);
                
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonSex))
      {
      
            obj
              .Patient
                  .AddHiddenPersonalData("Gender", c=>true);
                
            obj
              .Patient
                  .AddHiddenPersonalData("idfsGender", c=>true);
                
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Settlement))
      {
      
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("Settlement", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("idfsSettlement", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("PostCode", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("Street", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("strPostCode", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("strStreetName", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("strApartment", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("strHouse", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("strBuilding", c=>true);
                
            obj
              .Patient
                  .AddHiddenPersonalData("strHomePhone", c=>true);
                
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Details))
      {
      
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("PostCode", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("Street", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("strPostCode", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("strStreetName", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("strApartment", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("strHouse", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("strBuilding", c=>true);
                
            obj
              .Patient
                  .AddHiddenPersonalData("strHomePhone", c=>true);
                
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Coordinates))
      {
      
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("dblLongitude", c=>true);
                
            obj
              .Patient
                  .CurrentResidenceAddress
                  .AddHiddenPersonalData("dblLatitude", c=>true);
                
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Employer_Settlement))
      {
      
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("PostCode", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("Street", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("Settlement", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("idfsSettlement", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("strPostCode", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("strStreetName", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("strApartment", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("strHouse", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("strBuilding", c=>true);
                
            obj
              .Patient
                  .AddHiddenPersonalData("strEmployerName", c=>true);
                
            obj
              .AddHiddenPersonalData("strWorkPhone", c=>true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Employer_Details))
      {
      
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("PostCode", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("Street", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("strPostCode", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("strStreetName", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("strApartment", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("strHouse", c=>true);
                
            obj
              .Patient
                  .EmployerAddress
                  .AddHiddenPersonalData("strBuilding", c=>true);
                
            obj
              .Patient
                  .AddHiddenPersonalData("strEmployerName", c=>true);
                
            obj
              .AddHiddenPersonalData("strWorkPhone", c=>true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PermanentResidence_Settlement))
      {
      
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("PostCode", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("Street", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("Settlement", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("idfsSettlement", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("strPostCode", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("strStreetName", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("strApartment", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("strHouse", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("strBuilding", c=>true);
                
            obj
              .AddHiddenPersonalData("strRegistrationPhone", c=>true);
            
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("strForeignAddress", c=>true);
                
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PermanentResidence_Details))
      {
      
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("PostCode", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("Street", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("strPostCode", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("strStreetName", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("strApartment", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("strHouse", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("strBuilding", c=>true);
                
            obj
              .AddHiddenPersonalData("strRegistrationPhone", c=>true);
            
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("strForeignAddress", c=>true);
                
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PermanentResidence_Coordinates))
      {
      
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("dblLongitude", c=>true);
                
            obj
              .RegistrationAddress
                  .AddHiddenPersonalData("dblLatitude", c=>true);
                
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Contact_Settlement))
      {
      
            obj
              .AddHiddenPersonalData("ContactedPersonList", c=>true);
            
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .AddHiddenPersonalData("strFullName", c=>true);
                  
                }
              
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .Person
                        .RegistrationAddress
                          .AddHiddenPersonalData("Settlement", c=>true);
                      
                }
              
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .Person
                        .RegistrationAddress
                          .AddHiddenPersonalData("idfsSettlement", c=>true);
                      
                }
              
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .Person
                        .RegistrationAddress
                          .AddHiddenPersonalData("strPostCode", c=>true);
                      
                }
              
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .Person
                        .RegistrationAddress
                          .AddHiddenPersonalData("strStreetName", c=>true);
                      
                }
              
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .Person
                        .RegistrationAddress
                          .AddHiddenPersonalData("strApartment", c=>true);
                      
                }
              
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .Person
                        .RegistrationAddress
                          .AddHiddenPersonalData("strHouse", c=>true);
                      
                }
              
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .Person
                        .RegistrationAddress
                          .AddHiddenPersonalData("strBuilding", c=>true);
                      
                }
              
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Contact_Details))
      {
      
            obj
              .AddHiddenPersonalData("ContactedPersonList", c=>true);
            
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .AddHiddenPersonalData("strFullName", c=>true);
                  
                }
              
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .Person
                        .RegistrationAddress
                          .AddHiddenPersonalData("strPostCode", c=>true);
                      
                }
              
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .Person
                        .RegistrationAddress
                          .AddHiddenPersonalData("strStreetName", c=>true);
                      
                }
              
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .Person
                        .RegistrationAddress
                          .AddHiddenPersonalData("strApartment", c=>true);
                      
                }
              
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .Person
                        .RegistrationAddress
                          .AddHiddenPersonalData("strHouse", c=>true);
                      
                }
              
                foreach(var o in obj.ContactedPerson)
              {
              o
               
                    .Person
                        .RegistrationAddress
                          .AddHiddenPersonalData("strBuilding", c=>true);
                      
                }
              
      }
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as HumanCase) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as HumanCase) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "HumanCaseDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return "web_human_case_form"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private HumanCase m_obj;
            internal Permissions(HumanCase obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spHumanCase_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spHumanCase_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spHumanCase_Delete";
            public static string spCanDelete = "spHumanCase_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<HumanCase, bool>> RequiredByField = new Dictionary<string, Func<HumanCase, bool>>();
            public static Dictionary<string, Func<HumanCase, bool>> RequiredByProperty = new Dictionary<string, Func<HumanCase, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strCaseID, 200);
                Sizes.Add(_str_strSentByOffice, 2000);
                Sizes.Add(_str_strSentByPerson, 602);
                Sizes.Add(_str_strReceivedByOffice, 2000);
                Sizes.Add(_str_strReceivedByPerson, 602);
                Sizes.Add(_str_strInvestigatedByOffice, 2000);
                Sizes.Add(_str_strInvestigatedByPerson, 602);
                Sizes.Add(_str_strNote, 2000);
                Sizes.Add(_str_strCurrentLocation, 200);
                Sizes.Add(_str_strHospitalizationPlace, 200);
                Sizes.Add(_str_strLocalIdentifier, 200);
                Sizes.Add(_str_strSoughtCareFacility, 2000);
                Sizes.Add(_str_strSentByFirstName, 200);
                Sizes.Add(_str_strSentByPatronymicName, 200);
                Sizes.Add(_str_strSentByLastName, 200);
                Sizes.Add(_str_strReceivedByFirstName, 200);
                Sizes.Add(_str_strReceivedByPatronymicName, 200);
                Sizes.Add(_str_strReceivedByLastName, 200);
                Sizes.Add(_str_strEpidemiologistsName, 200);
                Sizes.Add(_str_strClinicalNotes, 2000);
                Sizes.Add(_str_strSummaryNotes, 2000);
                Sizes.Add(_str_strPersonEnteredBy, 602);
                Sizes.Add(_str_strRegistrationPhone, 200);
                Sizes.Add(_str_strWorkPhone, 200);
                Sizes.Add(_str_strSampleNotes, 1000);
                if (!RequiredByField.ContainsKey("idfsCaseProgressStatus")) RequiredByField.Add("idfsCaseProgressStatus", c => true);
                if (!RequiredByProperty.ContainsKey("CaseProgressStatus")) RequiredByProperty.Add("CaseProgressStatus", c => true);
                
                if (!RequiredByField.ContainsKey("idfsTentativeDiagnosis")) RequiredByField.Add("idfsTentativeDiagnosis", c => true);
                if (!RequiredByProperty.ContainsKey("TentativeDiagnosis")) RequiredByProperty.Add("TentativeDiagnosis", c => true);
                
                if (!RequiredByField.ContainsKey("Patient.strLastName")) RequiredByField.Add("Patient.strLastName", c => true);
                if (!RequiredByProperty.ContainsKey("Patient.strLastName")) RequiredByProperty.Add("Patient.strLastName", c => true);
                
                if (!RequiredByField.ContainsKey("Patient.CurrentResidenceAddress.idfsCountry")) RequiredByField.Add("Patient.CurrentResidenceAddress.idfsCountry", c => true);
                if (!RequiredByProperty.ContainsKey("Patient.CurrentResidenceAddress.Country")) RequiredByProperty.Add("Patient.CurrentResidenceAddress.Country", c => true);
                
                if (!RequiredByField.ContainsKey("Patient.CurrentResidenceAddress.idfsRegion")) RequiredByField.Add("Patient.CurrentResidenceAddress.idfsRegion", c => true);
                if (!RequiredByProperty.ContainsKey("Patient.CurrentResidenceAddress.Region")) RequiredByProperty.Add("Patient.CurrentResidenceAddress.Region", c => true);
                
                if (!RequiredByField.ContainsKey("Patient.CurrentResidenceAddress.idfsRayon")) RequiredByField.Add("Patient.CurrentResidenceAddress.idfsRayon", c => true);
                if (!RequiredByProperty.ContainsKey("Patient.CurrentResidenceAddress.Rayon")) RequiredByProperty.Add("Patient.CurrentResidenceAddress.Rayon", c => true);
                
                Actions.Add(new ActionMetaItem(
                    "CreateGeoLocation",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).CreateGeoLocation(manager, (HumanCase)c, pars),
                        
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
                    "EmergencyNotificationReport",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).EmergencyNotificationReport(manager, (HumanCase)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleEmergencyNotificationReport",
                        "Report",
                        /*from BvMessages*/"titleEmergencyNotificationReport",
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
                    "HumanInvestigationReport",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).HumanInvestigationReport(manager, (HumanCase)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleCaseInvestigationReport",
                        "Report",
                        /*from BvMessages*/"titleCaseInvestigationReport",
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
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((HumanCase)c).MarkToDelete() && ObjectAccessor.PostInterface<HumanCase>().Post(manager, (HumanCase)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<HumanCase>().Post(manager, (HumanCase)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<HumanCase>().Post(manager, (HumanCase)c), c),
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
	