using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using EIDSS;
using EIDSS.RAM;
using EIDSS.RAM.Components;
using EIDSS.RAM.Components.DataTransactions;
using EIDSS.RAM.Layout;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.RamPivotGrid;
using EIDSS.RAM.QueryBuilder;
using EIDSS.RAM_DB.Components;
using EIDSS.RAM_DB.DBService.QueryBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.db.Core;
using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.common;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ViewReportTests:BaseReportTests
    {
        


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            PresenterFactory.Init(new BaseForm());
            PresenterFactory.SharedPresenter.SharedModel.ResetReportDataCallback = () => { };
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }
        [TestMethod]
        public void PivotLayoutTest()
        {
            using (var pivot = new PivotForm())
            {
                DataTable dataTable = DataHelper.GenerateTestTable();
                pivot.PivotGrid.DataSourceWithFields = dataTable;
                string fileXml;
                pivot.PivotGrid.SaveLayoutToXml("1.xml");
                using (var reader = new StreamReader("1.xml"))
                {
                    fileXml = reader.ReadToEnd();
                    Console.WriteLine(@"file xml length={0}", fileXml.Length);
                }

                string streamXml = GetLayoutXml(pivot.PivotGrid);

                Assert.AreEqual(streamXml, fileXml);

                SetLayoutXml(pivot.PivotGrid, streamXml);
            }
        }

        [TestMethod]
        public void PivotDataTransactionTest()
        {
            using (var pivot = new PivotForm())
            {
                DataTable dataTable = DataHelper.GenerateTestTable();
                pivot.PivotGrid.DataSourceWithFields = dataTable;
                for (int i = 0; i < 2; i++)
                {
                    using (var transaction = (DataTransaction) pivot.PivotGrid.BeginTransaction())
                    {
                        Assert.IsTrue(transaction.HasData);
                        using (var innerTransaction = (DataTransaction) pivot.PivotGrid.BeginTransaction())
                        {
                            Assert.IsFalse(innerTransaction.HasData);
                        }
                        Assert.IsTrue(transaction.HasData);
                    }
                }
            }
        }

        [TestMethod]
        public void GetPivotSummaryTypeTest()
        {
            using (var pivot = new PivotForm())
            {
                DataTable dataTable = DataHelper.GenerateTestTable();

                List<WinPivotGridField> list = RamPivotGridPresenter.CreateWinFields(dataTable);
                pivot.PivotGrid.Fields.AddRange(list.ToArray());

                pivot.PivotGrid.DataSourceWithFields = dataTable;
                Assert.IsTrue(Configuration.SummaryTypeDictionary.ContainsKey(typeof (string)));
                CustomSummaryType type = Configuration.SummaryTypeDictionary[typeof (string)];
                Assert.AreEqual(CustomSummaryType.Count, type);

                Assert.IsTrue(Configuration.SummaryTypeDictionary.ContainsKey(typeof (DateTime)));
                type = Configuration.SummaryTypeDictionary[typeof (DateTime)];
                Assert.AreEqual(CustomSummaryType.Max, type);

                Assert.IsFalse(Configuration.SummaryTypeDictionary.ContainsKey(typeof (bool)));
                type = Configuration.DefaltSummaryType;
                Assert.AreEqual(CustomSummaryType.Count, type);

                Assert.IsTrue(Configuration.SummaryTypeDictionary.ContainsKey(typeof (int)));
                type = Configuration.SummaryTypeDictionary[typeof (int)];
                Assert.AreEqual(CustomSummaryType.Sum, type);

                Assert.IsTrue(Configuration.SummaryTypeDictionary.ContainsKey(typeof (long)));
                type = Configuration.SummaryTypeDictionary[typeof (long)];
                Assert.AreEqual(CustomSummaryType.Sum, type);
            }
        }

        [TestMethod]
        public void LookupAggregateTest()
        {
            DataView view = LookupCache.Get(LookupTables.AggregateFunction.ToString());
            Assert.IsTrue(view.Count >= 6);
        }

        [TestMethod]
        public void SetLookAndFeelTest()
        {
            var panel1 = new GroupControl();
            var panel2 = new GroupControl();
            panel1.Controls.Add(panel2);
            var button = new SimpleButton();
            panel2.Controls.Add(button);

            Assert.AreNotEqual("Black", button.LookAndFeel.ActiveSkinName);
            Assert.IsTrue(button.LookAndFeel.UseDefaultLookAndFeel);

            SharedPresenter.SetBlackLookAndFeel(panel1);

            Assert.AreEqual("Black", button.LookAndFeel.ActiveSkinName);
            Assert.IsFalse(button.LookAndFeel.UseDefaultLookAndFeel);
        }

        [TestMethod]
        public void QueryInfo_DBTest()
        {
            using (var info = new QueryInfo())
            {
                Assert.IsNotNull(info.DbService);
                Assert.IsTrue(info.DbService is QueryInfo_DB);
            }
        }

        internal static string GetLayoutXml(RamPivotGrid pivotGrid)
        {
            string streamXml;
            using (var stream = new MemoryStream())
            {
                pivotGrid.SaveLayoutToStream(stream);
                stream.Position = 0;
                using (var streamReader = new StreamReader(stream))
                {
                    streamXml = streamReader.ReadToEnd();
                    Console.WriteLine(@"in memory xml length={0}", streamXml.Length);
                }
            }
            return streamXml;
        }

        private static void SetLayoutXml(PivotGridControl pivotGrid, string streamXml)
        {
            using (var stream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write(streamXml);
                    streamWriter.Flush();
                    stream.Position = 0;
                    Console.WriteLine(@"stream xml length={0}", stream.Length);
                    Assert.AreEqual(stream.Length, streamXml.Length);

                    pivotGrid.RestoreLayoutFromStream(stream);
                }
            }
        }
    }
}
