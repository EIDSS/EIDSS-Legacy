using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
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
                           : WinClientContext.CurrentFont.Name;
            }
        }
    }
}