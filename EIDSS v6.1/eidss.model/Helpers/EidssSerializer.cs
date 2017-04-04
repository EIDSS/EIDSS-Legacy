using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace eidss.model.Helpers
{
    public class EidssSerializer<T> where T : class
    {
        private static readonly XmlSerializer m_Serializer = new XmlSerializer(typeof (T));

        static EidssSerializer()
        {
            m_Serializer.UnknownNode += serializer_UnknownNode;
            m_Serializer.UnknownAttribute += serializer_UnknownAttribute;
        }

        private static void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
        }

        private static void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
        }

        public string Serialize(T responses)
        {
            if (responses == null)
            {
                return null;
            }
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var sw = new StringWriter();
            XmlWriter writer = new XmlTextWriterFormattedNoDeclaration(sw);

            m_Serializer.Serialize(writer, responses, ns);

            return sw.ToString();
        }

        public T Deserialize(string xml)
        {
            if (xml == null)
            {
                return null;
            }

            var stringReader = new StringReader(xml);
            var entry = m_Serializer.Deserialize(stringReader) as T;

            return entry;
        }

        private class XmlTextWriterFormattedNoDeclaration : XmlTextWriter
        {
            public XmlTextWriterFormattedNoDeclaration(TextWriter w)
                : base(w)
            {
                Formatting = Formatting.Indented;
            }

            public override void WriteStartDocument()
            {
            }

            // suppress
        }
    }
}