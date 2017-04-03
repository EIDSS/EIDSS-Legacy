using System.Windows.Forms;
using DevExpress.XtraBars;
using EIDSS.RAM;
using EIDSS.RAM.Presenters.RamForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.win;
using bv.tests.AVR.Helpers.Fake;
using bv.tests.common;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Resources;

namespace bv.tests.AVR.UnitTests.Presenters
{
    [TestClass]
    public class RamFormPresenterReportTests :BaseReportTests
    {


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var parentForm = new Form();
            BaseFormManager.Init(parentForm);
            PresenterFactory.Init(new BaseForm());
            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();

            var barManager = new BarManager();
            BaseFormManager.MainBarManager = barManager;
            MenuActionManager.Instance = new MenuActionManager(parentForm, barManager, new Bar(barManager),
                                                               EidssUserContext.User) { ItemsStorage = EidssMenu.Instance };
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void RamReportControlPresenterGetAvrPermissionsTest()
        {
            string permissions = RamMenuRegistrator.GetAvrPermissions(3);
            Assert.AreEqual("HumanCase.Select|VetCase.Select", permissions);
            permissions = RamMenuRegistrator.GetAvrPermissions(1);
            Assert.AreEqual("VetCase.Select", permissions);
            permissions = RamMenuRegistrator.GetAvrPermissions(2);
            Assert.AreEqual("HumanCase.Select", permissions);
            permissions = RamMenuRegistrator.GetAvrPermissions(0);
            Assert.AreEqual("", permissions);
        }

        [TestMethod]
        public void RamReportControlPresenterRegisterStaticReportsTest()
        {
            MenuAction reports = RamMenuRegistrator.RegisterWinStaticReports(null);
            Assert.IsNotNull(reports);
            Assert.AreEqual(0, reports.Items.Count);
            // todo: [Ivan] Uncomment this when some standard reports will be published from AVR. Now we haven't requirements for them
            //Assert.IsTrue(reports.Items.Count > 0);
        }
    }
}
