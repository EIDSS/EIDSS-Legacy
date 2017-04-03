using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using bv.common.Core;

namespace EIDSS.Reports.BaseControls.Filters
{
    public class MultiFilterEventArgs : EventArgs
    {
        private readonly IDictionary<long, string> m_Dictionary;

        public MultiFilterEventArgs(IDictionary<long, string> dictionary)
        {
            Utils.CheckNotNull(dictionary, "dictionary");
            m_Dictionary = dictionary;
        }

        public IDictionary<long, string> Dictionary
        {
            get { return m_Dictionary; }
        }

        public string[] KeyArray
        {
            get { return Dictionary.Keys.Select(k => k.ToString(CultureInfo.InvariantCulture)).ToArray(); }
        }

        public string GetXmlResult(int? maxCount = null)
        {
            var document = new XmlDocument();

            XmlElement root = document.CreateElement("ItemList");
            document.AppendChild(root);

            int count = 0;
            foreach (KeyValuePair<long, string> pair in Dictionary)
            {
                if ((maxCount.HasValue && count >= maxCount.Value))
                    break;

                count++;
                XmlElement elem = document.CreateElement("Item");

                XmlAttribute atrKey = document.CreateAttribute("key");
                atrKey.Value = pair.Key.ToString();

                XmlAttribute atrValue = document.CreateAttribute("value");
                atrValue.Value = pair.Value;

                elem.Attributes.Append(atrKey);
                elem.Attributes.Append(atrValue);

                root.AppendChild(elem);
            }
            return document.OuterXml;
        }
    }
}