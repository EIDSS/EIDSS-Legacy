using System;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Extenders;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.model.Model.FlexibleForms.Helpers;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.webclient.Utils;
using System.Linq;

namespace eidss.webclient.Areas.FlexForms.Controllers
{
    public class FFPresenterController : Controller
    {
        //
        // GET: /FFPresenter/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Показ компонента в том же окне
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <param name="ffpresenterId"></param>
        /// <param name="isVetAggrCase"></param>
        /// <returns></returns>
        public ActionResult ShowFlexibleForm(long root, long key, long ffpresenterId, bool isVetAggrCase = false)
        {
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId.ToString()) as FFPresenterModel;
            if ((ff != null) && (ff.CurrentTemplate != null))
            {
                if (ViewBag.GridName == null)
                {
                    ViewBag.GridName = String.Empty;
                }
                ViewBag.FFKey = key;
                ViewBag.FFpresenterId = ffpresenterId;
                ff.Settings.WindowMode = false;
                //формируем список параметров
                ff.RefreshParameterList();

                return PartialView("ShowFlexibleForm", ff);
            }
            if (isVetAggrCase)
            {
                return PartialView("EmptyVetAggr");
            }
            return PartialView("Empty");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <param name="ffpresenter"></param>
        /// <returns></returns>
        public ActionResult ShowFlexibleFormDirect(long root, long key, FFPresenterModel ffpresenter)
        {
            if ((ffpresenter != null) && (ffpresenter.CurrentTemplate != null) && ffpresenter.CurrentObservation.HasValue)
            {
                if (ViewBag.GridName == null)
                {
                    ViewBag.GridName = String.Empty;
                }
                ViewBag.FFKey = key;
                ViewBag.FFpresenterId = ffpresenter.CurrentObservation.Value;
                ffpresenter.Settings.WindowMode = false;
                ModelStorage.Put(Session.SessionID, root, root, ffpresenter.CurrentObservation.ToString(), ffpresenter);
                
                var result = PartialView("ShowFlexibleForm", ffpresenter);
                
                return result;
            }
            return PartialView("Empty");
        }

        /// <summary>
        /// Показ компонента в отдельном окне
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <param name="ffpresenterId"></param>
        /// <returns></returns>
        public ActionResult ShowFlexibleFormWindow(long root, long key, long ffpresenterId)
        {
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId.ToString()) as FFPresenterModel;

            if ((ff != null) && (ff.CurrentTemplate != null))
            {
                if (ViewBag.GridName == null)
                    ViewBag.GridName = String.Empty;
                ff.Settings.WindowMode = true;
                return PartialView("ShowFlexibleForm", ff);
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
        }

     


        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult ShowTestDetailFlexibleForm(long root, long key, string name)
        {
            var list = ModelStorage.Get(Session.SessionID, root, name, false) as EditableList<CaseTest>;
            if (list == null) return Index();
            var caseTest = list.Find(t => t.idfTesting == key);
            ModelStorage.Put(Session.SessionID, root, key,
                             GetAdditionalKeyFFPresenter(caseTest.FFPresenter).ToString(),
                             caseTest.FFPresenter);

            var ff = caseTest.FFPresenter;

            if ((ff != null) && (ff.CurrentTemplate != null))
            {
                if (ViewBag.GridName == null)
                    ViewBag.GridName = String.Empty;
                ff.Settings.WindowMode = true;
                return PartialView("ShowFlexibleForm", ff);
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
            //return RedirectToAction("ShowFlexibleFormWindow", Extenders.GetArgs(root, key, GetAdditionalKeyFFPresenter(caseTest.FFPresenter)));
        }


        [HttpPost]
        public ActionResult ShowTestDetailFlexibleForm(long root, long key, string name, FormCollection form)
        {
            var list = ModelStorage.Get(Session.SessionID, root, name, false) as EditableList<CaseTest>;
            if (list == null) return Index();
            var caseTest = list.Find(t => t.idfTesting == key);
            return FlexibleFormPost(key, GetAdditionalKeyFFPresenter(caseTest.FFPresenter), form);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ffPresenterModel"></param>
        /// <returns></returns>
        private long GetAdditionalKeyFFPresenter(FFPresenterModel ffPresenterModel)
        {
            return ffPresenterModel.CurrentObservation.HasValue ? ffPresenterModel.CurrentObservation.Value : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ffPresenter"></param>
        /// <param name="form"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public static bool UpdateModelRoutines(FFPresenterModel ffPresenter, FormCollection form, out string errMessage)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        static void ffPresenter_Validation(object sender, ValidationEventArgs args)
        {
            m_Error = EidssMessages.GetValidationErrorMessage(args);
        }

        private static string m_Error;

        [HttpPost]
        public ActionResult ShowFlexibleFormWindow(long root, long key, long ffpresenterId, FormCollection form)
        {
            return FlexibleFormPost(key, ffpresenterId, form);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="ffpresenterId"></param>
        /// <param name="form"></param>
        /// <returns></returns>
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
                             : new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = errMessage };
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        internal const string StatusOk = "ok";

        #region Species Clinical Signs Clear/Copy/Paste functions

        public ActionResult FlexFormWithClearCopyPaste(long root, FFPresenterModel presenter)        
        {
            ModelStorage.Put(Session.SessionID, root, root,
                 presenter.CurrentObservation.ToString(),
                 presenter);                       
            return PartialView("FlexFormWithClearCopyPaste",presenter);
        }

        [HttpPost]
        public ActionResult FlexFormWithClearCopyPaste(long root, FFPresenterModel presenter, FormCollection form)
        {            
            return FlexibleFormPost(root, GetAdditionalKeyFFPresenter(presenter), form);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfCase"></param>
        /// <param name="idfAnimal"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult AnimalClinicalSigns(long idfCase, long idfAnimal, string name)
        {
            var vc = ModelStorage.Get(Session.SessionID, idfCase, null) as VetCase;
            var animal = vc.AnimalList.Single(t => t.idfAnimal == idfAnimal);
            ViewData["GridName"] = name;
            ViewData["root"] = idfCase;
            ViewData["localKey"] = idfAnimal;

            return FlexFormWithClearCopyPaste(idfCase, animal.FFPresenterCs);
        }


        [HttpPost]
        public ActionResult AnimalClinicalSigns(long idfCase, long idfAnimal, string name, FormCollection form)
        {
            var vc = ModelStorage.Get(Session.SessionID, idfCase, null) as VetCase;
            var animal = vc.AnimalList.Single(t => t.idfAnimal == idfAnimal);
            ViewData["GridName"] = name;

            return FlexibleFormPost(idfCase, GetAdditionalKeyFFPresenter(animal.FFPresenterCs), form);
        }

        public ActionResult SpeciesClinicalSigns(long idfCase, long idfParty)
        {
            var vc = ModelStorage.Get(Session.SessionID, idfCase, null) as VetCase;
            var species = vc.Farm.FarmTree.Single(x => x.idfParty == idfParty);
            ViewData["root"] = idfCase; 
            ViewData["localKey"] = idfParty;
            //ModelStorage.Put(Session.SessionID, idfCase, idfCase,
            //     GetAdditionalKeyFFPresenter(species.FFPresenterCs).ToString(),
            //     species.FFPresenterCs);
            //var ff = species.FFPresenterCs;

            //if ((ff != null) && (ff.CurrentTemplate != null))
            //{
            //    if (ViewBag.GridName == null)
            //        ViewBag.GridName = String.Empty;
            //    ff.Settings.WindowMode = true;
            //}

            return FlexFormWithClearCopyPaste(idfCase, species.FFPresenterCs);
        }

        [HttpPost]
        public ActionResult SpeciesClinicalSigns(long idfCase, long idfParty, FormCollection form)
        {
            var vc = ModelStorage.Get(Session.SessionID, idfCase, null) as VetCase;
            var species = vc.Farm.FarmTree.Single(x => x.idfParty == idfParty);
            return FlexibleFormPost(idfCase, GetAdditionalKeyFFPresenter(species.FFPresenterCs), form);
        }

        [HttpGet]
        public ActionResult ClearFFPresenter(long root, long idfObservation)
        {
            var presenter = ModelStorage.Get(Session.SessionID, root, idfObservation.ToString()) as FFPresenterModel;
            
            presenter.Clear(presenter.CurrentObservation.Value);

            var json = new JsonResult { Data = StatusOk ?? "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        [HttpGet]
        public ActionResult CopyFFPresenter(long root, long idfObservation)
        {
            var presenter = ModelStorage.Get(Session.SessionID, root, idfObservation.ToString()) as FFPresenterModel;

            ModelStorage.Put(Session.SessionID, root, root, FFHelper.COPIED_PRESENTER_STORAGE_KEY, presenter);
            //put presenter to special container
            var json = new JsonResult { Data = StatusOk, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        [HttpGet]
        public ActionResult PasteFFPresenter(long root, long idfObservation)
        {
            string result = StatusOk;
            //check if buffer contains a presenter
            var source = ModelStorage.Get(Session.SessionID, root, FFHelper.COPIED_PRESENTER_STORAGE_KEY, false);
            if (source == null)
            {
                //data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                //    Translator.GetMessageString("Error_NoClinicalSignsInClipBoard"),
                //    false, false, false);
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
        public ActionResult CopyTableRow(string idfsSection, long idfRow, long key, string ffpresenterId)
        {
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId) as FFPresenterModel;
            if ((ff != null) && (idfsSection.Length > 0)) ff.CopyRow(Convert.ToInt64(idfsSection), idfRow);
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
            return View("SectionTemplateTableEditRender", sectionNode);
        }

        [HttpPost]
        public ActionResult EditTableRow(string idfsSection, bool isNew, long key, string ffpresenterId, FormCollection form)
        {
            return FlexibleFormPost(key, Convert.ToInt64(ffpresenterId), form);
        }

        [HttpGet]
        public ActionResult RemoveTableRow(string idfsSection, long idfRow, long key, string ffpresenterId)
        {
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId) as FFPresenterModel;
            if (ff != null) ff.RemoveRow(idfRow);
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //[HttpGet]
        //public ActionResult ClearFFPresenter(long idfCase, long idfParty)
        //{
        //    var vc = ModelStorage.Get(Session.SessionID, idfCase, null) as VetCase;
        //    var species = vc.Farm.FarmTree.Single(x => x.idfParty == idfParty);
        //    var presenter = species.FFPresenterCs;

        //    CompareModel data = null;
        //    ICloneable cloneable = presenter as ICloneable;
        //    IObject clone = cloneable.Clone() as IObject;
        //    presenter.Clear(presenter.CurrentObservation.Value);

        //    data = presenter.Compare(clone);

        //    var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    return json;
        //}

        //[HttpGet]
        //public ActionResult CopyFFPresenter(long idfCase, long idfParty)
        //{
        //    var vc = ModelStorage.Get(Session.SessionID, idfCase, null) as VetCase;
        //    var species = vc.Farm.FarmTree.Single(x => x.idfParty == idfParty);
        //    var presenter = species.FFPresenterCs;

        //    ModelStorage.Put(Session.SessionID, idfCase, idfCase, FFHelper.COPIED_PRESENTER_STORAGE_KEY, presenter);
        //    //put presenter to special container
        //    var json = new JsonResult { Data = StatusOk, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    return json;
        //}

        //[HttpGet]
        //public ActionResult PasteFFPresenter(long idfCase, long idfParty)
        //{
        //    CompareModel data = null;
        //    //check if buffer contains a presenter
        //    var source = ModelStorage.Get(Session.SessionID, idfCase, FFHelper.COPIED_PRESENTER_STORAGE_KEY, false);
        //    if (source == null)
        //    {
        //        data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
        //            Translator.GetMessageString("Error_NoClinicalSignsInClipBoard"),
        //            false, false, false);
        //    }
        //    else
        //    {

        //        var vc = ModelStorage.Get(Session.SessionID, idfCase, null) as VetCase;
        //        var species = vc.Farm.FarmTree.Single(x => x.idfParty == idfParty);
        //        var presenter = species.FFPresenterCs;


        //        ICloneable cloneable = presenter as ICloneable;
        //        IObject clone = cloneable.Clone() as IObject;

        //        FFPresenterModel.Paste(source as FFPresenterModel, presenter);
        //        data = presenter.Compare(clone);
        //    }
        //    var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    return json;

        //}


        #endregion
    }
}
