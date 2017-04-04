using System.Collections.Generic;
using System.Windows.Forms;
using bv.tests.common;
using bv.winclient.Core;
using DevExpress.XtraBars;
using eidss.model.Avr.Tree;
using eidss.model.Core;
using eidss.model.Reports;
using eidss.model.Resources;
using eidss.winclient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class AvrMenuReportTests : BaseReportTests
    {
        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
            var barManager1 = new BarManager();
            var tbToolbar = new Bar();
            MenuActionManager.Instance = new MenuActionManager(new Form(), barManager1, tbToolbar, EidssUserContext.User)
            {
                ItemsStorage = EidssMenu.Instance
            };
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void DeleteEmptyFoldersTest()
        {
            List<AvrTreeElement> layouts = LoadLayouts();
            List<AvrTreeElement> folders = LoadFolders();
            BaseMenuReportRegistrator.DeleteAvrEmptyFolders(layouts, folders);
            Assert.AreEqual(3, layouts.Count);
            Assert.AreEqual(4, folders.Count);
            Assert.IsNotNull(folders.Find(tmp => tmp.ID == 10));
            Assert.IsNotNull(folders.Find(tmp => tmp.ID == 11));
            Assert.IsNotNull(folders.Find(tmp => tmp.ID == 14));
            Assert.IsNotNull(folders.Find(tmp => tmp.ID == 15));
        }

        private class FakeMenuregistrator : WinMenuReportRegistrator
        {
            public static WinMenuReportRegistrator GetRegistrator()
            {
                return new FakeMenuregistrator(MenuActionManager.Instance, null, a => { });
            }

            private FakeMenuregistrator
                (MenuActionManager menuManager, IReportFactory reportFactory, MenuAction.ActionHandler avrActionHandler)
                : base(menuManager, reportFactory, avrActionHandler)
            {
            }
        }

        [TestMethod]
        public void CreateFoldersLayoutsMenuTest()
        {
            List<AvrTreeElement> layouts = LoadLayouts();
            List<AvrTreeElement> folders = LoadFolders();
            BaseMenuReportRegistrator.DeleteAvrEmptyFolders(layouts, folders);

            var queryMenuAction = new MenuAction(null, null, "query", 1);

            WinMenuReportRegistrator registrator = FakeMenuregistrator.GetRegistrator();
            registrator.CreateAvrFoldersLayoutsMenu(queryMenuAction, layouts, folders);
            Assert.AreEqual(2, queryMenuAction.Items.Count);
        }

        public static List<AvrTreeElement> LoadLayouts()
        {
            var treeElements = new List<AvrTreeElement>
            {
                new AvrTreeElement(100, 15, 100, AvrTreeElementType.Layout, 1, "100", "100", string.Empty, true),
                new AvrTreeElement(101, null, 101, AvrTreeElementType.Layout, 1, "101", "101", string.Empty, true),
                new AvrTreeElement(102, 14, 102, AvrTreeElementType.Layout, 1, "102", "102", string.Empty, true)
            };
            return treeElements;
        }

        public static List<AvrTreeElement> LoadFolders()
        {
            var treeElements = new List<AvrTreeElement>
            {
                new AvrTreeElement(10, null, 10, AvrTreeElementType.Folder, 1, "10", "10", string.Empty, true),
                new AvrTreeElement(11, 10, 11, AvrTreeElementType.Folder, 1, "11", "11", string.Empty, true),
                new AvrTreeElement(12, 10, 12, AvrTreeElementType.Folder, 1, "12", "12", string.Empty, true),
                new AvrTreeElement(13, null, 13, AvrTreeElementType.Folder, 1, "13", "13", string.Empty, true),
                new AvrTreeElement(14, 11, 14, AvrTreeElementType.Folder, 1, "14", "14", string.Empty, true),
                new AvrTreeElement(15, 14, 15, AvrTreeElementType.Folder, 1, "15", "15", string.Empty, true),
                new AvrTreeElement(16, 12, 16, AvrTreeElementType.Folder, 1, "16", "16", string.Empty, true),
                new AvrTreeElement(17, 16, 17, AvrTreeElementType.Folder, 1, "17", "17", string.Empty, true),
                new AvrTreeElement(18, 17, 18, AvrTreeElementType.Folder, 1, "18", "18", string.Empty, true)
            };
            return treeElements;
        }
    }
}