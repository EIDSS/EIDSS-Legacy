using System;
using System.Collections.Generic;
using bv.common.win;
using bv.tests.AVR.Helpers.Fake;
using bv.tests.common;
using eidss.avr;
using eidss.avr.BaseComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests.Presenters
{
    [TestClass]
    public class PresenterReportTests : BaseReportTests
    {
        private IDisposable m_PresenterTransaction;
        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
            m_PresenterTransaction = PresenterFactory.BeginSharedPresenterTransaction(m_Container, new BaseForm());
            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            m_PresenterTransaction.Dispose();
            base.TestCleanup();
        }

        [TestMethod]
        public void BaseLayoutPresenterTryGetStartUpParameterTest()
        {
            object layoutId;
            var sharedPresenter = new SharedPresenter(m_Container, new BaseForm());

            Assert.IsFalse(sharedPresenter.TryGetStartUpParameter("xxx", out layoutId));
            sharedPresenter.SharedModel.StartUpParameters = new Dictionary<string, object> {{"LayoutId", 10}};
            Assert.IsFalse(sharedPresenter.TryGetStartUpParameter("yyy", out layoutId));
            Assert.IsTrue(sharedPresenter.TryGetStartUpParameter("LayoutId", out layoutId));
            Assert.AreEqual(10, layoutId);
        }
    }
}