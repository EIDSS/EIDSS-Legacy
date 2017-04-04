using System;
using System.Collections.Generic;
using System.Linq;
using bv.tests.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Enums;
using eidss.openapi.bll.Bll;
using eidss.openapi.contract;
using eidss.openapi.bll.Converters;

namespace bv.tests.openapi
{
    [TestClass]
    public class OpenApiVetCaseTest : EidssEnvWithLogin
    {

        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }


        [TestMethod]
        public void OpenApiTestVetCaseGeneral()
        {
            var vcin = new VetCase();
            vcin.TentativeDiagnosis1 = new Diagnosis()
            {
                RecordID = ReferenceBll.GetDignosisList().Last(c => !c.Aggregate && (c.AccessoryCode & (int)HACode.Livestock) != 0).RecordID
            };
            vcin.Farm = new Farm()
            {
                Name = "Farm Name",
                Address = new Address()
                {
                    Country = new GisReference() { RecordID = 780000000 },
                    Region = new GisReference() { RecordID = ReferenceBll.GetRegionList(780000000).First().RecordID },
                }
            };
            vcin.Farm.Address.Rayon = new GisReference()
            {
                RecordID = ReferenceBll.GetRayonList(vcin.Farm.Address.Region.RecordID).First().RecordID
            };

            vcin.CaseType = new Reference()
            {
                RecordID = ReferenceBll.GetList(19000012).Single(c => c.RecordID == 10012003).RecordID // Livestock
            };
            vcin.ReportType = new Reference()
            {
                RecordID = ReferenceBll.GetList(19000144).Single(c => c.RecordID == 4578940000002).RecordID // Passive
            };


            var vcout = VetCaseBll.Create(vcin);

            var vcfnd = VetCaseBll.Select(vcout.RecordID);
            
            Assert.IsNotNull(vcfnd.Samples);
            Assert.AreEqual(0, vcfnd.Samples.Count);
            /*
            var smp = VetCaseSampleBll.Create(vcfnd.idfCase, new Sample()
            {
                SampleType = new Reference()
                {
                    id = ReferenceBll.GetSampleTypeForDiagnosisList((int)HACode.Livestock, 0).Last().id
                }
            });

            vcfnd = VetCaseBll.Select(vcout.idfCase);
            Assert.IsNotNull(vcfnd.Samples);
            Assert.AreEqual(1, vcfnd.Samples.Count);
            Assert.IsNotNull(vcfnd.Samples[0].idfMaterial);
            Assert.AreEqual(smp.idfMaterial, vcfnd.Samples[0].idfMaterial.Value);

            VetCaseSampleBll.Delete(vcfnd.idfCase, vcfnd.Samples[0].idfMaterial.Value);

            vcfnd = VetCaseBll.Select(vcout.idfCase);
            Assert.IsNotNull(vcfnd.Samples);
            Assert.AreEqual(0, vcfnd.Samples.Count);
            */

            var list = VetCaseBll.Select(new VetCaseListFilter());
            Assert.IsTrue(list.Count >= 1);

            list = VetCaseBll.Select(new VetCaseListFilter() { CaseID = vcout.CaseID });
            Assert.IsTrue(list.Count == 1);
            /*
            list = VetCaseBll.Select(new VetCaseListFilter() { idfsDiagnosis = 100 });
            Assert.IsTrue(list.Count == 0);

            list = VetCaseBll.Select(new VetCaseListFilter() { idfsDiagnosis = vcout.TentativeDiagnosis.id });
            Assert.IsTrue(list.Count >= 1);
            */
            list = VetCaseBll.Select(new VetCaseListFilter() { EnteredDateFrom = DateTime.Now, EnteredDateTo = DateTime.Now.AddDays(1) });
            Assert.IsTrue(list.Count >= 1);

            list = VetCaseBll.Select(new VetCaseListFilter() { EnteredDateFrom = DateTime.Now.AddDays(1), EnteredDateTo = DateTime.Now.AddDays(2) });
            Assert.IsTrue(list.Count == 0);
        }
    }
}
