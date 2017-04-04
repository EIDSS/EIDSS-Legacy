using System;
using System.Collections.Generic;
using System.Threading;
using eidss.model.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests
{
    /// <summary>
    ///This is a test class for EidssUserTest and is intended
    ///to contain all EidssUserTest Unit Tests
    ///</summary>
    [TestClass]
    public class EidssUserTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

       

        /// <summary>
        ///A test for EIDSSUser Constructor
        ///</summary>
        [TestMethod]
        public void EidssUserConstructorTest()
        {
            var target = new EidssUser();
            Assert.IsFalse(target.IsAuthenticated);
           
        }

        /// <summary>
        ///A test for HasObjectPermission
        ///</summary>
        [TestMethod]
        public void HasObjectPermissionTest()
        {
            var target = new EidssUser();
            bool hasPermission = target.HasObjectPermission("");
            Assert.IsFalse(hasPermission);
            hasPermission = target.HasObjectPermission("Always");
            Assert.IsTrue(hasPermission);
            hasPermission = target.HasObjectPermission("test");
            Assert.IsTrue(hasPermission);
            var permissions = new Dictionary<string, bool>
                                  {
                                      {"Update", true},
                                      {"Insert", true},
                                      {"Delete", false},
                                      {"Write", false}
                                  };
            target.ObjectPermissions = permissions;
            hasPermission = target.HasObjectPermission("Delete");
            Assert.IsFalse(hasPermission);
            hasPermission = target.HasObjectPermission("Write");
            Assert.IsFalse(hasPermission);
            hasPermission = target.HasObjectPermission("Update");
            Assert.IsTrue(hasPermission);
            hasPermission = target.HasObjectPermission("Insert");
            Assert.IsTrue(hasPermission);
            hasPermission = target.HasObjectPermission("test");
            Assert.IsTrue(hasPermission);
            hasPermission = target.HasObjectPermission("Insert|Delete");
            Assert.IsTrue(hasPermission);
        }

        /// <summary>
        ///A test for HasPermission
        ///</summary>
        [TestMethod]
        public void HasPermissionTest()
        {
            var target = new EidssUser();
            bool hasPermission = target.HasPermission("");
            Assert.IsFalse(hasPermission);
            hasPermission = target.HasPermission("Always");
            Assert.IsTrue(hasPermission);
            hasPermission = target.HasPermission("test");
            Assert.IsTrue(hasPermission);
            var permissions = new Dictionary<string, bool>
                                  {
                                      {"Update", true},
                                      {"Insert", true},
                                      {"Delete", false},
                                      {"Write", false}
                                  };
            target.Permissions = permissions;
            hasPermission = target.HasPermission("Always");
            Assert.IsTrue(hasPermission);
            hasPermission = target.HasPermission("Delete");
            Assert.IsFalse(hasPermission);
            hasPermission = target.HasPermission("Write");
            Assert.IsFalse(hasPermission);
            hasPermission = target.HasPermission("Update");
            Assert.IsTrue(hasPermission);
            hasPermission = target.HasPermission("Insert");
            Assert.IsTrue(hasPermission);
            hasPermission = target.HasPermission("test");
            Assert.IsFalse(hasPermission);
            hasPermission = target.HasPermission("Insert|Delete");
            Assert.IsTrue(hasPermission);
        }

        /// <summary>
        ///A test for AuthenticationType
        ///</summary>
        [TestMethod]
        public void AuthenticationTypeTest()
        {
            var target = new EidssUser();
            string actual = target.AuthenticationType;
            Assert.AreEqual(actual, "eidss");
        }

        /// <summary>
        ///A test for EmployeeID
        ///</summary>
        [TestMethod]
        public void EmployeeIDTest()
        {
            var target = new EidssUser();
            object expected = 1;
            target.EmployeeID = expected;
            object actual = target.EmployeeID;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FirstName
        ///</summary>
        [TestMethod]
        public void FirstNameTest()
        {
            var target = new EidssUser();
            const string expected = "test";
            target.FirstName = expected;
            string actual = target.FirstName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FullName
        ///</summary>
        [TestMethod]
        public void FullNameTest()
        {
            var target = new EidssUser();
            const string expected = "test";
            target.FullName = expected;
            string actual = target.FullName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ID
        ///</summary>
        [TestMethod]
        public void IDTest()
        {
            var target = new EidssUser();
            object expected = 1;
            target.ID = expected;
            object actual = target.ID;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsAuthenticated
        ///</summary>
        [TestMethod]
        public void IsAuthenticatedTest()
        {
            var target = new EidssUser();
            bool actual = target.IsAuthenticated;
            Assert.IsFalse(actual);
            target.ID = 1;
            actual = target.IsAuthenticated;
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for LastName
        ///</summary>
        [TestMethod]
        public void LastNameTest()
        {
            var target = new EidssUser();
            const string expected = "test";
            target.LastName = expected;
            string actual = target.LastName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LoginName
        ///</summary>
        [TestMethod]
        public void LoginNameTest()
        {
            var target = new EidssUser();
            const string expected = "test";
            target.LoginName = expected;
            string actual = target.LoginName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod]
        public void NameTest()
        {
            var target = new EidssUser();
            string actual = target.Name;
            Assert.AreEqual(String.Empty, actual);
            target.LoginName = "test";
            actual = target.Name;
            Assert.AreEqual(target.LoginName, actual);
        }

        /// <summary>
        ///A test for ObjectPermissions
        ///</summary>
        [TestMethod]
        public void ObjectPermissionsTest()
        {
            var target = new EidssUser();
            IDictionary<string, bool> expected = null;
            target.ObjectPermissions = expected;
            IDictionary<string, bool> actual = target.ObjectPermissions;
            Assert.AreEqual(expected, actual);
            expected = new Dictionary<string, bool>();
            target.ObjectPermissions = expected;
            actual = target.ObjectPermissions;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Organization
        ///</summary>
        [TestMethod]
        public void OrganizationTest()
        {
            var target = new EidssUser();
            const string expected = "test";
            target.OrganizationEng = expected;
            string actual = target.OrganizationEng;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OrganizationID
        ///</summary>
        [TestMethod]
        public void OrganizationIDTest()
        {
            var target = new EidssUser();
            object expected = 1;
            target.OrganizationID = expected;
            object actual = target.OrganizationID;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Permissions
        ///</summary>
        [TestMethod]
        public void PermissionsTest()
        {
            var target = new EidssUser();
            IDictionary<string, bool> expected = null;
            target.Permissions = expected;
            IDictionary<string, bool> actual = target.Permissions;
            Assert.AreEqual(expected, actual);
            expected = new Dictionary<string, bool>();
            target.Permissions = expected;
            actual = target.Permissions;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SecondName
        ///</summary>
        [TestMethod]
        public void SecondNameTest()
        {
            var target = new EidssUser();
            const string expected = "test";
            target.SecondName = expected;
            string actual = target.SecondName;
            Assert.AreEqual(expected, actual);
        }
    }
}