using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.Core;
using eidss.model.Schema;
using eidss.model.Enums;

namespace bv.tests.db.tests
{
    [TestClass]
    public class OutbreakTest : EidssEnvWithLogin
    {
        private Outbreak.Accessor m_Acc;

        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
            m_Acc = Outbreak.Accessor.Instance(null);
            
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            m_Acc = null;
            base.TestCleanup();
        }


        [TestMethod]
        public void OutbreakCreating()
        {
            var acc = HumanCase.Accessor.Instance(null);
            var hc = acc.CreateNewT(manager, null);
            // mandatory for posting
            hc.Patient.strLastName = "last";
            hc.Patient.strFirstName = "first";
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.SingleOrDefault(c => c.strCountryName == "Georgia");
            hc.Patient.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.SingleOrDefault(c => c.strRegionName == "Abkhazia");
            hc.Patient.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.SingleOrDefault(c => c.strRayonName == "Gagra");
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();
            Assert.IsTrue(acc.Post(manager, hc));

            var outbreak = m_Acc.CreateNewT(manager, null);
            Assert.IsNotNull(outbreak);
            long id = outbreak.idfOutbreak;
            Assert.AreNotEqual(0, outbreak.idfOutbreak);
            Assert.AreEqual(String.Empty, outbreak.strOutbreakID);
            outbreak.Diagnosis = outbreak.DiagnosisLookup.SingleOrDefault(a => a.name == "Anthrax - Cutaneous");
            outbreak.Cases.Add(OutbreakCase.Accessor.Instance(null).Create(manager, outbreak, hc.idfCase));
            Assert.AreEqual("Anthrax - Cutaneous", outbreak.Cases[0].strDiagnosis);
            Assert.AreEqual(hc.strCaseID, outbreak.Cases[0].strCaseID);
            Assert.AreEqual("Georgia, Abkhazia, Gagra", outbreak.Cases[0].strAddress);
            Assert.AreEqual("last first", outbreak.Cases[0].strPatientName);
            Outbreak.Accessor.Instance(null).SetPrimaryCase(manager, outbreak, outbreak.Cases[0]);
            Assert.AreEqual(hc.idfCase, outbreak.idfPrimaryCaseOrSession);

            outbreak.Notes.Add(OutbreakNote.Accessor.Instance(null).CreateNewT(manager, outbreak));
            outbreak.Notes[0].strNote = "note";

            outbreak.Location.Country = outbreak.Location.CountryLookup.SingleOrDefault(c => c.strCountryName == "Georgia");
            outbreak.Location.Region = outbreak.Location.RegionLookup.SingleOrDefault(c => c.strRegionName == "Abkhazia");
            outbreak.Location.Rayon = outbreak.Location.RayonLookup.SingleOrDefault(c => c.strRayonName == "Gagra");
            outbreak.Location.Settlement = outbreak.Location.SettlementLookup.SingleOrDefault(c => c.strSettlementName == "Achmarda");

            Assert.IsTrue(m_Acc.Post(manager, outbreak));

            outbreak = m_Acc.SelectByKey(manager, id);
            Assert.IsNotNull(outbreak);
            Assert.AreNotEqual(String.Empty, outbreak.strOutbreakID);
            Assert.IsNotNull(outbreak.Cases);
            Assert.AreEqual(1, outbreak.Cases.Count);
            Assert.AreEqual("Anthrax - Cutaneous", outbreak.Cases[0].strDiagnosis);
            Assert.AreEqual(hc.strCaseID, outbreak.Cases[0].strCaseID);
            Assert.AreEqual("Georgia, Abkhazia, Gagra", outbreak.Cases[0].strAddress);
            Assert.AreEqual("last first", outbreak.Cases[0].strPatientName);
            Assert.IsNotNull(outbreak.Notes);
            Assert.AreEqual(1, outbreak.Notes.Count);
            Assert.AreEqual("note", outbreak.Notes[0].strNote);
            Assert.AreEqual(hc.idfCase, outbreak.idfPrimaryCaseOrSession);

        }
    }
}
