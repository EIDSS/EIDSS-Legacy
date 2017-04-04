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
    public abstract partial class VectorLabTest : 
        EditableObject<VectorLabTest>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfTesting), NonUpdatable, PrimaryKey]
        public abstract Int64 idfTesting { get; set; }
                
        [LocalizedDisplayName(_str_idfsTestName)]
        [MapField(_str_idfsTestName)]
        public abstract Int64? idfsTestName { get; set; }
        protected Int64? idfsTestName_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestName).OriginalValue; } }
        protected Int64? idfsTestName_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestName).PreviousValue; } }
                
        [LocalizedDisplayName("TestName")]
        [MapField(_str_strTestName)]
        public abstract String strTestName { get; set; }
        protected String strTestName_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestName).OriginalValue; } }
        protected String strTestName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMaterial)]
        [MapField(_str_idfMaterial)]
        public abstract Int64 idfMaterial { get; set; }
        protected Int64 idfMaterial_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).OriginalValue; } }
        protected Int64 idfMaterial_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfVector)]
        [MapField(_str_idfVector)]
        public abstract Int64? idfVector { get; set; }
        protected Int64? idfVector_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).OriginalValue; } }
        protected Int64? idfVector_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).PreviousValue; } }
                
        [LocalizedDisplayName("Vector.strVectorID")]
        [MapField(_str_strVectorID)]
        public abstract String strVectorID { get; set; }
        protected String strVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).OriginalValue; } }
        protected String strVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).PreviousValue; } }
                
        [LocalizedDisplayName("VectorSample.strBarcode")]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
                
        [LocalizedDisplayName("VectorSample.strFieldBarcode")]
        [MapField(_str_strFieldBarcode)]
        public abstract String strFieldBarcode { get; set; }
        protected String strFieldBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).OriginalValue; } }
        protected String strFieldBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSampleType)]
        [MapField(_str_idfsSampleType)]
        public abstract Int64 idfsSampleType { get; set; }
        protected Int64 idfsSampleType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleType).OriginalValue; } }
        protected Int64 idfsSampleType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSampleType).PreviousValue; } }
                
        [LocalizedDisplayName("idfsSampleType")]
        [MapField(_str_strSampleType)]
        public abstract String strSampleType { get; set; }
        protected String strSampleType_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleType).OriginalValue; } }
        protected String strSampleType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFieldCollectionDate)]
        [MapField(_str_datFieldCollectionDate)]
        public abstract DateTime? datFieldCollectionDate { get; set; }
        protected DateTime? datFieldCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).OriginalValue; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datAccession)]
        [MapField(_str_datAccession)]
        public abstract DateTime? datAccession { get; set; }
        protected DateTime? datAccession_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).OriginalValue; } }
        protected DateTime? datAccession_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).PreviousValue; } }
                
        [LocalizedDisplayName("idfPensideTestTestDate")]
        [MapField(_str_datStartedDate)]
        public abstract DateTime? datStartedDate { get; set; }
        protected DateTime? datStartedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartedDate).OriginalValue; } }
        protected DateTime? datStartedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartedDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTestCategory)]
        [MapField(_str_idfsTestCategory)]
        public abstract Int64? idfsTestCategory { get; set; }
        protected Int64? idfsTestCategory_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestCategory).OriginalValue; } }
        protected Int64? idfsTestCategory_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestCategory).PreviousValue; } }
                
        [LocalizedDisplayName("idfPensideTestTestCategory")]
        [MapField(_str_strTestCategory)]
        public abstract String strTestCategory { get; set; }
        protected String strTestCategory_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestCategory).OriginalValue; } }
        protected String strTestCategory_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestCategory).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfTestedByPerson)]
        [MapField(_str_idfTestedByPerson)]
        public abstract Int64? idfTestedByPerson { get; set; }
        protected Int64? idfTestedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByPerson).OriginalValue; } }
        protected Int64? idfTestedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName("idfPensideTestTestedByPerson")]
        [MapField(_str_strTestedByPerson)]
        public abstract String strTestedByPerson { get; set; }
        protected String strTestedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestedByPerson).OriginalValue; } }
        protected String strTestedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfTestedByOffice)]
        [MapField(_str_idfTestedByOffice)]
        public abstract Int64? idfTestedByOffice { get; set; }
        protected Int64? idfTestedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByOffice).OriginalValue; } }
        protected Int64? idfTestedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName("idfPensideTestTestedByOffice")]
        [MapField(_str_strTestedByOffice)]
        public abstract String strTestedByOffice { get; set; }
        protected String strTestedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestedByOffice).OriginalValue; } }
        protected String strTestedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsTestResult)]
        [MapField(_str_idfsTestResult)]
        public abstract Int64? idfsTestResult { get; set; }
        protected Int64? idfsTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).OriginalValue; } }
        protected Int64? idfsTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestResult).PreviousValue; } }
                
        [LocalizedDisplayName("TestResult")]
        [MapField(_str_strTestResultName)]
        public abstract String strTestResultName { get; set; }
        protected String strTestResultName_Original { get { return ((EditableValue<String>)((dynamic)this)._strTestResultName).OriginalValue; } }
        protected String strTestResultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTestResultName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsDiagnosis)]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64 idfsDiagnosis { get; set; }
        protected Int64 idfsDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64 idfsDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName("FT.strDisease")]
        [MapField(_str_strDiagnosisName)]
        public abstract String strDiagnosisName { get; set; }
        protected String strDiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisName).OriginalValue; } }
        protected String strDiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsVectorType)]
        [MapField(_str_idfsVectorType)]
        public abstract Int64 idfsVectorType { get; set; }
        protected Int64 idfsVectorType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).OriginalValue; } }
        protected Int64 idfsVectorType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).PreviousValue; } }
                
        [LocalizedDisplayName("idfsVectorType")]
        [MapField(_str_strVectorTypeName)]
        public abstract String strVectorTypeName { get; set; }
        protected String strVectorTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorTypeName).OriginalValue; } }
        protected String strVectorTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorTypeName).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<VectorLabTest, object> _get_func;
            internal Action<VectorLabTest, string> _set_func;
            internal Action<VectorLabTest, VectorLabTest, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_idfsTestName = "idfsTestName";
        internal const string _str_strTestName = "strTestName";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_idfVector = "idfVector";
        internal const string _str_strVectorID = "strVectorID";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_idfsSampleType = "idfsSampleType";
        internal const string _str_strSampleType = "strSampleType";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_datStartedDate = "datStartedDate";
        internal const string _str_idfsTestCategory = "idfsTestCategory";
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
        internal const string _str_strVectorTypeName = "strVectorTypeName";
        internal const string _str_strAmendmentHistory = "strAmendmentHistory";
        internal const string _str_ParentVector = "ParentVector";
        internal const string _str_strVectorSubTypeName = "strVectorSubTypeName";
        internal const string _str_Vectors = "Vectors";
        internal const string _str_HasAmendmentHistory = "HasAmendmentHistory";
        internal const string _str_TypeLabTestToResultMatrix = "TypeLabTestToResultMatrix";
        internal const string _str_AmendmentHistory = "AmendmentHistory";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfTesting, _formname = _str_idfTesting, _type = "Int64",
              _get_func = o => o.idfTesting,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfTesting != newval) o.idfTesting = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfTesting != c.idfTesting || o.IsRIRPropChanged(_str_idfTesting, c)) 
                  m.Add(_str_idfTesting, o.ObjectIdent + _str_idfTesting, o.ObjectIdent2 + _str_idfTesting, o.ObjectIdent3 + _str_idfTesting, "Int64", 
                    o.idfTesting == null ? "" : o.idfTesting.ToString(),                  
                  o.IsReadOnly(_str_idfTesting), o.IsInvisible(_str_idfTesting), o.IsRequired(_str_idfTesting)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestName, _formname = _str_idfsTestName, _type = "Int64?",
              _get_func = o => o.idfsTestName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestName != newval) o.idfsTestName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTestName != c.idfsTestName || o.IsRIRPropChanged(_str_idfsTestName, c)) 
                  m.Add(_str_idfsTestName, o.ObjectIdent + _str_idfsTestName, o.ObjectIdent2 + _str_idfsTestName, o.ObjectIdent3 + _str_idfsTestName, "Int64?", 
                    o.idfsTestName == null ? "" : o.idfsTestName.ToString(),                  
                  o.IsReadOnly(_str_idfsTestName), o.IsInvisible(_str_idfsTestName), o.IsRequired(_str_idfsTestName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTestName, _formname = _str_strTestName, _type = "String",
              _get_func = o => o.strTestName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTestName != newval) o.strTestName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strTestName != c.strTestName || o.IsRIRPropChanged(_str_strTestName, c)) 
                  m.Add(_str_strTestName, o.ObjectIdent + _str_strTestName, o.ObjectIdent2 + _str_strTestName, o.ObjectIdent3 + _str_strTestName, "String", 
                    o.strTestName == null ? "" : o.strTestName.ToString(),                  
                  o.IsReadOnly(_str_strTestName), o.IsInvisible(_str_strTestName), o.IsRequired(_str_strTestName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMaterial, _formname = _str_idfMaterial, _type = "Int64",
              _get_func = o => o.idfMaterial,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfMaterial != newval) o.idfMaterial = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfMaterial != c.idfMaterial || o.IsRIRPropChanged(_str_idfMaterial, c)) 
                  m.Add(_str_idfMaterial, o.ObjectIdent + _str_idfMaterial, o.ObjectIdent2 + _str_idfMaterial, o.ObjectIdent3 + _str_idfMaterial, "Int64", 
                    o.idfMaterial == null ? "" : o.idfMaterial.ToString(),                  
                  o.IsReadOnly(_str_idfMaterial), o.IsInvisible(_str_idfMaterial), o.IsRequired(_str_idfMaterial)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVector, _formname = _str_idfVector, _type = "Int64?",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfVector != newval) o.idfVector = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, o.ObjectIdent2 + _str_idfVector, o.ObjectIdent3 + _str_idfVector, "Int64?", 
                    o.idfVector == null ? "" : o.idfVector.ToString(),                  
                  o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strVectorID, _formname = _str_strVectorID, _type = "String",
              _get_func = o => o.strVectorID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectorID != newval) o.strVectorID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strVectorID != c.strVectorID || o.IsRIRPropChanged(_str_strVectorID, c)) 
                  m.Add(_str_strVectorID, o.ObjectIdent + _str_strVectorID, o.ObjectIdent2 + _str_strVectorID, o.ObjectIdent3 + _str_strVectorID, "String", 
                    o.strVectorID == null ? "" : o.strVectorID.ToString(),                  
                  o.IsReadOnly(_str_strVectorID), o.IsInvisible(_str_strVectorID), o.IsRequired(_str_strVectorID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strBarcode, _formname = _str_strBarcode, _type = "String",
              _get_func = o => o.strBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strBarcode != newval) o.strBarcode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strBarcode != c.strBarcode || o.IsRIRPropChanged(_str_strBarcode, c)) 
                  m.Add(_str_strBarcode, o.ObjectIdent + _str_strBarcode, o.ObjectIdent2 + _str_strBarcode, o.ObjectIdent3 + _str_strBarcode, "String", 
                    o.strBarcode == null ? "" : o.strBarcode.ToString(),                  
                  o.IsReadOnly(_str_strBarcode), o.IsInvisible(_str_strBarcode), o.IsRequired(_str_strBarcode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFieldBarcode, _formname = _str_strFieldBarcode, _type = "String",
              _get_func = o => o.strFieldBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldBarcode != newval) o.strFieldBarcode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFieldBarcode != c.strFieldBarcode || o.IsRIRPropChanged(_str_strFieldBarcode, c)) 
                  m.Add(_str_strFieldBarcode, o.ObjectIdent + _str_strFieldBarcode, o.ObjectIdent2 + _str_strFieldBarcode, o.ObjectIdent3 + _str_strFieldBarcode, "String", 
                    o.strFieldBarcode == null ? "" : o.strFieldBarcode.ToString(),                  
                  o.IsReadOnly(_str_strFieldBarcode), o.IsInvisible(_str_strFieldBarcode), o.IsRequired(_str_strFieldBarcode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSampleType, _formname = _str_idfsSampleType, _type = "Int64",
              _get_func = o => o.idfsSampleType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsSampleType != newval) o.idfsSampleType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSampleType != c.idfsSampleType || o.IsRIRPropChanged(_str_idfsSampleType, c)) 
                  m.Add(_str_idfsSampleType, o.ObjectIdent + _str_idfsSampleType, o.ObjectIdent2 + _str_idfsSampleType, o.ObjectIdent3 + _str_idfsSampleType, "Int64", 
                    o.idfsSampleType == null ? "" : o.idfsSampleType.ToString(),                  
                  o.IsReadOnly(_str_idfsSampleType), o.IsInvisible(_str_idfsSampleType), o.IsRequired(_str_idfsSampleType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSampleType, _formname = _str_strSampleType, _type = "String",
              _get_func = o => o.strSampleType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSampleType != newval) o.strSampleType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSampleType != c.strSampleType || o.IsRIRPropChanged(_str_strSampleType, c)) 
                  m.Add(_str_strSampleType, o.ObjectIdent + _str_strSampleType, o.ObjectIdent2 + _str_strSampleType, o.ObjectIdent3 + _str_strSampleType, "String", 
                    o.strSampleType == null ? "" : o.strSampleType.ToString(),                  
                  o.IsReadOnly(_str_strSampleType), o.IsInvisible(_str_strSampleType), o.IsRequired(_str_strSampleType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datFieldCollectionDate, _formname = _str_datFieldCollectionDate, _type = "DateTime?",
              _get_func = o => o.datFieldCollectionDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datFieldCollectionDate != newval) o.datFieldCollectionDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datFieldCollectionDate != c.datFieldCollectionDate || o.IsRIRPropChanged(_str_datFieldCollectionDate, c)) 
                  m.Add(_str_datFieldCollectionDate, o.ObjectIdent + _str_datFieldCollectionDate, o.ObjectIdent2 + _str_datFieldCollectionDate, o.ObjectIdent3 + _str_datFieldCollectionDate, "DateTime?", 
                    o.datFieldCollectionDate == null ? "" : o.datFieldCollectionDate.ToString(),                  
                  o.IsReadOnly(_str_datFieldCollectionDate), o.IsInvisible(_str_datFieldCollectionDate), o.IsRequired(_str_datFieldCollectionDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datAccession, _formname = _str_datAccession, _type = "DateTime?",
              _get_func = o => o.datAccession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datAccession != newval) o.datAccession = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datAccession != c.datAccession || o.IsRIRPropChanged(_str_datAccession, c)) 
                  m.Add(_str_datAccession, o.ObjectIdent + _str_datAccession, o.ObjectIdent2 + _str_datAccession, o.ObjectIdent3 + _str_datAccession, "DateTime?", 
                    o.datAccession == null ? "" : o.datAccession.ToString(),                  
                  o.IsReadOnly(_str_datAccession), o.IsInvisible(_str_datAccession), o.IsRequired(_str_datAccession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datStartedDate, _formname = _str_datStartedDate, _type = "DateTime?",
              _get_func = o => o.datStartedDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datStartedDate != newval) o.datStartedDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datStartedDate != c.datStartedDate || o.IsRIRPropChanged(_str_datStartedDate, c)) 
                  m.Add(_str_datStartedDate, o.ObjectIdent + _str_datStartedDate, o.ObjectIdent2 + _str_datStartedDate, o.ObjectIdent3 + _str_datStartedDate, "DateTime?", 
                    o.datStartedDate == null ? "" : o.datStartedDate.ToString(),                  
                  o.IsReadOnly(_str_datStartedDate), o.IsInvisible(_str_datStartedDate), o.IsRequired(_str_datStartedDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestCategory, _formname = _str_idfsTestCategory, _type = "Int64?",
              _get_func = o => o.idfsTestCategory,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestCategory != newval) o.idfsTestCategory = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTestCategory != c.idfsTestCategory || o.IsRIRPropChanged(_str_idfsTestCategory, c)) 
                  m.Add(_str_idfsTestCategory, o.ObjectIdent + _str_idfsTestCategory, o.ObjectIdent2 + _str_idfsTestCategory, o.ObjectIdent3 + _str_idfsTestCategory, "Int64?", 
                    o.idfsTestCategory == null ? "" : o.idfsTestCategory.ToString(),                  
                  o.IsReadOnly(_str_idfsTestCategory), o.IsInvisible(_str_idfsTestCategory), o.IsRequired(_str_idfsTestCategory)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTestCategory, _formname = _str_strTestCategory, _type = "String",
              _get_func = o => o.strTestCategory,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTestCategory != newval) o.strTestCategory = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strTestCategory != c.strTestCategory || o.IsRIRPropChanged(_str_strTestCategory, c)) 
                  m.Add(_str_strTestCategory, o.ObjectIdent + _str_strTestCategory, o.ObjectIdent2 + _str_strTestCategory, o.ObjectIdent3 + _str_strTestCategory, "String", 
                    o.strTestCategory == null ? "" : o.strTestCategory.ToString(),                  
                  o.IsReadOnly(_str_strTestCategory), o.IsInvisible(_str_strTestCategory), o.IsRequired(_str_strTestCategory)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfTestedByPerson, _formname = _str_idfTestedByPerson, _type = "Int64?",
              _get_func = o => o.idfTestedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfTestedByPerson != newval) o.idfTestedByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfTestedByPerson != c.idfTestedByPerson || o.IsRIRPropChanged(_str_idfTestedByPerson, c)) 
                  m.Add(_str_idfTestedByPerson, o.ObjectIdent + _str_idfTestedByPerson, o.ObjectIdent2 + _str_idfTestedByPerson, o.ObjectIdent3 + _str_idfTestedByPerson, "Int64?", 
                    o.idfTestedByPerson == null ? "" : o.idfTestedByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfTestedByPerson), o.IsInvisible(_str_idfTestedByPerson), o.IsRequired(_str_idfTestedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTestedByPerson, _formname = _str_strTestedByPerson, _type = "String",
              _get_func = o => o.strTestedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTestedByPerson != newval) o.strTestedByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strTestedByPerson != c.strTestedByPerson || o.IsRIRPropChanged(_str_strTestedByPerson, c)) 
                  m.Add(_str_strTestedByPerson, o.ObjectIdent + _str_strTestedByPerson, o.ObjectIdent2 + _str_strTestedByPerson, o.ObjectIdent3 + _str_strTestedByPerson, "String", 
                    o.strTestedByPerson == null ? "" : o.strTestedByPerson.ToString(),                  
                  o.IsReadOnly(_str_strTestedByPerson), o.IsInvisible(_str_strTestedByPerson), o.IsRequired(_str_strTestedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfTestedByOffice, _formname = _str_idfTestedByOffice, _type = "Int64?",
              _get_func = o => o.idfTestedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfTestedByOffice != newval) o.idfTestedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfTestedByOffice != c.idfTestedByOffice || o.IsRIRPropChanged(_str_idfTestedByOffice, c)) 
                  m.Add(_str_idfTestedByOffice, o.ObjectIdent + _str_idfTestedByOffice, o.ObjectIdent2 + _str_idfTestedByOffice, o.ObjectIdent3 + _str_idfTestedByOffice, "Int64?", 
                    o.idfTestedByOffice == null ? "" : o.idfTestedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfTestedByOffice), o.IsInvisible(_str_idfTestedByOffice), o.IsRequired(_str_idfTestedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTestedByOffice, _formname = _str_strTestedByOffice, _type = "String",
              _get_func = o => o.strTestedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTestedByOffice != newval) o.strTestedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strTestedByOffice != c.strTestedByOffice || o.IsRIRPropChanged(_str_strTestedByOffice, c)) 
                  m.Add(_str_strTestedByOffice, o.ObjectIdent + _str_strTestedByOffice, o.ObjectIdent2 + _str_strTestedByOffice, o.ObjectIdent3 + _str_strTestedByOffice, "String", 
                    o.strTestedByOffice == null ? "" : o.strTestedByOffice.ToString(),                  
                  o.IsReadOnly(_str_strTestedByOffice), o.IsInvisible(_str_strTestedByOffice), o.IsRequired(_str_strTestedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTestResult, _formname = _str_idfsTestResult, _type = "Int64?",
              _get_func = o => o.idfsTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsTestResult != newval) o.idfsTestResult = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTestResult != c.idfsTestResult || o.IsRIRPropChanged(_str_idfsTestResult, c)) 
                  m.Add(_str_idfsTestResult, o.ObjectIdent + _str_idfsTestResult, o.ObjectIdent2 + _str_idfsTestResult, o.ObjectIdent3 + _str_idfsTestResult, "Int64?", 
                    o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(),                  
                  o.IsReadOnly(_str_idfsTestResult), o.IsInvisible(_str_idfsTestResult), o.IsRequired(_str_idfsTestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTestResultName, _formname = _str_strTestResultName, _type = "String",
              _get_func = o => o.strTestResultName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTestResultName != newval) o.strTestResultName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strTestResultName != c.strTestResultName || o.IsRIRPropChanged(_str_strTestResultName, c)) 
                  m.Add(_str_strTestResultName, o.ObjectIdent + _str_strTestResultName, o.ObjectIdent2 + _str_strTestResultName, o.ObjectIdent3 + _str_strTestResultName, "String", 
                    o.strTestResultName == null ? "" : o.strTestResultName.ToString(),                  
                  o.IsReadOnly(_str_strTestResultName), o.IsInvisible(_str_strTestResultName), o.IsRequired(_str_strTestResultName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "Int64",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis, "Int64", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDiagnosisName, _formname = _str_strDiagnosisName, _type = "String",
              _get_func = o => o.strDiagnosisName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnosisName != newval) o.strDiagnosisName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strDiagnosisName != c.strDiagnosisName || o.IsRIRPropChanged(_str_strDiagnosisName, c)) 
                  m.Add(_str_strDiagnosisName, o.ObjectIdent + _str_strDiagnosisName, o.ObjectIdent2 + _str_strDiagnosisName, o.ObjectIdent3 + _str_strDiagnosisName, "String", 
                    o.strDiagnosisName == null ? "" : o.strDiagnosisName.ToString(),                  
                  o.IsReadOnly(_str_strDiagnosisName), o.IsInvisible(_str_strDiagnosisName), o.IsRequired(_str_strDiagnosisName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsVectorType, _formname = _str_idfsVectorType, _type = "Int64",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsVectorType != newval) o.idfsVectorType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) 
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, o.ObjectIdent2 + _str_idfsVectorType, o.ObjectIdent3 + _str_idfsVectorType, "Int64", 
                    o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(),                  
                  o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strVectorTypeName, _formname = _str_strVectorTypeName, _type = "String",
              _get_func = o => o.strVectorTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectorTypeName != newval) o.strVectorTypeName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strVectorTypeName != c.strVectorTypeName || o.IsRIRPropChanged(_str_strVectorTypeName, c)) 
                  m.Add(_str_strVectorTypeName, o.ObjectIdent + _str_strVectorTypeName, o.ObjectIdent2 + _str_strVectorTypeName, o.ObjectIdent3 + _str_strVectorTypeName, "String", 
                    o.strVectorTypeName == null ? "" : o.strVectorTypeName.ToString(),                  
                  o.IsReadOnly(_str_strVectorTypeName), o.IsInvisible(_str_strVectorTypeName), o.IsRequired(_str_strVectorTypeName)); 
                  }
              }, 
        
            new field_info {
              _name = _str_strAmendmentHistory, _formname = _str_strAmendmentHistory, _type = "string",
              _get_func = o => o.strAmendmentHistory,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAmendmentHistory != newval) o.strAmendmentHistory = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.strAmendmentHistory != c.strAmendmentHistory || o.IsRIRPropChanged(_str_strAmendmentHistory, c)) {
                  m.Add(_str_strAmendmentHistory, o.ObjectIdent + _str_strAmendmentHistory, o.ObjectIdent2 + _str_strAmendmentHistory, o.ObjectIdent3 + _str_strAmendmentHistory,  "string", 
                    o.strAmendmentHistory == null ? "" : o.strAmendmentHistory.ToString(),                  
                    o.IsReadOnly(_str_strAmendmentHistory), o.IsInvisible(_str_strAmendmentHistory), o.IsRequired(_str_strAmendmentHistory));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_ParentVector, _formname = _str_ParentVector, _type = "Vector",
              _get_func = o => o.ParentVector,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_strVectorSubTypeName, _formname = _str_strVectorSubTypeName, _type = "string",
              _get_func = o => o.strVectorSubTypeName,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strVectorSubTypeName != c.strVectorSubTypeName || o.IsRIRPropChanged(_str_strVectorSubTypeName, c)) {
                  m.Add(_str_strVectorSubTypeName, o.ObjectIdent + _str_strVectorSubTypeName, o.ObjectIdent2 + _str_strVectorSubTypeName, o.ObjectIdent3 + _str_strVectorSubTypeName, "string", o.strVectorSubTypeName == null ? "" : o.strVectorSubTypeName.ToString(), o.IsReadOnly(_str_strVectorSubTypeName), o.IsInvisible(_str_strVectorSubTypeName), o.IsRequired(_str_strVectorSubTypeName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Vectors, _formname = _str_Vectors, _type = "EditableList<Vector>",
              _get_func = o => o.Vectors,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_HasAmendmentHistory, _formname = _str_HasAmendmentHistory, _type = "bool",
              _get_func = o => o.HasAmendmentHistory,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.HasAmendmentHistory != c.HasAmendmentHistory || o.IsRIRPropChanged(_str_HasAmendmentHistory, c)) {
                  m.Add(_str_HasAmendmentHistory, o.ObjectIdent + _str_HasAmendmentHistory, o.ObjectIdent2 + _str_HasAmendmentHistory, o.ObjectIdent3 + _str_HasAmendmentHistory, "bool", o.HasAmendmentHistory == null ? "" : o.HasAmendmentHistory.ToString(), o.IsReadOnly(_str_HasAmendmentHistory), o.IsInvisible(_str_HasAmendmentHistory), o.IsRequired(_str_HasAmendmentHistory));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_TypeLabTestToResultMatrix, _formname = _str_TypeLabTestToResultMatrix, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.TypeLabTestToResultMatrix.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.TypeLabTestToResultMatrix.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.TypeLabTestToResultMatrix.Count != c.TypeLabTestToResultMatrix.Count || o.IsReadOnly(_str_TypeLabTestToResultMatrix) != c.IsReadOnly(_str_TypeLabTestToResultMatrix) || o.IsInvisible(_str_TypeLabTestToResultMatrix) != c.IsInvisible(_str_TypeLabTestToResultMatrix) || o.IsRequired(_str_TypeLabTestToResultMatrix) != c._isRequired(o.m_isRequired, _str_TypeLabTestToResultMatrix)) {
                  m.Add(_str_TypeLabTestToResultMatrix, o.ObjectIdent + _str_TypeLabTestToResultMatrix, o.ObjectIdent2 + _str_TypeLabTestToResultMatrix, o.ObjectIdent3 + _str_TypeLabTestToResultMatrix, "Child", o.idfsTestResult == null ? "" : o.idfsTestResult.ToString(), o.IsReadOnly(_str_TypeLabTestToResultMatrix), o.IsInvisible(_str_TypeLabTestToResultMatrix), o.IsRequired(_str_TypeLabTestToResultMatrix)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_AmendmentHistory, _formname = _str_AmendmentHistory, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.AmendmentHistory.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.AmendmentHistory.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.AmendmentHistory.Count != c.AmendmentHistory.Count || o.IsReadOnly(_str_AmendmentHistory) != c.IsReadOnly(_str_AmendmentHistory) || o.IsInvisible(_str_AmendmentHistory) != c.IsInvisible(_str_AmendmentHistory) || o.IsRequired(_str_AmendmentHistory) != c._isRequired(o.m_isRequired, _str_AmendmentHistory)) {
                  m.Add(_str_AmendmentHistory, o.ObjectIdent + _str_AmendmentHistory, o.ObjectIdent2 + _str_AmendmentHistory, o.ObjectIdent3 + _str_AmendmentHistory, "Child", o.idfTesting == null ? "" : o.idfTesting.ToString(), o.IsReadOnly(_str_AmendmentHistory), o.IsInvisible(_str_AmendmentHistory), o.IsRequired(_str_AmendmentHistory)); 
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
            VectorLabTest obj = (VectorLabTest)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_TypeLabTestToResultMatrix)]
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
                    
        [LocalizedDisplayName(_str_AmendmentHistory)]
        [Relation(typeof(LabTestAmendment), eidss.model.Schema.LabTestAmendment._str_idfTesting, _str_idfTesting)]
        public EditableList<LabTestAmendment> AmendmentHistory
        {
            get 
            {   
                return _AmendmentHistory; 
            }
            set 
            {
                _AmendmentHistory = value;
            }
        }
        protected EditableList<LabTestAmendment> _AmendmentHistory = new EditableList<LabTestAmendment>();
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_ParentVector)]
        public Vector ParentVector
        {
            get { return new Func<VectorLabTest, Vector>(c => Parent as Vector)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("idfsVectorSubType")]
        public string strVectorSubTypeName
        {
            get { return new Func<VectorLabTest, string>(c => ((c.ParentVector != null) && (c.ParentVector.VectorSubType != null)) ? c.ParentVector.VectorSubType.name : String.Empty)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Vectors)]
        public EditableList<Vector> Vectors
        {
            get { return new Func<VectorLabTest, EditableList<Vector>>(c => c.ParentVector == null ? new EditableList<Vector>() : c.ParentVector.Vectors)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_HasAmendmentHistory)]
        public bool HasAmendmentHistory
        {
            get { return new Func<VectorLabTest, bool>(c => c.AmendmentHistory != null ? AmendmentHistory.Count > 0 : false)(this); }
            
        }
        
          [LocalizedDisplayName("HasAmendmentHistory")]
        public string strAmendmentHistory
        {
            get { return m_strAmendmentHistory; }
            set { if (m_strAmendmentHistory != value) { m_strAmendmentHistory = value; OnPropertyChanged(_str_strAmendmentHistory); } }
        }
        private string m_strAmendmentHistory;
        
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
                AmendmentHistory.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as VectorLabTest;
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
            var ret = base.Clone() as VectorLabTest;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_TypeLabTestToResultMatrix != null && _TypeLabTestToResultMatrix.Count > 0)
            {
              ret.TypeLabTestToResultMatrix.Clear();
              _TypeLabTestToResultMatrix.ForEach(c => ret.TypeLabTestToResultMatrix.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_AmendmentHistory != null && _AmendmentHistory.Count > 0)
            {
              ret.AmendmentHistory.Clear();
              _AmendmentHistory.ForEach(c => ret.AmendmentHistory.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
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
        public object KeyLookup { get { return idfTesting; } }
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
        
                    || TypeLabTestToResultMatrix.IsDirty
                    || TypeLabTestToResultMatrix.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || AmendmentHistory.IsDirty
                    || AmendmentHistory.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
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
        TypeLabTestToResultMatrix.DeepRejectChanges();
                AmendmentHistory.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        TypeLabTestToResultMatrix.DeepAcceptChanges();
                AmendmentHistory.DeepAcceptChanges();
                
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
        TypeLabTestToResultMatrix.ForEach(c => c.SetChange());
                AmendmentHistory.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, VectorLabTest c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, VectorLabTest c)
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
        

      

        public VectorLabTest()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VectorLabTest_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VectorLabTest_PropertyChanged);
        }
        private void VectorLabTest_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VectorLabTest).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_ParentVector);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_strVectorSubTypeName);
                  
            if (e.PropertyName == _str_ParentVector)
                OnPropertyChanged(_str_Vectors);
                  
            if (e.PropertyName == _str_AmendmentHistory)
                OnPropertyChanged(_str_HasAmendmentHistory);
                  
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
            
            return ReadOnly || new Func<VectorLabTest, bool>(c => true)(this);
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
                foreach(var o in _TypeLabTestToResultMatrix)
                    o._isValid &= value;
                
                foreach(var o in _AmendmentHistory)
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
        
                foreach(var o in _TypeLabTestToResultMatrix)
                    o.ReadOnly |= value;
                
                foreach(var o in _AmendmentHistory)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<VectorLabTest, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VectorLabTest, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VectorLabTest, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VectorLabTest, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VectorLabTest, bool>> m_isHiddenPersonalData;
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
        protected bool bNeedLookupRemove;
        ~VectorLabTest()
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
                
                if (!bIsClone)
                {
                    TypeLabTestToResultMatrix.ForEach(c => c.Dispose());
                }
                TypeLabTestToResultMatrix.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    AmendmentHistory.ForEach(c => c.Dispose());
                }
                AmendmentHistory.ClearModelListEventInvocations();
                
                
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
        
            if (_TypeLabTestToResultMatrix != null) _TypeLabTestToResultMatrix.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_AmendmentHistory != null) _AmendmentHistory.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    
        #region Class for web grid
        public class VectorLabTestGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfTesting { get; set; }
        
            public String strVectorID { get; set; }
        
            public String strVectorTypeName { get; set; }
        
            public string strVectorSubTypeName { get; set; }
        
            public String strBarcode { get; set; }
        
            public String strFieldBarcode { get; set; }
        
            public String strSampleType { get; set; }
        
            public DateTimeWrap datFieldCollectionDate { get; set; }
        
            public String strTestName { get; set; }
        
            public String strTestCategory { get; set; }
        
            public DateTimeWrap datStartedDate { get; set; }
        
            public String strTestedByOffice { get; set; }
        
            public String strTestedByPerson { get; set; }
        
            public String strTestResultName { get; set; }
        
            public String strDiagnosisName { get; set; }
        
            public bool HasAmendmentHistory { get; set; }
        
            public string strAmendmentHistory { get; set; }
        
        }
        public partial class VectorLabTestGridModelList : List<VectorLabTestGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public VectorLabTestGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VectorLabTest>, errMes);
            }
            public VectorLabTestGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VectorLabTest>, errMes);
            }
            public VectorLabTestGridModelList(long key, IEnumerable<VectorLabTest> items)
            {
                LoadGridModelList(key, items, null);
            }
            public VectorLabTestGridModelList(long key)
            {
                LoadGridModelList(key, new List<VectorLabTest>(), null);
            }
            partial void filter(List<VectorLabTest> items);
            private void LoadGridModelList(long key, IEnumerable<VectorLabTest> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strVectorID,_str_strVectorTypeName,_str_strVectorSubTypeName,_str_strBarcode,_str_strFieldBarcode,_str_strSampleType,_str_datFieldCollectionDate,_str_strTestName,_str_strTestCategory,_str_datStartedDate,_str_strTestedByOffice,_str_strTestedByPerson,_str_strTestResultName,_str_strDiagnosisName,_str_HasAmendmentHistory,_str_strAmendmentHistory};
                    
                Hiddens = new List<string> {_str_idfTesting};
                Keys = new List<string> {_str_idfTesting};
                Labels = new Dictionary<string, string> {{_str_strVectorID, "Vector.strVectorID"},{_str_strVectorTypeName, "idfsVectorType"},{_str_strVectorSubTypeName, "idfsVectorSubType"},{_str_strBarcode, "VectorSample.strBarcode"},{_str_strFieldBarcode, "VectorSample.strFieldBarcode"},{_str_strSampleType, "idfsSampleType"},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_strTestName, "TestName"},{_str_strTestCategory, "idfPensideTestTestCategory"},{_str_datStartedDate, "idfPensideTestTestDate"},{_str_strTestedByOffice, "idfPensideTestTestedByOffice"},{_str_strTestedByPerson, "idfPensideTestTestedByPerson"},{_str_strTestResultName, "TestResult"},{_str_strDiagnosisName, "FT.strDisease"},{_str_HasAmendmentHistory, _str_HasAmendmentHistory},{_str_strAmendmentHistory, "HasAmendmentHistory"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                VectorLabTest.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<VectorLabTest>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VectorLabTestGridModel()
                {
                    ItemKey=c.idfTesting,strVectorID=c.strVectorID,strVectorTypeName=c.strVectorTypeName,strVectorSubTypeName=c.strVectorSubTypeName,strBarcode=c.strBarcode,strFieldBarcode=c.strFieldBarcode,strSampleType=c.strSampleType,datFieldCollectionDate=c.datFieldCollectionDate,strTestName=c.strTestName,strTestCategory=c.strTestCategory,datStartedDate=c.datStartedDate,strTestedByOffice=c.strTestedByOffice,strTestedByPerson=c.strTestedByPerson,strTestResultName=c.strTestResultName,strDiagnosisName=c.strDiagnosisName,HasAmendmentHistory=c.HasAmendmentHistory,strAmendmentHistory=c.strAmendmentHistory
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
            , IObjectCreator<VectorLabTest>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfTesting"; } }
            #endregion
        
            public delegate void on_action(VectorLabTest obj);
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
            private LabTestAmendment.Accessor AmendmentHistoryAccessor { get { return eidss.model.Schema.LabTestAmendment.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<VectorLabTest> SelectList(DbManagerProxy manager
                , Int64? idfVector
                )
            {
                return _SelectList(manager
                    , idfVector
                    , delegate(VectorLabTest obj)
                        {
                        }
                    , delegate(VectorLabTest obj)
                        {
                        }
                    );
            }

            

            public List<VectorLabTest> _SelectList(DbManagerProxy manager
                , Int64? idfVector
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfVector
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<VectorLabTest> _SelectListInternal(DbManagerProxy manager
                , Int64? idfVector
                , on_action loading, on_action loaded
                )
            {
                VectorLabTest _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VectorLabTest> objs = new List<VectorLabTest>();
                    sets[0] = new MapResultSet(typeof(VectorLabTest), objs);
                    
                    manager
                        .SetSpCommand("spVectorLabTest_SelectDetail"
                            , manager.Parameter("@idfVector", idfVector)
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
            
            private void _SetupAddChildHandlerAmendmentHistory(VectorLabTest obj)
            {
                obj.AmendmentHistory.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadAmendmentHistory(VectorLabTest obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadAmendmentHistory(manager, obj);
                }
            }
            internal void _LoadAmendmentHistory(DbManagerProxy manager, VectorLabTest obj)
            {
              
                obj.AmendmentHistory.Clear();
                obj.AmendmentHistory.AddRange(AmendmentHistoryAccessor.SelectDetailList(manager
                    
                    , obj.idfTesting
                    ));
                obj.AmendmentHistory.ForEach(c => c.m_ObjectName = _str_AmendmentHistory);
                obj.AmendmentHistory.AcceptChanges();
                    
              }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, VectorLabTest obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadTypeLabTestToResultMatrix(manager, obj);
                _LoadAmendmentHistory(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerTypeLabTestToResultMatrix(obj);
                
                _SetupAddChildHandlerAmendmentHistory(obj);
                
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
                    
                        obj.AmendmentHistory.ForEach(c => AmendmentHistoryAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private VectorLabTest _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                VectorLabTest obj = null;
                try
                {
                    obj = VectorLabTest.CreateInstance();
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
                    
                    _SetupAddChildHandlerAmendmentHistory(obj);
                    
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
                    throw DbModelException.Create(obj, e);
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
            public VectorLabTest CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public VectorLabTest CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ViewOnDetailForm(DbManagerProxy manager, VectorLabTest obj, List<object> pars)
            {
                
                return ViewOnDetailForm(manager, obj
                    );
            }
            public ActResult ViewOnDetailForm(DbManagerProxy manager, VectorLabTest obj
                )
            {
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(VectorLabTest obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VectorLabTest obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, VectorLabTest obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(VectorLabTest obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(VectorLabTest obj, bool bRethrowException)
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
                return Validate(manager, obj as VectorLabTest, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VectorLabTest obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
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
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
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
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VectorLabTest, bool>> RequiredByField = new Dictionary<string, Func<VectorLabTest, bool>>();
            public static Dictionary<string, Func<VectorLabTest, bool>> RequiredByProperty = new Dictionary<string, Func<VectorLabTest, bool>>();
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
                
                Sizes.Add(_str_strTestName, 2000);
                Sizes.Add(_str_strVectorID, 50);
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strSampleType, 2000);
                Sizes.Add(_str_strTestCategory, 2000);
                Sizes.Add(_str_strTestedByPerson, 400);
                Sizes.Add(_str_strTestedByOffice, 2000);
                Sizes.Add(_str_strTestResultName, 2000);
                Sizes.Add(_str_strDiagnosisName, 2000);
                Sizes.Add(_str_strVectorTypeName, 2000);
                GridMeta.Add(new GridMetaItem(
                    _str_idfTesting,
                    _str_idfTesting, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorID,
                    "Vector.strVectorID", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorTypeName,
                    "idfsVectorType", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorSubTypeName,
                    "idfsVectorSubType", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBarcode,
                    "VectorSample.strBarcode", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode,
                    "VectorSample.strFieldBarcode", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSampleType,
                    "idfsSampleType", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestName,
                    "TestName", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestCategory,
                    "idfPensideTestTestCategory", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datStartedDate,
                    "idfPensideTestTestDate", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestedByOffice,
                    "idfPensideTestTestedByOffice", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestedByPerson,
                    "idfPensideTestTestedByPerson", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestResultName,
                    "TestResult", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosisName,
                    "FT.strDisease", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_HasAmendmentHistory,
                    _str_HasAmendmentHistory, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAmendmentHistory,
                    "HasAmendmentHistory", null, false, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "ViewOnDetailForm",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ViewOnDetailForm(manager, (VectorLabTest)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strViewOnDetailForm_Id",
                        "",
                        /*from BvMessages*/"tooltipViewOnDetailForm_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    (c, p, b) => c != null  && !c.Key.Equals(PredefinedObjectId.FakeListObject),
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
	