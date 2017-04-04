using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using bv.winclient.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.model.ResourcesUsage;

namespace bv.tests.WinClient
{
    [TestClass]
    public class ResourceUsageTest
    {
        [TestMethod]
        public void TesGetResourceUsage()
        {
            FillTestData("TestFormsData.xml", "TestResourcesData.xml");
            var resources = new ResourceUsage("TestFormsData.xml", "TestResourcesData.xml");
            List<FormDescription> forms = resources.GetResourceUsage("form 1", "View №1 of form №1", "resFile1", "resource №1");
            Assert.AreEqual(1, forms.Count);
            Assert.AreEqual(2, forms[0].Views.Count);
        }

        [TestMethod]
        public void TestDisplayResourceUsage()
        {
            FillTestData("TestFormsData.xml", "TestResourcesData.xml");
            ChooseWithGridForm.UnitTestMode = true;
            ResourceAction ret = DesktopResourceUsage.DisplayResourceUsage("form 1", "View №1 of form №1", "resFile1", "resource №1","resource №1", "TestFormsData.xml", "TestResourcesData.xml");
            Assert.AreEqual(ResourceAction.Split, ret);
        }

        private void FillTestData(string xmlForms, string xmlResources)
        {
            var resources = new ResourceUsage();
            var form1 = resources.Forms.Add(new FormDescription() { Key = "form 1", FormID = "A1", Caption = "Caption of Form №1", Apptype = "desktop", Obsolete = false });
            form1.AddView("View №1 of form №1");
            form1.AddView("View №2 of form №1");
            var form2 = resources.Forms.Add(new FormDescription() { Key = "form 2", FormID = "B2", Caption = "Caption of Form №2", Apptype = "desktop", Obsolete = false });
            form2.AddView("View №1 of form №2");
            form2.AddView("View №2 of form №2");
            var form10 = resources.Forms.Add(new FormDescription() { Key = "form 10", FormID = "C10", Caption = "Caption of Form №10", Apptype = "desktop", Obsolete = false });
            form10.AddView("View №1 of form №10");
            form10.AddView("View №2 of form №10");
            resources.Forms.Save(xmlForms);
            

            var res1 = resources.Add("resFile1", "resource №1");
            res1.AddForm("form 1", "", resources.Forms);
            res1.AddForm("form 1", "View №1 of form №1", resources.Forms);
            var res2 = resources.Add("resFile1", "resource №1");
            res1.AddForm("form 2", "", resources.Forms);
            var res3 = resources.Add("resFile1", "resource №2");
            res2.AddForm("form 2", "", resources.Forms);
            res3.AddForm("form 10", "", resources.Forms);
            resources.Save(xmlResources);
        }

    }
}
