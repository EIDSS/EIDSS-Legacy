using System;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core.Security;
using eidss.model.Trace;

namespace eidss.model.WcfService
{
    public static class DataBaseChecker
    {
        private static readonly TraceHelper m_Trace = new TraceHelper(TraceHelper.ReportsCategory);
        private const string TraceTitle = @"Data Adapter";
        public static void CheckDbConnection()
        {
            try
            {
                string dbName;
                using (DbManagerProxy dbManager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    dbName = dbManager.Connection.Database;
                    dbManager.SetCommand(@"select 1").ExecuteNonQuery();
                }
                m_Trace.Trace(TraceTitle, "Database '{0}' connection checked.", dbName);
            }
            catch (Exception ex)
            {
                m_Trace.TraceError(ex);
            }
            
        }

        public static void Login()
        {
            var manager = new EidssSecurityManager();
            int resultCode = manager.LogIn(BaseSettings.DefaultOrganization, BaseSettings.DefaultUser,
                                           BaseSettings.DefaultPassword);
            if (resultCode != 0)
            {
                string err = string.Format("Could not login under user {0} from organization {1}.",
                                           BaseSettings.DefaultUser, BaseSettings.DefaultOrganization);
                throw new ApplicationException(err);
            }
            m_Trace.Trace(TraceTitle, "EIDSS login successfully.");
        }

        public static void Logout()
        {
            var manager = new EidssSecurityManager();
            manager.LogOut();

            m_Trace.Trace(TraceTitle, "EIDSS logout successfully.");
        }
    }
}