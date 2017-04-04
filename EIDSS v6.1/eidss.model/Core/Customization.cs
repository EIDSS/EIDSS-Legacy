using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.common.Core;
using System.Reflection;

namespace eidss.model.Core
{
    public class Customization
    {
        private static readonly object m_Lock = new object();
        private static volatile ICustomization g_Instance;
        public static ICustomization Instance
        {
            get
            {
                lock (m_Lock)
                {
                    if (g_Instance == null)
                    {
                        string assemblyName = Utils.GetExecutingPathBin() + "eidss.model.customization.dll";
                        //LogError.Log("MessageLog", new Exception(), c => c.WriteLine(assemblyName));
                        Assembly a = Assembly.LoadFrom(assemblyName);
                        Type t = a.GetType("eidss.model.customization.Core.CustomizationCreator", true);
                        MethodInfo m = t.GetMethod("Create", BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
                        var p = new object[] { EidssSiteContext.Instance.CustomizationPackageID };
                        g_Instance = m.Invoke(null, p) as ICustomization;
                    }
                    return g_Instance;
                }
            }
        }
    }
}
