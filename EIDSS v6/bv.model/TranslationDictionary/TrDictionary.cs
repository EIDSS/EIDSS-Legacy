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
    public class TrDictionary : IEnumerable<Word>
    {
        #region Properties
        const string TranslationDictionaryFile = @"Translations\ResourceUsage\TranslationDictionary.xml";
        const string TranslationsCurrentFile = @"Translations\ResourceUsage\TranslationsCurrent.xml";
        const string MarkerDll = @"\bvwin_common.resources.dll";
        const string MarkerDll1 = @"\eidss.core.resources.dll";

        private readonly Dictionary<string, Word> m_List = new Dictionary<string, Word>();

        // get list of resources dlls
        private ArrayList m_ResourceDllNames;
        private ArrayList ResourceDllNames
        {
            get
            {
                if (m_ResourceDllNames == null || m_ResourceDllNames.Count == 0)
                {
                    if (m_ResourceDllNames == null)
                        m_ResourceDllNames = new ArrayList();
                    string[] dirs = Directory.GetDirectories(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    foreach (string dir in dirs)
                    {
                        if (File.Exists(dir + MarkerDll) || File.Exists(dir + MarkerDll1))
                        {
                            string[] files = Directory.GetFiles(dir, "*.resources.dll");
                            foreach (string file in files)
                            {
                                string basename = file.Substring(dir.Length + 1, file.IndexOf(".resources.dll") - dir.Length - 1);
                                bool found = false;
                                foreach (string resname in m_ResourceDllNames)
                                {
                                    if (resname == basename)
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                                if (!found) m_ResourceDllNames.Add(basename);
                            }
                        }
                    }
                }
                return m_ResourceDllNames;
            }
        }

        public Word this[string key]
        {
            get
            { 
                if(m_List.ContainsKey(key))
                    return m_List[key];
                return null;
            }
        }
        #endregion

        #region Public Functions
        public void Init(string dictfile, string phrasesfile)
        {
            m_List.Clear();
            Load(dictfile, true);
            Load(phrasesfile, false);
        }

        public void Init()
        {
            m_List.Clear();
            Load(TranslationDictionaryFile, true);
            Load(TranslationsCurrentFile, false);
        }

        public IEnumerator<Word> GetEnumerator()
        {
            foreach(Word w in m_List.Values)
                yield return w;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // Serialize Dictionary<string, Word> m_List into xml
        public void Save(bool dict)
        {
            string xmlFileName = TranslationsCurrentFile;
            if(dict) xmlFileName = TranslationDictionaryFile;
            Save(xmlFileName, dict);
        }

        public void Save(string xmlFileName, bool dict)
        {
            FileStream fs = new FileStream(xmlFileName, FileMode.Create);
            XmlWriter writer = XmlWriter.Create(fs);

            writer.WriteStartDocument(true);
            writer.WriteStartElement("root");

            foreach (Word w in m_List.Values)
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

        public void LookForPhrases()
        {
            LookForPhrasesIn(Directory.GetCurrentDirectory());
            //LookForPhrasesIn(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\eidss.mobileclient\\bin"));//nothing new here
            Save(false);
        }

        public void LookForPhrases(string xmlFileName)
        {
            LookForPhrasesIn(Directory.GetParent(Directory.GetParent(xmlFileName).FullName).FullName);
            Save(xmlFileName, false);
        }

        public void LookForPhrases(string xmlFileName, string eidssDirectory)
        {
            LookForPhrasesIn(eidssDirectory);
            if (String.IsNullOrEmpty(xmlFileName))
                xmlFileName = TranslationsCurrentFile;
            Save(xmlFileName, false);
        }

        public void ChangeWordKey(string oldKey, string newKey)
        {
            Word w = m_List[oldKey];
            w.Key = newKey;
            m_List.Add(newKey, w);
            m_List.Remove(oldKey);
        }
        #endregion

        #region Private Functions
        private void Load(string xmlFileName, bool dict)
        {
            lock (m_List)
            {
                try
                {
                    if (!File.Exists(xmlFileName))
                        Save(xmlFileName, dict);

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
                                if (!m_List.ContainsKey(key))
                                    m_List.Add(key, new Word(key, comment));
                                var w = m_List[key];

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

        private void LookForPhrasesIn(string dir)
        {
            m_List.Clear();
            Load(TranslationDictionaryFile, true);

            // go through all resources dll
            foreach (string file in ResourceDllNames)
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
                                            if (deResources.Value is String)
                                            {
                                                string resName = deResources.Key as string;
                                                if (!resName.StartsWith(">>"))
                                                {
                                                    string key = GetResxValue(resm, resName, "en-US");
                                                    if (!m_List.ContainsKey(key))
                                                        m_List.Add(key, new Word(key));
                                                    Word w = m_List[key];

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
                                    }
                                    //-------------------------------------------------------
                                }
                            }
                        }
                    }
                }
            }
        }

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
        #endregion
    }
}
