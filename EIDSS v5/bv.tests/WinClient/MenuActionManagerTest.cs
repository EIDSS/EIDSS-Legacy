using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using bv.common.Core;
using bv.tests.WinClient;
using bv.winclient.Core;
using DevExpress.XtraBars;
using eidss.model.Core;
using eidss.model.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests
{
    /// <summary>
    ///This is a test class for MenuActionManagerTest and is intended
    ///to contain all MenuActionManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class MenuActionManagerTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        #region Additional test attributes

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion

        private TestMainForm m_MainForm;

        private MenuActionManager Init()
        {
            m_MainForm = new TestMainForm();
            var user = new EidssUser();
            user.Permissions = new Dictionary<string, bool> {{"Allow", true}, {"Deny", false}};
            var target = new MenuActionManager(m_MainForm, m_MainForm.BarManager, m_MainForm.BarManager.Bars[0], user);
            target.ItemsStorage = EidssMenu.Instance;
            return target;
        }

        private static void CheckTopMenu(MenuActionManager target)
        {
            Assert.IsNotNull(target.Create);
            Assert.IsNotNull(target.Documents);
            Assert.IsNotNull(target.Edit);
            Assert.IsNotNull(target.File);
            Assert.IsNotNull(target.Help);
            Assert.IsNotNull(target.Journals);
            Assert.IsNotNull(target.Maps);
            Assert.IsNotNull(target.Operations);
            Assert.IsNotNull(target.Options);
            Assert.IsNotNull(target.Reports);
            Assert.IsNotNull(target.Search);
            Assert.IsNotNull(target.Security);
            Assert.IsNotNull(target.System);
            Assert.IsNotNull(target.View);
            Assert.IsNotNull(target.Window);
        }

        /// <summary>
        ///A test for MenuActionManager Constructor
        ///</summary>
        [TestMethod]
        public void MenuActionManagerConstructorTest()
        {
            MenuActionManager target = Init();
            CheckTopMenu(target);
        }

        /// <summary>
        ///A test for AddAction
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("bv.winclient.dll")]
        //public void AddActionTest()
        //{
        //    MenuActionManager manager = Init();
        //    PrivateObject param0 = new PrivateObject(manager);
        //    MenuActionManager_Accessor target = new MenuActionManager_Accessor(param0);
        //    MenuAction topAction = new MenuAction(manager, null, "Test", 0);
        //    MenuAction action = new MenuAction(manager, null, "MenuExit", 0);
        //    MenuAction_Accessor a = new MenuAction_Accessor(new PrivateObject(action));
        //    MenuAction_Accessor c = new MenuAction_Accessor(new PrivateObject(topAction));
        //    object parentMenuItem = target.AddTopMenuItem(c);
        //    target.AddAction(parentMenuItem, a);
        //    Assert.AreEqual(1, ((BarSubItem)parentMenuItem).ItemLinks.Count);
        //}
        /// <summary>
        ///A test for AddTopMenuItem
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("bv.winclient.dll")]
        //public void AddTopMenuItemTest()
        //{
        //    MenuActionManager manager = Init();
        //    MenuAction action = new MenuAction(manager, null, "Test", 0);
        //    PrivateObject param0 = new PrivateObject(manager);
        //    MenuActionManager_Accessor target = new MenuActionManager_Accessor(param0); // TODO: Initialize to an appropriate value
        //    MenuAction_Accessor c = new MenuAction_Accessor(new PrivateObject(action));
        //    object expected = action;
        //    object actual;
        //    actual = target.AddTopMenuItem(c);
        //    Assert.AreEqual(typeof(DevExpress.XtraBars.BarSubItem), actual.GetType());
        //    Assert.IsNotNull(manager.FindAction("Test"));
        //    Assert.IsTrue(manager.MenuItems.Contains(action));
        //}
        /// <summary>
        ///A test for Clear
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("bv.winclient.dll")]
        //public void ClearTest()
        //{
        //    MenuActionManager manager = Init();
        //    PrivateObject param0 = new PrivateObject(manager);
        //    MenuActionManager_Accessor target = new MenuActionManager_Accessor(param0);
        //    new MenuAction(manager, manager.File, "MenuExit", 0);
        //    manager.DisplayActions();
        //    Assert.AreEqual(1, manager.MenuItems[0].Items.Count);
        //    Assert.AreEqual(1, target.m_BarManager.MainMenu.ItemLinks.Count);
        //    target.Clear();
        //    CheckTopMenu(manager);
        //    Assert.AreEqual(0, target.m_BarManager.MainMenu.ItemLinks.Count);
        //}
        /// <summary>
        ///A test for ClearEmptyItems
        ///</summary>
        [TestMethod]
        public void ClearEmptyItemsTest()
        {
            var barItem = new BarSubItem {Caption = @"Test1"};
            BarSubItem expected = null;
            BarSubItem actual = MenuActionManager.ClearEmptyItems(barItem);
            Assert.AreEqual(expected, actual);
            barItem = new BarSubItem();
            var childItem = new BarSubItem();
            barItem.AddItem(new BarLargeButtonItem());
            barItem.AddItem(childItem);
            expected = barItem;
            actual = MenuActionManager.ClearEmptyItems(barItem);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, barItem.ItemLinks.Count);
            barItem.AddItem(childItem);
            childItem.AddItem(new BarLargeButtonItem());
            actual = MenuActionManager.ClearEmptyItems(barItem);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(2, barItem.ItemLinks.Count);
            Assert.AreEqual(1, childItem.ItemLinks.Count);
        }

        /// <summary>
        ///A test for DisplayActions
        ///</summary>
        [TestMethod]
        public void DisplayActionsTest()
        {
            MenuActionManager target = Init();
            var action = new MenuAction(fooHandle, target, target.File, "MenuExit", 1);
            action = new MenuAction(fooHandle, target, target.File, "MenuLogout", 2);
            var actionHC = new MenuAction(target, target.Reports, "", 1);
            actionHC.Caption = "human reports";
            var actionVC = new MenuAction(target, target.Reports, "", 2);
            actionHC.Caption = "vet reports";
            action = new MenuAction(fooHandle, target, target.Reports, "MenuLogout", 3);
            action = new MenuAction(fooHandle, target, actionHC, "MenuExit", 1);
            action = new MenuAction(fooHandle, target, actionVC, "MenuExit", 1);
            target.DisplayActions();

            Assert.AreEqual(2, m_MainForm.BarManager.MainMenu.ItemLinks.Count);
            Assert.AreEqual(2, ((BarSubItem) m_MainForm.BarManager.MainMenu.ItemLinks[0].Item).ItemLinks.Count);
            Assert.AreEqual(3, ((BarSubItem) m_MainForm.BarManager.MainMenu.ItemLinks[1].Item).ItemLinks.Count);
            Assert.AreEqual(1,
                            ((BarSubItem)
                             ((BarSubItem) m_MainForm.BarManager.MainMenu.ItemLinks[1].Item).ItemLinks[0].Item).
                                ItemLinks.Count);
            Assert.AreEqual(1,
                            ((BarSubItem)
                             ((BarSubItem) m_MainForm.BarManager.MainMenu.ItemLinks[1].Item).ItemLinks[1].Item).
                                ItemLinks.Count);
            Assert.AreEqual(EidssMenu.Get("MenuLogout", ""),
                            (((BarSubItem) m_MainForm.BarManager.MainMenu.ItemLinks[1].Item).ItemLinks[2].Item).Caption);
        }

        private void fooHandle()
        {
        }

        /// <summary>
        ///A test for FindAction
        ///</summary>
        [TestMethod]
        public void FindActionTest1()
        {
            MenuActionManager target = Init();
            string resourceKey = "MenuEdit";
            IMenuAction expected = target.Edit;
            IMenuAction actual;
            actual = target.FindAction(resourceKey);
            Assert.AreEqual(expected, actual);
            actual = target.FindAction("AbsentMenu");
            Assert.AreEqual(null, actual);
            var actionHC = new MenuAction(target, target.Reports, "", 1);
            actionHC.Caption = "human reports";
            var actionVC = new MenuAction(target, target.Reports, "", 2);
            actionHC.Caption = "vet reports";
            var action = new MenuAction(target, target.Reports, "MenuLogout", 3);
            action = new MenuAction(target, actionHC, "MenuExit", 1);
            actual = target.FindAction("MenuExit");
            Assert.AreEqual(action, actual);
            actual = target.FindAction(actionHC.Caption);
            Assert.AreEqual(actionHC, actual);
            actual = target.FindAction("AbsentMenu");
            Assert.AreEqual(null, actual);
        }

        /// <summary>
        ///A test for GetItemCaption
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("bv.winclient.dll")]
        //public void GetItemCaptionTest()
        //{
        //    MenuActionManager manager = Init();
        //    PrivateObject param0 = new PrivateObject(manager);
        //    MenuActionManager_Accessor target = new MenuActionManager_Accessor(param0);
        //    MenuAction action = new MenuAction(manager, manager.File, "MenuExit", 0);
        //    MenuAction_Accessor GetItem = new MenuAction_Accessor(new PrivateObject(action));
        //    string expected = EidssMenu.Get("MenuExit",null); 
        //    string actual;
        //    actual = target.GetItemCaption(GetItem);
        //    Assert.AreEqual(expected, actual);
        //    action.Caption = "Test";
        //    expected = action.Caption;
        //    actual = target.GetItemCaption(GetItem);
        //    Assert.AreEqual(expected, actual);
        //    action.ItemsStorage = BvMessages.Instance;
        //    actual = target.GetItemCaption(GetItem);
        //    Assert.AreEqual(expected, actual);
        //    action.Caption = null;
        //    expected = BvMessages.Get("MenuExit", null);
        //    actual = target.GetItemCaption(GetItem);
        //    Assert.AreEqual(expected, actual);
        //}
        /// <summary>
        ///A test for GetToolTipText
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("bv.winclient.dll")]
        //public void GetToolTipTextTest()
        //{
        //    string caption = "&Replace"; 
        //    string expected = "Replace"; 
        //    string actual;
        //    actual = MenuActionManager_Accessor.GetToolTipText(caption);
        //    Assert.AreEqual(expected, actual);
        //    caption = "Rep&lace";
        //    actual = MenuActionManager_Accessor.GetToolTipText(caption);
        //    Assert.AreEqual(expected, actual);
        //}
        public static void Register(Control parent)
        {
            var action = new MenuAction(MenuActionManager.Instance, MenuActionManager.Instance.File, "MenuExit", 0);
        }

        /// <summary>
        ///A test for LoadAssemblyActions
        ///</summary>
        [TestMethod]
        public void LoadAssemblyActionsTest()
        {
            MenuActionManager target = Init();
            MenuActionManager.Instance = target;
            IMenuAction action = target.FindAction("MenuExit");
            Assert.IsNull(action);
            string assemblyName = Utils.GetAssemblyLocation(Assembly.GetAssembly(GetType()));
            target.LoadAssemblyActions(assemblyName);
            action = target.FindAction("MenuExit");
            Assert.IsNotNull(action);
        }

        /// <summary>
        ///A test for RegisterAction
        ///</summary>
        //[TestMethod()]
        //public void RegisterActionTest()
        //{
        //    MenuActionManager target = Init();
        //    MenuAction parent = new MenuAction(target, target.File, "parent", 0);
        //    MenuAction a = new MenuAction(target, parent, "MenuExit", 0);
        //    MenuAction expected = a;
        //    MenuAction actual;
        //    actual = target.RegisterAction(parent, a);
        //    Assert.AreEqual(expected, actual);
        //    Assert.IsNotNull(target.FindAction("parent"));
        //    Assert.IsNotNull(target.FindAction("MenuExit"));
        //    Assert.AreEqual(parent, a.Parent);
        //}
        /// <summary>
        ///A test for RegisterAction
        ///</summary>
        //[TestMethod()]
        //public void RegisterActionTest1()
        //{
        //    MenuActionManager target = Init();
        //    MenuAction a = new MenuAction(target, target.File, "MenuExit", 0);
        //    MenuAction expected = a;
        //    MenuAction actual;
        //    actual = target.RegisterAction(a);
        //    Assert.AreEqual(expected, actual);
        //    Assert.IsNotNull(target.FindAction("MenuExit"));
        //    Assert.AreEqual(target.File, a.Parent);
        //}
        [TestMethod]
       [Ignore]
        [DeploymentItem("bv.winclient.dll")]
        public void VisualTest()
        {
            MenuActionManager target = Init();
            var action = new MenuAction(target, target.File, "MenuExit", 1);
            action = new MenuAction(target, target.File, "MenuLogout", 2);
            var actionHC = new MenuAction(target, target.Reports, "", 1);
            actionHC.Caption = "human reports";
            var actionVC = new MenuAction(target, target.Reports, "", 2);
            actionVC.Caption = "vet reports";
            action = new MenuAction(target, target.Reports, "MenuLogout", 3);
            action.SelectPermission = "Deny";
            action = new MenuAction(target, actionHC, "MenuExit", 1);
            action = new MenuAction(target, actionVC, "MenuExit", 1);
            target.DisplayActions();
            //PrivateObject param0 = new PrivateObject(manager);
            //MenuActionManager_Accessor target = new MenuActionManager_Accessor(param0);
            m_MainForm.ShowDialog();
        }
    }
}