using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.tests.Schema;
using bv.winclient.BasePanel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.WinClient
{
    /// <summary>
    ///This is a test class for BaseDetailPanelTest and is intended
    ///to contain all BaseDetailPanelTest Unit Tests
    ///</summary>
    [TestClass]
    public class BaseListPanelTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        //Use TestInitialize to run code before running each test
        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString"));
        }

        #endregion

        [TestMethod]
        public void DataTest()
        {
            var panel = new BaseListPanel<ListPanelItem>();
            Assert.AreEqual(0, panel.DataSource.Count);
            panel.Refresh();
            Assert.AreEqual(100, panel.DataSource.Count);
        }

        [TestMethod]
        public void FocusTest()
        {
            var panel = new BaseListPanel<ListPanelItem>();
            panel.FocusedItemChanged += ((o, e) =>
                                         {
                                             Assert.IsNotNull(e.FocusedItem);
                                             Assert.AreEqual("Lookup2Value99",
                                                             ((ListPanelItem) e.FocusedItem).Lookup2Field1);
                                         });

            panel.SelectedItemsChanged += ((o, e) =>
                                           {
                                               Assert.AreEqual(1, e.SelectedItems.Count);
                                               Assert.AreEqual("Lookup2Value99",
                                                               ((ListPanelItem) e.SelectedItems[0]).Lookup2Field1);
                                           });
            panel.Refresh();
        }

        [TestMethod]
        public void SearchPanelTest()
        {
            var listPanel = new FakeListPanel();
            listPanel.Refresh();
            Assert.AreEqual(100, listPanel.DataSource.Count);

            Assert.IsTrue(listPanel.SearchPanel is FakeSearchPanel);
            var fakeSearchPanel = ((FakeSearchPanel) listPanel.SearchPanel);
            fakeSearchPanel.Parameters = CetTestFilters();
            fakeSearchPanel.RaiseTestSearch();
            Assert.AreEqual(40, listPanel.DataSource.Count);
        }

        public static FilterParams CetTestFilters()
        {
            var ret = new FilterParams();
            ret.Add("par11", "like", "%Value%");
            ret.Add("par21", ">=", 2);
            ret.Add("par22", "<=", 5);
            return ret;
        }
    }
}