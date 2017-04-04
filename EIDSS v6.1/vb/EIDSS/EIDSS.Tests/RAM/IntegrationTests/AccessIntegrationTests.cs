using System.Data;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM;
using EIDSS.RAM.Layout;
using EIDSS.RAM.QueryBuilder;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.Access;
using EIDSS.Tests.RAM.Helpers;
using NUnit.Framework;

namespace EIDSS.Tests.RAM.IntegrationTests
{
    [TestFixture]
    public class AccessIntegrationTests : BaseTests
    {
        [Test]
        public void PivotFormExportToAccessTest()
        {
            bv.common.GlobalSettings.SelectDefaultQuery = true;
            RamForm ramForm = new RamForm();
            QueryInfo queryInfo;
            LayoutInfo layoutInfo;
            LayoutDetail layoutDetail = ViewHelper.CreateLayoutControls(out queryInfo, out layoutInfo);
            PivotForm pivotForm = ViewHelper.GetLayoutDetailControls(layoutDetail);

            queryInfo.SetDefaultQuery();

            layoutInfo.LoadData(-1);
            queryInfo.LoadData(QueryId);

            const string queryString =
                "select * from dbo.fnRAMHumanCaseList(@LangID) ";

            BaseRamDbService db = (ramForm.DbService as BaseRamDbService);
            Assert.IsNotNull(db);
            DataTable dataTable = db.GetQueryResult(queryString);

            pivotForm.PivotGrid.DataSource = dataTable;
            foreach (PivotGridField field in pivotForm.PivotGrid.Fields)
            {
                field.Visible = true;
            }
            pivotForm.PivotGrid.Fields[0].Visible = false;

            const string newName = "tmp_integrate.mdb";
            AccessDataAdapter adapter = new AccessDataAdapter(newName);
            DataTable table = pivotForm.PivotGrid.GetFilteredDataSource("Layout");

            adapter.ExportTableToAccess(table);
            Assert.AreEqual(true, adapter.IsTableExistInAccess("Layout"));
        }
    }
}