using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using bv.common.Core;
using bv.model.BLToolkit;
using BLToolkit.Data;
using BLToolkit.TypeBuilder;
using eidss.model.Avr;
using eidss.model.Avr.Tree;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.model.Reports
{
    public abstract class BaseMenuReportRegistrator
    {
        private IMenuAction m_StandardReportsCategory;
        private IMenuAction m_PaperFormsCategory;
        private IMenuAction m_AvrReportsCategory;
        private IMenuAction m_HumanCategory;
        private IMenuAction m_ZoonoticCategory;
        private IMenuAction m_SimplifiedCategory;
        private IMenuAction m_HumanGGOldRevisionCategory;
        private IMenuAction m_VetCategory;
        private IMenuAction m_LabCategory;
        private IMenuAction m_AdminCategory;
        private IMenuAction m_AberrationCategory;

        #region Properties

        protected IMenuAction PaperFormsCategory
        {
            get
            {
                if (m_PaperFormsCategory == null)
                {
                    m_PaperFormsCategory = RegisterSubMenu("MenuPaperForms", EIDSSPermissionObject.Report, 500);
                    m_PaperFormsCategory.SmallIconIndex = (int) MenuIconsSmall.Reports;
                }
                return m_PaperFormsCategory;
            }
        }

        protected IMenuAction StandardReportsCategory
        {
            get
            {
                if (m_StandardReportsCategory == null)
                {
                    m_StandardReportsCategory = RegisterSubMenu("menuStndReports", EIDSSPermissionObject.Report, 1000);
                    m_StandardReportsCategory.SmallIconIndex = (int) MenuIconsSmall.Reports;
                }
                return m_StandardReportsCategory;
            }
        }

        protected IMenuAction AvrReportsCategory
        {
            get
            {
                if (m_AvrReportsCategory == null)
                {
                    m_AvrReportsCategory = RegisterSubMenu("menuAvrReports", EIDSSPermissionObject.AVRReport, 1100);
                    m_AvrReportsCategory.SmallIconIndex = (int) MenuIconsSmall.Reports;
                }
                return m_AvrReportsCategory;
            }
        }

        protected IMenuAction HumanCategory
        {
            get
            {
                if (m_HumanCategory == null)
                {
                    m_HumanCategory = RegisterSubMenu(StandardReportsCategory, "MenuHumanReports", EIDSSPermissionObject.HumanCase, 10000);
                    m_HumanCategory.SmallIconIndex = (int) MenuIconsSmall.HumanReport;
                }
                return m_HumanCategory;
            }
        }

        protected IMenuAction HumanGGOldRevisionCategory
        {
            get
            {
                if (m_HumanGGOldRevisionCategory == null)
                {
                    m_HumanGGOldRevisionCategory = RegisterSubMenu(HumanCategory, "MenuHumanGGOldRevisionReports",
                        EIDSSPermissionObject.HumanCase, 385);
                    m_HumanGGOldRevisionCategory.SmallIconIndex = (int) MenuIconsSmall.HumanReport;
                }
                return m_HumanGGOldRevisionCategory;
            }
        }

        protected IMenuAction LabCategory
        {
            get
            {
                if (m_LabCategory == null)
                {
                    m_LabCategory = RegisterSubMenu(StandardReportsCategory, "MenuLaboratoryReports", EIDSSPermissionObject.Sample, 15000);
                    m_LabCategory.SmallIconIndex = (int)MenuIconsSmall.LabReport;
                }

                return m_LabCategory;
            }
        }
        protected IMenuAction VetCategory
        {
            get
            {
                if (m_VetCategory == null)
                {
                    m_VetCategory = RegisterSubMenu(StandardReportsCategory, "MenuVetReports", EIDSSPermissionObject.VetCase, 20000);
                    m_VetCategory.SmallIconIndex = (int) MenuIconsSmall.VetReport;
                }
                return m_VetCategory;
            }
        }

      

        protected IMenuAction ZoonoticCategory
        {
            get
            {
                if (m_ZoonoticCategory == null)
                {
                    m_ZoonoticCategory = RegisterSubMenu(StandardReportsCategory, "MenuZoonoticReports", EIDSSPermissionObject.Report, 25000);
                    m_ZoonoticCategory.SmallIconIndex = (int) MenuIconsSmall.HumanCase;
                }
                return m_ZoonoticCategory;
            }
        }

        protected IMenuAction SimplifiedCategory
        {
            get
            {
                if (m_SimplifiedCategory == null)
                {
                    m_SimplifiedCategory = RegisterSubMenu(HumanCategory, "MenuSimplifiedReports",
                        EIDSSPermissionObject.HumanCase, 100);
                    m_SimplifiedCategory.SmallIconIndex = (int) MenuIconsSmall.HumanReport;
                }

                return m_SimplifiedCategory;
            }
        }

        protected IMenuAction AdminCategory
        {
            get
            {
                if (m_AdminCategory == null)
                {
                    m_AdminCategory =
                        RegisterSubMenu(StandardReportsCategory, "MenuAdministrativeReports", EIDSSPermissionObject.Report, 35000);
                    m_AdminCategory.SmallIconIndex = (int) MenuIconsSmall.AdminReport;
                }

                return m_AdminCategory;
            }
        }

        protected IMenuAction AberrationCategory
        {
            get
            {
                if (m_AberrationCategory == null)
                {
                    m_AberrationCategory =
                        RegisterSubMenu(StandardReportsCategory, "MenuAberrationReports", EIDSSPermissionObject.Report, 40000);
                    m_AberrationCategory.SmallIconIndex = (int) MenuIconsSmall.AberrationReport;
                }

                return m_AberrationCategory;
            }
        }

        #endregion

        #region Paper forms 

        protected abstract void RegisterStandartReport(IMenuAction category, MenuReportDescriptionAttribute attribute, MethodInfo info);

        protected abstract IMenuAction RegisterSubMenu(string resourceKey, EIDSSPermissionObject permission, int order);

        protected abstract IMenuAction RegisterSubMenu
            (IMenuAction category, string resourceKey, EIDSSPermissionObject permission, int order);

        protected void RegisterAllStandartReports()
        {
            DataView lookup = GetDeniedReportsLookup();

            foreach (MethodInfo info in typeof (IReportFactory).GetMethods())
            {
                MenuReportDescriptionAttribute attribute = GetMenuActionDescriptionAttribute(info);

                if (!IsDenyInDescription(attribute) && !IsDenyInDataGroup(info) && !IsDenyInCustomization(info))
                {
                    lookup.RowFilter = string.Format("strReportAlias = '{0}'", attribute.Caption);
                    bool avaliable = lookup.Count == 0;
                    IMenuAction category;
                    if (avaliable && TryGetSubMenuCategory(attribute.SubMenu, out category))
                    {
                        RegisterStandartReport(category, attribute, info);
                    }
                }
            }
        }

        public static bool IsPaperFormAllowed(string name)
        {
            MethodInfo info = typeof (IReportFactory).GetMethod(name);
            if (info == null)
            {
                return false;
            }
            return !IsDenyInDataGroup(info) && !IsDenyInCustomization(info);
        }

        protected internal static bool IsDenyInDescription(MenuReportDescriptionAttribute attribute)
        {
            if (attribute == null)
            {
                return true;
            }
            bool denyPermission = false;
            if (attribute.PermissionObjects != null)
            {
                foreach (EIDSSPermissionObject permission in attribute.PermissionObjects)
                {
                    if (permission != 0 && attribute.PermissionActions != null)
                    {
                        foreach (string action in attribute.PermissionActions)
                        {
                            switch (action)
                            {
                                case PermissionHelper.Select:
                                    denyPermission = !EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(permission));
                                    break;
                                case PermissionHelper.Execute:
                                    denyPermission = !EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(permission));
                                    break;
                                case PermissionHelper.Insert:
                                    denyPermission = !EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(permission));
                                    break;
                                case PermissionHelper.Update:
                                    denyPermission = !EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission(permission));
                                    break;
                                case PermissionHelper.Delete:
                                    denyPermission = !EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission(permission));
                                    break;
                            }
                        }
                        if (denyPermission)
                        {
                            break;
                        }
                    }
                }
            }

            return denyPermission;
        }

        protected internal static DataView GetDeniedReportsLookup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                DbManager command = manager.SetSpCommand("spRepDeniedReportsLookup",
                    manager.Parameter("SiteID", EidssSiteContext.Instance.SiteID),
                    manager.Parameter("UserID", Convert.ToInt64(EidssUserContext.User.ID))
                    );
                DataTable dataTable = command.ExecuteDataTable();
                return new DataView(dataTable);
            }
        }

        protected internal static bool IsDenyInDataGroup(MethodInfo info)
        {
            Utils.CheckNotNull(info, "handler");

            var attribute = (ForbiddenDataGroupAttribute)
                info.GetCustomAttributes(typeof (ForbiddenDataGroupAttribute), true).FirstOrDefault();
            return (attribute != null) && attribute.DataGroups.Any(g => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(g));
        }

        protected internal static bool IsDenyInCustomization(MethodInfo info)
        {
            Utils.CheckNotNull(info, "handler");

            var attribute = (MenuReportCustomizationAttribute)
                info.GetCustomAttributes(typeof (MenuReportCustomizationAttribute), true).FirstOrDefault();

            // if no attribute set - report denied
            if (attribute == null)
            {
                return true;
            }

            // attribute is set but has no allowed or forbidden customization packages - report allowed
            var allowed = (long) attribute.Allowed;
            CustomizationPackage[] forbidden = attribute.Forbidden ?? new CustomizationPackage[0];
            if (allowed == 0 && forbidden.Length == 0)
            {
                return false;
            }

            // If allowed customization package doesn't equal to current customization package
            // or forbidden customization package equals to current customization package  - report denied
            long currentPackage = EidssSiteContext.Instance.CustomizationPackageID;
            if ((allowed != 0 && allowed != currentPackage) || forbidden.Contains((CustomizationPackage) currentPackage))
            {
                return true;
            }

            return false;
        }

        protected internal static MenuReportDescriptionAttribute GetMenuActionDescriptionAttribute(MethodInfo info)
        {
            Utils.CheckNotNull(info, "info");

            var attribute = (MenuReportDescriptionAttribute)
                info.GetCustomAttributes(typeof (MenuReportDescriptionAttribute), true).FirstOrDefault();

            return attribute;
        }

        protected bool TryGetSubMenuCategory(ReportSubMenu subMenu, out IMenuAction category)
        {
            category = null;
            switch (subMenu)
            {
                case ReportSubMenu.StandardReports:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Report)))
                    {
                        return false;
                    }
                    category = StandardReportsCategory;
                    break;
                case ReportSubMenu.Admin:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.EventLog)))
                    {
                        return false;
                    }
                    category = AdminCategory;
                    break;
                case ReportSubMenu.Human:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase)))
                    {
                        return false;
                    }
                    category = HumanCategory;
                    break;
                case ReportSubMenu.HumanGGOldRevision:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase)))
                    {
                        return false;
                    }
                    category = HumanGGOldRevisionCategory;
                    break;
                case ReportSubMenu.Lab:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Sample)))
                    {
                        return false;
                    }
                    category = LabCategory;
                    break;
                case ReportSubMenu.Vet:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase)))
                    {
                        return false;
                    }

                    category = VetCategory;
                    break;

                case ReportSubMenu.Aberration:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Report)))
                    {
                        return false;
                    }
                    category = AberrationCategory;
                    break;
                case ReportSubMenu.Zoonotic:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Report)))
                    {
                        return false;
                    }
                    category = ZoonoticCategory;
                    break;

                case ReportSubMenu.Simplified:
                    if (!EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.Report)))
                    {
                        return false;
                    }
                    category = SimplifiedCategory;
                    break;
                default:
                    throw new ArgumentException(string.Format("{0} is not supportedtype of submenu", subMenu));
            }
            return true;
        }

        #endregion

        #region AVR reports

        public IMenuAction RegisterAllAvrReports()
        {
            AvrReportsCategory.SmallIconIndex = (int) MenuIconsSmall.LaunchAVR;

            string avrPermissions = PermissionHelper.SelectPermission(EIDSSPermissionObject.AVRReport);
            if (EidssUserContext.User.HasPermission(avrPermissions))
            {
                int order = 0;
                foreach (KeyValuePair<long, string> pair in GetAvrQueries())
                {
                    order += 100;
                    long queryId = pair.Key;
                    string queryName = pair.Value;

                    EidssUserContext.CheckUserLoggedIn();
                    List<AvrTreeElement> layouts = AvrQueryLayoutTreeDbHelper.ReLoadLayouts(true, queryId);
                    List<AvrTreeElement> readOnlyLayouts = layouts.Where(l => l.ReadOnly).ToList();
                    if (readOnlyLayouts.Count == 0)
                    {
                        continue;
                    }
                    List<AvrTreeElement> folders = AvrQueryLayoutTreeDbHelper.ReLoadFolders(true, queryId);

                    DeleteAvrEmptyFolders(readOnlyLayouts, folders);

                    IMenuAction queryMenuAction = AddEmptyAvrMenuAction(AvrReportsCategory, queryName, order);

                    CreateAvrFoldersLayoutsMenu(queryMenuAction, readOnlyLayouts, folders);
                }
            }

            return AvrReportsCategory;
        }

        internal void CreateAvrFoldersLayoutsMenu
            (IMenuAction queryMenuAction, IEnumerable<AvrTreeElement> layouts, ICollection<AvrTreeElement> folders)
        {
            int order = 1;
            var menuActions = new Dictionary<long, IMenuAction>();
            for (int index = 0; index < folders.Count + 1; index++)
            {
                var processedFolders = new List<AvrTreeElement>();
                foreach (AvrTreeElement folder in folders)
                {
                    IMenuAction parentMenuAction = (folder.ParentID.HasValue && menuActions.ContainsKey(folder.ParentID.Value))
                        ? menuActions[folder.ParentID.Value]
                        : queryMenuAction;
                    if (parentMenuAction != null)
                    {
                        order++;
                        IMenuAction childMenuAction = AddEmptyAvrMenuAction(parentMenuAction, folder.NationalName, order);

                        menuActions.Add(folder.ID, childMenuAction);
                        processedFolders.Add(folder);
                    }
                }
                foreach (AvrTreeElement folder in processedFolders)
                {
                    folders.Remove(folder);
                }
                if (folders.Count == 0)
                {
                    break;
                }
            }
            foreach (AvrTreeElement layout in layouts)
            {
                IMenuAction parentMenuAction = queryMenuAction;
                if (layout.ParentID.HasValue)
                {
                    if (!menuActions.TryGetValue(layout.ParentID.Value, out parentMenuAction))
                    {
                        parentMenuAction = queryMenuAction;
                    }
                }
                order++;
                AddAvrMenuAction(parentMenuAction, layout.NationalName, layout.QueryID, layout.ID, order, true);
            }
        }

        protected IMenuAction AddEmptyAvrMenuAction(IMenuAction parent, string name, int order)
        {
            return AddAvrMenuAction(parent, name, -1, -1, order, false);
        }

        protected abstract IMenuAction AddAvrMenuAction
            (IMenuAction parent, string name, long queryId, long layoutId, int order, bool hasAction);

        internal static Dictionary<long, string> GetAvrQueries()
        {
            List<AvrTreeElement> queries = AvrQueryLayoutTreeDbHelper.ReLoadQueries(true);
            Dictionary<long, string> result = queries.ToDictionary(query => query.QueryID, query => query.NationalName);
            return result;
            //            
//            DataView view = LookupBinder.GetQueryDataView(false);
//            view.Sort = "intOrder, QueryName";
//          
//            foreach (DataRowView row in view)
//            {
//                var queryId = (long)row["idflQuery"];
//                string queryName = row["QueryName"].ToString();
//
//                result.Add(queryId, queryName);
//            }
        }

        internal static void DeleteAvrEmptyFolders(IEnumerable<AvrTreeElement> layouts, ICollection<AvrTreeElement> folders)
        {
            var treeElements = new List<AvrTreeElement>(layouts);
            treeElements.AddRange(folders);

            for (int index = 0; index < folders.Count; index++)
            {
                var parentList = new List<long>();
                foreach (AvrTreeElement element in treeElements)
                {
                    if ((element.ParentID.HasValue) && (!parentList.Contains(element.ParentID.Value)))
                    {
                        parentList.Add(element.ParentID.Value);
                    }
                }
                List<AvrTreeElement> foldersToRemove =
                    folders.Where(folder => !parentList.Contains(folder.ID)).ToList();
                foreach (AvrTreeElement folder in foldersToRemove)
                {
                    folders.Remove(folder);
                    treeElements.Remove(folder);
                }
            }
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

        #endregion
    }
}