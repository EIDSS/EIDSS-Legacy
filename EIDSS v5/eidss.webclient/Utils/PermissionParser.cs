using System.Collections.Generic;
using System.Xml.Linq;
using System;
using System.Threading;
using bv.common.Core;
using eidss.model.Resources;

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
                if (context != null && !context.CanDo(i.Attribute("permission").Value))
                {
                    continue;
                }

                MenuItem item = CreateMenuItem(i, culture);               
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

            foreach (var i in items)
            {
                if (context != null && !context.CanDo(i.Attribute("permission").Value))
                {
                    continue;
                }

                cat = new MenuCategory(Translator.GetMenuName(i.Attribute("ref").Value, i.Attribute("reskey").Value), true, null, i.Attribute("ref").Value == "MenuReports");

                if (!i.HasElements)
                {
                    continue;
                }


                foreach (var e in i.Descendants("item"))
                {
                    if (context != null && !context.CanDo(e.Attribute("permission").Value))
                    {
                        isActive = false;
                        continue;
                    }

                    var menuItem = CreateMenuItem(e, culture);

                    cat.Items.Add(menuItem);
                    isActive = isActive && !menuItem.IsActive;
                }

                cat.IsActive = !isActive;
                isActive = true;
                if (cat.Items.Count > 0)
                {
                    categories.Add(cat);
                }

            }

            return categories;
        }

        public static MenuItem CreateMenuItem(IMenuAction item, string culture)
        {
            string url = String.Format("/{0}{1}", culture, item.ActionUrl);

            var menuItem = new MenuItem(
                Translator.GetMenuName(item.ResourceKey, item.Caption),
                url,
                item.SelectPermission);
            menuItem.IsPopup = true;

            return menuItem;
        }


        private static MenuItem CreateMenuItem(XElement description, string culture)
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

            return menuItem;
        }

    }
}