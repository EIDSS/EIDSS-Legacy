using System;
using System.Collections.Generic;
using System.Drawing.Text;
using eidss.gis.Layers;
using GIS_V4.Layers;
using GIS_V4.Serializers.LayerSerializers;
using GIS_V4.Serializers.StyleSerializers;
using SharpMap.Styles;
using System.Xml;
using System.Drawing.Drawing2D;

//using SharpMap.Layers;

//using GIS_V4.Styles;
namespace eidss.gis.Serializers.LayerSerializers
{
    public abstract class EidssLabelLayerSerializer
    {
        /// <summary>
        /// Serialize LabelLayer
        /// </summary>
        /// <param name="labelLayer">LabelLayer to serialize</param>
        /// <param name="labelLayerElement">Root element to serialize</param>
        public static void Serialize(EidssLabelLayer labelLayer, XmlElement labelLayerElement)
        {
            XmlElement xmlElement;

            LayerSerializer.SerializeLayerFields(labelLayer, labelLayerElement);

            #region << Serialization >>

            //DataSource - это не правильно, так как соурс копируется два раза! 
            // после изменения лееров переделать на связь по id!
            try
            { EidssProviderSerializer.Instance.SerializeAsNode(labelLayer.DataSource, labelLayerElement, "DataSource"); }
            catch (Exception ex)
            { throw new EidssLabelLayerSerializationException("DataSource can't be serialized: " + ex.Message, ex); }

            //LabelColumn 
            xmlElement = labelLayerElement.OwnerDocument.CreateElement("LabelColumn");
            xmlElement.InnerText = labelLayer.LabelColumn;
            labelLayerElement.AppendChild(xmlElement);

            //LabelFilter (Temporary version)
            xmlElement = labelLayerElement.OwnerDocument.CreateElement("LabelFilter");
            xmlElement.InnerText = labelLayer.LabelFilter!=null?labelLayer.LabelFilter.Method.DeclaringType.FullName.ToString()+"+"+labelLayer.LabelFilter.Method.Name.ToString():null;
            labelLayerElement.AppendChild(xmlElement);

            //LabelStringDelegate
            //NotImplemented

            //MultipartGeometryBehaviour
            xmlElement = labelLayerElement.OwnerDocument.CreateElement("MultipartGeometryBehaviour");
            xmlElement.InnerText = labelLayer.MultipartGeometryBehaviour.ToString("D");
            labelLayerElement.AppendChild(xmlElement);

            //Priority
            xmlElement = labelLayerElement.OwnerDocument.CreateElement("Priority");
            xmlElement.InnerText = labelLayer.Priority.ToString();
            labelLayerElement.AppendChild(xmlElement);

            //RotationColumn
            xmlElement = labelLayerElement.OwnerDocument.CreateElement("RotationColumn");
            xmlElement.InnerText = labelLayer.RotationColumn;
            labelLayerElement.AppendChild(xmlElement);

            //SmoothingMode
            xmlElement = labelLayerElement.OwnerDocument.CreateElement("SmoothingMode");
            xmlElement.InnerText = labelLayer.SmoothingMode.ToString("D");
            labelLayerElement.AppendChild(xmlElement);

            //SRID 
            xmlElement = labelLayerElement.OwnerDocument.CreateElement("SRID");
            xmlElement.InnerText = labelLayer.SRID.ToString("F0");
            labelLayerElement.AppendChild(xmlElement);

            //Style 
            try
            { StyleSerializer.SerializeAsNode(labelLayer.Style, labelLayerElement); }
            catch (Exception ex)
            { throw new LabelLayerSerializationException("Style can't be serialized: " + ex.Message, ex); }

            //TextRenderingHint
            xmlElement = labelLayerElement.OwnerDocument.CreateElement("TextRenderingHint");
            xmlElement.InnerText = labelLayer.TextRenderingHint.ToString("D");
            labelLayerElement.AppendChild(xmlElement);

            //Theme 
            //NotImplemented

            #endregion
        }


        /// <summary>
        /// Deserialize LabelLayer
        /// </summary>
        /// <param name="labelLayerElement">Root element to deserialize</param>
        /// <returns>LabelLayer</returns>
        public static EidssLabelLayer Deserialize(XmlElement labelLayerElement)
        {
            EidssLabelLayer resultLabelLayer = null;
            LayerSerializer.LayerInfo lyrInfo;
            XmlNode tempNode;
            int tempInt;

            #region <<Deserialize LayerFields >>

            try
            { lyrInfo = LayerSerializer.DeserializeLayerFields(labelLayerElement); }
            catch (Exception ex)
            { throw new EidssLabelLayerDeserializationException("LabelLayer can't be deserialized: " + ex.Message, ex); }

            //create layer
            switch (labelLayerElement.Attributes["Type"].Value)
            {
                case "eidss.gis.Layers.EidssLabelLayer":
                    resultLabelLayer = new EidssLabelLayer(lyrInfo.LayerName, lyrInfo.Guid);
                    break;
                case "eidss.gis.Layers.EidssSystemLabelLayer":
                    resultLabelLayer = new EidssSystemLabelLayer(lyrInfo.LayerName, lyrInfo.Guid);
                    break;
                case "eidss.gis.Layers.EidssExtSystemLabelLayer":
                    resultLabelLayer = new EidssExtSystemLabelLayer(lyrInfo.LayerName, lyrInfo.Guid);
                    break;
            }

            resultLabelLayer.ControledByUser = lyrInfo.ControledByUser;
            resultLabelLayer.Enabled = lyrInfo.Enabled;
            resultLabelLayer.MaxVisible = lyrInfo.MaxVisible;
            resultLabelLayer.MinVisible = lyrInfo.MinVisible;
            //resultLabelLayer.SRID = lyrInfo.SRID; - тут бля косяк в провайдере! нет проверки!
            resultLabelLayer.VisibleInTOC = lyrInfo.VisibleInTOC;
            resultLabelLayer.Transparency = lyrInfo.Transparency;
            #endregion

            #region << Deserialize >>

            //DataSource - переделать 
            try
            { resultLabelLayer.DataSource = EidssProviderSerializer.Instance.DeserializeFromNode(labelLayerElement, "DataSource"); }
            catch (Exception ex)
            { throw new EidssLabelLayerDeserializationException("DataSource can't be deserialized: " + ex.Message, ex); }

            //LabelColumn 
            tempNode = labelLayerElement.SelectSingleNode("LabelColumn");
            if (tempNode == null)
                throw new EidssLabelLayerDeserializationException("'LabelLayerElement' don't have element 'LabelColumn'!");
            resultLabelLayer.LabelColumn = tempNode.InnerText;

            //LabelFilter
            tempNode = labelLayerElement.SelectSingleNode("LabelFilter");
            if (tempNode == null)
                throw new EidssLabelLayerDeserializationException("'LabelLayerElement' don't have element 'LabelFilter'!");
            resultLabelLayer.LabelFilter = LabelLayerSerializer.GetFilterLabelDelegate(tempNode.InnerText);

            //LabelStringDelegate
            //NotImplemented

            //MultipartGeometryBehaviour
            tempNode = labelLayerElement.SelectSingleNode("MultipartGeometryBehaviour");
            if (tempNode == null)
                throw new EidssLabelLayerDeserializationException("'LabelLayerElement' don't have element 'MultipartGeometryBehaviour'!");
            if (!Int32.TryParse(tempNode.InnerText, out tempInt) || !Enum.IsDefined(typeof(SharpMap.Layers.LabelLayer.MultipartGeometryBehaviourEnum), tempInt))
                throw new EidssLabelLayerDeserializationException("Can't parse node 'MultipartGeometryBehaviour'!");
            resultLabelLayer.MultipartGeometryBehaviour = (SharpMap.Layers.LabelLayer.MultipartGeometryBehaviourEnum)tempInt;

            //Priority
            tempNode = labelLayerElement.SelectSingleNode("Priority");
            if (tempNode == null)
                throw new EidssLabelLayerDeserializationException("'LabelLayerElement' don't have element 'Priority'!");
            if (!Int32.TryParse(tempNode.InnerText, out tempInt) || tempInt < 0)
                throw new EidssLabelLayerDeserializationException("Can't parse node 'Priority'!");
            resultLabelLayer.Priority = tempInt;

            //RotationColumn
            tempNode = labelLayerElement.SelectSingleNode("RotationColumn");
            if (tempNode == null)
                throw new EidssLabelLayerDeserializationException("'LabelLayerElement' don't have element 'RotationColumn'!");
            resultLabelLayer.RotationColumn = tempNode.InnerText;

            //SmoothingMode
            tempNode = labelLayerElement.SelectSingleNode("SmoothingMode");
            if (tempNode == null)
                throw new EidssLabelLayerDeserializationException("'LabelLayerElement' don't have element 'SmoothingMode'!");
            if (!Int32.TryParse(tempNode.InnerText, out tempInt) || !Enum.IsDefined(typeof(SmoothingMode), tempInt))
                throw new EidssLabelLayerDeserializationException("Can't parse node 'SmoothingMode'!");
            resultLabelLayer.SmoothingMode = (SmoothingMode)tempInt;


            //SRID
            tempNode = labelLayerElement.SelectSingleNode("SRID");
            if (tempNode == null)
                throw new EidssLabelLayerDeserializationException("'LabelLayerElement' don't have element 'SRID'!");
            if (!Int32.TryParse(tempNode.InnerText, out tempInt))
                throw new EidssLabelLayerDeserializationException("Can't parse node 'SRID'!");
            resultLabelLayer.SRID = tempInt;

            //Style
            try
            { resultLabelLayer.Style = (LabelStyle)StyleSerializer.DeserializeFromNode(labelLayerElement, "Style"); }
            catch (Exception ex)
            { throw new EidssLabelLayerDeserializationException("Style can't be deserialized: " + ex.Message, ex); }


            //TextRenderingHint
            tempNode = labelLayerElement.SelectSingleNode("TextRenderingHint");
            if (tempNode == null)
                throw new EidssLabelLayerDeserializationException("'LabelLayerElement' don't have element 'TextRenderingHint'!");
            if (!Int32.TryParse(tempNode.InnerText, out tempInt) || !Enum.IsDefined(typeof(TextRenderingHint), tempInt))
                throw new EidssLabelLayerDeserializationException("Can't parse node 'TextRenderingHint'!");
            resultLabelLayer.TextRenderingHint = (TextRenderingHint)tempInt;

            //Theme 
            //NotImplemented

            #endregion

            return resultLabelLayer;
        }

    }

    public class EidssLabelLayerSerializationException : LayerSerializationException
    {
        public EidssLabelLayerSerializationException(){}
        public EidssLabelLayerSerializationException(string message) : base(message) { }
        public EidssLabelLayerSerializationException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class EidssLabelLayerDeserializationException : LayerDeserializationException
    {
        public EidssLabelLayerDeserializationException(){}
        public EidssLabelLayerDeserializationException(string message) : base(message) { }
        public EidssLabelLayerDeserializationException(string message, Exception innerException) : base(message, innerException) { }
    }

}