using System;
using System.Data;
using System.IO;
using bv.common.db.Core;
using bv.common.win;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM;
using EIDSS.RAM.Components;
using EIDSS.RAM.Components.DataTransactions;
using EIDSS.RAM.Layout;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.RamPivotGrid;
using EIDSS.RAM.Presenters.RamPivotGrid.PivotSummary;
using EIDSS.RAM.QueryBuilder;
using EIDSS.RAM_DB.DBService.QueryBuilder;
using EIDSS.Tests.RAM.Helpers;
using NUnit.Framework;

namespace EIDSS.Tests.RAM.UnitTests
{
    [TestFixture]
    public class ViewTests : BaseTests
    {
        private PivotForm m_Pivot;

        [TestFixtureSetUp]
        public override void FixtureSetUp()
        {
            base.FixtureSetUp();

            PresenterFactory.Init(new BaseForm());
            m_Pivot = new PivotForm();
        }

        [Test]
        public void PivotLayoutTest()
        {
            DataTable dataTable = DataHelper.GenerateTestTable();
            m_Pivot.PivotGrid.DataSource = dataTable;
            string fileXml;
            m_Pivot.PivotGrid.SaveLayoutToXml("1.xml");
            using (StreamReader reader = new StreamReader("1.xml"))
            {
                fileXml = reader.ReadToEnd();
                Console.WriteLine(@"file xml length={0}", fileXml.Length);
            }

            string streamXml = GetLayoutXml(m_Pivot.PivotGrid);

            Assert.AreEqual(streamXml, fileXml);

            SetLayoutXml(m_Pivot.PivotGrid, streamXml);
        }

        [Test]
        public void PivotDataTransactionTest()
        {
            DataTable dataTable = DataHelper.GenerateTestTable();
            m_Pivot.PivotGrid.DataSource = dataTable;
            for (int i = 0; i < 2; i++)
            {
                using (DataTransaction transaction = m_Pivot.PivotGrid.BeginTransaction())
                {
                    Assert.IsTrue(transaction.HasData);
                    using (DataTransaction innerTransaction = m_Pivot.PivotGrid.BeginTransaction())
                    {
                        Assert.IsFalse(innerTransaction.HasData);
                    }
                    Assert.IsTrue(transaction.HasData);
                }
            }
        }

        [Test]
        public void GetPivotSummaryTypeTest()
        {
            DataTable dataTable = DataHelper.GenerateTestTable();
            foreach (DataColumn column in dataTable.Columns)
            {
                PivotGridField field = RamPivotGridPresenter.GetNewField(column);

                m_Pivot.PivotGrid.Fields.Add(field);
            }

            m_Pivot.PivotGrid.DataSource = dataTable;
            Assert.IsTrue(Configuration.SummaryTypeDictionary.ContainsKey(typeof (string)));
            CustomSummaryType type = Configuration.SummaryTypeDictionary[typeof (string)];
            Assert.AreEqual(CustomSummaryType.Max, type);

            Assert.IsTrue(Configuration.SummaryTypeDictionary.ContainsKey(typeof (DateTime)));
            type = Configuration.SummaryTypeDictionary[typeof (DateTime)];
            Assert.AreEqual(CustomSummaryType.Max, type);

            Assert.IsFalse(Configuration.SummaryTypeDictionary.ContainsKey(typeof (bool)));
            type = Configuration.DefaltSummaryType;
            Assert.AreEqual(CustomSummaryType.Count, type);

            Assert.IsTrue(Configuration.SummaryTypeDictionary.ContainsKey(typeof (int)));
            type = Configuration.SummaryTypeDictionary[typeof (int)];
            Assert.AreEqual(CustomSummaryType.Count, type);

            Assert.IsTrue(Configuration.SummaryTypeDictionary.ContainsKey(typeof (long)));
            type = Configuration.SummaryTypeDictionary[typeof (long)];
            Assert.AreEqual(CustomSummaryType.Count, type);
        }

        [Test]
        public void LookupAggregateTest()
        {
            DataView view = LookupCache.Get(LookupTables.AggregateFunction.ToString());
            Assert.GreaterOrEqual(view.Count, 6);
        }

        [Test]
        public void SetLookAndFeelTest()
        {
            GroupControl panel1 = new GroupControl();
            GroupControl panel2 = new GroupControl();
            panel1.Controls.Add(panel2);
            SimpleButton button = new SimpleButton();
            panel2.Controls.Add(button);

            Assert.AreNotEqual("Black", button.LookAndFeel.ActiveSkinName);
            Assert.IsTrue(button.LookAndFeel.UseDefaultLookAndFeel);

            SharedPresenter.SetBlackLookAndFeel(panel1);

            Assert.AreEqual("Black", button.LookAndFeel.ActiveSkinName);
            Assert.IsFalse(button.LookAndFeel.UseDefaultLookAndFeel);
        }

        [Test]
        public void QueryInfo_DBTest()
        {
            QueryInfo info = new QueryInfo();
            Assert.IsNotNull(info.DbService);
            Assert.IsTrue(info.DbService is QueryInfo_DB);
        }

        internal static string GetLayoutXml(RamPivotGrid pivotGrid)
        {
            string streamXml;
            using (MemoryStream stream = new MemoryStream())
            {
                pivotGrid.SaveLayoutToStream(stream);
                stream.Position = 0;
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    streamXml = streamReader.ReadToEnd();
                    Console.WriteLine(@"in memory xml length={0}", streamXml.Length);
                }
            }
            return streamXml;
        }

        private static void SetLayoutXml(PivotGridControl pivotGrid, string streamXml)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter streamWriter = new StreamWriter(stream))
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