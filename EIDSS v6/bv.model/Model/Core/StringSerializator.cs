using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.IO;

namespace bv.model.Model.Core
{
    public static class StringSerializator
    {
        public static string SerializeObject<T>(T objectToSerialize)
        {
            var bf = new BinaryFormatter();
            var memStr = new MemoryStream();

            try
            {
                bf.Serialize(memStr, objectToSerialize);
                memStr.Position = 0;

                return Convert.ToBase64String(memStr.ToArray());
            }
            finally
            {
                memStr.Close();
            }
        }

        public static T DeserializeObject<T>(string str)
        {
            var bf = new BinaryFormatter();
            byte[] b = Convert.FromBase64String(str); 
            var ms = new MemoryStream(b);

            try
            {
                return (T)bf.Deserialize(ms);
            }
            finally
            {
                ms.Close();
            }
        }
    }
}
