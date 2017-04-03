using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Enums;
using eidss.model.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLToolkit.EditableObjects;

namespace bv.tests.db.tests
{
    [TestClass]
    public class LabSampleReceiveTests
    {
        const string Organizaton = "NCDC&PH";
        const string Admin = "test_admin";
        const string User = "test_user";
        const string AdminPassword = "test";
        const string UserPassword = "test";

        [TestMethod]
        public void TestLabSampleReceiveGeneral()
        {
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                int result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(context))
                {
                    HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);
                    LabSampleReceive.Accessor accs = LabSampleReceive.Accessor.Instance(null);
                    LabSampleReceiveItem.Accessor acci = LabSampleReceiveItem.Accessor.Instance(null);
                    manager.BeginTransaction();

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

                    hc.SpecimenCollected =
                        hc.SpecimenCollectedLookup.Where(c => c.strDefault == "Yes").SingleOrDefault();
                    Assert.AreEqual("Yes", hc.SpecimenCollected.strDefault);

                    hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
                    Assert.AreEqual(1, hc.Samples.Count);
                    Assert.AreEqual(DateTime.Now.Date, hc.Samples[0].datFieldCollectionDate);
                    hc.Samples[0].SampleType =
                        hc.Samples[0].SampleTypeLookup.Where(c => c.name == "Blood - plasma").SingleOrDefault();
                    Assert.AreEqual("Blood - plasma", hc.Samples[0].SampleType.name);

                    hc.Samples.Add(HumanCaseSample.Accessor.Instance(null).Create(manager, hc, null, null, null, null, null, null));
                    Assert.AreEqual(2, hc.Samples.Count);
                    hc.Samples[1].SampleType =
                        hc.Samples[1].SampleTypeLookup.Where(c => c.name == "Food").SingleOrDefault();
                    Assert.AreEqual("Food", hc.Samples[1].SampleType.name);


                    hc.AntimicrobialTherapyUsed =
                        hc.AntimicrobialTherapyUsedLookup.Where(c => c.strDefault == "Yes").SingleOrDefault();
                    Assert.AreEqual("Yes", hc.AntimicrobialTherapyUsed.strDefault);
                    hc.AntimicrobialTherapy.Add(AntimicrobialTherapy.Accessor.Instance(null).Create(manager, hc, hc.idfCase));
                    Assert.AreEqual(1, hc.AntimicrobialTherapy.Count);
                    Assert.AreEqual(id, hc.AntimicrobialTherapy[0].idfHumanCase);
                    hc.AntimicrobialTherapy[0].datFirstAdministeredDate = DateTime.Now.Date;
                    hc.AntimicrobialTherapy[0].strAntimicrobialTherapyName = "test";
                    hc.AntimicrobialTherapy[0].strDosage = "3";
                    hc.AntimicrobialTherapy.Add(AntimicrobialTherapy.Accessor.Instance(null).Create(manager, hc, hc.idfCase));
                    Assert.AreEqual(2, hc.AntimicrobialTherapy.Count);
                    Assert.AreEqual(id, hc.AntimicrobialTherapy[0].idfHumanCase);
                    hc.AntimicrobialTherapy[1].datFirstAdministeredDate = DateTime.Now.Date;
                    hc.AntimicrobialTherapy[1].strAntimicrobialTherapyName = "test2";
                    hc.AntimicrobialTherapy[1].strDosage = "6";

                    hc.Validation += v_Validation;
                    Assert.IsTrue(acc.Post(manager, hc));
                    hc.Validation -= v_Validation;

                    hc = acc.SelectByKey(manager, id);
                    Assert.IsNotNull(hc);
                    Assert.AreEqual(id, hc.idfCase);
                    Assert.AreEqual(2, hc.Samples.Count);
                    Assert.AreEqual(2, hc.AntimicrobialTherapy.Count);

                    LabSampleReceive ls = accs.SelectByKey(manager, id);
                    Assert.IsNotNull(ls);
                    Assert.AreEqual(id, ls.IDCase);
                    Assert.AreEqual(2, ls.Samples.Count);
                    Assert.AreEqual(2, ls.Antibiotics.Count);

                    manager.RollbackTransaction();
                }
                EidssUserContext.Clear();
            }
        }


        private void v_Validation(object sender, ValidationEventArgs args)
        {
        }
    }
}
