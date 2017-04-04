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
    internal class RayonConverter :
        BaseConverter<eidss.openapi.contract.GisReference, eidss.model.Schema.RayonLookup>
    {
        private static RayonConverter _instance = new RayonConverter();
        private RayonConverter() { AutoConverter.Nop(); }
        public static RayonConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.GisReference, eidss.model.Schema.RayonLookup>()
                .ConstructUsing(context =>
                    AutoConverter.Construct<eidss.openapi.contract.GisReference, eidss.model.Schema.RayonLookup>
                        (context, (s, d) => s.RecordID == d.idfsRayon, s => s.RecordID))
                .ForMember(p => p.idfsRayon, e => e.Ignore())
                .ForMember(p => p.strRayonName, e => e.Ignore())
                .ForMember(p => p.idfsRegion, e => e.Ignore())
                .ForMember(p => p.idfsCountry, e => e.Ignore())
                .ForMember(p => p.strRayonExtendedName, e => e.Ignore())
                .ForMember(p => p.strRegionExtendedName, e => e.Ignore())
                .ForMember(p => p.strCountryName, e => e.Ignore())
                .ForMember(p => p.intRowStatus, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.RayonLookup, eidss.openapi.contract.GisReference>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfsRayon))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.strRayonName))
                ;
        }

    }
}