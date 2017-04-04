using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using bv.model.Helpers;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.openapi.bll.Exceptions;
using AutoMapper;

namespace eidss.openapi.bll.Converters
{
    internal class VetCaseConverter :
        BaseConverter<eidss.openapi.contract.VetCase, eidss.model.Schema.VetCase>
    {
        private static VetCaseConverter _instance = new VetCaseConverter();
        private VetCaseConverter() { AutoConverter.Nop(); }
        public static VetCaseConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.VetCase, eidss.model.Schema.VetCase>()
                .ForMember(c => c.CaseClassification, e => e.MapFrom(m => m.CaseClassification))
                .ForMember(c => c.CaseProgressStatus, e => e.MapFrom(m => m.CaseStatus))
                .ForMember(c => c.CaseType, e => e.MapFrom(m => m.CaseType))
                .ForMember(c => c.CaseReportType, e => e.MapFrom(m => m.ReportType))
                .ForMember(c => c.PersonInvestigatedBy, e => e.MapFrom(m => m.InvestigatorName))
                .ForMember(c => c.datInvestigationDate, e => e.MapFrom(m => m.InvestigationDate))
                .ForMember(c => c.datAssignedDate, e => e.MapFrom(m => m.AssignedDate))
                .ForMember(c => c.datReportDate, e => e.MapFrom(m => m.InitialReportDate))
                .ForMember(c => c.datTentativeDiagnosisDate, e => e.MapFrom(m => m.TentativeDiagnosis1Date))
                .ForMember(c => c.datTentativeDiagnosis1Date, e => e.MapFrom(m => m.TentativeDiagnosis2Date))
                .ForMember(c => c.datTentativeDiagnosis2Date, e => e.MapFrom(m => m.TentativeDiagnosis3Date))
                .ForMember(c => c.datFinalDiagnosisDate, e => e.MapFrom(m => m.FinalDiagnosisDate))
                .ForMember(c => c.TentativeDiagnosis, e => e.MapFrom(m => m.TentativeDiagnosis1))
                .ForMember(c => c.TentativeDiagnosis1, e => e.MapFrom(m => m.TentativeDiagnosis2))
                .ForMember(c => c.TentativeDiagnosis2, e => e.MapFrom(m => m.TentativeDiagnosis3))
                .ForMember(c => c.FinalDiagnosis, e => e.MapFrom(m => m.FinalDiagnosis))
                .ForMember(c => c.strFieldAccessionID, e => e.MapFrom(m => m.FieldAccessionID))
                .ForMember(c => c.strOutbreakID, e => e.MapFrom(m => m.OutbreakID))
                .ForMember(c => c.Farm, e => e.MapFrom(m => m.Farm))
                .ForMember(c => c.Samples, e => e.MapFrom(m => m.Samples))
                .ForMember(c => c.CaseTests, e => e.MapFrom(m => m.Tests))
                .ForMember(p => p.CaseTestValidations, e => e.MapFrom(m => m.TestInterpretations))
                .ForMember(p => p.PensideTests, e => e.MapFrom(m => m.PensideTests))
                .ForMember(p => p.AnimalList, e => e.MapFrom(m => m.Animals))
                .ForMember(c => c.idfPersonReportedBy, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.ReportedByOfficer == null || m.ReportedByOfficer.RecordID <= 0
                        ? new long?()
                        : eidss.model.Schema.WiderPersonLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, null, null, true, null).SingleOrDefault(i => i.idfPerson == m.ReportedByOfficer.RecordID, i => i.idfPerson);
                }))
                .ForMember(c => c.idfPersonEnteredBy, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.EnteredByOfficer == null || m.EnteredByOfficer.RecordID <= 0
                        ? new long?()
                        : eidss.model.Schema.WiderPersonLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, null, null, true, null).SingleOrDefault(i => i.idfPerson == m.EnteredByOfficer.RecordID, i => i.idfPerson);
                }))

                // readonly
                .ForMember(c => c.idfCase, e => e.Ignore())
                .ForMember(c => c.strCaseID, e => e.Ignore())
                .ForMember(c => c.ShowDiagnosis, e => e.Ignore())
                .ForMember(c => c.datEnteredDate, e => e.Ignore())

                // not yet
                .ForMember(p => p.Vaccination, e => e.Ignore())

                // ignore
                .ForMember(p => p.uidOfflineCaseID, e => e.Ignore())
                .ForMember(p => p.strSampleNotes, e => e.Ignore())
                .ForMember(p => p.strTestNotes, e => e.Ignore())
                .ForMember(p => p.strSummaryNotes, e => e.Ignore())
                .ForMember(p => p.strClinicalNotes, e => e.Ignore())
                .ForMember(p => p.TestsConducted, e => e.Ignore())
                .ForMember(p => p.idfOutbreak, e => e.Ignore())
                .ForMember(p => p.idfsCaseProgressStatus, e => e.Ignore())
                .ForMember(p => p.idfsYNTestsConducted, e => e.Ignore())
                .ForMember(p => p.blnEnableTestsConducted, e => e.Ignore())
                .ForMember(p => p.idfsTentativeDiagnosis, e => e.Ignore())
                .ForMember(p => p.idfsFinalDiagnosis, e => e.Ignore())
                .ForMember(p => p.idfInvestigatedByOffice, e => e.Ignore())
                .ForMember(p => p.strInvestigatedByOffice, e => e.Ignore())
                .ForMember(p => p.idfPersonEnteredBy, e => e.Ignore())
                .ForMember(p => p.idfsSite, e => e.Ignore())
                .ForMember(p => p.TentativeDiagnosisLookup, e => e.Ignore())
                .ForMember(p => p.FinalDiagnosisLookup, e => e.Ignore())
                .ForMember(p => p.DiagnosisAll, e => e.Ignore())
                .ForMember(p => p.CaseProgressStatusLookup, e => e.Ignore())
                .ForMember(p => p.TestsConductedLookup, e => e.Ignore())
                .ForMember(p => p.idfsCaseClassification, e => e.Ignore())
                .ForMember(p => p.idfsShowDiagnosis, e => e.Ignore())
                .ForMember(p => p.idfsCaseType, e => e.Ignore())
                .ForMember(p => p.idfParentMonitoringSession, e => e.Ignore())
                .ForMember(p => p.strMonitoringSessionID, e => e.Ignore())
                .ForMember(p => p.idfsTentativeDiagnosis1, e => e.Ignore())
                .ForMember(p => p.idfsTentativeDiagnosis2, e => e.Ignore())
                .ForMember(p => p.idfPersonInvestigatedBy, e => e.Ignore())
                .ForMember(p => p.strPersonInvestigatedBy, e => e.Ignore())
                .ForMember(p => p.strPersonEnteredByName, e => e.Ignore())
                .ForMember(p => p.idfReportedByOffice, e => e.Ignore())
                .ForMember(p => p.strReportedByOffice, e => e.Ignore())
                .ForMember(p => p.idfPersonReportedBy, e => e.Ignore())
                .ForMember(p => p.strPersonReportedBy, e => e.Ignore())
                .ForMember(p => p.idfObservation, e => e.Ignore())
                .ForMember(p => p.idfsFormTemplate, e => e.Ignore())
                .ForMember(p => p.idfsCaseReportType, e => e.Ignore())
                .ForMember(p => p.idfFarm, e => e.Ignore())
                .ForMember(p => p.idfRootFarm, e => e.Ignore())
                .ForMember(p => p.strFinalDiagnosisOIECode, e => e.Ignore())
                .ForMember(p => p.strTentativeDiagnosisOIECode, e => e.Ignore())
                .ForMember(p => p.strTentativeDiagnosis1OIECode, e => e.Ignore())
                .ForMember(p => p.strTentativeDiagnosis2OIECode, e => e.Ignore())
                .ForMember(p => p.FFPresenterControlMeasures, e => e.Ignore())
                .ForMember(p => p.CaseReportTypeLookup, e => e.Ignore())
                .ForMember(p => p.CaseTypeLookup, e => e.Ignore())
                .ForMember(p => p.CaseClassificationLookup, e => e.Ignore())
                .ForMember(p => p.TentativeDiagnosis1Lookup, e => e.Ignore())
                .ForMember(p => p.TentativeDiagnosis2Lookup, e => e.Ignore())
                .ForMember(p => p.ShowDiagnosisLookup, e => e.Ignore())
                .ForMember(p => p.PersonInvestigatedBy, e => e.Ignore())
                .ForMember(p => p.PersonInvestigatedByLookup, e => e.Ignore())
                .ForMember(p => p.Logs, e => e.Ignore())
                .ForMember(p => p.Site, e => e.Ignore())
                .ForMember(p => p.SiteLookup, e => e.Ignore())
                .ForMember(p => p.datModificationForArchiveDate, e => e.Ignore())
                .ForMember(p => p._HACode, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                
                /*.ForAllMembers(e => e.Condition(context => 
                        context.MemberName == "CaseProgressStatus" 
                        ? context.SourceValue != null
                        : AutoConverter.CheckReadOnly<eidss.model.Schema.VetCase>(context)
                    ))*/
                ;
            Mapper.CreateMap<eidss.model.Schema.VetCase, eidss.openapi.contract.VetCase>()
                .ForMember(c => c.RecordID, e => e.MapFrom(m => m.idfCase))
                .ForMember(c => c.CaseID, e => e.MapFrom(m => m.strCaseID))
                .ForMember(c => c.Diagnosis, e => e.MapFrom(m => m.ShowDiagnosis))
                .ForMember(c => c.FinalDiagnosis, e => e.MapFrom(m => m.FinalDiagnosis))
                .ForMember(c => c.TentativeDiagnosis1, e => e.MapFrom(m => m.TentativeDiagnosis))
                .ForMember(c => c.TentativeDiagnosis2, e => e.MapFrom(m => m.TentativeDiagnosis1))
                .ForMember(c => c.TentativeDiagnosis3, e => e.MapFrom(m => m.TentativeDiagnosis2))
                .ForMember(c => c.CaseClassification, e => e.MapFrom(m => m.CaseClassification))
                .ForMember(c => c.CaseStatus, e => e.MapFrom(m => m.CaseProgressStatus))
                .ForMember(c => c.CaseType, e => e.MapFrom(m => m.CaseType))
                .ForMember(c => c.ReportType, e => e.MapFrom(m => m.CaseReportType))
                .ForMember(c => c.InvestigatorName, e => e.MapFrom(m => m.PersonInvestigatedBy))
                .ForMember(c => c.InvestigationDate, e => e.MapFrom(m => m.datInvestigationDate))
                .ForMember(c => c.AssignedDate, e => e.MapFrom(m => m.datAssignedDate))
                .ForMember(c => c.EnteredDate, e => e.MapFrom(m => m.datEnteredDate))
                .ForMember(c => c.FinalDiagnosisDate, e => e.MapFrom(m => m.datFinalDiagnosisDate))
                .ForMember(c => c.InitialReportDate, e => e.MapFrom(m => m.datReportDate))
                .ForMember(c => c.TentativeDiagnosis1Date, e => e.MapFrom(m => m.datTentativeDiagnosisDate))
                .ForMember(c => c.TentativeDiagnosis2Date, e => e.MapFrom(m => m.datTentativeDiagnosis1Date))
                .ForMember(c => c.TentativeDiagnosis3Date, e => e.MapFrom(m => m.datTentativeDiagnosis2Date))
                .ForMember(c => c.FieldAccessionID, e => e.MapFrom(m => m.strFieldAccessionID))
                .ForMember(c => c.OutbreakID, e => e.MapFrom(m => m.strOutbreakID))
                .ForMember(c => c.Farm, e => e.MapFrom(m => m.Farm))
                .ForMember(c => c.Samples, e => e.MapFrom(m => m.Samples))
                .ForMember(c => c.Tests, e => e.MapFrom(m => m.CaseTests))
                .ForMember(p => p.TestInterpretations, e => e.MapFrom(m => m.CaseTestValidations))
                .ForMember(p => p.PensideTests, e => e.MapFrom(m => m.PensideTests))
                .ForMember(p => p.Animals, e => e.MapFrom(m => m.AnimalList))
                .ForMember(c => c.ReportedByOfficer, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.WiderPersonLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, null, null, true, null).SingleOrDefault(i => i.idfPerson == m.idfPersonReportedBy);
                }))
                .ForMember(c => c.EnteredByOfficer, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.WiderPersonLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, null, null, true, null).SingleOrDefault(i => i.idfPerson == m.idfPersonEnteredBy);
                }))
                .ForMember(c => c.Herds, e => e.ResolveUsing(m =>
                    m.Farm.FarmTree.Where(i => i.idfsPartyType == (long)PartyTypeEnum.Herd && i.IsMarkedToDelete == false).ToList())
                )
                .ForMember(c => c.Species, e => e.ResolveUsing(m =>
                    m.Farm.FarmTree.Where(i => i.idfsPartyType == (long)PartyTypeEnum.Species && i.IsMarkedToDelete == false).ToList())
                )
                ;
            ;
        }

    }
}