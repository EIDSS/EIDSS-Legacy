using bv.common.win;
using EIDSS.RAM;
using EIDSS.RAM.Layout;
using EIDSS.RAM.QueryBuilder;
using EIDSS.Tests.RAM.Helpers;
using NUnit.Framework;
using GlobalSettings=bv.common.GlobalSettings;

namespace EIDSS.Tests.RAM.IntegrationTests
{
    [TestFixture]
    public class FormBindingTests : BaseTests
    {
        [TestFixtureSetUp]
        public override void FixtureSetUp()
        {
            base.FixtureSetUp();
            PresenterFactory.Init(new BaseForm());
            GlobalSettings.SelectDefaultQuery = true;
        }

        [Test]
        public void LayoutBindingTest()
        {
            LayoutDetail layoutDetail = ViewHelper.CreateLayoutControls();
            layoutDetail.LoadData(-1);
        }

        [Test]
        public void LayoutLoadDataTest()
        {
            QueryInfo queryInfo;
            LayoutInfo layoutInfo;
            LayoutDetail layoutDetail = ViewHelper.CreateLayoutControls(out queryInfo, out layoutInfo);

            queryInfo.SetDefaultQuery();

            layoutInfo.LoadData(-1);
            queryInfo.LoadData(QueryId);
            layoutDetail.LoadData(-1);
        }
    }
}