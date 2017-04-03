using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;

namespace bv.common.Core
{
    public class Utils
    {
        public const long SEARCH_MODE_ID = -2;

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     Returns safe string representation of object.
        /// </summary>
        /// <param name="o"> object that should be converted to string </param>
        /// <returns>
        ///     Returns string representation of passed object. If passed object is <b>Nothing</b> or <b>DBNull.Value</b> the
        ///     method returns empty string.
        /// </returns>
        /// <history>[Mike]	03.04.2006	Created</history>
        /// -----------------------------------------------------------------------------
        public static string Str(object o)
        {
            return Str(o, "");
        }

        public static string Str(object o, string defaultString)
        {
            if (o == null || o == DBNull.Value)
            {
                return defaultString;
            }
            return o.ToString();
        }

        public static double Dbl(object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return 0.0;
            }
            try
            {
                return Convert.ToDouble(o);
            }
            catch (Exception)
            {
                return 0.0;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     Checks if the passed object represents the valid typed object.
        /// </summary>
        /// <param name="o"> object to check </param>
        /// <returns>
        ///     False if passed object is <b>Nothing</b> or <b>DBNull.Value</b> or its string representation is empty string
        ///     and True in other case.
        /// </returns>
        /// <history>[Mike]	03.04.2006	Created</history>
        /// -----------------------------------------------------------------------------
        public static bool IsEmpty(object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return true;
            }
            if (string.IsNullOrWhiteSpace(o.ToString()))
            {
                return true;
            }
            return false;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     Appends the default string with other separating them with some separator
        /// </summary>
        /// <param name="s"> default string to append </param>
        /// <param name="val"> string that should be appended </param>
        /// <param name="separator"> string that should separate default and appended strings </param>
        /// <remarks>
        ///     method inserts the separator between strings only if default string is not empty.
        /// </remarks>
        /// <history>[Mike]	03.04.2006	Created</history>
        /// -----------------------------------------------------------------------------
        public static void AppendLine(ref string s, object val, string separator)
        {
            if (val == DBNull.Value || val.ToString().Trim().Length == 0)
            {
                return;
            }
            if (s.Length == 0)
            {
                s += val.ToString();
            }
            else
            {
                s += separator + val;
            }
        }

        public static string Join(string separator, IEnumerable collection)
        {
            var result = new StringBuilder();
            object item;
            foreach (object tempLoopVarItem in collection)
            {
                item = tempLoopVarItem;
                if (item == null || string.IsNullOrWhiteSpace(item.ToString()))
                {
                    continue;
                }
                if (result.Length > 0)
                {
                    result.Append(separator);
                }

                result.Append(item.ToString());
            }

            return result.ToString();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     Checks if directory exists and creates it if it is absent
        /// </summary>
        /// <param name="dir"> directory to check </param>
        /// <returns>
        ///     Returns <b>True</b> if requested directory exists or was created successfully and <b>False</b> if requested
        ///     directory can't be created
        /// </returns>
        /// <history>[Mike]	03.04.2006	Created</history>
        /// -----------------------------------------------------------------------------
        public static bool ForceDirectories(string dir)
        {
            int pos = 0;

            try
            {
                do
                {
                    pos = dir.IndexOf(Path.DirectorySeparatorChar, pos);
                    if (pos < 0)
                    {
                        break;
                    }
                    string dirName = dir.Substring(0, pos);
                    if (!Directory.Exists(dirName))
                    {
                        Directory.CreateDirectory(dirName);
                    }
                    pos++;
                } while (true);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                return Directory.Exists(dir);
            }
            catch
            {
                return false;
            }
        }

        public static Bitmap LoadBitmapFromResource(string resName, Type aType)
        {
            //open the executing assembly
            Assembly oAssembly = Assembly.GetAssembly(aType);

            //create stream for image (icon) in assembly
            Stream oStream = oAssembly.GetManifestResourceStream(resName);

            //create new bitmap from stream
            if (oStream != null)
            {
                var oBitmap = (Bitmap) (Image.FromStream(oStream));
                return oBitmap;
            }
            return null;
        }

        public static bool IsGuid(object g)
        {
            string s = Str(g);
            if (s.Length != 36)
            {
                return false;
            }
            try
            {
                new Guid(s);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*		
                public static bool IsEIDSS
                {
                    get
                    {
                        return (ApplicationContext.ApplicationName.ToLowerInvariant() == "eidss");
                    }
                }
		
                public static bool IsPACS
                {
                    get
                    {
                        return (ApplicationContext.ApplicationName.ToLowerInvariant() == "pacs_main");
                    }
                }
        */

        public static T CheckNotNull<T>(T param, string paramName)
        {
            if (ReferenceEquals(param, null))
            {
                throw (new ArgumentNullException(paramName));
            }

            return param;
        }

        public static string CheckNotNullOrEmpty(string param, string paramName)
        {
            if (CheckNotNull(param, paramName) == string.Empty)
            {
                throw (new ArgumentException(paramName + " cannot be empty string"));
            }

            return param;
        }

        public static string GetParentDirectoryPath(string dirName)
        {
            string appLocation = GetExecutingPath();
            dirName = dirName.ToLowerInvariant();
            var dir = new DirectoryInfo(Path.GetDirectoryName(appLocation));
            while (dir != null && dir.Name.ToLowerInvariant() != dirName)
            {
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    if (subDir.Name.ToLower(CultureInfo.InvariantCulture) == dirName)
                    {
                        return subDir.FullName + "\\";
                    }
                }
                dir = dir.Parent;
            }
            if (dir != null)
            {
                return string.Format("{0}\\", dir.FullName);
            }
            return null;
        }

        //It is assumed that assembly is placed in the project that is located in solution directory;
        public static string GetSolutionPath()
        {
            string binPath = GetParentDirectoryPath("bin");
            var dir = new DirectoryInfo(Path.GetDirectoryName(binPath));
            return string.Format("{0}\\", dir.Parent.Parent.FullName);
        }
        public static string GetDesktopExecutingPath()
        {
            DirectoryInfo appDir;
            Assembly asm = Assembly.GetExecutingAssembly();
            if (!asm.GetName().Name.StartsWith("nunit"))
            {
                appDir = new DirectoryInfo(Path.GetDirectoryName(GetAssemblyLocation(asm)));
                return string.Format("{0}\\", appDir.FullName);
            }
            asm = Assembly.GetCallingAssembly();
            appDir = new DirectoryInfo(Path.GetDirectoryName(GetAssemblyLocation(asm)));
            return string.Format("{0}\\", appDir.FullName);
            
        }

        public static string GetExecutingPath()
        {
            DirectoryInfo appDir;
            if (HttpContext.Current != null)
            {
                try
                {
                    appDir = new DirectoryInfo(HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(appDir.FullName))
                    {
                        return string.Format("{0}", appDir.FullName);
                    }
                }
                catch
                {
                }
            }
            return GetDesktopExecutingPath();
        }

        public static string GetAssemblyLocation(Assembly asm)
        {
            if (asm.CodeBase.StartsWith("file:///"))
            {
                return asm.CodeBase.Substring(8).Replace("/", "\\");
            }
            return asm.Location;
        }

        public static string GetFilePathNearAssembly(Assembly asm, string fileName)
        {
            string location = ConvertFileName(asm.Location);
            string locationFileName = string.Format(@"{0}\{1}", Path.GetDirectoryName(location), fileName);
            if (File.Exists(locationFileName))
            {
                return locationFileName;
            }

            string codeBase = ConvertFileName(asm.CodeBase);
            string codeBaseFileName = string.Format(@"{0}\{1}", Path.GetDirectoryName(codeBase), fileName);
            if (File.Exists(codeBaseFileName))
            {
                return codeBaseFileName;
            }

            throw new FileNotFoundException(
                string.Format("Could not find file placed neither {0} nor {1}", locationFileName, codeBaseFileName), fileName);
        }

        public static string ConvertFileName(string fileName)
        {
            if (fileName.StartsWith("file:///"))
            {
                return fileName.Substring(8).Replace("/", "\\");
            }
            return fileName;
        }

        public static string GetConfigFileName()
        {
            if (HttpContext.Current != null)
            {
                return "Web.config";
            }
            Assembly asm = Assembly.GetEntryAssembly();
            if (asm != null)
            {
                return Path.GetFileName(asm.Location) + ".config";
            }
            return "";
        }

        public static long? ToNullableLong(object val)
        {
            if (IsEmpty(val))
            {
                return null;
            }
            long res;
            if (long.TryParse(val.ToString(), out res))
                return res;
            return null;
        }
        public static int? ToNullableInt(object val)
        {
            if (IsEmpty(val))
            {
                return null;
            }
            int res;
            if (int.TryParse(val.ToString(), out res))
                return res;
            return null;
        }

        public static bool IsCalledFromUnitTest()
        {
            var stack = new StackTrace();
            int frameCount = stack.FrameCount - 1;

            for (int frame = 0; frame <= frameCount; frame++)
            {
                StackFrame stackFrame = stack.GetFrame(frame);
                if (stackFrame != null)
                {
                    MethodBase method = stackFrame.GetMethod();
                    if (method != null)
                    {
                        string moduleName = method.Module.Name;
                        if (moduleName.Contains("tests"))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private static string GetAssemblyCodeBaseLocation(Assembly asm)
        {
            if (asm.CodeBase.StartsWith("file:///"))
            {
                return asm.CodeBase.Substring(8).Replace("/", "\\");
            }
            return asm.Location;
        }

        public static string GetExecutingAssembly()
        {
            string app;
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.PhysicalApplicationPath;
            }
            Assembly asm = Assembly.GetEntryAssembly();
            if (asm == null)
            {
                asm = Assembly.GetExecutingAssembly();
            }
            if (!asm.GetName().Name.StartsWith("nunit"))
            {
                app = GetAssemblyCodeBaseLocation(asm);
                if (app != null)
                {
                    return app;
                }
            }
            asm = Assembly.GetCallingAssembly();
            app = GetAssemblyCodeBaseLocation(asm);
            if (app != null)
            {
                return app;
            }
            return null;
        }

        public static object ToDbValue(object val)
        {
            if (val == null)
            {
                return DBNull.Value;
            }
            return val;
        }

        public static long ToLong(object o, long defValue = 0)
        {
            if (o == null || o == DBNull.Value)
            {
                return defValue;
            }
            try
            {
                return Convert.ToInt64(o);
            }
            catch (Exception)
            {
                return defValue;
            }
        }
        public static long ToInt(object o, int defValue = 0)
        {
            if (o == null || o == DBNull.Value)
            {
                return defValue;
            }
            try
            {
                return Convert.ToInt32(o);
            }
            catch (Exception)
            {
                return defValue;
            }
        }

        public static string GetCurrentMethodName()
        {
            return GetMethodName(2);
        }

        public static string GetPreviousMethodName()
        {
            return GetMethodName(3);
        }

        private static string GetMethodName(int index)
        {
            var stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(index);
            string name = stackFrame != null
                ? stackFrame.GetMethod().Name
                : "CANNOT_GET_METHOD_NAME";
            return name;
        }

        public static object SafeDate(object date)
        {
            return IsEmpty(date) ? "..." : date;
        }

        public static DateTime? ToDateNullable(string date)
        {
           if(IsEmpty(date))
               return null;
            DateTime res;
            if (DateTime.TryParse(date, out res))
                return res;
            return null;
        }
    }
}