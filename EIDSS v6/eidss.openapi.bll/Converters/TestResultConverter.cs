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
    internal class TestResultConverter :
        BaseConverter<eidss.openapi.contract.Reference, eidss.model.Schema.TestResultLookup>
    {
        private static TestResultConverter _instance = new TestResultConverter();
        private TestResultConverter() { AutoConverter.Nop(); }
        public static TestResultConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Reference, eidss.model.Schema.TestResultLookup>()
                .ConstructUsing(context =>
                    {
                        var source = context.SourceValue as eidss.openapi.contract.Reference;
                        var o = context.InstanceCache.Last().Value as CaseTest;
                        var list = o.TestResultRefLookup;
                        var ret = list.SingleOrDefault(i => i.idfsReference == source.RecordID);
                        if (ret == null)
                        {
                            throw new ReferenceNotFoundException(source.RecordID, context.MemberName);
                        }
                        return ret;
                    })
                .ForMember(p => p.idfsTestName, e => e.Ignore())
                .ForMember(p => p.idfsReference, e => e.Ignore())
                .ForMember(p => p.name, e => e.Ignore())
                .ForMember(p => p.intRowStatus, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.TestResultLookup, eidss.openapi.contract.Reference>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfsReference))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.name))
                ;
        }

    }
}