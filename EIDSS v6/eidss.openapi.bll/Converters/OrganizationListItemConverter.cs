using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.openapi.bll.Exceptions;
using eidss.openapi.contract;

namespace eidss.openapi.bll.Converters
{
    internal class OrganizationListItemConverter :
        IConverter<eidss.openapi.contract.OrganizationListItem, eidss.model.Schema.OrganizationListItem>,
        IListConverter<eidss.openapi.contract.OrganizationListItem, eidss.model.Schema.OrganizationListItem>
    {
        private static OrganizationListItemConverter _instance = new OrganizationListItemConverter();
        private OrganizationListItemConverter() { AutoConverter.Nop(); }
        public static OrganizationListItemConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.model.Schema.OrganizationListItem, eidss.openapi.contract.OrganizationListItem>()
                .ForMember(c => c.RecordID, e => e.MapFrom(m => m.idfInstitution))
                .ForMember(c => c.AccessoryCode, e => e.MapFrom(m => m.intHACode))
                .ForMember(p => p.Abbreviation, e => e.MapFrom(c => c.name))
                .ForMember(p => p.OrganizationName, e => e.MapFrom(c => c.FullName))
                .ForMember(p => p.UniqueOrganizationID, e => e.MapFrom(c => c.strOrganizationID))
                .ForMember(p => p.Address, e => e.MapFrom(c => c.Address))
                ;
        }

        public eidss.openapi.contract.OrganizationListItem ToContract(DbManagerProxy manager, eidss.model.Schema.OrganizationListItem m)
        {
            return m == null ? null : Mapper.Map<eidss.openapi.contract.OrganizationListItem>(m);
        }

        public model.Schema.OrganizationListItem ToModel(DbManagerProxy manager, eidss.model.Schema.OrganizationListItem m, eidss.openapi.contract.OrganizationListItem c)
        {
            throw new NotImplementedException();
        }

        public List<OrganizationListItem> ToContract(DbManagerProxy manager, IList<model.Schema.OrganizationListItem> m)
        {
            return m.Where(i => !i.IsMarkedToDelete)
                    .Select(c => ToContract(manager, c))
                    .ToList();
        }

        public EditableList<model.Schema.OrganizationListItem> ToModel(DbManagerProxy manager, IObject parent, EditableList<model.Schema.OrganizationListItem> m, List<OrganizationListItem> c)
        {
            throw new NotImplementedException();
        }

    }
}