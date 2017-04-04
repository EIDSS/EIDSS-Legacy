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
    public abstract partial class WhoExport : 
        EditableObject<WhoExport>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCase { get; set; }
                
        [LocalizedDisplayName("strCaseIDWho")]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
                
        [LocalizedDisplayName("intAreaIDWho")]
        [MapField(_str_intAreaID)]
        public abstract Int32 intAreaID { get; set; }
        protected Int32 intAreaID_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intAreaID).OriginalValue; } }
        protected Int32 intAreaID_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intAreaID).PreviousValue; } }
                
        [LocalizedDisplayName("datDRashWho")]
        [MapField(_str_datDRash)]
        public abstract DateTime? datDRash { get; set; }
        protected DateTime? datDRash_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDRash).OriginalValue; } }
        protected DateTime? datDRash_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDRash).PreviousValue; } }
                
        [LocalizedDisplayName("intGenderIDWho")]
        [MapField(_str_intGenderID)]
        public abstract Int32 intGenderID { get; set; }
        protected Int32 intGenderID_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intGenderID).OriginalValue; } }
        protected Int32 intGenderID_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intGenderID).PreviousValue; } }
                
        [LocalizedDisplayName("datDBirthWho")]
        [MapField(_str_datDBirth)]
        public abstract DateTime? datDBirth { get; set; }
        protected DateTime? datDBirth_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDBirth).OriginalValue; } }
        protected DateTime? datDBirth_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDBirth).PreviousValue; } }
                
        [LocalizedDisplayName("intAgeAtRashOnsetWho")]
        [MapField(_str_intAgeAtRashOnset)]
        public abstract Int32? intAgeAtRashOnset { get; set; }
        protected Int32? intAgeAtRashOnset_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intAgeAtRashOnset).OriginalValue; } }
        protected Int32? intAgeAtRashOnset_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intAgeAtRashOnset).PreviousValue; } }
                
        [LocalizedDisplayName("intNumOfVaccinesWho")]
        [MapField(_str_intNumOfVaccines)]
        public abstract Int32? intNumOfVaccines { get; set; }
        protected Int32? intNumOfVaccines_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intNumOfVaccines).OriginalValue; } }
        protected Int32? intNumOfVaccines_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intNumOfVaccines).PreviousValue; } }
                
        [LocalizedDisplayName("datDvaccineWho")]
        [MapField(_str_datDvaccine)]
        public abstract DateTime? datDvaccine { get; set; }
        protected DateTime? datDvaccine_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDvaccine).OriginalValue; } }
        protected DateTime? datDvaccine_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDvaccine).PreviousValue; } }
                
        [LocalizedDisplayName("datDNotificationWho")]
        [MapField(_str_datDNotification)]
        public abstract DateTime? datDNotification { get; set; }
        protected DateTime? datDNotification_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDNotification).OriginalValue; } }
        protected DateTime? datDNotification_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDNotification).PreviousValue; } }
                
        [LocalizedDisplayName("datDInvestigationWho")]
        [MapField(_str_datDInvestigation)]
        public abstract DateTime? datDInvestigation { get; set; }
        protected DateTime? datDInvestigation_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDInvestigation).OriginalValue; } }
        protected DateTime? datDInvestigation_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDInvestigation).PreviousValue; } }
                
        [LocalizedDisplayName("intClinFeverWho")]
        [MapField(_str_intClinFever)]
        public abstract Int32? intClinFever { get; set; }
        protected Int32? intClinFever_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intClinFever).OriginalValue; } }
        protected Int32? intClinFever_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intClinFever).PreviousValue; } }
                
        [LocalizedDisplayName("intClinCCCWho")]
        [MapField(_str_intClinCCC)]
        public abstract Int32? intClinCCC { get; set; }
        protected Int32? intClinCCC_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intClinCCC).OriginalValue; } }
        protected Int32? intClinCCC_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intClinCCC).PreviousValue; } }
                
        [LocalizedDisplayName("intClinRashDurationWho")]
        [MapField(_str_intClinRashDuration)]
        public abstract Int32? intClinRashDuration { get; set; }
        protected Int32? intClinRashDuration_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intClinRashDuration).OriginalValue; } }
        protected Int32? intClinRashDuration_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intClinRashDuration).PreviousValue; } }
                
        [LocalizedDisplayName("intClinOutcomeWho")]
        [MapField(_str_intClinOutcome)]
        public abstract Int32? intClinOutcome { get; set; }
        protected Int32? intClinOutcome_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intClinOutcome).OriginalValue; } }
        protected Int32? intClinOutcome_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intClinOutcome).PreviousValue; } }
                
        [LocalizedDisplayName("intClinHospitalizationWho")]
        [MapField(_str_intClinHospitalization)]
        public abstract Int32? intClinHospitalization { get; set; }
        protected Int32? intClinHospitalization_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intClinHospitalization).OriginalValue; } }
        protected Int32? intClinHospitalization_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intClinHospitalization).PreviousValue; } }
                
        [LocalizedDisplayName("intSrcInfWho")]
        [MapField(_str_intSrcInf)]
        public abstract Int32? intSrcInf { get; set; }
        protected Int32? intSrcInf_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intSrcInf).OriginalValue; } }
        protected Int32? intSrcInf_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intSrcInf).PreviousValue; } }
                
        [LocalizedDisplayName("intSrcOutbreakRelatedWho")]
        [MapField(_str_intSrcOutbreakRelated)]
        public abstract Int32? intSrcOutbreakRelated { get; set; }
        protected Int32? intSrcOutbreakRelated_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intSrcOutbreakRelated).OriginalValue; } }
        protected Int32? intSrcOutbreakRelated_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intSrcOutbreakRelated).PreviousValue; } }
                
        [LocalizedDisplayName("strSrcOutbreakIDWho")]
        [MapField(_str_strSrcOutbreakID)]
        public abstract String strSrcOutbreakID { get; set; }
        protected String strSrcOutbreakID_Original { get { return ((EditableValue<String>)((dynamic)this)._strSrcOutbreakID).OriginalValue; } }
        protected String strSrcOutbreakID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSrcOutbreakID).PreviousValue; } }
                
        [LocalizedDisplayName("intCompComplicationsWho")]
        [MapField(_str_intCompComplications)]
        public abstract Int32? intCompComplications { get; set; }
        protected Int32? intCompComplications_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intCompComplications).OriginalValue; } }
        protected Int32? intCompComplications_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intCompComplications).PreviousValue; } }
                
        [LocalizedDisplayName("intCompEncephalitisWho")]
        [MapField(_str_intCompEncephalitis)]
        public abstract Int32? intCompEncephalitis { get; set; }
        protected Int32? intCompEncephalitis_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intCompEncephalitis).OriginalValue; } }
        protected Int32? intCompEncephalitis_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intCompEncephalitis).PreviousValue; } }
                
        [LocalizedDisplayName("intCompPneumoniaWho")]
        [MapField(_str_intCompPneumonia)]
        public abstract Int32? intCompPneumonia { get; set; }
        protected Int32? intCompPneumonia_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intCompPneumonia).OriginalValue; } }
        protected Int32? intCompPneumonia_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intCompPneumonia).PreviousValue; } }
                
        [LocalizedDisplayName("intCompMalnutritionWho")]
        [MapField(_str_intCompMalnutrition)]
        public abstract Int32? intCompMalnutrition { get; set; }
        protected Int32? intCompMalnutrition_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intCompMalnutrition).OriginalValue; } }
        protected Int32? intCompMalnutrition_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intCompMalnutrition).PreviousValue; } }
                
        [LocalizedDisplayName("intCompDiarrhoeaWho")]
        [MapField(_str_intCompDiarrhoea)]
        public abstract Int32? intCompDiarrhoea { get; set; }
        protected Int32? intCompDiarrhoea_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intCompDiarrhoea).OriginalValue; } }
        protected Int32? intCompDiarrhoea_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intCompDiarrhoea).PreviousValue; } }
                
        [LocalizedDisplayName("intCompOtherWho")]
        [MapField(_str_intCompOther)]
        public abstract Int32? intCompOther { get; set; }
        protected Int32? intCompOther_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intCompOther).OriginalValue; } }
        protected Int32? intCompOther_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intCompOther).PreviousValue; } }
                
        [LocalizedDisplayName("intFinalClassificationWho")]
        [MapField(_str_intFinalClassification)]
        public abstract Int32? intFinalClassification { get; set; }
        protected Int32? intFinalClassification_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intFinalClassification).OriginalValue; } }
        protected Int32? intFinalClassification_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intFinalClassification).PreviousValue; } }
                
        [LocalizedDisplayName("datDSpecimenWho")]
        [MapField(_str_datDSpecimen)]
        public abstract DateTime? datDSpecimen { get; set; }
        protected DateTime? datDSpecimen_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDSpecimen).OriginalValue; } }
        protected DateTime? datDSpecimen_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDSpecimen).PreviousValue; } }
                
        [LocalizedDisplayName("intSpecimenWho")]
        [MapField(_str_intSpecimen)]
        public abstract Int32? intSpecimen { get; set; }
        protected Int32? intSpecimen_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intSpecimen).OriginalValue; } }
        protected Int32? intSpecimen_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intSpecimen).PreviousValue; } }
                
        [LocalizedDisplayName("datDLabResultWho")]
        [MapField(_str_datDLabResult)]
        public abstract DateTime? datDLabResult { get; set; }
        protected DateTime? datDLabResult_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDLabResult).OriginalValue; } }
        protected DateTime? datDLabResult_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDLabResult).PreviousValue; } }
                
        [LocalizedDisplayName("intMeaslesIgmWho")]
        [MapField(_str_intMeaslesIgm)]
        public abstract Int32? intMeaslesIgm { get; set; }
        protected Int32? intMeaslesIgm_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intMeaslesIgm).OriginalValue; } }
        protected Int32? intMeaslesIgm_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intMeaslesIgm).PreviousValue; } }
                
        [LocalizedDisplayName("intMeaslesVirusDetectionWho")]
        [MapField(_str_intMeaslesVirusDetection)]
        public abstract Int32? intMeaslesVirusDetection { get; set; }
        protected Int32? intMeaslesVirusDetection_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intMeaslesVirusDetection).OriginalValue; } }
        protected Int32? intMeaslesVirusDetection_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intMeaslesVirusDetection).PreviousValue; } }
                
        [LocalizedDisplayName("intRubellaIgmWho")]
        [MapField(_str_intRubellaIgm)]
        public abstract Int32? intRubellaIgm { get; set; }
        protected Int32? intRubellaIgm_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intRubellaIgm).OriginalValue; } }
        protected Int32? intRubellaIgm_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intRubellaIgm).PreviousValue; } }
                
        [LocalizedDisplayName("intRubellaVirusDetectionWho")]
        [MapField(_str_intRubellaVirusDetection)]
        public abstract Int32? intRubellaVirusDetection { get; set; }
        protected Int32? intRubellaVirusDetection_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intRubellaVirusDetection).OriginalValue; } }
        protected Int32? intRubellaVirusDetection_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intRubellaVirusDetection).PreviousValue; } }
                
        [LocalizedDisplayName("strCommentsEpiWho")]
        [MapField(_str_strCommentsEpi)]
        public abstract String strCommentsEpi { get; set; }
        protected String strCommentsEpi_Original { get { return ((EditableValue<String>)((dynamic)this)._strCommentsEpi).OriginalValue; } }
        protected String strCommentsEpi_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCommentsEpi).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<WhoExport, object> _get_func;
            internal Action<WhoExport, string> _set_func;
            internal Action<WhoExport, WhoExport, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCase = "idfCase";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_intAreaID = "intAreaID";
        internal const string _str_datDRash = "datDRash";
        internal const string _str_intGenderID = "intGenderID";
        internal const string _str_datDBirth = "datDBirth";
        internal const string _str_intAgeAtRashOnset = "intAgeAtRashOnset";
        internal const string _str_intNumOfVaccines = "intNumOfVaccines";
        internal const string _str_datDvaccine = "datDvaccine";
        internal const string _str_datDNotification = "datDNotification";
        internal const string _str_datDInvestigation = "datDInvestigation";
        internal const string _str_intClinFever = "intClinFever";
        internal const string _str_intClinCCC = "intClinCCC";
        internal const string _str_intClinRashDuration = "intClinRashDuration";
        internal const string _str_intClinOutcome = "intClinOutcome";
        internal const string _str_intClinHospitalization = "intClinHospitalization";
        internal const string _str_intSrcInf = "intSrcInf";
        internal const string _str_intSrcOutbreakRelated = "intSrcOutbreakRelated";
        internal const string _str_strSrcOutbreakID = "strSrcOutbreakID";
        internal const string _str_intCompComplications = "intCompComplications";
        internal const string _str_intCompEncephalitis = "intCompEncephalitis";
        internal const string _str_intCompPneumonia = "intCompPneumonia";
        internal const string _str_intCompMalnutrition = "intCompMalnutrition";
        internal const string _str_intCompDiarrhoea = "intCompDiarrhoea";
        internal const string _str_intCompOther = "intCompOther";
        internal const string _str_intFinalClassification = "intFinalClassification";
        internal const string _str_datDSpecimen = "datDSpecimen";
        internal const string _str_intSpecimen = "intSpecimen";
        internal const string _str_datDLabResult = "datDLabResult";
        internal const string _str_intMeaslesIgm = "intMeaslesIgm";
        internal const string _str_intMeaslesVirusDetection = "intMeaslesVirusDetection";
        internal const string _str_intRubellaIgm = "intRubellaIgm";
        internal const string _str_intRubellaVirusDetection = "intRubellaVirusDetection";
        internal const string _str_strCommentsEpi = "strCommentsEpi";
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
              _name = _str_intAreaID, _formname = _str_intAreaID, _type = "Int32",
              _get_func = o => o.intAreaID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intAreaID != newval) o.intAreaID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intAreaID != c.intAreaID || o.IsRIRPropChanged(_str_intAreaID, c)) 
                  m.Add(_str_intAreaID, o.ObjectIdent + _str_intAreaID, o.ObjectIdent2 + _str_intAreaID, o.ObjectIdent3 + _str_intAreaID, "Int32", 
                    o.intAreaID == null ? "" : o.intAreaID.ToString(),                  
                  o.IsReadOnly(_str_intAreaID), o.IsInvisible(_str_intAreaID), o.IsRequired(_str_intAreaID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDRash, _formname = _str_datDRash, _type = "DateTime?",
              _get_func = o => o.datDRash,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDRash != newval) o.datDRash = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDRash != c.datDRash || o.IsRIRPropChanged(_str_datDRash, c)) 
                  m.Add(_str_datDRash, o.ObjectIdent + _str_datDRash, o.ObjectIdent2 + _str_datDRash, o.ObjectIdent3 + _str_datDRash, "DateTime?", 
                    o.datDRash == null ? "" : o.datDRash.ToString(),                  
                  o.IsReadOnly(_str_datDRash), o.IsInvisible(_str_datDRash), o.IsRequired(_str_datDRash)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intGenderID, _formname = _str_intGenderID, _type = "Int32",
              _get_func = o => o.intGenderID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intGenderID != newval) o.intGenderID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intGenderID != c.intGenderID || o.IsRIRPropChanged(_str_intGenderID, c)) 
                  m.Add(_str_intGenderID, o.ObjectIdent + _str_intGenderID, o.ObjectIdent2 + _str_intGenderID, o.ObjectIdent3 + _str_intGenderID, "Int32", 
                    o.intGenderID == null ? "" : o.intGenderID.ToString(),                  
                  o.IsReadOnly(_str_intGenderID), o.IsInvisible(_str_intGenderID), o.IsRequired(_str_intGenderID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDBirth, _formname = _str_datDBirth, _type = "DateTime?",
              _get_func = o => o.datDBirth,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDBirth != newval) o.datDBirth = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDBirth != c.datDBirth || o.IsRIRPropChanged(_str_datDBirth, c)) 
                  m.Add(_str_datDBirth, o.ObjectIdent + _str_datDBirth, o.ObjectIdent2 + _str_datDBirth, o.ObjectIdent3 + _str_datDBirth, "DateTime?", 
                    o.datDBirth == null ? "" : o.datDBirth.ToString(),                  
                  o.IsReadOnly(_str_datDBirth), o.IsInvisible(_str_datDBirth), o.IsRequired(_str_datDBirth)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intAgeAtRashOnset, _formname = _str_intAgeAtRashOnset, _type = "Int32?",
              _get_func = o => o.intAgeAtRashOnset,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intAgeAtRashOnset != newval) o.intAgeAtRashOnset = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intAgeAtRashOnset != c.intAgeAtRashOnset || o.IsRIRPropChanged(_str_intAgeAtRashOnset, c)) 
                  m.Add(_str_intAgeAtRashOnset, o.ObjectIdent + _str_intAgeAtRashOnset, o.ObjectIdent2 + _str_intAgeAtRashOnset, o.ObjectIdent3 + _str_intAgeAtRashOnset, "Int32?", 
                    o.intAgeAtRashOnset == null ? "" : o.intAgeAtRashOnset.ToString(),                  
                  o.IsReadOnly(_str_intAgeAtRashOnset), o.IsInvisible(_str_intAgeAtRashOnset), o.IsRequired(_str_intAgeAtRashOnset)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intNumOfVaccines, _formname = _str_intNumOfVaccines, _type = "Int32?",
              _get_func = o => o.intNumOfVaccines,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intNumOfVaccines != newval) o.intNumOfVaccines = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intNumOfVaccines != c.intNumOfVaccines || o.IsRIRPropChanged(_str_intNumOfVaccines, c)) 
                  m.Add(_str_intNumOfVaccines, o.ObjectIdent + _str_intNumOfVaccines, o.ObjectIdent2 + _str_intNumOfVaccines, o.ObjectIdent3 + _str_intNumOfVaccines, "Int32?", 
                    o.intNumOfVaccines == null ? "" : o.intNumOfVaccines.ToString(),                  
                  o.IsReadOnly(_str_intNumOfVaccines), o.IsInvisible(_str_intNumOfVaccines), o.IsRequired(_str_intNumOfVaccines)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDvaccine, _formname = _str_datDvaccine, _type = "DateTime?",
              _get_func = o => o.datDvaccine,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDvaccine != newval) o.datDvaccine = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDvaccine != c.datDvaccine || o.IsRIRPropChanged(_str_datDvaccine, c)) 
                  m.Add(_str_datDvaccine, o.ObjectIdent + _str_datDvaccine, o.ObjectIdent2 + _str_datDvaccine, o.ObjectIdent3 + _str_datDvaccine, "DateTime?", 
                    o.datDvaccine == null ? "" : o.datDvaccine.ToString(),                  
                  o.IsReadOnly(_str_datDvaccine), o.IsInvisible(_str_datDvaccine), o.IsRequired(_str_datDvaccine)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDNotification, _formname = _str_datDNotification, _type = "DateTime?",
              _get_func = o => o.datDNotification,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDNotification != newval) o.datDNotification = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDNotification != c.datDNotification || o.IsRIRPropChanged(_str_datDNotification, c)) 
                  m.Add(_str_datDNotification, o.ObjectIdent + _str_datDNotification, o.ObjectIdent2 + _str_datDNotification, o.ObjectIdent3 + _str_datDNotification, "DateTime?", 
                    o.datDNotification == null ? "" : o.datDNotification.ToString(),                  
                  o.IsReadOnly(_str_datDNotification), o.IsInvisible(_str_datDNotification), o.IsRequired(_str_datDNotification)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDInvestigation, _formname = _str_datDInvestigation, _type = "DateTime?",
              _get_func = o => o.datDInvestigation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDInvestigation != newval) o.datDInvestigation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDInvestigation != c.datDInvestigation || o.IsRIRPropChanged(_str_datDInvestigation, c)) 
                  m.Add(_str_datDInvestigation, o.ObjectIdent + _str_datDInvestigation, o.ObjectIdent2 + _str_datDInvestigation, o.ObjectIdent3 + _str_datDInvestigation, "DateTime?", 
                    o.datDInvestigation == null ? "" : o.datDInvestigation.ToString(),                  
                  o.IsReadOnly(_str_datDInvestigation), o.IsInvisible(_str_datDInvestigation), o.IsRequired(_str_datDInvestigation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intClinFever, _formname = _str_intClinFever, _type = "Int32?",
              _get_func = o => o.intClinFever,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intClinFever != newval) o.intClinFever = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intClinFever != c.intClinFever || o.IsRIRPropChanged(_str_intClinFever, c)) 
                  m.Add(_str_intClinFever, o.ObjectIdent + _str_intClinFever, o.ObjectIdent2 + _str_intClinFever, o.ObjectIdent3 + _str_intClinFever, "Int32?", 
                    o.intClinFever == null ? "" : o.intClinFever.ToString(),                  
                  o.IsReadOnly(_str_intClinFever), o.IsInvisible(_str_intClinFever), o.IsRequired(_str_intClinFever)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intClinCCC, _formname = _str_intClinCCC, _type = "Int32?",
              _get_func = o => o.intClinCCC,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intClinCCC != newval) o.intClinCCC = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intClinCCC != c.intClinCCC || o.IsRIRPropChanged(_str_intClinCCC, c)) 
                  m.Add(_str_intClinCCC, o.ObjectIdent + _str_intClinCCC, o.ObjectIdent2 + _str_intClinCCC, o.ObjectIdent3 + _str_intClinCCC, "Int32?", 
                    o.intClinCCC == null ? "" : o.intClinCCC.ToString(),                  
                  o.IsReadOnly(_str_intClinCCC), o.IsInvisible(_str_intClinCCC), o.IsRequired(_str_intClinCCC)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intClinRashDuration, _formname = _str_intClinRashDuration, _type = "Int32?",
              _get_func = o => o.intClinRashDuration,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intClinRashDuration != newval) o.intClinRashDuration = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intClinRashDuration != c.intClinRashDuration || o.IsRIRPropChanged(_str_intClinRashDuration, c)) 
                  m.Add(_str_intClinRashDuration, o.ObjectIdent + _str_intClinRashDuration, o.ObjectIdent2 + _str_intClinRashDuration, o.ObjectIdent3 + _str_intClinRashDuration, "Int32?", 
                    o.intClinRashDuration == null ? "" : o.intClinRashDuration.ToString(),                  
                  o.IsReadOnly(_str_intClinRashDuration), o.IsInvisible(_str_intClinRashDuration), o.IsRequired(_str_intClinRashDuration)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intClinOutcome, _formname = _str_intClinOutcome, _type = "Int32?",
              _get_func = o => o.intClinOutcome,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intClinOutcome != newval) o.intClinOutcome = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intClinOutcome != c.intClinOutcome || o.IsRIRPropChanged(_str_intClinOutcome, c)) 
                  m.Add(_str_intClinOutcome, o.ObjectIdent + _str_intClinOutcome, o.ObjectIdent2 + _str_intClinOutcome, o.ObjectIdent3 + _str_intClinOutcome, "Int32?", 
                    o.intClinOutcome == null ? "" : o.intClinOutcome.ToString(),                  
                  o.IsReadOnly(_str_intClinOutcome), o.IsInvisible(_str_intClinOutcome), o.IsRequired(_str_intClinOutcome)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intClinHospitalization, _formname = _str_intClinHospitalization, _type = "Int32?",
              _get_func = o => o.intClinHospitalization,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intClinHospitalization != newval) o.intClinHospitalization = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intClinHospitalization != c.intClinHospitalization || o.IsRIRPropChanged(_str_intClinHospitalization, c)) 
                  m.Add(_str_intClinHospitalization, o.ObjectIdent + _str_intClinHospitalization, o.ObjectIdent2 + _str_intClinHospitalization, o.ObjectIdent3 + _str_intClinHospitalization, "Int32?", 
                    o.intClinHospitalization == null ? "" : o.intClinHospitalization.ToString(),                  
                  o.IsReadOnly(_str_intClinHospitalization), o.IsInvisible(_str_intClinHospitalization), o.IsRequired(_str_intClinHospitalization)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intSrcInf, _formname = _str_intSrcInf, _type = "Int32?",
              _get_func = o => o.intSrcInf,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intSrcInf != newval) o.intSrcInf = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intSrcInf != c.intSrcInf || o.IsRIRPropChanged(_str_intSrcInf, c)) 
                  m.Add(_str_intSrcInf, o.ObjectIdent + _str_intSrcInf, o.ObjectIdent2 + _str_intSrcInf, o.ObjectIdent3 + _str_intSrcInf, "Int32?", 
                    o.intSrcInf == null ? "" : o.intSrcInf.ToString(),                  
                  o.IsReadOnly(_str_intSrcInf), o.IsInvisible(_str_intSrcInf), o.IsRequired(_str_intSrcInf)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intSrcOutbreakRelated, _formname = _str_intSrcOutbreakRelated, _type = "Int32?",
              _get_func = o => o.intSrcOutbreakRelated,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intSrcOutbreakRelated != newval) o.intSrcOutbreakRelated = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intSrcOutbreakRelated != c.intSrcOutbreakRelated || o.IsRIRPropChanged(_str_intSrcOutbreakRelated, c)) 
                  m.Add(_str_intSrcOutbreakRelated, o.ObjectIdent + _str_intSrcOutbreakRelated, o.ObjectIdent2 + _str_intSrcOutbreakRelated, o.ObjectIdent3 + _str_intSrcOutbreakRelated, "Int32?", 
                    o.intSrcOutbreakRelated == null ? "" : o.intSrcOutbreakRelated.ToString(),                  
                  o.IsReadOnly(_str_intSrcOutbreakRelated), o.IsInvisible(_str_intSrcOutbreakRelated), o.IsRequired(_str_intSrcOutbreakRelated)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSrcOutbreakID, _formname = _str_strSrcOutbreakID, _type = "String",
              _get_func = o => o.strSrcOutbreakID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSrcOutbreakID != newval) o.strSrcOutbreakID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSrcOutbreakID != c.strSrcOutbreakID || o.IsRIRPropChanged(_str_strSrcOutbreakID, c)) 
                  m.Add(_str_strSrcOutbreakID, o.ObjectIdent + _str_strSrcOutbreakID, o.ObjectIdent2 + _str_strSrcOutbreakID, o.ObjectIdent3 + _str_strSrcOutbreakID, "String", 
                    o.strSrcOutbreakID == null ? "" : o.strSrcOutbreakID.ToString(),                  
                  o.IsReadOnly(_str_strSrcOutbreakID), o.IsInvisible(_str_strSrcOutbreakID), o.IsRequired(_str_strSrcOutbreakID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intCompComplications, _formname = _str_intCompComplications, _type = "Int32?",
              _get_func = o => o.intCompComplications,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intCompComplications != newval) o.intCompComplications = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intCompComplications != c.intCompComplications || o.IsRIRPropChanged(_str_intCompComplications, c)) 
                  m.Add(_str_intCompComplications, o.ObjectIdent + _str_intCompComplications, o.ObjectIdent2 + _str_intCompComplications, o.ObjectIdent3 + _str_intCompComplications, "Int32?", 
                    o.intCompComplications == null ? "" : o.intCompComplications.ToString(),                  
                  o.IsReadOnly(_str_intCompComplications), o.IsInvisible(_str_intCompComplications), o.IsRequired(_str_intCompComplications)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intCompEncephalitis, _formname = _str_intCompEncephalitis, _type = "Int32?",
              _get_func = o => o.intCompEncephalitis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intCompEncephalitis != newval) o.intCompEncephalitis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intCompEncephalitis != c.intCompEncephalitis || o.IsRIRPropChanged(_str_intCompEncephalitis, c)) 
                  m.Add(_str_intCompEncephalitis, o.ObjectIdent + _str_intCompEncephalitis, o.ObjectIdent2 + _str_intCompEncephalitis, o.ObjectIdent3 + _str_intCompEncephalitis, "Int32?", 
                    o.intCompEncephalitis == null ? "" : o.intCompEncephalitis.ToString(),                  
                  o.IsReadOnly(_str_intCompEncephalitis), o.IsInvisible(_str_intCompEncephalitis), o.IsRequired(_str_intCompEncephalitis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intCompPneumonia, _formname = _str_intCompPneumonia, _type = "Int32?",
              _get_func = o => o.intCompPneumonia,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intCompPneumonia != newval) o.intCompPneumonia = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intCompPneumonia != c.intCompPneumonia || o.IsRIRPropChanged(_str_intCompPneumonia, c)) 
                  m.Add(_str_intCompPneumonia, o.ObjectIdent + _str_intCompPneumonia, o.ObjectIdent2 + _str_intCompPneumonia, o.ObjectIdent3 + _str_intCompPneumonia, "Int32?", 
                    o.intCompPneumonia == null ? "" : o.intCompPneumonia.ToString(),                  
                  o.IsReadOnly(_str_intCompPneumonia), o.IsInvisible(_str_intCompPneumonia), o.IsRequired(_str_intCompPneumonia)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intCompMalnutrition, _formname = _str_intCompMalnutrition, _type = "Int32?",
              _get_func = o => o.intCompMalnutrition,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intCompMalnutrition != newval) o.intCompMalnutrition = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intCompMalnutrition != c.intCompMalnutrition || o.IsRIRPropChanged(_str_intCompMalnutrition, c)) 
                  m.Add(_str_intCompMalnutrition, o.ObjectIdent + _str_intCompMalnutrition, o.ObjectIdent2 + _str_intCompMalnutrition, o.ObjectIdent3 + _str_intCompMalnutrition, "Int32?", 
                    o.intCompMalnutrition == null ? "" : o.intCompMalnutrition.ToString(),                  
                  o.IsReadOnly(_str_intCompMalnutrition), o.IsInvisible(_str_intCompMalnutrition), o.IsRequired(_str_intCompMalnutrition)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intCompDiarrhoea, _formname = _str_intCompDiarrhoea, _type = "Int32?",
              _get_func = o => o.intCompDiarrhoea,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intCompDiarrhoea != newval) o.intCompDiarrhoea = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intCompDiarrhoea != c.intCompDiarrhoea || o.IsRIRPropChanged(_str_intCompDiarrhoea, c)) 
                  m.Add(_str_intCompDiarrhoea, o.ObjectIdent + _str_intCompDiarrhoea, o.ObjectIdent2 + _str_intCompDiarrhoea, o.ObjectIdent3 + _str_intCompDiarrhoea, "Int32?", 
                    o.intCompDiarrhoea == null ? "" : o.intCompDiarrhoea.ToString(),                  
                  o.IsReadOnly(_str_intCompDiarrhoea), o.IsInvisible(_str_intCompDiarrhoea), o.IsRequired(_str_intCompDiarrhoea)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intCompOther, _formname = _str_intCompOther, _type = "Int32?",
              _get_func = o => o.intCompOther,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intCompOther != newval) o.intCompOther = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intCompOther != c.intCompOther || o.IsRIRPropChanged(_str_intCompOther, c)) 
                  m.Add(_str_intCompOther, o.ObjectIdent + _str_intCompOther, o.ObjectIdent2 + _str_intCompOther, o.ObjectIdent3 + _str_intCompOther, "Int32?", 
                    o.intCompOther == null ? "" : o.intCompOther.ToString(),                  
                  o.IsReadOnly(_str_intCompOther), o.IsInvisible(_str_intCompOther), o.IsRequired(_str_intCompOther)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intFinalClassification, _formname = _str_intFinalClassification, _type = "Int32?",
              _get_func = o => o.intFinalClassification,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intFinalClassification != newval) o.intFinalClassification = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intFinalClassification != c.intFinalClassification || o.IsRIRPropChanged(_str_intFinalClassification, c)) 
                  m.Add(_str_intFinalClassification, o.ObjectIdent + _str_intFinalClassification, o.ObjectIdent2 + _str_intFinalClassification, o.ObjectIdent3 + _str_intFinalClassification, "Int32?", 
                    o.intFinalClassification == null ? "" : o.intFinalClassification.ToString(),                  
                  o.IsReadOnly(_str_intFinalClassification), o.IsInvisible(_str_intFinalClassification), o.IsRequired(_str_intFinalClassification)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDSpecimen, _formname = _str_datDSpecimen, _type = "DateTime?",
              _get_func = o => o.datDSpecimen,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDSpecimen != newval) o.datDSpecimen = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDSpecimen != c.datDSpecimen || o.IsRIRPropChanged(_str_datDSpecimen, c)) 
                  m.Add(_str_datDSpecimen, o.ObjectIdent + _str_datDSpecimen, o.ObjectIdent2 + _str_datDSpecimen, o.ObjectIdent3 + _str_datDSpecimen, "DateTime?", 
                    o.datDSpecimen == null ? "" : o.datDSpecimen.ToString(),                  
                  o.IsReadOnly(_str_datDSpecimen), o.IsInvisible(_str_datDSpecimen), o.IsRequired(_str_datDSpecimen)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intSpecimen, _formname = _str_intSpecimen, _type = "Int32?",
              _get_func = o => o.intSpecimen,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intSpecimen != newval) o.intSpecimen = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intSpecimen != c.intSpecimen || o.IsRIRPropChanged(_str_intSpecimen, c)) 
                  m.Add(_str_intSpecimen, o.ObjectIdent + _str_intSpecimen, o.ObjectIdent2 + _str_intSpecimen, o.ObjectIdent3 + _str_intSpecimen, "Int32?", 
                    o.intSpecimen == null ? "" : o.intSpecimen.ToString(),                  
                  o.IsReadOnly(_str_intSpecimen), o.IsInvisible(_str_intSpecimen), o.IsRequired(_str_intSpecimen)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDLabResult, _formname = _str_datDLabResult, _type = "DateTime?",
              _get_func = o => o.datDLabResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDLabResult != newval) o.datDLabResult = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDLabResult != c.datDLabResult || o.IsRIRPropChanged(_str_datDLabResult, c)) 
                  m.Add(_str_datDLabResult, o.ObjectIdent + _str_datDLabResult, o.ObjectIdent2 + _str_datDLabResult, o.ObjectIdent3 + _str_datDLabResult, "DateTime?", 
                    o.datDLabResult == null ? "" : o.datDLabResult.ToString(),                  
                  o.IsReadOnly(_str_datDLabResult), o.IsInvisible(_str_datDLabResult), o.IsRequired(_str_datDLabResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intMeaslesIgm, _formname = _str_intMeaslesIgm, _type = "Int32?",
              _get_func = o => o.intMeaslesIgm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intMeaslesIgm != newval) o.intMeaslesIgm = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intMeaslesIgm != c.intMeaslesIgm || o.IsRIRPropChanged(_str_intMeaslesIgm, c)) 
                  m.Add(_str_intMeaslesIgm, o.ObjectIdent + _str_intMeaslesIgm, o.ObjectIdent2 + _str_intMeaslesIgm, o.ObjectIdent3 + _str_intMeaslesIgm, "Int32?", 
                    o.intMeaslesIgm == null ? "" : o.intMeaslesIgm.ToString(),                  
                  o.IsReadOnly(_str_intMeaslesIgm), o.IsInvisible(_str_intMeaslesIgm), o.IsRequired(_str_intMeaslesIgm)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intMeaslesVirusDetection, _formname = _str_intMeaslesVirusDetection, _type = "Int32?",
              _get_func = o => o.intMeaslesVirusDetection,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intMeaslesVirusDetection != newval) o.intMeaslesVirusDetection = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intMeaslesVirusDetection != c.intMeaslesVirusDetection || o.IsRIRPropChanged(_str_intMeaslesVirusDetection, c)) 
                  m.Add(_str_intMeaslesVirusDetection, o.ObjectIdent + _str_intMeaslesVirusDetection, o.ObjectIdent2 + _str_intMeaslesVirusDetection, o.ObjectIdent3 + _str_intMeaslesVirusDetection, "Int32?", 
                    o.intMeaslesVirusDetection == null ? "" : o.intMeaslesVirusDetection.ToString(),                  
                  o.IsReadOnly(_str_intMeaslesVirusDetection), o.IsInvisible(_str_intMeaslesVirusDetection), o.IsRequired(_str_intMeaslesVirusDetection)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRubellaIgm, _formname = _str_intRubellaIgm, _type = "Int32?",
              _get_func = o => o.intRubellaIgm,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intRubellaIgm != newval) o.intRubellaIgm = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intRubellaIgm != c.intRubellaIgm || o.IsRIRPropChanged(_str_intRubellaIgm, c)) 
                  m.Add(_str_intRubellaIgm, o.ObjectIdent + _str_intRubellaIgm, o.ObjectIdent2 + _str_intRubellaIgm, o.ObjectIdent3 + _str_intRubellaIgm, "Int32?", 
                    o.intRubellaIgm == null ? "" : o.intRubellaIgm.ToString(),                  
                  o.IsReadOnly(_str_intRubellaIgm), o.IsInvisible(_str_intRubellaIgm), o.IsRequired(_str_intRubellaIgm)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRubellaVirusDetection, _formname = _str_intRubellaVirusDetection, _type = "Int32?",
              _get_func = o => o.intRubellaVirusDetection,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intRubellaVirusDetection != newval) o.intRubellaVirusDetection = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intRubellaVirusDetection != c.intRubellaVirusDetection || o.IsRIRPropChanged(_str_intRubellaVirusDetection, c)) 
                  m.Add(_str_intRubellaVirusDetection, o.ObjectIdent + _str_intRubellaVirusDetection, o.ObjectIdent2 + _str_intRubellaVirusDetection, o.ObjectIdent3 + _str_intRubellaVirusDetection, "Int32?", 
                    o.intRubellaVirusDetection == null ? "" : o.intRubellaVirusDetection.ToString(),                  
                  o.IsReadOnly(_str_intRubellaVirusDetection), o.IsInvisible(_str_intRubellaVirusDetection), o.IsRequired(_str_intRubellaVirusDetection)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCommentsEpi, _formname = _str_strCommentsEpi, _type = "String",
              _get_func = o => o.strCommentsEpi,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCommentsEpi != newval) o.strCommentsEpi = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCommentsEpi != c.strCommentsEpi || o.IsRIRPropChanged(_str_strCommentsEpi, c)) 
                  m.Add(_str_strCommentsEpi, o.ObjectIdent + _str_strCommentsEpi, o.ObjectIdent2 + _str_strCommentsEpi, o.ObjectIdent3 + _str_strCommentsEpi, "String", 
                    o.strCommentsEpi == null ? "" : o.strCommentsEpi.ToString(),                  
                  o.IsReadOnly(_str_strCommentsEpi), o.IsInvisible(_str_strCommentsEpi), o.IsRequired(_str_strCommentsEpi)); 
                  }
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
            WhoExport obj = (WhoExport)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "WhoExport";

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
            var ret = base.Clone() as WhoExport;
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
            var ret = base.Clone() as WhoExport;
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
        public WhoExport CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as WhoExport;
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
        
            base.RejectChanges();
        
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

        private bool IsRIRPropChanged(string fld, WhoExport c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, WhoExport c)
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
        

      

        public WhoExport()
        {
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(WhoExport_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(WhoExport_PropertyChanged);
        }
        private void WhoExport_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as WhoExport).Changed(e.PropertyName);
            
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
            WhoExport obj = this;
            
        }
        private void _DeletedExtenders()
        {
            WhoExport obj = this;
            
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


        internal Dictionary<string, Func<WhoExport, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<WhoExport, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<WhoExport, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<WhoExport, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<WhoExport, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<WhoExport, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<WhoExport, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~WhoExport()
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
        
            }
            ParsedFormCollection(form);
        }
    
        #region Class for web grid
        public class WhoExportGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfCase { get; set; }
        
            public String strCaseID { get; set; }
        
            public Int32 intAreaID { get; set; }
        
            public DateTimeWrap datDRash { get; set; }
        
            public Int32 intGenderID { get; set; }
        
            public DateTimeWrap datDBirth { get; set; }
        
            public Int32? intAgeAtRashOnset { get; set; }
        
            public Int32? intNumOfVaccines { get; set; }
        
            public DateTimeWrap datDvaccine { get; set; }
        
            public DateTimeWrap datDNotification { get; set; }
        
            public DateTimeWrap datDInvestigation { get; set; }
        
            public Int32? intClinFever { get; set; }
        
            public Int32? intClinCCC { get; set; }
        
            public Int32? intClinRashDuration { get; set; }
        
            public Int32? intClinOutcome { get; set; }
        
            public Int32? intClinHospitalization { get; set; }
        
            public Int32? intSrcInf { get; set; }
        
            public Int32? intSrcOutbreakRelated { get; set; }
        
            public String strSrcOutbreakID { get; set; }
        
            public Int32? intCompComplications { get; set; }
        
            public Int32? intCompEncephalitis { get; set; }
        
            public Int32? intCompPneumonia { get; set; }
        
            public Int32? intCompMalnutrition { get; set; }
        
            public Int32? intCompDiarrhoea { get; set; }
        
            public Int32? intCompOther { get; set; }
        
            public Int32? intFinalClassification { get; set; }
        
            public DateTimeWrap datDSpecimen { get; set; }
        
            public Int32? intSpecimen { get; set; }
        
            public DateTimeWrap datDLabResult { get; set; }
        
            public Int32? intMeaslesIgm { get; set; }
        
            public Int32? intMeaslesVirusDetection { get; set; }
        
            public Int32? intRubellaIgm { get; set; }
        
            public Int32? intRubellaVirusDetection { get; set; }
        
            public String strCommentsEpi { get; set; }
        
        }
        public partial class WhoExportGridModelList : List<WhoExportGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public WhoExportGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<WhoExport>, errMes);
            }
            public WhoExportGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<WhoExport>, errMes);
            }
            public WhoExportGridModelList(long key, IEnumerable<WhoExport> items)
            {
                LoadGridModelList(key, items, null);
            }
            public WhoExportGridModelList(long key)
            {
                LoadGridModelList(key, new List<WhoExport>(), null);
            }
            partial void filter(List<WhoExport> items);
            private void LoadGridModelList(long key, IEnumerable<WhoExport> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strCaseID,_str_intAreaID,_str_datDRash,_str_intGenderID,_str_datDBirth,_str_intAgeAtRashOnset,_str_intNumOfVaccines,_str_datDvaccine,_str_datDNotification,_str_datDInvestigation,_str_intClinFever,_str_intClinCCC,_str_intClinRashDuration,_str_intClinOutcome,_str_intClinHospitalization,_str_intSrcInf,_str_intSrcOutbreakRelated,_str_strSrcOutbreakID,_str_intCompComplications,_str_intCompEncephalitis,_str_intCompPneumonia,_str_intCompMalnutrition,_str_intCompDiarrhoea,_str_intCompOther,_str_intFinalClassification,_str_datDSpecimen,_str_intSpecimen,_str_datDLabResult,_str_intMeaslesIgm,_str_intMeaslesVirusDetection,_str_intRubellaIgm,_str_intRubellaVirusDetection,_str_strCommentsEpi};
                    
                Hiddens = new List<string> {_str_idfCase};
                Keys = new List<string> {_str_idfCase};
                Labels = new Dictionary<string, string> {{_str_strCaseID, "strCaseIDWho"},{_str_intAreaID, "intAreaIDWho"},{_str_datDRash, "datDRashWho"},{_str_intGenderID, "intGenderIDWho"},{_str_datDBirth, "datDBirthWho"},{_str_intAgeAtRashOnset, "intAgeAtRashOnsetWho"},{_str_intNumOfVaccines, "intNumOfVaccinesWho"},{_str_datDvaccine, "datDvaccineWho"},{_str_datDNotification, "datDNotificationWho"},{_str_datDInvestigation, "datDInvestigationWho"},{_str_intClinFever, "intClinFeverWho"},{_str_intClinCCC, "intClinCCCWho"},{_str_intClinRashDuration, "intClinRashDurationWho"},{_str_intClinOutcome, "intClinOutcomeWho"},{_str_intClinHospitalization, "intClinHospitalizationWho"},{_str_intSrcInf, "intSrcInfWho"},{_str_intSrcOutbreakRelated, "intSrcOutbreakRelatedWho"},{_str_strSrcOutbreakID, "strSrcOutbreakIDWho"},{_str_intCompComplications, "intCompComplicationsWho"},{_str_intCompEncephalitis, "intCompEncephalitisWho"},{_str_intCompPneumonia, "intCompPneumoniaWho"},{_str_intCompMalnutrition, "intCompMalnutritionWho"},{_str_intCompDiarrhoea, "intCompDiarrhoeaWho"},{_str_intCompOther, "intCompOtherWho"},{_str_intFinalClassification, "intFinalClassificationWho"},{_str_datDSpecimen, "datDSpecimenWho"},{_str_intSpecimen, "intSpecimenWho"},{_str_datDLabResult, "datDLabResultWho"},{_str_intMeaslesIgm, "intMeaslesIgmWho"},{_str_intMeaslesVirusDetection, "intMeaslesVirusDetectionWho"},{_str_intRubellaIgm, "intRubellaIgmWho"},{_str_intRubellaVirusDetection, "intRubellaVirusDetectionWho"},{_str_strCommentsEpi, "strCommentsEpiWho"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                WhoExport.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<WhoExport>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new WhoExportGridModel()
                {
                    ItemKey=c.idfCase,strCaseID=c.strCaseID,intAreaID=c.intAreaID,datDRash=c.datDRash,intGenderID=c.intGenderID,datDBirth=c.datDBirth,intAgeAtRashOnset=c.intAgeAtRashOnset,intNumOfVaccines=c.intNumOfVaccines,datDvaccine=c.datDvaccine,datDNotification=c.datDNotification,datDInvestigation=c.datDInvestigation,intClinFever=c.intClinFever,intClinCCC=c.intClinCCC,intClinRashDuration=c.intClinRashDuration,intClinOutcome=c.intClinOutcome,intClinHospitalization=c.intClinHospitalization,intSrcInf=c.intSrcInf,intSrcOutbreakRelated=c.intSrcOutbreakRelated,strSrcOutbreakID=c.strSrcOutbreakID,intCompComplications=c.intCompComplications,intCompEncephalitis=c.intCompEncephalitis,intCompPneumonia=c.intCompPneumonia,intCompMalnutrition=c.intCompMalnutrition,intCompDiarrhoea=c.intCompDiarrhoea,intCompOther=c.intCompOther,intFinalClassification=c.intFinalClassification,datDSpecimen=c.datDSpecimen,intSpecimen=c.intSpecimen,datDLabResult=c.datDLabResult,intMeaslesIgm=c.intMeaslesIgm,intMeaslesVirusDetection=c.intMeaslesVirusDetection,intRubellaIgm=c.intRubellaIgm,intRubellaVirusDetection=c.intRubellaVirusDetection,strCommentsEpi=c.strCommentsEpi
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
        : DataAccessor<WhoExport>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<WhoExport>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfCase"; } }
            #endregion
        
            public delegate void on_action(WhoExport obj);
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
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (DateTime?)ident
                        
                    , null
                        
                    , null
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<WhoExport> SelectList(DbManagerProxy manager
                , DateTime? StartDate
                , DateTime? EndDate
                , Int64? idfsDiagnosis
                )
            {
                return _SelectList(manager
                    , StartDate
                    , EndDate
                    , idfsDiagnosis
                    , delegate(WhoExport obj)
                        {
                        }
                    , delegate(WhoExport obj)
                        {
                        }
                    );
            }

            

            public List<WhoExport> _SelectList(DbManagerProxy manager
                , DateTime? StartDate
                , DateTime? EndDate
                , Int64? idfsDiagnosis
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , StartDate
                    , EndDate
                    , idfsDiagnosis
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<WhoExport> _SelectListInternal(DbManagerProxy manager
                , DateTime? StartDate
                , DateTime? EndDate
                , Int64? idfsDiagnosis
                , on_action loading, on_action loaded
                )
            {
                WhoExport _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<WhoExport> objs = new List<WhoExport>();
                    sets[0] = new MapResultSet(typeof(WhoExport), objs);
                    
                    manager
                        .SetSpCommand("spWhoExport_SelectDetail"
                            , manager.Parameter("@StartDate", StartDate)
                            , manager.Parameter("@EndDate", EndDate)
                            , manager.Parameter("@idfsDiagnosis", idfsDiagnosis)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
                        _obj = obj;
                        obj.m_CS = m_CS;
                        
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, WhoExport obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, WhoExport obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private WhoExport _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                WhoExport obj = null;
                try
                {
                    obj = WhoExport.CreateInstance();
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

            
            public WhoExport CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public WhoExport CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public WhoExport CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(WhoExport obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(WhoExport obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, WhoExport obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(WhoExport obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(WhoExport obj, bool bRethrowException)
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
                return Validate(manager, obj as WhoExport, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, WhoExport obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(WhoExport obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(WhoExport obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as WhoExport) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as WhoExport) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "WhoExportDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spWhoExport_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<WhoExport, bool>> RequiredByField = new Dictionary<string, Func<WhoExport, bool>>();
            public static Dictionary<string, Func<WhoExport, bool>> RequiredByProperty = new Dictionary<string, Func<WhoExport, bool>>();
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
                
                Sizes.Add(_str_strCaseID, 300);
                Sizes.Add(_str_strSrcOutbreakID, 50);
                Sizes.Add(_str_strCommentsEpi, 500);
                GridMeta.Add(new GridMetaItem(
                    _str_idfCase,
                    _str_idfCase, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseID,
                    "strCaseIDWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intAreaID,
                    "intAreaIDWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datDRash,
                    "datDRashWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intGenderID,
                    "intGenderIDWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datDBirth,
                    "datDBirthWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intAgeAtRashOnset,
                    "intAgeAtRashOnsetWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intNumOfVaccines,
                    "intNumOfVaccinesWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datDvaccine,
                    "datDvaccineWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datDNotification,
                    "datDNotificationWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datDInvestigation,
                    "datDInvestigationWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intClinFever,
                    "intClinFeverWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intClinCCC,
                    "intClinCCCWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intClinRashDuration,
                    "intClinRashDurationWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intClinOutcome,
                    "intClinOutcomeWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intClinHospitalization,
                    "intClinHospitalizationWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intSrcInf,
                    "intSrcInfWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intSrcOutbreakRelated,
                    "intSrcOutbreakRelatedWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSrcOutbreakID,
                    "strSrcOutbreakIDWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intCompComplications,
                    "intCompComplicationsWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intCompEncephalitis,
                    "intCompEncephalitisWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intCompPneumonia,
                    "intCompPneumoniaWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intCompMalnutrition,
                    "intCompMalnutritionWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intCompDiarrhoea,
                    "intCompDiarrhoeaWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intCompOther,
                    "intCompOtherWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intFinalClassification,
                    "intFinalClassificationWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datDSpecimen,
                    "datDSpecimenWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intSpecimen,
                    "intSpecimenWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datDLabResult,
                    "datDLabResultWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intMeaslesIgm,
                    "intMeaslesIgmWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intMeaslesVirusDetection,
                    "intMeaslesVirusDetectionWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intRubellaIgm,
                    "intRubellaIgmWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intRubellaVirusDetection,
                    "intRubellaVirusDetectionWho", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCommentsEpi,
                    "strCommentsEpiWho", null, false, true, true, true, true, null
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
                        ActionsPanelType.Group,
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
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
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
                    (manager, c, pars) => ((WhoExport)c).MarkToDelete(),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
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
                    (manager, c, pars) => new ActResult(true, c),
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
	