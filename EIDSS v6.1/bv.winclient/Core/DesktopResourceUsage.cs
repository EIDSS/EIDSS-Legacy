using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;
using bv.common.Resources.TranslationTool;
using bv.model.ResourcesUsage;

namespace bv.winclient.Core
{
    class DesktopResourceUsage : ResourceUsage
    {
        #region Default Names of xml Files

        //const string XmlFilesDir = "../../../bv.model/ResourcesUsage";
        private static readonly string m_FormsListFile =
            Path.Combine(TranslationToolHelper.ResourceUsageDirectoryName, "FormList.xml");
        private static readonly string m_ResourcesListFile = Path.Combine(TranslationToolHelper.ResourceUsageDirectoryName, "ResourceUsing.xml");
        // получить путь к запущенному exe
        private static string m_AppDir;
        private static string appDir
        {
            get
            {
                if (string.IsNullOrEmpty(m_AppDir))
                {
                    m_AppDir = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
                }
                return m_AppDir;
            }
        }
        
        #endregion

        public DesktopResourceUsage(string xmlFormsFileName, string xmlResourcesFileName):base(xmlFormsFileName, xmlResourcesFileName)
        {
        }

        public override ResourceAction DisplayResourceUsage(string currentFormName, string currentViewName, string resourceName, string resourceKey, string text)
        {
            // remove culture name from file name
            string res = resourceName;
            string ciName = Thread.CurrentThread.CurrentUICulture.Name;
            if (res.EndsWith("." + ciName))
                res = res.Substring(0, res.Length - ciName.Length - 1);
            ///////////////

            List<FormDescription> forms = GetResourceUsage(currentFormName, currentViewName, res, resourceKey);
            return display(forms, resourceKey, text);
        }

        public static ResourceAction DisplayResourceUsage(string currentFormName, string currentViewName, string resourceName, string resourceKey, string text, string xmlFormsFile, string xmlResourcesFile)
        {
            string xmlForms = String.IsNullOrEmpty(xmlFormsFile) ? m_FormsListFile : xmlFormsFile;
            string xmlResources = String.IsNullOrEmpty(xmlResourcesFile) ? m_ResourcesListFile : xmlResourcesFile;

            var resources = new DesktopResourceUsage(xmlForms, xmlResources);
            return resources.DisplayResourceUsage(currentFormName, currentViewName, resourceName, resourceKey, text);
        }

        #region Private Functions
        private static ResourceAction display(List<FormDescription> forms, string resourceKey, string text)
        {
            if (forms == null || forms.Count <= 0)
                return ResourceAction.Accept;

            // construct string with list of forms: 1-st string - column captions
            string formDescription = "Key`Caption`FormID`Apptype`Views`Paths`Comment";
            foreach (FormDescription form in forms)
            {
                formDescription += "^";
                formDescription += form.Key + "`";
                formDescription += form.Caption + "`";
                formDescription += form.FormID + "`";
                formDescription += form.Apptype + "`";
                formDescription += form.ViewsString + "`";
                formDescription += form.PathsString + "`";
                formDescription += form.Comment;
            }
            string ret = ChooseWithGridForm.ChooseWithGrid(String.Format("Term {0} is used in other forms. Do you want to save term translation?", text), "",
                null, "Split", "Save", "Cancel", formDescription);

            if (ret == "Split")
            {
                return ResourceAction.Split;
            }
            if (ret == "Save")
                return ResourceAction.Accept;
            return ResourceAction.Cancel;
        }
        #endregion
    }
}
