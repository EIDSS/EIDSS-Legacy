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
        public bool IsValueExists { get; private set; }

        private string ReturnEmptyValue(string stringName, string stringValue)
        {
            string ret = Utils.IsEmpty(stringValue) ? stringName : stringValue;
            if (!Utils.IsEmpty(ret) && BaseSettings.WarnIfResourceEmpty)
                ret = ret + " (TRANSLATED RESOURCE IS ABSENT)";
            return ret;
        }
        public virtual string GetString(string stringName, string stringValue = null, string cultureName = null)
        {
            if (string.IsNullOrEmpty(stringName))
                return "";
            IsValueExists = false;
            try
            {
                string s = GetResxValue(stringName, cultureName);
                if (s == null || (s == "" && !string.IsNullOrWhiteSpace(stringValue)))
                {
                    //Dbg.DbgAssert(ResourcePath == null, "resource path for class {0} is not defined", GetType().Name);
                    //Dbg.Debug("Key \'{0}\' is not found in the resource {1}", stringName, ResourceName);
                    if (ForceAbsentResourceAdding && !Utils.IsEmpty(ResourcePath) && File.Exists(ResourcePath))
                    {
                        return AddResourceEntry(ResourcePath, stringName, stringValue).ToString();
                    }
                    return ReturnEmptyValue(stringName, stringValue);

                }
                else
                    IsValueExists = true;
                return s;
            }
            catch (MissingManifestResourceException)
            {
                if (ForceAbsentResourceAdding && !string.IsNullOrWhiteSpace(stringValue) && !Utils.IsEmpty(ResourcePath) && File.Exists(ResourcePath))
                {
                    return AddResourceEntry(ResourcePath, stringName, stringValue).ToString();
                }
                return ReturnEmptyValue(stringName, stringValue);
            }
            catch (Exception e)
            {
                Dbg.Debug("error during resource reading \'{0}\' ({1}): {2}", stringName, ResourceName, e);
            }
            finally
            {
                m_ResourceManager.IgnoreCase = false;
            }
            return ReturnEmptyValue(stringName, stringValue);
        }
        //full qualified resource name
        public virtual string ResourceName
        {
            get { return GetType().FullName; }
        }
        //path to resource file
        public virtual string ResourcePath
        {
            get { return m_ResFileName ?? (m_ResFileName = Utils.GetSolutionPath() + "bv.common\\resources\\" + GetType().Name + ".resx"); }
        }

        #if !MONO
        private static object AddResourceEntry(string resxFile, string resName, string resValue)
        {
            if (string.IsNullOrWhiteSpace(resValue))
                return resValue;
            //Dbg.Debug(string.Format("adding resource {0} to the {1}", resName, resxFile));
            try
            {
                var rw = new ResXResourceWriter(resxFile);
                // Create a ResXResourceReader for the file items.resx.
                var rsxr = new ResXResourceReader(resxFile);

                // Iterate through the resources and display the contents to the console.
                DictionaryEntry d;
                var entryList = new SortedList();
                bool entryExists = false;
                foreach (DictionaryEntry tempLoopVarD in rsxr)
                {
                    d = tempLoopVarD;
                    if (d.Key.ToString() == resName)
                    {
                        entryExists = true;
                        resValue = d.Value.ToString();
                    }
                    entryList.Add(d.Key, d.Value);
                }

                rsxr.Close();
                if (!entryExists)
                {
                    entryList.Add(resName, resValue);
                }

                for (int i = 0; i <= entryList.Count - 1; i++)
                {
                    rw.AddResource(entryList.GetKey(i).ToString(), entryList.GetByIndex(i));
                }
                rw.Close();
                return resValue;
            }
            catch (Exception e)
            {
                Dbg.Debug(string.Format("resource {0} is not added to the {1}", resName, resxFile), e);
#if DEBUG
                return "";
#else
                return resValue;
#endif
            }

        }
        #endif
        private string GetResxValue(string resxKey, string cultureName)
        {
            //Dbg.DbgAssert(ResourceName != null, "resource name for class {0} is not defined", GetType().Name);
            if (m_ResourceManager == null)
            {
                Assembly mainAssembly = Assembly.GetAssembly(GetType());
                // ReSharper disable AssignNullToNotNullAttribute
                m_ResourceManager = new ResourceManager(ResourceName, mainAssembly);
                // ReSharper restore AssignNullToNotNullAttribute
            }
            // Get the culture of the currently executing thread.
            // The value of ci will determine the culture of
            // the resources that the resource manager retrieves.
            CultureInfo ci = cultureName == null ? Thread.CurrentThread.CurrentUICulture : new CultureInfo(Localizer.SupportedLanguages[cultureName]);
            m_ResourceManager.IgnoreCase = true;
            return m_ResourceManager.GetString(resxKey, ci);
        }
    }


}
