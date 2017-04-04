using System;
using System.Xml;

namespace bv.common.Core
{
    public class EventLayerSettings
    {
        public EventLayerSettings()
        {
        }

        public EventLayerSettings(XmlDocument layerSettings, XmlDocument mapSettings, int position)
        {
            LayerSettings = layerSettings;

            //m_GradTheme = (XmlDocument) LayerSettings.ChildNodes[0];
            //m_ChartTheme = (XmlDocument)LayerSettings.ChildNodes[1];

            MapSettings = mapSettings;
            Position = position;
        }

        //public XmlDocument LayerSettings { get; private set; }

        //private XmlDocument m_GradTheme;
        //private XmlDocument m_ChartTheme;

        //public void SetLayerThemes(XmlDocument gradTheme, XmlDocument chartTheme)
        //{
        //    try
        //    {
        //        m_GradTheme = gradTheme;
        //        m_ChartTheme = chartTheme;

        //        var xmlDocument = new XmlDocument();
        //        xmlDocument.AppendChild(m_GradTheme);
        //        xmlDocument.AppendChild(m_ChartTheme);
        //        LayerSettings = xmlDocument;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("AVR Layer Settings", exception);
        //    }
        //}

        public XmlDocument LayerSettings { get; set; }
        public XmlDocument MapSettings { get; set; }
        public int Position { get; set; }
    }
}