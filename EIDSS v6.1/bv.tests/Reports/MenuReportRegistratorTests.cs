using System.Windows.Forms;
using DevExpress.XtraBars;
using EIDSS.Reports.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Core;
using bv.tests.common;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.webclient.Utils;
using eidss.winclient;

namespace bv.tests.Reports
{
    [TestClass]
    public class MenuReportRegistratorTests
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            BaseReportTests.InitDBAndLogin();
        }

        [TestMethod]
        public void WebMenuReportTest()
        {
            var actionManager = new MenuActionManagerWeb();
            Assert.AreEqual(0, actionManager.Reports.Items.Count);

            WebMenuReportRegistrator.RegisterAllStandartReports(actionManager);
            WebMenuReportRegistrator.RegisterAllAvrReports(actionManager);

            AssertMenuActionManager(actionManager);
        }

        [TestMethod]
        public void WintMenuReportTest()
        {
            var barManager1 = new BarManager();
            var tbToolbar = new Bar();
            var actionManager = new MenuActionManager(new Form(), barManager1, tbToolbar, EidssUserContext.User)
                {
                    ItemsStorage = EidssMenu.Instance
                };
            Assert.AreEqual(0, actionManager.Reports.Items.Count);

            WinMenuReportRegistrator.RegisterAllStandartReports(actionManager, new ReportFactory());

            AssertMenuActionManager(actionManager);
        }

        private static void AssertMenuActionManager(MenuManagerBase actionManager)
        {
            Assert.IsTrue(actionManager.Reports.Items.Count >0);
            IMenuAction standardReportMenu = actionManager.Reports.Items.Find(m => m.ResourceKey == "menuStndReports");
            Assert.IsNotNull(standardReportMenu);
            Assert.IsTrue(standardReportMenu.Items.Count > 2);
            IMenuAction humanSubmenu = standardReportMenu.Items.Find(m => m.ResourceKey == "MenuHumanReports");
            Assert.IsNotNull(humanSubmenu);
            IMenuAction vetSubmenu = standardReportMenu.Items.Find(m => m.ResourceKey == "MenuVetReports");
            Assert.IsNotNull(vetSubmenu);
            IMenuAction admSubmenu = standardReportMenu.Items.Find(m => m.ResourceKey == "MenuAdministrativeReports");
            Assert.IsNotNull(admSubmenu);
            Assert.AreEqual(1, admSubmenu.Items.Count);
            Assert.AreEqual("ReportsAdmEventLog", admSubmenu.Items[0].ResourceKey);
        }
    }
}