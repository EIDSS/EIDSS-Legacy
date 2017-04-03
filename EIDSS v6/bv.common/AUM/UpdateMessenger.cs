using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;

namespace bv.common.AUM
{
    public class UpdateMessenger
    {

        private SqlConnection m_Connection;

        public void SetConnection(SqlConnection connection)
        {
            m_Connection = connection;
            MessageWrited = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="credentials"></param>
        public UpdateMessenger(Configuration.ConnectionCredentials credentials)
        {
            SetConnection(new SqlConnection(credentials.ConnectionString));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CanConnect()
        {
            var result = false;
            try
            {
                if (m_Connection.State != ConnectionState.Open)
                {

                    var thread = new Thread(TryOpenConnection);
                    var manualResetEvent = new ManualResetEvent(false);
                    thread.Start(new Tuple<SqlConnection, ManualResetEvent>(m_Connection, manualResetEvent));
                    result = manualResetEvent.WaitOne(1000);

                    if (!result)
                    {
                        thread.Abort();
                    }
                }
                else
                {
                    result = true;
                }
                if (result)
                    MessageWrited = false;
                //result = m_Connection.State.Equals(ConnectionState.Open);


                //if (m_Connection.State != ConnectionState.Open)
                //{
                //   m_Connection.Open();
                //}
                //result = m_Connection.State.Equals(ConnectionState.Open);
            }
            catch (Exception e)
            {
                if (!MessageWrited)
                {
                    WriteToEventLogWindows(e.Message, EventLogEntryType.Error);
                    MessageWrited = true;
                }
            }
            return result;
        }
        private static void TryOpenConnection(object input)
        {
            var parameters = (Tuple<SqlConnection, ManualResetEvent>)input;

            try
            {
                parameters.Item1.Open();
                parameters.Item1.Close();
                parameters.Item2.Set();
            }
            catch
            {
                // Eat any exception, we're not interested in it 
            }
        }

        private bool MessageWrited { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="application">Приложение-инициатор апдейта</param>
        /// <param name="withDatabaseUpdate">Будет ли апдейтиться БД</param>
        public void CreateUpdateBlock(string clientID, string application, bool withDatabaseUpdate)
        {
            var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter("@ClientID", SqlDbType.NVarChar) {Value = clientID},
                                     new SqlParameter("@Application", SqlDbType.NVarChar){Value = application},
                                     new SqlParameter("@WithDatabaseUpdate", SqlDbType.Bit){Value = withDatabaseUpdate},
                                 };
            ExecuteStoredProc("spEIDSSUpdate_CreateUpdateBlock", parameters, false);
        }

        public const double ListenInterval = 10 * 1000;
        public const double ExitInterval = 10 * 60 * 1000;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Timers.Timer CreateTimerListener()
        {
            return new System.Timers.Timer(ListenInterval) { Enabled = false };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Timers.Timer CreateTimerExit()
        {
            return new System.Timers.Timer(ExitInterval) { Enabled = false };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CanUpdateBlock()
        {
            var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter("@Result", SqlDbType.Bit) {Direction = ParameterDirection.InputOutput}
                                 };
            var command = ExecuteStoredProc("spEIDSSUpdate_CanUpdateBlock", parameters, false);
            if (command == null)
                return true;
            var result = command.Parameters["@Result"].Value;
            return !((result != DBNull.Value) && (result != null)) || (bool)result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="application">Приложение-инициатор апдейта</param>
        public void CreateRunningApps(string clientID, string application)
        {
            var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter("@ClientID", SqlDbType.NVarChar) {Value = clientID},
                                     new SqlParameter("@Application", SqlDbType.NVarChar){Value = application}
                                 };
            ExecuteStoredProc("spEIDSSUpdate_CreateRunningApps", parameters, false);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteUpdateBlock()
        {
            ExecuteStoredProc("spEIDSSUpdate_DeleteUpdateBlock", null, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled"></param>
        public void ManageConnections(bool enabled)
        {
            var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter("@enable", SqlDbType.NVarChar) {Value = enabled},
                                 };
            ExecuteStoredProc("spEIDSSUpdate_ManageUsers", parameters, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parameters"></param>
        /// <param name="executeReader"> </param>
        /// <returns></returns>
        private SqlCommand ExecuteStoredProc(string procName, IEnumerable<SqlParameter> parameters, bool executeReader)
        {
            try
            {
                if (m_Connection.State != ConnectionState.Open) m_Connection.Open();
                var cmd = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = m_Connection,
                    CommandText = procName
                };
                if (parameters != null)
                {
                    foreach (var sqlParameter in parameters)
                    {
                        cmd.Parameters.Add(sqlParameter);
                    }
                }
                if (!executeReader) cmd.ExecuteNonQuery();
                return cmd;
            }
            catch (Exception e)
            {
                WriteToEventLogWindows(e.Message, EventLogEntryType.Error);
                return null;
            }
        }

        /// <summary>
        /// Запись в реестр Windows
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventLogEntryType"></param>
        public static void WriteToEventLogWindows(string message, EventLogEntryType eventLogEntryType)
        {
            using (var eventLog = new EventLog())
            {
                try
                {
                    eventLog.Source = "EIDSS/NS";
                    eventLog.WriteEntry(message, eventLogEntryType);
                }
                //писать более некуда
                // ReSharper disable EmptyGeneralCatchClause
                catch
                // ReSharper restore EmptyGeneralCatchClause
                {
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataTable GetRunningApps()
        {
            return FillTable("spEIDSSUpdate_GetRunningApps", null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="application">Приложение-инициатор апдейта</param>
        public bool CanRunApplication(string clientID, string application)
        {
            if (!CanConnect()) return true;
            var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter("@ClientID", SqlDbType.NVarChar) {Value = clientID},
                                     new SqlParameter("@Application", SqlDbType.NVarChar){Value = application},
                                     new SqlParameter("@Result", SqlDbType.Bit){Direction = ParameterDirection.Output}
                                 };
            var command = ExecuteStoredProc("spEIDSSUpdate_CanRunApplication", parameters, false);
            //если хранимку выполнить не удалось, то EIDSS работать может
            if (command == null) return true;
            var val = command.Parameters["@Result"].Value;
            if ((val == null) || (val == DBNull.Value)) return true;
            return (bool)val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        public DataTable GetCurrentLanguageInfo(string clientID)
        {
            var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter("@ClientID", SqlDbType.NVarChar) {Value = clientID}
                                 };
            return FillTable("spEIDSSUpdate_GetCurrentLanguage", parameters);
        }

        private DataTable FillTable(string spName, IEnumerable<SqlParameter> parameters)
        {
            try
            {
                var result = new DataTable();
                var command = ExecuteStoredProc(spName, parameters, true);
                var reader = command.ExecuteReader();
                result.Load(reader);
                return result;

            }
            catch (Exception e)
            {
                WriteToEventLogWindows(e.Message, EventLogEntryType.Error);
                return null;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="programName"></param>
        public void DeleteRunningApps(string clientID, string programName)
        {
            var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter("@ClientID", SqlDbType.NVarChar) {Value = clientID},
                                     new SqlParameter("@Application", SqlDbType.NVarChar){Value = programName}
                                 };
            ExecuteStoredProc("spEIDSSUpdate_DeleteRunningApps", parameters, false);
        }

    }
}
