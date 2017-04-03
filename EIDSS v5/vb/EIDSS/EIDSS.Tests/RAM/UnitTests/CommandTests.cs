#region Using

using System;
using System.Windows.Forms;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using NUnit.Framework;

#endregion

namespace EIDSS.Tests.RAM.UnitTests
{
    [TestFixture]
    public class CommandTests
    {
        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }

        [Test]
        public void CommandConstructorTest()
        {
            Console.WriteLine(@"CommandConstructorTest");
            Command cmd = new Command(this);
            Assert.AreEqual(this, cmd.Sender);
            Assert.AreEqual(CommandState.Unprecessed, cmd.State);
        }

        [Test]
        public void CommandPropertiesTest()
        {
            Console.WriteLine(@"CommandPropertiesTest");
            Command cmd = new Command(this);
            cmd.State = CommandState.Pending;
            Assert.AreEqual(CommandState.Pending, cmd.State);
            cmd.State = CommandState.Processed;
            Assert.AreEqual(CommandState.Processed, cmd.State);
        }

        [Test]
        public void SimpleReportViewCommandTest()
        {
            Console.WriteLine(@"SimpleReportViewCommandTest");
            ReportViewCommand cmd = new ReportViewCommand(this);
            Assert.IsNull(cmd.NewParent);
            Assert.AreEqual(0, cmd.BottonAnchor);
        }

        [Test]
        public void ComplexReportViewCommandTest()
        {
            Console.WriteLine(@"ComplexReportViewCommandTest");
            Control parent = new Control();
            ReportViewCommand cmd = new ReportViewCommand(this, parent, 123);
            Assert.AreEqual(parent, cmd.NewParent);
            Assert.AreEqual(123, cmd.BottonAnchor);
        }

        [Test]
        public void ExportCommandTest()
        {
            Console.WriteLine(@"ExportCommandTest");
            ExportCommand cmd = new ExportCommand(this, ExportObject.Chart, ExportType.PDF);
            Assert.AreEqual(ExportObject.Chart, cmd.ExportObject);
            Assert.AreEqual(ExportType.PDF, cmd.ExportType);
        }

        [Test]
        public void LayoutCommandTest()
        {
            Console.WriteLine(@"LayoutCommandTest");
            LayoutCommand cmd = new LayoutCommand(this, LayoutOperation.Filter);
            Assert.AreEqual(LayoutOperation.Filter, cmd.Operation);
        }

        [Test]
        public void PrintCommandTest()
        {
            Console.WriteLine(@"PrintCommandTest");
            PrintCommand cmd = new PrintCommand(this, PrintType.Grid);
            Assert.AreEqual(PrintType.Grid, cmd.PrintType);
        }

        [Test]
        public void QueryCommandTest()
        {
            Console.WriteLine(@"QueryCommandTest");
            QueryCommand cmd = new QueryCommand(this, QueryOperation.Edit);
            Assert.AreEqual(QueryOperation.Edit, cmd.Operation);
        }

        [Test]
        public void RefreshCommandTest()
        {
            Console.WriteLine(@"RefreshCommandTest");
            RefreshCommand cmd = new RefreshCommand(this, RefreshType.Grid);
            Assert.AreEqual(RefreshType.Grid, cmd.RefreshType);
        }
    }
}