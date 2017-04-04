using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using BLToolkit.Reflection;

namespace bv.model.BLToolkit
{
    public static class Serializer
    {
        public static byte[] ToByteArray<T>(T obj, SurrogateSelector ss = null)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.SurrogateSelector = ss;
            using (MemoryStream stm = new MemoryStream())
            {
                formatter.Serialize(stm, obj);
                stm.Position = 0L;
                using (BinaryReader mr = new BinaryReader(stm))
                {
                    return mr.ReadBytes((int)stm.Length);
                }
            }
        }
        public static T FromByteArray<T>(byte[] array, SurrogateSelector ss = null)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.SurrogateSelector = ss;
            using (MemoryStream stm = new MemoryStream(array))
            {
                return (T)formatter.Deserialize(stm);
            }
        }

        public static string ToXmlString<T>(T obj)
        {
            XmlSerializer sr = new XmlSerializer(TypeAccessor<T>.Type);
            using (MemoryStream stm = new MemoryStream())
            {
                sr.Serialize(stm, obj);
                stm.Position = 0L;
                using (StreamReader mr = new StreamReader(stm))
                {
                    return mr.ReadToEnd();
                }
            }
        }

        public static T FromXmlString<T>(string xml)
        {
            XmlSerializer sr = new XmlSerializer(TypeAccessor<T>.Type);
            using (MemoryStream stm = new MemoryStream())
            {
                using (StreamWriter mw = new StreamWriter(stm))
                {
                    mw.Write(xml);
                    mw.Flush();
                    stm.Position = 0L;
                    return (T) sr.Deserialize(stm);
                }
            }
        }
    }
}
