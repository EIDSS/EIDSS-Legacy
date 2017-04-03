using EIDSS.RAM;
using EIDSS.RAM.Layout;
using EIDSS.RAM.QueryBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.common;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class FormBindingTests
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            BaseReportTests.InitDBAndLogin();
            PresenterFactory.Init(new BaseForm());
        }

        [TestMethod]
        public void LayoutBindingTest()
        {
            QueryInfo queryInfo;
            LayoutInfo layoutInfo;
            RamForm ramForm;
            LayoutDetail layoutDetail = ViewHelper.CreateLayoutControls(out queryInfo, out layoutInfo, out ramForm);

            object id = -1;
            layoutDetail.LoadData(ref id);

            ramForm.Dispose();
        }

        [TestMethod]
        public void LayoutLoadDataTest()
        {
            QueryInfo queryInfo;
            LayoutInfo layoutInfo;
            RamForm ramForm;
            LayoutDetail layoutDetail = ViewHelper.CreateLayoutControls(out queryInfo, out layoutInfo, out ramForm);

            queryInfo.SetDefaultQuery();

            object id = -1;
            layoutDetail.LoadData(ref id);
            id = BaseReportTests.QueryId;
            queryInfo.LoadData(ref id);
            id = -1;
            layoutDetail.LoadData(ref id);

            ramForm.Dispose();
        }
    }
}