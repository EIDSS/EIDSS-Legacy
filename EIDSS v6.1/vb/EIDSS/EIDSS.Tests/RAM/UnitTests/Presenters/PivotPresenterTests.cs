#region Using

using System;
using System.Data;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.win;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.RamPivotGrid;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.DBService.Enumerations;
using EIDSS.RAM_DB.Views;
using EIDSS.Tests.RAM.Helpers;
using EIDSS.Tests.RAM.Helpers.Fake;
using Ionic.Zlib;
using NMock2;
using NUnit.Framework;
using GlobalSettings=bv.common.GlobalSettings;
using Is=NMock2.Is;

#endregion

namespace EIDSS.Tests.RAM.UnitTests.Presenters
{
    [TestFixture]
    public class PivotPresenterTests
    {
        private static readonly string[] m_Regions = new string[] { "Adjara (GGAJ00)", "Guria (GGGU00)", "Kakheti (GGKA00)", "Shida Kartli (GGSD00)", "Tbilisi (GGTB00)" };
        private static readonly long[] m_RegionsId = new long[] { 37030000000, 37040000000, 37060000000, 37100000000, 37130000000 };


        
        [SetUp]
        public void SetUp()
        {
            EIDSS_LookupCacheHelper.Init();
            GlobalSettings.Init("EIDSS_Caption", "Electronic Integrated Disease Surveillance System", "EIDSS");
            PresenterFactory.Init(new BaseForm());

            PresenterFactory.SharedPresenter.SharedModel.ExportStrategy = new FakeExportDialogStrategy();
        }

        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }

        [Test]
        public void PivotPresenterConvertValueToIntTest()
        {
            ConvertToIntAssert(0, null);
            ConvertToIntAssert(0, 0.1f);
            ConvertToIntAssert(1, 0.51f);
            ConvertToIntAssert(1, 0.51m);
            ConvertToIntAssert(1, 0.51d);
            ConvertToIntAssert(0, 0.49m);
            ConvertToIntAssert(10001, 10000.59m);
            ConvertToIntAssert(10000, 10000L);
            ConvertToIntAssert(10000, 10000);
        }

        [Test]
        public void PivotPresenterGetGroupIntervalTypeTest()
        {
            Assert.AreEqual(PivotGroupInterval.Date, PivotPresenter.GetGroupInterval(-1));
            Assert.AreEqual(PivotGroupInterval.DateMonth,
                            PivotPresenter.GetGroupInterval((long) DBGroupInterval.gitDateMonth));
            Assert.AreEqual(PivotGroupInterval.Date, PivotPresenter.GetGroupInterval(DBNull.Value));
            Assert.AreEqual(PivotGroupInterval.Date, PivotPresenter.GetGroupInterval(null));
        }

        [Test]
        public void PivotPresenterLayoutXmlTest()
        {
            Mockery mocks = new Mockery();
            DataSet dataSet = GetPivotDataSet();
            PivotPresenter pivotPresenter = GetAndCheckPivotPresenter(mocks, dataSet);

            Assert.AreEqual("xxx", pivotPresenter.LayoutXml);
            pivotPresenter.LayoutXml = "yyy";
            Assert.AreEqual("yyy", pivotPresenter.LayoutXml);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void PivotPresenterNullDatasetTest()
        {
            try
            {
                Mockery mocks = new Mockery();
                PivotPresenter pivotPresenter = GetAndCheckPivotPresenter(mocks, null);

                pivotPresenter.LayoutXml = "yyy";

                mocks.VerifyAllExpectationsHaveBeenMet();
            }
            catch (RamException ex)
            {
                Assert.AreEqual("Dataset of view pivotView is not initialized", ex.Message);
            }
        }

        [Test]
        public void GetMapDataTableTest()
        {
            Mockery mocks = new Mockery();
            RamPivotGrid pivotGrid = new RamPivotGrid();
            PivotGridField field = new PivotGridField("xxx", PivotArea.RowArea);
            pivotGrid.Fields.Add(field);

            IRamPivotGridView pivotGridView = mocks.NewMock<IRamPivotGridView>();
            Expect.Once.On(pivotGridView).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(pivotGridView).EventAdd("FieldVisibleChanged", Is.Anything);

            RamPivotGridPresenter gridPresenter =
                PresenterFactory.SharedPresenter[pivotGridView] as RamPivotGridPresenter;
            Assert.IsNotNull(gridPresenter);

            IPivotView pivotView;
            DataGridView dataGridView = GetMapDataGrid();
            DataSet dataSet = GetPivotDataSet();
            PivotPresenter pivotPresenter = GetAndCheckPivotPresenter(mocks, dataSet, out pivotView);
            pivotPresenter.PivotFields = pivotGrid.Fields;
            Expect.AtLeastOnce.On(pivotView).GetProperty("Fields").Will(Return.Value(pivotGrid.Fields));
            Expect.AtLeastOnce.On(pivotView).GetProperty("MapDataView").Will(Return.Value(dataGridView));
            Expect.AtLeastOnce.On(pivotView).GetProperty("CorrectedLayoutName").Will(Return.Value("CorrectedLayoutName"));
            Expect.AtLeastOnce.On(pivotView).Method("OnChangeOrientation");

            pivotPresenter.LayoutXml = "yyy";

            PresenterFactory.SharedPresenter.SharedModel.ChartDataVertical = true;

            DataTable result = pivotPresenter.GetMapDataTable("xxx");
            Assert.IsNotNull(result);
            Assert.AreEqual("CorrectedLayoutName", result.TableName);
            Assert.AreEqual(5, result.Rows.Count);

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(m_RegionsId[i], result.Rows[i]["id"], "error in Administrating Unit ID");
                Assert.AreEqual((4 * i + 1), result.Rows[i]["value"], "error while calculating value");
            }

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private static DataGridView GetMapDataGrid()
        {
            DataGridView dataGridView = new DataGridView();
            dataGridView.ReadOnly = true;

            dataGridView.AutoGenerateColumns = false;
            AddColumn(dataGridView, "Series", "seriesDataGridViewTextBoxColumn");
            AddColumn(dataGridView, "Arguments", "argumentsDataGridViewTextBoxColumn");
            AddColumn(dataGridView, "Values", "valuesDataGridViewTextBoxColumn");

            dataGridView.Rows[0].Cells[0].Value = "series_1";
            dataGridView.Rows[0].Cells[1].Value = "yyy0";
            dataGridView.Rows[0].Cells[2].Value = 0;
            
            //long[] regions = new long[] {48710000000, 32380000000, 32920000000, 44090000000, 32650000000};
            for (int i = 1; i < 10; i++)
            {
                dataGridView.Rows.Add("series_1", m_Regions[i / 2], i);
            }

            return dataGridView;
        }

        private static void AddColumn(DataGridView dataGridView, string propertyName, string name)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = propertyName;
            column.Name = name;
            dataGridView.Columns.Add(column);
        }

        private static DataSet GetPivotDataSet()
        {
            LayoutDetailDataSet dataSet = new LayoutDetailDataSet();
            dataSet.EnforceConstraints = false;
            LayoutDetailDataSet.LayoutRow row = dataSet.Layout.NewLayoutRow();

            row.idflLayout = 1;
            row.idflQuery = 1;
            row.idfUserID = 1;

            row.strBasicXml = "xxx";
            row.blbZippedBasicXml = ZlibStream.CompressString(row.strBasicXml);
            row.strLayoutName = Guid.NewGuid().ToString();
            row.strDefaultLayoutName = Guid.NewGuid().ToString();
            dataSet.Layout.AddLayoutRow(row);
            dataSet.AcceptChanges();
            return dataSet;
        }

        private static PivotPresenter GetAndCheckPivotPresenter(Mockery mocks, DataSet dataSet)
        {
            IPivotView pivotView;

            return GetAndCheckPivotPresenter(mocks, dataSet, out pivotView);
        }

        internal static PivotPresenter GetAndCheckPivotPresenter(Mockery mocks, DataSet dataSet,
                                                                 out IPivotView pivotView)
        {
            pivotView = GetPivotView(mocks);

            Expect.AtLeastOnce.On(pivotView).GetProperty("baseDataSet").Will(Return.Value(dataSet));

            PivotPresenter pivotPresenter = DataHelper.GetPresenter<PivotPresenter>(pivotView);
            Assert.IsNotNull(pivotPresenter);
            return pivotPresenter;
        }

        internal static IPivotView GetPivotView(Mockery mocks)
        {
            IPivotView pivotView = DataHelper.GetView<IPivotView>(mocks);
            Expect.Once.On(pivotView).EventAdd("PivotSelected", Is.Anything);
            Expect.Once.On(pivotView).EventAdd("PivotDataLoaded", Is.Anything);
            Expect.Once.On(pivotView).EventAdd("InitAdmUnit", Is.Anything);
            Expect.Once.On(pivotView).EventAdd("InitDenominator", Is.Anything);
            return pivotView;
        }

        private static void ConvertToIntAssert(object expected, object actual)
        {
            int value = PivotPresenter.ConvertValueToInt(actual);
            Assert.AreEqual(expected, value);
        }
    }
}