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
    public abstract partial class Outbreak : 
        EditableObject<Outbreak>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfOutbreak), NonUpdatable, PrimaryKey]
        public abstract Int64 idfOutbreak { get; set; }
                
        [LocalizedDisplayName(_str_idfsDiagnosisOrDiagnosisGroup)]
        [MapField(_str_idfsDiagnosisOrDiagnosisGroup)]
        public abstract Int64? idfsDiagnosisOrDiagnosisGroup { get; set; }
        protected Int64? idfsDiagnosisOrDiagnosisGroup_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosisOrDiagnosisGroup).OriginalValue; } }
        protected Int64? idfsDiagnosisOrDiagnosisGroup_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosisOrDiagnosisGroup).PreviousValue; } }
                
        [LocalizedDisplayName("strOutbreakStatus")]
        [MapField(_str_idfsOutbreakStatus)]
        public abstract Int64? idfsOutbreakStatus { get; set; }
        protected Int64? idfsOutbreakStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOutbreakStatus).OriginalValue; } }
        protected Int64? idfsOutbreakStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOutbreakStatus).PreviousValue; } }
                
        [LocalizedDisplayName("strGeoLocationName")]
        [MapField(_str_idfGeoLocation)]
        public abstract Int64? idfGeoLocation { get; set; }
        protected Int64? idfGeoLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfGeoLocation).OriginalValue; } }
        protected Int64? idfGeoLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfGeoLocation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOutbreakID)]
        [MapField(_str_strOutbreakID)]
        public abstract String strOutbreakID { get; set; }
        protected String strOutbreakID_Original { get { return ((EditableValue<String>)((dynamic)this)._strOutbreakID).OriginalValue; } }
        protected String strOutbreakID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOutbreakID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStartDate)]
        [MapField(_str_datStartDate)]
        public abstract DateTime? datStartDate { get; set; }
        protected DateTime? datStartDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime? datStartDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFinishDate)]
        [MapField(_str_datFinishDate)]
        public abstract DateTime? datFinishDate { get; set; }
        protected DateTime? datFinishDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFinishDate).OriginalValue; } }
        protected DateTime? datFinishDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFinishDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDescription)]
        [MapField(_str_strDescription)]
        public abstract String strDescription { get; set; }
        protected String strDescription_Original { get { return ((EditableValue<String>)((dynamic)this)._strDescription).OriginalValue; } }
        protected String strDescription_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDescription).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPrimaryCaseOrSession)]
        [MapField(_str_idfPrimaryCaseOrSession)]
        public abstract Int64? idfPrimaryCaseOrSession { get; set; }
        protected Int64? idfPrimaryCaseOrSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPrimaryCaseOrSession).OriginalValue; } }
        protected Int64? idfPrimaryCaseOrSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPrimaryCaseOrSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPrimaryCase)]
        [MapField(_str_strPrimaryCase)]
        public abstract String strPrimaryCase { get; set; }
        protected String strPrimaryCase_Original { get { return ((EditableValue<String>)((dynamic)this)._strPrimaryCase).OriginalValue; } }
        protected String strPrimaryCase_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPrimaryCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCasePrimaryType)]
        [MapField(_str_idfsCasePrimaryType)]
        public abstract Int64? idfsCasePrimaryType { get; set; }
        protected Int64? idfsCasePrimaryType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCasePrimaryType).OriginalValue; } }
        protected Int64? idfsCasePrimaryType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCasePrimaryType).PreviousValue; } }
                
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
            internal Func<Outbreak, object> _get_func;
            internal Action<Outbreak, string> _set_func;
            internal Action<Outbreak, Outbreak, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfOutbreak = "idfOutbreak";
        internal const string _str_idfsDiagnosisOrDiagnosisGroup = "idfsDiagnosisOrDiagnosisGroup";
        internal const string _str_idfsOutbreakStatus = "idfsOutbreakStatus";
        internal const string _str_idfGeoLocation = "idfGeoLocation";
        internal const string _str_strOutbreakID = "strOutbreakID";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_datFinishDate = "datFinishDate";
        internal const string _str_strDescription = "strDescription";
        internal const string _str_idfPrimaryCaseOrSession = "idfPrimaryCaseOrSession";
        internal const string _str_strPrimaryCase = "strPrimaryCase";
        internal const string _str_idfsCasePrimaryType = "idfsCasePrimaryType";
        internal const string _str_datModificationForArchiveDate = "datModificationForArchiveDate";
        internal const string _str_intCaseCount = "intCaseCount";
        internal const string _str_intCaseConfirmedCount = "intCaseConfirmedCount";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_OutbreakStatus = "OutbreakStatus";
        internal const string _str_Location = "Location";
        internal const string _str_Cases = "Cases";
        internal const string _str_Notes = "Notes";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfOutbreak, _formname = _str_idfOutbreak, _type = "Int64",
              _get_func = o => o.idfOutbreak,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfOutbreak != newval) o.idfOutbreak = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfOutbreak != c.idfOutbreak || o.IsRIRPropChanged(_str_idfOutbreak, c)) 
                  m.Add(_str_idfOutbreak, o.ObjectIdent + _str_idfOutbreak, o.ObjectIdent2 + _str_idfOutbreak, o.ObjectIdent3 + _str_idfOutbreak, "Int64", 
                    o.idfOutbreak == null ? "" : o.idfOutbreak.ToString(),                  
                  o.IsReadOnly(_str_idfOutbreak), o.IsInvisible(_str_idfOutbreak), o.IsRequired(_str_idfOutbreak)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosisOrDiagnosisGroup, _formname = _str_idfsDiagnosisOrDiagnosisGroup, _type = "Int64?",
              _get_func = o => o.idfsDiagnosisOrDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsDiagnosisOrDiagnosisGroup != newval) 
                  o.Diagnosis = o.DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosisOrDiagnosisGroup == newval);
                if (o.idfsDiagnosisOrDiagnosisGroup != newval) o.idfsDiagnosisOrDiagnosisGroup = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDiagnosisOrDiagnosisGroup != c.idfsDiagnosisOrDiagnosisGroup || o.IsRIRPropChanged(_str_idfsDiagnosisOrDiagnosisGroup, c)) 
                  m.Add(_str_idfsDiagnosisOrDiagnosisGroup, o.ObjectIdent + _str_idfsDiagnosisOrDiagnosisGroup, o.ObjectIdent2 + _str_idfsDiagnosisOrDiagnosisGroup, o.ObjectIdent3 + _str_idfsDiagnosisOrDiagnosisGroup, "Int64?", 
                    o.idfsDiagnosisOrDiagnosisGroup == null ? "" : o.idfsDiagnosisOrDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosisOrDiagnosisGroup), o.IsInvisible(_str_idfsDiagnosisOrDiagnosisGroup), o.IsRequired(_str_idfsDiagnosisOrDiagnosisGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsOutbreakStatus, _formname = _str_idfsOutbreakStatus, _type = "Int64?",
              _get_func = o => o.idfsOutbreakStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsOutbreakStatus != newval) 
                  o.OutbreakStatus = o.OutbreakStatusLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsOutbreakStatus != newval) o.idfsOutbreakStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsOutbreakStatus != c.idfsOutbreakStatus || o.IsRIRPropChanged(_str_idfsOutbreakStatus, c)) 
                  m.Add(_str_idfsOutbreakStatus, o.ObjectIdent + _str_idfsOutbreakStatus, o.ObjectIdent2 + _str_idfsOutbreakStatus, o.ObjectIdent3 + _str_idfsOutbreakStatus, "Int64?", 
                    o.idfsOutbreakStatus == null ? "" : o.idfsOutbreakStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsOutbreakStatus), o.IsInvisible(_str_idfsOutbreakStatus), o.IsRequired(_str_idfsOutbreakStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfGeoLocation, _formname = _str_idfGeoLocation, _type = "Int64?",
              _get_func = o => o.idfGeoLocation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfGeoLocation != newval) o.idfGeoLocation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfGeoLocation != c.idfGeoLocation || o.IsRIRPropChanged(_str_idfGeoLocation, c)) 
                  m.Add(_str_idfGeoLocation, o.ObjectIdent + _str_idfGeoLocation, o.ObjectIdent2 + _str_idfGeoLocation, o.ObjectIdent3 + _str_idfGeoLocation, "Int64?", 
                    o.idfGeoLocation == null ? "" : o.idfGeoLocation.ToString(),                  
                  o.IsReadOnly(_str_idfGeoLocation), o.IsInvisible(_str_idfGeoLocation), o.IsRequired(_str_idfGeoLocation)); 
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
              _name = _str_datStartDate, _formname = _str_datStartDate, _type = "DateTime?",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datStartDate != newval) o.datStartDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, o.ObjectIdent2 + _str_datStartDate, o.ObjectIdent3 + _str_datStartDate, "DateTime?", 
                    o.datStartDate == null ? "" : o.datStartDate.ToString(),                  
                  o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datFinishDate, _formname = _str_datFinishDate, _type = "DateTime?",
              _get_func = o => o.datFinishDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datFinishDate != newval) o.datFinishDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datFinishDate != c.datFinishDate || o.IsRIRPropChanged(_str_datFinishDate, c)) 
                  m.Add(_str_datFinishDate, o.ObjectIdent + _str_datFinishDate, o.ObjectIdent2 + _str_datFinishDate, o.ObjectIdent3 + _str_datFinishDate, "DateTime?", 
                    o.datFinishDate == null ? "" : o.datFinishDate.ToString(),                  
                  o.IsReadOnly(_str_datFinishDate), o.IsInvisible(_str_datFinishDate), o.IsRequired(_str_datFinishDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDescription, _formname = _str_strDescription, _type = "String",
              _get_func = o => o.strDescription,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDescription != newval) o.strDescription = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strDescription != c.strDescription || o.IsRIRPropChanged(_str_strDescription, c)) 
                  m.Add(_str_strDescription, o.ObjectIdent + _str_strDescription, o.ObjectIdent2 + _str_strDescription, o.ObjectIdent3 + _str_strDescription, "String", 
                    o.strDescription == null ? "" : o.strDescription.ToString(),                  
                  o.IsReadOnly(_str_strDescription), o.IsInvisible(_str_strDescription), o.IsRequired(_str_strDescription)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPrimaryCaseOrSession, _formname = _str_idfPrimaryCaseOrSession, _type = "Int64?",
              _get_func = o => o.idfPrimaryCaseOrSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfPrimaryCaseOrSession != newval) o.idfPrimaryCaseOrSession = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfPrimaryCaseOrSession != c.idfPrimaryCaseOrSession || o.IsRIRPropChanged(_str_idfPrimaryCaseOrSession, c)) 
                  m.Add(_str_idfPrimaryCaseOrSession, o.ObjectIdent + _str_idfPrimaryCaseOrSession, o.ObjectIdent2 + _str_idfPrimaryCaseOrSession, o.ObjectIdent3 + _str_idfPrimaryCaseOrSession, "Int64?", 
                    o.idfPrimaryCaseOrSession == null ? "" : o.idfPrimaryCaseOrSession.ToString(),                  
                  o.IsReadOnly(_str_idfPrimaryCaseOrSession), o.IsInvisible(_str_idfPrimaryCaseOrSession), o.IsRequired(_str_idfPrimaryCaseOrSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPrimaryCase, _formname = _str_strPrimaryCase, _type = "String",
              _get_func = o => o.strPrimaryCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPrimaryCase != newval) o.strPrimaryCase = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strPrimaryCase != c.strPrimaryCase || o.IsRIRPropChanged(_str_strPrimaryCase, c)) 
                  m.Add(_str_strPrimaryCase, o.ObjectIdent + _str_strPrimaryCase, o.ObjectIdent2 + _str_strPrimaryCase, o.ObjectIdent3 + _str_strPrimaryCase, "String", 
                    o.strPrimaryCase == null ? "" : o.strPrimaryCase.ToString(),                  
                  o.IsReadOnly(_str_strPrimaryCase), o.IsInvisible(_str_strPrimaryCase), o.IsRequired(_str_strPrimaryCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCasePrimaryType, _formname = _str_idfsCasePrimaryType, _type = "Int64?",
              _get_func = o => o.idfsCasePrimaryType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsCasePrimaryType != newval) o.idfsCasePrimaryType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCasePrimaryType != c.idfsCasePrimaryType || o.IsRIRPropChanged(_str_idfsCasePrimaryType, c)) 
                  m.Add(_str_idfsCasePrimaryType, o.ObjectIdent + _str_idfsCasePrimaryType, o.ObjectIdent2 + _str_idfsCasePrimaryType, o.ObjectIdent3 + _str_idfsCasePrimaryType, "Int64?", 
                    o.idfsCasePrimaryType == null ? "" : o.idfsCasePrimaryType.ToString(),                  
                  o.IsReadOnly(_str_idfsCasePrimaryType), o.IsInvisible(_str_idfsCasePrimaryType), o.IsRequired(_str_idfsCasePrimaryType)); 
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
              _name = _str_intCaseCount, _formname = _str_intCaseCount, _type = "int",
              _get_func = o => o.intCaseCount,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.intCaseCount != c.intCaseCount || o.IsRIRPropChanged(_str_intCaseCount, c)) {
                  m.Add(_str_intCaseCount, o.ObjectIdent + _str_intCaseCount, o.ObjectIdent2 + _str_intCaseCount, o.ObjectIdent3 + _str_intCaseCount, "int", o.intCaseCount == null ? "" : o.intCaseCount.ToString(), o.IsReadOnly(_str_intCaseCount), o.IsInvisible(_str_intCaseCount), o.IsRequired(_str_intCaseCount));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_intCaseConfirmedCount, _formname = _str_intCaseConfirmedCount, _type = "int",
              _get_func = o => o.intCaseConfirmedCount,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.intCaseConfirmedCount != c.intCaseConfirmedCount || o.IsRIRPropChanged(_str_intCaseConfirmedCount, c)) {
                  m.Add(_str_intCaseConfirmedCount, o.ObjectIdent + _str_intCaseConfirmedCount, o.ObjectIdent2 + _str_intCaseConfirmedCount, o.ObjectIdent3 + _str_intCaseConfirmedCount, "int", o.intCaseConfirmedCount == null ? "" : o.intCaseConfirmedCount.ToString(), o.IsReadOnly(_str_intCaseConfirmedCount), o.IsInvisible(_str_intCaseConfirmedCount), o.IsRequired(_str_intCaseConfirmedCount));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _formname = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosisOrDiagnosisGroup; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosisOrDiagnosisGroup.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Diagnosis, c);
                if (o.idfsDiagnosisOrDiagnosisGroup != c.idfsDiagnosisOrDiagnosisGroup || o.IsRIRPropChanged(_str_Diagnosis, c) || bChangeLookupContent) {
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, o.ObjectIdent2 + _str_Diagnosis, o.ObjectIdent3 + _str_Diagnosis, "Lookup", o.idfsDiagnosisOrDiagnosisGroup == null ? "" : o.idfsDiagnosisOrDiagnosisGroup.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis),
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
              _name = _str_OutbreakStatus, _formname = _str_OutbreakStatus, _type = "Lookup",
              _get_func = o => { if (o.OutbreakStatus == null) return null; return o.OutbreakStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.OutbreakStatus = o.OutbreakStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_OutbreakStatus, c);
                if (o.idfsOutbreakStatus != c.idfsOutbreakStatus || o.IsRIRPropChanged(_str_OutbreakStatus, c) || bChangeLookupContent) {
                  m.Add(_str_OutbreakStatus, o.ObjectIdent + _str_OutbreakStatus, o.ObjectIdent2 + _str_OutbreakStatus, o.ObjectIdent3 + _str_OutbreakStatus, "Lookup", o.idfsOutbreakStatus == null ? "" : o.idfsOutbreakStatus.ToString(), o.IsReadOnly(_str_OutbreakStatus), o.IsInvisible(_str_OutbreakStatus), o.IsRequired(_str_OutbreakStatus),
                  bChangeLookupContent ? o.OutbreakStatusLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_OutbreakStatus + "Lookup", _formname = _str_OutbreakStatus + "Lookup", _type = "LookupContent",
              _get_func = o => o.OutbreakStatusLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Cases, _formname = _str_Cases, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Cases.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Cases.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.Cases.Count != c.Cases.Count || o.IsReadOnly(_str_Cases) != c.IsReadOnly(_str_Cases) || o.IsInvisible(_str_Cases) != c.IsInvisible(_str_Cases) || o.IsRequired(_str_Cases) != c._isRequired(o.m_isRequired, _str_Cases)) {
                  m.Add(_str_Cases, o.ObjectIdent + _str_Cases, o.ObjectIdent2 + _str_Cases, o.ObjectIdent3 + _str_Cases, "Child", o.idfOutbreak == null ? "" : o.idfOutbreak.ToString(), o.IsReadOnly(_str_Cases), o.IsInvisible(_str_Cases), o.IsRequired(_str_Cases)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Notes, _formname = _str_Notes, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Notes.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Notes.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.Notes.Count != c.Notes.Count || o.IsReadOnly(_str_Notes) != c.IsReadOnly(_str_Notes) || o.IsInvisible(_str_Notes) != c.IsInvisible(_str_Notes) || o.IsRequired(_str_Notes) != c._isRequired(o.m_isRequired, _str_Notes)) {
                  m.Add(_str_Notes, o.ObjectIdent + _str_Notes, o.ObjectIdent2 + _str_Notes, o.ObjectIdent3 + _str_Notes, "Child", o.idfOutbreak == null ? "" : o.idfOutbreak.ToString(), o.IsReadOnly(_str_Notes), o.IsInvisible(_str_Notes), o.IsRequired(_str_Notes)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Location, _formname = _str_Location, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.Location != null) o.Location._compare(c.Location, m); }
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
            Outbreak obj = (Outbreak)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Location)]
        [Relation(typeof(GeoLocation), eidss.model.Schema.GeoLocation._str_idfGeoLocation, _str_idfGeoLocation)]
        public GeoLocation Location
        {
            get 
            {   
                return _Location; 
            }
            set 
            {   
                _Location = value;
                if (_Location != null) 
                { 
                    _Location.m_ObjectName = _str_Location;
                    _Location.Parent = this;
                }
                idfGeoLocation = _Location == null 
                        ? new Int64?()
                        : _Location.idfGeoLocation;
                
            }
        }
        protected GeoLocation _Location;
                    
        [LocalizedDisplayName(_str_Cases)]
        [Relation(typeof(OutbreakCase), eidss.model.Schema.OutbreakCase._str_idfOutbreak, _str_idfOutbreak)]
        public EditableList<OutbreakCase> Cases
        {
            get 
            {   
                return _Cases; 
            }
            set 
            {
                _Cases = value;
            }
        }
        protected EditableList<OutbreakCase> _Cases = new EditableList<OutbreakCase>();
                    
        [LocalizedDisplayName(_str_Notes)]
        [Relation(typeof(OutbreakNote), eidss.model.Schema.OutbreakNote._str_idfOutbreak, _str_idfOutbreak)]
        public EditableList<OutbreakNote> Notes
        {
            get 
            {   
                return _Notes; 
            }
            set 
            {
                _Notes = value;
            }
        }
        protected EditableList<OutbreakNote> _Notes = new EditableList<OutbreakNote>();
                    
        [LocalizedDisplayName(_str_Diagnosis)]
        [Relation(typeof(DiagnosesAndGroupsLookup), eidss.model.Schema.DiagnosesAndGroupsLookup._str_idfsDiagnosisOrDiagnosisGroup, _str_idfsDiagnosisOrDiagnosisGroup)]
        public DiagnosesAndGroupsLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                var oldVal = _Diagnosis;
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Diagnosis != oldVal)
                {
                    if (idfsDiagnosisOrDiagnosisGroup != (_Diagnosis == null
                            ? new Int64?()
                            : (Int64?)_Diagnosis.idfsDiagnosisOrDiagnosisGroup))
                        idfsDiagnosisOrDiagnosisGroup = _Diagnosis == null 
                            ? new Int64?()
                            : (Int64?)_Diagnosis.idfsDiagnosisOrDiagnosisGroup; 
                    OnPropertyChanged(_str_Diagnosis); 
                }
            }
        }
        private DiagnosesAndGroupsLookup _Diagnosis;

        
        public List<DiagnosesAndGroupsLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<DiagnosesAndGroupsLookup> _DiagnosisLookup = new List<DiagnosesAndGroupsLookup>();
            
        [LocalizedDisplayName(_str_OutbreakStatus)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsOutbreakStatus)]
        public BaseReference OutbreakStatus
        {
            get { return _OutbreakStatus == null ? null : ((long)_OutbreakStatus.Key == 0 ? null : _OutbreakStatus); }
            set 
            { 
                var oldVal = _OutbreakStatus;
                _OutbreakStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_OutbreakStatus != oldVal)
                {
                    if (idfsOutbreakStatus != (_OutbreakStatus == null
                            ? new Int64?()
                            : (Int64?)_OutbreakStatus.idfsBaseReference))
                        idfsOutbreakStatus = _OutbreakStatus == null 
                            ? new Int64?()
                            : (Int64?)_OutbreakStatus.idfsBaseReference; 
                    OnPropertyChanged(_str_OutbreakStatus); 
                }
            }
        }
        private BaseReference _OutbreakStatus;

        
        public BaseReferenceList OutbreakStatusLookup
        {
            get { return _OutbreakStatusLookup; }
        }
        private BaseReferenceList _OutbreakStatusLookup = new BaseReferenceList("rftOutbreakStatus");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosesAndGroupsLookup._str_idfsDiagnosisOrDiagnosisGroup, null, Diagnosis, _str_idfsDiagnosisOrDiagnosisGroup);
            
                case _str_OutbreakStatus:
                    return new BvSelectList(OutbreakStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, OutbreakStatus, _str_idfsOutbreakStatus);
            
                case _str_Cases:
                    return new BvSelectList(Cases, "", "", null, "");
            
                case _str_Notes:
                    return new BvSelectList(Notes, "", "", null, "");
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_intCaseCount)]
        public int intCaseCount
        {
            get { return new Func<Outbreak, int>(c => c.Cases.Count(i => !i.IsMarkedToDelete))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_intCaseConfirmedCount)]
        public int intCaseConfirmedCount
        {
            get { return new Func<Outbreak, int>(c => c.Cases.Count(i => !i.IsMarkedToDelete && i.Confirmed.HasValue && i.Confirmed.Value > 0))(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Outbreak";

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
                Cases.ForEach(c => { c.Parent = this; });
                Notes.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as Outbreak;
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
            var ret = base.Clone() as Outbreak;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Location != null)
              ret.Location = _Location.CloneWithSetup(manager, bRestricted) as GeoLocation;
                
            if (_Cases != null && _Cases.Count > 0)
            {
              ret.Cases.Clear();
              _Cases.ForEach(c => ret.Cases.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_Notes != null && _Notes.Count > 0)
            {
              ret.Notes.Clear();
              _Notes.ForEach(c => ret.Notes.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public Outbreak CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Outbreak;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfOutbreak; } }
        public string KeyName { get { return "idfOutbreak"; } }
        public object KeyLookup { get { return idfOutbreak; } }
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
        
                    || (_Location != null && _Location.HasChanges)
                
                    || Cases.IsDirty
                    || Cases.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Notes.IsDirty
                    || Notes.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsDiagnosisOrDiagnosisGroup_Diagnosis = idfsDiagnosisOrDiagnosisGroup;
            var _prev_idfsOutbreakStatus_OutbreakStatus = idfsOutbreakStatus;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosisOrDiagnosisGroup_Diagnosis != idfsDiagnosisOrDiagnosisGroup)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosisOrDiagnosisGroup == idfsDiagnosisOrDiagnosisGroup);
            }
            if (_prev_idfsOutbreakStatus_OutbreakStatus != idfsOutbreakStatus)
            {
                _OutbreakStatus = _OutbreakStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsOutbreakStatus);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (Location != null) Location.DeepRejectChanges();
                Cases.DeepRejectChanges();
                Notes.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Location != null) _Location.DeepAcceptChanges();
                Cases.DeepAcceptChanges();
                Notes.DeepAcceptChanges();
                
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
        
            if (_Location != null) _Location.SetChange();
                Cases.ForEach(c => c.SetChange());
                Notes.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, Outbreak c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, Outbreak c)
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
        

      

        public Outbreak()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Outbreak_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Outbreak_PropertyChanged);
        }
        private void Outbreak_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Outbreak).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Cases)
                OnPropertyChanged(_str_intCaseCount);
                  
            if (e.PropertyName == _str_Cases)
                OnPropertyChanged(_str_intCaseConfirmedCount);
                  
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
            Outbreak obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Outbreak obj = this;
            
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

    
        private static string[] readonly_names1 = "strOutbreakID".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strPrimaryCase".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "intCaseCount,intCaseConfirmedCount".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Outbreak, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Outbreak, bool>(c => true)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Outbreak, bool>(c => true)(this);
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
                if (_Location != null)
                    _Location._isValid &= value;
                
                foreach(var o in _Cases)
                    o._isValid &= value;
                
                foreach(var o in _Notes)
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
        
                if (_Location != null)
                    _Location.ReadOnly |= value;
                
                foreach(var o in _Cases)
                    o.ReadOnly |= value;
                
                foreach(var o in _Notes)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<Outbreak, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Outbreak, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Outbreak, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Outbreak, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Outbreak, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<Outbreak, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<Outbreak, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~Outbreak()
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
                
                if (_Location != null)
                    Location.Dispose();
                
                if (!bIsClone)
                {
                    Cases.ForEach(c => c.Dispose());
                }
                Cases.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    Notes.ForEach(c => c.Dispose());
                }
                Notes.ClearModelListEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("DiagnosesAndGroupsLookup", this);
                
                LookupManager.RemoveObject("rftOutbreakStatus", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosesAndGroupsLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftOutbreakStatus")
                _getAccessor().LoadLookup_OutbreakStatus(manager, this);
            
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
        
            if (_Location != null) _Location.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_Cases != null) _Cases.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Notes != null) _Notes.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<Outbreak>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<Outbreak>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<Outbreak>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfOutbreak"; } }
            #endregion
        
            public delegate void on_action(Outbreak obj);
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
            private OutbreakCase.Accessor CasesAccessor { get { return eidss.model.Schema.OutbreakCase.Accessor.Instance(m_CS); } }
            private OutbreakNote.Accessor NotesAccessor { get { return eidss.model.Schema.OutbreakNote.Accessor.Instance(m_CS); } }
            private DiagnosesAndGroupsLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosesAndGroupsLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor OutbreakStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            

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
            public virtual Outbreak SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
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

            
            public virtual Outbreak SelectByKey(DbManagerProxy manager
                , Int64? OutbreakID
                )
            {
                return _SelectByKey(manager
                    , OutbreakID
                    , null, null
                    );
            }
            

            private Outbreak _SelectByKey(DbManagerProxy manager
                , Int64? OutbreakID
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , OutbreakID
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual Outbreak _SelectByKeyInternal(DbManagerProxy manager
                , Int64? OutbreakID
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[3];
                List<Outbreak> objs = new List<Outbreak>();
                sets[0] = new MapResultSet(typeof(Outbreak), objs);
                
                List<OutbreakCase> objs_OutbreakCase = new List<OutbreakCase>();
                sets[1] = new MapResultSet(typeof(OutbreakCase), objs_OutbreakCase);
                
                List<OutbreakNote> objs_OutbreakNote = new List<OutbreakNote>();
                sets[2] = new MapResultSet(typeof(OutbreakNote), objs_OutbreakNote);
                Outbreak obj = null;
                try
                {
                    manager
                        .SetSpCommand("spOutbreak_SelectDetail"
                            , manager.Parameter("@OutbreakID", OutbreakID)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    obj = objs[0];
                    obj.m_CS = m_CS;
                    
                  
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    
                    obj.Cases.ForEach(c => CasesAccessor._SetupLoad(manager, c));
                            
                    obj.Notes.ForEach(c => NotesAccessor._SetupLoad(manager, c));
                            
                      if (BaseSettings.ValidateObject)
                          obj._isValid = (manager.SetSpCommand("spOutbreak_Validate", obj.Key).ExecuteScalar<int>(ScalarSourceType.ReturnValue) == 0);
                    

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
    
            private void _SetupAddChildHandlerCases(Outbreak obj)
            {
                obj.Cases.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerNotes(Outbreak obj)
            {
                obj.Notes.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadLocation(Outbreak obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLocation(manager, obj);
                }
            }
            internal void _LoadLocation(DbManagerProxy manager, Outbreak obj)
            {
              
                if (obj.Location == null && obj.idfGeoLocation != null && obj.idfGeoLocation != 0)
                {
                    obj.Location = LocationAccessor.SelectByKey(manager
                        
                        , obj.idfGeoLocation.Value
                        );
                    if (obj.Location != null)
                    {
                        obj.Location.m_ObjectName = _str_Location;
                    }
                }
                    
              }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, Outbreak obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadLocation(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.Location = new Func<Outbreak, GeoLocation>(c => c.Location == null ? LocationAccessor.CreateWithCountry(manager, c) : c.Location)(obj);
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerCases(obj);
                
                _SetupAddChildHandlerNotes(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, Outbreak obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    LocationAccessor._SetPermitions(obj._permissions, obj.Location);
                    
                        obj.Cases.ForEach(c => CasesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Notes.ForEach(c => NotesAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private Outbreak _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                Outbreak obj = null;
                try
                {
                    obj = Outbreak.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfOutbreak = (new GetNewIDExtender<Outbreak>()).GetScalar(manager, obj, isFake);
                obj.strOutbreakID = new Func<Outbreak, string>(c => string.Empty)(obj);
                obj.Location = new Func<Outbreak, GeoLocation>(c => LocationAccessor.CreateWithCountry(manager, c))(obj);
                obj.Location.GeoLocationType = new Func<Outbreak, BaseReference>(c => c.Location.GeoLocationTypeLookup.SingleOrDefault(a => a.idfsBaseReference == (long)GeoLocationTypeEnum.RelativePoint))(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerCases(obj);
                    
                    _SetupAddChildHandlerNotes(obj);
                    
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

            
            public Outbreak CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Outbreak CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public Outbreak CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ClearPrimaryCase(DbManagerProxy manager, Outbreak obj, List<object> pars)
            {
                
                return ClearPrimaryCase(manager, obj
                    );
            }
            public ActResult ClearPrimaryCase(DbManagerProxy manager, Outbreak obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ClearPrimaryCase"))
                    throw new PermissionException("Outbreak", "ClearPrimaryCase");
                
              obj.idfPrimaryCaseOrSession = null;
              obj.idfsCasePrimaryType = 0;
              obj.strPrimaryCase = "";
              return true;
            
            }
            
      
            public ActResult SetPrimaryCase(DbManagerProxy manager, Outbreak obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is OutbreakCase)) 
                    throw new TypeMismatchException("caseOrSession", typeof(OutbreakCase));
                
                return SetPrimaryCase(manager, obj
                    , (OutbreakCase)pars[0]
                    );
            }
            public ActResult SetPrimaryCase(DbManagerProxy manager, Outbreak obj
                , OutbreakCase caseOrSession
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("SetPrimaryCase"))
                    throw new PermissionException("Outbreak", "SetPrimaryCase");
                
              if (caseOrSession != null) 
              {
                  obj.idfPrimaryCaseOrSession = caseOrSession.idfCase;
                  obj.idfsCasePrimaryType = caseOrSession.idfsCaseType;
                  obj.strPrimaryCase = caseOrSession.strCaseID + (string.IsNullOrEmpty(caseOrSession.strDiagnosis) ? "" : ", " + caseOrSession.strDiagnosis);
              }
              return true;
            
            }
            
      
            public ActResult ReportContextMenu(DbManagerProxy manager, Outbreak obj, List<object> pars)
            {
                
                return ReportContextMenu(manager, obj
                    );
            }
            public ActResult ReportContextMenu(DbManagerProxy manager, Outbreak obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ReportContextMenu"))
                    throw new PermissionException("Outbreak", "ReportContextMenu");
                
                return true;
                
            }
            
      
            public ActResult OutbreakReport(DbManagerProxy manager, Outbreak obj, List<object> pars)
            {
                
                return OutbreakReport(manager, obj
                    );
            }
            public ActResult OutbreakReport(DbManagerProxy manager, Outbreak obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("OutbreakReport"))
                    throw new PermissionException("Outbreak", "OutbreakReport");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(Outbreak obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Outbreak obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datStartDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datStartDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datFinishDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFinishDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
                obj.Cases.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    if (e.ListChangedType == ListChangedType.ItemAdded && obj.Cases.Count > e.NewIndex)
                    {
                        try
                        {
                            var item = obj.Cases[e.NewIndex];
                      
                CheckOnAddCase(obj, item);
            
                        }
                        catch (ValidationModelException ex)
                        {
                            if (!obj.OnValidation(ex))
                            {
                                if (obj.Cases.Count > e.NewIndex)
                                    obj.Cases.RemoveAt(e.NewIndex);
                                obj.OnValidationEnd(ex);
                            }
                        }
                    }
                };
                    
                obj.Cases.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    
              if (e.ListChangedType == ListChangedType.ItemAdded && obj.Cases.Count > e.NewIndex && obj.Cases.Count(c => c.idfCase == obj.Cases[e.NewIndex].idfCase && !c.IsMarkedToDelete) > 1) 
              {
                  obj.Cases.RemoveAt(e.NewIndex);
              }
              else 
              {
                  if (e.ListChangedType == ListChangedType.ItemChanged && obj.Cases.Count > e.NewIndex && obj.Cases[e.NewIndex].IsMarkedToDelete && obj.Cases[e.NewIndex].idfCase == obj.idfPrimaryCaseOrSession)
                  {
                      using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                      {
                          ClearPrimaryCase(manager, obj);
                      }
                  }
                  if (obj.Cases.Count > e.NewIndex && obj.Cases.Count(c => c.idfCase == obj.Cases[e.NewIndex].idfCase && !c.IsMarkedToDelete) == 1 && obj.Diagnosis != null)
                  {
                      if (obj.Cases.Single(c => c.idfCase == obj.Cases[e.NewIndex].idfCase && !c.IsMarkedToDelete).idfsDefaultDiagnosis != obj.Diagnosis.idfsDiagnosisOrDiagnosisGroup && obj.Diagnosis.blnGroup.HasValue && !obj.Diagnosis.blnGroup.Value && obj.Diagnosis.idfsDiagnosisGroup.HasValue && obj.Diagnosis.idfsDiagnosisGroup.Value != 0)
                      {
                          obj.Diagnosis = obj.DiagnosisLookup.SingleOrDefault(i => i.idfsDiagnosisOrDiagnosisGroup == obj.Diagnosis.idfsDiagnosisGroup);
                      }
                  }
                  if (e.ListChangedType == ListChangedType.ItemAdded && obj.Cases.Count > e.NewIndex && obj.Cases.Count(c => !c.IsMarkedToDelete) == 1)
                  {
                      using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                      {
                          var location = GeoLocation.Accessor.Instance(null).SelectByKey(manager, obj.Cases.FirstOrDefault(c => !c.IsMarkedToDelete, i => i.idfGeoLocation));
                          if (location != null)
                          {
                              location.CopyFieldsTo(obj.Location);
                          }
                      }
                  }
              }
            
                };
                    
                obj.Cases.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    
                obj.Diagnosis = new Func<Outbreak, DiagnosesAndGroupsLookup>(c => c.Cases.Count(i => !i.IsMarkedToDelete) != 1 || c.Diagnosis != null ? c.Diagnosis : (c.DiagnosisLookup.SingleOrDefault(i => i.idfsDiagnosisOrDiagnosisGroup == c.Cases.First(j => !j.IsMarkedToDelete).idfsDefaultDiagnosis)))(obj);
                };
                    
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsDiagnosisOrDiagnosisGroup)
                        {
                            try
                            {
                            
                CheckDiagnosisOnChange(obj);
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_idfsDiagnosisOrDiagnosisGroup);
                                    obj._Diagnosis = obj.DiagnosisLookup.Where(a => a.idfsDiagnosisOrDiagnosisGroup == obj.idfsDiagnosisOrDiagnosisGroup).SingleOrDefault();
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                                
                                else if (ex.ValidationType == ValidationEventType.Question)
                                {
                                    obj.LockNotifyChanges();
                                    new Action<Outbreak>(c => c.Diagnosis = c.DiagnosisLookup.SingleOrDefault(i => i.idfsDiagnosisOrDiagnosisGroup == c.Diagnosis.idfsDiagnosisGroup))(obj);
                                    obj.UnlockNotifyChanges();
                                }
                                
                            }
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Diagnosis(DbManagerProxy manager, Outbreak obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    , new Func<Outbreak, int>(c => (int)HACode.HumanLivestockAvianVector)(obj)
                            
                    , new Func<Outbreak, long>(c => (long)DiagnosisUsingTypeEnum.StandardCase)(obj)
                            
                    , new Func<Outbreak, long>(c => 19000156)(obj)
                            
                    )
                    .Where(c => !EidssUserContext.User.DenyDiagnosis.ContainsKey((long)c.idfsDiagnosisOrDiagnosisGroup))
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosisOrDiagnosisGroup == obj.idfsDiagnosisOrDiagnosisGroup))
                    
                    .ToList());
                
                if (obj.idfsDiagnosisOrDiagnosisGroup != null && obj.idfsDiagnosisOrDiagnosisGroup != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosisOrDiagnosisGroup == obj.idfsDiagnosisOrDiagnosisGroup);
                    
                }
              
                LookupManager.AddObject("DiagnosesAndGroupsLookup", obj, DiagnosisAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_OutbreakStatus(DbManagerProxy manager, Outbreak obj)
            {
                
                obj.OutbreakStatusLookup.Clear();
                
                obj.OutbreakStatusLookup.Add(OutbreakStatusAccessor.CreateNewT(manager, null));
                
                obj.OutbreakStatusLookup.AddRange(OutbreakStatusAccessor.rftOutbreakStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsOutbreakStatus))
                    
                    .ToList());
                
                if (obj.idfsOutbreakStatus != null && obj.idfsOutbreakStatus != 0)
                {
                    obj.OutbreakStatus = obj.OutbreakStatusLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsOutbreakStatus);
                    
                }
              
                LookupManager.AddObject("rftOutbreakStatus", obj, OutbreakStatusAccessor.GetType(), "rftOutbreakStatus_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, Outbreak obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_OutbreakStatus(manager, obj);
                
            }
    
            [SprocName("spOutbreak_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spOutbreak_Delete")]
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
        
            [SprocName("spOutbreak_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strOutbreakID")] Outbreak obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strOutbreakID")] Outbreak obj)
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
                        Outbreak bo = obj as Outbreak;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            if (!CanDelete)
                                throw new PermissionException("Outbreak", "Delete");
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            if (!CanInsert)
                                throw new PermissionException("Outbreak", "Insert");
                        }
                        else if (!bo.IsMarkedToDelete && bo.HasChanges) // update
                        {
                            if (!CanUpdate)
                                throw new PermissionException("Outbreak", "Update");
                        }
                        
                        long mainObject = bo.idfOutbreak;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                                manager.SetEventParams(false, new object[] { EventType.OutbreakCreatedLocal, mainObject, "" });
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                            if (new Func<Outbreak, bool>(c => c.Cases.Count(i => i.IsNew && i.idfsCaseType == (long)CaseTypeEnum.Human && !i.IsMarkedToDelete) > 0)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.NewHumanCaseAddedToOutbreakLocal, mainObject, "" });
                            
                            if (new Func<Outbreak, bool>(c => c.Cases.Count(i => i.IsNew && (i.idfsCaseType == (long)CaseTypeEnum.Livestock || i.idfsCaseType == (long)CaseTypeEnum.Avian || i.idfsCaseType == (long)CaseTypeEnum.Veterinary) && !i.IsMarkedToDelete) > 0)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.NewVetCaseAddedToOutbreakLocal, mainObject, "" });
                            
                            if (new Func<Outbreak, bool>(c => c.Cases.Count(i => i.IsNew && i.idfsCaseType == (long)CaseTypeEnum.Vector && !i.IsMarkedToDelete) > 0)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.NewVsSessionAddedToOutbreakLocal, mainObject, "" });
                            
                            if (
                                bo.idfPrimaryCaseOrSession != bo.idfPrimaryCaseOrSession_Original
                              )
                              
                                manager.SetEventParams(false, new object[] { EventType.OutbreakPrimaryCaseChangedLocal, mainObject, "" });
                            
                            if (
                                bo.idfsOutbreakStatus != bo.idfsOutbreakStatus_Original
                              )
                              
                                manager.SetEventParams(false, new object[] { EventType.OutbreakStatusChangedLocal, mainObject, "" });
                            
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
                            
                            eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoOutbreak;
                            eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbOutbreak;
                            manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as Outbreak, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, Outbreak obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                                
                    _postPredicate(manager, 8, obj);
                                    
                    if (obj.Location != null)
                    {
                        obj.Location.MarkToDelete();
                        if (!LocationAccessor.Post(manager, obj.Location, true))
                            return false;
                    }
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                obj.datModificationForArchiveDate = new Func<Outbreak, DateTime?>(c => c.HasChanges ? DateTime.Now : c.datModificationForArchiveDate)(obj);
                obj.strOutbreakID = new Func<Outbreak, DbManagerProxy, string>((c,m) => 
                        c.strOutbreakID != string.Empty 
                        ? c.strOutbreakID 
                        : m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.Outbreak, DBNull.Value, DBNull.Value)
                        .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue"))(obj, manager);
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
                                    
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                                    
                    if (obj.IsNew)
                    {
                        if (obj.Cases != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Cases)
                                if (!CasesAccessor.Post(manager, i, true))
                                    return false;
                            obj.Cases.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Cases.Remove(c));
                            obj.Cases.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Cases != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Cases)
                                if (!CasesAccessor.Post(manager, i, true))
                                    return false;
                            obj._Cases.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Cases.Remove(c));
                            obj._Cases.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.Notes != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Notes)
                                if (!NotesAccessor.Post(manager, i, true))
                                    return false;
                            obj.Notes.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Notes.Remove(c));
                            obj.Notes.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Notes != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Notes)
                                if (!NotesAccessor.Post(manager, i, true))
                                    return false;
                            obj._Notes.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Notes.Remove(c));
                            obj._Notes.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(Outbreak obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, Outbreak obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfOutbreak
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
        
      
            protected ValidationModelException ChainsValidate(Outbreak obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<Outbreak>(obj, "datStartDate", c => true, 
      obj.datStartDate,
      obj.GetType(),
      false, listdatStartDate => {
    listdatStartDate.Add(
    new ChainsValidatorDateTime<Outbreak>(obj, "datFinishDate", c => true, 
      obj.datFinishDate,
      obj.GetType(),
      false, listdatFinishDate => {
    listdatFinishDate.Add(
    new ChainsValidatorDateTime<Outbreak>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
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
            protected bool ChainsValidate(Outbreak obj, bool bRethrowException)
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
                return Validate(manager, obj as Outbreak, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Outbreak obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsDiagnosisOrDiagnosisGroup", "Diagnosis","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsDiagnosisOrDiagnosisGroup);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                CheckDiagnosisOnChange(obj);
            
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Location != null)
                            LocationAccessor.Validate(manager, obj.Location, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Cases != null)
                            foreach (var i in obj.Cases.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                CasesAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Notes != null)
                            foreach (var i in obj.Notes.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                NotesAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(Outbreak obj)
            {
            
                obj
                    .AddRequired("Diagnosis", c => true);
                    
                  obj
                    .AddRequired("Diagnosis", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(Outbreak obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Outbreak) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Outbreak) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "OutbreakDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private Outbreak m_obj;
            internal Permissions(Outbreak obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spOutbreak_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spOutbreak_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spOutbreak_Delete";
            public static string spCanDelete = "spOutbreak_CanDelete";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Outbreak, bool>> RequiredByField = new Dictionary<string, Func<Outbreak, bool>>();
            public static Dictionary<string, Func<Outbreak, bool>> RequiredByProperty = new Dictionary<string, Func<Outbreak, bool>>();
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
                Sizes.Add(_str_strDescription, 2000);
                Sizes.Add(_str_strPrimaryCase, 2202);
                if (!RequiredByField.ContainsKey("idfsDiagnosisOrDiagnosisGroup")) RequiredByField.Add("idfsDiagnosisOrDiagnosisGroup", c => true);
                if (!RequiredByProperty.ContainsKey("Diagnosis")) RequiredByProperty.Add("Diagnosis", c => true);
                
                Actions.Add(new ActionMetaItem(
                    "ClearPrimaryCase",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ClearPrimaryCase(manager, (Outbreak)c, pars),
                        
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
                    "SetPrimaryCase",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).SetPrimaryCase(manager, (Outbreak)c, pars),
                        
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
                    "ReportContextMenu",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ReportContextMenu(manager, (Outbreak)c, pars),
                        
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
                    "OutbreakReport",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).OutbreakReport(manager, (Outbreak)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleOutbreakReport",
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
                    (o1, o2, p, r) => eidss.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("Outbreak"),
                    false,
                    false,
                    null,
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Outbreak>().Post(manager, (Outbreak)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Outbreak>().Post(manager, (Outbreak)c), c),
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
                    (manager, c, pars) => new ActResult(((Outbreak)c).MarkToDelete() && ObjectAccessor.PostInterface<Outbreak>().Post(manager, (Outbreak)c), c),
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
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class OutbreakCase : 
        EditableObject<OutbreakCase>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCase { get; set; }
                
        [LocalizedDisplayName(_str_idfOutbreak)]
        [MapField(_str_idfOutbreak)]
        public abstract Int64? idfOutbreak { get; set; }
        protected Int64? idfOutbreak_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOutbreak).OriginalValue; } }
        protected Int64? idfOutbreak_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOutbreak).PreviousValue; } }
                
        [LocalizedDisplayName("strCaseSessionID")]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseType)]
        [MapField(_str_idfsCaseType)]
        public abstract Int64 idfsCaseType { get; set; }
        protected Int64 idfsCaseType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseType).OriginalValue; } }
        protected Int64 idfsCaseType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsCaseType).PreviousValue; } }
                
        [LocalizedDisplayName("CaseStatusName")]
        [MapField(_str_strCaseStatus)]
        public abstract String strCaseStatus { get; set; }
        protected String strCaseStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseStatus).OriginalValue; } }
        protected String strCaseStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Confirmed)]
        [MapField(_str_Confirmed)]
        public abstract Int32? Confirmed { get; set; }
        protected Int32? Confirmed_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._confirmed).OriginalValue; } }
        protected Int32? Confirmed_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._confirmed).PreviousValue; } }
                
        [LocalizedDisplayName("DiagnosisName")]
        [MapField(_str_strDiagnosis)]
        public abstract String strDiagnosis { get; set; }
        protected String strDiagnosis_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosis).OriginalValue; } }
        protected String strDiagnosis_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsDefaultDiagnosis)]
        [MapField(_str_idfsDefaultDiagnosis)]
        public abstract Int64? idfsDefaultDiagnosis { get; set; }
        protected Int64? idfsDefaultDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDefaultDiagnosis).OriginalValue; } }
        protected Int64? idfsDefaultDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDefaultDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName("strCaseSessionDate")]
        [MapField(_str_datEnteredDate)]
        public abstract DateTime? datEnteredDate { get; set; }
        protected DateTime? datEnteredDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).OriginalValue; } }
        protected DateTime? datEnteredDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSourceOfCaseSessionDate)]
        [MapField(_str_idfsSourceOfCaseSessionDate)]
        public abstract Int32 idfsSourceOfCaseSessionDate { get; set; }
        protected Int32 idfsSourceOfCaseSessionDate_Original { get { return ((EditableValue<Int32>)((dynamic)this)._idfsSourceOfCaseSessionDate).OriginalValue; } }
        protected Int32 idfsSourceOfCaseSessionDate_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._idfsSourceOfCaseSessionDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfGeoLocation)]
        [MapField(_str_idfGeoLocation)]
        public abstract Int64? idfGeoLocation { get; set; }
        protected Int64? idfGeoLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfGeoLocation).OriginalValue; } }
        protected Int64? idfGeoLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfGeoLocation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfAddress)]
        [MapField(_str_idfAddress)]
        public abstract Int64? idfAddress { get; set; }
        protected Int64? idfAddress_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAddress).OriginalValue; } }
        protected Int64? idfAddress_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAddress).PreviousValue; } }
                
        [LocalizedDisplayName("strExposureLocation")]
        [MapField(_str_strGeoLocation)]
        public abstract String strGeoLocation { get; set; }
        protected String strGeoLocation_Original { get { return ((EditableValue<String>)((dynamic)this)._strGeoLocation).OriginalValue; } }
        protected String strGeoLocation_Previous { get { return ((EditableValue<String>)((dynamic)this)._strGeoLocation).PreviousValue; } }
                
        [LocalizedDisplayName("AddressName")]
        [MapField(_str_strAddress)]
        public abstract String strAddress { get; set; }
        protected String strAddress_Original { get { return ((EditableValue<String>)((dynamic)this)._strAddress).OriginalValue; } }
        protected String strAddress_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAddress).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPatientName)]
        [MapField(_str_strPatientName)]
        public abstract String strPatientName { get; set; }
        protected String strPatientName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPatientName).OriginalValue; } }
        protected String strPatientName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPatientName).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<OutbreakCase, object> _get_func;
            internal Action<OutbreakCase, string> _set_func;
            internal Action<OutbreakCase, OutbreakCase, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfOutbreak = "idfOutbreak";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_idfsCaseType = "idfsCaseType";
        internal const string _str_strCaseStatus = "strCaseStatus";
        internal const string _str_Confirmed = "Confirmed";
        internal const string _str_strDiagnosis = "strDiagnosis";
        internal const string _str_idfsDefaultDiagnosis = "idfsDefaultDiagnosis";
        internal const string _str_datEnteredDate = "datEnteredDate";
        internal const string _str_idfsSourceOfCaseSessionDate = "idfsSourceOfCaseSessionDate";
        internal const string _str_idfGeoLocation = "idfGeoLocation";
        internal const string _str_idfAddress = "idfAddress";
        internal const string _str_strGeoLocation = "strGeoLocation";
        internal const string _str_strAddress = "strAddress";
        internal const string _str_strPatientName = "strPatientName";
        internal const string _str_strSourceOfCaseSessionDate = "strSourceOfCaseSessionDate";
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
              _name = _str_strCaseStatus, _formname = _str_strCaseStatus, _type = "String",
              _get_func = o => o.strCaseStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCaseStatus != newval) o.strCaseStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCaseStatus != c.strCaseStatus || o.IsRIRPropChanged(_str_strCaseStatus, c)) 
                  m.Add(_str_strCaseStatus, o.ObjectIdent + _str_strCaseStatus, o.ObjectIdent2 + _str_strCaseStatus, o.ObjectIdent3 + _str_strCaseStatus, "String", 
                    o.strCaseStatus == null ? "" : o.strCaseStatus.ToString(),                  
                  o.IsReadOnly(_str_strCaseStatus), o.IsInvisible(_str_strCaseStatus), o.IsRequired(_str_strCaseStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Confirmed, _formname = _str_Confirmed, _type = "Int32?",
              _get_func = o => o.Confirmed,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.Confirmed != newval) o.Confirmed = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.Confirmed != c.Confirmed || o.IsRIRPropChanged(_str_Confirmed, c)) 
                  m.Add(_str_Confirmed, o.ObjectIdent + _str_Confirmed, o.ObjectIdent2 + _str_Confirmed, o.ObjectIdent3 + _str_Confirmed, "Int32?", 
                    o.Confirmed == null ? "" : o.Confirmed.ToString(),                  
                  o.IsReadOnly(_str_Confirmed), o.IsInvisible(_str_Confirmed), o.IsRequired(_str_Confirmed)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDiagnosis, _formname = _str_strDiagnosis, _type = "String",
              _get_func = o => o.strDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnosis != newval) o.strDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strDiagnosis != c.strDiagnosis || o.IsRIRPropChanged(_str_strDiagnosis, c)) 
                  m.Add(_str_strDiagnosis, o.ObjectIdent + _str_strDiagnosis, o.ObjectIdent2 + _str_strDiagnosis, o.ObjectIdent3 + _str_strDiagnosis, "String", 
                    o.strDiagnosis == null ? "" : o.strDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_strDiagnosis), o.IsInvisible(_str_strDiagnosis), o.IsRequired(_str_strDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDefaultDiagnosis, _formname = _str_idfsDefaultDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsDefaultDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsDefaultDiagnosis != newval) o.idfsDefaultDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDefaultDiagnosis != c.idfsDefaultDiagnosis || o.IsRIRPropChanged(_str_idfsDefaultDiagnosis, c)) 
                  m.Add(_str_idfsDefaultDiagnosis, o.ObjectIdent + _str_idfsDefaultDiagnosis, o.ObjectIdent2 + _str_idfsDefaultDiagnosis, o.ObjectIdent3 + _str_idfsDefaultDiagnosis, "Int64?", 
                    o.idfsDefaultDiagnosis == null ? "" : o.idfsDefaultDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsDefaultDiagnosis), o.IsInvisible(_str_idfsDefaultDiagnosis), o.IsRequired(_str_idfsDefaultDiagnosis)); 
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
              _name = _str_idfsSourceOfCaseSessionDate, _formname = _str_idfsSourceOfCaseSessionDate, _type = "Int32",
              _get_func = o => o.idfsSourceOfCaseSessionDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.idfsSourceOfCaseSessionDate != newval) o.idfsSourceOfCaseSessionDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSourceOfCaseSessionDate != c.idfsSourceOfCaseSessionDate || o.IsRIRPropChanged(_str_idfsSourceOfCaseSessionDate, c)) 
                  m.Add(_str_idfsSourceOfCaseSessionDate, o.ObjectIdent + _str_idfsSourceOfCaseSessionDate, o.ObjectIdent2 + _str_idfsSourceOfCaseSessionDate, o.ObjectIdent3 + _str_idfsSourceOfCaseSessionDate, "Int32", 
                    o.idfsSourceOfCaseSessionDate == null ? "" : o.idfsSourceOfCaseSessionDate.ToString(),                  
                  o.IsReadOnly(_str_idfsSourceOfCaseSessionDate), o.IsInvisible(_str_idfsSourceOfCaseSessionDate), o.IsRequired(_str_idfsSourceOfCaseSessionDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfGeoLocation, _formname = _str_idfGeoLocation, _type = "Int64?",
              _get_func = o => o.idfGeoLocation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfGeoLocation != newval) o.idfGeoLocation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfGeoLocation != c.idfGeoLocation || o.IsRIRPropChanged(_str_idfGeoLocation, c)) 
                  m.Add(_str_idfGeoLocation, o.ObjectIdent + _str_idfGeoLocation, o.ObjectIdent2 + _str_idfGeoLocation, o.ObjectIdent3 + _str_idfGeoLocation, "Int64?", 
                    o.idfGeoLocation == null ? "" : o.idfGeoLocation.ToString(),                  
                  o.IsReadOnly(_str_idfGeoLocation), o.IsInvisible(_str_idfGeoLocation), o.IsRequired(_str_idfGeoLocation)); 
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
              _name = _str_strGeoLocation, _formname = _str_strGeoLocation, _type = "String",
              _get_func = o => o.strGeoLocation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strGeoLocation != newval) o.strGeoLocation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strGeoLocation != c.strGeoLocation || o.IsRIRPropChanged(_str_strGeoLocation, c)) 
                  m.Add(_str_strGeoLocation, o.ObjectIdent + _str_strGeoLocation, o.ObjectIdent2 + _str_strGeoLocation, o.ObjectIdent3 + _str_strGeoLocation, "String", 
                    o.strGeoLocation == null ? "" : o.strGeoLocation.ToString(),                  
                  o.IsReadOnly(_str_strGeoLocation), o.IsInvisible(_str_strGeoLocation), o.IsRequired(_str_strGeoLocation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strAddress, _formname = _str_strAddress, _type = "String",
              _get_func = o => o.strAddress,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAddress != newval) o.strAddress = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strAddress != c.strAddress || o.IsRIRPropChanged(_str_strAddress, c)) 
                  m.Add(_str_strAddress, o.ObjectIdent + _str_strAddress, o.ObjectIdent2 + _str_strAddress, o.ObjectIdent3 + _str_strAddress, "String", 
                    o.strAddress == null ? "" : o.strAddress.ToString(),                  
                  o.IsReadOnly(_str_strAddress), o.IsInvisible(_str_strAddress), o.IsRequired(_str_strAddress)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPatientName, _formname = _str_strPatientName, _type = "String",
              _get_func = o => o.strPatientName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPatientName != newval) o.strPatientName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strPatientName != c.strPatientName || o.IsRIRPropChanged(_str_strPatientName, c)) 
                  m.Add(_str_strPatientName, o.ObjectIdent + _str_strPatientName, o.ObjectIdent2 + _str_strPatientName, o.ObjectIdent3 + _str_strPatientName, "String", 
                    o.strPatientName == null ? "" : o.strPatientName.ToString(),                  
                  o.IsReadOnly(_str_strPatientName), o.IsInvisible(_str_strPatientName), o.IsRequired(_str_strPatientName)); 
                  }
              }, 
        
            new field_info {
              _name = _str_strSourceOfCaseSessionDate, _formname = _str_strSourceOfCaseSessionDate, _type = "string",
              _get_func = o => o.strSourceOfCaseSessionDate,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strSourceOfCaseSessionDate != c.strSourceOfCaseSessionDate || o.IsRIRPropChanged(_str_strSourceOfCaseSessionDate, c)) {
                  m.Add(_str_strSourceOfCaseSessionDate, o.ObjectIdent + _str_strSourceOfCaseSessionDate, o.ObjectIdent2 + _str_strSourceOfCaseSessionDate, o.ObjectIdent3 + _str_strSourceOfCaseSessionDate, "string", o.strSourceOfCaseSessionDate == null ? "" : o.strSourceOfCaseSessionDate.ToString(), o.IsReadOnly(_str_strSourceOfCaseSessionDate), o.IsInvisible(_str_strSourceOfCaseSessionDate), o.IsRequired(_str_strSourceOfCaseSessionDate));
                  }
                
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
            OutbreakCase obj = (OutbreakCase)o;
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
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strSourceOfCaseSessionDate)]
        public string strSourceOfCaseSessionDate
        {
            get { return new Func<OutbreakCase, string>(c => SourceOfCaseSessionDateMapper.Map((SourceOfCaseSessionDate)c.idfsSourceOfCaseSessionDate))(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "OutbreakCase";

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
            var ret = base.Clone() as OutbreakCase;
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
            var ret = base.Clone() as OutbreakCase;
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
        public OutbreakCase CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as OutbreakCase;
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

        private bool IsRIRPropChanged(string fld, OutbreakCase c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, OutbreakCase c)
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
        

      

        public OutbreakCase()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(OutbreakCase_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(OutbreakCase_PropertyChanged);
        }
        private void OutbreakCase_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as OutbreakCase).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsSourceOfCaseSessionDate)
                OnPropertyChanged(_str_strSourceOfCaseSessionDate);
                  
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
            OutbreakCase obj = this;
            
        }
        private void _DeletedExtenders()
        {
            OutbreakCase obj = this;
            
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


        internal Dictionary<string, Func<OutbreakCase, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<OutbreakCase, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<OutbreakCase, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<OutbreakCase, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<OutbreakCase, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<OutbreakCase, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<OutbreakCase, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~OutbreakCase()
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
        public class OutbreakCaseGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfCase { get; set; }
        
            public String strCaseID { get; set; }
        
            public DateTimeWrap datEnteredDate { get; set; }
        
            public string strSourceOfCaseSessionDate { get; set; }
        
            public String strCaseStatus { get; set; }
        
            public String strDiagnosis { get; set; }
        
            public String strGeoLocation { get; set; }
        
            public String strAddress { get; set; }
        
            public String strPatientName { get; set; }
        
        }
        public partial class OutbreakCaseGridModelList : List<OutbreakCaseGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public OutbreakCaseGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<OutbreakCase>, errMes);
            }
            public OutbreakCaseGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<OutbreakCase>, errMes);
            }
            public OutbreakCaseGridModelList(long key, IEnumerable<OutbreakCase> items)
            {
                LoadGridModelList(key, items, null);
            }
            public OutbreakCaseGridModelList(long key)
            {
                LoadGridModelList(key, new List<OutbreakCase>(), null);
            }
            partial void filter(List<OutbreakCase> items);
            private void LoadGridModelList(long key, IEnumerable<OutbreakCase> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strCaseID,_str_datEnteredDate,_str_strSourceOfCaseSessionDate,_str_strCaseStatus,_str_strDiagnosis,_str_strGeoLocation,_str_strAddress,_str_strPatientName};
                    
                Hiddens = new List<string> {_str_idfCase};
                Keys = new List<string> {_str_idfCase};
                Labels = new Dictionary<string, string> {{_str_strCaseID, "strCaseSessionID"},{_str_datEnteredDate, "strCaseSessionDate"},{_str_strSourceOfCaseSessionDate, _str_strSourceOfCaseSessionDate},{_str_strCaseStatus, "CaseStatusName"},{_str_strDiagnosis, "DiagnosisName"},{_str_strGeoLocation, "strExposureLocation"},{_str_strAddress, "AddressName"},{_str_strPatientName, _str_strPatientName}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                OutbreakCase.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<OutbreakCase>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new OutbreakCaseGridModel()
                {
                    ItemKey=c.idfCase,strCaseID=c.strCaseID,datEnteredDate=c.datEnteredDate,strSourceOfCaseSessionDate=c.strSourceOfCaseSessionDate,strCaseStatus=c.strCaseStatus,strDiagnosis=c.strDiagnosis,strGeoLocation=c.IsHiddenPersonalData("strGeoLocation")?"****":c.strGeoLocation,strAddress=c.IsHiddenPersonalData("strAddress")?"****":c.strAddress,strPatientName=c.IsHiddenPersonalData("strPatientName")?"****":c.strPatientName
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
        : DataAccessor<OutbreakCase>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<OutbreakCase>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfCase"; } }
            #endregion
        
            public delegate void on_action(OutbreakCase obj);
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
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<OutbreakCase> SelectList(DbManagerProxy manager
                , Int64? OutbreakID
                )
            {
                return _SelectList(manager
                    , OutbreakID
                    , delegate(OutbreakCase obj)
                        {
                        }
                    , delegate(OutbreakCase obj)
                        {
                        }
                    );
            }

            

            public List<OutbreakCase> _SelectList(DbManagerProxy manager
                , Int64? OutbreakID
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , OutbreakID
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<OutbreakCase> _SelectListInternal(DbManagerProxy manager
                , Int64? OutbreakID
                , on_action loading, on_action loaded
                )
            {
                OutbreakCase _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<OutbreakCase> objs = new List<OutbreakCase>();
                    sets[0] = new MapResultSet(typeof(OutbreakCase), objs);
                    
                    manager
                        .SetSpCommand("spOutbreak_SelectDetail"
                            , manager.Parameter("@OutbreakID", OutbreakID)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, OutbreakCase obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, OutbreakCase obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private OutbreakCase _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                OutbreakCase obj = null;
                try
                {
                    obj = OutbreakCase.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfOutbreak = new Func<OutbreakCase, long>(c => (Parent as Outbreak).idfOutbreak)(obj);
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

            
            public OutbreakCase CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public OutbreakCase CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public OutbreakCase CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public OutbreakCase CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfCase", typeof(long));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public OutbreakCase Create(DbManagerProxy manager, IObject Parent
                , long idfCase
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfCase = new Func<OutbreakCase, long>(c => idfCase)(obj);
                  var pop = manager.SetSpCommand("dbo.spOutbreak_PopulateCaseInfo", idfCase, ModelUserContext.CurrentLanguage).ExecuteObject<OutbreakCase>();
                  obj.strCaseStatus = pop.strCaseStatus;
                  obj.Confirmed = pop.Confirmed;
                  obj.strDiagnosis = pop.strDiagnosis;
                  obj.idfsDefaultDiagnosis = pop.idfsDefaultDiagnosis;
                  obj.datEnteredDate = pop.datEnteredDate;
                  obj.idfsSourceOfCaseSessionDate = pop.idfsSourceOfCaseSessionDate;
                  obj.idfGeoLocation = pop.idfGeoLocation;
                  obj.idfAddress = pop.idfAddress;
                  obj.strGeoLocation = pop.strGeoLocation;
                  obj.strAddress = pop.strAddress;
                  obj.strPatientName = pop.strPatientName;
                  obj.strCaseID = pop.strCaseID;
                  obj.idfsCaseType = pop.idfsCaseType;
                
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(OutbreakCase obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(OutbreakCase obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, OutbreakCase obj)
            {
                
            }
    
            [SprocName("spOutbreak_PostCaseList")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] OutbreakCase obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] OutbreakCase obj)
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
                        OutbreakCase bo = obj as OutbreakCase;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as OutbreakCase, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, OutbreakCase obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(OutbreakCase obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, OutbreakCase obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(OutbreakCase obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(OutbreakCase obj, bool bRethrowException)
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
                return Validate(manager, obj as OutbreakCase, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, OutbreakCase obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(OutbreakCase obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(OutbreakCase obj)
    {
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName))
      {
      
            obj
              .AddHiddenPersonalData("strPatientName", c => c.idfsCaseType == (long)CaseTypeEnum.Human);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Details))
      {
      
            obj
              .AddHiddenPersonalData("strAddress", c => c.idfsCaseType == (long)CaseTypeEnum.Human);
            
            obj
              .AddHiddenPersonalData("strGeoLocation", c => c.idfsCaseType == (long)CaseTypeEnum.Human);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Settlement))
      {
      
            obj
              .AddHiddenPersonalData("strAddress", c => c.idfsCaseType == (long)CaseTypeEnum.Human);
            
            obj
              .AddHiddenPersonalData("strGeoLocation", c => c.idfsCaseType == (long)CaseTypeEnum.Human);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement))
      {
      
            obj
              .AddHiddenPersonalData("strGeoLocation", c => c.idfsCaseType == (long)CaseTypeEnum.Livestock || c.idfsCaseType == (long)CaseTypeEnum.Avian || c.idfsCaseType == (long)CaseTypeEnum.Veterinary);
            
            obj
              .AddHiddenPersonalData("strPatientName", c => c.idfsCaseType == (long)CaseTypeEnum.Livestock || c.idfsCaseType == (long)CaseTypeEnum.Avian || c.idfsCaseType == (long)CaseTypeEnum.Veterinary);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details))
      {
      
            obj
              .AddHiddenPersonalData("strGeoLocation", c => c.idfsCaseType == (long)CaseTypeEnum.Livestock || c.idfsCaseType == (long)CaseTypeEnum.Avian || c.idfsCaseType == (long)CaseTypeEnum.Veterinary);
            
            obj
              .AddHiddenPersonalData("strPatientName", c => c.idfsCaseType == (long)CaseTypeEnum.Livestock || c.idfsCaseType == (long)CaseTypeEnum.Avian || c.idfsCaseType == (long)CaseTypeEnum.Veterinary);
            
      }
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as OutbreakCase) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as OutbreakCase) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "OutbreakCaseDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spOutbreak_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spOutbreak_PostCaseList";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<OutbreakCase, bool>> RequiredByField = new Dictionary<string, Func<OutbreakCase, bool>>();
            public static Dictionary<string, Func<OutbreakCase, bool>> RequiredByProperty = new Dictionary<string, Func<OutbreakCase, bool>>();
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
                Sizes.Add(_str_strCaseStatus, 2000);
                Sizes.Add(_str_strDiagnosis, 4000);
                Sizes.Add(_str_strGeoLocation, 1000);
                Sizes.Add(_str_strAddress, 1000);
                Sizes.Add(_str_strPatientName, 400);
                GridMeta.Add(new GridMetaItem(
                    _str_idfCase,
                    _str_idfCase, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseID,
                    "strCaseSessionID", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datEnteredDate,
                    "strCaseSessionDate", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSourceOfCaseSessionDate,
                    _str_strSourceOfCaseSessionDate, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseStatus,
                    "CaseStatusName", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosis,
                    "DiagnosisName", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strGeoLocation,
                    "strExposureLocation", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAddress,
                    "AddressName", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPatientName,
                    _str_strPatientName, null, false, true, true, true, true, null
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
                    (manager, c, pars) => ((OutbreakCase)c).MarkToDelete(),
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
    
        AddHiddenPersonalData("strPatientName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName));
      
        AddHiddenPersonalData("strAddress", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Details));
      
        AddHiddenPersonalData("strGeoLocation", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Details));
      
        AddHiddenPersonalData("strAddress", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Settlement));
      
        AddHiddenPersonalData("strGeoLocation", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Settlement));
      
        AddHiddenPersonalData("strGeoLocation", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("strPatientName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("strGeoLocation", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("strPatientName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      

    }
  
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class OutbreakNote : 
        EditableObject<OutbreakNote>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfOutbreakNote), NonUpdatable, PrimaryKey]
        public abstract Int64 idfOutbreakNote { get; set; }
                
        [LocalizedDisplayName(_str_idfOutbreak)]
        [MapField(_str_idfOutbreak)]
        public abstract Int64 idfOutbreak { get; set; }
        protected Int64 idfOutbreak_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfOutbreak).OriginalValue; } }
        protected Int64 idfOutbreak_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfOutbreak).PreviousValue; } }
                
        [LocalizedDisplayName("Note")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
                
        [LocalizedDisplayName("datDate")]
        [MapField(_str_datNoteDate)]
        public abstract DateTime? datNoteDate { get; set; }
        protected DateTime? datNoteDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datNoteDate).OriginalValue; } }
        protected DateTime? datNoteDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datNoteDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPerson)]
        [MapField(_str_idfPerson)]
        public abstract Int64 idfPerson { get; set; }
        protected Int64 idfPerson_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfPerson).OriginalValue; } }
        protected Int64 idfPerson_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfPerson).PreviousValue; } }
                
        [LocalizedDisplayName("CreatedName")]
        [MapField(_str_FullName)]
        public abstract String FullName { get; set; }
        protected String FullName_Original { get { return ((EditableValue<String>)((dynamic)this)._fullName).OriginalValue; } }
        protected String FullName_Previous { get { return ((EditableValue<String>)((dynamic)this)._fullName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfInstitution)]
        [MapField(_str_idfInstitution)]
        public abstract Int64? idfInstitution { get; set; }
        protected Int64? idfInstitution_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInstitution).OriginalValue; } }
        protected Int64? idfInstitution_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInstitution).PreviousValue; } }
                
        [LocalizedDisplayName("strInstitutionName")]
        [MapField(_str_strInstitution)]
        public abstract String strInstitution { get; set; }
        protected String strInstitution_Original { get { return ((EditableValue<String>)((dynamic)this)._strInstitution).OriginalValue; } }
        protected String strInstitution_Previous { get { return ((EditableValue<String>)((dynamic)this)._strInstitution).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<OutbreakNote, object> _get_func;
            internal Action<OutbreakNote, string> _set_func;
            internal Action<OutbreakNote, OutbreakNote, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfOutbreakNote = "idfOutbreakNote";
        internal const string _str_idfOutbreak = "idfOutbreak";
        internal const string _str_strNote = "strNote";
        internal const string _str_datNoteDate = "datNoteDate";
        internal const string _str_idfPerson = "idfPerson";
        internal const string _str_FullName = "FullName";
        internal const string _str_idfInstitution = "idfInstitution";
        internal const string _str_strInstitution = "strInstitution";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfOutbreakNote, _formname = _str_idfOutbreakNote, _type = "Int64",
              _get_func = o => o.idfOutbreakNote,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfOutbreakNote != newval) o.idfOutbreakNote = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfOutbreakNote != c.idfOutbreakNote || o.IsRIRPropChanged(_str_idfOutbreakNote, c)) 
                  m.Add(_str_idfOutbreakNote, o.ObjectIdent + _str_idfOutbreakNote, o.ObjectIdent2 + _str_idfOutbreakNote, o.ObjectIdent3 + _str_idfOutbreakNote, "Int64", 
                    o.idfOutbreakNote == null ? "" : o.idfOutbreakNote.ToString(),                  
                  o.IsReadOnly(_str_idfOutbreakNote), o.IsInvisible(_str_idfOutbreakNote), o.IsRequired(_str_idfOutbreakNote)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfOutbreak, _formname = _str_idfOutbreak, _type = "Int64",
              _get_func = o => o.idfOutbreak,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfOutbreak != newval) o.idfOutbreak = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfOutbreak != c.idfOutbreak || o.IsRIRPropChanged(_str_idfOutbreak, c)) 
                  m.Add(_str_idfOutbreak, o.ObjectIdent + _str_idfOutbreak, o.ObjectIdent2 + _str_idfOutbreak, o.ObjectIdent3 + _str_idfOutbreak, "Int64", 
                    o.idfOutbreak == null ? "" : o.idfOutbreak.ToString(),                  
                  o.IsReadOnly(_str_idfOutbreak), o.IsInvisible(_str_idfOutbreak), o.IsRequired(_str_idfOutbreak)); 
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
              _name = _str_datNoteDate, _formname = _str_datNoteDate, _type = "DateTime?",
              _get_func = o => o.datNoteDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datNoteDate != newval) o.datNoteDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datNoteDate != c.datNoteDate || o.IsRIRPropChanged(_str_datNoteDate, c)) 
                  m.Add(_str_datNoteDate, o.ObjectIdent + _str_datNoteDate, o.ObjectIdent2 + _str_datNoteDate, o.ObjectIdent3 + _str_datNoteDate, "DateTime?", 
                    o.datNoteDate == null ? "" : o.datNoteDate.ToString(),                  
                  o.IsReadOnly(_str_datNoteDate), o.IsInvisible(_str_datNoteDate), o.IsRequired(_str_datNoteDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPerson, _formname = _str_idfPerson, _type = "Int64",
              _get_func = o => o.idfPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfPerson != newval) o.idfPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfPerson != c.idfPerson || o.IsRIRPropChanged(_str_idfPerson, c)) 
                  m.Add(_str_idfPerson, o.ObjectIdent + _str_idfPerson, o.ObjectIdent2 + _str_idfPerson, o.ObjectIdent3 + _str_idfPerson, "Int64", 
                    o.idfPerson == null ? "" : o.idfPerson.ToString(),                  
                  o.IsReadOnly(_str_idfPerson), o.IsInvisible(_str_idfPerson), o.IsRequired(_str_idfPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_FullName, _formname = _str_FullName, _type = "String",
              _get_func = o => o.FullName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.FullName != newval) o.FullName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.FullName != c.FullName || o.IsRIRPropChanged(_str_FullName, c)) 
                  m.Add(_str_FullName, o.ObjectIdent + _str_FullName, o.ObjectIdent2 + _str_FullName, o.ObjectIdent3 + _str_FullName, "String", 
                    o.FullName == null ? "" : o.FullName.ToString(),                  
                  o.IsReadOnly(_str_FullName), o.IsInvisible(_str_FullName), o.IsRequired(_str_FullName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfInstitution, _formname = _str_idfInstitution, _type = "Int64?",
              _get_func = o => o.idfInstitution,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfInstitution != newval) o.idfInstitution = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfInstitution != c.idfInstitution || o.IsRIRPropChanged(_str_idfInstitution, c)) 
                  m.Add(_str_idfInstitution, o.ObjectIdent + _str_idfInstitution, o.ObjectIdent2 + _str_idfInstitution, o.ObjectIdent3 + _str_idfInstitution, "Int64?", 
                    o.idfInstitution == null ? "" : o.idfInstitution.ToString(),                  
                  o.IsReadOnly(_str_idfInstitution), o.IsInvisible(_str_idfInstitution), o.IsRequired(_str_idfInstitution)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strInstitution, _formname = _str_strInstitution, _type = "String",
              _get_func = o => o.strInstitution,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strInstitution != newval) o.strInstitution = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strInstitution != c.strInstitution || o.IsRIRPropChanged(_str_strInstitution, c)) 
                  m.Add(_str_strInstitution, o.ObjectIdent + _str_strInstitution, o.ObjectIdent2 + _str_strInstitution, o.ObjectIdent3 + _str_strInstitution, "String", 
                    o.strInstitution == null ? "" : o.strInstitution.ToString(),                  
                  o.IsReadOnly(_str_strInstitution), o.IsInvisible(_str_strInstitution), o.IsRequired(_str_strInstitution)); 
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
            OutbreakNote obj = (OutbreakNote)o;
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
        internal string m_ObjectName = "OutbreakNote";

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
            var ret = base.Clone() as OutbreakNote;
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
            var ret = base.Clone() as OutbreakNote;
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
        public OutbreakNote CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as OutbreakNote;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfOutbreakNote; } }
        public string KeyName { get { return "idfOutbreakNote"; } }
        public object KeyLookup { get { return idfOutbreakNote; } }
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

        private bool IsRIRPropChanged(string fld, OutbreakNote c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, OutbreakNote c)
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
        

      

        public OutbreakNote()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(OutbreakNote_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(OutbreakNote_PropertyChanged);
        }
        private void OutbreakNote_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as OutbreakNote).Changed(e.PropertyName);
            
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
            OutbreakNote obj = this;
            
        }
        private void _DeletedExtenders()
        {
            OutbreakNote obj = this;
            
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

    
        private static string[] readonly_names1 = "datNoteDate".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "FullName,strInstitution".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<OutbreakNote, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<OutbreakNote, bool>(c => true)(this);
            
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


        internal Dictionary<string, Func<OutbreakNote, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<OutbreakNote, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<OutbreakNote, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<OutbreakNote, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<OutbreakNote, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<OutbreakNote, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<OutbreakNote, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~OutbreakNote()
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
        public class OutbreakNoteGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfOutbreakNote { get; set; }
        
            public String strNote { get; set; }
        
            public DateTimeWrap datNoteDate { get; set; }
        
            public String FullName { get; set; }
        
            public String strInstitution { get; set; }
        
        }
        public partial class OutbreakNoteGridModelList : List<OutbreakNoteGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public OutbreakNoteGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<OutbreakNote>, errMes);
            }
            public OutbreakNoteGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<OutbreakNote>, errMes);
            }
            public OutbreakNoteGridModelList(long key, IEnumerable<OutbreakNote> items)
            {
                LoadGridModelList(key, items, null);
            }
            public OutbreakNoteGridModelList(long key)
            {
                LoadGridModelList(key, new List<OutbreakNote>(), null);
            }
            partial void filter(List<OutbreakNote> items);
            private void LoadGridModelList(long key, IEnumerable<OutbreakNote> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strNote,_str_datNoteDate,_str_FullName,_str_strInstitution};
                    
                Hiddens = new List<string> {_str_idfOutbreakNote};
                Keys = new List<string> {_str_idfOutbreakNote};
                Labels = new Dictionary<string, string> {{_str_strNote, "Note"},{_str_datNoteDate, "datDate"},{_str_FullName, "CreatedName"},{_str_strInstitution, "strInstitutionName"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                OutbreakNote.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<OutbreakNote>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new OutbreakNoteGridModel()
                {
                    ItemKey=c.idfOutbreakNote,strNote=c.strNote,datNoteDate=c.datNoteDate,FullName=c.FullName,strInstitution=c.strInstitution
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
        : DataAccessor<OutbreakNote>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<OutbreakNote>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfOutbreakNote"; } }
            #endregion
        
            public delegate void on_action(OutbreakNote obj);
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
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<OutbreakNote> SelectList(DbManagerProxy manager
                , Int64? OutbreakID
                )
            {
                return _SelectList(manager
                    , OutbreakID
                    , delegate(OutbreakNote obj)
                        {
                        }
                    , delegate(OutbreakNote obj)
                        {
                        }
                    );
            }

            

            public List<OutbreakNote> _SelectList(DbManagerProxy manager
                , Int64? OutbreakID
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , OutbreakID
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<OutbreakNote> _SelectListInternal(DbManagerProxy manager
                , Int64? OutbreakID
                , on_action loading, on_action loaded
                )
            {
                OutbreakNote _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<OutbreakNote> objs = new List<OutbreakNote>();
                    sets[0] = new MapResultSet(typeof(OutbreakNote), objs);
                    
                    manager
                        .SetSpCommand("spOutbreak_SelectDetail"
                            , manager.Parameter("@OutbreakID", OutbreakID)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, OutbreakNote obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, OutbreakNote obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private OutbreakNote _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                OutbreakNote obj = null;
                try
                {
                    obj = OutbreakNote.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfOutbreakNote = (new GetNewIDExtender<OutbreakNote>()).GetScalar(manager, obj, isFake);
                obj.idfOutbreak = new Func<OutbreakNote, long>(c => (Parent as Outbreak).idfOutbreak)(obj);
                obj.datNoteDate = new Func<OutbreakNote, DateTime?>(c => DateTime.Now)(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.idfPerson = new Func<OutbreakNote, long>(c => (long)EidssUserContext.User.EmployeeID)(obj);
                obj.FullName = new Func<OutbreakNote, string>(c => EidssUserContext.User.FullName)(obj);
                obj.idfInstitution = new Func<OutbreakNote, long>(c => (long)EidssUserContext.User.OrganizationID)(obj);
                obj.strInstitution = new Func<OutbreakNote, string>(c => OrganizationLookup.OrganizationNational)(obj);
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

            
            public OutbreakNote CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public OutbreakNote CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public OutbreakNote CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(OutbreakNote obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(OutbreakNote obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, OutbreakNote obj)
            {
                
            }
    
            [SprocName("spOutbreak_PostNotes")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfOutbreakNote")] OutbreakNote obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfOutbreakNote")] OutbreakNote obj)
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
                        OutbreakNote bo = obj as OutbreakNote;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as OutbreakNote, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, OutbreakNote obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(OutbreakNote obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, OutbreakNote obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(OutbreakNote obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(OutbreakNote obj, bool bRethrowException)
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
                return Validate(manager, obj as OutbreakNote, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, OutbreakNote obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(OutbreakNote obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(OutbreakNote obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as OutbreakNote) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as OutbreakNote) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "OutbreakNoteDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spOutbreak_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spOutbreak_PostNotes";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<OutbreakNote, bool>> RequiredByField = new Dictionary<string, Func<OutbreakNote, bool>>();
            public static Dictionary<string, Func<OutbreakNote, bool>> RequiredByProperty = new Dictionary<string, Func<OutbreakNote, bool>>();
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
                
                Sizes.Add(_str_strNote, 2000);
                Sizes.Add(_str_FullName, 400);
                Sizes.Add(_str_strInstitution, 2000);
                GridMeta.Add(new GridMetaItem(
                    _str_idfOutbreakNote,
                    _str_idfOutbreakNote, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNote,
                    "Note", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datNoteDate,
                    "datDate", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_FullName,
                    "CreatedName", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strInstitution,
                    "strInstitutionName", null, false, true, true, true, true, null
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
                    (manager, c, pars) => ((OutbreakNote)c).MarkToDelete(),
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
	