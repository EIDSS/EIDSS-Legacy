using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.common.Resources.TranslationTool
{
    public class CommonResourcesCache
    {
        private readonly static Dictionary<string, Dictionary<string, ResourceValue>> m_CommonResources =
            new Dictionary<string, Dictionary<string, ResourceValue>>();

        private static string m_CultureCode = string.Empty;
        public static string GetText(string resourceName, string cultureCode, string key, bool returnDefaultValue = false)
        {
            lock (m_CommonResources)
            {
                InitResources(resourceName, cultureCode);
                string result = null;
                if (m_CommonResources[resourceName].ContainsKey(key))
                {
                    if (m_CommonResources[resourceName][key].Value != null)
                        result = m_CommonResources[resourceName][key].Value.ToString();
                }
                if (returnDefaultValue && string.IsNullOrEmpty(result))
                {
                    result = TranslationToolHelper.GetDefaultText(resourceName, key);
                } 
                return result;
                
            }
        }

        public static ResourceValue Get(string resourceName, string cultureCode, string key, string viewNameForSplit)
        {
            lock (m_CommonResources)
            {
                if(!string.IsNullOrEmpty(viewNameForSplit))
                {
                    var res = ResourceSplitter.Read(viewNameForSplit, key, null, cultureCode);
                    if (!string.IsNullOrEmpty(res))
                        return new ResourceValue()
                                   {
                                       ResourceName = resourceName,
                                       SourceKey = key,
                                       Value = res,
                                       IsSplitted = true
                                   };
                }
                InitResources(resourceName, cultureCode);
                if (m_CommonResources[resourceName].ContainsKey(key))
                    return m_CommonResources[resourceName][key];
                return null;
            }
        }
        public static void SetText(string resourceName, string cultureCode, string key, /*string rawValue,*/ string value)
        {
            lock (m_CommonResources)
            {
                InitResources(resourceName, cultureCode);
                if (m_CommonResources[resourceName].ContainsKey(key))
                {
                    //m_CommonResources[resourceName][key].RawValue = rawValue;
                    m_CommonResources[resourceName][key].Value = value;
                }
                else
                {
                    var resValue = new ResourceValue()
                                       {
                                           //SourceFileName = string.Format("{0}.{1}.resx", resourceName, cultureCode),
                                           SourceKey = key,
                                           //RawValue = rawValue,
                                           Value = value,
                                           ResourceName = resourceName
                                       };
                    m_CommonResources[resourceName].Add(key, resValue);
                }

            }
        }
        public static void SetValue(string resourceName, string cultureCode, string key, ResourceValue resValue)
        {
            lock (m_CommonResources)
            {
                InitResources(resourceName, cultureCode);
                if (m_CommonResources[resourceName].ContainsKey(key))
                {
                    m_CommonResources[resourceName][key] = resValue;
                }
                else
                {
                    m_CommonResources[resourceName].Add(key, resValue);
                }
            }

        }
        public static bool ContainsKey(string resourceName, string cultureCode, string key)
        {
            lock (m_CommonResources)
            {
                InitResources(resourceName, cultureCode);
                return m_CommonResources[resourceName].ContainsKey(key);
            }
        }
       private static void InitResources(string resourceName, string cultureCode)
        {
            if (cultureCode!=null && !m_CultureCode.Equals(cultureCode))
            {
                m_CultureCode = cultureCode;
                m_CommonResources.Clear();
            }
            if (!m_CommonResources.ContainsKey(resourceName))
            {
                var resValues = new Dictionary<string, ResourceValue>();
                TranslationToolHelper.ReadResxFile(resourceName, cultureCode, resValues, null);
                m_CommonResources.Add(resourceName,resValues);
            }
        }
        public static void Refresh(string resourceName, string cultureCode)
        {
            lock (m_CommonResources)
            {
                if (!m_CommonResources.ContainsKey(resourceName))
                    return;
                m_CommonResources.Remove(resourceName);
                InitResources(resourceName, cultureCode);
            }
        }

        public static void Reset()
        {
            lock (m_CommonResources)
            {
                m_CommonResources.Clear();
            }
        }



    }
}
