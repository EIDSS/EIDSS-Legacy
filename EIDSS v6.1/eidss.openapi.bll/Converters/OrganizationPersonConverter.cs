using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.openapi.bll.Exceptions;

namespace eidss.openapi.bll.Converters
{
    internal class OrganizationPersonConverter :
        BaseConverter<eidss.openapi.contract.Person, eidss.model.Schema.OrganizationsPerson>
    {
        private static OrganizationPersonConverter _instance = new OrganizationPersonConverter();
        private OrganizationPersonConverter(){ AutoConverter.Nop(); }
        public static OrganizationPersonConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Person, eidss.model.Schema.OrganizationsPerson>()
                .ConstructUsing(context =>
                {
                    var source = context.SourceValue as eidss.openapi.contract.Person;
                    var hc = context.Parent.Parent.DestinationValue as eidss.model.Schema.Organization;
                    var o = hc.Persons.SingleOrDefault(i => i.idfPerson == source.RecordID);
                    if (o == null)
                    {
                        if (source.RecordID == 0)
                        {
                            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                            {
                                o = eidss.model.Schema.OrganizationsPerson.Accessor.Instance(null).CreateNewT(manager, hc);
                            }
                        }
                        else
                        {
                            throw new ObjectNotFoundException(source.RecordID);
                        }
                    }
                    return o;
                })

                .ForMember(p => p.strFirstName, e => e.MapFrom(c => c.PersonFirstName))
                .ForMember(p => p.strSecondName, e => e.MapFrom(c => c.PersonMiddleName))
                .ForMember(p => p.strFamilyName, e => e.MapFrom(c => c.PersonLastName))

                // readonly
                .ForMember(p => p.idfPerson, e => e.Ignore())

                .ForMember(p => p.idfsStaffPosition, e => e.Ignore())
                .ForMember(p => p.idfInstitution, e => e.Ignore())
                .ForMember(p => p.idfDepartment, e => e.Ignore())
                .ForMember(p => p.strContactPhone, e => e.Ignore())
                .ForMember(p => p.strBarcode, e => e.Ignore())
                .ForMember(p => p.idfsSite, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                ;
            Mapper.CreateMap<eidss.model.Schema.OrganizationsPerson, eidss.openapi.contract.Person>()
                .ForMember(p => p.RecordID, e => e.MapFrom(c => c.idfPerson))
                .ForMember(p => p.PersonFirstName, e => e.MapFrom(c => c.strFirstName))
                .ForMember(p => p.PersonMiddleName, e => e.MapFrom(c => c.strSecondName))
                .ForMember(p => p.PersonLastName, e => e.MapFrom(c => c.strFamilyName))
                ;
        }

    }
}