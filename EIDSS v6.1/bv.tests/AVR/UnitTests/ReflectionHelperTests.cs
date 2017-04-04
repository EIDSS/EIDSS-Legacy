using System;
using bv.common.win;
using bv.tests.AVR.Helpers;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraReports.UI;
using EIDSS;
using eidss.avr;
using eidss.avr.PivotComponents;
using eidss.model.AVR.SourceData;
using eidss.model.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ReflectionHelperTests
    {
        private IDisposable m_PresenterTransaction;

        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { });
            return c;
        }
        [TestInitialize]
        public void MyTestInitialize()
        {
            EIDSS_LookupCacheHelper.Init();
            m_PresenterTransaction = PresenterFactory.BeginSharedPresenterTransaction(StructureMapContainerInit(),new BaseForm());
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            m_PresenterTransaction.Dispose();
        }

        [TestMethod]
        public void PivotReportFormFieldsReflectionTest()
        {
            PivotGridField field1;
            PivotGridField field2;
            PivotGridField field3;
            using (var pivotGridControl = new AvrPivotGrid())
            {
                var dataTable = new AvrDataTable(DataHelper.GenerateTestTable());

                pivotGridControl.SetDataSourceAndCreateFields(dataTable);

                pivotGridControl.Fields[0].Width = 1000;
                pivotGridControl.Fields[0].Visible = false;
                field1 = ReflectionHelper.CreateAndCopyProperties(pivotGridControl.Fields[0]);
                field2 = ReflectionHelper.CreateAndCopyProperties(pivotGridControl.Fields[2]);
                field3 = ReflectionHelper.CreateAndCopyProperties(pivotGridControl.Fields[4]);
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
            using (var pivotGrid = new AvrPivotGrid())
            {
                var dataTable = new AvrDataTable(DataHelper.GenerateTestTable());

                pivotGrid.SetDataSourceAndCreateFields(dataTable);

                xrPivotGrid = new XRPivotGrid();
                ReflectionHelper.CopyCommonProperties(pivotGrid, xrPivotGrid);

                Assert.AreEqual(pivotGrid.DataSource.RealPivotData, xrPivotGrid.DataSource);
                Assert.AreNotEqual(pivotGrid.Fields.Count, xrPivotGrid.Fields.Count);
            }
            Assert.AreEqual(0, xrPivotGrid.Fields.Count);
        }
    }
}