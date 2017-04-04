
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using bv.common.Core;

namespace bv.common.Resources.TranslationTool
{
    public class ResourceSplitter
    {
        private static string FileToSave
        {
            get
            {
                return TranslationToolHelper.SplittedResourcesFileName;
            }
        }
                                //culture      -     key        -        file - value
        private static Dictionary<string, Dictionary<string, Dictionary<string, string>>> g_SplittedFiles = new Dictionary<string,Dictionary<string,Dictionary<string,string>>>();

        #region Read
        public static string Read(string viewName, string resourceKey)
        {
            return Read(viewName, resourceKey, null, null);
        }

        public static string Read(string viewName, string resourceKey, string langId, string cultureCode)
        {
            if(string.IsNullOrEmpty(cultureCode))
                cultureCode = GetCultureName(langId);
            return Read(FileToSave, Utils.GetExecutingPath(), viewName, resourceKey, cultureCode);
        }

        public static string Read(string xmlFileName, string appDir, string viewName, string resourceKey, string cultureCode)
        {
            string key;
            lock (g_SplittedFiles)
            {
                // file of this culture was not read yet
                if (!g_SplittedFiles.ContainsKey(cultureCode))
                {
                    g_SplittedFiles.Add(cultureCode, new Dictionary<string, Dictionary<string, string>>());

                    string path = Path.Combine(appDir, string.Format(xmlFileName, cultureCode));
                    // read file
                    if (File.Exists(path))
                    {
                        var xp = new XPathDocument(path);
                        XPathNavigator nav = xp.CreateNavigator();
                        XPathNavigator fs = nav.SelectSingleNode("splittedResources");
                        if (fs != null)
                        {
                            XPathNodeIterator keysIt = fs.SelectChildren("key", "");
                            if (keysIt.Count > 0)
                            {
                                while (keysIt.MoveNext())
                                {//read one key
                                    if (keysIt.Current != null)
                                    {
                                        key = keysIt.Current.GetAttribute("id", "");
                                        g_SplittedFiles[cultureCode].Add(key, new Dictionary<string, string>());
                                        string file = keysIt.Current.GetAttribute("file", "");
                                        g_SplittedFiles[cultureCode][key].Add(file, keysIt.Current.InnerXml);
                                    }
                                }
                            }
                        }
                    }
                }

                key = viewName + "." + resourceKey;
                if (!g_SplittedFiles[cultureCode].ContainsKey(key))
                    return null;
                if (g_SplittedFiles[cultureCode][key].Count == 0)
                    return null;
                Dictionary<string, string>.Enumerator en = g_SplittedFiles[cultureCode][key].GetEnumerator();
                en.MoveNext();
                return en.Current.Value;
            }
        }
        #endregion

        #region Split
        public static void Split(string viewName, string resourceName, string resourceKey, string resourceValue)
        {
            Split(viewName, resourceName, resourceKey, resourceValue, null);
            Save(FileToSave, Path.GetDirectoryName(Utils.GetExecutingAssembly()), viewName, resourceName, resourceKey, resourceValue, null);
        }

        public static void Split(string viewName, string resourceName, string resourceKey, string resourceValue, string langId)
        {
            string cult = GetCultureName(langId);
            if (string.IsNullOrEmpty(resourceName))
                return;
            // add to cash
            string key = viewName + "." + resourceKey;
            lock (g_SplittedFiles)
            {
                if (!g_SplittedFiles.ContainsKey(cult))
                    g_SplittedFiles.Add(cult, new Dictionary<string, Dictionary<string, string>>());
                if (!g_SplittedFiles[cult].ContainsKey(key))
                    g_SplittedFiles[cult].Add(key, new Dictionary<string, string>());
                if (!g_SplittedFiles[cult][key].ContainsKey(resourceName))
                    g_SplittedFiles[cult][key].Add(resourceName, resourceValue);
                else
                    g_SplittedFiles[cult][key][resourceName] = resourceValue;
            }

            //add to file
        }
        #endregion
        public static void Save(string viewName, string resourceFile, string resourceKey, string resourceValue)
        {

            Save(FileToSave, Path.GetDirectoryName(Utils.GetExecutingAssembly()), viewName, resourceFile, resourceKey, resourceValue, null);
        }

        public static void Save(string fileToSave, string appDir, string viewName, string resourceFile, string resourceKey, string resourceValue, string cultureCode)
        {
            if(string.IsNullOrEmpty(cultureCode))
                cultureCode = GetCultureName(null);
            string path = Path.Combine(appDir, string.Format(fileToSave, cultureCode));

            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                XmlWriter writer = XmlWriter.Create(fs);
                writer.WriteStartDocument(true);
                writer.WriteElementString("splittedResources", "");
                writer.WriteEndDocument();
                writer.Flush();
                fs.Flush();
                fs.Close();
            }

            var xd = new XmlDocument();
            xd.Load(path);
            XmlNode key = xd.SelectSingleNode(string.Format("splittedResources/key[@id=\"{0}.{1}\"]", viewName, resourceKey));
            if (key == null)
            {
                XmlElement createdElement = xd.CreateElement("key");
                XmlAttribute id = xd.CreateAttribute("id");
                id.InnerText = string.Format("{0}.{1}", viewName, resourceKey);
                createdElement.Attributes.Append(id);
                XmlAttribute file = xd.CreateAttribute("file");
                // remove culture name from file name
                string res = resourceFile;
                if (res.EndsWith("." + cultureCode))
                    res = res.Substring(0, res.Length - cultureCode.Length - 1);
                ///////////////
                file.InnerText = res;
                createdElement.Attributes.Append(file);
                createdElement.InnerText = resourceValue;
                key = xd.SelectSingleNode("splittedResources");
                key.AppendChild(createdElement);
            }
            else
            {
                key.InnerText = resourceValue;
            }
            xd.Save(path);
            
        }
        private static string GetCultureName(string langId)
        {
            string ciName = Thread.CurrentThread.CurrentUICulture.Name;
            if (!string.IsNullOrEmpty(langId))//for tests
            {
                if (CustomCultureHelper.SupportedLanguages.ContainsKey(langId))
                {
                    CultureInfo ci = new CultureInfo(CustomCultureHelper.SupportedLanguages[langId]);
                    ciName = ci.Name;
                }
            }
            return ciName;
        }
   }
}
