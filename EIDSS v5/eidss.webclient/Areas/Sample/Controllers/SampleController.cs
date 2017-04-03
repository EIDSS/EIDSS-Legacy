using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.webclient.Utils;
using Telerik.Web.Mvc;
using Telerik.Web.Mvc.UI;

namespace eidss.webclient.Areas.Sample.Controllers
{
    public class SampleController : Controller
    {
        //
        // GET: /Sample/Sample/

        //[HttpGet]
        public ActionResult ShowLabSampleReceiveGrid(long root, string name, EditableList<LabSampleReceiveItem> samples, bool isReadOnly, int HACode)
        {
            ViewData["SampleName"] = name;
            ViewData["IsReadOnly"] = isReadOnly || root == 0;
            string strExclude = "";
            if (HACode == (int)eidss.model.Enums.HACode.None) // ASSession
            {
                strExclude = "AnimalID,strFieldBarcode";
            }
            else if (HACode == (int)eidss.model.Enums.HACode.Livestock)
            {
                strExclude = "strFieldBarcode";
            }
            else if (HACode == (int)eidss.model.Enums.HACode.Avian)
            {
                strExclude = "AnimalID,strFieldBarcode";
            }
            else if (HACode == (int)eidss.model.Enums.HACode.Human)
            {
                strExclude = "AnimalID,Species,strFieldBarcode2";
            }
            ViewData["ExcludeColumns"] = strExclude;
            ModelStorage.Put(Session.SessionID, root, root, name, samples);
            var model = new LabSampleReceiveItem.LabSampleReceiveItemGridModelList(root, samples);
            return PartialView(model);
        }

        public ActionResult ShowCaseTestsGrid(long root, string name, EditableList<CaseTest> tests, bool isReadOnly, int HACode, bool showSearchButton)
        {
            ViewData["root"] = root;
            ViewData["CaseTestsName"] = name;
            ViewData["IsReadOnly"] = isReadOnly;
            ViewData["ShowSearch"] = showSearchButton;
            string strExclude = "";
            if (HACode == (int)eidss.model.Enums.HACode.None) // ASSession
            {
                strExclude = "strFieldBarcode2,strBatchCode,DepartmentName,AnimalName";
            }
            else if (HACode == (int)eidss.model.Enums.HACode.Animal)
            {
                strExclude = "strFieldBarcode2,strFarmCode,DepartmentName,AnimalID";
            }
            else if (HACode == (int)eidss.model.Enums.HACode.Human)
            {
                strExclude = "strFieldBarcode,strFarmCode,AnimalID,AnimalName,datReceivedDate";
            }
            ViewData["ExcludeColumns"] = strExclude;
            ModelStorage.Put(Session.SessionID, root, root, name, tests);
            var model = new CaseTest.CaseTestGridModelList(root, tests);
            return PartialView(model);
        }

        public ActionResult ShowPensideTestsGrid(long root, string name, EditableList<PensideTest> tests, bool isReadOnly, int HACode)
        {
            ViewData["PensideTestsName"] = name;
            ViewData["IsReadOnly"] = isReadOnly;
            string strExclude = "";
            if (HACode == (int)eidss.model.Enums.HACode.Livestock)
            {
                strExclude = "Species";
            }
            else if (HACode == (int)eidss.model.Enums.HACode.Avian)
            {
                strExclude = "AnimalID";
            }
            ViewData["ExcludeColumns"] = strExclude;
            ModelStorage.Put(Session.SessionID, root, root, name, tests);
            var model = new PensideTest.PensideTestGridModelList(root, tests);
            return PartialView(model);
        }

        public ActionResult ShowCaseTestValidationsGrid(long root, string name, EditableList<CaseTestValidation> validations, bool isReadOnly)
        {
            ViewData["CaseTestValidationsName"] = name;
            ViewData["IsReadOnly"] = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, validations);
            var model = new CaseTestValidation.CaseTestValidationGridModelList(root, validations);
            return PartialView(model);
        }

        public ActionResult ShowLabTestAmendmentHistoryGrid(long root, string name, EditableList<LabTestAmendmentHistory> history, bool isReadOnly)
        {
            ViewData["LabTestAmendmentHistoryName"] = name;
            ViewData["IsReadOnly"] = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, history);
            var model = new LabTestAmendmentHistory.LabTestAmendmentHistoryGridModelList(root, history);
            return PartialView(model);
        }


        [HttpPost]
        public ActionResult SelectSampleType(long idfMaterial)
        {
            var sampleObj = ModelStorage.Get(Session.SessionID, idfMaterial, null);
            if (sampleObj is HumanCaseSample)
            {
                var sample = sampleObj as HumanCaseSample;
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(sample.SampleTypeLookup, "idfsReference", "name") };
            }
            if (sampleObj is VetCaseSample)
            {
                var sample = sampleObj as VetCaseSample;
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(sample.SampleTypeLookup, "idfsReference", "name") };
            }
            if (sampleObj is LabSampleReceiveItem)
            {
                var sample = sampleObj as LabSampleReceiveItem;
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(sample.SampleTypeLookup, "idfsReference", "name") };
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
        }

    }
}
