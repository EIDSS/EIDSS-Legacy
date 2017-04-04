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
        protected Int64 idfVectorSurveillanceSession_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfVectorSurveillanceSession).OriginalValue; } }
        protected Int64 idfVectorSurveillanceSession_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfVectorSurveillanceSession).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSessionID)]
        [MapField(_str_strSessionID)]
        public abstract String strSessionID { get; set; }
        protected String strSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strSessionID).OriginalValue; } }
        protected String strSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSessionID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsVectorType)]
        [MapField(_str_idfsVectorType)]
        public abstract Int64 idfsVectorType { get; set; }
        protected Int64 idfsVectorType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).OriginalValue; } }
        protected Int64 idfsVectorType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).PreviousValue; } }
                
        [LocalizedDisplayName("idfsVectorType")]
        [MapField(_str_strVectorType)]
        public abstract String strVectorType { get; set; }
        protected String strVectorType_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).OriginalValue; } }
        protected String strVectorType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsVectorSubType)]
        [MapField(_str_idfsVectorSubType)]
        public abstract Int64 idfsVectorSubType { get; set; }
        protected Int64 idfsVectorSubType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSubType).OriginalValue; } }
        protected Int64 idfsVectorSubType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSubType).PreviousValue; } }
                
        [LocalizedDisplayName("Vector.strVectorID")]
        [MapField(_str_strVectorID)]
        public abstract String strVectorID { get; set; }
        protected String strVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).OriginalValue; } }
        protected String strVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).PreviousValue; } }
                
        [LocalizedDisplayName("Vector.strFieldVectorID")]
        [MapField(_str_strFieldVectorID)]
        public abstract String strFieldVectorID { get; set; }
        protected String strFieldVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldVectorID).OriginalValue; } }
        protected String strFieldVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldVectorID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfHostVector)]
        [MapField(_str_idfHostVector)]
        public abstract Int64? idfHostVector { get; set; }
        protected Int64? idfHostVector_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHostVector).OriginalValue; } }
        protected Int64? idfHostVector_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfHostVector).PreviousValue; } }
                
        [LocalizedDisplayName("idfHostVector")]
        [MapField(_str_strHostVector)]
        public abstract String strHostVector { get; set; }
        protected String strHostVector_Original { get { return ((EditableValue<String>)((dynamic)this)._strHostVector).OriginalValue; } }
        protected String strHostVector_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHostVector).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfLocation)]
        [MapField(_str_idfLocation)]
        public abstract Int64? idfLocation { get; set; }
        protected Int64? idfLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).OriginalValue; } }
        protected Int64? idfLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfLocation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCountry)]
        [MapField(_str_strCountry)]
        public abstract String strCountry { get; set; }
        protected String strCountry_Original { get { return ((EditableValue<String>)((dynamic)this)._strCountry).OriginalValue; } }
        protected String strCountry_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCountry).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRegion)]
        [MapField(_str_strRegion)]
        public abstract String strRegion { get; set; }
        protected String strRegion_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegion).OriginalValue; } }
        protected String strRegion_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRayon)]
        [MapField(_str_strRayon)]
        public abstract String strRayon { get; set; }
        protected String strRayon_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayon).OriginalValue; } }
        protected String strRayon_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayon).PreviousValue; } }
                
        [LocalizedDisplayName("Vector.strSettlement")]
        [MapField(_str_strSettlement)]
        public abstract String strSettlement { get; set; }
        protected String strSettlement_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).OriginalValue; } }
        protected String strSettlement_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intElevation)]
        [MapField(_str_intElevation)]
        public abstract Int32? intElevation { get; set; }
        protected Int32? intElevation_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intElevation).OriginalValue; } }
        protected Int32? intElevation_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intElevation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSurrounding)]
        [MapField(_str_idfsSurrounding)]
        public abstract Int64? idfsSurrounding { get; set; }
        protected Int64? idfsSurrounding_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSurrounding).OriginalValue; } }
        protected Int64? idfsSurrounding_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSurrounding).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSurrounding)]
        [MapField(_str_strSurrounding)]
        public abstract String strSurrounding { get; set; }
        protected String strSurrounding_Original { get { return ((EditableValue<String>)((dynamic)this)._strSurrounding).OriginalValue; } }
        protected String strSurrounding_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSurrounding).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strGEOReferenceSources)]
        [MapField(_str_strGEOReferenceSources)]
        public abstract String strGEOReferenceSources { get; set; }
        protected String strGEOReferenceSources_Original { get { return ((EditableValue<String>)((dynamic)this)._strGEOReferenceSources).OriginalValue; } }
        protected String strGEOReferenceSources_Previous { get { return ((EditableValue<String>)((dynamic)this)._strGEOReferenceSources).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCollectedByOffice)]
        [MapField(_str_idfCollectedByOffice)]
        public abstract Int64 idfCollectedByOffice { get; set; }
        protected Int64 idfCollectedByOffice_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfCollectedByOffice).OriginalValue; } }
        protected Int64 idfCollectedByOffice_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfCollectedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName("VectorSample.idfFieldCollectedByOffice")]
        [MapField(_str_strCollectedByOffice)]
        public abstract String strCollectedByOffice { get; set; }
        protected String strCollectedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByOffice).OriginalValue; } }
        protected String strCollectedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCollectedByPerson)]
        [MapField(_str_idfCollectedByPerson)]
        public abstract Int64? idfCollectedByPerson { get; set; }
        protected Int64? idfCollectedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCollectedByPerson).OriginalValue; } }
        protected Int64? idfCollectedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCollectedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName("Vector.idfFieldCollectedByPerson")]
        [MapField(_str_strCollectedByPerson)]
        public abstract String strCollectedByPerson { get; set; }
        protected String strCollectedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByPerson).OriginalValue; } }
        protected String strCollectedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCollectedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datCollectionDateTime)]
        [MapField(_str_datCollectionDateTime)]
        public abstract DateTime datCollectionDateTime { get; set; }
        protected DateTime datCollectionDateTime_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datCollectionDateTime).OriginalValue; } }
        protected DateTime datCollectionDateTime_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datCollectionDateTime).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCollectionMethod)]
        [MapField(_str_idfsCollectionMethod)]
        public abstract Int64? idfsCollectionMethod { get; set; }
        protected Int64? idfsCollectionMethod_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCollectionMethod).OriginalValue; } }
        protected Int64? idfsCollectionMethod_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCollectionMethod).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCollectionMethod)]
        [MapField(_str_strCollectionMethod)]
        public abstract String strCollectionMethod { get; set; }
        protected String strCollectionMethod_Original { get { return ((EditableValue<String>)((dynamic)this)._strCollectionMethod).OriginalValue; } }
        protected String strCollectionMethod_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCollectionMethod).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsBasisOfRecord)]
        [MapField(_str_idfsBasisOfRecord)]
        public abstract Int64? idfsBasisOfRecord { get; set; }
        protected Int64? idfsBasisOfRecord_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBasisOfRecord).OriginalValue; } }
        protected Int64? idfsBasisOfRecord_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBasisOfRecord).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strBasisOfRecord)]
        [MapField(_str_strBasisOfRecord)]
        public abstract String strBasisOfRecord { get; set; }
        protected String strBasisOfRecord_Original { get { return ((EditableValue<String>)((dynamic)this)._strBasisOfRecord).OriginalValue; } }
        protected String strBasisOfRecord_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBasisOfRecord).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intQuantity)]
        [MapField(_str_intQuantity)]
        public abstract Int32 intQuantity { get; set; }
        protected Int32 intQuantity_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intQuantity).OriginalValue; } }
        protected Int32 intQuantity_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intQuantity).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSex)]
        [MapField(_str_idfsSex)]
        public abstract Int64? idfsSex { get; set; }
        protected Int64? idfsSex_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSex).OriginalValue; } }
        protected Int64? idfsSex_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSex).PreviousValue; } }
                
        [LocalizedDisplayName("idfsAnimalGender")]
        [MapField(_str_strSex)]
        public abstract String strSex { get; set; }
        protected String strSex_Original { get { return ((EditableValue<String>)((dynamic)this)._strSex).OriginalValue; } }
        protected String strSex_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSex).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfIdentifiedByOffice)]
        [MapField(_str_idfIdentifiedByOffice)]
        public abstract Int64? idfIdentifiedByOffice { get; set; }
        protected Int64? idfIdentifiedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfIdentifiedByOffice).OriginalValue; } }
        protected Int64? idfIdentifiedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfIdentifiedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strIdentifiedByOffice)]
        [MapField(_str_strIdentifiedByOffice)]
        public abstract String strIdentifiedByOffice { get; set; }
        protected String strIdentifiedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strIdentifiedByOffice).OriginalValue; } }
        protected String strIdentifiedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strIdentifiedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfIdentifiedByPerson)]
        [MapField(_str_idfIdentifiedByPerson)]
        public abstract Int64? idfIdentifiedByPerson { get; set; }
        protected Int64? idfIdentifiedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfIdentifiedByPerson).OriginalValue; } }
        protected Int64? idfIdentifiedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfIdentifiedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strIdentifiedByPerson)]
        [MapField(_str_strIdentifiedByPerson)]
        public abstract String strIdentifiedByPerson { get; set; }
        protected String strIdentifiedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strIdentifiedByPerson).OriginalValue; } }
        protected String strIdentifiedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strIdentifiedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datIdentifiedDateTime)]
        [MapField(_str_datIdentifiedDateTime)]
        public abstract DateTime? datIdentifiedDateTime { get; set; }
        protected DateTime? datIdentifiedDateTime_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datIdentifiedDateTime).OriginalValue; } }
        protected DateTime? datIdentifiedDateTime_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datIdentifiedDateTime).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsIdentificationMethod)]
        [MapField(_str_idfsIdentificationMethod)]
        public abstract Int64? idfsIdentificationMethod { get; set; }
        protected Int64? idfsIdentificationMethod_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsIdentificationMethod).OriginalValue; } }
        protected Int64? idfsIdentificationMethod_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsIdentificationMethod).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strIdentificationMethod)]
        [MapField(_str_strIdentificationMethod)]
        public abstract String strIdentificationMethod { get; set; }
        protected String strIdentificationMethod_Original { get { return ((EditableValue<String>)((dynamic)this)._strIdentificationMethod).OriginalValue; } }
        protected String strIdentificationMethod_Previous { get { return ((EditableValue<String>)((dynamic)this)._strIdentificationMethod).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfObservation)]
        [MapField(_str_idfObservation)]
        public abstract Int64? idfObservation { get; set; }
        protected Int64? idfObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObservation).OriginalValue; } }
        protected Int64? idfObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfObservation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64? idfsFormTemplate { get; set; }
        protected Int64? idfsFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64? idfsFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName("VsSessionListItem.dblLatitude")]
        [MapField(_str_dblLatitude)]
        public abstract Double? dblLatitude { get; set; }
        protected Double? dblLatitude_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblLatitude).OriginalValue; } }
        protected Double? dblLatitude_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblLatitude).PreviousValue; } }
                
        [LocalizedDisplayName("VsSessionListItem.dblLongitude")]
        [MapField(_str_dblLongitude)]
        public abstract Double? dblLongitude { get; set; }
        protected Double? dblLongitude_Original { get { return ((EditableValue<Double?>)((dynamic)this)._dblLongitude).OriginalValue; } }
        protected Double? dblLongitude_Previous { get { return ((EditableValue<Double?>)((dynamic)this)._dblLongitude).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsDayPeriod)]
        [MapField(_str_idfsDayPeriod)]
        public abstract Int64? idfsDayPeriod { get; set; }
        protected Int64? idfsDayPeriod_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDayPeriod).OriginalValue; } }
        protected Int64? idfsDayPeriod_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDayPeriod).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDayPeriod)]
        [MapField(_str_strDayPeriod)]
        public abstract String strDayPeriod { get; set; }
        protected String strDayPeriod_Original { get { return ((EditableValue<String>)((dynamic)this)._strDayPeriod).OriginalValue; } }
        protected String strDayPeriod_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDayPeriod).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSpecies)]
        [MapField(_str_strSpecies)]
        public abstract String strSpecies { get; set; }
        protected String strSpecies_Original { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).OriginalValue; } }
        protected String strSpecies_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).PreviousValue; } }
                
        [LocalizedDisplayName("Vector.strComment")]
        [MapField(_str_strComment)]
        public abstract String strComment { get; set; }
        protected String strComment_Original { get { return ((EditableValue<String>)((dynamic)this)._strComment).OriginalValue; } }
        protected String strComment_Previous { get { return ((EditableValue<String>)((dynamic)this)._strComment).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsEctoparasitesCollected)]
        [MapField(_str_idfsEctoparasitesCollected)]
        public abstract Int64? idfsEctoparasitesCollected { get; set; }
        protected Int64? idfsEctoparasitesCollected_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEctoparasitesCollected).OriginalValue; } }
        protected Int64? idfsEctoparasitesCollected_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsEctoparasitesCollected).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strEctoparasitesCollected)]
        [MapField(_str_strEctoparasitesCollected)]
        public abstract String strEctoparasitesCollected { get; set; }
        protected String strEctoparasitesCollected_Original { get { return ((EditableValue<String>)((dynamic)this)._strEctoparasitesCollected).OriginalValue; } }
        protected String strEctoparasitesCollected_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEctoparasitesCollected).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<Vector, object> _get_func;
            internal Action<Vector, string> _set_func;
            internal Action<Vector, Vector, CompareModel, DbManagerProxy> _compare_func;
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
        internal const string _str_strCountry = "strCountry";
        internal const string _str_strRegion = "strRegion";
        internal const string _str_strRayon = "strRayon";
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
        internal const string _str_Session = "Session";
        internal const string _str_datStartDateFromSession = "datStartDateFromSession";
        internal const string _str_Vectors = "Vectors";
        internal const string _str_IsPoolVectorType = "IsPoolVectorType";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_strVectorSpecificData = "strVectorSpecificData";
        internal const string _str_openMode = "openMode";
        internal const string _str_intOriginalOrder = "intOriginalOrder";
        internal const string _str_intPostOrder = "intPostOrder";
        internal const string _str_blnIgnoreValidation = "blnIgnoreValidation";
        internal const string _str_SamplesAll = "SamplesAll";
        internal const string _str_VectorsWithoutThisVectorSelectList = "VectorsWithoutThisVectorSelectList";
        internal const string _str_HostVector = "HostVector";
        internal const string _str_CollectedByOffice = "CollectedByOffice";
        internal const string _str_IdentifiedByOffice = "IdentifiedByOffice";
        internal const string _str_Surrounding = "Surrounding";
        internal const string _str_DayPeriod = "DayPeriod";
        internal const string _str_CollectionMethod = "CollectionMethod";
        internal const string _str_BasisOfRecord = "BasisOfRecord";
        internal const string _str_VectorType = "VectorType";
        internal const string _str_VectorSubType = "VectorSubType";
        internal const string _str_AnimalGender = "AnimalGender";
        internal const string _str_IdentificationMethod = "IdentificationMethod";
        internal const string _str_Collector = "Collector";
        internal const string _str_Identifier = "Identifier";
        internal const string _str_EctoparasitesCollected = "EctoparasitesCollected";
        internal const string _str_Location = "Location";
        internal const string _str_FFPresenter = "FFPresenter";
        internal const string _str_Samples = "Samples";
        internal const string _str_FieldTests = "FieldTests";
        internal const string _str_LabTests = "LabTests";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfVector, _formname = _str_idfVector, _type = "Int64",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVector != newval) o.idfVector = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, o.ObjectIdent2 + _str_idfVector, o.ObjectIdent3 + _str_idfVector, "Int64", 
                    o.idfVector == null ? "" : o.idfVector.ToString(),                  
                  o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _formname = _str_idfVectorSurveillanceSession, _type = "Int64",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVectorSurveillanceSession != newval) o.idfVectorSurveillanceSession = newval; },
              _compare_func = (o, c, m, g) => {
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
              _compare_func = (o, c, m, g) => {
                if (o.strSessionID != c.strSessionID || o.IsRIRPropChanged(_str_strSessionID, c)) 
                  m.Add(_str_strSessionID, o.ObjectIdent + _str_strSessionID, o.ObjectIdent2 + _str_strSessionID, o.ObjectIdent3 + _str_strSessionID, "String", 
                    o.strSessionID == null ? "" : o.strSessionID.ToString(),                  
                  o.IsReadOnly(_str_strSessionID), o.IsInvisible(_str_strSessionID), o.IsRequired(_str_strSessionID)); 
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
              _name = _str_strVectorType, _formname = _str_strVectorType, _type = "String",
              _get_func = o => o.strVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectorType != newval) o.strVectorType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strVectorType != c.strVectorType || o.IsRIRPropChanged(_str_strVectorType, c)) 
                  m.Add(_str_strVectorType, o.ObjectIdent + _str_strVectorType, o.ObjectIdent2 + _str_strVectorType, o.ObjectIdent3 + _str_strVectorType, "String", 
                    o.strVectorType == null ? "" : o.strVectorType.ToString(),                  
                  o.IsReadOnly(_str_strVectorType), o.IsInvisible(_str_strVectorType), o.IsRequired(_str_strVectorType)); 
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
              _name = _str_strFieldVectorID, _formname = _str_strFieldVectorID, _type = "String",
              _get_func = o => o.strFieldVectorID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldVectorID != newval) o.strFieldVectorID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFieldVectorID != c.strFieldVectorID || o.IsRIRPropChanged(_str_strFieldVectorID, c)) 
                  m.Add(_str_strFieldVectorID, o.ObjectIdent + _str_strFieldVectorID, o.ObjectIdent2 + _str_strFieldVectorID, o.ObjectIdent3 + _str_strFieldVectorID, "String", 
                    o.strFieldVectorID == null ? "" : o.strFieldVectorID.ToString(),                  
                  o.IsReadOnly(_str_strFieldVectorID), o.IsInvisible(_str_strFieldVectorID), o.IsRequired(_str_strFieldVectorID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfHostVector, _formname = _str_idfHostVector, _type = "Int64?",
              _get_func = o => o.idfHostVector,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfHostVector != newval) 
                  o.HostVector = o.HostVectorLookup.FirstOrDefault(c => c.idfVector == newval);
                if (o.idfHostVector != newval) o.idfHostVector = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfHostVector != c.idfHostVector || o.IsRIRPropChanged(_str_idfHostVector, c)) 
                  m.Add(_str_idfHostVector, o.ObjectIdent + _str_idfHostVector, o.ObjectIdent2 + _str_idfHostVector, o.ObjectIdent3 + _str_idfHostVector, "Int64?", 
                    o.idfHostVector == null ? "" : o.idfHostVector.ToString(),                  
                  o.IsReadOnly(_str_idfHostVector), o.IsInvisible(_str_idfHostVector), o.IsRequired(_str_idfHostVector)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHostVector, _formname = _str_strHostVector, _type = "String",
              _get_func = o => o.strHostVector,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHostVector != newval) o.strHostVector = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHostVector != c.strHostVector || o.IsRIRPropChanged(_str_strHostVector, c)) 
                  m.Add(_str_strHostVector, o.ObjectIdent + _str_strHostVector, o.ObjectIdent2 + _str_strHostVector, o.ObjectIdent3 + _str_strHostVector, "String", 
                    o.strHostVector == null ? "" : o.strHostVector.ToString(),                  
                  o.IsReadOnly(_str_strHostVector), o.IsInvisible(_str_strHostVector), o.IsRequired(_str_strHostVector)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfLocation, _formname = _str_idfLocation, _type = "Int64?",
              _get_func = o => o.idfLocation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfLocation != newval) o.idfLocation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfLocation != c.idfLocation || o.IsRIRPropChanged(_str_idfLocation, c)) 
                  m.Add(_str_idfLocation, o.ObjectIdent + _str_idfLocation, o.ObjectIdent2 + _str_idfLocation, o.ObjectIdent3 + _str_idfLocation, "Int64?", 
                    o.idfLocation == null ? "" : o.idfLocation.ToString(),                  
                  o.IsReadOnly(_str_idfLocation), o.IsInvisible(_str_idfLocation), o.IsRequired(_str_idfLocation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCountry, _formname = _str_strCountry, _type = "String",
              _get_func = o => o.strCountry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCountry != newval) o.strCountry = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCountry != c.strCountry || o.IsRIRPropChanged(_str_strCountry, c)) 
                  m.Add(_str_strCountry, o.ObjectIdent + _str_strCountry, o.ObjectIdent2 + _str_strCountry, o.ObjectIdent3 + _str_strCountry, "String", 
                    o.strCountry == null ? "" : o.strCountry.ToString(),                  
                  o.IsReadOnly(_str_strCountry), o.IsInvisible(_str_strCountry), o.IsRequired(_str_strCountry)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRegion, _formname = _str_strRegion, _type = "String",
              _get_func = o => o.strRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRegion != newval) o.strRegion = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strRegion != c.strRegion || o.IsRIRPropChanged(_str_strRegion, c)) 
                  m.Add(_str_strRegion, o.ObjectIdent + _str_strRegion, o.ObjectIdent2 + _str_strRegion, o.ObjectIdent3 + _str_strRegion, "String", 
                    o.strRegion == null ? "" : o.strRegion.ToString(),                  
                  o.IsReadOnly(_str_strRegion), o.IsInvisible(_str_strRegion), o.IsRequired(_str_strRegion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRayon, _formname = _str_strRayon, _type = "String",
              _get_func = o => o.strRayon,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRayon != newval) o.strRayon = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strRayon != c.strRayon || o.IsRIRPropChanged(_str_strRayon, c)) 
                  m.Add(_str_strRayon, o.ObjectIdent + _str_strRayon, o.ObjectIdent2 + _str_strRayon, o.ObjectIdent3 + _str_strRayon, "String", 
                    o.strRayon == null ? "" : o.strRayon.ToString(),                  
                  o.IsReadOnly(_str_strRayon), o.IsInvisible(_str_strRayon), o.IsRequired(_str_strRayon)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSettlement, _formname = _str_strSettlement, _type = "String",
              _get_func = o => o.strSettlement,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSettlement != newval) o.strSettlement = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSettlement != c.strSettlement || o.IsRIRPropChanged(_str_strSettlement, c)) 
                  m.Add(_str_strSettlement, o.ObjectIdent + _str_strSettlement, o.ObjectIdent2 + _str_strSettlement, o.ObjectIdent3 + _str_strSettlement, "String", 
                    o.strSettlement == null ? "" : o.strSettlement.ToString(),                  
                  o.IsReadOnly(_str_strSettlement), o.IsInvisible(_str_strSettlement), o.IsRequired(_str_strSettlement)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intElevation, _formname = _str_intElevation, _type = "Int32?",
              _get_func = o => o.intElevation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intElevation != newval) o.intElevation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intElevation != c.intElevation || o.IsRIRPropChanged(_str_intElevation, c)) 
                  m.Add(_str_intElevation, o.ObjectIdent + _str_intElevation, o.ObjectIdent2 + _str_intElevation, o.ObjectIdent3 + _str_intElevation, "Int32?", 
                    o.intElevation == null ? "" : o.intElevation.ToString(),                  
                  o.IsReadOnly(_str_intElevation), o.IsInvisible(_str_intElevation), o.IsRequired(_str_intElevation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSurrounding, _formname = _str_idfsSurrounding, _type = "Int64?",
              _get_func = o => o.idfsSurrounding,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsSurrounding != newval) 
                  o.Surrounding = o.SurroundingLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsSurrounding != newval) o.idfsSurrounding = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSurrounding != c.idfsSurrounding || o.IsRIRPropChanged(_str_idfsSurrounding, c)) 
                  m.Add(_str_idfsSurrounding, o.ObjectIdent + _str_idfsSurrounding, o.ObjectIdent2 + _str_idfsSurrounding, o.ObjectIdent3 + _str_idfsSurrounding, "Int64?", 
                    o.idfsSurrounding == null ? "" : o.idfsSurrounding.ToString(),                  
                  o.IsReadOnly(_str_idfsSurrounding), o.IsInvisible(_str_idfsSurrounding), o.IsRequired(_str_idfsSurrounding)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSurrounding, _formname = _str_strSurrounding, _type = "String",
              _get_func = o => o.strSurrounding,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSurrounding != newval) o.strSurrounding = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSurrounding != c.strSurrounding || o.IsRIRPropChanged(_str_strSurrounding, c)) 
                  m.Add(_str_strSurrounding, o.ObjectIdent + _str_strSurrounding, o.ObjectIdent2 + _str_strSurrounding, o.ObjectIdent3 + _str_strSurrounding, "String", 
                    o.strSurrounding == null ? "" : o.strSurrounding.ToString(),                  
                  o.IsReadOnly(_str_strSurrounding), o.IsInvisible(_str_strSurrounding), o.IsRequired(_str_strSurrounding)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strGEOReferenceSources, _formname = _str_strGEOReferenceSources, _type = "String",
              _get_func = o => o.strGEOReferenceSources,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strGEOReferenceSources != newval) o.strGEOReferenceSources = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strGEOReferenceSources != c.strGEOReferenceSources || o.IsRIRPropChanged(_str_strGEOReferenceSources, c)) 
                  m.Add(_str_strGEOReferenceSources, o.ObjectIdent + _str_strGEOReferenceSources, o.ObjectIdent2 + _str_strGEOReferenceSources, o.ObjectIdent3 + _str_strGEOReferenceSources, "String", 
                    o.strGEOReferenceSources == null ? "" : o.strGEOReferenceSources.ToString(),                  
                  o.IsReadOnly(_str_strGEOReferenceSources), o.IsInvisible(_str_strGEOReferenceSources), o.IsRequired(_str_strGEOReferenceSources)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfCollectedByOffice, _formname = _str_idfCollectedByOffice, _type = "Int64",
              _get_func = o => o.idfCollectedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfCollectedByOffice != newval) 
                  o.CollectedByOffice = o.CollectedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfCollectedByOffice != newval) o.idfCollectedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfCollectedByOffice != c.idfCollectedByOffice || o.IsRIRPropChanged(_str_idfCollectedByOffice, c)) 
                  m.Add(_str_idfCollectedByOffice, o.ObjectIdent + _str_idfCollectedByOffice, o.ObjectIdent2 + _str_idfCollectedByOffice, o.ObjectIdent3 + _str_idfCollectedByOffice, "Int64", 
                    o.idfCollectedByOffice == null ? "" : o.idfCollectedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfCollectedByOffice), o.IsInvisible(_str_idfCollectedByOffice), o.IsRequired(_str_idfCollectedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCollectedByOffice, _formname = _str_strCollectedByOffice, _type = "String",
              _get_func = o => o.strCollectedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCollectedByOffice != newval) o.strCollectedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCollectedByOffice != c.strCollectedByOffice || o.IsRIRPropChanged(_str_strCollectedByOffice, c)) 
                  m.Add(_str_strCollectedByOffice, o.ObjectIdent + _str_strCollectedByOffice, o.ObjectIdent2 + _str_strCollectedByOffice, o.ObjectIdent3 + _str_strCollectedByOffice, "String", 
                    o.strCollectedByOffice == null ? "" : o.strCollectedByOffice.ToString(),                  
                  o.IsReadOnly(_str_strCollectedByOffice), o.IsInvisible(_str_strCollectedByOffice), o.IsRequired(_str_strCollectedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfCollectedByPerson, _formname = _str_idfCollectedByPerson, _type = "Int64?",
              _get_func = o => o.idfCollectedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfCollectedByPerson != newval) 
                  o.Collector = o.CollectorLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfCollectedByPerson != newval) o.idfCollectedByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfCollectedByPerson != c.idfCollectedByPerson || o.IsRIRPropChanged(_str_idfCollectedByPerson, c)) 
                  m.Add(_str_idfCollectedByPerson, o.ObjectIdent + _str_idfCollectedByPerson, o.ObjectIdent2 + _str_idfCollectedByPerson, o.ObjectIdent3 + _str_idfCollectedByPerson, "Int64?", 
                    o.idfCollectedByPerson == null ? "" : o.idfCollectedByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfCollectedByPerson), o.IsInvisible(_str_idfCollectedByPerson), o.IsRequired(_str_idfCollectedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCollectedByPerson, _formname = _str_strCollectedByPerson, _type = "String",
              _get_func = o => o.strCollectedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCollectedByPerson != newval) o.strCollectedByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCollectedByPerson != c.strCollectedByPerson || o.IsRIRPropChanged(_str_strCollectedByPerson, c)) 
                  m.Add(_str_strCollectedByPerson, o.ObjectIdent + _str_strCollectedByPerson, o.ObjectIdent2 + _str_strCollectedByPerson, o.ObjectIdent3 + _str_strCollectedByPerson, "String", 
                    o.strCollectedByPerson == null ? "" : o.strCollectedByPerson.ToString(),                  
                  o.IsReadOnly(_str_strCollectedByPerson), o.IsInvisible(_str_strCollectedByPerson), o.IsRequired(_str_strCollectedByPerson)); 
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
              _name = _str_idfsCollectionMethod, _formname = _str_idfsCollectionMethod, _type = "Int64?",
              _get_func = o => o.idfsCollectionMethod,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsCollectionMethod != newval) 
                  o.CollectionMethod = o.CollectionMethodLookup.FirstOrDefault(c => c.idfsCollectionMethod == newval);
                if (o.idfsCollectionMethod != newval) o.idfsCollectionMethod = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCollectionMethod != c.idfsCollectionMethod || o.IsRIRPropChanged(_str_idfsCollectionMethod, c)) 
                  m.Add(_str_idfsCollectionMethod, o.ObjectIdent + _str_idfsCollectionMethod, o.ObjectIdent2 + _str_idfsCollectionMethod, o.ObjectIdent3 + _str_idfsCollectionMethod, "Int64?", 
                    o.idfsCollectionMethod == null ? "" : o.idfsCollectionMethod.ToString(),                  
                  o.IsReadOnly(_str_idfsCollectionMethod), o.IsInvisible(_str_idfsCollectionMethod), o.IsRequired(_str_idfsCollectionMethod)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCollectionMethod, _formname = _str_strCollectionMethod, _type = "String",
              _get_func = o => o.strCollectionMethod,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCollectionMethod != newval) o.strCollectionMethod = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCollectionMethod != c.strCollectionMethod || o.IsRIRPropChanged(_str_strCollectionMethod, c)) 
                  m.Add(_str_strCollectionMethod, o.ObjectIdent + _str_strCollectionMethod, o.ObjectIdent2 + _str_strCollectionMethod, o.ObjectIdent3 + _str_strCollectionMethod, "String", 
                    o.strCollectionMethod == null ? "" : o.strCollectionMethod.ToString(),                  
                  o.IsReadOnly(_str_strCollectionMethod), o.IsInvisible(_str_strCollectionMethod), o.IsRequired(_str_strCollectionMethod)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsBasisOfRecord, _formname = _str_idfsBasisOfRecord, _type = "Int64?",
              _get_func = o => o.idfsBasisOfRecord,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsBasisOfRecord != newval) 
                  o.BasisOfRecord = o.BasisOfRecordLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsBasisOfRecord != newval) o.idfsBasisOfRecord = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsBasisOfRecord != c.idfsBasisOfRecord || o.IsRIRPropChanged(_str_idfsBasisOfRecord, c)) 
                  m.Add(_str_idfsBasisOfRecord, o.ObjectIdent + _str_idfsBasisOfRecord, o.ObjectIdent2 + _str_idfsBasisOfRecord, o.ObjectIdent3 + _str_idfsBasisOfRecord, "Int64?", 
                    o.idfsBasisOfRecord == null ? "" : o.idfsBasisOfRecord.ToString(),                  
                  o.IsReadOnly(_str_idfsBasisOfRecord), o.IsInvisible(_str_idfsBasisOfRecord), o.IsRequired(_str_idfsBasisOfRecord)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strBasisOfRecord, _formname = _str_strBasisOfRecord, _type = "String",
              _get_func = o => o.strBasisOfRecord,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strBasisOfRecord != newval) o.strBasisOfRecord = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strBasisOfRecord != c.strBasisOfRecord || o.IsRIRPropChanged(_str_strBasisOfRecord, c)) 
                  m.Add(_str_strBasisOfRecord, o.ObjectIdent + _str_strBasisOfRecord, o.ObjectIdent2 + _str_strBasisOfRecord, o.ObjectIdent3 + _str_strBasisOfRecord, "String", 
                    o.strBasisOfRecord == null ? "" : o.strBasisOfRecord.ToString(),                  
                  o.IsReadOnly(_str_strBasisOfRecord), o.IsInvisible(_str_strBasisOfRecord), o.IsRequired(_str_strBasisOfRecord)); 
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
              _name = _str_idfsSex, _formname = _str_idfsSex, _type = "Int64?",
              _get_func = o => o.idfsSex,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsSex != newval) 
                  o.AnimalGender = o.AnimalGenderLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsSex != newval) o.idfsSex = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSex != c.idfsSex || o.IsRIRPropChanged(_str_idfsSex, c)) 
                  m.Add(_str_idfsSex, o.ObjectIdent + _str_idfsSex, o.ObjectIdent2 + _str_idfsSex, o.ObjectIdent3 + _str_idfsSex, "Int64?", 
                    o.idfsSex == null ? "" : o.idfsSex.ToString(),                  
                  o.IsReadOnly(_str_idfsSex), o.IsInvisible(_str_idfsSex), o.IsRequired(_str_idfsSex)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSex, _formname = _str_strSex, _type = "String",
              _get_func = o => o.strSex,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSex != newval) o.strSex = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSex != c.strSex || o.IsRIRPropChanged(_str_strSex, c)) 
                  m.Add(_str_strSex, o.ObjectIdent + _str_strSex, o.ObjectIdent2 + _str_strSex, o.ObjectIdent3 + _str_strSex, "String", 
                    o.strSex == null ? "" : o.strSex.ToString(),                  
                  o.IsReadOnly(_str_strSex), o.IsInvisible(_str_strSex), o.IsRequired(_str_strSex)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfIdentifiedByOffice, _formname = _str_idfIdentifiedByOffice, _type = "Int64?",
              _get_func = o => o.idfIdentifiedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfIdentifiedByOffice != newval) 
                  o.IdentifiedByOffice = o.IdentifiedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfIdentifiedByOffice != newval) o.idfIdentifiedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfIdentifiedByOffice != c.idfIdentifiedByOffice || o.IsRIRPropChanged(_str_idfIdentifiedByOffice, c)) 
                  m.Add(_str_idfIdentifiedByOffice, o.ObjectIdent + _str_idfIdentifiedByOffice, o.ObjectIdent2 + _str_idfIdentifiedByOffice, o.ObjectIdent3 + _str_idfIdentifiedByOffice, "Int64?", 
                    o.idfIdentifiedByOffice == null ? "" : o.idfIdentifiedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfIdentifiedByOffice), o.IsInvisible(_str_idfIdentifiedByOffice), o.IsRequired(_str_idfIdentifiedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strIdentifiedByOffice, _formname = _str_strIdentifiedByOffice, _type = "String",
              _get_func = o => o.strIdentifiedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strIdentifiedByOffice != newval) o.strIdentifiedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strIdentifiedByOffice != c.strIdentifiedByOffice || o.IsRIRPropChanged(_str_strIdentifiedByOffice, c)) 
                  m.Add(_str_strIdentifiedByOffice, o.ObjectIdent + _str_strIdentifiedByOffice, o.ObjectIdent2 + _str_strIdentifiedByOffice, o.ObjectIdent3 + _str_strIdentifiedByOffice, "String", 
                    o.strIdentifiedByOffice == null ? "" : o.strIdentifiedByOffice.ToString(),                  
                  o.IsReadOnly(_str_strIdentifiedByOffice), o.IsInvisible(_str_strIdentifiedByOffice), o.IsRequired(_str_strIdentifiedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfIdentifiedByPerson, _formname = _str_idfIdentifiedByPerson, _type = "Int64?",
              _get_func = o => o.idfIdentifiedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfIdentifiedByPerson != newval) 
                  o.Identifier = o.IdentifierLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfIdentifiedByPerson != newval) o.idfIdentifiedByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfIdentifiedByPerson != c.idfIdentifiedByPerson || o.IsRIRPropChanged(_str_idfIdentifiedByPerson, c)) 
                  m.Add(_str_idfIdentifiedByPerson, o.ObjectIdent + _str_idfIdentifiedByPerson, o.ObjectIdent2 + _str_idfIdentifiedByPerson, o.ObjectIdent3 + _str_idfIdentifiedByPerson, "Int64?", 
                    o.idfIdentifiedByPerson == null ? "" : o.idfIdentifiedByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfIdentifiedByPerson), o.IsInvisible(_str_idfIdentifiedByPerson), o.IsRequired(_str_idfIdentifiedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strIdentifiedByPerson, _formname = _str_strIdentifiedByPerson, _type = "String",
              _get_func = o => o.strIdentifiedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strIdentifiedByPerson != newval) o.strIdentifiedByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strIdentifiedByPerson != c.strIdentifiedByPerson || o.IsRIRPropChanged(_str_strIdentifiedByPerson, c)) 
                  m.Add(_str_strIdentifiedByPerson, o.ObjectIdent + _str_strIdentifiedByPerson, o.ObjectIdent2 + _str_strIdentifiedByPerson, o.ObjectIdent3 + _str_strIdentifiedByPerson, "String", 
                    o.strIdentifiedByPerson == null ? "" : o.strIdentifiedByPerson.ToString(),                  
                  o.IsReadOnly(_str_strIdentifiedByPerson), o.IsInvisible(_str_strIdentifiedByPerson), o.IsRequired(_str_strIdentifiedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datIdentifiedDateTime, _formname = _str_datIdentifiedDateTime, _type = "DateTime?",
              _get_func = o => o.datIdentifiedDateTime,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datIdentifiedDateTime != newval) o.datIdentifiedDateTime = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datIdentifiedDateTime != c.datIdentifiedDateTime || o.IsRIRPropChanged(_str_datIdentifiedDateTime, c)) 
                  m.Add(_str_datIdentifiedDateTime, o.ObjectIdent + _str_datIdentifiedDateTime, o.ObjectIdent2 + _str_datIdentifiedDateTime, o.ObjectIdent3 + _str_datIdentifiedDateTime, "DateTime?", 
                    o.datIdentifiedDateTime == null ? "" : o.datIdentifiedDateTime.ToString(),                  
                  o.IsReadOnly(_str_datIdentifiedDateTime), o.IsInvisible(_str_datIdentifiedDateTime), o.IsRequired(_str_datIdentifiedDateTime)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsIdentificationMethod, _formname = _str_idfsIdentificationMethod, _type = "Int64?",
              _get_func = o => o.idfsIdentificationMethod,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsIdentificationMethod != newval) 
                  o.IdentificationMethod = o.IdentificationMethodLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsIdentificationMethod != newval) o.idfsIdentificationMethod = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsIdentificationMethod != c.idfsIdentificationMethod || o.IsRIRPropChanged(_str_idfsIdentificationMethod, c)) 
                  m.Add(_str_idfsIdentificationMethod, o.ObjectIdent + _str_idfsIdentificationMethod, o.ObjectIdent2 + _str_idfsIdentificationMethod, o.ObjectIdent3 + _str_idfsIdentificationMethod, "Int64?", 
                    o.idfsIdentificationMethod == null ? "" : o.idfsIdentificationMethod.ToString(),                  
                  o.IsReadOnly(_str_idfsIdentificationMethod), o.IsInvisible(_str_idfsIdentificationMethod), o.IsRequired(_str_idfsIdentificationMethod)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strIdentificationMethod, _formname = _str_strIdentificationMethod, _type = "String",
              _get_func = o => o.strIdentificationMethod,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strIdentificationMethod != newval) o.strIdentificationMethod = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strIdentificationMethod != c.strIdentificationMethod || o.IsRIRPropChanged(_str_strIdentificationMethod, c)) 
                  m.Add(_str_strIdentificationMethod, o.ObjectIdent + _str_strIdentificationMethod, o.ObjectIdent2 + _str_strIdentificationMethod, o.ObjectIdent3 + _str_strIdentificationMethod, "String", 
                    o.strIdentificationMethod == null ? "" : o.strIdentificationMethod.ToString(),                  
                  o.IsReadOnly(_str_strIdentificationMethod), o.IsInvisible(_str_strIdentificationMethod), o.IsRequired(_str_strIdentificationMethod)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfObservation, _formname = _str_idfObservation, _type = "Int64?",
              _get_func = o => o.idfObservation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfObservation != newval) o.idfObservation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfObservation != c.idfObservation || o.IsRIRPropChanged(_str_idfObservation, c)) 
                  m.Add(_str_idfObservation, o.ObjectIdent + _str_idfObservation, o.ObjectIdent2 + _str_idfObservation, o.ObjectIdent3 + _str_idfObservation, "Int64?", 
                    o.idfObservation == null ? "" : o.idfObservation.ToString(),                  
                  o.IsReadOnly(_str_idfObservation), o.IsInvisible(_str_idfObservation), o.IsRequired(_str_idfObservation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsFormTemplate, _formname = _str_idfsFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsFormTemplate != newval) o.idfsFormTemplate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, o.ObjectIdent2 + _str_idfsFormTemplate, o.ObjectIdent3 + _str_idfsFormTemplate, "Int64?", 
                    o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_dblLatitude, _formname = _str_dblLatitude, _type = "Double?",
              _get_func = o => o.dblLatitude,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDoubleNullable(val); if (o.dblLatitude != newval) o.dblLatitude = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.dblLatitude != c.dblLatitude || o.IsRIRPropChanged(_str_dblLatitude, c)) 
                  m.Add(_str_dblLatitude, o.ObjectIdent + _str_dblLatitude, o.ObjectIdent2 + _str_dblLatitude, o.ObjectIdent3 + _str_dblLatitude, "Double?", 
                    o.dblLatitude == null ? "" : o.dblLatitude.Value.ToString(new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator = "" }),                  
                  o.IsReadOnly(_str_dblLatitude), o.IsInvisible(_str_dblLatitude), o.IsRequired(_str_dblLatitude)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_dblLongitude, _formname = _str_dblLongitude, _type = "Double?",
              _get_func = o => o.dblLongitude,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDoubleNullable(val); if (o.dblLongitude != newval) o.dblLongitude = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.dblLongitude != c.dblLongitude || o.IsRIRPropChanged(_str_dblLongitude, c)) 
                  m.Add(_str_dblLongitude, o.ObjectIdent + _str_dblLongitude, o.ObjectIdent2 + _str_dblLongitude, o.ObjectIdent3 + _str_dblLongitude, "Double?", 
                    o.dblLongitude == null ? "" : o.dblLongitude.Value.ToString(new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator = "" }),                  
                  o.IsReadOnly(_str_dblLongitude), o.IsInvisible(_str_dblLongitude), o.IsRequired(_str_dblLongitude)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDayPeriod, _formname = _str_idfsDayPeriod, _type = "Int64?",
              _get_func = o => o.idfsDayPeriod,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsDayPeriod != newval) 
                  o.DayPeriod = o.DayPeriodLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsDayPeriod != newval) o.idfsDayPeriod = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDayPeriod != c.idfsDayPeriod || o.IsRIRPropChanged(_str_idfsDayPeriod, c)) 
                  m.Add(_str_idfsDayPeriod, o.ObjectIdent + _str_idfsDayPeriod, o.ObjectIdent2 + _str_idfsDayPeriod, o.ObjectIdent3 + _str_idfsDayPeriod, "Int64?", 
                    o.idfsDayPeriod == null ? "" : o.idfsDayPeriod.ToString(),                  
                  o.IsReadOnly(_str_idfsDayPeriod), o.IsInvisible(_str_idfsDayPeriod), o.IsRequired(_str_idfsDayPeriod)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDayPeriod, _formname = _str_strDayPeriod, _type = "String",
              _get_func = o => o.strDayPeriod,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDayPeriod != newval) o.strDayPeriod = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strDayPeriod != c.strDayPeriod || o.IsRIRPropChanged(_str_strDayPeriod, c)) 
                  m.Add(_str_strDayPeriod, o.ObjectIdent + _str_strDayPeriod, o.ObjectIdent2 + _str_strDayPeriod, o.ObjectIdent3 + _str_strDayPeriod, "String", 
                    o.strDayPeriod == null ? "" : o.strDayPeriod.ToString(),                  
                  o.IsReadOnly(_str_strDayPeriod), o.IsInvisible(_str_strDayPeriod), o.IsRequired(_str_strDayPeriod)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSpecies, _formname = _str_strSpecies, _type = "String",
              _get_func = o => o.strSpecies,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSpecies != newval) o.strSpecies = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSpecies != c.strSpecies || o.IsRIRPropChanged(_str_strSpecies, c)) 
                  m.Add(_str_strSpecies, o.ObjectIdent + _str_strSpecies, o.ObjectIdent2 + _str_strSpecies, o.ObjectIdent3 + _str_strSpecies, "String", 
                    o.strSpecies == null ? "" : o.strSpecies.ToString(),                  
                  o.IsReadOnly(_str_strSpecies), o.IsInvisible(_str_strSpecies), o.IsRequired(_str_strSpecies)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strComment, _formname = _str_strComment, _type = "String",
              _get_func = o => o.strComment,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strComment != newval) o.strComment = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strComment != c.strComment || o.IsRIRPropChanged(_str_strComment, c)) 
                  m.Add(_str_strComment, o.ObjectIdent + _str_strComment, o.ObjectIdent2 + _str_strComment, o.ObjectIdent3 + _str_strComment, "String", 
                    o.strComment == null ? "" : o.strComment.ToString(),                  
                  o.IsReadOnly(_str_strComment), o.IsInvisible(_str_strComment), o.IsRequired(_str_strComment)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsEctoparasitesCollected, _formname = _str_idfsEctoparasitesCollected, _type = "Int64?",
              _get_func = o => o.idfsEctoparasitesCollected,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsEctoparasitesCollected != newval) 
                  o.EctoparasitesCollected = o.EctoparasitesCollectedLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsEctoparasitesCollected != newval) o.idfsEctoparasitesCollected = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsEctoparasitesCollected != c.idfsEctoparasitesCollected || o.IsRIRPropChanged(_str_idfsEctoparasitesCollected, c)) 
                  m.Add(_str_idfsEctoparasitesCollected, o.ObjectIdent + _str_idfsEctoparasitesCollected, o.ObjectIdent2 + _str_idfsEctoparasitesCollected, o.ObjectIdent3 + _str_idfsEctoparasitesCollected, "Int64?", 
                    o.idfsEctoparasitesCollected == null ? "" : o.idfsEctoparasitesCollected.ToString(),                  
                  o.IsReadOnly(_str_idfsEctoparasitesCollected), o.IsInvisible(_str_idfsEctoparasitesCollected), o.IsRequired(_str_idfsEctoparasitesCollected)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strEctoparasitesCollected, _formname = _str_strEctoparasitesCollected, _type = "String",
              _get_func = o => o.strEctoparasitesCollected,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strEctoparasitesCollected != newval) o.strEctoparasitesCollected = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strEctoparasitesCollected != c.strEctoparasitesCollected || o.IsRIRPropChanged(_str_strEctoparasitesCollected, c)) 
                  m.Add(_str_strEctoparasitesCollected, o.ObjectIdent + _str_strEctoparasitesCollected, o.ObjectIdent2 + _str_strEctoparasitesCollected, o.ObjectIdent3 + _str_strEctoparasitesCollected, "String", 
                    o.strEctoparasitesCollected == null ? "" : o.strEctoparasitesCollected.ToString(),                  
                  o.IsReadOnly(_str_strEctoparasitesCollected), o.IsInvisible(_str_strEctoparasitesCollected), o.IsRequired(_str_strEctoparasitesCollected)); 
                  }
              }, 
        
            new field_info {
              _name = _str_openMode, _formname = _str_openMode, _type = "int",
              _get_func = o => o.openMode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.openMode != newval) o.openMode = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.openMode != c.openMode || o.IsRIRPropChanged(_str_openMode, c)) {
                  m.Add(_str_openMode, o.ObjectIdent + _str_openMode, o.ObjectIdent2 + _str_openMode, o.ObjectIdent3 + _str_openMode,  "int", 
                    o.openMode == null ? "" : o.openMode.ToString(),                  
                    o.IsReadOnly(_str_openMode), o.IsInvisible(_str_openMode), o.IsRequired(_str_openMode));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_intOriginalOrder, _formname = _str_intOriginalOrder, _type = "int",
              _get_func = o => o.intOriginalOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intOriginalOrder != newval) o.intOriginalOrder = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.intOriginalOrder != c.intOriginalOrder || o.IsRIRPropChanged(_str_intOriginalOrder, c)) {
                  m.Add(_str_intOriginalOrder, o.ObjectIdent + _str_intOriginalOrder, o.ObjectIdent2 + _str_intOriginalOrder, o.ObjectIdent3 + _str_intOriginalOrder,  "int", 
                    o.intOriginalOrder == null ? "" : o.intOriginalOrder.ToString(),                  
                    o.IsReadOnly(_str_intOriginalOrder), o.IsInvisible(_str_intOriginalOrder), o.IsRequired(_str_intOriginalOrder));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_intPostOrder, _formname = _str_intPostOrder, _type = "int",
              _get_func = o => o.intPostOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intPostOrder != newval) o.intPostOrder = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.intPostOrder != c.intPostOrder || o.IsRIRPropChanged(_str_intPostOrder, c)) {
                  m.Add(_str_intPostOrder, o.ObjectIdent + _str_intPostOrder, o.ObjectIdent2 + _str_intPostOrder, o.ObjectIdent3 + _str_intPostOrder,  "int", 
                    o.intPostOrder == null ? "" : o.intPostOrder.ToString(),                  
                    o.IsReadOnly(_str_intPostOrder), o.IsInvisible(_str_intPostOrder), o.IsRequired(_str_intPostOrder));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_blnIgnoreValidation, _formname = _str_blnIgnoreValidation, _type = "bool",
              _get_func = o => o.blnIgnoreValidation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnIgnoreValidation != newval) o.blnIgnoreValidation = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.blnIgnoreValidation != c.blnIgnoreValidation || o.IsRIRPropChanged(_str_blnIgnoreValidation, c)) {
                  m.Add(_str_blnIgnoreValidation, o.ObjectIdent + _str_blnIgnoreValidation, o.ObjectIdent2 + _str_blnIgnoreValidation, o.ObjectIdent3 + _str_blnIgnoreValidation,  "bool", 
                    o.blnIgnoreValidation == null ? "" : o.blnIgnoreValidation.ToString(),                  
                    o.IsReadOnly(_str_blnIgnoreValidation), o.IsInvisible(_str_blnIgnoreValidation), o.IsRequired(_str_blnIgnoreValidation));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_Session, _formname = _str_Session, _type = "VsSession",
              _get_func = o => o.Session,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_datStartDateFromSession, _formname = _str_datStartDateFromSession, _type = "DateTime?",
              _get_func = o => o.datStartDateFromSession,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.datStartDateFromSession != c.datStartDateFromSession || o.IsRIRPropChanged(_str_datStartDateFromSession, c)) {
                  m.Add(_str_datStartDateFromSession, o.ObjectIdent + _str_datStartDateFromSession, o.ObjectIdent2 + _str_datStartDateFromSession, o.ObjectIdent3 + _str_datStartDateFromSession, "DateTime?", o.datStartDateFromSession == null ? "" : o.datStartDateFromSession.ToString(), o.IsReadOnly(_str_datStartDateFromSession), o.IsInvisible(_str_datStartDateFromSession), o.IsRequired(_str_datStartDateFromSession));
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
              _name = _str_IsPoolVectorType, _formname = _str_IsPoolVectorType, _type = "bool",
              _get_func = o => o.IsPoolVectorType,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.IsPoolVectorType != c.IsPoolVectorType || o.IsRIRPropChanged(_str_IsPoolVectorType, c)) {
                  m.Add(_str_IsPoolVectorType, o.ObjectIdent + _str_IsPoolVectorType, o.ObjectIdent2 + _str_IsPoolVectorType, o.ObjectIdent3 + _str_IsPoolVectorType, "bool", o.IsPoolVectorType == null ? "" : o.IsPoolVectorType.ToString(), o.IsReadOnly(_str_IsPoolVectorType), o.IsInvisible(_str_IsPoolVectorType), o.IsRequired(_str_IsPoolVectorType));
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
              _name = _str_strVectorSpecificData, _formname = _str_strVectorSpecificData, _type = "string",
              _get_func = o => o.strVectorSpecificData,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strVectorSpecificData != c.strVectorSpecificData || o.IsRIRPropChanged(_str_strVectorSpecificData, c)) {
                  m.Add(_str_strVectorSpecificData, o.ObjectIdent + _str_strVectorSpecificData, o.ObjectIdent2 + _str_strVectorSpecificData, o.ObjectIdent3 + _str_strVectorSpecificData, "string", o.strVectorSpecificData == null ? "" : o.strVectorSpecificData.ToString(), o.IsReadOnly(_str_strVectorSpecificData), o.IsInvisible(_str_strVectorSpecificData), o.IsRequired(_str_strVectorSpecificData));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_SamplesAll, _formname = _str_SamplesAll, _type = "EditableList<VectorSample>",
              _get_func = o => o.SamplesAll,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_VectorsWithoutThisVectorSelectList, _formname = _str_VectorsWithoutThisVectorSelectList, _type = "EditableList<Vector>",
              _get_func = o => o.VectorsWithoutThisVectorSelectList,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_HostVector, _formname = _str_HostVector, _type = "Lookup",
              _get_func = o => { if (o.HostVector == null) return null; return o.HostVector.idfVector; },
              _set_func = (o, val) => { o.HostVector = o.HostVectorLookup.Where(c => c.idfVector.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_HostVector, c);
                if (o.idfHostVector != c.idfHostVector || o.IsRIRPropChanged(_str_HostVector, c) || bChangeLookupContent) {
                  m.Add(_str_HostVector, o.ObjectIdent + _str_HostVector, o.ObjectIdent2 + _str_HostVector, o.ObjectIdent3 + _str_HostVector, "Lookup", o.idfHostVector == null ? "" : o.idfHostVector.ToString(), o.IsReadOnly(_str_HostVector), o.IsInvisible(_str_HostVector), o.IsRequired(_str_HostVector),
                  bChangeLookupContent ? o.HostVectorLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_HostVector + "Lookup", _formname = _str_HostVector + "Lookup", _type = "LookupContent",
              _get_func = o => o.HostVectorLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_CollectedByOffice, _formname = _str_CollectedByOffice, _type = "Lookup",
              _get_func = o => { if (o.CollectedByOffice == null) return null; return o.CollectedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.CollectedByOffice = o.CollectedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_CollectedByOffice, c);
                if (o.idfCollectedByOffice != c.idfCollectedByOffice || o.IsRIRPropChanged(_str_CollectedByOffice, c) || bChangeLookupContent) {
                  m.Add(_str_CollectedByOffice, o.ObjectIdent + _str_CollectedByOffice, o.ObjectIdent2 + _str_CollectedByOffice, o.ObjectIdent3 + _str_CollectedByOffice, "Lookup", o.idfCollectedByOffice == null ? "" : o.idfCollectedByOffice.ToString(), o.IsReadOnly(_str_CollectedByOffice), o.IsInvisible(_str_CollectedByOffice), o.IsRequired(_str_CollectedByOffice),
                  bChangeLookupContent ? o.CollectedByOfficeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_CollectedByOffice + "Lookup", _formname = _str_CollectedByOffice + "Lookup", _type = "LookupContent",
              _get_func = o => o.CollectedByOfficeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_IdentifiedByOffice, _formname = _str_IdentifiedByOffice, _type = "Lookup",
              _get_func = o => { if (o.IdentifiedByOffice == null) return null; return o.IdentifiedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.IdentifiedByOffice = o.IdentifiedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_IdentifiedByOffice, c);
                if (o.idfIdentifiedByOffice != c.idfIdentifiedByOffice || o.IsRIRPropChanged(_str_IdentifiedByOffice, c) || bChangeLookupContent) {
                  m.Add(_str_IdentifiedByOffice, o.ObjectIdent + _str_IdentifiedByOffice, o.ObjectIdent2 + _str_IdentifiedByOffice, o.ObjectIdent3 + _str_IdentifiedByOffice, "Lookup", o.idfIdentifiedByOffice == null ? "" : o.idfIdentifiedByOffice.ToString(), o.IsReadOnly(_str_IdentifiedByOffice), o.IsInvisible(_str_IdentifiedByOffice), o.IsRequired(_str_IdentifiedByOffice),
                  bChangeLookupContent ? o.IdentifiedByOfficeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_IdentifiedByOffice + "Lookup", _formname = _str_IdentifiedByOffice + "Lookup", _type = "LookupContent",
              _get_func = o => o.IdentifiedByOfficeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Surrounding, _formname = _str_Surrounding, _type = "Lookup",
              _get_func = o => { if (o.Surrounding == null) return null; return o.Surrounding.idfsBaseReference; },
              _set_func = (o, val) => { o.Surrounding = o.SurroundingLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Surrounding, c);
                if (o.idfsSurrounding != c.idfsSurrounding || o.IsRIRPropChanged(_str_Surrounding, c) || bChangeLookupContent) {
                  m.Add(_str_Surrounding, o.ObjectIdent + _str_Surrounding, o.ObjectIdent2 + _str_Surrounding, o.ObjectIdent3 + _str_Surrounding, "Lookup", o.idfsSurrounding == null ? "" : o.idfsSurrounding.ToString(), o.IsReadOnly(_str_Surrounding), o.IsInvisible(_str_Surrounding), o.IsRequired(_str_Surrounding),
                  bChangeLookupContent ? o.SurroundingLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Surrounding + "Lookup", _formname = _str_Surrounding + "Lookup", _type = "LookupContent",
              _get_func = o => o.SurroundingLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_DayPeriod, _formname = _str_DayPeriod, _type = "Lookup",
              _get_func = o => { if (o.DayPeriod == null) return null; return o.DayPeriod.idfsBaseReference; },
              _set_func = (o, val) => { o.DayPeriod = o.DayPeriodLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_DayPeriod, c);
                if (o.idfsDayPeriod != c.idfsDayPeriod || o.IsRIRPropChanged(_str_DayPeriod, c) || bChangeLookupContent) {
                  m.Add(_str_DayPeriod, o.ObjectIdent + _str_DayPeriod, o.ObjectIdent2 + _str_DayPeriod, o.ObjectIdent3 + _str_DayPeriod, "Lookup", o.idfsDayPeriod == null ? "" : o.idfsDayPeriod.ToString(), o.IsReadOnly(_str_DayPeriod), o.IsInvisible(_str_DayPeriod), o.IsRequired(_str_DayPeriod),
                  bChangeLookupContent ? o.DayPeriodLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_DayPeriod + "Lookup", _formname = _str_DayPeriod + "Lookup", _type = "LookupContent",
              _get_func = o => o.DayPeriodLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_CollectionMethod, _formname = _str_CollectionMethod, _type = "Lookup",
              _get_func = o => { if (o.CollectionMethod == null) return null; return o.CollectionMethod.idfsCollectionMethod; },
              _set_func = (o, val) => { o.CollectionMethod = o.CollectionMethodLookup.Where(c => c.idfsCollectionMethod.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_CollectionMethod, c);
                if (o.idfsCollectionMethod != c.idfsCollectionMethod || o.IsRIRPropChanged(_str_CollectionMethod, c) || bChangeLookupContent) {
                  m.Add(_str_CollectionMethod, o.ObjectIdent + _str_CollectionMethod, o.ObjectIdent2 + _str_CollectionMethod, o.ObjectIdent3 + _str_CollectionMethod, "Lookup", o.idfsCollectionMethod == null ? "" : o.idfsCollectionMethod.ToString(), o.IsReadOnly(_str_CollectionMethod), o.IsInvisible(_str_CollectionMethod), o.IsRequired(_str_CollectionMethod),
                  bChangeLookupContent ? o.CollectionMethodLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_CollectionMethod + "Lookup", _formname = _str_CollectionMethod + "Lookup", _type = "LookupContent",
              _get_func = o => o.CollectionMethodLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_BasisOfRecord, _formname = _str_BasisOfRecord, _type = "Lookup",
              _get_func = o => { if (o.BasisOfRecord == null) return null; return o.BasisOfRecord.idfsBaseReference; },
              _set_func = (o, val) => { o.BasisOfRecord = o.BasisOfRecordLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_BasisOfRecord, c);
                if (o.idfsBasisOfRecord != c.idfsBasisOfRecord || o.IsRIRPropChanged(_str_BasisOfRecord, c) || bChangeLookupContent) {
                  m.Add(_str_BasisOfRecord, o.ObjectIdent + _str_BasisOfRecord, o.ObjectIdent2 + _str_BasisOfRecord, o.ObjectIdent3 + _str_BasisOfRecord, "Lookup", o.idfsBasisOfRecord == null ? "" : o.idfsBasisOfRecord.ToString(), o.IsReadOnly(_str_BasisOfRecord), o.IsInvisible(_str_BasisOfRecord), o.IsRequired(_str_BasisOfRecord),
                  bChangeLookupContent ? o.BasisOfRecordLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_BasisOfRecord + "Lookup", _formname = _str_BasisOfRecord + "Lookup", _type = "LookupContent",
              _get_func = o => o.BasisOfRecordLookup,
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
              _name = _str_AnimalGender, _formname = _str_AnimalGender, _type = "Lookup",
              _get_func = o => { if (o.AnimalGender == null) return null; return o.AnimalGender.idfsBaseReference; },
              _set_func = (o, val) => { o.AnimalGender = o.AnimalGenderLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AnimalGender, c);
                if (o.idfsSex != c.idfsSex || o.IsRIRPropChanged(_str_AnimalGender, c) || bChangeLookupContent) {
                  m.Add(_str_AnimalGender, o.ObjectIdent + _str_AnimalGender, o.ObjectIdent2 + _str_AnimalGender, o.ObjectIdent3 + _str_AnimalGender, "Lookup", o.idfsSex == null ? "" : o.idfsSex.ToString(), o.IsReadOnly(_str_AnimalGender), o.IsInvisible(_str_AnimalGender), o.IsRequired(_str_AnimalGender),
                  bChangeLookupContent ? o.AnimalGenderLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AnimalGender + "Lookup", _formname = _str_AnimalGender + "Lookup", _type = "LookupContent",
              _get_func = o => o.AnimalGenderLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_IdentificationMethod, _formname = _str_IdentificationMethod, _type = "Lookup",
              _get_func = o => { if (o.IdentificationMethod == null) return null; return o.IdentificationMethod.idfsBaseReference; },
              _set_func = (o, val) => { o.IdentificationMethod = o.IdentificationMethodLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_IdentificationMethod, c);
                if (o.idfsIdentificationMethod != c.idfsIdentificationMethod || o.IsRIRPropChanged(_str_IdentificationMethod, c) || bChangeLookupContent) {
                  m.Add(_str_IdentificationMethod, o.ObjectIdent + _str_IdentificationMethod, o.ObjectIdent2 + _str_IdentificationMethod, o.ObjectIdent3 + _str_IdentificationMethod, "Lookup", o.idfsIdentificationMethod == null ? "" : o.idfsIdentificationMethod.ToString(), o.IsReadOnly(_str_IdentificationMethod), o.IsInvisible(_str_IdentificationMethod), o.IsRequired(_str_IdentificationMethod),
                  bChangeLookupContent ? o.IdentificationMethodLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_IdentificationMethod + "Lookup", _formname = _str_IdentificationMethod + "Lookup", _type = "LookupContent",
              _get_func = o => o.IdentificationMethodLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Collector, _formname = _str_Collector, _type = "Lookup",
              _get_func = o => { if (o.Collector == null) return null; return o.Collector.idfPerson; },
              _set_func = (o, val) => { o.Collector = o.CollectorLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Collector, c);
                if (o.idfCollectedByPerson != c.idfCollectedByPerson || o.IsRIRPropChanged(_str_Collector, c) || bChangeLookupContent) {
                  m.Add(_str_Collector, o.ObjectIdent + _str_Collector, o.ObjectIdent2 + _str_Collector, o.ObjectIdent3 + _str_Collector, "Lookup", o.idfCollectedByPerson == null ? "" : o.idfCollectedByPerson.ToString(), o.IsReadOnly(_str_Collector), o.IsInvisible(_str_Collector), o.IsRequired(_str_Collector),
                  bChangeLookupContent ? o.CollectorLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Collector + "Lookup", _formname = _str_Collector + "Lookup", _type = "LookupContent",
              _get_func = o => o.CollectorLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Identifier, _formname = _str_Identifier, _type = "Lookup",
              _get_func = o => { if (o.Identifier == null) return null; return o.Identifier.idfPerson; },
              _set_func = (o, val) => { o.Identifier = o.IdentifierLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Identifier, c);
                if (o.idfIdentifiedByPerson != c.idfIdentifiedByPerson || o.IsRIRPropChanged(_str_Identifier, c) || bChangeLookupContent) {
                  m.Add(_str_Identifier, o.ObjectIdent + _str_Identifier, o.ObjectIdent2 + _str_Identifier, o.ObjectIdent3 + _str_Identifier, "Lookup", o.idfIdentifiedByPerson == null ? "" : o.idfIdentifiedByPerson.ToString(), o.IsReadOnly(_str_Identifier), o.IsInvisible(_str_Identifier), o.IsRequired(_str_Identifier),
                  bChangeLookupContent ? o.IdentifierLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Identifier + "Lookup", _formname = _str_Identifier + "Lookup", _type = "LookupContent",
              _get_func = o => o.IdentifierLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_EctoparasitesCollected, _formname = _str_EctoparasitesCollected, _type = "Lookup",
              _get_func = o => { if (o.EctoparasitesCollected == null) return null; return o.EctoparasitesCollected.idfsBaseReference; },
              _set_func = (o, val) => { o.EctoparasitesCollected = o.EctoparasitesCollectedLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_EctoparasitesCollected, c);
                if (o.idfsEctoparasitesCollected != c.idfsEctoparasitesCollected || o.IsRIRPropChanged(_str_EctoparasitesCollected, c) || bChangeLookupContent) {
                  m.Add(_str_EctoparasitesCollected, o.ObjectIdent + _str_EctoparasitesCollected, o.ObjectIdent2 + _str_EctoparasitesCollected, o.ObjectIdent3 + _str_EctoparasitesCollected, "Lookup", o.idfsEctoparasitesCollected == null ? "" : o.idfsEctoparasitesCollected.ToString(), o.IsReadOnly(_str_EctoparasitesCollected), o.IsInvisible(_str_EctoparasitesCollected), o.IsRequired(_str_EctoparasitesCollected),
                  bChangeLookupContent ? o.EctoparasitesCollectedLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_EctoparasitesCollected + "Lookup", _formname = _str_EctoparasitesCollected + "Lookup", _type = "LookupContent",
              _get_func = o => o.EctoparasitesCollectedLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Samples, _formname = _str_Samples, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Samples.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Samples.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.Samples.Count != c.Samples.Count || o.IsReadOnly(_str_Samples) != c.IsReadOnly(_str_Samples) || o.IsInvisible(_str_Samples) != c.IsInvisible(_str_Samples) || o.IsRequired(_str_Samples) != c._isRequired(o.m_isRequired, _str_Samples)) {
                  m.Add(_str_Samples, o.ObjectIdent + _str_Samples, o.ObjectIdent2 + _str_Samples, o.ObjectIdent3 + _str_Samples, "Child", o.idfVector == null ? "" : o.idfVector.ToString(), o.IsReadOnly(_str_Samples), o.IsInvisible(_str_Samples), o.IsRequired(_str_Samples)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_FieldTests, _formname = _str_FieldTests, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.FieldTests.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.FieldTests.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.FieldTests.Count != c.FieldTests.Count || o.IsReadOnly(_str_FieldTests) != c.IsReadOnly(_str_FieldTests) || o.IsInvisible(_str_FieldTests) != c.IsInvisible(_str_FieldTests) || o.IsRequired(_str_FieldTests) != c._isRequired(o.m_isRequired, _str_FieldTests)) {
                  m.Add(_str_FieldTests, o.ObjectIdent + _str_FieldTests, o.ObjectIdent2 + _str_FieldTests, o.ObjectIdent3 + _str_FieldTests, "Child", o.idfVector == null ? "" : o.idfVector.ToString(), o.IsReadOnly(_str_FieldTests), o.IsInvisible(_str_FieldTests), o.IsRequired(_str_FieldTests)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_LabTests, _formname = _str_LabTests, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.LabTests.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.LabTests.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.LabTests.Count != c.LabTests.Count || o.IsReadOnly(_str_LabTests) != c.IsReadOnly(_str_LabTests) || o.IsInvisible(_str_LabTests) != c.IsInvisible(_str_LabTests) || o.IsRequired(_str_LabTests) != c._isRequired(o.m_isRequired, _str_LabTests)) {
                  m.Add(_str_LabTests, o.ObjectIdent + _str_LabTests, o.ObjectIdent2 + _str_LabTests, o.ObjectIdent3 + _str_LabTests, "Child", o.idfVector == null ? "" : o.idfVector.ToString(), o.IsReadOnly(_str_LabTests), o.IsInvisible(_str_LabTests), o.IsRequired(_str_LabTests)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Location, _formname = _str_Location, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.Location != null) o.Location._compare(c.Location, m); }
              }, 
        
            new field_info {
              _name = _str_FFPresenter, _formname = _str_FFPresenter, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
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
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
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
                    
        [LocalizedDisplayName(_str_FFPresenter)]
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
                    
        [LocalizedDisplayName(_str_Samples)]
        [Relation(typeof(VectorSample), eidss.model.Schema.VectorSample._str_idfVector, _str_idfVector)]
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
                    
        [LocalizedDisplayName(_str_FieldTests)]
        [Relation(typeof(VectorFieldTest), eidss.model.Schema.VectorFieldTest._str_idfVector, _str_idfVector)]
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
                    
        [LocalizedDisplayName(_str_LabTests)]
        [Relation(typeof(VectorLabTest), eidss.model.Schema.VectorLabTest._str_idfVector, _str_idfVector)]
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
                    
        [LocalizedDisplayName("idfHostVector")]
        [Relation(typeof(Vector), eidss.model.Schema.Vector._str_idfVector, _str_idfHostVector)]
        public Vector HostVector
        {
            get { return _HostVector; }
            set 
            { 
                var oldVal = _HostVector;
                _HostVector = value;
                if (_HostVector != oldVal)
                {
                    if (idfHostVector != (_HostVector == null
                            ? new Int64?()
                            : (Int64?)_HostVector.idfVector))
                        idfHostVector = _HostVector == null 
                            ? new Int64?()
                            : (Int64?)_HostVector.idfVector; 
                    OnPropertyChanged(_str_HostVector); 
                }
            }
        }
        private Vector _HostVector;

        
        public List<Vector> HostVectorLookup
        {
            get 
            { 
                
                var ret = new List<Vector>();
                
              
                if (VectorsWithoutThisVectorSelectList != null)
                {
                    
                    ret.AddRange(VectorsWithoutThisVectorSelectList
                    );
                }
                return ret;
            }
        }
            
        [LocalizedDisplayName(_str_CollectedByOffice)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfCollectedByOffice)]
        public OrganizationLookup CollectedByOffice
        {
            get { return _CollectedByOffice == null ? null : ((long)_CollectedByOffice.Key == 0 ? null : _CollectedByOffice); }
            set 
            { 
                var oldVal = _CollectedByOffice;
                _CollectedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_CollectedByOffice != oldVal)
                {
                    if (idfCollectedByOffice != (_CollectedByOffice == null
                            ? new Int64()
                            : (Int64)_CollectedByOffice.idfInstitution))
                        idfCollectedByOffice = _CollectedByOffice == null 
                            ? new Int64()
                            : (Int64)_CollectedByOffice.idfInstitution; 
                    OnPropertyChanged(_str_CollectedByOffice); 
                }
            }
        }
        private OrganizationLookup _CollectedByOffice;

        
        public List<OrganizationLookup> CollectedByOfficeLookup
        {
            get { return _CollectedByOfficeLookup; }
        }
        private List<OrganizationLookup> _CollectedByOfficeLookup = new List<OrganizationLookup>();
            
        [LocalizedDisplayName(_str_IdentifiedByOffice)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfIdentifiedByOffice)]
        public OrganizationLookup IdentifiedByOffice
        {
            get { return _IdentifiedByOffice == null ? null : ((long)_IdentifiedByOffice.Key == 0 ? null : _IdentifiedByOffice); }
            set 
            { 
                var oldVal = _IdentifiedByOffice;
                _IdentifiedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_IdentifiedByOffice != oldVal)
                {
                    if (idfIdentifiedByOffice != (_IdentifiedByOffice == null
                            ? new Int64?()
                            : (Int64?)_IdentifiedByOffice.idfInstitution))
                        idfIdentifiedByOffice = _IdentifiedByOffice == null 
                            ? new Int64?()
                            : (Int64?)_IdentifiedByOffice.idfInstitution; 
                    OnPropertyChanged(_str_IdentifiedByOffice); 
                }
            }
        }
        private OrganizationLookup _IdentifiedByOffice;

        
        public List<OrganizationLookup> IdentifiedByOfficeLookup
        {
            get { return _IdentifiedByOfficeLookup; }
        }
        private List<OrganizationLookup> _IdentifiedByOfficeLookup = new List<OrganizationLookup>();
            
        [LocalizedDisplayName(_str_Surrounding)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSurrounding)]
        public BaseReference Surrounding
        {
            get { return _Surrounding == null ? null : ((long)_Surrounding.Key == 0 ? null : _Surrounding); }
            set 
            { 
                var oldVal = _Surrounding;
                _Surrounding = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Surrounding != oldVal)
                {
                    if (idfsSurrounding != (_Surrounding == null
                            ? new Int64?()
                            : (Int64?)_Surrounding.idfsBaseReference))
                        idfsSurrounding = _Surrounding == null 
                            ? new Int64?()
                            : (Int64?)_Surrounding.idfsBaseReference; 
                    OnPropertyChanged(_str_Surrounding); 
                }
            }
        }
        private BaseReference _Surrounding;

        
        public BaseReferenceList SurroundingLookup
        {
            get { return _SurroundingLookup; }
        }
        private BaseReferenceList _SurroundingLookup = new BaseReferenceList("rftSurrounding");
            
        [LocalizedDisplayName(_str_DayPeriod)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsDayPeriod)]
        public BaseReference DayPeriod
        {
            get { return _DayPeriod == null ? null : ((long)_DayPeriod.Key == 0 ? null : _DayPeriod); }
            set 
            { 
                var oldVal = _DayPeriod;
                _DayPeriod = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_DayPeriod != oldVal)
                {
                    if (idfsDayPeriod != (_DayPeriod == null
                            ? new Int64?()
                            : (Int64?)_DayPeriod.idfsBaseReference))
                        idfsDayPeriod = _DayPeriod == null 
                            ? new Int64?()
                            : (Int64?)_DayPeriod.idfsBaseReference; 
                    OnPropertyChanged(_str_DayPeriod); 
                }
            }
        }
        private BaseReference _DayPeriod;

        
        public BaseReferenceList DayPeriodLookup
        {
            get { return _DayPeriodLookup; }
        }
        private BaseReferenceList _DayPeriodLookup = new BaseReferenceList("rftCollectionTimePeriod");
            
        [LocalizedDisplayName(_str_CollectionMethod)]
        [Relation(typeof(CollectionMethodLookup), eidss.model.Schema.CollectionMethodLookup._str_idfsCollectionMethod, _str_idfsCollectionMethod)]
        public CollectionMethodLookup CollectionMethod
        {
            get { return _CollectionMethod == null ? null : ((long)_CollectionMethod.Key == 0 ? null : _CollectionMethod); }
            set 
            { 
                var oldVal = _CollectionMethod;
                _CollectionMethod = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_CollectionMethod != oldVal)
                {
                    if (idfsCollectionMethod != (_CollectionMethod == null
                            ? new Int64?()
                            : (Int64?)_CollectionMethod.idfsCollectionMethod))
                        idfsCollectionMethod = _CollectionMethod == null 
                            ? new Int64?()
                            : (Int64?)_CollectionMethod.idfsCollectionMethod; 
                    OnPropertyChanged(_str_CollectionMethod); 
                }
            }
        }
        private CollectionMethodLookup _CollectionMethod;

        
        public List<CollectionMethodLookup> CollectionMethodLookup
        {
            get { return _CollectionMethodLookup; }
        }
        private List<CollectionMethodLookup> _CollectionMethodLookup = new List<CollectionMethodLookup>();
            
        [LocalizedDisplayName(_str_BasisOfRecord)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsBasisOfRecord)]
        public BaseReference BasisOfRecord
        {
            get { return _BasisOfRecord == null ? null : ((long)_BasisOfRecord.Key == 0 ? null : _BasisOfRecord); }
            set 
            { 
                var oldVal = _BasisOfRecord;
                _BasisOfRecord = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_BasisOfRecord != oldVal)
                {
                    if (idfsBasisOfRecord != (_BasisOfRecord == null
                            ? new Int64?()
                            : (Int64?)_BasisOfRecord.idfsBaseReference))
                        idfsBasisOfRecord = _BasisOfRecord == null 
                            ? new Int64?()
                            : (Int64?)_BasisOfRecord.idfsBaseReference; 
                    OnPropertyChanged(_str_BasisOfRecord); 
                }
            }
        }
        private BaseReference _BasisOfRecord;

        
        public BaseReferenceList BasisOfRecordLookup
        {
            get { return _BasisOfRecordLookup; }
        }
        private BaseReferenceList _BasisOfRecordLookup = new BaseReferenceList("rftBasisOfRecord");
            
        [LocalizedDisplayName(_str_VectorType)]
        [Relation(typeof(VectorTypeLookup), eidss.model.Schema.VectorTypeLookup._str_idfsBaseReference, _str_idfsVectorType)]
        public VectorTypeLookup VectorType
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
        private VectorTypeLookup _VectorType;

        
        public List<VectorTypeLookup> VectorTypeLookup
        {
            get { return _VectorTypeLookup; }
        }
        private List<VectorTypeLookup> _VectorTypeLookup = new List<VectorTypeLookup>();
            
        [LocalizedDisplayName(_str_VectorSubType)]
        [Relation(typeof(VectorSubTypeLookup), eidss.model.Schema.VectorSubTypeLookup._str_idfsBaseReference, _str_idfsVectorSubType)]
        public VectorSubTypeLookup VectorSubType
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
        private VectorSubTypeLookup _VectorSubType;

        
        public List<VectorSubTypeLookup> VectorSubTypeLookup
        {
            get { return _VectorSubTypeLookup; }
        }
        private List<VectorSubTypeLookup> _VectorSubTypeLookup = new List<VectorSubTypeLookup>();
            
        [LocalizedDisplayName(_str_AnimalGender)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSex)]
        public BaseReference AnimalGender
        {
            get { return _AnimalGender == null ? null : ((long)_AnimalGender.Key == 0 ? null : _AnimalGender); }
            set 
            { 
                var oldVal = _AnimalGender;
                _AnimalGender = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AnimalGender != oldVal)
                {
                    if (idfsSex != (_AnimalGender == null
                            ? new Int64?()
                            : (Int64?)_AnimalGender.idfsBaseReference))
                        idfsSex = _AnimalGender == null 
                            ? new Int64?()
                            : (Int64?)_AnimalGender.idfsBaseReference; 
                    OnPropertyChanged(_str_AnimalGender); 
                }
            }
        }
        private BaseReference _AnimalGender;

        
        public BaseReferenceList AnimalGenderLookup
        {
            get { return _AnimalGenderLookup; }
        }
        private BaseReferenceList _AnimalGenderLookup = new BaseReferenceList("rftAnimalSex");
            
        [LocalizedDisplayName(_str_IdentificationMethod)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsIdentificationMethod)]
        public BaseReference IdentificationMethod
        {
            get { return _IdentificationMethod == null ? null : ((long)_IdentificationMethod.Key == 0 ? null : _IdentificationMethod); }
            set 
            { 
                var oldVal = _IdentificationMethod;
                _IdentificationMethod = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_IdentificationMethod != oldVal)
                {
                    if (idfsIdentificationMethod != (_IdentificationMethod == null
                            ? new Int64?()
                            : (Int64?)_IdentificationMethod.idfsBaseReference))
                        idfsIdentificationMethod = _IdentificationMethod == null 
                            ? new Int64?()
                            : (Int64?)_IdentificationMethod.idfsBaseReference; 
                    OnPropertyChanged(_str_IdentificationMethod); 
                }
            }
        }
        private BaseReference _IdentificationMethod;

        
        public BaseReferenceList IdentificationMethodLookup
        {
            get { return _IdentificationMethodLookup; }
        }
        private BaseReferenceList _IdentificationMethodLookup = new BaseReferenceList("rftIdentificationMethod");
            
        [LocalizedDisplayName(_str_Collector)]
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfCollectedByPerson)]
        public PersonLookup Collector
        {
            get { return _Collector == null ? null : ((long)_Collector.Key == 0 ? null : _Collector); }
            set 
            { 
                var oldVal = _Collector;
                _Collector = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Collector != oldVal)
                {
                    if (idfCollectedByPerson != (_Collector == null
                            ? new Int64?()
                            : (Int64?)_Collector.idfPerson))
                        idfCollectedByPerson = _Collector == null 
                            ? new Int64?()
                            : (Int64?)_Collector.idfPerson; 
                    OnPropertyChanged(_str_Collector); 
                }
            }
        }
        private PersonLookup _Collector;

        
        public List<PersonLookup> CollectorLookup
        {
            get { return _CollectorLookup; }
        }
        private List<PersonLookup> _CollectorLookup = new List<PersonLookup>();
            
        [LocalizedDisplayName(_str_Identifier)]
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfIdentifiedByPerson)]
        public PersonLookup Identifier
        {
            get { return _Identifier == null ? null : ((long)_Identifier.Key == 0 ? null : _Identifier); }
            set 
            { 
                var oldVal = _Identifier;
                _Identifier = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Identifier != oldVal)
                {
                    if (idfIdentifiedByPerson != (_Identifier == null
                            ? new Int64?()
                            : (Int64?)_Identifier.idfPerson))
                        idfIdentifiedByPerson = _Identifier == null 
                            ? new Int64?()
                            : (Int64?)_Identifier.idfPerson; 
                    OnPropertyChanged(_str_Identifier); 
                }
            }
        }
        private PersonLookup _Identifier;

        
        public List<PersonLookup> IdentifierLookup
        {
            get { return _IdentifierLookup; }
        }
        private List<PersonLookup> _IdentifierLookup = new List<PersonLookup>();
            
        [LocalizedDisplayName(_str_EctoparasitesCollected)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsEctoparasitesCollected)]
        public BaseReference EctoparasitesCollected
        {
            get { return _EctoparasitesCollected == null ? null : ((long)_EctoparasitesCollected.Key == 0 ? null : _EctoparasitesCollected); }
            set 
            { 
                var oldVal = _EctoparasitesCollected;
                _EctoparasitesCollected = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_EctoparasitesCollected != oldVal)
                {
                    if (idfsEctoparasitesCollected != (_EctoparasitesCollected == null
                            ? new Int64?()
                            : (Int64?)_EctoparasitesCollected.idfsBaseReference))
                        idfsEctoparasitesCollected = _EctoparasitesCollected == null 
                            ? new Int64?()
                            : (Int64?)_EctoparasitesCollected.idfsBaseReference; 
                    OnPropertyChanged(_str_EctoparasitesCollected); 
                }
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
            
                case _str_HostVector:
                    return new BvSelectList(HostVectorLookup, eidss.model.Schema.Vector._str_idfVector, null, HostVector, _str_idfHostVector);
            
                case _str_CollectedByOffice:
                    return new BvSelectList(CollectedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, CollectedByOffice, _str_idfCollectedByOffice);
            
                case _str_IdentifiedByOffice:
                    return new BvSelectList(IdentifiedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, IdentifiedByOffice, _str_idfIdentifiedByOffice);
            
                case _str_Surrounding:
                    return new BvSelectList(SurroundingLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Surrounding, _str_idfsSurrounding);
            
                case _str_DayPeriod:
                    return new BvSelectList(DayPeriodLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, DayPeriod, _str_idfsDayPeriod);
            
                case _str_CollectionMethod:
                    return new BvSelectList(CollectionMethodLookup, eidss.model.Schema.CollectionMethodLookup._str_idfsCollectionMethod, null, CollectionMethod, _str_idfsCollectionMethod);
            
                case _str_BasisOfRecord:
                    return new BvSelectList(BasisOfRecordLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, BasisOfRecord, _str_idfsBasisOfRecord);
            
                case _str_VectorType:
                    return new BvSelectList(VectorTypeLookup, eidss.model.Schema.VectorTypeLookup._str_idfsBaseReference, null, VectorType, _str_idfsVectorType);
            
                case _str_VectorSubType:
                    return new BvSelectList(VectorSubTypeLookup, eidss.model.Schema.VectorSubTypeLookup._str_idfsBaseReference, null, VectorSubType, _str_idfsVectorSubType);
            
                case _str_AnimalGender:
                    return new BvSelectList(AnimalGenderLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AnimalGender, _str_idfsSex);
            
                case _str_IdentificationMethod:
                    return new BvSelectList(IdentificationMethodLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, IdentificationMethod, _str_idfsIdentificationMethod);
            
                case _str_Collector:
                    return new BvSelectList(CollectorLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, Collector, _str_idfCollectedByPerson);
            
                case _str_Identifier:
                    return new BvSelectList(IdentifierLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, Identifier, _str_idfIdentifiedByPerson);
            
                case _str_EctoparasitesCollected:
                    return new BvSelectList(EctoparasitesCollectedLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, EctoparasitesCollected, _str_idfsEctoparasitesCollected);
            
                case _str_Samples:
                    return new BvSelectList(Samples, "", "", null, "");
            
                case _str_FieldTests:
                    return new BvSelectList(FieldTests, "", "", null, "");
            
                case _str_LabTests:
                    return new BvSelectList(LabTests, "", "", null, "");
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_Session)]
        public VsSession Session
        {
            get { return new Func<Vector, VsSession>(c => Parent as VsSession)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_datStartDateFromSession)]
        public DateTime? datStartDateFromSession
        {
            get { return new Func<Vector, DateTime?>(c => c.Session != null ? c.Session.datStartDate : DateTime.Now)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_Vectors)]
        public EditableList<Vector> Vectors
        {
            get { return new Func<Vector, EditableList<Vector>>(c => c.Session != null ? c.Session.Vectors : null)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsPoolVectorType)]
        public bool IsPoolVectorType
        {
            get { return new Func<Vector, bool>(c => c.GetIsPoolVectorType(c.idfsVectorType))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<Vector, string>(c => "Vectors_" + c.idfVectorSurveillanceSession + "_")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strVectorSpecificData)]
        public string strVectorSpecificData
        {
            get { return new Func<Vector, string>(c => c.RecalculateVectorSpecificData())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_SamplesAll)]
        public EditableList<VectorSample> SamplesAll
        {
            get { return new Func<Vector, EditableList<VectorSample>>(c => { var list = new EditableList<VectorSample>(); foreach (var vector in c.Vectors) list.AddRange(vector.Samples); return list;})(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_VectorsWithoutThisVectorSelectList)]
        public EditableList<Vector> VectorsWithoutThisVectorSelectList
        {
            get { return new Func<Vector, EditableList<Vector>>(c => c.VectorsWithoutThisVector())(this); }
            
        }
        
          [LocalizedDisplayName(_str_openMode)]
        public int openMode
        {
            get { return m_openMode; }
            set { if (m_openMode != value) { m_openMode = value; OnPropertyChanged(_str_openMode); } }
        }
        private int m_openMode;
        
          [LocalizedDisplayName(_str_intOriginalOrder)]
        public int intOriginalOrder
        {
            get { return m_intOriginalOrder; }
            set { if (m_intOriginalOrder != value) { m_intOriginalOrder = value; OnPropertyChanged(_str_intOriginalOrder); } }
        }
        private int m_intOriginalOrder;
        
          [LocalizedDisplayName(_str_intPostOrder)]
        public int intPostOrder
        {
            get { return m_intPostOrder; }
            set { if (m_intPostOrder != value) { m_intPostOrder = value; OnPropertyChanged(_str_intPostOrder); } }
        }
        private int m_intPostOrder;
        
          [LocalizedDisplayName(_str_blnIgnoreValidation)]
        public bool blnIgnoreValidation
        {
            get { return m_blnIgnoreValidation; }
            set { if (m_blnIgnoreValidation != value) { m_blnIgnoreValidation = value; OnPropertyChanged(_str_blnIgnoreValidation); } }
        }
        private bool m_blnIgnoreValidation;
        
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
                Samples.ForEach(c => { c.Parent = this; });
                FieldTests.ForEach(c => { c.Parent = this; });
                LabTests.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as Vector;
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
            var ret = base.Clone() as Vector;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Location != null)
              ret.Location = _Location.CloneWithSetup(manager, bRestricted) as GeoLocation;
                
            if (_FFPresenter != null)
              ret.FFPresenter = _FFPresenter.CloneWithSetup(manager, bRestricted) as FFPresenterModel;
                
            if (_Samples != null && _Samples.Count > 0)
            {
              ret.Samples.Clear();
              _Samples.ForEach(c => ret.Samples.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_FieldTests != null && _FieldTests.Count > 0)
            {
              ret.FieldTests.Clear();
              _FieldTests.ForEach(c => ret.FieldTests.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_LabTests != null && _LabTests.Count > 0)
            {
              ret.LabTests.Clear();
              _LabTests.ForEach(c => ret.LabTests.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
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
        public object KeyLookup { get { return idfVector; } }
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
        
                    || (_Location != null && _Location.HasChanges)
                
                    || (_FFPresenter != null && _FFPresenter.HasChanges)
                
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
        
            var _prev_idfCollectedByOffice_CollectedByOffice = idfCollectedByOffice;
            var _prev_idfIdentifiedByOffice_IdentifiedByOffice = idfIdentifiedByOffice;
            var _prev_idfsSurrounding_Surrounding = idfsSurrounding;
            var _prev_idfsDayPeriod_DayPeriod = idfsDayPeriod;
            var _prev_idfsCollectionMethod_CollectionMethod = idfsCollectionMethod;
            var _prev_idfsBasisOfRecord_BasisOfRecord = idfsBasisOfRecord;
            var _prev_idfsVectorType_VectorType = idfsVectorType;
            var _prev_idfsVectorSubType_VectorSubType = idfsVectorSubType;
            var _prev_idfsSex_AnimalGender = idfsSex;
            var _prev_idfsIdentificationMethod_IdentificationMethod = idfsIdentificationMethod;
            var _prev_idfCollectedByPerson_Collector = idfCollectedByPerson;
            var _prev_idfIdentifiedByPerson_Identifier = idfIdentifiedByPerson;
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
            if (_prev_idfsSurrounding_Surrounding != idfsSurrounding)
            {
                _Surrounding = _SurroundingLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSurrounding);
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
            if (_prev_idfsVectorType_VectorType != idfsVectorType)
            {
                _VectorType = _VectorTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorType);
            }
            if (_prev_idfsVectorSubType_VectorSubType != idfsVectorSubType)
            {
                _VectorSubType = _VectorSubTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsVectorSubType);
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
            if (_prev_idfsEctoparasitesCollected_EctoparasitesCollected != idfsEctoparasitesCollected)
            {
                _EctoparasitesCollected = _EctoparasitesCollectedLookup.FirstOrDefault(c => c.idfsBaseReference == idfsEctoparasitesCollected);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (Location != null) Location.DeepRejectChanges();
                
            if (FFPresenter != null) FFPresenter.DeepRejectChanges();
                Samples.DeepRejectChanges();
                FieldTests.DeepRejectChanges();
                LabTests.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Location != null) _Location.DeepAcceptChanges();
                
            if (_FFPresenter != null) _FFPresenter.DeepAcceptChanges();
                Samples.DeepAcceptChanges();
                FieldTests.DeepAcceptChanges();
                LabTests.DeepAcceptChanges();
                
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
        
            if (_Location != null) _Location.SetChange();
                
            if (_FFPresenter != null) _FFPresenter.SetChange();
                Samples.ForEach(c => c.SetChange());
                FieldTests.ForEach(c => c.SetChange());
                LabTests.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, Vector c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, Vector c)
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
        

      
        public override string ToString()
        {
            return new Func<Vector, string>(c => String.Format("{0}/{1}/{2}", strVectorID, strVectorType, strSpecies))(this);
        }
        

        public Vector()
        {
            
            m_permissions = new Permissions(this);
            
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
                OnPropertyChanged(_str_Session);
                  
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_datStartDateFromSession);
                  
            if (e.PropertyName == _str_Session)
                OnPropertyChanged(_str_Vectors);
                  
            if (e.PropertyName == _str_idfsVectorType)
                OnPropertyChanged(_str_IsPoolVectorType);
                  
            if (e.PropertyName == _str_idfVectorSurveillanceSession)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
            if (e.PropertyName == _str_Vectors)
                OnPropertyChanged(_str_SamplesAll);
                  
            if (e.PropertyName == _str_Vectors)
                OnPropertyChanged(_str_VectorsWithoutThisVectorSelectList);
                  
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
                        ValidationEventType.Error
                    )).Validate(obj, v => (v.Samples.Count == 0) || v.blnIgnoreValidation
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
            Vector obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Vector obj = this;
            
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
    
        private static string[] invisible_names1 = "HostVector".Split(new char[] { ',' });
        
        private bool _isInvisible(string name)
        {
            
            if (invisible_names1.Where(c => c == name).Count() > 0)
                return new Func<Vector, bool>(c => !c.GetIsPoolVectorType(c.idfsVectorType))(this);
            
            return false;
                
        }

    
        private static string[] readonly_names1 = "strVectorID".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strSessionID".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "strVectorType".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "strCollectedByOffice,strCollectedByPerson,strIdentifiedByOffice,strIdentifiedByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names5 = "Collector".Split(new char[] { ',' });
        
        private static string[] readonly_names6 = "Identifier".Split(new char[] { ',' });
        
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
                return ReadOnly || new Func<Vector, bool>(c => CollectedByOffice == null)(this);
            
            if (readonly_names6.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Vector, bool>(c => IdentifiedByOffice == null)(this);
            
            return ReadOnly || new Func<Vector, bool>(c => c.ReadOnly)(this);
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
                if (_Location != null)
                    _Location._isValid &= value;
                
                if (_FFPresenter != null)
                    _FFPresenter._isValid &= value;
                
                foreach(var o in _Samples)
                    o._isValid &= value;
                
                foreach(var o in _FieldTests)
                    o._isValid &= value;
                
                foreach(var o in _LabTests)
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
        
                if (_Location != null)
                    _Location.ReadOnly |= value;
                
                if (_FFPresenter != null)
                    _FFPresenter.ReadOnly |= value;
                
                foreach(var o in _Samples)
                    o.ReadOnly |= value;
                
                foreach(var o in _FieldTests)
                    o.ReadOnly |= value;
                
                foreach(var o in _LabTests)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<Vector, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Vector, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Vector, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Vector, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Vector, bool>> m_isHiddenPersonalData;
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
        protected bool bNeedLookupRemove;
        ~Vector()
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
                
                if (_Location != null)
                    Location.Dispose();
                
                if (_FFPresenter != null)
                    FFPresenter.Dispose();
                
                if (!bIsClone)
                {
                    Samples.ForEach(c => c.Dispose());
                }
                Samples.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    FieldTests.ForEach(c => c.Dispose());
                }
                FieldTests.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    LabTests.ForEach(c => c.Dispose());
                }
                LabTests.ClearModelListEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("Vector", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("rftSurrounding", this);
                
                LookupManager.RemoveObject("rftCollectionTimePeriod", this);
                
                LookupManager.RemoveObject("CollectionMethodLookup", this);
                
                LookupManager.RemoveObject("rftBasisOfRecord", this);
                
                LookupManager.RemoveObject("VectorTypeLookup", this);
                
                LookupManager.RemoveObject("VectorSubTypeLookup", this);
                
                LookupManager.RemoveObject("rftAnimalSex", this);
                
                LookupManager.RemoveObject("rftIdentificationMethod", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                LookupManager.RemoveObject("rftYesNoValue", this);
                
                }
            }
            GC.SuppressFinalize(this);
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
                _getAccessor().LoadLookup_Surrounding(manager, this);
            
            if (lookup_object == "rftCollectionTimePeriod")
                _getAccessor().LoadLookup_DayPeriod(manager, this);
            
            if (lookup_object == "CollectionMethodLookup")
                _getAccessor().LoadLookup_CollectionMethod(manager, this);
            
            if (lookup_object == "rftBasisOfRecord")
                _getAccessor().LoadLookup_BasisOfRecord(manager, this);
            
            if (lookup_object == "VectorTypeLookup")
                _getAccessor().LoadLookup_VectorType(manager, this);
            
            if (lookup_object == "VectorSubTypeLookup")
                _getAccessor().LoadLookup_VectorSubType(manager, this);
            
            if (lookup_object == "rftAnimalSex")
                _getAccessor().LoadLookup_AnimalGender(manager, this);
            
            if (lookup_object == "rftIdentificationMethod")
                _getAccessor().LoadLookup_IdentificationMethod(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_Collector(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_Identifier(manager, this);
            
            if (lookup_object == "rftYesNoValue")
                _getAccessor().LoadLookup_EctoparasitesCollected(manager, this);
            
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
        
            if (_Location != null) _Location.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_FFPresenter != null) _FFPresenter.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_Samples != null) _Samples.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_FieldTests != null) _FieldTests.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_LabTests != null) _LabTests.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
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
        
            public Double? dblLongitude { get; set; }
        
            public Double? dblLatitude { get; set; }
        
            public Int32? intElevation { get; set; }
        
            public String strSurrounding { get; set; }
        
            public DateTimeWrap datCollectionDateTime { get; set; }
        
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
        
            public DateTimeWrap datIdentifiedDateTime { get; set; }
        
            public String strIdentificationMethod { get; set; }
        
            public String strVectorSpecificData { get; set; }
        
        }
        public partial class VectorGridModelList : List<VectorGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public VectorGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<Vector>, errMes);
            }
            public VectorGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<Vector>, errMes);
            }
            public VectorGridModelList(long key, IEnumerable<Vector> items)
            {
                LoadGridModelList(key, items, null);
            }
            public VectorGridModelList(long key)
            {
                LoadGridModelList(key, new List<Vector>(), null);
            }
            partial void filter(List<Vector> items);
            private void LoadGridModelList(long key, IEnumerable<Vector> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strVectorID,_str_strFieldVectorID,_str_strRegion,_str_strRayon,_str_strSettlement,_str_dblLongitude,_str_dblLatitude,_str_intElevation,_str_strSurrounding,_str_datCollectionDateTime,_str_strDayPeriod,_str_strCollectedByPerson,_str_strCollectedByOffice,_str_strSpecies,_str_intQuantity,_str_strSex,_str_strEctoparasitesCollected,_str_strHostVector,_str_strCollectionMethod,_str_strBasisOfRecord,_str_strGEOReferenceSources,_str_strIdentifiedByPerson,_str_strIdentifiedByOffice,_str_datIdentifiedDateTime,_str_strIdentificationMethod,_str_strVectorSpecificData};
                    
                Hiddens = new List<string> {_str_idfVector};
                Keys = new List<string> {_str_idfVector};
                Labels = new Dictionary<string, string> {{_str_strVectorID, "Vector.strVectorID"},{_str_strFieldVectorID, "Vector.strFieldVectorID"},{_str_strRegion, _str_strRegion},{_str_strRayon, _str_strRayon},{_str_strSettlement, "Vector.strSettlement"},{_str_dblLongitude, "VsSessionListItem.dblLongitude"},{_str_dblLatitude, "VsSessionListItem.dblLatitude"},{_str_intElevation, _str_intElevation},{_str_strSurrounding, _str_strSurrounding},{_str_datCollectionDateTime, _str_datCollectionDateTime},{_str_strDayPeriod, _str_strDayPeriod},{_str_strCollectedByPerson, "Vector.idfFieldCollectedByPerson"},{_str_strCollectedByOffice, "VectorSample.idfFieldCollectedByOffice"},{_str_strSpecies, _str_strSpecies},{_str_intQuantity, _str_intQuantity},{_str_strSex, "idfsAnimalGender"},{_str_strEctoparasitesCollected, _str_strEctoparasitesCollected},{_str_strHostVector, "idfHostVector"},{_str_strCollectionMethod, _str_strCollectionMethod},{_str_strBasisOfRecord, _str_strBasisOfRecord},{_str_strGEOReferenceSources, _str_strGEOReferenceSources},{_str_strIdentifiedByPerson, _str_strIdentifiedByPerson},{_str_strIdentifiedByOffice, _str_strIdentifiedByOffice},{_str_datIdentifiedDateTime, _str_datIdentifiedDateTime},{_str_strIdentificationMethod, _str_strIdentificationMethod},{_str_strVectorSpecificData, _str_strVectorSpecificData}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strVectorID, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "ActionEditVector")}};
                Vector.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<Vector>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VectorGridModel()
                {
                    ItemKey=c.idfVector,strVectorID=c.strVectorID,strFieldVectorID=c.strFieldVectorID,strRegion=c.strRegion,strRayon=c.strRayon,strSettlement=c.strSettlement,dblLongitude=c.dblLongitude,dblLatitude=c.dblLatitude,intElevation=c.intElevation,strSurrounding=c.strSurrounding,datCollectionDateTime=c.datCollectionDateTime,strDayPeriod=c.strDayPeriod,strCollectedByPerson=c.strCollectedByPerson,strCollectedByOffice=c.strCollectedByOffice,strSpecies=c.strSpecies,intQuantity=c.intQuantity,strSex=c.strSex,strEctoparasitesCollected=c.strEctoparasitesCollected,strHostVector=c.strHostVector,strCollectionMethod=c.strCollectionMethod,strBasisOfRecord=c.strBasisOfRecord,strGEOReferenceSources=c.strGEOReferenceSources,strIdentifiedByPerson=c.strIdentifiedByPerson,strIdentifiedByOffice=c.strIdentifiedByOffice,datIdentifiedDateTime=c.datIdentifiedDateTime,strIdentificationMethod=c.strIdentificationMethod,strVectorSpecificData=c.strVectorSpecificData
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
            , IObjectCreator<Vector>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfVector"; } }
            #endregion
        
            public delegate void on_action(Vector obj);
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
            private VectorSample.Accessor SamplesAccessor { get { return eidss.model.Schema.VectorSample.Accessor.Instance(m_CS); } }
            private VectorFieldTest.Accessor FieldTestsAccessor { get { return eidss.model.Schema.VectorFieldTest.Accessor.Instance(m_CS); } }
            private VectorLabTest.Accessor LabTestsAccessor { get { return eidss.model.Schema.VectorLabTest.Accessor.Instance(m_CS); } }
            private Vector.Accessor HostVectorAccessor { get { return eidss.model.Schema.Vector.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor CollectedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor IdentifiedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SurroundingAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor DayPeriodAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private CollectionMethodLookup.Accessor CollectionMethodAccessor { get { return eidss.model.Schema.CollectionMethodLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor BasisOfRecordAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private VectorTypeLookup.Accessor VectorTypeAccessor { get { return eidss.model.Schema.VectorTypeLookup.Accessor.Instance(m_CS); } }
            private VectorSubTypeLookup.Accessor VectorSubTypeAccessor { get { return eidss.model.Schema.VectorSubTypeLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AnimalGenderAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor IdentificationMethodAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor CollectorAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor IdentifierAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
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

            

            public List<Vector> _SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfVectorSurveillanceSession
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<Vector> _SelectListInternal(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
                Vector _obj = null;
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
    
            private void _SetupAddChildHandlerSamples(Vector obj)
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
            
            private void _SetupAddChildHandlerFieldTests(Vector obj)
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
            
            private void _SetupAddChildHandlerLabTests(Vector obj)
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
            
            internal void _LoadSamples(Vector obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSamples(manager, obj);
                }
            }
            internal void _LoadSamples(DbManagerProxy manager, Vector obj)
            {
              
                obj.Samples.Clear();
                obj.Samples.AddRange(SamplesAccessor.SelectDetailList(manager
                    
                    , obj.idfVector
                    ));
                obj.Samples.ForEach(c => c.m_ObjectName = _str_Samples);
                obj.Samples.AcceptChanges();
                    
              }
            
            internal void _LoadFieldTests(Vector obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFieldTests(manager, obj);
                }
            }
            internal void _LoadFieldTests(DbManagerProxy manager, Vector obj)
            {
              
                obj.FieldTests.Clear();
                obj.FieldTests.AddRange(FieldTestsAccessor.SelectDetailList(manager
                    
                    , obj.idfVector
                    ));
                obj.FieldTests.ForEach(c => c.m_ObjectName = _str_FieldTests);
                obj.FieldTests.AcceptChanges();
                    
              }
            
            internal void _LoadLabTests(Vector obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLabTests(manager, obj);
                }
            }
            internal void _LoadLabTests(DbManagerProxy manager, Vector obj)
            {
              
                obj.LabTests.Clear();
                obj.LabTests.AddRange(LabTestsAccessor.SelectDetailList(manager
                    
                    , obj.idfVector
                    ));
                obj.LabTests.ForEach(c => c.m_ObjectName = _str_LabTests);
                obj.LabTests.AcceptChanges();
                    
              }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, Vector obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadLocation(manager, obj);
                _LoadFFPresenter(manager, obj);
                _LoadSamples(manager, obj);
                _LoadFieldTests(manager, obj);
                _LoadLabTests(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.Location = new Func<Vector, GeoLocation>(c => c.Location == null ? LocationAccessor.CreateWithCountry(manager, c) : c.Location)(obj);
                obj.strVectorType = new Func<Vector, string>(c => c.VectorType == null ? String.Empty : c.VectorType.strTranslatedName)(obj);
                obj.strSpecies = new Func<Vector, string>(c => c.VectorSubTypeLookup == null ? String.Empty : c.VectorSubTypeLookup.FirstOrDefault(p => p.idfsBaseReference == c.idfsVectorSubType).name)(obj);
                    if (obj.idfsFormTemplate.HasValue) 
                    { 
                      obj.FFPresenter.SetProperties(obj.idfsFormTemplate.Value, obj.idfVector);
                      obj.OnPropertyChanged("FFPresenter");
                    }
                  
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerSamples(obj);
                
                _SetupAddChildHandlerFieldTests(obj);
                
                _SetupAddChildHandlerLabTests(obj);
                
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
                    
                        obj.Samples.ForEach(c => SamplesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.FieldTests.ForEach(c => FieldTestsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.LabTests.ForEach(c => LabTestsAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private Vector _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                Vector obj = null;
                try
                {
                    obj = Vector.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfVector = (new GetNewIDExtender<Vector>()).GetScalar(manager, obj, isFake);
                obj.strVectorID = new Func<Vector, DbManagerProxy, string>((c,m) => 
                        m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.VsVector, DBNull.Value, DBNull.Value)
                        .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue"))(obj, manager);
                obj.Location = new Func<Vector, GeoLocation>(c => c.Location == null ? LocationAccessor.CreateWithCountry(manager, c) : c.Location)(obj);
                obj.intQuantity = new Func<Vector, int>(c => 1)(obj);
                obj.datCollectionDateTime = new Func<Vector, DateTime>(c => DateTime.Now)(obj);
                obj.idfObservation = (new GetNewIDExtender<Vector>()).GetScalar(manager, obj, isFake);
                        obj.FFPresenter = FFPresenterModel.Accessor.Instance(null).SelectByKey(manager, obj.idfObservation);
                        obj.FFPresenter.SetProperties(EidssSiteContext.Instance.CountryID, obj.idfsVectorType, FFTypeEnum.VectorTypeSpecificData, obj.idfObservation.Value, obj.idfVector);
                        if (obj.FFPresenter.CurrentTemplate != null)
                        {
                          obj.idfsFormTemplate = obj.FFPresenter.CurrentTemplate.idfsFormTemplate;
                          obj.OnPropertyChanged("FFPresenter");
                        }
                      
                obj.openMode = new Func<Vector, int>(c => 0)(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerSamples(obj);
                    
                    _SetupAddChildHandlerFieldTests(obj);
                    
                    _SetupAddChildHandlerLabTests(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.idfVectorSurveillanceSession = new Func<Vector, long>(c => c.Session != null ? c.Session.idfVectorSurveillanceSession : c.idfVectorSurveillanceSession)(obj);
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

            
            public Vector CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Vector CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
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
                if (pars.Count != 4) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfVectorSurveillanceSession", typeof(long));
                if (pars[1] != null && !(pars[1] is DateTime)) 
                    throw new TypeMismatchException("datCollectionDateTime", typeof(DateTime));
                if (pars[2] != null && !(pars[2] is string)) 
                    throw new TypeMismatchException("strSessionID", typeof(string));
                if (pars[3] != null && !(pars[3] is GeoLocation)) 
                    throw new TypeMismatchException("Location", typeof(GeoLocation));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    , (DateTime)pars[1]
                    , (string)pars[2]
                    , (GeoLocation)pars[3]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public Vector Create(DbManagerProxy manager, IObject Parent
                , long idfVectorSurveillanceSession
                , DateTime datCollectionDateTime
                , string strSessionID
                , GeoLocation Location
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfVectorSurveillanceSession = new Func<Vector, long>(c => idfVectorSurveillanceSession)(obj);
                obj.datCollectionDateTime = new Func<Vector, DateTime>(c => datCollectionDateTime)(obj);
                obj.strSessionID = new Func<Vector, string>(c => strSessionID)(obj);
                    obj.Location = LocationAccessor.CreateWithCountry(manager, obj);
                    obj.CopyLocation(Location);
                    /*
                    obj.Location.strDescription = Location.strDescription;
                    obj.Location.blnGeoLocationShared = Location.blnGeoLocationShared;
                    obj.Location.Region = Location.idfsRegion.HasValue ? Location.RegionLookup.SingleOrDefault(c => c.idfsRegion == Location.idfsRegion.Value) : obj.Location.Region;
                    obj.Location.Rayon = Location.idfsRayon.HasValue ? Location.RayonLookup.SingleOrDefault(c => c.idfsRayon == Location.idfsRayon.Value) : obj.Location.Rayon;
                    obj.Location.Settlement = Location.idfsSettlement.HasValue ? Location.SettlementLookup.SingleOrDefault(c => c.idfsSettlement == Location.idfsSettlement.Value) : obj.Location.Settlement;
                    obj.Location.dblLatitude = Location.dblLatitude;
                    obj.Location.dblLongitude = Location.dblLongitude;
                    obj.Location.dblDistance = Location.dblDistance;
                    obj.Location.dblAccuracy = Location.dblAccuracy;
                    obj.Location.GeoLocationType = Location.GeoLocationType;
                    obj.Location.GroundType = Location.GroundType;
                    
                    
                    obj.strRegion = obj.Location.Region == null ? "" : obj.Location.Region.strRegionName;
                    obj.strRayon = obj.Location.Rayon == null ? "" : obj.Location.Rayon.strRayonName;
                    obj.strSettlement = obj.Location.Settlement == null ? "" : obj.Location.Settlement.strSettlementName;
                    obj.dblLatitude = obj.Location.dblLatitude;
                    obj.dblLongitude = obj.Location.dblLongitude;
                    */
                  
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
            
      
            public ActResult CopyVector(DbManagerProxy manager, Vector obj, List<object> pars)
            {
                
                return CopyVector(manager, obj
                    );
            }
            public ActResult CopyVector(DbManagerProxy manager, Vector obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("CopyVector"))
                    throw new PermissionException("VsSession", "CopyVector");
                
                return true;
                
            }
            
      
            public ActResult VectorCancel(DbManagerProxy manager, Vector obj, List<object> pars)
            {
                
                return VectorCancel(manager, obj
                    );
            }
            public ActResult VectorCancel(DbManagerProxy manager, Vector obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("VectorCancel"))
                    throw new PermissionException("VsSession", "VectorCancel");
                
                return true;
                
            }
            
      
            public ActResult ActionEditVector(DbManagerProxy manager, Vector obj, List<object> pars)
            {
                
                return ActionEditVector(manager, obj
                    );
            }
            public ActResult ActionEditVector(DbManagerProxy manager, Vector obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ActionEditVector"))
                    throw new PermissionException("VsSession", "ActionEditVector");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(Vector obj, object newobj)
            {
                
                    if (newobj == null || newobj == obj.Location)
                    {
                        var o = obj.Location;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "idfsCountry")
                                {
                                
                obj.strCountry = new Func<Vector, string>(c => c.Location.Country == null ? "" : c.Location.Country.strCountryName)(obj);
                                }
                            };
                        }    
                        
                    }
                            
                    if (newobj == null || newobj == obj.Location)
                    {
                        var o = obj.Location;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "idfsRegion")
                                {
                                
                obj.strRegion = new Func<Vector, string>(c => c.Location.Region == null ? "" : c.Location.Region.strRegionName)(obj);
                                }
                            };
                        }    
                        
                    }
                            
                    if (newobj == null || newobj == obj.Location)
                    {
                        var o = obj.Location;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "idfsRayon")
                                {
                                
                obj.strRayon = new Func<Vector, string>(c => c.Location.Rayon == null ? "" : c.Location.Rayon.strRayonName)(obj);
                                }
                            };
                        }    
                        
                    }
                            
                    if (newobj == null || newobj == obj.Location)
                    {
                        var o = obj.Location;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "idfsSettlement")
                                {
                                
                obj.strSettlement = new Func<Vector, string>(c => c.Location.Settlement == null ? "" : c.Location.Settlement.strSettlementName)(obj);
                                }
                            };
                        }    
                        
                    }
                            
                    if (newobj == null || newobj == obj.Location)
                    {
                        var o = obj.Location;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "dblLatitude")
                                {
                                
                obj.dblLatitude = new Func<Vector, double?>(c => c.Location.dblLatitude)(obj);
                                }
                            };
                        }    
                        
                    }
                            
                    if (newobj == null || newobj == obj.Location)
                    {
                        var o = obj.Location;
                            
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "dblLongitude")
                                {
                                
                obj.dblLongitude = new Func<Vector, double?>(c => c.Location.dblLongitude)(obj);
                                }
                            };
                        }    
                        
                    }
                            
            }
            
            private void _SetupHandlers(Vector obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datIdentifiedDateTime)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datIdentifiedDateTime);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datCollectionDateTime)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datCollectionDateTime);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datIdentifiedDateTime)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datIdentifiedDateTime);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datStartDateFromSession)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datStartDateFromSession);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datCollectionDateTime)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datCollectionDateTime);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfCollectedByOffice)
                        {
                    
                obj.Collector = (new SetScalarHandler()).Handler(obj,
                    obj.idfCollectedByOffice, obj.idfCollectedByOffice_Previous, obj.Collector,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfIdentifiedByOffice)
                        {
                    
                obj.Identifier = (new SetScalarHandler()).Handler(obj,
                    obj.idfIdentifiedByOffice, obj.idfIdentifiedByOffice_Previous, obj.Identifier,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                obj.strVectorType = new Func<Vector, string>(c => c.VectorType == null ? String.Empty : c.VectorType.strTranslatedName)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorSubType)
                        {
                    
                obj.strSpecies = new Func<Vector, string>(c => c.VectorSubTypeLookup == null ? String.Empty : c.VectorSubTypeLookup.FirstOrDefault(p => p.idfsBaseReference == c.idfsVectorSubType).name)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_CollectionMethod(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_VectorSubType(manager, obj);
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
                    
                        if (e.PropertyName == _str_idfsSurrounding)
                        {
                    
                obj.strSurrounding = new Func<Vector, string>(c => c.Surrounding == null ? "" : c.Surrounding.name)(obj);
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
                    
                        if (e.PropertyName == _str_IsPoolVectorType)
                        {
                    
                obj.HostVector = new Func<Vector, Vector>(c => !c.IsPoolVectorType ? null : c.HostVector)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsEctoparasitesCollected)
                        {
                    
                obj.strEctoparasitesCollected = new Func<Vector, string>(c => c.idfsEctoparasitesCollected != null ? c.EctoparasitesCollectedLookup.FirstOrDefault(p => p.idfsBaseReference == c.idfsEctoparasitesCollected).name : c.strEctoparasitesCollected)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                obj.VectorSubType = new Func<Vector, VectorSubTypeLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsVectorType)
                        {
                    
                    obj.RefreshFF();
                  
                        }
                    
                        if (e.PropertyName == _str_VectorType)
                        {
                    
                    obj.RefreshFF();
                  
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
                    
                if (obj.Samples != null) 
                    obj.Samples.ForEach(t => { t.strVectorSubTypeName = new Func<Vector, string>(c => obj.VectorSubType != null? obj.VectorSubType.name : String.Empty)(obj); } );
                        }
                    
                        if (e.PropertyName == _str_strVectorID)
                        {
                    
                if (obj.Samples != null) 
                    obj.Samples.ForEach(t => { t.strVectorID = new Func<Vector, string>(c => obj.strVectorID)(obj); } );
                        }
                    
                    };
                
            }
    
            public void LoadLookup_CollectedByOffice(DbManagerProxy manager, Vector obj)
            {
                
                obj.CollectedByOfficeLookup.Clear();
                
                obj.CollectedByOfficeLookup.Add(CollectedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.CollectedByOfficeLookup.AddRange(CollectedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (((c.intHACode??0) & (int)HACode.Vector) != 0) || c.idfInstitution == obj.idfCollectedByOffice)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfCollectedByOffice))
                    
                    .ToList());
                
                if (obj.idfCollectedByOffice != 0)
                {
                    obj.CollectedByOffice = obj.CollectedByOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfCollectedByOffice);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, CollectedByOfficeAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_IdentifiedByOffice(DbManagerProxy manager, Vector obj)
            {
                
                obj.IdentifiedByOfficeLookup.Clear();
                
                obj.IdentifiedByOfficeLookup.Add(IdentifiedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.IdentifiedByOfficeLookup.AddRange(IdentifiedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (((c.intHACode??0) & (int)HACode.Vector) != 0) || c.idfInstitution == obj.idfIdentifiedByOffice)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfIdentifiedByOffice))
                    
                    .ToList());
                
                if (obj.idfIdentifiedByOffice != null && obj.idfIdentifiedByOffice != 0)
                {
                    obj.IdentifiedByOffice = obj.IdentifiedByOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfIdentifiedByOffice);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, IdentifiedByOfficeAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Surrounding(DbManagerProxy manager, Vector obj)
            {
                
                obj.SurroundingLookup.Clear();
                
                obj.SurroundingLookup.Add(SurroundingAccessor.CreateNewT(manager, null));
                
                obj.SurroundingLookup.AddRange(SurroundingAccessor.rftSurrounding_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSurrounding))
                    
                    .ToList());
                
                if (obj.idfsSurrounding != null && obj.idfsSurrounding != 0)
                {
                    obj.Surrounding = obj.SurroundingLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsSurrounding);
                    
                }
              
                LookupManager.AddObject("rftSurrounding", obj, SurroundingAccessor.GetType(), "rftSurrounding_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_DayPeriod(DbManagerProxy manager, Vector obj)
            {
                
                obj.DayPeriodLookup.Clear();
                
                obj.DayPeriodLookup.Add(DayPeriodAccessor.CreateNewT(manager, null));
                
                obj.DayPeriodLookup.AddRange(DayPeriodAccessor.rftCollectionTimePeriod_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsDayPeriod))
                    
                    .ToList());
                
                if (obj.idfsDayPeriod != null && obj.idfsDayPeriod != 0)
                {
                    obj.DayPeriod = obj.DayPeriodLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsDayPeriod);
                    
                }
              
                LookupManager.AddObject("rftCollectionTimePeriod", obj, DayPeriodAccessor.GetType(), "rftCollectionTimePeriod_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
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
                        .SingleOrDefault(c => c.idfsCollectionMethod == obj.idfsCollectionMethod);
                    
                }
              
                LookupManager.AddObject("CollectionMethodLookup", obj, CollectionMethodAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
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
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsBasisOfRecord);
                    
                }
              
                LookupManager.AddObject("rftBasisOfRecord", obj, BasisOfRecordAccessor.GetType(), "rftBasisOfRecord_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_VectorType(DbManagerProxy manager, Vector obj)
            {
                
                obj.VectorTypeLookup.Clear();
                
                obj.VectorTypeLookup.Add(VectorTypeAccessor.CreateNewT(manager, null));
                
                obj.VectorTypeLookup.AddRange(VectorTypeAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorType))
                    
                    .ToList());
                
                if (obj.idfsVectorType != 0)
                {
                    obj.VectorType = obj.VectorTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsVectorType);
                    
                }
              
                LookupManager.AddObject("VectorTypeLookup", obj, VectorTypeAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_VectorSubType(DbManagerProxy manager, Vector obj)
            {
                
                obj.VectorSubTypeLookup.Clear();
                
                obj.VectorSubTypeLookup.Add(VectorSubTypeAccessor.CreateNewT(manager, null));
                
                obj.VectorSubTypeLookup.AddRange(VectorSubTypeAccessor.SelectLookupList(manager
                    
                    , new Func<Vector, long>(c => c.idfsVectorType > 0 ? c.idfsVectorType : 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsVectorSubType))
                    
                    .ToList());
                
                if (obj.idfsVectorSubType != 0)
                {
                    obj.VectorSubType = obj.VectorSubTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsVectorSubType);
                    
                }
              
                LookupManager.AddObject("VectorSubTypeLookup", obj, VectorSubTypeAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_AnimalGender(DbManagerProxy manager, Vector obj)
            {
                
                obj.AnimalGenderLookup.Clear();
                
                obj.AnimalGenderLookup.Add(AnimalGenderAccessor.CreateNewT(manager, null));
                
                obj.AnimalGenderLookup.AddRange(AnimalGenderAccessor.rftAnimalSex_SelectList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Vector) != 0) || c.idfsBaseReference == obj.idfsSex)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSex))
                    
                    .ToList());
                
                if (obj.idfsSex != null && obj.idfsSex != 0)
                {
                    obj.AnimalGender = obj.AnimalGenderLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsSex);
                    
                }
              
                LookupManager.AddObject("rftAnimalSex", obj, AnimalGenderAccessor.GetType(), "rftAnimalSex_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
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
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsIdentificationMethod);
                    
                }
              
                LookupManager.AddObject("rftIdentificationMethod", obj, IdentificationMethodAccessor.GetType(), "rftIdentificationMethod_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Collector(DbManagerProxy manager, Vector obj)
            {
                
                obj.CollectorLookup.Clear();
                
                obj.CollectorLookup.Add(CollectorAccessor.CreateNewT(manager, null));
                
                obj.CollectorLookup.AddRange(CollectorAccessor.SelectLookupList(manager
                    
                    , new Func<Vector, long?>(c => c.idfCollectedByOffice)(obj)
                            
                    , null
                    , false
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfCollectedByPerson))
                    
                    .ToList());
                
                if (obj.idfCollectedByPerson != null && obj.idfCollectedByPerson != 0)
                {
                    obj.Collector = obj.CollectorLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfCollectedByPerson);
                    
                }
              
                LookupManager.AddObject("PersonLookup", obj, CollectorAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Identifier(DbManagerProxy manager, Vector obj)
            {
                
                obj.IdentifierLookup.Clear();
                
                obj.IdentifierLookup.Add(IdentifierAccessor.CreateNewT(manager, null));
                
                obj.IdentifierLookup.AddRange(IdentifierAccessor.SelectLookupList(manager
                    
                    , new Func<Vector, long?>(c => c.idfIdentifiedByOffice ?? 0)(obj)
                            
                    , null
                    , false
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfIdentifiedByPerson))
                    
                    .ToList());
                
                if (obj.idfIdentifiedByPerson != null && obj.idfIdentifiedByPerson != 0)
                {
                    obj.Identifier = obj.IdentifierLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfIdentifiedByPerson);
                    
                }
              
                LookupManager.AddObject("PersonLookup", obj, IdentifierAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
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
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsEctoparasitesCollected);
                    
                }
              
                LookupManager.AddObject("rftYesNoValue", obj, EctoparasitesCollectedAccessor.GetType(), "rftYesNoValue_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, Vector obj)
            {
                
                LoadLookup_CollectedByOffice(manager, obj);
                
                LoadLookup_IdentifiedByOffice(manager, obj);
                
                LoadLookup_Surrounding(manager, obj);
                
                LoadLookup_DayPeriod(manager, obj);
                
                LoadLookup_CollectionMethod(manager, obj);
                
                LoadLookup_BasisOfRecord(manager, obj);
                
                LoadLookup_VectorType(manager, obj);
                
                LoadLookup_VectorSubType(manager, obj);
                
                LoadLookup_AnimalGender(manager, obj);
                
                LoadLookup_IdentificationMethod(manager, obj);
                
                LoadLookup_Collector(manager, obj);
                
                LoadLookup_Identifier(manager, obj);
                
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
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        Vector bo = obj as Vector;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            if (!CanDelete)
                                throw new PermissionException("VsSession", "Delete");
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            if (!CanInsert)
                                throw new PermissionException("VsSession", "Insert");
                        }
                        else if (!bo.IsMarkedToDelete && bo.HasChanges) // update
                        {
                            if (!CanUpdate)
                                throw new PermissionException("VsSession", "Update");
                        }
                        
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

                        if (!manager.IsTransactionStarted)
                        {
                            
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
            private bool _PostNonTransaction(DbManagerProxy manager, Vector obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.FFPresenter != null)
                    {
                        obj.FFPresenter.MarkToDelete();
                        if (!FFPresenterAccessor.Post(manager, obj.FFPresenter, true))
                            return false;
                    }
                                    
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
                //obj.AcceptChanges();
                
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
        
      
            protected ValidationModelException ChainsValidate(Vector obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<Vector>(obj, "datIdentifiedDateTime", c => true, 
      obj.datIdentifiedDateTime,
      obj.GetType(),
      false, listdatIdentifiedDateTime => {
    listdatIdentifiedDateTime.Add(
    new ChainsValidatorDateTime<Vector>(obj, "datCollectionDateTime", c => true, 
      obj.datCollectionDateTime,
      obj.GetType(),
      false, listdatCollectionDateTime => {
    listdatCollectionDateTime.Add(
    new ChainsValidatorDateTime<Vector>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }));
  
    }).Process();
  
    new ChainsValidatorDateTime<Vector>(obj, "datIdentifiedDateTime", c => true, 
      obj.datIdentifiedDateTime,
      obj.GetType(),
      false, listdatIdentifiedDateTime => {
    listdatIdentifiedDateTime.Add(
    new ChainsValidatorDateTime<Vector>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }).Process();
  
    new ChainsValidatorDateTime<Vector>(obj, "datStartDateFromSession", c => true, 
      obj.datStartDateFromSession,
      obj.GetType(),
      false, listdatStartDateFromSession => {
    listdatStartDateFromSession.Add(
    new ChainsValidatorDateTime<Vector>(obj, "datCollectionDateTime", c => true, 
      obj.datCollectionDateTime,
      obj.GetType(),
      false, listdatCollectionDateTime => {
    
    }));
  
    }).Process();
  
                }
                catch(ValidationModelException ex)
                {
                    return ex;
                }
                
                return null;
            }
            protected bool ChainsValidate(Vector obj, bool bRethrowException)
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
                return Validate(manager, obj as Vector, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Vector obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "VectorType", "VectorType","idfsVectorType",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.VectorType);
            
                (new RequiredValidator( "idfCollectedByOffice", "CollectedByOffice","VectorSample.idfFieldCollectedByOffice",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfCollectedByOffice);
            
                (new RequiredValidator( "strCollectedByOffice", "strCollectedByOffice","VectorSample.idfFieldCollectedByOffice",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.strCollectedByOffice);
            
                (new RequiredValidator( "datCollectionDateTime", "datCollectionDateTime","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.datCollectionDateTime);
            
                (new RequiredValidator( "idfVectorSurveillanceSession", "idfVectorSurveillanceSession","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfVectorSurveillanceSession);
            
                (new RequiredValidator( "idfsVectorType", "strVectorType","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsVectorType);
            
                (new RequiredValidator( "idfsVectorSubType", "VectorSubType","strHerdSpecies",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsVectorSubType);
            
                (new RequiredValidator( "intQuantity", "intQuantity","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.intQuantity);
            
                (new RequiredValidator( "Location.LocationDisplayName", "Location.LocationDisplayName","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.Location.LocationDisplayName);
            
                (new RequiredValidator( "Location.strReadOnlyAdaptiveFullName", "Location.strReadOnlyAdaptiveFullName","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.Location.strReadOnlyAdaptiveFullName);
            
                CustomValidations(obj);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Location != null)
                            LocationAccessor.Validate(manager, obj.Location, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Samples != null)
                            foreach (var i in obj.Samples.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                SamplesAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FieldTests != null)
                            foreach (var i in obj.FieldTests.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                FieldTestsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FFPresenter != null)
                            FFPresenterAccessor.Validate(manager, obj.FFPresenter, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
            
            private void _SetupRequired(Vector obj)
            {
            
                obj
                    .AddRequired("VectorType", c => true);
                    
                obj
                    .AddRequired("CollectedByOffice", c => true);
                    
                  obj
                    .AddRequired("CollectedByOffice", c => true);
                
                obj
                    .AddRequired("strCollectedByOffice", c => true);
                    
                obj
                    .AddRequired("datCollectionDateTime", c => true);
                    
                obj
                    .AddRequired("idfVectorSurveillanceSession", c => true);
                    
                obj
                    .AddRequired("strVectorType", c => true);
                    
                  obj
                    .AddRequired("VectorType", c => true);
                
                obj
                    .AddRequired("VectorSubType", c => true);
                    
                  obj
                    .AddRequired("VectorSubType", c => true);
                
                obj
                    .AddRequired("intQuantity", c => true);
                    
                obj
                    .Location
                        .AddRequired("LocationDisplayName", c => true);
                        
                obj
                    .Location
                        .AddRequired("strReadOnlyAdaptiveFullName", c => true);
                        
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
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
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
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Vector, bool>> RequiredByField = new Dictionary<string, Func<Vector, bool>>();
            public static Dictionary<string, Func<Vector, bool>> RequiredByProperty = new Dictionary<string, Func<Vector, bool>>();
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
                Sizes.Add(_str_strCollectedByPerson, 400);
                Sizes.Add(_str_strCollectionMethod, 2000);
                Sizes.Add(_str_strBasisOfRecord, 2000);
                Sizes.Add(_str_strSex, 2000);
                Sizes.Add(_str_strIdentifiedByOffice, 2000);
                Sizes.Add(_str_strIdentifiedByPerson, 400);
                Sizes.Add(_str_strIdentificationMethod, 2000);
                Sizes.Add(_str_strDayPeriod, 2000);
                Sizes.Add(_str_strSpecies, 2000);
                Sizes.Add(_str_strComment, 500);
                Sizes.Add(_str_strEctoparasitesCollected, 2000);
                if (!RequiredByField.ContainsKey("VectorType")) RequiredByField.Add("VectorType", c => true);
                if (!RequiredByProperty.ContainsKey("VectorType")) RequiredByProperty.Add("VectorType", c => true);
                
                if (!RequiredByField.ContainsKey("idfCollectedByOffice")) RequiredByField.Add("idfCollectedByOffice", c => true);
                if (!RequiredByProperty.ContainsKey("CollectedByOffice")) RequiredByProperty.Add("CollectedByOffice", c => true);
                
                if (!RequiredByField.ContainsKey("strCollectedByOffice")) RequiredByField.Add("strCollectedByOffice", c => true);
                if (!RequiredByProperty.ContainsKey("strCollectedByOffice")) RequiredByProperty.Add("strCollectedByOffice", c => true);
                
                if (!RequiredByField.ContainsKey("datCollectionDateTime")) RequiredByField.Add("datCollectionDateTime", c => true);
                if (!RequiredByProperty.ContainsKey("datCollectionDateTime")) RequiredByProperty.Add("datCollectionDateTime", c => true);
                
                if (!RequiredByField.ContainsKey("idfVectorSurveillanceSession")) RequiredByField.Add("idfVectorSurveillanceSession", c => true);
                if (!RequiredByProperty.ContainsKey("idfVectorSurveillanceSession")) RequiredByProperty.Add("idfVectorSurveillanceSession", c => true);
                
                if (!RequiredByField.ContainsKey("idfsVectorType")) RequiredByField.Add("idfsVectorType", c => true);
                if (!RequiredByProperty.ContainsKey("strVectorType")) RequiredByProperty.Add("strVectorType", c => true);
                
                if (!RequiredByField.ContainsKey("idfsVectorSubType")) RequiredByField.Add("idfsVectorSubType", c => true);
                if (!RequiredByProperty.ContainsKey("VectorSubType")) RequiredByProperty.Add("VectorSubType", c => true);
                
                if (!RequiredByField.ContainsKey("intQuantity")) RequiredByField.Add("intQuantity", c => true);
                if (!RequiredByProperty.ContainsKey("intQuantity")) RequiredByProperty.Add("intQuantity", c => true);
                
                if (!RequiredByField.ContainsKey("Location.LocationDisplayName")) RequiredByField.Add("Location.LocationDisplayName", c => true);
                if (!RequiredByProperty.ContainsKey("Location.LocationDisplayName")) RequiredByProperty.Add("Location.LocationDisplayName", c => true);
                
                if (!RequiredByField.ContainsKey("Location.strReadOnlyAdaptiveFullName")) RequiredByField.Add("Location.strReadOnlyAdaptiveFullName", c => true);
                if (!RequiredByProperty.ContainsKey("Location.strReadOnlyAdaptiveFullName")) RequiredByProperty.Add("Location.strReadOnlyAdaptiveFullName", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfVector,
                    _str_idfVector, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorID,
                    "Vector.strVectorID", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFieldVectorID,
                    "Vector.strFieldVectorID", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRegion,
                    _str_strRegion, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRayon,
                    _str_strRayon, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSettlement,
                    "Vector.strSettlement", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_dblLongitude,
                    "VsSessionListItem.dblLongitude", "{0:F5}", false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_dblLatitude,
                    "VsSessionListItem.dblLatitude", "{0:F5}", false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intElevation,
                    _str_intElevation, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSurrounding,
                    _str_strSurrounding, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datCollectionDateTime,
                    _str_datCollectionDateTime, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDayPeriod,
                    _str_strDayPeriod, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCollectedByPerson,
                    "Vector.idfFieldCollectedByPerson", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCollectedByOffice,
                    "VectorSample.idfFieldCollectedByOffice", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpecies,
                    _str_strSpecies, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intQuantity,
                    _str_intQuantity, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSex,
                    "idfsAnimalGender", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strEctoparasitesCollected,
                    _str_strEctoparasitesCollected, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strHostVector,
                    "idfHostVector", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCollectionMethod,
                    _str_strCollectionMethod, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBasisOfRecord,
                    _str_strBasisOfRecord, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strGEOReferenceSources,
                    _str_strGEOReferenceSources, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strIdentifiedByPerson,
                    _str_strIdentifiedByPerson, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strIdentifiedByOffice,
                    _str_strIdentifiedByOffice, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datIdentifiedDateTime,
                    _str_datIdentifiedDateTime, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strIdentificationMethod,
                    _str_strIdentificationMethod, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strVectorSpecificData,
                    _str_strVectorSpecificData, null, false, true, true, true, true, null
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
                      true,
                    null,
                    null,
                    null,
                    null,
                    (c, a, p, b) => c != null ? !c.ReadOnly : true,
                    true,
                    false,
                    "vector.vectorDetailOk",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Cancel",
                    ActionTypes.Cancel,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.Win
                        ),
                      false,
                    null,
                    null,
                    null,
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
                      true,
                    null,
                    null,
                    (a, p, b) => a != null ? (a.Environment != null ? !a.Environment.ReadOnly : !a.ReadOnly) : true,
                    null,
                    null,
                    false,
                    false,
                    "Vector.vectorDetailCancel",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "CopyVector",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).CopyVector(manager, (Vector)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCopy_Id",
                        "",
                        /*from BvMessages*/"tooltipAdd_Id",
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
                    (c, p, b) => c != null && !c.Key.Equals(PredefinedObjectId.FakeListObject) && (c.Environment != null ? !c.Environment.ReadOnly : !c.ReadOnly),
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
                    "VectorCancel",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).VectorCancel(manager, (Vector)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.Web
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    "vector.vectorDetailCancel",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "ActionEditVector",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionEditVector(manager, (Vector)c, pars),
                        
                    null,
                    
                    null,
                      true,
                    null,
                    null,
                    null,
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
    public abstract partial class VectorItem : 
        EditableObject<VectorItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [LocalizedDisplayName(_str_idfVector)]
        [MapField(_str_idfVector)]
        public abstract Int64 idfVector { get; set; }
        protected Int64 idfVector_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfVector).OriginalValue; } }
        protected Int64 idfVector_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfVector).PreviousValue; } }
                
        [MapField(_str_idfVectorSurveillanceSession), NonUpdatable, PrimaryKey]
        public abstract Int64 idfVectorSurveillanceSession { get; set; }
                
        [LocalizedDisplayName(_str_idfsVectorType)]
        [MapField(_str_idfsVectorType)]
        public abstract Int64 idfsVectorType { get; set; }
        protected Int64 idfsVectorType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).OriginalValue; } }
        protected Int64 idfsVectorType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strVectorType)]
        [MapField(_str_strVectorType)]
        public abstract String strVectorType { get; set; }
        protected String strVectorType_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).OriginalValue; } }
        protected String strVectorType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsVectorSubType)]
        [MapField(_str_idfsVectorSubType)]
        public abstract Int64 idfsVectorSubType { get; set; }
        protected Int64 idfsVectorSubType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSubType).OriginalValue; } }
        protected Int64 idfsVectorSubType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsVectorSubType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSpecies)]
        [MapField(_str_strSpecies)]
        public abstract String strSpecies { get; set; }
        protected String strSpecies_Original { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).OriginalValue; } }
        protected String strSpecies_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSpecies).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strVectorID)]
        [MapField(_str_strVectorID)]
        public abstract String strVectorID { get; set; }
        protected String strVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).OriginalValue; } }
        protected String strVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strVectorID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFieldVectorID)]
        [MapField(_str_strFieldVectorID)]
        public abstract String strFieldVectorID { get; set; }
        protected String strFieldVectorID_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldVectorID).OriginalValue; } }
        protected String strFieldVectorID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldVectorID).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<VectorItem, object> _get_func;
            internal Action<VectorItem, string> _set_func;
            internal Action<VectorItem, VectorItem, CompareModel, DbManagerProxy> _compare_func;
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
              _name = _str_idfVector, _formname = _str_idfVector, _type = "Int64",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVector != newval) o.idfVector = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) 
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, o.ObjectIdent2 + _str_idfVector, o.ObjectIdent3 + _str_idfVector, "Int64", 
                    o.idfVector == null ? "" : o.idfVector.ToString(),                  
                  o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _formname = _str_idfVectorSurveillanceSession, _type = "Int64",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVectorSurveillanceSession != newval) o.idfVectorSurveillanceSession = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) 
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, o.ObjectIdent2 + _str_idfVectorSurveillanceSession, o.ObjectIdent3 + _str_idfVectorSurveillanceSession, "Int64", 
                    o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(),                  
                  o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession)); 
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
              _name = _str_strVectorType, _formname = _str_strVectorType, _type = "String",
              _get_func = o => o.strVectorType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strVectorType != newval) o.strVectorType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strVectorType != c.strVectorType || o.IsRIRPropChanged(_str_strVectorType, c)) 
                  m.Add(_str_strVectorType, o.ObjectIdent + _str_strVectorType, o.ObjectIdent2 + _str_strVectorType, o.ObjectIdent3 + _str_strVectorType, "String", 
                    o.strVectorType == null ? "" : o.strVectorType.ToString(),                  
                  o.IsReadOnly(_str_strVectorType), o.IsInvisible(_str_strVectorType), o.IsRequired(_str_strVectorType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsVectorSubType, _formname = _str_idfsVectorSubType, _type = "Int64",
              _get_func = o => o.idfsVectorSubType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsVectorSubType != newval) o.idfsVectorSubType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsVectorSubType != c.idfsVectorSubType || o.IsRIRPropChanged(_str_idfsVectorSubType, c)) 
                  m.Add(_str_idfsVectorSubType, o.ObjectIdent + _str_idfsVectorSubType, o.ObjectIdent2 + _str_idfsVectorSubType, o.ObjectIdent3 + _str_idfsVectorSubType, "Int64", 
                    o.idfsVectorSubType == null ? "" : o.idfsVectorSubType.ToString(),                  
                  o.IsReadOnly(_str_idfsVectorSubType), o.IsInvisible(_str_idfsVectorSubType), o.IsRequired(_str_idfsVectorSubType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSpecies, _formname = _str_strSpecies, _type = "String",
              _get_func = o => o.strSpecies,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSpecies != newval) o.strSpecies = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSpecies != c.strSpecies || o.IsRIRPropChanged(_str_strSpecies, c)) 
                  m.Add(_str_strSpecies, o.ObjectIdent + _str_strSpecies, o.ObjectIdent2 + _str_strSpecies, o.ObjectIdent3 + _str_strSpecies, "String", 
                    o.strSpecies == null ? "" : o.strSpecies.ToString(),                  
                  o.IsReadOnly(_str_strSpecies), o.IsInvisible(_str_strSpecies), o.IsRequired(_str_strSpecies)); 
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
              _name = _str_strFieldVectorID, _formname = _str_strFieldVectorID, _type = "String",
              _get_func = o => o.strFieldVectorID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldVectorID != newval) o.strFieldVectorID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFieldVectorID != c.strFieldVectorID || o.IsRIRPropChanged(_str_strFieldVectorID, c)) 
                  m.Add(_str_strFieldVectorID, o.ObjectIdent + _str_strFieldVectorID, o.ObjectIdent2 + _str_strFieldVectorID, o.ObjectIdent3 + _str_strFieldVectorID, "String", 
                    o.strFieldVectorID == null ? "" : o.strFieldVectorID.ToString(),                  
                  o.IsReadOnly(_str_strFieldVectorID), o.IsInvisible(_str_strFieldVectorID), o.IsRequired(_str_strFieldVectorID)); 
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
            VectorItem obj = (VectorItem)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
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
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as VectorItem;
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
            var ret = base.Clone() as VectorItem;
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
        public object KeyLookup { get { return idfVectorSurveillanceSession; } }
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

        private bool IsRIRPropChanged(string fld, VectorItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, VectorItem c)
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
        

      

        public VectorItem()
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
            
            return ReadOnly;
                
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


        internal Dictionary<string, Func<VectorItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VectorItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VectorItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VectorItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VectorItem, bool>> m_isHiddenPersonalData;
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
        protected bool bNeedLookupRemove;
        ~VectorItem()
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
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<VectorItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<VectorItem>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfVectorSurveillanceSession"; } }
            #endregion
        
            public delegate void on_action(VectorItem obj);
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

            

            public List<VectorItem> _SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfVectorSurveillanceSession
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<VectorItem> _SelectListInternal(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
                VectorItem _obj = null;
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VectorItem obj, bool bCloning = false)
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

    

            private VectorItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                VectorItem obj = null;
                try
                {
                    obj = VectorItem.CreateInstance();
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
                    throw DbModelException.Create(obj, e);
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
            public VectorItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
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
    

            internal void _LoadLookups(DbManagerProxy manager, VectorItem obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(VectorItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(VectorItem obj, bool bRethrowException)
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
                return Validate(manager, obj as VectorItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VectorItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
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
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
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
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VectorItem, bool>> RequiredByField = new Dictionary<string, Func<VectorItem, bool>>();
            public static Dictionary<string, Func<VectorItem, bool>> RequiredByProperty = new Dictionary<string, Func<VectorItem, bool>>();
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
    public abstract partial class CopyDialogWindowItem : 
        EditableObject<CopyDialogWindowItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<CopyDialogWindowItem, object> _get_func;
            internal Action<CopyDialogWindowItem, string> _set_func;
            internal Action<CopyDialogWindowItem, CopyDialogWindowItem, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_blnNeedCopyGeneralData = "blnNeedCopyGeneralData";
        internal const string _str_blnNeedCopyFF = "blnNeedCopyFF";
        internal const string _str_blnNeedCopySamples = "blnNeedCopySamples";
        internal const string _str_blnNeedCopyFT = "blnNeedCopyFT";
        internal const string _str_idfVectorSurveillanceSession = "idfVectorSurveillanceSession";
        internal const string _str_idfVector = "idfVector";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_blnNeedCopyGeneralData, _formname = _str_blnNeedCopyGeneralData, _type = "bool",
              _get_func = o => o.blnNeedCopyGeneralData,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnNeedCopyGeneralData != newval) o.blnNeedCopyGeneralData = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.blnNeedCopyGeneralData != c.blnNeedCopyGeneralData || o.IsRIRPropChanged(_str_blnNeedCopyGeneralData, c)) {
                  m.Add(_str_blnNeedCopyGeneralData, o.ObjectIdent + _str_blnNeedCopyGeneralData, o.ObjectIdent2 + _str_blnNeedCopyGeneralData, o.ObjectIdent3 + _str_blnNeedCopyGeneralData,  "bool", 
                    o.blnNeedCopyGeneralData == null ? "" : o.blnNeedCopyGeneralData.ToString(),                  
                    o.IsReadOnly(_str_blnNeedCopyGeneralData), o.IsInvisible(_str_blnNeedCopyGeneralData), o.IsRequired(_str_blnNeedCopyGeneralData));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_blnNeedCopyFF, _formname = _str_blnNeedCopyFF, _type = "bool",
              _get_func = o => o.blnNeedCopyFF,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnNeedCopyFF != newval) o.blnNeedCopyFF = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.blnNeedCopyFF != c.blnNeedCopyFF || o.IsRIRPropChanged(_str_blnNeedCopyFF, c)) {
                  m.Add(_str_blnNeedCopyFF, o.ObjectIdent + _str_blnNeedCopyFF, o.ObjectIdent2 + _str_blnNeedCopyFF, o.ObjectIdent3 + _str_blnNeedCopyFF,  "bool", 
                    o.blnNeedCopyFF == null ? "" : o.blnNeedCopyFF.ToString(),                  
                    o.IsReadOnly(_str_blnNeedCopyFF), o.IsInvisible(_str_blnNeedCopyFF), o.IsRequired(_str_blnNeedCopyFF));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_blnNeedCopySamples, _formname = _str_blnNeedCopySamples, _type = "bool",
              _get_func = o => o.blnNeedCopySamples,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnNeedCopySamples != newval) o.blnNeedCopySamples = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.blnNeedCopySamples != c.blnNeedCopySamples || o.IsRIRPropChanged(_str_blnNeedCopySamples, c)) {
                  m.Add(_str_blnNeedCopySamples, o.ObjectIdent + _str_blnNeedCopySamples, o.ObjectIdent2 + _str_blnNeedCopySamples, o.ObjectIdent3 + _str_blnNeedCopySamples,  "bool", 
                    o.blnNeedCopySamples == null ? "" : o.blnNeedCopySamples.ToString(),                  
                    o.IsReadOnly(_str_blnNeedCopySamples), o.IsInvisible(_str_blnNeedCopySamples), o.IsRequired(_str_blnNeedCopySamples));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_blnNeedCopyFT, _formname = _str_blnNeedCopyFT, _type = "bool",
              _get_func = o => o.blnNeedCopyFT,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnNeedCopyFT != newval) o.blnNeedCopyFT = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.blnNeedCopyFT != c.blnNeedCopyFT || o.IsRIRPropChanged(_str_blnNeedCopyFT, c)) {
                  m.Add(_str_blnNeedCopyFT, o.ObjectIdent + _str_blnNeedCopyFT, o.ObjectIdent2 + _str_blnNeedCopyFT, o.ObjectIdent3 + _str_blnNeedCopyFT,  "bool", 
                    o.blnNeedCopyFT == null ? "" : o.blnNeedCopyFT.ToString(),                  
                    o.IsReadOnly(_str_blnNeedCopyFT), o.IsInvisible(_str_blnNeedCopyFT), o.IsRequired(_str_blnNeedCopyFT));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfVectorSurveillanceSession, _formname = _str_idfVectorSurveillanceSession, _type = "long",
              _get_func = o => o.idfVectorSurveillanceSession,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVectorSurveillanceSession != newval) o.idfVectorSurveillanceSession = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfVectorSurveillanceSession != c.idfVectorSurveillanceSession || o.IsRIRPropChanged(_str_idfVectorSurveillanceSession, c)) {
                  m.Add(_str_idfVectorSurveillanceSession, o.ObjectIdent + _str_idfVectorSurveillanceSession, o.ObjectIdent2 + _str_idfVectorSurveillanceSession, o.ObjectIdent3 + _str_idfVectorSurveillanceSession,  "long", 
                    o.idfVectorSurveillanceSession == null ? "" : o.idfVectorSurveillanceSession.ToString(),                  
                    o.IsReadOnly(_str_idfVectorSurveillanceSession), o.IsInvisible(_str_idfVectorSurveillanceSession), o.IsRequired(_str_idfVectorSurveillanceSession));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfVector, _formname = _str_idfVector, _type = "long",
              _get_func = o => o.idfVector,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVector != newval) o.idfVector = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfVector != c.idfVector || o.IsRIRPropChanged(_str_idfVector, c)) {
                  m.Add(_str_idfVector, o.ObjectIdent + _str_idfVector, o.ObjectIdent2 + _str_idfVector, o.ObjectIdent3 + _str_idfVector,  "long", 
                    o.idfVector == null ? "" : o.idfVector.ToString(),                  
                    o.IsReadOnly(_str_idfVector), o.IsInvisible(_str_idfVector), o.IsRequired(_str_idfVector));
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
            CopyDialogWindowItem obj = (CopyDialogWindowItem)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<CopyDialogWindowItem, string>(c => "VsSession_" + c.idfVectorSurveillanceSession + "_")(this); }
            
        }
        
          [LocalizedDisplayName(_str_blnNeedCopyGeneralData)]
        public bool blnNeedCopyGeneralData
        {
            get { return m_blnNeedCopyGeneralData; }
            set { if (m_blnNeedCopyGeneralData != value) { m_blnNeedCopyGeneralData = value; OnPropertyChanged(_str_blnNeedCopyGeneralData); } }
        }
        private bool m_blnNeedCopyGeneralData;
        
          [LocalizedDisplayName(_str_blnNeedCopyFF)]
        public bool blnNeedCopyFF
        {
            get { return m_blnNeedCopyFF; }
            set { if (m_blnNeedCopyFF != value) { m_blnNeedCopyFF = value; OnPropertyChanged(_str_blnNeedCopyFF); } }
        }
        private bool m_blnNeedCopyFF;
        
          [LocalizedDisplayName(_str_blnNeedCopySamples)]
        public bool blnNeedCopySamples
        {
            get { return m_blnNeedCopySamples; }
            set { if (m_blnNeedCopySamples != value) { m_blnNeedCopySamples = value; OnPropertyChanged(_str_blnNeedCopySamples); } }
        }
        private bool m_blnNeedCopySamples;
        
          [LocalizedDisplayName(_str_blnNeedCopyFT)]
        public bool blnNeedCopyFT
        {
            get { return m_blnNeedCopyFT; }
            set { if (m_blnNeedCopyFT != value) { m_blnNeedCopyFT = value; OnPropertyChanged(_str_blnNeedCopyFT); } }
        }
        private bool m_blnNeedCopyFT;
        
          [LocalizedDisplayName(_str_idfVectorSurveillanceSession)]
        public long idfVectorSurveillanceSession
        {
            get { return m_idfVectorSurveillanceSession; }
            set { if (m_idfVectorSurveillanceSession != value) { m_idfVectorSurveillanceSession = value; OnPropertyChanged(_str_idfVectorSurveillanceSession); } }
        }
        private long m_idfVectorSurveillanceSession;
        
          [LocalizedDisplayName(_str_idfVector)]
        public long idfVector
        {
            get { return m_idfVector; }
            set { if (m_idfVector != value) { m_idfVector = value; OnPropertyChanged(_str_idfVector); } }
        }
        private long m_idfVector;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "CopyDialogWindowItem";

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
            var ret = base.Clone() as CopyDialogWindowItem;
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
            var ret = base.Clone() as CopyDialogWindowItem;
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
        public CopyDialogWindowItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as CopyDialogWindowItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return ID; } }
        public string KeyName { get { return "ID"; } }
        public object KeyLookup { get { return ID; } }
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

        private bool IsRIRPropChanged(string fld, CopyDialogWindowItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, CopyDialogWindowItem c)
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
        

      

        public CopyDialogWindowItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(CopyDialogWindowItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(CopyDialogWindowItem_PropertyChanged);
        }
        private void CopyDialogWindowItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as CopyDialogWindowItem).Changed(e.PropertyName);
            
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
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            CopyDialogWindowItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            CopyDialogWindowItem obj = this;
            
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

    
        private static string[] readonly_names1 = "blnNeedCopyGeneralData".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<CopyDialogWindowItem, bool>(c => true)(this);
            
            return ReadOnly || new Func<CopyDialogWindowItem, bool>(c => c.ReadOnly)(this);
                
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


        internal Dictionary<string, Func<CopyDialogWindowItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<CopyDialogWindowItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<CopyDialogWindowItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<CopyDialogWindowItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<CopyDialogWindowItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<CopyDialogWindowItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<CopyDialogWindowItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~CopyDialogWindowItem()
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
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<CopyDialogWindowItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<CopyDialogWindowItem>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "ID"; } }
            #endregion
        
            public delegate void on_action(CopyDialogWindowItem obj);
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
            
        
            public virtual List<CopyDialogWindowItem> SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                )
            {
                return _SelectList(manager
                    , idfVectorSurveillanceSession
                    , delegate(CopyDialogWindowItem obj)
                        {
                        }
                    , delegate(CopyDialogWindowItem obj)
                        {
                        }
                    );
            }

            

            public List<CopyDialogWindowItem> _SelectList(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfVectorSurveillanceSession
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<CopyDialogWindowItem> _SelectListInternal(DbManagerProxy manager
                , Int64? idfVectorSurveillanceSession
                , on_action loading, on_action loaded
                )
            {
                CopyDialogWindowItem _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<CopyDialogWindowItem> objs = new List<CopyDialogWindowItem>();
                    sets[0] = new MapResultSet(typeof(CopyDialogWindowItem), objs);
                    
                    manager
                        .SetSpCommand("spVector_SelectDetail"
                            , manager.Parameter("@idfVectorSurveillanceSession", idfVectorSurveillanceSession)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, CopyDialogWindowItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, CopyDialogWindowItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private CopyDialogWindowItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                CopyDialogWindowItem obj = null;
                try
                {
                    obj = CopyDialogWindowItem.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.blnNeedCopyGeneralData = new Func<CopyDialogWindowItem, bool>(c => true)(obj);
                obj.blnNeedCopyFF = new Func<CopyDialogWindowItem, bool>(c => false)(obj);
                obj.blnNeedCopySamples = new Func<CopyDialogWindowItem, bool>(c => false)(obj);
                obj.blnNeedCopyFT = new Func<CopyDialogWindowItem, bool>(c => false)(obj);
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
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public CopyDialogWindowItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public CopyDialogWindowItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public CopyDialogWindowItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(CopyDialogWindowItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(CopyDialogWindowItem obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, CopyDialogWindowItem obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(CopyDialogWindowItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(CopyDialogWindowItem obj, bool bRethrowException)
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
                return Validate(manager, obj as CopyDialogWindowItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, CopyDialogWindowItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(CopyDialogWindowItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(CopyDialogWindowItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as CopyDialogWindowItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as CopyDialogWindowItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "CopyDialogWindowItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
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
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<CopyDialogWindowItem, bool>> RequiredByField = new Dictionary<string, Func<CopyDialogWindowItem, bool>>();
            public static Dictionary<string, Func<CopyDialogWindowItem, bool>> RequiredByProperty = new Dictionary<string, Func<CopyDialogWindowItem, bool>>();
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
                
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Close,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelect_Id",
                        "",
                        /*from BvMessages*/"tooltipSelect_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
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
                    "Cancel",
                    ActionTypes.Close,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    "vector.vectorDetailCancel",
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
	