using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using bv.common.Core;
using bv.model.BLToolkit;
using System.Reflection;
using bv.common.Diagnostics;
#if !MONO
using System.Web;
using System.Management;
using bv.common.Configuration;
#endif

namespace bv.model.Model.Core
{
    public delegate int IsProcessedDelegate();
    public delegate ModelUserContext CreateContextDelegate();

    [Serializable]
    public class ModelUserContext : IDisposable
    {
        protected static string m_ClientID;
        protected ModelUserContext(string clientID)
        {
            m_ClientID = clientID;
            CreateContextData();
        }
        public static string ClientID
        {
            get
            {

#if !MONO
                lock (g_lock)
                {
                    if (HttpContext.Current != null && HttpContext.Current.Session != null)
                        return HttpContext.Current.Session.SessionID;
                }
                if (string.IsNullOrEmpty(m_ClientID))
                {
                    m_ClientID = Config.GetSetting("ClientID", null);
                }
#endif
                if (string.IsNullOrEmpty(m_ClientID))
                {
                    m_ClientID = GetDefaultEIDSSClientID();
                }
                if (string.IsNullOrEmpty(m_ClientID))
                {
                    m_ClientID = GetMacAddress();
                }
                if (string.IsNullOrEmpty(m_ClientID))
                {
                    m_ClientID = DefaultClientID;
                    //                    m_ClientID = Guid.NewGuid().ToString();
                    //#if !MONO
                    //                    UserConfigWriter.Instance.SetItem("ClientID", m_ClientID);
                    //                    UserConfigWriter.Instance.Save();
                    //#endif
                }
                return m_ClientID;
            }
            set { m_ClientID = value; }
        }

        private static string GetDefaultEIDSSClientID()
        {
            var user = Environment.UserName;
            var clientIDKeyName = string.Format("{0}-{1}", Environment.UserName, DefaultClientID);
            var clientID = RegistryHelper.ReadEidssValue(clientIDKeyName);
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
                    return Instance.m_ApplicationName;
                else
                    return Eidss;
            }
            set
            {
                if (Instance != null)
                    Instance.m_ApplicationName = value;
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
        private string m_CurrentLanguage = bv.common.Core.Localizer.lngEn;
        public static string CurrentLanguage
        {
            get
            {
                if (Instance != null)
                    return Instance.m_CurrentLanguage;
                return bv.common.Core.Localizer.lngEn;
            }
            set
            {
                if (Instance != null)
                    Instance.m_CurrentLanguage = value;
            }
        }
        private static string GetMacAddress()
        {
            try
            {
                string macAddress = string.Empty;
#if !MONO
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
#endif
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
        //#if !MONO
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
        //#endif
        //                return macAddress;

        //            }
        //            catch (Exception ex)
        //            {
        //                Dbg.Debug("can't got MAC Address: {0}", ex);
        //                return null;
        //            }
        //        }

        private static ModelUserContext g_Instance;
        private static object g_lock = new object();
        public static ModelUserContext Instance
        {
            get
            {
                lock (g_lock)
                {
                    ModelUserContext ret = null;
#if !MONO
                    if (HttpContext.Current != null && HttpContext.Current.Session != null)
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
#endif
                        ret = g_Instance;
                        if (ret == null)
                        {
                            ret = Creator == null ? null : Creator();
                            g_Instance = ret;
                        }
#if !MONO
                    }
#endif
                    return ret;
                }
            }
            protected set
            {
                lock (g_lock)
                {
#if !MONO
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.Session["UserContext"] = value;
                    }
                    else
                    {
#endif
                        g_Instance = value;
                    }
#if !MONO
                }
#endif
            }
        }

        public static bool IsWebContext
        {
            get { return HttpContext.Current != null; }
        }

        static ModelUserContext()
        {
        }

        public IsProcessedDelegate IsProcessed { get; protected set; }
        protected static CreateContextDelegate Creator { get; set; }

        public virtual void CreateContextData() { }
        public virtual void DeleteContextData() { }
        public virtual void SetContext(DbManagerProxy manager) { }
        public virtual void ClearContext(DbManagerProxy manager) { }
        public virtual long Audit(DbManagerProxy manager, params object[] auditData) { return 0; }
        public virtual void Event(DbManagerProxy manager, int isProcessed, params object[] eventData) { }
        public virtual void Filtration(long id) { }
        public virtual bool CanDo(string permission) { return true; }
        public virtual IUser CurrentUser { get { return null; } }

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
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (g_lock)
                {
#if !MONO
                    if (HttpContext.Current != null)
                    {
                        if (HttpContext.Current.Session["UserContext"] != null)
                        {
                            HttpContext.Current.Session.Remove("UserContext");
                        }
                    }
                    else
                    {
#endif
                        g_Instance = null;
#if !MONO
                    }
#endif
                }
                DeleteContextData();
            }
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
