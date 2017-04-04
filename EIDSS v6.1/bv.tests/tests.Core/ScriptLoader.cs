using System;
using System.Collections.Generic;
using System.IO;
using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using bv.common.Configuration;

namespace bv.tests.Core
{
    internal class ScriptLoader
    {
        public static IEnumerable<string> LoadScript(string fName)
        {
            string text;
            using (var sr = new StreamReader(fName))
            {
                text = sr.ReadToEnd();
                sr.Close();
            }
            var separators = new[]
                {"GO" + Environment.NewLine, "go" + Environment.NewLine, "Go" + Environment.NewLine, "gO" + Environment.NewLine};
            string[] scripts = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return scripts;
        }

        public static void RunScript(string fileName, string connectionString = null)
        {
            if (connectionString == null)
            {
                connectionString = Config.GetSetting("TestConnectionString");
            }
            using (var manager = new DbManager(new SqlDataProvider(), connectionString))
            {
                IEnumerable<string> scripts = LoadScript(fileName);
                foreach (string script in scripts)
                {
                    if (String.IsNullOrWhiteSpace(script))
                    {
                        continue;
                    }

                    string commandText = script.Trim();
                    try
                    {
                        manager
                            .SetCommand(commandText)
                            .ExecuteNonQuery();
                    }
                    catch (Exception )
                    {
                        Console.WriteLine(@"Error while executing script :");
                        Console.WriteLine(commandText);
                        throw;
                    }
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