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

namespace eidss.openapi.bll.Converters
{
    internal class CaseTestConverter :
        BaseConverter<eidss.openapi.contract.Test, eidss.model.Schema.CaseTest>
    {
        private static CaseTestConverter _instance = new CaseTestConverter();
        private CaseTestConverter() { AutoConverter.Nop(); }
        public static CaseTestConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.Test, eidss.model.Schema.CaseTest>()
                .ConstructUsing(context =>
                    {
                        var source = context.SourceValue as eidss.openapi.contract.Test;
                        var hc = context.Parent.Parent.DestinationValue as eidss.model.Schema.HumanCase;
                        var vc = context.Parent.Parent.DestinationValue as eidss.model.Schema.VetCase;
                        var o = hc != null 
                            ? hc.CaseTests.SingleOrDefault(i => i.idfTesting == source.RecordID)
                            : vc.CaseTests.SingleOrDefault(i => i.idfTesting == source.RecordID);
                        if (o == null)
                        {
                            if (source.RecordID == 0)
                            {
                                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                                {
                                    o = eidss.model.Schema.CaseTest.Accessor.Instance(null).CreateNewT(manager, hc as IObject ?? vc);
                                }
                            }
                            else
                            {
                                throw new ObjectNotFoundException(source.RecordID);
                            }
                        }
                        return o;
                    })
                .ForMember(c => c.idfTesting, e => e.MapFrom(m => m.RecordID))
                .ForMember(c => c.idfMaterial, e => e.MapFrom(m => m.SampleRecordID))
                .ForMember(c => c.TestNameRef, e => e.MapFrom(m => m.TestName))
                .ForMember(c => c.TestStatusRef, e => e.MapFrom(m => m.TestStatus))
                .ForMember(c => c.TestResultRef, e => e.MapFrom(m => m.TestResult))
                .ForMember(c => c.TestCategory, e => e.MapFrom(m => m.TestCategory))
                .ForMember(c => c.Diagnosis, e => e.MapFrom(m => m.Diagnosis))
                .ForMember(c => c.strBatchCode, e => e.MapFrom(m => m.TestRunID))
                .ForMember(c => c.datConcludedDate, e => e.MapFrom(m => m.ResultDate))


                // ignore
                .ForMember(p => p.strBarcode, e => e.Ignore())
                .ForMember(p => p.strFieldBarcode, e => e.Ignore())
                .ForMember(p => p.datFieldCollectionDate, e => e.Ignore())
                .ForMember(p => p.datPerformedDate, e => e.Ignore())
                .ForMember(p => p.datValidatedDate, e => e.Ignore())
                .ForMember(p => p.datStartedDate, e => e.Ignore())
                .ForMember(p => p.idfCase, e => e.Ignore())
                .ForMember(p => p.strNote, e => e.Ignore())
                .ForMember(p => p.datReceivedDate, e => e.Ignore())
                .ForMember(p => p.idfObservation, e => e.Ignore())
                .ForMember(p => p.idfsFormTemplate, e => e.Ignore())
                .ForMember(p => p.idfsTestStatus, e => e.Ignore())
                .ForMember(p => p.idfsTestResult, e => e.Ignore())
                .ForMember(p => p.idfsTestCategory, e => e.Ignore())
                .ForMember(p => p.strFieldBarcode2, e => e.Ignore())
                .ForMember(p => p.strSampleName, e => e.Ignore())
                .ForMember(p => p.idfsTestName, e => e.Ignore())
                .ForMember(p => p.strBatchCode, e => e.Ignore())
                .ForMember(p => p.DepartmentName, e => e.Ignore())
                .ForMember(p => p.AnimalName, e => e.Ignore())
                .ForMember(p => p.strFarmCode, e => e.Ignore())
                .ForMember(p => p.idfsDiagnosis, e => e.Ignore())
                .ForMember(p => p.datAccession, e => e.Ignore())
                .ForMember(p => p.blnNonLaboratoryTest, e => e.Ignore())
                .ForMember(p => p.blnReadOnly, e => e.Ignore())
                .ForMember(p => p.idfTestedByOffice, e => e.Ignore())
                .ForMember(p => p.idfTestedByPerson, e => e.Ignore())
                .ForMember(p => p.idfResultEnteredByOffice, e => e.Ignore())
                .ForMember(p => p.idfResultEnteredByPerson, e => e.Ignore())
                .ForMember(p => p.idfValidatedByOffice, e => e.Ignore())
                .ForMember(p => p.idfValidatedByPerson, e => e.Ignore())
                .ForMember(p => p.idfMaterialHuman, e => e.Ignore())
                .ForMember(p => p.idfMaterialVet, e => e.Ignore())
                .ForMember(p => p.idfMaterialAsSession, e => e.Ignore())
                .ForMember(p => p.intHasAmendment, e => e.Ignore())
                .ForMember(p => p.blnExternalTest, e => e.Ignore())
                .ForMember(p => p.idfPerformedByOffice, e => e.Ignore())
                .ForMember(p => p.strContactPerson, e => e.Ignore())
                .ForMember(p => p.blnIsMainSampleTest, e => e.Ignore())
                .ForMember(p => p.FFPresenter, e => e.Ignore())
                .ForMember(p => p.TestNameRefLookup, e => e.Ignore())
                .ForMember(p => p.TestResultRefLookup, e => e.Ignore())
                .ForMember(p => p.TestCategoryLookup, e => e.Ignore())
                .ForMember(p => p.TestStatusRefLookup, e => e.Ignore())
                .ForMember(p => p.HumanCaseSample, e => e.Ignore())
                .ForMember(p => p.HumanCaseSampleLookup, e => e.Ignore())
                .ForMember(p => p.VetCaseSample, e => e.Ignore())
                .ForMember(p => p.VetCaseSampleLookup, e => e.Ignore())
                .ForMember(p => p.AsSessionSample, e => e.Ignore())
                .ForMember(p => p.AsSessionSampleLookup, e => e.Ignore())
                .ForMember(p => p.DiagnosisLookup, e => e.Ignore())
                .ForMember(p => p.PerformedByOffice, e => e.Ignore())
                .ForMember(p => p.PerformedByOfficeLookup, e => e.Ignore())
                .ForMember(p => p.AsSessionSamples, e => e.Ignore())
                .ForMember(p => p.HumanCaseSamples, e => e.Ignore())
                .ForMember(p => p.VetCaseSamples, e => e.Ignore())
                .ForMember(p => p.CaseTestValidations, e => e.Ignore())
                .ForMember(p => p.CaseDiagnosis, e => e.Ignore())
                .ForMember(p => p.AsSessionDiseases, e => e.Ignore())
                .ForMember(p => p.strPerformedByOffice, e => e.Ignore())
                .ForMember(p => p.DiagnosisName, e => e.Ignore())
                .ForMember(p => p.Species, e => e.Ignore())
                .ForMember(p => p.idfFarm, e => e.Ignore())
                .ForMember(p => p.AmendmentHistory, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                .ForAllMembers(e => e.Condition(AutoConverter.CheckReadOnly<eidss.model.Schema.CaseTest>))
                ;
            Mapper.CreateMap<eidss.model.Schema.CaseTest, eidss.openapi.contract.Test>()
                .ForMember(c => c.RecordID, e => e.MapFrom(m => m.idfTesting))
                .ForMember(c => c.SampleRecordID, e => e.MapFrom(m => m.idfMaterial))
                .ForMember(c => c.TestName, e => e.MapFrom(m => m.TestNameRef))
                .ForMember(c => c.TestResult, e => e.MapFrom(m => m.TestResultRef))
                .ForMember(c => c.TestStatus, e => e.MapFrom(m => m.TestStatusRef))
                .ForMember(c => c.TestCategory, e => e.MapFrom(m => m.TestCategory))
                .ForMember(c => c.Diagnosis, e => e.MapFrom(m => m.Diagnosis))
                .ForMember(c => c.TestRunID, e => e.MapFrom(m => m.strBatchCode))
                .ForMember(c => c.ResultDate, e => e.MapFrom(m => m.datConcludedDate))
                ;
        }

    }
}