using System.Collections.Generic;
using EIDSS.RAM;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;
using bv.common;
using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.AVR.Helpers.Fake;
using bv.tests.common;

namespace bv.tests.AVR.UnitTests.Presenters
{
    [TestClass]
    public class PresenterReportTests : BaseReportTests
    {
   

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            PresenterFactory.Init(new BaseForm());
            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }


        [TestMethod]
        public void LayoutDetailPostTest()
        {
            PresenterFactory.Init(new BaseFormStub());

            var mocks = new Mockery();

            var layoutDetailView = DataHelper.GetView<ILayoutDetailView>(mocks);
            Expect.Once.On(layoutDetailView).EventAdd("CopyLayoutCreating", Is.Anything);
            var detailPresenter = DataHelper.GetPresenter<LayoutDetailPresenter>(layoutDetailView);
            Assert.IsNotNull(detailPresenter);

            Assert.IsTrue(detailPresenter.Post(PostType.FinalPosting));
            Assert.IsFalse(detailPresenter.Post(PostType.IntermediatePosting));
            Assert.IsFalse(detailPresenter.Post(PostType.PerformAdditionalPosting));

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void BaseLayoutPresenterTryGetStartUpParameterTest()
        {
            object layoutId;
            var sharedPresenter = new SharedPresenter(new BaseForm());

            Assert.IsFalse(sharedPresenter.TryGetStartUpParameter("xxx", out layoutId));
            sharedPresenter.SharedModel.StartUpParameters = new Dictionary<string, object> {{"LayoutId", 10}};
            Assert.IsFalse(sharedPresenter.TryGetStartUpParameter("yyy", out layoutId));
            Assert.IsTrue(sharedPresenter.TryGetStartUpParameter("LayoutId", out layoutId));
            Assert.AreEqual(10, layoutId);
        }
    }
}
