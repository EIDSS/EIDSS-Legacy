using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.ResourcesUsage;
using bv.common.Resources.TranslationTool;
using System.IO;

namespace eidss.web.common.Utils
{
    public class WebResourceUsage : ResourceUsage
    {
        const string FormsListFile = @"FormList.xml";
        const string ResourcesListFile = @"ResourceUsing.xml";

        protected WebResourceUsage()
        {
            //string root = bv.common.Core.Utils.GetExecutingPath();
            string xmlFormsFileName = Path.Combine(TranslationToolHelper.ResourceUsageDirectoryName, FormsListFile);
            string xmlResourcesFileName = Path.Combine(TranslationToolHelper.ResourceUsageDirectoryName, ResourcesListFile);
            Init(xmlFormsFileName, xmlResourcesFileName);
        }

        public override ResourceAction DisplayResourceUsage(string currentFormName, string currentViewName, string resourceName, string resourceKey, string text)
        {
            List<FormDescription> forms = ResourceUsageList(currentFormName, resourceName, resourceKey);
            return forms.Count == 0 ? ResourceAction.Accept : ResourceAction.Cancel;
        }

        public List<FormDescription> ResourceUsageList(string currentFormName, string resourceName, string resourceKey)
        {
            currentFormName = currentFormName.Replace("ASP._Page_Views_", "").Replace("_cshtml", "").Replace('_', '\\');
            return GetResourceUsage(currentFormName, "", resourceName, resourceKey);
        }

        private static WebResourceUsage g_Instance = new WebResourceUsage();
        public static WebResourceUsage Instance
        {
            get { return g_Instance; }
        }
    }
}
