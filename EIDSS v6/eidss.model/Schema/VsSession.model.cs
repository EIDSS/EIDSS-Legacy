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
    public abstract partial class VsSession : 
        EditableObject<VsSession>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfVectorSurveillanceSession), NonUpdatable, PrimaryKey]
        public abstract Int64 idfVectorSurveillanceSession { get; set; }
                
        [LocalizedDisplayName(_str_strSessionID)]
        [MapField(_str_strSessionID)]
        public abstract String strSessionID { get; set; }
        protected String strSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strSessionID).OriginalValue; } }
        protected String strSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSessionID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFieldSessionID)]
        [MapField(_str_strFieldSessionID)]
        public abstract String strFieldSessionID { get; set; }
        protected String strFieldSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldSessionID).OriginalValue; } }
        protected String strFieldSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldSessionID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsVectorSurveillanceStatus)]
        [MapField(_str_idfsVectorSurveillanceStatus)]
        public abstract Int64 idfsVectorSurveillanceStatus { get; set; }
        protected Int64 idfsVectorSurveillanceStatus_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSurveillanceStatus).OriginalValue; } }
        protected Int64 idfsVectorSurveillanceStatus_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSurveillanceStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStartDate)]
        [MapField(_str_datStartDate)]
        public abstract DateTime datStartDate { get; set; }
        protected DateTime datStartDate_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime datStartDate_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datStartDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datCloseDate)]
        [MapField(_str_datCloseDate)]
        public abstract DateTime? datCloseDate { get; set; }
        protected DateTime? datCloseDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCloseDate).OriginalValue; } }
        protected DateTime? datCloseDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCloseDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfLocation)]
        [MapField(_str_idfLocation)]
        public abstract Int64? idfLocation { get; set; }
        protected Int64? idfLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).OriginalValue; } }
        protected Int64? idfLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfOutbreak)]
        [MapField(_str_idfOutbreak)]
        public abstract Int64? idfOutbreak { get; set; }
        protected Int64? idfOutbreak_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOutbreak).OriginalValue; } }
        protected Int64? idfOutbreak_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOutbreak).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDescription)]
        [MapField(_str_strDescription)]
        public abstract String strDescription { get; set; }
        protected String strDescription_Original { get { return ((EditableValue<String>)((dynamic)this)._strDescription).OriginalValue; } }
        protected String strDescription_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDescription).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64 idfsSite { get; set; }
        protected Int64 idfsSite_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64 idfsSite_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOutbreakID)]
        [MapField(_str_strOutbreakID)]
        public abstract String strOutbreakID { get; set; }
        protected String strOutbreakID_Original { get { return ((EditableValue<String>)((dynamic)this)._strOutbreakID).OriginalValue; } }
        protected String strOutbreakID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOutbreakID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intCollectionEffort)]
        [MapField(_str_intCollectionEffort)]
        public abstract Int32? intCollectionEffort { get; set; }
        protected Int32? intCollectionEffort_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intCollectionEffort).OriginalValue; } }
        protected Int32? intCollectionEffort_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intCollectionEffort).PreviousValue; } }
                
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
            internal Func<VsSession, object> _get_func;
            internal Action<VsSession, string> _set_func;
            internal Action<VsSession, VsSession, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_strSessionID = "strSessionID";
        internal const string _str_strFieldSessionID = "strFieldSessionID";
        internal const string _str_idfsVectorSurveillanceStatus = "idfsVectorSurveillanceStatus";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_datCloseDate = "datCloseDate";
        internal const string _str_idfLocation = "idfLocation";
        internal const string _str_idfOutbreak = "idfOutbreak";
        internal const string _str_strDescription = "strDescription";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_strOutbreakID = "strOutbreakID";
        internal const string _str_intCollectionEffort = "intCollectionEffort";
        internal const string _str_datModificationForArchiveDate = "datModificationForArchiveDate";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_strVectorsCalculated = "strVectorsCalculated";
        internal const string _str_strDiagnosesCalculated = "strDiagnosesCalculated";
        internal const string _str_IsClosed = "IsClosed";
        internal const string _str_Samples = "Samples";
        internal const string _str_FieldTests = "FieldTests";
        internal const string _str_LabTests = "LabTests";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_VsStatus = "VsStatus";
        internal const string _str_Diagnoses = "Diagnoses";
        internal const string _str_DiagnosisList = "DiagnosisList";
        internal const string _str_Vectors = "Vectors";
        internal const string _str_Summaries = "Summaries";
        internal const string _str_Location = "Location";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _formname = _str_idfVectorSurveillanceSession, _type = "Int64",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVectorSurveillanceSession != newval) o.idfVectorSurveillanceSession = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, o.ObjectIdent2 + _str_idfVectorSurveillanceSession, o.ObjectIdent3 + _str_idfVectorSurveillanceSession, "Int64", 
                    o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(),                  
                  o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSessionID, _formname = _str_strSessionID, _type = "String",
              _get_func = o => o.strSessionID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSessionID != newval) o.strSessionID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSessionID != c.strSessionID || o.IsRIRPropChanged(_str_strSessionID, c)) 
                  m.Add(_str_strSessionID, o.ObjectIdent + _str_strSessionID, o.ObjectIdent2 + _str_strSessionID, o.ObjectIdent3 + _str_strSessionID, "String", 
                    o.strSessionID == null ? "" : o.strSessionID.ToString(),                  
                  o.IsReadOnly(_str_strSessionID), o.IsInvisible(_str_strSessionID), o.IsRequired(_str_strSessionID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFieldSessionID, _formname = _str_strFieldSessionID, _type = "String",
              _get_func = o => o.strFieldSessionID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldSessionID != newval) o.strFieldSessionID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFieldSessionID != c.strFieldSessionID || o.IsRIRPropChanged(_str_strFieldSessionID, c)) 
                  m.Add(_str_strFieldSessionID, o.ObjectIdent + _str_strFieldSessionID, o.ObjectIdent2 + _str_strFieldSessionID, o.ObjectIdent3 + _str_strFieldSessionID, "String", 
                    o.strFieldSessionID == null ? "" : o.strFieldSessionID.ToString(),                  
                  o.IsReadOnly(_str_strFieldSessionID), o.IsInvisible(_str_strFieldSessionID), o.IsRequired(_str_strFieldSessionID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsVectorSurveillanceStatus, _formname = _str_idfsVectorSurveillanceStatus, _type = "Int64",
              _get_func = o => o.idfsVectorSurveillanceStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsVectorSurveillanceStatus != newval) 
                  o.VsStatus = o.VsStatusLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsVectorSurveillanceStatus != newval) o.idfsVectorSurveillanceStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorSurveillanceStatus != c.idfsVectorSurveillanceStatus || o.IsRIRPropChanged(_str_idfsVectorSurveillanceStatus, c)) 
                  m.Add(_str_idfsVectorSurveillanceStatus, o.ObjectIdent + _str_idfsVectorSurveillanceStatus, o.ObjectIdent2 + _str_idfsVectorSurveillanceStatus, o.ObjectIdent3 + _str_idfsVectorSurveillanceStatus, "Int64", 
                    o.idfsVectorSurveillanceStatus == null ? "" : o.idfsVectorSurveillanceStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsVectorSurveillanceStatus), o.IsInvisible(_str_idfsVectorSurveillanceStatus), o.IsRequired(_str_idfsVectorSurveillanceStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datStartDate, _formname = _str_datStartDate, _type = "DateTime",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTime(val); if (o.datStartDate != newval) o.datStartDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, o.ObjectIdent2 + _str_datStartDate, o.ObjectIdent3 + _str_datStartDate, "DateTime", 
                    o.datStartDate == null ? "" : o.datStartDate.ToString(),                  
                  o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datCloseDate, _formname = _str_datCloseDate, _type = "DateTime?",
              _get_func = o => o.datCloseDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datCloseDate != newval) o.datCloseDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datCloseDate != c.datCloseDate || o.IsRIRPropChanged(_str_datCloseDate, c)) 
                  m.Add(_str_datCloseDate, o.ObjectIdent + _str_datCloseDate, o.ObjectIdent2 + _str_datCloseDate, o.ObjectIdent3 + _str_datCloseDate, "DateTime?", 
                    o.datCloseDate == null ? "" : o.datCloseDate.ToString(),                  
                  o.IsReadOnly(_str_datCloseDate), o.IsInvisible(_str_datCloseDate), o.IsRequired(_str_datCloseDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfLocation, _formname = _str_idfLocation, _type = "Int64?",
              _get_func = o => o.idfLocation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfLocation != newval) o.idfLocation = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfLocation != c.idfLocation || o.IsRIRPropChanged(_str_idfLocation, c)) 
                  m.Add(_str_idfLocation, o.ObjectIdent + _str_idfLocation, o.ObjectIdent2 + _str_idfLocation, o.ObjectIdent3 + _str_idfLocation, "Int64?", 
                    o.idfLocation == null ? "" : o.idfLocation.ToString(),                  
                  o.IsReadOnly(_str_idfLocation), o.IsInvisible(_str_idfLocation), o.IsRequired(_str_idfLocation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfOutbreak, _formname = _str_idfOutbreak, _type = "Int64?",
              _get_func = o => o.idfOutbreak,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfOutbreak != newval) o.idfOutbreak = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfOutbreak != c.idfOutbreak || o.IsRIRPropChanged(_str_idfOutbreak, c)) 
                  m.Add(_str_idfOutbreak, o.ObjectIdent + _str_idfOutbreak, o.ObjectIdent2 + _str_idfOutbreak, o.ObjectIdent3 + _str_idfOutbreak, "Int64?", 
                    o.idfOutbreak == null ? "" : o.idfOutbreak.ToString(),                  
                  o.IsReadOnly(_str_idfOutbreak), o.IsInvisible(_str_idfOutbreak), o.IsRequired(_str_idfOutbreak)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDescription, _formname = _str_strDescription, _type = "String",
              _get_func = o => o.strDescription,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDescription != newval) o.strDescription = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDescription != c.strDescription || o.IsRIRPropChanged(_str_strDescription, c)) 
                  m.Add(_str_strDescription, o.ObjectIdent + _str_strDescription, o.ObjectIdent2 + _str_strDescription, o.ObjectIdent3 + _str_strDescription, "String", 
                    o.strDescription == null ? "" : o.strDescription.ToString(),                  
                  o.IsReadOnly(_str_strDescription), o.IsInvisible(_str_strDescription), o.IsRequired(_str_strDescription)); 
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
              _name = _str_strOutbreakID, _formname = _str_strOutbreakID, _type = "String",
              _get_func = o => o.strOutbreakID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOutbreakID != newval) o.strOutbreakID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strOutbreakID != c.strOutbreakID || o.IsRIRPropChanged(_str_strOutbreakID, c)) 
                  m.Add(_str_strOutbreakID, o.ObjectIdent + _str_strOutbreakID, o.ObjectIdent2 + _str_strOutbreakID, o.ObjectIdent3 + _str_strOutbreakID, "String", 
                    o.strOutbreakID == null ? "" : o.strOutbreakID.ToString(),                  
                  o.IsReadOnly(_str_strOutbreakID), o.IsInvisible(_str_strOutbreakID), o.IsRequired(_str_strOutbreakID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intCollectionEffort, _formname = _str_intCollectionEffort, _type = "Int32?",
              _get_func = o => o.intCollectionEffort,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intCollectionEffort != newval) o.intCollectionEffort = newval; },
              _compare_func = (o, c, m) => {
                if (o.intCollectionEffort != c.intCollectionEffort || o.IsRIRPropChanged(_str_intCollectionEffort, c)) 
                  m.Add(_str_intCollectionEffort, o.ObjectIdent + _str_intCollectionEffort, o.ObjectIdent2 + _str_intCollectionEffort, o.ObjectIdent3 + _str_intCollectionEffort, "Int32?", 
                    o.intCollectionEffort == null ? "" : o.intCollectionEffort.ToString(),                  
                  o.IsReadOnly(_str_intCollectionEffort), o.IsInvisible(_str_intCollectionEffort), o.IsRequired(_str_intCollectionEffort)); 
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
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "long?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) {
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis,  "long?", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                    o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_strVectorsCalculated, _formname = _str_strVectorsCalculated, _type = "string",
              _get_func = o => o.strVectorsCalculated,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strVectorsCalculated != c.strVectorsCalculated || o.IsRIRPropChanged(_str_strVectorsCalculated, c)) {
                  m.Add(_str_strVectorsCalculated, o.ObjectIdent + _str_strVectorsCalculated, o.ObjectIdent2 + _str_strVectorsCalculated, o.ObjectIdent3 + _str_strVectorsCalculated, "string", o.strVectorsCalculated == null ? "" : o.strVectorsCalculated.ToString(), o.IsReadOnly(_str_strVectorsCalculated), o.IsInvisible(_str_strVectorsCalculated), o.IsRequired(_str_strVectorsCalculated));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strDiagnosesCalculated, _formname = _str_strDiagnosesCalculated, _type = "string",
              _get_func = o => o.strDiagnosesCalculated,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strDiagnosesCalculated != c.strDiagnosesCalculated || o.IsRIRPropChanged(_str_strDiagnosesCalculated, c)) {
                  m.Add(_str_strDiagnosesCalculated, o.ObjectIdent + _str_strDiagnosesCalculated, o.ObjectIdent2 + _str_strDiagnosesCalculated, o.ObjectIdent3 + _str_strDiagnosesCalculated, "string", o.strDiagnosesCalculated == null ? "" : o.strDiagnosesCalculated.ToString(), o.IsReadOnly(_str_strDiagnosesCalculated), o.IsInvisible(_str_strDiagnosesCalculated), o.IsRequired(_str_strDiagnosesCalculated));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_IsClosed, _formname = _str_IsClosed, _type = "bool",
              _get_func = o => o.IsClosed,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.IsClosed != c.IsClosed || o.IsRIRPropChanged(_str_IsClosed, c)) {
                  m.Add(_str_IsClosed, o.ObjectIdent + _str_IsClosed, o.ObjectIdent2 + _str_IsClosed, o.ObjectIdent3 + _str_IsClosed, "bool", o.IsClosed == null ? "" : o.IsClosed.ToString(), o.IsReadOnly(_str_IsClosed), o.IsInvisible(_str_IsClosed), o.IsRequired(_str_IsClosed));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Samples, _formname = _str_Samples, _type = "EditableList<VectorSample>",
              _get_func = o => o.Samples,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_FieldTests, _formname = _str_FieldTests, _type = "EditableList<VectorFieldTest>",
              _get_func = o => o.FieldTests,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_LabTests, _formname = _str_LabTests, _type = "EditableList<VectorLabTest>",
              _get_func = o => o.LabTests,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_CaseObjectIdent, _formname = _str_CaseObjectIdent, _type = "string",
              _get_func = o => o.CaseObjectIdent,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.CaseObjectIdent != c.CaseObjectIdent || o.IsRIRPropChanged(_str_CaseObjectIdent, c)) {
                  m.Add(_str_CaseObjectIdent, o.ObjectIdent + _str_CaseObjectIdent, o.ObjectIdent2 + _str_CaseObjectIdent, o.ObjectIdent3 + _str_CaseObjectIdent, "string", o.CaseObjectIdent == null ? "" : o.CaseObjectIdent.ToString(), o.IsReadOnly(_str_CaseObjectIdent), o.IsInvisible(_str_CaseObjectIdent), o.IsRequired(_str_CaseObjectIdent));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_VsStatus, _formname = _str_VsStatus, _type = "Lookup",
              _get_func = o => { if (o.VsStatus == null) return null; return o.VsStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.VsStatus = o.VsStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorSurveillanceStatus != c.idfsVectorSurveillanceStatus || o.IsRIRPropChanged(_str_VsStatus, c)) {
                  m.Add(_str_VsStatus, o.ObjectIdent + _str_VsStatus, o.ObjectIdent2 + _str_VsStatus, o.ObjectIdent3 + _str_VsStatus, "Lookup", o.idfsVectorSurveillanceStatus == null ? "" : o.idfsVectorSurveillanceStatus.ToString(), o.IsReadOnly(_str_VsStatus), o.IsInvisible(_str_VsStatus), o.IsRequired(_str_VsStatus)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_VsStatus + "Lookup", _formname = _str_VsStatus + "Lookup", _type = "LookupContent",
              _get_func = o => o.VsStatusLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Diagnoses, _formname = _str_Diagnoses, _type = "Lookup",
              _get_func = o => { if (o.Diagnoses == null) return null; return o.Diagnoses.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnoses = o.DiagnosesLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnoses, c)) {
                  m.Add(_str_Diagnoses, o.ObjectIdent + _str_Diagnoses, o.ObjectIdent2 + _str_Diagnoses, o.ObjectIdent3 + _str_Diagnoses, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnoses), o.IsInvisible(_str_Diagnoses), o.IsRequired(_str_Diagnoses)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Diagnoses + "Lookup", _formname = _str_Diagnoses + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosesLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_DiagnosisList, _formname = _str_DiagnosisList, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.DiagnosisList.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.DiagnosisList.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.DiagnosisList.Count != c.DiagnosisList.Count || o.IsReadOnly(_str_DiagnosisList) != c.IsReadOnly(_str_DiagnosisList) || o.IsInvisible(_str_DiagnosisList) != c.IsInvisible(_str_DiagnosisList) || o.IsRequired(_str_DiagnosisList) != c._isRequired(o.m_isRequired, _str_DiagnosisList)) {
                  m.Add(_str_DiagnosisList, o.ObjectIdent + _str_DiagnosisList, o.ObjectIdent2 + _str_DiagnosisList, o.ObjectIdent3 + _str_DiagnosisList, "Child", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_DiagnosisList), o.IsInvisible(_str_DiagnosisList), o.IsRequired(_str_DiagnosisList)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Vectors, _formname = _str_Vectors, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Vectors.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Vectors.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.Vectors.Count != c.Vectors.Count || o.IsReadOnly(_str_Vectors) != c.IsReadOnly(_str_Vectors) || o.IsInvisible(_str_Vectors) != c.IsInvisible(_str_Vectors) || o.IsRequired(_str_Vectors) != c._isRequired(o.m_isRequired, _str_Vectors)) {
                  m.Add(_str_Vectors, o.ObjectIdent + _str_Vectors, o.ObjectIdent2 + _str_Vectors, o.ObjectIdent3 + _str_Vectors, "Child", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_Vectors), o.IsInvisible(_str_Vectors), o.IsRequired(_str_Vectors)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Summaries, _formname = _str_Summaries, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Summaries.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Summaries.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.Summaries.Count != c.Summaries.Count || o.IsReadOnly(_str_Summaries) != c.IsReadOnly(_str_Summaries) || o.IsInvisible(_str_Summaries) != c.IsInvisible(_str_Summaries) || o.IsRequired(_str_Summaries) != c._isRequired(o.m_isRequired, _str_Summaries)) {
                  m.Add(_str_Summaries, o.ObjectIdent + _str_Summaries, o.ObjectIdent2 + _str_Summaries, o.ObjectIdent3 + _str_Summaries, "Child", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_Summaries), o.IsInvisible(_str_Summaries), o.IsRequired(_str_Summaries)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Location, _formname = _str_Location, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
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
            VsSession obj = (VsSession)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_DiagnosisList)]
        [Relation(typeof(DiagnosisItem), eidss.model.Schema.DiagnosisItem._str_idfVectorSurveillanceSession, _str_idfVectorSurveillanceSession)]
        public EditableList<DiagnosisItem> DiagnosisList
        {
            get 
            {   
                return _DiagnosisList; 
            }
            set 
            {
                _DiagnosisList = value;
            }
        }
        protected EditableList<DiagnosisItem> _DiagnosisList = new EditableList<DiagnosisItem>();
                    
        [LocalizedDisplayName(_str_Vectors)]
        [Relation(typeof(Vector), eidss.model.Schema.Vector._str_idfVectorSurveillanceSession, _str_idfVectorSurveillanceSession)]
        public EditableList<Vector> Vectors
        {
            get 
            {   
                return _Vectors; 
            }
            set 
            {
                _Vectors = value;
            }
        }
        protected EditableList<Vector> _Vectors = new EditableList<Vector>();
                    
        [LocalizedDisplayName(_str_Summaries)]
        [Relation(typeof(VsSessionSummary), eidss.model.Schema.VsSessionSummary._str_idfVectorSurveillanceSession, _str_idfVectorSurveillanceSession)]
        public EditableList<VsSessionSummary> Summaries
        {
            get 
            {   
                return _Summaries; 
            }
            set 
            {
                _Summaries = value;
            }
        }
        protected EditableList<VsSessionSummary> _Summaries = new EditableList<VsSessionSummary>();
                    
        [LocalizedDisplayName("LocationDisplayName")]
        [Relation(typeof(GeoLocation), eidss.model.Schema.GeoLocation._str_idfGeoLocation, _str_idfLocation)]
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
                idfLocation = _Location == null 
                        ? new Int64?()
                        : _Location.idfGeoLocation;
                
            }
        }
        protected GeoLocation _Location;
                    
        [LocalizedDisplayName(_str_VsStatus)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsVectorSurveillanceStatus)]
        public BaseReference VsStatus
        {
            get { return _VsStatus; }
            set 
            { 
                var oldVal = _VsStatus;
                _VsStatus = value;
                if (_VsStatus != oldVal)
                {
                    if (idfsVectorSurveillanceStatus != (_VsStatus == null
                            ? new Int64()
                            : (Int64)_VsStatus.idfsBaseReference))
                        idfsVectorSurveillanceStatus = _VsStatus == null 
                            ? new Int64()
                            : (Int64)_VsStatus.idfsBaseReference; 
                    OnPropertyChanged(_str_VsStatus); 
                }
            }
        }
        private BaseReference _VsStatus;

        
        public BaseReferenceList VsStatusLookup
        {
            get { return _VsStatusLookup; }
        }
        private BaseReferenceList _VsStatusLookup = new BaseReferenceList("rftVectorSurveillanceSessionStatus");
            
        [LocalizedDisplayName(_str_Diagnoses)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnoses
        {
            get { return _Diagnoses == null ? null : ((long)_Diagnoses.Key == 0 ? null : _Diagnoses); }
            set 
            { 
                var oldVal = _Diagnoses;
                _Diagnoses = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Diagnoses != oldVal)
                {
                    if (idfsDiagnosis != (_Diagnoses == null
                            ? new long?()
                            : _Diagnoses.idfsDiagnosis))
                        idfsDiagnosis = _Diagnoses == null 
                            ? new long?()
                            : _Diagnoses.idfsDiagnosis; 
                    OnPropertyChanged(_str_Diagnoses); 
                }
            }
        }
        private DiagnosisLookup _Diagnoses;

        
        public List<DiagnosisLookup> DiagnosesLookup
        {
            get { return _DiagnosesLookup; }
        }
        private List<DiagnosisLookup> _DiagnosesLookup = new List<DiagnosisLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_VsStatus:
                    return new BvSelectList(VsStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, VsStatus, _str_idfsVectorSurveillanceStatus);
            
                case _str_Diagnoses:
                    return new BvSelectList(DiagnosesLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnoses, _str_idfsDiagnosis);
            
                case _str_DiagnosisList:
                    return new BvSelectList(DiagnosisList, "", "", null, "");
            
                case _str_Vectors:
                    return new BvSelectList(Vectors, "", "", null, "");
            
                case _str_Summaries:
                    return new BvSelectList(Summaries, "", "", null, "");
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strVectorsCalculated)]
        public string strVectorsCalculated
        {
            get { return new Func<VsSession, string>(c => c.GetVestorsNames())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strDiagnosesCalculated)]
        public string strDiagnosesCalculated
        {
            get { return new Func<VsSession, string>(c => c.GetDiagnosesNames())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsClosed)]
        public bool IsClosed
        {
            get { return new Func<VsSession, bool>(c => (c.idfsVectorSurveillanceStatus == (long)VsStatusEnum.Closed) )(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Samples)]
        public EditableList<VectorSample> Samples
        {
            get { return new Func<VsSession, EditableList<VectorSample>>(c => {var list = new EditableList<VectorSample>();foreach (var vector in Vectors){list.AddRange(vector.Samples);}return list;})(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_FieldTests)]
        public EditableList<VectorFieldTest> FieldTests
        {
            get { return new Func<VsSession, EditableList<VectorFieldTest>>(c => {var list = new EditableList<VectorFieldTest>();foreach (var vector in Vectors){list.AddRange(vector.FieldTests);}return list;})(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_LabTests)]
        public EditableList<VectorLabTest> LabTests
        {
            get { return new Func<VsSession, EditableList<VectorLabTest>>(c => {var list = new EditableList<VectorLabTest>();foreach (var vector in Vectors){list.AddRange(vector.LabTests);}return list;})(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<VsSession, string>(c => "Vectors_" + c.idfVectorSurveillanceSession + "_")(this); }
            
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
        internal string m_ObjectName = "VsSession";

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
        DiagnosisList.ForEach(c => { c.Parent = this; });
                Vectors.ForEach(c => { c.Parent = this; });
                Summaries.ForEach(c => { c.Parent = this; });
                
            if (_Location != null) { _Location.Parent = this; }
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as VsSession;
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
            var ret = base.Clone() as VsSession;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_DiagnosisList != null && _DiagnosisList.Count > 0)
            {
              ret.DiagnosisList.Clear();
              _DiagnosisList.ForEach(c => ret.DiagnosisList.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_Vectors != null && _Vectors.Count > 0)
            {
              ret.Vectors.Clear();
              _Vectors.ForEach(c => ret.Vectors.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_Summaries != null && _Summaries.Count > 0)
            {
              ret.Summaries.Clear();
              _Summaries.ForEach(c => ret.Summaries.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_Location != null)
              ret.Location = _Location.CloneWithSetup(manager, bRestricted) as GeoLocation;
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public VsSession CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VsSession;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfVectorSurveillanceSession; } }
        public string KeyName { get { return "idfVectorSurveillanceSession"; } }
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
        
                    || DiagnosisList.IsDirty
                    || DiagnosisList.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Vectors.IsDirty
                    || Vectors.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Summaries.IsDirty
                    || Summaries.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || (_Location != null && _Location.HasChanges)
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsVectorSurveillanceStatus_VsStatus = idfsVectorSurveillanceStatus;
            var _prev_idfsDiagnosis_Diagnoses = idfsDiagnosis;
            base.RejectChanges();
        
            if (_prev_idfsVectorSurveillanceStatus_VsStatus != idfsVectorSurveillanceStatus)
            {
                _VsStatus = _VsStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorSurveillanceStatus);
            }
            if (_prev_idfsDiagnosis_Diagnoses != idfsDiagnosis)
            {
                _Diagnoses = _DiagnosesLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        DiagnosisList.DeepRejectChanges();
                Vectors.DeepRejectChanges();
                Summaries.DeepRejectChanges();
                
            if (Location != null) Location.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        DiagnosisList.DeepAcceptChanges();
                Vectors.DeepAcceptChanges();
                Summaries.DeepAcceptChanges();
                
            if (_Location != null) _Location.DeepAcceptChanges();
                
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
        DiagnosisList.ForEach(c => c.SetChange());
                Vectors.ForEach(c => c.SetChange());
                Summaries.ForEach(c => c.SetChange());
                
            if (_Location != null) _Location.SetChange();
                
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

        private bool IsRIRPropChanged(string fld, VsSession c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public VsSession()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VsSession_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VsSession_PropertyChanged);
        }
        private void VsSession_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VsSession).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Vectors)
                OnPropertyChanged(_str_strVectorsCalculated);
                  
            if (e.PropertyName == _str_DiagnosisList)
                OnPropertyChanged(_str_strDiagnosesCalculated);
                  
            if (e.PropertyName == _str_idfsVectorSurveillanceStatus)
                OnPropertyChanged(_str_IsClosed);
                  
            if (e.PropertyName == _str_Vectors)
                OnPropertyChanged(_str_Samples);
                  
            if (e.PropertyName == _str_Vectors)
                OnPropertyChanged(_str_FieldTests);
                  
            if (e.PropertyName == _str_Vectors)
                OnPropertyChanged(_str_LabTests);
                  
            if (e.PropertyName == _str_idfVectorSurveillanceSession)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
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
            VsSession obj = this;
            try
            {
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, v => v.Samples.Where(s => !s.IsMarkedToDelete).Count() == 0
                    );
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, v => v.Vectors.Where(s => !s.IsMarkedToDelete).Count() == 0
                    );
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, v => v.FieldTests.Where(ft => ft.idfsPensideTestResult != null).Count() == 0
                    );
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, v => !v.IsClosed
                    );
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, v => v.idfOutbreak == null || v.idfOutbreak == 0
                    );
            
            }
            catch(ValidationModelException ex)
            {
                if (bReport && !OnValidation(ex))
                {
                    OnValidationEnd(ex);
                }
                
                return false;
            }
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            VsSession obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VsSession obj = this;
            
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

    
        private static string[] readonly_names1 = "strSessionID,strVectorsCalculated,strDiagnosesCalculated,intSummaryQuantity,intSummaryCollectionEffort,datSummaryCollectionFrom,datSummaryCollectionTo,datCloseDate".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "VsStatus".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "Vectors,Summaries,DiagnosisList,Location".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VsSession, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VsSession, bool>(c => c.ReadOnly)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VsSession, bool>(c => c.IsClosed || c.ReadOnly)(this);
            
            return ReadOnly || new Func<VsSession, bool>(c => c.ReadOnly || c.IsClosed)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _DiagnosisList)
                    o.ReadOnly |= value;
                
                foreach(var o in _Vectors)
                    o.ReadOnly |= value;
                
                foreach(var o in _Summaries)
                    o.ReadOnly |= value;
                
                if (_Location != null)
                    _Location.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<VsSession, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VsSession, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VsSession, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VsSession, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VsSession, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<VsSession, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<VsSession, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VsSession()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                if (_Location != null)
                    Location.Dispose();
                DiagnosisList.ForEach(c => c.Dispose());
                Vectors.ForEach(c => c.Dispose());
                Summaries.ForEach(c => c.Dispose());
                
                LookupManager.RemoveObject("rftVectorSurveillanceSessionStatus", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftVectorSurveillanceSessionStatus")
                _getAccessor().LoadLookup_VsStatus(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnoses(manager, this);
            
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
        
            if (_DiagnosisList != null) _DiagnosisList.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Vectors != null) _Vectors.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Summaries != null) _Summaries.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Location != null) _Location.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<VsSession>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<VsSession>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<VsSession>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfVectorSurveillanceSession"; } }
            #endregion
        
            private delegate void on_action(VsSession obj);
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
            private DiagnosisItem.Accessor DiagnosisListAccessor { get { return eidss.model.Schema.DiagnosisItem.Accessor.Instance(m_CS); } }
            private Vector.Accessor VectorsAccessor { get { return eidss.model.Schema.Vector.Accessor.Instance(m_CS); } }
            private VsSessionSummary.Accessor SummariesAccessor { get { return eidss.model.Schema.VsSessionSummary.Accessor.Instance(m_CS); } }
            private GeoLocation.Accessor LocationAccessor { get { return eidss.model.Schema.GeoLocation.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor VsStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor DiagnosesAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            

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
            public virtual VsSession SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
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

            
            public virtual VsSession SelectByKey(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                )
            {
                return _SelectByKey(manager
                    , idfVectorSurveillanceSession
                    , null, null
                    );
            }
            
      
            private VsSession _SelectByKey(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[2];
                List<VsSession> objs = new List<VsSession>();
                sets[0] = new MapResultSet(typeof(VsSession), objs);
                
                List<DiagnosisItem> objs_DiagnosisItem = new List<DiagnosisItem>();
                sets[1] = new MapResultSet(typeof(DiagnosisItem), objs_DiagnosisItem);
                
        
                try
                {
                    manager
                        .SetSpCommand("spVsSession_SelectDetail"
                            , manager.Parameter("@idfVectorSurveillanceSession", idfVectorSurveillanceSession)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    VsSession obj = objs[0];
                    obj.m_CS = m_CS;
                    
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    
                    obj.DiagnosisList.ForEach(c => DiagnosisListAccessor._SetupLoad(manager, c));
                        
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
    
            private void _SetupAddChildHandlerDiagnosisList(VsSession obj)
            {
                obj.DiagnosisList.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerVectors(VsSession obj)
            {
                obj.Vectors.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerSummaries(VsSession obj)
            {
                obj.Summaries.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadVectors(VsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadVectors(manager, obj);
                }
            }
            internal void _LoadVectors(DbManagerProxy manager, VsSession obj)
            {
                
                obj.Vectors.Clear();
                obj.Vectors.AddRange(VectorsAccessor.SelectDetailList(manager
                    
                    , obj.idfVectorSurveillanceSession
                    ));
                obj.Vectors.ForEach(c => c.m_ObjectName = _str_Vectors);
                obj.Vectors.AcceptChanges();
                    
            }
            
            internal void _LoadSummaries(VsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSummaries(manager, obj);
                }
            }
            internal void _LoadSummaries(DbManagerProxy manager, VsSession obj)
            {
                
                obj.Summaries.Clear();
                obj.Summaries.AddRange(SummariesAccessor.SelectDetailList(manager
                    
                    , obj.idfVectorSurveillanceSession
                    ));
                obj.Summaries.ForEach(c => c.m_ObjectName = _str_Summaries);
                obj.Summaries.AcceptChanges();
                    
            }
            
            internal void _LoadLocation(VsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLocation(manager, obj);
                }
            }
            internal void _LoadLocation(DbManagerProxy manager, VsSession obj)
            {
                
                if (obj.Location == null && obj.idfLocation != null && obj.idfLocation != 0)
                {
                    obj.Location = LocationAccessor.SelectByKey(manager
                        
                        , obj.idfLocation.Value
                        );
                    if (obj.Location != null)
                    {
                        obj.Location.m_ObjectName = _str_Location;
                    }
                }
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, VsSession obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadVectors(manager, obj);
                _LoadSummaries(manager, obj);
                _LoadLocation(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerDiagnosisList(obj);
                
                _SetupAddChildHandlerVectors(obj);
                
                _SetupAddChildHandlerSummaries(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, VsSession obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    LocationAccessor._SetPermitions(obj._permissions, obj.Location);
                    
                        obj.DiagnosisList.ForEach(c => DiagnosisListAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Vectors.ForEach(c => VectorsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Summaries.ForEach(c => SummariesAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private VsSession _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    VsSession obj = VsSession.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfVectorSurveillanceSession = (new GetNewIDExtender<VsSession>()).GetScalar(manager, obj, isFake);
                obj.datStartDate = new Func<VsSession, DateTime>(c => DateTime.Now)(obj);
                obj.strSessionID = new Func<VsSession, string>(c => "(new)")(obj);
                obj.Location = new Func<VsSession, GeoLocation>(c => LocationAccessor.CreateWithoutCountry(manager, obj))(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerDiagnosisList(obj);
                    
                    _SetupAddChildHandlerVectors(obj);
                    
                    _SetupAddChildHandlerSummaries(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.VsStatus = new Func<VsSession, BaseReference>(c => c.VsStatusLookup.Where(l => l.idfsBaseReference == (long)VsStatusEnum.InProgress).SingleOrDefault())(obj);
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

            
            public VsSession CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VsSession CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public VsSession CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult VsSessionReport(DbManagerProxy manager, VsSession obj, List<object> pars)
            {
                
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("id", typeof(long));
                
                return VsSessionReport(manager, obj
                    , (long)pars[0]
                    );
            }
            public ActResult VsSessionReport(DbManagerProxy manager, VsSession obj
                , long id
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("VsSessionReport"))
                    throw new PermissionException("VsSession", "VsSessionReport");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(VsSession obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VsSession obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datStartDate)
                        {
                            try
                            {
                            
                (new PredicateValidator("datStartDate_CurrentDate_msgId", "datStartDate", "datStartDate", "datStartDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datStartDate, DateTime.Now)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datStartDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                                
                            }
                        }
                    
                        if (e.PropertyName == _str_intCollectionEffort)
                        {
                            try
                            {
                            
                (new PredicateValidator("intCollectionEffort_CurrentDate_msgId", "intCollectionEffort", "intCollectionEffort", "intCollectionEffort",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.intCollectionEffort != null? c.intCollectionEffort > 0 : true
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intCollectionEffort);
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
                                
                                else if (ex.ShouldAsk)
                                {
                                    obj.LockNotifyChanges();
                                    new Action<VsSession>(c => c.ChangeOutbreakDiagnosis())(obj);
                                    obj.UnlockNotifyChanges();
                                }
                                
                            }
                        }
                    
                        if (e.PropertyName == _str_strSessionID)
                        {
                    
                if (obj.Vectors != null) 
                    obj.Vectors.ForEach(t => { t.strSessionID = new Func<VsSession, string>(c => c.strSessionID)(obj); } );
                        }
                    
                        if (e.PropertyName == _str_idfsVectorSurveillanceStatus)
                        {
                    
                obj.datCloseDate = new Func<VsSession, DateTime?>(c => c.IsClosed ? new DateTime?(DateTime.Now) : null)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_VsStatus(DbManagerProxy manager, VsSession obj)
            {
                
                obj.VsStatusLookup.Clear();
                
                obj.VsStatusLookup.AddRange(VsStatusAccessor.rftVectorSurveillanceSessionStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorSurveillanceStatus))
                    
                    .ToList());
                
                if (obj.idfsVectorSurveillanceStatus != 0)
                {
                    obj.VsStatus = obj.VsStatusLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsVectorSurveillanceStatus);
                    
                }
              
                
                LookupManager.AddObject("rftVectorSurveillanceSessionStatus", obj, VsStatusAccessor.GetType(), "rftVectorSurveillanceSessionStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Diagnoses(DbManagerProxy manager, VsSession obj)
            {
                
                obj.DiagnosesLookup.Clear();
                
                obj.DiagnosesLookup.Add(DiagnosesAccessor.CreateNewT(manager, null));
                
                obj.DiagnosesLookup.AddRange(DiagnosesAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Vector) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != null && obj.idfsDiagnosis != 0)
                {
                    obj.Diagnoses = obj.DiagnosesLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosesAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, VsSession obj)
            {
                
                LoadLookup_VsStatus(manager, obj);
                
                LoadLookup_Diagnoses(manager, obj);
                
            }
    
            [SprocName("spVsSession_Delete")]
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
        
            [SprocName("spVsSession_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfVectorSurveillanceSession", "strSessionID")] VsSession obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfVectorSurveillanceSession", "strSessionID")] VsSession obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    VsSession bo = obj as VsSession;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("VsSession", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("VsSession", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("VsSession", "Update");
                    }
                    
                    long mainObject = bo.idfVectorSurveillanceSession;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        
                            manager.SetEventParams(false, new object[] { EventType.VsSessionCreatedLocal, mainObject, "" });
                        
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        
                        if (new Func<VsSession, bool>(c => c.DiagnosisList.Count(i => i.IsNew && !i.IsMarkedToDelete) > 0)(bo))
                          
                            manager.SetEventParams(false, new object[] { EventType.VsSessionNewDiagnosisLocal, mainObject, "" });
                        
                        if (new Func<VsSession, bool>(c => c.FieldTests.Count(i => i.IsNew && !i.IsMarkedToDelete) > 0)(bo))
                          
                            manager.SetEventParams(false, new object[] { EventType.VsSessionFieldTestResultRegistrationLocal, mainObject, "" });
                        
                        if (new Func<VsSession, bool>(c => c.LabTests.Count(i => i.IsNew && !i.IsMarkedToDelete) > 0)(bo))
                          
                            manager.SetEventParams(false, new object[] { EventType.VsSessionTestResultRegistrationLocal, mainObject, "" });
                        
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoVectorSurveillanceSession;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbVectorSurveillanceSession;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as VsSession, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VsSession obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.Summaries != null)
                    {
                        foreach (var i in obj.Summaries)
                        {
                            i.MarkToDelete();
                            if (!SummariesAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    
                    if (obj.Vectors != null)
                    {
                        foreach (var i in obj.Vectors)
                        {
                            i.MarkToDelete();
                            if (!VectorsAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    
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
                obj.datModificationForArchiveDate = new Func<VsSession, DateTime?>(c => c.HasChanges ? DateTime.Now : c.datModificationForArchiveDate)(obj);
              obj.Location.SetChange();
              obj.SetPostingOrder();
            
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
                        if (obj.Vectors != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Vectors)
                                if (!VectorsAccessor.Post(manager, i, true))
                                    return false;
                            obj.Vectors.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Vectors.Remove(c));
                            obj.Vectors.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Vectors != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Vectors)
                                if (!VectorsAccessor.Post(manager, i, true))
                                    return false;
                            obj._Vectors.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Vectors.Remove(c));
                            obj._Vectors.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.Summaries != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Summaries)
                                if (!SummariesAccessor.Post(manager, i, true))
                                    return false;
                            obj.Summaries.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Summaries.Remove(c));
                            obj.Summaries.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Summaries != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Summaries)
                                if (!SummariesAccessor.Post(manager, i, true))
                                    return false;
                            obj._Summaries.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Summaries.Remove(c));
                            obj._Summaries.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
              obj.RestoreOriginalOrder();
            
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                obj.OnPropertyChanged(_str_IsClosed);
                
                return true;
            }
            
            public bool ValidateCanDelete(VsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VsSession obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(VsSession obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(VsSession obj, bool bRethrowException)
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
                return Validate(manager, obj as VsSession, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VsSession obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsVectorSurveillanceStatus", "VsStatus","",
                false
              )).Validate(c => true, obj, obj.idfsVectorSurveillanceStatus);
            
                (new RequiredValidator( "datStartDate", "datStartDate","",
                false
              )).Validate(c => true, obj, obj.datStartDate);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                (new PredicateValidator("datStartDate_CurrentDate_msgId", "datStartDate", "datStartDate", "datStartDate",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datStartDate, DateTime.Now)
                    );
            
                (new PredicateValidator("intCollectionEffort_CurrentDate_msgId", "intCollectionEffort", "intCollectionEffort", "intCollectionEffort",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.intCollectionEffort != null? c.intCollectionEffort > 0 : true
                    );
            
                CheckOutbreak(obj);
            
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Location != null)
                            LocationAccessor.Validate(manager, obj.Location, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Vectors != null)
                            foreach (var i in obj.Vectors.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                VectorsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Summaries != null)
                            foreach (var i in obj.Summaries.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                SummariesAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(VsSession obj)
            {
            
                obj
                    .AddRequired("VsStatus", c => true);
                    
                  obj
                    .AddRequired("VsStatus", c => true);
                
                obj
                    .AddRequired("datStartDate", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(VsSession obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VsSession) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VsSession) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VsSessionDetail"; } }
            public string HelpIdWin { get { return "vss_form"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private VsSession m_obj;
            internal Permissions(VsSession obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("VsSession.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spVsSession_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spVsSession_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spVsSession_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VsSession, bool>> RequiredByField = new Dictionary<string, Func<VsSession, bool>>();
            public static Dictionary<string, Func<VsSession, bool>> RequiredByProperty = new Dictionary<string, Func<VsSession, bool>>();
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
                
                Sizes.Add(_str_strSessionID, 50);
                Sizes.Add(_str_strFieldSessionID, 50);
                Sizes.Add(_str_strDescription, 500);
                Sizes.Add(_str_strOutbreakID, 200);
                if (!RequiredByField.ContainsKey("idfsVectorSurveillanceStatus")) RequiredByField.Add("idfsVectorSurveillanceStatus", c => true);
                if (!RequiredByProperty.ContainsKey("VsStatus")) RequiredByProperty.Add("VsStatus", c => true);
                
                if (!RequiredByField.ContainsKey("datStartDate")) RequiredByField.Add("datStartDate", c => true);
                if (!RequiredByProperty.ContainsKey("datStartDate")) RequiredByProperty.Add("datStartDate", c => true);
                
                Actions.Add(new ActionMetaItem(
                    "VsSessionReport",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).VsSessionReport(manager, (VsSession)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleVsSessionReport",
                        "Report",
                        /*from BvMessages*/"titleVsSessionReport",
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
                    (c, a, b, p) => false,
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<VsSession>().Post(manager, (VsSession)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<VsSession>().Post(manager, (VsSession)c), c),
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
                    (manager, c, pars) => new ActResult(((VsSession)c).MarkToDelete() && ObjectAccessor.PostInterface<VsSession>().Post(manager, (VsSession)c), c),
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
    public abstract partial class DiagnosisItem : 
        EditableObject<DiagnosisItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfVectorSurveillanceSession), NonUpdatable, PrimaryKey]
        public abstract Int64 idfVectorSurveillanceSession { get; set; }
                
        [LocalizedDisplayName(_str_idfsDiagnosis)]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64? idfsDiagnosis { get; set; }
        protected Int64? idfsDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64? idfsDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DefaultName)]
        [MapField(_str_DefaultName)]
        public abstract String DefaultName { get; set; }
        protected String DefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._defaultName).OriginalValue; } }
        protected String DefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._defaultName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_NationalName)]
        [MapField(_str_NationalName)]
        public abstract String NationalName { get; set; }
        protected String NationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._nationalName).OriginalValue; } }
        protected String NationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._nationalName).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<DiagnosisItem, object> _get_func;
            internal Action<DiagnosisItem, string> _set_func;
            internal Action<DiagnosisItem, DiagnosisItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_DefaultName = "DefaultName";
        internal const string _str_NationalName = "NationalName";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _formname = _str_idfVectorSurveillanceSession, _type = "Int64",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVectorSurveillanceSession != newval) o.idfVectorSurveillanceSession = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, o.ObjectIdent2 + _str_idfVectorSurveillanceSession, o.ObjectIdent3 + _str_idfVectorSurveillanceSession, "Int64", 
                    o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(),                  
                  o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis, "Int64?", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DefaultName, _formname = _str_DefaultName, _type = "String",
              _get_func = o => o.DefaultName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DefaultName != newval) o.DefaultName = newval; },
              _compare_func = (o, c, m) => {
                if (o.DefaultName != c.DefaultName || o.IsRIRPropChanged(_str_DefaultName, c)) 
                  m.Add(_str_DefaultName, o.ObjectIdent + _str_DefaultName, o.ObjectIdent2 + _str_DefaultName, o.ObjectIdent3 + _str_DefaultName, "String", 
                    o.DefaultName == null ? "" : o.DefaultName.ToString(),                  
                  o.IsReadOnly(_str_DefaultName), o.IsInvisible(_str_DefaultName), o.IsRequired(_str_DefaultName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_NationalName, _formname = _str_NationalName, _type = "String",
              _get_func = o => o.NationalName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.NationalName != newval) o.NationalName = newval; },
              _compare_func = (o, c, m) => {
                if (o.NationalName != c.NationalName || o.IsRIRPropChanged(_str_NationalName, c)) 
                  m.Add(_str_NationalName, o.ObjectIdent + _str_NationalName, o.ObjectIdent2 + _str_NationalName, o.ObjectIdent3 + _str_NationalName, "String", 
                    o.NationalName == null ? "" : o.NationalName.ToString(),                  
                  o.IsReadOnly(_str_NationalName), o.IsInvisible(_str_NationalName), o.IsRequired(_str_NationalName)); 
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
            DiagnosisItem obj = (DiagnosisItem)o;
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
        internal string m_ObjectName = "DiagnosisItem";

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
            var ret = base.Clone() as DiagnosisItem;
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
            var ret = base.Clone() as DiagnosisItem;
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
        public DiagnosisItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as DiagnosisItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfVectorSurveillanceSession; } }
        public string KeyName { get { return "idfVectorSurveillanceSession"; } }
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

        private bool IsRIRPropChanged(string fld, DiagnosisItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public DiagnosisItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(DiagnosisItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(DiagnosisItem_PropertyChanged);
        }
        private void DiagnosisItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as DiagnosisItem).Changed(e.PropertyName);
            
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
            DiagnosisItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            DiagnosisItem obj = this;
            
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


        internal Dictionary<string, Func<DiagnosisItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<DiagnosisItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<DiagnosisItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<DiagnosisItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<DiagnosisItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<DiagnosisItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<DiagnosisItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~DiagnosisItem()
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
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<DiagnosisItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<DiagnosisItem>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<DiagnosisItem>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfVectorSurveillanceSession"; } }
            #endregion
        
            private delegate void on_action(DiagnosisItem obj);
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
            public virtual DiagnosisItem SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
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

            
            public virtual DiagnosisItem SelectByKey(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                )
            {
                return _SelectByKey(manager
                    , idfVectorSurveillanceSession
                    , null, null
                    );
            }
            
      
            private DiagnosisItem _SelectByKey(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, DiagnosisItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, DiagnosisItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private DiagnosisItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    DiagnosisItem obj = DiagnosisItem.CreateInstance();
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

            
            public DiagnosisItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public DiagnosisItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public DiagnosisItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(DiagnosisItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(DiagnosisItem obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, DiagnosisItem obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(DiagnosisItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(DiagnosisItem obj, bool bRethrowException)
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
                return Validate(manager, obj as DiagnosisItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, DiagnosisItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(DiagnosisItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(DiagnosisItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as DiagnosisItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as DiagnosisItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "DiagnosisItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spVsSession_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<DiagnosisItem, bool>> RequiredByField = new Dictionary<string, Func<DiagnosisItem, bool>>();
            public static Dictionary<string, Func<DiagnosisItem, bool>> RequiredByProperty = new Dictionary<string, Func<DiagnosisItem, bool>>();
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
                
                Sizes.Add(_str_DefaultName, 2000);
                Sizes.Add(_str_NationalName, 2000);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<DiagnosisItem>().Post(manager, (DiagnosisItem)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<DiagnosisItem>().Post(manager, (DiagnosisItem)c), c),
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
                    (manager, c, pars) => new ActResult(((DiagnosisItem)c).MarkToDelete() && ObjectAccessor.PostInterface<DiagnosisItem>().Post(manager, (DiagnosisItem)c), c),
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
	