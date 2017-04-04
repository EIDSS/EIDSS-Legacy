using System;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Web;
using System.Collections.Generic;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.model.BLToolkit;
using System.Threading;

namespace bv.model.Model.Core
{
    public delegate bool IsStartReplicationQuestionDelegate();
    public delegate void StartReplicationDelegate();

    public delegate ModelUserContext CreateContextDelegate();

    [Serializable]
    public class ModelUserContext : IDisposable
    {
        private static string g_ClientID;
        //private static string m_host;

        protected ModelUserContext()
        {
            //CreateContextData();
        }


        public static string ReadonlyWebClientID
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Session != null)
                    {
                        return HttpContext.Current.Session.SessionID;
                    }
                    try
                    {
                        if (HttpContext.Current.Request.Cookies["ClientID"] != null && !String.IsNullOrEmpty(HttpContext.Current.Request.Cookies["ClientID"].Value))
                        {
                            return HttpContext.Current.Request.Cookies["ClientID"].Value;
                        }
                    }
                    catch (HttpException)
                    {
                        return "";
                    }
                }
                return "";
            }
        }

        public static string ClientID
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Session != null)
                    {
                        return HttpContext.Current.Session.SessionID;
                    }
                    try
                    {
                        /*if (HttpContext.Current.Response.Cookies["ClientID"] != null && !String.IsNullOrEmpty(HttpContext.Current.Response.Cookies["ClientID"].Value))
                        {
                            var s = HttpContext.Current.Response.Cookies["ClientID"].Value;
                            return s;
                        }*/
                        if (HttpContext.Current.Request.Cookies["ClientID"] != null && !String.IsNullOrEmpty(HttpContext.Current.Request.Cookies["ClientID"].Value))
                        {
                            var s = HttpContext.Current.Request.Cookies["ClientID"].Value;
                            return s;
                        }
                    }
                    catch (HttpException)
                    {
                    }
                    /*if (HttpContext.Current.Response.Cookies["formsauth"] != null && !String.IsNullOrEmpty(HttpContext.Current.Response.Cookies["formsauth"].Value))
                    {
                        var s = HttpContext.Current.Response.Cookies["formsauth"].Value;
                        return s.GetHashCode().ToString("X");
                        var ticket = System.Web.Security.FormsAuthentication.Decrypt(s);
                        if (ticket != null)
                        {
                            return ticket.UserData;
                        }
                    }
                    if (HttpContext.Current.Request.Cookies["formsauth"] != null && !String.IsNullOrEmpty(HttpContext.Current.Request.Cookies["formsauth"].Value))
                    {
                        var s = HttpContext.Current.Request.Cookies["formsauth"].Value;
                        return s.GetHashCode().ToString("X");
                        var ticket = System.Web.Security.FormsAuthentication.Decrypt(s);
                        if (ticket != null)
                        {
                            return ticket.UserData;
                        }
                    }*/
                }
                if (string.IsNullOrEmpty(g_ClientID))
                {
                    g_ClientID = Config.GetSetting("ClientID", null);
                }
                if (string.IsNullOrEmpty(g_ClientID))
                {
                    g_ClientID = GetDefaultEIDSSClientID();
                }
                if (string.IsNullOrEmpty(g_ClientID))
                {
                    g_ClientID = GetMacAddress();
                }
                if (string.IsNullOrEmpty(g_ClientID))
                {
                    g_ClientID = DefaultClientID;
                }
                return g_ClientID;
            }
            set { g_ClientID = value; }//setter for tests
        }

        private static string GetDefaultEIDSSClientID()
        {
            string user = Environment.UserName;
            string clientIDKeyName = string.Format("{0}-{1}", Environment.UserName, DefaultClientID);
            string clientID = RegistryHelper.ReadEidssValue(clientIDKeyName);
            if (string.IsNullOrEmpty(clientID))
            {
                RegistryHelper.WriteEidssValue(clientIDKeyName, Guid.NewGuid().ToString());
                clientID = RegistryHelper.ReadEidssValue(clientIDKeyName);
            }
            return clientID;
        }

        private const string DefaultClientID = "DefaultClientID";
        private const string Eidss = "eidss";
        private string m_ApplicationName = Eidss;

        public static string ApplicationName
        {
            get
            {
                if (Instance != null)
                {
                    return Instance.m_ApplicationName;
                }
                else
                {
                    return Eidss;
                }
            }
            set
            {
                if (Instance != null)
                {
                    Instance.m_ApplicationName = value;
                }
            }
        }

        public static string Version
        {
            get
            {
                Assembly a = Assembly.GetEntryAssembly();
                if (a == null)
                {
                    a = Assembly.GetExecutingAssembly();
                }
                if (a == null)
                {
                    a = Assembly.GetCallingAssembly();
                }
                if (a != null)
                {
                    return a.GetName().Version.ToString();
                }
                else
                {
                    return "0.0.0.0";
                }
            }
        }

        private string m_CurrentLanguage = Localizer.lngEn;

        public static string CurrentLanguage
        {
            get
            {
                if (Instance != null)
                {
                    return Instance.m_CurrentLanguage;
                }
                return Localizer.lngEn;
            }
            set
            {
                if (Instance != null)
                {
                    Instance.m_CurrentLanguage = value;
                }
            }
        }

        private bool m_SmartphoneContext = false;
        public static bool SmartphoneContext
        {
            get
            {
                if (Instance != null)
                {
                    return Instance.m_SmartphoneContext;
                }
                return false;
            }
            set
            {
                if (Instance != null)
                {
                    Instance.m_SmartphoneContext = value;
                }
            }
        }

        private static string GetMacAddress()
        {
            try
            {
                string macAddress = string.Empty;
                const int MIN_MAC_ADDR_LENGTH = 12;
                long maxSpeed = -1;

                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    Dbg.Debug(
                        " MAC Address: " + nic.GetPhysicalAddress() +
                        " Type: " + nic.NetworkInterfaceType);

                    string tempMac = nic.GetPhysicalAddress().ToString();
                    if (macAddress == string.Empty && nic.Speed > maxSpeed &&
                        !string.IsNullOrEmpty(tempMac) &&
                        tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                    {
                        Dbg.Debug("MAC address is found : MAC: {0} , Max Speed = {1}", tempMac, nic.Speed);
                        maxSpeed = nic.Speed;
                        macAddress = tempMac;
                    }
                }
                return macAddress;
            }
            catch (Exception ex)
            {
                Dbg.Debug("can't got MAC Address: {0}", ex);
                return null;
            }
        }

        //        private static string GetMacAddress()
        //        {
        //            try
        //            {
        //                string macAddress = string.Empty;
        //                var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        //                ManagementObjectCollection moc = mc.GetInstances();
        //                Dbg.Debug("Geting Mac address:");
        //                foreach (ManagementObject mo in moc)
        //                {
        //                    Dbg.Debug("Mac address: {0}; Enabled = {1}", mo["MacAddress"], mo["IPEnabled"] );

        //                    if (macAddress == string.Empty) // only return MAC Address from first card
        //                    {
        //                        if (Convert.ToBoolean(mo["IPEnabled"]))
        //                        {
        //                            macAddress = mo["MacAddress"].ToString();
        //                        }
        //                        mo.Dispose();
        //                    }
        //                }
        //                macAddress = macAddress.Replace(":", "");
        //                return macAddress;

        //            }
        //            catch (Exception ex)
        //            {
        //                Dbg.Debug("can't got MAC Address: {0}", ex);
        //                return null;
        //            }
        //        }

        private static ModelUserContext g_Instance;
        private static readonly int CheckIntervalSeconds = Config.GetIntSetting("CheckIntervalSeconds", 300);
        private static readonly int LifetimeSeconds = Config.GetIntSetting("LifetimeSeconds", 1200);
        private static Dictionary<string, ModelUserContext> g_InstanceStateless = new Dictionary<string, ModelUserContext>();
        private static Dictionary<string, object> g_InstanceSiteContextStateless = new Dictionary<string, object>();
        private static object g_lock = new object();

        //public static Dictionary<string, object> InstanceSiteContextStateless { get { return g_InstanceSiteContextStateless; } }
        public static T AddSiteContext<T>(string key, T objIfNotFound)
            where T : class
        {
            T ret = null;
            lock (g_lock)
            {
                if (g_InstanceSiteContextStateless.ContainsKey(key))
                {
                    ret = g_InstanceSiteContextStateless[key] as T;
                }
                else
                {
                    ret = objIfNotFound;
                    g_InstanceSiteContextStateless.Add(key, ret);
                }
            }
            return ret;
        }


        #region Deleteng objects by timeout
        private DateTime LastAccess { get; set; }

        private static void DeleteByTimeout()
        {
            var listForDispose = new List<ModelUserContext>();
            lock (g_lock)
            {
                try
                {
                    var now = DateTime.Now;
                    foreach (var c in g_InstanceStateless)
                    {
                        if ((now - c.Value.LastAccess).TotalSeconds > LifetimeSeconds)
                        {
                            listForDispose.Add(c.Value);
                        }
                    }
                }
                catch
                {
                }
            }

            try
            {
                listForDispose.ForEach(
                    c => 
                    { 
                        try 
                        { 
                            c.Close(); 
                        }
                        catch
                        {
                        }
                    }
                    );
                listForDispose.Clear();
            }
            catch
            {
            }
        }
        private static Timer gDeletedTimer = new Timer(t =>
        {
            DeleteByTimeout();
            gDeletedTimer.Change(CheckIntervalSeconds * 1000, Timeout.Infinite);
        }, null, CheckIntervalSeconds * 1000, Timeout.Infinite);

        #endregion

        public static ModelUserContext Instance
        {
            get
            {
                lock (g_lock)
                {
                    ModelUserContext ret = null;
                    if (HttpContext.Current != null)
                    {
                        if (HttpContext.Current.Session != null)
                        {
                            ret = HttpContext.Current.Session["UserContext"] as ModelUserContext;
                            if (ret == null)
                            {
                                ret = Creator == null ? null : Creator();
                                HttpContext.Current.Session["UserContext"] = ret;
                            }
                        }
                        else
                        {
                            if (g_InstanceStateless.ContainsKey(ClientID))
                            {
                                ret = g_InstanceStateless[ClientID];
                            }
                            else
                            {
                                ret = Creator == null ? null : Creator();
                                g_InstanceStateless.Add(ClientID, ret);
                            }
                        }
                    }
                    else
                    {
                        ret = g_Instance;
                        if (ret == null)
                        {
                            ret = Creator == null ? null : Creator();
                            g_Instance = ret;
                        }
                    }

                    if (ret != null)
                    {
                        ret.LastAccess = DateTime.Now;
                    }
                    return ret;
                }
            }
            protected set
            {
                lock (g_lock)
                {
                    if (HttpContext.Current != null)
                    {
                        if (HttpContext.Current.Session != null)
                        {
                            HttpContext.Current.Session["UserContext"] = value;
                        }
                        else
                        {
                            if (g_InstanceStateless.ContainsKey(ClientID))
                            {
                                g_InstanceStateless[ClientID] = value;
                            }
                            else
                            {
                                g_InstanceStateless.Add(ClientID, value);
                            }
                        }
                    }
                    else
                    {
                        g_Instance = value;
                    }
                }
            }
        }

        public static bool IsWebContext
        {
            get { return HttpContext.Current != null; }
        }

        static ModelUserContext()
        {
        }

        public IsStartReplicationQuestionDelegate IsStartReplicationQuestion { get; protected set; }
        public StartReplicationDelegate StartReplication { get; protected set; }
        protected static CreateContextDelegate Creator { get; set; }

        public virtual void CreateContextData()
        {
        }

        public virtual void DeleteContextData()
        {
        }

        public virtual void SetContext(DbManagerProxy manager)
        {
        }

        public virtual void ClearContext(DbManagerProxy manager)
        {
        }

        public virtual long Audit(DbManagerProxy manager, params object[] auditData)
        {
            return 0;
        }

        public virtual void Event(DbManagerProxy manager, int isProcessed, params object[] eventData)
        {
        }

        public virtual void Filtration(long id)
        {
        }

        public virtual bool CanDo(string permission)
        {
            return true;
        }

        public virtual IUser CurrentUser
        {
            get { return null; }
        }

        public string DatabaseConnectionString { get; protected set; }
        public bool IsArchiveMode { get; protected set; }

        public void SetArchiveMode(string connString)
        {
            IsArchiveMode = true;
            DatabaseConnectionString = connString;
        }

        public void ResetArchiveMode()
        {
            IsArchiveMode = false;
            DatabaseConnectionString = "";
        }

        #region IDisposable Members

        private bool m_bDisposed;

        private void RemoveFromStateContext()
        {
            lock (g_lock)
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Session != null)
                    {
                        if (HttpContext.Current.Session["UserContext"] != null)
                        {
                            HttpContext.Current.Session.Remove("UserContext");
                        }
                    }
                }
                else if (g_Instance == this)
                {
                    g_Instance = null;
                }

                string keyToDelete = null;
                foreach (var c in g_InstanceStateless)
                {
                    if (c.Value == this)
                    {
                        keyToDelete = c.Key;
                        break;
                    }
                }
                if (keyToDelete != null)
                {
                    g_InstanceStateless.Remove(keyToDelete);

                    if (g_InstanceSiteContextStateless.ContainsKey(keyToDelete))
                    {
                        g_InstanceSiteContextStateless.Remove(keyToDelete);
                    }
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                RemoveFromStateContext();
                DeleteContextData();
            }
            GC.SuppressFinalize(this);
        }

        ~ModelUserContext()
        {
            RemoveFromStateContext();
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(!m_bDisposed);
            m_bDisposed = true;
        }
        
        #endregion
    }
}
