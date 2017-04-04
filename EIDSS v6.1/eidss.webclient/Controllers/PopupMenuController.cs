using System;
using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using Kendo.Mvc.UI;
using bv.common.Enums;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using bv.model.Model.Core;
using eidss.model.Enums;
using System.Collections.Generic;
using System.Collections;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class PopupMenuController : BvController
    {
        public ActionResult PopupMenu(IObjectMeta meta, string selector)
        {
            ViewBag.Selector = selector;
            return PartialView(meta);
        }


        public class MenuItem
        {
            public string text { get; set; }
            public bool encoded { get; set; }
            public bool enabled { get; set; }
            public MenuItem[] items { get; set; }
        }

        [CompressFilter]
        public ActionResult Reports(long root, string idents)
        {
            //var objs = idents.Split(',').Select(c => ModelStorage.Get(ModelUserContext.ClientID, long.Parse(c), "_" + root) as IObject).ToList();
            return ObjectStorage.Using<IObject, ActionResult>(obj =>
            {
                var list = MenuList(new List<IObject>() { obj.Parent == null ? obj : obj.Parent }, root, idents, true);

                var json = new JsonResult { Data = list.ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                return json;
            }, ModelUserContext.ClientID, root, "");
        }

        [CompressFilter]
        public ActionResult ReportsAdditional(long root, string idents)
        {
            //var objs = idents.Split(',').Select(c => ModelStorage.Get(ModelUserContext.ClientID, long.Parse(c), "_" + root) as IObject).ToList();
            return ObjectStorage.Using<IObject, ActionResult>(obj =>
            {
                var list = MenuList(new List<IObject>() { obj.Parent == null ? obj : obj.Parent }, root, idents, true, ActionsPanelType.ContextMenuAdditional);

                var json = new JsonResult { Data = list.ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                return json;
            }, ModelUserContext.ClientID, root, "");
        }


        [CompressFilter]
        public ActionResult Content(long root, string idents)
        {
            //var objs = idents.Split(',').Select(c => ModelStorage.Get(ModelUserContext.ClientID, long.Parse(c), "_" + root) as IObject).ToList();
            return ObjectStorage.UsingList<IObject, ActionResult>(objs =>
                {
                    var list = MenuList(objs, root, idents);

                    var json = new JsonResult { Data = list.ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    return json;
                }, ModelUserContext.ClientID, idents.Split(',').Select(c => new Tuple<long, string>(long.Parse(c), "_" + root)));
        }

        [CompressFilter]
        public ActionResult ContentLabSection(long root, string idents)
        {
            //var master = ModelStorage.Get(ModelUserContext.ClientID, root, null) as LaboratorySectionMaster;
            return ObjectStorage.Using<LaboratorySectionMaster, ActionResult>(master =>
                {
                    var objs = idents.Split(',').Select(c => master.LaboratorySectionItems.FirstOrDefault(i => i.idfMaterial == long.Parse(c) || i.idfTesting == long.Parse(c)) as IObject).ToList();
                    var list = MenuList(objs, root, idents);

                    var json = new JsonResult { Data = list.ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    return json;
                }, ModelUserContext.ClientID, root, null);
        }

        [CompressFilter]
        public ActionResult ContentLabSectionMyPref(long root, string idents)
        {
            //var master = ModelStorage.Get(ModelUserContext.ClientID, root, null) as LaboratorySectionMaster;
            return ObjectStorage.Using<LaboratorySectionMaster, ActionResult>(master =>
                {
                    var objs = idents.Split(',').Select(c => master.LaboratorySectionMyPrefItems.FirstOrDefault(i => i.idfMaterial == long.Parse(c) || i.idfTesting == long.Parse(c)) as IObject).ToList();
                    var list = MenuList(objs, root, idents);

                    var json = new JsonResult { Data = list.ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    return json;
                }, ModelUserContext.ClientID, root, null);
        }

        private List<MenuItem> MenuList(List<IObject> objs, long root, string idents, bool isHideDisabled = false, ActionsPanelType panelType = ActionsPanelType.ContextMenu)
        {
            var o = objs[0];
            var p = o.GetPermissions();
            var meta = o.GetAccessor() as IObjectMeta;

            var list =
                meta.Actions.Where(c => c.PanelType == panelType && (c.AppType == ActionsAppType.Web || c.AppType == ActionsAppType.All))
                    .Where(c => isHideDisabled ? c.IsVisible(objs, p) : true)
                    .ToList().Select(c => new MenuItem
                    {
                        text = c.Children(objs).Any()
                            ? Translator.GetBvOrEidssMessageString(c.CaptionId(o, p))
                            : (c.CaptionId(o, p) == "-"
                                ? "<hr />"
                                : Translator.GetBvOrEidssMessageString(c.CaptionId(o, p)) + string.Format("<span style='visibility: hidden' root='{0}' idents='{1}' action='{2}' method='{3}' />", root, idents, c.Name, c.IsWebJScript ? c.MethodName : "")
                                ),
                        enabled = c.CaptionId(o, p) != "-" && c.IsVisible(objs, p),
                        encoded = false,
                        items = !c.Children(objs).Any()
                            ? null
                            : c.Children(objs).Select(i => new MenuItem()
                            {
                                text = i.Children(objs).Any()
                                    ? Translator.GetBvOrEidssMessageString(i.CaptionId(o, p))
                                    : (i.CaptionId(o, p) == "-"
                                        ? "<hr />"
                                        : Translator.GetBvOrEidssMessageString(i.CaptionId(o, p)) + string.Format("<span style='visibility: hidden' root='{0}' idents='{1}' action='{2}' method='{3}' />", root, idents, i.Name, i.IsWebJScript ? i.MethodName : "")
                                        ),
                                enabled = i.IsVisible(objs, p),
                                encoded = false,
                                items = !i.Children(objs).Any()
                                    ? null
                                    : i.Children(objs).Select(j => new MenuItem()
                                    {
                                        text = Translator.GetBvOrEidssMessageString(j.CaptionId(o, p)) + string.Format("<span style='visibility: hidden' root='{0}' idents='{1}' action='{2}' method='{3}' />", root, idents, j.Name, j.IsWebJScript ? j.MethodName : ""),
                                        enabled = j.IsVisible(objs, p),
                                        encoded = false
                                    }).ToArray()

                            }).ToArray()
                    }
                    ).ToList();

            int sepIndex = -1;
            var sepIndexes = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].text == "<hr />" && i == sepIndex + 1)
                    sepIndexes.Add(i);
                if (list[i].text == "<hr />")
                    sepIndex = i;
            }
            sepIndexes.Reverse();
            sepIndexes.ForEach(i => list.RemoveAt(i));

            return list;
        }

        private ActionMetaItem FindAction(List<ActionMetaItem> actions, string name, IObject o)
        {
            var ret = actions.FirstOrDefault(c => (c.PanelType == ActionsPanelType.ContextMenu || c.PanelType == ActionsPanelType.ContextMenuAdditional) && c.Name == name);
            if (ret == null)
            {
                foreach (var a in actions)
                {
                    ret = FindAction(a.Children(o), name, o);
                    if (ret != null)
                        break;
                }
            }
            return ret;
        }


        public ActionResult SelectReport(long root, string idents, string name)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                ObjectStorage.Using<IObject, bool>(o =>
                {
                    IObjectMeta meta = o.GetAccessor() as IObjectMeta;
                    var action = FindAction(meta.Actions, name, o);
                    if (action != null)
                    {
                        action.RunAction(manager, o);
                    }
                    return false;
                }, ModelUserContext.ClientID, root, null);
            }

            var json = new JsonResult { Data = new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        public ActionResult Select(long root, string idents, string name)
        {
            string[] ids = idents.Split(',');

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                foreach (var s in ids)
                {
                    long id = long.Parse(s);
                    //var o = ModelStorage.Get(ModelUserContext.ClientID, id, "_" + root) as IObject;
                    ObjectStorage.Using<IObject, bool>(o =>
                        {
                            IObjectMeta meta = o.GetAccessor() as IObjectMeta;
                            var action = FindAction(meta.Actions, name, o);
                            if (action != null)
                            {
                                action.RunAction(manager, o);
                            }
                            return false;
                        }, ModelUserContext.ClientID, id, "_" + root, ForceLock: ForceReadWriteLockType.Write);
                }
            }

            var json = new JsonResult { Data = new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        public ActionResult SelectLab(long root, string idents, string name)
        {
            //var master = ModelStorage.Get(ModelUserContext.ClientID, root, null) as LaboratorySectionMaster;
            return ObjectStorage.Using<LaboratorySectionMaster, ActionResult>(master =>
                {
                    var objs = idents.Split(',').Select(c => master.LaboratorySectionItems.FirstOrDefault(i => i.idfMaterial == long.Parse(c) || i.idfTesting == long.Parse(c)) as IObject).ToList();

                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                    {
                        foreach (var o in objs)
                        {
                            IObjectMeta meta = o.GetAccessor() as IObjectMeta;
                            var action = FindAction(meta.Actions, name, o);
                            if (action != null)
                            {
                                action.RunAction(manager, o);
                            }
                        }
                    }
                    var json = new JsonResult { Data = new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    return json;
                }, ModelUserContext.ClientID, root, null, ForceLock: ForceReadWriteLockType.Write);
        }

        public ActionResult SelectLabMyPref(long root, string idents, string name)
        {
            //var master = ModelStorage.Get(ModelUserContext.ClientID, root, null) as LaboratorySectionMaster;
            return ObjectStorage.Using<LaboratorySectionMaster, ActionResult>(master =>
                {
                    var objs = idents.Split(',').Select(c => master.LaboratorySectionMyPrefItems.FirstOrDefault(i => i.idfMaterial == long.Parse(c) || i.idfTesting == long.Parse(c)) as IObject).ToList();

                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                    {
                        foreach (var o in objs)
                        {
                            IObjectMeta meta = o.GetAccessor() as IObjectMeta;
                            var action = FindAction(meta.Actions, name, o);
                            if (action != null)
                            {
                                action.RunAction(manager, o);
                            }
                        }
                    }
                    var json = new JsonResult { Data = new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    return json;
                }, ModelUserContext.ClientID, root, null, ForceLock: ForceReadWriteLockType.Write);
        }

    }
}

