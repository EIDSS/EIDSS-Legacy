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
    internal class PatientListItemConverter :
        IConverter<eidss.openapi.contract.PatientListItem, eidss.model.Schema.PatientListItem>,
        IListConverter<eidss.openapi.contract.PatientListItem, eidss.model.Schema.PatientListItem>
    {
        private static PatientListItemConverter _instance = new PatientListItemConverter();
        private PatientListItemConverter() { AutoConverter.Nop(); }
        public static PatientListItemConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.model.Schema.PatientListItem, eidss.openapi.contract.PatientListItem>()
                .ForMember(c => c.RecordID, e => e.MapFrom(m => m.idfHumanActual))
                .ForMember(c => c.DateOfBirth, e => e.MapFrom(m => m.datDateofBirth))
                .ForMember(p => p.PatientFirstName, e => e.MapFrom(c => c.strFirstName))
                .ForMember(p => p.PatientMiddleName, e => e.MapFrom(c => c.strSecondName))
                .ForMember(p => p.PatientLastName, e => e.MapFrom(c => c.strLastName))
                .ForMember(p => p.PersonalID, e => e.MapFrom(c => c.strPersonID))
                .ForMember(c => c.PatientPersonalIDType, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.BaseReference.Accessor.Instance(null)
                           .rftPersonIDType_SelectList(manager).SingleOrDefault(i => i.idfsBaseReference == m.idfsPersonIDType);
                }))
                .ForMember(c => c.CurrentResidenceCountry, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.CountryLookup.Accessor.Instance(null)
                           .SelectLookupList(manager).SingleOrDefault(i => i.idfsCountry == m.idfsCountry);
                }))
                .ForMember(c => c.CurrentResidenceRegion, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.idfsCountry == null ? null : eidss.model.Schema.RegionLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, m.idfsCountry, null).SingleOrDefault(i => i.idfsRegion == m.idfsRegion);
                }))
                .ForMember(c => c.CurrentResidenceRayon, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return m.idfsRegion == null ? null : eidss.model.Schema.RayonLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, m.idfsRegion, null).SingleOrDefault(i => i.idfsRayon == m.idfsRayon);
                }))
                ;
        }

        public eidss.openapi.contract.PatientListItem ToContract(DbManagerProxy manager, eidss.model.Schema.PatientListItem m)
        {
            return m == null ? null : Mapper.Map<eidss.openapi.contract.PatientListItem>(m);
        }

        public model.Schema.PatientListItem ToModel(DbManagerProxy manager, eidss.model.Schema.PatientListItem m, eidss.openapi.contract.PatientListItem c)
        {
            throw new NotImplementedException();
        }

        public List<PatientListItem> ToContract(DbManagerProxy manager, IList<model.Schema.PatientListItem> m)
        {
            return m.Where(i => !i.IsMarkedToDelete)
                    .Select(c => ToContract(manager, c))
                    .ToList();
        }

        public EditableList<model.Schema.PatientListItem> ToModel(DbManagerProxy manager, IObject parent, EditableList<model.Schema.PatientListItem> m, List<PatientListItem> c)
        {
            throw new NotImplementedException();
        }

    }
}