using System;
using System.Xml;
using GIS_V4.Serializers;
using GIS_V4.Serializers.DataSourceSerializers;
using SharpMap.Data.Providers;
using eidss.gis.Data.Providers;
using eidss.gis.Serializers.ProviderSerializers;

namespace eidss.gis.Serializers
{
    public class EidssProviderSerializer : ProviderSerializer
    {
        public new static EidssProviderSerializer Instance = new EidssProviderSerializer();

        protected override void Serialize(IProvider provider, XmlElement xmlElement)
        {
            // << Check provider on null>>
            if (provider == null)
            {
                xmlElement.InnerText = MapSerializerConst.NullValue;
            }
            else
            {
                //Add attr TYPE
                XmlAttribute typeAttribute = xmlElement.OwnerDocument.CreateAttribute("Type");
                typeAttribute.Value = provider.GetType().ToString();
                xmlElement.Attributes.Append(typeAttribute);

                switch (provider.GetType().ToString())
                {
                    case "eidss.gis.Data.Providers.EidssSqlServer2008":
                        EidssSqlServer2008ProviderSerializer.Serialize((EidssSqlServer2008) provider, xmlElement);
                        break;

                    case "SharpMap.Data.Providers.ShapeFile":
                        ShapeFileProviderSerializer.Serialize((ShapeFile) provider, xmlElement);
                        break;
                    case "SharpMap.Data.Providers.MsSql":
                        MsSqlProviderSerializer.Serialize((MsSql) provider, xmlElement);
                        break;
                    case "SharpMap.Data.Providers.SqlServer2008":
                        SqlServer2008ProviderSerializer.Serialize((SqlServer2008) provider, xmlElement);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        protected override IProvider Deserialize(XmlElement providerNode)
        {
            #region << Check value on NullValue >>

            if (providerNode.InnerText == MapSerializerConst.NullValue)
            {
                return null;
            }

            #endregion

            XmlAttribute typeAttribute = providerNode.Attributes["Type"];
            if (typeAttribute == null)
            {
                throw new ProviderDeserializationException("Element 'Provider' don't have attribute 'Type'!");
            }

            switch (typeAttribute.Value)
            {
                case "eidss.gis.Data.Providers.EidssSqlServer2008":
                    return EidssSqlServer2008ProviderSerializer.Deserialize(providerNode);

                case "SharpMap.Data.Providers.ShapeFile":
                    return ShapeFileProviderSerializer.Deserialize(providerNode);
                case "SharpMap.Data.Providers.MsSql":
                    return MsSqlProviderSerializer.Deserialize(providerNode);
                case "SharpMap.Data.Providers.SqlServer2008":
                    return SqlServer2008ProviderSerializer.Deserialize(providerNode);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}