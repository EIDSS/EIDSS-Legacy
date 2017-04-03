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
    public abstract partial class PensideTest : 
        EditableObject<PensideTest>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfPensideTest), NonUpdatable, PrimaryKey]
        public abstract Int64 idfPensideTest { get; set; }
                
        [LocalizedDisplayName(_str_idfVetCase)]
        [MapField(_str_idfVetCase)]
        public abstract Int64? idfVetCase { get; set; }
        #if MONO
        protected Int64? idfVetCase_Original { get { return idfVetCase; } }
        protected Int64? idfVetCase_Previous { get { return idfVetCase; } }
        #else
        protected Int64? idfVetCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVetCase).OriginalValue; } }
        protected Int64? idfVetCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVetCase).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfParty)]
        [MapField(_str_idfParty)]
        public abstract Int64? idfParty { get; set; }
        #if MONO
        protected Int64? idfParty_Original { get { return idfParty; } }
        protected Int64? idfParty_Previous { get { return idfParty; } }
        #else
        protected Int64? idfParty_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParty).OriginalValue; } }
        protected Int64? idfParty_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParty).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strBarcode)]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        #if MONO
        protected String strBarcode_Original { get { return strBarcode; } }
        protected String strBarcode_Previous { get { return strBarcode; } }
        #else
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strFieldBarcodeField")]
        [MapField(_str_strFieldBarcode)]
        public abstract String strFieldBarcode { get; set; }
        #if MONO
        protected String strFieldBarcode_Original { get { return strFieldBarcode; } }
        protected String strFieldBarcode_Previous { get { return strFieldBarcode; } }
        #else
        protected String strFieldBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).OriginalValue; } }
        protected String strFieldBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strPensideTestTypeName)]
        [MapField(_str_strPensideTestTypeName)]
        public abstract String strPensideTestTypeName { get; set; }
        #if MONO
        protected String strPensideTestTypeName_Original { get { return strPensideTestTypeName; } }
        protected String strPensideTestTypeName_Previous { get { return strPensideTestTypeName; } }
        #else
        protected String strPensideTestTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestTypeName).OriginalValue; } }
        protected String strPensideTestTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPensideTestTypeName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("SpecimenType")]
        [MapField(_str_strSpecimenName)]
        public abstract String strSpecimenName { get; set; }
        #if MONO
        protected String strSpecimenName_Original { get { return strSpecimenName; } }
        protected String strSpecimenName_Previous { get { return strSpecimenName; } }
        #else
        protected String strSpecimenName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSpecimenName).OriginalValue; } }
        protected String strSpecimenName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSpecimenName).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_datTestDate)]
        [MapField(_str_datTestDate)]
        public abstract DateTime? datTestDate { get; set; }
        #if MONO
        protected DateTime? datTestDate_Original { get { return datTestDate; } }
        protected DateTime? datTestDate_Previous { get { return datTestDate; } }
        #else
        protected DateTime? datTestDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTestDate).OriginalValue; } }
        protected DateTime? datTestDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datTestDate).PreviousValue; } }
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
                
        [LocalizedDisplayName("AnimalID")]
        [MapField(_str_strAnimal)]
        public abstract String strAnimal { get; set; }
        #if MONO
        protected String strAnimal_Original { get { return strAnimal; } }
        protected String strAnimal_Previous { get { return strAnimal; } }
        #else
        protected String strAnimal_Original { get { return ((EditableValue<String>)((dynamic)this)._strAnimal).OriginalValue; } }
        protected String strAnimal_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAnimal).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_Species)]
        [MapField(_str_Species)]
        public abstract String Species { get; set; }
        #if MONO
        protected String Species_Original { get { return Species; } }
        protected String Species_Previous { get { return Species; } }
        #else
        protected String Species_Original { get { return ((EditableValue<String>)((dynamic)this)._species).OriginalValue; } }
        protected String Species_Previous { get { return ((EditableValue<String>)((dynamic)this)._species).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strDummy)]
        [MapField(_str_strDummy)]
        public abstract String strDummy { get; set; }
        #if MONO
        protected String strDummy_Original { get { return strDummy; } }
        protected String strDummy_Previous { get { return strDummy; } }
        #else
        protected String strDummy_Original { get { return ((EditableValue<String>)((dynamic)this)._strDummy).OriginalValue; } }
        protected String strDummy_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDummy).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<PensideTest, object> _get_func;
            internal Action<PensideTest, string> _set_func;
            internal Action<PensideTest, PensideTest, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfPensideTest = "idfPensideTest";
        internal const string _str_idfVetCase = "idfVetCase";
        internal const string _str_idfParty = "idfParty";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_idfsPensideTestResult = "idfsPensideTestResult";
        internal const string _str_strPensideTestResultName = "strPensideTestResultName";
        internal const string _str_idfsPensideTestType = "idfsPensideTestType";
        internal const string _str_strPensideTestTypeName = "strPensideTestTypeName";
        internal const string _str_strSpecimenName = "strSpecimenName";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfVector = "idfVector";
        internal const string _str_datTestDate = "datTestDate";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_strAnimal = "strAnimal";
        internal const string _str_Species = "Species";
        internal const string _str_strDummy = "strDummy";
        internal const string _str_NewObject = "NewObject";
        internal const string _str_SamplesFromCase = "SamplesFromCase";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_SampleType = "SampleType";
        internal const string _str_FieldID = "FieldID";
        internal const string _str_AnimalID = "AnimalID";
        internal const string _str_SpeciesID = "SpeciesID";
        internal const string _str_PensideTestResult = "PensideTestResult";
        internal const string _str_PensideTestType = "PensideTestType";
        internal const string _str_Samples = "Samples";
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
              _name = _str_idfVetCase, _type = "Int64?",
              _get_func = o => o.idfVetCase,
              _set_func = (o, val) => { o.idfVetCase = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVetCase != c.idfVetCase || o.IsRIRPropChanged(_str_idfVetCase, c)) 
                  m.Add(_str_idfVetCase, o.ObjectIdent + _str_idfVetCase, "Int64?", o.idfVetCase == null ? "" : o.idfVetCase.ToString(), o.IsReadOnly(_str_idfVetCase), o.IsInvisible(_str_idfVetCase), o.IsRequired(_str_idfVetCase)); }
              }, 
        
            new field_info {
              _name = _str_idfParty, _type = "Int64?",
              _get_func = o => o.idfParty,
              _set_func = (o, val) => { o.idfParty = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_idfParty, c)) 
                  m.Add(_str_idfParty, o.ObjectIdent + _str_idfParty, "Int64?", o.idfParty == null ? "" : o.idfParty.ToString(), o.IsReadOnly(_str_idfParty), o.IsInvisible(_str_idfParty), o.IsRequired(_str_idfParty)); }
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
              _name = _str_strSpecimenName, _type = "String",
              _get_func = o => o.strSpecimenName,
              _set_func = (o, val) => { o.strSpecimenName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSpecimenName != c.strSpecimenName || o.IsRIRPropChanged(_str_strSpecimenName, c)) 
                  m.Add(_str_strSpecimenName, o.ObjectIdent + _str_strSpecimenName, "String", o.strSpecimenName == null ? "" : o.strSpecimenName.ToString(), o.IsReadOnly(_str_strSpecimenName), o.IsInvisible(_str_strSpecimenName), o.IsRequired(_str_strSpecimenName)); }
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
              _name = _str_datTestDate, _type = "DateTime?",
              _get_func = o => o.datTestDate,
              _set_func = (o, val) => { o.datTestDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datTestDate != c.datTestDate || o.IsRIRPropChanged(_str_datTestDate, c)) 
                  m.Add(_str_datTestDate, o.ObjectIdent + _str_datTestDate, "DateTime?", o.datTestDate == null ? "" : o.datTestDate.ToString(), o.IsReadOnly(_str_datTestDate), o.IsInvisible(_str_datTestDate), o.IsRequired(_str_datTestDate)); }
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
              _name = _str_strAnimal, _type = "String",
              _get_func = o => o.strAnimal,
              _set_func = (o, val) => { o.strAnimal = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strAnimal != c.strAnimal || o.IsRIRPropChanged(_str_strAnimal, c)) 
                  m.Add(_str_strAnimal, o.ObjectIdent + _str_strAnimal, "String", o.strAnimal == null ? "" : o.strAnimal.ToString(), o.IsReadOnly(_str_strAnimal), o.IsInvisible(_str_strAnimal), o.IsRequired(_str_strAnimal)); }
              }, 
        
            new field_info {
              _name = _str_Species, _type = "String",
              _get_func = o => o.Species,
              _set_func = (o, val) => { o.Species = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.Species != c.Species || o.IsRIRPropChanged(_str_Species, c)) 
                  m.Add(_str_Species, o.ObjectIdent + _str_Species, "String", o.Species == null ? "" : o.Species.ToString(), o.IsReadOnly(_str_Species), o.IsInvisible(_str_Species), o.IsRequired(_str_Species)); }
              }, 
        
            new field_info {
              _name = _str_strDummy, _type = "String",
              _get_func = o => o.strDummy,
              _set_func = (o, val) => { o.strDummy = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strDummy != c.strDummy || o.IsRIRPropChanged(_str_strDummy, c)) 
                  m.Add(_str_strDummy, o.ObjectIdent + _str_strDummy, "String", o.strDummy == null ? "" : o.strDummy.ToString(), o.IsReadOnly(_str_strDummy), o.IsInvisible(_str_strDummy), o.IsRequired(_str_strDummy)); }
              }, 
        
            new field_info {
              _name = _str_NewObject, _type = "bool",
              _get_func = o => o.NewObject,
              _set_func = (o, val) => { o.NewObject = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.NewObject != c.NewObject || o.IsRIRPropChanged(_str_NewObject, c)) 
                  m.Add(_str_NewObject, o.ObjectIdent + _str_NewObject, "bool", o.NewObject == null ? "" : o.NewObject.ToString(), o.IsReadOnly(_str_NewObject), o.IsInvisible(_str_NewObject), o.IsRequired(_str_NewObject));
                 }
              }, 
        
            new field_info {
              _name = _str_SamplesFromCase, _type = "EditableList<VetCaseSample>",
              _get_func = o => o.SamplesFromCase,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_CaseObjectIdent, _type = "string",
              _get_func = o => o.CaseObjectIdent,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.CaseObjectIdent != c.CaseObjectIdent || o.IsRIRPropChanged(_str_CaseObjectIdent, c)) 
                  m.Add(_str_CaseObjectIdent, o.ObjectIdent + _str_CaseObjectIdent, "string", o.CaseObjectIdent == null ? "" : o.CaseObjectIdent.ToString(), o.IsReadOnly(_str_CaseObjectIdent), o.IsInvisible(_str_CaseObjectIdent), o.IsRequired(_str_CaseObjectIdent));
                 }
              }, 
        
            new field_info {
              _name = _str_SampleType, _type = "string",
              _get_func = o => o.SampleType,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.SampleType != c.SampleType || o.IsRIRPropChanged(_str_SampleType, c)) 
                  m.Add(_str_SampleType, o.ObjectIdent + _str_SampleType, "string", o.SampleType == null ? "" : o.SampleType.ToString(), o.IsReadOnly(_str_SampleType), o.IsInvisible(_str_SampleType), o.IsRequired(_str_SampleType));
                 }
              }, 
        
            new field_info {
              _name = _str_FieldID, _type = "string",
              _get_func = o => o.FieldID,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.FieldID != c.FieldID || o.IsRIRPropChanged(_str_FieldID, c)) 
                  m.Add(_str_FieldID, o.ObjectIdent + _str_FieldID, "string", o.FieldID == null ? "" : o.FieldID.ToString(), o.IsReadOnly(_str_FieldID), o.IsInvisible(_str_FieldID), o.IsRequired(_str_FieldID));
                 }
              }, 
        
            new field_info {
              _name = _str_AnimalID, _type = "string",
              _get_func = o => o.AnimalID,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.AnimalID != c.AnimalID || o.IsRIRPropChanged(_str_AnimalID, c)) 
                  m.Add(_str_AnimalID, o.ObjectIdent + _str_AnimalID, "string", o.AnimalID == null ? "" : o.AnimalID.ToString(), o.IsReadOnly(_str_AnimalID), o.IsInvisible(_str_AnimalID), o.IsRequired(_str_AnimalID));
                 }
              }, 
        
            new field_info {
              _name = _str_SpeciesID, _type = "string",
              _get_func = o => o.SpeciesID,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.SpeciesID != c.SpeciesID || o.IsRIRPropChanged(_str_SpeciesID, c)) 
                  m.Add(_str_SpeciesID, o.ObjectIdent + _str_SpeciesID, "string", o.SpeciesID == null ? "" : o.SpeciesID.ToString(), o.IsReadOnly(_str_SpeciesID), o.IsInvisible(_str_SpeciesID), o.IsRequired(_str_SpeciesID));
                 }
              }, 
        
            new field_info {
              _name = _str_PensideTestResult, _type = "Lookup",
              _get_func = o => { if (o.PensideTestResult == null) return null; return o.PensideTestResult.idfsBaseReference; },
              _set_func = (o, val) => { o.PensideTestResult = o.PensideTestResultLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsPensideTestResult != c.idfsPensideTestResult || o.IsRIRPropChanged(_str_PensideTestResult, c)) 
                  m.Add(_str_PensideTestResult, o.ObjectIdent + _str_PensideTestResult, "Lookup", o.idfsPensideTestResult == null ? "" : o.idfsPensideTestResult.ToString(), o.IsReadOnly(_str_PensideTestResult), o.IsInvisible(_str_PensideTestResult), o.IsRequired(_str_PensideTestResult)); }
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
              _name = _str_Samples, _type = "Lookup",
              _get_func = o => { if (o.Samples == null) return null; return o.Samples.idfMaterial; },
              _set_func = (o, val) => { o.Samples = o.SamplesLookup.Where(c => c.idfMaterial.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfMaterial != c.idfMaterial || o.IsRIRPropChanged(_str_Samples, c)) 
                  m.Add(_str_Samples, o.ObjectIdent + _str_Samples, "Lookup", o.idfMaterial == null ? "" : o.idfMaterial.ToString(), o.IsReadOnly(_str_Samples), o.IsInvisible(_str_Samples), o.IsRequired(_str_Samples)); }
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
            PensideTest obj = (PensideTest)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsPensideTestResult)]
        public BaseReference PensideTestResult
        {
            get { return _PensideTestResult == null ? null : ((long)_PensideTestResult.Key == 0 ? null : _PensideTestResult); }
            set 
            { 
                _PensideTestResult = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsPensideTestResult = _PensideTestResult == null 
                    ? new Int64?()
                    : _PensideTestResult.idfsBaseReference; 
                OnPropertyChanged(_str_PensideTestResult); 
            }
        }
        private BaseReference _PensideTestResult;

        
        public BaseReferenceList PensideTestResultLookup
        {
            get { return _PensideTestResultLookup; }
        }
        private BaseReferenceList _PensideTestResultLookup = new BaseReferenceList("rftPensideTestResult");
            
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
            
        [Relation(typeof(VetCaseSample), eidss.model.Schema.VetCaseSample._str_idfMaterial, _str_idfMaterial)]
        public VetCaseSample Samples
        {
            get { return _Samples == null ? null : ((long)_Samples.Key == 0 ? null : _Samples); }
            set 
            { 
                _Samples = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfMaterial = _Samples == null 
                    ? new Int64()
                    : _Samples.idfMaterial; 
                OnPropertyChanged(_str_Samples); 
            }
        }
        private VetCaseSample _Samples;

        
        public List<VetCaseSample> SamplesLookup
        {
            get 
            { 
                var ret = new List<VetCaseSample>();
                using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    ret.Add(eidss.model.Schema.VetCaseSample.Accessor.Instance(null).CreateNewT(manager, null));
                if (SamplesFromCase != null)
                    ret.AddRange(SamplesFromCase
                        .Where(c => !c.IsMarkedToDelete)
                            
                    );
                return ret;
            }
        }
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_PensideTestResult:
                    return new BvSelectList(PensideTestResultLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, PensideTestResult, _str_idfsPensideTestResult);
            
                case _str_PensideTestType:
                    return new BvSelectList(PensideTestTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, PensideTestType, _str_idfsPensideTestType);
            
                case _str_Samples:
                    return new BvSelectList(SamplesLookup, eidss.model.Schema.VetCaseSample._str_idfMaterial, null, Samples, _str_idfMaterial);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_SamplesFromCase)]
        public EditableList<VetCaseSample> SamplesFromCase
        {
            get { return new Func<PensideTest, EditableList<VetCaseSample>>(c => (c.Parent as VetCase).Samples)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<PensideTest, string>(c => "VetCase_" + c.idfVetCase + "_")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("SpecimenType")]
        public string SampleType
        {
            get { return new Func<PensideTest, string>(c => c.SamplesFromCase == null || c.SamplesFromCase.Count == 0 || c.idfMaterial == 0 ? "" : c.SamplesFromCase.Where(a => a.idfMaterial == c.idfMaterial).Single().strSpecimenName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_FieldID)]
        public string FieldID
        {
            get { return new Func<PensideTest, string>(c => c.SamplesFromCase == null || c.SamplesFromCase.Count == 0 || c.idfMaterial == 0 ? "" : c.SamplesFromCase.Where(a => a.idfMaterial == c.idfMaterial).Single().strFieldBarcode)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_AnimalID)]
        public string AnimalID
        {
            get { return new Func<PensideTest, string>(c => c.SamplesFromCase == null || c.SamplesFromCase.Count == 0 || c.idfMaterial == 0 ? "" : c.SamplesFromCase.Where(a => a.idfMaterial == c.idfMaterial).Single().AnimalID)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_SpeciesID)]
        public string SpeciesID
        {
            get { return new Func<PensideTest, string>(c => c.SamplesFromCase == null || c.SamplesFromCase.Count == 0 || c.idfMaterial == 0 ? "" : c.SamplesFromCase.Where(a => a.idfMaterial == c.idfMaterial).Single().Species)(this); }
            
        }
        
          [LocalizedDisplayName(_str_NewObject)]
        public bool NewObject
        {
            get { return m_NewObject; }
            set { if (m_NewObject != value) { m_NewObject = value; OnPropertyChanged(_str_NewObject); } }
        }
        private bool m_NewObject;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "PensideTest";

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
            var ret = base.Clone() as PensideTest;
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
            var ret = base.Clone() as PensideTest;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public PensideTest CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as PensideTest;
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
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsPensideTestResult_PensideTestResult = idfsPensideTestResult;
            var _prev_idfsPensideTestType_PensideTestType = idfsPensideTestType;
            base.RejectChanges();
        
            if (_prev_idfsPensideTestResult_PensideTestResult != idfsPensideTestResult)
            {
                _PensideTestResult = _PensideTestResultLookup.FirstOrDefault(c => c.idfsBaseReference == idfsPensideTestResult);
            }
            if (_prev_idfsPensideTestType_PensideTestType != idfsPensideTestType)
            {
                _PensideTestType = _PensideTestTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsPensideTestType);
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

      private bool IsRIRPropChanged(string fld, PensideTest c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public PensideTest()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();

        
        private int? m_HACode;
        public int? _HACode { get { return m_HACode; } set { m_HACode = value; } }
        

        private bool m_IsForcedToDelete;
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(PensideTest_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(PensideTest_PropertyChanged);
        }
        private void PensideTest_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as PensideTest).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_SamplesFromCase);
                  
            if (e.PropertyName == _str_idfVetCase)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
            if (e.PropertyName == _str_idfMaterial)
                OnPropertyChanged(_str_SampleType);
                  
            if (e.PropertyName == _str_SamplesFromCase)
                OnPropertyChanged(_str_SampleType);
                  
            if (e.PropertyName == _str_idfMaterial)
                OnPropertyChanged(_str_FieldID);
                  
            if (e.PropertyName == _str_SamplesFromCase)
                OnPropertyChanged(_str_FieldID);
                  
            if (e.PropertyName == _str_idfMaterial)
                OnPropertyChanged(_str_AnimalID);
                  
            if (e.PropertyName == _str_SamplesFromCase)
                OnPropertyChanged(_str_AnimalID);
                  
            if (e.PropertyName == _str_idfMaterial)
                OnPropertyChanged(_str_SpeciesID);
                  
            if (e.PropertyName == _str_SamplesFromCase)
                OnPropertyChanged(_str_SpeciesID);
                  
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
            PensideTest obj = this;
            
        }
        private void _DeletedExtenders()
        {
            PensideTest obj = this;
            
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

    
        private static string[] readonly_names1 = "SampleType,AnimalID,Species".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<PensideTest, bool>(c => true)(this);
            
            return ReadOnly || new Func<PensideTest, bool>(c => false)(this);
                
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


        public Dictionary<string, Func<PensideTest, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<PensideTest, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<PensideTest, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<PensideTest, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<PensideTest, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<PensideTest, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~PensideTest()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftPensideTestResult", this);
                
                LookupManager.RemoveObject("rftPensideTestType", this);
                
                LookupManager.RemoveObject("VetCaseSample", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftPensideTestResult")
                _getAccessor().LoadLookup_PensideTestResult(manager, this);
            
            if (lookup_object == "rftPensideTestType")
                _getAccessor().LoadLookup_PensideTestType(manager, this);
            
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
    
        #region Class for web grid
        public class PensideTestGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfPensideTest { get; set; }
        
            public String strPensideTestTypeName { get; set; }
        
            public String strFieldBarcode { get; set; }
        
            public String strSpecimenName { get; set; }
        
            public string Species { get; set; }
        
            public string AnimalID { get; set; }
        
            public String strPensideTestResultName { get; set; }
        
        }
        public partial class PensideTestGridModelList : List<PensideTestGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public PensideTestGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<PensideTest>, errMes);
            }
            public PensideTestGridModelList(long key, IEnumerable<PensideTest> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<PensideTest> items);
            private void LoadGridModelList(long key, IEnumerable<PensideTest> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strPensideTestTypeName,_str_strFieldBarcode,_str_strSpecimenName,_str_Species,_str_AnimalID,_str_strPensideTestResultName};
                    
                Hiddens = new List<string> {_str_idfPensideTest};
                Keys = new List<string> {_str_idfPensideTest};
                Labels = new Dictionary<string, string> {{_str_strPensideTestTypeName, _str_strPensideTestTypeName},{_str_strFieldBarcode, "strFieldBarcodeField"},{_str_strSpecimenName, "SpecimenType"},{_str_Species, _str_Species},{_str_AnimalID, _str_AnimalID},{_str_strPensideTestResultName, _str_strPensideTestResultName}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<PensideTest>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new PensideTestGridModel()
                {
                    ItemKey=c.idfPensideTest,strPensideTestTypeName=c.strPensideTestTypeName,strFieldBarcode=c.strFieldBarcode,strSpecimenName=c.strSpecimenName,Species=c.Species,AnimalID=c.AnimalID,strPensideTestResultName=c.strPensideTestResultName
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
        : DataAccessor<PensideTest>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(PensideTest obj);
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
            private BaseReference.Accessor PensideTestResultAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PensideTestTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private VetCaseSample.Accessor SamplesAccessor { get { return eidss.model.Schema.VetCaseSample.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , HACode
                    
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<PensideTest> SelectList(DbManagerProxy manager
                , Int64? idfCase
                , int? HACode
                
                )
            {
                return _SelectList(manager
                    , idfCase
                    , HACode
                    
                    , delegate(PensideTest obj)
                        {
                        }
                    , delegate(PensideTest obj)
                        {
                        }
                    );
            }

            
            private List<PensideTest> _SelectList(DbManagerProxy manager
                , Int64? idfCase
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<PensideTest> objs = new List<PensideTest>();
                    sets[0] = new MapResultSet(typeof(PensideTest), objs);
                    
                    manager
                        .SetSpCommand("spPensideTests_SelectDetail"
                            , manager.Parameter("@idfCase", idfCase)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
                        obj.m_CS = m_CS;
                        
                        obj._HACode = HACode;
                        
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, PensideTest obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, PensideTest obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private PensideTest _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    PensideTest obj = PensideTest.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    obj._HACode = HACode;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfPensideTest = (new GetNewIDExtender<PensideTest>()).GetScalar(manager, obj);
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

            
            public PensideTest CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public PensideTest CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public PensideTest CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                return Create(manager, Parent
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public PensideTest Create(DbManagerProxy manager, IObject Parent
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfVetCase = new Func<PensideTest, long>(c => (Parent as VetCase).idfCase)(obj);
                obj._HACode = new Func<PensideTest, int?>(c => (Parent as VetCase)._HACode)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(PensideTest obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(PensideTest obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_strDummy)
                        {
                    
                obj.Samples = new Func<PensideTest, VetCaseSample>(c => c.SamplesLookup.Where(i => i.idfMaterial == c.idfMaterial).SingleOrDefault())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterial)
                        {
                    
                obj.strFieldBarcode = new Func<PensideTest, string>(c => c.FieldID)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterial)
                        {
                    
                obj.strSpecimenName = new Func<PensideTest, string>(c => c.SampleType)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterial)
                        {
                    
                obj.strAnimal = new Func<PensideTest, string>(c => c.AnimalID)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfMaterial)
                        {
                    
                obj.Species = new Func<PensideTest, string>(c => c.SpeciesID)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsPensideTestType)
                        {
                    
                obj.strPensideTestTypeName = new Func<PensideTest, string>(c => c.idfsPensideTestType == null ? "" : c.PensideTestTypeLookup.Where(a => a.idfsBaseReference == c.idfsPensideTestType).Single().name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsPensideTestResult)
                        {
                    
                obj.strPensideTestResultName = new Func<PensideTest, string>(c => c.idfsPensideTestResult == null ? "" : c.PensideTestResultLookup.Where(a => a.idfsBaseReference == c.idfsPensideTestResult).Single().name)(obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_PensideTestResult(DbManagerProxy manager, PensideTest obj)
            {
                
                obj.PensideTestResultLookup.Clear();
                
                obj.PensideTestResultLookup.Add(PensideTestResultAccessor.CreateNewT(manager, null));
                
                obj.PensideTestResultLookup.AddRange(PensideTestResultAccessor.rftPensideTestResult_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsPensideTestResult))
                    
                    .ToList());
                
                if (obj.idfsPensideTestResult != null && obj.idfsPensideTestResult != 0)
                {
                    obj.PensideTestResult = obj.PensideTestResultLookup
                        .Where(c => c.idfsBaseReference == obj.idfsPensideTestResult)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftPensideTestResult", obj, PensideTestResultAccessor.GetType(), "rftPensideTestResult_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_PensideTestType(DbManagerProxy manager, PensideTest obj)
            {
                
                obj.PensideTestTypeLookup.Clear();
                
                obj.PensideTestTypeLookup.Add(PensideTestTypeAccessor.CreateNewT(manager, null));
                
                obj.PensideTestTypeLookup.AddRange(PensideTestTypeAccessor.rftPensideTestType_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode & obj._HACode) != 0)
                        
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
            

            private void _LoadLookups(DbManagerProxy manager, PensideTest obj)
            {
                
                LoadLookup_PensideTestResult(manager, obj);
                
                LoadLookup_PensideTestType(manager, obj);
                
            }
    
            [SprocName("spPensideTest_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spPensideTest_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                )
            {
                
                _postDelete(manager);
                
            }
        
            [SprocName("spPensideTest_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] PensideTest obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] PensideTest obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    PensideTest bo = obj as PensideTest;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as PensideTest, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, PensideTest obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(PensideTest obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, PensideTest obj)
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
                return Validate(manager, obj as PensideTest, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, PensideTest obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "PensideTestType", "PensideTestType","",
                false
              )).Validate(c => true, obj, obj.PensideTestType);
            
                (new RequiredValidator( "Samples", "Samples","strFieldBarcodeField",
                false
              )).Validate(c => true, obj, obj.Samples);
            
                  
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
           
    
            private void _SetupRequired(PensideTest obj)
            {
            
                obj
                    .AddRequired("PensideTestType", c => true);
                    
                obj
                    .AddRequired("Samples", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(PensideTest obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as PensideTest) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as PensideTest) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "PensideTestDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spPensideTests_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spPensideTest_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spPensideTest_Delete";
            public static string spCanDelete = "spPensideTest_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<PensideTest, bool>> RequiredByField = new Dictionary<string, Func<PensideTest, bool>>();
            public static Dictionary<string, Func<PensideTest, bool>> RequiredByProperty = new Dictionary<string, Func<PensideTest, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strPensideTestResultName, 2000);
                Sizes.Add(_str_strPensideTestTypeName, 2000);
                Sizes.Add(_str_strSpecimenName, 2000);
                Sizes.Add(_str_strAnimal, 200);
                Sizes.Add(_str_Species, 2000);
                Sizes.Add(_str_strDummy, 1);
                if (!RequiredByField.ContainsKey("PensideTestType")) RequiredByField.Add("PensideTestType", c => true);
                if (!RequiredByProperty.ContainsKey("PensideTestType")) RequiredByProperty.Add("PensideTestType", c => true);
                
                if (!RequiredByField.ContainsKey("Samples")) RequiredByField.Add("Samples", c => true);
                if (!RequiredByProperty.ContainsKey("Samples")) RequiredByProperty.Add("Samples", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfPensideTest,
                    _str_idfPensideTest, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPensideTestTypeName,
                    _str_strPensideTestTypeName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldBarcode,
                    "strFieldBarcodeField", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpecimenName,
                    "SpecimenType", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Species,
                    _str_Species, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_AnimalID,
                    _str_AnimalID, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPensideTestResultName,
                    _str_strPensideTestResultName, null, true, true, null
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
                    false
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
                    (manager, c, pars) => ((PensideTest)c).MarkToDelete(),
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
	