using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using EIDSS.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Data;
using EIDSS;
using bv.common.Configuration;
using bv.common.db;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using bv.common.db.Core;
using bv.common.win;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Enums;
using System.ComponentModel;
using BaseReferenceType = bv.common.db.BaseReferenceType;

namespace bv.tests
{


    /// <summary>
    ///This is a test class for LookupBinderTest and is intended
    ///to contain all LookupBinderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LookupBinderTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion
        private DataSet GetTestDataset()
        {
            var ds = new DataSet();
            var dt = new DataTable("TestTable");
            dt.Columns.Add(new DataColumn("idfsBaseReference", typeof(long)));
            dt.Columns.Add(new DataColumn("idfEmployee", typeof(long)));
            dt.Columns.Add(new DataColumn("idfOffice", typeof(long)));
            dt.Columns.Add(new DataColumn("idfsCountry", typeof(long)));
            dt.Columns.Add(new DataColumn("idfsRegion", typeof(long)));
            dt.Columns.Add(new DataColumn("idfsRayon", typeof(long)));
            dt.Columns.Add(new DataColumn("idfsSettlement", typeof(long)));
            ds.Tables.Add(dt);
            var row = dt.NewRow();
            row["idfsBaseReference"] = TestStatus.Declined;
            dt.Rows.Add(row);
            ds.AcceptChanges();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            ConnectionManager.DefaultInstance.SetCredentials(Config.GetSetting("EidssConnectionString"));

            EidssUserContext.Init();
            using (var manager = DbManagerFactory.Factory.Create())
            {
                manager.SetCommand(
                    "exec spBaseReference_SysPost 1,19000001, 'en', 'TestDeletedValue', 'TestDeletedValue'; exec spBaseReference_Post 8, 1, 19000001,null,null,null, null, 'en'").ExecuteNonQuery();
            }

            return ds;
        }

        [TestMethod()]
        public void BaseLookupBinderDeletedReferencesTest()
        {
            using (var ds = GetTestDataset())
            {
                using (var form = new Form())
                {
                    var cb = new LookUpEdit();
                    cb.Parent = form;
                    form.Show();
                    Application.DoEvents();
                    LookupBinder.BindBaseLookup(cb, ds, "TestTable.idfsBaseReference", BaseReferenceType.rftActivityStatus);
                    Application.DoEvents();
                    var view = (DataView)cb.Properties.DataSource;
                    Assert.AreEqual(Enum.GetValues(typeof(TestStatus)).Length + 1, view.Count);
                    Assert.AreEqual((long)TestStatus.Declined, (long)cb.EditValue);
                    ds.Tables[0].Rows[0]["idfsBaseReference"] = 1;
                    ds.AcceptChanges();
                    LookupBinder.BindBaseLookup(cb, ds, "TestTable.idfsBaseReference", BaseReferenceType.rftActivityStatus);
                    Application.DoEvents();
                    view = (DataView)cb.Properties.DataSource;
                    Assert.AreEqual(Enum.GetValues(typeof(TestStatus)).Length + 2, view.Count);
                    Assert.AreEqual(1, (long)cb.EditValue);
                    view.Sort = "idfsReference";
                    Assert.IsNotNull(view.Find(1));
                    form.Close();
                }
            }
        }

        private void ValidateRepositoryLookup(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var cb = (LookUpEdit)sender;
            var view = (DataView)cb.Properties.DataSource;
            Assert.AreEqual(Enum.GetValues(typeof(TestStatus)).Length + 1, view.Count);
            Assert.AreEqual((long)TestStatus.Declined, (long)cb.EditValue);
        }
        private void ValidateRepositoryLookup1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var cb = (LookUpEdit)sender;
            var view = (DataView)cb.Properties.DataSource;
            Assert.AreEqual(Enum.GetValues(typeof(TestStatus)).Length + 2, view.Count);
            Assert.AreEqual(1, (long)cb.EditValue);
            view.Sort = "idfsReference";
            Assert.IsNotNull(view.Find(1));
        }
        private void GridView_ShownEditor(object sender, System.EventArgs e)
        {
            var gridView = (GridView)sender;
            if (gridView.ActiveEditor != null && gridView.ActiveEditor is LookUpEdit)
                ((LookUpEdit)gridView.ActiveEditor).ShowPopup();

        }
        [TestMethod()]
        public void BaseRepositoryLookupBinderDeletedReferencesTest()
        {
            using (var ds = GetTestDataset())
            {
                using (var form = new Form())
                {
                    //var form = new Form();
                    var cb = new RepositoryItemLookUpEdit();
                    var grid = new GridControl();
                    var gridView = new GridView();
                    var col = new GridColumn
                                  {
                                      FieldName = "idfsBaseReference",
                                      ColumnEdit = cb,
                                      Caption = "Test Status",
                                      Visible = true,
                                      VisibleIndex = 0
                                  };

                    grid.MainView = gridView;
                    grid.RepositoryItems.AddRange(new RepositoryItem[] { cb });
                    grid.ViewCollection.AddRange(new BaseView[] { gridView });
                    gridView.Columns.AddRange(new GridColumn[] { col });
                    gridView.GridControl = grid;
                    gridView.OptionsBehavior.AutoPopulateColumns = false;
                    gridView.OptionsView.ShowGroupPanel = false;

                    gridView.ShownEditor += GridView_ShownEditor;
                    grid.Parent = form;
                    grid.DataSource = new DataView(ds.Tables[0]);
                    LookupBinder.BindBaseRepositoryLookup(cb, BaseReferenceType.rftActivityStatus);
                    cb.QueryPopUp += ValidateRepositoryLookup;
                    gridView.FocusedColumn = col;
                    gridView.FocusedRowHandle = 0;
                    form.Show();
                    Application.DoEvents();
                    gridView.ShowEditor();
                    Application.DoEvents();
                    gridView.HideEditor();
                    ds.Tables[0].Rows[0]["idfsBaseReference"] = 1;
                    ds.AcceptChanges();
                    cb.QueryPopUp -= ValidateRepositoryLookup;
                    cb.QueryPopUp += ValidateRepositoryLookup1;
                    Application.DoEvents();
                    gridView.ShowEditor();
                    Application.DoEvents();
                    gridView.HideEditor();
                    form.Close();
                    //while (true)
                    //    Application.DoEvents();

                }
            }
        }

        //    /// <summary>
        //    ///A test for LookupBinder Constructor
        //    ///</summary>
        //    [TestMethod()]
        //    public void LookupBinderConstructorTest()
        //    {
        //        LookupBinder target = new LookupBinder();
        //        Assert.Inconclusive("TODO: Implement code to verify target");
        //    }

        //    /// <summary>
        //    ///A test for ActionReference_PlusClick
        //    ///</summary>
        //    [TestMethod()]
        //    public void ActionReference_PlusClickTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ButtonPressedEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.ActionReference_PlusClick(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddActionReference
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void AddActionReferenceTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ButtonPressedEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.AddActionReference(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddBaseReference
        //    ///</summary>
        //    [TestMethod()]
        //    public void AddBaseReferenceTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ButtonPressedEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.AddBaseReference(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddBinding
        //    ///</summary>
        //    [TestMethod()]
        //    public void AddBindingTest()
        //    {
        //        GridLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        object ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.AddBinding(cb, ds, BindField, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddBinding
        //    ///</summary>
        //    [TestMethod()]
        //    public void AddBindingTest1()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        object ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.AddBinding(cb, ds, BindField, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddClearButton
        //    ///</summary>
        //    [TestMethod()]
        //    public void AddClearButtonTest()
        //    {
        //        ButtonEdit cb = null; // TODO: Initialize to an appropriate value
        //        bool ForceAddClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.AddClearButton(cb, ForceAddClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddClearButton
        //    ///</summary>
        //    [TestMethod()]
        //    public void AddClearButtonTest1()
        //    {
        //        RepositoryItemButtonEdit cb = null; // TODO: Initialize to an appropriate value
        //        bool ForceAddClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.AddClearButton(cb, ForceAddClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddDepartment
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void AddDepartmentTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ButtonPressedEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.AddDepartment(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddHACode
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void AddHACodeTest()
        //    {
        //        DataView dv = null; // TODO: Initialize to an appropriate value
        //        RepositoryItemPopupContainerEdit popupContainer = null; // TODO: Initialize to an appropriate value
        //        int code = 0; // TODO: Initialize to an appropriate value
        //        int HACodePopupWidth = 0; // TODO: Initialize to an appropriate value
        //        int HACodePopupWidthExpected = 0; // TODO: Initialize to an appropriate value
        //        bool expected = false; // TODO: Initialize to an appropriate value
        //        bool actual;
        //        actual = LookupBinder_Accessor.AddHACode(dv, popupContainer, code, ref HACodePopupWidth);
        //        Assert.AreEqual(HACodePopupWidthExpected, HACodePopupWidth);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for AddLookupClosedHandler
        //    ///</summary>
        //    [TestMethod()]
        //    public void AddLookupClosedHandlerTest()
        //    {
        //        RepositoryItemLookUpEditBase cb = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.AddLookupClosedHandler(cb);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddOrganization
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void AddOrganizationTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ButtonPressedEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.AddOrganization(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddOrganizationSearchButton
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void AddOrganizationSearchButtonTest()
        //    {
        //        EditorButtonCollection buttons = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.AddOrganizationSearchButton(buttons);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddOtherValue
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void AddOtherValueTest()
        //    {
        //        DataTable dt = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.AddOtherValue(dt);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddPerson
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void AddPersonTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ButtonPressedEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.AddPerson(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddPlusButton
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void AddPlusButtonTest()
        //    {
        //        ButtonEdit cb = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.AddPlusButton(cb);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddPlusButton
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void AddPlusButtonTest1()
        //    {
        //        RepositoryItemButtonEdit cb = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.AddPlusButton(cb);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddQuery
        //    ///</summary>
        //    [TestMethod()]
        //    public void AddQueryTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        EventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.AddQuery(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddQuery
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void AddQueryTest1()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ButtonPressedEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.AddQuery(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddSampleType
        //    ///</summary>
        //    [TestMethod()]
        //    public void AddSampleTypeTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ButtonPressedEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.AddSampleType(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for AddSpecies
        //    ///</summary>
        //    [TestMethod()]
        //    public void AddSpeciesTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ButtonPressedEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.AddSpecies(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindASCampaignLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindASCampaignLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindASCampaignLookup(cb, ds, BindField);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindAVRGisRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindAVRGisRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        GisRefereneceType referenceType = new GisRefereneceType(); // TODO: Initialize to an appropriate value
        //        string valueMember = string.Empty; // TODO: Initialize to an appropriate value
        //        DataView dataSource = null; // TODO: Initialize to an appropriate value
        //        DataView expected = null; // TODO: Initialize to an appropriate value
        //        DataView actual;
        //        actual = LookupBinder.BindAVRGisRepositoryLookup(cb, referenceType, valueMember, dataSource);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for BindActionBaseRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindActionBaseRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        LookupTables TableId = new LookupTables(); // TODO: Initialize to an appropriate value
        //        HACode aHACode = new HACode(); // TODO: Initialize to an appropriate value
        //        string ActionColumnName = string.Empty; // TODO: Initialize to an appropriate value
        //        string ActionCodeFieldName = string.Empty; // TODO: Initialize to an appropriate value
        //        string CodeColumnName = string.Empty; // TODO: Initialize to an appropriate value
        //        string DisplayMember = string.Empty; // TODO: Initialize to an appropriate value
        //        string ValueMember = string.Empty; // TODO: Initialize to an appropriate value
        //        bool AddClearBtn = false; // TODO: Initialize to an appropriate value
        //        bool AddPlusBtn = false; // TODO: Initialize to an appropriate value
        //        bool AddActionHandler = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindActionBaseRepositoryLookup(cb, TableId, aHACode, ActionColumnName, ActionCodeFieldName, CodeColumnName, DisplayMember, ValueMember, AddClearBtn, AddPlusBtn, AddActionHandler);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindAggregateMatrixVersionLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindAggregateMatrixVersionLookupTest()
        //    {
        //        GridLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        AggregateCaseSection MatrixType = new AggregateCaseSection(); // TODO: Initialize to an appropriate value
        //        bool ShowActiveMatrixOnly = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindAggregateMatrixVersionLookup(cb, ds, BindField, MatrixType, ShowActiveMatrixOnly);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindAnimalAgeRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindAnimalAgeRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindAnimalAgeRepositoryLookup(cb, ShowPlusButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseLookupTest()
        //    {
        //        RadioGroup rg = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        HACode aHACode = new HACode(); // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseLookup(rg, ds, BindField, TableId, aHACode);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseLookupTest1()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        object dataSource = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseLookup(cb, dataSource, BindField, TableId, ShowPlusButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseLookupTest2()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        object dataSource = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseLookup(cb, ds, dataSource, BindField, TableId, ShowPlusButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseLookupTest3()
        //    {
        //        RadioGroup rg = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseLookup(rg, ds, BindField, TableId);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseLookupTest4()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseLookup(cb, ds, BindField, TableId);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseLookupTest5()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseLookup(cb, ds, BindField, TableId, ShowPlusButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseLookupTest6()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseLookup(cb, ds, BindField, TableId, ShowPlusButton, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseLookupTest7()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        object dataSource = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        ButtonPressedEventHandler AddButtonHandler = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseLookup(cb, dataSource, BindField, TableId, AddButtonHandler);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseLookupTest8()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        HACode aHACode = new HACode(); // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseLookup(cb, ds, BindField, TableId, aHACode);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseLookupTest9()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        HACode aHACode = new HACode(); // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseLookup(cb, ds, BindField, TableId, aHACode, ShowPlusButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        HACode aHACode = new HACode(); // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseRepositoryLookup(cb, TableId, aHACode);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseRepositoryLookupTest1()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseRepositoryLookup(cb, TableId, ShowPlusButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseRepositoryLookupTest2()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        HACode aHACode = new HACode(); // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseRepositoryLookup(cb, TableId, aHACode, ShowPlusButton, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseRepositoryLookupTest3()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        HACode aHACode = new HACode(); // TODO: Initialize to an appropriate value
        //        ButtonPressedEventHandler AddButtonHandler = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseRepositoryLookup(cb, TableId, aHACode, AddButtonHandler);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindBaseValueLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindBaseValueLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        HACode aHACode = new HACode(); // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindBaseValueLookup(cb, ds, BindField, TableId, aHACode, ShowPlusButton, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindCheckListLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindCheckListLookupTest()
        //    {
        //        CheckedListBoxControl lst = null; // TODO: Initialize to an appropriate value
        //        DataTable dt = null; // TODO: Initialize to an appropriate value
        //        string ValueMember = string.Empty; // TODO: Initialize to an appropriate value
        //        string DisplayMember = string.Empty; // TODO: Initialize to an appropriate value
        //        bool AddEmptyString = false; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableId = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        LookupBinder.BindCheckListLookup(lst, dt, ValueMember, DisplayMember, AddEmptyString, TableId);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindCountryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindCountryLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindCountryLookup(cb, ds, BindField);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindCountryRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindCountryRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindCountryRepositoryLookup(cb);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindDepartmentLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindDepartmentLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindDepartmentLookup(cb, ds, BindField, ShowPlusButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindDepartmentRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindDepartmentRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        bool CurrentOrganization = false; // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindDepartmentRepositoryLookup(cb, CurrentOrganization, ShowPlusButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindDiagnosisHACodeLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindDiagnosisHACodeLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        LookupTables DiagnosisType = new LookupTables(); // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        bool ShowAdditionalColumns = false; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindDiagnosisHACodeLookup(cb, ds, DiagnosisType, BindField, ShowAdditionalColumns, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindDiagnosisHACodeRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindDiagnosisHACodeRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        LookupTables DiagnosisType = new LookupTables(); // TODO: Initialize to an appropriate value
        //        bool ShowAdditionalColumns = false; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        string displayMember = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindDiagnosisHACodeRepositoryLookup(cb, DiagnosisType, ShowAdditionalColumns, ShowClearButton, displayMember);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindDiagnosisLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindDiagnosisLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        bool ShowAdditionalColumns = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindDiagnosisLookup(cb, ds, BindField, ShowAdditionalColumns);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindFFTemplatesLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindFFTemplatesLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        FFType formType = new FFType(); // TODO: Initialize to an appropriate value
        //        LookupBinder.BindFFTemplatesLookup(cb, ds, BindField, formType);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindLayoutLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindLayoutLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        object userId = null; // TODO: Initialize to an appropriate value
        //        bool showAllItems = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindLayoutLookup(cb, userId, showAllItems);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindOrganizationLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindOrganizationLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        object dataSource = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindOrganizationLookup(cb, dataSource, BindField);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindOrganizationLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindOrganizationLookupTest1()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        object dataSource = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindOrganizationLookup(cb, dataSource, BindField, ShowPlusButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindOrganizationRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindOrganizationRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindOrganizationRepositoryLookup(cb);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindOrganizationRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindOrganizationRepositoryLookupTest1()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        string valueMember = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindOrganizationRepositoryLookup(cb, valueMember);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindOutbreakLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindOutbreakLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        object dataSource = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindOutbreakLookup(cb, dataSource, BindField);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindParameterForFFTypeLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindParameterForFFTypeLookupTest()
        //    {
        //        ImageListBoxControl imlbc = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindParameterForFFTypeLookup(imlbc);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindParameterForFFTypeLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindParameterForFFTypeLookupTest1()
        //    {
        //        ListBoxControl lbc = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindParameterForFFTypeLookup(lbc);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindParametersFixedPresetValueLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindParametersFixedPresetValueLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindParametersFixedPresetValueLookup(cb, ds, BindField, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindParametersFixedPresetValueRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindParametersFixedPresetValueRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindParametersFixedPresetValueRepositoryLookup(cb, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindPersonLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindPersonLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        bool showClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindPersonLookup(cb, ds, BindField, showClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindPersonRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindPersonRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindPersonRepositoryLookup(cb);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindQueryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindQueryLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        bool showAllItems = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindQueryLookup(cb, showAllItems);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindQuerySearchFieldLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindQuerySearchFieldLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataView dv = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindQuerySearchFieldLookup(cb, dv, ds, BindField, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindRayonLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindRayonLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindRayonLookup(cb, ds, BindField);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindRayonRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindRayonRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindRayonRepositoryLookup(cb);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindRegionLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindRegionLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindRegionLookup(cb, ds, BindField);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindRegionRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindRegionRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindRegionRepositoryLookup(cb);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindReprositoryCheckListLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindReprositoryCheckListLookupTest()
        //    {
        //        RepositoryItemCheckedComboBoxEdit checkList = null; // TODO: Initialize to an appropriate value
        //        DataView dv = null; // TODO: Initialize to an appropriate value
        //        string ValueMember = string.Empty; // TODO: Initialize to an appropriate value
        //        string DisplayMember = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindReprositoryCheckListLookup(checkList, dv, ValueMember, DisplayMember);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindReprositoryHACodeLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindReprositoryHACodeLookupTest()
        //    {
        //        RepositoryItemPopupContainerEdit popupContainer = null; // TODO: Initialize to an appropriate value
        //        DataView dv = null; // TODO: Initialize to an appropriate value
        //        GridView gridView = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindReprositoryHACodeLookup(popupContainer, dv, gridView);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindSearchCriteriaLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindSearchCriteriaLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindSearchCriteriaLookup(cb, ds, BindField, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindSearchFieldLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindSearchFieldLookupTest()
        //    {
        //        ListBoxControl lbc = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindSearchFieldLookup(lbc);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindSearchFieldLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindSearchFieldLookupTest1()
        //    {
        //        ImageListBoxControl imlbc = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindSearchFieldLookup(imlbc);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindSearchFieldLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindSearchFieldLookupTest2()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindSearchFieldLookup(cb, ds, BindField, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindSettlementLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindSettlementLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindSettlementLookup(cb, ds, BindField);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindSettlementRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindSettlementRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindSettlementRepositoryLookup(cb);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindSiteLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindSiteLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindSiteLookup(cb, ds, BindField, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindSiteRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindSiteRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindSiteRepositoryLookup(cb, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindStandardDiagnosisRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindStandardDiagnosisRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        HACode aHACode = new HACode(); // TODO: Initialize to an appropriate value
        //        bool ShowAdditionalColumns = false; // TODO: Initialize to an appropriate value
        //        string DisplayMember = string.Empty; // TODO: Initialize to an appropriate value
        //        bool AddClearBtn = false; // TODO: Initialize to an appropriate value
        //        bool AddPlusBtn = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindStandardDiagnosisRepositoryLookup(cb, aHACode, ShowAdditionalColumns, DisplayMember, AddClearBtn, AddPlusBtn);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindStandardLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindStandardLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        Enum TableId = null; // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindStandardLookup(cb, ds, BindField, TableId, ShowPlusButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindStandardRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindStandardRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        LookupTables TableId = new LookupTables(); // TODO: Initialize to an appropriate value
        //        bool ShowPlusButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindStandardRepositoryLookup(cb, TableId, ShowPlusButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindTestResultLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindTestResultLookupTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        object dataSource = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindTestResultLookup(cb, dataSource, BindField);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindTestResultRepositoryLookup
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindTestResultRepositoryLookupTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        bool ShowClearButton = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindTestResultRepositoryLookup(cb, ShowClearButton);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for BindTextEdit
        //    ///</summary>
        //    [TestMethod()]
        //    public void BindTextEditTest()
        //    {
        //        TextEdit txt = null; // TODO: Initialize to an appropriate value
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string BindField = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.BindTextEdit(txt, ds, BindField);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for CheckList_ItemCheck
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void CheckList_ItemCheckTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ItemCheckEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.CheckList_ItemCheck(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for CheckList_ItemChecking
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void CheckList_ItemCheckingTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ItemCheckingEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.CheckList_ItemChecking(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for CheckList_Load
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void CheckList_LoadTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        EventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.CheckList_Load(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for CheckedHandler
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void CheckedHandlerTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        EventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.CheckedHandler(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for ClearLookup
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void ClearLookupTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ButtonPressedEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.ClearLookup(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for CreateDiagnosisColumns
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void CreateDiagnosisColumnsTest()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        int aHACode = 0; // TODO: Initialize to an appropriate value
        //        bool ShowAdditionalColumns = false; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.CreateDiagnosisColumns(cb, aHACode, ShowAdditionalColumns);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for FindParentPopupContol
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void FindParentPopupContolTest()
        //    {
        //        Control ctl = null; // TODO: Initialize to an appropriate value
        //        BaseLookupForm expected = null; // TODO: Initialize to an appropriate value
        //        BaseLookupForm actual;
        //        actual = LookupBinder_Accessor.FindParentPopupContol(ctl);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for GetBindedValue
        //    ///</summary>
        //    [TestMethod()]
        //    public void GetBindedValueTest()
        //    {
        //        LookUpEdit lookup = null; // TODO: Initialize to an appropriate value
        //        object expected = null; // TODO: Initialize to an appropriate value
        //        object actual;
        //        actual = LookupBinder.GetBindedValue(lookup);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for GetControlBindingField
        //    ///</summary>
        //    [TestMethod()]
        //    public void GetControlBindingFieldTest()
        //    {
        //        Control ctrl = null; // TODO: Initialize to an appropriate value
        //        string expected = string.Empty; // TODO: Initialize to an appropriate value
        //        string actual;
        //        actual = LookupBinder.GetControlBindingField(ctrl);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for GetDiagnosisHACode
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void GetDiagnosisHACodeTest()
        //    {
        //        LookupTables DiagnosisType = new LookupTables(); // TODO: Initialize to an appropriate value
        //        int expected = 0; // TODO: Initialize to an appropriate value
        //        int actual;
        //        actual = LookupBinder_Accessor.GetDiagnosisHACode(DiagnosisType);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for GetFieldLength
        //    ///</summary>
        //    [TestMethod()]
        //    public void GetFieldLengthTest()
        //    {
        //        DataSet ds = null; // TODO: Initialize to an appropriate value
        //        string fieldName = string.Empty; // TODO: Initialize to an appropriate value
        //        int expected = 0; // TODO: Initialize to an appropriate value
        //        int actual;
        //        actual = LookupBinder.GetFieldLength(ds, fieldName);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for GetHACode
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void GetHACodeTest()
        //    {
        //        object ctl = null; // TODO: Initialize to an appropriate value
        //        HACode expected = new HACode(); // TODO: Initialize to an appropriate value
        //        HACode actual;
        //        actual = LookupBinder_Accessor.GetHACode(ctl);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for GetLookupTableID
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void GetLookupTableIDTest()
        //    {
        //        object ctl = null; // TODO: Initialize to an appropriate value
        //        BaseReferenceType expected = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        BaseReferenceType actual;
        //        actual = LookupBinder_Accessor.GetLookupTableID(ctl);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for GetOriginalValue
        //    ///</summary>
        //    [TestMethod()]
        //    public void GetOriginalValueTest()
        //    {
        //        DataRow row = null; // TODO: Initialize to an appropriate value
        //        string ColumnName = string.Empty; // TODO: Initialize to an appropriate value
        //        object expected = null; // TODO: Initialize to an appropriate value
        //        object actual;
        //        actual = LookupBinder.GetOriginalValue(row, ColumnName);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for GetParentIDFromRowFilter
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void GetParentIDFromRowFilterTest()
        //    {
        //        string filter = string.Empty; // TODO: Initialize to an appropriate value
        //        object expected = null; // TODO: Initialize to an appropriate value
        //        object actual;
        //        actual = LookupBinder_Accessor.GetParentIDFromRowFilter(filter);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for GetQueryDataView
        //    ///</summary>
        //    [TestMethod()]
        //    public void GetQueryDataViewTest()
        //    {
        //        bool showAllItems = false; // TODO: Initialize to an appropriate value
        //        DataView expected = null; // TODO: Initialize to an appropriate value
        //        DataView actual;
        //        actual = LookupBinder.GetQueryDataView(showAllItems);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for HACodeColumn_ShowFilterPopupListBox
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void HACodeColumn_ShowFilterPopupListBoxTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        FilterPopupListBoxEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.HACodeColumn_ShowFilterPopupListBox(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for HACode_Disposed
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void HACode_DisposedTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        EventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.HACode_Disposed(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for HasNoPermission
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void HasNoPermissionTest()
        //    {
        //        EIDSSPermissionObject permissionObject = new EIDSSPermissionObject(); // TODO: Initialize to an appropriate value
        //        bool expected = false; // TODO: Initialize to an appropriate value
        //        bool actual;
        //        actual = LookupBinder_Accessor.HasNoPermission(permissionObject);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for IsPrintButton
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void IsPrintButtonTest()
        //    {
        //        EditorButton btn = null; // TODO: Initialize to an appropriate value
        //        bool expected = false; // TODO: Initialize to an appropriate value
        //        bool actual;
        //        actual = LookupBinder_Accessor.IsPrintButton(btn);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for KeyDown
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void KeyDownTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        KeyEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.KeyDown(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for Lookup_Disposed
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void Lookup_DisposedTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        EventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.Lookup_Disposed(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for MarkCheckListBoxes
        //    ///</summary>
        //    [TestMethod()]
        //    public void MarkCheckListBoxesTest()
        //    {
        //        BaseForm bf = null; // TODO: Initialize to an appropriate value
        //        CheckedListBoxControl lst = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.MarkCheckListBoxes(bf, lst);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for PopupContainerEdit_QueryResultValue
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void PopupContainerEdit_QueryResultValueTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        QueryResultValueEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.PopupContainerEdit_QueryResultValue(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for PopupContainer_QueryDisplayText
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void PopupContainer_QueryDisplayTextTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        QueryDisplayTextEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.PopupContainer_QueryDisplayText(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for PopupContainer_QueryPopUp
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void PopupContainer_QueryPopUpTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        CancelEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.PopupContainer_QueryPopUp(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for RelositoryItemLookupEdit_Closed
        //    ///</summary>
        //    [TestMethod()]
        //    public void RelositoryItemLookupEdit_ClosedTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ClosedEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.RelositoryItemLookupEdit_Closed(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for SearchOrganization
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void SearchOrganizationTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        ButtonPressedEventArgs e = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.SearchOrganization(sender, e);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for SetChecked
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void SetCheckedTest()
        //    {
        //        CheckEdit check = null; // TODO: Initialize to an appropriate value
        //        bool status = false; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.SetChecked(check, status);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for SetDataSource
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void SetDataSourceTest()
        //    {
        //        ImageListBoxControl imlbc = null; // TODO: Initialize to an appropriate value
        //        DataView dv = null; // TODO: Initialize to an appropriate value
        //        string DisplayMember = string.Empty; // TODO: Initialize to an appropriate value
        //        string ValueMember = string.Empty; // TODO: Initialize to an appropriate value
        //        string ImageDisplayMember = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.SetDataSource(imlbc, dv, DisplayMember, ValueMember, ImageDisplayMember);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for SetDataSource
        //    ///</summary>
        //    [TestMethod()]
        //    public void SetDataSourceTest1()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataView dv = null; // TODO: Initialize to an appropriate value
        //        string DisplayMember = string.Empty; // TODO: Initialize to an appropriate value
        //        string ValueMember = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.SetDataSource(cb, dv, DisplayMember, ValueMember);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for SetDataSource
        //    ///</summary>
        //    [TestMethod()]
        //    public void SetDataSourceTest2()
        //    {
        //        RepositoryItemLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataView dv = null; // TODO: Initialize to an appropriate value
        //        string DisplayMember = string.Empty; // TODO: Initialize to an appropriate value
        //        string ValueMember = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.SetDataSource(cb, dv, DisplayMember, ValueMember);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for SetDataSource
        //    ///</summary>
        //    [TestMethod()]
        //    public void SetDataSourceTest3()
        //    {
        //        GridLookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        DataView dv = null; // TODO: Initialize to an appropriate value
        //        string DisplayMember = string.Empty; // TODO: Initialize to an appropriate value
        //        string ValueMember = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder.SetDataSource(cb, dv, DisplayMember, ValueMember);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for SetDataSource
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void SetDataSourceTest4()
        //    {
        //        ListBoxControl lbc = null; // TODO: Initialize to an appropriate value
        //        DataView dv = null; // TODO: Initialize to an appropriate value
        //        string DisplayMember = string.Empty; // TODO: Initialize to an appropriate value
        //        string ValueMember = string.Empty; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.SetDataSource(lbc, dv, DisplayMember, ValueMember);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for SetLookupEditValue
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void SetLookupEditValueTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        Enum TableID = null; // TODO: Initialize to an appropriate value
        //        object ID = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.SetLookupEditValue(sender, TableID, ID);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for SetPersonFilter
        //    ///</summary>
        //    [TestMethod()]
        //    public void SetPersonFilterTest()
        //    {
        //        LookUpEdit cbPerson = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.SetPersonFilter(cbPerson);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for SetPersonFilter
        //    ///</summary>
        //    [TestMethod()]
        //    public void SetPersonFilterTest1()
        //    {
        //        LookUpEdit cbOrganisation = null; // TODO: Initialize to an appropriate value
        //        LookUpEdit cbPerson = null; // TODO: Initialize to an appropriate value
        //        LookupBinder.SetPersonFilter(cbOrganisation, cbPerson);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for SetPersonFilter
        //    ///</summary>
        //    [TestMethod()]
        //    public void SetPersonFilterTest2()
        //    {
        //        DataRow OrganizationRow = null; // TODO: Initialize to an appropriate value
        //        string OrganizationColumn = string.Empty; // TODO: Initialize to an appropriate value
        //        LookUpEdit cbPerson = null; // TODO: Initialize to an appropriate value
        //        bool softLink = false; // TODO: Initialize to an appropriate value
        //        LookupBinder.SetPersonFilter(OrganizationRow, OrganizationColumn, cbPerson, softLink);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for ShowActionReferenceEditor
        //    ///</summary>
        //    [TestMethod()]
        //    public void ShowActionReferenceEditorTest()
        //    {
        //        BaseReferenceType TableID = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        object expected = null; // TODO: Initialize to an appropriate value
        //        object actual;
        //        actual = LookupBinder.ShowActionReferenceEditor(TableID);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for ShowBaseReferenceEditor
        //    ///</summary>
        //    [TestMethod()]
        //    public void ShowBaseReferenceEditorTest()
        //    {
        //        object sender = null; // TODO: Initialize to an appropriate value
        //        BaseReferenceType TableID = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        object expected = null; // TODO: Initialize to an appropriate value
        //        object actual;
        //        actual = LookupBinder.ShowBaseReferenceEditor(sender, TableID);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for ShowRAMQueryEditor
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void ShowRAMQueryEditorTest()
        //    {
        //        LookUpEdit cb = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.ShowRAMQueryEditor(cb);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for VisitCheckLlists
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void VisitCheckLlistsTest()
        //    {
        //        BaseForm bf = null; // TODO: Initialize to an appropriate value
        //        Control parentCtl = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.VisitCheckLlists(bf, parentCtl);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for __ENCAddToList
        //    ///</summary>
        //    [TestMethod()]
        //    [DeploymentItem("eidss_forms.dll")]
        //    public void @__ENCAddToListTest()
        //    {
        //        object value = null; // TODO: Initialize to an appropriate value
        //        LookupBinder_Accessor.@__ENCAddToList(value);
        //        Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //    }

        //    /// <summary>
        //    ///A test for HACodeName
        //    ///</summary>
        //    [TestMethod()]
        //    public void HACodeNameTest()
        //    {
        //        RepositoryItemLookUpEdit ctl = null; // TODO: Initialize to an appropriate value
        //        string expected = string.Empty; // TODO: Initialize to an appropriate value
        //        string actual;
        //        LookupBinder.set_HACodeName(ctl, expected);
        //        actual = LookupBinder.get_HACodeName(ctl);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for HACodeName
        //    ///</summary>
        //    [TestMethod()]
        //    public void HACodeNameTest1()
        //    {
        //        Control ctl = null; // TODO: Initialize to an appropriate value
        //        string expected = string.Empty; // TODO: Initialize to an appropriate value
        //        string actual;
        //        LookupBinder.set_HACodeName(ctl, expected);
        //        actual = LookupBinder.get_HACodeName(ctl);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for HACodeValue
        //    ///</summary>
        //    [TestMethod()]
        //    public void HACodeValueTest()
        //    {
        //        RepositoryItemLookUpEdit ctl = null; // TODO: Initialize to an appropriate value
        //        HACode expected = new HACode(); // TODO: Initialize to an appropriate value
        //        HACode actual;
        //        LookupBinder.set_HACodeValue(ctl, expected);
        //        actual = LookupBinder.get_HACodeValue(ctl);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for HACodeValue
        //    ///</summary>
        //    [TestMethod()]
        //    public void HACodeValueTest1()
        //    {
        //        Control ctl = null; // TODO: Initialize to an appropriate value
        //        HACode expected = new HACode(); // TODO: Initialize to an appropriate value
        //        HACode actual;
        //        LookupBinder.set_HACodeValue(ctl, expected);
        //        actual = LookupBinder.get_HACodeValue(ctl);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for LookupTableID
        //    ///</summary>
        //    [TestMethod()]
        //    public void LookupTableIDTest()
        //    {
        //        Control ctl = null; // TODO: Initialize to an appropriate value
        //        BaseReferenceType expected = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        BaseReferenceType actual;
        //        LookupBinder.set_LookupTableID(ctl, expected);
        //        actual = LookupBinder.get_LookupTableID(ctl);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for LookupTableID
        //    ///</summary>
        //    [TestMethod()]
        //    public void LookupTableIDTest1()
        //    {
        //        RepositoryItemLookUpEdit ctl = null; // TODO: Initialize to an appropriate value
        //        BaseReferenceType expected = new BaseReferenceType(); // TODO: Initialize to an appropriate value
        //        BaseReferenceType actual;
        //        LookupBinder.set_LookupTableID(ctl, expected);
        //        actual = LookupBinder.get_LookupTableID(ctl);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for LookupTableName
        //    ///</summary>
        //    [TestMethod()]
        //    public void LookupTableNameTest()
        //    {
        //        Control ctl = null; // TODO: Initialize to an appropriate value
        //        string expected = string.Empty; // TODO: Initialize to an appropriate value
        //        string actual;
        //        LookupBinder.set_LookupTableName(ctl, expected);
        //        actual = LookupBinder.get_LookupTableName(ctl);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }

        //    /// <summary>
        //    ///A test for LookupTableName
        //    ///</summary>
        //    [TestMethod()]
        //    public void LookupTableNameTest1()
        //    {
        //        RepositoryItemLookUpEdit ctl = null; // TODO: Initialize to an appropriate value
        //        string expected = string.Empty; // TODO: Initialize to an appropriate value
        //        string actual;
        //        LookupBinder.set_LookupTableName(ctl, expected);
        //        actual = LookupBinder.get_LookupTableName(ctl);
        //        Assert.AreEqual(expected, actual);
        //        Assert.Inconclusive("Verify the correctness of this test method.");
        //    }
    }
}
