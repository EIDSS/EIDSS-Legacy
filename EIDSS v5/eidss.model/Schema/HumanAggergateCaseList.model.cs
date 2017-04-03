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
    public abstract partial class HumanAggregateCaseListItem : 
        EditableObject<HumanAggregateCaseListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfAggrCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfAggrCase { get; set; }
                
        [LocalizedDisplayName(_str_idfsAggrCaseType)]
        [MapField(_str_idfsAggrCaseType)]
        public abstract Int64 idfsAggrCaseType { get; set; }
        #if MONO
        protected Int64 idfsAggrCaseType_Original { get { return idfsAggrCaseType; } }
        protected Int64 idfsAggrCaseType_Previous { get { return idfsAggrCaseType; } }
        #else
        protected Int64 idfsAggrCaseType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAggrCaseType).OriginalValue; } }
        protected Int64 idfsAggrCaseType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAggrCaseType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsAdministrativeUnit)]
        [MapField(_str_idfsAdministrativeUnit)]
        public abstract Int64 idfsAdministrativeUnit { get; set; }
        #if MONO
        protected Int64 idfsAdministrativeUnit_Original { get { return idfsAdministrativeUnit; } }
        protected Int64 idfsAdministrativeUnit_Previous { get { return idfsAdministrativeUnit; } }
        #else
        protected Int64 idfsAdministrativeUnit_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAdministrativeUnit).OriginalValue; } }
        protected Int64 idfsAdministrativeUnit_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAdministrativeUnit).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfReceivedByOffice)]
        [MapField(_str_idfReceivedByOffice)]
        public abstract Int64 idfReceivedByOffice { get; set; }
        #if MONO
        protected Int64 idfReceivedByOffice_Original { get { return idfReceivedByOffice; } }
        protected Int64 idfReceivedByOffice_Previous { get { return idfReceivedByOffice; } }
        #else
        protected Int64 idfReceivedByOffice_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfReceivedByOffice).OriginalValue; } }
        protected Int64 idfReceivedByOffice_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfReceivedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfReceivedByPerson)]
        [MapField(_str_idfReceivedByPerson)]
        public abstract Int64 idfReceivedByPerson { get; set; }
        #if MONO
        protected Int64 idfReceivedByPerson_Original { get { return idfReceivedByPerson; } }
        protected Int64 idfReceivedByPerson_Previous { get { return idfReceivedByPerson; } }
        #else
        protected Int64 idfReceivedByPerson_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfReceivedByPerson).OriginalValue; } }
        protected Int64 idfReceivedByPerson_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfReceivedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfSentByOffice)]
        [MapField(_str_idfSentByOffice)]
        public abstract Int64 idfSentByOffice { get; set; }
        #if MONO
        protected Int64 idfSentByOffice_Original { get { return idfSentByOffice; } }
        protected Int64 idfSentByOffice_Previous { get { return idfSentByOffice; } }
        #else
        protected Int64 idfSentByOffice_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfSentByOffice).OriginalValue; } }
        protected Int64 idfSentByOffice_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfSentByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfSentByPerson)]
        [MapField(_str_idfSentByPerson)]
        public abstract Int64 idfSentByPerson { get; set; }
        #if MONO
        protected Int64 idfSentByPerson_Original { get { return idfSentByPerson; } }
        protected Int64 idfSentByPerson_Previous { get { return idfSentByPerson; } }
        #else
        protected Int64 idfSentByPerson_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfSentByPerson).OriginalValue; } }
        protected Int64 idfSentByPerson_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfSentByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfEnteredByOffice)]
        [MapField(_str_idfEnteredByOffice)]
        public abstract Int64 idfEnteredByOffice { get; set; }
        #if MONO
        protected Int64 idfEnteredByOffice_Original { get { return idfEnteredByOffice; } }
        protected Int64 idfEnteredByOffice_Previous { get { return idfEnteredByOffice; } }
        #else
        protected Int64 idfEnteredByOffice_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfEnteredByOffice).OriginalValue; } }
        protected Int64 idfEnteredByOffice_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfEnteredByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfEnteredByPerson)]
        [MapField(_str_idfEnteredByPerson)]
        public abstract Int64 idfEnteredByPerson { get; set; }
        #if MONO
        protected Int64 idfEnteredByPerson_Original { get { return idfEnteredByPerson; } }
        protected Int64 idfEnteredByPerson_Previous { get { return idfEnteredByPerson; } }
        #else
        protected Int64 idfEnteredByPerson_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfEnteredByPerson).OriginalValue; } }
        protected Int64 idfEnteredByPerson_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfEnteredByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datReceivedByDate)]
        [MapField(_str_datReceivedByDate)]
        public abstract DateTime? datReceivedByDate { get; set; }
        #if MONO
        protected DateTime? datReceivedByDate_Original { get { return datReceivedByDate; } }
        protected DateTime? datReceivedByDate_Previous { get { return datReceivedByDate; } }
        #else
        protected DateTime? datReceivedByDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReceivedByDate).OriginalValue; } }
        protected DateTime? datReceivedByDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReceivedByDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datSentByDate)]
        [MapField(_str_datSentByDate)]
        public abstract DateTime? datSentByDate { get; set; }
        #if MONO
        protected DateTime? datSentByDate_Original { get { return datSentByDate; } }
        protected DateTime? datSentByDate_Previous { get { return datSentByDate; } }
        #else
        protected DateTime? datSentByDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSentByDate).OriginalValue; } }
        protected DateTime? datSentByDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSentByDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datEnteredByDate)]
        [MapField(_str_datEnteredByDate)]
        public abstract DateTime? datEnteredByDate { get; set; }
        #if MONO
        protected DateTime? datEnteredByDate_Original { get { return datEnteredByDate; } }
        protected DateTime? datEnteredByDate_Previous { get { return datEnteredByDate; } }
        #else
        protected DateTime? datEnteredByDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredByDate).OriginalValue; } }
        protected DateTime? datEnteredByDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredByDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datStartDate)]
        [MapField(_str_datStartDate)]
        public abstract DateTime? datStartDate { get; set; }
        #if MONO
        protected DateTime? datStartDate_Original { get { return datStartDate; } }
        protected DateTime? datStartDate_Previous { get { return datStartDate; } }
        #else
        protected DateTime? datStartDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime? datStartDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datFinishDate)]
        [MapField(_str_datFinishDate)]
        public abstract DateTime? datFinishDate { get; set; }
        #if MONO
        protected DateTime? datFinishDate_Original { get { return datFinishDate; } }
        protected DateTime? datFinishDate_Previous { get { return datFinishDate; } }
        #else
        protected DateTime? datFinishDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFinishDate).OriginalValue; } }
        protected DateTime? datFinishDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFinishDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strCaseID")]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        #if MONO
        protected String strCaseID_Original { get { return strCaseID; } }
        protected String strCaseID_Previous { get { return strCaseID; } }
        #else
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsAreaType)]
        [MapField(_str_idfsAreaType)]
        public abstract Int64? idfsAreaType { get; set; }
        #if MONO
        protected Int64? idfsAreaType_Original { get { return idfsAreaType; } }
        protected Int64? idfsAreaType_Previous { get { return idfsAreaType; } }
        #else
        protected Int64? idfsAreaType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAreaType).OriginalValue; } }
        protected Int64? idfsAreaType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsAreaType).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strCountry)]
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
                
        [LocalizedDisplayName("idfsRegion")]
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
                
        [LocalizedDisplayName("idfsRayon")]
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
                
        [LocalizedDisplayName("strSettlement")]
        [MapField(_str_strSettlement)]
        public abstract String strSettlement { get; set; }
        #if MONO
        protected String strSettlement_Original { get { return strSettlement; } }
        protected String strSettlement_Previous { get { return strSettlement; } }
        #else
        protected String strSettlement_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).OriginalValue; } }
        protected String strSettlement_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsPeriodType)]
        [MapField(_str_idfsPeriodType)]
        public abstract Int64? idfsPeriodType { get; set; }
        #if MONO
        protected Int64? idfsPeriodType_Original { get { return idfsPeriodType; } }
        protected Int64? idfsPeriodType_Previous { get { return idfsPeriodType; } }
        #else
        protected Int64? idfsPeriodType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPeriodType).OriginalValue; } }
        protected Int64? idfsPeriodType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsPeriodType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsPeriodType")]
        [MapField(_str_strPeriodName)]
        public abstract String strPeriodName { get; set; }
        #if MONO
        protected String strPeriodName_Original { get { return strPeriodName; } }
        protected String strPeriodName_Previous { get { return strPeriodName; } }
        #else
        protected String strPeriodName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPeriodName).OriginalValue; } }
        protected String strPeriodName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPeriodName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfCaseObservation)]
        [MapField(_str_idfCaseObservation)]
        public abstract Int64? idfCaseObservation { get; set; }
        #if MONO
        protected Int64? idfCaseObservation_Original { get { return idfCaseObservation; } }
        protected Int64? idfCaseObservation_Previous { get { return idfCaseObservation; } }
        #else
        protected Int64? idfCaseObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCaseObservation).OriginalValue; } }
        protected Int64? idfCaseObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCaseObservation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfDiagnosticObservation)]
        [MapField(_str_idfDiagnosticObservation)]
        public abstract Int64? idfDiagnosticObservation { get; set; }
        #if MONO
        protected Int64? idfDiagnosticObservation_Original { get { return idfDiagnosticObservation; } }
        protected Int64? idfDiagnosticObservation_Previous { get { return idfDiagnosticObservation; } }
        #else
        protected Int64? idfDiagnosticObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDiagnosticObservation).OriginalValue; } }
        protected Int64? idfDiagnosticObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDiagnosticObservation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfProphylacticObservation)]
        [MapField(_str_idfProphylacticObservation)]
        public abstract Int64? idfProphylacticObservation { get; set; }
        #if MONO
        protected Int64? idfProphylacticObservation_Original { get { return idfProphylacticObservation; } }
        protected Int64? idfProphylacticObservation_Previous { get { return idfProphylacticObservation; } }
        #else
        protected Int64? idfProphylacticObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfProphylacticObservation).OriginalValue; } }
        protected Int64? idfProphylacticObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfProphylacticObservation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfSanitaryObservation)]
        [MapField(_str_idfSanitaryObservation)]
        public abstract Int64? idfSanitaryObservation { get; set; }
        #if MONO
        protected Int64? idfSanitaryObservation_Original { get { return idfSanitaryObservation; } }
        protected Int64? idfSanitaryObservation_Previous { get { return idfSanitaryObservation; } }
        #else
        protected Int64? idfSanitaryObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSanitaryObservation).OriginalValue; } }
        protected Int64? idfSanitaryObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSanitaryObservation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsDiagnosticFormTemplate)]
        [MapField(_str_idfsDiagnosticFormTemplate)]
        public abstract Int64? idfsDiagnosticFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsDiagnosticFormTemplate_Original { get { return idfsDiagnosticFormTemplate; } }
        protected Int64? idfsDiagnosticFormTemplate_Previous { get { return idfsDiagnosticFormTemplate; } }
        #else
        protected Int64? idfsDiagnosticFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosticFormTemplate).OriginalValue; } }
        protected Int64? idfsDiagnosticFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosticFormTemplate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsProphylacticFormTemplate)]
        [MapField(_str_idfsProphylacticFormTemplate)]
        public abstract Int64? idfsProphylacticFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsProphylacticFormTemplate_Original { get { return idfsProphylacticFormTemplate; } }
        protected Int64? idfsProphylacticFormTemplate_Previous { get { return idfsProphylacticFormTemplate; } }
        #else
        protected Int64? idfsProphylacticFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsProphylacticFormTemplate).OriginalValue; } }
        protected Int64? idfsProphylacticFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsProphylacticFormTemplate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSanitaryFormTemplate)]
        [MapField(_str_idfsSanitaryFormTemplate)]
        public abstract Int64? idfsSanitaryFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsSanitaryFormTemplate_Original { get { return idfsSanitaryFormTemplate; } }
        protected Int64? idfsSanitaryFormTemplate_Previous { get { return idfsSanitaryFormTemplate; } }
        #else
        protected Int64? idfsSanitaryFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSanitaryFormTemplate).OriginalValue; } }
        protected Int64? idfsSanitaryFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSanitaryFormTemplate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCaseFormTemplate)]
        [MapField(_str_idfsCaseFormTemplate)]
        public abstract Int64? idfsCaseFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsCaseFormTemplate_Original { get { return idfsCaseFormTemplate; } }
        protected Int64? idfsCaseFormTemplate_Previous { get { return idfsCaseFormTemplate; } }
        #else
        protected Int64? idfsCaseFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseFormTemplate).OriginalValue; } }
        protected Int64? idfsCaseFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseFormTemplate).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<HumanAggregateCaseListItem, object> _get_func;
            internal Action<HumanAggregateCaseListItem, string> _set_func;
            internal Action<HumanAggregateCaseListItem, HumanAggregateCaseListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAggrCase = "idfAggrCase";
        internal const string _str_idfsAggrCaseType = "idfsAggrCaseType";
        internal const string _str_idfsAdministrativeUnit = "idfsAdministrativeUnit";
        internal const string _str_idfReceivedByOffice = "idfReceivedByOffice";
        internal const string _str_idfReceivedByPerson = "idfReceivedByPerson";
        internal const string _str_idfSentByOffice = "idfSentByOffice";
        internal const string _str_idfSentByPerson = "idfSentByPerson";
        internal const string _str_idfEnteredByOffice = "idfEnteredByOffice";
        internal const string _str_idfEnteredByPerson = "idfEnteredByPerson";
        internal const string _str_datReceivedByDate = "datReceivedByDate";
        internal const string _str_datSentByDate = "datSentByDate";
        internal const string _str_datEnteredByDate = "datEnteredByDate";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_datFinishDate = "datFinishDate";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_idfsAreaType = "idfsAreaType";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_strCountry = "strCountry";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_strRegion = "strRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_strRayon = "strRayon";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_strSettlement = "strSettlement";
        internal const string _str_idfsPeriodType = "idfsPeriodType";
        internal const string _str_strPeriodName = "strPeriodName";
        internal const string _str_idfCaseObservation = "idfCaseObservation";
        internal const string _str_idfDiagnosticObservation = "idfDiagnosticObservation";
        internal const string _str_idfProphylacticObservation = "idfProphylacticObservation";
        internal const string _str_idfSanitaryObservation = "idfSanitaryObservation";
        internal const string _str_idfsDiagnosticFormTemplate = "idfsDiagnosticFormTemplate";
        internal const string _str_idfsProphylacticFormTemplate = "idfsProphylacticFormTemplate";
        internal const string _str_idfsSanitaryFormTemplate = "idfsSanitaryFormTemplate";
        internal const string _str_idfsCaseFormTemplate = "idfsCaseFormTemplate";
        internal const string _str_StatisticPeriodType = "StatisticPeriodType";
        internal const string _str_StatisticAreaType = "StatisticAreaType";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_Settings = "Settings";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfAggrCase, _type = "Int64",
              _get_func = o => o.idfAggrCase,
              _set_func = (o, val) => { o.idfAggrCase = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAggrCase != c.idfAggrCase || o.IsRIRPropChanged(_str_idfAggrCase, c)) 
                  m.Add(_str_idfAggrCase, o.ObjectIdent + _str_idfAggrCase, "Int64", o.idfAggrCase == null ? "" : o.idfAggrCase.ToString(), o.IsReadOnly(_str_idfAggrCase), o.IsInvisible(_str_idfAggrCase), o.IsRequired(_str_idfAggrCase)); }
              }, 
        
            new field_info {
              _name = _str_idfsAggrCaseType, _type = "Int64",
              _get_func = o => o.idfsAggrCaseType,
              _set_func = (o, val) => { o.idfsAggrCaseType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAggrCaseType != c.idfsAggrCaseType || o.IsRIRPropChanged(_str_idfsAggrCaseType, c)) 
                  m.Add(_str_idfsAggrCaseType, o.ObjectIdent + _str_idfsAggrCaseType, "Int64", o.idfsAggrCaseType == null ? "" : o.idfsAggrCaseType.ToString(), o.IsReadOnly(_str_idfsAggrCaseType), o.IsInvisible(_str_idfsAggrCaseType), o.IsRequired(_str_idfsAggrCaseType)); }
              }, 
        
            new field_info {
              _name = _str_idfsAdministrativeUnit, _type = "Int64",
              _get_func = o => o.idfsAdministrativeUnit,
              _set_func = (o, val) => { o.idfsAdministrativeUnit = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAdministrativeUnit != c.idfsAdministrativeUnit || o.IsRIRPropChanged(_str_idfsAdministrativeUnit, c)) 
                  m.Add(_str_idfsAdministrativeUnit, o.ObjectIdent + _str_idfsAdministrativeUnit, "Int64", o.idfsAdministrativeUnit == null ? "" : o.idfsAdministrativeUnit.ToString(), o.IsReadOnly(_str_idfsAdministrativeUnit), o.IsInvisible(_str_idfsAdministrativeUnit), o.IsRequired(_str_idfsAdministrativeUnit)); }
              }, 
        
            new field_info {
              _name = _str_idfReceivedByOffice, _type = "Int64",
              _get_func = o => o.idfReceivedByOffice,
              _set_func = (o, val) => { o.idfReceivedByOffice = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfReceivedByOffice != c.idfReceivedByOffice || o.IsRIRPropChanged(_str_idfReceivedByOffice, c)) 
                  m.Add(_str_idfReceivedByOffice, o.ObjectIdent + _str_idfReceivedByOffice, "Int64", o.idfReceivedByOffice == null ? "" : o.idfReceivedByOffice.ToString(), o.IsReadOnly(_str_idfReceivedByOffice), o.IsInvisible(_str_idfReceivedByOffice), o.IsRequired(_str_idfReceivedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfReceivedByPerson, _type = "Int64",
              _get_func = o => o.idfReceivedByPerson,
              _set_func = (o, val) => { o.idfReceivedByPerson = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfReceivedByPerson != c.idfReceivedByPerson || o.IsRIRPropChanged(_str_idfReceivedByPerson, c)) 
                  m.Add(_str_idfReceivedByPerson, o.ObjectIdent + _str_idfReceivedByPerson, "Int64", o.idfReceivedByPerson == null ? "" : o.idfReceivedByPerson.ToString(), o.IsReadOnly(_str_idfReceivedByPerson), o.IsInvisible(_str_idfReceivedByPerson), o.IsRequired(_str_idfReceivedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfSentByOffice, _type = "Int64",
              _get_func = o => o.idfSentByOffice,
              _set_func = (o, val) => { o.idfSentByOffice = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSentByOffice != c.idfSentByOffice || o.IsRIRPropChanged(_str_idfSentByOffice, c)) 
                  m.Add(_str_idfSentByOffice, o.ObjectIdent + _str_idfSentByOffice, "Int64", o.idfSentByOffice == null ? "" : o.idfSentByOffice.ToString(), o.IsReadOnly(_str_idfSentByOffice), o.IsInvisible(_str_idfSentByOffice), o.IsRequired(_str_idfSentByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfSentByPerson, _type = "Int64",
              _get_func = o => o.idfSentByPerson,
              _set_func = (o, val) => { o.idfSentByPerson = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSentByPerson != c.idfSentByPerson || o.IsRIRPropChanged(_str_idfSentByPerson, c)) 
                  m.Add(_str_idfSentByPerson, o.ObjectIdent + _str_idfSentByPerson, "Int64", o.idfSentByPerson == null ? "" : o.idfSentByPerson.ToString(), o.IsReadOnly(_str_idfSentByPerson), o.IsInvisible(_str_idfSentByPerson), o.IsRequired(_str_idfSentByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfEnteredByOffice, _type = "Int64",
              _get_func = o => o.idfEnteredByOffice,
              _set_func = (o, val) => { o.idfEnteredByOffice = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfEnteredByOffice != c.idfEnteredByOffice || o.IsRIRPropChanged(_str_idfEnteredByOffice, c)) 
                  m.Add(_str_idfEnteredByOffice, o.ObjectIdent + _str_idfEnteredByOffice, "Int64", o.idfEnteredByOffice == null ? "" : o.idfEnteredByOffice.ToString(), o.IsReadOnly(_str_idfEnteredByOffice), o.IsInvisible(_str_idfEnteredByOffice), o.IsRequired(_str_idfEnteredByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfEnteredByPerson, _type = "Int64",
              _get_func = o => o.idfEnteredByPerson,
              _set_func = (o, val) => { o.idfEnteredByPerson = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfEnteredByPerson != c.idfEnteredByPerson || o.IsRIRPropChanged(_str_idfEnteredByPerson, c)) 
                  m.Add(_str_idfEnteredByPerson, o.ObjectIdent + _str_idfEnteredByPerson, "Int64", o.idfEnteredByPerson == null ? "" : o.idfEnteredByPerson.ToString(), o.IsReadOnly(_str_idfEnteredByPerson), o.IsInvisible(_str_idfEnteredByPerson), o.IsRequired(_str_idfEnteredByPerson)); }
              }, 
        
            new field_info {
              _name = _str_datReceivedByDate, _type = "DateTime?",
              _get_func = o => o.datReceivedByDate,
              _set_func = (o, val) => { o.datReceivedByDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datReceivedByDate != c.datReceivedByDate || o.IsRIRPropChanged(_str_datReceivedByDate, c)) 
                  m.Add(_str_datReceivedByDate, o.ObjectIdent + _str_datReceivedByDate, "DateTime?", o.datReceivedByDate == null ? "" : o.datReceivedByDate.ToString(), o.IsReadOnly(_str_datReceivedByDate), o.IsInvisible(_str_datReceivedByDate), o.IsRequired(_str_datReceivedByDate)); }
              }, 
        
            new field_info {
              _name = _str_datSentByDate, _type = "DateTime?",
              _get_func = o => o.datSentByDate,
              _set_func = (o, val) => { o.datSentByDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datSentByDate != c.datSentByDate || o.IsRIRPropChanged(_str_datSentByDate, c)) 
                  m.Add(_str_datSentByDate, o.ObjectIdent + _str_datSentByDate, "DateTime?", o.datSentByDate == null ? "" : o.datSentByDate.ToString(), o.IsReadOnly(_str_datSentByDate), o.IsInvisible(_str_datSentByDate), o.IsRequired(_str_datSentByDate)); }
              }, 
        
            new field_info {
              _name = _str_datEnteredByDate, _type = "DateTime?",
              _get_func = o => o.datEnteredByDate,
              _set_func = (o, val) => { o.datEnteredByDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datEnteredByDate != c.datEnteredByDate || o.IsRIRPropChanged(_str_datEnteredByDate, c)) 
                  m.Add(_str_datEnteredByDate, o.ObjectIdent + _str_datEnteredByDate, "DateTime?", o.datEnteredByDate == null ? "" : o.datEnteredByDate.ToString(), o.IsReadOnly(_str_datEnteredByDate), o.IsInvisible(_str_datEnteredByDate), o.IsRequired(_str_datEnteredByDate)); }
              }, 
        
            new field_info {
              _name = _str_datStartDate, _type = "DateTime?",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { o.datStartDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, "DateTime?", o.datStartDate == null ? "" : o.datStartDate.ToString(), o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); }
              }, 
        
            new field_info {
              _name = _str_datFinishDate, _type = "DateTime?",
              _get_func = o => o.datFinishDate,
              _set_func = (o, val) => { o.datFinishDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datFinishDate != c.datFinishDate || o.IsRIRPropChanged(_str_datFinishDate, c)) 
                  m.Add(_str_datFinishDate, o.ObjectIdent + _str_datFinishDate, "DateTime?", o.datFinishDate == null ? "" : o.datFinishDate.ToString(), o.IsReadOnly(_str_datFinishDate), o.IsInvisible(_str_datFinishDate), o.IsRequired(_str_datFinishDate)); }
              }, 
        
            new field_info {
              _name = _str_strCaseID, _type = "String",
              _get_func = o => o.strCaseID,
              _set_func = (o, val) => { o.strCaseID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCaseID != c.strCaseID || o.IsRIRPropChanged(_str_strCaseID, c)) 
                  m.Add(_str_strCaseID, o.ObjectIdent + _str_strCaseID, "String", o.strCaseID == null ? "" : o.strCaseID.ToString(), o.IsReadOnly(_str_strCaseID), o.IsInvisible(_str_strCaseID), o.IsRequired(_str_strCaseID)); }
              }, 
        
            new field_info {
              _name = _str_idfsAreaType, _type = "Int64?",
              _get_func = o => o.idfsAreaType,
              _set_func = (o, val) => { o.idfsAreaType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsAreaType != c.idfsAreaType || o.IsRIRPropChanged(_str_idfsAreaType, c)) 
                  m.Add(_str_idfsAreaType, o.ObjectIdent + _str_idfsAreaType, "Int64?", o.idfsAreaType == null ? "" : o.idfsAreaType.ToString(), o.IsReadOnly(_str_idfsAreaType), o.IsInvisible(_str_idfsAreaType), o.IsRequired(_str_idfsAreaType)); }
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
              _name = _str_idfsPeriodType, _type = "Int64?",
              _get_func = o => o.idfsPeriodType,
              _set_func = (o, val) => { o.idfsPeriodType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsPeriodType != c.idfsPeriodType || o.IsRIRPropChanged(_str_idfsPeriodType, c)) 
                  m.Add(_str_idfsPeriodType, o.ObjectIdent + _str_idfsPeriodType, "Int64?", o.idfsPeriodType == null ? "" : o.idfsPeriodType.ToString(), o.IsReadOnly(_str_idfsPeriodType), o.IsInvisible(_str_idfsPeriodType), o.IsRequired(_str_idfsPeriodType)); }
              }, 
        
            new field_info {
              _name = _str_strPeriodName, _type = "String",
              _get_func = o => o.strPeriodName,
              _set_func = (o, val) => { o.strPeriodName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strPeriodName != c.strPeriodName || o.IsRIRPropChanged(_str_strPeriodName, c)) 
                  m.Add(_str_strPeriodName, o.ObjectIdent + _str_strPeriodName, "String", o.strPeriodName == null ? "" : o.strPeriodName.ToString(), o.IsReadOnly(_str_strPeriodName), o.IsInvisible(_str_strPeriodName), o.IsRequired(_str_strPeriodName)); }
              }, 
        
            new field_info {
              _name = _str_idfCaseObservation, _type = "Int64?",
              _get_func = o => o.idfCaseObservation,
              _set_func = (o, val) => { o.idfCaseObservation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCaseObservation != c.idfCaseObservation || o.IsRIRPropChanged(_str_idfCaseObservation, c)) 
                  m.Add(_str_idfCaseObservation, o.ObjectIdent + _str_idfCaseObservation, "Int64?", o.idfCaseObservation == null ? "" : o.idfCaseObservation.ToString(), o.IsReadOnly(_str_idfCaseObservation), o.IsInvisible(_str_idfCaseObservation), o.IsRequired(_str_idfCaseObservation)); }
              }, 
        
            new field_info {
              _name = _str_idfDiagnosticObservation, _type = "Int64?",
              _get_func = o => o.idfDiagnosticObservation,
              _set_func = (o, val) => { o.idfDiagnosticObservation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfDiagnosticObservation != c.idfDiagnosticObservation || o.IsRIRPropChanged(_str_idfDiagnosticObservation, c)) 
                  m.Add(_str_idfDiagnosticObservation, o.ObjectIdent + _str_idfDiagnosticObservation, "Int64?", o.idfDiagnosticObservation == null ? "" : o.idfDiagnosticObservation.ToString(), o.IsReadOnly(_str_idfDiagnosticObservation), o.IsInvisible(_str_idfDiagnosticObservation), o.IsRequired(_str_idfDiagnosticObservation)); }
              }, 
        
            new field_info {
              _name = _str_idfProphylacticObservation, _type = "Int64?",
              _get_func = o => o.idfProphylacticObservation,
              _set_func = (o, val) => { o.idfProphylacticObservation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfProphylacticObservation != c.idfProphylacticObservation || o.IsRIRPropChanged(_str_idfProphylacticObservation, c)) 
                  m.Add(_str_idfProphylacticObservation, o.ObjectIdent + _str_idfProphylacticObservation, "Int64?", o.idfProphylacticObservation == null ? "" : o.idfProphylacticObservation.ToString(), o.IsReadOnly(_str_idfProphylacticObservation), o.IsInvisible(_str_idfProphylacticObservation), o.IsRequired(_str_idfProphylacticObservation)); }
              }, 
        
            new field_info {
              _name = _str_idfSanitaryObservation, _type = "Int64?",
              _get_func = o => o.idfSanitaryObservation,
              _set_func = (o, val) => { o.idfSanitaryObservation = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSanitaryObservation != c.idfSanitaryObservation || o.IsRIRPropChanged(_str_idfSanitaryObservation, c)) 
                  m.Add(_str_idfSanitaryObservation, o.ObjectIdent + _str_idfSanitaryObservation, "Int64?", o.idfSanitaryObservation == null ? "" : o.idfSanitaryObservation.ToString(), o.IsReadOnly(_str_idfSanitaryObservation), o.IsInvisible(_str_idfSanitaryObservation), o.IsRequired(_str_idfSanitaryObservation)); }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosticFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsDiagnosticFormTemplate,
              _set_func = (o, val) => { o.idfsDiagnosticFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosticFormTemplate != c.idfsDiagnosticFormTemplate || o.IsRIRPropChanged(_str_idfsDiagnosticFormTemplate, c)) 
                  m.Add(_str_idfsDiagnosticFormTemplate, o.ObjectIdent + _str_idfsDiagnosticFormTemplate, "Int64?", o.idfsDiagnosticFormTemplate == null ? "" : o.idfsDiagnosticFormTemplate.ToString(), o.IsReadOnly(_str_idfsDiagnosticFormTemplate), o.IsInvisible(_str_idfsDiagnosticFormTemplate), o.IsRequired(_str_idfsDiagnosticFormTemplate)); }
              }, 
        
            new field_info {
              _name = _str_idfsProphylacticFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsProphylacticFormTemplate,
              _set_func = (o, val) => { o.idfsProphylacticFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsProphylacticFormTemplate != c.idfsProphylacticFormTemplate || o.IsRIRPropChanged(_str_idfsProphylacticFormTemplate, c)) 
                  m.Add(_str_idfsProphylacticFormTemplate, o.ObjectIdent + _str_idfsProphylacticFormTemplate, "Int64?", o.idfsProphylacticFormTemplate == null ? "" : o.idfsProphylacticFormTemplate.ToString(), o.IsReadOnly(_str_idfsProphylacticFormTemplate), o.IsInvisible(_str_idfsProphylacticFormTemplate), o.IsRequired(_str_idfsProphylacticFormTemplate)); }
              }, 
        
            new field_info {
              _name = _str_idfsSanitaryFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsSanitaryFormTemplate,
              _set_func = (o, val) => { o.idfsSanitaryFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSanitaryFormTemplate != c.idfsSanitaryFormTemplate || o.IsRIRPropChanged(_str_idfsSanitaryFormTemplate, c)) 
                  m.Add(_str_idfsSanitaryFormTemplate, o.ObjectIdent + _str_idfsSanitaryFormTemplate, "Int64?", o.idfsSanitaryFormTemplate == null ? "" : o.idfsSanitaryFormTemplate.ToString(), o.IsReadOnly(_str_idfsSanitaryFormTemplate), o.IsInvisible(_str_idfsSanitaryFormTemplate), o.IsRequired(_str_idfsSanitaryFormTemplate)); }
              }, 
        
            new field_info {
              _name = _str_idfsCaseFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsCaseFormTemplate,
              _set_func = (o, val) => { o.idfsCaseFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseFormTemplate != c.idfsCaseFormTemplate || o.IsRIRPropChanged(_str_idfsCaseFormTemplate, c)) 
                  m.Add(_str_idfsCaseFormTemplate, o.ObjectIdent + _str_idfsCaseFormTemplate, "Int64?", o.idfsCaseFormTemplate == null ? "" : o.idfsCaseFormTemplate.ToString(), o.IsReadOnly(_str_idfsCaseFormTemplate), o.IsInvisible(_str_idfsCaseFormTemplate), o.IsRequired(_str_idfsCaseFormTemplate)); }
              }, 
        
            new field_info {
              _name = _str_StatisticPeriodType, _type = "Lookup",
              _get_func = o => { if (o.StatisticPeriodType == null) return null; return o.StatisticPeriodType.idfsBaseReference; },
              _set_func = (o, val) => { o.StatisticPeriodType = o.StatisticPeriodTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsPeriodType != c.idfsPeriodType || o.IsRIRPropChanged(_str_StatisticPeriodType, c)) 
                  m.Add(_str_StatisticPeriodType, o.ObjectIdent + _str_StatisticPeriodType, "Lookup", o.idfsPeriodType == null ? "" : o.idfsPeriodType.ToString(), o.IsReadOnly(_str_StatisticPeriodType), o.IsInvisible(_str_StatisticPeriodType), o.IsRequired(_str_StatisticPeriodType)); }
              }, 
        
            new field_info {
              _name = _str_StatisticAreaType, _type = "Lookup",
              _get_func = o => { if (o.StatisticAreaType == null) return null; return o.StatisticAreaType.idfsBaseReference; },
              _set_func = (o, val) => { o.StatisticAreaType = o.StatisticAreaTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAreaType != c.idfsAreaType || o.IsRIRPropChanged(_str_StatisticAreaType, c)) 
                  m.Add(_str_StatisticAreaType, o.ObjectIdent + _str_StatisticAreaType, "Lookup", o.idfsAreaType == null ? "" : o.idfsAreaType.ToString(), o.IsReadOnly(_str_StatisticAreaType), o.IsInvisible(_str_StatisticAreaType), o.IsRequired(_str_StatisticAreaType)); }
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
              _name = _str_Settings, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Settings != null) o.Settings._compare(c.Settings, m); }
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
            HumanAggregateCaseListItem obj = (HumanAggregateCaseListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(AggregateSettings), eidss.model.Schema.AggregateSettings._str_idfsAggrCaseType, _str_idfsAggrCaseType)]
        public AggregateSettings Settings
        {
            get 
            {   
                if (!_SettingsLoaded)
                {
                    _SettingsLoaded = true;
                    _getAccessor()._LoadSettings(this);
                    if (_Settings != null) 
                        _Settings.Parent = this;
                }
                return _Settings; 
            }
            set 
            {   
                if (!_SettingsLoaded) { _SettingsLoaded = true; }
                _Settings = value;
                if (_Settings != null) 
                { 
                    _Settings.m_ObjectName = _str_Settings;
                    _Settings.Parent = this;
                }
                idfsAggrCaseType = _Settings == null 
                        ? new Int64()
                        : _Settings.idfsAggrCaseType;
                
            }
        }
        protected AggregateSettings _Settings;
                    
        private bool _SettingsLoaded = false;
                    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsPeriodType)]
        public BaseReference StatisticPeriodType
        {
            get { return _StatisticPeriodType == null ? null : ((long)_StatisticPeriodType.Key == 0 ? null : _StatisticPeriodType); }
            set 
            { 
                _StatisticPeriodType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsPeriodType = _StatisticPeriodType == null 
                    ? new Int64?()
                    : _StatisticPeriodType.idfsBaseReference; 
                OnPropertyChanged(_str_StatisticPeriodType); 
            }
        }
        private BaseReference _StatisticPeriodType;

        
        public BaseReferenceList StatisticPeriodTypeLookup
        {
            get { return _StatisticPeriodTypeLookup; }
        }
        private BaseReferenceList _StatisticPeriodTypeLookup = new BaseReferenceList("rftStatisticPeriodType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAreaType)]
        public BaseReference StatisticAreaType
        {
            get { return _StatisticAreaType == null ? null : ((long)_StatisticAreaType.Key == 0 ? null : _StatisticAreaType); }
            set 
            { 
                _StatisticAreaType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsAreaType = _StatisticAreaType == null 
                    ? new Int64?()
                    : _StatisticAreaType.idfsBaseReference; 
                OnPropertyChanged(_str_StatisticAreaType); 
            }
        }
        private BaseReference _StatisticAreaType;

        
        public BaseReferenceList StatisticAreaTypeLookup
        {
            get { return _StatisticAreaTypeLookup; }
        }
        private BaseReferenceList _StatisticAreaTypeLookup = new BaseReferenceList("rftStatisticAreaType");
            
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
            
        [Relation(typeof(RegionAggrLookup), eidss.model.Schema.RegionAggrLookup._str_idfsRegion, _str_idfsRegion)]
        public RegionAggrLookup Region
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
        private RegionAggrLookup _Region;

        
        public List<RegionAggrLookup> RegionLookup
        {
            get { return _RegionLookup; }
        }
        private List<RegionAggrLookup> _RegionLookup = new List<RegionAggrLookup>();
            
        [Relation(typeof(RayonAggrLookup), eidss.model.Schema.RayonAggrLookup._str_idfsRayon, _str_idfsRayon)]
        public RayonAggrLookup Rayon
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
        private RayonAggrLookup _Rayon;

        
        public List<RayonAggrLookup> RayonLookup
        {
            get { return _RayonLookup; }
        }
        private List<RayonAggrLookup> _RayonLookup = new List<RayonAggrLookup>();
            
        [Relation(typeof(SettlementAggrLookup), eidss.model.Schema.SettlementAggrLookup._str_idfsSettlement, _str_idfsSettlement)]
        public SettlementAggrLookup Settlement
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
        private SettlementAggrLookup _Settlement;

        
        public List<SettlementAggrLookup> SettlementLookup
        {
            get { return _SettlementLookup; }
        }
        private List<SettlementAggrLookup> _SettlementLookup = new List<SettlementAggrLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_StatisticPeriodType:
                    return new BvSelectList(StatisticPeriodTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, StatisticPeriodType, _str_idfsPeriodType);
            
                case _str_StatisticAreaType:
                    return new BvSelectList(StatisticAreaTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, StatisticAreaType, _str_idfsAreaType);
            
                case _str_Country:
                    return new BvSelectList(CountryLookup, eidss.model.Schema.CountryLookup._str_idfsCountry, null, Country, _str_idfsCountry);
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionAggrLookup._str_idfsRegion, null, Region, _str_idfsRegion);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonAggrLookup._str_idfsRayon, null, Rayon, _str_idfsRayon);
            
                case _str_Settlement:
                    return new BvSelectList(SettlementLookup, eidss.model.Schema.SettlementAggrLookup._str_idfsSettlement, null, Settlement, _str_idfsSettlement);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "HumanAggregateCaseListItem";

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
        
            if (_Settings != null) { _Settings.Parent = this; }
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as HumanAggregateCaseListItem;
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
            var ret = base.Clone() as HumanAggregateCaseListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Settings != null)
              ret.Settings = _Settings.CloneWithSetup(manager) as AggregateSettings;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public HumanAggregateCaseListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as HumanAggregateCaseListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfAggrCase; } }
        public string KeyName { get { return "idfAggrCase"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || (_Settings != null && _Settings.HasChanges)
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsPeriodType_StatisticPeriodType = idfsPeriodType;
            var _prev_idfsAreaType_StatisticAreaType = idfsAreaType;
            var _prev_idfsCountry_Country = idfsCountry;
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            var _prev_idfsSettlement_Settlement = idfsSettlement;
            base.RejectChanges();
        
            if (_prev_idfsPeriodType_StatisticPeriodType != idfsPeriodType)
            {
                _StatisticPeriodType = _StatisticPeriodTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsPeriodType);
            }
            if (_prev_idfsAreaType_StatisticAreaType != idfsAreaType)
            {
                _StatisticAreaType = _StatisticAreaTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAreaType);
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
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (Settings != null) Settings.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Settings != null) _Settings.AcceptChanges();
                
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
        
            if (_Settings != null) _Settings.SetChange();
                
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

      private bool IsRIRPropChanged(string fld, HumanAggregateCaseListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public HumanAggregateCaseListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(HumanAggregateCaseListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(HumanAggregateCaseListItem_PropertyChanged);
        }
        private void HumanAggregateCaseListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as HumanAggregateCaseListItem).Changed(e.PropertyName);
            
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
            HumanAggregateCaseListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            HumanAggregateCaseListItem obj = this;
            
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

    
        private static string[] readonly_names1 = "Region,idfsRegion".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "Rayon,idfsRayon".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "Settlement,idfsSettlement".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanAggregateCaseListItem, bool>(c => c.idfsCountry == null || c.StatisticAreaType == null 
                        || (c.StatisticAreaType != null && c.StatisticAreaType.idfsBaseReference == (long)eidss.model.Enums.StatisticAreaType.Country)
                        )(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanAggregateCaseListItem, bool>(c => c.idfsRegion == null || c.StatisticAreaType == null 
                        || (c.StatisticAreaType != null && c.StatisticAreaType.idfsBaseReference == (long)eidss.model.Enums.StatisticAreaType.Country)
                        || (c.StatisticAreaType != null && c.StatisticAreaType.idfsBaseReference == (long)eidss.model.Enums.StatisticAreaType.Region)
                        )(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<HumanAggregateCaseListItem, bool>(c => c.idfsRayon == null || c.StatisticAreaType == null 
                        || (c.StatisticAreaType != null && c.StatisticAreaType.idfsBaseReference == (long)eidss.model.Enums.StatisticAreaType.Country)
                        || (c.StatisticAreaType != null && c.StatisticAreaType.idfsBaseReference == (long)eidss.model.Enums.StatisticAreaType.Region)
                        || (c.StatisticAreaType != null && c.StatisticAreaType.idfsBaseReference == (long)eidss.model.Enums.StatisticAreaType.Rayon)
                        )(this);
            
            return ReadOnly || new Func<HumanAggregateCaseListItem, bool>(c => false)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_Settings != null)
                    _Settings.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<HumanAggregateCaseListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<HumanAggregateCaseListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<HumanAggregateCaseListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<HumanAggregateCaseListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<HumanAggregateCaseListItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<HumanAggregateCaseListItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~HumanAggregateCaseListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftStatisticPeriodType", this);
                
                LookupManager.RemoveObject("rftStatisticAreaType", this);
                
                LookupManager.RemoveObject("CountryLookup", this);
                
                LookupManager.RemoveObject("RegionAggrLookup", this);
                
                LookupManager.RemoveObject("RayonAggrLookup", this);
                
                LookupManager.RemoveObject("SettlementAggrLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftStatisticPeriodType")
                _getAccessor().LoadLookup_StatisticPeriodType(manager, this);
            
            if (lookup_object == "rftStatisticAreaType")
                _getAccessor().LoadLookup_StatisticAreaType(manager, this);
            
            if (lookup_object == "CountryLookup")
                _getAccessor().LoadLookup_Country(manager, this);
            
            if (lookup_object == "RegionAggrLookup")
                _getAccessor().LoadLookup_Region(manager, this);
            
            if (lookup_object == "RayonAggrLookup")
                _getAccessor().LoadLookup_Rayon(manager, this);
            
            if (lookup_object == "SettlementAggrLookup")
                _getAccessor().LoadLookup_Settlement(manager, this);
            
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
        
            if (_Settings != null) _Settings.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
        }
    
        #region Class for web grid
        public class HumanAggregateCaseListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfAggrCase { get; set; }
        
            public String strCaseID { get; set; }
        
            public DateTime? datStartDate { get; set; }
        
            public String strPeriodName { get; set; }
        
            public String strRegion { get; set; }
        
            public String strRayon { get; set; }
        
            public String strSettlement { get; set; }
        
        }
        public partial class HumanAggregateCaseListItemGridModelList : List<HumanAggregateCaseListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public HumanAggregateCaseListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<HumanAggregateCaseListItem>, errMes);
            }
            public HumanAggregateCaseListItemGridModelList(long key, IEnumerable<HumanAggregateCaseListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<HumanAggregateCaseListItem> items);
            private void LoadGridModelList(long key, IEnumerable<HumanAggregateCaseListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strCaseID,_str_datStartDate,_str_strPeriodName,_str_strRegion,_str_strRayon,_str_strSettlement};
                    
                Hiddens = new List<string> {_str_idfAggrCase};
                Keys = new List<string> {_str_idfAggrCase};
                Labels = new Dictionary<string, string> {{_str_strCaseID, "strCaseID"},{_str_datStartDate, _str_datStartDate},{_str_strPeriodName, "idfsPeriodType"},{_str_strRegion, "idfsRegion"},{_str_strRayon, "idfsRayon"},{_str_strSettlement, "strSettlement"}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strCaseID, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "ActionEditHumanAggregateCase")}};
                var list = new List<HumanAggregateCaseListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new HumanAggregateCaseListItemGridModel()
                {
                    ItemKey=c.idfAggrCase,strCaseID=c.strCaseID,datStartDate=c.datStartDate,strPeriodName=c.strPeriodName,strRegion=c.strRegion,strRayon=c.strRayon,strSettlement=c.strSettlement
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
        : DataAccessor<HumanAggregateCaseListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
            private delegate void on_action(HumanAggregateCaseListItem obj);
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
            private AggregateSettings.Accessor SettingsAccessor { get { return eidss.model.Schema.AggregateSettings.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor StatisticPeriodTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor StatisticAreaTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private CountryLookup.Accessor CountryAccessor { get { return eidss.model.Schema.CountryLookup.Accessor.Instance(m_CS); } }
            private RegionAggrLookup.Accessor RegionAccessor { get { return eidss.model.Schema.RegionAggrLookup.Accessor.Instance(m_CS); } }
            private RayonAggrLookup.Accessor RayonAccessor { get { return eidss.model.Schema.RayonAggrLookup.Accessor.Instance(m_CS); } }
            private SettlementAggrLookup.Accessor SettlementAccessor { get { return eidss.model.Schema.SettlementAggrLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<HumanAggregateCaseListItem> SelectListT(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                );
            }
            public virtual List<IObject> SelectList(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                ).Cast<IObject>().ToList();
            }
            
            private List<HumanAggregateCaseListItem> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                , FilterParams filters
                , KeyValuePair<string, ListSortDirection>[] sorts
                , bool serverSort = false
                )
            {
                if (filters == null) filters = new FilterParams();
                var sql = new StringBuilder();
                string maxtop = BaseSettings.SelectTopMaxCount.ToString();
                sql.Append(@"select ");
                
                sql.Append(@"top ");
                sql.Append(maxtop);
                sql.Append(@" dbo.fn_HumanAggregateCase_SelectList.* from dbo.fn_HumanAggregateCase_SelectList(@LangID
                    ) ");
                
                if (ModelUserContext.IsWebContext && EidssSiteContext.Instance.SiteType == SiteType.SS)
                {
                    sql.Append(" " + @"inner join tflAggrCaseFiltered f on f.idfAggrCase = fn_HumanAggregateCase_SelectList.idfAggrCase and f.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString());
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfAggrCase"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfAggrCase"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfAggrCase") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfAggrCase,0) {0} @idfAggrCase_{1}", filters.Operation("idfAggrCase", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsAggrCaseType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsAggrCaseType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsAggrCaseType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfsAggrCaseType,0) {0} @idfsAggrCaseType_{1}", filters.Operation("idfsAggrCaseType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsAdministrativeUnit"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsAdministrativeUnit"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsAdministrativeUnit") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfsAdministrativeUnit,0) {0} @idfsAdministrativeUnit_{1}", filters.Operation("idfsAdministrativeUnit", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfReceivedByOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfReceivedByOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfReceivedByOffice") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfReceivedByOffice,0) {0} @idfReceivedByOffice_{1}", filters.Operation("idfReceivedByOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfReceivedByPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfReceivedByPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfReceivedByPerson") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfReceivedByPerson,0) {0} @idfReceivedByPerson_{1}", filters.Operation("idfReceivedByPerson", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfSentByOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfSentByOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfSentByOffice") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfSentByOffice,0) {0} @idfSentByOffice_{1}", filters.Operation("idfSentByOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfSentByPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfSentByPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfSentByPerson") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfSentByPerson,0) {0} @idfSentByPerson_{1}", filters.Operation("idfSentByPerson", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfEnteredByOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfEnteredByOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfEnteredByOffice") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfEnteredByOffice,0) {0} @idfEnteredByOffice_{1}", filters.Operation("idfEnteredByOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfEnteredByPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfEnteredByPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfEnteredByPerson") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfEnteredByPerson,0) {0} @idfEnteredByPerson_{1}", filters.Operation("idfEnteredByPerson", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datReceivedByDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datReceivedByDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datReceivedByDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_HumanAggregateCase_SelectList.datReceivedByDate, 112) {0} CONVERT(NVARCHAR(8), @datReceivedByDate_{1}, 112)", filters.Operation("datReceivedByDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datSentByDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datSentByDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datSentByDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_HumanAggregateCase_SelectList.datSentByDate, 112) {0} CONVERT(NVARCHAR(8), @datSentByDate_{1}, 112)", filters.Operation("datSentByDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datEnteredByDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datEnteredByDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datEnteredByDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_HumanAggregateCase_SelectList.datEnteredByDate, 112) {0} CONVERT(NVARCHAR(8), @datEnteredByDate_{1}, 112)", filters.Operation("datEnteredByDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datStartDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datStartDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datStartDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_HumanAggregateCase_SelectList.datStartDate, 112) {0} CONVERT(NVARCHAR(8), @datStartDate_{1}, 112)", filters.Operation("datStartDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datFinishDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datFinishDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datFinishDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_HumanAggregateCase_SelectList.datFinishDate, 112) {0} CONVERT(NVARCHAR(8), @datFinishDate_{1}, 112)", filters.Operation("datFinishDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCaseID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCaseID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCaseID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanAggregateCase_SelectList.strCaseID {0} @strCaseID_{1}", filters.Operation("strCaseID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsAreaType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsAreaType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsAreaType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfsAreaType,0) {0} @idfsAreaType_{1}", filters.Operation("idfsAreaType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCountry"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCountry"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCountry") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfsCountry,0) {0} @idfsCountry_{1}", filters.Operation("idfsCountry", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCountry"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCountry"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCountry") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanAggregateCase_SelectList.strCountry {0} @strCountry_{1}", filters.Operation("strCountry", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsRegion"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsRegion"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsRegion") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfsRegion,0) {0} @idfsRegion_{1}", filters.Operation("idfsRegion", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strRegion"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strRegion"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strRegion") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanAggregateCase_SelectList.strRegion {0} @strRegion_{1}", filters.Operation("strRegion", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsRayon"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsRayon"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsRayon") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfsRayon,0) {0} @idfsRayon_{1}", filters.Operation("idfsRayon", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strRayon"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strRayon"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strRayon") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanAggregateCase_SelectList.strRayon {0} @strRayon_{1}", filters.Operation("strRayon", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSettlement"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSettlement") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfsSettlement,0) {0} @idfsSettlement_{1}", filters.Operation("idfsSettlement", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSettlement"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSettlement"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSettlement") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanAggregateCase_SelectList.strSettlement {0} @strSettlement_{1}", filters.Operation("strSettlement", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsPeriodType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsPeriodType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsPeriodType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfsPeriodType,0) {0} @idfsPeriodType_{1}", filters.Operation("idfsPeriodType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strPeriodName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strPeriodName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strPeriodName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_HumanAggregateCase_SelectList.strPeriodName {0} @strPeriodName_{1}", filters.Operation("strPeriodName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfCaseObservation"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfCaseObservation"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfCaseObservation") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfCaseObservation,0) {0} @idfCaseObservation_{1}", filters.Operation("idfCaseObservation", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfDiagnosticObservation"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfDiagnosticObservation"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfDiagnosticObservation") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfDiagnosticObservation,0) {0} @idfDiagnosticObservation_{1}", filters.Operation("idfDiagnosticObservation", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfProphylacticObservation"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfProphylacticObservation"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfProphylacticObservation") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfProphylacticObservation,0) {0} @idfProphylacticObservation_{1}", filters.Operation("idfProphylacticObservation", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfSanitaryObservation"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfSanitaryObservation"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfSanitaryObservation") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfSanitaryObservation,0) {0} @idfSanitaryObservation_{1}", filters.Operation("idfSanitaryObservation", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsDiagnosticFormTemplate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsDiagnosticFormTemplate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsDiagnosticFormTemplate") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfsDiagnosticFormTemplate,0) {0} @idfsDiagnosticFormTemplate_{1}", filters.Operation("idfsDiagnosticFormTemplate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsProphylacticFormTemplate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsProphylacticFormTemplate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsProphylacticFormTemplate") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfsProphylacticFormTemplate,0) {0} @idfsProphylacticFormTemplate_{1}", filters.Operation("idfsProphylacticFormTemplate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSanitaryFormTemplate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSanitaryFormTemplate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSanitaryFormTemplate") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfsSanitaryFormTemplate,0) {0} @idfsSanitaryFormTemplate_{1}", filters.Operation("idfsSanitaryFormTemplate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCaseFormTemplate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCaseFormTemplate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCaseFormTemplate") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_HumanAggregateCase_SelectList.idfsCaseFormTemplate,0) {0} @idfsCaseFormTemplate_{1}", filters.Operation("idfsCaseFormTemplate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (serverSort && sorts != null && sorts.Length > 0)
                {
                    sql.Append(" order by");
                    bool bFirst = true;
                    foreach(var sort in sorts)
                    {
                        sql.Append((bFirst ? " " : ", ") + sort.Key + " " + (sort.Value == ListSortDirection.Ascending ? "ASC" : "DESC"));
                        bFirst = false;
                    }
                }

                bool bTransactionStarted = false;
                try
                {
                    if (!manager.IsTransactionStarted)
                    {
                        bTransactionStarted = true;
                        manager.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                    }
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("idfAggrCase"))
                        for (int i = 0; i < filters.Count("idfAggrCase"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfAggrCase_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfAggrCase", i), filters.Value("idfAggrCase", i))));
                      
                    if (filters.Contains("idfsAggrCaseType"))
                        for (int i = 0; i < filters.Count("idfsAggrCaseType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAggrCaseType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsAggrCaseType", i), filters.Value("idfsAggrCaseType", i))));
                      
                    if (filters.Contains("idfsAdministrativeUnit"))
                        for (int i = 0; i < filters.Count("idfsAdministrativeUnit"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAdministrativeUnit_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsAdministrativeUnit", i), filters.Value("idfsAdministrativeUnit", i))));
                      
                    if (filters.Contains("idfReceivedByOffice"))
                        for (int i = 0; i < filters.Count("idfReceivedByOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfReceivedByOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfReceivedByOffice", i), filters.Value("idfReceivedByOffice", i))));
                      
                    if (filters.Contains("idfReceivedByPerson"))
                        for (int i = 0; i < filters.Count("idfReceivedByPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfReceivedByPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfReceivedByPerson", i), filters.Value("idfReceivedByPerson", i))));
                      
                    if (filters.Contains("idfSentByOffice"))
                        for (int i = 0; i < filters.Count("idfSentByOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSentByOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSentByOffice", i), filters.Value("idfSentByOffice", i))));
                      
                    if (filters.Contains("idfSentByPerson"))
                        for (int i = 0; i < filters.Count("idfSentByPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSentByPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSentByPerson", i), filters.Value("idfSentByPerson", i))));
                      
                    if (filters.Contains("idfEnteredByOffice"))
                        for (int i = 0; i < filters.Count("idfEnteredByOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfEnteredByOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfEnteredByOffice", i), filters.Value("idfEnteredByOffice", i))));
                      
                    if (filters.Contains("idfEnteredByPerson"))
                        for (int i = 0; i < filters.Count("idfEnteredByPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfEnteredByPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfEnteredByPerson", i), filters.Value("idfEnteredByPerson", i))));
                      
                    if (filters.Contains("datReceivedByDate"))
                        for (int i = 0; i < filters.Count("datReceivedByDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datReceivedByDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datReceivedByDate", i), filters.Value("datReceivedByDate", i))));
                      
                    if (filters.Contains("datSentByDate"))
                        for (int i = 0; i < filters.Count("datSentByDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datSentByDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datSentByDate", i), filters.Value("datSentByDate", i))));
                      
                    if (filters.Contains("datEnteredByDate"))
                        for (int i = 0; i < filters.Count("datEnteredByDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datEnteredByDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datEnteredByDate", i), filters.Value("datEnteredByDate", i))));
                      
                    if (filters.Contains("datStartDate"))
                        for (int i = 0; i < filters.Count("datStartDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datStartDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datStartDate", i), filters.Value("datStartDate", i))));
                      
                    if (filters.Contains("datFinishDate"))
                        for (int i = 0; i < filters.Count("datFinishDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datFinishDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datFinishDate", i), filters.Value("datFinishDate", i))));
                      
                    if (filters.Contains("strCaseID"))
                        for (int i = 0; i < filters.Count("strCaseID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCaseID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCaseID", i), filters.Value("strCaseID", i))));
                      
                    if (filters.Contains("idfsAreaType"))
                        for (int i = 0; i < filters.Count("idfsAreaType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsAreaType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsAreaType", i), filters.Value("idfsAreaType", i))));
                      
                    if (filters.Contains("idfsCountry"))
                        for (int i = 0; i < filters.Count("idfsCountry"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCountry_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCountry", i), filters.Value("idfsCountry", i))));
                      
                    if (filters.Contains("strCountry"))
                        for (int i = 0; i < filters.Count("strCountry"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCountry_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCountry", i), filters.Value("strCountry", i))));
                      
                    if (filters.Contains("idfsRegion"))
                        for (int i = 0; i < filters.Count("idfsRegion"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRegion", i), filters.Value("idfsRegion", i))));
                      
                    if (filters.Contains("strRegion"))
                        for (int i = 0; i < filters.Count("strRegion"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strRegion", i), filters.Value("strRegion", i))));
                      
                    if (filters.Contains("idfsRayon"))
                        for (int i = 0; i < filters.Count("idfsRayon"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsRayon", i), filters.Value("idfsRayon", i))));
                      
                    if (filters.Contains("strRayon"))
                        for (int i = 0; i < filters.Count("strRayon"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strRayon", i), filters.Value("strRayon", i))));
                      
                    if (filters.Contains("idfsSettlement"))
                        for (int i = 0; i < filters.Count("idfsSettlement"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSettlement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSettlement", i), filters.Value("idfsSettlement", i))));
                      
                    if (filters.Contains("strSettlement"))
                        for (int i = 0; i < filters.Count("strSettlement"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSettlement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSettlement", i), filters.Value("strSettlement", i))));
                      
                    if (filters.Contains("idfsPeriodType"))
                        for (int i = 0; i < filters.Count("idfsPeriodType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsPeriodType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsPeriodType", i), filters.Value("idfsPeriodType", i))));
                      
                    if (filters.Contains("strPeriodName"))
                        for (int i = 0; i < filters.Count("strPeriodName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strPeriodName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strPeriodName", i), filters.Value("strPeriodName", i))));
                      
                    if (filters.Contains("idfCaseObservation"))
                        for (int i = 0; i < filters.Count("idfCaseObservation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfCaseObservation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfCaseObservation", i), filters.Value("idfCaseObservation", i))));
                      
                    if (filters.Contains("idfDiagnosticObservation"))
                        for (int i = 0; i < filters.Count("idfDiagnosticObservation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfDiagnosticObservation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfDiagnosticObservation", i), filters.Value("idfDiagnosticObservation", i))));
                      
                    if (filters.Contains("idfProphylacticObservation"))
                        for (int i = 0; i < filters.Count("idfProphylacticObservation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfProphylacticObservation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfProphylacticObservation", i), filters.Value("idfProphylacticObservation", i))));
                      
                    if (filters.Contains("idfSanitaryObservation"))
                        for (int i = 0; i < filters.Count("idfSanitaryObservation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSanitaryObservation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSanitaryObservation", i), filters.Value("idfSanitaryObservation", i))));
                      
                    if (filters.Contains("idfsDiagnosticFormTemplate"))
                        for (int i = 0; i < filters.Count("idfsDiagnosticFormTemplate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosticFormTemplate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosticFormTemplate", i), filters.Value("idfsDiagnosticFormTemplate", i))));
                      
                    if (filters.Contains("idfsProphylacticFormTemplate"))
                        for (int i = 0; i < filters.Count("idfsProphylacticFormTemplate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsProphylacticFormTemplate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsProphylacticFormTemplate", i), filters.Value("idfsProphylacticFormTemplate", i))));
                      
                    if (filters.Contains("idfsSanitaryFormTemplate"))
                        for (int i = 0; i < filters.Count("idfsSanitaryFormTemplate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSanitaryFormTemplate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSanitaryFormTemplate", i), filters.Value("idfsSanitaryFormTemplate", i))));
                      
                    if (filters.Contains("idfsCaseFormTemplate"))
                        for (int i = 0; i < filters.Count("idfsCaseFormTemplate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCaseFormTemplate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCaseFormTemplate", i), filters.Value("idfsCaseFormTemplate", i))));
                      
                    List<HumanAggregateCaseListItem> objs = manager.ExecuteList<HumanAggregateCaseListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                    }
                    return objs;
                }
                catch(DataException e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                    }
                    throw DbModelException.Create(e);
                }
            }
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spHumanAggregateCase_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
            internal void _LoadSettings(HumanAggregateCaseListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSettings(manager, obj);
                }
            }
            internal void _LoadSettings(DbManagerProxy manager, HumanAggregateCaseListItem obj)
            {
                
                if (obj.Settings == null && obj.idfsAggrCaseType != 0)
                {
                    obj.Settings = SettingsAccessor.SelectByKey(manager
                        
                        , obj.idfsAggrCaseType
                        );
                    if (obj.Settings != null)
                    {
                        obj.Settings.m_ObjectName = _str_Settings;
                    }
                }
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, HumanAggregateCaseListItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, HumanAggregateCaseListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    SettingsAccessor._SetPermitions(obj._permissions, obj.Settings);
                    
                    }
                }
            }

    

            private HumanAggregateCaseListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    HumanAggregateCaseListItem obj = HumanAggregateCaseListItem.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfsAggrCaseType = new Func<HumanAggregateCaseListItem, long>(c => (long)AggregateCaseType.HumanAggregateCase)(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.Country = new Func<HumanAggregateCaseListItem, CountryLookup>(c => 
                                     c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
                                     .SingleOrDefault())(obj);
                obj.Region = new Func<HumanAggregateCaseListItem, RegionAggrLookup>(c => 
                                     c.RegionLookup.Where(a => a.idfsRegion == eidss.model.Core.EidssSiteContext.Instance.RegionID)
                                     .SingleOrDefault())(obj);
                obj.StatisticPeriodType = new Func<HumanAggregateCaseListItem, BaseReference>(c => 
                                     c.StatisticPeriodTypeLookup.Where(a => a.idfsBaseReference == c.Settings.idfsStatisticPeriodType)
                                     .SingleOrDefault())(obj);
                obj.StatisticAreaType = new Func<HumanAggregateCaseListItem, BaseReference>(c => 
                                     c.StatisticAreaTypeLookup.Where(a => a.idfsBaseReference == c.Settings.idfsStatisticAreaType)
                                     .SingleOrDefault())(obj);
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

            
            public HumanAggregateCaseListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public HumanAggregateCaseListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ActionEditHumanAggregateCase(DbManagerProxy manager, HumanAggregateCaseListItem obj, List<object> pars)
            {
                
                return ActionEditHumanAggregateCase(manager, obj
                    );
            }
            public ActResult ActionEditHumanAggregateCase(DbManagerProxy manager, HumanAggregateCaseListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ActionEditHumanAggregateCase"))
                    throw new PermissionException("HumanCase", "ActionEditHumanAggregateCase");
                
                return true;
                
            }
            
            private void _SetupChildHandlers(HumanAggregateCaseListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(HumanAggregateCaseListItem obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsCountry)
                        {
                    
                obj.Region = new Func<HumanAggregateCaseListItem, RegionAggrLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRegion)
                        {
                    
                obj.Rayon = new Func<HumanAggregateCaseListItem, RayonAggrLookup>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_idfsRayon)
                        {
                    
                obj.Settlement = new Func<HumanAggregateCaseListItem, SettlementAggrLookup>(c => null)(obj);
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
                    
                    };
                
            }
    
            public void LoadLookup_StatisticPeriodType(DbManagerProxy manager, HumanAggregateCaseListItem obj)
            {
                
                obj.StatisticPeriodTypeLookup.Clear();
                
                obj.StatisticPeriodTypeLookup.Add(StatisticPeriodTypeAccessor.CreateNewT(manager, null));
                
                obj.StatisticPeriodTypeLookup.AddRange(StatisticPeriodTypeAccessor.rftStatisticPeriodType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsPeriodType))
                    
                    .ToList());
                
                if (obj.idfsPeriodType != null && obj.idfsPeriodType != 0)
                {
                    obj.StatisticPeriodType = obj.StatisticPeriodTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsPeriodType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftStatisticPeriodType", obj, StatisticPeriodTypeAccessor.GetType(), "rftStatisticPeriodType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_StatisticAreaType(DbManagerProxy manager, HumanAggregateCaseListItem obj)
            {
                
                obj.StatisticAreaTypeLookup.Clear();
                
                obj.StatisticAreaTypeLookup.Add(StatisticAreaTypeAccessor.CreateNewT(manager, null));
                
                obj.StatisticAreaTypeLookup.AddRange(StatisticAreaTypeAccessor.rftStatisticAreaType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAreaType))
                    
                    .ToList());
                
                if (obj.idfsAreaType != null && obj.idfsAreaType != 0)
                {
                    obj.StatisticAreaType = obj.StatisticAreaTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsAreaType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftStatisticAreaType", obj, StatisticAreaTypeAccessor.GetType(), "rftStatisticAreaType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Country(DbManagerProxy manager, HumanAggregateCaseListItem obj)
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
            
            public void LoadLookup_Region(DbManagerProxy manager, HumanAggregateCaseListItem obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<HumanAggregateCaseListItem, long>(c => c.idfsCountry ?? 0)(obj)
                            
                    , null
                    , (long)AggregateCaseType.HumanAggregateCase
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRegion == obj.idfsRegion))
                    
                    .ToList());
                
                if (obj.idfsRegion != null && obj.idfsRegion != 0)
                {
                    obj.Region = obj.RegionLookup
                        .Where(c => c.idfsRegion == obj.idfsRegion)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("RegionAggrLookup", obj, RegionAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Rayon(DbManagerProxy manager, HumanAggregateCaseListItem obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<HumanAggregateCaseListItem, long>(c => c.idfsRegion ?? 0)(obj)
                            
                    , null
                    , (long)AggregateCaseType.HumanAggregateCase
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRayon == obj.idfsRayon))
                    
                    .ToList());
                
                if (obj.idfsRayon != null && obj.idfsRayon != 0)
                {
                    obj.Rayon = obj.RayonLookup
                        .Where(c => c.idfsRayon == obj.idfsRayon)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("RayonAggrLookup", obj, RayonAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Settlement(DbManagerProxy manager, HumanAggregateCaseListItem obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<HumanAggregateCaseListItem, long>(c => c.idfsRayon ?? 0)(obj)
                            
                    , null
                    , (long)AggregateCaseType.HumanAggregateCase
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSettlement == obj.idfsSettlement))
                    
                    .ToList());
                
                if (obj.idfsSettlement != null && obj.idfsSettlement != 0)
                {
                    obj.Settlement = obj.SettlementLookup
                        .Where(c => c.idfsSettlement == obj.idfsSettlement)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("SettlementAggrLookup", obj, SettlementAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, HumanAggregateCaseListItem obj)
            {
                
                LoadLookup_StatisticPeriodType(manager, obj);
                
                LoadLookup_StatisticAreaType(manager, obj);
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
            }
    
            [SprocName("spHumanAggregateCase_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    HumanAggregateCaseListItem bo = obj as HumanAggregateCaseListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("HumanCase", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("HumanCase", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("HumanCase", "Update");
                    }
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfAggrCase;
                        
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoAgregateHumanCase;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbAggrCase;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as HumanAggregateCaseListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, HumanAggregateCaseListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfAggrCase
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(HumanAggregateCaseListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, HumanAggregateCaseListItem obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as HumanAggregateCaseListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, HumanAggregateCaseListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(HumanAggregateCaseListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(HumanAggregateCaseListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as HumanAggregateCaseListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as HumanAggregateCaseListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "HumanAggregateCaseListItemDetail"; } }
            public string HelpIdWin { get { return "HumanAggregateCaseSummary"; } }
            public string HelpIdWeb { get { return "web_to_search_for_a_human_aggregate"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private HumanAggregateCaseListItem m_obj;
            internal Permissions(HumanAggregateCaseListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_HumanAggregateCase_SelectList";
            public static string spCount = "spHumanAggregateCase_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spHumanAggregateCase_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<HumanAggregateCaseListItem, bool>> RequiredByField = new Dictionary<string, Func<HumanAggregateCaseListItem, bool>>();
            public static Dictionary<string, Func<HumanAggregateCaseListItem, bool>> RequiredByProperty = new Dictionary<string, Func<HumanAggregateCaseListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strCaseID, 200);
                Sizes.Add(_str_strCountry, 300);
                Sizes.Add(_str_strRegion, 300);
                Sizes.Add(_str_strRayon, 300);
                Sizes.Add(_str_strSettlement, 300);
                Sizes.Add(_str_strPeriodName, 2000);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCaseID",
                    EditorType.Text,
                    false, false, 
                    "strCaseID",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "PeriodSeparator",
                    EditorType.Separator,
                    false, false, 
                    "",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsPeriodType",
                    EditorType.Lookup,
                    false, false, 
                    "strTimeIntervalUnit",
                    null, null, true, false, SearchPanelLocation.Main, false, null, "StatisticPeriodTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datStartDate",
                    EditorType.Date,
                    false, false, 
                    "datStartDate",
                    null, ">=", false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datFinishDate",
                    EditorType.Date,
                    false, false, 
                    "datFinishDate",
                    null, "<=", false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "AreaSeparator",
                    EditorType.Separator,
                    false, false, 
                    "",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsAreaType",
                    EditorType.Lookup,
                    false, false, 
                    "idfsAreaType",
                    null, null, true, false, SearchPanelLocation.Main, false, null, "StatisticAreaTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRegion",
                    EditorType.Lookup,
                    false, false, 
                    "idfsRegion",
                    null, "=", false, false, SearchPanelLocation.Main, false, "idfsRayon", "RegionLookup", typeof(RegionAggrLookup), (o) => { var c = (RegionAggrLookup)o; return c.idfsRegion; }, (o) => { var c = (RegionAggrLookup)o; return c.strRegionName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsRayon",
                    EditorType.Lookup,
                    false, false, 
                    "idfsRayon",
                    null, null, false, false, SearchPanelLocation.Main, false, "idfsSettlement", "RayonLookup", typeof(RayonAggrLookup), (o) => { var c = (RayonAggrLookup)o; return c.idfsRayon; }, (o) => { var c = (RayonAggrLookup)o; return c.strRayonName; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSettlement",
                    EditorType.Lookup,
                    false, false, 
                    "strSettlement",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "SettlementLookup", typeof(SettlementAggrLookup), (o) => { var c = (SettlementAggrLookup)o; return c.idfsSettlement; }, (o) => { var c = (SettlementAggrLookup)o; return c.strSettlementName; }
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfAggrCase,
                    _str_idfAggrCase, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseID,
                    "strCaseID", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datStartDate,
                    _str_datStartDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPeriodName,
                    "idfsPeriodType", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRegion,
                    "idfsRegion", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRayon,
                    "idfsRayon", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSettlement,
                    "strSettlement", null, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "ActionEditHumanAggregateCase",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionEditHumanAggregateCase(manager, (HumanAggregateCaseListItem)c, pars),
                        
                    null,
                    
                    null,
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "SelectAll",
                    ActionTypes.SelectAll,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelectAll_Id",
                        "selectall",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    "Select",
                    ActionTypes.Select,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelect_Id",
                        "select",
                        /*from BvMessages*/"tooltipSelect_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelect_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<HumanAggregateCase>().CreateNew(manager, null, pars == null ? null : (int?)pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<HumanAggregateCase>().SelectDetail(manager, pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    (manager, c, pars) => 
                        {
                            if (c == null)
                            {
                                c = ObjectAccessor.CreatorInterface<HumanAggregateCaseListItem>().CreateWithParams(manager, null, pars);
                                ((HumanAggregateCaseListItem)c).idfAggrCase = (long)pars[0];
                                ((HumanAggregateCaseListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((HumanAggregateCaseListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<HumanAggregateCaseListItem>().Post(manager, (HumanAggregateCaseListItem)c), c);
                        }
                                            ,
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
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
                    "Refresh",
                    ActionTypes.Refresh,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strRefresh_Id",
                        "iconRefresh_Id",
                        /*from BvMessages*/"tooltipRefresh_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipRefresh_Id",
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
                    "Close",
                    ActionTypes.Close,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strClose_Id",
                        "Close",
                        /*from BvMessages*/"tooltipClose_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipClose_Id",
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
                    "Report",
                    ActionTypes.Report,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strReport_Id",
                        "Report",
                        /*from BvMessages*/"tooltipReport_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipReport_Id",
                        ActionsAlignment.Left,
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
	