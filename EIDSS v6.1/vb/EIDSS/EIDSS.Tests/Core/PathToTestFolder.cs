using System.IO;
using System.Reflection;

namespace EIDSS.Tests.Core
{
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
        public static string Get(string testFolder)
        {
            Assembly asm = Assembly.GetAssembly(typeof(PathToTestFolder));
            if (asm != null)
            {
                DirectoryInfo appDir = new DirectoryInfo(Path.GetDirectoryName(GetAssemblyCodeBaseLocation(asm)));
// ReSharper disable PossibleNullReferenceException
                return string.Format("{0}\\{1}\\", appDir.Parent.Parent.FullName, testFolder);
// ReSharper restore PossibleNullReferenceException
            }
            return "..\\" + testFolder + "\\";
        }
    }
}