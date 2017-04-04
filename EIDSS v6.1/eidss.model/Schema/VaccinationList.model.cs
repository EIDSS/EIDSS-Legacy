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
    public abstract partial class VaccinationListItem : 
        EditableObject<VaccinationListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfVaccination), NonUpdatable, PrimaryKey]
        public abstract Int64 idfVaccination { get; set; }
                
        [LocalizedDisplayName(_str_idfVetCase)]
        [MapField(_str_idfVetCase)]
        public abstract Int64? idfVetCase { get; set; }
        protected Int64? idfVetCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVetCase).OriginalValue; } }
        protected Int64? idfVetCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVetCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSpecies)]
        [MapField(_str_idfSpecies)]
        public abstract Int64? idfSpecies { get; set; }
        protected Int64? idfSpecies_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).OriginalValue; } }
        protected Int64? idfSpecies_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSpecies).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsVaccinationType)]
        [MapField(_str_idfsVaccinationType)]
        public abstract Int64? idfsVaccinationType { get; set; }
        protected Int64? idfsVaccinationType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVaccinationType).OriginalValue; } }
        protected Int64? idfsVaccinationType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVaccinationType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsVaccinationRoute)]
        [MapField(_str_idfsVaccinationRoute)]
        public abstract Int64? idfsVaccinationRoute { get; set; }
        protected Int64? idfsVaccinationRoute_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVaccinationRoute).OriginalValue; } }
        protected Int64? idfsVaccinationRoute_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsVaccinationRoute).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsDiagnosis)]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64? idfsDiagnosis { get; set; }
        protected Int64? idfsDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64? idfsDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datVaccinationDate)]
        [MapField(_str_datVaccinationDate)]
        public abstract DateTime? datVaccinationDate { get; set; }
        protected DateTime? datVaccinationDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datVaccinationDate).OriginalValue; } }
        protected DateTime? datVaccinationDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datVaccinationDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strManufacturer)]
        [MapField(_str_strManufacturer)]
        public abstract String strManufacturer { get; set; }
        protected String strManufacturer_Original { get { return ((EditableValue<String>)((dynamic)this)._strManufacturer).OriginalValue; } }
        protected String strManufacturer_Previous { get { return ((EditableValue<String>)((dynamic)this)._strManufacturer).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strLotNumber)]
        [MapField(_str_strLotNumber)]
        public abstract String strLotNumber { get; set; }
        protected String strLotNumber_Original { get { return ((EditableValue<String>)((dynamic)this)._strLotNumber).OriginalValue; } }
        protected String strLotNumber_Previous { get { return ((EditableValue<String>)((dynamic)this)._strLotNumber).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intNumberVaccinated)]
        [MapField(_str_intNumberVaccinated)]
        public abstract Int32? intNumberVaccinated { get; set; }
        protected Int32? intNumberVaccinated_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intNumberVaccinated).OriginalValue; } }
        protected Int32? intNumberVaccinated_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intNumberVaccinated).PreviousValue; } }
                
        [LocalizedDisplayName("Vaccination.strNote")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64 idfsCaseType { get; set; }
        protected Int64 idfsCaseType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64 idfsCaseType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseType).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<VaccinationListItem, object> _get_func;
            internal Action<VaccinationListItem, string> _set_func;
            internal Action<VaccinationListItem, VaccinationListItem, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfVaccination = "idfVaccination";
        internal const string _str_idfVetCase = "idfVetCase";
        internal const string _str_idfSpecies = "idfSpecies";
        internal const string _str_idfsVaccinationType = "idfsVaccinationType";
        internal const string _str_idfsVaccinationRoute = "idfsVaccinationRoute";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_datVaccinationDate = "datVaccinationDate";
        internal const string _str_strManufacturer = "strManufacturer";
        internal const string _str_strLotNumber = "strLotNumber";
        internal const string _str_intNumberVaccinated = "intNumberVaccinated";
        internal const string _str_strNote = "strNote";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str__HACode = "_HACode";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_strSpecies = "strSpecies";
        internal const string _str_strDiagnosis = "strDiagnosis";
        internal const string _str_strVaccinationRoute = "strVaccinationRoute";
        internal const string _str_strVaccinationType = "strVaccinationType";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_VaccinationType = "VaccinationType";
        internal const string _str_VaccinationRoute = "VaccinationRoute";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfVaccination, _formname = _str_idfVaccination, _type = "Int64",
              _get_func = o => o.idfVaccination,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVaccination != newval) o.idfVaccination = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVaccination != c.idfVaccination || o.IsRIRPropChanged(_str_idfVaccination, c)) 
                  m.Add(_str_idfVaccination, o.ObjectIdent + _str_idfVaccination, o.ObjectIdent2 + _str_idfVaccination, o.ObjectIdent3 + _str_idfVaccination, "Int64", 
                    o.idfVaccination == null ? "" : o.idfVaccination.ToString(),                  
                  o.IsReadOnly(_str_idfVaccination), o.IsInvisible(_str_idfVaccination), o.IsRequired(_str_idfVaccination)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVetCase, _formname = _str_idfVetCase, _type = "Int64?",
              _get_func = o => o.idfVetCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfVetCase != newval) o.idfVetCase = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVetCase != c.idfVetCase || o.IsRIRPropChanged(_str_idfVetCase, c)) 
                  m.Add(_str_idfVetCase, o.ObjectIdent + _str_idfVetCase, o.ObjectIdent2 + _str_idfVetCase, o.ObjectIdent3 + _str_idfVetCase, "Int64?", 
                    o.idfVetCase == null ? "" : o.idfVetCase.ToString(),                  
                  o.IsReadOnly(_str_idfVetCase), o.IsInvisible(_str_idfVetCase), o.IsRequired(_str_idfVetCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSpecies, _formname = _str_idfSpecies, _type = "Int64?",
              _get_func = o => o.idfSpecies,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfSpecies != newval) o.idfSpecies = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfSpecies != c.idfSpecies || o.IsRIRPropChanged(_str_idfSpecies, c)) 
                  m.Add(_str_idfSpecies, o.ObjectIdent + _str_idfSpecies, o.ObjectIdent2 + _str_idfSpecies, o.ObjectIdent3 + _str_idfSpecies, "Int64?", 
                    o.idfSpecies == null ? "" : o.idfSpecies.ToString(),                  
                  o.IsReadOnly(_str_idfSpecies), o.IsInvisible(_str_idfSpecies), o.IsRequired(_str_idfSpecies)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsVaccinationType, _formname = _str_idfsVaccinationType, _type = "Int64?",
              _get_func = o => o.idfsVaccinationType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsVaccinationType != newval) 
                  o.VaccinationType = o.VaccinationTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsVaccinationType != newval) o.idfsVaccinationType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsVaccinationType != c.idfsVaccinationType || o.IsRIRPropChanged(_str_idfsVaccinationType, c)) 
                  m.Add(_str_idfsVaccinationType, o.ObjectIdent + _str_idfsVaccinationType, o.ObjectIdent2 + _str_idfsVaccinationType, o.ObjectIdent3 + _str_idfsVaccinationType, "Int64?", 
                    o.idfsVaccinationType == null ? "" : o.idfsVaccinationType.ToString(),                  
                  o.IsReadOnly(_str_idfsVaccinationType), o.IsInvisible(_str_idfsVaccinationType), o.IsRequired(_str_idfsVaccinationType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsVaccinationRoute, _formname = _str_idfsVaccinationRoute, _type = "Int64?",
              _get_func = o => o.idfsVaccinationRoute,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsVaccinationRoute != newval) 
                  o.VaccinationRoute = o.VaccinationRouteLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsVaccinationRoute != newval) o.idfsVaccinationRoute = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsVaccinationRoute != c.idfsVaccinationRoute || o.IsRIRPropChanged(_str_idfsVaccinationRoute, c)) 
                  m.Add(_str_idfsVaccinationRoute, o.ObjectIdent + _str_idfsVaccinationRoute, o.ObjectIdent2 + _str_idfsVaccinationRoute, o.ObjectIdent3 + _str_idfsVaccinationRoute, "Int64?", 
                    o.idfsVaccinationRoute == null ? "" : o.idfsVaccinationRoute.ToString(),                  
                  o.IsReadOnly(_str_idfsVaccinationRoute), o.IsInvisible(_str_idfsVaccinationRoute), o.IsRequired(_str_idfsVaccinationRoute)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsDiagnosis != newval) 
                  o.Diagnosis = o.DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis, "Int64?", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datVaccinationDate, _formname = _str_datVaccinationDate, _type = "DateTime?",
              _get_func = o => o.datVaccinationDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datVaccinationDate != newval) o.datVaccinationDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datVaccinationDate != c.datVaccinationDate || o.IsRIRPropChanged(_str_datVaccinationDate, c)) 
                  m.Add(_str_datVaccinationDate, o.ObjectIdent + _str_datVaccinationDate, o.ObjectIdent2 + _str_datVaccinationDate, o.ObjectIdent3 + _str_datVaccinationDate, "DateTime?", 
                    o.datVaccinationDate == null ? "" : o.datVaccinationDate.ToString(),                  
                  o.IsReadOnly(_str_datVaccinationDate), o.IsInvisible(_str_datVaccinationDate), o.IsRequired(_str_datVaccinationDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strManufacturer, _formname = _str_strManufacturer, _type = "String",
              _get_func = o => o.strManufacturer,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strManufacturer != newval) o.strManufacturer = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strManufacturer != c.strManufacturer || o.IsRIRPropChanged(_str_strManufacturer, c)) 
                  m.Add(_str_strManufacturer, o.ObjectIdent + _str_strManufacturer, o.ObjectIdent2 + _str_strManufacturer, o.ObjectIdent3 + _str_strManufacturer, "String", 
                    o.strManufacturer == null ? "" : o.strManufacturer.ToString(),                  
                  o.IsReadOnly(_str_strManufacturer), o.IsInvisible(_str_strManufacturer), o.IsRequired(_str_strManufacturer)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strLotNumber, _formname = _str_strLotNumber, _type = "String",
              _get_func = o => o.strLotNumber,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strLotNumber != newval) o.strLotNumber = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strLotNumber != c.strLotNumber || o.IsRIRPropChanged(_str_strLotNumber, c)) 
                  m.Add(_str_strLotNumber, o.ObjectIdent + _str_strLotNumber, o.ObjectIdent2 + _str_strLotNumber, o.ObjectIdent3 + _str_strLotNumber, "String", 
                    o.strLotNumber == null ? "" : o.strLotNumber.ToString(),                  
                  o.IsReadOnly(_str_strLotNumber), o.IsInvisible(_str_strLotNumber), o.IsRequired(_str_strLotNumber)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intNumberVaccinated, _formname = _str_intNumberVaccinated, _type = "Int32?",
              _get_func = o => o.intNumberVaccinated,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intNumberVaccinated != newval) o.intNumberVaccinated = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intNumberVaccinated != c.intNumberVaccinated || o.IsRIRPropChanged(_str_intNumberVaccinated, c)) 
                  m.Add(_str_intNumberVaccinated, o.ObjectIdent + _str_intNumberVaccinated, o.ObjectIdent2 + _str_intNumberVaccinated, o.ObjectIdent3 + _str_intNumberVaccinated, "Int32?", 
                    o.intNumberVaccinated == null ? "" : o.intNumberVaccinated.ToString(),                  
                  o.IsReadOnly(_str_intNumberVaccinated), o.IsInvisible(_str_intNumberVaccinated), o.IsRequired(_str_intNumberVaccinated)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strNote, _formname = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strNote != newval) o.strNote = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, o.ObjectIdent2 + _str_strNote, o.ObjectIdent3 + _str_strNote, "String", 
                    o.strNote == null ? "" : o.strNote.ToString(),                  
                  o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCaseType, _formname = _str_idfsCaseType, _type = "Int64",
              _get_func = o => o.idfsCaseType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsCaseType != newval) o.idfsCaseType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCaseType != c.idfsCaseType || o.IsRIRPropChanged(_str_idfsCaseType, c)) 
                  m.Add(_str_idfsCaseType, o.ObjectIdent + _str_idfsCaseType, o.ObjectIdent2 + _str_idfsCaseType, o.ObjectIdent3 + _str_idfsCaseType, "Int64", 
                    o.idfsCaseType == null ? "" : o.idfsCaseType.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseType), o.IsInvisible(_str_idfsCaseType), o.IsRequired(_str_idfsCaseType)); 
                  }
              }, 
        
            new field_info {
              _name = _str__HACode, _formname = _str__HACode, _type = "int?",
              _get_func = o => o._HACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o._HACode != newval) o._HACode = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o._HACode != c._HACode || o.IsRIRPropChanged(_str__HACode, c)) {
                  m.Add(_str__HACode, o.ObjectIdent + _str__HACode, o.ObjectIdent2 + _str__HACode, o.ObjectIdent3 + _str__HACode,  "int?", 
                    o._HACode == null ? "" : o._HACode.ToString(),                  
                    o.IsReadOnly(_str__HACode), o.IsInvisible(_str__HACode), o.IsRequired(_str__HACode));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_CaseObjectIdent, _formname = _str_CaseObjectIdent, _type = "string",
              _get_func = o => o.CaseObjectIdent,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.CaseObjectIdent != c.CaseObjectIdent || o.IsRIRPropChanged(_str_CaseObjectIdent, c)) {
                  m.Add(_str_CaseObjectIdent, o.ObjectIdent + _str_CaseObjectIdent, o.ObjectIdent2 + _str_CaseObjectIdent, o.ObjectIdent3 + _str_CaseObjectIdent, "string", o.CaseObjectIdent == null ? "" : o.CaseObjectIdent.ToString(), o.IsReadOnly(_str_CaseObjectIdent), o.IsInvisible(_str_CaseObjectIdent), o.IsRequired(_str_CaseObjectIdent));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strSpecies, _formname = _str_strSpecies, _type = "string",
              _get_func = o => o.strSpecies,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strSpecies != c.strSpecies || o.IsRIRPropChanged(_str_strSpecies, c)) {
                  m.Add(_str_strSpecies, o.ObjectIdent + _str_strSpecies, o.ObjectIdent2 + _str_strSpecies, o.ObjectIdent3 + _str_strSpecies, "string", o.strSpecies == null ? "" : o.strSpecies.ToString(), o.IsReadOnly(_str_strSpecies), o.IsInvisible(_str_strSpecies), o.IsRequired(_str_strSpecies));
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
              _name = _str_strVaccinationRoute, _formname = _str_strVaccinationRoute, _type = "string",
              _get_func = o => o.strVaccinationRoute,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strVaccinationRoute != c.strVaccinationRoute || o.IsRIRPropChanged(_str_strVaccinationRoute, c)) {
                  m.Add(_str_strVaccinationRoute, o.ObjectIdent + _str_strVaccinationRoute, o.ObjectIdent2 + _str_strVaccinationRoute, o.ObjectIdent3 + _str_strVaccinationRoute, "string", o.strVaccinationRoute == null ? "" : o.strVaccinationRoute.ToString(), o.IsReadOnly(_str_strVaccinationRoute), o.IsInvisible(_str_strVaccinationRoute), o.IsRequired(_str_strVaccinationRoute));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strVaccinationType, _formname = _str_strVaccinationType, _type = "string",
              _get_func = o => o.strVaccinationType,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strVaccinationType != c.strVaccinationType || o.IsRIRPropChanged(_str_strVaccinationType, c)) {
                  m.Add(_str_strVaccinationType, o.ObjectIdent + _str_strVaccinationType, o.ObjectIdent2 + _str_strVaccinationType, o.ObjectIdent3 + _str_strVaccinationType, "string", o.strVaccinationType == null ? "" : o.strVaccinationType.ToString(), o.IsReadOnly(_str_strVaccinationType), o.IsInvisible(_str_strVaccinationType), o.IsRequired(_str_strVaccinationType));
                  }
                
                }
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
              _name = _str_VaccinationType, _formname = _str_VaccinationType, _type = "Lookup",
              _get_func = o => { if (o.VaccinationType == null) return null; return o.VaccinationType.idfsBaseReference; },
              _set_func = (o, val) => { o.VaccinationType = o.VaccinationTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_VaccinationType, c);
                if (o.idfsVaccinationType != c.idfsVaccinationType || o.IsRIRPropChanged(_str_VaccinationType, c) || bChangeLookupContent) {
                  m.Add(_str_VaccinationType, o.ObjectIdent + _str_VaccinationType, o.ObjectIdent2 + _str_VaccinationType, o.ObjectIdent3 + _str_VaccinationType, "Lookup", o.idfsVaccinationType == null ? "" : o.idfsVaccinationType.ToString(), o.IsReadOnly(_str_VaccinationType), o.IsInvisible(_str_VaccinationType), o.IsRequired(_str_VaccinationType),
                  bChangeLookupContent ? o.VaccinationTypeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_VaccinationType + "Lookup", _formname = _str_VaccinationType + "Lookup", _type = "LookupContent",
              _get_func = o => o.VaccinationTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_VaccinationRoute, _formname = _str_VaccinationRoute, _type = "Lookup",
              _get_func = o => { if (o.VaccinationRoute == null) return null; return o.VaccinationRoute.idfsBaseReference; },
              _set_func = (o, val) => { o.VaccinationRoute = o.VaccinationRouteLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_VaccinationRoute, c);
                if (o.idfsVaccinationRoute != c.idfsVaccinationRoute || o.IsRIRPropChanged(_str_VaccinationRoute, c) || bChangeLookupContent) {
                  m.Add(_str_VaccinationRoute, o.ObjectIdent + _str_VaccinationRoute, o.ObjectIdent2 + _str_VaccinationRoute, o.ObjectIdent3 + _str_VaccinationRoute, "Lookup", o.idfsVaccinationRoute == null ? "" : o.idfsVaccinationRoute.ToString(), o.IsReadOnly(_str_VaccinationRoute), o.IsInvisible(_str_VaccinationRoute), o.IsRequired(_str_VaccinationRoute),
                  bChangeLookupContent ? o.VaccinationRouteLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_VaccinationRoute + "Lookup", _formname = _str_VaccinationRoute + "Lookup", _type = "LookupContent",
              _get_func = o => o.VaccinationRouteLookup,
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
            VaccinationListItem obj = (VaccinationListItem)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
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
                            ? new Int64?()
                            : (Int64?)_Diagnosis.idfsDiagnosis))
                        idfsDiagnosis = _Diagnosis == null 
                            ? new Int64?()
                            : (Int64?)_Diagnosis.idfsDiagnosis; 
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
            
        [LocalizedDisplayName(_str_VaccinationType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsVaccinationType)]
        public BaseReference VaccinationType
        {
            get { return _VaccinationType == null ? null : ((long)_VaccinationType.Key == 0 ? null : _VaccinationType); }
            set 
            { 
                var oldVal = _VaccinationType;
                _VaccinationType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_VaccinationType != oldVal)
                {
                    if (idfsVaccinationType != (_VaccinationType == null
                            ? new Int64?()
                            : (Int64?)_VaccinationType.idfsBaseReference))
                        idfsVaccinationType = _VaccinationType == null 
                            ? new Int64?()
                            : (Int64?)_VaccinationType.idfsBaseReference; 
                    OnPropertyChanged(_str_VaccinationType); 
                }
            }
        }
        private BaseReference _VaccinationType;

        
        public BaseReferenceList VaccinationTypeLookup
        {
            get { return _VaccinationTypeLookup; }
        }
        private BaseReferenceList _VaccinationTypeLookup = new BaseReferenceList("rftVaccinationType");
            
        [LocalizedDisplayName(_str_VaccinationRoute)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsVaccinationRoute)]
        public BaseReference VaccinationRoute
        {
            get { return _VaccinationRoute == null ? null : ((long)_VaccinationRoute.Key == 0 ? null : _VaccinationRoute); }
            set 
            { 
                var oldVal = _VaccinationRoute;
                _VaccinationRoute = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_VaccinationRoute != oldVal)
                {
                    if (idfsVaccinationRoute != (_VaccinationRoute == null
                            ? new Int64?()
                            : (Int64?)_VaccinationRoute.idfsBaseReference))
                        idfsVaccinationRoute = _VaccinationRoute == null 
                            ? new Int64?()
                            : (Int64?)_VaccinationRoute.idfsBaseReference; 
                    OnPropertyChanged(_str_VaccinationRoute); 
                }
            }
        }
        private BaseReference _VaccinationRoute;

        
        public BaseReferenceList VaccinationRouteLookup
        {
            get { return _VaccinationRouteLookup; }
        }
        private BaseReferenceList _VaccinationRouteLookup = new BaseReferenceList("rftVaccinationRoute");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_VaccinationType:
                    return new BvSelectList(VaccinationTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, VaccinationType, _str_idfsVaccinationType);
            
                case _str_VaccinationRoute:
                    return new BvSelectList(VaccinationRouteLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, VaccinationRoute, _str_idfsVaccinationRoute);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<VaccinationListItem, string>(c => "VetCase_" + c.idfVetCase + "_")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("strAnimalFlockSpecies")]
        public string strSpecies
        {
            get { return new Func<VaccinationListItem, string>(c => { var ft = (c.Parent as VetCase).Farm.FarmTree.FirstOrDefault(f => f.idfsPartyType == (long)PartyTypeEnum.Species && c.idfSpecies == f.idfParty); return ft == null ? "" : String.Format("{0}/{1}", ft.strHerdName, ft.strSpeciesName); })(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("Vaccination.strDiagnosis")]
        public string strDiagnosis
        {
            get { return new Func<VaccinationListItem, string>(c=> c.Diagnosis == null ? "" : c.Diagnosis.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strVaccinationRoute)]
        public string strVaccinationRoute
        {
            get { return new Func<VaccinationListItem, string>(c => c.VaccinationRoute == null ? "" : c.VaccinationRoute.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strVaccinationType)]
        public string strVaccinationType
        {
            get { return new Func<VaccinationListItem, string>(c => c.VaccinationType == null ? "" : c.VaccinationType.name)(this); }
            
        }
        
          [LocalizedDisplayName(_str__HACode)]
        public int? _HACode
        {
            get { return m__HACode; }
            set { if (m__HACode != value) { m__HACode = value; OnPropertyChanged(_str__HACode); } }
        }
        private int? m__HACode;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VaccinationListItem";

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
            var ret = base.Clone() as VaccinationListItem;
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
            var ret = base.Clone() as VaccinationListItem;
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
        public VaccinationListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VaccinationListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfVaccination; } }
        public string KeyName { get { return "idfVaccination"; } }
        public object KeyLookup { get { return idfVaccination; } }
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
        
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsVaccinationType_VaccinationType = idfsVaccinationType;
            var _prev_idfsVaccinationRoute_VaccinationRoute = idfsVaccinationRoute;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsVaccinationType_VaccinationType != idfsVaccinationType)
            {
                _VaccinationType = _VaccinationTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVaccinationType);
            }
            if (_prev_idfsVaccinationRoute_VaccinationRoute != idfsVaccinationRoute)
            {
                _VaccinationRoute = _VaccinationRouteLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVaccinationRoute);
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

        private bool IsRIRPropChanged(string fld, VaccinationListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, VaccinationListItem c)
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
        

      

        public VaccinationListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VaccinationListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VaccinationListItem_PropertyChanged);
        }
        private void VaccinationListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VaccinationListItem).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfVetCase)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_strSpecies);
                  
            if (e.PropertyName == _str_idfsDiagnosis)
                OnPropertyChanged(_str_strDiagnosis);
                  
            if (e.PropertyName == _str_idfsVaccinationRoute)
                OnPropertyChanged(_str_strVaccinationRoute);
                  
            if (e.PropertyName == _str_idfsVaccinationType)
                OnPropertyChanged(_str_strVaccinationType);
                  
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
            VaccinationListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VaccinationListItem obj = this;
            
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


        internal Dictionary<string, Func<VaccinationListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VaccinationListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VaccinationListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VaccinationListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VaccinationListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<VaccinationListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<VaccinationListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~VaccinationListItem()
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
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftVaccinationType", this);
                
                LookupManager.RemoveObject("rftVaccinationRoute", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftVaccinationType")
                _getAccessor().LoadLookup_VaccinationType(manager, this);
            
            if (lookup_object == "rftVaccinationRoute")
                _getAccessor().LoadLookup_VaccinationRoute(manager, this);
            
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
        public class VaccinationListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfVaccination { get; set; }
        
            public Int64? idfSpecies { get; set; }
        
            public string strDiagnosis { get; set; }
        
            public DateTimeWrap datVaccinationDate { get; set; }
        
            public string strSpecies { get; set; }
        
            public int? intNumberVaccinated { get; set; }
        
            public string strVaccinationType { get; set; }
        
            public string strVaccinationRoute { get; set; }
        
            public string strLotNumber { get; set; }
        
            public string strManufacturer { get; set; }
        
            public string strNote { get; set; }
        
        }
        public partial class VaccinationListItemGridModelList : List<VaccinationListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public VaccinationListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VaccinationListItem>, errMes);
            }
            public VaccinationListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VaccinationListItem>, errMes);
            }
            public VaccinationListItemGridModelList(long key, IEnumerable<VaccinationListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public VaccinationListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<VaccinationListItem>(), null);
            }
            partial void filter(List<VaccinationListItem> items);
            private void LoadGridModelList(long key, IEnumerable<VaccinationListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strDiagnosis,_str_datVaccinationDate,_str_strSpecies,_str_intNumberVaccinated,_str_strVaccinationType,_str_strVaccinationRoute,_str_strLotNumber,_str_strManufacturer,_str_strNote};
                    
                Hiddens = new List<string> {_str_idfVaccination,_str_idfSpecies};
                Keys = new List<string> {_str_idfVaccination};
                Labels = new Dictionary<string, string> {{_str_strDiagnosis, "Vaccination.strDiagnosis"},{_str_datVaccinationDate, _str_datVaccinationDate},{_str_strSpecies, "strAnimalFlockSpecies"},{_str_intNumberVaccinated, _str_intNumberVaccinated},{_str_strVaccinationType, _str_strVaccinationType},{_str_strVaccinationRoute, _str_strVaccinationRoute},{_str_strLotNumber, _str_strLotNumber},{_str_strManufacturer, _str_strManufacturer},{_str_strNote, "Vaccination.strNote"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                VaccinationListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<VaccinationListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VaccinationListItemGridModel()
                {
                    ItemKey=c.idfVaccination,idfSpecies=c.idfSpecies,strDiagnosis=c.strDiagnosis,datVaccinationDate=c.datVaccinationDate,strSpecies=c.strSpecies,intNumberVaccinated=c.intNumberVaccinated,strVaccinationType=c.strVaccinationType,strVaccinationRoute=c.strVaccinationRoute,strLotNumber=c.strLotNumber,strManufacturer=c.strManufacturer,strNote=c.strNote
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
        : DataAccessor<VaccinationListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<VaccinationListItem>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfVaccination"; } }
            #endregion
        
            public delegate void on_action(VaccinationListItem obj);
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
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor VaccinationTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor VaccinationRouteAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<VaccinationListItem> SelectList(DbManagerProxy manager
                , Int64? idfCase
                )
            {
                return _SelectList(manager
                    , idfCase
                    , delegate(VaccinationListItem obj)
                        {
                        }
                    , delegate(VaccinationListItem obj)
                        {
                        }
                    );
            }

            

            public List<VaccinationListItem> _SelectList(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfCase
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<VaccinationListItem> _SelectListInternal(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                VaccinationListItem _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VaccinationListItem> objs = new List<VaccinationListItem>();
                    sets[0] = new MapResultSet(typeof(VaccinationListItem), objs);
                    
                    manager
                        .SetSpCommand("spVaccination_SelectDetail"
                            , manager.Parameter("@idfCase", idfCase)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VaccinationListItem obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj._HACode = new Func<VaccinationListItem, int?>(c => (c.idfsCaseType == (long)CaseTypeEnum.Livestock ? 32 : 64))(obj);
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
            
            internal void _SetPermitions(IObjectPermissions permissions, VaccinationListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private VaccinationListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                VaccinationListItem obj = null;
                try
                {
                    obj = VaccinationListItem.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfVaccination = (new GetNewIDExtender<VaccinationListItem>()).GetScalar(manager, obj, isFake);
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

            
            public VaccinationListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VaccinationListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public VaccinationListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public VaccinationListItem CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                return Create(manager, Parent
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public VaccinationListItem Create(DbManagerProxy manager, IObject Parent
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj._HACode = new Func<VaccinationListItem, int?>(c => (Parent as VetCase)._HACode)(obj);
                obj.idfVetCase = new Func<VaccinationListItem, long?>(c => (Parent as VetCase).idfCase)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(VaccinationListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VaccinationListItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datVaccinationDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datVaccinationDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Diagnosis(DbManagerProxy manager, VaccinationListItem obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((obj._HACode.HasValue && (c.intHACode & (int)obj._HACode) != 0)) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
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
            
            public void LoadLookup_VaccinationType(DbManagerProxy manager, VaccinationListItem obj)
            {
                
                obj.VaccinationTypeLookup.Clear();
                
                obj.VaccinationTypeLookup.Add(VaccinationTypeAccessor.CreateNewT(manager, null));
                
                obj.VaccinationTypeLookup.AddRange(VaccinationTypeAccessor.rftVaccinationType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVaccinationType))
                    
                    .ToList());
                
                if (obj.idfsVaccinationType != null && obj.idfsVaccinationType != 0)
                {
                    obj.VaccinationType = obj.VaccinationTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsVaccinationType);
                    
                }
              
                LookupManager.AddObject("rftVaccinationType", obj, VaccinationTypeAccessor.GetType(), "rftVaccinationType_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_VaccinationRoute(DbManagerProxy manager, VaccinationListItem obj)
            {
                
                obj.VaccinationRouteLookup.Clear();
                
                obj.VaccinationRouteLookup.Add(VaccinationRouteAccessor.CreateNewT(manager, null));
                
                obj.VaccinationRouteLookup.AddRange(VaccinationRouteAccessor.rftVaccinationRoute_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVaccinationRoute))
                    
                    .ToList());
                
                if (obj.idfsVaccinationRoute != null && obj.idfsVaccinationRoute != 0)
                {
                    obj.VaccinationRoute = obj.VaccinationRouteLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsVaccinationRoute);
                    
                }
              
                LookupManager.AddObject("rftVaccinationRoute", obj, VaccinationRouteAccessor.GetType(), "rftVaccinationRoute_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, VaccinationListItem obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_VaccinationType(manager, obj);
                
                LoadLookup_VaccinationRoute(manager, obj);
                
            }
    
            [SprocName("spVaccination_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] VaccinationListItem obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] VaccinationListItem obj)
            {
                
                _post(manager, Action, obj);
                
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
                        VaccinationListItem bo = obj as VaccinationListItem;
                        
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
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as VaccinationListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VaccinationListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postPredicate(manager, 8, obj);
                                
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(VaccinationListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VaccinationListItem obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(VaccinationListItem obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<VaccinationListItem>(obj, "datVaccinationDate", c => true, 
      obj.datVaccinationDate,
      obj.GetType(),
      false, listdatVaccinationDate => {
    listdatVaccinationDate.Add(
    new ChainsValidatorDateTime<VaccinationListItem>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }).Process();
  
                }
                catch(ValidationModelException ex)
                {
                    return ex;
                }
                
                return null;
            }
            protected bool ChainsValidate(VaccinationListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as VaccinationListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VaccinationListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new PredicateValidator("errCantSaveEmptyRow", "", "", "",
              new object[] {
              },
                        ValidationEventType.Error
                    )).Validate(obj, c=>c.idfsDiagnosis.HasValue || c.idfSpecies.HasValue || c.datVaccinationDate.HasValue || c.idfsVaccinationRoute.HasValue || c.idfsVaccinationType.HasValue || !String.IsNullOrWhiteSpace(c.strLotNumber) || !String.IsNullOrWhiteSpace(c.strManufacturer) || !String.IsNullOrWhiteSpace(c.strNote) || c.intNumberVaccinated.HasValue
                    );
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
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
           
    
            private void _SetupRequired(VaccinationListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(VaccinationListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VaccinationListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VaccinationListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VaccinationListItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spVaccination_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spVaccination_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VaccinationListItem, bool>> RequiredByField = new Dictionary<string, Func<VaccinationListItem, bool>>();
            public static Dictionary<string, Func<VaccinationListItem, bool>> RequiredByProperty = new Dictionary<string, Func<VaccinationListItem, bool>>();
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
                
                Sizes.Add(_str_strManufacturer, 200);
                Sizes.Add(_str_strLotNumber, 200);
                Sizes.Add(_str_strNote, 2000);
                GridMeta.Add(new GridMetaItem(
                    _str_idfVaccination,
                    _str_idfVaccination, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfSpecies,
                    _str_idfSpecies, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosis,
                    "Vaccination.strDiagnosis", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datVaccinationDate,
                    _str_datVaccinationDate, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpecies,
                    "strAnimalFlockSpecies", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intNumberVaccinated,
                    _str_intNumberVaccinated, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVaccinationType,
                    _str_strVaccinationType, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVaccinationRoute,
                    _str_strVaccinationRoute, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strLotNumber,
                    _str_strLotNumber, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strManufacturer,
                    _str_strManufacturer, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNote,
                    "Vaccination.strNote", null, false, true, true, true, true, null
                    ));
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
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
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
                    (manager, c, pars) => ((VaccinationListItem)c).MarkToDelete(),
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
	