using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using bv.common.Resources.TranslationTool;

namespace bv.model.ResourcesUsage
{
    public enum ResourceAction
    {
        Cancel,
        Accept,
        Split
    }

    public class ResourceUsage : IEnumerable<ResourceItemUsage>
    {
        // list of forms
        private readonly FormDescriptionList m_Forms = new FormDescriptionList(); 
        // list of resources
        private readonly Dictionary<string, Dictionary<string, ResourceItemUsage>> m_List = new Dictionary<string, Dictionary<string, ResourceItemUsage>>();

        public int Count
        {
            get { return m_List.Count; }
        }

        public FormDescriptionList Forms
        {
            get
            {
                return m_Forms;
            }
        }

        public Dictionary<string, ResourceItemUsage> this[string resxName]
        {
            get
            {
                try
                {
                    return m_List[resxName];
                }
                catch (Exception)
                {
                    return new Dictionary<string, ResourceItemUsage>();
                }
            }
        }

        public ResourceItemUsage this[string resxName, string resxKey]
        {
            get
            {
                try
                {
                    return m_List[resxName][resxKey];
                }
                catch (Exception)
                {
                    return new ResourceItemUsage();
                }
            }
        }

        public IEnumerator<ResourceItemUsage> GetEnumerator()
        {
            foreach (Dictionary<string, ResourceItemUsage> dict in m_List.Values)
            {
                foreach (ResourceItemUsage res in dict.Values)
                {
                    yield return res;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #region Constructors
        public ResourceUsage()
        {
        }

        public ResourceUsage(string xmlFormsFileName, string xmlResourcesFileName)
        {
            Init(xmlFormsFileName, xmlResourcesFileName);
        }
        #endregion

        public void Init(string xmlFormsFileName, string xmlResourcesFileName)
        {
            if (!File.Exists(xmlFormsFileName))
                throw (new Exception("File " + xmlFormsFileName + " not found!"));
            if (!File.Exists(xmlResourcesFileName))
                throw (new Exception("File " + xmlResourcesFileName + " not found!"));
            m_Forms.Load(xmlFormsFileName);
            Load(xmlResourcesFileName);
        }

        // add empty list of form/view pairs
        public ResourceItemUsage Add(string resxName, string resxKey)
        {
            lock (m_List)
            {
                if (!m_List.ContainsKey(resxName))
                    m_List.Add(resxName, new Dictionary<string, ResourceItemUsage>());

                if (!m_List[resxName].ContainsKey(resxKey))
                    m_List[resxName].Add(resxKey, new ResourceItemUsage(resxName, resxKey));
            }

            return m_List[resxName][resxKey];
        }

        public void Delete(string resxName, string resxKey)
        {
            lock (m_List)
            {
                if (m_List.ContainsKey(resxName))
                    m_List[resxName].Remove(resxKey);
            }
        }

        // Load xml structure into Dictionary<string, Dictionary<string, ResourceItemUsage>> m_List
        // ???? use earlier loaded list of forms descriptions 
        public void Load(string xmlFileName)//???? , FormDescriptionList loadedForms)
        {
            lock (m_List)
            {
                m_List.Clear();
                try
                {
                    var xp = new XPathDocument(xmlFileName);
                    XPathNavigator nav = xp.CreateNavigator();
                    XPathNavigator fs = nav.SelectSingleNode("root");
                    XPathNodeIterator filesIt = fs.SelectChildren("resxfile", "");
                    if (filesIt.Count > 0)
                    {
                        while (filesIt.MoveNext())
                        {//read one file
                            var f = new Dictionary<string, ResourceItemUsage>();
                            string filename = filesIt.Current.GetAttribute("name", "");

                            XPathNodeIterator keyIt = filesIt.Current.SelectChildren("resxkey", "");
                            if (keyIt.Count > 0)
                            {
                                while (keyIt.MoveNext())
                                {//read one view
                                    string keyname = keyIt.Current.GetAttribute("name", "");
                                    XPathNavigator cIt = keyIt.Current.SelectSingleNode("comment");
                                    string comment = null;
                                    if (cIt != null && !String.IsNullOrEmpty(cIt.InnerXml))
                                        comment = cIt.InnerXml;
                                    var item = new ResourceItemUsage(filename, keyname, comment);

                                    XPathNavigator forms = keyIt.Current.SelectSingleNode("forms");
                                    XPathNodeIterator formsIt = forms.SelectChildren("form", "");
                                    if (formsIt.Count > 0)
                                    {
                                        while (formsIt.MoveNext())
                                        {//read one form-view
                                            string form = formsIt.Current.GetAttribute("key", "");
                                            string view = formsIt.Current.GetAttribute("view", "");
                                            string obsolete = formsIt.Current.GetAttribute("obsolete", "");
                                            item.Forms.Add(new FormDescriptionLink(form, view, obsolete == "true"?true:false));
                                        }
                                    }
                                    f.Add(keyname, item);
                                }
                            }

                            m_List.Add(filename, f);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    // couldn't load file - make its backup and rename
                    if (File.Exists(xmlFileName))
                    {
                        FileInfo fi1 = new FileInfo(xmlFileName);
                        if (fi1.Length > 0)
                        {
                            string xmlFileNameBak = xmlFileName.Replace(".xml", ".bak");
                            fi1.CopyTo(xmlFileNameBak, true);
                            fi1.Delete();
                        }
                    }
                }
            }
        }

        // Serialize Dictionary<string, Dictionary<string, ResourceItemUsage>> m_List into xml
        public void Save(string xmlFileName)
        {
            FileStream fs = new FileStream(xmlFileName, FileMode.Create);
            XmlWriter writer = XmlWriter.Create(fs);

            writer.WriteStartDocument(true);
            writer.WriteStartElement("root");

            foreach (string filename in m_List.Keys)
            {
                var f = m_List[filename];

                writer.WriteStartElement("resxfile");

                writer.WriteAttributeString("name", filename);

                foreach (string keyname in f.Keys)
                {
                    writer.WriteStartElement("resxkey");
                    writer.WriteAttributeString("name", keyname);
                    writer.WriteElementString("comment", f[keyname].Comment);

                    writer.WriteStartElement("forms");
                    foreach (FormDescriptionLink v in f[keyname].Forms)
                    {
                        writer.WriteStartElement("form");
                        writer.WriteAttributeString("key", v.Form);
                        writer.WriteAttributeString("view", v.View);
                        writer.WriteAttributeString("obsolete", v.Obsolete?"true":"false");
                        writer.WriteEndElement();//"form"
                    }
                    writer.WriteEndElement();//"forms"
                    writer.WriteEndElement();//"resxkey"

                }
                writer.WriteEndElement();//"resxfile"
            }

            writer.WriteEndElement();//"root"
            writer.WriteEndDocument();

            // Close and release the writer resources.
            writer.Flush();
            fs.Flush();
            fs.Close();
        }

        public List<FormDescription> GetResourceUsage(string currentFormName, string currentViewName, string resourceFileName, string resourceKey)
        {
            var ret = new List<FormDescription>();
            // if resource is splitted - it isn't used on another forms
            if (!string.IsNullOrEmpty(ResourceSplitter.Read(string.IsNullOrEmpty(currentViewName) ? currentFormName : currentViewName, resourceKey)))
                return ret;

            var retStrings = new Dictionary<string, FormDescription>();

            foreach (FormDescriptionLink fdl in this[resourceFileName, resourceKey].Forms)
            {
                if (fdl.Form != currentFormName && !retStrings.ContainsKey(fdl.Form))
                {
                    retStrings.Add(fdl.Form, m_Forms[fdl.Form]);
                }
            }

            foreach (FormDescription f in retStrings.Values)
                ret.Add(f);
            return ret;
        }

        public virtual ResourceAction DisplayResourceUsage(string currentFormName, string currentViewName, string resourceName, string resourceKey, string text)
        {
            return ResourceAction.Cancel;
        }

#region IObject
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to ResourceUsage return false.
            var p = obj as ResourceUsage;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            if (m_List.Count != p.Count)
                return false;
            foreach (string filename in m_List.Keys)
            {
                if (m_List[filename].Count != p[filename].Count)
                    return false;

                foreach (string key in m_List[filename].Keys)
                {
                    if (!m_List[filename][key].Equals(p[filename][key]))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
#endregion
    }
}
