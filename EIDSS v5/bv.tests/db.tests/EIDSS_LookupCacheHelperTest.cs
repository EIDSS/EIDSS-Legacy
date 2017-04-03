using System.Threading;
using EIDSS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using bv.common.Diagnostics;
using bv.common.db.Core;
using bv.tests.Core;

namespace bv.tests
{
    
    
    /// <summary>
    ///This is a test class for EIDSS_LookupCacheHelperTest and is intended
    ///to contain all EIDSS_LookupCacheHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EIDSS_LookupCacheHelperTest: EidssEnvWithLogin    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for correctness of lookup primary key
        ///It gets all lookup lists and shall throw exception if list contains incorrect PK value(null or duplicate)
        ///</summary>
        [TestMethod()]
        public void EIDSS_LookupCacheHelperPrimaryKeyTest()
        {
            EIDSS_LookupCacheHelper.Init();
            foreach(var val in Enum.GetNames(typeof(LookupTables)))
            {
                //for(int i = 0;i<100;i++)
                {
                    var view = LookupCache.Get(val);
                    //if (view == null)
                    //{
                    //    Thread.Sleep(100);
                    //    continue;
                    //}
                    Dbg.Debug("{0} records in table {1}", view.Count, val);
                    view.Table.DataSet.EnforceConstraints = false;
                    view.Table.DataSet.EnforceConstraints = true;
                    //break;

                }
            }
        }
    }
}
