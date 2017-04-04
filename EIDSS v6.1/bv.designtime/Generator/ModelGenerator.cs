using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using System.Runtime.InteropServices;
using Microsoft.Win32;


// Visual Studio 2012 SDK: http://www.microsoft.com/en-au/download/details.aspx?id=30668
// Single File Generator: http://msdn.microsoft.com/ru-ru/library/bb166508.aspx
// Custom tool registration for VS 2012: http://mnaoumov.wordpress.com/2012/09/26/developing-custom-tool-aka-single-file-generators-for-visual-studio-2012/


namespace bv.designtime.Generator
{
    [ComVisible(true)]
    [GeneratorRegistration(typeof(ModelGenerator), @"B&V Model Custom File Generator", vsContextGuidVCSProject, true)] //, false, true)]
    [Guid("8CD3CA10-76FD-4594-AA2B-0DCADA11A694")]
    public class ModelGenerator : IVsSingleFileGenerator
    {
        const string vsVer = "11.0_Config";
        const string vsContextGuidVCSProject = "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}";

        #region Register/unregister
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        /// <param name="contextType"></param>
        [ComRegisterFunction]
        public static void Register(Type contextType)
        {
            Attribute[] attrs = (Attribute[])typeof(ModelGenerator).GetCustomAttributes(typeof(GeneratorRegistrationAttribute), false);
            RegistryKey baseKey = null;
            string codeFile = null;

            foreach (GeneratorRegistrationAttribute attr in attrs)
            {
                foreach (string vs in Properties.Resource.REG_VSKEY.Split(','))
                {
                    baseKey = Registry.CurrentUser.OpenSubKey(Properties.Resource.REG_BASEKEY.FmtStr(vs, vsVer), true);
                    if (baseKey.isValid()) attr.Register(baseKey, codeFile);
                }
            }
        }
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        /// <param name="contextType"></param>
        [ComUnregisterFunction]
        public static void Unregister(Type contextType)
        {
            Attribute[] attrs = (Attribute[])typeof(ModelGenerator).GetCustomAttributes(typeof(GeneratorRegistrationAttribute), false);
            RegistryKey baseKey = null;

            foreach (GeneratorRegistrationAttribute attr in attrs)
            {
                foreach (string vs in Properties.Resource.REG_VSKEY.Split(','))
                {
                    baseKey = Registry.CurrentUser.OpenSubKey(Properties.Resource.REG_BASEKEY.FmtStr(vs, vsVer), true);
                    if (baseKey.isValid()) attr.Unregister(baseKey);
                }
            }
        }
        #endregion

        #region IVsSingleFileGenerator Members

        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = ".edmx";
            return VSConstants.S_OK;
        }

        public int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            try
            {
                XmlDocument source = new XmlDocument();
                source.LoadXml(bstrInputFileContents);

                string xsltFileName = source.DocumentElement.GetAttribute("generator");
                if (xsltFileName == null || xsltFileName == "") 
                    xsltFileName = "ModelGenerator.xslt";
                string xsltFile =
                    wszInputFilePath.Split(new string[] { "Schema" }, StringSplitOptions.None)[0]
                    + @"Schema\XsltGenerator\" + xsltFileName;
                if (!File.Exists(xsltFile))
                    throw new ApplicationException("Xslt file not exists: " + xsltFile);


                XslCompiledTransform transformator = new XslCompiledTransform();
                transformator.Load(xsltFile);

                string rootPath = Path.GetFullPath(wszInputFilePath);
                rootPath = rootPath.Substring(0, rootPath.LastIndexOf('\\') + 1);
                XsltUtil util = new XsltUtil(rootPath, "ConnectionString");
                XsltArgumentList args = new XsltArgumentList();
                args.AddParam("param_namespace", "", wszDefaultNamespace);
                args.AddExtensionObject("urn:util", util);
                using (MemoryStream stream = new MemoryStream())
                {
                    transformator.Transform(source, args, stream);
                    stream.Position = 0;
                    byte[] content = stream.ToArray();
                    pcbOutput = (uint)content.Length;
                    rgbOutputFileContents[0] = Marshal.AllocCoTaskMem((int)content.Length);
                    Marshal.Copy(content, 0, rgbOutputFileContents[0], (int)content.Length);
                }
            }
            catch (Exception ex)
            {
                byte[] content = Encoding.UTF8.GetBytes(ex.ToString());
                pcbOutput = (uint)content.Length;
                rgbOutputFileContents[0] = Marshal.AllocCoTaskMem((int)content.Length);
                Marshal.Copy(content, 0, rgbOutputFileContents[0], (int)content.Length);
            }

            return VSConstants.S_OK;
        }

        #endregion
    }
}
