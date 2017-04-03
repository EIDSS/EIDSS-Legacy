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
    public abstract partial class Vector : 
        EditableObject<Vector>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfVector), NonUpdatable, PrimaryKey]
        public abstract Int64 idfVector { get; set; }
                
        [LocalizedDisplayName(_str_idfVectorSurveillanceSession)]
        [MapField(_str_idfVectorSurveillanceSession)]
        public abstract Int64 idfVectorSurveillanceSession { get; set; }
        #if MONO
        protected Int64 idfVectorSurveillanceSession_Original { get { return idfVectorSurveillanceSession; } }
        protected Int64 idfVectorSurveillanceSession_Previous { get { return idfVectorSurveillanceSession; } }
        #else
        protected Int64 idfVectorSurveillanceSession_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfVectorSurveillanceSession).OriginalValue; } }
        protected Int64 idfVectorSurveillanceSession_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfVectorSurveillanceSession).PreviousValue; } }
        #endif
                
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
        [MapField(_str_strVectorType)]
        public abstract String strVectorType { get; set; }
        #if MONO
        protected String strVectorType_Original { get { return strVectorType; } }
        protected String strVectorType_Previous { get { return strVectorType; } }
        #else
        protected String strVectorType_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).OriginalValue; } }
        protected String strVectorType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfSpecies")]
        [MapField(_str_idfsVectorSubType)]
        public abstract Int64 idfsVectorSubType { get; set; }
        #if MONO
        protected Int64 idfsVectorSubType_Original { get { return idfsVectorSubType; } }
        protected Int64 idfsVectorSubType_Previous { get { return idfsVectorSubType; } }
        #else
        protected Int64 idfsVectorSubType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSubType).OriginalValue; } }
        protected Int64 idfsVectorSubType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSubType).PreviousValue; } }
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
                
        [LocalizedDisplayName("Vector.strFieldVectorID")]
        [MapField(_str_strFieldVectorID)]
        public abstract String strFieldVectorID { get; set; }
        #if MONO
        protected String strFieldVectorID_Original { get { return strFieldVectorID; } }
        protected String strFieldVectorID_Previous { get { return strFieldVectorID; } }
        #else
        protected String strFieldVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldVectorID).OriginalValue; } }
        protected String strFieldVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldVectorID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfHostVector)]
        [MapField(_str_idfHostVector)]
        public abstract Int64? idfHostVector { get; set; }
        #if MONO
        protected Int64? idfHostVector_Original { get { return idfHostVector; } }
        protected Int64? idfHostVector_Previous { get { return idfHostVector; } }
        #else
        protected Int64? idfHostVector_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHostVector).OriginalValue; } }
        protected Int64? idfHostVector_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHostVector).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfHostVector")]
        [MapField(_str_strHostVector)]
        public abstract String strHostVector { get; set; }
        #if MONO
        protected String strHostVector_Original { get { return strHostVector; } }
        protected String strHostVector_Previous { get { return strHostVector; } }
        #else
        protected String strHostVector_Original { get { return ((EditableValue<String>)((dynamic)this)._strHostVector).OriginalValue; } }
        protected String strHostVector_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHostVector).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsCountry)]
        [MapField(_str_idfsCountry)]
        public abstract Int64? idfsCountry { get; set; }
        #if MONO
        protected Int64? idfsCountry_Original { get { return idfsCountry; } }
        protected Int64? idfsCountry_Previous { get { return idfsCountry; } }
        #else
        protected Int64? idfsCountry_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).OriginalValue; } }
        protected Int64? idfsCountry_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsCountry")]
        [MapField(_str_strCountry)]
        public abstract String strCountry { get; set; }
        #if MONO
        protected String strCountry_Original { get { return strCountry; } }
        protected String strCountry_Previous { get { return strCountry; } }
        #else
        protected String strCountry_Original { get { return ((EditableValue<String>)((dynamic)this)._strCountry).OriginalValue; } }
        protected String strCountry_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCountry).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strRegion)]
        [MapField(_str_strRegion)]
        public abstract String strRegion { get; set; }
        #if MONO
        protected String strRegion_Original { get { return strRegion; } }
        protected String strRegion_Previous { get { return strRegion; } }
        #else
        protected String strRegion_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegion).OriginalValue; } }
        protected String strRegion_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegion).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strRayon)]
        [MapField(_str_strRayon)]
        public abstract String strRayon { get; set; }
        #if MONO
        protected String strRayon_Original { get { return strRayon; } }
        protected String strRayon_Previous { get { return strRayon; } }
        #else
        protected String strRayon_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayon).OriginalValue; } }
        protected String strRayon_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayon).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSettlement)]
        [MapField(_str_idfsSettlement)]
        public abstract Int64? idfsSettlement { get; set; }
        #if MONO
        protected Int64? idfsSettlement_Original { get { return idfsSettlement; } }
        protected Int64? idfsSettlement_Previous { get { return idfsSettlement; } }
        #else
        protected Int64? idfsSettlement_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).OriginalValue; } }
        protected Int64? idfsSettlement_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("Vector.strSettlement")]
        [MapField(_str_strSettlement)]
        public abstract String strSettlement { get; set; }
        #if MONO
        protected String strSettlement_Original { get { return strSettlement; } }
        protected String strSettlement_Previous { get { return strSettlement; } }
        #else
        protected String strSettlement_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).OriginalValue; } }
        protected String strSettlement_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intElevation)]
        [MapField(_str_intElevation)]
        public abstract Int32? intElevation { get; set; }
        #if MONO
        protected Int32? intElevation_Original { get { return intElevation; } }
        protected Int32? intElevation_Previous { get { return intElevation; } }
        #else
        protected Int32? intElevation_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intElevation).OriginalValue; } }
        protected Int32? intElevation_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intElevation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSurrounding)]
        [MapField(_str_idfsSurrounding)]
        public abstract Int64? idfsSurrounding { get; set; }
        #if MONO
        protected Int64? idfsSurrounding_Original { get { return idfsSurrounding; } }
        protected Int64? idfsSurrounding_Previous { get { return idfsSurrounding; } }
        #else
        protected Int64? idfsSurrounding_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSurrounding).OriginalValue; } }
        protected Int64? idfsSurrounding_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSurrounding).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSurrounding)]
        [MapField(_str_strSurrounding)]
        public abstract String strSurrounding { get; set; }
        #if MONO
        protected String strSurrounding_Original { get { return strSurrounding; } }
        protected String strSurrounding_Previous { get { return strSurrounding; } }
        #else
        protected String strSurrounding_Original { get { return ((EditableValue<String>)((dynamic)this)._strSurrounding).OriginalValue; } }
        protected String strSurrounding_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSurrounding).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strGEOReferenceSources)]
        [MapField(_str_strGEOReferenceSources)]
        public abstract String strGEOReferenceSources { get; set; }
        #if MONO
        protected String strGEOReferenceSources_Original { get { return strGEOReferenceSources; } }
        protected String strGEOReferenceSources_Previous { get { return strGEOReferenceSources; } }
        #else
        protected String strGEOReferenceSources_Original { get { return ((EditableValue<String>)((dynamic)this)._strGEOReferenceSources).OriginalValue; } }
        protected String strGEOReferenceSources_Previous { get { return ((EditableValue<String>)((dynamic)this)._strGEOReferenceSources).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfCollectedByOffice)]
        [MapField(_str_idfCollectedByOffice)]
        public abstract Int64 idfCollectedByOffice { get; set; }
        #if MONO
        protected Int64 idfCollectedByOffice_Original { get { return idfCollectedByOffice; } }
        protected Int64 idfCollectedByOffice_Previous { get { return idfCollectedByOffice; } }
        #else
        protected Int64 idfCollectedByOffice_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfCollectedByOffice).OriginalValue; } }
        protected Int64 idfCollectedByOffice_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfCollectedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("VectorSample.idfFieldCollectedByOffice")]
        [MapField(_str_strCollectedByOffice)]
        public abstract String strCollectedByOffice { get; set; }
        #if MONO
        protected String strCollectedByOffice_Original { get { return strCollectedByOffice; } }
        protected String strCollectedByOffice_Previous { get { return strCollectedByOffice; } }
        #else
        protected String strCollectedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByOffice).OriginalValue; } }
        protected String strCollectedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfCollectedByPerson)]
        [MapField(_str_idfCollectedByPerson)]
        public abstract Int64? idfCollectedByPerson { get; set; }
        #if MONO
        protected Int64? idfCollectedByPerson_Original { get { return idfCollectedByPerson; } }
        protected Int64? idfCollectedByPerson_Previous { get { return idfCollectedByPerson; } }
        #else
        protected Int64? idfCollectedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCollectedByPerson).OriginalValue; } }
        protected Int64? idfCollectedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCollectedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("Vector.idfFieldCollectedByPerson")]
        [MapField(_str_strCollectedByPerson)]
        public abstract String strCollectedByPerson { get; set; }
        #if MONO
        protected String strCollectedByPerson_Original { get { return strCollectedByPerson; } }
        protected String strCollectedByPerson_Previous { get { return strCollectedByPerson; } }
        #else
        protected String strCollectedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByPerson).OriginalValue; } }
        protected String strCollectedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("datFieldCollectionDate")]
        [MapField(_str_datCollectionDateTime)]
        public abstract DateTime datCollectionDateTime { get; set; }
        #if MONO
        protected DateTime datCollectionDateTime_Original { get { return datCollectionDateTime; } }
        protected DateTime datCollectionDateTime_Previous { get { return datCollectionDateTime; } }
        #else
        protected DateTime datCollectionDateTime_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datCollectionDateTime).OriginalValue; } }
        protected DateTime datCollectionDateTime_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datCollectionDateTime).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCollectionMethod)]
        [MapField(_str_idfsCollectionMethod)]
        public abstract Int64? idfsCollectionMethod { get; set; }
        #if MONO
        protected Int64? idfsCollectionMethod_Original { get { return idfsCollectionMethod; } }
        protected Int64? idfsCollectionMethod_Previous { get { return idfsCollectionMethod; } }
        #else
        protected Int64? idfsCollectionMethod_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCollectionMethod).OriginalValue; } }
        protected Int64? idfsCollectionMethod_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCollectionMethod).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCollectionMethod)]
        [MapField(_str_strCollectionMethod)]
        public abstract String strCollectionMethod { get; set; }
        #if MONO
        protected String strCollectionMethod_Original { get { return strCollectionMethod; } }
        protected String strCollectionMethod_Previous { get { return strCollectionMethod; } }
        #else
        protected String strCollectionMethod_Original { get { return ((EditableValue<String>)((dynamic)this)._strCollectionMethod).OriginalValue; } }
        protected String strCollectionMethod_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCollectionMethod).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsBasisOfRecord)]
        [MapField(_str_idfsBasisOfRecord)]
        public abstract Int64? idfsBasisOfRecord { get; set; }
        #if MONO
        protected Int64? idfsBasisOfRecord_Original { get { return idfsBasisOfRecord; } }
        protected Int64? idfsBasisOfRecord_Previous { get { return idfsBasisOfRecord; } }
        #else
        protected Int64? idfsBasisOfRecord_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBasisOfRecord).OriginalValue; } }
        protected Int64? idfsBasisOfRecord_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBasisOfRecord).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strBasisOfRecord)]
        [MapField(_str_strBasisOfRecord)]
        public abstract String strBasisOfRecord { get; set; }
        #if MONO
        protected String strBasisOfRecord_Original { get { return strBasisOfRecord; } }
        protected String strBasisOfRecord_Previous { get { return strBasisOfRecord; } }
        #else
        protected String strBasisOfRecord_Original { get { return ((EditableValue<String>)((dynamic)this)._strBasisOfRecord).OriginalValue; } }
        protected String strBasisOfRecord_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBasisOfRecord).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsSex)]
        [MapField(_str_idfsSex)]
        public abstract Int64? idfsSex { get; set; }
        #if MONO
        protected Int64? idfsSex_Original { get { return idfsSex; } }
        protected Int64? idfsSex_Previous { get { return idfsSex; } }
        #else
        protected Int64? idfsSex_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSex).OriginalValue; } }
        protected Int64? idfsSex_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSex).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsAnimalGender")]
        [MapField(_str_strSex)]
        public abstract String strSex { get; set; }
        #if MONO
        protected String strSex_Original { get { return strSex; } }
        protected String strSex_Previous { get { return strSex; } }
        #else
        protected String strSex_Original { get { return ((EditableValue<String>)((dynamic)this)._strSex).OriginalValue; } }
        protected String strSex_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSex).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfIdentifiedByOffice)]
        [MapField(_str_idfIdentifiedByOffice)]
        public abstract Int64? idfIdentifiedByOffice { get; set; }
        #if MONO
        protected Int64? idfIdentifiedByOffice_Original { get { return idfIdentifiedByOffice; } }
        protected Int64? idfIdentifiedByOffice_Previous { get { return idfIdentifiedByOffice; } }
        #else
        protected Int64? idfIdentifiedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfIdentifiedByOffice).OriginalValue; } }
        protected Int64? idfIdentifiedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfIdentifiedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strIdentifiedByOffice)]
        [MapField(_str_strIdentifiedByOffice)]
        public abstract String strIdentifiedByOffice { get; set; }
        #if MONO
        protected String strIdentifiedByOffice_Original { get { return strIdentifiedByOffice; } }
        protected String strIdentifiedByOffice_Previous { get { return strIdentifiedByOffice; } }
        #else
        protected String strIdentifiedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strIdentifiedByOffice).OriginalValue; } }
        protected String strIdentifiedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strIdentifiedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfIdentifiedByPerson)]
        [MapField(_str_idfIdentifiedByPerson)]
        public abstract Int64? idfIdentifiedByPerson { get; set; }
        #if MONO
        protected Int64? idfIdentifiedByPerson_Original { get { return idfIdentifiedByPerson; } }
        protected Int64? idfIdentifiedByPerson_Previous { get { return idfIdentifiedByPerson; } }
        #else
        protected Int64? idfIdentifiedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfIdentifiedByPerson).OriginalValue; } }
        protected Int64? idfIdentifiedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfIdentifiedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strIdentifiedByPerson)]
        [MapField(_str_strIdentifiedByPerson)]
        public abstract String strIdentifiedByPerson { get; set; }
        #if MONO
        protected String strIdentifiedByPerson_Original { get { return strIdentifiedByPerson; } }
        protected String strIdentifiedByPerson_Previous { get { return strIdentifiedByPerson; } }
        #else
        protected String strIdentifiedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strIdentifiedByPerson).OriginalValue; } }
        protected String strIdentifiedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strIdentifiedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datIdentifiedDateTime)]
        [MapField(_str_datIdentifiedDateTime)]
        public abstract DateTime? datIdentifiedDateTime { get; set; }
        #if MONO
        protected DateTime? datIdentifiedDateTime_Original { get { return datIdentifiedDateTime; } }
        protected DateTime? datIdentifiedDateTime_Previous { get { return datIdentifiedDateTime; } }
        #else
        protected DateTime? datIdentifiedDateTime_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datIdentifiedDateTime).OriginalValue; } }
        protected DateTime? datIdentifiedDateTime_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datIdentifiedDateTime).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsIdentificationMethod)]
        [MapField(_str_idfsIdentificationMethod)]
        public abstract Int64? idfsIdentificationMethod { get; set; }
        #if MONO
        protected Int64? idfsIdentificationMethod_Original { get { return idfsIdentificationMethod; } }
        protected Int64? idfsIdentificationMethod_Previous { get { return idfsIdentificationMethod; } }
        #else
        protected Int64? idfsIdentificationMethod_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsIdentificationMethod).OriginalValue; } }
        protected Int64? idfsIdentificationMethod_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsIdentificationMethod).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strIdentificationMethod)]
        [MapField(_str_strIdentificationMethod)]
        public abstract String strIdentificationMethod { get; set; }
        #if MONO
        protected String strIdentificationMethod_Original { get { return strIdentificationMethod; } }
        protected String strIdentificationMethod_Previous { get { return strIdentificationMethod; } }
        #else
        protected String strIdentificationMethod_Original { get { return ((EditableValue<String>)((dynamic)this)._strIdentificationMethod).OriginalValue; } }
        protected String strIdentificationMethod_Previous { get { return ((EditableValue<String>)((dynamic)this)._strIdentificationMethod).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfObservation)]
        [MapField(_str_idfObservation)]
        public abstract Int64? idfObservation { get; set; }
        #if MONO
        protected Int64? idfObservation_Original { get { return idfObservation; } }
        protected Int64? idfObservation_Previous { get { return idfObservation; } }
        #else
        protected Int64? idfObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObservation).OriginalValue; } }
        protected Int64? idfObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObservation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64? idfsFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsFormTemplate_Original { get { return idfsFormTemplate; } }
        protected Int64? idfsFormTemplate_Previous { get { return idfsFormTemplate; } }
        #else
        protected Int64? idfsFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64? idfsFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("VsSessionListItem.dblLatitude")]
        [MapField(_str_dblLatitude)]
        public abstract Double? dblLatitude { get; set; }
        #if MONO
        protected Double? dblLatitude_Original { get { return dblLatitude; } }
        protected Double? dblLatitude_Previous { get { return dblLatitude; } }
        #else
        protected Double? dblLatitude_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblLatitude).OriginalValue; } }
        protected Double? dblLatitude_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblLatitude).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("VsSessionListItem.dblLongitude")]
        [MapField(_str_dblLongitude)]
        public abstract Double? dblLongitude { get; set; }
        #if MONO
        protected Double? dblLongitude_Original { get { return dblLongitude; } }
        protected Double? dblLongitude_Previous { get { return dblLongitude; } }
        #else
        protected Double? dblLongitude_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblLongitude).OriginalValue; } }
        protected Double? dblLongitude_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblLongitude).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsDayPeriod)]
        [MapField(_str_idfsDayPeriod)]
        public abstract Int64? idfsDayPeriod { get; set; }
        #if MONO
        protected Int64? idfsDayPeriod_Original { get { return idfsDayPeriod; } }
        protected Int64? idfsDayPeriod_Previous { get { return idfsDayPeriod; } }
        #else
        protected Int64? idfsDayPeriod_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDayPeriod).OriginalValue; } }
        protected Int64? idfsDayPeriod_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDayPeriod).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strDayPeriod)]
        [MapField(_str_strDayPeriod)]
        public abstract String strDayPeriod { get; set; }
        #if MONO
        protected String strDayPeriod_Original { get { return strDayPeriod; } }
        protected String strDayPeriod_Previous { get { return strDayPeriod; } }
        #else
        protected String strDayPeriod_Original { get { return ((EditableValue<String>)((dynamic)this)._strDayPeriod).OriginalValue; } }
        protected String strDayPeriod_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDayPeriod).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSpecies)]
        [MapField(_str_strSpecies)]
        public abstract String strSpecies { get; set; }
        #if MONO
        protected String strSpecies_Original { get { return strSpecies; } }
        protected String strSpecies_Previous { get { return strSpecies; } }
        #else
        protected String strSpecies_Original { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).OriginalValue; } }
        protected String strSpecies_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("Vector.strComment")]
        [MapField(_str_strComment)]
        public abstract String strComment { get; set; }
        #if MONO
        protected String strComment_Original { get { return strComment; } }
        protected String strComment_Previous { get { return strComment; } }
        #else
        protected String strComment_Original { get { return ((EditableValue<String>)((dynamic)this)._strComment).OriginalValue; } }
        protected String strComment_Previous { get { return ((EditableValue<String>)((dynamic)this)._strComment).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsEctoparasitesCollected)]
        [MapField(_str_idfsEctoparasitesCollected)]
        public abstract Int64? idfsEctoparasitesCollected { get; set; }
        #if MONO
        protected Int64? idfsEctoparasitesCollected_Original { get { return idfsEctoparasitesCollected; } }
        protected Int64? idfsEctoparasitesCollected_Previous { get { return idfsEctoparasitesCollected; } }
        #else
        protected Int64? idfsEctoparasitesCollected_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEctoparasitesCollected).OriginalValue; } }
        protected Int64? idfsEctoparasitesCollected_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEctoparasitesCollected).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strEctoparasitesCollected)]
        [MapField(_str_strEctoparasitesCollected)]
        public abstract String strEctoparasitesCollected { get; set; }
        #if MONO
        protected String strEctoparasitesCollected_Original { get { return strEctoparasitesCollected; } }
        protected String strEctoparasitesCollected_Previous { get { return strEctoparasitesCollected; } }
        #else
        protected String strEctoparasitesCollected_Original { get { return ((EditableValue<String>)((dynamic)this)._strEctoparasitesCollected).OriginalValue; } }
        protected String strEctoparasitesCollected_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEctoparasitesCollected).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<Vector, object> _get_func;
            internal Action<Vector, string> _set_func;
            internal Action<Vector, Vector, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfVector = "idfVector";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_strSessionID = "strSessionID";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_strVectorType = "strVectorType";
        internal const string _str_idfsVectorSubType = "idfsVectorSubType";
        internal const string _str_strVectorID = "strVectorID";
        internal const string _str_strFieldVectorID = "strFieldVectorID";
        internal const string _str_idfHostVector = "idfHostVector";
        internal const string _str_strHostVector = "strHostVector";
        internal const string _str_idfLocation = "idfLocation";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_strCountry = "strCountry";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_strRegion = "strRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_strRayon = "strRayon";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_strSettlement = "strSettlement";
        internal const string _str_intElevation = "intElevation";
        internal const string _str_idfsSurrounding = "idfsSurrounding";
        internal const string _str_strSurrounding = "strSurrounding";
        internal const string _str_strGEOReferenceSources = "strGEOReferenceSources";
        internal const string _str_idfCollectedByOffice = "idfCollectedByOffice";
        internal const string _str_strCollectedByOffice = "strCollectedByOffice";
        internal const string _str_idfCollectedByPerson = "idfCollectedByPerson";
        internal const string _str_strCollectedByPerson = "strCollectedByPerson";
        internal const string _str_datCollectionDateTime = "datCollectionDateTime";
        internal const string _str_idfsCollectionMethod = "idfsCollectionMethod";
        internal const string _str_strCollectionMethod = "strCollectionMethod";
        internal const string _str_idfsBasisOfRecord = "idfsBasisOfRecord";
        internal const string _str_strBasisOfRecord = "strBasisOfRecord";
        internal const string _str_intQuantity = "intQuantity";
        internal const string _str_idfsSex = "idfsSex";
        internal const string _str_strSex = "strSex";
        internal const string _str_idfIdentifiedByOffice = "idfIdentifiedByOffice";
        internal const string _str_strIdentifiedByOffice = "strIdentifiedByOffice";
        internal const string _str_idfIdentifiedByPerson = "idfIdentifiedByPerson";
        internal const string _str_strIdentifiedByPerson = "strIdentifiedByPerson";
        internal const string _str_datIdentifiedDateTime = "datIdentifiedDateTime";
        internal const string _str_idfsIdentificationMethod = "idfsIdentificationMethod";
        internal const string _str_strIdentificationMethod = "strIdentificationMethod";
        internal const string _str_idfObservation = "idfObservation";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_dblLatitude = "dblLatitude";
        internal const string _str_dblLongitude = "dblLongitude";
        internal const string _str_idfsDayPeriod = "idfsDayPeriod";
        internal const string _str_strDayPeriod = "strDayPeriod";
        internal const string _str_strSpecies = "strSpecies";
        internal const string _str_strComment = "strComment";
        internal const string _str_idfsEctoparasitesCollected = "idfsEctoparasitesCollected";
        internal const string _str_strEctoparasitesCollected = "strEctoparasitesCollected";
        internal const string _str_Vectors = "Vectors";
        internal const string _str_Samples = "Samples";
        internal const string _str_FieldTests = "FieldTests";
        internal const string _str_LabTests = "LabTests";
        internal const string _str_HostVector = "HostVector";
        internal const string _str_strVectorSpecificData = "strVectorSpecificData";
        internal const string _str_IsPoolVectorType = "IsPoolVectorType";
        internal const string _str_CollectedByOffice = "CollectedByOffice";
        internal const string _str_IdentifiedByOffice = "IdentifiedByOffice";
        internal const string _str_VsSurrounding = "VsSurrounding";
        internal const string _str_DayPeriod = "DayPeriod";
        internal const string _str_CollectionMethod = "CollectionMethod";
        internal const string _str_BasisOfRecord = "BasisOfRecord";
        internal const string _str_VsVectorType = "VsVectorType";
        internal const string _str_VsVectorSubType = "VsVectorSubType";
        internal const string _str_AnimalGender = "AnimalGender";
        internal const string _str_IdentificationMethod = "IdentificationMethod";
        internal const string _str_Collector = "Collector";
        internal const string _str_Identifier = "Identifier";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_VectorTypes = "VectorTypes";
        internal const string _str_EctoparasitesCollected = "EctoparasitesCollected";
        internal const string _str_Location = "Location";
        internal const string _str_FFPresenter = "FFPresenter";
        internal const string _str_SampleTypesMatrix = "SampleTypesMatrix";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfVector, _type = "Int64",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { o.idfVector = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, "Int64", o.idfVector == null ? "" : o.idfVector.ToString(), o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); }
              }, 
        
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
              _name = _str_idfsVectorType, _type = "Int64",
              _get_func = o => o.idfsVectorType,
              _set_func = (o, val) => { o.idfsVectorType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorType != c.idfsVectorType || o.IsRIRPropChanged(_str_idfsVectorType, c)) 
                  m.Add(_str_idfsVectorType, o.ObjectIdent + _str_idfsVectorType, "Int64", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_idfsVectorType), o.IsInvisible(_str_idfsVectorType), o.IsRequired(_str_idfsVectorType)); }
              }, 
        
            new field_info {
              _name = _str_strVectorType, _type = "String",
              _get_func = o => o.strVectorType,
              _set_func = (o, val) => { o.strVectorType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorType != c.strVectorType || o.IsRIRPropChanged(_str_strVectorType, c)) 
                  m.Add(_str_strVectorType, o.ObjectIdent + _str_strVectorType, "String", o.strVectorType == null ? "" : o.strVectorType.ToString(), o.IsReadOnly(_str_strVectorType), o.IsInvisible(_str_strVectorType), o.IsRequired(_str_strVectorType)); }
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
              _name = _str_strVectorID, _type = "String",
              _get_func = o => o.strVectorID,
              _set_func = (o, val) => { o.strVectorID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorID != c.strVectorID || o.IsRIRPropChanged(_str_strVectorID, c)) 
                  m.Add(_str_strVectorID, o.ObjectIdent + _str_strVectorID, "String", o.strVectorID == null ? "" : o.strVectorID.ToString(), o.IsReadOnly(_str_strVectorID), o.IsInvisible(_str_strVectorID), o.IsRequired(_str_strVectorID)); }
              }, 
        
            new field_info {
              _name = _str_strFieldVectorID, _type = "String",
              _get_func = o => o.strFieldVectorID,
              _set_func = (o, val) => { o.strFieldVectorID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldVectorID != c.strFieldVectorID || o.IsRIRPropChanged(_str_strFieldVectorID, c)) 
                  m.Add(_str_strFieldVectorID, o.ObjectIdent + _str_strFieldVectorID, "String", o.strFieldVectorID == null ? "" : o.strFieldVectorID.ToString(), o.IsReadOnly(_str_strFieldVectorID), o.IsInvisible(_str_strFieldVectorID), o.IsRequired(_str_strFieldVectorID)); }
              }, 
        
            new field_info {
              _name = _str_idfHostVector, _type = "Int64?",
              _get_func = o => o.idfHostVector,
              _set_func = (o, val) => { o.idfHostVector = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfHostVector != c.idfHostVector || o.IsRIRPropChanged(_str_idfHostVector, c)) 
                  m.Add(_str_idfHostVector, o.ObjectIdent + _str_idfHostVector, "Int64?", o.idfHostVector == null ? "" : o.idfHostVector.ToString(), o.IsReadOnly(_str_idfHostVector), o.IsInvisible(_str_idfHostVector), o.IsRequired(_str_idfHostVector)); }
              }, 
        
            new field_info {
              _name = _str_strHostVector, _type = "String",
              _get_func = o => o.strHostVector,
              _set_func = (o, val) => { o.strHostVector = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strHostVector != c.strHostVector || o.IsRIRPropChanged(_str_strHostVector, c)) 
                  m.Add(_str_strHostVector, o.ObjectIdent + _str_strHostVector, "String", o.strHostVector == null ? "" : o.strHostVector.ToString(), o.IsReadOnly(_str_strHostVector), o.IsInvisible(_str_strHostVector), o.IsRequired(_str_strHostVector)); }
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
              _name = _str_idfsCountry, _type = "Int64?",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { o.idfsCountry = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) 
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, "Int64?", o.idfsCountry == null ? "" : o.idfsCountry.ToString(), o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry)); }
              }, 
        
            new field_info {
              _name = _str_strCountry, _type = "String",
              _get_func = o => o.strCountry,
              _set_func = (o, val) => { o.strCountry = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCountry != c.strCountry || o.IsRIRPropChanged(_str_strCountry, c)) 
                  m.Add(_str_strCountry, o.ObjectIdent + _str_strCountry, "String", o.strCountry == null ? "" : o.strCountry.ToString(), o.IsReadOnly(_str_strCountry), o.IsInvisible(_str_strCountry), o.IsRequired(_str_strCountry)); }
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
              _name = _str_strRegion, _type = "String",
              _get_func = o => o.strRegion,
              _set_func = (o, val) => { o.strRegion = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strRegion != c.strRegion || o.IsRIRPropChanged(_str_strRegion, c)) 
                  m.Add(_str_strRegion, o.ObjectIdent + _str_strRegion, "String", o.strRegion == null ? "" : o.strRegion.ToString(), o.IsReadOnly(_str_strRegion), o.IsInvisible(_str_strRegion), o.IsRequired(_str_strRegion)); }
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
              _name = _str_strRayon, _type = "String",
              _get_func = o => o.strRayon,
              _set_func = (o, val) => { o.strRayon = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strRayon != c.strRayon || o.IsRIRPropChanged(_str_strRayon, c)) 
                  m.Add(_str_strRayon, o.ObjectIdent + _str_strRayon, "String", o.strRayon == null ? "" : o.strRayon.ToString(), o.IsReadOnly(_str_strRayon), o.IsInvisible(_str_strRayon), o.IsRequired(_str_strRayon)); }
              }, 
        
            new field_info {
              _name = _str_idfsSettlement, _type = "Int64?",
              _get_func = o => o.idfsSettlement,
              _set_func = (o, val) => { o.idfsSettlement = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_idfsSettlement, c)) 
                  m.Add(_str_idfsSettlement, o.ObjectIdent + _str_idfsSettlement, "Int64?", o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(), o.IsReadOnly(_str_idfsSettlement), o.IsInvisible(_str_idfsSettlement), o.IsRequired(_str_idfsSettlement)); }
              }, 
        
            new field_info {
              _name = _str_strSettlement, _type = "String",
              _get_func = o => o.strSettlement,
              _set_func = (o, val) => { o.strSettlement = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSettlement != c.strSettlement || o.IsRIRPropChanged(_str_strSettlement, c)) 
                  m.Add(_str_strSettlement, o.ObjectIdent + _str_strSettlement, "String", o.strSettlement == null ? "" : o.strSettlement.ToString(), o.IsReadOnly(_str_strSettlement), o.IsInvisible(_str_strSettlement), o.IsRequired(_str_strSettlement)); }
              }, 
        
            new field_info {
              _name = _str_intElevation, _type = "Int32?",
              _get_func = o => o.intElevation,
              _set_func = (o, val) => { o.intElevation = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intElevation != c.intElevation || o.IsRIRPropChanged(_str_intElevation, c)) 
                  m.Add(_str_intElevation, o.ObjectIdent + _str_intElevation, "Int32?", o.intElevation == null ? "" : o.intElevation.ToString(), o.IsReadOnly(_str_intElevation), o.IsInvisible(_str_intElevation), o.IsRequired(_str_intElevation)); }
              }, 
        
            new field_info {
              _name = _str_idfsSurrounding, _type = "Int64?",
              _get_func = o => o.idfsSurrounding,
              _set_func = (o, val) => { o.idfsSurrounding = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSurrounding != c.idfsSurrounding || o.IsRIRPropChanged(_str_idfsSurrounding, c)) 
                  m.Add(_str_idfsSurrounding, o.ObjectIdent + _str_idfsSurrounding, "Int64?", o.idfsSurrounding == null ? "" : o.idfsSurrounding.ToString(), o.IsReadOnly(_str_idfsSurrounding), o.IsInvisible(_str_idfsSurrounding), o.IsRequired(_str_idfsSurrounding)); }
              }, 
        
            new field_info {
              _name = _str_strSurrounding, _type = "String",
              _get_func = o => o.strSurrounding,
              _set_func = (o, val) => { o.strSurrounding = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSurrounding != c.strSurrounding || o.IsRIRPropChanged(_str_strSurrounding, c)) 
                  m.Add(_str_strSurrounding, o.ObjectIdent + _str_strSurrounding, "String", o.strSurrounding == null ? "" : o.strSurrounding.ToString(), o.IsReadOnly(_str_strSurrounding), o.IsInvisible(_str_strSurrounding), o.IsRequired(_str_strSurrounding)); }
              }, 
        
            new field_info {
              _name = _str_strGEOReferenceSources, _type = "String",
              _get_func = o => o.strGEOReferenceSources,
              _set_func = (o, val) => { o.strGEOReferenceSources = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strGEOReferenceSources != c.strGEOReferenceSources || o.IsRIRPropChanged(_str_strGEOReferenceSources, c)) 
                  m.Add(_str_strGEOReferenceSources, o.ObjectIdent + _str_strGEOReferenceSources, "String", o.strGEOReferenceSources == null ? "" : o.strGEOReferenceSources.ToString(), o.IsReadOnly(_str_strGEOReferenceSources), o.IsInvisible(_str_strGEOReferenceSources), o.IsRequired(_str_strGEOReferenceSources)); }
              }, 
        
            new field_info {
              _name = _str_idfCollectedByOffice, _type = "Int64",
              _get_func = o => o.idfCollectedByOffice,
              _set_func = (o, val) => { o.idfCollectedByOffice = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCollectedByOffice != c.idfCollectedByOffice || o.IsRIRPropChanged(_str_idfCollectedByOffice, c)) 
                  m.Add(_str_idfCollectedByOffice, o.ObjectIdent + _str_idfCollectedByOffice, "Int64", o.idfCollectedByOffice == null ? "" : o.idfCollectedByOffice.ToString(), o.IsReadOnly(_str_idfCollectedByOffice), o.IsInvisible(_str_idfCollectedByOffice), o.IsRequired(_str_idfCollectedByOffice)); }
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
              _name = _str_idfCollectedByPerson, _type = "Int64?",
              _get_func = o => o.idfCollectedByPerson,
              _set_func = (o, val) => { o.idfCollectedByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCollectedByPerson != c.idfCollectedByPerson || o.IsRIRPropChanged(_str_idfCollectedByPerson, c)) 
                  m.Add(_str_idfCollectedByPerson, o.ObjectIdent + _str_idfCollectedByPerson, "Int64?", o.idfCollectedByPerson == null ? "" : o.idfCollectedByPerson.ToString(), o.IsReadOnly(_str_idfCollectedByPerson), o.IsInvisible(_str_idfCollectedByPerson), o.IsRequired(_str_idfCollectedByPerson)); }
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
              _name = _str_datCollectionDateTime, _type = "DateTime",
              _get_func = o => o.datCollectionDateTime,
              _set_func = (o, val) => { o.datCollectionDateTime = ParsingHelper.ParseDateTime(val); },
              _compare_func = (o, c, m) => {
                if (o.datCollectionDateTime != c.datCollectionDateTime || o.IsRIRPropChanged(_str_datCollectionDateTime, c)) 
                  m.Add(_str_datCollectionDateTime, o.ObjectIdent + _str_datCollectionDateTime, "DateTime", o.datCollectionDateTime == null ? "" : o.datCollectionDateTime.ToString(), o.IsReadOnly(_str_datCollectionDateTime), o.IsInvisible(_str_datCollectionDateTime), o.IsRequired(_str_datCollectionDateTime)); }
              }, 
        
            new field_info {
              _name = _str_idfsCollectionMethod, _type = "Int64?",
              _get_func = o => o.idfsCollectionMethod,
              _set_func = (o, val) => { o.idfsCollectionMethod = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCollectionMethod != c.idfsCollectionMethod || o.IsRIRPropChanged(_str_idfsCollectionMethod, c)) 
                  m.Add(_str_idfsCollectionMethod, o.ObjectIdent + _str_idfsCollectionMethod, "Int64?", o.idfsCollectionMethod == null ? "" : o.idfsCollectionMethod.ToString(), o.IsReadOnly(_str_idfsCollectionMethod), o.IsInvisible(_str_idfsCollectionMethod), o.IsRequired(_str_idfsCollectionMethod)); }
              }, 
        
            new field_info {
              _name = _str_strCollectionMethod, _type = "String",
              _get_func = o => o.strCollectionMethod,
              _set_func = (o, val) => { o.strCollectionMethod = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCollectionMethod != c.strCollectionMethod || o.IsRIRPropChanged(_str_strCollectionMethod, c)) 
                  m.Add(_str_strCollectionMethod, o.ObjectIdent + _str_strCollectionMethod, "String", o.strCollectionMethod == null ? "" : o.strCollectionMethod.ToString(), o.IsReadOnly(_str_strCollectionMethod), o.IsInvisible(_str_strCollectionMethod), o.IsRequired(_str_strCollectionMethod)); }
              }, 
        
            new field_info {
              _name = _str_idfsBasisOfRecord, _type = "Int64?",
              _get_func = o => o.idfsBasisOfRecord,
              _set_func = (o, val) => { o.idfsBasisOfRecord = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsBasisOfRecord != c.idfsBasisOfRecord || o.IsRIRPropChanged(_str_idfsBasisOfRecord, c)) 
                  m.Add(_str_idfsBasisOfRecord, o.ObjectIdent + _str_idfsBasisOfRecord, "Int64?", o.idfsBasisOfRecord == null ? "" : o.idfsBasisOfRecord.ToString(), o.IsReadOnly(_str_idfsBasisOfRecord), o.IsInvisible(_str_idfsBasisOfRecord), o.IsRequired(_str_idfsBasisOfRecord)); }
              }, 
        
            new field_info {
              _name = _str_strBasisOfRecord, _type = "String",
              _get_func = o => o.strBasisOfRecord,
              _set_func = (o, val) => { o.strBasisOfRecord = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strBasisOfRecord != c.strBasisOfRecord || o.IsRIRPropChanged(_str_strBasisOfRecord, c)) 
                  m.Add(_str_strBasisOfRecord, o.ObjectIdent + _str_strBasisOfRecord, "String", o.strBasisOfRecord == null ? "" : o.strBasisOfRecord.ToString(), o.IsReadOnly(_str_strBasisOfRecord), o.IsInvisible(_str_strBasisOfRecord), o.IsRequired(_str_strBasisOfRecord)); }
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
              _name = _str_idfsSex, _type = "Int64?",
              _get_func = o => o.idfsSex,
              _set_func = (o, val) => { o.idfsSex = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSex != c.idfsSex || o.IsRIRPropChanged(_str_idfsSex, c)) 
                  m.Add(_str_idfsSex, o.ObjectIdent + _str_idfsSex, "Int64?", o.idfsSex == null ? "" : o.idfsSex.ToString(), o.IsReadOnly(_str_idfsSex), o.IsInvisible(_str_idfsSex), o.IsRequired(_str_idfsSex)); }
              }, 
        
            new field_info {
              _name = _str_strSex, _type = "String",
              _get_func = o => o.strSex,
              _set_func = (o, val) => { o.strSex = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSex != c.strSex || o.IsRIRPropChanged(_str_strSex, c)) 
                  m.Add(_str_strSex, o.ObjectIdent + _str_strSex, "String", o.strSex == null ? "" : o.strSex.ToString(), o.IsReadOnly(_str_strSex), o.IsInvisible(_str_strSex), o.IsRequired(_str_strSex)); }
              }, 
        
            new field_info {
              _name = _str_idfIdentifiedByOffice, _type = "Int64?",
              _get_func = o => o.idfIdentifiedByOffice,
              _set_func = (o, val) => { o.idfIdentifiedByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfIdentifiedByOffice != c.idfIdentifiedByOffice || o.IsRIRPropChanged(_str_idfIdentifiedByOffice, c)) 
                  m.Add(_str_idfIdentifiedByOffice, o.ObjectIdent + _str_idfIdentifiedByOffice, "Int64?", o.idfIdentifiedByOffice == null ? "" : o.idfIdentifiedByOffice.ToString(), o.IsReadOnly(_str_idfIdentifiedByOffice), o.IsInvisible(_str_idfIdentifiedByOffice), o.IsRequired(_str_idfIdentifiedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_strIdentifiedByOffice, _type = "String",
              _get_func = o => o.strIdentifiedByOffice,
              _set_func = (o, val) => { o.strIdentifiedByOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strIdentifiedByOffice != c.strIdentifiedByOffice || o.IsRIRPropChanged(_str_strIdentifiedByOffice, c)) 
                  m.Add(_str_strIdentifiedByOffice, o.ObjectIdent + _str_strIdentifiedByOffice, "String", o.strIdentifiedByOffice == null ? "" : o.strIdentifiedByOffice.ToString(), o.IsReadOnly(_str_strIdentifiedByOffice), o.IsInvisible(_str_strIdentifiedByOffice), o.IsRequired(_str_strIdentifiedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfIdentifiedByPerson, _type = "Int64?",
              _get_func = o => o.idfIdentifiedByPerson,
              _set_func = (o, val) => { o.idfIdentifiedByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfIdentifiedByPerson != c.idfIdentifiedByPerson || o.IsRIRPropChanged(_str_idfIdentifiedByPerson, c)) 
                  m.Add(_str_idfIdentifiedByPerson, o.ObjectIdent + _str_idfIdentifiedByPerson, "Int64?", o.idfIdentifiedByPerson == null ? "" : o.idfIdentifiedByPerson.ToString(), o.IsReadOnly(_str_idfIdentifiedByPerson), o.IsInvisible(_str_idfIdentifiedByPerson), o.IsRequired(_str_idfIdentifiedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_strIdentifiedByPerson, _type = "String",
              _get_func = o => o.strIdentifiedByPerson,
              _set_func = (o, val) => { o.strIdentifiedByPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strIdentifiedByPerson != c.strIdentifiedByPerson || o.IsRIRPropChanged(_str_strIdentifiedByPerson, c)) 
                  m.Add(_str_strIdentifiedByPerson, o.ObjectIdent + _str_strIdentifiedByPerson, "String", o.strIdentifiedByPerson == null ? "" : o.strIdentifiedByPerson.ToString(), o.IsReadOnly(_str_strIdentifiedByPerson), o.IsInvisible(_str_strIdentifiedByPerson), o.IsRequired(_str_strIdentifiedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_datIdentifiedDateTime, _type = "DateTime?",
              _get_func = o => o.datIdentifiedDateTime,
              _set_func = (o, val) => { o.datIdentifiedDateTime = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datIdentifiedDateTime != c.datIdentifiedDateTime || o.IsRIRPropChanged(_str_datIdentifiedDateTime, c)) 
                  m.Add(_str_datIdentifiedDateTime, o.ObjectIdent + _str_datIdentifiedDateTime, "DateTime?", o.datIdentifiedDateTime == null ? "" : o.datIdentifiedDateTime.ToString(), o.IsReadOnly(_str_datIdentifiedDateTime), o.IsInvisible(_str_datIdentifiedDateTime), o.IsRequired(_str_datIdentifiedDateTime)); }
              }, 
        
            new field_info {
              _name = _str_idfsIdentificationMethod, _type = "Int64?",
              _get_func = o => o.idfsIdentificationMethod,
              _set_func = (o, val) => { o.idfsIdentificationMethod = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsIdentificationMethod != c.idfsIdentificationMethod || o.IsRIRPropChanged(_str_idfsIdentificationMethod, c)) 
                  m.Add(_str_idfsIdentificationMethod, o.ObjectIdent + _str_idfsIdentificationMethod, "Int64?", o.idfsIdentificationMethod == null ? "" : o.idfsIdentificationMethod.ToString(), o.IsReadOnly(_str_idfsIdentificationMethod), o.IsInvisible(_str_idfsIdentificationMethod), o.IsRequired(_str_idfsIdentificationMethod)); }
              }, 
        
            new field_info {
              _name = _str_strIdentificationMethod, _type = "String",
              _get_func = o => o.strIdentificationMethod,
              _set_func = (o, val) => { o.strIdentificationMethod = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strIdentificationMethod != c.strIdentificationMethod || o.IsRIRPropChanged(_str_strIdentificationMethod, c)) 
                  m.Add(_str_strIdentificationMethod, o.ObjectIdent + _str_strIdentificationMethod, "String", o.strIdentificationMethod == null ? "" : o.strIdentificationMethod.ToString(), o.IsReadOnly(_str_strIdentificationMethod), o.IsInvisible(_str_strIdentificationMethod), o.IsRequired(_str_strIdentificationMethod)); }
              }, 
        
            new field_info {
              _name = _str_idfObservation, _type = "Int64?",
              _get_func = o => o.idfObservation,
              _set_func = (o, val) => { o.idfObservation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfObservation != c.idfObservation || o.IsRIRPropChanged(_str_idfObservation, c)) 
                  m.Add(_str_idfObservation, o.ObjectIdent + _str_idfObservation, "Int64?", o.idfObservation == null ? "" : o.idfObservation.ToString(), o.IsReadOnly(_str_idfObservation), o.IsInvisible(_str_idfObservation), o.IsRequired(_str_idfObservation)); }
              }, 
        
            new field_info {
              _name = _str_idfsFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { o.idfsFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, "Int64?", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); }
              }, 
        
            new field_info {
              _name = _str_dblLatitude, _type = "Double?",
              _get_func = o => o.dblLatitude,
              _set_func = (o, val) => { o.dblLatitude = ParsingHelper.ParseDoubleNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.dblLatitude != c.dblLatitude || o.IsRIRPropChanged(_str_dblLatitude, c)) 
                  m.Add(_str_dblLatitude, o.ObjectIdent + _str_dblLatitude, "Double?", o.dblLatitude == null ? "" : o.dblLatitude.ToString(), o.IsReadOnly(_str_dblLatitude), o.IsInvisible(_str_dblLatitude), o.IsRequired(_str_dblLatitude)); }
              }, 
        
            new field_info {
              _name = _str_dblLongitude, _type = "Double?",
              _get_func = o => o.dblLongitude,
              _set_func = (o, val) => { o.dblLongitude = ParsingHelper.ParseDoubleNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.dblLongitude != c.dblLongitude || o.IsRIRPropChanged(_str_dblLongitude, c)) 
                  m.Add(_str_dblLongitude, o.ObjectIdent + _str_dblLongitude, "Double?", o.dblLongitude == null ? "" : o.dblLongitude.ToString(), o.IsReadOnly(_str_dblLongitude), o.IsInvisible(_str_dblLongitude), o.IsRequired(_str_dblLongitude)); }
              }, 
        
            new field_info {
              _name = _str_idfsDayPeriod, _type = "Int64?",
              _get_func = o => o.idfsDayPeriod,
              _set_func = (o, val) => { o.idfsDayPeriod = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsDayPeriod != c.idfsDayPeriod || o.IsRIRPropChanged(_str_idfsDayPeriod, c)) 
                  m.Add(_str_idfsDayPeriod, o.ObjectIdent + _str_idfsDayPeriod, "Int64?", o.idfsDayPeriod == null ? "" : o.idfsDayPeriod.ToString(), o.IsReadOnly(_str_idfsDayPeriod), o.IsInvisible(_str_idfsDayPeriod), o.IsRequired(_str_idfsDayPeriod)); }
              }, 
        
            new field_info {
              _name = _str_strDayPeriod, _type = "String",
              _get_func = o => o.strDayPeriod,
              _set_func = (o, val) => { o.strDayPeriod = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strDayPeriod != c.strDayPeriod || o.IsRIRPropChanged(_str_strDayPeriod, c)) 
                  m.Add(_str_strDayPeriod, o.ObjectIdent + _str_strDayPeriod, "String", o.strDayPeriod == null ? "" : o.strDayPeriod.ToString(), o.IsReadOnly(_str_strDayPeriod), o.IsInvisible(_str_strDayPeriod), o.IsRequired(_str_strDayPeriod)); }
              }, 
        
            new field_info {
              _name = _str_strSpecies, _type = "String",
              _get_func = o => o.strSpecies,
              _set_func = (o, val) => { o.strSpecies = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSpecies != c.strSpecies || o.IsRIRPropChanged(_str_strSpecies, c)) 
                  m.Add(_str_strSpecies, o.ObjectIdent + _str_strSpecies, "String", o.strSpecies == null ? "" : o.strSpecies.ToString(), o.IsReadOnly(_str_strSpecies), o.IsInvisible(_str_strSpecies), o.IsRequired(_str_strSpecies)); }
              }, 
        
            new field_info {
              _name = _str_strComment, _type = "String",
              _get_func = o => o.strComment,
              _set_func = (o, val) => { o.strComment = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strComment != c.strComment || o.IsRIRPropChanged(_str_strComment, c)) 
                  m.Add(_str_strComment, o.ObjectIdent + _str_strComment, "String", o.strComment == null ? "" : o.strComment.ToString(), o.IsReadOnly(_str_strComment), o.IsInvisible(_str_strComment), o.IsRequired(_str_strComment)); }
              }, 
        
            new field_info {
              _name = _str_idfsEctoparasitesCollected, _type = "Int64?",
              _get_func = o => o.idfsEctoparasitesCollected,
              _set_func = (o, val) => { o.idfsEctoparasitesCollected = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsEctoparasitesCollected != c.idfsEctoparasitesCollected || o.IsRIRPropChanged(_str_idfsEctoparasitesCollected, c)) 
                  m.Add(_str_idfsEctoparasitesCollected, o.ObjectIdent + _str_idfsEctoparasitesCollected, "Int64?", o.idfsEctoparasitesCollected == null ? "" : o.idfsEctoparasitesCollected.ToString(), o.IsReadOnly(_str_idfsEctoparasitesCollected), o.IsInvisible(_str_idfsEctoparasitesCollected), o.IsRequired(_str_idfsEctoparasitesCollected)); }
              }, 
        
            new field_info {
              _name = _str_strEctoparasitesCollected, _type = "String",
              _get_func = o => o.strEctoparasitesCollected,
              _set_func = (o, val) => { o.strEctoparasitesCollected = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strEctoparasitesCollected != c.strEctoparasitesCollected || o.IsRIRPropChanged(_str_strEctoparasitesCollected, c)) 
                  m.Add(_str_strEctoparasitesCollected, o.ObjectIdent + _str_strEctoparasitesCollected, "String", o.strEctoparasitesCollected == null ? "" : o.strEctoparasitesCollected.ToString(), o.IsReadOnly(_str_strEctoparasitesCollected), o.IsInvisible(_str_strEctoparasitesCollected), o.IsRequired(_str_strEctoparasitesCollected)); }
              }, 
        
            new field_info {
              _name = _str_HostVector, _type = "Vector",
              _get_func = o => o.HostVector,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_strVectorSpecificData, _type = "string",
              _get_func = o => o.strVectorSpecificData,
              _set_func = (o, val) => { o.strVectorSpecificData = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
              
                if (o.strVectorSpecificData != c.strVectorSpecificData || o.IsRIRPropChanged(_str_strVectorSpecificData, c)) 
                  m.Add(_str_strVectorSpecificData, o.ObjectIdent + _str_strVectorSpecificData, "string", o.strVectorSpecificData == null ? "" : o.strVectorSpecificData.ToString(), o.IsReadOnly(_str_strVectorSpecificData), o.IsInvisible(_str_strVectorSpecificData), o.IsRequired(_str_strVectorSpecificData));
                 }
              }, 
        
            new field_info {
              _name = _str_Vectors, _type = "EditableList<Vector>",
              _get_func = o => o.Vectors,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_Samples, _type = "EditableList<VectorSample>",
              _get_func = o => o.Samples,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_FieldTests, _type = "EditableList<VectorFieldTest>",
              _get_func = o => o.FieldTests,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_LabTests, _type = "EditableList<VectorLabTest>",
              _get_func = o => o.LabTests,
              _set_func = (o, val) => {},
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
              _name = _str_CollectedByOffice, _type = "Lookup",
              _get_func = o => { if (o.CollectedByOffice == null) return null; return o.CollectedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.CollectedByOffice = o.CollectedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfCollectedByOffice != c.idfCollectedByOffice || o.IsRIRPropChanged(_str_CollectedByOffice, c)) 
                  m.Add(_str_CollectedByOffice, o.ObjectIdent + _str_CollectedByOffice, "Lookup", o.idfCollectedByOffice == null ? "" : o.idfCollectedByOffice.ToString(), o.IsReadOnly(_str_CollectedByOffice), o.IsInvisible(_str_CollectedByOffice), o.IsRequired(_str_CollectedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_IdentifiedByOffice, _type = "Lookup",
              _get_func = o => { if (o.IdentifiedByOffice == null) return null; return o.IdentifiedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.IdentifiedByOffice = o.IdentifiedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfIdentifiedByOffice != c.idfIdentifiedByOffice || o.IsRIRPropChanged(_str_IdentifiedByOffice, c)) 
                  m.Add(_str_IdentifiedByOffice, o.ObjectIdent + _str_IdentifiedByOffice, "Lookup", o.idfIdentifiedByOffice == null ? "" : o.idfIdentifiedByOffice.ToString(), o.IsReadOnly(_str_IdentifiedByOffice), o.IsInvisible(_str_IdentifiedByOffice), o.IsRequired(_str_IdentifiedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_VsSurrounding, _type = "Lookup",
              _get_func = o => { if (o.VsSurrounding == null) return null; return o.VsSurrounding.idfsBaseReference; },
              _set_func = (o, val) => { o.VsSurrounding = o.VsSurroundingLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSurrounding != c.idfsSurrounding || o.IsRIRPropChanged(_str_VsSurrounding, c)) 
                  m.Add(_str_VsSurrounding, o.ObjectIdent + _str_VsSurrounding, "Lookup", o.idfsSurrounding == null ? "" : o.idfsSurrounding.ToString(), o.IsReadOnly(_str_VsSurrounding), o.IsInvisible(_str_VsSurrounding), o.IsRequired(_str_VsSurrounding)); }
              }, 
        
            new field_info {
              _name = _str_DayPeriod, _type = "Lookup",
              _get_func = o => { if (o.DayPeriod == null) return null; return o.DayPeriod.idfsBaseReference; },
              _set_func = (o, val) => { o.DayPeriod = o.DayPeriodLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDayPeriod != c.idfsDayPeriod || o.IsRIRPropChanged(_str_DayPeriod, c)) 
                  m.Add(_str_DayPeriod, o.ObjectIdent + _str_DayPeriod, "Lookup", o.idfsDayPeriod == null ? "" : o.idfsDayPeriod.ToString(), o.IsReadOnly(_str_DayPeriod), o.IsInvisible(_str_DayPeriod), o.IsRequired(_str_DayPeriod)); }
              }, 
        
            new field_info {
              _name = _str_CollectionMethod, _type = "Lookup",
              _get_func = o => { if (o.CollectionMethod == null) return null; return o.CollectionMethod.idfsCollectionMethod; },
              _set_func = (o, val) => { o.CollectionMethod = o.CollectionMethodLookup.Where(c => c.idfsCollectionMethod.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCollectionMethod != c.idfsCollectionMethod || o.IsRIRPropChanged(_str_CollectionMethod, c)) 
                  m.Add(_str_CollectionMethod, o.ObjectIdent + _str_CollectionMethod, "Lookup", o.idfsCollectionMethod == null ? "" : o.idfsCollectionMethod.ToString(), o.IsReadOnly(_str_CollectionMethod), o.IsInvisible(_str_CollectionMethod), o.IsRequired(_str_CollectionMethod)); }
              }, 
        
            new field_info {
              _name = _str_BasisOfRecord, _type = "Lookup",
              _get_func = o => { if (o.BasisOfRecord == null) return null; return o.BasisOfRecord.idfsBaseReference; },
              _set_func = (o, val) => { o.BasisOfRecord = o.BasisOfRecordLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsBasisOfRecord != c.idfsBasisOfRecord || o.IsRIRPropChanged(_str_BasisOfRecord, c)) 
                  m.Add(_str_BasisOfRecord, o.ObjectIdent + _str_BasisOfRecord, "Lookup", o.idfsBasisOfRecord == null ? "" : o.idfsBasisOfRecord.ToString(), o.IsReadOnly(_str_BasisOfRecord), o.IsInvisible(_str_BasisOfRecord), o.IsRequired(_str_BasisOfRecord)); }
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
              _name = _str_VsVectorSubType, _type = "Lookup",
              _get_func = o => { if (o.VsVectorSubType == null) return null; return o.VsVectorSubType.idfsBaseReference; },
              _set_func = (o, val) => { o.VsVectorSubType = o.VsVectorSubTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_VsVectorSubType, c)) 
                  m.Add(_str_VsVectorSubType, o.ObjectIdent + _str_VsVectorSubType, "Lookup", o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(), o.IsReadOnly(_str_VsVectorSubType), o.IsInvisible(_str_VsVectorSubType), o.IsRequired(_str_VsVectorSubType)); }
              }, 
        
            new field_info {
              _name = _str_AnimalGender, _type = "Lookup",
              _get_func = o => { if (o.AnimalGender == null) return null; return o.AnimalGender.idfsBaseReference; },
              _set_func = (o, val) => { o.AnimalGender = o.AnimalGenderLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSex != c.idfsSex || o.IsRIRPropChanged(_str_AnimalGender, c)) 
                  m.Add(_str_AnimalGender, o.ObjectIdent + _str_AnimalGender, "Lookup", o.idfsSex == null ? "" : o.idfsSex.ToString(), o.IsReadOnly(_str_AnimalGender), o.IsInvisible(_str_AnimalGender), o.IsRequired(_str_AnimalGender)); }
              }, 
        
            new field_info {
              _name = _str_IdentificationMethod, _type = "Lookup",
              _get_func = o => { if (o.IdentificationMethod == null) return null; return o.IdentificationMethod.idfsBaseReference; },
              _set_func = (o, val) => { o.IdentificationMethod = o.IdentificationMethodLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsIdentificationMethod != c.idfsIdentificationMethod || o.IsRIRPropChanged(_str_IdentificationMethod, c)) 
                  m.Add(_str_IdentificationMethod, o.ObjectIdent + _str_IdentificationMethod, "Lookup", o.idfsIdentificationMethod == null ? "" : o.idfsIdentificationMethod.ToString(), o.IsReadOnly(_str_IdentificationMethod), o.IsInvisible(_str_IdentificationMethod), o.IsRequired(_str_IdentificationMethod)); }
              }, 
        
            new field_info {
              _name = _str_Collector, _type = "Lookup",
              _get_func = o => { if (o.Collector == null) return null; return o.Collector.idfPerson; },
              _set_func = (o, val) => { o.Collector = o.CollectorLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfCollectedByPerson != c.idfCollectedByPerson || o.IsRIRPropChanged(_str_Collector, c)) 
                  m.Add(_str_Collector, o.ObjectIdent + _str_Collector, "Lookup", o.idfCollectedByPerson == null ? "" : o.idfCollectedByPerson.ToString(), o.IsReadOnly(_str_Collector), o.IsInvisible(_str_Collector), o.IsRequired(_str_Collector)); }
              }, 
        
            new field_info {
              _name = _str_Identifier, _type = "Lookup",
              _get_func = o => { if (o.Identifier == null) return null; return o.Identifier.idfPerson; },
              _set_func = (o, val) => { o.Identifier = o.IdentifierLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfIdentifiedByPerson != c.idfIdentifiedByPerson || o.IsRIRPropChanged(_str_Identifier, c)) 
                  m.Add(_str_Identifier, o.ObjectIdent + _str_Identifier, "Lookup", o.idfIdentifiedByPerson == null ? "" : o.idfIdentifiedByPerson.ToString(), o.IsReadOnly(_str_Identifier), o.IsInvisible(_str_Identifier), o.IsRequired(_str_Identifier)); }
              }, 
        
            new field_info {
              _name = _str_Country, _type = "Lookup",
              _get_func = o => { if (o.Country == null) return null; return o.Country.idfsCountry; },
              _set_func = (o, val) => { o.Country = o.CountryLookup.Where(c => c.idfsCountry.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_Country, c)) 
                  m.Add(_str_Country, o.ObjectIdent + _str_Country, "Lookup", o.idfsCountry == null ? "" : o.idfsCountry.ToString(), o.IsReadOnly(_str_Country), o.IsInvisible(_str_Country), o.IsRequired(_str_Country)); }
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
              _name = _str_Settlement, _type = "Lookup",
              _get_func = o => { if (o.Settlement == null) return null; return o.Settlement.idfsSettlement; },
              _set_func = (o, val) => { o.Settlement = o.SettlementLookup.Where(c => c.idfsSettlement.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_Settlement, c)) 
                  m.Add(_str_Settlement, o.ObjectIdent + _str_Settlement, "Lookup", o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(), o.IsReadOnly(_str_Settlement), o.IsInvisible(_str_Settlement), o.IsRequired(_str_Settlement)); }
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
              _name = _str_EctoparasitesCollected, _type = "Lookup",
              _get_func = o => { if (o.EctoparasitesCollected == null) return null; return o.EctoparasitesCollected.idfsBaseReference; },
              _set_func = (o, val) => { o.EctoparasitesCollected = o.EctoparasitesCollectedLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsEctoparasitesCollected != c.idfsEctoparasitesCollected || o.IsRIRPropChanged(_str_EctoparasitesCollected, c)) 
                  m.Add(_str_EctoparasitesCollected, o.ObjectIdent + _str_EctoparasitesCollected, "Lookup", o.idfsEctoparasitesCollected == null ? "" : o.idfsEctoparasitesCollected.ToString(), o.IsReadOnly(_str_EctoparasitesCollected), o.IsInvisible(_str_EctoparasitesCollected), o.IsRequired(_str_EctoparasitesCollected)); }
              }, 
        
            new field_info {
              _name = _str_SampleTypesMatrix, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.SampleTypesMatrix.Count != c.SampleTypesMatrix.Count || o.IsReadOnly(_str_SampleTypesMatrix) != c.IsReadOnly(_str_SampleTypesMatrix) || o.IsInvisible(_str_SampleTypesMatrix) != c.IsInvisible(_str_SampleTypesMatrix) || o.IsRequired(_str_SampleTypesMatrix) != c.IsRequired(_str_SampleTypesMatrix)) 
                  m.Add(_str_SampleTypesMatrix, o.ObjectIdent + _str_SampleTypesMatrix, "Child", o.idfsVectorType == null ? "" : o.idfsVectorType.ToString(), o.IsReadOnly(_str_SampleTypesMatrix), o.IsInvisible(_str_SampleTypesMatrix), o.IsRequired(_str_SampleTypesMatrix)); }
              }, 
        
            new field_info {
              _name = _str_Location, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Location != null) o.Location._compare(c.Location, m); }
              }, 
        
            new field_info {
              _name = _str_FFPresenter, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.FFPresenter != null) o.FFPresenter._compare(c.FFPresenter, m); }
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
            Vector obj = (Vector)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
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
                    
        [Relation(typeof(FFPresenterModel), eidss.model.Schema.FFPresenterModel._str_CurrentObservation, _str_idfObservation)]
        public FFPresenterModel FFPresenter
        {
            get 
            {   
                return _FFPresenter; 
            }
            set 
            {   
                _FFPresenter = value;
                if (_FFPresenter != null) 
                { 
                    _FFPresenter.m_ObjectName = _str_FFPresenter;
                    _FFPresenter.Parent = this;
                }
                idfObservation = _FFPresenter == null 
                        ? new Int64?()
                        : _FFPresenter.CurrentObservation;
                
            }
        }
        protected FFPresenterModel _FFPresenter;
                    
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
                    
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfCollectedByOffice)]
        public OrganizationLookup CollectedByOffice
        {
            get { return _CollectedByOffice == null ? null : ((long)_CollectedByOffice.Key == 0 ? null : _CollectedByOffice); }
            set 
            { 
                _CollectedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfCollectedByOffice = _CollectedByOffice == null 
                    ? new Int64()
                    : _CollectedByOffice.idfInstitution; 
                OnPropertyChanged(_str_CollectedByOffice); 
            }
        }
        private OrganizationLookup _CollectedByOffice;

        
        public List<OrganizationLookup> CollectedByOfficeLookup
        {
            get { return _CollectedByOfficeLookup; }
        }
        private List<OrganizationLookup> _CollectedByOfficeLookup = new List<OrganizationLookup>();
            
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfIdentifiedByOffice)]
        public OrganizationLookup IdentifiedByOffice
        {
            get { return _IdentifiedByOffice == null ? null : ((long)_IdentifiedByOffice.Key == 0 ? null : _IdentifiedByOffice); }
            set 
            { 
                _IdentifiedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfIdentifiedByOffice = _IdentifiedByOffice == null 
                    ? new Int64?()
                    : _IdentifiedByOffice.idfInstitution; 
                OnPropertyChanged(_str_IdentifiedByOffice); 
            }
        }
        private OrganizationLookup _IdentifiedByOffice;

        
        public List<OrganizationLookup> IdentifiedByOfficeLookup
        {
            get { return _IdentifiedByOfficeLookup; }
        }
        private List<OrganizationLookup> _IdentifiedByOfficeLookup = new List<OrganizationLookup>();
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSurrounding)]
        public BaseReference VsSurrounding
        {
            get { return _VsSurrounding == null ? null : ((long)_VsSurrounding.Key == 0 ? null : _VsSurrounding); }
            set 
            { 
                _VsSurrounding = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSurrounding = _VsSurrounding == null 
                    ? new Int64?()
                    : _VsSurrounding.idfsBaseReference; 
                OnPropertyChanged(_str_VsSurrounding); 
            }
        }
        private BaseReference _VsSurrounding;

        
        public BaseReferenceList VsSurroundingLookup
        {
            get { return _VsSurroundingLookup; }
        }
        private BaseReferenceList _VsSurroundingLookup = new BaseReferenceList("rftSurrounding");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsDayPeriod)]
        public BaseReference DayPeriod
        {
            get { return _DayPeriod == null ? null : ((long)_DayPeriod.Key == 0 ? null : _DayPeriod); }
            set 
            { 
                _DayPeriod = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsDayPeriod = _DayPeriod == null 
                    ? new Int64?()
                    : _DayPeriod.idfsBaseReference; 
                OnPropertyChanged(_str_DayPeriod); 
            }
        }
        private BaseReference _DayPeriod;

        
        public BaseReferenceList DayPeriodLookup
        {
            get { return _DayPeriodLookup; }
        }
        private BaseReferenceList _DayPeriodLookup = new BaseReferenceList("rftDayPeriod");
            
        [Relation(typeof(CollectionMethodLookup), eidss.model.Schema.CollectionMethodLookup._str_idfsCollectionMethod, _str_idfsCollectionMethod)]
        public CollectionMethodLookup CollectionMethod
        {
            get { return _CollectionMethod == null ? null : ((long)_CollectionMethod.Key == 0 ? null : _CollectionMethod); }
            set 
            { 
                _CollectionMethod = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCollectionMethod = _CollectionMethod == null 
                    ? new Int64?()
                    : _CollectionMethod.idfsCollectionMethod; 
                OnPropertyChanged(_str_CollectionMethod); 
            }
        }
        private CollectionMethodLookup _CollectionMethod;

        
        public List<CollectionMethodLookup> CollectionMethodLookup
        {
            get { return _CollectionMethodLookup; }
        }
        private List<CollectionMethodLookup> _CollectionMethodLookup = new List<CollectionMethodLookup>();
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsBasisOfRecord)]
        public BaseReference BasisOfRecord
        {
            get { return _BasisOfRecord == null ? null : ((long)_BasisOfRecord.Key == 0 ? null : _BasisOfRecord); }
            set 
            { 
                _BasisOfRecord = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsBasisOfRecord = _BasisOfRecord == null 
                    ? new Int64?()
                    : _BasisOfRecord.idfsBaseReference; 
                OnPropertyChanged(_str_BasisOfRecord); 
            }
        }
        private BaseReference _BasisOfRecord;

        
        public BaseReferenceList BasisOfRecordLookup
        {
            get { return _BasisOfRecordLookup; }
        }
        private BaseReferenceList _BasisOfRecordLookup = new BaseReferenceList("rftBasisOfRecord");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsVectorType)]
        public BaseReference VsVectorType
        {
            get { return _VsVectorType == null ? null : ((long)_VsVectorType.Key == 0 ? null : _VsVectorType); }
            set 
            { 
                _VsVectorType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsVectorType = _VsVectorType == null 
                    ? new Int64()
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
            
        [Relation(typeof(VectorSubTypeLookup), eidss.model.Schema.VectorSubTypeLookup._str_idfsBaseReference, _str_idfsVectorSubType)]
        public VectorSubTypeLookup VsVectorSubType
        {
            get { return _VsVectorSubType == null ? null : ((long)_VsVectorSubType.Key == 0 ? null : _VsVectorSubType); }
            set 
            { 
                _VsVectorSubType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsVectorSubType = _VsVectorSubType == null 
                    ? new Int64()
                    : _VsVectorSubType.idfsBaseReference; 
                OnPropertyChanged(_str_VsVectorSubType); 
            }
        }
        private VectorSubTypeLookup _VsVectorSubType;

        
        public List<VectorSubTypeLookup> VsVectorSubTypeLookup
        {
            get { return _VsVectorSubTypeLookup; }
        }
        private List<VectorSubTypeLookup> _VsVectorSubTypeLookup = new List<VectorSubTypeLookup>();
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSex)]
        public BaseReference AnimalGender
        {
            get { return _AnimalGender == null ? null : ((long)_AnimalGender.Key == 0 ? null : _AnimalGender); }
            set 
            { 
                _AnimalGender = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSex = _AnimalGender == null 
                    ? new Int64?()
                    : _AnimalGender.idfsBaseReference; 
                OnPropertyChanged(_str_AnimalGender); 
            }
        }
        private BaseReference _AnimalGender;

        
        public BaseReferenceList AnimalGenderLookup
        {
            get { return _AnimalGenderLookup; }
        }
        private BaseReferenceList _AnimalGenderLookup = new BaseReferenceList("rftAnimalGenderList");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsIdentificationMethod)]
        public BaseReference IdentificationMethod
        {
            get { return _IdentificationMethod == null ? null : ((long)_IdentificationMethod.Key == 0 ? null : _IdentificationMethod); }
            set 
            { 
                _IdentificationMethod = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsIdentificationMethod = _IdentificationMethod == null 
                    ? new Int64?()
                    : _IdentificationMethod.idfsBaseReference; 
                OnPropertyChanged(_str_IdentificationMethod); 
            }
        }
        private BaseReference _IdentificationMethod;

        
        public BaseReferenceList IdentificationMethodLookup
        {
            get { return _IdentificationMethodLookup; }
        }
        private BaseReferenceList _IdentificationMethodLookup = new BaseReferenceList("rftIdentificationMethod");
            
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfCollectedByPerson)]
        public PersonLookup Collector
        {
            get { return _Collector == null ? null : ((long)_Collector.Key == 0 ? null : _Collector); }
            set 
            { 
                _Collector = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfCollectedByPerson = _Collector == null 
                    ? new Int64?()
                    : _Collector.idfPerson; 
                OnPropertyChanged(_str_Collector); 
            }
        }
        private PersonLookup _Collector;

        
        public List<PersonLookup> CollectorLookup
        {
            get { return _CollectorLookup; }
        }
        private List<PersonLookup> _CollectorLookup = new List<PersonLookup>();
            
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfIdentifiedByPerson)]
        public PersonLookup Identifier
        {
            get { return _Identifier == null ? null : ((long)_Identifier.Key == 0 ? null : _Identifier); }
            set 
            { 
                _Identifier = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfIdentifiedByPerson = _Identifier == null 
                    ? new Int64?()
                    : _Identifier.idfPerson; 
                OnPropertyChanged(_str_Identifier); 
            }
        }
        private PersonLookup _Identifier;

        
        public List<PersonLookup> IdentifierLookup
        {
            get { return _IdentifierLookup; }
        }
        private List<PersonLookup> _IdentifierLookup = new List<PersonLookup>();
            
        [Relation(typeof(CountryLookup), eidss.model.Schema.CountryLookup._str_idfsCountry, _str_idfsCountry)]
        public CountryLookup Country
        {
            get { return _Country == null ? null : ((long)_Country.Key == 0 ? null : _Country); }
            set 
            { 
                _Country = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCountry = _Country == null 
                    ? new Int64?()
                    : _Country.idfsCountry; 
                OnPropertyChanged(_str_Country); 
            }
        }
        private CountryLookup _Country;

        
        public List<CountryLookup> CountryLookup
        {
            get { return _CountryLookup; }
        }
        private List<CountryLookup> _CountryLookup = new List<CountryLookup>();
            
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
            
        [Relation(typeof(SettlementLookup), eidss.model.Schema.SettlementLookup._str_idfsSettlement, _str_idfsSettlement)]
        public SettlementLookup Settlement
        {
            get { return _Settlement == null ? null : ((long)_Settlement.Key == 0 ? null : _Settlement); }
            set 
            { 
                _Settlement = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSettlement = _Settlement == null 
                    ? new Int64?()
                    : _Settlement.idfsSettlement; 
                OnPropertyChanged(_str_Settlement); 
            }
        }
        private SettlementLookup _Settlement;

        
        public List<SettlementLookup> SettlementLookup
        {
            get { return _SettlementLookup; }
        }
        private List<SettlementLookup> _SettlementLookup = new List<SettlementLookup>();
            
        [Relation(typeof(VectorTypeLookup), eidss.model.Schema.VectorTypeLookup._str_idfsBaseReference, _str_idfsVectorType)]
        public VectorTypeLookup VectorTypes
        {
            get { return _VectorTypes == null ? null : ((long)_VectorTypes.Key == 0 ? null : _VectorTypes); }
            set 
            { 
                _VectorTypes = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsVectorType = _VectorTypes == null 
                    ? new Int64()
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
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsEctoparasitesCollected)]
        public BaseReference EctoparasitesCollected
        {
            get { return _EctoparasitesCollected == null ? null : ((long)_EctoparasitesCollected.Key == 0 ? null : _EctoparasitesCollected); }
            set 
            { 
                _EctoparasitesCollected = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsEctoparasitesCollected = _EctoparasitesCollected == null 
                    ? new Int64?()
                    : _EctoparasitesCollected.idfsBaseReference; 
                OnPropertyChanged(_str_EctoparasitesCollected); 
            }
        }
        private BaseReference _EctoparasitesCollected;

        
        public BaseReferenceList EctoparasitesCollectedLookup
        {
            get { return _EctoparasitesCollectedLookup; }
        }
        private BaseReferenceList _EctoparasitesCollectedLookup = new BaseReferenceList("rftYesNoValue");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_CollectedByOffice:
                    return new BvSelectList(CollectedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, CollectedByOffice, _str_idfCollectedByOffice);
            
                case _str_IdentifiedByOffice:
                    return new BvSelectList(IdentifiedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, IdentifiedByOffice, _str_idfIdentifiedByOffice);
            
                case _str_VsSurrounding:
                    return new BvSelectList(VsSurroundingLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, VsSurrounding, _str_idfsSurrounding);
            
                case _str_DayPeriod:
                    return new BvSelectList(DayPeriodLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, DayPeriod, _str_idfsDayPeriod);
            
                case _str_CollectionMethod:
                    return new BvSelectList(CollectionMethodLookup, eidss.model.Schema.CollectionMethodLookup._str_idfsCollectionMethod, null, CollectionMethod, _str_idfsCollectionMethod);
            
                case _str_BasisOfRecord:
                    return new BvSelectList(BasisOfRecordLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, BasisOfRecord, _str_idfsBasisOfRecord);
            
                case _str_VsVectorType:
                    return new BvSelectList(VsVectorTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, VsVectorType, _str_idfsVectorType);
            
                case _str_VsVectorSubType:
                    return new BvSelectList(VsVectorSubTypeLookup, eidss.model.Schema.VectorSubTypeLookup._str_idfsBaseReference, null, VsVectorSubType, _str_idfsVectorSubType);
            
                case _str_AnimalGender:
                    return new BvSelectList(AnimalGenderLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AnimalGender, _str_idfsSex);
            
                case _str_IdentificationMethod:
                    return new BvSelectList(IdentificationMethodLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, IdentificationMethod, _str_idfsIdentificationMethod);
            
                case _str_Collector:
                    return new BvSelectList(CollectorLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, Collector, _str_idfCollectedByPerson);
            
                case _str_Identifier:
                    return new BvSelectList(IdentifierLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, Identifier, _str_idfIdentifiedByPerson);
            
                case _str_Country:
                    return new BvSelectList(CountryLookup, eidss.model.Schema.CountryLookup._str_idfsCountry, null, Country, _str_idfsCountry);
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionLookup._str_idfsRegion, null, Region, _str_idfsRegion);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonLookup._str_idfsRayon, null, Rayon, _str_idfsRayon);
            
                case _str_Settlement:
                    return new BvSelectList(SettlementLookup, eidss.model.Schema.SettlementLookup._str_idfsSettlement, null, Settlement, _str_idfsSettlement);
            
                case _str_VectorTypes:
                    return new BvSelectList(VectorTypesLookup, eidss.model.Schema.VectorTypeLookup._str_idfsBaseReference, null, VectorTypes, _str_idfsVectorType);
            
                case _str_EctoparasitesCollected:
                    return new BvSelectList(EctoparasitesCollectedLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, EctoparasitesCollected, _str_idfsEctoparasitesCollected);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_Vectors)]
        public EditableList<Vector> Vectors
        {
            get { return new Func<Vector, EditableList<Vector>>(c => c.Parent == null ? new EditableList<Vector>() : ((VsSession)c.Parent).PoolsVectors)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Samples)]
        public EditableList<VectorSample> Samples
        {
            get { return new Func<Vector, EditableList<VectorSample>>(c => c.Parent == null ? new EditableList<VectorSample>() : ((VsSession)c.Parent).Samples)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_FieldTests)]
        public EditableList<VectorFieldTest> FieldTests
        {
            get { return new Func<Vector, EditableList<VectorFieldTest>>(c => c.Parent == null ? new EditableList<VectorFieldTest>() : ((VsSession)c.Parent).FieldTests)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_LabTests)]
        public EditableList<VectorLabTest> LabTests
        {
            get { return new Func<Vector, EditableList<VectorLabTest>>(c => c.Parent == null ? new EditableList<VectorLabTest>() : ((VsSession)c.Parent).LabTests)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsPoolVectorType)]
        public bool IsPoolVectorType
        {
            get { return new Func<Vector, bool>(c => c.VectorTypesLookup.Where(m => m.idfsBaseReference == c.idfsVectorType).FirstOrDefault() != null ? c.VectorTypesLookup.Where(m => m.idfsBaseReference == idfsVectorType).FirstOrDefault().bitCollectionByPool : false)(this); }
            
        }
        
          [LocalizedDisplayName(_str_HostVector)]
        public Vector HostVector
        {
            get { return m_HostVector; }
            set { if (m_HostVector != value) { m_HostVector = value; OnPropertyChanged(_str_HostVector); } }
        }
        private Vector m_HostVector;
        
          [LocalizedDisplayName(_str_strVectorSpecificData)]
        public string strVectorSpecificData
        {
            get { return m_strVectorSpecificData; }
            set { if (m_strVectorSpecificData != value) { m_strVectorSpecificData = value; OnPropertyChanged(_str_strVectorSpecificData); } }
        }
        private string m_strVectorSpecificData;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Vector";

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
                
            if (_FFPresenter != null) { _FFPresenter.Parent = this; }
                SampleTypesMatrix.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as Vector;
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
            var ret = base.Clone() as Vector;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Location != null)
              ret.Location = _Location.CloneWithSetup(manager) as GeoLocation;
                
            if (_FFPresenter != null)
              ret.FFPresenter = _FFPresenter.CloneWithSetup(manager) as FFPresenterModel;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public Vector CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Vector;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfVector; } }
        public string KeyName { get { return "idfVector"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || (_Location != null && _Location.HasChanges)
                
                    || (_FFPresenter != null && _FFPresenter.HasChanges)
                
                    || SampleTypesMatrix.IsDirty
                    || SampleTypesMatrix.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfCollectedByOffice_CollectedByOffice = idfCollectedByOffice;
            var _prev_idfIdentifiedByOffice_IdentifiedByOffice = idfIdentifiedByOffice;
            var _prev_idfsSurrounding_VsSurrounding = idfsSurrounding;
            var _prev_idfsDayPeriod_DayPeriod = idfsDayPeriod;
            var _prev_idfsCollectionMethod_CollectionMethod = idfsCollectionMethod;
            var _prev_idfsBasisOfRecord_BasisOfRecord = idfsBasisOfRecord;
            var _prev_idfsVectorType_VsVectorType = idfsVectorType;
            var _prev_idfsVectorSubType_VsVectorSubType = idfsVectorSubType;
            var _prev_idfsSex_AnimalGender = idfsSex;
            var _prev_idfsIdentificationMethod_IdentificationMethod = idfsIdentificationMethod;
            var _prev_idfCollectedByPerson_Collector = idfCollectedByPerson;
            var _prev_idfIdentifiedByPerson_Identifier = idfIdentifiedByPerson;
            var _prev_idfsCountry_Country = idfsCountry;
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            var _prev_idfsSettlement_Settlement = idfsSettlement;
            var _prev_idfsVectorType_VectorTypes = idfsVectorType;
            var _prev_idfsEctoparasitesCollected_EctoparasitesCollected = idfsEctoparasitesCollected;
            base.RejectChanges();
        
            if (_prev_idfCollectedByOffice_CollectedByOffice != idfCollectedByOffice)
            {
                _CollectedByOffice = _CollectedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfCollectedByOffice);
            }
            if (_prev_idfIdentifiedByOffice_IdentifiedByOffice != idfIdentifiedByOffice)
            {
                _IdentifiedByOffice = _IdentifiedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfIdentifiedByOffice);
            }
            if (_prev_idfsSurrounding_VsSurrounding != idfsSurrounding)
            {
                _VsSurrounding = _VsSurroundingLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSurrounding);
            }
            if (_prev_idfsDayPeriod_DayPeriod != idfsDayPeriod)
            {
                _DayPeriod = _DayPeriodLookup.FirstOrDefault(c => c.idfsBaseReference == idfsDayPeriod);
            }
            if (_prev_idfsCollectionMethod_CollectionMethod != idfsCollectionMethod)
            {
                _CollectionMethod = _CollectionMethodLookup.FirstOrDefault(c => c.idfsCollectionMethod == idfsCollectionMethod);
            }
            if (_prev_idfsBasisOfRecord_BasisOfRecord != idfsBasisOfRecord)
            {
                _BasisOfRecord = _BasisOfRecordLookup.FirstOrDefault(c => c.idfsBaseReference == idfsBasisOfRecord);
            }
            if (_prev_idfsVectorType_VsVectorType != idfsVectorType)
            {
                _VsVectorType = _VsVectorTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorType);
            }
            if (_prev_idfsVectorSubType_VsVectorSubType != idfsVectorSubType)
            {
                _VsVectorSubType = _VsVectorSubTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorSubType);
            }
            if (_prev_idfsSex_AnimalGender != idfsSex)
            {
                _AnimalGender = _AnimalGenderLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSex);
            }
            if (_prev_idfsIdentificationMethod_IdentificationMethod != idfsIdentificationMethod)
            {
                _IdentificationMethod = _IdentificationMethodLookup.FirstOrDefault(c => c.idfsBaseReference == idfsIdentificationMethod);
            }
            if (_prev_idfCollectedByPerson_Collector != idfCollectedByPerson)
            {
                _Collector = _CollectorLookup.FirstOrDefault(c => c.idfPerson == idfCollectedByPerson);
            }
            if (_prev_idfIdentifiedByPerson_Identifier != idfIdentifiedByPerson)
            {
                _Identifier = _IdentifierLookup.FirstOrDefault(c => c.idfPerson == idfIdentifiedByPerson);
            }
            if (_prev_idfsCountry_Country != idfsCountry)
            {
                _Country = _CountryLookup.FirstOrDefault(c => c.idfsCountry == idfsCountry);
            }
            if (_prev_idfsRegion_Region != idfsRegion)
            {
                _Region = _RegionLookup.FirstOrDefault(c => c.idfsRegion == idfsRegion);
            }
            if (_prev_idfsRayon_Rayon != idfsRayon)
            {
                _Rayon = _RayonLookup.FirstOrDefault(c => c.idfsRayon == idfsRayon);
            }
            if (_prev_idfsSettlement_Settlement != idfsSettlement)
            {
                _Settlement = _SettlementLookup.FirstOrDefault(c => c.idfsSettlement == idfsSettlement);
            }
            if (_prev_idfsVectorType_VectorTypes != idfsVectorType)
            {
                _VectorTypes = _VectorTypesLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorType);
            }
            if (_prev_idfsEctoparasitesCollected_EctoparasitesCollected != idfsEctoparasitesCollected)
            {
                _EctoparasitesCollected = _EctoparasitesCollectedLookup.FirstOrDefault(c => c.idfsBaseReference == idfsEctoparasitesCollected);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (Location != null) Location.RejectChanges();
                
            if (FFPresenter != null) FFPresenter.RejectChanges();
                SampleTypesMatrix.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Location != null) _Location.AcceptChanges();
                
            if (_FFPresenter != null) _FFPresenter.AcceptChanges();
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
        
            if (_Location != null) _Location.SetChange();
                
            if (_FFPresenter != null) _FFPresenter.SetChange();
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

      private bool IsRIRPropChanged(string fld, Vector c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public Vector()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Vector_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Vector_PropertyChanged);
        }
        private void Vector_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Vector).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_Vectors);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_Samples);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_FieldTests);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_LabTests);
                  
            if (e.PropertyName == _str_idfsVectorType)
                OnPropertyChanged(_str_IsPoolVectorType);
                  
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
            Vector obj = this;
            try
            {
            
                (new PredicateValidator("msgCantDeleteRecord", "", "", "",
              new object[] {
              },
                        false
                    )).Validate(obj, v => v.SamplesForThisVector.Count == 0
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
            Vector obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Vector obj = this;
            
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

    
        private static string[] readonly_names1 = "strVectorID".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strSessionID".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "strVectorType".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "idfsVectorType".Split(new char[] { ',' });
        
        private static string[] readonly_names5 = "strCollectedByOffice,strCollectedByPerson,strIdentifiedByOffice,strIdentifiedByPerson".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Vector, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Vector, bool>(c => true)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Vector, bool>(c => true)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Vector, bool>(c => true)(this);
            
            if (readonly_names5.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Vector, bool>(c => true)(this);
            
            return ReadOnly || new Func<Vector, bool>(c => c.ReadOnly)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_Location != null)
                    _Location.ReadOnly = value;
                
                if (_FFPresenter != null)
                    _FFPresenter.ReadOnly = value;
                
                foreach(var o in _SampleTypesMatrix)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<Vector, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Vector, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Vector, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<Vector, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<Vector, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<Vector, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~Vector()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("rftSurrounding", this);
                
                LookupManager.RemoveObject("rftDayPeriod", this);
                
                LookupManager.RemoveObject("CollectionMethodLookup", this);
                
                LookupManager.RemoveObject("rftBasisOfRecord", this);
                
                LookupManager.RemoveObject("rftVectorType", this);
                
                LookupManager.RemoveObject("VectorSubTypeLookup", this);
                
                LookupManager.RemoveObject("rftAnimalGenderList", this);
                
                LookupManager.RemoveObject("rftIdentificationMethod", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("CountryLookup", this);
                
                LookupManager.RemoveObject("RegionLookup", this);
                
                LookupManager.RemoveObject("RayonLookup", this);
                
                LookupManager.RemoveObject("SettlementLookup", this);
                
                LookupManager.RemoveObject("VectorTypeLookup", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_CollectedByOffice(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_IdentifiedByOffice(manager, this);
            
            if (lookup_object == "rftSurrounding")
                _getAccessor().LoadLookup_VsSurrounding(manager, this);
            
            if (lookup_object == "rftDayPeriod")
                _getAccessor().LoadLookup_DayPeriod(manager, this);
            
            if (lookup_object == "CollectionMethodLookup")
                _getAccessor().LoadLookup_CollectionMethod(manager, this);
            
            if (lookup_object == "rftBasisOfRecord")
                _getAccessor().LoadLookup_BasisOfRecord(manager, this);
            
            if (lookup_object == "rftVectorType")
                _getAccessor().LoadLookup_VsVectorType(manager, this);
            
            if (lookup_object == "VectorSubTypeLookup")
                _getAccessor().LoadLookup_VsVectorSubType(manager, this);
            
            if (lookup_object == "rftAnimalGenderList")
                _getAccessor().LoadLookup_AnimalGender(manager, this);
            
            if (lookup_object == "rftIdentificationMethod")
                _getAccessor().LoadLookup_IdentificationMethod(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_Collector(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_Identifier(manager, this);
            
            if (lookup_object == "CountryLookup")
                _getAccessor().LoadLookup_Country(manager, this);
            
            if (lookup_object == "RegionLookup")
                _getAccessor().LoadLookup_Region(manager, this);
            
            if (lookup_object == "RayonLookup")
                _getAccessor().LoadLookup_Rayon(manager, this);
            
            if (lookup_object == "SettlementLookup")
                _getAccessor().LoadLookup_Settlement(manager, this);
            
            if (lookup_object == "VectorTypeLookup")
                _getAccessor().LoadLookup_VectorTypes(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_EctoparasitesCollected(manager, this);
            
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
        
            if (_Location != null) _Location.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_FFPresenter != null) _FFPresenter.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_SampleTypesMatrix != null) _SampleTypesMatrix.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    
        #region Class for web grid
        public class VectorGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfVector { get; set; }
        
            public String strVectorID { get; set; }
        
            public String strFieldVectorID { get; set; }
        
            public String strRegion { get; set; }
        
            public String strRayon { get; set; }
        
            public String strSettlement { get; set; }
        
            public Double? dblLatitude { get; set; }
        
            public Double? dblLongitude { get; set; }
        
            public Int32? intElevation { get; set; }
        
            public String strSurrounding { get; set; }
        
            public DateTime datCollectionDateTime { get; set; }
        
            public String strDayPeriod { get; set; }
        
            public String strCollectedByPerson { get; set; }
        
            public String strCollectedByOffice { get; set; }
        
            public String strSpecies { get; set; }
        
            public Int32 intQuantity { get; set; }
        
            public String strSex { get; set; }
        
            public String strEctoparasitesCollected { get; set; }
        
            public String strHostVector { get; set; }
        
            public String strCollectionMethod { get; set; }
        
            public String strBasisOfRecord { get; set; }
        
            public String strGEOReferenceSources { get; set; }
        
            public String strIdentifiedByPerson { get; set; }
        
            public String strIdentifiedByOffice { get; set; }
        
            public DateTime? datIdentifiedDateTime { get; set; }
        
            public String strIdentificationMethod { get; set; }
        
            public String strVectorSpecificData { get; set; }
        
        }
        public partial class VectorGridModelList : List<VectorGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public VectorGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<Vector>, errMes);
            }
            public VectorGridModelList(long key, IEnumerable<Vector> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<Vector> items);
            private void LoadGridModelList(long key, IEnumerable<Vector> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strVectorID,_str_strFieldVectorID,_str_strRegion,_str_strRayon,_str_strSettlement,_str_dblLatitude,_str_dblLongitude,_str_intElevation,_str_strSurrounding,_str_datCollectionDateTime,_str_strDayPeriod,_str_strCollectedByPerson,_str_strCollectedByOffice,_str_strSpecies,_str_intQuantity,_str_strSex,_str_strEctoparasitesCollected,_str_strHostVector,_str_strCollectionMethod,_str_strBasisOfRecord,_str_strGEOReferenceSources,_str_strIdentifiedByPerson,_str_strIdentifiedByOffice,_str_datIdentifiedDateTime,_str_strIdentificationMethod,_str_strVectorSpecificData};
                    
                Hiddens = new List<string> {_str_idfVector};
                Keys = new List<string> {_str_idfVector};
                Labels = new Dictionary<string, string> {{_str_strVectorID, "Vector.strVectorID"},{_str_strFieldVectorID, "Vector.strFieldVectorID"},{_str_strRegion, _str_strRegion},{_str_strRayon, _str_strRayon},{_str_strSettlement, "Vector.strSettlement"},{_str_dblLatitude, "VsSessionListItem.dblLatitude"},{_str_dblLongitude, "VsSessionListItem.dblLongitude"},{_str_intElevation, _str_intElevation},{_str_strSurrounding, _str_strSurrounding},{_str_datCollectionDateTime, "datFieldCollectionDate"},{_str_strDayPeriod, _str_strDayPeriod},{_str_strCollectedByPerson, "Vector.idfFieldCollectedByPerson"},{_str_strCollectedByOffice, "VectorSample.idfFieldCollectedByOffice"},{_str_strSpecies, _str_strSpecies},{_str_intQuantity, _str_intQuantity},{_str_strSex, "idfsAnimalGender"},{_str_strEctoparasitesCollected, _str_strEctoparasitesCollected},{_str_strHostVector, "idfHostVector"},{_str_strCollectionMethod, _str_strCollectionMethod},{_str_strBasisOfRecord, _str_strBasisOfRecord},{_str_strGEOReferenceSources, _str_strGEOReferenceSources},{_str_strIdentifiedByPerson, _str_strIdentifiedByPerson},{_str_strIdentifiedByOffice, _str_strIdentifiedByOffice},{_str_datIdentifiedDateTime, _str_datIdentifiedDateTime},{_str_strIdentificationMethod, _str_strIdentificationMethod},{_str_strVectorSpecificData, _str_strVectorSpecificData}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<Vector>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VectorGridModel()
                {
                    ItemKey=c.idfVector,strVectorID=c.strVectorID,strFieldVectorID=c.strFieldVectorID,strRegion=c.strRegion,strRayon=c.strRayon,strSettlement=c.strSettlement,dblLatitude=c.dblLatitude,dblLongitude=c.dblLongitude,intElevation=c.intElevation,strSurrounding=c.strSurrounding,datCollectionDateTime=c.datCollectionDateTime,strDayPeriod=c.strDayPeriod,strCollectedByPerson=c.strCollectedByPerson,strCollectedByOffice=c.strCollectedByOffice,strSpecies=c.strSpecies,intQuantity=c.intQuantity,strSex=c.strSex,strEctoparasitesCollected=c.strEctoparasitesCollected,strHostVector=c.strHostVector,strCollectionMethod=c.strCollectionMethod,strBasisOfRecord=c.strBasisOfRecord,strGEOReferenceSources=c.strGEOReferenceSources,strIdentifiedByPerson=c.strIdentifiedByPerson,strIdentifiedByOffice=c.strIdentifiedByOffice,datIdentifiedDateTime=c.datIdentifiedDateTime,strIdentificationMethod=c.strIdentificationMethod,strVectorSpecificData=c.strVectorSpecificData
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
        : DataAccessor<Vector>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(Vector obj);
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
            private FFPresenterModel.Accessor FFPresenterAccessor { get { return eidss.model.Schema.FFPresenterModel.Accessor.Instance(m_CS); } }
            private VectorType2SampleTypeLookup.Accessor SampleTypesMatrixAccessor { get { return eidss.model.Schema.VectorType2SampleTypeLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor CollectedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor IdentifiedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor VsSurroundingAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor DayPeriodAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private CollectionMethodLookup.Accessor CollectionMethodAccessor { get { return eidss.model.Schema.CollectionMethodLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor BasisOfRecordAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor VsVectorTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private VectorSubTypeLookup.Accessor VsVectorSubTypeAccessor { get { return eidss.model.Schema.VectorSubTypeLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AnimalGenderAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor IdentificationMethodAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor CollectorAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor IdentifierAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            private CountryLookup.Accessor CountryAccessor { get { return eidss.model.Schema.CountryLookup.Accessor.Instance(m_CS); } }
            private RegionLookup.Accessor RegionAccessor { get { return eidss.model.Schema.RegionLookup.Accessor.Instance(m_CS); } }
            private RayonLookup.Accessor RayonAccessor { get { return eidss.model.Schema.RayonLookup.Accessor.Instance(m_CS); } }
            private SettlementLookup.Accessor SettlementAccessor { get { return eidss.model.Schema.SettlementLookup.Accessor.Instance(m_CS); } }
            private VectorTypeLookup.Accessor VectorTypesAccessor { get { return eidss.model.Schema.VectorTypeLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor EctoparasitesCollectedAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<Vector> SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                )
            {
                return _SelectList(manager
                    , idfVectorSurveillanceSession
                    , delegate(Vector obj)
                        {
                        }
                    , delegate(Vector obj)
                        {
                        }
                    );
            }

            
            private List<Vector> _SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<Vector> objs = new List<Vector>();
                    sets[0] = new MapResultSet(typeof(Vector), objs);
                    
                    manager
                        .SetSpCommand("spVector_SelectDetail"
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
    
            private void _SetupAddChildHandlerSampleTypesMatrix(Vector obj)
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
            
            internal void _LoadLocation(Vector obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLocation(manager, obj);
                }
            }
            internal void _LoadLocation(DbManagerProxy manager, Vector obj)
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
            
            internal void _LoadFFPresenter(Vector obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFFPresenter(manager, obj);
                }
            }
            internal void _LoadFFPresenter(DbManagerProxy manager, Vector obj)
            {
                
                if (obj.FFPresenter == null && obj.idfObservation != null && obj.idfObservation != 0)
                {
                    obj.FFPresenter = FFPresenterAccessor.SelectByKey(manager
                        
                        , obj.idfObservation.Value
                        );
                    if (obj.FFPresenter != null)
                    {
                        obj.FFPresenter.m_ObjectName = _str_FFPresenter;
                    }
                }
                    
            }
            
            internal void _LoadSampleTypesMatrix(Vector obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSampleTypesMatrix(manager, obj);
                }
            }
            internal void _LoadSampleTypesMatrix(DbManagerProxy manager, Vector obj)
            {
                
                obj.SampleTypesMatrix.Clear();
                obj.SampleTypesMatrix.AddRange(SampleTypesMatrixAccessor.SelectDetailList(manager
                    
                    , obj.idfsVectorType
                    ));
                obj.SampleTypesMatrix.ForEach(c => c.m_ObjectName = _str_SampleTypesMatrix);
                obj.SampleTypesMatrix.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, Vector obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadLocation(manager, obj);
                _LoadFFPresenter(manager, obj);
                _LoadSampleTypesMatrix(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                    if (obj.idfsFormTemplate.HasValue) obj.FFPresenter.SetProperties(obj.idfsFormTemplate.Value);
                  
                    if (obj.idfHostVector.HasValue && (obj.Vectors != null)) obj.HostVector = obj.Vectors.Where(v => v.idfVector == obj.idfHostVector).FirstOrDefault();
                  
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
            
            internal void _SetPermitions(IObjectPermissions permissions, Vector obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    LocationAccessor._SetPermitions(obj._permissions, obj.Location);
                    FFPresenterAccessor._SetPermitions(obj._permissions, obj.FFPresenter);
                    
                        obj.SampleTypesMatrix.ForEach(c => SampleTypesMatrixAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private Vector _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    Vector obj = Vector.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfVector = (new GetNewIDExtender<Vector>()).GetScalar(manager, obj);
                obj.strVectorID = new Func<Vector, DbManagerProxy, string>((c,m) => 
                        m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.VsVector, DBNull.Value, DBNull.Value)
                        .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue"))(obj, manager);
                obj.Location = new Func<Vector, GeoLocation>(c => c.Location == null ? LocationAccessor.CreateWithCountry(manager, c) : c.Location)(obj);
                obj.intQuantity = new Func<Vector, int>(c => 1)(obj);
                obj.datCollectionDateTime = new Func<Vector, DateTime>(c => DateTime.Now)(obj);
                obj.idfObservation = (new GetNewIDExtender<Vector>()).GetScalar(manager, obj);
                      obj.FFPresenter = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, obj.idfObservation);
                      obj.FFPresenter.SetProperties(EidssSiteContext.Instance.CountryID, obj.idfsVectorType, FFTypeEnum.VectorTypeSpecificData, obj.idfObservation.Value);
                      if (obj.FFPresenter.CurrentTemplate != null)
                      {
                        obj.idfsFormTemplate = obj.FFPresenter.CurrentTemplate.idfsFormTemplate;
                      }
                    
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerSampleTypesMatrix(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.Country = new Func<Vector, CountryLookup>(c => 
                                      c.CountryLookup.Where(a => a.idfsCountry == EidssSiteContext.Instance.CountryID)
                                      .SingleOrDefault())(obj);
                obj.idfVector = new Func<Vector, DbManagerProxy, long>((c,m) => { _LoadSampleTypesMatrix(m,c); return c.idfVector; })(obj, manager);
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

            
            public Vector CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public Vector CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public Vector CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 10) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfVectorSurveillanceSession", typeof(long));
                if (pars[1] != null && !(pars[1] is long)) 
                    throw new TypeMismatchException("idfsVectorType", typeof(long));
                if (pars[2] != null && !(pars[2] is string)) 
                    throw new TypeMismatchException("strVectorType", typeof(string));
                if (pars[3] != null && !(pars[3] is DateTime)) 
                    throw new TypeMismatchException("datCollectionDateTime", typeof(DateTime));
                if (pars[4] != null && !(pars[4] is string)) 
                    throw new TypeMismatchException("strSessionID", typeof(string));
                if (pars[5] != null && !(pars[5] is EditableList<Vector>)) 
                    throw new TypeMismatchException("Vectors", typeof(EditableList<Vector>));
                if (pars[6] != null && !(pars[6] is EditableList<VectorSample>)) 
                    throw new TypeMismatchException("Samples", typeof(EditableList<VectorSample>));
                if (pars[7] != null && !(pars[7] is GeoLocation)) 
                    throw new TypeMismatchException("Location", typeof(GeoLocation));
                if (pars[8] != null && !(pars[8] is EditableList<VectorFieldTest>)) 
                    throw new TypeMismatchException("fieldTests", typeof(EditableList<VectorFieldTest>));
                if (pars[9] != null && !(pars[9] is EditableList<VectorLabTest>)) 
                    throw new TypeMismatchException("labTests", typeof(EditableList<VectorLabTest>));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    , (long)pars[1]
                    , (string)pars[2]
                    , (DateTime)pars[3]
                    , (string)pars[4]
                    , (EditableList<Vector>)pars[5]
                    , (EditableList<VectorSample>)pars[6]
                    , (GeoLocation)pars[7]
                    , (EditableList<VectorFieldTest>)pars[8]
                    , (EditableList<VectorLabTest>)pars[9]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public Vector Create(DbManagerProxy manager, IObject Parent
                , long idfVectorSurveillanceSession
                , long idfsVectorType
                , string strVectorType
                , DateTime datCollectionDateTime
                , string strSessionID
                , EditableList<Vector> Vectors
                , EditableList<VectorSample> Samples
                , GeoLocation Location
                , EditableList<VectorFieldTest> fieldTests
                , EditableList<VectorLabTest> labTests
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfVectorSurveillanceSession = new Func<Vector, long>(c => idfVectorSurveillanceSession)(obj);
                obj.idfsVectorType = new Func<Vector, long>(c => idfsVectorType)(obj);
                obj.strVectorType = new Func<Vector, string>(c => strVectorType)(obj);
                obj.datCollectionDateTime = new Func<Vector, DateTime>(c => datCollectionDateTime)(obj);
                obj.strSessionID = new Func<Vector, string>(c => strSessionID)(obj);
                      obj.Location = LocationAccessor.CreateWithCountry(manager, obj);
                      obj.Location.strDescription = Location.strDescription;
                      obj.Location.blnGeoLocationShared = Location.blnGeoLocationShared;
                      obj.Location.Region = Location.Region;
                      obj.Location.Rayon = Location.Rayon;
                      obj.Location.Settlement = Location.Settlement;
                      obj.Location.dblLatitude = Location.dblLatitude;
                      obj.Location.dblLongitude = Location.dblLongitude;
                      obj.Location.dblDistance = Location.dblDistance;
                      obj.Location.dblAccuracy = Location.dblAccuracy;
                      obj.Location.GeoLocationType = Location.GeoLocationType;
                      obj.Location.GroundType = Location.GroundType;
                      
                }
                    , obj =>
                {
                }
                );
            }
            
            public ActResult VectorOk(DbManagerProxy manager, Vector obj, List<object> pars)
            {
                
                return VectorOk(manager, obj
                    );
            }
            public ActResult VectorOk(DbManagerProxy manager, Vector obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("VectorOk"))
                    throw new PermissionException("VsSession", "VectorOk");
                
                  return (obj.GetAccessor() as IObjectValidator).Validate(manager, obj, true, true, true);
                
            }
            
            private void _SetupChildHandlers(Vector obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Vector obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.Region = (new SetScalarHandler()).Handler(obj,
                    obj.idfsCountry, obj.idfsCountry_Previous, obj.Region,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.Rayon = (new SetScalarHandler()).Handler(obj,
                    obj.idfsRegion, obj.idfsRegion_Previous, obj.Rayon,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                obj.Settlement = (new SetScalarHandler()).Handler(obj,
                    obj.idfsRayon, obj.idfsRayon_Previous, obj.Settlement,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                obj.strVectorType = new Func<Vector, string>(c => c.VsVectorType == null ? "" : c.VsVectorType.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorSubType)
                        {
                    
                obj.strSpecies = new Func<Vector, string>(c => c.VsVectorSubType == null ? "" : c.VsVectorSubType.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Region(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Rayon(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Settlement(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.strCountry = new Func<Vector, string>(c =>c.Country == null ? "" : c.Country.strCountryName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.strRegion = new Func<Vector, string>(c =>c.Region == null ? "" : c.Region.strRegionName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                obj.strRayon = new Func<Vector, string>(c =>c.Rayon == null ? "" : c.Rayon.strRayonName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSettlement)
                        {
                    
                obj.strSettlement = new Func<Vector, string>(c =>c.Settlement == null ? "" : c.Settlement.strSettlementName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSurrounding)
                        {
                    
                obj.strSurrounding = new Func<Vector, string>(c => c.VsSurrounding == null ? "" : c.VsSurrounding.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfCollectedByOffice)
                        {
                    
                obj.strCollectedByOffice = new Func<Vector, string>(c => c.CollectedByOffice == null ? "" : c.CollectedByOffice.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfCollectedByPerson)
                        {
                    
                obj.strCollectedByPerson = new Func<Vector, string>(c => c.Collector == null ? "" : c.Collector.FullName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsCollectionMethod)
                        {
                    
                obj.strCollectionMethod = new Func<Vector, string>(c => c.CollectionMethod == null ? "" : c.CollectionMethod.CMName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsBasisOfRecord)
                        {
                    
                obj.strBasisOfRecord = new Func<Vector, string>(c => c.BasisOfRecord == null ? "" : c.BasisOfRecord.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsSex)
                        {
                    
                obj.strSex = new Func<Vector, string>(c => c.AnimalGender == null ? "" : c.AnimalGender.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfIdentifiedByOffice)
                        {
                    
                obj.strIdentifiedByOffice = new Func<Vector, string>(c => c.IdentifiedByOffice == null ? "" : c.IdentifiedByOffice.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfIdentifiedByPerson)
                        {
                    
                obj.strIdentifiedByPerson = new Func<Vector, string>(c => c.Identifier == null ? "" : c.Identifier.FullName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsIdentificationMethod)
                        {
                    
                obj.strIdentificationMethod = new Func<Vector, string>(c => c.IdentificationMethod == null ? "" : c.IdentificationMethod.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsDayPeriod)
                        {
                    
                obj.strDayPeriod = new Func<Vector, string>(c => c.DayPeriod == null ? "" : c.DayPeriod.name)(obj);
                        }
                    
                        if (e.PropertyName == _str_HostVector)
                        {
                    
                obj.idfHostVector = new Func<Vector, long?>(c => c.HostVector != null ? c.HostVector.idfVector : c.idfHostVector)(obj);
                        }
                    
                        if (e.PropertyName == _str_HostVector)
                        {
                    
                obj.strHostVector = new Func<Vector, string>(c => c.HostVector != null ? c.HostVector.strVectorID : c.strHostVector)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsEctoparasitesCollected)
                        {
                    
                obj.strEctoparasitesCollected = new Func<Vector, string>(c => c.idfsEctoparasitesCollected != null ? c.EctoparasitesCollected.name : c.strEctoparasitesCollected)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                obj.VsVectorSubType = new Func<Vector, VectorSubTypeLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_VsVectorSubType(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_Location)
                        {
                    
                    obj.RecalculateLocation();
                  
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                    obj.FFPresenter.SetProperties(EidssSiteContext.Instance.CountryID, obj.idfsVectorType, FFTypeEnum.VectorTypeSpecificData, obj.idfObservation.Value);
                    if (obj.FFPresenter.CurrentTemplate != null) obj.idfsFormTemplate = obj.FFPresenter.CurrentTemplate.idfsFormTemplate;
                  
                        }
                    
                        if (e.PropertyName == _str_idfCollectedByOffice)
                        {
                    
                    obj.FillSamplesDefaultProperties();
                  
                        }
                    
                        if (e.PropertyName == _str_datCollectionDateTime)
                        {
                    
                    obj.FillSamplesDefaultProperties();
                  
                        }
                    
                        if (e.PropertyName == _str_idfCollectedByOffice)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Collector(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfIdentifiedByOffice)
                        {
                    
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Identifier(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorSubType)
                        {
                    
                    foreach(var sample in obj.SamplesForThisVector)
                    {
                      sample.idfsVectorSubType = obj.idfsVectorSubType;
                      if (obj.VsVectorSubType != null) sample.strVectorSubTypeName = obj.VsVectorSubType.strDefault;
                    }
                  
                        }
                    
                    };
                
            }
    
            public void LoadLookup_CollectedByOffice(DbManagerProxy manager, Vector obj)
            {
                
                obj.CollectedByOfficeLookup.Clear();
                
                obj.CollectedByOfficeLookup.Add(CollectedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.CollectedByOfficeLookup.AddRange(CollectedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfCollectedByOffice))
                    
                    .ToList());
                
                if (obj.idfCollectedByOffice != 0)
                {
                    obj.CollectedByOffice = obj.CollectedByOfficeLookup
                        .Where(c => c.idfInstitution == obj.idfCollectedByOffice)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("OrganizationLookup", obj, CollectedByOfficeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_IdentifiedByOffice(DbManagerProxy manager, Vector obj)
            {
                
                obj.IdentifiedByOfficeLookup.Clear();
                
                obj.IdentifiedByOfficeLookup.Add(IdentifiedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.IdentifiedByOfficeLookup.AddRange(IdentifiedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfIdentifiedByOffice))
                    
                    .ToList());
                
                if (obj.idfIdentifiedByOffice != null && obj.idfIdentifiedByOffice != 0)
                {
                    obj.IdentifiedByOffice = obj.IdentifiedByOfficeLookup
                        .Where(c => c.idfInstitution == obj.idfIdentifiedByOffice)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("OrganizationLookup", obj, IdentifiedByOfficeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_VsSurrounding(DbManagerProxy manager, Vector obj)
            {
                
                obj.VsSurroundingLookup.Clear();
                
                obj.VsSurroundingLookup.Add(VsSurroundingAccessor.CreateNewT(manager, null));
                
                obj.VsSurroundingLookup.AddRange(VsSurroundingAccessor.rftSurrounding_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSurrounding))
                    
                    .ToList());
                
                if (obj.idfsSurrounding != null && obj.idfsSurrounding != 0)
                {
                    obj.VsSurrounding = obj.VsSurroundingLookup
                        .Where(c => c.idfsBaseReference == obj.idfsSurrounding)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftSurrounding", obj, VsSurroundingAccessor.GetType(), "rftSurrounding_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_DayPeriod(DbManagerProxy manager, Vector obj)
            {
                
                obj.DayPeriodLookup.Clear();
                
                obj.DayPeriodLookup.Add(DayPeriodAccessor.CreateNewT(manager, null));
                
                obj.DayPeriodLookup.AddRange(DayPeriodAccessor.rftDayPeriod_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsDayPeriod))
                    
                    .ToList());
                
                if (obj.idfsDayPeriod != null && obj.idfsDayPeriod != 0)
                {
                    obj.DayPeriod = obj.DayPeriodLookup
                        .Where(c => c.idfsBaseReference == obj.idfsDayPeriod)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftDayPeriod", obj, DayPeriodAccessor.GetType(), "rftDayPeriod_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_CollectionMethod(DbManagerProxy manager, Vector obj)
            {
                
                obj.CollectionMethodLookup.Clear();
                
                obj.CollectionMethodLookup.Add(CollectionMethodAccessor.CreateNewT(manager, null));
                
                obj.CollectionMethodLookup.AddRange(CollectionMethodAccessor.SelectLookupList(manager
                    
                    , new Func<Vector, long>(c => c.idfsVectorType)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsCollectionMethod == obj.idfsCollectionMethod))
                    
                    .ToList());
                
                if (obj.idfsCollectionMethod != null && obj.idfsCollectionMethod != 0)
                {
                    obj.CollectionMethod = obj.CollectionMethodLookup
                        .Where(c => c.idfsCollectionMethod == obj.idfsCollectionMethod)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("CollectionMethodLookup", obj, CollectionMethodAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_BasisOfRecord(DbManagerProxy manager, Vector obj)
            {
                
                obj.BasisOfRecordLookup.Clear();
                
                obj.BasisOfRecordLookup.Add(BasisOfRecordAccessor.CreateNewT(manager, null));
                
                obj.BasisOfRecordLookup.AddRange(BasisOfRecordAccessor.rftBasisOfRecord_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsBasisOfRecord))
                    
                    .ToList());
                
                if (obj.idfsBasisOfRecord != null && obj.idfsBasisOfRecord != 0)
                {
                    obj.BasisOfRecord = obj.BasisOfRecordLookup
                        .Where(c => c.idfsBaseReference == obj.idfsBasisOfRecord)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftBasisOfRecord", obj, BasisOfRecordAccessor.GetType(), "rftBasisOfRecord_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_VsVectorType(DbManagerProxy manager, Vector obj)
            {
                
                obj.VsVectorTypeLookup.Clear();
                
                obj.VsVectorTypeLookup.Add(VsVectorTypeAccessor.CreateNewT(manager, null));
                
                obj.VsVectorTypeLookup.AddRange(VsVectorTypeAccessor.rftVectorType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorType))
                    
                    .ToList());
                
                if (obj.idfsVectorType != 0)
                {
                    obj.VsVectorType = obj.VsVectorTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsVectorType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftVectorType", obj, VsVectorTypeAccessor.GetType(), "rftVectorType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_VsVectorSubType(DbManagerProxy manager, Vector obj)
            {
                
                obj.VsVectorSubTypeLookup.Clear();
                
                obj.VsVectorSubTypeLookup.Add(VsVectorSubTypeAccessor.CreateNewT(manager, null));
                
                obj.VsVectorSubTypeLookup.AddRange(VsVectorSubTypeAccessor.SelectLookupList(manager
                    
                    , new Func<Vector, long>(c => c.idfsVectorType > 0 ? c.idfsVectorType : 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorSubType))
                    
                    .ToList());
                
                if (obj.idfsVectorSubType != 0)
                {
                    obj.VsVectorSubType = obj.VsVectorSubTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsVectorSubType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("VectorSubTypeLookup", obj, VsVectorSubTypeAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_AnimalGender(DbManagerProxy manager, Vector obj)
            {
                
                obj.AnimalGenderLookup.Clear();
                
                obj.AnimalGenderLookup.Add(AnimalGenderAccessor.CreateNewT(manager, null));
                
                obj.AnimalGenderLookup.AddRange(AnimalGenderAccessor.rftAnimalGenderList_SelectList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Vector) != 0) || c.idfsBaseReference == obj.idfsSex)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSex))
                    
                    .ToList());
                
                if (obj.idfsSex != null && obj.idfsSex != 0)
                {
                    obj.AnimalGender = obj.AnimalGenderLookup
                        .Where(c => c.idfsBaseReference == obj.idfsSex)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftAnimalGenderList", obj, AnimalGenderAccessor.GetType(), "rftAnimalGenderList_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_IdentificationMethod(DbManagerProxy manager, Vector obj)
            {
                
                obj.IdentificationMethodLookup.Clear();
                
                obj.IdentificationMethodLookup.Add(IdentificationMethodAccessor.CreateNewT(manager, null));
                
                obj.IdentificationMethodLookup.AddRange(IdentificationMethodAccessor.rftIdentificationMethod_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsIdentificationMethod))
                    
                    .ToList());
                
                if (obj.idfsIdentificationMethod != null && obj.idfsIdentificationMethod != 0)
                {
                    obj.IdentificationMethod = obj.IdentificationMethodLookup
                        .Where(c => c.idfsBaseReference == obj.idfsIdentificationMethod)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftIdentificationMethod", obj, IdentificationMethodAccessor.GetType(), "rftIdentificationMethod_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Collector(DbManagerProxy manager, Vector obj)
            {
                
                obj.CollectorLookup.Clear();
                
                obj.CollectorLookup.Add(CollectorAccessor.CreateNewT(manager, null));
                
                obj.CollectorLookup.AddRange(CollectorAccessor.SelectLookupList(manager
                    
                    , new Func<Vector, long?>(c => c.idfCollectedByOffice)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfCollectedByPerson))
                    
                    .ToList());
                
                if (obj.idfCollectedByPerson != null && obj.idfCollectedByPerson != 0)
                {
                    obj.Collector = obj.CollectorLookup
                        .Where(c => c.idfPerson == obj.idfCollectedByPerson)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("PersonLookup", obj, CollectorAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Identifier(DbManagerProxy manager, Vector obj)
            {
                
                obj.IdentifierLookup.Clear();
                
                obj.IdentifierLookup.Add(IdentifierAccessor.CreateNewT(manager, null));
                
                obj.IdentifierLookup.AddRange(IdentifierAccessor.SelectLookupList(manager
                    
                    , new Func<Vector, long?>(c => c.idfIdentifiedByOffice ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfIdentifiedByPerson))
                    
                    .ToList());
                
                if (obj.idfIdentifiedByPerson != null && obj.idfIdentifiedByPerson != 0)
                {
                    obj.Identifier = obj.IdentifierLookup
                        .Where(c => c.idfPerson == obj.idfIdentifiedByPerson)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("PersonLookup", obj, IdentifierAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Country(DbManagerProxy manager, Vector obj)
            {
                
                obj.CountryLookup.Clear();
                
                obj.CountryLookup.Add(CountryAccessor.CreateNewT(manager, null));
                
                obj.CountryLookup.AddRange(CountryAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsCountry == obj.idfsCountry))
                    
                    .ToList());
                
                if (obj.idfsCountry != null && obj.idfsCountry != 0)
                {
                    obj.Country = obj.CountryLookup
                        .Where(c => c.idfsCountry == obj.idfsCountry)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("CountryLookup", obj, CountryAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Region(DbManagerProxy manager, Vector obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<Vector, long>(c => c.idfsCountry ?? 0)(obj)
                            
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
            
            public void LoadLookup_Rayon(DbManagerProxy manager, Vector obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<Vector, long>(c => c.idfsRegion ?? 0)(obj)
                            
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
            
            public void LoadLookup_Settlement(DbManagerProxy manager, Vector obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<Vector, long>(c => c.idfsRayon ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSettlement == obj.idfsSettlement))
                    
                    .ToList());
                
                if (obj.idfsSettlement != null && obj.idfsSettlement != 0)
                {
                    obj.Settlement = obj.SettlementLookup
                        .Where(c => c.idfsSettlement == obj.idfsSettlement)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("SettlementLookup", obj, SettlementAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_VectorTypes(DbManagerProxy manager, Vector obj)
            {
                
                obj.VectorTypesLookup.Clear();
                
                obj.VectorTypesLookup.Add(VectorTypesAccessor.CreateNewT(manager, null));
                
                obj.VectorTypesLookup.AddRange(VectorTypesAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorType))
                    
                    .ToList());
                
                if (obj.idfsVectorType != 0)
                {
                    obj.VectorTypes = obj.VectorTypesLookup
                        .Where(c => c.idfsBaseReference == obj.idfsVectorType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("VectorTypeLookup", obj, VectorTypesAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_EctoparasitesCollected(DbManagerProxy manager, Vector obj)
            {
                
                obj.EctoparasitesCollectedLookup.Clear();
                
                obj.EctoparasitesCollectedLookup.Add(EctoparasitesCollectedAccessor.CreateNewT(manager, null));
                
                obj.EctoparasitesCollectedLookup.AddRange(EctoparasitesCollectedAccessor.rftYesNoValue_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsEctoparasitesCollected))
                    
                    .ToList());
                
                if (obj.idfsEctoparasitesCollected != null && obj.idfsEctoparasitesCollected != 0)
                {
                    obj.EctoparasitesCollected = obj.EctoparasitesCollectedLookup
                        .Where(c => c.idfsBaseReference == obj.idfsEctoparasitesCollected)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftYesNoValue", obj, EctoparasitesCollectedAccessor.GetType(), "rftYesNoValue_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, Vector obj)
            {
                
                LoadLookup_CollectedByOffice(manager, obj);
                
                LoadLookup_IdentifiedByOffice(manager, obj);
                
                LoadLookup_VsSurrounding(manager, obj);
                
                LoadLookup_DayPeriod(manager, obj);
                
                LoadLookup_CollectionMethod(manager, obj);
                
                LoadLookup_BasisOfRecord(manager, obj);
                
                LoadLookup_VsVectorType(manager, obj);
                
                LoadLookup_VsVectorSubType(manager, obj);
                
                LoadLookup_AnimalGender(manager, obj);
                
                LoadLookup_IdentificationMethod(manager, obj);
                
                LoadLookup_Collector(manager, obj);
                
                LoadLookup_Identifier(manager, obj);
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
                LoadLookup_VectorTypes(manager, obj);
                
                LoadLookup_EctoparasitesCollected(manager, obj);
                
            }
    
            [SprocName("spVector_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            [SprocName("spVector_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] Vector obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] Vector obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    Vector bo = obj as Vector;
                    
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
                        
                        long mainObject = bo.idfVector;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                        }
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as Vector, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, Vector obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.FFPresenter != null)
                    {
                        obj.FFPresenter.MarkToDelete();
                        if (!FFPresenterAccessor.Post(manager, obj.FFPresenter, true))
                            return false;
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
                obj.strVectorID = new Func<Vector, DbManagerProxy, string>((c,m) => 
                        c.strVectorID != "(new)" 
                        ? c.strVectorID 
                        : m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.VsVector, DBNull.Value, DBNull.Value)
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
                        if (obj.FFPresenter != null) // forced load potential lazy subobject for new object
                            if (!FFPresenterAccessor.Post(manager, obj.FFPresenter, true))
                                return false;
                    }
                    else
                    {
                        if (obj._FFPresenter != null) // do not load lazy subobject for existing object
                            if (!FFPresenterAccessor.Post(manager, obj.FFPresenter, true))
                                return false;
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(Vector obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, Vector obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as Vector, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Vector obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "strVectorID", "strVectorID","",
                false
              )).Validate(c => true, obj, obj.strVectorID);
            
                (new RequiredValidator( "idfCollectedByOffice", "CollectedByOffice","VectorSample.idfFieldCollectedByOffice",
                false
              )).Validate(c => true, obj, obj.idfCollectedByOffice);
            
                (new RequiredValidator( "datCollectionDateTime", "datCollectionDateTime","",
                false
              )).Validate(c => true, obj, obj.datCollectionDateTime);
            
                (new RequiredValidator( "idfVectorSurveillanceSession", "idfVectorSurveillanceSession","",
                false
              )).Validate(c => true, obj, obj.idfVectorSurveillanceSession);
            
                (new RequiredValidator( "idfsVectorType", "strVectorType","",
                false
              )).Validate(c => true, obj, obj.idfsVectorType);
            
                (new RequiredValidator( "idfsVectorSubType", "VsVectorSubType","",
                false
              )).Validate(c => true, obj, obj.idfsVectorSubType);
            
                (new RequiredValidator( "intQuantity", "intQuantity","",
                false
              )).Validate(c => true, obj, obj.intQuantity);
            
                (new RequiredValidator( "Location.LocationDisplayName", "Location.LocationDisplayName","",
                false
              )).Validate(c => true, obj, obj.Location.LocationDisplayName);
            
                CheckSamples(manager, obj);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Location != null)
                            LocationAccessor.Validate(manager, obj.Location, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FFPresenter != null)
                            FFPresenterAccessor.Validate(manager, obj.FFPresenter, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
            
            private void _SetupRequired(Vector obj)
            {
            
                obj
                    .AddRequired("strVectorID", c => true);
                    
                obj
                    .AddRequired("CollectedByOffice", c => true);
                    
                obj
                    .AddRequired("datCollectionDateTime", c => true);
                    
                obj
                    .AddRequired("idfVectorSurveillanceSession", c => true);
                    
                obj
                    .AddRequired("strVectorType", c => true);
                    
                obj
                    .AddRequired("VsVectorSubType", c => true);
                    
                obj
                    .AddRequired("intQuantity", c => true);
                    
                obj
                    .Location
                        .AddRequired("LocationDisplayName", c => true);
                        
            }
    
    private void _SetupPersonalDataRestrictions(Vector obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Vector) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Vector) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VectorDetail"; } }
            public string HelpIdWin { get { return "vss_pool_form"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private Vector m_obj;
            internal Permissions(Vector obj)
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
            public static string spSelect = "spVector_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spVector_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spVector_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Vector, bool>> RequiredByField = new Dictionary<string, Func<Vector, bool>>();
            public static Dictionary<string, Func<Vector, bool>> RequiredByProperty = new Dictionary<string, Func<Vector, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strSessionID, 50);
                Sizes.Add(_str_strVectorType, 2000);
                Sizes.Add(_str_strVectorID, 50);
                Sizes.Add(_str_strFieldVectorID, 50);
                Sizes.Add(_str_strHostVector, 50);
                Sizes.Add(_str_strCountry, 300);
                Sizes.Add(_str_strRegion, 300);
                Sizes.Add(_str_strRayon, 300);
                Sizes.Add(_str_strSettlement, 300);
                Sizes.Add(_str_strSurrounding, 2000);
                Sizes.Add(_str_strGEOReferenceSources, 500);
                Sizes.Add(_str_strCollectedByOffice, 2000);
                Sizes.Add(_str_strCollectedByPerson, 602);
                Sizes.Add(_str_strCollectionMethod, 2000);
                Sizes.Add(_str_strBasisOfRecord, 2000);
                Sizes.Add(_str_strSex, 2000);
                Sizes.Add(_str_strIdentifiedByOffice, 2000);
                Sizes.Add(_str_strIdentifiedByPerson, 602);
                Sizes.Add(_str_strIdentificationMethod, 2000);
                Sizes.Add(_str_strDayPeriod, 2000);
                Sizes.Add(_str_strSpecies, 2000);
                Sizes.Add(_str_strComment, 500);
                Sizes.Add(_str_strEctoparasitesCollected, 2000);
                if (!RequiredByField.ContainsKey("strVectorID")) RequiredByField.Add("strVectorID", c => true);
                if (!RequiredByProperty.ContainsKey("strVectorID")) RequiredByProperty.Add("strVectorID", c => true);
                
                if (!RequiredByField.ContainsKey("idfCollectedByOffice")) RequiredByField.Add("idfCollectedByOffice", c => true);
                if (!RequiredByProperty.ContainsKey("CollectedByOffice")) RequiredByProperty.Add("CollectedByOffice", c => true);
                
                if (!RequiredByField.ContainsKey("datCollectionDateTime")) RequiredByField.Add("datCollectionDateTime", c => true);
                if (!RequiredByProperty.ContainsKey("datCollectionDateTime")) RequiredByProperty.Add("datCollectionDateTime", c => true);
                
                if (!RequiredByField.ContainsKey("idfVectorSurveillanceSession")) RequiredByField.Add("idfVectorSurveillanceSession", c => true);
                if (!RequiredByProperty.ContainsKey("idfVectorSurveillanceSession")) RequiredByProperty.Add("idfVectorSurveillanceSession", c => true);
                
                if (!RequiredByField.ContainsKey("idfsVectorType")) RequiredByField.Add("idfsVectorType", c => true);
                if (!RequiredByProperty.ContainsKey("strVectorType")) RequiredByProperty.Add("strVectorType", c => true);
                
                if (!RequiredByField.ContainsKey("idfsVectorSubType")) RequiredByField.Add("idfsVectorSubType", c => true);
                if (!RequiredByProperty.ContainsKey("VsVectorSubType")) RequiredByProperty.Add("VsVectorSubType", c => true);
                
                if (!RequiredByField.ContainsKey("intQuantity")) RequiredByField.Add("intQuantity", c => true);
                if (!RequiredByProperty.ContainsKey("intQuantity")) RequiredByProperty.Add("intQuantity", c => true);
                
                if (!RequiredByField.ContainsKey("Location.LocationDisplayName")) RequiredByField.Add("Location.LocationDisplayName", c => true);
                if (!RequiredByProperty.ContainsKey("Location.LocationDisplayName")) RequiredByProperty.Add("Location.LocationDisplayName", c => true);
                
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strVectorID",
                    EditorType.Text,
                    false, false, 
                    "Vector.strVectorID",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFieldVectorID",
                    EditorType.Text,
                    false, false, 
                    "Vector.strFieldVectorID",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRegion",
                    EditorType.Lookup,
                    false, false, 
                    "idfsRegion",
                    null, null, false, false, SearchPanelLocation.Main, false, "idfsRayon", "RegionLookup", typeof(RegionLookup), (o) => { var c = (RegionLookup)o; return c.idfsRegion; }, (o) => { var c = (RegionLookup)o; return c.strRegionName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRayon",
                    EditorType.Lookup,
                    false, false, 
                    "idfsRayon",
                    null, null, false, false, SearchPanelLocation.Main, false, "idfsSettlement", "RayonLookup", typeof(RayonLookup), (o) => { var c = (RayonLookup)o; return c.idfsRayon; }, (o) => { var c = (RayonLookup)o; return c.strRayonName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSettlement",
                    EditorType.Lookup,
                    false, false, 
                    "VsSession.idfsSettlement",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "SettlementLookup", typeof(SettlementLookup), (o) => { var c = (SettlementLookup)o; return c.idfsSettlement; }, (o) => { var c = (SettlementLookup)o; return c.strSettlementName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "dblLongitude",
                    EditorType.Numeric,
                    false, false, 
                    "dblLongitude",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "dblLatitude",
                    EditorType.Numeric,
                    false, false, 
                    "dblLatitude",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datCollectionDateTime",
                    EditorType.Date,
                    true, false, 
                    "datCollectionDateTime",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfCollectedByOffice",
                    EditorType.Lookup,
                    false, false, 
                    "VectorSample.idfFieldCollectedByOffice",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "CollectedByOfficeLookup", typeof(OrganizationLookup), (o) => { var c = (OrganizationLookup)o; return c.idfInstitution; }, (o) => { var c = (OrganizationLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfIdentifiedByOffice",
                    EditorType.Lookup,
                    false, false, 
                    "strIdentifiedByOffice",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "IdentifiedByOfficeLookup", typeof(OrganizationLookup), (o) => { var c = (OrganizationLookup)o; return c.idfInstitution; }, (o) => { var c = (OrganizationLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsVectorSubType",
                    EditorType.Lookup,
                    false, false, 
                    "strSpecies",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "VsVectorSubTypeLookup", typeof(VectorSubTypeLookup), (o) => { var c = (VectorSubTypeLookup)o; return c.idfsBaseReference; }, (o) => { var c = (VectorSubTypeLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "intQuantity",
                    EditorType.Numeric,
                    true, false, 
                    "intQuantity",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfVector,
                    _str_idfVector, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorID,
                    "Vector.strVectorID", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldVectorID,
                    "Vector.strFieldVectorID", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRegion,
                    _str_strRegion, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRayon,
                    _str_strRayon, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSettlement,
                    "Vector.strSettlement", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_dblLatitude,
                    "VsSessionListItem.dblLatitude", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_dblLongitude,
                    "VsSessionListItem.dblLongitude", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intElevation,
                    _str_intElevation, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSurrounding,
                    _str_strSurrounding, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datCollectionDateTime,
                    "datFieldCollectionDate", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDayPeriod,
                    _str_strDayPeriod, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCollectedByPerson,
                    "Vector.idfFieldCollectedByPerson", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCollectedByOffice,
                    "VectorSample.idfFieldCollectedByOffice", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpecies,
                    _str_strSpecies, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intQuantity,
                    _str_intQuantity, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSex,
                    "idfsAnimalGender", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strEctoparasitesCollected,
                    _str_strEctoparasitesCollected, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strHostVector,
                    "idfHostVector", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCollectionMethod,
                    _str_strCollectionMethod, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBasisOfRecord,
                    _str_strBasisOfRecord, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strGEOReferenceSources,
                    _str_strGEOReferenceSources, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strIdentifiedByPerson,
                    _str_strIdentifiedByPerson, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strIdentifiedByOffice,
                    _str_strIdentifiedByOffice, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datIdentifiedDateTime,
                    _str_datIdentifiedDateTime, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strIdentificationMethod,
                    _str_strIdentificationMethod, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorSpecificData,
                    _str_strVectorSpecificData, null, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "VectorOk",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).VectorOk(manager, (Vector)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
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
                    true
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
                    (a, p, b) => a != null ? !a.ReadOnly : true,
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
                    (manager, c, pars) => ((Vector)c).MarkToDelete(),
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
    public abstract partial class VectorItem : 
        EditableObject<VectorItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [LocalizedDisplayName(_str_idfVector)]
        [MapField(_str_idfVector)]
        public abstract Int64 idfVector { get; set; }
        #if MONO
        protected Int64 idfVector_Original { get { return idfVector; } }
        protected Int64 idfVector_Previous { get { return idfVector; } }
        #else
        protected Int64 idfVector_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfVector).OriginalValue; } }
        protected Int64 idfVector_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfVector).PreviousValue; } }
        #endif
                
        [MapField(_str_idfVectorSurveillanceSession), NonUpdatable, PrimaryKey]
        public abstract Int64 idfVectorSurveillanceSession { get; set; }
                
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
                
        [LocalizedDisplayName(_str_strVectorType)]
        [MapField(_str_strVectorType)]
        public abstract String strVectorType { get; set; }
        #if MONO
        protected String strVectorType_Original { get { return strVectorType; } }
        protected String strVectorType_Previous { get { return strVectorType; } }
        #else
        protected String strVectorType_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).OriginalValue; } }
        protected String strVectorType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strSpecies)]
        [MapField(_str_strSpecies)]
        public abstract String strSpecies { get; set; }
        #if MONO
        protected String strSpecies_Original { get { return strSpecies; } }
        protected String strSpecies_Previous { get { return strSpecies; } }
        #else
        protected String strSpecies_Original { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).OriginalValue; } }
        protected String strSpecies_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strFieldVectorID)]
        [MapField(_str_strFieldVectorID)]
        public abstract String strFieldVectorID { get; set; }
        #if MONO
        protected String strFieldVectorID_Original { get { return strFieldVectorID; } }
        protected String strFieldVectorID_Previous { get { return strFieldVectorID; } }
        #else
        protected String strFieldVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldVectorID).OriginalValue; } }
        protected String strFieldVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldVectorID).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<VectorItem, object> _get_func;
            internal Action<VectorItem, string> _set_func;
            internal Action<VectorItem, VectorItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfVector = "idfVector";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfsVectorType = "idfsVectorType";
        internal const string _str_strVectorType = "strVectorType";
        internal const string _str_idfsVectorSubType = "idfsVectorSubType";
        internal const string _str_strSpecies = "strSpecies";
        internal const string _str_strVectorID = "strVectorID";
        internal const string _str_strFieldVectorID = "strFieldVectorID";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfVector, _type = "Int64",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { o.idfVector = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, "Int64", o.idfVector == null ? "" : o.idfVector.ToString(), o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); }
              }, 
        
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _type = "Int64",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { o.idfVectorSurveillanceSession = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, "Int64", o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(), o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); }
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
              _name = _str_strVectorType, _type = "String",
              _get_func = o => o.strVectorType,
              _set_func = (o, val) => { o.strVectorType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strVectorType != c.strVectorType || o.IsRIRPropChanged(_str_strVectorType, c)) 
                  m.Add(_str_strVectorType, o.ObjectIdent + _str_strVectorType, "String", o.strVectorType == null ? "" : o.strVectorType.ToString(), o.IsReadOnly(_str_strVectorType), o.IsInvisible(_str_strVectorType), o.IsRequired(_str_strVectorType)); }
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
              _name = _str_strSpecies, _type = "String",
              _get_func = o => o.strSpecies,
              _set_func = (o, val) => { o.strSpecies = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSpecies != c.strSpecies || o.IsRIRPropChanged(_str_strSpecies, c)) 
                  m.Add(_str_strSpecies, o.ObjectIdent + _str_strSpecies, "String", o.strSpecies == null ? "" : o.strSpecies.ToString(), o.IsReadOnly(_str_strSpecies), o.IsInvisible(_str_strSpecies), o.IsRequired(_str_strSpecies)); }
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
              _name = _str_strFieldVectorID, _type = "String",
              _get_func = o => o.strFieldVectorID,
              _set_func = (o, val) => { o.strFieldVectorID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFieldVectorID != c.strFieldVectorID || o.IsRIRPropChanged(_str_strFieldVectorID, c)) 
                  m.Add(_str_strFieldVectorID, o.ObjectIdent + _str_strFieldVectorID, "String", o.strFieldVectorID == null ? "" : o.strFieldVectorID.ToString(), o.IsReadOnly(_str_strFieldVectorID), o.IsInvisible(_str_strFieldVectorID), o.IsRequired(_str_strFieldVectorID)); }
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
            VectorItem obj = (VectorItem)o;
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
        internal string m_ObjectName = "VectorItem";

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
            var ret = base.Clone() as VectorItem;
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
            var ret = base.Clone() as VectorItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public VectorItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VectorItem;
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

      private bool IsRIRPropChanged(string fld, VectorItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public VectorItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VectorItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VectorItem_PropertyChanged);
        }
        private void VectorItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VectorItem).Changed(e.PropertyName);
            
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
            VectorItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VectorItem obj = this;
            
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


        public Dictionary<string, Func<VectorItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VectorItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VectorItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<VectorItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<VectorItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<VectorItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VectorItem()
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
        : DataAccessor<VectorItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(VectorItem obj);
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
            
        
            public virtual List<VectorItem> SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                )
            {
                return _SelectList(manager
                    , idfVectorSurveillanceSession
                    , delegate(VectorItem obj)
                        {
                        }
                    , delegate(VectorItem obj)
                        {
                        }
                    );
            }

            
            private List<VectorItem> _SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VectorItem> objs = new List<VectorItem>();
                    sets[0] = new MapResultSet(typeof(VectorItem), objs);
                    
                    manager
                        .SetSpCommand("spVector_SelectDetail"
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VectorItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, VectorItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private VectorItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    VectorItem obj = VectorItem.CreateInstance();
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

            
            public VectorItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public VectorItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(VectorItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VectorItem obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, VectorItem obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as VectorItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VectorItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(VectorItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(VectorItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VectorItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VectorItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VectorItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spVector_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VectorItem, bool>> RequiredByField = new Dictionary<string, Func<VectorItem, bool>>();
            public static Dictionary<string, Func<VectorItem, bool>> RequiredByProperty = new Dictionary<string, Func<VectorItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strVectorType, 2000);
                Sizes.Add(_str_strSpecies, 2000);
                Sizes.Add(_str_strVectorID, 50);
                Sizes.Add(_str_strFieldVectorID, 50);
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
                    (manager, c, pars) => ((VectorItem)c).MarkToDelete(),
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
	