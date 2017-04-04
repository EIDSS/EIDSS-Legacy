

using System.Threading;
using bv.common.Configuration;
using bv.common.Core;
using bv.winclient.Core;

namespace EIDSS.FlexibleForms.Helpers.ReportHelper.Tree
{
    public abstract class FlexNodeVisitor
    {
        public abstract void Visit(FlexNode node);


        public static string CurrentFontName
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == Localizer.lngGe
                           ? BaseSettings.GGSystemFontName
                           : BaseSettings.SystemFontName;
            }
        }
    }
}