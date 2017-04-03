using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.openapi.contract;
using eidss.openapi.bll.Exceptions;

namespace eidss.openapi.bll.Converters
{
    internal class HerdConverter :
        BaseConverter<eidss.openapi.contract.Animal, eidss.model.Schema.VetFarmTree>
    {
        private static HerdConverter _instance = new HerdConverter();
        private HerdConverter() { AutoConverter.Nop(); }
        public static HerdConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Herd, eidss.model.Schema.VetFarmTree>()
                .ConstructUsing(context =>
                    {
                        var source = context.SourceValue as eidss.openapi.contract.Herd;
                        var vc = context.Parent.Parent.DestinationValue as eidss.model.Schema.VetCase;
                        var o = vc.Farm.FarmTree.SingleOrDefault(i => i.idfParty == source.RecordID);
                        if (o == null)
                        {
                            if (source.RecordID == 0)
                            {
                                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                                {
                                    VetFarmTree parent = vc.Farm.FarmTree.SingleOrDefault(i => i.idfsPartyType == (long)PartyTypeEnum.Farm);
                                    o = eidss.model.Schema.VetFarmTree.Accessor.Instance(null).CreateHerd(manager, vc, parent);
                                }
                            }
                            else
                            {
                                throw new ObjectNotFoundException(source.RecordID);
                            }
                        }
                        return o;
                    })
                .ForMember(c => c.idfParty, e => e.MapFrom(m => m.RecordID))
                .ForMember(c => c.idfCase, e => e.MapFrom(m => m.VetCaseRecordID))
                .ForMember(c => c.intDeadAnimalQty, e => e.MapFrom(m => m.NumberOfDeadAnimals))
                .ForMember(c => c.intSickAnimalQty, e => e.MapFrom(m => m.NumberOfSickAnimals))
                .ForMember(c => c.intTotalAnimalQty, e => e.MapFrom(m => m.TotalNumberOfAnimals))


                // ignore
                .ForMember(p => p.idfFarm, e => e.Ignore())
                .ForMember(p => p.idfMonitoringSession, e => e.Ignore())
                .ForMember(p => p.idfsPartyType, e => e.Ignore())
                .ForMember(p => p.strName, e => e.Ignore())
                .ForMember(p => p.idfParentParty, e => e.Ignore())
                .ForMember(p => p.idfObservation, e => e.Ignore())
                .ForMember(p => p.idfsFormTemplate, e => e.Ignore())
                .ForMember(p => p.strAverageAge, e => e.Ignore())
                .ForMember(p => p.datStartOfSignsDate, e => e.Ignore())
                .ForMember(p => p.strNote, e => e.Ignore())
                .ForMember(p => p.FFPresenterCs, e => e.Ignore())
                .ForMember(p => p.SpeciesType, e => e.Ignore())
                .ForMember(p => p.SpeciesTypeLookup, e => e.Ignore())
                .ForMember(p => p.idfsSpeciesTypeReference, e => e.Ignore())
                .ForMember(p => p.Case, e => e.Ignore())
                .ForMember(p => p.VetFarmTreeList, e => e.Ignore())
                .ForMember(p => p.idfsDiagnosisForCs, e => e.Ignore())
                .ForMember(p => p.strHerdName, e => e.Ignore())
                .ForMember(p => p._HACode, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                .ForAllMembers(e => e.Condition(AutoConverter.CheckReadOnly<eidss.model.Schema.VetFarmTree>))
                ;
            Mapper.CreateMap<eidss.model.Schema.VetFarmTree, eidss.openapi.contract.Herd>()
                .ForMember(c => c.RecordID, e => e.MapFrom(m => m.idfParty))
                .ForMember(c => c.VetCaseRecordID, e => e.MapFrom(m => m.idfCase))
                .ForMember(c => c.NumberOfDeadAnimals, e => e.MapFrom(m => m.intDeadAnimalQty))
                .ForMember(c => c.NumberOfSickAnimals, e => e.MapFrom(m => m.intSickAnimalQty))
                .ForMember(c => c.TotalNumberOfAnimals, e => e.MapFrom(m => m.intTotalAnimalQty))
                ;
        }

    }
}