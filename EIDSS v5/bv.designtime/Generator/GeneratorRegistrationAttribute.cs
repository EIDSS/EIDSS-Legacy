using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Microsoft.VisualStudio.Shell;
using System.Globalization;

// from http://social.msdn.microsoft.com/forums/en-US/vsx/thread/091f5fde-dd6f-401a-b50f-5fe14234b2bb

namespace bv.designtime.Generator
{
    public static class StringExtentions
    {
        /// <summary>
        /// Wrapper for the string.Format() Shared Function.
        /// </summary>
        /// <param name="GetItem">Calling string Object</param>
        /// <param name="args">ParamArray of Format Argumnets</param>
        /// <returns>string</returns>
        /// <remarks></remarks>
        public static string FmtStr(this string item, params object[] args)
        {
            return item.isValid() ? string.Format(CultureInfo.InvariantCulture, item, args) : string.Empty;
        }

        /// <summary>
        /// Cross-Board object comparison.  Similar to Assert but without any negative effects, simple bool return
        /// </summary>
        /// <param name="items">object Calling Extension</param>
        /// <returns>bool - Is a Valid object or Not</returns>
        /// <remarks></remarks>
        public static bool isValid<T>(this T self)
        {
            return (self != null);
        }

        /// <summary>
        /// returns if a string is Valid (! Blank)
        /// </summary>
        /// <param name="item">Calling string Object</param>
        /// <returns>bool</returns>
        /// <remarks></remarks>
        public static bool isValid(this string item)
        {
            return (item != null) && (item.Length > 0);
        }

    }

    /// <summary>
    /// Custom Tool Registration Attribute Handles the Registration of a Custom Tool Class
    /// <para>Derived from the <see cref="Microsoft.VisualStudio.Shell.RegistrationAttribute"/> Abstract class</para>
    /// </summary>
    /// <remarks>The Overridden Constructors provide differing access to the default 
    /// values of properties for use during Registration, primarily <see cref="GeneratorRegistrationAttribute.CreateSource"/> 
    /// defaults to true and <see cref="GeneratorRegistrationAttribute.CreateSharedSource"/>defaults to false.</remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class GeneratorRegistrationAttribute : RegistrationAttribute
    {
        #region -------------::< Fields & Constants >::-------------
        private const string KEYFMT = @"Generators\{0}\{1}";
        private const string CLSID = @"CLSID";
        private const string GENSRC = @"GeneratesDesignTimeSource";
        private const string GENSHR = @"GeneratesSharedDesignTimeSource";
        internal const string PROCSVR = @"InprocServer32";
        private const string ASSMBL = @"Assembly";
        private const string MODEL = @"ThreadingModel";
        private const string CLASS = @"Class";
        internal const string CODEBASE = @"Codebase";
        private const string MsCorePathFormatStr = @"C:\Windows\{0}\mscoree.dll";

        private Type _toolType;
        private string _toolDesc;
        private string _language;
        private bool _source;
        private bool _shared;
        #endregion

        #region -------------::< Class Properties >::-------------
        
        private static string MSCORE
        {
            get 
            {
                int osArchitecture = GetOsArchitecture();
                return String.Format(MsCorePathFormatStr, GetSystemDirectoryNameByOsArchitecture(osArchitecture));
            }
        } 

        /// <summary>
        /// Accessor for the Custom Tool Class's Type
        /// </summary>
        /// <value>System.Type</value>
        public Type ToolType { get { return _toolType; } }
        /// <summary>
        /// Accessor for the Custom Tool's Description
        /// </summary>
        /// <value>String</value>
        public string Description { get { return _toolDesc; } }
        /// <summary>
        /// Accessor for the Language Context GUID, used to determine Generator's 
        /// Language Sub key during registration into the specific Visual Studio IDE's.
        /// </summary>
        public string Language { get { return _language; } }
        /// <summary>
        /// Accessor for the GenerateDesignTimeSource Registry Flag
        /// Indicating this Custom Tool Generates a Design Time Source File.
        /// </summary>
        public bool CreateSource
        {
            get { return _source; }
            set { _source = value; }
        }
        /// <summary>
        /// Accessor for the GenerateSharedDesignTimeSource Registry Flag
        /// Indicating this Custom Tool Generates a Shared Design Time Source File
        /// </summary>
        public bool CreateSharedSource
        {
            get { return _shared; }
            set { _shared = value; }
        }
        #endregion

        #region -------------::< Class Constructors >::-------------
        /// <summary>
        /// Overloaded Constructor
        /// <para>Provides the values for <paramref name="generatorType"/>, <paramref name="generatorDesc"/>, 
        /// and <paramref name="contextGuid"/> for Registering the Custom Tool, Assuming default values for
        /// <see cref="CreateSource"/> and <see cref="CreateSharedSource"/>.</para>
        /// </summary>
        /// <param name="generatorType">The System.Type describing the Custom Tool Class (<see cref="typeof"/>).</param>
        /// <param name="generatorDesc">Description Element of the Custom Tool</param>
        /// <param name="Context">Language Specific Context GUID (<see cref="VSLangProj80.vsContextGuids"/>).</param>
        public GeneratorRegistrationAttribute(Type generatorType, string generatorDesc, string contextGuid) :
            this(generatorType, generatorDesc, contextGuid, true, false) { }

        /// <summary>
        /// Overloaded Constructor
        /// <para>Provides the values for <paramref name="generatorType"/>, <paramref name="generatorDesc"/>, 
        /// <paramref name="contextGuid"/>, and <paramref name="createSource"/> for Registering the Custom Tool, Assuming 
        /// the default value for <see cref="CreateSharedSource"/>.</para>
        /// </summary>
        /// <param name="generatorType">The System.Type describing the Custom Tool Class (<see cref="typeof"/>).</param>
        /// <param name="generatorDesc">Description Element of the Custom Tool</param>
        /// <param name="contextGuid">Language Specific Context GUID (<see cref="VSLangProj80.vsContextGuids"/>)</param>
        /// <param name="createSource">Boolean Flag Setting the <see cref="CreateSource"/> property</param>
        public GeneratorRegistrationAttribute(Type generatorType, string generatorDesc, string contextGuid, bool createSource) :
            this(generatorType, generatorDesc, contextGuid, createSource, false) { }

        /// <summary>
        /// Overloaded Constructor
        /// <para>Provides the values for <paramref name="generatorType"/>, <paramref name="generatorDesc"/>, 
        /// <paramref name="Context"/>, <paramref name="createSource"/>, and <paramref name="createShared"/> 
        /// for Registering the Custom Tool.</para>
        /// </summary>
        /// <param name="generatorType">The System.Type describing the Custom Tool Class (<see cref="typeof"/>).</param>
        /// <param name="generatorDesc">Description Element of the Custom Tool</param>
        /// <param name="contextGuid">Language Specific Context GUID (<see cref="VSLangProj80.vsContextGuids"/>).</param>
        /// <param name="createSource">Boolean Flag Setting the <see cref="CreateSource"/> property</param>
        /// <param name="createShared">Boolean Flag Setting the <see cref="CreateSharedSource"/> property</param>
        public GeneratorRegistrationAttribute(Type generatorType, string generatorDesc, string contextGuid, bool createSource, bool createShared)
        {
            if (generatorType == null)
                throw new ArgumentNullException("generatorType");
            if (generatorDesc == null)
                throw new ArgumentNullException("generatorDesc");
            if (contextGuid == null)
                throw new ArgumentNullException("contextGuid");

            _toolDesc = generatorDesc;
            _toolType = generatorType;
            _language = contextGuid;
            this.CreateSource = createSource;
            this.CreateSharedSource = createShared;
        }
        #endregion

        #region -------------::< Public Methods >::-------------
        /// <summary>
        /// Overridden Abstract MethDecl handling the registration of the Custom Tool into 
        /// the System Registry based on provided properties.
        /// </summary>
        /// <param name="context">Provided RegistrationContext for the base Registry key 
        /// from which to add further Registration subkeys values.</param>
        public override void Register(RegistrationContext context)
        {
            using (Key generatorKey = context.CreateKey(KEYFMT.FmtStr(_language, _toolType.Name)))
            {
                generatorKey.SetValue(string.Empty, _toolDesc);
                generatorKey.SetValue(CLSID, _toolType.GUID.ToString("B"));
                generatorKey.SetValue(GENSRC, _source ? 1 : 0);
                if (_shared) generatorKey.SetValue(GENSHR, 1);
            }
            using (Key key = context.CreateKey(CLSID + @"\" + _toolType.GUID.ToString("B")))
            {
                key.SetValue(string.Empty, _toolDesc);
                //Console.WriteLine("ProcSvr: " + MSCORE);
                key.SetValue(PROCSVR, MSCORE);
                key.SetValue(MODEL, "Both");
                //Console.WriteLine("Class:" + _toolType.FullName);
                key.SetValue(CLASS, _toolType.FullName);
                //Console.WriteLine("Assembly: " + _toolType.AssemblyQualifiedName);
                key.SetValue(ASSMBL, _toolType.AssemblyQualifiedName);
            }
        }

        /// <summary>
        /// Overridden Abstract MethDecl handling the removal of the Custom Tool from
        /// the System Registry based on provided properties.
        /// </summary>
        /// <param name="context">Provided RegistrationContext for the base Registry key
        /// from which to remove previous registered subkeys and values.</param>
        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(KEYFMT.FmtStr(_language, _toolType.Name));
            context.RemoveKey(CLSID + @"\" + _toolType.GUID.ToString("B"));
        }

        public void Register(RegistryKey baseKey, string CodeFile)
        {
            if (baseKey.isValid())
            {
                string tmpKey = string.Empty;
                if (!baseKey.OpenSubKey(tmpKey = KEYFMT.FmtStr(_language, _toolType.Name)).isValid()) baseKey.CreateSubKey(tmpKey);
                //Console.WriteLine(tmpKey);
                using (RegistryKey key = baseKey.OpenSubKey(tmpKey, true))
                {
                    //Console.WriteLine("Desc: " + _toolDesc);
                    key.SetValue(string.Empty, _toolDesc);
                    //Console.WriteLine("Guid: " + _toolType.GUID.ToString("B"));
                    key.SetValue(CLSID, _toolType.GUID.ToString("B"));
                    //Console.WriteLine("GenSrc: " + (_source ? 1 : 0));
                    key.SetValue(GENSRC, _source ? 1 : 0);
                    if (_shared) key.SetValue(GENSHR, 1);
                }
                if (!baseKey.OpenSubKey(tmpKey = CLSID + @"\" + _toolType.GUID.ToString("B")).isValid()) baseKey.CreateSubKey(tmpKey);
                //Console.WriteLine(tmpKey);
                using (RegistryKey key = baseKey.OpenSubKey(tmpKey, true))
                {
                    key.SetValue(string.Empty, _toolDesc);
                    //Console.WriteLine("ProcSvr: " + MSCORE);
                    key.SetValue(PROCSVR, MSCORE);
                    key.SetValue(MODEL, "Both");
                    //Console.WriteLine("Class:" + _toolType.FullName);
                    key.SetValue(CLASS, _toolType.FullName);
                    //Console.WriteLine("Assembly: " + _toolType.AssemblyQualifiedName);
                    key.SetValue(ASSMBL, _toolType.AssemblyQualifiedName);
                    if (CodeFile.isValid()) key.SetValue(CODEBASE, CodeFile);
                }
            }
        }

        public void Unregister(RegistryKey baseKey)
        {
            try
            {
                string tmpKey = string.Empty;
                if (baseKey.OpenSubKey(tmpKey = KEYFMT.FmtStr(_language, _toolType.Name), true).isValid()) baseKey.DeleteSubKey(tmpKey);
                if (baseKey.OpenSubKey(tmpKey = CLSID + @"\" + _toolType.GUID.ToString("B"), true).isValid()) baseKey.DeleteSubKey(tmpKey);
            }
            catch (Exception)
            {
            }
        }
        #endregion

        private static int GetOsArchitecture()
        {
            string pa = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            return ((String.IsNullOrEmpty(pa) || String.Compare(pa, 0, "x86", 0, 3, true) == 0) ? 32 : 64);
        }

        private static string GetSystemDirectoryNameByOsArchitecture(int osArchitecture)
        {
            return osArchitecture == 64 ? "SysWOW64" : "system32";
        }
    }
}
