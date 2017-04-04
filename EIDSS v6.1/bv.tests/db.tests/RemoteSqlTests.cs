using bv.model.BLToolkit;
using bv.tests.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.db.tests
{
    [TestClass]
    public class RemoteSqlTests
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
        public void create_extenders_Test()
        {
            DbManagerFactory.SetRemoteFactory();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                var result = manager
                    .SetCommand("select @par1 - @par2",
                        manager.InputParameter("par1", 5),
                        manager.InputParameter("par2", 2)
                    )
                    .ExecuteScalar<int>();
            }
        }
    }
}