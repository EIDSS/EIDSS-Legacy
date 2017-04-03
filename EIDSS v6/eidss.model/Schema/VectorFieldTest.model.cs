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
    public abstract partial class VectorFieldTest : 
        EditableObject<VectorFieldTest>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfPensideTest), NonUpdatable, PrimaryKey]
        public abstract Int64 idfPensideTest { get; set; }
                
        [LocalizedDisplayName("strPensideTypeName")]
        [MapField(_str_idfsPensideTestName)]
        public abstract Int64? idfsPensideTestName { get; set; }
        protected Int64? idfsPensideTestName_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPensideTestName).OriginalValue; } }
        protected Int64? idfsPensideTestName_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPensideTestName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPensideTestTypeName)]
        [MapField(_str_strPensideTestTypeName)]
        public abstract String strPensideTestTypeName { get; set; }
        protected String strPensideTestTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestTypeName).OriginalValue; } }
        protected String strPensideTestTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestTypeName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfVectorSurveillanceSession)]
        [MapField(_str_idfVectorSurveillanceSession)]
        public abstract Int64? idfVectorSurveillanceSession { get; set; }
        protected Int64? idfVectorSurveillanceSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).OriginalValue; } }
        protected Int64? idfVectorSurveillanceSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfVector)]
        [MapField(_str_idfVector)]
        public abstract Int64? idfVector { get; set; }
        protected Int64? idfVector_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).OriginalValue; } }
        protected Int64? idfVector_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVector).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_idfMaterial)]
        [MapField(_str_idfMaterial)]
        public abstract Int64 idfMaterial { get; set; }
        protected Int64 idfMaterial_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).OriginalValue; } }
        protected Int64 idfMaterial_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfMaterial).PreviousValue; } }
                
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
        [MapField(_str_strSampleName)]
        public abstract String strSampleName { get; set; }
        protected String strSampleName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).OriginalValue; } }
        protected String strSampleName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFieldCollectionDate)]
        [MapField(_str_datFieldCollectionDate)]
        public abstract DateTime? datFieldCollectionDate { get; set; }
        protected DateTime? datFieldCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).OriginalValue; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).PreviousValue; } }
                
        [LocalizedDisplayName("idfPensideTestTestDate")]
        [MapField(_str_datTestDate)]
        public abstract DateTime? datTestDate { get; set; }
        protected DateTime? datTestDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTestDate).OriginalValue; } }
        protected DateTime? datTestDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTestDate).PreviousValue; } }
                
        [LocalizedDisplayName("idfPensideTestTestCategory")]
        [MapField(_str_idfsPensideTestCategory)]
        public abstract Int64? idfsPensideTestCategory { get; set; }
        protected Int64? idfsPensideTestCategory_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPensideTestCategory).OriginalValue; } }
        protected Int64? idfsPensideTestCategory_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPensideTestCategory).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPensideTestCategoryName)]
        [MapField(_str_strPensideTestCategoryName)]
        public abstract String strPensideTestCategoryName { get; set; }
        protected String strPensideTestCategoryName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestCategoryName).OriginalValue; } }
        protected String strPensideTestCategoryName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestCategoryName).PreviousValue; } }
                
        [LocalizedDisplayName("idfPensideTestTestedByPerson")]
        [MapField(_str_idfTestedByPerson)]
        public abstract Int64? idfTestedByPerson { get; set; }
        protected Int64? idfTestedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByPerson).OriginalValue; } }
        protected Int64? idfTestedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCollectedByPerson)]
        [MapField(_str_strCollectedByPerson)]
        public abstract String strCollectedByPerson { get; set; }
        protected String strCollectedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByPerson).OriginalValue; } }
        protected String strCollectedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName("idfPensideTestTestedByOffice")]
        [MapField(_str_idfTestedByOffice)]
        public abstract Int64? idfTestedByOffice { get; set; }
        protected Int64? idfTestedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByOffice).OriginalValue; } }
        protected Int64? idfTestedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCollectedByOffice)]
        [MapField(_str_strCollectedByOffice)]
        public abstract String strCollectedByOffice { get; set; }
        protected String strCollectedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByOffice).OriginalValue; } }
        protected String strCollectedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName("FT.PensideTestResult")]
        [MapField(_str_idfsPensideTestResult)]
        public abstract Int64? idfsPensideTestResult { get; set; }
        protected Int64? idfsPensideTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPensideTestResult).OriginalValue; } }
        protected Int64? idfsPensideTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPensideTestResult).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPensideTestResultName)]
        [MapField(_str_strPensideTestResultName)]
        public abstract String strPensideTestResultName { get; set; }
        protected String strPensideTestResultName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestResultName).OriginalValue; } }
        protected String strPensideTestResultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestResultName).PreviousValue; } }
                
        [LocalizedDisplayName("FT.strDisease")]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64? idfsDiagnosis { get; set; }
        protected Int64? idfsDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64? idfsDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDiagnosisName)]
        [MapField(_str_strDiagnosisName)]
        public abstract String strDiagnosisName { get; set; }
        protected String strDiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisName).OriginalValue; } }
        protected String strDiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32? intOrder { get; set; }
        protected Int32? intOrder_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32? intOrder_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).PreviousValue; } }
                
        [LocalizedDisplayName("Vector.strVectorID")]
        [MapField(_str_strVectorID)]
        public abstract String strVectorID { get; set; }
        protected String strVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).OriginalValue; } }
        protected String strVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<VectorFieldTest, object> _get_func;
            internal Action<VectorFieldTest, string> _set_func;
            internal Action<VectorFieldTest, VectorFieldTest, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfPensideTest = "idfPensideTest";
        internal const string _str_idfsPensideTestName = "idfsPensideTestName";
        internal const string _str_strPensideTestTypeName = "strPensideTestTypeName";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfVector = "idfVector";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_strVectorTypeName = "strVectorTypeName";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_idfsSampleType = "idfsSampleType";
        internal const string _str_strSampleName = "strSampleName";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_datTestDate = "datTestDate";
        internal const string _str_idfsPensideTestCategory = "idfsPensideTestCategory";
        internal const string _str_strPensideTestCategoryName = "strPensideTestCategoryName";
        internal const string _str_idfTestedByPerson = "idfTestedByPerson";
        internal const string _str_strCollectedByPerson = "strCollectedByPerson";
        internal const string _str_idfTestedByOffice = "idfTestedByOffice";
        internal const string _str_strCollectedByOffice = "strCollectedByOffice";
        internal const string _str_idfsPensideTestResult = "idfsPensideTestResult";
        internal const string _str_strPensideTestResultName = "strPensideTestResultName";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_strDiagnosisName = "strDiagnosisName";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_strVectorID = "strVectorID";
        internal const string _str_strPensideTestName = "strPensideTestName";
        internal const string _str_strPensideTestCategory = "strPensideTestCategory";
        internal const string _str_strPensideTestResult = "strPensideTestResult";
        internal const string _str_strDiagnosis = "strDiagnosis";
        internal const string _str_strTestedByOffice = "strTestedByOffice";
        internal const string _str_strTestedByPerson = "strTestedByPerson";
        internal const string _str_strSampleFieldBarcode = "strSampleFieldBarcode";
        internal const string _str_strVectorSubTypeName = "strVectorSubTypeName";
        internal const string _str_ParentVector = "ParentVector";
        internal const string _str_Samples = "Samples";
        internal const string _str_SamplesSelectList = "SamplesSelectList";
        internal const string _str_ParentSample = "ParentSample";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_Vectors = "Vectors";
        internal const string _str_TestType = "TestType";
        internal const string _str_TestCategory = "TestCategory";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_TestResult = "TestResult";
        internal const string _str_DiagnosisFiltered = "DiagnosisFiltered";
        internal const string _str_TestResultFiltered = "TestResultFiltered";
        internal const string _str_TestedByPerson = "TestedByPerson";
        internal const string _str_TestedByOffice = "TestedByOffice";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfPensideTest, _formname = _str_idfPensideTest, _type = "Int64",
              _get_func = o => o.idfPensideTest,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfPensideTest != newval) o.idfPensideTest = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfPensideTest != c.idfPensideTest || o.IsRIRPropChanged(_str_idfPensideTest, c)) 
                  m.Add(_str_idfPensideTest, o.ObjectIdent + _str_idfPensideTest, o.ObjectIdent2 + _str_idfPensideTest, o.ObjectIdent3 + _str_idfPensideTest, "Int64", 
                    o.idfPensideTest == null ? "" : o.idfPensideTest.ToString(),                  
                  o.IsReadOnly(_str_idfPensideTest), o.IsInvisible(_str_idfPensideTest), o.IsRequired(_str_idfPensideTest)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsPensideTestName, _formname = _str_idfsPensideTestName, _type = "Int64?",
              _get_func = o => o.idfsPensideTestName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsPensideTestName != newval) 
                  o.TestType = o.TestTypeLookup.FirstOrDefault(c => c.idfsPensideTestName == newval);
                if (o.idfsPensideTestName != newval) o.idfsPensideTestName = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsPensideTestName != c.idfsPensideTestName || o.IsRIRPropChanged(_str_idfsPensideTestName, c)) 
                  m.Add(_str_idfsPensideTestName, o.ObjectIdent + _str_idfsPensideTestName, o.ObjectIdent2 + _str_idfsPensideTestName, o.ObjectIdent3 + _str_idfsPensideTestName, "Int64?", 
                    o.idfsPensideTestName == null ? "" : o.idfsPensideTestName.ToString(),                  
                  o.IsReadOnly(_str_idfsPensideTestName), o.IsInvisible(_str_idfsPensideTestName), o.IsRequired(_str_idfsPensideTestName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPensideTestTypeName, _formname = _str_strPensideTestTypeName, _type = "String",
              _get_func = o => o.strPensideTestTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPensideTestTypeName != newval) o.strPensideTestTypeName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPensideTestTypeName != c.strPensideTestTypeName || o.IsRIRPropChanged(_str_strPensideTestTypeName, c)) 
                  m.Add(_str_strPensideTestTypeName, o.ObjectIdent + _str_strPensideTestTypeName, o.ObjectIdent2 + _str_strPensideTestTypeName, o.ObjectIdent3 + _str_strPensideTestTypeName, "String", 
                    o.strPensideTestTypeName == null ? "" : o.strPensideTestTypeName.ToString(),                  
                  o.IsReadOnly(_str_strPensideTestTypeName), o.IsInvisible(_str_strPensideTestTypeName), o.IsRequired(_str_strPensideTestTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _formname = _str_idfVectorSurveillanceSession, _type = "Int64?",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfVectorSurveillanceSession != newval) o.idfVectorSurveillanceSession = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, o.ObjectIdent2 + _str_idfVectorSurveillanceSession, o.ObjectIdent3 + _str_idfVectorSurveillanceSession, "Int64?", 
                    o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(),                  
                  o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVector, _formname = _str_idfVector, _type = "Int64?",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfVector != newval) o.idfVector = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, o.ObjectIdent2 + _str_idfVector, o.ObjectIdent3 + _str_idfVector, "Int64?", 
                    o.idfVector == null ? "" : o.idfVector.ToString(),                  
                  o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsVectorType, _formname = _str_idfsVectorType, _type = "Int64",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsVectorType != newval) o.idfsVectorType = newval; },
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
                if (o.strVectorTypeName != c.strVectorTypeName || o.IsRIRPropChanged(_str_strVectorTypeName, c)) 
                  m.Add(_str_strVectorTypeName, o.ObjectIdent + _str_strVectorTypeName, o.ObjectIdent2 + _str_strVectorTypeName, o.ObjectIdent3 + _str_strVectorTypeName, "String", 
                    o.strVectorTypeName == null ? "" : o.strVectorTypeName.ToString(),                  
                  o.IsReadOnly(_str_strVectorTypeName), o.IsInvisible(_str_strVectorTypeName), o.IsRequired(_str_strVectorTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMaterial, _formname = _str_idfMaterial, _type = "Int64",
              _get_func = o => o.idfMaterial,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfMaterial != newval) o.idfMaterial = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfMaterial != c.idfMaterial || o.IsRIRPropChanged(_str_idfMaterial, c)) 
                  m.Add(_str_idfMaterial, o.ObjectIdent + _str_idfMaterial, o.ObjectIdent2 + _str_idfMaterial, o.ObjectIdent3 + _str_idfMaterial, "Int64", 
                    o.idfMaterial == null ? "" : o.idfMaterial.ToString(),                  
                  o.IsReadOnly(_str_idfMaterial), o.IsInvisible(_str_idfMaterial), o.IsRequired(_str_idfMaterial)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFieldBarcode, _formname = _str_strFieldBarcode, _type = "String",
              _get_func = o => o.strFieldBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldBarcode != newval) o.strFieldBarcode = newval; },
              _compare_func = (o, c, m) => {
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
              _compare_func = (o, c, m) => {
                if (o.idfsSampleType != c.idfsSampleType || o.IsRIRPropChanged(_str_idfsSampleType, c)) 
                  m.Add(_str_idfsSampleType, o.ObjectIdent + _str_idfsSampleType, o.ObjectIdent2 + _str_idfsSampleType, o.ObjectIdent3 + _str_idfsSampleType, "Int64", 
                    o.idfsSampleType == null ? "" : o.idfsSampleType.ToString(),                  
                  o.IsReadOnly(_str_idfsSampleType), o.IsInvisible(_str_idfsSampleType), o.IsRequired(_str_idfsSampleType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSampleName, _formname = _str_strSampleName, _type = "String",
              _get_func = o => o.strSampleName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSampleName != newval) o.strSampleName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSampleName != c.strSampleName || o.IsRIRPropChanged(_str_strSampleName, c)) 
                  m.Add(_str_strSampleName, o.ObjectIdent + _str_strSampleName, o.ObjectIdent2 + _str_strSampleName, o.ObjectIdent3 + _str_strSampleName, "String", 
                    o.strSampleName == null ? "" : o.strSampleName.ToString(),                  
                  o.IsReadOnly(_str_strSampleName), o.IsInvisible(_str_strSampleName), o.IsRequired(_str_strSampleName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datFieldCollectionDate, _formname = _str_datFieldCollectionDate, _type = "DateTime?",
              _get_func = o => o.datFieldCollectionDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datFieldCollectionDate != newval) o.datFieldCollectionDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datFieldCollectionDate != c.datFieldCollectionDate || o.IsRIRPropChanged(_str_datFieldCollectionDate, c)) 
                  m.Add(_str_datFieldCollectionDate, o.ObjectIdent + _str_datFieldCollectionDate, o.ObjectIdent2 + _str_datFieldCollectionDate, o.ObjectIdent3 + _str_datFieldCollectionDate, "DateTime?", 
                    o.datFieldCollectionDate == null ? "" : o.datFieldCollectionDate.ToString(),                  
                  o.IsReadOnly(_str_datFieldCollectionDate), o.IsInvisible(_str_datFieldCollectionDate), o.IsRequired(_str_datFieldCollectionDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datTestDate, _formname = _str_datTestDate, _type = "DateTime?",
              _get_func = o => o.datTestDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datTestDate != newval) o.datTestDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datTestDate != c.datTestDate || o.IsRIRPropChanged(_str_datTestDate, c)) 
                  m.Add(_str_datTestDate, o.ObjectIdent + _str_datTestDate, o.ObjectIdent2 + _str_datTestDate, o.ObjectIdent3 + _str_datTestDate, "DateTime?", 
                    o.datTestDate == null ? "" : o.datTestDate.ToString(),                  
                  o.IsReadOnly(_str_datTestDate), o.IsInvisible(_str_datTestDate), o.IsRequired(_str_datTestDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsPensideTestCategory, _formname = _str_idfsPensideTestCategory, _type = "Int64?",
              _get_func = o => o.idfsPensideTestCategory,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsPensideTestCategory != newval) 
                  o.TestCategory = o.TestCategoryLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsPensideTestCategory != newval) o.idfsPensideTestCategory = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsPensideTestCategory != c.idfsPensideTestCategory || o.IsRIRPropChanged(_str_idfsPensideTestCategory, c)) 
                  m.Add(_str_idfsPensideTestCategory, o.ObjectIdent + _str_idfsPensideTestCategory, o.ObjectIdent2 + _str_idfsPensideTestCategory, o.ObjectIdent3 + _str_idfsPensideTestCategory, "Int64?", 
                    o.idfsPensideTestCategory == null ? "" : o.idfsPensideTestCategory.ToString(),                  
                  o.IsReadOnly(_str_idfsPensideTestCategory), o.IsInvisible(_str_idfsPensideTestCategory), o.IsRequired(_str_idfsPensideTestCategory)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPensideTestCategoryName, _formname = _str_strPensideTestCategoryName, _type = "String",
              _get_func = o => o.strPensideTestCategoryName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPensideTestCategoryName != newval) o.strPensideTestCategoryName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPensideTestCategoryName != c.strPensideTestCategoryName || o.IsRIRPropChanged(_str_strPensideTestCategoryName, c)) 
                  m.Add(_str_strPensideTestCategoryName, o.ObjectIdent + _str_strPensideTestCategoryName, o.ObjectIdent2 + _str_strPensideTestCategoryName, o.ObjectIdent3 + _str_strPensideTestCategoryName, "String", 
                    o.strPensideTestCategoryName == null ? "" : o.strPensideTestCategoryName.ToString(),                  
                  o.IsReadOnly(_str_strPensideTestCategoryName), o.IsInvisible(_str_strPensideTestCategoryName), o.IsRequired(_str_strPensideTestCategoryName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfTestedByPerson, _formname = _str_idfTestedByPerson, _type = "Int64?",
              _get_func = o => o.idfTestedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfTestedByPerson != newval) 
                  o.TestedByPerson = o.TestedByPersonLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfTestedByPerson != newval) o.idfTestedByPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByPerson != c.idfTestedByPerson || o.IsRIRPropChanged(_str_idfTestedByPerson, c)) 
                  m.Add(_str_idfTestedByPerson, o.ObjectIdent + _str_idfTestedByPerson, o.ObjectIdent2 + _str_idfTestedByPerson, o.ObjectIdent3 + _str_idfTestedByPerson, "Int64?", 
                    o.idfTestedByPerson == null ? "" : o.idfTestedByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfTestedByPerson), o.IsInvisible(_str_idfTestedByPerson), o.IsRequired(_str_idfTestedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCollectedByPerson, _formname = _str_strCollectedByPerson, _type = "String",
              _get_func = o => o.strCollectedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCollectedByPerson != newval) o.strCollectedByPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.strCollectedByPerson != c.strCollectedByPerson || o.IsRIRPropChanged(_str_strCollectedByPerson, c)) 
                  m.Add(_str_strCollectedByPerson, o.ObjectIdent + _str_strCollectedByPerson, o.ObjectIdent2 + _str_strCollectedByPerson, o.ObjectIdent3 + _str_strCollectedByPerson, "String", 
                    o.strCollectedByPerson == null ? "" : o.strCollectedByPerson.ToString(),                  
                  o.IsReadOnly(_str_strCollectedByPerson), o.IsInvisible(_str_strCollectedByPerson), o.IsRequired(_str_strCollectedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfTestedByOffice, _formname = _str_idfTestedByOffice, _type = "Int64?",
              _get_func = o => o.idfTestedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfTestedByOffice != newval) 
                  o.TestedByOffice = o.TestedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfTestedByOffice != newval) o.idfTestedByOffice = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByOffice != c.idfTestedByOffice || o.IsRIRPropChanged(_str_idfTestedByOffice, c)) 
                  m.Add(_str_idfTestedByOffice, o.ObjectIdent + _str_idfTestedByOffice, o.ObjectIdent2 + _str_idfTestedByOffice, o.ObjectIdent3 + _str_idfTestedByOffice, "Int64?", 
                    o.idfTestedByOffice == null ? "" : o.idfTestedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfTestedByOffice), o.IsInvisible(_str_idfTestedByOffice), o.IsRequired(_str_idfTestedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCollectedByOffice, _formname = _str_strCollectedByOffice, _type = "String",
              _get_func = o => o.strCollectedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCollectedByOffice != newval) o.strCollectedByOffice = newval; },
              _compare_func = (o, c, m) => {
                if (o.strCollectedByOffice != c.strCollectedByOffice || o.IsRIRPropChanged(_str_strCollectedByOffice, c)) 
                  m.Add(_str_strCollectedByOffice, o.ObjectIdent + _str_strCollectedByOffice, o.ObjectIdent2 + _str_strCollectedByOffice, o.ObjectIdent3 + _str_strCollectedByOffice, "String", 
                    o.strCollectedByOffice == null ? "" : o.strCollectedByOffice.ToString(),                  
                  o.IsReadOnly(_str_strCollectedByOffice), o.IsInvisible(_str_strCollectedByOffice), o.IsRequired(_str_strCollectedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsPensideTestResult, _formname = _str_idfsPensideTestResult, _type = "Int64?",
              _get_func = o => o.idfsPensideTestResult,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsPensideTestResult != newval) 
                  o.TestResult = o.TestResultLookup.FirstOrDefault(c => c.idfsPensideTestResult == newval);
                if (o.idfsPensideTestResult != newval) o.idfsPensideTestResult = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsPensideTestResult != c.idfsPensideTestResult || o.IsRIRPropChanged(_str_idfsPensideTestResult, c)) 
                  m.Add(_str_idfsPensideTestResult, o.ObjectIdent + _str_idfsPensideTestResult, o.ObjectIdent2 + _str_idfsPensideTestResult, o.ObjectIdent3 + _str_idfsPensideTestResult, "Int64?", 
                    o.idfsPensideTestResult == null ? "" : o.idfsPensideTestResult.ToString(),                  
                  o.IsReadOnly(_str_idfsPensideTestResult), o.IsInvisible(_str_idfsPensideTestResult), o.IsRequired(_str_idfsPensideTestResult)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPensideTestResultName, _formname = _str_strPensideTestResultName, _type = "String",
              _get_func = o => o.strPensideTestResultName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPensideTestResultName != newval) o.strPensideTestResultName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPensideTestResultName != c.strPensideTestResultName || o.IsRIRPropChanged(_str_strPensideTestResultName, c)) 
                  m.Add(_str_strPensideTestResultName, o.ObjectIdent + _str_strPensideTestResultName, o.ObjectIdent2 + _str_strPensideTestResultName, o.ObjectIdent3 + _str_strPensideTestResultName, "String", 
                    o.strPensideTestResultName == null ? "" : o.strPensideTestResultName.ToString(),                  
                  o.IsReadOnly(_str_strPensideTestResultName), o.IsInvisible(_str_strPensideTestResultName), o.IsRequired(_str_strPensideTestResultName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "Int64?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsDiagnosis != newval) 
                  o.Diagnosis = o.DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis, "Int64?", 
                    o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDiagnosisName, _formname = _str_strDiagnosisName, _type = "String",
              _get_func = o => o.strDiagnosisName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnosisName != newval) o.strDiagnosisName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDiagnosisName != c.strDiagnosisName || o.IsRIRPropChanged(_str_strDiagnosisName, c)) 
                  m.Add(_str_strDiagnosisName, o.ObjectIdent + _str_strDiagnosisName, o.ObjectIdent2 + _str_strDiagnosisName, o.ObjectIdent3 + _str_strDiagnosisName, "String", 
                    o.strDiagnosisName == null ? "" : o.strDiagnosisName.ToString(),                  
                  o.IsReadOnly(_str_strDiagnosisName), o.IsInvisible(_str_strDiagnosisName), o.IsRequired(_str_strDiagnosisName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intOrder, _formname = _str_intOrder, _type = "Int32?",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intOrder != newval) o.intOrder = newval; },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, o.ObjectIdent2 + _str_intOrder, o.ObjectIdent3 + _str_intOrder, "Int32?", 
                    o.intOrder == null ? "" : o.intOrder.ToString(),                  
                  o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strVectorID, _formname = _str_strVectorID, _type = "String",
              _get_func = o => o.strVectorID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectorID != newval) o.strVectorID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strVectorID != c.strVectorID || o.IsRIRPropChanged(_str_strVectorID, c)) 
                  m.Add(_str_strVectorID, o.ObjectIdent + _str_strVectorID, o.ObjectIdent2 + _str_strVectorID, o.ObjectIdent3 + _str_strVectorID, "String", 
                    o.strVectorID == null ? "" : o.strVectorID.ToString(),                  
                  o.IsReadOnly(_str_strVectorID), o.IsInvisible(_str_strVectorID), o.IsRequired(_str_strVectorID)); 
                  }
              }, 
        
            new field_info {
              _name = _str_strPensideTestName, _formname = _str_strPensideTestName, _type = "string",
              _get_func = o => o.strPensideTestName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strPensideTestName != c.strPensideTestName || o.IsRIRPropChanged(_str_strPensideTestName, c)) {
                  m.Add(_str_strPensideTestName, o.ObjectIdent + _str_strPensideTestName, o.ObjectIdent2 + _str_strPensideTestName, o.ObjectIdent3 + _str_strPensideTestName, "string", o.strPensideTestName == null ? "" : o.strPensideTestName.ToString(), o.IsReadOnly(_str_strPensideTestName), o.IsInvisible(_str_strPensideTestName), o.IsRequired(_str_strPensideTestName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strPensideTestCategory, _formname = _str_strPensideTestCategory, _type = "string",
              _get_func = o => o.strPensideTestCategory,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strPensideTestCategory != c.strPensideTestCategory || o.IsRIRPropChanged(_str_strPensideTestCategory, c)) {
                  m.Add(_str_strPensideTestCategory, o.ObjectIdent + _str_strPensideTestCategory, o.ObjectIdent2 + _str_strPensideTestCategory, o.ObjectIdent3 + _str_strPensideTestCategory, "string", o.strPensideTestCategory == null ? "" : o.strPensideTestCategory.ToString(), o.IsReadOnly(_str_strPensideTestCategory), o.IsInvisible(_str_strPensideTestCategory), o.IsRequired(_str_strPensideTestCategory));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strPensideTestResult, _formname = _str_strPensideTestResult, _type = "string",
              _get_func = o => o.strPensideTestResult,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strPensideTestResult != c.strPensideTestResult || o.IsRIRPropChanged(_str_strPensideTestResult, c)) {
                  m.Add(_str_strPensideTestResult, o.ObjectIdent + _str_strPensideTestResult, o.ObjectIdent2 + _str_strPensideTestResult, o.ObjectIdent3 + _str_strPensideTestResult, "string", o.strPensideTestResult == null ? "" : o.strPensideTestResult.ToString(), o.IsReadOnly(_str_strPensideTestResult), o.IsInvisible(_str_strPensideTestResult), o.IsRequired(_str_strPensideTestResult));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strDiagnosis, _formname = _str_strDiagnosis, _type = "string",
              _get_func = o => o.strDiagnosis,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strDiagnosis != c.strDiagnosis || o.IsRIRPropChanged(_str_strDiagnosis, c)) {
                  m.Add(_str_strDiagnosis, o.ObjectIdent + _str_strDiagnosis, o.ObjectIdent2 + _str_strDiagnosis, o.ObjectIdent3 + _str_strDiagnosis, "string", o.strDiagnosis == null ? "" : o.strDiagnosis.ToString(), o.IsReadOnly(_str_strDiagnosis), o.IsInvisible(_str_strDiagnosis), o.IsRequired(_str_strDiagnosis));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strTestedByOffice, _formname = _str_strTestedByOffice, _type = "string",
              _get_func = o => o.strTestedByOffice,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strTestedByOffice != c.strTestedByOffice || o.IsRIRPropChanged(_str_strTestedByOffice, c)) {
                  m.Add(_str_strTestedByOffice, o.ObjectIdent + _str_strTestedByOffice, o.ObjectIdent2 + _str_strTestedByOffice, o.ObjectIdent3 + _str_strTestedByOffice, "string", o.strTestedByOffice == null ? "" : o.strTestedByOffice.ToString(), o.IsReadOnly(_str_strTestedByOffice), o.IsInvisible(_str_strTestedByOffice), o.IsRequired(_str_strTestedByOffice));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strTestedByPerson, _formname = _str_strTestedByPerson, _type = "string",
              _get_func = o => o.strTestedByPerson,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strTestedByPerson != c.strTestedByPerson || o.IsRIRPropChanged(_str_strTestedByPerson, c)) {
                  m.Add(_str_strTestedByPerson, o.ObjectIdent + _str_strTestedByPerson, o.ObjectIdent2 + _str_strTestedByPerson, o.ObjectIdent3 + _str_strTestedByPerson, "string", o.strTestedByPerson == null ? "" : o.strTestedByPerson.ToString(), o.IsReadOnly(_str_strTestedByPerson), o.IsInvisible(_str_strTestedByPerson), o.IsRequired(_str_strTestedByPerson));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strSampleFieldBarcode, _formname = _str_strSampleFieldBarcode, _type = "string",
              _get_func = o => o.strSampleFieldBarcode,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strSampleFieldBarcode != c.strSampleFieldBarcode || o.IsRIRPropChanged(_str_strSampleFieldBarcode, c)) {
                  m.Add(_str_strSampleFieldBarcode, o.ObjectIdent + _str_strSampleFieldBarcode, o.ObjectIdent2 + _str_strSampleFieldBarcode, o.ObjectIdent3 + _str_strSampleFieldBarcode, "string", o.strSampleFieldBarcode == null ? "" : o.strSampleFieldBarcode.ToString(), o.IsReadOnly(_str_strSampleFieldBarcode), o.IsInvisible(_str_strSampleFieldBarcode), o.IsRequired(_str_strSampleFieldBarcode));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strVectorSubTypeName, _formname = _str_strVectorSubTypeName, _type = "string",
              _get_func = o => o.strVectorSubTypeName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strVectorSubTypeName != c.strVectorSubTypeName || o.IsRIRPropChanged(_str_strVectorSubTypeName, c)) {
                  m.Add(_str_strVectorSubTypeName, o.ObjectIdent + _str_strVectorSubTypeName, o.ObjectIdent2 + _str_strVectorSubTypeName, o.ObjectIdent3 + _str_strVectorSubTypeName, "string", o.strVectorSubTypeName == null ? "" : o.strVectorSubTypeName.ToString(), o.IsReadOnly(_str_strVectorSubTypeName), o.IsInvisible(_str_strVectorSubTypeName), o.IsRequired(_str_strVectorSubTypeName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_ParentVector, _formname = _str_ParentVector, _type = "Vector",
              _get_func = o => o.ParentVector,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
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
              _name = _str_SamplesSelectList, _formname = _str_SamplesSelectList, _type = "BvSelectList",
              _get_func = o => o.SamplesSelectList,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_ParentSample, _formname = _str_ParentSample, _type = "VectorSample",
              _get_func = o => o.ParentSample,
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
              _name = _str_Vectors, _formname = _str_Vectors, _type = "EditableList<Vector>",
              _get_func = o => o.Vectors,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_TestType, _formname = _str_TestType, _type = "Lookup",
              _get_func = o => { if (o.TestType == null) return null; return o.TestType.idfsPensideTestName; },
              _set_func = (o, val) => { o.TestType = o.TestTypeLookup.Where(c => c.idfsPensideTestName.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsPensideTestName != c.idfsPensideTestName || o.IsRIRPropChanged(_str_TestType, c)) {
                  m.Add(_str_TestType, o.ObjectIdent + _str_TestType, o.ObjectIdent2 + _str_TestType, o.ObjectIdent3 + _str_TestType, "Lookup", o.idfsPensideTestName == null ? "" : o.idfsPensideTestName.ToString(), o.IsReadOnly(_str_TestType), o.IsInvisible(_str_TestType), o.IsRequired(_str_TestType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestType + "Lookup", _formname = _str_TestType + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestCategory, _formname = _str_TestCategory, _type = "Lookup",
              _get_func = o => { if (o.TestCategory == null) return null; return o.TestCategory.idfsBaseReference; },
              _set_func = (o, val) => { o.TestCategory = o.TestCategoryLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsPensideTestCategory != c.idfsPensideTestCategory || o.IsRIRPropChanged(_str_TestCategory, c)) {
                  m.Add(_str_TestCategory, o.ObjectIdent + _str_TestCategory, o.ObjectIdent2 + _str_TestCategory, o.ObjectIdent3 + _str_TestCategory, "Lookup", o.idfsPensideTestCategory == null ? "" : o.idfsPensideTestCategory.ToString(), o.IsReadOnly(_str_TestCategory), o.IsInvisible(_str_TestCategory), o.IsRequired(_str_TestCategory)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestCategory + "Lookup", _formname = _str_TestCategory + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestCategoryLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _formname = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c)) {
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, o.ObjectIdent2 + _str_Diagnosis, o.ObjectIdent3 + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Diagnosis + "Lookup", _formname = _str_Diagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestResult, _formname = _str_TestResult, _type = "Lookup",
              _get_func = o => { if (o.TestResult == null) return null; return o.TestResult.idfsPensideTestResult; },
              _set_func = (o, val) => { o.TestResult = o.TestResultLookup.Where(c => c.idfsPensideTestResult.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsPensideTestResult != c.idfsPensideTestResult || o.IsRIRPropChanged(_str_TestResult, c)) {
                  m.Add(_str_TestResult, o.ObjectIdent + _str_TestResult, o.ObjectIdent2 + _str_TestResult, o.ObjectIdent3 + _str_TestResult, "Lookup", o.idfsPensideTestResult == null ? "" : o.idfsPensideTestResult.ToString(), o.IsReadOnly(_str_TestResult), o.IsInvisible(_str_TestResult), o.IsRequired(_str_TestResult)); 
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
              _name = _str_DiagnosisFiltered, _formname = _str_DiagnosisFiltered, _type = "Lookup",
              _get_func = o => { if (o.DiagnosisFiltered == null) return null; return o.DiagnosisFiltered.idfsDiagnosis; },
              _set_func = (o, val) => { o.DiagnosisFiltered = o.DiagnosisFilteredLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_DiagnosisFiltered, c)) {
                  m.Add(_str_DiagnosisFiltered, o.ObjectIdent + _str_DiagnosisFiltered, o.ObjectIdent2 + _str_DiagnosisFiltered, o.ObjectIdent3 + _str_DiagnosisFiltered, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_DiagnosisFiltered), o.IsInvisible(_str_DiagnosisFiltered), o.IsRequired(_str_DiagnosisFiltered)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_DiagnosisFiltered + "Lookup", _formname = _str_DiagnosisFiltered + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisFilteredLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestResultFiltered, _formname = _str_TestResultFiltered, _type = "Lookup",
              _get_func = o => { if (o.TestResultFiltered == null) return null; return o.TestResultFiltered.idfsPensideTestResult; },
              _set_func = (o, val) => { o.TestResultFiltered = o.TestResultFilteredLookup.Where(c => c.idfsPensideTestResult.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsPensideTestResult != c.idfsPensideTestResult || o.IsRIRPropChanged(_str_TestResultFiltered, c)) {
                  m.Add(_str_TestResultFiltered, o.ObjectIdent + _str_TestResultFiltered, o.ObjectIdent2 + _str_TestResultFiltered, o.ObjectIdent3 + _str_TestResultFiltered, "Lookup", o.idfsPensideTestResult == null ? "" : o.idfsPensideTestResult.ToString(), o.IsReadOnly(_str_TestResultFiltered), o.IsInvisible(_str_TestResultFiltered), o.IsRequired(_str_TestResultFiltered)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestResultFiltered + "Lookup", _formname = _str_TestResultFiltered + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestResultFilteredLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestedByPerson, _formname = _str_TestedByPerson, _type = "Lookup",
              _get_func = o => { if (o.TestedByPerson == null) return null; return o.TestedByPerson.idfPerson; },
              _set_func = (o, val) => { o.TestedByPerson = o.TestedByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByPerson != c.idfTestedByPerson || o.IsRIRPropChanged(_str_TestedByPerson, c)) {
                  m.Add(_str_TestedByPerson, o.ObjectIdent + _str_TestedByPerson, o.ObjectIdent2 + _str_TestedByPerson, o.ObjectIdent3 + _str_TestedByPerson, "Lookup", o.idfTestedByPerson == null ? "" : o.idfTestedByPerson.ToString(), o.IsReadOnly(_str_TestedByPerson), o.IsInvisible(_str_TestedByPerson), o.IsRequired(_str_TestedByPerson)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestedByPerson + "Lookup", _formname = _str_TestedByPerson + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestedByPersonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_TestedByOffice, _formname = _str_TestedByOffice, _type = "Lookup",
              _get_func = o => { if (o.TestedByOffice == null) return null; return o.TestedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.TestedByOffice = o.TestedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByOffice != c.idfTestedByOffice || o.IsRIRPropChanged(_str_TestedByOffice, c)) {
                  m.Add(_str_TestedByOffice, o.ObjectIdent + _str_TestedByOffice, o.ObjectIdent2 + _str_TestedByOffice, o.ObjectIdent3 + _str_TestedByOffice, "Lookup", o.idfTestedByOffice == null ? "" : o.idfTestedByOffice.ToString(), o.IsReadOnly(_str_TestedByOffice), o.IsInvisible(_str_TestedByOffice), o.IsRequired(_str_TestedByOffice)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_TestedByOffice + "Lookup", _formname = _str_TestedByOffice + "Lookup", _type = "LookupContent",
              _get_func = o => o.TestedByOfficeLookup,
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
            VectorFieldTest obj = (VectorFieldTest)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_TestType)]
        [Relation(typeof(PensideTestLookup), eidss.model.Schema.PensideTestLookup._str_idfsPensideTestName, _str_idfsPensideTestName)]
        public PensideTestLookup TestType
        {
            get { return _TestType == null ? null : ((long)_TestType.Key == 0 ? null : _TestType); }
            set 
            { 
                var oldVal = _TestType;
                _TestType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestType != oldVal)
                {
                    if (idfsPensideTestName != (_TestType == null
                            ? new Int64?()
                            : (Int64?)_TestType.idfsPensideTestName))
                        idfsPensideTestName = _TestType == null 
                            ? new Int64?()
                            : (Int64?)_TestType.idfsPensideTestName; 
                    OnPropertyChanged(_str_TestType); 
                }
            }
        }
        private PensideTestLookup _TestType;

        
        public List<PensideTestLookup> TestTypeLookup
        {
            get { return _TestTypeLookup; }
        }
        private List<PensideTestLookup> _TestTypeLookup = new List<PensideTestLookup>();
            
        [LocalizedDisplayName(_str_TestCategory)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsPensideTestCategory)]
        public BaseReference TestCategory
        {
            get { return _TestCategory == null ? null : ((long)_TestCategory.Key == 0 ? null : _TestCategory); }
            set 
            { 
                var oldVal = _TestCategory;
                _TestCategory = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestCategory != oldVal)
                {
                    if (idfsPensideTestCategory != (_TestCategory == null
                            ? new Int64?()
                            : (Int64?)_TestCategory.idfsBaseReference))
                        idfsPensideTestCategory = _TestCategory == null 
                            ? new Int64?()
                            : (Int64?)_TestCategory.idfsBaseReference; 
                    OnPropertyChanged(_str_TestCategory); 
                }
            }
        }
        private BaseReference _TestCategory;

        
        public BaseReferenceList TestCategoryLookup
        {
            get { return _TestCategoryLookup; }
        }
        private BaseReferenceList _TestCategoryLookup = new BaseReferenceList("rftPensideTestCategory");
            
        [LocalizedDisplayName(_str_Diagnosis)]
        [Relation(typeof(Diagnosis2PensideTestMatrixLookup), eidss.model.Schema.Diagnosis2PensideTestMatrixLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public Diagnosis2PensideTestMatrixLookup Diagnosis
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
        private Diagnosis2PensideTestMatrixLookup _Diagnosis;

        
        public List<Diagnosis2PensideTestMatrixLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<Diagnosis2PensideTestMatrixLookup> _DiagnosisLookup = new List<Diagnosis2PensideTestMatrixLookup>();
            
        [LocalizedDisplayName(_str_TestResult)]
        [Relation(typeof(TypeFieldTestToResultMatrixLookup), eidss.model.Schema.TypeFieldTestToResultMatrixLookup._str_idfsPensideTestResult, _str_idfsPensideTestResult)]
        public TypeFieldTestToResultMatrixLookup TestResult
        {
            get { return _TestResult == null ? null : ((long)_TestResult.Key == 0 ? null : _TestResult); }
            set 
            { 
                var oldVal = _TestResult;
                _TestResult = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestResult != oldVal)
                {
                    if (idfsPensideTestResult != (_TestResult == null
                            ? new Int64?()
                            : (Int64?)_TestResult.idfsPensideTestResult))
                        idfsPensideTestResult = _TestResult == null 
                            ? new Int64?()
                            : (Int64?)_TestResult.idfsPensideTestResult; 
                    OnPropertyChanged(_str_TestResult); 
                }
            }
        }
        private TypeFieldTestToResultMatrixLookup _TestResult;

        
        public List<TypeFieldTestToResultMatrixLookup> TestResultLookup
        {
            get { return _TestResultLookup; }
        }
        private List<TypeFieldTestToResultMatrixLookup> _TestResultLookup = new List<TypeFieldTestToResultMatrixLookup>();
            
        [LocalizedDisplayName(_str_DiagnosisFiltered)]
        [Relation(typeof(Diagnosis2PensideTestMatrixLookup), eidss.model.Schema.Diagnosis2PensideTestMatrixLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public Diagnosis2PensideTestMatrixLookup DiagnosisFiltered
        {
            get { return _DiagnosisFiltered == null ? null : ((long)_DiagnosisFiltered.Key == 0 ? null : _DiagnosisFiltered); }
            set 
            { 
                var oldVal = _DiagnosisFiltered;
                _DiagnosisFiltered = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_DiagnosisFiltered != oldVal)
                {
                    if (idfsDiagnosis != (_DiagnosisFiltered == null
                            ? new Int64?()
                            : (Int64?)_DiagnosisFiltered.idfsDiagnosis))
                        idfsDiagnosis = _DiagnosisFiltered == null 
                            ? new Int64?()
                            : (Int64?)_DiagnosisFiltered.idfsDiagnosis; 
                    OnPropertyChanged(_str_DiagnosisFiltered); 
                }
            }
        }
        private Diagnosis2PensideTestMatrixLookup _DiagnosisFiltered;

        
        public List<Diagnosis2PensideTestMatrixLookup> DiagnosisFilteredLookup
        {
            get { return _DiagnosisFilteredLookup; }
        }
        private List<Diagnosis2PensideTestMatrixLookup> _DiagnosisFilteredLookup = new List<Diagnosis2PensideTestMatrixLookup>();
            
        [LocalizedDisplayName(_str_TestResultFiltered)]
        [Relation(typeof(TypeFieldTestToResultMatrixLookup), eidss.model.Schema.TypeFieldTestToResultMatrixLookup._str_idfsPensideTestResult, _str_idfsPensideTestResult)]
        public TypeFieldTestToResultMatrixLookup TestResultFiltered
        {
            get { return _TestResultFiltered == null ? null : ((long)_TestResultFiltered.Key == 0 ? null : _TestResultFiltered); }
            set 
            { 
                var oldVal = _TestResultFiltered;
                _TestResultFiltered = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestResultFiltered != oldVal)
                {
                    if (idfsPensideTestResult != (_TestResultFiltered == null
                            ? new Int64?()
                            : (Int64?)_TestResultFiltered.idfsPensideTestResult))
                        idfsPensideTestResult = _TestResultFiltered == null 
                            ? new Int64?()
                            : (Int64?)_TestResultFiltered.idfsPensideTestResult; 
                    OnPropertyChanged(_str_TestResultFiltered); 
                }
            }
        }
        private TypeFieldTestToResultMatrixLookup _TestResultFiltered;

        
        public List<TypeFieldTestToResultMatrixLookup> TestResultFilteredLookup
        {
            get { return _TestResultFilteredLookup; }
        }
        private List<TypeFieldTestToResultMatrixLookup> _TestResultFilteredLookup = new List<TypeFieldTestToResultMatrixLookup>();
            
        [LocalizedDisplayName(_str_TestedByPerson)]
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfTestedByPerson)]
        public PersonLookup TestedByPerson
        {
            get { return _TestedByPerson == null ? null : ((long)_TestedByPerson.Key == 0 ? null : _TestedByPerson); }
            set 
            { 
                var oldVal = _TestedByPerson;
                _TestedByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestedByPerson != oldVal)
                {
                    if (idfTestedByPerson != (_TestedByPerson == null
                            ? new Int64?()
                            : (Int64?)_TestedByPerson.idfPerson))
                        idfTestedByPerson = _TestedByPerson == null 
                            ? new Int64?()
                            : (Int64?)_TestedByPerson.idfPerson; 
                    OnPropertyChanged(_str_TestedByPerson); 
                }
            }
        }
        private PersonLookup _TestedByPerson;

        
        public List<PersonLookup> TestedByPersonLookup
        {
            get { return _TestedByPersonLookup; }
        }
        private List<PersonLookup> _TestedByPersonLookup = new List<PersonLookup>();
            
        [LocalizedDisplayName(_str_TestedByOffice)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfTestedByOffice)]
        public OrganizationLookup TestedByOffice
        {
            get { return _TestedByOffice == null ? null : ((long)_TestedByOffice.Key == 0 ? null : _TestedByOffice); }
            set 
            { 
                var oldVal = _TestedByOffice;
                _TestedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_TestedByOffice != oldVal)
                {
                    if (idfTestedByOffice != (_TestedByOffice == null
                            ? new Int64?()
                            : (Int64?)_TestedByOffice.idfInstitution))
                        idfTestedByOffice = _TestedByOffice == null 
                            ? new Int64?()
                            : (Int64?)_TestedByOffice.idfInstitution; 
                    OnPropertyChanged(_str_TestedByOffice); 
                }
            }
        }
        private OrganizationLookup _TestedByOffice;

        
        public List<OrganizationLookup> TestedByOfficeLookup
        {
            get { return _TestedByOfficeLookup; }
        }
        private List<OrganizationLookup> _TestedByOfficeLookup = new List<OrganizationLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_TestType:
                    return new BvSelectList(TestTypeLookup, eidss.model.Schema.PensideTestLookup._str_idfsPensideTestName, null, TestType, _str_idfsPensideTestName);
            
                case _str_TestCategory:
                    return new BvSelectList(TestCategoryLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, TestCategory, _str_idfsPensideTestCategory);
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.Diagnosis2PensideTestMatrixLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_TestResult:
                    return new BvSelectList(TestResultLookup, eidss.model.Schema.TypeFieldTestToResultMatrixLookup._str_idfsPensideTestResult, null, TestResult, _str_idfsPensideTestResult);
            
                case _str_DiagnosisFiltered:
                    return new BvSelectList(DiagnosisFilteredLookup, eidss.model.Schema.Diagnosis2PensideTestMatrixLookup._str_idfsDiagnosis, null, DiagnosisFiltered, _str_idfsDiagnosis);
            
                case _str_TestResultFiltered:
                    return new BvSelectList(TestResultFilteredLookup, eidss.model.Schema.TypeFieldTestToResultMatrixLookup._str_idfsPensideTestResult, null, TestResultFiltered, _str_idfsPensideTestResult);
            
                case _str_TestedByPerson:
                    return new BvSelectList(TestedByPersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, TestedByPerson, _str_idfTestedByPerson);
            
                case _str_TestedByOffice:
                    return new BvSelectList(TestedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, TestedByOffice, _str_idfTestedByOffice);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName("strPensideTypeName")]
        public string strPensideTestName
        {
            get { return new Func<VectorFieldTest, string>(c => c.TestType == null ? String.Empty : c.TestType.strPensideTypeName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("idfPensideTestTestCategory")]
        public string strPensideTestCategory
        {
            get { return new Func<VectorFieldTest, string>(c => c.TestCategory == null ? String.Empty : c.TestCategory.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("FT.PensideTestResult")]
        public string strPensideTestResult
        {
            get { return new Func<VectorFieldTest, string>(c => c.TestResultFiltered == null ? String.Empty : c.TestResultFiltered.strPensideTestResultName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("FT.strDisease")]
        public string strDiagnosis
        {
            get { return new Func<VectorFieldTest, string>(c => c.DiagnosisFiltered == null ? String.Empty : c.DiagnosisFiltered.DiagnosisName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("idfPensideTestTestedByOffice")]
        public string strTestedByOffice
        {
            get { return new Func<VectorFieldTest, string>(c => c.TestedByOffice == null ? String.Empty : c.TestedByOffice.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("idfPensideTestTestedByPerson")]
        public string strTestedByPerson
        {
            get { return new Func<VectorFieldTest, string>(c => c.TestedByPerson == null ? String.Empty : c.TestedByPerson.FullName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("VectorSample.strFieldBarcode")]
        public string strSampleFieldBarcode
        {
            get { return new Func<VectorFieldTest, string>(c => c.ParentSample == null ? String.Empty : c.ParentSample.strFieldBarcode)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("idfsVectorSubType")]
        public string strVectorSubTypeName
        {
            get { return new Func<VectorFieldTest, string>(c => ((c.ParentVector != null) && (c.ParentVector.VectorSubType != null)) ? c.ParentVector.VectorSubType.name : String.Empty)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_ParentVector)]
        public Vector ParentVector
        {
            get { return new Func<VectorFieldTest, Vector>(c => Parent as Vector)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Samples)]
        public EditableList<VectorSample> Samples
        {
            get { return new Func<VectorFieldTest, EditableList<VectorSample>>(c => c.ParentVector == null ? new EditableList<VectorSample>() : c.ParentVector.Samples)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_SamplesSelectList)]
        public BvSelectList SamplesSelectList
        {
            get { return new Func<VectorFieldTest, BvSelectList>(c => c.Samples == null ? null : new BvSelectList(c.Samples, "idfMaterial", "strFieldBarcode", c.ParentSample, "idfMaterial"))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_ParentSample)]
        public VectorSample ParentSample
        {
            get { return new Func<VectorFieldTest, VectorSample>(c => c.Samples == null ? null : c.Samples.FirstOrDefault(s => s.idfMaterial == c.idfMaterial))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<VectorFieldTest, string>(c => "Vectors_" + c.idfVectorSurveillanceSession + "_")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Vectors)]
        public EditableList<Vector> Vectors
        {
            get { return new Func<VectorFieldTest, EditableList<Vector>>(c => c.ParentVector == null ? new EditableList<Vector>() : c.ParentVector.Vectors)(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VectorFieldTest";

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
            var ret = base.Clone() as VectorFieldTest;
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
            var ret = base.Clone() as VectorFieldTest;
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
        public VectorFieldTest CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VectorFieldTest;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfPensideTest; } }
        public string KeyName { get { return "idfPensideTest"; } }
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
        
            var _prev_idfsPensideTestName_TestType = idfsPensideTestName;
            var _prev_idfsPensideTestCategory_TestCategory = idfsPensideTestCategory;
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsPensideTestResult_TestResult = idfsPensideTestResult;
            var _prev_idfsDiagnosis_DiagnosisFiltered = idfsDiagnosis;
            var _prev_idfsPensideTestResult_TestResultFiltered = idfsPensideTestResult;
            var _prev_idfTestedByPerson_TestedByPerson = idfTestedByPerson;
            var _prev_idfTestedByOffice_TestedByOffice = idfTestedByOffice;
            base.RejectChanges();
        
            if (_prev_idfsPensideTestName_TestType != idfsPensideTestName)
            {
                _TestType = _TestTypeLookup.FirstOrDefault(c => c.idfsPensideTestName == idfsPensideTestName);
            }
            if (_prev_idfsPensideTestCategory_TestCategory != idfsPensideTestCategory)
            {
                _TestCategory = _TestCategoryLookup.FirstOrDefault(c => c.idfsBaseReference == idfsPensideTestCategory);
            }
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsPensideTestResult_TestResult != idfsPensideTestResult)
            {
                _TestResult = _TestResultLookup.FirstOrDefault(c => c.idfsPensideTestResult == idfsPensideTestResult);
            }
            if (_prev_idfsDiagnosis_DiagnosisFiltered != idfsDiagnosis)
            {
                _DiagnosisFiltered = _DiagnosisFilteredLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsPensideTestResult_TestResultFiltered != idfsPensideTestResult)
            {
                _TestResultFiltered = _TestResultFilteredLookup.FirstOrDefault(c => c.idfsPensideTestResult == idfsPensideTestResult);
            }
            if (_prev_idfTestedByPerson_TestedByPerson != idfTestedByPerson)
            {
                _TestedByPerson = _TestedByPersonLookup.FirstOrDefault(c => c.idfPerson == idfTestedByPerson);
            }
            if (_prev_idfTestedByOffice_TestedByOffice != idfTestedByOffice)
            {
                _TestedByOffice = _TestedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfTestedByOffice);
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

        private bool IsRIRPropChanged(string fld, VectorFieldTest c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public VectorFieldTest()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VectorFieldTest_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VectorFieldTest_PropertyChanged);
        }
        private void VectorFieldTest_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VectorFieldTest).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsPensideTestName)
                OnPropertyChanged(_str_strPensideTestName);
                  
            if (e.PropertyName == _str_idfsPensideTestCategory)
                OnPropertyChanged(_str_strPensideTestCategory);
                  
            if (e.PropertyName == _str_idfsPensideTestResult)
                OnPropertyChanged(_str_strPensideTestResult);
                  
            if (e.PropertyName == _str_idfsDiagnosis)
                OnPropertyChanged(_str_strDiagnosis);
                  
            if (e.PropertyName == _str_idfTestedByOffice)
                OnPropertyChanged(_str_strTestedByOffice);
                  
            if (e.PropertyName == _str_idfTestedByPerson)
                OnPropertyChanged(_str_strTestedByPerson);
                  
            if (e.PropertyName == _str_ParentSample)
                OnPropertyChanged(_str_strSampleFieldBarcode);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_strVectorSubTypeName);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_ParentVector);
                  
            if (e.PropertyName == _str_ParentVector)
                OnPropertyChanged(_str_Samples);
                  
            if (e.PropertyName == _str_Samples)
                OnPropertyChanged(_str_SamplesSelectList);
                  
            if (e.PropertyName == _str_idfMaterial)
                OnPropertyChanged(_str_ParentSample);
                  
            if (e.PropertyName == _str_idfVectorSurveillanceSession)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
            if (e.PropertyName == _str_ParentVector)
                OnPropertyChanged(_str_Vectors);
                  
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
            VectorFieldTest obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VectorFieldTest obj = this;
            
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

    
        private static string[] readonly_names1 = "TestedByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strSampleName,datFieldCollectionDate,strVectorID,strVectorTypeName,strVectorSubTypeName".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VectorFieldTest, bool>(c => TestedByOffice == null)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VectorFieldTest, bool>(c => true)(this);
            
            return ReadOnly || new Func<VectorFieldTest, bool>(c => false)(this);
                
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


        internal Dictionary<string, Func<VectorFieldTest, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VectorFieldTest, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VectorFieldTest, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VectorFieldTest, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VectorFieldTest, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<VectorFieldTest, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<VectorFieldTest, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VectorFieldTest()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("PensideTestLookup", this);
                
                LookupManager.RemoveObject("rftPensideTestCategory", this);
                
                LookupManager.RemoveObject("Diagnosis2PensideTestMatrixLookup", this);
                
                LookupManager.RemoveObject("TypeFieldTestToResultMatrixLookup", this);
                
                LookupManager.RemoveObject("Diagnosis2PensideTestMatrixLookup", this);
                
                LookupManager.RemoveObject("TypeFieldTestToResultMatrixLookup", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "PensideTestLookup")
                _getAccessor().LoadLookup_TestType(manager, this);
            
            if (lookup_object == "rftPensideTestCategory")
                _getAccessor().LoadLookup_TestCategory(manager, this);
            
            if (lookup_object == "Diagnosis2PensideTestMatrixLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "TypeFieldTestToResultMatrixLookup")
                _getAccessor().LoadLookup_TestResult(manager, this);
            
            if (lookup_object == "Diagnosis2PensideTestMatrixLookup")
                _getAccessor().LoadLookup_DiagnosisFiltered(manager, this);
            
            if (lookup_object == "TypeFieldTestToResultMatrixLookup")
                _getAccessor().LoadLookup_TestResultFiltered(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_TestedByPerson(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_TestedByOffice(manager, this);
            
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
        public class VectorFieldTestGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfPensideTest { get; set; }
        
            public String strVectorID { get; set; }
        
            public String strVectorTypeName { get; set; }
        
            public string strVectorSubTypeName { get; set; }
        
            public Int64 idfMaterial { get; set; }
        
            public string strSampleFieldBarcode { get; set; }
        
            public String strSampleName { get; set; }
        
            public DateTime? datFieldCollectionDate { get; set; }
        
            public Int64? idfsPensideTestName { get; set; }
        
            public string strPensideTestName { get; set; }
        
            public Int64? idfsPensideTestCategory { get; set; }
        
            public string strPensideTestCategory { get; set; }
        
            public DateTime? datTestDate { get; set; }
        
            public Int64? idfTestedByOffice { get; set; }
        
            public string strTestedByOffice { get; set; }
        
            public Int64? idfTestedByPerson { get; set; }
        
            public string strTestedByPerson { get; set; }
        
            public Int64? idfsPensideTestResult { get; set; }
        
            public string strPensideTestResult { get; set; }
        
            public Int64? idfsDiagnosis { get; set; }
        
            public string strDiagnosis { get; set; }
        
        }
        public partial class VectorFieldTestGridModelList : List<VectorFieldTestGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public VectorFieldTestGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VectorFieldTest>, errMes);
            }
            public VectorFieldTestGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VectorFieldTest>, errMes);
            }
            public VectorFieldTestGridModelList(long key, IEnumerable<VectorFieldTest> items)
            {
                LoadGridModelList(key, items, null);
            }
            public VectorFieldTestGridModelList(long key)
            {
                LoadGridModelList(key, new List<VectorFieldTest>(), null);
            }
            partial void filter(List<VectorFieldTest> items);
            private void LoadGridModelList(long key, IEnumerable<VectorFieldTest> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strVectorID,_str_strVectorTypeName,_str_strVectorSubTypeName,_str_idfMaterial,_str_strSampleFieldBarcode,_str_strSampleName,_str_datFieldCollectionDate,_str_idfsPensideTestName,_str_strPensideTestName,_str_idfsPensideTestCategory,_str_strPensideTestCategory,_str_datTestDate,_str_idfTestedByOffice,_str_strTestedByOffice,_str_idfTestedByPerson,_str_strTestedByPerson,_str_idfsPensideTestResult,_str_strPensideTestResult,_str_idfsDiagnosis,_str_strDiagnosis};
                    
                Hiddens = new List<string> {_str_idfPensideTest};
                Keys = new List<string> {_str_idfPensideTest};
                Labels = new Dictionary<string, string> {{_str_strVectorID, "Vector.strVectorID"},{_str_strVectorTypeName, "idfsVectorType"},{_str_strVectorSubTypeName, "idfsVectorSubType"},{_str_idfMaterial, _str_idfMaterial},{_str_strSampleFieldBarcode, "VectorSample.strFieldBarcode"},{_str_strSampleName, "idfsSampleType"},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_idfsPensideTestName, "strPensideTypeName"},{_str_strPensideTestName, "strPensideTypeName"},{_str_idfsPensideTestCategory, "idfPensideTestTestCategory"},{_str_strPensideTestCategory, "idfPensideTestTestCategory"},{_str_datTestDate, "idfPensideTestTestDate"},{_str_idfTestedByOffice, "idfPensideTestTestedByOffice"},{_str_strTestedByOffice, "idfPensideTestTestedByOffice"},{_str_idfTestedByPerson, "idfPensideTestTestedByPerson"},{_str_strTestedByPerson, "idfPensideTestTestedByPerson"},{_str_idfsPensideTestResult, "FT.PensideTestResult"},{_str_strPensideTestResult, "FT.PensideTestResult"},{_str_idfsDiagnosis, "FT.strDisease"},{_str_strDiagnosis, "FT.strDisease"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                VectorFieldTest.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<VectorFieldTest>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VectorFieldTestGridModel()
                {
                    ItemKey=c.idfPensideTest,strVectorID=c.strVectorID,strVectorTypeName=c.strVectorTypeName,strVectorSubTypeName=c.strVectorSubTypeName,idfMaterial=c.idfMaterial,strSampleFieldBarcode=c.strSampleFieldBarcode,strSampleName=c.strSampleName,datFieldCollectionDate=c.datFieldCollectionDate,idfsPensideTestName=c.idfsPensideTestName,strPensideTestName=c.strPensideTestName,idfsPensideTestCategory=c.idfsPensideTestCategory,strPensideTestCategory=c.strPensideTestCategory,datTestDate=c.datTestDate,idfTestedByOffice=c.idfTestedByOffice,strTestedByOffice=c.strTestedByOffice,idfTestedByPerson=c.idfTestedByPerson,strTestedByPerson=c.strTestedByPerson,idfsPensideTestResult=c.idfsPensideTestResult,strPensideTestResult=c.strPensideTestResult,idfsDiagnosis=c.idfsDiagnosis,strDiagnosis=c.strDiagnosis
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
        : DataAccessor<VectorFieldTest>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<VectorFieldTest>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfPensideTest"; } }
            #endregion
        
            private delegate void on_action(VectorFieldTest obj);
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
            private PensideTestLookup.Accessor TestTypeAccessor { get { return eidss.model.Schema.PensideTestLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor TestCategoryAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private Diagnosis2PensideTestMatrixLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.Diagnosis2PensideTestMatrixLookup.Accessor.Instance(m_CS); } }
            private TypeFieldTestToResultMatrixLookup.Accessor TestResultAccessor { get { return eidss.model.Schema.TypeFieldTestToResultMatrixLookup.Accessor.Instance(m_CS); } }
            private Diagnosis2PensideTestMatrixLookup.Accessor DiagnosisFilteredAccessor { get { return eidss.model.Schema.Diagnosis2PensideTestMatrixLookup.Accessor.Instance(m_CS); } }
            private TypeFieldTestToResultMatrixLookup.Accessor TestResultFilteredAccessor { get { return eidss.model.Schema.TypeFieldTestToResultMatrixLookup.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor TestedByPersonAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor TestedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<VectorFieldTest> SelectList(DbManagerProxy manager
                , Int64? idfVector
                )
            {
                return _SelectList(manager
                    , idfVector
                    , delegate(VectorFieldTest obj)
                        {
                        }
                    , delegate(VectorFieldTest obj)
                        {
                        }
                    );
            }

            
            private List<VectorFieldTest> _SelectList(DbManagerProxy manager
                , Int64? idfVector
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VectorFieldTest> objs = new List<VectorFieldTest>();
                    sets[0] = new MapResultSet(typeof(VectorFieldTest), objs);
                    
                    manager
                        .SetSpCommand("spVectorFieldTest_SelectDetail"
                            , manager.Parameter("@idfVector", idfVector)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VectorFieldTest obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, VectorFieldTest obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private VectorFieldTest _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    VectorFieldTest obj = VectorFieldTest.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfPensideTest = (new GetNewIDExtender<VectorFieldTest>()).GetScalar(manager, obj, isFake);
                obj.idfVector = new Func<VectorFieldTest, long?>(c => c.ParentVector != null ? c.ParentVector.idfVector : obj.idfVector)(obj);
                obj.idfsVectorType = new Func<VectorFieldTest, long>(c => c.ParentVector != null ? c.ParentVector.idfsVectorType : obj.idfsVectorType)(obj);
                obj.strVectorID = new Func<VectorFieldTest, string>(c => c.ParentVector != null ? c.ParentVector.strVectorID : String.Empty)(obj);
                obj.strVectorTypeName = new Func<VectorFieldTest, string>(c => ((c.ParentVector != null) && (c.ParentVector.VectorType != null)) ? c.ParentVector.VectorType.strTranslatedName : String.Empty)(obj);
                obj.strSampleName = new Func<VectorFieldTest, string>(c => c.ParentSample != null ? c.ParentSample.strSampleName : String.Empty)(obj);
                obj.datFieldCollectionDate = new Func<VectorFieldTest, DateTime?>(c => c.ParentSample != null ? c.ParentSample.datCollectionDateTime : obj.datFieldCollectionDate)(obj);
                obj.idfVectorSurveillanceSession = new Func<VectorFieldTest, long?>(c => c.ParentVector == null ? c.idfVectorSurveillanceSession : c.ParentVector.idfVectorSurveillanceSession)(obj);
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

            
            public VectorFieldTest CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VectorFieldTest CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public VectorFieldTest CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public VectorFieldTest CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                return Create(manager, Parent
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public VectorFieldTest Create(DbManagerProxy manager, IObject Parent
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                }
                    , obj =>
                {
                }
                );
            }
            
            public ActResult ViewOnDetailForm(DbManagerProxy manager, VectorFieldTest obj, List<object> pars)
            {
                
                return ViewOnDetailForm(manager, obj
                    );
            }
            public ActResult ViewOnDetailForm(DbManagerProxy manager, VectorFieldTest obj
                )
            {
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(VectorFieldTest obj, object newobj)
            {
                
                    if (newobj == null || newobj == obj.ParentVector)
                    {
                        var o = obj.ParentVector;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "datCollectionDateTime")
                                {
                                
                obj.datFieldCollectionDate = new Func<VectorFieldTest, DateTime?>(c => c.ParentVector.datCollectionDateTime)(obj);
                                }
                            };
                        }    
                        
                    }
                            
            }
            
            private void _SetupHandlers(VectorFieldTest obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datTestDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datTestDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datFieldCollectionDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFieldCollectionDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfMaterial)
                        {
                    
                obj.strSampleName = new Func<VectorFieldTest, string>(c => c.Samples == null ? "" : c.Samples.Where(s => s.idfMaterial == c.idfMaterial).FirstOrDefault().strSampleName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterial)
                        {
                    
                obj.datFieldCollectionDate = new Func<VectorFieldTest, DateTime?>(c => c.Samples == null ? c.datFieldCollectionDate : c.Samples.Where(s => s.idfMaterial == c.idfMaterial).FirstOrDefault().datFieldCollectionDate)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsPensideTestName)
                        {
                    
                obj.TestType = new Func<VectorFieldTest, PensideTestLookup>(c => c.TestTypeLookup.Where(x => x.idfsPensideTestName == c.idfsPensideTestName).FirstOrDefault())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsPensideTestCategory)
                        {
                    
                obj.TestCategory = new Func<VectorFieldTest, BaseReference>(c => c.TestCategoryLookup.Where(x => x.idfsBaseReference == c.idfsPensideTestCategory).FirstOrDefault())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfTestedByOffice)
                        {
                    
                obj.TestedByOffice = new Func<VectorFieldTest, OrganizationLookup>(c => c.TestedByOfficeLookup.Where(x => x.idfInstitution == c.idfTestedByOffice).FirstOrDefault())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfTestedByPerson)
                        {
                    
                obj.TestedByPerson = new Func<VectorFieldTest, PersonLookup>(c => c.TestedByPersonLookup.Where(x => x.idfPerson == c.idfTestedByPerson).FirstOrDefault())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfTestedByOffice)
                        {
                    
                obj.TestedByPerson = (new SetScalarHandler()).Handler(obj,
                    obj.idfTestedByOffice, obj.idfTestedByOffice_Previous, obj.TestedByPerson,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsPensideTestName)
                        {
                    
                obj.Diagnosis = (new SetScalarHandler()).Handler(obj,
                    obj.idfsPensideTestName, obj.idfsPensideTestName_Previous, obj.Diagnosis,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsPensideTestName)
                        {
                    
                obj.TestResult = (new SetScalarHandler()).Handler(obj,
                    obj.idfsPensideTestName, obj.idfsPensideTestName_Previous, obj.TestResult,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsPensideTestName)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestType(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsPensideTestName)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Diagnosis(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsPensideTestName)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestResult(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfTestedByOffice)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestedByPerson(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsPensideTestName)
                        {
                    
                obj.DiagnosisFiltered = (new SetScalarHandler()).Handler(obj,
                    obj.idfsPensideTestName, obj.idfsPensideTestName_Previous, obj.DiagnosisFiltered,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsPensideTestName)
                        {
                    
                obj.TestResultFiltered = (new SetScalarHandler()).Handler(obj,
                    obj.idfsPensideTestName, obj.idfsPensideTestName_Previous, obj.TestResultFiltered,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsPensideTestName)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_DiagnosisFiltered(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsPensideTestName)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_TestResultFiltered(manager, obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_TestType(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.TestTypeLookup.Clear();
                
                obj.TestTypeLookup.Add(TestTypeAccessor.CreateNewT(manager, null));
                
                obj.TestTypeLookup.AddRange(TestTypeAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => obj.idfsVectorType == 0 ? true : c.idfsVectorType == obj.idfsVectorType)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsPensideTestName == obj.idfsPensideTestName))
                    
                    .ToList());
                
                if (obj.idfsPensideTestName != null && obj.idfsPensideTestName != 0)
                {
                    obj.TestType = obj.TestTypeLookup
                        .SingleOrDefault(c => c.idfsPensideTestName == obj.idfsPensideTestName);
                    
                }
              
                
                LookupManager.AddObject("PensideTestLookup", obj, TestTypeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_TestCategory(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.TestCategoryLookup.Clear();
                
                obj.TestCategoryLookup.Add(TestCategoryAccessor.CreateNewT(manager, null));
                
                obj.TestCategoryLookup.AddRange(TestCategoryAccessor.rftPensideTestCategory_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsPensideTestCategory))
                    
                    .ToList());
                
                if (obj.idfsPensideTestCategory != null && obj.idfsPensideTestCategory != 0)
                {
                    obj.TestCategory = obj.TestCategoryLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsPensideTestCategory);
                    
                }
              
                
                LookupManager.AddObject("rftPensideTestCategory", obj, TestCategoryAccessor.GetType(), "rftPensideTestCategory_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Diagnosis(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsPensideTestName == (obj.idfsPensideTestName.HasValue && obj.idfsPensideTestName.Value != 0 ? obj.idfsPensideTestName.Value : c.idfsPensideTestName))
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != null && obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                
                LookupManager.AddObject("Diagnosis2PensideTestMatrixLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_TestResult(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.TestResultLookup.Clear();
                
                obj.TestResultLookup.Add(TestResultAccessor.CreateNewT(manager, null));
                
                obj.TestResultLookup.AddRange(TestResultAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsPensideTestName == (obj.idfsPensideTestName.HasValue && obj.idfsPensideTestName.Value != 0 ? obj.idfsPensideTestName.Value : c.idfsPensideTestName))
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsPensideTestResult == obj.idfsPensideTestResult))
                    
                    .ToList());
                
                if (obj.idfsPensideTestResult != null && obj.idfsPensideTestResult != 0)
                {
                    obj.TestResult = obj.TestResultLookup
                        .SingleOrDefault(c => c.idfsPensideTestResult == obj.idfsPensideTestResult);
                    
                }
              
                
                LookupManager.AddObject("TypeFieldTestToResultMatrixLookup", obj, TestResultAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_DiagnosisFiltered(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.DiagnosisFilteredLookup.Clear();
                
                obj.DiagnosisFilteredLookup.Add(DiagnosisFilteredAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisFilteredLookup.AddRange(DiagnosisFilteredAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsPensideTestName == (obj.idfsPensideTestName.HasValue && obj.idfsPensideTestName.Value != 0 ? obj.idfsPensideTestName.Value : -1))
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != null && obj.idfsDiagnosis != 0)
                {
                    obj.DiagnosisFiltered = obj.DiagnosisFilteredLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                
                LookupManager.AddObject("Diagnosis2PensideTestMatrixLookup", obj, DiagnosisFilteredAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_TestResultFiltered(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.TestResultFilteredLookup.Clear();
                
                obj.TestResultFilteredLookup.Add(TestResultFilteredAccessor.CreateNewT(manager, null));
                
                obj.TestResultFilteredLookup.AddRange(TestResultFilteredAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsPensideTestName == (obj.idfsPensideTestName.HasValue && obj.idfsPensideTestName.Value != 0 ? obj.idfsPensideTestName.Value : -1))
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsPensideTestResult == obj.idfsPensideTestResult))
                    
                    .ToList());
                
                if (obj.idfsPensideTestResult != null && obj.idfsPensideTestResult != 0)
                {
                    obj.TestResultFiltered = obj.TestResultFilteredLookup
                        .SingleOrDefault(c => c.idfsPensideTestResult == obj.idfsPensideTestResult);
                    
                }
              
                
                LookupManager.AddObject("TypeFieldTestToResultMatrixLookup", obj, TestResultFilteredAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_TestedByPerson(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.TestedByPersonLookup.Clear();
                
                obj.TestedByPersonLookup.Add(TestedByPersonAccessor.CreateNewT(manager, null));
                
                obj.TestedByPersonLookup.AddRange(TestedByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<VectorFieldTest, long?>(c => c.idfTestedByOffice)(obj)
                            
                    , null
                    , false
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfTestedByPerson))
                    
                    .ToList());
                
                if (obj.idfTestedByPerson != null && obj.idfTestedByPerson != 0)
                {
                    obj.TestedByPerson = obj.TestedByPersonLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfTestedByPerson);
                    
                }
              
                
                LookupManager.AddObject("PersonLookup", obj, TestedByPersonAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_TestedByOffice(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.TestedByOfficeLookup.Clear();
                
                obj.TestedByOfficeLookup.Add(TestedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.TestedByOfficeLookup.AddRange(TestedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (((c.intHACode??0) & (int)HACode.Vector) != 0) || c.idfInstitution == obj.idfTestedByOffice)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfTestedByOffice))
                    
                    .ToList());
                
                if (obj.idfTestedByOffice != null && obj.idfTestedByOffice != 0)
                {
                    obj.TestedByOffice = obj.TestedByOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfTestedByOffice);
                    
                }
              
                
                LookupManager.AddObject("OrganizationLookup", obj, TestedByOfficeAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                LoadLookup_TestType(manager, obj);
                
                LoadLookup_TestCategory(manager, obj);
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_TestResult(manager, obj);
                
                LoadLookup_DiagnosisFiltered(manager, obj);
                
                LoadLookup_TestResultFiltered(manager, obj);
                
                LoadLookup_TestedByPerson(manager, obj);
                
                LoadLookup_TestedByOffice(manager, obj);
                
            }
    
            [SprocName("spVectorFieldTest_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? idfVectorFieldTest, out Boolean Result
                );
        
            [SprocName("spVectorFieldTest_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            [SprocName("spVectorFieldTest_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfPensideTest", "datTestDate")] VectorFieldTest obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfPensideTest", "datTestDate")] VectorFieldTest obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    VectorFieldTest bo = obj as VectorFieldTest;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as VectorFieldTest, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VectorFieldTest obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(VectorFieldTest obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VectorFieldTest obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfPensideTest
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, false, obj);
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
        
      
            protected ValidationModelException ChainsValidate(VectorFieldTest obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<VectorFieldTest>(obj, "datTestDate", c => true, 
      obj.datTestDate,
      obj.GetType(),
      false, listdatTestDate => {
    listdatTestDate.Add(
    new ChainsValidatorDateTime<VectorFieldTest>(obj, "datFieldCollectionDate", c => true, 
      obj.datFieldCollectionDate,
      obj.GetType(),
      false, listdatFieldCollectionDate => {
    listdatFieldCollectionDate.Add(
    new ChainsValidatorDateTime<VectorFieldTest>(obj, "CurrentDate", c => true, 
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
            protected bool ChainsValidate(VectorFieldTest obj, bool bRethrowException)
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
                return Validate(manager, obj as VectorFieldTest, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VectorFieldTest obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfMaterial", "idfMaterial","",
                false
              )).Validate(c => true, obj, obj.idfMaterial);
            
                (new RequiredValidator( "idfsPensideTestName", "idfsPensideTestName","",
                false
              )).Validate(c => true, obj, obj.idfsPensideTestName);
            
                (new PredicateValidator("errNoDiagnosisForTestResult", "idfsDiagnosis", "idfsDiagnosis", "idfsDiagnosis",
              new object[] {
              },
                        false
                    )).Validate(obj, c => c.idfsPensideTestResult != null ? c.idfsDiagnosis != null : true
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
           
    
            private void _SetupRequired(VectorFieldTest obj)
            {
            
                obj
                    .AddRequired("idfMaterial", c => true);
                    
                obj
                    .AddRequired("idfsPensideTestName", c => true);
                    
                  obj
                    .AddRequired("TestType", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(VectorFieldTest obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VectorFieldTest) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VectorFieldTest) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VectorFieldTestDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spVectorFieldTest_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spVectorFieldTest_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spVectorFieldTest_Delete";
            public static string spCanDelete = "spVectorFieldTest_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VectorFieldTest, bool>> RequiredByField = new Dictionary<string, Func<VectorFieldTest, bool>>();
            public static Dictionary<string, Func<VectorFieldTest, bool>> RequiredByProperty = new Dictionary<string, Func<VectorFieldTest, bool>>();
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
                
                Sizes.Add(_str_strPensideTestTypeName, 2000);
                Sizes.Add(_str_strVectorTypeName, 2000);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strSampleName, 2000);
                Sizes.Add(_str_strPensideTestCategoryName, 2000);
                Sizes.Add(_str_strCollectedByPerson, 602);
                Sizes.Add(_str_strCollectedByOffice, 2000);
                Sizes.Add(_str_strPensideTestResultName, 2000);
                Sizes.Add(_str_strDiagnosisName, 2000);
                Sizes.Add(_str_strVectorID, 50);
                if (!RequiredByField.ContainsKey("idfMaterial")) RequiredByField.Add("idfMaterial", c => true);
                if (!RequiredByProperty.ContainsKey("idfMaterial")) RequiredByProperty.Add("idfMaterial", c => true);
                
                if (!RequiredByField.ContainsKey("idfsPensideTestName")) RequiredByField.Add("idfsPensideTestName", c => true);
                if (!RequiredByProperty.ContainsKey("idfsPensideTestName")) RequiredByProperty.Add("idfsPensideTestName", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfPensideTest,
                    _str_idfPensideTest, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorID,
                    "Vector.strVectorID", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorTypeName,
                    "idfsVectorType", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorSubTypeName,
                    "idfsVectorSubType", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfMaterial,
                    _str_idfMaterial, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSampleFieldBarcode,
                    "VectorSample.strFieldBarcode", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSampleName,
                    "idfsSampleType", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsPensideTestName,
                    "strPensideTypeName", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPensideTestName,
                    "strPensideTypeName", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsPensideTestCategory,
                    "idfPensideTestTestCategory", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPensideTestCategory,
                    "idfPensideTestTestCategory", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datTestDate,
                    "idfPensideTestTestDate", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfTestedByOffice,
                    "idfPensideTestTestedByOffice", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestedByOffice,
                    "idfPensideTestTestedByOffice", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfTestedByPerson,
                    "idfPensideTestTestedByPerson", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTestedByPerson,
                    "idfPensideTestTestedByPerson", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsPensideTestResult,
                    "FT.PensideTestResult", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPensideTestResult,
                    "FT.PensideTestResult", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsDiagnosis,
                    "FT.strDisease", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosis,
                    "FT.strDisease", null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).Create(manager, c, pars)),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      false,
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
                    "Edit",
                    ActionTypes.Edit,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      false,
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
                    "ViewOnDetailForm",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ViewOnDetailForm(manager, (VectorFieldTest)c, pars),
                        
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
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => ((VectorFieldTest)c).MarkToDelete(),
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
	