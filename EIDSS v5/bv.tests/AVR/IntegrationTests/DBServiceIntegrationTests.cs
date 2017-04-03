using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using EIDSS.RAM;
using EIDSS.RAM.Layout;
using EIDSS.RAM_DB.Common;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.DBService.Enumerations;
using EIDSS.Reports.BaseControls.Transaction;
using Ionic.Zlib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.win;
using bv.tests.common;
using eidss.model.Core;
using eidss.model.Core.CultureInfo;
using eidss.model.Core.Security;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class DBServiceIntegrationTests
    {
        #region SQL

        private const string GetQueryIdSQL =
            @"if not exists	(select	*  from	[dbo].[tasQuery] where idflQuery = 9999)
begin
	INSERT INTO dbo.locBaseReference(idflBaseReference)
		 VALUES (9999)

	INSERT INTO [dbo].[tasQuery] ([idflQuery], [strFunctionName])
		 VALUES (9999, 'dbo.fnAggregateCaseList')

    INSERT INTO [dbo].[locStringNameTranslation] ([idflBaseReference], [idfsLanguage], [strTextString])
         VALUES (9999, 10049003, 'Query1')

    INSERT INTO [dbo].[locStringNameTranslation] ([idflBaseReference], [idfsLanguage], [strTextString])
         VALUES (9999, 10049006, ' верь1')
end

SELECT TOP 1 [idflQuery]	FROM	[dbo].[tasQuery] where idflQuery = 9999";

        private const string IsLayoutExistsSQL =
            @"SELECT	count(*) from tasLayout where idflLayout = @LayoutID";

        private const string DeleteQuerySQL =
            @"declare @idflLayout bigint
declare _T cursor fast_forward for
select idflLayout from tasLayout where idflQuery = 9999
open _T
fetch next from _T into @idflLayout
WHILE @@FETCH_STATUS = 0
	BEGIN 
		exec dbo.spAsLayout_Delete @idflLayout
		fetch next from _T into @idflLayout
	END 
close _T
deallocate _T

delete from	dbo.tasQuery where idflQuery = 9999
exec dbo.spAsReferenceDelete 9999 ";

        #endregion

        private static Layout_DB m_LayoutDB;
        private static LayoutInfo_DB m_LayoutInfoDB;
        private static BaseRamDbService m_PivotDB;
        private static BaseRamDbService m_ChartDB;
        private static long m_TestQueryId;

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            BaseReportTests.InitDBAndLogin();
            PresenterFactory.Init(new BaseForm());

            var mocks = new Mockery();

            mocks.VerifyAllExpectationsHaveBeenMet();

            m_LayoutInfoDB = new LayoutInfo_DB(PresenterFactory.SharedPresenter.SharedModel);
            m_LayoutDB = new Layout_DB(PresenterFactory.SharedPresenter.SharedModel);
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

            m_PivotDB = new BaseRamDbService();
            m_LayoutDB.AddLinkedDbService(m_PivotDB, null, RelatedPostOrder.SkipPost);

            m_ChartDB = new BaseRamDbService();
            m_LayoutDB.AddLinkedDbService(m_ChartDB, null, RelatedPostOrder.SkipPost);
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BaseReportTests.InitDBAndLogin();
            PresenterFactory.Init(new BaseForm());
        }

        [ClassCleanup]
        public static void MyClassCleanup()
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
                Assert.IsTrue(dataSet.Tables.Contains("Aggregate"));
                Assert.IsTrue(dataSet is LayoutDetailDataSet, "Dataset has wrong type");
                var layoutDataSet = (LayoutDetailDataSet) dataSet;
                Assert.IsNotNull(layoutDataSet);

                CloseConnection();
            }
        }

        [TestMethod]
        public void GetLayoutInfoTest()
        {
            string layoutCountSQL = string.Format(@"select count (*) from tasLayout where idflQuery = {0}  and idfUserID = {1}",
                                                  BaseReportTests.QueryId, (long) EidssUserContext.User.ID);
            string folderCountSQL = @"select count (*) from tasLayoutFolder where idflQuery = " + BaseReportTests.QueryId;
            lock (m_LayoutDB.Connection)
            {
                EidssUserContext.CheckUserLoggedIn();

                PresenterFactory.SharedPresenter.SharedModel.SelectedQueryId = BaseReportTests.QueryId;

                int layoutCount = GetCount(layoutCountSQL);
                int folderCount = GetCount(folderCountSQL);

                int actualLayoutCount = LayoutInfo_DB.LoadLayouts(BaseReportTests.QueryId, (long) EidssUserContext.User.ID, false).Count;
                Assert.AreEqual(layoutCount, actualLayoutCount);

                int actualFolderCount = LayoutInfo_DB.LoadFolders(BaseReportTests.QueryId, false).Count;
                Assert.AreEqual(folderCount, actualFolderCount);
            }
        }

        [TestMethod]
        public void LayoutDetailPresenterResetKeyTest()
        {
            lock (m_LayoutDB.Connection)
            {
                OpenConnection();

                using (var layoutDetail = new LayoutDetail())
                {
                    object id = -1;
                    layoutDetail.LoadData(ref id);

                    var row =
                        (LayoutDetailDataSet.LayoutRow)((LayoutDetailDataSet)layoutDetail.baseDataSet).Layout.Rows[0];
                    long idflLayout = row.idflLayout;
                    long idflQuery = row.idflQuery;
                    long idflChartName = row.idflChartName;
                    long idflMapName = row.idflMapName;
                    long idflDescription = row.idflDescription;

                    layoutDetail.ProcessLayoutCommand(new LayoutCommand(this, LayoutOperation.Copy));

                    Assert.AreEqual(idflQuery, row.idflQuery);
                    Assert.AreNotEqual(idflLayout, row.idflLayout);
                    Assert.AreNotEqual(idflChartName, row.idflChartName);
                    Assert.AreNotEqual(idflMapName, row.idflMapName);
                    Assert.AreNotEqual(idflDescription, row.idflDescription);
                }
                CloseConnection();
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

                    Assert.IsFalse(row.blnApplyFilter);
                    Assert.IsFalse(row.blnPivotAxis);
                    Assert.IsFalse(row.blnReadOnly);
                    Assert.IsFalse(row.blnShareLayout);
                    Assert.IsFalse(row.blnShowColGrandTotals);
                    Assert.IsFalse(row.blnShowColsTotals);
                    Assert.IsFalse(row.blnShowForSingleTotals);
                    Assert.IsFalse(row.blnShowRowGrandTotals);
                    Assert.IsFalse(row.blnShowRowsTotals);
                    Assert.IsFalse(row.blnShowXLabels);
                    Assert.IsFalse(row.blnShowPointLabels);

                    Assert.AreEqual(m_TestQueryId, row.idflQuery);
                    Assert.AreEqual(layoutId, row.idflLayout);
                    Assert.AreEqual((long) DBChartType.chrBar, row.idfsChartType);
                    Assert.AreEqual((long) DBGroupInterval.gitDate, row.idfsGroupInterval);
                    Assert.AreEqual(EidssUserContext.User.ID, row.idfUserID);

                    row.blnApplyFilter = true;
                    row.blnPivotAxis = true;
                    row.blnReadOnly = true;
                    row.blnShareLayout = true;
                    row.blnShowColGrandTotals = true;
                    row.blnShowColsTotals = true;
                    row.blnShowForSingleTotals = true;
                    row.blnShowRowGrandTotals = true;
                    row.blnShowRowsTotals = true;
                    row.blnShowXLabels = true;
                    row.blnShowPointLabels = true;
                    row.idfsChartType = (long) DBChartType.chrLine;
                    row.idfsGroupInterval = (long) DBGroupInterval.gitDateMonth;
                    row.strBasicXml = @"<?xml version=""1.0"" encoding=""utf-8""?><configuration></configuration>";
                    row.blbZippedBasicXml = BaseRamDbService.CompressString(row.strBasicXml);
                    row.strChartName = "Chart";
                    row.strMapName = "Map";
                    row.strDefaultLayoutName = "English name";
                    row.strLayoutName = "russian";
                    row.strDescription = "descr aaa";
                    row.strGisLayerSettings =
                        @"<?xml version=""1.0"" encoding=""utf-8""?><configuration>strGisLayerSettings</configuration>";
                    row.strGisMapSettings =
                        @"<?xml version=""1.0"" encoding=""utf-8""?><configuration>strGisMapSettings</configuration>";
                    row.intGisLayerPosition = 10;

                    UpdateLayout(layoutDetail);

                    var newLayoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
                    var newRow =
                        (LayoutDetailDataSet.LayoutRow) newLayoutDetail.Layout.Rows[0];

                    Assert.AreEqual(row.blnApplyFilter, newRow.blnApplyFilter);
                    Assert.AreEqual(row.blnPivotAxis, newRow.blnPivotAxis);
                    Assert.AreEqual(row.blnReadOnly, newRow.blnReadOnly);
                    Assert.AreEqual(row.blnShareLayout, newRow.blnShareLayout);
                    Assert.AreEqual(row.blnShowColGrandTotals, newRow.blnShowColGrandTotals);
                    Assert.AreEqual(row.blnShowColsTotals, newRow.blnShowColsTotals);
                    Assert.AreEqual(row.blnShowForSingleTotals, newRow.blnShowForSingleTotals);
                    Assert.AreEqual(row.blnShowRowGrandTotals, newRow.blnShowRowGrandTotals);
                    Assert.AreEqual(row.blnShowRowsTotals, newRow.blnShowRowsTotals);
                    Assert.AreEqual(row.blnShowXLabels, newRow.blnShowXLabels);
                    Assert.AreEqual(row.blnShowPointLabels, newRow.blnShowPointLabels);
                    Assert.AreEqual(row.idfsChartType, newRow.idfsChartType);
                    Assert.AreEqual(row.idfsGroupInterval, newRow.idfsGroupInterval);
                    Assert.AreEqual(row.strBasicXml, newRow.strBasicXml);
                    Assert.AreEqual(BaseRamDbService.UncompressString(row.blbZippedBasicXml),
                                    BaseRamDbService.UncompressString(newRow.blbZippedBasicXml));
                    Assert.AreEqual(row.strChartName, newRow.strChartName);
                    Assert.AreEqual(row.strDefaultLayoutName, newRow.strDefaultLayoutName);
                    Assert.AreEqual(row.strLayoutName, newRow.strLayoutName);
                    Assert.AreEqual(row.strMapName, newRow.strMapName);
                    Assert.AreEqual(row.strDescription, newRow.strDescription);

                    Assert.AreEqual(row.idflLayout, newRow.idflLayout);
                    Assert.AreEqual(row.idflQuery, newRow.idflQuery);
                    Assert.AreEqual(row.idflChartName, newRow.idflChartName);
                    Assert.AreEqual(row.idflMapName, newRow.idflMapName);
                    Assert.AreEqual(row.idflDescription, newRow.idflDescription);
                    Assert.AreEqual(row.IsidflLayoutFolderNull(), newRow.IsidflLayoutFolderNull());

                    Assert.AreEqual(row.strGisLayerSettings, newRow.strGisLayerSettings);
                    Assert.AreEqual(row.strGisMapSettings, newRow.strGisMapSettings);
                    Assert.AreEqual(BaseRamDbService.UncompressString(row.blbGisLayerSettings),
                                    BaseRamDbService.UncompressString(newRow.blbGisLayerSettings));
                    Assert.AreEqual(BaseRamDbService.UncompressString(row.blbGisZippedMapSettings),
                                    BaseRamDbService.UncompressString(newRow.blbGisZippedMapSettings));
                    Assert.AreEqual(row.intGisLayerPosition, newRow.intGisLayerPosition);

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

                Assert.IsFalse(row.blnPivotAxis);
                Assert.IsFalse(row.blnShowXLabels);
                Assert.IsFalse(row.blnShowPointLabels);
                Assert.AreEqual(EidssUserContext.User.ID, row.idfUserID);

                row.blnPivotAxis = true;
                row.blnShowXLabels = true;
                row.blnShowPointLabels = true;
                row.idfsChartType = (long) DBChartType.chrLine;
                row.strChartName = "Chart";
                row.strDefaultLayoutName = "English name";
                row.strLayoutName = "russian";

                UpdateLayout(layoutDetail);

                var newLayoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
                var newRow = (LayoutDetailDataSet.LayoutRow) newLayoutDetail.Layout.Rows[0];

                Assert.AreEqual(row.blnPivotAxis, newRow.blnPivotAxis);
                Assert.AreEqual(row.blnShowXLabels, newRow.blnShowXLabels);
                Assert.AreEqual(row.blnShowPointLabels, newRow.blnShowPointLabels);
                Assert.AreEqual(row.idfsChartType, newRow.idfsChartType);
                Assert.AreEqual(row.strChartName, newRow.strChartName);
                Assert.AreEqual(row.idflChartName, newRow.idflChartName);
                Assert.AreEqual(EidssUserContext.User.ID, newRow.idfUserID);

                securityManager.LogOut();
                CloseConnection();

                // check that layout under user has the same chart options
                OpenConnection();
                result = securityManager.LogIn(BaseReportTests.Organizaton, BaseReportTests.User, BaseReportTests.UserPassword);
                Assert.AreEqual(0, result);

                layoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
                row = (LayoutDetailDataSet.LayoutRow) layoutDetail.Layout.Rows[0];

                Assert.AreNotEqual(EidssUserContext.User.ID, newRow.idfUserID);

                Assert.IsTrue(row.blnPivotAxis);
                Assert.IsTrue(row.blnShowXLabels);
                Assert.IsTrue(row.blnShowPointLabels);
                Assert.AreEqual((long) DBChartType.chrLine, row.idfsChartType);
                Assert.AreEqual("Chart", row.strChartName);

                row.blnPivotAxis = false;
                row.blnShowXLabels = false;
                row.blnShowPointLabels = false;
                row.idfsChartType = (long) DBChartType.chrSpline;
                row.strChartName = "Chart for user";

                UpdateLayout(layoutDetail);

                newLayoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
                newRow = (LayoutDetailDataSet.LayoutRow) newLayoutDetail.Layout.Rows[0];

                Assert.IsFalse(newRow.blnPivotAxis);
                Assert.IsFalse(newRow.blnShowXLabels);
                Assert.IsFalse(newRow.blnShowPointLabels);
                Assert.AreEqual((long) DBChartType.chrSpline, newRow.idfsChartType);
                Assert.AreEqual("Chart for user", newRow.strChartName);
                Assert.AreEqual(EidssUserContext.User.ID, newRow.idfUserID);
                securityManager.LogOut();
                CloseConnection();

                // check that layout under admin has original options
                OpenConnection();

                result = securityManager.LogIn(BaseReportTests.Organizaton, BaseReportTests.Admin, BaseReportTests.AdminPassword);
                Assert.AreEqual(0, result);

                layoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
                row = (LayoutDetailDataSet.LayoutRow) layoutDetail.Layout.Rows[0];

                Assert.IsTrue(row.blnPivotAxis);
                Assert.IsTrue(row.blnShowXLabels);
                Assert.IsTrue(row.blnShowPointLabels);
                Assert.AreEqual((long) DBChartType.chrLine, row.idfsChartType);
                Assert.AreEqual("Chart", row.strChartName);

                DeleteLayout(layoutId);
                securityManager.LogOut();
                CloseConnection();
            }
        }

        [TestMethod]
        public void UpdateLayoutInfoTest()
        {
            PresenterFactory.SharedPresenter.SharedModel.SelectedQueryId = m_TestQueryId;
            long layoutId = CreateLayout();
            try
            {
                List<LayoutTreeElement> original = LayoutInfo_DB.LoadFolders(m_TestQueryId, false);
                EidssUserContext.CheckUserLoggedIn();
                original.AddRange(LayoutInfo_DB.LoadLayouts(m_TestQueryId, (long) EidssUserContext.User.ID, false));
                var final = new List<LayoutTreeElement>(original);

                LayoutTreeElement layout = original.Find(ById(layoutId));
                Assert.IsNotNull(layout);

                LayoutTreeElement folder1 = CreateFolderItem(null, "Folder1", "Nat f1");
                LayoutTreeElement folder2 = CreateFolderItem(folder1.ID, "Folder2", "Nat f2");
                LayoutTreeElement folder3 = CreateFolderItem(folder2.ID, "Folder3", "Nat f3");
                final.AddRange(new[] {folder1, folder2, folder3});
                layout.ParentID = folder1.ID;

                m_LayoutInfoDB.SaveLayoutAndFolders(original, final);

                List<LayoutTreeElement> saved = LayoutInfo_DB.LoadFolders(m_TestQueryId, false);
                EidssUserContext.CheckUserLoggedIn();
                saved.AddRange(LayoutInfo_DB.LoadLayouts(m_TestQueryId, (long) EidssUserContext.User.ID, false));

                LayoutTreeElement newFolder1 = saved.Find(ById(folder1.ID));
                Assert.IsNotNull(newFolder1);
                LayoutTreeElement newFolder2 = saved.Find(ById(folder2.ID));
                Assert.IsNotNull(newFolder2);
                LayoutTreeElement newFolder3 = saved.Find(ById(folder3.ID));
                Assert.IsNotNull(newFolder3);
                LayoutTreeElement newLayout = saved.Find(ById(layoutId));
                Assert.IsNotNull(newLayout);
                Assert.IsNull(newFolder1.ParentID);
                Assert.AreEqual(newFolder1.ID, newFolder2.ParentID);
                Assert.AreEqual(newFolder2.ID, newFolder3.ParentID);
                Assert.AreEqual(newFolder1.ID, newLayout.ParentID);
                newLayout.ParentID = null;
                layout.ParentID = null;

                // delete saved folders
                m_LayoutInfoDB.SaveLayoutAndFolders(saved, new List<LayoutTreeElement>());
                Assert.IsTrue(LayoutInfo_DB.LoadFolders(m_TestQueryId, false).Count == 0);
                EidssUserContext.CheckUserLoggedIn();
                Assert.IsTrue(LayoutInfo_DB.LoadLayouts(m_TestQueryId, (long) EidssUserContext.User.ID, false).Count > 0);
            }
            finally
            {
                DeleteLayout(layoutId);
            }
        }

        private static Predicate<LayoutTreeElement> ById(long id)
        {
            return temp => temp.ID == id;
        }

        private static LayoutTreeElement CreateFolderItem(long? parentId, string defaultName, string nationalName)
        {
            var item = new LayoutTreeElement(BaseDbService.NewIntID(), parentId, m_TestQueryId, false, defaultName,
                                             nationalName, false, true);
            item.SetChanges();
            return item;
        }

        private static long CreateLayout()
        {
            m_LayoutDB.QueryID = m_TestQueryId;
            var dataSet = (LayoutDetailDataSet) m_LayoutDB.GetDetail(-1);
            var row = (LayoutDetailDataSet.LayoutRow) dataSet.Layout.Rows[0];
            Assert.AreEqual(m_LayoutDB.QueryID, row.idflQuery);
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
            bool isPosted = m_LayoutDB.PostDetail(dataSet, 0, null);
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
        public void CreateModifyDeleteFoldertest()
        {
            EidssUserContext.CheckUserLoggedIn();

            PresenterFactory.SharedPresenter.SharedModel.SelectedQueryId = m_TestQueryId;
            List<LayoutTreeElement> original = LayoutInfo_DB.LoadFolders(m_TestQueryId, false);
            var final = new List<LayoutTreeElement>(original.ToArray());

            LayoutTreeElement folder1 = CreateFolderItem(null, "Folder1", "Nat f1");
            LayoutTreeElement folder2 = CreateFolderItem(null, "Folder2", "Nat f2");
            LayoutTreeElement folder3 = CreateFolderItem(null, "Folder3", "Nat f3");
            final.AddRange(new[] {folder1, folder2, folder3});
            m_LayoutInfoDB.SaveLayoutAndFolders(original, final);

            List<LayoutTreeElement> saved1 = LayoutInfo_DB.LoadFolders(m_TestQueryId, false);
            Assert.AreEqual(original.Count + 3, saved1.Count);

            LayoutTreeElement savedFolder1 = saved1.Find(ById(folder1.ID));
            Assert.IsNotNull(savedFolder1);
            LayoutTreeElement savedFolder2 = saved1.Find(ById(folder2.ID));
            Assert.IsNotNull(savedFolder2);
            LayoutTreeElement savedFolder3 = saved1.Find(ById(folder3.ID));
            Assert.IsNotNull(savedFolder3);

            Assert.IsNull(savedFolder1.ParentID);
            Assert.IsNull(savedFolder2.ParentID);
            Assert.IsNull(savedFolder3.ParentID);

            savedFolder2.ParentID = savedFolder1.ID;
            savedFolder3.ParentID = savedFolder2.ID;

            original = new List<LayoutTreeElement>(saved1.ToArray());
            m_LayoutInfoDB.SaveLayoutAndFolders(original, saved1);

            List<LayoutTreeElement> saved2 = LayoutInfo_DB.LoadFolders(m_TestQueryId, false);

            LayoutTreeElement updatedFolder2 = saved2.Find(ById(folder2.ID));
            Assert.IsNotNull(updatedFolder2);
            LayoutTreeElement updatedFolder3 = saved2.Find(ById(folder3.ID));
            Assert.IsNotNull(updatedFolder3);
            Assert.AreEqual(folder1.ID, updatedFolder2.ParentID);
            Assert.AreEqual(folder2.ID, updatedFolder3.ParentID);

            // delete saved folders
            m_LayoutInfoDB.SaveLayoutAndFolders(saved1, new List<LayoutTreeElement>());
            Assert.IsTrue(LayoutInfo_DB.LoadFolders(m_TestQueryId, false).Count == 0);
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
