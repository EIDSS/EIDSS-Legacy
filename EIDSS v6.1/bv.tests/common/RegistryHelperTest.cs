using bv.common.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests
{
    
    
    /// <summary>
    ///This is a test class for RegistryHelperTest and is intended
    ///to contain all RegistryHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RegistryHelperTest
    {


        private TestContext testContextInstance;

        private const string Section = "SOFTWARE";
        private const string KeyName = "EidssTestKey";
        private const string ValueName = "EidssTestValueName";
        private const string Value = "EidssTestValue";
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }



        /// <summary>
        ///A test for DeleteSubkey
        ///</summary>
        [TestMethod()]
        public void DeleteSubkeyTest()
        {
            RegistryHelper.Write(Section, KeyName, ValueName,Value);
            string val = RegistryHelper.Read(Section, KeyName, ValueName);
            Assert.AreEqual(Value, val);
            RegistryHelper.DeleteSubkey(Section, KeyName);
            val = RegistryHelper.Read(Section, KeyName, ValueName);
            Assert.AreEqual("",val);
        }

        /// <summary>
        ///A test for DeleteValue
        ///</summary>
        [TestMethod()]
        public void DeleteValueTest()
        {
            RegistryHelper.Write(Section, KeyName, ValueName, Value);
            string val = RegistryHelper.Read(Section, KeyName, ValueName);
            Assert.AreEqual(Value, val);
            RegistryHelper.DeleteValue(Section, KeyName, ValueName, Value);
            val = RegistryHelper.Read(Section, KeyName, ValueName);
            Assert.AreEqual("", val);
        }

        /// <summary>
        ///A test for Read
        ///</summary>
        [TestMethod()]
        public void ReadTest()
        {
            RegistryHelper.Write(Section, KeyName, ValueName, Value);
            string actual = RegistryHelper.Read(Section, KeyName, ValueName);
            Assert.AreEqual(Value, actual);
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            RegistryHelper.Write(Section, KeyName, ValueName, Value);
            string actual = RegistryHelper.Read(Section, KeyName, ValueName);
            Assert.AreEqual(Value, actual);
            RegistryHelper.Write(Section, KeyName, ValueName, "");
            actual = RegistryHelper.Read(Section, KeyName, ValueName);
            Assert.AreEqual("", actual);
        }
    }
}
