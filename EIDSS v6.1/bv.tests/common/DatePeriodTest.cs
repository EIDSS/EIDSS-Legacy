using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Core;
using System.Globalization;
using bv.model.BLToolkit;
using bv.common.db.Core;
using bv.common.Configuration;

namespace bv.tests.common
{
    [TestClass]
    public class DatePeriodTest// : EidssEnvWithLogin
    {
        [TestMethod]
        public void TestInitial()
        {
            Assert.AreEqual(DayOfWeek.Monday, EidssSiteContext.Instance.FirstDayOfWeek);
            Assert.AreEqual(CalendarWeekRule.FirstFourDayWeek, EidssSiteContext.Instance.WeekRule);

            Assert.AreEqual(new DateTime(2008, 12, 29), DatePeriodHelper.GetFirstWeekOfYear(2009));
            Assert.AreEqual(new DateTime(2010, 1, 4), DatePeriodHelper.GetFirstWeekOfYear(2010));
            Assert.AreEqual(new DateTime(2011, 1, 3), DatePeriodHelper.GetFirstWeekOfYear(2011));
            Assert.AreEqual(new DateTime(2012, 1, 2), DatePeriodHelper.GetFirstWeekOfYear(2012));
            Assert.AreEqual(new DateTime(2012, 12, 31), DatePeriodHelper.GetFirstWeekOfYear(2013));
            Assert.AreEqual(new DateTime(2013, 12, 30), DatePeriodHelper.GetFirstWeekOfYear(2014));

            Assert.AreEqual(52, DatePeriodHelper.GetWeekOfYear(new DateTime(2012, 12, 30)));
            Assert.AreEqual(1, DatePeriodHelper.GetWeekOfYear(new DateTime(2013, 12, 30)));
            Assert.AreEqual(3, DatePeriodHelper.GetWeekOfYear(new DateTime(2014, 1, 17)));
            Assert.AreEqual(52, DatePeriodHelper.GetWeekOfYear(new DateTime(2006, 1, 1)));
            Assert.AreEqual(1, DatePeriodHelper.GetWeekOfYear(new DateTime(2008, 1, 1)));
            Assert.AreEqual(1, DatePeriodHelper.GetWeekOfYear(new DateTime(2009, 1, 1)));
            Assert.AreEqual(53, DatePeriodHelper.GetWeekOfYear(new DateTime(2010, 1, 1)));
            Assert.AreEqual(52, DatePeriodHelper.GetWeekOfYear(new DateTime(2011, 1, 1)));

            var list = DatePeriodHelper.GetWeeksList(2007);
            Assert.AreEqual(52, list.Count);
        }

        [TestMethod]
        public void TestCompareSQLtoCS()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            ConnectionManager.DefaultInstance.SetCredentials(Config.GetSetting("EidssConnectionString"));

            EidssUserContext.Init();
            using (var manager = DbManagerFactory.Factory.Create())
            {
                for (int year = 1900; year <= 2050; year++)
                {
                    for (int day = 24; day <= 31; day++)
                    {
                        DateTime dt = new DateTime(year, 12, day);
                        Assert.AreEqual(DatePeriodHelper.GetWeekOfYear(dt), manager.SetCommand("SET DATEFIRST 1; select dbo.fnWeekDatepart('" + dt.ToString("yyyyMMdd") + "')").ExecuteScalar());
                    }
                    for (int day = 1; day <= 7; day++)
                    {
                        DateTime dt = new DateTime(year, 1, day);
                        Assert.AreEqual(DatePeriodHelper.GetWeekOfYear(dt), manager.SetCommand("SET DATEFIRST 1; select dbo.fnWeekDatepart('" + dt.ToString("yyyyMMdd") + "')").ExecuteScalar());
                    }
                }
            }
        }
    }
}
