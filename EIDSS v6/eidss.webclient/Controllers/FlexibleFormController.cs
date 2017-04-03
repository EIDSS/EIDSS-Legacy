using System;
using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using bv.model.Model.Core;
using bv.model.Model.Extenders;
using eidss.model.FlexibleForms.Helpers;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.model.Model.FlexibleForms.Helpers;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using bv.model.BLToolkit;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class FlexibleFormController : Controller
    {


        /// <summary>
        /// Показ компонента в том же окне
        /// </summary>
        public ActionResult ShowFlexibleForm(long root, long key, long ffpresenterId, bool isVetAggrCase = false)
        {
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId.ToString()) as FFPresenterModel;
            if ((ff != null) && (ff.CurrentTemplate != null))
            {
                if (ViewBag.GridName == null) ViewBag.GridName = String.Empty;
                ViewBag.FFKey = key;
                ViewBag.FFpresenterId = ffpresenterId;
                ViewBag.IDObservation = ff.CurrentObservation.HasValue ? ff.CurrentObservation.Value : 0;
                ViewBag.IDRoot = root;
                ff.Settings.WindowMode = false;
                return PartialView("ShowFlexibleForm", ff);
            }
            return PartialView(isVetAggrCase ? "EmptyVetAggr" : "Empty");
        }

        public ActionResult ShowTestDetailFlexibleForm(long root, long key, string name)
        {
            var list = ModelStorage.Get(Session.SessionID, root, name, false) as EditableList<CaseTest>;
            if (list == null)
            {
                return PartialView("Empty");
            }
            var caseTest = list.Find(t => t.idfTesting == key);
            ModelStorage.Put(Session.SessionID, root, key,
                             GetAdditionalKeyFFPresenter(caseTest.FFPresenter).ToString(),
                             caseTest.FFPresenter);

            var ff = caseTest.FFPresenter;

            return PopupWindowContent(ff, root);
        }


        [HttpPost]
        public ActionResult ShowTestDetailFlexibleForm(long root, long key, string name, FormCollection form)
        {
            var list = ModelStorage.Get(Session.SessionID, root, name, false) as EditableList<CaseTest>;
            if (list == null)
            {
                return PartialView("Empty");
            }
            var caseTest = list.Find(t => t.idfTesting == key);
            return FlexibleFormPost(key, GetAdditionalKeyFFPresenter(caseTest.FFPresenter), form);
        }

        public ActionResult SpeciesClinicalSigns(long idfCase, long idfSpecies)
        {
            var vc = ModelStorage.Get(Session.SessionID, idfCase, null) as VetCase;
            var species = vc.Farm.FarmTree.Single(x => x.idfParty == idfSpecies);
            var ff = species.FFPresenterCs;

            ModelStorage.Put(Session.SessionID, idfCase, idfCase, ff.CurrentObservation.ToString(), ff);

            return PopupWindowContent(ff, idfCase, true);
        }

        [HttpPost]
        public ActionResult SpeciesClinicalSigns(long idfCase, long idfSpecies, FormCollection form)
        {
            var vc = ModelStorage.Get(Session.SessionID, idfCase, null) as VetCase;
            var species = vc.Farm.FarmTree.Single(x => x.idfParty == idfSpecies);
            return FlexibleFormPost(idfCase, GetAdditionalKeyFFPresenter(species.FFPresenterCs), form);
        }

        public ActionResult AnimalClinicalSigns(long idfCase, long idfAnimal)
        {
            var vc = ModelStorage.Get(Session.SessionID, idfCase, null) as VetCase;
            var animal = vc.AnimalList.Single(t => t.idfAnimal == idfAnimal);
            
            var ff = animal.FFPresenterCs;
            ModelStorage.Put(Session.SessionID, idfCase, idfCase, ff.CurrentObservation.ToString(), ff);

            return PopupWindowContent(ff, idfCase, true);
        }

        [HttpPost]
        public ActionResult AnimalClinicalSigns(long idfCase, long idfAnimal, string name, FormCollection form)
        {
            var vc = ModelStorage.Get(Session.SessionID, idfCase, null) as VetCase;
            var animal = vc.AnimalList.Single(t => t.idfAnimal == idfAnimal);
            return FlexibleFormPost(idfCase, GetAdditionalKeyFFPresenter(animal.FFPresenterCs), form);
        }

        [HttpGet]
        public ActionResult ShowAddFFParameterForm(long key, long ffpresenterId)
        {
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId.ToString()) as FFPresenterModel;
            return View(ff);
        }

        [HttpGet]
        public ActionResult CopyFFPresenter(long root, long idfObservation)
        {
            var presenter = ModelStorage.Get(Session.SessionID, root, idfObservation.ToString()) as FFPresenterModel;

            ModelStorage.Put(Session.SessionID, root, root, FFHelper.COPIED_PRESENTER_STORAGE_KEY, presenter);
            //put presenter to special container
            var json = new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        [HttpGet]
        public ActionResult PasteFFPresenter(long root, long idfObservation)
        {
            var result = StatusOk;
            //check if buffer contains a presenter
            var source = ModelStorage.Get(Session.SessionID, root, FFHelper.COPIED_PRESENTER_STORAGE_KEY, false);
            if (source == null)
            {
                result = "Error";
            }
            else
            {
                var presenter = ModelStorage.Get(Session.SessionID, root, idfObservation.ToString()) as FFPresenterModel;
                FFPresenterModel.Paste(source as FFPresenterModel, presenter);
            }
            var json = new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        [HttpGet]
        public ActionResult DeleteFFParameters(long root, long idfObservation)
        {
            var ff = (FFPresenterModel)ModelStorage.Get(Session.SessionID, root, idfObservation.ToString());
            var deletedFromTemplates = FFHelper.GetDeletedParameters(ff.ActivityParameters, idfObservation, ff.CurrentTemplate);
            foreach (var ap in ff.ActivityParameters)
            {
                if (!ap.IsDynamicParameter || !ap.idfsParameter.HasValue) continue;
                ff.ActivityParameters.SetActivityParameterValue(ff.CurrentTemplate, idfObservation, ap.idfsParameter.Value, ap.idfRow.HasValue ? ap.idfRow.Value : 0, ap.intNumRow.HasValue ? ap.intNumRow.Value : 0, null, String.Empty, deletedFromTemplates);
            }
            //удаляем секцию динамических параметров и все узлы под ней
            ff.DeleteDynamicParametersNode();
            
            var json = new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        [HttpGet]
        public ActionResult AddFFParameter(long root, long idfObservation, long idfsParameter)
        {
            var ff = (FFPresenterModel)ModelStorage.Get(Session.SessionID, root, idfObservation.ToString());
            if (ff.CurrentTemplate != null)
            {
                //проверим, что такой параметр не находится среди параметров шаблона или среди удалённых
                var alreadyHave1 = ff.CurrentTemplate.ParameterTemplates.Any(c => c.idfsParameter == idfsParameter);
                var alreadyHave2 = false;
                if (!alreadyHave1)
                {
                    var deletedFromTemplates = FFHelper.GetDeletedParameters(ff.ActivityParameters, idfObservation, ff.CurrentTemplate);
                    alreadyHave2 = deletedFromTemplates.Any(c => c.idfsParameter == idfsParameter);
                }
                if (!alreadyHave1 && !alreadyHave2)
                {
                    //добавляем параметр в шаблон (в удалённые/динамические)
                    //для этого нужно добавить данные
                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        var accParameter = Parameter.Accessor.Instance(null);
                        var pl = accParameter.SelectDetailList(manager, null, ff.CurrentTemplate.idfsFormType);
                        var parameter = pl.FirstOrDefault(c => c.idfsParameter == idfsParameter);
                        if (parameter != null)
                        {
                            //TODO проверить, обязательно ли данные создавать
                            //создаем именно так, потому что через хелпер не сработает
                            var ap = ActivityParameter.Accessor.Instance(null)
                                                      .Create(manager
                                                              , ff.CurrentTemplate
                                                              , idfsParameter
                                                              , idfObservation
                                                              , ff.CurrentTemplate.idfsFormTemplate);

                            ap.varValue = null;
                            ff.ActivityParameters.Add(ap);

                            //
                            ff.AddDynamicParameterNode(parameter, idfObservation, ff.ActivityParameters);
                        }
                    }
                }
            }
            var json = new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        [HttpGet]
        public ActionResult ClearFFPresenter(long root, long idfObservation)
        {
            var presenter = ModelStorage.Get(Session.SessionID, root, idfObservation.ToString()) as FFPresenterModel;
            
            presenter.Clear(presenter.CurrentObservation.Value);

            var json = new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        [HttpGet]
        public ActionResult EditTableRow(string idfsSection, bool isNew, long idfRow, long key, string ffpresenterId)
        {
            FlexNode sectionNode = null;
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId) as FFPresenterModel;
            if ((ff != null) && (ff.CurrentTemplate != null) && (idfsSection.Length > 0) &&
                (ff.CurrentObservation.HasValue))
            {
                //проходим по всем столбцам-параметрами создаём фейковые ячейки данных 
                //(пустые, удалятся при сохранении, если не будут введены данные)
                //отыскиваем нод для табличной секции
                sectionNode = ff.TemplateFlexNode.FindChildNodeSection(Convert.ToInt64(idfsSection));

                if (isNew)
                {
                    var idParameters = sectionNode.GetIDParametersForSection();
                    var numRow = sectionNode.GetNumForNewRow(ff.ActivityParameters);

                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        var idfRowNew = (new GetNewIDExtender<ActivityParameter>()).GetScalar(manager, null);
                        foreach (var parameter in ff.CurrentTemplate.ParameterTemplates)
                        {
                            if (!idParameters.Contains(parameter.idfsParameter)) continue;
                            ff.ActivityParameters.SetActivityParameterValue(
                                ff.CurrentTemplate
                                , ff.CurrentObservation.Value
                                , parameter.idfsParameter
                                , idfRowNew
                                , numRow
                                , DBNull.Value
                                , String.Empty);
                        }
                        sectionNode.idfRow = ViewBag.IdfRow = idfRowNew;
                    }
                }
                else
                {
                    sectionNode.idfRow = ViewBag.IdfRow = idfRow;
                }
            }
            ViewBag.IsNew = isNew ? 1 : 0;
            ViewBag.IdfsSection = idfsSection;
            ViewBag.FFKey = key;
            ViewBag.FFPresenterId = ffpresenterId;
            return View("GridEditWindow", sectionNode);
        }

        [HttpPost]
        public ActionResult EditTableRow(string idfsSection, bool isNew, long key, string ffpresenterId, FormCollection form)
        {
            var result = FlexibleFormPost(key, Convert.ToInt64(ffpresenterId), form);
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId) as FFPresenterModel;
            if (ff != null && ff.CurrentTemplate != null && idfsSection.Length > 0 &&
                ff.CurrentObservation.HasValue)
            {
                var node = ff.TemplateFlexNode.FindChildNodeSection(Convert.ToInt64(idfsSection));
                return PartialView("SectionTemplateOnlyTable", node);
            }
            return result;
        }

        [HttpPost]
        public ActionResult CopyTableRow(string idfsSection, long idfRow, long key, string ffpresenterId)
        {
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId) as FFPresenterModel;
            if (ff != null && ff.CurrentTemplate != null && idfsSection.Length > 0 && ff.CurrentObservation.HasValue)
            {
                ff.CopyRow(Convert.ToInt64(idfsSection), idfRow);
                var node = ff.TemplateFlexNode.FindChildNodeSection(Convert.ToInt64(idfsSection));
                return PartialView("SectionTemplateOnlyTable", node);
            }
            else
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "error in FlexibleFormController.CopyTableRow" };
        }

        [HttpPost]
        public ActionResult DeleteTableRow(string idfsSection, long idfRow, long key, string ffpresenterId)
        {
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId) as FFPresenterModel;
            if (ff != null && ff.CurrentTemplate != null && idfsSection.Length > 0 && ff.CurrentObservation.HasValue)
            {
                ff.RemoveRow(idfRow);
                var node = ff.TemplateFlexNode.FindChildNodeSection(Convert.ToInt64(idfsSection));
                return PartialView("SectionTemplateOnlyTable", node);
            }
            else
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "error in FlexibleFormController.CopyTableRow" };
        }

        private ActionResult PopupWindowContent(FFPresenterModel ff, long idfCase, bool isClearCopyPasteButtonsVisible = false)
        {
            if ((ff != null) && (ff.CurrentTemplate != null))
            {
                if (ViewBag.GridName == null) ViewBag.GridName = String.Empty;
                ff.Settings.WindowMode = true;
                ViewBag.IsClearCopyPasteButtonsVisible = isClearCopyPasteButtonsVisible;
                ViewBag.RootItemId = idfCase;
                return PartialView("PopupWindowContent", ff);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
        }

        private long GetAdditionalKeyFFPresenter(FFPresenterModel ffPresenterModel)
        {
            return ffPresenterModel.CurrentObservation.HasValue ? ffPresenterModel.CurrentObservation.Value : 0;
        }

        private ActionResult FlexibleFormPost(long key, long ffpresenterId, FormCollection form)
        {
            ActionResult result;
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId.ToString(), false) as FFPresenterModel;
            if (ff == null)
            {
                result = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "can't restore ffpresenter" };
            }
            else
            {
                string errMessage;
                result = (UpdateModelRoutines(ff, form, out errMessage))
                             ? new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = StatusOk }
                             : new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = errMessage };//new { errMsg = errMessage}
            }
            return result;
        }

        private bool UpdateModelRoutines(FFPresenterModel ffPresenter, FormCollection form, out string errMessage)
        {
            errMessage = String.Empty;
            var result = true;

            ffPresenter.Validation += ffPresenter_Validation;
            ffPresenter.ParseFormCollection(form);
            ffPresenter.Validate();
            ffPresenter.Validation -= ffPresenter_Validation;

            if (!String.IsNullOrWhiteSpace(m_Error))
            {
                errMessage = m_Error;
                result = false;
            }

            return result;
        }

        void ffPresenter_Validation(object sender, ValidationEventArgs args)
        {
            m_Error = EidssMessages.GetValidationErrorMessage(args);
        }

        private string m_Error;
        internal const string StatusOk = "ok";
    }
}
