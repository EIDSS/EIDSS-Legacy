using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Configuration;

namespace bv.tests
{
    /// <summary>
    ///This is a test class for AppConfigWriterTest and is intended
    ///to contain all AppConfigWriterTest Unit Tests
    ///</summary>
    [TestClass]
    public class AppConfigWriterTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

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
        ///A test for AppConfigWriter Constructor
        ///</summary>
        [TestMethod]
        public void AppConfigWriteTest()
        {
            UserConfigWriter.m_TestUserConfigName = Path.GetTempPath() + "user_v6.config";
            AppConfigWriter.m_TestAppConfigName = Path.GetTempPath() + "app_v6.config";
            if (File.Exists(AppConfigWriter.m_TestAppConfigName))
            {
                File.Delete(AppConfigWriter.m_TestAppConfigName);
            }
            var config = new ConfigWriter();
            config.Read(AppConfigWriter.m_TestAppConfigName);
            Assert.AreEqual("", config.GetItem("DocumentPrinter"));
            string expected = "test printer";
            //Assert.AreEqual(AppConfigWriter.Instance.FileName, AppConfigWriter.m_TestAppConfigName);
            //AppConfigWriter.Instance.SetItem("DocumentPrinter", expected);
            //AppConfigWriter.Instance.SetItem("SomeItem", "true");
            //AppConfigWriter.Instance.Save();
            //config.Read(AppConfigWriter.m_TestAppConfigName);
            //Assert.AreEqual(expected, config.GetItem("DocumentPrinter"));
            //Assert.AreEqual("", config.GetItem("SomeItem"));
            ConfigWriter target = AppConfigWriter.CreateConfigWriter();
            target.SetItem("DocumentPrinter", expected);
            target.SetItem("SomeItem", "false");
            target.Save();
            config.Read(AppConfigWriter.m_TestAppConfigName);
            Assert.AreEqual(expected, config.GetItem("DocumentPrinter"));
            Assert.AreEqual("", config.GetItem("SomeItem"));
        }
    }
}
