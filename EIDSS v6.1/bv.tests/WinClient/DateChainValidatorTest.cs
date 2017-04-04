using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Resources;
using bv.common.win;
using bv.common.win.Validators;
using eidss.model.Resources;

namespace bv.tests.WinClient
{
    [TestClass]
    public class DateChainValidatorTest
    {
        private DataTable InitTable(string tableName, string masterRowName)
        {
            var table = new DataTable(tableName);
            table.Columns.Add(new DataColumn("id", typeof(long)));
            table.Columns[0].AutoIncrement = true;
            table.Columns[0].AutoIncrementSeed = 1;
            table.Columns[0].AutoIncrementStep = 1;
            table.PrimaryKey = new[] { table.Columns[0] };
            table.Columns.Add(new DataColumn("today", typeof(DateTime)));
            table.Columns.Add(new DataColumn("today_1", typeof(DateTime)));
            table.Columns.Add(new DataColumn("today_100", typeof(DateTime)));
            table.Columns.Add(new DataColumn("tomorrow", typeof(DateTime)));
            if (!string.IsNullOrEmpty(masterRowName))
                table.Columns.Add(new DataColumn(masterRowName, typeof(long)));
            return table;
        }

        private void AddDateRowToTable(DataTable table, object masterId)
        {
            var row = table.NewRow();
            row["today"] = DateTime.Today;
            row["today_1"] = DateTime.Today.AddDays(-1);
            row["today_100"] = DateTime.Today.AddDays(-100);
            row["tomorrow"] = DateTime.Today.AddDays(1);
            if (masterId != null)
                row[5] = masterId;
            table.Rows.Add(row);
        }

        //dataset structure
        //master table - 1 record
        //   detail table - 2 records
        //       detail detail table 2 records (2 record for each row in detail table)
        //all date fields are filled with default values
        private DataSet InitDataset()
        {

            BaseValidator.Messages = EidssMessages.Instance;
            var ds = new DataSet();
            var masterTable = InitTable("master", null);
            AddDateRowToTable(masterTable, null);
            ds.Tables.Add(masterTable);

            var detail = InitTable("detail", "masterId");
            AddDateRowToTable(detail, 1);
            AddDateRowToTable(detail, 1);
            ds.Tables.Add(detail);

            var detail1 = InitTable("detail1", "detailId");
            AddDateRowToTable(detail1, 1);
            AddDateRowToTable(detail1, 1);
            AddDateRowToTable(detail1, 2);
            AddDateRowToTable(detail1, 2);
            ds.Tables.Add(detail1);

            return ds;
        }

        private void test(DateChainValidator validator, DataRow row, string expectedErrorMsg)
        {
            var result = validator.Validate(row, false);
            var errorMsg = validator.ErrorMessage;
            if (expectedErrorMsg == null)
            {
                Assert.IsTrue(result);
                Assert.AreEqual(null, errorMsg);
            }
            else
            {
                Assert.IsFalse(result);
                Assert.AreEqual(expectedErrorMsg, errorMsg);
            }

        }


        [TestMethod]
        public void SimpleValidationTest()
        {
            var panel = new BaseDetailForm();
            panel.baseDataSet = InitDataset();
            var rootValidator = new DateChainValidator(panel, null, "master", "today_100", "Today_100");
            var yesterdayValidator = new DateChainValidator(panel, null, "master", "Today_1", "Today_1", null, false,
                                                            null,
                                                            false);
            rootValidator.AddChild(yesterdayValidator);
            var todayValidator = new DateChainValidator(panel, null, "master", "today", "Today", null, false, null,
                                                        true);
            yesterdayValidator.AddChild(todayValidator);
            var row = panel.baseDataSet.Tables["master"].Rows[0];

            test(rootValidator, row, null);

            var tomorrowValidator = new DateChainValidator(panel, null, "master", "tomorrow", "Tomorrow", null, false,
                                                           null,
                                                           true);
            yesterdayValidator.AddChild(tomorrowValidator);

            test(rootValidator, row, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Tomorrow", row["tomorrow"], BvMessages.Get("CurrentDate"), DateTime.Today));

            tomorrowValidator.CompareWithCurrentDate = false;
            test(rootValidator, row, null);

            row["today"] = DBNull.Value;
            test(rootValidator, row, null);
            test(todayValidator, row, null);
            test(yesterdayValidator, row, null);
            test(tomorrowValidator, row, null);

            row["today"] = DateTime.Today.AddDays(1);
            test(rootValidator, row, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today", row["today"], BvMessages.Get("CurrentDate"), DateTime.Today));
            row["today"] = DateTime.Today.AddDays(-2);
            test(rootValidator, row, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", row["today_1"], "Today", row["today"]));
            test(todayValidator, row, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", row["today_1"], "Today", row["today"]));
            test(yesterdayValidator, row, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", row["today_1"], "Today", row["today"]));
            test(tomorrowValidator, row, null);
        }

        [TestMethod]
        public void MasterDetailValidationTest()
        {
            var panel = new BaseDetailForm();
            panel.baseDataSet = InitDataset();
            var rootValidator = new DateChainValidator(panel, null, "master", "today_100", "Today_100");
            var yesterdayValidator = new DateChainValidator(panel, null, "detail", "Today_1", "Today_1", null, false,
                                                            null,
                                                            false);
            rootValidator.AddChild(yesterdayValidator);
            var todayValidator = new DateChainValidator(panel, null, "detail", "today", "Today", null, false, null,
                                                        true);
            yesterdayValidator.AddChild(todayValidator);
            var masterRow = panel.baseDataSet.Tables["master"].Rows[0];
            var detailRow1 = panel.baseDataSet.Tables["detail"].Rows[0];
            var detailRow2 = panel.baseDataSet.Tables["detail"].Rows[1];

            test(rootValidator, masterRow, null);
            test(todayValidator, detailRow1, null);
            test(todayValidator, detailRow2, null);


            detailRow2["today"] = DBNull.Value;
            test(rootValidator, masterRow, null);
            test(todayValidator, detailRow1, null);
            test(todayValidator, detailRow2, null);

            detailRow2["today"] = DateTime.Today.AddDays(1);
            test(rootValidator, masterRow, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today", detailRow2["today"], BvMessages.Get("CurrentDate"), DateTime.Today));
            detailRow2["today"] = DateTime.Today.AddDays(1);
            test(todayValidator, detailRow1, null);
            test(todayValidator, detailRow2, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today", detailRow2["today"], BvMessages.Get("CurrentDate"), DateTime.Today));

            detailRow2["today"] = DateTime.Today.AddDays(-2);
            test(rootValidator, masterRow, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", detailRow2["today"]));
            detailRow2["today"] = DateTime.Today.AddDays(-2);
            test(todayValidator, detailRow1, null);
            test(todayValidator, detailRow2, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", detailRow2["today"]));

        }

        [TestMethod]
        public void DetailDetailValidationTest()
        {
            var panel = new BaseDetailForm();
            panel.baseDataSet = InitDataset();
            var rootValidator = new DateChainValidator(panel, null, "detail", "today_100", "Today_100", null, false,
                                                            "masterId={0}",
                                                            false);
            var yesterdayValidator = new DateChainValidator(panel, null, "detail1", "Today_1", "Today_1", null, false,
                                                            "detailId={0}",
                                                            false);
            rootValidator.AddChild(yesterdayValidator);
            var todayValidator = new DateChainValidator(panel, null, "detail1", "today", "Today", null, false, "detailId={0}",
                                                        true);
            yesterdayValidator.AddChild(todayValidator);

            //Initial rows state
            //-100 < masterRow1
            // -1 < 0 detailRow1
            // -1 < 0 detailRow2
            //-100 < masterRow2
            // -1 < 0 detailRow3
            // -1 < 0 detailRow4
            var masterRow1 = panel.baseDataSet.Tables["detail"].Rows[0];
            var masterRow2 = panel.baseDataSet.Tables["detail"].Rows[1];
            var detailRow1 = panel.baseDataSet.Tables["detail1"].Rows[0];
            var detailRow2 = panel.baseDataSet.Tables["detail1"].Rows[1];
            var detailRow3 = panel.baseDataSet.Tables["detail1"].Rows[2];
            var detailRow4 = panel.baseDataSet.Tables["detail1"].Rows[3];
            //No errors
            //-100 <
            //   -1<0
            test(rootValidator, null, null);
            test(todayValidator, null, null);

            //0 < - error date
            // -1 < 0
            // -1 < 0
            //-100 <
            // -1 < 0
            // -1 < 0
            masterRow1["today_100"] = DateTime.Today;//error date
            test(rootValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_100", masterRow1["today_100"], "Today_1", detailRow1["today_1"]));
            test(rootValidator, masterRow1, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_100", masterRow1["today_100"], "Today_1", detailRow1["today_1"]));
            test(yesterdayValidator, detailRow1, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_100", masterRow1["today_100"], "Today_1", detailRow1["today_1"]));
            test(yesterdayValidator, detailRow2, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_100", masterRow1["today_100"], "Today_1", detailRow1["today_1"]));
            test(todayValidator, detailRow1, null);
            test(todayValidator, detailRow2, null);

            test(rootValidator, masterRow2, null);
            test(yesterdayValidator, detailRow3, null);
            test(yesterdayValidator, detailRow4, null);
            test(todayValidator, detailRow3, null);
            test(todayValidator, detailRow4, null);
            //0 < - error date
            // null < 0
            // -1 < 0
            //-100 <
            // -1 < 0
            // -1 < 0
            detailRow1["today_1"] = DBNull.Value;
            test(rootValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_100", masterRow1["today_100"], "Today_1", detailRow2["today_1"]));
            test(rootValidator, masterRow1, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_100", masterRow1["today_100"], "Today_1", detailRow2["today_1"]));
            test(yesterdayValidator, detailRow1, null);
            test(yesterdayValidator, detailRow2, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_100", masterRow1["today_100"], "Today_1", detailRow2["today_1"]));
            test(todayValidator, detailRow1, null);
            test(todayValidator, detailRow2, null);

            test(rootValidator, masterRow2, null);
            test(yesterdayValidator, detailRow3, null);
            test(yesterdayValidator, detailRow4, null);
            test(todayValidator, detailRow3, null);
            test(todayValidator, detailRow4, null);

            //-100<
            // -1 < 0
            // -1 < 0
            //-100 <
            // +1 < 0 error date
            // -1 < 0

            masterRow1["today_100"] = DateTime.Today.AddDays(-100);
            detailRow1["today_1"] = DateTime.Today.AddDays(-1);
            detailRow3["today_1"] = DateTime.Today.AddDays(1);//error date
            test(rootValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow3["today_1"], "Today", detailRow3["today"]));
            test(rootValidator, masterRow2, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow3["today_1"], "Today", detailRow3["today"]));
            test(rootValidator, masterRow1, null);
            test(yesterdayValidator, detailRow1, null);
            test(yesterdayValidator, detailRow2, null);
            test(yesterdayValidator, detailRow3, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow3["today_1"], "Today", detailRow3["today"]));
            test(yesterdayValidator, detailRow4, null);
            test(yesterdayValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow3["today_1"], "Today", detailRow3["today"]));
            //-100<
            // -1 < 0
            // -1 < 0
            //-100 <
            // -1 < 0
            // -1 < -2 error date

            detailRow3["today_1"] = DateTime.Today.AddDays(-1);
            detailRow4["today"] = DateTime.Today.AddDays(-2); //error date
            test(rootValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow4["today_1"], "Today", detailRow4["today"]));
            test(rootValidator, masterRow2, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow4["today_1"], "Today", detailRow4["today"]));
            test(rootValidator, masterRow1, null);
            test(yesterdayValidator, detailRow1, null);
            test(yesterdayValidator, detailRow2, null);
            test(yesterdayValidator, detailRow4, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow4["today_1"], "Today", detailRow4["today"]));
            test(yesterdayValidator, detailRow3, null);
            test(yesterdayValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow4["today_1"], "Today", detailRow4["today"]));
            test(todayValidator, detailRow3, null);
            test(todayValidator, detailRow4, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow4["today_1"], "Today", detailRow4["today"]));
        }

        [TestMethod]
        public void DetailMasterValidationTest()
        {
            var panel = new BaseDetailForm();
            panel.baseDataSet = InitDataset();
            var rootValidator = new DateChainValidator(panel, null, "detail1", "today_100", "Today_100", null, false,
                                                            null,
                                                            false, null);
            var yesterdayValidator = new DateChainValidator(panel, null, "detail", "Today_1", "Today_1", null, false,
                                                            "id={0}",
                                                            false, "detailId");
            rootValidator.AddChild(yesterdayValidator);
            var todayValidator = new DateChainValidator(panel, null, "master", "today", "Today", null, false, "id={0}",
                                                        true, "masterId");
            yesterdayValidator.AddChild(todayValidator);

            //Initial rows state
            // 0 > masterRow
            // -1 > detailRow1
            //   -100  detail1Row1
            //   -100  detail1Row2
            // -1 >  detailRow2
            //   -100  detail1Row3
            //   -100  detail1Row4
            var masterRow = panel.baseDataSet.Tables["master"].Rows[0];
            var detailRow1 = panel.baseDataSet.Tables["detail"].Rows[0];
            var detailRow2 = panel.baseDataSet.Tables["detail"].Rows[1];
            var detail1Row1 = panel.baseDataSet.Tables["detail1"].Rows[0];
            var detail1Row2 = panel.baseDataSet.Tables["detail1"].Rows[1];
            var detail1Row3 = panel.baseDataSet.Tables["detail1"].Rows[2];
            var detail1Row4 = panel.baseDataSet.Tables["detail1"].Rows[3];
            detail1Row1["today_100"] = DateTime.Today.AddDays(-100);
            detail1Row2["today_100"] = DateTime.Today.AddDays(-101);
            detail1Row3["today_100"] = DateTime.Today.AddDays(-102);
            detail1Row4["today_100"] = DateTime.Today.AddDays(-102);
            //No errors
            //0 > 
            //  -1 >
            //     -100
            test(rootValidator, null, null);
            test(rootValidator, detail1Row1, null);
            test(rootValidator, detail1Row4, null);
            test(todayValidator, null, null);
            test(yesterdayValidator, null, null);

            //-2 > error row
            // -1 > 
            //   -100  
            //   -101  
            // -1 >  
            //   -102  
            //   -103  
            masterRow["today"] = DateTime.Today.AddDays(-2);//error date
            test(rootValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow1["today_1"], "Today", masterRow["today"]));
            test(yesterdayValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow1["today_1"], "Today", masterRow["today"]));
            test(yesterdayValidator, detailRow1, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow1["today_1"], "Today", masterRow["today"]));
            test(yesterdayValidator, detailRow2, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", masterRow["today"]));
            test(todayValidator, masterRow, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow1["today_1"], "Today", masterRow["today"]));
            //-2 > error row
            //  null > 
            //   -100  
            //   -101  
            //  -1 >  
            //   -102  
            //   -103  
            detailRow1["today_1"] = DBNull.Value;
            test(rootValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", masterRow["today"]));
            test(yesterdayValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", masterRow["today"]));
            test(yesterdayValidator, detailRow1, null);
            test(yesterdayValidator, detailRow2, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", masterRow["today"]));
            test(todayValidator, masterRow, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", masterRow["today"]));
            test(rootValidator, detail1Row1, null);
            test(rootValidator, detail1Row2, null);
            test(rootValidator, detail1Row3, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", masterRow["today"]));
            test(rootValidator, detail1Row4, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", masterRow["today"]));
            //-101 > error row
            //  null > 
            //   -100  
            //   -101  
            //  -1 >  
            //   -102  
            //   -103  
            masterRow["today"] = DateTime.Today.AddDays(-101);//error date
            test(rootValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_100", detail1Row1["today_100"], "Today", masterRow["today"]));
            test(yesterdayValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", masterRow["today"]));
            test(yesterdayValidator, detailRow1, null);
            test(yesterdayValidator, detailRow2, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", masterRow["today"]));
            test(todayValidator, masterRow, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", masterRow["today"]));
            test(rootValidator, detail1Row1, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_100", detail1Row1["today_100"], "Today", masterRow["today"]));
            test(rootValidator, detail1Row2, null);
            test(rootValidator, detail1Row3, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", masterRow["today"]));
            test(rootValidator, detail1Row4, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_1", detailRow2["today_1"], "Today", masterRow["today"]));
            //-101 > 
            //  null > 
            //   -101  
            //   -101  
            //  -101 >  
            //   -102  
            //   -100  error row
            detailRow2["today_1"] = DateTime.Today.AddDays(-101);
            detail1Row1["today_100"] = DateTime.Today.AddDays(-101);
            detail1Row4["today_100"] = DateTime.Today.AddDays(-100);

            test(rootValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_100", detail1Row4["today_100"], "Today_1", detailRow2["today_1"]));
            test(yesterdayValidator, null, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_100", detail1Row4["today_100"], "Today_1", detailRow2["today_1"]));
            test(yesterdayValidator, detailRow1, null);
            test(yesterdayValidator, detailRow2, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_100", detail1Row4["today_100"], "Today_1", detailRow2["today_1"]));
            test(todayValidator, masterRow, null);
            test(rootValidator, detail1Row1, null);
            test(rootValidator, detail1Row2, null);
            test(rootValidator, detail1Row3, null);
            test(rootValidator, detail1Row4, string.Format(EidssMessages.Get("ErrUnstrictChainDate"), "Today_100", detail1Row4["today_100"], "Today_1", detailRow2["today_1"]));

        }

    }
}
