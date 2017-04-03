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
    internal class SampleTypeForDiagnosisConverter :
        BaseConverter<eidss.openapi.contract.Reference, eidss.model.Schema.SampleTypeForDiagnosisLookup>
    {
        private static SampleTypeForDiagnosisConverter _instance = new SampleTypeForDiagnosisConverter();
        private SampleTypeForDiagnosisConverter() { AutoConverter.Nop(); }
        public static SampleTypeForDiagnosisConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Reference, eidss.model.Schema.SampleTypeForDiagnosisLookup>()
                .ConstructUsing(context =>
                    {
                        var source = context.SourceValue as eidss.openapi.contract.Reference;
                        var hcs = context.InstanceCache.Last().Value as HumanCaseSample;
                        if (hcs != null)
                        {
                            var list = hcs.SampleTypeWithUnknownLookup;
                            var ret = list.SingleOrDefault(i => i.idfsReference == source.RecordID);
                            if (ret == null)
                            {
                                throw new ReferenceNotFoundException(source.RecordID, context.MemberName);
                            }
                            return ret;
                        }
                        var vcs = context.InstanceCache.Last().Value as VetCaseSample;
                        if (vcs != null)
                        {
                            var list = vcs.SampleTypeForDiagnosisLookup;
                            var ret = list.SingleOrDefault(i => i.idfsReference == source.RecordID);
                            if (ret == null)
                            {
                                throw new ReferenceNotFoundException(source.RecordID, context.MemberName);
                            }
                            return ret;
                        }
                        throw new ReferenceNotFoundException(source.RecordID, context.MemberName);
                    })
                .ForMember(p => p.idfMaterialForDisease, e => e.Ignore())
                .ForMember(p => p.idfsDiagnosis, e => e.Ignore())
                .ForMember(p => p.idfsReference, e => e.Ignore())
                .ForMember(p => p.name, e => e.Ignore())
                .ForMember(p => p.intHACode, e => e.Ignore())
                .ForMember(p => p.intRowStatus, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.SampleTypeForDiagnosisLookup, eidss.openapi.contract.Reference>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfMaterialForDisease))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.name))
                ;
        }

    }
}