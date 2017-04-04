using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.openapi.bll.Exceptions;
using eidss.openapi.contract;

namespace eidss.openapi.bll.Converters
{
    internal class VetCaseListItemConverter :
        IConverter<eidss.openapi.contract.VetCaseListItem, eidss.model.Schema.VetCaseListItem>,
        IListConverter<eidss.openapi.contract.VetCaseListItem, eidss.model.Schema.VetCaseListItem>
    {
        private static VetCaseListItemConverter _instance = new VetCaseListItemConverter();
        private VetCaseListItemConverter() { AutoConverter.Nop(); }
        public static VetCaseListItemConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.model.Schema.VetCaseListItem, eidss.openapi.contract.VetCaseListItem>()
                .ForMember(c => c.RecordID, e => e.MapFrom(i => i.idfCase))
                .ForMember(c => c.CaseID, e => e.MapFrom(i => i.strCaseID))
                .ForMember(c => c.AssignedDate, e => e.MapFrom(i => i.datAssignedDate))
                .ForMember(c => c.EnteredDate, e => e.MapFrom(i => i.datEnteredDate))
                .ForMember(c => c.InitialReportDate, e => e.MapFrom(i => i.datReportDate))
                .ForMember(c => c.InvestigationDate, e => e.MapFrom(i => i.datInvestigationDate))
                .ForMember(c => c.FarmName, e => e.MapFrom(i => i.FarmName))
                .ForMember(c => c.Diagnosis, e => e.ResolveUsing(m =>
                    {
                        using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                            return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(null)
                               .SelectLookupList(manager).SingleOrDefault(i => i.idfsDiagnosis == m.idfsShowDiagnosis);
                    }))
                .ForMember(c => c.FinalDiagnosis, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(null)
                           .SelectLookupList(manager).SingleOrDefault(i => i.idfsDiagnosis == m.idfsFinalDiagnosis);
                }))
                .ForMember(c => c.TentativeDiagnosis1, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(null)
                           .SelectLookupList(manager).SingleOrDefault(i => i.idfsDiagnosis == m.idfsTentativeDiagnosis);
                }))
                .ForMember(c => c.TentativeDiagnosis2, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(null)
                           .SelectLookupList(manager).SingleOrDefault(i => i.idfsDiagnosis == m.idfsTentativeDiagnosis1);
                }))
                .ForMember(c => c.TentativeDiagnosis3, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(null)
                           .SelectLookupList(manager).SingleOrDefault(i => i.idfsDiagnosis == m.idfsTentativeDiagnosis2);
                }))
                .ForMember(c => c.CaseClassification, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.BaseReference.Accessor.Instance(null)
                           .rftCaseClassification_SelectList(manager).SingleOrDefault(i => i.idfsBaseReference == m.idfsCaseClassification);
                }))
                .ForMember(c => c.CaseStatus, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.BaseReference.Accessor.Instance(null)
                           .rftCaseProgressStatus_SelectList(manager).SingleOrDefault(i => i.idfsBaseReference == m.idfsCaseProgressStatus);
                }))
                .ForMember(c => c.CaseType, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.BaseReference.Accessor.Instance(null)
                           .rftCaseType_SelectList(manager).SingleOrDefault(i => i.idfsBaseReference == m.idfsCaseType);
                }))
                .ForMember(c => c.ReportType, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.BaseReference.Accessor.Instance(null)
                           .rftCaseReportType_SelectList(manager).SingleOrDefault(i => i.idfsBaseReference == m.idfsCaseReportType);
                }))
                .ForMember(c => c.Country, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.CountryLookup.Accessor.Instance(null)
                           .SelectLookupList(manager).SingleOrDefault(i => i.idfsCountry == m.idfsCountry);
                }))
                .ForMember(c => c.Region, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.idfsCountry == null ? null : eidss.model.Schema.RegionLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, m.idfsCountry, null).SingleOrDefault(i => i.idfsRegion == m.idfsRegion);
                }))
                .ForMember(c => c.Rayon, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.idfsRegion == null ? null : eidss.model.Schema.RayonLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, m.idfsRegion, null).SingleOrDefault(i => i.idfsRayon == m.idfsRayon);
                }))
                .ForMember(c => c.Settlement, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.idfsRayon == null ? null : eidss.model.Schema.SettlementLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, m.idfsRayon, null).SingleOrDefault(i => i.idfsSettlement == m.idfsSettlement);
                }))
                ;
        }

        public eidss.openapi.contract.VetCaseListItem ToContract(DbManagerProxy manager, eidss.model.Schema.VetCaseListItem m)
        {
            return m == null ? null : Mapper.Map<eidss.openapi.contract.VetCaseListItem>(m);
        }

        public model.Schema.VetCaseListItem ToModel(DbManagerProxy manager, eidss.model.Schema.VetCaseListItem m, eidss.openapi.contract.VetCaseListItem c)
        {
            throw new NotImplementedException();
        }

        public List<VetCaseListItem> ToContract(DbManagerProxy manager, IList<model.Schema.VetCaseListItem> m)
        {
            return m.Where(i => !i.IsMarkedToDelete)
                    .Select(c => ToContract(manager, c))
                    .ToList();
        }

        public EditableList<model.Schema.VetCaseListItem> ToModel(DbManagerProxy manager, IObject parent, EditableList<model.Schema.VetCaseListItem> m, List<VetCaseListItem> c)
        {
            throw new NotImplementedException();
        }

    }
}