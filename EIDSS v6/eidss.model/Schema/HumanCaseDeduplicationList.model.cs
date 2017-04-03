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
    public abstract partial class HumanCaseDeduplicationListItem : 
        EditableObject<HumanCaseDeduplicationListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCase { get; set; }
                
        [LocalizedDisplayName(_str_idfsTentativeDiagnosis)]
        [MapField(_str_idfsTentativeDiagnosis)]
        public abstract Int64? idfsTentativeDiagnosis { get; set; }
        protected Int64? idfsTentativeDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis).OriginalValue; } }
        protected Int64? idfsTentativeDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTentativeDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_TentativeDiagnosisName)]
        [MapField(_str_TentativeDiagnosisName)]
        public abstract String TentativeDiagnosisName { get; set; }
        protected String TentativeDiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._tentativeDiagnosisName).OriginalValue; } }
        protected String TentativeDiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._tentativeDiagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFinalDiagnosis)]
        [MapField(_str_idfsFinalDiagnosis)]
        public abstract Int64? idfsFinalDiagnosis { get; set; }
        protected Int64? idfsFinalDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalDiagnosis).OriginalValue; } }
        protected Int64? idfsFinalDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFinalDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_FinalDiagnosisName)]
        [MapField(_str_FinalDiagnosisName)]
        public abstract String FinalDiagnosisName { get; set; }
        protected String FinalDiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._finalDiagnosisName).OriginalValue; } }
        protected String FinalDiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._finalDiagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datEnteredDate)]
        [MapField(_str_datEnteredDate)]
        public abstract DateTime? datEnteredDate { get; set; }
        protected DateTime? datEnteredDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).OriginalValue; } }
        protected DateTime? datEnteredDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCaseID)]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strLocalIdentifier)]
        [MapField(_str_strLocalIdentifier)]
        public abstract String strLocalIdentifier { get; set; }
        protected String strLocalIdentifier_Original { get { return ((EditableValue<String>)((dynamic)this)._strLocalIdentifier).OriginalValue; } }
        protected String strLocalIdentifier_Previous { get { return ((EditableValue<String>)((dynamic)this)._strLocalIdentifier).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strLastName)]
        [MapField(_str_strLastName)]
        public abstract String strLastName { get; set; }
        protected String strLastName_Original { get { return ((EditableValue<String>)((dynamic)this)._strLastName).OriginalValue; } }
        protected String strLastName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strLastName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFirstName)]
        [MapField(_str_strFirstName)]
        public abstract String strFirstName { get; set; }
        protected String strFirstName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).OriginalValue; } }
        protected String strFirstName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSecondName)]
        [MapField(_str_strSecondName)]
        public abstract String strSecondName { get; set; }
        protected String strSecondName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSecondName).OriginalValue; } }
        protected String strSecondName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSecondName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_PatientName)]
        [MapField(_str_PatientName)]
        public abstract String PatientName { get; set; }
        protected String PatientName_Original { get { return ((EditableValue<String>)((dynamic)this)._patientName).OriginalValue; } }
        protected String PatientName_Previous { get { return ((EditableValue<String>)((dynamic)this)._patientName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intPatientAge)]
        [MapField(_str_intPatientAge)]
        public abstract Int32? intPatientAge { get; set; }
        protected Int32? intPatientAge_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intPatientAge).OriginalValue; } }
        protected Int32? intPatientAge_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intPatientAge).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsHumanAgeType)]
        [MapField(_str_idfsHumanAgeType)]
        public abstract Int64? idfsHumanAgeType { get; set; }
        protected Int64? idfsHumanAgeType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanAgeType).OriginalValue; } }
        protected Int64? idfsHumanAgeType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanAgeType).PreviousValue; } }
                
        [LocalizedDisplayName("HumanAgeType_Name")]
        [MapField(_str_HumanAgeTypeName)]
        public abstract String HumanAgeTypeName { get; set; }
        protected String HumanAgeTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._humanAgeTypeName).OriginalValue; } }
        protected String HumanAgeTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._humanAgeTypeName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Age)]
        [MapField(_str_Age)]
        public abstract String Age { get; set; }
        protected String Age_Original { get { return ((EditableValue<String>)((dynamic)this)._age).OriginalValue; } }
        protected String Age_Previous { get { return ((EditableValue<String>)((dynamic)this)._age).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<HumanCaseDeduplicationListItem, object> _get_func;
            internal Action<HumanCaseDeduplicationListItem, string> _set_func;
            internal Action<HumanCaseDeduplicationListItem, HumanCaseDeduplicationListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfsTentativeDiagnosis = "idfsTentativeDiagnosis";
        internal const string _str_TentativeDiagnosisName = "TentativeDiagnosisName";
        internal const string _str_idfsFinalDiagnosis = "idfsFinalDiagnosis";
        internal const string _str_FinalDiagnosisName = "FinalDiagnosisName";
        internal const string _str_datEnteredDate = "datEnteredDate";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_strLocalIdentifier = "strLocalIdentifier";
        internal const string _str_strLastName = "strLastName";
        internal const string _str_strFirstName = "strFirstName";
        internal const string _str_strSecondName = "strSecondName";
        internal const string _str_PatientName = "PatientName";
        internal const string _str_intPatientAge = "intPatientAge";
        internal const string _str_idfsHumanAgeType = "idfsHumanAgeType";
        internal const string _str_HumanAgeTypeName = "HumanAgeTypeName";
        internal const string _str_Age = "Age";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfCase, _formname = _str_idfCase, _type = "Int64",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfCase != newval) o.idfCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, o.ObjectIdent2 + _str_idfCase, o.ObjectIdent3 + _str_idfCase, "Int64", 
                    o.idfCase == null ? "" : o.idfCase.ToString(),                  
                  o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTentativeDiagnosis, _formname = _str_idfsTentativeDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsTentativeDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTentativeDiagnosis != newval) o.idfsTentativeDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsTentativeDiagnosis != c.idfsTentativeDiagnosis || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis, c)) 
                  m.Add(_str_idfsTentativeDiagnosis, o.ObjectIdent + _str_idfsTentativeDiagnosis, o.ObjectIdent2 + _str_idfsTentativeDiagnosis, o.ObjectIdent3 + _str_idfsTentativeDiagnosis, "Int64?", 
                    o.idfsTentativeDiagnosis == null ? "" : o.idfsTentativeDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsTentativeDiagnosis), o.IsInvisible(_str_idfsTentativeDiagnosis), o.IsRequired(_str_idfsTentativeDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_TentativeDiagnosisName, _formname = _str_TentativeDiagnosisName, _type = "String",
              _get_func = o => o.TentativeDiagnosisName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.TentativeDiagnosisName != newval) o.TentativeDiagnosisName = newval; },
              _compare_func = (o, c, m) => {
                if (o.TentativeDiagnosisName != c.TentativeDiagnosisName || o.IsRIRPropChanged(_str_TentativeDiagnosisName, c)) 
                  m.Add(_str_TentativeDiagnosisName, o.ObjectIdent + _str_TentativeDiagnosisName, o.ObjectIdent2 + _str_TentativeDiagnosisName, o.ObjectIdent3 + _str_TentativeDiagnosisName, "String", 
                    o.TentativeDiagnosisName == null ? "" : o.TentativeDiagnosisName.ToString(),                  
                  o.IsReadOnly(_str_TentativeDiagnosisName), o.IsInvisible(_str_TentativeDiagnosisName), o.IsRequired(_str_TentativeDiagnosisName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsFinalDiagnosis, _formname = _str_idfsFinalDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsFinalDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsFinalDiagnosis != newval) o.idfsFinalDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsFinalDiagnosis != c.idfsFinalDiagnosis || o.IsRIRPropChanged(_str_idfsFinalDiagnosis, c)) 
                  m.Add(_str_idfsFinalDiagnosis, o.ObjectIdent + _str_idfsFinalDiagnosis, o.ObjectIdent2 + _str_idfsFinalDiagnosis, o.ObjectIdent3 + _str_idfsFinalDiagnosis, "Int64?", 
                    o.idfsFinalDiagnosis == null ? "" : o.idfsFinalDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsFinalDiagnosis), o.IsInvisible(_str_idfsFinalDiagnosis), o.IsRequired(_str_idfsFinalDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_FinalDiagnosisName, _formname = _str_FinalDiagnosisName, _type = "String",
              _get_func = o => o.FinalDiagnosisName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.FinalDiagnosisName != newval) o.FinalDiagnosisName = newval; },
              _compare_func = (o, c, m) => {
                if (o.FinalDiagnosisName != c.FinalDiagnosisName || o.IsRIRPropChanged(_str_FinalDiagnosisName, c)) 
                  m.Add(_str_FinalDiagnosisName, o.ObjectIdent + _str_FinalDiagnosisName, o.ObjectIdent2 + _str_FinalDiagnosisName, o.ObjectIdent3 + _str_FinalDiagnosisName, "String", 
                    o.FinalDiagnosisName == null ? "" : o.FinalDiagnosisName.ToString(),                  
                  o.IsReadOnly(_str_FinalDiagnosisName), o.IsInvisible(_str_FinalDiagnosisName), o.IsRequired(_str_FinalDiagnosisName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datEnteredDate, _formname = _str_datEnteredDate, _type = "DateTime?",
              _get_func = o => o.datEnteredDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datEnteredDate != newval) o.datEnteredDate = newval; },
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
                if (o.strCaseID != c.strCaseID || o.IsRIRPropChanged(_str_strCaseID, c)) 
                  m.Add(_str_strCaseID, o.ObjectIdent + _str_strCaseID, o.ObjectIdent2 + _str_strCaseID, o.ObjectIdent3 + _str_strCaseID, "String", 
                    o.strCaseID == null ? "" : o.strCaseID.ToString(),                  
                  o.IsReadOnly(_str_strCaseID), o.IsInvisible(_str_strCaseID), o.IsRequired(_str_strCaseID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strLocalIdentifier, _formname = _str_strLocalIdentifier, _type = "String",
              _get_func = o => o.strLocalIdentifier,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strLocalIdentifier != newval) o.strLocalIdentifier = newval; },
              _compare_func = (o, c, m) => {
                if (o.strLocalIdentifier != c.strLocalIdentifier || o.IsRIRPropChanged(_str_strLocalIdentifier, c)) 
                  m.Add(_str_strLocalIdentifier, o.ObjectIdent + _str_strLocalIdentifier, o.ObjectIdent2 + _str_strLocalIdentifier, o.ObjectIdent3 + _str_strLocalIdentifier, "String", 
                    o.strLocalIdentifier == null ? "" : o.strLocalIdentifier.ToString(),                  
                  o.IsReadOnly(_str_strLocalIdentifier), o.IsInvisible(_str_strLocalIdentifier), o.IsRequired(_str_strLocalIdentifier)); 
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
              _name = _str_strSecondName, _formname = _str_strSecondName, _type = "String",
              _get_func = o => o.strSecondName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSecondName != newval) o.strSecondName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSecondName != c.strSecondName || o.IsRIRPropChanged(_str_strSecondName, c)) 
                  m.Add(_str_strSecondName, o.ObjectIdent + _str_strSecondName, o.ObjectIdent2 + _str_strSecondName, o.ObjectIdent3 + _str_strSecondName, "String", 
                    o.strSecondName == null ? "" : o.strSecondName.ToString(),                  
                  o.IsReadOnly(_str_strSecondName), o.IsInvisible(_str_strSecondName), o.IsRequired(_str_strSecondName)); 
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
              _name = _str_intPatientAge, _formname = _str_intPatientAge, _type = "Int32?",
              _get_func = o => o.intPatientAge,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intPatientAge != newval) o.intPatientAge = newval; },
              _compare_func = (o, c, m) => {
                if (o.intPatientAge != c.intPatientAge || o.IsRIRPropChanged(_str_intPatientAge, c)) 
                  m.Add(_str_intPatientAge, o.ObjectIdent + _str_intPatientAge, o.ObjectIdent2 + _str_intPatientAge, o.ObjectIdent3 + _str_intPatientAge, "Int32?", 
                    o.intPatientAge == null ? "" : o.intPatientAge.ToString(),                  
                  o.IsReadOnly(_str_intPatientAge), o.IsInvisible(_str_intPatientAge), o.IsRequired(_str_intPatientAge)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsHumanAgeType, _formname = _str_idfsHumanAgeType, _type = "Int64?",
              _get_func = o => o.idfsHumanAgeType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsHumanAgeType != newval) o.idfsHumanAgeType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsHumanAgeType != c.idfsHumanAgeType || o.IsRIRPropChanged(_str_idfsHumanAgeType, c)) 
                  m.Add(_str_idfsHumanAgeType, o.ObjectIdent + _str_idfsHumanAgeType, o.ObjectIdent2 + _str_idfsHumanAgeType, o.ObjectIdent3 + _str_idfsHumanAgeType, "Int64?", 
                    o.idfsHumanAgeType == null ? "" : o.idfsHumanAgeType.ToString(),                  
                  o.IsReadOnly(_str_idfsHumanAgeType), o.IsInvisible(_str_idfsHumanAgeType), o.IsRequired(_str_idfsHumanAgeType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_HumanAgeTypeName, _formname = _str_HumanAgeTypeName, _type = "String",
              _get_func = o => o.HumanAgeTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.HumanAgeTypeName != newval) o.HumanAgeTypeName = newval; },
              _compare_func = (o, c, m) => {
                if (o.HumanAgeTypeName != c.HumanAgeTypeName || o.IsRIRPropChanged(_str_HumanAgeTypeName, c)) 
                  m.Add(_str_HumanAgeTypeName, o.ObjectIdent + _str_HumanAgeTypeName, o.ObjectIdent2 + _str_HumanAgeTypeName, o.ObjectIdent3 + _str_HumanAgeTypeName, "String", 
                    o.HumanAgeTypeName == null ? "" : o.HumanAgeTypeName.ToString(),                  
                  o.IsReadOnly(_str_HumanAgeTypeName), o.IsInvisible(_str_HumanAgeTypeName), o.IsRequired(_str_HumanAgeTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Age, _formname = _str_Age, _type = "String",
              _get_func = o => o.Age,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.Age != newval) o.Age = newval; },
              _compare_func = (o, c, m) => {
                if (o.Age != c.Age || o.IsRIRPropChanged(_str_Age, c)) 
                  m.Add(_str_Age, o.ObjectIdent + _str_Age, o.ObjectIdent2 + _str_Age, o.ObjectIdent3 + _str_Age, "String", 
                    o.Age == null ? "" : o.Age.ToString(),                  
                  o.IsReadOnly(_str_Age), o.IsInvisible(_str_Age), o.IsRequired(_str_Age)); 
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
            HumanCaseDeduplicationListItem obj = (HumanCaseDeduplicationListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
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
        internal string m_ObjectName = "HumanCaseDeduplicationListItem";

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
            var ret = base.Clone() as HumanCaseDeduplicationListItem;
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
            var ret = base.Clone() as HumanCaseDeduplicationListItem;
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
        public HumanCaseDeduplicationListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as HumanCaseDeduplicationListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfCase; } }
        public string KeyName { get { return "idfCase"; } }
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

        private bool IsRIRPropChanged(string fld, HumanCaseDeduplicationListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public HumanCaseDeduplicationListItem()
        {
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(HumanCaseDeduplicationListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(HumanCaseDeduplicationListItem_PropertyChanged);
        }
        private void HumanCaseDeduplicationListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as HumanCaseDeduplicationListItem).Changed(e.PropertyName);
            
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
            HumanCaseDeduplicationListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            HumanCaseDeduplicationListItem obj = this;
            
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

    
        private bool _isReadOnly(string name)
        {
            
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


        internal Dictionary<string, Func<HumanCaseDeduplicationListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<HumanCaseDeduplicationListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<HumanCaseDeduplicationListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<HumanCaseDeduplicationListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<HumanCaseDeduplicationListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<HumanCaseDeduplicationListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<HumanCaseDeduplicationListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~HumanCaseDeduplicationListItem()
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
        public class HumanCaseDeduplicationListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfCase { get; set; }
        
            public String strLocalIdentifier { get; set; }
        
            public String strLastName { get; set; }
        
            public String strFirstName { get; set; }
        
            public String strSecondName { get; set; }
        
            public Int32? intPatientAge { get; set; }
        
            public String HumanAgeTypeName { get; set; }
        
            public String TentativeDiagnosisName { get; set; }
        
            public String FinalDiagnosisName { get; set; }
        
        }
        public partial class HumanCaseDeduplicationListItemGridModelList : List<HumanCaseDeduplicationListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public HumanCaseDeduplicationListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<HumanCaseDeduplicationListItem>, errMes);
            }
            public HumanCaseDeduplicationListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<HumanCaseDeduplicationListItem>, errMes);
            }
            public HumanCaseDeduplicationListItemGridModelList(long key, IEnumerable<HumanCaseDeduplicationListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public HumanCaseDeduplicationListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<HumanCaseDeduplicationListItem>(), null);
            }
            partial void filter(List<HumanCaseDeduplicationListItem> items);
            private void LoadGridModelList(long key, IEnumerable<HumanCaseDeduplicationListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strLocalIdentifier,_str_strLastName,_str_strFirstName,_str_strSecondName,_str_intPatientAge,_str_HumanAgeTypeName,_str_TentativeDiagnosisName,_str_FinalDiagnosisName};
                    
                Hiddens = new List<string> {_str_idfCase};
                Keys = new List<string> {_str_idfCase};
                Labels = new Dictionary<string, string> {{_str_strLocalIdentifier, _str_strLocalIdentifier},{_str_strLastName, _str_strLastName},{_str_strFirstName, _str_strFirstName},{_str_strSecondName, _str_strSecondName},{_str_intPatientAge, _str_intPatientAge},{_str_HumanAgeTypeName, "HumanAgeType_Name"},{_str_TentativeDiagnosisName, _str_TentativeDiagnosisName},{_str_FinalDiagnosisName, _str_FinalDiagnosisName}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                HumanCaseDeduplicationListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<HumanCaseDeduplicationListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new HumanCaseDeduplicationListItemGridModel()
                {
                    ItemKey=c.idfCase,strLocalIdentifier=c.strLocalIdentifier,strLastName=c.strLastName,strFirstName=c.strFirstName,strSecondName=c.strSecondName,intPatientAge=c.intPatientAge,HumanAgeTypeName=c.HumanAgeTypeName,TentativeDiagnosisName=c.TentativeDiagnosisName,FinalDiagnosisName=c.FinalDiagnosisName
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
        : DataAccessor<HumanCaseDeduplicationListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<HumanCaseDeduplicationListItem>
            
            , IObjectSelectList
            , IObjectSelectList<HumanCaseDeduplicationListItem>
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfCase"; } }
            #endregion
        
            private delegate void on_action(HumanCaseDeduplicationListItem obj);
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
            
            public virtual List<HumanCaseDeduplicationListItem> SelectListT(DbManagerProxy manager
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
            
            private List<HumanCaseDeduplicationListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_HumanCaseDeduplicationWeb_SelectList.* from dbo.fn_HumanCaseDeduplicationWeb_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfCase"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfCase"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfCase") ? " or " : " and ");
                        
                        if (filters.Operation("idfCase", i) == "&")
                          sql.AppendFormat("(isnull(fn_HumanCaseDeduplicationWeb_SelectList.idfCase,0) {0} @idfCase_{1} = @idfCase_{1})", filters.Operation("idfCase", i), i);
                        else
                          sql.AppendFormat("isnull(fn_HumanCaseDeduplicationWeb_SelectList.idfCase,0) {0} @idfCase_{1}", filters.Operation("idfCase", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_HumanCaseDeduplicationWeb_SelectList.idfsTentativeDiagnosis,0) {0} @idfsTentativeDiagnosis_{1} = @idfsTentativeDiagnosis_{1})", filters.Operation("idfsTentativeDiagnosis", i), i);
                        else
                          sql.AppendFormat("isnull(fn_HumanCaseDeduplicationWeb_SelectList.idfsTentativeDiagnosis,0) {0} @idfsTentativeDiagnosis_{1}", filters.Operation("idfsTentativeDiagnosis", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("TentativeDiagnosisName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("TentativeDiagnosisName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("TentativeDiagnosisName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCaseDeduplicationWeb_SelectList.TentativeDiagnosisName {0} @TentativeDiagnosisName_{1}", filters.Operation("TentativeDiagnosisName", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_HumanCaseDeduplicationWeb_SelectList.idfsFinalDiagnosis,0) {0} @idfsFinalDiagnosis_{1} = @idfsFinalDiagnosis_{1})", filters.Operation("idfsFinalDiagnosis", i), i);
                        else
                          sql.AppendFormat("isnull(fn_HumanCaseDeduplicationWeb_SelectList.idfsFinalDiagnosis,0) {0} @idfsFinalDiagnosis_{1}", filters.Operation("idfsFinalDiagnosis", i), i);
                            
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
                        
                        sql.AppendFormat("fn_HumanCaseDeduplicationWeb_SelectList.FinalDiagnosisName {0} @FinalDiagnosisName_{1}", filters.Operation("FinalDiagnosisName", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_HumanCaseDeduplicationWeb_SelectList.datEnteredDate, 112) {0} CONVERT(NVARCHAR(8), @datEnteredDate_{1}, 112)", filters.Operation("datEnteredDate", i), i);
                            
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
                        
                        sql.AppendFormat("fn_HumanCaseDeduplicationWeb_SelectList.strCaseID {0} @strCaseID_{1}", filters.Operation("strCaseID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strLocalIdentifier"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strLocalIdentifier"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strLocalIdentifier") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCaseDeduplicationWeb_SelectList.strLocalIdentifier {0} @strLocalIdentifier_{1}", filters.Operation("strLocalIdentifier", i), i);
                            
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
                        
                        sql.AppendFormat("fn_HumanCaseDeduplicationWeb_SelectList.strLastName {0} @strLastName_{1}", filters.Operation("strLastName", i), i);
                            
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
                        
                        sql.AppendFormat("fn_HumanCaseDeduplicationWeb_SelectList.strFirstName {0} @strFirstName_{1}", filters.Operation("strFirstName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSecondName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSecondName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSecondName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCaseDeduplicationWeb_SelectList.strSecondName {0} @strSecondName_{1}", filters.Operation("strSecondName", i), i);
                            
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
                        
                        sql.AppendFormat("fn_HumanCaseDeduplicationWeb_SelectList.PatientName {0} @PatientName_{1}", filters.Operation("PatientName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intPatientAge"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intPatientAge"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intPatientAge") ? " or " : " and ");
                        
                        if (filters.Operation("intPatientAge", i) == "&")
                          sql.AppendFormat("(isnull(fn_HumanCaseDeduplicationWeb_SelectList.intPatientAge,0) {0} @intPatientAge_{1} = @intPatientAge_{1})", filters.Operation("intPatientAge", i), i);
                        else
                          sql.AppendFormat("isnull(fn_HumanCaseDeduplicationWeb_SelectList.intPatientAge,0) {0} @intPatientAge_{1}", filters.Operation("intPatientAge", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsHumanAgeType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsHumanAgeType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsHumanAgeType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsHumanAgeType", i) == "&")
                          sql.AppendFormat("(isnull(fn_HumanCaseDeduplicationWeb_SelectList.idfsHumanAgeType,0) {0} @idfsHumanAgeType_{1} = @idfsHumanAgeType_{1})", filters.Operation("idfsHumanAgeType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_HumanCaseDeduplicationWeb_SelectList.idfsHumanAgeType,0) {0} @idfsHumanAgeType_{1}", filters.Operation("idfsHumanAgeType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("HumanAgeTypeName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("HumanAgeTypeName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("HumanAgeTypeName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCaseDeduplicationWeb_SelectList.HumanAgeTypeName {0} @HumanAgeTypeName_{1}", filters.Operation("HumanAgeTypeName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("Age"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("Age"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("Age") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanCaseDeduplicationWeb_SelectList.Age {0} @Age_{1}", filters.Operation("Age", i), i);
                            
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
                    
                    if (filters.Contains("idfCase"))
                        for (int i = 0; i < filters.Count("idfCase"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfCase_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfCase", i), filters.Value("idfCase", i))));
                      
                    if (filters.Contains("idfsTentativeDiagnosis"))
                        for (int i = 0; i < filters.Count("idfsTentativeDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsTentativeDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsTentativeDiagnosis", i), filters.Value("idfsTentativeDiagnosis", i))));
                      
                    if (filters.Contains("TentativeDiagnosisName"))
                        for (int i = 0; i < filters.Count("TentativeDiagnosisName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TentativeDiagnosisName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TentativeDiagnosisName", i), filters.Value("TentativeDiagnosisName", i))));
                      
                    if (filters.Contains("idfsFinalDiagnosis"))
                        for (int i = 0; i < filters.Count("idfsFinalDiagnosis"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsFinalDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsFinalDiagnosis", i), filters.Value("idfsFinalDiagnosis", i))));
                      
                    if (filters.Contains("FinalDiagnosisName"))
                        for (int i = 0; i < filters.Count("FinalDiagnosisName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@FinalDiagnosisName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("FinalDiagnosisName", i), filters.Value("FinalDiagnosisName", i))));
                      
                    if (filters.Contains("datEnteredDate"))
                        for (int i = 0; i < filters.Count("datEnteredDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datEnteredDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datEnteredDate", i), filters.Value("datEnteredDate", i))));
                      
                    if (filters.Contains("strCaseID"))
                        for (int i = 0; i < filters.Count("strCaseID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCaseID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCaseID", i), filters.Value("strCaseID", i))));
                      
                    if (filters.Contains("strLocalIdentifier"))
                        for (int i = 0; i < filters.Count("strLocalIdentifier"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strLocalIdentifier_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strLocalIdentifier", i), filters.Value("strLocalIdentifier", i))));
                      
                    if (filters.Contains("strLastName"))
                        for (int i = 0; i < filters.Count("strLastName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strLastName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strLastName", i), filters.Value("strLastName", i))));
                      
                    if (filters.Contains("strFirstName"))
                        for (int i = 0; i < filters.Count("strFirstName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFirstName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFirstName", i), filters.Value("strFirstName", i))));
                      
                    if (filters.Contains("strSecondName"))
                        for (int i = 0; i < filters.Count("strSecondName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSecondName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSecondName", i), filters.Value("strSecondName", i))));
                      
                    if (filters.Contains("PatientName"))
                        for (int i = 0; i < filters.Count("PatientName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@PatientName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("PatientName", i), filters.Value("PatientName", i))));
                      
                    if (filters.Contains("intPatientAge"))
                        for (int i = 0; i < filters.Count("intPatientAge"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intPatientAge_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intPatientAge", i), filters.Value("intPatientAge", i))));
                      
                    if (filters.Contains("idfsHumanAgeType"))
                        for (int i = 0; i < filters.Count("idfsHumanAgeType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsHumanAgeType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsHumanAgeType", i), filters.Value("idfsHumanAgeType", i))));
                      
                    if (filters.Contains("HumanAgeTypeName"))
                        for (int i = 0; i < filters.Count("HumanAgeTypeName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@HumanAgeTypeName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("HumanAgeTypeName", i), filters.Value("HumanAgeTypeName", i))));
                      
                    if (filters.Contains("Age"))
                        for (int i = 0; i < filters.Count("Age"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@Age_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("Age", i), filters.Value("Age", i))));
                      
                    List<HumanCaseDeduplicationListItem> objs = manager.ExecuteList<HumanCaseDeduplicationListItem>();
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
            partial void ListSelected(DbManagerProxy manager, List<HumanCaseDeduplicationListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return null;
                    
            }
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, HumanCaseDeduplicationListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, HumanCaseDeduplicationListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private HumanCaseDeduplicationListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    HumanCaseDeduplicationListItem obj = HumanCaseDeduplicationListItem.CreateInstance();
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
                    throw DbModelException.Create(e);
                }
            }

            
            public HumanCaseDeduplicationListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public HumanCaseDeduplicationListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public HumanCaseDeduplicationListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(HumanCaseDeduplicationListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(HumanCaseDeduplicationListItem obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, HumanCaseDeduplicationListItem obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(HumanCaseDeduplicationListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(HumanCaseDeduplicationListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as HumanCaseDeduplicationListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, HumanCaseDeduplicationListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(HumanCaseDeduplicationListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(HumanCaseDeduplicationListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as HumanCaseDeduplicationListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as HumanCaseDeduplicationListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "HumanCaseDeduplicationListItemDetail"; } }
            public string HelpIdWin { get { return "HC_H10"; } }
            public string HelpIdWeb { get { return "HC_H10"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_HumanCaseDeduplicationWeb_SelectList";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<HumanCaseDeduplicationListItem, bool>> RequiredByField = new Dictionary<string, Func<HumanCaseDeduplicationListItem, bool>>();
            public static Dictionary<string, Func<HumanCaseDeduplicationListItem, bool>> RequiredByProperty = new Dictionary<string, Func<HumanCaseDeduplicationListItem, bool>>();
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
                
                Sizes.Add(_str_TentativeDiagnosisName, 2000);
                Sizes.Add(_str_FinalDiagnosisName, 2000);
                Sizes.Add(_str_strCaseID, 200);
                Sizes.Add(_str_strLocalIdentifier, 200);
                Sizes.Add(_str_strLastName, 200);
                Sizes.Add(_str_strFirstName, 200);
                Sizes.Add(_str_strSecondName, 200);
                Sizes.Add(_str_PatientName, 602);
                Sizes.Add(_str_HumanAgeTypeName, 2000);
                Sizes.Add(_str_Age, 2013);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strLocalIdentifier",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strLocalIdentifier",
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
                    "strSecondName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strSecondName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "intPatientAge",
                    EditorType.Numeric,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "intPatientAge",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsHumanAgeType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsHumanAgeType",
                    null, "=", c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsTentativeDiagnosis",
                    EditorType.Lookup,
                    EditorControlWidth.Large, true, true, false, false, 
                    "idfsTentativeDiagnosis",
                    null, "=", c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsFinalDiagnosis",
                    EditorType.Lookup,
                    EditorControlWidth.Large, true, true, false, false, 
                    "idfsFinalDiagnosis",
                    null, "=", c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfCase,
                    _str_idfCase, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strLocalIdentifier,
                    _str_strLocalIdentifier, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strLastName,
                    _str_strLastName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFirstName,
                    _str_strFirstName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSecondName,
                    _str_strSecondName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intPatientAge,
                    _str_intPatientAge, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_HumanAgeTypeName,
                    "HumanAgeType_Name", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TentativeDiagnosisName,
                    _str_TentativeDiagnosisName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_FinalDiagnosisName,
                    _str_FinalDiagnosisName, null, true, true, true, true, null
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<HumanCase>().CreateNew(manager, c, pars == null ? null : (int?)pars[0])),
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<HumanCase>().SelectDetail(manager, pars[0])),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.DeleteInterface<HumanCase>().DeleteObject(manager, c == null ? pars[0] : c.Key), c),
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
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
}
	