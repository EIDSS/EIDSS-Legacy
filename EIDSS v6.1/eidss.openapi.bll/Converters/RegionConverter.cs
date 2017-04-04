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
    internal class RegionConverter :
        BaseConverter<eidss.openapi.contract.GisReference, eidss.model.Schema.RegionLookup>
    {
        private static RegionConverter _instance = new RegionConverter();
        private RegionConverter() { AutoConverter.Nop(); }
        public static RegionConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.GisReference, eidss.model.Schema.RegionLookup>()
                .ConstructUsing(context =>
                    AutoConverter.Construct<eidss.openapi.contract.GisReference, eidss.model.Schema.RegionLookup>
                        (context, (s, d) => s.RecordID == d.idfsRegion, s => s.RecordID))
                .ForMember(p => p.idfsRegion, e => e.Ignore())
                .ForMember(p => p.strRegionName, e => e.Ignore())
                .ForMember(p => p.strRegionCode, e => e.Ignore())
                .ForMember(p => p.idfsCountry, e => e.Ignore())
                .ForMember(p => p.strRegionExtendedName, e => e.Ignore())
                .ForMember(p => p.strCountryName, e => e.Ignore())
                .ForMember(p => p.intRowStatus, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.RegionLookup, eidss.openapi.contract.GisReference>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfsRegion))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.strRegionName))
                ;
        }

    }
}