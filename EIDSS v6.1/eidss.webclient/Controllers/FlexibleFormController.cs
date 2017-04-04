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
            //var ff = ModelStorage.Get(ModelUserContext.ClientID, key, ffpresenterId.ToString()) as FFPresenterModel;
            return ObjectStorage.Using<FFPresenterModel, ActionResult>(ff =>
                {
                    if ((ff != null) && (ff.CurrentTemplate != null))
                    {
                        if (ViewBag.GridName == null) ViewBag.GridName = String.Empty;
                        ViewBag.FFKey = key;
                        ViewBag.FFpresenterId = ffpresenterId;
                        ViewBag.IDObservation = ff.CurrentObservation ?? 0;
                        ViewBag.IDRoot = root;
                        ff.Settings.WindowMode = false;
                        return PartialView("ShowFlexibleForm", ff);
                    }
                    return PartialView(isVetAggrCase ? "EmptyVetAggr" : "Empty");
                }, ModelUserContext.ClientID, key, ffpresenterId.ToString());
        }

        public ActionResult ShowTestDetailFlexibleForm(long root, long key, string name)
        {
            //var list = ModelStorage.Get(ModelUserContext.ClientID, root, name, false) as EditableList<CaseTest>;
            return ObjectStorage.Using<EditableList<CaseTest>, ActionResult>(list =>
                {
                    if (list == null)
                    {
                        return PartialView("Empty");
                    }
                    var caseTest = list.Find(t => t.idfTesting == key);
                    ObjectStorage.Put(ModelUserContext.ClientID, root, key,
                                     GetAdditionalKeyFFPresenter(caseTest.FFPresenter).ToString(),
                                     caseTest.FFPresenter);

                    var ff = caseTest.FFPresenter;

                    return PopupWindowContent(ff, root);
                }, ModelUserContext.ClientID, root, name, false);
        }


        [HttpPost]
        public ActionResult ShowTestDetailFlexibleForm(long root, long key, string name, FormCollection form)
        {
            //var list = ModelStorage.Get(ModelUserContext.ClientID, root, name, false) as EditableList<CaseTest>;
            return ObjectStorage.Using<EditableList<CaseTest>, ActionResult>(list =>
                {
                    if (list == null)
                    {
                        return PartialView("Empty");
                    }
                    var caseTest = list.Find(t => t.idfTesting == key);
                    return FlexibleFormPost(key, GetAdditionalKeyFFPresenter(caseTest.FFPresenter), caseTest.FFPresenter, form);
                }, ModelUserContext.ClientID, root, name, false);
        }

        public ActionResult SpeciesClinicalSigns(long idfCase, long idfSpecies)
        {

            return ObjectStorage.Using<VetCase, ActionResult>(vc =>
                {
                    var species = vc.Farm.FarmTree.Single(x => x.idfParty == idfSpecies);
                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance)){
                        var ff = species.FFPresenterCs.CloneWithSetup(manager) as FFPresenterModel;

                        ObjectStorage.Put(ModelUserContext.ClientID, idfCase, idfCase, ff.CurrentObservation.ToString(), ff);

                        return PopupWindowContent(ff, idfCase, true);
                    }
                }, ModelUserContext.ClientID, idfCase, null);
        }

        [HttpPost]
        public ActionResult SpeciesClinicalSigns(long idfCase, long idfSpecies, FormCollection form)
        {
            return ObjectStorage.Using<VetCase, ActionResult>(vc =>
                {
                    var species = vc.Farm.FarmTree.Single(x => x.idfParty == idfSpecies);
                    return FlexibleFormPost(idfCase, GetAdditionalKeyFFPresenter(species.FFPresenterCs), species.FFPresenterCs, form);
                }, ModelUserContext.ClientID, idfCase, null);
        }

        public ActionResult AnimalClinicalSigns(long idfCase, long idfAnimal)
        {
            return ObjectStorage.Using<VetCase, ActionResult>(vc =>
                {
                    var animal = vc.AnimalList.Single(t => t.idfAnimal == idfAnimal);
                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        var ff = animal.FFPresenterCs.CloneWithSetup(manager) as FFPresenterModel;

                        ObjectStorage.Put(ModelUserContext.ClientID, idfCase, idfCase, ff.CurrentObservation.ToString(), ff);

                        ViewBag.GridName = vc.ObjectIdent + "AnimalList";
                        return PopupWindowContent(ff, idfCase, true);
                    }
                }, ModelUserContext.ClientID, idfCase, null);
        }

        [HttpPost]
        public ActionResult AnimalClinicalSigns(long idfCase, long idfAnimal, string name, FormCollection form)
        {
            return ObjectStorage.Using<VetCase, ActionResult>(vc =>
                {
                    var animal = vc.AnimalList.Single(t => t.idfAnimal == idfAnimal);
                    return FlexibleFormPost(idfCase, GetAdditionalKeyFFPresenter(animal.FFPresenterCs), animal.FFPresenterCs, form);
                }, ModelUserContext.ClientID, idfCase, null);
        }

        [HttpGet]
        public ActionResult ShowAddFFParameterForm(long key, long ffpresenterId)
        {
            //var ff = ModelStorage.Get(ModelUserContext.ClientID, key, ffpresenterId.ToString()) as FFPresenterModel;
            return ObjectStorage.Using<FFPresenterModel, ActionResult>(ff =>
                {
                    return View(ff);
                }, ModelUserContext.ClientID, key, ffpresenterId.ToString());
        }

        [HttpPost]
        public ActionResult CopyFFPresenter(long root, long idfObservation)
        {
            //var presenter = ModelStorage.Get(ModelUserContext.ClientID, root, idfObservation.ToString()) as FFPresenterModel;
            return ObjectStorage.Using<FFPresenterModel, ActionResult>(presenter =>
                {
                    ObjectStorage.Put(ModelUserContext.ClientID, root, root, FFHelper.COPIED_PRESENTER_STORAGE_KEY, presenter);
                    //put presenter to special container
                    var json = new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    return json;
                }, ModelUserContext.ClientID, root, idfObservation.ToString());
        }

        [HttpPost]
        public ActionResult PasteFFPresenter(long root, long idfObservation)
        {
            var result = StatusOk;
            //check if buffer contains a presenter
            //var source = ModelStorage.Get(ModelUserContext.ClientID, root, FFHelper.COPIED_PRESENTER_STORAGE_KEY, false);
            return ObjectStorage.Using<object, ActionResult>(source =>
                {
                    if (source == null)
                    {
                        result = "Error";
                    }
                    else
                    {
                        //var presenter = ModelStorage.Get(ModelUserContext.ClientID, root, idfObservation.ToString()) as FFPresenterModel;
                        ObjectStorage.Using<FFPresenterModel, bool>(presenter =>
                            {
                                FFPresenterModel.Paste(source as FFPresenterModel, presenter);
                                return true;
                            }, ModelUserContext.ClientID, root, idfObservation.ToString());
                    }
                    var json = new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    return json;
                }, ModelUserContext.ClientID, root, FFHelper.COPIED_PRESENTER_STORAGE_KEY, false);
        }

        [HttpPost]
        public ActionResult DeleteFFParameters(long root, long idfObservation)
        {
            //var ff = (FFPresenterModel)ModelStorage.Get(ModelUserContext.ClientID, root, idfObservation.ToString());
            return ObjectStorage.Using<FFPresenterModel, ActionResult>(ff =>
                {
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
                }, ModelUserContext.ClientID, root, idfObservation.ToString());
        }

        [HttpPost]
        public ActionResult AddFFParameter(long root, long idfObservation, long idfsParameter)
        {
            //var ff = (FFPresenterModel)ModelStorage.Get(ModelUserContext.ClientID, root, idfObservation.ToString());
            return ObjectStorage.Using<FFPresenterModel, ActionResult>(ff =>
                {
                    if (ff.CurrentTemplate != null)
                    {
                        //проверим, что такой параметр не находится среди параметров шаблона или среди удалённых
                        var alreadyHave1 = ff.CurrentTemplate.ParameterTemplatesLookup.Any(c => c.idfsParameter == idfsParameter);
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
                                var pl = accParameter.SelectLookupList(manager, null, ff.CurrentTemplate.idfsFormType);
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
                }, ModelUserContext.ClientID, root, idfObservation.ToString());
        }

        [HttpPost]
        public ActionResult ClearFFPresenter(long root, long idfObservation)
        {
            //var presenter = ModelStorage.Get(ModelUserContext.ClientID, root, idfObservation.ToString()) as FFPresenterModel;
            return ObjectStorage.Using<FFPresenterModel, ActionResult>(presenter =>
                {
                    presenter.Clear(presenter.CurrentObservation.Value);

                    var json = new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    return json;
                }, ModelUserContext.ClientID, root, idfObservation.ToString());
        }

        [HttpGet]
        public ActionResult EditTableRow(string idfsSection, bool isNew, long idfRow, long key, string ffpresenterId)
        {
            FlexNode sectionNode = null;
            return ObjectStorage.Using<FFPresenterModel, ActionResult>(ff =>
                {
                    if (ff != null && ff.CurrentTemplate != null && idfsSection.Length > 0 &&
                        ff.CurrentObservation.HasValue)
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
                                foreach (var parameter in ff.CurrentTemplate.ParameterTemplatesLookup)
                                {
                                    if (!idParameters.Contains(parameter.idfsParameter)) continue;
                                    var ap = ff.ActivityParameters.SetActivityParameterValue(
                                        ff.CurrentTemplate
                                        , ff.CurrentObservation.Value
                                        , parameter.idfsParameter
                                        , idfRowNew
                                        , numRow
                                        , DBNull.Value
                                        , String.Empty);
                                    ap.varValue = null;
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
                }, ModelUserContext.ClientID, key, ffpresenterId, true, ForceLock: ForceReadWriteLockType.Write);
        }

        [HttpPost]
        public ActionResult EditTableRow(string idfsSection, bool isNew, long key, string ffpresenterId, FormCollection form)
        {
            return ObjectStorage.Using<FFPresenterModel, ActionResult>(ff =>
                {
                    var result = FlexibleFormPost(key, Convert.ToInt64(ffpresenterId), ff, form);
                    if (ff != null && ff.CurrentTemplate != null && idfsSection.Length > 0 &&
                        ff.CurrentObservation.HasValue)
                    {
                        ff.RebuildTemplateFlexNode();
                        var node = ff.TemplateFlexNode.FindChildNodeSection(Convert.ToInt64(idfsSection));
                        return PartialView("SectionTemplateOnlyTable", node);
                    }
                    return result;
                }, ModelUserContext.ClientID, key, ffpresenterId);
        }

        [HttpPost]
        public ActionResult CopyTableRow(string idfsSection, long idfRow, long key, string ffpresenterId)
        {
            //var ff = ModelStorage.Get(ModelUserContext.ClientID, key, ffpresenterId) as FFPresenterModel;
            return ObjectStorage.Using<FFPresenterModel, ActionResult>(ff =>
                {
                    if (ff != null && ff.CurrentTemplate != null && idfsSection.Length > 0 && ff.CurrentObservation.HasValue)
                    {
                        ff.CopyRow(Convert.ToInt64(idfsSection), idfRow);
                        var node = ff.TemplateFlexNode.FindChildNodeSection(Convert.ToInt64(idfsSection));
                        return PartialView("SectionTemplateOnlyTable", node);
                    }
                    else
                        return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "error in FlexibleFormController.CopyTableRow" };
                }, ModelUserContext.ClientID, key, ffpresenterId);
        }

        [HttpPost]
        public ActionResult DeleteTableRow(string idfsSection, long idfRow, long key, string ffpresenterId)
        {
            //var ff = ModelStorage.Get(ModelUserContext.ClientID, key, ffpresenterId) as FFPresenterModel;
            return ObjectStorage.Using<FFPresenterModel, ActionResult>(ff =>
                {
                    if (ff != null && ff.CurrentTemplate != null && idfsSection.Length > 0 && ff.CurrentObservation.HasValue)
                    {
                        ff.RemoveRow(idfRow);
                        ff.RebuildTemplateFlexNode();
                        var node = ff.TemplateFlexNode.FindChildNodeSection(Convert.ToInt64(idfsSection));
                        return PartialView("SectionTemplateOnlyTable", node);
                    }
                    else
                        return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "error in FlexibleFormController.CopyTableRow" };
                }, ModelUserContext.ClientID, key, ffpresenterId);
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

        private ActionResult FlexibleFormPost(long key, long ffpresenterId, FFPresenterModel orig, FormCollection form)
        {
            ActionResult result;
            return ObjectStorage.Using<FFPresenterModel, ActionResult>(ff =>
                {
                    if (ff == null)
                    {
                        result = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "can't restore ffpresenter" };
                    }
                    else
                    {
                        ff.Validation += ffPresenter_Validation;
                        ff.ParseFormCollection(form);
                        ff.Validate();
                        ff.Validation -= ffPresenter_Validation;

                        if (!String.IsNullOrWhiteSpace(m_Error))
                            result = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = m_Error };
                        else
                        {
                            if (ff == orig)
                            {
                                result = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = StatusOk };
                                ObjectStorage.Put(ModelUserContext.ClientID, key, key, ffpresenterId.ToString(), orig);
                            }
                            else
                            {
                                orig.Validation += ffPresenter_Validation;
                                orig.ParseFormCollection(form);
                                orig.Validate();
                                orig.Validation -= ffPresenter_Validation;
                                orig.LoadParameterTemplateReadOnly(ff.ParameterTemplateReadOnly);

                                if (!String.IsNullOrWhiteSpace(m_Error))
                                    result = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = m_Error };
                                else
                                {
                                    result = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = StatusOk };
                                    ObjectStorage.Put(ModelUserContext.ClientID, key, key, ffpresenterId.ToString(), orig);
                                }
                            }
                        }

                    }
                    return result;
                }, ModelUserContext.ClientID, key, ffpresenterId.ToString(), false);
        }

        void ffPresenter_Validation(object sender, ValidationEventArgs args)
        {
            m_Error = EidssMessages.GetValidationErrorMessage(args);
        }

        private string m_Error;
        internal const string StatusOk = "ok";
    }
}
