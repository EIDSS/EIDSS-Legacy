using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Xml.Serialization;
using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using BLToolkit.DataAccess;
using BLToolkit.EditableObjects;
using BLToolkit.Mapping;
using BLToolkit.Reflection;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.tests.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.db.tests
{
    public abstract class MasterObject : EditableObject<MasterObject>
    {
        [MapField("MasterID"), NonUpdatable, PrimaryKey]
        public abstract Int64 MasterID { get; set; }

        [MapField("LookupField1")]
        public abstract Int64 LookupField1 { get; set; }

        [MapField("LookupField2")]
        public abstract Int64 LookupField2 { get; set; }

        [MapField("LinkField1")]
        public abstract Int64 LinkField1 { get; set; }

        [MapField("TextField")]
        public abstract string TextField { get; set; }

        public string TextFieldOriginal
        {
            get { return ((EditableValue<string>) ((dynamic) this)._textField).OriginalValue; }
        }

        public string TextFieldPrevious
        {
            get { return ((EditableValue<string>) ((dynamic) this)._textField).PreviousValue; }
        }
    }

    public abstract class MasterObjectAccessor : DataAccessor<MasterObject>
    {
        [SprocName("spMasterObject_SelectDetail")]
        public abstract MasterObject SelectById(DbManager manager, Int64 MasterID, string LangID);

        [SprocName("spMasterObject_Post")]
        public abstract void Post(DbManager manager, int Action, MasterObject mo);

        public void Insert(DbManager manager, MasterObject mo)
        {
            Post(manager, 4, mo);
        }

        public void Update(DbManager manager, MasterObject mo)
        {
            Post(manager, 16, mo);
        }

        public void Delete(DbManager manager, MasterObject mo)
        {
            Post(manager, 8, mo);
        }

        public List<MasterObject> SelectList(DbManager manager, string LangID)
        {
            return manager
                .SetCommand("SELECT * FROM fnMasterObject_SelectList(@LangID)",
                            manager.Parameter("@LangID", LangID))
                .ExecuteList<MasterObject>();
        }
    }

    [XmlType(AnonymousType = true)]
    //[XmlIncludeAbstract(typeof(TestObject))]
    public abstract class ChildObject : EditableObject<ChildObject>
    {
        [MapField("ChildID"), NonUpdatable, PrimaryKey]
        public abstract Int64 ChildID { get; set; }

        [MapField("ParentID")]
        public abstract Int64 ParentID { get; set; }

        [MapField("ChildField1")]
        public abstract string ChildField1 { get; set; }

        [MapField("LookupField1")]
        public abstract string LookupField1 { get; set; }

        //[Relation(typeof(TestObject), "MasterID", "ParentID")]
        //public TestObject Parent;
    }

    [XmlType(AnonymousType = true)]
    //[XmlIncludeAbstract(typeof(TestObject))]
    public abstract class MasterSiblingObject : EditableObject<MasterSiblingObject>
    {
        [MapField("MasterSiblingID"), NonUpdatable, PrimaryKey]
        public abstract Int64 MasterSiblingID { get; set; }

        [MapField("MasterSiblingField1")]
        public abstract string MasterSiblingField1 { get; set; }

        //[Relation(typeof(TestObject), "MasterID", "MasterSiblingID")]
        //public TestObject Parent;
    }

    [XmlType(AnonymousType = true)]
    //[XmlIncludeAbstract(typeof(TestObject))]
    public abstract class LinkObject : EditableObject<LinkObject>
    {
        [MapField("LinkID"), NonUpdatable, PrimaryKey]
        public abstract Int64 LinkID { get; set; }

        [MapField("LinkField1")]
        public abstract string LinkField1 { get; set; }

        //[Relation(typeof(TestObject), "LinkField1", "LinkID")]
        //public TestObject Parent;
    }

    [XmlType(AnonymousType = true)]
    //[XmlIncludeAbstract(typeof(Lookup2Object))]
    public abstract class Lookup1Object : EditableObject<Lookup1Object>
    {
        [MapField("Lookup1ID"), NonUpdatable, PrimaryKey]
        public abstract Int64 Lookup1ID { get; set; }

        [MapField("Lookup1Field1")]
        public abstract string Lookup1Field1 { get; set; }

        //[Relation(typeof(Lookup2Object), "Lookup2ParentID", "Lookup1ID")]
        //public List<Lookup2Object> Lookup2Objects = new List<Lookup2Object>();
    }

    public abstract class Lookup1ObjectAccessor : DataAccessor<Lookup1Object>
    {
        [SprocName("spLookupTable1_SelectLookup")]
        public abstract List<Lookup1Object> SelectList(DbManager manager, string LangID);
    }

    [XmlType(AnonymousType = true)]
    //[XmlIncludeAbstract(typeof(Lookup1Object))]
    public abstract class Lookup2Object : EditableObject<Lookup2Object>
    {
        [MapField("Lookup2ID"), NonUpdatable, PrimaryKey]
        public abstract Int64 Lookup2ID { get; set; }

        [MapField("Lookup2ParentID")]
        public abstract Int64 Lookup2ParentID { get; set; }

        [MapField("Lookup2Field1")]
        public abstract string Lookup2Field1 { get; set; }

        //[Relation(typeof(Lookup1Object), "Lookup1ID", "Lookup2ParentID")]
        //public Lookup1Object Parent;
    }

    public abstract class Lookup2ObjectAccessor : DataAccessor<Lookup2Object>
    {
        [SprocName("spLookupTable2_SelectLookup")]
        public abstract List<Lookup2Object> SelectList(DbManager manager, string LangID);
    }

    [XmlType(AnonymousType = true)]
    [XmlIncludeAbstract(typeof (ChildObject))]
    [XmlIncludeAbstract(typeof (MasterSiblingObject))]
    [XmlIncludeAbstract(typeof (LinkObject))]
    [XmlIncludeAbstract(typeof (Lookup1Object))]
    [XmlIncludeAbstract(typeof (Lookup2Object))]
    public abstract class TestObject : EditableObject<TestObject>
    {
        [MapField("MasterID"), NonUpdatable, PrimaryKey]
        public abstract Int64 MasterID { get; set; }

        [MapField("LookupField1")]
        public abstract Int64 LookupField1 { get; set; }

        [MapField("LookupField2")]
        public abstract Int64 LookupField2 { get; set; }

        [MapField("LinkField1")]
        public abstract Int64 LinkField1 { get; set; }

        [MapField("TextField")]
        public abstract string TextField { get; set; }

        [Relation(typeof (ChildObject), "ParentID", "MasterID")] public EditableList<ChildObject> Children =
            new EditableList<ChildObject>();

        [Relation(typeof (MasterSiblingObject), "MasterSiblingID", "MasterID")] public MasterSiblingObject MasterSibling;

        [Relation(typeof (LinkObject), "LinkID", "LinkField1")] public LinkObject Link;

        [Relation(typeof (Lookup1Object), "Lookup1ID", "LookupField1")] public Lookup1Object Lookup1Object;

        [Relation(typeof (Lookup2Object), "Lookup2ID", "LookupField2")] public Lookup2Object Lookup2Object;

        public string TextFieldOriginal
        {
            get { return ((EditableValue<string>) ((dynamic) this)._textField).OriginalValue; }
        }

        public string TextFieldPrevious
        {
            get { return ((EditableValue<string>) ((dynamic) this)._textField).PreviousValue; }
        }
    }

    public abstract class TestObjectAccessor : DataAccessor<TestObject>
    {
        public TestObject SelectById(DbManager manager, Int64 ID, string LangID)
        {
            var objs = new List<TestObject>();
            var sets = new MapResultSet[4];
            sets[0] = new MapResultSet(typeof (TestObject), objs);
            sets[1] = new MapResultSet(typeof (ChildObject));
            sets[2] = new MapResultSet(typeof (MasterSiblingObject));
            sets[3] = new MapResultSet(typeof (LinkObject));

            manager
                .SetSpCommand("spTestObject_SelectDetail"
                              , manager.Parameter("@ID", ID)
                              , manager.Parameter("@LangID", LangID)
                )
                .ExecuteResultSet(sets);

            TestObject to = objs[0];

            var lo1acc = CreateInstance<Lookup1ObjectAccessor>();
            List<Lookup1Object> lo1list = lo1acc.SelectList(manager, "en");
            to.Lookup1Object = lo1list
                .Where(c => c.Lookup1ID == to.LookupField1)
                .Single();

            var lo2acc = CreateInstance<Lookup2ObjectAccessor>();
            List<Lookup2Object> lo2list = lo2acc.SelectList(manager, "en");
            to.Lookup2Object = lo2list
                .Where(c => c.Lookup2ID == to.LookupField2 && c.Lookup2ParentID == to.Lookup1Object.Lookup1ID)
                .Single();

            return to;
        }
    }

    [TestClass]
    public class GeneralBLToolkitTest
    {
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            ScriptLoader.RunScript(PathToTestFolder.Get(TestFolders.Db) + "Data\\CreateTestTables.sql");
        }

        [ClassCleanup]
        public static void Deinit()
        {
            //ScriptLoader.RunScript(PathToTestFolder.Get(TestFolders.Db) + "Data\\DropTestTables.sql");
        }

        [TestMethod]
        public void TestFunction()
        {
            string connectionString = Config.GetSetting("EidssConnectionString", "");
            using (var manager = new DbManager(new SqlDataProvider(), connectionString))
            {
                DataTable table = manager
                    .SetCommand(
                        @"select * from dbo.fn_VetCase_SelectList(
                        @LangID
                        )"
                        , manager.Parameter("@LangID", "en")
                    ).ExecuteDataTable();
            }
        }

        [TestMethod]
        public void TestTestObject()
        {
            string connectionString = Config.GetSetting("TestConnectionString", "");
            using (var manager = new DbManager(new SqlDataProvider(), connectionString))
            {
                var toacc = DataAccessor.CreateInstance<TestObjectAccessor>();
                TestObject to = toacc.SelectById(manager, 1000000L, "en");

                Assert.AreEqual(1000000L, to.MasterID);
                Assert.AreEqual(1L, to.LookupField1);
                //Assert.AreEqual("qqq", to.TextField);

                Assert.AreEqual(1, to.Children.Count);
                Assert.AreEqual("ChildValue", to.Children[0].ChildField1);
                //Assert.AreEqual(1000000L, to.Children[0].Parent.MasterID);

                Assert.AreEqual("SiblingValue", to.MasterSibling.MasterSiblingField1);
                //Assert.AreEqual(1000000L, to.MasterSibling.Parent.MasterID);

                Assert.AreEqual("LinkValue1", to.Link.LinkField1);
                //Assert.AreEqual(1000000L, to.Link.Parent.MasterID);

                Assert.AreEqual("Lookup1Value1", to.Lookup1Object.Lookup1Field1);
                Assert.AreEqual("Lookup2Value1", to.Lookup2Object.Lookup2Field1);

                string xml = Serializer.ToXmlString(to);
                var to2 = Serializer.FromXmlString<TestObject>(xml);

                Assert.AreEqual(1000000L, to2.MasterID);
                Assert.AreEqual(1L, to2.LookupField1);
                //Assert.AreEqual("qqq", to2.TextField);

                Assert.AreEqual(1, to2.Children.Count);
                Assert.AreEqual("ChildValue", to2.Children[0].ChildField1);
                //Assert.AreEqual(1000000L, to2.Children[0].Parent.MasterID);

                Assert.AreEqual("SiblingValue", to2.MasterSibling.MasterSiblingField1);
                //Assert.AreEqual(1000000L, to2.MasterSibling.Parent.MasterID);

                Assert.AreEqual("LinkValue1", to2.Link.LinkField1);
                //Assert.AreEqual(1000000L, to2.Link.Parent.MasterID);

                Assert.AreEqual("Lookup1Value1", to2.Lookup1Object.Lookup1Field1);
                Assert.AreEqual("Lookup2Value1", to2.Lookup2Object.Lookup2Field1);
            }
        }

        [TestMethod]
        public void TestMasterObject()
        {
            string connectionString = Config.GetSetting("TestConnectionString", "");
            using (var manager = new DbManager(new SqlDataProvider(), connectionString))
            {
                var moacc = DataAccessor.CreateInstance<MasterObjectAccessor>();

                MasterObject mo_ins = MasterObject.CreateInstance();
                mo_ins.MasterID = 1000001;
                mo_ins.LookupField1 = 1;
                mo_ins.LookupField2 = 1;
                mo_ins.LinkField1 = 2000000;
                mo_ins.TextField = "QQQ";
                moacc.Insert(manager, mo_ins);

                MasterObject mo = moacc.SelectById(manager, 1000001, "en");

                Assert.AreEqual(1000001L, mo.MasterID);
                Assert.AreEqual(1L, mo.LookupField1);
                Assert.AreEqual("QQQ", mo.TextField);

                //mo.ObjectEdit += new BLToolkit.ComponentModel.ObjectEditEventHandler(mo_ObjectEdit);
                mo.PropertyChanged += mo_PropertyChanged;

                mo.TextField = "aaa";
                Assert.IsTrue(mo.IsDirty);
                Assert.IsTrue(mo.IsDirtyMember("TextField"));
                Assert.IsFalse(mo.IsDirtyMember("LookupField1"));

                mo.RejectChanges();
                Assert.IsFalse(mo.IsDirty);
                Assert.AreEqual("QQQ", mo.TextField);

                mo.TextField = "bbb";
                Assert.IsTrue(mo.IsDirty);

                mo.TextField = "ccc";
                Assert.AreEqual("bbb", mo.TextField);

                mo.AcceptChanges();
                Assert.IsFalse(mo.IsDirty);

                moacc.Update(manager, mo);

                List<MasterObject> list = moacc.SelectList(manager, "en");
                Assert.AreEqual(2, list.Count);

                moacc.Delete(manager, mo);
            }
        }

        private void mo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var mo = sender as MasterObject;
            if (e.PropertyName == "TextField" && mo.TextField == "ccc" && mo.TextFieldPrevious == "bbb")
            {
                mo.LockNotifyChanges();
                mo.CancelMemberLastChanges("TextField");
                mo.UnlockNotifyChanges();
            }
        }


    }
}