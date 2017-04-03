using System;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.WinClient
{
    [TestClass]
    public class AllListCounttests
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
        }

        [TestMethod]
        public void ListCountTest()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                AssertCountFor(manager, typeof (AsSessionListItem));
                AssertCountFor(manager, typeof(AsSessionListItem));
                AssertCountFor(manager, typeof(HumanCaseListItem));
                AssertCountFor(manager, typeof(OutbreakListItem));
                AssertCountFor(manager, typeof(SettlementListItem));
                AssertCountFor(manager, typeof(VetCaseListItem));
                AssertCountFor(manager, typeof(StatisticListItem));
                AssertCountFor(manager, typeof(PersonListItem));
                AssertCountFor(manager, typeof(EventLogListItem));
                AssertCountFor(manager, typeof(FarmListItem));
                AssertCountFor(manager, typeof(LabBatchListItem));
                AssertCountFor(manager, typeof(DataAuditListItem));
                AssertCountFor(manager, typeof(NextNumbersListItem));
                AssertCountFor(manager, typeof(OrganizationListItem));
                AssertCountFor(manager, typeof(PatientListItem));
                AssertCountFor(manager, typeof(RepositorySchemeListItem));
                AssertCountFor(manager, typeof(UserGroupListItem));
                AssertCountFor(manager, typeof(SiteActivationServerListItem));
                AssertCountFor(manager, typeof(SecurityEventLogListItem));
                AssertCountFor(manager, typeof(LabSampleListItem));
                AssertCountFor(manager, typeof(LabSampleDispositionListItem));
                AssertCountFor(manager, typeof(LabSampleTransferListItem));
            }
        }

        private static void AssertCountFor(DbManagerProxy manager, Type type)
        {
            IObjectSelectList accessor = ObjectAccessor.SelectListInterface(type);
            long? totalCount = accessor.SelectCount(manager);
            Assert.IsNotNull(totalCount, string.Format("Type {0} hasn't Select Count procedure", type));
        }
    }
}