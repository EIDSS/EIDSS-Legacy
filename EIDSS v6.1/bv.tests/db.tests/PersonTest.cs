using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.Core;
using eidss.model.Schema;

namespace bv.tests.db.tests
{
    [TestClass]
    public class PersonTest : EidssEnvWithLogin
    {
        private Person.Accessor m_Acc;
        private Person m_Person;

        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
            m_Acc = Person.Accessor.Instance(null);
            
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            m_Acc = null;
            m_Person = null;
            base.TestCleanup();
        }


        [TestMethod]
        public void Creating()
        {
            m_Person = m_Acc.CreateNewT(manager, null);
            Assert.IsNotNull(m_Person);
            //Assert.IsNotNull(m_Person.Site);
            Assert.IsTrue(m_Person.idfPerson > 0);
            Assert.IsTrue(m_Person.idfsSite > 0);
            Assert.IsTrue(m_Person.ObjectAccessList.Count > 0);
            Assert.IsTrue(m_Person.ObjectAccessListFiltered.Count > 0);

            const string familyName = "Test family name";
            const string firstName = "Test first name";
            
            m_Person.strFirstName = firstName;
            m_Person.strFamilyName = familyName;
            m_Person.Institution = m_Person.InstitutionLookup.Skip(1).FirstOrDefault();

            Assert.IsTrue(m_Acc.Post(manager, m_Person));

            var mp = m_Acc.SelectByKey(manager, m_Person.idfPerson);
            Assert.IsNotNull(mp);
            Assert.IsTrue(m_Person.idfPerson == mp.idfPerson);
            Assert.IsTrue(m_Person.strFirstName == mp.strFirstName);
            Assert.IsTrue(m_Person.strFamilyName == mp.strFamilyName);

            //Assert.IsNotNull(mp.Site);
            Assert.IsTrue(mp.ObjectAccessList.Count > 0);
            Assert.IsTrue(mp.ObjectAccessListFiltered.Count > 0);
        }
    }
}
