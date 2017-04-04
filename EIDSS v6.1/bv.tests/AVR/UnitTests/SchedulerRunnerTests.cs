using System;
using System.Collections.Generic;
using System.Threading;
using bv.common.Configuration;
using bv.model.BLToolkit;
using eidss.model.WindowsService;
using EIDSS.AVR.Service.Scheduler;
using EIDSS.AVR.Service.WcfFacade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;
using StructureMap;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class SchedulerRunnerTests
    {
        private static IContainer m_Container;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            m_Container = StructureMapContainerInit();
        }

        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { r.For<ISchedulerConfigurationStrategy>().Use<SchedulerConfigurationStrategy>(); });
            return c;
        }

        [TestMethod]
        public void SchedulerRunnerDefaultConstructorTest()
        {
            using (m_Container.GetInstance<SchedulerRunner>())
            {
            }
        }

        [TestMethod]
        public void SchedulerRunnerDefaultConstructorStartTest()
        {
            using (var runner = m_Container.GetInstance<SchedulerRunner>())
            {
                runner.Start();
            }
        }

        [TestMethod]
        public void SchedulerRunnerFakeMissedTaskTickTest()
        {
            var mocks = new Mockery();
            var facade = mocks.NewMock<IAVRFacade>();

            Expect.Once.On(facade).Method("GetQueryIdList").Will(Return.Value(new List<long> {1, 2, 3}));

            Expect.Exactly(6).On(facade).Method("RefreshCachedQueryTableByScheduler");
            Expect.Exactly(6).On(facade).Method("DeleteQueryCacheForLanguage");

            Expect.Exactly(3).On(facade).Method("GetsQueryCacheUserRequestDate").Will(Return.Value(DateTime.Now));

            SchedulerConfigurationSection configuration = GetConfiguration(false);
            var languages = new List<string> {"en", "ru"};

            ISchedulerConfigurationStrategy configStrategy = mocks.NewMock<ISchedulerConfigurationStrategy>();
            Expect.Once.On(configStrategy).Method("GetAVRFacade").Will(Return.Value(facade));
            Expect.Once.On(configStrategy).Method("GetConfigurationSection").Will(Return.Value(configuration));
            Expect.Once.On(configStrategy).Method("GetLanguages").Will(Return.Value(languages));
            Expect.Once.On(configStrategy).Method("GetServiceDisplayName").Will(Return.Value("service name"));

            Container c = new Container();
            c.Configure(r => { r.For<ISchedulerConfigurationStrategy>().Use(configStrategy); });
            using (var runner = c.GetInstance<SchedulerRunner>())
            {
                runner.Start();
                Thread.Sleep(50);
                runner.QueryRefreshTimerTick(null);
            }

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void SchedulerRunnerFakeTickTest()
        {
            var mocks = new Mockery();
            var facade = mocks.NewMock<IAVRFacade>();

            Expect.Exactly(2).On(facade).Method("GetQueryIdList").Will(Return.Value(new List<long> {1, 2, 3}));
            Expect.Exactly(12).On(facade).Method("RefreshCachedQueryTableByScheduler");
            Expect.Exactly(12).On(facade).Method("DeleteQueryCacheForLanguage");
            Expect.Exactly(6).On(facade).Method("GetsQueryCacheUserRequestDate").Will(Return.Value(DateTime.Now));

            SchedulerConfigurationSection configuration = GetConfiguration(true);
            var languages = new List<string> {"en", "ru"};
            var configStrategy = mocks.NewMock<ISchedulerConfigurationStrategy>();
            Expect.Once.On(configStrategy).Method("GetAVRFacade").Will(Return.Value(facade));
            Expect.Once.On(configStrategy).Method("GetConfigurationSection").Will(Return.Value(configuration));
            Expect.Once.On(configStrategy).Method("GetLanguages").Will(Return.Value(languages));
            Expect.Once.On(configStrategy).Method("GetServiceDisplayName").Will(Return.Value("service name"));

            Container c = new Container();
            c.Configure(r => { r.For<ISchedulerConfigurationStrategy>().Use(configStrategy); });

            using (var runner = c.GetInstance<SchedulerRunner>())
            {
                runner.Start();
                Thread.Sleep(100);
                runner.QueryRefreshTimerTick(null);
            }

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void SchedulerRunnerFakeDisabledTest()
        {
            var mocks = new Mockery();

            SchedulerConfigurationSection configuration = GetConfiguration(true);
            configuration.SchedulerEnabled = false;
            var configStrategy = mocks.NewMock<ISchedulerConfigurationStrategy>();
            Expect.Once.On(configStrategy).Method("GetConfigurationSection").Will(Return.Value(configuration));
            Expect.Once.On(configStrategy).Method("GetServiceDisplayName").Will(Return.Value("service name"));

            Container c = new Container();
            c.Configure(r => { r.For<ISchedulerConfigurationStrategy>().Use(configStrategy); });
            using (var runner = c.GetInstance<SchedulerRunner>())
            {
                runner.Start();
                Thread.Sleep(50);
                runner.QueryRefreshTimerTick(null);
            }

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void SchedulerRunnerDbTickTest()
        {
            InitDb();
            using (var runner = m_Container.GetInstance<SchedulerRunner>())
            {
                Thread.Sleep(50);
                runner.QueryRefreshTimerTick(null);
            }
        }

        [TestMethod]
        public void SchedulerRunnerDbStartAndDisposeTest()
        {
            InitDb();
            using (var runner = m_Container.GetInstance<SchedulerRunner>())
            {
                runner.Start();
            }
        }

        [TestMethod]
        public void SchedulerRunnerDbStartAndWaitTest()
        {
            InitDb();
            using (var runner = m_Container.GetInstance<SchedulerRunner>())
            {
                runner.Start();
                Thread.Sleep(50);
            }
        }

        [TestMethod]
        public void SchedulerRunnerDbStartAndWaitWithDelayBetweenTasksTest()
        {
            InitDb();
            SchedulerConfigurationSection configuration = GetConfiguration(true);
            configuration.SecondsBetweenSchedulerTasks = 60;
            var languages = new List<string> {"en", "ru"};

            var mocks = new Mockery();
            var configStrategy = mocks.NewMock<ISchedulerConfigurationStrategy>();
            Expect.Once.On(configStrategy).Method("GetAVRFacade").Will(Return.Value(new AVRFacade(m_Container)));
            Expect.Once.On(configStrategy).Method("GetConfigurationSection").Will(Return.Value(configuration));
            Expect.Once.On(configStrategy).Method("GetLanguages").Will(Return.Value(languages));
            Expect.Once.On(configStrategy).Method("GetServiceDisplayName").Will(Return.Value("service name"));

            Container c = new Container();
            c.Configure(r => { r.For<ISchedulerConfigurationStrategy>().Use(configStrategy); });

            using (var runner = c.GetInstance<SchedulerRunner>())
            {
                runner.Start();
                Thread.Sleep(200);
            }
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private static void InitDb()
        {
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "AvrService").ConnectionString, DatabaseType.Avr);
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
        }

        private static SchedulerConfigurationSection GetConfiguration(bool immediatelyRunSchedulerWhenServiceStarts)
        {
            var configuration = new SchedulerConfigurationSection
            {
                TimeOfSchedulerRuns = new TimeSpan(0, 0, 0, 0),
                ImmediatelyRunScheduler = immediatelyRunSchedulerWhenServiceStarts,
                SecondsBetweenSchedulerTasks = 0,
            };
            return configuration;
        }
    }
}