using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.win;
using bv.common.win.Core;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using NUnit.Framework;
using GlobalSettings = bv.common.GlobalSettings;

namespace EIDSS.Tests.Core
{
    [TestFixture]
    public class BaseFormTest
    {
        public static object m_SyncLock = new object();
        [SetUp]
        public virtual void Init()
        {
            ClassLoader.Init("eidss*.dll", null);
            GlobalSettings.Init("test", "test", "test");
            GlobalSettings.AppName = "eidss";
            GlobalSettings.CurrentLanguage = GlobalSettings.lngEn;
            WinClient.Init();
            int res =
                ClientAccessor.SecurityManager.LogIn(BaseSettings.DefaultOrganization, BaseSettings.DefaultUser,
                                                      BaseSettings.DefaultPassword, null, null, null, null, false);
            if(res!=0)
                throw (new Exception("login failed"));
            EIDSS_LookupCacheHelper.Init();
        }
        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
           ClientAccessor.SecurityManager.LogOut();
        }
        
        private static void SplitTestFieldName(string testField, ref string childFormName, ref string tableName, ref string fieldName)
        {
            string[] split = testField.Split('.');
            if (split.Length == 3)
            {
                childFormName = split[0];
                tableName = split[1];
                fieldName = split[2];
            }
            else if (split.Length == 2)
            {
                tableName = split[0];
                fieldName = split[1];
            }
            else
            {
                fieldName = split[0];
            }
        }
        private static void InitTestFields(BaseForm frm, Dictionary<string, object> testFields)
        {
            if (testFields != null)
                foreach (KeyValuePair<string, object> field in testFields)
                {
                    string fieldName = null;
                    string table = frm.baseDataSet.Tables[0].TableName;
                    string childFormName = null;
                    SplitTestFieldName(field.Key, ref childFormName, ref table, ref fieldName);
                    if (childFormName != null)
                    {
                        BaseForm child = GetChildForm(frm, childFormName);
                        Assert.IsNotNull(child, "child form {0} is not found", childFormName);
                        child.baseDataSet.Tables[table].Rows[0][fieldName] = field.Value;
                    }
                    else
                        frm.baseDataSet.Tables[table].Rows[0][fieldName] = field.Value;
                }
        }
        private static void ValidateTestFields(BaseForm frm, Dictionary<string, object> testFields)
        {
            if (testFields != null)
                foreach (KeyValuePair<string, object> field in testFields)
                {
                    string fieldName = null;
                    string table = frm.baseDataSet.Tables[0].TableName;
                    string childFormName = null;
                    SplitTestFieldName(field.Key, ref childFormName, ref table, ref fieldName);

                    if (childFormName != null)
                    {
                        BaseForm child = GetChildForm(frm, childFormName);
                        Assert.IsNotNull(child, "child form <{0}> is not found", childFormName);
                        Assert.AreEqual(field.Value, child.baseDataSet.Tables[table].Rows[0][fieldName],
                                        "table <{0}> incorrectly saved field <{1}> for base form <{2}>", table, fieldName, childFormName);
                    }
                    else
                        Assert.AreEqual(field.Value, frm.baseDataSet.Tables[table].Rows[0][fieldName],
                                        "table <{0}> incorrectly saved field <{1}> for base form <{2}>", table, fieldName, frm.GetType().Name);
                }
        }
        public static BaseForm RunAutoBaseFormTest(object ID, string formName, Dictionary<string, object> testFields, bool checkPrimaryKey)
        {
            lock (m_SyncLock)
            {
                BaseForm frm = null;
                try
                {
                    frm = (BaseForm) ClassLoader.LoadClass(formName);

                }
                catch (Exception ex)
                {
                    Assert.Fail("can't load class {0}, {1}", formName, ex);
                    return null;
                }
                Application.DoEvents();
                BaseForm.ShowNormal(frm, ID, null);
                Application.DoEvents();
                InitTestFields(frm, testFields);
                if (frm.ReadOnly)
                    Assert.Fail("Post is not perfomed for form {0} because form is ReadOnly", formName);
                if (frm.Post(PostType.FinalPosting) == false)
                    Assert.Fail("Post is failed for form {0}", formName);
                ID = frm.GetKey(null, null);
                if (checkPrimaryKey && frm.baseDataSet.Tables.Count > 0 && frm.baseDataSet.Tables[0].Rows.Count > 0)
                    Assert.IsNotNull(ID, "form {0} doesn't return key", formName);
                frm.DoOk();
                Application.DoEvents();
                if (checkPrimaryKey == false || frm is BaseListForm)
                    return frm;
                frm = (BaseForm) ClassLoader.LoadClass(formName);
                BaseForm.ShowNormal(frm, ID, null);
                Application.DoEvents();
                ValidateTestFields(frm, testFields);
                frm.DoOk();
                Application.DoEvents();
                return frm;
            }
        }
        protected static BaseForm RunAutoBaseFormTest(string formName, Dictionary<string, object> testFields, bool checkPrimaryKey)
        {
            return RunAutoBaseFormTest(null, formName, testFields, checkPrimaryKey);
        }

        protected static BaseForm RunAutoBaseFormTest(string formName, Dictionary<string, object> testFields)
        {

            return RunAutoBaseFormTest(null, formName, testFields, true);

        }

        protected static BaseForm GetChildForm(BaseForm frm, string childFormName)
        {
            foreach (IRelatedObject child in frm.Children)
            {
                if (child is BaseForm)
                {
                    if ((child as BaseForm).Name == childFormName)
                        return child as BaseForm;
                    BaseForm childFrm = GetChildForm(child as BaseForm, childFormName);
                    if (childFrm != null)
                        return childFrm;
                }
            }
            return null;
        }
        protected static void RunManualBaseFormTest(string formName)
        {
            object ID = null;
            ErrorForm.ShowMode = ErrorFormShowMode.ShowInUnitTest;
            BaseForm frm = (BaseForm)ClassLoader.LoadClass(formName);
            if (BaseForm.ShowModal(frm, null, ref ID, null, null, 0, 0))
            {
                frm = (BaseForm)ClassLoader.LoadClass(formName);
                BaseForm.ShowModal(frm, null, ref ID, null, null, 0, 0);

            }
        }

        protected static void RunManualBaseFormTest(string formName, Dictionary<string, object> testFields)
        {
            object ID = null;
            ErrorForm.ShowMode = ErrorFormShowMode.ShowInUnitTest;
            BaseForm frm = (BaseForm)ClassLoader.LoadClass(formName);
            Application.DoEvents();
            Form form = BaseForm.ShowNormal(frm, ID, null);
            Application.DoEvents();
            InitTestFields(frm, testFields);
            Application.DoEvents();
            form.Hide();
            Application.DoEvents();
            if (form.ShowDialog()== DialogResult.OK)
            {
                ID = frm.GetKey(null, null);
                frm = (BaseForm)ClassLoader.LoadClass(formName);
                BaseForm.ShowModal(frm, null, ref ID, null, null, 0, 0);

            }
        }
        public void RunDefaultListFormTest(string formName)
        {
            lock (m_SyncLock)
            {
                BaseListForm frm = (BaseListForm) ClassLoader.LoadClass(formName);
                BaseForm.ShowNormal(frm, null, null);
                Application.DoEvents();
                GridView view = (GridView) ((GridControl) frm.Grid).MainView;
                string tableName = ((DataView) (((SortProxy) view.DataSource).Target)).Table.TableName;
                Assert.IsTrue(frm.baseDataSet.Tables.Contains(tableName), "base dataset doesn't contain table {0}",
                              tableName);
                foreach (GridColumn col in view.Columns)
                {
                    Assert.IsTrue(frm.baseDataSet.Tables[tableName].Columns.Contains(col.FieldName),
                                  "base dataset doesn't contain field {0} for table {1}", col.FieldName, tableName);

                }
                frm.DoOk();
                Application.DoEvents();
            }
        }

    }
}
