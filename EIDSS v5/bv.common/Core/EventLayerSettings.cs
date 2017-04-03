using System.Xml;

namespace bv.common.Core
{
    public class EventLayerSettings
    {
        public int Position { get; set; }
        public XmlDocument LayerSettings { get; set; }
        public XmlDocument MapSettings { get; set; }
    }
}
