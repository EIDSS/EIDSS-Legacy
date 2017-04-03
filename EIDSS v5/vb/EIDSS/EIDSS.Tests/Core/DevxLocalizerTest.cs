using System.Globalization;
using System.Threading;
using bv.common.win;
using NUnit.Framework;
using GlobalSettings = bv.common.GlobalSettings;

namespace EIDSS.Tests.Core
{
    [TestFixture]
    public class DevxLocalizerTest
    {
        [Test, Ignore("Manual test")]
        public void AddAllResources()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            DevXLocalizer.ForceResourceAdding();
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            //Thread.CurrentThread.CurrentCulture  = new CultureInfo("ru-RU");
            //GlobalSettings.CurrentLanguage = GlobalSettings.lngRu;
            //DevXLocalizer.ForceResourceAdding();
        }
        
    }
}