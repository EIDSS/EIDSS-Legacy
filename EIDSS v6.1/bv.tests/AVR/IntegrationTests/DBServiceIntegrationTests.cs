using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.win;
using bv.model.BLToolkit;
using bv.tests.common;
using eidss.avr;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.DataSource;
using eidss.model.Avr;
using eidss.model.Avr.Chart;
using eidss.model.Avr.Tree;
using eidss.model.Core;
using eidss.model.Core.CultureInfo;
using eidss.model.Core.Security;
using eidss.model.Schema;
using eidss.model.Trace;
using eidss.model.WindowsService.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class DBServiceIntegrationTests
    {
        #region SQL

        private const string GetQueryIdSQL =
            @"
    delete from [locStringNameTranslation] where [idflBaseReference] = 9999 
    delete from [tasLayoutFolder] where [idflQuery] = 9999
    delete from [tasLayout] where [idflQuery] = 9999
	delete from [tasQuery] where [idflQuery] = 9999
	delete from [locBaseReference] where [idflBaseReference] = 9999
	delete from [locBaseReference] where [idflBaseReference] = 9998
	
    INSERT INTO dbo.locBaseReference(idflBaseReference)
		 VALUES (9998)

    INSERT INTO dbo.locBaseReference(idflBaseReference)
		 VALUES (9999)
		 
	INSERT INTO [dbo].[tasQuery] ([idflQuery], [strFunctionName],[idflDescription] )
		 VALUES (9999, 'dbo.fnAggregateCaseList', 9998)

    INSERT INTO [dbo].[locStringNameTranslation] ([idflBaseReference], [idfsLanguage], [strTextString])
         VALUES (9999, 10049003, 'Query1')

    INSERT INTO [dbo].[locStringNameTranslation] ([idflBaseReference], [idfsLanguage], [strTextString])
         VALUES (9999, 10049006, 'Кверь1')

SELECT TOP 1 [idflQuery]	FROM	[dbo].[tasQuery] where idflQuery = 9999";

        private const string IsLayoutExistsSQL =
            @"SELECT	count(*) from tasLayout where idflLayout = @LayoutID";

        private const string DeleteQuerySQL = @"exec dbo.spAsQuery_Delete 9999 ";

        #endregion

        private static Layout_DB m_LayoutDB;
        private static BaseAvrDbService m_PivotDB;
        private static BaseAvrDbService m_ChartDB;
        private static long m_TestQueryId;
        private static TraceHelper m_Trace;
        private IDisposable m_PresenterTransaction;

        private readonly object m_SyncLock = new object();

        private static IContainer m_Container;


        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { });
            return c;
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            m_Container = StructureMapContainerInit();
            BaseReportTests.InitDBAndLogin();
            using (PresenterFactory.BeginSharedPresenterTransaction(m_Container, new BaseForm()))
            {
                m_LayoutDB = new WinLayout_DB(PresenterFactory.SharedPresenter.SharedModel);
            }
            lock (m_LayoutDB.Connection)
            {
                OpenConnection();
                using (var command = new SqlCommand(GetQueryIdSQL))
                {
                    command.Connection = (SqlConnection) m_LayoutDB.Connection;
                    m_TestQueryId = (long) command.ExecuteScalar();
                }
                CloseConnection();
            }

            m_PivotDB = new BaseAvrDbService();
            m_LayoutDB.AddLinkedDbService(m_PivotDB, null, RelatedPostOrder.SkipPost);

            m_ChartDB = new BaseAvrDbService();
            m_LayoutDB.AddLinkedDbService(m_ChartDB, null, RelatedPostOrder.SkipPost);

            LookupManager.AddObject("Query", null, AvrQueryLookup.Accessor.Instance(null).GetType(), "_SelectListInternal");
            LookupManager.AddObject("LayoutFolder", null, AvrFolderLookup.Accessor.Instance(null).GetType(), "_SelectListInternal");
            LookupManager.AddObject("Layout", null, AvrLayoutLookup.Accessor.Instance(null).GetType(), "_SelectListInternal");

            m_PresenterTransaction = PresenterFactory.BeginSharedPresenterTransaction(m_Container, new BaseForm());
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            m_PresenterTransaction.Dispose();

            try
            {
                lock (m_LayoutDB.Connection)
                {
                    OpenConnection();
                    using (var command = new SqlCommand(DeleteQuerySQL))
                    {
                        command.Connection = (SqlConnection) m_LayoutDB.Connection;
                        command.ExecuteNonQuery();
                    }
                    CloseConnection();
                }
                m_ChartDB.Dispose();
                m_PivotDB.Dispose();
                m_LayoutDB.Dispose();
                MemoryManager.Flush();
            }
            catch (Exception ex)
            {
                m_Trace.TraceError(ex);
            }
        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            m_Trace = new TraceHelper(TraceHelper.AVRCategory);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        #region Get Detail 

        [TestMethod]
        public void GetLayoutDetailTest()
        {
            lock (m_LayoutDB.Connection)
            {
                OpenConnection();
                DataSet dataSet = m_LayoutDB.GetDetail(-1);
                Assert.IsNotNull(dataSet);
                Assert.AreEqual(2, dataSet.Tables.Count);
                Assert.IsTrue(dataSet.Tables.Contains("Layout"));
                Assert.IsTrue(dataSet.Tables.Contains("LayoutSearchField"));
                Assert.IsTrue(dataSet is LayoutDetailDataSet, "Dataset has wrong type");
                var layoutDataSet = (LayoutDetailDataSet) dataSet;
                Assert.IsNotNull(layoutDataSet);

                CloseConnection();
            }
        }

        [TestMethod]
        public void GetLayoutInfoTest()
        {
            string layoutCountSQL =
                string.Format(@"select count (*) from tasLayout where idflQuery = {0}  and (idfPerson = {1}  or blnShareLayout=1)",
                    BaseReportTests.QueryId, (long) EidssUserContext.User.EmployeeID);
            string folderCountSQL = @"select count (*) from tasLayoutFolder where idflQuery = " + BaseReportTests.QueryId;
            lock (m_LayoutDB.Connection)
            {
                EidssUserContext.CheckUserLoggedIn();

                PresenterFactory.SharedPresenter.SharedModel.SelectedQueryId = BaseReportTests.QueryId;

                int layoutCount = GetCount(layoutCountSQL);
                int folderCount = GetCount(folderCountSQL);

                LookupManager.ClearAndReloadOnIdle();
                int actualLayoutCount = AvrQueryLayoutTreeDbHelper.LoadLayouts(false, BaseReportTests.QueryId).Count;
                Assert.AreEqual(layoutCount, actualLayoutCount);

                int actualFolderCount = AvrQueryLayoutTreeDbHelper.LoadFolders(false, BaseReportTests.QueryId).Count;
                Assert.AreEqual(folderCount, actualFolderCount);
            }
        }

        [TestMethod]
        public void GetQueriesInfoTest()
        {
            const string queryCountSQL = @"select count (*) from tasQuery where blnSubQuery = 0";
            lock (m_LayoutDB.Connection)
            {
                EidssUserContext.CheckUserLoggedIn();

                LookupManager.ClearByTable("Query");
                LookupManager.ClearAndReloadOnIdle();
                int queryCount = GetCount(queryCountSQL);
                int actualQueryCount = AvrQueryLayoutTreeDbHelper.ReLoadQueries().Count;
                Assert.AreEqual(queryCount, actualQueryCount);
            }
        }

        #endregion

        #region Get and post layout

        [TestMethod]
        public void CreateDeleteLayoutDetailTest()
        {
            lock (m_LayoutDB.Connection)
            {
                OpenConnection();

                long layoutId = CreateLayout();
                DeleteLayout(layoutId);
                CloseConnection();
            }
        }

        [TestMethod]
        public void UpdateLayoutDetailTest()
        {
            lock (m_LayoutDB.Connection)
            {
                OpenConnection();
                using (new CultureInfoTransaction(new CultureInfo("ru-RU")))
                {
                    long layoutId = CreateLayout();

                    var layoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
                    var row = (LayoutDetailDataSet.LayoutRow) layoutDetail.Layout.Rows[0];
                    m_LayoutDB.SetQueryID(m_TestQueryId);

                    Assert.IsFalse(row.blnApplyPivotGridFilter);
                    Assert.IsFalse(row.blnReadOnly);
                    Assert.IsFalse(row.blnShareLayout);
                    Assert.IsFalse(row.blnShowColGrandTotals);
                    Assert.IsFalse(row.blnShowColsTotals);
                    Assert.IsFalse(row.blnShowForSingleTotals);
                    Assert.IsFalse(row.blnShowRowGrandTotals);
                    Assert.IsFalse(row.blnShowRowsTotals);

                    Assert.AreEqual(layoutId, row.idflLayout);
                    Assert.AreEqual((long) DBGroupInterval.gitDateYear, row.idfsDefaultGroupDate);
                    Assert.AreEqual(EidssUserContext.User.EmployeeID, row.idfPerson);

                    row.blnApplyPivotGridFilter = true;
                    row.blnReadOnly = true;
                    row.blnShareLayout = true;
                    row.blnShowColGrandTotals = true;
                    row.blnShowColsTotals = true;
                    row.blnShowForSingleTotals = true;
                    row.blnShowRowGrandTotals = true;
                    row.blnShowRowsTotals = true;
                    row.idfsDefaultGroupDate = (long) DBGroupInterval.gitDateMonth;
                    row.strPivotGridSettings = string.Empty;
                    row.blbPivotGridSettings = BinaryCompressor.ZipString(row.strPivotGridSettings);
                    row.strDefaultLayoutName = "English name";
                    row.strLayoutName = "russian";
                    row.strDescription = "descr aaa";

                    UpdateLayout(layoutDetail);

                    var newLayoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
                    var newRow =
                        (LayoutDetailDataSet.LayoutRow) newLayoutDetail.Layout.Rows[0];

                    Assert.AreEqual(row.blnApplyPivotGridFilter, newRow.blnApplyPivotGridFilter);
                    Assert.AreEqual(row.blnReadOnly, newRow.blnReadOnly);
                    Assert.AreEqual(row.blnShareLayout, newRow.blnShareLayout);
                    Assert.AreEqual(row.blnShowColGrandTotals, newRow.blnShowColGrandTotals);
                    Assert.AreEqual(row.blnShowColsTotals, newRow.blnShowColsTotals);
                    Assert.AreEqual(row.blnShowForSingleTotals, newRow.blnShowForSingleTotals);
                    Assert.AreEqual(row.blnShowRowGrandTotals, newRow.blnShowRowGrandTotals);
                    Assert.AreEqual(row.blnShowRowsTotals, newRow.blnShowRowsTotals);
                    Assert.AreEqual(row.idfsDefaultGroupDate, newRow.idfsDefaultGroupDate);
                    Assert.AreEqual(row.strPivotGridSettings, newRow.strPivotGridSettings);
                    Assert.AreEqual(BinaryCompressor.UnzipString(row.blbPivotGridSettings),
                        BinaryCompressor.UnzipString(newRow.blbPivotGridSettings));
                    Assert.AreEqual(row.strDefaultLayoutName, newRow.strDefaultLayoutName);
                    Assert.AreEqual(row.strLayoutName, newRow.strLayoutName);
                    Assert.AreEqual(row.strDescription, newRow.strDescription);

                    Assert.AreEqual(row.idflLayout, newRow.idflLayout);
                    Assert.AreEqual(row.idflQuery, newRow.idflQuery);
                    Assert.AreEqual(row.idflDescription, newRow.idflDescription);
                    Assert.AreEqual(row.IsidflLayoutFolderNull(), newRow.IsidflLayoutFolderNull());

                    if (!row.IsidflLayoutFolderNull())
                    {
                        Assert.AreEqual(row.idflLayoutFolder, newRow.idflLayoutFolder);
                    }

                    DeleteLayout(layoutId);
                }

                CloseConnection();
            }
        }

        [TestMethod]
        public void UpdateLayoutDetailSettingsTest()
        {
            lock (m_LayoutDB.Connection)
            {
                OpenConnection();
                // create layout under admin
                var securityManager = new EidssSecurityManager();
                int result = securityManager.LogIn(BaseReportTests.Organizaton, BaseReportTests.Admin, BaseReportTests.AdminPassword);
                Assert.AreEqual(0, result);

                long layoutId = CreateLayout();

                var layoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
                var row = (LayoutDetailDataSet.LayoutRow) layoutDetail.Layout.Rows[0];

                Assert.AreEqual(EidssUserContext.User.EmployeeID, row.idfPerson);

                row.strDefaultLayoutName = "English name";
                row.strLayoutName = "russian";

                UpdateLayout(layoutDetail);

                var newLayoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
                var newRow = (LayoutDetailDataSet.LayoutRow) newLayoutDetail.Layout.Rows[0];

                Assert.AreEqual(EidssUserContext.User.EmployeeID, newRow.idfPerson);

                securityManager.LogOut();
                CloseConnection();

                // check that layout under user has the same chart options
                OpenConnection();
                result = securityManager.LogIn(BaseReportTests.Organizaton, BaseReportTests.User, BaseReportTests.UserPassword);
                Assert.AreEqual(0, result);

                layoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);

                Assert.AreNotEqual(EidssUserContext.User.EmployeeID, newRow.idfPerson);

                UpdateLayout(layoutDetail);

                newLayoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
                newRow = (LayoutDetailDataSet.LayoutRow) newLayoutDetail.Layout.Rows[0];

                Assert.AreEqual(EidssUserContext.User.EmployeeID, newRow.idfPerson);
                securityManager.LogOut();
                CloseConnection();

                // check that layout under admin has original options
                OpenConnection();

                result = securityManager.LogIn(BaseReportTests.Organizaton, BaseReportTests.Admin, BaseReportTests.AdminPassword);
                Assert.AreEqual(0, result);

                layoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
                Assert.AreEqual(1, layoutDetail.Layout.Rows.Count);
                //row = (LayoutDetailDataSet.LayoutRow) layoutDetail.Layout.Rows[0];

                DeleteLayout(layoutId);
                securityManager.LogOut();
                CloseConnection();
            }
        }

        [TestMethod]
        public void TestCopyLayoutNameTest()
        {
            using (new CultureInfoTransaction(new CultureInfo("ru-RU")))
            {
                var layout = new AvrTreeElement(-1, m_TestQueryId, null, AvrTreeElementType.Layout,
                    m_TestQueryId, "asdfghj", "фывапр", "", false);
                string xml = AvrQueryLayoutTreeDbHelper.GetCopyLayoutNameXml(layout);
                Assert.IsNotNull(xml);
                Assert.AreEqual(
                    @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><LayoutName LanguageId=""en""  Translation=""Copy of asdfghj"" /><LayoutName LanguageId=""ru""  Translation=""Копия  фывапр"" /></ROOT>",
                    xml);
            }
        }

        private static Predicate<AvrTreeElement> ById(long id)
        {
            return temp => temp.ID == id;
        }

        private static AvrTreeElement CreateFolderItem(long? parentId, string defaultName, string nationalName)
        {
            var item = new AvrTreeElement(BaseDbService.NewIntID(), parentId, null, AvrTreeElementType.Folder, m_TestQueryId, defaultName,
                nationalName, string.Empty, false);
            return item;
        }

        private static long CreateLayout()
        {
            m_LayoutDB.SetQueryID(m_TestQueryId);
            var dataSet = (LayoutDetailDataSet) m_LayoutDB.GetDetail(-1);
            var row = (LayoutDetailDataSet.LayoutRow) dataSet.Layout.Rows[0];
            Assert.AreEqual(m_LayoutDB.ID, row.idflLayout);

            row.strDefaultLayoutName = "english";
            row.strLayoutName = "russian";
            Assert.IsFalse(IsLayoutExists(m_LayoutDB.ID));
            UpdateLayout(dataSet);
            Assert.IsTrue(IsLayoutExists(m_LayoutDB.ID));

            return (long) m_LayoutDB.ID;
        }

        private static void UpdateLayout(DataSet dataSet)
        {
            m_LayoutDB.SetQueryID(m_TestQueryId);
            bool isPosted = m_LayoutDB.PostDetail(dataSet, 0);
            if (!isPosted)
            {
                Exception exception = m_LayoutDB.LastError.Exception;
                Console.WriteLine(exception);
                throw exception;
            }
        }

        private static void DeleteLayout(long layoutId)
        {
            Assert.IsTrue(IsLayoutExists(layoutId));
            m_LayoutDB.Delete(layoutId);
            Assert.IsFalse(IsLayoutExists(layoutId));
        }

        #endregion

        #region Get and post folder

        [TestMethod]
        public void UpdateFoldersTest()
        {
            lock (m_SyncLock)
            {
                PresenterFactory.SharedPresenter.SharedModel.SelectedQueryId = m_TestQueryId;
                long layoutId = CreateLayout();
                try
                {
                    List<AvrTreeElement> original = AvrQueryLayoutTreeDbHelper.LoadQueries();
                    original.AddRange(AvrQueryLayoutTreeDbHelper.LoadFolders(false, m_TestQueryId));
                    EidssUserContext.CheckUserLoggedIn();
                    original.AddRange(AvrQueryLayoutTreeDbHelper.LoadLayouts(false, m_TestQueryId));
                    var final = new List<AvrTreeElement>(original);

                    AvrTreeElement layout = original.Find(ById(layoutId));
                    Assert.IsNotNull(layout);

                    AvrTreeElement folder1 = CreateFolderItem(null, "Folder1", "Nat f1");
                    AvrQueryLayoutTreeDbHelper.SaveFolder(folder1.ID, folder1.ParentID, m_TestQueryId, folder1.DefaultName,
                        folder1.NationalName);

                    AvrTreeElement folder2 = CreateFolderItem(folder1.ID, "Folder2", "Nat f2");
                    AvrQueryLayoutTreeDbHelper.SaveFolder(folder2.ID, folder2.ParentID, m_TestQueryId, folder2.DefaultName,
                        folder2.NationalName);

                    AvrTreeElement folder3 = CreateFolderItem(folder2.ID, "Folder3", "Nat f3");
                    AvrQueryLayoutTreeDbHelper.SaveFolder(folder3.ID, folder3.ParentID, m_TestQueryId, folder3.DefaultName,
                        folder3.NationalName);

                    final.AddRange(new[] {folder1, folder2, folder3});
                    layout.ParentID = folder1.ID;

                    LookupManager.ClearAndReloadOnIdle();
                    List<AvrTreeElement> saved = AvrQueryLayoutTreeDbHelper.LoadQueries();
                    saved.AddRange(AvrQueryLayoutTreeDbHelper.LoadFolders(false, m_TestQueryId));
                    EidssUserContext.CheckUserLoggedIn();
                    saved.AddRange(AvrQueryLayoutTreeDbHelper.LoadLayouts(false, m_TestQueryId));

                    AvrTreeElement newFolder1 = saved.Find(ById(folder1.ID));
                    Assert.IsNotNull(newFolder1);
                    AvrTreeElement newFolder2 = saved.Find(ById(folder2.ID));
                    Assert.IsNotNull(newFolder2);
                    AvrTreeElement newFolder3 = saved.Find(ById(folder3.ID));
                    Assert.IsNotNull(newFolder3);
                    AvrTreeElement newLayout = saved.Find(ById(layoutId));
                    Assert.IsNotNull(newLayout);
                    Assert.AreEqual(m_TestQueryId, newFolder1.ParentID);
                    Assert.AreEqual(newFolder1.ID, newFolder2.ParentID);
                    Assert.AreEqual(newFolder2.ID, newFolder3.ParentID);
                    Assert.AreEqual(m_TestQueryId, newLayout.ParentID);
                    newLayout.ParentID = m_TestQueryId;
                    layout.ParentID = m_TestQueryId;

                    LookupManager.ClearAndReloadOnIdle();
                    int oldFoldersCount = AvrQueryLayoutTreeDbHelper.LoadFolders(false, m_TestQueryId).Count;

                    // delete saved folders

                    using (var avrDbService = new Folder_DB())
                    {
                        Assert.IsTrue(avrDbService.Delete(folder3.ID),
                            string.Format("could not delete folder '{0}' because of '{1}'", folder3.ID, avrDbService.LastError));
                        Assert.IsTrue(avrDbService.Delete(folder2.ID),
                            string.Format("could not delete folder '{0}' because of '{1}'", folder2.ID, avrDbService.LastError));
                        Assert.IsTrue(avrDbService.Delete(folder1.ID),
                            string.Format("could not delete folder '{0}' because of '{1}'", folder1.ID, avrDbService.LastError));
                    }
                    LookupManager.ClearAndReloadOnIdle();
                    Assert.AreEqual(oldFoldersCount - 3, AvrQueryLayoutTreeDbHelper.ReLoadFolders(false, m_TestQueryId).Count);
                }
                finally
                {
                    DeleteLayout(layoutId);
                }
            }
        }

        [TestMethod]
        public void CreateModifyDeleteFoldersTest()
        {
            lock (m_SyncLock)
            {
                EidssUserContext.CheckUserLoggedIn();

                PresenterFactory.SharedPresenter.SharedModel.SelectedQueryId = m_TestQueryId;

                List<AvrTreeElement> original = AvrQueryLayoutTreeDbHelper.LoadFolders(false, m_TestQueryId);

                AvrTreeElement folder1 = CreateFolderItem(null, "Folder1", "Nat f1");
                AvrQueryLayoutTreeDbHelper.SaveFolder(folder1.ID, folder1.ParentID, m_TestQueryId, folder1.DefaultName, folder1.NationalName);
                AvrTreeElement folder2 = CreateFolderItem(null, "Folder2", "Nat f2");
                AvrQueryLayoutTreeDbHelper.SaveFolder(folder2.ID, folder2.ParentID, m_TestQueryId, folder2.DefaultName, folder2.NationalName);
                AvrTreeElement folder3 = CreateFolderItem(null, "Folder3", "Nat f3");
                AvrQueryLayoutTreeDbHelper.SaveFolder(folder3.ID, folder3.ParentID, m_TestQueryId, folder3.DefaultName, folder3.NationalName);

                LookupManager.ClearAndReloadOnIdle();

                List<AvrTreeElement> saved1 = AvrQueryLayoutTreeDbHelper.LoadFolders(false, m_TestQueryId);
                Assert.AreEqual(original.Count + 3, saved1.Count, "some folders not saved");

                AvrTreeElement savedFolder1 = saved1.Find(ById(folder1.ID));
                Assert.IsNotNull(savedFolder1);
                AvrTreeElement savedFolder2 = saved1.Find(ById(folder2.ID));
                Assert.IsNotNull(savedFolder2);
                AvrTreeElement savedFolder3 = saved1.Find(ById(folder3.ID));
                Assert.IsNotNull(savedFolder3);

                Assert.AreEqual(m_TestQueryId, savedFolder1.ParentID);
                Assert.AreEqual(m_TestQueryId, savedFolder2.ParentID);
                Assert.AreEqual(m_TestQueryId, savedFolder3.ParentID);

                AvrQueryLayoutTreeDbHelper.SaveFolder(savedFolder2.ID, savedFolder1.ID,
                    m_TestQueryId, savedFolder2.DefaultName, savedFolder2.NationalName);
                AvrQueryLayoutTreeDbHelper.SaveFolder(savedFolder3.ID, savedFolder2.ID,
                    m_TestQueryId, savedFolder3.DefaultName, savedFolder3.NationalName);

                LookupManager.ClearAndReloadOnIdle();

                List<AvrTreeElement> saved2 = AvrQueryLayoutTreeDbHelper.LoadFolders(false, m_TestQueryId);

                AvrTreeElement updatedFolder2 = saved2.Find(ById(folder2.ID));
                Assert.IsNotNull(updatedFolder2);
                AvrTreeElement updatedFolder3 = saved2.Find(ById(folder3.ID));
                Assert.IsNotNull(updatedFolder3);
                Assert.AreEqual(folder1.ID, updatedFolder2.ParentID);
                Assert.AreEqual(folder2.ID, updatedFolder3.ParentID);

                int oldFoldersCount = AvrQueryLayoutTreeDbHelper.LoadFolders(false, m_TestQueryId).Count;

                // delete saved folders

                using (var avrDbService = new Folder_DB())
                {
                    Assert.IsTrue(avrDbService.Delete(folder3.ID),
                        string.Format("could not delete folder '{0}' because of '{1}'", folder3.ID, avrDbService.LastError));
                    Assert.IsTrue(avrDbService.Delete(folder2.ID),
                        string.Format("could not delete folder '{0}' because of '{1}'", folder2.ID, avrDbService.LastError));
                    Assert.IsTrue(avrDbService.Delete(folder1.ID),
                        string.Format("could not delete folder '{0}' because of '{1}'", folder1.ID, avrDbService.LastError));
                }

                LookupManager.ClearAndReloadOnIdle();

                Assert.AreEqual(oldFoldersCount - 3, AvrQueryLayoutTreeDbHelper.ReLoadFolders(false, m_TestQueryId).Count);
            }
        }

        #endregion

        #region helper methods

        private static bool IsLayoutExists(object id)
        {
            OpenConnection();
            using (var command = new SqlCommand(IsLayoutExistsSQL))
            {
                command.Connection = (SqlConnection) m_LayoutDB.Connection;
                var parameter = new SqlParameter("@LayoutID", id);
                command.Parameters.Add(parameter);
                var count = (int) command.ExecuteScalar();
                return count > 0;
            }
        }

        private static void OpenConnection()
        {
            if (m_LayoutDB.Connection.State != ConnectionState.Open)
            {
                m_LayoutDB.Connection.Open();
            }
        }

        private static void CloseConnection()
        {
            if (m_LayoutDB.Connection.State == ConnectionState.Open)
            {
                m_LayoutDB.Connection.Close();
            }
        }

        private static int GetCount(string query)
        {
            OpenConnection();
            using (var command = new SqlCommand(query))
            {
                command.Connection = (SqlConnection) m_LayoutDB.Connection;
                return (int) command.ExecuteScalar();
            }
        }

        #endregion
    }
}