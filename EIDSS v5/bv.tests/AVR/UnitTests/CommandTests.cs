using System;
using System.Windows.Forms;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Core;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class CommandTests
    {
        [TestCleanup]
        public void TearDown()
        {
            MemoryManager.Flush();
        }

        [TestMethod]
        public void CommandConstructorTest()
        {
            Console.WriteLine(@"CommandConstructorTest");
            var cmd = new Command(this);
            Assert.AreEqual(this, cmd.Sender);
            Assert.AreEqual(CommandState.Unprecessed, cmd.State);
        }

        [TestMethod]
        public void CommandPropertiesTest()
        {
            Console.WriteLine(@"CommandPropertiesTest");
            var cmd = new Command(this) {State = CommandState.Pending};
            Assert.AreEqual(CommandState.Pending, cmd.State);
            cmd.State = CommandState.Processed;
            Assert.AreEqual(CommandState.Processed, cmd.State);
        }

        [TestMethod]
        public void SimpleReportViewCommandTest()
        {
            Console.WriteLine(@"SimpleReportViewCommandTest");
            var cmd = new ReportViewCommand(this);
            Assert.IsNull(cmd.NewParent);
            Assert.AreEqual(0, cmd.BottonAnchor);
        }

        [TestMethod]
        public void ComplexReportViewCommandTest()
        {
            Console.WriteLine(@"ComplexReportViewCommandTest");
            var parent = new Control();
            var cmd = new ReportViewCommand(this, parent, 123);
            Assert.AreEqual(parent, cmd.NewParent);
            Assert.AreEqual(123, cmd.BottonAnchor);
        }

        [TestMethod]
        public void ExportCommandTest()
        {
            Console.WriteLine(@"ExportCommandTest");
            var cmd = new ExportCommand(this, ExportObject.Chart, ExportType.PDF);
            Assert.AreEqual(ExportObject.Chart, cmd.ExportObject);
            Assert.AreEqual(ExportType.PDF, cmd.ExportType);
        }

        [TestMethod]
        public void LayoutCommandTest()
        {
            Console.WriteLine(@"LayoutCommandTest");
            var cmd = new LayoutCommand(this, LayoutOperation.Filter);
            Assert.AreEqual(LayoutOperation.Filter, cmd.Operation);
        }

        [TestMethod]
        public void PrintCommandTest()
        {
            Console.WriteLine(@"PrintCommandTest");
            var cmd = new PrintCommand(this, PrintType.Grid);
            Assert.AreEqual(PrintType.Grid, cmd.PrintType);
        }

        [TestMethod]
        public void QueryCommandTest()
        {
            Console.WriteLine(@"QueryCommandTest");
            var cmd = new QueryCommand(this, QueryOperation.Edit);
            Assert.AreEqual(QueryOperation.Edit, cmd.Operation);
        }

        [TestMethod]
        public void RefreshCommandTest()
        {
            Console.WriteLine(@"RefreshCommandTest");
            var cmd = new RefreshCommand(this, RefreshType.Grid);
            Assert.AreEqual(RefreshType.Grid, cmd.RefreshType);
        }
    }
}