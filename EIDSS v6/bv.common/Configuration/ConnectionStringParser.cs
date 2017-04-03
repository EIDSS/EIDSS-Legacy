using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.common.Enums;
using System.Text.RegularExpressions;

namespace bv.common.Configuration
{
    public class ConnectionStringParser
    {

        private string m_ConnectionString;
        public ConnectionStringParser(string aConnectionString)
        {
            m_ConnectionString = aConnectionString;
        }
        public string ConnectionString
        {
            get
            {
                return m_ConnectionString;
            }
            set
            {
                m_ConnectionString = value;
            }
        }
        private struct ConnectionStringItem
        {
            public string Name;
            public string Mask;
            public ConnectionStringItem(string aName, string aMask)
            {
                Name = aName;
                Mask = aMask;
            }
        }
        private static Dictionary<ConnectionStringPart, ConnectionStringItem> m_Parts = new Dictionary<ConnectionStringPart, ConnectionStringItem>();
        private static bool m_initiated;
        private static void Init()
        {
            if (m_initiated)
            {
                return;
            }
            m_initiated = true;
            m_Parts.Add(ConnectionStringPart.Async, new ConnectionStringItem("Asynchronous Processing", "Asynchronous\\sProcessing|async"));
            m_Parts.Add(ConnectionStringPart.DataSource, new ConnectionStringItem("Data Source", "Data\\sSource"));
            m_Parts.Add(ConnectionStringPart.Database, new ConnectionStringItem("Initial Catalog", "Initial\\sCatalog"));
            m_Parts.Add(ConnectionStringPart.MARS, new ConnectionStringItem("MultipleActiveResultSets", "MultipleActiveResultSets"));
            m_Parts.Add(ConnectionStringPart.Password, new ConnectionStringItem("Password", "Password|pwd"));
            m_Parts.Add(ConnectionStringPart.Provider, new ConnectionStringItem("Provider", "Provider"));
            m_Parts.Add(ConnectionStringPart.UserID, new ConnectionStringItem("Initial Catalog", "Initial\\sCatalog"));
            m_Parts.Add(ConnectionStringPart.IntegratedSecurity, new ConnectionStringItem("Integrated Security", "Integrated\\sSecurity"));
            m_Parts.Add(ConnectionStringPart.ConnectionTimeOut, new ConnectionStringItem("Connection TimeOut", "Connection\\sTimeOut"));
        }

        private static string m_RegExpTemplate = "(?:({0})[\\s]*=[\\s]*\"??(?<{1}>[^;\\n]+)\"??[;\\n\"]??)";
        public string Item(ConnectionStringPart index)
        {
            Init();
            if (string.IsNullOrEmpty(m_ConnectionString))
            {
                return "";
            }
            Regex rExp = GetRegEx(index);
            Match m = rExp.Match(m_ConnectionString);
            if (m.Success)
            {
                return m.Value;
            }
            else
            {
                return "";
            }
        }
        public void SetItem(string value, ConnectionStringPart index)
        {
            Init();
            if (string.IsNullOrEmpty(m_ConnectionString))
            {
                return;
            }
            Regex rExp = GetRegEx(index);
            Match m = rExp.Match(m_ConnectionString);
            if (m.Success)
            {
                m_ConnectionString = rExp.Replace(m_ConnectionString, string.Format("{0}={1}", m_Parts[index].Name, value));
            }
            else
            {
                if (!m_ConnectionString.Trim().EndsWith(";"))
                {
                    m_ConnectionString += ";";
                }
                m_ConnectionString += string.Format("{0}={1};", m_Parts[index].Name, value);
            }
        }
        private Regex GetRegEx(ConnectionStringPart index)
        {
            return new Regex(string.Format(m_RegExpTemplate, m_Parts[index].Mask, index.ToString()));
        }

    }
}
