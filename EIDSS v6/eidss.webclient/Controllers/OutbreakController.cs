using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using Kendo.Mvc.UI;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using bv.model.Model.Core;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using eidss.model.Resources;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class OutbreakController : BvController
    {
        public ActionResult Index()
        {
            return IndexInternal<OutbreakListItem.Accessor, OutbreakListItem, OutbreakListItem.OutbreakListItemGridModelList>
                (OutbreakListItem.Accessor.Instance(null), AutoGridRoots.OutbreakList, false);
        }

        public ActionResult IndexAjax([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax<OutbreakListItem.Accessor, OutbreakListItem, OutbreakListItem.OutbreakListItemGridModelList>
                (form, OutbreakListItem.Accessor.Instance(null), AutoGridRoots.OutbreakList, request);
        }

        public ActionResult Details(long? id)
        {
            return DetailsInternal<Outbreak.Accessor, Outbreak>(id, eidss.model.Schema.Outbreak.Accessor.Instance(null), null, null, null, null, null);
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            var key = long.Parse(form[eidss.model.Schema.Outbreak.Accessor.Instance(null).KeyName]);
            var o = (Outbreak)ModelStorage.Get(Session.SessionID, key, null);
            o.Cases.ForEach(c => c.SetChange());
            return DetailsInternalAjax<Outbreak.Accessor, Outbreak>(form, eidss.model.Schema.Outbreak.Accessor.Instance(null), null, null, null, null);
        }


        public ActionResult InlineOutbreakPicker(IObject obj, long objectId, string idfsOutbreakPropertyName, string strOutbreakPropertyName, bool showInInternalWindow = false)
        {
            ViewBag.IdfsOutbreakPropertyName = idfsOutbreakPropertyName;
            ViewBag.StrOutbreakPropertyName = strOutbreakPropertyName;
            ViewBag.ShowInInternalWindow = showInInternalWindow;
            ViewBag.MainDivId = string.Format("divOutbreakSearchPicker_{0}_{1}", objectId, idfsOutbreakPropertyName);
            ViewBag.BtnViewPicker = string.Format("btnOutbreakViewPicker_{0}_{1}", objectId, idfsOutbreakPropertyName);
            ViewBag.BtnSearchPicker = string.Format("btnOutbreakSearchPicker_{0}_{1}", objectId, idfsOutbreakPropertyName);
            ViewBag.BtnClianPicker = string.Format("btnOutbreakClian_{0}_{1}", objectId, idfsOutbreakPropertyName);

            SetButtonsReadOnlyInViewBag(objectId, idfsOutbreakPropertyName);

            string onSelectItemClick = string.Format("outbreak.showSearchPicker(\"{0}\", \"{1}\", \"{2}\", \"{3}\")",
                objectId, idfsOutbreakPropertyName, strOutbreakPropertyName, showInInternalWindow);
            ViewBag.OnSelectItemClick = onSelectItemClick;

            string onClianButtonClick = string.Format("outbreak.onPickerValueChanged(\"{0}\", \"{1}\", \"{2}\", \"\", \"{3}\")",
                objectId, idfsOutbreakPropertyName, strOutbreakPropertyName, showInInternalWindow);
            ViewBag.OnClianButtonClick = onClianButtonClick;

            return PartialView(obj);
        }

        private void SetButtonsReadOnlyInViewBag(long objectId, string idfsOutbreakPropertyName)
        {
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, objectId, null);

            IObjectPermissions permission = rootObject.GetPermissions();
            bool isRootReadOnly = permission == null ? false : permission.IsReadOnlyForEdit;

            bool isControlReadOnly = rootObject.IsReadOnly(idfsOutbreakPropertyName) || isRootReadOnly;
            ViewBag.IsSearchButtonReadOnly = isControlReadOnly;

            object outbreak = rootObject.GetValue(idfsOutbreakPropertyName);
            Int64 outbreakId = 0;
            if (outbreak != null)
            {
                Int64.TryParse(outbreak.ToString(), out outbreakId);
            }
            ViewBag.IsClianButtonReadOnly = isControlReadOnly || outbreakId == 0;

            ViewBag.IsViewButtonReadOnly = outbreakId == 0;
        }


        [HttpGet]
        public ActionResult OutbreakPicker(string objectId, string idfsOutbreakPropertyName, string strOutbreakPropertyName, bool showInInternalWindow = false)
        {
            ViewBag.ObjectId = objectId;
            ViewBag.IdfsOutbreakPropertyName = idfsOutbreakPropertyName;
            ViewBag.StrOutbreakPropertyName = strOutbreakPropertyName;
            ViewBag.ShowInInternalWindow = showInInternalWindow;

            IObject initObject = null;
            var accessor = OutbreakListItem.Accessor.Instance(null);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            FilterParams filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            ViewBag.Filter = filter;

            return View(accessor);
        }

        [HttpPost]
        public ActionResult SetSelectedOutbreak(string objectId, string idfsOutbreakPropertyName, string strOutbreakPropertyName, string selectedItemId)
        {
            return SetSelectedOutbreakWithIgnore(objectId, idfsOutbreakPropertyName, strOutbreakPropertyName, selectedItemId, 0);
        }

        [HttpGet]
        public ActionResult SetSelectedOutbreakWithIgnore(string objectId, string idfsOutbreakPropertyName, string strOutbreakPropertyName, string selectedItemId, int ignoreErr)
        {
            long key = long.Parse(objectId);
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, key, null);
            var data = new CompareModel();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                IObject cloneObject = rootObject.CloneWithSetup(manager);


                m_ignoreErr = ignoreErr;
                ViewBag.ErrorMessage = null;
                rootObject.Validation += ValidationDetails;
                rootObject.SetValue(idfsOutbreakPropertyName, selectedItemId);
                rootObject.Validation -= ValidationDetails;

                if (ViewBag.ErrorMessage != null)
                {
                    data.Add("ErrorMessage", "/Outbreak/SetSelectedOutbreakWithIgnore?objectId=" + objectId + "&idfsOutbreakPropertyName=" + idfsOutbreakPropertyName + "&strOutbreakPropertyName=" + strOutbreakPropertyName + "&selectedItemId=" + selectedItemId + "&ignoreErr=1",
                        validation.ShouldAsk ? "AskUrlMessage" : "ErrorMessage",
                                    ViewBag.ErrorMessage.ToString(),
                                    false, false, false);
                }
                else
                {
                    string outbreakName = string.Empty;
                    if (!string.IsNullOrEmpty(selectedItemId))
                    {
                        Int64 id = Int64.Parse(selectedItemId);
                        outbreakName = GetOutbreakNameById(id);
                    }
                    rootObject.SetValue(strOutbreakPropertyName, outbreakName);

                    data = rootObject.Compare(cloneObject);
                }
            }
            return new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private string GetOutbreakNameById(Int64 id)
        {
            var outbreaks = new List<OutbreakListItem>();
            var accessor = OutbreakListItem.Accessor.Instance(null);
            var filter = new FilterParams();
            filter.Add("idfOutbreak", "=", id);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                outbreaks = accessor.SelectListT(dbmanager, filter);
            }

            if (outbreaks.Count == 1)
            {
                return outbreaks[0].strOutbreakID;
            }

            return null;
        }

        [HttpPost]
        public ActionResult SetPrimaryCase(long objectId, long caseId)
        {
            var rootObject = (Outbreak)ModelStorage.Get(Session.SessionID, objectId, null);
            CompareModel data;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var cloneObject = rootObject.CloneWithSetup(manager);
                var acc = Outbreak.Accessor.Instance(null);
                if (caseId == 0)
                    acc.ClearPrimaryCase(manager, rootObject);
                else
                    acc.SetPrimaryCase(manager, rootObject, rootObject.Cases.SingleOrDefault(c => c.idfCase == caseId && !c.IsMarkedToDelete));

                data = rootObject.Compare(cloneObject);
            }
            return new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult DeleteCase(long outbreakId, long caseId)
        {
            var rootObject = (Outbreak)ModelStorage.Get(Session.SessionID, outbreakId, null);
            CompareModel data = new CompareModel();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var cloneObject = rootObject.CloneWithSetup(manager);

                ViewBag.ErrorMessage = null;
                rootObject.Validation += ValidationDetails;
                var toDelete = rootObject.Cases.FirstOrDefault(i => i.idfCase == caseId && !i.IsMarkedToDelete);
                if (toDelete != null)
                    toDelete.MarkToDelete();
                rootObject.Validation -= ValidationDetails;

                if (ViewBag.ErrorMessage != null)
                {
                    data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                                    ViewBag.ErrorMessage.ToString(),
                                    false, false, false);
                }
                else
                {
                    data = rootObject.Compare(cloneObject);
                }
            }
            return new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult AddCase(long outbreakId, long caseId)
        {
            return AddCaseWithIgnore(outbreakId, caseId, 0);
        }

        [HttpGet]
        public ActionResult AddCaseWithIgnore(long outbreakId, long caseId, int ignoreErr)
        {
            var rootObject = (Outbreak)ModelStorage.Get(Session.SessionID, outbreakId, null);
            CompareModel data = new CompareModel();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var cloneObject = rootObject.CloneWithSetup(manager);
                var acc = OutbreakCase.Accessor.Instance(null);
                var cs = acc.Create(manager, rootObject, caseId);

                m_ignoreErr = ignoreErr;
                ViewBag.ErrorMessage = null;
                rootObject.Validation += ValidationDetails;
                rootObject.Cases.Add(cs);
                rootObject.Validation -= ValidationDetails;

                if (ViewBag.ErrorMessage != null)
                {
                    data.Add("ErrorMessage", "/Outbreak/AddCaseWithIgnore?outbreakId=" + outbreakId + "&caseId=" + caseId + "&ignoreErr=1", 
                        validation.ShouldAsk ? "AskUrlMessage" : "ErrorMessage",
                                    ViewBag.ErrorMessage.ToString(),
                                    false, false, false);
                }
                else
                {
                    data = rootObject.Compare(cloneObject);
                }
            }
            return new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private ValidationEventArgs validation = null;
        private int m_ignoreErr;
        void ValidationDetails(object sender, ValidationEventArgs args)
        {
            if (m_ignoreErr == 1)
            {
                args.Continue = true;
            }
            else
            {
                validation = args;
                ViewBag.ErrorMessage = Translator.GetErrorMessage(args);
            }
        }


        [HttpGet]
        public ActionResult OutbreakNotePicker(long key, string name, long id)
        {
            return PickerInternal<OutbreakNote.Accessor, OutbreakNote, Outbreak>(key, id, name, OutbreakNote.Accessor.Instance(null), null, null,
                null,
                null);
        }

        [HttpPost]
        public ActionResult SetOutbreakNote(FormCollection form)
        {
            return PickerInternal<OutbreakNote.Accessor, OutbreakNote, Outbreak>(form, OutbreakNote.Accessor.Instance(null), null,
                p => p.Notes,
                (i, o) => i.idfOutbreakNote == o.idfOutbreakNote,
                null
                /*SetSampleOrganizationsAndEmpoyee*/
                );
        }

        [HttpGet]
        public ActionResult OutbreakReport(long id)
        {
            try
            {
                byte[] report;
                using (var wrapper = new ReportClientWrapper())
                {
                    var model = new BaseIdModel(ModelUserContext.CurrentLanguage, id, ModelUserContext.Instance.IsArchiveMode);
                    report = wrapper.Client.ExportOutbreak(model);
                }
                return ReportResponse(report, "OutbreakReport.pdf");
            }
            catch
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
            }
        }

    }
}
