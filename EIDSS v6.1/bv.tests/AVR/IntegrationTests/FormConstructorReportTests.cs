using System;
using EIDSS;
using bv.common.win;
using bv.tests.common;
using eidss.avr;
using eidss.avr.ChartForm;
using eidss.avr.FilterForm;
using eidss.avr.LayoutForm;
using eidss.avr.MainForm;
using eidss.avr.MapForm;
using eidss.avr.PivotComponents;
using eidss.avr.PivotForm;
using eidss.avr.QueryLayoutTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class FormConstructorReportTests : BaseReportTests
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
        public void FilterFormConstructorTest()
        {
            using (new FilterDialog())
            {
            }
        }

        [TestMethod]
        public void FilterFormPivotConstructorTest()
        {
            using (var ramPivotGrid = new AvrPivotGrid())
            {
                using (new FilterDialog(ramPivotGrid, null, HACode.None))
                {
                }
            }
        }

        [TestMethod]
        public void PivotConstructorTest()
        {
            using (new PivotDetailPanel())
            {
            }
        }

        [TestMethod]
        public void ChartConstructorTest()
        {
            using (new ChartDetailPanel())
            {
            }
        }

        [TestMethod]
        public void MapConstructorTest()
        {
            using (new MapDetailPanel())
            {
            }
        }

        [TestMethod]
        public void PivotInfoTest()
        {
            using (new PivotInfoDetailPanel())
            {
            }
        }

        [TestMethod]
        public void LayoutDetailConstructorTest()
        {
            using (new LayoutDetailPanel())
            {
            }
        }

        [TestMethod]
        public void QueryLayoutTreeListFormConstructorTest()
        {
            using (new QueryLayoutTreePanel())
            {
            }
        }

        [TestMethod]
        public void RamFormConstructorTest()
        {
            using (new AvrMainForm())
            {
            }
        }
    }
}