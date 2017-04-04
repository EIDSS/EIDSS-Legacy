using System.Collections.Generic;
using System.Xml.Linq;
using System;
using System.Threading;
using bv.common.Configuration;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.web.common.Utils;

namespace eidss.webclient.Utils
{
    public class PermissionParser
    {
        public static List<MenuItem> GetPermittedIconMenu(XDocument document, eidss.model.Core.EidssUserContext context)
        {
            IEnumerable<XElement> items = document.Element("menu").Descendants("item");
            List<MenuItem> result = new List<MenuItem>();

            string culture = Thread.CurrentThread.CurrentCulture.ToString();

            foreach (var i in items)
            {
                long customization;
                if (context != null && !context.CanDo(i.Attribute("permission").Value) || (i.Attribute("denyCustomization") != null && !string.IsNullOrEmpty(i.Attribute("denyCustomization").Value) && long.TryParse(i.Attribute("denyCustomization").Value, out customization) && eidss.model.Core.EidssSiteContext.Instance.CustomizationPackageID == customization))
                {
                    continue;
                }

                MenuItem item = CreateMenuItem(i, culture, MenuItem.MenuItemFrom.Toolbar);               
                result.Add(item);                
            }

            return result;
        }

        public static List<MenuCategory> GetPermittedMenu(XDocument document, eidss.model.Core.EidssUserContext context)
        {
            IEnumerable<XElement> items = document.Element("menu").Descendants("item");
            List<MenuCategory> categories = new List<MenuCategory>();
            MenuCategory cat = null;
            
            bool isActive = true;
            string culture = Thread.CurrentThread.CurrentCulture.ToString();

            long customization;
            foreach (var i in items)
            {
                if (context != null && !context.CanDo(i.Attribute("permission").Value) || (i.Attribute("denyCustomization") != null && !string.IsNullOrEmpty(i.Attribute("denyCustomization").Value) && long.TryParse(i.Attribute("denyCustomization").Value, out customization) && eidss.model.Core.EidssSiteContext.Instance.CustomizationPackageID == customization))
                {
                    continue;
                }

                if (i.Attribute("siteTypeExclude") != null && !string.IsNullOrEmpty(i.Attribute("siteTypeExclude").Value))
                {
                    if (EidssSiteContext.Instance.RealSiteType == (SiteType) Enum.Parse(typeof (SiteType), i.Attribute("siteTypeExclude").Value))
                    {
                        continue;
                    }
                }

                if (i.Attribute("notForArchive") != null && !string.IsNullOrEmpty(i.Attribute("notForArchive").Value))
                {
                    if (i.Attribute("notForArchive").Value.ToLowerInvariant() == "true" && EidssUserContext.Instance.IsArchiveMode)
                    {
                        continue;
                    }
                }


                cat = new MenuCategory(Translator.GetMenuName(i.Attribute("ref").Value, i.Attribute("reskey").Value), true, null, i.Attribute("ref").Value == "MenuReports");
                if (i.Attribute("urlTop") != null && !string.IsNullOrEmpty(i.Attribute("urlTop").Value))
                {
                    if (i.Attribute("urlTop").Value.StartsWith("javascript:"))
                    {
                        cat.Url = i.Attribute("urlTop").Value;
                        // TODO переделать, это ужасно
                        cat.Url = cat.Url.Replace("%BaseSettings.CheckNotificationSeconds%", BaseSettings.CheckNotificationSeconds.ToString());
                    }
                    else
                        cat.Url = String.Format("/{0}{1}", culture, i.Attribute("urlTop").Value);

                    if (i.Attribute("popup") != null)
                    {
                        cat.IsPopup = Convert.ToBoolean(i.Attribute("popup").Value);
                    }

                    if (!cat.IsPopup && i.Attribute("modal") != null)
                    {
                        cat.IsModal = Convert.ToBoolean(i.Attribute("modal").Value);
                    }
                    isActive = false;
                }

                if (!i.HasElements && string.IsNullOrEmpty(cat.Url) && !cat.IsReport)
                {
                    continue;
                }


                foreach (var e in i.Descendants("item"))
                {
                    if (context != null && !context.CanDo(e.Attribute("permission").Value) || (e.Attribute("denyCustomization") != null && !string.IsNullOrEmpty(e.Attribute("denyCustomization").Value) && long.TryParse(e.Attribute("denyCustomization").Value, out customization) && eidss.model.Core.EidssSiteContext.Instance.CustomizationPackageID == customization))
                    {
                        isActive = false;
                        continue;
                    }

                    var menuItem = CreateMenuItem(e, culture, MenuItem.MenuItemFrom.Menu);

                    cat.Items.Add(menuItem);
                    isActive = isActive && !menuItem.IsActive;
                }

                cat.IsActive = !isActive;
                isActive = true;
                if (cat.Items.Count > 0 || !string.IsNullOrEmpty(cat.Url) || cat.IsReport)
                {
                    categories.Add(cat);
                }

            }

            return categories;
        }

        public static MenuItem CreateMenuItem(IMenuAction item, string culture, MenuItem.MenuItemFrom from)
        {
            string url = String.Format("/{0}{1}", culture, item.ActionUrl);

            var menuItem = new MenuItem(
                Translator.GetMenuName(item.ResourceKey, item.Caption),
                url,
                item.SelectPermission,
                from);
            menuItem.IsPopup = true;

            return menuItem;
        }
        public static MenuItem CreateMenuFolder(IMenuAction item)
        {
            var menuItem = new MenuItem(
                Translator.GetMenuName(item.ResourceKey, item.Caption),
                "",
                item.SelectPermission,
                MenuItem.MenuItemFrom.Menu
                );

            return menuItem;
        }


        private static MenuItem CreateMenuItem(XElement description, string culture, MenuItem.MenuItemFrom from)
        {
            string url = String.Format("/{0}{1}", culture, description.Attribute("url").Value);
            
            if (description.Attribute("IsExternal") != null && Convert.ToBoolean(description.Attribute("IsExternal").Value))
            {
                url = description.Attribute("url").Value;
            }

            var menuItem = new MenuItem(
                Translator.GetMenuName(description.Attribute("ref").Value, description.Attribute("reskey").Value),
                url,
                description.Attribute("permission").Value,
                from,
                String.Empty,
                true);


            if (description.Attribute("popup") != null)
            {
                menuItem.IsPopup = Convert.ToBoolean(description.Attribute("popup").Value);
            }

            if (!menuItem.IsPopup && description.Attribute("modal") != null)
            {
                menuItem.IsModal = Convert.ToBoolean(description.Attribute("modal").Value);
            }

            if (description.Attribute("help") != null)
            {
                menuItem.IsHelp = Convert.ToBoolean(description.Attribute("help").Value);
            }

            if (description.Attribute("icon") != null)
            {
                menuItem.IconName = description.Attribute("icon").Value;
            }

            if (description.Attribute("isLastInSection") != null)
            {
                menuItem.IsLastInSection = Convert.ToBoolean(description.Attribute("isLastInSection").Value);
            }

            return menuItem;
        }

    }
}