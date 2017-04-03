using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

namespace bv.model.ResourcesUsage
{
    public class FormDescriptionList : IEnumerable<FormDescription>
    {
        private readonly List<FormDescription> m_List = new List<FormDescription>();

        public int Count
        {
            get { return m_List.Count; }
        }

        public FormDescription this[string key]
        {
            get
            { return m_List.FirstOrDefault(f => f.Key == key); }
        }

        public FormDescription this[int key]
        {
            get
            { return m_List[key]; }
        }

        public IEnumerator<FormDescription> GetEnumerator()
        {
            foreach (FormDescription f in m_List)
                yield return f;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public FormDescription Add(FormDescription form)
        {
            // if this form was earlier - only edit it
            foreach (FormDescription f in m_List)
            {
                if (f.Key == form.Key)
                {
                    f.Apptype = form.Apptype;
                    f.Caption = form.Caption;
                    f.FormID = form.FormID;
                    f.Obsolete = false;
                    f.Views.Clear();
                    foreach (ViewDescription v in form.Views.Values)
                        f.Views.Add(v.Key, v);
                    return f;
                }
            }
            m_List.Add(form);
            return form;
        }

        public void Delete(FormDescription form)
        {
            m_List.Remove(form);
        }

        public void Delete(string key)
        {
            foreach (FormDescription f in m_List)
            {
                if (f.Key == key)
                {
                    m_List.Remove(f);
                    break;
                }
            }
        }

        // Load xml structure into List<FormDescription> m_List
        public void Load(string xmlFileName)
        {
            m_List.Clear();
            try
            {
                var xp = new XPathDocument(xmlFileName);
                XPathNavigator nav = xp.CreateNavigator();
                XPathNavigator fs = nav.SelectSingleNode("forms");
                XPathNodeIterator formsIt = fs.SelectChildren("form", "");
                if (formsIt.Count > 0)
                {
                    while (formsIt.MoveNext())
                    {//read one form
                        var f = new FormDescription();
                        f.Key = formsIt.Current.GetAttribute("key", "");
                        f.FormID = formsIt.Current.GetAttribute("formid", "");
                        f.Caption = formsIt.Current.GetAttribute("caption", "");
                        f.Apptype = formsIt.Current.GetAttribute("apptype", "");
                        string obsolete = formsIt.Current.GetAttribute("obsolete", "");
                        f.Obsolete = obsolete == "true" ? true : false;

                        XPathNavigator cIt = formsIt.Current.SelectSingleNode("comment");
                        if (cIt != null && !String.IsNullOrEmpty(cIt.InnerXml)) f.Comment = cIt.InnerXml;
                        cIt = formsIt.Current.SelectSingleNode("path");
                        if (cIt != null && cIt.InnerXml.Length > 0) f.PathsString = cIt.InnerXml;

                        XPathNavigator viewsIt = formsIt.Current.SelectSingleNode("views");
                        XPathNodeIterator viewIt = viewsIt.SelectChildren("view", "");
                        if (viewIt.Count > 0)
                        {
                            while (viewIt.MoveNext())
                            {//read one view
                                string Key = viewIt.Current.GetAttribute("key", "");
                                cIt = viewIt.Current.SelectSingleNode("comment");
                                string Comment = null;
                                if (cIt != null && !String.IsNullOrEmpty(cIt.InnerXml)) Comment = cIt.InnerXml;
                                f.Views.Add(Key, new ViewDescription(Key, Comment));
                            }
                        }

                        m_List.Add(f);
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                FileInfo fi1 = new FileInfo(xmlFileName);
                if (fi1.Length > 0)
                {
                    string xmlFileNameBak = xmlFileName.Replace(".xml", ".bak");
                    fi1.CopyTo(xmlFileNameBak, true);
                    fi1.Delete();
                }
            }
        }

        // Serialize List<FormDescription> m_List into xml
        public void Save(string xmlFileName)
        {
            FileStream fs = new FileStream(xmlFileName, FileMode.Create);
            XmlWriter writer = XmlWriter.Create(fs);

            writer.WriteStartDocument(true);
            writer.WriteStartElement("forms");

            foreach (FormDescription f in m_List)
            {
                writer.WriteStartElement("form");

                writer.WriteAttributeString("key", f.Key);
                writer.WriteAttributeString("caption", f.Caption);
                writer.WriteAttributeString("formid", f.FormID);
                writer.WriteAttributeString("apptype", f.Apptype);
                writer.WriteAttributeString("obsolete", f.Obsolete?"true":"false");

                writer.WriteElementString("comment", f.Comment);
                writer.WriteElementString("path", f.PathsString);

                writer.WriteStartElement("views");
                foreach (ViewDescription v in f.Views.Values)
                {
                    writer.WriteStartElement("view");
                    writer.WriteAttributeString("key", v.Key);
                    writer.WriteElementString("comment", v.Comment);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();

            // Close and release the writer resources.
            writer.Flush();
            fs.Flush();
            fs.Close();
        }

        #region IObject
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to FormDescriptionList return false.
            var p = obj as FormDescriptionList;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            if(m_List.Count != p.Count)
                return false;
            for (int i = 0; i < m_List.Count; i++)
                if(!m_List[i].Equals(p[i]))
                    return false;
                
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

    }
}
