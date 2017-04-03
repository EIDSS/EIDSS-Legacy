using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using AutoMapper;
using bv.model.BLToolkit;
using eidss.openapi.bll.Exceptions;

namespace eidss.openapi.bll.Converters
{
    internal class SettlementConverter :
        BaseConverter<eidss.openapi.contract.GisReference, eidss.model.Schema.SettlementLookup>
    {
        private static SettlementConverter _instance = new SettlementConverter();
        private SettlementConverter() { AutoConverter.Nop(); }
        public static SettlementConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.GisReference, eidss.model.Schema.SettlementLookup>()
                .ConstructUsing(context =>
                    AutoConverter.Construct<eidss.openapi.contract.GisReference, eidss.model.Schema.SettlementLookup>
                        (context, (s, d) => s.RecordID == d.idfsSettlement, s => s.RecordID))
                .ForMember(p => p.idfsSettlement, e => e.Ignore())
                .ForMember(p => p.strSettlementName, e => e.Ignore())
                .ForMember(p => p.idfsRayon, e => e.Ignore())
                .ForMember(p => p.idfsRegion, e => e.Ignore())
                .ForMember(p => p.idfsCountry, e => e.Ignore())
                .ForMember(p => p.strSettlementExtendedName, e => e.Ignore())
                .ForMember(p => p.strSettlementType, e => e.Ignore())
                .ForMember(p => p.strCountryName, e => e.Ignore())
                .ForMember(p => p.strRegionExtendedName, e => e.Ignore())
                .ForMember(p => p.strRayonExtendedName, e => e.Ignore())
                .ForMember(p => p.intRowStatus, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.SettlementLookup, eidss.openapi.contract.GisReference>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfsSettlement))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.strSettlementName))
                ;
        }

    }
}