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
    public abstract partial class VectorSample : 
        EditableObject<VectorSample>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
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
                
        [LocalizedDisplayName(_str_idfsVectorSubType)]
        [MapField(_str_idfsVectorSubType)]
        public abstract Int64 idfsVectorSubType { get; set; }
        protected Int64 idfsVectorSubType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSubType).OriginalValue; } }
        protected Int64 idfsVectorSubType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSubType).PreviousValue; } }
                
        [MapField(_str_idfMaterial), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMaterial { get; set; }
                
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
                
        [LocalizedDisplayName(_str_strSampleName)]
        [MapField(_str_strSampleName)]
        public abstract String strSampleName { get; set; }
        protected String strSampleName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).OriginalValue; } }
        protected String strSampleName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFieldCollectionDate)]
        [MapField(_str_datFieldCollectionDate)]
        public abstract DateTime? datFieldCollectionDate { get; set; }
        protected DateTime? datFieldCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).OriginalValue; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).PreviousValue; } }
                
        [LocalizedDisplayName("strSendToOrganization")]
        [MapField(_str_idfSendToOffice)]
        public abstract Int64? idfSendToOffice { get; set; }
        protected Int64? idfSendToOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).OriginalValue; } }
        protected Int64? idfSendToOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSendToOffice)]
        [MapField(_str_strSendToOffice)]
        public abstract String strSendToOffice { get; set; }
        protected String strSendToOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strSendToOffice).OriginalValue; } }
        protected String strSendToOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSendToOffice).PreviousValue; } }
                
        [LocalizedDisplayName("VectorSample.idfFieldCollectedByOffice")]
        [MapField(_str_idfFieldCollectedByOffice)]
        public abstract Int64? idfFieldCollectedByOffice { get; set; }
        protected Int64? idfFieldCollectedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).OriginalValue; } }
        protected Int64? idfFieldCollectedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFieldCollectedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFieldSentDate)]
        [MapField(_str_datFieldSentDate)]
        public abstract DateTime? datFieldSentDate { get; set; }
        protected DateTime? datFieldSentDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldSentDate).OriginalValue; } }
        protected DateTime? datFieldSentDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldSentDate).PreviousValue; } }
                
        [LocalizedDisplayName("VectorSample.strNote")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datAccession)]
        [MapField(_str_datAccession)]
        public abstract DateTime? datAccession { get; set; }
        protected DateTime? datAccession_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).OriginalValue; } }
        protected DateTime? datAccession_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datAccession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsAccessionCondition)]
        [MapField(_str_idfsAccessionCondition)]
        public abstract Int64? idfsAccessionCondition { get; set; }
        protected Int64? idfsAccessionCondition_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAccessionCondition).OriginalValue; } }
        protected Int64? idfsAccessionCondition_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAccessionCondition).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfParty)]
        [MapField(_str_idfParty)]
        public abstract Int64? idfParty { get; set; }
        protected Int64? idfParty_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParty).OriginalValue; } }
        protected Int64? idfParty_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParty).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64? idfCase { get; set; }
        protected Int64? idfCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64? idfCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfVectorSurveillanceSession)]
        [MapField(_str_idfVectorSurveillanceSession)]
        public abstract Int64? idfVectorSurveillanceSession { get; set; }
        protected Int64? idfVectorSurveillanceSession_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).OriginalValue; } }
        protected Int64? idfVectorSurveillanceSession_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVectorSurveillanceSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strVectorTypeName)]
        [MapField(_str_strVectorTypeName)]
        public abstract String strVectorTypeName { get; set; }
        protected String strVectorTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorTypeName).OriginalValue; } }
        protected String strVectorTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorTypeName).PreviousValue; } }
                
        [LocalizedDisplayName("idfsVectorSubType")]
        [MapField(_str_strVectorSubTypeName)]
        public abstract String strVectorSubTypeName { get; set; }
        protected String strVectorSubTypeName_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorSubTypeName).OriginalValue; } }
        protected String strVectorSubTypeName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorSubTypeName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRegion)]
        [MapField(_str_idfsRegion)]
        public abstract Int64? idfsRegion { get; set; }
        protected Int64? idfsRegion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).OriginalValue; } }
        protected Int64? idfsRegion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRegionName)]
        [MapField(_str_strRegionName)]
        public abstract String strRegionName { get; set; }
        protected String strRegionName_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegionName).OriginalValue; } }
        protected String strRegionName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegionName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRayon)]
        [MapField(_str_idfsRayon)]
        public abstract Int64? idfsRayon { get; set; }
        protected Int64? idfsRayon_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).OriginalValue; } }
        protected Int64? idfsRayon_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRayonName)]
        [MapField(_str_strRayonName)]
        public abstract String strRayonName { get; set; }
        protected String strRayonName_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayonName).OriginalValue; } }
        protected String strRayonName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayonName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intQuantity)]
        [MapField(_str_intQuantity)]
        public abstract Int32 intQuantity { get; set; }
        protected Int32 intQuantity_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intQuantity).OriginalValue; } }
        protected Int32 intQuantity_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intQuantity).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datCollectionDateTime)]
        [MapField(_str_datCollectionDateTime)]
        public abstract DateTime datCollectionDateTime { get; set; }
        protected DateTime datCollectionDateTime_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datCollectionDateTime).OriginalValue; } }
        protected DateTime datCollectionDateTime_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datCollectionDateTime).PreviousValue; } }
                
        [LocalizedDisplayName("Vector.strVectorID")]
        [MapField(_str_strVectorID)]
        public abstract String strVectorID { get; set; }
        protected String strVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).OriginalValue; } }
        protected String strVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Used)]
        [MapField(_str_Used)]
        public abstract Int32 Used { get; set; }
        protected Int32 Used_Original { get { return ((EditableValue<Int32>)((dynamic)this)._used).OriginalValue; } }
        protected Int32 Used_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._used).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<VectorSample, object> _get_func;
            internal Action<VectorSample, string> _set_func;
            internal Action<VectorSample, VectorSample, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfVector = "idfVector";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_idfsVectorSubType = "idfsVectorSubType";
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_idfsSampleType = "idfsSampleType";
        internal const string _str_strSampleName = "strSampleName";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_idfSendToOffice = "idfSendToOffice";
        internal const string _str_strSendToOffice = "strSendToOffice";
        internal const string _str_idfFieldCollectedByOffice = "idfFieldCollectedByOffice";
        internal const string _str_datFieldSentDate = "datFieldSentDate";
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
        internal const string _str_strFieldCollectedByOffice = "strFieldCollectedByOffice";
        internal const string _str_ParentVector = "ParentVector";
        internal const string _str_Samples = "Samples";
        internal const string _str_FieldTests = "FieldTests";
        internal const string _str_Vectors = "Vectors";
        internal const string _str_LabTests = "LabTests";
        internal const string _str_isPool = "isPool";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_strVectorType = "strVectorType";
        internal const string _str_strSampleType = "strSampleType";
        internal const string _str_strAccessionCondition = "strAccessionCondition";
        internal const string _str_SampleLongName = "SampleLongName";
        internal const string _str_VectorType2SampleType = "VectorType2SampleType";
        internal const string _str_VectorType2SampleTypeFiltered = "VectorType2SampleTypeFiltered";
        internal const string _str_FieldCollectedByOffice = "FieldCollectedByOffice";
        internal const string _str_SendToOffice = "SendToOffice";
        internal const string _str_AccessionCondition = "AccessionCondition";
        internal const string _str_VectorType = "VectorType";
        internal const string _str_VectorSubType = "VectorSubType";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        private static readonly field_info[] _field_infos =
        {
                  
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
              _name = _str_idfsVectorType, _formname = _str_idfsVectorType, _type = "Int64",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsVectorType != newval) 
                  o.VectorType = o.VectorTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsVectorType != newval) o.idfsVectorType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) 
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, o.ObjectIdent2 + _str_idfsVectorType, o.ObjectIdent3 + _str_idfsVectorType, "Int64", 
                    o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(),                  
                  o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsVectorSubType, _formname = _str_idfsVectorSubType, _type = "Int64",
              _get_func = o => o.idfsVectorSubType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsVectorSubType != newval) 
                  o.VectorSubType = o.VectorSubTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsVectorSubType != newval) o.idfsVectorSubType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_idfsVectorSubType, c)) 
                  m.Add(_str_idfsVectorSubType, o.ObjectIdent + _str_idfsVectorSubType, o.ObjectIdent2 + _str_idfsVectorSubType, o.ObjectIdent3 + _str_idfsVectorSubType, "Int64", 
                    o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(),                  
                  o.IsReadOnly(_str_idfsVectorSubType), o.IsInvisible(_str_idfsVectorSubType), o.IsRequired(_str_idfsVectorSubType)); 
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
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsSampleType != newval) 
                  o.VectorType2SampleType = o.VectorType2SampleTypeLookup.FirstOrDefault(c => c.idfsSampleType == newval);
                if (o.idfsSampleType != newval) o.idfsSampleType = newval; },
              _compare_func = (o, c, m, g) => {
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
              _compare_func = (o, c, m, g) => {
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
              _compare_func = (o, c, m, g) => {
                if (o.datFieldCollectionDate != c.datFieldCollectionDate || o.IsRIRPropChanged(_str_datFieldCollectionDate, c)) 
                  m.Add(_str_datFieldCollectionDate, o.ObjectIdent + _str_datFieldCollectionDate, o.ObjectIdent2 + _str_datFieldCollectionDate, o.ObjectIdent3 + _str_datFieldCollectionDate, "DateTime?", 
                    o.datFieldCollectionDate == null ? "" : o.datFieldCollectionDate.ToString(),                  
                  o.IsReadOnly(_str_datFieldCollectionDate), o.IsInvisible(_str_datFieldCollectionDate), o.IsRequired(_str_datFieldCollectionDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSendToOffice, _formname = _str_idfSendToOffice, _type = "Int64?",
              _get_func = o => o.idfSendToOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfSendToOffice != newval) 
                  o.SendToOffice = o.SendToOfficeLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfSendToOffice != newval) o.idfSendToOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfSendToOffice != c.idfSendToOffice || o.IsRIRPropChanged(_str_idfSendToOffice, c)) 
                  m.Add(_str_idfSendToOffice, o.ObjectIdent + _str_idfSendToOffice, o.ObjectIdent2 + _str_idfSendToOffice, o.ObjectIdent3 + _str_idfSendToOffice, "Int64?", 
                    o.idfSendToOffice == null ? "" : o.idfSendToOffice.ToString(),                  
                  o.IsReadOnly(_str_idfSendToOffice), o.IsInvisible(_str_idfSendToOffice), o.IsRequired(_str_idfSendToOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSendToOffice, _formname = _str_strSendToOffice, _type = "String",
              _get_func = o => o.strSendToOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSendToOffice != newval) o.strSendToOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSendToOffice != c.strSendToOffice || o.IsRIRPropChanged(_str_strSendToOffice, c)) 
                  m.Add(_str_strSendToOffice, o.ObjectIdent + _str_strSendToOffice, o.ObjectIdent2 + _str_strSendToOffice, o.ObjectIdent3 + _str_strSendToOffice, "String", 
                    o.strSendToOffice == null ? "" : o.strSendToOffice.ToString(),                  
                  o.IsReadOnly(_str_strSendToOffice), o.IsInvisible(_str_strSendToOffice), o.IsRequired(_str_strSendToOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfFieldCollectedByOffice, _formname = _str_idfFieldCollectedByOffice, _type = "Int64?",
              _get_func = o => o.idfFieldCollectedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfFieldCollectedByOffice != newval) 
                  o.FieldCollectedByOffice = o.FieldCollectedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfFieldCollectedByOffice != newval) o.idfFieldCollectedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfFieldCollectedByOffice != c.idfFieldCollectedByOffice || o.IsRIRPropChanged(_str_idfFieldCollectedByOffice, c)) 
                  m.Add(_str_idfFieldCollectedByOffice, o.ObjectIdent + _str_idfFieldCollectedByOffice, o.ObjectIdent2 + _str_idfFieldCollectedByOffice, o.ObjectIdent3 + _str_idfFieldCollectedByOffice, "Int64?", 
                    o.idfFieldCollectedByOffice == null ? "" : o.idfFieldCollectedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfFieldCollectedByOffice), o.IsInvisible(_str_idfFieldCollectedByOffice), o.IsRequired(_str_idfFieldCollectedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datFieldSentDate, _formname = _str_datFieldSentDate, _type = "DateTime?",
              _get_func = o => o.datFieldSentDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datFieldSentDate != newval) o.datFieldSentDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datFieldSentDate != c.datFieldSentDate || o.IsRIRPropChanged(_str_datFieldSentDate, c)) 
                  m.Add(_str_datFieldSentDate, o.ObjectIdent + _str_datFieldSentDate, o.ObjectIdent2 + _str_datFieldSentDate, o.ObjectIdent3 + _str_datFieldSentDate, "DateTime?", 
                    o.datFieldSentDate == null ? "" : o.datFieldSentDate.ToString(),                  
                  o.IsReadOnly(_str_datFieldSentDate), o.IsInvisible(_str_datFieldSentDate), o.IsRequired(_str_datFieldSentDate)); 
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
              _name = _str_idfsAccessionCondition, _formname = _str_idfsAccessionCondition, _type = "Int64?",
              _get_func = o => o.idfsAccessionCondition,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsAccessionCondition != newval) 
                  o.AccessionCondition = o.AccessionConditionLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsAccessionCondition != newval) o.idfsAccessionCondition = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsAccessionCondition != c.idfsAccessionCondition || o.IsRIRPropChanged(_str_idfsAccessionCondition, c)) 
                  m.Add(_str_idfsAccessionCondition, o.ObjectIdent + _str_idfsAccessionCondition, o.ObjectIdent2 + _str_idfsAccessionCondition, o.ObjectIdent3 + _str_idfsAccessionCondition, "Int64?", 
                    o.idfsAccessionCondition == null ? "" : o.idfsAccessionCondition.ToString(),                  
                  o.IsReadOnly(_str_idfsAccessionCondition), o.IsInvisible(_str_idfsAccessionCondition), o.IsRequired(_str_idfsAccessionCondition)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfParty, _formname = _str_idfParty, _type = "Int64?",
              _get_func = o => o.idfParty,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfParty != newval) o.idfParty = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_idfParty, c)) 
                  m.Add(_str_idfParty, o.ObjectIdent + _str_idfParty, o.ObjectIdent2 + _str_idfParty, o.ObjectIdent3 + _str_idfParty, "Int64?", 
                    o.idfParty == null ? "" : o.idfParty.ToString(),                  
                  o.IsReadOnly(_str_idfParty), o.IsInvisible(_str_idfParty), o.IsRequired(_str_idfParty)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfCase, _formname = _str_idfCase, _type = "Int64?",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfCase != newval) o.idfCase = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, o.ObjectIdent2 + _str_idfCase, o.ObjectIdent3 + _str_idfCase, "Int64?", 
                    o.idfCase == null ? "" : o.idfCase.ToString(),                  
                  o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _formname = _str_idfVectorSurveillanceSession, _type = "Int64?",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfVectorSurveillanceSession != newval) o.idfVectorSurveillanceSession = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, o.ObjectIdent2 + _str_idfVectorSurveillanceSession, o.ObjectIdent3 + _str_idfVectorSurveillanceSession, "Int64?", 
                    o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(),                  
                  o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); 
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
              _name = _str_strVectorSubTypeName, _formname = _str_strVectorSubTypeName, _type = "String",
              _get_func = o => o.strVectorSubTypeName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectorSubTypeName != newval) o.strVectorSubTypeName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strVectorSubTypeName != c.strVectorSubTypeName || o.IsRIRPropChanged(_str_strVectorSubTypeName, c)) 
                  m.Add(_str_strVectorSubTypeName, o.ObjectIdent + _str_strVectorSubTypeName, o.ObjectIdent2 + _str_strVectorSubTypeName, o.ObjectIdent3 + _str_strVectorSubTypeName, "String", 
                    o.strVectorSubTypeName == null ? "" : o.strVectorSubTypeName.ToString(),                  
                  o.IsReadOnly(_str_strVectorSubTypeName), o.IsInvisible(_str_strVectorSubTypeName), o.IsRequired(_str_strVectorSubTypeName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRegion, _formname = _str_idfsRegion, _type = "Int64?",
              _get_func = o => o.idfsRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsRegion != newval) 
                  o.Region = o.RegionLookup.FirstOrDefault(c => c.idfsRegion == newval);
                if (o.idfsRegion != newval) o.idfsRegion = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_idfsRegion, c)) 
                  m.Add(_str_idfsRegion, o.ObjectIdent + _str_idfsRegion, o.ObjectIdent2 + _str_idfsRegion, o.ObjectIdent3 + _str_idfsRegion, "Int64?", 
                    o.idfsRegion == null ? "" : o.idfsRegion.ToString(),                  
                  o.IsReadOnly(_str_idfsRegion), o.IsInvisible(_str_idfsRegion), o.IsRequired(_str_idfsRegion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRegionName, _formname = _str_strRegionName, _type = "String",
              _get_func = o => o.strRegionName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRegionName != newval) o.strRegionName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strRegionName != c.strRegionName || o.IsRIRPropChanged(_str_strRegionName, c)) 
                  m.Add(_str_strRegionName, o.ObjectIdent + _str_strRegionName, o.ObjectIdent2 + _str_strRegionName, o.ObjectIdent3 + _str_strRegionName, "String", 
                    o.strRegionName == null ? "" : o.strRegionName.ToString(),                  
                  o.IsReadOnly(_str_strRegionName), o.IsInvisible(_str_strRegionName), o.IsRequired(_str_strRegionName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsRayon, _formname = _str_idfsRayon, _type = "Int64?",
              _get_func = o => o.idfsRayon,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsRayon != newval) 
                  o.Rayon = o.RayonLookup.FirstOrDefault(c => c.idfsRayon == newval);
                if (o.idfsRayon != newval) o.idfsRayon = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_idfsRayon, c)) 
                  m.Add(_str_idfsRayon, o.ObjectIdent + _str_idfsRayon, o.ObjectIdent2 + _str_idfsRayon, o.ObjectIdent3 + _str_idfsRayon, "Int64?", 
                    o.idfsRayon == null ? "" : o.idfsRayon.ToString(),                  
                  o.IsReadOnly(_str_idfsRayon), o.IsInvisible(_str_idfsRayon), o.IsRequired(_str_idfsRayon)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRayonName, _formname = _str_strRayonName, _type = "String",
              _get_func = o => o.strRayonName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRayonName != newval) o.strRayonName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strRayonName != c.strRayonName || o.IsRIRPropChanged(_str_strRayonName, c)) 
                  m.Add(_str_strRayonName, o.ObjectIdent + _str_strRayonName, o.ObjectIdent2 + _str_strRayonName, o.ObjectIdent3 + _str_strRayonName, "String", 
                    o.strRayonName == null ? "" : o.strRayonName.ToString(),                  
                  o.IsReadOnly(_str_strRayonName), o.IsInvisible(_str_strRayonName), o.IsRequired(_str_strRayonName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intQuantity, _formname = _str_intQuantity, _type = "Int32",
              _get_func = o => o.intQuantity,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intQuantity != newval) o.intQuantity = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intQuantity != c.intQuantity || o.IsRIRPropChanged(_str_intQuantity, c)) 
                  m.Add(_str_intQuantity, o.ObjectIdent + _str_intQuantity, o.ObjectIdent2 + _str_intQuantity, o.ObjectIdent3 + _str_intQuantity, "Int32", 
                    o.intQuantity == null ? "" : o.intQuantity.ToString(),                  
                  o.IsReadOnly(_str_intQuantity), o.IsInvisible(_str_intQuantity), o.IsRequired(_str_intQuantity)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datCollectionDateTime, _formname = _str_datCollectionDateTime, _type = "DateTime",
              _get_func = o => o.datCollectionDateTime,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTime(val); if (o.datCollectionDateTime != newval) o.datCollectionDateTime = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datCollectionDateTime != c.datCollectionDateTime || o.IsRIRPropChanged(_str_datCollectionDateTime, c)) 
                  m.Add(_str_datCollectionDateTime, o.ObjectIdent + _str_datCollectionDateTime, o.ObjectIdent2 + _str_datCollectionDateTime, o.ObjectIdent3 + _str_datCollectionDateTime, "DateTime", 
                    o.datCollectionDateTime == null ? "" : o.datCollectionDateTime.ToString(),                  
                  o.IsReadOnly(_str_datCollectionDateTime), o.IsInvisible(_str_datCollectionDateTime), o.IsRequired(_str_datCollectionDateTime)); 
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
              _name = _str_Used, _formname = _str_Used, _type = "Int32",
              _get_func = o => o.Used,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.Used != newval) o.Used = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.Used != c.Used || o.IsRIRPropChanged(_str_Used, c)) 
                  m.Add(_str_Used, o.ObjectIdent + _str_Used, o.ObjectIdent2 + _str_Used, o.ObjectIdent3 + _str_Used, "Int32", 
                    o.Used == null ? "" : o.Used.ToString(),                  
                  o.IsReadOnly(_str_Used), o.IsInvisible(_str_Used), o.IsRequired(_str_Used)); 
                  }
              }, 
        
            new field_info {
              _name = _str_strFieldCollectedByOffice, _formname = _str_strFieldCollectedByOffice, _type = "string",
              _get_func = o => o.strFieldCollectedByOffice,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strFieldCollectedByOffice != c.strFieldCollectedByOffice || o.IsRIRPropChanged(_str_strFieldCollectedByOffice, c)) {
                  m.Add(_str_strFieldCollectedByOffice, o.ObjectIdent + _str_strFieldCollectedByOffice, o.ObjectIdent2 + _str_strFieldCollectedByOffice, o.ObjectIdent3 + _str_strFieldCollectedByOffice, "string", o.strFieldCollectedByOffice == null ? "" : o.strFieldCollectedByOffice.ToString(), o.IsReadOnly(_str_strFieldCollectedByOffice), o.IsInvisible(_str_strFieldCollectedByOffice), o.IsRequired(_str_strFieldCollectedByOffice));
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
              _name = _str_Samples, _formname = _str_Samples, _type = "EditableList<VectorSample>",
              _get_func = o => o.Samples,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_FieldTests, _formname = _str_FieldTests, _type = "EditableList<VectorFieldTest>",
              _get_func = o => o.FieldTests,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
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
              _name = _str_LabTests, _formname = _str_LabTests, _type = "EditableList<VectorLabTest>",
              _get_func = o => o.LabTests,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_isPool, _formname = _str_isPool, _type = "bool",
              _get_func = o => o.isPool,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.isPool != c.isPool || o.IsRIRPropChanged(_str_isPool, c)) {
                  m.Add(_str_isPool, o.ObjectIdent + _str_isPool, o.ObjectIdent2 + _str_isPool, o.ObjectIdent3 + _str_isPool, "bool", o.isPool == null ? "" : o.isPool.ToString(), o.IsReadOnly(_str_isPool), o.IsInvisible(_str_isPool), o.IsRequired(_str_isPool));
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
              _name = _str_strVectorType, _formname = _str_strVectorType, _type = "string",
              _get_func = o => o.strVectorType,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strVectorType != c.strVectorType || o.IsRIRPropChanged(_str_strVectorType, c)) {
                  m.Add(_str_strVectorType, o.ObjectIdent + _str_strVectorType, o.ObjectIdent2 + _str_strVectorType, o.ObjectIdent3 + _str_strVectorType, "string", o.strVectorType == null ? "" : o.strVectorType.ToString(), o.IsReadOnly(_str_strVectorType), o.IsInvisible(_str_strVectorType), o.IsRequired(_str_strVectorType));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strSampleType, _formname = _str_strSampleType, _type = "string",
              _get_func = o => o.strSampleType,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strSampleType != c.strSampleType || o.IsRIRPropChanged(_str_strSampleType, c)) {
                  m.Add(_str_strSampleType, o.ObjectIdent + _str_strSampleType, o.ObjectIdent2 + _str_strSampleType, o.ObjectIdent3 + _str_strSampleType, "string", o.strSampleType == null ? "" : o.strSampleType.ToString(), o.IsReadOnly(_str_strSampleType), o.IsInvisible(_str_strSampleType), o.IsRequired(_str_strSampleType));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strAccessionCondition, _formname = _str_strAccessionCondition, _type = "string",
              _get_func = o => o.strAccessionCondition,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strAccessionCondition != c.strAccessionCondition || o.IsRIRPropChanged(_str_strAccessionCondition, c)) {
                  m.Add(_str_strAccessionCondition, o.ObjectIdent + _str_strAccessionCondition, o.ObjectIdent2 + _str_strAccessionCondition, o.ObjectIdent3 + _str_strAccessionCondition, "string", o.strAccessionCondition == null ? "" : o.strAccessionCondition.ToString(), o.IsReadOnly(_str_strAccessionCondition), o.IsInvisible(_str_strAccessionCondition), o.IsRequired(_str_strAccessionCondition));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_SampleLongName, _formname = _str_SampleLongName, _type = "string",
              _get_func = o => o.SampleLongName,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.SampleLongName != c.SampleLongName || o.IsRIRPropChanged(_str_SampleLongName, c)) {
                  m.Add(_str_SampleLongName, o.ObjectIdent + _str_SampleLongName, o.ObjectIdent2 + _str_SampleLongName, o.ObjectIdent3 + _str_SampleLongName, "string", o.SampleLongName == null ? "" : o.SampleLongName.ToString(), o.IsReadOnly(_str_SampleLongName), o.IsInvisible(_str_SampleLongName), o.IsRequired(_str_SampleLongName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_VectorType2SampleType, _formname = _str_VectorType2SampleType, _type = "Lookup",
              _get_func = o => { if (o.VectorType2SampleType == null) return null; return o.VectorType2SampleType.idfsSampleType; },
              _set_func = (o, val) => { o.VectorType2SampleType = o.VectorType2SampleTypeLookup.Where(c => c.idfsSampleType.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_VectorType2SampleType, c);
                if (o.idfsSampleType != c.idfsSampleType || o.IsRIRPropChanged(_str_VectorType2SampleType, c) || bChangeLookupContent) {
                  m.Add(_str_VectorType2SampleType, o.ObjectIdent + _str_VectorType2SampleType, o.ObjectIdent2 + _str_VectorType2SampleType, o.ObjectIdent3 + _str_VectorType2SampleType, "Lookup", o.idfsSampleType == null ? "" : o.idfsSampleType.ToString(), o.IsReadOnly(_str_VectorType2SampleType), o.IsInvisible(_str_VectorType2SampleType), o.IsRequired(_str_VectorType2SampleType),
                  bChangeLookupContent ? o.VectorType2SampleTypeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_VectorType2SampleType + "Lookup", _formname = _str_VectorType2SampleType + "Lookup", _type = "LookupContent",
              _get_func = o => o.VectorType2SampleTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_VectorType2SampleTypeFiltered, _formname = _str_VectorType2SampleTypeFiltered, _type = "Lookup",
              _get_func = o => { if (o.VectorType2SampleTypeFiltered == null) return null; return o.VectorType2SampleTypeFiltered.idfsSampleType; },
              _set_func = (o, val) => { o.VectorType2SampleTypeFiltered = o.VectorType2SampleTypeFilteredLookup.Where(c => c.idfsSampleType.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_VectorType2SampleTypeFiltered, c);
                if (o.idfsSampleType != c.idfsSampleType || o.IsRIRPropChanged(_str_VectorType2SampleTypeFiltered, c) || bChangeLookupContent) {
                  m.Add(_str_VectorType2SampleTypeFiltered, o.ObjectIdent + _str_VectorType2SampleTypeFiltered, o.ObjectIdent2 + _str_VectorType2SampleTypeFiltered, o.ObjectIdent3 + _str_VectorType2SampleTypeFiltered, "Lookup", o.idfsSampleType == null ? "" : o.idfsSampleType.ToString(), o.IsReadOnly(_str_VectorType2SampleTypeFiltered), o.IsInvisible(_str_VectorType2SampleTypeFiltered), o.IsRequired(_str_VectorType2SampleTypeFiltered),
                  bChangeLookupContent ? o.VectorType2SampleTypeFilteredLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_VectorType2SampleTypeFiltered + "Lookup", _formname = _str_VectorType2SampleTypeFiltered + "Lookup", _type = "LookupContent",
              _get_func = o => o.VectorType2SampleTypeFilteredLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_FieldCollectedByOffice, _formname = _str_FieldCollectedByOffice, _type = "Lookup",
              _get_func = o => { if (o.FieldCollectedByOffice == null) return null; return o.FieldCollectedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.FieldCollectedByOffice = o.FieldCollectedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_FieldCollectedByOffice, c);
                if (o.idfFieldCollectedByOffice != c.idfFieldCollectedByOffice || o.IsRIRPropChanged(_str_FieldCollectedByOffice, c) || bChangeLookupContent) {
                  m.Add(_str_FieldCollectedByOffice, o.ObjectIdent + _str_FieldCollectedByOffice, o.ObjectIdent2 + _str_FieldCollectedByOffice, o.ObjectIdent3 + _str_FieldCollectedByOffice, "Lookup", o.idfFieldCollectedByOffice == null ? "" : o.idfFieldCollectedByOffice.ToString(), o.IsReadOnly(_str_FieldCollectedByOffice), o.IsInvisible(_str_FieldCollectedByOffice), o.IsRequired(_str_FieldCollectedByOffice),
                  bChangeLookupContent ? o.FieldCollectedByOfficeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_FieldCollectedByOffice + "Lookup", _formname = _str_FieldCollectedByOffice + "Lookup", _type = "LookupContent",
              _get_func = o => o.FieldCollectedByOfficeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_SendToOffice, _formname = _str_SendToOffice, _type = "Lookup",
              _get_func = o => { if (o.SendToOffice == null) return null; return o.SendToOffice.idfInstitution; },
              _set_func = (o, val) => { o.SendToOffice = o.SendToOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_SendToOffice, c);
                if (o.idfSendToOffice != c.idfSendToOffice || o.IsRIRPropChanged(_str_SendToOffice, c) || bChangeLookupContent) {
                  m.Add(_str_SendToOffice, o.ObjectIdent + _str_SendToOffice, o.ObjectIdent2 + _str_SendToOffice, o.ObjectIdent3 + _str_SendToOffice, "Lookup", o.idfSendToOffice == null ? "" : o.idfSendToOffice.ToString(), o.IsReadOnly(_str_SendToOffice), o.IsInvisible(_str_SendToOffice), o.IsRequired(_str_SendToOffice),
                  bChangeLookupContent ? o.SendToOfficeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_SendToOffice + "Lookup", _formname = _str_SendToOffice + "Lookup", _type = "LookupContent",
              _get_func = o => o.SendToOfficeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_AccessionCondition, _formname = _str_AccessionCondition, _type = "Lookup",
              _get_func = o => { if (o.AccessionCondition == null) return null; return o.AccessionCondition.idfsBaseReference; },
              _set_func = (o, val) => { o.AccessionCondition = o.AccessionConditionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AccessionCondition, c);
                if (o.idfsAccessionCondition != c.idfsAccessionCondition || o.IsRIRPropChanged(_str_AccessionCondition, c) || bChangeLookupContent) {
                  m.Add(_str_AccessionCondition, o.ObjectIdent + _str_AccessionCondition, o.ObjectIdent2 + _str_AccessionCondition, o.ObjectIdent3 + _str_AccessionCondition, "Lookup", o.idfsAccessionCondition == null ? "" : o.idfsAccessionCondition.ToString(), o.IsReadOnly(_str_AccessionCondition), o.IsInvisible(_str_AccessionCondition), o.IsRequired(_str_AccessionCondition),
                  bChangeLookupContent ? o.AccessionConditionLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AccessionCondition + "Lookup", _formname = _str_AccessionCondition + "Lookup", _type = "LookupContent",
              _get_func = o => o.AccessionConditionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_VectorType, _formname = _str_VectorType, _type = "Lookup",
              _get_func = o => { if (o.VectorType == null) return null; return o.VectorType.idfsBaseReference; },
              _set_func = (o, val) => { o.VectorType = o.VectorTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_VectorType, c);
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_VectorType, c) || bChangeLookupContent) {
                  m.Add(_str_VectorType, o.ObjectIdent + _str_VectorType, o.ObjectIdent2 + _str_VectorType, o.ObjectIdent3 + _str_VectorType, "Lookup", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_VectorType), o.IsInvisible(_str_VectorType), o.IsRequired(_str_VectorType),
                  bChangeLookupContent ? o.VectorTypeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_VectorType + "Lookup", _formname = _str_VectorType + "Lookup", _type = "LookupContent",
              _get_func = o => o.VectorTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_VectorSubType, _formname = _str_VectorSubType, _type = "Lookup",
              _get_func = o => { if (o.VectorSubType == null) return null; return o.VectorSubType.idfsBaseReference; },
              _set_func = (o, val) => { o.VectorSubType = o.VectorSubTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_VectorSubType, c);
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_VectorSubType, c) || bChangeLookupContent) {
                  m.Add(_str_VectorSubType, o.ObjectIdent + _str_VectorSubType, o.ObjectIdent2 + _str_VectorSubType, o.ObjectIdent3 + _str_VectorSubType, "Lookup", o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(), o.IsReadOnly(_str_VectorSubType), o.IsInvisible(_str_VectorSubType), o.IsRequired(_str_VectorSubType),
                  bChangeLookupContent ? o.VectorSubTypeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_VectorSubType + "Lookup", _formname = _str_VectorSubType + "Lookup", _type = "LookupContent",
              _get_func = o => o.VectorSubTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Region, _formname = _str_Region, _type = "Lookup",
              _get_func = o => { if (o.Region == null) return null; return o.Region.idfsRegion; },
              _set_func = (o, val) => { o.Region = o.RegionLookup.Where(c => c.idfsRegion.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Region, c);
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_Region, c) || bChangeLookupContent) {
                  m.Add(_str_Region, o.ObjectIdent + _str_Region, o.ObjectIdent2 + _str_Region, o.ObjectIdent3 + _str_Region, "Lookup", o.idfsRegion == null ? "" : o.idfsRegion.ToString(), o.IsReadOnly(_str_Region), o.IsInvisible(_str_Region), o.IsRequired(_str_Region),
                  bChangeLookupContent ? o.RegionLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Region + "Lookup", _formname = _str_Region + "Lookup", _type = "LookupContent",
              _get_func = o => o.RegionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Rayon, _formname = _str_Rayon, _type = "Lookup",
              _get_func = o => { if (o.Rayon == null) return null; return o.Rayon.idfsRayon; },
              _set_func = (o, val) => { o.Rayon = o.RayonLookup.Where(c => c.idfsRayon.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Rayon, c);
                if (o.idfsRayon != c.idfsRayon || o.IsRIRPropChanged(_str_Rayon, c) || bChangeLookupContent) {
                  m.Add(_str_Rayon, o.ObjectIdent + _str_Rayon, o.ObjectIdent2 + _str_Rayon, o.ObjectIdent3 + _str_Rayon, "Lookup", o.idfsRayon == null ? "" : o.idfsRayon.ToString(), o.IsReadOnly(_str_Rayon), o.IsInvisible(_str_Rayon), o.IsRequired(_str_Rayon),
                  bChangeLookupContent ? o.RayonLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Rayon + "Lookup", _formname = _str_Rayon + "Lookup", _type = "LookupContent",
              _get_func = o => o.RayonLookup,
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
            VectorSample obj = (VectorSample)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_VectorType2SampleType)]
        [Relation(typeof(VectorType2SampleTypeLookup), eidss.model.Schema.VectorType2SampleTypeLookup._str_idfsSampleType, _str_idfsSampleType)]
        public VectorType2SampleTypeLookup VectorType2SampleType
        {
            get { return _VectorType2SampleType == null ? null : ((long)_VectorType2SampleType.Key == 0 ? null : _VectorType2SampleType); }
            set 
            { 
                var oldVal = _VectorType2SampleType;
                _VectorType2SampleType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_VectorType2SampleType != oldVal)
                {
                    if (idfsSampleType != (_VectorType2SampleType == null
                            ? new Int64()
                            : (Int64)_VectorType2SampleType.idfsSampleType))
                        idfsSampleType = _VectorType2SampleType == null 
                            ? new Int64()
                            : (Int64)_VectorType2SampleType.idfsSampleType; 
                    OnPropertyChanged(_str_VectorType2SampleType); 
                }
            }
        }
        private VectorType2SampleTypeLookup _VectorType2SampleType;

        
        public List<VectorType2SampleTypeLookup> VectorType2SampleTypeLookup
        {
            get { return _VectorType2SampleTypeLookup; }
        }
        private List<VectorType2SampleTypeLookup> _VectorType2SampleTypeLookup = new List<VectorType2SampleTypeLookup>();
            
        [LocalizedDisplayName(_str_VectorType2SampleTypeFiltered)]
        [Relation(typeof(VectorType2SampleTypeLookup), eidss.model.Schema.VectorType2SampleTypeLookup._str_idfsSampleType, _str_idfsSampleType)]
        public VectorType2SampleTypeLookup VectorType2SampleTypeFiltered
        {
            get { return _VectorType2SampleTypeFiltered == null ? null : ((long)_VectorType2SampleTypeFiltered.Key == 0 ? null : _VectorType2SampleTypeFiltered); }
            set 
            { 
                var oldVal = _VectorType2SampleTypeFiltered;
                _VectorType2SampleTypeFiltered = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_VectorType2SampleTypeFiltered != oldVal)
                {
                    if (idfsSampleType != (_VectorType2SampleTypeFiltered == null
                            ? new Int64()
                            : (Int64)_VectorType2SampleTypeFiltered.idfsSampleType))
                        idfsSampleType = _VectorType2SampleTypeFiltered == null 
                            ? new Int64()
                            : (Int64)_VectorType2SampleTypeFiltered.idfsSampleType; 
                    OnPropertyChanged(_str_VectorType2SampleTypeFiltered); 
                }
            }
        }
        private VectorType2SampleTypeLookup _VectorType2SampleTypeFiltered;

        
        public List<VectorType2SampleTypeLookup> VectorType2SampleTypeFilteredLookup
        {
            get { return _VectorType2SampleTypeFilteredLookup; }
        }
        private List<VectorType2SampleTypeLookup> _VectorType2SampleTypeFilteredLookup = new List<VectorType2SampleTypeLookup>();
            
        [LocalizedDisplayName(_str_FieldCollectedByOffice)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfFieldCollectedByOffice)]
        public OrganizationLookup FieldCollectedByOffice
        {
            get { return _FieldCollectedByOffice == null ? null : ((long)_FieldCollectedByOffice.Key == 0 ? null : _FieldCollectedByOffice); }
            set 
            { 
                var oldVal = _FieldCollectedByOffice;
                _FieldCollectedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_FieldCollectedByOffice != oldVal)
                {
                    if (idfFieldCollectedByOffice != (_FieldCollectedByOffice == null
                            ? new Int64?()
                            : (Int64?)_FieldCollectedByOffice.idfInstitution))
                        idfFieldCollectedByOffice = _FieldCollectedByOffice == null 
                            ? new Int64?()
                            : (Int64?)_FieldCollectedByOffice.idfInstitution; 
                    OnPropertyChanged(_str_FieldCollectedByOffice); 
                }
            }
        }
        private OrganizationLookup _FieldCollectedByOffice;

        
        public List<OrganizationLookup> FieldCollectedByOfficeLookup
        {
            get { return _FieldCollectedByOfficeLookup; }
        }
        private List<OrganizationLookup> _FieldCollectedByOfficeLookup = new List<OrganizationLookup>();
            
        [LocalizedDisplayName(_str_SendToOffice)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfSendToOffice)]
        public OrganizationLookup SendToOffice
        {
            get { return _SendToOffice == null ? null : ((long)_SendToOffice.Key == 0 ? null : _SendToOffice); }
            set 
            { 
                var oldVal = _SendToOffice;
                _SendToOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SendToOffice != oldVal)
                {
                    if (idfSendToOffice != (_SendToOffice == null
                            ? new Int64?()
                            : (Int64?)_SendToOffice.idfInstitution))
                        idfSendToOffice = _SendToOffice == null 
                            ? new Int64?()
                            : (Int64?)_SendToOffice.idfInstitution; 
                    OnPropertyChanged(_str_SendToOffice); 
                }
            }
        }
        private OrganizationLookup _SendToOffice;

        
        public List<OrganizationLookup> SendToOfficeLookup
        {
            get { return _SendToOfficeLookup; }
        }
        private List<OrganizationLookup> _SendToOfficeLookup = new List<OrganizationLookup>();
            
        [LocalizedDisplayName(_str_AccessionCondition)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAccessionCondition)]
        public BaseReference AccessionCondition
        {
            get { return _AccessionCondition == null ? null : ((long)_AccessionCondition.Key == 0 ? null : _AccessionCondition); }
            set 
            { 
                var oldVal = _AccessionCondition;
                _AccessionCondition = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AccessionCondition != oldVal)
                {
                    if (idfsAccessionCondition != (_AccessionCondition == null
                            ? new Int64?()
                            : (Int64?)_AccessionCondition.idfsBaseReference))
                        idfsAccessionCondition = _AccessionCondition == null 
                            ? new Int64?()
                            : (Int64?)_AccessionCondition.idfsBaseReference; 
                    OnPropertyChanged(_str_AccessionCondition); 
                }
            }
        }
        private BaseReference _AccessionCondition;

        
        public BaseReferenceList AccessionConditionLookup
        {
            get { return _AccessionConditionLookup; }
        }
        private BaseReferenceList _AccessionConditionLookup = new BaseReferenceList("rftAccessionCondition");
            
        [LocalizedDisplayName(_str_VectorType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsVectorType)]
        public BaseReference VectorType
        {
            get { return _VectorType == null ? null : ((long)_VectorType.Key == 0 ? null : _VectorType); }
            set 
            { 
                var oldVal = _VectorType;
                _VectorType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_VectorType != oldVal)
                {
                    if (idfsVectorType != (_VectorType == null
                            ? new Int64()
                            : (Int64)_VectorType.idfsBaseReference))
                        idfsVectorType = _VectorType == null 
                            ? new Int64()
                            : (Int64)_VectorType.idfsBaseReference; 
                    OnPropertyChanged(_str_VectorType); 
                }
            }
        }
        private BaseReference _VectorType;

        
        public BaseReferenceList VectorTypeLookup
        {
            get { return _VectorTypeLookup; }
        }
        private BaseReferenceList _VectorTypeLookup = new BaseReferenceList("rftVectorType");
            
        [LocalizedDisplayName(_str_VectorSubType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsVectorSubType)]
        public BaseReference VectorSubType
        {
            get { return _VectorSubType == null ? null : ((long)_VectorSubType.Key == 0 ? null : _VectorSubType); }
            set 
            { 
                var oldVal = _VectorSubType;
                _VectorSubType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_VectorSubType != oldVal)
                {
                    if (idfsVectorSubType != (_VectorSubType == null
                            ? new Int64()
                            : (Int64)_VectorSubType.idfsBaseReference))
                        idfsVectorSubType = _VectorSubType == null 
                            ? new Int64()
                            : (Int64)_VectorSubType.idfsBaseReference; 
                    OnPropertyChanged(_str_VectorSubType); 
                }
            }
        }
        private BaseReference _VectorSubType;

        
        public BaseReferenceList VectorSubTypeLookup
        {
            get { return _VectorSubTypeLookup; }
        }
        private BaseReferenceList _VectorSubTypeLookup = new BaseReferenceList("rftVectorSubType");
            
        [LocalizedDisplayName(_str_Region)]
        [Relation(typeof(RegionLookup), eidss.model.Schema.RegionLookup._str_idfsRegion, _str_idfsRegion)]
        public RegionLookup Region
        {
            get { return _Region == null ? null : ((long)_Region.Key == 0 ? null : _Region); }
            set 
            { 
                var oldVal = _Region;
                _Region = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Region != oldVal)
                {
                    if (idfsRegion != (_Region == null
                            ? new Int64?()
                            : (Int64?)_Region.idfsRegion))
                        idfsRegion = _Region == null 
                            ? new Int64?()
                            : (Int64?)_Region.idfsRegion; 
                    OnPropertyChanged(_str_Region); 
                }
            }
        }
        private RegionLookup _Region;

        
        public List<RegionLookup> RegionLookup
        {
            get { return _RegionLookup; }
        }
        private List<RegionLookup> _RegionLookup = new List<RegionLookup>();
            
        [LocalizedDisplayName(_str_Rayon)]
        [Relation(typeof(RayonLookup), eidss.model.Schema.RayonLookup._str_idfsRayon, _str_idfsRayon)]
        public RayonLookup Rayon
        {
            get { return _Rayon == null ? null : ((long)_Rayon.Key == 0 ? null : _Rayon); }
            set 
            { 
                var oldVal = _Rayon;
                _Rayon = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Rayon != oldVal)
                {
                    if (idfsRayon != (_Rayon == null
                            ? new Int64?()
                            : (Int64?)_Rayon.idfsRayon))
                        idfsRayon = _Rayon == null 
                            ? new Int64?()
                            : (Int64?)_Rayon.idfsRayon; 
                    OnPropertyChanged(_str_Rayon); 
                }
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
            
                case _str_VectorType2SampleType:
                    return new BvSelectList(VectorType2SampleTypeLookup, eidss.model.Schema.VectorType2SampleTypeLookup._str_idfsSampleType, null, VectorType2SampleType, _str_idfsSampleType);
            
                case _str_VectorType2SampleTypeFiltered:
                    return new BvSelectList(VectorType2SampleTypeFilteredLookup, eidss.model.Schema.VectorType2SampleTypeLookup._str_idfsSampleType, null, VectorType2SampleTypeFiltered, _str_idfsSampleType);
            
                case _str_FieldCollectedByOffice:
                    return new BvSelectList(FieldCollectedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, FieldCollectedByOffice, _str_idfFieldCollectedByOffice);
            
                case _str_SendToOffice:
                    return new BvSelectList(SendToOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, SendToOffice, _str_idfSendToOffice);
            
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
          [LocalizedDisplayName("VectorSample.idfFieldCollectedByOffice")]
        public string strFieldCollectedByOffice
        {
            get { return new Func<VectorSample, string>(c => (c.FieldCollectedByOfficeLookup == null) || Utils.IsEmpty(c.idfFieldCollectedByOffice) || (c.FieldCollectedByOfficeLookup.Count == 0) ? String.Empty : c.FieldCollectedByOfficeLookup.FirstOrDefault(x => x.idfInstitution == c.idfFieldCollectedByOffice).name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_ParentVector)]
        public Vector ParentVector
        {
            get { return new Func<VectorSample, Vector>(c => Parent as Vector)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Samples)]
        public EditableList<VectorSample> Samples
        {
            get { return new Func<VectorSample, EditableList<VectorSample>>(c => c.ParentVector == null ? new EditableList<VectorSample>() : c.ParentVector.SamplesAll)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_FieldTests)]
        public EditableList<VectorFieldTest> FieldTests
        {
            get { return new Func<VectorSample, EditableList<VectorFieldTest>>(c => c.ParentVector == null ? new EditableList<VectorFieldTest>() : c.ParentVector.FieldTests)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Vectors)]
        public EditableList<Vector> Vectors
        {
            get { return new Func<VectorSample, EditableList<Vector>>(c => c.ParentVector == null ? new EditableList<Vector>() : c.ParentVector.Vectors)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_LabTests)]
        public EditableList<VectorLabTest> LabTests
        {
            get { return new Func<VectorSample, EditableList<VectorLabTest>>(c => c.ParentVector == null ? new EditableList<VectorLabTest>() : c.ParentVector.LabTests)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isPool)]
        public bool isPool
        {
            get { return new Func<VectorSample, bool>(c => c.ParentVector == null ? false : c.ParentVector.IsPoolVectorType)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<VectorSample, string>(c => "Vectors_" + c.idfVectorSurveillanceSession + "_")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("idfsVectorType")]
        public string strVectorType
        {
            get { return new Func<VectorSample, string>(c => c.ParentVector == null ? String.Empty : c.ParentVector.strVectorType)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("idfsSampleType")]
        public string strSampleType
        {
            get { return new Func<VectorSample, string>(c => { if (c.VectorType2SampleTypeLookup == null) return String.Empty; else { var sn = c.VectorType2SampleTypeLookup.FirstOrDefault(s => s.idfsSampleType == c.idfsSampleType); return sn == null ? String.Empty : sn.SampleName; } })(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("idfsAccessionCondition")]
        public string strAccessionCondition
        {
            get { return new Func<VectorSample, string>(c => c.AccessionCondition == null ? String.Empty : c.AccessionCondition.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_SampleLongName)]
        public string SampleLongName
        {
            get { return new Func<VectorSample, string>(c => String.Format("{0}/{1}", strFieldBarcode, strSampleType))(this); }
            
        }
        
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
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as VectorSample;
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
            var ret = base.Clone() as VectorSample;
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
        public object KeyLookup { get { return idfMaterial; } }
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
        
            var _prev_idfsSampleType_VectorType2SampleType = idfsSampleType;
            var _prev_idfsSampleType_VectorType2SampleTypeFiltered = idfsSampleType;
            var _prev_idfFieldCollectedByOffice_FieldCollectedByOffice = idfFieldCollectedByOffice;
            var _prev_idfSendToOffice_SendToOffice = idfSendToOffice;
            var _prev_idfsAccessionCondition_AccessionCondition = idfsAccessionCondition;
            var _prev_idfsVectorType_VectorType = idfsVectorType;
            var _prev_idfsVectorSubType_VectorSubType = idfsVectorSubType;
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            base.RejectChanges();
        
            if (_prev_idfsSampleType_VectorType2SampleType != idfsSampleType)
            {
                _VectorType2SampleType = _VectorType2SampleTypeLookup.FirstOrDefault(c => c.idfsSampleType == idfsSampleType);
            }
            if (_prev_idfsSampleType_VectorType2SampleTypeFiltered != idfsSampleType)
            {
                _VectorType2SampleTypeFiltered = _VectorType2SampleTypeFilteredLookup.FirstOrDefault(c => c.idfsSampleType == idfsSampleType);
            }
            if (_prev_idfFieldCollectedByOffice_FieldCollectedByOffice != idfFieldCollectedByOffice)
            {
                _FieldCollectedByOffice = _FieldCollectedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfFieldCollectedByOffice);
            }
            if (_prev_idfSendToOffice_SendToOffice != idfSendToOffice)
            {
                _SendToOffice = _SendToOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfSendToOffice);
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

        private bool IsRIRPropChanged(string fld, VectorSample c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, VectorSample c)
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
        

      

        public VectorSample()
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
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_ParentVector);
                  
            if (e.PropertyName == _str_ParentVector)
                OnPropertyChanged(_str_Samples);
                  
            if (e.PropertyName == _str_ParentVector)
                OnPropertyChanged(_str_FieldTests);
                  
            if (e.PropertyName == _str_ParentVector)
                OnPropertyChanged(_str_Vectors);
                  
            if (e.PropertyName == _str_ParentVector)
                OnPropertyChanged(_str_LabTests);
                  
            if (e.PropertyName == _str_ParentVector)
                OnPropertyChanged(_str_isPool);
                  
            if (e.PropertyName == _str_idfVectorSurveillanceSession)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
            if (e.PropertyName == _str_ParentVector)
                OnPropertyChanged(_str_strVectorType);
                  
            if (e.PropertyName == _str_idfsSampleType)
                OnPropertyChanged(_str_strSampleType);
                  
            if (e.PropertyName == _str_idfsAccessionCondition)
                OnPropertyChanged(_str_strAccessionCondition);
                  
            if (e.PropertyName == _str_strSampleType)
                OnPropertyChanged(_str_SampleLongName);
                  
            if (e.PropertyName == _str_strFieldBarcode)
                OnPropertyChanged(_str_SampleLongName);
                  
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
            VectorSample obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VectorSample obj = this;
            
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

    
        private static string[] readonly_names1 = "datFieldCollectionDate,idfFieldCollectedByOffice".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strFieldBarcode,idfVector,idfsVectorType,strVectorSubTypeName,idfSendToOffice,strSendToOffice".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "idfsSampleType,VectorType2SampleTypeFiltered".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VectorSample, bool>(c => c.isPool || c.Used == 1)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VectorSample, bool>(c => false || c.Used == 1)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<VectorSample, bool>(c => c.Used == 1 ? true : (c.isPool && (c.VectorType2SampleTypeLookup.Count(s => s.idfsVectorType == c.idfsVectorType) <= 1)))(this);
            
            return ReadOnly || new Func<VectorSample, bool>(c => true)(this);
                
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


        internal Dictionary<string, Func<VectorSample, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VectorSample, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VectorSample, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VectorSample, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VectorSample, bool>> m_isHiddenPersonalData;
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
        protected bool bNeedLookupRemove;
        ~VectorSample()
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
                
                LookupManager.RemoveObject("VectorType2SampleTypeLookup", this);
                
                LookupManager.RemoveObject("VectorType2SampleTypeLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("rftAccessionCondition", this);
                
                LookupManager.RemoveObject("rftVectorType", this);
                
                LookupManager.RemoveObject("rftVectorSubType", this);
                
                LookupManager.RemoveObject("RegionLookup", this);
                
                LookupManager.RemoveObject("RayonLookup", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "VectorType2SampleTypeLookup")
                _getAccessor().LoadLookup_VectorType2SampleType(manager, this);
            
            if (lookup_object == "VectorType2SampleTypeLookup")
                _getAccessor().LoadLookup_VectorType2SampleTypeFiltered(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_FieldCollectedByOffice(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_SendToOffice(manager, this);
            
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
        public class VectorSampleGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfMaterial { get; set; }
        
            public String strVectorID { get; set; }
        
            public long? idfsVectorType { get; set; }
        
            public string strVectorType { get; set; }
        
            public String strVectorSubTypeName { get; set; }
        
            public String strBarcode { get; set; }
        
            public String strFieldBarcode { get; set; }
        
            public Int64 idfsSampleType { get; set; }
        
            public string strSampleType { get; set; }
        
            public DateTimeWrap datFieldCollectionDate { get; set; }
        
            public Int64? idfSendToOffice { get; set; }
        
            public string strSendToOffice { get; set; }
        
            public Int64? idfFieldCollectedByOffice { get; set; }
        
            public string strFieldCollectedByOffice { get; set; }
        
            public string strNote { get; set; }
        
            public DateTimeWrap datAccession { get; set; }
        
            public Int64? idfsAccessionCondition { get; set; }
        
            public string strAccessionCondition { get; set; }
        
        }
        public partial class VectorSampleGridModelList : List<VectorSampleGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public VectorSampleGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VectorSample>, errMes);
            }
            public VectorSampleGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VectorSample>, errMes);
            }
            public VectorSampleGridModelList(long key, IEnumerable<VectorSample> items)
            {
                LoadGridModelList(key, items, null);
            }
            public VectorSampleGridModelList(long key)
            {
                LoadGridModelList(key, new List<VectorSample>(), null);
            }
            partial void filter(List<VectorSample> items);
            private void LoadGridModelList(long key, IEnumerable<VectorSample> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strVectorID,_str_idfsVectorType,_str_strVectorType,_str_strVectorSubTypeName,_str_strBarcode,_str_strFieldBarcode,_str_idfsSampleType,_str_strSampleType,_str_datFieldCollectionDate,_str_idfSendToOffice,_str_strSendToOffice,_str_idfFieldCollectedByOffice,_str_strFieldCollectedByOffice,_str_strNote,_str_datAccession,_str_idfsAccessionCondition,_str_strAccessionCondition};
                    
                Hiddens = new List<string> {_str_idfMaterial};
                Keys = new List<string> {_str_idfMaterial};
                Labels = new Dictionary<string, string> {{_str_strVectorID, "Vector.strVectorID"},{_str_idfsVectorType, _str_idfsVectorType},{_str_strVectorType, "idfsVectorType"},{_str_strVectorSubTypeName, "idfsVectorSubType"},{_str_strBarcode, "VectorSample.strBarcode"},{_str_strFieldBarcode, "VectorSample.strFieldBarcode"},{_str_idfsSampleType, _str_idfsSampleType},{_str_strSampleType, "idfsSampleType"},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_idfSendToOffice, "strSendToOrganization"},{_str_strSendToOffice, _str_strSendToOffice},{_str_idfFieldCollectedByOffice, "VectorSample.idfFieldCollectedByOffice"},{_str_strFieldCollectedByOffice, "VectorSample.idfFieldCollectedByOffice"},{_str_strNote, "VectorSample.strNote"},{_str_datAccession, _str_datAccession},{_str_idfsAccessionCondition, _str_idfsAccessionCondition},{_str_strAccessionCondition, "idfsAccessionCondition"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                VectorSample.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<VectorSample>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VectorSampleGridModel()
                {
                    ItemKey=c.idfMaterial,strVectorID=c.strVectorID,idfsVectorType=c.idfsVectorType,strVectorType=c.strVectorType,strVectorSubTypeName=c.strVectorSubTypeName,strBarcode=c.strBarcode,strFieldBarcode=c.strFieldBarcode,idfsSampleType=c.idfsSampleType,strSampleType=c.strSampleType,datFieldCollectionDate=c.datFieldCollectionDate,idfSendToOffice=c.idfSendToOffice,strSendToOffice=c.strSendToOffice,idfFieldCollectedByOffice=c.idfFieldCollectedByOffice,strFieldCollectedByOffice=c.strFieldCollectedByOffice,strNote=c.strNote,datAccession=c.datAccession,idfsAccessionCondition=c.idfsAccessionCondition,strAccessionCondition=c.strAccessionCondition
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
            , IObjectCreator<VectorSample>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfMaterial"; } }
            #endregion
        
            public delegate void on_action(VectorSample obj);
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
            private VectorType2SampleTypeLookup.Accessor VectorType2SampleTypeAccessor { get { return eidss.model.Schema.VectorType2SampleTypeLookup.Accessor.Instance(m_CS); } }
            private VectorType2SampleTypeLookup.Accessor VectorType2SampleTypeFilteredAccessor { get { return eidss.model.Schema.VectorType2SampleTypeLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor FieldCollectedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor SendToOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
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
                , Int64? idfVector
                )
            {
                return _SelectList(manager
                    , idfVector
                    , delegate(VectorSample obj)
                        {
                        }
                    , delegate(VectorSample obj)
                        {
                        }
                    );
            }

            

            public List<VectorSample> _SelectList(DbManagerProxy manager
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
      
            
            public virtual List<VectorSample> _SelectListInternal(DbManagerProxy manager
                , Int64? idfVector
                , on_action loading, on_action loaded
                )
            {
                VectorSample _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VectorSample> objs = new List<VectorSample>();
                    sets[0] = new MapResultSet(typeof(VectorSample), objs);
                    
                    manager
                        .SetSpCommand("spVectorSamples_SelectDetail"
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VectorSample obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, VectorSample obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private VectorSample _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                VectorSample obj = null;
                try
                {
                    obj = VectorSample.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfMaterial = (new GetNewIDExtender<VectorSample>()).GetScalar(manager, obj, isFake);
                obj.idfsVectorType = new Func<VectorSample, long>(c => c.ParentVector == null ? c.idfsVectorType : c.ParentVector.idfsVectorType)(obj);
                obj.idfParty = new Func<VectorSample, long?>(c => c.ParentVector == null ? c.idfParty : c.ParentVector.idfVector)(obj);
                obj.idfVectorSurveillanceSession = new Func<VectorSample, long?>(c => c.ParentVector == null ? c.idfVectorSurveillanceSession : c.ParentVector.idfVectorSurveillanceSession)(obj);
                obj.idfsVectorSubType = new Func<VectorSample, long>(c => c.ParentVector == null ? c.idfsVectorSubType : c.ParentVector.idfsVectorSubType)(obj);
                obj.datFieldCollectionDate = new Func<VectorSample, DateTime?>(c => (c.ParentVector != null) && c.isPool  ? c.ParentVector.datCollectionDateTime : DateTime.Now.Date)(obj);
                obj.FieldCollectedByOffice = new Func<VectorSample, OrganizationLookup>(c => (c.ParentVector != null) ? c.ParentVector.CollectedByOffice : c.FieldCollectedByOffice)(obj);
                obj.idfFieldCollectedByOffice = new Func<VectorSample, long?>(c => (c.ParentVector != null) ? c.ParentVector.idfCollectedByOffice : c.idfFieldCollectedByOffice)(obj);
                obj.strVectorSubTypeName = new Func<VectorSample, string>(c => c.ParentVector == null ? c.strVectorSubTypeName : c.ParentVector.strSpecies)(obj);
                obj.strVectorID = new Func<VectorSample, string>(c => c.ParentVector == null ? c.strVectorID : c.ParentVector.strVectorID)(obj);
                obj.idfVector = new Func<VectorSample, long?>(c => c.ParentVector == null ? c.idfVector : c.ParentVector.idfVector)(obj);
                obj.Used = new Func<VectorSample, int>(c => 0)(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                  if ((obj.ParentVector != null) && (obj.ParentVector.IsPoolVectorType) && (obj.VectorType2SampleTypeLookup != null) && (obj.VectorType2SampleTypeLookup.Count > 1)) obj.VectorType2SampleType = obj.VectorType2SampleTypeLookup[1];
                
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

            
            public VectorSample CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VectorSample CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
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
                
                return Create(manager, Parent
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public VectorSample Create(DbManagerProxy manager, IObject Parent
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
            
            public ActResult ViewOnDetailForm(DbManagerProxy manager, VectorSample obj, List<object> pars)
            {
                
                return ViewOnDetailForm(manager, obj
                    );
            }
            public ActResult ViewOnDetailForm(DbManagerProxy manager, VectorSample obj
                )
            {
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(VectorSample obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VectorSample obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
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
                    
                        if (e.PropertyName == _str_datFieldSentDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datFieldSentDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datAccession)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datAccession);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsSampleType)
                        {
                    
                obj.strSampleName = new Func<VectorSample, string>(c => { var st = c.VectorType2SampleTypeLookup.FirstOrDefault(s => s.idfsSampleType == c.idfsSampleType); return st != null ? st.SampleName : String.Empty;})(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSampleType)
                        {
                    
                obj.VectorType2SampleTypeFiltered = new Func<VectorSample, VectorType2SampleTypeLookup>(c => c.VectorType2SampleTypeLookup.Where(x => x.idfsSampleType == c.idfsSampleType).FirstOrDefault())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfVector)
                        {
                    
                obj.idfParty = new Func<VectorSample, long?>(c => c.idfVector.HasValue ? c.idfVector : c.idfParty)(obj);
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
                    
                        if (e.PropertyName == _str_idfFieldCollectedByOffice)
                        {
                    
                obj.FieldCollectedByOffice = new Func<VectorSample, OrganizationLookup>(c => c.FieldCollectedByOfficeLookup.Where(x => x.idfInstitution == c.idfFieldCollectedByOffice).FirstOrDefault())(obj);
                        }
                    
                        if (e.PropertyName == _str_idfSendToOffice)
                        {
                    
                obj.strSendToOffice = new Func<VectorSample, string>(c => { var st = c.SendToOfficeLookup.FirstOrDefault(s => s.idfInstitution == c.idfSendToOffice); return st != null ? st.name : String.Empty;})(obj);
                        }
                    
                        if (e.PropertyName == _str_datFieldCollectionDate)
                        {
                    
                if (obj.FieldTests != null) 
                    obj.FieldTests.ForEach(t => { t.datFieldCollectionDate = new Func<VectorSample, DateTime?>(c => c.idfMaterial == t.idfMaterial ? c.datFieldCollectionDate : t.datFieldCollectionDate)(obj); } );
                        }
                    
                        if (e.PropertyName == _str_idfsSampleType)
                        {
                    
                if (obj.FieldTests != null) 
                    obj.FieldTests.ForEach(t => { t.strSampleName = new Func<VectorSample, string>(c => c.idfMaterial == t.idfMaterial ? c.strSampleName : t.strSampleName)(obj); } );
                        }
                    
                    };
                
            }
    
            public void LoadLookup_VectorType2SampleType(DbManagerProxy manager, VectorSample obj)
            {
                
                obj.VectorType2SampleTypeLookup.Clear();
                
                obj.VectorType2SampleTypeLookup.Add(VectorType2SampleTypeAccessor.CreateNewT(manager, null));
                
                obj.VectorType2SampleTypeLookup.AddRange(VectorType2SampleTypeAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsVectorType == (obj.idfsVectorType != 0 ? obj.idfsVectorType : c.idfsVectorType))
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSampleType == obj.idfsSampleType))
                    
                    .ToList());
                
                if (obj.idfsSampleType != 0)
                {
                    obj.VectorType2SampleType = obj.VectorType2SampleTypeLookup
                        .SingleOrDefault(c => c.idfsSampleType == obj.idfsSampleType);
                    
                }
              
                LookupManager.AddObject("VectorType2SampleTypeLookup", obj, VectorType2SampleTypeAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_VectorType2SampleTypeFiltered(DbManagerProxy manager, VectorSample obj)
            {
                
                obj.VectorType2SampleTypeFilteredLookup.Clear();
                
                obj.VectorType2SampleTypeFilteredLookup.Add(VectorType2SampleTypeFilteredAccessor.CreateNewT(manager, null));
                
                obj.VectorType2SampleTypeFilteredLookup.AddRange(VectorType2SampleTypeFilteredAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.idfsVectorType == (obj.idfsVectorType != 0 ? obj.idfsVectorType : -1))
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSampleType == obj.idfsSampleType))
                    
                    .ToList());
                
                if (obj.idfsSampleType != 0)
                {
                    obj.VectorType2SampleTypeFiltered = obj.VectorType2SampleTypeFilteredLookup
                        .SingleOrDefault(c => c.idfsSampleType == obj.idfsSampleType);
                    
                }
              
                LookupManager.AddObject("VectorType2SampleTypeLookup", obj, VectorType2SampleTypeFilteredAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_FieldCollectedByOffice(DbManagerProxy manager, VectorSample obj)
            {
                
                obj.FieldCollectedByOfficeLookup.Clear();
                
                obj.FieldCollectedByOfficeLookup.Add(FieldCollectedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.FieldCollectedByOfficeLookup.AddRange(FieldCollectedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (((c.intHACode??0) & (int)HACode.Vector) != 0) || c.idfInstitution == obj.idfFieldCollectedByOffice)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfFieldCollectedByOffice))
                    
                    .ToList());
                
                if (obj.idfFieldCollectedByOffice != null && obj.idfFieldCollectedByOffice != 0)
                {
                    obj.FieldCollectedByOffice = obj.FieldCollectedByOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfFieldCollectedByOffice);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, FieldCollectedByOfficeAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_SendToOffice(DbManagerProxy manager, VectorSample obj)
            {
                
                obj.SendToOfficeLookup.Clear();
                
                obj.SendToOfficeLookup.Add(SendToOfficeAccessor.CreateNewT(manager, null));
                
                obj.SendToOfficeLookup.AddRange(SendToOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (((c.intHACode??0) & (int)HACode.Vector) != 0) || c.idfInstitution == obj.idfSendToOffice)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfSendToOffice))
                    
                    .ToList());
                
                if (obj.idfSendToOffice != null && obj.idfSendToOffice != 0)
                {
                    obj.SendToOffice = obj.SendToOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfSendToOffice);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, SendToOfficeAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
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
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsAccessionCondition);
                    
                }
              
                LookupManager.AddObject("rftAccessionCondition", obj, AccessionConditionAccessor.GetType(), "rftAccessionCondition_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
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
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsVectorType);
                    
                }
              
                LookupManager.AddObject("rftVectorType", obj, VectorTypeAccessor.GetType(), "rftVectorType_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
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
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsVectorSubType);
                    
                }
              
                LookupManager.AddObject("rftVectorSubType", obj, VectorSubTypeAccessor.GetType(), "rftVectorSubType_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
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
                        .SingleOrDefault(c => c.idfsRegion == obj.idfsRegion);
                    
                }
              
                LookupManager.AddObject("RegionLookup", obj, RegionAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
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
                        .SingleOrDefault(c => c.idfsRayon == obj.idfsRayon);
                    
                }
              
                LookupManager.AddObject("RayonLookup", obj, RayonAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, VectorSample obj)
            {
                
                LoadLookup_VectorType2SampleType(manager, obj);
                
                LoadLookup_VectorType2SampleTypeFiltered(manager, obj);
                
                LoadLookup_FieldCollectedByOffice(manager, obj);
                
                LoadLookup_SendToOffice(manager, obj);
                
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
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        VectorSample bo = obj as VectorSample;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as VectorSample, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VectorSample obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
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
                //obj.AcceptChanges();
                
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
        
      
            protected ValidationModelException ChainsValidate(VectorSample obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<VectorSample>(obj, "datFieldCollectionDate", c => true, 
      obj.datFieldCollectionDate,
      obj.GetType(),
      false, listdatFieldCollectionDate => {
    listdatFieldCollectionDate.Add(
    new ChainsValidatorDateTime<VectorSample>(obj, "datFieldSentDate", c => true, 
      obj.datFieldSentDate,
      obj.GetType(),
      false, listdatFieldSentDate => {
    listdatFieldSentDate.Add(
    new ChainsValidatorDateTime<VectorSample>(obj, "datAccession", c => true, 
      obj.datAccession,
      obj.GetType(),
      false, listdatAccession => {
    listdatAccession.Add(
    new ChainsValidatorDateTime<VectorSample>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
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
            protected bool ChainsValidate(VectorSample obj, bool bRethrowException)
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
                return Validate(manager, obj as VectorSample, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VectorSample obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "strFieldBarcode", "strFieldBarcode","VectorSample.strFieldBarcode",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.strFieldBarcode);
            
                (new RequiredValidator( "idfsSampleType", "idfsSampleType","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsSampleType);
            
                (new RequiredValidator( "idfParty", "idfParty","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfParty);
            
                (new RequiredValidator( "VectorType2SampleTypeFiltered", "VectorType2SampleTypeFiltered","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.VectorType2SampleTypeFiltered);
            
                (new RequiredValidator( "idfFieldCollectedByOffice", "idfFieldCollectedByOffice","VectorSample.idfFieldCollectedByOffice",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfFieldCollectedByOffice);
            
                (new RequiredValidator( "strFieldCollectedByOffice", "strFieldCollectedByOffice","VectorSample.idfFieldCollectedByOffice",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.strFieldCollectedByOffice);
            
                CustomValidations(obj);
            
            (new CustomMandatoryFieldValidator("idfSendToOffice", "idfSendToOffice", "VetCaseSample.idfSendToOffice",
            ValidationEventType.Error
            )).Validate(obj, obj.idfSendToOffice, CustomMandatoryField.VsSessionSample_SentTo,
            c => true);

          
            (new CustomMandatoryFieldValidator("strSendToOffice", "strSendToOffice", "VetCaseSample.idfSendToOffice",
            ValidationEventType.Error
            )).Validate(obj, obj.strSendToOffice, CustomMandatoryField.VsSessionSample_SentTo,
            c => true);

          
                  
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
           
    
            private void _SetupRequired(VectorSample obj)
            {
            
                obj
                    .AddRequired("strFieldBarcode", c => true);
                    
                obj
                    .AddRequired("idfsSampleType", c => true);
                    
                  obj
                    .AddRequired("VectorType2SampleType", c => true);
                
                obj
                    .AddRequired("idfParty", c => true);
                    
                obj
                    .AddRequired("VectorType2SampleTypeFiltered", c => true);
                    
                obj
                    .AddRequired("idfFieldCollectedByOffice", c => true);
                    
                  obj
                    .AddRequired("FieldCollectedByOffice", c => true);
                
                obj
                    .AddRequired("strFieldCollectedByOffice", c => true);
                    
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VsSessionSample_SentTo)  && new Func<VectorSample, bool>(c => true)(obj))
              {
                obj
                  .AddRequired("idfSendToOffice", c => true);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VsSessionSample_SentTo)  && new Func<VectorSample, bool>(c => true)(obj))
              {
                obj
                  .AddRequired("strSendToOffice", c => true);
                
                }
            
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
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
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
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VectorSample, bool>> RequiredByField = new Dictionary<string, Func<VectorSample, bool>>();
            public static Dictionary<string, Func<VectorSample, bool>> RequiredByProperty = new Dictionary<string, Func<VectorSample, bool>>();
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
                
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strSampleName, 2000);
                Sizes.Add(_str_strSendToOffice, 2000);
                Sizes.Add(_str_strNote, 500);
                Sizes.Add(_str_strVectorTypeName, 2000);
                Sizes.Add(_str_strVectorSubTypeName, 2000);
                Sizes.Add(_str_strRegionName, 300);
                Sizes.Add(_str_strRayonName, 300);
                Sizes.Add(_str_strVectorID, 50);
                if (!RequiredByField.ContainsKey("strFieldBarcode")) RequiredByField.Add("strFieldBarcode", c => true);
                if (!RequiredByProperty.ContainsKey("strFieldBarcode")) RequiredByProperty.Add("strFieldBarcode", c => true);
                
                if (!RequiredByField.ContainsKey("idfsSampleType")) RequiredByField.Add("idfsSampleType", c => true);
                if (!RequiredByProperty.ContainsKey("idfsSampleType")) RequiredByProperty.Add("idfsSampleType", c => true);
                
                if (!RequiredByField.ContainsKey("idfParty")) RequiredByField.Add("idfParty", c => true);
                if (!RequiredByProperty.ContainsKey("idfParty")) RequiredByProperty.Add("idfParty", c => true);
                
                if (!RequiredByField.ContainsKey("VectorType2SampleTypeFiltered")) RequiredByField.Add("VectorType2SampleTypeFiltered", c => true);
                if (!RequiredByProperty.ContainsKey("VectorType2SampleTypeFiltered")) RequiredByProperty.Add("VectorType2SampleTypeFiltered", c => true);
                
                if (!RequiredByField.ContainsKey("idfFieldCollectedByOffice")) RequiredByField.Add("idfFieldCollectedByOffice", c => true);
                if (!RequiredByProperty.ContainsKey("idfFieldCollectedByOffice")) RequiredByProperty.Add("idfFieldCollectedByOffice", c => true);
                
                if (!RequiredByField.ContainsKey("strFieldCollectedByOffice")) RequiredByField.Add("strFieldCollectedByOffice", c => true);
                if (!RequiredByProperty.ContainsKey("strFieldCollectedByOffice")) RequiredByProperty.Add("strFieldCollectedByOffice", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfMaterial,
                    _str_idfMaterial, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorID,
                    "Vector.strVectorID", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsVectorType,
                    _str_idfsVectorType, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorType,
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
                    _str_idfsSampleType,
                    _str_idfsSampleType, null, true, true, true, true, true, null
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
                    _str_idfSendToOffice,
                    "strSendToOrganization", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSendToOffice,
                    _str_strSendToOffice, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfFieldCollectedByOffice,
                    "VectorSample.idfFieldCollectedByOffice", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldCollectedByOffice,
                    "VectorSample.idfFieldCollectedByOffice", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNote,
                    "VectorSample.strNote", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datAccession,
                    _str_datAccession, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsAccessionCondition,
                    _str_idfsAccessionCondition, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAccessionCondition,
                    "idfsAccessionCondition", null, false, true, true, true, true, null
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
                    
                    (manager, c, pars) => Accessor.Instance(null).ViewOnDetailForm(manager, (VectorSample)c, pars),
                        
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
                    (c, p, b) => c != null && !c.Key.Equals(PredefinedObjectId.FakeListObject),
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
	