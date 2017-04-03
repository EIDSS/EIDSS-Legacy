#region Using

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using bv.common;
using bv.common.db;
using bv.common.win;
using EIDSS.RAM;
using EIDSS.RAM.Layout;
using EIDSS.RAM_DB.Common;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.DBService.Enumerations;
using EIDSS.Reports.BaseControls.Transaction;
using Ionic.Zlib;
using NMock2;
using NUnit.Framework;

#endregion

namespace EIDSS.Tests.RAM.IntegrationTests
{
    [TestFixture]
    public class DBServiceIntegrationTests : BaseTests
    {
        #region SQL

        private const string GetQueryIdSQL =
            @"if not exists	(select	*  from	[dbo].[tasQuery] where idflQuery = 9999)
begin
	INSERT INTO dbo.locBaseReference(idflBaseReference)
		 VALUES (9999)

	INSERT INTO [dbo].[tasQuery] ([idflQuery], [strFunctionName])
		 VALUES (9999, 'dbo.fn_AggregateCase_SelectList')

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

        private const string LayoutCountSQL = @"select count (*) from tasLayout where idflQuery = 9999";
        private const string FolderCountSQL = @"select count (*) from tasLayoutFolder where idflQuery = 9999";

        #endregion

        private Layout_DB m_LayoutDB;
        private LayoutInfo_DB m_LayoutInfoDB;
        private BaseRamDbService m_PivotDB;
        private BaseRamDbService m_ChartDB;
        private long m_TestQueryId;

        [TestFixtureSetUp]
        public override void FixtureSetUp()
        {
            base.FixtureSetUp();

            Mockery mocks = new Mockery();
            PresenterFactory.Init(new BaseForm());

            mocks.VerifyAllExpectationsHaveBeenMet();

            m_LayoutInfoDB = new LayoutInfo_DB(PresenterFactory.SharedPresenter.SharedModel);
            m_LayoutDB = new Layout_DB(PresenterFactory.SharedPresenter.SharedModel);
            lock (m_LayoutDB.Connection)
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand(GetQueryIdSQL))
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

        [TestFixtureTearDown]
        public  void TestFixtureTearDown()
        {
            lock (m_LayoutDB.Connection)
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand(DeleteQuerySQL))
                {
                    command.Connection = (SqlConnection) m_LayoutDB.Connection;
                    command.ExecuteNonQuery();
                }
                CloseConnection();
            }
            m_ChartDB.Dispose();
            m_PivotDB.Dispose();
            m_LayoutDB.Dispose();
            
        }

        #region Get Detail 

        [Test]
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
                LayoutDetailDataSet layoutDataSet = (LayoutDetailDataSet) dataSet;
                Assert.IsNotNull(layoutDataSet);

                CloseConnection();
            }
        }

        [Test]
        public void GetLayoutInfoTest()
        {
            PresenterFactory.SharedPresenter.SharedModel.SelectedQueryId = m_TestQueryId;
            int folderCount = GetCount(FolderCountSQL);
            int layoutCount = GetCount(LayoutCountSQL);

            Assert.AreEqual(folderCount, LayoutInfo_DB.LoadFolders(m_TestQueryId, false).Count);
            Assert.AreEqual(layoutCount, LayoutInfo_DB.LoadLayouts(m_TestQueryId, (long)eidss.model.Core.EidssUserContext.User.ID, false).Count);
        }

        #endregion

        #region Get and post

        [Test]
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

        [Test]
        public void UpdateLayoutDetailTest()
        {
            lock (m_LayoutDB.Connection)
            {
                OpenConnection();
                using (new CultureInfoTransaction(new CultureInfo("ru-RU")))
                {
                    long layoutId = CreateLayout();

                    LayoutDetailDataSet layoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
                    LayoutDetailDataSet.LayoutRow row = (LayoutDetailDataSet.LayoutRow) layoutDetail.Layout.Rows[0];

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
                    Assert.AreEqual(eidss.model.Core.EidssUserContext.User.ID, row.idfUserID);

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
                    row.blbZippedBasicXml = ZlibStream.CompressString(row.strBasicXml);
                    row.strChartName = "Chart";
                    row.strMapName = "Map";
                    row.strDefaultLayoutName = "English name";
                    row.strLayoutName = "russian";
                    row.strDescription = "descr aaa";

                    row.intGisMaxColor = Color.Red.ToArgb();
                    row.intGisMaxOutlineColor = Color.Blue.ToArgb();
                    row.intGisMinColor = Color.Black.ToArgb();
                    row.intGisMinOutlineColor = Color.White.ToArgb();
                    row.dblGisMaxMarkerSize = 1.1;
                    row.dblGisMaxOutlineWith = 3.1;
                    row.dblGisMinMarkerSize = 4;
                    row.dblGisMinOutlineWith = 100;
                    row.strGisLegendTitle = "tt";
                    row.strGisMaxAlias = "mm";
                    row.strGisMinAlias = "mm";
                    row.blnGisIsGradient = false;
                    row.blnGisUseAliases = true;


                    UpdateLayout(layoutDetail);

                    LayoutDetailDataSet newLayoutDetail = (LayoutDetailDataSet) m_LayoutDB.GetDetail(layoutId);
                    LayoutDetailDataSet.LayoutRow newRow =
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
                    Assert.AreEqual(ZlibStream.UncompressString(row.blbZippedBasicXml),
                                    ZlibStream.UncompressString(newRow.blbZippedBasicXml));
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

                    Assert.AreEqual(row.intGisMaxColor, newRow.intGisMaxColor);
                    Assert.AreEqual(row.intGisMaxOutlineColor, newRow.intGisMaxOutlineColor);
                    Assert.AreEqual(row.intGisMinColor, newRow.intGisMinColor);
                    Assert.AreEqual(row.intGisMinOutlineColor, newRow.intGisMinOutlineColor);
                    Assert.AreEqual(row.dblGisMaxMarkerSize, newRow.dblGisMaxMarkerSize);
                    Assert.AreEqual(row.dblGisMaxOutlineWith, newRow.dblGisMaxOutlineWith);
                    Assert.AreEqual(row.dblGisMinMarkerSize, newRow.dblGisMinMarkerSize);
                    Assert.AreEqual(row.dblGisMinOutlineWith, newRow.dblGisMinOutlineWith);
                    Assert.AreEqual(row.strGisLegendTitle, newRow.strGisLegendTitle);
                    Assert.AreEqual(row.strGisMaxAlias, newRow.strGisMaxAlias);
                    Assert.AreEqual(row.strGisMinAlias, newRow.strGisMinAlias);
                    Assert.AreEqual(row.blnGisIsGradient, newRow.blnGisIsGradient);
                    Assert.AreEqual(row.blnGisUseAliases, newRow.blnGisUseAliases);
                    if (!row.IsidflLayoutFolderNull())
                    {
                        Assert.AreEqual(row.idflLayoutFolder, newRow.idflLayoutFolder);
                    }

                    DeleteLayout(layoutId);
                }

                CloseConnection();
            }
        }

        [Test]
        public void UpdateLayoutInfoTest()
        {
            PresenterFactory.SharedPresenter.SharedModel.SelectedQueryId = m_TestQueryId;
            long layoutId = CreateLayout();
            try
            {
                List<LayoutTreeElement> original = LayoutInfo_DB.LoadFolders(m_TestQueryId, false);
                original.AddRange(LayoutInfo_DB.LoadLayouts(m_TestQueryId, (long)eidss.model.Core.EidssUserContext.User.ID, false));
                List<LayoutTreeElement> final = new List<LayoutTreeElement>(original);

                LayoutTreeElement layout = original.Find(ById(layoutId));
                Assert.IsNotNull(layout);

                LayoutTreeElement folder1 = CreateFolderItem(null, "Folder1", "Nat f1");
                LayoutTreeElement folder2 = CreateFolderItem(folder1.ID, "Folder2", "Nat f2");
                LayoutTreeElement folder3 = CreateFolderItem(folder2.ID, "Folder3", "Nat f3");
                final.AddRange(new LayoutTreeElement[] {folder1, folder2, folder3});
                layout.ParentID = folder1.ID;

                m_LayoutInfoDB.SaveLayoutAndFolders(original, final);

                List<LayoutTreeElement> saved = LayoutInfo_DB.LoadFolders(m_TestQueryId, false);
                saved.AddRange(LayoutInfo_DB.LoadLayouts(m_TestQueryId, (long)eidss.model.Core.EidssUserContext.User.ID, false));

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
                Assert.IsEmpty(LayoutInfo_DB.LoadFolders(m_TestQueryId, false));
                Assert.IsNotEmpty(LayoutInfo_DB.LoadLayouts(m_TestQueryId, (long)eidss.model.Core.EidssUserContext.User.ID, false));
            }
            finally
            {
                DeleteLayout(layoutId);
            }
        }

        private static Predicate<LayoutTreeElement> ById(long id)
        {
            return delegate(LayoutTreeElement temp) { return temp.ID == id; };
        }

        private LayoutTreeElement CreateFolderItem(long? parentId, string defaultName, string nationalName)
        {
            LayoutTreeElement item = new LayoutTreeElement(BaseDbService.NewIntID(null), parentId, m_TestQueryId, false, defaultName, nationalName, false , true);
            item.SetChanges();
            return item;
        }

        private long CreateLayout()
        {
            m_LayoutDB.QueryID = m_TestQueryId;
            LayoutDetailDataSet dataSet = (LayoutDetailDataSet) m_LayoutDB.GetDetail(-1);
            LayoutDetailDataSet.LayoutRow row = (LayoutDetailDataSet.LayoutRow) dataSet.Layout.Rows[0];
            Assert.AreEqual(m_LayoutDB.QueryID, row.idflQuery);
            Assert.AreEqual(m_LayoutDB.ID, row.idflLayout);

            row.strDefaultLayoutName = "english";
            row.strLayoutName = "russian";
            Assert.IsFalse(IsLayoutExists(m_LayoutDB.ID));
            UpdateLayout(dataSet);
            Assert.IsTrue(IsLayoutExists(m_LayoutDB.ID));

            return (long) m_LayoutDB.ID;
        }

        private void UpdateLayout(DataSet dataSet)
        {
            bool isPosted = m_LayoutDB.PostDetail(dataSet, 0, null);
            if (!isPosted)
            {
                Exception exception = m_LayoutDB.LastError.Exception;
                Console.WriteLine(exception);
                throw exception;
            }
        }

        private void DeleteLayout(long layoutId)
        {
            Assert.IsTrue(IsLayoutExists(layoutId));
            m_LayoutDB.Delete(layoutId);
            Assert.IsFalse(IsLayoutExists(layoutId));
        }

        #endregion

        [Test]
        public void LayoutDetailPresenterResetKeyTest()
        {
            lock (m_LayoutDB.Connection)
            {
                OpenConnection();

                LayoutDetail layoutDetail = new LayoutDetail();
                layoutDetail.LoadData(-1);
                LayoutDetailDataSet.LayoutRow row =
                    (LayoutDetailDataSet.LayoutRow) ((LayoutDetailDataSet) layoutDetail.baseDataSet).Layout.Rows[0];
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
                CloseConnection();
            }
        }

        #region helper methods

        private bool IsLayoutExists(object id)
        {
            OpenConnection();
            using (SqlCommand command = new SqlCommand(IsLayoutExistsSQL))
            {
                command.Connection = (SqlConnection) m_LayoutDB.Connection;
                SqlParameter parameter = new SqlParameter("@LayoutID", id);
                command.Parameters.Add(parameter);
                int count = (int) command.ExecuteScalar();
                return count > 0;
            }
        }

        private void OpenConnection()
        {
            if (m_LayoutDB.Connection.State != ConnectionState.Open)
            {
                m_LayoutDB.Connection.Open();
            }
        }

        private void CloseConnection()
        {
            if (m_LayoutDB.Connection.State == ConnectionState.Open)
            {
                m_LayoutDB.Connection.Close();
            }
        }

        private int GetCount(string query)
        {
            OpenConnection();
            using (SqlCommand command = new SqlCommand(query))
            {
                command.Connection = (SqlConnection) m_LayoutDB.Connection;
                return (int) command.ExecuteScalar();
            }
        }

        #endregion
    }
}