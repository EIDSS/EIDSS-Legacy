using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using AutoMapper;
using bv.model.BLToolkit;
using eidss.openapi.bll.Exceptions;
using eidss.openapi.contract;

namespace eidss.openapi.bll.Converters
{
    internal class AddressConverter :
        BaseConverter<eidss.openapi.contract.Address, eidss.model.Schema.Address>
    {
        private static AddressConverter _instance = new AddressConverter();
        private AddressConverter(){ AutoConverter.Nop(); }
        public static AddressConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Address, eidss.model.Schema.Address>()
                .ForMember(c => c.Country, e => e.MapFrom(m => m.Country))
                .ForMember(c => c.Region, e => e.MapFrom(m => m.Region))
                .ForMember(c => c.Rayon, e => e.MapFrom(m => m.Rayon))
                .ForMember(c => c.Settlement, e => e.MapFrom(m => m.Settlement))
                .ForMember(c => c.strPostCode, e => e.MapFrom(m => m.PostalCode))
                .ForMember(c => c.strStreetName, e => e.MapFrom(m => m.StreetName))
                .ForMember(c => c.strApartment, e => e.MapFrom(m => m.Apartment))
                .ForMember(c => c.strBuilding, e => e.MapFrom(m => m.Building))
                .ForMember(c => c.strHouse, e => e.MapFrom(m => m.House))
                .ForMember(c => c.strForeignAddress, e => e.MapFrom(m => m.ForeignAddress))
                .ForMember(c => c.dblLatitude, e => e.MapFrom(m => m.Latitude))
                .ForMember(c => c.dblLongitude, e => e.MapFrom(m => m.Longitude))

                .ForMember(p => p.idfGeoLocation, e => e.Ignore())
                .ForMember(p => p.idfsCountry, e => e.Ignore())
                .ForMember(p => p.idfsRegion, e => e.Ignore())
                .ForMember(p => p.idfsRayon, e => e.Ignore())
                .ForMember(p => p.idfsSettlement, e => e.Ignore())
                .ForMember(p => p.strAddressStringTranslate, e => e.Ignore())
                .ForMember(p => p.strAddressDefaultString, e => e.Ignore())
                .ForMember(p => p.blnForeignAddress, e => e.Ignore())
                .ForMember(p => p.CountryLookup, e => e.Ignore())
                .ForMember(p => p.RegionLookup, e => e.Ignore())
                .ForMember(p => p.RayonLookup, e => e.Ignore())
                .ForMember(p => p.SettlementLookup, e => e.Ignore())
                .ForMember(p => p.Street, e => e.Ignore())
                .ForMember(p => p.StreetLookup, e => e.Ignore())
                .ForMember(p => p.PostCode, e => e.Ignore())
                .ForMember(p => p.PostCodeLookup, e => e.Ignore())
                .ForMember(p => p.blnGeoLocationShared, e => e.Ignore())
                .ForMember(p => p.blnReadOnlyRegion, e => e.Ignore())
                .ForMember(p => p.bCancelCoordinationValidation, e => e.Ignore())
                .ForMember(p => p.blnNeedForeignAddressStr, e => e.Ignore())
                .ForMember(p => p.blnForceReadOnly, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                //.ForAllMembers(e => e.Condition(AutoConverter.CheckReadOnly<eidss.model.Schema.Address>))
                ;
            Mapper.CreateMap<eidss.model.Schema.Address, eidss.openapi.contract.Address>()
                .ForMember(d => d.RecordID, opt => opt.MapFrom(s => s.idfGeoLocation))
                .ForMember(d => d.PostalCode, opt => opt.MapFrom(s => s.strPostCode))
                .ForMember(d => d.StreetName, opt => opt.MapFrom(s => s.strStreetName))
                .ForMember(d => d.Apartment, opt => opt.MapFrom(s => s.strApartment))
                .ForMember(d => d.Building, opt => opt.MapFrom(s => s.strBuilding))
                .ForMember(d => d.House, opt => opt.MapFrom(s => s.strHouse))
                .ForMember(d => d.ForeignAddress, opt => opt.MapFrom(s => s.strForeignAddress))
                .ForMember(d => d.Latitude, opt => opt.MapFrom(s => s.dblLatitude))
                .ForMember(d => d.Longitude, opt => opt.MapFrom(s => s.dblLongitude))
                ;
        }
    }
}