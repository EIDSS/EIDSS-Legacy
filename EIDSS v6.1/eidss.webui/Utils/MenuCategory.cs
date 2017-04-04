using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace eidss.webui.Utils
{
    public class MenuCategory
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<MenuItem> Items { get; set; }


        public MenuCategory(string name, bool isActive = true, List<MenuItem> items = null)
        {
            Items = items ?? new List<MenuItem>();
            Name = name;
            IsActive = isActive;
        }

        public static List<MenuCategory> GetMenuList(eidss.model.Core.EidssUserContext context, string menuPath)
        {
            //the menu is located in the MenuStructure.xml file, permissions are applied from current user context            
            if (System.IO.File.Exists(menuPath))
            {
                XDocument permissions = XDocument.Load(menuPath);
                return PermissionParser.GetPermittedMenu(permissions, context);
            }
            else
                throw new ArgumentException("Menu source file is not found at specified location.");
        }
    }
}
