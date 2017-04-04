using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Resources.TranslationTool;

namespace bv.common.Resources
{
    public class ResourceHelper
    {
        private static readonly object m_LockObject = new object();
        private static object ReadResxValue(ResXResourceReader reader, string key)
        {
            var dict = reader.GetEnumerator();
            while (dict.MoveNext())
            {
                if (dict.Value == null) continue;
                if (dict.Key.Equals(key))
                {
                    return dict.Value.ToString();
                }
            }
            return null;
        }
        public static object ReadResxValue(string fileName, string key)
        {
            try
            {
                if (!File.Exists(fileName))
                    return null;
                lock (m_LockObject)
                {
                    using (var reader = new ResXResourceReader(fileName))
                    {
                        return ReadResxValue(reader, key);
                    }

                }
            }
            catch (Exception e)
            {
                Dbg.Debug("error during resource reading. Resource {0}, error: {1}", fileName, e);
                return null;
            }
        }
        public static string ReadResxTextValue(ResXResourceReader reader, string key)
        {
            var value = ReadResxValue(reader, key);
            if (value != null && value is string)
                return value.ToString();
            return null;
        }
        public static string ReadResxTextValue(string fileName, string key)
        {
            var value = ReadResxValue(fileName, key);
            if (value != null && value is string)
                return value.ToString();
            return null;
        }
        public static void GetResxDictionary(string viewName, string fileName, ref Dictionary<string, ResourceValue> dict)
        {
            if (!File.Exists(fileName) || dict == null)
                return;
            try
            {
                lock (m_LockObject)
                {
                    using (var reader = new ResXResourceReader(fileName) { UseResXDataNodes = true })
                    {
                        var node = reader.GetEnumerator();
                        //var sourceFileName = Path.GetFileName(fileName);
                        while (node.MoveNext())
                        {
                            if (!dict.ContainsKey(node.Key.ToString()))
                            {
                                var resxNode = (ResXDataNode)node.Value;
                                object val = resxNode.GetValue((ITypeResolutionService)null);
                                dict.Add(node.Key.ToString(), new ResourceValue()
                                {
                                    //RawValue = val is string ? val.ToString() : null,
                                    Value = val,
                                    Comment = resxNode.Comment,
                                    //SourceFileName = sourceFileName,
                                    ResourceName = viewName,
                                    SourceKey = node.Key.ToString()
                                });

                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Dbg.Debug("error during resource reading. Resource {0}, error: {1}", fileName, e);
            }
        }
        public static  Dictionary<string, object> ReadResxDictionary(string fileName)
        {
            try
            {
                var dict = new Dictionary<string, object>();
                if (File.Exists(fileName))
                {
                    lock (m_LockObject)
                    {
                        using (var reader = new ResXResourceReader(fileName))
                        {
                            var enumerator = reader.GetEnumerator();
                            while (enumerator.MoveNext())
                            {
                                var keystr = enumerator.Key.ToString();
                                var val = enumerator.Value.ToString();
                                dict.Add(keystr, enumerator.Value);
                            }
                        }
                    }
                }
                return dict;
            }
            catch (Exception e)
            {
                Dbg.Debug("error during resource reading. Resource {0}, error: {1}", fileName, e);
                return null;
            }
        }
        public  static void WriteToResx(string fileName, string key, object newValue)
        {
            if(newValue==null || string.IsNullOrWhiteSpace(newValue.ToString()))
                return;
            var dict = ReadResxDictionary(fileName);
            if(!dict.ContainsKey(key))
                dict.Add(key, newValue);
            else
                dict[key] = newValue;
            try
            {
                lock (m_LockObject)
                {
                    if (File.Exists(fileName))
                    {
                        var fi = new FileInfo(fileName) { IsReadOnly = false };
                        fi.Refresh();
                    } 
                    using (var writer = new ResXResourceWriter(fileName))
                    {
                        foreach (var keypair in dict)
                        {
                            writer.AddResource(keypair.Key, keypair.Value);
                        }
                        writer.Generate();
                        writer.Close();
                    }
                }
                
            }
            catch(Exception e)
            {
                Dbg.Debug("error during resource writing. Resource {0}, error: {1}", fileName, e);
                throw;
            }
        }

        public static void WriteToResx(string fileName, Dictionary<string, ResourceValue> resourceValues, SizeF autoScaleFactor)
        {
            if (resourceValues == null || resourceValues.Count == 0)
                return;
            try
            {
                lock (m_LockObject)
                {
                    if (File.Exists(fileName))
                    {
                        var fi = new FileInfo(fileName) { IsReadOnly = false };
                        fi.Refresh();
                    }
                    using (var writer = new ResXResourceWriter(fileName))
                    {
                        foreach (var res in resourceValues)
                        {
                            //skip resources with empty values
                            if (res.Value == null || string.IsNullOrWhiteSpace(res.Value.ToString()))
                                continue;
                            object value = res.Value.Value;
                            string key = string.IsNullOrEmpty(res.Value.SourceKey) ? res.Key : res.Value.SourceKey;
                            if (res.Value.Modified)
                            {
                                if (key.EndsWith(".Size"))
                                    value = GetScaledSize((Size) value, autoScaleFactor);
                                else if (key.EndsWith(".Location"))
                                    value = GetScaledPoint((Point) value, autoScaleFactor);
                            }
                            writer.AddResource(key, value);
                        }
                        writer.Generate();
                        writer.Close();
                    }
                }

            }
            catch (Exception e)
            {
                Dbg.Debug("error during resource writing. Resource {0}, error: {1}", fileName, e);
                throw;
            }
        }

        private static int Scale(int val, float factor)
        {
            var scaled = (int) (val / factor);
            if(factor>1)
                while (((int) Math.Round(scaled * factor)) < val)
                {
                    scaled +=  1 ;
                }
            else
            {
                while (((int)Math.Round(scaled * factor)) > val)
                {
                    scaled -= 1;
                }
            }
            return scaled;
        }
        private static Point GetScaledPoint(Point point, SizeF autoScaleFactor)
        {
            point.X = Scale(point.X , autoScaleFactor.Width);
            point.Y = Scale(point.Y , autoScaleFactor.Height);
            return point;
        }

        private static Size GetScaledSize(Size size, SizeF autoScaleFactor)
        {
            size.Width = Scale(size.Width , autoScaleFactor.Width);
            size.Height = Scale(size.Height , autoScaleFactor.Height);
            return size;
        }
    }
}
