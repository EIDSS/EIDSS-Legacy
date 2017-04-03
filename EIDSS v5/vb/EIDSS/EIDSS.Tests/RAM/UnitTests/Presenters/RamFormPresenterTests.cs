#region Using

using System;
using bv.common.win;
using EIDSS.RAM;
using EIDSS.RAM.Presenters.RamForm;
using EIDSS.Tests.RAM.Helpers.Fake;
using NUnit.Framework;
using bv.winclient.Core;

#endregion

namespace EIDSS.Tests.RAM.UnitTests.Presenters
{
    [TestFixture]
    public class RamFormPresenterTests
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

        [Test]
        [Ignore("Will be uncommented after creating predefined layouts")]
        public void RamReportControlPresenterRegisterStaticReportsTest()
        {
            MenuAction reports = RamMenuRegistrator.RegisterStaticReports(null);
            Assert.IsNotNull(reports);
            Assert.GreaterOrEqual(reports.Items.Count, 24);
        }
    }
}