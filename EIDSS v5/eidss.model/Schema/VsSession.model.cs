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
        #if MONO
        protected String strSessionID_Original { get { return strSessionID; } }
        protected String strSessionID_Previous { get { return strSessionID; } }
        #else
        protected String strSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strSessionID).OriginalValue; } }
        protected String strSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSessionID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strFieldSessionID)]
        [MapField(_str_strFieldSessionID)]
        public abstract String strFieldSessionID { get; set; }
        #if MONO
        protected String strFieldSessionID_Original { get { return strFieldSessionID; } }
        protected String strFieldSessionID_Previous { get { return strFieldSessionID; } }
        #else
        protected String strFieldSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldSessionID).OriginalValue; } }
        protected String strFieldSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldSessionID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsVectorSurveillanceStatus)]
        [MapField(_str_idfsVectorSurveillanceStatus)]
        public abstract Int64 idfsVectorSurveillanceStatus { get; set; }
        #if MONO
        protected Int64 idfsVectorSurveillanceStatus_Original { get { return idfsVectorSurveillanceStatus; } }
        protected Int64 idfsVectorSurveillanceStatus_Previous { get { return idfsVectorSurveillanceStatus; } }
        #else
        protected Int64 idfsVectorSurveillanceStatus_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSurveillanceStatus).OriginalValue; } }
        protected Int64 idfsVectorSurveillanceStatus_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSurveillanceStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datStartDate)]
        [MapField(_str_datStartDate)]
        public abstract DateTime datStartDate { get; set; }
        #if MONO
        protected DateTime datStartDate_Original { get { return datStartDate; } }
        protected DateTime datStartDate_Previous { get { return datStartDate; } }
        #else
        protected DateTime datStartDate_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime datStartDate_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datStartDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datCloseDate)]
        [MapField(_str_datCloseDate)]
        public abstract DateTime? datCloseDate { get; set; }
        #if MONO
        protected DateTime? datCloseDate_Original { get { return datCloseDate; } }
        protected DateTime? datCloseDate_Previous { get { return datCloseDate; } }
        #else
        protected DateTime? datCloseDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCloseDate).OriginalValue; } }
        protected DateTime? datCloseDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCloseDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfLocation)]
        [MapField(_str_idfLocation)]
        public abstract Int64? idfLocation { get; set; }
        #if MONO
        protected Int64? idfLocation_Original { get { return idfLocation; } }
        protected Int64? idfLocation_Previous { get { return idfLocation; } }
        #else
        protected Int64? idfLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).OriginalValue; } }
        protected Int64? idfLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).PreviousValue; } }
        #endif
                
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
                
        [LocalizedDisplayName(_str_strDescription)]
        [MapField(_str_strDescription)]
        public abstract String strDescription { get; set; }
        #if MONO
        protected String strDescription_Original { get { return strDescription; } }
        protected String strDescription_Previous { get { return strDescription; } }
        #else
        protected String strDescription_Original { get { return ((EditableValue<String>)((dynamic)this)._strDescription).OriginalValue; } }
        protected String strDescription_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDescription).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strOutbreakID)]
        [MapField(_str_strOutbreakID)]
        public abstract String strOutbreakID { get; set; }
        #if MONO
        protected String strOutbreakID_Original { get { return strOutbreakID; } }
        protected String strOutbreakID_Previous { get { return strOutbreakID; } }
        #else
        protected String strOutbreakID_Original { get { return ((EditableValue<String>)((dynamic)this)._strOutbreakID).OriginalValue; } }
        protected String strOutbreakID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOutbreakID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intCollectionEffort)]
        [MapField(_str_intCollectionEffort)]
        public abstract Int32? intCollectionEffort { get; set; }
        #if MONO
        protected Int32? intCollectionEffort_Original { get { return intCollectionEffort; } }
        protected Int32? intCollectionEffort_Previous { get { return intCollectionEffort; } }
        #else
        protected Int32? intCollectionEffort_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intCollectionEffort).OriginalValue; } }
        protected Int32? intCollectionEffort_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intCollectionEffort).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
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
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_strVectorType = "strVectorType";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_blnNeedRecalculateFields = "blnNeedRecalculateFields";
        internal const string _str_blnNeedRecalculateFieldTests = "blnNeedRecalculateFieldTests";
        internal const string _str_IsPoolVectorType = "IsPoolVectorType";
        internal const string _str_strVectorsCalculated = "strVectorsCalculated";
        internal const string _str_intSummaryQuantity = "intSummaryQuantity";
        internal const string _str_datSummaryCollectionFrom = "datSummaryCollectionFrom";
        internal const string _str_datSummaryCollectionTo = "datSummaryCollectionTo";
        internal const string _str_FieldTestsSummary = "FieldTestsSummary";
        internal const string _str_LabTestsSummary = "LabTestsSummary";
        internal const string _str_IsClosed = "IsClosed";
        internal const string _str_VsStatus = "VsStatus";
        internal const string _str_VsVectorType = "VsVectorType";
        internal const string _str_PensideTestType = "PensideTestType";
        internal const string _str_Diagnoses = "Diagnoses";
        internal const string _str_VectorTypes = "VectorTypes";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_SessionToVectorType = "SessionToVectorType";
        internal const string _str_PoolsVectors = "PoolsVectors";
        internal const string _str_Location = "Location";
        internal const string _str_Samples = "Samples";
        internal const string _str_FieldTests = "FieldTests";
        internal const string _str_LabTests = "LabTests";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _type = "Int64",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { o.idfVectorSurveillanceSession = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, "Int64", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); }
              }, 
        
            new field_info {
              _name = _str_strSessionID, _type = "String",
              _get_func = o => o.strSessionID,
              _set_func = (o, val) => { o.strSessionID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSessionID != c.strSessionID || o.IsRIRPropChanged(_str_strSessionID, c)) 
                  m.Add(_str_strSessionID, o.ObjectIdent + _str_strSessionID, "String", o.strSessionID == null ? "" : o.strSessionID.ToString(), o.IsReadOnly(_str_strSessionID), o.IsInvisible(_str_strSessionID), o.IsRequired(_str_strSessionID)); }
              }, 
        
            new field_info {
              _name = _str_strFieldSessionID, _type = "String",
              _get_func = o => o.strFieldSessionID,
              _set_func = (o, val) => { o.strFieldSessionID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldSessionID != c.strFieldSessionID || o.IsRIRPropChanged(_str_strFieldSessionID, c)) 
                  m.Add(_str_strFieldSessionID, o.ObjectIdent + _str_strFieldSessionID, "String", o.strFieldSessionID == null ? "" : o.strFieldSessionID.ToString(), o.IsReadOnly(_str_strFieldSessionID), o.IsInvisible(_str_strFieldSessionID), o.IsRequired(_str_strFieldSessionID)); }
              }, 
        
            new field_info {
              _name = _str_idfsVectorSurveillanceStatus, _type = "Int64",
              _get_func = o => o.idfsVectorSurveillanceStatus,
              _set_func = (o, val) => { o.idfsVectorSurveillanceStatus = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorSurveillanceStatus != c.idfsVectorSurveillanceStatus || o.IsRIRPropChanged(_str_idfsVectorSurveillanceStatus, c)) 
                  m.Add(_str_idfsVectorSurveillanceStatus, o.ObjectIdent + _str_idfsVectorSurveillanceStatus, "Int64", o.idfsVectorSurveillanceStatus == null ? "" : o.idfsVectorSurveillanceStatus.ToString(), o.IsReadOnly(_str_idfsVectorSurveillanceStatus), o.IsInvisible(_str_idfsVectorSurveillanceStatus), o.IsRequired(_str_idfsVectorSurveillanceStatus)); }
              }, 
        
            new field_info {
              _name = _str_datStartDate, _type = "DateTime",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { o.datStartDate = ParsingHelper.ParseDateTime(val); },
              _compare_func = (o, c, m) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, "DateTime", o.datStartDate == null ? "" : o.datStartDate.ToString(), o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); }
              }, 
        
            new field_info {
              _name = _str_datCloseDate, _type = "DateTime?",
              _get_func = o => o.datCloseDate,
              _set_func = (o, val) => { o.datCloseDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCloseDate != c.datCloseDate || o.IsRIRPropChanged(_str_datCloseDate, c)) 
                  m.Add(_str_datCloseDate, o.ObjectIdent + _str_datCloseDate, "DateTime?", o.datCloseDate == null ? "" : o.datCloseDate.ToString(), o.IsReadOnly(_str_datCloseDate), o.IsInvisible(_str_datCloseDate), o.IsRequired(_str_datCloseDate)); }
              }, 
        
            new field_info {
              _name = _str_idfLocation, _type = "Int64?",
              _get_func = o => o.idfLocation,
              _set_func = (o, val) => { o.idfLocation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfLocation != c.idfLocation || o.IsRIRPropChanged(_str_idfLocation, c)) 
                  m.Add(_str_idfLocation, o.ObjectIdent + _str_idfLocation, "Int64?", o.idfLocation == null ? "" : o.idfLocation.ToString(), o.IsReadOnly(_str_idfLocation), o.IsInvisible(_str_idfLocation), o.IsRequired(_str_idfLocation)); }
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
              _name = _str_strDescription, _type = "String",
              _get_func = o => o.strDescription,
              _set_func = (o, val) => { o.strDescription = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strDescription != c.strDescription || o.IsRIRPropChanged(_str_strDescription, c)) 
                  m.Add(_str_strDescription, o.ObjectIdent + _str_strDescription, "String", o.strDescription == null ? "" : o.strDescription.ToString(), o.IsReadOnly(_str_strDescription), o.IsInvisible(_str_strDescription), o.IsRequired(_str_strDescription)); }
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
              _name = _str_strOutbreakID, _type = "String",
              _get_func = o => o.strOutbreakID,
              _set_func = (o, val) => { o.strOutbreakID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strOutbreakID != c.strOutbreakID || o.IsRIRPropChanged(_str_strOutbreakID, c)) 
                  m.Add(_str_strOutbreakID, o.ObjectIdent + _str_strOutbreakID, "String", o.strOutbreakID == null ? "" : o.strOutbreakID.ToString(), o.IsReadOnly(_str_strOutbreakID), o.IsInvisible(_str_strOutbreakID), o.IsRequired(_str_strOutbreakID)); }
              }, 
        
            new field_info {
              _name = _str_intCollectionEffort, _type = "Int32?",
              _get_func = o => o.intCollectionEffort,
              _set_func = (o, val) => { o.intCollectionEffort = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intCollectionEffort != c.intCollectionEffort || o.IsRIRPropChanged(_str_intCollectionEffort, c)) 
                  m.Add(_str_intCollectionEffort, o.ObjectIdent + _str_intCollectionEffort, "Int32?", o.intCollectionEffort == null ? "" : o.intCollectionEffort.ToString(), o.IsReadOnly(_str_intCollectionEffort), o.IsInvisible(_str_intCollectionEffort), o.IsRequired(_str_intCollectionEffort)); }
              }, 
        
            new field_info {
              _name = _str_idfsVectorType, _type = "long?",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { o.idfsVectorType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) 
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, "long?", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType));
                 }
              }, 
        
            new field_info {
              _name = _str_strVectorType, _type = "string",
              _get_func = o => o.strVectorType,
              _set_func = (o, val) => { o.strVectorType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
              
                if (o.strVectorType != c.strVectorType || o.IsRIRPropChanged(_str_strVectorType, c)) 
                  m.Add(_str_strVectorType, o.ObjectIdent + _str_strVectorType, "string", o.strVectorType == null ? "" : o.strVectorType.ToString(), o.IsReadOnly(_str_strVectorType), o.IsInvisible(_str_strVectorType), o.IsRequired(_str_strVectorType));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosis, _type = "long?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { o.idfsDiagnosis = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, "long?", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis));
                 }
              }, 
        
            new field_info {
              _name = _str_blnNeedRecalculateFields, _type = "bool",
              _get_func = o => o.blnNeedRecalculateFields,
              _set_func = (o, val) => { o.blnNeedRecalculateFields = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.blnNeedRecalculateFields != c.blnNeedRecalculateFields || o.IsRIRPropChanged(_str_blnNeedRecalculateFields, c)) 
                  m.Add(_str_blnNeedRecalculateFields, o.ObjectIdent + _str_blnNeedRecalculateFields, "bool", o.blnNeedRecalculateFields == null ? "" : o.blnNeedRecalculateFields.ToString(), o.IsReadOnly(_str_blnNeedRecalculateFields), o.IsInvisible(_str_blnNeedRecalculateFields), o.IsRequired(_str_blnNeedRecalculateFields));
                 }
              }, 
        
            new field_info {
              _name = _str_blnNeedRecalculateFieldTests, _type = "bool",
              _get_func = o => o.blnNeedRecalculateFieldTests,
              _set_func = (o, val) => { o.blnNeedRecalculateFieldTests = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.blnNeedRecalculateFieldTests != c.blnNeedRecalculateFieldTests || o.IsRIRPropChanged(_str_blnNeedRecalculateFieldTests, c)) 
                  m.Add(_str_blnNeedRecalculateFieldTests, o.ObjectIdent + _str_blnNeedRecalculateFieldTests, "bool", o.blnNeedRecalculateFieldTests == null ? "" : o.blnNeedRecalculateFieldTests.ToString(), o.IsReadOnly(_str_blnNeedRecalculateFieldTests), o.IsInvisible(_str_blnNeedRecalculateFieldTests), o.IsRequired(_str_blnNeedRecalculateFieldTests));
                 }
              }, 
        
            new field_info {
              _name = _str_intSummaryQuantity, _type = "int",
              _get_func = o => o.intSummaryQuantity,
              _set_func = (o, val) => { o.intSummaryQuantity = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
              
                if (o.intSummaryQuantity != c.intSummaryQuantity || o.IsRIRPropChanged(_str_intSummaryQuantity, c)) 
                  m.Add(_str_intSummaryQuantity, o.ObjectIdent + _str_intSummaryQuantity, "int", o.intSummaryQuantity == null ? "" : o.intSummaryQuantity.ToString(), o.IsReadOnly(_str_intSummaryQuantity), o.IsInvisible(_str_intSummaryQuantity), o.IsRequired(_str_intSummaryQuantity));
                 }
              }, 
        
            new field_info {
              _name = _str_datSummaryCollectionFrom, _type = "DateTime?",
              _get_func = o => o.datSummaryCollectionFrom,
              _set_func = (o, val) => { o.datSummaryCollectionFrom = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.datSummaryCollectionFrom != c.datSummaryCollectionFrom || o.IsRIRPropChanged(_str_datSummaryCollectionFrom, c)) 
                  m.Add(_str_datSummaryCollectionFrom, o.ObjectIdent + _str_datSummaryCollectionFrom, "DateTime?", o.datSummaryCollectionFrom == null ? "" : o.datSummaryCollectionFrom.ToString(), o.IsReadOnly(_str_datSummaryCollectionFrom), o.IsInvisible(_str_datSummaryCollectionFrom), o.IsRequired(_str_datSummaryCollectionFrom));
                 }
              }, 
        
            new field_info {
              _name = _str_datSummaryCollectionTo, _type = "DateTime?",
              _get_func = o => o.datSummaryCollectionTo,
              _set_func = (o, val) => { o.datSummaryCollectionTo = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.datSummaryCollectionTo != c.datSummaryCollectionTo || o.IsRIRPropChanged(_str_datSummaryCollectionTo, c)) 
                  m.Add(_str_datSummaryCollectionTo, o.ObjectIdent + _str_datSummaryCollectionTo, "DateTime?", o.datSummaryCollectionTo == null ? "" : o.datSummaryCollectionTo.ToString(), o.IsReadOnly(_str_datSummaryCollectionTo), o.IsInvisible(_str_datSummaryCollectionTo), o.IsRequired(_str_datSummaryCollectionTo));
                 }
              }, 
        
            new field_info {
              _name = _str_FieldTestsSummary, _type = "List<eidss.model.Model.SummaryTable>",
              _get_func = o => o.FieldTestsSummary,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_LabTestsSummary, _type = "List<eidss.model.Model.SummaryTable>",
              _get_func = o => o.LabTestsSummary,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_IsPoolVectorType, _type = "bool",
              _get_func = o => o.IsPoolVectorType,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.IsPoolVectorType != c.IsPoolVectorType || o.IsRIRPropChanged(_str_IsPoolVectorType, c)) 
                  m.Add(_str_IsPoolVectorType, o.ObjectIdent + _str_IsPoolVectorType, "bool", o.IsPoolVectorType == null ? "" : o.IsPoolVectorType.ToString(), o.IsReadOnly(_str_IsPoolVectorType), o.IsInvisible(_str_IsPoolVectorType), o.IsRequired(_str_IsPoolVectorType));
                 }
              }, 
        
            new field_info {
              _name = _str_strVectorsCalculated, _type = "string",
              _get_func = o => o.strVectorsCalculated,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strVectorsCalculated != c.strVectorsCalculated || o.IsRIRPropChanged(_str_strVectorsCalculated, c)) 
                  m.Add(_str_strVectorsCalculated, o.ObjectIdent + _str_strVectorsCalculated, "string", o.strVectorsCalculated == null ? "" : o.strVectorsCalculated.ToString(), o.IsReadOnly(_str_strVectorsCalculated), o.IsInvisible(_str_strVectorsCalculated), o.IsRequired(_str_strVectorsCalculated));
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
              _name = _str_VsStatus, _type = "Lookup",
              _get_func = o => { if (o.VsStatus == null) return null; return o.VsStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.VsStatus = o.VsStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorSurveillanceStatus != c.idfsVectorSurveillanceStatus || o.IsRIRPropChanged(_str_VsStatus, c)) 
                  m.Add(_str_VsStatus, o.ObjectIdent + _str_VsStatus, "Lookup", o.idfsVectorSurveillanceStatus == null ? "" : o.idfsVectorSurveillanceStatus.ToString(), o.IsReadOnly(_str_VsStatus), o.IsInvisible(_str_VsStatus), o.IsRequired(_str_VsStatus)); }
              }, 
        
            new field_info {
              _name = _str_VsVectorType, _type = "Lookup",
              _get_func = o => { if (o.VsVectorType == null) return null; return o.VsVectorType.idfsBaseReference; },
              _set_func = (o, val) => { o.VsVectorType = o.VsVectorTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_VsVectorType, c)) 
                  m.Add(_str_VsVectorType, o.ObjectIdent + _str_VsVectorType, "Lookup", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_VsVectorType), o.IsInvisible(_str_VsVectorType), o.IsRequired(_str_VsVectorType)); }
              }, 
        
            new field_info {
              _name = _str_PensideTestType, _type = "Lookup",
              _get_func = o => { if (o.PensideTestType == null) return null; return o.PensideTestType.idfsVectorType; },
              _set_func = (o, val) => { o.PensideTestType = o.PensideTestTypeLookup.Where(c => c.idfsVectorType.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_PensideTestType, c)) 
                  m.Add(_str_PensideTestType, o.ObjectIdent + _str_PensideTestType, "Lookup", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_PensideTestType), o.IsInvisible(_str_PensideTestType), o.IsRequired(_str_PensideTestType)); }
              }, 
        
            new field_info {
              _name = _str_Diagnoses, _type = "Lookup",
              _get_func = o => { if (o.Diagnoses == null) return null; return o.Diagnoses.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnoses = o.DiagnosesLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnoses, c)) 
                  m.Add(_str_Diagnoses, o.ObjectIdent + _str_Diagnoses, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnoses), o.IsInvisible(_str_Diagnoses), o.IsRequired(_str_Diagnoses)); }
              }, 
        
            new field_info {
              _name = _str_VectorTypes, _type = "Lookup",
              _get_func = o => { if (o.VectorTypes == null) return null; return o.VectorTypes.idfsBaseReference; },
              _set_func = (o, val) => { o.VectorTypes = o.VectorTypesLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_VectorTypes, c)) 
                  m.Add(_str_VectorTypes, o.ObjectIdent + _str_VectorTypes, "Lookup", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_VectorTypes), o.IsInvisible(_str_VectorTypes), o.IsRequired(_str_VectorTypes)); }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Diagnosis.Count != c.Diagnosis.Count || o.IsReadOnly(_str_Diagnosis) != c.IsReadOnly(_str_Diagnosis) || o.IsInvisible(_str_Diagnosis) != c.IsInvisible(_str_Diagnosis) || o.IsRequired(_str_Diagnosis) != c.IsRequired(_str_Diagnosis)) 
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, "Child", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); }
              }, 
        
            new field_info {
              _name = _str_SessionToVectorType, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.SessionToVectorType.Count != c.SessionToVectorType.Count || o.IsReadOnly(_str_SessionToVectorType) != c.IsReadOnly(_str_SessionToVectorType) || o.IsInvisible(_str_SessionToVectorType) != c.IsInvisible(_str_SessionToVectorType) || o.IsRequired(_str_SessionToVectorType) != c.IsRequired(_str_SessionToVectorType)) 
                  m.Add(_str_SessionToVectorType, o.ObjectIdent + _str_SessionToVectorType, "Child", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_SessionToVectorType), o.IsInvisible(_str_SessionToVectorType), o.IsRequired(_str_SessionToVectorType)); }
              }, 
        
            new field_info {
              _name = _str_PoolsVectors, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.PoolsVectors.Count != c.PoolsVectors.Count || o.IsReadOnly(_str_PoolsVectors) != c.IsReadOnly(_str_PoolsVectors) || o.IsInvisible(_str_PoolsVectors) != c.IsInvisible(_str_PoolsVectors) || o.IsRequired(_str_PoolsVectors) != c.IsRequired(_str_PoolsVectors)) 
                  m.Add(_str_PoolsVectors, o.ObjectIdent + _str_PoolsVectors, "Child", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_PoolsVectors), o.IsInvisible(_str_PoolsVectors), o.IsRequired(_str_PoolsVectors)); }
              }, 
        
            new field_info {
              _name = _str_Samples, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Samples.Count != c.Samples.Count || o.IsReadOnly(_str_Samples) != c.IsReadOnly(_str_Samples) || o.IsInvisible(_str_Samples) != c.IsInvisible(_str_Samples) || o.IsRequired(_str_Samples) != c.IsRequired(_str_Samples)) 
                  m.Add(_str_Samples, o.ObjectIdent + _str_Samples, "Child", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_Samples), o.IsInvisible(_str_Samples), o.IsRequired(_str_Samples)); }
              }, 
        
            new field_info {
              _name = _str_FieldTests, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.FieldTests.Count != c.FieldTests.Count || o.IsReadOnly(_str_FieldTests) != c.IsReadOnly(_str_FieldTests) || o.IsInvisible(_str_FieldTests) != c.IsInvisible(_str_FieldTests) || o.IsRequired(_str_FieldTests) != c.IsRequired(_str_FieldTests)) 
                  m.Add(_str_FieldTests, o.ObjectIdent + _str_FieldTests, "Child", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_FieldTests), o.IsInvisible(_str_FieldTests), o.IsRequired(_str_FieldTests)); }
              }, 
        
            new field_info {
              _name = _str_LabTests, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.LabTests.Count != c.LabTests.Count || o.IsReadOnly(_str_LabTests) != c.IsReadOnly(_str_LabTests) || o.IsInvisible(_str_LabTests) != c.IsInvisible(_str_LabTests) || o.IsRequired(_str_LabTests) != c.IsRequired(_str_LabTests)) 
                  m.Add(_str_LabTests, o.ObjectIdent + _str_LabTests, "Child", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_LabTests), o.IsInvisible(_str_LabTests), o.IsRequired(_str_LabTests)); }
              }, 
        
            new field_info {
              _name = _str_Location, _type = "Relation",
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
    
        [Relation(typeof(DiagnosisItem), eidss.model.Schema.DiagnosisItem._str_idfVectorSurveillanceSession, _str_idfVectorSurveillanceSession)]
        public EditableList<DiagnosisItem> Diagnosis
        {
            get 
            {   
                return _Diagnosis; 
            }
            set 
            {
                _Diagnosis = value;
            }
        }
        protected EditableList<DiagnosisItem> _Diagnosis = new EditableList<DiagnosisItem>();
                    
        [Relation(typeof(SessionToVectorTypeItem), eidss.model.Schema.SessionToVectorTypeItem._str_idfVectorSurveillanceSession, _str_idfVectorSurveillanceSession)]
        public EditableList<SessionToVectorTypeItem> SessionToVectorType
        {
            get 
            {   
                return _SessionToVectorType; 
            }
            set 
            {
                _SessionToVectorType = value;
            }
        }
        protected EditableList<SessionToVectorTypeItem> _SessionToVectorType = new EditableList<SessionToVectorTypeItem>();
                    
        [Relation(typeof(Vector), eidss.model.Schema.Vector._str_idfVectorSurveillanceSession, _str_idfVectorSurveillanceSession)]
        public EditableList<Vector> PoolsVectors
        {
            get 
            {   
                return _PoolsVectors; 
            }
            set 
            {
                _PoolsVectors = value;
            }
        }
        protected EditableList<Vector> _PoolsVectors = new EditableList<Vector>();
                    
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
                    
        [Relation(typeof(VectorSample), eidss.model.Schema.VectorSample._str_idfVectorSurveillanceSession, _str_idfVectorSurveillanceSession)]
        public EditableList<VectorSample> Samples
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
        protected EditableList<VectorSample> _Samples = new EditableList<VectorSample>();
                    
        [Relation(typeof(VectorFieldTest), eidss.model.Schema.VectorFieldTest._str_idfVectorSurveillanceSession, _str_idfVectorSurveillanceSession)]
        public EditableList<VectorFieldTest> FieldTests
        {
            get 
            {   
                return _FieldTests; 
            }
            set 
            {
                _FieldTests = value;
            }
        }
        protected EditableList<VectorFieldTest> _FieldTests = new EditableList<VectorFieldTest>();
                    
        [Relation(typeof(VectorLabTest), "", _str_idfVectorSurveillanceSession)]
        public EditableList<VectorLabTest> LabTests
        {
            get 
            {   
                return _LabTests; 
            }
            set 
            {
                _LabTests = value;
            }
        }
        protected EditableList<VectorLabTest> _LabTests = new EditableList<VectorLabTest>();
                    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsVectorSurveillanceStatus)]
        public BaseReference VsStatus
        {
            get { return _VsStatus; }
            set 
            { 
                _VsStatus = value;
                idfsVectorSurveillanceStatus = _VsStatus == null 
                    ? new Int64()
                    : _VsStatus.idfsBaseReference; 
                OnPropertyChanged(_str_VsStatus); 
            }
        }
        private BaseReference _VsStatus;

        
        public BaseReferenceList VsStatusLookup
        {
            get { return _VsStatusLookup; }
        }
        private BaseReferenceList _VsStatusLookup = new BaseReferenceList("rftVectorSurveillanceSessionStatus");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsVectorType)]
        public BaseReference VsVectorType
        {
            get { return _VsVectorType == null ? null : ((long)_VsVectorType.Key == 0 ? null : _VsVectorType); }
            set 
            { 
                _VsVectorType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsVectorType = _VsVectorType == null 
                    ? new long?()
                    : _VsVectorType.idfsBaseReference; 
                OnPropertyChanged(_str_VsVectorType); 
            }
        }
        private BaseReference _VsVectorType;

        
        public BaseReferenceList VsVectorTypeLookup
        {
            get { return _VsVectorTypeLookup; }
        }
        private BaseReferenceList _VsVectorTypeLookup = new BaseReferenceList("rftVectorType");
            
        [Relation(typeof(PensideTestLookup), eidss.model.Schema.PensideTestLookup._str_idfsVectorType, _str_idfsVectorType)]
        public PensideTestLookup PensideTestType
        {
            get { return _PensideTestType == null ? null : ((long)_PensideTestType.Key == 0 ? null : _PensideTestType); }
            set 
            { 
                _PensideTestType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsVectorType = _PensideTestType == null 
                    ? new long?()
                    : _PensideTestType.idfsVectorType; 
                OnPropertyChanged(_str_PensideTestType); 
            }
        }
        private PensideTestLookup _PensideTestType;

        
        public List<PensideTestLookup> PensideTestTypeLookup
        {
            get { return _PensideTestTypeLookup; }
        }
        private List<PensideTestLookup> _PensideTestTypeLookup = new List<PensideTestLookup>();
            
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnoses
        {
            get { return _Diagnoses == null ? null : ((long)_Diagnoses.Key == 0 ? null : _Diagnoses); }
            set 
            { 
                _Diagnoses = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsDiagnosis = _Diagnoses == null 
                    ? new long?()
                    : _Diagnoses.idfsDiagnosis; 
                OnPropertyChanged(_str_Diagnoses); 
            }
        }
        private DiagnosisLookup _Diagnoses;

        
        public List<DiagnosisLookup> DiagnosesLookup
        {
            get { return _DiagnosesLookup; }
        }
        private List<DiagnosisLookup> _DiagnosesLookup = new List<DiagnosisLookup>();
            
        [Relation(typeof(VectorTypeLookup), eidss.model.Schema.VectorTypeLookup._str_idfsBaseReference, _str_idfsVectorType)]
        public VectorTypeLookup VectorTypes
        {
            get { return _VectorTypes == null ? null : ((long)_VectorTypes.Key == 0 ? null : _VectorTypes); }
            set 
            { 
                _VectorTypes = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsVectorType = _VectorTypes == null 
                    ? new long?()
                    : _VectorTypes.idfsBaseReference; 
                OnPropertyChanged(_str_VectorTypes); 
            }
        }
        private VectorTypeLookup _VectorTypes;

        
        public List<VectorTypeLookup> VectorTypesLookup
        {
            get { return _VectorTypesLookup; }
        }
        private List<VectorTypeLookup> _VectorTypesLookup = new List<VectorTypeLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_VsStatus:
                    return new BvSelectList(VsStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, VsStatus, _str_idfsVectorSurveillanceStatus);
            
                case _str_VsVectorType:
                    return new BvSelectList(VsVectorTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, VsVectorType, _str_idfsVectorType);
            
                case _str_PensideTestType:
                    return new BvSelectList(PensideTestTypeLookup, eidss.model.Schema.PensideTestLookup._str_idfsVectorType, null, PensideTestType, _str_idfsVectorType);
            
                case _str_Diagnoses:
                    return new BvSelectList(DiagnosesLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnoses, _str_idfsDiagnosis);
            
                case _str_VectorTypes:
                    return new BvSelectList(VectorTypesLookup, eidss.model.Schema.VectorTypeLookup._str_idfsBaseReference, null, VectorTypes, _str_idfsVectorType);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsPoolVectorType)]
        public bool IsPoolVectorType
        {
            get { return new Func<VsSession, bool>(c => c.VectorTypesLookup.Where(m => m.idfsBaseReference == c.idfsVectorType).FirstOrDefault() != null ? c.VectorTypesLookup.Where(m => m.idfsBaseReference == idfsVectorType).FirstOrDefault().bitCollectionByPool : false)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strVectorsCalculated)]
        public string strVectorsCalculated
        {
            get { return new Func<VsSession, string>(c => c.SessionToVectorType.Where(m => m.IsChecked == 1).Aggregate("", 
                                (a,b) => (a == String.Empty ? String.Empty : a + ", ") 
                                + b.VectorTypeNationalName))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsClosed)]
        public bool IsClosed
        {
            get { return new Func<VsSession, bool>(c => (c.idfsVectorSurveillanceStatus == (long)VsStatusEnum.Closed) )(this); }
            
        }
        
          [LocalizedDisplayName(_str_idfsVectorType)]
        public long? idfsVectorType
        {
            get { return m_idfsVectorType; }
            set { if (m_idfsVectorType != value) { m_idfsVectorType = value; OnPropertyChanged(_str_idfsVectorType); } }
        }
        private long? m_idfsVectorType;
        
          [LocalizedDisplayName(_str_strVectorType)]
        public string strVectorType
        {
            get { return m_strVectorType; }
            set { if (m_strVectorType != value) { m_strVectorType = value; OnPropertyChanged(_str_strVectorType); } }
        }
        private string m_strVectorType;
        
          [LocalizedDisplayName(_str_idfsDiagnosis)]
        public long? idfsDiagnosis
        {
            get { return m_idfsDiagnosis; }
            set { if (m_idfsDiagnosis != value) { m_idfsDiagnosis = value; OnPropertyChanged(_str_idfsDiagnosis); } }
        }
        private long? m_idfsDiagnosis;
        
          [LocalizedDisplayName(_str_blnNeedRecalculateFields)]
        public bool blnNeedRecalculateFields
        {
            get { return m_blnNeedRecalculateFields; }
            set { if (m_blnNeedRecalculateFields != value) { m_blnNeedRecalculateFields = value; OnPropertyChanged(_str_blnNeedRecalculateFields); } }
        }
        private bool m_blnNeedRecalculateFields;
        
          [LocalizedDisplayName(_str_blnNeedRecalculateFieldTests)]
        public bool blnNeedRecalculateFieldTests
        {
            get { return m_blnNeedRecalculateFieldTests; }
            set { if (m_blnNeedRecalculateFieldTests != value) { m_blnNeedRecalculateFieldTests = value; OnPropertyChanged(_str_blnNeedRecalculateFieldTests); } }
        }
        private bool m_blnNeedRecalculateFieldTests;
        
          [LocalizedDisplayName(_str_intSummaryQuantity)]
        public int intSummaryQuantity
        {
            get { return m_intSummaryQuantity; }
            set { if (m_intSummaryQuantity != value) { m_intSummaryQuantity = value; OnPropertyChanged(_str_intSummaryQuantity); } }
        }
        private int m_intSummaryQuantity;
        
          [LocalizedDisplayName(_str_datSummaryCollectionFrom)]
        public DateTime? datSummaryCollectionFrom
        {
            get { return m_datSummaryCollectionFrom; }
            set { if (m_datSummaryCollectionFrom != value) { m_datSummaryCollectionFrom = value; OnPropertyChanged(_str_datSummaryCollectionFrom); } }
        }
        private DateTime? m_datSummaryCollectionFrom;
        
          [LocalizedDisplayName(_str_datSummaryCollectionTo)]
        public DateTime? datSummaryCollectionTo
        {
            get { return m_datSummaryCollectionTo; }
            set { if (m_datSummaryCollectionTo != value) { m_datSummaryCollectionTo = value; OnPropertyChanged(_str_datSummaryCollectionTo); } }
        }
        private DateTime? m_datSummaryCollectionTo;
        
          [LocalizedDisplayName(_str_FieldTestsSummary)]
        public List<eidss.model.Model.SummaryTable> FieldTestsSummary
        {
            get { return m_FieldTestsSummary; }
            set { if (m_FieldTestsSummary != value) { m_FieldTestsSummary = value; OnPropertyChanged(_str_FieldTestsSummary); } }
        }
        private List<eidss.model.Model.SummaryTable> m_FieldTestsSummary;
        
          [LocalizedDisplayName(_str_LabTestsSummary)]
        public List<eidss.model.Model.SummaryTable> LabTestsSummary
        {
            get { return m_LabTestsSummary; }
            set { if (m_LabTestsSummary != value) { m_LabTestsSummary = value; OnPropertyChanged(_str_LabTestsSummary); } }
        }
        private List<eidss.model.Model.SummaryTable> m_LabTestsSummary;
        
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
        Diagnosis.ForEach(c => { c.Parent = this; });
                SessionToVectorType.ForEach(c => { c.Parent = this; });
                PoolsVectors.ForEach(c => { c.Parent = this; });
                
            if (_Location != null) { _Location.Parent = this; }
                Samples.ForEach(c => { c.Parent = this; });
                FieldTests.ForEach(c => { c.Parent = this; });
                LabTests.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as VsSession;
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
            var ret = base.Clone() as VsSession;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Location != null)
              ret.Location = _Location.CloneWithSetup(manager) as GeoLocation;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
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
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || Diagnosis.IsDirty
                    || Diagnosis.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || SessionToVectorType.IsDirty
                    || SessionToVectorType.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || PoolsVectors.IsDirty
                    || PoolsVectors.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || (_Location != null && _Location.HasChanges)
                
                    || Samples.IsDirty
                    || Samples.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || FieldTests.IsDirty
                    || FieldTests.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || LabTests.IsDirty
                    || LabTests.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsVectorSurveillanceStatus_VsStatus = idfsVectorSurveillanceStatus;
            var _prev_idfsVectorType_VsVectorType = idfsVectorType;
            var _prev_idfsVectorType_PensideTestType = idfsVectorType;
            var _prev_idfsDiagnosis_Diagnoses = idfsDiagnosis;
            var _prev_idfsVectorType_VectorTypes = idfsVectorType;
            base.RejectChanges();
        
            if (_prev_idfsVectorSurveillanceStatus_VsStatus != idfsVectorSurveillanceStatus)
            {
                _VsStatus = _VsStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorSurveillanceStatus);
            }
            if (_prev_idfsVectorType_VsVectorType != idfsVectorType)
            {
                _VsVectorType = _VsVectorTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorType);
            }
            if (_prev_idfsVectorType_PensideTestType != idfsVectorType)
            {
                _PensideTestType = _PensideTestTypeLookup.FirstOrDefault(c => c.idfsVectorType == idfsVectorType);
            }
            if (_prev_idfsDiagnosis_Diagnoses != idfsDiagnosis)
            {
                _Diagnoses = _DiagnosesLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsVectorType_VectorTypes != idfsVectorType)
            {
                _VectorTypes = _VectorTypesLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorType);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        Diagnosis.RejectChanges();
                SessionToVectorType.RejectChanges();
                PoolsVectors.RejectChanges();
                
            if (Location != null) Location.RejectChanges();
                Samples.RejectChanges();
                FieldTests.RejectChanges();
                LabTests.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        Diagnosis.AcceptChanges();
                SessionToVectorType.AcceptChanges();
                PoolsVectors.AcceptChanges();
                
            if (_Location != null) _Location.AcceptChanges();
                Samples.AcceptChanges();
                FieldTests.AcceptChanges();
                LabTests.AcceptChanges();
                
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
        Diagnosis.ForEach(c => c.SetChange());
                SessionToVectorType.ForEach(c => c.SetChange());
                PoolsVectors.ForEach(c => c.SetChange());
                
            if (_Location != null) _Location.SetChange();
                Samples.ForEach(c => c.SetChange());
                FieldTests.ForEach(c => c.SetChange());
                LabTests.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, VsSession c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public VsSession()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VsSession_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VsSession_PropertyChanged);
        }
        private void VsSession_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VsSession).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsVectorType)
                OnPropertyChanged(_str_IsPoolVectorType);
                  
            if (e.PropertyName == _str_blnNeedRecalculateFields)
                OnPropertyChanged(_str_strVectorsCalculated);
                  
            if (e.PropertyName == _str_idfsVectorSurveillanceStatus)
                OnPropertyChanged(_str_IsClosed);
                  
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
                    )).Validate(obj, v => v.PoolsVectors.Where(s => !s.IsMarkedToDelete).Count() == 0
                    );
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, v => v.FieldTests.Where(ft => ft.idfsPensideTestResult != null).Count() == 0
                    );
            
            }
            catch(ValidationModelException ex)
            {
                if (bReport && !OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                {
                    OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
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

    
        private static string[] readonly_names1 = "strSessionID,strVectorsCalculated,intSummaryQuantity,intSummaryCollectionEffort,datSummaryCollectionFrom,datSummaryCollectionTo,datCloseDate".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "VsStatus".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VsSession, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VsSession, bool>(c => c.ReadOnly)(this);
            
            return ReadOnly || new Func<VsSession, bool>(c => c.ReadOnly || c.IsClosed)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _Diagnosis)
                    o.ReadOnly = value;
                
                foreach(var o in _SessionToVectorType)
                    o.ReadOnly = value;
                
                foreach(var o in _PoolsVectors)
                    o.ReadOnly = value;
                
                if (_Location != null)
                    _Location.ReadOnly = value;
                
                foreach(var o in _Samples)
                    o.ReadOnly = value;
                
                foreach(var o in _FieldTests)
                    o.ReadOnly = value;
                
                foreach(var o in _LabTests)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<VsSession, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VsSession, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VsSession, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<VsSession, bool>> m_isHiddenPersonalData;
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
                
                LookupManager.RemoveObject("rftVectorSurveillanceSessionStatus", this);
                
                LookupManager.RemoveObject("rftVectorType", this);
                
                LookupManager.RemoveObject("PensideTestLookup", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("VectorTypeLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftVectorSurveillanceSessionStatus")
                _getAccessor().LoadLookup_VsStatus(manager, this);
            
            if (lookup_object == "rftVectorType")
                _getAccessor().LoadLookup_VsVectorType(manager, this);
            
            if (lookup_object == "PensideTestLookup")
                _getAccessor().LoadLookup_PensideTestType(manager, this);
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnoses(manager, this);
            
            if (lookup_object == "VectorTypeLookup")
                _getAccessor().LoadLookup_VectorTypes(manager, this);
            
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
        
            if (_Diagnosis != null) _Diagnosis.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_SessionToVectorType != null) _SessionToVectorType.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_PoolsVectors != null) _PoolsVectors.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Location != null) _Location.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_Samples != null) _Samples.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_FieldTests != null) _FieldTests.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_LabTests != null) _LabTests.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<VsSession>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
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
            private DiagnosisItem.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisItem.Accessor.Instance(m_CS); } }
            private SessionToVectorTypeItem.Accessor SessionToVectorTypeAccessor { get { return eidss.model.Schema.SessionToVectorTypeItem.Accessor.Instance(m_CS); } }
            private Vector.Accessor PoolsVectorsAccessor { get { return eidss.model.Schema.Vector.Accessor.Instance(m_CS); } }
            private GeoLocation.Accessor LocationAccessor { get { return eidss.model.Schema.GeoLocation.Accessor.Instance(m_CS); } }
            private VectorSample.Accessor SamplesAccessor { get { return eidss.model.Schema.VectorSample.Accessor.Instance(m_CS); } }
            private VectorFieldTest.Accessor FieldTestsAccessor { get { return eidss.model.Schema.VectorFieldTest.Accessor.Instance(m_CS); } }
            private VectorLabTest.Accessor LabTestsAccessor { get { return eidss.model.Schema.VectorLabTest.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor VsStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor VsVectorTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private PensideTestLookup.Accessor PensideTestTypeAccessor { get { return eidss.model.Schema.PensideTestLookup.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor DiagnosesAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private VectorTypeLookup.Accessor VectorTypesAccessor { get { return eidss.model.Schema.VectorTypeLookup.Accessor.Instance(m_CS); } }
            

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
            
                MapResultSet[] sets = new MapResultSet[3];
                List<VsSession> objs = new List<VsSession>();
                sets[0] = new MapResultSet(typeof(VsSession), objs);
                
                List<DiagnosisItem> objs_DiagnosisItem = new List<DiagnosisItem>();
                sets[1] = new MapResultSet(typeof(DiagnosisItem), objs_DiagnosisItem);
                
                List<SessionToVectorTypeItem> objs_SessionToVectorTypeItem = new List<SessionToVectorTypeItem>();
                sets[2] = new MapResultSet(typeof(SessionToVectorTypeItem), objs_SessionToVectorTypeItem);
                
        
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
                    
                    obj.Diagnosis.ForEach(c => DiagnosisAccessor._SetupLoad(manager, c));
                        
                    obj.SessionToVectorType.ForEach(c => SessionToVectorTypeAccessor._SetupLoad(manager, c));
                        
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
    
            private void _SetupAddChildHandlerDiagnosis(VsSession obj)
            {
                obj.Diagnosis.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerSessionToVectorType(VsSession obj)
            {
                obj.SessionToVectorType.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerPoolsVectors(VsSession obj)
            {
                obj.PoolsVectors.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerSamples(VsSession obj)
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
            
            private void _SetupAddChildHandlerFieldTests(VsSession obj)
            {
                obj.FieldTests.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerLabTests(VsSession obj)
            {
                obj.LabTests.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadPoolsVectors(VsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadPoolsVectors(manager, obj);
                }
            }
            internal void _LoadPoolsVectors(DbManagerProxy manager, VsSession obj)
            {
                
                obj.PoolsVectors.Clear();
                obj.PoolsVectors.AddRange(PoolsVectorsAccessor.SelectDetailList(manager
                    
                    , obj.idfVectorSurveillanceSession
                    ));
                obj.PoolsVectors.ForEach(c => c.m_ObjectName = _str_PoolsVectors);
                obj.PoolsVectors.AcceptChanges();
                    
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
            
            internal void _LoadSamples(VsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSamples(manager, obj);
                }
            }
            internal void _LoadSamples(DbManagerProxy manager, VsSession obj)
            {
                
                obj.Samples.Clear();
                obj.Samples.AddRange(SamplesAccessor.SelectDetailList(manager
                    
                    , obj.idfVectorSurveillanceSession
                    ));
                obj.Samples.ForEach(c => c.m_ObjectName = _str_Samples);
                obj.Samples.AcceptChanges();
                    
            }
            
            internal void _LoadFieldTests(VsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFieldTests(manager, obj);
                }
            }
            internal void _LoadFieldTests(DbManagerProxy manager, VsSession obj)
            {
                
                obj.FieldTests.Clear();
                obj.FieldTests.AddRange(FieldTestsAccessor.SelectDetailList(manager
                    
                    , obj.idfVectorSurveillanceSession
                    ));
                obj.FieldTests.ForEach(c => c.m_ObjectName = _str_FieldTests);
                obj.FieldTests.AcceptChanges();
                    
            }
            
            internal void _LoadLabTests(VsSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLabTests(manager, obj);
                }
            }
            internal void _LoadLabTests(DbManagerProxy manager, VsSession obj)
            {
                
                obj.LabTests.Clear();
                obj.LabTests.AddRange(LabTestsAccessor.SelectDetailList(manager
                    
                    , obj.idfVectorSurveillanceSession
                    ));
                obj.LabTests.ForEach(c => c.m_ObjectName = _str_LabTests);
                obj.LabTests.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, VsSession obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadPoolsVectors(manager, obj);
                _LoadLocation(manager, obj);
                _LoadSamples(manager, obj);
                _LoadFieldTests(manager, obj);
                _LoadLabTests(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.Samples.ForEach(t => { t.SessionSamples = new Func<VsSession, EditableList<VectorSample>>(c => c.Samples)(obj); } );
                obj.Samples.ForEach(t => { t.Vectors = new Func<VsSession, EditableList<Vector>>(c => c.PoolsVectors)(obj); } );
                obj.Samples.ForEach(t => { t.FieldTests = new Func<VsSession, EditableList<VectorFieldTest>>(c => c.FieldTests)(obj); } );
                obj.Samples.ForEach(t => { t.LabTests = new Func<VsSession, EditableList<VectorLabTest>>(c => c.LabTests)(obj); } );
              obj.InitRoutines(manager);
            
              foreach (var vector in obj.PoolsVectors)
              {
              vector.RecalculateVectorSpecificData();
              foreach (var sample in obj.Samples)
              {
                if (sample.idfVector != vector.idfVector) continue;
                sample.ParentVector = vector;
                sample.isPool = vector.IsPoolVectorType;
              }
              }
            
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerDiagnosis(obj);
                
                _SetupAddChildHandlerSessionToVectorType(obj);
                
                _SetupAddChildHandlerPoolsVectors(obj);
                
                _SetupAddChildHandlerSamples(obj);
                
                _SetupAddChildHandlerFieldTests(obj);
                
                _SetupAddChildHandlerLabTests(obj);
                
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
                    
                        obj.Diagnosis.ForEach(c => DiagnosisAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.SessionToVectorType.ForEach(c => SessionToVectorTypeAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.PoolsVectors.ForEach(c => PoolsVectorsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Samples.ForEach(c => SamplesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.FieldTests.ForEach(c => FieldTestsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.LabTests.ForEach(c => LabTestsAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private VsSession _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
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
                obj.idfVectorSurveillanceSession = (new GetNewIDExtender<VsSession>()).GetScalar(manager, obj);
                obj.datStartDate = new Func<VsSession, DateTime>(c => DateTime.Now)(obj);
                obj.strSessionID = new Func<VsSession, string>(c => "(new)")(obj);
                obj.Location = new Func<VsSession, GeoLocation>(c => LocationAccessor.CreateWithCountry(manager, obj))(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerDiagnosis(obj);
                    
                    _SetupAddChildHandlerSessionToVectorType(obj);
                    
                    _SetupAddChildHandlerPoolsVectors(obj);
                    
                    _SetupAddChildHandlerSamples(obj);
                    
                    _SetupAddChildHandlerFieldTests(obj);
                    
                    _SetupAddChildHandlerLabTests(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.VsStatus = new Func<VsSession, BaseReference>(c => c.VsStatusLookup.Where(l => l.idfsBaseReference == (long)VsStatusEnum.InProgress).SingleOrDefault())(obj);
              obj.VsVectorTypeLookup.ForEach(c =>
              {
              var item = SessionToVectorTypeItem.Accessor.Instance(obj.m_CS).CreateNewT(manager, obj);
              item.idfsVectorType = c.idfsBaseReference;
              item.idfVectorSurveillanceSession = obj.idfVectorSurveillanceSession;
              item.IsChecked = 0;
              item.VectorTypeDefaultName = c.strDefault;
              item.VectorTypeNationalName = c.name;
              obj.SessionToVectorType.Add(item);
              });
            
              obj.InitRoutines(manager);
            
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
            
            public VsSession CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
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
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datStartDate);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
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
                    )).Validate(obj, c => c.intCollectionEffort > 0
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intCollectionEffort);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_strSessionID)
                        {
                    
                obj.PoolsVectors.ForEach(t => { t.strSessionID = new Func<VsSession, string>(c => c.strSessionID)(obj); } );
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                obj.strVectorType = new Func<VsSession, string>(c => c.idfsVectorType.HasValue ? c.VsVectorTypeLookup.FirstOrDefault(t => t.idfsBaseReference == c.idfsVectorType).name : String.Empty)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorSurveillanceStatus)
                        {
                    
                obj.datCloseDate = new Func<VsSession, DateTime?>(c => c.IsClosed ? new DateTime?(DateTime.Now) : null)(obj);
                        }
                    
                        if (e.PropertyName == _str_blnNeedRecalculateFieldTests)
                        {
                    
              using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
              {
              obj.RefreshFieldTests(manager);
              obj.RefreshLabTests();
              }
            
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
                        .Where(c => c.idfsBaseReference == obj.idfsVectorSurveillanceStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftVectorSurveillanceSessionStatus", obj, VsStatusAccessor.GetType(), "rftVectorSurveillanceSessionStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_VsVectorType(DbManagerProxy manager, VsSession obj)
            {
                
                obj.VsVectorTypeLookup.Clear();
                
                obj.VsVectorTypeLookup.Add(VsVectorTypeAccessor.CreateNewT(manager, null));
                
                obj.VsVectorTypeLookup.AddRange(VsVectorTypeAccessor.rftVectorType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorType))
                    
                    .ToList());
                
                if (obj.idfsVectorType != null && obj.idfsVectorType != 0)
                {
                    obj.VsVectorType = obj.VsVectorTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsVectorType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftVectorType", obj, VsVectorTypeAccessor.GetType(), "rftVectorType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_PensideTestType(DbManagerProxy manager, VsSession obj)
            {
                
                obj.PensideTestTypeLookup.Clear();
                
                obj.PensideTestTypeLookup.Add(PensideTestTypeAccessor.CreateNewT(manager, null));
                
                obj.PensideTestTypeLookup.AddRange(PensideTestTypeAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsVectorType == obj.idfsVectorType))
                    
                    .ToList());
                
                if (obj.idfsVectorType != null && obj.idfsVectorType != 0)
                {
                    obj.PensideTestType = obj.PensideTestTypeLookup
                        .Where(c => c.idfsVectorType == obj.idfsVectorType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("PensideTestLookup", obj, PensideTestTypeAccessor.GetType(), "SelectLookupList");
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
                        .Where(c => c.idfsDiagnosis == obj.idfsDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosesAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_VectorTypes(DbManagerProxy manager, VsSession obj)
            {
                
                obj.VectorTypesLookup.Clear();
                
                obj.VectorTypesLookup.Add(VectorTypesAccessor.CreateNewT(manager, null));
                
                obj.VectorTypesLookup.AddRange(VectorTypesAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorType))
                    
                    .ToList());
                
                if (obj.idfsVectorType != null && obj.idfsVectorType != 0)
                {
                    obj.VectorTypes = obj.VectorTypesLookup
                        .Where(c => c.idfsBaseReference == obj.idfsVectorType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("VectorTypeLookup", obj, VectorTypesAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, VsSession obj)
            {
                
                LoadLookup_VsStatus(manager, obj);
                
                LoadLookup_VsVectorType(manager, obj);
                
                LoadLookup_PensideTestType(manager, obj);
                
                LoadLookup_Diagnoses(manager, obj);
                
                LoadLookup_VectorTypes(manager, obj);
                
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
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfVectorSurveillanceSession;
                        
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
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.FieldTests != null)
                    {
                        foreach (var i in obj.FieldTests)
                        {
                            i.MarkToDelete();
                            if (!FieldTestsAccessor.Post(manager, i, true))
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
                                    
                    if (obj.PoolsVectors != null)
                    {
                        foreach (var i in obj.PoolsVectors)
                        {
                            i.MarkToDelete();
                            if (!PoolsVectorsAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    
                    if (obj.SessionToVectorType != null)
                    {
                        foreach (var i in obj.SessionToVectorType)
                        {
                            i.MarkToDelete();
                            if (!SessionToVectorTypeAccessor.Post(manager, i, true))
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
                        if (obj.SessionToVectorType != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.SessionToVectorType)
                                if (!SessionToVectorTypeAccessor.Post(manager, i, true))
                                    return false;
                            obj.SessionToVectorType.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.SessionToVectorType.Remove(c));
                            obj.SessionToVectorType.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._SessionToVectorType != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._SessionToVectorType)
                                if (!SessionToVectorTypeAccessor.Post(manager, i, true))
                                    return false;
                            obj._SessionToVectorType.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._SessionToVectorType.Remove(c));
                            obj._SessionToVectorType.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.PoolsVectors != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.PoolsVectors)
                                if (!PoolsVectorsAccessor.Post(manager, i, true))
                                    return false;
                            obj.PoolsVectors.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.PoolsVectors.Remove(c));
                            obj.PoolsVectors.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._PoolsVectors != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._PoolsVectors)
                                if (!PoolsVectorsAccessor.Post(manager, i, true))
                                    return false;
                            obj._PoolsVectors.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._PoolsVectors.Remove(c));
                            obj._PoolsVectors.AcceptChanges();
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
                        if (obj.FieldTests != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.FieldTests)
                                if (!FieldTestsAccessor.Post(manager, i, true))
                                    return false;
                            obj.FieldTests.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.FieldTests.Remove(c));
                            obj.FieldTests.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._FieldTests != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._FieldTests)
                                if (!FieldTestsAccessor.Post(manager, i, true))
                                    return false;
                            obj._FieldTests.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._FieldTests.Remove(c));
                            obj._FieldTests.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
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
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as VsSession, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VsSession obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "strSessionID", "strSessionID","",
                false
              )).Validate(c => true, obj, obj.strSessionID);
            
                (new RequiredValidator( "idfsVectorSurveillanceStatus", "VsStatus","",
                false
              )).Validate(c => true, obj, obj.idfsVectorSurveillanceStatus);
            
                (new RequiredValidator( "datStartDate", "datStartDate","",
                false
              )).Validate(c => true, obj, obj.datStartDate);
            
                (new RequiredValidator( "Location.LocationDisplayName", "Location.LocationDisplayName","",
                false
              )).Validate(c => true, obj, obj.Location.LocationDisplayName);
            
                (new RequiredValidator( "intCollectionEffort", "intCollectionEffort","",
                false
              )).Validate(c => true, obj, obj.intCollectionEffort);
            
                  
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
                    )).Validate(obj, c => c.intCollectionEffort > 0
                    );
            
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Location != null)
                            LocationAccessor.Validate(manager, obj.Location, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.SessionToVectorType != null)
                            foreach (var i in obj.SessionToVectorType.Where(c => !c.IsMarkedToDelete))
                                SessionToVectorTypeAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.PoolsVectors != null)
                            foreach (var i in obj.PoolsVectors.Where(c => !c.IsMarkedToDelete))
                                PoolsVectorsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Samples != null)
                            foreach (var i in obj.Samples.Where(c => !c.IsMarkedToDelete))
                                SamplesAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FieldTests != null)
                            foreach (var i in obj.FieldTests.Where(c => !c.IsMarkedToDelete))
                                FieldTestsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
                    .AddRequired("strSessionID", c => true);
                    
                obj
                    .AddRequired("VsStatus", c => true);
                    
                obj
                    .AddRequired("datStartDate", c => true);
                    
                obj
                    .Location
                        .AddRequired("LocationDisplayName", c => true);
                        
                obj
                    .AddRequired("intCollectionEffort", c => true);
                    
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
            static Meta()
            {
                
                Sizes.Add(_str_strSessionID, 50);
                Sizes.Add(_str_strFieldSessionID, 50);
                Sizes.Add(_str_strDescription, 500);
                Sizes.Add(_str_strOutbreakID, 200);
                if (!RequiredByField.ContainsKey("strSessionID")) RequiredByField.Add("strSessionID", c => true);
                if (!RequiredByProperty.ContainsKey("strSessionID")) RequiredByProperty.Add("strSessionID", c => true);
                
                if (!RequiredByField.ContainsKey("idfsVectorSurveillanceStatus")) RequiredByField.Add("idfsVectorSurveillanceStatus", c => true);
                if (!RequiredByProperty.ContainsKey("VsStatus")) RequiredByProperty.Add("VsStatus", c => true);
                
                if (!RequiredByField.ContainsKey("datStartDate")) RequiredByField.Add("datStartDate", c => true);
                if (!RequiredByProperty.ContainsKey("datStartDate")) RequiredByProperty.Add("datStartDate", c => true);
                
                if (!RequiredByField.ContainsKey("Location.LocationDisplayName")) RequiredByField.Add("Location.LocationDisplayName", c => true);
                if (!RequiredByProperty.ContainsKey("Location.LocationDisplayName")) RequiredByProperty.Add("Location.LocationDisplayName", c => true);
                
                if (!RequiredByField.ContainsKey("intCollectionEffort")) RequiredByField.Add("intCollectionEffort", c => true);
                if (!RequiredByProperty.ContainsKey("intCollectionEffort")) RequiredByProperty.Add("intCollectionEffort", c => true);
                
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
        #if MONO
        protected Int64? idfsDiagnosis_Original { get { return idfsDiagnosis; } }
        protected Int64? idfsDiagnosis_Previous { get { return idfsDiagnosis; } }
        #else
        protected Int64? idfsDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64? idfsDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_DefaultName)]
        [MapField(_str_DefaultName)]
        public abstract String DefaultName { get; set; }
        #if MONO
        protected String DefaultName_Original { get { return DefaultName; } }
        protected String DefaultName_Previous { get { return DefaultName; } }
        #else
        protected String DefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._defaultName).OriginalValue; } }
        protected String DefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._defaultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_NationalName)]
        [MapField(_str_NationalName)]
        public abstract String NationalName { get; set; }
        #if MONO
        protected String NationalName_Original { get { return NationalName; } }
        protected String NationalName_Previous { get { return NationalName; } }
        #else
        protected String NationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._nationalName).OriginalValue; } }
        protected String NationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._nationalName).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
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
              _name = _str_idfVectorSurveillanceSession, _type = "Int64",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { o.idfVectorSurveillanceSession = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, "Int64", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); }
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
              _name = _str_DefaultName, _type = "String",
              _get_func = o => o.DefaultName,
              _set_func = (o, val) => { o.DefaultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.DefaultName != c.DefaultName || o.IsRIRPropChanged(_str_DefaultName, c)) 
                  m.Add(_str_DefaultName, o.ObjectIdent + _str_DefaultName, "String", o.DefaultName == null ? "" : o.DefaultName.ToString(), o.IsReadOnly(_str_DefaultName), o.IsInvisible(_str_DefaultName), o.IsRequired(_str_DefaultName)); }
              }, 
        
            new field_info {
              _name = _str_NationalName, _type = "String",
              _get_func = o => o.NationalName,
              _set_func = (o, val) => { o.NationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.NationalName != c.NationalName || o.IsRIRPropChanged(_str_NationalName, c)) 
                  m.Add(_str_NationalName, o.ObjectIdent + _str_NationalName, "String", o.NationalName == null ? "" : o.NationalName.ToString(), o.IsReadOnly(_str_NationalName), o.IsInvisible(_str_NationalName), o.IsRequired(_str_NationalName)); }
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
        public override object Clone()
        {
            var ret = base.Clone() as DiagnosisItem;
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
            var ret = base.Clone() as DiagnosisItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
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

      private bool IsRIRPropChanged(string fld, DiagnosisItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public DiagnosisItem()
        {
            
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


        public Dictionary<string, Func<DiagnosisItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<DiagnosisItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<DiagnosisItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<DiagnosisItem, bool>> m_isHiddenPersonalData;
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
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._name] != null) a._set_func(this, form[ObjectIdent + a._name]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._name)) a._set_func(this, form[ObjectIdent + a._name]);} );
      
            if (bParseRelations)
            {
        
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<DiagnosisItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, DiagnosisItem obj)
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

    

            private DiagnosisItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
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
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as DiagnosisItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, DiagnosisItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
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
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, null, pars)),
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class SessionToVectorTypeItem : 
        EditableObject<SessionToVectorTypeItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [LocalizedDisplayName(_str_IsChecked)]
        [MapField(_str_IsChecked)]
        public abstract Int32 IsChecked { get; set; }
        #if MONO
        protected Int32 IsChecked_Original { get { return IsChecked; } }
        protected Int32 IsChecked_Previous { get { return IsChecked; } }
        #else
        protected Int32 IsChecked_Original { get { return ((EditableValue<Int32>)((dynamic)this)._isChecked).OriginalValue; } }
        protected Int32 IsChecked_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._isChecked).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfVectorSurveillanceSessionToVectorType)]
        [MapField(_str_idfVectorSurveillanceSessionToVectorType)]
        public abstract Int64? idfVectorSurveillanceSessionToVectorType { get; set; }
        #if MONO
        protected Int64? idfVectorSurveillanceSessionToVectorType_Original { get { return idfVectorSurveillanceSessionToVectorType; } }
        protected Int64? idfVectorSurveillanceSessionToVectorType_Previous { get { return idfVectorSurveillanceSessionToVectorType; } }
        #else
        protected Int64? idfVectorSurveillanceSessionToVectorType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSessionToVectorType).OriginalValue; } }
        protected Int64? idfVectorSurveillanceSessionToVectorType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSessionToVectorType).PreviousValue; } }
        #endif
                
        [MapField(_str_idfsVectorType), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsVectorType { get; set; }
                
        [LocalizedDisplayName(_str_idfVectorSurveillanceSession)]
        [MapField(_str_idfVectorSurveillanceSession)]
        public abstract Int64? idfVectorSurveillanceSession { get; set; }
        #if MONO
        protected Int64? idfVectorSurveillanceSession_Original { get { return idfVectorSurveillanceSession; } }
        protected Int64? idfVectorSurveillanceSession_Previous { get { return idfVectorSurveillanceSession; } }
        #else
        protected Int64? idfVectorSurveillanceSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).OriginalValue; } }
        protected Int64? idfVectorSurveillanceSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_VectorTypeDefaultName)]
        [MapField(_str_VectorTypeDefaultName)]
        public abstract String VectorTypeDefaultName { get; set; }
        #if MONO
        protected String VectorTypeDefaultName_Original { get { return VectorTypeDefaultName; } }
        protected String VectorTypeDefaultName_Previous { get { return VectorTypeDefaultName; } }
        #else
        protected String VectorTypeDefaultName_Original { get { return ((EditableValue<String>)((dynamic)this)._vectorTypeDefaultName).OriginalValue; } }
        protected String VectorTypeDefaultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._vectorTypeDefaultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_VectorTypeNationalName)]
        [MapField(_str_VectorTypeNationalName)]
        public abstract String VectorTypeNationalName { get; set; }
        #if MONO
        protected String VectorTypeNationalName_Original { get { return VectorTypeNationalName; } }
        protected String VectorTypeNationalName_Previous { get { return VectorTypeNationalName; } }
        #else
        protected String VectorTypeNationalName_Original { get { return ((EditableValue<String>)((dynamic)this)._vectorTypeNationalName).OriginalValue; } }
        protected String VectorTypeNationalName_Previous { get { return ((EditableValue<String>)((dynamic)this)._vectorTypeNationalName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCode)]
        [MapField(_str_strCode)]
        public abstract String strCode { get; set; }
        #if MONO
        protected String strCode_Original { get { return strCode; } }
        protected String strCode_Previous { get { return strCode; } }
        #else
        protected String strCode_Original { get { return ((EditableValue<String>)((dynamic)this)._strCode).OriginalValue; } }
        protected String strCode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_bitCollectionByPool)]
        [MapField(_str_bitCollectionByPool)]
        public abstract Boolean bitCollectionByPool { get; set; }
        #if MONO
        protected Boolean bitCollectionByPool_Original { get { return bitCollectionByPool; } }
        protected Boolean bitCollectionByPool_Previous { get { return bitCollectionByPool; } }
        #else
        protected Boolean bitCollectionByPool_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._bitCollectionByPool).OriginalValue; } }
        protected Boolean bitCollectionByPool_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._bitCollectionByPool).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<SessionToVectorTypeItem, object> _get_func;
            internal Action<SessionToVectorTypeItem, string> _set_func;
            internal Action<SessionToVectorTypeItem, SessionToVectorTypeItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_IsChecked = "IsChecked";
        internal const string _str_idfVectorSurveillanceSessionToVectorType = "idfVectorSurveillanceSessionToVectorType";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_VectorTypeDefaultName = "VectorTypeDefaultName";
        internal const string _str_VectorTypeNationalName = "VectorTypeNationalName";
        internal const string _str_strCode = "strCode";
        internal const string _str_bitCollectionByPool = "bitCollectionByPool";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_IsChecked, _type = "Int32",
              _get_func = o => o.IsChecked,
              _set_func = (o, val) => { o.IsChecked = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.IsChecked != c.IsChecked || o.IsRIRPropChanged(_str_IsChecked, c)) 
                  m.Add(_str_IsChecked, o.ObjectIdent + _str_IsChecked, "Int32", o.IsChecked == null ? "" : o.IsChecked.ToString(), o.IsReadOnly(_str_IsChecked), o.IsInvisible(_str_IsChecked), o.IsRequired(_str_IsChecked)); }
              }, 
        
            new field_info {
              _name = _str_idfVectorSurveillanceSessionToVectorType, _type = "Int64?",
              _get_func = o => o.idfVectorSurveillanceSessionToVectorType,
              _set_func = (o, val) => { o.idfVectorSurveillanceSessionToVectorType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSessionToVectorType != c.idfVectorSurveillanceSessionToVectorType || o.IsRIRPropChanged(_str_idfVectorSurveillanceSessionToVectorType, c)) 
                  m.Add(_str_idfVectorSurveillanceSessionToVectorType, o.ObjectIdent + _str_idfVectorSurveillanceSessionToVectorType, "Int64?", o.idfVectorSurveillanceSessionToVectorType == null ? "" : o.idfVectorSurveillanceSessionToVectorType.ToString(), o.IsReadOnly(_str_idfVectorSurveillanceSessionToVectorType), o.IsInvisible(_str_idfVectorSurveillanceSessionToVectorType), o.IsRequired(_str_idfVectorSurveillanceSessionToVectorType)); }
              }, 
        
            new field_info {
              _name = _str_idfsVectorType, _type = "Int64",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { o.idfsVectorType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) 
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, "Int64", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType)); }
              }, 
        
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _type = "Int64?",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { o.idfVectorSurveillanceSession = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, "Int64?", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); }
              }, 
        
            new field_info {
              _name = _str_VectorTypeDefaultName, _type = "String",
              _get_func = o => o.VectorTypeDefaultName,
              _set_func = (o, val) => { o.VectorTypeDefaultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.VectorTypeDefaultName != c.VectorTypeDefaultName || o.IsRIRPropChanged(_str_VectorTypeDefaultName, c)) 
                  m.Add(_str_VectorTypeDefaultName, o.ObjectIdent + _str_VectorTypeDefaultName, "String", o.VectorTypeDefaultName == null ? "" : o.VectorTypeDefaultName.ToString(), o.IsReadOnly(_str_VectorTypeDefaultName), o.IsInvisible(_str_VectorTypeDefaultName), o.IsRequired(_str_VectorTypeDefaultName)); }
              }, 
        
            new field_info {
              _name = _str_VectorTypeNationalName, _type = "String",
              _get_func = o => o.VectorTypeNationalName,
              _set_func = (o, val) => { o.VectorTypeNationalName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.VectorTypeNationalName != c.VectorTypeNationalName || o.IsRIRPropChanged(_str_VectorTypeNationalName, c)) 
                  m.Add(_str_VectorTypeNationalName, o.ObjectIdent + _str_VectorTypeNationalName, "String", o.VectorTypeNationalName == null ? "" : o.VectorTypeNationalName.ToString(), o.IsReadOnly(_str_VectorTypeNationalName), o.IsInvisible(_str_VectorTypeNationalName), o.IsRequired(_str_VectorTypeNationalName)); }
              }, 
        
            new field_info {
              _name = _str_strCode, _type = "String",
              _get_func = o => o.strCode,
              _set_func = (o, val) => { o.strCode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCode != c.strCode || o.IsRIRPropChanged(_str_strCode, c)) 
                  m.Add(_str_strCode, o.ObjectIdent + _str_strCode, "String", o.strCode == null ? "" : o.strCode.ToString(), o.IsReadOnly(_str_strCode), o.IsInvisible(_str_strCode), o.IsRequired(_str_strCode)); }
              }, 
        
            new field_info {
              _name = _str_bitCollectionByPool, _type = "Boolean",
              _get_func = o => o.bitCollectionByPool,
              _set_func = (o, val) => { o.bitCollectionByPool = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
                if (o.bitCollectionByPool != c.bitCollectionByPool || o.IsRIRPropChanged(_str_bitCollectionByPool, c)) 
                  m.Add(_str_bitCollectionByPool, o.ObjectIdent + _str_bitCollectionByPool, "Boolean", o.bitCollectionByPool == null ? "" : o.bitCollectionByPool.ToString(), o.IsReadOnly(_str_bitCollectionByPool), o.IsInvisible(_str_bitCollectionByPool), o.IsRequired(_str_bitCollectionByPool)); }
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
            SessionToVectorTypeItem obj = (SessionToVectorTypeItem)o;
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
        internal string m_ObjectName = "SessionToVectorTypeItem";

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
            var ret = base.Clone() as SessionToVectorTypeItem;
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
            var ret = base.Clone() as SessionToVectorTypeItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public SessionToVectorTypeItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as SessionToVectorTypeItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsVectorType; } }
        public string KeyName { get { return "idfsVectorType"; } }
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

      private bool IsRIRPropChanged(string fld, SessionToVectorTypeItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public SessionToVectorTypeItem()
        {
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SessionToVectorTypeItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SessionToVectorTypeItem_PropertyChanged);
        }
        private void SessionToVectorTypeItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as SessionToVectorTypeItem).Changed(e.PropertyName);
            
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
            SessionToVectorTypeItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            SessionToVectorTypeItem obj = this;
            
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


        public Dictionary<string, Func<SessionToVectorTypeItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<SessionToVectorTypeItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<SessionToVectorTypeItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<SessionToVectorTypeItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<SessionToVectorTypeItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<SessionToVectorTypeItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~SessionToVectorTypeItem()
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
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._name] != null) a._set_func(this, form[ObjectIdent + a._name]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._name)) a._set_func(this, form[ObjectIdent + a._name]);} );
      
            if (bParseRelations)
            {
        
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<SessionToVectorTypeItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(SessionToVectorTypeItem obj);
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

            
            public virtual SessionToVectorTypeItem SelectByKey(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                )
            {
                return _SelectByKey(manager
                    , idfVectorSurveillanceSession
                    , null, null
                    );
            }
            
      
            private SessionToVectorTypeItem _SelectByKey(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, SessionToVectorTypeItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, SessionToVectorTypeItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private SessionToVectorTypeItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    SessionToVectorTypeItem obj = SessionToVectorTypeItem.CreateInstance();
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

            
            public SessionToVectorTypeItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public SessionToVectorTypeItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(SessionToVectorTypeItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(SessionToVectorTypeItem obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, SessionToVectorTypeItem obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spVectorSurveillanceSessionToVectorType_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput("idfVectorSurveillanceSessionToVectorType")] SessionToVectorTypeItem obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput("idfVectorSurveillanceSessionToVectorType")] SessionToVectorTypeItem obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    SessionToVectorTypeItem bo = obj as SessionToVectorTypeItem;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as SessionToVectorTypeItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, SessionToVectorTypeItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (!obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(SessionToVectorTypeItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, SessionToVectorTypeItem obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as SessionToVectorTypeItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, SessionToVectorTypeItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(SessionToVectorTypeItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(SessionToVectorTypeItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as SessionToVectorTypeItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as SessionToVectorTypeItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "SessionToVectorTypeItemDetail"; } }
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
            public static string spPost = "spVectorSurveillanceSessionToVectorType_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<SessionToVectorTypeItem, bool>> RequiredByField = new Dictionary<string, Func<SessionToVectorTypeItem, bool>>();
            public static Dictionary<string, Func<SessionToVectorTypeItem, bool>> RequiredByProperty = new Dictionary<string, Func<SessionToVectorTypeItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_VectorTypeDefaultName, 2000);
                Sizes.Add(_str_VectorTypeNationalName, 2000);
                Sizes.Add(_str_strCode, 50);
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, null, pars)),
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
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((SessionToVectorTypeItem)c).MarkToDelete() && ObjectAccessor.PostInterface<SessionToVectorTypeItem>().Post(manager, (SessionToVectorTypeItem)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SessionToVectorTypeItem>().Post(manager, (SessionToVectorTypeItem)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<SessionToVectorTypeItem>().Post(manager, (SessionToVectorTypeItem)c), c),
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
	