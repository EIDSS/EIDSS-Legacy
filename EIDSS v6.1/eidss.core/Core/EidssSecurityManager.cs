using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using BLToolkit.Data;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using DataException = BLToolkit.Data.DataException;

[assembly: InternalsVisibleTo("bv.tests")]

namespace eidss.model.Core
{
    namespace Security
    {
        public partial class EidssSecurityManager
        {
            //private GetPermissionName m_PermissionName;

            private const string AccessToPersonalDataString = "Access To Personal Data";
            private static readonly object m_LockObject = new object();

            public bool AccessGranted
            {
                get { return EidssUserContext.User != null && EidssUserContext.User.IsAuthenticated; }
            }

            private Dictionary<string, bool> ParsePermissions(DataTable dt)
            {
                var permissions = new Dictionary<string, bool>();
                var operationName = new Dictionary<long, string>();
                operationName[Convert.ToInt64(ObjectOperation.Read)] = "Select";
                operationName[Convert.ToInt64(ObjectOperation.Write)] = "Update";
                operationName[Convert.ToInt64(ObjectOperation.Create)] = "Insert";
                operationName[Convert.ToInt64(ObjectOperation.Delete)] = "Delete";
                operationName[Convert.ToInt64(ObjectOperation.Execute)] = "Execute";
                operationName[Convert.ToInt64(ObjectOperation.AccessToPersonalData)] = AccessToPersonalDataString;
                foreach (DataRow row in dt.Rows)
                {
                    object value = row["intPermission"];
                    if (value == DBNull.Value)
                    {
                        continue;
                    }
                    string sf = ((EIDSSPermissionObject)(Convert.ToInt64(row["idfsSystemFunction"]))).ToString();
                    var op = (long)(row["idfsObjectOperation"]);
                    sf += ("." + operationName[op]);
                    permissions[sf] = (Convert.ToInt32(value) == 2);
                }
                return permissions;
            }

            public IDictionary<string, bool> GetPermissions(object userId)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {
                        return ParsePermissions(
                            manager.SetSpCommand("dbo.spEvaluatePermissions",
                                manager.Parameter("@idfEmployee", userId)
                                ).ExecuteDataTable());
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(null, e as DataException);
                        }
                        throw;
                    }
                }
            }

            private List<long> GetDenyPermissionOnDiagnosis(object userId)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {
                        DataTable table =
                            manager.SetCommand(
                                "select idfsDiagnosis from dbo.fnGetPermissionOnDiagnosis(@ObjectOperation, @Employee) where intPermission = 1",
                                manager.Parameter("@ObjectOperation", Convert.ToInt64(ObjectOperation.Read)),
                                manager.Parameter("@Employee", userId)
                                ).ExecuteDataTable();
                        return (from DataRow row in table.Rows
                                select (long)row["idfsDiagnosis"]).ToList();
                        //return manager.SetCommand("select idfsDiagnosis from dbo.fnGetPermissionOnDiagnosis(@ObjectOperation, @Employee) where intPermission = 1",
                        //                            manager.Parameter("@ObjectOperation", Convert.ToInt64(ObjectOperation.Read)),
                        //                            manager.Parameter("@Employee", userId)
                        //    ).ExecuteList<long>();
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(null, e as DataException);
                        }
                        throw;
                    }
                }
            }

            private Dictionary<long, List<EIDSSPermissionObject>> GetAvrQueryPermissions()
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {
                        var avrPermissions = new Dictionary<long, List<EIDSSPermissionObject>>();
                        DataTable table = manager.SetSpCommand("dbo.spAsSearchObjectToSystemFunctionSelectLookup",
                                manager.Parameter("@LangID", Localizer.lngEn)
                                ).ExecuteDataTable();
                        foreach (DataRow row in table.Rows)
                        {
                            var key = (long)row["idfsSearchObject"];
                            if (!avrPermissions.ContainsKey(key))
                            {
                                avrPermissions.Add(key, new List<EIDSSPermissionObject>());
                            }
                            avrPermissions[key].Add((EIDSSPermissionObject)row["idfsSystemFunction"]);
                        }
                        return avrPermissions;
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(null, e as DataException);
                        }
                        throw;
                    }
                }
            }

            protected internal object PasswordHash(string password)
            {
                return SHA1.Create().ComputeHash(Encoding.Unicode.GetBytes(password));
            }

            internal object CalculatePassword(string password, byte[] challenge)
            {
                var total = new List<byte>();
                SHA1 sha = SHA1.Create();
                byte[] passwordHash = sha.ComputeHash(Encoding.Unicode.GetBytes(password));

                int j = 0;
                int i;
                for (i = 0; i < passwordHash.Length; i++)
                {
                    byte current = passwordHash[i];
                    current = (byte)(current ^ challenge[j]);
                    total.Add(current);
                    j++;
                    if (j >= challenge.Length)
                    {
                        j = 0;
                    }
                }
                return sha.ComputeHash(total.ToArray());
            }

            internal int EvaluateHash(string password, ref object hash)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {
                        manager.SetSpCommand("dbo.spLoginChallenge",
                            manager.Parameter(ParameterDirection.Output, "@challenge", DbType.Binary, 1000)
                            ).ExecuteNonQuery();
                        object challenge = manager.Parameter("@challenge").Value;
                        if (Utils.IsEmpty(challenge))
                        {
                            return 2;
                        }

                        hash = CalculatePassword(password, (byte[])challenge);
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(null, e as DataException);
                        }
                        throw;
                    }
                }

                return 0;
            }

            internal int CheckVersion()
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {
                        manager.SetSpCommand("dbo.spCheckVersion",
                            manager.Parameter("@ModuleName", ModelUserContext.ApplicationName),
                            manager.Parameter("@ModuleVersion", ModelUserContext.Version),
                            manager.Parameter(ParameterDirection.Output, "@Result", 0)
                            ).ExecuteNonQuery();
                        return Convert.ToInt32(manager.Parameter("@Result").Value);
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(null, e as DataException);
                        }
                        throw;
                    }
                }
            }

            private void setEidssUser(DataTable dt)
            {
                EidssUserContext.User.EmployeeID = Utils.ToNullableLong(dt.Rows[0]["idfPerson"]);
                EidssUserContext.User.FullName = (Utils.Str(dt.Rows[0]["strFamilyName"]) + " " + Utils.Str(dt.Rows[0]["strFirstName"]) + " " +
                                                  Utils.Str(dt.Rows[0]["strSecondName"]));
                EidssUserContext.User.FirstName = Utils.Str(dt.Rows[0]["strFirstName"]);
                EidssUserContext.User.SecondName = Utils.Str(dt.Rows[0]["strSecondName"]);
                EidssUserContext.User.LastName = Utils.Str(dt.Rows[0]["strFamilyName"]);
                EidssUserContext.User.LoginName = Utils.Str(dt.Rows[0]["strUserName"]);
                EidssUserContext.User.ID = dt.Rows[0]["idfUserID"];
                EidssUserContext.User.OrganizationEng = Utils.Str(dt.Rows[0]["strLoginOrganization"]);
                EidssUserContext.User.OrganizationID = dt.Rows[0]["idfInstitution"];
                EidssUserContext.User.Permissions = GetPermissions(EidssUserContext.User.EmployeeID);
                EidssUserContext.User.Options.Deserialize(Utils.Str(dt.Rows[0]["strOptions"]));
                ForcedReplicationClient.Instance = null;
            }

            private void PerformLogin(DataTable loginData)
            {
                lock (m_LockObject)
                {
                    setEidssUser(loginData);
                    ModelUserContext.Instance.CreateContextData();
                    EidssSiteContext.Instance.Load();
                    EidssSiteContext.Instance.SetCustomMandatoryFields(GetCustomMandatoryFields());
                    EidssUserContext.User.SetForbiddenPersonalDataGroups(GetPersonalDataGroups());
                    EidssUserContext.User.SetDenyDiagnosis(GetDenyPermissionOnDiagnosis(EidssUserContext.User.EmployeeID));
                    EidssUserContext.User.SetAvrSearchObjectPermissions(GetAvrQueryPermissions());
                }
            }
            public string CreateTicket(long userId)
            {
                var dbType = DatabaseType.Main;
                var connectionCredentials = new ConnectionCredentials(null, "Avr");
                if (connectionCredentials.IsCorrect)
                {
                    DbManagerFactory.SetSqlFactory(connectionCredentials.ConnectionString, DatabaseType.AvrTicket);
                    using (var avrManager = DbManagerFactory.Factory[DatabaseType.AvrTicket].Create())
                    {
                        if (avrManager.TestConnection())
                            dbType = DatabaseType.AvrTicket;
                    }
                }
                using (DbManagerProxy manager = DbManagerFactory.Factory[dbType].Create(ModelUserContext.Instance))
                {
                    try
                    {
                        manager.SetSpCommand("dbo.spLoginCreateTicket",
                            manager.Parameter("@idfUserID", userId),
                            manager.Parameter(ParameterDirection.Output, "@strTicket", ""),
                            manager.Parameter(ParameterDirection.Output, "@Result", 0)
                            ).ExecuteNonQuery();
                        int res = Convert.ToInt32(manager.Parameter("@Result").Value);
                        if (res == 0)
                        {
                            return Utils.Str(manager.Parameter("@strTicket").Value);
                        }
                        return null;
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(null, e as DataException);
                        }
                        throw;
                    }
                }
            }

            private static int DedalockRepeatCount = 3;
            private int m_LoginTry;
            public int LogIn(string ticketId, bool repeatAfterDeadlock = true)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {

                        DataTable dt = manager.SetSpCommand("dbo.spLoginByTicket",
                            manager.Parameter("@strTicket", ticketId),
                            manager.Parameter("@intExpirationInterval", BaseSettings.TicketExpiration),
                            manager.Parameter(ParameterDirection.Output, "@Result", 0)
                            ).ExecuteDataTable();
                        int res = Convert.ToInt32(manager.Parameter("@Result").Value);
                        if (res == 0)
                            PerformLogin(dt);
                        m_LoginTry = 0;
                        return res;
                    }
                    catch (Exception e)
                    {
                        Dbg.Debug("login by ticket failed, error: {0}", e);
                        Dbg.Trace();
                        m_LoginTry++;
                        if (DbModelException.IsDeadlockException(e) && m_LoginTry < DedalockRepeatCount)
                        {

                            Debug.WriteLine("user login deadlock found");
                            return LogIn(ticketId, m_LoginTry < DedalockRepeatCount - 1);
                        }
                        if (e is DataException)
                        {
                            m_LoginTry = 0;
                            throw DbModelException.Create(null, e as DataException);
                        }
                        m_LoginTry = 0;
                        throw;
                    }
                }

            }

            public int LogIn(string organization, string userName, string password, Action onBeforeLogin = null, Action onSuccess = null)
            {
                int res = CheckVersion();
                if (res != 0)
                {
                    return res;
                }

                if (onBeforeLogin != null)
                    onBeforeLogin();

                object hash = null;
                res = EvaluateHash(password, ref hash);
                if (res != 0)
                {
                    return res;
                }
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {
                        DataTable dt = manager.SetSpCommand("dbo.spLoginUser",
                            manager.Parameter("@UserName", userName),
                            manager.Parameter("@Password", hash, DbType.Binary),
                            manager.Parameter(ParameterDirection.Output, "@Result", 0)
                            ).ExecuteDataTable();
                        res = Convert.ToInt32(manager.Parameter("@Result").Value);
                        if (res == 0)
                        {
                            if (BaseSettings.UseOrganizationInLogin && Utils.Str(organization).ToLowerInvariant() != Utils.Str(dt.Rows[0]["strLoginOrganization"]).ToLowerInvariant())
                            {
                                return 2;
                            }

                            if (onSuccess != null)
                                onSuccess();

                            PerformLogin(dt);
                        }
                        return res;
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(null, e as DataException);
                        }
                        throw;
                    }
                }
            }

            public int ChangePassword(string organization, string userName, string currentPassword, string newPassword)
            {
                //ConnectionManager.DefaultInstance.SetCredentials(null, SQLServer, SQLDatabase, SQLUser, SQLPassword);

                int res = CheckVersion();
                if (res != 0)
                {
                    return res;
                }

                object hash = null;
                res = EvaluateHash(currentPassword, ref hash);
                if (res != 0)
                {
                    return res;
                }

                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {
                        DataTable dt = manager.SetSpCommand("dbo.spChangePassword",
                            manager.Parameter("@Organization", organization),
                            manager.Parameter("@UserName", userName),
                            manager.Parameter("@CurrentPassword", hash),
                            manager.Parameter("@NewPassword", PasswordHash(newPassword)),
                            manager.Parameter(ParameterDirection.Output, "@Result", 0)
                            ).ExecuteDataTable();
                        res = Convert.ToInt32(manager.Parameter("@Result").Value);
                        if (res == 0)
                        {
                            //ConnectionManager.DefaultInstance.Save();
                            setEidssUser(dt);
                            //ConfigWriter.Instance.Save();
                        }
                        return res;
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(null, e as DataException);
                        }
                        throw;
                    }
                }
            }

            public int SetPassword(object userID, string password)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {
                        manager.SetSpCommand("dbo.spSetPassword",
                            manager.Parameter("@UserID", userID),
                            manager.Parameter("@Password", PasswordHash(password)),
                            manager.Parameter(ParameterDirection.Output, "@Result", 0)
                            ).ExecuteNonQuery();
                        return Convert.ToInt32(manager.Parameter("@Result").Value);
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(null, e as DataException);
                        }
                        throw;
                    }
                }
            }

            public int GetIntPolicyValue(string name, int defaultValue)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {
                        DataTable dt = manager.SetSpCommand("dbo.spSecurityPolicy_List",
                            manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            ).ExecuteDataTable();
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            return defaultValue;
                        }
                        return (int)dt.Rows[0][name];
                    }
                    catch (Exception e)
                    {
                        Dbg.Debug("error during retrieving security policy value {0}, default value {1} is returned. \r\n{2}", name,
                            defaultValue, e.ToString());
                        return defaultValue;
                    }
                }
            }

            public void LogOut()
            {
                if (!(Utils.IsEmpty(EidssUserContext.User.ID)))
                {
                    SecurityLog.WriteToEventLogDB(EidssUserContext.User.ID, SecurityAuditEvent.Logoff, true, "EIDSS user log off", null,
                        null, SecurityAuditProcessType.Eidss); //EIDSS user log off
                }
                try
                {
                    lock (m_LockObject)
                    {
                        if (EidssUserContext.User.IsAuthenticated)
                        {
                            using (DbManager manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                            {
                                manager.SetSpCommand("spLogoffUser",
                                    manager.Parameter("@ClientID", ModelUserContext.ClientID),
                                    manager.Parameter("@idfUserID", EidssUserContext.User.ID)).ExecuteNonQuery();
                            }
                            //EidssUserContext.Instance.ClearContext(DbManagerFactory.Factory.Create(EidssUserContext.Instance));
                            EidssUserContext.User.Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Dbg.Debug("error during logoff: {0}", ex);
                }
            }

            public bool ValidatePassword(string password)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {
                        DataSet ds = manager.SetSpCommand("dbo.spSecurityPolicy_List",
                            manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            ).ExecuteDataSet();
                        if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
                        {
                            return false;
                        }
                        DataTable dt = ds.Tables[0];
                        if ((int)dt.Rows[0]["intForcePasswordComplexity"] == 0)
                        {
                            return true;
                        }
                        dt = ds.Tables[1];
                        if (dt.Rows.Count == 0)
                        {
                            return true;
                        }
                        string passwordExpression = Utils.Str(dt.Rows[0]["strAlphabet"], "");
                        MatchCollection matches = Regex.Matches(password, passwordExpression);
                        return matches.Count > 0;
                    }
                    catch (Exception e)
                    {
                        Dbg.Debug("error during password validation: {0}", e.ToString());
                        return false;
                    }
                }
            }

            public double GetAccountLockTimeout()
            {
                try
                {
                    using (DbManager manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        DataTable dt = manager.SetSpCommand("spSecurityPolicy_List",
                            manager.Parameter("LangID", ModelUserContext.CurrentLanguage)
                            ).ExecuteDataTable();
                        double timeout = 15;
                        if (dt.Rows[0]["intAccountLockTimeout"] != DBNull.Value)
                        {
                            timeout = Convert.ToDouble(dt.Rows[0]["intAccountLockTimeout"]);
                        }
                        return timeout;
                    }
                }
                catch
                {
                    return 15;
                }
            }

            public int GetAccountLockTimeout(string organization, string userName)
            {
                try
                {
                    using (DbManager manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        object result = manager.SetSpCommand("spUserLocked_TimeElapsed",
                            manager.Parameter("Organization", organization),
                            manager.Parameter("UserName", userName)
                            ).ExecuteScalar();

                        int timeout = 30;
                        if (result != null && !result.Equals(DBNull.Value))
                        {
                            int.TryParse(result.ToString(), out timeout);
                        }

                        return timeout;
                    }
                }
                catch
                {
                    return 15;
                }
            }

            public List<CustomMandatoryField> GetCustomMandatoryFields(long? idfCustomizationPackage = null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {
                        DataTable dt = manager.SetSpCommand("dbo.spContext_GetCustomMandatoryFields",
                            manager.Parameter("@idfCustomizationPackage", idfCustomizationPackage)
                            ).ExecuteDataTable();

                        return (from DataRow row in dt.Rows
                                select (CustomMandatoryField)Convert.ToInt64(row["idfMandatoryField"])).ToList();
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(null, e as DataException);
                        }
                        throw;
                    }
                }
            }

            private List<PersonalDataGroup> ParsePersonalDataGroups(DataTable dt)
            {
                return (from DataRow row in dt.Rows
                        select (PersonalDataGroup)Convert.ToInt64(row["idfPersonalDataGroup"])).ToList();
            }

            public List<PersonalDataGroup> GetPersonalDataGroups(long? idfUser = null, long? idfCustomizationPackage = null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    var result = new List<PersonalDataGroup>();
                    try
                    {
                        Dictionary<string, bool> permissions;
                        if (EidssUserContext.User == null)
                        {
                            //check if user has restrictions
                            permissions = ParsePermissions(
                                manager.SetSpCommand("dbo.spEvaluatePermissions",
                                    manager.Parameter("@idfEmployee", idfUser)
                                    ).ExecuteDataTable());
                        }
                        else
                        {
                            permissions = (Dictionary<string, bool>)EidssUserContext.User.Permissions;
                        }

                        List<PersonalDataGroup> personalGroups = ParsePersonalDataGroups(
                            manager.SetSpCommand("[dbo].[spContext_GetPersonalDataGroups]",
                                manager.Parameter("@idfCustomizationPackage", idfCustomizationPackage)
                                ).ExecuteDataTable());
                        //return personalGroups;

                        if (personalGroups.Count == 0)
                        {
                            return result;
                        }

                        var splitter = new[] { '.' };

                        foreach (KeyValuePair<string, bool> permission in permissions)
                        {
                            string[] parser = permission.Key.Split(splitter);

                            if (parser[1].Equals(AccessToPersonalDataString, StringComparison.InvariantCultureIgnoreCase)
                                && !permission.Value)
                            {
                                bool human = parser[0] == EIDSSPermissionObject.HumanCase.ToString();
                                bool vet = parser[0] == EIDSSPermissionObject.VetCase.ToString();
                                foreach (PersonalDataGroup pg in personalGroups)
                                {
                                    if (pg.ToString().StartsWith("Human") && human)
                                    {
                                        result.Add(pg);
                                        continue;
                                    }
                                    if (pg.ToString().StartsWith("Vet") && vet)
                                    {
                                        result.Add(pg);
                                    }
                                }
                            }
                            if (personalGroups.Count == result.Count)
                            {
                                break;
                            }
                        }

                        return result;
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(null, e as DataException);
                        }
                        throw;
                    }
                }
            }
        }
    }
}
