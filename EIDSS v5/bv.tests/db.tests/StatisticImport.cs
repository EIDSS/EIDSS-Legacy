using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Import;
using bv.tests.Core;
using bv.model.BLToolkit;
using eidss.model.Core;
using bv.common.Configuration;
namespace bv.tests.db.tests
{
    [TestClass]
    public class StatisticImport
    {
        [TestMethod]
        public void StatisticImportTest()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            EidssUserContext.Init();
            using (var context = EidssUserContext.Instance)
            {
                StatisticHelper helper = new StatisticHelper();
                int result = helper.Import(PathToTestFolder.Get(TestFolders.Db) + "Data\\StatisticData_Errors.csv", false);
                Assert.AreEqual(0, result);
                //Assert.AreEqual(4, helper.RowsAffected);
                Assert.AreEqual(10, helper.Errors.Count);
                Assert.AreEqual("errMissingField", helper.Errors[0].MessageID);
                Assert.AreEqual(0, helper.Errors[0].LineNumber);
                Assert.AreEqual("errInvalidStatisticType", helper.Errors[1].MessageID);
                Assert.AreEqual(1, helper.Errors[1].LineNumber);
                Assert.AreEqual("errInvalidStatisticValue", helper.Errors[2].MessageID);
                Assert.AreEqual(2, helper.Errors[2].LineNumber);
                Assert.AreEqual("errInvalidDateFormat", helper.Errors[3].MessageID);
                Assert.AreEqual(3, helper.Errors[3].LineNumber);
                Assert.AreEqual("errInvalidYearStartDate", helper.Errors[4].MessageID);
                Assert.AreEqual(4, helper.Errors[4].LineNumber);
                Assert.AreEqual("errInvalidCountry", helper.Errors[5].MessageID);
                Assert.AreEqual(5, helper.Errors[5].LineNumber);
                Assert.AreEqual("errInvalidRegion", helper.Errors[6].MessageID);
                Assert.AreEqual(6, helper.Errors[6].LineNumber);
                Assert.AreEqual("errInvalidRayon", helper.Errors[7].MessageID);
                Assert.AreEqual(7, helper.Errors[7].LineNumber);
                Assert.AreEqual("errInvalidParameter", helper.Errors[8].MessageID);
                Assert.AreEqual(8, helper.Errors[8].LineNumber);
                Assert.AreEqual("errMalFormedCvs", helper.Errors[9].MessageID);
                Assert.AreEqual(9, helper.Errors[9].LineNumber);
                Assert.IsTrue(helper.RowsAffected<=3);

                result = helper.Import(PathToTestFolder.Get(TestFolders.Db) + "Data\\StatisticData_BadHeader.csv", false);
                Assert.AreEqual(-1, result);
                Assert.AreEqual(1, helper.Errors.Count);
                Assert.AreEqual("errStatisticImportFieldsQty", helper.Errors[0].MessageID);
                Assert.AreEqual(-1, helper.Errors[0].LineNumber);

                result = helper.Import(PathToTestFolder.Get(TestFolders.Db) + "Data\\StatisticData_BadHeader1.csv", false);
                Assert.AreEqual(-1, result);
                Assert.AreEqual(1, helper.Errors.Count);
                Assert.AreEqual("errStatisticImportFieldsQty", helper.Errors[0].MessageID);
                Assert.AreEqual(-1, helper.Errors[0].LineNumber);

                result = helper.Import(PathToTestFolder.Get(TestFolders.Db) + "Data\\StatisticData_Good.csv", false);
                Assert.AreEqual(0, result);
                Assert.AreEqual(9, helper.Errors.Count);
                Assert.AreEqual("errMissingField", helper.Errors[0].MessageID);
                Assert.AreEqual(0, helper.Errors[0].LineNumber);
                Assert.AreEqual("errInvalidStatisticType", helper.Errors[1].MessageID);
                Assert.AreEqual(1, helper.Errors[1].LineNumber);
                Assert.AreEqual("errInvalidStatisticValue", helper.Errors[2].MessageID);
                Assert.AreEqual(2, helper.Errors[2].LineNumber);
                Assert.AreEqual("errInvalidDateFormat", helper.Errors[3].MessageID);
                Assert.AreEqual(3, helper.Errors[3].LineNumber);
                Assert.AreEqual("errInvalidYearStartDate", helper.Errors[4].MessageID);
                Assert.AreEqual(4, helper.Errors[4].LineNumber);
                Assert.AreEqual("errInvalidCountry", helper.Errors[5].MessageID);
                Assert.AreEqual(5, helper.Errors[5].LineNumber);
                Assert.AreEqual("errInvalidRegion", helper.Errors[6].MessageID);
                Assert.AreEqual(6, helper.Errors[6].LineNumber);
                Assert.AreEqual("errInvalidRayon", helper.Errors[7].MessageID);
                Assert.AreEqual(7, helper.Errors[7].LineNumber);
                Assert.AreEqual("errInvalidParameter", helper.Errors[8].MessageID);
                Assert.AreEqual(8, helper.Errors[8].LineNumber);
                Assert.IsTrue(helper.RowsAffected <=3);


            }
        }
    }
}
