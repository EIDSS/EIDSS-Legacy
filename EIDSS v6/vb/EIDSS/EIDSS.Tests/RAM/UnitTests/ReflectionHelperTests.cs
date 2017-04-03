#region Using

using System.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UI.PivotGrid;
using EIDSS.RAM.Components;
using EIDSS.RAM_DB.Common;
using EIDSS.Tests.RAM.Helpers;
using NUnit.Framework;

#endregion

namespace EIDSS.Tests.RAM.UnitTests
{
    public class ReflectionHelperTests
    {
        [Test]
        public void PivotReportFormFieldsReflectionTest()
        {
            RamPivotGrid pivotGridControl = new RamPivotGrid();
            DataTable dataTable = DataHelper.GenerateTestTable();

            pivotGridControl.DataSource = dataTable;

            pivotGridControl.Fields[0].Width = 1000;
            pivotGridControl.Fields[0].Visible = false;
            XRPivotGridField field1 =
                ReflectionHelper.CreateAndCopyProperties(pivotGridControl.Fields[0] as XRPivotGridField);
            XRPivotGridField field2 =
                ReflectionHelper.CreateAndCopyProperties(pivotGridControl.Fields[1] as XRPivotGridField);
            XRPivotGridField field3 =
                ReflectionHelper.CreateAndCopyProperties(pivotGridControl.Fields[2] as XRPivotGridField);

            Assert.AreEqual("column1_Caption", field1.Caption);
            Assert.AreEqual("column2_Caption", field2.Caption);
            Assert.AreEqual("column3_Caption", field3.Caption);
            Assert.AreEqual(1000, field1.Width);
            Assert.AreEqual(false, field1.Visible);
        }

        [Test]
        public void PivotReportFormPivotReflectionTest()
        {
            RamPivotGrid pivotGrid = new RamPivotGrid();
            DataTable dataTable = DataHelper.GenerateTestTable();

            pivotGrid.DataSource = dataTable;

            XRPivotGrid xrPivotGrid = new XRPivotGrid();
            ReflectionHelper.CopyCommonProperties(pivotGrid, xrPivotGrid);

            Assert.AreEqual(pivotGrid.DataSource, xrPivotGrid.DataSource);
            Assert.AreNotEqual(pivotGrid.Fields.Count, xrPivotGrid.Fields.Count);
            Assert.AreEqual(0, xrPivotGrid.Fields.Count);
        }
    }
}