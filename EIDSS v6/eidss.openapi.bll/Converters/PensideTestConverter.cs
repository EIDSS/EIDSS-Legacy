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
    internal class PensideTestConverter :
        BaseConverter<eidss.openapi.contract.PensideTest, eidss.model.Schema.PensideTest>
    {
        private static PensideTestConverter _instance = new PensideTestConverter();
        private PensideTestConverter() { AutoConverter.Nop(); }
        public static PensideTestConverter Instance { get { return _instance; } }

        internal static void Register()
        {
            Mapper.CreateMap<eidss.openapi.contract.PensideTest, eidss.model.Schema.PensideTest>()
                .ConstructUsing(context =>
                    {
                        var source = context.SourceValue as eidss.openapi.contract.PensideTest;
                        var vc = context.Parent.Parent.DestinationValue as eidss.model.Schema.VetCase;
                        var o = vc.PensideTests.SingleOrDefault(i => i.idfPensideTest == source.RecordID);
                        if (o == null)
                        {
                            if (source.RecordID == 0)
                            {
                                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                                {
                                    o = eidss.model.Schema.PensideTest.Accessor.Instance(null).CreateNewT(manager, vc);
                                }
                            }
                            else
                            {
                                throw new ObjectNotFoundException(source.RecordID);
                            }
                        }
                        return o;
                    })
                .ForMember(c => c.idfPensideTest, e => e.MapFrom(m => m.RecordID))
                .ForMember(c => c.idfMaterial, e => e.MapFrom(m => m.SampleRecordID))
                .ForMember(c => c.idfParty, e => e.MapFrom(m => m.AnimalRecordID))
                .ForMember(c => c.PensideTestType, e => e.MapFrom(m => m.PensideTestName))
                .ForMember(c => c.PensideTestResult, e => e.MapFrom(m => m.PensideTestResult))
                .ForMember(c => c.strFieldBarcode, e => e.MapFrom(m => m.FieldSampleID))


                // ignore
                .ForMember(p => p.idfVetCase, e => e.Ignore())
                .ForMember(p => p.idfsPensideTestResult, e => e.Ignore())
                .ForMember(p => p.strPensideTestResultName, e => e.Ignore())
                .ForMember(p => p.idfsPensideTestName, e => e.Ignore())
                .ForMember(p => p.strPensideTestName, e => e.Ignore())
                .ForMember(p => p.idfVectorSurveillanceSession, e => e.Ignore())
                .ForMember(p => p.idfVector, e => e.Ignore())
                .ForMember(p => p.datTestDate, e => e.Ignore())
                .ForMember(p => p.strAnimal, e => e.Ignore())
                .ForMember(p => p.Species, e => e.Ignore())
                .ForMember(p => p.strDummy, e => e.Ignore())
                .ForMember(p => p.PensideTestResultLookup, e => e.Ignore())
                .ForMember(p => p.PensideTestTypeLookup, e => e.Ignore())
                .ForMember(p => p.Samples, e => e.Ignore())
                .ForMember(p => p.SamplesLookup, e => e.Ignore())
                .ForMember(p => p.SamplesFromCase, e => e.Ignore())
                .ForMember(p => p._HACode, e => e.Ignore())
                .ForMember(p => p.strBarcode, e => e.Ignore())
                .ForMember(p => p.strFieldBarcode, e => e.Ignore())
                .ForMember(p => p.datFieldCollectionDate, e => e.Ignore())
                .ForMember(p => p.strSampleName, e => e.Ignore())
                .ForMember(p => p.Parent, e => e.Ignore())
                .ForMember(p => p.ReadOnly, e => e.Ignore())
                .ForMember(p => p.NotifyChanges, e => e.Ignore())
                .ForMember(p => p.Environment, e => e.Ignore())
                .ForAllMembers(e => e.Condition(AutoConverter.CheckReadOnly<eidss.model.Schema.PensideTest>))
                ;
            Mapper.CreateMap<eidss.model.Schema.PensideTest, eidss.openapi.contract.PensideTest>()
                .ForMember(c => c.RecordID, e => e.MapFrom(m => m.idfPensideTest))
                .ForMember(c => c.SampleRecordID, e => e.MapFrom(m => m.idfMaterial))
                .ForMember(c => c.AnimalRecordID, e => e.MapFrom(m => m.idfParty))
                .ForMember(c => c.PensideTestName, e => e.MapFrom(m => m.PensideTestType))
                .ForMember(c => c.PensideTestResult, e => e.MapFrom(m => m.PensideTestResult))
                .ForMember(c => c.FieldSampleID, e => e.MapFrom(m => m.strFieldBarcode))
                ;
        }

    }
}