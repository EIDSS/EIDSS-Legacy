using System;
using System.Data;
using bv.common.Core;
using eidss.avr.db.Common.CommandProcessing.Commands.Export;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Export;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Commands.Print;
using eidss.model.Avr.Commands.Refresh;
using eidss.model.Avr.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.AreEqual(CommandState.Unprocessed, cmd.State);
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
        public void ExportCommandTest()
        {
            Console.WriteLine(@"ExportCommandTest");
            var cmd = new ExportCommand(this, ExportObject.Chart, ExportType.Pdf);
            Assert.AreEqual(ExportObject.Chart, cmd.ExportObject);
            Assert.AreEqual(ExportType.Pdf, cmd.ExportType);
        }

        [TestMethod]
        public void PivotGridDataLoadedCommandTest()
        {
            Console.WriteLine(@"PivotGridDataLoadedCommandTest");

            var avrView = new AvrView(-1, "", -1);
            var cmd = new AvrPivotViewModel( avrView, new DataTable());
            Assert.AreEqual(avrView, cmd.ViewHeader);
        }

        [TestMethod]
        public void PrintCommandTest()
        {
            Console.WriteLine(@"PrintCommandTest");
            var cmd = new PrintCommand(this, PrintType.View);
            Assert.AreEqual(PrintType.View, cmd.PrintType);
        }

        [TestMethod]
        public void RefreshCommandTest()
        {
            Console.WriteLine(@"RefreshCommandTest");
            var cmd = new RefreshPivotCommand(this);
            Assert.AreEqual(this, cmd.Sender);
        }
    }
}