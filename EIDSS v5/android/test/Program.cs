using System;
using System.Collections.Generic;
//using System.Linq;
using System.Data;
using System.Text;
using bv.com.eidss;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Schema;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Organizaton = "NCDC&PH";
            const string Admin = "test_admin";
            const string User = "test_user";
            const string AdminPassword = "test";
            const string UserPassword = "test";

            OAClient oa = new OAClient("https://192.168.10.34:1443/");
//            OAClient oa = new OAClient("https://vdovinpc:1443/");
            //try
            //{
            oa.Proxy.Login(Organizaton, Admin, AdminPassword, "en");

            /*
            DbManagerFactory.SetRemoteFactory("http://192.168.10.34:8734/qqq");
            EidssUserContext.Init();

            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
                {
                    var target = new EidssSecurityManager();
                    int ret = target.LogIn(Organizaton, Admin, AdminPassword);

                    //HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);

                    //HumanCase hc = acc.CreateNewT(manager, null);

                    //manager.RollbackTransaction();
                }
            }
            EidssUserContext.Clear();
            8/
            /*using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                manager.SetSpCommand("dbo.spCheckVersion",
                                     manager.Parameter("@ModuleName", "aaa"),
                                     manager.Parameter("@ModuleVersion", "1.0.0.1"),
                                     manager.Parameter(ParameterDirection.Output, "@Result", 0)
                    ).ExecuteNonQuery();
                int ret = Convert.ToInt32(manager.Parameter("@Result").Value);
            }*/
        }
    }
}
