using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Resources.TranslationTool;

namespace bv.common.Resources
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Provides reading/writing of resource strings from specified resource file.
    /// </summary>
    /// <remarks>
    /// This class is used internally by other classes that work with specific resource files
    /// </remarks>
    /// <history>
    /// 	[Mike]	03.04.2006	Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class BaseStringsStorage
    {
        public static bool ForceAbsentResourceAdding { get; set; }

        protected string m_ResFileName;
        private ResourceManager m_ResourceManager;
        public bool IsValueExists { get; internal set; }

        private string ReturnEmptyValue(string stringName, string stringValue)
        {
            string ret = Utils.IsEmpty(stringValue) ? stringName : stringValue;
            if (!Utils.IsEmpty(ret) && BaseSettings.WarnIfResourceEmpty)
                ret = ret + " (TRANSLATED RESOURCE IS ABSENT)";
            return ret;
        }

        public virtual string GetString(string stringName, string stringValue = null, string langId = null, string viewName = null )
        {
            bool found;
            var ret = TranslationToolOnlineStorage.GetTranslated(this, stringName, stringValue, langId, viewName, out found);
            if(found)
                TranslationToolOnlineStorage.AddTranslated(this, stringName, ret.Item1, ret.Item2, langId);
            return ret.Item1;
        }

        internal string GetStringInternal(string key, string stringValue, string langId)
        {
            if (string.IsNullOrEmpty(key))
                return "";
            IsValueExists = false;
            try
            {
                string s = GetResxValue(key, langId);
                if (s == null || (s == "" && !string.IsNullOrWhiteSpace(stringValue)))
                {
                    //Dbg.DbgAssert(ResourcePath == null, "resource path for class {0} is not defined", GetType().Name);
                    //Dbg.Debug("Key \'{0}\' is not found in the resource {1}", key, ResourceName);
                    if (ForceAbsentResourceAdding && !Utils.IsEmpty(ResourcePath) && File.Exists(ResourcePath))
                    {
                        return AddResourceEntry(ResourcePath, key, stringValue).ToString();
                    }
                    return ReturnEmptyValue(key, stringValue);

                }
                else
                    IsValueExists = true;
                return s;
            }
            catch (MissingManifestResourceException)
            {
                if (ForceAbsentResourceAdding && !string.IsNullOrWhiteSpace(stringValue) && !Utils.IsEmpty(ResourcePath) && File.Exists(ResourcePath))
                {
                    return AddResourceEntry(ResourcePath, key, stringValue).ToString();
                }
                return ReturnEmptyValue(key, stringValue);
            }
            catch (Exception e)
            {
                Dbg.Debug("error during resource reading \'{0}\' ({1}): {2}", key, ResourceName, e);
            }
            finally
            {
                m_ResourceManager.IgnoreCase = false;
            }
            return ReturnEmptyValue(key, stringValue);
        }


        //full qualified resource name
        public virtual string ResourceName
        {
            get { return GetType().FullName; }
        }
        //path to resource file
        public virtual string ResourcePath
        {
            get
            {
                return GetResourcePath("bv.common\\resources\\");
            }
        }

        protected string GetResourcePath(string dir)
        {
            string result;
            var resName = GetType().Name;
            if (BaseSettings.TranslationMode)
            {
                /*
                //TODO надо ли создавать спецкаталоги Translations с вложенными?
                var langid = Thread.CurrentThread.CurrentUICulture.Name;
                var trDir = Path.Combine(Utils.GetExecutingPath(), TranslationToolHelper.TranslationsDirectoryName);
                var tt = new TranslationToolHelper(trDir, langid);
                result = tt.GetFullPathToResX(resName, langid);
                */

                var trDir = Path.Combine(Utils.GetExecutingPath(), TranslationToolHelper.TranslationsDirectoryName);

                result = m_ResFileName ??
                         (m_ResFileName = Path.Combine(trDir, dir + resName + ".resx"));
            }
            else
            {
                result = m_ResFileName ??
                         (m_ResFileName =
                          Utils.GetSolutionPath() + dir + resName + ".resx");
            }
            return result;
        }

        private static object AddResourceEntry(string resxFile, string resName, string resValue)
        {
            Dbg.Debug(string.Format("adding resource {0} to the {1}", resName, resxFile));
            ResourceHelper.WriteToResx(resxFile, resName, resValue);
            return resValue;
        }


        private string GetResxValue(string resxKey, string cultureName)
        {
            //Dbg.DbgAssert(ResourceName != null, "resource name for class {0} is not defined", GetType().Name);

            // Get the culture of the currently executing thread.
            // The value of ci will determine the culture of
            // the resources that the resource manager retrieves.
            //string result;
            var ci = cultureName == null
                             ? Thread.CurrentThread.CurrentUICulture
                             : new CultureInfo(CustomCultureHelper.SupportedLanguages[cultureName]);

            //if (BaseSettings.TranslationMode)
            //{
            //    var langId = ci.Name;
            //    var tt = new TranslationToolHelper(Path.Combine(Utils.GetExecutingPath(), TranslationToolHelper.TranslationsDirectoryName), langId);
            //    var resFullPath = tt.GetFullPathToResX(ResourceName, langId);
            //    if (File.Exists(resFullPath))
            //    {
            //        //вытаскиваем запрошенную строку из основного ресурса
            //        tt.ReadFromResxFile(resFullPath, resxKey, out result);
            //    }
            //    else return GetDefaultResxString(resxKey, ci);
            //}
            //else
            //{
            //    return GetDefaultResxString(resxKey, ci);
            //}

            return GetDefaultResxString(resxKey, ci);

            //return result;
        }

        private string GetDefaultResxString(string resxKey, CultureInfo ci)
        {
            if ((m_ResourceManager == null) && (ResourceName != null))
            {
                var mainAssembly = Assembly.GetAssembly(GetType());
                m_ResourceManager = new ResourceManager(ResourceName, mainAssembly);
            }

            if (m_ResourceManager != null)
            {
                m_ResourceManager.IgnoreCase = true;
                var s = m_ResourceManager.GetString(resxKey, ci);
                return s;
            }
            return String.Empty;
        }
    }


}
