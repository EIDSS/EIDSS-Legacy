using System;
using System.Collections.Generic;
using System.Linq;
using bv.tests.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Enums;
using eidss.openapi.bll.Bll;
using eidss.openapi.contract;
using eidss.openapi.bll.Converters;

namespace bv.tests.openapi
{
    [TestClass]
    public class OpenApiOrganizationTest : EidssEnvWithLogin
    {

        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void OpenApiTestOrganizationGeneral()
        {
            var list = OrganizationBll.Select(new OrganizationListFilter());
            Assert.IsTrue(list.Count > 0);
            var abbr = list[0].Abbreviation;
            var id = list[0].RecordID;

            list = OrganizationBll.Select(new OrganizationListFilter() { RecordID = -1 });
            Assert.IsTrue(list.Count == 0);
            
            list = OrganizationBll.Select(new OrganizationListFilter() { Abbreviation = abbr });
            Assert.IsTrue(list.Count > 0);//we can have several records with this filter because search is performed using like 'abrr%'

            var org = OrganizationBll.Select(id);
            Assert.IsNotNull(org);

            var orgIn = new Organization() { LocalAbbreviation = "TEST", LocalOrganizationName = "test", UniqueOrganizationID = "Uniq", Persons =  new List<Person>() };
            orgIn.Persons.Add(new Person() { PersonFirstName = "first", PersonLastName = "last" });
            var orgOut = OrganizationBll.Create(orgIn);
            Assert.IsNotNull(orgOut);
            Assert.AreNotEqual(0, orgOut.RecordID);
            Assert.IsNotNull(orgOut.Persons);
            Assert.AreEqual(1, orgOut.Persons.Count);
            Assert.AreEqual("first", orgOut.Persons[0].PersonFirstName);

            var prsIn = new Person() { PersonFirstName = "first1", PersonLastName = "last1" };
            var prsOut = OrganizationPersonBll.Create(orgOut.RecordID, prsIn);
            Assert.IsNotNull(prsOut);
            Assert.AreNotEqual(0, prsOut.RecordID);
            Assert.AreEqual("first1", prsOut.PersonFirstName);

            org = OrganizationBll.Select(orgOut.RecordID);
            Assert.IsNotNull(org);
            Assert.AreEqual(orgOut.RecordID, org.RecordID);
            Assert.IsNotNull(org.Persons);
            Assert.AreEqual(2, org.Persons.Count);
            Assert.AreEqual("first", org.Persons[0].PersonFirstName);
            Assert.AreEqual("first1", org.Persons[1].PersonFirstName);

            list = OrganizationBll.Select(new OrganizationListFilter() { RecordID = orgOut.RecordID });
            Assert.IsTrue(list.Count == 1);

            list = OrganizationBll.Select(new OrganizationListFilter() { Abbreviation = "TEST" });
            Assert.IsTrue(list.Count == 1);

            OrganizationPersonBll.Delete(org.RecordID, org.Persons[1].RecordID);
            OrganizationPersonBll.Delete(org.RecordID, org.Persons[0].RecordID);
            OrganizationBll.Delete(org.RecordID);

            //org = OrganizationBll.Select(orgOut.RecordID);
            //Assert.IsNull(org);

            list = OrganizationBll.Select(new OrganizationListFilter() { RecordID = orgOut.RecordID });
            Assert.IsTrue(list.Count == 0);

            list = OrganizationBll.Select(new OrganizationListFilter() { Abbreviation = "TEST" });
            Assert.IsTrue(list.Count == 0);
        }


    }
}
