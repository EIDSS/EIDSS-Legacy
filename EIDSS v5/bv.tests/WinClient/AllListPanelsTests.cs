using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Configuration;
using bv.tests.common;
using bv.tests.Core;
using eidss.winclient.ActiveSurveillance;
using eidss.winclient.Administration;
using eidss.winclient.AggregateCase;
using eidss.winclient.Audit;
using eidss.winclient.Human;
using eidss.winclient.Lab;
using eidss.winclient.Outbreaks;
using eidss.winclient.RepositorySchemes;
using eidss.winclient.Security;
using eidss.winclient.VectorSurveillance;
using eidss.winclient.Vet;

namespace bv.tests.WinClient
{
    [TestClass]
    public class AllListPanelsTests : EidssEnvWithLogin
    {
        private bool m_IgnoreTopMaxCount;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            m_IgnoreTopMaxCount = BaseSettings.IgnoreTopMaxCount;
            Config.Settings["IgnoreTopMaxCount"] = "true";
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
            Config.Settings["IgnoreTopMaxCount"] = m_IgnoreTopMaxCount.ToString();
        }

        [TestMethod]
        public void AsCampaignListPanelTest()
        {
            var panel = new AsCampaignListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void AsSessionListPanelTest()
        {
            var panel = new AsSessionListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void BatchListPanelTest()
        {
            var panel = new BatchListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void DataAuditListPanelTest()
        {
            var panel = new DataAuditListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void EventLogListPanelTest()
        {
            var panel = new EventLogListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void FarmListPanelTest()
        {
            var panel = new FarmListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void HumanCaseListPanelTest()
        {
            var panel = new HumanCaseListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void TestListPanelTest()
        {
            var panel = new TestListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void NextNumbersListPanelTest()
        {
            var panel = new NextNumbersListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void OutbreakListPanelTest()
        {
            var panel = new OutbreakListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void PatientListPanelTest()
        {
            var panel = new PatientListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void OrganizationListPanelTest()
        {
            var panel = new OrganizationListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void PersonListPanelTest()
        {
            var panel = new PersonListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void RepositorySchemeListPanelTest()
        {
            var panel = new RepositorySchemeListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void SampleDispositionListPanelTest()
        {
            var panel = new SampleDispositionListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void SampleListPanelTest()
        {
            var panel = new SampleListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void SampleTransferListPanelTest()
        {
            var panel = new SampleTransferListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void SecurityEventLogListPanelTest()
        {
            var panel = new SecurityEventLogListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void SettlementListPanelTest()
        {
            var panel = new SettlementListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void SiteListPanelTest()
        {
            var panel = new SiteListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void UserGroupListPanelTest()
        {
            var panel = new UserGroupListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void VetCaseListPanelTest()
        {
            var panel = new VetCaseListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void VsSessionListPanelTest()
        {
            var panel = new VsSessionListPanel();
            panel.LoadData();
        }

        [TestMethod]
        public void HumanAggregateCaseListTest()
        {
            var panel = new HumanAggregateCaseList();
            panel.LoadData();
        }

        [TestMethod]
        public void VetAggregateCaseListTest()
        {
            var panel = new VetAggregateCaseList();
            panel.LoadData();
        }

        [TestMethod]
        public void VetAggregateActionListTest()
        {
            var panel = new VetAggregateActionList();
            panel.LoadData();
        }

        [TestMethod]
        public void StatisticListPanelTest()
        {
            var panel = new StatisticListPanel();
            panel.LoadData();
        }
    }
}
