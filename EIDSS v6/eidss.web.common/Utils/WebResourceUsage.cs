using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.ResourcesUsage;

namespace eidss.web.common.Utils
{
    public class WebResourceUsage : ResourceUsage
    {
        const string FormsListFile = @"App_Data\Translations\ResourceUsage\FormList.xml";
        const string ResourcesListFile = @"App_Data\Translations\ResourceUsage\ResourceUsing.xml";

        protected WebResourceUsage()
        {
            string root = bv.common.Core.Utils.GetExecutingPath();
            string xmlFormsFileName = root + FormsListFile;
            string xmlResourcesFileName = root + ResourcesListFile;
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
