using bv.common.win;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM;
using EIDSS.RAM.Components;
using EIDSS.RAM.Layout;
using NUnit.Framework;

namespace EIDSS.Tests.RAM.IntegrationTests
{
    [TestFixture]
    public class FormConstructorTests : BaseTests
    {
        [TestFixtureSetUp]
        public override void FixtureSetUp()
        {
            base.FixtureSetUp();
            PresenterFactory.Init(new BaseForm());
        }

        [Test]
        public void FilterFormConstructorTest()
        {
            new FilterForm();
        }

        [Test]
        public void FilterFormPivotConstructorTest()
        {
            new FilterForm(new RamPivotGrid());
        }

        [Test]
        public void PivotConstructorTest()
        {
            new PivotForm();
        }

        [Test]
        public void PivotReportConstructorTest()
        {
            new PivotReportForm();
        }

        [Test]
        public void ChartConstructorTest()
        {
            new ChartForm();
        }

        [Test]
        public void MapConstructorTest()
        {
            new MapForm();
        }

        [Test]
        public void LayoutDetailConstructorTest()
        {
            new LayoutDetail();
        }

        [Test]
        public void LayoutInfoConstructorTest()
        {
            new LayoutInfo();
        }

        [Test]
        public void RamFormConstructorTest()
        {
            new RamForm();
        }
    }
}