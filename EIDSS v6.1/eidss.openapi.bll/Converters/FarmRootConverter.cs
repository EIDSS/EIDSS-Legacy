using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using bv.model.BLToolkit;

namespace eidss.openapi.bll.Converters
{
    internal class FarmRootConverter :
        BaseConverter<eidss.openapi.contract.Farm, eidss.model.Schema.FarmRoot>
    {
        private static FarmRootConverter _instance = new FarmRootConverter();
        private FarmRootConverter(){ AutoConverter.Nop(); }
        public static FarmRootConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Farm, eidss.model.Schema.FarmRoot>()
                .ForMember(m => m.Address, e => e.Condition(c => c.Address != null))

                .ForMember(p => p.idfFarm, e => e.MapFrom(c => c.RecordID))
                .ForMember(p => p.idfRootFarm, e => e.MapFrom(c => c.RootRecordID))
                .ForMember(p => p.strFarmCode, e => e.MapFrom(c => c.FarmID))
                .ForMember(p => p.strOwnerFirstName, e => e.MapFrom(c => c.OwnerFirstName))
                .ForMember(p => p.strOwnerLastName, e => e.MapFrom(c => c.OwnerLastName))
                .ForMember(p => p.strOwnerMiddleName, e => e.MapFrom(c => c.OwnerMiddleName))
                .ForMember(p => p.strEmail, e => e.MapFrom(c => c.Email))
                .ForMember(p => p.strNationalName, e => e.MapFrom(c => c.Name))
                .ForMember(p => p.strContactPhone, e => e.MapFrom(c => c.Phone))
                .ForMember(p => p.strFax, e => e.MapFrom(c => c.Fax))
                .ForMember(p => p.OwnershipStructure, e => e.MapFrom(c => c.Type))
                .ForMember(p => p.Address, e => e.MapFrom(c => c.Address))

                // ignore
                .ForMember(p => p.strInternationalName, e => e.Ignore())
                .ForMember(p => p.HACode, e => e.Ignore())
                .ForMember(p => p.HACodeLookup, e => e.Ignore())
                .ForMember(p => p.idfCase, e => e.Ignore())
                .ForMember(p => p.datModificationDate, e => e.Ignore())
                .ForMember(p => p.idfMonitoringSession, e => e.Ignore())
                .ForMember(p => p.strContactPhone, e => e.Ignore())
                .ForMember(p => p.strFax, e => e.Ignore())
                .ForMember(p => p.strEmail, e => e.Ignore())
                .ForMember(p => p.idfFarmAddress, e => e.Ignore())
                .ForMember(p => p.idfsOwnershipStructure, e => e.Ignore())
                .ForMember(p => p.idfsLivestockProductionType, e => e.Ignore())
                .ForMember(p => p.idfsGrazingPattern, e => e.Ignore())
                .ForMember(p => p.idfsMovementPattern, e => e.Ignore())
                .ForMember(p => p.idfsAvianFarmType, e => e.Ignore())
                .ForMember(p => p.idfsAvianProductionType, e => e.Ignore())
                .ForMember(p => p.idfsIntendedUse, e => e.Ignore())
                .ForMember(p => p.intBirdsPerBuilding, e => e.Ignore())
                .ForMember(p => p.intBuidings, e => e.Ignore())
                .ForMember(p => p.idfOwner, e => e.Ignore())
                .ForMember(p => p.idfRootOwner, e => e.Ignore())
                .ForMember(p => p.strFullName, e => e.Ignore())
                .ForMember(p => p.idfObservation, e => e.Ignore())
                .ForMember(p => p.idfsFormTemplate, e => e.Ignore())
                .ForMember(p => p.blnRootFarm, e => e.Ignore())
                .ForMember(p => p.intHACode, e => e.Ignore())
                .ForMember(p => p.OwnershipStructureLookup, e => e.Ignore())
                .ForMember(p => p._blnAllowFarmReload, e => e.Ignore())
                .ForMember(p => p.datModificationForArchiveDate, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())

                /*.ForAllMembers(e => e.Condition(context =>
                        context.MemberName == "CurrentResidenceAddress" || context.MemberName == "RegistrationAddress" || context.MemberName == "EmployerAddress" 
                        ? context.SourceValue != null
                        : AutoConverter.CheckReadOnly<eidss.model.Schema.Farm>(context)
                    ))*/
                ;
            Mapper.CreateMap<eidss.model.Schema.FarmRoot, eidss.openapi.contract.Farm>()
                .ForMember(p => p.RecordID, e => e.MapFrom(c => c.idfFarm))
                .ForMember(p => p.RootRecordID, e => e.MapFrom(c => c.idfRootFarm))
                .ForMember(p => p.FarmID, e => e.MapFrom(c => c.strFarmCode))
                .ForMember(p => p.OwnerFirstName, e => e.MapFrom(c => c.strOwnerFirstName))
                .ForMember(p => p.OwnerLastName, e => e.MapFrom(c => c.strOwnerLastName))
                .ForMember(p => p.OwnerMiddleName, e => e.MapFrom(c => c.strOwnerMiddleName))
                .ForMember(p => p.Email, e => e.MapFrom(c => c.strEmail))
                .ForMember(p => p.Name, e => e.MapFrom(c => c.strInternationalName))
                .ForMember(p => p.Phone, e => e.MapFrom(c => c.strContactPhone))
                .ForMember(p => p.Fax, e => e.MapFrom(c => c.strFax))
                .ForMember(p => p.Type, e => e.MapFrom(c => c.OwnershipStructure))
                .ForMember(p => p.Address, e => e.MapFrom(c => c.Address))
                ;
        }

    }
}