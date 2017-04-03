using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using eidss.model.Core;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using bv.model.Model.Core;
using eidss.model.Enums;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class LabSampleController : BvController
    {

        [HttpGet]
        public ActionResult CaseTestValidationItemPicker(long key, string name, long id_test, long id)
        {
            return PickerInternal<CaseTestValidation.Accessor, CaseTestValidation, IObject>(key, id, name, CaseTestValidation.Accessor.Instance(null), null,
                null,
                (m, a, p) =>
                {
                    CaseTestValidation item = null;
                    var vet = p as VetCase;
                    var human = p as HumanCase;
                    var assession = p as AsSession;
                    CaseTest test = null;
                    if (human != null)
                    {
                        test = human.CaseTests.Single(c => c.idfTesting == id_test);
                    }
                    else if (vet != null)
                    {
                        test = vet.CaseTests.Single(c => c.idfTesting == id_test);
                    }
                    else if (assession != null)
                    {
                        test = assession.CaseTests.Single(c => c.idfTesting == id_test);
                    }
                    if (test != null)
                    {
                        item = a.Create(m, p, key, id_test, test.TestName, test.TestCategoryName, test.idfsDiagnosis, test.AnimalID);
                    }
                    return item;
                },
                null);
        }

        [HttpPost]
        public ActionResult CaseTestValidationItemPicker(FormCollection form)
        {
            return PickerInternal<CaseTestValidation.Accessor, CaseTestValidation, IObject>(form, CaseTestValidation.Accessor.Instance(null), null,
                p =>
                {
                    var vet = p as VetCase;
                    var human = p as HumanCase;
                    var assession = p as AsSession;
                    if (vet != null)
                        return vet.CaseTestValidations;
                    if (human != null)
                        return human.CaseTestValidations;
                    if (assession != null)
                        return assession.CaseTestValidations;
                    return null;
                },
                (i, o) => i.idfTestValidation == o.idfTestValidation,
                null);
        }

        [HttpGet]
        public ActionResult CaseTestItemPicker(long key, string name, long id, long? idfMaterial)
        {
            return PickerInternal<CaseTest.Accessor, CaseTest, IObject>(key, id, name, CaseTest.Accessor.Instance(null), null,
                (m, a, p) =>
                {
                    CaseTest item = null;
                    var vet = p as VetCase;
                    var human = p as HumanCase;
                    var assession = p as AsSession;
                    if (vet != null)
                    {
                        item = vet.CaseTests.SingleOrDefault(c => c.idfTesting == id);
                        if (item != null)
                            item.VetCaseSample = item.VetCaseSamples.SingleOrDefault(c => c.idfMaterial == item.idfMaterialVet);
                    }
                    else if (human != null)
                    {
                        item = human.CaseTests.SingleOrDefault(c => c.idfTesting == id);
                        if (item != null)
                            item.HumanCaseSample = item.HumanCaseSamples.SingleOrDefault(c => c.idfMaterial == item.idfMaterialHuman);
                    }
                    else if (assession != null)
                    {
                        item = assession.CaseTests.SingleOrDefault(c => c.idfTesting == id);
                        if (item != null)
                            item.AsSessionSample = item.AsSessionSamples.SingleOrDefault(c => c.idfMaterial == item.idfMaterialAsSession);
                    }
                    return item.CloneWithSetup(m) as CaseTest;
                },
                (m, a, p) =>
                {
                    var vet = p as VetCase;
                    var human = p as HumanCase;
                    var assession = p as AsSession;
                    return a.Create(m, p, vet != null ? vet.idfCase : (human != null ? human.idfCase : (assession != null ? assession.idfMonitoringSession : 0)));
                },
                (m, a, o) =>
                {
                    ModelStorage.Put(Session.SessionID, o.idfTesting, o.idfTesting, o.ObjectIdent + "AmendmentHistory", o.AmendmentHistory);
                    o.Diagnosis = o.DiagnosisLookup.SingleOrDefault(c => c != null && c.idfsDiagnosis == o.idfsDiagnosis);
                    if (idfMaterial.HasValue)
                    {
                        o.AsSessionSample = o.AsSessionSampleLookup.SingleOrDefault(i => i.idfMaterial == idfMaterial.Value);
                    }
                });
        }

        [HttpPost]
        public ActionResult CaseTestItemPicker(FormCollection form)
        {
            return PickerInternal<CaseTest.Accessor, CaseTest, IObject>(form, CaseTest.Accessor.Instance(null), null,
                p =>
                {
                    var vet = p as VetCase;
                    var human = p as HumanCase;
                    var assession = p as AsSession;
                    if (vet != null)
                        return vet.CaseTests;
                    if (human != null)
                        return human.CaseTests;
                    if (assession != null)
                        return assession.CaseTests;
                    return null;
                },
                (i, o) => i.idfTesting == o.idfTesting,
                null, (o, p) =>
                    {
                        var human = p as HumanCase;
                        if (human != null)
                        {
                            var sample = human.Samples.FirstOrDefault(c => c.idfMaterial == o.idfMaterialHuman);
                            if (sample != null)
                            {
                                var test = sample.Tests.FirstOrDefault(c => c.idfTesting == o.idfTesting);
                                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                                {
                                    if (test == null)
                                    {
                                        sample.Tests.Add(HumanCaseSampleTest.Accessor.Instance(null).CreateFromCaseTestT(manager, sample, new List<object> { o }));
                                    }
                                    else
                                    {
                                        HumanCaseSampleTest.Accessor.Instance(null).UpdateFromCaseTest(manager, test, new List<object> { o });
                                    }
                                }
                            }
                        }
                    }, 
                null, false, true, 
                bDeepValidation: false
                );
        }


        [HttpGet]
        public ActionResult HumanCaseSamplePicker(long key, string name, long id)
        {
            return PickerInternal<HumanCaseSample.Accessor, HumanCaseSample, HumanCase>(key, id, name, HumanCaseSample.Accessor.Instance(null), null, null,
                (m, a, p) =>
                {
                    var lastSample = p.Samples.LastOrDefault(c => !c.IsMarkedToDelete);
                    return a.Create(m, p
                        , lastSample == null ? null : lastSample.idfSendToOffice
                        , lastSample == null ? null : lastSample.idfFieldCollectedByOffice
                        , lastSample == null ? null : lastSample.idfFieldCollectedByPerson
                        , lastSample == null ? null : lastSample.strSendToOffice
                        , lastSample == null ? null : lastSample.strFieldCollectedByOffice
                        , lastSample == null ? null : lastSample.strFieldCollectedByPerson
                        );
                },
                null);
        }


        [HttpPost]
        public ActionResult SetHumanSample(FormCollection form)
        {
            return PickerInternal<HumanCaseSample.Accessor, HumanCaseSample, HumanCase>(form, HumanCaseSample.Accessor.Instance(null), null,
                p => p.Samples,
                (i, o) => i.idfMaterial == o.idfMaterial,
                SetSampleOrganizationsAndEmpoyee);
        }

        [HttpGet]
        public ActionResult VetCaseSamplePicker(long key, string name, long id)
        {
            return PickerInternal<VetCaseSample.Accessor, VetCaseSample, VetCase>(key, id, name, VetCaseSample.Accessor.Instance(null), null,
                (m, a, p) =>
                {
                    var item = p.Samples.SingleOrDefault(c => c.idfMaterial == id);
                    if (item._HACode == (int)HACode.Livestock)
                        item.Animal = (item.idfParty == null || item.AnimalListFromCase == null) ? null : item.AnimalListFromCase.SingleOrDefault(i => i.idfAnimal == item.idfParty);
                    if (item._HACode == (int)HACode.Avian)
                        item.FarmTree = (item.idfParty == null || item.VetFarmTreeFromCase == null) ? null : item.VetFarmTreeFromCase.SingleOrDefault(i => i.idfParty == item.idfParty);
                    return item.CloneWithSetup();
                },
                (m, a, p) =>
                {
                    var lastSample = p.Samples.LastOrDefault(c => !c.IsMarkedToDelete);
                    return a.Create(m, p
                        , lastSample == null ? null : lastSample.idfSendToOffice
                        , lastSample == null ? null : lastSample.idfFieldCollectedByOffice
                        , lastSample == null ? null : lastSample.idfFieldCollectedByPerson
                        , lastSample == null ? null : lastSample.strSendToOffice
                        , lastSample == null ? null : lastSample.strFieldCollectedByOffice
                        , lastSample == null ? null : lastSample.strFieldCollectedByPerson
                        );
                },
                null);
        }

        [HttpPost]
        public ActionResult SetVetSample(FormCollection form)
        {
            return PickerInternal<VetCaseSample.Accessor, VetCaseSample, VetCase>(form, VetCaseSample.Accessor.Instance(null), null,
                p => p.Samples,
                (i, o) => i.idfMaterial == o.idfMaterial,
                SetSampleOrganizationsAndEmpoyee);
        }


        private static void SetSampleOrganizationsAndEmpoyee(HumanCaseSample originalSample, HumanCaseSample tempSample)
        {
            originalSample.idfFieldCollectedByOffice = tempSample.idfFieldCollectedByOffice;
            originalSample.strFieldCollectedByOffice = tempSample.strFieldCollectedByOffice;

            originalSample.idfFieldCollectedByPerson = tempSample.idfFieldCollectedByPerson;
            originalSample.strFieldCollectedByPerson = tempSample.strFieldCollectedByPerson;

            originalSample.idfSendToOffice = tempSample.idfSendToOffice;
        }

        private static void SetSampleOrganizationsAndEmpoyee(VetCaseSample originalSample, VetCaseSample tempSample)
        {
            originalSample.idfFieldCollectedByOffice = tempSample.idfFieldCollectedByOffice;
            originalSample.strFieldCollectedByOffice = tempSample.strFieldCollectedByOffice;

            originalSample.idfFieldCollectedByPerson = tempSample.idfFieldCollectedByPerson;
            originalSample.strFieldCollectedByPerson = tempSample.strFieldCollectedByPerson;

            originalSample.idfSendToOffice = tempSample.idfSendToOffice;
        }


        [HttpGet]
        public ActionResult TestResultReport(long idfTesting, long csObjId, long typeId)
        {
            try
            {
                byte[] report;
                using (var wrapper = new ReportClientWrapper())
                {
                    var model = new LimTestResultModel(ModelUserContext.CurrentLanguage, idfTesting, csObjId, typeId,
                        ModelUserContext.Instance.IsArchiveMode);
                    report = wrapper.Client.ExportLimTestResult(model);
                }
                return ReportResponse(report, "TestResultReport.pdf");
            }
            catch
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
            }
        }

    }
}

