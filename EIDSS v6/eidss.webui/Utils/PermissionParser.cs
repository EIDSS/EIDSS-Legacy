using System.Collections.Generic;
using System.Xml.Linq;
using System;

namespace eidss.webui.Utils
{
    public class PermissionParser
    {
        public static List<MenuCategory> GetPermittedMenu(XDocument document, eidss.model.Core.EidssUserContext context)
        {
            IEnumerable<XElement> items = document.Element("menu").Descendants("item");
            List<MenuCategory> categories = new List<MenuCategory>();
            MenuCategory cat = null;
            MenuItem menuItem = null;
            bool isActive = true;
            foreach (var i in items)
            {
                cat = new MenuCategory(i.Attribute("reskey").Value);

                if (context == null || context.CanDo(i.Attribute("permission").Value))
                {
                    if (i.HasElements)
                    {
                        foreach (var e in i.Descendants("item"))
                        {
                            menuItem = new MenuItem(e.Attribute("reskey").Value, e.Attribute("url").Value);
                            menuItem.IsActive = context == null ? true : context.CanDo(e.Attribute("permission").Value);
                            if (e.Attribute("popup") != null)
                                menuItem.IsPopup = Convert.ToBoolean(e.Attribute("popup").Value);
                            if (!menuItem.IsPopup && e.Attribute("modal") != null)
                                menuItem.IsModal = Convert.ToBoolean(e.Attribute("modal").Value);
                            cat.Items.Add(menuItem);
                            isActive = isActive && !menuItem.IsActive;
                        }
                    }
                    cat.IsActive = !isActive;
                    isActive = true;
                }
                categories.Add(cat);
            }

            return categories;
        }
    }
}