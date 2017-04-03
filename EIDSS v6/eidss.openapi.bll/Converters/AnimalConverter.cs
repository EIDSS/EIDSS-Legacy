using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Schema;
using eidss.openapi.contract;
using eidss.openapi.bll.Exceptions;

namespace eidss.openapi.bll.Converters
{
    internal class AnimalConverter :
        BaseConverter<eidss.openapi.contract.Animal, eidss.model.Schema.AnimalListItem>
    {
        private static AnimalConverter _instance = new AnimalConverter();
        private AnimalConverter() { AutoConverter.Nop(); }
        public static AnimalConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Animal, eidss.model.Schema.AnimalListItem>()
                .ConstructUsing(context =>
                    {
                        var source = context.SourceValue as eidss.openapi.contract.Animal;
                        var vc = context.Parent.Parent.DestinationValue as eidss.model.Schema.VetCase;
                        var o = vc.AnimalList.SingleOrDefault(i => i.idfAnimal == source.RecordID);
                        if (o == null)
                        {
                            if (source.RecordID == 0)
                            {
                                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                                {
                                    o = eidss.model.Schema.AnimalListItem.Accessor.Instance(null).CreateNewT(manager, vc);
                                }
                            }
                            else
                            {
                                throw new ObjectNotFoundException(source.RecordID);
                            }
                        }
                        return o;
                    })
                .ForMember(c => c.idfAnimal, e => e.MapFrom(m => m.RecordID))
                .ForMember(c => c.idfSpecies, e => e.MapFrom(m => m.SpeciesRecordID))
                .ForMember(c => c.AnimalAge, e => e.MapFrom(m => m.Age))
                .ForMember(c => c.AnimalGender, e => e.MapFrom(m => m.Sex))
                .ForMember(c => c.AnimalCondition, e => e.MapFrom(m => m.Status))


                // ignore
                .ForMember(p => p.idfHerd, e => e.Ignore())
                .ForMember(p => p.strHerdCode, e => e.Ignore())
                .ForMember(p => p.idfCase, e => e.Ignore())
                .ForMember(p => p.idfsAnimalAge, e => e.Ignore())
                .ForMember(p => p.idfsAnimalGender, e => e.Ignore())
                .ForMember(p => p.strAnimalCode, e => e.Ignore())
                .ForMember(p => p.strDescription, e => e.Ignore())
                .ForMember(p => p.idfsAnimalCondition, e => e.Ignore())
                .ForMember(p => p.idfsSpeciesType, e => e.Ignore())
                .ForMember(p => p.idfObservation, e => e.Ignore())
                .ForMember(p => p.idfsFormTemplate, e => e.Ignore())
                .ForMember(p => p.strGender, e => e.Ignore())
                .ForMember(p => p.strSpecies, e => e.Ignore())
                .ForMember(p => p.FFPresenterCs, e => e.Ignore())
                .ForMember(p => p.AnimalGenderLookup, e => e.Ignore())
                .ForMember(p => p.AnimalAgeLookup, e => e.Ignore())
                .ForMember(p => p.AnimalConditionLookup, e => e.Ignore())
                .ForMember(p => p.idfsDiagnosisForCs, e => e.Ignore())
                .ForMember(p => p.strClinicalSigns, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                .ForAllMembers(e => e.Condition(AutoConverter.CheckReadOnly<eidss.model.Schema.AnimalListItem>))
                ;
            Mapper.CreateMap<eidss.model.Schema.AnimalListItem, eidss.openapi.contract.Animal>()
                .ForMember(c => c.RecordID, e => e.MapFrom(m => m.idfAnimal))
                .ForMember(c => c.SpeciesRecordID, e => e.MapFrom(m => m.idfSpecies))
                .ForMember(c => c.Age, e => e.MapFrom(m => m.AnimalAge))
                .ForMember(c => c.Sex, e => e.MapFrom(m => m.AnimalGender))
                .ForMember(c => c.Status, e => e.MapFrom(m => m.AnimalCondition))
                ;
        }

    }
}