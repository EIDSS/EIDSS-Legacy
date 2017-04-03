using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Collections.Specialized;
using System.Web;
using Kendo.Mvc.UI;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Enums;
using BLToolkit.EditableObjects;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class ASCampaignController : BvController
    {

        #region Campaign
        public ActionResult Index()
        {
            return IndexInternal<AsCampaignListItem.Accessor, AsCampaignListItem, AsCampaignListItem.AsCampaignListItemGridModelList>
                (AsCampaignListItem.Accessor.Instance(null), AutoGridRoots.AsCampaignList, false);
        }

        public ActionResult IndexAjax([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax<AsCampaignListItem.Accessor, AsCampaignListItem, AsCampaignListItem.AsCampaignListItemGridModelList>
                (form, AsCampaignListItem.Accessor.Instance(null), AutoGridRoots.AsCampaignList, request);
        }

        public ActionResult Details(long? id)
        {
            return DetailsInternal<AsCampaign.Accessor, AsCampaign>(id, AsCampaign.Accessor.Instance(null), null, null, null, null, null);
        }
        

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            return DetailsInternalAjax<AsCampaign.Accessor, AsCampaign>(form, AsCampaign.Accessor.Instance(null), null, null, null, null);
        }

        [HttpGet]
        public ActionResult RemoveSession(long idfCampaign, long idfSession)
        {
            var camp = ModelStorage.Get(Session.SessionID, idfCampaign, null) as AsCampaign;

            int sessionIndexInList = camp.Sessions.FindIndex(x=>x.idfMonitoringSession == idfSession);
            if (sessionIndexInList > -1)
            {
                camp.Sessions[sessionIndexInList].MarkToDelete();
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Invalid input", JsonRequestBehavior.AllowGet);         
            }

        }

        [HttpGet]
        public ActionResult ASCampaignDiseasesPicker(long key, string name, long id)
        {
            return PickerInternal<AsDisease.Accessor, AsDisease, AsCampaign>(key, id, name, AsDisease.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.CreateNewT(m, p),
                null);
        }

        [HttpPost]
        public ActionResult SetASCampaignDiseases(FormCollection form)
        {
            return PickerInternal<AsDisease.Accessor, AsDisease, AsCampaign>(form, AsDisease.Accessor.Instance(null), null,
                p => p.Diseases,
                (i, o) => i.idfCampaignToDiagnosis == o.idfCampaignToDiagnosis,
                null);
        }

        #endregion

        private int m_ignoreErr = 0;
        void object_ValidationDetails(object sender, ValidationEventArgs args)
        {
            if (m_ignoreErr == 1)
            {
                args.Continue = true;
            }
            else
            {
                ViewBag.ErrorMessage = Translator.GetErrorMessage(args).Replace("*Species*", args.PropertyName);
            }
            /*ViewBag.ErrorMessage = EidssMessages.GetValidationErrorMessage(args).Replace("*Species*", args.PropertyName);
            if (args.Pars != null && args.Pars.Length > 0)
            {
                ViewBag.ErrorType = args.Pars[0];
            }*/
        }

        public ActionResult MoveItem(long key, string name, long? idfAsDisease, int moveDirection)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<AsDisease>;
            if (list.Count(d => !d.IsMarkedToDelete) > 0)
            {
                var d1 = list.Single(d => d.idfCampaignToDiagnosis == idfAsDisease);

                if (moveDirection > 0)
                {
                    var list1 = list.Where(d => d.intOrder > d1.intOrder && !d.IsMarkedToDelete);
                    if (list1.Count() > 0)
                    {
                        var newseq = list1.Min(c => c.intOrder);
                        var d2 = list1.Single(d => d.intOrder == newseq);
                        d2.intOrder = d1.intOrder;
                        d1.intOrder = newseq;
                    }
                }
                else
                {
                    var list1 = list.Where(d => d.intOrder < d1.intOrder && !d.IsMarkedToDelete);
                    if (list1.Count() > 0)
                    {
                        var newseq = list1.Max(c => c.intOrder);
                        var d2 = list1.Single(d => d.intOrder == newseq);
                        d2.intOrder = d1.intOrder;
                        d1.intOrder = newseq;
                    }
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
        }

        [HttpPost]
        public ActionResult SetSelectedASSession(string root, string selectedId)
        {
            long key = long.Parse(root);
            var campaign = ModelStorage.Get(Session.SessionID, key, null) as AsCampaign;
            key = long.Parse(selectedId);
            
            try
            {
                AsCampaign.AssignCampaignToSession(campaign, key);
            }
            catch (ValidationModelException e)
            {
                ViewData["ErrorMessage"] = String.Format(EidssMessages.GetValidationErrorMessage(e), e.Pars);
                /*if (e.Pars != null && e.Pars.Length > 0)
                {
                    ViewData["ErrorType"] = e.Pars[e.Pars.Length - 1];
                }*/
            }

            CompareModel data = new CompareModel();
            if (ViewBag.ErrorMessage != null)
            {
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", ViewBag.ErrorMessage /*String.Format("{0}:{1}", ViewBag.ErrorType, ViewBag.ErrorMessage)*/,
                         false, false, false);
            }
            return new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult InlineASCampaignPicker(IObject obj, long objectId, string idfsASCampaignPropertyName, string strASCampaignPropertyName, 
            string strASCampaignIdPropertyName, bool showInInternalWindow = false)
        {
            //!важно: данный контрол не является вариантом стандартного пикера, потому что в нем добавлено еще одно поле strASCampaignIdPropertyName
            ViewBag.IdfsASCampaignPropertyName = idfsASCampaignPropertyName;
            ViewBag.StrASCampaignPropertyName = strASCampaignPropertyName;
            ViewBag.StrASCampaignIdPropertyName = strASCampaignIdPropertyName;
            ViewBag.ShowInInternalWindow = showInInternalWindow;
            ViewBag.MainDivId = string.Format("divASCampaignSearchPicker_{0}_{1}", objectId, idfsASCampaignPropertyName);
            ViewBag.BtnViewPicker = string.Format("btnASCampaignViewPicker_{0}_{1}", objectId, idfsASCampaignPropertyName);
            ViewBag.BtnSearchPicker = string.Format("btnASCampaignSearchPicker_{0}_{1}", objectId, idfsASCampaignPropertyName);
            ViewBag.BtnClianPicker = string.Format("btnASCampaignClian_{0}_{1}", objectId, idfsASCampaignPropertyName);

            SetButtonsReadOnlyInViewBag(objectId, idfsASCampaignPropertyName);

            string onSelectItemClick = string.Format("asCampaign.showASCampaignSearchPicker(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\")",
                objectId, idfsASCampaignPropertyName, strASCampaignPropertyName, strASCampaignIdPropertyName, showInInternalWindow);
            ViewBag.OnSelectItemClick = onSelectItemClick;

            string onClianButtonClick = string.Format("asCampaign.onASCampaignPickerValueChanged(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"\", \"{4}\")",
                objectId, idfsASCampaignPropertyName, strASCampaignPropertyName, strASCampaignIdPropertyName, showInInternalWindow);
            ViewBag.OnClianButtonClick = onClianButtonClick;

            return PartialView(obj);
        }

        private void SetButtonsReadOnlyInViewBag(long objectId, string idfsASCampaignPropertyName)
        {
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, objectId, null);

            IObjectPermissions permission = rootObject.GetPermissions();
            bool isRootReadOnly = permission == null ? false : permission.IsReadOnlyForEdit;

            bool isControlReadOnly = rootObject.IsReadOnly(idfsASCampaignPropertyName) || isRootReadOnly;
            ViewBag.IsSearchButtonReadOnly = isControlReadOnly;

            object asCampaign = rootObject.GetValue(idfsASCampaignPropertyName);
            Int64 asCampaignId = 0;
            if (asCampaign != null)
            {
                Int64.TryParse(asCampaign.ToString(), out asCampaignId);
            }
            ViewBag.IsClianButtonReadOnly = isControlReadOnly || asCampaignId == 0;

            ViewBag.IsViewButtonReadOnly = asCampaignId == 0;
        }

        [HttpGet]
        public ActionResult ASCampaignPicker(string objectId, string idfsASCampaignPropertyName, string strASCampaignPropertyName, 
            string strASCampaignIdPropertyName, bool showInInternalWindow = false)
        {
            ViewBag.ObjectId = objectId;
            ViewBag.IdfsASCampaignPropertyName = idfsASCampaignPropertyName;
            ViewBag.StrASCampaignPropertyName = strASCampaignPropertyName;
            ViewBag.StrASCampaignIdPropertyName = strASCampaignIdPropertyName;
            ViewBag.ShowInInternalWindow = showInInternalWindow;

            IObject initObject = null;
            var accessor = AsCampaignListItem.Accessor.Instance(null);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;

            var filter = new FilterParams();
            filter.Add("idfsCampaignStatus", "=", (long)AsCampaignStatus.Open);
            ViewBag.Filter = filter;

            return View(accessor);
        }
        
        [HttpPost]
        public ActionResult SetSelectedASCampaign(string objectId, string idfsASCampaignPropertyName, string strASCampaignPropertyName,
            string strASCampaignIdPropertyName, string selectedItemId, int ignoreErr)
        {
            long key = long.Parse(objectId);
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, key, null);
            CompareModel data;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                IObject cloneObject = rootObject.CloneWithSetup(manager);
                object previousAsCampaignId = rootObject.GetValue(idfsASCampaignPropertyName);
                if (previousAsCampaignId != null)
                {
                    cloneObject.SetValue(idfsASCampaignPropertyName, previousAsCampaignId.ToString());
                }

                m_ignoreErr = ignoreErr;
                rootObject.Validation += object_ValidationDetails;
                rootObject.SetValue(idfsASCampaignPropertyName, selectedItemId);
                rootObject.Validation -= object_ValidationDetails;
                data = new CompareModel();
                if (ViewBag.ErrorMessage != null)
                {
                    object val = rootObject.GetValue(idfsASCampaignPropertyName);
                    string type = rootObject.GetType(idfsASCampaignPropertyName);
                    string valstr = val == null ? "" : val.ToString();
                    data.Add(idfsASCampaignPropertyName, objectId, type, valstr,
                             rootObject.IsReadOnly(idfsASCampaignPropertyName),
                             rootObject.IsInvisible(idfsASCampaignPropertyName),
                             rootObject.IsRequired(idfsASCampaignPropertyName));
                    data.Add("ErrorMessage", "ErrorMessage",
                        "AskMessage", 
                        ViewBag.ErrorMessage /*String.Format("{0}:{1}", ViewBag.ErrorType, ViewBag.ErrorMessage)*/,
                        false, false, false);
                }
                else
                {
                    SetAsCampaignInRootObject(rootObject, selectedItemId, strASCampaignPropertyName, strASCampaignIdPropertyName);
                    data = rootObject.Compare(cloneObject);
                }
            }
            return new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult StoreInSession(FormCollection form)
        {
            if (form.AllKeys.Contains("idfCampaign"))
            {
                var key = long.Parse(form["idfCampaign"]);
                var campaign = (AsCampaign)ModelStorage.Get(Session.SessionID, key, null);
                campaign.ParseFormCollection(form);
            }
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private void SetAsCampaignInRootObject(IObject rootObject, string campaignId, string strASCampaignPropertyName, string strASCampaignIdPropertyName)
        {
            string strCampaignName = string.Empty;
            string strCampaignID = string.Empty;
            if (!string.IsNullOrEmpty(campaignId))
            {
                Int64 id = Int64.Parse(campaignId);
                var asCampaignList = new List<AsCampaignListItem>();
                var accessor = AsCampaignListItem.Accessor.Instance(null);
                var filter = new FilterParams();
                filter.Add("idfCampaign", "=", id);
                using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    asCampaignList = accessor.SelectListT(dbmanager, filter);
                }

                if (asCampaignList.Count == 1)
                {
                    strCampaignName = string.IsNullOrEmpty(asCampaignList[0].strCampaignName) ? "" : asCampaignList[0].strCampaignName;
                    strCampaignID = string.IsNullOrEmpty(asCampaignList[0].strCampaignID) ? "" : asCampaignList[0].strCampaignID;
                }

            }
            rootObject.SetValue(strASCampaignPropertyName, strCampaignName);
            rootObject.SetValue(strASCampaignIdPropertyName, strCampaignID);
        }
    }
}
