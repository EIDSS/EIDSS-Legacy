using System;
using System.Data;
using System.IO;
using bv.tests.AVR.IntegrationTests;
using bv.tests.common;
using eidss.model.AVR.SourceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Avr.Commands.Export;
using eidss.model.Avr.Export;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ExportToExcel
    {
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            BaseReportTests.LoadAssemblies();
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BaseReportTests.InitDBAndLogin();
        }

        [TestMethod]
        public void Export()
        {

            AvrDataTable data = CreateData();
            AccessTests.RemoveCopyColumns(data);
            string fileName = Path.GetTempPath() + "test.xls";
            using (var npoiExcelWrapper = new NpoiExcelWrapper(ExportType.Xls))
            {
                npoiExcelWrapper.Export(fileName, data);
                Assert.IsTrue(File.Exists(fileName));
                for (int j = 0; j < data.Columns.Count; j++)
                    Assert.AreEqual(data.Columns[j].Caption, npoiExcelWrapper.Workbook.GetSheetAt(0).GetRow(0).GetCell(j).StringCellValue);

                for (int j = 0; j < data.Rows.Count; j++)
                    Assert.AreEqual(data.Rows[j][0], npoiExcelWrapper.Workbook.GetSheetAt(0).GetRow(j + 1).GetCell(0).StringCellValue);
                for (int j = 0; j < data.Rows.Count; j++)
                    Assert.AreEqual(((DateTime)data.Rows[j][1]).Date, npoiExcelWrapper.Workbook.GetSheetAt(0).GetRow(j + 1).GetCell(1).DateCellValue.Date);
                for (int j = 0; j < data.Rows.Count; j++)
                    Assert.AreEqual(data.Rows[j][2], Convert.ToInt32(npoiExcelWrapper.Workbook.GetSheetAt(0).GetRow(j + 1).GetCell(2).NumericCellValue));
                for (int j = 0; j < data.Rows.Count; j++)
                    Assert.AreEqual(data.Rows[j][3], npoiExcelWrapper.Workbook.GetSheetAt(0).GetRow(j + 1).GetCell(3).NumericCellValue);
            }

            fileName = Path.GetTempPath() + "test.xlsx";
            using (var npoiExcelWrapper = new NpoiExcelWrapper(ExportType.Xlsx))
            {
                npoiExcelWrapper.Export(fileName, data);
                Assert.IsTrue(File.Exists(fileName));
                for (int j = 0; j < data.Columns.Count; j++)
                    Assert.AreEqual(data.Columns[j].Caption, npoiExcelWrapper.Workbook.GetSheetAt(0).GetRow(0).GetCell(j).StringCellValue);

                for (int j = 0; j < data.Rows.Count; j++)
                    Assert.AreEqual(data.Rows[j][0], npoiExcelWrapper.Workbook.GetSheetAt(0).GetRow(j + 1).GetCell(0).StringCellValue);
                for (int j = 0; j < data.Rows.Count; j++)
                    Assert.AreEqual(((DateTime)data.Rows[j][1]).Date, npoiExcelWrapper.Workbook.GetSheetAt(0).GetRow(j + 1).GetCell(1).DateCellValue.Date);
                for (int j = 0; j < data.Rows.Count; j++)
                    Assert.AreEqual(data.Rows[j][2], Convert.ToInt32(npoiExcelWrapper.Workbook.GetSheetAt(0).GetRow(j + 1).GetCell(2).NumericCellValue));
                for (int j = 0; j < data.Rows.Count; j++)
                    Assert.AreEqual(data.Rows[j][3], npoiExcelWrapper.Workbook.GetSheetAt(0).GetRow(j + 1).GetCell(3).NumericCellValue);
            }

            //fileName = Path.GetTempPath() + "test1.xlsx";
            //using (var npoiExcelWrapper = new ClosedXmlExcelWrapper())
            //{
            //    npoiExcelWrapper.Export(fileName, data);
            //    Assert.IsTrue(File.Exists(fileName));
            //}

        }
        [Ignore]
        [TestMethod]
        public void ExportBigData()
        {
            AvrDataTable data = CreateBigData(30, 100000);
            string fileName = Path.GetTempPath() + "testBig.xls";
            using (var npoiExcelWrapper = new NpoiExcelWrapper(ExportType.Xls))
            {
                npoiExcelWrapper.Export(fileName, data);
                Assert.IsTrue(File.Exists(fileName));
            }
            fileName = Path.GetTempPath() + "testBig1.xlsx";
            using (var npoiExcelWrapper = new NpoiExcelWrapper(ExportType.Xlsx))
            {
                npoiExcelWrapper.Export(fileName, data);
                Assert.IsTrue(File.Exists(NpoiExcelWrapper.AppendFileNameWithSuffix(fileName,"1")));
                Assert.IsTrue(File.Exists(NpoiExcelWrapper.AppendFileNameWithSuffix(fileName, "2")));
                Assert.IsTrue(File.Exists(NpoiExcelWrapper.AppendFileNameWithSuffix(fileName, "3")));
                Assert.IsTrue(File.Exists(NpoiExcelWrapper.AppendFileNameWithSuffix(fileName, "4")));
            }
        }

        private AvrDataTable CreateBigData(int colCount, int rowCount)
        {
            var data = new DataTable { TableName = "TestTable" };
            for (int i = 0; i < colCount; i++)
                 data.Columns.Add(new DataColumn("string"+i, typeof(string)) { Caption = "Caption " + i });
            for (int j = 0; j < rowCount; j++)
            {
                DataRow row = data.NewRow();
                for (int i = 0; i < colCount; i++)
                {
                    row[i] = "Test string Test string Test string Test string Test string Test string";
                }
                data.Rows.Add(row);

            }
            return new AvrDataTable(data);
        }
        private AvrDataTable CreateData()
        {
            var data = new DataTable { TableName = "TestTable" };
            data.Columns.Add(new DataColumn("string", typeof(string)) { Caption = "string caption" });
            data.Columns.Add(new DataColumn("date", typeof(DateTime)) { Caption = "date caption" });
            data.Columns.Add(new DataColumn("int", typeof(int)) { Caption = "int caption" });
            data.Columns.Add(new DataColumn("double", typeof(double)) { Caption = "double caption" });
            DataRow row = data.NewRow();
            row["string"] = "s1";
            row["date"] = DateTime.Now;
            row["int"] = 1;
            row["double"] = 1.1;
            data.Rows.Add(row);
            row = data.NewRow();
            row["string"] = "s2";
            row["date"] = DateTime.Today;
            row["int"] = 3;
            row["double"] = 3.3;
            data.Rows.Add(row);

            return new AvrDataTable(data);
        }

    }
}
