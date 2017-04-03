using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM;
using EIDSS.RAM.Layout;
using EIDSS.RAM.QueryBuilder;
using EIDSS.RAM_DB.Components;
using EIDSS.RAM_DB.DBService.Models;
using EIDSS.RAM_DB.Views;
using EIDSS.Reports.BaseControls.Transaction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;
using bv.common;
using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.AVR.Helpers.Fake;
using bv.tests.common;
using eidss.model.Core.CultureInfo;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class FormIntegrationTests
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            BaseReportTests.LoadAssemblies();
            BaseReportTests.InitDBAndLogin();
            PresenterFactory.Init(new BaseForm());
            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();
        }

        [TestMethod]
        public void LayoutFormLoadSaveTest()
        {
            LayoutFormLoadSave(false);
        }

        private void LayoutFormLoadSave(bool needBind)
        {
            using (new CultureInfoTransaction(new CultureInfo("ru-RU")))
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

                string defaultLayoutName = "Some layout " + Guid.NewGuid();
                string layoutName = "Russian layout " + Guid.NewGuid();
                string pivotName = "Russian Pivot " + Guid.NewGuid();
                string mapName = "Russian map " + Guid.NewGuid();
                string chartName = "Russian chart " + Guid.NewGuid();
                string description = "Description " + Guid.NewGuid();
                DataRow dataRow = layoutDetail.baseDataSet.Tables["Layout"].Rows[0];

                if (needBind)
                {
                    BindLayoutControls(layoutDetail, dataRow, defaultLayoutName, layoutName, pivotName, chartName,
                                       mapName, description, true, 2);
                }
                else
                {
                    BindLayoutDataTable(layoutDetail, dataRow, defaultLayoutName, layoutName, pivotName, chartName,
                                        mapName, description, true, 10039002, 10013002);
                }
                layoutDetail.Post(PostType.FinalPosting);
                Assert.IsTrue(ramForm.ForcePost(), "Layout could not be posted: " + ramForm.DbService.LastError);
                

                var layoutId = (long) dataRow["idflLayout"];
                Assert.IsTrue(layoutId > -1);
                id = -1;
                layoutDetail.LoadData(ref id);
                id = layoutId;
                layoutDetail.LoadData(ref id);

                dataRow = layoutDetail.baseDataSet.Tables["Layout"].Rows[0];
                AssertData(dataRow, defaultLayoutName, layoutName, pivotName, chartName, mapName, description, true, 10039002, 10013002);

                defaultLayoutName = "Some layout " + Guid.NewGuid();
                layoutName = "Russian layout " + Guid.NewGuid();
                pivotName = "Russian layout " + Guid.NewGuid();
                mapName = "Russian map " + Guid.NewGuid();
                chartName = "Russian chart " + Guid.NewGuid();
                description = "Description " + Guid.NewGuid();

                if (needBind)
                {
                    BindLayoutControls(layoutDetail, dataRow, defaultLayoutName, layoutName, pivotName, chartName,
                                       mapName, description, false, 3);
                }
                else
                {
                    BindLayoutDataTable(layoutDetail, dataRow, defaultLayoutName, layoutName, pivotName, chartName,
                                        mapName, description, false, 10039004, 10013020);
                }
                layoutDetail.Post(PostType.FinalPosting);
                AssertData(dataRow, defaultLayoutName, layoutName, pivotName, chartName, mapName, description, false,
                           10039004, 10013020);
                ramForm.Dispose();
            }
        }

        private void BindLayoutControls
            (Control layoutDetail, DataRow dataRow, string defaultLayoutName,
             string layoutName, string pivotName, string chartName, string mapName, string description, bool blnValue,
             long checkIndex)
        {
            dataRow["idflQuery"] = BaseReportTests.QueryId;
            //pivot
            var tbDefaultLayoutName = FindAndCheck<TextEdit>(layoutDetail, "tbDefaultLayoutName");
            var tbLayoutName = FindAndCheck<TextEdit>(layoutDetail, "tbLayoutName");
            var tbPivotName = FindAndCheck<TextEdit>(layoutDetail, "tbPivotName");
            var tbChartName = FindAndCheck<TextEdit>(layoutDetail, "tbChartName");

            var memDescription = FindAndCheck<MemoEdit>(layoutDetail, "memDescription");
            var ceShareLayout = FindAndCheck<CheckEdit>(layoutDetail, "ceShareLayout");
            var chkApplyFilter = FindAndCheck<CheckEdit>(layoutDetail, "chkApplyFilter");
            var cbGroupInterval = FindAndCheck<LookUpEdit>(layoutDetail, "cbGroupInterval");
            var ccbShowTotals = FindAndCheck<CheckedComboBoxEdit>(layoutDetail, "ccbShowTotals");
            // chart
            var checkShowXAxesLabels = FindAndCheck<CheckEdit>(layoutDetail, "checkShowXAxesLabels");
            var checkPointLabels = FindAndCheck<CheckEdit>(layoutDetail, "checkPointLabels");
            var checkPivotAxes = FindAndCheck<CheckEdit>(layoutDetail, "checkPivotAxes");
            var cbChart = FindAndCheck<LookUpEdit>(layoutDetail, "cbChart");
            //map
            var tbMapName = FindAndCheck<TextEdit>(layoutDetail, "tbMapName");

            using (var bindingHelper = new BindingHelper(dataRow))
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

        private void BindLayoutDataTable
            (Control layoutDetail, DataRow dataRow, string defaultLayoutName,
             string layoutName, string pivotName, string chartName, string mapName,
             string description, bool blnValue, long groupInterval, long chartType)
        {
            var tbDefaultLayoutName = FindAndCheck<TextEdit>(layoutDetail, "tbDefaultLayoutName");
            tbDefaultLayoutName.Text = defaultLayoutName;
            var tbLayoutName = FindAndCheck<TextEdit>(layoutDetail, "tbLayoutName");
            tbLayoutName.Text = layoutName;
            var tbPivotName = FindAndCheck<TextEdit>(layoutDetail, "tbPivotName");
            tbPivotName.Text = pivotName;

            dataRow["idflQuery"] = BaseReportTests.QueryId;
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

        private static void AssertData
            (DataRow dataRow, string defaultLayoutName, string layoutName,
             string pivotName, string chartName, string mapName, string description,
             bool blnValue, long groupInterval, long chartType)
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

     
        public T FindAndCheck<T>(Control parent, string name) where T : Control
        {
            var found = Find<T>(parent, name);
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
                var result = Find<T>(child, name);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
}