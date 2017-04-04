using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.tests.Core;
using bv.tests.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.db.tests
{
    [TestClass]
    public class ModelTests
    {
        private static readonly object sync = new object();

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            string scriptPath = PathToTestFolder.Get(TestFolders.Db) + "Data\\CreateTestTables.sql";
            ScriptLoader.RunScript(scriptPath);
        }

        [ClassCleanup]
        public static void Deinit()
        {
            //ScriptLoader.RunScript(PathToTestFolder.Get(TestFolders.Db) + "Data\\DropTestTables.sql");
        }


        [TestMethod]
        public void wrongConnectionString_Test_local()
        {
            DbManagerFactory.SetSqlFactory("Server=wrongserver;Database=wrongdb;Integrated Security=SSPI");
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                Assert.IsFalse(manager.TestConnection());
                Assert.IsInstanceOfType(manager.TestConnectionEx(), typeof(BLToolkit.Data.DataException));
                Assert.AreEqual(53, ((BLToolkit.Data.DataException)manager.TestConnectionEx()).Number);
            }
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                Assert.IsTrue(manager.TestConnection());
                Assert.IsNull(manager.TestConnectionEx());
            }
        }

        [TestMethod]
        public void dbException_Test_local()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            dbException_Test_inner();
        }

        //[TestMethod]
        //public void dbException_Test_remote()
        //{
        //    DbManagerFactory.SetRemoteFactory();
        //    dbException_Test_inner();
        //}
        private void dbException_Test_inner()
        {
            MasterTable.Accessor moacc = MasterTable.Accessor.Instance(null);
            try
            {
                using (DbManagerProxy manager1 = DbManagerFactory.Factory.Create())
                {
                    manager1.BeginTransaction();
                    MasterTable mo1 = moacc.Get(manager1, 1000000L);
                    mo1.TextField = "RAISERROR";
                    moacc.Post(manager1, mo1);
                    manager1.CommitTransaction();
                }
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof (DbModelRaiserrorException));
                Assert.AreEqual("msgSpErr", ((DbModelRaiserrorException)e).MessageId);
            }


            // test without deadlock attempts
            try
            {
                using (DbManagerProxy manager1 = DbManagerFactory.Factory.Create())
                {
                    manager1.BeginTransaction(IsolationLevel.RepeatableRead);
                    MasterTable mo1 = moacc.Get(manager1, 1000000L);
                    mo1.TextField = mo1.TextField + "1";

                    ThreadPool.QueueUserWorkItem(c =>
                                                     {
                                                         try
                                                         {
                                                             using (DbManagerProxy manager2 = DbManagerFactory.Factory.Create())
                                                             {
                                                                 manager2.BeginTransaction(IsolationLevel.RepeatableRead);
                                                                 MasterTable mo2 = moacc.Get(manager2, 1000000L);
                                                                 mo2.TextField = mo2.TextField + "1";
                                                                 Assert.IsTrue(moacc.Post(manager2, mo2));
                                                                 manager2.CommitTransaction();
                                                             }
                                                         }
                                                         catch (Exception e)
                                                         {
                                                             Assert.IsInstanceOfType(e, typeof (DbModelDeadlockException));
                                                         }
                                                     });

                    Thread.Sleep(1000);
                    Assert.IsTrue(moacc.Post(manager1, mo1));
                    manager1.CommitTransaction();
                }
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof (DbModelDeadlockException));
            }
            Thread.Sleep(2000);

            // test with deadlock attempts
            /*
            using (DbManagerProxy manager1 = DbManagerFactory.Factory.Create())
            {
                manager1.BeginTransaction(IsolationLevel.RepeatableRead);
                MasterTable mo1 = moacc.Get(manager1, 1000000L);
                mo1.TextField = mo1.TextField + "1";

                ThreadPool.QueueUserWorkItem(c =>
                                                    {
                                                        using (DbManagerProxy manager2 = DbManagerFactory.Factory.Create())
                                                        {
                                                            MasterTable mo2 = moacc.Get(manager2, 1000000L);
                                                            mo2.TextField = mo2.TextField + "1";
                                                            manager2.DefaultIsolationLevel = IsolationLevel.RepeatableRead;
                                                            bool bRet = moacc.Post(manager2, mo2);
                                                            Assert.IsTrue(bRet);
                                                        }
                                                    });

                Thread.Sleep(500);
                Assert.IsTrue(moacc.Post(manager1, mo1));
                manager1.CommitTransaction();
            }
            Thread.Sleep(4000);
            Thread.Sleep(4000);
            */


            /*
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        MasterTable bo = obj as MasterTable;

                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {

                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {

                        }

                        if (!manager.IsTransactionStarted)
                        {

                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as MasterTable, bChildObject);
                        if (bTransactionStarted)
                        {
                            if (bSuccess)
                            {
                                obj.DeepAcceptChanges();
                                manager.CommitTransaction();

                            }
                            else
                            {
                                manager.RollbackTransaction();
                            }

                        }
                        if (bSuccess && bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            bo.m_IsNew = false;
                        }
                        if (bSuccess && bTransactionStarted)
                        {
                            bo.OnAfterPost();
                        }

                        break;
                    }
                    catch (Exception e)
                    {
                        if (bTransactionStarted)
                        {
                            manager.RollbackTransaction();
                            if (DbModelException.IsDeadlockException(e))
                            {
                                System.Threading.Thread.Sleep(BaseSettings.DeadlockDelay);
                                continue;
                            }
                        }

                        if (e is DataException)
                        {
                            throw DbModelException.Create(e as DataException);
                        }
                        if (e is System.Data.SqlClient.SqlException)
                        {
                            throw DbModelException.Create(e as System.Data.SqlClient.SqlException);
                        }
                        else
                            throw;
                    }
                }
                return bSuccess;
            }
            */



            try
            {
                using (DbManagerProxy manager1 = DbManagerFactory.Factory.Create())
                {
                    manager1.BeginTransaction();
                    MasterTable mo1 = moacc.Get(manager1, 1000000L);
                    using (DbManagerProxy manager2 = DbManagerFactory.Factory.Create())
                    {
                        manager2.CommandTimeout = 2;
                        manager2.BeginTransaction();
                        MasterTable mo2 = moacc.Get(manager2, 1000000L);
                        moacc.Post(manager1, mo1);
                        moacc.Post(manager2, mo2); // exception here
                        manager2.CommitTransaction();
                    }
                    manager1.CommitTransaction();
                }
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof (DbModelTimeoutException));
            }

            try
            {
                using (DbManagerProxy manager1 = DbManagerFactory.Factory.Create())
                {
                    manager1.BeginTransaction();
                    MasterTable mo1 = moacc.Get(manager1, 1000000L);
                    moacc.Post(manager1, mo1);
                    using (DbManagerProxy manager2 = DbManagerFactory.Factory.Create())
                    {
                        manager2.CommandTimeout = 2;
                        manager2.BeginTransaction();
                        MasterTable mo2 = moacc.Get(manager2, 1000000L); // exception here
                        manager2.CommitTransaction();
                    }
                    manager1.CommitTransaction();
                }
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof (DbModelTimeoutException));
            }
        }

        [TestMethod]
        public void lazy_Test_local()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            lazy_Test_inner();
        }

        [TestMethod]
        public void lazy_Test_remote()
        {
            DbManagerFactory.SetRemoteFactory();
            lazy_Test_inner();
        }

        private void lazy_Test_inner()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                manager.BeginTransaction();
                MasterTable.Accessor moacc = MasterTable.Accessor.Instance(null);
                MasterTable mo_d = moacc.Get(manager, 1000000L);
                Assert.IsNotNull(mo_d.Sibling);
                mo_d.Sibling.MasterSiblingField1 = "qqq";
                moacc.Post(manager, mo_d);

                MasterTable mo = moacc.Get(manager, 1000000L);
                FieldInfo fi = mo.GetType().GetField("_Sibling", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.IsNotNull(fi);
                Assert.IsNull(fi.GetValue(mo));
                Assert.IsNotNull(mo.Sibling);
                fi = mo.GetType().GetField("_Link", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.IsNotNull(fi);
                Assert.IsNotNull(fi.GetValue(mo)); // not lazy
                Assert.IsNotNull(mo.Link);
                manager.RollbackTransaction();
            }
        }

        [TestMethod]
        public void fnlist_Test_local()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            fnlist_Test_inner();
        }

        [TestMethod]
        public void fnlist_Test_remote()
        {
            DbManagerFactory.SetRemoteFactory();
            fnlist_Test_inner();
        }

        private void fnlist_Test_inner()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                Lookup2ListItem.Accessor acc = Lookup2ListItem.Accessor.Instance(null);
                List<IObject> objects = acc.SelectList(manager);
                Assert.AreEqual(100, objects.Count);

                List<Lookup2ListItem> items = objects.Cast<Lookup2ListItem>().ToList();
                Assert.AreEqual(100, items.Count);

                List<Lookup2ListItem> list = acc.SelectListT(manager);
                Assert.AreEqual(100, list.Count);

                var filters = new FilterParams();

                Lookup2ListItem filter1 = acc.CreateNewT(manager, null);
                filter1.ParentLookup =
                    filter1.ParentLookupLookup.Where(c => c.Lookup1Field1 == "Lookup1Value2").SingleOrDefault();
                Assert.AreEqual(2, filter1.Lookup2ParentID);
                filters.Add("Lookup2ParentID", "=", filter1.Lookup2ParentID);
                list = acc.SelectListT(manager, filters);
                Assert.AreEqual(10, list.Count);

                Lookup2ListItem filter2 = acc.CreateNewT(manager, null);
                filter2.ParentLookup =
                    filter2.ParentLookupLookup.Where(c => c.Lookup1Field1 == "Lookup1Value5").SingleOrDefault();
                Assert.AreEqual(5, filter2.Lookup2ParentID);
                filters.Clear();
                filters.Add("Lookup2ParentID", ">=", filter1.Lookup2ParentID);
                filters.Add("Lookup2ParentID", "<=", filter2.Lookup2ParentID);
                list = acc.SelectListT(manager, filters);
                Assert.AreEqual(40, list.Count);

                list = acc.SelectListT(manager, filters,
                                       new[]
                                           {
                                               new KeyValuePair<string, ListSortDirection>("Lookup2Field1",
                                                                                           ListSortDirection.Ascending)
                                           }, true);
                Assert.AreEqual("Lookup2Value11", list[0].Lookup2Field1);

                list = acc.SelectListT(manager, filters,
                                       new[]
                                           {
                                               new KeyValuePair<string, ListSortDirection>("Lookup2Field1",
                                                                                           ListSortDirection.Descending)
                                           }, true);
                Assert.AreEqual("Lookup2Value50", list[0].Lookup2Field1);

                filters.Clear();
                filters.Add("par11", "like", "%Value%");
                filters.Add("par21", ">=", 2);
                filters.Add("par22", "<=", 5);
                list = acc.SelectListT(manager, filters);
                Assert.AreEqual(40, list.Count);

                filters.Clear();
                filters.Add("par21", ">=", 2);
                list = acc.SelectListT(manager, filters);
                Assert.AreEqual(90, list.Count);

                filters.Clear();
                filters.Add("par11", "like", "%Value3%");
                list = acc.SelectListT(manager, filters);
                Assert.AreEqual(10, list.Count);
            }
        }

        [TestMethod]
        public void create_extenders_Test_local()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                create_extenders_Test_inner(manager);
            }
        }

        [TestMethod]
        public void create_extenders_Test_remote()
        {
            DbManagerFactory.SetRemoteFactory();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                create_extenders_Test_inner(manager);
            }
        }

        private void create_extenders_Test_inner(DbManagerProxy manager)
        {
            MasterTable.Accessor moacc = MasterTable.Accessor.Instance(null);
            MasterTable mo = moacc.Create(manager, null, (int?) null);
            Assert.AreEqual(1000001L, mo.MasterID);
            Assert.IsNotNull(mo.Sibling);
            Assert.AreEqual(1000001L, mo.Sibling.MasterSiblingID);
            Assert.AreEqual(1000002L, mo.Link.LinkID);
            Assert.AreEqual(1000002L, mo.LinkField1);
            Assert.IsNotNull(mo.InnerDate);
            Assert.AreEqual("create", mo.TextField);
            Assert.AreEqual(2, mo.ChildrenCount);
            Assert.AreEqual(1000001L, mo.Children[0].ChildID);
            Assert.AreEqual("create", mo.Children[0].TextFieldFromMaster);
            Assert.AreEqual("create0", mo.Children[1].TextFieldFromMaster);
        }

        [TestMethod]
        public void load_extenders_Test_local()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                load_extenders_Test_inner(manager);
            }
        }

        [TestMethod]
        public void load_extenders_Test_remote()
        {
            DbManagerFactory.SetRemoteFactory();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                load_extenders_Test_inner(manager);
            }
        }

        public void load_extenders_Test_inner(DbManagerProxy manager)
        {
            MasterTable.Accessor moacc = MasterTable.Accessor.Instance(null);
            MasterTable mo = moacc.Get(manager, 1000000L);
            Assert.AreEqual(1000000L, mo.MasterID);
            Assert.IsNotNull(mo.Sibling);
            Assert.AreEqual(1000000L, mo.Sibling.MasterSiblingID);
            Assert.AreEqual(2000000L, mo.Link.LinkID);
            Assert.AreEqual(2000000L, mo.LinkField1);
            Assert.IsNotNull(mo.InnerDate);
            Assert.AreEqual("load", mo.TextField);
            Assert.AreEqual(2, mo.ChildrenCount);
            Assert.AreEqual(3000000L, mo.Children[0].ChildID);
            Assert.AreEqual(1000000L, mo.Children[1].ChildID);
            Assert.AreEqual("load", mo.Children[0].TextFieldFromMaster);
            Assert.AreEqual("load0", mo.Children[1].TextFieldFromMaster);
        }

        [TestMethod]
        public void post_extenders_Test_local()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                post_extenders_Test_inner(manager);
            }
        }

        [TestMethod]
        public void post_extenders_Test_remote()
        {
            DbManagerFactory.SetRemoteFactory();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                post_extenders_Test_inner(manager);
            }
        }

        public void post_extenders_Test_inner(DbManagerProxy manager)
        {
            MasterTable.Accessor moacc = MasterTable.Accessor.Instance(null);
            MasterTable mo = moacc.Get(manager, 1000000L);
            Assert.IsFalse(mo.IsDirty);
            Assert.AreEqual(2, mo.Children.Count);
            mo.Children[1].MarkToDelete();
            moacc.Post(manager, mo);
            Assert.IsFalse(mo.IsDirty);
            Assert.AreEqual("postu", mo.TextField);
            Assert.AreEqual(3, mo.Children.Count);
            Assert.AreEqual(2, mo.ChildrenCount);
            Assert.AreEqual(3000000L, mo.Children[0].ChildID);
            Assert.AreEqual(1000000L, mo.Children[1].ChildID);
            Assert.AreEqual(1000000L, mo.Children[2].ChildID);
            Assert.AreEqual("postu", mo.Children[0].TextFieldFromMaster);
            Assert.AreEqual("postu0", mo.Children[1].TextFieldFromMaster);
            Assert.AreEqual("postu0", mo.Children[2].TextFieldFromMaster);
        }

        [TestMethod]
        public void post_Test_local()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                post_Test_inner(manager);
            }
        }

        [TestMethod]
        public void post_Test_remote()
        {
            DbManagerFactory.SetRemoteFactory();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                post_Test_inner(manager);
            }
        }

        public void post_Test_inner(DbManagerProxy manager)
        {
            MasterTable.Accessor moacc = MasterTable.Accessor.Instance(null);
            MasterTable mo = moacc.Create(manager, null, (int?) null);
            long id = mo.MasterID;
            mo.Sibling = null;
            mo.Link = null;
            mo.Children.ForEach(t => t.MarkToDelete());
            Assert.IsTrue(moacc.Post(manager, mo));
            mo = moacc.Get(manager, id);
            Assert.AreEqual(1000001L, mo.MasterID);
            mo.Validation += mo_Validation2;
            Assert.IsFalse(mo.MarkToDelete());
            mo.Validation -= mo_Validation2;
            mo.TestString = "-";
            mo.Validation += mo_Validation1;
            Assert.IsFalse(mo.MarkToDelete());
            mo.Validation -= mo_Validation1;
            mo.Validation += mo_Validation0;
            Assert.IsTrue(mo.ForceToDelete());
            mo.Validation -= mo_Validation0;
            Assert.IsTrue(moacc.Post(manager, mo));
            mo = moacc.Get(manager, id);
            Assert.IsNull(mo);
        }

        private void mo_Validation0(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("msgCantDelete", args.MessageId);
            Assert.AreEqual("_on_delete", args.FieldName);
            args.Continue = true;
        }

        private void mo_Validation1(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("msgCantDelete", args.MessageId);
            Assert.AreEqual("_on_delete", args.FieldName);
        }

        private void mo_Validation2(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("ErrMandatoryFieldRequired", args.MessageId);
            Assert.AreEqual("TestString", args.FieldName);
        }

        [TestMethod]
        public void transactions_Test_local()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                transactions_Test_inner(manager);
            }
        }

        [TestMethod]
        public void transactions_Test_remote()
        {
            DbManagerFactory.SetRemoteFactory();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                transactions_Test_inner(manager);
            }
        }

        public void transactions_Test_inner(DbManagerProxy manager)
        {
            MasterTable.Accessor moacc = MasterTable.Accessor.Instance(null);

            manager.BeginTransaction();
            MasterTable mo = moacc.Create(manager, null, (int?) null);
            long id = mo.MasterID;
            mo.Sibling = null;
            mo.Link = null;
            mo.Children.ForEach(t => t.MarkToDelete());
            Assert.IsTrue(moacc.Post(manager, mo));
            mo = moacc.Get(manager, id);
            Assert.AreEqual(1000001L, mo.MasterID);
            manager.RollbackTransaction();
            mo = moacc.Get(manager, id);
            Assert.IsNull(mo);

            manager.BeginTransaction();
            mo = moacc.Create(manager, null, (int?) null);
            id = mo.MasterID;
            mo.Sibling = null;
            mo.Link = null;
            //mo.Children.ForEach(t => t.MarkToDelete());
            Assert.IsTrue(moacc.Post(manager, mo));
            mo = moacc.Get(manager, id);
            Assert.AreEqual(1000001L, mo.MasterID);
            manager.CommitTransaction();
            mo = moacc.Get(manager, id);
            Assert.IsNotNull(mo);

            mo.TestString = "-";
            mo.Validation += MoOnValidation;
            Assert.IsTrue(mo.ForceToDelete());
            Assert.IsTrue(moacc.Post(manager, mo));
            mo.Validation -= MoOnValidation;
            mo = moacc.Get(manager, id);
            Assert.IsNull(mo);
        }

        private void MoOnValidation(object sender, ValidationEventArgs args)
        {
            args.Continue = true;
        }

        [TestMethod]
        public void lookup_Test_local()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                lookup_Test_inner(manager);
            }
        }

        [TestMethod]
        public void lookup_Test_remote()
        {
            DbManagerFactory.SetRemoteFactory();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                lookup_Test_inner(manager);
            }
        }

        public void lookup_Test_inner(DbManagerProxy manager)
        {
            MasterTable.Accessor moacc = MasterTable.Accessor.Instance(null);
            MasterTable mo = moacc.Get(manager, 1000000L);
            Assert.IsNotNull(mo.Lookup1);
            Assert.IsNotNull(mo.Lookup2);
            Assert.IsNotNull(mo.Lookup2Param);
            Assert.AreEqual(11, mo.Lookup1Lookup.Count);
            Assert.AreEqual(11, mo.Lookup2Lookup.Count);
            Assert.AreEqual(11, mo.Lookup2ParamLookup.Count);
            Assert.AreEqual("Lookup1Value1", mo.Lookup1Lookup[1].Lookup1Field1);
            Assert.AreEqual("Lookup2Value1", mo.Lookup2Lookup[1].Lookup2Field1);
            Assert.AreEqual("Lookup2Value1", mo.Lookup2ParamLookup[1].Lookup2Field1);
            mo.Lookup1 = mo.Lookup1Lookup.Where(c => c.Lookup1Field1 == "notfound").SingleOrDefault();
            Assert.IsNull(mo.Lookup1);
            Assert.IsNull(mo.Lookup2);
            Assert.IsNull(mo.Lookup2Param);
            Assert.AreEqual(1, mo.Lookup2Lookup.Count);
            Assert.AreEqual(1, mo.Lookup2ParamLookup.Count);
            mo.Lookup1 = mo.Lookup1Lookup.Where(c => c.Lookup1Field1 == "Lookup1Value2").SingleOrDefault();
            Assert.IsNotNull(mo.Lookup1);
            Assert.IsNull(mo.Lookup2);
            Assert.IsNull(mo.Lookup2Param);
            Assert.AreEqual(11, mo.Lookup2Lookup.Count);
            Assert.AreEqual(11, mo.Lookup2ParamLookup.Count);
            Assert.AreEqual("Lookup2Value11", mo.Lookup2Lookup[1].Lookup2Field1);
            Assert.AreEqual("Lookup2Value11", mo.Lookup2ParamLookup[1].Lookup2Field1);
            mo.Lookup2 = mo.Lookup2Lookup.Where(c => c.Lookup2Field1 == "Lookup2Value12").SingleOrDefault();
            Assert.AreEqual("Lookup2Value12", mo.Lookup2.Lookup2Field1);
            mo.Lookup2Param = mo.Lookup2ParamLookup.Where(c => c.Lookup2Field1 == "Lookup2Value12").SingleOrDefault();
            Assert.AreEqual("Lookup2Value12", mo.Lookup2Param.Lookup2Field1);
        }

        [TestMethod]
        public void lookup_cache_Test_local()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            DbManagerProxy manager1 = DbManagerFactory.Factory.Create();
            DbManagerProxy manager2 = DbManagerFactory.Factory.Create();
            DbManagerProxy manager3 = DbManagerFactory.Factory.Create();
            lookup_cache_Test_inner(manager1, manager2, manager3);
            manager3.Close();
            manager2.Close();
            manager1.Close();
        }

        [TestMethod]
        public void lookup_cache_Test_remote()
        {
            DbManagerFactory.SetRemoteFactory();
            DbManagerProxy manager1 = DbManagerFactory.Factory.Create();
            DbManagerProxy manager2 = DbManagerFactory.Factory.Create();
            DbManagerProxy manager3 = DbManagerFactory.Factory.Create();
            lookup_cache_Test_inner(manager1, manager2, manager3);
            manager3.Close();
            manager2.Close();
            manager1.Close();
        }

        public void lookup_cache_Test_inner(DbManagerProxy manager1, DbManagerProxy manager2, DbManagerProxy manager3)
        {
            lock (sync)
            {
                MasterTable.Accessor toacc = MasterTable.Accessor.Instance(null);
                using (MasterTable to = toacc.SelectByKey(manager1, 1000000L))
                {
                    Assert.AreEqual("Lookup1Value1", to.Lookup1Lookup[1].Lookup1Field1);
                    Assert.AreEqual("Lookup1Value1", to.Lookup1.Lookup1Field1);
                    manager2
                        .SetCommand("update LookupTable1 set Lookup1Field1 = 'AAA' where Lookup1ID = 1")
                        .ExecuteNonQuery();
                    using (MasterTable to1 = toacc.SelectByKey(manager3, 1000000L))
                    {
                        Assert.AreEqual("Lookup1Value1", to1.Lookup1Lookup[1].Lookup1Field1);
                        Assert.AreEqual("Lookup1Value1", to1.Lookup1.Lookup1Field1);
                        LookupManager.ClearAndReload(manager1, "Lookup1Table");
                        Assert.AreEqual("AAA", to.Lookup1Lookup[1].Lookup1Field1);
                        Assert.AreEqual("AAA", to.Lookup1.Lookup1Field1);
                        Assert.AreEqual("AAA", to1.Lookup1Lookup[1].Lookup1Field1);
                        Assert.AreEqual("AAA", to1.Lookup1.Lookup1Field1);
                    }
                    manager2
                        .SetCommand("update LookupTable1 set Lookup1Field1 = 'Lookup1Value1' where Lookup1ID = 1")
                        .ExecuteNonQuery();
                    LookupManager.ClearAndReload(manager3, "Lookup1Table");
                }
            }
        }

        [TestMethod]
        public void cache_scope_Test_local()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            DbManagerProxy manager1 = DbManagerFactory.Factory.Create();
            DbManagerProxy manager2 = DbManagerFactory.Factory.Create();
            DbManagerProxy manager3 = DbManagerFactory.Factory.Create();
            cache_scope_Test_inner(manager1, manager2, manager3);
            manager3.Close();
            manager2.Close();
            manager1.Close();
        }

        [TestMethod]
        public void cache_scope_Test_remote()
        {
            DbManagerFactory.SetRemoteFactory();
            DbManagerProxy manager1 = DbManagerFactory.Factory.Create();
            DbManagerProxy manager2 = DbManagerFactory.Factory.Create();
            DbManagerProxy manager3 = DbManagerFactory.Factory.Create();
            cache_scope_Test_inner(manager1, manager2, manager3);
            manager3.Close();
            manager2.Close();
            manager1.Close();
        }

        public void cache_scope_Test_inner(DbManagerProxy manager1, DbManagerProxy manager2, DbManagerProxy manager3)
        {
            lock (sync)
            {
                using (var cacheScope1 = new CacheScope())
                {
                    MasterTable.Accessor toacc1 = MasterTable.Accessor.Instance(cacheScope1);
                    using (MasterTable to = toacc1.SelectByKey(manager1, 1000000L))
                    {
                        Assert.AreEqual("Lookup1Value1", to.Lookup1Lookup[1].Lookup1Field1);
                        Assert.AreEqual("Lookup1Value1", to.Lookup1.Lookup1Field1);
                        manager2
                            .SetCommand("update LookupTable1 set Lookup1Field1 = 'AAA' where Lookup1ID = 1")
                            .ExecuteNonQuery();

                        using (var cacheScope2 = new CacheScope())
                        {
                            MasterTable.Accessor toacc2 = MasterTable.Accessor.Instance(cacheScope2);
                            using (MasterTable to1 = toacc2.SelectByKey(manager3, 1000000L))
                            {
                                Assert.AreEqual("AAA", to1.Lookup1Lookup[1].Lookup1Field1);
                                Assert.AreEqual("AAA", to1.Lookup1.Lookup1Field1);
                            }
                        }

                        MasterTable.Accessor toacc3 = MasterTable.Accessor.Instance(cacheScope1);
                        using (MasterTable to2 = toacc3.SelectByKey(manager3, 1000000L))
                        {
                            Assert.AreEqual("Lookup1Value1", to2.Lookup1Lookup[1].Lookup1Field1);
                            Assert.AreEqual("Lookup1Value1", to2.Lookup1.Lookup1Field1);
                        }

                        manager2
                            .SetCommand("update LookupTable1 set Lookup1Field1 = 'Lookup1Value1' where Lookup1ID = 1")
                            .ExecuteNonQuery();
                        LookupManager.ClearAndReload(manager3, "Lookup1Table");
                    }
                }
            }
        }


        [TestMethod]
        public void complexObj_Test_local()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            complexObj_Test_inner();
        }

        [TestMethod]
        public void complexObj_Test_remote()
        {
            DbManagerFactory.SetRemoteFactory();
            complexObj_Test_inner();
        }

        private void complexObj_Test_inner()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                TestTable.Accessor moacc = TestTable.Accessor.Instance(null);
                TestTable mo = moacc.SelectByKey(manager, 1000000L);
                Assert.IsNotNull(mo);
                Assert.IsNotNull(mo.MasterSibling);
                Assert.IsNotNull(mo.Link);
                Assert.AreEqual(1, mo.Children.Count);
                Assert.AreEqual("From extender", mo.MasterSibling.MasterSiblingField1);
            }
        }

        private object create_function()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                ChildTable.Accessor cacc = ChildTable.Accessor.Instance(null);
                ChildTable ret = cacc.CreateNewT(manager, null);
                ret.ChildField1 = "test!!";
                return ret;
            }
        }

        [TestMethod]
        public void TestCreator()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString", ""));
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                TestTable.Accessor moacc = TestTable.Accessor.Instance(null);
                TestTable mo = moacc.SelectByKey(manager, 1000000L);
                mo.Children.Creator = create_function;/* new BLToolkit.ComponentModel.ObjectCreatorCallback(() =>
                     {
                         ChildTable.Accessor cacc = ChildTable.Accessor.Instance(null);
                         ChildTable ret = cacc.CreateNewT(manager);
                         ret.ChildField1 = "test!!";
                         return ret;
                     }
                     );*/
                Assert.AreEqual(1, mo.Children.Count);
                mo.Children.AddNew();
                Assert.AreEqual(2, mo.Children.Count);
                Assert.AreEqual("test!!", mo.Children[1].ChildField1);
            }
       }

    }
}