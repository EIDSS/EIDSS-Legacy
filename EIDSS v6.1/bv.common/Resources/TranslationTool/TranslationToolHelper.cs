using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using bv.common.Core;

namespace bv.common.Resources.TranslationTool
{
    public class TranslationToolHelper
    {
        public const string LocationPropName = "Location";
        public const string SizePropName = "Size";
        public const string TextPropName = "Text";
        public const string CaptionPropName = "Caption";
        public const string VisiblePropName = "Visible";
        public const string DescriptionPropName = "Properties.Items";
        public const string CustomizationFormTextPropName = "CustomizationFormText";
        public const string PropertiesCaptionPropName = "Properties.Caption";
        public const string AutoScaleDimensions = "AutoScaleDimensions";
        public const string ThisAutoScaleDimensions = "$this.AutoScaleDimensions";

        public static string TranslationsDirectoryName { get { return Path.Combine(RootPath, "Translations", "Resources"); } }
        public static string ResourceUsageDirectoryName { get { return Path.Combine(RootPath, "Translations", "ResourceUsage"); } }
        public static string ExclusionsDirectoryName { get { return Path.Combine(RootPath, "Translations", "Exclusions"); } }

        public static string SplittedResourcesFileName { get { return Path.Combine(RootPath, "Translations", "SplittedResources.{0}.xml"); } }

        private static string m_RootPath;
        public static void SetDefaultTranslationPath()
        {
            var eidssModule = AppDomain.CurrentDomain.GetAssemblies()
                     .FirstOrDefault(a => a.FullName.ToLowerInvariant().StartsWith("eidss"));
            if (eidssModule != null)
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(eidssModule.Location);
                m_RootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                                          fvi.CompanyName.TrimEnd(' ', '.'), fvi.ProductName.TrimEnd(' ', '.'));
            }
        }
        public static string RootPath
        {
            get
            {
                if (string.IsNullOrEmpty(m_RootPath))
                {
                    return string.Empty;
                }
                return m_RootPath;
            }
            set { m_RootPath = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="cultureCode"></param>
        /// <returns></returns>
        public static string GetResourceFilename(string className, string cultureCode)
        {
            return
                String.Format(string.IsNullOrEmpty(cultureCode)
                ? "{0}.resx"
                : "{0}.{1}.resx", className, cultureCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="className"></param>
        /// <param name="cultureCode"> </param>
        /// <returns></returns>
        public static string GetResourceFilename(string path, string className, string cultureCode)
        {
            return Path.Combine(path
                , String.Format(string.IsNullOrEmpty(cultureCode) || cultureCode == Localizer.SupportedLanguages[Localizer.lngEn]
                ? "{0}.resx"
                : "{0}.{1}.resx", className, cultureCode));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="controlName"> </param>
        /// <param name="file"> </param>
        /// <param name="key"> </param>
        /// <returns></returns>
        protected static void GetXmlNodeValue(string fileName, string controlName, out string file, out string key)
        {
            file = key = String.Empty;

            using (var reader = new XmlTextReader(fileName))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name.Equals("data")))
                    {
                        var nv = reader.GetAttribute("name") ?? String.Empty;
                        if (nv == controlName)
                        {
                            file = reader.GetAttribute("file") ?? String.Empty;
                            key = reader.GetAttribute("key") ?? String.Empty;
                        }
                    }
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="resName"> </param>
        /// <param name="cultureCode"></param>
        /// <returns></returns>
        public static string GetFullPathToResX(string resName, string cultureCode)
        {
            if (string.IsNullOrEmpty(TranslationsDirectoryName))
                return string.Empty;
            var resfilename = GetResourceFilename(resName, null);
            //ищем с корневого каталога и вглубь файлы с таким именем
            if (!Directory.Exists(TranslationsDirectoryName))
                return string.Empty;
            var files = Directory.GetFiles(TranslationsDirectoryName, resfilename, SearchOption.AllDirectories);
            if (files.Length > 0)
            {
                if (!string.IsNullOrEmpty(cultureCode))
                    return Path.ChangeExtension(files[0], string.Format("{0}.resx", cultureCode));
                return files[0];
            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exclusionsDir"></param>
        /// <param name="resName"></param>
        /// <param name="cultureCode"></param>
        /// <returns></returns>
        public static string GetFullPathToXml(string exclusionsDir, string resName, string cultureCode)
        {
            var file = GetResourceFilename(exclusionsDir, resName, cultureCode);
            return Path.ChangeExtension(file, "xml");
        }


        public static readonly string[] SupportedProperties = new[]
                                                             {
                                                                 TextPropName,
                                                                 CaptionPropName,
                                                                 LocationPropName,
                                                                 SizePropName,
                                                                 VisiblePropName,
                                                                 PropertiesCaptionPropName,
                                                                 AutoScaleDimensions
                                                             };

        private static bool IsSupportedProperty(string key)
        {
            return SupportedProperties.Any(key.EndsWith);
        }

        /// <summary>
        /// Reads properties supported for translations from national resource file,
        /// then from custom english resource file.
        /// Default resource file is not intended for translations, it is read to initialize english captions only.
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="cultureCode"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static Dictionary<string, ResourceValue> ReadResxFile(string viewName, string cultureCode, Dictionary<string, ResourceValue> dict, Dictionary<string, ResourceValue> defaultDict)
        {
            if (dict == null)
                dict = new Dictionary<string, ResourceValue>();
            if (string.IsNullOrEmpty(TranslationsDirectoryName))
                return dict;
            //read national resources if current language is not english only
            if (!string.IsNullOrEmpty(cultureCode) && !cultureCode.StartsWith("en"))
            {
                var resFullPath = GetFullPathToResX(viewName, cultureCode);
                ResourceHelper.GetResxDictionary(viewName, resFullPath, ref dict);
            }
            var resFullPathEngCustom = GetFullPathToResX(viewName, CustomCultureHelper.SupportedLanguages[Localizer.lngEn]);
            ResourceHelper.GetResxDictionary(viewName, resFullPathEngCustom, ref dict);
            ReadEnglishCaptions(viewName, dict, defaultDict);
            return dict;
        }

        public static string GetDefaultText(string resourceName, string key)
        {
            var filePath = GetFullPathToResX(resourceName, null);
            return ResourceHelper.ReadResxTextValue(filePath, key);
        }
        private static void ReadEnglishCaptions(string viewName, Dictionary<string, ResourceValue> dict, Dictionary<string, ResourceValue> defaultDict)
        {
            var filePath = GetFullPathToResX(viewName, null);
            var enDict = new Dictionary<string, ResourceValue>();
            ResourceHelper.GetResxDictionary(viewName, filePath, ref enDict);
            if (defaultDict != null)
                foreach (var resourceValue in enDict)
                {
                    if (IsNotInheritedObject(resourceValue.Key) && IsSupportedProperty(resourceValue.Key) && !defaultDict.ContainsKey(resourceValue.Key))
                    {
                        defaultDict.Add(resourceValue.Key, resourceValue.Value);
                    }
                }

            foreach (var resourceValue in dict)
            {
                if (enDict.ContainsKey(resourceValue.Key) && resourceValue.Value.Value is string)
                {
                    resourceValue.Value.EnglishText = Utils.Str(enDict[resourceValue.Key].Value);
                }
            }

        }

        private static bool IsNotInheritedObject(string key)
        {
            return !string.IsNullOrEmpty(key) && !key.StartsWith(">>");
        }

        public static string GetPropertyName(string ctlName, string propName)
        {
            return string.Format("{0}.{1}", ctlName, propName);
        }
    }
}
