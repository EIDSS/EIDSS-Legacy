using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.model.BLToolkit;
using bv.common.Configuration;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Schema;
using eidss.model.Enums;

namespace bv.tests.db.tests
{
    /// <summary>
    /// Summary description for ASSessionTest
    /// </summary>
    [TestClass]
    public class ASSessionTest
    {
        public ASSessionTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AsSessionSample()
        {
              DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
              using (var context = ModelUserContext.Instance as EidssUserContext)
              {
                  using (var manager = DbManagerFactory.Factory.Create(context))
                  {
                      var acc = AsSession.Accessor.Instance(null);

                      var session = (AsSession)acc.CreateNew(manager);
                      //mandatory field
                      session.Region = session.RegionLookup.FirstOrDefault();

                      var rootFarm = FarmRootPanel.Accessor.Instance(null).CreateNewT(manager);


                      
                  }
              }
        }
    }
}
