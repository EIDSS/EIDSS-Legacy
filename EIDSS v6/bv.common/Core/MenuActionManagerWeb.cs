using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.common.Core
{
    public class MenuActionManagerWeb : MenuManagerBase
    {
        public MenuActionManagerWeb()
        {
            MenuItems = new List<IMenuAction>();
            Clear();
        }
        public IMenuAction GetTopMenuItem(string resourceKey)
        {
            return MenuItems.FirstOrDefault(item => item.ResourceKey == resourceKey);
        }
        public void Clear()
        {
            MenuItems.Clear();
            m_File = new MenuActionWeb(this, null, "MenuFile", 1);
            m_Edit = new MenuActionWeb(this, null, "MenuEdit", 100);
            m_View = new MenuActionWeb(this, null, "MenuView", 200);
            m_Journals = new MenuActionWeb(this, null, "MenuCatalogs", 300);
            m_Operations = new MenuActionWeb(this, null, "MenuOperations", 400);
            m_Create = new MenuActionWeb(this, null, "MenuCreate", 450);
            m_Search = new MenuActionWeb(this, null, "MenuSearch", 500);
            m_Reports = new MenuActionWeb(this, null, "MenuReports", 600);
            m_Maps = new MenuActionWeb(this, null, "MenuMaps", 650);

            m_Documents = new MenuActionWeb(this, null, "MenuDocuments", 700);
            m_Options = new MenuActionWeb(this, null, "MenuOptions", 800);
            m_System = new MenuActionWeb(this, null, "MenuSystem", 900);
            m_Avr = new MenuActionWeb(this, null, "MenuRAM", 950);
            m_Security = new MenuActionWeb(this, null, "MenuSecurity", 1000);
            m_DataExport = new MenuActionWeb(this, null, "MenuDataExport", 1100);
            m_Window = new MenuActionWeb(this, null, "MenuWindow", 999900);
            m_Help = new MenuActionWeb(this, null, "MenuHelp", 1000000);
        }

    }
}
