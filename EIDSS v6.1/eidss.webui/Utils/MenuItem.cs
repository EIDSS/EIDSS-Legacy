using System.Collections.Generic;
using System.Threading;
using System;

namespace eidss.webui.Utils
{
    public class MenuItem
    {
        public bool IsActive { get; set; }
        public string IconName { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsPopup { get; set; }
        public bool IsModal { get; set; }

        internal MenuItem(string name, string url, string iconName = "", bool isActive = true, bool isPopup = false, bool isModal = false)
        {
            Name = name;
            Url = url;
            IsActive = isActive;
            IconName = iconName;
            if (isModal && isPopup)
                throw new ArgumentException("Menu item can't be opened in Modal and Pop-up window at the same time");
            IsModal = isModal;
            IsPopup = isPopup;
        }

        public static List<MenuItem> GetIconMenu()
        {
            return new List<MenuItem>
            {
                new MenuItem("Search Human Case", "/HumanCase/Index", "SearchHI.png"),
                new MenuItem("Search Vet Case", "/VetCase/Index", "SearchVet.png"),
                new MenuItem("Create Human Case", "/HumanCase/Details", "NewHC.png"),
                new MenuItem("Create Avian Case", "/VetCase/Details/Avian", "NewAvian.png"),
                new MenuItem("Create Livestock Case", "/VetCase/Details/Lvstk", "NewLvstk.png")
                //new MenuItem("Human Aggregate Case Summary", "/HumanCase/Aggregate/Summary"),
                //new MenuItem("Vet Aggregate Case Summary", "/VetCase/Aggregate/Summary"),
                //new MenuItem("Vet Aggregate Action Summary", "/VetCase/Aggregate/ActionSummary"),
                //new MenuItem("Lab Sample Log Book", "/Lab/SampleLog"),
                //new MenuItem("Help", "/Help/Index")
            };
        }
    }
}