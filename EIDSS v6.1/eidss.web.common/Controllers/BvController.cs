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
using bv.common.Resources;

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
                    items = accessor.SelectListT(manager, filter, sorts, false);
                    using (var sample = accessor.CreateNew(manager, null, null))
                    {
                        if (sample.IsHiddenPersonalData("GeoLocationName") || sample.IsHiddenPersonalData("AddressName"))
                        {
                            AddressStringHelper.RearrangeAddressDisplayString(sample, items);
                        }
                    }
                }
            }

            if (list_action != null)
                list_action(items);
            
            var list = new L();
            list.Load((long)grid, items, null);

            if (list_return == null && list_action == null)
            {
                items.ForEach(c => c.Dispose());
            }

            return list;
        }

        private ActionResult IndexInternal<A, O, L>(FilterParams filter, A accessor, AutoGridRoots grid)
            where A : IObjectAccessor, IObjectMeta, IObjectSelectList<O>, IObjectCreator
            where O : IObject
            where L : IGridModelList, IGridModelListLoad, IList, new()
        {
            //ModelStorage.Access(ModelUserContext.ClientID);
            ObjectStorage.Access(ModelUserContext.ClientID);

            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            L list = GetGridModelList<A, O, L>(filter, accessor, grid);
            //ModelStorage.Put(ModelUserContext.ClientID, 0, (long)grid, "Grid", list);
            ObjectStorage.Put(ModelUserContext.ClientID, 0, (long)grid, "Grid", list);

            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        public L IndexInternalAjax<A, O, L>(FormCollection form, A accessor, AutoGridRoots grid, KeyValuePair<string,ListSortDirection>[] sorts = null)
            where A : IObjectAccessor, IObjectMeta, IObjectSelectList<O>, IObjectCreator
            where O : IObject
            where L : IGridModelList, IGridModelListLoad, IList, new()
        {
            //ModelStorage.Access(ModelUserContext.ClientID);
            ObjectStorage.Access(ModelUserContext.ClientID);
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
            //ModelStorage.Access(ModelUserContext.ClientID);
            ObjectStorage.Access(ModelUserContext.ClientID);
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
            //return Json(bvResult);
            return new JsonResult() { Data = result, MaxJsonLength = Int32.MaxValue };
        }


        public ActionResult IndexInternal<A, O, L>(A accessor, AutoGridRoots grid, bool bLoadList, FilterParams addFilter = null, string viewName = null)
            where A : IObjectAccessor, IObjectMeta, IObjectSelectList<O>, IObjectCreator
            where O : IObject
            where L : IGridModelList, IGridModelListLoad, IList, new()
        {
            //ModelStorage.Access(ModelUserContext.ClientID);
            ObjectStorage.Access(ModelUserContext.ClientID);
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
                //ModelStorage.Put(ModelUserContext.ClientID, 0, (long)grid, "Grid", list);
                ObjectStorage.Put(ModelUserContext.ClientID, 0, (long)grid, "Grid", list);
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
            //ModelStorage.Access(ModelUserContext.ClientID);
            ObjectStorage.Access(ModelUserContext.ClientID);
            return IndexInternal<A, O, L>(SearchPanelHelper.SearchPanelParseValues(form, accessor.SearchPanelMeta), accessor, grid);
        }
        public ActionResult IndexInternal<A, O, L>(string formData, A accessor, AutoGridRoots grid)
            where A : IObjectAccessor, IObjectMeta, IObjectSelectList<O>, IObjectCreator
            where O : IObject
            where L : IGridModelList, IGridModelListLoad, IList, new()
        {
            //ModelStorage.Access(ModelUserContext.ClientID);
            ObjectStorage.Access(ModelUserContext.ClientID);
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

                //ModelStorage.Put(ModelUserContext.ClientID, (long)o.Key, (long)o.Key, null, o);
                ObjectStorage.Put(ModelUserContext.ClientID, (long)o.Key, (long)o.Key, null, o);

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
                var textMessage = Translator.GetErrorMessage(args);
                if (args.MessageId == "msgWarningForFinalCaseClassification")
                {
                    var textDoNotShow = BvMessages.Get("DoNotShowWarningNextTime");
                    textMessage = textMessage + "<br/><br/><input name='idDoNotShowAgain' id='idDoNotShowAgain' class='bvCheckbox' onclick='DoNotShowAgain(\"ShowWharningForFinalCaseDefinition\")' type='checkbox'></input><label for='idDoNotShowAgain'>" + textDoNotShow + "</label>";
                }
                ViewBag.ErrorMessage = textMessage;
            }
        }

        public ActionResult DetailsInternalAjax<A, O>(FormCollection form, A accessor, string keyName,
            Action<O, O> before_validation, Action<O> before_post, Action<O> after_post, bool needPost = true, bool bCloneWithSetup = true,
            Action<O, CompareModel, ValidationEventArgs> onError = null)
            where A : IObjectAccessor, IObjectMeta, IObjectPost
            where O : class, IObject, ICloneable
        {
            var key = long.Parse(form[keyName ?? accessor.KeyName]);

            form.AllKeys.ToList().ForEach(k => form[k] = EidssWebHelper.UnescapeHtml(form[k]));
            
            //var o = (O)ModelStorage.Get(ModelUserContext.ClientID, key, null);
            return ObjectStorage.Using<O, JsonResult>(o =>
                {
            var comparision = new CompareModel();
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                using (var clone = (bCloneWithSetup ? o.CloneWithSetup(manager, true) : o.Clone()) as O)
                {

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
                        try
                        {
                            accessor.Post(manager, o);
                        }
                        catch (DbModelDeadlockException)
                        {
                            ViewBag.ErrorMessage = Translator.GetBvMessageString("msgIdDeadlock");
                        }
                    }
                    o.Validation -= ValidationDetails;

                    if (after_post != null)
                    {
                        after_post(o);
                    }

                    ViewBag.IsNewCase = "";

                    if (ViewBag.ErrorMessage != null)
                    {
                        if (onError != null)
                        {
                            onError(o, comparision, validation);
                        }
                        else
                        {
                            comparision.Add("ErrorMessage", "ErrorMessage",
                                validation.ValidationType == ValidationEventType.Error ? "ErrorMessage" : (validation.ValidationType == ValidationEventType.Warning ? "WarningPostMessage" : "AskPostMessage"),
                                ViewBag.ErrorMessage.ToString(),
                                false, false, false);
                        }
                    }
                    else
                    {
                        comparision = o.Compare(clone);
                    }
                }
            }

            return Json(comparision, JsonRequestBehavior.AllowGet);
            }, ModelUserContext.ClientID, key, null);
        }

        /*
        public ActionResult DetailsInternalPost<A, O>(FormCollection form, A accessor, string keyName,
            bool bReload, string viewName,
            Func<O, bool> before_validation, Action<O> before_post, Action<O> after_post)
            where A : IObjectAccessor, IObjectMeta, IObjectPost, IObjectSelectDetail<O>
            where O : class, IObject, ICloneable
        {
            var key = long.Parse(form[keyName ?? accessor.KeyName]);
            //var o = ModelStorage.Get(ModelUserContext.ClientID, key, null) as O;
            return ObjectStorage.Using<O, ActionResult>(o =>
                {
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
                                //ModelStorage.Remove(ModelUserContext.ClientID, (long)o.Key, null);
                                //ModelStorage.Put(ModelUserContext.ClientID, (long)o.Key, (long)o.Key, null, o);
                                ObjectStorage.Remove(ModelUserContext.ClientID, (long)o.Key, null);
                                ObjectStorage.Put(ModelUserContext.ClientID, (long)o.Key, (long)o.Key, null, o);
                    }
                }
            }

            return viewName == null ? View(o) : View(viewName, o);

                }, ModelUserContext.ClientID, key, null);
        }
        */
        
        #endregion


        #region Picker

        public ActionResult PickerInternal<A, O, P>(long key, long id, string nameList, A accessor, int? hacode,
            Func<DbManagerProxy, A, P, O> selector, Func<DbManagerProxy, A, P, O> creator,
            Action<DbManagerProxy, A, O> addition,
            bool bThrowIfNotFound = true)
            where A : IObjectAccessor, IObjectCreator<O>
            where O : class, IObject
            where P : class, IObject
        {
            //var list = ModelStorage.Get(ModelUserContext.ClientID, key, nameList) as EditableList<O>;
            //var root = (long)((IObject)ModelStorage.GetRoot(ModelUserContext.ClientID, key, null)).Key;
            //var parent = ModelStorage.Get(ModelUserContext.ClientID, key, null) as P;
            return ObjectStorage.Using2WithRoot<P, IList<O>, IObject, ActionResult>((parent, list, r) =>
                {
                    var root = r == null ? 0 : (long)r.Key;

            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                if (selector == null)
                    selector = (m, a, p) => list.Single(c => (long)c.Key == id).CloneWithSetup(manager) as O;
                if (creator == null)
                    creator = (m, a, p) => a.CreateNewT(m, parent, hacode);
                var o = (id == 0) ? creator(manager, accessor, parent) : selector(manager, accessor, parent);

                //AsSession.Check(ModelStorage.Get(ModelUserContext.ClientID, key, null), o);
                //AsSession.Check(ModelStorage.Get(ModelUserContext.ClientID, root, null), o);

                if (addition != null)
                    addition(manager, accessor, o);
                        //ModelStorage.Put(ModelUserContext.ClientID, root, (long)o.Key, null, o);
                        ObjectStorage.Put(ModelUserContext.ClientID, root, (long)o.Key, null, o);

                //AsSession.Check(ModelStorage.Get(ModelUserContext.ClientID, key, null), o);
                //AsSession.Check(ModelStorage.Get(ModelUserContext.ClientID, root, null), o);

                return View(o);
            }
                }, ModelUserContext.ClientID, key, nameList, bThrowIfNotFound);
        }


        public ActionResult PickerInternal<A, O, P>(FormCollection form, A accessor, string idName, 
            Func<P, EditableList<O>> list, Func<O, O, bool> predicate, Action<O, O> copy,
            Func<O, P, IObject, CompareModel> action = null, Func<O, O> fOriginal = null, bool bCompareParent = false, bool bCompareParentForAdditional = false,
            bool bDeepValidation = true,
            bool bThrowIfNotFound = true)
            where A : IObjectAccessor, IObjectValidator
            where O : class, IObject
            where P : class, IObject
        {
            var id = long.Parse(form[idName ?? accessor.KeyName]);

            form.AllKeys.ToList().ForEach(k => form[k] = EidssWebHelper.UnescapeHtml(form[k]));

            //var o = ModelStorage.Get(ModelUserContext.ClientID, id, null) as O;
            //var root = ModelStorage.GetRoot(ModelUserContext.ClientID, id, null) as P;
            return ObjectStorage.UsingWithRoot<O, P, ActionResult>((o, root) =>
                {
            var prnt = o.Parent is P ? (P)o.Parent : root;

            //AsSession.Check(ModelStorage.Get(ModelUserContext.ClientID, (long)root.Key, null), o);
            //AsSession.Check(ModelStorage.Get(ModelUserContext.ClientID, (long)prnt.Key, null), o);
            
            var data = new CompareModel();
            using (var clone = (bCompareParent ? ((root ?? prnt) as ICloneable).Clone() : (o as ICloneable).Clone()) as IObject)
            {
                using (var cloneParent = (bCompareParentForAdditional ? ((root ?? prnt) as ICloneable).Clone() : null) as IObject)
                {

                    //AsSession.Check(ModelStorage.Get(ModelUserContext.ClientID, (long)root.Key, null), o);
                    //AsSession.Check(ModelStorage.Get(ModelUserContext.ClientID, (long)prnt.Key, null), o);

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
                        data.Add("ErrorMessage", "ErrorMessage", 
                            validation.ValidationType == ValidationEventType.Error ? "ErrorMessage" : (validation.ValidationType == ValidationEventType.Warning ? "WarningPostMessage" : "AskPostMessage"),
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
                            data = action(o, root ?? prnt, clone);
                            if (data == null)
                            {
                                if (bCompareParentForAdditional)
                                    data = (root ?? prnt).Compare(cloneParent);
                                else
                                    data = o.Compare(clone);
                            }
                        }
                        else
                        {
                            //ModelStorage.Remove(ModelUserContext.ClientID, id, null);
                            ObjectStorage.Remove(ModelUserContext.ClientID, id, null);
                        }
                    }

                    //AsSession.Check(ModelStorage.Get(ModelUserContext.ClientID, (long)root.Key, null), o);
                    //AsSession.Check(ModelStorage.Get(ModelUserContext.ClientID, (long)prnt.Key, null), o);

                    return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
                }
            }
                }, ModelUserContext.ClientID, id, null, bThrowIfNotFound);
        }

        public ActionResult PickerInternalNotList<A, O, P>(FormCollection form, A accessor, string idName,
            Func<DbManagerProxy, P, O, CompareModel> action)
            where A : IObjectAccessor, IObjectValidator
            where O : class, IObject
            where P : class, IObject
        {
            var id = long.Parse(form[idName ?? accessor.KeyName]);

            form.AllKeys.ToList().ForEach(k => form[k] = EidssWebHelper.UnescapeHtml(form[k]));

            //var o = ModelStorage.Get(ModelUserContext.ClientID, id, null) as O;
            return ObjectStorage.Using<O, ActionResult>(o =>
                {
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
                        //ModelStorage.Remove(ModelUserContext.ClientID, id, null);
                        ObjectStorage.Remove(ModelUserContext.ClientID, id, null);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
                }, ModelUserContext.ClientID, id, null);
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


        protected static void SetAddressLookup<T>(CompareModel data, List<T> lookup, string starts, string ends, bool mandatory = false)
            where T : IObject
        {
            if (data.Values.Any(c => c.Key.StartsWith(starts) && c.Key.EndsWith(ends)))
            {
                var item = data.Values.FirstOrDefault(c => c.Key.StartsWith(starts) && c.Key.EndsWith(ends));
                item.Value.items = lookup.Select(c => new CompareModel.ComboBoxItem() { id = c.Key, name = c.ToStringProp }).ToArray();
                if (mandatory)
                    item.Value.mandatory = true;
            }
        }

    }
}
