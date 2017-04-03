using System;
using System.IO;
using BLToolkit.Data;
using bv.common.Configuration;
using BLToolkit.Data.DataProvider;

namespace bv.tests.Core
{
    class ScriptLoader
    {
         
        private static string[] LoadScript(string fName)
        {
            string text;
            using (StreamReader sr = new StreamReader(fName))
            {
                text = sr.ReadToEnd();
                sr.Close();
            }
            var separators = new string[] {"GO" + Environment.NewLine, "go" + Environment.NewLine, "Go" + Environment.NewLine, "gO" + Environment.NewLine};
            string[] scripts = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return scripts;
        }
        public static void RunScript(string fileName, string connectionString = null)
        {
            if (connectionString == null)
                connectionString = Config.GetSetting("TestConnectionString", "");
            using (DbManager manager = new DbManager(new SqlDataProvider(), connectionString))
            {
                string[] scripts = LoadScript(fileName);
                foreach (string script in scripts)
                {
                    if (String.IsNullOrWhiteSpace(script))
                        continue;
                    manager
                        .SetCommand(script.Trim())
                        .ExecuteNonQuery();
                }
            }

            /*
            IDbConnection m_Connection = ConnectionManager.DefaultInstance.Connection;
            IDbCommand cmd = m_Connection.CreateCommand();
            string[] scripts = LoadScript(fileName);
            cmd.CommandType = CommandType.Text;
            try
            {
                if  (m_Connection.State!= ConnectionState.Open)
                      m_Connection.Open();
                foreach (string script in scripts)
                {
                    cmd.CommandText = script;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Dbg.Debug("error during script loading, script - {0}, error - {1}", fileName , ex);
            }
            finally
            {
                m_Connection.Close();
            }
            */
        }
    }
}
