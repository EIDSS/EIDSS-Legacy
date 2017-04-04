using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.webclient.Utils;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Enums;
using eidss.web.common.Utils;
using eidss.web.common.Controllers;
using BLToolkit.EditableObjects;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class FarmController : BvController
    {
        public ActionResult Index()
        {
            return IndexInternal<FarmListItem.Accessor, FarmListItem, FarmListItem.FarmListItemGridModelList>
                (FarmListItem.Accessor.Instance(null), AutoGridRoots.FarmsList, false);
        }

        public ActionResult Details(long? id)
        {
            return DetailsInternal<FarmRoot.Accessor, FarmRoot>(id, eidss.model.Schema.FarmRoot.Accessor.Instance(null), null, null, null, null, null);
        }

        [HttpPost]
        [CompressFilter]
        public ActionResult Details(FormCollection form)
        {
            return DetailsInternalAjax<FarmRoot.Accessor, FarmRoot>(form, eidss.model.Schema.FarmRoot.Accessor.Instance(null), null, 
                (o, c) =>
                    {
                        o.intHACode = null;
                        var selected = form[o.ObjectIdent + "HACode"].ToString();
                        if (!string.IsNullOrEmpty(selected))
                        {
                            o.intHACode = 0;
                            selected.Split(',').ToList().ForEach(i => o.intHACode |= Int32.Parse(i));
                            form.Remove(o.ObjectIdent + "HACode");
                        }
                    }, 
                null, null);
        }


        //
        // GET: /Farm/
        #region Farms

        public ActionResult InlineFarmPicker(FarmPanel obj)
        {
            return PartialView(obj);
        }


        public ActionResult FarmPicker()
        {
            var accessor = FarmListItem.Accessor.Instance(null);
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            FilterParams filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            ViewBag.Filter = filter;
            FarmListItem.FarmListItemGridModelList list = GetGridModelList(filter);
            ViewBag.GridItems = list;
            ObjectStorage.Put(ModelUserContext.ClientID, 0, (long)AutoGridRoots.FarmSelectList, "Grid", list);

            return View(accessor);
        }

        [CompressFilter]
        public ActionResult IndexAjax([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax<FarmListItem.Accessor, FarmListItem, FarmListItem.FarmListItemGridModelList>
                (form, FarmListItem.Accessor.Instance(null), AutoGridRoots.FarmsList, request);
        }

        [HttpPost]
        public ActionResult Select(string formData)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(formData, FarmListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            FarmListItem.FarmListItemGridModelList list = GetGridModelList(filter);
            ObjectStorage.Put(ModelUserContext.ClientID, 0, (long)AutoGridRoots.FarmSelectList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static FarmListItem.FarmListItemGridModelList GetGridModelList(FilterParams filter)
        {
            List<FarmListItem> items = GetFarmList(filter);
            var list = new FarmListItem.FarmListItemGridModelList((long)AutoGridRoots.FarmSelectList, items);
            return list;
        }

        private static List<FarmListItem> GetFarmList(FilterParams filter)
        {
            var accessor = FarmListItem.Accessor.Instance(null);

            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<FarmListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }


        #endregion
    }
}
