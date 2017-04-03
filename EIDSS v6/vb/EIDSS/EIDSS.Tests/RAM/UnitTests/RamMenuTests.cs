using System.Collections;
using System.Collections.Generic;
using bv.common.win;
using EIDSS.RAM.Presenters.RamForm;
using EIDSS.RAM_DB.Common;
using NUnit.Framework;
using bv.winclient.Core;

namespace EIDSS.Tests.RAM.UnitTests
{
    [TestFixture]
    public class RamMenuTests
    {
        [Test]
        public void DeleteEmptyFoldersTest()
        {
            List<LayoutTreeElement> layouts = LoadLayouts();
            List<LayoutTreeElement> folders = LoadFolders();
            RamMenuRegistrator.DeleteEmptyFolders(layouts, folders);
            Assert.AreEqual(3, layouts.Count);
            Assert.AreEqual(4, folders.Count);
            Assert.IsNotNull(folders.Find(delegate(LayoutTreeElement tmp) { return tmp.ID == 10; }));
            Assert.IsNotNull(folders.Find(delegate(LayoutTreeElement tmp) { return tmp.ID == 11; }));
            Assert.IsNotNull(folders.Find(delegate(LayoutTreeElement tmp) { return tmp.ID == 14; }));
            Assert.IsNotNull(folders.Find(delegate(LayoutTreeElement tmp) { return tmp.ID == 15; }));
        }
        [Test]
        public void CreateFoldersLayoutsMenuTest()
        {
            List<LayoutTreeElement> layouts = LoadLayouts();
            List<LayoutTreeElement> folders = LoadFolders();
            RamMenuRegistrator.DeleteEmptyFolders(layouts, folders);

            MenuAction queryMenuAction = new MenuAction(MenuActionManager.Instance, MenuActionManager.Instance.Reports, "query", 1);

            RamMenuRegistrator.CreateFoldersLayoutsMenu(null, queryMenuAction, layouts, folders);
            Assert.AreEqual(2, queryMenuAction.Items.Count);

        }

        public static List<LayoutTreeElement> LoadLayouts()
        {
            List<LayoutTreeElement> treeElements = new List<LayoutTreeElement>();
            treeElements.Add(new LayoutTreeElement(100, 15, 1, true, "100", "100", true, true));
            treeElements.Add(new LayoutTreeElement(101, null, 1, true, "101", "101", true, true));
            treeElements.Add(new LayoutTreeElement(102, 14, 1, true, "102", "102", true, true));
            return treeElements;
        }
        public static List<LayoutTreeElement> LoadFolders()
        {
            List<LayoutTreeElement> treeElements = new List<LayoutTreeElement>();
            treeElements.Add(new LayoutTreeElement(10, null, 1, false, "10", "10", true, true));
            treeElements.Add(new LayoutTreeElement(11, 10, 1, false, "11", "11", true, true));
            treeElements.Add(new LayoutTreeElement(12, 10, 1, false, "12", "12", true, true));
            treeElements.Add(new LayoutTreeElement(13, null, 1, false, "13", "13", true, true));
            treeElements.Add(new LayoutTreeElement(14, 11, 1, false, "14", "14", true, true));
            treeElements.Add(new LayoutTreeElement(15, 14, 1, false, "15", "15", true, true));
            treeElements.Add(new LayoutTreeElement(16, 12, 1, false, "16", "16", true, true));
            treeElements.Add(new LayoutTreeElement(17, 16, 1, false, "17", "17", true, true));
            treeElements.Add(new LayoutTreeElement(18, 17, 1, false, "18", "18", true, true));
            return treeElements;
        }
    }
}
