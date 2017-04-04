using System;
using System.Reflection;
using bv.tests.common;
using bv.tests.Core;
using DevExpress.XtraReports.UI;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.Document.Human.CaseInvestigation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.Reports
{
    [TestClass]
    public class AccessToReportsTests : EidssEnvWithLogin
    {
        private class AttributeTestClass
        {
            [ForbiddenDataGroup(PersonalDataGroup.Human_PersonName, PersonalDataGroup.Human_Employer_Details)]
            public void ForbiddenAccessMethod()
            {
            }

            [MenuReportCustomization(CustomizationPackage.DTRA)]
            public void AllowedCustomizationCountryMethod()
            {
            }

            [MenuReportCustomization(CustomizationPackage.Ukraine)]
            public void ForbiddenCustomizationCountryMethod()
            {
            }

            [MenuReportCustomization(Forbidden = new[] {CustomizationPackage.Ukraine})]
            public void AllowedCustomizationOtherCountryMethod()
            {
            }

            [MenuReportCustomization(Forbidden = new[] {CustomizationPackage.Ukraine, CustomizationPackage.DTRA})]
            public void ForbiddenCustomizationOtherCountryMethod()
            {
            }

            [MenuReportCustomization]
            public void AllowedCustomizationMethod()
            {
            }

            public void MethodWithoutAttributes()
            {
            }

            [MenuReportDescription(ReportSubMenu.Human, "xxx", 100)]
            public void CaptionMethod()
            {
            }
        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            BaseReportTests.LoadAssemblies();
        }

        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
            EidssUserContext.User.ForbiddenPersonalDataGroups.Add(PersonalDataGroup.Human_PersonName);
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void TestAttributeForbiddenGroup()
        {
            var testClass = new AttributeTestClass();
            MethodInfo info = testClass.GetType().GetMethod("ForbiddenAccessMethod");
            Assert.IsNotNull(info);

            Assert.IsTrue(BaseMenuReportRegistrator.IsDenyInDataGroup(info));
        }

        [TestMethod]
        public void TestAttributeAllowedGroup()
        {
            var testClass = new AttributeTestClass();
            MethodInfo info = testClass.GetType().GetMethod("MethodWithoutAttributes");
            Assert.IsNotNull(info);

            Assert.IsFalse(BaseMenuReportRegistrator.IsDenyInDataGroup(info));
        }

        [TestMethod]
        public void TestAttributeAllowedCustomizationCountry()
        {
            var testClass = new AttributeTestClass();
            MethodInfo info = testClass.GetType().GetMethod("AllowedCustomizationCountryMethod");
            Assert.IsNotNull(info);

            Assert.IsFalse(BaseMenuReportRegistrator.IsDenyInCustomization(info));
        }

        [TestMethod]
        public void TestAttributeAllowedCustomizationOtherCountry()
        {
            var testClass = new AttributeTestClass();
            MethodInfo info = testClass.GetType().GetMethod("AllowedCustomizationOtherCountryMethod");
            Assert.IsNotNull(info);

            Assert.IsFalse(BaseMenuReportRegistrator.IsDenyInCustomization(info));
        }

        [TestMethod]
        public void TestAttributeForbiddenCustomization()
        {
            var testClass = new AttributeTestClass();
            MethodInfo info = testClass.GetType().GetMethod("ForbiddenCustomizationCountryMethod");
            Assert.IsNotNull(info);

            Assert.IsTrue(BaseMenuReportRegistrator.IsDenyInCustomization(info));
        }

        [TestMethod]
        public void TestAttributeForbiddenOtherCustomization()
        {
            var testClass = new AttributeTestClass();
            MethodInfo info = testClass.GetType().GetMethod("ForbiddenCustomizationOtherCountryMethod");
            Assert.IsNotNull(info);

            Assert.IsTrue(BaseMenuReportRegistrator.IsDenyInCustomization(info));
        }

        [TestMethod]
        public void TestAttributeAllowedCustomization()
        {
            var testClass = new AttributeTestClass();
            MethodInfo info = testClass.GetType().GetMethod("MethodWithoutAttributes");
            Assert.IsNotNull(info);

            Assert.IsTrue(BaseMenuReportRegistrator.IsDenyInCustomization(info));

            info = testClass.GetType().GetMethod("AllowedCustomizationMethod");
            Assert.IsNotNull(info);

            Assert.IsFalse(BaseMenuReportRegistrator.IsDenyInCustomization(info));
        }

        [TestMethod]
        public void TestAttributeCaption()
        {
            var testClass = new AttributeTestClass();
            MethodInfo info = testClass.GetType().GetMethod("CaptionMethod");
            Assert.IsNotNull(info);
            MenuReportDescriptionAttribute attribute = BaseMenuReportRegistrator.GetMenuActionDescriptionAttribute(info);
            Assert.IsNotNull(attribute);

            Assert.AreEqual("xxx", attribute.Caption);
            Assert.AreEqual(100, attribute.Order);
        }

        [TestMethod]
        public void TestCaseInvestigationWithStub()
        {
            var report = new CaseInvestigationReport();

            XRTableCell nameCell = GetCell(report, "xrTableCell21");
            Assert.AreEqual("CaseInvestigation.NameOfPatient", nameCell.DataBindings[0].DataMember);
            XRTableCell sexCell = GetCell(report, "xrTableCell27");
            Assert.AreEqual("CaseInvestigation.Sex", sexCell.DataBindings[0].DataMember);

            var rebinder = new AccessRigthsRebinder(report);
            rebinder.Process();

            Assert.AreEqual(0, nameCell.DataBindings.Count);
            Assert.AreEqual("*", nameCell.Text);
            Assert.AreEqual(1, sexCell.DataBindings.Count);
        }

        private static XRTableCell GetCell(XtraReport report, string cellName)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            FieldInfo nameFieldInfo = report.GetType().GetField(cellName, flags);
            if (nameFieldInfo == null)
            {
                throw new ApplicationException(string.Format("Could not find XRTableCell {0} in report", cellName));
            }
            return (XRTableCell) nameFieldInfo.GetValue(report);
        }
    }
}