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
    internal class PersonConverter :
        BaseConverter<eidss.openapi.contract.PersonReference, eidss.model.Schema.PersonLookup>
    {
        private static PersonConverter _instance = new PersonConverter();
        private PersonConverter() { AutoConverter.Nop(); }
        public static PersonConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.PersonReference, eidss.model.Schema.PersonLookup>()
                .ConstructUsing(context =>
                    AutoConverter.Construct<eidss.openapi.contract.PersonReference, eidss.model.Schema.PersonLookup>
                        (context, (s, d) => s.RecordID == d.idfPerson, s => s.RecordID))
                .ForMember(p => p.idfOffice, e => e.Ignore())
                .ForMember(p => p.idfPerson, e => e.Ignore())
                .ForMember(p => p.intRowStatus, e => e.Ignore())
                .ForMember(p => p.FullName, e => e.Ignore())
                .ForMember(p => p.Organization, e => e.Ignore())
                .ForMember(p => p.Position, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.PersonLookup, eidss.openapi.contract.PersonReference>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfPerson))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.FullName))
                .ForMember(d => d.OrganizationRecordID, opt => opt.MapFrom(s => s.idfOffice))
                ;
        }

    }
}