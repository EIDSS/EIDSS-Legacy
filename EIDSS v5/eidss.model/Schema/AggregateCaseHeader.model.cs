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
                
        [LocalizedDisplayName(_str_strReceivedByOffice)]
        [MapField(_str_strReceivedByOffice)]
        public abstract String strReceivedByOffice { get; set; }
        #if MONO
        protected String strReceivedByOffice_Original { get { return strReceivedByOffice; } }
        protected String strReceivedByOffice_Previous { get { return strReceivedByOffice; } }
        #else
        protected String strReceivedByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByOffice).OriginalValue; } }
        protected String strReceivedByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strReceivedByPerson)]
        [MapField(_str_strReceivedByPerson)]
        public abstract String strReceivedByPerson { get; set; }
        #if MONO
        protected String strReceivedByPerson_Original { get { return strReceivedByPerson; } }
        protected String strReceivedByPerson_Previous { get { return strReceivedByPerson; } }
        #else
        protected String strReceivedByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByPerson).OriginalValue; } }
        protected String strReceivedByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReceivedByPerson).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strSentByOffice)]
        [MapField(_str_strSentByOffice)]
        public abstract String strSentByOffice { get; set; }
        #if MONO
        protected String strSentByOffice_Original { get { return strSentByOffice; } }
        protected String strSentByOffice_Previous { get { return strSentByOffice; } }
        #else
        protected String strSentByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strSentByOffice).OriginalValue; } }
        protected String strSentByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSentByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSentByPerson)]
        [MapField(_str_strSentByPerson)]
        public abstract String strSentByPerson { get; set; }
        #if MONO
        protected String strSentByPerson_Original { get { return strSentByPerson; } }
        protected String strSentByPerson_Previous { get { return strSentByPerson; } }
        #else
        protected String strSentByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strSentByPerson).OriginalValue; } }
        protected String strSentByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSentByPerson).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strEnteredByOffice)]
        [MapField(_str_strEnteredByOffice)]
        public abstract String strEnteredByOffice { get; set; }
        #if MONO
        protected String strEnteredByOffice_Original { get { return strEnteredByOffice; } }
        protected String strEnteredByOffice_Previous { get { return strEnteredByOffice; } }
        #else
        protected String strEnteredByOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strEnteredByOffice).OriginalValue; } }
        protected String strEnteredByOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEnteredByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strEnteredByPerson)]
        [MapField(_str_strEnteredByPerson)]
        public abstract String strEnteredByPerson { get; set; }
        #if MONO
        protected String strEnteredByPerson_Original { get { return strEnteredByPerson; } }
        protected String strEnteredByPerson_Previous { get { return strEnteredByPerson; } }
        #else
        protected String strEnteredByPerson_Original { get { return ((EditableValue<String>)((dynamic)this)._strEnteredByPerson).OriginalValue; } }
        protected String strEnteredByPerson_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEnteredByPerson).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsCaseObservationFormTemplate)]
        [MapField(_str_idfsCaseObservationFormTemplate)]
        public abstract Int64? idfsCaseObservationFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsCaseObservationFormTemplate_Original { get { return idfsCaseObservationFormTemplate; } }
        protected Int64? idfsCaseObservationFormTemplate_Previous { get { return idfsCaseObservationFormTemplate; } }
        #else
        protected Int64? idfsCaseObservationFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseObservationFormTemplate).OriginalValue; } }
        protected Int64? idfsCaseObservationFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseObservationFormTemplate).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsDiagnosticObservationFormTemplate)]
        [MapField(_str_idfsDiagnosticObservationFormTemplate)]
        public abstract Int64? idfsDiagnosticObservationFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsDiagnosticObservationFormTemplate_Original { get { return idfsDiagnosticObservationFormTemplate; } }
        protected Int64? idfsDiagnosticObservationFormTemplate_Previous { get { return idfsDiagnosticObservationFormTemplate; } }
        #else
        protected Int64? idfsDiagnosticObservationFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosticObservationFormTemplate).OriginalValue; } }
        protected Int64? idfsDiagnosticObservationFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosticObservationFormTemplate).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsProphylacticObservationFormTemplate)]
        [MapField(_str_idfsProphylacticObservationFormTemplate)]
        public abstract Int64? idfsProphylacticObservationFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsProphylacticObservationFormTemplate_Original { get { return idfsProphylacticObservationFormTemplate; } }
        protected Int64? idfsProphylacticObservationFormTemplate_Previous { get { return idfsProphylacticObservationFormTemplate; } }
        #else
        protected Int64? idfsProphylacticObservationFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsProphylacticObservationFormTemplate).OriginalValue; } }
        protected Int64? idfsProphylacticObservationFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsProphylacticObservationFormTemplate).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_idfsSanitaryObservationFormTemplate)]
        [MapField(_str_idfsSanitaryObservationFormTemplate)]
        public abstract Int64? idfsSanitaryObservationFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsSanitaryObservationFormTemplate_Original { get { return idfsSanitaryObservationFormTemplate; } }
        protected Int64? idfsSanitaryObservationFormTemplate_Previous { get { return idfsSanitaryObservationFormTemplate; } }
        #else
        protected Int64? idfsSanitaryObservationFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSanitaryObservationFormTemplate).OriginalValue; } }
        protected Int64? idfsSanitaryObservationFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSanitaryObservationFormTemplate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfVersion)]
        [MapField(_str_idfVersion)]
        public abstract Int64? idfVersion { get; set; }
        #if MONO
        protected Int64? idfVersion_Original { get { return idfVersion; } }
        protected Int64? idfVersion_Previous { get { return idfVersion; } }
        #else
        protected Int64? idfVersion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVersion).OriginalValue; } }
        protected Int64? idfVersion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVersion).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfDiagnosticVersion)]
        [MapField(_str_idfDiagnosticVersion)]
        public abstract Int64? idfDiagnosticVersion { get; set; }
        #if MONO
        protected Int64? idfDiagnosticVersion_Original { get { return idfDiagnosticVersion; } }
        protected Int64? idfDiagnosticVersion_Previous { get { return idfDiagnosticVersion; } }
        #else
        protected Int64? idfDiagnosticVersion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDiagnosticVersion).OriginalValue; } }
        protected Int64? idfDiagnosticVersion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDiagnosticVersion).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfProphylacticVersion)]
        [MapField(_str_idfProphylacticVersion)]
        public abstract Int64? idfProphylacticVersion { get; set; }
        #if MONO
        protected Int64? idfProphylacticVersion_Original { get { return idfProphylacticVersion; } }
        protected Int64? idfProphylacticVersion_Previous { get { return idfProphylacticVersion; } }
        #else
        protected Int64? idfProphylacticVersion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfProphylacticVersion).OriginalValue; } }
        protected Int64? idfProphylacticVersion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfProphylacticVersion).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfSanitaryVersion)]
        [MapField(_str_idfSanitaryVersion)]
        public abstract Int64? idfSanitaryVersion { get; set; }
        #if MONO
        protected Int64? idfSanitaryVersion_Original { get { return idfSanitaryVersion; } }
        protected Int64? idfSanitaryVersion_Previous { get { return idfSanitaryVersion; } }
        #else
        protected Int64? idfSanitaryVersion_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSanitaryVersion).OriginalValue; } }
        protected Int64? idfSanitaryVersion_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSanitaryVersion).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_strCaseID)]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        #if MONO
        protected String strCaseID_Original { get { return strCaseID; } }
        protected String strCaseID_Previous { get { return strCaseID; } }
        #else
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_YearForAggr)]
        [MapField(_str_YearForAggr)]
        public abstract Int32? YearForAggr { get; set; }
        #if MONO
        protected Int32? YearForAggr_Original { get { return YearForAggr; } }
        protected Int32? YearForAggr_Previous { get { return YearForAggr; } }
        #else
        protected Int32? YearForAggr_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._yearForAggr).OriginalValue; } }
        protected Int32? YearForAggr_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._yearForAggr).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_QuarterForAggr)]
        [MapField(_str_QuarterForAggr)]
        public abstract Int32? QuarterForAggr { get; set; }
        #if MONO
        protected Int32? QuarterForAggr_Original { get { return QuarterForAggr; } }
        protected Int32? QuarterForAggr_Previous { get { return QuarterForAggr; } }
        #else
        protected Int32? QuarterForAggr_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._quarterForAggr).OriginalValue; } }
        protected Int32? QuarterForAggr_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._quarterForAggr).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_MonthForAggr)]
        [MapField(_str_MonthForAggr)]
        public abstract Int32? MonthForAggr { get; set; }
        #if MONO
        protected Int32? MonthForAggr_Original { get { return MonthForAggr; } }
        protected Int32? MonthForAggr_Previous { get { return MonthForAggr; } }
        #else
        protected Int32? MonthForAggr_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._monthForAggr).OriginalValue; } }
        protected Int32? MonthForAggr_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._monthForAggr).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_WeekForAggr)]
        [MapField(_str_WeekForAggr)]
        public abstract Int32? WeekForAggr { get; set; }
        #if MONO
        protected Int32? WeekForAggr_Original { get { return WeekForAggr; } }
        protected Int32? WeekForAggr_Previous { get { return WeekForAggr; } }
        #else
        protected Int32? WeekForAggr_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._weekForAggr).OriginalValue; } }
        protected Int32? WeekForAggr_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._weekForAggr).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_DayForAggr)]
        [MapField(_str_DayForAggr)]
        public abstract DateTime? DayForAggr { get; set; }
        #if MONO
        protected DateTime? DayForAggr_Original { get { return DayForAggr; } }
        protected DateTime? DayForAggr_Previous { get { return DayForAggr; } }
        #else
        protected DateTime? DayForAggr_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._dayForAggr).OriginalValue; } }
        protected DateTime? DayForAggr_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._dayForAggr).PreviousValue; } }
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
                
        [LocalizedDisplayName(_str_CurPeriodType)]
        [MapField(_str_CurPeriodType)]
        public abstract Int64? CurPeriodType { get; set; }
        #if MONO
        protected Int64? CurPeriodType_Original { get { return CurPeriodType; } }
        protected Int64? CurPeriodType_Previous { get { return CurPeriodType; } }
        #else
        protected Int64? CurPeriodType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._curPeriodType).OriginalValue; } }
        protected Int64? CurPeriodType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._curPeriodType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_CurAreaType)]
        [MapField(_str_CurAreaType)]
        public abstract Int64? CurAreaType { get; set; }
        #if MONO
        protected Int64? CurAreaType_Original { get { return CurAreaType; } }
        protected Int64? CurAreaType_Previous { get { return CurAreaType; } }
        #else
        protected Int64? CurAreaType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._curAreaType).OriginalValue; } }
        protected Int64? CurAreaType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._curAreaType).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<AggregateCaseHeader, object> _get_func;
            internal Action<AggregateCaseHeader, string> _set_func;
            internal Action<AggregateCaseHeader, AggregateCaseHeader, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAggrCase = "idfAggrCase";
        internal const string _str_idfsAggrCaseType = "idfsAggrCaseType";
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
        internal const string _str_NumberingObject = "NumberingObject";
        internal const string _str_idfsAdministrativeUnitCalc = "idfsAdministrativeUnitCalc";
        internal const string _str_datStartDateCalc = "datStartDateCalc";
        internal const string _str_datFinishDateCalc = "datFinishDateCalc";
        internal const string _str_strReadOnlyEnteredByDate = "strReadOnlyEnteredByDate";
        internal const string _str_Country = "Country";
        internal const string _str_Region = "Region";
        internal const string _str_Rayon = "Rayon";
        internal const string _str_Settlement = "Settlement";
        internal const string _str_Settings = "Settings";
        internal const string _str_FFPresenterCase = "FFPresenterCase";
        internal const string _str_FFPresenterDiagnostic = "FFPresenterDiagnostic";
        internal const string _str_FFPresenterProphylactic = "FFPresenterProphylactic";
        internal const string _str_FFPresenterSanitary = "FFPresenterSanitary";
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
              _name = _str_strReceivedByOffice, _type = "String",
              _get_func = o => o.strReceivedByOffice,
              _set_func = (o, val) => { o.strReceivedByOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strReceivedByOffice != c.strReceivedByOffice || o.IsRIRPropChanged(_str_strReceivedByOffice, c)) 
                  m.Add(_str_strReceivedByOffice, o.ObjectIdent + _str_strReceivedByOffice, "String", o.strReceivedByOffice == null ? "" : o.strReceivedByOffice.ToString(), o.IsReadOnly(_str_strReceivedByOffice), o.IsInvisible(_str_strReceivedByOffice), o.IsRequired(_str_strReceivedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_strReceivedByPerson, _type = "String",
              _get_func = o => o.strReceivedByPerson,
              _set_func = (o, val) => { o.strReceivedByPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strReceivedByPerson != c.strReceivedByPerson || o.IsRIRPropChanged(_str_strReceivedByPerson, c)) 
                  m.Add(_str_strReceivedByPerson, o.ObjectIdent + _str_strReceivedByPerson, "String", o.strReceivedByPerson == null ? "" : o.strReceivedByPerson.ToString(), o.IsReadOnly(_str_strReceivedByPerson), o.IsInvisible(_str_strReceivedByPerson), o.IsRequired(_str_strReceivedByPerson)); }
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
              _name = _str_strSentByOffice, _type = "String",
              _get_func = o => o.strSentByOffice,
              _set_func = (o, val) => { o.strSentByOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSentByOffice != c.strSentByOffice || o.IsRIRPropChanged(_str_strSentByOffice, c)) 
                  m.Add(_str_strSentByOffice, o.ObjectIdent + _str_strSentByOffice, "String", o.strSentByOffice == null ? "" : o.strSentByOffice.ToString(), o.IsReadOnly(_str_strSentByOffice), o.IsInvisible(_str_strSentByOffice), o.IsRequired(_str_strSentByOffice)); }
              }, 
        
            new field_info {
              _name = _str_strSentByPerson, _type = "String",
              _get_func = o => o.strSentByPerson,
              _set_func = (o, val) => { o.strSentByPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSentByPerson != c.strSentByPerson || o.IsRIRPropChanged(_str_strSentByPerson, c)) 
                  m.Add(_str_strSentByPerson, o.ObjectIdent + _str_strSentByPerson, "String", o.strSentByPerson == null ? "" : o.strSentByPerson.ToString(), o.IsReadOnly(_str_strSentByPerson), o.IsInvisible(_str_strSentByPerson), o.IsRequired(_str_strSentByPerson)); }
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
              _name = _str_strEnteredByOffice, _type = "String",
              _get_func = o => o.strEnteredByOffice,
              _set_func = (o, val) => { o.strEnteredByOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strEnteredByOffice != c.strEnteredByOffice || o.IsRIRPropChanged(_str_strEnteredByOffice, c)) 
                  m.Add(_str_strEnteredByOffice, o.ObjectIdent + _str_strEnteredByOffice, "String", o.strEnteredByOffice == null ? "" : o.strEnteredByOffice.ToString(), o.IsReadOnly(_str_strEnteredByOffice), o.IsInvisible(_str_strEnteredByOffice), o.IsRequired(_str_strEnteredByOffice)); }
              }, 
        
            new field_info {
              _name = _str_strEnteredByPerson, _type = "String",
              _get_func = o => o.strEnteredByPerson,
              _set_func = (o, val) => { o.strEnteredByPerson = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strEnteredByPerson != c.strEnteredByPerson || o.IsRIRPropChanged(_str_strEnteredByPerson, c)) 
                  m.Add(_str_strEnteredByPerson, o.ObjectIdent + _str_strEnteredByPerson, "String", o.strEnteredByPerson == null ? "" : o.strEnteredByPerson.ToString(), o.IsReadOnly(_str_strEnteredByPerson), o.IsInvisible(_str_strEnteredByPerson), o.IsRequired(_str_strEnteredByPerson)); }
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
              _name = _str_idfsCaseObservationFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsCaseObservationFormTemplate,
              _set_func = (o, val) => { o.idfsCaseObservationFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCaseObservationFormTemplate != c.idfsCaseObservationFormTemplate || o.IsRIRPropChanged(_str_idfsCaseObservationFormTemplate, c)) 
                  m.Add(_str_idfsCaseObservationFormTemplate, o.ObjectIdent + _str_idfsCaseObservationFormTemplate, "Int64?", o.idfsCaseObservationFormTemplate == null ? "" : o.idfsCaseObservationFormTemplate.ToString(), o.IsReadOnly(_str_idfsCaseObservationFormTemplate), o.IsInvisible(_str_idfsCaseObservationFormTemplate), o.IsRequired(_str_idfsCaseObservationFormTemplate)); }
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
              _name = _str_idfsDiagnosticObservationFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsDiagnosticObservationFormTemplate,
              _set_func = (o, val) => { o.idfsDiagnosticObservationFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosticObservationFormTemplate != c.idfsDiagnosticObservationFormTemplate || o.IsRIRPropChanged(_str_idfsDiagnosticObservationFormTemplate, c)) 
                  m.Add(_str_idfsDiagnosticObservationFormTemplate, o.ObjectIdent + _str_idfsDiagnosticObservationFormTemplate, "Int64?", o.idfsDiagnosticObservationFormTemplate == null ? "" : o.idfsDiagnosticObservationFormTemplate.ToString(), o.IsReadOnly(_str_idfsDiagnosticObservationFormTemplate), o.IsInvisible(_str_idfsDiagnosticObservationFormTemplate), o.IsRequired(_str_idfsDiagnosticObservationFormTemplate)); }
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
              _name = _str_idfsProphylacticObservationFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsProphylacticObservationFormTemplate,
              _set_func = (o, val) => { o.idfsProphylacticObservationFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsProphylacticObservationFormTemplate != c.idfsProphylacticObservationFormTemplate || o.IsRIRPropChanged(_str_idfsProphylacticObservationFormTemplate, c)) 
                  m.Add(_str_idfsProphylacticObservationFormTemplate, o.ObjectIdent + _str_idfsProphylacticObservationFormTemplate, "Int64?", o.idfsProphylacticObservationFormTemplate == null ? "" : o.idfsProphylacticObservationFormTemplate.ToString(), o.IsReadOnly(_str_idfsProphylacticObservationFormTemplate), o.IsInvisible(_str_idfsProphylacticObservationFormTemplate), o.IsRequired(_str_idfsProphylacticObservationFormTemplate)); }
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
              _name = _str_idfsSanitaryObservationFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsSanitaryObservationFormTemplate,
              _set_func = (o, val) => { o.idfsSanitaryObservationFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSanitaryObservationFormTemplate != c.idfsSanitaryObservationFormTemplate || o.IsRIRPropChanged(_str_idfsSanitaryObservationFormTemplate, c)) 
                  m.Add(_str_idfsSanitaryObservationFormTemplate, o.ObjectIdent + _str_idfsSanitaryObservationFormTemplate, "Int64?", o.idfsSanitaryObservationFormTemplate == null ? "" : o.idfsSanitaryObservationFormTemplate.ToString(), o.IsReadOnly(_str_idfsSanitaryObservationFormTemplate), o.IsInvisible(_str_idfsSanitaryObservationFormTemplate), o.IsRequired(_str_idfsSanitaryObservationFormTemplate)); }
              }, 
        
            new field_info {
              _name = _str_idfVersion, _type = "Int64?",
              _get_func = o => o.idfVersion,
              _set_func = (o, val) => { o.idfVersion = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfVersion != c.idfVersion || o.IsRIRPropChanged(_str_idfVersion, c)) 
                  m.Add(_str_idfVersion, o.ObjectIdent + _str_idfVersion, "Int64?", o.idfVersion == null ? "" : o.idfVersion.ToString(), o.IsReadOnly(_str_idfVersion), o.IsInvisible(_str_idfVersion), o.IsRequired(_str_idfVersion)); }
              }, 
        
            new field_info {
              _name = _str_idfDiagnosticVersion, _type = "Int64?",
              _get_func = o => o.idfDiagnosticVersion,
              _set_func = (o, val) => { o.idfDiagnosticVersion = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfDiagnosticVersion != c.idfDiagnosticVersion || o.IsRIRPropChanged(_str_idfDiagnosticVersion, c)) 
                  m.Add(_str_idfDiagnosticVersion, o.ObjectIdent + _str_idfDiagnosticVersion, "Int64?", o.idfDiagnosticVersion == null ? "" : o.idfDiagnosticVersion.ToString(), o.IsReadOnly(_str_idfDiagnosticVersion), o.IsInvisible(_str_idfDiagnosticVersion), o.IsRequired(_str_idfDiagnosticVersion)); }
              }, 
        
            new field_info {
              _name = _str_idfProphylacticVersion, _type = "Int64?",
              _get_func = o => o.idfProphylacticVersion,
              _set_func = (o, val) => { o.idfProphylacticVersion = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfProphylacticVersion != c.idfProphylacticVersion || o.IsRIRPropChanged(_str_idfProphylacticVersion, c)) 
                  m.Add(_str_idfProphylacticVersion, o.ObjectIdent + _str_idfProphylacticVersion, "Int64?", o.idfProphylacticVersion == null ? "" : o.idfProphylacticVersion.ToString(), o.IsReadOnly(_str_idfProphylacticVersion), o.IsInvisible(_str_idfProphylacticVersion), o.IsRequired(_str_idfProphylacticVersion)); }
              }, 
        
            new field_info {
              _name = _str_idfSanitaryVersion, _type = "Int64?",
              _get_func = o => o.idfSanitaryVersion,
              _set_func = (o, val) => { o.idfSanitaryVersion = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSanitaryVersion != c.idfSanitaryVersion || o.IsRIRPropChanged(_str_idfSanitaryVersion, c)) 
                  m.Add(_str_idfSanitaryVersion, o.ObjectIdent + _str_idfSanitaryVersion, "Int64?", o.idfSanitaryVersion == null ? "" : o.idfSanitaryVersion.ToString(), o.IsReadOnly(_str_idfSanitaryVersion), o.IsInvisible(_str_idfSanitaryVersion), o.IsRequired(_str_idfSanitaryVersion)); }
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
              _name = _str_YearForAggr, _type = "Int32?",
              _get_func = o => o.YearForAggr,
              _set_func = (o, val) => { o.YearForAggr = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.YearForAggr != c.YearForAggr || o.IsRIRPropChanged(_str_YearForAggr, c)) 
                  m.Add(_str_YearForAggr, o.ObjectIdent + _str_YearForAggr, "Int32?", o.YearForAggr == null ? "" : o.YearForAggr.ToString(), o.IsReadOnly(_str_YearForAggr), o.IsInvisible(_str_YearForAggr), o.IsRequired(_str_YearForAggr)); }
              }, 
        
            new field_info {
              _name = _str_QuarterForAggr, _type = "Int32?",
              _get_func = o => o.QuarterForAggr,
              _set_func = (o, val) => { o.QuarterForAggr = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.QuarterForAggr != c.QuarterForAggr || o.IsRIRPropChanged(_str_QuarterForAggr, c)) 
                  m.Add(_str_QuarterForAggr, o.ObjectIdent + _str_QuarterForAggr, "Int32?", o.QuarterForAggr == null ? "" : o.QuarterForAggr.ToString(), o.IsReadOnly(_str_QuarterForAggr), o.IsInvisible(_str_QuarterForAggr), o.IsRequired(_str_QuarterForAggr)); }
              }, 
        
            new field_info {
              _name = _str_MonthForAggr, _type = "Int32?",
              _get_func = o => o.MonthForAggr,
              _set_func = (o, val) => { o.MonthForAggr = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.MonthForAggr != c.MonthForAggr || o.IsRIRPropChanged(_str_MonthForAggr, c)) 
                  m.Add(_str_MonthForAggr, o.ObjectIdent + _str_MonthForAggr, "Int32?", o.MonthForAggr == null ? "" : o.MonthForAggr.ToString(), o.IsReadOnly(_str_MonthForAggr), o.IsInvisible(_str_MonthForAggr), o.IsRequired(_str_MonthForAggr)); }
              }, 
        
            new field_info {
              _name = _str_WeekForAggr, _type = "Int32?",
              _get_func = o => o.WeekForAggr,
              _set_func = (o, val) => { o.WeekForAggr = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.WeekForAggr != c.WeekForAggr || o.IsRIRPropChanged(_str_WeekForAggr, c)) 
                  m.Add(_str_WeekForAggr, o.ObjectIdent + _str_WeekForAggr, "Int32?", o.WeekForAggr == null ? "" : o.WeekForAggr.ToString(), o.IsReadOnly(_str_WeekForAggr), o.IsInvisible(_str_WeekForAggr), o.IsRequired(_str_WeekForAggr)); }
              }, 
        
            new field_info {
              _name = _str_DayForAggr, _type = "DateTime?",
              _get_func = o => o.DayForAggr,
              _set_func = (o, val) => { o.DayForAggr = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.DayForAggr != c.DayForAggr || o.IsRIRPropChanged(_str_DayForAggr, c)) 
                  m.Add(_str_DayForAggr, o.ObjectIdent + _str_DayForAggr, "DateTime?", o.DayForAggr == null ? "" : o.DayForAggr.ToString(), o.IsReadOnly(_str_DayForAggr), o.IsInvisible(_str_DayForAggr), o.IsRequired(_str_DayForAggr)); }
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
              _name = _str_idfsRegion, _type = "Int64?",
              _get_func = o => o.idfsRegion,
              _set_func = (o, val) => { o.idfsRegion = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsRegion != c.idfsRegion || o.IsRIRPropChanged(_str_idfsRegion, c)) 
                  m.Add(_str_idfsRegion, o.ObjectIdent + _str_idfsRegion, "Int64?", o.idfsRegion == null ? "" : o.idfsRegion.ToString(), o.IsReadOnly(_str_idfsRegion), o.IsInvisible(_str_idfsRegion), o.IsRequired(_str_idfsRegion)); }
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
              _name = _str_idfsSettlement, _type = "Int64?",
              _get_func = o => o.idfsSettlement,
              _set_func = (o, val) => { o.idfsSettlement = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSettlement != c.idfsSettlement || o.IsRIRPropChanged(_str_idfsSettlement, c)) 
                  m.Add(_str_idfsSettlement, o.ObjectIdent + _str_idfsSettlement, "Int64?", o.idfsSettlement == null ? "" : o.idfsSettlement.ToString(), o.IsReadOnly(_str_idfsSettlement), o.IsInvisible(_str_idfsSettlement), o.IsRequired(_str_idfsSettlement)); }
              }, 
        
            new field_info {
              _name = _str_CurPeriodType, _type = "Int64?",
              _get_func = o => o.CurPeriodType,
              _set_func = (o, val) => { o.CurPeriodType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.CurPeriodType != c.CurPeriodType || o.IsRIRPropChanged(_str_CurPeriodType, c)) 
                  m.Add(_str_CurPeriodType, o.ObjectIdent + _str_CurPeriodType, "Int64?", o.CurPeriodType == null ? "" : o.CurPeriodType.ToString(), o.IsReadOnly(_str_CurPeriodType), o.IsInvisible(_str_CurPeriodType), o.IsRequired(_str_CurPeriodType)); }
              }, 
        
            new field_info {
              _name = _str_CurAreaType, _type = "Int64?",
              _get_func = o => o.CurAreaType,
              _set_func = (o, val) => { o.CurAreaType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.CurAreaType != c.CurAreaType || o.IsRIRPropChanged(_str_CurAreaType, c)) 
                  m.Add(_str_CurAreaType, o.ObjectIdent + _str_CurAreaType, "Int64?", o.CurAreaType == null ? "" : o.CurAreaType.ToString(), o.IsReadOnly(_str_CurAreaType), o.IsInvisible(_str_CurAreaType), o.IsRequired(_str_CurAreaType)); }
              }, 
        
            new field_info {
              _name = _str_NumberingObject, _type = "long",
              _get_func = o => o.NumberingObject,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.NumberingObject != c.NumberingObject || o.IsRIRPropChanged(_str_NumberingObject, c)) 
                  m.Add(_str_NumberingObject, o.ObjectIdent + _str_NumberingObject, "long", o.NumberingObject == null ? "" : o.NumberingObject.ToString(), o.IsReadOnly(_str_NumberingObject), o.IsInvisible(_str_NumberingObject), o.IsRequired(_str_NumberingObject));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsAdministrativeUnitCalc, _type = "long",
              _get_func = o => o.idfsAdministrativeUnitCalc,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsAdministrativeUnitCalc != c.idfsAdministrativeUnitCalc || o.IsRIRPropChanged(_str_idfsAdministrativeUnitCalc, c)) 
                  m.Add(_str_idfsAdministrativeUnitCalc, o.ObjectIdent + _str_idfsAdministrativeUnitCalc, "long", o.idfsAdministrativeUnitCalc == null ? "" : o.idfsAdministrativeUnitCalc.ToString(), o.IsReadOnly(_str_idfsAdministrativeUnitCalc), o.IsInvisible(_str_idfsAdministrativeUnitCalc), o.IsRequired(_str_idfsAdministrativeUnitCalc));
                 }
              }, 
        
            new field_info {
              _name = _str_datStartDateCalc, _type = "DateTime?",
              _get_func = o => o.datStartDateCalc,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.datStartDateCalc != c.datStartDateCalc || o.IsRIRPropChanged(_str_datStartDateCalc, c)) 
                  m.Add(_str_datStartDateCalc, o.ObjectIdent + _str_datStartDateCalc, "DateTime?", o.datStartDateCalc == null ? "" : o.datStartDateCalc.ToString(), o.IsReadOnly(_str_datStartDateCalc), o.IsInvisible(_str_datStartDateCalc), o.IsRequired(_str_datStartDateCalc));
                 }
              }, 
        
            new field_info {
              _name = _str_datFinishDateCalc, _type = "DateTime?",
              _get_func = o => o.datFinishDateCalc,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.datFinishDateCalc != c.datFinishDateCalc || o.IsRIRPropChanged(_str_datFinishDateCalc, c)) 
                  m.Add(_str_datFinishDateCalc, o.ObjectIdent + _str_datFinishDateCalc, "DateTime?", o.datFinishDateCalc == null ? "" : o.datFinishDateCalc.ToString(), o.IsReadOnly(_str_datFinishDateCalc), o.IsInvisible(_str_datFinishDateCalc), o.IsRequired(_str_datFinishDateCalc));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyEnteredByDate, _type = "string",
              _get_func = o => o.strReadOnlyEnteredByDate,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyEnteredByDate != c.strReadOnlyEnteredByDate || o.IsRIRPropChanged(_str_strReadOnlyEnteredByDate, c)) 
                  m.Add(_str_strReadOnlyEnteredByDate, o.ObjectIdent + _str_strReadOnlyEnteredByDate, "string", o.strReadOnlyEnteredByDate == null ? "" : o.strReadOnlyEnteredByDate.ToString(), o.IsReadOnly(_str_strReadOnlyEnteredByDate), o.IsInvisible(_str_strReadOnlyEnteredByDate), o.IsRequired(_str_strReadOnlyEnteredByDate));
                 }
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
        
            new field_info {
              _name = _str_FFPresenterCase, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.FFPresenterCase != null) o.FFPresenterCase._compare(c.FFPresenterCase, m); }
              }, 
        
            new field_info {
              _name = _str_FFPresenterDiagnostic, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.FFPresenterDiagnostic != null) o.FFPresenterDiagnostic._compare(c.FFPresenterDiagnostic, m); }
              }, 
        
            new field_info {
              _name = _str_FFPresenterProphylactic, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.FFPresenterProphylactic != null) o.FFPresenterProphylactic._compare(c.FFPresenterProphylactic, m); }
              }, 
        
            new field_info {
              _name = _str_FFPresenterSanitary, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
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
                                (c.WeekForAggr != null ? (c.YearForAggr != null ? new DateTime(c.YearForAggr.Value, 1, 1).AddDays(-(int)(new DateTime(c.YearForAggr.Value, 1, 1).DayOfWeek) + 1).AddDays(7 * (c.WeekForAggr.Value - 1)) : default(DateTime?)) :
                                (c.MonthForAggr != null ? (c.YearForAggr != null ? new DateTime(c.YearForAggr.Value, c.MonthForAggr.Value, 1) : default(DateTime?)) : 
                                (c.QuarterForAggr != null ? (c.YearForAggr != null ? new DateTime(c.YearForAggr.Value, (c.QuarterForAggr.Value - 1) * 3 + 1, 1) : default(DateTime?)) : 
                                (c.YearForAggr != null ? new DateTime(c.YearForAggr.Value, 1, 1) : default(DateTime?)
                                )))))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_datFinishDateCalc)]
        public DateTime? datFinishDateCalc
        {
            get { return new Func<AggregateCaseHeader, DateTime?>(c => c.DayForAggr != null ? c.DayForAggr : 
                                (c.WeekForAggr != null ? (c.YearForAggr != null ? new DateTime(c.YearForAggr.Value, 1, 1).AddDays(-(int)(new DateTime(c.YearForAggr.Value, 1, 1).DayOfWeek) + 1).AddDays(7 * c.WeekForAggr.Value).AddDays(-1) : default(DateTime?)) : 
                                (c.MonthForAggr != null ? (c.YearForAggr != null ? (c.MonthForAggr.Value == 12 ? new DateTime(c.YearForAggr.Value + 1, 1, 1).AddDays(-1) : new DateTime(c.YearForAggr.Value, c.MonthForAggr.Value + 1, 1)).AddDays(-1) : default(DateTime?)) : 
                                (c.QuarterForAggr != null ? (c.YearForAggr != null ? (c.QuarterForAggr.Value == 4 ? new DateTime(c.YearForAggr.Value + 1, 1, 1).AddDays(-1) : new DateTime(c.YearForAggr.Value, c.QuarterForAggr.Value * 3 + 1, 1)).AddDays(-1) : default(DateTime?)) : 
                                (c.YearForAggr != null ? new DateTime(c.YearForAggr.Value + 1, 1, 1).AddDays(-1) : default(DateTime?)
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
        public override object Clone()
        {
            var ret = base.Clone() as AggregateCaseHeader;
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
            var ret = base.Clone() as AggregateCaseHeader;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Settings != null)
              ret.Settings = _Settings.CloneWithSetup(manager) as AggregateSettings;
                
            if (_FFPresenterCase != null)
              ret.FFPresenterCase = _FFPresenterCase.CloneWithSetup(manager) as FFPresenterModel;
                
            if (_FFPresenterDiagnostic != null)
              ret.FFPresenterDiagnostic = _FFPresenterDiagnostic.CloneWithSetup(manager) as FFPresenterModel;
                
            if (_FFPresenterProphylactic != null)
              ret.FFPresenterProphylactic = _FFPresenterProphylactic.CloneWithSetup(manager) as FFPresenterModel;
                
            if (_FFPresenterSanitary != null)
              ret.FFPresenterSanitary = _FFPresenterSanitary.CloneWithSetup(manager) as FFPresenterModel;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
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
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
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
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (Settings != null) Settings.RejectChanges();
                
            if (FFPresenterCase != null) FFPresenterCase.RejectChanges();
                
            if (FFPresenterDiagnostic != null) FFPresenterDiagnostic.RejectChanges();
                
            if (FFPresenterProphylactic != null) FFPresenterProphylactic.RejectChanges();
                
            if (FFPresenterSanitary != null) FFPresenterSanitary.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_Settings != null) _Settings.AcceptChanges();
                
            if (_FFPresenterCase != null) _FFPresenterCase.AcceptChanges();
                
            if (_FFPresenterDiagnostic != null) _FFPresenterDiagnostic.AcceptChanges();
                
            if (_FFPresenterProphylactic != null) _FFPresenterProphylactic.AcceptChanges();
                
            if (_FFPresenterSanitary != null) _FFPresenterSanitary.AcceptChanges();
                
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
                
            if (_FFPresenterCase != null) _FFPresenterCase.SetChange();
                
            if (_FFPresenterDiagnostic != null) _FFPresenterDiagnostic.SetChange();
                
            if (_FFPresenterProphylactic != null) _FFPresenterProphylactic.SetChange();
                
            if (_FFPresenterSanitary != null) _FFPresenterSanitary.SetChange();
                
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

      private bool IsRIRPropChanged(string fld, AggregateCaseHeader c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public AggregateCaseHeader()
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
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            AggregateCaseHeader obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AggregateCaseHeader obj = this;
            
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

    
        private static string[] readonly_names1 = "strReadOnlyEnteredByDate".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strSentByOffice,strReceivedByOffice,strEnteredByOffice".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "strSentByPerson,strReceivedByPerson,strEnteredByPerson".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "datEnteredByDate,strCaseID".Split(new char[] { ',' });
        
        private static string[] readonly_names5 = "Country,idfsCountry".Split(new char[] { ',' });
        
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
            
            if (readonly_names5.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AggregateCaseHeader, bool>(c => true)(this);
            
            return ReadOnly || new Func<AggregateCaseHeader, bool>(c => false)(this);
                
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
                
                if (_FFPresenterCase != null)
                    _FFPresenterCase.ReadOnly = value;
                
                if (_FFPresenterDiagnostic != null)
                    _FFPresenterDiagnostic.ReadOnly = value;
                
                if (_FFPresenterProphylactic != null)
                    _FFPresenterProphylactic.ReadOnly = value;
                
                if (_FFPresenterSanitary != null)
                    _FFPresenterSanitary.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<AggregateCaseHeader, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AggregateCaseHeader, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AggregateCaseHeader, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<AggregateCaseHeader, bool>> m_isHiddenPersonalData;
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
        ~AggregateCaseHeader()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
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
                
            if (_FFPresenterCase != null) _FFPresenterCase.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_FFPresenterDiagnostic != null) _FFPresenterDiagnostic.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_FFPresenterProphylactic != null) _FFPresenterProphylactic.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_FFPresenterSanitary != null) _FFPresenterSanitary.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<AggregateCaseHeader>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(AggregateCaseHeader obj);
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
            
                MapResultSet[] sets = new MapResultSet[1];
                List<AggregateCaseHeader> objs = new List<AggregateCaseHeader>();
                sets[0] = new MapResultSet(typeof(AggregateCaseHeader), objs);
                
        
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

                    AggregateCaseHeader obj = objs[0];
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
                    throw DbModelException.Create(e);
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
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadFFPresenterCase(manager, obj);
                _LoadFFPresenterDiagnostic(manager, obj);
                _LoadFFPresenterProphylactic(manager, obj);
                _LoadFFPresenterSanitary(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                    obj.CreateFF(manager, obj);
                  
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

    

            private AggregateCaseHeader _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    AggregateCaseHeader obj = AggregateCaseHeader.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfAggrCase = (new GetNewIDExtender<AggregateCaseHeader>()).GetScalar(manager, obj);
                obj.idfCaseObservation = (new GetNewIDExtender<AggregateCaseHeader>()).GetScalar(manager, obj);
                obj.idfDiagnosticObservation = (new GetNewIDExtender<AggregateCaseHeader>()).GetScalar(manager, obj);
                obj.idfProphylacticObservation = (new GetNewIDExtender<AggregateCaseHeader>()).GetScalar(manager, obj);
                obj.idfSanitaryObservation = (new GetNewIDExtender<AggregateCaseHeader>()).GetScalar(manager, obj);
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

            
            public AggregateCaseHeader CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
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
                        .Where(c => c.idfsCountry == obj.idfsCountry)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("CountryLookup", obj, CountryAccessor.GetType(), "SelectLookupList");
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
                        .Where(c => c.idfsRegion == obj.idfsRegion)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("RegionAggrLookup", obj, RegionAccessor.GetType(), "SelectLookupList");
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
                        .Where(c => c.idfsRayon == obj.idfsRayon)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("RayonAggrLookup", obj, RayonAccessor.GetType(), "SelectLookupList");
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
                        .Where(c => c.idfsSettlement == obj.idfsSettlement)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("SettlementAggrLookup", obj, SettlementAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, AggregateCaseHeader obj)
            {
                
                LoadLookup_Country(manager, obj);
                
                LoadLookup_Region(manager, obj);
                
                LoadLookup_Rayon(manager, obj);
                
                LoadLookup_Settlement(manager, obj);
                
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
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AggregateCaseHeader bo = obj as AggregateCaseHeader;
                    
                
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
                    bSuccess = _PostNonTransaction(manager, obj as AggregateCaseHeader, bChildObject);
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
                                
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
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
                obj.AcceptChanges();
                
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
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as AggregateCaseHeader, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AggregateCaseHeader obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfSentByOffice", "idfSentByOffice","idfCollectedByOffice",
                false
              )).Validate(c => true, obj, obj.idfSentByOffice);
            
                (new RequiredValidator( "idfSentByPerson", "idfSentByPerson","",
                false
              )).Validate(c => true, obj, obj.idfSentByPerson);
            
                (new RequiredValidator( "strSentByOffice", "strSentByOffice","",
                false
              )).Validate(c => true, obj, obj.strSentByOffice);
            
                (new RequiredValidator( "strSentByPerson", "strSentByPerson","",
                false
              )).Validate(c => true, obj, obj.strSentByPerson);
            
                (new RequiredValidator( "datSentByDate", "datSentByDate","",
                false
              )).Validate(c => true, obj, obj.datSentByDate);
            
                (new RequiredValidator( "idfReceivedByOffice", "idfReceivedByOffice","idfCollectedByOffice",
                false
              )).Validate(c => true, obj, obj.idfReceivedByOffice);
            
                (new RequiredValidator( "idfReceivedByPerson", "idfReceivedByPerson","",
                false
              )).Validate(c => true, obj, obj.idfReceivedByPerson);
            
                (new RequiredValidator( "strReceivedByOffice", "strReceivedByOffice","",
                false
              )).Validate(c => true, obj, obj.strReceivedByOffice);
            
                (new RequiredValidator( "strReceivedByPerson", "strReceivedByPerson","",
                false
              )).Validate(c => true, obj, obj.strReceivedByPerson);
            
                (new RequiredValidator( "datReceivedByDate", "datReceivedByDate","",
                false
              )).Validate(c => true, obj, obj.datReceivedByDate);
            
                (new RequiredValidator( "YearForAggr", "YearForAggr","",
                false
              )).Validate(c => 
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Year ||
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter ||
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month ||
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week, obj, obj.YearForAggr);
            
                (new RequiredValidator( "QuarterForAggr", "QuarterForAggr","",
                false
              )).Validate(c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter, obj, obj.QuarterForAggr);
            
                (new RequiredValidator( "MonthForAggr", "MonthForAggr","",
                false
              )).Validate(c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month, obj, obj.MonthForAggr);
            
                (new RequiredValidator( "WeekForAggr", "WeekForAggr","",
                false
              )).Validate(c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week, obj, obj.WeekForAggr);
            
                (new RequiredValidator( "DayForAggr", "DayForAggr","",
                false
              )).Validate(c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Day, obj, obj.DayForAggr);
            
                (new RequiredValidator( "idfsCountry", "Country","",
                false
              )).Validate(c => true, obj, obj.idfsCountry);
            
                (new RequiredValidator( "idfsRegion", "Region","",
                false
              )).Validate(c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Region || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement, obj, obj.idfsRegion);
            
                (new RequiredValidator( "idfsRayon", "Rayon","",
                false
              )).Validate(c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement, obj, obj.idfsRayon);
            
                (new RequiredValidator( "idfsSettlement", "Settlement","Settlement",
                false
              )).Validate(c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement, obj, obj.idfsSettlement);
            
                CheckDuplicates(manager, obj);
            
                  
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
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
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
                    .AddRequired("idfSentByPerson", c => true);
                    
                obj
                    .AddRequired("strSentByOffice", c => true);
                    
                obj
                    .AddRequired("strSentByPerson", c => true);
                    
                obj
                    .AddRequired("datSentByDate", c => true);
                    
                obj
                    .AddRequired("idfReceivedByOffice", c => true);
                    
                obj
                    .AddRequired("idfReceivedByPerson", c => true);
                    
                obj
                    .AddRequired("strReceivedByOffice", c => true);
                    
                obj
                    .AddRequired("strReceivedByPerson", c => true);
                    
                obj
                    .AddRequired("datReceivedByDate", c => true);
                    
                obj
                    .AddRequired("YearForAggr", c => 
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Year ||
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter ||
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month ||
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week);
                    
                obj
                    .AddRequired("QuarterForAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter);
                    
                obj
                    .AddRequired("MonthForAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month);
                    
                obj
                    .AddRequired("WeekForAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week);
                    
                obj
                    .AddRequired("DayForAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Day);
                    
                obj
                    .AddRequired("Country", c => true);
                    
                obj
                    .AddRequired("Region", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Region || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                    
                obj
                    .AddRequired("Rayon", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Rayon || c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                    
                obj
                    .AddRequired("Settlement", c => c.Settings.idfsStatisticAreaType == (long)StatisticAreaType.Settlement);
                    
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
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AggregateCaseHeader, bool>> RequiredByField = new Dictionary<string, Func<AggregateCaseHeader, bool>>();
            public static Dictionary<string, Func<AggregateCaseHeader, bool>> RequiredByProperty = new Dictionary<string, Func<AggregateCaseHeader, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
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
                
                if (!RequiredByField.ContainsKey("idfReceivedByOffice")) RequiredByField.Add("idfReceivedByOffice", c => true);
                if (!RequiredByProperty.ContainsKey("idfReceivedByOffice")) RequiredByProperty.Add("idfReceivedByOffice", c => true);
                
                if (!RequiredByField.ContainsKey("idfReceivedByPerson")) RequiredByField.Add("idfReceivedByPerson", c => true);
                if (!RequiredByProperty.ContainsKey("idfReceivedByPerson")) RequiredByProperty.Add("idfReceivedByPerson", c => true);
                
                if (!RequiredByField.ContainsKey("strReceivedByOffice")) RequiredByField.Add("strReceivedByOffice", c => true);
                if (!RequiredByProperty.ContainsKey("strReceivedByOffice")) RequiredByProperty.Add("strReceivedByOffice", c => true);
                
                if (!RequiredByField.ContainsKey("strReceivedByPerson")) RequiredByField.Add("strReceivedByPerson", c => true);
                if (!RequiredByProperty.ContainsKey("strReceivedByPerson")) RequiredByProperty.Add("strReceivedByPerson", c => true);
                
                if (!RequiredByField.ContainsKey("datReceivedByDate")) RequiredByField.Add("datReceivedByDate", c => true);
                if (!RequiredByProperty.ContainsKey("datReceivedByDate")) RequiredByProperty.Add("datReceivedByDate", c => true);
                
                if (!RequiredByField.ContainsKey("YearForAggr")) RequiredByField.Add("YearForAggr", c => 
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Year ||
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter ||
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month ||
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week);
                if (!RequiredByProperty.ContainsKey("YearForAggr")) RequiredByProperty.Add("YearForAggr", c => 
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Year ||
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter ||
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month ||
                                      c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week);
                
                if (!RequiredByField.ContainsKey("QuarterForAggr")) RequiredByField.Add("QuarterForAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter);
                if (!RequiredByProperty.ContainsKey("QuarterForAggr")) RequiredByProperty.Add("QuarterForAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Quarter);
                
                if (!RequiredByField.ContainsKey("MonthForAggr")) RequiredByField.Add("MonthForAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month);
                if (!RequiredByProperty.ContainsKey("MonthForAggr")) RequiredByProperty.Add("MonthForAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Month);
                
                if (!RequiredByField.ContainsKey("WeekForAggr")) RequiredByField.Add("WeekForAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week);
                if (!RequiredByProperty.ContainsKey("WeekForAggr")) RequiredByProperty.Add("WeekForAggr", c => c.Settings.idfsStatisticPeriodType == (long)StatisticPeriodType.Week);
                
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
                    false
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	