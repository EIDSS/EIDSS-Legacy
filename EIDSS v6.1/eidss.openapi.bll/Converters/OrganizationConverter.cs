using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using bv.model.BLToolkit;

namespace eidss.openapi.bll.Converters
{
    internal class OrganizationConverter :
        BaseConverter<eidss.openapi.contract.Organization, eidss.model.Schema.Organization>
    {
        private static OrganizationConverter _instance = new OrganizationConverter();
        private OrganizationConverter(){ AutoConverter.Nop(); }
        public static OrganizationConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Organization, eidss.model.Schema.Organization>()
                .ForMember(m => m.Address, e => e.Condition(c => c.Address != null))

                .ForMember(p => p.intHACode, e => e.MapFrom(c => c.AccessoryCode))
                .ForMember(p => p.EnglishName, e => e.MapFrom(c => c.Abbreviation))
                .ForMember(p => p.EnglishFullName, e => e.MapFrom(c => c.OrganizationName))
                .ForMember(p => p.name, e => e.MapFrom(c => c.LocalAbbreviation))
                .ForMember(p => p.FullName, e => e.MapFrom(c => c.LocalOrganizationName))
                .ForMember(p => p.strContactPhone, e => e.MapFrom(c => c.Phone))
                .ForMember(p => p.strOrganizationID, e => e.MapFrom(c => c.UniqueOrganizationID))
                .ForMember(p => p.Address, e => e.MapFrom(c => c.Address))
                .ForMember(p => p.Persons, e => e.MapFrom(c => c.Persons))

                // readonly
                .ForMember(p => p.idfOffice, e => e.Ignore())

                .ForMember(p => p.Departments, e => e.Ignore())
                .ForMember(p => p.idfLocation, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.Organization, eidss.openapi.contract.Organization>()
                .ForMember(p => p.RecordID, e => e.MapFrom(c => c.idfOffice))
                .ForMember(p => p.AccessoryCode, e => e.MapFrom(c => c.intHACode))
                .ForMember(p => p.Abbreviation, e => e.MapFrom(c => c.EnglishName))
                .ForMember(p => p.OrganizationName, e => e.MapFrom(c => c.EnglishFullName))
                .ForMember(p => p.LocalAbbreviation, e => e.MapFrom(c => c.name))
                .ForMember(p => p.LocalOrganizationName, e => e.MapFrom(c => c.FullName))
                .ForMember(p => p.Phone, e => e.MapFrom(c => c.strContactPhone))
                .ForMember(p => p.UniqueOrganizationID, e => e.MapFrom(c => c.strOrganizationID))
                .ForMember(p => p.Address, e => e.MapFrom(c => c.Address))
                .ForMember(p => p.Persons, e => e.MapFrom(c => c.Persons))
                ;
        }

    }
}