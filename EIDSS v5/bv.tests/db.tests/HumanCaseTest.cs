using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.tests.Core;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Enums;
using eidss.model.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Model.FlexibleForms.Helpers;

namespace bv.tests.db.tests
{
    [TestClass]
    public class HumanCaseTest : EidssEnvWithLogin
    {
        private HumanCase.Accessor acc;
        private HumanCase hc;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            acc = HumanCase.Accessor.Instance(null);
            hc = acc.CreateNewT(manager, null);
            Assert.IsNotNull(hc);
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            acc = null;
            hc = null;
            base.TestCleanup();
        }

        [TestMethod]
        public void TestHumanCaseIsChangeDiagnosisReason()
        {
            Assert.IsNull(hc.idfsChangeDiagnosisReason);
            Assert.IsNull(hc.idfsTentativeDiagnosis);
            hc.TentativeDiagnosis = hc.TentativeDiagnosisLookup.Skip(1).First();
            Assert.IsNotNull(hc.idfsTentativeDiagnosis);
            Assert.IsNull(hc.idfsChangeDiagnosisReason);
            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Skip(1).First(x => x.idfsDiagnosis != hc.idfsTentativeDiagnosis);
            Assert.IsNotNull(hc.idfsFinalDiagnosis);
            Assert.IsNull(hc.idfsChangeDiagnosisReason);
            hc.idfsChangeDiagnosisReason = 1;
            Assert.IsNotNull(hc.idfsFinalDiagnosis);
            Assert.IsTrue(hc.isChangeDiagnosisReasonEnter);
            long idfsFinalDiagnosis = hc.idfsFinalDiagnosis.Value;
            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Skip(1).First(x => x.idfsDiagnosis != hc.idfsTentativeDiagnosis && x.idfsDiagnosis != idfsFinalDiagnosis);
            Assert.AreNotEqual(idfsFinalDiagnosis, hc.idfsFinalDiagnosis.Value);
            Assert.IsNotNull(hc.idfsChangeDiagnosisReason);
            Assert.IsTrue(hc.isChangeDiagnosisReasonEnter);
            long idfsTentativeDiagnosis = hc.idfsTentativeDiagnosis.Value;
            hc.TentativeDiagnosis = hc.TentativeDiagnosisLookup.Skip(1).First(x => x.idfsDiagnosis != idfsTentativeDiagnosis && x.idfsDiagnosis != hc.idfsFinalDiagnosis);
            Assert.AreNotEqual(idfsTentativeDiagnosis, hc.idfsTentativeDiagnosis.Value);
            Assert.IsNotNull(hc.idfsChangeDiagnosisReason);
            Assert.IsTrue(hc.isChangeDiagnosisReasonEnter);
        }

        [TestMethod]
        public void TestHumanCaseDates_DOB_CurD()
        {
            //1.	DOB≤CurD
            Assert.IsNull(hc.Patient.datDateofBirth);
            hc.Validation += hc_Validation_datDateofBirth_CurrentDate;
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(1);
            hc.Validation -= hc_Validation_datDateofBirth_CurrentDate;
            Assert.IsNull(hc.Patient.datDateofBirth);
            hc.Validation += hc_Validation_datDateofBirth_CurrentDate;
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-1).Date;
            hc.Validation -= hc_Validation_datDateofBirth_CurrentDate;
            Assert.AreEqual(hc.Patient.datDateofBirth, DateTime.Now.AddDays(-1).Date);
        }

        [TestMethod]
        public void TestHumanCaseDates_DOB_NSD()
        {
            //2.	DOB≤NSD
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-1);
            Assert.IsNull(hc.datNotificationDate);
            hc.Validation += hc_Validation_datDateofBirth_datNotificationDate;
            hc.datNotificationDate = DateTime.Now.AddDays(-2);
            hc.Validation -= hc_Validation_datDateofBirth_datNotificationDate;
            Assert.IsNull(hc.datNotificationDate);
            hc.Validation += hc_Validation_datDateofBirth_datNotificationDate;
            hc.datNotificationDate = DateTime.Now.Date;
            hc.Validation -= hc_Validation_datDateofBirth_datNotificationDate;
            Assert.AreEqual(hc.datNotificationDate, DateTime.Now.Date);
        }

        [TestMethod]
        public void TestHumanCaseDates_DOB_IDD()
        {
            //3.	DOB≤IDD
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-1);
            Assert.IsNull(hc.datTentativeDiagnosisDate);
            hc.Validation += hc_Validation_datDateofBirth_datTentativeDiagnosisDate;
            hc.datTentativeDiagnosisDate = DateTime.Now.AddDays(-2);
            hc.Validation -= hc_Validation_datDateofBirth_datTentativeDiagnosisDate;
            Assert.IsNull(hc.datTentativeDiagnosisDate);
            hc.Validation += hc_Validation_datDateofBirth_datTentativeDiagnosisDate;
            hc.datTentativeDiagnosisDate = DateTime.Now.Date;
            hc.Validation -= hc_Validation_datDateofBirth_datTentativeDiagnosisDate;
            Assert.AreEqual(hc.datTentativeDiagnosisDate, DateTime.Now.Date);
        }

        [TestMethod]
        public void TestHumanCaseDates_DOB_CDD()
        {
            //4.	DOB≤CDD
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-1);
            Assert.IsNull(hc.datFinalDiagnosisDate);
            hc.Validation += hc_Validation_datDateofBirth_datFinalDiagnosisDate;
            hc.datFinalDiagnosisDate = DateTime.Now.AddDays(-2);
            hc.Validation -= hc_Validation_datDateofBirth_datFinalDiagnosisDate;
            Assert.IsNull(hc.datFinalDiagnosisDate);
            hc.Validation += hc_Validation_datDateofBirth_datFinalDiagnosisDate;
            hc.datFinalDiagnosisDate = DateTime.Now.Date;
            hc.Validation -= hc_Validation_datDateofBirth_datFinalDiagnosisDate;
            Assert.AreEqual(hc.datFinalDiagnosisDate, DateTime.Now.Date);
        }

        [TestMethod]
        public void TestHumanCaseDates_DOB_ED()
        {
            //5.	DOB≤ED
            Assert.IsNotNull(hc.datEnteredDate);
            hc.datEnteredDate = hc.datEnteredDate.Value.AddDays(-2);
            hc.Validation += hc_Validation_datDateofBirth_datEnteredDate;
            hc.Patient.datDateofBirth = hc.datEnteredDate.Value.AddDays(1);
            hc.Validation -= hc_Validation_datDateofBirth_datEnteredDate;
            Assert.IsNull(hc.Patient.datDateofBirth);
            Assert.IsNotNull(hc.datEnteredDate);
            hc.Validation += hc_Validation_datDateofBirth_datEnteredDate;
            hc.Patient.datDateofBirth = hc.datEnteredDate.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datDateofBirth_datEnteredDate;
            Assert.AreEqual(hc.Patient.datDateofBirth, hc.datEnteredDate.Value.AddDays(-1));
        }

        [TestMethod]
        public void TestHumanCaseDates_DOB_ScolD()
        {
            hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
            hc.Samples[0].SampleType =
                hc.Samples[0].SampleTypeLookup.Where(c => c.name == "Food").FirstOrDefault();
            hc.Samples[0].datFieldCollectionDate = DateTime.Now.AddDays(-2);

            //6.	DOB≤ScolD
            Assert.IsNull(hc.Patient.datDateofBirth);
            hc.Validation += hc_Validation_datDateofBirth_datFieldCollectionDate;
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-1);
            hc.Validation -= hc_Validation_datDateofBirth_datFieldCollectionDate;
            Assert.IsNull(hc.Patient.datDateofBirth);
            hc.Samples[0].datFieldCollectionDate = null;
            Assert.IsNull(hc.Samples[0].datFieldCollectionDate);
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-3);
            hc.Validation += hc_Validation_datDateofBirth_datFieldCollectionDate;
            hc.Samples[0].datFieldCollectionDate = hc.Patient.datDateofBirth.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datDateofBirth_datFieldCollectionDate;
            Assert.IsNull(hc.Samples[0].datFieldCollectionDate);
            hc.Validation += hc_Validation_datDateofBirth_datFieldCollectionDate;
            hc.Samples[0].datFieldCollectionDate = hc.Patient.datDateofBirth.Value.AddDays(1);
            hc.Validation -= hc_Validation_datDateofBirth_datFieldCollectionDate;
            Assert.AreEqual(hc.Samples[0].datFieldCollectionDate, hc.Patient.datDateofBirth.Value.AddDays(1));
        }

        [TestMethod]
        public void TestHumanCaseDates_DOB_SSD()
        {
            hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
            hc.Samples[0].SampleType =
                hc.Samples[0].SampleTypeLookup.Where(c => c.name == "Food").FirstOrDefault();
            hc.Samples[0].datFieldCollectionDate = null;

            //7.	DOB≤SSD
            Assert.IsNull(hc.Patient.datDateofBirth);
            hc.Samples[0].datFieldSentDate = DateTime.Now.AddDays(-2);
            hc.Validation += hc_Validation_datDateofBirth_datFieldSentDate;
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-1);
            hc.Validation -= hc_Validation_datDateofBirth_datFieldSentDate;
            Assert.IsNull(hc.Patient.datDateofBirth);
            hc.Samples[0].datFieldSentDate = null;
            Assert.IsNull(hc.Samples[0].datFieldSentDate);
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-3);
            hc.Samples[0].datFieldCollectionDate = DateTime.Now.AddDays(-2);
            hc.Validation += hc_Validation_datDateofBirth_datFieldSentDate;
            hc.Samples[0].datFieldSentDate = hc.Patient.datDateofBirth.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datDateofBirth_datFieldSentDate;
            Assert.IsNull(hc.Samples[0].datFieldSentDate);
            hc.Validation += hc_Validation_datDateofBirth_datFieldSentDate;
            hc.Samples[0].datFieldSentDate = hc.Patient.datDateofBirth.Value.AddDays(2);
            hc.Validation -= hc_Validation_datDateofBirth_datFieldSentDate;
            Assert.AreEqual(hc.Samples[0].datFieldSentDate, hc.Patient.datDateofBirth.Value.AddDays(2));
        }

        [TestMethod]
        public void TestHumanCaseDates_DOB_SAD()
        {
            hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
            hc.Samples[0].SampleType =
                hc.Samples[0].SampleTypeLookup.Where(c => c.name == "Food").FirstOrDefault();
            hc.Samples[0].datFieldCollectionDate = null;

            //8.	DOB≤SAD
            Assert.IsNull(hc.Patient.datDateofBirth);
            hc.Samples[0].datFieldSentDate = null;
            hc.Samples[0].datAccession = DateTime.Now.AddDays(-2);
            hc.Validation += hc_Validation_datDateofBirth_datAccession;
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-1);
            hc.Validation -= hc_Validation_datDateofBirth_datAccession;
            Assert.IsNull(hc.Patient.datDateofBirth);
            hc.Samples[0].datAccession = null;
            Assert.IsNull(hc.Samples[0].datAccession);
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-3);
            hc.Samples[0].datFieldCollectionDate = DateTime.Now.AddDays(-1);
            hc.Validation += hc_Validation_datDateofBirth_datAccession;
            hc.Samples[0].datAccession = hc.Patient.datDateofBirth.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datDateofBirth_datAccession;
            Assert.IsNull(hc.Samples[0].datAccession);
            hc.Validation += hc_Validation_datDateofBirth_datAccession;
            hc.Samples[0].datAccession = hc.Patient.datDateofBirth.Value.AddDays(1);
            hc.Validation -= hc_Validation_datDateofBirth_datAccession;
            Assert.AreEqual(hc.Samples[0].datAccession, hc.Patient.datDateofBirth.Value.AddDays(1));
        }

        [TestMethod]
        public void TestHumanCaseDates_DOB_LVD()
        {
            //9.	DOB≤LVD
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-1);
            Assert.IsNull(hc.datFacilityLastVisit);
            hc.Validation += hc_Validation_datDateofBirth_datFacilityLastVisit;
            hc.datFacilityLastVisit = DateTime.Now.AddDays(-2);
            hc.Validation -= hc_Validation_datDateofBirth_datFacilityLastVisit;
            Assert.IsNull(hc.datFacilityLastVisit);
            hc.Validation += hc_Validation_datDateofBirth_datFacilityLastVisit;
            hc.datFacilityLastVisit = DateTime.Now.Date;
            hc.Validation -= hc_Validation_datDateofBirth_datFacilityLastVisit;
            Assert.AreEqual(hc.datFacilityLastVisit, DateTime.Now.Date);
        }

        //[TestMethod] obsolete validator
        //public void TestHumanCaseDates_ED_CurD()
        //{
        //    //10.	ED≤CurD
        //    Assert.IsNotNull(hc.datEnteredDate);
        //    DateTime datEnteredDate = hc.datEnteredDate.Value;
        //    hc.Validation += hc_Validation_datEnteredDate_CurrentDate;
        //    hc.datEnteredDate = hc.datEnteredDate.Value.AddDays(2);
        //    hc.Validation -= hc_Validation_datEnteredDate_CurrentDate;
        //    Assert.IsNotNull(hc.datEnteredDate);
        //    Assert.AreEqual(hc.datEnteredDate, datEnteredDate);
        //}

        [TestMethod]
        public void TestHumanCaseDates_NSD_ED()
        {
            //11.	NSD≤ED
            Assert.IsNotNull(hc.datEnteredDate);
            hc.datEnteredDate = hc.datEnteredDate.Value.AddDays(-2);
            Assert.IsNull(hc.datNotificationDate);
            hc.Validation += hc_Validation_datNotificationDate_datEnteredDate;
            hc.datNotificationDate = hc.datEnteredDate.Value.AddDays(1);
            hc.Validation -= hc_Validation_datNotificationDate_datEnteredDate;
            Assert.IsNull(hc.datNotificationDate);
            Assert.IsNotNull(hc.datEnteredDate);
            hc.Validation += hc_Validation_datNotificationDate_datEnteredDate;
            hc.datNotificationDate = hc.datEnteredDate.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datNotificationDate_datEnteredDate;
            Assert.AreEqual(hc.datNotificationDate, hc.datEnteredDate.Value.AddDays(-1));
        }

        [TestMethod]
        public void TestHumanCaseDates_DSO_ED()
        {
            //12, 15.	DSO≤ED
            Assert.IsNotNull(hc.datEnteredDate);
            hc.datEnteredDate = hc.datEnteredDate.Value.AddDays(-2);
            Assert.IsNull(hc.datOnSetDate);
            hc.Validation += hc_Validation_datOnSetDate_datEnteredDate;
            hc.datOnSetDate = hc.datEnteredDate.Value.AddDays(1);
            hc.Validation -= hc_Validation_datOnSetDate_datEnteredDate;
            Assert.IsNull(hc.datOnSetDate);
            Assert.IsNotNull(hc.datEnteredDate);
            hc.Validation += hc_Validation_datOnSetDate_datEnteredDate;
            hc.datOnSetDate = hc.datEnteredDate.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datOnSetDate_datEnteredDate;
            Assert.AreEqual(hc.datOnSetDate, hc.datEnteredDate.Value.AddDays(-1));
        }

        [TestMethod]
        public void TestHumanCaseDates_IDD_ED()
        {
            //13.	IDD≤ED
            Assert.IsNotNull(hc.datEnteredDate);
            hc.datEnteredDate = hc.datEnteredDate.Value.AddDays(-2);
            Assert.IsNull(hc.datTentativeDiagnosisDate);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datEnteredDate;
            hc.datTentativeDiagnosisDate = hc.datEnteredDate.Value.AddDays(1);
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datEnteredDate;
            Assert.IsNull(hc.datTentativeDiagnosisDate);
            Assert.IsNotNull(hc.datEnteredDate);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datEnteredDate;
            hc.datTentativeDiagnosisDate = hc.datEnteredDate.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datEnteredDate;
            Assert.AreEqual(hc.datTentativeDiagnosisDate, hc.datEnteredDate.Value.AddDays(-1));
        }

        [TestMethod]
        public void TestHumanCaseDates_NSD_CurD()
        {
            //14.	NSD≤CurD
            Assert.IsNull(hc.datNotificationDate);
            hc.Validation += hc_Validation_datNotificationDate_CurrentDate;
            hc.datNotificationDate = DateTime.Now.AddDays(-1).Date;
            hc.Validation -= hc_Validation_datNotificationDate_CurrentDate;
            Assert.AreEqual(hc.datNotificationDate, DateTime.Now.AddDays(-1).Date);
        }

        [TestMethod]
        public void TestHumanCaseDates_IDD_NSD()
        {
            //16.	IDD≤NSD
            hc.datTentativeDiagnosisDate = DateTime.Now.AddDays(-1);
            Assert.IsNull(hc.datNotificationDate);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datNotificationDate;
            hc.datNotificationDate = DateTime.Now.AddDays(-2);
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datNotificationDate;
            Assert.IsNull(hc.datNotificationDate);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datNotificationDate;
            hc.datNotificationDate = DateTime.Now.Date;
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datNotificationDate;
            Assert.AreEqual(hc.datNotificationDate, DateTime.Now.Date);
        }

        [TestMethod]
        public void TestHumanCaseDates_DSO_CurD()
        {
            //17.	DSO≤CurD
            Assert.IsNull(hc.datOnSetDate);
            hc.Validation += hc_Validation_datOnSetDate_CurrentDate;
            hc.datOnSetDate = DateTime.Now.AddDays(-1).Date;
            hc.Validation -= hc_Validation_datOnSetDate_CurrentDate;
            Assert.AreEqual(hc.datOnSetDate, DateTime.Now.AddDays(-1).Date);
        }

        [TestMethod]
        public void TestHumanCaseDates_DSO_IDD()
        {
            //18.	DSO≤IDD
            Assert.IsNull(hc.datTentativeDiagnosisDate);
            hc.datTentativeDiagnosisDate = hc.datEnteredDate.Value.AddDays(-2);
            Assert.IsNull(hc.datOnSetDate);
            hc.Validation += hc_Validation_datOnSetDate_datTentativeDiagnosisDate;
            hc.datOnSetDate = hc.datTentativeDiagnosisDate.Value.AddDays(1);
            hc.Validation -= hc_Validation_datOnSetDate_datTentativeDiagnosisDate;
            Assert.IsNull(hc.datOnSetDate);
            Assert.IsNotNull(hc.datEnteredDate);
            hc.Validation += hc_Validation_datOnSetDate_datTentativeDiagnosisDate;
            hc.datOnSetDate = hc.datTentativeDiagnosisDate.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datOnSetDate_datTentativeDiagnosisDate;
            Assert.AreEqual(hc.datOnSetDate, hc.datTentativeDiagnosisDate.Value.AddDays(-1));
        }

        [TestMethod]
        public void TestHumanCaseDates_DSO_CDD()
        {
            //19.	DSO≤CDD
            Assert.IsNull(hc.datFinalDiagnosisDate);
            hc.datFinalDiagnosisDate = hc.datEnteredDate.Value.AddDays(-2);
            Assert.IsNull(hc.datOnSetDate);
            hc.Validation += hc_Validation_datOnSetDate_datFinalDiagnosisDate;
            hc.datOnSetDate = hc.datFinalDiagnosisDate.Value.AddDays(1);
            hc.Validation -= hc_Validation_datOnSetDate_datFinalDiagnosisDate;
            Assert.IsNull(hc.datOnSetDate);
            Assert.IsNotNull(hc.datEnteredDate);
            hc.Validation += hc_Validation_datOnSetDate_datFinalDiagnosisDate;
            hc.datOnSetDate = hc.datFinalDiagnosisDate.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datOnSetDate_datFinalDiagnosisDate;
            Assert.AreEqual(hc.datOnSetDate, hc.datFinalDiagnosisDate.Value.AddDays(-1));
        }

        [TestMethod]
        public void TestHumanCaseDates_DSO_SColD()
        {
            hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
            hc.Samples[0].SampleType =
                hc.Samples[0].SampleTypeLookup.Where(c => c.name == "Food").SingleOrDefault();
            hc.Samples[0].datFieldCollectionDate = null;

            //20.	DSO≤SColD
            hc.Samples[0].datFieldCollectionDate = DateTime.Now.AddDays(-3);
            Assert.IsNull(hc.datOnSetDate);
            hc.Validation += hc_Validation_datOnSetDate_datFieldCollectionDate;
            hc.datOnSetDate = hc.datEnteredDate;
            hc.Validation -= hc_Validation_datOnSetDate_datFieldCollectionDate;
            Assert.IsNull(hc.datOnSetDate);
            hc.Samples[0].datFieldCollectionDate = null;
            hc.Validation += hc_Validation;
            hc.datOnSetDate = DateTime.Now.Date.AddDays(-1);
            hc.Validation -= hc_Validation;
            Assert.IsNull(hc.Samples[0].datFieldCollectionDate);
            hc.Validation += hc_Validation_datOnSetDate_datFieldCollectionDate;
            hc.Samples[0].datFieldCollectionDate = hc.datOnSetDate.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datOnSetDate_datFieldCollectionDate;
            Assert.IsNull(hc.Samples[0].datFieldCollectionDate);
            hc.Validation += hc_Validation_datOnSetDate_datFieldCollectionDate;
            hc.Samples[0].datFieldCollectionDate = hc.datOnSetDate.Value.AddDays(1);
            hc.Validation -= hc_Validation_datOnSetDate_datFieldCollectionDate;
        }

        [TestMethod]
        public void TestHumanCaseDates_DSO_SSD()
        {
            hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
            hc.Samples[0].SampleType =
                hc.Samples[0].SampleTypeLookup.Where(c => c.name == "Food").SingleOrDefault();
            hc.Samples[0].datFieldCollectionDate = null;

            //21.	DSO≤SSD
            Assert.IsNull(hc.datOnSetDate);
            hc.Samples[0].datFieldSentDate = DateTime.Now.AddDays(-3);
            hc.Validation += hc_Validation_datOnSetDate_datFieldSentDate;
            hc.datOnSetDate = hc.datEnteredDate;
            hc.Validation -= hc_Validation_datOnSetDate_datFieldSentDate;
            Assert.IsNull(hc.datOnSetDate);
            hc.Samples[0].datFieldSentDate = null;
            hc.Validation += hc_Validation;
            hc.datOnSetDate = DateTime.Now.Date.AddDays(-1);
            hc.Validation -= hc_Validation;
            Assert.IsNull(hc.Samples[0].datFieldSentDate);
            hc.Validation += hc_Validation_datOnSetDate_datFieldSentDate;
            hc.Samples[0].datFieldSentDate = hc.datOnSetDate.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datOnSetDate_datFieldSentDate;
            Assert.IsNull(hc.Samples[0].datFieldSentDate);
            hc.Validation += hc_Validation_datOnSetDate_datFieldSentDate;
            hc.Samples[0].datFieldSentDate = hc.datOnSetDate.Value.AddDays(1);
            hc.Validation -= hc_Validation_datOnSetDate_datFieldSentDate;
            Assert.AreEqual(hc.Samples[0].datFieldSentDate, hc.datOnSetDate.Value.AddDays(1));
        }

        [TestMethod]
        public void TestHumanCaseDates_DSO_SAD()
        {
            hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
            hc.Samples[0].SampleType =
                hc.Samples[0].SampleTypeLookup.Where(c => c.name == "Food").SingleOrDefault();
            hc.Samples[0].datFieldCollectionDate = null;

            //22.	DSO≤SAD
            Assert.IsNull(hc.datOnSetDate);
            hc.Samples[0].datFieldSentDate = null;
            hc.Samples[0].datAccession = DateTime.Now.AddDays(-3);
            hc.Validation += hc_Validation_datOnSetDate_datAccession;
            hc.datOnSetDate = hc.datEnteredDate;
            hc.Validation -= hc_Validation_datOnSetDate_datAccession;
            Assert.IsNull(hc.datOnSetDate);
            hc.Samples[0].datAccession = null;
            hc.Validation += hc_Validation;
            hc.datOnSetDate = DateTime.Now.Date.AddDays(-1);
            hc.Validation -= hc_Validation;
            Assert.IsNull(hc.Samples[0].datAccession);
            hc.Validation += hc_Validation_datOnSetDate_datAccession;
            hc.Samples[0].datAccession = hc.datOnSetDate.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datOnSetDate_datAccession;
            Assert.IsNull(hc.Samples[0].datAccession);
            hc.Validation += hc_Validation_datOnSetDate_datAccession;
            hc.Samples[0].datAccession = hc.datOnSetDate.Value.AddDays(1);
            hc.Validation -= hc_Validation_datOnSetDate_datAccession;
            Assert.AreEqual(hc.Samples[0].datAccession, hc.datOnSetDate.Value.AddDays(1));
        }

        [TestMethod]
        public void TestHumanCaseDates_IDD_CDD()
        {
            //23.	IDD≤CDD
            hc.datTentativeDiagnosisDate = DateTime.Now.AddDays(-1);
            Assert.IsNull(hc.datFinalDiagnosisDate);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datFinalDiagnosisDate;
            hc.datFinalDiagnosisDate = DateTime.Now.AddDays(-2);
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datFinalDiagnosisDate;
            Assert.IsNull(hc.datFinalDiagnosisDate);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datFinalDiagnosisDate;
            hc.datFinalDiagnosisDate = DateTime.Now.Date;
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datFinalDiagnosisDate;
            Assert.AreEqual(hc.datFinalDiagnosisDate, DateTime.Now.Date);
        }

        [TestMethod]
        public void TestHumanCaseDates_IDD_SColD()
        {
            hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
            hc.Samples[0].SampleType =
                hc.Samples[0].SampleTypeLookup.Where(c => c.name == "Food").SingleOrDefault();
            hc.Samples[0].datFieldCollectionDate = null;

            //24.	IDD≤SColD
            hc.Samples[0].datFieldCollectionDate = DateTime.Now.AddDays(-3);
            Assert.IsNull(hc.datTentativeDiagnosisDate);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datFieldCollectionDate; //datTentativeDiagnosisDate_datFieldCollectionDate_msgId
            hc.datTentativeDiagnosisDate = hc.datEnteredDate;
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datFieldCollectionDate;
            Assert.IsNull(hc.datTentativeDiagnosisDate);
            hc.Samples[0].datFieldCollectionDate = null;
            hc.Validation += hc_Validation;
            hc.datTentativeDiagnosisDate = DateTime.Now.Date.AddDays(-1);
            hc.Validation -= hc_Validation;
            Assert.IsNull(hc.Samples[0].datFieldCollectionDate);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datFieldCollectionDate;
            hc.Samples[0].datFieldCollectionDate = hc.datTentativeDiagnosisDate.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datFieldCollectionDate;
            Assert.IsNull(hc.Samples[0].datFieldCollectionDate);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datFieldCollectionDate;
            hc.Samples[0].datFieldCollectionDate = hc.datTentativeDiagnosisDate.Value.AddDays(1);
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datFieldCollectionDate;
        }

        [TestMethod]
        public void TestHumanCaseDates_IDD_SSD()
        {
            hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
            hc.Samples[0].SampleType =
                hc.Samples[0].SampleTypeLookup.Where(c => c.name == "Food").SingleOrDefault();
            hc.Samples[0].datFieldCollectionDate = null;

            //25.	IDD≤SSD
            Assert.IsNull(hc.datTentativeDiagnosisDate);
            hc.Samples[0].datFieldSentDate = DateTime.Now.AddDays(-3);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datFieldSentDate;
            hc.datTentativeDiagnosisDate = hc.datEnteredDate;
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datFieldSentDate;
            Assert.IsNull(hc.datTentativeDiagnosisDate);
            hc.Samples[0].datFieldSentDate = null;
            hc.Validation += hc_Validation;
            hc.datTentativeDiagnosisDate = DateTime.Now.Date.AddDays(-1);
            hc.Validation -= hc_Validation;
            Assert.IsNull(hc.Samples[0].datFieldSentDate);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datFieldSentDate;
            hc.Samples[0].datFieldSentDate = hc.datTentativeDiagnosisDate.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datFieldSentDate;
            Assert.IsNull(hc.Samples[0].datFieldSentDate);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datFieldSentDate;
            hc.Samples[0].datFieldSentDate = hc.datTentativeDiagnosisDate.Value.AddDays(1);
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datFieldSentDate;
            Assert.AreEqual(hc.Samples[0].datFieldSentDate, hc.datTentativeDiagnosisDate.Value.AddDays(1));
        }

        [TestMethod]
        public void TestHumanCaseDates_IDD_SAD()
        {
            hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
            hc.Samples[0].SampleType =
                hc.Samples[0].SampleTypeLookup.Where(c => c.name == "Food").SingleOrDefault();
            hc.Samples[0].datFieldCollectionDate = null;

            //26.	IDD≤SAD
            Assert.IsNull(hc.datTentativeDiagnosisDate);
            hc.Samples[0].datFieldSentDate = null;
            hc.Samples[0].datAccession = DateTime.Now.AddDays(-3);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datAccession;
            hc.datTentativeDiagnosisDate = hc.datEnteredDate;
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datAccession;
            Assert.IsNull(hc.datTentativeDiagnosisDate);
            hc.Samples[0].datAccession = null;
            hc.Validation += hc_Validation;
            hc.datTentativeDiagnosisDate = DateTime.Now.Date.AddDays(-1);
            hc.Validation -= hc_Validation;
            Assert.IsNull(hc.Samples[0].datAccession);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datAccession;
            hc.Samples[0].datAccession = hc.datTentativeDiagnosisDate.Value.AddDays(-1);
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datAccession;
            Assert.IsNull(hc.Samples[0].datAccession);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datAccession;
            hc.Samples[0].datAccession = hc.datTentativeDiagnosisDate.Value.AddDays(1);
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datAccession;
            Assert.AreEqual(hc.Samples[0].datAccession, hc.datTentativeDiagnosisDate.Value.AddDays(1));
        }

        [TestMethod]
        public void TestHumanCaseDates_DOB_DLC()
        {
            //27. DOB≤DLC
            hc.ContactedPerson.Add(ContactedCasePerson.Accessor.Instance(null).Create(manager, hc, hc.idfCase));
            hc.ContactedPerson[0].datDateofBirth = DateTime.Now.AddDays(-5);
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-1);
            Assert.IsNull(hc.ContactedPerson[0].datDateOfLastContact);
            hc.Validation += hc_Validation_datDateofBirth_datDateOfLastContact;
            hc.ContactedPerson[0].datDateOfLastContact = DateTime.Now.AddDays(-2);
            hc.Validation -= hc_Validation_datDateofBirth_datDateOfLastContact;
            Assert.IsNull(hc.ContactedPerson[0].datDateOfLastContact);
            hc.Validation += hc_Validation_datDateofBirth_datDateOfLastContact;
            hc.ContactedPerson[0].datDateOfLastContact = DateTime.Now.Date;
            hc.Validation -= hc_Validation_datDateofBirth_datDateOfLastContact;
            Assert.AreEqual(hc.ContactedPerson[0].datDateOfLastContact, DateTime.Now.Date);
        }

        [TestMethod]
        public void TestHumanCaseDates_DOB_DH()
        {
            //28. DOB≤DH
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-1);
            Assert.IsNull(hc.datHospitalizationDate);
            hc.Validation += hc_Validation_datDateofBirth_datHospitalizationDate;
            hc.datHospitalizationDate = DateTime.Now.AddDays(-2);
            hc.Validation -= hc_Validation_datDateofBirth_datHospitalizationDate;
            Assert.IsNull(hc.datHospitalizationDate);
            hc.Validation += hc_Validation_datDateofBirth_datHospitalizationDate;
            hc.datHospitalizationDate = DateTime.Now.Date;
            hc.Validation -= hc_Validation_datDateofBirth_datHospitalizationDate;
            Assert.AreEqual(hc.datHospitalizationDate, DateTime.Now.Date);
        }

        [TestMethod]
        public void TestHumanCaseDates_DOB_DFSC()
        {
            //29. DOB≤DFSC
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-1);
            Assert.IsNull(hc.datFirstSoughtCareDate);
            hc.Validation += hc_Validation_datDateofBirth_datFirstSoughtCareDate;
            hc.datFirstSoughtCareDate = DateTime.Now.AddDays(-2);
            hc.Validation -= hc_Validation_datDateofBirth_datFirstSoughtCareDate;
            Assert.IsNull(hc.datFirstSoughtCareDate);
            hc.Validation += hc_Validation_datDateofBirth_datFirstSoughtCareDate;
            hc.datFirstSoughtCareDate = DateTime.Now.Date;
            hc.Validation -= hc_Validation_datDateofBirth_datFirstSoughtCareDate;
            Assert.AreEqual(hc.datFirstSoughtCareDate, DateTime.Now.Date);
        }

        [TestMethod]
        public void TestHumanCaseDates_DE_DSO()
        {
            //30. DE≤DSO
            hc.datExposureDate = DateTime.Now.AddDays(-1);
            Assert.IsNull(hc.datOnSetDate);
            hc.Validation += hc_Validation_datExposureDate_datOnSetDate;
            hc.datOnSetDate = DateTime.Now.AddDays(-2);
            hc.Validation -= hc_Validation_datExposureDate_datOnSetDate;
            Assert.IsNull(hc.datOnSetDate);
            hc.Validation += hc_Validation_datExposureDate_datOnSetDate;
            hc.datOnSetDate = DateTime.Now.Date;
            hc.Validation -= hc_Validation_datExposureDate_datOnSetDate;
            Assert.AreEqual(hc.datOnSetDate, DateTime.Now.Date);
        }

        [TestMethod]
        public void TestHumanCaseDates_IDD_DCPF()
        {
            //31. IDD≤DCPF   
            hc.datTentativeDiagnosisDate = DateTime.Now.AddDays(-1);
            Assert.IsNull(hc.datCompletionPaperFormDate);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datCompletionPaperFormDate;
            hc.datCompletionPaperFormDate = DateTime.Now.AddDays(-2);
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datCompletionPaperFormDate;
            Assert.IsNull(hc.datCompletionPaperFormDate);
            hc.Validation += hc_Validation_datTentativeDiagnosisDate_datCompletionPaperFormDate;
            hc.datCompletionPaperFormDate = DateTime.Now.Date;
            hc.Validation -= hc_Validation_datTentativeDiagnosisDate_datCompletionPaperFormDate;
            Assert.AreEqual(hc.datCompletionPaperFormDate, DateTime.Now.Date);
        }

        [TestMethod]
        public void TestHumanCaseDates_DCPF_NSD()
        {
            //32. DCPF≤NSD 
            DateTime curDate = DateTime.Now;
            hc.datCompletionPaperFormDate = curDate.AddDays(-2);
            Assert.IsNull(hc.datNotificationDate);
            hc.Validation += hc_Validation_datCompletionPaperFormDate_datNotificationDate;
            hc.datNotificationDate = curDate.AddDays(-3);
            hc.Validation -= hc_Validation_datCompletionPaperFormDate_datNotificationDate;
            Assert.IsNull(hc.datNotificationDate);
            hc.Validation += hc_Validation_datCompletionPaperFormDate_datNotificationDate;
            hc.datNotificationDate = curDate.Date.AddDays(-1);
            hc.Validation -= hc_Validation_datCompletionPaperFormDate_datNotificationDate;
            Assert.AreEqual(hc.datNotificationDate, curDate.Date.AddDays(-1));
            hc.Validation += hc_Validation_datCompletionPaperFormDate_datNotificationDate;
            hc.datCompletionPaperFormDate = curDate;
            hc.Validation -= hc_Validation_datCompletionPaperFormDate_datNotificationDate;
            Assert.AreEqual(hc.datCompletionPaperFormDate.Value.Date, curDate.Date.AddDays(-2));
            hc.datCompletionPaperFormDate = null;
            hc.Validation += hc_Validation_datCompletionPaperFormDate_datNotificationDate;
            hc.datCompletionPaperFormDate = curDate;
            hc.Validation -= hc_Validation_datCompletionPaperFormDate_datNotificationDate;
            Assert.IsNull(hc.datCompletionPaperFormDate);
        }

        [TestMethod]
        public void TestHumanCaseDates_SAD_TD()
        {
            //33. SAD≤TD
        }

        //[TestMethod] obsolete validation
        //public void TestHumanCaseDates_DLS_CurD()
        //{
        //    //34. DLS≤CurD 
        //    Assert.IsNull(hc.datModificationDate);
        //    hc.Validation += hc_Validation_datModificationDate_CurrentDate;
        //    hc.datModificationDate = DateTime.Now.AddDays(1);
        //    hc.Validation -= hc_Validation_datModificationDate_CurrentDate;
        //    Assert.IsNull(hc.datModificationDate);
        //    hc.Validation += hc_Validation_datModificationDate_CurrentDate;
        //    hc.datModificationDate = DateTime.Now.AddDays(-1).Date;
        //    hc.Validation -= hc_Validation_datModificationDate_CurrentDate;
        //    Assert.AreEqual(hc.datModificationDate, DateTime.Now.AddDays(-1).Date);
        //}

        [TestMethod]
        public void TestHumanCaseDates_DOB_DSO()
        {
            //35.	DOB≤DSO
            Assert.IsNull(hc.Patient.datDateofBirth);
            hc.datOnSetDate = DateTime.Now.AddDays(-2);
            hc.Validation += hc_Validation_datDateofBirth_datOnSetDate;
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-1);
            hc.Validation -= hc_Validation_datDateofBirth_datOnSetDate;
            Assert.IsNull(hc.Patient.datDateofBirth);
            hc.Validation += hc_Validation_datDateofBirth_datOnSetDate;
            hc.Patient.datDateofBirth = DateTime.Now.AddDays(-3).Date;
            hc.Validation -= hc_Validation_datDateofBirth_datOnSetDate;
            Assert.AreEqual(hc.Patient.datDateofBirth, DateTime.Now.AddDays(-3).Date);
        }

        [TestMethod]
        public void TestValidators()
        {
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();
            hc.Patient.strLastName = "last";
            hc.Patient.strFirstName = "first";

            hc.Validation += hc_Validation_idfsCountry;
            Assert.IsFalse(acc.Validate(manager, hc, true, true, true));
            Assert.IsFalse(acc.Post(manager, hc));
            hc.Validation -= hc_Validation_idfsCountry;
        }

        [TestMethod]
        public void TestHumanCaseClassificationAndOutcome()
        {
            Assert.IsTrue(hc.IsInvisible("datDischargeDate"));
            Assert.IsNull(hc.datDischargeDate);
            Assert.IsTrue(hc.IsInvisible("datDateOfDeath"));
            Assert.IsNull(hc.datDateOfDeath);
            hc.Outcome = hc.OutcomeLookup.Where(c => c.strDefault == "Unknown").SingleOrDefault();
            Assert.IsTrue(hc.IsInvisible("datDischargeDate"));
            Assert.IsNull(hc.datDischargeDate);
            Assert.IsTrue(hc.IsInvisible("datDateOfDeath"));
            Assert.IsNull(hc.datDateOfDeath);
            hc.Outcome = hc.OutcomeLookup.Where(c => c.strDefault == "Recovered").SingleOrDefault();
            Assert.IsFalse(hc.IsInvisible("datDischargeDate"));
            hc.datDischargeDate = DateTime.Now;
            Assert.IsTrue(hc.IsInvisible("datDateOfDeath"));
            Assert.IsNull(hc.datDateOfDeath);
            hc.Outcome = hc.OutcomeLookup.Where(c => c.strDefault == "Died").SingleOrDefault();
            Assert.IsTrue(hc.IsInvisible("datDischargeDate"));
            Assert.IsNull(hc.datDischargeDate);
            Assert.IsFalse(hc.IsInvisible("datDateOfDeath"));
            hc.datDischargeDate = DateTime.Now;
            hc.Outcome = hc.OutcomeLookup.Where(c => c.strDefault == "Unknown").SingleOrDefault();
            Assert.IsTrue(hc.IsInvisible("datDischargeDate"));
            Assert.IsNull(hc.datDischargeDate);
            Assert.IsTrue(hc.IsInvisible("datDateOfDeath"));
            Assert.IsNull(hc.datDateOfDeath);
        }

        [TestMethod]
        public void TestHumanCaseGeneral()
        {
            long id = hc.idfCase;
            Assert.IsNotNull(hc.datEnteredDate);
            // The field Date Entered will be populated automatically when the case is created
            Assert.IsNull(hc.datModificationDate);
            // When the form for a new case is opened the Date Entered by default is the current date and the Date Last Saved is empty
            Assert.IsNotNull(hc.Patient);
            Assert.AreEqual(id, hc.Patient.idfCase);

            //The case could not be saved unless the diagnosis is given
            hc.Validation += hc_Validation_idfsTentativeDiagnosis;
            Assert.IsFalse(acc.Post(manager, hc));
            hc.Validation -= hc_Validation_idfsTentativeDiagnosis;

            // the field Diagnosis is blocked until the diagnosis is chosen
            Assert.IsTrue(hc.IsReadOnly("datTentativeDiagnosisDate"));
            // The value of the field Diagnosis: if the Changed Diagnosis (if known) field of the Notification tab is not blank, then its value is displayed, otherwise – the value of the Diagnosis field -->
            Assert.AreEqual("", hc.strDiagnosis);
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();
            Assert.AreEqual("Anthrax - Cutaneous", hc.strDiagnosis);
            Assert.IsFalse(hc.IsReadOnly("datTentativeDiagnosisDate"));
            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Where(a => a.name == "Anthrax - Pulmonary").SingleOrDefault();
            hc.DiagnosisHistory[0].idfsChangeDiagnosisReason =
                hc.DiagnosisHistory[0].ChangeDiagnosisReasonLookup.Where(a => a.name == "Misdiagnosis").SingleOrDefault().idfsBaseReference;
            Assert.AreEqual("Anthrax - Pulmonary", hc.strDiagnosis);
            // The field Case Classification: if the Final Case Classification field is not blank, then its value is displayed, otherwise – the value of the Initial Case Classification -->
            Assert.AreEqual("", hc.strCaseClassification);
            hc.InitialCaseStatus = hc.InitialCaseStatusLookup.Where(a => a.name == "Probable").SingleOrDefault();
            Assert.AreEqual("Probable", hc.strCaseClassification);
            hc.FinalCaseStatus = hc.FinalCaseStatusLookup.Where(a => a.name == "Confirmed").SingleOrDefault();
            Assert.AreEqual("Confirmed", hc.strCaseClassification);
            // If any value is selected the Changed diagnosis (if known) field on the Notification tab and a user tries to select the same value 
            // in the Diagnosis field, then the system returns the previous value (even if it was blank) and displays message box 
            // ‘The changed diagnosis should differ from the initial diagnosis.’
            hc.Validation += hc_Validation_idfsFinalDiagnosis_idfsTentativeDiagnosis;
            Assert.AreEqual("Anthrax - Pulmonary", hc.FinalDiagnosis.name);
            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();
            Assert.AreEqual("Anthrax - Pulmonary", hc.FinalDiagnosis.name);
            Assert.AreEqual("Anthrax - Cutaneous", hc.TentativeDiagnosis.name);
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Pulmonary").SingleOrDefault();
            Assert.AreEqual("Anthrax - Cutaneous", hc.TentativeDiagnosis.name);
            hc.Validation -= hc_Validation_idfsFinalDiagnosis_idfsTentativeDiagnosis;

            // If a user clears the Changed Diagnosis field, then the Date of Changed Diagnosis becomes blank and disabled.
            hc.FinalDiagnosis = null;
            Assert.IsTrue(hc.IsReadOnly("datFinalDiagnosisDate"));
            Assert.IsNull(hc.datFinalDiagnosisDate);
            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Where(a => a.name == "Anthrax - Oropharyngeal").SingleOrDefault();
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.FinalDiagnosis.name);
            Assert.IsFalse(hc.IsReadOnly("datFinalDiagnosisDate"));
            hc.datFinalDiagnosisDate = DateTime.Now;
            Assert.IsNotNull(hc.datFinalDiagnosisDate);
            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Where(a => a.name == "Anthrax - Pulmonary").SingleOrDefault();
            Assert.AreEqual("Anthrax - Pulmonary", hc.FinalDiagnosis.name);
            Assert.IsFalse(hc.IsReadOnly("datFinalDiagnosisDate"));
            Assert.IsNotNull(hc.datFinalDiagnosisDate);
            hc.FinalDiagnosis = null;
            Assert.IsTrue(hc.IsReadOnly("datFinalDiagnosisDate"));
            Assert.IsNull(hc.datFinalDiagnosisDate);

            // If the patient is in a hospital, the Hospital name text-field can be filled in (otherwise this field is blocked), 
            // if he or she is neither at home nor in a hospital, the Other location name can also be given in the text-field (otherwise this field is blocked).
            Assert.IsTrue(hc.IsReadOnly("strCurrentLocation"));
            Assert.AreEqual("", hc.strCurrentLocation);
            Assert.IsNull(hc.idfsHospitalizationStatus);
            hc.PatientLocationType =
                hc.PatientLocationTypeLookup.Where(c => c.strDefault == "Hospital").SingleOrDefault();
            Assert.IsNotNull(hc.idfsHospitalizationStatus);
            Assert.IsFalse(hc.IsReadOnly("strCurrentLocation"));
            Assert.IsNull(hc.strCurrentLocation);
            hc.strCurrentLocation = "test";
            Assert.AreEqual("test", hc.strCurrentLocation);
            hc.PatientLocationType =
                hc.PatientLocationTypeLookup.Where(c => c.strDefault == "Other").SingleOrDefault();
            Assert.IsNotNull(hc.idfsHospitalizationStatus);
            Assert.IsFalse(hc.IsReadOnly("strCurrentLocation"));
            Assert.IsNull(hc.strCurrentLocation);
            hc.strCurrentLocation = "test";
            Assert.AreEqual("test", hc.strCurrentLocation);
            hc.PatientLocationType =
                hc.PatientLocationTypeLookup.Where(c => c.strDefault == "Home").SingleOrDefault();
            Assert.IsNotNull(hc.idfsHospitalizationStatus);
            Assert.IsTrue(hc.IsReadOnly("strCurrentLocation"));
            Assert.IsNull(hc.strCurrentLocation);
            hc.strCurrentLocation = "test";
            Assert.AreEqual("test", hc.strCurrentLocation);
            hc.PatientLocationType = null;
            Assert.IsNull(hc.idfsHospitalizationStatus);
            Assert.IsTrue(hc.IsReadOnly("strCurrentLocation"));
            Assert.IsNull(hc.strCurrentLocation);

            // The completion of the field Last Name is mandatory
            hc.Validation += hc_Validation_strLastName;
            Assert.IsFalse(acc.Post(manager, hc));
            hc.Validation -= hc_Validation_strLastName;

            hc.Patient.strLastName = "last";
            hc.Patient.strFirstName = "first";
            hc.Patient.strSecondName = "second";
            Assert.AreEqual("last first second", hc.Patient.strName);
            // In the field Patient the last and the first name of the patient will be displayed

            // mandatory for posting
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                    SingleOrDefault
                    ();

            hc.SpecimenCollected =
                hc.SpecimenCollectedLookup.Where(c => c.strDefault == "Yes").SingleOrDefault();

            hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
            hc.Samples[0].SampleType =
                hc.Samples[0].SampleTypeLookup.Where(c => c.name == "Food").SingleOrDefault();
            hc.Samples[0].datFieldCollectionDate = DateTime.Now.AddDays(-1);
            hc.Samples[0].strFieldBarcode = "qqq";

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            hc = acc.SelectByKey(manager, id);
            Assert.IsNotNull(hc);
            Assert.IsNotNull(hc.Patient);
            Assert.AreEqual(id, hc.Patient.idfCase);
            Assert.AreEqual(1, hc.Samples.Count);
            Assert.AreEqual(id, hc.Samples[0].idfCase);
            Assert.AreEqual("Food", hc.Samples[0].strSpecimenName);
            Assert.AreEqual("qqq", hc.Samples[0].strFieldBarcode);
            Assert.AreEqual("last", hc.Patient.strLastName);
            Assert.AreEqual("first", hc.Patient.strFirstName);
            Assert.AreEqual("second", hc.Patient.strSecondName);
            Assert.AreEqual("last first second", hc.Patient.strName);
            // In the field Patient the last and the first name of the patient will be displayed
            Assert.IsNotNull(hc.datModificationDate);
            // In the field Date Last Saved the current date will be inserted each time the changes are saved
            Assert.AreEqual("Anthrax - Cutaneous", hc.strDiagnosis);
            Assert.AreEqual("Confirmed", hc.strCaseClassification);

            // Hospitalization
            // If the value of the field Hospitalization is Yes and at least one of two fields (Date of Hospitalization and Place of Hospitalization) 
            // is not blank and a user tries to clear or change the value of the Hospitalization field, then confirmation dialog opens 
            // ‘There is some information on hospitalization. Are you sure you want to delete it?’ with Yes and No buttons. If a user clicks No, 
            // then the system cancels operation and the value of the Hospitalization field is not changed. If a user clicks Yes, then 
            // Date of Hospitalization and Place of Hospitalization fields become blank and disabled, and the value of the Hospitalization field is changed.
            Assert.IsTrue(hc.IsReadOnly("datHospitalizationDate"));
            Assert.IsTrue(hc.IsReadOnly("strHospitalizationPlace"));
            Assert.IsNull(hc.Hospitalization);
            hc.Hospitalization = hc.HospitalizationLookup.Where(c => c.name == "Yes").SingleOrDefault();
            Assert.AreEqual("Yes", hc.Hospitalization.name);
            Assert.IsFalse(hc.IsReadOnly("datHospitalizationDate"));
            Assert.IsFalse(hc.IsReadOnly("strHospitalizationPlace"));
            Assert.AreEqual("", hc.strHospitalizationPlace);
            Assert.IsNull(hc.datHospitalizationDate);
            hc.Hospitalization = hc.HospitalizationLookup.Where(c => c.name == "No").SingleOrDefault();
            Assert.AreEqual("No", hc.Hospitalization.name);
            Assert.AreEqual("", hc.strHospitalizationPlace);
            Assert.IsNull(hc.datHospitalizationDate);
            hc.Hospitalization = hc.HospitalizationLookup.Where(c => c.name == "Yes").SingleOrDefault();
            Assert.AreEqual("Yes", hc.Hospitalization.name);
            hc.datHospitalizationDate = DateTime.Now;
            hc.strHospitalizationPlace = "place";
            Assert.AreEqual("place", hc.strHospitalizationPlace);
            Assert.IsNotNull(hc.datHospitalizationDate);
            hc.Validation += hc_Validation_Hospitalization_Reject;
            hc.Hospitalization = hc.HospitalizationLookup.Where(c => c.name == "No").SingleOrDefault();
            Assert.AreEqual("Yes", hc.Hospitalization.name);
            Assert.AreEqual("place", hc.strHospitalizationPlace);
            Assert.IsNotNull(hc.datHospitalizationDate);
            hc.Validation -= hc_Validation_Hospitalization_Reject;
            hc.Validation += hc_Validation_Hospitalization_Confirm;
            hc.Hospitalization = hc.HospitalizationLookup.Where(c => c.name == "No").SingleOrDefault();
            hc.Validation -= hc_Validation_Hospitalization_Confirm;
            Assert.AreEqual("No", hc.Hospitalization.name);
            Assert.AreEqual("", hc.strHospitalizationPlace);
            Assert.IsNull(hc.datHospitalizationDate);

            // always read only fields
            Assert.IsTrue(hc.IsReadOnly("strDiagnosis"));
            Assert.IsTrue(hc.IsReadOnly("strCaseClassification"));
            Assert.IsTrue(hc.IsReadOnly("strCaseID"));
            Assert.IsTrue(hc.IsReadOnly("datEnteredDate"));
            Assert.IsTrue(hc.IsReadOnly("datModificationDate"));
            Assert.IsTrue(hc.Patient.IsReadOnly("strName"));

            Assert.IsFalse(hc.MarkToDelete());
            hc.Validation += hc_ValidationContinue;
            Assert.IsTrue(hc.MarkToDelete());
            hc.Validation -= hc_ValidationContinue;
            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            hc = acc.SelectByKey(manager, id);
            Assert.IsNull(hc);
        }

        [TestMethod]
        public void TestHumanContactedPerson()
        {
            long id = hc.idfCase;

            // mandatory for posting
            hc.Patient.strLastName = "last";
            hc.Patient.strFirstName = "first";
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                    SingleOrDefault();
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();

            Assert.AreEqual(0, hc.ContactedPerson.Count);
            hc.ContactedPerson.Add(ContactedCasePerson.Accessor.Instance(null).Create(manager, hc, hc.idfCase));
            Assert.AreEqual(1, hc.ContactedPerson.Count);
            Assert.AreEqual("Family", hc.ContactedPerson[0].PersonContactType.strDefault);
            Assert.IsNotNull(hc.ContactedPerson[0].Person);
            Assert.IsNotNull(hc.ContactedPerson[0].Person.CurrentResidenceAddress);
            hc.ContactedPerson[0].Person.strHomePhone = "123";

            hc.Validation += hc_Validation_ContactedPerson_msgId;
            hc.ContactedPerson.Add(ContactedCasePerson.Accessor.Instance(null).Create(manager, hc, hc.idfCase));
            Assert.AreEqual(1, hc.ContactedPerson.Count);
            Assert.IsFalse(acc.Post(manager, hc));
            hc.Validation -= hc_Validation_ContactedPerson_msgId;

            hc.ContactedPerson[0].Person.strLastName = "last";
            Assert.AreEqual("last", hc.ContactedPerson[0].Person.strLastName);
            hc.ContactedPerson[0].Person.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                    SingleOrDefault();
            //Assert.AreEqual("Georgia",
            //                hc.ContactedPerson[0].Person.CurrentResidenceAddress.FullName);

            hc.ContactedPerson[0].Person.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                    SingleOrDefault();
            hc.ContactedPerson[0].Person.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                    SingleOrDefault();

            hc.ContactedPerson.Add(ContactedCasePerson.Accessor.Instance(null).Create(manager, hc, hc.idfCase));
            Assert.AreEqual(2, hc.ContactedPerson.Count);
            hc.ContactedPerson[1].Person.strLastName = "last2";
            Assert.AreEqual("last2", hc.ContactedPerson[1].Person.strLastName);

            hc.ContactedPerson[1].Person.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                    SingleOrDefault();
            //Assert.AreEqual("Georgia",
            //                hc.ContactedPerson[1].Person.CurrentResidenceAddress.FullName);

            hc.ContactedPerson[1].Person.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                    SingleOrDefault();
            hc.ContactedPerson[1].Person.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                    SingleOrDefault();

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            int cnt = manager.SetCommand("select count(*) from tlbHuman").ExecuteScalar<int>();
            cnt = manager.SetCommand("select count(*) from tlbContactedCasePerson").ExecuteScalar<int>();
            DataSet ds = manager.SetCommand("select idfHuman from tlbHuman").ExecuteDataSet();
            ds = manager.SetCommand("select idfHuman from tlbContactedCasePerson").ExecuteDataSet();
            //cnt = manager.SetCommand("select count(*) from fn_CaseSamples(" + hc.idfCase + ", 'en')").ExecuteScalar<int>();

            hc = acc.SelectByKey(manager, id);
            Assert.IsNotNull(hc);
            Assert.AreEqual(id, hc.idfCase);
            Assert.AreEqual(2, hc.ContactedPerson.Count);
            //Person is not loaded and strRegistrationAddress equals preloaded strPatientInformation
            Assert.AreEqual("Georgia, Abkhazia, Gagra, 123", hc.ContactedPerson[0].strPatientInformation);
            //Assert.AreEqual(hc.ContactedPerson[0].strRegistrationAddress, hc.ContactedPerson[0].strPatientInformation);
            Assert.AreEqual("last", hc.ContactedPerson[0].Person.strLastName);
            Assert.AreEqual("Georgia, Abkhazia, Gagra",
                            hc.ContactedPerson[0].Person.CurrentResidenceAddress.FullName);
            Assert.AreEqual("last2", hc.ContactedPerson[1].Person.strLastName);
            //Person is loaded now and strRegistrationAddress is calcualted basing on Person data
            hc.ContactedPerson[0].Person.strHomePhone = "456";
            Assert.AreEqual("Georgia, Abkhazia, Gagra, 123", hc.ContactedPerson[0].strPatientInformation);
            Assert.AreEqual("Georgia, Tbilisi, 456", hc.ContactedPerson[0].strRegistrationAddress);
            Assert.AreEqual("Family", hc.ContactedPerson[0].strPersonContactType);
            hc.ContactedPerson[0].PersonContactType =
                hc.ContactedPerson[0].PersonContactTypeLookup.Where(c => c.strDefault == "Friend").SingleOrDefault();
            Assert.AreEqual("Friend", hc.ContactedPerson[0].strPersonContactType);
        }

        [TestMethod]
        public void TestHumanCaseSamples()
        {
            long id = hc.idfCase;

            // mandatory for posting
            hc.Patient.strLastName = "last";
            hc.Patient.strFirstName = "first";
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                    SingleOrDefault();
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();

            // If the value of the field Samples Collected is Yes and the Samples table has at least one row and a user tries to clear or change the value of the Samples Collected field, then the system cancels the operation and a message box 'It is impossible to disable the Sample table because it contains some records.' appears.
            // If a user changes the value of the field Samples Collected to No, the Reason field becomes shown, New and Delete buttons and the Note field becomes disabled.
            // If a user clears the field Samples Collected or changes its value to Unknown, the Reason field becomes clear and hidden, if it has been shown, New and Delete buttons and the Note field becomes disabled.
            // If a user changes the value of the field Samples Collected to Yes, the Reason field becomes clear and hidden, if it has been shown, New and Delete buttons panel and the Note field becomes enabled.
            Assert.IsNull(hc.SpecimenCollected);
            Assert.IsTrue(hc.IsReadOnly("idfsNotCollectedReason"));
            Assert.IsTrue(hc.IsInvisible("idfsNotCollectedReason"));
            Assert.IsTrue(hc.idfsNotCollectedReason==null);
            Assert.IsTrue(hc.IsReadOnly("strSampleNotes"));
            Assert.IsFalse(hc.IsInvisible("strSampleNotes"));
            Assert.IsTrue(string.IsNullOrEmpty(hc.strSampleNotes));
            hc.SpecimenCollected = hc.SpecimenCollectedLookup.Where(c => c.strDefault == "No").SingleOrDefault();
            Assert.AreEqual("No", hc.SpecimenCollected.strDefault);
            Assert.IsFalse(hc.IsReadOnly("idfsNotCollectedReason"));
            Assert.IsFalse(hc.IsInvisible("idfsNotCollectedReason"));
            hc.idfsNotCollectedReason = 12014780000000;//Patient is unavailable
            Assert.IsFalse(hc.idfsNotCollectedReason == null);
            Assert.IsTrue(hc.IsReadOnly("strSampleNotes"));
            Assert.IsFalse(hc.IsInvisible("strSampleNotes"));
            Assert.IsTrue(string.IsNullOrEmpty(hc.strSampleNotes));
            hc.SpecimenCollected =
                hc.SpecimenCollectedLookup.Where(c => c.strDefault == "Yes").SingleOrDefault();
            Assert.AreEqual("Yes", hc.SpecimenCollected.strDefault);
            Assert.IsTrue(hc.IsReadOnly("idfsNotCollectedReason"));
            Assert.IsTrue(hc.IsInvisible("idfsNotCollectedReason"));
            Assert.IsTrue(hc.idfsNotCollectedReason == null);
            Assert.IsFalse(hc.IsReadOnly("strSampleNotes"));
            Assert.IsFalse(hc.IsInvisible("strSampleNotes"));
            Assert.IsTrue(string.IsNullOrEmpty(hc.strSampleNotes));
            hc.strSampleNotes = "test";
            Assert.IsFalse(string.IsNullOrEmpty(hc.strSampleNotes));
            hc.SpecimenCollected =
                hc.SpecimenCollectedLookup.Where(c => c.strDefault == "No").SingleOrDefault();
            Assert.IsTrue(hc.IsReadOnly("strSampleNotes"));
            Assert.IsFalse(hc.IsInvisible("strSampleNotes"));
            Assert.IsTrue(string.IsNullOrEmpty(hc.strSampleNotes));
            hc.SpecimenCollected =
                hc.SpecimenCollectedLookup.Where(c => c.strDefault == "Yes").SingleOrDefault();
            Assert.IsTrue(string.IsNullOrEmpty(hc.strSampleNotes));
            Assert.IsFalse(hc.IsInvisible("strSampleNotes"));
            Assert.IsFalse(hc.IsReadOnly("strSampleNotes"));
            hc.strSampleNotes = "test";
            Assert.IsFalse(string.IsNullOrEmpty(hc.strSampleNotes));
            Assert.IsFalse(hc.IsInvisible("strSampleNotes"));
            hc.SpecimenCollected =
                hc.SpecimenCollectedLookup.Where(c => c.strDefault == "Unknown").SingleOrDefault();
            Assert.IsTrue(hc.IsReadOnly("strSampleNotes"));
            Assert.IsFalse(hc.IsInvisible("strSampleNotes"));
            Assert.IsTrue(string.IsNullOrEmpty(hc.strSampleNotes));
            hc.SpecimenCollected =
                hc.SpecimenCollectedLookup.Where(c => c.strDefault == "Yes").SingleOrDefault();

            hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
            Assert.AreEqual(1, hc.Samples.Count);
            Assert.AreEqual(DateTime.Now.Date, hc.Samples[0].datFieldCollectionDate);
            Assert.IsNull(hc.Samples[0].SampleType);

            hc.Validation += hc_Validation_idfsSpecimenType_msgId;
            hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
            Assert.AreEqual(1, hc.Samples.Count);
            Assert.IsFalse(acc.Post(manager, hc));
            hc.Validation -= hc_Validation_idfsSpecimenType_msgId;

            hc.Samples[0].SampleType =
                hc.Samples[0].SampleTypeLookup.Where(c => c.name == "Blood - plasma").SingleOrDefault();
            Assert.AreEqual("Blood - plasma", hc.Samples[0].SampleType.name);
            hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
            Assert.AreEqual(2, hc.Samples.Count);
            hc.Samples[1].SampleType =
                hc.Samples[1].SampleTypeLookup.Where(c => c.name == "Food").SingleOrDefault();
            Assert.AreEqual("Food", hc.Samples[1].SampleType.name);

            hc.Validation += hc_Validation_idfsYNSpecimenCollected_msgId;
            hc.SpecimenCollected = hc.SpecimenCollectedLookup.Where(c => c.strDefault == "No").SingleOrDefault();
            Assert.AreEqual("Yes", hc.SpecimenCollected.strDefault);
            Assert.IsTrue(hc.IsReadOnly("idfsNotCollectedReason"));
            Assert.IsTrue(hc.IsInvisible("idfsNotCollectedReason"));
            Assert.IsTrue(hc.idfsNotCollectedReason==null);
            hc.Validation -= hc_Validation_idfsYNSpecimenCollected_msgId;

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            //int cnt = manager.SetCommand("select count(*) from tlbMaterial").ExecuteScalar<int>();
            //cnt = manager.SetCommand("select count(*) from fn_CaseSamples(" + hc.idfCase + ", 'en')").ExecuteScalar<int>();

            hc = acc.SelectByKey(manager, id);
            Assert.IsNotNull(hc);
            Assert.AreEqual(id, hc.idfCase);
            Assert.AreEqual(2, hc.Samples.Count);
            Assert.AreEqual("Blood - plasma", hc.Samples[0].SampleType.name);
            Assert.AreEqual("Food", hc.Samples[1].SampleType.name);
        }

        [TestMethod]
        public void TestHumanCaseAntimicrobialTherapy()
        {
            long id = hc.idfCase;

            // mandatory for posting
            hc.Patient.strLastName = "last";
            hc.Patient.strFirstName = "first";
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                    SingleOrDefault();
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();

            // If the value of the field Antibiotic/Antiviral therapy administered before samples collection is Yes and the 
            // Antibiotic table has at least one row and a user tries to clear or change the value of the Antibiotic/Antiviral therapy 
            // administered before samples collection field, then the system cancels the operation and a message box 
            // 'It is impossible to disable the table of antibiotic or antiviral therapy because it contains some records.' appears.
            Assert.AreEqual(0, hc.AntimicrobialTherapy.Count);
            hc.AntimicrobialTherapyUsed =
                hc.AntimicrobialTherapyUsedLookup.Where(c => c.strDefault == "Yes").SingleOrDefault();
            Assert.AreEqual("Yes", hc.AntimicrobialTherapyUsed.strDefault);
            hc.AntimicrobialTherapyUsed =
                hc.AntimicrobialTherapyUsedLookup.Where(c => c.strDefault == "No").SingleOrDefault();
            Assert.AreEqual("No", hc.AntimicrobialTherapyUsed.strDefault);
            hc.AntimicrobialTherapyUsed = null;
            Assert.IsNull(hc.AntimicrobialTherapyUsed);
            hc.AntimicrobialTherapyUsed =
                hc.AntimicrobialTherapyUsedLookup.Where(c => c.strDefault == "Yes").SingleOrDefault();
            Assert.AreEqual("Yes", hc.AntimicrobialTherapyUsed.strDefault);
            hc.AntimicrobialTherapy.Add(AntimicrobialTherapy.Accessor.Instance(null).Create(manager, hc, hc.idfCase));
            Assert.AreEqual(1, hc.AntimicrobialTherapy.Count);
            Assert.AreEqual(id, hc.AntimicrobialTherapy[0].idfHumanCase);

            // If there is at least one record with empty cell of the Name column in the Antibiotic grid 
            // and a user tries to click Add button assigned to the Antibiotic grid or save the case, the system cancels operation, 
            // the Case Investigation tab and the Clinical Information sub-tab open and message box 'Some records from the table of 
            // antibiotic and antiviral therapy are not defined. Please define or delete undefined records' appears.
            hc.Validation += hc_Validation_AntimicrobialTherapy_msgId;
            Assert.IsFalse(acc.Post(manager, hc));
            hc.AntimicrobialTherapy.Add(AntimicrobialTherapy.Accessor.Instance(null).Create(manager, hc, hc.idfCase));
            Assert.AreEqual(1, hc.AntimicrobialTherapy.Count);
            hc.Validation -= hc_Validation_AntimicrobialTherapy_msgId;

            hc.AntimicrobialTherapy[0].datFirstAdministeredDate = DateTime.Now.Date;
            hc.AntimicrobialTherapy[0].strAntimicrobialTherapyName = "test";
            hc.AntimicrobialTherapy[0].strDosage = "3";
            hc.AntimicrobialTherapyUsed =
                hc.AntimicrobialTherapyUsedLookup.Where(c => c.strDefault == "No").SingleOrDefault();
            hc.Validation += hc_Validation_YNAntimicrobialTherapy_Antimicrobial;
            Assert.AreEqual("Yes", hc.AntimicrobialTherapyUsed.strDefault);
            hc.AntimicrobialTherapyUsed = null;
            Assert.IsNotNull(hc.AntimicrobialTherapyUsed);
            Assert.AreEqual("Yes", hc.AntimicrobialTherapyUsed.strDefault);
            hc.Validation -= hc_Validation_YNAntimicrobialTherapy_Antimicrobial;

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            hc = acc.SelectByKey(manager, id);
            Assert.IsNotNull(hc);
            Assert.AreEqual(id, hc.idfCase);

            Assert.AreEqual(1, hc.AntimicrobialTherapy.Count);
            Assert.AreEqual(id, hc.AntimicrobialTherapy[0].idfHumanCase);
            Assert.AreEqual(DateTime.Now.Date, hc.AntimicrobialTherapy[0].datFirstAdministeredDate);
            Assert.AreEqual("test", hc.AntimicrobialTherapy[0].strAntimicrobialTherapyName);
            Assert.AreEqual("3", hc.AntimicrobialTherapy[0].strDosage);
        }

        [TestMethod]
        public void TestHumanCaseFF()
        {
            var id = hc.idfCase;

            Assert.IsNotNull(hc.idfCSObservation);
            Assert.IsNotNull(hc.idfEpiObservation);

            var ffCs = hc.FFPresenterCs;
            var ffEpi = hc.FFPresenterEpi;

            Assert.IsNotNull(ffCs);
            Assert.IsNotNull(ffEpi);

            FFTests.CheckFFPresenter(ffCs);
            FFTests.CheckFFPresenter(ffEpi);

            Assert.IsNotNull(ffCs.CurrentObservation);
            Assert.IsNotNull(ffEpi.CurrentObservation);
            Assert.IsTrue(ffCs.CurrentObservation.HasValue);
            Assert.IsTrue(ffEpi.CurrentObservation.HasValue);
            Assert.IsTrue(ffCs.CurrentObservation.Value == hc.idfCSObservation);
            Assert.IsTrue(ffEpi.CurrentObservation.Value == hc.idfEpiObservation);

            Assert.IsNull(hc.idfsDiagnosis);
            Assert.IsNull(hc.idfsEPIFormTemplate);
            Assert.IsNull(hc.idfsCSFormTemplate);

            //UNI-шаблоны уже должны быть загружены

            Assert.IsNotNull(ffEpi.CurrentTemplate);
            Assert.IsNotNull(ffCs.CurrentTemplate);
            var idfsFormTemplateEpiUNI = ffEpi.CurrentTemplate.idfsFormTemplate;

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
                hc.TentativeDiagnosisLookup.SingleOrDefault(a => a.name == "Anthrax - Cutaneous");
            Assert.AreEqual(
                hc.TentativeDiagnosisLookup.Single(a => a.name == "Anthrax - Cutaneous").idfsDiagnosis,
                hc.idfsDiagnosis);

            //должен выставиться диагноз
            Assert.IsNotNull(hc.idfsEPIFormTemplate);
            Assert.IsNotNull(hc.idfsCSFormTemplate);
            //Assert.AreEqual("HEI Anthrax GG", ffEpi.CurrentTemplate.DefaultName);
            //Assert.AreEqual("HCS Anthrax - Cutaneous GG", ffCs.CurrentTemplate.DefaultName);

            //сверяем id шаблонов
            Assert.AreNotEqual(ffEpi.CurrentTemplate.idfsFormTemplate, idfsFormTemplateEpiUNI);
            //Assert.AreEqual(ffCs.CurrentTemplate.idfsFormTemplate, idfsFormTemplateCsUNI);

            Assert.AreEqual(ffEpi.CurrentTemplate.idfsFormTemplate, hc.idfsEPIFormTemplate);
            Assert.AreEqual(ffCs.CurrentTemplate.idfsFormTemplate, hc.idfsCSFormTemplate);

            //вводим данные
            //отыскиваем параметр
            var parameter1 = ffEpi.CurrentTemplate.ParameterTemplates.First(c => c.Editor == FFParameterEditors.TextBox).idfsParameter;

            DateTime val = DateTime.Today;
            var apEpi = ffEpi.ActivityParameters;
            apEpi.SetActivityParameterValue(ffEpi.CurrentTemplate,
                                                                ffEpi.CurrentObservation.Value, parameter1,
                                                                val);
            Assert.AreEqual(1, apEpi.Count);
            //apEpi[0].varValue = "test";
            Assert.IsTrue(val.ToString().Equals(apEpi[0].varValue.ToString()));

            var idfsEPIFormTemplate = hc.idfsEPIFormTemplate;
            var idfsCSFormTemplate = hc.idfsCSFormTemplate;

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            Assert.AreEqual(1,
                            manager.SetCommand(
                                "Select count(*) From dbo.ffParameterForTemplate Where idfsParameter = @idfsParameter And idfsFormTemplate = @idfsFormTemplate And intRowStatus = 0"
                                , manager.Parameter("idfsParameter", ffEpi.ActivityParameters[0].idfsParameter)
                                ,
                                manager.Parameter("idfsFormTemplate",
                                                    ffEpi.ActivityParameters[0].idfsFormTemplate)
                                ).ExecuteScalar<int>());

            Assert.AreEqual(1,
                            manager.SetCommand(
                                "Select count(*) From dbo.tlbObservation Where idfObservation = @idfObservation"
                                ,
                                manager.Parameter("idfObservation", ffEpi.ActivityParameters[0].idfObservation)
                                ).ExecuteScalar<int>());

            Assert.AreEqual(1,
                            manager.SetCommand(
                                "Select count(*) From dbo.tlbActivityParameters Where [idfsParameter] = @idfsParameter And [idfObservation] = @idfObservation And [idfRow] = @idfRow"
                                , manager.Parameter("idfsParameter", ffEpi.ActivityParameters[0].idfsParameter)
                                ,
                                manager.Parameter("idfObservation", ffEpi.ActivityParameters[0].idfObservation)
                                , manager.Parameter("idfRow", ffEpi.ActivityParameters[0].idfRow)
                                ).ExecuteScalar<int>());

            //перезагружаем кейс

            var hcLoaded = acc.SelectByKey(manager, id);
            Assert.IsNotNull(hcLoaded);
            Assert.AreEqual(id, hcLoaded.idfCase);

            Assert.IsNotNull(hcLoaded.idfsEPIFormTemplate);
            Assert.IsNotNull(hcLoaded.idfsCSFormTemplate);
            Assert.IsNotNull(hcLoaded.idfEpiObservation);
            Assert.IsNotNull(hcLoaded.idfCSObservation);

            var ffEpiLoaded = hcLoaded.FFPresenterEpi;
            var ffCsLoaded = hcLoaded.FFPresenterCs;

            Assert.AreEqual(idfsEPIFormTemplate, ffEpiLoaded.CurrentTemplate.idfsFormTemplate);
            Assert.AreEqual(idfsCSFormTemplate, ffCsLoaded.CurrentTemplate.idfsFormTemplate);

            Assert.IsNotNull(ffEpiLoaded.CurrentObservation);
            Assert.IsNotNull(ffCsLoaded.CurrentObservation);
            Assert.AreEqual(ffEpiLoaded.CurrentObservation.Value, hcLoaded.idfEpiObservation);
            Assert.AreEqual(ffCsLoaded.CurrentObservation.Value, hcLoaded.idfCSObservation);

            Assert.AreEqual(idfsEPIFormTemplate, hcLoaded.idfsEPIFormTemplate);
            Assert.AreEqual(idfsCSFormTemplate, hcLoaded.idfsCSFormTemplate);
            Assert.AreEqual(1, ffEpiLoaded.ActivityParameters.Count);
            Assert.IsTrue(val.ToString().Equals(ffEpi.ActivityParameters[0].varValue.ToString()));
        }

        [TestMethod]
        public void TestHumanCaseDiagnosis()
        {
            DateTime currentDate = DateTime.Now.Date;
            Assert.AreEqual(0, hc.DiagnosisHistory.Count);
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();
            Assert.AreEqual("Anthrax - Cutaneous", hc.strDiagnosis);
            Assert.IsNull(hc.blnClinicalDiagBasis);
            Assert.IsNull(hc.blnEpiDiagBasis);
            Assert.IsNull(hc.blnLabDiagBasis);
            hc.datTentativeDiagnosisDate = currentDate.AddDays(-3);
            Assert.AreEqual(currentDate.AddDays(-3), Convert.ToDateTime(hc.strReadOnlyFinalDiagnosisDate));
            hc.blnClinicalDiagBasis = true;
            hc.blnEpiDiagBasis = true;
            hc.blnLabDiagBasis = true;
            hc.TentativeDiagnosis = hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Pulmonary").SingleOrDefault();
            Assert.AreEqual(currentDate.AddDays(-3), Convert.ToDateTime(hc.strReadOnlyFinalDiagnosisDate));
            Assert.IsNull(hc.blnClinicalDiagBasis);
            Assert.IsNull(hc.blnEpiDiagBasis);
            Assert.IsNull(hc.blnLabDiagBasis);
            hc.blnClinicalDiagBasis = true;
            hc.blnEpiDiagBasis = true;
            hc.blnLabDiagBasis = true;
            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();
            hc.datFinalDiagnosisDate = currentDate.AddDays(-2);
            Assert.AreEqual(currentDate.AddDays(-2), Convert.ToDateTime(hc.strReadOnlyFinalDiagnosisDate));
            Assert.IsNull(hc.blnClinicalDiagBasis);
            Assert.IsNull(hc.blnEpiDiagBasis);
            Assert.IsNull(hc.blnLabDiagBasis);
            hc.blnClinicalDiagBasis = true;
            hc.blnEpiDiagBasis = true;
            hc.blnLabDiagBasis = true;
            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Where(a => a.name == "Anthrax - Oropharyngeal").SingleOrDefault();
            hc.datFinalDiagnosisDate = currentDate.AddDays(-1);
            Assert.AreEqual(currentDate.AddDays(-1), Convert.ToDateTime(hc.strReadOnlyFinalDiagnosisDate));
            Assert.IsNull(hc.blnClinicalDiagBasis);
            Assert.IsNull(hc.blnEpiDiagBasis);
            Assert.IsNull(hc.blnLabDiagBasis);
            hc.blnClinicalDiagBasis = true;
            hc.blnEpiDiagBasis = true;
            hc.blnLabDiagBasis = true;
            hc.TentativeDiagnosis = hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();
            Assert.IsNull(hc.blnClinicalDiagBasis);
            Assert.IsNull(hc.blnEpiDiagBasis);
            Assert.IsNull(hc.blnLabDiagBasis);
            hc.datFinalDiagnosisDate = null;
            Assert.IsNull(hc.strReadOnlyFinalDiagnosisDate);
            hc.datTentativeDiagnosisDate = currentDate;
            Assert.IsNull(hc.strReadOnlyFinalDiagnosisDate);
            hc.datTentativeDiagnosisDate = null;
            Assert.IsNull(hc.strReadOnlyFinalDiagnosisDate);
            hc.blnClinicalDiagBasis = true;
            hc.blnEpiDiagBasis = true;
            hc.blnLabDiagBasis = true;
            hc.FinalDiagnosis = null;
            Assert.IsNull(hc.blnClinicalDiagBasis);
            Assert.IsNull(hc.blnEpiDiagBasis);
            Assert.IsNull(hc.blnLabDiagBasis);
            hc.blnClinicalDiagBasis = true;
            hc.blnEpiDiagBasis = true;
            hc.blnLabDiagBasis = true;
            hc.TentativeDiagnosis = null;
            Assert.IsNull(hc.blnClinicalDiagBasis);
            Assert.IsNull(hc.blnEpiDiagBasis);
            Assert.IsNull(hc.blnLabDiagBasis);
        }

        [TestMethod]
        public void TestHumanCaseDiagnosisHistory()
        {
            long id = hc.idfCase;

            Assert.AreEqual(0, hc.DiagnosisHistory.Count);
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();
            Assert.AreEqual("Anthrax - Cutaneous", hc.strDiagnosis);
            Assert.AreEqual(0, hc.DiagnosisHistory.Count);
            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Where(a => a.name == "Anthrax - Pulmonary").SingleOrDefault();
            Assert.AreEqual("Anthrax - Pulmonary", hc.strDiagnosis);
            Assert.AreEqual(1, hc.DiagnosisHistory.Count);
            Assert.IsNull(hc.DiagnosisHistory[0].PreviousDiagnosisName);
            Assert.AreEqual("Anthrax - Pulmonary", hc.DiagnosisHistory[0].CurrentDiagnosisName);
            var reason0 = hc.DiagnosisHistory[0].ChangeDiagnosisReasonLookup.Where(a => a.name == "Misdiagnosis").SingleOrDefault();
            var reason1 = hc.DiagnosisHistory[0].ChangeDiagnosisReasonLookup.Where(a => a.name == "Additional clinical development").SingleOrDefault();
            var reason2 =  hc.DiagnosisHistory[0].ChangeDiagnosisReasonLookup.Where(a => a.name == "Unknown").SingleOrDefault();
            hc.DiagnosisHistory[0].idfsChangeDiagnosisReason = reason0.idfsBaseReference;
               
            Assert.AreEqual(ModelUserContext.Instance.CurrentUser.Organization,
                            hc.DiagnosisHistory[0].Organization);
            Assert.AreEqual(ModelUserContext.Instance.CurrentUser.FullName, hc.DiagnosisHistory[0].PersonName);
            Assert.AreEqual((long)ModelUserContext.Instance.CurrentUser.ID, hc.DiagnosisHistory[0].idfUserID);
            Assert.AreEqual((long)ModelUserContext.Instance.CurrentUser.EmployeeID,
                            hc.DiagnosisHistory[0].idfPerson);
            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Where(a => a.name == "Anthrax - Oropharyngeal").SingleOrDefault();
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.strDiagnosis);
            Assert.AreEqual(1, hc.DiagnosisHistory.Count);
            Assert.IsNull(hc.DiagnosisHistory[0].PreviousDiagnosisName);
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.DiagnosisHistory[0].CurrentDiagnosisName);

            // mandatory for posting
            hc.Patient.strLastName = "last";
            hc.Patient.strFirstName = "first";
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                    SingleOrDefault();

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            hc = acc.SelectByKey(manager, id);
            Assert.IsNotNull(hc);
            Assert.AreEqual(1, hc.DiagnosisHistory.Count);
            Assert.IsTrue(string.IsNullOrEmpty(hc.DiagnosisHistory[0].PreviousDiagnosisName));
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.DiagnosisHistory[0].CurrentDiagnosisName);
            Assert.AreEqual(reason0.idfsBaseReference, hc.DiagnosisHistory[0].idfsChangeDiagnosisReason);

            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Where(a => a.name == "Anthrax - Pulmonary").SingleOrDefault();
            Assert.AreEqual(2, hc.DiagnosisHistory.Count);
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.DiagnosisHistory[1].PreviousDiagnosisName);
            Assert.AreEqual("Anthrax - Pulmonary", hc.DiagnosisHistory[1].CurrentDiagnosisName);

            hc.FinalDiagnosis = null;
            Assert.AreEqual(2, hc.DiagnosisHistory.Count);
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.DiagnosisHistory[1].PreviousDiagnosisName);
            Assert.IsNull(hc.DiagnosisHistory[1].CurrentDiagnosisName);

            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Where(a => a.name == "Anthrax - Pulmonary").SingleOrDefault();
            Assert.AreEqual("Anthrax - Pulmonary", hc.strDiagnosis);
            Assert.AreEqual(2, hc.DiagnosisHistory.Count);
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.DiagnosisHistory[1].PreviousDiagnosisName);
            Assert.AreEqual("Anthrax - Pulmonary", hc.DiagnosisHistory[1].CurrentDiagnosisName);
            hc.DiagnosisHistory[1].idfsChangeDiagnosisReason = reason1.idfsBaseReference;
            Assert.AreEqual(ModelUserContext.Instance.CurrentUser.Organization,
                            hc.DiagnosisHistory[1].Organization);
            Assert.AreEqual(ModelUserContext.Instance.CurrentUser.FullName, hc.DiagnosisHistory[1].PersonName);
            Assert.AreEqual((long)ModelUserContext.Instance.CurrentUser.ID, hc.DiagnosisHistory[1].idfUserID);
            Assert.AreEqual((long)ModelUserContext.Instance.CurrentUser.EmployeeID,
                            hc.DiagnosisHistory[1].idfPerson);

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            hc = acc.SelectByKey(manager, id);
            Assert.IsNotNull(hc);
            Assert.AreEqual(2, hc.DiagnosisHistory.Count);
            Assert.IsTrue(string.IsNullOrEmpty(hc.DiagnosisHistory[0].PreviousDiagnosisName));
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.DiagnosisHistory[0].CurrentDiagnosisName);
            Assert.AreEqual(reason0.idfsBaseReference, hc.DiagnosisHistory[0].idfsChangeDiagnosisReason);
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.DiagnosisHistory[1].PreviousDiagnosisName);
            Assert.AreEqual("Anthrax - Pulmonary", hc.DiagnosisHistory[1].CurrentDiagnosisName);
            Assert.AreEqual(reason1.idfsBaseReference, hc.DiagnosisHistory[1].idfsChangeDiagnosisReason);

            hc = acc.SelectByKey(manager, id);
            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Where(a => a.name == "Anthrax - Pulmonary").SingleOrDefault();

            Assert.AreEqual(2, hc.DiagnosisHistory.Count);
            Assert.IsTrue(string.IsNullOrEmpty(hc.DiagnosisHistory[0].PreviousDiagnosisName));
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.DiagnosisHistory[0].CurrentDiagnosisName);
            Assert.AreEqual(reason0.idfsBaseReference, hc.DiagnosisHistory[0].idfsChangeDiagnosisReason);
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.DiagnosisHistory[1].PreviousDiagnosisName);
            Assert.AreEqual("Anthrax - Pulmonary", hc.DiagnosisHistory[1].CurrentDiagnosisName);
            Assert.AreEqual(reason1.idfsBaseReference, hc.DiagnosisHistory[1].idfsChangeDiagnosisReason);

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            hc = acc.SelectByKey(manager, id);
            Assert.AreEqual(2, hc.DiagnosisHistory.Count);
            Assert.IsTrue(string.IsNullOrEmpty(hc.DiagnosisHistory[0].PreviousDiagnosisName));
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.DiagnosisHistory[0].CurrentDiagnosisName);
            Assert.AreEqual(reason0.idfsBaseReference, hc.DiagnosisHistory[0].idfsChangeDiagnosisReason);
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.DiagnosisHistory[1].PreviousDiagnosisName);
            Assert.AreEqual("Anthrax - Pulmonary", hc.DiagnosisHistory[1].CurrentDiagnosisName);
            Assert.AreEqual(reason1.idfsBaseReference, hc.DiagnosisHistory[1].idfsChangeDiagnosisReason);

            hc.FinalDiagnosis = null;
            hc.DiagnosisHistory[2].idfsChangeDiagnosisReason = reason2.idfsBaseReference;//Unknown
            Assert.AreEqual(3, hc.DiagnosisHistory.Count);
            Assert.AreEqual("Anthrax - Pulmonary", hc.DiagnosisHistory[2].PreviousDiagnosisName);
            Assert.IsNull(hc.DiagnosisHistory[2].CurrentDiagnosisName);
            Assert.AreEqual(reason2.idfsBaseReference, hc.DiagnosisHistory[2].idfsChangeDiagnosisReason);

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            hc = acc.SelectByKey(manager, id);
            Assert.AreEqual(3, hc.DiagnosisHistory.Count);
            Assert.AreEqual("Anthrax - Pulmonary", hc.DiagnosisHistory[2].PreviousDiagnosisName);
            Assert.IsTrue(string.IsNullOrEmpty(hc.DiagnosisHistory[2].CurrentDiagnosisName));
            Assert.AreEqual(reason2.idfsBaseReference, hc.DiagnosisHistory[2].idfsChangeDiagnosisReason);

            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Where(a => a.name == "Anthrax - Pulmonary").SingleOrDefault();
            hc.DiagnosisHistory[3].idfsChangeDiagnosisReason = reason1.idfsBaseReference;//Patient died
            Assert.AreEqual(4, hc.DiagnosisHistory.Count);
            Assert.IsTrue(string.IsNullOrEmpty(hc.DiagnosisHistory[3].PreviousDiagnosisName));
            Assert.AreEqual("Anthrax - Pulmonary", hc.DiagnosisHistory[3].CurrentDiagnosisName);
            Assert.AreEqual(reason1.idfsBaseReference, hc.DiagnosisHistory[3].idfsChangeDiagnosisReason);

            hc.FinalDiagnosis = hc.FinalDiagnosisLookup.Where(a => a.name == "Anthrax - Oropharyngeal").SingleOrDefault();
            Assert.AreEqual(4, hc.DiagnosisHistory.Count);
            Assert.IsTrue(string.IsNullOrEmpty(hc.DiagnosisHistory[3].PreviousDiagnosisName));
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.DiagnosisHistory[3].CurrentDiagnosisName);
            Assert.AreEqual(reason1.idfsBaseReference, hc.DiagnosisHistory[3].idfsChangeDiagnosisReason);

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            hc = acc.SelectByKey(manager, id);
            Assert.AreEqual(4, hc.DiagnosisHistory.Count);
            Assert.IsTrue(string.IsNullOrEmpty(hc.DiagnosisHistory[3].PreviousDiagnosisName));
            Assert.AreEqual("Anthrax - Oropharyngeal", hc.DiagnosisHistory[3].CurrentDiagnosisName);
            Assert.AreEqual(reason1.idfsBaseReference, hc.DiagnosisHistory[3].idfsChangeDiagnosisReason);
        }

        [TestMethod]
        public void TestHumanCaseGeoLocation()
        {
            long id = hc.idfCase;

            // mandatory for posting
            hc.Patient.strLastName = "last";
            hc.Patient.strFirstName = "first";
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                    SingleOrDefault();
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();

            Assert.IsTrue(hc.PointGeoLocation.IsNull);
            Assert.IsNull(hc.PointGeoLocation.Country);
            Assert.IsNull(hc.PointGeoLocation.Region);
            Assert.IsNull(hc.PointGeoLocation.Rayon);
            Assert.IsNull(hc.PointGeoLocation.Settlement);

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            hc = acc.SelectByKey(manager, id);
            Assert.IsNotNull(hc);
            Assert.AreEqual(id, hc.Patient.idfCase);

            Assert.IsTrue(hc.PointGeoLocation.IsNull);
            Assert.IsNull(hc.PointGeoLocation.Country);
            Assert.IsNull(hc.PointGeoLocation.Region);
            Assert.IsNull(hc.PointGeoLocation.Rayon);
            Assert.IsNull(hc.PointGeoLocation.Settlement);
            Assert.AreEqual("", hc.PointGeoLocation.FullName);
            acc.CreateGeoLocation(manager, hc);
            Assert.IsFalse(hc.PointGeoLocation.IsNull);
            Assert.AreEqual("",
                            hc.PointGeoLocation.FullName);
            Assert.AreEqual(hc.Patient.CurrentResidenceAddress.Country.strCountryName,
                            hc.PointGeoLocation.Country.strCountryName);
            Assert.AreEqual(hc.Patient.CurrentResidenceAddress.Region.strRegionName,
                            hc.PointGeoLocation.Region.strRegionName);
            Assert.AreEqual(hc.Patient.CurrentResidenceAddress.Rayon.strRayonName,
                            hc.PointGeoLocation.Rayon.strRayonName);
            Assert.IsNull(hc.PointGeoLocation.Settlement);

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            hc = acc.SelectByKey(manager, id);
            Assert.IsNotNull(hc);
            Assert.AreEqual(id, hc.Patient.idfCase);

            Assert.IsFalse(hc.PointGeoLocation.IsNull);
            Assert.AreEqual(hc.Patient.CurrentResidenceAddress.Country.strCountryName,
                            hc.PointGeoLocation.Country.strCountryName);
            Assert.AreEqual(hc.Patient.CurrentResidenceAddress.Region.strRegionName,
                            hc.PointGeoLocation.Region.strRegionName);
            Assert.AreEqual(hc.Patient.CurrentResidenceAddress.Rayon.strRayonName,
                            hc.PointGeoLocation.Rayon.strRayonName);
            Assert.IsNull(hc.PointGeoLocation.Settlement);

            hc.PointGeoLocation.Rayon = null;

            hc.Validation += hc_Validation_GeoLocation_idfsRayon;
            Assert.IsFalse(acc.Post(manager, hc));
            hc.Validation -= hc_Validation_GeoLocation_idfsRayon;
        }

        [TestMethod]
        public void TestHumanCaseAge()
        {
            // By default in Age no value If date of birth is not specified yet
            // but they have to save values if date of birth cleared
            //Assert.IsNull(hc.intPatientAge);
            //Assert.IsNull(hc.idfsHumanAgeType);
            Assert.IsNull(hc.Patient.intPatientAgeFromCase);
            Assert.IsNull(hc.Patient.idfsHumanAgeTypeFromCase);
            Assert.IsNull(hc.Patient.HumanAgeType);
            //Assert.IsFalse(hc.IsReadOnly("intPatientAge"));
            //Assert.IsFalse(hc.IsReadOnly("idfsHumanAgeType"));
            Assert.IsFalse(hc.Patient.IsReadOnly("intPatientAgeFromCase"));
            Assert.IsFalse(hc.Patient.IsReadOnly("idfsHumanAgeTypeFromCase"));
            Assert.IsFalse(hc.Patient.IsReadOnly("HumanAgeType"));
            hc.Patient.datDateofBirth = DateTime.Now.AddYears(-1);
            //Assert.IsNotNull(hc.intPatientAge);
            //Assert.IsNotNull(hc.idfsHumanAgeType);
            Assert.IsNotNull(hc.Patient.intPatientAgeFromCase);
            Assert.IsNotNull(hc.Patient.idfsHumanAgeTypeFromCase);
            Assert.IsNotNull(hc.Patient.HumanAgeType);
            //Assert.IsTrue(hc.IsReadOnly("intPatientAge"));
            //Assert.IsTrue(hc.IsReadOnly("idfsHumanAgeType"));
            Assert.IsTrue(hc.Patient.IsReadOnly("intPatientAgeFromCase"));
            Assert.IsTrue(hc.Patient.IsReadOnly("idfsHumanAgeTypeFromCase"));
            Assert.IsTrue(hc.Patient.IsReadOnly("HumanAgeType"));
            hc.Patient.datDateofBirth = null;
            //Assert.IsNotNull(hc.intPatientAge);
            //Assert.IsNotNull(hc.idfsHumanAgeType);
            Assert.IsNotNull(hc.Patient.intPatientAgeFromCase);
            Assert.IsNotNull(hc.Patient.idfsHumanAgeTypeFromCase);
            Assert.IsNotNull(hc.Patient.HumanAgeType);
            //Assert.IsFalse(hc.IsReadOnly("intPatientAge"));
            //Assert.IsFalse(hc.IsReadOnly("idfsHumanAgeType"));
            Assert.IsFalse(hc.Patient.IsReadOnly("intPatientAgeFromCase"));
            Assert.IsFalse(hc.Patient.IsReadOnly("idfsHumanAgeTypeFromCase"));
            Assert.IsFalse(hc.Patient.IsReadOnly("HumanAgeType"));
            hc.Patient.intPatientAgeFromCase = null;
            hc.Patient.HumanAgeType = null;
            //Assert.IsNull(hc.intPatientAge);
            //Assert.IsNull(hc.idfsHumanAgeType);
            Assert.IsNull(hc.Patient.intPatientAgeFromCase);
            Assert.IsNull(hc.Patient.idfsHumanAgeTypeFromCase);
            Assert.IsNull(hc.Patient.HumanAgeType);
            //Assert.IsFalse(hc.IsReadOnly("intPatientAge"));
            //Assert.IsFalse(hc.IsReadOnly("idfsHumanAgeType"));
            Assert.IsFalse(hc.Patient.IsReadOnly("intPatientAgeFromCase"));
            Assert.IsFalse(hc.Patient.IsReadOnly("idfsHumanAgeTypeFromCase"));
            Assert.IsFalse(hc.Patient.IsReadOnly("HumanAgeType"));

            //Rules for calculating age by date of birth (DOB) are as follows:
            //    1. If the value of the Date of symptoms onset field is not blank, then date of symptoms is used for calculating age and age units;
            //    2. If the value of the Date of symptoms onset field is blank and the value of the Notification date field is not blank, then notification date is used for calculating age and age units;
            //    3. If the value of the Date of symptoms onset and Notification date fields are blank, then the value of the Entered Date field is used for calculating age and age units; case entered date is always specified automatically by the system.
            //    4. Let D be the date which is used for calculating age and age type. 
            //        a.	If the difference between D and DOB is equal to or greater than a year, then age is a number of complete years of the patient on the date D, and age type is “Years”.
            //        b.	If the difference between D and DOB is less than a year and equal to or greater than a month, then age is a number of complete months of the patient on the date D, and age type is “Month”.
            //        c.	If the difference between D and DOB is less than a month, then age is a number of days of the patient on the date D, and age type is “Days”
            Assert.IsNull(hc.Patient.intPatientAgeFromCase);
            DateTime DOB = DateTime.Now.AddYears(-1).AddDays(-10);
            hc.Patient.datDateofBirth = DOB;
            Assert.AreEqual(DOB, hc.Patient.datDateofBirth);
            //Assert.AreEqual(1, hc.intPatientAgeYears);
            //Assert.AreEqual(12, hc.intPatientAgeMonths);
            Assert.AreEqual(1, hc.Patient.intPatientAgeFromCase);
            Assert.AreEqual("Years", hc.Patient.HumanAgeType.strDefault);
            DOB = DateTime.Now.AddMonths(-2).AddDays(-10);
            hc.Patient.datDateofBirth = DOB;
            Assert.AreEqual(DOB, hc.Patient.datDateofBirth);
            //Assert.AreEqual(0, hc.intPatientAgeYears);
            //Assert.AreEqual(2, hc.intPatientAgeMonths);
            Assert.AreEqual(2, hc.Patient.intPatientAgeFromCase);
            Assert.AreEqual("Month", hc.Patient.HumanAgeType.strDefault);
            DOB = DateTime.Now.AddDays(-10);
            hc.Patient.datDateofBirth = DOB;
            Assert.AreEqual(DOB, hc.Patient.datDateofBirth);
            //Assert.AreEqual(0, hc.intPatientAgeYears);
            //Assert.AreEqual(0, hc.intPatientAgeMonths);
            Assert.AreEqual(10, hc.Patient.intPatientAgeFromCase);
            Assert.AreEqual("Days", hc.Patient.HumanAgeType.strDefault);
            Assert.IsNull(hc.datOnSetDate);
            hc.datOnSetDate = DateTime.Now.AddDays(-5);
            Assert.IsNotNull(hc.datOnSetDate);
            Assert.AreEqual(5, hc.Patient.intPatientAgeFromCase);
        }

        [TestMethod]
        public void TestHumanCaseAddresses()
        {
            long id = hc.idfCase;
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();
            hc.Patient.strLastName = "last";
            hc.Patient.strFirstName = "first";

            // addresses
            Assert.IsNotNull(hc.RegistrationAddress);
            Assert.IsNotNull(hc.Patient.CurrentResidenceAddress);
            Assert.IsNotNull(hc.Patient.EmployerAddress);
            Assert.IsNotNull(hc.Patient.RegistrationAddress);
            Assert.AreEqual(hc.RegistrationAddress.idfGeoLocation, hc.Patient.RegistrationAddress.idfGeoLocation);
            Assert.AreSame(hc.RegistrationAddress, hc.Patient.RegistrationAddress);

            // The Region and Rayon information in Current Residence fields group is mandatory
            hc.Validation += hc_Validation_idfsCountry;
            Assert.IsFalse(acc.Post(manager, hc));
            hc.Validation -= hc_Validation_idfsCountry;

            // If the Region has been changed or cleared, the Rayon, Town or Village, Street, Postal Code and Building/House/Apt. become blank and Street, Postal Code and Building/House/Apt. become disabled.
            // If the Rayon has been changed or cleared, the Rayon, Town or Village, Street, Postal Code and Building/House/Apt. become blank and Street, Postal Code and Building/House/Apt. become disabled.
            // After the Town or Village is specified, the Street, Postal Code and Building/House/Apt. become enabled. Each time the Town or Village is changed with not blank value, the Street, Postal Code and Building/House/Apt. become blank.
            // If the Town or Village has been cleared, the Street, Postal Code and Building/House/Apt. become blank and disabled.
            Assert.AreEqual("", hc.Patient.CurrentResidenceAddress.strStreetName);
            Assert.AreEqual("", hc.Patient.CurrentResidenceAddress.strPostCode);
            Assert.AreEqual("", hc.Patient.CurrentResidenceAddress.strHouse);
            Assert.AreEqual("", hc.Patient.CurrentResidenceAddress.strBuilding);
            Assert.AreEqual("", hc.Patient.CurrentResidenceAddress.strApartment);
            Assert.IsNotNull(hc.Patient.CurrentResidenceAddress.Country);
            Assert.AreEqual("Georgia", hc.Patient.CurrentResidenceAddress.Country.strCountryName);
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsInvisible("strForeignAddress"));
            Assert.IsTrue(string.IsNullOrEmpty(hc.Patient.CurrentResidenceAddress.strForeignAddress));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("Region"));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsRegion"));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("Rayon"));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsRayon"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("Settlement"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsSettlement"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strStreetName"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strPostCode"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strHouse"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strBuilding"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strApartment"));
            hc.Patient.CurrentResidenceAddress.blnReadOnlyRegion = false;
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Greece").
                    SingleOrDefault();
            Assert.AreEqual("Greece", hc.Patient.CurrentResidenceAddress.Country.strCountryName);
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsInvisible("strForeignAddress"));
            Assert.IsTrue(string.IsNullOrEmpty(hc.Patient.CurrentResidenceAddress.strForeignAddress));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("Region"));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsRegion"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("Rayon"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsRayon"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("Settlement"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsSettlement"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strStreetName"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strPostCode"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strHouse"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strBuilding"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strApartment"));
            hc.Patient.CurrentResidenceAddress.blnReadOnlyRegion = true;
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Ghana").
                    SingleOrDefault();
            Assert.AreEqual("Ghana", hc.Patient.CurrentResidenceAddress.Country.strCountryName);
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsInvisible("strForeignAddress"));
            Assert.IsTrue(string.IsNullOrEmpty(hc.Patient.CurrentResidenceAddress.strForeignAddress));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("Region"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsRegion"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("Rayon"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsRayon"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("Settlement"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsSettlement"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strStreetName"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strPostCode"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strHouse"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strBuilding"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strApartment"));
            hc.Patient.CurrentResidenceAddress.strForeignAddress = "Test Address";
            Assert.AreEqual("Test Address", hc.Patient.CurrentResidenceAddress.strForeignAddress);
            hc.Patient.CurrentResidenceAddress.blnReadOnlyRegion = false;
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                    SingleOrDefault();
            Assert.AreEqual("Georgia", hc.Patient.CurrentResidenceAddress.Country.strCountryName);
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsInvisible("strForeignAddress"));
            Assert.IsTrue(string.IsNullOrEmpty(hc.Patient.CurrentResidenceAddress.strForeignAddress));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("Region"));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsRegion"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("Rayon"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsRayon"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("Settlement"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsSettlement"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strStreetName"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strPostCode"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strHouse"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strBuilding"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strApartment"));
            //hc.Patient.CurrentResidenceAddress.Country =
            //    hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
            //        SingleOrDefault();
            //Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("Region"));
            //Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsRegion"));
            hc.Patient.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                    SingleOrDefault();
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("Rayon"));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsRayon"));
            hc.Patient.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                    SingleOrDefault
                    ();
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("Settlement"));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("idfsSettlement"));
            hc.Patient.CurrentResidenceAddress.Settlement =
                hc.Patient.CurrentResidenceAddress.SettlementLookup.Where(c => c.strSettlementName == "Zegani")
                    .
                    SingleOrDefault();
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("strStreetName"));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("strPostCode"));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("strHouse"));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("strBuilding"));
            Assert.IsFalse(hc.Patient.CurrentResidenceAddress.IsReadOnly("strApartment"));
            hc.Patient.CurrentResidenceAddress.strStreetName = "1";
            hc.Patient.CurrentResidenceAddress.strPostCode = "2";
            hc.Patient.CurrentResidenceAddress.strHouse = "3";
            hc.Patient.CurrentResidenceAddress.strBuilding = "4";
            hc.Patient.CurrentResidenceAddress.strApartment = "5";
            Assert.AreEqual("1", hc.Patient.CurrentResidenceAddress.strStreetName);
            Assert.AreEqual("2", hc.Patient.CurrentResidenceAddress.strPostCode);
            Assert.AreEqual("3", hc.Patient.CurrentResidenceAddress.strHouse);
            Assert.AreEqual("4", hc.Patient.CurrentResidenceAddress.strBuilding);
            Assert.AreEqual("5", hc.Patient.CurrentResidenceAddress.strApartment);
            //Assert.AreEqual("2, Georgia, Abkhazia, Gagra, Zegani, 1 4 - 3 - 5",
            //                hc.Patient.CurrentResidenceAddress.FullName);
            hc.Patient.CurrentResidenceAddress.Settlement = null;
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strStreetName"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strPostCode"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strHouse"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strBuilding"));
            Assert.IsTrue(hc.Patient.CurrentResidenceAddress.IsReadOnly("strApartment"));
            Assert.AreEqual("", hc.Patient.CurrentResidenceAddress.strStreetName);
            Assert.AreEqual("", hc.Patient.CurrentResidenceAddress.strPostCode);
            Assert.AreEqual("", hc.Patient.CurrentResidenceAddress.strHouse);
            Assert.AreEqual("", hc.Patient.CurrentResidenceAddress.strBuilding);
            Assert.AreEqual("", hc.Patient.CurrentResidenceAddress.strApartment);

            // In the field Location of Exposure if Known 
            // By default the Region, Rayon and Town or Village equal to the corresponding fields in Current Residence of the patient 
            hc.Patient.CurrentResidenceAddress.Settlement =
                hc.Patient.CurrentResidenceAddress.SettlementLookup.Where(c => c.strSettlementName == "Zegani")
                    .
                    SingleOrDefault();
            Assert.IsTrue(hc.PointGeoLocation.IsNull);
            acc.CreateGeoLocation(manager, hc);
            Assert.IsFalse(hc.PointGeoLocation.IsNull);
            Assert.AreEqual(hc.Patient.CurrentResidenceAddress.Country.strCountryName,
                            hc.PointGeoLocation.Country.strCountryName);
            Assert.AreEqual(hc.Patient.CurrentResidenceAddress.Region.strRegionName,
                            hc.PointGeoLocation.Region.strRegionName);
            Assert.AreEqual(hc.Patient.CurrentResidenceAddress.Rayon.strRayonName,
                            hc.PointGeoLocation.Rayon.strRayonName);
            Assert.IsNull(hc.PointGeoLocation.Settlement);

            hc.Patient.CurrentResidenceAddress.Settlement =
                hc.Patient.CurrentResidenceAddress.SettlementLookup.Where(c => c.strSettlementName == "Veli").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.strStreetName = "1";
            hc.Patient.CurrentResidenceAddress.strPostCode = "2";
            hc.Patient.CurrentResidenceAddress.strHouse = "3";
            hc.Patient.CurrentResidenceAddress.strBuilding = "4";
            hc.Patient.CurrentResidenceAddress.strApartment = "5";
            Assert.AreEqual("1", hc.Patient.CurrentResidenceAddress.strStreetName);
            Assert.AreEqual("2", hc.Patient.CurrentResidenceAddress.strPostCode);
            Assert.AreEqual("3", hc.Patient.CurrentResidenceAddress.strHouse);
            Assert.AreEqual("4", hc.Patient.CurrentResidenceAddress.strBuilding);
            Assert.AreEqual("5", hc.Patient.CurrentResidenceAddress.strApartment);
            //Assert.AreEqual("2, Georgia, Abkhazia, Gagra, Village Veli, 1 4 - 3 - 5",
            //                hc.Patient.CurrentResidenceAddress.FullName);
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();

            Assert.AreEqual(1, hc.Patient.CurrentResidenceAddress.StreetLookup.Count);
            Assert.AreEqual(1, hc.Patient.CurrentResidenceAddress.PostCodeLookup.Count);

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            hc = acc.SelectByKey(manager, id);
            Assert.IsNotNull(hc);
            Assert.AreEqual(id, hc.idfCase);

            Assert.AreEqual("2, Georgia, Abkhazia, Gagra, Village Veli, 1 4 - 3 - 5",
                            hc.Patient.CurrentResidenceAddress.FullName);
            Assert.AreEqual(2, hc.Patient.CurrentResidenceAddress.StreetLookup.Count);
            Assert.AreEqual(2, hc.Patient.CurrentResidenceAddress.PostCodeLookup.Count);
            Assert.AreEqual("1", hc.Patient.CurrentResidenceAddress.StreetLookup[1].strStreetName);
            Assert.AreEqual("2", hc.Patient.CurrentResidenceAddress.PostCodeLookup[1].strPostCode);
        }


        private void hc_ValidationContinue(object sender, ValidationEventArgs args)
        {
            args.Continue = true;
        }

        private void hc_Validation(object sender, ValidationEventArgs args)
        {
        }

        private void hc_Validation_GeoLocation_idfsRayon(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("ErrMandatoryFieldRequired", args.MessageId);
        }

        private void hc_Validation_YNAntimicrobialTherapy_Antimicrobial(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("mbCannotDeleteAllAntibiotics", args.MessageId);
        }

        private void hc_Validation_AntimicrobialTherapy_msgId(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("ErrMandatoryFieldRequired", args.MessageId);
        }

        private void hc_Validation_idfsSpecimenType_msgId(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("ErrMandatoryFieldRequired", args.MessageId);
        }

        private void hc_Validation_idfsYNSpecimenCollected_msgId(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("mbCannotDeleteAllSpecimens", args.MessageId);
        }

        private void hc_Validation_ContactedPerson_msgId(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("ErrMandatoryFieldRequired", args.MessageId);
        }

        private void hc_Validation_idfsTentativeDiagnosis(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("idfsTentativeDiagnosis", args.FieldName);
        }

        private void hc_Validation_strLastName(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Patient.strLastName", args.FieldName);
        }

        private void hc_Validation_idfsFinalDiagnosis_idfsTentativeDiagnosis(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("idfsFinalDiagnosis_idfsTentativeDiagnosis_msgId", args.MessageId);
        }

        private void hc_Validation_Hospitalization_Reject(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("mbSureToDisableHosp", args.MessageId);
        }

        private void hc_Validation_Hospitalization_Confirm(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("mbSureToDisableHosp", args.MessageId);
            args.Continue = true;
        }

        private void hc_Validation_idfsCountry(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("ErrMandatoryFieldRequired", args.MessageId);
        }

        private void hc_Validation_datDateofBirth_CurrentDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Birth_Current date", args.MessageId);
        }

        private void hc_Validation_datDateofBirth_datNotificationDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Birth_Notification date", args.MessageId);
        }

        private void hc_Validation_datDateofBirth_datTentativeDiagnosisDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Birth_Diagnosis date", args.MessageId);
        }

        private void hc_Validation_datDateofBirth_datFinalDiagnosisDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Birth_Date of changed diagnosis", args.MessageId);
        }

        private void hc_Validation_datDateofBirth_datEnteredDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Birth_Date Entered", args.MessageId);
        }

        private void hc_Validation_datDateofBirth_datFieldCollectionDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Birth_Sample Collection Date", args.MessageId);
        }

        private void hc_Validation_datDateofBirth_datFieldSentDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Birth_Sample sent date", args.MessageId);
        }

        private void hc_Validation_datDateofBirth_datAccession(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Birth_Accession Date", args.MessageId);
        }

        private void hc_Validation_datDateofBirth_datFacilityLastVisit(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Birth_Date of last visit to employer, school, children's facility", args.MessageId);
        }

        private void hc_Validation_datDateofBirth_datOnSetDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Birth_Date of symptoms onset", args.MessageId);
        }

        private void hc_Validation_datEnteredDate_CurrentDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date Entered_Current date", args.MessageId);
        }

        private void hc_Validation_datNotificationDate_datEnteredDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Notification date_Date Entered", args.MessageId);
        }

        private void hc_Validation_datOnSetDate_datEnteredDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of symptoms onset_Date Entered", args.MessageId);
        }

        private void hc_Validation_datTentativeDiagnosisDate_datEnteredDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Diagnosis date_Date Entered", args.MessageId);
        }

        private void hc_Validation_datNotificationDate_CurrentDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Notification date_Current date", args.MessageId);
        }

        private void hc_Validation_datTentativeDiagnosisDate_datNotificationDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Diagnosis date_Notification date", args.MessageId);
        }

        private void hc_Validation_datOnSetDate_CurrentDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of symptoms onset_Current date", args.MessageId);
        }

        private void hc_Validation_datOnSetDate_datTentativeDiagnosisDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of symptoms onset_Diagnosis date", args.MessageId);
        }

        private void hc_Validation_datOnSetDate_datFinalDiagnosisDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of symptoms onset_Date of changed diagnosis", args.MessageId);
        }

        private void hc_Validation_datOnSetDate_datFieldCollectionDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of symptoms onset_Sample Collection Date", args.MessageId);
        }

        private void hc_Validation_datOnSetDate_datFieldSentDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of symptoms onset_Sample Sent Date", args.MessageId);
        }

        private void hc_Validation_datOnSetDate_datAccession(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of symptoms onset_Accession Date", args.MessageId);
        }

        private void hc_Validation_datTentativeDiagnosisDate_datFinalDiagnosisDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Diagnosis date_Date of changed diagnosis", args.MessageId);
        }

        private void hc_Validation_datTentativeDiagnosisDate_datFieldCollectionDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Diagnosis date_Sample Collection Date", args.MessageId);
        }

        private void hc_Validation_datTentativeDiagnosisDate_datFieldSentDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Diagnosis date_Sample sent date", args.MessageId);
        }

        private void hc_Validation_datTentativeDiagnosisDate_datAccession(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Diagnosis date_Accession Date", args.MessageId);
        }

        private void hc_Validation_datDateofBirth_datDateOfLastContact(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Birth_Date of last contact", args.MessageId);
        }

        private void hc_Validation_datDateofBirth_datHospitalizationDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Birth_Date of hospitalization", args.MessageId);
        }

        private void hc_Validation_datDateofBirth_datFirstSoughtCareDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Birth_Date of patient first sought care", args.MessageId);
        }

        private void hc_Validation_datExposureDate_datOnSetDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of Exposure_Date of symptoms onset", args.MessageId);
        }

        private void hc_Validation_datTentativeDiagnosisDate_datCompletionPaperFormDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Diagnosis date_Date of completion of paper form", args.MessageId);
        }

        private void hc_Validation_datCompletionPaperFormDate_datNotificationDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date of completion of paper form_Notification date", args.MessageId);
        }

        private void hc_Validation_datModificationDate_CurrentDate(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("Date Last Saved_Current date", args.MessageId);
        }

    }


    [TestClass]
    public class HumanCaseTest2 : EidssEnvWithLogin
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void TestHumanCaseList()
        {
            HumanCaseListItem.Accessor acc = HumanCaseListItem.Accessor.Instance(null);
            HumanCaseListItem hi = acc.CreateNewT(manager, null);

            Assert.AreEqual("Georgia", hi.Country.strCountryName);
            Assert.IsTrue(hi.RegionLookup.Count > 1);
            //Assert.IsTrue(hi.RayonLookup.Count == 1);
            Assert.IsTrue(hi.SettlementLookup.Count == 1);

            hi.Region = hi.RegionLookup.Where(c => c.idfsRegion == 37020000000).SingleOrDefault();
            Assert.AreEqual("Abkhazia", hi.Region.strRegionName);
            Assert.IsTrue(hi.RayonLookup.Count > 1);
            Assert.IsTrue(hi.SettlementLookup.Count == 1);

            hi.Rayon = hi.RayonLookup.Where(c => c.idfsRayon == 3260000000).SingleOrDefault();
            Assert.AreEqual("Gagra", hi.Rayon.strRayonName);
            Assert.IsTrue(hi.SettlementLookup.Count > 1);

            hi.Settlement = hi.SettlementLookup.Where(c => c.idfsSettlement == 259730000000).SingleOrDefault();
            Assert.AreEqual("Achmarda", hi.Settlement.strSettlementName);

            hi.Region = hi.RegionLookup.Where(c => c.idfsRegion == 37030000000).SingleOrDefault();
            Assert.AreEqual("Adjara", hi.Region.strRegionName);
            Assert.IsNull(hi.Rayon);
            Assert.IsNull(hi.Settlement);
            Assert.IsTrue(hi.RayonLookup.Count > 1);
            Assert.IsTrue(hi.SettlementLookup.Count == 1);

            hi.Region = hi.RegionLookup.Where(c => c.idfsRegion == 37020000000).SingleOrDefault();
            hi.Rayon = hi.RayonLookup.Where(c => c.idfsRayon == 3260000000).SingleOrDefault();
            hi.Settlement = hi.SettlementLookup.Where(c => c.idfsSettlement == 259730000000).SingleOrDefault();
        }


        [TestMethod]
        public void TestHumanCase_Clone()
        {
            HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);

            HumanCase hc = acc.CreateNewT(manager, null);
            Assert.IsNotNull(hc);
            Assert.AreSame(hc, hc.Patient.Parent);

            var hcclone = hc.Clone() as HumanCase;
            Assert.AreNotSame(hc, hcclone);
            Assert.AreSame(hcclone, hcclone.Patient.Parent);

            var hcclone2 = hc.CloneWithSetup(manager) as HumanCase;
            Assert.AreNotSame(hc, hcclone2);
            Assert.IsNotNull(hcclone2.Patient);
            Assert.AreSame(hcclone2, hcclone2.Patient.Parent);
        }

        [TestMethod]
        public void TestHumanCase_Leak()
        {
            TestHumanCase_Leak_inner1();
        }

        private void TestHumanCase_Leak_inner1()
        {
            WeakReference r = TestHumanCase_Leak_inner2();
            Assert.IsTrue(r.IsAlive);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Assert.IsFalse(r.IsAlive);
        }

        private WeakReference TestHumanCase_Leak_inner2()
        {
            HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);
            HumanCase hc = acc.CreateNewT(manager, null);
            Assert.IsNotNull(hc);
            return new WeakReference(hc);
        }


        [TestMethod]
        public void TestHumanCaseDeleteFromList()
        {
            HumanCaseListItem.Accessor acclist = HumanCaseListItem.Accessor.Instance(null);
            HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);

            HumanCase hc = acc.CreateNewT(manager, null);
            Assert.IsNotNull(hc);
            long id = hc.idfCase;

            // mandatory for posting
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();
            hc.Patient.strLastName = "last";
            hc.Patient.strFirstName = "first";
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                    SingleOrDefault();

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            var filters = new FilterParams();
            filters.Add("strCaseID", "=", hc.strCaseID);
            List<HumanCaseListItem> list = acclist.SelectListT(manager, filters);
            Assert.AreEqual(1, list.Count);

            Assert.IsTrue(acclist.Actions.Where(c => c.Name == "Delete").SingleOrDefault().RunAction(manager, list[0]).result);

            list = acclist.SelectListT(manager, filters);
            Assert.AreEqual(0, list.Count);
        }


        [TestMethod]
        public void TestHumanCaseListCount()
        {
            HumanCaseListItem.Accessor acclist = HumanCaseListItem.Accessor.Instance(null);
            HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);

            long count = acclist.SelectCount(manager).Value;

            HumanCase hc = acc.CreateNewT(manager, null);
            Assert.IsNotNull(hc);
            long id = hc.idfCase;

            // mandatory for posting
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();
            hc.Patient.strLastName = "last";
            hc.Patient.strFirstName = "first";
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                    SingleOrDefault();

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            var filters = new FilterParams();
            filters.Add("strCaseID", "=", hc.strCaseID);
            List<HumanCaseListItem> list = acclist.SelectListT(manager, filters);
            Assert.AreEqual(1, list.Count);

            Assert.AreEqual(count + 1, acclist.SelectCount(manager));
        }


        [TestMethod]
        public void TestHumanCaseEnteredBy()
        {
            HumanCaseListItem.Accessor acclist = HumanCaseListItem.Accessor.Instance(null);
            HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);

            HumanCase hc = acc.CreateNewT(manager, null);
            Assert.IsNotNull(hc);
            long id = hc.idfCase;

            Assert.IsNotNull(hc.idfPersonEnteredBy);
            Assert.AreEqual((long)EidssUserContext.User.EmployeeID, hc.idfPersonEnteredBy);
            Assert.AreEqual(EidssUserContext.User.FullName.Trim(), hc.strPersonEnteredBy.Trim());

            // mandatory for posting
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();
            hc.Patient.strLastName = "last";
            hc.Patient.strFirstName = "first";
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                    SingleOrDefault();

            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            hc = acc.SelectByKey(manager, id);
            Assert.IsNotNull(hc);

            Assert.IsNotNull(hc.idfPersonEnteredBy);
            Assert.AreEqual((long)EidssUserContext.User.EmployeeID, hc.idfPersonEnteredBy);
            Assert.AreEqual(EidssUserContext.User.FullName.Trim(), hc.strPersonEnteredBy.Trim());


            var filters = new FilterParams();
            filters.Add("strCaseID", "=", hc.strCaseID);
            List<HumanCaseListItem> list = acclist.SelectListT(manager, filters);
            Assert.AreEqual(1, list.Count);

            filters.Add("idfPerson", "=", true);
            list = acclist.SelectListT(manager, filters);
            Assert.AreEqual(1, list.Count);



            hc = acc.CreateNewT(manager, null);

            // mandatory for posting
            hc.TentativeDiagnosis =
                hc.TentativeDiagnosisLookup.Where(a => a.name == "Anthrax - Cutaneous").SingleOrDefault();
            hc.Patient.strLastName = "last";
            hc.Patient.strFirstName = "first";
            hc.Patient.CurrentResidenceAddress.Country =
                hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Region =
                hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                    SingleOrDefault();
            hc.Patient.CurrentResidenceAddress.Rayon =
                hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                    SingleOrDefault();

            var personAccessor = PersonListItem.Accessor.Instance(null);
            filters = new FilterParams();
            filters.Add("idfInstitution", "=", EidssUserContext.User.OrganizationID);
            List<PersonListItem> persons = personAccessor.SelectListT(manager, filters);

            hc.idfPersonEnteredBy = persons[0].idfEmployee;
                    
            hc.Validation += hc_Validation;
            Assert.IsTrue(acc.Post(manager, hc));
            hc.Validation -= hc_Validation;

            filters = new FilterParams();
            filters.Add("strCaseID", "=", hc.strCaseID);
            list = acclist.SelectListT(manager, filters);
            Assert.AreEqual(1, list.Count);

            filters.Add("idfPerson", "=", true);
            list = acclist.SelectListT(manager, filters);
            Assert.AreEqual(0, list.Count);
        }

        private void hc_Validation(object sender, ValidationEventArgs args)
        {
        }
    }
}
