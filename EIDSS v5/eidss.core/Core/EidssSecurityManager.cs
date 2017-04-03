using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BLToolkit.Data;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using DataException = BLToolkit.Data.DataException;
using bv.common.Diagnostics;
using System.Text.RegularExpressions;

namespace eidss.model.Core
{
    namespace Security
    {
        public partial class EidssSecurityManager : ISecurityManager
        {
            //private GetPermissionName m_PermissionName;

            private static string ACCESS_TO_PERSONAL_DATA = "Access To Personal Data";
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
                operationName[Convert.ToInt64(ObjectOperation.AccessToPersonalData)] = ACCESS_TO_PERSONAL_DATA;
                foreach (DataRow row in dt.Rows)
                {
                    object value = row["intPermission"];
                    if (value == DBNull.Value)
                    {
                        continue;
                    }
                    string sf = ((eidss.model.Enums.EIDSSPermissionObject)(Convert.ToInt32(row["idfsSystemFunction"]))).ToString();
                    var op = (long)(row["idfsObjectOperation"]);
                    sf += ("." + operationName[op]);
                    permissions[sf] = (Convert.ToInt32(value) == 2);
                }
                return permissions;
            }

            public IDictionary<string, bool> GetPermissions(object userId)
            {
                var permissions = new Dictionary<string, bool>();
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
                            throw DbModelException.Create(e as DataException);
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
                        var table = manager.SetCommand("select idfsDiagnosis from dbo.fnGetPermissionOnDiagnosis(@ObjectOperation, @Employee) where intPermission = 1",
                                                    manager.Parameter("@ObjectOperation", Convert.ToInt64(ObjectOperation.Read)),
                                                    manager.Parameter("@Employee", userId)
                            ).ExecuteDataTable();
                        return (from DataRow row in table.Rows
                                select (long) row["idfsDiagnosis"]).ToList();
                        //return manager.SetCommand("select idfsDiagnosis from dbo.fnGetPermissionOnDiagnosis(@ObjectOperation, @Employee) where intPermission = 1",
                        //                            manager.Parameter("@ObjectOperation", Convert.ToInt64(ObjectOperation.Read)),
                        //                            manager.Parameter("@Employee", userId)
                        //    ).ExecuteList<long>();
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(e as DataException);
                        }
                        throw;
                    }
                }
            }

            protected object PasswordHash(string password)
            {
                return SHA1.Create().ComputeHash(Encoding.Unicode.GetBytes(password));
            }

            private object CalculatePassword(string password, byte[] challenge)
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

            private int EvaluateHash(string password, ref object hash)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
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
                            throw DbModelException.Create(e as DataException);
                        }
                        throw;
                    }
                }

                return 0;
            }

            private int CheckVersion()
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    try
                    {
                        manager.SetSpCommand("dbo.spCheckVersion",
                                             manager.Parameter("@ModuleName", EidssUserContext.ApplicationName),
                                             manager.Parameter("@ModuleVersion", EidssUserContext.Version),
                                             manager.Parameter(ParameterDirection.Output, "@Result", 0)
                            ).ExecuteNonQuery();
                        return Convert.ToInt32(manager.Parameter("@Result").Value);
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(e as DataException);
                        }
                        throw;
                    }
                }
            }

            private void setEidssUser(DataTable dt, string userName, string organization)
            {
                EidssUserContext.User.EmployeeID = Utils.ToNullableLong(dt.Rows[0]["idfPerson"]);
                EidssUserContext.User.FullName = (Utils.Str(dt.Rows[0]["strFamilyName"]) + " " + Utils.Str(dt.Rows[0]["strFirstName"]) + " " +
                                                  Utils.Str(dt.Rows[0]["strSecondName"]));
                EidssUserContext.User.FirstName = Utils.Str(dt.Rows[0]["strFirstName"]);
                EidssUserContext.User.SecondName = Utils.Str(dt.Rows[0]["strSecondName"]);
                EidssUserContext.User.LastName = Utils.Str(dt.Rows[0]["strFamilyName"]);

                EidssUserContext.User.LoginName = userName;
                EidssUserContext.User.ID = dt.Rows[0]["idfUserID"];
                EidssUserContext.User.Organization = organization;
                EidssUserContext.User.OrganizationID = dt.Rows[0]["idfInstitution"];

                EidssUserContext.User.Permissions = GetPermissions(EidssUserContext.User.EmployeeID);
                EidssSiteContext.Instance.Clear();
                string siteID = EidssSiteContext.Instance.SiteID.ToString();
                //EidssUserContext.User.ObjectPermissions = GetObjectTypePermissions(EidssUserContext.User.EmployeeID)
            }

            public int LogIn(string organization, string userName, string password)
            {
                int res = CheckVersion();
                if (res != 0)
                {
                    return res;
                }

                object hash = null;
                res = EvaluateHash(password, ref hash);
                if (res != 0)
                {
                    return res;
                }
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    try
                    {
                        DataTable dt = manager.SetSpCommand("dbo.spLoginUser",
                                                            manager.Parameter("@Organization", organization),
                                                            manager.Parameter("@UserName", userName),
                                                            manager.Parameter("@Password", hash, DbType.Binary),
                                                            manager.Parameter(ParameterDirection.Output, "@Result", 0)
                            ).ExecuteDataTable();
                        res = Convert.ToInt32(manager.Parameter("@Result").Value);
                        if (res == 0)
                        {
                            setEidssUser(dt, userName, organization);

                            EidssSiteContext.Instance.SetCustomMandatoryFields(GetCustomMandatoryFields());
                            EidssUserContext.User.SetForbiddenPersonalDataGroups(GetPersonalDataGroups());
                            EidssUserContext.User.SetDenyDiagnosis(GetDenyPermissionOnDiagnosis(EidssUserContext.User.EmployeeID));

                            //var denydiags = GetDenyPermissionOnDiagnosis(EidssUserContext.User.EmployeeID);
                            //denydiags.Add(784440000000); // - botulism
                            //EidssUserContext.User.SetDenyDiagnosis(denydiags);

                            //UserConfigWriter writer = new UserConfigWriter();
                            //writer.SetItem("Organization", organization);
                            //writer.Save();
                        }
                        return res;
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(e as DataException);
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

                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
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
                            setEidssUser(dt, userName, organization);
                            //ConfigWriter.Instance.Save();
                        }
                        return res;
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(e as DataException);
                        }
                        throw;
                    }
                }
            }

            public int SetPassword(object userID, string password)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
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
                            throw DbModelException.Create(e as DataException);
                        }
                        throw;
                    }
                }
            }

            public int GetIntPolicyValue(string name, int defaultValue)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    try
                    {
                        DataTable dt = manager.SetSpCommand("dbo.spSecurityPolicy_List",
                                             manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            ).ExecuteDataTable();
                        if (dt == null || dt.Rows.Count == 0)
                            return defaultValue;
                        return (int)dt.Rows[0][name];

                    }
                    catch (Exception e)
                    {
                        Dbg.Debug("error during retrieving security policy value {0}, default value {1} is returned. \r\n{2}", name, defaultValue, e.ToString());
                        return defaultValue;
                    }
                }
            }

            public void LogOut()
            {

                if (!(Utils.IsEmpty(EidssUserContext.User.ID)))
                {
                    SecurityLog.WriteToEventLogDB(EidssUserContext.User.ID, SecurityAuditEvent.Logoff, true, "EIDSS user log off", null, null, SecurityAuditProcessType.Eidss); //EIDSS user log off
                }
                try
                {
                    if (EidssUserContext.User.IsAuthenticated)
                    {
                        using (DbManager manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        {
                            manager.SetSpCommand("spLogoffUser",
                                                 manager.Parameter("@ClientID", EidssUserContext.ClientID),
                                                 manager.Parameter("@idfUserID", EidssUserContext.User.ID)).ExecuteNonQuery();
                        }
                        //EidssUserContext.Instance.ClearContext(DbManagerFactory.Factory.Create(EidssUserContext.Instance));
                        EidssUserContext.User.Clear();
                    }
                }
                catch
                {
                }
            }

            public bool ValidatePassword(string password)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    try
                    {
                        DataSet ds = manager.SetSpCommand("dbo.spSecurityPolicy_List",
                                             manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            ).ExecuteDataSet();
                        if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
                            return false;
                        DataTable dt = ds.Tables[0];
                        if ((int)dt.Rows[0]["intForcePasswordComplexity"] == 0)
                            return true;
                        dt = ds.Tables[1];
                        if (dt.Rows.Count == 0)
                            return true;
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
                            timeout = Convert.ToDouble(dt.Rows[0]["intAccountLockTimeout"]);
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
                        var result = manager.SetSpCommand("spUserLocked_TimeElapsed",
                                manager.Parameter("Organization", organization),
                                manager.Parameter("UserName", userName)
                            ).ExecuteScalar();

                        int timeout = 30;
                        if (result != null && !result.Equals(DBNull.Value))
                            int.TryParse(result.ToString(), out timeout);

                        return timeout;
                    }
                }
                catch
                {
                    return 15;
                }
            }


            public List<CustomMandatoryField> GetCustomMandatoryFields(long? idfsCountry = null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    try
                    {
                        DataTable dt = manager.SetSpCommand("dbo.spContext_GetCustomMandatoryFields",
                                              manager.Parameter("@idfsCountry", idfsCountry)

                             ).ExecuteDataTable();
                        List<CustomMandatoryField> result = new List<CustomMandatoryField>();

                        foreach (DataRow row in dt.Rows)
                        {
                            result.Add((CustomMandatoryField)Convert.ToInt64(row["idfMandatoryField"]));
                        }

                        return result;
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(e as DataException);
                        }
                        throw;
                    }
                }
            }


            private List<PersonalDataGroup> ParsePersonalDataGroups(DataTable dt)
            {
                List<PersonalDataGroup> result = new List<PersonalDataGroup>();

                foreach (DataRow row in dt.Rows)
                {
                    result.Add((PersonalDataGroup)Convert.ToInt64(row["idfPersonalDataGroup"]));
                }

                return result;
            }

            public List<PersonalDataGroup> GetPersonalDataGroups(long? idfUser = null, long? idfsCountry = null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    List<PersonalDataGroup> result = new List<PersonalDataGroup>();
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
                            permissions = (Dictionary<string,bool>)EidssUserContext.User.Permissions;
                        }

                        var personalGroups = ParsePersonalDataGroups(
                            manager.SetSpCommand("[dbo].[spContext_GetPersonalDataGroups]",
                                manager.Parameter("@idfsCountry", idfsCountry)

                            ).ExecuteDataTable());
                        //return personalGroups;

                        if (personalGroups.Count == 0)
                            return result;

                        char[] splitter = new char[] { '.' };

                        foreach (var permission in permissions)
                        {
                            string[] parser = permission.Key.Split(splitter);

                            if (parser[1].Equals(ACCESS_TO_PERSONAL_DATA, StringComparison.InvariantCultureIgnoreCase)
                                && !permission.Value)
                            {
                                bool _human = parser[0] == EIDSSPermissionObject.HumanCase.ToString();
                                bool _vet = parser[0] == EIDSSPermissionObject.VetCase.ToString();
                                foreach (var pg in personalGroups)
                                {
                                    if (pg.ToString().StartsWith("Human") && _human)
                                    {
                                        result.Add(pg);
                                        continue;
                                    }
                                    if (pg.ToString().StartsWith("Vet") && _vet)
                                    {
                                        result.Add(pg);
                                    }
                                }
                            }
                            if (personalGroups.Count == result.Count)
                                break;
                        }


                        return result;
                    }
                    catch (Exception e)
                    {
                        if (e is DataException)
                        {
                            throw DbModelException.Create(e as DataException);
                        }
                        throw;
                    }
                }
            }


           

        }
    }
}
