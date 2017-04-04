using System;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Enums;

[assembly: CLSCompliant(true)]

namespace bv.common.Configuration
{
    [CLSCompliant(true)]
    public class ConnectionCredentials : IComparable
    {

        protected string m_ConnectionStringFinal;
        private string m_SQLConnectionString;
        private string m_SQLServer;
        private string m_SQLDatabase;
        private string m_SQLUser;
        private string m_SQLPassword;
        private string m_Prefix = "SQL";
        public delegate void CredentialChangeHandler(string keyName, string oldValue, string newValue);
        public event CredentialChangeHandler CredentialChange;
        public ConnectionCredentials()
        {
            Load(null);
            CreateConnectionString();
        }

        //public ConnectionCredentials(string server, string database, string user, string password, string connectionString, string prefix = "SQL")
        //{
        //    SetCredentials(connectionString, server, database, user, password, prefix);
        //}

        public ConnectionCredentials(string configFile, string prefix = "SQL")
        {
            Load(configFile, prefix);
            CreateConnectionString();
        }
        public virtual void SetCredentials(string connectionString = null, string server = null, string database = null, string user = null, string password = null, string prefix = "SQL")
        {

            Load(null, prefix);
            m_ConnectionStringFinal = null;
            if (!string.IsNullOrEmpty(connectionString))
            {
                m_SQLConnectionString = connectionString;
            }
            if (!string.IsNullOrEmpty(server))
            {
                m_SQLServer = server;
            }
            if (!string.IsNullOrEmpty(database))
            {
                m_SQLDatabase = database;
            }
            if (!string.IsNullOrEmpty(user))
            {
                m_SQLUser = user;
            }
            if (!string.IsNullOrEmpty(password))
            {
                m_SQLPassword = password;
            }
            CreateConnectionString();
        }
        public void Clear()
        {
            m_SQLServer = null;
            m_SQLDatabase = null;
            m_SQLUser = null;
            m_SQLPassword = null;
            WriteToRegistry(GetKey("User"), "");
            WriteToRegistry(GetKey("Password"), "");
            WriteToRegistry(GetKey("Server"), "");
            WriteToRegistry(GetKey("Database"), "");
            SaveToFile(null);
            if (m_ConfigFilesToSave != null)
            {
                foreach (string configFile in m_ConfigFilesToSave)
                {
                    SaveToFile(configFile);
                }
            }
        }
        private string CreateConnectionString(string baseConnectionString)
        {
            if (baseConnectionString != null)
            {
                baseConnectionString = m_SQLConnectionString;
                if (m_SQLUser != null)
                {
                    baseConnectionString = baseConnectionString.Replace("{0}", m_SQLUser);
                }
                if (m_SQLPassword != null)
                {
                    baseConnectionString = baseConnectionString.Replace("{1}", m_SQLPassword);
                }
                if (m_SQLDatabase != null)
                {
                    baseConnectionString = baseConnectionString.Replace("{2}", m_SQLDatabase);
                }
                if (m_SQLServer != null)
                {
                    baseConnectionString = baseConnectionString.Replace("{3}", m_SQLServer);
                }
            }
            return (baseConnectionString);
        }

        public string CreateConnectionString()
        {
            if (string.IsNullOrEmpty(m_ConnectionStringFinal))
            {
                m_ConnectionStringFinal = CreateConnectionString(m_SQLConnectionString);
                var parser = new ConnectionStringParser(m_ConnectionStringFinal);
                if (UseAsyncConnection)
                {
                    parser.SetItem("true", ConnectionStringPart.Async);
                }
                parser.SetItem("true", ConnectionStringPart.MARS);
                m_ConnectionStringFinal = parser.ConnectionString;
            }
            return (m_ConnectionStringFinal);
        }

        public string ConnectionString
        {
            get
            {
                if (m_ConnectionStringFinal == null)
                {
                    CreateConnectionString();
                }
                return m_ConnectionStringFinal;
            }
        }

        private string ReadFromRegistry(string valueName)
        {
            return RegistryHelper.ReadEidssValue(valueName);
        }

        private void WriteToRegistry(string valueName, string value)
        {
            RegistryHelper.WriteEidssValue(valueName, value);
        }

        private string GetKey(string baseKey)
        {
            return string.Format("{0}{1}", m_Prefix, baseKey);
        }
        private readonly ConfigWriter m_Config = AppConfigWriter.Instance;

        public void Init
            (string connectionString, string server, string database, string encryptedUser,
             string enryptedPassword)
        {
            m_ConnectionStringFinal = null;
            m_SQLDatabase = database;
            m_SQLServer = server;
            m_SQLUser = Cryptor.Decrypt(encryptedUser);
            if ((!string.IsNullOrEmpty(enryptedPassword)) && (!string.IsNullOrEmpty(m_SQLUser)))
            {
                m_SQLPassword = Cryptor.Decrypt(enryptedPassword, m_SQLUser);
            }
            if (string.IsNullOrEmpty(connectionString))
            {
                m_SQLConnectionString = m_Config.GetItem(GetKey("ConnectionString"));
            }
            if (string.IsNullOrEmpty(m_SQLConnectionString))
            {
                m_SQLConnectionString = "Persist Security Info=False;User ID={0};Password={1};Initial Catalog={2};Data Source={3}";
            }
        }

        public void Load(string configFile, string prefix = "SQL")
        {
            m_Prefix = prefix;
            m_Config.Read(configFile);

            //reading SQLUser and SQLPassword from registry
            m_SQLUser = ReadFromRegistry(GetKey("User"));
            m_SQLPassword = ReadFromRegistry(GetKey("Password"));

            if (Utils.Str(configFile) == "")
            {
                m_SQLConnectionString = BaseSettings.ConnectionString;
                if (BaseSettings.ConnectionSource == 1 || Utils.IsEmpty(m_SQLUser) || Utils.IsEmpty(m_SQLPassword))
                {
                    m_SQLUser = Config.GetSetting(GetKey("User"));// BaseSettings.SqlUser;
                    m_SQLPassword = Config.GetSetting(GetKey("Password")); //BaseSettings.SqlPassword;
                }
                m_SQLDatabase = Config.GetSetting(GetKey("Database")); //BaseSettings.SqlDatabase;
                m_SQLServer = Config.GetSetting(GetKey("Server")); //BaseSettings.SqlServer;
            }
            else
            {
                m_SQLConnectionString = m_Config.GetItem(GetKey("ConnectionString"));
                if (BaseSettings.ConnectionSource == 1 || m_Config.GetItem("ConnectionSource") == "1")
                {
                    m_SQLUser = m_Config.GetItem(GetKey("User"));
                    m_SQLPassword = m_Config.GetItem(GetKey("Password"));
                }
                m_SQLDatabase = m_Config.GetItem(GetKey("Database"));
                m_SQLServer = m_Config.GetItem(GetKey("Server"));
            }
            Init(m_SQLConnectionString, m_SQLServer, m_SQLDatabase, m_SQLUser, m_SQLPassword);
            //Dbg.Assert(Utils.Str(Me.m_SQLConnectionString) <> "", "connection string is not defined")
            //if (!string.IsNullOrEmpty(m_SQLUser))
            //{
            //    m_SQLUser = Cryptor.Decrypt(m_SQLUser);
            //}
            //if ((!string.IsNullOrEmpty(m_SQLPassword)) && (!string.IsNullOrEmpty(m_SQLUser)))
            //{
            //    m_SQLPassword = Cryptor.Decrypt(m_SQLPassword, m_SQLUser);
            //}
            //if (string.IsNullOrEmpty(m_SQLConnectionString))
            //{
            //    m_SQLConnectionString = m_Config.GetItem(GetKey("ConnectionString"));
            //}
            //if (string.IsNullOrEmpty(m_SQLConnectionString))
            //{
            //    m_SQLConnectionString = "Persist Security Info=False;User ID={0};Password={1};Initial Catalog={2};Data Source={3}";
            //}
        }
        private string[] m_ConfigFilesToSave;
        public string[] ConfigFilesToSave
        {
            get
            {
                return m_ConfigFilesToSave;
            }
            set
            {
                m_ConfigFilesToSave = value;
            }
        }

        private void SaveToRegistry()
        {

            string sqlUserRegistry = Utils.Str(m_SQLUser); //ReadFromRegistry("SQLUser")
            if (sqlUserRegistry.Length > 0)
            {
                //USER
                string sqlUserDecrypt = string.Empty;
                string s = ReadFromRegistry(GetKey("User"));
                if (s.Length > 0)
                {
                    sqlUserDecrypt = Cryptor.Decrypt(s);
                }

                bool userChanged = false;
                if (m_SQLUser != null && !m_SQLUser.Equals(sqlUserDecrypt))
                {
                    WriteToRegistry(GetKey("User"), Cryptor.Encrypt(m_SQLUser));
                    userChanged = true;
                    if (CredentialChange != null)
                        CredentialChange(GetKey("User"), sqlUserDecrypt, m_SQLUser);
                }

                //PASSWORD
                string sqlPasswordRegistry = m_SQLPassword; //ReadFromRegistry("SQLPassword")
                if (sqlPasswordRegistry.Length > 0)
                {
                    string sqlPasswordDecrypt = string.Empty;
                    s = ReadFromRegistry(GetKey("Password"));
                    if (s.Length > 0)
                    {
                        sqlPasswordDecrypt = Cryptor.Decrypt(s, sqlUserDecrypt);
                    }
                    //we must change password if user was changed
                    if (m_SQLPassword != null && (userChanged || !(m_SQLPassword.Equals(sqlPasswordDecrypt))))
                    {
                        WriteToRegistry(GetKey("Password"), Cryptor.Encrypt(m_SQLPassword, m_SQLUser));
                        if (CredentialChange != null)
                            CredentialChange(GetKey("Password"), sqlPasswordDecrypt, m_SQLPassword);
                    }
                }
            }
            if (!Utils.IsEmpty(m_SQLServer) && ReadFromRegistry(GetKey("Server")).ToLowerInvariant() != m_SQLServer.ToLowerInvariant())
            {
                WriteToRegistry(GetKey("Server"), m_SQLServer);
            }
            if (!Utils.IsEmpty(m_SQLDatabase) && ReadFromRegistry(GetKey("Database")).ToLowerInvariant() != m_SQLDatabase.ToLowerInvariant())
            {
                WriteToRegistry(GetKey("Database"), m_SQLDatabase);
            }
        }
        public void Save()
        {
            if (!BaseSettings.UpdateConnectionInfo)
                return;
            SaveToRegistry();
            SaveToFile(null);
            if (m_ConfigFilesToSave != null)
            {
                foreach (string configFile in m_ConfigFilesToSave)
                {
                    SaveToFile(configFile);
                }
            }
        }
        public void SaveToFile(string configFile)
        {
            if (!BaseSettings.UpdateConnectionInfo)
                return;
            if (configFile != null)
            {
                if (System.IO.File.Exists(configFile))
                {
                    m_Config.Read(configFile);
                }
            }
            Dbg.ConditionalDebug(DebugDetalizationLevel.High, "Saving connection to file {0}", m_Config.FileName);
            m_Config.SetItem(GetKey("ConnectionString"), m_SQLConnectionString);

            m_Config.SetItem(GetKey("Database"), Utils.Str(m_SQLDatabase));
            m_Config.SetItem(GetKey("Server"), Utils.Str(m_SQLServer));
            if(Utils.IsEmpty(m_SQLUser))
               m_Config.SetItem(GetKey("User"), "");
            else
                m_Config.SetItem(GetKey("User"), Cryptor.Encrypt(m_SQLUser));
            if (Utils.IsEmpty(m_SQLPassword))
                m_Config.SetItem(GetKey("Password"), "");
            else
                m_Config.SetItem(GetKey("Password"), Cryptor.Encrypt(m_SQLPassword, Utils.Str(m_SQLUser)));
            m_Config.Save();
            Config.ReloadSettings();
        }

        public int CompareTo(object obj)
        {
            var anvil = obj as ConnectionCredentials;
            if (anvil == null)
                return (-1);
            return (String.CompareOrdinal(m_ConnectionStringFinal, anvil.m_ConnectionStringFinal));
        }
        protected bool m_UseAsyncConnection;
        public virtual bool UseAsyncConnection
        {
            get
            {
                return m_UseAsyncConnection;
            }
            set
            {
                m_UseAsyncConnection = value;
            }
        }
        public string SQLUser
        {
            get
            {
                return m_SQLUser;
            }
        }
        public string SQLDatabase
        {
            get
            {
                return m_SQLDatabase;
            }
        }
        public string SQLServer
        {
            get
            {
                return m_SQLServer;
            }
        }
        public string SQLPassword
        {
            get
            {
                return m_SQLPassword;
            }
        }

        public string SQLConnectionString
        {
            get
            {
                return m_SQLConnectionString;
            }
        }
        public bool IsCorrect
        {
            get
            {
                if (string.IsNullOrEmpty(m_SQLUser) || string.IsNullOrEmpty(m_SQLPassword) || string.IsNullOrEmpty(m_SQLDatabase) || string.IsNullOrEmpty(m_SQLServer))
                {
                    return (false);
                }
                return (true);
            }
        }
    }
}
