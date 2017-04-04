using System;
using System.Data;
using NUnit.Framework;

namespace EIDSS.Tests.Admin
{
    [TestFixture]
    public class AdminDbTests
    {
        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }

        [Test]
        public void StatisticExists_Test()
        {
            Statistic_DB service = new Statistic_DB();
            DataSet ds = service.GetDetail(null);
            Assert.AreEqual(false, service.StatisticExists(ds.Tables[0].Rows[0]));
        }
    }
}