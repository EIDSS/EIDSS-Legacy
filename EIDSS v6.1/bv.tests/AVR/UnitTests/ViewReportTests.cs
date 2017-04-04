using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using bv.common.db.Core;
using bv.common.win;
using bv.tests.AVR.Helpers;
using bv.tests.common;
using DevExpress.XtraPivotGrid;
using EIDSS;
using eidss.avr;
using eidss.avr.db.Common;
using eidss.avr.PivotComponents;
using eidss.avr.PivotForm;
using eidss.avr.Tools.DataTransactions;
using eidss.model.Avr.Pivot;
using eidss.model.AVR.SourceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ViewReportTests : BaseReportTests
    {
        private IDisposable m_PresenterTransaction;

        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
            m_PresenterTransaction = PresenterFactory.BeginSharedPresenterTransaction(m_Container, new BaseForm());
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            m_PresenterTransaction.Dispose();
            base.TestCleanup();
        }

        [TestMethod]
        public void PivotLayoutTest()
        {
            using (var pivot = new PivotDetailPanel())
            {
                AvrDataTable dataTable = new AvrDataTable( DataHelper.GenerateTestTable());
                pivot.PivotGrid.SetDataSourceAndCreateFields(dataTable);
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
            using (var pivot = new PivotDetailPanel())
            {
                AvrDataTable dataTable = new AvrDataTable(DataHelper.GenerateTestTable());
                pivot.PivotGrid.SetDataSourceAndCreateFields(dataTable);
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
            using (var pivot = new PivotDetailPanel())
            {
                AvrDataTable dataTable = new AvrDataTable(DataHelper.GenerateTestTable());

                List<WinPivotGridField> list = AvrPivotGridHelper.CreateFields<WinPivotGridField>(dataTable);
                pivot.PivotGrid.Fields.AddRange(list.ToArray());

                pivot.PivotGrid.SetDataSourceAndCreateFields(dataTable);
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

        internal static string GetLayoutXml(AvrPivotGrid pivotGrid)
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