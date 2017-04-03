using System.Data;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM;
using EIDSS.RAM.Layout;
using EIDSS.RAM.Presenters.RamForm;
using EIDSS.RAM.QueryBuilder;
using EIDSS.RAM_DB.Common;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.Access;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.AVR.Helpers;
using bv.tests.common;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class AccessIntegrationTests
    {

        [TestInitialize]
        public void MyTestInitialize()
        {
            BaseReportTests.LoadAssemblies();
            BaseReportTests.InitDBAndLogin();
        }

        [TestMethod]
        public void PivotFormExportToAccessTest()
        {
            const string queryString = "select * from dbo.fn_AVR_HumanCaseReport(@LangID) ";

            QueryInfo queryInfo;
            LayoutInfo layoutInfo;
            RamForm ramForm;
            LayoutDetail layoutDetail = ViewHelper.CreateLayoutControls(out queryInfo, out layoutInfo, out ramForm);
            PivotForm pivotForm = ViewHelper.GetLayoutDetailControls(layoutDetail);

            queryInfo.SetDefaultQuery();

            object id = -1;
            layoutDetail.LoadData(ref id);
            id = BaseReportTests.QueryId;
            queryInfo.LoadData(ref id);

            var db = (ramForm.DbService as BaseRamDbService);

            Assert.IsNotNull(db);
            DataTable dataTable = RamFormPresenter.GetQueryResult(db, queryString, "", false);

            QueryProcessor.RemoveNotExistingColumns(dataTable, BaseReportTests.QueryId);
            pivotForm.PivotGrid.DataSourceWithFields = dataTable;
            foreach (PivotGridField field in pivotForm.PivotGrid.Fields)
            {
                field.Visible = true;
            }
            pivotForm.PivotGrid.Fields[0].Visible = false;

            const string newName = "tmp_integrate.mdb";
            var adapter = new AccessDataAdapter(newName);
            DataTable table = pivotForm.PivotGrid.GetFilteredDataSource("Layout");

            adapter.ExportTableToAccess(table);
            Assert.AreEqual(true, adapter.IsTableExistInAccess("Layout"));

            ramForm.Dispose();
        }
    }
}
