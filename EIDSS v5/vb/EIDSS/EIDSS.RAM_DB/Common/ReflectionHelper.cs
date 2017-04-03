using System;
using System.Collections.Generic;
using System.Reflection;
using bv.common.Core;

namespace EIDSS.RAM_DB.Common
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// Create clone of "source" object. 
        /// Clone contains the same non-indexed properties 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Object to copy from</param>
        /// <returns></returns>
        public static T CreateAndCopyProperties<T>(T source) where T : class, new()
        {
            Utils.CheckNotNull(source, "source");

            var newField = new T();
            CopyProperties(source, newField);
            return newField;
        }

        /// <summary>
        /// Copies all writable properties from "source" object to "dest" object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Object to copy from</param>
        /// <param name="dest">Object to copy to</param>
        public static void CopyProperties<T>(T source, T dest) where T : class
        {
            Utils.CheckNotNull(source, "source");
            Utils.CheckNotNull(dest, "dest");

            Type type = typeof (T);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.CanRead && property.CanWrite)
                {
                    object value = property.GetValue(source, null);
                    property.SetValue(dest, value, null);
                }
            }
        }

        /// <summary>
        /// Copies writeble properties from "source" object to "dest" object in case
        /// "source" object and "dest" object contains properies with the same name and type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="source">Object to copy from</param>
        /// <param name="dest">Object to copy to</param>
        /// <param name="ignoreProperties">Properties that should not be copied</param>
        public static void CopyCommonProperties<T, K>(T source, K dest, List<string> ignoreProperties = null)
            where T : class
            where K : class
        {
            Utils.CheckNotNull(source, "source");
            Utils.CheckNotNull(dest, "dest");
            if (ignoreProperties == null)
            {
                ignoreProperties = new List<string>();
            }

            Type sourceType = typeof (T);
            Type destType = typeof (K);
            var sourceProperties = new List<PropertyInfo>(sourceType.GetProperties());
            var destProperties = new List<PropertyInfo>(destType.GetProperties());
            foreach (PropertyInfo sourceProp in sourceProperties)
            {
                var sourcePropName = sourceProp.Name;
                if ((!ignoreProperties.Contains(sourcePropName)) && sourceProp.CanRead)
                {
                    var foundByName = destProperties.FindAll(prop => prop.Name == sourcePropName);
                    //PropertyInfo destProp = destType.GetProperty(sourcePropName);
                    foreach (var destProp in foundByName)
                    {
                        if (destProp.CanWrite)
                        {
                            if (destProp.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
                            {
                                object value = sourceProp.GetValue(source, null);
                                destProp.SetValue(dest, value, null);
                            }
                        }
                    }
                   
                }
            }
        }
    }
}