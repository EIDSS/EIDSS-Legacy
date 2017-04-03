using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using EIDSS.RAM;
using EIDSS.RAM.Components;
using EIDSS.RAM.Layout;
using EIDSS.Reports.BaseControls.Transaction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.win;
using bv.model.Model.Core;
using bv.tests.common;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.main;
using eidss.model.Core;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class FormConstructorReportTests :BaseReportTests
    {


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            PresenterFactory.Init(new BaseForm());
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void FilterFormConstructorTest()
        {
            using (new FilterForm())
            {
            }
        }


        
        [TestMethod]
        public void FilterFormPivotConstructorTest()
        {
            using (var ramPivotGrid = new RamPivotGrid())
            {
                using (new FilterForm(ramPivotGrid, null, null))
                {
                }
            }
        }

        [TestMethod]
        public void PivotConstructorTest()
        {
            using (new PivotForm())
            {
            }
        }

        [TestMethod]
        public void PivotReportConstructorTest()
        {
            using (new PivotReportForm())
            {
            }
        }

        [TestMethod]
        public void ChartConstructorTest()
        {
           
                using (new ChartForm())
                {
                }
            
        }

        [TestMethod]
        public void MapConstructorTest()
        {
            using (new MapForm())
            {
            }
        }

        [TestMethod]
        public void LayoutDetailConstructorTest()
        {
            using (new LayoutDetail())
            {
            }
        }

        [TestMethod]
        public void LayoutInfoConstructorTest()
        {
            using (new LayoutInfo())
            {
            }
        }

        [TestMethod]
        public void RamFormConstructorTest()
        {
            using (new RamForm())
            {
            }
        }

        [TestMethod]
        public void SwitchLanguageConstructorTest()
        {
            BaseReportTests.LoadAssemblies();
            var mainForm = new MainForm();
            try
            {
                mainForm.ResetLanguage(Localizer.lngRu);
                using (new RamForm())
                {
                }
            }
            finally
            {
                mainForm.ResetLanguage(Localizer.lngEn);
            }
        }
      
    }
}
