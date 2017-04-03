using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using AutoMapper;
using bv.model.BLToolkit;
using eidss.model.Enums;
using eidss.openapi.bll.Exceptions;

namespace eidss.openapi.bll.Converters
{
    internal class DiagnosisConverter :
        BaseConverter<eidss.openapi.contract.Diagnosis, eidss.model.Schema.DiagnosisLookup>
    {
        private static DiagnosisConverter _instance = new DiagnosisConverter();
        private DiagnosisConverter() { AutoConverter.Nop(); }
        public static DiagnosisConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Diagnosis, eidss.model.Schema.DiagnosisLookup>()
                .ConstructUsing(context =>
                    AutoConverter.Construct<eidss.openapi.contract.Diagnosis, eidss.model.Schema.DiagnosisLookup>
                        (context, (s, d) => s.RecordID == d.idfsDiagnosis, s => s.RecordID))
                .ForMember(p => p.idfsDiagnosis, e => e.Ignore())
                .ForMember(p => p.name, e => e.Ignore())
                .ForMember(p => p.strIDC10, e => e.Ignore())
                .ForMember(p => p.strOIECode, e => e.Ignore())
                .ForMember(p => p.HACode, e => e.Ignore())
                .ForMember(p => p.intHACode, e => e.Ignore())
                .ForMember(p => p.idfsUsingType, e => e.Ignore())
                .ForMember(p => p.blnZoonotic, e => e.Ignore())
                .ForMember(p => p.strZoonotic, e => e.Ignore())
                .ForMember(p => p.idfsDiagnosisGroup, e => e.Ignore())
                .ForMember(p => p.strDiagnosesGroupName, e => e.Ignore())
                .ForMember(p => p.intRowStatus, e => e.Ignore())
                .ForMember(p => p.intOrder, e => e.Ignore())
                .ForMember(p => p.UsingTypeName, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.DiagnosisLookup, eidss.openapi.contract.Diagnosis>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfsDiagnosis))
                .ForMember(d => d.DiagnosisName, opt => opt.MapFrom(s => s.name))
                .ForMember(d => d.Aggregate, opt => opt.ResolveUsing(s => s.idfsUsingType == (long)DiagnosisUsingTypeEnum.AggregatedCase))
                .ForMember(d => d.AccessoryCode, opt => opt.MapFrom(s => s.intHACode))
                .ForMember(d => d.IDC10Code, opt => opt.MapFrom(s => s.strIDC10))
                ;
        }

    }
}