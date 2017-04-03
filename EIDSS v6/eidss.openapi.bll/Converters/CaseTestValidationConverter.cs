using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Schema;
using eidss.openapi.contract;
using eidss.openapi.bll.Exceptions;
using bv.model.Helpers;

namespace eidss.openapi.bll.Converters
{

    internal class CaseTestValidationConverter :
        BaseConverter<eidss.openapi.contract.TestInterpretation, eidss.model.Schema.CaseTestValidation>
    {
        private static CaseTestValidationConverter _instance = new CaseTestValidationConverter();
        private CaseTestValidationConverter() { AutoConverter.Nop(); }
        public static CaseTestValidationConverter Instance { get { return _instance; } }


        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.TestInterpretation, eidss.model.Schema.CaseTestValidation>()
                .ConstructUsing(context =>
                    {
                        var source = context.SourceValue as eidss.openapi.contract.Test;
                        var hc = context.Parent.Parent.DestinationValue as eidss.model.Schema.HumanCase;
                        var vc = context.Parent.Parent.DestinationValue as eidss.model.Schema.VetCase;
                        var o = hc != null 
                            ? hc.CaseTestValidations.SingleOrDefault(i => i.idfTestValidation == source.RecordID)
                            : vc.CaseTestValidations.SingleOrDefault(i => i.idfTestValidation == source.RecordID);
                        if (o == null)
                        {
                            if (source.RecordID == 0)
                            {
                                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                                {
                                    o = eidss.model.Schema.CaseTestValidation.Accessor.Instance(null).CreateNewT(manager, hc as IObject ?? vc);
                                }
                            }
                            else
                            {
                                throw new ObjectNotFoundException(source.RecordID);
                            }
                        }
                        return o;
                    })
                .ForMember(c => c.idfTestValidation, e => e.MapFrom(m => m.RecordID))
                .ForMember(c => c.idfTesting, e => e.MapFrom(m => m.TestRecordID))
                .ForMember(c => c.RuleInOut, e => e.MapFrom(m => m.RuleInRuleOut))
                .ForMember(c => c.idfInterpretedByPerson, e => e.ResolveUsing(m =>
                    {
                        using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                            return m.InterpretedBy == null || m.InterpretedBy.RecordID <= 0 
                            ? new long?()
                            : eidss.model.Schema.WiderPersonLookup.Accessor.Instance(null)
                               .SelectLookupList(manager, null, null, true, null).SingleOrDefault(i => i.idfPerson == m.InterpretedBy.RecordID, i => i.idfPerson);
                    }))
                .ForMember(c => c.idfValidatedByPerson, e => e.ResolveUsing(m =>
                    {
                        using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                            return m.ValidateBy == null || m.ValidateBy.RecordID <= 0
                            ? new long?()
                            : eidss.model.Schema.WiderPersonLookup.Accessor.Instance(null)
                               .SelectLookupList(manager, null, null, true, null).SingleOrDefault(i => i.idfPerson == m.ValidateBy.RecordID, i => i.idfPerson);
                    }))
                .ForMember(c => c.strInterpretedComment, e => e.MapFrom(m => m.RuleInRuleOutComments))
                .ForMember(c => c.strValidateComment, e => e.MapFrom(m => m.ValidationComments))
                .ForMember(c => c.datInterpretationDate, e => e.MapFrom(m => m.InterpretationDate))
                .ForMember(c => c.datValidationDate, e => e.MapFrom(m => m.ValidationDate))
                .ForMember(c => c.blnValidateStatus, e => e.MapFrom(m => m.Validated))


                // ignore
                .ForMember(p => p.TestName, e => e.Ignore())
                .ForMember(p => p.TestType, e => e.Ignore())
                .ForMember(p => p.RuleInOutName, e => e.Ignore())
                .ForMember(p => p.ValidatedName, e => e.Ignore())
                .ForMember(p => p.InterpretedName, e => e.Ignore())
                .ForMember(p => p.idfsInterpretedStatus, e => e.Ignore())
                .ForMember(p => p.idfCase, e => e.Ignore())
                .ForMember(p => p.Diagnosis, e => e.Ignore())
                .ForMember(p => p.RuleInOutLookup, e => e.Ignore())
                .ForMember(p => p.idfsDiagnosis, e => e.Ignore())
                .ForMember(p => p.DiagnosisLookup, e => e.Ignore())
                .ForMember(p => p.DiagnosisName, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                .ForAllMembers(e => e.Condition(AutoConverter.CheckReadOnly<eidss.model.Schema.CaseTestValidation>))
                ;
            Mapper.CreateMap<eidss.model.Schema.CaseTestValidation, eidss.openapi.contract.TestInterpretation>()
                .ForMember(c => c.RecordID, e => e.MapFrom(m => m.idfTestValidation))
                .ForMember(c => c.TestRecordID, e => e.MapFrom(m => m.idfTesting))
                .ForMember(c => c.RuleInRuleOut, e => e.MapFrom(m => m.RuleInOut))
                .ForMember(c => c.InterpretedBy, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.WiderPersonLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, null, null, true, null).SingleOrDefault(i => i.idfPerson == m.idfInterpretedByPerson);
                }))
                .ForMember(c => c.ValidateBy, e => e.ResolveUsing(m =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        return eidss.model.Schema.WiderPersonLookup.Accessor.Instance(null)
                           .SelectLookupList(manager, null, null, true, null).SingleOrDefault(i => i.idfPerson == m.idfValidatedByPerson);
                }))
                .ForMember(c => c.RuleInRuleOutComments, e => e.MapFrom(m => m.strInterpretedComment))
                .ForMember(c => c.ValidationComments, e => e.MapFrom(m => m.strValidateComment))
                .ForMember(c => c.InterpretationDate, e => e.MapFrom(m => m.datInterpretationDate))
                .ForMember(c => c.ValidationDate, e => e.MapFrom(m => m.datValidationDate))
                .ForMember(c => c.Validated, e => e.MapFrom(m => m.blnValidateStatus))
                ;
        }

    }
}