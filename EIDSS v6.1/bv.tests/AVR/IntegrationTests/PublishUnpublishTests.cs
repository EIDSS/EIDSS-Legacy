using BLToolkit.Data;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.tests.common;
using eidss.avr;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.avr.LayoutForm;
using eidss.model.Avr.Commands.Models;
using eidss.model.Trace;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class PublishUnpublishTests
    {
        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { r.For<ITraceStrategy>().Use<TraceHelper>(); });

            return c;
        }
        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "AvrService").ConnectionString, DatabaseType.Avr);
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));

            BaseReportTests.InitDBAndLogin();
            ClassLoader.Init("eidss_common.dll", null);
            ClassLoader.Init("eidss_db.dll", null);
        }

        [TestMethod]
        public void PublishAndUnpublishTest()
        {
            long layoutId = VirtualLayoutCopierTests.GetFirstlayoutId();
            //   layoutId = 56295660000000;
            if (layoutId > 0)
            {
                var container = StructureMapContainerInit();
                long copiedId = VirtualLayoutCopier.CreateLayoutCopyInAvrService(layoutId,"ru", container);

                SharedModel model;
                using (PresenterFactory.BeginSharedPresenterTransaction(container,new EmptyPostableForm()))
                {
                    model = PresenterFactory.SharedPresenter.SharedModel;
                }
                using (var dbService = new WinLayout_DB(model))
                {
                    long publishedId;

                    using (new StopwathTransaction("++ Publish layout " + copiedId))
                    {
                        publishedId = dbService.PublishUnpublish(copiedId, true);
                    }
                    Assert.AreEqual(1, GetLayoutCount(publishedId));

                    using (new StopwathTransaction("++ UnPublish layout " + publishedId))
                    {
                        dbService.PublishUnpublish(copiedId, false);
                    }
                    Assert.AreEqual(0, GetLayoutCount(publishedId));
                }
            }
        }

        private static int GetLayoutCount(long publishedId)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                DbManager command = manager.SetCommand(
                    @" select COUNT(*) from tasglLayout where idfsLayout =  @idfsLayout",
                    manager.Parameter("idfsLayout", publishedId));

                var result = (int) command.ExecuteScalar();
                return result;
            }
        }
    }
}