using System;
using System.Xml;
using eidss.gis.Data.Providers;
using GIS_V4.Serializers;

namespace eidss.gis.Serializers.ProviderSerializers
{
    public abstract class EidssSqlServer2008ProviderSerializer
    {
        /// <summary>
        /// Serialize MsSql layer
        /// </summary>
        /// <param name="sqlLayer">MsSql layer to serialize</param>
        /// <param name="providerElement">xml element</param>
        public static void Serialize(EidssSqlServer2008 sqlLayer, XmlElement providerElement)
        {

            //DefinitionQuery
            XmlElement xmlElement = providerElement.OwnerDocument.CreateElement("DefinitionQuery");
            xmlElement.InnerText = sqlLayer.DefinitionQuery;
            providerElement.AppendChild(xmlElement);

            //Table
            xmlElement = providerElement.OwnerDocument.CreateElement("Table");
            xmlElement.InnerText = sqlLayer.Table;
            providerElement.AppendChild(xmlElement);

            //ValidateGeometries
            xmlElement = providerElement.OwnerDocument.CreateElement("ValidateGeometries");
            xmlElement.InnerText = sqlLayer.ValidateGeometries.ToString();
            providerElement.AppendChild(xmlElement);
            
        }

        /// <summary>
        /// Deserialize MsSql layer
        /// </summary>
        /// <param name="providerElement">xml element</param>
        /// <returns></returns>
        public static EidssSqlServer2008 Deserialize(XmlElement providerElement)
        {
            EidssSqlServer2008 resultSqlLayer;
            XmlNode tempNode;
            string defquery;
            string table;
            bool validateGeometries;

            #region <<Deserialization>>

            ////ConnectionID
            //tempNode = providerElement.SelectSingleNode("ConnectionID");
            //if (tempNode == null)
            //    throw new MsSqlProviderDeserializationException("'ptroviderElement' don't have element 'ConnectionID'!");
            //if (!int.TryParse(tempNode.InnerText, out connectionID))
            //    throw new MsSqlProviderDeserializationException("Can't parse node 'ConnectionID'!");

            //DefinitionQuery
            tempNode = providerElement.SelectSingleNode("DefinitionQuery");
            if (tempNode == null)
                throw new EidssSqlServerProviderDeserializationException("'ptroviderElement' don't have element 'DefinitionQuery'!");
            defquery = tempNode.InnerText;

            //Table
            tempNode = providerElement.SelectSingleNode("Table");
            if (tempNode == null)
                throw new EidssSqlServerProviderDeserializationException("'ptroviderElement' don't have element 'Table'!");
            table = tempNode.InnerText;

            //ValidateGeometries
            tempNode = providerElement.SelectSingleNode("ValidateGeometries");
            if (tempNode == null)
                throw new EidssSqlServerProviderDeserializationException("'ptroviderElement' don't have element 'ValidateGeometries'!");
            if (!bool.TryParse(tempNode.InnerText, out validateGeometries))
                throw new EidssSqlServerProviderDeserializationException("Can't parse node 'ValidateGeometries'!");

            try
            {
                resultSqlLayer = new EidssSqlServer2008(table) {DefinitionQuery = defquery};
            }
            catch (Exception ex)
            {
                throw new EidssSqlServerProviderDeserializationException("EidssSqlServer2008 Provider can't be create: " + ex.Message, ex);
            }

            #endregion

            return resultSqlLayer;
        }
    }

    public class EidssSqlServerProviderSerializationException : MapSerializationException
    {
        public EidssSqlServerProviderSerializationException() { }
        public EidssSqlServerProviderSerializationException(string message) : base(message) { }
        public EidssSqlServerProviderSerializationException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class EidssSqlServerProviderDeserializationException : MapDeserializationException
    {
        public EidssSqlServerProviderDeserializationException() { }
        public EidssSqlServerProviderDeserializationException(string message) : base(message) { }
        public EidssSqlServerProviderDeserializationException(string message, Exception innerException) : base(message, innerException) { }
    }
}