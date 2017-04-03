using System.Collections.Generic;
using System.Threading;
using System;
using System.Linq;
using System.Xml.Linq;

namespace eidss.webclient.Utils
{
    public class MenuItem
    {
        public bool IsActive { get; set; }
        public string IconName { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Permission { get; set; }
        public bool IsPopup { get; set; }
        public bool IsModal { get; set; }
        public int WindowWidth { get; set; }
        public int WindowHeigth { get; set; }
        public bool IsHelp { get; set; }

        internal MenuItem(string name, string url, string permission, string iconName = "", bool isActive = true, bool isPopup = false, bool isModal = false, bool isHelp = false, 
            int windowWidth = 1080, int windowHeigth = 800)
        {
            Name = name;
            Url = url;
            Permission = permission;
            IsActive = isActive;
            IconName = iconName;
            IsHelp = isHelp;

            if (isModal && isPopup)
            {
                throw new ArgumentException("Menu item can't be opened in Modal and Pop-up window at the same time");
            }
            
            IsModal = isModal;
            IsPopup = isPopup;
            WindowWidth = windowWidth;
            WindowHeigth = windowHeigth;
        }

        public static List<MenuItem> GetIconMenu(eidss.model.Core.EidssUserContext context, string menuPath)
        {
            //the menu is located in the MenuStructure.xml file, permissions are applied from current user context            
            if (System.IO.File.Exists(menuPath))
            {
                XDocument permissions = XDocument.Load(menuPath);
                return PermissionParser.GetPermittedIconMenu(permissions, context);
            }
            else
                throw new ArgumentException("Icons menu source file is not found at specified location.");
        }
    }
}