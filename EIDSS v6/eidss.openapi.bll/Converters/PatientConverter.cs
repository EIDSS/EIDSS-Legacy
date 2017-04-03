using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using bv.model.BLToolkit;

namespace eidss.openapi.bll.Converters
{
    internal class PatientConverter :
        BaseConverter<eidss.openapi.contract.Patient, eidss.model.Schema.Patient>
    {
        private static PatientConverter _instance = new PatientConverter();
        private PatientConverter(){ AutoConverter.Nop(); }
        public static PatientConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Patient, eidss.model.Schema.Patient>()
                .ForMember(m => m.CurrentResidenceAddress, e => e.Condition(c => c.PatientCurrentResidence != null))
                .ForMember(m => m.RegistrationAddress, e => e.Condition(c => c.PermanentResidence != null))
                .ForMember(m => m.EmployerAddress, e => e.Condition(c => c.PatientEmployer != null))

                .ForMember(p => p.CurrentResidenceAddress, e => e.MapFrom(c => c.PatientCurrentResidence))
                .ForMember(p => p.RegistrationAddress, e => e.MapFrom(c => c.PermanentResidence))
                .ForMember(p => p.EmployerAddress, e => e.MapFrom(c => c.PatientEmployer))
                .ForMember(p => p.intPatientAgeFromCase, e => e.MapFrom(c => c.Age))
                .ForMember(p => p.datDateofBirth, e => e.MapFrom(c => c.DateOfBirth))
                .ForMember(p => p.strFirstName, e => e.MapFrom(c => c.PatientFirstName))
                .ForMember(p => p.strSecondName, e => e.MapFrom(c => c.PatientMiddleName))
                .ForMember(p => p.strLastName, e => e.MapFrom(c => c.PatientLastName))
                .ForMember(p => p.strHomePhone, e => e.MapFrom(c => c.PatientPhoneNumber))
                .ForMember(p => p.strRegistrationPhone, e => e.MapFrom(c => c.PermanentResidencePhoneNumber))
                .ForMember(p => p.Gender, e => e.MapFrom(c => c.Sex))
                .ForMember(p => p.PersonIDType, e => e.MapFrom(c => c.PatientPersonalIDType))
                .ForMember(p => p.Nationality, e => e.MapFrom(c => c.NationalityCitizenship))
                .ForMember(p => p.strPersonID, e => e.MapFrom(c => c.PersonalID))
                .ForMember(p => p.HumanAgeType, e => e.MapFrom(c => c.AgeType))
                .ForMember(p => p.datDateOfDeath, e => e.MapFrom(c => c.DateOfDeath))
                .ForMember(p => p.strEmployerName, e => e.MapFrom(c => c.EmployerName))
                .ForMember(p => p.strWorkPhone, e => e.MapFrom(c => c.EmployerPhoneNumber))

                .ForMember(p => p.idfHuman, e => e.Ignore())
                .ForMember(p => p.idfRootHuman, e => e.Ignore())
                .ForMember(p => p.idfCase, e => e.Ignore())
                .ForMember(p => p.idfsHumanAgeTypeFromCase, e => e.Ignore())
                .ForMember(p => p.idfsOccupationType, e => e.Ignore())
                .ForMember(p => p.idfsNationality, e => e.Ignore())
                .ForMember(p => p.idfsHumanGender, e => e.Ignore())
                .ForMember(p => p.idfCurrentResidenceAddress, e => e.Ignore())
                .ForMember(p => p.idfEmployerAddress, e => e.Ignore())
                .ForMember(p => p.idfRegistrationAddress, e => e.Ignore())
                .ForMember(p => p.OccupationType, e => e.Ignore())
                .ForMember(p => p.OccupationTypeLookup, e => e.Ignore())
                .ForMember(p => p.NationalityLookup, e => e.Ignore())
                .ForMember(p => p.GenderLookup, e => e.Ignore())
                .ForMember(p => p.HumanAgeTypeLookup, e => e.Ignore())
                .ForMember(p => p.idfsPersonIDType, e => e.Ignore())
                .ForMember(p => p.strPersonID, e => e.Ignore())
                .ForMember(p => p.datEnteredDate, e => e.Ignore())
                .ForMember(p => p.datModificationDate, e => e.Ignore())
                .ForMember(p => p.PersonIDType, e => e.Ignore())
                .ForMember(p => p.PersonIDTypeLookup, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())

                /*.ForAllMembers(e => e.Condition(context =>
                        context.MemberName == "CurrentResidenceAddress" || context.MemberName == "RegistrationAddress" || context.MemberName == "EmployerAddress" 
                        ? context.SourceValue != null
                        : AutoConverter.CheckReadOnly<eidss.model.Schema.Patient>(context)
                    ))*/
                ;
            Mapper.CreateMap<eidss.model.Schema.Patient, eidss.openapi.contract.Patient>()
                .ForMember(p => p.RecordID, e => e.MapFrom(c => c.idfHuman))
                .ForMember(p => p.RootRecordID, e => e.MapFrom(c => c.idfRootHuman))
                .ForMember(p => p.PatientFirstName, e => e.MapFrom(c => c.strFirstName))
                .ForMember(p => p.PatientMiddleName, e => e.MapFrom(c => c.strSecondName))
                .ForMember(p => p.PatientLastName, e => e.MapFrom(c => c.strLastName))
                .ForMember(p => p.PatientCurrentResidence, e => e.MapFrom(c => c.CurrentResidenceAddress))
                .ForMember(p => p.PatientEmployer, e => e.MapFrom(c => c.EmployerAddress))
                .ForMember(p => p.PermanentResidence, e => e.MapFrom(c => c.RegistrationAddress))
                .ForMember(p => p.PatientPhoneNumber, e => e.MapFrom(c => c.strHomePhone))
                .ForMember(p => p.PermanentResidencePhoneNumber, e => e.MapFrom(c => c.strRegistrationPhone))
                .ForMember(p => p.Sex, e => e.MapFrom(c => c.Gender))
                .ForMember(p => p.PatientPersonalIDType, e => e.MapFrom(c => c.PersonIDType))
                .ForMember(p => p.NationalityCitizenship, e => e.MapFrom(c => c.Nationality))
                .ForMember(p => p.PersonalID, e => e.MapFrom(c => c.strPersonID))
                .ForMember(p => p.Age, e => e.MapFrom(c => c.intPatientAgeFromCase))
                .ForMember(p => p.AgeType, e => e.MapFrom(c => c.HumanAgeType))
                .ForMember(p => p.DateOfBirth, e => e.MapFrom(c => c.datDateofBirth))
                .ForMember(p => p.DateOfDeath, e => e.MapFrom(c => c.datDateOfDeath))
                .ForMember(p => p.EmployerName, e => e.MapFrom(c => c.strEmployerName))
                .ForMember(p => p.EmployerPhoneNumber, e => e.MapFrom(c => c.strWorkPhone))
                ;
        }

    }
}