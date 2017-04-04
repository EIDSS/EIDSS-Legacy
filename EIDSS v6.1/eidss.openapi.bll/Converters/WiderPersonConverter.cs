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
    internal class WiderPersonConverter :
        BaseConverter<eidss.openapi.contract.PersonReference, eidss.model.Schema.WiderPersonLookup>
    {
        private static WiderPersonConverter _instance = new WiderPersonConverter();
        private WiderPersonConverter() { AutoConverter.Nop(); }
        public static WiderPersonConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.PersonReference, eidss.model.Schema.WiderPersonLookup>()
                .ConstructUsing(context =>
                    AutoConverter.Construct<eidss.openapi.contract.PersonReference, eidss.model.Schema.WiderPersonLookup>
                        (context, (s, d) => s.RecordID == d.idfPerson, s => s.RecordID))
                .ForMember(p => p.idfOffice, e => e.Ignore())
                .ForMember(p => p.idfPerson, e => e.Ignore())
                .ForMember(p => p.intRowStatus, e => e.Ignore())
                .ForMember(p => p.FullName, e => e.Ignore())
                .ForMember(p => p.Organization, e => e.Ignore())
                .ForMember(p => p.Position, e => e.Ignore())
                .ForMember(p => p.strFamilyName, e => e.Ignore())
                .ForMember(p => p.strFirstName, e => e.Ignore())
                .ForMember(p => p.intHACode, e => e.Ignore())
                .ForMember(p => p.blnHuman, e => e.Ignore())
                .ForMember(p => p.blnVet, e => e.Ignore())
                .ForMember(p => p.blnLivestock, e => e.Ignore())
                .ForMember(p => p.blnAvian, e => e.Ignore())
                .ForMember(p => p.blnVector, e => e.Ignore())
                .ForMember(p => p.blnSyndromic, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.WiderPersonLookup, eidss.openapi.contract.PersonReference>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfPerson))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.FullName))
                .ForMember(d => d.OrganizationRecordID, opt => opt.MapFrom(s => s.idfOffice))
                ;
        }

    }
}