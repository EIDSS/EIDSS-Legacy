using System;
using System.Web.UI;
using System.Threading;
using System.Globalization;
using bv.common.Core;
using bv.model.Model.Core;
using eidss.model.Core;

namespace eidss.ram.web
{
    public class BasePage : Page
    {

        protected override void InitializeCulture()
        {
            string selectedLanguage = Page.Request.QueryString["lang"];

            if (String.IsNullOrWhiteSpace(selectedLanguage))
            {
                selectedLanguage = (string) Session["Language"] ?? "en-US";
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

            Session["Language"] = selectedLanguage;
            ModelUserContext.CurrentLanguage = Localizer.GetLanguageID(Thread.CurrentThread.CurrentCulture);

            base.InitializeCulture();
        }
    }
}