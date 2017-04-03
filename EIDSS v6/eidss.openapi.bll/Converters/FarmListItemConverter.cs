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
    internal class FarmListItemConverter :
        IConverter<eidss.openapi.contract.FarmListItem, eidss.model.Schema.FarmListItem>,
        IListConverter<eidss.openapi.contract.FarmListItem, eidss.model.Schema.FarmListItem>
    {
        private static FarmListItemConverter _instance = new FarmListItemConverter();
        private FarmListItemConverter() { AutoConverter.Nop(); }
        public static FarmListItemConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.model.Schema.FarmListItem, eidss.openapi.contract.FarmListItem>()
                .ForMember(c => c.RecordID, e => e.MapFrom(m => m.idfFarm))
                .ForMember(c => c.FarmID, e => e.MapFrom(m => m.strFarmCode))
                .ForMember(p => p.OwnerFirstName, e => e.MapFrom(c => c.strFirstName))
                .ForMember(p => p.OwnerMiddleName, e => e.MapFrom(c => c.strSecondName))
                .ForMember(p => p.OwnerLastName, e => e.MapFrom(c => c.strLastName))
                .ForMember(p => p.Name, e => e.MapFrom(c => c.strNationalName))
                .ForMember(c => c.Type, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.BaseReference.Accessor.Instance(null)
                           .rftOwnershipType_SelectList(manager).SingleOrDefault(i => i.idfsBaseReference == m.idfsOwnershipStructure);
                }))
                .ForMember(c => c.Region, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.idfsCountry == null ? null : eidss.model.Schema.RegionLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, m.idfsCountry, null).SingleOrDefault(i => i.idfsRegion == m.idfsRegion);
                }))
                .ForMember(c => c.Rayon, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.idfsRegion == null ? null : eidss.model.Schema.RayonLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, m.idfsRegion, null).SingleOrDefault(i => i.idfsRayon == m.idfsRayon);
                }))
                .ForMember(c => c.Settlement, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.idfsSettlement == null ? null : eidss.model.Schema.SettlementLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, m.idfsRayon, null).SingleOrDefault(i => i.idfsSettlement == m.idfsSettlement);
                }))
                ;
        }

        public eidss.openapi.contract.FarmListItem ToContract(DbManagerProxy manager, eidss.model.Schema.FarmListItem m)
        {
            return m == null ? null : Mapper.Map<eidss.openapi.contract.FarmListItem>(m);
        }

        public model.Schema.FarmListItem ToModel(DbManagerProxy manager, eidss.model.Schema.FarmListItem m, eidss.openapi.contract.FarmListItem c)
        {
            throw new NotImplementedException();
        }

        public List<FarmListItem> ToContract(DbManagerProxy manager, IList<model.Schema.FarmListItem> m)
        {
            return m.Where(i => !i.IsMarkedToDelete)
                    .Select(c => ToContract(manager, c))
                    .ToList();
        }

        public EditableList<model.Schema.FarmListItem> ToModel(DbManagerProxy manager, IObject parent, EditableList<model.Schema.FarmListItem> m, List<FarmListItem> c)
        {
            throw new NotImplementedException();
        }

    }
}