using System.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UI.PivotGrid;
using EIDSS;
using EIDSS.RAM;
using EIDSS.RAM.Components;
using EIDSS.RAM_DB.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.win;
using bv.tests.AVR.Helpers;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ReflectionHelperTests
    {
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            EIDSS_LookupCacheHelper.Init();
            PresenterFactory.Init(new BaseForm());
            PresenterFactory.SharedPresenter.SharedModel.ResetReportDataCallback = () => { };
        }

        [TestMethod]
        public void PivotReportFormFieldsReflectionTest()
        {
            XRPivotGridField field1;
            XRPivotGridField field2;
            XRPivotGridField field3;
            using (var pivotGridControl = new RamPivotGrid())
            {
                DataTable dataTable = DataHelper.GenerateTestTable();

                pivotGridControl.DataSourceWithFields = dataTable;

                pivotGridControl.Fields[0].Width = 1000;
                pivotGridControl.Fields[0].Visible = false;
                field1 = ReflectionHelper.CreateAndCopyProperties(pivotGridControl.Fields[0] as XRPivotGridField);
                field2 = ReflectionHelper.CreateAndCopyProperties(pivotGridControl.Fields[1] as XRPivotGridField);
                field3 = ReflectionHelper.CreateAndCopyProperties(pivotGridControl.Fields[2] as XRPivotGridField);
            }

            Assert.AreEqual("sflHC_PatientAge_Caption", field1.Caption);
            Assert.AreEqual("sflHC_PatientDOB_Caption", field2.Caption);
            Assert.AreEqual("sflHC_CaseID_Caption", field3.Caption);
            Assert.AreEqual(1000, field1.Width);
            Assert.AreEqual(false, field1.Visible);
        }

        [TestMethod]
        public void PivotReportFormPivotReflectionTest()
        {
            XRPivotGrid xrPivotGrid;
            using (var pivotGrid = new RamPivotGrid())
            {
                DataTable dataTable = DataHelper.GenerateTestTable();

                pivotGrid.DataSourceWithFields = dataTable;

                xrPivotGrid = new XRPivotGrid();
                ReflectionHelper.CopyCommonProperties(pivotGrid, xrPivotGrid);

                Assert.AreEqual(pivotGrid.DataSource, xrPivotGrid.DataSource);
                Assert.AreNotEqual(pivotGrid.Fields.Count, xrPivotGrid.Fields.Count);
            }
            Assert.AreEqual(0, xrPivotGrid.Fields.Count);
        }
    }
}