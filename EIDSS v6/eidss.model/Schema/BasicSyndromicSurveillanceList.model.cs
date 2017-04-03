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
    public abstract partial class BasicSyndromicSurveillanceListItem : 
        EditableObject<BasicSyndromicSurveillanceListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfBasicSyndromicSurveillance), NonUpdatable, PrimaryKey]
        public abstract Int64 idfBasicSyndromicSurveillance { get; set; }
                
        [LocalizedDisplayName(_str_strFormID)]
        [MapField(_str_strFormID)]
        public abstract String strFormID { get; set; }
        protected String strFormID_Original { get { return ((EditableValue<String>)((dynamic)this)._strFormID).OriginalValue; } }
        protected String strFormID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFormID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDateEntered)]
        [MapField(_str_datDateEntered)]
        public abstract DateTime datDateEntered { get; set; }
        protected DateTime datDateEntered_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datDateEntered).OriginalValue; } }
        protected DateTime datDateEntered_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datDateEntered).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDateLastSaved)]
        [MapField(_str_datDateLastSaved)]
        public abstract DateTime datDateLastSaved { get; set; }
        protected DateTime datDateLastSaved_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datDateLastSaved).OriginalValue; } }
        protected DateTime datDateLastSaved_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datDateLastSaved).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfEnteredBy)]
        [MapField(_str_idfEnteredBy)]
        public abstract Int64 idfEnteredBy { get; set; }
        protected Int64 idfEnteredBy_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfEnteredBy).OriginalValue; } }
        protected Int64 idfEnteredBy_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfEnteredBy).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64 idfsSite { get; set; }
        protected Int64 idfsSite_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64 idfsSite_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsBasicSyndromicSurveillanceType)]
        [MapField(_str_idfsBasicSyndromicSurveillanceType)]
        public abstract Int64? idfsBasicSyndromicSurveillanceType { get; set; }
        protected Int64? idfsBasicSyndromicSurveillanceType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBasicSyndromicSurveillanceType).OriginalValue; } }
        protected Int64? idfsBasicSyndromicSurveillanceType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBasicSyndromicSurveillanceType).PreviousValue; } }
                
        [LocalizedDisplayName("idfsBasicSyndromicSurveillanceType")]
        [MapField(_str_strBasicSyndromicSurveillanceType)]
        public abstract String strBasicSyndromicSurveillanceType { get; set; }
        protected String strBasicSyndromicSurveillanceType_Original { get { return ((EditableValue<String>)((dynamic)this)._strBasicSyndromicSurveillanceType).OriginalValue; } }
        protected String strBasicSyndromicSurveillanceType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBasicSyndromicSurveillanceType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfHospital)]
        [MapField(_str_idfHospital)]
        public abstract Int64? idfHospital { get; set; }
        protected Int64? idfHospital_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHospital).OriginalValue; } }
        protected Int64? idfHospital_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHospital).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHospital)]
        [MapField(_str_strHospital)]
        public abstract String strHospital { get; set; }
        protected String strHospital_Original { get { return ((EditableValue<String>)((dynamic)this)._strHospital).OriginalValue; } }
        protected String strHospital_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHospital).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datReportDate)]
        [MapField(_str_datReportDate)]
        public abstract DateTime? datReportDate { get; set; }
        protected DateTime? datReportDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReportDate).OriginalValue; } }
        protected DateTime? datReportDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReportDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFirstName)]
        [MapField(_str_strFirstName)]
        public abstract String strFirstName { get; set; }
        protected String strFirstName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).OriginalValue; } }
        protected String strFirstName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strLastName)]
        [MapField(_str_strLastName)]
        public abstract String strLastName { get; set; }
        protected String strLastName_Original { get { return ((EditableValue<String>)((dynamic)this)._strLastName).OriginalValue; } }
        protected String strLastName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strLastName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_PatientName)]
        [MapField(_str_PatientName)]
        public abstract String PatientName { get; set; }
        protected String PatientName_Original { get { return ((EditableValue<String>)((dynamic)this)._patientName).OriginalValue; } }
        protected String PatientName_Previous { get { return ((EditableValue<String>)((dynamic)this)._patientName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intAgeYear)]
        [MapField(_str_intAgeYear)]
        public abstract Int32? intAgeYear { get; set; }
        protected Int32? intAgeYear_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intAgeYear).OriginalValue; } }
        protected Int32? intAgeYear_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intAgeYear).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intAgeMonth)]
        [MapField(_str_intAgeMonth)]
        public abstract Int32? intAgeMonth { get; set; }
        protected Int32? intAgeMonth_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intAgeMonth).OriginalValue; } }
        protected Int32? intAgeMonth_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intAgeMonth).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intAgeFullYear)]
        [MapField(_str_intAgeFullYear)]
        public abstract Int32? intAgeFullYear { get; set; }
        protected Int32? intAgeFullYear_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intAgeFullYear).OriginalValue; } }
        protected Int32? intAgeFullYear_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intAgeFullYear).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intAgeFullMonth)]
        [MapField(_str_intAgeFullMonth)]
        public abstract Int32? intAgeFullMonth { get; set; }
        protected Int32? intAgeFullMonth_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intAgeFullMonth).OriginalValue; } }
        protected Int32? intAgeFullMonth_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intAgeFullMonth).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPersonalID)]
        [MapField(_str_strPersonalID)]
        public abstract String strPersonalID { get; set; }
        protected String strPersonalID_Original { get { return ((EditableValue<String>)((dynamic)this)._strPersonalID).OriginalValue; } }
        protected String strPersonalID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPersonalID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsYNPregnant)]
        [MapField(_str_idfsYNPregnant)]
        public abstract Int64? idfsYNPregnant { get; set; }
        protected Int64? idfsYNPregnant_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNPregnant).OriginalValue; } }
        protected Int64? idfsYNPregnant_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNPregnant).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsYNPostpartumPeriod)]
        [MapField(_str_idfsYNPostpartumPeriod)]
        public abstract Int64? idfsYNPostpartumPeriod { get; set; }
        protected Int64? idfsYNPostpartumPeriod_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNPostpartumPeriod).OriginalValue; } }
        protected Int64? idfsYNPostpartumPeriod_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNPostpartumPeriod).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDateOfSymptomsOnset)]
        [MapField(_str_datDateOfSymptomsOnset)]
        public abstract DateTime? datDateOfSymptomsOnset { get; set; }
        protected DateTime? datDateOfSymptomsOnset_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateOfSymptomsOnset).OriginalValue; } }
        protected DateTime? datDateOfSymptomsOnset_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateOfSymptomsOnset).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsYNFever)]
        [MapField(_str_idfsYNFever)]
        public abstract Int64? idfsYNFever { get; set; }
        protected Int64? idfsYNFever_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNFever).OriginalValue; } }
        protected Int64? idfsYNFever_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNFever).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsMethodOfMeasurement)]
        [MapField(_str_idfsMethodOfMeasurement)]
        public abstract Int64? idfsMethodOfMeasurement { get; set; }
        protected Int64? idfsMethodOfMeasurement_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMethodOfMeasurement).OriginalValue; } }
        protected Int64? idfsMethodOfMeasurement_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsMethodOfMeasurement).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strMethodOfMeasurement)]
        [MapField(_str_strMethodOfMeasurement)]
        public abstract String strMethodOfMeasurement { get; set; }
        protected String strMethodOfMeasurement_Original { get { return ((EditableValue<String>)((dynamic)this)._strMethodOfMeasurement).OriginalValue; } }
        protected String strMethodOfMeasurement_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMethodOfMeasurement).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strMethod)]
        [MapField(_str_strMethod)]
        public abstract String strMethod { get; set; }
        protected String strMethod_Original { get { return ((EditableValue<String>)((dynamic)this)._strMethod).OriginalValue; } }
        protected String strMethod_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMethod).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsYNCough)]
        [MapField(_str_idfsYNCough)]
        public abstract Int64? idfsYNCough { get; set; }
        protected Int64? idfsYNCough_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNCough).OriginalValue; } }
        protected Int64? idfsYNCough_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNCough).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsYNShortnessOfBreath)]
        [MapField(_str_idfsYNShortnessOfBreath)]
        public abstract Int64? idfsYNShortnessOfBreath { get; set; }
        protected Int64? idfsYNShortnessOfBreath_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNShortnessOfBreath).OriginalValue; } }
        protected Int64? idfsYNShortnessOfBreath_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNShortnessOfBreath).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsYNSeasonalFluVaccine)]
        [MapField(_str_idfsYNSeasonalFluVaccine)]
        public abstract Int64? idfsYNSeasonalFluVaccine { get; set; }
        protected Int64? idfsYNSeasonalFluVaccine_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNSeasonalFluVaccine).OriginalValue; } }
        protected Int64? idfsYNSeasonalFluVaccine_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNSeasonalFluVaccine).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDateOfCare)]
        [MapField(_str_datDateOfCare)]
        public abstract DateTime? datDateOfCare { get; set; }
        protected DateTime? datDateOfCare_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateOfCare).OriginalValue; } }
        protected DateTime? datDateOfCare_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateOfCare).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsYNPatientWasHospitalized)]
        [MapField(_str_idfsYNPatientWasHospitalized)]
        public abstract Int64? idfsYNPatientWasHospitalized { get; set; }
        protected Int64? idfsYNPatientWasHospitalized_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNPatientWasHospitalized).OriginalValue; } }
        protected Int64? idfsYNPatientWasHospitalized_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNPatientWasHospitalized).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsOutcome)]
        [MapField(_str_idfsOutcome)]
        public abstract Int64? idfsOutcome { get; set; }
        protected Int64? idfsOutcome_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOutcome).OriginalValue; } }
        protected Int64? idfsOutcome_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOutcome).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsYNPatientWasInER)]
        [MapField(_str_idfsYNPatientWasInER)]
        public abstract Int64? idfsYNPatientWasInER { get; set; }
        protected Int64? idfsYNPatientWasInER_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNPatientWasInER).OriginalValue; } }
        protected Int64? idfsYNPatientWasInER_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNPatientWasInER).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsYNTreatment)]
        [MapField(_str_idfsYNTreatment)]
        public abstract Int64? idfsYNTreatment { get; set; }
        protected Int64? idfsYNTreatment_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNTreatment).OriginalValue; } }
        protected Int64? idfsYNTreatment_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNTreatment).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsYNAdministratedAntiviralMedication)]
        [MapField(_str_idfsYNAdministratedAntiviralMedication)]
        public abstract Int64? idfsYNAdministratedAntiviralMedication { get; set; }
        protected Int64? idfsYNAdministratedAntiviralMedication_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNAdministratedAntiviralMedication).OriginalValue; } }
        protected Int64? idfsYNAdministratedAntiviralMedication_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsYNAdministratedAntiviralMedication).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strNameOfMedication)]
        [MapField(_str_strNameOfMedication)]
        public abstract String strNameOfMedication { get; set; }
        protected String strNameOfMedication_Original { get { return ((EditableValue<String>)((dynamic)this)._strNameOfMedication).OriginalValue; } }
        protected String strNameOfMedication_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNameOfMedication).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDateReceivedAntiviralMedication)]
        [MapField(_str_datDateReceivedAntiviralMedication)]
        public abstract DateTime? datDateReceivedAntiviralMedication { get; set; }
        protected DateTime? datDateReceivedAntiviralMedication_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateReceivedAntiviralMedication).OriginalValue; } }
        protected DateTime? datDateReceivedAntiviralMedication_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateReceivedAntiviralMedication).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnRespiratorySystem)]
        [MapField(_str_blnRespiratorySystem)]
        public abstract Boolean blnRespiratorySystem { get; set; }
        protected Boolean blnRespiratorySystem_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnRespiratorySystem).OriginalValue; } }
        protected Boolean blnRespiratorySystem_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnRespiratorySystem).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnAsthma)]
        [MapField(_str_blnAsthma)]
        public abstract Boolean blnAsthma { get; set; }
        protected Boolean blnAsthma_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnAsthma).OriginalValue; } }
        protected Boolean blnAsthma_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnAsthma).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnDiabetes)]
        [MapField(_str_blnDiabetes)]
        public abstract Boolean blnDiabetes { get; set; }
        protected Boolean blnDiabetes_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnDiabetes).OriginalValue; } }
        protected Boolean blnDiabetes_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnDiabetes).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnCardiovascular)]
        [MapField(_str_blnCardiovascular)]
        public abstract Boolean blnCardiovascular { get; set; }
        protected Boolean blnCardiovascular_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnCardiovascular).OriginalValue; } }
        protected Boolean blnCardiovascular_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnCardiovascular).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnObesity)]
        [MapField(_str_blnObesity)]
        public abstract Boolean blnObesity { get; set; }
        protected Boolean blnObesity_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnObesity).OriginalValue; } }
        protected Boolean blnObesity_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnObesity).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnRenal)]
        [MapField(_str_blnRenal)]
        public abstract Boolean blnRenal { get; set; }
        protected Boolean blnRenal_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnRenal).OriginalValue; } }
        protected Boolean blnRenal_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnRenal).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnLiver)]
        [MapField(_str_blnLiver)]
        public abstract Boolean blnLiver { get; set; }
        protected Boolean blnLiver_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnLiver).OriginalValue; } }
        protected Boolean blnLiver_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnLiver).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnNeurological)]
        [MapField(_str_blnNeurological)]
        public abstract Boolean blnNeurological { get; set; }
        protected Boolean blnNeurological_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnNeurological).OriginalValue; } }
        protected Boolean blnNeurological_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnNeurological).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnImmunodeficiency)]
        [MapField(_str_blnImmunodeficiency)]
        public abstract Boolean blnImmunodeficiency { get; set; }
        protected Boolean blnImmunodeficiency_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnImmunodeficiency).OriginalValue; } }
        protected Boolean blnImmunodeficiency_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnImmunodeficiency).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnUnknownEtiology)]
        [MapField(_str_blnUnknownEtiology)]
        public abstract Boolean blnUnknownEtiology { get; set; }
        protected Boolean blnUnknownEtiology_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnUnknownEtiology).OriginalValue; } }
        protected Boolean blnUnknownEtiology_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnUnknownEtiology).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datSampleCollectionDate)]
        [MapField(_str_datSampleCollectionDate)]
        public abstract DateTime? datSampleCollectionDate { get; set; }
        protected DateTime? datSampleCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSampleCollectionDate).OriginalValue; } }
        protected DateTime? datSampleCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSampleCollectionDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSampleID)]
        [MapField(_str_strSampleID)]
        public abstract String strSampleID { get; set; }
        protected String strSampleID_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleID).OriginalValue; } }
        protected String strSampleID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTestResult)]
        [MapField(_str_idfsTestResult)]
        public abstract Int64? idfsTestResult { get; set; }
        protected Int64? idfsTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).OriginalValue; } }
        protected Int64? idfsTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).PreviousValue; } }
                
        [LocalizedDisplayName("TestResult")]
        [MapField(_str_strTestResult)]
        public abstract String strTestResult { get; set; }
        protected String strTestResult_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestResult).OriginalValue; } }
        protected String strTestResult_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestResult).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datTestResultDate)]
        [MapField(_str_datTestResultDate)]
        public abstract DateTime? datTestResultDate { get; set; }
        protected DateTime? datTestResultDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTestResultDate).OriginalValue; } }
        protected DateTime? datTestResultDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTestResultDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datModificationForArchiveDate)]
        [MapField(_str_datModificationForArchiveDate)]
        public abstract DateTime? datModificationForArchiveDate { get; set; }
        protected DateTime? datModificationForArchiveDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationForArchiveDate).OriginalValue; } }
        protected DateTime? datModificationForArchiveDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationForArchiveDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32 intRowStatus { get; set; }
        protected Int32 intRowStatus_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32 intRowStatus_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfHuman)]
        [MapField(_str_idfHuman)]
        public abstract Int64? idfHuman { get; set; }
        protected Int64? idfHuman_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHuman).OriginalValue; } }
        protected Int64? idfHuman_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHuman).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsHumanGender)]
        [MapField(_str_idfsHumanGender)]
        public abstract Int64? idfsHumanGender { get; set; }
        protected Int64? idfsHumanGender_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanGender).OriginalValue; } }
        protected Int64? idfsHumanGender_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanGender).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strGender)]
        [MapField(_str_strGender)]
        public abstract String strGender { get; set; }
        protected String strGender_Original { get { return ((EditableValue<String>)((dynamic)this)._strGender).OriginalValue; } }
        protected String strGender_Previous { get { return ((EditableValue<String>)((dynamic)this)._strGender).PreviousValue; } }
                
        [LocalizedDisplayName("AddressName")]
        [MapField(_str_strAddress)]
        public abstract String strAddress { get; set; }
        protected String strAddress_Original { get { return ((EditableValue<String>)((dynamic)this)._strAddress).OriginalValue; } }
        protected String strAddress_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAddress).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSettlement)]
        [MapField(_str_idfsSettlement)]
        public abstract Int64? idfsSettlement { get; set; }
        protected Int64? idfsSettlement_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).OriginalValue; } }
        protected Int64? idfsSettlement_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfsCountry)]
        [MapField(_str_idfsCountry)]
        public abstract Int64? idfsCountry { get; set; }
        protected Int64? idfsCountry_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).OriginalValue; } }
        protected Int64? idfsCountry_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<BasicSyndromicSurveillanceListItem, object> _get_func;
            internal Action<BasicSyndromicSurveillanceListItem, string> _set_func;
            internal Action<BasicSyndromicSurveillanceListItem, BasicSyndromicSurveillanceListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfBasicSyndromicSurveillance = "idfBasicSyndromicSurveillance";
        internal const string _str_strFormID = "strFormID";
        internal const string _str_datDateEntered = "datDateEntered";
        internal const string _str_datDateLastSaved = "datDateLastSaved";
        internal const string _str_idfEnteredBy = "idfEnteredBy";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_idfsBasicSyndromicSurveillanceType = "idfsBasicSyndromicSurveillanceType";
        internal const string _str_strBasicSyndromicSurveillanceType = "strBasicSyndromicSurveillanceType";
        internal const string _str_idfHospital = "idfHospital";
        internal const string _str_strHospital = "strHospital";
        internal const string _str_datReportDate = "datReportDate";
        internal const string _str_strFirstName = "strFirstName";
        internal const string _str_strLastName = "strLastName";
        internal const string _str_PatientName = "PatientName";
        internal const string _str_intAgeYear = "intAgeYear";
        internal const string _str_intAgeMonth = "intAgeMonth";
        internal const string _str_intAgeFullYear = "intAgeFullYear";
        internal const string _str_intAgeFullMonth = "intAgeFullMonth";
        internal const string _str_strPersonalID = "strPersonalID";
        internal const string _str_idfsYNPregnant = "idfsYNPregnant";
        internal const string _str_idfsYNPostpartumPeriod = "idfsYNPostpartumPeriod";
        internal const string _str_datDateOfSymptomsOnset = "datDateOfSymptomsOnset";
        internal const string _str_idfsYNFever = "idfsYNFever";
        internal const string _str_idfsMethodOfMeasurement = "idfsMethodOfMeasurement";
        internal const string _str_strMethodOfMeasurement = "strMethodOfMeasurement";
        internal const string _str_strMethod = "strMethod";
        internal const string _str_idfsYNCough = "idfsYNCough";
        internal const string _str_idfsYNShortnessOfBreath = "idfsYNShortnessOfBreath";
        internal const string _str_idfsYNSeasonalFluVaccine = "idfsYNSeasonalFluVaccine";
        internal const string _str_datDateOfCare = "datDateOfCare";
        internal const string _str_idfsYNPatientWasHospitalized = "idfsYNPatientWasHospitalized";
        internal const string _str_idfsOutcome = "idfsOutcome";
        internal const string _str_idfsYNPatientWasInER = "idfsYNPatientWasInER";
        internal const string _str_idfsYNTreatment = "idfsYNTreatment";
        internal const string _str_idfsYNAdministratedAntiviralMedication = "idfsYNAdministratedAntiviralMedication";
        internal const string _str_strNameOfMedication = "strNameOfMedication";
        internal const string _str_datDateReceivedAntiviralMedication = "datDateReceivedAntiviralMedication";
        internal const string _str_blnRespiratorySystem = "blnRespiratorySystem";
        internal const string _str_blnAsthma = "blnAsthma";
        internal const string _str_blnDiabetes = "blnDiabetes";
        internal const string _str_blnCardiovascular = "blnCardiovascular";
        internal const string _str_blnObesity = "blnObesity";
        internal const string _str_blnRenal = "blnRenal";
        internal const string _str_blnLiver = "blnLiver";
        internal const string _str_blnNeurological = "blnNeurological";
        internal const string _str_blnImmunodeficiency = "blnImmunodeficiency";
        internal const string _str_blnUnknownEtiology = "blnUnknownEtiology";
        internal const string _str_datSampleCollectionDate = "datSampleCollectionDate";
        internal const string _str_strSampleID = "strSampleID";
        internal const string _str_idfsTestResult = "idfsTestResult";
        internal const string _str_strTestResult = "strTestResult";
        internal const string _str_datTestResultDate = "datTestResultDate";
        internal const string _str_datModificationForArchiveDate = "datModificationForArchiveDate";
        internal const string _str_intRowStatus = "intRowStatus";
        internal const string _str_idfHuman = "idfHuman";
        internal const string _str_idfsHumanGender = "idfsHumanGender";
        internal const string _str_strGender = "strGender";
        internal const string _str_strAddress = "strAddress";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_strAge = "strAge";
        internal const string _str_BSSType = "BSSType";
        internal const string _str_Hospital = "Hospital";
        internal const string _str_Gender = "Gender";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_TestResult = "TestResult";
        internal const string _str_Site = "Site";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfBasicSyndromicSurveillance, _formname = _str_idfBasicSyndromicSurveillance, _type = "Int64",
              _get_func = o => o.idfBasicSyndromicSurveillance,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfBasicSyndromicSurveillance != newval) o.idfBasicSyndromicSurveillance = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfBasicSyndromicSurveillance != c.idfBasicSyndromicSurveillance || o.IsRIRPropChanged(_str_idfBasicSyndromicSurveillance, c)) 
                  m.Add(_str_idfBasicSyndromicSurveillance, o.ObjectIdent + _str_idfBasicSyndromicSurveillance, o.ObjectIdent2 + _str_idfBasicSyndromicSurveillance, o.ObjectIdent3 + _str_idfBasicSyndromicSurveillance, "Int64", 
                    o.idfBasicSyndromicSurveillance == null ? "" : o.idfBasicSyndromicSurveillance.ToString(),                  
                  o.IsReadOnly(_str_idfBasicSyndromicSurveillance), o.IsInvisible(_str_idfBasicSyndromicSurveillance), o.IsRequired(_str_idfBasicSyndromicSurveillance)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFormID, _formname = _str_strFormID, _type = "String",
              _get_func = o => o.strFormID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFormID != newval) o.strFormID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFormID != c.strFormID || o.IsRIRPropChanged(_str_strFormID, c)) 
                  m.Add(_str_strFormID, o.ObjectIdent + _str_strFormID, o.ObjectIdent2 + _str_strFormID, o.ObjectIdent3 + _str_strFormID, "String", 
                    o.strFormID == null ? "" : o.strFormID.ToString(),                  
                  o.IsReadOnly(_str_strFormID), o.IsInvisible(_str_strFormID), o.IsRequired(_str_strFormID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDateEntered, _formname = _str_datDateEntered, _type = "DateTime",
              _get_func = o => o.datDateEntered,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTime(val); if (o.datDateEntered != newval) o.datDateEntered = newval; },
              _compare_func = (o, c, m) => {
                if (o.datDateEntered != c.datDateEntered || o.IsRIRPropChanged(_str_datDateEntered, c)) 
                  m.Add(_str_datDateEntered, o.ObjectIdent + _str_datDateEntered, o.ObjectIdent2 + _str_datDateEntered, o.ObjectIdent3 + _str_datDateEntered, "DateTime", 
                    o.datDateEntered == null ? "" : o.datDateEntered.ToString(),                  
                  o.IsReadOnly(_str_datDateEntered), o.IsInvisible(_str_datDateEntered), o.IsRequired(_str_datDateEntered)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDateLastSaved, _formname = _str_datDateLastSaved, _type = "DateTime",
              _get_func = o => o.datDateLastSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTime(val); if (o.datDateLastSaved != newval) o.datDateLastSaved = newval; },
              _compare_func = (o, c, m) => {
                if (o.datDateLastSaved != c.datDateLastSaved || o.IsRIRPropChanged(_str_datDateLastSaved, c)) 
                  m.Add(_str_datDateLastSaved, o.ObjectIdent + _str_datDateLastSaved, o.ObjectIdent2 + _str_datDateLastSaved, o.ObjectIdent3 + _str_datDateLastSaved, "DateTime", 
                    o.datDateLastSaved == null ? "" : o.datDateLastSaved.ToString(),                  
                  o.IsReadOnly(_str_datDateLastSaved), o.IsInvisible(_str_datDateLastSaved), o.IsRequired(_str_datDateLastSaved)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfEnteredBy, _formname = _str_idfEnteredBy, _type = "Int64",
              _get_func = o => o.idfEnteredBy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfEnteredBy != newval) o.idfEnteredBy = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfEnteredBy != c.idfEnteredBy || o.IsRIRPropChanged(_str_idfEnteredBy, c)) 
                  m.Add(_str_idfEnteredBy, o.ObjectIdent + _str_idfEnteredBy, o.ObjectIdent2 + _str_idfEnteredBy, o.ObjectIdent3 + _str_idfEnteredBy, "Int64", 
                    o.idfEnteredBy == null ? "" : o.idfEnteredBy.ToString(),                  
                  o.IsReadOnly(_str_idfEnteredBy), o.IsInvisible(_str_idfEnteredBy), o.IsRequired(_str_idfEnteredBy)); 
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
              _name = _str_idfsBasicSyndromicSurveillanceType, _formname = _str_idfsBasicSyndromicSurveillanceType, _type = "Int64?",
              _get_func = o => o.idfsBasicSyndromicSurveillanceType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsBasicSyndromicSurveillanceType != newval) 
                  o.BSSType = o.BSSTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsBasicSyndromicSurveillanceType != newval) o.idfsBasicSyndromicSurveillanceType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsBasicSyndromicSurveillanceType != c.idfsBasicSyndromicSurveillanceType || o.IsRIRPropChanged(_str_idfsBasicSyndromicSurveillanceType, c)) 
                  m.Add(_str_idfsBasicSyndromicSurveillanceType, o.ObjectIdent + _str_idfsBasicSyndromicSurveillanceType, o.ObjectIdent2 + _str_idfsBasicSyndromicSurveillanceType, o.ObjectIdent3 + _str_idfsBasicSyndromicSurveillanceType, "Int64?", 
                    o.idfsBasicSyndromicSurveillanceType == null ? "" : o.idfsBasicSyndromicSurveillanceType.ToString(),                  
                  o.IsReadOnly(_str_idfsBasicSyndromicSurveillanceType), o.IsInvisible(_str_idfsBasicSyndromicSurveillanceType), o.IsRequired(_str_idfsBasicSyndromicSurveillanceType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strBasicSyndromicSurveillanceType, _formname = _str_strBasicSyndromicSurveillanceType, _type = "String",
              _get_func = o => o.strBasicSyndromicSurveillanceType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strBasicSyndromicSurveillanceType != newval) o.strBasicSyndromicSurveillanceType = newval; },
              _compare_func = (o, c, m) => {
                if (o.strBasicSyndromicSurveillanceType != c.strBasicSyndromicSurveillanceType || o.IsRIRPropChanged(_str_strBasicSyndromicSurveillanceType, c)) 
                  m.Add(_str_strBasicSyndromicSurveillanceType, o.ObjectIdent + _str_strBasicSyndromicSurveillanceType, o.ObjectIdent2 + _str_strBasicSyndromicSurveillanceType, o.ObjectIdent3 + _str_strBasicSyndromicSurveillanceType, "String", 
                    o.strBasicSyndromicSurveillanceType == null ? "" : o.strBasicSyndromicSurveillanceType.ToString(),                  
                  o.IsReadOnly(_str_strBasicSyndromicSurveillanceType), o.IsInvisible(_str_strBasicSyndromicSurveillanceType), o.IsRequired(_str_strBasicSyndromicSurveillanceType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfHospital, _formname = _str_idfHospital, _type = "Int64?",
              _get_func = o => o.idfHospital,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfHospital != newval) 
                  o.Hospital = o.HospitalLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfHospital != newval) o.idfHospital = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfHospital != c.idfHospital || o.IsRIRPropChanged(_str_idfHospital, c)) 
                  m.Add(_str_idfHospital, o.ObjectIdent + _str_idfHospital, o.ObjectIdent2 + _str_idfHospital, o.ObjectIdent3 + _str_idfHospital, "Int64?", 
                    o.idfHospital == null ? "" : o.idfHospital.ToString(),                  
                  o.IsReadOnly(_str_idfHospital), o.IsInvisible(_str_idfHospital), o.IsRequired(_str_idfHospital)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHospital, _formname = _str_strHospital, _type = "String",
              _get_func = o => o.strHospital,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHospital != newval) o.strHospital = newval; },
              _compare_func = (o, c, m) => {
                if (o.strHospital != c.strHospital || o.IsRIRPropChanged(_str_strHospital, c)) 
                  m.Add(_str_strHospital, o.ObjectIdent + _str_strHospital, o.ObjectIdent2 + _str_strHospital, o.ObjectIdent3 + _str_strHospital, "String", 
                    o.strHospital == null ? "" : o.strHospital.ToString(),                  
                  o.IsReadOnly(_str_strHospital), o.IsInvisible(_str_strHospital), o.IsRequired(_str_strHospital)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datReportDate, _formname = _str_datReportDate, _type = "DateTime?",
              _get_func = o => o.datReportDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datReportDate != newval) o.datReportDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datReportDate != c.datReportDate || o.IsRIRPropChanged(_str_datReportDate, c)) 
                  m.Add(_str_datReportDate, o.ObjectIdent + _str_datReportDate, o.ObjectIdent2 + _str_datReportDate, o.ObjectIdent3 + _str_datReportDate, "DateTime?", 
                    o.datReportDate == null ? "" : o.datReportDate.ToString(),                  
                  o.IsReadOnly(_str_datReportDate), o.IsInvisible(_str_datReportDate), o.IsRequired(_str_datReportDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFirstName, _formname = _str_strFirstName, _type = "String",
              _get_func = o => o.strFirstName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFirstName != newval) o.strFirstName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFirstName != c.strFirstName || o.IsRIRPropChanged(_str_strFirstName, c)) 
                  m.Add(_str_strFirstName, o.ObjectIdent + _str_strFirstName, o.ObjectIdent2 + _str_strFirstName, o.ObjectIdent3 + _str_strFirstName, "String", 
                    o.strFirstName == null ? "" : o.strFirstName.ToString(),                  
                  o.IsReadOnly(_str_strFirstName), o.IsInvisible(_str_strFirstName), o.IsRequired(_str_strFirstName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strLastName, _formname = _str_strLastName, _type = "String",
              _get_func = o => o.strLastName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strLastName != newval) o.strLastName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strLastName != c.strLastName || o.IsRIRPropChanged(_str_strLastName, c)) 
                  m.Add(_str_strLastName, o.ObjectIdent + _str_strLastName, o.ObjectIdent2 + _str_strLastName, o.ObjectIdent3 + _str_strLastName, "String", 
                    o.strLastName == null ? "" : o.strLastName.ToString(),                  
                  o.IsReadOnly(_str_strLastName), o.IsInvisible(_str_strLastName), o.IsRequired(_str_strLastName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_PatientName, _formname = _str_PatientName, _type = "String",
              _get_func = o => o.PatientName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.PatientName != newval) o.PatientName = newval; },
              _compare_func = (o, c, m) => {
                if (o.PatientName != c.PatientName || o.IsRIRPropChanged(_str_PatientName, c)) 
                  m.Add(_str_PatientName, o.ObjectIdent + _str_PatientName, o.ObjectIdent2 + _str_PatientName, o.ObjectIdent3 + _str_PatientName, "String", 
                    o.PatientName == null ? "" : o.PatientName.ToString(),                  
                  o.IsReadOnly(_str_PatientName), o.IsInvisible(_str_PatientName), o.IsRequired(_str_PatientName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intAgeYear, _formname = _str_intAgeYear, _type = "Int32?",
              _get_func = o => o.intAgeYear,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intAgeYear != newval) o.intAgeYear = newval; },
              _compare_func = (o, c, m) => {
                if (o.intAgeYear != c.intAgeYear || o.IsRIRPropChanged(_str_intAgeYear, c)) 
                  m.Add(_str_intAgeYear, o.ObjectIdent + _str_intAgeYear, o.ObjectIdent2 + _str_intAgeYear, o.ObjectIdent3 + _str_intAgeYear, "Int32?", 
                    o.intAgeYear == null ? "" : o.intAgeYear.ToString(),                  
                  o.IsReadOnly(_str_intAgeYear), o.IsInvisible(_str_intAgeYear), o.IsRequired(_str_intAgeYear)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intAgeMonth, _formname = _str_intAgeMonth, _type = "Int32?",
              _get_func = o => o.intAgeMonth,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intAgeMonth != newval) o.intAgeMonth = newval; },
              _compare_func = (o, c, m) => {
                if (o.intAgeMonth != c.intAgeMonth || o.IsRIRPropChanged(_str_intAgeMonth, c)) 
                  m.Add(_str_intAgeMonth, o.ObjectIdent + _str_intAgeMonth, o.ObjectIdent2 + _str_intAgeMonth, o.ObjectIdent3 + _str_intAgeMonth, "Int32?", 
                    o.intAgeMonth == null ? "" : o.intAgeMonth.ToString(),                  
                  o.IsReadOnly(_str_intAgeMonth), o.IsInvisible(_str_intAgeMonth), o.IsRequired(_str_intAgeMonth)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intAgeFullYear, _formname = _str_intAgeFullYear, _type = "Int32?",
              _get_func = o => o.intAgeFullYear,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intAgeFullYear != newval) o.intAgeFullYear = newval; },
              _compare_func = (o, c, m) => {
                if (o.intAgeFullYear != c.intAgeFullYear || o.IsRIRPropChanged(_str_intAgeFullYear, c)) 
                  m.Add(_str_intAgeFullYear, o.ObjectIdent + _str_intAgeFullYear, o.ObjectIdent2 + _str_intAgeFullYear, o.ObjectIdent3 + _str_intAgeFullYear, "Int32?", 
                    o.intAgeFullYear == null ? "" : o.intAgeFullYear.ToString(),                  
                  o.IsReadOnly(_str_intAgeFullYear), o.IsInvisible(_str_intAgeFullYear), o.IsRequired(_str_intAgeFullYear)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intAgeFullMonth, _formname = _str_intAgeFullMonth, _type = "Int32?",
              _get_func = o => o.intAgeFullMonth,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intAgeFullMonth != newval) o.intAgeFullMonth = newval; },
              _compare_func = (o, c, m) => {
                if (o.intAgeFullMonth != c.intAgeFullMonth || o.IsRIRPropChanged(_str_intAgeFullMonth, c)) 
                  m.Add(_str_intAgeFullMonth, o.ObjectIdent + _str_intAgeFullMonth, o.ObjectIdent2 + _str_intAgeFullMonth, o.ObjectIdent3 + _str_intAgeFullMonth, "Int32?", 
                    o.intAgeFullMonth == null ? "" : o.intAgeFullMonth.ToString(),                  
                  o.IsReadOnly(_str_intAgeFullMonth), o.IsInvisible(_str_intAgeFullMonth), o.IsRequired(_str_intAgeFullMonth)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPersonalID, _formname = _str_strPersonalID, _type = "String",
              _get_func = o => o.strPersonalID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPersonalID != newval) o.strPersonalID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPersonalID != c.strPersonalID || o.IsRIRPropChanged(_str_strPersonalID, c)) 
                  m.Add(_str_strPersonalID, o.ObjectIdent + _str_strPersonalID, o.ObjectIdent2 + _str_strPersonalID, o.ObjectIdent3 + _str_strPersonalID, "String", 
                    o.strPersonalID == null ? "" : o.strPersonalID.ToString(),                  
                  o.IsReadOnly(_str_strPersonalID), o.IsInvisible(_str_strPersonalID), o.IsRequired(_str_strPersonalID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsYNPregnant, _formname = _str_idfsYNPregnant, _type = "Int64?",
              _get_func = o => o.idfsYNPregnant,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsYNPregnant != newval) o.idfsYNPregnant = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsYNPregnant != c.idfsYNPregnant || o.IsRIRPropChanged(_str_idfsYNPregnant, c)) 
                  m.Add(_str_idfsYNPregnant, o.ObjectIdent + _str_idfsYNPregnant, o.ObjectIdent2 + _str_idfsYNPregnant, o.ObjectIdent3 + _str_idfsYNPregnant, "Int64?", 
                    o.idfsYNPregnant == null ? "" : o.idfsYNPregnant.ToString(),                  
                  o.IsReadOnly(_str_idfsYNPregnant), o.IsInvisible(_str_idfsYNPregnant), o.IsRequired(_str_idfsYNPregnant)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsYNPostpartumPeriod, _formname = _str_idfsYNPostpartumPeriod, _type = "Int64?",
              _get_func = o => o.idfsYNPostpartumPeriod,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsYNPostpartumPeriod != newval) o.idfsYNPostpartumPeriod = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsYNPostpartumPeriod != c.idfsYNPostpartumPeriod || o.IsRIRPropChanged(_str_idfsYNPostpartumPeriod, c)) 
                  m.Add(_str_idfsYNPostpartumPeriod, o.ObjectIdent + _str_idfsYNPostpartumPeriod, o.ObjectIdent2 + _str_idfsYNPostpartumPeriod, o.ObjectIdent3 + _str_idfsYNPostpartumPeriod, "Int64?", 
                    o.idfsYNPostpartumPeriod == null ? "" : o.idfsYNPostpartumPeriod.ToString(),                  
                  o.IsReadOnly(_str_idfsYNPostpartumPeriod), o.IsInvisible(_str_idfsYNPostpartumPeriod), o.IsRequired(_str_idfsYNPostpartumPeriod)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDateOfSymptomsOnset, _formname = _str_datDateOfSymptomsOnset, _type = "DateTime?",
              _get_func = o => o.datDateOfSymptomsOnset,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDateOfSymptomsOnset != newval) o.datDateOfSymptomsOnset = newval; },
              _compare_func = (o, c, m) => {
                if (o.datDateOfSymptomsOnset != c.datDateOfSymptomsOnset || o.IsRIRPropChanged(_str_datDateOfSymptomsOnset, c)) 
                  m.Add(_str_datDateOfSymptomsOnset, o.ObjectIdent + _str_datDateOfSymptomsOnset, o.ObjectIdent2 + _str_datDateOfSymptomsOnset, o.ObjectIdent3 + _str_datDateOfSymptomsOnset, "DateTime?", 
                    o.datDateOfSymptomsOnset == null ? "" : o.datDateOfSymptomsOnset.ToString(),                  
                  o.IsReadOnly(_str_datDateOfSymptomsOnset), o.IsInvisible(_str_datDateOfSymptomsOnset), o.IsRequired(_str_datDateOfSymptomsOnset)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsYNFever, _formname = _str_idfsYNFever, _type = "Int64?",
              _get_func = o => o.idfsYNFever,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsYNFever != newval) o.idfsYNFever = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsYNFever != c.idfsYNFever || o.IsRIRPropChanged(_str_idfsYNFever, c)) 
                  m.Add(_str_idfsYNFever, o.ObjectIdent + _str_idfsYNFever, o.ObjectIdent2 + _str_idfsYNFever, o.ObjectIdent3 + _str_idfsYNFever, "Int64?", 
                    o.idfsYNFever == null ? "" : o.idfsYNFever.ToString(),                  
                  o.IsReadOnly(_str_idfsYNFever), o.IsInvisible(_str_idfsYNFever), o.IsRequired(_str_idfsYNFever)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsMethodOfMeasurement, _formname = _str_idfsMethodOfMeasurement, _type = "Int64?",
              _get_func = o => o.idfsMethodOfMeasurement,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsMethodOfMeasurement != newval) o.idfsMethodOfMeasurement = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsMethodOfMeasurement != c.idfsMethodOfMeasurement || o.IsRIRPropChanged(_str_idfsMethodOfMeasurement, c)) 
                  m.Add(_str_idfsMethodOfMeasurement, o.ObjectIdent + _str_idfsMethodOfMeasurement, o.ObjectIdent2 + _str_idfsMethodOfMeasurement, o.ObjectIdent3 + _str_idfsMethodOfMeasurement, "Int64?", 
                    o.idfsMethodOfMeasurement == null ? "" : o.idfsMethodOfMeasurement.ToString(),                  
                  o.IsReadOnly(_str_idfsMethodOfMeasurement), o.IsInvisible(_str_idfsMethodOfMeasurement), o.IsRequired(_str_idfsMethodOfMeasurement)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strMethodOfMeasurement, _formname = _str_strMethodOfMeasurement, _type = "String",
              _get_func = o => o.strMethodOfMeasurement,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strMethodOfMeasurement != newval) o.strMethodOfMeasurement = newval; },
              _compare_func = (o, c, m) => {
                if (o.strMethodOfMeasurement != c.strMethodOfMeasurement || o.IsRIRPropChanged(_str_strMethodOfMeasurement, c)) 
                  m.Add(_str_strMethodOfMeasurement, o.ObjectIdent + _str_strMethodOfMeasurement, o.ObjectIdent2 + _str_strMethodOfMeasurement, o.ObjectIdent3 + _str_strMethodOfMeasurement, "String", 
                    o.strMethodOfMeasurement == null ? "" : o.strMethodOfMeasurement.ToString(),                  
                  o.IsReadOnly(_str_strMethodOfMeasurement), o.IsInvisible(_str_strMethodOfMeasurement), o.IsRequired(_str_strMethodOfMeasurement)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strMethod, _formname = _str_strMethod, _type = "String",
              _get_func = o => o.strMethod,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strMethod != newval) o.strMethod = newval; },
              _compare_func = (o, c, m) => {
                if (o.strMethod != c.strMethod || o.IsRIRPropChanged(_str_strMethod, c)) 
                  m.Add(_str_strMethod, o.ObjectIdent + _str_strMethod, o.ObjectIdent2 + _str_strMethod, o.ObjectIdent3 + _str_strMethod, "String", 
                    o.strMethod == null ? "" : o.strMethod.ToString(),                  
                  o.IsReadOnly(_str_strMethod), o.IsInvisible(_str_strMethod), o.IsRequired(_str_strMethod)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsYNCough, _formname = _str_idfsYNCough, _type = "Int64?",
              _get_func = o => o.idfsYNCough,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsYNCough != newval) o.idfsYNCough = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsYNCough != c.idfsYNCough || o.IsRIRPropChanged(_str_idfsYNCough, c)) 
                  m.Add(_str_idfsYNCough, o.ObjectIdent + _str_idfsYNCough, o.ObjectIdent2 + _str_idfsYNCough, o.ObjectIdent3 + _str_idfsYNCough, "Int64?", 
                    o.idfsYNCough == null ? "" : o.idfsYNCough.ToString(),                  
                  o.IsReadOnly(_str_idfsYNCough), o.IsInvisible(_str_idfsYNCough), o.IsRequired(_str_idfsYNCough)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsYNShortnessOfBreath, _formname = _str_idfsYNShortnessOfBreath, _type = "Int64?",
              _get_func = o => o.idfsYNShortnessOfBreath,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsYNShortnessOfBreath != newval) o.idfsYNShortnessOfBreath = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsYNShortnessOfBreath != c.idfsYNShortnessOfBreath || o.IsRIRPropChanged(_str_idfsYNShortnessOfBreath, c)) 
                  m.Add(_str_idfsYNShortnessOfBreath, o.ObjectIdent + _str_idfsYNShortnessOfBreath, o.ObjectIdent2 + _str_idfsYNShortnessOfBreath, o.ObjectIdent3 + _str_idfsYNShortnessOfBreath, "Int64?", 
                    o.idfsYNShortnessOfBreath == null ? "" : o.idfsYNShortnessOfBreath.ToString(),                  
                  o.IsReadOnly(_str_idfsYNShortnessOfBreath), o.IsInvisible(_str_idfsYNShortnessOfBreath), o.IsRequired(_str_idfsYNShortnessOfBreath)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsYNSeasonalFluVaccine, _formname = _str_idfsYNSeasonalFluVaccine, _type = "Int64?",
              _get_func = o => o.idfsYNSeasonalFluVaccine,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsYNSeasonalFluVaccine != newval) o.idfsYNSeasonalFluVaccine = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsYNSeasonalFluVaccine != c.idfsYNSeasonalFluVaccine || o.IsRIRPropChanged(_str_idfsYNSeasonalFluVaccine, c)) 
                  m.Add(_str_idfsYNSeasonalFluVaccine, o.ObjectIdent + _str_idfsYNSeasonalFluVaccine, o.ObjectIdent2 + _str_idfsYNSeasonalFluVaccine, o.ObjectIdent3 + _str_idfsYNSeasonalFluVaccine, "Int64?", 
                    o.idfsYNSeasonalFluVaccine == null ? "" : o.idfsYNSeasonalFluVaccine.ToString(),                  
                  o.IsReadOnly(_str_idfsYNSeasonalFluVaccine), o.IsInvisible(_str_idfsYNSeasonalFluVaccine), o.IsRequired(_str_idfsYNSeasonalFluVaccine)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDateOfCare, _formname = _str_datDateOfCare, _type = "DateTime?",
              _get_func = o => o.datDateOfCare,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDateOfCare != newval) o.datDateOfCare = newval; },
              _compare_func = (o, c, m) => {
                if (o.datDateOfCare != c.datDateOfCare || o.IsRIRPropChanged(_str_datDateOfCare, c)) 
                  m.Add(_str_datDateOfCare, o.ObjectIdent + _str_datDateOfCare, o.ObjectIdent2 + _str_datDateOfCare, o.ObjectIdent3 + _str_datDateOfCare, "DateTime?", 
                    o.datDateOfCare == null ? "" : o.datDateOfCare.ToString(),                  
                  o.IsReadOnly(_str_datDateOfCare), o.IsInvisible(_str_datDateOfCare), o.IsRequired(_str_datDateOfCare)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsYNPatientWasHospitalized, _formname = _str_idfsYNPatientWasHospitalized, _type = "Int64?",
              _get_func = o => o.idfsYNPatientWasHospitalized,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsYNPatientWasHospitalized != newval) o.idfsYNPatientWasHospitalized = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsYNPatientWasHospitalized != c.idfsYNPatientWasHospitalized || o.IsRIRPropChanged(_str_idfsYNPatientWasHospitalized, c)) 
                  m.Add(_str_idfsYNPatientWasHospitalized, o.ObjectIdent + _str_idfsYNPatientWasHospitalized, o.ObjectIdent2 + _str_idfsYNPatientWasHospitalized, o.ObjectIdent3 + _str_idfsYNPatientWasHospitalized, "Int64?", 
                    o.idfsYNPatientWasHospitalized == null ? "" : o.idfsYNPatientWasHospitalized.ToString(),                  
                  o.IsReadOnly(_str_idfsYNPatientWasHospitalized), o.IsInvisible(_str_idfsYNPatientWasHospitalized), o.IsRequired(_str_idfsYNPatientWasHospitalized)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsOutcome, _formname = _str_idfsOutcome, _type = "Int64?",
              _get_func = o => o.idfsOutcome,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsOutcome != newval) o.idfsOutcome = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsOutcome != c.idfsOutcome || o.IsRIRPropChanged(_str_idfsOutcome, c)) 
                  m.Add(_str_idfsOutcome, o.ObjectIdent + _str_idfsOutcome, o.ObjectIdent2 + _str_idfsOutcome, o.ObjectIdent3 + _str_idfsOutcome, "Int64?", 
                    o.idfsOutcome == null ? "" : o.idfsOutcome.ToString(),                  
                  o.IsReadOnly(_str_idfsOutcome), o.IsInvisible(_str_idfsOutcome), o.IsRequired(_str_idfsOutcome)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsYNPatientWasInER, _formname = _str_idfsYNPatientWasInER, _type = "Int64?",
              _get_func = o => o.idfsYNPatientWasInER,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsYNPatientWasInER != newval) o.idfsYNPatientWasInER = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsYNPatientWasInER != c.idfsYNPatientWasInER || o.IsRIRPropChanged(_str_idfsYNPatientWasInER, c)) 
                  m.Add(_str_idfsYNPatientWasInER, o.ObjectIdent + _str_idfsYNPatientWasInER, o.ObjectIdent2 + _str_idfsYNPatientWasInER, o.ObjectIdent3 + _str_idfsYNPatientWasInER, "Int64?", 
                    o.idfsYNPatientWasInER == null ? "" : o.idfsYNPatientWasInER.ToString(),                  
                  o.IsReadOnly(_str_idfsYNPatientWasInER), o.IsInvisible(_str_idfsYNPatientWasInER), o.IsRequired(_str_idfsYNPatientWasInER)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsYNTreatment, _formname = _str_idfsYNTreatment, _type = "Int64?",
              _get_func = o => o.idfsYNTreatment,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsYNTreatment != newval) o.idfsYNTreatment = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsYNTreatment != c.idfsYNTreatment || o.IsRIRPropChanged(_str_idfsYNTreatment, c)) 
                  m.Add(_str_idfsYNTreatment, o.ObjectIdent + _str_idfsYNTreatment, o.ObjectIdent2 + _str_idfsYNTreatment, o.ObjectIdent3 + _str_idfsYNTreatment, "Int64?", 
                    o.idfsYNTreatment == null ? "" : o.idfsYNTreatment.ToString(),                  
                  o.IsReadOnly(_str_idfsYNTreatment), o.IsInvisible(_str_idfsYNTreatment), o.IsRequired(_str_idfsYNTreatment)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsYNAdministratedAntiviralMedication, _formname = _str_idfsYNAdministratedAntiviralMedication, _type = "Int64?",
              _get_func = o => o.idfsYNAdministratedAntiviralMedication,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsYNAdministratedAntiviralMedication != newval) o.idfsYNAdministratedAntiviralMedication = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsYNAdministratedAntiviralMedication != c.idfsYNAdministratedAntiviralMedication || o.IsRIRPropChanged(_str_idfsYNAdministratedAntiviralMedication, c)) 
                  m.Add(_str_idfsYNAdministratedAntiviralMedication, o.ObjectIdent + _str_idfsYNAdministratedAntiviralMedication, o.ObjectIdent2 + _str_idfsYNAdministratedAntiviralMedication, o.ObjectIdent3 + _str_idfsYNAdministratedAntiviralMedication, "Int64?", 
                    o.idfsYNAdministratedAntiviralMedication == null ? "" : o.idfsYNAdministratedAntiviralMedication.ToString(),                  
                  o.IsReadOnly(_str_idfsYNAdministratedAntiviralMedication), o.IsInvisible(_str_idfsYNAdministratedAntiviralMedication), o.IsRequired(_str_idfsYNAdministratedAntiviralMedication)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strNameOfMedication, _formname = _str_strNameOfMedication, _type = "String",
              _get_func = o => o.strNameOfMedication,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strNameOfMedication != newval) o.strNameOfMedication = newval; },
              _compare_func = (o, c, m) => {
                if (o.strNameOfMedication != c.strNameOfMedication || o.IsRIRPropChanged(_str_strNameOfMedication, c)) 
                  m.Add(_str_strNameOfMedication, o.ObjectIdent + _str_strNameOfMedication, o.ObjectIdent2 + _str_strNameOfMedication, o.ObjectIdent3 + _str_strNameOfMedication, "String", 
                    o.strNameOfMedication == null ? "" : o.strNameOfMedication.ToString(),                  
                  o.IsReadOnly(_str_strNameOfMedication), o.IsInvisible(_str_strNameOfMedication), o.IsRequired(_str_strNameOfMedication)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDateReceivedAntiviralMedication, _formname = _str_datDateReceivedAntiviralMedication, _type = "DateTime?",
              _get_func = o => o.datDateReceivedAntiviralMedication,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDateReceivedAntiviralMedication != newval) o.datDateReceivedAntiviralMedication = newval; },
              _compare_func = (o, c, m) => {
                if (o.datDateReceivedAntiviralMedication != c.datDateReceivedAntiviralMedication || o.IsRIRPropChanged(_str_datDateReceivedAntiviralMedication, c)) 
                  m.Add(_str_datDateReceivedAntiviralMedication, o.ObjectIdent + _str_datDateReceivedAntiviralMedication, o.ObjectIdent2 + _str_datDateReceivedAntiviralMedication, o.ObjectIdent3 + _str_datDateReceivedAntiviralMedication, "DateTime?", 
                    o.datDateReceivedAntiviralMedication == null ? "" : o.datDateReceivedAntiviralMedication.ToString(),                  
                  o.IsReadOnly(_str_datDateReceivedAntiviralMedication), o.IsInvisible(_str_datDateReceivedAntiviralMedication), o.IsRequired(_str_datDateReceivedAntiviralMedication)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnRespiratorySystem, _formname = _str_blnRespiratorySystem, _type = "Boolean",
              _get_func = o => o.blnRespiratorySystem,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnRespiratorySystem != newval) o.blnRespiratorySystem = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnRespiratorySystem != c.blnRespiratorySystem || o.IsRIRPropChanged(_str_blnRespiratorySystem, c)) 
                  m.Add(_str_blnRespiratorySystem, o.ObjectIdent + _str_blnRespiratorySystem, o.ObjectIdent2 + _str_blnRespiratorySystem, o.ObjectIdent3 + _str_blnRespiratorySystem, "Boolean", 
                    o.blnRespiratorySystem == null ? "" : o.blnRespiratorySystem.ToString(),                  
                  o.IsReadOnly(_str_blnRespiratorySystem), o.IsInvisible(_str_blnRespiratorySystem), o.IsRequired(_str_blnRespiratorySystem)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnAsthma, _formname = _str_blnAsthma, _type = "Boolean",
              _get_func = o => o.blnAsthma,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnAsthma != newval) o.blnAsthma = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnAsthma != c.blnAsthma || o.IsRIRPropChanged(_str_blnAsthma, c)) 
                  m.Add(_str_blnAsthma, o.ObjectIdent + _str_blnAsthma, o.ObjectIdent2 + _str_blnAsthma, o.ObjectIdent3 + _str_blnAsthma, "Boolean", 
                    o.blnAsthma == null ? "" : o.blnAsthma.ToString(),                  
                  o.IsReadOnly(_str_blnAsthma), o.IsInvisible(_str_blnAsthma), o.IsRequired(_str_blnAsthma)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnDiabetes, _formname = _str_blnDiabetes, _type = "Boolean",
              _get_func = o => o.blnDiabetes,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnDiabetes != newval) o.blnDiabetes = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnDiabetes != c.blnDiabetes || o.IsRIRPropChanged(_str_blnDiabetes, c)) 
                  m.Add(_str_blnDiabetes, o.ObjectIdent + _str_blnDiabetes, o.ObjectIdent2 + _str_blnDiabetes, o.ObjectIdent3 + _str_blnDiabetes, "Boolean", 
                    o.blnDiabetes == null ? "" : o.blnDiabetes.ToString(),                  
                  o.IsReadOnly(_str_blnDiabetes), o.IsInvisible(_str_blnDiabetes), o.IsRequired(_str_blnDiabetes)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnCardiovascular, _formname = _str_blnCardiovascular, _type = "Boolean",
              _get_func = o => o.blnCardiovascular,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnCardiovascular != newval) o.blnCardiovascular = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnCardiovascular != c.blnCardiovascular || o.IsRIRPropChanged(_str_blnCardiovascular, c)) 
                  m.Add(_str_blnCardiovascular, o.ObjectIdent + _str_blnCardiovascular, o.ObjectIdent2 + _str_blnCardiovascular, o.ObjectIdent3 + _str_blnCardiovascular, "Boolean", 
                    o.blnCardiovascular == null ? "" : o.blnCardiovascular.ToString(),                  
                  o.IsReadOnly(_str_blnCardiovascular), o.IsInvisible(_str_blnCardiovascular), o.IsRequired(_str_blnCardiovascular)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnObesity, _formname = _str_blnObesity, _type = "Boolean",
              _get_func = o => o.blnObesity,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnObesity != newval) o.blnObesity = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnObesity != c.blnObesity || o.IsRIRPropChanged(_str_blnObesity, c)) 
                  m.Add(_str_blnObesity, o.ObjectIdent + _str_blnObesity, o.ObjectIdent2 + _str_blnObesity, o.ObjectIdent3 + _str_blnObesity, "Boolean", 
                    o.blnObesity == null ? "" : o.blnObesity.ToString(),                  
                  o.IsReadOnly(_str_blnObesity), o.IsInvisible(_str_blnObesity), o.IsRequired(_str_blnObesity)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnRenal, _formname = _str_blnRenal, _type = "Boolean",
              _get_func = o => o.blnRenal,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnRenal != newval) o.blnRenal = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnRenal != c.blnRenal || o.IsRIRPropChanged(_str_blnRenal, c)) 
                  m.Add(_str_blnRenal, o.ObjectIdent + _str_blnRenal, o.ObjectIdent2 + _str_blnRenal, o.ObjectIdent3 + _str_blnRenal, "Boolean", 
                    o.blnRenal == null ? "" : o.blnRenal.ToString(),                  
                  o.IsReadOnly(_str_blnRenal), o.IsInvisible(_str_blnRenal), o.IsRequired(_str_blnRenal)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnLiver, _formname = _str_blnLiver, _type = "Boolean",
              _get_func = o => o.blnLiver,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnLiver != newval) o.blnLiver = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnLiver != c.blnLiver || o.IsRIRPropChanged(_str_blnLiver, c)) 
                  m.Add(_str_blnLiver, o.ObjectIdent + _str_blnLiver, o.ObjectIdent2 + _str_blnLiver, o.ObjectIdent3 + _str_blnLiver, "Boolean", 
                    o.blnLiver == null ? "" : o.blnLiver.ToString(),                  
                  o.IsReadOnly(_str_blnLiver), o.IsInvisible(_str_blnLiver), o.IsRequired(_str_blnLiver)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnNeurological, _formname = _str_blnNeurological, _type = "Boolean",
              _get_func = o => o.blnNeurological,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnNeurological != newval) o.blnNeurological = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnNeurological != c.blnNeurological || o.IsRIRPropChanged(_str_blnNeurological, c)) 
                  m.Add(_str_blnNeurological, o.ObjectIdent + _str_blnNeurological, o.ObjectIdent2 + _str_blnNeurological, o.ObjectIdent3 + _str_blnNeurological, "Boolean", 
                    o.blnNeurological == null ? "" : o.blnNeurological.ToString(),                  
                  o.IsReadOnly(_str_blnNeurological), o.IsInvisible(_str_blnNeurological), o.IsRequired(_str_blnNeurological)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnImmunodeficiency, _formname = _str_blnImmunodeficiency, _type = "Boolean",
              _get_func = o => o.blnImmunodeficiency,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnImmunodeficiency != newval) o.blnImmunodeficiency = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnImmunodeficiency != c.blnImmunodeficiency || o.IsRIRPropChanged(_str_blnImmunodeficiency, c)) 
                  m.Add(_str_blnImmunodeficiency, o.ObjectIdent + _str_blnImmunodeficiency, o.ObjectIdent2 + _str_blnImmunodeficiency, o.ObjectIdent3 + _str_blnImmunodeficiency, "Boolean", 
                    o.blnImmunodeficiency == null ? "" : o.blnImmunodeficiency.ToString(),                  
                  o.IsReadOnly(_str_blnImmunodeficiency), o.IsInvisible(_str_blnImmunodeficiency), o.IsRequired(_str_blnImmunodeficiency)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnUnknownEtiology, _formname = _str_blnUnknownEtiology, _type = "Boolean",
              _get_func = o => o.blnUnknownEtiology,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnUnknownEtiology != newval) o.blnUnknownEtiology = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnUnknownEtiology != c.blnUnknownEtiology || o.IsRIRPropChanged(_str_blnUnknownEtiology, c)) 
                  m.Add(_str_blnUnknownEtiology, o.ObjectIdent + _str_blnUnknownEtiology, o.ObjectIdent2 + _str_blnUnknownEtiology, o.ObjectIdent3 + _str_blnUnknownEtiology, "Boolean", 
                    o.blnUnknownEtiology == null ? "" : o.blnUnknownEtiology.ToString(),                  
                  o.IsReadOnly(_str_blnUnknownEtiology), o.IsInvisible(_str_blnUnknownEtiology), o.IsRequired(_str_blnUnknownEtiology)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datSampleCollectionDate, _formname = _str_datSampleCollectionDate, _type = "DateTime?",
              _get_func = o => o.datSampleCollectionDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datSampleCollectionDate != newval) o.datSampleCollectionDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datSampleCollectionDate != c.datSampleCollectionDate || o.IsRIRPropChanged(_str_datSampleCollectionDate, c)) 
                  m.Add(_str_datSampleCollectionDate, o.ObjectIdent + _str_datSampleCollectionDate, o.ObjectIdent2 + _str_datSampleCollectionDate, o.ObjectIdent3 + _str_datSampleCollectionDate, "DateTime?", 
                    o.datSampleCollectionDate == null ? "" : o.datSampleCollectionDate.ToString(),                  
                  o.IsReadOnly(_str_datSampleCollectionDate), o.IsInvisible(_str_datSampleCollectionDate), o.IsRequired(_str_datSampleCollectionDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSampleID, _formname = _str_strSampleID, _type = "String",
              _get_func = o => o.strSampleID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSampleID != newval) o.strSampleID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSampleID != c.strSampleID || o.IsRIRPropChanged(_str_strSampleID, c)) 
                  m.Add(_str_strSampleID, o.ObjectIdent + _str_strSampleID, o.ObjectIdent2 + _str_strSampleID, o.ObjectIdent3 + _str_strSampleID, "String", 
                    o.strSampleID == null ? "" : o.strSampleID.ToString(),                  
                  o.IsReadOnly(_str_strSampleID), o.IsInvisible(_str_strSampleID), o.IsRequired(_str_strSampleID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestResult, _formname = _str_idfsTestResult, _type = "Int64?",
              _get_func = o => o.idfsTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsTestResult != newval) 
                  o.TestResult = o.TestResultLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsTestResult != newval) o.idfsTestResult = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_idfsTestResult, c)) 
                  m.Add(_str_idfsTestResult, o.ObjectIdent + _str_idfsTestResult, o.ObjectIdent2 + _str_idfsTestResult, o.ObjectIdent3 + _str_idfsTestResult, "Int64?", 
                    o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(),                  
                  o.IsReadOnly(_str_idfsTestResult), o.IsInvisible(_str_idfsTestResult), o.IsRequired(_str_idfsTestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTestResult, _formname = _str_strTestResult, _type = "String",
              _get_func = o => o.strTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTestResult != newval) o.strTestResult = newval; },
              _compare_func = (o, c, m) => {
                if (o.strTestResult != c.strTestResult || o.IsRIRPropChanged(_str_strTestResult, c)) 
                  m.Add(_str_strTestResult, o.ObjectIdent + _str_strTestResult, o.ObjectIdent2 + _str_strTestResult, o.ObjectIdent3 + _str_strTestResult, "String", 
                    o.strTestResult == null ? "" : o.strTestResult.ToString(),                  
                  o.IsReadOnly(_str_strTestResult), o.IsInvisible(_str_strTestResult), o.IsRequired(_str_strTestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datTestResultDate, _formname = _str_datTestResultDate, _type = "DateTime?",
              _get_func = o => o.datTestResultDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datTestResultDate != newval) o.datTestResultDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datTestResultDate != c.datTestResultDate || o.IsRIRPropChanged(_str_datTestResultDate, c)) 
                  m.Add(_str_datTestResultDate, o.ObjectIdent + _str_datTestResultDate, o.ObjectIdent2 + _str_datTestResultDate, o.ObjectIdent3 + _str_datTestResultDate, "DateTime?", 
                    o.datTestResultDate == null ? "" : o.datTestResultDate.ToString(),                  
                  o.IsReadOnly(_str_datTestResultDate), o.IsInvisible(_str_datTestResultDate), o.IsRequired(_str_datTestResultDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datModificationForArchiveDate, _formname = _str_datModificationForArchiveDate, _type = "DateTime?",
              _get_func = o => o.datModificationForArchiveDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datModificationForArchiveDate != newval) o.datModificationForArchiveDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datModificationForArchiveDate != c.datModificationForArchiveDate || o.IsRIRPropChanged(_str_datModificationForArchiveDate, c)) 
                  m.Add(_str_datModificationForArchiveDate, o.ObjectIdent + _str_datModificationForArchiveDate, o.ObjectIdent2 + _str_datModificationForArchiveDate, o.ObjectIdent3 + _str_datModificationForArchiveDate, "DateTime?", 
                    o.datModificationForArchiveDate == null ? "" : o.datModificationForArchiveDate.ToString(),                  
                  o.IsReadOnly(_str_datModificationForArchiveDate), o.IsInvisible(_str_datModificationForArchiveDate), o.IsRequired(_str_datModificationForArchiveDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRowStatus, _formname = _str_intRowStatus, _type = "Int32",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intRowStatus != newval) o.intRowStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, o.ObjectIdent2 + _str_intRowStatus, o.ObjectIdent3 + _str_intRowStatus, "Int32", 
                    o.intRowStatus == null ? "" : o.intRowStatus.ToString(),                  
                  o.IsReadOnly(_str_intRowStatus), o.IsInvisible(_str_intRowStatus), o.IsRequired(_str_intRowStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfHuman, _formname = _str_idfHuman, _type = "Int64?",
              _get_func = o => o.idfHuman,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfHuman != newval) o.idfHuman = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfHuman != c.idfHuman || o.IsRIRPropChanged(_str_idfHuman, c)) 
                  m.Add(_str_idfHuman, o.ObjectIdent + _str_idfHuman, o.ObjectIdent2 + _str_idfHuman, o.ObjectIdent3 + _str_idfHuman, "Int64?", 
                    o.idfHuman == null ? "" : o.idfHuman.ToString(),                  
                  o.IsReadOnly(_str_idfHuman), o.IsInvisible(_str_idfHuman), o.IsRequired(_str_idfHuman)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsHumanGender, _formname = _str_idfsHumanGender, _type = "Int64?",
              _get_func = o => o.idfsHumanGender,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsHumanGender != newval) 
                  o.Gender = o.GenderLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsHumanGender != newval) o.idfsHumanGender = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsHumanGender != c.idfsHumanGender || o.IsRIRPropChanged(_str_idfsHumanGender, c)) 
                  m.Add(_str_idfsHumanGender, o.ObjectIdent + _str_idfsHumanGender, o.ObjectIdent2 + _str_idfsHumanGender, o.ObjectIdent3 + _str_idfsHumanGender, "Int64?", 
                    o.idfsHumanGender == null ? "" : o.idfsHumanGender.ToString(),                  
                  o.IsReadOnly(_str_idfsHumanGender), o.IsInvisible(_str_idfsHumanGender), o.IsRequired(_str_idfsHumanGender)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strGender, _formname = _str_strGender, _type = "String",
              _get_func = o => o.strGender,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strGender != newval) o.strGender = newval; },
              _compare_func = (o, c, m) => {
                if (o.strGender != c.strGender || o.IsRIRPropChanged(_str_strGender, c)) 
                  m.Add(_str_strGender, o.ObjectIdent + _str_strGender, o.ObjectIdent2 + _str_strGender, o.ObjectIdent3 + _str_strGender, "String", 
                    o.strGender == null ? "" : o.strGender.ToString(),                  
                  o.IsReadOnly(_str_strGender), o.IsInvisible(_str_strGender), o.IsRequired(_str_strGender)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strAddress, _formname = _str_strAddress, _type = "String",
              _get_func = o => o.strAddress,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAddress != newval) o.strAddress = newval; },
              _compare_func = (o, c, m) => {
                if (o.strAddress != c.strAddress || o.IsRIRPropChanged(_str_strAddress, c)) 
                  m.Add(_str_strAddress, o.ObjectIdent + _str_strAddress, o.ObjectIdent2 + _str_strAddress, o.ObjectIdent3 + _str_strAddress, "String", 
                    o.strAddress == null ? "" : o.strAddress.ToString(),                  
                  o.IsReadOnly(_str_strAddress), o.IsInvisible(_str_strAddress), o.IsRequired(_str_strAddress)); 
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
              _name = _str_idfsCountry, _formname = _str_idfsCountry, _type = "Int64?",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsCountry != newval) 
                  o.Country = o.CountryLookup.FirstOrDefault(c => c.idfsCountry == newval);
                if (o.idfsCountry != newval) o.idfsCountry = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) 
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, o.ObjectIdent2 + _str_idfsCountry, o.ObjectIdent3 + _str_idfsCountry, "Int64?", 
                    o.idfsCountry == null ? "" : o.idfsCountry.ToString(),                  
                  o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry)); 
                  }
              }, 
        
            new field_info {
              _name = _str_strAge, _formname = _str_strAge, _type = "string",
              _get_func = o => o.strAge,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strAge != c.strAge || o.IsRIRPropChanged(_str_strAge, c)) {
                  m.Add(_str_strAge, o.ObjectIdent + _str_strAge, o.ObjectIdent2 + _str_strAge, o.ObjectIdent3 + _str_strAge, "string", o.strAge == null ? "" : o.strAge.ToString(), o.IsReadOnly(_str_strAge), o.IsInvisible(_str_strAge), o.IsRequired(_str_strAge));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_BSSType, _formname = _str_BSSType, _type = "Lookup",
              _get_func = o => { if (o.BSSType == null) return null; return o.BSSType.idfsBaseReference; },
              _set_func = (o, val) => { o.BSSType = o.BSSTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsBasicSyndromicSurveillanceType != c.idfsBasicSyndromicSurveillanceType || o.IsRIRPropChanged(_str_BSSType, c)) {
                  m.Add(_str_BSSType, o.ObjectIdent + _str_BSSType, o.ObjectIdent2 + _str_BSSType, o.ObjectIdent3 + _str_BSSType, "Lookup", o.idfsBasicSyndromicSurveillanceType == null ? "" : o.idfsBasicSyndromicSurveillanceType.ToString(), o.IsReadOnly(_str_BSSType), o.IsInvisible(_str_BSSType), o.IsRequired(_str_BSSType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_BSSType + "Lookup", _formname = _str_BSSType + "Lookup", _type = "LookupContent",
              _get_func = o => o.BSSTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Hospital, _formname = _str_Hospital, _type = "Lookup",
              _get_func = o => { if (o.Hospital == null) return null; return o.Hospital.idfInstitution; },
              _set_func = (o, val) => { o.Hospital = o.HospitalLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfHospital != c.idfHospital || o.IsRIRPropChanged(_str_Hospital, c)) {
                  m.Add(_str_Hospital, o.ObjectIdent + _str_Hospital, o.ObjectIdent2 + _str_Hospital, o.ObjectIdent3 + _str_Hospital, "Lookup", o.idfHospital == null ? "" : o.idfHospital.ToString(), o.IsReadOnly(_str_Hospital), o.IsInvisible(_str_Hospital), o.IsRequired(_str_Hospital)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Hospital + "Lookup", _formname = _str_Hospital + "Lookup", _type = "LookupContent",
              _get_func = o => o.HospitalLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Gender, _formname = _str_Gender, _type = "Lookup",
              _get_func = o => { if (o.Gender == null) return null; return o.Gender.idfsBaseReference; },
              _set_func = (o, val) => { o.Gender = o.GenderLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsHumanGender != c.idfsHumanGender || o.IsRIRPropChanged(_str_Gender, c)) {
                  m.Add(_str_Gender, o.ObjectIdent + _str_Gender, o.ObjectIdent2 + _str_Gender, o.ObjectIdent3 + _str_Gender, "Lookup", o.idfsHumanGender == null ? "" : o.idfsHumanGender.ToString(), o.IsReadOnly(_str_Gender), o.IsInvisible(_str_Gender), o.IsRequired(_str_Gender)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Gender + "Lookup", _formname = _str_Gender + "Lookup", _type = "LookupContent",
              _get_func = o => o.GenderLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
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
              _name = _str_TestResult, _formname = _str_TestResult, _type = "Lookup",
              _get_func = o => { if (o.TestResult == null) return null; return o.TestResult.idfsBaseReference; },
              _set_func = (o, val) => { o.TestResult = o.TestResultLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_TestResult, c)) {
                  m.Add(_str_TestResult, o.ObjectIdent + _str_TestResult, o.ObjectIdent2 + _str_TestResult, o.ObjectIdent3 + _str_TestResult, "Lookup", o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(), o.IsReadOnly(_str_TestResult), o.IsInvisible(_str_TestResult), o.IsRequired(_str_TestResult)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestResult + "Lookup", _formname = _str_TestResult + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestResultLookup,
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
            BasicSyndromicSurveillanceListItem obj = (BasicSyndromicSurveillanceListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_BSSType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsBasicSyndromicSurveillanceType)]
        public BaseReference BSSType
        {
            get { return _BSSType == null ? null : ((long)_BSSType.Key == 0 ? null : _BSSType); }
            set 
            { 
                var oldVal = _BSSType;
                _BSSType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_BSSType != oldVal)
                {
                    if (idfsBasicSyndromicSurveillanceType != (_BSSType == null
                            ? new Int64?()
                            : (Int64?)_BSSType.idfsBaseReference))
                        idfsBasicSyndromicSurveillanceType = _BSSType == null 
                            ? new Int64?()
                            : (Int64?)_BSSType.idfsBaseReference; 
                    OnPropertyChanged(_str_BSSType); 
                }
            }
        }
        private BaseReference _BSSType;

        
        public BaseReferenceList BSSTypeLookup
        {
            get { return _BSSTypeLookup; }
        }
        private BaseReferenceList _BSSTypeLookup = new BaseReferenceList("rftBssType");
            
        [LocalizedDisplayName(_str_Hospital)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfHospital)]
        public OrganizationLookup Hospital
        {
            get { return _Hospital == null ? null : ((long)_Hospital.Key == 0 ? null : _Hospital); }
            set 
            { 
                var oldVal = _Hospital;
                _Hospital = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Hospital != oldVal)
                {
                    if (idfHospital != (_Hospital == null
                            ? new Int64?()
                            : (Int64?)_Hospital.idfInstitution))
                        idfHospital = _Hospital == null 
                            ? new Int64?()
                            : (Int64?)_Hospital.idfInstitution; 
                    OnPropertyChanged(_str_Hospital); 
                }
            }
        }
        private OrganizationLookup _Hospital;

        
        public List<OrganizationLookup> HospitalLookup
        {
            get { return _HospitalLookup; }
        }
        private List<OrganizationLookup> _HospitalLookup = new List<OrganizationLookup>();
            
        [LocalizedDisplayName(_str_Gender)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsHumanGender)]
        public BaseReference Gender
        {
            get { return _Gender == null ? null : ((long)_Gender.Key == 0 ? null : _Gender); }
            set 
            { 
                var oldVal = _Gender;
                _Gender = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Gender != oldVal)
                {
                    if (idfsHumanGender != (_Gender == null
                            ? new Int64?()
                            : (Int64?)_Gender.idfsBaseReference))
                        idfsHumanGender = _Gender == null 
                            ? new Int64?()
                            : (Int64?)_Gender.idfsBaseReference; 
                    OnPropertyChanged(_str_Gender); 
                }
            }
        }
        private BaseReference _Gender;

        
        public BaseReferenceList GenderLookup
        {
            get { return _GenderLookup; }
        }
        private BaseReferenceList _GenderLookup = new BaseReferenceList("rftHumanGender");
            
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
            
        [LocalizedDisplayName(_str_TestResult)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestResult)]
        public BaseReference TestResult
        {
            get { return _TestResult == null ? null : ((long)_TestResult.Key == 0 ? null : _TestResult); }
            set 
            { 
                var oldVal = _TestResult;
                _TestResult = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestResult != oldVal)
                {
                    if (idfsTestResult != (_TestResult == null
                            ? new Int64?()
                            : (Int64?)_TestResult.idfsBaseReference))
                        idfsTestResult = _TestResult == null 
                            ? new Int64?()
                            : (Int64?)_TestResult.idfsBaseReference; 
                    OnPropertyChanged(_str_TestResult); 
                }
            }
        }
        private BaseReference _TestResult;

        
        public BaseReferenceList TestResultLookup
        {
            get { return _TestResultLookup; }
        }
        private BaseReferenceList _TestResultLookup = new BaseReferenceList("rftBssTestResult");
            
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
            
                case _str_BSSType:
                    return new BvSelectList(BSSTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, BSSType, _str_idfsBasicSyndromicSurveillanceType);
            
                case _str_Hospital:
                    return new BvSelectList(HospitalLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, Hospital, _str_idfHospital);
            
                case _str_Gender:
                    return new BvSelectList(GenderLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Gender, _str_idfsHumanGender);
            
                case _str_Country:
                    return new BvSelectList(CountryLookup, eidss.model.Schema.CountryLookup._str_idfsCountry, null, Country, _str_idfsCountry);
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionLookup._str_idfsRegion, null, Region, _str_idfsRegion);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonLookup._str_idfsRayon, null, Rayon, _str_idfsRayon);
            
                case _str_Settlement:
                    return new BvSelectList(SettlementLookup, eidss.model.Schema.SettlementLookup._str_idfsSettlement, null, Settlement, _str_idfsSettlement);
            
                case _str_TestResult:
                    return new BvSelectList(TestResultLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestResult, _str_idfsTestResult);
            
                case _str_Site:
                    return new BvSelectList(SiteLookup, eidss.model.Schema.SiteLookup._str_idfsSite, null, Site, _str_idfsSite);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName("Age")]
        public string strAge
        {
            get { return new Func<BasicSyndromicSurveillanceListItem, string>(c=> c.FormatAge())(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "BasicSyndromicSurveillanceListItem";

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
            var ret = base.Clone() as BasicSyndromicSurveillanceListItem;
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
            var ret = base.Clone() as BasicSyndromicSurveillanceListItem;
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
        public BasicSyndromicSurveillanceListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as BasicSyndromicSurveillanceListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfBasicSyndromicSurveillance; } }
        public string KeyName { get { return "idfBasicSyndromicSurveillance"; } }
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
        
            var _prev_idfsBasicSyndromicSurveillanceType_BSSType = idfsBasicSyndromicSurveillanceType;
            var _prev_idfHospital_Hospital = idfHospital;
            var _prev_idfsHumanGender_Gender = idfsHumanGender;
            var _prev_idfsCountry_Country = idfsCountry;
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            var _prev_idfsSettlement_Settlement = idfsSettlement;
            var _prev_idfsTestResult_TestResult = idfsTestResult;
            var _prev_idfsSite_Site = idfsSite;
            base.RejectChanges();
        
            if (_prev_idfsBasicSyndromicSurveillanceType_BSSType != idfsBasicSyndromicSurveillanceType)
            {
                _BSSType = _BSSTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsBasicSyndromicSurveillanceType);
            }
            if (_prev_idfHospital_Hospital != idfHospital)
            {
                _Hospital = _HospitalLookup.FirstOrDefault(c => c.idfInstitution == idfHospital);
            }
            if (_prev_idfsHumanGender_Gender != idfsHumanGender)
            {
                _Gender = _GenderLookup.FirstOrDefault(c => c.idfsBaseReference == idfsHumanGender);
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
            if (_prev_idfsTestResult_TestResult != idfsTestResult)
            {
                _TestResult = _TestResultLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestResult);
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

        private bool IsRIRPropChanged(string fld, BasicSyndromicSurveillanceListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public BasicSyndromicSurveillanceListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(BasicSyndromicSurveillanceListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(BasicSyndromicSurveillanceListItem_PropertyChanged);
        }
        private void BasicSyndromicSurveillanceListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as BasicSyndromicSurveillanceListItem).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_intAgeYear)
                OnPropertyChanged(_str_strAge);
                  
            if (e.PropertyName == _str_intAgeMonth)
                OnPropertyChanged(_str_strAge);
                  
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
            BasicSyndromicSurveillanceListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            BasicSyndromicSurveillanceListItem obj = this;
            
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

    
        private static string[] readonly_names1 = "Region,idfsRegion".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "Rayon,idfsRayon".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "Settlement,idfsSettlement".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<BasicSyndromicSurveillanceListItem, bool>(c => c.idfsCountry == null)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<BasicSyndromicSurveillanceListItem, bool>(c => c.idfsRegion == null)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<BasicSyndromicSurveillanceListItem, bool>(c => c.idfsRayon == null)(this);
            
            return ReadOnly || new Func<BasicSyndromicSurveillanceListItem, bool>(c => false)(this);
                
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


        internal Dictionary<string, Func<BasicSyndromicSurveillanceListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<BasicSyndromicSurveillanceListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<BasicSyndromicSurveillanceListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<BasicSyndromicSurveillanceListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<BasicSyndromicSurveillanceListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<BasicSyndromicSurveillanceListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<BasicSyndromicSurveillanceListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~BasicSyndromicSurveillanceListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftBssType", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("rftHumanGender", this);
                
                LookupManager.RemoveObject("CountryLookup", this);
                
                LookupManager.RemoveObject("RegionLookup", this);
                
                LookupManager.RemoveObject("RayonLookup", this);
                
                LookupManager.RemoveObject("SettlementLookup", this);
                
                LookupManager.RemoveObject("rftBssTestResult", this);
                
                LookupManager.RemoveObject("SiteLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftBssType")
                _getAccessor().LoadLookup_BSSType(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_Hospital(manager, this);
            
            if (lookup_object == "rftHumanGender")
                _getAccessor().LoadLookup_Gender(manager, this);
            
            if (lookup_object == "CountryLookup")
                _getAccessor().LoadLookup_Country(manager, this);
            
            if (lookup_object == "RegionLookup")
                _getAccessor().LoadLookup_Region(manager, this);
            
            if (lookup_object == "RayonLookup")
                _getAccessor().LoadLookup_Rayon(manager, this);
            
            if (lookup_object == "SettlementLookup")
                _getAccessor().LoadLookup_Settlement(manager, this);
            
            if (lookup_object == "rftBssTestResult")
                _getAccessor().LoadLookup_TestResult(manager, this);
            
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
        public class BasicSyndromicSurveillanceListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfBasicSyndromicSurveillance { get; set; }
        
            public String strFormID { get; set; }
        
            public Int64? idfsBasicSyndromicSurveillanceType { get; set; }
        
            public String strBasicSyndromicSurveillanceType { get; set; }
        
            public String strHospital { get; set; }
        
            public DateTime? datReportDate { get; set; }
        
            public DateTime? datDateOfSymptomsOnset { get; set; }
        
            public String PatientName { get; set; }
        
            public String strGender { get; set; }
        
            public string strAge { get; set; }
        
            public String strAddress { get; set; }
        
            public String strTestResult { get; set; }
        
        }
        public partial class BasicSyndromicSurveillanceListItemGridModelList : List<BasicSyndromicSurveillanceListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public BasicSyndromicSurveillanceListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<BasicSyndromicSurveillanceListItem>, errMes);
            }
            public BasicSyndromicSurveillanceListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<BasicSyndromicSurveillanceListItem>, errMes);
            }
            public BasicSyndromicSurveillanceListItemGridModelList(long key, IEnumerable<BasicSyndromicSurveillanceListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public BasicSyndromicSurveillanceListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<BasicSyndromicSurveillanceListItem>(), null);
            }
            partial void filter(List<BasicSyndromicSurveillanceListItem> items);
            private void LoadGridModelList(long key, IEnumerable<BasicSyndromicSurveillanceListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strFormID,_str_strBasicSyndromicSurveillanceType,_str_strHospital,_str_datReportDate,_str_datDateOfSymptomsOnset,_str_PatientName,_str_strGender,_str_strAge,_str_strAddress,_str_strTestResult};
                    
                Hiddens = new List<string> {_str_idfBasicSyndromicSurveillance,_str_idfsBasicSyndromicSurveillanceType};
                Keys = new List<string> {_str_idfBasicSyndromicSurveillance};
                Labels = new Dictionary<string, string> {{_str_strFormID, _str_strFormID},{_str_strBasicSyndromicSurveillanceType, "idfsBasicSyndromicSurveillanceType"},{_str_strHospital, _str_strHospital},{_str_datReportDate, _str_datReportDate},{_str_datDateOfSymptomsOnset, _str_datDateOfSymptomsOnset},{_str_PatientName, _str_PatientName},{_str_strGender, _str_strGender},{_str_strAge, "Age"},{_str_strAddress, "AddressName"},{_str_strTestResult, "TestResult"}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strFormID, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "ActionEditBSS")}};
                BasicSyndromicSurveillanceListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<BasicSyndromicSurveillanceListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new BasicSyndromicSurveillanceListItemGridModel()
                {
                    ItemKey=c.idfBasicSyndromicSurveillance,strFormID=c.strFormID,idfsBasicSyndromicSurveillanceType=c.idfsBasicSyndromicSurveillanceType,strBasicSyndromicSurveillanceType=c.strBasicSyndromicSurveillanceType,strHospital=c.strHospital,datReportDate=c.datReportDate,datDateOfSymptomsOnset=c.datDateOfSymptomsOnset,PatientName=c.PatientName,strGender=c.strGender,strAge=c.strAge,strAddress=c.strAddress,strTestResult=c.strTestResult
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
        : DataAccessor<BasicSyndromicSurveillanceListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<BasicSyndromicSurveillanceListItem>
            
            , IObjectSelectList
            , IObjectSelectList<BasicSyndromicSurveillanceListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfBasicSyndromicSurveillance"; } }
            #endregion
        
            private delegate void on_action(BasicSyndromicSurveillanceListItem obj);
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
            private BaseReference.Accessor BSSTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor HospitalAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor GenderAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private CountryLookup.Accessor CountryAccessor { get { return eidss.model.Schema.CountryLookup.Accessor.Instance(m_CS); } }
            private RegionLookup.Accessor RegionAccessor { get { return eidss.model.Schema.RegionLookup.Accessor.Instance(m_CS); } }
            private RayonLookup.Accessor RayonAccessor { get { return eidss.model.Schema.RayonLookup.Accessor.Instance(m_CS); } }
            private SettlementLookup.Accessor SettlementAccessor { get { return eidss.model.Schema.SettlementLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestResultAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private SiteLookup.Accessor SiteAccessor { get { return eidss.model.Schema.SiteLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<BasicSyndromicSurveillanceListItem> SelectListT(DbManagerProxy manager
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
            
            private List<BasicSyndromicSurveillanceListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_BasicSyndromicSurveillance_SelectList.* from dbo.fn_BasicSyndromicSurveillance_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (ModelUserContext.IsWebContext && EidssSiteContext.Instance.SiteType == SiteType.TLVL)
                {
                    sql.Append(@" and exists (select * from  tflBasicSyndromicSurveillanceFiltered f inner join tflSiteToSiteGroup on tflSiteToSiteGroup.idfSiteGroup = f.idfSiteGroup and tflSiteToSiteGroup.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString() + " where f.idfBasicSyndromicSurveillance = fn_BasicSyndromicSurveillance_SelectList.idfBasicSyndromicSurveillance)");
                }
                
                if (filters.Contains("idfBasicSyndromicSurveillance"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfBasicSyndromicSurveillance"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfBasicSyndromicSurveillance") ? " or " : " and ");
                        
                        if (filters.Operation("idfBasicSyndromicSurveillance", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfBasicSyndromicSurveillance,0) {0} @idfBasicSyndromicSurveillance_{1} = @idfBasicSyndromicSurveillance_{1})", filters.Operation("idfBasicSyndromicSurveillance", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfBasicSyndromicSurveillance,0) {0} @idfBasicSyndromicSurveillance_{1}", filters.Operation("idfBasicSyndromicSurveillance", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFormID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFormID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFormID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.strFormID {0} @strFormID_{1}", filters.Operation("strFormID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datDateEntered"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datDateEntered"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datDateEntered") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_BasicSyndromicSurveillance_SelectList.datDateEntered, 112) {0} CONVERT(NVARCHAR(8), @datDateEntered_{1}, 112)", filters.Operation("datDateEntered", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datDateLastSaved"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datDateLastSaved"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datDateLastSaved") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_BasicSyndromicSurveillance_SelectList.datDateLastSaved, 112) {0} CONVERT(NVARCHAR(8), @datDateLastSaved_{1}, 112)", filters.Operation("datDateLastSaved", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfEnteredBy"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfEnteredBy"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfEnteredBy") ? " or " : " and ");
                        
                        if (filters.Operation("idfEnteredBy", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfEnteredBy,0) {0} @idfEnteredBy_{1} = @idfEnteredBy_{1})", filters.Operation("idfEnteredBy", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfEnteredBy,0) {0} @idfEnteredBy_{1}", filters.Operation("idfEnteredBy", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsSite,0) {0} @idfsSite_{1} = @idfsSite_{1})", filters.Operation("idfsSite", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsSite,0) {0} @idfsSite_{1}", filters.Operation("idfsSite", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsBasicSyndromicSurveillanceType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsBasicSyndromicSurveillanceType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsBasicSyndromicSurveillanceType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsBasicSyndromicSurveillanceType", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsBasicSyndromicSurveillanceType,0) {0} @idfsBasicSyndromicSurveillanceType_{1} = @idfsBasicSyndromicSurveillanceType_{1})", filters.Operation("idfsBasicSyndromicSurveillanceType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsBasicSyndromicSurveillanceType,0) {0} @idfsBasicSyndromicSurveillanceType_{1}", filters.Operation("idfsBasicSyndromicSurveillanceType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strBasicSyndromicSurveillanceType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strBasicSyndromicSurveillanceType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strBasicSyndromicSurveillanceType") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.strBasicSyndromicSurveillanceType {0} @strBasicSyndromicSurveillanceType_{1}", filters.Operation("strBasicSyndromicSurveillanceType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfHospital"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfHospital"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfHospital") ? " or " : " and ");
                        
                        if (filters.Operation("idfHospital", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfHospital,0) {0} @idfHospital_{1} = @idfHospital_{1})", filters.Operation("idfHospital", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfHospital,0) {0} @idfHospital_{1}", filters.Operation("idfHospital", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strHospital"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strHospital"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strHospital") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.strHospital {0} @strHospital_{1}", filters.Operation("strHospital", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_BasicSyndromicSurveillance_SelectList.datReportDate, 112) {0} CONVERT(NVARCHAR(8), @datReportDate_{1}, 112)", filters.Operation("datReportDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFirstName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFirstName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFirstName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.strFirstName {0} @strFirstName_{1}", filters.Operation("strFirstName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strLastName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strLastName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strLastName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.strLastName {0} @strLastName_{1}", filters.Operation("strLastName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("PatientName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("PatientName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("PatientName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.PatientName {0} @PatientName_{1}", filters.Operation("PatientName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intAgeYear"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intAgeYear"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intAgeYear") ? " or " : " and ");
                        
                        if (filters.Operation("intAgeYear", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.intAgeYear,0) {0} @intAgeYear_{1} = @intAgeYear_{1})", filters.Operation("intAgeYear", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.intAgeYear,0) {0} @intAgeYear_{1}", filters.Operation("intAgeYear", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intAgeMonth"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intAgeMonth"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intAgeMonth") ? " or " : " and ");
                        
                        if (filters.Operation("intAgeMonth", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.intAgeMonth,0) {0} @intAgeMonth_{1} = @intAgeMonth_{1})", filters.Operation("intAgeMonth", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.intAgeMonth,0) {0} @intAgeMonth_{1}", filters.Operation("intAgeMonth", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intAgeFullYear"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intAgeFullYear"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intAgeFullYear") ? " or " : " and ");
                        
                        if (filters.Operation("intAgeFullYear", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.intAgeFullYear,0) {0} @intAgeFullYear_{1} = @intAgeFullYear_{1})", filters.Operation("intAgeFullYear", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.intAgeFullYear,0) {0} @intAgeFullYear_{1}", filters.Operation("intAgeFullYear", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intAgeFullMonth"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intAgeFullMonth"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intAgeFullMonth") ? " or " : " and ");
                        
                        if (filters.Operation("intAgeFullMonth", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.intAgeFullMonth,0) {0} @intAgeFullMonth_{1} = @intAgeFullMonth_{1})", filters.Operation("intAgeFullMonth", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.intAgeFullMonth,0) {0} @intAgeFullMonth_{1}", filters.Operation("intAgeFullMonth", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strPersonalID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strPersonalID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strPersonalID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.strPersonalID {0} @strPersonalID_{1}", filters.Operation("strPersonalID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsYNPregnant"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsYNPregnant"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsYNPregnant") ? " or " : " and ");
                        
                        if (filters.Operation("idfsYNPregnant", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNPregnant,0) {0} @idfsYNPregnant_{1} = @idfsYNPregnant_{1})", filters.Operation("idfsYNPregnant", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNPregnant,0) {0} @idfsYNPregnant_{1}", filters.Operation("idfsYNPregnant", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsYNPostpartumPeriod"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsYNPostpartumPeriod"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsYNPostpartumPeriod") ? " or " : " and ");
                        
                        if (filters.Operation("idfsYNPostpartumPeriod", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNPostpartumPeriod,0) {0} @idfsYNPostpartumPeriod_{1} = @idfsYNPostpartumPeriod_{1})", filters.Operation("idfsYNPostpartumPeriod", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNPostpartumPeriod,0) {0} @idfsYNPostpartumPeriod_{1}", filters.Operation("idfsYNPostpartumPeriod", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datDateOfSymptomsOnset"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datDateOfSymptomsOnset"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datDateOfSymptomsOnset") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_BasicSyndromicSurveillance_SelectList.datDateOfSymptomsOnset, 112) {0} CONVERT(NVARCHAR(8), @datDateOfSymptomsOnset_{1}, 112)", filters.Operation("datDateOfSymptomsOnset", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsYNFever"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsYNFever"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsYNFever") ? " or " : " and ");
                        
                        if (filters.Operation("idfsYNFever", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNFever,0) {0} @idfsYNFever_{1} = @idfsYNFever_{1})", filters.Operation("idfsYNFever", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNFever,0) {0} @idfsYNFever_{1}", filters.Operation("idfsYNFever", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsMethodOfMeasurement"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsMethodOfMeasurement"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsMethodOfMeasurement") ? " or " : " and ");
                        
                        if (filters.Operation("idfsMethodOfMeasurement", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsMethodOfMeasurement,0) {0} @idfsMethodOfMeasurement_{1} = @idfsMethodOfMeasurement_{1})", filters.Operation("idfsMethodOfMeasurement", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsMethodOfMeasurement,0) {0} @idfsMethodOfMeasurement_{1}", filters.Operation("idfsMethodOfMeasurement", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strMethodOfMeasurement"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strMethodOfMeasurement"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strMethodOfMeasurement") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.strMethodOfMeasurement {0} @strMethodOfMeasurement_{1}", filters.Operation("strMethodOfMeasurement", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strMethod"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strMethod"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strMethod") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.strMethod {0} @strMethod_{1}", filters.Operation("strMethod", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsYNCough"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsYNCough"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsYNCough") ? " or " : " and ");
                        
                        if (filters.Operation("idfsYNCough", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNCough,0) {0} @idfsYNCough_{1} = @idfsYNCough_{1})", filters.Operation("idfsYNCough", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNCough,0) {0} @idfsYNCough_{1}", filters.Operation("idfsYNCough", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsYNShortnessOfBreath"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsYNShortnessOfBreath"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsYNShortnessOfBreath") ? " or " : " and ");
                        
                        if (filters.Operation("idfsYNShortnessOfBreath", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNShortnessOfBreath,0) {0} @idfsYNShortnessOfBreath_{1} = @idfsYNShortnessOfBreath_{1})", filters.Operation("idfsYNShortnessOfBreath", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNShortnessOfBreath,0) {0} @idfsYNShortnessOfBreath_{1}", filters.Operation("idfsYNShortnessOfBreath", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsYNSeasonalFluVaccine"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsYNSeasonalFluVaccine"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsYNSeasonalFluVaccine") ? " or " : " and ");
                        
                        if (filters.Operation("idfsYNSeasonalFluVaccine", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNSeasonalFluVaccine,0) {0} @idfsYNSeasonalFluVaccine_{1} = @idfsYNSeasonalFluVaccine_{1})", filters.Operation("idfsYNSeasonalFluVaccine", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNSeasonalFluVaccine,0) {0} @idfsYNSeasonalFluVaccine_{1}", filters.Operation("idfsYNSeasonalFluVaccine", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datDateOfCare"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datDateOfCare"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datDateOfCare") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_BasicSyndromicSurveillance_SelectList.datDateOfCare, 112) {0} CONVERT(NVARCHAR(8), @datDateOfCare_{1}, 112)", filters.Operation("datDateOfCare", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsYNPatientWasHospitalized"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsYNPatientWasHospitalized"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsYNPatientWasHospitalized") ? " or " : " and ");
                        
                        if (filters.Operation("idfsYNPatientWasHospitalized", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNPatientWasHospitalized,0) {0} @idfsYNPatientWasHospitalized_{1} = @idfsYNPatientWasHospitalized_{1})", filters.Operation("idfsYNPatientWasHospitalized", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNPatientWasHospitalized,0) {0} @idfsYNPatientWasHospitalized_{1}", filters.Operation("idfsYNPatientWasHospitalized", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsOutcome"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsOutcome"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsOutcome") ? " or " : " and ");
                        
                        if (filters.Operation("idfsOutcome", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsOutcome,0) {0} @idfsOutcome_{1} = @idfsOutcome_{1})", filters.Operation("idfsOutcome", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsOutcome,0) {0} @idfsOutcome_{1}", filters.Operation("idfsOutcome", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsYNPatientWasInER"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsYNPatientWasInER"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsYNPatientWasInER") ? " or " : " and ");
                        
                        if (filters.Operation("idfsYNPatientWasInER", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNPatientWasInER,0) {0} @idfsYNPatientWasInER_{1} = @idfsYNPatientWasInER_{1})", filters.Operation("idfsYNPatientWasInER", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNPatientWasInER,0) {0} @idfsYNPatientWasInER_{1}", filters.Operation("idfsYNPatientWasInER", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsYNTreatment"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsYNTreatment"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsYNTreatment") ? " or " : " and ");
                        
                        if (filters.Operation("idfsYNTreatment", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNTreatment,0) {0} @idfsYNTreatment_{1} = @idfsYNTreatment_{1})", filters.Operation("idfsYNTreatment", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNTreatment,0) {0} @idfsYNTreatment_{1}", filters.Operation("idfsYNTreatment", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsYNAdministratedAntiviralMedication"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsYNAdministratedAntiviralMedication"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsYNAdministratedAntiviralMedication") ? " or " : " and ");
                        
                        if (filters.Operation("idfsYNAdministratedAntiviralMedication", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNAdministratedAntiviralMedication,0) {0} @idfsYNAdministratedAntiviralMedication_{1} = @idfsYNAdministratedAntiviralMedication_{1})", filters.Operation("idfsYNAdministratedAntiviralMedication", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsYNAdministratedAntiviralMedication,0) {0} @idfsYNAdministratedAntiviralMedication_{1}", filters.Operation("idfsYNAdministratedAntiviralMedication", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strNameOfMedication"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strNameOfMedication"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strNameOfMedication") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.strNameOfMedication {0} @strNameOfMedication_{1}", filters.Operation("strNameOfMedication", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datDateReceivedAntiviralMedication"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datDateReceivedAntiviralMedication"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datDateReceivedAntiviralMedication") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_BasicSyndromicSurveillance_SelectList.datDateReceivedAntiviralMedication, 112) {0} CONVERT(NVARCHAR(8), @datDateReceivedAntiviralMedication_{1}, 112)", filters.Operation("datDateReceivedAntiviralMedication", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("blnRespiratorySystem"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("blnRespiratorySystem"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("blnRespiratorySystem") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.blnRespiratorySystem {0} @blnRespiratorySystem_{1}", filters.Operation("blnRespiratorySystem", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("blnAsthma"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("blnAsthma"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("blnAsthma") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.blnAsthma {0} @blnAsthma_{1}", filters.Operation("blnAsthma", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("blnDiabetes"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("blnDiabetes"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("blnDiabetes") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.blnDiabetes {0} @blnDiabetes_{1}", filters.Operation("blnDiabetes", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("blnCardiovascular"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("blnCardiovascular"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("blnCardiovascular") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.blnCardiovascular {0} @blnCardiovascular_{1}", filters.Operation("blnCardiovascular", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("blnObesity"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("blnObesity"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("blnObesity") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.blnObesity {0} @blnObesity_{1}", filters.Operation("blnObesity", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("blnRenal"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("blnRenal"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("blnRenal") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.blnRenal {0} @blnRenal_{1}", filters.Operation("blnRenal", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("blnLiver"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("blnLiver"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("blnLiver") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.blnLiver {0} @blnLiver_{1}", filters.Operation("blnLiver", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("blnNeurological"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("blnNeurological"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("blnNeurological") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.blnNeurological {0} @blnNeurological_{1}", filters.Operation("blnNeurological", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("blnImmunodeficiency"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("blnImmunodeficiency"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("blnImmunodeficiency") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.blnImmunodeficiency {0} @blnImmunodeficiency_{1}", filters.Operation("blnImmunodeficiency", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("blnUnknownEtiology"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("blnUnknownEtiology"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("blnUnknownEtiology") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.blnUnknownEtiology {0} @blnUnknownEtiology_{1}", filters.Operation("blnUnknownEtiology", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datSampleCollectionDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datSampleCollectionDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datSampleCollectionDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_BasicSyndromicSurveillance_SelectList.datSampleCollectionDate, 112) {0} CONVERT(NVARCHAR(8), @datSampleCollectionDate_{1}, 112)", filters.Operation("datSampleCollectionDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSampleID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSampleID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSampleID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.strSampleID {0} @strSampleID_{1}", filters.Operation("strSampleID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsTestResult"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsTestResult"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsTestResult") ? " or " : " and ");
                        
                        if (filters.Operation("idfsTestResult", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsTestResult,0) {0} @idfsTestResult_{1} = @idfsTestResult_{1})", filters.Operation("idfsTestResult", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsTestResult,0) {0} @idfsTestResult_{1}", filters.Operation("idfsTestResult", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strTestResult"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strTestResult"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strTestResult") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.strTestResult {0} @strTestResult_{1}", filters.Operation("strTestResult", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datTestResultDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datTestResultDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datTestResultDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_BasicSyndromicSurveillance_SelectList.datTestResultDate, 112) {0} CONVERT(NVARCHAR(8), @datTestResultDate_{1}, 112)", filters.Operation("datTestResultDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datModificationForArchiveDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datModificationForArchiveDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datModificationForArchiveDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_BasicSyndromicSurveillance_SelectList.datModificationForArchiveDate, 112) {0} CONVERT(NVARCHAR(8), @datModificationForArchiveDate_{1}, 112)", filters.Operation("datModificationForArchiveDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intRowStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intRowStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intRowStatus") ? " or " : " and ");
                        
                        if (filters.Operation("intRowStatus", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.intRowStatus,0) {0} @intRowStatus_{1} = @intRowStatus_{1})", filters.Operation("intRowStatus", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.intRowStatus,0) {0} @intRowStatus_{1}", filters.Operation("intRowStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfHuman"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfHuman"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfHuman") ? " or " : " and ");
                        
                        if (filters.Operation("idfHuman", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfHuman,0) {0} @idfHuman_{1} = @idfHuman_{1})", filters.Operation("idfHuman", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfHuman,0) {0} @idfHuman_{1}", filters.Operation("idfHuman", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsHumanGender"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsHumanGender"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsHumanGender") ? " or " : " and ");
                        
                        if (filters.Operation("idfsHumanGender", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsHumanGender,0) {0} @idfsHumanGender_{1} = @idfsHumanGender_{1})", filters.Operation("idfsHumanGender", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsHumanGender,0) {0} @idfsHumanGender_{1}", filters.Operation("idfsHumanGender", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strGender"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strGender"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strGender") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.strGender {0} @strGender_{1}", filters.Operation("strGender", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strAddress"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strAddress"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strAddress") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillance_SelectList.strAddress {0} @strAddress_{1}", filters.Operation("strAddress", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsSettlement,0) {0} @idfsSettlement_{1} = @idfsSettlement_{1})", filters.Operation("idfsSettlement", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsSettlement,0) {0} @idfsSettlement_{1}", filters.Operation("idfsSettlement", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsRegion,0) {0} @idfsRegion_{1} = @idfsRegion_{1})", filters.Operation("idfsRegion", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsRegion,0) {0} @idfsRegion_{1}", filters.Operation("idfsRegion", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsRayon,0) {0} @idfsRayon_{1} = @idfsRayon_{1})", filters.Operation("idfsRayon", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsRayon,0) {0} @idfsRayon_{1}", filters.Operation("idfsRayon", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillance_SelectList.idfsCountry,0) {0} @idfsCountry_{1} = @idfsCountry_{1})", filters.Operation("idfsCountry", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillance_SelectList.idfsCountry,0) {0} @idfsCountry_{1}", filters.Operation("idfsCountry", i), i);
                            
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
                    
                    if (filters.Contains("idfBasicSyndromicSurveillance"))
                        for (int i = 0; i < filters.Count("idfBasicSyndromicSurveillance"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfBasicSyndromicSurveillance_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfBasicSyndromicSurveillance", i), filters.Value("idfBasicSyndromicSurveillance", i))));
                      
                    if (filters.Contains("strFormID"))
                        for (int i = 0; i < filters.Count("strFormID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFormID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFormID", i), filters.Value("strFormID", i))));
                      
                    if (filters.Contains("datDateEntered"))
                        for (int i = 0; i < filters.Count("datDateEntered"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datDateEntered_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datDateEntered", i), filters.Value("datDateEntered", i))));
                      
                    if (filters.Contains("datDateLastSaved"))
                        for (int i = 0; i < filters.Count("datDateLastSaved"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datDateLastSaved_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datDateLastSaved", i), filters.Value("datDateLastSaved", i))));
                      
                    if (filters.Contains("idfEnteredBy"))
                        for (int i = 0; i < filters.Count("idfEnteredBy"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfEnteredBy_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfEnteredBy", i), filters.Value("idfEnteredBy", i))));
                      
                    if (filters.Contains("idfsSite"))
                        for (int i = 0; i < filters.Count("idfsSite"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSite_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSite", i), filters.Value("idfsSite", i))));
                      
                    if (filters.Contains("idfsBasicSyndromicSurveillanceType"))
                        for (int i = 0; i < filters.Count("idfsBasicSyndromicSurveillanceType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsBasicSyndromicSurveillanceType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsBasicSyndromicSurveillanceType", i), filters.Value("idfsBasicSyndromicSurveillanceType", i))));
                      
                    if (filters.Contains("strBasicSyndromicSurveillanceType"))
                        for (int i = 0; i < filters.Count("strBasicSyndromicSurveillanceType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strBasicSyndromicSurveillanceType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strBasicSyndromicSurveillanceType", i), filters.Value("strBasicSyndromicSurveillanceType", i))));
                      
                    if (filters.Contains("idfHospital"))
                        for (int i = 0; i < filters.Count("idfHospital"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfHospital_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfHospital", i), filters.Value("idfHospital", i))));
                      
                    if (filters.Contains("strHospital"))
                        for (int i = 0; i < filters.Count("strHospital"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strHospital_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strHospital", i), filters.Value("strHospital", i))));
                      
                    if (filters.Contains("datReportDate"))
                        for (int i = 0; i < filters.Count("datReportDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datReportDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datReportDate", i), filters.Value("datReportDate", i))));
                      
                    if (filters.Contains("strFirstName"))
                        for (int i = 0; i < filters.Count("strFirstName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFirstName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFirstName", i), filters.Value("strFirstName", i))));
                      
                    if (filters.Contains("strLastName"))
                        for (int i = 0; i < filters.Count("strLastName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strLastName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strLastName", i), filters.Value("strLastName", i))));
                      
                    if (filters.Contains("PatientName"))
                        for (int i = 0; i < filters.Count("PatientName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@PatientName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("PatientName", i), filters.Value("PatientName", i))));
                      
                    if (filters.Contains("intAgeYear"))
                        for (int i = 0; i < filters.Count("intAgeYear"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intAgeYear_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intAgeYear", i), filters.Value("intAgeYear", i))));
                      
                    if (filters.Contains("intAgeMonth"))
                        for (int i = 0; i < filters.Count("intAgeMonth"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intAgeMonth_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intAgeMonth", i), filters.Value("intAgeMonth", i))));
                      
                    if (filters.Contains("intAgeFullYear"))
                        for (int i = 0; i < filters.Count("intAgeFullYear"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intAgeFullYear_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intAgeFullYear", i), filters.Value("intAgeFullYear", i))));
                      
                    if (filters.Contains("intAgeFullMonth"))
                        for (int i = 0; i < filters.Count("intAgeFullMonth"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intAgeFullMonth_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intAgeFullMonth", i), filters.Value("intAgeFullMonth", i))));
                      
                    if (filters.Contains("strPersonalID"))
                        for (int i = 0; i < filters.Count("strPersonalID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strPersonalID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strPersonalID", i), filters.Value("strPersonalID", i))));
                      
                    if (filters.Contains("idfsYNPregnant"))
                        for (int i = 0; i < filters.Count("idfsYNPregnant"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsYNPregnant_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsYNPregnant", i), filters.Value("idfsYNPregnant", i))));
                      
                    if (filters.Contains("idfsYNPostpartumPeriod"))
                        for (int i = 0; i < filters.Count("idfsYNPostpartumPeriod"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsYNPostpartumPeriod_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsYNPostpartumPeriod", i), filters.Value("idfsYNPostpartumPeriod", i))));
                      
                    if (filters.Contains("datDateOfSymptomsOnset"))
                        for (int i = 0; i < filters.Count("datDateOfSymptomsOnset"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datDateOfSymptomsOnset_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datDateOfSymptomsOnset", i), filters.Value("datDateOfSymptomsOnset", i))));
                      
                    if (filters.Contains("idfsYNFever"))
                        for (int i = 0; i < filters.Count("idfsYNFever"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsYNFever_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsYNFever", i), filters.Value("idfsYNFever", i))));
                      
                    if (filters.Contains("idfsMethodOfMeasurement"))
                        for (int i = 0; i < filters.Count("idfsMethodOfMeasurement"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsMethodOfMeasurement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsMethodOfMeasurement", i), filters.Value("idfsMethodOfMeasurement", i))));
                      
                    if (filters.Contains("strMethodOfMeasurement"))
                        for (int i = 0; i < filters.Count("strMethodOfMeasurement"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strMethodOfMeasurement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strMethodOfMeasurement", i), filters.Value("strMethodOfMeasurement", i))));
                      
                    if (filters.Contains("strMethod"))
                        for (int i = 0; i < filters.Count("strMethod"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strMethod_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strMethod", i), filters.Value("strMethod", i))));
                      
                    if (filters.Contains("idfsYNCough"))
                        for (int i = 0; i < filters.Count("idfsYNCough"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsYNCough_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsYNCough", i), filters.Value("idfsYNCough", i))));
                      
                    if (filters.Contains("idfsYNShortnessOfBreath"))
                        for (int i = 0; i < filters.Count("idfsYNShortnessOfBreath"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsYNShortnessOfBreath_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsYNShortnessOfBreath", i), filters.Value("idfsYNShortnessOfBreath", i))));
                      
                    if (filters.Contains("idfsYNSeasonalFluVaccine"))
                        for (int i = 0; i < filters.Count("idfsYNSeasonalFluVaccine"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsYNSeasonalFluVaccine_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsYNSeasonalFluVaccine", i), filters.Value("idfsYNSeasonalFluVaccine", i))));
                      
                    if (filters.Contains("datDateOfCare"))
                        for (int i = 0; i < filters.Count("datDateOfCare"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datDateOfCare_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datDateOfCare", i), filters.Value("datDateOfCare", i))));
                      
                    if (filters.Contains("idfsYNPatientWasHospitalized"))
                        for (int i = 0; i < filters.Count("idfsYNPatientWasHospitalized"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsYNPatientWasHospitalized_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsYNPatientWasHospitalized", i), filters.Value("idfsYNPatientWasHospitalized", i))));
                      
                    if (filters.Contains("idfsOutcome"))
                        for (int i = 0; i < filters.Count("idfsOutcome"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsOutcome_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsOutcome", i), filters.Value("idfsOutcome", i))));
                      
                    if (filters.Contains("idfsYNPatientWasInER"))
                        for (int i = 0; i < filters.Count("idfsYNPatientWasInER"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsYNPatientWasInER_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsYNPatientWasInER", i), filters.Value("idfsYNPatientWasInER", i))));
                      
                    if (filters.Contains("idfsYNTreatment"))
                        for (int i = 0; i < filters.Count("idfsYNTreatment"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsYNTreatment_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsYNTreatment", i), filters.Value("idfsYNTreatment", i))));
                      
                    if (filters.Contains("idfsYNAdministratedAntiviralMedication"))
                        for (int i = 0; i < filters.Count("idfsYNAdministratedAntiviralMedication"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsYNAdministratedAntiviralMedication_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsYNAdministratedAntiviralMedication", i), filters.Value("idfsYNAdministratedAntiviralMedication", i))));
                      
                    if (filters.Contains("strNameOfMedication"))
                        for (int i = 0; i < filters.Count("strNameOfMedication"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strNameOfMedication_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strNameOfMedication", i), filters.Value("strNameOfMedication", i))));
                      
                    if (filters.Contains("datDateReceivedAntiviralMedication"))
                        for (int i = 0; i < filters.Count("datDateReceivedAntiviralMedication"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datDateReceivedAntiviralMedication_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datDateReceivedAntiviralMedication", i), filters.Value("datDateReceivedAntiviralMedication", i))));
                      
                    if (filters.Contains("blnRespiratorySystem"))
                        for (int i = 0; i < filters.Count("blnRespiratorySystem"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnRespiratorySystem_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("blnRespiratorySystem", i), filters.Value("blnRespiratorySystem", i))));
                      
                    if (filters.Contains("blnAsthma"))
                        for (int i = 0; i < filters.Count("blnAsthma"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnAsthma_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("blnAsthma", i), filters.Value("blnAsthma", i))));
                      
                    if (filters.Contains("blnDiabetes"))
                        for (int i = 0; i < filters.Count("blnDiabetes"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnDiabetes_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("blnDiabetes", i), filters.Value("blnDiabetes", i))));
                      
                    if (filters.Contains("blnCardiovascular"))
                        for (int i = 0; i < filters.Count("blnCardiovascular"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnCardiovascular_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("blnCardiovascular", i), filters.Value("blnCardiovascular", i))));
                      
                    if (filters.Contains("blnObesity"))
                        for (int i = 0; i < filters.Count("blnObesity"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnObesity_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("blnObesity", i), filters.Value("blnObesity", i))));
                      
                    if (filters.Contains("blnRenal"))
                        for (int i = 0; i < filters.Count("blnRenal"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnRenal_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("blnRenal", i), filters.Value("blnRenal", i))));
                      
                    if (filters.Contains("blnLiver"))
                        for (int i = 0; i < filters.Count("blnLiver"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnLiver_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("blnLiver", i), filters.Value("blnLiver", i))));
                      
                    if (filters.Contains("blnNeurological"))
                        for (int i = 0; i < filters.Count("blnNeurological"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnNeurological_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("blnNeurological", i), filters.Value("blnNeurological", i))));
                      
                    if (filters.Contains("blnImmunodeficiency"))
                        for (int i = 0; i < filters.Count("blnImmunodeficiency"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnImmunodeficiency_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("blnImmunodeficiency", i), filters.Value("blnImmunodeficiency", i))));
                      
                    if (filters.Contains("blnUnknownEtiology"))
                        for (int i = 0; i < filters.Count("blnUnknownEtiology"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@blnUnknownEtiology_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("blnUnknownEtiology", i), filters.Value("blnUnknownEtiology", i))));
                      
                    if (filters.Contains("datSampleCollectionDate"))
                        for (int i = 0; i < filters.Count("datSampleCollectionDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datSampleCollectionDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datSampleCollectionDate", i), filters.Value("datSampleCollectionDate", i))));
                      
                    if (filters.Contains("strSampleID"))
                        for (int i = 0; i < filters.Count("strSampleID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSampleID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSampleID", i), filters.Value("strSampleID", i))));
                      
                    if (filters.Contains("idfsTestResult"))
                        for (int i = 0; i < filters.Count("idfsTestResult"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTestResult_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTestResult", i), filters.Value("idfsTestResult", i))));
                      
                    if (filters.Contains("strTestResult"))
                        for (int i = 0; i < filters.Count("strTestResult"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strTestResult_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strTestResult", i), filters.Value("strTestResult", i))));
                      
                    if (filters.Contains("datTestResultDate"))
                        for (int i = 0; i < filters.Count("datTestResultDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datTestResultDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datTestResultDate", i), filters.Value("datTestResultDate", i))));
                      
                    if (filters.Contains("datModificationForArchiveDate"))
                        for (int i = 0; i < filters.Count("datModificationForArchiveDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datModificationForArchiveDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datModificationForArchiveDate", i), filters.Value("datModificationForArchiveDate", i))));
                      
                    if (filters.Contains("intRowStatus"))
                        for (int i = 0; i < filters.Count("intRowStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intRowStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intRowStatus", i), filters.Value("intRowStatus", i))));
                      
                    if (filters.Contains("idfHuman"))
                        for (int i = 0; i < filters.Count("idfHuman"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfHuman_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfHuman", i), filters.Value("idfHuman", i))));
                      
                    if (filters.Contains("idfsHumanGender"))
                        for (int i = 0; i < filters.Count("idfsHumanGender"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsHumanGender_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsHumanGender", i), filters.Value("idfsHumanGender", i))));
                      
                    if (filters.Contains("strGender"))
                        for (int i = 0; i < filters.Count("strGender"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strGender_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strGender", i), filters.Value("strGender", i))));
                      
                    if (filters.Contains("strAddress"))
                        for (int i = 0; i < filters.Count("strAddress"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strAddress_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strAddress", i), filters.Value("strAddress", i))));
                      
                    if (filters.Contains("idfsSettlement"))
                        for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlement", i), filters.Value("idfsSettlement", i))));
                      
                    if (filters.Contains("idfsRegion"))
                        for (int i = 0; i < filters.Count("idfsRegion"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion", i), filters.Value("idfsRegion", i))));
                      
                    if (filters.Contains("idfsRayon"))
                        for (int i = 0; i < filters.Count("idfsRayon"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon", i), filters.Value("idfsRayon", i))));
                      
                    if (filters.Contains("idfsCountry"))
                        for (int i = 0; i < filters.Count("idfsCountry"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCountry_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCountry", i), filters.Value("idfsCountry", i))));
                      
                    List<BasicSyndromicSurveillanceListItem> objs = manager.ExecuteList<BasicSyndromicSurveillanceListItem>();
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
            partial void ListSelected(DbManagerProxy manager, List<BasicSyndromicSurveillanceListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return null;
                    
            }
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, BasicSyndromicSurveillanceListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private BasicSyndromicSurveillanceListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    BasicSyndromicSurveillanceListItem obj = BasicSyndromicSurveillanceListItem.CreateInstance();
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
                obj.Country = new Func<BasicSyndromicSurveillanceListItem, CountryLookup>(c => 
                                       c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
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

            
            public BasicSyndromicSurveillanceListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public BasicSyndromicSurveillanceListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public BasicSyndromicSurveillanceListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ActionEditBSS(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj, List<object> pars)
            {
                
                return ActionEditBSS(manager, obj
                    );
            }
            public ActResult ActionEditBSS(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ActionEditBSS"))
                    throw new PermissionException("AccessToBssModule", "ActionEditBSS");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(BasicSyndromicSurveillanceListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(BasicSyndromicSurveillanceListItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.Region = new Func<BasicSyndromicSurveillanceListItem, RegionLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.Rayon = new Func<BasicSyndromicSurveillanceListItem, RayonLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                obj.Settlement = new Func<BasicSyndromicSurveillanceListItem, SettlementLookup>(c => null)(obj);
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
    
            public void LoadLookup_BSSType(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj)
            {
                
                obj.BSSTypeLookup.Clear();
                
                obj.BSSTypeLookup.Add(BSSTypeAccessor.CreateNewT(manager, null));
                
                obj.BSSTypeLookup.AddRange(BSSTypeAccessor.rftBssType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsBasicSyndromicSurveillanceType))
                    
                    .ToList());
                
                if (obj.idfsBasicSyndromicSurveillanceType != null && obj.idfsBasicSyndromicSurveillanceType != 0)
                {
                    obj.BSSType = obj.BSSTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsBasicSyndromicSurveillanceType);
                    
                }
              
                
                LookupManager.AddObject("rftBssType", obj, BSSTypeAccessor.GetType(), "rftBssType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Hospital(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj)
            {
                
                obj.HospitalLookup.Clear();
                
                obj.HospitalLookup.Add(HospitalAccessor.CreateNewT(manager, null));
                
                obj.HospitalLookup.AddRange(HospitalAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfHospital))
                    
                    .ToList());
                
                if (obj.idfHospital != null && obj.idfHospital != 0)
                {
                    obj.Hospital = obj.HospitalLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfHospital);
                    
                }
              
                
                LookupManager.AddObject("OrganizationLookup", obj, HospitalAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Gender(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj)
            {
                
                obj.GenderLookup.Clear();
                
                obj.GenderLookup.Add(GenderAccessor.CreateNewT(manager, null));
                
                obj.GenderLookup.AddRange(GenderAccessor.rftHumanGender_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsHumanGender))
                    
                    .ToList());
                
                if (obj.idfsHumanGender != null && obj.idfsHumanGender != 0)
                {
                    obj.Gender = obj.GenderLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsHumanGender);
                    
                }
              
                
                LookupManager.AddObject("rftHumanGender", obj, GenderAccessor.GetType(), "rftHumanGender_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Country(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj)
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
            
            public void LoadLookup_Region(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<BasicSyndromicSurveillanceListItem, long>(c => c.idfsCountry ?? 0)(obj)
                            
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
            
            public void LoadLookup_Rayon(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<BasicSyndromicSurveillanceListItem, long>(c => c.idfsRegion ?? 0)(obj)
                            
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
            
            public void LoadLookup_Settlement(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<BasicSyndromicSurveillanceListItem, long>(c => c.idfsRayon ?? 0)(obj)
                            
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
            
            public void LoadLookup_TestResult(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj)
            {
                
                obj.TestResultLookup.Clear();
                
                obj.TestResultLookup.Add(TestResultAccessor.CreateNewT(manager, null));
                
                obj.TestResultLookup.AddRange(TestResultAccessor.rftBssTestResult_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestResult))
                    
                    .ToList());
                
                if (obj.idfsTestResult != null && obj.idfsTestResult != 0)
                {
                    obj.TestResult = obj.TestResultLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestResult);
                    
                }
              
                
                LookupManager.AddObject("rftBssTestResult", obj, TestResultAccessor.GetType(), "rftBssTestResult_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Site(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj)
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
            

            private void _LoadLookups(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj)
            {
                
                LoadLookup_BSSType(manager, obj);
                
                LoadLookup_Hospital(manager, obj);
                
                LoadLookup_Gender(manager, obj);
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
                LoadLookup_TestResult(manager, obj);
                
                LoadLookup_Site(manager, obj);
                
            }
    
            [SprocName("spBasicSyndromicSurveillance_Delete")]
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
                    BasicSyndromicSurveillanceListItem bo = obj as BasicSyndromicSurveillanceListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("AccessToBssModule", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("AccessToBssModule", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("AccessToBssModule", "Update");
                    }
                    
                    long mainObject = bo.idfBasicSyndromicSurveillance;
                    
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoBssForm;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbBasicSyndromicSurveillance;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as BasicSyndromicSurveillanceListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfBasicSyndromicSurveillance
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
            
            public bool ValidateCanDelete(BasicSyndromicSurveillanceListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(BasicSyndromicSurveillanceListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(BasicSyndromicSurveillanceListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as BasicSyndromicSurveillanceListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, BasicSyndromicSurveillanceListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(BasicSyndromicSurveillanceListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(BasicSyndromicSurveillanceListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as BasicSyndromicSurveillanceListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as BasicSyndromicSurveillanceListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "BasicSyndromicSurveillanceListItemDetail"; } }
            public string HelpIdWin { get { return "SS_list"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private BasicSyndromicSurveillanceListItem m_obj;
            internal Permissions(BasicSyndromicSurveillanceListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_BasicSyndromicSurveillance_SelectList";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spBasicSyndromicSurveillance_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<BasicSyndromicSurveillanceListItem, bool>> RequiredByField = new Dictionary<string, Func<BasicSyndromicSurveillanceListItem, bool>>();
            public static Dictionary<string, Func<BasicSyndromicSurveillanceListItem, bool>> RequiredByProperty = new Dictionary<string, Func<BasicSyndromicSurveillanceListItem, bool>>();
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
                
                Sizes.Add(_str_strFormID, 200);
                Sizes.Add(_str_strBasicSyndromicSurveillanceType, 2000);
                Sizes.Add(_str_strHospital, 2000);
                Sizes.Add(_str_strFirstName, 200);
                Sizes.Add(_str_strLastName, 200);
                Sizes.Add(_str_PatientName, 602);
                Sizes.Add(_str_strPersonalID, 100);
                Sizes.Add(_str_strMethodOfMeasurement, 2000);
                Sizes.Add(_str_strMethod, 500);
                Sizes.Add(_str_strNameOfMedication, 200);
                Sizes.Add(_str_strSampleID, 200);
                Sizes.Add(_str_strTestResult, 2000);
                Sizes.Add(_str_strGender, 2000);
                Sizes.Add(_str_strAddress, 1000);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFormID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strFormID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsBasicSyndromicSurveillanceType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsBasicSyndromicSurveillanceType",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "BSSTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfHospital",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strHospital",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "HospitalLookup", typeof(OrganizationLookup), (o) => { var c = (OrganizationLookup)o; return c.idfInstitution; }, (o) => { var c = (OrganizationLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datReportDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datReportDate",
                    c => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, c => true, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datDateOfSymptomsOnset",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datDateOfSymptomsOnset",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strLastName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strLastName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFirstName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strFirstName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsHumanGender",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsHumanGender",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "GenderLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "intAgeFullYear",
                    EditorType.Numeric,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "AgeYears",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRegion",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsRegion",
                    null, null, c => false, false, SearchPanelLocation.Main, false, "idfsRayon", "RegionLookup", typeof(RegionLookup), (o) => { var c = (RegionLookup)o; return c.idfsRegion; }, (o) => { var c = (RegionLookup)o; return c.strRegionName; }, null,false
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
                    "idfsSettlement",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SettlementLookup", typeof(SettlementLookup), (o) => { var c = (SettlementLookup)o; return c.idfsSettlement; }, (o) => { var c = (SettlementLookup)o; return c.strSettlementName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTestResult",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "TestResult",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "TestResultLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSite",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "lbDataEntrySiteID",
                    c=>(c as BasicSyndromicSurveillanceListItem).SiteLookup.SingleOrDefault(s=>s.idfsSite == EidssSiteContext.Instance.SiteID), null, c => false, false, SearchPanelLocation.Main, false, null, "SiteLookup", typeof(SiteLookup), (o) => { var c = (SiteLookup)o; return c.idfsSite; }, (o) => { var c = (SiteLookup)o; return c.strSiteName; }, new List<Tuple<string, string>>(){new Tuple<string, string>("strSiteName", eidss.model.Resources.EidssFields.Get("strSiteName")),new Tuple<string, string>("strSiteID", eidss.model.Resources.EidssFields.Get("strSiteID")),},false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfBasicSyndromicSurveillance,
                    _str_idfBasicSyndromicSurveillance, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFormID,
                    _str_strFormID, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsBasicSyndromicSurveillanceType,
                    _str_idfsBasicSyndromicSurveillanceType, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBasicSyndromicSurveillanceType,
                    "idfsBasicSyndromicSurveillanceType", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strHospital,
                    _str_strHospital, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datReportDate,
                    _str_datReportDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datDateOfSymptomsOnset,
                    _str_datDateOfSymptomsOnset, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_PatientName,
                    _str_PatientName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strGender,
                    _str_strGender, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAge,
                    "Age", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAddress,
                    "AddressName", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestResult,
                    "TestResult", null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "ActionEditBSS",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionEditBSS(manager, (BasicSyndromicSurveillanceListItem)c, pars),
                        
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<BasicSyndromicSurveillanceItem>().CreateNew(manager, c, pars == null ? null : (int?)pars[0])),
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<BasicSyndromicSurveillanceItem>().SelectDetail(manager, pars[0])),
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
                                c = ObjectAccessor.CreatorInterface<BasicSyndromicSurveillanceListItem>().CreateWithParams(manager, null, pars);
                                ((BasicSyndromicSurveillanceListItem)c).idfBasicSyndromicSurveillance = (long)pars[0];
                                ((BasicSyndromicSurveillanceListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((BasicSyndromicSurveillanceListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<BasicSyndromicSurveillanceListItem>().Post(manager, (BasicSyndromicSurveillanceListItem)c), c);
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
	