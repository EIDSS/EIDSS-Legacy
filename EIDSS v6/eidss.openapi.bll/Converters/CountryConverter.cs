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
    internal class CountryConverter :
        BaseConverter<eidss.openapi.contract.GisReference, eidss.model.Schema.CountryLookup>
    {
        private static CountryConverter _instance = new CountryConverter();
        private CountryConverter() { AutoConverter.Nop(); }
        public static CountryConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.GisReference, eidss.model.Schema.CountryLookup>()
                .ConstructUsing(context =>
                    AutoConverter.Construct<eidss.openapi.contract.GisReference, eidss.model.Schema.CountryLookup>
                        (context, (s, d) => s.RecordID == d.idfsCountry, s => s.RecordID))
                .ForMember(p => p.idfsCountry, e => e.Ignore())
                .ForMember(p => p.strCountryName, e => e.Ignore())
                .ForMember(p => p.strCountryCode, e => e.Ignore())
                .ForMember(p => p.intRowStatus, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.CountryLookup, eidss.openapi.contract.GisReference>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfsCountry))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.strCountryName))
                ;
        }

    }
}