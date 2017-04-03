
using System;
using System.IO;
using System.Xml;
using bv.common.Core;
using bv.common.Diagnostics;
using System.Collections.Generic;

namespace bv.common.Configuration
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Reads and writes the information form the xml configuration files
    /// </summary>
    /// <remarks>
    /// By default <i>ConfigWriter</i> reads/writes the settings of the configuration file <b>appSettings</b> section.
    /// If configuration file name is not specified, it works with application config file (app.config)
    /// Shared <i>Instance</i> method always works to the <i>ConfigWriter</i> instance related with application config file.
    /// </remarks>
    /// <history>
    /// 	[Mike]	22.03.2006	Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConfigWriter
    {
        public delegate ConfigWriter CreateConfigWriterDelegate();
        protected static CreateConfigWriterDelegate Creator { get; set; }
        private List<string> m_RestrictedKeys = null;
        private class NodeAttribute
        {
            public string Name;
            public string Value;

            public NodeAttribute(string aName, string aValue)
            {
                Name = aName;
                Value = aValue;
            }
        }
        private static ConfigWriter s_Instance;
        private readonly XmlDocument m_AppConfig = new XmlDocument();
        private string m_FileName;
        private bool m_Initialized;
        private bool m_Modified;
        private readonly string m_DefaultConfigFileName = Utils.GetExecutingPath() + Utils.GetConfigFileName();
        private XmlNamespaceManager m_Namespaces;
        private string m_Prefix;
        public ConfigWriter()
        {
        }

        public ConfigWriter(List<string> keys, string fileName)
        {
            Config.InitSettings();
            m_RestrictedKeys = keys;
            foreach (string key in Config.m_Settings.Keys)
            {
                SetItem(key, Config.m_Settings[key]);
            }
            m_Modified = false;
            m_Initialized = true;
            if (!string.IsNullOrEmpty(Path.GetFileName(fileName)))
                m_FileName = fileName;
            else
                m_FileName = m_DefaultConfigFileName;

        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Defines whether <i>ConfigWriter</i> initialized by reading configuration file
        /// </summary>
        /// <returns>
        /// returns <b>True</b> if <i>Read</i> method was called successfully and <b>False</b> in other case.
        /// </returns>
        /// <remarks>
        /// Use this method to indicate was the data successfully read from configuration file or no.
        /// If <i>Read</i> method was called for absent configuration file for example the property will return <b>False</b>.
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public bool IsInitialized
        {
            get { return m_Initialized; }
        }

        public string FileName
        {
            get { return m_FileName; }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Returns the default instance of <i>ConfigWriter</i> related with application configuration file.
        /// </summary>
        /// <returns>
        /// Returns the default instance of <i>ConfigWriter</i> related with application configuration file.
        /// </returns>
        /// <remarks>
        /// When requested first time the instance of <i>ConfigWriter</i> related with application configuration file is created and read.
        /// Any next call of this property returns this created instance and no additional read is performed.
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static object g_lock = new object();
        public static ConfigWriter Instance
        {
            get
            {
                lock (g_lock)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = Creator == null ? new ConfigWriter() : Creator();
                        s_Instance.Read(null);
                    }
                }

                return s_Instance;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Reads the configuration file and stores xml document inside the class
        /// </summary>
        /// <param name="fileName">
        /// Xml file name to read
        /// </param>
        /// <remarks>
        /// If <i>fileName</i> is not passed (or set to <b>Nothing</b>) the default application config file is read.
        /// If specified file doesn't exist new xml document with <i>&lt;configuration&gt;/&lt;appConfig&gt;</i> section is created.
        /// </remarks>
        /// <history>
        /// 	[Mike]	22.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public void Read(string fileName)
        {
            //Save settings in app config file
            if (string.IsNullOrEmpty(fileName))
            {
                if (string.IsNullOrEmpty(m_FileName))
                {
                    Config.FindLocalConfigFile();
                    m_FileName = Config.FileName;
                    if (fileName == null)
                        m_FileName = m_DefaultConfigFileName;
                }
            }
            else
            {
                m_FileName = fileName;
            }

            if (File.Exists(m_FileName) == false)
            {
                GetAppSettingsNode();
                return;
            }
            m_Namespaces = null;
            m_NamespaceInitialized = false;
            m_AppConfig.Load(m_FileName);
            InitNamespace();
            m_Modified = false;
            m_Initialized = true;
        }

        private bool m_NamespaceInitialized = false;
        private void InitNamespace()
        {
            if (!m_NamespaceInitialized)
            {
                if (m_AppConfig != null && m_AppConfig.DocumentElement != null)
                {
                    XmlAttribute xmlnsAttribute = m_AppConfig.DocumentElement.Attributes["xmlns"];
                    m_Prefix = "";
                    if (xmlnsAttribute != null)
                    {
                        m_Prefix = "ns";
                        m_Namespaces = new XmlNamespaceManager(m_AppConfig.NameTable);
                        m_Namespaces.AddNamespace(m_Prefix, xmlnsAttribute.Value);
                        //Re-configure xPath with included the prefix 
                        m_Prefix = String.Concat(m_Prefix, ":");
                    }
                    m_NamespaceInitialized = true;
                }

            }
        }
        private XmlNode _GetAppSettingsNode()
        {

            if (m_AppConfig != null && m_AppConfig.DocumentElement != null)
            {
                var xPath = string.Format("/{0}configuration/{0}appSettings", m_Prefix);
                return m_AppConfig.SelectSingleNode(xPath, m_Namespaces);
            }
            return null;
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Sets the value for specific setting defined by parent node and setting's key.
        /// </summary>
        /// <param name="appSettingsNode">
        /// defines the <b>XmlNode</b> that contains the setting nodes.
        /// </param>
        /// <param name="nodeName">
        /// the value of <i>key</i> attribute of setting node
        /// </param>
        /// <param name="value">
        /// the string that should be assigned to the <i>value</i> attribute of setting node
        /// </param>
        /// <returns>
        /// Returns <b>True</b> if setting node was modified and <b>False</b> in other case
        /// </returns>
        /// <remarks>
        /// This method is used to set the values of setting nodes with predefined node parameters: <br/>
        /// <i>add</i> - the tag name of setting node
        /// <b>key</b> - the attribute that defines the unique node identifier
        /// <b>value</b> - the attribute that defines the setting value <br/>
        /// If requested setting is absent the new setting node is added to the parent <b>XmlNode</b>
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private bool SetAttributeValue(XmlNode appSettingsNode, string nodeName, string value)
        {
            XmlNode node = FindNodeByAttribute(appSettingsNode, "add", "key", nodeName);
            if (node == null && appSettingsNode != null && appSettingsNode.OwnerDocument != null)
            {
                node = appSettingsNode.OwnerDocument.CreateElement("add");
                node.Attributes.Append(appSettingsNode.OwnerDocument.CreateAttribute("key"));
                node.Attributes["key"].InnerText = nodeName;
                node.Attributes.Append(appSettingsNode.OwnerDocument.CreateAttribute("value"));
                node.Attributes["value"].InnerText = value;
                appSettingsNode.AppendChild(node);
                Dbg.ConditionalDebug(DebugDetalizationLevel.High, "attribute value {0} for node {1} is added  ", value,
                          nodeName);
                return true;
            }
            if (node.Attributes["value"].InnerText != value)
            {
                Dbg.ConditionalDebug(DebugDetalizationLevel.High,
                          "attribute value for node {0} was changed from {1} to {2}  ", nodeName,
                          node.Attributes["value"].InnerText, value);
                node.Attributes["value"].InnerText = value;
                return true;
            }
            Dbg.ConditionalDebug(DebugDetalizationLevel.High, "attribute value for node {0} was changed not changed",
                      nodeName);
            return false;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Searches the <b>XmlNode</b> with specific name and specific attribute value in the section defined by <i>appSettingsNode</i> parameter.
        /// </summary>
        /// <param name="appSettingsNode">
        /// parent <b>XmlNode</b> node. The result node will be searched among the children of this node.
        /// </param>
        /// <param name="nodeName">
        /// the tag name of xml node to search
        /// </param>
        /// <param name="attrName">
        /// the name of key attribute
        /// </param>
        /// <param name="attrValue">
        /// the value of key attribute
        /// </param>
        /// <returns>
        /// Returns the first <b>XmlNode</b> that match to specified conditions or <b>Nothing</b> if node is not found
        /// </returns>
        /// <remarks>
        /// Use this method to find <b>XmlNode</b> with arbitrary tag name and key attribute
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public XmlNode FindNodeByAttribute(XmlNode appSettingsNode, string nodeName, string attrName, string attrValue)
        {
            if (appSettingsNode == null)
            {
                appSettingsNode = _GetAppSettingsNode();
            }

            if (appSettingsNode != null)
            {
                string xPath = string.Format("descendant::{0}{1}[@{2}=\'{3}\']", m_Prefix,
                                                                   nodeName, attrName,
                                                                   attrValue);
                return
                    appSettingsNode.SelectSingleNode(xPath, m_Namespaces);
            }
            return null;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Searches the <b>XmlNode</b> with specific name and specific attribute value in descendant nodes of parent node and sets values for the set of node attributes.
        /// </summary>
        /// <param name="appSettingsNode">
        /// parent <b>XmlNode</b> node. The node that should be modified will be searched among the children of this node.
        /// </param>
        /// <param name="nodeName">
        /// the tag name of xml node that should be modified
        /// </param>
        /// <param name="attr">
        /// the array of <i>NodeAttribute</i> objects that defines the name/value pairs for modified attributes
        /// </param>
        /// <returns>
        /// Returns <b>True</b> if any of the passed attributes values was modified or new node was created and <b>False</b> in other case.
        /// </returns>
        /// <remarks>
        /// Call this method if you need to modify several attributes of <i>XmlNode</i> with custom node name.
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private bool SetAttributeValue(XmlNode appSettingsNode, string nodeName, NodeAttribute[] attr)
        {
            if (attr.Length == 0)
            {
                return false;
            }
            XmlNode node = FindNodeByAttribute(appSettingsNode, nodeName, attr[0].Name, attr[0].Value);
            if (node == null && appSettingsNode != null && appSettingsNode.OwnerDocument != null)
            {
                node = appSettingsNode.OwnerDocument.CreateElement(nodeName);
                for (int i = 0; i <= attr.Length - 1; i++)
                {
                    node.Attributes.Append(appSettingsNode.OwnerDocument.CreateAttribute(attr[i].Name));
                    node.Attributes[attr[i].Name].InnerText = attr[i].Value;
                    Dbg.ConditionalDebug(DebugDetalizationLevel.High, "attribute value {0} for node {1} is added  ",
                              attr[i].Value, attr[i].Name);
                }
                appSettingsNode.AppendChild(node);
                m_Modified = true;
                return true;
            }
            for (int i = 1; i <= attr.Length - 1; i++)
            {
                if (node.Attributes[attr[i].Name] == null)
                {
                    node.Attributes.Append(appSettingsNode.OwnerDocument.CreateAttribute(attr[i].Name));
                    Dbg.ConditionalDebug(DebugDetalizationLevel.High, "attribute value {0} for node {1} is added  ",
                              attr[i].Value, attr[i].Name);
                    m_Modified = true;
                }
                if (node.Attributes[attr[i].Name].InnerText != attr[i].Value)
                {
                    Dbg.ConditionalDebug(DebugDetalizationLevel.High,
                              "attribute value for node {0} was changed from {1} to {2}  ", attr[i].Name,
                              node.Attributes[attr[i].Name].InnerText, attr[i].Value);
                    node.Attributes[attr[i].Name].InnerText = attr[i].Value;
                    m_Modified = true;
                }
            }
            return m_Modified;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Sets several attribute values for the specific <b>XmlNode</b>.
        /// </summary>
        /// <param name="node">
        /// the <b>XmlNode</b> that should be modified
        /// </param>
        /// <param name="attr">
        /// the array of <i>NodeAttribute</i> objects that defines the name/value pairs for modified attributes
        /// </param>
        /// <returns>
        /// Returns <b>True</b> if any of the passed attributes values was modified or new node was created and <b>False</b> in other case.
        /// </returns>
        /// <remarks>
        /// Call this method if you need to modify several attributes of the specific <i>XmlNode</i>.
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private bool SetAttributeValue(XmlNode node, NodeAttribute[] attr)
        {
            if (attr.Length == 0)
            {
                return false;
            }
            if (node != null)
            {
                for (int i = 0; i <= attr.Length - 1; i++)
                {
                    if (node.Attributes[attr[i].Name] == null)
                    {
                        node.Attributes.Append(node.OwnerDocument.CreateAttribute(attr[i].Name));
                    }
                    if (node.Attributes[attr[i].Name].InnerText != attr[i].Value)
                    {
                        node.Attributes[attr[i].Name].InnerText = attr[i].Value;
                        m_Modified = true;
                    }
                }
                return true;
            }
            return false;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the specific setting in the appSettings section of configuration file
        /// </summary>
        /// <param name="keyValue">
        /// the value key attribute of the appSettings node
        /// </param>
        /// <returns>
        /// the value attribute of the appSettings node
        /// </returns>
        /// <remarks>
        /// If requested settings node doesn't exist the <b>Nothing</b> is returned. If you set value for non existing setting node, the new setting is created.
        /// </remarks>
        /// <history>
        /// 	[Mike]	22.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public string GetItem(string keyValue)
        {
            if (m_AppConfig == null)
                return "";

            XmlNode root = m_AppConfig.DocumentElement;
            if (root != null)
            {
                XmlNode appSettingsNode = _GetAppSettingsNode();

                if (appSettingsNode == null || appSettingsNode.OwnerDocument == null)
                {
                    return "";
                }

                XmlNode node = FindNodeByAttribute(appSettingsNode, "add", "key", keyValue);
                if (node != null)
                {
                    return node.Attributes["value"].InnerText;
                }
            }
            return "";
        }

        public void SetItem(string keyValue, string value)
        {
            if (m_RestrictedKeys != null && !m_RestrictedKeys.Contains(keyValue))
                return;
            XmlNode appSettingsNode = GetAppSettingsNode();
            m_Modified = m_Modified | SetAttributeValue(appSettingsNode, keyValue, value);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Searches and returns <b>XmlNode</b> defined by node name and attribute name/value pair in the <b>appSettings</b> section of configuration file.
        /// </summary>
        /// <param name="nodeName">
        /// xml node name to find
        /// </param>
        /// <param name="attrName">
        /// the key attribute name
        /// </param>
        /// <param name="attrValue">
        /// the key attribute value
        /// </param>
        /// <returns>
        /// Returns <b>XmlNode</b> with specific node name and attribute name/value pair or <b>Nothing</b> is node is not found.
        /// </returns>
        /// <remarks>
        /// The node is searched inside <b>appSettings</b> section of configuration file only.
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public XmlNode GetNode(string nodeName, string attrName, string attrValue)
        {
            return GetNode(null, nodeName, attrName, attrValue);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Searches and returns <b>XmlNode</b> defined by node name and attribute name/value pair in the specific section of configuration file.
        /// </summary>
        /// <param name="parentNode">
        /// <b>XmlNode</b> of section to search
        /// </param>
        /// <param name="nodeName">
        /// xml node name to find
        /// </param>
        /// <param name="attrName">
        /// the key attribute name
        /// </param>
        /// <param name="attrValue">
        /// the key attribute value
        /// </param>
        /// <returns>
        /// Returns <b>XmlNode</b> with specific node name and attribute name/value pair or <b>Nothing</b> is node is not found.
        /// </returns>
        /// <remarks>
        /// The node is searched inside section of configuration file defined by <i>parentNode</i>.
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public XmlNode GetNode(XmlNode parentNode, string nodeName, string attrName, string attrValue)
        {
            if (parentNode == null)
            {
                parentNode = _GetAppSettingsNode();
                if (parentNode == null)
                    return null;
            }
            XmlNode sectionNode = FindNodeByAttribute(parentNode, nodeName, attrName, attrValue);
            if (sectionNode != null)
            {
                return sectionNode;
            }
            sectionNode = parentNode.OwnerDocument.CreateElement(nodeName);
            SetAttributeValue(sectionNode, new NodeAttribute[] { new NodeAttribute(attrName, attrValue) });
            parentNode.AppendChild(sectionNode);
            m_Modified = true;
            return sectionNode;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Returns the string value of specific attribute for passed <b>XmlNode</b>
        /// </summary>
        /// <param name="node">
        /// <b>XmlNode</b> that contains the attribute
        /// </param>
        /// <param name="attrName">
        /// the attribute name
        /// </param>
        /// <returns>
        /// the string representation of the requested attribute
        /// </returns>
        /// <remarks>
        /// No additional checks for existence of passed node or attribute is performed. If <i>node</i> is <b>Nothing</b> or contains no requested attribute the exception will be thrown
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public string GetAttributeValue(XmlNode node, string attrName)
        {
            return node.Attributes[attrName].InnerText;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Saves the configuration file previously read using <i>Read</i> method.
        /// </summary>
        /// <returns>
        /// Returns <b>False</b> if error occur during saving or <b>True</b> in other case.
        /// </returns>
        /// <remarks>
        /// When the application is run from VS IDE the changes for default application configuration
        /// file are saved not only to configuration file in the <b>bin</b> folder but to the original
        /// <b>app.config</b> file too. If error occurs during saving the error is written to
        /// the application log but no error reported to end user
        /// </remarks>
        /// <history>
        /// 	[Mike]	23.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public bool Save(bool forceSaving = false, bool throwExeption = false)
        {
            if (!m_Modified && !forceSaving)
            {
                Dbg.ConditionalDebug(DebugDetalizationLevel.High,
                          "configuration file {0} is not saved, there is no changes", m_FileName);
                return true;
            }
            //!!We should never update web.config from code. Only manual changes are allowed
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(m_FileName);
            if (fileNameWithoutExtension != null && fileNameWithoutExtension.ToLowerInvariant() == "web")
                return true;
            bool ret = true;
            try
            {
                if (!File.Exists(FileName))
                {
                    Utils.ForceDirectories(Path.GetDirectoryName(FileName));
                    FileStream fs = File.Create(FileName);
                    fs.Close();
                }
                FileAttributes attr = File.GetAttributes(FileName);
                if ((attr & FileAttributes.ReadOnly) != 0)
                {
                    attr = attr & (~FileAttributes.ReadOnly);
                    File.SetAttributes(FileName, attr);
                }
                m_AppConfig.Save(m_FileName);
                m_Modified = false;
            }
            catch (Exception ex)
            {
                ret = false;
                Dbg.Debug("the changes to configuration file {0} was not written, {1}",
                                m_FileName, ex.Message);
                if (throwExeption)
                    throw;
            }
            string appConfigFileName = "";
            try
            {
                if (m_FileName == m_DefaultConfigFileName)
                {
                    appConfigFileName = Utils.GetExecutingPath() + "\\..\\app.config";
                    if (File.Exists(appConfigFileName))
                    {
                        m_AppConfig.Save(appConfigFileName);
                    }
                }
            }
            catch (Exception ex)
            {
                ret = false;
                Dbg.Debug("the changes to configuration file {0} was not written, {1}",
                                appConfigFileName, ex.Message);
                if (throwExeption)
                    throw;
            }
            //Config.ReloadSettings();
            //Instance.Read(null);
            return ret;
        }

        public bool SaveAs(string fileName, bool forceSaving = false, bool throwExeption = false)
        {
            m_FileName = fileName;
            return Save(forceSaving, throwExeption);
        }

        private XmlNode GetAppSettingsNode()
        {
            XmlNode appSettingsNode = _GetAppSettingsNode();
            if (appSettingsNode == null)
            {
                XmlNode root = m_AppConfig.DocumentElement;
                if (root == null)
                {
                    root = m_AppConfig.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                    m_AppConfig.AppendChild(root);
                }
                root = m_AppConfig.SelectSingleNode("/configuration");
                if (root == null)
                {
                    root = m_AppConfig.CreateNode(XmlNodeType.Element, "configuration", "");
                }
                appSettingsNode = m_AppConfig.CreateNode(XmlNodeType.Element, "appSettings", "");
                root.AppendChild(appSettingsNode);
                m_AppConfig.AppendChild(root);
            }
            return appSettingsNode;
        }
    }
}
