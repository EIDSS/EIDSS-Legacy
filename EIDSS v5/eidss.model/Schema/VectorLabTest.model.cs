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
    public abstract partial class VectorLabTest : 
        EditableObject<VectorLabTest>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfTesting), NonUpdatable, PrimaryKey]
        public abstract Int64 idfTesting { get; set; }
                
        [LocalizedDisplayName(_str_idfsTestType)]
        [MapField(_str_idfsTestType)]
        public abstract Int64? idfsTestType { get; set; }
        #if MONO
        protected Int64? idfsTestType_Original { get { return idfsTestType; } }
        protected Int64? idfsTestType_Previous { get { return idfsTestType; } }
        #else
        protected Int64? idfsTestType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestType).OriginalValue; } }
        protected Int64? idfsTestType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("TestName")]
        [MapField(_str_strTestName)]
        public abstract String strTestName { get; set; }
        #if MONO
        protected String strTestName_Original { get { return strTestName; } }
        protected String strTestName_Previous { get { return strTestName; } }
        #else
        protected String strTestName_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestName).OriginalValue; } }
        protected String strTestName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfMaterial)]
        [MapField(_str_idfMaterial)]
        public abstract Int64 idfMaterial { get; set; }
        #if MONO
        protected Int64 idfMaterial_Original { get { return idfMaterial; } }
        protected Int64 idfMaterial_Previous { get { return idfMaterial; } }
        #else
        protected Int64 idfMaterial_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).OriginalValue; } }
        protected Int64 idfMaterial_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfVector)]
        [MapField(_str_idfVector)]
        public abstract Int64? idfVector { get; set; }
        #if MONO
        protected Int64? idfVector_Original { get { return idfVector; } }
        protected Int64? idfVector_Previous { get { return idfVector; } }
        #else
        protected Int64? idfVector_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).OriginalValue; } }
        protected Int64? idfVector_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("Vector.strVectorID")]
        [MapField(_str_strVectorID)]
        public abstract String strVectorID { get; set; }
        #if MONO
        protected String strVectorID_Original { get { return strVectorID; } }
        protected String strVectorID_Previous { get { return strVectorID; } }
        #else
        protected String strVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).OriginalValue; } }
        protected String strVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("VectorSample.strBarcode")]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        #if MONO
        protected String strBarcode_Original { get { return strBarcode; } }
        protected String strBarcode_Previous { get { return strBarcode; } }
        #else
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("VectorSample.strFieldBarcode")]
        [MapField(_str_strFieldBarcode)]
        public abstract String strFieldBarcode { get; set; }
        #if MONO
        protected String strFieldBarcode_Original { get { return strFieldBarcode; } }
        protected String strFieldBarcode_Previous { get { return strFieldBarcode; } }
        #else
        protected String strFieldBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).OriginalValue; } }
        protected String strFieldBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSpecimenType)]
        [MapField(_str_idfsSpecimenType)]
        public abstract Int64 idfsSpecimenType { get; set; }
        #if MONO
        protected Int64 idfsSpecimenType_Original { get { return idfsSpecimenType; } }
        protected Int64 idfsSpecimenType_Previous { get { return idfsSpecimenType; } }
        #else
        protected Int64 idfsSpecimenType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSpecimenType).OriginalValue; } }
        protected Int64 idfsSpecimenType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSpecimenType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsSpecimenType")]
        [MapField(_str_strSampleType)]
        public abstract String strSampleType { get; set; }
        #if MONO
        protected String strSampleType_Original { get { return strSampleType; } }
        protected String strSampleType_Previous { get { return strSampleType; } }
        #else
        protected String strSampleType_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleType).OriginalValue; } }
        protected String strSampleType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datFieldCollectionDate)]
        [MapField(_str_datFieldCollectionDate)]
        public abstract DateTime? datFieldCollectionDate { get; set; }
        #if MONO
        protected DateTime? datFieldCollectionDate_Original { get { return datFieldCollectionDate; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return datFieldCollectionDate; } }
        #else
        protected DateTime? datFieldCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).OriginalValue; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datAccession)]
        [MapField(_str_datAccession)]
        public abstract DateTime? datAccession { get; set; }
        #if MONO
        protected DateTime? datAccession_Original { get { return datAccession; } }
        protected DateTime? datAccession_Previous { get { return datAccession; } }
        #else
        protected DateTime? datAccession_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).OriginalValue; } }
        protected DateTime? datAccession_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfPensideTestTestDate")]
        [MapField(_str_datStartedDate)]
        public abstract DateTime? datStartedDate { get; set; }
        #if MONO
        protected DateTime? datStartedDate_Original { get { return datStartedDate; } }
        protected DateTime? datStartedDate_Previous { get { return datStartedDate; } }
        #else
        protected DateTime? datStartedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartedDate).OriginalValue; } }
        protected DateTime? datStartedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartedDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsTestForDiseaseType)]
        [MapField(_str_idfsTestForDiseaseType)]
        public abstract Int64? idfsTestForDiseaseType { get; set; }
        #if MONO
        protected Int64? idfsTestForDiseaseType_Original { get { return idfsTestForDiseaseType; } }
        protected Int64? idfsTestForDiseaseType_Previous { get { return idfsTestForDiseaseType; } }
        #else
        protected Int64? idfsTestForDiseaseType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestForDiseaseType).OriginalValue; } }
        protected Int64? idfsTestForDiseaseType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestForDiseaseType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfPensideTestTestCategory")]
        [MapField(_str_strTestCategory)]
        public abstract String strTestCategory { get; set; }
        #if MONO
        protected String strTestCategory_Original { get { return strTestCategory; } }
        protected String strTestCategory_Previous { get { return strTestCategory; } }
        #else
        protected String strTestCategory_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestCategory).OriginalValue; } }
        protected String strTestCategory_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestCategory).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfTestedByPerson)]
        [MapField(_str_idfTestedByPerson)]
        public abstract Int64? idfTestedByPerson { get; set; }
        #if MONO
        protected Int64? idfTestedByPerson_Original { get { return idfTestedByPerson; } }
        protected Int64? idfTestedByPerson_Previous { get { return idfTestedByPerson; } }
        #else
        protected Int64? idfTestedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByPerson).OriginalValue; } }
        protected Int64? idfTestedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfPensideTestTestedByPerson")]
        [MapField(_str_strTestedByPerson)]
        public abstract String strTestedByPerson { get; set; }
        #if MONO
        protected String strTestedByPerson_Original { get { return strTestedByPerson; } }
        protected String strTestedByPerson_Previous { get { return strTestedByPerson; } }
        #else
        protected String strTestedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestedByPerson).OriginalValue; } }
        protected String strTestedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfTestedByOffice)]
        [MapField(_str_idfTestedByOffice)]
        public abstract Int64? idfTestedByOffice { get; set; }
        #if MONO
        protected Int64? idfTestedByOffice_Original { get { return idfTestedByOffice; } }
        protected Int64? idfTestedByOffice_Previous { get { return idfTestedByOffice; } }
        #else
        protected Int64? idfTestedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByOffice).OriginalValue; } }
        protected Int64? idfTestedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfPensideTestTestedByOffice")]
        [MapField(_str_strTestedByOffice)]
        public abstract String strTestedByOffice { get; set; }
        #if MONO
        protected String strTestedByOffice_Original { get { return strTestedByOffice; } }
        protected String strTestedByOffice_Previous { get { return strTestedByOffice; } }
        #else
        protected String strTestedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestedByOffice).OriginalValue; } }
        protected String strTestedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsTestResult)]
        [MapField(_str_idfsTestResult)]
        public abstract Int64? idfsTestResult { get; set; }
        #if MONO
        protected Int64? idfsTestResult_Original { get { return idfsTestResult; } }
        protected Int64? idfsTestResult_Previous { get { return idfsTestResult; } }
        #else
        protected Int64? idfsTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).OriginalValue; } }
        protected Int64? idfsTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsPensideTestResult")]
        [MapField(_str_strTestResultName)]
        public abstract String strTestResultName { get; set; }
        #if MONO
        protected String strTestResultName_Original { get { return strTestResultName; } }
        protected String strTestResultName_Previous { get { return strTestResultName; } }
        #else
        protected String strTestResultName_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestResultName).OriginalValue; } }
        protected String strTestResultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestResultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsDiagnosis)]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64 idfsDiagnosis { get; set; }
        #if MONO
        protected Int64 idfsDiagnosis_Original { get { return idfsDiagnosis; } }
        protected Int64 idfsDiagnosis_Previous { get { return idfsDiagnosis; } }
        #else
        protected Int64 idfsDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64 idfsDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("FT.strDisease")]
        [MapField(_str_strDiagnosisName)]
        public abstract String strDiagnosisName { get; set; }
        #if MONO
        protected String strDiagnosisName_Original { get { return strDiagnosisName; } }
        protected String strDiagnosisName_Previous { get { return strDiagnosisName; } }
        #else
        protected String strDiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisName).OriginalValue; } }
        protected String strDiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsVectorType)]
        [MapField(_str_idfsVectorType)]
        public abstract Int64 idfsVectorType { get; set; }
        #if MONO
        protected Int64 idfsVectorType_Original { get { return idfsVectorType; } }
        protected Int64 idfsVectorType_Previous { get { return idfsVectorType; } }
        #else
        protected Int64 idfsVectorType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).OriginalValue; } }
        protected Int64 idfsVectorType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<VectorLabTest, object> _get_func;
            internal Action<VectorLabTest, string> _set_func;
            internal Action<VectorLabTest, VectorLabTest, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_idfsTestType = "idfsTestType";
        internal const string _str_strTestName = "strTestName";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_idfVector = "idfVector";
        internal const string _str_strVectorID = "strVectorID";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_idfsSpecimenType = "idfsSpecimenType";
        internal const string _str_strSampleType = "strSampleType";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_datStartedDate = "datStartedDate";
        internal const string _str_idfsTestForDiseaseType = "idfsTestForDiseaseType";
        internal const string _str_strTestCategory = "strTestCategory";
        internal const string _str_idfTestedByPerson = "idfTestedByPerson";
        internal const string _str_strTestedByPerson = "strTestedByPerson";
        internal const string _str_idfTestedByOffice = "idfTestedByOffice";
        internal const string _str_strTestedByOffice = "strTestedByOffice";
        internal const string _str_idfsTestResult = "idfsTestResult";
        internal const string _str_strTestResultName = "strTestResultName";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_strDiagnosisName = "strDiagnosisName";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_TypeLabTestToResultMatrix = "TypeLabTestToResultMatrix";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfTesting, _type = "Int64",
              _get_func = o => o.idfTesting,
              _set_func = (o, val) => { o.idfTesting = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTesting != c.idfTesting || o.IsRIRPropChanged(_str_idfTesting, c)) 
                  m.Add(_str_idfTesting, o.ObjectIdent + _str_idfTesting, "Int64", o.idfTesting == null ? "" : o.idfTesting.ToString(), o.IsReadOnly(_str_idfTesting), o.IsInvisible(_str_idfTesting), o.IsRequired(_str_idfTesting)); }
              }, 
        
            new field_info {
              _name = _str_idfsTestType, _type = "Int64?",
              _get_func = o => o.idfsTestType,
              _set_func = (o, val) => { o.idfsTestType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestType != c.idfsTestType || o.IsRIRPropChanged(_str_idfsTestType, c)) 
                  m.Add(_str_idfsTestType, o.ObjectIdent + _str_idfsTestType, "Int64?", o.idfsTestType == null ? "" : o.idfsTestType.ToString(), o.IsReadOnly(_str_idfsTestType), o.IsInvisible(_str_idfsTestType), o.IsRequired(_str_idfsTestType)); }
              }, 
        
            new field_info {
              _name = _str_strTestName, _type = "String",
              _get_func = o => o.strTestName,
              _set_func = (o, val) => { o.strTestName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strTestName != c.strTestName || o.IsRIRPropChanged(_str_strTestName, c)) 
                  m.Add(_str_strTestName, o.ObjectIdent + _str_strTestName, "String", o.strTestName == null ? "" : o.strTestName.ToString(), o.IsReadOnly(_str_strTestName), o.IsInvisible(_str_strTestName), o.IsRequired(_str_strTestName)); }
              }, 
        
            new field_info {
              _name = _str_idfMaterial, _type = "Int64",
              _get_func = o => o.idfMaterial,
              _set_func = (o, val) => { o.idfMaterial = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMaterial != c.idfMaterial || o.IsRIRPropChanged(_str_idfMaterial, c)) 
                  m.Add(_str_idfMaterial, o.ObjectIdent + _str_idfMaterial, "Int64", o.idfMaterial == null ? "" : o.idfMaterial.ToString(), o.IsReadOnly(_str_idfMaterial), o.IsInvisible(_str_idfMaterial), o.IsRequired(_str_idfMaterial)); }
              }, 
        
            new field_info {
              _name = _str_idfVector, _type = "Int64?",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { o.idfVector = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, "Int64?", o.idfVector == null ? "" : o.idfVector.ToString(), o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); }
              }, 
        
            new field_info {
              _name = _str_strVectorID, _type = "String",
              _get_func = o => o.strVectorID,
              _set_func = (o, val) => { o.strVectorID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorID != c.strVectorID || o.IsRIRPropChanged(_str_strVectorID, c)) 
                  m.Add(_str_strVectorID, o.ObjectIdent + _str_strVectorID, "String", o.strVectorID == null ? "" : o.strVectorID.ToString(), o.IsReadOnly(_str_strVectorID), o.IsInvisible(_str_strVectorID), o.IsRequired(_str_strVectorID)); }
              }, 
        
            new field_info {
              _name = _str_strBarcode, _type = "String",
              _get_func = o => o.strBarcode,
              _set_func = (o, val) => { o.strBarcode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strBarcode != c.strBarcode || o.IsRIRPropChanged(_str_strBarcode, c)) 
                  m.Add(_str_strBarcode, o.ObjectIdent + _str_strBarcode, "String", o.strBarcode == null ? "" : o.strBarcode.ToString(), o.IsReadOnly(_str_strBarcode), o.IsInvisible(_str_strBarcode), o.IsRequired(_str_strBarcode)); }
              }, 
        
            new field_info {
              _name = _str_strFieldBarcode, _type = "String",
              _get_func = o => o.strFieldBarcode,
              _set_func = (o, val) => { o.strFieldBarcode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldBarcode != c.strFieldBarcode || o.IsRIRPropChanged(_str_strFieldBarcode, c)) 
                  m.Add(_str_strFieldBarcode, o.ObjectIdent + _str_strFieldBarcode, "String", o.strFieldBarcode == null ? "" : o.strFieldBarcode.ToString(), o.IsReadOnly(_str_strFieldBarcode), o.IsInvisible(_str_strFieldBarcode), o.IsRequired(_str_strFieldBarcode)); }
              }, 
        
            new field_info {
              _name = _str_idfsSpecimenType, _type = "Int64",
              _get_func = o => o.idfsSpecimenType,
              _set_func = (o, val) => { o.idfsSpecimenType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpecimenType != c.idfsSpecimenType || o.IsRIRPropChanged(_str_idfsSpecimenType, c)) 
                  m.Add(_str_idfsSpecimenType, o.ObjectIdent + _str_idfsSpecimenType, "Int64", o.idfsSpecimenType == null ? "" : o.idfsSpecimenType.ToString(), o.IsReadOnly(_str_idfsSpecimenType), o.IsInvisible(_str_idfsSpecimenType), o.IsRequired(_str_idfsSpecimenType)); }
              }, 
        
            new field_info {
              _name = _str_strSampleType, _type = "String",
              _get_func = o => o.strSampleType,
              _set_func = (o, val) => { o.strSampleType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSampleType != c.strSampleType || o.IsRIRPropChanged(_str_strSampleType, c)) 
                  m.Add(_str_strSampleType, o.ObjectIdent + _str_strSampleType, "String", o.strSampleType == null ? "" : o.strSampleType.ToString(), o.IsReadOnly(_str_strSampleType), o.IsInvisible(_str_strSampleType), o.IsRequired(_str_strSampleType)); }
              }, 
        
            new field_info {
              _name = _str_datFieldCollectionDate, _type = "DateTime?",
              _get_func = o => o.datFieldCollectionDate,
              _set_func = (o, val) => { o.datFieldCollectionDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datFieldCollectionDate != c.datFieldCollectionDate || o.IsRIRPropChanged(_str_datFieldCollectionDate, c)) 
                  m.Add(_str_datFieldCollectionDate, o.ObjectIdent + _str_datFieldCollectionDate, "DateTime?", o.datFieldCollectionDate == null ? "" : o.datFieldCollectionDate.ToString(), o.IsReadOnly(_str_datFieldCollectionDate), o.IsInvisible(_str_datFieldCollectionDate), o.IsRequired(_str_datFieldCollectionDate)); }
              }, 
        
            new field_info {
              _name = _str_datAccession, _type = "DateTime?",
              _get_func = o => o.datAccession,
              _set_func = (o, val) => { o.datAccession = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datAccession != c.datAccession || o.IsRIRPropChanged(_str_datAccession, c)) 
                  m.Add(_str_datAccession, o.ObjectIdent + _str_datAccession, "DateTime?", o.datAccession == null ? "" : o.datAccession.ToString(), o.IsReadOnly(_str_datAccession), o.IsInvisible(_str_datAccession), o.IsRequired(_str_datAccession)); }
              }, 
        
            new field_info {
              _name = _str_datStartedDate, _type = "DateTime?",
              _get_func = o => o.datStartedDate,
              _set_func = (o, val) => { o.datStartedDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datStartedDate != c.datStartedDate || o.IsRIRPropChanged(_str_datStartedDate, c)) 
                  m.Add(_str_datStartedDate, o.ObjectIdent + _str_datStartedDate, "DateTime?", o.datStartedDate == null ? "" : o.datStartedDate.ToString(), o.IsReadOnly(_str_datStartedDate), o.IsInvisible(_str_datStartedDate), o.IsRequired(_str_datStartedDate)); }
              }, 
        
            new field_info {
              _name = _str_idfsTestForDiseaseType, _type = "Int64?",
              _get_func = o => o.idfsTestForDiseaseType,
              _set_func = (o, val) => { o.idfsTestForDiseaseType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestForDiseaseType != c.idfsTestForDiseaseType || o.IsRIRPropChanged(_str_idfsTestForDiseaseType, c)) 
                  m.Add(_str_idfsTestForDiseaseType, o.ObjectIdent + _str_idfsTestForDiseaseType, "Int64?", o.idfsTestForDiseaseType == null ? "" : o.idfsTestForDiseaseType.ToString(), o.IsReadOnly(_str_idfsTestForDiseaseType), o.IsInvisible(_str_idfsTestForDiseaseType), o.IsRequired(_str_idfsTestForDiseaseType)); }
              }, 
        
            new field_info {
              _name = _str_strTestCategory, _type = "String",
              _get_func = o => o.strTestCategory,
              _set_func = (o, val) => { o.strTestCategory = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strTestCategory != c.strTestCategory || o.IsRIRPropChanged(_str_strTestCategory, c)) 
                  m.Add(_str_strTestCategory, o.ObjectIdent + _str_strTestCategory, "String", o.strTestCategory == null ? "" : o.strTestCategory.ToString(), o.IsReadOnly(_str_strTestCategory), o.IsInvisible(_str_strTestCategory), o.IsRequired(_str_strTestCategory)); }
              }, 
        
            new field_info {
              _name = _str_idfTestedByPerson, _type = "Int64?",
              _get_func = o => o.idfTestedByPerson,
              _set_func = (o, val) => { o.idfTestedByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByPerson != c.idfTestedByPerson || o.IsRIRPropChanged(_str_idfTestedByPerson, c)) 
                  m.Add(_str_idfTestedByPerson, o.ObjectIdent + _str_idfTestedByPerson, "Int64?", o.idfTestedByPerson == null ? "" : o.idfTestedByPerson.ToString(), o.IsReadOnly(_str_idfTestedByPerson), o.IsInvisible(_str_idfTestedByPerson), o.IsRequired(_str_idfTestedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_strTestedByPerson, _type = "String",
              _get_func = o => o.strTestedByPerson,
              _set_func = (o, val) => { o.strTestedByPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strTestedByPerson != c.strTestedByPerson || o.IsRIRPropChanged(_str_strTestedByPerson, c)) 
                  m.Add(_str_strTestedByPerson, o.ObjectIdent + _str_strTestedByPerson, "String", o.strTestedByPerson == null ? "" : o.strTestedByPerson.ToString(), o.IsReadOnly(_str_strTestedByPerson), o.IsInvisible(_str_strTestedByPerson), o.IsRequired(_str_strTestedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfTestedByOffice, _type = "Int64?",
              _get_func = o => o.idfTestedByOffice,
              _set_func = (o, val) => { o.idfTestedByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByOffice != c.idfTestedByOffice || o.IsRIRPropChanged(_str_idfTestedByOffice, c)) 
                  m.Add(_str_idfTestedByOffice, o.ObjectIdent + _str_idfTestedByOffice, "Int64?", o.idfTestedByOffice == null ? "" : o.idfTestedByOffice.ToString(), o.IsReadOnly(_str_idfTestedByOffice), o.IsInvisible(_str_idfTestedByOffice), o.IsRequired(_str_idfTestedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_strTestedByOffice, _type = "String",
              _get_func = o => o.strTestedByOffice,
              _set_func = (o, val) => { o.strTestedByOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strTestedByOffice != c.strTestedByOffice || o.IsRIRPropChanged(_str_strTestedByOffice, c)) 
                  m.Add(_str_strTestedByOffice, o.ObjectIdent + _str_strTestedByOffice, "String", o.strTestedByOffice == null ? "" : o.strTestedByOffice.ToString(), o.IsReadOnly(_str_strTestedByOffice), o.IsInvisible(_str_strTestedByOffice), o.IsRequired(_str_strTestedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfsTestResult, _type = "Int64?",
              _get_func = o => o.idfsTestResult,
              _set_func = (o, val) => { o.idfsTestResult = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_idfsTestResult, c)) 
                  m.Add(_str_idfsTestResult, o.ObjectIdent + _str_idfsTestResult, "Int64?", o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(), o.IsReadOnly(_str_idfsTestResult), o.IsInvisible(_str_idfsTestResult), o.IsRequired(_str_idfsTestResult)); }
              }, 
        
            new field_info {
              _name = _str_strTestResultName, _type = "String",
              _get_func = o => o.strTestResultName,
              _set_func = (o, val) => { o.strTestResultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strTestResultName != c.strTestResultName || o.IsRIRPropChanged(_str_strTestResultName, c)) 
                  m.Add(_str_strTestResultName, o.ObjectIdent + _str_strTestResultName, "String", o.strTestResultName == null ? "" : o.strTestResultName.ToString(), o.IsReadOnly(_str_strTestResultName), o.IsInvisible(_str_strTestResultName), o.IsRequired(_str_strTestResultName)); }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosis, _type = "Int64",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { o.idfsDiagnosis = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, "Int64", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_strDiagnosisName, _type = "String",
              _get_func = o => o.strDiagnosisName,
              _set_func = (o, val) => { o.strDiagnosisName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strDiagnosisName != c.strDiagnosisName || o.IsRIRPropChanged(_str_strDiagnosisName, c)) 
                  m.Add(_str_strDiagnosisName, o.ObjectIdent + _str_strDiagnosisName, "String", o.strDiagnosisName == null ? "" : o.strDiagnosisName.ToString(), o.IsReadOnly(_str_strDiagnosisName), o.IsInvisible(_str_strDiagnosisName), o.IsRequired(_str_strDiagnosisName)); }
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
              _name = _str_TypeLabTestToResultMatrix, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.TypeLabTestToResultMatrix.Count != c.TypeLabTestToResultMatrix.Count || o.IsReadOnly(_str_TypeLabTestToResultMatrix) != c.IsReadOnly(_str_TypeLabTestToResultMatrix) || o.IsInvisible(_str_TypeLabTestToResultMatrix) != c.IsInvisible(_str_TypeLabTestToResultMatrix) || o.IsRequired(_str_TypeLabTestToResultMatrix) != c.IsRequired(_str_TypeLabTestToResultMatrix)) 
                  m.Add(_str_TypeLabTestToResultMatrix, o.ObjectIdent + _str_TypeLabTestToResultMatrix, "Child", o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(), o.IsReadOnly(_str_TypeLabTestToResultMatrix), o.IsInvisible(_str_TypeLabTestToResultMatrix), o.IsRequired(_str_TypeLabTestToResultMatrix)); }
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
            VectorLabTest obj = (VectorLabTest)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(TypeLabTestToResultMatrixLookup), "", _str_idfsTestResult)]
        public EditableList<TypeLabTestToResultMatrixLookup> TypeLabTestToResultMatrix
        {
            get 
            {   
                return _TypeLabTestToResultMatrix; 
            }
            set 
            {
                _TypeLabTestToResultMatrix = value;
            }
        }
        protected EditableList<TypeLabTestToResultMatrixLookup> _TypeLabTestToResultMatrix = new EditableList<TypeLabTestToResultMatrixLookup>();
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VectorLabTest";

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
        TypeLabTestToResultMatrix.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as VectorLabTest;
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
            var ret = base.Clone() as VectorLabTest;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public VectorLabTest CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VectorLabTest;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfTesting; } }
        public string KeyName { get { return "idfTesting"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || TypeLabTestToResultMatrix.IsDirty
                    || TypeLabTestToResultMatrix.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
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
        TypeLabTestToResultMatrix.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        TypeLabTestToResultMatrix.AcceptChanges();
                
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
        TypeLabTestToResultMatrix.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, VectorLabTest c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public VectorLabTest()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VectorLabTest_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VectorLabTest_PropertyChanged);
        }
        private void VectorLabTest_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VectorLabTest).Changed(e.PropertyName);
            
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
            VectorLabTest obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VectorLabTest obj = this;
            
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
            
            return ReadOnly || new Func<VectorLabTest, bool>(c => true)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _TypeLabTestToResultMatrix)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<VectorLabTest, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VectorLabTest, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VectorLabTest, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<VectorLabTest, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<VectorLabTest, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<VectorLabTest, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VectorLabTest()
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
        
            if (_TypeLabTestToResultMatrix != null) _TypeLabTestToResultMatrix.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    
        #region Class for web grid
        public class VectorLabTestGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfTesting { get; set; }
        
            public String strTestName { get; set; }
        
            public String strVectorID { get; set; }
        
            public String strBarcode { get; set; }
        
            public String strFieldBarcode { get; set; }
        
            public String strSampleType { get; set; }
        
            public DateTime? datFieldCollectionDate { get; set; }
        
            public DateTime? datAccession { get; set; }
        
            public DateTime? datStartedDate { get; set; }
        
            public String strTestCategory { get; set; }
        
            public String strTestedByPerson { get; set; }
        
            public String strTestedByOffice { get; set; }
        
            public String strTestResultName { get; set; }
        
            public String strDiagnosisName { get; set; }
        
        }
        public partial class VectorLabTestGridModelList : List<VectorLabTestGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public VectorLabTestGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VectorLabTest>, errMes);
            }
            public VectorLabTestGridModelList(long key, IEnumerable<VectorLabTest> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<VectorLabTest> items);
            private void LoadGridModelList(long key, IEnumerable<VectorLabTest> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strTestName,_str_strVectorID,_str_strBarcode,_str_strFieldBarcode,_str_strSampleType,_str_datFieldCollectionDate,_str_datAccession,_str_datStartedDate,_str_strTestCategory,_str_strTestedByPerson,_str_strTestedByOffice,_str_strTestResultName,_str_strDiagnosisName};
                    
                Hiddens = new List<string> {_str_idfTesting};
                Keys = new List<string> {_str_idfTesting};
                Labels = new Dictionary<string, string> {{_str_strTestName, "TestName"},{_str_strVectorID, "Vector.strVectorID"},{_str_strBarcode, "VectorSample.strBarcode"},{_str_strFieldBarcode, "VectorSample.strFieldBarcode"},{_str_strSampleType, "idfsSpecimenType"},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_datAccession, _str_datAccession},{_str_datStartedDate, "idfPensideTestTestDate"},{_str_strTestCategory, "idfPensideTestTestCategory"},{_str_strTestedByPerson, "idfPensideTestTestedByPerson"},{_str_strTestedByOffice, "idfPensideTestTestedByOffice"},{_str_strTestResultName, "idfsPensideTestResult"},{_str_strDiagnosisName, "FT.strDisease"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<VectorLabTest>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VectorLabTestGridModel()
                {
                    ItemKey=c.idfTesting,strTestName=c.strTestName,strVectorID=c.strVectorID,strBarcode=c.strBarcode,strFieldBarcode=c.strFieldBarcode,strSampleType=c.strSampleType,datFieldCollectionDate=c.datFieldCollectionDate,datAccession=c.datAccession,datStartedDate=c.datStartedDate,strTestCategory=c.strTestCategory,strTestedByPerson=c.strTestedByPerson,strTestedByOffice=c.strTestedByOffice,strTestResultName=c.strTestResultName,strDiagnosisName=c.strDiagnosisName
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
        : DataAccessor<VectorLabTest>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(VectorLabTest obj);
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
            private TypeLabTestToResultMatrixLookup.Accessor TypeLabTestToResultMatrixAccessor { get { return eidss.model.Schema.TypeLabTestToResultMatrixLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<VectorLabTest> SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                )
            {
                return _SelectList(manager
                    , idfVectorSurveillanceSession
                    , delegate(VectorLabTest obj)
                        {
                        }
                    , delegate(VectorLabTest obj)
                        {
                        }
                    );
            }

            
            private List<VectorLabTest> _SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VectorLabTest> objs = new List<VectorLabTest>();
                    sets[0] = new MapResultSet(typeof(VectorLabTest), objs);
                    
                    manager
                        .SetSpCommand("spVectorLabTest_SelectDetail"
                            , manager.Parameter("@idfVectorSurveillanceSession", idfVectorSurveillanceSession)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
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
                    throw DbModelException.Create(e);
                }
            }
    
            private void _SetupAddChildHandlerTypeLabTestToResultMatrix(VectorLabTest obj)
            {
                obj.TypeLabTestToResultMatrix.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadTypeLabTestToResultMatrix(VectorLabTest obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadTypeLabTestToResultMatrix(manager, obj);
                }
            }
            internal void _LoadTypeLabTestToResultMatrix(DbManagerProxy manager, VectorLabTest obj)
            {
                
                obj.TypeLabTestToResultMatrix.Clear();
                obj.TypeLabTestToResultMatrix.AddRange(TypeLabTestToResultMatrixAccessor.SelectDetailList(manager
                    
                    , obj.idfsTestResult.HasValue ? obj.idfsTestResult.Value : 0
                    ));
                obj.TypeLabTestToResultMatrix.ForEach(c => c.m_ObjectName = _str_TypeLabTestToResultMatrix);
                obj.TypeLabTestToResultMatrix.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, VectorLabTest obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadTypeLabTestToResultMatrix(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerTypeLabTestToResultMatrix(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, VectorLabTest obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.TypeLabTestToResultMatrix.ForEach(c => TypeLabTestToResultMatrixAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private VectorLabTest _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    VectorLabTest obj = VectorLabTest.CreateInstance();
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
                    
                    _SetupAddChildHandlerTypeLabTestToResultMatrix(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.idfTesting = new Func<VectorLabTest, DbManagerProxy, long>((c,m) => { _LoadTypeLabTestToResultMatrix(m,c); return c.idfTesting; })(obj, manager);
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

            
            public VectorLabTest CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public VectorLabTest CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(VectorLabTest obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VectorLabTest obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, VectorLabTest obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as VectorLabTest, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VectorLabTest obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(VectorLabTest obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(VectorLabTest obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VectorLabTest) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VectorLabTest) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VectorLabTestDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spVectorLabTest_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VectorLabTest, bool>> RequiredByField = new Dictionary<string, Func<VectorLabTest, bool>>();
            public static Dictionary<string, Func<VectorLabTest, bool>> RequiredByProperty = new Dictionary<string, Func<VectorLabTest, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strTestName, 2000);
                Sizes.Add(_str_strVectorID, 50);
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strSampleType, 2000);
                Sizes.Add(_str_strTestCategory, 2000);
                Sizes.Add(_str_strTestedByPerson, 602);
                Sizes.Add(_str_strTestedByOffice, 2000);
                Sizes.Add(_str_strTestResultName, 2000);
                Sizes.Add(_str_strDiagnosisName, 2000);
                GridMeta.Add(new GridMetaItem(
                    _str_idfTesting,
                    _str_idfTesting, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestName,
                    "TestName", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorID,
                    "Vector.strVectorID", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBarcode,
                    "VectorSample.strBarcode", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode,
                    "VectorSample.strFieldBarcode", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSampleType,
                    "idfsSpecimenType", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datAccession,
                    _str_datAccession, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datStartedDate,
                    "idfPensideTestTestDate", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestCategory,
                    "idfPensideTestTestCategory", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestedByPerson,
                    "idfPensideTestTestedByPerson", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestedByOffice,
                    "idfPensideTestTestedByOffice", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestResultName,
                    "idfsPensideTestResult", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosisName,
                    "FT.strDisease", null, true, true, null
                    ));
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
                    (manager, c, pars) => ((VectorLabTest)c).MarkToDelete(),
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	