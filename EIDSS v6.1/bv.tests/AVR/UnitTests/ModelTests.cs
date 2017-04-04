using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using bv.common.Core;
using bv.common.win;
using bv.tests.AVR.Helpers.Fake;
using eidss.avr.BaseComponents;
using eidss.model.Avr.Commands.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ModelTests
    {
        private BaseForm m_ParentForm;
        private SharedModel m_SharedModel;

        [TestInitialize]
        public void SetUp()
        {
            m_ParentForm = new BaseForm();
            m_SharedModel = new SharedModel(m_ParentForm, new FakeExportDialogStrategy());
        }

        [TestCleanup]
        public void TearDown()
        {
            MemoryManager.Flush();
        }

        [TestMethod]
        public void ConstructorSharedModelTest()
        {
            Console.WriteLine(@"ConstructorSharedModelTest");

            Assert.AreEqual(m_ParentForm, m_SharedModel.ParentForm);
        }

    

        #region Properties tests


        [TestMethod]
        public void SharedModelSelectedQueryIdTest()
        {
            TestProperty(m_SharedModel, SharedProperty.SelectedQueryId, -100L, 4L);
        }

        [TestMethod]
        public void SharedModelSelectedLayoutIdTest()
        {
            TestProperty(m_SharedModel, SharedProperty.SelectedLayoutId, -100L, 3L);
        }

        [TestMethod]
        public void SharedModelStandardReportsTest()
        {
            TestProperty(m_SharedModel, SharedProperty.StandardReports, false, true);
        }

        [TestMethod]
        public void SharedModelStartUpParametersTest()
        {
            TestProperty(m_SharedModel, SharedProperty.StartUpParameters, null, new Dictionary<string, object>());
        }

        [TestMethod]
        public void SharedModelExportDialogStrategyTest()
        {
            TestProperty(m_SharedModel, SharedProperty.ExportStrategy, m_SharedModel.ExportStrategy,
                new ExportDialogStrategy());
        }

        private static void TestProperty
            (INotifyPropertyChanged model, SharedProperty propertyName, object oldValue,
                object newValue)
        {
            Console.WriteLine(propertyName + @"Test");
            object value = GetPropertyValue(model, propertyName.ToString());

            Assert.AreEqual(oldValue, value);
            model.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                Assert.AreEqual(propertyName.ToString(), e.PropertyName);
                Assert.AreEqual(newValue, GetPropertyValue(model, propertyName.ToString()));
                Console.WriteLine(propertyName + @" changed.");
            };
            SetPropertyValue(model, propertyName.ToString(), newValue);
        }

        private static object GetPropertyValue(object model, string propertyName)
        {
            PropertyInfo propertyInfo = GetPropertyInfo(model, propertyName);
            return propertyInfo.GetValue(model, null);
        }

        private static void SetPropertyValue(object model, string propertyName, object value)
        {
            PropertyInfo propertyInfo = GetPropertyInfo(model, propertyName);
            propertyInfo.SetValue(model, value, null);
        }

        private static PropertyInfo GetPropertyInfo(object model, string propertyName)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(propertyName, "propertyName");
            PropertyInfo property = model.GetType().GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException(string.Format("Property {0} doesnt exists", propertyName));
            }
            return property;
        }

        #endregion
    }
}