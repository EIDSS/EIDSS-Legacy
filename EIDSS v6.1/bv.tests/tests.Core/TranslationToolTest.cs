using System.IO;
using System.Reflection;
using System.Xml;
using bv.common.Resources.TranslationTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.tests.Core
{
    /// <summary>
    /// Summary description for TranslationTool
    /// </summary>
    [TestClass]
    public class TranslationToolTest
    {
        public TranslationToolTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void TestResourceSplitterSplit()
        {
            const string fileToSave = @"TestSplittedResources.{0}.xml";
            const string viewName = "viewName";
            const string resourceKey = "resourceKey";
            const string resourceValue = "resourceValue";
            const string lang = "ru-RU";
            string path = Path.GetDirectoryName(Assembly.GetAssembly(typeof(ResourceSplitter)).Location);

            // try
            ResourceSplitter.Split(viewName, "EidssMessages", resourceKey, resourceValue, lang);
            ResourceSplitter.Save(fileToSave, path, viewName, "EidssMessages", resourceKey, resourceValue, lang);

            // Check the result
            var xd = new XmlDocument();
            string file = Path.Combine(path, string.Format(fileToSave, lang));

            Assert.IsTrue(File.Exists(file));

            xd.Load(file);
            XmlNode key = xd.SelectSingleNode(string.Format("splittedResources/key[@id=\"{0}.{1}\"]", viewName, resourceKey));

            Assert.IsNotNull(key);
            Assert.AreEqual(resourceValue, key.InnerText);
        }

        [TestMethod]
        public void TestResourceSplitterRead()
        {
            const string fileToRead = @"TestSplittedResources.{0}.xml";
            const string viewName = "viewName2";
            const string resourceKey = "resourceKey2";
            const string resourceValue = "resourceValue2";
            const string lang = "ru-Ru";
            string path = Path.GetDirectoryName(Assembly.GetAssembly(typeof(ResourceSplitter)).Location);
            ResourceSplitter.Split(viewName, "EidssMessages", resourceKey, resourceValue, lang);
            ResourceSplitter.Save(fileToRead, path, viewName, "EidssMessages", resourceKey, resourceValue, lang);
            // try
            string resourceValueRead = ResourceSplitter.Read(fileToRead, path, viewName, resourceKey, lang);

            // Check the result
            Assert.AreEqual(resourceValue, resourceValueRead);
        }
    }
}
