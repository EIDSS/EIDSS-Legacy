using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.IO;
using System.Collections.Generic;
using bv.common.Diagnostics;
using System.Linq;

/// -----------------------------------------------------------------------------
/// Project	 : bv.common
/// Class	 : common..Core.ClassLoader
///
/// -----------------------------------------------------------------------------
/// <summary>
/// Used to register .NET assemblies and load the class from registered assembly
/// by class name using reflection mechanism
/// </summary>
/// <remarks>
/// This class simplifies the class instance creation using <b>Reflection</b> mechanism.
/// Any assembly that supposed to be called using <b>Reflection</b>  should be registered by <i>Init</i> method call.
/// To create the class instance call <i>LoadClass</i> or <i>LoadObject</i> method.
/// </remarks>
/// <history>
/// 	[Mike]	22.03.2006	Created
/// </history>
/// -----------------------------------------------------------------------------
namespace bv.common.Core
{
    public class ClassLoader
    {

        private static Dictionary<string, moduleInfo> m_Modules = new Dictionary<string, moduleInfo>();
        private static Dictionary<string, string> m_AssemblyList = new Dictionary<string, string>();
        private struct moduleInfo
        {
            public string FullName;
            public string AssemblyName;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Registers all assemblies that fit to the passed wildcard mask.
        /// </summary>
        /// <param name="mask"> the wildcard mask for assemblies to be registered
        /// </param>
        /// <remarks>
        /// <i>Init</i> method can be called several times with different wildcard masks.
        /// All assemblies that fit the mask and not registered yet will be appended to the registered assemblies list.
        /// The following wildcard specifiers are permitted in <i>mask</i>.
        /// <list type="table">
        ///<listheader>
        ///<term>Wildcard character</term>
        ///<description>Description</description>
        ///</listheader>
        ///<item><term>*</term>
        ///<description>Zero or more characters.</description></item>
        ///<item><term>?</term>
        /// <description>Exactly one character.</description></item>
        /// </list>
        ///Characters other than the wildcard specifiers represent themselves. For example, the <i>mask</i> string
        ///"*.dll" searches for all files having extension <i>dll</i> in the directory containing application executable.
        ///The <i>mask</i> string 'eidss*.dll' searches for all assemblies which names begin from 'eidss'.
        ///The <i>mask</i> parameter can point to absolute or relative path information.
        ///Relative path information is interpreted as relative to the directory containing application executable.
        ///The path parameter is not case-sensitive.
        ///For an example of using this method, see the <b>Example</b> section below.
        /// </remarks>
        /// <example>
        /// The following example registers all assemblies starting with "eidss" in the directory with the application executable
        /// creates the instance of the class HumanCaseList that is inherited from BaseForm, and uses this instance to show the created form.
        /// <code>
        /// ClassLoader.Init("eidss*.dll")
        /// Dim humanCaseForm As Object = ClassLoader.LoadControl("HumanCaseList")
        /// If Not humanCaseForm Is Nothing Then
        ///     BaseForm.ShowNormal(CType(humanCaseForm, BaseForm))
        /// End If
        /// </code>
        /// </example>
        /// <history>
        /// 	[Mike]	22.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static void Init(string mask, string appdir)
        {
            if (appdir == null)
            {
                appdir = Utils.GetExecutingPath();
            }
            if (Path.GetDirectoryName(mask) != "")
            {
                appdir = Path.GetDirectoryName(mask);
                mask = Path.GetFileName(mask);
            }
            string[] files = Directory.GetFiles(appdir, mask);
            foreach (string file in files)
            {
                if (m_AssemblyList.ContainsKey(Path.GetFileName(file)))
                    m_AssemblyList[Path.GetFileName(file)] = file;
                else
                    m_AssemblyList.Add(Path.GetFileName(file), file);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Searches the class in the registered assemblies and creates the class instance.
        /// </summary>
        /// <param name="className">
        /// the class name to load.
        /// </param>
        /// <returns>
        /// Returns the instance of the created class or throws the exception if class can't be created.
        /// </returns>
        /// <remarks>
        /// If method is called first time for the requested class name, it searches the class in the registered assemblies
        /// and cash the relation between class and assembly if assembly is found. If class is not found in the registered assemblies,  SystemExeption with message 'Class not found' is thrown.
        /// </remarks>
        /// <history>
        /// 	[Mike]	22.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object LoadClass(string className)
        {
            if (Utils.IsEmpty(className))
                return null;
            Exception rethrow = null;
            ObjectHandle hdl = null;
            string AssemblyName = FindModuleAssembly(ref className, ref hdl);
            if (hdl == null)
            {
                try
                {
                    //try to load from primary assembly
                    //ClassLoader.AssemblyName should return assembly name related with specific form
                    //if you will add new forms to the project be sure that GetAssemblyName method
                    //will return correct assembly name for this form
                    hdl = System.Activator.CreateInstance(AssemblyName, className);
                }
                catch (TargetInvocationException e)
                {
                    rethrow = e.InnerException;
                    Dbg.Debug(string.Format("EIDSS_LoadClass:Can\'t create class {0}, Assembly {1}:{2}{3}", className, AssemblyName, "\r\n", e.InnerException.Message), (System.Exception)null);
                }
                catch (Exception e)
                {
                    Dbg.Debug(string.Format("EIDSS_LoadClass:Can\'t create class {0}, Assembly {1}:{2}{3}", className, AssemblyName, "\r\n", e.Message), (System.Exception)null);
                    throw (new SystemException(string.Format("Can\'t create class {0}:{1}{2}", className, "\r\n", e.Message), e));
                }
                if (rethrow != null)
                {
                    throw (rethrow);
                }
            }
            return hdl.Unwrap();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Searches the class in the registered assemblies, and returns the full assembly name containing the class
        /// </summary>
        /// <param name="className">
        /// the class name that should be contained by assembly.
        /// </param>
        /// <param name="hdl">
        /// returns the <b>ObjectHandle</b> to the class instance if the class is requested first time. In other case this parameter returns <b>Nothing</b>
        /// </param>
        /// <returns>
        /// Returns the full qualified assembly name that contains the requested class
        /// </returns>
        /// <remarks>
        /// If method is called first time for this specific class, it tries to load the class from all registered assemblies
        /// and after successful attempt cash the assembly name for this class and returns the handler to the class instance in the <i>hdl</i> parameter.
        /// If class was already loaded before, it just returns the cashed class assembly name.
        /// If assembly for requested files was not found, SystemException with message 'Class not found' is thrown.
        /// </remarks>
        /// <history>
        /// 	[Mike]	22.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static string FindModuleAssembly(ref string className, ref ObjectHandle hdl)
        {
            moduleInfo mi;
            if (m_Modules.ContainsKey(className))
            {
                mi = m_Modules[className];
                className = mi.FullName;
                return mi.AssemblyName;
            }

            string cName = className;
            bool wasError = false;
            foreach (var assemblyName in m_AssemblyList.Keys)
            {
                Assembly a;
                try
                {
                    a = Assembly.LoadFrom(m_AssemblyList[assemblyName]);
                    var type = a.GetTypes().FirstOrDefault(t => t.FullName == cName || t.Name == cName);
                    if (type != null)
                    {
                        hdl = LoadClassByName(a.FullName, type.FullName);
                        if (hdl != null)
                        {
                            mi.AssemblyName = a.FullName;
                            mi.FullName = type.FullName;
                            m_Modules[className] = mi;
                            return a.FullName;
                        }
                    }
                }
                catch (Exception e)
                {
                    Dbg.Debug(string.Format("EIDSS_LoadClass:Can\'t create class {0}, Assembly {1}{2}:{3}{4}", className, AppDomain.CurrentDomain.BaseDirectory, assemblyName, "\r\n", e.Message), (System.Exception)null);
                    Dbg.Debug(string.Format("Stack trace:{0}", e.StackTrace), (System.Exception)null);
                    if (e.InnerException != null)
                    {
                        Dbg.Debug(string.Format("InerException:Can\'t create class {0}, Assembly {1}{2}:{3}{4}", className, AppDomain.CurrentDomain.BaseDirectory, assemblyName, "\r\n", e.InnerException.Message), (System.Exception)null);
                        Dbg.Debug(string.Format("Stack trace:{0}", e.InnerException.StackTrace), (System.Exception)null);
                    }
                    wasError = true;
                }
            }
            if (!wasError) throw (new Exception(string.Format("Class {0} is not found in registerd assemblies", className)));
            return String.Empty;
        }

        public static Type FindType(string className)
        {
            foreach (var assemblyName in m_AssemblyList.Keys)
            {
                try
                {
                    var a = Assembly.LoadFrom(m_AssemblyList[assemblyName]);
                    return  a.GetTypes().FirstOrDefault(t => t.FullName == className || t.Name == className);
                }
                catch (Exception e)
                {
                    Dbg.Debug(string.Format("EIDSS_LoadClass:Can\'t create class {0}, Assembly {1}{2}:{3}{4}", className, AppDomain.CurrentDomain.BaseDirectory, assemblyName, "\r\n", e.Message), (System.Exception)null);
                    Dbg.Debug(string.Format("Stack trace:{0}", e.StackTrace), (System.Exception)null);
                    if (e.InnerException != null)
                    {
                        Dbg.Debug(string.Format("InerException:Can\'t create class {0}, Assembly {1}{2}:{3}{4}", className, AppDomain.CurrentDomain.BaseDirectory, assemblyName, "\r\n", e.InnerException.Message), (System.Exception)null);
                        Dbg.Debug(string.Format("Stack trace:{0}", e.InnerException.StackTrace), (System.Exception)null);
                    }
                }
            }
            return null;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Loads class from the specific assembly
        /// </summary>
        /// <param name="AssemblyName">
        /// full qualified assembly name
        /// </param>
        /// <param name="className">
        /// class name to load
        /// </param>
        /// <returns>
        /// the new instance of the class. Throws the exception if the instance can't be created
        /// </returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	22.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static ObjectHandle LoadClassByName(string AssemblyName, string ClassName)
        {
            try
            {
                return System.Activator.CreateInstance(AssemblyName, ClassName);
            }
            catch (TargetInvocationException e)
            {
                throw (e.InnerException);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates the new instance of the specific type
        /// </summary>
        /// <param name="ClassType">
        /// the type of object to create
        /// </param>
        /// <returns>
        /// Returns the new instance of the class. Throws the exception if the instance can't be created
        /// </returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	22.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static object LoadClass(Type ClassType)
        {
            if (ClassType == null)
            {
                return null;
            }
            try
            {
                return System.Activator.CreateInstance(ClassType);
            }
            catch (TargetInvocationException e)
            {
                throw (e.InnerException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public static Type LoadType(string ClassName)
        //{
        //    if (ClassName == null)
        //    {
        //        return null;
        //    }
        //    foreach (string AssemblyName in m_AssemblyList.Keys)
        //    {
        //        Assembly a = null;
        //        try
        //        {
        //            a = Assembly.LoadFrom(m_AssemblyList[AssemblyName]);
        //            Type[] mytypes = a.GetTypes();
        //            foreach (Type t in mytypes)
        //            {
        //                if (t.FullName == ClassName || t.Name == ClassName)
        //                {
        //                    return t;
        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Dbg.Debug(string.Format("EIDSS_LoadClass:Can\'t load class type{0}, Assembly {1}{2}:{3}{4}", ClassName, AppDomain.CurrentDomain.BaseDirectory, AssemblyName, "\r\n", e.Message), (System.Exception)null);
        //            Dbg.Debug(string.Format("Stack trace:{0}", e.StackTrace), (System.Exception)null);
        //            if (e.InnerException != null)
        //            {
        //                Dbg.Debug(string.Format("InerException:Can\'t load class type {0}, Assembly {1}{2}:{3}{4}", ClassName, AppDomain.CurrentDomain.BaseDirectory, AssemblyName, "\r\n", e.InnerException.Message), (System.Exception)null);
        //                Dbg.Debug(string.Format("Stack trace:{0}", e.InnerException.StackTrace));
        //            }
        //        }
        //    }
        //    return null;
        //}
    }

}
