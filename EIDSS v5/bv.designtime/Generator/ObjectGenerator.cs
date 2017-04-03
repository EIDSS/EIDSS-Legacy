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


// Visual Studio 2010 SDK: http://www.microsoft.com/downloads/en/details.aspx?FamilyID=47305cf4-2bea-43c0-91cd-1b853602dcc5&displaylang=en
// Single File Generator: http://msdn.microsoft.com/ru-ru/library/bb166508.aspx

// bv.designtime.Generator.XsltUtil | urn:util

namespace bv.designtime.Generator
{
    [ComVisible(true)]
    [GeneratorRegistration(typeof(ObjectGenerator), @"B&V Objects VC# Custom File Generator", vsContextGuidVCSProject, true)] //, false, true)]
    [Guid("38CC5BC1-3E35-40ba-BDCB-53FA1563A2FF")]
    public class ObjectGenerator : IVsSingleFileGenerator
    {
        const string vsVer = "10.0";
        const string vsContextGuidVCSProject = "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}";

        #region Register/unregister
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        /// <param name="contextType"></param>
        [ComRegisterFunction]
        public static void Register(Type contextType)
        {
            Attribute[] attrs = (Attribute[])typeof(ObjectGenerator).GetCustomAttributes(typeof(GeneratorRegistrationAttribute), false);
            RegistryKey baseKey = null;
            string codeFile = null;

            foreach (GeneratorRegistrationAttribute attr in attrs)
            {
                foreach (string vs in Properties.Resource.REG_VSKEY.Split(','))
                {
                    baseKey = Registry.LocalMachine.OpenSubKey(Properties.Resource.REG_BASEKEY.FmtStr(vs, vsVer), true);
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
            Attribute[] attrs = (Attribute[])typeof(ObjectGenerator).GetCustomAttributes(typeof(GeneratorRegistrationAttribute), false);
            RegistryKey baseKey = null;

            foreach (GeneratorRegistrationAttribute attr in attrs)
            {
                foreach (string vs in Properties.Resource.REG_VSKEY.Split(','))
                {
                    baseKey = Registry.LocalMachine.OpenSubKey(Properties.Resource.REG_BASEKEY.FmtStr(vs, vsVer), true);
                    if (baseKey.isValid()) attr.Unregister(baseKey);
                }
            }
        }
        #endregion

        #region IVsSingleFileGenerator Members

        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = ".model.cs";
            return VSConstants.S_OK;
        }

        private void MergeXml(XmlNode dest, XmlNode src)
        {
            XmlElement selem = src as XmlElement;
            XmlElement delem = dest as XmlElement;
            if (selem != null && delem != null)
            {
                foreach (XmlAttribute a in selem.Attributes)
                {
                    delem.SetAttribute(a.Name, a.Value);
                }
            }
            
            foreach (XmlNode node_src in src.ChildNodes)
            {
                XmlElement elem_src = node_src as XmlElement;
                if (elem_src != null)
                {
                    string path = "bv:" + node_src.LocalName;
                    if (node_src.LocalName != "table")
                    {
                        string name = elem_src.GetAttribute("name");
                        if (!string.IsNullOrEmpty(name))
                            path = path + "[@name = '" + name + "']";
                    }
                    XmlNamespaceManager mngr = new XmlNamespaceManager(dest.OwnerDocument.NameTable);
                    mngr.AddNamespace("bv", node_src.NamespaceURI);
                    XmlNode node_dest = dest.SelectSingleNode(path, mngr);
                    if (node_dest == null)
                    {
                        XmlNode cloned = dest.OwnerDocument.ImportNode(node_src, true);
                        dest.AppendChild(cloned);
                    }
                    else
                    {
                        MergeXml(node_dest, node_src);
                    }
                }
            }
        }

        public int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            try
            {
                XmlDocument source = new XmlDocument();
                source.LoadXml(bstrInputFileContents);

                string inherited_filename = source.DocumentElement.GetAttribute("inherited");
                if (!string.IsNullOrEmpty(inherited_filename))
                {
                    string inherited_path = Path.GetDirectoryName(wszInputFilePath) + "\\" + inherited_filename;
                    XmlDocument inherited = new XmlDocument();
                    inherited.Load(inherited_path);
                    MergeXml(inherited.DocumentElement, source.DocumentElement);
                    bstrInputFileContents = inherited.OuterXml;
                }

                string xsltFileName = source.DocumentElement.GetAttribute("generator");
                if (xsltFileName == null || xsltFileName == "") 
                    xsltFileName = "ObjectGenerator.xslt";
                string xsltFile =
                    wszInputFilePath.Split(new string[] { "Schema" }, StringSplitOptions.None)[0]
                    + @"..\bv.model\Schema\XsltGenerator\" + xsltFileName;
                if (!File.Exists(xsltFile))
                    throw new ApplicationException("Xslt file is not exists: " + xsltFile);

                string connectionKey = source.DocumentElement.GetAttribute("connection");
                if (connectionKey == null || connectionKey == "")
                    xsltFileName = "ConnectionString";


                XslCompiledTransform transformator = new XslCompiledTransform();
                transformator.Load(xsltFile);

                string rootPath = Path.GetFullPath(wszInputFilePath);
                rootPath = rootPath.Substring(0, rootPath.LastIndexOf('\\') + 1);

                XsltUtil util = new XsltUtil(rootPath, connectionKey);
            
                XsltArgumentList args = new XsltArgumentList();
                args.AddParam("param_namespace", "", wszDefaultNamespace);
                args.AddExtensionObject("urn:util", util);
                
                using (MemoryStream stream = new MemoryStream())
                {
                    using (StringReader inp = new StringReader(bstrInputFileContents))
                    {
                        transformator.Transform(new XmlTextReader(inp), args, stream);
                        stream.Position = 0;
                        byte[] content = stream.ToArray();
                        pcbOutput = (uint) content.Length;
                        rgbOutputFileContents[0] = Marshal.AllocCoTaskMem((int) content.Length);
                        Marshal.Copy(content, 0, rgbOutputFileContents[0], (int) content.Length);
                    }
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
