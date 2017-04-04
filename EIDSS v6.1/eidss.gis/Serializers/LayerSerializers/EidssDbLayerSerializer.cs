using System;
using eidss.gis.Layers;
using GIS_V4.Layers;
using GIS_V4.Serializers.LayerSerializers;
using GIS_V4.Serializers.SimpleTypeSerializers;
using GIS_V4.Serializers.StyleSerializers;
using GIS_V4.Serializers.ThemeSerializers;
using SharpMap.Styles;
using System.Xml;
using System.Drawing.Drawing2D;
//using SharpMap.Layers;

//using GIS_V4.Styles;

namespace eidss.gis.Serializers.LayerSerializers
{
    public abstract class EidssDbLayerSerializer
    {
        /// <summary>
        /// Serialize VectorLayer
        /// </summary>
        /// <param name="vectorLayer">VectorLayer to serialize</param>
        /// <param name="vectorLayerElement">Root element to serialize</param>
        public static void Serialize(EidssDbLayer vectorLayer, XmlElement vectorLayerElement)
        {
            XmlElement xmlElement;

            LayerSerializer.SerializeLayerFields(vectorLayer, vectorLayerElement);

            #region << Serialization >>

            //TODO[enikulin]: need refactoring. only one property (DataSource) and type of layer is changed from VectorLayer

            //DataSource
            try
            { EidssProviderSerializer.Instance.SerializeAsNode(vectorLayer.DataSource, vectorLayerElement, "DataSource"); }
            catch (Exception ex)
            { throw new VectorLayerSerializationException("DataSource can't be serialized: " + ex.Message, ex); }


            //LabelLayerGuid 
            xmlElement = vectorLayerElement.OwnerDocument.CreateElement("LabelLayerGuid");
            xmlElement.InnerText = vectorLayer.LabelLayerGuid.ToString();
            vectorLayerElement.AppendChild(xmlElement);

            //ClippingEnabled
            xmlElement = vectorLayerElement.OwnerDocument.CreateElement("ClippingEnabled");
            xmlElement.InnerText = vectorLayer.ClippingEnabled.ToString();
            vectorLayerElement.AppendChild(xmlElement);

            

            //SmoothingMode
            xmlElement = vectorLayerElement.OwnerDocument.CreateElement("SmoothingMode");
            xmlElement.InnerText = vectorLayer.SmoothingMode.ToString("D");
            vectorLayerElement.AppendChild(xmlElement);

            //SRID 
            xmlElement = vectorLayerElement.OwnerDocument.CreateElement("SRID");
            xmlElement.InnerText = vectorLayer.SRID.ToString("F0");
            vectorLayerElement.AppendChild(xmlElement);


            //Style 
            try
            { StyleSerializer.SerializeAsNode(vectorLayer.Style, vectorLayerElement); }
            catch (Exception ex)
            { throw new VectorLayerSerializationException("Style can't be serialized: " + ex.Message, ex); }

            //Theme
            try
            { ThemeSerializer.SerializeAsNode(vectorLayer.Theme, vectorLayerElement); }
            catch (Exception ex)
            { throw new VectorLayerSerializationException("Theme can't be serialized: " + ex.Message, ex); }



            //Marker size
            xmlElement = vectorLayerElement.OwnerDocument.CreateElement("MarkerSize");
            xmlElement.InnerText = vectorLayer.MarkerSize.ToString();
            vectorLayerElement.AppendChild(xmlElement);

            //Marker color
            try
            {
                ColorSerializer.SerializeAsNode(vectorLayer.MarkerColor, vectorLayerElement, "MarkerColor");
            }
            catch (Exception ex)
            {
                throw new VectorLayerSerializationException("'MarkerColor' can't be serialized: " + ex.Message, ex);
            }

            //Polygon Fill Style
            xmlElement = vectorLayerElement.OwnerDocument.CreateElement("PolygonFillStyle");
            xmlElement.InnerText = vectorLayer.PolygonFillStyle;
            vectorLayerElement.AppendChild(xmlElement);

            //Polygon Fill Color
            try
            {
                ColorSerializer.SerializeAsNode(vectorLayer.PolygonFillColor, vectorLayerElement, "PolygonFillColor");
            }
            catch (Exception ex)
            {
                throw new VectorLayerSerializationException("'PolygonFillColor' can't be serialized: " + ex.Message, ex);
            }

            #endregion
        }


        /// <summary>
        /// Deserialize VectorLayer
        /// </summary>
        /// <param name="vectorLayerElement">Root element to deserialize</param>
        /// <returns>VectorLayer</returns>
        public static EidssDbLayer Deserialize(XmlElement vectorLayerElement)
        {
            EidssDbLayer resultVectorLayer=null;
            XmlNode tempNode;
            LayerSerializer.LayerInfo lyrInfo;
            bool tempBool;
            int tempInt;

            #region <<Deserialize LayerFields >>

            try
            { lyrInfo = LayerSerializer.DeserializeLayerFields(vectorLayerElement); }
            catch (Exception ex)
            { throw new VectorLayerDeserializationException("VectorLayer can't be deserialized: " + ex.Message, ex); }

            //LabelLayer Guid 
            tempNode = vectorLayerElement.SelectSingleNode("LabelLayerGuid");
            if (tempNode == null)
                throw new VectorLayerDeserializationException("VectorLayer can't be deserialized: 'LayerElement' don't have element 'LabelLayerGuid'!");
            var labelLayerGuid = new Guid(tempNode.InnerText);

            //create layer
            switch (vectorLayerElement.Attributes["Type"].Value)
            {
                case "eidss.gis.Layers.EidssSystemDbLayer":
                    resultVectorLayer = new EidssSystemDbLayer(lyrInfo.LayerName, lyrInfo.Guid, labelLayerGuid);
                    break;
                case "eidss.gis.Layers.EidssExtSystemDbLayer":
                    resultVectorLayer = new EidssExtSystemDbLayer(lyrInfo.LayerName, lyrInfo.Guid, labelLayerGuid);
                    break;
            }


            resultVectorLayer.ControledByUser = lyrInfo.ControledByUser;
            resultVectorLayer.Enabled = lyrInfo.Enabled;
            resultVectorLayer.MaxVisible = lyrInfo.MaxVisible;
            resultVectorLayer.MinVisible = lyrInfo.MinVisible;
            //resultVectorLayer.SRID = lyrInfo.SRID; - тут бля косяк в провайдере! нет проверки!
            resultVectorLayer.VisibleInTOC = lyrInfo.VisibleInTOC;
            resultVectorLayer.Transparency = lyrInfo.Transparency;
            #endregion

            #region << Deserialize >>

            //ClippingEnabled
            tempNode = vectorLayerElement.SelectSingleNode("ClippingEnabled");
            if (tempNode == null)
                throw new VectorLayerDeserializationException("'VectorLayerElement' don't have element 'ClippingEnabled'!");
            if (!bool.TryParse(tempNode.InnerText, out tempBool))
                throw new VectorLayerDeserializationException("Can't parse node 'ClippingEnabled'!");
            resultVectorLayer.ClippingEnabled = tempBool;


            //DataSource
            try
            { resultVectorLayer.DataSource = EidssProviderSerializer.Instance.DeserializeFromNode(vectorLayerElement, "DataSource"); }
            catch (Exception ex)
            { throw new VectorLayerDeserializationException("DataSource can't be deserialized: " + ex.Message, ex); }

            //SmoothingMode
            tempNode = vectorLayerElement.SelectSingleNode("SmoothingMode");
            if (tempNode == null)
                throw new VectorLayerDeserializationException("'VectorLayerElement' don't have element 'SmoothingMode'!");
            if (!Int32.TryParse(tempNode.InnerText, out tempInt) || !Enum.IsDefined(typeof(SmoothingMode), tempInt))
                throw new VectorLayerDeserializationException("Can't parse node 'SmoothingMode'!");
            resultVectorLayer.SmoothingMode = (SmoothingMode)tempInt;

            //SRID
            tempNode = vectorLayerElement.SelectSingleNode("SRID");
            if (tempNode == null)
                throw new VectorLayerDeserializationException("'VectorLayerElement' don't have element 'SRID'!");
            if (!Int32.TryParse(tempNode.InnerText, out tempInt))
                throw new VectorLayerDeserializationException("Can't parse node 'SRID'!");
            resultVectorLayer.SRID = tempInt;

            //Style
            try
            { resultVectorLayer.Style = (VectorStyle)StyleSerializer.DeserializeFromNode(vectorLayerElement); }
            catch (Exception ex)
            { throw new VectorLayerSerializationException("Style can't be deserialized: " + ex.Message, ex); }

            //Theme            
            try
            { resultVectorLayer.Theme = ThemeSerializer.DeserializeFromNode(vectorLayerElement); }
            catch (Exception ex)
            { throw new VectorLayerSerializationException("Theme can't be deserialized: " + ex.Message, ex); }


            //Marker size
            tempNode = vectorLayerElement.SelectSingleNode("MarkerSize");
            if (tempNode == null)
                throw new VectorLayerDeserializationException("'VectorLayerElement' don't have element 'MarkerSize'!");
            if (!Int32.TryParse(tempNode.InnerText, out tempInt))
                throw new VectorLayerDeserializationException("Can't parse node 'MarkerSize'!");
            resultVectorLayer.MarkerSize = tempInt;

            //Marker color
            try
            {
                resultVectorLayer.MarkerColor = ColorSerializer.DeserializeFromNode(vectorLayerElement, "MarkerColor");
            }
            catch (Exception ex)
            {
                throw new VectorLayerSerializationException("MarkerColor can't be deserialized: " + ex.Message, ex);
            }

            //Polygon Fill Style
            tempNode = vectorLayerElement.SelectSingleNode("PolygonFillStyle");
            if (tempNode == null)
                throw new VectorLayerDeserializationException("'VectorLayerElement' don't have element 'PolygonFillStyle'!");
            resultVectorLayer.PolygonFillStyle = tempNode.InnerText;

            //Polygon Fill Color
            try
            {
                resultVectorLayer.PolygonFillColor = ColorSerializer.DeserializeFromNode(vectorLayerElement, "PolygonFillColor");
            }
            catch (Exception ex)
            {
                throw new VectorLayerSerializationException("PolygonFillColor can't be deserialized: " + ex.Message, ex);
            }

            #endregion

            return resultVectorLayer;
        }

    }

    public class EidssDbLayerSerializationException : LayerSerializationException
    {
        public EidssDbLayerSerializationException()
        { }
        public EidssDbLayerSerializationException(string message) : base(message) { }
        public EidssDbLayerSerializationException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class EidssDbLayerDeserializationException : LayerDeserializationException
    {
        public EidssDbLayerDeserializationException()
        { }
        public EidssDbLayerDeserializationException(string message) : base(message) { }
        public EidssDbLayerDeserializationException(string message, Exception innerException) : base(message, innerException) { }
    }
}