using bv.common.Configuration;
using bv.model.BLToolkit;

namespace eidss.model.Helpers
{
    public static class ArchiveSqlHelper
    {
        public static void InitSqlFactory()
        {
            if (DbManagerFactory.Factory[DatabaseType.Archive] == null)
            {
                DbManagerFactory.SetSqlFactory(GetCredentials().ConnectionString, DatabaseType.Archive);
            }
        }

        public static bool IsCredentialsCorrect()
        {
            return GetCredentials().IsCorrect;
        }

        private static ConnectionCredentials GetCredentials()
        {
            var credentials = new ConnectionCredentials(null, "Archive");
            return credentials;
        }
    }
}