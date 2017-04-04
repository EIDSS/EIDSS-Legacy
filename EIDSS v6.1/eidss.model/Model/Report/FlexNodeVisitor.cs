using System.Threading;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.Helpers;

namespace eidss.model.Model.Report
{
    public abstract class FlexNodeVisitor
    {
        public abstract void Visit(FlexNodeReport node);

        public static string CurrentFontName
        {
            get
            {
                var languageName = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
                return languageName == Localizer.lngGe || languageName == Localizer.lngAr
                           ? BaseSettings.GGSystemFontName
                           : BaseSettings.SystemFontName;
            }
        }
    }
}
