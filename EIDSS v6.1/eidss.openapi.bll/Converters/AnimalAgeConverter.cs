using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using AutoMapper;
using bv.model.BLToolkit;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.openapi.bll.Exceptions;

namespace eidss.openapi.bll.Converters
{
    internal class AnimalAgeConverter :
        BaseConverter<eidss.openapi.contract.Reference, eidss.model.Schema.AnimalAgeLookup>
    {
        private static AnimalAgeConverter _instance = new AnimalAgeConverter();
        private AnimalAgeConverter() { AutoConverter.Nop(); }
        public static AnimalAgeConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Reference, eidss.model.Schema.AnimalAgeLookup>()
                .ConstructUsing(context =>
                    {
                        var source = context.SourceValue as eidss.openapi.contract.Reference;
                        var vcs = context.InstanceCache.Last().Value as AnimalListItem;
                        if (vcs != null)
                        {
                            var list = vcs.AnimalAgeLookup;
                            var ret = list.SingleOrDefault(i => i.idfsReference == source.RecordID);
                            if (ret == null)
                            {
                                throw new ReferenceNotFoundException(source.RecordID, context.MemberName);
                            }
                            return ret;
                        }
                        throw new ReferenceNotFoundException(source.RecordID, context.MemberName);
                    })
                .ForMember(p => p.idfRowNumber, e => e.Ignore())
                .ForMember(p => p.idfsSpeciesType, e => e.Ignore())
                .ForMember(p => p.intOrder, e => e.Ignore())
                .ForMember(p => p.idfsReference, e => e.Ignore())
                .ForMember(p => p.intRowStatus, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.AnimalAgeLookup, eidss.openapi.contract.Reference>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfsReference))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.name))
                ;
        }

    }
}