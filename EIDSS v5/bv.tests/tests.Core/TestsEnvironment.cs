using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Core.Security;

namespace bv.tests.Core
{
    public class TestsEnvironment
    {
        public virtual void TestInitialize()
        {
        }

        public virtual void TestCleanup()
        {
        }

        public DbManagerProxy manager { get; protected set; }
        public ModelUserContext context { get; protected set; }
    }


    public class EidssEnv : TestsEnvironment
    {
        public override void TestInitialize()
        {
            base.TestInitialize();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            manager = DbManagerFactory.Factory.Create(context);
            manager.BeginTransaction();
        }

        public override void TestCleanup()
        {
            if (manager != null)
            {
                manager.RollbackTransaction();
                manager.Close();
                manager = null;
            }
            base.TestCleanup();
        }
    }


    public class EidssEnvWithContext : EidssEnv
    {
        public override void TestInitialize()
        {
            EidssUserContext.Init();
            context = ModelUserContext.Instance as EidssUserContext;
            base.TestInitialize();
        }

        public override void TestCleanup()
        {
            if (context != null)
            {
                context.Close();
                context = null;
            }
            base.TestCleanup();
            EidssUserContext.Clear();
        }
    }


    public class EidssEnvWithLogin : EidssEnvWithContext
    {
        private const string Organizaton = "NCDC&PH";
        const string Admin = "test_admin";
        const string User = "test_user";
        const string AdminPassword = "test";
        const string UserPassword = "test";
        private EidssSecurityManager Security;

        public override void TestInitialize()
        {
            base.TestInitialize();
            Security = new EidssSecurityManager();
            int result = Security.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, result);
        }

        public override void TestCleanup()
        {
            if (Security != null)
            {
                Security.LogOut();
            }
            base.TestCleanup();
        }
    }
}
