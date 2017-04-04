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
    public class OpenApiHumanCaseTest : EidssEnvWithLogin
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
        public void OpenApiTestHumanCaseGeneral()
        {
            var hcin = new HumanCase();
            hcin.Diagnosis = new Diagnosis()
                {
                    RecordID = ReferenceBll.GetDignosisList().Last(c => !c.Aggregate && (c.AccessoryCode & (int)HACode.Human) != 0).RecordID
                };
            hcin.Patient = new Patient()
                {
                    PatientLastName = "last",
                    PatientCurrentResidence = new Address()
                        {
                            Country = new GisReference() { RecordID = 780000000 },
                            Region = new GisReference() { RecordID = ReferenceBll.GetRegionList(780000000).First().RecordID },
                        }
                };
            hcin.Patient.PatientCurrentResidence.Rayon = new GisReference()
                {
                    RecordID = ReferenceBll.GetRayonList(hcin.Patient.PatientCurrentResidence.Region.RecordID).First().RecordID
                };

            hcin.SamplesCollected = new Reference()
                {
                    RecordID = ReferenceBll.GetList(19000100).Single(c => c.RecordID == 10100001).RecordID
                };

            //hcin.strCaseID = "QQQ";

            /*hcin.Samples = new List<Sample>();
            hcin.Samples.Add(new Sample()
                {
                    SampleType = new Reference()
                        {
                            id = ReferenceBll.GetSampleTypeForDiagnosisList((int)HACode.Human, 0).Last().id
                        }
                });
            */
            var hcout = HumanCaseBll.Create(hcin);

            var hcfnd = HumanCaseBll.Select(hcout.RecordID);
            Assert.IsNotNull(hcfnd.Samples);
            Assert.AreEqual(0, hcfnd.Samples.Count);

            var smp = HumanCaseSampleBll.Create(hcfnd.RecordID, new Sample()
            {
                SampleType = new Reference()
                {
                    RecordID = ReferenceBll.GetSampleTypeForDiagnosisList((int)HACode.Human, 0).Last().RecordID
                }
            });

            hcfnd = HumanCaseBll.Select(hcout.RecordID);
            Assert.IsNotNull(hcfnd.Samples);
            Assert.AreEqual(1, hcfnd.Samples.Count);
            Assert.IsNotNull(hcfnd.Samples[0].RecordID);
            Assert.AreEqual(smp.RecordID, hcfnd.Samples[0].RecordID);

            HumanCaseSampleBll.Delete(hcfnd.RecordID, hcfnd.Samples[0].RecordID);

            hcfnd = HumanCaseBll.Select(hcout.RecordID);
            Assert.IsNotNull(hcfnd.Samples);
            Assert.AreEqual(0, hcfnd.Samples.Count);


            var list = HumanCaseBll.Select(new HumanCaseListFilter());
            Assert.IsTrue(list.Count >= 1);

            list = HumanCaseBll.Select(new HumanCaseListFilter() { CaseID = hcout.CaseID });
            Assert.IsTrue(list.Count == 1);

            list = HumanCaseBll.Select(new HumanCaseListFilter() { Diagnosis = 100 });
            Assert.IsTrue(list.Count == 0);

            list = HumanCaseBll.Select(new HumanCaseListFilter() { Diagnosis = hcout.Diagnosis.RecordID });
            Assert.IsTrue(list.Count >= 1);

            list = HumanCaseBll.Select(new HumanCaseListFilter() { DateEnteredFrom = DateTime.Now.AddMinutes(-1), DateEnteredTo = DateTime.Now.AddDays(1) });
            Assert.IsTrue(list.Count >= 1);

            list = HumanCaseBll.Select(new HumanCaseListFilter() { DateEnteredFrom = DateTime.Now.AddDays(1), DateEnteredTo = DateTime.Now.AddDays(2) });
            Assert.IsTrue(list.Count == 0);
        }

        [TestMethod]
        public void OpenApiTestPatientList()
        {
            var list = PatientBll.Select(new PatientListFilter());
            Assert.IsTrue(list.Count >= 0);

            list = PatientBll.Select(new PatientListFilter() { RecordID = -1 });
            Assert.IsTrue(list.Count == 0);
        }


    }
}
