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
    public abstract partial class AggregateCaseHeader : 
        EditableObject<AggregateCaseHeader>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfAggrCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfAggrCase { get; set; }
                
        [LocalizedDisplayName(_str_idfsAggrCaseType)]
        [MapField(_str_idfsAggrCaseType)]
        public abstract Int64 idfsAggrCaseType { get; set; }
        protected Int64 idfsAggrCaseType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAggrCaseType).OriginalValue; } }
        protected Int64 idfsAggrCaseType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAggrCaseType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHACode)]
        [MapField(_str_intHACode)]
        public abstract Int32 intHACode { get; set; }
        protected Int32 intHACode_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intHACode).OriginalValue; } }
        protected Int32 intHACode_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intHACode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsAdministrativeUnit)]
        [MapField(_str_idfsAdministrativeUnit)]
        public abstract Int64 idfsAdministrativeUnit { get; set; }
        protected Int64 idfsAdministrativeUnit_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAdministrativeUnit).OriginalValue; } }
        protected Int64 idfsAdministrativeUnit_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsAdministrativeUnit).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfReceivedByOffice)]
        [MapField(_str_idfReceivedByOffice)]
        public abstract Int64? idfReceivedByOffice { get; set; }
        protected Int64? idfReceivedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfReceivedByOffice).OriginalValue; } }
        protected Int64? idfReceivedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfReceivedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfReceivedByPerson)]
        [MapField(_str_idfReceivedByPerson)]
        public abstract Int64? idfReceivedByPerson { get; set; }
        protected Int64? idfReceivedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfReceivedByPerson).OriginalValue; } }
        protected Int64? idfReceivedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfReceivedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strReceivedByOffice)]
        [MapField(_str_strReceivedByOffice)]
        public abstract String strReceivedByOffice { get; set; }
        protected String strReceivedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByOffice).OriginalValue; } }
        protected String strReceivedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strReceivedByPerson)]
        [MapField(_str_strReceivedByPerson)]
        public abstract String strReceivedByPerson { get; set; }
        protected String strReceivedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByPerson).OriginalValue; } }
        protected String strReceivedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSentByOffice)]
        [MapField(_str_idfSentByOffice)]
        public abstract Int64 idfSentByOffice { get; set; }
        protected Int64 idfSentByOffice_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfSentByOffice).OriginalValue; } }
        protected Int64 idfSentByOffice_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfSentByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSentByPerson)]
        [MapField(_str_idfSentByPerson)]
        public abstract Int64 idfSentByPerson { get; set; }
        protected Int64 idfSentByPerson_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfSentByPerson).OriginalValue; } }
        protected Int64 idfSentByPerson_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfSentByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSentByOffice)]
        [MapField(_str_strSentByOffice)]
        public abstract String strSentByOffice { get; set; }
        protected String strSentByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strSentByOffice).OriginalValue; } }
        protected String strSentByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSentByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSentByPerson)]
        [MapField(_str_strSentByPerson)]
        public abstract String strSentByPerson { get; set; }
        protected String strSentByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strSentByPerson).OriginalValue; } }
        protected String strSentByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSentByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfEnteredByOffice)]
        [MapField(_str_idfEnteredByOffice)]
        public abstract Int64 idfEnteredByOffice { get; set; }
        protected Int64 idfEnteredByOffice_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfEnteredByOffice).OriginalValue; } }
        protected Int64 idfEnteredByOffice_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfEnteredByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfEnteredByPerson)]
        [MapField(_str_idfEnteredByPerson)]
        public abstract Int64 idfEnteredByPerson { get; set; }
        protected Int64 idfEnteredByPerson_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfEnteredByPerson).OriginalValue; } }
        protected Int64 idfEnteredByPerson_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfEnteredByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strEnteredByOffice)]
        [MapField(_str_strEnteredByOffice)]
        public abstract String strEnteredByOffice { get; set; }
        protected String strEnteredByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strEnteredByOffice).OriginalValue; } }
        protected String strEnteredByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEnteredByOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strEnteredByPerson)]
        [MapField(_str_strEnteredByPerson)]
        public abstract String strEnteredByPerson { get; set; }
        protected String strEnteredByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strEnteredByPerson).OriginalValue; } }
        protected String strEnteredByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEnteredByPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCaseObservation)]
        [MapField(_str_idfCaseObservation)]
        public abstract Int64? idfCaseObservation { get; set; }
        protected Int64? idfCaseObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCaseObservation).OriginalValue; } }
        protected Int64? idfCaseObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCaseObservation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCaseObservationFormTemplate)]
        [MapField(_str_idfsCaseObservationFormTemplate)]
        public abstract Int64? idfsCaseObservationFormTemplate { get; set; }
        protected Int64? idfsCaseObservationFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseObservationFormTemplate).OriginalValue; } }
        protected Int64? idfsCaseObservationFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseObservationFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfDiagnosticObservation)]
        [MapField(_str_idfDiagnosticObservation)]
        public abstract Int64? idfDiagnosticObservation { get; set; }
        protected Int64? idfDiagnosticObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDiagnosticObservation).OriginalValue; } }
        protected Int64? idfDiagnosticObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDiagnosticObservation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsDiagnosticObservationFormTemplate)]
        [MapField(_str_idfsDiagnosticObservationFormTemplate)]
        public abstract Int64? idfsDiagnosticObservationFormTemplate { get; set; }
        protected Int64? idfsDiagnosticObservationFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosticObservationFormTemplate).OriginalValue; } }
        protected Int64? idfsDiagnosticObservationFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosticObservationFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfProphylacticObservation)]
        [MapField(_str_idfProphylacticObservation)]
        public abstract Int64? idfProphylacticObservation { get; set; }
        protected Int64? idfProphylacticObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfProphylacticObservation).OriginalValue; } }
        protected Int64? idfProphylacticObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfProphylacticObservation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsProphylacticObservationFormTemplate)]
        [MapField(_str_idfsProphylacticObservationFormTemplate)]
        public abstract Int64? idfsProphylacticObservationFormTemplate { get; set; }
        protected Int64? idfsProphylacticObservationFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsProphylacticObservationFormTemplate).OriginalValue; } }
        protected Int64? idfsProphylacticObservationFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsProphylacticObservationFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSanitaryObservation)]
        [MapField(_str_idfSanitaryObservation)]
        public abstract Int64? idfSanitaryObservation { get; set; }
        protected Int64? idfSanitaryObservation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSanitaryObservation).OriginalValue; } }
        protected Int64? idfSanitaryObservation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSanitaryObservation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSanitaryObservationFormTemplate)]
        [MapField(_str_idfsSanitaryObservationFormTemplate)]
        public abstract Int64? idfsSanitaryObservationFormTemplate { get; set; }
        protected Int64? idfsSanitaryObservationFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSanitaryObservationFormTemplate).OriginalValue; } }
        protected Int64? idfsSanitaryObservationFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSanitaryObservationFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfVersion)]
        [MapField(_str_idfVersion)]
        public abstract Int64? idfVersion { get; set; }
        protected Int64? idfVersion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVersion).OriginalValue; } }
        protected Int64? idfVersion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVersion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfDiagnosticVersion)]
        [MapField(_str_idfDiagnosticVersion)]
        public abstract Int64? idfDiagnosticVersion { get; set; }
        protected Int64? idfDiagnosticVersion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDiagnosticVersion).OriginalValue; } }
        protected Int64? idfDiagnosticVersion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDiagnosticVersion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfProphylacticVersion)]
        [MapField(_str_idfProphylacticVersion)]
        public abstract Int64? idfProphylacticVersion { get; set; }
        protected Int64? idfProphylacticVersion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfProphylacticVersion).OriginalValue; } }
        protected Int64? idfProphylacticVersion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfProphylacticVersion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSanitaryVersion)]
        [MapField(_str_idfSanitaryVersion)]
        public abstract Int64? idfSanitaryVersion { get; set; }
        protected Int64? idfSanitaryVersion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSanitaryVersion).OriginalValue; } }
        protected Int64? idfSanitaryVersion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSanitaryVersion).PreviousValue; } }
                
        [LocalizedDisplayName("lbNotificationReceivedByDate")]
        [MapField(_str_datReceivedByDate)]
        public abstract DateTime? datReceivedByDate { get; set; }
        protected DateTime? datReceivedByDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReceivedByDate).OriginalValue; } }
        protected DateTime? datReceivedByDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datReceivedByDate).PreviousValue; } }
                
        [LocalizedDisplayName("lbNotificationSentByDate")]
        [MapField(_str_datSentByDate)]
        public abstract DateTime? datSentByDate { get; set; }
        protected DateTime? datSentByDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSentByDate).OriginalValue; } }
        protected DateTime? datSentByDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSentByDate).PreviousValue; } }
                
        [LocalizedDisplayName("lbNotificationEnteredByDate")]
        [MapField(_str_datEnteredByDate)]
        public abstract DateTime? datEnteredByDate { get; set; }
        protected DateTime? datEnteredByDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredByDate).OriginalValue; } }
        protected DateTime? datEnteredByDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredByDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStartDate)]
        [MapField(_str_datStartDate)]
        public abstract DateTime? datStartDate { get; set; }
        protected DateTime? datStartDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime? datStartDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFinishDate)]
        [MapField(_str_datFinishDate)]
        public abstract DateTime? datFinishDate { get; set; }
        protected DateTime? datFinishDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFinishDate).OriginalValue; } }
        protected DateTime? datFinishDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFinishDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strCaseID)]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_YearForAggr)]
        [MapField(_str_YearForAggr)]
        public abstract Int64? YearForAggr { get; set; }
        protected Int64? YearForAggr_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._yearForAggr).OriginalValue; } }
        protected Int64? YearForAggr_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._yearForAggr).PreviousValue; } }
                
        [LocalizedDisplayName(_str_QuarterForAggr)]
        [MapField(_str_QuarterForAggr)]
        public abstract Int64? QuarterForAggr { get; set; }
        protected Int64? QuarterForAggr_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._quarterForAggr).OriginalValue; } }
        protected Int64? QuarterForAggr_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._quarterForAggr).PreviousValue; } }
                
        [LocalizedDisplayName(_str_MonthForAggr)]
        [MapField(_str_MonthForAggr)]
        public abstract Int64? MonthForAggr { get; set; }
        protected Int64? MonthForAggr_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._monthForAggr).OriginalValue; } }
        protected Int64? MonthForAggr_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._monthForAggr).PreviousValue; } }
                
        [LocalizedDisplayName(_str_WeekForAggr)]
        [MapField(_str_WeekForAggr)]
        public abstract Int64? WeekForAggr { get; set; }
        protected Int64? WeekForAggr_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._weekForAggr).OriginalValue; } }
        protected Int64? WeekForAggr_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._weekForAggr).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DayForAggr)]
        [MapField(_str_DayForAggr)]
        public abstract DateTime? DayForAggr { get; set; }
        protected DateTime? DayForAggr_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._dayForAggr).OriginalValue; } }
        protected DateTime? DayForAggr_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._dayForAggr).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsCountry)]
        [MapField(_str_idfsCountry)]
        public abstract Int64? idfsCountry { get; set; }
        protected Int64? idfsCountry_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).OriginalValue; } }
        protected Int64? idfsCountry_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCountry).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRegion)]
        [MapField(_str_idfsRegion)]
        public abstract Int64? idfsRegion { get; set; }
        protected Int64? idfsRegion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).OriginalValue; } }
        protected Int64? idfsRegion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRegion).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsRayon)]
        [MapField(_str_idfsRayon)]
        public abstract Int64? idfsRayon { get; set; }
        protected Int64? idfsRayon_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).OriginalValue; } }
        protected Int64? idfsRayon_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsRayon).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSettlement)]
        [MapField(_str_idfsSettlement)]
        public abstract Int64? idfsSettlement { get; set; }
        protected Int64? idfsSettlement_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).OriginalValue; } }
        protected Int64? idfsSettlement_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSettlement).PreviousValue; } }
                
        [LocalizedDisplayName(_str_CurPeriodType)]
        [MapField(_str_CurPeriodType)]
        public abstract Int64? CurPeriodType { get; set; }
        protected Int64? CurPeriodType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._curPeriodType).OriginalValue; } }
        protected Int64? CurPeriodType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._curPeriodType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_CurAreaType)]
        [MapField(_str_CurAreaType)]
        public abstract Int64? CurAreaType { get; set; }
        protected Int64? CurAreaType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._curAreaType).OriginalValue; } }
        protected Int64? CurAreaType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._curAreaType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datModificationForArchiveDate)]
        [MapField(_str_datModificationForArchiveDate)]
        public abstract DateTime? datModificationForArchiveDate { get; set; }
        protected DateTime? datModificationForArchiveDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationForArchiveDate).OriginalValue; } }
        protected DateTime? datModificationForArchiveDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationForArchiveDate).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<AggregateCaseHeader, object> _get_func;
            internal Action<AggregateCaseHeader, string> _set_func;
            internal Action<AggregateCaseHeader, AggregateCaseHeader, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAggrCase = "idfAggrCase";
        internal const string _str_idfsAggrCaseType = "idfsAggrCaseType";
        internal const string _str_intHACode = "intHACode";
        internal const string _str_idfsAdministrativeUnit = "idfsAdministrativeUnit";
        internal const string _str_idfReceivedByOffice = "idfReceivedByOffice";
        internal const string _str_idfReceivedByPerson = "idfReceivedByPerson";
        internal const string _str_strReceivedByOffice = "strReceivedByOffice";
        internal const string _str_strReceivedByPerson = "strReceivedByPerson";
        internal const string _str_idfSentByOffice = "idfSentByOffice";
        internal const string _str_idfSentByPerson = "idfSentByPerson";
        internal const string _str_strSentByOffice = "strSentByOffice";
        internal const string _str_strSentByPerson = "strSentByPerson";
        internal const string _str_idfEnteredByOffice = "idfEnteredByOffice";
        internal const string _str_idfEnteredByPerson = "idfEnteredByPerson";
        internal const string _str_strEnteredByOffice = "strEnteredByOffice";
        internal const string _str_strEnteredByPerson = "strEnteredByPerson";
        internal const string _str_idfCaseObservation = "idfCaseObservation";
        internal const string _str_idfsCaseObservationFormTemplate = "idfsCaseObservationFormTemplate";
        internal const string _str_idfDiagnosticObservation = "idfDiagnosticObservation";
        internal const string _str_idfsDiagnosticObservationFormTemplate = "idfsDiagnosticObservationFormTemplate";
        internal const string _str_idfProphylacticObservation = "idfProphylacticObservation";
        internal const string _str_idfsProphylacticObservationFormTemplate = "idfsProphylacticObservationFormTemplate";
        internal const string _str_idfSanitaryObservation = "idfSanitaryObservation";
        internal const string _str_idfsSanitaryObservationFormTemplate = "idfsSanitaryObservationFormTemplate";
        internal const string _str_idfVersion = "idfVersion";
        internal const string _str_idfDiagnosticVersion = "idfDiagnosticVersion";
        internal const string _str_idfProphylacticVersion = "idfProphylacticVersion";
        internal const string _str_idfSanitaryVersion = "idfSanitaryVersion";
        internal const string _str_datReceivedByDate = "datReceivedByDate";
        internal const string _str_datSentByDate = "datSentByDate";
        internal const string _str_datEnteredByDate = "datEnteredByDate";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_datFinishDate = "datFinishDate";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_YearForAggr = "YearForAggr";
        internal const string _str_QuarterForAggr = "QuarterForAggr";
        internal const string _str_MonthForAggr = "MonthForAggr";
        internal const string _str_WeekForAggr = "WeekForAggr";
        internal const string _str_DayForAggr = "DayForAggr";
        internal const string _str_idfsCountry = "idfsCountry";
        internal const string _str_idfsRegion = "idfsRegion";
        internal const string _str_idfsRayon = "idfsRayon";
        internal const string _str_idfsSettlement = "idfsSettlement";
        internal const string _str_CurPeriodType = "CurPeriodType";
        internal const string _str_CurAreaType = "CurAreaType";
        internal const string _str_datModificationForArchiveDate = "datModificationForArchiveDate";
        internal const string _str_NumberingObject = "NumberingObject";
        internal const string _str_idfsAdministrativeUnitCalc = "idfsAdministrativeUnitCalc";
        internal const string _str_datStartDateCalc = "datStartDateCalc";
        internal const string _str_datFinishDateCalc = "datFinishDateCalc";
        internal const string _str_strReadOnlyEnteredByDate = "strReadOnlyEnteredByDate";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_SentByOffice = "SentByOffice";
        internal const string _str_ReceivedByOffice = "ReceivedByOffice";
        internal const string _str_SentByPerson = "SentByPerson";
        internal const string _str_ReceivedByPerson = "ReceivedByPerson";
        internal const string _str_YearAggr = "YearAggr";
        internal const string _str_QuarterAggr = "QuarterAggr";
        internal const string _str_MonthAggr = "MonthAggr";
        internal const string _str_WeekAggr = "WeekAggr";
        internal const string _str_AggregateMatrixVersionCase = "AggregateMatrixVersionCase";
        internal const string _str_AggregateMatrixVersionDiagnostic = "AggregateMatrixVersionDiagnostic";
        internal const string _str_AggregateMatrixVersionProphylactic = "AggregateMatrixVersionProphylactic";
        internal const string _str_AggregateMatrixVersionSanitary = "AggregateMatrixVersionSanitary";
        internal const string _str_FFTemplateCase = "FFTemplateCase";
        internal const string _str_FFTemplateDiagnostic = "FFTemplateDiagnostic";
        internal const string _str_FFTemplateProphylactic = "FFTemplateProphylactic";
        internal const string _str_FFTemplateSanitary = "FFTemplateSanitary";
        internal const string _str_Settings = "Settings";
        internal const string _str_FFPresenterCase = "FFPresenterCase";
        internal const string _str_FFPresenterDiagnostic = "FFPresenterDiagnostic";
        internal const string _str_FFPresenterProphylactic = "FFPresenterProphylactic";
        internal const string _str_FFPresenterSanitary = "FFPresenterSanitary";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfAggrCase, _formname = _str_idfAggrCase, _type = "Int64",
              _get_func = o => o.idfAggrCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfAggrCase != newval) o.idfAggrCase = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfAggrCase != c.idfAggrCase || o.IsRIRPropChanged(_str_idfAggrCase, c)) 
                  m.Add(_str_idfAggrCase, o.ObjectIdent + _str_idfAggrCase, o.ObjectIdent2 + _str_idfAggrCase, o.ObjectIdent3 + _str_idfAggrCase, "Int64", 
                    o.idfAggrCase == null ? "" : o.idfAggrCase.ToString(),                  
                  o.IsReadOnly(_str_idfAggrCase), o.IsInvisible(_str_idfAggrCase), o.IsRequired(_str_idfAggrCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAggrCaseType, _formname = _str_idfsAggrCaseType, _type = "Int64",
              _get_func = o => o.idfsAggrCaseType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsAggrCaseType != newval) o.idfsAggrCaseType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsAggrCaseType != c.idfsAggrCaseType || o.IsRIRPropChanged(_str_idfsAggrCaseType, c)) 
                  m.Add(_str_idfsAggrCaseType, o.ObjectIdent + _str_idfsAggrCaseType, o.ObjectIdent2 + _str_idfsAggrCaseType, o.ObjectIdent3 + _str_idfsAggrCaseType, "Int64", 
                    o.idfsAggrCaseType == null ? "" : o.idfsAggrCaseType.ToString(),                  
                  o.IsReadOnly(_str_idfsAggrCaseType), o.IsInvisible(_str_idfsAggrCaseType), o.IsRequired(_str_idfsAggrCaseType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHACode, _formname = _str_intHACode, _type = "Int32",
              _get_func = o => o.intHACode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intHACode != newval) o.intHACode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intHACode != c.intHACode || o.IsRIRPropChanged(_str_intHACode, c)) 
                  m.Add(_str_intHACode, o.ObjectIdent + _str_intHACode, o.ObjectIdent2 + _str_intHACode, o.ObjectIdent3 + _str_intHACode, "Int32", 
                    o.intHACode == null ? "" : o.intHACode.ToString(),                  
                  o.IsReadOnly(_str_intHACode), o.IsInvisible(_str_intHACode), o.IsRequired(_str_intHACode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsAdministrativeUnit, _formname = _str_idfsAdministrativeUnit, _type = "Int64",
              _get_func = o => o.idfsAdministrativeUnit,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsAdministrativeUnit != newval) o.idfsAdministrativeUnit = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsAdministrativeUnit != c.idfsAdministrativeUnit || o.IsRIRPropChanged(_str_idfsAdministrativeUnit, c)) 
                  m.Add(_str_idfsAdministrativeUnit, o.ObjectIdent + _str_idfsAdministrativeUnit, o.ObjectIdent2 + _str_idfsAdministrativeUnit, o.ObjectIdent3 + _str_idfsAdministrativeUnit, "Int64", 
                    o.idfsAdministrativeUnit == null ? "" : o.idfsAdministrativeUnit.ToString(),                  
                  o.IsReadOnly(_str_idfsAdministrativeUnit), o.IsInvisible(_str_idfsAdministrativeUnit), o.IsRequired(_str_idfsAdministrativeUnit)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfReceivedByOffice, _formname = _str_idfReceivedByOffice, _type = "Int64?",
              _get_func = o => o.idfReceivedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfReceivedByOffice != newval) 
                  o.ReceivedByOffice = o.ReceivedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfReceivedByOffice != newval) o.idfReceivedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfReceivedByOffice != c.idfReceivedByOffice || o.IsRIRPropChanged(_str_idfReceivedByOffice, c)) 
                  m.Add(_str_idfReceivedByOffice, o.ObjectIdent + _str_idfReceivedByOffice, o.ObjectIdent2 + _str_idfReceivedByOffice, o.ObjectIdent3 + _str_idfReceivedByOffice, "Int64?", 
                    o.idfReceivedByOffice == null ? "" : o.idfReceivedByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfReceivedByOffice), o.IsInvisible(_str_idfReceivedByOffice), o.IsRequired(_str_idfReceivedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfReceivedByPerson, _formname = _str_idfReceivedByPerson, _type = "Int64?",
              _get_func = o => o.idfReceivedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfReceivedByPerson != newval) 
                  o.ReceivedByPerson = o.ReceivedByPersonLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfReceivedByPerson != newval) o.idfReceivedByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfReceivedByPerson != c.idfReceivedByPerson || o.IsRIRPropChanged(_str_idfReceivedByPerson, c)) 
                  m.Add(_str_idfReceivedByPerson, o.ObjectIdent + _str_idfReceivedByPerson, o.ObjectIdent2 + _str_idfReceivedByPerson, o.ObjectIdent3 + _str_idfReceivedByPerson, "Int64?", 
                    o.idfReceivedByPerson == null ? "" : o.idfReceivedByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfReceivedByPerson), o.IsInvisible(_str_idfReceivedByPerson), o.IsRequired(_str_idfReceivedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strReceivedByOffice, _formname = _str_strReceivedByOffice, _type = "String",
              _get_func = o => o.strReceivedByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strReceivedByOffice != newval) o.strReceivedByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strReceivedByOffice != c.strReceivedByOffice || o.IsRIRPropChanged(_str_strReceivedByOffice, c)) 
                  m.Add(_str_strReceivedByOffice, o.ObjectIdent + _str_strReceivedByOffice, o.ObjectIdent2 + _str_strReceivedByOffice, o.ObjectIdent3 + _str_strReceivedByOffice, "String", 
                    o.strReceivedByOffice == null ? "" : o.strReceivedByOffice.ToString(),                  
                  o.IsReadOnly(_str_strReceivedByOffice), o.IsInvisible(_str_strReceivedByOffice), o.IsRequired(_str_strReceivedByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strReceivedByPerson, _formname = _str_strReceivedByPerson, _type = "String",
              _get_func = o => o.strReceivedByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strReceivedByPerson != newval) o.strReceivedByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strReceivedByPerson != c.strReceivedByPerson || o.IsRIRPropChanged(_str_strReceivedByPerson, c)) 
                  m.Add(_str_strReceivedByPerson, o.ObjectIdent + _str_strReceivedByPerson, o.ObjectIdent2 + _str_strReceivedByPerson, o.ObjectIdent3 + _str_strReceivedByPerson, "String", 
                    o.strReceivedByPerson == null ? "" : o.strReceivedByPerson.ToString(),                  
                  o.IsReadOnly(_str_strReceivedByPerson), o.IsInvisible(_str_strReceivedByPerson), o.IsRequired(_str_strReceivedByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSentByOffice, _formname = _str_idfSentByOffice, _type = "Int64",
              _get_func = o => o.idfSentByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfSentByOffice != newval) 
                  o.SentByOffice = o.SentByOfficeLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfSentByOffice != newval) o.idfSentByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfSentByOffice != c.idfSentByOffice || o.IsRIRPropChanged(_str_idfSentByOffice, c)) 
                  m.Add(_str_idfSentByOffice, o.ObjectIdent + _str_idfSentByOffice, o.ObjectIdent2 + _str_idfSentByOffice, o.ObjectIdent3 + _str_idfSentByOffice, "Int64", 
                    o.idfSentByOffice == null ? "" : o.idfSentByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfSentByOffice), o.IsInvisible(_str_idfSentByOffice), o.IsRequired(_str_idfSentByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSentByPerson, _formname = _str_idfSentByPerson, _type = "Int64",
              _get_func = o => o.idfSentByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfSentByPerson != newval) 
                  o.SentByPerson = o.SentByPersonLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfSentByPerson != newval) o.idfSentByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfSentByPerson != c.idfSentByPerson || o.IsRIRPropChanged(_str_idfSentByPerson, c)) 
                  m.Add(_str_idfSentByPerson, o.ObjectIdent + _str_idfSentByPerson, o.ObjectIdent2 + _str_idfSentByPerson, o.ObjectIdent3 + _str_idfSentByPerson, "Int64", 
                    o.idfSentByPerson == null ? "" : o.idfSentByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfSentByPerson), o.IsInvisible(_str_idfSentByPerson), o.IsRequired(_str_idfSentByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSentByOffice, _formname = _str_strSentByOffice, _type = "String",
              _get_func = o => o.strSentByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSentByOffice != newval) o.strSentByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSentByOffice != c.strSentByOffice || o.IsRIRPropChanged(_str_strSentByOffice, c)) 
                  m.Add(_str_strSentByOffice, o.ObjectIdent + _str_strSentByOffice, o.ObjectIdent2 + _str_strSentByOffice, o.ObjectIdent3 + _str_strSentByOffice, "String", 
                    o.strSentByOffice == null ? "" : o.strSentByOffice.ToString(),                  
                  o.IsReadOnly(_str_strSentByOffice), o.IsInvisible(_str_strSentByOffice), o.IsRequired(_str_strSentByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSentByPerson, _formname = _str_strSentByPerson, _type = "String",
              _get_func = o => o.strSentByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSentByPerson != newval) o.strSentByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSentByPerson != c.strSentByPerson || o.IsRIRPropChanged(_str_strSentByPerson, c)) 
                  m.Add(_str_strSentByPerson, o.ObjectIdent + _str_strSentByPerson, o.ObjectIdent2 + _str_strSentByPerson, o.ObjectIdent3 + _str_strSentByPerson, "String", 
                    o.strSentByPerson == null ? "" : o.strSentByPerson.ToString(),                  
                  o.IsReadOnly(_str_strSentByPerson), o.IsInvisible(_str_strSentByPerson), o.IsRequired(_str_strSentByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfEnteredByOffice, _formname = _str_idfEnteredByOffice, _type = "Int64",
              _get_func = o => o.idfEnteredByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfEnteredByOffice != newval) o.idfEnteredByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfEnteredByOffice != c.idfEnteredByOffice || o.IsRIRPropChanged(_str_idfEnteredByOffice, c)) 
                  m.Add(_str_idfEnteredByOffice, o.ObjectIdent + _str_idfEnteredByOffice, o.ObjectIdent2 + _str_idfEnteredByOffice, o.ObjectIdent3 + _str_idfEnteredByOffice, "Int64", 
                    o.idfEnteredByOffice == null ? "" : o.idfEnteredByOffice.ToString(),                  
                  o.IsReadOnly(_str_idfEnteredByOffice), o.IsInvisible(_str_idfEnteredByOffice), o.IsRequired(_str_idfEnteredByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfEnteredByPerson, _formname = _str_idfEnteredByPerson, _type = "Int64",
              _get_func = o => o.idfEnteredByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfEnteredByPerson != newval) o.idfEnteredByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfEnteredByPerson != c.idfEnteredByPerson || o.IsRIRPropChanged(_str_idfEnteredByPerson, c)) 
                  m.Add(_str_idfEnteredByPerson, o.ObjectIdent + _str_idfEnteredByPerson, o.ObjectIdent2 + _str_idfEnteredByPerson, o.ObjectIdent3 + _str_idfEnteredByPerson, "Int64", 
                    o.idfEnteredByPerson == null ? "" : o.idfEnteredByPerson.ToString(),                  
                  o.IsReadOnly(_str_idfEnteredByPerson), o.IsInvisible(_str_idfEnteredByPerson), o.IsRequired(_str_idfEnteredByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strEnteredByOffice, _formname = _str_strEnteredByOffice, _type = "String",
              _get_func = o => o.strEnteredByOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strEnteredByOffice != newval) o.strEnteredByOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strEnteredByOffice != c.strEnteredByOffice || o.IsRIRPropChanged(_str_strEnteredByOffice, c)) 
                  m.Add(_str_strEnteredByOffice, o.ObjectIdent + _str_strEnteredByOffice, o.ObjectIdent2 + _str_strEnteredByOffice, o.ObjectIdent3 + _str_strEnteredByOffice, "String", 
                    o.strEnteredByOffice == null ? "" : o.strEnteredByOffice.ToString(),                  
                  o.IsReadOnly(_str_strEnteredByOffice), o.IsInvisible(_str_strEnteredByOffice), o.IsRequired(_str_strEnteredByOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strEnteredByPerson, _formname = _str_strEnteredByPerson, _type = "String",
              _get_func = o => o.strEnteredByPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strEnteredByPerson != newval) o.strEnteredByPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strEnteredByPerson != c.strEnteredByPerson || o.IsRIRPropChanged(_str_strEnteredByPerson, c)) 
                  m.Add(_str_strEnteredByPerson, o.ObjectIdent + _str_strEnteredByPerson, o.ObjectIdent2 + _str_strEnteredByPerson, o.ObjectIdent3 + _str_strEnteredByPerson, "String", 
                    o.strEnteredByPerson == null ? "" : o.strEnteredByPerson.ToString(),                  
                  o.IsReadOnly(_str_strEnteredByPerson), o.IsInvisible(_str_strEnteredByPerson), o.IsRequired(_str_strEnteredByPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfCaseObservation, _formname = _str_idfCaseObservation, _type = "Int64?",
              _get_func = o => o.idfCaseObservation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfCaseObservation != newval) o.idfCaseObservation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfCaseObservation != c.idfCaseObservation || o.IsRIRPropChanged(_str_idfCaseObservation, c)) 
                  m.Add(_str_idfCaseObservation, o.ObjectIdent + _str_idfCaseObservation, o.ObjectIdent2 + _str_idfCaseObservation, o.ObjectIdent3 + _str_idfCaseObservation, "Int64?", 
                    o.idfCaseObservation == null ? "" : o.idfCaseObservation.ToString(),                  
                  o.IsReadOnly(_str_idfCaseObservation), o.IsInvisible(_str_idfCaseObservation), o.IsRequired(_str_idfCaseObservation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCaseObservationFormTemplate, _formname = _str_idfsCaseObservationFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsCaseObservationFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsCaseObservationFormTemplate != newval) 
                  o.FFTemplateCase = o.FFTemplateCaseLookup.FirstOrDefault(c => c.idfsFormTemplate == newval);
                if (o.idfsCaseObservationFormTemplate != newval) o.idfsCaseObservationFormTemplate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCaseObservationFormTemplate != c.idfsCaseObservationFormTemplate || o.IsRIRPropChanged(_str_idfsCaseObservationFormTemplate, c)) 
                  m.Add(_str_idfsCaseObservationFormTemplate, o.ObjectIdent + _str_idfsCaseObservationFormTemplate, o.ObjectIdent2 + _str_idfsCaseObservationFormTemplate, o.ObjectIdent3 + _str_idfsCaseObservationFormTemplate, "Int64?", 
                    o.idfsCaseObservationFormTemplate == null ? "" : o.idfsCaseObservationFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseObservationFormTemplate), o.IsInvisible(_str_idfsCaseObservationFormTemplate), o.IsRequired(_str_idfsCaseObservationFormTemplate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfDiagnosticObservation, _formname = _str_idfDiagnosticObservation, _type = "Int64?",
              _get_func = o => o.idfDiagnosticObservation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfDiagnosticObservation != newval) o.idfDiagnosticObservation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfDiagnosticObservation != c.idfDiagnosticObservation || o.IsRIRPropChanged(_str_idfDiagnosticObservation, c)) 
                  m.Add(_str_idfDiagnosticObservation, o.ObjectIdent + _str_idfDiagnosticObservation, o.ObjectIdent2 + _str_idfDiagnosticObservation, o.ObjectIdent3 + _str_idfDiagnosticObservation, "Int64?", 
                    o.idfDiagnosticObservation == null ? "" : o.idfDiagnosticObservation.ToString(),                  
                  o.IsReadOnly(_str_idfDiagnosticObservation), o.IsInvisible(_str_idfDiagnosticObservation), o.IsRequired(_str_idfDiagnosticObservation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosticObservationFormTemplate, _formname = _str_idfsDiagnosticObservationFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsDiagnosticObservationFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsDiagnosticObservationFormTemplate != newval) 
                  o.FFTemplateDiagnostic = o.FFTemplateDiagnosticLookup.FirstOrDefault(c => c.idfsFormTemplate == newval);
                if (o.idfsDiagnosticObservationFormTemplate != newval) o.idfsDiagnosticObservationFormTemplate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsDiagnosticObservationFormTemplate != c.idfsDiagnosticObservationFormTemplate || o.IsRIRPropChanged(_str_idfsDiagnosticObservationFormTemplate, c)) 
                  m.Add(_str_idfsDiagnosticObservationFormTemplate, o.ObjectIdent + _str_idfsDiagnosticObservationFormTemplate, o.ObjectIdent2 + _str_idfsDiagnosticObservationFormTemplate, o.ObjectIdent3 + _str_idfsDiagnosticObservationFormTemplate, "Int64?", 
                    o.idfsDiagnosticObservationFormTemplate == null ? "" : o.idfsDiagnosticObservationFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosticObservationFormTemplate), o.IsInvisible(_str_idfsDiagnosticObservationFormTemplate), o.IsRequired(_str_idfsDiagnosticObservationFormTemplate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfProphylacticObservation, _formname = _str_idfProphylacticObservation, _type = "Int64?",
              _get_func = o => o.idfProphylacticObservation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfProphylacticObservation != newval) o.idfProphylacticObservation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfProphylacticObservation != c.idfProphylacticObservation || o.IsRIRPropChanged(_str_idfProphylacticObservation, c)) 
                  m.Add(_str_idfProphylacticObservation, o.ObjectIdent + _str_idfProphylacticObservation, o.ObjectIdent2 + _str_idfProphylacticObservation, o.ObjectIdent3 + _str_idfProphylacticObservation, "Int64?", 
                    o.idfProphylacticObservation == null ? "" : o.idfProphylacticObservation.ToString(),                  
                  o.IsReadOnly(_str_idfProphylacticObservation), o.IsInvisible(_str_idfProphylacticObservation), o.IsRequired(_str_idfProphylacticObservation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsProphylacticObservationFormTemplate, _formname = _str_idfsProphylacticObservationFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsProphylacticObservationFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsProphylacticObservationFormTemplate != newval) 
                  o.FFTemplateProphylactic = o.FFTemplateProphylacticLookup.FirstOrDefault(c => c.idfsFormTemplate == newval);
                if (o.idfsProphylacticObservationFormTemplate != newval) o.idfsProphylacticObservationFormTemplate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsProphylacticObservationFormTemplate != c.idfsProphylacticObservationFormTemplate || o.IsRIRPropChanged(_str_idfsProphylacticObservationFormTemplate, c)) 
                  m.Add(_str_idfsProphylacticObservationFormTemplate, o.ObjectIdent + _str_idfsProphylacticObservationFormTemplate, o.ObjectIdent2 + _str_idfsProphylacticObservationFormTemplate, o.ObjectIdent3 + _str_idfsProphylacticObservationFormTemplate, "Int64?", 
                    o.idfsProphylacticObservationFormTemplate == null ? "" : o.idfsProphylacticObservationFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsProphylacticObservationFormTemplate), o.IsInvisible(_str_idfsProphylacticObservationFormTemplate), o.IsRequired(_str_idfsProphylacticObservationFormTemplate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSanitaryObservation, _formname = _str_idfSanitaryObservation, _type = "Int64?",
              _get_func = o => o.idfSanitaryObservation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfSanitaryObservation != newval) o.idfSanitaryObservation = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfSanitaryObservation != c.idfSanitaryObservation || o.IsRIRPropChanged(_str_idfSanitaryObservation, c)) 
                  m.Add(_str_idfSanitaryObservation, o.ObjectIdent + _str_idfSanitaryObservation, o.ObjectIdent2 + _str_idfSanitaryObservation, o.ObjectIdent3 + _str_idfSanitaryObservation, "Int64?", 
                    o.idfSanitaryObservation == null ? "" : o.idfSanitaryObservation.ToString(),                  
                  o.IsReadOnly(_str_idfSanitaryObservation), o.IsInvisible(_str_idfSanitaryObservation), o.IsRequired(_str_idfSanitaryObservation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSanitaryObservationFormTemplate, _formname = _str_idfsSanitaryObservationFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsSanitaryObservationFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsSanitaryObservationFormTemplate != newval) 
                  o.FFTemplateSanitary = o.FFTemplateSanitaryLookup.FirstOrDefault(c => c.idfsFormTemplate == newval);
                if (o.idfsSanitaryObservationFormTemplate != newval) o.idfsSanitaryObservationFormTemplate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSanitaryObservationFormTemplate != c.idfsSanitaryObservationFormTemplate || o.IsRIRPropChanged(_str_idfsSanitaryObservationFormTemplate, c)) 
                  m.Add(_str_idfsSanitaryObservationFormTemplate, o.ObjectIdent + _str_idfsSanitaryObservationFormTemplate, o.ObjectIdent2 + _str_idfsSanitaryObservationFormTemplate, o.ObjectIdent3 + _str_idfsSanitaryObservationFormTemplate, "Int64?", 
                    o.idfsSanitaryObservationFormTemplate == null ? "" : o.idfsSanitaryObservationFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsSanitaryObservationFormTemplate), o.IsInvisible(_str_idfsSanitaryObservationFormTemplate), o.IsRequired(_str_idfsSanitaryObservationFormTemplate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVersion, _formname = _str_idfVersion, _type = "Int64?",
              _get_func = o => o.idfVersion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfVersion != newval) 
                  o.AggregateMatrixVersionCase = o.AggregateMatrixVersionCaseLookup.FirstOrDefault(c => c.idfVersion == newval);
                if (o.idfVersion != newval) o.idfVersion = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVersion != c.idfVersion || o.IsRIRPropChanged(_str_idfVersion, c)) 
                  m.Add(_str_idfVersion, o.ObjectIdent + _str_idfVersion, o.ObjectIdent2 + _str_idfVersion, o.ObjectIdent3 + _str_idfVersion, "Int64?", 
                    o.idfVersion == null ? "" : o.idfVersion.ToString(),                  
                  o.IsReadOnly(_str_idfVersion), o.IsInvisible(_str_idfVersion), o.IsRequired(_str_idfVersion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfDiagnosticVersion, _formname = _str_idfDiagnosticVersion, _type = "Int64?",
              _get_func = o => o.idfDiagnosticVersion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfDiagnosticVersion != newval) 
                  o.AggregateMatrixVersionDiagnostic = o.AggregateMatrixVersionDiagnosticLookup.FirstOrDefault(c => c.idfVersion == newval);
                if (o.idfDiagnosticVersion != newval) o.idfDiagnosticVersion = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfDiagnosticVersion != c.idfDiagnosticVersion || o.IsRIRPropChanged(_str_idfDiagnosticVersion, c)) 
                  m.Add(_str_idfDiagnosticVersion, o.ObjectIdent + _str_idfDiagnosticVersion, o.ObjectIdent2 + _str_idfDiagnosticVersion, o.ObjectIdent3 + _str_idfDiagnosticVersion, "Int64?", 
                    o.idfDiagnosticVersion == null ? "" : o.idfDiagnosticVersion.ToString(),                  
                  o.IsReadOnly(_str_idfDiagnosticVersion), o.IsInvisible(_str_idfDiagnosticVersion), o.IsRequired(_str_idfDiagnosticVersion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfProphylacticVersion, _formname = _str_idfProphylacticVersion, _type = "Int64?",
              _get_func = o => o.idfProphylacticVersion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfProphylacticVersion != newval) 
                  o.AggregateMatrixVersionProphylactic = o.AggregateMatrixVersionProphylacticLookup.FirstOrDefault(c => c.idfVersion == newval);
                if (o.idfProphylacticVersion != newval) o.idfProphylacticVersion = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfProphylacticVersion != c.idfProphylacticVersion || o.IsRIRPropChanged(_str_idfProphylacticVersion, c)) 
                  m.Add(_str_idfProphylacticVersion, o.ObjectIdent + _str_idfProphylacticVersion, o.ObjectIdent2 + _str_idfProphylacticVersion, o.ObjectIdent3 + _str_idfProphylacticVersion, "Int64?", 
                    o.idfProphylacticVersion == null ? "" : o.idfProphylacticVersion.ToString(),                  
                  o.IsReadOnly(_str_idfProphylacticVersion), o.IsInvisible(_str_idfProphylacticVersion), o.IsRequired(_str_idfProphylacticVersion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSanitaryVersion, _formname = _str_idfSanitaryVersion, _type = "Int64?",
              _get_func = o => o.idfSanitaryVersion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfSanitaryVersion != newval) 
                  o.AggregateMatrixVersionSanitary = o.AggregateMatrixVersionSanitaryLookup.FirstOrDefault(c => c.idfVersion == newval);
                if (o.idfSanitaryVersion != newval) o.idfSanitaryVersion = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfSanitaryVersion != c.idfSanitaryVersion || o.IsRIRPropChanged(_str_idfSanitaryVersion, c)) 
                  m.Add(_str_idfSanitaryVersion, o.ObjectIdent + _str_idfSanitaryVersion, o.ObjectIdent2 + _str_idfSanitaryVersion, o.ObjectIdent3 + _str_idfSanitaryVersion, "Int64?", 
                    o.idfSanitaryVersion == null ? "" : o.idfSanitaryVersion.ToString(),                  
                  o.IsReadOnly(_str_idfSanitaryVersion), o.IsInvisible(_str_idfSanitaryVersion), o.IsRequired(_str_idfSanitaryVersion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datReceivedByDate, _formname = _str_datReceivedByDate, _type = "DateTime?",
              _get_func = o => o.datReceivedByDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datReceivedByDate != newval) o.datReceivedByDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datReceivedByDate != c.datReceivedByDate || o.IsRIRPropChanged(_str_datReceivedByDate, c)) 
                  m.Add(_str_datReceivedByDate, o.ObjectIdent + _str_datReceivedByDate, o.ObjectIdent2 + _str_datReceivedByDate, o.ObjectIdent3 + _str_datReceivedByDate, "DateTime?", 
                    o.datReceivedByDate == null ? "" : o.datReceivedByDate.ToString(),                  
                  o.IsReadOnly(_str_datReceivedByDate), o.IsInvisible(_str_datReceivedByDate), o.IsRequired(_str_datReceivedByDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datSentByDate, _formname = _str_datSentByDate, _type = "DateTime?",
              _get_func = o => o.datSentByDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datSentByDate != newval) o.datSentByDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datSentByDate != c.datSentByDate || o.IsRIRPropChanged(_str_datSentByDate, c)) 
                  m.Add(_str_datSentByDate, o.ObjectIdent + _str_datSentByDate, o.ObjectIdent2 + _str_datSentByDate, o.ObjectIdent3 + _str_datSentByDate, "DateTime?", 
                    o.datSentByDate == null ? "" : o.datSentByDate.ToString(),                  
                  o.IsReadOnly(_str_datSentByDate), o.IsInvisible(_str_datSentByDate), o.IsRequired(_str_datSentByDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datEnteredByDate, _formname = _str_datEnteredByDate, _type = "DateTime?",
              _get_func = o => o.datEnteredByDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datEnteredByDate != newval) o.datEnteredByDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datEnteredByDate != c.datEnteredByDate || o.IsRIRPropChanged(_str_datEnteredByDate, c)) 
                  m.Add(_str_datEnteredByDate, o.ObjectIdent + _str_datEnteredByDate, o.ObjectIdent2 + _str_datEnteredByDate, o.ObjectIdent3 + _str_datEnteredByDate, "DateTime?", 
                    o.datEnteredByDate == null ? "" : o.datEnteredByDate.ToString(),                  
                  o.IsReadOnly(_str_datEnteredByDate), o.IsInvisible(_str_datEnteredByDate), o.IsRequired(_str_datEnteredByDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datStartDate, _formname = _str_datStartDate, _type = "DateTime?",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datStartDate != newval) o.datStartDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, o.ObjectIdent2 + _str_datStartDate, o.ObjectIdent3 + _str_datStartDate, "DateTime?", 
                    o.datStartDate == null ? "" : o.datStartDate.ToString(),                  
                  o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datFinishDate, _formname = _str_datFinishDate, _type = "DateTime?",
              _get_func = o => o.datFinishDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datFinishDate != newval) o.datFinishDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datFinishDate != c.datFinishDate || o.IsRIRPropChanged(_str_datFinishDate, c)) 
                  m.Add(_str_datFinishDate, o.ObjectIdent + _str_datFinishDate, o.ObjectIdent2 + _str_datFinishDate, o.ObjectIdent3 + _str_datFinishDate, "DateTime?", 
                    o.datFinishDate == null ? "" : o.datFinishDate.ToString(),                  
                  o.IsReadOnly(_str_datFinishDate), o.IsInvisible(_str_datFinishDate), o.IsRequired(_str_datFinishDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCaseID, _formname = _str_strCaseID, _type = "String",
              _get_func = o => o.strCaseID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCaseID != newval) o.strCaseID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCaseID != c.strCaseID || o.IsRIRPropChanged(_str_strCaseID, c)) 
                  m.Add(_str_strCaseID, o.ObjectIdent + _str_strCaseID, o.ObjectIdent2 + _str_strCaseID, o.ObjectIdent3 + _str_strCaseID, "String", 
                    o.strCaseID == null ? "" : o.strCaseID.ToString(),                  
                  o.IsReadOnly(_str_strCaseID), o.IsInvisible(_str_strCaseID), o.IsRequired(_str_strCaseID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_YearForAggr, _formname = _str_YearForAggr, _type = "Int64?",
              _get_func = o => o.YearForAggr,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.YearForAggr != newval) 
                  o.YearAggr = o.YearAggrLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.YearForAggr != newval) o.YearForAggr = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.YearForAggr != c.YearForAggr || o.IsRIRPropChanged(_str_YearForAggr, c)) 
                  m.Add(_str_YearForAggr, o.ObjectIdent + _str_YearForAggr, o.ObjectIdent2 + _str_YearForAggr, o.ObjectIdent3 + _str_YearForAggr, "Int64?", 
                    o.YearForAggr == null ? "" : o.YearForAggr.ToString(),                  
                  o.IsReadOnly(_str_YearForAggr), o.IsInvisible(_str_YearForAggr), o.IsRequired(_str_YearForAggr)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_QuarterForAggr, _formname = _str_QuarterForAggr, _type = "Int64?",
              _get_func = o => o.QuarterForAggr,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.QuarterForAggr != newval) 
                  o.QuarterAggr = o.QuarterAggrLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.QuarterForAggr != newval) o.QuarterForAggr = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.QuarterForAggr != c.QuarterForAggr || o.IsRIRPropChanged(_str_QuarterForAggr, c)) 
                  m.Add(_str_QuarterForAggr, o.ObjectIdent + _str_QuarterForAggr, o.ObjectIdent2 + _str_QuarterForAggr, o.ObjectIdent3 + _str_QuarterForAggr, "Int64?", 
                    o.QuarterForAggr == null ? "" : o.QuarterForAggr.ToString(),                  
                  o.IsReadOnly(_str_QuarterForAggr), o.IsInvisible(_str_QuarterForAggr), o.IsRequired(_str_QuarterForAggr)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_MonthForAggr, _formname = _str_MonthForAggr, _type = "Int64?",
              _get_func = o => o.MonthForAggr,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.MonthForAggr != newval) 
                  o.MonthAggr = o.MonthAggrLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.MonthForAggr != newval) o.MonthForAggr = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.MonthForAggr != c.MonthForAggr || o.IsRIRPropChanged(_str_MonthForAggr, c)) 
                  m.Add(_str_MonthForAggr, o.ObjectIdent + _str_MonthForAggr, o.ObjectIdent2 + _str_MonthForAggr, o.ObjectIdent3 + _str_MonthForAggr, "Int64?", 
                    o.MonthForAggr == null ? "" : o.MonthForAggr.ToString(),                  
                  o.IsReadOnly(_str_MonthForAggr), o.IsInvisible(_str_MonthForAggr), o.IsRequired(_str_MonthForAggr)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_WeekForAggr, _formname = _str_WeekForAggr, _type = "Int64?",
              _get_func = o => o.WeekForAggr,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.WeekForAggr != newval) 
                  o.WeekAggr = o.WeekAggrLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.WeekForAggr != newval) o.WeekForAggr = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.WeekForAggr != c.WeekForAggr || o.IsRIRPropChanged(_str_WeekForAggr, c)) 
                  m.Add(_str_WeekForAggr, o.ObjectIdent + _str_WeekForAggr, o.ObjectIdent2 + _str_WeekForAggr, o.ObjectIdent3 + _str_WeekForAggr, "Int64?", 
                    o.WeekForAggr == null ? "" : o.WeekForAggr.ToString(),                  
                  o.IsReadOnly(_str_WeekForAggr), o.IsInvisible(_str_WeekForAggr), o.IsRequired(_str_WeekForAggr)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DayForAggr, _formname = _str_DayForAggr, _type = "DateTime?",
              _get_func = o => o.DayForAggr,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.DayForAggr != newval) o.DayForAggr = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DayForAggr != c.DayForAggr || o.IsRIRPropChanged(_str_DayForAggr, c)) 
                  m.Add(_str_DayForAggr, o.ObjectIdent + _str_DayForAggr, o.ObjectIdent2 + _str_DayForAggr, o.ObjectIdent3 + _str_DayForAggr, "DateTime?", 
                    o.DayForAggr == null ? "" : o.DayForAggr.ToString(),                  
                  o.IsReadOnly(_str_DayForAggr), o.IsInvisible(_str_DayForAggr), o.IsRequired(_str_DayForAggr)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCountry, _formname = _str_idfsCountry, _type = "Int64?",
              _get_func = o => o.idfsCountry,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsCountry != newval) 
                  o.Country = o.CountryLookup.FirstOrDefault(c => c.idfsCountry == newval);
                if (o.idfsCountry != newval) o.idfsCountry = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_idfsCountry, c)) 
                  m.Add(_str_idfsCountry, o.ObjectIdent + _str_idfsCountry, o.ObjectIdent2 + _str_idfsCountry, o.ObjectIdent3 + _str_idfsCountry, "Int64?", 
                    o.idfsCountry == null ? "" : o.idfsCountry.ToString(),                  
                  o.IsReadOnly(_str_idfsCountry), o.IsInvisible(_str_idfsCountry), o.IsRequired(_str_idfsCountry)); 
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
              _name = _str_idfsSettlement, _formname = _str_idfsSettlement, _type = "Int64?",
              _get_func = o => o.idfsSettlement,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsSettlement != newval) 
                  o.Settlement = o.SettlementLookup.FirstOrDefault(c => c.idfsSettlement == newval);
                if (o.idfsSettlement != newval) o.idfsSettlement = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_idfsSettlement, c)) 
                  m.Add(_str_idfsSettlement, o.ObjectIdent + _str_idfsSettlement, o.ObjectIdent2 + _str_idfsSettlement, o.ObjectIdent3 + _str_idfsSettlement, "Int64?", 
                    o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(),                  
                  o.IsReadOnly(_str_idfsSettlement), o.IsInvisible(_str_idfsSettlement), o.IsRequired(_str_idfsSettlement)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_CurPeriodType, _formname = _str_CurPeriodType, _type = "Int64?",
              _get_func = o => o.CurPeriodType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.CurPeriodType != newval) o.CurPeriodType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.CurPeriodType != c.CurPeriodType || o.IsRIRPropChanged(_str_CurPeriodType, c)) 
                  m.Add(_str_CurPeriodType, o.ObjectIdent + _str_CurPeriodType, o.ObjectIdent2 + _str_CurPeriodType, o.ObjectIdent3 + _str_CurPeriodType, "Int64?", 
                    o.CurPeriodType == null ? "" : o.CurPeriodType.ToString(),                  
                  o.IsReadOnly(_str_CurPeriodType), o.IsInvisible(_str_CurPeriodType), o.IsRequired(_str_CurPeriodType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_CurAreaType, _formname = _str_CurAreaType, _type = "Int64?",
              _get_func = o => o.CurAreaType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.CurAreaType != newval) o.CurAreaType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.CurAreaType != c.CurAreaType || o.IsRIRPropChanged(_str_CurAreaType, c)) 
                  m.Add(_str_CurAreaType, o.ObjectIdent + _str_CurAreaType, o.ObjectIdent2 + _str_CurAreaType, o.ObjectIdent3 + _str_CurAreaType, "Int64?", 
                    o.CurAreaType == null ? "" : o.CurAreaType.ToString(),                  
                  o.IsReadOnly(_str_CurAreaType), o.IsInvisible(_str_CurAreaType), o.IsRequired(_str_CurAreaType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datModificationForArchiveDate, _formname = _str_datModificationForArchiveDate, _type = "DateTime?",
              _get_func = o => o.datModificationForArchiveDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datModificationForArchiveDate != newval) o.datModificationForArchiveDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datModificationForArchiveDate != c.datModificationForArchiveDate || o.IsRIRPropChanged(_str_datModificationForArchiveDate, c)) 
                  m.Add(_str_datModificationForArchiveDate, o.ObjectIdent + _str_datModificationForArchiveDate, o.ObjectIdent2 + _str_datModificationForArchiveDate, o.ObjectIdent3 + _str_datModificationForArchiveDate, "DateTime?", 
                    o.datModificationForArchiveDate == null ? "" : o.datModificationForArchiveDate.ToString(),                  
                  o.IsReadOnly(_str_datModificationForArchiveDate), o.IsInvisible(_str_datModificationForArchiveDate), o.IsRequired(_str_datModificationForArchiveDate)); 
                  }
              }, 
        
            new field_info {
              _name = _str_NumberingObject, _formname = _str_NumberingObject, _type = "long",
              _get_func = o => o.NumberingObject,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.NumberingObject != c.NumberingObject || o.IsRIRPropChanged(_str_NumberingObject, c)) {
                  m.Add(_str_NumberingObject, o.ObjectIdent + _str_NumberingObject, o.ObjectIdent2 + _str_NumberingObject, o.ObjectIdent3 + _str_NumberingObject, "long", o.NumberingObject == null ? "" : o.NumberingObject.ToString(), o.IsReadOnly(_str_NumberingObject), o.IsInvisible(_str_NumberingObject), o.IsRequired(_str_NumberingObject));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_idfsAdministrativeUnitCalc, _formname = _str_idfsAdministrativeUnitCalc, _type = "long",
              _get_func = o => o.idfsAdministrativeUnitCalc,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.idfsAdministrativeUnitCalc != c.idfsAdministrativeUnitCalc || o.IsRIRPropChanged(_str_idfsAdministrativeUnitCalc, c)) {
                  m.Add(_str_idfsAdministrativeUnitCalc, o.ObjectIdent + _str_idfsAdministrativeUnitCalc, o.ObjectIdent2 + _str_idfsAdministrativeUnitCalc, o.ObjectIdent3 + _str_idfsAdministrativeUnitCalc, "long", o.idfsAdministrativeUnitCalc == null ? "" : o.idfsAdministrativeUnitCalc.ToString(), o.IsReadOnly(_str_idfsAdministrativeUnitCalc), o.IsInvisible(_str_idfsAdministrativeUnitCalc), o.IsRequired(_str_idfsAdministrativeUnitCalc));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_datStartDateCalc, _formname = _str_datStartDateCalc, _type = "DateTime?",
              _get_func = o => o.datStartDateCalc,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.datStartDateCalc != c.datStartDateCalc || o.IsRIRPropChanged(_str_datStartDateCalc, c)) {
                  m.Add(_str_datStartDateCalc, o.ObjectIdent + _str_datStartDateCalc, o.ObjectIdent2 + _str_datStartDateCalc, o.ObjectIdent3 + _str_datStartDateCalc, "DateTime?", o.datStartDateCalc == null ? "" : o.datStartDateCalc.ToString(), o.IsReadOnly(_str_datStartDateCalc), o.IsInvisible(_str_datStartDateCalc), o.IsRequired(_str_datStartDateCalc));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_datFinishDateCalc, _formname = _str_datFinishDateCalc, _type = "DateTime?",
              _get_func = o => o.datFinishDateCalc,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.datFinishDateCalc != c.datFinishDateCalc || o.IsRIRPropChanged(_str_datFinishDateCalc, c)) {
                  m.Add(_str_datFinishDateCalc, o.ObjectIdent + _str_datFinishDateCalc, o.ObjectIdent2 + _str_datFinishDateCalc, o.ObjectIdent3 + _str_datFinishDateCalc, "DateTime?", o.datFinishDateCalc == null ? "" : o.datFinishDateCalc.ToString(), o.IsReadOnly(_str_datFinishDateCalc), o.IsInvisible(_str_datFinishDateCalc), o.IsRequired(_str_datFinishDateCalc));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyEnteredByDate, _formname = _str_strReadOnlyEnteredByDate, _type = "string",
              _get_func = o => o.strReadOnlyEnteredByDate,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strReadOnlyEnteredByDate != c.strReadOnlyEnteredByDate || o.IsRIRPropChanged(_str_strReadOnlyEnteredByDate, c)) {
                  m.Add(_str_strReadOnlyEnteredByDate, o.ObjectIdent + _str_strReadOnlyEnteredByDate, o.ObjectIdent2 + _str_strReadOnlyEnteredByDate, o.ObjectIdent3 + _str_strReadOnlyEnteredByDate, "string", o.strReadOnlyEnteredByDate == null ? "" : o.strReadOnlyEnteredByDate.ToString(), o.IsReadOnly(_str_strReadOnlyEnteredByDate), o.IsInvisible(_str_strReadOnlyEnteredByDate), o.IsRequired(_str_strReadOnlyEnteredByDate));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Country, _formname = _str_Country, _type = "Lookup",
              _get_func = o => { if (o.Country == null) return null; return o.Country.idfsCountry; },
              _set_func = (o, val) => { o.Country = o.CountryLookup.Where(c => c.idfsCountry.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Country, c);
                if (o.idfsCountry != c.idfsCountry || o.IsRIRPropChanged(_str_Country, c) || bChangeLookupContent) {
                  m.Add(_str_Country, o.ObjectIdent + _str_Country, o.ObjectIdent2 + _str_Country, o.ObjectIdent3 + _str_Country, "Lookup", o.idfsCountry == null ? "" : o.idfsCountry.ToString(), o.IsReadOnly(_str_Country), o.IsInvisible(_str_Country), o.IsRequired(_str_Country),
                  bChangeLookupContent ? o.CountryLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Country + "Lookup", _formname = _str_Country + "Lookup", _type = "LookupContent",
              _get_func = o => o.CountryLookup,
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
        
            new field_info {
              _name = _str_Settlement, _formname = _str_Settlement, _type = "Lookup",
              _get_func = o => { if (o.Settlement == null) return null; return o.Settlement.idfsSettlement; },
              _set_func = (o, val) => { o.Settlement = o.SettlementLookup.Where(c => c.idfsSettlement.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Settlement, c);
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_Settlement, c) || bChangeLookupContent) {
                  m.Add(_str_Settlement, o.ObjectIdent + _str_Settlement, o.ObjectIdent2 + _str_Settlement, o.ObjectIdent3 + _str_Settlement, "Lookup", o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(), o.IsReadOnly(_str_Settlement), o.IsInvisible(_str_Settlement), o.IsRequired(_str_Settlement),
                  bChangeLookupContent ? o.SettlementLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Settlement + "Lookup", _formname = _str_Settlement + "Lookup", _type = "LookupContent",
              _get_func = o => o.SettlementLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_SentByOffice, _formname = _str_SentByOffice, _type = "Lookup",
              _get_func = o => { if (o.SentByOffice == null) return null; return o.SentByOffice.idfInstitution; },
              _set_func = (o, val) => { o.SentByOffice = o.SentByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_SentByOffice, c);
                if (o.idfSentByOffice != c.idfSentByOffice || o.IsRIRPropChanged(_str_SentByOffice, c) || bChangeLookupContent) {
                  m.Add(_str_SentByOffice, o.ObjectIdent + _str_SentByOffice, o.ObjectIdent2 + _str_SentByOffice, o.ObjectIdent3 + _str_SentByOffice, "Lookup", o.idfSentByOffice == null ? "" : o.idfSentByOffice.ToString(), o.IsReadOnly(_str_SentByOffice), o.IsInvisible(_str_SentByOffice), o.IsRequired(_str_SentByOffice),
                  bChangeLookupContent ? o.SentByOfficeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_SentByOffice + "Lookup", _formname = _str_SentByOffice + "Lookup", _type = "LookupContent",
              _get_func = o => o.SentByOfficeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_ReceivedByOffice, _formname = _str_ReceivedByOffice, _type = "Lookup",
              _get_func = o => { if (o.ReceivedByOffice == null) return null; return o.ReceivedByOffice.idfInstitution; },
              _set_func = (o, val) => { o.ReceivedByOffice = o.ReceivedByOfficeLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_ReceivedByOffice, c);
                if (o.idfReceivedByOffice != c.idfReceivedByOffice || o.IsRIRPropChanged(_str_ReceivedByOffice, c) || bChangeLookupContent) {
                  m.Add(_str_ReceivedByOffice, o.ObjectIdent + _str_ReceivedByOffice, o.ObjectIdent2 + _str_ReceivedByOffice, o.ObjectIdent3 + _str_ReceivedByOffice, "Lookup", o.idfReceivedByOffice == null ? "" : o.idfReceivedByOffice.ToString(), o.IsReadOnly(_str_ReceivedByOffice), o.IsInvisible(_str_ReceivedByOffice), o.IsRequired(_str_ReceivedByOffice),
                  bChangeLookupContent ? o.ReceivedByOfficeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_ReceivedByOffice + "Lookup", _formname = _str_ReceivedByOffice + "Lookup", _type = "LookupContent",
              _get_func = o => o.ReceivedByOfficeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_SentByPerson, _formname = _str_SentByPerson, _type = "Lookup",
              _get_func = o => { if (o.SentByPerson == null) return null; return o.SentByPerson.idfPerson; },
              _set_func = (o, val) => { o.SentByPerson = o.SentByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_SentByPerson, c);
                if (o.idfSentByPerson != c.idfSentByPerson || o.IsRIRPropChanged(_str_SentByPerson, c) || bChangeLookupContent) {
                  m.Add(_str_SentByPerson, o.ObjectIdent + _str_SentByPerson, o.ObjectIdent2 + _str_SentByPerson, o.ObjectIdent3 + _str_SentByPerson, "Lookup", o.idfSentByPerson == null ? "" : o.idfSentByPerson.ToString(), o.IsReadOnly(_str_SentByPerson), o.IsInvisible(_str_SentByPerson), o.IsRequired(_str_SentByPerson),
                  bChangeLookupContent ? o.SentByPersonLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_SentByPerson + "Lookup", _formname = _str_SentByPerson + "Lookup", _type = "LookupContent",
              _get_func = o => o.SentByPersonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_ReceivedByPerson, _formname = _str_ReceivedByPerson, _type = "Lookup",
              _get_func = o => { if (o.ReceivedByPerson == null) return null; return o.ReceivedByPerson.idfPerson; },
              _set_func = (o, val) => { o.ReceivedByPerson = o.ReceivedByPersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_ReceivedByPerson, c);
                if (o.idfReceivedByPerson != c.idfReceivedByPerson || o.IsRIRPropChanged(_str_ReceivedByPerson, c) || bChangeLookupContent) {
                  m.Add(_str_ReceivedByPerson, o.ObjectIdent + _str_ReceivedByPerson, o.ObjectIdent2 + _str_ReceivedByPerson, o.ObjectIdent3 + _str_ReceivedByPerson, "Lookup", o.idfReceivedByPerson == null ? "" : o.idfReceivedByPerson.ToString(), o.IsReadOnly(_str_ReceivedByPerson), o.IsInvisible(_str_ReceivedByPerson), o.IsRequired(_str_ReceivedByPerson),
                  bChangeLookupContent ? o.ReceivedByPersonLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_ReceivedByPerson + "Lookup", _formname = _str_ReceivedByPerson + "Lookup", _type = "LookupContent",
              _get_func = o => o.ReceivedByPersonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_YearAggr, _formname = _str_YearAggr, _type = "Lookup",
              _get_func = o => { if (o.YearAggr == null) return null; return o.YearAggr.idfsBaseReference; },
              _set_func = (o, val) => { o.YearAggr = o.YearAggrLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_YearAggr, c);
                if (o.YearForAggr != c.YearForAggr || o.IsRIRPropChanged(_str_YearAggr, c) || bChangeLookupContent) {
                  m.Add(_str_YearAggr, o.ObjectIdent + _str_YearAggr, o.ObjectIdent2 + _str_YearAggr, o.ObjectIdent3 + _str_YearAggr, "Lookup", o.YearForAggr == null ? "" : o.YearForAggr.ToString(), o.IsReadOnly(_str_YearAggr), o.IsInvisible(_str_YearAggr), o.IsRequired(_str_YearAggr),
                  bChangeLookupContent ? o.YearAggrLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_YearAggr + "Lookup", _formname = _str_YearAggr + "Lookup", _type = "LookupContent",
              _get_func = o => o.YearAggrLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_QuarterAggr, _formname = _str_QuarterAggr, _type = "Lookup",
              _get_func = o => { if (o.QuarterAggr == null) return null; return o.QuarterAggr.idfsBaseReference; },
              _set_func = (o, val) => { o.QuarterAggr = o.QuarterAggrLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_QuarterAggr, c);
                if (o.QuarterForAggr != c.QuarterForAggr || o.IsRIRPropChanged(_str_QuarterAggr, c) || bChangeLookupContent) {
                  m.Add(_str_QuarterAggr, o.ObjectIdent + _str_QuarterAggr, o.ObjectIdent2 + _str_QuarterAggr, o.ObjectIdent3 + _str_QuarterAggr, "Lookup", o.QuarterForAggr == null ? "" : o.QuarterForAggr.ToString(), o.IsReadOnly(_str_QuarterAggr), o.IsInvisible(_str_QuarterAggr), o.IsRequired(_str_QuarterAggr),
                  bChangeLookupContent ? o.QuarterAggrLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_QuarterAggr + "Lookup", _formname = _str_QuarterAggr + "Lookup", _type = "LookupContent",
              _get_func = o => o.QuarterAggrLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_MonthAggr, _formname = _str_MonthAggr, _type = "Lookup",
              _get_func = o => { if (o.MonthAggr == null) return null; return o.MonthAggr.idfsBaseReference; },
              _set_func = (o, val) => { o.MonthAggr = o.MonthAggrLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_MonthAggr, c);
                if (o.MonthForAggr != c.MonthForAggr || o.IsRIRPropChanged(_str_MonthAggr, c) || bChangeLookupContent) {
                  m.Add(_str_MonthAggr, o.ObjectIdent + _str_MonthAggr, o.ObjectIdent2 + _str_MonthAggr, o.ObjectIdent3 + _str_MonthAggr, "Lookup", o.MonthForAggr == null ? "" : o.MonthForAggr.ToString(), o.IsReadOnly(_str_MonthAggr), o.IsInvisible(_str_MonthAggr), o.IsRequired(_str_MonthAggr),
                  bChangeLookupContent ? o.MonthAggrLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_MonthAggr + "Lookup", _formname = _str_MonthAggr + "Lookup", _type = "LookupContent",
              _get_func = o => o.MonthAggrLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_WeekAggr, _formname = _str_WeekAggr, _type = "Lookup",
              _get_func = o => { if (o.WeekAggr == null) return null; return o.WeekAggr.idfsBaseReference; },
              _set_func = (o, val) => { o.WeekAggr = o.WeekAggrLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_WeekAggr, c);
                if (o.WeekForAggr != c.WeekForAggr || o.IsRIRPropChanged(_str_WeekAggr, c) || bChangeLookupContent) {
                  m.Add(_str_WeekAggr, o.ObjectIdent + _str_WeekAggr, o.ObjectIdent2 + _str_WeekAggr, o.ObjectIdent3 + _str_WeekAggr, "Lookup", o.WeekForAggr == null ? "" : o.WeekForAggr.ToString(), o.IsReadOnly(_str_WeekAggr), o.IsInvisible(_str_WeekAggr), o.IsRequired(_str_WeekAggr),
                  bChangeLookupContent ? o.WeekAggrLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_WeekAggr + "Lookup", _formname = _str_WeekAggr + "Lookup", _type = "LookupContent",
              _get_func = o => o.WeekAggrLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_AggregateMatrixVersionCase, _formname = _str_AggregateMatrixVersionCase, _type = "Lookup",
              _get_func = o => { if (o.AggregateMatrixVersionCase == null) return null; return o.AggregateMatrixVersionCase.idfVersion; },
              _set_func = (o, val) => { o.AggregateMatrixVersionCase = o.AggregateMatrixVersionCaseLookup.Where(c => c.idfVersion.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AggregateMatrixVersionCase, c);
                if (o.idfVersion != c.idfVersion || o.IsRIRPropChanged(_str_AggregateMatrixVersionCase, c) || bChangeLookupContent) {
                  m.Add(_str_AggregateMatrixVersionCase, o.ObjectIdent + _str_AggregateMatrixVersionCase, o.ObjectIdent2 + _str_AggregateMatrixVersionCase, o.ObjectIdent3 + _str_AggregateMatrixVersionCase, "Lookup", o.idfVersion == null ? "" : o.idfVersion.ToString(), o.IsReadOnly(_str_AggregateMatrixVersionCase), o.IsInvisible(_str_AggregateMatrixVersionCase), o.IsRequired(_str_AggregateMatrixVersionCase),
                  bChangeLookupContent ? o.AggregateMatrixVersionCaseLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AggregateMatrixVersionCase + "Lookup", _formname = _str_AggregateMatrixVersionCase + "Lookup", _type = "LookupContent",
              _get_func = o => o.AggregateMatrixVersionCaseLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_AggregateMatrixVersionDiagnostic, _formname = _str_AggregateMatrixVersionDiagnostic, _type = "Lookup",
              _get_func = o => { if (o.AggregateMatrixVersionDiagnostic == null) return null; return o.AggregateMatrixVersionDiagnostic.idfVersion; },
              _set_func = (o, val) => { o.AggregateMatrixVersionDiagnostic = o.AggregateMatrixVersionDiagnosticLookup.Where(c => c.idfVersion.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AggregateMatrixVersionDiagnostic, c);
                if (o.idfDiagnosticVersion != c.idfDiagnosticVersion || o.IsRIRPropChanged(_str_AggregateMatrixVersionDiagnostic, c) || bChangeLookupContent) {
                  m.Add(_str_AggregateMatrixVersionDiagnostic, o.ObjectIdent + _str_AggregateMatrixVersionDiagnostic, o.ObjectIdent2 + _str_AggregateMatrixVersionDiagnostic, o.ObjectIdent3 + _str_AggregateMatrixVersionDiagnostic, "Lookup", o.idfDiagnosticVersion == null ? "" : o.idfDiagnosticVersion.ToString(), o.IsReadOnly(_str_AggregateMatrixVersionDiagnostic), o.IsInvisible(_str_AggregateMatrixVersionDiagnostic), o.IsRequired(_str_AggregateMatrixVersionDiagnostic),
                  bChangeLookupContent ? o.AggregateMatrixVersionDiagnosticLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AggregateMatrixVersionDiagnostic + "Lookup", _formname = _str_AggregateMatrixVersionDiagnostic + "Lookup", _type = "LookupContent",
              _get_func = o => o.AggregateMatrixVersionDiagnosticLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_AggregateMatrixVersionProphylactic, _formname = _str_AggregateMatrixVersionProphylactic, _type = "Lookup",
              _get_func = o => { if (o.AggregateMatrixVersionProphylactic == null) return null; return o.AggregateMatrixVersionProphylactic.idfVersion; },
              _set_func = (o, val) => { o.AggregateMatrixVersionProphylactic = o.AggregateMatrixVersionProphylacticLookup.Where(c => c.idfVersion.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AggregateMatrixVersionProphylactic, c);
                if (o.idfProphylacticVersion != c.idfProphylacticVersion || o.IsRIRPropChanged(_str_AggregateMatrixVersionProphylactic, c) || bChangeLookupContent) {
                  m.Add(_str_AggregateMatrixVersionProphylactic, o.ObjectIdent + _str_AggregateMatrixVersionProphylactic, o.ObjectIdent2 + _str_AggregateMatrixVersionProphylactic, o.ObjectIdent3 + _str_AggregateMatrixVersionProphylactic, "Lookup", o.idfProphylacticVersion == null ? "" : o.idfProphylacticVersion.ToString(), o.IsReadOnly(_str_AggregateMatrixVersionProphylactic), o.IsInvisible(_str_AggregateMatrixVersionProphylactic), o.IsRequired(_str_AggregateMatrixVersionProphylactic),
                  bChangeLookupContent ? o.AggregateMatrixVersionProphylacticLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AggregateMatrixVersionProphylactic + "Lookup", _formname = _str_AggregateMatrixVersionProphylactic + "Lookup", _type = "LookupContent",
              _get_func = o => o.AggregateMatrixVersionProphylacticLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_AggregateMatrixVersionSanitary, _formname = _str_AggregateMatrixVersionSanitary, _type = "Lookup",
              _get_func = o => { if (o.AggregateMatrixVersionSanitary == null) return null; return o.AggregateMatrixVersionSanitary.idfVersion; },
              _set_func = (o, val) => { o.AggregateMatrixVersionSanitary = o.AggregateMatrixVersionSanitaryLookup.Where(c => c.idfVersion.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AggregateMatrixVersionSanitary, c);
                if (o.idfSanitaryVersion != c.idfSanitaryVersion || o.IsRIRPropChanged(_str_AggregateMatrixVersionSanitary, c) || bChangeLookupContent) {
                  m.Add(_str_AggregateMatrixVersionSanitary, o.ObjectIdent + _str_AggregateMatrixVersionSanitary, o.ObjectIdent2 + _str_AggregateMatrixVersionSanitary, o.ObjectIdent3 + _str_AggregateMatrixVersionSanitary, "Lookup", o.idfSanitaryVersion == null ? "" : o.idfSanitaryVersion.ToString(), o.IsReadOnly(_str_AggregateMatrixVersionSanitary), o.IsInvisible(_str_AggregateMatrixVersionSanitary), o.IsRequired(_str_AggregateMatrixVersionSanitary),
                  bChangeLookupContent ? o.AggregateMatrixVersionSanitaryLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AggregateMatrixVersionSanitary + "Lookup", _formname = _str_AggregateMatrixVersionSanitary + "Lookup", _type = "LookupContent",
              _get_func = o => o.AggregateMatrixVersionSanitaryLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_FFTemplateCase, _formname = _str_FFTemplateCase, _type = "Lookup",
              _get_func = o => { if (o.FFTemplateCase == null) return null; return o.FFTemplateCase.idfsFormTemplate; },
              _set_func = (o, val) => { o.FFTemplateCase = o.FFTemplateCaseLookup.Where(c => c.idfsFormTemplate.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_FFTemplateCase, c);
                if (o.idfsCaseObservationFormTemplate != c.idfsCaseObservationFormTemplate || o.IsRIRPropChanged(_str_FFTemplateCase, c) || bChangeLookupContent) {
                  m.Add(_str_FFTemplateCase, o.ObjectIdent + _str_FFTemplateCase, o.ObjectIdent2 + _str_FFTemplateCase, o.ObjectIdent3 + _str_FFTemplateCase, "Lookup", o.idfsCaseObservationFormTemplate == null ? "" : o.idfsCaseObservationFormTemplate.ToString(), o.IsReadOnly(_str_FFTemplateCase), o.IsInvisible(_str_FFTemplateCase), o.IsRequired(_str_FFTemplateCase),
                  bChangeLookupContent ? o.FFTemplateCaseLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_FFTemplateCase + "Lookup", _formname = _str_FFTemplateCase + "Lookup", _type = "LookupContent",
              _get_func = o => o.FFTemplateCaseLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_FFTemplateDiagnostic, _formname = _str_FFTemplateDiagnostic, _type = "Lookup",
              _get_func = o => { if (o.FFTemplateDiagnostic == null) return null; return o.FFTemplateDiagnostic.idfsFormTemplate; },
              _set_func = (o, val) => { o.FFTemplateDiagnostic = o.FFTemplateDiagnosticLookup.Where(c => c.idfsFormTemplate.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_FFTemplateDiagnostic, c);
                if (o.idfsDiagnosticObservationFormTemplate != c.idfsDiagnosticObservationFormTemplate || o.IsRIRPropChanged(_str_FFTemplateDiagnostic, c) || bChangeLookupContent) {
                  m.Add(_str_FFTemplateDiagnostic, o.ObjectIdent + _str_FFTemplateDiagnostic, o.ObjectIdent2 + _str_FFTemplateDiagnostic, o.ObjectIdent3 + _str_FFTemplateDiagnostic, "Lookup", o.idfsDiagnosticObservationFormTemplate == null ? "" : o.idfsDiagnosticObservationFormTemplate.ToString(), o.IsReadOnly(_str_FFTemplateDiagnostic), o.IsInvisible(_str_FFTemplateDiagnostic), o.IsRequired(_str_FFTemplateDiagnostic),
                  bChangeLookupContent ? o.FFTemplateDiagnosticLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_FFTemplateDiagnostic + "Lookup", _formname = _str_FFTemplateDiagnostic + "Lookup", _type = "LookupContent",
              _get_func = o => o.FFTemplateDiagnosticLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_FFTemplateProphylactic, _formname = _str_FFTemplateProphylactic, _type = "Lookup",
              _get_func = o => { if (o.FFTemplateProphylactic == null) return null; return o.FFTemplateProphylactic.idfsFormTemplate; },
              _set_func = (o, val) => { o.FFTemplateProphylactic = o.FFTemplateProphylacticLookup.Where(c => c.idfsFormTemplate.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_FFTemplateProphylactic, c);
                if (o.idfsProphylacticObservationFormTemplate != c.idfsProphylacticObservationFormTemplate || o.IsRIRPropChanged(_str_FFTemplateProphylactic, c) || bChangeLookupContent) {
                  m.Add(_str_FFTemplateProphylactic, o.ObjectIdent + _str_FFTemplateProphylactic, o.ObjectIdent2 + _str_FFTemplateProphylactic, o.ObjectIdent3 + _str_FFTemplateProphylactic, "Lookup", o.idfsProphylacticObservationFormTemplate == null ? "" : o.idfsProphylacticObservationFormTemplate.ToString(), o.IsReadOnly(_str_FFTemplateProphylactic), o.IsInvisible(_str_FFTemplateProphylactic), o.IsRequired(_str_FFTemplateProphylactic),
                  bChangeLookupContent ? o.FFTemplateProphylacticLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_FFTemplateProphylactic + "Lookup", _formname = _str_FFTemplateProphylactic + "Lookup", _type = "LookupContent",
              _get_func = o => o.FFTemplateProphylacticLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_FFTemplateSanitary, _formname = _str_FFTemplateSanitary, _type = "Lookup",
              _get_func = o => { if (o.FFTemplateSanitary == null) return null; return o.FFTemplateSanitary.idfsFormTemplate; },
              _set_func = (o, val) => { o.FFTemplateSanitary = o.FFTemplateSanitaryLookup.Where(c => c.idfsFormTemplate.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_FFTemplateSanitary, c);
                if (o.idfsSanitaryObservationFormTemplate != c.idfsSanitaryObservationFormTemplate || o.IsRIRPropChanged(_str_FFTemplateSanitary, c) || bChangeLookupContent) {
                  m.Add(_str_FFTemplateSanitary, o.ObjectIdent + _str_FFTemplateSanitary, o.ObjectIdent2 + _str_FFTemplateSanitary, o.ObjectIdent3 + _str_FFTemplateSanitary, "Lookup", o.idfsSanitaryObservationFormTemplate == null ? "" : o.idfsSanitaryObservationFormTemplate.ToString(), o.IsReadOnly(_str_FFTemplateSanitary), o.IsInvisible(_str_FFTemplateSanitary), o.IsRequired(_str_FFTemplateSanitary),
                  bChangeLookupContent ? o.FFTemplateSanitaryLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_FFTemplateSanitary + "Lookup", _formname = _str_FFTemplateSanitary + "Lookup", _type = "LookupContent",
              _get_func = o => o.FFTemplateSanitaryLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Settings, _formname = _str_Settings, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.Settings != null) o.Settings._compare(c.Settings, m); }
              }, 
        
            new field_info {
              _name = _str_FFPresenterCase, _formname = _str_FFPresenterCase, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.FFPresenterCase != null) o.FFPresenterCase._compare(c.FFPresenterCase, m); }
              }, 
        
            new field_info {
              _name = _str_FFPresenterDiagnostic, _formname = _str_FFPresenterDiagnostic, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.FFPresenterDiagnostic != null) o.FFPresenterDiagnostic._compare(c.FFPresenterDiagnostic, m); }
              }, 
        
            new field_info {
              _name = _str_FFPresenterProphylactic, _formname = _str_FFPresenterProphylactic, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.FFPresenterProphylactic != null) o.FFPresenterProphylactic._compare(c.FFPresenterProphylactic, m); }
              }, 
        
            new field_info {
              _name = _str_FFPresenterSanitary, _formname = _str_FFPresenterSanitary, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.FFPresenterSanitary != null) o.FFPresenterSanitary._compare(c.FFPresenterSanitary, m); }
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
            AggregateCaseHeader obj = (AggregateCaseHeader)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Settings)]
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
                    
        [LocalizedDisplayName(_str_FFPresenterCase)]
        [Relation(typeof(FFPresenterModel), eidss.model.Schema.FFPresenterModel._str_CurrentObservation, _str_idfCaseObservation)]
        public FFPresenterModel FFPresenterCase
        {
            get 
            {   
                return _FFPresenterCase; 
            }
            set 
            {   
                _FFPresenterCase = value;
                if (_FFPresenterCase != null) 
                { 
                    _FFPresenterCase.m_ObjectName = _str_FFPresenterCase;
                    _FFPresenterCase.Parent = this;
                }
                idfCaseObservation = _FFPresenterCase == null 
                        ? new Int64?()
                        : _FFPresenterCase.CurrentObservation;
                
            }
        }
        protected FFPresenterModel _FFPresenterCase;
                    
        [LocalizedDisplayName(_str_FFPresenterDiagnostic)]
        [Relation(typeof(FFPresenterModel), eidss.model.Schema.FFPresenterModel._str_CurrentObservation, _str_idfDiagnosticObservation)]
        public FFPresenterModel FFPresenterDiagnostic
        {
            get 
            {   
                return _FFPresenterDiagnostic; 
            }
            set 
            {   
                _FFPresenterDiagnostic = value;
                if (_FFPresenterDiagnostic != null) 
                { 
                    _FFPresenterDiagnostic.m_ObjectName = _str_FFPresenterDiagnostic;
                    _FFPresenterDiagnostic.Parent = this;
                }
                idfDiagnosticObservation = _FFPresenterDiagnostic == null 
                        ? new Int64?()
                        : _FFPresenterDiagnostic.CurrentObservation;
                
            }
        }
        protected FFPresenterModel _FFPresenterDiagnostic;
                    
        [LocalizedDisplayName(_str_FFPresenterProphylactic)]
        [Relation(typeof(FFPresenterModel), eidss.model.Schema.FFPresenterModel._str_CurrentObservation, _str_idfProphylacticObservation)]
        public FFPresenterModel FFPresenterProphylactic
        {
            get 
            {   
                return _FFPresenterProphylactic; 
            }
            set 
            {   
                _FFPresenterProphylactic = value;
                if (_FFPresenterProphylactic != null) 
                { 
                    _FFPresenterProphylactic.m_ObjectName = _str_FFPresenterProphylactic;
                    _FFPresenterProphylactic.Parent = this;
                }
                idfProphylacticObservation = _FFPresenterProphylactic == null 
                        ? new Int64?()
                        : _FFPresenterProphylactic.CurrentObservation;
                
            }
        }
        protected FFPresenterModel _FFPresenterProphylactic;
                    
        [LocalizedDisplayName(_str_FFPresenterSanitary)]
        [Relation(typeof(FFPresenterModel), eidss.model.Schema.FFPresenterModel._str_CurrentObservation, _str_idfSanitaryObservation)]
        public FFPresenterModel FFPresenterSanitary
        {
            get 
            {   
                return _FFPresenterSanitary; 
            }
            set 
            {   
                _FFPresenterSanitary = value;
                if (_FFPresenterSanitary != null) 
                { 
                    _FFPresenterSanitary.m_ObjectName = _str_FFPresenterSanitary;
                    _FFPresenterSanitary.Parent = this;
                }
                idfSanitaryObservation = _FFPresenterSanitary == null 
                        ? new Int64?()
                        : _FFPresenterSanitary.CurrentObservation;
                
            }
        }
        protected FFPresenterModel _FFPresenterSanitary;
                    
        [LocalizedDisplayName(_str_Country)]
        [Relation(typeof(CountryLookup), eidss.model.Schema.CountryLookup._str_idfsCountry, _str_idfsCountry)]
        public CountryLookup Country
        {
            get { return _Country == null ? null : ((long)_Country.Key == 0 ? null : _Country); }
            set 
            { 
                var oldVal = _Country;
                _Country = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Country != oldVal)
                {
                    if (idfsCountry != (_Country == null
                            ? new Int64?()
                            : (Int64?)_Country.idfsCountry))
                        idfsCountry = _Country == null 
                            ? new Int64?()
                            : (Int64?)_Country.idfsCountry; 
                    OnPropertyChanged(_str_Country); 
                }
            }
        }
        private CountryLookup _Country;

        
        public List<CountryLookup> CountryLookup
        {
            get { return _CountryLookup; }
        }
        private List<CountryLookup> _CountryLookup = new List<CountryLookup>();
            
        [LocalizedDisplayName(_str_Region)]
        [Relation(typeof(RegionAggrLookup), eidss.model.Schema.RegionAggrLookup._str_idfsRegion, _str_idfsRegion)]
        public RegionAggrLookup Region
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
        private RegionAggrLookup _Region;

        
        public List<RegionAggrLookup> RegionLookup
        {
            get { return _RegionLookup; }
        }
        private List<RegionAggrLookup> _RegionLookup = new List<RegionAggrLookup>();
            
        [LocalizedDisplayName(_str_Rayon)]
        [Relation(typeof(RayonAggrLookup), eidss.model.Schema.RayonAggrLookup._str_idfsRayon, _str_idfsRayon)]
        public RayonAggrLookup Rayon
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
        private RayonAggrLookup _Rayon;

        
        public List<RayonAggrLookup> RayonLookup
        {
            get { return _RayonLookup; }
        }
        private List<RayonAggrLookup> _RayonLookup = new List<RayonAggrLookup>();
            
        [LocalizedDisplayName(_str_Settlement)]
        [Relation(typeof(SettlementAggrLookup), eidss.model.Schema.SettlementAggrLookup._str_idfsSettlement, _str_idfsSettlement)]
        public SettlementAggrLookup Settlement
        {
            get { return _Settlement == null ? null : ((long)_Settlement.Key == 0 ? null : _Settlement); }
            set 
            { 
                var oldVal = _Settlement;
                _Settlement = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Settlement != oldVal)
                {
                    if (idfsSettlement != (_Settlement == null
                            ? new Int64?()
                            : (Int64?)_Settlement.idfsSettlement))
                        idfsSettlement = _Settlement == null 
                            ? new Int64?()
                            : (Int64?)_Settlement.idfsSettlement; 
                    OnPropertyChanged(_str_Settlement); 
                }
            }
        }
        private SettlementAggrLookup _Settlement;

        
        public List<SettlementAggrLookup> SettlementLookup
        {
            get { return _SettlementLookup; }
        }
        private List<SettlementAggrLookup> _SettlementLookup = new List<SettlementAggrLookup>();
            
        [LocalizedDisplayName(_str_SentByOffice)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfSentByOffice)]
        public OrganizationLookup SentByOffice
        {
            get { return _SentByOffice == null ? null : ((long)_SentByOffice.Key == 0 ? null : _SentByOffice); }
            set 
            { 
                var oldVal = _SentByOffice;
                _SentByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SentByOffice != oldVal)
                {
                    if (idfSentByOffice != (_SentByOffice == null
                            ? new Int64()
                            : (Int64)_SentByOffice.idfInstitution))
                        idfSentByOffice = _SentByOffice == null 
                            ? new Int64()
                            : (Int64)_SentByOffice.idfInstitution; 
                    OnPropertyChanged(_str_SentByOffice); 
                }
            }
        }
        private OrganizationLookup _SentByOffice;

        
        public List<OrganizationLookup> SentByOfficeLookup
        {
            get { return _SentByOfficeLookup; }
        }
        private List<OrganizationLookup> _SentByOfficeLookup = new List<OrganizationLookup>();
            
        [LocalizedDisplayName(_str_ReceivedByOffice)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfReceivedByOffice)]
        public OrganizationLookup ReceivedByOffice
        {
            get { return _ReceivedByOffice == null ? null : ((long)_ReceivedByOffice.Key == 0 ? null : _ReceivedByOffice); }
            set 
            { 
                var oldVal = _ReceivedByOffice;
                _ReceivedByOffice = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_ReceivedByOffice != oldVal)
                {
                    if (idfReceivedByOffice != (_ReceivedByOffice == null
                            ? new Int64?()
                            : (Int64?)_ReceivedByOffice.idfInstitution))
                        idfReceivedByOffice = _ReceivedByOffice == null 
                            ? new Int64?()
                            : (Int64?)_ReceivedByOffice.idfInstitution; 
                    OnPropertyChanged(_str_ReceivedByOffice); 
                }
            }
        }
        private OrganizationLookup _ReceivedByOffice;

        
        public List<OrganizationLookup> ReceivedByOfficeLookup
        {
            get { return _ReceivedByOfficeLookup; }
        }
        private List<OrganizationLookup> _ReceivedByOfficeLookup = new List<OrganizationLookup>();
            
        [LocalizedDisplayName(_str_SentByPerson)]
        [Relation(typeof(WiderPersonLookup), eidss.model.Schema.WiderPersonLookup._str_idfPerson, _str_idfSentByPerson)]
        public WiderPersonLookup SentByPerson
        {
            get { return _SentByPerson == null ? null : ((long)_SentByPerson.Key == 0 ? null : _SentByPerson); }
            set 
            { 
                var oldVal = _SentByPerson;
                _SentByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_SentByPerson != oldVal)
                {
                    if (idfSentByPerson != (_SentByPerson == null
                            ? new Int64()
                            : (Int64)_SentByPerson.idfPerson))
                        idfSentByPerson = _SentByPerson == null 
                            ? new Int64()
                            : (Int64)_SentByPerson.idfPerson; 
                    OnPropertyChanged(_str_SentByPerson); 
                }
            }
        }
        private WiderPersonLookup _SentByPerson;

        
        public List<WiderPersonLookup> SentByPersonLookup
        {
            get { return _SentByPersonLookup; }
        }
        private List<WiderPersonLookup> _SentByPersonLookup = new List<WiderPersonLookup>();
            
        [LocalizedDisplayName(_str_ReceivedByPerson)]
        [Relation(typeof(WiderPersonLookup), eidss.model.Schema.WiderPersonLookup._str_idfPerson, _str_idfReceivedByPerson)]
        public WiderPersonLookup ReceivedByPerson
        {
            get { return _ReceivedByPerson == null ? null : ((long)_ReceivedByPerson.Key == 0 ? null : _ReceivedByPerson); }
            set 
            { 
                var oldVal = _ReceivedByPerson;
                _ReceivedByPerson = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_ReceivedByPerson != oldVal)
                {
                    if (idfReceivedByPerson != (_ReceivedByPerson == null
                            ? new Int64?()
                            : (Int64?)_ReceivedByPerson.idfPerson))
                        idfReceivedByPerson = _ReceivedByPerson == null 
                            ? new Int64?()
                            : (Int64?)_ReceivedByPerson.idfPerson; 
                    OnPropertyChanged(_str_ReceivedByPerson); 
                }
            }
        }
        private WiderPersonLookup _ReceivedByPerson;

        
        public List<WiderPersonLookup> ReceivedByPersonLookup
        {
            get { return _ReceivedByPersonLookup; }
        }
        private List<WiderPersonLookup> _ReceivedByPersonLookup = new List<WiderPersonLookup>();
            
        [LocalizedDisplayName(_str_YearAggr)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_YearForAggr)]
        public BaseReference YearAggr
        {
            get { return _YearAggr == null ? null : ((long)_YearAggr.Key == 0 ? null : _YearAggr); }
            set 
            { 
                var oldVal = _YearAggr;
                _YearAggr = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_YearAggr != oldVal)
                {
                    if (YearForAggr != (_YearAggr == null
                            ? new Int64?()
                            : (Int64?)_YearAggr.idfsBaseReference))
                        YearForAggr = _YearAggr == null 
                            ? new Int64?()
                            : (Int64?)_YearAggr.idfsBaseReference; 
                    OnPropertyChanged(_str_YearAggr); 
                }
            }
        }
        private BaseReference _YearAggr;

        
        public BaseReferenceList YearAggrLookup
        {
            get { return _YearAggrLookup; }
        }
        private BaseReferenceList _YearAggrLookup = new BaseReferenceList("rftSampleStatus");
            
        [LocalizedDisplayName(_str_QuarterAggr)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_QuarterForAggr)]
        public BaseReference QuarterAggr
        {
            get { return _QuarterAggr == null ? null : ((long)_QuarterAggr.Key == 0 ? null : _QuarterAggr); }
            set 
            { 
                var oldVal = _QuarterAggr;
                _QuarterAggr = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_QuarterAggr != oldVal)
                {
                    if (QuarterForAggr != (_QuarterAggr == null
                            ? new Int64?()
                            : (Int64?)_QuarterAggr.idfsBaseReference))
                        QuarterForAggr = _QuarterAggr == null 
                            ? new Int64?()
                            : (Int64?)_QuarterAggr.idfsBaseReference; 
                    OnPropertyChanged(_str_QuarterAggr); 
                }
            }
        }
        private BaseReference _QuarterAggr;

        
        public BaseReferenceList QuarterAggrLookup
        {
            get { return _QuarterAggrLookup; }
        }
        private BaseReferenceList _QuarterAggrLookup = new BaseReferenceList("rftSampleStatus");
            
        [LocalizedDisplayName(_str_MonthAggr)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_MonthForAggr)]
        public BaseReference MonthAggr
        {
            get { return _MonthAggr == null ? null : ((long)_MonthAggr.Key == 0 ? null : _MonthAggr); }
            set 
            { 
                var oldVal = _MonthAggr;
                _MonthAggr = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_MonthAggr != oldVal)
                {
                    if (MonthForAggr != (_MonthAggr == null
                            ? new Int64?()
                            : (Int64?)_MonthAggr.idfsBaseReference))
                        MonthForAggr = _MonthAggr == null 
                            ? new Int64?()
                            : (Int64?)_MonthAggr.idfsBaseReference; 
                    OnPropertyChanged(_str_MonthAggr); 
                }
            }
        }
        private BaseReference _MonthAggr;

        
        public BaseReferenceList MonthAggrLookup
        {
            get { return _MonthAggrLookup; }
        }
        private BaseReferenceList _MonthAggrLookup = new BaseReferenceList("rftSampleStatus");
            
        [LocalizedDisplayName(_str_WeekAggr)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_WeekForAggr)]
        public BaseReference WeekAggr
        {
            get { return _WeekAggr == null ? null : ((long)_WeekAggr.Key == 0 ? null : _WeekAggr); }
            set 
            { 
                var oldVal = _WeekAggr;
                _WeekAggr = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_WeekAggr != oldVal)
                {
                    if (WeekForAggr != (_WeekAggr == null
                            ? new Int64?()
                            : (Int64?)_WeekAggr.idfsBaseReference))
                        WeekForAggr = _WeekAggr == null 
                            ? new Int64?()
                            : (Int64?)_WeekAggr.idfsBaseReference; 
                    OnPropertyChanged(_str_WeekAggr); 
                }
            }
        }
        private BaseReference _WeekAggr;

        
        public BaseReferenceList WeekAggrLookup
        {
            get { return _WeekAggrLookup; }
        }
        private BaseReferenceList _WeekAggrLookup = new BaseReferenceList("rftSampleStatus");
            
        [LocalizedDisplayName("AggregateMatrixVersion")]
        [Relation(typeof(AggregateMatrixVersionLookup), eidss.model.Schema.AggregateMatrixVersionLookup._str_idfVersion, _str_idfVersion)]
        public AggregateMatrixVersionLookup AggregateMatrixVersionCase
        {
            get { return _AggregateMatrixVersionCase; }
            set 
            { 
                var oldVal = _AggregateMatrixVersionCase;
                _AggregateMatrixVersionCase = value;
                if (_AggregateMatrixVersionCase != oldVal)
                {
                    if (idfVersion != (_AggregateMatrixVersionCase == null
                            ? new Int64?()
                            : (Int64?)_AggregateMatrixVersionCase.idfVersion))
                        idfVersion = _AggregateMatrixVersionCase == null 
                            ? new Int64?()
                            : (Int64?)_AggregateMatrixVersionCase.idfVersion; 
                    OnPropertyChanged(_str_AggregateMatrixVersionCase); 
                }
            }
        }
        private AggregateMatrixVersionLookup _AggregateMatrixVersionCase;

        
        public List<AggregateMatrixVersionLookup> AggregateMatrixVersionCaseLookup
        {
            get { return _AggregateMatrixVersionCaseLookup; }
        }
        private List<AggregateMatrixVersionLookup> _AggregateMatrixVersionCaseLookup = new List<AggregateMatrixVersionLookup>();
            
        [LocalizedDisplayName("AggregateMatrixVersion")]
        [Relation(typeof(AggregateMatrixVersionLookup), eidss.model.Schema.AggregateMatrixVersionLookup._str_idfVersion, _str_idfDiagnosticVersion)]
        public AggregateMatrixVersionLookup AggregateMatrixVersionDiagnostic
        {
            get { return _AggregateMatrixVersionDiagnostic; }
            set 
            { 
                var oldVal = _AggregateMatrixVersionDiagnostic;
                _AggregateMatrixVersionDiagnostic = value;
                if (_AggregateMatrixVersionDiagnostic != oldVal)
                {
                    if (idfDiagnosticVersion != (_AggregateMatrixVersionDiagnostic == null
                            ? new Int64?()
                            : (Int64?)_AggregateMatrixVersionDiagnostic.idfVersion))
                        idfDiagnosticVersion = _AggregateMatrixVersionDiagnostic == null 
                            ? new Int64?()
                            : (Int64?)_AggregateMatrixVersionDiagnostic.idfVersion; 
                    OnPropertyChanged(_str_AggregateMatrixVersionDiagnostic); 
                }
            }
        }
        private AggregateMatrixVersionLookup _AggregateMatrixVersionDiagnostic;

        
        public List<AggregateMatrixVersionLookup> AggregateMatrixVersionDiagnosticLookup
        {
            get { return _AggregateMatrixVersionDiagnosticLookup; }
        }
        private List<AggregateMatrixVersionLookup> _AggregateMatrixVersionDiagnosticLookup = new List<AggregateMatrixVersionLookup>();
            
        [LocalizedDisplayName("AggregateMatrixVersion")]
        [Relation(typeof(AggregateMatrixVersionLookup), eidss.model.Schema.AggregateMatrixVersionLookup._str_idfVersion, _str_idfProphylacticVersion)]
        public AggregateMatrixVersionLookup AggregateMatrixVersionProphylactic
        {
            get { return _AggregateMatrixVersionProphylactic; }
            set 
            { 
                var oldVal = _AggregateMatrixVersionProphylactic;
                _AggregateMatrixVersionProphylactic = value;
                if (_AggregateMatrixVersionProphylactic != oldVal)
                {
                    if (idfProphylacticVersion != (_AggregateMatrixVersionProphylactic == null
                            ? new Int64?()
                            : (Int64?)_AggregateMatrixVersionProphylactic.idfVersion))
                        idfProphylacticVersion = _AggregateMatrixVersionProphylactic == null 
                            ? new Int64?()
                            : (Int64?)_AggregateMatrixVersionProphylactic.idfVersion; 
                    OnPropertyChanged(_str_AggregateMatrixVersionProphylactic); 
                }
            }
        }
        private AggregateMatrixVersionLookup _AggregateMatrixVersionProphylactic;

        
        public List<AggregateMatrixVersionLookup> AggregateMatrixVersionProphylacticLookup
        {
            get { return _AggregateMatrixVersionProphylacticLookup; }
        }
        private List<AggregateMatrixVersionLookup> _AggregateMatrixVersionProphylacticLookup = new List<AggregateMatrixVersionLookup>();
            
        [LocalizedDisplayName("AggregateMatrixVersion")]
        [Relation(typeof(AggregateMatrixVersionLookup), eidss.model.Schema.AggregateMatrixVersionLookup._str_idfVersion, _str_idfSanitaryVersion)]
        public AggregateMatrixVersionLookup AggregateMatrixVersionSanitary
        {
            get { return _AggregateMatrixVersionSanitary; }
            set 
            { 
                var oldVal = _AggregateMatrixVersionSanitary;
                _AggregateMatrixVersionSanitary = value;
                if (_AggregateMatrixVersionSanitary != oldVal)
                {
                    if (idfSanitaryVersion != (_AggregateMatrixVersionSanitary == null
                            ? new Int64?()
                            : (Int64?)_AggregateMatrixVersionSanitary.idfVersion))
                        idfSanitaryVersion = _AggregateMatrixVersionSanitary == null 
                            ? new Int64?()
                            : (Int64?)_AggregateMatrixVersionSanitary.idfVersion; 
                    OnPropertyChanged(_str_AggregateMatrixVersionSanitary); 
                }
            }
        }
        private AggregateMatrixVersionLookup _AggregateMatrixVersionSanitary;

        
        public List<AggregateMatrixVersionLookup> AggregateMatrixVersionSanitaryLookup
        {
            get { return _AggregateMatrixVersionSanitaryLookup; }
        }
        private List<AggregateMatrixVersionLookup> _AggregateMatrixVersionSanitaryLookup = new List<AggregateMatrixVersionLookup>();
            
        [LocalizedDisplayName("FFTemplate")]
        [Relation(typeof(FFTemplateLookup), eidss.model.Schema.FFTemplateLookup._str_idfsFormTemplate, _str_idfsCaseObservationFormTemplate)]
        public FFTemplateLookup FFTemplateCase
        {
            get { return _FFTemplateCase; }
            set 
            { 
                var oldVal = _FFTemplateCase;
                _FFTemplateCase = value;
                if (_FFTemplateCase != oldVal)
                {
                    if (idfsCaseObservationFormTemplate != (_FFTemplateCase == null
                            ? new Int64?()
                            : (Int64?)_FFTemplateCase.idfsFormTemplate))
                        idfsCaseObservationFormTemplate = _FFTemplateCase == null 
                            ? new Int64?()
                            : (Int64?)_FFTemplateCase.idfsFormTemplate; 
                    OnPropertyChanged(_str_FFTemplateCase); 
                }
            }
        }
        private FFTemplateLookup _FFTemplateCase;

        
        public List<FFTemplateLookup> FFTemplateCaseLookup
        {
            get { return _FFTemplateCaseLookup; }
        }
        private List<FFTemplateLookup> _FFTemplateCaseLookup = new List<FFTemplateLookup>();
            
        [LocalizedDisplayName("FFTemplate")]
        [Relation(typeof(FFTemplateLookup), eidss.model.Schema.FFTemplateLookup._str_idfsFormTemplate, _str_idfsDiagnosticObservationFormTemplate)]
        public FFTemplateLookup FFTemplateDiagnostic
        {
            get { return _FFTemplateDiagnostic; }
            set 
            { 
                var oldVal = _FFTemplateDiagnostic;
                _FFTemplateDiagnostic = value;
                if (_FFTemplateDiagnostic != oldVal)
                {
                    if (idfsDiagnosticObservationFormTemplate != (_FFTemplateDiagnostic == null
                            ? new Int64?()
                            : (Int64?)_FFTemplateDiagnostic.idfsFormTemplate))
                        idfsDiagnosticObservationFormTemplate = _FFTemplateDiagnostic == null 
                            ? new Int64?()
                            : (Int64?)_FFTemplateDiagnostic.idfsFormTemplate; 
                    OnPropertyChanged(_str_FFTemplateDiagnostic); 
                }
            }
        }
        private FFTemplateLookup _FFTemplateDiagnostic;

        
        public List<FFTemplateLookup> FFTemplateDiagnosticLookup
        {
            get { return _FFTemplateDiagnosticLookup; }
        }
        private List<FFTemplateLookup> _FFTemplateDiagnosticLookup = new List<FFTemplateLookup>();
            
        [LocalizedDisplayName("FFTemplate")]
        [Relation(typeof(FFTemplateLookup), eidss.model.Schema.FFTemplateLookup._str_idfsFormTemplate, _str_idfsProphylacticObservationFormTemplate)]
        public FFTemplateLookup FFTemplateProphylactic
        {
            get { return _FFTemplateProphylactic; }
            set 
            { 
                var oldVal = _FFTemplateProphylactic;
                _FFTemplateProphylactic = value;
                if (_FFTemplateProphylactic != oldVal)
                {
                    if (idfsProphylacticObservationFormTemplate != (_FFTemplateProphylactic == null
                            ? new Int64?()
                            : (Int64?)_FFTemplateProphylactic.idfsFormTemplate))
                        idfsProphylacticObservationFormTemplate = _FFTemplateProphylactic == null 
                            ? new Int64?()
                            : (Int64?)_FFTemplateProphylactic.idfsFormTemplate; 
                    OnPropertyChanged(_str_FFTemplateProphylactic); 
                }
            }
        }
        private FFTemplateLookup _FFTemplateProphylactic;

        
        public List<FFTemplateLookup> FFTemplateProphylacticLookup
        {
            get { return _FFTemplateProphylacticLookup; }
        }
        private List<FFTemplateLookup> _FFTemplateProphylacticLookup = new List<FFTemplateLookup>();
            
        [LocalizedDisplayName("FFTemplate")]
        [Relation(typeof(FFTemplateLookup), eidss.model.Schema.FFTemplateLookup._str_idfsFormTemplate, _str_idfsSanitaryObservationFormTemplate)]
        public FFTemplateLookup FFTemplateSanitary
        {
            get { return _FFTemplateSanitary; }
            set 
            { 
                var oldVal = _FFTemplateSanitary;
                _FFTemplateSanitary = value;
                if (_FFTemplateSanitary != oldVal)
                {
                    if (idfsSanitaryObservationFormTemplate != (_FFTemplateSanitary == null
                            ? new Int64?()
                            : (Int64?)_FFTemplateSanitary.idfsFormTemplate))
                        idfsSanitaryObservationFormTemplate = _FFTemplateSanitary == null 
                            ? new Int64?()
                            : (Int64?)_FFTemplateSanitary.idfsFormTemplate; 
                    OnPropertyChanged(_str_FFTemplateSanitary); 
                }
            }
        }
        private FFTemplateLookup _FFTemplateSanitary;

        
        public List<FFTemplateLookup> FFTemplateSanitaryLookup
        {
            get { return _FFTemplateSanitaryLookup; }
        }
        private List<FFTemplateLookup> _FFTemplateSanitaryLookup = new List<FFTemplateLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Country:
                    return new BvSelectList(CountryLookup, eidss.model.Schema.CountryLookup._str_idfsCountry, null, Country, _str_idfsCountry);
            
                case _str_Region:
                    return new BvSelectList(RegionLookup, eidss.model.Schema.RegionAggrLookup._str_idfsRegion, null, Region, _str_idfsRegion);
            
                case _str_Rayon:
                    return new BvSelectList(RayonLookup, eidss.model.Schema.RayonAggrLookup._str_idfsRayon, null, Rayon, _str_idfsRayon);
            
                case _str_Settlement:
                    return new BvSelectList(SettlementLookup, eidss.model.Schema.SettlementAggrLookup._str_idfsSettlement, null, Settlement, _str_idfsSettlement);
            
                case _str_SentByOffice:
                    return new BvSelectList(SentByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, SentByOffice, _str_idfSentByOffice);
            
                case _str_ReceivedByOffice:
                    return new BvSelectList(ReceivedByOfficeLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, ReceivedByOffice, _str_idfReceivedByOffice);
            
                case _str_SentByPerson:
                    return new BvSelectList(SentByPersonLookup, eidss.model.Schema.WiderPersonLookup._str_idfPerson, null, SentByPerson, _str_idfSentByPerson);
            
                case _str_ReceivedByPerson:
                    return new BvSelectList(ReceivedByPersonLookup, eidss.model.Schema.WiderPersonLookup._str_idfPerson, null, ReceivedByPerson, _str_idfReceivedByPerson);
            
                case _str_YearAggr:
                    return new BvSelectList(YearAggrLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, YearAggr, _str_YearForAggr);
            
                case _str_QuarterAggr:
                    return new BvSelectList(QuarterAggrLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, QuarterAggr, _str_QuarterForAggr);
            
                case _str_MonthAggr:
                    return new BvSelectList(MonthAggrLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, MonthAggr, _str_MonthForAggr);
            
                case _str_WeekAggr:
                    return new BvSelectList(WeekAggrLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, WeekAggr, _str_WeekForAggr);
            
                case _str_AggregateMatrixVersionCase:
                    return new BvSelectList(AggregateMatrixVersionCaseLookup, eidss.model.Schema.AggregateMatrixVersionLookup._str_idfVersion, null, AggregateMatrixVersionCase, _str_idfVersion);
            
                case _str_AggregateMatrixVersionDiagnostic:
                    return new BvSelectList(AggregateMatrixVersionDiagnosticLookup, eidss.model.Schema.AggregateMatrixVersionLookup._str_idfVersion, null, AggregateMatrixVersionDiagnostic, _str_idfDiagnosticVersion);
            
                case _str_AggregateMatrixVersionProphylactic:
                    return new BvSelectList(AggregateMatrixVersionProphylacticLookup, eidss.model.Schema.AggregateMatrixVersionLookup._str_idfVersion, null, AggregateMatrixVersionProphylactic, _str_idfProphylacticVersion);
            
                case _str_AggregateMatrixVersionSanitary:
                    return new BvSelectList(AggregateMatrixVersionSanitaryLookup, eidss.model.Schema.AggregateMatrixVersionLookup._str_idfVersion, null, AggregateMatrixVersionSanitary, _str_idfSanitaryVersion);
            
                case _str_FFTemplateCase:
                    return new BvSelectList(FFTemplateCaseLookup, eidss.model.Schema.FFTemplateLookup._str_idfsFormTemplate, null, FFTemplateCase, _str_idfsCaseObservationFormTemplate);
            
                case _str_FFTemplateDiagnostic:
                    return new BvSelectList(FFTemplateDiagnosticLookup, eidss.model.Schema.FFTemplateLookup._str_idfsFormTemplate, null, FFTemplateDiagnostic, _str_idfsDiagnosticObservationFormTemplate);
            
                case _str_FFTemplateProphylactic:
                    return new BvSelectList(FFTemplateProphylacticLookup, eidss.model.Schema.FFTemplateLookup._str_idfsFormTemplate, null, FFTemplateProphylactic, _str_idfsProphylacticObservationFormTemplate);
            
                case _str_FFTemplateSanitary:
                    return new BvSelectList(FFTemplateSanitaryLookup, eidss.model.Schema.FFTemplateLookup._str_idfsFormTemplate, null, FFTemplateSanitary, _str_idfsSanitaryObservationFormTemplate);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_NumberingObject)]
        public long NumberingObject
        {
            get { return new Func<AggregateCaseHeader, long>(c => c.idfsAggrCaseType == (long)AggregateCaseType.HumanAggregateCase ? (long)NumberingObjectEnum.HumanAggregateCase :
                            (c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateCase ? (long)NumberingObjectEnum.VetAggregateCase :
                            (c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateAction ? (long)NumberingObjectEnum.VetAggregateAction :
                            0)))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsAdministrativeUnitCalc)]
        public long idfsAdministrativeUnitCalc
        {
            get { return new Func<AggregateCaseHeader, long>(c => c.idfsSettlement != null ? c.idfsSettlement.Value : 
                                (c.idfsRayon != null ? c.idfsRayon.Value : 
                                (c.idfsRegion != null ? c.idfsRegion.Value : c.idfsCountry.Value)))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_datStartDateCalc)]
        public DateTime? datStartDateCalc
        {
            get { return new Func<AggregateCaseHeader, DateTime?>(c => c.DayForAggr != null ? c.DayForAggr : 
                                (c.WeekForAggr != null ? (c.YearForAggr != null ? new DateTime((int)c.YearForAggr.Value, 1, 1).AddDays(-(int)(new DateTime((int)c.YearForAggr.Value, 1, 1).DayOfWeek) + 1).AddDays(7 * (c.WeekForAggr.Value - 1)) : default(DateTime?)) :
                                (c.MonthForAggr != null ? (c.YearForAggr != null ? new DateTime((int)c.YearForAggr.Value, (int)c.MonthForAggr.Value, 1) : default(DateTime?)) : 
                                (c.QuarterForAggr != null ? (c.YearForAggr != null ? new DateTime((int)c.YearForAggr.Value, (int)(c.QuarterForAggr.Value - 1) * 3 + 1, 1) : default(DateTime?)) : 
                                (c.YearForAggr != null ? new DateTime((int)c.YearForAggr.Value, 1, 1) : default(DateTime?)
                                )))))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_datFinishDateCalc)]
        public DateTime? datFinishDateCalc
        {
            get { return new Func<AggregateCaseHeader, DateTime?>(c => c.DayForAggr != null ? c.DayForAggr : 
                                (c.WeekForAggr != null ? (c.YearForAggr != null ? new DateTime((int)c.YearForAggr.Value, 1, 1).AddDays(-(int)(new DateTime((int)c.YearForAggr.Value, 1, 1).DayOfWeek) + 1).AddDays(7 * c.WeekForAggr.Value).AddDays(-1) : default(DateTime?)) : 
                                (c.MonthForAggr != null ? (c.YearForAggr != null ? (c.MonthForAggr.Value == 12 ? new DateTime((int)c.YearForAggr.Value + 1, 1, 1).AddDays(-1) : new DateTime((int)c.YearForAggr.Value, (int)c.MonthForAggr.Value + 1, 1)).AddDays(-1) : default(DateTime?)) : 
                                (c.QuarterForAggr != null ? (c.YearForAggr != null ? (c.QuarterForAggr.Value == 4 ? new DateTime((int)c.YearForAggr.Value + 1, 1, 1).AddDays(-1) : new DateTime((int)c.YearForAggr.Value, (int)c.QuarterForAggr.Value * 3 + 1, 1)).AddDays(-1) : default(DateTime?)) : 
                                (c.YearForAggr != null ? new DateTime((int)c.YearForAggr.Value + 1, 1, 1).AddDays(-1) : default(DateTime?)
                                )))))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyEnteredByDate)]
        public string strReadOnlyEnteredByDate
        {
            get { return new Func<AggregateCaseHeader, string>(c => c.datEnteredByDate == null ? (string)null : c.datEnteredByDate.Value.ToString("d"))(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AggregateCaseHeader";

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
                
            if (_FFPresenterCase != null) { _FFPresenterCase.Parent = this; }
                
            if (_FFPresenterDiagnostic != null) { _FFPresenterDiagnostic.Parent = this; }
                
            if (_FFPresenterProphylactic != null) { _FFPresenterProphylactic.Parent = this; }
                
            if (_FFPresenterSanitary != null) { _FFPresenterSanitary.Parent = this; }
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as AggregateCaseHeader;
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
            var ret = base.Clone() as AggregateCaseHeader;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Settings != null)
              ret.Settings = _Settings.CloneWithSetup(manager, bRestricted) as AggregateSettings;
                
            if (_FFPresenterCase != null)
              ret.FFPresenterCase = _FFPresenterCase.CloneWithSetup(manager, bRestricted) as FFPresenterModel;
                
            if (_FFPresenterDiagnostic != null)
              ret.FFPresenterDiagnostic = _FFPresenterDiagnostic.CloneWithSetup(manager, bRestricted) as FFPresenterModel;
                
            if (_FFPresenterProphylactic != null)
              ret.FFPresenterProphylactic = _FFPresenterProphylactic.CloneWithSetup(manager, bRestricted) as FFPresenterModel;
                
            if (_FFPresenterSanitary != null)
              ret.FFPresenterSanitary = _FFPresenterSanitary.CloneWithSetup(manager, bRestricted) as FFPresenterModel;
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AggregateCaseHeader CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AggregateCaseHeader;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfAggrCase; } }
        public string KeyName { get { return "idfAggrCase"; } }
        public object KeyLookup { get { return idfAggrCase; } }
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
        
                    || (_Settings != null && _Settings.HasChanges)
                
                    || (_FFPresenterCase != null && _FFPresenterCase.HasChanges)
                
                    || (_FFPresenterDiagnostic != null && _FFPresenterDiagnostic.HasChanges)
                
                    || (_FFPresenterProphylactic != null && _FFPresenterProphylactic.HasChanges)
                
                    || (_FFPresenterSanitary != null && _FFPresenterSanitary.HasChanges)
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsCountry_Country = idfsCountry;
            var _prev_idfsRegion_Region = idfsRegion;
            var _prev_idfsRayon_Rayon = idfsRayon;
            var _prev_idfsSettlement_Settlement = idfsSettlement;
            var _prev_idfSentByOffice_SentByOffice = idfSentByOffice;
            var _prev_idfReceivedByOffice_ReceivedByOffice = idfReceivedByOffice;
            var _prev_idfSentByPerson_SentByPerson = idfSentByPerson;
            var _prev_idfReceivedByPerson_ReceivedByPerson = idfReceivedByPerson;
            var _prev_YearForAggr_YearAggr = YearForAggr;
            var _prev_QuarterForAggr_QuarterAggr = QuarterForAggr;
            var _prev_MonthForAggr_MonthAggr = MonthForAggr;
            var _prev_WeekForAggr_WeekAggr = WeekForAggr;
            var _prev_idfVersion_AggregateMatrixVersionCase = idfVersion;
            var _prev_idfDiagnosticVersion_AggregateMatrixVersionDiagnostic = idfDiagnosticVersion;
            var _prev_idfProphylacticVersion_AggregateMatrixVersionProphylactic = idfProphylacticVersion;
            var _prev_idfSanitaryVersion_AggregateMatrixVersionSanitary = idfSanitaryVersion;
            var _prev_idfsCaseObservationFormTemplate_FFTemplateCase = idfsCaseObservationFormTemplate;
            var _prev_idfsDiagnosticObservationFormTemplate_FFTemplateDiagnostic = idfsDiagnosticObservationFormTemplate;
            var _prev_idfsProphylacticObservationFormTemplate_FFTemplateProphylactic = idfsProphylacticObservationFormTemplate;
            var _prev_idfsSanitaryObservationFormTemplate_FFTemplateSanitary = idfsSanitaryObservationFormTemplate;
            base.RejectChanges();
        
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
            if (_prev_idfSentByOffice_SentByOffice != idfSentByOffice)
            {
                _SentByOffice = _SentByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfSentByOffice);
            }
            if (_prev_idfReceivedByOffice_ReceivedByOffice != idfReceivedByOffice)
            {
                _ReceivedByOffice = _ReceivedByOfficeLookup.FirstOrDefault(c => c.idfInstitution == idfReceivedByOffice);
            }
            if (_prev_idfSentByPerson_SentByPerson != idfSentByPerson)
            {
                _SentByPerson = _SentByPersonLookup.FirstOrDefault(c => c.idfPerson == idfSentByPerson);
            }
            if (_prev_idfReceivedByPerson_ReceivedByPerson != idfReceivedByPerson)
            {
                _ReceivedByPerson = _ReceivedByPersonLookup.FirstOrDefault(c => c.idfPerson == idfReceivedByPerson);
            }
            if (_prev_YearForAggr_YearAggr != YearForAggr)
            {
                _YearAggr = _YearAggrLookup.FirstOrDefault(c => c.idfsBaseReference == YearForAggr);
            }
            if (_prev_QuarterForAggr_QuarterAggr != QuarterForAggr)
            {
                _QuarterAggr = _QuarterAggrLookup.FirstOrDefault(c => c.idfsBaseReference == QuarterForAggr);
            }
            if (_prev_MonthForAggr_MonthAggr != MonthForAggr)
            {
                _MonthAggr = _MonthAggrLookup.FirstOrDefault(c => c.idfsBaseReference == MonthForAggr);
            }
            if (_prev_WeekForAggr_WeekAggr != WeekForAggr)
            {
                _WeekAggr = _WeekAggrLookup.FirstOrDefault(c => c.idfsBaseReference == WeekForAggr);
            }
            if (_prev_idfVersion_AggregateMatrixVersionCase != idfVersion)
            {
                _AggregateMatrixVersionCase = _AggregateMatrixVersionCaseLookup.FirstOrDefault(c => c.idfVersion == idfVersion);
            }
            if (_prev_idfDiagnosticVersion_AggregateMatrixVersionDiagnostic != idfDiagnosticVersion)
            {
                _AggregateMatrixVersionDiagnostic = _AggregateMatrixVersionDiagnosticLookup.FirstOrDefault(c => c.idfVersion == idfDiagnosticVersion);
            }
            if (_prev_idfProphylacticVersion_AggregateMatrixVersionProphylactic != idfProphylacticVersion)
            {
                _AggregateMatrixVersionProphylactic = _AggregateMatrixVersionProphylacticLookup.FirstOrDefault(c => c.idfVersion == idfProphylacticVersion);
            }
            if (_prev_idfSanitaryVersion_AggregateMatrixVersionSanitary != idfSanitaryVersion)
            {
                _AggregateMatrixVersionSanitary = _AggregateMatrixVersionSanitaryLookup.FirstOrDefault(c => c.idfVersion == idfSanitaryVersion);
            }
            if (_prev_idfsCaseObservationFormTemplate_FFTemplateCase != idfsCaseObservationFormTemplate)
            {
                _FFTemplateCase = _FFTemplateCaseLookup.FirstOrDefault(c => c.idfsFormTemplate == idfsCaseObservationFormTemplate);
            }
            if (_prev_idfsDiagnosticObservationFormTemplate_FFTemplateDiagnostic != idfsDiagnosticObservationFormTemplate)
            {
                _FFTemplateDiagnostic = _FFTemplateDiagnosticLookup.FirstOrDefault(c => c.idfsFormTemplate == idfsDiagnosticObservationFormTemplate);
            }
            if (_prev_idfsProphylacticObservationFormTemplate_FFTemplateProphylactic != idfsProphylacticObservationFormTemplate)
            {
                _FFTemplateProphylactic = _FFTemplateProphylacticLookup.FirstOrDefault(c => c.idfsFormTemplate == idfsProphylacticObservationFormTemplate);
            }
            if (_prev_idfsSanitaryObservationFormTemplate_FFTemplateSanitary != idfsSanitaryObservationFormTemplate)
            {
                _FFTemplateSanitary = _FFTemplateSanitaryLookup.FirstOrDefault(c => c.idfsFormTemplate == idfsSanitaryObservationFormTemplate);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (Settings != null) Settings.DeepRejectChanges();
                
            if (FFPresenterCase != null) FFPresenterCase.DeepRejectChanges();
                
            if (FFPresenterDiagnostic != null) FFPresenterDiagnostic.DeepRejectChanges();
                
            if (FFPresenterProphylactic != null) FFPresenterProphylactic.DeepRejectChanges();
                
            if (FFPresenterSanitary != null) FFPresenterSanitary.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Settings != null) _Settings.DeepAcceptChanges();
                
            if (_FFPresenterCase != null) _FFPresenterCase.DeepAcceptChanges();
                
            if (_FFPresenterDiagnostic != null) _FFPresenterDiagnostic.DeepAcceptChanges();
                
            if (_FFPresenterProphylactic != null) _FFPresenterProphylactic.DeepAcceptChanges();
                
            if (_FFPresenterSanitary != null) _FFPresenterSanitary.DeepAcceptChanges();
                
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
        
            if (_Settings != null) _Settings.SetChange();
                
            if (_FFPresenterCase != null) _FFPresenterCase.SetChange();
                
            if (_FFPresenterDiagnostic != null) _FFPresenterDiagnostic.SetChange();
                
            if (_FFPresenterProphylactic != null) _FFPresenterProphylactic.SetChange();
                
            if (_FFPresenterSanitary != null) _FFPresenterSanitary.SetChange();
                
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

        private bool IsRIRPropChanged(string fld, AggregateCaseHeader c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, AggregateCaseHeader c)
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
        

      

        public AggregateCaseHeader()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AggregateCaseHeader_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AggregateCaseHeader_PropertyChanged);
        }
        private void AggregateCaseHeader_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AggregateCaseHeader).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsAggrCaseType)
                OnPropertyChanged(_str_NumberingObject);
                  
            if (e.PropertyName == _str_datSentByDate)
                OnPropertyChanged(_str_strReadOnlyEnteredByDate);
                  
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
            AggregateCaseHeader obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AggregateCaseHeader obj = this;
            
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

    
        private static string[] readonly_names1 = "strReadOnlyEnteredByDate".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strSentByOffice,strReceivedByOffice,strEnteredByOffice,strSentByPerson,strReceivedByPerson,strEnteredByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "datEnteredByDate,strCaseID".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "Country,idfsCountry".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AggregateCaseHeader, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AggregateCaseHeader, bool>(c => true)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AggregateCaseHeader, bool>(c => true)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AggregateCaseHeader, bool>(c => true)(this);
            
            return ReadOnly || new Func<AggregateCaseHeader, bool>(c => false)(this);
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
                if (_Settings != null)
                    _Settings._isValid &= value;
                
                if (_FFPresenterCase != null)
                    _FFPresenterCase._isValid &= value;
                
                if (_FFPresenterDiagnostic != null)
                    _FFPresenterDiagnostic._isValid &= value;
                
                if (_FFPresenterProphylactic != null)
                    _FFPresenterProphylactic._isValid &= value;
                
                if (_FFPresenterSanitary != null)
                    _FFPresenterSanitary._isValid &= value;
                
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_Settings != null)
                    _Settings.ReadOnly |= value;
                
                if (_FFPresenterCase != null)
                    _FFPresenterCase.ReadOnly |= value;
                
                if (_FFPresenterDiagnostic != null)
                    _FFPresenterDiagnostic.ReadOnly |= value;
                
                if (_FFPresenterProphylactic != null)
                    _FFPresenterProphylactic.ReadOnly |= value;
                
                if (_FFPresenterSanitary != null)
                    _FFPresenterSanitary.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<AggregateCaseHeader, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AggregateCaseHeader, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AggregateCaseHeader, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AggregateCaseHeader, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AggregateCaseHeader, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<AggregateCaseHeader, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<AggregateCaseHeader, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~AggregateCaseHeader()
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
                
                if (_Settings != null)
                    Settings.Dispose();
                
                if (_FFPresenterCase != null)
                    FFPresenterCase.Dispose();
                
                if (_FFPresenterDiagnostic != null)
                    FFPresenterDiagnostic.Dispose();
                
                if (_FFPresenterProphylactic != null)
                    FFPresenterProphylactic.Dispose();
                
                if (_FFPresenterSanitary != null)
                    FFPresenterSanitary.Dispose();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("CountryLookup", this);
                
                LookupManager.RemoveObject("RegionAggrLookup", this);
                
                LookupManager.RemoveObject("RayonAggrLookup", this);
                
                LookupManager.RemoveObject("SettlementAggrLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("WiderPersonLookup", this);
                
                LookupManager.RemoveObject("WiderPersonLookup", this);
                
                LookupManager.RemoveObject("rftSampleStatus", this);
                
                LookupManager.RemoveObject("rftSampleStatus", this);
                
                LookupManager.RemoveObject("rftSampleStatus", this);
                
                LookupManager.RemoveObject("rftSampleStatus", this);
                
                LookupManager.RemoveObject("AggregateMatrixVersionLookup", this);
                
                LookupManager.RemoveObject("AggregateMatrixVersionLookup", this);
                
                LookupManager.RemoveObject("AggregateMatrixVersionLookup", this);
                
                LookupManager.RemoveObject("AggregateMatrixVersionLookup", this);
                
                LookupManager.RemoveObject("FFTemplateLookup", this);
                
                LookupManager.RemoveObject("FFTemplateLookup", this);
                
                LookupManager.RemoveObject("FFTemplateLookup", this);
                
                LookupManager.RemoveObject("FFTemplateLookup", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "CountryLookup")
                _getAccessor().LoadLookup_Country(manager, this);
            
            if (lookup_object == "RegionAggrLookup")
                _getAccessor().LoadLookup_Region(manager, this);
            
            if (lookup_object == "RayonAggrLookup")
                _getAccessor().LoadLookup_Rayon(manager, this);
            
            if (lookup_object == "SettlementAggrLookup")
                _getAccessor().LoadLookup_Settlement(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_SentByOffice(manager, this);
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_ReceivedByOffice(manager, this);
            
            if (lookup_object == "WiderPersonLookup")
                _getAccessor().LoadLookup_SentByPerson(manager, this);
            
            if (lookup_object == "WiderPersonLookup")
                _getAccessor().LoadLookup_ReceivedByPerson(manager, this);
            
            if (lookup_object == "rftSampleStatus")
                _getAccessor().LoadLookup_YearAggr(manager, this);
            
            if (lookup_object == "rftSampleStatus")
                _getAccessor().LoadLookup_QuarterAggr(manager, this);
            
            if (lookup_object == "rftSampleStatus")
                _getAccessor().LoadLookup_MonthAggr(manager, this);
            
            if (lookup_object == "rftSampleStatus")
                _getAccessor().LoadLookup_WeekAggr(manager, this);
            
            if (lookup_object == "AggregateMatrixVersionLookup")
                _getAccessor().LoadLookup_AggregateMatrixVersionCase(manager, this);
            
            if (lookup_object == "AggregateMatrixVersionLookup")
                _getAccessor().LoadLookup_AggregateMatrixVersionDiagnostic(manager, this);
            
            if (lookup_object == "AggregateMatrixVersionLookup")
                _getAccessor().LoadLookup_AggregateMatrixVersionProphylactic(manager, this);
            
            if (lookup_object == "AggregateMatrixVersionLookup")
                _getAccessor().LoadLookup_AggregateMatrixVersionSanitary(manager, this);
            
            if (lookup_object == "FFTemplateLookup")
                _getAccessor().LoadLookup_FFTemplateCase(manager, this);
            
            if (lookup_object == "FFTemplateLookup")
                _getAccessor().LoadLookup_FFTemplateDiagnostic(manager, this);
            
            if (lookup_object == "FFTemplateLookup")
                _getAccessor().LoadLookup_FFTemplateProphylactic(manager, this);
            
            if (lookup_object == "FFTemplateLookup")
                _getAccessor().LoadLookup_FFTemplateSanitary(manager, this);
            
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
        
            if (_Settings != null) _Settings.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_FFPresenterCase != null) _FFPresenterCase.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_FFPresenterDiagnostic != null) _FFPresenterDiagnostic.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_FFPresenterProphylactic != null) _FFPresenterProphylactic.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_FFPresenterSanitary != null) _FFPresenterSanitary.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<AggregateCaseHeader>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<AggregateCaseHeader>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<AggregateCaseHeader>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfAggrCase"; } }
            #endregion
        
            public delegate void on_action(AggregateCaseHeader obj);
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
            private FFPresenterModel.Accessor FFPresenterCaseAccessor { get { return eidss.model.Schema.FFPresenterModel.Accessor.Instance(m_CS); } }
            private FFPresenterModel.Accessor FFPresenterDiagnosticAccessor { get { return eidss.model.Schema.FFPresenterModel.Accessor.Instance(m_CS); } }
            private FFPresenterModel.Accessor FFPresenterProphylacticAccessor { get { return eidss.model.Schema.FFPresenterModel.Accessor.Instance(m_CS); } }
            private FFPresenterModel.Accessor FFPresenterSanitaryAccessor { get { return eidss.model.Schema.FFPresenterModel.Accessor.Instance(m_CS); } }
            private CountryLookup.Accessor CountryAccessor { get { return eidss.model.Schema.CountryLookup.Accessor.Instance(m_CS); } }
            private RegionAggrLookup.Accessor RegionAccessor { get { return eidss.model.Schema.RegionAggrLookup.Accessor.Instance(m_CS); } }
            private RayonAggrLookup.Accessor RayonAccessor { get { return eidss.model.Schema.RayonAggrLookup.Accessor.Instance(m_CS); } }
            private SettlementAggrLookup.Accessor SettlementAccessor { get { return eidss.model.Schema.SettlementAggrLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor SentByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private OrganizationLookup.Accessor ReceivedByOfficeAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private WiderPersonLookup.Accessor SentByPersonAccessor { get { return eidss.model.Schema.WiderPersonLookup.Accessor.Instance(m_CS); } }
            private WiderPersonLookup.Accessor ReceivedByPersonAccessor { get { return eidss.model.Schema.WiderPersonLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor YearAggrAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor QuarterAggrAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor MonthAggrAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor WeekAggrAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private AggregateMatrixVersionLookup.Accessor AggregateMatrixVersionCaseAccessor { get { return eidss.model.Schema.AggregateMatrixVersionLookup.Accessor.Instance(m_CS); } }
            private AggregateMatrixVersionLookup.Accessor AggregateMatrixVersionDiagnosticAccessor { get { return eidss.model.Schema.AggregateMatrixVersionLookup.Accessor.Instance(m_CS); } }
            private AggregateMatrixVersionLookup.Accessor AggregateMatrixVersionProphylacticAccessor { get { return eidss.model.Schema.AggregateMatrixVersionLookup.Accessor.Instance(m_CS); } }
            private AggregateMatrixVersionLookup.Accessor AggregateMatrixVersionSanitaryAccessor { get { return eidss.model.Schema.AggregateMatrixVersionLookup.Accessor.Instance(m_CS); } }
            private FFTemplateLookup.Accessor FFTemplateCaseAccessor { get { return eidss.model.Schema.FFTemplateLookup.Accessor.Instance(m_CS); } }
            private FFTemplateLookup.Accessor FFTemplateDiagnosticAccessor { get { return eidss.model.Schema.FFTemplateLookup.Accessor.Instance(m_CS); } }
            private FFTemplateLookup.Accessor FFTemplateProphylacticAccessor { get { return eidss.model.Schema.FFTemplateLookup.Accessor.Instance(m_CS); } }
            private FFTemplateLookup.Accessor FFTemplateSanitaryAccessor { get { return eidss.model.Schema.FFTemplateLookup.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null
                            
                        , null, null
                        );
                }
            }
            public virtual AggregateCaseHeader SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null
                            
                        , null, null
                        );
                }
            }

            
            public virtual AggregateCaseHeader SelectByKey(DbManagerProxy manager
                , Int64? idfAggrCase
                , Int64? idfsAggrCaseType
                )
            {
                return _SelectByKey(manager
                    , idfAggrCase
                    , idfsAggrCaseType
                    , null, null
                    );
            }
            

            private AggregateCaseHeader _SelectByKey(DbManagerProxy manager
                , Int64? idfAggrCase
                , Int64? idfsAggrCaseType
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfAggrCase
                    , idfsAggrCaseType
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual AggregateCaseHeader _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfAggrCase
                , Int64? idfsAggrCaseType
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<AggregateCaseHeader> objs = new List<AggregateCaseHeader>();
                sets[0] = new MapResultSet(typeof(AggregateCaseHeader), objs);
                AggregateCaseHeader obj = null;
                try
                {
                    manager
                        .SetSpCommand("spAggregateCaseHeader_SelectDetail"
                            , manager.Parameter("@idfAggrCase", idfAggrCase)
                            , manager.Parameter("@idfsAggrCaseType", idfsAggrCaseType)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    obj = objs[0];
                    obj.m_CS = m_CS;
                    
                  
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    

                    //obj._setParent();
                    if (loaded != null)
                    loaded(obj);
                    obj.Loaded(manager);
                    return obj;
                  }
                  catch(DataException e)
                  {
                    throw DbModelException.Create(obj, e);
                  }
                
            }
    
            internal void _LoadSettings(AggregateCaseHeader obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSettings(manager, obj);
                }
            }
            internal void _LoadSettings(DbManagerProxy manager, AggregateCaseHeader obj)
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
            
            internal void _LoadFFPresenterCase(AggregateCaseHeader obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFFPresenterCase(manager, obj);
                }
            }
            internal void _LoadFFPresenterCase(DbManagerProxy manager, AggregateCaseHeader obj)
            {
              
                if (obj.FFPresenterCase == null && obj.idfCaseObservation != null && obj.idfCaseObservation != 0)
                {
                    obj.FFPresenterCase = FFPresenterCaseAccessor.SelectByKey(manager
                        
                        , obj.idfCaseObservation.Value
                        );
                    if (obj.FFPresenterCase != null)
                    {
                        obj.FFPresenterCase.m_ObjectName = _str_FFPresenterCase;
                    }
                }
                    
              }
            
            internal void _LoadFFPresenterDiagnostic(AggregateCaseHeader obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFFPresenterDiagnostic(manager, obj);
                }
            }
            internal void _LoadFFPresenterDiagnostic(DbManagerProxy manager, AggregateCaseHeader obj)
            {
              
                if (obj.FFPresenterDiagnostic == null && obj.idfDiagnosticObservation != null && obj.idfDiagnosticObservation != 0)
                {
                    obj.FFPresenterDiagnostic = FFPresenterDiagnosticAccessor.SelectByKey(manager
                        
                        , obj.idfDiagnosticObservation.Value
                        );
                    if (obj.FFPresenterDiagnostic != null)
                    {
                        obj.FFPresenterDiagnostic.m_ObjectName = _str_FFPresenterDiagnostic;
                    }
                }
                    
              }
            
            internal void _LoadFFPresenterProphylactic(AggregateCaseHeader obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFFPresenterProphylactic(manager, obj);
                }
            }
            internal void _LoadFFPresenterProphylactic(DbManagerProxy manager, AggregateCaseHeader obj)
            {
              
                if (obj.FFPresenterProphylactic == null && obj.idfProphylacticObservation != null && obj.idfProphylacticObservation != 0)
                {
                    obj.FFPresenterProphylactic = FFPresenterProphylacticAccessor.SelectByKey(manager
                        
                        , obj.idfProphylacticObservation.Value
                        );
                    if (obj.FFPresenterProphylactic != null)
                    {
                        obj.FFPresenterProphylactic.m_ObjectName = _str_FFPresenterProphylactic;
                    }
                }
                    
              }
            
            internal void _LoadFFPresenterSanitary(AggregateCaseHeader obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFFPresenterSanitary(manager, obj);
                }
            }
            internal void _LoadFFPresenterSanitary(DbManagerProxy manager, AggregateCaseHeader obj)
            {
              
                if (obj.FFPresenterSanitary == null && obj.idfSanitaryObservation != null && obj.idfSanitaryObservation != 0)
                {
                    obj.FFPresenterSanitary = FFPresenterSanitaryAccessor.SelectByKey(manager
                        
                        , obj.idfSanitaryObservation.Value
                        );
                    if (obj.FFPresenterSanitary != null)
                    {
                        obj.FFPresenterSanitary.m_ObjectName = _str_FFPresenterSanitary;
                    }
                }
                    
              }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, AggregateCaseHeader obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadFFPresenterCase(manager, obj);
                _LoadFFPresenterDiagnostic(manager, obj);
                _LoadFFPresenterProphylactic(manager, obj);
                _LoadFFPresenterSanitary(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                    obj.CreateFF(manager, obj);
                  
                    obj.YearAggrLookup.AddRange(YearLookupTemplate);
                    obj.YearAggr = obj.YearAggrLookup
                    .Where(c => c.idfsBaseReference == obj.YearForAggr)
                    .SingleOrDefault();
                    if(obj.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter)
                      QuarterLookupTemplate(ref obj);
                    else if(obj.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month || obj.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Day)
                      MonthLookupTemplate(ref obj);
                    else if(obj.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week)
                      WeekLookupTemplate(ref obj);
                  
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, AggregateCaseHeader obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    SettingsAccessor._SetPermitions(obj._permissions, obj.Settings);
                    FFPresenterCaseAccessor._SetPermitions(obj._permissions, obj.FFPresenterCase);
                    FFPresenterDiagnosticAccessor._SetPermitions(obj._permissions, obj.FFPresenterDiagnostic);
                    FFPresenterProphylacticAccessor._SetPermitions(obj._permissions, obj.FFPresenterProphylactic);
                    FFPresenterSanitaryAccessor._SetPermitions(obj._permissions, obj.FFPresenterSanitary);
                    
                    }
                }
            }

    

            private AggregateCaseHeader _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                AggregateCaseHeader obj = null;
                try
                {
                    obj = AggregateCaseHeader.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfAggrCase = (new GetNewIDExtender<AggregateCaseHeader>()).GetScalar(manager, obj, isFake);
                      if(obj.Parent is HumanAggregateCase || obj.Parent is VetAggregateCase)
                        obj.idfCaseObservation = (new GetNewIDExtender<AggregateCaseHeader>()).GetScalar(manager, obj, isFake);
                      else
                      {
                        obj.idfDiagnosticObservation = (new GetNewIDExtender<AggregateCaseHeader>()).GetScalar(manager, obj, isFake);
                        obj.idfProphylacticObservation = (new GetNewIDExtender<AggregateCaseHeader>()).GetScalar(manager, obj, isFake);
                        obj.idfSanitaryObservation = (new GetNewIDExtender<AggregateCaseHeader>()).GetScalar(manager, obj, isFake);
                      }
                    
                obj.strCaseID = new Func<AggregateCaseHeader, string>(c => "(new)")(obj);
                      obj.CreateFF(manager, obj);
                    
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.Country = new Func<AggregateCaseHeader, CountryLookup>(c => 
                                     c.CountryLookup.Where(a => a.idfsCountry == eidss.model.Core.EidssSiteContext.Instance.CountryID)
                                     .SingleOrDefault())(obj);
                obj.datEnteredByDate = new Func<AggregateCaseHeader, DateTime?>(c => DateTime.Now)(obj);
                obj.idfEnteredByOffice = new Func<AggregateCaseHeader, long>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationID)(obj);
                obj.idfEnteredByPerson = new Func<AggregateCaseHeader, long>(c => (long)ModelUserContext.Instance.CurrentUser.EmployeeID)(obj);
                obj.strEnteredByOffice = new Func<AggregateCaseHeader, string>(c => eidss.model.Core.EidssSiteContext.Instance.OrganizationName)(obj);
                obj.strEnteredByPerson = new Func<AggregateCaseHeader, string>(c => ModelUserContext.Instance.CurrentUser.FullName)(obj);
                obj.YearAggr = new Func<AggregateCaseHeader, BaseReference>(c => BaseReference.Accessor.Instance(null).CreateDummy(manager, null, (long)DateTime.Now.Year, DateTime.Now.Year.ToString()))(obj);
                    obj.YearAggrLookup.AddRange(YearLookupTemplate);
                    if(obj.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Region ||
                       obj.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon ||
                       obj.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement)
                         obj.Region = new Func<AggregateCaseHeader, RegionAggrLookup>(c =>
                                         c.RegionLookup.Where(a => a.idfsRegion == eidss.model.Core.EidssSiteContext.Instance.RegionID)
                                         .SingleOrDefault())(obj);
                    if(obj.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon ||
                       obj.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement)
                         obj.Rayon = new Func<AggregateCaseHeader, RayonAggrLookup>(c =>
                                    c.RayonLookup.Where(a => a.idfsRayon == eidss.model.Core.EidssSiteContext.Instance.RayonID)
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
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public AggregateCaseHeader CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AggregateCaseHeader CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AggregateCaseHeader CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public AggregateCaseHeader CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfsAggrCaseType", typeof(long));
                if (pars[1] != null && !(pars[1] is long?)) 
                    throw new TypeMismatchException("idfVersion", typeof(long?));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    , (long?)pars[1]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public AggregateCaseHeader Create(DbManagerProxy manager, IObject Parent
                , long idfsAggrCaseType
                , long? idfVersion
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfsAggrCaseType = new Func<AggregateCaseHeader, long>(c => idfsAggrCaseType)(obj);
                obj.idfVersion = new Func<AggregateCaseHeader, long?>(c => idfVersion)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            public AggregateCaseHeader CreateWithParamsManyVersionsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 4) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfsAggrCaseType", typeof(long));
                if (pars[1] != null && !(pars[1] is long?)) 
                    throw new TypeMismatchException("idfDiagnosticVersion", typeof(long?));
                if (pars[2] != null && !(pars[2] is long?)) 
                    throw new TypeMismatchException("idfProphylacticVersion", typeof(long?));
                if (pars[3] != null && !(pars[3] is long?)) 
                    throw new TypeMismatchException("idfSanitaryVersion", typeof(long?));
                
                return CreateWithParamsManyVersions(manager, Parent
                    , (long)pars[0]
                    , (long?)pars[1]
                    , (long?)pars[2]
                    , (long?)pars[3]
                    );
            }
            public IObject CreateWithParamsManyVersions(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateWithParamsManyVersionsT(manager, Parent, pars);
            }
            public AggregateCaseHeader CreateWithParamsManyVersions(DbManagerProxy manager, IObject Parent
                , long idfsAggrCaseType
                , long? idfDiagnosticVersion
                , long? idfProphylacticVersion
                , long? idfSanitaryVersion
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfsAggrCaseType = new Func<AggregateCaseHeader, long>(c => idfsAggrCaseType)(obj);
                obj.idfDiagnosticVersion = new Func<AggregateCaseHeader, long?>(c => idfDiagnosticVersion)(obj);
                obj.idfProphylacticVersion = new Func<AggregateCaseHeader, long?>(c => idfProphylacticVersion)(obj);
                obj.idfSanitaryVersion = new Func<AggregateCaseHeader, long?>(c => idfSanitaryVersion)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(AggregateCaseHeader obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AggregateCaseHeader obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datSentByDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datSentByDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datReceivedByDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datReceivedByDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_datEnteredByDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datEnteredByDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
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
                    
                        if (e.PropertyName == _str_idfSentByOffice)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_SentByPerson(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfReceivedByOffice)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_ReceivedByPerson(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_idfSentByOffice)
                        {
                    
                obj.SentByPerson = (new SetScalarHandler()).Handler(obj,
                    obj.idfSentByOffice, obj.idfSentByOffice_Previous, obj.SentByPerson,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_idfReceivedByOffice)
                        {
                    
                obj.ReceivedByPerson = (new SetScalarHandler()).Handler(obj,
                    obj.idfReceivedByOffice, obj.idfReceivedByOffice_Previous, obj.ReceivedByPerson,
                    (o, fld, prev_fld) => null);
            
                        }
                    
                        if (e.PropertyName == _str_YearForAggr)
                        {
                    
                      if(obj.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter)
                        QuarterLookupTemplate(ref obj);
                      else if(obj.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month || obj.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Day)
                        MonthLookupTemplate(ref obj);
                      else if(obj.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week)
                        WeekLookupTemplate(ref obj);
                    
                        }
                    
                        if (e.PropertyName == _str_idfVersion)
                        {
                    
                          obj.FFPresenterCase.SetProperties(obj.idfsCaseObservationFormTemplate.Value, obj.idfAggrCase);
                          obj.FFPresenterCase.PrepareAggregateCase(obj.idfsAggrCaseType == (long)AggregateCaseType.HumanAggregateCase ? AggregateCaseSectionEnum.HumanCase : AggregateCaseSectionEnum.VetCase, obj.idfVersion.Value);
                    
                        }
                    
                        if (e.PropertyName == _str_idfsCaseObservationFormTemplate)
                        {
                    
                          obj.FFPresenterCase.SetProperties(obj.idfsCaseObservationFormTemplate.Value, obj.idfAggrCase);
                          obj.FFPresenterCase.PrepareAggregateCase(obj.idfsAggrCaseType == (long)AggregateCaseType.HumanAggregateCase ? AggregateCaseSectionEnum.HumanCase : AggregateCaseSectionEnum.VetCase, obj.idfVersion.Value);
                    
                        }
                    
                        if (e.PropertyName == _str_idfDiagnosticVersion)
                        {
                    
                          obj.FFPresenterDiagnostic.SetProperties(obj.idfsDiagnosticObservationFormTemplate.Value, obj.idfAggrCase);
                          obj.FFPresenterDiagnostic.PrepareAggregateCase(AggregateCaseSectionEnum.DiagnosticAction, obj.idfDiagnosticVersion.Value);
                    
                        }
                    
                        if (e.PropertyName == _str_idfsDiagnosticObservationFormTemplate)
                        {
                    
                          obj.FFPresenterDiagnostic.SetProperties(obj.idfsDiagnosticObservationFormTemplate.Value, obj.idfAggrCase);
                          obj.FFPresenterDiagnostic.PrepareAggregateCase(AggregateCaseSectionEnum.DiagnosticAction, obj.idfDiagnosticVersion.Value);
                    
                        }
                    
                        if (e.PropertyName == _str_idfProphylacticVersion)
                        {
                    
                          obj.FFPresenterProphylactic.SetProperties(obj.idfsProphylacticObservationFormTemplate.Value, obj.idfAggrCase);
                          obj.FFPresenterProphylactic.PrepareAggregateCase(AggregateCaseSectionEnum.ProphylacticAction, obj.idfProphylacticVersion.Value);
                    
                        }
                    
                        if (e.PropertyName == _str_idfsProphylacticObservationFormTemplate)
                        {
                    
                          obj.FFPresenterProphylactic.SetProperties(obj.idfsProphylacticObservationFormTemplate.Value, obj.idfAggrCase);
                          obj.FFPresenterProphylactic.PrepareAggregateCase(AggregateCaseSectionEnum.ProphylacticAction, obj.idfProphylacticVersion.Value);
                    
                        }
                    
                        if (e.PropertyName == _str_idfSanitaryVersion)
                        {
                    
                          obj.FFPresenterSanitary.SetProperties(obj.idfsSanitaryObservationFormTemplate.Value, obj.idfAggrCase);
                          obj.FFPresenterSanitary.PrepareAggregateCase(AggregateCaseSectionEnum.SanitaryAction, obj.idfSanitaryVersion.Value);
                    
                        }
                    
                        if (e.PropertyName == _str_idfsSanitaryObservationFormTemplate)
                        {
                    
                          obj.FFPresenterSanitary.SetProperties(obj.idfsSanitaryObservationFormTemplate.Value, obj.idfAggrCase);
                          obj.FFPresenterSanitary.PrepareAggregateCase(AggregateCaseSectionEnum.SanitaryAction, obj.idfSanitaryVersion.Value);
                    
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Country(DbManagerProxy manager, AggregateCaseHeader obj)
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
                        .SingleOrDefault(c => c.idfsCountry == obj.idfsCountry);
                    
                }
              
                LookupManager.AddObject("CountryLookup", obj, CountryAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Region(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.RegionLookup.Clear();
                
                obj.RegionLookup.Add(RegionAccessor.CreateNewT(manager, null));
                
                obj.RegionLookup.AddRange(RegionAccessor.SelectLookupList(manager
                    
                    , new Func<AggregateCaseHeader, long>(c => c.idfsCountry ?? 0)(obj)
                            
                    , null
                    , new Func<AggregateCaseHeader, long?>(c => c.idfsAggrCaseType)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRegion == obj.idfsRegion))
                    
                    .ToList());
                
                if (obj.idfsRegion != null && obj.idfsRegion != 0)
                {
                    obj.Region = obj.RegionLookup
                        .SingleOrDefault(c => c.idfsRegion == obj.idfsRegion);
                    
                }
              
                LookupManager.AddObject("RegionAggrLookup", obj, RegionAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Rayon(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.RayonLookup.Clear();
                
                obj.RayonLookup.Add(RayonAccessor.CreateNewT(manager, null));
                
                obj.RayonLookup.AddRange(RayonAccessor.SelectLookupList(manager
                    
                    , new Func<AggregateCaseHeader, long>(c => c.idfsRegion ?? 0)(obj)
                            
                    , null
                    , new Func<AggregateCaseHeader, long?>(c => c.idfsAggrCaseType)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsRayon == obj.idfsRayon))
                    
                    .ToList());
                
                if (obj.idfsRayon != null && obj.idfsRayon != 0)
                {
                    obj.Rayon = obj.RayonLookup
                        .SingleOrDefault(c => c.idfsRayon == obj.idfsRayon);
                    
                }
              
                LookupManager.AddObject("RayonAggrLookup", obj, RayonAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Settlement(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.SettlementLookup.Clear();
                
                obj.SettlementLookup.Add(SettlementAccessor.CreateNewT(manager, null));
                
                obj.SettlementLookup.AddRange(SettlementAccessor.SelectLookupList(manager
                    
                    , new Func<AggregateCaseHeader, long>(c => c.idfsRayon ?? 0)(obj)
                            
                    , null
                    , new Func<AggregateCaseHeader, long?>(c => c.idfsAggrCaseType)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSettlement == obj.idfsSettlement))
                    
                    .ToList());
                
                if (obj.idfsSettlement != null && obj.idfsSettlement != 0)
                {
                    obj.Settlement = obj.SettlementLookup
                        .SingleOrDefault(c => c.idfsSettlement == obj.idfsSettlement);
                    
                }
              
                LookupManager.AddObject("SettlementAggrLookup", obj, SettlementAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_SentByOffice(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.SentByOfficeLookup.Clear();
                
                obj.SentByOfficeLookup.Add(SentByOfficeAccessor.CreateNewT(manager, null));
                
                obj.SentByOfficeLookup.AddRange(SentByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (((c.intHACode??0) & obj.intHACode) != 0) || c.idfInstitution == obj.idfSentByOffice)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfSentByOffice))
                    
                    .ToList());
                
                if (obj.idfSentByOffice != 0)
                {
                    obj.SentByOffice = obj.SentByOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfSentByOffice);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, SentByOfficeAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_ReceivedByOffice(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.ReceivedByOfficeLookup.Clear();
                
                obj.ReceivedByOfficeLookup.Add(ReceivedByOfficeAccessor.CreateNewT(manager, null));
                
                obj.ReceivedByOfficeLookup.AddRange(ReceivedByOfficeAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (((c.intHACode??0) & obj.intHACode) != 0) || c.idfInstitution == obj.idfReceivedByOffice)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfReceivedByOffice))
                    
                    .ToList());
                
                if (obj.idfReceivedByOffice != null && obj.idfReceivedByOffice != 0)
                {
                    obj.ReceivedByOffice = obj.ReceivedByOfficeLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfReceivedByOffice);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, ReceivedByOfficeAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_SentByPerson(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.SentByPersonLookup.Clear();
                
                obj.SentByPersonLookup.Add(SentByPersonAccessor.CreateNewT(manager, null));
                
                obj.SentByPersonLookup.AddRange(SentByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<AggregateCaseHeader, long>(c => c.idfSentByOffice == null ? -1 : c.idfSentByOffice)(obj)
                            
                    , null
                    , false
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfSentByPerson))
                    
                    .ToList());
                
                if (obj.idfSentByPerson != 0)
                {
                    obj.SentByPerson = obj.SentByPersonLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfSentByPerson);
                    
                }
              
                LookupManager.AddObject("WiderPersonLookup", obj, SentByPersonAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_ReceivedByPerson(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.ReceivedByPersonLookup.Clear();
                
                obj.ReceivedByPersonLookup.Add(ReceivedByPersonAccessor.CreateNewT(manager, null));
                
                obj.ReceivedByPersonLookup.AddRange(ReceivedByPersonAccessor.SelectLookupList(manager
                    
                    , new Func<AggregateCaseHeader, long>(c => c.idfReceivedByOffice ?? -1L)(obj)
                            
                    , null
                    , false
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfReceivedByPerson))
                    
                    .ToList());
                
                if (obj.idfReceivedByPerson != null && obj.idfReceivedByPerson != 0)
                {
                    obj.ReceivedByPerson = obj.ReceivedByPersonLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfReceivedByPerson);
                    
                }
              
                LookupManager.AddObject("WiderPersonLookup", obj, ReceivedByPersonAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_YearAggr(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.YearAggrLookup.Clear();
                
                obj.YearAggrLookup.Add(YearAggrAccessor.CreateNewT(manager, null));
                
                obj.YearAggrLookup.AddRange(YearAggrAccessor.rftSampleStatus_SelectList(manager
                    
                    )
                    .Where(c=>c.idfsBaseReference == 0)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.YearForAggr))
                    
                    .ToList());
                
                if (obj.YearForAggr != null && obj.YearForAggr != 0)
                {
                    obj.YearAggr = obj.YearAggrLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.YearForAggr);
                    
                }
              
                LookupManager.AddObject("rftSampleStatus", obj, YearAggrAccessor.GetType(), "rftSampleStatus_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_QuarterAggr(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.QuarterAggrLookup.Clear();
                
                obj.QuarterAggrLookup.Add(QuarterAggrAccessor.CreateNewT(manager, null));
                
                obj.QuarterAggrLookup.AddRange(QuarterAggrAccessor.rftSampleStatus_SelectList(manager
                    
                    )
                    .Where(c=>c.idfsBaseReference == 0)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.QuarterForAggr))
                    
                    .ToList());
                
                if (obj.QuarterForAggr != null && obj.QuarterForAggr != 0)
                {
                    obj.QuarterAggr = obj.QuarterAggrLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.QuarterForAggr);
                    
                }
              
                LookupManager.AddObject("rftSampleStatus", obj, QuarterAggrAccessor.GetType(), "rftSampleStatus_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_MonthAggr(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.MonthAggrLookup.Clear();
                
                obj.MonthAggrLookup.Add(MonthAggrAccessor.CreateNewT(manager, null));
                
                obj.MonthAggrLookup.AddRange(MonthAggrAccessor.rftSampleStatus_SelectList(manager
                    
                    )
                    .Where(c=>c.idfsBaseReference == 0)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.MonthForAggr))
                    
                    .ToList());
                
                if (obj.MonthForAggr != null && obj.MonthForAggr != 0)
                {
                    obj.MonthAggr = obj.MonthAggrLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.MonthForAggr);
                    
                }
              
                LookupManager.AddObject("rftSampleStatus", obj, MonthAggrAccessor.GetType(), "rftSampleStatus_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_WeekAggr(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.WeekAggrLookup.Clear();
                
                obj.WeekAggrLookup.Add(WeekAggrAccessor.CreateNewT(manager, null));
                
                obj.WeekAggrLookup.AddRange(WeekAggrAccessor.rftSampleStatus_SelectList(manager
                    
                    )
                    .Where(c=>c.idfsBaseReference == 0)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.WeekForAggr))
                    
                    .ToList());
                
                if (obj.WeekForAggr != null && obj.WeekForAggr != 0)
                {
                    obj.WeekAggr = obj.WeekAggrLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.WeekForAggr);
                    
                }
              
                LookupManager.AddObject("rftSampleStatus", obj, WeekAggrAccessor.GetType(), "rftSampleStatus_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_AggregateMatrixVersionCase(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.AggregateMatrixVersionCaseLookup.Clear();
                
                obj.AggregateMatrixVersionCaseLookup.AddRange(AggregateMatrixVersionCaseAccessor.SelectLookupList(manager
                    
                    , new Func<AggregateCaseHeader, long?>(c => c.idfsAggrCaseType == (long)AggregateCaseType.HumanAggregateCase ? (long)AggregateCaseSectionEnum.HumanCase :
                            (c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateCase ? (long)AggregateCaseSectionEnum.VetCase : 0))(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfVersion == obj.idfVersion))
                    
                    .ToList());
                
                if (obj.idfVersion != null && obj.idfVersion != 0)
                {
                    obj.AggregateMatrixVersionCase = obj.AggregateMatrixVersionCaseLookup
                        .SingleOrDefault(c => c.idfVersion == obj.idfVersion);
                    
                }
              
                LookupManager.AddObject("AggregateMatrixVersionLookup", obj, AggregateMatrixVersionCaseAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_AggregateMatrixVersionDiagnostic(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.AggregateMatrixVersionDiagnosticLookup.Clear();
                
                obj.AggregateMatrixVersionDiagnosticLookup.AddRange(AggregateMatrixVersionDiagnosticAccessor.SelectLookupList(manager
                    
                    , new Func<AggregateCaseHeader, long?>(c => c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateAction ? (long)AggregateCaseSectionEnum.DiagnosticAction : 0)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfVersion == obj.idfDiagnosticVersion))
                    
                    .ToList());
                
                if (obj.idfDiagnosticVersion != null && obj.idfDiagnosticVersion != 0)
                {
                    obj.AggregateMatrixVersionDiagnostic = obj.AggregateMatrixVersionDiagnosticLookup
                        .SingleOrDefault(c => c.idfVersion == obj.idfDiagnosticVersion);
                    
                }
              
                LookupManager.AddObject("AggregateMatrixVersionLookup", obj, AggregateMatrixVersionDiagnosticAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_AggregateMatrixVersionProphylactic(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.AggregateMatrixVersionProphylacticLookup.Clear();
                
                obj.AggregateMatrixVersionProphylacticLookup.AddRange(AggregateMatrixVersionProphylacticAccessor.SelectLookupList(manager
                    
                    , new Func<AggregateCaseHeader, long?>(c => c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateAction ? (long)AggregateCaseSectionEnum.ProphylacticAction : 0)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfVersion == obj.idfProphylacticVersion))
                    
                    .ToList());
                
                if (obj.idfProphylacticVersion != null && obj.idfProphylacticVersion != 0)
                {
                    obj.AggregateMatrixVersionProphylactic = obj.AggregateMatrixVersionProphylacticLookup
                        .SingleOrDefault(c => c.idfVersion == obj.idfProphylacticVersion);
                    
                }
              
                LookupManager.AddObject("AggregateMatrixVersionLookup", obj, AggregateMatrixVersionProphylacticAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_AggregateMatrixVersionSanitary(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.AggregateMatrixVersionSanitaryLookup.Clear();
                
                obj.AggregateMatrixVersionSanitaryLookup.AddRange(AggregateMatrixVersionSanitaryAccessor.SelectLookupList(manager
                    
                    , new Func<AggregateCaseHeader, long?>(c => c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateAction ? (long)AggregateCaseSectionEnum.SanitaryAction : 0)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfVersion == obj.idfSanitaryVersion))
                    
                    .ToList());
                
                if (obj.idfSanitaryVersion != null && obj.idfSanitaryVersion != 0)
                {
                    obj.AggregateMatrixVersionSanitary = obj.AggregateMatrixVersionSanitaryLookup
                        .SingleOrDefault(c => c.idfVersion == obj.idfSanitaryVersion);
                    
                }
              
                LookupManager.AddObject("AggregateMatrixVersionLookup", obj, AggregateMatrixVersionSanitaryAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_FFTemplateCase(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.FFTemplateCaseLookup.Clear();
                
                obj.FFTemplateCaseLookup.AddRange(FFTemplateCaseAccessor.SelectLookupList(manager
                    
                    , null
                    , new Func<AggregateCaseHeader, long?>(c => c.idfsAggrCaseType == (long)AggregateCaseType.HumanAggregateCase ? (long)FFTypeEnum.HumanAggregateCase :
                            (c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateCase ? (long)FFTypeEnum.VetAggregateCase : 0))(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsFormTemplate == obj.idfsCaseObservationFormTemplate))
                    
                    .ToList());
                
                if (obj.idfsCaseObservationFormTemplate != null && obj.idfsCaseObservationFormTemplate != 0)
                {
                    obj.FFTemplateCase = obj.FFTemplateCaseLookup
                        .SingleOrDefault(c => c.idfsFormTemplate == obj.idfsCaseObservationFormTemplate);
                    
                }
              
                LookupManager.AddObject("FFTemplateLookup", obj, FFTemplateCaseAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_FFTemplateDiagnostic(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.FFTemplateDiagnosticLookup.Clear();
                
                obj.FFTemplateDiagnosticLookup.AddRange(FFTemplateDiagnosticAccessor.SelectLookupList(manager
                    
                    , null
                    , new Func<AggregateCaseHeader, long?>(c => c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateAction ? (long)FFTypeEnum.VetEpizooticActionDiagnosisInv : 0)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsFormTemplate == obj.idfsDiagnosticObservationFormTemplate))
                    
                    .ToList());
                
                if (obj.idfsDiagnosticObservationFormTemplate != null && obj.idfsDiagnosticObservationFormTemplate != 0)
                {
                    obj.FFTemplateDiagnostic = obj.FFTemplateDiagnosticLookup
                        .SingleOrDefault(c => c.idfsFormTemplate == obj.idfsDiagnosticObservationFormTemplate);
                    
                }
              
                LookupManager.AddObject("FFTemplateLookup", obj, FFTemplateDiagnosticAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_FFTemplateProphylactic(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.FFTemplateProphylacticLookup.Clear();
                
                obj.FFTemplateProphylacticLookup.AddRange(FFTemplateProphylacticAccessor.SelectLookupList(manager
                    
                    , null
                    , new Func<AggregateCaseHeader, long?>(c => c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateAction ? (long)FFTypeEnum.VetEpizooticActionTreatment : 0)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsFormTemplate == obj.idfsProphylacticObservationFormTemplate))
                    
                    .ToList());
                
                if (obj.idfsProphylacticObservationFormTemplate != null && obj.idfsProphylacticObservationFormTemplate != 0)
                {
                    obj.FFTemplateProphylactic = obj.FFTemplateProphylacticLookup
                        .SingleOrDefault(c => c.idfsFormTemplate == obj.idfsProphylacticObservationFormTemplate);
                    
                }
              
                LookupManager.AddObject("FFTemplateLookup", obj, FFTemplateProphylacticAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_FFTemplateSanitary(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                obj.FFTemplateSanitaryLookup.Clear();
                
                obj.FFTemplateSanitaryLookup.AddRange(FFTemplateSanitaryAccessor.SelectLookupList(manager
                    
                    , null
                    , new Func<AggregateCaseHeader, long?>(c => c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateAction ? (long)FFTypeEnum.VetEpizooticAction : 0)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsFormTemplate == obj.idfsSanitaryObservationFormTemplate))
                    
                    .ToList());
                
                if (obj.idfsSanitaryObservationFormTemplate != null && obj.idfsSanitaryObservationFormTemplate != 0)
                {
                    obj.FFTemplateSanitary = obj.FFTemplateSanitaryLookup
                        .SingleOrDefault(c => c.idfsFormTemplate == obj.idfsSanitaryObservationFormTemplate);
                    
                }
              
                LookupManager.AddObject("FFTemplateLookup", obj, FFTemplateSanitaryAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
                LoadLookup_SentByOffice(manager, obj);
                
                LoadLookup_ReceivedByOffice(manager, obj);
                
                LoadLookup_SentByPerson(manager, obj);
                
                LoadLookup_ReceivedByPerson(manager, obj);
                
                LoadLookup_YearAggr(manager, obj);
                
                LoadLookup_QuarterAggr(manager, obj);
                
                LoadLookup_MonthAggr(manager, obj);
                
                LoadLookup_WeekAggr(manager, obj);
                
                LoadLookup_AggregateMatrixVersionCase(manager, obj);
                
                LoadLookup_AggregateMatrixVersionDiagnostic(manager, obj);
                
                LoadLookup_AggregateMatrixVersionProphylactic(manager, obj);
                
                LoadLookup_AggregateMatrixVersionSanitary(manager, obj);
                
                LoadLookup_FFTemplateCase(manager, obj);
                
                LoadLookup_FFTemplateDiagnostic(manager, obj);
                
                LoadLookup_FFTemplateProphylactic(manager, obj);
                
                LoadLookup_FFTemplateSanitary(manager, obj);
                
            }
    
            [SprocName("spAggregateCase_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spAggregateCase_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spAggregateCaseHeader_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput("strCaseID")] AggregateCaseHeader obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput("strCaseID")] AggregateCaseHeader obj)
            {
                
                _post(manager, obj);
                
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
                        AggregateCaseHeader bo = obj as AggregateCaseHeader;
                        
                        long mainObject = bo.idfAggrCase;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                            if (new Func<AggregateCaseHeader, bool>(c => c.idfsAggrCaseType == (long)AggregateCaseType.HumanAggregateCase)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.HumanAggregateCaseCreatedLocal, mainObject, "" });
                            
                            if (new Func<AggregateCaseHeader, bool>(c => c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateCase)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.VetAggregateCaseCreatedLocal, mainObject, "" });
                            
                            if (new Func<AggregateCaseHeader, bool>(c => c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateAction)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.VetAggregateActionCreatedLocal, mainObject, "" });
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                            if (new Func<AggregateCaseHeader, bool>(c => c.idfsAggrCaseType == (long)AggregateCaseType.HumanAggregateCase && (c.Parent as HumanAggregateCase).HasChanges)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.HumanAggregateCaseChangedLocal, mainObject, "" });
                            
                            if (new Func<AggregateCaseHeader, bool>(c => c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateCase && (c.Parent as VetAggregateCase).HasChanges)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.VetAggregateCaseChangedLocal, mainObject, "" });
                            
                            if (new Func<AggregateCaseHeader, bool>(c => c.idfsAggrCaseType == (long)AggregateCaseType.VetAggregateAction && (c.Parent as VetAggregateAction).HasChanges)(bo))
                              
                                manager.SetEventParams(false, new object[] { EventType.VetAggregateActionChangedLocal, mainObject, "" });
                            
                        }

                        if (!manager.IsTransactionStarted)
                        {
                            
                            eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                            
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
                        bSuccess = _PostNonTransaction(manager, obj as AggregateCaseHeader, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AggregateCaseHeader obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.FFPresenterCase != null)
                    {
                        obj.FFPresenterCase.MarkToDelete();
                        if (!FFPresenterCaseAccessor.Post(manager, obj.FFPresenterCase, true))
                            return false;
                    }
                                    
                    if (obj.FFPresenterDiagnostic != null)
                    {
                        obj.FFPresenterDiagnostic.MarkToDelete();
                        if (!FFPresenterDiagnosticAccessor.Post(manager, obj.FFPresenterDiagnostic, true))
                            return false;
                    }
                                    
                    if (obj.FFPresenterProphylactic != null)
                    {
                        obj.FFPresenterProphylactic.MarkToDelete();
                        if (!FFPresenterProphylacticAccessor.Post(manager, obj.FFPresenterProphylactic, true))
                            return false;
                    }
                                    
                    if (obj.FFPresenterSanitary != null)
                    {
                        obj.FFPresenterSanitary.MarkToDelete();
                        if (!FFPresenterSanitaryAccessor.Post(manager, obj.FFPresenterSanitary, true))
                            return false;
                    }
                                    
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
                    
            
                    // posting extenters - begin
                obj.datModificationForArchiveDate = new Func<AggregateCaseHeader, DateTime?>(c => c.HasChanges ? DateTime.Now : c.datModificationForArchiveDate)(obj);
                obj.idfsAdministrativeUnit = new Func<AggregateCaseHeader, long>(c => c.idfsAdministrativeUnitCalc)(obj);
                obj.datStartDate = new Func<AggregateCaseHeader, DateTime?>(c => c.datStartDateCalc)(obj);
                obj.datFinishDate = new Func<AggregateCaseHeader, DateTime?>(c => c.datFinishDateCalc)(obj);
                obj.strCaseID = new Func<AggregateCaseHeader, DbManagerProxy, string>((c,m) => 
                    c.strCaseID != "(new)" 
                    ? c.strCaseID 
                    : m.SetSpCommand("dbo.spGetNextNumber", c.NumberingObject, DBNull.Value, DBNull.Value)
                    .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue"))(obj, manager);
                    // posting extenters - end
            
                    if (!obj.IsMarkedToDelete && bHasChanges)
                        _postPredicate(manager, obj);
                                    
                    if (obj.IsNew)
                    {
                        if (obj.FFPresenterCase != null) // forced load potential lazy subobject for new object
                            if (!FFPresenterCaseAccessor.Post(manager, obj.FFPresenterCase, true))
                                return false;
                    }
                    else
                    {
                        if (obj._FFPresenterCase != null) // do not load lazy subobject for existing object
                            if (!FFPresenterCaseAccessor.Post(manager, obj.FFPresenterCase, true))
                                return false;
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.FFPresenterDiagnostic != null) // forced load potential lazy subobject for new object
                            if (!FFPresenterDiagnosticAccessor.Post(manager, obj.FFPresenterDiagnostic, true))
                                return false;
                    }
                    else
                    {
                        if (obj._FFPresenterDiagnostic != null) // do not load lazy subobject for existing object
                            if (!FFPresenterDiagnosticAccessor.Post(manager, obj.FFPresenterDiagnostic, true))
                                return false;
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.FFPresenterProphylactic != null) // forced load potential lazy subobject for new object
                            if (!FFPresenterProphylacticAccessor.Post(manager, obj.FFPresenterProphylactic, true))
                                return false;
                    }
                    else
                    {
                        if (obj._FFPresenterProphylactic != null) // do not load lazy subobject for existing object
                            if (!FFPresenterProphylacticAccessor.Post(manager, obj.FFPresenterProphylactic, true))
                                return false;
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.FFPresenterSanitary != null) // forced load potential lazy subobject for new object
                            if (!FFPresenterSanitaryAccessor.Post(manager, obj.FFPresenterSanitary, true))
                                return false;
                    }
                    else
                    {
                        if (obj._FFPresenterSanitary != null) // do not load lazy subobject for existing object
                            if (!FFPresenterSanitaryAccessor.Post(manager, obj.FFPresenterSanitary, true))
                                return false;
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AggregateCaseHeader obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AggregateCaseHeader obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfAggrCase
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
        
      
            protected ValidationModelException ChainsValidate(AggregateCaseHeader obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<AggregateCaseHeader>(obj, "datSentByDate", c => true, 
      obj.datSentByDate,
      obj.GetType(),
      false, listdatSentByDate => {
    listdatSentByDate.Add(
    new ChainsValidatorDateTime<AggregateCaseHeader>(obj, "datReceivedByDate", c => true, 
      obj.datReceivedByDate,
      obj.GetType(),
      false, listdatReceivedByDate => {
    listdatReceivedByDate.Add(
    new ChainsValidatorDateTime<AggregateCaseHeader>(obj, "datEnteredByDate", c => true, 
      obj.datEnteredByDate,
      obj.GetType(),
      false, listdatEnteredByDate => {
    listdatEnteredByDate.Add(
    new ChainsValidatorDateTime<AggregateCaseHeader>(obj, "CurrentDate", c => true, 
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
            protected bool ChainsValidate(AggregateCaseHeader obj, bool bRethrowException)
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
                return Validate(manager, obj as AggregateCaseHeader, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AggregateCaseHeader obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfSentByOffice", "idfSentByOffice","idfCollectedByOffice",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfSentByOffice);
            
                (new RequiredValidator( "idfSentByPerson", "idfSentByPerson","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfSentByPerson);
            
                (new RequiredValidator( "strSentByOffice", "strSentByOffice","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.strSentByOffice);
            
                (new RequiredValidator( "strSentByPerson", "strSentByPerson","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.strSentByPerson);
            
                (new RequiredValidator( "datSentByDate", "datSentByDate","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.datSentByDate);
            
                (new RequiredValidator( "YearAggr", "YearAggr","YearForAggr",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.YearAggr);
            
                (new RequiredValidator( "QuarterAggr", "QuarterAggr","QuarterForAggr",
                ValidationEventType.Error
              )).Validate(c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter, obj, obj.QuarterAggr);
            
                (new RequiredValidator( "MonthAggr", "MonthAggr","MonthForAggr",
                ValidationEventType.Error
              )).Validate(c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month || c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Day, obj, obj.MonthAggr);
            
                (new RequiredValidator( "WeekAggr", "WeekAggr","WeekForAggr",
                ValidationEventType.Error
              )).Validate(c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week, obj, obj.WeekAggr);
            
                (new RequiredValidator( "DayForAggr", "DayForAggr","",
                ValidationEventType.Error
              )).Validate(c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Day, obj, obj.DayForAggr);
            
                (new RequiredValidator( "idfsCountry", "Country","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfsCountry);
            
                (new RequiredValidator( "idfsRegion", "Region","",
                ValidationEventType.Error
              )).Validate(c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Region || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement, obj, obj.idfsRegion);
            
                (new RequiredValidator( "idfsRayon", "Rayon","",
                ValidationEventType.Error
              )).Validate(c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement, obj, obj.idfsRayon);
            
                (new RequiredValidator( "idfsSettlement", "Settlement","Settlement",
                ValidationEventType.Error
              )).Validate(c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement, obj, obj.idfsSettlement);
            
            (new CustomMandatoryFieldValidator("idfReceivedByPerson", "idfReceivedByPerson", "",
            ValidationEventType.Error
            )).Validate(obj, obj.idfReceivedByPerson, CustomMandatoryField.HumanAggrCase_NotificationReceivedByOfficer,
            c => c.Parent is HumanAggregateCase);

          
            (new CustomMandatoryFieldValidator("strReceivedByPerson", "strReceivedByPerson", "",
            ValidationEventType.Error
            )).Validate(obj, obj.strReceivedByPerson, CustomMandatoryField.HumanAggrCase_NotificationReceivedByOfficer,
            c => c.Parent is HumanAggregateCase);

          
            (new CustomMandatoryFieldValidator("idfReceivedByOffice", "idfReceivedByOffice", "",
            ValidationEventType.Error
            )).Validate(obj, obj.idfReceivedByOffice, CustomMandatoryField.HumanAggrCase_NotificationReceivedByOffice,
            c => c.Parent is HumanAggregateCase);

          
            (new CustomMandatoryFieldValidator("strReceivedByOffice", "strReceivedByOffice", "",
            ValidationEventType.Error
            )).Validate(obj, obj.strReceivedByOffice, CustomMandatoryField.HumanAggrCase_NotificationReceivedByOffice,
            c => c.Parent is HumanAggregateCase);

          
            (new CustomMandatoryFieldValidator("datReceivedByDate", "datReceivedByDate", "",
            ValidationEventType.Error
            )).Validate(obj, obj.datReceivedByDate, CustomMandatoryField.HumanAggrCase_NotificationReceivedByDate,
            c => c.Parent is HumanAggregateCase);

          
            (new CustomMandatoryFieldValidator("idfReceivedByPerson", "idfReceivedByPerson", "",
            ValidationEventType.Error
            )).Validate(obj, obj.idfReceivedByPerson, CustomMandatoryField.VetAggrCase_NotificationReceivedByOfficer,
            c => c.Parent is VetAggregateCase);

          
            (new CustomMandatoryFieldValidator("strReceivedByPerson", "strReceivedByPerson", "",
            ValidationEventType.Error
            )).Validate(obj, obj.strReceivedByPerson, CustomMandatoryField.VetAggrCase_NotificationReceivedByOfficer,
            c => c.Parent is VetAggregateCase);

          
            (new CustomMandatoryFieldValidator("idfReceivedByOffice", "idfReceivedByOffice", "",
            ValidationEventType.Error
            )).Validate(obj, obj.idfReceivedByOffice, CustomMandatoryField.VetAggrCase_NotificationReceivedByOffice,
            c => c.Parent is VetAggregateCase);

          
            (new CustomMandatoryFieldValidator("strReceivedByOffice", "strReceivedByOffice", "",
            ValidationEventType.Error
            )).Validate(obj, obj.strReceivedByOffice, CustomMandatoryField.VetAggrCase_NotificationReceivedByOffice,
            c => c.Parent is VetAggregateCase);

          
            (new CustomMandatoryFieldValidator("datReceivedByDate", "datReceivedByDate", "",
            ValidationEventType.Error
            )).Validate(obj, obj.datReceivedByDate, CustomMandatoryField.VetAggrCase_NotificationReceivedByDate,
            c => c.Parent is VetAggregateCase);

          
            (new CustomMandatoryFieldValidator("idfReceivedByPerson", "idfReceivedByPerson", "",
            ValidationEventType.Error
            )).Validate(obj, obj.idfReceivedByPerson, CustomMandatoryField.VetAggrAction_NotificationReceivedByOfficer,
            c => c.Parent is VetAggregateAction);

          
            (new CustomMandatoryFieldValidator("strReceivedByPerson", "strReceivedByPerson", "",
            ValidationEventType.Error
            )).Validate(obj, obj.strReceivedByPerson, CustomMandatoryField.VetAggrAction_NotificationReceivedByOfficer,
            c => c.Parent is VetAggregateAction);

          
            (new CustomMandatoryFieldValidator("idfReceivedByOffice", "idfReceivedByOffice", "",
            ValidationEventType.Error
            )).Validate(obj, obj.idfReceivedByOffice, CustomMandatoryField.VetAggrAction_NotificationReceivedByOffice,
            c => c.Parent is VetAggregateAction);

          
            (new CustomMandatoryFieldValidator("strReceivedByOffice", "strReceivedByOffice", "",
            ValidationEventType.Error
            )).Validate(obj, obj.strReceivedByOffice, CustomMandatoryField.VetAggrAction_NotificationReceivedByOffice,
            c => c.Parent is VetAggregateAction);

          
            (new CustomMandatoryFieldValidator("datReceivedByDate", "datReceivedByDate", "",
            ValidationEventType.Error
            )).Validate(obj, obj.datReceivedByDate, CustomMandatoryField.VetAggrAction_NotificationReceivedByDate,
            c => c.Parent is VetAggregateAction);

          
                CheckDuplicates(manager, obj);
            
                CustomValidations(obj);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.FFPresenterCase != null)
                            FFPresenterCaseAccessor.Validate(manager, obj.FFPresenterCase, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FFPresenterDiagnostic != null)
                            FFPresenterDiagnosticAccessor.Validate(manager, obj.FFPresenterDiagnostic, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FFPresenterProphylactic != null)
                            FFPresenterProphylacticAccessor.Validate(manager, obj.FFPresenterProphylactic, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.FFPresenterSanitary != null)
                            FFPresenterSanitaryAccessor.Validate(manager, obj.FFPresenterSanitary, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            private void _SetupRequired(AggregateCaseHeader obj)
            {
            
                obj
                    .AddRequired("idfSentByOffice", c => true);
                    
                  obj
                    .AddRequired("SentByOffice", c => true);
                
                obj
                    .AddRequired("idfSentByPerson", c => true);
                    
                  obj
                    .AddRequired("SentByPerson", c => true);
                
                obj
                    .AddRequired("strSentByOffice", c => true);
                    
                obj
                    .AddRequired("strSentByPerson", c => true);
                    
                obj
                    .AddRequired("datSentByDate", c => true);
                    
                obj
                    .AddRequired("YearAggr", c => true);
                    
                obj
                    .AddRequired("QuarterAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter);
                    
                obj
                    .AddRequired("MonthAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month || c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Day);
                    
                obj
                    .AddRequired("WeekAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week);
                    
                obj
                    .AddRequired("DayForAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Day);
                    
                obj
                    .AddRequired("Country", c => true);
                    
                  obj
                    .AddRequired("Country", c => true);
                
                obj
                    .AddRequired("Region", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Region || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                    
                  obj
                    .AddRequired("Region", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Region || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                
                obj
                    .AddRequired("Rayon", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                    
                  obj
                    .AddRequired("Rayon", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                
                obj
                    .AddRequired("Settlement", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                    
                  obj
                    .AddRequired("Settlement", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanAggrCase_NotificationReceivedByOfficer)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is HumanAggregateCase)(obj))
              {
                obj
                  .AddRequired("idfReceivedByPerson", c => c.Parent is HumanAggregateCase);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanAggrCase_NotificationReceivedByOfficer)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is HumanAggregateCase)(obj))
              {
                obj
                  .AddRequired("strReceivedByPerson", c => c.Parent is HumanAggregateCase);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanAggrCase_NotificationReceivedByOffice)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is HumanAggregateCase)(obj))
              {
                obj
                  .AddRequired("idfReceivedByOffice", c => c.Parent is HumanAggregateCase);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanAggrCase_NotificationReceivedByOffice)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is HumanAggregateCase)(obj))
              {
                obj
                  .AddRequired("strReceivedByOffice", c => c.Parent is HumanAggregateCase);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.HumanAggrCase_NotificationReceivedByDate)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is HumanAggregateCase)(obj))
              {
                obj
                  .AddRequired("datReceivedByDate", c => c.Parent is HumanAggregateCase);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetAggrCase_NotificationReceivedByOfficer)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is VetAggregateCase)(obj))
              {
                obj
                  .AddRequired("idfReceivedByPerson", c => c.Parent is VetAggregateCase);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetAggrCase_NotificationReceivedByOfficer)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is VetAggregateCase)(obj))
              {
                obj
                  .AddRequired("strReceivedByPerson", c => c.Parent is VetAggregateCase);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetAggrCase_NotificationReceivedByOffice)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is VetAggregateCase)(obj))
              {
                obj
                  .AddRequired("idfReceivedByOffice", c => c.Parent is VetAggregateCase);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetAggrCase_NotificationReceivedByOffice)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is VetAggregateCase)(obj))
              {
                obj
                  .AddRequired("strReceivedByOffice", c => c.Parent is VetAggregateCase);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetAggrCase_NotificationReceivedByDate)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is VetAggregateCase)(obj))
              {
                obj
                  .AddRequired("datReceivedByDate", c => c.Parent is VetAggregateCase);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetAggrAction_NotificationReceivedByOfficer)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is VetAggregateAction)(obj))
              {
                obj
                  .AddRequired("idfReceivedByPerson", c => c.Parent is VetAggregateAction);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetAggrAction_NotificationReceivedByOfficer)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is VetAggregateAction)(obj))
              {
                obj
                  .AddRequired("strReceivedByPerson", c => c.Parent is VetAggregateAction);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetAggrAction_NotificationReceivedByOffice)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is VetAggregateAction)(obj))
              {
                obj
                  .AddRequired("idfReceivedByOffice", c => c.Parent is VetAggregateAction);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetAggrAction_NotificationReceivedByOffice)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is VetAggregateAction)(obj))
              {
                obj
                  .AddRequired("strReceivedByOffice", c => c.Parent is VetAggregateAction);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.VetAggrAction_NotificationReceivedByDate)  && new Func<AggregateCaseHeader, bool>(c => c.Parent is VetAggregateAction)(obj))
              {
                obj
                  .AddRequired("datReceivedByDate", c => c.Parent is VetAggregateAction);
                
                }
            
            }
    
    private void _SetupPersonalDataRestrictions(AggregateCaseHeader obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AggregateCaseHeader) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AggregateCaseHeader) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AggregateCaseHeaderDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spAggregateCaseHeader_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spAggregateCaseHeader_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spAggregateCase_Delete";
            public static string spCanDelete = "spAggregateCase_CanDelete";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AggregateCaseHeader, bool>> RequiredByField = new Dictionary<string, Func<AggregateCaseHeader, bool>>();
            public static Dictionary<string, Func<AggregateCaseHeader, bool>> RequiredByProperty = new Dictionary<string, Func<AggregateCaseHeader, bool>>();
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
                
                Sizes.Add(_str_strReceivedByOffice, 2000);
                Sizes.Add(_str_strReceivedByPerson, 602);
                Sizes.Add(_str_strSentByOffice, 2000);
                Sizes.Add(_str_strSentByPerson, 602);
                Sizes.Add(_str_strEnteredByOffice, 2000);
                Sizes.Add(_str_strEnteredByPerson, 602);
                Sizes.Add(_str_strCaseID, 200);
                if (!RequiredByField.ContainsKey("idfSentByOffice")) RequiredByField.Add("idfSentByOffice", c => true);
                if (!RequiredByProperty.ContainsKey("idfSentByOffice")) RequiredByProperty.Add("idfSentByOffice", c => true);
                
                if (!RequiredByField.ContainsKey("idfSentByPerson")) RequiredByField.Add("idfSentByPerson", c => true);
                if (!RequiredByProperty.ContainsKey("idfSentByPerson")) RequiredByProperty.Add("idfSentByPerson", c => true);
                
                if (!RequiredByField.ContainsKey("strSentByOffice")) RequiredByField.Add("strSentByOffice", c => true);
                if (!RequiredByProperty.ContainsKey("strSentByOffice")) RequiredByProperty.Add("strSentByOffice", c => true);
                
                if (!RequiredByField.ContainsKey("strSentByPerson")) RequiredByField.Add("strSentByPerson", c => true);
                if (!RequiredByProperty.ContainsKey("strSentByPerson")) RequiredByProperty.Add("strSentByPerson", c => true);
                
                if (!RequiredByField.ContainsKey("datSentByDate")) RequiredByField.Add("datSentByDate", c => true);
                if (!RequiredByProperty.ContainsKey("datSentByDate")) RequiredByProperty.Add("datSentByDate", c => true);
                
                if (!RequiredByField.ContainsKey("YearAggr")) RequiredByField.Add("YearAggr", c => true);
                if (!RequiredByProperty.ContainsKey("YearAggr")) RequiredByProperty.Add("YearAggr", c => true);
                
                if (!RequiredByField.ContainsKey("QuarterAggr")) RequiredByField.Add("QuarterAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter);
                if (!RequiredByProperty.ContainsKey("QuarterAggr")) RequiredByProperty.Add("QuarterAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter);
                
                if (!RequiredByField.ContainsKey("MonthAggr")) RequiredByField.Add("MonthAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month || c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Day);
                if (!RequiredByProperty.ContainsKey("MonthAggr")) RequiredByProperty.Add("MonthAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month || c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Day);
                
                if (!RequiredByField.ContainsKey("WeekAggr")) RequiredByField.Add("WeekAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week);
                if (!RequiredByProperty.ContainsKey("WeekAggr")) RequiredByProperty.Add("WeekAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week);
                
                if (!RequiredByField.ContainsKey("DayForAggr")) RequiredByField.Add("DayForAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Day);
                if (!RequiredByProperty.ContainsKey("DayForAggr")) RequiredByProperty.Add("DayForAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Day);
                
                if (!RequiredByField.ContainsKey("idfsCountry")) RequiredByField.Add("idfsCountry", c => true);
                if (!RequiredByProperty.ContainsKey("Country")) RequiredByProperty.Add("Country", c => true);
                
                if (!RequiredByField.ContainsKey("idfsRegion")) RequiredByField.Add("idfsRegion", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Region || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                if (!RequiredByProperty.ContainsKey("Region")) RequiredByProperty.Add("Region", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Region || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                
                if (!RequiredByField.ContainsKey("idfsRayon")) RequiredByField.Add("idfsRayon", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                if (!RequiredByProperty.ContainsKey("Rayon")) RequiredByProperty.Add("Rayon", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                
                if (!RequiredByField.ContainsKey("idfsSettlement")) RequiredByField.Add("idfsSettlement", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                if (!RequiredByProperty.ContainsKey("Settlement")) RequiredByProperty.Add("Settlement", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                
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
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "CreateWithParamsManyVersions",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParamsManyVersions(manager, c, pars)),
                        
                    null,
                    
                    null,
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
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AggregateCaseHeader>().Post(manager, (AggregateCaseHeader)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
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
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AggregateCaseHeader>().Post(manager, (AggregateCaseHeader)c), c),
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
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((AggregateCaseHeader)c).MarkToDelete() && ObjectAccessor.PostInterface<AggregateCaseHeader>().Post(manager, (AggregateCaseHeader)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
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
	