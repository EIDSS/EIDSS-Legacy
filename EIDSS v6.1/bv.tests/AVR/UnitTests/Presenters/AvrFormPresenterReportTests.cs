using System;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.win;
using bv.tests.AVR.Helpers.Fake;
using bv.tests.common;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using DevExpress.XtraBars;
using eidss.avr;
using eidss.model.Core;
using eidss.model.Reports;
using eidss.model.Resources;
using eidss.winclient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace bv.tests.AVR.UnitTests.Presenters
{
    [TestClass]
    public class AvrFormPresenterReportTests : BaseReportTests
    {
        private Form m_ParentForm;
        private Bar m_Bar;
        private IDisposable m_PresenterTransaction;

        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { });
            return c;
        }

        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();

            m_ParentForm = new Form();
            BaseFormManager.Init(m_ParentForm);
            var mainForm = new BaseForm();
            m_PresenterTransaction = PresenterFactory.BeginSharedPresenterTransaction(StructureMapContainerInit(), mainForm);
            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();

            var barManager = new BarManager();
            BaseFormManager.MainBarManager = barManager;
            m_Bar = new Bar(barManager);
            MenuActionManager.Instance = new MenuActionManager(m_ParentForm, barManager, m_Bar,
                EidssUserContext.User) {ItemsStorage = EidssMenu.Instance};
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            m_Bar.Dispose();
            m_Bar = null;

            MenuActionManager.Instance = null;
            BaseFormManager.CloseAll(false);

            m_ParentForm.Dispose();
            m_ParentForm = null;
            m_PresenterTransaction.Dispose();

            base.TestCleanup();
        }

        [TestMethod]
        public void AvrReportControlPresenterGetAvrPermissionsTest()
        {
            string permissions = BaseMenuReportRegistrator.GetAvrPermissions(3);
            Assert.AreEqual("HumanCase.Select|VetCase.Select", permissions);
            permissions = BaseMenuReportRegistrator.GetAvrPermissions(1);
            Assert.AreEqual("VetCase.Select", permissions);
            permissions = BaseMenuReportRegistrator.GetAvrPermissions(2);
            Assert.AreEqual("HumanCase.Select", permissions);
            permissions = BaseMenuReportRegistrator.GetAvrPermissions(0);
            Assert.AreEqual("", permissions);
        }

        [TestMethod]
        public void AvrReportControlPresenterRegisterStaticReportsTest()
        {
            IMenuAction reports = WinMenuReportRegistrator.RegisterAllAvrReports(MenuActionManager.Instance, null);
            Assert.IsNotNull(reports);
            Assert.AreEqual(0, reports.Items.Count);
            // todo: [Ivan] Uncomment this when some standard reports will be published from AVR. Now we haven't requirements for them
            //Assert.IsTrue(reports.Items.Count > 0);
        }
    }
}