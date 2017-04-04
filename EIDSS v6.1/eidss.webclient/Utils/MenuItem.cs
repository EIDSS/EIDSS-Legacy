using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using bv.common.Configuration;
using eidss.model.Core;

namespace eidss.webclient.Utils
{
    public class MenuItem
    {
        public enum MenuItemFrom
        {
            Menu = 0,
            Toolbar = 1
        }

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
        public bool IsLastInSection { get; set; }
        public List<MenuItem> Items { get; set; }
        public bool IsFolder { get { return Items != null && Items.Count > 0; } }

        internal MenuItem
            (string name, string url, string permission, MenuItemFrom from, string iconName = "", bool isActive = true, bool isPopup = false,
                bool isModal = false, bool isHelp = false,
                int windowWidth = 1080, int windowHeigth = 800, bool isLastInSection = false)
        {
            Name = name;
            Url = url;
            var bLogging = Config.GetBoolSetting("IsActionLogging");
            if (bLogging)
            {
               Url += "?RunFrom=" + from.ToString();
            }

            Permission = permission;
            IsActive = isActive;
            IconName = iconName;
            IsHelp = isHelp;
            Items = new List<MenuItem>();

            if (isModal && isPopup)
            {
                throw new ArgumentException("Menu item can't be opened in Modal and Pop-up window at the same time");
            }

            IsModal = isModal;
            IsPopup = isPopup;
            WindowWidth = windowWidth;
            WindowHeigth = windowHeigth;

            IsLastInSection = isLastInSection;
        }

        public static List<MenuItem> GetIconMenu(EidssUserContext context, string menuPath)
        {
            //the menu is located in the MenuStructure.xml file, permissions are applied from current user context            
            if (File.Exists(menuPath))
            {
                XDocument permissions = XDocument.Load(menuPath);
                return PermissionParser.GetPermittedIconMenu(permissions, context);
            }
            else
            {
                throw new ArgumentException("Icons menu source file is not found at specified location.");
            }
        }
    }
}