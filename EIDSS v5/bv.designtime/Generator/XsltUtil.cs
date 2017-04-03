using System;
using System.Reflection;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
//using MSXML2; // используется только при вызове из XSelerator
using bv.common.Configuration;

namespace bv.designtime.Generator
{
    [ComVisible(true)]
    [Guid("7873EEC5-CFFB-4895-B97C-9E8283C9A801")]

    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IXsltUtil
    {
        [DispId(1)]
        object Xml(string file);
        [DispId(2)]
        object SchemaXml(string sp);
        [DispId(3)]
        object ExpandXml(string outnames, string instr1, string instr2);
    }

    [Guid("F67384DB-A1C2-46e2-9882-D9F26170571B")]
    [ClassInterface(ClassInterfaceType.None)]
    public class XsltUtil : IXsltUtil
    {
        private Dictionary<string, XPathDocument> m_cacheFile = new Dictionary<string, XPathDocument>();
        private Dictionary<string, XmlDocument> m_cacheSchema = new Dictionary<string, XmlDocument>();
        private string m_root;
        private string m_connectionString;
        private bool m_fromXselerator;

        public XsltUtil()
        {
            m_fromXselerator = true;
            //m_root = @"C:\Work\sources\EIDSS_V4\bv.test\bv.tests3\Schema\";
            m_root = @"C:\Work\sources\EIDSS_V4\bv.test\bv.tests3\Schema\Objects\Tests\";
            m_connectionString = "Data Source=.;Initial Catalog=test;Integrated Security=True;";
        }

        public XsltUtil(string root, string connectionKey)
        {
            m_fromXselerator = false;
            m_root = root;
            Config.InitSettingsWithDir(root);
            m_connectionString = Config.GetSetting(connectionKey, "");
        }

        [ComVisible(true)]
        public object Xml(string file)
        {
            if (!m_fromXselerator)
            {
                XPathDocument doc;
                lock (m_cacheFile)
                {
                    if (m_cacheFile.ContainsKey(file))
                    {
                        doc = m_cacheFile[file];
                    }
                    else
                    {
                        doc = new XPathDocument(m_root + file);
                        m_cacheFile.Add(file, doc);
                    }
                }

                lock (doc)
                {
                    XPathNavigator nav = doc.CreateNavigator();
                    //return nav;
                    XPathNodeIterator iter = nav.Select("/");
                    return iter;
                }
            }
            else
            {
                string content = File.ReadAllText(m_root + file);
                return Convert(content);
            }
        }


        [ComVisible(true)]
        public object SchemaXml(string sp)
        {
            if (!m_fromXselerator)
            {
                XmlDocument doc;
                lock (m_cacheSchema)
                {
                    if (m_cacheSchema.ContainsKey(sp))
                    {
                        doc = m_cacheSchema[sp];
                    }
                    else
                    {
                        string content = GetSchemaXml(sp);
                        doc = new XmlDocument();
                        doc.LoadXml(content);
                        m_cacheSchema.Add(sp, doc);
                    }
                }

                lock (doc)
                {
                    XPathNavigator nav = doc.CreateNavigator();
                    //return nav;
                    XPathNodeIterator iter = nav.Select("/");
                    return iter;
                }
            }
            else
            {
                string content = GetSchemaXml(sp);
                return Convert(content);
            }
        }

        [ComVisible(true)]
        public object ExpandXml(string outnames, string instr1, string instr2)
        {
            string content = GetExpandXml(outnames, instr1, instr2);
            if (!m_fromXselerator)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(content);
                XPathNavigator nav = doc.CreateNavigator();
                XPathNodeIterator iter = nav.Select("/");
                return iter;
            }
            else
            {
                return Convert(content);
            }
        }



        private string GetExpandXml(string outnames, string instr1, string instr2)
        {
            string[] names = outnames.Replace(" ", "").Split(new char[] {','});
            string[] vals1 = instr1.Replace(" ", "").Split(new char[] { ',' });
            string[] vals2 = instr2.Replace(" ", "").Split(new char[] { ',' });

            var xmlret = new XElement("keys");
            for (int i = 0; i < vals1.Length; i++)
            {
                xmlret.Add(new XElement("key", new XAttribute(names[0], vals1[i]), new XAttribute(names[1], vals2[i])));
            }

            return xmlret.ToString();
        }


        private string GetSchemaXml(string sp)
        {
            var xmlschema = new XElement("schema", new XAttribute("sp", sp));

            try
            {
                var xmlparams = new XElement("params");
                var xmlresults = new XElement("results");
                using (var conn = new SqlConnection(m_connectionString))
                {
                    conn.Open();
                    var listParams = new List<string>();
                    var dicParamTypes = new Dictionary<string, string>();
                    string sqlParams = SqlForParams(sp);
                    using (var commParams = new SqlCommand())
                    {
                        commParams.Connection = conn;
                        commParams.CommandText = sqlParams;
                        commParams.CommandType = CommandType.Text;
                        var rdr = commParams.ExecuteReader();
                        while(rdr.Read())
                        {
                            if ((int)rdr["Direction"] != 6)
                            {
                                var name = (string)rdr["Name"];
                                var typename = (string)rdr["SystemType"];
                                var type = (string)rdr["Type"];
                                var direction = (int)rdr["Direction"];
                                var param = new XElement("param",
                                    new XAttribute("name", name.Substring(1)),
                                    new XAttribute("dbtype", typename),
                                    new XAttribute("type", type),
                                    new XAttribute("direction", direction == 1 ? "In" : "InOut")
                                    );

                                listParams.Add(name);
                                dicParamTypes.Add(name, typename);
                                xmlparams.Add(param);
                            }
                        }
                        rdr.Close();
                    }

                    using (var commReturn = new SqlCommand())
                    {
                        commReturn.Connection = conn;
                        if (sp.StartsWith("fn"))
                        {
                            commReturn.CommandText = "select * from dbo." + sp + "(";
                            foreach (var p in listParams)
                            {
                                if (!commReturn.CommandText.EndsWith("("))
                                    commReturn.CommandText += ", ";
                                commReturn.CommandText += p;
                            }
                            commReturn.CommandText += ")";
                            commReturn.CommandType = CommandType.Text;
                        }
                        else
                        {
                            commReturn.CommandText = sp;
                            commReturn.CommandType = CommandType.StoredProcedure;
                        }
                        foreach (var p in listParams)
                        {
                            var param = new SqlParameter(p, DBNull.Value);
                            if (dicParamTypes[p] == "varbinary")
                            {
                                param = new SqlParameter(p, SqlDbType.VarBinary);
                                param.Value = new Byte[0];
                            }
                            commReturn.Parameters.Add(param);
                        }


                        var rdr = commReturn.ExecuteReader();

                        do
                        {
                            var xmlcolumns = new XElement("columns");
                            var xmlkeys = new XElement("keys");

                            var schema = rdr.GetSchemaTable();
                            if (schema != null && schema.Rows != null)
                            {
                                bool keyadded = false;
                                foreach (DataRow line in schema.Rows)
                                {
                                    var name = (string)line["ColumnName"];
                                    var typename = (string)line["DataTypeName"];
                                    var size = (int)line["ColumnSize"];
                                    var type = (Type)line["DataType"];
                                    var nullable = line["AllowDBNull"] as bool?;
                                    var column = new XElement("column",
                                        new XAttribute("name", name),
                                        new XAttribute("dbtype", typename)
                                        );
                                    if (nullable != null && nullable.Value && type.IsValueType)
                                    {
                                        column.Add(new XAttribute("type", type.Name + "?"));
                                        column.Add(new XAttribute("nullable", "true"));
                                    }
                                    else
                                    {
                                        column.Add(new XAttribute("type", type.Name));
                                    }
                                    switch(typename)
                                    {
                                        case "varchar":
                                        case "char":
                                            column.Add(new XAttribute("size", size));
                                            break;
                                        case "nvarchar":
                                        case "nchar":
                                            column.Add(new XAttribute("size", size));
                                            break;
                                    }
                                    xmlcolumns.Add(column);

                                    if (!keyadded)
                                    {
                                        var key = new XElement("key",
                                            new XAttribute("name", name)
                                            );
                                        xmlkeys.Add(key);
                                        keyadded = true;
                                    }
                                }
                            }

                            xmlresults.Add(xmlcolumns);
                            xmlresults.Add(xmlkeys);

                        } while (rdr.NextResult());
                        rdr.Close();
                    }

                    conn.Close();
                }

                xmlschema.Add(xmlparams, xmlresults);
                
            }
            catch
            {

            }

            return xmlschema.ToString();
        }

        /// <summary>
        /// Создаём "Msxml2.DOMDocument.4.0" из xml строки
        /// Вызывается только из XSelerator
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns>Msxml2.DOMDocument.4.0</returns>
        private object Convert(string xmlContent)
        {
            throw new NotImplementedException();
            /*
            // создание пустого объекта для возврата
            Type domType = Type.GetTypeFromProgID("Msxml2.DOMDocument.4.0");
            object nav = Activator.CreateInstance(domType);

            if (xmlContent.Length > 0)
            {
                // заполнение возвращаемого объекта из объекта .NET
                object[] param = new object[1];
                param[0] = xmlContent;
                object res = domType.InvokeMember("loadXML", System.Reflection.BindingFlags.InvokeMethod,
                  null, nav, param);

                if ((bool)res == false)
                {
                    IXMLDOMParseError pe = (IXMLDOMParseError)domType.InvokeMember("parseError", System.Reflection.BindingFlags.GetProperty,
                          null, nav, new object[] { });

                    string reason = pe.reason + "Место, где произошла ошибка: " + pe.srcText + " Загружаемая строка: " + xmlContent + " Произошла ошибка loadXML объекта Msxml2.DOMDocument.4.0.";

                    throw new Exception(reason);
                }
            }

            return nav;
            */
        }

        private string SqlForParams(string sp)
        {
            return String.Format(
@"SELECT
	[Name] = N'@RETURN_VALUE',
	[ID] = 0,
	[Direction] = 6,
	[UserType] = NULL,
	[SystemType] = N'int',
	[Type] = N'Int32',
	[Size] = 4,
	[Precision] = 10,
	[Scale] = 0
WHERE
	OBJECTPROPERTY(OBJECT_ID(N'{0}'), 'IsProcedure') = 1
UNION
SELECT
	[Name] = CASE WHEN p.name <> '' THEN p.name ELSE '@RETURN_VALUE' END,
	[ID] = p.parameter_id,
	[Direction] = CASE WHEN p.is_output = 0 THEN 1 WHEN p.parameter_id > 0 AND p.is_output = 1 THEN 3 ELSE 6 END,
	[UserType] = CASE WHEN ut.is_assembly_type = 1 THEN SCHEMA_NAME(ut.schema_id) + '.' + ut.name ELSE NULL END,
	[SystemType] = CASE WHEN ut.is_assembly_type = 0 AND ut.user_type_id = ut.system_type_id THEN ut.name WHEN ut.is_user_defined = 1 OR ut.is_assembly_type = 0 THEN st.name ELSE 'UDT' END,
	[Type] = 
		CASE 
			WHEN ut.name = 'bit' THEN 'Boolean'
			WHEN ut.name = 'int' THEN 'Int32?'
			WHEN ut.name = 'bigint' THEN 'Int64?'
			WHEN ut.name = 'char' THEN 'String'
			WHEN ut.name = 'nchar' THEN 'String'
			WHEN ut.name = 'varchar' THEN 'String'
			WHEN ut.name = 'nvarchar' THEN 'String'
			WHEN ut.name = 'datetime' THEN 'DateTime?'
			WHEN ut.name = 'varbinary' THEN 'Byte[]'
			ELSE '' 
		END,
	[Size] = CONVERT(int, CASE WHEN st.name IN (N'text', N'ntext', N'image') AND p.max_length = 16 THEN -1 WHEN st.name IN (N'nchar', N'nvarchar', N'sysname') AND p.max_length >= 0 THEN p.max_length/2 ELSE p.max_length END),
	[Precision] = p.precision,
	[Scale] = p.scale
FROM
	sys.all_parameters p
	INNER JOIN sys.types ut ON p.user_type_id = ut.user_type_id
	LEFT OUTER JOIN sys.types st ON ut.system_type_id = st.user_type_id AND ut.system_type_id = st.system_type_id
WHERE
	object_id = OBJECT_ID(N'{0}')
ORDER BY
	2
", sp);
        }

    }
}
