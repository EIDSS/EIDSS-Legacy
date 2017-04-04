using System;
using System.Linq;
using bv.model.Model.Core;
using bv.tests.Core;
using eidss.model;
using eidss.model.Core;
using eidss.model.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Enums;

namespace bv.tests.db.tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class BSSTest : EidssEnvWithLogin
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
        public void BSSCreateNew()
        {
            var accessorBSS = BasicSyndromicSurveillanceItem.Accessor.Instance(null);
            
            var bss = accessorBSS.CreateNewT(manager, null);
            Assert.IsNotNull(bss);

            #region Basic Syndromic Surveillance

            Assert.IsTrue(bss.idfBasicSyndromicSurveillance > 0);
            Assert.IsTrue(bss.strFormID == "(new)");
            Assert.IsTrue(bss.datDateEntered > DateTime.MinValue);
            Assert.IsTrue(bss.idfEnteredBy == (long) EidssUserContext.User.EmployeeID);
            Assert.IsTrue(bss.idfsSite == EidssSiteContext.Instance.SiteID);

            Assert.IsTrue(bss.BSSTypeLookup.Count > 1);
            bss.BSSType = bss.BSSTypeLookup[1];

            Assert.IsTrue(bss.HospitalLookup.Count > 1);
            bss.Hospital = bss.HospitalLookup[1];

            bss.datReportDate = bss.datDateEntered.AddDays(-1);

            bss.Patient.strLastName = "Ivanov";
            bss.Patient.strFirstName = "Ivan";
            bss.Patient.strSecondName = "Ivanovich";
            bss.Patient.datDateofBirth = new DateTime(1975, 5, 17);

            Assert.IsTrue(bss.Patient.CurrentResidenceAddress.RegionLookup.Count > 1);
            bss.Patient.CurrentResidenceAddress.Region = bss.Patient.CurrentResidenceAddress.RegionLookup[1];

            Assert.IsTrue(bss.Patient.CurrentResidenceAddress.RayonLookup.Count > 1);
            bss.Patient.CurrentResidenceAddress.Rayon = bss.Patient.CurrentResidenceAddress.RayonLookup[1];

            Assert.IsTrue(bss.Patient.CurrentResidenceAddress.SettlementLookup.Count > 1);
            bss.Patient.CurrentResidenceAddress.Settlement = bss.Patient.CurrentResidenceAddress.SettlementLookup[1];

            Assert.IsTrue(bss.intAgeYear > 0); //Full-варианты пустые, потому что они на сервере заполняются
            Assert.IsTrue(bss.intAgeFullYear == 0);
            Assert.IsTrue(bss.intAgeFullMonth == 0);

            //клинические признаки

            //сначала выставляем пол в женский, ставим беременность, потом переключаем в мужской
            //этот признак должен очиститься

            Assert.IsTrue(bss.Patient.GenderLookup.Count > 1);
            bss.Patient.Gender =
                bss.Patient.GenderLookup.FirstOrDefault(g => g.idfsBaseReference == (long) GenderType.Female);
            Assert.IsNotNull(bss.Patient.Gender);

            bss.Pregnant =
                bss.PregnantLookup.FirstOrDefault(g => g.idfsBaseReference == (long) YesNoUnknownValuesEnum.Yes);
            Assert.IsNotNull(bss.Pregnant);

            bss.PostpartumPeriod =
                bss.PostpartumPeriodLookup.FirstOrDefault(g => g.idfsBaseReference == (long) YesNoUnknownValuesEnum.Yes);
            Assert.IsNotNull(bss.PostpartumPeriod);

            bss.Patient.Gender =
                bss.Patient.GenderLookup.FirstOrDefault(g => g.idfsBaseReference == (long) GenderType.Male);
            Assert.IsNotNull(bss.Patient.Gender);

            Assert.IsNull(bss.Pregnant);
            Assert.IsNull(bss.PostpartumPeriod);

            bss.datDateOfSymptomsOnset = bss.datReportDate;

            bss.Fever = bss.FeverLookup.FirstOrDefault(g => g.idfsBaseReference == (long) YesNoUnknownValuesEnum.Yes);
            Assert.IsNotNull(bss.Fever);

            bss.MethodMeasurement =
                bss.MethodMeasurementLookup.FirstOrDefault(g => g.idfsBaseReference == (long) MethodOfMeasurement.Other);
            Assert.IsNotNull(bss.MethodMeasurement);
            bss.strMethod = "another method";

            bss.Cough = bss.CoughLookup.FirstOrDefault(g => g.idfsBaseReference == (long) YesNoUnknownValuesEnum.Yes);
            Assert.IsNotNull(bss.Cough);

            bss.ShortnessBreath =
                bss.ShortnessBreathLookup.FirstOrDefault(g => g.idfsBaseReference == (long) YesNoUnknownValuesEnum.Yes);
            Assert.IsNotNull(bss.ShortnessBreath);

            bss.SeasonalFluVaccine =
                bss.SeasonalFluVaccineLookup.FirstOrDefault(
                    g => g.idfsBaseReference == (long) YesNoUnknownValuesEnum.Yes);
            Assert.IsNotNull(bss.SeasonalFluVaccine);

            bss.datDateOfCare = bss.datReportDate;

            bss.PatientWasHospitalized =
                bss.PatientWasHospitalizedLookup.FirstOrDefault(
                    g => g.idfsBaseReference == (long) YesNoUnknownValuesEnum.Yes);
            Assert.IsNotNull(bss.PatientWasHospitalized);

            bss.Outcome = bss.OutcomeLookup.FirstOrDefault(g => g.idfsBaseReference == (long) BssOutcome.Unknown);
            Assert.IsNotNull(bss.Outcome);

            bss.PatientWasInER =
                bss.PatientWasInERLookup.FirstOrDefault(g => g.idfsBaseReference == (long) YesNoUnknownValuesEnum.Yes);
            Assert.IsNotNull(bss.PatientWasInER);

            bss.Treatment =
                bss.TreatmentLookup.FirstOrDefault(g => g.idfsBaseReference == (long) YesNoUnknownValuesEnum.Yes);
            Assert.IsNotNull(bss.Treatment);

            bss.AdministratedAntiviralMedication =
                bss.AdministratedAntiviralMedicationLookup.FirstOrDefault(
                    g => g.idfsBaseReference == (long) YesNoUnknownValuesEnum.Yes);
            Assert.IsNotNull(bss.AdministratedAntiviralMedication);

            bss.strNameOfMedication = "some Medication";

            bss.datDateReceivedAntiviralMedication = bss.Patient.datDateofBirth;

            bss.blnDiabetes = true;
            bss.blnLiver = true;

            bss.datSampleCollectionDate = bss.datDateOfCare;

            bss.strSampleID = "sample #1";

            bss.TestResult = bss.TestResultLookup.FirstOrDefault(g => g.idfsBaseReference == (long) TestResult.Positive);
            Assert.IsNotNull(bss.TestResult);

            bss.datTestResultDate = bss.datSampleCollectionDate;

            #endregion

            //сохранение 
            bss.Validation += bss_Validation;
            Assert.IsTrue(accessorBSS.Post(manager, bss));
            bss.Validation -= bss_Validation;

            //загружаем 
            var bssLoaded = accessorBSS.SelectByKey(manager, bss.idfBasicSyndromicSurveillance);
            Assert.IsNotNull(bssLoaded);

            #region Проверка загруженного объекта
            

            #endregion
        }

        void bss_Validation(object sender, ValidationEventArgs args)
        {
            
        }

        [TestMethod]
        public void BSSAggregateTest()
        {
            var accessorBSSHeader = BasicSyndromicSurveillanceAggregateHeader.Accessor.Instance(null);
            var bssHeader = accessorBSSHeader.CreateNewT(manager, null);
            Assert.IsNotNull(bssHeader);
            Assert.IsNotNull(bssHeader.BSSAggregateDetail);
            Assert.IsTrue(bssHeader.datDateEntered > DateTime.MinValue);
            Assert.IsTrue(bssHeader.datFinishDate > DateTime.MinValue);
            Assert.IsTrue(bssHeader.datStartDate > DateTime.MinValue);
            Assert.IsNull(bssHeader.datModificationForArchiveDate);
            bssHeader.intYear = 1985;
            bssHeader.intWeek = 40;

            var accessorBSSDetail = BasicSyndromicSurveillanceAggregateDetail.Accessor.Instance(null);
            var bssDetail = accessorBSSDetail.CreateNewT(manager, bssHeader);
            Assert.IsNotNull(bssDetail);
            Assert.IsNotNull(bssDetail.Parent);

            Assert.IsTrue(bssDetail.HospitalLookup.Count > 1);
            bssDetail.Hospital = bssDetail.HospitalLookup[1];
            bssDetail.intAge0_4 = 2;
            bssDetail.intAge5_14 = 22;
            bssDetail.intAge15_29 = 4;
            bssDetail.intAge30_64 = 11;
            bssDetail.intAge65 = 1;
            bssDetail.inTotalILI = 100;
            bssDetail.intTotalAdmissions = 150;
            bssDetail.intILISamples = 200;

            bssHeader.BSSAggregateDetail.Add(bssDetail);

            bssHeader.Validation += bss_Validation;
            Assert.IsTrue(accessorBSSHeader.Post(manager, bssHeader));
            bssHeader.Validation -= bss_Validation;
        }
    }
}
