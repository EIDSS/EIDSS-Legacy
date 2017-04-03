using System;
using System.Collections.Generic;
using System.Data;
using bv.common;
using bv.common.db;
using bv.common.db.Core;
using bv.common.Diagnostics;
using EIDSS.Tests.Core;
using NUnit.Framework;
using System.Threading;
using GlobalSettings = bv.common.GlobalSettings;

namespace EIDSS.Tests.Database
{
    [TestFixture]
    public class LookupCacheTest
    {


        [SetUp]
        public void Init()
        {
            GlobalSettings.Init("test", "test", "test");
            ScriptLoader.RunScript(PathToTestFolder.Get("Database") + "Data\\DropTestTables.sql");
            ScriptLoader.RunScript(PathToTestFolder.Get("Database") + "Data\\CreateTestTables.sql");
        }
        [TearDown]
        public void Deinit()
        {
            LookupCacheListener.Stop();
            ScriptLoader.RunScript(PathToTestFolder.Get("Database") + "Data\\DropTestTables.sql");
        }
        private const int TimeOut = 100;
        [Test]
        public void RandomLookupCacheTest()
        {
            Random rnd = new Random();
            DummyLookupCacheHelper.Init();
            //LookupCache.UseSingleConnection = true;
            DateTime time = DateTime.Now;
            while (DateTime.Now.Subtract(time).TotalSeconds < TimeOut)
            {
                Thread.Sleep(rnd.Next(100, 5000));
                int randomTableNum = Convert.ToInt32(rnd.Next(0, (int)DummyLookupTables.HumanDiagnoses));
                Dbg.Debug("--------------------");
                Dbg.Debug("Get lookup table {0}", ((DummyLookupTables)randomTableNum).ToString());
                DataView dv = LookupCache.Get((DummyLookupTables)randomTableNum);
                Assert.IsNotNull(dv, "lookup cache didn\'t return table {0}", ((DummyLookupTables)randomTableNum).ToString());
                Dbg.Debug("{0} records is returned ", dv.Count);
                //Assert.AreNotEqual(0, dv.Count, "lookup cache {0} has no data", CType(randomTableNum, LookupTables).ToString)
                Dbg.Debug("--------------------");
                LookupCache.Reload();
            }

        }

        [Test]
        public void TestLookupCache()
        {
            Dbg.Debug("************************************************************");
            DebugTimer.Start("start lookup cache filling with multiple connections. Attempt 1");
            DummyLookupCacheHelper.Init();
            //LookupCache.UseSingleConnection = false;
            while (!LookupCache.Filled)
            {
                Thread.Sleep(1000);
                Dbg.Debug("waiting for async lookup table filling");
            }
            DebugTimer.Stop();
            Dbg.Debug("************************************************************");
            Dbg.Debug("************************************************************");
            DebugTimer.Start("start lookup cache filling with multiple connections. Attempt 2");
            LookupCache.Init(true, true);
            //LookupCache.UseSingleConnection = false;
            while (!LookupCache.Filled)
            {
                Thread.Sleep(1000);
                Dbg.Debug("waiting for async lookup table filling");
            }
            DebugTimer.Stop();
            Dbg.Debug("************************************************************");
            Dbg.Debug("************************************************************");
            DebugTimer.Start("start lookup cache filling with single connection. Attempt 1");
            LookupCache.Init(true, true);
            //LookupCache.UseSingleConnection = true;
            while (!LookupCache.Filled)
            {
                Thread.Sleep(1000);
                Dbg.Debug("waiting for async lookup table filling");
            }
            DebugTimer.Stop();
            Dbg.Debug("************************************************************");
            Dbg.Debug("************************************************************");
            DebugTimer.Start("start lookup cache filling with single connection. Attempt 2");
            LookupCache.Init(true, true);
            //LookupCache.UseSingleConnection = true;
            while (!LookupCache.Filled)
            {
                Thread.Sleep(1000);
                Dbg.Debug("waiting for async lookup table filling");
            }
            DebugTimer.Stop();
            Dbg.Debug("************************************************************");
            Dbg.Debug("***********RowFilter performance**************");
            DataView settlementView = LookupCache.Get(DummyLookupTables.Settlement);
            Dbg.Debug("Settlement table contains {0} records", settlementView.Count);
            string rowFilter = string.Format("idfsSettlement=\'{0}\'", settlementView.Table.Rows[0]["idfsSettlement"]);

            DebugTimer.Start("Filtering setllements: " + rowFilter);
            settlementView.RowFilter = rowFilter;
            Dbg.Debug("{0} rows are selected", settlementView.Count);
            DebugTimer.Stop();

            rowFilter = string.Format("idfsSettlement=\'{0}\'", settlementView.Table.Rows[settlementView.Table.Rows.Count - 1]["idfsSettlement"]);
            DebugTimer.Start("Filtering setllements: " + rowFilter);
            settlementView.RowFilter = rowFilter;
            Dbg.Debug("{0} rows are selected", settlementView.Count);
            DebugTimer.Stop();

            rowFilter = string.Format("idfsRayon=\'{0}\'", settlementView.Table.Rows[settlementView.Table.Rows.Count - 1]["idfsRayon"]);
            DebugTimer.Start("Filtering setllements: " + rowFilter);
            settlementView.RowFilter = rowFilter;
            Dbg.Debug("{0} rows are selected", settlementView.Count);
            DebugTimer.Stop();

            rowFilter = string.Format("idfsRayon=\'{0}\'", settlementView.Table.Rows[0]["idfsRayon"]);
            DebugTimer.Start("Filtering setllements: " + rowFilter);
            settlementView.RowFilter = rowFilter;
            Dbg.Debug("{0} rows are selected", settlementView.Count);
            DebugTimer.Stop();

        }

        [Test]
        public void ChangeNotification()
        {
            BaseDbService.NewIntID(null);
            DummyLookupCacheHelper.Init();
            while (!LookupCache.Filled)
            {
                Thread.Sleep(1000);
                Dbg.Debug("waiting for async lookup table filling");
            }
            DataView dv = LookupCache.Get(DummyLookupTables.Organization);
            if (dv.Count > 0)
            {
                object oldName = dv[0]["Name"];
                IDbCommand cmd = BaseDbService.CreateSPCommand("spOrganization_Post", ConnectionManager.DefaultInstance.Connection, null);


                StoredProcParamsCache.CreateParameters(cmd, null);
                BaseDbService.SetParam(cmd, "@idfOffice", dv[0]["idfInstitution"], ParameterDirection.Input);
                BaseDbService.SetParam(cmd, "@EnglishName", "Test111111", ParameterDirection.Input);
                BaseDbService.SetParam(cmd, "@Name", "Test111111", ParameterDirection.Input);
                BaseDbService.SetParam(cmd, "@EnglishAbbreviation", dv[0]["Abbreviation"], ParameterDirection.Input);
                BaseDbService.SetParam(cmd, "@Abbreviation", dv[0]["Abbreviation"], ParameterDirection.Input);
                //BaseDbService.SetParam(cmd, "@LANGID", GlobalSettings.CurrentLanguage, ParameterDirection.Input);
                lock (cmd.Connection)
                {
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();

                    IDbTransaction transaction = cmd.Connection.BeginTransaction();
                    BaseDbService.ExecCommand(cmd, cmd.Connection, transaction, false);
                    LookupCache.NotifyChange("tlbOffice", transaction, null);
                    transaction.Commit();
                }

                Thread.Sleep(2000);
                Assert.AreEqual("Test111111", dv[0]["Name"].ToString(), "organization lookup was not refreshed");

                lock (cmd.Connection)
                {
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    IDbTransaction transaction = cmd.Connection.BeginTransaction();
                    BaseDbService.SetParam(cmd, "@Name", oldName, ParameterDirection.Input);
                    BaseDbService.SetParam(cmd, "@EnglishName", oldName, ParameterDirection.Input);
                    BaseDbService.ExecCommand(cmd, cmd.Connection, transaction, false);
                    LookupCache.NotifyChange("tlbOffice", transaction, null);
                    transaction.Commit();
                }

                Thread.Sleep(2000);
                Assert.AreEqual(oldName, dv[0]["Name"].ToString(), "organization lookup was refreshed unexpectelly");
            }


        }
        [Test]
        public void WebAccessMode()
        {
            LookupCache.WebClientMode = true;
            DummyLookupCacheHelper.Init();
            //LookupCache.UseSingleConnection = true;

            DataView rayonView = LookupCache.Get(DummyLookupTables.Rayon);
            Dictionary<string,object> args = new Dictionary<string, object>();
            Dbg.Debug("************************************************************");
            DebugTimer.Start("get full settlements list");
            DataView settlementView = LookupCache.Get(DummyLookupTables.Settlement);
            DebugTimer.Stop();
            int total = settlementView.Count;
            Dbg.Debug("got {0} settlements", total);
            Assert.Greater(total, 0);
            settlementView.RowFilter = string.Format("idfsRayon={0}", rayonView[0]["idfsRayon"]);
            int rayon0Total = settlementView.Count;
            settlementView.RowFilter = string.Format("idfsRayon={0}", rayonView[1]["idfsRayon"]);
            int rayon1Total = settlementView.Count;
            settlementView.RowFilter = string.Format("idfsRayon={0}", rayonView[2]["idfsRayon"]);
            int rayon2Total = settlementView.Count;

            args["@RayonID"] = rayonView[0]["idfsRayon"];
            Dbg.Debug("************************************************************");
            DebugTimer.Start("get settlements for rayon 1");
            settlementView = LookupCache.Get(DummyLookupTables.Settlement, 0, args);
            DebugTimer.Stop();
            int rayonTotal = settlementView.Count;
            Dbg.Debug("got {0} settlements", rayonTotal);
            Assert.Greater(total, rayonTotal);
            Assert.AreEqual(rayon0Total, rayonTotal);

            args["@RayonID"] = rayonView[1]["idfsRayon"];
            Dbg.Debug("************************************************************");
            DebugTimer.Start("get settlements for rayon 2");
            settlementView = LookupCache.Get(DummyLookupTables.Settlement, 0, args);
            rayonTotal = settlementView.Count;
            Dbg.Debug("got {0} settlements", rayonTotal);
            Assert.Greater(total, rayonTotal);
            Assert.AreEqual(rayon1Total, rayonTotal);

            args["@RayonID"] = rayonView[2]["idfsRayon"];
            Dbg.Debug("************************************************************");
            DebugTimer.Start("get settlements for rayon 3");
            settlementView = LookupCache.Get(DummyLookupTables.Settlement, 0, args);
            DebugTimer.Stop();
            rayonTotal = settlementView.Count;
            Dbg.Debug("got {0} settlements", rayonTotal);
            Assert.Greater(total, rayonTotal);
            Assert.AreEqual(rayon2Total, rayonTotal);

            Dbg.Debug("************************************************************");
            DebugTimer.Start("get settlements for rayon 3");
            settlementView = LookupCache.Get(DummyLookupTables.Settlement, 0, null);
            DebugTimer.Stop();
            rayonTotal = settlementView.Count;
            Dbg.Debug("got {0} settlements", rayonTotal);
            Assert.Greater(total, rayonTotal);
            Assert.AreEqual(rayon2Total, rayonTotal);

            args.Clear();
            Dbg.Debug("************************************************************");
            DebugTimer.Start("get all settlements");
            settlementView = LookupCache.Get(DummyLookupTables.Settlement, 0, args);
            DebugTimer.Stop();
            rayonTotal = settlementView.Count;
            Dbg.Debug("got {0} settlements", rayonTotal);
            Assert.AreEqual(total, rayonTotal);
        }

    }
}