using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Schema;
using eidss.web.common.Utils;

namespace eidss.web.common.Controllers
{
    public class BvController : Controller
    {
        #region List
        private L GetGridModelList<A, O, L>(FilterParams filter, A accessor, AutoGridRoots grid, KeyValuePair<string, ListSortDirection>[] sorts = null, 
            Func<List<O>> list_return = null, 
            Action<List<O>> list_action = null)
            where A : IObjectAccessor, IObjectMeta, IObjectSelectList<O>, IObjectCreator
            where O : IObject
            where L : IGridModelList, IGridModelListLoad, IList, new()
        {
            List<O> items = null;
            if (list_return != null)
            {
                items = list_return();
            }
            if (items == null)
            {
                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    items = accessor.SelectListT(manager, filter, sorts, true);
                    var sample = accessor.CreateNew(manager, null, null);
                    if (sample.IsHiddenPersonalData("GeoLocationName") || sample.IsHiddenPersonalData("AddressName"))
                    {
                        AddressStringHelper.RearrangeAddressDisplayString(sample, items);
                    }
                }
            }

            if (list_action != null)
                list_action(items);
            
            var list = new L();
            list.Load((long)grid, items, null);
            return list;
        }

        private ActionResult IndexInternal<A, O, L>(FilterParams filter, A accessor, AutoGridRoots grid)
            where A : IObjectAccessor, IObjectMeta, IObjectSelectList<O>, IObjectCreator
            where O : IObject
            where L : IGridModelList, IGridModelListLoad, IList, new()
        {
            ModelStorage.Access(Session.SessionID);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            L list = GetGridModelList<A, O, L>(filter, accessor, grid);
            ModelStorage.Put(Session.SessionID, 0, (long)grid, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        public L IndexInternalAjax<A, O, L>(FormCollection form, A accessor, AutoGridRoots grid, KeyValuePair<string,ListSortDirection>[] sorts = null)
            where A : IObjectAccessor, IObjectMeta, IObjectSelectList<O>, IObjectCreator
            where O : IObject
            where L : IGridModelList, IGridModelListLoad, IList, new()
        {
            ModelStorage.Access(Session.SessionID);
            return GetGridModelList<A, O, L>(SearchPanelHelper.SearchPanelParseValues(form, accessor.SearchPanelMeta), accessor, grid, sorts);
        }

        public class BvDataSourceResult : DataSourceResult
        {
            public bool IgnoreTopMaxCount { get; set; }
            public int SelectTopMaxCount { get; set; }
            public BvDataSourceResult(DataSourceResult source)
            {
                this.AggregateResults = source.AggregateResults;
                this.Data = source.Data;
                this.Errors = source.Errors;
                this.Total = source.Total;
                this.IgnoreTopMaxCount = BaseSettings.IgnoreTopMaxCount;
                this.SelectTopMaxCount = BaseSettings.SelectTopMaxCount;
            }
        }

        public ActionResult IndexInternalAjax<A, O, L>(FormCollection form, A accessor, AutoGridRoots grid, DataSourceRequest request,
            Func<List<O>> list_return = null,
            Action<List<O>> list_action = null,
            bool bModelSortable = false)
            where A : IObjectAccessor, IObjectMeta, IObjectSelectList<O>, IObjectCreator
            where O : IObject
            where L : IGridModelList, IGridModelListLoad, IList, new()
        {
            ModelStorage.Access(Session.SessionID);
            var list = new L();
            if (form["bFirstSearchClick"] == "0")
            {
            }
            else
            {
                KeyValuePair<string, ListSortDirection>[] sorts = null;
                if (!bModelSortable && request.Sorts != null && request.Sorts.Count > 0)
                {
                    sorts = new[] { new KeyValuePair<string, ListSortDirection>(request.Sorts[0].Member, request.Sorts[0].SortDirection) };
                }

                FilterParams pars = SearchPanelHelper.SearchPanelParseValues(form, accessor.SearchPanelMeta);
                pars = pars.Merge(FilterParams.Deserialize(form["StaticFilter"]));
                list = GetGridModelList<A, O, L>(pars, accessor, grid, sorts, list_return, list_action);
            }
            DataSourceResult result = list.ToDataSourceResult(request);
            var bvResult = new BvDataSourceResult(result);
            return Json(bvResult);
        }


        public ActionResult IndexInternal<A, O, L>(A accessor, AutoGridRoots grid, bool bLoadList, FilterParams addFilter = null, string viewName = null)
            where A : IObjectAccessor, IObjectMeta, IObjectSelectList<O>, IObjectCreator
            where O : IObject
            where L : IGridModelList, IGridModelListLoad, IList, new()
        {
            ModelStorage.Access(Session.SessionID);
            IObject initObject = null;
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null, null);
            }
            ViewBag.InitObject = initObject;

            FilterParams filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject, addFilter);
            ViewBag.Filter = filter;
            filter = filter.Merge(ViewBag.StaticFilter as FilterParams);
            if (bLoadList)
            {
                L list = GetGridModelList<A, O, L>(filter, accessor, grid);
                ViewBag.GridItems = list;
                ModelStorage.Put(Session.SessionID, 0, (long)grid, "Grid", list);
            }
            if (viewName == null)
                return View(accessor);
            else
                return View(viewName, accessor);
        }

        public ActionResult IndexInternal<A, O, L>(FormCollection form, A accessor, AutoGridRoots grid)
            where A : IObjectAccessor, IObjectMeta, IObjectSelectList<O>, IObjectCreator
            where O : IObject
            where L : IGridModelList, IGridModelListLoad, IList, new()
        {
            ModelStorage.Access(Session.SessionID);
            return IndexInternal<A, O, L>(SearchPanelHelper.SearchPanelParseValues(form, accessor.SearchPanelMeta), accessor, grid);
        }
        public ActionResult IndexInternal<A, O, L>(string formData, A accessor, AutoGridRoots grid)
            where A : IObjectAccessor, IObjectMeta, IObjectSelectList<O>, IObjectCreator
            where O : IObject
            where L : IGridModelList, IGridModelListLoad, IList, new()
        {
            ModelStorage.Access(Session.SessionID);
            return IndexInternal<A, O, L>(SearchPanelHelper.SearchPanelParseValues(formData, accessor.SearchPanelMeta), accessor, grid);
        }
        #endregion

        #region Detail
        public ActionResult Delete<A, O>(long? id, A accessor)
            where A : IObjectAccessor, IObjectSelectDetail<O>, IObjectPost
            where O : class, IObject
        {
            bool isSuccess = false;
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var o = accessor.SelectDetailT(manager, id.Value) as O;
                if (o != null)
                {
                    if (o.MarkToDelete())
                    {
                        isSuccess = accessor.Post(manager, o);
                    }
                }

                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = isSuccess };
            }
        }

        public ActionResult DetailsInternal<A, O>(long? id, A accessor, int? hacode, string viewName,
            Func<DbManagerProxy, A, O> selector, Func<DbManagerProxy, A, O> creator, Action<O> addition)
            where A : IObjectAccessor, IObjectMeta, IObjectCreator<O>//, IObjectSelectDetail<O>
            where O : IObject
        {
            if (!id.HasValue) id = 0;
            if (id == 0) ViewBag.IsNewCase = "true";

            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                if (selector == null)
                {
                    if (accessor is IObjectSelectDetail<O>)
                    {
                        selector = (m, a) => ((IObjectSelectDetail<O>)accessor).SelectDetailT(m, id.Value, hacode);
                    }
                }
                if (creator == null)
                    creator = (m, a) => a.CreateNewT(m, null, hacode);
                
                var o = id.Value.Equals(0) ? creator(manager, accessor) : selector(manager, accessor);
                if (o == null) o = creator(manager, accessor);

                ModelStorage.Put(Session.SessionID, (long)o.Key, (long)o.Key, null, o);
                var permission = o.GetPermissions();
                ViewBag.IsReadOnlyForEdit = (permission != null) && permission.IsReadOnlyForEdit;
                if (addition != null)
                    addition(o);
                return viewName == null ? View(o) : View(viewName, o);
            }
        }


        private ValidationEventArgs validation = null;
        private bool ignoreErr;
        void ValidationDetails(object sender, ValidationEventArgs args)
        {
            if (ignoreErr)
            {
                args.Continue = true;
            }
            else
            {
                validation = args;
                ViewBag.ErrorMessage = Translator.GetErrorMessage(args);
            }
        }

        public ActionResult DetailsInternalAjax<A, O>(FormCollection form, A accessor, string keyName,
            Action<O, O> before_validation, Action<O> before_post, Action<O> after_post, bool needPost = true, bool bCloneWithSetup = true)
            where A : IObjectAccessor, IObjectMeta, IObjectPost
            where O : class, IObject, ICloneable
        {
            var key = long.Parse(form[keyName ?? accessor.KeyName]);
            var o = (O)ModelStorage.Get(Session.SessionID, key, null);
            var comparision = new CompareModel();
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var clone = (bCloneWithSetup ? o.CloneWithSetup(manager, true) : o.Clone()) as O;

                if (before_validation != null)
                    before_validation(o, clone);

                ViewBag.ErrorMessage = null;
                ignoreErr = form.AllKeys.Contains("ignore_rule") && form["ignore_rule"] == "1";
                o.Validation += ValidationDetails;
                o.ParseFormCollection(form);

                if (before_post != null)
                    before_post(o);

                if (needPost && (ViewBag.ErrorMessage == null))
                {
                    accessor.Post(manager, o);
                }
                o.Validation -= ValidationDetails;

                if (after_post != null)
                {
                    after_post(o);
                }

                ViewBag.IsNewCase = "";

                if (ViewBag.ErrorMessage != null)
                {
                    comparision.Add("ErrorMessage", "ErrorMessage", validation.ShouldAsk ? "AskPostMessage" : "ErrorMessage",
                                    ViewBag.ErrorMessage.ToString(),
                                    false, false, false);
                }
                else
                {
                    comparision = o.Compare(clone);
                }
            }

            return Json(comparision, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DetailsInternalPost<A, O>(FormCollection form, A accessor, string keyName,
            bool bReload, string viewName,
            Func<O, bool> before_validation, Action<O> before_post, Action<O> after_post)
            where A : IObjectAccessor, IObjectMeta, IObjectPost, IObjectSelectDetail<O>
            where O : class, IObject, ICloneable
        {
            var key = long.Parse(form[keyName ?? accessor.KeyName]);
            var o = ModelStorage.Get(Session.SessionID, key, null) as O;

            if (before_validation != null)
            {
                if (before_validation(o))
                    return View(o);
            }

            ViewBag.ErrorMessage = null;
            ignoreErr = form.AllKeys.Contains("ignore_rule") && form["ignore_rule"] == "1";
            o.Validation += ValidationDetails;
            o.ParseFormCollection(form);

            if (before_post != null)
                before_post(o);

            if (ViewBag.ErrorMessage == null)
            {
                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    accessor.Post(manager, o);
                }
            }
            o.Validation -= ValidationDetails;

            if (after_post != null)
            {
                after_post(o);
            }

            ViewBag.IsNewCase = "";

            if (bReload)
            {
                if (ViewBag.ErrorMessage == null)
                {
                    using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                    {
                        o = accessor.SelectDetailT(manager, o.Key);
                        ModelStorage.Remove(Session.SessionID, (long)o.Key, null);
                        ModelStorage.Put(Session.SessionID, (long)o.Key, (long)o.Key, null, o);
                    }
                }
            }

            return viewName == null ? View(o) : View(viewName, o);
        }

        
        #endregion


        #region Picker

        public ActionResult PickerInternal<A, O, P>(long key, long id, string nameList, A accessor, int? hacode,
            Func<DbManagerProxy, A, P, O> selector, Func<DbManagerProxy, A, P, O> creator,
            Action<DbManagerProxy, A, O> addition)
            where A : IObjectAccessor, IObjectCreator<O>
            where O : class, IObject
            where P : class, IObject
        {
            var list = ModelStorage.Get(Session.SessionID, key, nameList) as EditableList<O>;
            var root = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, key, null)).Key;
            var parent = ModelStorage.Get(Session.SessionID, key, null) as P;
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                if (selector == null)
                    selector = (m, a, p) => list.Single(c => (long)c.Key == id).CloneWithSetup(manager) as O;
                if (creator == null)
                    creator = (m, a, p) => a.CreateNewT(m, parent, hacode);
                var o = (id == 0) ? creator(manager, accessor, parent) : selector(manager, accessor, parent);
                if (addition != null)
                    addition(manager, accessor, o);
                ModelStorage.Put(Session.SessionID, root, (long)o.Key, null, o);
                return View(o);
            }
        }


        public ActionResult PickerInternal<A, O, P>(FormCollection form, A accessor, string idName, 
            Func<P, EditableList<O>> list, Func<O, O, bool> predicate, Action<O, O> copy,
            Action<O, P> action = null, Func<O, O> fOriginal = null, bool bCompareParent = false, bool bCompareParentForAdditional = false,
            bool bDeepValidation = true)
            where A : IObjectAccessor, IObjectValidator
            where O : class, IObject
            where P : class, IObject
        {
            var id = long.Parse(form[idName ?? accessor.KeyName]);
            var o = ModelStorage.Get(Session.SessionID, id, null) as O;
            var root = ModelStorage.GetRoot(Session.SessionID, id, null) as P;
            var prnt = o.Parent is P ? (P)o.Parent : root;
            var data = new CompareModel();
            var clone = (bCompareParent ? ((root ?? prnt) as ICloneable).Clone() : (o as ICloneable).Clone()) as IObject;
            var cloneParent = (bCompareParentForAdditional ? ((root ?? prnt) as ICloneable).Clone() : null) as IObject;

            ignoreErr = form.AllKeys.Contains("ignore_rule") && form["ignore_rule"] == "1";
            o.Validation += ValidationDetails;
            o.ParseFormCollection(form);
            if (validation == null)
            {
                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    accessor.Validate(manager, o, true, true, bDeepValidation);
                }
            }
            o.Validation -= ValidationDetails;

            if (validation == null)
            {
                if (list != null)
                {
                    if (root != null)
                        root.Validation += ValidationDetails;
                    if (prnt != null && prnt != root)
                        prnt.Validation += ValidationDetails;
                    var original = list(prnt).SingleOrDefault(i => predicate(i, o));
                    if (original != null)
                    {
                        original.Validation += ValidationDetails;
                        original.ParseFormCollection(form);
                        if (copy != null)
                            copy(original, o);
                        original.Validation -= ValidationDetails;
                    }
                    else
                    {
                        list(prnt).Add(o);
                    }
                    if (prnt != null && prnt != root)
                        prnt.Validation -= ValidationDetails;
                    if (root != null)
                        root.Validation -= ValidationDetails;
                }

                if (fOriginal != null)
                {
                    var original = fOriginal(o);
                    if (original != null)
                    {
                        original.Validation += ValidationDetails;
                        original.ParseFormCollection(form);
                        if (copy != null)
                            copy(original, o);
                        original.Validation -= ValidationDetails;
                    }
                }
            }

            if (validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(validation);
                data.Add("ErrorMessage", "ErrorMessage", validation.ShouldAsk ? "AskPostMessage" : "ErrorMessage",
                    errorMessage, false, false, false);
            }
            else
            {
                if (bCompareParent)
                {
                    data = (root ?? prnt).Compare(clone);
                }
                else if (action != null)
                {
                    action(o, root ?? prnt);
                    if (bCompareParentForAdditional)
                        data = (root ?? prnt).Compare(cloneParent);
                    else
                        data = o.Compare(clone);
                }
                else
                {
                    ModelStorage.Remove(Session.SessionID, id, null);
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        public ActionResult PickerInternalNotList<A, O, P>(FormCollection form, A accessor, string idName,
            Func<DbManagerProxy, P, O, CompareModel> action)
            where A : IObjectAccessor, IObjectValidator
            where O : class, IObject
            where P : class, IObject
        {
            var id = long.Parse(form[idName ?? accessor.KeyName]);
            var o = ModelStorage.Get(Session.SessionID, id, null) as O;
            var p = o.Parent as P;
            var data = new CompareModel();

            o.Validation += ValidationDetails;
            o.ParseFormCollection(form);
            if (validation == null)
            {
                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    accessor.Validate(manager, o, true, true, true);
                    if (validation == null)
                    {
                        if (action != null)
                            data = action(manager, p, o);
                    }
                }
            }
            o.Validation -= ValidationDetails;


            if (validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                ModelStorage.Remove(Session.SessionID, id, null);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        #endregion


        public ActionResult ReportResponse(byte[] report, string fileName)
        {
            if (report != null)
            {
                Response.AppendHeader("Content-Disposition", "inline; filename=" + fileName);
                Response.AppendHeader("Content-Type", "application/pdf");
                Response.BinaryWrite(report);
            }
            return new ContentResult();
        }

    }
}
