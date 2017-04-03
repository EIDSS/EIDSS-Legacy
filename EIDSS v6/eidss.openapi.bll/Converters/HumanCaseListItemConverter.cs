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
    internal class HumanCaseListItemConverter :
        IConverter<eidss.openapi.contract.HumanCaseListItem, eidss.model.Schema.HumanCaseListItem>,
        IListConverter<eidss.openapi.contract.HumanCaseListItem, eidss.model.Schema.HumanCaseListItem>
    {
        private static HumanCaseListItemConverter _instance = new HumanCaseListItemConverter();
        private HumanCaseListItemConverter() { AutoConverter.Nop(); }
        public static HumanCaseListItemConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.model.Schema.HumanCaseListItem, eidss.openapi.contract.HumanCaseListItem>()
                .ForMember(c => c.RecordID, e => e.MapFrom(m => m.idfCase))
                .ForMember(c => c.CaseID, e => e.MapFrom(m => m.strCaseID))
                .ForMember(c => c.LocalID, e => e.MapFrom(m => m.strLocalIdentifier))
                .ForMember(c => c.PatientLastName, e => e.MapFrom(m => m.strLastName))
                .ForMember(c => c.PatientFirstName, e => e.MapFrom(m => m.strFirstName))
                .ForMember(c => c.DateEntered, e => e.MapFrom(m => m.datEnteredDate))
                .ForMember(c => c.DateOfBirth, e => e.MapFrom(m => m.datDateofBirth))
                .ForMember(c => c.DateOfCompletionOfPaperForm, e => e.MapFrom(m => m.datCompletionPaperFormDate))
                .ForMember(c => c.FinalDiagnosis, e => e.ResolveUsing(m =>
                    {
                        using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                            return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(null)
                               .SelectLookupList(manager).SingleOrDefault(i => i.idfsDiagnosis == m.idfsDiagnosis);
                    }))
                .ForMember(c => c.InitialCaseClassification, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.InitialCaseClassificationLookup.Accessor.Instance(null)
                           .SelectLookupList(manager).SingleOrDefault(i => i.idfsReference == m.idfsInitialCaseStatus);
                }))
                .ForMember(c => c.FinalCaseClassification, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.BaseReference.Accessor.Instance(null)
                           .rftCaseClassification_SelectList(manager).SingleOrDefault(i => i.idfsBaseReference == m.idfsCaseStatus);
                }))
                .ForMember(c => c.CaseStatus, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.BaseReference.Accessor.Instance(null)
                           .rftCaseProgressStatus_SelectList(manager).SingleOrDefault(i => i.idfsBaseReference == m.idfsCaseProgressStatus);
                }))
                .ForMember(c => c.Age, e => e.MapFrom(m => m.intPatientAge))
                .ForMember(c => c.AgeType, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.BaseReference.Accessor.Instance(null)
                           .rftHumanAgeType_SelectList(manager).SingleOrDefault(i => i.idfsBaseReference == m.idfsHumanAgeType);
                }))
                .ForMember(c => c.CurrentResidenceCountry, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.CountryLookup.Accessor.Instance(null)
                           .SelectLookupList(manager).SingleOrDefault(i => i.idfsCountry == m.idfsCountry);
                }))
                .ForMember(c => c.CurrentResidenceRegion, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.idfsCountry == null ? null : eidss.model.Schema.RegionLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, m.idfsCountry, null).SingleOrDefault(i => i.idfsRegion == m.idfsRegion);
                }))
                .ForMember(c => c.CurrentResidenceRayon, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.idfsRegion == null ? null : eidss.model.Schema.RayonLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, m.idfsRegion, null).SingleOrDefault(i => i.idfsRayon == m.idfsRayon);
                }))
                .ForMember(c => c.CurrentResidenceSettlement, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.idfsRayon == null ? null : eidss.model.Schema.SettlementLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, m.idfsRayon, null).SingleOrDefault(i => i.idfsSettlement == m.idfsSettlement);
                }))
                ;
        }

        public eidss.openapi.contract.HumanCaseListItem ToContract(DbManagerProxy manager, eidss.model.Schema.HumanCaseListItem m)
        {
            return m == null ? null : Mapper.Map<eidss.openapi.contract.HumanCaseListItem>(m);
        }

        public model.Schema.HumanCaseListItem ToModel(DbManagerProxy manager, eidss.model.Schema.HumanCaseListItem m, eidss.openapi.contract.HumanCaseListItem c)
        {
            throw new NotImplementedException();
        }

        public List<HumanCaseListItem> ToContract(DbManagerProxy manager, IList<model.Schema.HumanCaseListItem> m)
        {
            return m.Where(i => !i.IsMarkedToDelete)
                    .Select(c => ToContract(manager, c))
                    .ToList();
        }

        public EditableList<model.Schema.HumanCaseListItem> ToModel(DbManagerProxy manager, IObject parent, EditableList<model.Schema.HumanCaseListItem> m, List<HumanCaseListItem> c)
        {
            throw new NotImplementedException();
        }

    }
}