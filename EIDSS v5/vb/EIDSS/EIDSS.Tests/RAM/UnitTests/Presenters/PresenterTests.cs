using System;
using System.Collections;
using bv.common;
using bv.common.win;
using EIDSS.RAM;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Views;
using EIDSS.Tests.RAM.Helpers;
using EIDSS.Tests.RAM.Helpers.Fake;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace EIDSS.Tests.RAM.UnitTests.Presenters
{
    [TestFixture]
    public class PresenterTests
    {
        [SetUp]
        public void SetUp()
        {
            PresenterFactory.Init(new BaseForm());

            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();
        }

        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }

        [Test]
        public void LayoutDetailPostTest()
        {
            PresenterFactory.Init(new BaseFormStub());

            Mockery mocks = new Mockery();

            ILayoutDetailView layoutDetailView = DataHelper.GetView<ILayoutDetailView>(mocks);
            Expect.Once.On(layoutDetailView).EventAdd("CopyLayoutCreating", Is.Anything);
            LayoutDetailPresenter detailPresenter = DataHelper.GetPresenter<LayoutDetailPresenter>(layoutDetailView);
            Assert.IsNotNull(detailPresenter);

            Assert.IsTrue(detailPresenter.Post(PostType.FinalPosting));
            Assert.IsFalse(detailPresenter.Post(PostType.IntermediatePosting));
            Assert.IsFalse(detailPresenter.Post(PostType.PerformAdditionalPosting));

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void BaseLayoutPresenterTryGetStartUpParameterTest()
        {
            object layoutId;
            SharedPresenter sharedPresenter = new SharedPresenter(new BaseForm());

            Assert.IsFalse(sharedPresenter.TryGetStartUpParameter("xxx", out layoutId));
            sharedPresenter.SharedModel.StartUpParameters = new Hashtable();
            sharedPresenter.SharedModel.StartUpParameters.Add("LayoutId", 10);
            Assert.IsFalse(sharedPresenter.TryGetStartUpParameter("yyy", out layoutId));
            Assert.IsTrue(sharedPresenter.TryGetStartUpParameter("LayoutId", out layoutId));
            Assert.AreEqual(10, layoutId);
        }
    }
}