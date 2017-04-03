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
    public abstract partial class BasicSyndromicSurveillanceItem : 
        EditableObject<BasicSyndromicSurveillanceItem>
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
        public abstract DateTime? datDateLastSaved { get; set; }
        protected DateTime? datDateLastSaved_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateLastSaved).OriginalValue; } }
        protected DateTime? datDateLastSaved_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateLastSaved).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_strBasicSyndromicSurveillanceType)]
        [MapField(_str_strBasicSyndromicSurveillanceType)]
        public abstract String strBasicSyndromicSurveillanceType { get; set; }
        protected String strBasicSyndromicSurveillanceType_Original { get { return ((EditableValue<String>)((dynamic)this)._strBasicSyndromicSurveillanceType).OriginalValue; } }
        protected String strBasicSyndromicSurveillanceType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBasicSyndromicSurveillanceType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfHospital)]
        [MapField(_str_idfHospital)]
        public abstract Int64? idfHospital { get; set; }
        protected Int64? idfHospital_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHospital).OriginalValue; } }
        protected Int64? idfHospital_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHospital).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datReportDate)]
        [MapField(_str_datReportDate)]
        public abstract DateTime? datReportDate { get; set; }
        protected DateTime? datReportDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReportDate).OriginalValue; } }
        protected DateTime? datReportDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReportDate).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_strTestResult)]
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
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<BasicSyndromicSurveillanceItem, object> _get_func;
            internal Action<BasicSyndromicSurveillanceItem, string> _set_func;
            internal Action<BasicSyndromicSurveillanceItem, BasicSyndromicSurveillanceItem, CompareModel> _compare_func;
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
        internal const string _str_datReportDate = "datReportDate";
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
        internal const string _str_strSite = "strSite";
        internal const string _str_strEnteredBy = "strEnteredBy";
        internal const string _str_IsILI = "IsILI";
        internal const string _str_BSSType = "BSSType";
        internal const string _str_BSSMethodOfMeasurement = "BSSMethodOfMeasurement";
        internal const string _str_BSSOutcome = "BSSOutcome";
        internal const string _str_BSSTestResult = "BSSTestResult";
        internal const string _str_Hospital = "Hospital";
        internal const string _str_Pregnant = "Pregnant";
        internal const string _str_PostpartumPeriod = "PostpartumPeriod";
        internal const string _str_Fever = "Fever";
        internal const string _str_MethodMeasurement = "MethodMeasurement";
        internal const string _str_Cough = "Cough";
        internal const string _str_ShortnessBreath = "ShortnessBreath";
        internal const string _str_SeasonalFluVaccine = "SeasonalFluVaccine";
        internal const string _str_PatientWasHospitalized = "PatientWasHospitalized";
        internal const string _str_Outcome = "Outcome";
        internal const string _str_PatientWasInER = "PatientWasInER";
        internal const string _str_Treatment = "Treatment";
        internal const string _str_AdministratedAntiviralMedication = "AdministratedAntiviralMedication";
        internal const string _str_TestResult = "TestResult";
        internal const string _str_Patient = "Patient";
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
              _name = _str_datDateLastSaved, _formname = _str_datDateLastSaved, _type = "DateTime?",
              _get_func = o => o.datDateLastSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDateLastSaved != newval) o.datDateLastSaved = newval; },
              _compare_func = (o, c, m) => {
                if (o.datDateLastSaved != c.datDateLastSaved || o.IsRIRPropChanged(_str_datDateLastSaved, c)) 
                  m.Add(_str_datDateLastSaved, o.ObjectIdent + _str_datDateLastSaved, o.ObjectIdent2 + _str_datDateLastSaved, o.ObjectIdent3 + _str_datDateLastSaved, "DateTime?", 
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsSite != newval) o.idfsSite = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsYNPregnant != newval) 
                  o.Pregnant = o.PregnantLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsYNPregnant != newval) o.idfsYNPregnant = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsYNPostpartumPeriod != newval) 
                  o.PostpartumPeriod = o.PostpartumPeriodLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsYNPostpartumPeriod != newval) o.idfsYNPostpartumPeriod = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsYNFever != newval) 
                  o.Fever = o.FeverLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsYNFever != newval) o.idfsYNFever = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsMethodOfMeasurement != newval) 
                  o.BSSMethodOfMeasurement = o.BSSMethodOfMeasurementLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsMethodOfMeasurement != newval) o.idfsMethodOfMeasurement = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsYNCough != newval) 
                  o.Cough = o.CoughLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsYNCough != newval) o.idfsYNCough = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsYNShortnessOfBreath != newval) 
                  o.ShortnessBreath = o.ShortnessBreathLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsYNShortnessOfBreath != newval) o.idfsYNShortnessOfBreath = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsYNSeasonalFluVaccine != newval) 
                  o.SeasonalFluVaccine = o.SeasonalFluVaccineLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsYNSeasonalFluVaccine != newval) o.idfsYNSeasonalFluVaccine = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsYNPatientWasHospitalized != newval) 
                  o.PatientWasHospitalized = o.PatientWasHospitalizedLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsYNPatientWasHospitalized != newval) o.idfsYNPatientWasHospitalized = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsOutcome != newval) 
                  o.BSSOutcome = o.BSSOutcomeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsOutcome != newval) o.idfsOutcome = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsYNPatientWasInER != newval) 
                  o.PatientWasInER = o.PatientWasInERLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsYNPatientWasInER != newval) o.idfsYNPatientWasInER = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsYNTreatment != newval) 
                  o.Treatment = o.TreatmentLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsYNTreatment != newval) o.idfsYNTreatment = newval; },
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsYNAdministratedAntiviralMedication != newval) 
                  o.AdministratedAntiviralMedication = o.AdministratedAntiviralMedicationLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsYNAdministratedAntiviralMedication != newval) o.idfsYNAdministratedAntiviralMedication = newval; },
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
                  o.BSSTestResult = o.BSSTestResultLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
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
              _name = _str_strSite, _formname = _str_strSite, _type = "string",
              _get_func = o => o.strSite,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSite != newval) o.strSite = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.strSite != c.strSite || o.IsRIRPropChanged(_str_strSite, c)) {
                  m.Add(_str_strSite, o.ObjectIdent + _str_strSite, o.ObjectIdent2 + _str_strSite, o.ObjectIdent3 + _str_strSite,  "string", 
                    o.strSite == null ? "" : o.strSite.ToString(),                  
                    o.IsReadOnly(_str_strSite), o.IsInvisible(_str_strSite), o.IsRequired(_str_strSite));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_strEnteredBy, _formname = _str_strEnteredBy, _type = "string",
              _get_func = o => o.strEnteredBy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strEnteredBy != newval) o.strEnteredBy = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.strEnteredBy != c.strEnteredBy || o.IsRIRPropChanged(_str_strEnteredBy, c)) {
                  m.Add(_str_strEnteredBy, o.ObjectIdent + _str_strEnteredBy, o.ObjectIdent2 + _str_strEnteredBy, o.ObjectIdent3 + _str_strEnteredBy,  "string", 
                    o.strEnteredBy == null ? "" : o.strEnteredBy.ToString(),                  
                    o.IsReadOnly(_str_strEnteredBy), o.IsInvisible(_str_strEnteredBy), o.IsRequired(_str_strEnteredBy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_IsILI, _formname = _str_IsILI, _type = "bool",
              _get_func = o => o.IsILI,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.IsILI != c.IsILI || o.IsRIRPropChanged(_str_IsILI, c)) {
                  m.Add(_str_IsILI, o.ObjectIdent + _str_IsILI, o.ObjectIdent2 + _str_IsILI, o.ObjectIdent3 + _str_IsILI, "bool", o.IsILI == null ? "" : o.IsILI.ToString(), o.IsReadOnly(_str_IsILI), o.IsInvisible(_str_IsILI), o.IsRequired(_str_IsILI));
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
              _name = _str_BSSMethodOfMeasurement, _formname = _str_BSSMethodOfMeasurement, _type = "Lookup",
              _get_func = o => { if (o.BSSMethodOfMeasurement == null) return null; return o.BSSMethodOfMeasurement.idfsBaseReference; },
              _set_func = (o, val) => { o.BSSMethodOfMeasurement = o.BSSMethodOfMeasurementLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsMethodOfMeasurement != c.idfsMethodOfMeasurement || o.IsRIRPropChanged(_str_BSSMethodOfMeasurement, c)) {
                  m.Add(_str_BSSMethodOfMeasurement, o.ObjectIdent + _str_BSSMethodOfMeasurement, o.ObjectIdent2 + _str_BSSMethodOfMeasurement, o.ObjectIdent3 + _str_BSSMethodOfMeasurement, "Lookup", o.idfsMethodOfMeasurement == null ? "" : o.idfsMethodOfMeasurement.ToString(), o.IsReadOnly(_str_BSSMethodOfMeasurement), o.IsInvisible(_str_BSSMethodOfMeasurement), o.IsRequired(_str_BSSMethodOfMeasurement)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_BSSMethodOfMeasurement + "Lookup", _formname = _str_BSSMethodOfMeasurement + "Lookup", _type = "LookupContent",
              _get_func = o => o.BSSMethodOfMeasurementLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_BSSOutcome, _formname = _str_BSSOutcome, _type = "Lookup",
              _get_func = o => { if (o.BSSOutcome == null) return null; return o.BSSOutcome.idfsBaseReference; },
              _set_func = (o, val) => { o.BSSOutcome = o.BSSOutcomeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsOutcome != c.idfsOutcome || o.IsRIRPropChanged(_str_BSSOutcome, c)) {
                  m.Add(_str_BSSOutcome, o.ObjectIdent + _str_BSSOutcome, o.ObjectIdent2 + _str_BSSOutcome, o.ObjectIdent3 + _str_BSSOutcome, "Lookup", o.idfsOutcome == null ? "" : o.idfsOutcome.ToString(), o.IsReadOnly(_str_BSSOutcome), o.IsInvisible(_str_BSSOutcome), o.IsRequired(_str_BSSOutcome)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_BSSOutcome + "Lookup", _formname = _str_BSSOutcome + "Lookup", _type = "LookupContent",
              _get_func = o => o.BSSOutcomeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_BSSTestResult, _formname = _str_BSSTestResult, _type = "Lookup",
              _get_func = o => { if (o.BSSTestResult == null) return null; return o.BSSTestResult.idfsBaseReference; },
              _set_func = (o, val) => { o.BSSTestResult = o.BSSTestResultLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_BSSTestResult, c)) {
                  m.Add(_str_BSSTestResult, o.ObjectIdent + _str_BSSTestResult, o.ObjectIdent2 + _str_BSSTestResult, o.ObjectIdent3 + _str_BSSTestResult, "Lookup", o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(), o.IsReadOnly(_str_BSSTestResult), o.IsInvisible(_str_BSSTestResult), o.IsRequired(_str_BSSTestResult)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_BSSTestResult + "Lookup", _formname = _str_BSSTestResult + "Lookup", _type = "LookupContent",
              _get_func = o => o.BSSTestResultLookup,
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
              _name = _str_Pregnant, _formname = _str_Pregnant, _type = "Lookup",
              _get_func = o => { if (o.Pregnant == null) return null; return o.Pregnant.idfsBaseReference; },
              _set_func = (o, val) => { o.Pregnant = o.PregnantLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNPregnant != c.idfsYNPregnant || o.IsRIRPropChanged(_str_Pregnant, c)) {
                  m.Add(_str_Pregnant, o.ObjectIdent + _str_Pregnant, o.ObjectIdent2 + _str_Pregnant, o.ObjectIdent3 + _str_Pregnant, "Lookup", o.idfsYNPregnant == null ? "" : o.idfsYNPregnant.ToString(), o.IsReadOnly(_str_Pregnant), o.IsInvisible(_str_Pregnant), o.IsRequired(_str_Pregnant)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Pregnant + "Lookup", _formname = _str_Pregnant + "Lookup", _type = "LookupContent",
              _get_func = o => o.PregnantLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_PostpartumPeriod, _formname = _str_PostpartumPeriod, _type = "Lookup",
              _get_func = o => { if (o.PostpartumPeriod == null) return null; return o.PostpartumPeriod.idfsBaseReference; },
              _set_func = (o, val) => { o.PostpartumPeriod = o.PostpartumPeriodLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNPostpartumPeriod != c.idfsYNPostpartumPeriod || o.IsRIRPropChanged(_str_PostpartumPeriod, c)) {
                  m.Add(_str_PostpartumPeriod, o.ObjectIdent + _str_PostpartumPeriod, o.ObjectIdent2 + _str_PostpartumPeriod, o.ObjectIdent3 + _str_PostpartumPeriod, "Lookup", o.idfsYNPostpartumPeriod == null ? "" : o.idfsYNPostpartumPeriod.ToString(), o.IsReadOnly(_str_PostpartumPeriod), o.IsInvisible(_str_PostpartumPeriod), o.IsRequired(_str_PostpartumPeriod)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_PostpartumPeriod + "Lookup", _formname = _str_PostpartumPeriod + "Lookup", _type = "LookupContent",
              _get_func = o => o.PostpartumPeriodLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Fever, _formname = _str_Fever, _type = "Lookup",
              _get_func = o => { if (o.Fever == null) return null; return o.Fever.idfsBaseReference; },
              _set_func = (o, val) => { o.Fever = o.FeverLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNFever != c.idfsYNFever || o.IsRIRPropChanged(_str_Fever, c)) {
                  m.Add(_str_Fever, o.ObjectIdent + _str_Fever, o.ObjectIdent2 + _str_Fever, o.ObjectIdent3 + _str_Fever, "Lookup", o.idfsYNFever == null ? "" : o.idfsYNFever.ToString(), o.IsReadOnly(_str_Fever), o.IsInvisible(_str_Fever), o.IsRequired(_str_Fever)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Fever + "Lookup", _formname = _str_Fever + "Lookup", _type = "LookupContent",
              _get_func = o => o.FeverLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_MethodMeasurement, _formname = _str_MethodMeasurement, _type = "Lookup",
              _get_func = o => { if (o.MethodMeasurement == null) return null; return o.MethodMeasurement.idfsBaseReference; },
              _set_func = (o, val) => { o.MethodMeasurement = o.MethodMeasurementLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsMethodOfMeasurement != c.idfsMethodOfMeasurement || o.IsRIRPropChanged(_str_MethodMeasurement, c)) {
                  m.Add(_str_MethodMeasurement, o.ObjectIdent + _str_MethodMeasurement, o.ObjectIdent2 + _str_MethodMeasurement, o.ObjectIdent3 + _str_MethodMeasurement, "Lookup", o.idfsMethodOfMeasurement == null ? "" : o.idfsMethodOfMeasurement.ToString(), o.IsReadOnly(_str_MethodMeasurement), o.IsInvisible(_str_MethodMeasurement), o.IsRequired(_str_MethodMeasurement)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_MethodMeasurement + "Lookup", _formname = _str_MethodMeasurement + "Lookup", _type = "LookupContent",
              _get_func = o => o.MethodMeasurementLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Cough, _formname = _str_Cough, _type = "Lookup",
              _get_func = o => { if (o.Cough == null) return null; return o.Cough.idfsBaseReference; },
              _set_func = (o, val) => { o.Cough = o.CoughLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNCough != c.idfsYNCough || o.IsRIRPropChanged(_str_Cough, c)) {
                  m.Add(_str_Cough, o.ObjectIdent + _str_Cough, o.ObjectIdent2 + _str_Cough, o.ObjectIdent3 + _str_Cough, "Lookup", o.idfsYNCough == null ? "" : o.idfsYNCough.ToString(), o.IsReadOnly(_str_Cough), o.IsInvisible(_str_Cough), o.IsRequired(_str_Cough)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Cough + "Lookup", _formname = _str_Cough + "Lookup", _type = "LookupContent",
              _get_func = o => o.CoughLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_ShortnessBreath, _formname = _str_ShortnessBreath, _type = "Lookup",
              _get_func = o => { if (o.ShortnessBreath == null) return null; return o.ShortnessBreath.idfsBaseReference; },
              _set_func = (o, val) => { o.ShortnessBreath = o.ShortnessBreathLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNShortnessOfBreath != c.idfsYNShortnessOfBreath || o.IsRIRPropChanged(_str_ShortnessBreath, c)) {
                  m.Add(_str_ShortnessBreath, o.ObjectIdent + _str_ShortnessBreath, o.ObjectIdent2 + _str_ShortnessBreath, o.ObjectIdent3 + _str_ShortnessBreath, "Lookup", o.idfsYNShortnessOfBreath == null ? "" : o.idfsYNShortnessOfBreath.ToString(), o.IsReadOnly(_str_ShortnessBreath), o.IsInvisible(_str_ShortnessBreath), o.IsRequired(_str_ShortnessBreath)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_ShortnessBreath + "Lookup", _formname = _str_ShortnessBreath + "Lookup", _type = "LookupContent",
              _get_func = o => o.ShortnessBreathLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_SeasonalFluVaccine, _formname = _str_SeasonalFluVaccine, _type = "Lookup",
              _get_func = o => { if (o.SeasonalFluVaccine == null) return null; return o.SeasonalFluVaccine.idfsBaseReference; },
              _set_func = (o, val) => { o.SeasonalFluVaccine = o.SeasonalFluVaccineLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNSeasonalFluVaccine != c.idfsYNSeasonalFluVaccine || o.IsRIRPropChanged(_str_SeasonalFluVaccine, c)) {
                  m.Add(_str_SeasonalFluVaccine, o.ObjectIdent + _str_SeasonalFluVaccine, o.ObjectIdent2 + _str_SeasonalFluVaccine, o.ObjectIdent3 + _str_SeasonalFluVaccine, "Lookup", o.idfsYNSeasonalFluVaccine == null ? "" : o.idfsYNSeasonalFluVaccine.ToString(), o.IsReadOnly(_str_SeasonalFluVaccine), o.IsInvisible(_str_SeasonalFluVaccine), o.IsRequired(_str_SeasonalFluVaccine)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_SeasonalFluVaccine + "Lookup", _formname = _str_SeasonalFluVaccine + "Lookup", _type = "LookupContent",
              _get_func = o => o.SeasonalFluVaccineLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_PatientWasHospitalized, _formname = _str_PatientWasHospitalized, _type = "Lookup",
              _get_func = o => { if (o.PatientWasHospitalized == null) return null; return o.PatientWasHospitalized.idfsBaseReference; },
              _set_func = (o, val) => { o.PatientWasHospitalized = o.PatientWasHospitalizedLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNPatientWasHospitalized != c.idfsYNPatientWasHospitalized || o.IsRIRPropChanged(_str_PatientWasHospitalized, c)) {
                  m.Add(_str_PatientWasHospitalized, o.ObjectIdent + _str_PatientWasHospitalized, o.ObjectIdent2 + _str_PatientWasHospitalized, o.ObjectIdent3 + _str_PatientWasHospitalized, "Lookup", o.idfsYNPatientWasHospitalized == null ? "" : o.idfsYNPatientWasHospitalized.ToString(), o.IsReadOnly(_str_PatientWasHospitalized), o.IsInvisible(_str_PatientWasHospitalized), o.IsRequired(_str_PatientWasHospitalized)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_PatientWasHospitalized + "Lookup", _formname = _str_PatientWasHospitalized + "Lookup", _type = "LookupContent",
              _get_func = o => o.PatientWasHospitalizedLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Outcome, _formname = _str_Outcome, _type = "Lookup",
              _get_func = o => { if (o.Outcome == null) return null; return o.Outcome.idfsBaseReference; },
              _set_func = (o, val) => { o.Outcome = o.OutcomeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsOutcome != c.idfsOutcome || o.IsRIRPropChanged(_str_Outcome, c)) {
                  m.Add(_str_Outcome, o.ObjectIdent + _str_Outcome, o.ObjectIdent2 + _str_Outcome, o.ObjectIdent3 + _str_Outcome, "Lookup", o.idfsOutcome == null ? "" : o.idfsOutcome.ToString(), o.IsReadOnly(_str_Outcome), o.IsInvisible(_str_Outcome), o.IsRequired(_str_Outcome)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Outcome + "Lookup", _formname = _str_Outcome + "Lookup", _type = "LookupContent",
              _get_func = o => o.OutcomeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_PatientWasInER, _formname = _str_PatientWasInER, _type = "Lookup",
              _get_func = o => { if (o.PatientWasInER == null) return null; return o.PatientWasInER.idfsBaseReference; },
              _set_func = (o, val) => { o.PatientWasInER = o.PatientWasInERLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNPatientWasInER != c.idfsYNPatientWasInER || o.IsRIRPropChanged(_str_PatientWasInER, c)) {
                  m.Add(_str_PatientWasInER, o.ObjectIdent + _str_PatientWasInER, o.ObjectIdent2 + _str_PatientWasInER, o.ObjectIdent3 + _str_PatientWasInER, "Lookup", o.idfsYNPatientWasInER == null ? "" : o.idfsYNPatientWasInER.ToString(), o.IsReadOnly(_str_PatientWasInER), o.IsInvisible(_str_PatientWasInER), o.IsRequired(_str_PatientWasInER)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_PatientWasInER + "Lookup", _formname = _str_PatientWasInER + "Lookup", _type = "LookupContent",
              _get_func = o => o.PatientWasInERLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Treatment, _formname = _str_Treatment, _type = "Lookup",
              _get_func = o => { if (o.Treatment == null) return null; return o.Treatment.idfsBaseReference; },
              _set_func = (o, val) => { o.Treatment = o.TreatmentLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNTreatment != c.idfsYNTreatment || o.IsRIRPropChanged(_str_Treatment, c)) {
                  m.Add(_str_Treatment, o.ObjectIdent + _str_Treatment, o.ObjectIdent2 + _str_Treatment, o.ObjectIdent3 + _str_Treatment, "Lookup", o.idfsYNTreatment == null ? "" : o.idfsYNTreatment.ToString(), o.IsReadOnly(_str_Treatment), o.IsInvisible(_str_Treatment), o.IsRequired(_str_Treatment)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Treatment + "Lookup", _formname = _str_Treatment + "Lookup", _type = "LookupContent",
              _get_func = o => o.TreatmentLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_AdministratedAntiviralMedication, _formname = _str_AdministratedAntiviralMedication, _type = "Lookup",
              _get_func = o => { if (o.AdministratedAntiviralMedication == null) return null; return o.AdministratedAntiviralMedication.idfsBaseReference; },
              _set_func = (o, val) => { o.AdministratedAntiviralMedication = o.AdministratedAntiviralMedicationLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsYNAdministratedAntiviralMedication != c.idfsYNAdministratedAntiviralMedication || o.IsRIRPropChanged(_str_AdministratedAntiviralMedication, c)) {
                  m.Add(_str_AdministratedAntiviralMedication, o.ObjectIdent + _str_AdministratedAntiviralMedication, o.ObjectIdent2 + _str_AdministratedAntiviralMedication, o.ObjectIdent3 + _str_AdministratedAntiviralMedication, "Lookup", o.idfsYNAdministratedAntiviralMedication == null ? "" : o.idfsYNAdministratedAntiviralMedication.ToString(), o.IsReadOnly(_str_AdministratedAntiviralMedication), o.IsInvisible(_str_AdministratedAntiviralMedication), o.IsRequired(_str_AdministratedAntiviralMedication)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_AdministratedAntiviralMedication + "Lookup", _formname = _str_AdministratedAntiviralMedication + "Lookup", _type = "LookupContent",
              _get_func = o => o.AdministratedAntiviralMedicationLookup,
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
              _name = _str_Patient, _formname = _str_Patient, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Patient != null) o.Patient._compare(c.Patient, m); }
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
            BasicSyndromicSurveillanceItem obj = (BasicSyndromicSurveillanceItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Patient)]
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
                    
        [LocalizedDisplayName(_str_BSSType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsBasicSyndromicSurveillanceType)]
        public BaseReference BSSType
        {
            get { return _BSSType; }
            set 
            { 
                var oldVal = _BSSType;
                _BSSType = value;
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
            
        [LocalizedDisplayName(_str_BSSMethodOfMeasurement)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsMethodOfMeasurement)]
        public BaseReference BSSMethodOfMeasurement
        {
            get { return _BSSMethodOfMeasurement == null ? null : ((long)_BSSMethodOfMeasurement.Key == 0 ? null : _BSSMethodOfMeasurement); }
            set 
            { 
                var oldVal = _BSSMethodOfMeasurement;
                _BSSMethodOfMeasurement = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_BSSMethodOfMeasurement != oldVal)
                {
                    if (idfsMethodOfMeasurement != (_BSSMethodOfMeasurement == null
                            ? new Int64?()
                            : (Int64?)_BSSMethodOfMeasurement.idfsBaseReference))
                        idfsMethodOfMeasurement = _BSSMethodOfMeasurement == null 
                            ? new Int64?()
                            : (Int64?)_BSSMethodOfMeasurement.idfsBaseReference; 
                    OnPropertyChanged(_str_BSSMethodOfMeasurement); 
                }
            }
        }
        private BaseReference _BSSMethodOfMeasurement;

        
        public BaseReferenceList BSSMethodOfMeasurementLookup
        {
            get { return _BSSMethodOfMeasurementLookup; }
        }
        private BaseReferenceList _BSSMethodOfMeasurementLookup = new BaseReferenceList("rftBssMethodOfMeasurement");
            
        [LocalizedDisplayName(_str_BSSOutcome)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsOutcome)]
        public BaseReference BSSOutcome
        {
            get { return _BSSOutcome == null ? null : ((long)_BSSOutcome.Key == 0 ? null : _BSSOutcome); }
            set 
            { 
                var oldVal = _BSSOutcome;
                _BSSOutcome = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_BSSOutcome != oldVal)
                {
                    if (idfsOutcome != (_BSSOutcome == null
                            ? new Int64?()
                            : (Int64?)_BSSOutcome.idfsBaseReference))
                        idfsOutcome = _BSSOutcome == null 
                            ? new Int64?()
                            : (Int64?)_BSSOutcome.idfsBaseReference; 
                    OnPropertyChanged(_str_BSSOutcome); 
                }
            }
        }
        private BaseReference _BSSOutcome;

        
        public BaseReferenceList BSSOutcomeLookup
        {
            get { return _BSSOutcomeLookup; }
        }
        private BaseReferenceList _BSSOutcomeLookup = new BaseReferenceList("rftBssOutcome");
            
        [LocalizedDisplayName(_str_BSSTestResult)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsTestResult)]
        public BaseReference BSSTestResult
        {
            get { return _BSSTestResult == null ? null : ((long)_BSSTestResult.Key == 0 ? null : _BSSTestResult); }
            set 
            { 
                var oldVal = _BSSTestResult;
                _BSSTestResult = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_BSSTestResult != oldVal)
                {
                    if (idfsTestResult != (_BSSTestResult == null
                            ? new Int64?()
                            : (Int64?)_BSSTestResult.idfsBaseReference))
                        idfsTestResult = _BSSTestResult == null 
                            ? new Int64?()
                            : (Int64?)_BSSTestResult.idfsBaseReference; 
                    OnPropertyChanged(_str_BSSTestResult); 
                }
            }
        }
        private BaseReference _BSSTestResult;

        
        public BaseReferenceList BSSTestResultLookup
        {
            get { return _BSSTestResultLookup; }
        }
        private BaseReferenceList _BSSTestResultLookup = new BaseReferenceList("rftBssTestResult");
            
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
            
        [LocalizedDisplayName(_str_Pregnant)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNPregnant)]
        public BaseReference Pregnant
        {
            get { return _Pregnant == null ? null : ((long)_Pregnant.Key == 0 ? null : _Pregnant); }
            set 
            { 
                var oldVal = _Pregnant;
                _Pregnant = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Pregnant != oldVal)
                {
                    if (idfsYNPregnant != (_Pregnant == null
                            ? new Int64?()
                            : (Int64?)_Pregnant.idfsBaseReference))
                        idfsYNPregnant = _Pregnant == null 
                            ? new Int64?()
                            : (Int64?)_Pregnant.idfsBaseReference; 
                    OnPropertyChanged(_str_Pregnant); 
                }
            }
        }
        private BaseReference _Pregnant;

        
        public BaseReferenceList PregnantLookup
        {
            get { return _PregnantLookup; }
        }
        private BaseReferenceList _PregnantLookup = new BaseReferenceList("rftYesNoValue");
            
        [LocalizedDisplayName(_str_PostpartumPeriod)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNPostpartumPeriod)]
        public BaseReference PostpartumPeriod
        {
            get { return _PostpartumPeriod == null ? null : ((long)_PostpartumPeriod.Key == 0 ? null : _PostpartumPeriod); }
            set 
            { 
                var oldVal = _PostpartumPeriod;
                _PostpartumPeriod = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_PostpartumPeriod != oldVal)
                {
                    if (idfsYNPostpartumPeriod != (_PostpartumPeriod == null
                            ? new Int64?()
                            : (Int64?)_PostpartumPeriod.idfsBaseReference))
                        idfsYNPostpartumPeriod = _PostpartumPeriod == null 
                            ? new Int64?()
                            : (Int64?)_PostpartumPeriod.idfsBaseReference; 
                    OnPropertyChanged(_str_PostpartumPeriod); 
                }
            }
        }
        private BaseReference _PostpartumPeriod;

        
        public BaseReferenceList PostpartumPeriodLookup
        {
            get { return _PostpartumPeriodLookup; }
        }
        private BaseReferenceList _PostpartumPeriodLookup = new BaseReferenceList("rftYesNoValue");
            
        [LocalizedDisplayName(_str_Fever)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNFever)]
        public BaseReference Fever
        {
            get { return _Fever == null ? null : ((long)_Fever.Key == 0 ? null : _Fever); }
            set 
            { 
                var oldVal = _Fever;
                _Fever = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Fever != oldVal)
                {
                    if (idfsYNFever != (_Fever == null
                            ? new Int64?()
                            : (Int64?)_Fever.idfsBaseReference))
                        idfsYNFever = _Fever == null 
                            ? new Int64?()
                            : (Int64?)_Fever.idfsBaseReference; 
                    OnPropertyChanged(_str_Fever); 
                }
            }
        }
        private BaseReference _Fever;

        
        public BaseReferenceList FeverLookup
        {
            get { return _FeverLookup; }
        }
        private BaseReferenceList _FeverLookup = new BaseReferenceList("rftYesNoValue");
            
        [LocalizedDisplayName(_str_MethodMeasurement)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsMethodOfMeasurement)]
        public BaseReference MethodMeasurement
        {
            get { return _MethodMeasurement == null ? null : ((long)_MethodMeasurement.Key == 0 ? null : _MethodMeasurement); }
            set 
            { 
                var oldVal = _MethodMeasurement;
                _MethodMeasurement = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_MethodMeasurement != oldVal)
                {
                    if (idfsMethodOfMeasurement != (_MethodMeasurement == null
                            ? new Int64?()
                            : (Int64?)_MethodMeasurement.idfsBaseReference))
                        idfsMethodOfMeasurement = _MethodMeasurement == null 
                            ? new Int64?()
                            : (Int64?)_MethodMeasurement.idfsBaseReference; 
                    OnPropertyChanged(_str_MethodMeasurement); 
                }
            }
        }
        private BaseReference _MethodMeasurement;

        
        public BaseReferenceList MethodMeasurementLookup
        {
            get { return _MethodMeasurementLookup; }
        }
        private BaseReferenceList _MethodMeasurementLookup = new BaseReferenceList("rftBssMethodOfMeasurement");
            
        [LocalizedDisplayName(_str_Cough)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNCough)]
        public BaseReference Cough
        {
            get { return _Cough == null ? null : ((long)_Cough.Key == 0 ? null : _Cough); }
            set 
            { 
                var oldVal = _Cough;
                _Cough = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Cough != oldVal)
                {
                    if (idfsYNCough != (_Cough == null
                            ? new Int64?()
                            : (Int64?)_Cough.idfsBaseReference))
                        idfsYNCough = _Cough == null 
                            ? new Int64?()
                            : (Int64?)_Cough.idfsBaseReference; 
                    OnPropertyChanged(_str_Cough); 
                }
            }
        }
        private BaseReference _Cough;

        
        public BaseReferenceList CoughLookup
        {
            get { return _CoughLookup; }
        }
        private BaseReferenceList _CoughLookup = new BaseReferenceList("rftYesNoValue");
            
        [LocalizedDisplayName(_str_ShortnessBreath)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNShortnessOfBreath)]
        public BaseReference ShortnessBreath
        {
            get { return _ShortnessBreath == null ? null : ((long)_ShortnessBreath.Key == 0 ? null : _ShortnessBreath); }
            set 
            { 
                var oldVal = _ShortnessBreath;
                _ShortnessBreath = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_ShortnessBreath != oldVal)
                {
                    if (idfsYNShortnessOfBreath != (_ShortnessBreath == null
                            ? new Int64?()
                            : (Int64?)_ShortnessBreath.idfsBaseReference))
                        idfsYNShortnessOfBreath = _ShortnessBreath == null 
                            ? new Int64?()
                            : (Int64?)_ShortnessBreath.idfsBaseReference; 
                    OnPropertyChanged(_str_ShortnessBreath); 
                }
            }
        }
        private BaseReference _ShortnessBreath;

        
        public BaseReferenceList ShortnessBreathLookup
        {
            get { return _ShortnessBreathLookup; }
        }
        private BaseReferenceList _ShortnessBreathLookup = new BaseReferenceList("rftYesNoValue");
            
        [LocalizedDisplayName(_str_SeasonalFluVaccine)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNSeasonalFluVaccine)]
        public BaseReference SeasonalFluVaccine
        {
            get { return _SeasonalFluVaccine == null ? null : ((long)_SeasonalFluVaccine.Key == 0 ? null : _SeasonalFluVaccine); }
            set 
            { 
                var oldVal = _SeasonalFluVaccine;
                _SeasonalFluVaccine = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SeasonalFluVaccine != oldVal)
                {
                    if (idfsYNSeasonalFluVaccine != (_SeasonalFluVaccine == null
                            ? new Int64?()
                            : (Int64?)_SeasonalFluVaccine.idfsBaseReference))
                        idfsYNSeasonalFluVaccine = _SeasonalFluVaccine == null 
                            ? new Int64?()
                            : (Int64?)_SeasonalFluVaccine.idfsBaseReference; 
                    OnPropertyChanged(_str_SeasonalFluVaccine); 
                }
            }
        }
        private BaseReference _SeasonalFluVaccine;

        
        public BaseReferenceList SeasonalFluVaccineLookup
        {
            get { return _SeasonalFluVaccineLookup; }
        }
        private BaseReferenceList _SeasonalFluVaccineLookup = new BaseReferenceList("rftYesNoValue");
            
        [LocalizedDisplayName(_str_PatientWasHospitalized)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNPatientWasHospitalized)]
        public BaseReference PatientWasHospitalized
        {
            get { return _PatientWasHospitalized == null ? null : ((long)_PatientWasHospitalized.Key == 0 ? null : _PatientWasHospitalized); }
            set 
            { 
                var oldVal = _PatientWasHospitalized;
                _PatientWasHospitalized = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_PatientWasHospitalized != oldVal)
                {
                    if (idfsYNPatientWasHospitalized != (_PatientWasHospitalized == null
                            ? new Int64?()
                            : (Int64?)_PatientWasHospitalized.idfsBaseReference))
                        idfsYNPatientWasHospitalized = _PatientWasHospitalized == null 
                            ? new Int64?()
                            : (Int64?)_PatientWasHospitalized.idfsBaseReference; 
                    OnPropertyChanged(_str_PatientWasHospitalized); 
                }
            }
        }
        private BaseReference _PatientWasHospitalized;

        
        public BaseReferenceList PatientWasHospitalizedLookup
        {
            get { return _PatientWasHospitalizedLookup; }
        }
        private BaseReferenceList _PatientWasHospitalizedLookup = new BaseReferenceList("rftYesNoValue");
            
        [LocalizedDisplayName(_str_Outcome)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsOutcome)]
        public BaseReference Outcome
        {
            get { return _Outcome == null ? null : ((long)_Outcome.Key == 0 ? null : _Outcome); }
            set 
            { 
                var oldVal = _Outcome;
                _Outcome = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Outcome != oldVal)
                {
                    if (idfsOutcome != (_Outcome == null
                            ? new Int64?()
                            : (Int64?)_Outcome.idfsBaseReference))
                        idfsOutcome = _Outcome == null 
                            ? new Int64?()
                            : (Int64?)_Outcome.idfsBaseReference; 
                    OnPropertyChanged(_str_Outcome); 
                }
            }
        }
        private BaseReference _Outcome;

        
        public BaseReferenceList OutcomeLookup
        {
            get { return _OutcomeLookup; }
        }
        private BaseReferenceList _OutcomeLookup = new BaseReferenceList("rftBssOutcome");
            
        [LocalizedDisplayName(_str_PatientWasInER)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNPatientWasInER)]
        public BaseReference PatientWasInER
        {
            get { return _PatientWasInER == null ? null : ((long)_PatientWasInER.Key == 0 ? null : _PatientWasInER); }
            set 
            { 
                var oldVal = _PatientWasInER;
                _PatientWasInER = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_PatientWasInER != oldVal)
                {
                    if (idfsYNPatientWasInER != (_PatientWasInER == null
                            ? new Int64?()
                            : (Int64?)_PatientWasInER.idfsBaseReference))
                        idfsYNPatientWasInER = _PatientWasInER == null 
                            ? new Int64?()
                            : (Int64?)_PatientWasInER.idfsBaseReference; 
                    OnPropertyChanged(_str_PatientWasInER); 
                }
            }
        }
        private BaseReference _PatientWasInER;

        
        public BaseReferenceList PatientWasInERLookup
        {
            get { return _PatientWasInERLookup; }
        }
        private BaseReferenceList _PatientWasInERLookup = new BaseReferenceList("rftYesNoValue");
            
        [LocalizedDisplayName(_str_Treatment)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNTreatment)]
        public BaseReference Treatment
        {
            get { return _Treatment == null ? null : ((long)_Treatment.Key == 0 ? null : _Treatment); }
            set 
            { 
                var oldVal = _Treatment;
                _Treatment = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Treatment != oldVal)
                {
                    if (idfsYNTreatment != (_Treatment == null
                            ? new Int64?()
                            : (Int64?)_Treatment.idfsBaseReference))
                        idfsYNTreatment = _Treatment == null 
                            ? new Int64?()
                            : (Int64?)_Treatment.idfsBaseReference; 
                    OnPropertyChanged(_str_Treatment); 
                }
            }
        }
        private BaseReference _Treatment;

        
        public BaseReferenceList TreatmentLookup
        {
            get { return _TreatmentLookup; }
        }
        private BaseReferenceList _TreatmentLookup = new BaseReferenceList("rftYesNoValue");
            
        [LocalizedDisplayName(_str_AdministratedAntiviralMedication)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsYNAdministratedAntiviralMedication)]
        public BaseReference AdministratedAntiviralMedication
        {
            get { return _AdministratedAntiviralMedication == null ? null : ((long)_AdministratedAntiviralMedication.Key == 0 ? null : _AdministratedAntiviralMedication); }
            set 
            { 
                var oldVal = _AdministratedAntiviralMedication;
                _AdministratedAntiviralMedication = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AdministratedAntiviralMedication != oldVal)
                {
                    if (idfsYNAdministratedAntiviralMedication != (_AdministratedAntiviralMedication == null
                            ? new Int64?()
                            : (Int64?)_AdministratedAntiviralMedication.idfsBaseReference))
                        idfsYNAdministratedAntiviralMedication = _AdministratedAntiviralMedication == null 
                            ? new Int64?()
                            : (Int64?)_AdministratedAntiviralMedication.idfsBaseReference; 
                    OnPropertyChanged(_str_AdministratedAntiviralMedication); 
                }
            }
        }
        private BaseReference _AdministratedAntiviralMedication;

        
        public BaseReferenceList AdministratedAntiviralMedicationLookup
        {
            get { return _AdministratedAntiviralMedicationLookup; }
        }
        private BaseReferenceList _AdministratedAntiviralMedicationLookup = new BaseReferenceList("rftYesNoValue");
            
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
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_BSSType:
                    return new BvSelectList(BSSTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, BSSType, _str_idfsBasicSyndromicSurveillanceType);
            
                case _str_BSSMethodOfMeasurement:
                    return new BvSelectList(BSSMethodOfMeasurementLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, BSSMethodOfMeasurement, _str_idfsMethodOfMeasurement);
            
                case _str_BSSOutcome:
                    return new BvSelectList(BSSOutcomeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, BSSOutcome, _str_idfsOutcome);
            
                case _str_BSSTestResult:
                    return new BvSelectList(BSSTestResultLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, BSSTestResult, _str_idfsTestResult);
            
                case _str_Hospital:
                    return new BvSelectList(HospitalLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, Hospital, _str_idfHospital);
            
                case _str_Pregnant:
                    return new BvSelectList(PregnantLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Pregnant, _str_idfsYNPregnant);
            
                case _str_PostpartumPeriod:
                    return new BvSelectList(PostpartumPeriodLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, PostpartumPeriod, _str_idfsYNPostpartumPeriod);
            
                case _str_Fever:
                    return new BvSelectList(FeverLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Fever, _str_idfsYNFever);
            
                case _str_MethodMeasurement:
                    return new BvSelectList(MethodMeasurementLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, MethodMeasurement, _str_idfsMethodOfMeasurement);
            
                case _str_Cough:
                    return new BvSelectList(CoughLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Cough, _str_idfsYNCough);
            
                case _str_ShortnessBreath:
                    return new BvSelectList(ShortnessBreathLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, ShortnessBreath, _str_idfsYNShortnessOfBreath);
            
                case _str_SeasonalFluVaccine:
                    return new BvSelectList(SeasonalFluVaccineLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SeasonalFluVaccine, _str_idfsYNSeasonalFluVaccine);
            
                case _str_PatientWasHospitalized:
                    return new BvSelectList(PatientWasHospitalizedLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, PatientWasHospitalized, _str_idfsYNPatientWasHospitalized);
            
                case _str_Outcome:
                    return new BvSelectList(OutcomeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Outcome, _str_idfsOutcome);
            
                case _str_PatientWasInER:
                    return new BvSelectList(PatientWasInERLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, PatientWasInER, _str_idfsYNPatientWasInER);
            
                case _str_Treatment:
                    return new BvSelectList(TreatmentLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Treatment, _str_idfsYNTreatment);
            
                case _str_AdministratedAntiviralMedication:
                    return new BvSelectList(AdministratedAntiviralMedicationLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AdministratedAntiviralMedication, _str_idfsYNAdministratedAntiviralMedication);
            
                case _str_TestResult:
                    return new BvSelectList(TestResultLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestResult, _str_idfsTestResult);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsILI)]
        public bool IsILI
        {
            get { return new Func<BasicSyndromicSurveillanceItem, bool>(c => c.idfsBasicSyndromicSurveillanceType == 50791920000000)(this); }
            
        }
        
          [LocalizedDisplayName(_str_strSite)]
        public string strSite
        {
            get { return m_strSite; }
            set { if (m_strSite != value) { m_strSite = value; OnPropertyChanged(_str_strSite); } }
        }
        private string m_strSite;
        
          [LocalizedDisplayName(_str_strEnteredBy)]
        public string strEnteredBy
        {
            get { return m_strEnteredBy; }
            set { if (m_strEnteredBy != value) { m_strEnteredBy = value; OnPropertyChanged(_str_strEnteredBy); } }
        }
        private string m_strEnteredBy;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "BasicSyndromicSurveillanceItem";

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
        
            if (_Patient != null) { _Patient.Parent = this; }
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as BasicSyndromicSurveillanceItem;
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
            var ret = base.Clone() as BasicSyndromicSurveillanceItem;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Patient != null)
              ret.Patient = _Patient.CloneWithSetup(manager, bRestricted) as Patient;
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public BasicSyndromicSurveillanceItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as BasicSyndromicSurveillanceItem;
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
        
                    || (_Patient != null && _Patient.HasChanges)
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsBasicSyndromicSurveillanceType_BSSType = idfsBasicSyndromicSurveillanceType;
            var _prev_idfsMethodOfMeasurement_BSSMethodOfMeasurement = idfsMethodOfMeasurement;
            var _prev_idfsOutcome_BSSOutcome = idfsOutcome;
            var _prev_idfsTestResult_BSSTestResult = idfsTestResult;
            var _prev_idfHospital_Hospital = idfHospital;
            var _prev_idfsYNPregnant_Pregnant = idfsYNPregnant;
            var _prev_idfsYNPostpartumPeriod_PostpartumPeriod = idfsYNPostpartumPeriod;
            var _prev_idfsYNFever_Fever = idfsYNFever;
            var _prev_idfsMethodOfMeasurement_MethodMeasurement = idfsMethodOfMeasurement;
            var _prev_idfsYNCough_Cough = idfsYNCough;
            var _prev_idfsYNShortnessOfBreath_ShortnessBreath = idfsYNShortnessOfBreath;
            var _prev_idfsYNSeasonalFluVaccine_SeasonalFluVaccine = idfsYNSeasonalFluVaccine;
            var _prev_idfsYNPatientWasHospitalized_PatientWasHospitalized = idfsYNPatientWasHospitalized;
            var _prev_idfsOutcome_Outcome = idfsOutcome;
            var _prev_idfsYNPatientWasInER_PatientWasInER = idfsYNPatientWasInER;
            var _prev_idfsYNTreatment_Treatment = idfsYNTreatment;
            var _prev_idfsYNAdministratedAntiviralMedication_AdministratedAntiviralMedication = idfsYNAdministratedAntiviralMedication;
            var _prev_idfsTestResult_TestResult = idfsTestResult;
            base.RejectChanges();
        
            if (_prev_idfsBasicSyndromicSurveillanceType_BSSType != idfsBasicSyndromicSurveillanceType)
            {
                _BSSType = _BSSTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsBasicSyndromicSurveillanceType);
            }
            if (_prev_idfsMethodOfMeasurement_BSSMethodOfMeasurement != idfsMethodOfMeasurement)
            {
                _BSSMethodOfMeasurement = _BSSMethodOfMeasurementLookup.FirstOrDefault(c => c.idfsBaseReference == idfsMethodOfMeasurement);
            }
            if (_prev_idfsOutcome_BSSOutcome != idfsOutcome)
            {
                _BSSOutcome = _BSSOutcomeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsOutcome);
            }
            if (_prev_idfsTestResult_BSSTestResult != idfsTestResult)
            {
                _BSSTestResult = _BSSTestResultLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestResult);
            }
            if (_prev_idfHospital_Hospital != idfHospital)
            {
                _Hospital = _HospitalLookup.FirstOrDefault(c => c.idfInstitution == idfHospital);
            }
            if (_prev_idfsYNPregnant_Pregnant != idfsYNPregnant)
            {
                _Pregnant = _PregnantLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNPregnant);
            }
            if (_prev_idfsYNPostpartumPeriod_PostpartumPeriod != idfsYNPostpartumPeriod)
            {
                _PostpartumPeriod = _PostpartumPeriodLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNPostpartumPeriod);
            }
            if (_prev_idfsYNFever_Fever != idfsYNFever)
            {
                _Fever = _FeverLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNFever);
            }
            if (_prev_idfsMethodOfMeasurement_MethodMeasurement != idfsMethodOfMeasurement)
            {
                _MethodMeasurement = _MethodMeasurementLookup.FirstOrDefault(c => c.idfsBaseReference == idfsMethodOfMeasurement);
            }
            if (_prev_idfsYNCough_Cough != idfsYNCough)
            {
                _Cough = _CoughLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNCough);
            }
            if (_prev_idfsYNShortnessOfBreath_ShortnessBreath != idfsYNShortnessOfBreath)
            {
                _ShortnessBreath = _ShortnessBreathLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNShortnessOfBreath);
            }
            if (_prev_idfsYNSeasonalFluVaccine_SeasonalFluVaccine != idfsYNSeasonalFluVaccine)
            {
                _SeasonalFluVaccine = _SeasonalFluVaccineLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNSeasonalFluVaccine);
            }
            if (_prev_idfsYNPatientWasHospitalized_PatientWasHospitalized != idfsYNPatientWasHospitalized)
            {
                _PatientWasHospitalized = _PatientWasHospitalizedLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNPatientWasHospitalized);
            }
            if (_prev_idfsOutcome_Outcome != idfsOutcome)
            {
                _Outcome = _OutcomeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsOutcome);
            }
            if (_prev_idfsYNPatientWasInER_PatientWasInER != idfsYNPatientWasInER)
            {
                _PatientWasInER = _PatientWasInERLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNPatientWasInER);
            }
            if (_prev_idfsYNTreatment_Treatment != idfsYNTreatment)
            {
                _Treatment = _TreatmentLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNTreatment);
            }
            if (_prev_idfsYNAdministratedAntiviralMedication_AdministratedAntiviralMedication != idfsYNAdministratedAntiviralMedication)
            {
                _AdministratedAntiviralMedication = _AdministratedAntiviralMedicationLookup.FirstOrDefault(c => c.idfsBaseReference == idfsYNAdministratedAntiviralMedication);
            }
            if (_prev_idfsTestResult_TestResult != idfsTestResult)
            {
                _TestResult = _TestResultLookup.FirstOrDefault(c => c.idfsBaseReference == idfsTestResult);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (Patient != null) Patient.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Patient != null) _Patient.DeepAcceptChanges();
                
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
        
            if (_Patient != null) _Patient.SetChange();
                
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

        private bool IsRIRPropChanged(string fld, BasicSyndromicSurveillanceItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public BasicSyndromicSurveillanceItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(BasicSyndromicSurveillanceItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(BasicSyndromicSurveillanceItem_PropertyChanged);
        }
        private void BasicSyndromicSurveillanceItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as BasicSyndromicSurveillanceItem).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsBasicSyndromicSurveillanceType)
                OnPropertyChanged(_str_IsILI);
                  
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
            BasicSyndromicSurveillanceItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            BasicSyndromicSurveillanceItem obj = this;
            
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

    
        private static string[] readonly_names1 = "intAgeYear,intAgeMonth".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "Pregnant".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "PostpartumPeriod".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "strFormID,datDateEntered,datDateLastSaved,idfEnteredBy,idfsSite,strSite,strEnteredBy".Split(new char[] { ',' });
        
        private static string[] readonly_names5 = "MethodMeasurement".Split(new char[] { ',' });
        
        private static string[] readonly_names6 = "strMethod".Split(new char[] { ',' });
        
        private static string[] readonly_names7 = "strNameOfMedication,datDateReceivedAntiviralMedication".Split(new char[] { ',' });
        
        private static string[] readonly_names8 = "Outcome".Split(new char[] { ',' });
        
        private static string[] readonly_names9 = "datDateOfCare,PatientWasHospitalized,Outcome,PatientWasInER,Treatment".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<BasicSyndromicSurveillanceItem, bool>(c => c.Patient.datDateofBirth != null)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<BasicSyndromicSurveillanceItem, bool>(c => c.Patient != null ? c.Patient.Gender != null ? c.Patient.Gender.idfsBaseReference == (long)GenderType.Male : true : true)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<BasicSyndromicSurveillanceItem, bool>(c => (c.Patient.Gender != null && c.Patient.Gender.idfsBaseReference == (long)GenderType.Female) ? (c.Pregnant != null && c.Pregnant.idfsBaseReference == (long)YesNoUnknownValuesEnum.Yes) ? true : false : true)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<BasicSyndromicSurveillanceItem, bool>(c => true)(this);
            
            if (readonly_names5.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<BasicSyndromicSurveillanceItem, bool>(c => c.Fever != null ? c.Fever.idfsBaseReference != (long)YesNoUnknownValuesEnum.Yes : true)(this);
            
            if (readonly_names6.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<BasicSyndromicSurveillanceItem, bool>(c => c.MethodMeasurement != null ? c.MethodMeasurement.idfsBaseReference != (long)MethodOfMeasurement.Other : true)(this);
            
            if (readonly_names7.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<BasicSyndromicSurveillanceItem, bool>(c => c.AdministratedAntiviralMedication != null ? c.AdministratedAntiviralMedication.idfsBaseReference != (long)YesNoUnknownValuesEnum.Yes : true)(this);
            
            if (readonly_names8.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<BasicSyndromicSurveillanceItem, bool>(c => c.PatientWasHospitalized != null ? c.PatientWasHospitalized.idfsBaseReference != (long)YesNoUnknownValuesEnum.Yes : true)(this);
            
            if (readonly_names9.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<BasicSyndromicSurveillanceItem, bool>(c => c.IsILI)(this);
            
            return ReadOnly || new Func<BasicSyndromicSurveillanceItem, bool>(c => c.ReadOnly)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_Patient != null)
                    _Patient.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<BasicSyndromicSurveillanceItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<BasicSyndromicSurveillanceItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<BasicSyndromicSurveillanceItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<BasicSyndromicSurveillanceItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<BasicSyndromicSurveillanceItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<BasicSyndromicSurveillanceItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<BasicSyndromicSurveillanceItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~BasicSyndromicSurveillanceItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                if (_Patient != null)
                    Patient.Dispose();
                
                LookupManager.RemoveObject("rftBssType", this);
                
                LookupManager.RemoveObject("rftBssMethodOfMeasurement", this);
                
                LookupManager.RemoveObject("rftBssOutcome", this);
                
                LookupManager.RemoveObject("rftBssTestResult", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftBssMethodOfMeasurement", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftBssOutcome", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                LookupManager.RemoveObject("rftBssTestResult", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftBssType")
                _getAccessor().LoadLookup_BSSType(manager, this);
            
            if (lookup_object == "rftBssMethodOfMeasurement")
                _getAccessor().LoadLookup_BSSMethodOfMeasurement(manager, this);
            
            if (lookup_object == "rftBssOutcome")
                _getAccessor().LoadLookup_BSSOutcome(manager, this);
            
            if (lookup_object == "rftBssTestResult")
                _getAccessor().LoadLookup_BSSTestResult(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_Hospital(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_Pregnant(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_PostpartumPeriod(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_Fever(manager, this);
            
            if (lookup_object == "rftBssMethodOfMeasurement")
                _getAccessor().LoadLookup_MethodMeasurement(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_Cough(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_ShortnessBreath(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_SeasonalFluVaccine(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_PatientWasHospitalized(manager, this);
            
            if (lookup_object == "rftBssOutcome")
                _getAccessor().LoadLookup_Outcome(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_PatientWasInER(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_Treatment(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_AdministratedAntiviralMedication(manager, this);
            
            if (lookup_object == "rftBssTestResult")
                _getAccessor().LoadLookup_TestResult(manager, this);
            
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
        
            if (_Patient != null) _Patient.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<BasicSyndromicSurveillanceItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<BasicSyndromicSurveillanceItem>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<BasicSyndromicSurveillanceItem>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfBasicSyndromicSurveillance"; } }
            #endregion
        
            private delegate void on_action(BasicSyndromicSurveillanceItem obj);
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
            private Patient.Accessor PatientAccessor { get { return eidss.model.Schema.Patient.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor BSSTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor BSSMethodOfMeasurementAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor BSSOutcomeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor BSSTestResultAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor HospitalAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PregnantAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PostpartumPeriodAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor FeverAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor MethodMeasurementAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CoughAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor ShortnessBreathAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SeasonalFluVaccineAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PatientWasHospitalizedAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor OutcomeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PatientWasInERAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TreatmentAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AdministratedAntiviralMedicationAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestResultAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            

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
            public virtual BasicSyndromicSurveillanceItem SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual BasicSyndromicSurveillanceItem SelectByKey(DbManagerProxy manager
                , Int64? idfBasicSyndromicSurveillance
                )
            {
                return _SelectByKey(manager
                    , idfBasicSyndromicSurveillance
                    , null, null
                    );
            }
            
      
            private BasicSyndromicSurveillanceItem _SelectByKey(DbManagerProxy manager
                , Int64? idfBasicSyndromicSurveillance
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<BasicSyndromicSurveillanceItem> objs = new List<BasicSyndromicSurveillanceItem>();
                sets[0] = new MapResultSet(typeof(BasicSyndromicSurveillanceItem), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spBasicSyndromicSurveillance_SelectDetail"
                            , manager.Parameter("@idfBasicSyndromicSurveillance", idfBasicSyndromicSurveillance)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    BasicSyndromicSurveillanceItem obj = objs[0];
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
    
            internal void _LoadPatient(BasicSyndromicSurveillanceItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadPatient(manager, obj);
                }
            }
            internal void _LoadPatient(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
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
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj.strSite = new Func<BasicSyndromicSurveillanceItem, string>(c => EidssSiteContext.Instance.SiteABR)(obj);
                obj.strEnteredBy = new Func<BasicSyndromicSurveillanceItem, string>(c => EidssUserContext.User.FullName)(obj);
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadPatient(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.intAgeYear = new Func<BasicSyndromicSurveillanceItem, int?>(c => c.GetYears())(obj);
                obj.intAgeMonth = new Func<BasicSyndromicSurveillanceItem, int?>(c => c.GetMonths())(obj);
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, BasicSyndromicSurveillanceItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    PatientAccessor._SetPermitions(obj._permissions, obj.Patient);
                    
                    }
                }
            }

    

            private BasicSyndromicSurveillanceItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    BasicSyndromicSurveillanceItem obj = BasicSyndromicSurveillanceItem.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfBasicSyndromicSurveillance = (new GetNewIDExtender<BasicSyndromicSurveillanceItem>()).GetScalar(manager, obj, isFake);
                obj.strFormID = new Func<BasicSyndromicSurveillanceItem, string>(c => "(new)")(obj);
                obj.datDateEntered = new Func<BasicSyndromicSurveillanceItem, DateTime>(c => DateTime.Now)(obj);
                obj.datDateLastSaved = new Func<BasicSyndromicSurveillanceItem, DateTime?>(c => null)(obj);
                obj.idfEnteredBy = new Func<BasicSyndromicSurveillanceItem, long>(c => (long)EidssUserContext.User.EmployeeID)(obj);
                obj.strEnteredBy = new Func<BasicSyndromicSurveillanceItem, string>(c => EidssUserContext.User.FullName)(obj);
                obj.idfsSite = new Func<BasicSyndromicSurveillanceItem, long>(c => EidssSiteContext.Instance.SiteID)(obj);
                obj.strSite = new Func<BasicSyndromicSurveillanceItem, string>(c => EidssSiteContext.Instance.OrganizationName)(obj);
                obj.Patient = new Func<BasicSyndromicSurveillanceItem, Patient>(c => (Patient)PatientAccessor.Create(manager, c, 0))(obj);
                obj.Patient.idfRootHuman = (new GetNewIDExtender<BasicSyndromicSurveillanceItem>()).GetScalar(manager, obj, isFake);
                obj.Patient.CurrentResidenceAddress.Region = new Func<BasicSyndromicSurveillanceItem, RegionLookup>(c => null)(obj);
                obj.idfHuman = new Func<BasicSyndromicSurveillanceItem, long>(c => c.Patient.idfHuman)(obj);
                obj.intAgeFullYear = new Func<BasicSyndromicSurveillanceItem, int>(c => 0)(obj);
                obj.intAgeFullMonth = new Func<BasicSyndromicSurveillanceItem, int>(c => 0)(obj);
                obj.idfsBasicSyndromicSurveillanceType = new Func<BasicSyndromicSurveillanceItem, long>(c => 50791920000000)(obj);
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

            
            public BasicSyndromicSurveillanceItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public BasicSyndromicSurveillanceItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public BasicSyndromicSurveillanceItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(BasicSyndromicSurveillanceItem obj, object newobj)
            {
                
                    if (obj.Patient != null && (newobj == null || newobj == obj.Patient))
                    {
                        var o = obj.Patient;
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "datDateofBirth")
                            {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("datDateofBirth");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                    }
                  
                    if (newobj == null || newobj == obj.Patient)
                    {
                        var o = obj.Patient;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "datDateofBirth")
                                {
                                
                obj.intAgeYear = new Func<BasicSyndromicSurveillanceItem, int?>(c => c.GetYears())(obj);
                                }
                            };
                        }    
                        
                    }
                            
                    if (newobj == null || newobj == obj.Patient)
                    {
                        var o = obj.Patient;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "datDateofBirth")
                                {
                                
                obj.intAgeMonth = new Func<BasicSyndromicSurveillanceItem, int?>(c => c.GetMonths())(obj);
                                }
                            };
                        }    
                        
                    }
                            
                    if (newobj == null || newobj == obj.Patient)
                    {
                        var o = obj.Patient;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "Gender")
                                {
                                
                obj.Pregnant = new Func<BasicSyndromicSurveillanceItem, BaseReference>(c => (c.Patient.Gender != null && c.Patient.Gender.idfsBaseReference == (long)GenderType.Male) ? null : c.Pregnant)(obj);
                                }
                            };
                        }    
                        
                    }
                            
                    if (newobj == null || newobj == obj.Patient)
                    {
                        var o = obj.Patient;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "Gender")
                                {
                                
                obj.PostpartumPeriod = new Func<BasicSyndromicSurveillanceItem, BaseReference>(c => (c.Patient.Gender != null && c.Patient.Gender.idfsBaseReference == (long)GenderType.Male) ? null : c.PostpartumPeriod)(obj);
                                }
                            };
                        }    
                        
                    }
                            
            }
            
            private void _SetupHandlers(BasicSyndromicSurveillanceItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datDateOfSymptomsOnset)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datDateOfSymptomsOnset);
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
                    
                        if (e.PropertyName == _str_datDateOfCare)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datDateOfCare);
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
                    
                        if (e.PropertyName == _str_datDateReceivedAntiviralMedication)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datDateReceivedAntiviralMedication);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datSampleCollectionDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datSampleCollectionDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datTestResultDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTestResultDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_intAgeYear)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intAgeYear);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_intAgeMonth)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intAgeMonth);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsSite)
                        {
                    
                obj.strSite = new Func<BasicSyndromicSurveillanceItem, string>(c => EidssSiteContext.Instance.SiteABR)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfEnteredBy)
                        {
                    
                obj.strEnteredBy = new Func<BasicSyndromicSurveillanceItem, string>(c => EidssUserContext.User.FullName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsMethodOfMeasurement)
                        {
                    
                obj.strMethod = new Func<BasicSyndromicSurveillanceItem, string>(c => c.MethodMeasurement != null ? c.MethodMeasurement.idfsBaseReference == (long)MethodOfMeasurement.Other ? c.strMethod : String.Empty : String.Empty)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsYNFever)
                        {
                    
                obj.MethodMeasurement = new Func<BasicSyndromicSurveillanceItem, BaseReference>(c => c.Fever.idfsBaseReference == (long)YesNoUnknownValuesEnum.Yes ? c.MethodMeasurement : null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsYNPatientWasHospitalized)
                        {
                    
                obj.Outcome = new Func<BasicSyndromicSurveillanceItem, BaseReference>(c => (c.PatientWasHospitalized != null) && (c.PatientWasHospitalized.idfsBaseReference == (long)YesNoUnknownValuesEnum.Yes) ? c.Outcome : null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsYNAdministratedAntiviralMedication)
                        {
                    
                obj.strNameOfMedication = new Func<BasicSyndromicSurveillanceItem, string>(c => c.AdministratedAntiviralMedication.idfsBaseReference == (long)YesNoUnknownValuesEnum.Yes ? c.strNameOfMedication : String.Empty)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsYNAdministratedAntiviralMedication)
                        {
                    
                obj.datDateReceivedAntiviralMedication = new Func<BasicSyndromicSurveillanceItem, DateTime?>(c => c.AdministratedAntiviralMedication.idfsBaseReference == (long)YesNoUnknownValuesEnum.Yes ? c.datDateReceivedAntiviralMedication : null)(obj);
                        }
                    
                        if (e.PropertyName == _str_IsILI)
                        {
                    
                obj.datDateOfCare = new Func<BasicSyndromicSurveillanceItem, DateTime?>(c => c.IsILI ? null : c.datDateOfCare)(obj);
                        }
                    
                        if (e.PropertyName == _str_IsILI)
                        {
                    
                obj.PatientWasHospitalized = new Func<BasicSyndromicSurveillanceItem, BaseReference>(c => c.IsILI ? null : c.PatientWasHospitalized)(obj);
                        }
                    
                        if (e.PropertyName == _str_IsILI)
                        {
                    
                obj.Outcome = new Func<BasicSyndromicSurveillanceItem, BaseReference>(c => c.IsILI ? null : c.Outcome)(obj);
                        }
                    
                        if (e.PropertyName == _str_IsILI)
                        {
                    
                obj.PatientWasInER = new Func<BasicSyndromicSurveillanceItem, BaseReference>(c => c.IsILI ? null : c.PatientWasInER)(obj);
                        }
                    
                        if (e.PropertyName == _str_IsILI)
                        {
                    
                obj.Treatment = new Func<BasicSyndromicSurveillanceItem, BaseReference>(c => c.IsILI ? null : c.Treatment)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsYNPregnant)
                        {
                    
                obj.PostpartumPeriod = new Func<BasicSyndromicSurveillanceItem, BaseReference>(c => c.Pregnant != null ? c.Pregnant.idfsBaseReference == (long)YesNoUnknownValuesEnum.Yes ? null : c.PostpartumPeriod : c.PostpartumPeriod)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_BSSType(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.BSSTypeLookup.Clear();
                
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
            
            public void LoadLookup_BSSMethodOfMeasurement(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.BSSMethodOfMeasurementLookup.Clear();
                
                obj.BSSMethodOfMeasurementLookup.Add(BSSMethodOfMeasurementAccessor.CreateNewT(manager, null));
                
                obj.BSSMethodOfMeasurementLookup.AddRange(BSSMethodOfMeasurementAccessor.rftBssMethodOfMeasurement_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsMethodOfMeasurement))
                    
                    .ToList());
                
                if (obj.idfsMethodOfMeasurement != null && obj.idfsMethodOfMeasurement != 0)
                {
                    obj.BSSMethodOfMeasurement = obj.BSSMethodOfMeasurementLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsMethodOfMeasurement);
                    
                }
              
                
                LookupManager.AddObject("rftBssMethodOfMeasurement", obj, BSSMethodOfMeasurementAccessor.GetType(), "rftBssMethodOfMeasurement_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_BSSOutcome(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.BSSOutcomeLookup.Clear();
                
                obj.BSSOutcomeLookup.Add(BSSOutcomeAccessor.CreateNewT(manager, null));
                
                obj.BSSOutcomeLookup.AddRange(BSSOutcomeAccessor.rftBssOutcome_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsOutcome))
                    
                    .ToList());
                
                if (obj.idfsOutcome != null && obj.idfsOutcome != 0)
                {
                    obj.BSSOutcome = obj.BSSOutcomeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsOutcome);
                    
                }
              
                
                LookupManager.AddObject("rftBssOutcome", obj, BSSOutcomeAccessor.GetType(), "rftBssOutcome_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_BSSTestResult(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.BSSTestResultLookup.Clear();
                
                obj.BSSTestResultLookup.Add(BSSTestResultAccessor.CreateNewT(manager, null));
                
                obj.BSSTestResultLookup.AddRange(BSSTestResultAccessor.rftBssTestResult_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsTestResult))
                    
                    .ToList());
                
                if (obj.idfsTestResult != null && obj.idfsTestResult != 0)
                {
                    obj.BSSTestResult = obj.BSSTestResultLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsTestResult);
                    
                }
              
                
                LookupManager.AddObject("rftBssTestResult", obj, BSSTestResultAccessor.GetType(), "rftBssTestResult_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Hospital(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.HospitalLookup.Clear();
                
                obj.HospitalLookup.Add(HospitalAccessor.CreateNewT(manager, null));
                
                obj.HospitalLookup.AddRange(HospitalAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (((c.intHACode??0) & (int)HACode.Syndromic) != 0) || c.idfInstitution == obj.idfHospital)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfHospital))
                    
                    .ToList());
                
                if (obj.idfHospital != null && obj.idfHospital != 0)
                {
                    obj.Hospital = obj.HospitalLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfHospital);
                    
                }
              
                
                LookupManager.AddObject("OrganizationLookup", obj, HospitalAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Pregnant(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.PregnantLookup.Clear();
                
                obj.PregnantLookup.Add(PregnantAccessor.CreateNewT(manager, null));
                
                obj.PregnantLookup.AddRange(PregnantAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNPregnant))
                    
                    .ToList());
                
                if (obj.idfsYNPregnant != null && obj.idfsYNPregnant != 0)
                {
                    obj.Pregnant = obj.PregnantLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsYNPregnant);
                    
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, PregnantAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_PostpartumPeriod(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.PostpartumPeriodLookup.Clear();
                
                obj.PostpartumPeriodLookup.Add(PostpartumPeriodAccessor.CreateNewT(manager, null));
                
                obj.PostpartumPeriodLookup.AddRange(PostpartumPeriodAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNPostpartumPeriod))
                    
                    .ToList());
                
                if (obj.idfsYNPostpartumPeriod != null && obj.idfsYNPostpartumPeriod != 0)
                {
                    obj.PostpartumPeriod = obj.PostpartumPeriodLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsYNPostpartumPeriod);
                    
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, PostpartumPeriodAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Fever(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.FeverLookup.Clear();
                
                obj.FeverLookup.Add(FeverAccessor.CreateNewT(manager, null));
                
                obj.FeverLookup.AddRange(FeverAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNFever))
                    
                    .ToList());
                
                if (obj.idfsYNFever != null && obj.idfsYNFever != 0)
                {
                    obj.Fever = obj.FeverLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsYNFever);
                    
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, FeverAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_MethodMeasurement(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.MethodMeasurementLookup.Clear();
                
                obj.MethodMeasurementLookup.Add(MethodMeasurementAccessor.CreateNewT(manager, null));
                
                obj.MethodMeasurementLookup.AddRange(MethodMeasurementAccessor.rftBssMethodOfMeasurement_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsMethodOfMeasurement))
                    
                    .ToList());
                
                if (obj.idfsMethodOfMeasurement != null && obj.idfsMethodOfMeasurement != 0)
                {
                    obj.MethodMeasurement = obj.MethodMeasurementLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsMethodOfMeasurement);
                    
                }
              
                
                LookupManager.AddObject("rftBssMethodOfMeasurement", obj, MethodMeasurementAccessor.GetType(), "rftBssMethodOfMeasurement_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Cough(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.CoughLookup.Clear();
                
                obj.CoughLookup.Add(CoughAccessor.CreateNewT(manager, null));
                
                obj.CoughLookup.AddRange(CoughAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNCough))
                    
                    .ToList());
                
                if (obj.idfsYNCough != null && obj.idfsYNCough != 0)
                {
                    obj.Cough = obj.CoughLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsYNCough);
                    
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, CoughAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_ShortnessBreath(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.ShortnessBreathLookup.Clear();
                
                obj.ShortnessBreathLookup.Add(ShortnessBreathAccessor.CreateNewT(manager, null));
                
                obj.ShortnessBreathLookup.AddRange(ShortnessBreathAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNShortnessOfBreath))
                    
                    .ToList());
                
                if (obj.idfsYNShortnessOfBreath != null && obj.idfsYNShortnessOfBreath != 0)
                {
                    obj.ShortnessBreath = obj.ShortnessBreathLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsYNShortnessOfBreath);
                    
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, ShortnessBreathAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_SeasonalFluVaccine(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.SeasonalFluVaccineLookup.Clear();
                
                obj.SeasonalFluVaccineLookup.Add(SeasonalFluVaccineAccessor.CreateNewT(manager, null));
                
                obj.SeasonalFluVaccineLookup.AddRange(SeasonalFluVaccineAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNSeasonalFluVaccine))
                    
                    .ToList());
                
                if (obj.idfsYNSeasonalFluVaccine != null && obj.idfsYNSeasonalFluVaccine != 0)
                {
                    obj.SeasonalFluVaccine = obj.SeasonalFluVaccineLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsYNSeasonalFluVaccine);
                    
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, SeasonalFluVaccineAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_PatientWasHospitalized(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.PatientWasHospitalizedLookup.Clear();
                
                obj.PatientWasHospitalizedLookup.Add(PatientWasHospitalizedAccessor.CreateNewT(manager, null));
                
                obj.PatientWasHospitalizedLookup.AddRange(PatientWasHospitalizedAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNPatientWasHospitalized))
                    
                    .ToList());
                
                if (obj.idfsYNPatientWasHospitalized != null && obj.idfsYNPatientWasHospitalized != 0)
                {
                    obj.PatientWasHospitalized = obj.PatientWasHospitalizedLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsYNPatientWasHospitalized);
                    
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, PatientWasHospitalizedAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Outcome(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.OutcomeLookup.Clear();
                
                obj.OutcomeLookup.Add(OutcomeAccessor.CreateNewT(manager, null));
                
                obj.OutcomeLookup.AddRange(OutcomeAccessor.rftBssOutcome_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsOutcome))
                    
                    .ToList());
                
                if (obj.idfsOutcome != null && obj.idfsOutcome != 0)
                {
                    obj.Outcome = obj.OutcomeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsOutcome);
                    
                }
              
                
                LookupManager.AddObject("rftBssOutcome", obj, OutcomeAccessor.GetType(), "rftBssOutcome_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_PatientWasInER(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.PatientWasInERLookup.Clear();
                
                obj.PatientWasInERLookup.Add(PatientWasInERAccessor.CreateNewT(manager, null));
                
                obj.PatientWasInERLookup.AddRange(PatientWasInERAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNPatientWasInER))
                    
                    .ToList());
                
                if (obj.idfsYNPatientWasInER != null && obj.idfsYNPatientWasInER != 0)
                {
                    obj.PatientWasInER = obj.PatientWasInERLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsYNPatientWasInER);
                    
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, PatientWasInERAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Treatment(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.TreatmentLookup.Clear();
                
                obj.TreatmentLookup.Add(TreatmentAccessor.CreateNewT(manager, null));
                
                obj.TreatmentLookup.AddRange(TreatmentAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNTreatment))
                    
                    .ToList());
                
                if (obj.idfsYNTreatment != null && obj.idfsYNTreatment != 0)
                {
                    obj.Treatment = obj.TreatmentLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsYNTreatment);
                    
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, TreatmentAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_AdministratedAntiviralMedication(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                obj.AdministratedAntiviralMedicationLookup.Clear();
                
                obj.AdministratedAntiviralMedicationLookup.Add(AdministratedAntiviralMedicationAccessor.CreateNewT(manager, null));
                
                obj.AdministratedAntiviralMedicationLookup.AddRange(AdministratedAntiviralMedicationAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsYNAdministratedAntiviralMedication))
                    
                    .ToList());
                
                if (obj.idfsYNAdministratedAntiviralMedication != null && obj.idfsYNAdministratedAntiviralMedication != 0)
                {
                    obj.AdministratedAntiviralMedication = obj.AdministratedAntiviralMedicationLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsYNAdministratedAntiviralMedication);
                    
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, AdministratedAntiviralMedicationAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_TestResult(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
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
            

            private void _LoadLookups(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
                
                LoadLookup_BSSType(manager, obj);
                
                LoadLookup_BSSMethodOfMeasurement(manager, obj);
                
                LoadLookup_BSSOutcome(manager, obj);
                
                LoadLookup_BSSTestResult(manager, obj);
                
                LoadLookup_Hospital(manager, obj);
                
                LoadLookup_Pregnant(manager, obj);
                
                LoadLookup_PostpartumPeriod(manager, obj);
                
                LoadLookup_Fever(manager, obj);
                
                LoadLookup_MethodMeasurement(manager, obj);
                
                LoadLookup_Cough(manager, obj);
                
                LoadLookup_ShortnessBreath(manager, obj);
                
                LoadLookup_SeasonalFluVaccine(manager, obj);
                
                LoadLookup_PatientWasHospitalized(manager, obj);
                
                LoadLookup_Outcome(manager, obj);
                
                LoadLookup_PatientWasInER(manager, obj);
                
                LoadLookup_Treatment(manager, obj);
                
                LoadLookup_AdministratedAntiviralMedication(manager, obj);
                
                LoadLookup_TestResult(manager, obj);
                
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
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spBasicSyndromicSurveillance_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strFormID")] BasicSyndromicSurveillanceItem obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strFormID")] BasicSyndromicSurveillanceItem obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    BasicSyndromicSurveillanceItem bo = obj as BasicSyndromicSurveillanceItem;
                    
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
                        
                            manager.SetEventParams(false, new object[] { EventType.BssFormLocal, mainObject, "" });
                        
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
                    bSuccess = _PostNonTransaction(manager, obj as BasicSyndromicSurveillanceItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.Patient != null)
                    {
                        obj.Patient.MarkToDelete();
                        if (!PatientAccessor.Post(manager, obj.Patient, true))
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
                obj.datModificationForArchiveDate = new Func<BasicSyndromicSurveillanceItem, DateTime?>(c => c.HasChanges ? DateTime.Now : c.datModificationForArchiveDate)(obj);
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
                                    
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                                    
                    // posted extenters - begin
                obj.datDateLastSaved = new Func<BasicSyndromicSurveillanceItem, DateTime>(c => DateTime.Now)(obj);
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(BasicSyndromicSurveillanceItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(BasicSyndromicSurveillanceItem obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<BasicSyndromicSurveillanceItem>(obj, "datDateofBirth", c => true, 
      obj.Patient == null ? null : obj.Patient.datDateofBirth,
      obj.Patient == null ? null : obj.Patient.GetType(),
      false, listdatDateofBirth => {
    listdatDateofBirth.Add(
    new ChainsValidatorDateTime<BasicSyndromicSurveillanceItem>(obj, "datDateOfSymptomsOnset", c => true, 
      obj.datDateOfSymptomsOnset,
      obj.GetType(),
      false, listdatDateOfSymptomsOnset => {
    listdatDateOfSymptomsOnset.Add(
    new ChainsValidatorDateTime<BasicSyndromicSurveillanceItem>(obj, "datReportDate", c => true, 
      obj.datReportDate,
      obj.GetType(),
      false, listdatReportDate => {
    listdatReportDate.Add(
    new ChainsValidatorDateTime<BasicSyndromicSurveillanceItem>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }));
  
    }));
  listdatDateofBirth.Add(
    new ChainsValidatorDateTime<BasicSyndromicSurveillanceItem>(obj, "datDateOfCare", c => true, 
      obj.datDateOfCare,
      obj.GetType(),
      false, listdatDateOfCare => {
    listdatDateOfCare.Add(
    new ChainsValidatorDateTime<BasicSyndromicSurveillanceItem>(obj, "datReportDate", c => true, 
      obj.datReportDate,
      obj.GetType(),
      false, listdatReportDate => {
    listdatReportDate.Add(
    new ChainsValidatorDateTime<BasicSyndromicSurveillanceItem>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }));
  listdatDateOfCare.Add(
    new ChainsValidatorDateTime<BasicSyndromicSurveillanceItem>(obj, "datDateReceivedAntiviralMedication", c => true, 
      obj.datDateReceivedAntiviralMedication,
      obj.GetType(),
      false, listdatDateReceivedAntiviralMedication => {
    listdatDateReceivedAntiviralMedication.Add(
    new ChainsValidatorDateTime<BasicSyndromicSurveillanceItem>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }));
  listdatDateOfCare.Add(
    new ChainsValidatorDateTime<BasicSyndromicSurveillanceItem>(obj, "datSampleCollectionDate", c => true, 
      obj.datSampleCollectionDate,
      obj.GetType(),
      false, listdatSampleCollectionDate => {
    listdatSampleCollectionDate.Add(
    new ChainsValidatorDateTime<BasicSyndromicSurveillanceItem>(obj, "datTestResultDate", c => true, 
      obj.datTestResultDate,
      obj.GetType(),
      false, listdatTestResultDate => {
    listdatTestResultDate.Add(
    new ChainsValidatorDateTime<BasicSyndromicSurveillanceItem>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }));
  
    }));
  
    }));
  
    }).Process();
  
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceItem>(obj, "MinValue", c => true, 
      0,
      null,
      false, listMinValue => {
    listMinValue.Add(
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceItem>(obj, "intAgeYear", c => true, 
      obj.intAgeYear,
      obj.GetType(),
      false, listintAgeYear => {
    listintAgeYear.Add(
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceItem>(obj, "MaxValue", c => true, 
      200,
      null,
      false, listMaxValue => {
    
    }));
  
    }));
  
    }).Process();
  
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceItem>(obj, "MinValue", c => true, 
      0,
      null,
      false, listMinValue => {
    listMinValue.Add(
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceItem>(obj, "intAgeMonth", c => true, 
      obj.intAgeMonth,
      obj.GetType(),
      false, listintAgeMonth => {
    listintAgeMonth.Add(
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceItem>(obj, "MaxValue", c => true, 
      11,
      null,
      false, listMaxValue => {
    
    }));
  
    }));
  
    }).Process();
  
                }
                catch(ValidationModelException ex)
                {
                    return ex;
                }
                
                return null;
            }
            protected bool ChainsValidate(BasicSyndromicSurveillanceItem obj, bool bRethrowException)
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
                return Validate(manager, obj as BasicSyndromicSurveillanceItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, BasicSyndromicSurveillanceItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsSite", "idfsSite","",
                false
              )).Validate(c => true, obj, obj.idfsSite);
            
                (new RequiredValidator( "idfsBasicSyndromicSurveillanceType", "BSSType","BSSType",
                false
              )).Validate(c => true, obj, obj.idfsBasicSyndromicSurveillanceType);
            
                (new RequiredValidator( "idfHospital", "Hospital","BSS.Hospital",
                false
              )).Validate(c => true, obj, obj.idfHospital);
            
                (new RequiredValidator( "datReportDate", "datReportDate","",
                false
              )).Validate(c => true, obj, obj.datReportDate);
            
                (new RequiredValidator( "idfEnteredBy", "idfEnteredBy","",
                false
              )).Validate(c => true, obj, obj.idfEnteredBy);
            
                (new PredicateValidator("msgReportDateEnteredDate", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.datReportDate <= c.datDateEntered
                    );
            
                (new RequiredValidator( "Patient.strLastName", "strLastName","Person.strLastName",
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
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Patient != null)
                            PatientAccessor.Validate(manager, obj.Patient, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(BasicSyndromicSurveillanceItem obj)
            {
            
                obj
                    .AddRequired("idfsSite", c => true);
                    
                obj
                    .AddRequired("BSSType", c => true);
                    
                  obj
                    .AddRequired("BSSType", c => true);
                
                obj
                    .AddRequired("Hospital", c => true);
                    
                  obj
                    .AddRequired("Hospital", c => true);
                
                obj
                    .AddRequired("datReportDate", c => true);
                    
                obj
                    .AddRequired("idfEnteredBy", c => true);
                    
                obj
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
                        
            }
    
    private void _SetupPersonalDataRestrictions(BasicSyndromicSurveillanceItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as BasicSyndromicSurveillanceItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as BasicSyndromicSurveillanceItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "BasicSyndromicSurveillanceItemDetail"; } }
            public string HelpIdWin { get { return "SS_form"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private BasicSyndromicSurveillanceItem m_obj;
            internal Permissions(BasicSyndromicSurveillanceItem obj)
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
            public static string spSelect = "spBasicSyndromicSurveillance_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spBasicSyndromicSurveillance_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spBasicSyndromicSurveillance_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<BasicSyndromicSurveillanceItem, bool>> RequiredByField = new Dictionary<string, Func<BasicSyndromicSurveillanceItem, bool>>();
            public static Dictionary<string, Func<BasicSyndromicSurveillanceItem, bool>> RequiredByProperty = new Dictionary<string, Func<BasicSyndromicSurveillanceItem, bool>>();
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
                Sizes.Add(_str_strPersonalID, 100);
                Sizes.Add(_str_strMethodOfMeasurement, 2000);
                Sizes.Add(_str_strMethod, 500);
                Sizes.Add(_str_strNameOfMedication, 200);
                Sizes.Add(_str_strSampleID, 200);
                Sizes.Add(_str_strTestResult, 2000);
                if (!RequiredByField.ContainsKey("idfsSite")) RequiredByField.Add("idfsSite", c => true);
                if (!RequiredByProperty.ContainsKey("idfsSite")) RequiredByProperty.Add("idfsSite", c => true);
                
                if (!RequiredByField.ContainsKey("idfsBasicSyndromicSurveillanceType")) RequiredByField.Add("idfsBasicSyndromicSurveillanceType", c => true);
                if (!RequiredByProperty.ContainsKey("BSSType")) RequiredByProperty.Add("BSSType", c => true);
                
                if (!RequiredByField.ContainsKey("idfHospital")) RequiredByField.Add("idfHospital", c => true);
                if (!RequiredByProperty.ContainsKey("Hospital")) RequiredByProperty.Add("Hospital", c => true);
                
                if (!RequiredByField.ContainsKey("datReportDate")) RequiredByField.Add("datReportDate", c => true);
                if (!RequiredByProperty.ContainsKey("datReportDate")) RequiredByProperty.Add("datReportDate", c => true);
                
                if (!RequiredByField.ContainsKey("idfEnteredBy")) RequiredByField.Add("idfEnteredBy", c => true);
                if (!RequiredByProperty.ContainsKey("idfEnteredBy")) RequiredByProperty.Add("idfEnteredBy", c => true);
                
                if (!RequiredByField.ContainsKey("Patient.strLastName")) RequiredByField.Add("Patient.strLastName", c => true);
                if (!RequiredByProperty.ContainsKey("strLastName")) RequiredByProperty.Add("strLastName", c => true);
                
                if (!RequiredByField.ContainsKey("Patient.CurrentResidenceAddress.idfsCountry")) RequiredByField.Add("Patient.CurrentResidenceAddress.idfsCountry", c => true);
                if (!RequiredByProperty.ContainsKey("Patient.CurrentResidenceAddress.Country")) RequiredByProperty.Add("Patient.CurrentResidenceAddress.Country", c => true);
                
                if (!RequiredByField.ContainsKey("Patient.CurrentResidenceAddress.idfsRegion")) RequiredByField.Add("Patient.CurrentResidenceAddress.idfsRegion", c => true);
                if (!RequiredByProperty.ContainsKey("Patient.CurrentResidenceAddress.Region")) RequiredByProperty.Add("Patient.CurrentResidenceAddress.Region", c => true);
                
                if (!RequiredByField.ContainsKey("Patient.CurrentResidenceAddress.idfsRayon")) RequiredByField.Add("Patient.CurrentResidenceAddress.idfsRayon", c => true);
                if (!RequiredByProperty.ContainsKey("Patient.CurrentResidenceAddress.Rayon")) RequiredByProperty.Add("Patient.CurrentResidenceAddress.Rayon", c => true);
                
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<BasicSyndromicSurveillanceItem>().Post(manager, (BasicSyndromicSurveillanceItem)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<BasicSyndromicSurveillanceItem>().Post(manager, (BasicSyndromicSurveillanceItem)c), c),
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
                    (manager, c, pars) => new ActResult(((BasicSyndromicSurveillanceItem)c).MarkToDelete() && ObjectAccessor.PostInterface<BasicSyndromicSurveillanceItem>().Post(manager, (BasicSyndromicSurveillanceItem)c), c),
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
	