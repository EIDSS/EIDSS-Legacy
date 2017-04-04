using System;
using System.Data;
using BLToolkit.Data;
using bv.common.Configuration;
using bv.common.db.Core;
using bv.model.BLToolkit;
using EIDSS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class AvrMissedValuesLookupTest
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            EIDSS_LookupCacheHelper.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
        }

        [TestMethod]
        public void MissedValuesLookupTests()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                DbManager command = manager.SetCommand(
                    @"select 
		sf.idfsSearchField, 
		br.strDefault,
		sf.strSearchFieldAlias,
		sf.strLookupTable,
		sf.strLookupAttribute
		  
from	tasSearchField sf
inner join trtBaseReference br
	on sf.idfsSearchFieldType = br.idfsBaseReference
	and br.idfsReferenceType = 19000081
	and sf.blnAllowMissedReferenceValues = 1
	and  sf.idfsSearchFieldType <> 10081002"
                    );

                DataTable searchFields = command.ExecuteDataTable();
                Assert.AreEqual(0, searchFields.Select("strLookupTable is NULL").Length, "Not all search fields have strLookupTable");
                Assert.AreEqual(0, searchFields.Select("strLookupAttribute is NULL").Length, "Not all search fields have strLookupAttribute");
                foreach (DataRow row in searchFields.Rows)
                {
                    object tableNameObj = row["strLookupTable"];
                    object columnNameObj = row["strLookupAttribute"];
                    if (tableNameObj != DBNull.Value && columnNameObj != DBNull.Value)
                    {
                        string tableName = tableNameObj.ToString();
                        string columnName = columnNameObj.ToString();
                        DataView lookup = LookupCache.Get(tableName);
                        Assert.IsNotNull(lookup, string.Format("Could not load lookup '{0}'", tableName));

                        //if (!lookup.Table.Columns.Contains(columnName) && columnName == "strRegionExtendedName")
                        //{
                        //    columnName = "strExtendedRegionName";
                        //}
                        Assert.IsTrue(lookup.Table.Columns.Contains(columnName),
                            string.Format("Could not find attribute '{0}' in lookup '{1}'", columnName, tableName));
                    }
                }
            }
        }
    }
}