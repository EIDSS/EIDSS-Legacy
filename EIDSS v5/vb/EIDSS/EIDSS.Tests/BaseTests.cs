using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.win.Core;
using EIDSS.Reports.BaseControls.Transaction;
using NUnit.Extensions.Forms;
using NUnit.Framework;
using GlobalSettings=bv.common.GlobalSettings;

namespace EIDSS.Tests
{
    [TestFixture]
    public class BaseTests : NUnitFormTest
    {
        //private const string m_GetQueryIdSQL =
//            @"select top 1 idflQuery from [dbo].[tasQuery]";
        private const string GetQueryIdSql =
                    @"select idflQuery from [dbo].[tasQuery] where strFunctionName = 'fnRAMHumanCaseList'";

        private long m_QueryId = -1;

        public long QueryId
        {
            get { return m_QueryId; }
        }

        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
            Assembly.GetCallingAssembly();

            ClassLoader.Init("eidss*.dll", ".\\");
            /*
            string location = Assembly.GetExecutingAssembly().CodeBase.ToLower(CultureInfo.InvariantCulture);
            location = location.Replace("file:///", "");
            location = location.Substring(0, location.LastIndexOf('/'));
            location = location.Replace("/", "\\");

            AppStructure.Init("eidss*.dll", location);
            
             * */
            GlobalSettings.Init("test", "test", "test");
            GlobalSettings.AppName = "eidss";
            GlobalSettings.CurrentLanguage = GlobalSettings.lngEn;

            WinClient.Init();
            if (
                ClientAccessor.SecurityManager.LogIn(BaseSettings.DefaultOrganization, BaseSettings.DefaultUser,
                                                     BaseSettings.DefaultPassword, null, null, null, null, false) != 0)
                throw (new Exception("login failed"));
            EIDSS_LookupCacheHelper.Init();

            foreach (KeyValuePair<string, string> pair in CultureInfoEx.ExistingLanguages)
            {
                if (!GlobalSettings.SupportedLanguages.ContainsKey(pair.Key))
                {
                    GlobalSettings.SupportedLanguages.Add(pair.Key, pair.Value);
                }
            }

            using (SqlConnection connection = new SqlConnection(ConnectionManager.DefaultInstance.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(GetQueryIdSql))
                {
                    command.Connection = connection;
                    m_QueryId = (long) command.ExecuteScalar();
                }
            }
        }

        
    }
}