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
    public abstract partial class VectorSample : 
        EditableObject<VectorSample>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [LocalizedDisplayName("Vector.strVectorID")]
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
                
        [LocalizedDisplayName(_str_idfsVectorSubType)]
        [MapField(_str_idfsVectorSubType)]
        public abstract Int64 idfsVectorSubType { get; set; }
        #if MONO
        protected Int64 idfsVectorSubType_Original { get { return idfsVectorSubType; } }
        protected Int64 idfsVectorSubType_Previous { get { return idfsVectorSubType; } }
        #else
        protected Int64 idfsVectorSubType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSubType).OriginalValue; } }
        protected Int64 idfsVectorSubType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSubType).PreviousValue; } }
        #endif
                
        [MapField(_str_idfMaterial), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMaterial { get; set; }
                
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
                
        [LocalizedDisplayName(_str_strSpecimenName)]
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
                
        [LocalizedDisplayName("VectorSample.idfFieldCollectedByOffice")]
        [MapField(_str_idfFieldCollectedByOffice)]
        public abstract Int64? idfFieldCollectedByOffice { get; set; }
        #if MONO
        protected Int64? idfFieldCollectedByOffice_Original { get { return idfFieldCollectedByOffice; } }
        protected Int64? idfFieldCollectedByOffice_Previous { get { return idfFieldCollectedByOffice; } }
        #else
        protected Int64? idfFieldCollectedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).OriginalValue; } }
        protected Int64? idfFieldCollectedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("VectorSample.strNote")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        #if MONO
        protected String strNote_Original { get { return strNote; } }
        protected String strNote_Previous { get { return strNote; } }
        #else
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsAccessionCondition)]
        [MapField(_str_idfsAccessionCondition)]
        public abstract Int64? idfsAccessionCondition { get; set; }
        #if MONO
        protected Int64? idfsAccessionCondition_Original { get { return idfsAccessionCondition; } }
        protected Int64? idfsAccessionCondition_Previous { get { return idfsAccessionCondition; } }
        #else
        protected Int64? idfsAccessionCondition_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAccessionCondition).OriginalValue; } }
        protected Int64? idfsAccessionCondition_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAccessionCondition).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64? idfCase { get; set; }
        #if MONO
        protected Int64? idfCase_Original { get { return idfCase; } }
        protected Int64? idfCase_Previous { get { return idfCase; } }
        #else
        protected Int64? idfCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64? idfCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strVectorTypeName)]
        [MapField(_str_strVectorTypeName)]
        public abstract String strVectorTypeName { get; set; }
        #if MONO
        protected String strVectorTypeName_Original { get { return strVectorTypeName; } }
        protected String strVectorTypeName_Previous { get { return strVectorTypeName; } }
        #else
        protected String strVectorTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorTypeName).OriginalValue; } }
        protected String strVectorTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorTypeName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsVectorSubType")]
        [MapField(_str_strVectorSubTypeName)]
        public abstract String strVectorSubTypeName { get; set; }
        #if MONO
        protected String strVectorSubTypeName_Original { get { return strVectorSubTypeName; } }
        protected String strVectorSubTypeName_Previous { get { return strVectorSubTypeName; } }
        #else
        protected String strVectorSubTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorSubTypeName).OriginalValue; } }
        protected String strVectorSubTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorSubTypeName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsRegion)]
        [MapField(_str_idfsRegion)]
        public abstract Int64? idfsRegion { get; set; }
        #if MONO
        protected Int64? idfsRegion_Original { get { return idfsRegion; } }
        protected Int64? idfsRegion_Previous { get { return idfsRegion; } }
        #else
        protected Int64? idfsRegion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).OriginalValue; } }
        protected Int64? idfsRegion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strRegionName)]
        [MapField(_str_strRegionName)]
        public abstract String strRegionName { get; set; }
        #if MONO
        protected String strRegionName_Original { get { return strRegionName; } }
        protected String strRegionName_Previous { get { return strRegionName; } }
        #else
        protected String strRegionName_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegionName).OriginalValue; } }
        protected String strRegionName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegionName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsRayon)]
        [MapField(_str_idfsRayon)]
        public abstract Int64? idfsRayon { get; set; }
        #if MONO
        protected Int64? idfsRayon_Original { get { return idfsRayon; } }
        protected Int64? idfsRayon_Previous { get { return idfsRayon; } }
        #else
        protected Int64? idfsRayon_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).OriginalValue; } }
        protected Int64? idfsRayon_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strRayonName)]
        [MapField(_str_strRayonName)]
        public abstract String strRayonName { get; set; }
        #if MONO
        protected String strRayonName_Original { get { return strRayonName; } }
        protected String strRayonName_Previous { get { return strRayonName; } }
        #else
        protected String strRayonName_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayonName).OriginalValue; } }
        protected String strRayonName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayonName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intQuantity)]
        [MapField(_str_intQuantity)]
        public abstract Int32 intQuantity { get; set; }
        #if MONO
        protected Int32 intQuantity_Original { get { return intQuantity; } }
        protected Int32 intQuantity_Previous { get { return intQuantity; } }
        #else
        protected Int32 intQuantity_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intQuantity).OriginalValue; } }
        protected Int32 intQuantity_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intQuantity).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datCollectionDateTime)]
        [MapField(_str_datCollectionDateTime)]
        public abstract DateTime datCollectionDateTime { get; set; }
        #if MONO
        protected DateTime datCollectionDateTime_Original { get { return datCollectionDateTime; } }
        protected DateTime datCollectionDateTime_Previous { get { return datCollectionDateTime; } }
        #else
        protected DateTime datCollectionDateTime_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datCollectionDateTime).OriginalValue; } }
        protected DateTime datCollectionDateTime_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datCollectionDateTime).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strVectorID)]
        [MapField(_str_strVectorID)]
        public abstract String strVectorID { get; set; }
        #if MONO
        protected String strVectorID_Original { get { return strVectorID; } }
        protected String strVectorID_Previous { get { return strVectorID; } }
        #else
        protected String strVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).OriginalValue; } }
        protected String strVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_Used)]
        [MapField(_str_Used)]
        public abstract Int32 Used { get; set; }
        #if MONO
        protected Int32 Used_Original { get { return Used; } }
        protected Int32 Used_Previous { get { return Used; } }
        #else
        protected Int32 Used_Original { get { return ((EditableValue<Int32>)((dynamic)this)._used).OriginalValue; } }
        protected Int32 Used_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._used).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<VectorSample, object> _get_func;
            internal Action<VectorSample, string> _set_func;
            internal Action<VectorSample, VectorSample, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfVector = "idfVector";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_idfsVectorSubType = "idfsVectorSubType";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_idfsSpecimenType = "idfsSpecimenType";
        internal const string _str_strSpecimenName = "strSpecimenName";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_idfFieldCollectedByOffice = "idfFieldCollectedByOffice";
        internal const string _str_strNote = "strNote";
        internal const string _str_datAccession = "datAccession";
        internal const string _str_idfsAccessionCondition = "idfsAccessionCondition";
        internal const string _str_idfParty = "idfParty";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_strVectorTypeName = "strVectorTypeName";
        internal const string _str_strVectorSubTypeName = "strVectorSubTypeName";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_strRegionName = "strRegionName";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_strRayonName = "strRayonName";
        internal const string _str_intQuantity = "intQuantity";
        internal const string _str_datCollectionDateTime = "datCollectionDateTime";
        internal const string _str_strVectorID = "strVectorID";
        internal const string _str_Used = "Used";
        internal const string _str_NewObject = "NewObject";
        internal const string _str_strFieldCollectedByOffice = "strFieldCollectedByOffice";
        internal const string _str_isPool = "isPool";
        internal const string _str_isJustCreated = "isJustCreated";
        internal const string _str_SessionSamples = "SessionSamples";
        internal const string _str_FieldTests = "FieldTests";
        internal const string _str_Vectors = "Vectors";
        internal const string _str_LabTests = "LabTests";
        internal const string _str_ParentVector = "ParentVector";
        internal const string _str_CanChangeParentVector = "CanChangeParentVector";
        internal const string _str_FieldCollectedByOffice = "FieldCollectedByOffice";
        internal const string _str_AccessionCondition = "AccessionCondition";
        internal const string _str_VectorType = "VectorType";
        internal const string _str_VectorSubType = "VectorSubType";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_SampleTypesMatrix = "SampleTypesMatrix";
        private static readonly field_info[] _field_infos =
        {
        
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
              _name = _str_idfsVectorSubType, _type = "Int64",
              _get_func = o => o.idfsVectorSubType,
              _set_func = (o, val) => { o.idfsVectorSubType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_idfsVectorSubType, c)) 
                  m.Add(_str_idfsVectorSubType, o.ObjectIdent + _str_idfsVectorSubType, "Int64", o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(), o.IsReadOnly(_str_idfsVectorSubType), o.IsInvisible(_str_idfsVectorSubType), o.IsRequired(_str_idfsVectorSubType)); }
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
              _name = _str_idfFieldCollectedByOffice, _type = "Int64?",
              _get_func = o => o.idfFieldCollectedByOffice,
              _set_func = (o, val) => { o.idfFieldCollectedByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfFieldCollectedByOffice != c.idfFieldCollectedByOffice || o.IsRIRPropChanged(_str_idfFieldCollectedByOffice, c)) 
                  m.Add(_str_idfFieldCollectedByOffice, o.ObjectIdent + _str_idfFieldCollectedByOffice, "Int64?", o.idfFieldCollectedByOffice == null ? "" : o.idfFieldCollectedByOffice.ToString(), o.IsReadOnly(_str_idfFieldCollectedByOffice), o.IsInvisible(_str_idfFieldCollectedByOffice), o.IsRequired(_str_idfFieldCollectedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { o.strNote = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, "String", o.strNote == null ? "" : o.strNote.ToString(), o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); }
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
              _name = _str_idfsAccessionCondition, _type = "Int64?",
              _get_func = o => o.idfsAccessionCondition,
              _set_func = (o, val) => { o.idfsAccessionCondition = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAccessionCondition != c.idfsAccessionCondition || o.IsRIRPropChanged(_str_idfsAccessionCondition, c)) 
                  m.Add(_str_idfsAccessionCondition, o.ObjectIdent + _str_idfsAccessionCondition, "Int64?", o.idfsAccessionCondition == null ? "" : o.idfsAccessionCondition.ToString(), o.IsReadOnly(_str_idfsAccessionCondition), o.IsInvisible(_str_idfsAccessionCondition), o.IsRequired(_str_idfsAccessionCondition)); }
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
              _name = _str_idfCase, _type = "Int64?",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { o.idfCase = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, "Int64?", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); }
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
              _name = _str_strVectorTypeName, _type = "String",
              _get_func = o => o.strVectorTypeName,
              _set_func = (o, val) => { o.strVectorTypeName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorTypeName != c.strVectorTypeName || o.IsRIRPropChanged(_str_strVectorTypeName, c)) 
                  m.Add(_str_strVectorTypeName, o.ObjectIdent + _str_strVectorTypeName, "String", o.strVectorTypeName == null ? "" : o.strVectorTypeName.ToString(), o.IsReadOnly(_str_strVectorTypeName), o.IsInvisible(_str_strVectorTypeName), o.IsRequired(_str_strVectorTypeName)); }
              }, 
        
            new field_info {
              _name = _str_strVectorSubTypeName, _type = "String",
              _get_func = o => o.strVectorSubTypeName,
              _set_func = (o, val) => { o.strVectorSubTypeName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorSubTypeName != c.strVectorSubTypeName || o.IsRIRPropChanged(_str_strVectorSubTypeName, c)) 
                  m.Add(_str_strVectorSubTypeName, o.ObjectIdent + _str_strVectorSubTypeName, "String", o.strVectorSubTypeName == null ? "" : o.strVectorSubTypeName.ToString(), o.IsReadOnly(_str_strVectorSubTypeName), o.IsInvisible(_str_strVectorSubTypeName), o.IsRequired(_str_strVectorSubTypeName)); }
              }, 
        
            new field_info {
              _name = _str_idfsRegion, _type = "Int64?",
              _get_func = o => o.idfsRegion,
              _set_func = (o, val) => { o.idfsRegion = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_idfsRegion, c)) 
                  m.Add(_str_idfsRegion, o.ObjectIdent + _str_idfsRegion, "Int64?", o.idfsRegion == null ? "" : o.idfsRegion.ToString(), o.IsReadOnly(_str_idfsRegion), o.IsInvisible(_str_idfsRegion), o.IsRequired(_str_idfsRegion)); }
              }, 
        
            new field_info {
              _name = _str_strRegionName, _type = "String",
              _get_func = o => o.strRegionName,
              _set_func = (o, val) => { o.strRegionName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strRegionName != c.strRegionName || o.IsRIRPropChanged(_str_strRegionName, c)) 
                  m.Add(_str_strRegionName, o.ObjectIdent + _str_strRegionName, "String", o.strRegionName == null ? "" : o.strRegionName.ToString(), o.IsReadOnly(_str_strRegionName), o.IsInvisible(_str_strRegionName), o.IsRequired(_str_strRegionName)); }
              }, 
        
            new field_info {
              _name = _str_idfsRayon, _type = "Int64?",
              _get_func = o => o.idfsRayon,
              _set_func = (o, val) => { o.idfsRayon = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_idfsRayon, c)) 
                  m.Add(_str_idfsRayon, o.ObjectIdent + _str_idfsRayon, "Int64?", o.idfsRayon == null ? "" : o.idfsRayon.ToString(), o.IsReadOnly(_str_idfsRayon), o.IsInvisible(_str_idfsRayon), o.IsRequired(_str_idfsRayon)); }
              }, 
        
            new field_info {
              _name = _str_strRayonName, _type = "String",
              _get_func = o => o.strRayonName,
              _set_func = (o, val) => { o.strRayonName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strRayonName != c.strRayonName || o.IsRIRPropChanged(_str_strRayonName, c)) 
                  m.Add(_str_strRayonName, o.ObjectIdent + _str_strRayonName, "String", o.strRayonName == null ? "" : o.strRayonName.ToString(), o.IsReadOnly(_str_strRayonName), o.IsInvisible(_str_strRayonName), o.IsRequired(_str_strRayonName)); }
              }, 
        
            new field_info {
              _name = _str_intQuantity, _type = "Int32",
              _get_func = o => o.intQuantity,
              _set_func = (o, val) => { o.intQuantity = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intQuantity != c.intQuantity || o.IsRIRPropChanged(_str_intQuantity, c)) 
                  m.Add(_str_intQuantity, o.ObjectIdent + _str_intQuantity, "Int32", o.intQuantity == null ? "" : o.intQuantity.ToString(), o.IsReadOnly(_str_intQuantity), o.IsInvisible(_str_intQuantity), o.IsRequired(_str_intQuantity)); }
              }, 
        
            new field_info {
              _name = _str_datCollectionDateTime, _type = "DateTime",
              _get_func = o => o.datCollectionDateTime,
              _set_func = (o, val) => { o.datCollectionDateTime = ParsingHelper.ParseDateTime(val); },
              _compare_func = (o, c, m) => {
                if (o.datCollectionDateTime != c.datCollectionDateTime || o.IsRIRPropChanged(_str_datCollectionDateTime, c)) 
                  m.Add(_str_datCollectionDateTime, o.ObjectIdent + _str_datCollectionDateTime, "DateTime", o.datCollectionDateTime == null ? "" : o.datCollectionDateTime.ToString(), o.IsReadOnly(_str_datCollectionDateTime), o.IsInvisible(_str_datCollectionDateTime), o.IsRequired(_str_datCollectionDateTime)); }
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
              _name = _str_Used, _type = "Int32",
              _get_func = o => o.Used,
              _set_func = (o, val) => { o.Used = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.Used != c.Used || o.IsRIRPropChanged(_str_Used, c)) 
                  m.Add(_str_Used, o.ObjectIdent + _str_Used, "Int32", o.Used == null ? "" : o.Used.ToString(), o.IsReadOnly(_str_Used), o.IsInvisible(_str_Used), o.IsRequired(_str_Used)); }
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
              _name = _str_isPool, _type = "bool",
              _get_func = o => o.isPool,
              _set_func = (o, val) => { o.isPool = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.isPool != c.isPool || o.IsRIRPropChanged(_str_isPool, c)) 
                  m.Add(_str_isPool, o.ObjectIdent + _str_isPool, "bool", o.isPool == null ? "" : o.isPool.ToString(), o.IsReadOnly(_str_isPool), o.IsInvisible(_str_isPool), o.IsRequired(_str_isPool));
                 }
              }, 
        
            new field_info {
              _name = _str_isJustCreated, _type = "bool",
              _get_func = o => o.isJustCreated,
              _set_func = (o, val) => { o.isJustCreated = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.isJustCreated != c.isJustCreated || o.IsRIRPropChanged(_str_isJustCreated, c)) 
                  m.Add(_str_isJustCreated, o.ObjectIdent + _str_isJustCreated, "bool", o.isJustCreated == null ? "" : o.isJustCreated.ToString(), o.IsReadOnly(_str_isJustCreated), o.IsInvisible(_str_isJustCreated), o.IsRequired(_str_isJustCreated));
                 }
              }, 
        
            new field_info {
              _name = _str_SessionSamples, _type = "EditableList<VectorSample>",
              _get_func = o => o.SessionSamples,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_FieldTests, _type = "EditableList<VectorFieldTest>",
              _get_func = o => o.FieldTests,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_Vectors, _type = "EditableList<Vector>",
              _get_func = o => o.Vectors,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_LabTests, _type = "EditableList<VectorLabTest>",
              _get_func = o => o.LabTests,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_ParentVector, _type = "Vector",
              _get_func = o => o.ParentVector,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_CanChangeParentVector, _type = "bool",
              _get_func = o => o.CanChangeParentVector,
              _set_func = (o, val) => { o.CanChangeParentVector = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.CanChangeParentVector != c.CanChangeParentVector || o.IsRIRPropChanged(_str_CanChangeParentVector, c)) 
                  m.Add(_str_CanChangeParentVector, o.ObjectIdent + _str_CanChangeParentVector, "bool", o.CanChangeParentVector == null ? "" : o.CanChangeParentVector.ToString(), o.IsReadOnly(_str_CanChangeParentVector), o.IsInvisible(_str_CanChangeParentVector), o.IsRequired(_str_CanChangeParentVector));
                 }
              }, 
        
            new field_info {
              _name = _str_strFieldCollectedByOffice, _type = "string",
              _get_func = o => o.strFieldCollectedByOffice,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strFieldCollectedByOffice != c.strFieldCollectedByOffice || o.IsRIRPropChanged(_str_strFieldCollectedByOffice, c)) 
                  m.Add(_str_strFieldCollectedByOffice, o.ObjectIdent + _str_strFieldCollectedByOffice, "string", o.strFieldCollectedByOffice == null ? "" : o.strFieldCollectedByOffice.ToString(), o.IsReadOnly(_str_strFieldCollectedByOffice), o.IsInvisible(_str_strFieldCollectedByOffice), o.IsRequired(_str_strFieldCollectedByOffice));
                 }
              }, 
        
            new field_info {
              _name = _str_FieldCollectedByOffice, _type = "Lookup",
              _get_func = o => { if (o.FieldCollectedByOffice == null) return null; return o.FieldCollectedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.FieldCollectedByOffice = o.FieldCollectedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfFieldCollectedByOffice != c.idfFieldCollectedByOffice || o.IsRIRPropChanged(_str_FieldCollectedByOffice, c)) 
                  m.Add(_str_FieldCollectedByOffice, o.ObjectIdent + _str_FieldCollectedByOffice, "Lookup", o.idfFieldCollectedByOffice == null ? "" : o.idfFieldCollectedByOffice.ToString(), o.IsReadOnly(_str_FieldCollectedByOffice), o.IsInvisible(_str_FieldCollectedByOffice), o.IsRequired(_str_FieldCollectedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_AccessionCondition, _type = "Lookup",
              _get_func = o => { if (o.AccessionCondition == null) return null; return o.AccessionCondition.idfsBaseReference; },
              _set_func = (o, val) => { o.AccessionCondition = o.AccessionConditionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAccessionCondition != c.idfsAccessionCondition || o.IsRIRPropChanged(_str_AccessionCondition, c)) 
                  m.Add(_str_AccessionCondition, o.ObjectIdent + _str_AccessionCondition, "Lookup", o.idfsAccessionCondition == null ? "" : o.idfsAccessionCondition.ToString(), o.IsReadOnly(_str_AccessionCondition), o.IsInvisible(_str_AccessionCondition), o.IsRequired(_str_AccessionCondition)); }
              }, 
        
            new field_info {
              _name = _str_VectorType, _type = "Lookup",
              _get_func = o => { if (o.VectorType == null) return null; return o.VectorType.idfsBaseReference; },
              _set_func = (o, val) => { o.VectorType = o.VectorTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_VectorType, c)) 
                  m.Add(_str_VectorType, o.ObjectIdent + _str_VectorType, "Lookup", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_VectorType), o.IsInvisible(_str_VectorType), o.IsRequired(_str_VectorType)); }
              }, 
        
            new field_info {
              _name = _str_VectorSubType, _type = "Lookup",
              _get_func = o => { if (o.VectorSubType == null) return null; return o.VectorSubType.idfsBaseReference; },
              _set_func = (o, val) => { o.VectorSubType = o.VectorSubTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_VectorSubType, c)) 
                  m.Add(_str_VectorSubType, o.ObjectIdent + _str_VectorSubType, "Lookup", o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(), o.IsReadOnly(_str_VectorSubType), o.IsInvisible(_str_VectorSubType), o.IsRequired(_str_VectorSubType)); }
              }, 
        
            new field_info {
              _name = _str_Region, _type = "Lookup",
              _get_func = o => { if (o.Region == null) return null; return o.Region.idfsRegion; },
              _set_func = (o, val) => { o.Region = o.RegionLookup.Where(c => c.idfsRegion.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_Region, c)) 
                  m.Add(_str_Region, o.ObjectIdent + _str_Region, "Lookup", o.idfsRegion == null ? "" : o.idfsRegion.ToString(), o.IsReadOnly(_str_Region), o.IsInvisible(_str_Region), o.IsRequired(_str_Region)); }
              }, 
        
            new field_info {
              _name = _str_Rayon, _type = "Lookup",
              _get_func = o => { if (o.Rayon == null) return null; return o.Rayon.idfsRayon; },
              _set_func = (o, val) => { o.Rayon = o.RayonLookup.Where(c => c.idfsRayon.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_Rayon, c)) 
                  m.Add(_str_Rayon, o.ObjectIdent + _str_Rayon, "Lookup", o.idfsRayon == null ? "" : o.idfsRayon.ToString(), o.IsReadOnly(_str_Rayon), o.IsInvisible(_str_Rayon), o.IsRequired(_str_Rayon)); }
              }, 
        
            new field_info {
              _name = _str_SampleTypesMatrix, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.SampleTypesMatrix.Count != c.SampleTypesMatrix.Count || o.IsReadOnly(_str_SampleTypesMatrix) != c.IsReadOnly(_str_SampleTypesMatrix) || o.IsInvisible(_str_SampleTypesMatrix) != c.IsInvisible(_str_SampleTypesMatrix) || o.IsRequired(_str_SampleTypesMatrix) != c.IsRequired(_str_SampleTypesMatrix)) 
                  m.Add(_str_SampleTypesMatrix, o.ObjectIdent + _str_SampleTypesMatrix, "Child", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_SampleTypesMatrix), o.IsInvisible(_str_SampleTypesMatrix), o.IsRequired(_str_SampleTypesMatrix)); }
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
            VectorSample obj = (VectorSample)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(VectorType2SampleTypeLookup), "", _str_idfsVectorType)]
        public EditableList<VectorType2SampleTypeLookup> SampleTypesMatrix
        {
            get 
            {   
                return _SampleTypesMatrix; 
            }
            set 
            {
                _SampleTypesMatrix = value;
            }
        }
        protected EditableList<VectorType2SampleTypeLookup> _SampleTypesMatrix = new EditableList<VectorType2SampleTypeLookup>();
                    
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfFieldCollectedByOffice)]
        public OrganizationLookup FieldCollectedByOffice
        {
            get { return _FieldCollectedByOffice == null ? null : ((long)_FieldCollectedByOffice.Key == 0 ? null : _FieldCollectedByOffice); }
            set 
            { 
                _FieldCollectedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfFieldCollectedByOffice = _FieldCollectedByOffice == null 
                    ? new Int64?()
                    : _FieldCollectedByOffice.idfInstitution; 
                OnPropertyChanged(_str_FieldCollectedByOffice); 
            }
        }
        private OrganizationLookup _FieldCollectedByOffice;

        
        public List<OrganizationLookup> FieldCollectedByOfficeLookup
        {
            get { return _FieldCollectedByOfficeLookup; }
        }
        private List<OrganizationLookup> _FieldCollectedByOfficeLookup = new List<OrganizationLookup>();
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAccessionCondition)]
        public BaseReference AccessionCondition
        {
            get { return _AccessionCondition == null ? null : ((long)_AccessionCondition.Key == 0 ? null : _AccessionCondition); }
            set 
            { 
                _AccessionCondition = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAccessionCondition = _AccessionCondition == null 
                    ? new Int64?()
                    : _AccessionCondition.idfsBaseReference; 
                OnPropertyChanged(_str_AccessionCondition); 
            }
        }
        private BaseReference _AccessionCondition;

        
        public BaseReferenceList AccessionConditionLookup
        {
            get { return _AccessionConditionLookup; }
        }
        private BaseReferenceList _AccessionConditionLookup = new BaseReferenceList("rftAccessionCondition");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsVectorType)]
        public BaseReference VectorType
        {
            get { return _VectorType == null ? null : ((long)_VectorType.Key == 0 ? null : _VectorType); }
            set 
            { 
                _VectorType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsVectorType = _VectorType == null 
                    ? new Int64()
                    : _VectorType.idfsBaseReference; 
                OnPropertyChanged(_str_VectorType); 
            }
        }
        private BaseReference _VectorType;

        
        public BaseReferenceList VectorTypeLookup
        {
            get { return _VectorTypeLookup; }
        }
        private BaseReferenceList _VectorTypeLookup = new BaseReferenceList("rftVectorType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsVectorSubType)]
        public BaseReference VectorSubType
        {
            get { return _VectorSubType == null ? null : ((long)_VectorSubType.Key == 0 ? null : _VectorSubType); }
            set 
            { 
                _VectorSubType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsVectorSubType = _VectorSubType == null 
                    ? new Int64()
                    : _VectorSubType.idfsBaseReference; 
                OnPropertyChanged(_str_VectorSubType); 
            }
        }
        private BaseReference _VectorSubType;

        
        public BaseReferenceList VectorSubTypeLookup
        {
            get { return _VectorSubTypeLookup; }
        }
        private BaseReferenceList _VectorSubTypeLookup = new BaseReferenceList("rftVectorSubType");
            
        [Relation(typeof(RegionLookup), eidss.model.Schema.RegionLookup._str_idfsRegion, _str_idfsRegion)]
        public RegionLookup Region
        {
            get { return _Region == null ? null : ((long)_Region.Key == 0 ? null : _Region); }
            set 
            { 
                _Region = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsRegion = _Region == null 
                    ? new Int64?()
                    : _Region.idfsRegion; 
                OnPropertyChanged(_str_Region); 
            }
        }
        private RegionLookup _Region;

        
        public List<RegionLookup> RegionLookup
        {
            get { return _RegionLookup; }
        }
        private List<RegionLookup> _RegionLookup = new List<RegionLookup>();
            
        [Relation(typeof(RayonLookup), eidss.model.Schema.RayonLookup._str_idfsRayon, _str_idfsRayon)]
        public RayonLookup Rayon
        {
            get { return _Rayon == null ? null : ((long)_Rayon.Key == 0 ? null : _Rayon); }
            set 
            { 
                _Rayon = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsRayon = _Rayon == null 
                    ? new Int64?()
                    : _Rayon.idfsRayon; 
                OnPropertyChanged(_str_Rayon); 
            }
        }
        private RayonLookup _Rayon;

        
        public List<RayonLookup> RayonLookup
        {
            get { return _RayonLookup; }
        }
        private List<RayonLookup> _RayonLookup = new List<RayonLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_FieldCollectedByOffice:
                    return new BvSelectList(FieldCollectedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, FieldCollectedByOffice, _str_idfFieldCollectedByOffice);
            
                case _str_AccessionCondition:
                    return new BvSelectList(AccessionConditionLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AccessionCondition, _str_idfsAccessionCondition);
            
                case _str_VectorType:
                    return new BvSelectList(VectorTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, VectorType, _str_idfsVectorType);
            
                case _str_VectorSubType:
                    return new BvSelectList(VectorSubTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, VectorSubType, _str_idfsVectorSubType);
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionLookup._str_idfsRegion, null, Region, _str_idfsRegion);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonLookup._str_idfsRayon, null, Rayon, _str_idfsRayon);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strFieldCollectedByOffice)]
        public string strFieldCollectedByOffice
        {
            get { return new Func<VectorSample, string>(c => c.FieldCollectedByOffice == null ? String.Empty : c.FieldCollectedByOffice.name)(this); }
            
        }
        
          [LocalizedDisplayName(_str_NewObject)]
        public bool NewObject
        {
            get { return m_NewObject; }
            set { if (m_NewObject != value) { m_NewObject = value; OnPropertyChanged(_str_NewObject); } }
        }
        private bool m_NewObject;
        
          [LocalizedDisplayName(_str_isPool)]
        public bool isPool
        {
            get { return m_isPool; }
            set { if (m_isPool != value) { m_isPool = value; OnPropertyChanged(_str_isPool); } }
        }
        private bool m_isPool;
        
          [LocalizedDisplayName(_str_isJustCreated)]
        public bool isJustCreated
        {
            get { return m_isJustCreated; }
            set { if (m_isJustCreated != value) { m_isJustCreated = value; OnPropertyChanged(_str_isJustCreated); } }
        }
        private bool m_isJustCreated;
        
          [LocalizedDisplayName(_str_SessionSamples)]
        public EditableList<VectorSample> SessionSamples
        {
            get { return m_SessionSamples; }
            set { if (m_SessionSamples != value) { m_SessionSamples = value; OnPropertyChanged(_str_SessionSamples); } }
        }
        private EditableList<VectorSample> m_SessionSamples;
        
          [LocalizedDisplayName(_str_FieldTests)]
        public EditableList<VectorFieldTest> FieldTests
        {
            get { return m_FieldTests; }
            set { if (m_FieldTests != value) { m_FieldTests = value; OnPropertyChanged(_str_FieldTests); } }
        }
        private EditableList<VectorFieldTest> m_FieldTests;
        
          [LocalizedDisplayName(_str_Vectors)]
        public EditableList<Vector> Vectors
        {
            get { return m_Vectors; }
            set { if (m_Vectors != value) { m_Vectors = value; OnPropertyChanged(_str_Vectors); } }
        }
        private EditableList<Vector> m_Vectors;
        
          [LocalizedDisplayName(_str_LabTests)]
        public EditableList<VectorLabTest> LabTests
        {
            get { return m_LabTests; }
            set { if (m_LabTests != value) { m_LabTests = value; OnPropertyChanged(_str_LabTests); } }
        }
        private EditableList<VectorLabTest> m_LabTests;
        
          [LocalizedDisplayName(_str_ParentVector)]
        public Vector ParentVector
        {
            get { return m_ParentVector; }
            set { if (m_ParentVector != value) { m_ParentVector = value; OnPropertyChanged(_str_ParentVector); } }
        }
        private Vector m_ParentVector;
        
          [LocalizedDisplayName(_str_CanChangeParentVector)]
        public bool CanChangeParentVector
        {
            get { return m_CanChangeParentVector; }
            set { if (m_CanChangeParentVector != value) { m_CanChangeParentVector = value; OnPropertyChanged(_str_CanChangeParentVector); } }
        }
        private bool m_CanChangeParentVector;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VectorSample";

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
        SampleTypesMatrix.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as VectorSample;
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
            var ret = base.Clone() as VectorSample;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public VectorSample CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VectorSample;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfMaterial; } }
        public string KeyName { get { return "idfMaterial"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || SampleTypesMatrix.IsDirty
                    || SampleTypesMatrix.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfFieldCollectedByOffice_FieldCollectedByOffice = idfFieldCollectedByOffice;
            var _prev_idfsAccessionCondition_AccessionCondition = idfsAccessionCondition;
            var _prev_idfsVectorType_VectorType = idfsVectorType;
            var _prev_idfsVectorSubType_VectorSubType = idfsVectorSubType;
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            base.RejectChanges();
        
            if (_prev_idfFieldCollectedByOffice_FieldCollectedByOffice != idfFieldCollectedByOffice)
            {
                _FieldCollectedByOffice = _FieldCollectedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfFieldCollectedByOffice);
            }
            if (_prev_idfsAccessionCondition_AccessionCondition != idfsAccessionCondition)
            {
                _AccessionCondition = _AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAccessionCondition);
            }
            if (_prev_idfsVectorType_VectorType != idfsVectorType)
            {
                _VectorType = _VectorTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorType);
            }
            if (_prev_idfsVectorSubType_VectorSubType != idfsVectorSubType)
            {
                _VectorSubType = _VectorSubTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorSubType);
            }
            if (_prev_idfsRegion_Region != idfsRegion)
            {
                _Region = _RegionLookup.FirstOrDefault(c => c.idfsRegion == idfsRegion);
            }
            if (_prev_idfsRayon_Rayon != idfsRayon)
            {
                _Rayon = _RayonLookup.FirstOrDefault(c => c.idfsRayon == idfsRayon);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        SampleTypesMatrix.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        SampleTypesMatrix.AcceptChanges();
                
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
        SampleTypesMatrix.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, VectorSample c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public VectorSample()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VectorSample_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VectorSample_PropertyChanged);
        }
        private void VectorSample_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VectorSample).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfFieldCollectedByOffice)
                OnPropertyChanged(_str_strFieldCollectedByOffice);
                  
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
            VectorSample obj = this;
            try
            {
            
                CheckCanDelete(obj);
            
            }
            catch(ValidationModelException ex)
            {
                if (bReport && !OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                {
                    OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                }
                
                return false;
            }
            
            return Accessor.Instance(null).ValidateCanDelete(this);
              
        }
        private void _DeletingExtenders()
        {
            VectorSample obj = this;
            
                  var fieldTests = FieldTests.Where(ft => ft.idfMaterial == idfMaterial).ToList();
                  foreach(var ft in fieldTests)
                  {
                    ft.MarkToDelete();
                  }
                
        }
        private void _DeletedExtenders()
        {
            VectorSample obj = this;
            
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

    
        private static string[] readonly_names1 = "datFieldCollectionDate,idfFieldCollectedByOffice".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "datAccession,idfsAccessionCondition,strFieldBarcode,idfVector,idfsVectorType,strVectorSubTypeName".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "idfsSpecimenType".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VectorSample, bool>(c => c.isPool || c.Used == 1)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VectorSample, bool>(c => false || c.Used == 1)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VectorSample, bool>(c => (c.isPool && (c.SampleTypesMatrix.Count(s => s.idfsVectorType == c.idfsVectorType) <= 1)))(this);
            
            return ReadOnly || new Func<VectorSample, bool>(c => true)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _SampleTypesMatrix)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<VectorSample, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VectorSample, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VectorSample, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<VectorSample, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<VectorSample, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<VectorSample, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VectorSample()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("rftAccessionCondition", this);
                
                LookupManager.RemoveObject("rftVectorType", this);
                
                LookupManager.RemoveObject("rftVectorSubType", this);
                
                LookupManager.RemoveObject("RegionLookup", this);
                
                LookupManager.RemoveObject("RayonLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_FieldCollectedByOffice(manager, this);
            
            if (lookup_object == "rftAccessionCondition")
                _getAccessor().LoadLookup_AccessionCondition(manager, this);
            
            if (lookup_object == "rftVectorType")
                _getAccessor().LoadLookup_VectorType(manager, this);
            
            if (lookup_object == "rftVectorSubType")
                _getAccessor().LoadLookup_VectorSubType(manager, this);
            
            if (lookup_object == "RegionLookup")
                _getAccessor().LoadLookup_Region(manager, this);
            
            if (lookup_object == "RayonLookup")
                _getAccessor().LoadLookup_Rayon(manager, this);
            
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
        
            if (_SampleTypesMatrix != null) _SampleTypesMatrix.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    
        #region Class for web grid
        public class VectorSampleGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfMaterial { get; set; }
        
            public long? idfVector { get; set; }
        
            public String strBarcode { get; set; }
        
            public String strFieldBarcode { get; set; }
        
            public long? idfsVectorType { get; set; }
        
            public String strVectorSubTypeName { get; set; }
        
            public Int64 idfsSpecimenType { get; set; }
        
            public DateTime? datFieldCollectionDate { get; set; }
        
            public Int64? idfFieldCollectedByOffice { get; set; }
        
            public string strNote { get; set; }
        
            public DateTime? datAccession { get; set; }
        
            public Int64? idfsAccessionCondition { get; set; }
        
        }
        public partial class VectorSampleGridModelList : List<VectorSampleGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public VectorSampleGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VectorSample>, errMes);
            }
            public VectorSampleGridModelList(long key, IEnumerable<VectorSample> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<VectorSample> items);
            private void LoadGridModelList(long key, IEnumerable<VectorSample> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_idfVector,_str_strBarcode,_str_strFieldBarcode,_str_idfsVectorType,_str_strVectorSubTypeName,_str_idfsSpecimenType,_str_datFieldCollectionDate,_str_idfFieldCollectedByOffice,_str_strNote,_str_datAccession,_str_idfsAccessionCondition};
                    
                Hiddens = new List<string> {_str_idfMaterial};
                Keys = new List<string> {_str_idfMaterial};
                Labels = new Dictionary<string, string> {{_str_idfVector, "Vector.strVectorID"},{_str_strBarcode, "VectorSample.strBarcode"},{_str_strFieldBarcode, "VectorSample.strFieldBarcode"},{_str_idfsVectorType, _str_idfsVectorType},{_str_strVectorSubTypeName, "idfsVectorSubType"},{_str_idfsSpecimenType, _str_idfsSpecimenType},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_idfFieldCollectedByOffice, "VectorSample.idfFieldCollectedByOffice"},{_str_strNote, "VectorSample.strNote"},{_str_datAccession, _str_datAccession},{_str_idfsAccessionCondition, _str_idfsAccessionCondition}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<VectorSample>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VectorSampleGridModel()
                {
                    ItemKey=c.idfMaterial,idfVector=c.idfVector,strBarcode=c.strBarcode,strFieldBarcode=c.strFieldBarcode,idfsVectorType=c.idfsVectorType,strVectorSubTypeName=c.strVectorSubTypeName,idfsSpecimenType=c.idfsSpecimenType,datFieldCollectionDate=c.datFieldCollectionDate,idfFieldCollectedByOffice=c.idfFieldCollectedByOffice,strNote=c.strNote,datAccession=c.datAccession,idfsAccessionCondition=c.idfsAccessionCondition
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
        : DataAccessor<VectorSample>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(VectorSample obj);
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
            private VectorType2SampleTypeLookup.Accessor SampleTypesMatrixAccessor { get { return eidss.model.Schema.VectorType2SampleTypeLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor FieldCollectedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AccessionConditionAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor VectorTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor VectorSubTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private RegionLookup.Accessor RegionAccessor { get { return eidss.model.Schema.RegionLookup.Accessor.Instance(m_CS); } }
            private RayonLookup.Accessor RayonAccessor { get { return eidss.model.Schema.RayonLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<VectorSample> SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                )
            {
                return _SelectList(manager
                    , idfVectorSurveillanceSession
                    , delegate(VectorSample obj)
                        {
                        }
                    , delegate(VectorSample obj)
                        {
                        }
                    );
            }

            
            private List<VectorSample> _SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VectorSample> objs = new List<VectorSample>();
                    sets[0] = new MapResultSet(typeof(VectorSample), objs);
                    
                    manager
                        .SetSpCommand("spVectorSamples_SelectDetail"
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
    
            private void _SetupAddChildHandlerSampleTypesMatrix(VectorSample obj)
            {
                obj.SampleTypesMatrix.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadSampleTypesMatrix(VectorSample obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSampleTypesMatrix(manager, obj);
                }
            }
            internal void _LoadSampleTypesMatrix(DbManagerProxy manager, VectorSample obj)
            {
                
                obj.SampleTypesMatrix.Clear();
                obj.SampleTypesMatrix.AddRange(SampleTypesMatrixAccessor.SelectDetailList(manager
                    
                    , obj.idfsVectorType
                    ));
                obj.SampleTypesMatrix.ForEach(c => c.m_ObjectName = _str_SampleTypesMatrix);
                obj.SampleTypesMatrix.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, VectorSample obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadSampleTypesMatrix(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.CanChangeParentVector = new Func<VectorSample, bool>(c => false)(obj);
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerSampleTypesMatrix(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, VectorSample obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.SampleTypesMatrix.ForEach(c => SampleTypesMatrixAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private VectorSample _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    VectorSample obj = VectorSample.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfMaterial = (new GetNewIDExtender<VectorSample>()).GetScalar(manager, obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerSampleTypesMatrix(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.idfMaterial = new Func<VectorSample, DbManagerProxy, long>((c,m) => { _LoadSampleTypesMatrix(m,c); return c.idfMaterial; })(obj, manager);
                obj.CanChangeParentVector = new Func<VectorSample, bool>(c => true)(obj);
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

            
            public VectorSample CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public VectorSample CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public VectorSample CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is Vector)) 
                    throw new TypeMismatchException("parentVector", typeof(Vector));
                if (pars[1] != null && !(pars[1] is long?)) 
                    throw new TypeMismatchException("idfsSpecimenType", typeof(long?));
                
                return Create(manager, Parent
                    , (Vector)pars[0]
                    , (long?)pars[1]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public VectorSample Create(DbManagerProxy manager, IObject Parent
                , Vector parentVector
                , long? idfsSpecimenType
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.ParentVector = new Func<VectorSample, Vector>(c => parentVector)(obj);
                obj.idfVector = new Func<VectorSample, long>(c => parentVector.idfVector)(obj);
                obj.idfParty = new Func<VectorSample, long>(c => parentVector.idfVector)(obj);
                obj.isPool = new Func<VectorSample, bool>(c => parentVector.IsPoolVectorType)(obj);
                obj.idfVectorSurveillanceSession = new Func<VectorSample, long>(c => parentVector.idfVectorSurveillanceSession)(obj);
                obj.idfsVectorType = new Func<VectorSample, long>(c => parentVector.idfsVectorType)(obj);
                obj.idfsSpecimenType = new Func<VectorSample, long>(c => idfsSpecimenType.HasValue ? idfsSpecimenType.Value != 0 ? idfsSpecimenType.Value : c.idfsSpecimenType : c.idfsSpecimenType)(obj);
                obj.SessionSamples = new Func<VectorSample, EditableList<VectorSample>>(c => parentVector.Samples)(obj);
                obj.FieldTests = new Func<VectorSample, EditableList<VectorFieldTest>>(c => parentVector.FieldTests)(obj);
                obj.Vectors = new Func<VectorSample, EditableList<Vector>>(c => parentVector.Vectors)(obj);
                obj.LabTests = new Func<VectorSample, EditableList<VectorLabTest>>(c => parentVector.LabTests)(obj);
                obj.idfsVectorSubType = new Func<VectorSample, long>(c => parentVector.idfsVectorSubType)(obj);
                }
                    , obj =>
                {
                obj.datFieldCollectionDate = new Func<VectorSample, DateTime?>(c => c.isPool ? parentVector.datCollectionDateTime : DateTime.Now.Date)(obj);
                obj.idfFieldCollectedByOffice = new Func<VectorSample, long?>(c => c.isPool ? parentVector.idfCollectedByOffice : c.idfFieldCollectedByOffice)(obj);
                obj.isJustCreated = new Func<VectorSample, bool>(c => true)(obj);
                obj.strVectorSubTypeName = new Func<VectorSample, string>(c => parentVector.strSpecies)(obj);
                obj.strVectorID = new Func<VectorSample, string>(c => parentVector.strVectorID)(obj);
                }
                );
            }
            
            private void _SetupChildHandlers(VectorSample obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VectorSample obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfVector)
                        {
                    
                obj.idfParty = new Func<VectorSample, long>(c => c.idfVector.HasValue ? c.idfVector.Value : c.idfParty.Value)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                obj.strVectorTypeName = new Func<VectorSample, string>(c => c.VectorType == null ? "" : c.VectorType.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorSubType)
                        {
                    
                obj.strVectorSubTypeName = new Func<VectorSample, string>(c => c.VectorSubType == null ? "" : c.VectorSubType.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.strRegionName = new Func<VectorSample, string>(c => c.Region == null ? "" : c.Region.strRegionName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                obj.strRayonName = new Func<VectorSample, string>(c => c.Rayon == null ? "" : c.Rayon.strRayonName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSpecimenType)
                        {
                    
                  var matrix = obj.SampleTypesMatrix.FirstOrDefault(m => m.idfsSampleType == obj.idfsSpecimenType);
                  if (matrix != null) obj.strSpecimenName = matrix.SampleName;
                
                        }
                    
                    };
                
            }
    
            public void LoadLookup_FieldCollectedByOffice(DbManagerProxy manager, VectorSample obj)
            {
                
                obj.FieldCollectedByOfficeLookup.Clear();
                
                obj.FieldCollectedByOfficeLookup.Add(FieldCollectedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.FieldCollectedByOfficeLookup.AddRange(FieldCollectedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfFieldCollectedByOffice))
                    
                    .ToList());
                
                if (obj.idfFieldCollectedByOffice != null && obj.idfFieldCollectedByOffice != 0)
                {
                    obj.FieldCollectedByOffice = obj.FieldCollectedByOfficeLookup
                        .Where(c => c.idfInstitution == obj.idfFieldCollectedByOffice)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("OrganizationLookup", obj, FieldCollectedByOfficeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_AccessionCondition(DbManagerProxy manager, VectorSample obj)
            {
                
                obj.AccessionConditionLookup.Clear();
                
                obj.AccessionConditionLookup.Add(AccessionConditionAccessor.CreateNewT(manager, null));
                
                obj.AccessionConditionLookup.AddRange(AccessionConditionAccessor.rftAccessionCondition_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAccessionCondition))
                    
                    .ToList());
                
                if (obj.idfsAccessionCondition != null && obj.idfsAccessionCondition != 0)
                {
                    obj.AccessionCondition = obj.AccessionConditionLookup
                        .Where(c => c.idfsBaseReference == obj.idfsAccessionCondition)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftAccessionCondition", obj, AccessionConditionAccessor.GetType(), "rftAccessionCondition_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_VectorType(DbManagerProxy manager, VectorSample obj)
            {
                
                obj.VectorTypeLookup.Clear();
                
                obj.VectorTypeLookup.Add(VectorTypeAccessor.CreateNewT(manager, null));
                
                obj.VectorTypeLookup.AddRange(VectorTypeAccessor.rftVectorType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorType))
                    
                    .ToList());
                
                if (obj.idfsVectorType != 0)
                {
                    obj.VectorType = obj.VectorTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsVectorType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftVectorType", obj, VectorTypeAccessor.GetType(), "rftVectorType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_VectorSubType(DbManagerProxy manager, VectorSample obj)
            {
                
                obj.VectorSubTypeLookup.Clear();
                
                obj.VectorSubTypeLookup.Add(VectorSubTypeAccessor.CreateNewT(manager, null));
                
                obj.VectorSubTypeLookup.AddRange(VectorSubTypeAccessor.rftVectorSubType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorSubType))
                    
                    .ToList());
                
                if (obj.idfsVectorSubType != 0)
                {
                    obj.VectorSubType = obj.VectorSubTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsVectorSubType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftVectorSubType", obj, VectorSubTypeAccessor.GetType(), "rftVectorSubType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Region(DbManagerProxy manager, VectorSample obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<VectorSample, long>(c => eidss.model.Core.EidssSiteContext.Instance.CountryID)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRegion == obj.idfsRegion))
                    
                    .ToList());
                
                if (obj.idfsRegion != null && obj.idfsRegion != 0)
                {
                    obj.Region = obj.RegionLookup
                        .Where(c => c.idfsRegion == obj.idfsRegion)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("RegionLookup", obj, RegionAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Rayon(DbManagerProxy manager, VectorSample obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<VectorSample, long>(c => c.idfsRegion ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRayon == obj.idfsRayon))
                    
                    .ToList());
                
                if (obj.idfsRayon != null && obj.idfsRayon != 0)
                {
                    obj.Rayon = obj.RayonLookup
                        .Where(c => c.idfsRayon == obj.idfsRayon)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("RayonLookup", obj, RayonAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, VectorSample obj)
            {
                
                LoadLookup_FieldCollectedByOffice(manager, obj);
                
                LoadLookup_AccessionCondition(manager, obj);
                
                LoadLookup_VectorType(manager, obj);
                
                LoadLookup_VectorSubType(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
            }
    
            [SprocName("spVectorSample_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? idfMaterial, out Boolean Result
                );
        
            [SprocName("spLabSample_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? idfMaterial
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? idfMaterial
                )
            {
                
                _postDelete(manager, idfMaterial);
                
            }
        
            [SprocName("spLabSample_Create")]
            protected abstract void _postInsert(DbManagerProxy manager, 
                [Direction.InputOutput("idfMaterial")] VectorSample obj);
            protected void _postInsertPredicate(DbManagerProxy manager, 
                [Direction.InputOutput("idfMaterial")] VectorSample obj)
            {
                
                _postInsert(manager, obj);
                
            }
        
            [SprocName("spLabSample_Update")]
            protected abstract void _postUpdate(DbManagerProxy manager, 
                [Direction.InputOutput()] VectorSample obj);
            protected void _postUpdatePredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] VectorSample obj)
            {
                
                _postUpdate(manager, obj);
                
            }
        
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    VectorSample bo = obj as VectorSample;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as VectorSample, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VectorSample obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfMaterial
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postInsertPredicate(manager, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postUpdatePredicate(manager, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(VectorSample obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VectorSample obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfMaterial
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
                return Validate(manager, obj as VectorSample, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VectorSample obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "strFieldBarcode", "strFieldBarcode","VectorSample.strFieldBarcode",
                false
              )).Validate(c => true, obj, obj.strFieldBarcode);
            
                (new RequiredValidator( "idfsSpecimenType", "idfsSpecimenType","",
                false
              )).Validate(c => true, obj, obj.idfsSpecimenType);
            
                (new RequiredValidator( "idfParty", "idfParty","",
                false
              )).Validate(c => true, obj, obj.idfParty);
            
                CustomValidations(obj);
            
                  
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
           
    
            private void _SetupRequired(VectorSample obj)
            {
            
                obj
                    .AddRequired("strFieldBarcode", c => true);
                    
                obj
                    .AddRequired("idfsSpecimenType", c => true);
                    
                obj
                    .AddRequired("idfParty", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(VectorSample obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VectorSample) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VectorSample) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VectorSampleDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spVectorSamples_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "spLabSample_Create";
            public static string spUpdate = "spLabSample_Update";
            public static string spDelete = "spLabSample_Delete";
            public static string spCanDelete = "spVectorSample_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VectorSample, bool>> RequiredByField = new Dictionary<string, Func<VectorSample, bool>>();
            public static Dictionary<string, Func<VectorSample, bool>> RequiredByProperty = new Dictionary<string, Func<VectorSample, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strSpecimenName, 2000);
                Sizes.Add(_str_strNote, 500);
                Sizes.Add(_str_strVectorTypeName, 2000);
                Sizes.Add(_str_strVectorSubTypeName, 2000);
                Sizes.Add(_str_strRegionName, 300);
                Sizes.Add(_str_strRayonName, 300);
                Sizes.Add(_str_strVectorID, 50);
                if (!RequiredByField.ContainsKey("strFieldBarcode")) RequiredByField.Add("strFieldBarcode", c => true);
                if (!RequiredByProperty.ContainsKey("strFieldBarcode")) RequiredByProperty.Add("strFieldBarcode", c => true);
                
                if (!RequiredByField.ContainsKey("idfsSpecimenType")) RequiredByField.Add("idfsSpecimenType", c => true);
                if (!RequiredByProperty.ContainsKey("idfsSpecimenType")) RequiredByProperty.Add("idfsSpecimenType", c => true);
                
                if (!RequiredByField.ContainsKey("idfParty")) RequiredByField.Add("idfParty", c => true);
                if (!RequiredByProperty.ContainsKey("idfParty")) RequiredByProperty.Add("idfParty", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfMaterial,
                    _str_idfMaterial, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfVector,
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
                    _str_idfsVectorType,
                    _str_idfsVectorType, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorSubTypeName,
                    "idfsVectorSubType", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsSpecimenType,
                    _str_idfsSpecimenType, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfFieldCollectedByOffice,
                    "VectorSample.idfFieldCollectedByOffice", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNote,
                    "VectorSample.strNote", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datAccession,
                    _str_datAccession, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsAccessionCondition,
                    _str_idfsAccessionCondition, null, true, true, null
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
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
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
                    (manager, c, pars) => ((VectorSample)c).MarkToDelete(),
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
	