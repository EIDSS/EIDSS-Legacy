using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Xml;
using System.Xml.XPath;
using bv.common.Core;

namespace bv.model.TranslationDictionary
{
    public static class TrDictionary
    {
        #region Properties
        const string MarkerDll = @"\bvwin_common.resources.dll";
        const string MarkerDll1 = @"\eidss.core.resources.dll";
        #endregion

        #region Public Functions
        // load file and return only its dictionary
        public static Dictionary<string, Word> Load(string dictfile)
        {
            var list = new Dictionary<string, Word>();
            Load(list, dictfile, false);
            return list;
        }
        // load file into existing dictionary merging it
        public static void Load(Dictionary<string, Word> list, string xmlFileName, bool dict)
        {
            lock (list)
            {
                try
                {
                    if (!File.Exists(xmlFileName))
                        Save(list, xmlFileName, dict);

                    var xp = new XPathDocument(xmlFileName);
                    try
                    {
                        XPathNavigator nav = xp.CreateNavigator();
                        XPathNavigator fs = nav.SelectSingleNode("root");
                        XPathNodeIterator wordsIt = fs.SelectChildren("word", "");
                        if (wordsIt.Count > 0)
                        {
                            while (wordsIt.MoveNext())
                            {//read one file
                                string key = wordsIt.Current.GetAttribute("key", "");
                                XPathNavigator cIt = wordsIt.Current.SelectSingleNode("comment");
                                string comment = null;
                                if (cIt != null && !String.IsNullOrEmpty(cIt.InnerXml))
                                    comment = cIt.InnerXml;
                                if (!list.ContainsKey(key))
                                    list.Add(key, new Word(key, comment));
                                var w = list[key];

                                XPathNodeIterator transIt = wordsIt.Current.SelectChildren("translation", "");
                                if (transIt.Count > 0)
                                {
                                    while (transIt.MoveNext())
                                    {//read one view
                                        string keyname = transIt.Current.GetAttribute("key", "");
                                        string text = transIt.Current.InnerXml;

                                        if (w.Translations.Where(t => t.Language == keyname && t.Text == text).ToList().Count == 0)
                                            w.Translations.Add(new Translation(keyname, text, dict));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        Debug.WriteLine(ex.StackTrace);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    // couldn't load file - make its backup and rename
                    if (File.Exists(xmlFileName))
                    {
                        string xmlFileNameBak = xmlFileName.Replace(".xml", ".bak");
                        if (File.Exists(xmlFileNameBak))
                            File.Delete(xmlFileNameBak);
                        File.Move(xmlFileName, xmlFileNameBak);
                    }
                }
            }
        }

        public static void Save(Dictionary<string, Word> list, string xmlFileName, bool dict)
        {
            FileStream fs = new FileStream(xmlFileName, FileMode.Create);
            XmlWriter writer = XmlWriter.Create(fs);

            writer.WriteStartDocument(true);
            writer.WriteStartElement("root");

            foreach (Word w in list.Values)
            {
                bool found = false;
                foreach (Translation trans in w.Translations)
                {
                    if (trans.Dict == dict)
                    {
                        if (!found)
                        {
                            writer.WriteStartElement("word");
                            writer.WriteAttributeString("key", w.Key);
                            writer.WriteElementString("comment", w.Comment);
                            found = true;
                        }

                        writer.WriteStartElement("translation");
                        writer.WriteAttributeString("key", trans.Language);
                        writer.WriteString(trans.Text);
                        writer.WriteEndElement();//"translation"
                    }
                }
                if(found)
                    writer.WriteEndElement();//"word"
            }

            writer.WriteEndElement();//"root"
            writer.WriteEndDocument();

            // Close and release the writer resources.
            writer.Flush();
            fs.Flush();
            fs.Close();
        }

        public static void LookForPhrases(Dictionary<string, Word> list, string dir)
        {
            // go through all resources dll
            foreach (string file in GetResourceDllNames(dir))
            {
                Assembly asm1 = GetAssembly(Path.Combine(dir, file + ".dll"));
                if (asm1 == null) asm1 = GetAssembly(Path.Combine(dir, file + ".exe"));
                if (asm1 != null)
                {
                    string[] resourceNames = asm1.GetManifestResourceNames();
                    foreach (string resourceName in resourceNames)
                    {
                        if (resourceName.EndsWith("resources"))
                        {
                            string basename = resourceName.Substring(0, resourceName.Length - 10);
                            var resm = new ResourceManager(basename, asm1);
                            if (resm != null)
                            {
                                var resSet = resm.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                                if (resSet != null)
                                {
                                    //var count = resSet.Cast<object>().Count();
                                    //-------------------------------------------------------
                                    //search english phrases
                                    IDictionaryEnumerator deResources = resSet.GetEnumerator();
                                    if (deResources != null)
                                    {
                                        while (deResources.MoveNext())
                                        {
                                            try
                                            {
                                                if (deResources.Value is String)
                                                {
                                                    string resName = deResources.Key as string;
                                                    if (!resName.StartsWith(">>"))
                                                    {
                                                        string key = GetResxValue(resm, resName, "en-US");
                                                        if (!list.ContainsKey(key))
                                                            list.Add(key, new Word(key));
                                                        Word w = list[key];

                                                        //-------------------------------------------------------
                                                        //search other languages phrases
                                                        foreach (string lang in CustomCultureHelper.SupportedLanguages.Values)
                                                        {
                                                            string tr = GetResxValue(resm, resName, lang);
                                                            if (w.Translations.Where(t => t.Language == lang && t.Text == tr).ToList().Count == 0)
                                                                w.Translations.Add(new Translation(lang, tr));
                                                        }
                                                        //-------------------------------------------------------
                                                    }
                                                }
                                            }
                                            catch(Exception)
                                            {
                                            }
                                        }
                                    }
                                    //-------------------------------------------------------
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Private Functions
        private static Assembly GetAssembly(string path)
        {
            if (!File.Exists(path)) return null;

            return Assembly.LoadFrom(path);
        }

        // получить строку из  ресурса (нейтрального или язык)
        private static string GetResxValue(ResourceManager rm, string resxKey, string cultureName = "")
        {
            CultureInfo ci;
            if (String.IsNullOrEmpty(cultureName))
                ci = CultureInfo.InvariantCulture;
            else
                ci = CultureInfo.CreateSpecificCulture(cultureName);
            return rm.GetString(resxKey, ci).Trim();
        }

        private static ArrayList GetResourceDllNames(string path)
        {
            var resourceDllNames = new ArrayList();
            GetResourceDllNames(resourceDllNames, path);
            return resourceDllNames;
        }

        private static void GetResourceDllNames(ArrayList list, string path)
        {
            string[] dirs = Directory.GetDirectories(path);
            foreach (string dir in dirs)
            {
                if (File.Exists(dir + MarkerDll) || File.Exists(dir + MarkerDll1))
                {
                    string[] files = Directory.GetFiles(dir, "*.resources.dll");
                    foreach (string file in files)
                    {
                        string basename = file.Substring(dir.Length + 1, file.IndexOf(".resources.dll") - dir.Length - 1);
                        bool found = false;
                        foreach (string resname in list)
                        {
                            if (resname == basename)
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found) list.Add(basename);
                    }
                }
                GetResourceDllNames(list, dir);
            }
        }
        #endregion
    }
}
