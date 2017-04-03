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
                
        [LocalizedDisplayName(_str_idfsPensideTestType)]
        [MapField(_str_idfsPensideTestType)]
        public abstract Int64? idfsPensideTestType { get; set; }
        #if MONO
        protected Int64? idfsPensideTestType_Original { get { return idfsPensideTestType; } }
        protected Int64? idfsPensideTestType_Previous { get { return idfsPensideTestType; } }
        #else
        protected Int64? idfsPensideTestType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPensideTestType).OriginalValue; } }
        protected Int64? idfsPensideTestType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPensideTestType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("TestName")]
        [MapField(_str_strPensideTestTypeName)]
        public abstract String strPensideTestTypeName { get; set; }
        #if MONO
        protected String strPensideTestTypeName_Original { get { return strPensideTestTypeName; } }
        protected String strPensideTestTypeName_Previous { get { return strPensideTestTypeName; } }
        #else
        protected String strPensideTestTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestTypeName).OriginalValue; } }
        protected String strPensideTestTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestTypeName).PreviousValue; } }
        #endif
                
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
                
        [LocalizedDisplayName("idfsVectorType")]
        [MapField(_str_strVectorTypeName)]
        public abstract String strVectorTypeName { get; set; }
        #if MONO
        protected String strVectorTypeName_Original { get { return strVectorTypeName; } }
        protected String strVectorTypeName_Previous { get { return strVectorTypeName; } }
        #else
        protected String strVectorTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorTypeName).OriginalValue; } }
        protected String strVectorTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorTypeName).PreviousValue; } }
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
        [MapField(_str_strSpecimenName)]
        public abstract String strSpecimenName { get; set; }
        #if MONO
        protected String strSpecimenName_Original { get { return strSpecimenName; } }
        protected String strSpecimenName_Previous { get { return strSpecimenName; } }
        #else
        protected String strSpecimenName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSpecimenName).OriginalValue; } }
        protected String strSpecimenName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSpecimenName).PreviousValue; } }
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
                
        [LocalizedDisplayName("idfPensideTestTestDate")]
        [MapField(_str_datTestDate)]
        public abstract DateTime? datTestDate { get; set; }
        #if MONO
        protected DateTime? datTestDate_Original { get { return datTestDate; } }
        protected DateTime? datTestDate_Previous { get { return datTestDate; } }
        #else
        protected DateTime? datTestDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTestDate).OriginalValue; } }
        protected DateTime? datTestDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTestDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfPensideTestTestCategory")]
        [MapField(_str_idfsPensideTestCategory)]
        public abstract Int64? idfsPensideTestCategory { get; set; }
        #if MONO
        protected Int64? idfsPensideTestCategory_Original { get { return idfsPensideTestCategory; } }
        protected Int64? idfsPensideTestCategory_Previous { get { return idfsPensideTestCategory; } }
        #else
        protected Int64? idfsPensideTestCategory_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPensideTestCategory).OriginalValue; } }
        protected Int64? idfsPensideTestCategory_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPensideTestCategory).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strPensideTestCategoryName)]
        [MapField(_str_strPensideTestCategoryName)]
        public abstract String strPensideTestCategoryName { get; set; }
        #if MONO
        protected String strPensideTestCategoryName_Original { get { return strPensideTestCategoryName; } }
        protected String strPensideTestCategoryName_Previous { get { return strPensideTestCategoryName; } }
        #else
        protected String strPensideTestCategoryName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestCategoryName).OriginalValue; } }
        protected String strPensideTestCategoryName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestCategoryName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfPensideTestTestedByPerson")]
        [MapField(_str_idfTestedByPerson)]
        public abstract Int64? idfTestedByPerson { get; set; }
        #if MONO
        protected Int64? idfTestedByPerson_Original { get { return idfTestedByPerson; } }
        protected Int64? idfTestedByPerson_Previous { get { return idfTestedByPerson; } }
        #else
        protected Int64? idfTestedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByPerson).OriginalValue; } }
        protected Int64? idfTestedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCollectedByPerson)]
        [MapField(_str_strCollectedByPerson)]
        public abstract String strCollectedByPerson { get; set; }
        #if MONO
        protected String strCollectedByPerson_Original { get { return strCollectedByPerson; } }
        protected String strCollectedByPerson_Previous { get { return strCollectedByPerson; } }
        #else
        protected String strCollectedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByPerson).OriginalValue; } }
        protected String strCollectedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfPensideTestTestedByOffice")]
        [MapField(_str_idfTestedByOffice)]
        public abstract Int64? idfTestedByOffice { get; set; }
        #if MONO
        protected Int64? idfTestedByOffice_Original { get { return idfTestedByOffice; } }
        protected Int64? idfTestedByOffice_Previous { get { return idfTestedByOffice; } }
        #else
        protected Int64? idfTestedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByOffice).OriginalValue; } }
        protected Int64? idfTestedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfTestedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCollectedByOffice)]
        [MapField(_str_strCollectedByOffice)]
        public abstract String strCollectedByOffice { get; set; }
        #if MONO
        protected String strCollectedByOffice_Original { get { return strCollectedByOffice; } }
        protected String strCollectedByOffice_Previous { get { return strCollectedByOffice; } }
        #else
        protected String strCollectedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByOffice).OriginalValue; } }
        protected String strCollectedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsPensideTestResult)]
        [MapField(_str_idfsPensideTestResult)]
        public abstract Int64? idfsPensideTestResult { get; set; }
        #if MONO
        protected Int64? idfsPensideTestResult_Original { get { return idfsPensideTestResult; } }
        protected Int64? idfsPensideTestResult_Previous { get { return idfsPensideTestResult; } }
        #else
        protected Int64? idfsPensideTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPensideTestResult).OriginalValue; } }
        protected Int64? idfsPensideTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPensideTestResult).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strPensideTestResultName)]
        [MapField(_str_strPensideTestResultName)]
        public abstract String strPensideTestResultName { get; set; }
        #if MONO
        protected String strPensideTestResultName_Original { get { return strPensideTestResultName; } }
        protected String strPensideTestResultName_Previous { get { return strPensideTestResultName; } }
        #else
        protected String strPensideTestResultName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestResultName).OriginalValue; } }
        protected String strPensideTestResultName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestResultName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("FT.strDisease")]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64? idfsDiagnosis { get; set; }
        #if MONO
        protected Int64? idfsDiagnosis_Original { get { return idfsDiagnosis; } }
        protected Int64? idfsDiagnosis_Previous { get { return idfsDiagnosis; } }
        #else
        protected Int64? idfsDiagnosis_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64? idfsDiagnosis_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strDiagnosisName)]
        [MapField(_str_strDiagnosisName)]
        public abstract String strDiagnosisName { get; set; }
        #if MONO
        protected String strDiagnosisName_Original { get { return strDiagnosisName; } }
        protected String strDiagnosisName_Previous { get { return strDiagnosisName; } }
        #else
        protected String strDiagnosisName_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisName).OriginalValue; } }
        protected String strDiagnosisName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32? intOrder { get; set; }
        #if MONO
        protected Int32? intOrder_Original { get { return intOrder; } }
        protected Int32? intOrder_Previous { get { return intOrder; } }
        #else
        protected Int32? intOrder_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32? intOrder_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intOrder).PreviousValue; } }
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
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<VectorFieldTest, object> _get_func;
            internal Action<VectorFieldTest, string> _set_func;
            internal Action<VectorFieldTest, VectorFieldTest, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfPensideTest = "idfPensideTest";
        internal const string _str_idfsPensideTestType = "idfsPensideTestType";
        internal const string _str_strPensideTestTypeName = "strPensideTestTypeName";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfVector = "idfVector";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_strVectorTypeName = "strVectorTypeName";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_idfsSpecimenType = "idfsSpecimenType";
        internal const string _str_strSpecimenName = "strSpecimenName";
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
        internal const string _str_tempint = "tempint";
        internal const string _str_strVectorSubTypeName = "strVectorSubTypeName";
        internal const string _str_PensideTestType = "PensideTestType";
        internal const string _str_PensideTestCategory = "PensideTestCategory";
        internal const string _str_TestedByPerson = "TestedByPerson";
        internal const string _str_TestedByOffice = "TestedByOffice";
        internal const string _str_TypeFieldTestToResultMatrix = "TypeFieldTestToResultMatrix";
        internal const string _str_Diagnosis2PensideTestMatrix = "Diagnosis2PensideTestMatrix";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfPensideTest, _type = "Int64",
              _get_func = o => o.idfPensideTest,
              _set_func = (o, val) => { o.idfPensideTest = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfPensideTest != c.idfPensideTest || o.IsRIRPropChanged(_str_idfPensideTest, c)) 
                  m.Add(_str_idfPensideTest, o.ObjectIdent + _str_idfPensideTest, "Int64", o.idfPensideTest == null ? "" : o.idfPensideTest.ToString(), o.IsReadOnly(_str_idfPensideTest), o.IsInvisible(_str_idfPensideTest), o.IsRequired(_str_idfPensideTest)); }
              }, 
        
            new field_info {
              _name = _str_idfsPensideTestType, _type = "Int64?",
              _get_func = o => o.idfsPensideTestType,
              _set_func = (o, val) => { o.idfsPensideTestType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsPensideTestType != c.idfsPensideTestType || o.IsRIRPropChanged(_str_idfsPensideTestType, c)) 
                  m.Add(_str_idfsPensideTestType, o.ObjectIdent + _str_idfsPensideTestType, "Int64?", o.idfsPensideTestType == null ? "" : o.idfsPensideTestType.ToString(), o.IsReadOnly(_str_idfsPensideTestType), o.IsInvisible(_str_idfsPensideTestType), o.IsRequired(_str_idfsPensideTestType)); }
              }, 
        
            new field_info {
              _name = _str_strPensideTestTypeName, _type = "String",
              _get_func = o => o.strPensideTestTypeName,
              _set_func = (o, val) => { o.strPensideTestTypeName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strPensideTestTypeName != c.strPensideTestTypeName || o.IsRIRPropChanged(_str_strPensideTestTypeName, c)) 
                  m.Add(_str_strPensideTestTypeName, o.ObjectIdent + _str_strPensideTestTypeName, "String", o.strPensideTestTypeName == null ? "" : o.strPensideTestTypeName.ToString(), o.IsReadOnly(_str_strPensideTestTypeName), o.IsInvisible(_str_strPensideTestTypeName), o.IsRequired(_str_strPensideTestTypeName)); }
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
              _name = _str_idfVector, _type = "Int64?",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { o.idfVector = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, "Int64?", o.idfVector == null ? "" : o.idfVector.ToString(), o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); }
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
              _name = _str_strVectorTypeName, _type = "String",
              _get_func = o => o.strVectorTypeName,
              _set_func = (o, val) => { o.strVectorTypeName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorTypeName != c.strVectorTypeName || o.IsRIRPropChanged(_str_strVectorTypeName, c)) 
                  m.Add(_str_strVectorTypeName, o.ObjectIdent + _str_strVectorTypeName, "String", o.strVectorTypeName == null ? "" : o.strVectorTypeName.ToString(), o.IsReadOnly(_str_strVectorTypeName), o.IsInvisible(_str_strVectorTypeName), o.IsRequired(_str_strVectorTypeName)); }
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
              _name = _str_strSpecimenName, _type = "String",
              _get_func = o => o.strSpecimenName,
              _set_func = (o, val) => { o.strSpecimenName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSpecimenName != c.strSpecimenName || o.IsRIRPropChanged(_str_strSpecimenName, c)) 
                  m.Add(_str_strSpecimenName, o.ObjectIdent + _str_strSpecimenName, "String", o.strSpecimenName == null ? "" : o.strSpecimenName.ToString(), o.IsReadOnly(_str_strSpecimenName), o.IsInvisible(_str_strSpecimenName), o.IsRequired(_str_strSpecimenName)); }
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
              _name = _str_datTestDate, _type = "DateTime?",
              _get_func = o => o.datTestDate,
              _set_func = (o, val) => { o.datTestDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datTestDate != c.datTestDate || o.IsRIRPropChanged(_str_datTestDate, c)) 
                  m.Add(_str_datTestDate, o.ObjectIdent + _str_datTestDate, "DateTime?", o.datTestDate == null ? "" : o.datTestDate.ToString(), o.IsReadOnly(_str_datTestDate), o.IsInvisible(_str_datTestDate), o.IsRequired(_str_datTestDate)); }
              }, 
        
            new field_info {
              _name = _str_idfsPensideTestCategory, _type = "Int64?",
              _get_func = o => o.idfsPensideTestCategory,
              _set_func = (o, val) => { o.idfsPensideTestCategory = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsPensideTestCategory != c.idfsPensideTestCategory || o.IsRIRPropChanged(_str_idfsPensideTestCategory, c)) 
                  m.Add(_str_idfsPensideTestCategory, o.ObjectIdent + _str_idfsPensideTestCategory, "Int64?", o.idfsPensideTestCategory == null ? "" : o.idfsPensideTestCategory.ToString(), o.IsReadOnly(_str_idfsPensideTestCategory), o.IsInvisible(_str_idfsPensideTestCategory), o.IsRequired(_str_idfsPensideTestCategory)); }
              }, 
        
            new field_info {
              _name = _str_strPensideTestCategoryName, _type = "String",
              _get_func = o => o.strPensideTestCategoryName,
              _set_func = (o, val) => { o.strPensideTestCategoryName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strPensideTestCategoryName != c.strPensideTestCategoryName || o.IsRIRPropChanged(_str_strPensideTestCategoryName, c)) 
                  m.Add(_str_strPensideTestCategoryName, o.ObjectIdent + _str_strPensideTestCategoryName, "String", o.strPensideTestCategoryName == null ? "" : o.strPensideTestCategoryName.ToString(), o.IsReadOnly(_str_strPensideTestCategoryName), o.IsInvisible(_str_strPensideTestCategoryName), o.IsRequired(_str_strPensideTestCategoryName)); }
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
              _name = _str_strCollectedByPerson, _type = "String",
              _get_func = o => o.strCollectedByPerson,
              _set_func = (o, val) => { o.strCollectedByPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCollectedByPerson != c.strCollectedByPerson || o.IsRIRPropChanged(_str_strCollectedByPerson, c)) 
                  m.Add(_str_strCollectedByPerson, o.ObjectIdent + _str_strCollectedByPerson, "String", o.strCollectedByPerson == null ? "" : o.strCollectedByPerson.ToString(), o.IsReadOnly(_str_strCollectedByPerson), o.IsInvisible(_str_strCollectedByPerson), o.IsRequired(_str_strCollectedByPerson)); }
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
              _name = _str_strCollectedByOffice, _type = "String",
              _get_func = o => o.strCollectedByOffice,
              _set_func = (o, val) => { o.strCollectedByOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCollectedByOffice != c.strCollectedByOffice || o.IsRIRPropChanged(_str_strCollectedByOffice, c)) 
                  m.Add(_str_strCollectedByOffice, o.ObjectIdent + _str_strCollectedByOffice, "String", o.strCollectedByOffice == null ? "" : o.strCollectedByOffice.ToString(), o.IsReadOnly(_str_strCollectedByOffice), o.IsInvisible(_str_strCollectedByOffice), o.IsRequired(_str_strCollectedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfsPensideTestResult, _type = "Int64?",
              _get_func = o => o.idfsPensideTestResult,
              _set_func = (o, val) => { o.idfsPensideTestResult = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsPensideTestResult != c.idfsPensideTestResult || o.IsRIRPropChanged(_str_idfsPensideTestResult, c)) 
                  m.Add(_str_idfsPensideTestResult, o.ObjectIdent + _str_idfsPensideTestResult, "Int64?", o.idfsPensideTestResult == null ? "" : o.idfsPensideTestResult.ToString(), o.IsReadOnly(_str_idfsPensideTestResult), o.IsInvisible(_str_idfsPensideTestResult), o.IsRequired(_str_idfsPensideTestResult)); }
              }, 
        
            new field_info {
              _name = _str_strPensideTestResultName, _type = "String",
              _get_func = o => o.strPensideTestResultName,
              _set_func = (o, val) => { o.strPensideTestResultName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strPensideTestResultName != c.strPensideTestResultName || o.IsRIRPropChanged(_str_strPensideTestResultName, c)) 
                  m.Add(_str_strPensideTestResultName, o.ObjectIdent + _str_strPensideTestResultName, "String", o.strPensideTestResultName == null ? "" : o.strPensideTestResultName.ToString(), o.IsReadOnly(_str_strPensideTestResultName), o.IsInvisible(_str_strPensideTestResultName), o.IsRequired(_str_strPensideTestResultName)); }
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
              _name = _str_strDiagnosisName, _type = "String",
              _get_func = o => o.strDiagnosisName,
              _set_func = (o, val) => { o.strDiagnosisName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strDiagnosisName != c.strDiagnosisName || o.IsRIRPropChanged(_str_strDiagnosisName, c)) 
                  m.Add(_str_strDiagnosisName, o.ObjectIdent + _str_strDiagnosisName, "String", o.strDiagnosisName == null ? "" : o.strDiagnosisName.ToString(), o.IsReadOnly(_str_strDiagnosisName), o.IsInvisible(_str_strDiagnosisName), o.IsRequired(_str_strDiagnosisName)); }
              }, 
        
            new field_info {
              _name = _str_intOrder, _type = "Int32?",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { o.intOrder = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, "Int32?", o.intOrder == null ? "" : o.intOrder.ToString(), o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); }
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
              _name = _str_tempint, _type = "long",
              _get_func = o => o.tempint,
              _set_func = (o, val) => { o.tempint = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
              
                if (o.tempint != c.tempint || o.IsRIRPropChanged(_str_tempint, c)) 
                  m.Add(_str_tempint, o.ObjectIdent + _str_tempint, "long", o.tempint == null ? "" : o.tempint.ToString(), o.IsReadOnly(_str_tempint), o.IsInvisible(_str_tempint), o.IsRequired(_str_tempint));
                 }
              }, 
        
            new field_info {
              _name = _str_strVectorSubTypeName, _type = "string",
              _get_func = o => o.strVectorSubTypeName,
              _set_func = (o, val) => { o.strVectorSubTypeName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
              
                if (o.strVectorSubTypeName != c.strVectorSubTypeName || o.IsRIRPropChanged(_str_strVectorSubTypeName, c)) 
                  m.Add(_str_strVectorSubTypeName, o.ObjectIdent + _str_strVectorSubTypeName, "string", o.strVectorSubTypeName == null ? "" : o.strVectorSubTypeName.ToString(), o.IsReadOnly(_str_strVectorSubTypeName), o.IsInvisible(_str_strVectorSubTypeName), o.IsRequired(_str_strVectorSubTypeName));
                 }
              }, 
        
            new field_info {
              _name = _str_PensideTestType, _type = "Lookup",
              _get_func = o => { if (o.PensideTestType == null) return null; return o.PensideTestType.idfsBaseReference; },
              _set_func = (o, val) => { o.PensideTestType = o.PensideTestTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsPensideTestType != c.idfsPensideTestType || o.IsRIRPropChanged(_str_PensideTestType, c)) 
                  m.Add(_str_PensideTestType, o.ObjectIdent + _str_PensideTestType, "Lookup", o.idfsPensideTestType == null ? "" : o.idfsPensideTestType.ToString(), o.IsReadOnly(_str_PensideTestType), o.IsInvisible(_str_PensideTestType), o.IsRequired(_str_PensideTestType)); }
              }, 
        
            new field_info {
              _name = _str_PensideTestCategory, _type = "Lookup",
              _get_func = o => { if (o.PensideTestCategory == null) return null; return o.PensideTestCategory.idfsBaseReference; },
              _set_func = (o, val) => { o.PensideTestCategory = o.PensideTestCategoryLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsPensideTestCategory != c.idfsPensideTestCategory || o.IsRIRPropChanged(_str_PensideTestCategory, c)) 
                  m.Add(_str_PensideTestCategory, o.ObjectIdent + _str_PensideTestCategory, "Lookup", o.idfsPensideTestCategory == null ? "" : o.idfsPensideTestCategory.ToString(), o.IsReadOnly(_str_PensideTestCategory), o.IsInvisible(_str_PensideTestCategory), o.IsRequired(_str_PensideTestCategory)); }
              }, 
        
            new field_info {
              _name = _str_TestedByPerson, _type = "Lookup",
              _get_func = o => { if (o.TestedByPerson == null) return null; return o.TestedByPerson.idfPerson; },
              _set_func = (o, val) => { o.TestedByPerson = o.TestedByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByPerson != c.idfTestedByPerson || o.IsRIRPropChanged(_str_TestedByPerson, c)) 
                  m.Add(_str_TestedByPerson, o.ObjectIdent + _str_TestedByPerson, "Lookup", o.idfTestedByPerson == null ? "" : o.idfTestedByPerson.ToString(), o.IsReadOnly(_str_TestedByPerson), o.IsInvisible(_str_TestedByPerson), o.IsRequired(_str_TestedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_TestedByOffice, _type = "Lookup",
              _get_func = o => { if (o.TestedByOffice == null) return null; return o.TestedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.TestedByOffice = o.TestedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfTestedByOffice != c.idfTestedByOffice || o.IsRIRPropChanged(_str_TestedByOffice, c)) 
                  m.Add(_str_TestedByOffice, o.ObjectIdent + _str_TestedByOffice, "Lookup", o.idfTestedByOffice == null ? "" : o.idfTestedByOffice.ToString(), o.IsReadOnly(_str_TestedByOffice), o.IsInvisible(_str_TestedByOffice), o.IsRequired(_str_TestedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_TypeFieldTestToResultMatrix, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.TypeFieldTestToResultMatrix.Count != c.TypeFieldTestToResultMatrix.Count || o.IsReadOnly(_str_TypeFieldTestToResultMatrix) != c.IsReadOnly(_str_TypeFieldTestToResultMatrix) || o.IsInvisible(_str_TypeFieldTestToResultMatrix) != c.IsInvisible(_str_TypeFieldTestToResultMatrix) || o.IsRequired(_str_TypeFieldTestToResultMatrix) != c.IsRequired(_str_TypeFieldTestToResultMatrix)) 
                  m.Add(_str_TypeFieldTestToResultMatrix, o.ObjectIdent + _str_TypeFieldTestToResultMatrix, "Child", o.idfsPensideTestResult == null ? "" : o.idfsPensideTestResult.ToString(), o.IsReadOnly(_str_TypeFieldTestToResultMatrix), o.IsInvisible(_str_TypeFieldTestToResultMatrix), o.IsRequired(_str_TypeFieldTestToResultMatrix)); }
              }, 
        
            new field_info {
              _name = _str_Diagnosis2PensideTestMatrix, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Diagnosis2PensideTestMatrix.Count != c.Diagnosis2PensideTestMatrix.Count || o.IsReadOnly(_str_Diagnosis2PensideTestMatrix) != c.IsReadOnly(_str_Diagnosis2PensideTestMatrix) || o.IsInvisible(_str_Diagnosis2PensideTestMatrix) != c.IsInvisible(_str_Diagnosis2PensideTestMatrix) || o.IsRequired(_str_Diagnosis2PensideTestMatrix) != c.IsRequired(_str_Diagnosis2PensideTestMatrix)) 
                  m.Add(_str_Diagnosis2PensideTestMatrix, o.ObjectIdent + _str_Diagnosis2PensideTestMatrix, "Child", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis2PensideTestMatrix), o.IsInvisible(_str_Diagnosis2PensideTestMatrix), o.IsRequired(_str_Diagnosis2PensideTestMatrix)); }
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
    
        [Relation(typeof(TypeFieldTestToResultMatrixLookup), "", _str_idfsPensideTestResult)]
        public EditableList<TypeFieldTestToResultMatrixLookup> TypeFieldTestToResultMatrix
        {
            get 
            {   
                return _TypeFieldTestToResultMatrix; 
            }
            set 
            {
                _TypeFieldTestToResultMatrix = value;
            }
        }
        protected EditableList<TypeFieldTestToResultMatrixLookup> _TypeFieldTestToResultMatrix = new EditableList<TypeFieldTestToResultMatrixLookup>();
                    
        [Relation(typeof(Diagnosis2PensideTestMatrixLookup), "", _str_idfsDiagnosis)]
        public EditableList<Diagnosis2PensideTestMatrixLookup> Diagnosis2PensideTestMatrix
        {
            get 
            {   
                return _Diagnosis2PensideTestMatrix; 
            }
            set 
            {
                _Diagnosis2PensideTestMatrix = value;
            }
        }
        protected EditableList<Diagnosis2PensideTestMatrixLookup> _Diagnosis2PensideTestMatrix = new EditableList<Diagnosis2PensideTestMatrixLookup>();
                    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsPensideTestType)]
        public BaseReference PensideTestType
        {
            get { return _PensideTestType == null ? null : ((long)_PensideTestType.Key == 0 ? null : _PensideTestType); }
            set 
            { 
                _PensideTestType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsPensideTestType = _PensideTestType == null 
                    ? new Int64?()
                    : _PensideTestType.idfsBaseReference; 
                OnPropertyChanged(_str_PensideTestType); 
            }
        }
        private BaseReference _PensideTestType;

        
        public BaseReferenceList PensideTestTypeLookup
        {
            get { return _PensideTestTypeLookup; }
        }
        private BaseReferenceList _PensideTestTypeLookup = new BaseReferenceList("rftPensideTestType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsPensideTestCategory)]
        public BaseReference PensideTestCategory
        {
            get { return _PensideTestCategory == null ? null : ((long)_PensideTestCategory.Key == 0 ? null : _PensideTestCategory); }
            set 
            { 
                _PensideTestCategory = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsPensideTestCategory = _PensideTestCategory == null 
                    ? new Int64?()
                    : _PensideTestCategory.idfsBaseReference; 
                OnPropertyChanged(_str_PensideTestCategory); 
            }
        }
        private BaseReference _PensideTestCategory;

        
        public BaseReferenceList PensideTestCategoryLookup
        {
            get { return _PensideTestCategoryLookup; }
        }
        private BaseReferenceList _PensideTestCategoryLookup = new BaseReferenceList("rftPensideTestCategory");
            
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfTestedByPerson)]
        public PersonLookup TestedByPerson
        {
            get { return _TestedByPerson == null ? null : ((long)_TestedByPerson.Key == 0 ? null : _TestedByPerson); }
            set 
            { 
                _TestedByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfTestedByPerson = _TestedByPerson == null 
                    ? new Int64?()
                    : _TestedByPerson.idfPerson; 
                OnPropertyChanged(_str_TestedByPerson); 
            }
        }
        private PersonLookup _TestedByPerson;

        
        public List<PersonLookup> TestedByPersonLookup
        {
            get { return _TestedByPersonLookup; }
        }
        private List<PersonLookup> _TestedByPersonLookup = new List<PersonLookup>();
            
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfTestedByOffice)]
        public OrganizationLookup TestedByOffice
        {
            get { return _TestedByOffice == null ? null : ((long)_TestedByOffice.Key == 0 ? null : _TestedByOffice); }
            set 
            { 
                _TestedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfTestedByOffice = _TestedByOffice == null 
                    ? new Int64?()
                    : _TestedByOffice.idfInstitution; 
                OnPropertyChanged(_str_TestedByOffice); 
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
            
                case _str_PensideTestType:
                    return new BvSelectList(PensideTestTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, PensideTestType, _str_idfsPensideTestType);
            
                case _str_PensideTestCategory:
                    return new BvSelectList(PensideTestCategoryLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, PensideTestCategory, _str_idfsPensideTestCategory);
            
                case _str_TestedByPerson:
                    return new BvSelectList(TestedByPersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, TestedByPerson, _str_idfTestedByPerson);
            
                case _str_TestedByOffice:
                    return new BvSelectList(TestedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, TestedByOffice, _str_idfTestedByOffice);
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_tempint)]
        public long tempint
        {
            get { return m_tempint; }
            set { if (m_tempint != value) { m_tempint = value; OnPropertyChanged(_str_tempint); } }
        }
        private long m_tempint;
        
          [LocalizedDisplayName("idfsVectorSubType")]
        public string strVectorSubTypeName
        {
            get { return m_strVectorSubTypeName; }
            set { if (m_strVectorSubTypeName != value) { m_strVectorSubTypeName = value; OnPropertyChanged(_str_strVectorSubTypeName); } }
        }
        private string m_strVectorSubTypeName;
        
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
        TypeFieldTestToResultMatrix.ForEach(c => { c.Parent = this; });
                Diagnosis2PensideTestMatrix.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as VectorFieldTest;
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
            var ret = base.Clone() as VectorFieldTest;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
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
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || TypeFieldTestToResultMatrix.IsDirty
                    || TypeFieldTestToResultMatrix.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Diagnosis2PensideTestMatrix.IsDirty
                    || Diagnosis2PensideTestMatrix.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsPensideTestType_PensideTestType = idfsPensideTestType;
            var _prev_idfsPensideTestCategory_PensideTestCategory = idfsPensideTestCategory;
            var _prev_idfTestedByPerson_TestedByPerson = idfTestedByPerson;
            var _prev_idfTestedByOffice_TestedByOffice = idfTestedByOffice;
            base.RejectChanges();
        
            if (_prev_idfsPensideTestType_PensideTestType != idfsPensideTestType)
            {
                _PensideTestType = _PensideTestTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsPensideTestType);
            }
            if (_prev_idfsPensideTestCategory_PensideTestCategory != idfsPensideTestCategory)
            {
                _PensideTestCategory = _PensideTestCategoryLookup.FirstOrDefault(c => c.idfsBaseReference == idfsPensideTestCategory);
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
        TypeFieldTestToResultMatrix.RejectChanges();
                Diagnosis2PensideTestMatrix.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        TypeFieldTestToResultMatrix.AcceptChanges();
                Diagnosis2PensideTestMatrix.AcceptChanges();
                
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
        TypeFieldTestToResultMatrix.ForEach(c => c.SetChange());
                Diagnosis2PensideTestMatrix.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, VectorFieldTest c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public VectorFieldTest()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VectorFieldTest_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VectorFieldTest_PropertyChanged);
        }
        private void VectorFieldTest_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VectorFieldTest).Changed(e.PropertyName);
            
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

    
        private static string[] readonly_names1 = "datTestDate,idfsPensideTestCategory,idfTestedByPerson,idfTestedByOffice,idfsPensideTestResult,idfsDiagnosis".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VectorFieldTest, bool>(c => false)(this);
            
            return ReadOnly || new Func<VectorFieldTest, bool>(c => true)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _TypeFieldTestToResultMatrix)
                    o.ReadOnly = value;
                
                foreach(var o in _Diagnosis2PensideTestMatrix)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<VectorFieldTest, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VectorFieldTest, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VectorFieldTest, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<VectorFieldTest, bool>> m_isHiddenPersonalData;
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
                
                LookupManager.RemoveObject("rftPensideTestType", this);
                
                LookupManager.RemoveObject("rftPensideTestCategory", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftPensideTestType")
                _getAccessor().LoadLookup_PensideTestType(manager, this);
            
            if (lookup_object == "rftPensideTestCategory")
                _getAccessor().LoadLookup_PensideTestCategory(manager, this);
            
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
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._name] != null) a._set_func(this, form[ObjectIdent + a._name]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._name)) a._set_func(this, form[ObjectIdent + a._name]);} );
      
            if (bParseRelations)
            {
        
            if (_TypeFieldTestToResultMatrix != null) _TypeFieldTestToResultMatrix.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Diagnosis2PensideTestMatrix != null) _Diagnosis2PensideTestMatrix.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    
        #region Class for web grid
        public class VectorFieldTestGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfPensideTest { get; set; }
        
            public String strPensideTestTypeName { get; set; }
        
            public String strVectorID { get; set; }
        
            public String strFieldBarcode { get; set; }
        
            public string strVectorSubTypeName { get; set; }
        
            public String strSpecimenName { get; set; }
        
            public DateTime? datFieldCollectionDate { get; set; }
        
            public DateTime? datTestDate { get; set; }
        
            public Int64? idfsPensideTestCategory { get; set; }
        
            public Int64? idfTestedByPerson { get; set; }
        
            public Int64? idfTestedByOffice { get; set; }
        
            public Int64? idfsPensideTestResult { get; set; }
        
            public Int64? idfsDiagnosis { get; set; }
        
        }
        public partial class VectorFieldTestGridModelList : List<VectorFieldTestGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public VectorFieldTestGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VectorFieldTest>, errMes);
            }
            public VectorFieldTestGridModelList(long key, IEnumerable<VectorFieldTest> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<VectorFieldTest> items);
            private void LoadGridModelList(long key, IEnumerable<VectorFieldTest> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strPensideTestTypeName,_str_strVectorID,_str_strFieldBarcode,_str_strVectorSubTypeName,_str_strSpecimenName,_str_datFieldCollectionDate,_str_datTestDate,_str_idfsPensideTestCategory,_str_idfTestedByPerson,_str_idfTestedByOffice,_str_idfsPensideTestResult,_str_idfsDiagnosis};
                    
                Hiddens = new List<string> {_str_idfPensideTest};
                Keys = new List<string> {_str_idfPensideTest};
                Labels = new Dictionary<string, string> {{_str_strPensideTestTypeName, "TestName"},{_str_strVectorID, "Vector.strVectorID"},{_str_strFieldBarcode, "VectorSample.strFieldBarcode"},{_str_strVectorSubTypeName, "idfsVectorSubType"},{_str_strSpecimenName, "idfsSpecimenType"},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_datTestDate, "idfPensideTestTestDate"},{_str_idfsPensideTestCategory, "idfPensideTestTestCategory"},{_str_idfTestedByPerson, "idfPensideTestTestedByPerson"},{_str_idfTestedByOffice, "idfPensideTestTestedByOffice"},{_str_idfsPensideTestResult, _str_idfsPensideTestResult},{_str_idfsDiagnosis, "FT.strDisease"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<VectorFieldTest>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VectorFieldTestGridModel()
                {
                    ItemKey=c.idfPensideTest,strPensideTestTypeName=c.strPensideTestTypeName,strVectorID=c.strVectorID,strFieldBarcode=c.strFieldBarcode,strVectorSubTypeName=c.strVectorSubTypeName,strSpecimenName=c.strSpecimenName,datFieldCollectionDate=c.datFieldCollectionDate,datTestDate=c.datTestDate,idfsPensideTestCategory=c.idfsPensideTestCategory,idfTestedByPerson=c.idfTestedByPerson,idfTestedByOffice=c.idfTestedByOffice,idfsPensideTestResult=c.idfsPensideTestResult,idfsDiagnosis=c.idfsDiagnosis
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
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
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
            private TypeFieldTestToResultMatrixLookup.Accessor TypeFieldTestToResultMatrixAccessor { get { return eidss.model.Schema.TypeFieldTestToResultMatrixLookup.Accessor.Instance(m_CS); } }
            private Diagnosis2PensideTestMatrixLookup.Accessor Diagnosis2PensideTestMatrixAccessor { get { return eidss.model.Schema.Diagnosis2PensideTestMatrixLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PensideTestTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PensideTestCategoryAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
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
                , Int64? idfVectorSurveillanceSession
                )
            {
                return _SelectList(manager
                    , idfVectorSurveillanceSession
                    , delegate(VectorFieldTest obj)
                        {
                        }
                    , delegate(VectorFieldTest obj)
                        {
                        }
                    );
            }

            
            private List<VectorFieldTest> _SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
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
    
            private void _SetupAddChildHandlerTypeFieldTestToResultMatrix(VectorFieldTest obj)
            {
                obj.TypeFieldTestToResultMatrix.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerDiagnosis2PensideTestMatrix(VectorFieldTest obj)
            {
                obj.Diagnosis2PensideTestMatrix.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadTypeFieldTestToResultMatrix(VectorFieldTest obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadTypeFieldTestToResultMatrix(manager, obj);
                }
            }
            internal void _LoadTypeFieldTestToResultMatrix(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.TypeFieldTestToResultMatrix.Clear();
                obj.TypeFieldTestToResultMatrix.AddRange(TypeFieldTestToResultMatrixAccessor.SelectDetailList(manager
                    
                    , obj.idfsPensideTestResult.HasValue ? obj.idfsPensideTestResult.Value : 0
                    ));
                obj.TypeFieldTestToResultMatrix.ForEach(c => c.m_ObjectName = _str_TypeFieldTestToResultMatrix);
                obj.TypeFieldTestToResultMatrix.AcceptChanges();
                    
            }
            
            internal void _LoadDiagnosis2PensideTestMatrix(VectorFieldTest obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadDiagnosis2PensideTestMatrix(manager, obj);
                }
            }
            internal void _LoadDiagnosis2PensideTestMatrix(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.Diagnosis2PensideTestMatrix.Clear();
                obj.Diagnosis2PensideTestMatrix.AddRange(Diagnosis2PensideTestMatrixAccessor.SelectDetailList(manager
                    
                    , obj.idfsDiagnosis.HasValue ? obj.idfsDiagnosis.Value : 0
                    ));
                obj.Diagnosis2PensideTestMatrix.ForEach(c => c.m_ObjectName = _str_Diagnosis2PensideTestMatrix);
                obj.Diagnosis2PensideTestMatrix.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, VectorFieldTest obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadTypeFieldTestToResultMatrix(manager, obj);
                _LoadDiagnosis2PensideTestMatrix(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerTypeFieldTestToResultMatrix(obj);
                
                _SetupAddChildHandlerDiagnosis2PensideTestMatrix(obj);
                
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
                    
                        obj.TypeFieldTestToResultMatrix.ForEach(c => TypeFieldTestToResultMatrixAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Diagnosis2PensideTestMatrix.ForEach(c => Diagnosis2PensideTestMatrixAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private VectorFieldTest _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
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
                obj.idfPensideTest = (new AutoIncrementExtender<VectorFieldTest>()).GetScalar(manager, obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerTypeFieldTestToResultMatrix(obj);
                    
                    _SetupAddChildHandlerDiagnosis2PensideTestMatrix(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.idfTestedByPerson = new Func<VectorFieldTest, long>(c => (long)EidssUserContext.User.EmployeeID)(obj);
                obj.idfTestedByOffice = new Func<VectorFieldTest, long>(c => (long)EidssUserContext.User.OrganizationID)(obj);
                obj.tempint = new Func<VectorFieldTest, DbManagerProxy, long>((c,m) => { _LoadTypeFieldTestToResultMatrix(m,c); return c.tempint; })(obj, manager);
                obj.tempint = new Func<VectorFieldTest, DbManagerProxy, long>((c,m) => { _LoadDiagnosis2PensideTestMatrix(m,c); return c.tempint; })(obj, manager);
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
            
            public VectorFieldTest CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult SetResultEmpty(DbManagerProxy manager, VectorFieldTest obj, List<object> pars)
            {
                
                return SetResultEmpty(manager, obj
                    );
            }
            public ActResult SetResultEmpty(DbManagerProxy manager, VectorFieldTest obj
                )
            {
                
                return true;
                
            }
            
            public ActResult ClearTestResults(DbManagerProxy manager, VectorFieldTest obj, List<object> pars)
            {
                
                return ClearTestResults(manager, obj
                    );
            }
            public ActResult ClearTestResults(DbManagerProxy manager, VectorFieldTest obj
                )
            {
                
                return true;
                
            }
            
            private void _SetupChildHandlers(VectorFieldTest obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VectorFieldTest obj)
            {
                
            }
    
            public void LoadLookup_PensideTestType(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.PensideTestTypeLookup.Clear();
                
                obj.PensideTestTypeLookup.Add(PensideTestTypeAccessor.CreateNewT(manager, null));
                
                obj.PensideTestTypeLookup.AddRange(PensideTestTypeAccessor.rftPensideTestType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsPensideTestType))
                    
                    .ToList());
                
                if (obj.idfsPensideTestType != null && obj.idfsPensideTestType != 0)
                {
                    obj.PensideTestType = obj.PensideTestTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsPensideTestType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftPensideTestType", obj, PensideTestTypeAccessor.GetType(), "rftPensideTestType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_PensideTestCategory(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.PensideTestCategoryLookup.Clear();
                
                obj.PensideTestCategoryLookup.Add(PensideTestCategoryAccessor.CreateNewT(manager, null));
                
                obj.PensideTestCategoryLookup.AddRange(PensideTestCategoryAccessor.rftPensideTestCategory_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsPensideTestCategory))
                    
                    .ToList());
                
                if (obj.idfsPensideTestCategory != null && obj.idfsPensideTestCategory != 0)
                {
                    obj.PensideTestCategory = obj.PensideTestCategoryLookup
                        .Where(c => c.idfsBaseReference == obj.idfsPensideTestCategory)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftPensideTestCategory", obj, PensideTestCategoryAccessor.GetType(), "rftPensideTestCategory_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_TestedByPerson(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.TestedByPersonLookup.Clear();
                
                obj.TestedByPersonLookup.Add(TestedByPersonAccessor.CreateNewT(manager, null));
                
                obj.TestedByPersonLookup.AddRange(TestedByPersonAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfTestedByPerson))
                    
                    .ToList());
                
                if (obj.idfTestedByPerson != null && obj.idfTestedByPerson != 0)
                {
                    obj.TestedByPerson = obj.TestedByPersonLookup
                        .Where(c => c.idfPerson == obj.idfTestedByPerson)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("PersonLookup", obj, TestedByPersonAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_TestedByOffice(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                obj.TestedByOfficeLookup.Clear();
                
                obj.TestedByOfficeLookup.Add(TestedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.TestedByOfficeLookup.AddRange(TestedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfTestedByOffice))
                    
                    .ToList());
                
                if (obj.idfTestedByOffice != null && obj.idfTestedByOffice != 0)
                {
                    obj.TestedByOffice = obj.TestedByOfficeLookup
                        .Where(c => c.idfInstitution == obj.idfTestedByOffice)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("OrganizationLookup", obj, TestedByOfficeAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, VectorFieldTest obj)
            {
                
                LoadLookup_PensideTestType(manager, obj);
                
                LoadLookup_PensideTestCategory(manager, obj);
                
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
                obj.AcceptChanges();
                
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
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, false);
                        }
                     }
                }
                catch(ValidationModelException ex)
                {
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                        return false;
                    }
                    else
                        obj.m_IsForcedToDelete = true;
                }
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as VectorFieldTest, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VectorFieldTest obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfMaterial", "idfMaterial","",
                false
              )).Validate(c => true, obj, obj.idfMaterial);
            
                  
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
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                        return false;
                    }
                }
                
                return true;
            }
           
    
            private void _SetupRequired(VectorFieldTest obj)
            {
            
                obj
                    .AddRequired("idfMaterial", c => true);
                    
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
            static Meta()
            {
                
                Sizes.Add(_str_strPensideTestTypeName, 2000);
                Sizes.Add(_str_strVectorTypeName, 2000);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strSpecimenName, 2000);
                Sizes.Add(_str_strPensideTestCategoryName, 2000);
                Sizes.Add(_str_strCollectedByPerson, 602);
                Sizes.Add(_str_strCollectedByOffice, 2000);
                Sizes.Add(_str_strPensideTestResultName, 2000);
                Sizes.Add(_str_strDiagnosisName, 2000);
                Sizes.Add(_str_strVectorID, 50);
                if (!RequiredByField.ContainsKey("idfMaterial")) RequiredByField.Add("idfMaterial", c => true);
                if (!RequiredByProperty.ContainsKey("idfMaterial")) RequiredByProperty.Add("idfMaterial", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfPensideTest,
                    _str_idfPensideTest, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPensideTestTypeName,
                    "TestName", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorID,
                    "Vector.strVectorID", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode,
                    "VectorSample.strFieldBarcode", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorSubTypeName,
                    "idfsVectorSubType", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpecimenName,
                    "idfsSpecimenType", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datTestDate,
                    "idfPensideTestTestDate", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsPensideTestCategory,
                    "idfPensideTestTestCategory", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfTestedByPerson,
                    "idfPensideTestTestedByPerson", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfTestedByOffice,
                    "idfPensideTestTestedByOffice", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsPensideTestResult,
                    _str_idfsPensideTestResult, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsDiagnosis,
                    "FT.strDisease", null, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "SetResult",
                    ActionTypes.Container,
                    true,
                    "",
                    "",
                    
                    null,
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleFieldTestsSetResult",
                        "",
                        /*from BvMessages*/"titleFieldTestsSetResult",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      false,
                    "VsSession.Update",
                    null,
                    (c, p, b) => c != null &&  !c.ReadOnly ,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "SetResultEmpty",
                    ActionTypes.Action,
                    true,
                    "",
                    "SetResult",
                    
                    (manager, c, pars) => Accessor.Instance(null).SetResultEmpty(manager, (VectorFieldTest)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleFieldTestsSetResultEmpty",
                        "",
                        /*from BvMessages*/"titleFieldTestsSetResultEmpty",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      false,
                    "VsSession.Update",
                    null,
                    (c, p, b) => c != null &&  !c.ReadOnly,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "ClearTestResults",
                    ActionTypes.Action,
                    true,
                    "",
                    "SetResult",
                    
                    (manager, c, pars) => Accessor.Instance(null).ClearTestResults(manager, (VectorFieldTest)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleClearTestResults",
                        "",
                        /*from BvMessages*/"titleClearTestResults",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      false,
                    "VsSession.Update",
                    null,
                    (c, p, b) => c != null &&  !c.ReadOnly,
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
	