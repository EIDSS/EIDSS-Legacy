using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using eidss.model.Schema;
using eidss.webclient.Utils;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.web.common.Utils;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class GridsController : Controller
    {
        public ActionResult PensideTestsGrid(long root, string name, EditableList<PensideTest> tests, bool isReadOnly, int HACode)
        {
            ViewBag.PensideTestsName = name;
            ViewBag.IsReadOnly = isReadOnly;
            string strExclude = "";
            if (HACode == (int)eidss.model.Enums.HACode.Livestock)
            {
                strExclude = "Species";
            }
            else if (HACode == (int)eidss.model.Enums.HACode.Avian)
            {
                strExclude = "AnimalID";
            }
            ViewBag.ExcludeColumns = strExclude;
            ModelStorage.Put(Session.SessionID, root, root, name, tests);
            var model = new PensideTest.PensideTestGridModelList(root, tests);
            return PartialView(model);
        }

        public ActionResult VetCaseLogGrid(long root, string name, EditableList<VetCaseLog> log, bool isReadOnly)
        {
            ViewBag.VetCaseLogName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, log);
            var model = new VetCaseLog.VetCaseLogGridModelList(root, log);
            return PartialView(model);
        }

        public ActionResult HumanAntimicrobialTherapyGrid(long root, string name, EditableList<AntimicrobialTherapy> antibiotic, bool isReadOnly)
        {
            ViewBag.AntimicrobialTherapyName = name;
            ViewBag.IsReadOnly = isReadOnly;

            ModelStorage.Put(Session.SessionID, root, root, name, antibiotic);
            var model = new AntimicrobialTherapy.AntimicrobialTherapyGridModelList(root, antibiotic);
            return PartialView(model);
        }

        public ActionResult OutbreakCaseGrid(long root, string name, EditableList<OutbreakCase> casesList, bool isReadOnly)
        {
            ViewBag.OutbreakCaseGridName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, casesList);
            var model = new OutbreakCase.OutbreakCaseGridModelList(root, casesList);
            return PartialView(model);
        }

        public ActionResult OutbreakNoteGrid(long root, string name, EditableList<OutbreakNote> notesList, bool isReadOnly)
        {
            ViewBag.OutbreakNoteGridName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, notesList);
            var model = new OutbreakNote.OutbreakNoteGridModelList(root, notesList);
            return PartialView(model);
        }


        public ActionResult HumanContactedPersonGrid(long root, string name, EditableList<ContactedCasePerson> personList, bool isReadOnly)
        {
            ViewBag.ContactedCasePersonGridName = name;
            ViewBag.IsReadOnly = isReadOnly;
            var parent = (HumanCase)((HumanCase)ModelStorage.GetRoot(Session.SessionID, root, "")).Clone();
            if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Contact_Settlement)
                || EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Contact_Details))
            {
                ViewBag.IsReadOnly = true;
                parent.AddHiddenPersonalData("GeoLocationNameWithHiddenPersonalData", c => true);
                parent.AddHiddenPersonalData("strFullName", c => true);
                if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Contact_Details))
                {
                    parent.AddHiddenPersonalData("Settlement", c => true);
                }
                ViewBag.ExcludeColumns = "strRegistrationAddress";
                AddressStringHelper.RearrangeAddressDisplayString(parent, personList);
            }
            else
            {
                ViewBag.ExcludeColumns = "GeoLocationNameWithHiddenPersonalData";
            }

            ViewBag.Parent = parent;
            ModelStorage.Put(Session.SessionID, root, root, name, personList);
            var model = new ContactedCasePerson.ContactedCasePersonGridModelList(root, personList);
            return PartialView(model);
        }

        public ActionResult HumanCaseSamplesGrid(long root, string name, EditableList<HumanCaseSample> samples, bool isReadOnly)
        {
            ViewBag.SampleName = name;
            ViewBag.IsReadOnly = isReadOnly;

            string strExclude = "";
            if (eidss.model.Core.EidssSiteContext.Instance.CustomizationPackageID == (long)eidss.model.Enums.CustomizationPackage.Azerbaijan)
            {
                strExclude = "strTestName,strTestResult,datTestPerformedDate";
            }
            ViewBag.ExcludeColumns = strExclude;

            ModelStorage.Put(Session.SessionID, root, root, name, samples);
            var model = new HumanCaseSample.HumanCaseSampleGridModelList(root, samples.Where(c => c.idfsSampleType != (long)SampleTypeEnum.Unknown));
            return PartialView(model);
        }

        public ActionResult VetCaseSamplesGrid(long root, string name, EditableList<VetCaseSample> samples, bool isReadOnly, int? intHACode)
        {
            string exclude = intHACode.HasValue
                                 ? ((intHACode.Value & (int) HACode.Livestock) != 0
                                        ? "strBirdStatus"
                                        : "AnimalID")
                                 : "";

            ViewBag.SampleName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.ExcludeColumns = exclude;

            ModelStorage.Put(Session.SessionID, root, root, name, samples);
            var model = new VetCaseSample.VetCaseSampleGridModelList(root, samples);
            return PartialView(model);
        }


        public ActionResult CaseTestsGrid(long root, string name, EditableList<CaseTest> tests, bool isReadOnly, int HACode, bool showSearchButton)
        {
            ViewBag.root = root;
            ViewBag.CaseTestsName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.ShowSearch = showSearchButton;
            string strExclude = "";
            if (HACode == (int)eidss.model.Enums.HACode.None) // ASSession
            {
                strExclude = "strFieldBarcode2,strBatchCode,DepartmentName,AnimalID,AnimalIDSpecies,Species";
            }
            else if (HACode == (int)eidss.model.Enums.HACode.Animal)
            {
                strExclude = "strFieldBarcode2,strFarmCode,DepartmentName,AnimalName,AnimalID,Species,datReceivedDate";
            }
            else if (HACode == (int)eidss.model.Enums.HACode.Livestock)
            {
                strExclude = "strFieldBarcode2,strFarmCode,DepartmentName,AnimalName,AnimalIDSpecies,Species,datReceivedDate";
            }
            else if (HACode == (int)eidss.model.Enums.HACode.Avian)
            {
                strExclude = "strFieldBarcode2,strFarmCode,DepartmentName,AnimalName,AnimalID,AnimalIDSpecies,datReceivedDate";
            }
            else if (HACode == (int)eidss.model.Enums.HACode.Human)
            {
                strExclude = "strFieldBarcode,strFarmCode,AnimalID,AnimalName,AnimalIDSpecies,Species";
            }
            ViewBag.ExcludeColumns = strExclude;
            ModelStorage.Put(Session.SessionID, root, root, name, tests);
            var model = new CaseTest.CaseTestGridModelList(root, tests);
            return PartialView(model);
        }

        public ActionResult CaseTestValidationsGrid(long root, string name, EditableList<CaseTestValidation> validations, bool isReadOnly, bool withCreateCaseButton)
        {
            ViewBag.CaseTestValidationsName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.WithCreateCaseButton = withCreateCaseButton;
            string strExclude = "";
            if (!withCreateCaseButton) // not ASSession
            {
                strExclude = "AnimalID";
            }
            ViewBag.ExcludeColumns = strExclude;
            ModelStorage.Put(Session.SessionID, root, root, name, validations);
            var model = new CaseTestValidation.CaseTestValidationGridModelList(root, validations);
            return PartialView(model);
        }

        public ActionResult VetCaseVaccinationGrid(long root, string name, EditableList<VaccinationListItem> items, bool readOnly)
        {
            ViewBag.root = root;
            ViewBag.GridName = name;
            ViewBag.IsReadOnly = readOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, items);
            var model = new VaccinationListItem.VaccinationListItemGridModelList(root, items);
            return PartialView(model);
        }

        public ActionResult AnimalsGrid(long root, string name, EditableList<AnimalListItem> items, bool readOnly)
        {
            ViewBag.root = root;
            ViewBag.GridName = name;
            ViewBag.IsReadOnly = readOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, items);
            var model = new AnimalListItem.AnimalListItemGridModelList(root, items);
            return PartialView(model);
        }

        public ActionResult VectorGrid(long root, string name, EditableList<Vector> vectors, bool isReadOnly)
        {
            ViewBag.VectorsName = name;
            ViewBag.IsReadOnly = isReadOnly;

            ModelStorage.Put(Session.SessionID, root, root, name, vectors);
            var model = new Vector.VectorGridModelList(root, vectors);
            return PartialView(model);
        }

        public ActionResult VectorSampleGrid(long root, string name, EditableList<VectorSample> samples, bool isReadOnly, bool isVectorDetail)
        {
            ViewBag.SamplesName = name;
            ViewBag.IsReadOnly = isReadOnly;

            var excColumns = "idfsVectorType,idfsSampleType,idfFieldCollectedByOffice,idfsAccessionCondition,idfSendToOffice";
            if (isVectorDetail) excColumns += ",strVectorID,strVectorType,strVectorSubTypeName";

            ViewBag.ExcludeColumns = excColumns;

            ModelStorage.Put(Session.SessionID, root, root, name, samples);
            var model = new VectorSample.VectorSampleGridModelList(root, samples);
            return PartialView(model);
        }

        public ActionResult VectorFieldTestGrid(long root, string name, EditableList<VectorFieldTest> fieldTests, bool isReadOnly, bool isVectorDetail)
        {
            ViewBag.FieldTestsName = name;
            ViewBag.IsReadOnly = isReadOnly;
            var excColumns = "idfMaterial,idfsPensideTestName,idfsPensideTestCategory,idfTestedByOffice,idfTestedByPerson,idfsPensideTestResult,idfsDiagnosis";
            if (isVectorDetail) excColumns += ",strVectorID,strVectorTypeName,strVectorSubTypeName";
            ViewBag.ExcludeColumns = excColumns;
            ModelStorage.Put(Session.SessionID, root, root, name, fieldTests);
            var model = new VectorFieldTest.VectorFieldTestGridModelList(root, fieldTests);
            return PartialView(model);
        }

        public ActionResult VectorLabTestGrid(long root, string name, EditableList<VectorLabTest> labTests, bool isReadOnly, bool isVectorDetail)
        {
            ViewBag.LabTestsName = name;
            ViewBag.IsReadOnly = isReadOnly;
            var excColumns = isVectorDetail ? "idfTesting,strVectorID,strVectorTypeName,strVectorSubTypeName" : String.Empty;
            excColumns += ",HasAmendmentHistory";
            ViewBag.ExcludeColumns = excColumns;
            ModelStorage.Put(Session.SessionID, root, root, name, labTests);
            var model = new VectorLabTest.VectorLabTestGridModelList(root, labTests);
            return PartialView(model);
        }

        public ActionResult VsSessionSummariesGrid(long root, string name, EditableList<VsSessionSummary> summaries, bool isReadOnly)
        {
            ViewBag.SummariesName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.ExcludeColumns = "idfsVectorType,idfsVectorSubType,idfsSex";

            ModelStorage.Put(Session.SessionID, root, root, name, summaries);
            var model = new VsSessionSummary.VsSessionSummaryGridModelList(root, summaries);
            return PartialView(model);
        }

        public ActionResult VsSessionSummaryDiagnosisListGrid(long root, string name, EditableList<VsSessionSummaryDiagnosis> diagnosislist, bool isReadOnly)
        {
            ViewBag.DiagnosisListName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.ExcludeColumns = "idfsDiagnosis";

            ModelStorage.Put(Session.SessionID, root, root, name, diagnosislist);
            var model = new VsSessionSummaryDiagnosis.VsSessionSummaryDiagnosisGridModelList(root, diagnosislist);
            return PartialView(model);
        }

        public ActionResult AsCampaignDiseasesAndSpeciesGrid(long root, string name, EditableList<AsDisease> diseaseslist, bool isReadOnly)
        {
            ViewBag.GridName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.ExcludeColumns = "idfCampaignToDiagnosis,intOrder";
            ViewBag.Root = root;

            ModelStorage.Put(Session.SessionID, root, root, name, diseaseslist);
            var model = new AsDisease.AsDiseaseGridModelList(root, diseaseslist);
            return PartialView(model);
        }

        public ActionResult AsCampaignSessionsGrid(long root, string name, EditableList<AsMonitoringSession> sessionslist, bool isReadOnly)
        {
            ViewBag.GridName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.ExcludeColumns = "idfMonitoringSession";
            ViewBag.Root = root;

            ModelStorage.Put(Session.SessionID, root, root, name, sessionslist);
            var model = new AsMonitoringSession.AsMonitoringSessionGridModelList(root, sessionslist);
            return PartialView(model);
        }

        public ActionResult AsSessionDiseasesGrid(long root, string name, EditableList<AsSessionDisease> diseaseslist, bool isReadOnly)
        {
            ViewBag.GridName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.ExcludeColumns = "idfMonitoringSessionToDiagnosis,idfMonitoringSession,intOrder";
            ViewBag.Root = root;

            ModelStorage.Put(Session.SessionID, root, root, name, diseaseslist);
            var model = new AsSessionDisease.AsSessionDiseaseGridModelList(root, diseaseslist);
            return PartialView(model);
        }

        public ActionResult AsSessionFarmsGrid(long root, string name, List<AsSessionFarm> itemslist, bool isReadOnly, bool blnIsDetailsFarm, bool blnIsSummaryFarm)
        {
            ViewBag.GridName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.IsDetailsFarm = blnIsDetailsFarm;
            ViewBag.IsSummaryFarm = blnIsSummaryFarm;
            ViewBag.Root = root;
            ModelStorage.Put(Session.SessionID, root, root, name, itemslist);
            var model = new AsSessionFarm.AsSessionFarmGridModelList(root, itemslist);
            return PartialView(model);
        }

        public ActionResult AsSessionAnimalsSamplesGrid(long root, string name, EditableList<AsSessionAnimalSample> itemslist, bool isReadOnly)
        {
            ViewBag.GridName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.Root = root;
            ViewBag.AsSessionAnimalSamplePageable = ((int)Session["iSetPagable" + root] == 1);
            ModelStorage.Put(Session.SessionID, root, root, name, itemslist);
            var model = new AsSessionAnimalSample.AsSessionAnimalSampleGridModelList(root, itemslist);
            return PartialView(model);
        }

        public ActionResult AsSessionSummaryGrid(long root, string name, EditableList<AsSessionSummary> summaryitemslist, bool isReadOnly)
        {
            ViewBag.GridName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.ExcludeColumns = "idfMonitoringSessionSummary";
            ViewBag.Root = root;

            ModelStorage.Put(Session.SessionID, root, root, name, summaryitemslist);
            var model = new AsSessionSummary.AsSessionSummaryGridModelList(root, summaryitemslist);
            return PartialView(model);
        }

        public ActionResult AsSessionActionsGrid(long root, string name, EditableList<AsSessionAction> actionslist, bool isReadOnly)
        {
            ViewBag.GridName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.ExcludeColumns = "idfMonitoringSessionAction";
            ViewBag.Root = root;

            ModelStorage.Put(Session.SessionID, root, root, name, actionslist);
            var model = new AsSessionAction.AsSessionActionGridModelList(root, actionslist);
            return PartialView(model);
        }

        public ActionResult AsSessionCasesGrid(long root, string name, EditableList<AsSessionCase> caseslist, bool isReadOnly)
        {
            ViewBag.GridName = name;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.ExcludeColumns = "idfCase";
            ViewBag.Root = root;

            ModelStorage.Put(Session.SessionID, root, root, name, caseslist);
            var model = new AsSessionCase.AsSessionCaseGridModelList(root, caseslist);
            return PartialView(model);
        }
    }
}
