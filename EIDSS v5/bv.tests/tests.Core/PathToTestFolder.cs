using System.IO;
using System.Reflection;

namespace bv.tests.Core
{
    public enum TestFolders
    {
        Common,
        Db,
        WinClient,
        Client
    }

    public class PathToTestFolder
    {
        private static string GetAssemblyCodeBaseLocation(Assembly asm)
        {
            if (asm.CodeBase.StartsWith("file:///"))
            {
                return asm.CodeBase.Substring(8).Replace("/", "\\");
            }
            return asm.Location;
        }
        public static string Get(TestFolders folderType)
        {
            Assembly asm = Assembly.GetAssembly(typeof(PathToTestFolder));
            if (asm != null)
            {
                DirectoryInfo appDir = new DirectoryInfo(Path.GetDirectoryName(GetAssemblyCodeBaseLocation(asm)));
// ReSharper disable PossibleNullReferenceException
                var result = string.Format("{0}\\{1}.Tests\\", appDir.Parent.Parent.FullName, folderType);
                if (Directory.Exists(result))
                    return result;

                result = string.Format("{0}\\bv.tests\\{1}.Tests\\", appDir.Parent.Parent.Parent.FullName, folderType);
                if (Directory.Exists(result))
                    return result;

                // For tests
                return string.Format("{0}\\{1}.Tests\\", appDir.FullName, folderType); ;
                
// ReSharper restore PossibleNullReferenceException
            }
            return "..\\" + folderType + ".Tests\\";
        }
    }
}