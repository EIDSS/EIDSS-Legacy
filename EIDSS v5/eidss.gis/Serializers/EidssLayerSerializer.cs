using System;
using System.Xml;
using eidss.gis.Layers;
using eidss.gis.Serializers.LayerSerializers;
using GIS_V4.Layers;
using GIS_V4.Serializers;
using GIS_V4.Serializers.LayerSerializers;

namespace eidss.gis.Serializers
{
    public class EidssLayerSerializer:LayerSerializer
    {
        public new static EidssLayerSerializer Instance = new EidssLayerSerializer();
        
        protected override void Serialize(SharpMap.Layers.Layer layer, XmlElement lyrElement)
        {
            // << Check layer on null>>
            if (layer == null)
            {
                lyrElement.InnerText = MapSerializerConst.NullValue;
            }
            else
            {
                //Add attr TYPE
                XmlAttribute typeAttribute = lyrElement.OwnerDocument.CreateAttribute("Type");
                typeAttribute.Value = layer.GetType().ToString();
                lyrElement.Attributes.Append(typeAttribute);
                switch (layer.GetType().ToString())
                {
                    case "eidss.gis.Layers.EidssSystemDbLayer":
                    case "eidss.gis.Layers.EidssExtSystemDbLayer":
                        EidssDbLayerSerializer.Serialize((EidssDbLayer)layer, lyrElement);
                        break;
                    case "eidss.gis.Layers.EidssUserDbLayer":
                    case "eidss.gis.Layers.EidssUserBufZoneLayer":
                        EidssUserDbLayerSerializer.Serialize((EidssUserDbLayer)layer, lyrElement);
                        break;
                    case "eidss.gis.Layers.EidssLabelLayer":
                    case "eidss.gis.Layers.EidssSystemLabelLayer":
                    case "eidss.gis.Layers.EidssExtSystemLabelLayer":
                        EidssLabelLayerSerializer.Serialize((EidssLabelLayer)layer, lyrElement);
                        break;

                    case "GIS_V4.Layers.VectorLayer":
                        VectorLayerSerializer.Serialize((VectorLayer)layer, lyrElement);
                        break;
                    case "GIS_V4.Layers.LabelLayer":
                        LabelLayerSerializer.Serialize((LabelLayer)layer, lyrElement);
                        break;
                    case "GIS_V4.Layers.GdalRasterLayer":
                        GdalRasterLayerSerializer.Serialize((GdalRasterLayer)layer, lyrElement);
                        break;
                    case "GIS_V4.Layers.LayerGroup":
                        EidssLayerGroupSerializer.Instance.Serialize((LayerGroup)layer, lyrElement);
                        break;
                    case "GIS_V4.Layers.TileLayer":
                        TileLayerSerializer.Serialize((TileLayer)layer, lyrElement);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        protected override SharpMap.Layers.Layer Deserialize(XmlElement layerNode)
        {
            #region << Check value on NullValue >>
            if (layerNode.InnerText == MapSerializerConst.NullValue)
            {
                return null;
            }
            #endregion

            XmlAttribute typeAttribute = layerNode.Attributes["Type"];
            if (typeAttribute == null)
                throw new LayerDeserializationException("Element 'Layer' don't have attribute 'Type'!");

            switch (typeAttribute.Value)
            {
                case "eidss.gis.Layers.EidssSystemDbLayer":
                case "eidss.gis.Layers.EidssExtSystemDbLayer":
                    return EidssDbLayerSerializer.Deserialize(layerNode);
                case "eidss.gis.Layers.EidssUserDbLayer":
                case "eidss.gis.Layers.EidssUserBufZoneLayer":
                    return EidssUserDbLayerSerializer.Deserialize(layerNode);
                case "eidss.gis.Layers.EidssLabelLayer":
                case "eidss.gis.Layers.EidssSystemLabelLayer":
                case "eidss.gis.Layers.EidssExtSystemLabelLayer":
                    return EidssLabelLayerSerializer.Deserialize(layerNode);

                case "GIS_V4.Layers.VectorLayer":
                    return VectorLayerSerializer.Deserialize(layerNode);
                case "GIS_V4.Layers.LabelLayer":
                    return LabelLayerSerializer.Deserialize(layerNode);
                case "GIS_V4.Layers.GdalRasterLayer":
                    return GdalRasterLayerSerializer.Deserialize(layerNode);
                case "GIS_V4.Layers.LayerGroup":
                    return EidssLayerGroupSerializer.Instance.Deserialize(layerNode);
                case "GIS_V4.Layers.TileLayer":
                    return TileLayerSerializer.Deserialize(layerNode);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}