using System.Collections.Generic;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.tests.Core;
using EIDSS;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace bv.tests.common
{
    [TestClass]
    public class BaseReportTests : EidssEnvWithLogin
    {
        public const string Organizaton = "NCDC&PH";
        public const string Admin = "test_admin";
        public const string User = "test_user";
        public const string AdminPassword = "test";
        public const string UserPassword = "test";

        protected static IContainer m_Container;

        /// <summary>
        ///     Gets or sets the test context which provides information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        public static long QueryId
        {
            get { return 49539640000000; }
        }

        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { });
            return c;
        }

        [TestInitialize]
        public override void MyTestInitialize()
        {
            m_Container = StructureMapContainerInit();
            EIDSS_LookupCacheHelper.Init();
            InitSupportedLanguages();
            base.MyTestInitialize();
        }

        public static void LoadAssemblies()
        {
            ClassLoader.Init("bv_common.dll", null);
            ClassLoader.Init("bvwin_common.dll", null);
            ClassLoader.Init("bv.common.dll", null);
            ClassLoader.Init("bv.winclient.dll", null);
            ClassLoader.Init("eidss*.dll", null);
        }

        public static void InitDBAndLogin()
        {
            InitSupportedLanguages();
            EIDSS_LookupCacheHelper.Init();
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            var target = new EidssSecurityManager();
            int result = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, result);
        }

        public static void InitSupportedLanguages()
        {
            Localizer.MenuMessages = EidssMenu.Instance;
            foreach (KeyValuePair<string, string> pair in Localizer.AllSupportedLanguages)
            {
                if (!Localizer.SupportedLanguages.ContainsKey(pair.Key))
                {
                    Localizer.SupportedLanguages.Add(pair.Key, pair.Value);
                }
            }
        }
    }
}