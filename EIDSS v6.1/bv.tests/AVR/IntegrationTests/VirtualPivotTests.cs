using System.Data;
using bv.common.Configuration;
using bv.common.db.Core;
using bv.model.BLToolkit;
using bv.tests.common;
using EIDSS;
using eidss.avr.service.VirtualLayout;
using eidss.model.Avr.View;
using eidss.model.Trace;
using eidss.model.WindowsService;
using EIDSS.AVR.Service.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class VirtualPivotTests
    {
        
        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r =>
            {
                r.For<ISchedulerConfigurationStrategy>().Use<SchedulerConfigurationStrategy>();
                r.For<ITraceStrategy>().Use<TraceHelper>();
            });
            return c;
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "AvrService").ConnectionString, DatabaseType.Avr);
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));

            BaseReportTests.InitDBAndLogin();
        }

        [TestMethod]
        public void VirtualPivotConstructorTest()
        {
            for (int i = 0; i < 30; i++)
            {
                using (new StopwathTransaction("++ VirtualPivot  - Construictor ++ " + i))
                {
                    using (new VirtualPivot(StructureMapContainerInit()))
                    {
                    }
                }
            }
        }

        [TestMethod]
        public void VirtualPivotGetModelTest()
        {
            DataView layoutLookup = LookupCache.Get(LookupTables.Layout);
            if (layoutLookup.Count > 0)
            {
                var layoutId = (long) layoutLookup.Table.Rows[0]["idflLayout"];

                for (int i = 0; i < 3; i++)
                {
                    using (new StopwathTransaction("++ VirtualPivot with View++ " + i))
                    {
                        AvrPivotViewModel model = VirtualPivot.CreateAvrPivotViewModel(layoutId, "en", StructureMapContainerInit());

                        Assert.IsNotNull(model);
                    }
                }
            }
        }
    }
}