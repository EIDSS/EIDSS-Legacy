using bv.common.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace bv.tests
{
    
    
    /// <summary>
    ///This is a test class for UserConfigWriterTest and is intended
    ///to contain all UserConfigWriterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserConfigWriterTest
    {


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
        ///A test for UserConfigWriter Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("bv.common.dll")]
        public void UserConfigWriteTest()
        {
            UserConfigWriter.m_TestUserConfigName = Path.GetTempPath() + "user.config";
            AppConfigWriter.m_TestAppConfigName = Path.GetTempPath() + "app.config";
            if (File.Exists(UserConfigWriter.m_TestUserConfigName))
                File.Delete(UserConfigWriter.m_TestUserConfigName );
            ConfigWriter config = new ConfigWriter();
            config.Read(UserConfigWriter.m_TestUserConfigName);
            Assert.AreEqual("", config.GetItem("PromtReasonForChange"));
            //UserConfigWriter.Instance.SetItem("PromtReasonForChange", "true");
            //UserConfigWriter.Instance.SetItem("SomeItem", "true");
            //UserConfigWriter.Instance.Save();
            //config.Read(UserConfigWriter.m_TestUserConfigName);
            //Assert.AreEqual("true", config.GetItem("PromtReasonForChange"));
            //Assert.AreEqual("", config.GetItem("SomeItem"));
            var target = UserConfigWriter.CreateConfigWriter();
            target.SetItem("PromtReasonForChange", "false");
            target.SetItem("SomeItem", "false");
            target.Save();
            config.Read(UserConfigWriter.m_TestUserConfigName);
            Assert.AreEqual("false", config.GetItem("PromtReasonForChange"));
            Assert.AreEqual("", config.GetItem("SomeItem"));
        }

    }
}
