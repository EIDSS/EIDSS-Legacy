using System.Data;
using bv.common.Configuration;
using bv.common.db.Core;
using bv.model.BLToolkit;
using bv.tests.common;
using EIDSS;
using eidss.avr.LayoutForm;
using eidss.model.Trace;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class VirtualLayoutCopierTests
    {
        private static Container m_Container;

        
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
            m_Container = StructureMapContainerInit();

            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "AvrService").ConnectionString, DatabaseType.Avr);
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));

            BaseReportTests.InitDBAndLogin();
        }

        [TestMethod]
        public void VirtualLayoutConstructorTest()
        {
            for (int i = 0; i < 30; i++)
            {
                using (new StopwathTransaction("++ VirtualPivot  - Construictor ++ " + i))
                {
                    using (new VirtualLayoutCopier(m_Container))
                    {
                    }
                }
            }
        }

        [TestMethod]
        public void VirtualLayoutCopyWithLangTest()
        {
            long layoutId = GetFirstlayoutId();
            if (layoutId > 0)
            {
                using (new StopwathTransaction("++ Copy layout on russian" + layoutId))
                {
                    VirtualLayoutCopier.CreateLayoutCopyInAvrService(layoutId, "ru", m_Container);
                }
            }
        }

        [TestMethod]
        public void VirtualLayoutCopyWithTraceTest()
        {
            long layoutId = GetFirstlayoutId();
            if (layoutId > 0)
            {
                m_Container.Configure(r => { r.For<ITraceStrategy>().Use<EmptyTraceStrategy>(); }); 
                using (new StopwathTransaction("++ Copy layout with no trace " + layoutId))
                {
                    VirtualLayoutCopier.CreateLayoutCopy(layoutId, m_Container);
                }
                m_Container.Configure(r => { r.For<ITraceStrategy>().Use<EidssTraceStrategy>(); }); 
                using (new StopwathTransaction("++ Copy layout with EIDSS trace " + layoutId))
                {
                    VirtualLayoutCopier.CreateLayoutCopy(layoutId, m_Container);
                }
                m_Container.Configure(r => { r.For<ITraceStrategy>().Use<TraceHelper>(); }); 
                using (new StopwathTransaction("++ Copy layout with AVR Service trace " + layoutId))
                {
                    VirtualLayoutCopier.CreateLayoutCopy(layoutId, m_Container);
                }
            }
        }

        public static long GetFirstlayoutId()
        {
            DataView layoutLookup = LookupCache.Get(LookupTables.Layout);
            layoutLookup.Sort = "idflLayout";
            return layoutLookup.Count > 0
                ? (long) layoutLookup[0]["idflLayout"]
                : -1;
        }
    }
}