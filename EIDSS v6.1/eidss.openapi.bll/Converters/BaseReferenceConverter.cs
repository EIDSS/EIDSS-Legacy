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
    internal class BaseReferenceConverter :
        BaseConverter<eidss.openapi.contract.Reference, eidss.model.Schema.BaseReference>
    {
        private static BaseReferenceConverter _instance = new BaseReferenceConverter();
        private BaseReferenceConverter() { AutoConverter.Nop(); }
        public static BaseReferenceConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Reference, eidss.model.Schema.BaseReference>()
                .ConstructUsing(context =>
                    AutoConverter.Construct<eidss.openapi.contract.Reference, eidss.model.Schema.BaseReference>
                        (context, (s, d) => s.RecordID == d.idfsBaseReference, s => s.RecordID))
                .ForMember(p => p.idfsBaseReference, e => e.Ignore())
                .ForMember(p => p.idfsReferenceType, e => e.Ignore())
                .ForMember(p => p.strBaseReferenceCode, e => e.Ignore())
                .ForMember(p => p.name, e => e.Ignore())
                .ForMember(p => p.strDefault, e => e.Ignore())
                .ForMember(p => p.intHACode, e => e.Ignore())
                .ForMember(p => p.intOrder, e => e.Ignore())
                .ForMember(p => p.intRowStatus, e => e.Ignore())
                .ForMember(p => p.blnSystem, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.BaseReference, eidss.openapi.contract.Reference>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfsBaseReference))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.name))
                ;
        }
    }
}