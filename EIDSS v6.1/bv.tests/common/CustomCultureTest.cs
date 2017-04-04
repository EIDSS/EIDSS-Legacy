using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Core;

namespace bv.tests.common
{
    [TestClass]
    public class CustomCultureTest
    {
        [TestMethod]
        public void RegistrationTest()
        {
            CustomCultureHelper.UnRegisterAll();
            foreach (var culture in CustomCultureHelper.SupportedCustomCultures)
            {
                var cultureName = CustomCultureHelper.GetCustomCultureName(culture.Item1, culture.Item2);
                Assert.IsFalse(CustomCultureHelper.IsCultureRegistered(cultureName));
                Assert.IsFalse(
                    File.Exists(string.Format("{0}\\Globalization\\{1}.nlp",
                                              Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                                              cultureName)));
            }
            CustomCultureHelper.RegisterAll();
            foreach (var culture in CustomCultureHelper.SupportedCustomCultures)
            {
                var cultureName = CustomCultureHelper.GetCustomCultureName(culture.Item1, culture.Item2);
                Assert.IsTrue(CustomCultureHelper.IsCultureRegistered(cultureName));
                Assert.IsTrue(
                    File.Exists(string.Format("{0}\\Globalization\\{1}.nlp",
                                              Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                                              cultureName)));
            }
        }
    }
}
