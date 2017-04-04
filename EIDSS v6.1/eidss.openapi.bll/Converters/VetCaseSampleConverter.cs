using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Helpers;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Schema;
using eidss.openapi.contract;
using eidss.openapi.bll.Exceptions;

namespace eidss.openapi.bll.Converters
{
    internal class VetCaseSampleConverter :
        BaseConverter<eidss.openapi.contract.Sample, eidss.model.Schema.VetCaseSample>
    {
        private static VetCaseSampleConverter _instance = new VetCaseSampleConverter();
        private VetCaseSampleConverter() { AutoConverter.Nop(); }
        public static VetCaseSampleConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Sample, eidss.model.Schema.VetCaseSample>()
                .ConstructUsing(context =>
                    {
                        var source = context.SourceValue as eidss.openapi.contract.Sample;
                        var hc = context.Parent.Parent.DestinationValue as eidss.model.Schema.VetCase;
                        var o = hc.Samples.SingleOrDefault(i => i.idfMaterial == source.RecordID);
                        if (o == null)
                        {
                            if (source.RecordID == 0)
                            {
                                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                                {
                                    o = eidss.model.Schema.VetCaseSample.Accessor.Instance(null).CreateNewT(manager, hc);
                                }
                            }
                            else
                            {
                                throw new ObjectNotFoundException(source.RecordID);
                            }
                        }
                        return o;
                    })
                .ForMember(p => p.idfCase, e => e.MapFrom(c => c.HumanCaseRecordID))
                .ForMember(p => p.idfSpecies, e => e.MapFrom(c => c.SpeciesRecordID))
                .ForMember(p => p.idfAnimal, e => e.MapFrom(c => c.AnimalRecordID))
                .ForMember(p => p.AccessionCondition, e => e.MapFrom(c => c.ConditionReceived))
                .ForMember(c => c.SampleTypeForDiagnosis, e => e.MapFrom(m => m.SampleType))
                .ForMember(p => p.datAccession, e => e.MapFrom(c => c.AccessionDate))
                .ForMember(p => p.datCollectionDateTime, e => e.MapFrom(c => c.CollectionDate))
                .ForMember(p => p.datFieldSentDate, e => e.MapFrom(c => c.SentDate))
                .ForMember(p => p.strFarmCode, e => e.MapFrom(c => c.LocalSampleID))
                .ForMember(p => p.strBarcode, e => e.MapFrom(c => c.LabSampleID))
                .ForMember(p => p.strNote, e => e.MapFrom(c => c.Comment))

                .ForMember(c => c.idfSendToOffice, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.SentToOrganization == null || m.SentToOrganization.RecordID <= 0
                        ? new long?()
                        : eidss.model.Schema.OrganizationLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, null, null).SingleOrDefault(i => i.idfInstitution == m.SentToOrganization.RecordID, i => i.idfInstitution);
                }))
                .ForMember(c => c.idfFieldCollectedByOffice, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.CollectedByInstitution == null || m.CollectedByInstitution.RecordID <= 0
                        ? new long?()
                        : eidss.model.Schema.OrganizationLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, null, null).SingleOrDefault(i => i.idfInstitution == m.CollectedByInstitution.RecordID, i => i.idfInstitution);
                }))
                .ForMember(c => c.idfFieldCollectedByPerson, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.CollectedByOfficer == null || m.CollectedByOfficer.RecordID <= 0
                        ? new long?()
                        : eidss.model.Schema.WiderPersonLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, null, null, true, null).SingleOrDefault(i => i.idfPerson == m.CollectedByOfficer.RecordID, i => i.idfPerson);
                }))
                .ForMember(c => c.idfsSampleStatus, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.Status == null || m.Status.RecordID <= 0
                        ? new long?()
                        : eidss.model.Schema.BaseReference.Accessor.Instance(null)
                           .rftSampleStatus_SelectList(manager).SingleOrDefault(i => i.idfsBaseReference == m.Status.RecordID, i => i.idfsBaseReference);
                }))

                // not yet
                .ForMember(p => p.CaseTests, e => e.Ignore())

                // ignore
                .ForMember(p => p.datFieldCollectionDate, e => e.Ignore())
                .ForMember(p => p.strFieldBarcode, e => e.Ignore())
                .ForMember(p => p.strCondition, e => e.Ignore())
                .ForMember(p => p.strAccessionCondition, e => e.Ignore())
                .ForMember(p => p.AccessionConditionLookup, e => e.Ignore())
                .ForMember(p => p.AnimalName, e => e.Ignore())
                .ForMember(p => p.FilterByDiagnosis, e => e.Ignore())
                .ForMember(p => p.SpeciesName, e => e.Ignore())
                .ForMember(p => p.idfParty, e => e.Ignore())
                .ForMember(p => p.Used, e => e.Ignore())
                .ForMember(p => p.idfAccesionByPerson, e => e.Ignore())
                .ForMember(p => p.idfCase, e => e.Ignore())
                .ForMember(p => p.idfMaterial, e => e.Ignore())
                .ForMember(p => p.idfLocation, e => e.Ignore())
                .ForMember(p => p.idfMonitoringSession, e => e.Ignore())
                .ForMember(p => p.idfRootMaterial, e => e.Ignore())
                .ForMember(p => p.idfMainTest, e => e.Ignore())
                .ForMember(p => p.idfVector, e => e.Ignore())
                .ForMember(p => p.idfVectorSurveillanceSession, e => e.Ignore())
                .ForMember(p => p.idfsAccessionCondition, e => e.Ignore())
                .ForMember(p => p.idfsSpeciesType, e => e.Ignore())
                .ForMember(p => p.idfsSampleType, e => e.Ignore())
                .ForMember(p => p.idfsVectorSubType, e => e.Ignore())
                .ForMember(p => p.idfsVectorType, e => e.Ignore())
                .ForMember(p => p.intQuantity, e => e.Ignore())
                .ForMember(p => p.strAnimalCode, e => e.Ignore())
                .ForMember(p => p.strFarmCode, e => e.Ignore())
                .ForMember(p => p.strFieldCollectedByOffice, e => e.Ignore())
                .ForMember(p => p.strFieldCollectedByPerson, e => e.Ignore())
                .ForMember(p => p.strSendToOffice, e => e.Ignore())
                .ForMember(p => p.strSampleName, e => e.Ignore())
                .ForMember(p => p.strVectorID, e => e.Ignore())
                .ForMember(p => p.strVectorSpecies, e => e.Ignore())
                .ForMember(p => p.strVectorType, e => e.Ignore())
                .ForMember(p => p.idfsBirdStatus, e => e.Ignore())
                .ForMember(p => p.SampleTypeForDiagnosisLookup, e => e.Ignore())
                .ForMember(p => p.BirdStatus, e => e.Ignore())
                .ForMember(p => p.BirdStatusLookup, e => e.Ignore())
                .ForMember(p => p.Animal, e => e.Ignore())
                .ForMember(p => p.AnimalLookup, e => e.Ignore())
                .ForMember(p => p.FarmTree, e => e.Ignore())
                .ForMember(p => p.FarmTreeLookup, e => e.Ignore())
                .ForMember(p => p.AnimalListFromCase, e => e.Ignore())
                .ForMember(p => p.VetFarmTreeFromCase, e => e.Ignore())
                .ForMember(p => p.PensideTests, e => e.Ignore())
                .ForMember(p => p._HACode, e => e.Ignore())
                .ForMember(p => p.CaseSamples, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                .ForAllMembers(e => e.Condition(AutoConverter.CheckReadOnly<eidss.model.Schema.VetCaseSample>))
                ;
            Mapper.CreateMap<eidss.model.Schema.VetCaseSample, eidss.openapi.contract.Sample>()
                .ForMember(p => p.RecordID, e => e.MapFrom(c => c.idfMaterial))
                .ForMember(p => p.SpeciesRecordID, e => e.MapFrom(c => c.idfSpecies))
                .ForMember(p => p.AnimalRecordID, e => e.MapFrom(c => c.idfAnimal))
                .ForMember(p => p.ConditionReceived, e => e.MapFrom(c => c.AccessionCondition))
                .ForMember(c => c.SampleType, e => e.MapFrom(m => m.SampleTypeForDiagnosis))
                .ForMember(p => p.AccessionDate, e => e.MapFrom(c => c.datAccession))
                .ForMember(p => p.CollectionDate, e => e.MapFrom(c => c.datCollectionDateTime))
                .ForMember(p => p.SentDate, e => e.MapFrom(c => c.datFieldSentDate))
                .ForMember(p => p.LocalSampleID, e => e.MapFrom(c => c.strFarmCode))
                .ForMember(p => p.LabSampleID, e => e.MapFrom(c => c.strBarcode))
                .ForMember(p => p.Comment, e => e.MapFrom(c => c.strNote))

                .ForMember(c => c.SentToOrganization, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.OrganizationLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, null, null).SingleOrDefault(i => i.idfInstitution == m.idfSendToOffice);
                }))
                .ForMember(c => c.CollectedByInstitution, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.OrganizationLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, null, null).SingleOrDefault(i => i.idfInstitution == m.idfFieldCollectedByOffice);
                }))
                .ForMember(c => c.CollectedByOfficer, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.WiderPersonLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, m.idfFieldCollectedByOffice, null, true, null).SingleOrDefault(i => i.idfPerson == m.idfFieldCollectedByPerson);
                }))
                .ForMember(c => c.Status, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.BaseReference.Accessor.Instance(null)
                           .rftSampleStatus_SelectList(manager).SingleOrDefault(i => i.idfsBaseReference == m.idfsSampleStatus);
                }))

                .ForMember(p => p.HumanCaseRecordID, e => e.Ignore())
                ;
        }

    }
}