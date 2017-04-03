using System;
using System.Web.Mvc;
using System.Web.Routing;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Extenders;
using eidss.mobileclient.Attributes;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.model.Model.FlexibleForms.Helpers;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.mobileclient.Utils;

namespace eidss.mobileclient.Controllers
{
    public class FFPresenterController : Controller
    {
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
        /// <returns></returns>
        [SessionExpireFilter]
        public ActionResult ShowFlexibleForm(long root, long key, long ffpresenterId, bool canUpdate = true)
        {
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId.ToString()) as FFPresenterModel;
            
            if ((ff != null) && (ff.CurrentTemplate != null))
            {
                ViewBag.FFKey = key;
                ViewBag.FFpresenterId = ffpresenterId;
                ViewBag.CanUpdate = canUpdate;
                return PartialView("ShowFlexibleForm", ff);
            }
            return PartialView("Empty");
        }

        [SessionExpireFilter]
        public ActionResult ShowFlexibleFormDirect(long root, long key, FFPresenterModel ffpresenter, bool canUpdate = true)
        {
            //TODO определиться, нужен ли этот метод вообще

            if ((ffpresenter != null) && (ffpresenter.CurrentTemplate != null))
            {
                if (ViewBag.GridName == null)
                    ViewBag.GridName = String.Empty;

                ffpresenter.Settings.WindowMode = false;
                ModelStorage.Put(Session.SessionID, root, root, ffpresenter.CurrentObservation.ToString(), ffpresenter);
                ModelStorage.Put(Session.SessionID, root, key, ffpresenter.CurrentObservation.ToString(), ffpresenter);
                ViewBag.FFKey = key;
                ViewBag.FFpresenterId = ffpresenter.CurrentObservation.Value;
                ViewBag.CanUpdate = canUpdate;
                return PartialView("ShowFlexibleForm", ffpresenter);
            }
            return PartialView("Empty");
        }

        public ActionResult FlexNodeRender(FlexNode node, bool canUpdate = true)
        {
            ViewBag.CanUpdate = canUpdate;
            node.FFModel.ReadOnly = !canUpdate;
            return PartialView(node);
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
            ViewBag.UrlForReturn = Session["ReturnUrl"];
            return View("SectionTemplateTableEditRender", sectionNode);
        }

        [HttpPost]
        public ActionResult EditTableRow(long key, string ffpresenterId, FormCollection form)
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
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [SessionExpireFilter]
        public ActionResult ShowFarmTreeFlexibleForm(long root, long key, string name, bool canUpdate = true)
        {
            var list = ModelStorage.Get(Session.SessionID, root, name) as EditableList<VetFarmTree>;
            if (list == null)
            {
                return PartialView("Empty");
            }
            var vetFarmTree = list.Find(t => t.idfParty == key);
            long ffPresenterKey = GetAdditionalKeyFFPresenter(vetFarmTree.FFPresenterCs);
            Session["idfSpecies"] = key;
            Session["FfPresenterKey"] = ffPresenterKey;
            IObjectPermissions permission = vetFarmTree.GetPermissions();
            bool isReadOnly = permission == null ? false : permission.IsReadOnlyForEdit;
            vetFarmTree.FFPresenterCs.ReadOnly = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, key, ffPresenterKey.ToString(), vetFarmTree.FFPresenterCs);
            ViewBag.FFKey = key;
            ViewBag.FFpresenterId = ffPresenterKey;
            ViewBag.CanUpdate = canUpdate;
            return ShowFlexibleForm(root, key, ffPresenterKey);
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
            bool isDatesValid = DateTimeHelper.TryParseCustomDates(form, out errMessage);
            if (!isDatesValid)
            {
                return false;
            }

            errMessage = String.Empty;
            var result = true;

            m_Error = string.Empty;

            ffPresenter.Validation += ffPresenter_Validation;
            ffPresenter.ErrorValueType +=ffPresenter_ErrorValueType;
            ffPresenter.ParseFormCollection(form);
            ffPresenter.Validate();
            ffPresenter.ErrorValueType -= ffPresenter_ErrorValueType;
            ffPresenter.Validation -= ffPresenter_Validation;

            if (!String.IsNullOrWhiteSpace(m_Error))
            {
                errMessage = m_Error;
                result = false;
            }

            return result;
        }

        static void ffPresenter_ErrorValueType(string parameterName)
        {
            m_Error = string.Format(Translator.GetMessageString("errInvalidFieldFormat"), parameterName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        static void ffPresenter_Validation(object sender, ValidationEventArgs args)
        {
            m_Error = Translator.GetErrorMessage(args);
        }

        private static string m_Error;

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult ShowFlexibleFormWindow(FormCollection form)
        {
            long key = long.Parse(Session["IdfSpecies"].ToString());
            long ffpresenterId = long.Parse(Session["FfPresenterKey"].ToString());
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
            var ff = ModelStorage.Get(Session.SessionID, key, ffpresenterId.ToString()) as FFPresenterModel;
            if (ff == null)
            {
                result = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "can't restore ffpresenter" };
            }
            else
            {
                string errMessage;
                result = (UpdateModelRoutines(ff, form, out errMessage))
                             ? new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null }
                             : new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = errMessage };
            }
            return result;
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult ShowFlexibleForm(long root, long key, long ffpresenterId, FormCollection form)
        {
            return FlexibleFormPost(key, ffpresenterId, form);
        }
        
        /// <summary>
        /// 
        /// </summary>
        internal const string StatusOk = "ok";
    }
}
