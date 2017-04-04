using System;
using System.Data;
using System.IO;
using bv.common.db.Core;
using bv.common.Diagnostics;

namespace EIDSS.Tests.Core
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

            string[] scripts = text.Split(new string[] { "\r\n" + "GO" + "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return scripts;
        }
        public static void RunScript(string fileName)
        {
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

        }
    }
}