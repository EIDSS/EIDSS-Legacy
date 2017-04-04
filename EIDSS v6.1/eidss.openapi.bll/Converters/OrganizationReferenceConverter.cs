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
    internal class OrganizationReferenceConverter :
        BaseConverter<eidss.openapi.contract.OrganizationReference, eidss.model.Schema.OrganizationLookup>
    {
        private static OrganizationReferenceConverter _instance = new OrganizationReferenceConverter();
        private OrganizationReferenceConverter() { AutoConverter.Nop(); }
        public static OrganizationReferenceConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.OrganizationReference, eidss.model.Schema.OrganizationLookup>()
                .ConstructUsing(context =>
                    AutoConverter.Construct<eidss.openapi.contract.OrganizationReference, eidss.model.Schema.OrganizationLookup>
                        (context, (s, d) => s.RecordID == d.idfInstitution, s => s.RecordID))
                .ForMember(p => p.idfInstitution, e => e.Ignore())
                .ForMember(p => p.idfsOfficeAbbreviation, e => e.Ignore())
                .ForMember(p => p.idfsOfficeName, e => e.Ignore())
                .ForMember(p => p.intRowStatus, e => e.Ignore())
                .ForMember(p => p.name, e => e.Ignore())
                .ForMember(p => p.FullName, e => e.Ignore())
                .ForMember(p => p.blnHuman, e => e.Ignore())
                .ForMember(p => p.blnVet, e => e.Ignore())
                .ForMember(p => p.blnLivestock, e => e.Ignore())
                .ForMember(p => p.blnAvian, e => e.Ignore())
                .ForMember(p => p.blnVector, e => e.Ignore())
                .ForMember(p => p.intHACode, e => e.Ignore())
                .ForMember(p => p.idfsSite, e => e.Ignore())
                .ForMember(p => p.strOrganizationID, e => e.Ignore())
                .ForMember(p => p.blnSyndromic, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.OrganizationLookup, eidss.openapi.contract.OrganizationReference>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfInstitution))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.name))
                ;
        }

    }
}