using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common.Core;
using bv.winclient.Core;
using EIDSS.Core;
using eidss.model.Core;
using eidss.model.Enums;
using EIDSS.RAM_DB.Common;
using EIDSS.RAM_DB.DBService;

namespace EIDSS.RAM.Presenters.RamForm
{
    public static class RamMenuRegistrator
    {
        public static MenuAction RegisterWinStaticReports(MenuAction.ActionHandler showReportAction)
        {
            MenuAction category = MenuActionManager.Instance.FindAction("menuStndReports",
                                                                        MenuActionManager.Instance.Reports, 601);

            string avrPermissions = PermissionHelper.SelectPermission(EIDSSPermissionObject.AVRReport);
            if (EidssUserContext.User.HasPermission(avrPermissions))
            {
                int order = 0;
                foreach (KeyValuePair<long, string> pair in GetQueries())
                {
                    order += 100;
                    long queryId = pair.Key;
                    string queryName = pair.Value;

                    EidssUserContext.CheckUserLoggedIn();
                    List<LayoutTreeElement> layouts = LayoutInfo_DB.LoadLayouts(queryId,(long) EidssUserContext.User.ID,true);
                    if (layouts.Count == 0)
                    {
                        continue;
                    }
                    List<LayoutTreeElement> folders = LayoutInfo_DB.LoadFolders(queryId, true);

                    DeleteEmptyFolders(layouts, folders);

                    MenuAction queryMenuAction = AddMenuAction(category, order, queryId, queryName);

                    CreateFoldersLayoutsMenu(showReportAction, queryMenuAction, layouts, folders);
                }
            }

            return category;
        }

        public static WebReportLink RegisterWebStaticReports()
        {
            var root = new WebReportLink("Reprors");
            foreach (KeyValuePair<long, string> pair in GetQueries())
            {
                long queryId = pair.Key;
                string queryName = pair.Value;

                List<LayoutTreeElement> layouts = LayoutInfo_DB.LoadLayouts(queryId, -1, true);
                if (layouts.Count == 0)
                {
                    continue;
                }
                List<LayoutTreeElement> folders = LayoutInfo_DB.LoadFolders(queryId, true);

                DeleteEmptyFolders(layouts, folders);
                var queryLink = new WebReportLink(queryName) {QueryId = queryId};
                root.Children.Add(queryLink);
                CreateFoldersLayoutsLinks(queryLink, layouts, folders);
            }

            return root;
        }


        internal static void CreateFoldersLayoutsLinks
          (WebReportLink queryLink, 
            IEnumerable<LayoutTreeElement> layouts, 
            ICollection<LayoutTreeElement> folders)
        {
            var links = new Dictionary<long, WebReportLink>();
            for (int index = 0; index < folders.Count + 1; index++)
            {
                var processedFolders = new List<LayoutTreeElement>();
                foreach (LayoutTreeElement folder in folders)
                {
                    WebReportLink parentLink = null;
                    if (folder.ParentID.HasValue)
                    {
                        if (links.ContainsKey(folder.ParentID.Value))
                        {
                            parentLink = links[folder.ParentID.Value];
                        }
                    }
                    else
                    {
                        parentLink = queryLink;
                    }
                    if (parentLink != null)
                    {
                        var childLink = new WebReportLink(folder.NationalName) { QueryId = queryLink.QueryId };  
                        parentLink.Children.Add(childLink);
                        links.Add(folder.ID, childLink);
                        processedFolders.Add(folder);
                    }
                }
                foreach (LayoutTreeElement folder in processedFolders)
                {
                    folders.Remove(folder);
                }
                if (folders.Count == 0)
                {
                    break;
                }
            }
            foreach (LayoutTreeElement layout in layouts)
            {
                WebReportLink parentLink = queryLink;
                if (layout.ParentID.HasValue)
                {
                    if (!links.TryGetValue(layout.ParentID.Value, out parentLink))
                    {
                        parentLink = queryLink;
                    }
                }
                var childLink = new WebReportLink(layout.NationalName, queryLink.QueryId, layout.ID); 
                parentLink.Children.Add(childLink);
            }
        }


        internal static void CreateFoldersLayoutsMenu
            (MenuAction.ActionHandler showReportAction,
             MenuAction queryMenuAction, IEnumerable<LayoutTreeElement> layouts,
             ICollection<LayoutTreeElement> folders)
        {
            int order = 1;
            var menuActions = new Dictionary<long, MenuAction>();
            for (int index = 0; index < folders.Count + 1; index++)
            {
                var processedFolders = new List<LayoutTreeElement>();
                foreach (LayoutTreeElement folder in folders)
                {
                    MenuAction parentMenuAction = null;
                    if (folder.ParentID.HasValue)
                    {
                        if (menuActions.ContainsKey(folder.ParentID.Value))
                        {
                            parentMenuAction = menuActions[folder.ParentID.Value];
                        }
                    }
                    else
                    {
                        parentMenuAction = queryMenuAction;
                    }
                    if (parentMenuAction != null)
                    {
                        order++;
                        MenuAction childMenuAction = AddMenuAction(parentMenuAction, order, folder.ID,
                                                                   folder.NationalName);

                        menuActions.Add(folder.ID, childMenuAction);
                        processedFolders.Add(folder);
                    }
                }
                foreach (LayoutTreeElement folder in processedFolders)
                {
                    folders.Remove(folder);
                }
                if (folders.Count == 0)
                {
                    break;
                }
            }
            foreach (LayoutTreeElement layout in layouts)
            {
                MenuAction parentMenuAction = queryMenuAction;
                if (layout.ParentID.HasValue)
                {
                    if (!menuActions.TryGetValue(layout.ParentID.Value, out parentMenuAction))
                    {
                        parentMenuAction = queryMenuAction;
                    }
                }
                order++;
                AddMenuAction(showReportAction, parentMenuAction, order, layout.ID, layout.NationalName);
            }
        }

        private static MenuAction AddMenuAction(MenuAction parent, int order, long id, string name)
        {
            return AddMenuAction(null, parent, order, id, name);
        }

        private static MenuAction AddMenuAction
            (MenuAction.ActionHandler actionHandler, MenuAction parent, int order,
             long id, string name)
        {
            var child = new MenuAction(actionHandler, MenuActionManager.Instance, parent, name, order)
                            {
                                Name = "btnStandardReport" + id,
                                Caption = name,
                                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.AVRReport)
                            };
            return child;
        }

        internal static void DeleteEmptyFolders
            (IEnumerable<LayoutTreeElement> layouts,
             ICollection<LayoutTreeElement> folders)
        {
            var treeElements = new List<LayoutTreeElement>(layouts);
            treeElements.AddRange(folders);

            for (int index = 0; index < folders.Count; index++)
            {
                var parentList = new List<long>();
                foreach (LayoutTreeElement element in treeElements)
                {
                    if ((element.ParentID.HasValue) && (!parentList.Contains(element.ParentID.Value)))
                    {
                        parentList.Add(element.ParentID.Value);
                    }
                }
                List<LayoutTreeElement> foldersToRemove =
                    folders.Where(folder => !parentList.Contains(folder.ID)).ToList();
                foreach (LayoutTreeElement folder in foldersToRemove)
                {
                    folders.Remove(folder);
                    treeElements.Remove(folder);
                }
            }
        }

        private static Dictionary<long, string> GetQueries()
        {
            DataView view = LookupBinder.GetQueryDataView(false);
            view.Sort = "intOrder, QueryName";
            var result = new Dictionary<long, string>();
            foreach (DataRowView row in view)
            {
                var queryId = (long) row["idflQuery"];
                string queryName = row["QueryName"].ToString();

                result.Add(queryId, queryName);
            }

            return result;
        }

        internal static string GetAvrPermissions(int haCode)
        {
            string permissions = string.Empty;
            bool isVet = (haCode & 1) != 0;
            bool isHuman = (haCode & 2) != 0;
            string vetPerm = PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase);
            string humanPerm = PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase);

            if (isVet && isHuman)
            {
                permissions = string.Format("{0}|{1}", humanPerm, vetPerm);
            }
            else
            {
                if (isVet)
                {
                    permissions = vetPerm;
                }
                if (isHuman)
                {
                    permissions = humanPerm;
                }
            }
            return permissions;
        }
    }
}