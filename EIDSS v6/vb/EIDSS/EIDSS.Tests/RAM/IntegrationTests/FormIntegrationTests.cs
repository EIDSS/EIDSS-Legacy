using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using bv.common;
using bv.common.win;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM;
using EIDSS.RAM.Layout;
using EIDSS.RAM.Presenters.RamPivotGrid.PivotSummary;
using EIDSS.RAM.QueryBuilder;
using EIDSS.RAM_DB.DBService.Models;
using EIDSS.RAM_DB.Views;
using EIDSS.Reports.BaseControls.Transaction;
using EIDSS.Tests.RAM.Helpers;
using NMock2;
using NUnit.Framework;
using GlobalSettings=bv.common.GlobalSettings;
using Is=NMock2.Is;

namespace EIDSS.Tests.RAM.IntegrationTests
{
    [TestFixture]
    public class FormIntegrationTests : BaseTests
    {
        [TestFixtureSetUp]
        public override void FixtureSetUp()
        {
            base.FixtureSetUp();
            PresenterFactory.Init(new BaseForm());
        }

        [Test]
        public void LayoutFormLoadSaveTest()
        {
            LayoutFormLoadSave(false);
        }

        [Test]
        [Ignore("Should run manually because autobuild does not allow dialog")]
        public void LayoutFormLoadSaveWithBindingTest()
        {
            LayoutFormLoadSave(true);
        }

     

        private void LayoutFormLoadSave(bool needBind)
        {
            GlobalSettings.SelectDefaultQuery = true;
            using (new CultureInfoTransaction(new CultureInfo("ru-RU")))
            {
                QueryInfo queryInfo;
                LayoutInfo layoutInfo;
                LayoutDetail layoutDetail = ViewHelper.CreateLayoutControls(out queryInfo, out layoutInfo);

                queryInfo.SetDefaultQuery();
                layoutInfo.LoadData(-1);
                queryInfo.LoadData(QueryId);
                layoutDetail.LoadData(-1);

                string defaultLayoutName = "Some layout " + Guid.NewGuid();
                string layoutName = "Russian layout " + Guid.NewGuid();
                string pivotName = "Russian Pivot " + Guid.NewGuid();
                string mapName = "Russian map " + Guid.NewGuid();
                string chartName = "Russian chart " + Guid.NewGuid();
                string description = "Description " + Guid.NewGuid();
                DataRow dataRow = layoutDetail.baseDataSet.Tables[0].Rows[0];

                if (needBind)
                {
                    BindLayoutControls(layoutDetail, dataRow, defaultLayoutName, layoutName, pivotName,chartName, mapName, description, true, 2);
                }
                else
                {
                    BindLayoutDataTable(layoutDetail, dataRow, defaultLayoutName, layoutName, pivotName, chartName, mapName, description, true,
                                        10039002, 10013002);
                }
                layoutDetail.Post(PostType.FinalPosting);

                long layoutId = (long) dataRow["idflLayout"];
                Assert.Greater(layoutId, -1);
                layoutDetail.LoadData(-1);
                layoutDetail.LoadData(layoutId);

                dataRow = layoutDetail.baseDataSet.Tables[0].Rows[0];
                AssertData(dataRow, defaultLayoutName, layoutName, pivotName, chartName, mapName, description, true, 10039002, 10013002);

                defaultLayoutName = "Some layout " + Guid.NewGuid();
                layoutName = "Russian layout " + Guid.NewGuid();
                pivotName = "Russian layout " + Guid.NewGuid();
                mapName = "Russian map " + Guid.NewGuid();
                chartName = "Russian chart " + Guid.NewGuid();
                description = "Description " + Guid.NewGuid();

                if (needBind)
                {
                    BindLayoutControls(layoutDetail, dataRow, defaultLayoutName, layoutName, pivotName, chartName, mapName, description, false, 3);
                }
                else
                {
                    BindLayoutDataTable(layoutDetail, dataRow, defaultLayoutName, layoutName, pivotName, chartName, mapName, description, false,
                                        10039004, 10013020);
                }
                layoutDetail.Post(PostType.FinalPosting);

                AssertData(dataRow, defaultLayoutName, layoutName, pivotName, chartName, mapName, description, false, 10039004, 10013020);
            }
        }

        private void BindLayoutControls(Control layoutDetail, DataRow dataRow, string defaultLayoutName,
                                        string layoutName, string pivotName,string chartName, string mapName, string description, bool blnValue, int checkIndex)
        {
            //pivot
            TextEdit tbDefaultLayoutName = FindAndCheck<TextEdit>(layoutDetail, "tbDefaultLayoutName");
            TextEdit tbLayoutName = FindAndCheck<TextEdit>(layoutDetail, "tbLayoutName");
            TextEdit tbPivotName = FindAndCheck<TextEdit>(layoutDetail, "tbPivotName");
            TextEdit tbChartName = FindAndCheck<TextEdit>(layoutDetail, "tbChartName");
            
            MemoEdit memDescription = FindAndCheck<MemoEdit>(layoutDetail, "memDescription");
            CheckEdit ceShareLayout = FindAndCheck<CheckEdit>(layoutDetail, "ceShareLayout");
            CheckEdit chkApplyFilter = FindAndCheck<CheckEdit>(layoutDetail, "chkApplyFilter");
            LookUpEdit cbGroupInterval = FindAndCheck<LookUpEdit>(layoutDetail, "cbGroupInterval");
            CheckedComboBoxEdit ccbShowTotals = FindAndCheck<CheckedComboBoxEdit>(layoutDetail, "ccbShowTotals");
            // chart
            CheckEdit checkShowXAxesLabels = FindAndCheck<CheckEdit>(layoutDetail, "checkShowXAxesLabels");
            CheckEdit checkPointLabels = FindAndCheck<CheckEdit>(layoutDetail, "checkPointLabels");
            CheckEdit checkPivotAxes = FindAndCheck<CheckEdit>(layoutDetail, "checkPivotAxes");
            LookUpEdit cbChart = FindAndCheck<LookUpEdit>(layoutDetail, "cbChart");
            //map
            TextEdit tbMapName = FindAndCheck<TextEdit>(layoutDetail, "tbMapName");
            
            using (BindingHelper bindingHelper = new BindingHelper(dataRow))
            {
                //pivot
                bindingHelper.CheckTextBinding(tbDefaultLayoutName, "strDefaultLayoutName", defaultLayoutName);
                bindingHelper.CheckTextBinding(tbLayoutName, "strLayoutName", layoutName);
                bindingHelper.CheckTextBinding(tbPivotName, "strPivotName", pivotName);
                bindingHelper.CheckTextBinding(memDescription, "strDescription", description);
                bindingHelper.CheckBoolBinding(ceShareLayout, "blnShareLayout", blnValue);
                bindingHelper.CheckBoolBinding(chkApplyFilter, "blnApplyFilter", blnValue);
                bindingHelper.CheckComboBinding(cbGroupInterval, "idfsGroupInterval", checkIndex);
                bindingHelper.CheckComboBinding(ccbShowTotals, blnValue);

                //chart
                bindingHelper.CheckTextBinding(tbChartName, "strChartName", chartName);
                bindingHelper.CheckBoolBinding(checkShowXAxesLabels, "blnShowXLabels", blnValue);
                bindingHelper.CheckBoolBinding(checkPivotAxes, "blnPivotAxis", blnValue);
                bindingHelper.CheckBoolBinding(checkPointLabels, "blnShowPointLabels", blnValue);
                bindingHelper.CheckComboBinding(cbChart, "idfsChartType", checkIndex);
                //map
                bindingHelper.CheckTextBinding(tbMapName, "strMapName", mapName);
            }
        }

        private void BindLayoutDataTable(Control layoutDetail, DataRow dataRow, string defaultLayoutName,
                                         string layoutName, string pivotName, string chartName, string mapName, 
            string description, bool blnValue, int groupInterval, int chartType)
        {
            TextEdit tbDefaultLayoutName = FindAndCheck<TextEdit>(layoutDetail, "tbDefaultLayoutName");
            tbDefaultLayoutName.Text = defaultLayoutName;
            TextEdit tbLayoutName = FindAndCheck<TextEdit>(layoutDetail, "tbLayoutName");
            tbLayoutName.Text = layoutName;
            TextEdit tbPivotName = FindAndCheck<TextEdit>(layoutDetail, "tbPivotName");
            tbPivotName.Text = pivotName;

            dataRow["strDefaultLayoutName"] = defaultLayoutName;
            dataRow["strLayoutName"] = layoutName;
            dataRow["strPivotName"] = pivotName;
            dataRow["strChartName"] = chartName;
            dataRow["strMapName"] = mapName;
            dataRow["strDescription"] = description;
            dataRow["blnShareLayout"] = blnValue;
            dataRow["blnApplyFilter"] = blnValue;
            dataRow["idfsGroupInterval"] = groupInterval;
            dataRow["blnShowXLabels"] = blnValue;
            dataRow["blnShowPointLabels"] = blnValue;
            dataRow["blnPivotAxis"] = blnValue;

            dataRow["blnShowColsTotals"] = blnValue;
            dataRow["blnShowRowsTotals"] = !blnValue;
            dataRow["blnShowColGrandTotals"] = blnValue;
            dataRow["blnShowRowGrandTotals"] = !blnValue;
            dataRow["blnShowForSingleTotals"] = blnValue;
            dataRow["blnShowPointLabels"] = blnValue;
            dataRow["idfsChartType"] = chartType;
        }

        private static void AssertData(DataRow dataRow, string defaultLayoutName, string layoutName,
            string pivotName, string chartName, string mapName, string description,
                                       bool blnValue, int groupInterval, int chartType)
        {
            Assert.AreEqual(dataRow["strDefaultLayoutName"], defaultLayoutName);
            Assert.AreEqual(dataRow["strLayoutName"], layoutName);
            Assert.AreEqual(dataRow["strPivotName"], pivotName);
            Assert.AreEqual(dataRow["strChartName"], chartName);
            Assert.AreEqual(dataRow["strMapName"], mapName);
            Assert.AreEqual(dataRow["strDescription"], description);
            Assert.AreEqual(dataRow["blnShareLayout"], blnValue);
            Assert.AreEqual(dataRow["blnApplyFilter"], blnValue);
            Assert.AreEqual(dataRow["idfsGroupInterval"], groupInterval);
            Assert.AreEqual(dataRow["blnShowXLabels"], blnValue);
            Assert.AreEqual(dataRow["blnShowPointLabels"], blnValue);
            Assert.AreEqual(dataRow["blnPivotAxis"], blnValue);

            Assert.AreEqual(dataRow["blnShowColsTotals"], blnValue);
            Assert.AreEqual(dataRow["blnShowRowsTotals"], !blnValue);
            Assert.AreEqual(dataRow["blnShowColGrandTotals"], blnValue);
            Assert.AreEqual(dataRow["blnShowRowGrandTotals"], !blnValue);
            Assert.AreEqual(dataRow["blnShowForSingleTotals"], blnValue);
            Assert.AreEqual(dataRow["blnShowPointLabels"], blnValue);
            Assert.AreEqual(dataRow["idfsChartType"], chartType);
        }

        [Test]
        [Ignore]
        public void PivotDataMapTest()
        {
            GlobalSettings.SelectDefaultQuery = true;
            QueryInfo queryInfo;
            LayoutInfo layoutInfo;
            LayoutDetail layoutDetail = ViewHelper.CreateLayoutControls(out queryInfo, out layoutInfo);

            PivotForm pivotForm = ViewHelper.GetLayoutDetailControls(layoutDetail);

            queryInfo.SetDefaultQuery();
            layoutInfo.LoadData(-1);
            queryInfo.LoadData(-1);

            DataTable dataTable = pivotForm.PivotGrid.DataSource;
            Assert.IsNotNull(dataTable);

            foreach (PivotGridField field in pivotForm.PivotGrid.Fields)
            {
                if (field.Area == PivotArea.DataArea)
                {
                    pivotForm.PivotGrid.UpdatePivotFieldSummary(field, CustomSummaryType.Count);
                }
            }

            Mockery mocks = new Mockery();
            IView view = mocks.NewMock<IView>();
            Expect.Exactly(1).On(view).EventAdd("SendCommand", Is.Anything);

            SharedModel model = PresenterFactory.SharedPresenter.SharedModel;

            DataTable mapDataTable = model.GetMapDataTable("sflHCRayonsID");
            Assert.IsNotNull(mapDataTable);
            Assert.AreEqual(1, mapDataTable.Rows.Count);
            Assert.AreEqual("1", mapDataTable.Rows[0]["n_cases"].ToString());
            Assert.IsNotNull(mapDataTable.Rows.Find("GGAJKV"));

            mapDataTable = model.GetMapDataTable("sflHCRegionID");
            Assert.IsNotNull(mapDataTable);
            Assert.AreEqual(1, mapDataTable.Rows.Count);
            Assert.AreEqual("1", mapDataTable.Rows[0]["n_cases"].ToString());
            Assert.IsNotNull(mapDataTable.Rows.Find("GGAJ00"));
        }

        public T FindAndCheck<T>(Control parent, string name) where T : Control
        {
            T found = Find<T>(parent, name);
            Assert.IsNotNull(found);
            return found;
        }

        public T Find<T>(Control parent, string name) where T : Control
        {
            if ((parent.Name == name) && (parent is T))
            {
                return (T) parent;
            }
            foreach (Control child in parent.Controls)
            {
                T result = Find<T>(child, name);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
}