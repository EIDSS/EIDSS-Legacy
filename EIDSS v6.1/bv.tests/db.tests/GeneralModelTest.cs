using System;
using System.Data;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using BLToolkit.Data.DataProvider;
using BLToolkit.Reflection;
using bv.common.Configuration;
using bv.model.Model.Core;
using bv.tests.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.Schema;
using bv.model.BLToolkit;

namespace bv.tests.db.tests
{
    [TestClass]
    public class GeneralModelTest
    {
        [ClassInitialize()]
        public static void Init(TestContext testContext)
        {
            ScriptLoader.RunScript(PathToTestFolder.Get(TestFolders.Db) + "Data\\CreateTestTables.sql");
        }
        [ClassCleanup()]
        public static void Deinit()
        {
            //ScriptLoader.RunScript(PathToTestFolder.Get(TestFolders.Db) + "Data\\DropTestTables.sql");
        }

        /*
        [TestMethod]
        public void TestTestObject()
        {
            string connectionString = Config.GetSetting("TestConnectionString", "");
            using (DbManagerProxy manager = new DbManagerProxy(new SqlDataProvider(), connectionString))
            {
                TestTable.TestTable_Accessor toacc = DataAccessor.CreateInstance<TestTable.TestTable_Accessor>();
                TestTable to = toacc.SelectByKey(manager, 1000000L);
                TestTable to_copy = toacc.SelectByKey(manager, 1000000L);

                Assert.AreEqual(1000000L, to.MasterID);
                Assert.AreEqual(1L, to.LookupField1);
                Assert.AreEqual("qqq", to.TextField);

                Assert.AreEqual(1, to.Children.Count);
                Assert.AreEqual("ChildValue", to.Children[0].ChildField1);
                //Assert.AreEqual(1000000L, to.Children[0].Parent.MasterID);

                Assert.AreEqual("SiblingValue", to.MasterSibling.MasterSiblingField1);
                //Assert.AreEqual(1000000L, to.MasterSibling.Parent.MasterID);

                Assert.AreEqual("LinkValue1", to.Link.LinkField1);
                //Assert.AreEqual(1000000L, to.Link.Parent.MasterID);

                Assert.AreEqual("Lookup1Value1", to.Lookup1.Lookup1Field1);
                Assert.AreEqual("Lookup2Value1", to.Lookup2.Lookup2Field1);

                string xml = Serializer.ToXmlString(to);
                TestTable to2 = Serializer.FromXmlString<TestTable>(xml);


                Assert.AreEqual(1000000L, to2.MasterID);
                Assert.AreEqual(1L, to2.LookupField1);
                Assert.AreEqual("qqq", to2.TextField);

                Assert.AreEqual(1, to2.Children.Count);
                Assert.AreEqual("ChildValue", to2.Children[0].ChildField1);
                //Assert.AreEqual(1000000L, to2.Children[0].Parent.MasterID);

                Assert.AreEqual("SiblingValue", to2.MasterSibling.MasterSiblingField1);
                //Assert.AreEqual(1000000L, to2.MasterSibling.Parent.MasterID);

                Assert.AreEqual("LinkValue1", to2.Link.LinkField1);
                //Assert.AreEqual(1000000L, to2.Link.Parent.MasterID);

                Assert.AreEqual("Lookup1Value1", to2.Lookup1.Lookup1Field1);
                Assert.AreEqual("Lookup2Value1", to2.Lookup2.Lookup2Field1);
            }
        }


        [TestMethod]
        public void TestMasterObject2()
        {
            string connectionString = Config.GetSetting("TestConnectionString", "");
            using (DbManagerProxy manager = new DbManagerProxy(new SqlDataProvider(), connectionString))
            {
                MasterTable.MasterTable_Accessor toacc = DataAccessor.CreateInstance<MasterTable.MasterTable_Accessor>();
                MasterTable to = toacc.SelectByKey(manager, 1000000L);

                Assert.AreEqual(1000000L, to.MasterID);
                Assert.AreEqual(1L, to.LookupField1);
                Assert.AreEqual("qqq", to.TextField);

                //Assert.AreEqual(1, to.Children.Count);
                Assert.AreEqual("ChildValue", to.Children[0].ChildField1);
                //Assert.AreEqual(1000000L, to.Children[0].Parent.MasterID);

                Assert.AreEqual("SiblingValue", to.Sibling.MasterSiblingField1);
                //Assert.AreEqual(1000000L, to.MasterSibling.Parent.MasterID);

                Assert.AreEqual("LinkValue1", to.Link.LinkField1);
                //Assert.AreEqual(1000000L, to.Link.Parent.MasterID);

                Assert.AreEqual("Lookup1Value1", to.Lookup1.Lookup1Field1);
                Assert.AreEqual("Lookup2Value1", to.Lookup2.Lookup2Field1);

                string xml = Serializer.ToXmlString(to);
                MasterTable to2 = Serializer.FromXmlString<MasterTable>(xml);


                Assert.AreEqual(1000000L, to2.MasterID);
                Assert.AreEqual(1L, to2.LookupField1);
                Assert.AreEqual("qqq", to2.TextField);

                //Assert.AreEqual(1, to2.Children.Count);
                Assert.AreEqual("ChildValue", to2.Children[0].ChildField1);
                //Assert.AreEqual(1000000L, to2.Children[0].Parent.MasterID);

                Assert.AreEqual("SiblingValue", to2.Sibling.MasterSiblingField1);
                //Assert.AreEqual(1000000L, to2.MasterSibling.Parent.MasterID);

                Assert.AreEqual("LinkValue1", to2.Link.LinkField1);
                //Assert.AreEqual(1000000L, to2.Link.Parent.MasterID);

                Assert.AreEqual("Lookup1Value1", to2.Lookup1.Lookup1Field1);
                Assert.AreEqual("Lookup2Value1", to2.Lookup2.Lookup2Field1);
            }
        }

        [TestMethod]
        public void TestMasterObject()
        {
            string connectionString = Config.GetSetting("TestConnectionString", "");
            using (DbManagerProxy manager = new DbManagerProxy(new SqlDataProvider(), connectionString))
            {
                MasterTable.MasterTable_Accessor moacc = DataAccessor.CreateInstance<MasterTable.MasterTable_Accessor>();

                MasterTable mo_ins = moacc.CreateNew(manager);
                Assert.AreEqual(1000001L, mo_ins.MasterID);
                Assert.AreEqual(1000001L, mo_ins.Sibling.MasterSiblingID);
                mo_ins.LookupField1 = 1;
                mo_ins.LookupField2 = 1;
                mo_ins.LinkField1 = 2000000;
                mo_ins.TextField = "QQQ";
                moacc.Post(manager, mo_ins);
                Assert.AreEqual("postingi", mo_ins.TextField);

                MasterTable mo = moacc.SelectByKey(manager, 1000001);

                Assert.AreEqual(1000001L, mo.MasterID);
                Assert.AreEqual(1L, mo.LookupField1);
                Assert.AreEqual("posting", mo.TextField);

                //mo.ObjectEdit += new BLToolkit.ComponentModel.ObjectEditEventHandler(mo_ObjectEdit);
                //mo.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(MasterTable.mo_PropertyChanged);

                mo.TextField = "aaa";
                Assert.IsTrue(mo.IsDirty);
                Assert.IsTrue(mo.IsDirtyMember("TextField"));
                Assert.IsFalse(mo.IsDirtyMember("LookupField1"));

                mo.RejectChanges();
                Assert.IsFalse(mo.IsDirty);
                Assert.AreEqual("posting", mo.TextField);

                mo.TextField = "bbb";
                Assert.IsTrue(mo.IsDirty);

                //mo.TextField = "ccc";
                //Assert.AreEqual("bbb", mo.TextField);

                mo.AcceptChanges();
                Assert.IsFalse(mo.IsDirty);

                moacc.Post(manager, mo);
                Assert.AreEqual("postingu", mo.TextField);
                //Assert.AreEqual("posted", mo.TextField);

                //List<MasterTable> list = moacc.SelectList(manager);
                //Assert.AreEqual(2, list.Count);

                mo.MarkToDelete();
                try
                {
                    moacc.Post(manager, mo);
                }
                catch (Exception e)
                {
                    Assert.IsInstanceOfType(e, typeof(CanNotDeleteException));
                }

                mo.ForceToDelete();
                moacc.Post(manager, mo);
            }
        }
        */

    }

}

/*
namespace bv.tests.Schema.Tests
{
    public partial class MasterTable
    {
        
        partial void Created(DbManagerProxy manager, string LangID)
        {
            SiblingObject.SiblingObject_Accessor sdacc = DataAccessor.CreateInstance<SiblingObject.SiblingObject_Accessor>();
            Sibling = sdacc.CreateNew(manager, LangID);
            Sibling.MasterSiblingID = MasterID;
        }
        partial void Deleted()
        {
            if (Sibling != null)
                Sibling.MarkToDelete();
        }
        partial void Changed(string fieldName)
        {
            if (fieldName == "TextField" && TextField == "ccc" && TextField_Previous == "bbb")
            {
                LockNotifyChanges();
                CancelMemberLastChanges(fieldName);
                UnlockNotifyChanges();
            }
        }
        
    }
}
*/
