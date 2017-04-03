using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using EIDSS.RAM.Presenters.RamForm;
using EIDSS.RAM_DB.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.common;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Resources;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class RamMenuReportTests : BaseReportTests
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var barManager1 = new BarManager();
            var tbToolbar = new Bar();
            MenuActionManager.Instance = new MenuActionManager(new Form(), barManager1, tbToolbar, EidssUserContext.User) { ItemsStorage = EidssMenu.Instance };
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }



        [TestMethod]
        public void DeleteEmptyFoldersTest()
        {
            List<LayoutTreeElement> layouts = LoadLayouts();
            List<LayoutTreeElement> folders = LoadFolders();
            RamMenuRegistrator.DeleteEmptyFolders(layouts, folders);
            Assert.AreEqual(3, layouts.Count);
            Assert.AreEqual(4, folders.Count);
            Assert.IsNotNull(folders.Find(tmp => tmp.ID == 10));
            Assert.IsNotNull(folders.Find(tmp => tmp.ID == 11));
            Assert.IsNotNull(folders.Find(tmp => tmp.ID == 14));
            Assert.IsNotNull(folders.Find(tmp => tmp.ID == 15));
        }

        [TestMethod]
        public void CreateFoldersLayoutsMenuTest()
        {
            List<LayoutTreeElement> layouts = LoadLayouts();
            List<LayoutTreeElement> folders = LoadFolders();
            RamMenuRegistrator.DeleteEmptyFolders(layouts, folders);

            var queryMenuAction = new MenuAction(null, null, "query", 1);

            RamMenuRegistrator.CreateFoldersLayoutsMenu(null, queryMenuAction, layouts, folders);
            Assert.AreEqual(2, queryMenuAction.Items.Count);
        }

        public static List<LayoutTreeElement> LoadLayouts()
        {
            var treeElements = new List<LayoutTreeElement>
                                   {
                                       new LayoutTreeElement(100, 15, 1, true, "100", "100", true, true),
                                       new LayoutTreeElement(101, null, 1, true, "101", "101", true, true),
                                       new LayoutTreeElement(102, 14, 1, true, "102", "102", true, true)
                                   };
            return treeElements;
        }

        public static List<LayoutTreeElement> LoadFolders()
        {
            var treeElements = new List<LayoutTreeElement>
                                   {
                                       new LayoutTreeElement(10, null, 1, false, "10", "10", true, true),
                                       new LayoutTreeElement(11, 10, 1, false, "11", "11", true, true),
                                       new LayoutTreeElement(12, 10, 1, false, "12", "12", true, true),
                                       new LayoutTreeElement(13, null, 1, false, "13", "13", true, true),
                                       new LayoutTreeElement(14, 11, 1, false, "14", "14", true, true),
                                       new LayoutTreeElement(15, 14, 1, false, "15", "15", true, true),
                                       new LayoutTreeElement(16, 12, 1, false, "16", "16", true, true),
                                       new LayoutTreeElement(17, 16, 1, false, "17", "17", true, true),
                                       new LayoutTreeElement(18, 17, 1, false, "18", "18", true, true)
                                   };
            return treeElements;
        }
    }
}
