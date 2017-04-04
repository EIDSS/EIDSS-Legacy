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
    internal class FinalCaseClassificationConverter :
        BaseConverter<eidss.openapi.contract.Reference, eidss.model.Schema.FinalCaseClassificationLookup>
    {
        private static FinalCaseClassificationConverter _instance = new FinalCaseClassificationConverter();
        private FinalCaseClassificationConverter() { AutoConverter.Nop(); }
        public static FinalCaseClassificationConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Reference, eidss.model.Schema.FinalCaseClassificationLookup>()
                .ConstructUsing(context =>
                    AutoConverter.Construct<eidss.openapi.contract.Reference, eidss.model.Schema.FinalCaseClassificationLookup>
                        (context, (s, d) => s.RecordID == d.idfsReference, s => s.RecordID))
                .ForMember(p => p.idfsReferenceType, e => e.Ignore())
                .ForMember(p => p.idfsReference, e => e.Ignore())
                .ForMember(p => p.name, e => e.Ignore())
                .ForMember(p => p.LongName, e => e.Ignore())
                .ForMember(p => p.strDefault, e => e.Ignore())
                .ForMember(p => p.intHACode, e => e.Ignore())
                .ForMember(p => p.intOrder, e => e.Ignore())
                .ForMember(p => p.intRowStatus, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.FinalCaseClassificationLookup, eidss.openapi.contract.Reference>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfsReference))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.name))
                ;
        }

    }
}