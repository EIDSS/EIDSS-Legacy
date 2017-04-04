using bv.common.Configuration;
using bv.model.BLToolkit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.model.Model.Core;
using eidss.model.Schema;
using System.Linq;

namespace bv.tests.WebClient.FlexForms
{
    
    
    /// <summary>
    ///This is a test class for FFRenderModelTest and is intended
    ///to contain all FFRenderModelTest Unit Tests
    ///</summary>
    [TestClass]
    public class FFRenderModelTest
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
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            //TODO правильно получать настройки
            //DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
        }
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
        /// 
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <returns></returns>
        private Template GetTemplate(long idfsFormTemplate)
        {
            Template result;
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var acc = Template.Accessor.Instance(null);
                result = acc.SelectList(manager, idfsFormTemplate, null).FirstOrDefault();
            }

            return result;
        }

        //[TestMethod]
        //public void SetTemplateTest()
        //{
        //    DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
        //    var target = new FFPresenterModel();
        //    target.SetTemplate(GetTemplate(979560000000));
        //    Assert.IsNotNull(target.TemplateFlexNode);
        //}

        ///// <summary>
        /////A test for SetTemplate
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        //[TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("C:\\Projects\\EIDSS4\\bv.webclient", "/")]
        //[UrlToTest("http://localhost:16435/")]
        //public void SetTemplateTest()
        //{
        //    FFRenderModel target = new FFRenderModel(); // TODO: Initialize to an appropriate value
        //    Template template = null; // TODO: Initialize to an appropriate value
        //    target.SetTemplate(template);
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}
    }
}
