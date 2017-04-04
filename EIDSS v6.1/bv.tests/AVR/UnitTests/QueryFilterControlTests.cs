using System;
using System.Data;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Enums;
using bv.common.db.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using DevExpress.Data.Filtering;
using EIDSS;
using eidss.avr.db.DBService.QueryBuilder;
using eidss.avr.FilterForm;
using eidss.avr.QueryBuilder;
using eidss.model.Core;
using eidss.model.Core.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class QueryFilterControlTests
    {
        private const long QueryId = 49540070000000;
        private const long HumanCaseIdField = 49540120000000;
        private const long TestNameIdValue = 6618590000000;
        private const long SubQuerySearchObjectId = -10001L;
        private const long SubQuerySearchFieldIdSeed = -100000L;
        private const string StrValue1 = "AAA";
        private const string StrValue2 = "BBB";
        private const string CaseIDAlias = "sflHC_CaseID";
        private const string TestNameAlias = "sflHCTest_TestType_10082008";
        private const string Organizaton = "NCDC&PH";
        private const string Admin = "test_admin";
        private const string AdminPassword = "test";
        private EidssSecurityManager m_Security;
        public ModelUserContext context { get; protected set; }

        [TestInitialize]
        public void TestInitialize()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            ConnectionManager.DefaultInstance.SetCredentials(Config.GetSetting("EidssConnectionString"));
            EidssUserContext.Init();
            context = ModelUserContext.Instance as EidssUserContext;
            m_Security = new EidssSecurityManager();
            int result = m_Security.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, result);
            EIDSS_LookupCacheHelper.Init();
            //while(!LookupCache.Filled)
            //    Thread.Sleep(500);
            ModelUserContext.CurrentLanguage = "en";
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        //[Ignore]
        [TestMethod]
        public void QueryFilterFlashTest()
        {
            QueryFilterControl filter = CreateFilterControl();
            GroupOperator aggrGroup, rootGroup;
            CreateFilterCondition1(filter, out rootGroup, out aggrGroup);
            filter.Flush();
            DataTable searchCriteriaTable = filter.QueryDataset.Tables[QuerySearchObject_DB.TasQueryConditionGroup];
            Assert.AreEqual(6, searchCriteriaTable.Rows.Count);
            string filterText = filter.GetFilterText(filter.FilterCriteria, null, " ");
            CheckFilterCondition1(filter);
            var ds = filter.QueryDataset;
            filter = CreateFilterControl();
            filter.Bind((long)ds.Tables[1].Rows[0]["idfQuerySearchObject"], ds);
            filter.Flush();
            CheckFilterCondition1(filter);

            filter = CreateFilterControl();
            CreateFilterCondition2(filter, ref rootGroup, ref aggrGroup);
            filter.Flush();

            searchCriteriaTable = filter.QueryDataset.Tables[QuerySearchObject_DB.TasQueryConditionGroup];
            Assert.AreEqual(7, searchCriteriaTable.Rows.Count);
            CheckFilterCondition2(filter);
            ds = filter.QueryDataset;
            filter = CreateFilterControl();
            filter.Bind((long)ds.Tables[1].Rows[0]["idfQuerySearchObject"], ds);
            filter.Flush();
            CheckFilterCondition2(filter);

            filter = CreateFilterControl();
            CreateFilterCondition3(filter, out rootGroup);
            filter.Flush();

            searchCriteriaTable = filter.QueryDataset.Tables[QuerySearchObject_DB.TasQueryConditionGroup];
            Assert.AreEqual(3, searchCriteriaTable.Rows.Count);
            CheckFilterCondition3(filter);
            ds = filter.QueryDataset;
            filter = CreateFilterControl();
            filter.Bind((long)ds.Tables[1].Rows[0]["idfQuerySearchObject"], ds);
            filter.Flush();
            CheckFilterCondition3(filter);
        }

        //[Ignore]
        [TestMethod]
        public void QueryFilterRefreshTest()
        {
            QueryFilterControl filter = CreateFilterControl();
            GroupOperator aggrGroup, rootGroup;
            CreateFilterCondition1(filter, out rootGroup, out aggrGroup);
            DataTable searchCriteriaTable = filter.QueryDataset.Tables[QuerySearchObject_DB.TasQueryConditionGroup];
            filter.Flush();

            Assert.AreEqual(6, searchCriteriaTable.Rows.Count);
            var querySearchObjectId =
                (long)filter.QueryDataset.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfQuerySearchObject"];

            DataRow row = filter.QueryDataset.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows.Find(HumanCaseIdField);
            if (row != null)
            {
                row.Delete();
            }
            filter.RefreshNodes();
            Assert.AreEqual(4, searchCriteriaTable.Rows.Count);
            CheckConditionRow(searchCriteriaTable.Rows[0], -1L, DBNull.Value, querySearchObjectId, 0);
            CheckConditionRow(searchCriteriaTable.Rows[1], -2L, -1L, querySearchObjectId, 0, SubQuerySearchObjectId - 1, DBNull.Value, "Exists");
            CheckConditionRow(searchCriteriaTable.Rows[2], -3L, -2L, SubQuerySearchObjectId - 1, 0);
            CheckConditionRow(searchCriteriaTable.Rows[3], DBNull.Value, -3L, SubQuerySearchObjectId - 1, 0, DBNull.Value, SubQuerySearchFieldIdSeed - 1L, "Binary", 0, TestNameIdValue);
        }
        [Ignore]
        [TestMethod]
        public void QueryFilterPostLoadTest()
        {
            QueryFilterControl filter = CreateFilterControl();
            GroupOperator aggrGroup, rootGroup;
            CreateFilterCondition1(filter, out rootGroup, out aggrGroup);
            Post(filter);
            filter = CreateFilterControl();
            CheckFilterCondition1(filter);

        }

        private void Post(QueryFilterControl filter)
        {
            //var queryDb = new Query_DB();
            var querySearchObjectDb = new QuerySearchObject_DB();
            querySearchObjectDb.PostDetail(filter.QueryDataset, (int) PostType.FinalPosting, null);
        }

        private void CheckConditionRow
            (DataRow row, object idfQueryConditionGroup, object idfParentQueryConditionGroup, long idfQuerySearchObject,
                int intOrder, object idfSubQuerySearchObject = null, object idfQuerySearchField = null,
                object strOperator = null, object intOperatorType = null, object varValue = null, object blnFieldConditionUseNot = null,
                bool blnJoinByOr = false, bool blnUseNot = false)
        {
            if (idfSubQuerySearchObject == null)
            {
                idfSubQuerySearchObject = DBNull.Value;
            }
            if (idfQuerySearchField == null)
            {
                idfQuerySearchField = DBNull.Value;
            }
            if (strOperator == null)
            {
                strOperator = DBNull.Value;
            }
            if (intOperatorType == null)
            {
                intOperatorType = DBNull.Value;
            }
            if (varValue == null)
            {
                varValue = DBNull.Value;
            }
            if (blnFieldConditionUseNot == null)
            {
                blnFieldConditionUseNot = DBNull.Value;
            }

            Assert.AreEqual(idfQueryConditionGroup, row["idfQueryConditionGroup"]);
            Assert.AreEqual(idfParentQueryConditionGroup, row["idfParentQueryConditionGroup"]);
            Assert.AreEqual(idfQuerySearchObject, row["idfQuerySearchObject"]);
            Assert.AreEqual(intOrder, row["intOrder"]);
            Assert.AreEqual(blnJoinByOr, row["blnJoinByOr"]);
            Assert.AreEqual(blnUseNot, row["blnUseNot"]);
            Assert.AreEqual(idfSubQuerySearchObject, row["idfSubQuerySearchObject"]);
            Assert.AreEqual(idfQuerySearchField, row["idfQuerySearchField"]);
            Assert.AreEqual(strOperator, row["strOperator"]);
            Assert.AreEqual(intOperatorType, row["intOperatorType"]);
            Assert.AreEqual(varValue, row["varValue"]);
            Assert.AreEqual(blnFieldConditionUseNot, row["blnFieldConditionUseNot"]);
        }

        /*
         * AND
         *      Human Case ID = 'AAA'
         *      Human Case ID = 'BBB'
         *      Exists Human Case Test
         *          AND
         *              Human case Test Type = 6618590000000 ('Anaplasma test')
         */

        private void CreateFilterCondition1(QueryFilterControl filter, out GroupOperator rootGroup, out GroupOperator aggrGroup)
        {
            CriteriaOperator criteria;
            rootGroup = QueryFilterControl.AddGroupOperator(null, null, null, out criteria);
            QueryFilterControl.AddFieldOperator(rootGroup, CaseIDAlias, StrValue1, SearchOperator.Binary, BinaryOperatorType.Equal, false);
            QueryFilterControl.AddFieldOperator(rootGroup, CaseIDAlias, StrValue2, SearchOperator.Binary, BinaryOperatorType.Equal, false);
            AggregateOperand aggrOp = QueryFilterControl.AddAggregateOperand(rootGroup, "<Human Case Test>", false);
            CriteriaOperator aggrCriteria;
            aggrGroup = QueryFilterControl.AddGroupOperator(null, null, null, out aggrCriteria);
            QueryFilterControl.AddFieldOperator(aggrGroup, TestNameAlias, TestNameIdValue, SearchOperator.Binary, BinaryOperatorType.Equal,
                false);
            aggrOp.Condition = aggrCriteria;
            filter.FilterCriteria = criteria;
            filter.HasChanges = true;
        }
        private void CheckFilterCondition1(QueryFilterControl filter)
        {
            DataTable searchCriteriaTable = filter.QueryDataset.Tables[QuerySearchObject_DB.TasQueryConditionGroup];
            var querySearchObjectId =
                (long)filter.QueryDataset.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfQuerySearchObject"];
            //root AND
            CheckConditionRow(searchCriteriaTable.Rows[0], -1L, DBNull.Value, querySearchObjectId, 0);
            //Human Case ID = 'AAA'
            CheckConditionRow(searchCriteriaTable.Rows[1], DBNull.Value, -1L, querySearchObjectId, 0, DBNull.Value, HumanCaseIdField,
                "Binary", 0, StrValue1);
            //Human Case ID = 'BBB'
            CheckConditionRow(searchCriteriaTable.Rows[2], DBNull.Value, -1L, querySearchObjectId, 1, DBNull.Value, HumanCaseIdField,
                "Binary", 0, StrValue2);
            //Exists Human Case Test
            CheckConditionRow(searchCriteriaTable.Rows[3], -2L, -1L, querySearchObjectId, 2, SubQuerySearchObjectId, DBNull.Value, "Exists");
            //Child Human Case Test AND
            CheckConditionRow(searchCriteriaTable.Rows[4], -3L, -2L, SubQuerySearchObjectId, 0);
            //Human case Test Type = 6618590000000 ('Anaplasma test')
            CheckConditionRow(searchCriteriaTable.Rows[5], DBNull.Value, -3L, SubQuerySearchObjectId, 0, DBNull.Value, SubQuerySearchFieldIdSeed, "Binary", 0, TestNameIdValue);

        }
        /*
         * AND
         *      Human Case ID = 'AAA'
         *      Human Case ID = 'BBB'
         *      Exists Human Case Test
         *          AND
         *              Human case Test Type = 6618590000000 ('Anaplasma test')
         *              Human case Test Type <> 6618590000000 ('Anaplasma test')
         */

        private void CreateFilterCondition2(QueryFilterControl filter, ref GroupOperator rootGroup, ref GroupOperator aggrGroup)
        {
            CriteriaOperator criteria = filter.FilterCriteria;
            CreateFilterCondition1(filter, out rootGroup, out aggrGroup);
            QueryFilterControl.AddFieldOperator(aggrGroup, TestNameAlias, TestNameIdValue, SearchOperator.Binary, BinaryOperatorType.NotEqual,
                false);
            filter.FilterCriteria = rootGroup;
        }
        private void CheckFilterCondition2(QueryFilterControl filter)
        {

            DataTable searchCriteriaTable = filter.QueryDataset.Tables[QuerySearchObject_DB.TasQueryConditionGroup];
            CheckFilterCondition1(filter);
            //Human case Test Type = 6618590000000 ('Anaplasma test')
            CheckConditionRow(searchCriteriaTable.Rows[6], DBNull.Value, -3L, SubQuerySearchObjectId, 1, DBNull.Value, SubQuerySearchFieldIdSeed, "Binary", 1, TestNameIdValue);

        }

        /*
         * OR
         *      Human Case ID = 'AAA'
         *      Human Case ID = 'BBB'
         */

        private void CreateFilterCondition3(QueryFilterControl filter, out GroupOperator rootGroup)
        {
            CriteriaOperator criteria;
            rootGroup = QueryFilterControl.AddGroupOperator(null, null, null, out criteria);
            rootGroup.OperatorType = GroupOperatorType.Or;
            QueryFilterControl.AddFieldOperator(rootGroup, CaseIDAlias, StrValue1, SearchOperator.Binary, BinaryOperatorType.Equal, false);
            QueryFilterControl.AddFieldOperator(rootGroup, CaseIDAlias, StrValue2, SearchOperator.Binary, BinaryOperatorType.Equal, false);
            filter.FilterCriteria = criteria;
            filter.HasChanges = true;
        }
        private void CheckFilterCondition3(QueryFilterControl filter)
        {
            DataTable searchCriteriaTable = filter.QueryDataset.Tables[QuerySearchObject_DB.TasQueryConditionGroup];
            var querySearchObjectId =
                (long)filter.QueryDataset.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfQuerySearchObject"];
            //root OR
            CheckConditionRow(searchCriteriaTable.Rows[0], -1L, DBNull.Value, querySearchObjectId, 0, null, null, null, null, null, null, true);
            //Human Case ID = 'AAA'
            CheckConditionRow(searchCriteriaTable.Rows[1], DBNull.Value, -1L, querySearchObjectId, 0, DBNull.Value, HumanCaseIdField,
                "Binary", 0, StrValue1, null, true);
            //Human Case ID = 'BBB'
            CheckConditionRow(searchCriteriaTable.Rows[2], DBNull.Value, -1L, querySearchObjectId, 1, DBNull.Value, HumanCaseIdField,
                "Binary", 0, StrValue2, null, true);
        }

        private QueryFilterControl CreateFilterControl(string lang = "en")
        {
            var queryDb = new Query_DB();
            var querySearchObjectDb = new QuerySearchObject_DB();
            DataSet queryDs = queryDb.LoadDetailData(QueryId);
            DataRow row = queryDs.Tables[Query_DB.TasQueryObjectTree].Rows[0];
            DataSet searchObjectsDs = querySearchObjectDb.LoadDetailData(row["idfQuerySearchObject"]);

            var form = new Form();
            var filter = new QueryFilterControl { Parent = form, Dock = DockStyle.Fill };
            filter.Init();
            filter.Bind((long)queryDs.Tables[1].Rows[0]["idfQuerySearchObject"], searchObjectsDs);
            return filter;
        }
    }
}